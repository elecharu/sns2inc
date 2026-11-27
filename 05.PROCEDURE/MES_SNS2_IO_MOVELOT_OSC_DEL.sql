CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_MOVELOT_OSC_DEL(
-- *****************************************************************************
-- Comment: 외주간 이동(거래명세서 04) 삭제 - IO_MOVELOT_OSC 로 만든 이동을 되돌림
--          이동받은 외주창고에서 이동량을 빼 원래 외주창고로 돌려놓고, 출고·입고 이력과 거래명세서 삭제
--          시편수량이 있는 이동(시편창고로 따로 이동됨)은 삭제 불가. ERP 로는 송신한 I 행을 D 로 다시 송신 (IO_ERP_INTERFACE WORK_DEL)
-- Create: 2026-11-12
-- Modify: 2026-11-27 김영철 ERP 전송 여부와 상관없이 삭제 가능, 삭제 시 D 송신 (기존: 미전송 행은 삭제, 전송된 이동은 삭제 불가)
-- *****************************************************************************
  IN $INVOICEKEY   VARCHAR(100)
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$MOVEWARECD VARCHAR(20);
  DECLARE _$MAGAMDT    VARCHAR(10);

  DECLARE _$DONE       INT DEFAULT 0;
  DECLARE _$LOTKEY     VARCHAR(100);
  DECLARE _$OUTWARE    VARCHAR(20);
  DECLARE _$QTY        DECIMAL(20, 8);

  DECLARE CUR_LOT CURSOR FOR
    SELECT COMOUTLOT.LOTKEY, COMOUTLOT.WARECD, COMOUTLOT.OUTQTY
      FROM COMOUT
     INNER JOIN COMOUTLOT ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
     WHERE COMOUT.INVOICEKEY = $INVOICEKEY
       AND COMOUT.OUTTP = '83';

  DECLARE CONTINUE HANDLER FOR NOT FOUND SET _$DONE = 1;

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  IF NOT EXISTS (SELECT 1 FROM MTRCUST_INVOICE_HEADER WHERE INVOICEKEY = $INVOICEKEY AND INVOICETP = '04') THEN
    CALL COMERR('외주간 이동 거래명세서가 아닙니다.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM MTRCUST_INVOICE_DETAIL WHERE INVOICEKEY = $INVOICEKEY AND IFNULL(TESTQTY, 0) > 0) THEN
    CALL COMERR('시편수량이 있는 이동은 삭제할 수 없습니다.');
    LEAVE PROC;
  END IF;

  -- ERP 마감 / 전송 확인
  SET _$MAGAMDT = (SELECT LEFT(INVOICEDATE, 10) FROM MTRCUST_INVOICE_HEADER WHERE INVOICEKEY = $INVOICEKEY);

  IF EXISTS (SELECT 1 FROM MSTMAGAM_PRD WHERE MSTMAGAM_PRD.BDVCD = '71' AND MSTMAGAM_PRD.EDT = _$MAGAMDT) THEN
    CALL COMERR(CONCAT('ERP에서 마감된 일자 입니다. (', _$MAGAMDT, ')'));
    LEAVE PROC;
  END IF;

  -- 이동받은 외주창고
  SELECT MSTWARE.WARECD
    INTO _$MOVEWARECD
    FROM MTRCUST_INVOICE_HEADER AS H
   INNER JOIN MSTWARE ON MSTWARE.CUSTCD = H.CUSTCD_RECIEVER
                     AND MSTWARE.FACTORYCD = '07'
   WHERE H.INVOICEKEY = $INVOICEKEY
   LIMIT 1;

  IF IFNULL(_$MOVEWARECD, '') = '' THEN
    CALL COMERR('이동 창고 정보가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 1. 확인 : 이동받은 창고 재고가 이동량보다 적으면 (이미 사용·이동됨) 삭제 불가
  SET _$DONE = 0;
  OPEN CUR_LOT;
  LOOP_CHK: LOOP
    FETCH CUR_LOT INTO _$LOTKEY, _$OUTWARE, _$QTY;
    IF _$DONE = 1 THEN LEAVE LOOP_CHK; END IF;

    IF IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = _$MOVEWARECD), 0) < _$QTY THEN
      CLOSE CUR_LOT;
      CALL COMERR(CONCAT('이동받은 창고 재고가 이동량보다 적어 삭제할 수 없습니다. (이미 사용된 재고)'
                        , '\n- 로트번호: ', _$LOTKEY));
      LEAVE PROC;
    END IF;
  END LOOP LOOP_CHK;
  CLOSE CUR_LOT;

  -- 2. 되돌림
  SET _$DONE = 0;
  OPEN CUR_LOT;
  LOOP_DEL: LOOP
    FETCH CUR_LOT INTO _$LOTKEY, _$OUTWARE, _$QTY;
    IF _$DONE = 1 THEN LEAVE LOOP_DEL; END IF;

    UPDATE COMLOT
       SET COMLOT.LOTQTY = COMLOT.LOTQTY - _$QTY
         , COMLOT.MTIME  = CALLTIME()
         , COMLOT.MEMP   = CALLEMP()
         , COMLOT.MPRG   = CALLPRG()
     WHERE COMLOT.LOTKEY = _$LOTKEY
       AND COMLOT.WARECD = _$MOVEWARECD;

    -- 이동으로 새로 만들어진 이동 창고 LOT (수량 0) 삭제
    DELETE FROM COMLOT
     WHERE COMLOT.LOTKEY = _$LOTKEY
       AND COMLOT.WARECD = _$MOVEWARECD
       AND COMLOT.LOTQTY = 0;

    UPDATE COMLOT
       SET COMLOT.LOTQTY = COMLOT.LOTQTY + _$QTY
         , COMLOT.MTIME  = CALLTIME()
         , COMLOT.MEMP   = CALLEMP()
         , COMLOT.MPRG   = CALLPRG()
     WHERE COMLOT.LOTKEY = _$LOTKEY
       AND COMLOT.WARECD = _$OUTWARE;
  END LOOP LOOP_DEL;
  CLOSE CUR_LOT;

  -- 3. 이력·거래명세서 삭제
  DELETE COMOUTLOT FROM COMOUTLOT
   INNER JOIN COMOUT ON COMOUT.OUTKEY = COMOUTLOT.OUTKEY
   WHERE COMOUT.INVOICEKEY = $INVOICEKEY AND COMOUT.OUTTP = '83';

  DELETE FROM COMOUT WHERE COMOUT.INVOICEKEY = $INVOICEKEY AND COMOUT.OUTTP = '83';

  DELETE COMINLOT FROM COMINLOT
   INNER JOIN COMIN ON COMIN.INKEY = COMINLOT.INKEY
   WHERE COMIN.INVOICEKEY = $INVOICEKEY AND COMIN.INTP = '83';

  DELETE FROM COMIN WHERE COMIN.INVOICEKEY = $INVOICEKEY AND COMIN.INTP = '83';

  -- ERP 인터페이스 (외주간 이동 삭제 : 송신한 I 를 D 로 다시 송신)
  CALL IO_ERP_INTERFACE('WORK_DEL', $INVOICEKEY, 'D');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  DELETE FROM MTRCUST_INVOICE_DETAIL WHERE INVOICEKEY = $INVOICEKEY;
  DELETE FROM MTRCUST_INVOICE_HEADER WHERE INVOICEKEY = $INVOICEKEY;

-- ****************************************************************************
END IF; END
