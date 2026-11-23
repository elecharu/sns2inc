CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_MOVELOT(
-- *****************************************************************************
-- Comment: 무상사급 납품 등록 (외주이동, TML1010 R02)
-- Create: 2026-10-08 : 김영철
-- Modify: 2026-11-12: 입고창고($INWARE) 추가 - 외주이동(TML1010 R02) 에서 고른 S&S 사내 입고창고를 거래명세서 헤더(INWARE)에 저장
-- Modify: 2026-11-12: 시편수량($TESTQTY_LIST) 추가 - 이동량에 포함, 거래명세서 상세(TESTQTY)에 저장, 입고 때 시편창고로 이동 (IO_MOVELOT_TEST)
-- Modify: 2026-11-12: 외주이동 시 재고가 움직이지 않도록 변경 (외주입고 IO_MTRINVOICE 에서 외주처 재고 차감·출고이력 생성)
--                     거래명세서 상세(MTRCUST_INVOICE_DETAIL)에 출고창고(WARECD) 저장, 입고 전 다른 납품에 올라간 LOT 는 다시 올릴 수 없음
-- *****************************************************************************
  IN $CUSTCD            VARCHAR(100),
  IN $MOVEDATE          VARCHAR(100),
  IN $INWARE            VARCHAR(100),

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
  DECLARE _$LOTQTY       DECIMAL(18, 3);
  DECLARE _$TESTQTY      DECIMAL(18, 3);

  DECLARE _$WARECD       VARCHAR(100);
  DECLARE _$INVOICETP    VARCHAR(100);
  DECLARE _$INVOICEKEY   VARCHAR(100);

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

  IF IFNULL($INWARE, '') = '' THEN
    CALL COMERR('입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MSTWARE WHERE MSTWARE.WARECD = $INWARE AND MSTWARE.USEYN = 'Y' AND IFNULL(MSTWARE.CUSTCD, '') = '') THEN
    CALL COMERR('입고창고는 사내 창고만 선택할 수 있습니다.');
    LEAVE PROC;
  END IF;

  -- INVOICETP -> 03 : 무상사급 납품
  SET _$INVOICETP = '03';

  -- 거래명세서 헤더
  SET _$INVOICEKEY = GETKEY('INVOICEKEY');

  INSERT INTO MTRCUST_INVOICE_HEADER (
      INVOICEKEY, INVOICETP, INVOICEDATE, CUSTCD_GIVER, CUSTCD_RECIEVER, INWARE,
      EMPCD, RTIME, REMP, RPRG
  )
  VALUES (
      _$INVOICEKEY, _$INVOICETP, LEFT($MOVEDATE, 10), $CUSTCD, '', $INWARE,
      CALLEMP(), CALLTIME(), CALLEMP(), CALLPRG()
  );

  -- LOT 별 거래명세서 상세 (재고는 외주입고 때 차감)
  WHILE LENGTH(IFNULL($LOTKEY_LIST, '')) > 0 DO
    CALL COMSPLIT($WARECD_LIST, _$WARECD);
    CALL COMSPLIT($LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT($LOTQTY_LIST, _$LOTQTY);
    CALL COMSPLIT($TESTQTY_LIST, _$TESTQTY);
    SET _$TESTQTY = IFNULL(_$TESTQTY, 0);

    IF IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = _$WARECD), 0) < _$LOTQTY THEN
      CALL COMERR('재고 수량이 납품 출하수량 보다 작으면 출하가 불가능 합니다.');
      LEAVE PROC;
    END IF;

    IF _$TESTQTY < 0 OR _$TESTQTY > _$LOTQTY THEN
      CALL COMERR(CONCAT('시편수량은 0 이상, 이동량 이하로 입력하세요.', '\n- 로트번호: ', _$LOTKEY));
      LEAVE PROC;
    END IF;

    -- 아직 입고되지 않은 다른 납품 거래명세서에 올라간 LOT 는 다시 올릴 수 없음
    IF EXISTS (SELECT 1
                 FROM MTRCUST_INVOICE_DETAIL AS D
                INNER JOIN MTRCUST_INVOICE_HEADER AS H ON H.INVOICEKEY = D.INVOICEKEY
                WHERE D.LOTKEY = _$LOTKEY
                  AND D.WARECD = _$WARECD
                  AND H.INVOICETP = '03'
                  AND D.INVOICEKEY <> _$INVOICEKEY
                  AND NOT EXISTS (SELECT 1 FROM MTRIN WHERE MTRIN.INVOICEKEY = H.INVOICEKEY)) THEN
      CALL COMERR(CONCAT('입고 전 거래명세서에 이미 등록된 LOT 입니다.', '\n- 로트번호: ', _$LOTKEY));
      LEAVE PROC;
    END IF;

    -- 거래명세서 상세
    INSERT INTO MTRCUST_INVOICE_DETAIL (
      INVOICEKEY, LOTKEY, LOTQTY, ITEMID, LOTTP, WARECD, TESTQTY, RTIME, REMP, RPRG)
      SELECT
      _$INVOICEKEY, _$LOTKEY, _$LOTQTY, ITEMID, LOTTP, _$WARECD, _$TESTQTY, CALLTIME(), CALLEMP(), CALLPRG()
      FROM COMLOT
      WHERE LOTKEY = _$LOTKEY
        AND WARECD = _$WARECD;

  END WHILE;

  IF NOT EXISTS (SELECT 1 FROM MTRCUST_INVOICE_DETAIL WHERE INVOICEKEY = _$INVOICEKEY) THEN
    CALL COMERR('입고할 품목이 없습니다.');
    LEAVE PROC;
  END IF;

  SET @INVOICEKEY = _$INVOICEKEY;

-- ****************************************************************************
END IF; END
