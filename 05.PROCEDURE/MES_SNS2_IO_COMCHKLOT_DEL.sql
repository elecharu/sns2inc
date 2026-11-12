CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`IO_COMCHKLOT_DEL`(
-- *****************************************************************************
-- Comment: 실사그룹로트 실사등록 취소 프로시저 (PDA·태블릿)
-- Create: 	2024-11-21  	생성 			이대규
-- Modify: 	2026-11-11 					한성수	SNS2 마이그레이션
-- *****************************************************************************
  IN $CHKKEY        VARCHAR(20),
  IN $LOTKEY        VARCHAR(100)
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$WARECD        VARCHAR(100);
  DECLARE _$CHKGROUPKEY   VARCHAR(20);
-- *****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- *****************************************************************************
-- <실사그룹로트 실사등록 취소 순서>
-- 1_1. 창고정보 확인
-- 1_2. COMCHKLOT 실사수량 0, 스캔시간·스캔자 초기화
-- *****************************************************************************
  IF $CHKKEY = '' THEN
    CALL COMERR('실사키가 없습니다.');
    LEAVE PROC;
  END IF;

  IF $LOTKEY = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 1_1. 창고정보 확인
  SET _$CHKGROUPKEY = (SELECT CHKGROUPKEY FROM COMCHK WHERE CHKKEY = $CHKKEY);
  SET _$WARECD = IFNULL((SELECT CHKWARECD FROM COMCHK_GROUP WHERE CHKGROUPKEY = _$CHKGROUPKEY), '');

  IF _$WARECD = '' THEN
    CALL COMERR('창고코드가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 1_2. COMCHKLOT 실사수량 0, 스캔시간·스캔자 초기화
  UPDATE COMCHKLOT
     SET LOTCHKQTY = 0, CHKSCANTIME = '', CHKSCANEMP = '',
         MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG()
   WHERE CHKKEY = $CHKKEY
     AND CHKLOTKEY = $LOTKEY;
-- *****************************************************************************
END IF;
END
