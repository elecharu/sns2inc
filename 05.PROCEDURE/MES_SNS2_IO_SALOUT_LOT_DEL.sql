CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_SALOUT_LOT_DEL(
-- *****************************************************************************
-- Comment: 출하 삭제 (확정 출하 1건 재고 복원 후 삭제) - TML5000_R01 출하내역삭제 탭
--          IO_SALOUT_LOT(출고확정)의 반대. 출고구분 01·011(이 화면 출하)과 31(옛 외주처 판매출고) 모두 처리
-- Create: 2026-11-19
-- *****************************************************************************
  IN $SALOUTKEY  VARCHAR(20)      -- 출하번호 (확정 OUTYN = 'Y')
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$WARECD   VARCHAR(100);
  DECLARE _$OUTTP    VARCHAR(10);
-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************
-- <출하 삭제 순서>
-- 1. 확정 출하 확인
-- 2. ERP 인터페이스 삭제 송신 (이 화면에서 만든 출하 01·011 만 - 옛 외주처 판매출고 31 은 송신한 적 없음)
-- 3. COMLOT 재고 복원 (출고창고의 그 LOT)
-- 4. COMOUTLOT / COMOUT 삭제
-- 5. SALOUTLOT / SALOUT 삭제
-- ****************************************************************************

  -- 1. 확정 출하 확인
  IF IFNULL($SALOUTKEY, '') = '' THEN
    CALL COMERR('출하번호가 없습니다. (IO_SALOUT_LOT_DEL)');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY AND SALOUT.OUTYN = 'Y') THEN
    CALL COMERR('삭제할 출하가 없습니다.');
    LEAVE PROC;
  END IF;

  SET _$WARECD = (SELECT SALOUT.WARECD FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY);
  SET _$OUTTP = (SELECT MAX(COMOUT.OUTTP) FROM COMOUT WHERE COMOUT.SALOUTKEY = $SALOUTKEY);

  -- 2. ERP 인터페이스 (출하LOT : D) - 삭제 전에 보내야 출하 정보를 읽을 수 있음
  IF IFNULL(_$OUTTP, '') IN ('01', '011') THEN
    CALL IO_ERP_INTERFACE('SALOUTLOT', $SALOUTKEY, 'D');

    IF IFNULL(@ERRMSG, '') <> '' THEN
      LEAVE PROC;
    END IF;
  END IF;

  -- 3. 재고 복원
  UPDATE COMLOT
  INNER JOIN SALOUTLOT ON SALOUTLOT.LOTKEY = COMLOT.LOTKEY
     SET COMLOT.LOTQTY = COMLOT.LOTQTY + SALOUTLOT.LOTQTY
       , COMLOT.MTIME  = CALLTIME()
       , COMLOT.MEMP   = CALLEMP()
       , COMLOT.MPRG   = CALLPRG()
   WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
     AND COMLOT.WARECD = _$WARECD;

  -- 4. 출고 이력 삭제
  DELETE FROM COMOUTLOT
   WHERE COMOUTLOT.OUTKEY IN (SELECT COMOUT.OUTKEY FROM COMOUT WHERE COMOUT.SALOUTKEY = $SALOUTKEY);
  DELETE FROM COMOUT WHERE COMOUT.SALOUTKEY = $SALOUTKEY;

  -- 5. 출하 삭제
  DELETE FROM SALOUTLOT WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY;
  DELETE FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY;

-- ****************************************************************************
END IF; END
