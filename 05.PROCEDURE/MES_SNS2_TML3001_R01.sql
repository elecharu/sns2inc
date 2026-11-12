CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML3001_R01(
-- *****************************************************************************
-- Comment: 불량 양품전환 (SNS 2공장) - 부적합 판정이 재작업(REWORK)인 불량재고를 사내 재작업 후 양품창고로 재고이동
--          출고창고 = 불량창고 (재공불량 04S130_N, 제품불량 04S230_N, DC_COMBO WARECD_REWORK_OUT)
--          입고창고 = 양품창고 (재공품 04S131_N, 제품 04S200_N, DC_COMBO WARECD_REWORK_IN), 짝은 확인하지 않음 (자유 선택)
--          ) SCAN_LOT : 후처리 안 된(PROCYN = 'N') 재작업 판정이 있는 로트만 그리드에 올린다
--                       이동량 = 그 로트·출고창고의 후처리 안 된 재작업 판정수량 합 (고칠 수 없음)
--          ) ADD_MOVE : IO_MOVELOT_WARE 로 재고이동 (출고구분 OUTTP 024, 입고구분 INTP 024) 후 그 재작업 판정을 후처리 완료(PROCYN = 'Y')
--          ) 재작업 이력은 따로 남기지 않는다. ERP 인터페이스는 보내지 않는다 (2026-11-11 사용자 지시)
--          ) LIST_MOVE : 양품전환 이력 조회 (재고이동 이력 COMIN/COMOUT 출입고구분 024, 불량창고 → 양품창고)
--          ) DEL_MOVE  : 양품전환 이력 LOT 행 단위 삭제 (재고 원복, 이동 이력 삭제, 재작업 판정 후처리 취소)
-- Create: 2026-11-11
-- Modify: 2026-11-12: 조회(LIST_MOVE)·삭제(DEL_MOVE) 추가, 등록 시 재작업 판정에 이동 GROUPKEY 기록 (TQMJUDGE.GROUPKEY)
-- *****************************************************************************
  IN $MOVEDATE      VARCHAR(10),    -- 이동일자
  IN $OUTWARE       VARCHAR(20),    -- 출고창고 (불량창고)
  IN $INWARE        VARCHAR(20),    -- 입고창고 (양품창고)
  IN $SCANLOT       VARCHAR(100),   -- 스캔 LOT
  IN $LOTKEY_LIST   MEDIUMTEXT,     -- 이동 LOT (삭제 시 삭제할 LOT)
  IN $SDATE         VARCHAR(10),    -- 조회 시작일 (이동일자)
  IN $EDATE         VARCHAR(10),    -- 조회 종료일 (이동일자)
  IN $GROUPKEY_LIST MEDIUMTEXT,     -- 삭제할 이동 GROUPKEY (LOTKEY_LIST 와 짝)
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$LOTKEY_LIST   MEDIUMTEXT;
  DECLARE _$MOVELOT_LIST  MEDIUMTEXT;   -- IO_MOVELOT_WARE 에 넘길 LOT 목록
  DECLARE _$MOVEQTY_LIST  MEDIUMTEXT;   -- IO_MOVELOT_WARE 에 넘길 이동량 목록 (재작업 판정수량 합)
  DECLARE _$LOTKEY        VARCHAR(100);
  DECLARE _$LOTQTY        DECIMAL(20, 8);
  DECLARE _$REWORKQTY     DECIMAL(20, 8);
  DECLARE _$GROUPKEY_LIST MEDIUMTEXT;
  DECLARE _$GROUPKEY      VARCHAR(100);
  DECLARE _$INKEY         VARCHAR(100);
  DECLARE _$OUTKEY        VARCHAR(100);
  DECLARE _$INWARE        VARCHAR(20);
  DECLARE _$OUTWARE       VARCHAR(20);
  DECLARE _$MOVEQTY       DECIMAL(20, 8);
  DECLARE _$CNT           INT DEFAULT 0;
-- *****************************************************************************

-- ****************************************************************************
CASE $CALLTYPE

-- ****************************************************************************
WHEN 'SCAN_LOT' THEN -- LOT 스캔 : 후처리 안 된 재작업 판정이 있는 불량재고만 그리드에 추가할 행

  IF IFNULL($OUTWARE, '') = '' THEN
    CALL COMERR('출고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($SCANLOT, '') = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF $OUTWARE NOT IN ('04S130_N', '04S230_N') THEN
    CALL COMERR('출고창고는 재공불량창고·제품불량창고만 선택할 수 있습니다.');
    LEAVE PROC;
  END IF;

  SET _$LOTQTY = (SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = $SCANLOT AND COMLOT.WARECD = $OUTWARE);

  IF _$LOTQTY IS NULL THEN
    CALL COMERR(CONCAT('출고창고에 없는 로트번호입니다.'
                      , '\n- 창고: ', IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = $OUTWARE), $OUTWARE)
                      , '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  IF _$LOTQTY <= 0 THEN
    CALL COMERR(CONCAT('재고수량이 0 입니다.', '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  SET _$REWORKQTY = IFNULL((SELECT SUM(TQMJUDGE.JUDGEQTY)
                              FROM TQMJUDGE
                              WHERE TQMJUDGE.LOTKEY = $SCANLOT
                                AND TQMJUDGE.WARECD = $OUTWARE
                                AND TQMJUDGE.JUDGETP = 'REWORK'
                                AND TQMJUDGE.PROCYN = 'N'), 0);

  IF _$REWORKQTY <= 0 THEN
    -- 재작업 판정이 아예 없는지, 있는데 모두 후처리됐는지 나눠 알린다
    IF NOT EXISTS (SELECT TQMJUDGE.JUDGEKEY
                     FROM TQMJUDGE
                     WHERE TQMJUDGE.LOTKEY = $SCANLOT
                       AND TQMJUDGE.WARECD = $OUTWARE
                       AND TQMJUDGE.JUDGETP = 'REWORK') THEN
      CALL COMERR(CONCAT('재작업 판정이 없는 재고입니다. 부적합 판정등록에서 재작업으로 판정하세요.', '\n- 로트번호: ', $SCANLOT));
    ELSE
      CALL COMERR(CONCAT('이미 후처리(양품전환)된 재고입니다.', '\n- 로트번호: ', $SCANLOT));
    END IF;
    LEAVE PROC;
  END IF;

  IF _$REWORKQTY > _$LOTQTY THEN
    CALL COMERR(CONCAT('재작업 판정수량이 재고수량보다 많습니다. 부적합 판정을 확인하세요.'
                      , '\n- 로트번호: ', $SCANLOT
                      , '\n- 재고수량: ', FORMAT(_$LOTQTY, 0)
                      , '\n- 재작업 판정수량: ', FORMAT(_$REWORKQTY, 0)));
    LEAVE PROC;
  END IF;

  SELECT
      COMLOT.LOTKEY
    , CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL(COMLOT.HEATNO, '') AS HEATNO
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , _$REWORKQTY AS MOVEQTY     -- 이동량 = 후처리 안 된 재작업 판정수량 합
    , COMLOT.LOTQTY              -- 현재고
    , '' AS REMARK
  FROM COMLOT
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = COMLOT.ITEMID
  WHERE COMLOT.LOTKEY = $SCANLOT
    AND COMLOT.WARECD = $OUTWARE;

-- ****************************************************************************
WHEN 'ADD_MOVE' THEN -- 등록 : 불량창고 → 양품창고, 재작업 판정 후처리 완료

  IF IFNULL($OUTWARE, '') = '' THEN
    CALL COMERR('출고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($INWARE, '') = '' THEN
    CALL COMERR('입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $OUTWARE NOT IN ('04S130_N', '04S230_N') THEN
    CALL COMERR('출고창고는 재공불량창고·제품불량창고만 선택할 수 있습니다.');
    LEAVE PROC;
  END IF;

  IF $INWARE NOT IN ('04S131_N', '04S200_N') THEN
    CALL COMERR('입고창고는 재공품창고·제품창고만 선택할 수 있습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($LOTKEY_LIST, '') = '' THEN
    CALL COMERR('이동할 LOT 바코드를 스캔하세요.');
    LEAVE PROC;
  END IF;

  -- 1. LOT 마다 이동량(후처리 안 된 재작업 판정수량 합)을 다시 구하고 확인 (쓰기 전에 전부 확인)
  SET _$LOTKEY_LIST = $LOTKEY_LIST;
  SET _$MOVELOT_LIST = '';
  SET _$MOVEQTY_LIST = '';

  WHILE LENGTH(_$LOTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);

    IF IFNULL(_$LOTKEY, '') <> '' THEN
      SET _$LOTQTY = IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = $OUTWARE), 0);
      SET _$REWORKQTY = IFNULL((SELECT SUM(TQMJUDGE.JUDGEQTY)
                                  FROM TQMJUDGE
                                  WHERE TQMJUDGE.LOTKEY = _$LOTKEY
                                    AND TQMJUDGE.WARECD = $OUTWARE
                                    AND TQMJUDGE.JUDGETP = 'REWORK'
                                    AND TQMJUDGE.PROCYN = 'N'), 0);

      IF _$REWORKQTY <= 0 THEN
        IF NOT EXISTS (SELECT TQMJUDGE.JUDGEKEY
                         FROM TQMJUDGE
                         WHERE TQMJUDGE.LOTKEY = _$LOTKEY
                           AND TQMJUDGE.WARECD = $OUTWARE
                           AND TQMJUDGE.JUDGETP = 'REWORK') THEN
          CALL COMERR(CONCAT('재작업 판정이 없는 재고입니다. 다시 스캔하세요.', '\n- 로트번호: ', _$LOTKEY));
        ELSE
          CALL COMERR(CONCAT('이미 후처리(양품전환)된 재고입니다. 다시 스캔하세요.', '\n- 로트번호: ', _$LOTKEY));
        END IF;
        LEAVE PROC;
      END IF;

      IF _$REWORKQTY > _$LOTQTY THEN
        CALL COMERR(CONCAT('재작업 판정수량이 재고수량보다 많습니다.'
                          , '\n- 로트번호: ', _$LOTKEY
                          , '\n- 재고수량: ', FORMAT(_$LOTQTY, 0)
                          , '\n- 재작업 판정수량: ', FORMAT(_$REWORKQTY, 0)));
        LEAVE PROC;
      END IF;

      -- COMSPLIT 목록 형식 (값 + '»')
      SET _$MOVELOT_LIST = CONCAT(_$MOVELOT_LIST, _$LOTKEY, '»');
      SET _$MOVEQTY_LIST = CONCAT(_$MOVEQTY_LIST, _$REWORKQTY, '»');
    END IF;
  END WHILE;

  -- 2. 재고이동 (출고구분 OUTTP 024, 입고구분 INTP 024 : 2026-11-11 사용자 지정). GROUPKEY·LOTCNT 를 결과로 돌려준다
  CALL IO_MOVELOT_WARE($MOVEDATE, $OUTWARE, $INWARE, '024', '024', _$MOVELOT_LIST, _$MOVEQTY_LIST);

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- 3. 이동한 LOT 의 재작업 판정을 후처리 완료로 (삭제 시 되돌릴 수 있게 이동 GROUPKEY 를 같이 기록)
  SET _$LOTKEY_LIST = $LOTKEY_LIST;

  WHILE LENGTH(_$LOTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);

    UPDATE TQMJUDGE
       SET TQMJUDGE.PROCYN   = 'Y'
         , TQMJUDGE.GROUPKEY = @MOVEGROUPKEY
         , TQMJUDGE.MTIME  = CALLTIME()
         , TQMJUDGE.MEMP   = CALLEMP()
         , TQMJUDGE.MPRG   = CALLPRG()
     WHERE TQMJUDGE.LOTKEY = _$LOTKEY
       AND TQMJUDGE.WARECD = $OUTWARE
       AND TQMJUDGE.JUDGETP = 'REWORK'
       AND TQMJUDGE.PROCYN = 'N';
  END WHILE;

-- ****************************************************************************
WHEN 'LIST_MOVE' THEN -- 조회 : 양품전환 이력 (LOT 행 단위)

  IF IFNULL($SDATE, '') = '' OR IFNULL($EDATE, '') = '' THEN
    CALL COMERR('이동일자를 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT
      COMIN.INDATE AS MOVEDATE
    , COMINLOT.LOTKEY
    , CAST(COMIN.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , COMOUT.WARECD AS OUTWARE
    , IFNULL(W_OUT.WARENM, COMOUT.WARECD) AS OUTWARENM
    , COMIN.WARECD AS INWARE
    , IFNULL(W_IN.WARENM, COMIN.WARECD) AS INWARENM
    , COMINLOT.INQTY AS MOVEQTY
    , IFNULL(COMLOT.LOTQTY, 0) AS INLOTQTY     -- 입고창고 현재고 (이동량보다 적으면 삭제 불가)
    , IFNULL(MSTEMP.EMPNM, COMIN.REMP) AS EMPNM
    , COMIN.RTIME
    , COMIN.GROUPKEY
  FROM COMIN
  INNER JOIN COMINLOT
    ON COMINLOT.INKEY = COMIN.INKEY
  INNER JOIN COMOUT
    ON COMOUT.GROUPKEY = COMIN.GROUPKEY
   AND COMOUT.OUTTP = '024'
  INNER JOIN COMOUTLOT
    ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
   AND COMOUTLOT.LOTKEY = COMINLOT.LOTKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = COMIN.ITEMID
  LEFT JOIN MSTWARE AS W_OUT
    ON W_OUT.WARECD = COMOUT.WARECD
  LEFT JOIN MSTWARE AS W_IN
    ON W_IN.WARECD = COMIN.WARECD
  LEFT JOIN COMLOT
    ON COMLOT.LOTKEY = COMINLOT.LOTKEY
   AND COMLOT.WARECD = COMIN.WARECD
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = COMIN.REMP
  WHERE COMIN.INTP = '024'
    AND COMIN.GROUPKEY <> ''
    AND COMIN.INDATE BETWEEN $SDATE AND $EDATE
    AND COMIN.WARECD IN ('04S131_N', '04S200_N')    -- 양품창고
    AND COMOUT.WARECD IN ('04S130_N', '04S230_N')   -- 불량창고
  ORDER BY COMIN.INDATE DESC, COMIN.RTIME DESC, COMINLOT.LOTKEY;

-- ****************************************************************************
WHEN 'DEL_MOVE' THEN -- 삭제 : 양품전환 이력 LOT 행 단위 (입고창고 → 출고창고 재고 원복, 이동 이력 삭제, 재작업 판정 후처리 취소)

  IF IFNULL($GROUPKEY_LIST, '') = '' OR IFNULL($LOTKEY_LIST, '') = '' THEN
    CALL COMERR('삭제할 이력을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 전부 확인한 뒤에 쓴다
  SET _$GROUPKEY_LIST = $GROUPKEY_LIST;
  SET _$LOTKEY_LIST = $LOTKEY_LIST;

  WHILE LENGTH(_$GROUPKEY_LIST) > 0 DO
    CALL COMSPLIT(_$GROUPKEY_LIST, _$GROUPKEY);
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);

    SET _$INKEY = NULL;
    SET _$OUTKEY = NULL;

    SELECT COMIN.INKEY, COMIN.WARECD, COMINLOT.INQTY
      INTO _$INKEY, _$INWARE, _$MOVEQTY
      FROM COMIN
      INNER JOIN COMINLOT ON COMINLOT.INKEY = COMIN.INKEY
      WHERE COMIN.GROUPKEY = _$GROUPKEY
        AND COMIN.INTP = '024'
        AND COMINLOT.LOTKEY = _$LOTKEY
      LIMIT 1;

    SELECT COMOUT.OUTKEY, COMOUT.WARECD
      INTO _$OUTKEY, _$OUTWARE
      FROM COMOUT
      INNER JOIN COMOUTLOT ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
      WHERE COMOUT.GROUPKEY = _$GROUPKEY
        AND COMOUT.OUTTP = '024'
        AND COMOUTLOT.LOTKEY = _$LOTKEY
      LIMIT 1;

    IF _$INKEY IS NULL OR _$OUTKEY IS NULL THEN
      CALL COMERR(CONCAT('양품전환 이력이 없습니다. 다시 조회하세요.', '\n- 로트번호: ', _$LOTKEY));
      LEAVE PROC;
    END IF;

    SET _$LOTQTY = IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = _$INWARE), 0);

    IF _$LOTQTY < _$MOVEQTY THEN
      CALL COMERR(CONCAT('입고창고 재고가 이동량보다 적어 삭제할 수 없습니다. (이미 사용된 재고)'
                        , '\n- 로트번호: ', _$LOTKEY
                        , '\n- 창고: ', IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = _$INWARE), _$INWARE)
                        , '\n- 재고량: ', FORMAT(_$LOTQTY, 0)
                        , '\n- 이동량: ', FORMAT(_$MOVEQTY, 0)));
      LEAVE PROC;
    END IF;

    IF NOT EXISTS (SELECT 1 FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = _$OUTWARE) THEN
      CALL COMERR(CONCAT('출고창고(불량창고)에 로트가 없어 되돌릴 수 없습니다.'
                        , '\n- 로트번호: ', _$LOTKEY
                        , '\n- 창고: ', IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = _$OUTWARE), _$OUTWARE)));
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 삭제
  SET _$GROUPKEY_LIST = $GROUPKEY_LIST;
  SET _$LOTKEY_LIST = $LOTKEY_LIST;

  WHILE LENGTH(_$GROUPKEY_LIST) > 0 DO
    CALL COMSPLIT(_$GROUPKEY_LIST, _$GROUPKEY);
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);

    SELECT COMIN.INKEY, COMIN.WARECD, COMINLOT.INQTY
      INTO _$INKEY, _$INWARE, _$MOVEQTY
      FROM COMIN
      INNER JOIN COMINLOT ON COMINLOT.INKEY = COMIN.INKEY
      WHERE COMIN.GROUPKEY = _$GROUPKEY
        AND COMIN.INTP = '024'
        AND COMINLOT.LOTKEY = _$LOTKEY
      LIMIT 1;

    SELECT COMOUT.OUTKEY, COMOUT.WARECD
      INTO _$OUTKEY, _$OUTWARE
      FROM COMOUT
      INNER JOIN COMOUTLOT ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
      WHERE COMOUT.GROUPKEY = _$GROUPKEY
        AND COMOUT.OUTTP = '024'
        AND COMOUTLOT.LOTKEY = _$LOTKEY
      LIMIT 1;

    -- 2-1. 입고창고(양품창고) LOT 차감, 이 이동으로 생긴 LOT 행이면 삭제 (IO_MOVELOT_WARE 가 CRTQTY 도 늘렸으므로 같이 뺌)
    UPDATE COMLOT
       SET COMLOT.LOTQTY = COMLOT.LOTQTY - _$MOVEQTY
         , COMLOT.CRTQTY = COMLOT.CRTQTY - _$MOVEQTY
         , COMLOT.MTIME  = CALLTIME()
         , COMLOT.MEMP   = CALLEMP()
         , COMLOT.MPRG   = CALLPRG()
     WHERE COMLOT.LOTKEY = _$LOTKEY
       AND COMLOT.WARECD = _$INWARE;

    DELETE FROM COMLOT
     WHERE COMLOT.LOTKEY = _$LOTKEY
       AND COMLOT.WARECD = _$INWARE
       AND COMLOT.LOTQTY <= 0
       AND COMLOT.CRTQTY <= 0;

    -- 2-2. 출고창고(불량창고) LOT 원복
    UPDATE COMLOT
       SET COMLOT.LOTQTY = COMLOT.LOTQTY + _$MOVEQTY
         , COMLOT.MTIME  = CALLTIME()
         , COMLOT.MEMP   = CALLEMP()
         , COMLOT.MPRG   = CALLPRG()
     WHERE COMLOT.LOTKEY = _$LOTKEY
       AND COMLOT.WARECD = _$OUTWARE;

    -- 2-3. 이동 이력 삭제 (IO_MOVELOT_WARE 는 LOT 마다 INKEY·OUTKEY 를 하나씩 만든다)
    DELETE FROM COMINLOT WHERE COMINLOT.INKEY = _$INKEY AND COMINLOT.LOTKEY = _$LOTKEY;
    DELETE FROM COMIN WHERE COMIN.INKEY = _$INKEY;
    DELETE FROM COMOUTLOT WHERE COMOUTLOT.OUTKEY = _$OUTKEY AND COMOUTLOT.LOTKEY = _$LOTKEY;
    DELETE FROM COMOUT WHERE COMOUT.OUTKEY = _$OUTKEY;

    -- 2-4. 이 이동으로 후처리한 재작업 판정을 후처리 전으로
    UPDATE TQMJUDGE
       SET TQMJUDGE.PROCYN   = 'N'
         , TQMJUDGE.GROUPKEY = ''
         , TQMJUDGE.MTIME    = CALLTIME()
         , TQMJUDGE.MEMP     = CALLEMP()
         , TQMJUDGE.MPRG     = CALLPRG()
     WHERE TQMJUDGE.GROUPKEY = _$GROUPKEY
       AND TQMJUDGE.LOTKEY = _$LOTKEY
       AND TQMJUDGE.WARECD = _$OUTWARE
       AND TQMJUDGE.JUDGETP = 'REWORK';

    SET _$CNT = _$CNT + 1;
  END WHILE;

  SELECT _$CNT AS DELCNT;

-- ****************************************************************************
END CASE; END
