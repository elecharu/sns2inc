CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_MTRINVOICE_CANCEL(
-- *****************************************************************************
-- Comment: 거래명세서 입고 취소 (외주입고 TML1020_R01 [입고취소] 탭) - 거래명세서 단위
--          입고이력(MTRIN) 별로 IO_MTRINVOICE_DEL 을 부르고, 무상사급 납품(03) 은 먼저 외주처 재고 차감·출고이력(구분 82)을 되돌림
--          거래명세서는 남기고 입고대기 상태로 돌아감
--          무상사급 납품(03) : ERP 로 이미 넘어간 입고는 취소 불가. 시편수량은 IO_MOVELOT_TEST_DEL 로 시편창고에서 되돌림 (시편을 이미 썼으면 취소 불가)
-- Create: 2026-11-12
-- Modify: 2026-11-23: 시편수량이 있는 입고도 취소 가능
-- *****************************************************************************
  IN $INVOICEKEY      VARCHAR(50)
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************

  DECLARE _$TP        VARCHAR(20);
  DECLARE _$MAGAMDT   VARCHAR(10);
  DECLARE _$MTRINKEY  VARCHAR(20);
  DECLARE _$LIST     MEDIUMTEXT;

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  IF NOT EXISTS (SELECT 1 FROM MTRIN WHERE INVOICEKEY = $INVOICEKEY) THEN
    CALL COMERR('입고이력이 없는 거래명세서입니다.');
    LEAVE PROC;
  END IF;

  SET _$TP = IFNULL((SELECT INVOICETP FROM MTRCUST_INVOICE_HEADER WHERE INVOICEKEY = $INVOICEKEY), '');

  IF _$TP = '03' THEN

    -- ERP 마감 / 전송 확인
    SET _$MAGAMDT = (SELECT MIN(MTRIN.INDATE) FROM MTRIN WHERE MTRIN.INVOICEKEY = $INVOICEKEY);

    IF EXISTS (SELECT 1 FROM MSTMAGAM_PRD WHERE MSTMAGAM_PRD.BDVCD = '71' AND MSTMAGAM_PRD.EDT = _$MAGAMDT) THEN
      CALL COMERR(CONCAT('ERP에서 마감된 일자 입니다. (', _$MAGAMDT, ')'));
      LEAVE PROC;
    END IF;

    IF EXISTS (SELECT 1 FROM IF_MES_SNS_FAC2.FAC2_ERP_IF_WORK AS W
                WHERE W.MOVENO = CONCAT('2MES', $INVOICEKEY) AND W.IF_YN <> 'N') THEN
      CALL COMERR('이미 ERP 로 전송된 입고는 취소할 수 없습니다.');
      LEAVE PROC;
    END IF;

    -- 입고창고 재고를 이미 썼으면 취소 불가 (IO_MTRINVOICE_DEL 과 같은 기준을, 외주 재고를 건드리기 전에 확인)
    --   (시편수량은 입고창고에서 시편창고로 옮겨져 있으므로 그만큼은 사용한 것으로 보지 않음)
    IF EXISTS (SELECT 1 FROM COMLOT
                INNER JOIN MTRIN ON MTRIN.MTRINKEY = COMLOT.MTRINKEY
                LEFT JOIN MTRCUST_INVOICE_DETAIL AS D ON D.INVOICEKEY = MTRIN.INVOICEKEY AND D.LOTKEY = COMLOT.LOTKEY
                WHERE MTRIN.INVOICEKEY = $INVOICEKEY AND COMLOT.LOTQTY + IFNULL(D.TESTQTY, 0) <> COMLOT.CRTQTY) THEN
      CALL COMERR('이미 사용된 재고가 있어 입고 취소할 수 없습니다.');
      LEAVE PROC;
    END IF;

    -- 시편창고로 옮긴 시편수량 되돌림 (시편을 이미 썼으면 여기서 오류, 아무것도 바뀌지 않음)
    CALL IO_MOVELOT_TEST_DEL($INVOICEKEY);

    IF IFNULL(@ERRMSG, '') <> '' THEN
      LEAVE PROC;
    END IF;

    -- 외주처 재고 복원 (입고 때 차감한 출고이력 구분 82)
    UPDATE COMLOT
     INNER JOIN COMOUTLOT ON COMOUTLOT.LOTKEY = COMLOT.LOTKEY AND COMOUTLOT.WARECD = COMLOT.WARECD
     INNER JOIN COMOUT ON COMOUT.OUTKEY = COMOUTLOT.OUTKEY
       SET COMLOT.LOTQTY = COMLOT.LOTQTY + COMOUTLOT.OUTQTY,
           COMLOT.MTIME  = CALLTIME(),
           COMLOT.MEMP   = CALLEMP(),
           COMLOT.MPRG   = CALLPRG()
     WHERE COMOUT.INVOICEKEY = $INVOICEKEY
       AND COMOUT.OUTTP = '82';

    DELETE COMOUTLOT FROM COMOUTLOT
     INNER JOIN COMOUT ON COMOUT.OUTKEY = COMOUTLOT.OUTKEY
     WHERE COMOUT.INVOICEKEY = $INVOICEKEY AND COMOUT.OUTTP = '82';

    DELETE FROM COMOUT WHERE INVOICEKEY = $INVOICEKEY AND OUTTP = '82';

    DELETE FROM IF_MES_SNS_FAC2.FAC2_ERP_IF_WORK
     WHERE MOVENO = CONCAT('2MES', $INVOICEKEY) AND IF_YN = 'N';
  END IF;

  -- 입고이력 별 취소 (입고창고 재고·입고이력 삭제, 유상사급 01 은 ERP DLV 취소 포함)
  SET _$LIST = IFNULL((SELECT GROUP_CONCAT(MTRINKEY ORDER BY MTRINKEY SEPARATOR '»') FROM MTRIN WHERE INVOICEKEY = $INVOICEKEY), '');

  WHILE LENGTH(IFNULL(_$LIST, '')) > 0 DO
    CALL COMSPLIT(_$LIST, _$MTRINKEY);

    IF IFNULL(_$MTRINKEY, '') <> '' THEN
      CALL IO_MTRINVOICE_DEL(_$MTRINKEY);

      IF IFNULL(@ERRMSG, '') <> '' THEN
        LEAVE PROC;
      END IF;
    END IF;
  END WHILE;

-- ****************************************************************************
END IF; END
