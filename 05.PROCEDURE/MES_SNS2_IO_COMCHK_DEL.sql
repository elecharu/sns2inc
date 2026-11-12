CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`IO_COMCHK_DEL`(
-- *****************************************************************************
-- Comment: 재고실사품목 삭제 프로시저
-- Create: 	2024-11-21  	생성 			이대규
-- Modify: 	2026-11-11 					한성수	SNS2 마이그레이션
-- *****************************************************************************
  IN $CHKGROUPKEY   VARCHAR(20),
  IN $CHKKEYLIST    MEDIUMTEXT
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$CHKKEY    VARCHAR(20);
-- *****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- *****************************************************************************
-- <재고실사품목 삭제 순서>
-- 1_1. COMCHK, COMCHKLOT 삭제
-- 1_2. 실사품목이 모두 삭제되면 COMCHK_GROUP 삭제
-- *****************************************************************************
  IF $CHKGROUPKEY = '' THEN
    CALL COMERR('실사그룹키가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 1_1. COMCHK, COMCHKLOT 삭제
  WHILE LENGTH($CHKKEYLIST) > 0 DO
    CALL COMSPLIT($CHKKEYLIST, _$CHKKEY);

    IF _$CHKKEY = '' THEN
      CALL COMERR('실사키가 없습니다.');
      LEAVE PROC;
    END IF;

    IF (SELECT CHKAPPYN FROM COMCHK WHERE CHKKEY = _$CHKKEY) = 'Y' THEN
      CALL COMERR('승인된 실사는 삭제할 수 없습니다.');
      LEAVE PROC;
    END IF;

    DELETE FROM COMCHK WHERE CHKKEY = _$CHKKEY;
    DELETE FROM COMCHKLOT WHERE CHKKEY = _$CHKKEY;
  END WHILE;

  -- 1_2. 실사품목이 모두 삭제되면 COMCHK_GROUP 삭제
  IF NOT EXISTS (SELECT CHKKEY FROM COMCHK WHERE CHKGROUPKEY = $CHKGROUPKEY) THEN
    DELETE FROM COMCHK_GROUP WHERE CHKGROUPKEY = $CHKGROUPKEY;
  END IF;
-- *****************************************************************************
END IF;
END
