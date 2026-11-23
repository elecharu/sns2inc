CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_PRDRST_OSC_LOT(
-- *****************************************************************************
-- Comment: 외주 생산실적 생성 (스캔한 투입 LOT 기준) - TML1010_R03 무상사급 실적 등록
--          IO_PRDRST_OSC 와 같은 이력(자재출고 → OSCRST → 실적로트 입고)을 만들되
--          작업장·공정은 화면에서 받고, 투입 LOT 는 선입선출이 아니라 스캔한 LOT·사용량으로 차감
-- Create: 2026-11-09
-- Modify: 2026-11-11 ERP 인터페이스(OSCRST) 송신 추가
-- *****************************************************************************
  IN $CUSTCD       VARCHAR(100),   -- 외주처
  IN $LINECD       VARCHAR(100),   -- 작업장
  IN $PRCCD        VARCHAR(100),   -- 공정
  IN $ITEMID       VARCHAR(100),   -- 생산품
  IN $DNTP         VARCHAR(100),   -- 주야구분 (PP161)
  IN $WORKSDAY     VARCHAR(10),    -- 작업시작일
  IN $WORKSTIME    VARCHAR(8),     -- 작업시작시간
  IN $WORKEDAY     VARCHAR(10),    -- 작업종료일
  IN $WORKETIME    VARCHAR(8),     -- 작업종료시간
  IN $LOTKEY_LIST  MEDIUMTEXT,     -- 투입 LOT
  IN $USEQTY_LIST  MEDIUMTEXT      -- 투입 LOT 별 사용량
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$ITEMCG      VARCHAR(100);
  DECLARE _$GOODWARE    VARCHAR(100);
  DECLARE _$OSCRSTKEY   VARCHAR(100);
  DECLARE _$GROUPKEY    VARCHAR(100);
  DECLARE _$OUTKEY      VARCHAR(100);
  DECLARE _$INKEY       VARCHAR(100);
  DECLARE _$GOODLOTKEY  VARCHAR(100);
  DECLARE _$WGTP        VARCHAR(10);
  DECLARE _$RSTDATE     VARCHAR(10);
  DECLARE _$RSTTIME     VARCHAR(19);
  DECLARE _$LOTKEY      VARCHAR(100);
  DECLARE _$WARECD      VARCHAR(100);
  DECLARE _$USEITEMID   VARCHAR(100);
  DECLARE _$LOTQTY      DECIMAL(20, 8);
  DECLARE _$USEQTY      DECIMAL(20, 8);
  DECLARE _$GOODQTY     DECIMAL(20, 8) DEFAULT 0;

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  IF IFNULL($CUSTCD, '') = '' THEN
    CALL COMERR('외주처 정보가 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($LINECD, '') = '' THEN
    CALL COMERR('생산작업장이 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($PRCCD, '') = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($ITEMID, '') = '' THEN
    CALL COMERR('생산품목이 없습니다. 투입바코드를 스캔하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($LOTKEY_LIST, '') = '' THEN
    CALL COMERR('투입 LOT 가 없습니다. 투입바코드를 스캔하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($WORKSDAY, '') = '' OR IFNULL($WORKSTIME, '') = '' OR IFNULL($WORKEDAY, '') = '' OR IFNULL($WORKETIME, '') = '' THEN
    CALL COMERR('작업시작·종료 일시를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF CONCAT($WORKSDAY, ' ', LEFT($WORKSTIME, 5)) > CONCAT($WORKEDAY, ' ', LEFT($WORKETIME, 5)) THEN
    CALL COMERR('작업종료 일시가 작업시작 일시보다 빠릅니다.');
    LEAVE PROC;
  END IF;

  -- 주야구분 → 로트번호용 D/N
  SET _$WGTP = CASE WHEN $DNTP = 'PP161100N' THEN 'D'
                    WHEN $DNTP = 'PP161102N' THEN 'N'
                    ELSE '' END;

  IF _$WGTP = '' THEN
    CALL COMERR('주야구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 생산품 입고창고 (작업장·공정 설정, IO_PRDRST_OSC 와 같은 기준)
  SET _$ITEMCG = (SELECT MSTITEM.ITEMCG FROM MSTITEM WHERE MSTITEM.ITEMID = $ITEMID);

  SET _$GOODWARE = (SELECT CASE WHEN _$ITEMCG = 'DM100100' THEN MSTLINE_PRC.PROD_IN_WH  -- 제품
                                WHEN _$ITEMCG = 'DM100150' THEN MSTLINE_PRC.SEMI_IN_WH  -- 반제품
                           END
                      FROM MSTLINE_PRC
                      WHERE MSTLINE_PRC.LINECD = $LINECD
                        AND MSTLINE_PRC.PRCCD = $PRCCD
                      LIMIT 1);

  IF IFNULL(_$GOODWARE, '') = '' THEN
    CALL COMERR(CONCAT('생산품 입고창고 정보가 없습니다. (작업장·공정 설정 확인)'
                      , '\n- 작업장: ', IFNULL((SELECT MSTLINE.LINENM FROM MSTLINE WHERE MSTLINE.LINECD = $LINECD), $LINECD)
                      , '\n- 공정: ', IFNULL((SELECT MSTPRC.PRCNM FROM MSTPRC WHERE MSTPRC.PRCCD = $PRCCD), $PRCCD)));
    LEAVE PROC;
  END IF;

  SET _$RSTDATE     = $WORKSDAY;   -- 실적일자 = 작업시작일 (야간이면 전날)
  SET _$RSTTIME     = CONCAT($WORKEDAY, ' ', LEFT($WORKETIME, 5), ':00');
  SET _$OSCRSTKEY   = GETKEY('OSCRSTKEY');
  SET _$GROUPKEY    = GETKEY('GETGROUPKEY');
  SET _$INKEY       = GETKEY('INKEY');
  SET _$GOODLOTKEY  = GETLOTKEY_PRD(_$RSTDATE, $PRCCD, _$WGTP);

  -- 1. 자재차감 : 스캔한 LOT 마다 출고 (COMOUT·COMOUTLOT·OSCRSTUSE, COMLOT 차감)
  WHILE LENGTH($LOTKEY_LIST) > 0 DO
    CALL COMSPLIT($LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT($USEQTY_LIST, _$USEQTY);

    IF IFNULL(_$LOTKEY, '') <> '' THEN

      IF IFNULL(_$USEQTY, 0) <= 0 THEN
        CALL COMERR(CONCAT('사용량을 입력하세요.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      -- 투입 LOT 의 창고 (스캔해 둔 창고)
      SELECT PRDLINESCAN.WARECD
        INTO _$WARECD
        FROM PRDLINESCAN
        WHERE PRDLINESCAN.LINECD = $LINECD
          AND PRDLINESCAN.PRCCD = $PRCCD
          AND PRDLINESCAN.EQMCD = ''
          AND PRDLINESCAN.LOTKEY = _$LOTKEY
        LIMIT 1;

      SELECT COMLOT.LOTQTY, COMLOT.ITEMID
        INTO _$LOTQTY, _$USEITEMID
        FROM COMLOT
        WHERE COMLOT.LOTKEY = _$LOTKEY
          AND COMLOT.WARECD = _$WARECD;

      IF _$USEQTY > IFNULL(_$LOTQTY, 0) THEN
        CALL COMERR(CONCAT('사용량이 재고수량보다 많습니다.'
                          , '\n- 로트번호: ', _$LOTKEY
                          , '\n- 재고수량: ', FORMAT(IFNULL(_$LOTQTY, 0), 0)
                          , '\n- 사용량: ', FORMAT(_$USEQTY, 0)));
        LEAVE PROC;
      END IF;

      SET _$OUTKEY = GETKEY('OUTKEY');

      INSERT INTO COMOUT (
          OUTKEY, OUTTP, OUTDATE, OUTQTY, WARECD, ITEMID, EMPCD, PRCCD, OSCRSTKEY, GROUPKEY
        , RTIME, REMP, RPRG)
      VALUES (
          _$OUTKEY, '80', _$RSTDATE, _$USEQTY, _$WARECD, _$USEITEMID, CALLEMP(), $PRCCD, _$OSCRSTKEY, _$GROUPKEY
        , CALLTIME(), CALLEMP(), CALLPRG());

      UPDATE COMLOT
         SET COMLOT.LOTQTY = COMLOT.LOTQTY - _$USEQTY
           , COMLOT.MTIME  = CALLTIME()
           , COMLOT.MEMP   = CALLEMP()
           , COMLOT.MPRG   = CALLPRG()
       WHERE COMLOT.LOTKEY = _$LOTKEY
         AND COMLOT.WARECD = _$WARECD;

      INSERT INTO COMOUTLOT (
          OUTKEY, LOTKEY, ITEMID, WARECD, OUTDATE, OUTTP, OUTQTY, PRCCD, OLDQTY
        , RTIME, REMP, RPRG)
      VALUES (
          _$OUTKEY, _$LOTKEY, _$USEITEMID, _$WARECD, _$RSTDATE, '80', _$USEQTY, $PRCCD, _$LOTQTY
        , CALLTIME(), CALLEMP(), CALLPRG());

      INSERT INTO OSCRSTUSE (
          OSCRSTKEY, USELOTKEY, USEWARECD, USEITEMID, USEPRCCD, USEQTY
        , RTIME, REMP, RPRG)
      VALUES (
          _$OSCRSTKEY, _$LOTKEY, _$WARECD, _$USEITEMID, $PRCCD, _$USEQTY
        , CALLTIME(), CALLEMP(), CALLPRG());

      SET _$GOODQTY = _$GOODQTY + _$USEQTY;  -- 양품수량 = 투입 사용량 합계
    END IF;
  END WHILE;

  IF _$GOODQTY <= 0 THEN
    CALL COMERR('실적수량이 없습니다.');
    LEAVE PROC;
  END IF;

  -- 2. 생산실적
  INSERT INTO OSCRST (
      OSCRSTKEY, RSTTIME, ITEMID, PRODQTY, GOODQTY, BADQTY, TESTQTY, CUSTCD
    , LINECD, PRCCD, DNTP, WORKSTIME, WORKETIME
    , RTIME, REMP, RPRG)
  VALUES (
      _$OSCRSTKEY, _$RSTTIME, $ITEMID, _$GOODQTY, _$GOODQTY, 0, 0, $CUSTCD
    , $LINECD, $PRCCD, $DNTP
    , CONCAT($WORKSDAY, ' ', LEFT($WORKSTIME, 5), ':00'), CONCAT($WORKEDAY, ' ', LEFT($WORKETIME, 5), ':00')
    , CALLTIME(), CALLEMP(), CALLPRG());

  -- 3. 실적로트 생성·입고
  INSERT INTO OSCRSTLOT (
      OSCRSTKEY, LOTKEY, LOTTIME, LOTQTY, LOTTP
    , RTIME, REMP, RPRG)
  VALUES (
      _$OSCRSTKEY, _$GOODLOTKEY, _$RSTTIME, _$GOODQTY, '01'
    , CALLTIME(), CALLEMP(), CALLPRG());

  INSERT INTO COMLOT (
      LOTKEY, LABELCD, LOTQTY, LOTTP, WARECD, ITEMID, PRCCD, CUSTCD, CRTTIME, CRTQTY, PRDDATE, OSCRSTKEY
    , RTIME, REMP, RPRG)
  VALUES (
      _$GOODLOTKEY, 'MTR01', _$GOODQTY, '01', _$GOODWARE, $ITEMID, $PRCCD, $CUSTCD, _$RSTTIME, _$GOODQTY, _$RSTDATE, _$OSCRSTKEY
    , CALLTIME(), CALLEMP(), CALLPRG());

  INSERT INTO COMINLOT (
      INKEY, LOTKEY, INDATE, ITEMID, INTP, WARECD, INQTY, PRCCD
    , RTIME, REMP, RPRG)
  VALUES (
      _$INKEY, _$GOODLOTKEY, _$RSTDATE, $ITEMID, '80', _$GOODWARE, _$GOODQTY, $PRCCD
    , CALLTIME(), CALLEMP(), CALLPRG());

  INSERT INTO COMIN (
      INKEY, INDATE, INQTY, INTP, WARECD, ITEMID, PRCCD, EMPCD, GROUPKEY, OSCRSTKEY
    , RTIME, REMP, RPRG)
  VALUES (
      _$INKEY, _$RSTDATE, _$GOODQTY, '80', _$GOODWARE, $ITEMID, $PRCCD, CALLEMP(), _$GROUPKEY, _$OSCRSTKEY
    , CALLTIME(), CALLEMP(), CALLPRG());

  -- ERP 인터페이스 (외주 생산실적 : 실적·실적LOT·소요자재)
  CALL IO_ERP_INTERFACE('OSCRST', _$OSCRSTKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- 4. 투입 스캔·생산품 정보 비움 (다음 작업 준비)
  DELETE FROM PRDLINESCAN
   WHERE PRDLINESCAN.LINECD = $LINECD
     AND PRDLINESCAN.PRCCD = $PRCCD
     AND PRDLINESCAN.EQMCD = '';

  DELETE FROM PRDLINEITEM
   WHERE PRDLINEITEM.LINECD = $LINECD
     AND PRDLINEITEM.PRCCD = $PRCCD
     AND PRDLINEITEM.EQMCD = '';

  -- 실적로트 (공정이동표 출력용)
  SELECT _$OSCRSTKEY AS OSCRSTKEY, _$GOODLOTKEY AS LOTKEY, _$GOODQTY AS GOODQTY;

-- ****************************************************************************
END IF; END
