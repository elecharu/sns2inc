CREATE DEFINER=`root`@`%` PROCEDURE `IO_MTRINVOICE_DEL`(
-- *****************************************************************************
-- Comment: 거래명세서 입고 취소
-- Create: 2026-10-08 : 김영철
-- Modify: 2026-11-11 : 입고 취소 시 ERP 인터페이스(DLV, D) 송신 추가
-- *****************************************************************************
  IN $MTRINKEY        VARCHAR(20)
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  -- 1. 입력값 검증
  IF IFNULL($MTRINKEY, '') = '' THEN
    CALL COMERR('입고번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MTRIN WHERE MTRINKEY = $MTRINKEY) THEN
    CALL COMERR('존재하지 않는 입고이력입니다.');
    LEAVE PROC;
  END IF;

  -- 2. 이미 사용된 재고가 있으면 취소 불가
  IF EXISTS (SELECT 1
               FROM COMLOT
              WHERE MTRINKEY = $MTRINKEY
                AND LOTQTY <> CRTQTY) THEN
    CALL COMERR('이미 사용된 재고가 있어 입고 취소할 수 없습니다.');
    LEAVE PROC;
  END IF;

  -- ERP 인터페이스 (외주처 원자재 납품 취소) : 입고이력 삭제 전에 송신
  CALL IO_ERP_INTERFACE('DLV', $MTRINKEY, 'D');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- *******************
  -- 1. 재고 삭제
  -- 2. 입고상세이력 삭제
  -- 3. 입고이력 삭제
  -- 4. 재고상세이력 삭제
  -- 5. 재고이력 삭제
  -- *******************

  -- 재고 삭제
  DELETE COMLOT
    FROM COMLOT
    INNER JOIN COMINLOT
       ON COMLOT.LOTKEY  = COMINLOT.LOTKEY
      AND COMLOT.WARECD  = COMINLOT.WARECD
    INNER JOIN COMIN
       ON COMINLOT.INKEY = COMIN.INKEY
    WHERE COMIN.MTRINKEY = $MTRINKEY;

  -- 재고상세이력 삭제
  DELETE COMINLOT
    FROM COMINLOT
    INNER JOIN COMIN ON COMINLOT.INKEY = COMIN.INKEY
    WHERE COMIN.MTRINKEY = $MTRINKEY;

  -- 재고이력 삭제
  DELETE FROM COMIN
    WHERE MTRINKEY = $MTRINKEY;

  -- 입고상세이력 삭제
  DELETE FROM MTRINLOT
    WHERE MTRINKEY = $MTRINKEY;

  -- 입고이력 삭제
  DELETE FROM MTRIN
    WHERE MTRINKEY = $MTRINKEY;

 -- ****************************************************************************
END IF; END