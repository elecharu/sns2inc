CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`IO_COMCHK_ADD`(
-- *****************************************************************************
-- Comment: 재고실사품목 추가 프로시저
-- Create: 	2024-11-21  	생성 			이대규
-- Modify: 	2026-11-11 					한성수	SNS2 마이그레이션 (품목 ITEMID 기준)
-- *****************************************************************************
  IN $CHKDATE       VARCHAR(10),
  IN $WARECD        VARCHAR(100),
  IN $CHKNM         VARCHAR(100),
  IN $ITEMIDLIST    MEDIUMTEXT
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$ITEMID        VARCHAR(100);
  DECLARE _$CHKGROUPKEY   VARCHAR(20);
  DECLARE _$CHKKEY        VARCHAR(20);
-- *****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- *****************************************************************************
-- <재고실사품목 추가 순서>
-- 1_1. COMCHK_GROUP 생성
-- 1_2. COMCHK 생성
-- 1_3. COMCHKLOT 생성
-- 1_4. COMCHKLOT 존재하지 않을 경우, COMCHK 삭제
-- 1_5. COMCHK 존재하지 않을 경우, COMCHK_GROUP 삭제
-- *****************************************************************************
  IF $CHKDATE = '' THEN
    CALL COMERR('실사일자가 비어있습니다.');
    LEAVE PROC;
  END IF;

  IF $WARECD = '' THEN
    CALL COMERR('창고코드가 비어있습니다.');
    LEAVE PROC;
  END IF;

  IF $CHKNM = '' THEN
    CALL COMERR('실사명이 비어있습니다.');
    LEAVE PROC;
  END IF;

  IF $ITEMIDLIST = '' THEN
    CALL COMERR('품목을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 1_1. COMCHK_GROUP 생성
  SET _$CHKGROUPKEY = GETKEY('CHKGROUPKEY');

  INSERT INTO COMCHK_GROUP (CHKGROUPKEY, CHKDATE, CHKWARECD, CHKNM, RTIME, REMP, RPRG)
  VALUES (_$CHKGROUPKEY, $CHKDATE, $WARECD, $CHKNM, CALLTIME(), CALLEMP(), CALLPRG());

  WHILE LENGTH($ITEMIDLIST) > 0 DO
    CALL COMSPLIT($ITEMIDLIST, _$ITEMID);

    IF _$ITEMID = '' THEN
      CALL COMERR('품목ID가 비어있습니다.');
      LEAVE PROC;
    END IF;

    -- 1_2. COMCHK 생성
    SET _$CHKKEY = GETKEY('CHKKEY');

    INSERT INTO COMCHK (CHKKEY, CHKGROUPKEY, CHKITEMCD, RTIME, REMP, RPRG)
    VALUES (_$CHKKEY, _$CHKGROUPKEY, _$ITEMID, CALLTIME(), CALLEMP(), CALLPRG());

    -- 1_3. COMCHKLOT 생성
    INSERT INTO COMCHKLOT (CHKKEY, CHKLOTKEY, LOTOLDQTY, RTIME, REMP, RPRG)
    SELECT _$CHKKEY, LOTKEY, LOTQTY, CALLTIME(), CALLEMP(), CALLPRG()
    FROM COMLOT
    WHERE WARECD = $WARECD
      AND ITEMID = _$ITEMID
      AND LOTQTY > 0;

    -- 1_4. COMCHKLOT 존재하지 않을 경우, COMCHK 삭제
    IF NOT EXISTS (SELECT CHKLOTKEY FROM COMCHKLOT WHERE CHKKEY = _$CHKKEY) THEN
      DELETE FROM COMCHK WHERE CHKKEY = _$CHKKEY;
    END IF;
  END WHILE;

  -- 1_5. COMCHK 존재하지 않을 경우, COMCHK_GROUP 삭제
  IF NOT EXISTS (SELECT CHKKEY FROM COMCHK WHERE CHKGROUPKEY = _$CHKGROUPKEY) THEN
    DELETE FROM COMCHK_GROUP WHERE CHKGROUPKEY = _$CHKGROUPKEY;
  END IF;
-- *****************************************************************************
END IF;
END
