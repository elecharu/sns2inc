CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_MOVELOT_OSC(
-- *****************************************************************************
-- Comment: 외주간 재고 이동
-- Create: 2026-10-08 : 김영철
-- Modify: 2026-11-12: 시편수량($TESTQTY_LIST) 추가 - 이동량에 포함, 이동 창고에 들어온 뒤 시편창고로 이동 (IO_MOVELOT_TEST)
-- Modify: 2026-11-12: 거래명세서 상세 수량을 LOT 재고가 아닌 이동량으로 (부분 이동 지원)
-- Modify: 2026-11-11: ERP 인터페이스(WORK_30, 창고이동 FLAG 30 외주간이동) 송신 추가
-- *****************************************************************************
  IN $CUSTCD            VARCHAR(100),
  IN $MOVEDATE          VARCHAR(100),
  IN $MOVECUSTCD        VARCHAR(100),

  IN $WARECD_LIST       MEDIUMTEXT,
  IN $LOTKEY_LIST       MEDIUMTEXT,
  IN $LOTQTY_LIST       MEDIUMTEXT,
  IN $TESTQTY_LIST      MEDIUMTEXT

-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$LOTKEY       VARCHAR(100);
  DECLARE _$WARECD       VARCHAR(100);
  DECLARE _$MOVEWARECD   VARCHAR(100);
  DECLARE _$INVOICETP    VARCHAR(100);
  DECLARE _$OUTKEY       VARCHAR(100);
  DECLARE _$OUTTP        VARCHAR(100);
  DECLARE _$INKEY        VARCHAR(100);
  DECLARE _$INTP         VARCHAR(100);
  DECLARE _$INVOICEKEY   VARCHAR(100);
  DECLARE _$GROUPKEY     VARCHAR(100);
  DECLARE _$ITEMID       VARCHAR(100);

  DECLARE _$LOTQTY       DECIMAL(18, 3);
  DECLARE _$TESTQTY      DECIMAL(18, 3);

  DECLARE _$ITEMID_LIST  MEDIUMTEXT;

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  IF IFNULL($CUSTCD, '') = '' THEN
    CALL COMERR('거래처 정보가 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($LOTKEY_LIST, '') = '' THEN
    CALL COMERR('납품할 로트가 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($MOVECUSTCD, '') = '' THEN
    CALL COMERR('이동 거래처 정보가 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($CUSTCD, '') = IFNULL($MOVECUSTCD, '') THEN
    CALL COMERR('같은 거래처로는 이동이 불가능 합니다.');
    LEAVE PROC;
  END IF;

  SELECT WARECD
    INTO _$MOVEWARECD
    FROM MSTWARE 
    WHERE CUSTCD = $MOVECUSTCD
      AND FACTORYCD = '07';

  IF IFNULL(_$MOVEWARECD, '') = '' THEN
    CALL COMERR('이동 창고 정보가 없습니다.');
    LEAVE PROC;
  END IF;

  -- INVOICETP -> 04 : 외주간 이동  	
  -- OUTTP -> 022	창고이동(외주간이동) (2026-11-23 신정수)
  -- INTP -> 022	창고이동(외주간이동) (2026-11-23 신정수)
  SET _$INVOICETP = '04';
  SET _$OUTTP = '022';
  SET _$INTP = '022';

  -- 거래명세서 헤더
  SET _$INVOICEKEY = GETKEY('INVOICEKEY');

  INSERT INTO MTRCUST_INVOICE_HEADER (
      INVOICEKEY, INVOICETP, INVOICEDATE, CUSTCD_GIVER, CUSTCD_RECIEVER,
      EMPCD, RTIME, REMP, RPRG
  )
  VALUES (
      _$INVOICEKEY, _$INVOICETP, LEFT($MOVEDATE, 10), $CUSTCD, $MOVECUSTCD,
      CALLEMP(), CALLTIME(), CALLEMP(), CALLPRG()
  );

  -- 품목 + 구분별 처리
  WHILE LENGTH(IFNULL($LOTKEY_LIST, '')) > 0 DO
    CALL COMSPLIT($WARECD_LIST, _$WARECD);
    CALL COMSPLIT($LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT($LOTQTY_LIST, _$LOTQTY);
    CALL COMSPLIT($TESTQTY_LIST, _$TESTQTY);
    SET _$TESTQTY = IFNULL(_$TESTQTY, 0);

    IF _$TESTQTY < 0 OR _$TESTQTY > _$LOTQTY THEN
      CALL COMERR(CONCAT('시편수량은 0 이상, 이동량 이하로 입력하세요.', '\n- 로트번호: ', _$LOTKEY));
      LEAVE PROC;
    END IF;

    IF(SELECT LOTQTY FROM COMLOT WHERE LOTKEY = _$LOTKEY AND WARECD = _$WARECD) < _$LOTQTY THEN
      CALL COMERR('재고 수량이 이동 수량 보다 작으면 이동이 불가능 합니다.');
      LEAVE PROC;
    END IF;

    -- 거래명세서 상세
    INSERT INTO MTRCUST_INVOICE_DETAIL (
      INVOICEKEY, LOTKEY, LOTQTY, ITEMID, LOTTP, TESTQTY, RTIME, REMP, RPRG)
      SELECT 
      _$INVOICEKEY, _$LOTKEY, _$LOTQTY, ITEMID, LOTTP, _$TESTQTY, CALLTIME(), CALLEMP(), CALLPRG()
      FROM COMLOT
      WHERE LOTKEY = _$LOTKEY
        AND WARECD = _$WARECD;

    -- 출고 재고 수량 차감
    UPDATE COMLOT 
      SET LOTQTY = LOTQTY - _$LOTQTY,
          MTIME = CALLTIME(),
          MEMP = CALLEMP(),
          MPRG = CALLPRG()
      WHERE LOTKEY = _$LOTKEY
        AND WARECD = _$WARECD;

    -- 입고 재고 생성
    INSERT INTO COMLOT(
      LOTKEY, WARECD, LOTQTY, 
      ITEMID, CRTTIME, CRTQTY, CUSTCD,  
      LOTTP, 
      RTIME, REMP, RPRG)
      SELECT 
        LOTKEY, _$MOVEWARECD, _$LOTQTY,
        ITEMID, GETTIME(), _$LOTQTY, $CUSTCD,
        LOTTP,
        CALLTIME(), CALLEMP(), CALLPRG()
        FROM COMLOT
        WHERE LOTKEY = _$LOTKEY
          AND WARECD = _$WARECD;

  END WHILE;

  SET _$ITEMID_LIST = IFNULL((SELECT GROUP_CONCAT(DISTINCT ITEMID ORDER BY ITEMID ASC SEPARATOR '»')
                                FROM MTRCUST_INVOICE_DETAIL
                                WHERE INVOICEKEY = _$INVOICEKEY), ''); 

  IF IFNULL(_$ITEMID_LIST, '') = '' THEN
    CALL COMERR('입고할 품목이 없습니다.');
    LEAVE PROC;
  END IF;

  WHILE LENGTH(IFNULL(_$ITEMID_LIST, '')) > 0 DO
    CALL COMSPLIT(_$ITEMID_LIST, _$ITEMID);

    IF IFNULL(_$ITEMID, '') = '' THEN
      CALL COMERR('품목 또는 구분 정보가 없습니다.');
      LEAVE PROC;
    END IF;

    SET _$OUTKEY = GETKEY('OUTKEY');
    SET _$INKEY = GETKEY('INKEY');
    SET _$GROUPKEY = GETGROUPKEY();

    INSERT INTO COMOUT(
      OUTKEY, WARECD, OUTTP, OUTDATE, 
      OUTQTY, ITEMID, EMPCD, GROUPKEY, INVOICEKEY,  
      RTIME, REMP, RPRG)
      SELECT 
        _$OUTKEY, B.WARECD, _$OUTTP, LEFT($MOVEDATE, 10),
        SUM(A.LOTQTY), A.ITEMID, CALLEMP(), _$GROUPKEY, A.INVOICEKEY, 
        CALLTIME(), CALLEMP(), CALLPRG()
        FROM MTRCUST_INVOICE_DETAIL AS A 
        INNER JOIN COMLOT AS B ON A.LOTKEY = B.LOTKEY
       WHERE A.INVOICEKEY = _$INVOICEKEY
         AND A.ITEMID = _$ITEMID
         AND B.WARECD = _$WARECD
      GROUP BY A.ITEMID;

    INSERT INTO COMOUTLOT(
      OUTKEY, LOTKEY, WARECD, OUTTP, 
      OUTDATE, OUTQTY, ITEMID, OLDQTY,  
      RTIME, REMP, RPRG)
      SELECT 
        _$OUTKEY, A.LOTKEY, B.WARECD, _$OUTTP,
        LEFT($MOVEDATE, 10), A.LOTQTY, A.ITEMID, B.LOTQTY + A.LOTQTY,
        CALLTIME(), CALLEMP(), CALLPRG()
        FROM MTRCUST_INVOICE_DETAIL AS A 
        INNER JOIN COMLOT AS B ON A.LOTKEY = B.LOTKEY
       WHERE A.INVOICEKEY = _$INVOICEKEY
         AND A.ITEMID = _$ITEMID
         AND B.WARECD = _$WARECD;

    -- 재고이력
    INSERT INTO COMIN (
      INKEY, ITEMID, WARECD, INTP, 
      INDATE, INQTY, EMPCD, GROUPKEY, INVOICEKEY,
      RTIME, REMP, RPRG
    )
    SELECT 
      _$INKEY, ITEMID, _$MOVEWARECD, _$INTP, 
      GETDATE(), SUM(LOTQTY), CALLEMP(), _$GROUPKEY, INVOICEKEY,
      CALLTIME(), CALLEMP(), CALLPRG()
      FROM MTRCUST_INVOICE_DETAIL
     WHERE INVOICEKEY = _$INVOICEKEY
       AND ITEMID = _$ITEMID
    GROUP BY ITEMID;

    -- 재고상세이력
    INSERT INTO COMINLOT (
      INKEY, LOTKEY, WARECD, INTP, 
      INDATE, INQTY, ITEMID,
      RTIME, REMP, RPRG
    )
    SELECT 
      _$INKEY, LOTKEY, _$WARECD, _$INTP, 
      GETDATE(), LOTQTY, ITEMID,
      CALLTIME(), CALLEMP(), CALLPRG()
      FROM MTRCUST_INVOICE_DETAIL
     WHERE INVOICEKEY = _$INVOICEKEY
       AND ITEMID = _$ITEMID;

  END WHILE;

  -- 시편수량 : 이동 창고에 들어온 LOT 의 시편수량을 시편창고로 이동
  CALL IO_MOVELOT_TEST(_$INVOICEKEY, _$MOVEWARECD, LEFT($MOVEDATE, 10));

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- ERP 인터페이스 (창고이동 30 외주간이동 : I)
  CALL IO_ERP_INTERFACE('WORK_30', _$INVOICEKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  SET @INVOICEKEY = _$INVOICEKEY;

-- ****************************************************************************
END IF; END