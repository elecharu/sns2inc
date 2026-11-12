CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`IO_COMCHKLOT_ADD`(
-- *****************************************************************************
-- Comment: 실사그룹로트 실사수량 등록 프로시저 (PDA·태블릿)
-- Create: 	2024-11-21  	생성 			이대규
-- Modify: 	2026-11-11 					한성수	SNS2 마이그레이션 (품목 ITEMID 기준)
-- *****************************************************************************
  IN $CHKGROUPKEY   VARCHAR(20),
  IN $LOTKEY        VARCHAR(100),
  IN $CHKQTY        DECIMAL(20, 8)
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$WARECD    VARCHAR(100);
  DECLARE _$ITEMID    VARCHAR(100);
  DECLARE _$CHKKEY    VARCHAR(20);
-- *****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- *****************************************************************************
-- <실사그룹로트 등록 순서>
-- 1_1. 실사지시 품목의 로트인지, 이미 실사등록한 로트인지 확인
-- 1_2. COMCHKLOT 실사수량·스캔시간·스캔자 저장
-- *****************************************************************************
  IF NOT EXISTS (SELECT LOTKEY FROM COMLOT WHERE LOTKEY = $LOTKEY) THEN
    CALL COMERR('존재하지 않는 로트번호입니다.');
    LEAVE PROC;
  END IF;

  IF $CHKGROUPKEY = '' THEN
    CALL COMERR('실사그룹키가 없습니다.');
    LEAVE PROC;
  END IF;

  IF $LOTKEY = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 1_1. 실사지시 품목의 로트인지, 이미 실사등록한 로트인지 확인
  SET _$WARECD = IFNULL((SELECT CHKWARECD FROM COMCHK_GROUP WHERE CHKGROUPKEY = $CHKGROUPKEY), '');

  IF _$WARECD = '' THEN
    CALL COMERR('창고코드가 없습니다.');
    LEAVE PROC;
  END IF;

  SET _$ITEMID = IFNULL((SELECT ITEMID FROM COMLOT WHERE LOTKEY = $LOTKEY AND WARECD = _$WARECD), '');

  IF _$ITEMID <> '' THEN
    IF NOT EXISTS (SELECT CHKKEY FROM COMCHK WHERE CHKGROUPKEY = $CHKGROUPKEY AND CHKITEMCD = _$ITEMID) THEN
      CALL COMERR(CONCAT('실사품목에 속하지 않는 품목의 LOT입니다. ', $LOTKEY));
      LEAVE PROC;
    END IF;
  END IF;

  SET _$CHKKEY = (SELECT CHKKEY FROM COMCHK WHERE CHKGROUPKEY = $CHKGROUPKEY AND CHKITEMCD = _$ITEMID);

  IF (SELECT CHKSCANTIME FROM COMCHKLOT WHERE CHKKEY = _$CHKKEY AND CHKLOTKEY = $LOTKEY) != '' THEN
    CALL COMERR('이미 실사등록 하셨습니다.');
    LEAVE PROC;
  END IF;

  -- 1_2. COMCHKLOT 실사수량·스캔시간·스캔자 저장
  UPDATE COMCHKLOT
     SET LOTCHKQTY = $CHKQTY, CHKSCANTIME = CALLTIME(), CHKSCANEMP = CALLEMP(),
         MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG()
   WHERE CHKKEY = _$CHKKEY
     AND CHKLOTKEY = $LOTKEY;
-- *****************************************************************************
END IF;
END
