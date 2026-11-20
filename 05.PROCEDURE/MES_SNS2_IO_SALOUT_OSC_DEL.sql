CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_SALOUT_OSC_DEL(
-- *****************************************************************************
-- Comment: 외주처 판매출고 출하취소 프로시저 (출고구분 31 확정 출하 1건)
-- Create: 2026-10-26 17:02:      TML5000_R02 DEL_SALOUT 에서 분리
-- Modify:
-- *****************************************************************************
  IN $SALOUTKEY  VARCHAR(20)      -- 출하번호 (확정 OUTYN = 'Y')
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$OUTKEY   VARCHAR(20);
-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************
-- <외주처 판매출고 취소 순서>
-- 1. 확정 출하 확인
-- 2. COMLOT 재고 복원
-- 3. COMOUTLOT / COMOUT 삭제
-- 4. SALOUT / SALOUTLOT 삭제
-- ****************************************************************************

  -- 1. 확정 출하 확인
  IF $SALOUTKEY = '' THEN
    CALL COMERR('출하번호가 없습니다. (IO_SALOUT_OSC_DEL)');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY AND SALOUT.OUTYN = 'Y') THEN
    CALL COMERR('취소할 출하가 없습니다.');
    LEAVE PROC;
  END IF;

  SET _$OUTKEY = (SELECT COMOUT.OUTKEY FROM COMOUT
                  WHERE COMOUT.SALOUTKEY = $SALOUTKEY
                    AND COMOUT.OUTTP = '31'
                  LIMIT 1);

  -- 2. 재고 복원
  UPDATE SALOUTLOT
  INNER JOIN COMLOT
    ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
  SET COMLOT.LOTQTY = COMLOT.LOTQTY + SALOUTLOT.LOTQTY
    , COMLOT.MTIME = CALLTIME()
    , COMLOT.MEMP = CALLEMP()
    , COMLOT.MPRG = CALLPRG()
  WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
  ;

  -- 3. 출고 이력 삭제
  DELETE FROM COMOUTLOT WHERE COMOUTLOT.OUTKEY = _$OUTKEY;
  DELETE FROM COMOUT WHERE COMOUT.OUTKEY = _$OUTKEY;

  -- 4. 출하 삭제
  DELETE FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY;
  DELETE FROM SALOUTLOT WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY;

-- ****************************************************************************
END IF; END
