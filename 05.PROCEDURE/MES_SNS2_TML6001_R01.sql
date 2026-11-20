CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML6001_R01(
-- *****************************************************************************
-- Comment: 제품 반입등록 (SNS 2공장 현장) - 고객사로 출하한 제품이 문제가 있어 2공장으로 되돌아온 것을 제품불량창고(04S230_N)에 반입
--          반입 = COMOUT·COMOUTLOT 에 출고구분 OUTTP 20(출하반품), OUTQTY 마이너스 + COMLOT(04S230_N) 재고 생성·증가
--          반입 거래처는 COMOUT.CUSTCD (06.Table MES_SNS2_COMOUT_ADD_CUSTCD.sql) 와 COMLOT.CUSTCD 에 저장
--          ) SCAN_LOT  : 공정이동표가 붙어 온 경우. 출하(SALOUT 확정, 01·011)된 로트만, 반입가능량 = 출하량 - 이미 반입한 양
--                        거래처는 그 로트를 출하한 거래처 (화면에서 고른 거래처와 다르면 오류)
--          ) ADD_ITEM  : 공정이동표 없이 온 경우. 고른 거래처에 출하한 적 있는 품목 + 반입수량으로 그리드에 추가할 행 (로트번호는 등록 때 채번)
--          ) ADD_RTN   : 등록. 로트번호가 없는 행은 GETLOTKEY_RTN 으로 새 로트 채번 (RT + yyMMdd + '-' + 순번3)
--                        결과 [0] GROUPKEY·LOTCNT·NEWCNT, [1] 새로 만든 로트 (화면이 공정이동표 출력)
--          ) LIST_RTN  : 반입 이력 조회 (반입일자 기간, 거래처)
--          ) DEL_RTN   : 반입 취소 (OUTKEY 행 단위). 제품불량창고 재고가 반입수량보다 적거나 반입 뒤 부적합 판정이 있으면 취소 불가
--          ) PRINT_MOVE: 공정이동표 (TMLPRINT.PRD_1, isBad = true 로 제목 "공 정 이 동 표 (출하반품)", 수량 = 반입수량)
--          ERP 인터페이스는 보내지 않는다.
-- Create: 2026-11-20
-- *****************************************************************************
  IN $RTNDATE       VARCHAR(10),    -- 반입일자
  IN $CUSTCD        VARCHAR(100),   -- 반입 거래처
  IN $SCANLOT       VARCHAR(100),   -- 스캔 LOT (공정이동표 바코드)
  IN $ITEMID        VARCHAR(20),    -- 품목 (공정이동표 없을 때)
  IN $RTNQTY        VARCHAR(30),    -- 반입수량 (공정이동표 없을 때)
  IN $LOTKEY_LIST   MEDIUMTEXT,     -- 등록: 행마다 LOT ('' 이면 새로 채번)
  IN $ITEMID_LIST   MEDIUMTEXT,     -- 등록: 행마다 품목
  IN $RTNQTY_LIST   MEDIUMTEXT,     -- 등록: 행마다 반입수량
  IN $REMARK_LIST   MEDIUMTEXT,     -- 등록: 행마다 비고
  IN $SDATE         VARCHAR(10),    -- 조회 시작일 (반입일자)
  IN $EDATE         VARCHAR(10),    -- 조회 종료일 (반입일자)
  IN $OUTKEY_LIST   MEDIUMTEXT,     -- 취소할 반입 OUTKEY / 공정이동표 출력할 OUTKEY (1건)
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$RTNWARE      VARCHAR(20) DEFAULT '04S230_N';   -- 제품불량창고
  DECLARE _$OUTTP        VARCHAR(10) DEFAULT '20';         -- 출하반품
  DECLARE _$LOTKEY_LIST  MEDIUMTEXT;
  DECLARE _$ITEMID_LIST  MEDIUMTEXT;
  DECLARE _$RTNQTY_LIST  MEDIUMTEXT;
  DECLARE _$REMARK_LIST  MEDIUMTEXT;
  DECLARE _$OUTKEY_LIST  MEDIUMTEXT;
  DECLARE _$LOTKEY       VARCHAR(100);
  DECLARE _$ITEMID       VARCHAR(20);
  DECLARE _$SHIPITEMID   VARCHAR(20);
  DECLARE _$RTNQTY_S     VARCHAR(100);
  DECLARE _$RTNQTY       DECIMAL(20, 8);
  DECLARE _$REMARK       VARCHAR(1000);
  DECLARE _$SHIPQTY      DECIMAL(20, 8);
  DECLARE _$RETQTY       DECIMAL(20, 8);
  DECLARE _$REMQTY       DECIMAL(20, 8);
  DECLARE _$LOTQTY       DECIMAL(20, 8);
  DECLARE _$SHIPCUSTCD   VARCHAR(100);
  DECLARE _$OUTKEY       VARCHAR(20);
  DECLARE _$GROUPKEY     VARCHAR(20);
  DECLARE _$OUTRTIME     VARCHAR(19);
  DECLARE _$NEWYN        VARCHAR(1);
  DECLARE _$CNT          INT DEFAULT 0;
  DECLARE _$NEWCNT       INT DEFAULT 0;
-- *****************************************************************************

-- ****************************************************************************
CASE $CALLTYPE

-- ****************************************************************************
WHEN 'SCAN_LOT' THEN -- 공정이동표 바코드 스캔 : 출하된 로트만 그리드에 추가할 행

  IF IFNULL($SCANLOT, '') = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 출하 확정(고객사 01, 유상사급 011)된 로트인지, 출하량·품목·최근 출하 거래처
  SELECT IFNULL(SUM(SALOUTLOT.LOTQTY), 0)
    INTO _$SHIPQTY
    FROM SALOUTLOT
    INNER JOIN SALOUT
      ON SALOUT.SALOUTKEY = SALOUTLOT.SALOUTKEY
    WHERE SALOUTLOT.LOTKEY = $SCANLOT
      AND SALOUT.OUTYN = 'Y'
      AND SALOUT.SALOUTTP IN ('01', '011');

  IF _$SHIPQTY <= 0 THEN
    CALL COMERR(CONCAT('출하 이력이 없는 로트입니다. 공정이동표가 없는 것으로 보고 품목·반입수량을 입력하세요.', '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  SELECT SALOUT.CUSTCD, SALOUT.ITEMID
    INTO _$SHIPCUSTCD, _$SHIPITEMID
    FROM SALOUTLOT
    INNER JOIN SALOUT
      ON SALOUT.SALOUTKEY = SALOUTLOT.SALOUTKEY
    WHERE SALOUTLOT.LOTKEY = $SCANLOT
      AND SALOUT.OUTYN = 'Y'
      AND SALOUT.SALOUTTP IN ('01', '011')
    ORDER BY SALOUT.SALOUTDATE DESC, SALOUT.RTIME DESC
    LIMIT 1;

  IF IFNULL($CUSTCD, '') <> '' AND $CUSTCD <> _$SHIPCUSTCD THEN
    CALL COMERR(CONCAT('선택한 거래처에 출하한 로트가 아닙니다.'
                      , '\n- 로트번호: ', $SCANLOT
                      , '\n- 출하 거래처: ', IFNULL((SELECT MSTCUST.CUSTNM FROM MSTCUST WHERE MSTCUST.CUSTCD = _$SHIPCUSTCD), _$SHIPCUSTCD)));
    LEAVE PROC;
  END IF;

  -- 이미 반입한 양 (출하반품 OUTQTY 는 마이너스)
  SET _$RETQTY = IFNULL((SELECT -SUM(COMOUTLOT.OUTQTY)
                           FROM COMOUTLOT
                           WHERE COMOUTLOT.LOTKEY = $SCANLOT
                             AND COMOUTLOT.OUTTP = _$OUTTP), 0);
  SET _$REMQTY = _$SHIPQTY - _$RETQTY;

  IF _$REMQTY <= 0 THEN
    CALL COMERR(CONCAT('이미 출하량만큼 모두 반입된 로트입니다.'
                      , '\n- 로트번호: ', $SCANLOT
                      , '\n- 출하량: ', FORMAT(_$SHIPQTY, 0)
                      , '\n- 반입량: ', FORMAT(_$RETQTY, 0)));
    LEAVE PROC;
  END IF;

  SELECT
      $SCANLOT AS LOTKEY
    , 'N' AS NEWYN
    , '공정이동표' AS RTNTPNM
    , CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , _$SHIPCUSTCD AS CUSTCD
    , IFNULL((SELECT MSTCUST.CUSTNM FROM MSTCUST WHERE MSTCUST.CUSTCD = _$SHIPCUSTCD), _$SHIPCUSTCD) AS CUSTNM
    , _$REMQTY AS SHIPQTY      -- 반입가능량 (출하량 - 이미 반입한 양)
    , _$REMQTY AS RTNQTY       -- 반입수량 기본값 (일부만 반입되면 화면에서 고침)
    , '' AS REMARK
  FROM MSTITEM
  WHERE MSTITEM.ITEMID = _$SHIPITEMID;

-- ****************************************************************************
WHEN 'ADD_ITEM' THEN -- 공정이동표 없음 : 거래처에 출하한 품목 + 반입수량으로 그리드에 추가할 행

  IF IFNULL($CUSTCD, '') = '' THEN
    CALL COMERR('거래처를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($ITEMID, '') = '' THEN
    CALL COMERR('품목을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($RTNQTY, '') = '' OR CAST($RTNQTY AS DECIMAL(20, 8)) <= 0 THEN
    CALL COMERR('반입수량을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1
                   FROM SALOUT
                   WHERE SALOUT.CUSTCD = $CUSTCD
                     AND SALOUT.ITEMID = $ITEMID
                     AND SALOUT.OUTYN = 'Y'
                     AND SALOUT.SALOUTTP IN ('01', '011')) THEN
    CALL COMERR('선택한 거래처에 출하한 적이 없는 품목입니다.');
    LEAVE PROC;
  END IF;

  SELECT
      '' AS LOTKEY
    , 'Y' AS NEWYN
    , '신규(무표)' AS RTNTPNM
    , CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , $CUSTCD AS CUSTCD
    , IFNULL((SELECT MSTCUST.CUSTNM FROM MSTCUST WHERE MSTCUST.CUSTCD = $CUSTCD), $CUSTCD) AS CUSTNM
    , 0 AS SHIPQTY
    , CAST($RTNQTY AS DECIMAL(20, 8)) AS RTNQTY
    , '' AS REMARK
  FROM MSTITEM
  WHERE MSTITEM.ITEMID = $ITEMID;

-- ****************************************************************************
WHEN 'ADD_RTN' THEN -- 등록 : 제품불량창고 반입 (COMOUT 출하반품 OUTTP 20, OUTQTY 마이너스)

  IF IFNULL($RTNDATE, '') = '' THEN
    CALL COMERR('반입일자를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($CUSTCD, '') = '' THEN
    CALL COMERR('거래처를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($ITEMID_LIST, '') = '' THEN
    CALL COMERR('반입할 제품을 스캔하거나 추가하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 전부 확인한 뒤에 쓴다
  SET _$LOTKEY_LIST = $LOTKEY_LIST;
  SET _$ITEMID_LIST = $ITEMID_LIST;
  SET _$RTNQTY_LIST = $RTNQTY_LIST;

  WHILE LENGTH(_$ITEMID_LIST) > 0 DO
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT(_$ITEMID_LIST, _$ITEMID);
    CALL COMSPLIT(_$RTNQTY_LIST, _$RTNQTY_S);

    SET _$RTNQTY = CAST(IFNULL(NULLIF(_$RTNQTY_S, ''), '0') AS DECIMAL(20, 8));

    IF _$RTNQTY <= 0 THEN
      CALL COMERR(CONCAT('반입수량을 확인하세요.', IF(IFNULL(_$LOTKEY, '') = '', '', CONCAT('\n- 로트번호: ', _$LOTKEY))));
      LEAVE PROC;
    END IF;

    IF IFNULL(_$LOTKEY, '') <> '' THEN
      -- 공정이동표 로트 : 출하 확인, 거래처·품목 일치, 반입가능량
      SET _$SHIPQTY = IFNULL((SELECT SUM(SALOUTLOT.LOTQTY)
                                FROM SALOUTLOT
                                INNER JOIN SALOUT ON SALOUT.SALOUTKEY = SALOUTLOT.SALOUTKEY
                                WHERE SALOUTLOT.LOTKEY = _$LOTKEY
                                  AND SALOUT.OUTYN = 'Y'
                                  AND SALOUT.SALOUTTP IN ('01', '011')), 0);

      IF _$SHIPQTY <= 0 THEN
        CALL COMERR(CONCAT('출하 이력이 없는 로트입니다.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      SET _$SHIPCUSTCD = NULL;
      SET _$SHIPITEMID = NULL;
      SELECT SALOUT.CUSTCD, SALOUT.ITEMID
        INTO _$SHIPCUSTCD, _$SHIPITEMID
        FROM SALOUTLOT
        INNER JOIN SALOUT ON SALOUT.SALOUTKEY = SALOUTLOT.SALOUTKEY
        WHERE SALOUTLOT.LOTKEY = _$LOTKEY
          AND SALOUT.OUTYN = 'Y'
          AND SALOUT.SALOUTTP IN ('01', '011')
        ORDER BY SALOUT.SALOUTDATE DESC, SALOUT.RTIME DESC
        LIMIT 1;

      IF _$SHIPCUSTCD <> $CUSTCD THEN
        CALL COMERR(CONCAT('선택한 거래처에 출하한 로트가 아닙니다.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      IF _$SHIPITEMID <> _$ITEMID THEN
        CALL COMERR(CONCAT('출하 품목과 다릅니다. 다시 스캔하세요.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      SET _$RETQTY = IFNULL((SELECT -SUM(COMOUTLOT.OUTQTY)
                               FROM COMOUTLOT
                               WHERE COMOUTLOT.LOTKEY = _$LOTKEY
                                 AND COMOUTLOT.OUTTP = _$OUTTP), 0);

      IF _$RTNQTY > _$SHIPQTY - _$RETQTY THEN
        CALL COMERR(CONCAT('반입수량이 반입가능량(출하량 - 이미 반입한 양)보다 많습니다.'
                          , '\n- 로트번호: ', _$LOTKEY
                          , '\n- 반입가능량: ', FORMAT(_$SHIPQTY - _$RETQTY, 0)
                          , '\n- 반입수량: ', FORMAT(_$RTNQTY, 0)));
        LEAVE PROC;
      END IF;
    ELSE
      -- 공정이동표 없음 : 거래처에 출하한 품목인지
      IF NOT EXISTS (SELECT 1
                       FROM SALOUT
                       WHERE SALOUT.CUSTCD = $CUSTCD
                         AND SALOUT.ITEMID = _$ITEMID
                         AND SALOUT.OUTYN = 'Y'
                         AND SALOUT.SALOUTTP IN ('01', '011')) THEN
        CALL COMERR(CONCAT('선택한 거래처에 출하한 적이 없는 품목입니다.'
                          , '\n- 품목: ', IFNULL((SELECT MSTITEM.ITEMCD FROM MSTITEM WHERE MSTITEM.ITEMID = _$ITEMID), _$ITEMID)));
        LEAVE PROC;
      END IF;
    END IF;
  END WHILE;

  -- 2. 반입 (행마다 COMOUT 1건 : 행 단위로 취소할 수 있게)
  SET _$GROUPKEY = GETKEY('GETGROUPKEY');

  DROP TEMPORARY TABLE IF EXISTS TEMP_RTN;
  CREATE TEMPORARY TABLE TEMP_RTN (
      SEQ    INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
      OUTKEY VARCHAR(20),
      LOTKEY VARCHAR(100),
      NEWYN  VARCHAR(1)
  );

  SET _$LOTKEY_LIST = $LOTKEY_LIST;
  SET _$ITEMID_LIST = $ITEMID_LIST;
  SET _$RTNQTY_LIST = $RTNQTY_LIST;
  SET _$REMARK_LIST = IFNULL($REMARK_LIST, '');

  WHILE LENGTH(_$ITEMID_LIST) > 0 DO
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT(_$ITEMID_LIST, _$ITEMID);
    CALL COMSPLIT(_$RTNQTY_LIST, _$RTNQTY_S);
    CALL COMSPLIT(_$REMARK_LIST, _$REMARK);

    SET _$RTNQTY = CAST(IFNULL(NULLIF(_$RTNQTY_S, ''), '0') AS DECIMAL(20, 8));
    SET _$REMARK = IFNULL(_$REMARK, '');

    -- 2-1. 공정이동표 없으면 새 로트 채번
    IF IFNULL(_$LOTKEY, '') = '' THEN
      SET _$LOTKEY = GETLOTKEY_RTN($RTNDATE);
      IF IFNULL(_$LOTKEY, '') = '' THEN
        CALL COMERR(IFNULL(NULLIF(@ERRMSG, ''), '반입 로트번호를 만들지 못했습니다.'));
        LEAVE PROC;
      END IF;
      SET _$NEWYN = 'Y';
      SET _$NEWCNT = _$NEWCNT + 1;
    ELSE
      SET _$NEWYN = 'N';
    END IF;

    SET _$LOTQTY = IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = _$RTNWARE), 0);
    SET _$OUTKEY = GETKEY('OUTKEY');

    -- 2-2. 출고이력 (출하반품 : OUTQTY 마이너스)
    INSERT INTO COMOUTLOT (OUTKEY, LOTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, ITEMID, OLDQTY, REMARK, RTIME, REMP, RPRG)
    VALUES (_$OUTKEY, _$LOTKEY, _$RTNWARE, _$OUTTP, $RTNDATE, -_$RTNQTY, _$ITEMID, _$LOTQTY, LEFT(_$REMARK, 100), CALLTIME(), CALLEMP(), CALLPRG());

    INSERT INTO COMOUT (OUTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, ITEMID, CUSTCD, EMPCD, GROUPKEY, REMARK, RTIME, REMP, RPRG)
    VALUES (_$OUTKEY, _$RTNWARE, _$OUTTP, $RTNDATE, -_$RTNQTY, _$ITEMID, $CUSTCD, CALLEMP(), _$GROUPKEY, _$REMARK, CALLTIME(), CALLEMP(), CALLPRG());

    -- 2-3. 제품불량창고 재고 (있으면 더하고, 없으면 만듦. 공정이동표 로트는 원래 로트의 정보를 이어받음)
    IF EXISTS (SELECT 1 FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = _$RTNWARE) THEN
      UPDATE COMLOT
         SET COMLOT.LOTQTY = COMLOT.LOTQTY + _$RTNQTY
           , COMLOT.CRTQTY = COMLOT.CRTQTY + _$RTNQTY
           , COMLOT.CUSTCD = $CUSTCD
           , COMLOT.MTIME  = CALLTIME()
           , COMLOT.MEMP   = CALLEMP()
           , COMLOT.MPRG   = CALLPRG()
       WHERE COMLOT.LOTKEY = _$LOTKEY
         AND COMLOT.WARECD = _$RTNWARE;
    ELSEIF _$NEWYN = 'N' AND EXISTS (SELECT 1 FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY) THEN
      INSERT INTO COMLOT (LOTKEY, WARECD, LABELCD, LOTQTY, HEATNO, ITEMID, PRCCD, CRTTIME, CRTQTY, PRDDATE, CUSTCD, CUSTLOTKEY, LOTTP, GROUPKEY
                        , REMARK, RTIME, REMP, RPRG)
      SELECT
          COMLOT.LOTKEY, _$RTNWARE, COMLOT.LABELCD, _$RTNQTY, COMLOT.HEATNO, _$ITEMID, COMLOT.PRCCD, CALLTIME(), _$RTNQTY, COMLOT.PRDDATE, $CUSTCD, COMLOT.CUSTLOTKEY, COMLOT.LOTTP, _$GROUPKEY
        , _$REMARK, CALLTIME(), CALLEMP(), CALLPRG()
      FROM COMLOT
      WHERE COMLOT.LOTKEY = _$LOTKEY
      ORDER BY COMLOT.RTIME DESC
      LIMIT 1;
    ELSE
      INSERT INTO COMLOT (LOTKEY, WARECD, LOTQTY, ITEMID, CRTTIME, CRTQTY, PRDDATE, CUSTCD, GROUPKEY
                        , REMARK, RTIME, REMP, RPRG)
      VALUES (_$LOTKEY, _$RTNWARE, _$RTNQTY, _$ITEMID, CALLTIME(), _$RTNQTY, $RTNDATE, $CUSTCD, _$GROUPKEY
            , _$REMARK, CALLTIME(), CALLEMP(), CALLPRG());
    END IF;

    INSERT INTO TEMP_RTN (OUTKEY, LOTKEY, NEWYN) VALUES (_$OUTKEY, _$LOTKEY, _$NEWYN);
    SET _$CNT = _$CNT + 1;
  END WHILE;

  SELECT _$GROUPKEY AS GROUPKEY, _$CNT AS LOTCNT, _$NEWCNT AS NEWCNT;

  -- 새로 만든 로트 (화면이 공정이동표를 출력)
  SELECT TEMP_RTN.OUTKEY, TEMP_RTN.LOTKEY
  FROM TEMP_RTN
  WHERE TEMP_RTN.NEWYN = 'Y'
  ORDER BY TEMP_RTN.SEQ;

  DROP TEMPORARY TABLE IF EXISTS TEMP_RTN;

-- ****************************************************************************
WHEN 'LIST_RTN' THEN -- 조회 : 반입 이력 (OUTKEY 행 단위)

  IF IFNULL($SDATE, '') = '' OR IFNULL($EDATE, '') = '' THEN
    CALL COMERR('반입일자를 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT
      COMOUT.OUTKEY
    , COMOUT.OUTDATE AS RTNDATE
    , COMOUT.CUSTCD
    , IFNULL(MSTCUST.CUSTNM, COMOUT.CUSTCD) AS CUSTNM
    , COMOUTLOT.LOTKEY
    , IF(EXISTS (SELECT 1 FROM SALOUTLOT WHERE SALOUTLOT.LOTKEY = COMOUTLOT.LOTKEY), '공정이동표', '신규(무표)') AS RTNTPNM
    , CAST(COMOUT.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , -COMOUT.OUTQTY AS RTNQTY
    , IFNULL(COMLOT.LOTQTY, 0) AS LOTQTY      -- 제품불량창고 현재고 (반입수량보다 적으면 취소 불가)
    , COMOUT.REMARK
    , IFNULL(MSTEMP.EMPNM, COMOUT.REMP) AS EMPNM
    , COMOUT.RTIME
    , COMOUT.GROUPKEY
  FROM COMOUT
  INNER JOIN COMOUTLOT
    ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = COMOUT.ITEMID
  LEFT JOIN MSTCUST
    ON MSTCUST.CUSTCD = COMOUT.CUSTCD
  LEFT JOIN COMLOT
    ON COMLOT.LOTKEY = COMOUTLOT.LOTKEY
   AND COMLOT.WARECD = COMOUT.WARECD
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = COMOUT.REMP
  WHERE COMOUT.OUTTP = _$OUTTP
    AND COMOUT.WARECD = _$RTNWARE
    AND COMOUT.OUTDATE BETWEEN $SDATE AND $EDATE
    AND COMOUT.CUSTCD LIKE CONCAT('%', IFNULL($CUSTCD, ''), '%')
  ORDER BY COMOUT.OUTDATE DESC, COMOUT.RTIME DESC, COMOUTLOT.LOTKEY;

-- ****************************************************************************
WHEN 'DEL_RTN' THEN -- 반입 취소 : 제품불량창고 재고 차감, 출고이력 삭제

  IF IFNULL($OUTKEY_LIST, '') = '' THEN
    CALL COMERR('취소할 반입 이력을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 전부 확인한 뒤에 쓴다
  SET _$OUTKEY_LIST = $OUTKEY_LIST;

  WHILE LENGTH(_$OUTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$OUTKEY_LIST, _$OUTKEY);

    SET _$LOTKEY = NULL;
    SELECT COMOUTLOT.LOTKEY, -COMOUT.OUTQTY, COMOUT.RTIME
      INTO _$LOTKEY, _$RTNQTY, _$OUTRTIME
      FROM COMOUT
      INNER JOIN COMOUTLOT ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
      WHERE COMOUT.OUTKEY = _$OUTKEY
        AND COMOUT.OUTTP = _$OUTTP
        AND COMOUT.WARECD = _$RTNWARE
      LIMIT 1;

    IF _$LOTKEY IS NULL THEN
      CALL COMERR('반입 이력이 없습니다. 다시 조회하세요.');
      LEAVE PROC;
    END IF;

    SET _$LOTQTY = IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = _$RTNWARE), 0);

    IF _$LOTQTY < _$RTNQTY THEN
      CALL COMERR(CONCAT('제품불량창고 재고가 반입수량보다 적어 취소할 수 없습니다. (이미 이동·사용된 재고)'
                        , '\n- 로트번호: ', _$LOTKEY
                        , '\n- 재고량: ', FORMAT(_$LOTQTY, 0)
                        , '\n- 반입수량: ', FORMAT(_$RTNQTY, 0)));
      LEAVE PROC;
    END IF;

    IF EXISTS (SELECT 1
                 FROM TQMJUDGE
                 WHERE TQMJUDGE.LOTKEY = _$LOTKEY
                   AND TQMJUDGE.WARECD = _$RTNWARE
                   AND TQMJUDGE.RTIME >= _$OUTRTIME) THEN
      CALL COMERR(CONCAT('반입 후 부적합 판정이 등록된 로트입니다. 판정을 먼저 삭제하세요.', '\n- 로트번호: ', _$LOTKEY));
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 취소
  SET _$OUTKEY_LIST = $OUTKEY_LIST;

  WHILE LENGTH(_$OUTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$OUTKEY_LIST, _$OUTKEY);

    SELECT COMOUTLOT.LOTKEY, -COMOUT.OUTQTY
      INTO _$LOTKEY, _$RTNQTY
      FROM COMOUT
      INNER JOIN COMOUTLOT ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
      WHERE COMOUT.OUTKEY = _$OUTKEY
      LIMIT 1;

    -- 2-1. 제품불량창고 재고 차감, 이 반입으로 생긴 재고 행이면 삭제
    UPDATE COMLOT
       SET COMLOT.LOTQTY = COMLOT.LOTQTY - _$RTNQTY
         , COMLOT.CRTQTY = COMLOT.CRTQTY - _$RTNQTY
         , COMLOT.MTIME  = CALLTIME()
         , COMLOT.MEMP   = CALLEMP()
         , COMLOT.MPRG   = CALLPRG()
     WHERE COMLOT.LOTKEY = _$LOTKEY
       AND COMLOT.WARECD = _$RTNWARE;

    DELETE FROM COMLOT
     WHERE COMLOT.LOTKEY = _$LOTKEY
       AND COMLOT.WARECD = _$RTNWARE
       AND COMLOT.LOTQTY <= 0
       AND COMLOT.CRTQTY <= 0;

    -- 2-2. 출고이력 삭제
    DELETE FROM COMOUTLOT WHERE COMOUTLOT.OUTKEY = _$OUTKEY;
    DELETE FROM COMOUT WHERE COMOUT.OUTKEY = _$OUTKEY;

    SET _$CNT = _$CNT + 1;
  END WHILE;

  SELECT _$CNT AS DELCNT;

-- ****************************************************************************
-- 공정이동표 (반입 1건에 1장, 양식 TMLPRINT.PRD_1)
-- 화면이 isBad = true 로 부르므로 수량은 BADQTY, 제목은 "공 정 이 동 표 (BADTPNM)"
-- 작업장 칸 = 반입 거래처, 공정 칸 = 출하반품, 생산일자 = 반입일자(새 로트) / 원래 제조일자(공정이동표 로트)
-- ****************************************************************************
WHEN 'PRINT_MOVE' THEN

  IF IFNULL($OUTKEY_LIST, '') = '' THEN
    CALL COMERR('반입 이력이 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM COMOUT WHERE COMOUT.OUTKEY = $OUTKEY_LIST AND COMOUT.OUTTP = _$OUTTP) THEN
    CALL COMERR('반입 이력이 없습니다. 다시 조회하세요.');
    LEAVE PROC;
  END IF;

  -- 0. 품목·반입정보·로트
  SELECT
      MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL(COMLOT.HEATNO, '') AS HEATNO
    , '' AS HEATLOTKEY
    , IFNULL(NULLIF(COMLOT.PRDDATE, ''), COMOUT.OUTDATE) AS PRDDATE
    , IFNULL(MSTEMP.EMPNM, COMOUT.REMP) AS EMPNM
    , LEFT(COMOUT.RTIME, 16) AS RSTTIME
    , COMOUTLOT.LOTKEY
    , IFNULL(MSTCUST.CUSTNM, COMOUT.CUSTCD) AS LINENM
    , '출하반품' AS PRCNM
    , '' AS EQMNM
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , '' AS GOODQTY
    , FORMAT(-COMOUT.OUTQTY, 0) AS BADQTY
    , '출하반품' AS BADTPNM
    , IFNULL((SELECT E.EMPNM FROM MSTEMP AS E WHERE E.EMPCD = CALLEMP() LIMIT 1), CALLEMP()) AS PRINTEMPNM
    , CALLTIME() AS PRINTTIME
  FROM COMOUT
  INNER JOIN COMOUTLOT
    ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = COMOUT.ITEMID
  LEFT JOIN COMLOT
    ON COMLOT.LOTKEY = COMOUTLOT.LOTKEY
   AND COMLOT.WARECD = COMOUT.WARECD
  LEFT JOIN MSTCUST
    ON MSTCUST.CUSTCD = COMOUT.CUSTCD
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = COMOUT.REMP
  WHERE COMOUT.OUTKEY = $OUTKEY_LIST
  LIMIT 1;

  -- 1. 로트추적 : 반입 이력 한 줄
  SELECT
      1 AS NO
    , MSTITEM.ITEMCD
    , IFNULL(MSTCUST.CUSTNM, COMOUT.CUSTCD) AS LINENM
    , '출하반품' AS PRCNM
    , COMOUTLOT.LOTKEY
  FROM COMOUT
  INNER JOIN COMOUTLOT
    ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = COMOUT.ITEMID
  LEFT JOIN MSTCUST
    ON MSTCUST.CUSTCD = COMOUT.CUSTCD
  WHERE COMOUT.OUTKEY = $OUTKEY_LIST
  LIMIT 1;

-- ****************************************************************************
END CASE; END
