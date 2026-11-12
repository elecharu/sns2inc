CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_PRDRST(
-- *****************************************************************************
-- Comment: 생산실적 등록 (작업지시·작업이력·생산실적·자재사용출고·실적로트 입고)
--          ) 투입로트별 사용량으로 PRDINS, PRDWORK, PRDWORK_EMP, PRDRST, PRDRSTUSE, PRDRSTBAD,
--            COMOUT, COMOUTLOT(현재고 차감), PRDRSTLOT, COMIN, COMINLOT, COMLOT 생성
--          ) 생산수량 = 사용량 합계, 불량수량 = 라인 불량(PRDLINEBAD) 합계, 양품수량 = 생산 - 불량 (실적로트는 양품수량)
--          ) 불량이 있으면 같은 로트번호로 불량창고(제품 04S230_N, 반제품 04S130_N)에 입고 (INTP 05)
--          ) 진행 중 비가동이 있으면 막고, 라인 비가동(PRDRSTNON)에 작업키 연결
--          ) 끝나면 라인 정보(PRDLINESCAN, PRDLINEITEM, PRDLINEEMP, PRDLINEBAD) 삭제
--          ) 결과: 실적로트번호(LOTKEY), 양품수량(GOODQTY)
-- Create: 2026-10-29
-- Modify: 2026-10-29 라인 불량을 실적 불량수량·PRDRSTBAD 로 반영
--         2026-10-30 진행 중 비가동 확인, 비가동 작업키 연결
--         2026-11-05 작업지시 주야구분(PRDINS.DNTP) 저장 (DAY/NIGHT)
--         2026-11-06 실적로트 불량수량(PRDRSTLOT.BADQTY), 불량재고 입고(COMIN·COMINLOT·COMLOT)
--         2026-11-11 ERP 인터페이스(PRDINS, PRDRST) 송신 추가
-- *****************************************************************************
  IN $LINECD VARCHAR(100),     -- 작업장
  IN $PRCCD VARCHAR(100),      -- 공정
  IN $EQMCD VARCHAR(100),      -- 라인
  IN $ITEMID INT(11),          -- 생산품목ID
  IN $DNTP VARCHAR(100),       -- 주야구분 (PP161)
  IN $WORKSDAY VARCHAR(10),    -- 작업시작일
  IN $WORKSTIME VARCHAR(8),    -- 작업시작시간
  IN $WORKEDAY VARCHAR(10),    -- 작업종료일
  IN $WORKETIME VARCHAR(8),    -- 작업종료시간
  IN $LOTKEY_LIST MEDIUMTEXT,  -- 투입로트 목록
  IN $USEQTY_LIST MEDIUMTEXT   -- 투입로트별 사용량 목록
)
PROC: BEGIN
-- *****************************************************************************
  DECLARE _$WARECD VARCHAR(100);
  DECLARE _$LOTKEY_LIST MEDIUMTEXT;
  DECLARE _$USEQTY_LIST MEDIUMTEXT;
  DECLARE _$LOTKEY VARCHAR(100);
  DECLARE _$USEQTY_TXT VARCHAR(100);
  DECLARE _$USEQTY DECIMAL(20, 8);
  DECLARE _$LOTQTY DECIMAL(20, 8);
  DECLARE _$PRODQTY DECIMAL(20, 8);
  DECLARE _$BADQTY DECIMAL(20, 8);
  DECLARE _$GOODQTY DECIMAL(20, 8);
  DECLARE _$INSQTY DECIMAL(20, 8);
  DECLARE _$STIME VARCHAR(19);
  DECLARE _$ETIME VARCHAR(19);
  DECLARE _$INWARECD VARCHAR(100);
  DECLARE _$BADWARECD VARCHAR(100);
  DECLARE _$PRDINSKEY VARCHAR(100);
  DECLARE _$PRDWORKKEY VARCHAR(100);
  DECLARE _$PRDRSTKEY VARCHAR(100);
  DECLARE _$INKEY VARCHAR(100);
  DECLARE _$OUTKEY VARCHAR(100);
  DECLARE _$USEITEMID VARCHAR(100);
  DECLARE _$RSTLOTKEY VARCHAR(100);
-- *****************************************************************************

  -- 0. 입력 확인
  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($ITEMID, 0) = 0 THEN
    CALL COMERR('생산품목이 없습니다. 투입로트를 스캔하세요.');
    LEAVE PROC;
  END IF;

  IF $DNTP = '' THEN
    CALL COMERR('주야구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $WORKSDAY = '' OR $WORKSTIME = '' OR $WORKEDAY = '' OR $WORKETIME = '' THEN
    CALL COMERR('작업시작일, 시작시간, 작업종료일, 종료시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT PRDLINEEMP.EMPCD
                   FROM PRDLINEEMP
                   WHERE PRDLINEEMP.LINECD = $LINECD
                     AND PRDLINEEMP.PRCCD = $PRCCD
                     AND PRDLINEEMP.EQMCD = $EQMCD) THEN
    CALL COMERR('작업자를 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 실적로트 입고창고: 작업장·공정 기준, 제품(DM100100)이면 제품입고창고, 아니면 반제품입고창고
  SET _$INWARECD = (SELECT IF(MSTITEM.ITEMCG = 'DM100100', MSTLINE_PRC.PROD_IN_WH, MSTLINE_PRC.SEMI_IN_WH)
                      FROM MSTLINE_PRC
                      INNER JOIN MSTITEM
                        ON MSTITEM.ITEMID = $ITEMID
                      WHERE MSTLINE_PRC.LINECD = $LINECD
                        AND MSTLINE_PRC.PRCCD = $PRCCD
                      LIMIT 1);

  IF IFNULL(_$INWARECD, '') = '' THEN
    CALL COMERR(CONCAT('실적로트 입고창고가 없습니다. 작업장 공정정보(MSTLINE_PRC)를 확인하세요.'
                      , '\n- 작업장: ', $LINECD
                      , '\n- 공정: ', $PRCCD
                      )
               );
    LEAVE PROC;
  END IF;

  -- 불량로트 입고창고: 제품(DM100100)이면 제품불량창고, 아니면 재공불량창고
  SET _$BADWARECD = (SELECT IF(MSTITEM.ITEMCG = 'DM100100', '04S230_N', '04S130_N')
                       FROM MSTITEM
                       WHERE MSTITEM.ITEMID = $ITEMID);

  SET _$WARECD = '04S111_N'; -- 자재투입창고

  -- 1. 투입로트별 사용량 확인 (쓰기 전에 전부 확인)
  SET _$LOTKEY_LIST = $LOTKEY_LIST;
  SET _$USEQTY_LIST = $USEQTY_LIST;
  SET _$PRODQTY = 0;

  WHILE LENGTH(_$LOTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT(_$USEQTY_LIST, _$USEQTY_TXT);
    SET _$USEQTY = CAST(IF(IFNULL(_$USEQTY_TXT, '') = '', '0', _$USEQTY_TXT) AS DECIMAL(20, 8));

    IF _$USEQTY > 0 THEN
      IF NOT EXISTS (SELECT COMLOT.LOTKEY FROM COMLOT WHERE COMLOT.WARECD = _$WARECD AND COMLOT.LOTKEY = _$LOTKEY) THEN
        CALL COMERR(CONCAT('해당 창고에 존재하지 않는 로트번호입니다.'
                          , '\n- 창고: ', (SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = _$WARECD)
                          , '\n- 로트번호: ', _$LOTKEY
                          )
                   );
        LEAVE PROC;
      END IF;

      SET _$LOTQTY = (SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.WARECD = _$WARECD AND COMLOT.LOTKEY = _$LOTKEY);

      IF _$LOTQTY = 0 THEN
        CALL COMERR(CONCAT('재고수량이 0 입니다.'
                          , '\n- 로트번호: ', _$LOTKEY
                          )
                   );
        LEAVE PROC;
      END IF;

      IF _$LOTQTY < _$USEQTY THEN
        CALL COMERR(CONCAT('재고수량이 사용량보다 부족합니다.'
                          , '\n- 로트번호: ', _$LOTKEY
                          , '\n- 재고수량: ', FORMAT(_$LOTQTY, 0)
                          , '\n- 사용량: ', FORMAT(_$USEQTY, 0)
                          )
                   );
        LEAVE PROC;
      END IF;

      SET _$PRODQTY = _$PRODQTY + _$USEQTY;
    END IF;
  END WHILE;

  IF _$PRODQTY = 0 THEN
    CALL COMERR('투입로트의 사용량을 입력하세요.');
    LEAVE PROC;
  END IF;

  -- 불량수량 = 라인 불량 합계, 양품수량 = 생산수량 - 불량수량
  SET _$BADQTY = (SELECT IFNULL(SUM(PRDLINEBAD.BADQTY), 0)
                    FROM PRDLINEBAD
                    WHERE PRDLINEBAD.LINECD = $LINECD
                      AND PRDLINEBAD.PRCCD = $PRCCD
                      AND PRDLINEBAD.EQMCD = $EQMCD);

  IF _$BADQTY >= _$PRODQTY THEN
    CALL COMERR(CONCAT('불량수량이 사용량 합계보다 많거나 같습니다.'
                      , '\n- 사용량 합계: ', FORMAT(_$PRODQTY, 0)
                      , '\n- 불량수량: ', FORMAT(_$BADQTY, 0)
                      )
               );
    LEAVE PROC;
  END IF;

  SET _$GOODQTY = _$PRODQTY - _$BADQTY;

  -- 지시수량 = 작업시작일 주간생산계획 중 주야구분에 맞는 수량 (없으면 0)
  SET _$INSQTY = (SELECT IF($DNTP = 'PP161102N', MAX(PRDPLAN_W.PLANQTY_NIGHT), MAX(PRDPLAN_W.PLANQTY_DAY))
                    FROM PRDPLAN_W
                    WHERE PRDPLAN_W.PDATE = $WORKSDAY
                      AND PRDPLAN_W.ITEMID = $ITEMID
                      AND PRDPLAN_W.EQMCD = $EQMCD);

  -- 시간은 yyyy-MM-dd HH:mm:ss (화면 시간에 초가 없으면 :00)
  SET _$STIME = CONCAT($WORKSDAY, ' ', LEFT(CONCAT($WORKSTIME, ':00'), 8));
  SET _$ETIME = CONCAT($WORKEDAY, ' ', LEFT(CONCAT($WORKETIME, ':00'), 8));

  -- 작업시간(시작~종료) 안에 시작한 라인 비가동 중 끝나지 않은 것이 있으면 막음
  IF EXISTS (SELECT PRDRSTNON.PRDNONKEY
               FROM PRDRSTNON
               WHERE PRDRSTNON.EQMCD = $EQMCD
                 AND PRDRSTNON.NONSTIME BETWEEN _$STIME AND _$ETIME
                 AND PRDRSTNON.NONETIME = ''
                 AND PRDRSTNON.PRDWORKKEY = '') THEN
    CALL COMERR('진행 중인 비가동이 있습니다. 비가동을 종료한 후 작업완료하세요.');
    LEAVE PROC;
  END IF;

  -- 실적로트번호 (작업일 기준, 주간 D / 야간 N) - 실패하면 아무것도 쓰기 전에 끝냄
  SET _$RSTLOTKEY = GETLOTKEY_PRD($WORKSDAY, $PRCCD, IF($DNTP = 'PP161102N', 'N', 'D'));

  IF IFNULL(_$RSTLOTKEY, '') = '' THEN
    CALL COMERR(CONCAT('실적로트번호를 만들지 못했습니다.', '\n', IFNULL(@ERRMSG, '')));
    LEAVE PROC;
  END IF;

  -- 2. 작업지시
  SET _$PRDINSKEY = GETKEY('PRDINSKEY');

  INSERT INTO PRDINS (
      PRDINSKEY
    , INSDATE
    , INSSTIME
    , INSETIME
    , WORKSTT
    , INSTP
    , ITEMID
    , LINECD
    , PRCCD
    , EQMCD
    , INSQTY
    , DNTP
    , RTIME, REMP, RPRG)
  VALUES (
      _$PRDINSKEY
    , $WORKSDAY
    , _$STIME
    , _$ETIME
    , 'END'
    , '01'
    , $ITEMID
    , $LINECD
    , $PRCCD
    , $EQMCD
    , IFNULL(_$INSQTY, 0)
    , IF($DNTP = 'PP161102N', 'NIGHT', 'DAY')  -- 주야구분: 야간이면 NIGHT, 주간이면 DAY
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

  -- 3. 작업이력 (작업자는 사원코드 순 첫 번째)
  SET _$PRDWORKKEY = GETKEY('PRDWORKKEY');

  INSERT INTO PRDWORK (
      PRDWORKKEY
    , PRDINSKEY
    , WORKDATE
    , WORKSTIME
    , WORKETIME
    , WORKSTT
    , ITEMID
    , LINECD
    , PRCCD
    , EQMCD
    , EMPCD
    , RTIME, REMP, RPRG)
  VALUES (
      _$PRDWORKKEY
    , _$PRDINSKEY
    , $WORKSDAY
    , _$STIME
    , _$ETIME
    , 'END'
    , $ITEMID
    , $LINECD
    , $PRCCD
    , $EQMCD
    , (SELECT MIN(PRDLINEEMP.EMPCD)
         FROM PRDLINEEMP
         WHERE PRDLINEEMP.LINECD = $LINECD
           AND PRDLINEEMP.PRCCD = $PRCCD
           AND PRDLINEEMP.EQMCD = $EQMCD)
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

  INSERT INTO PRDWORK_EMP (
      PRDWORKKEY
    , EMPCD
    , RTIME, REMP, RPRG)
  SELECT
      _$PRDWORKKEY
    , PRDLINEEMP.EMPCD
    , CALLTIME(), CALLEMP(), CALLPRG()
  FROM PRDLINEEMP
  WHERE PRDLINEEMP.LINECD = $LINECD
    AND PRDLINEEMP.PRCCD = $PRCCD
    AND PRDLINEEMP.EQMCD = $EQMCD
  ORDER BY PRDLINEEMP.EMPCD;

  -- 작업시간(시작~종료) 안에 시작한 라인 비가동에 작업키 연결 (아직 작업키가 없는 것)
  UPDATE PRDRSTNON
  SET PRDWORKKEY = _$PRDWORKKEY
    , MTIME = CALLTIME()
    , MEMP = CALLEMP()
    , MPRG = CALLPRG()
  WHERE PRDRSTNON.EQMCD = $EQMCD
    AND PRDRSTNON.NONSTIME BETWEEN _$STIME AND _$ETIME
    AND PRDRSTNON.PRDWORKKEY = '';

  -- 4. 생산실적
  SET _$PRDRSTKEY = GETKEY('PRDRSTKEY');

  INSERT INTO PRDRST (
      PRDRSTKEY
    , PRDWORKKEY
    , RSTTIME
    , ITEMID
    , WARECD
    , EMPCD
    , LINECD
    , PRCCD
    , EQMCD
    , PRODQTY
    , GOODQTY
    , BADQTY
    , RTIME, REMP, RPRG)
  SELECT
      _$PRDRSTKEY
    , _$PRDWORKKEY
    , CALLTIME()
    , $ITEMID
    , _$INWARECD
    , PRDWORK.EMPCD
    , $LINECD
    , $PRCCD
    , $EQMCD
    , _$PRODQTY
    , _$GOODQTY
    , _$BADQTY
    , CALLTIME(), CALLEMP(), CALLPRG()
  FROM PRDWORK
  WHERE PRDWORK.PRDWORKKEY = _$PRDWORKKEY;

  -- 실적 불량 (라인 불량 그대로)
  INSERT INTO PRDRSTBAD (
      PRDRSTKEY
    , BADCD
    , BADDETAIL
    , BADQTY
    , REMARK
    , RTIME, REMP, RPRG)
  SELECT
      _$PRDRSTKEY
    , PRDLINEBAD.BADCD
    , PRDLINEBAD.BADDETAIL
    , PRDLINEBAD.BADQTY
    , PRDLINEBAD.REMARK
    , CALLTIME(), CALLEMP(), CALLPRG()
  FROM PRDLINEBAD
  WHERE PRDLINEBAD.LINECD = $LINECD
    AND PRDLINEBAD.PRCCD = $PRCCD
    AND PRDLINEBAD.EQMCD = $EQMCD;

  -- 5. 투입로트별 사용 이력 + 자재사용 출고 + 현재고 차감
  SET _$LOTKEY_LIST = $LOTKEY_LIST;
  SET _$USEQTY_LIST = $USEQTY_LIST;

  WHILE LENGTH(_$LOTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT(_$USEQTY_LIST, _$USEQTY_TXT);
    SET _$USEQTY = CAST(IF(IFNULL(_$USEQTY_TXT, '') = '', '0', _$USEQTY_TXT) AS DECIMAL(20, 8));

    IF _$USEQTY > 0 THEN
      SET _$LOTQTY = (SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.WARECD = _$WARECD AND COMLOT.LOTKEY = _$LOTKEY);

      INSERT INTO PRDRSTUSE (
          PRDRSTKEY
        , USELOTKEY
        , USEWARECD
        , USEITEMID
        , USEPRCCD
        , USEQTY
        , RTIME, REMP, RPRG)
      SELECT
          _$PRDRSTKEY
        , COMLOT.LOTKEY
        , COMLOT.WARECD
        , COMLOT.ITEMID
        , COMLOT.PRCCD
        , _$USEQTY
        , CALLTIME(), CALLEMP(), CALLPRG()
      FROM COMLOT
      WHERE COMLOT.WARECD = _$WARECD
        AND COMLOT.LOTKEY = _$LOTKEY;

      -- 출고는 품목별로 한 건 (같은 품목 로트는 같은 출고키에 수량을 더함)
      SET _$USEITEMID = (SELECT COMLOT.ITEMID FROM COMLOT WHERE COMLOT.WARECD = _$WARECD AND COMLOT.LOTKEY = _$LOTKEY);
      SET _$OUTKEY = (SELECT COMOUT.OUTKEY
                        FROM COMOUT
                        WHERE COMOUT.PRDRSTKEY = _$PRDRSTKEY
                          AND COMOUT.WARECD = _$WARECD
                          AND COMOUT.ITEMID = _$USEITEMID
                        LIMIT 1);

      IF _$OUTKEY IS NULL THEN
        SET _$OUTKEY = GETKEY('OUTKEY');

        INSERT INTO COMOUT (
            OUTKEY
          , WARECD
          , OUTTP
          , OUTDATE
          , OUTQTY
          , ITEMID
          , PRCCD
          , EMPCD
          , PRDRSTKEY
          , RTIME, REMP, RPRG)
        SELECT
            _$OUTKEY
          , COMLOT.WARECD
          , '04'
          , $WORKSDAY
          , _$USEQTY
          , COMLOT.ITEMID
          , COMLOT.PRCCD
          , CALLEMP()
          , _$PRDRSTKEY
          , CALLTIME(), CALLEMP(), CALLPRG()
        FROM COMLOT
        WHERE COMLOT.WARECD = _$WARECD
          AND COMLOT.LOTKEY = _$LOTKEY;
      ELSE
        UPDATE COMOUT
        SET OUTQTY = OUTQTY + _$USEQTY
          , MTIME = CALLTIME()
          , MEMP = CALLEMP()
          , MPRG = CALLPRG()
        WHERE COMOUT.OUTKEY = _$OUTKEY;
      END IF;

      INSERT INTO COMOUTLOT (
          OUTKEY
        , LOTKEY
        , WARECD
        , OUTTP
        , OUTDATE
        , OUTQTY
        , PRCCD
        , ITEMID
        , OLDQTY
        , RTIME, REMP, RPRG)
      SELECT
          _$OUTKEY
        , COMLOT.LOTKEY
        , COMLOT.WARECD
        , '04'
        , $WORKSDAY
        , _$USEQTY
        , COMLOT.PRCCD
        , COMLOT.ITEMID
        , _$LOTQTY
        , CALLTIME(), CALLEMP(), CALLPRG()
      FROM COMLOT
      WHERE COMLOT.WARECD = _$WARECD
        AND COMLOT.LOTKEY = _$LOTKEY;

      UPDATE COMLOT
      SET LOTQTY = LOTQTY - _$USEQTY
        , MTIME = CALLTIME()
        , MEMP = CALLEMP()
        , MPRG = CALLPRG()
      WHERE COMLOT.WARECD = _$WARECD
        AND COMLOT.LOTKEY = _$LOTKEY;
    END IF;
  END WHILE;

  -- 6. 실적로트 (양품수량, 불량수량)
  INSERT INTO PRDRSTLOT (
      PRDRSTKEY
    , LOTKEY
    , LOTTIME
    , LOTQTY
    , BADQTY
    , RTIME, REMP, RPRG)
  VALUES (
      _$PRDRSTKEY
    , _$RSTLOTKEY
    , CALLTIME()
    , _$GOODQTY
    , _$BADQTY
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

  -- 7. 실적로트 입고 + 현재고 생성
  SET _$INKEY = GETKEY('INKEY');

  INSERT INTO COMIN (
      INKEY
    , WARECD
    , INTP
    , INDATE
    , INQTY
    , ITEMID
    , PRCCD
    , EMPCD
    , PRDRSTKEY
    , RTIME, REMP, RPRG)
  VALUES (
      _$INKEY
    , _$INWARECD
    , '04'
    , $WORKSDAY
    , _$GOODQTY
    , $ITEMID
    , $PRCCD
    , CALLEMP()
    , _$PRDRSTKEY
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

  INSERT INTO COMINLOT (
      INKEY
    , LOTKEY
    , WARECD
    , INTP
    , INDATE
    , INQTY
    , PRCCD
    , ITEMID
    , OLDQTY
    , RTIME, REMP, RPRG)
  VALUES (
      _$INKEY
    , _$RSTLOTKEY
    , _$INWARECD
    , '04'
    , $WORKSDAY
    , _$GOODQTY
    , $PRCCD
    , $ITEMID
    , 0
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

  INSERT INTO COMLOT (
      LOTKEY
    , WARECD
    , LABELCD
    , LOTQTY
    , ITEMID
    , PRCCD
    , EQMCD
    , CRTTIME
    , CRTQTY
    , PRDDATE
    , PRDRSTKEY
    , RTIME, REMP, RPRG)
  VALUES (
      _$RSTLOTKEY
    , _$INWARECD
    , 'PRD01'
    , _$GOODQTY
    , $ITEMID
    , $PRCCD
    , $EQMCD
    , CALLTIME()
    , _$GOODQTY
    , $WORKSDAY
    , _$PRDRSTKEY
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

  -- 7-1. 불량로트 입고 + 현재고 생성 (불량이 있을 때, 로트번호는 양품로트와 같음, 입고유형 05 생산불량등록)
  IF _$BADQTY > 0 THEN
    SET _$INKEY = GETKEY('INKEY');

    INSERT INTO COMIN (
        INKEY
      , WARECD
      , INTP
      , INDATE
      , INQTY
      , ITEMID
      , PRCCD
      , EMPCD
      , PRDRSTKEY
      , RTIME, REMP, RPRG)
    VALUES (
        _$INKEY
      , _$BADWARECD
      , '05'
      , $WORKSDAY
      , _$BADQTY
      , $ITEMID
      , $PRCCD
      , CALLEMP()
      , _$PRDRSTKEY
      , CALLTIME(), CALLEMP(), CALLPRG()
    );

    INSERT INTO COMINLOT (
        INKEY
      , LOTKEY
      , WARECD
      , INTP
      , INDATE
      , INQTY
      , PRCCD
      , ITEMID
      , OLDQTY
      , RTIME, REMP, RPRG)
    VALUES (
        _$INKEY
      , _$RSTLOTKEY
      , _$BADWARECD
      , '05'
      , $WORKSDAY
      , _$BADQTY
      , $PRCCD
      , $ITEMID
      , 0
      , CALLTIME(), CALLEMP(), CALLPRG()
    );

    INSERT INTO COMLOT (
        LOTKEY
      , WARECD
      , LABELCD
      , LOTQTY
      , ITEMID
      , PRCCD
      , EQMCD
      , CRTTIME
      , CRTQTY
      , PRDDATE
      , PRDRSTKEY
      , RTIME, REMP, RPRG)
    VALUES (
        _$RSTLOTKEY
      , _$BADWARECD
      , 'PRD01'
      , _$BADQTY
      , $ITEMID
      , $PRCCD
      , $EQMCD
      , CALLTIME()
      , _$BADQTY
      , $WORKSDAY
      , _$PRDRSTKEY
      , CALLTIME(), CALLEMP(), CALLPRG()
    );
  END IF;

  -- ERP 인터페이스 (작업지시 → 생산실적·실적LOT·소요자재·작업자·불량)
  CALL IO_ERP_INTERFACE('PRDINS', _$PRDINSKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  CALL IO_ERP_INTERFACE('PRDRST', _$PRDRSTKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- 8. 라인 정보 정리 (투입로트, 생산품, 작업자, 불량)
  DELETE
    FROM PRDLINESCAN
    WHERE PRDLINESCAN.LINECD = $LINECD
      AND PRDLINESCAN.PRCCD = $PRCCD
      AND PRDLINESCAN.EQMCD = $EQMCD;

  DELETE
    FROM PRDLINEITEM
    WHERE PRDLINEITEM.LINECD = $LINECD
      AND PRDLINEITEM.PRCCD = $PRCCD
      AND PRDLINEITEM.EQMCD = $EQMCD;

  DELETE
    FROM PRDLINEEMP
    WHERE PRDLINEEMP.LINECD = $LINECD
      AND PRDLINEEMP.PRCCD = $PRCCD
      AND PRDLINEEMP.EQMCD = $EQMCD;

  DELETE
    FROM PRDLINEBAD
    WHERE PRDLINEBAD.LINECD = $LINECD
      AND PRDLINEBAD.PRCCD = $PRCCD
      AND PRDLINEBAD.EQMCD = $EQMCD;

  -- 결과: 실적로트번호
  SELECT _$RSTLOTKEY AS LOTKEY, _$GOODQTY AS GOODQTY;
-- *****************************************************************************
END