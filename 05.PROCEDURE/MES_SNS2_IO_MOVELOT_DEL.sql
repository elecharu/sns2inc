CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_MOVELOT_DEL(
-- *****************************************************************************
-- Comment: 무상사급 납품 삭제 (외주이동 취소, TML1010 R02)
-- Create: 2026-10-12 : 김영철
-- Modify: 2026-11-12: 외주이동은 입고 전까지 재고가 움직이지 않으므로, 출고이력이 없는 거래명세서는 거래명세서만 삭제
--                     (출고이력이 있는 예전 거래명세서는 기존처럼 재고 복원 후 삭제)
--                     입고 여부는 MTRIN(입고이력) 으로 확인
-- *****************************************************************************
  IN $INVOICEKEY        VARCHAR(100)
-- *****************************************************************************
)
PROC: BEGIN

  DECLARE _$OUTKEY      VARCHAR(100);
  DECLARE _$WARECD      VARCHAR(100);

  DECLARE _$OUTKEY_LIST MEDIUMTEXT;

-- ****************************************************************************
  IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  IF IFNULL($INVOICEKEY, '') = '' THEN
    CALL COMERR('거래명세서 번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF EXISTS(
    SELECT 1
      FROM MTRIN
      WHERE INVOICEKEY = $INVOICEKEY) THEN
        CALL COMERR('이미 S&S에 입고된 내용은 삭제할 수 없습니다.');
        LEAVE PROC;
  END IF;

  -- 예전 방식(이동 시 재고 차감) 으로 등록된 거래명세서 : 출고이력 삭제 + 재고 복원
  SET _$OUTKEY_LIST = IFNULL((SELECT GROUP_CONCAT(DISTINCT OUTKEY ORDER BY OUTKEY ASC SEPARATOR '»')
                                FROM COMOUT
                                WHERE INVOICEKEY = $INVOICEKEY), '');

  WHILE LENGTH(IFNULL(_$OUTKEY_LIST, '')) > 0 DO
    CALL COMSPLIT(_$OUTKEY_LIST, _$OUTKEY);

    IF IFNULL(_$OUTKEY, '') = '' THEN
      CALL COMERR('출고키 정보가 없습니다.');
      LEAVE PROC;
    END IF;

    SELECT WARECD
      INTO _$WARECD
      FROM COMOUT
      WHERE OUTKEY = _$OUTKEY;

    UPDATE COMLOT AS A
      INNER JOIN COMOUTLOT AS B ON A.LOTKEY = B.LOTKEY
      INNER JOIN COMOUT AS C ON B.OUTKEY = C.OUTKEY
      SET A.LOTQTY = A.LOTQTY + B.OUTQTY,
          A.MTIME = CALLTIME(),
          A.MEMP = CALLEMP(),
          A.MPRG = CALLPRG()
      WHERE C.OUTKEY = _$OUTKEY
        AND A.WARECD = _$WARECD;

    DELETE FROM COMOUTLOT
     WHERE OUTKEY = _$OUTKEY;

    DELETE FROM COMOUT
     WHERE OUTKEY = _$OUTKEY;

  END WHILE;

  DELETE FROM MTRCUST_INVOICE_DETAIL
   WHERE INVOICEKEY = $INVOICEKEY;

  DELETE FROM MTRCUST_INVOICE_HEADER
   WHERE INVOICEKEY = $INVOICEKEY;

-- ****************************************************************************
  END IF;
END
