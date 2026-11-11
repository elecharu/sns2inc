CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_ETC_OUT_DEL(
-- *****************************************************************************
-- Comment: 기타출고이력 삭제 프로시저
-- Create: 2024-11-21: 이대규
-- Modify: 
-- ***************************************************************************** 
 IN $LOTKEYLIST     MEDIUMTEXT,
 IN $OUTKEYLIST      MEDIUMTEXT
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
 DECLARE _$LOTKEY  VARCHAR(100);   
 DECLARE _$OUTKEY   VARCHAR(100);  
 DECLARE _$WARECD  VARCHAR(100);   
 DECLARE _$OUTQTY   DECIMAL(20,8);
 DECLARE _$ITEMID  VARCHAR(100);
 DECLARE _$OUTDATE   VARCHAR(100);    
 DECLARE _$ITEMCG   VARCHAR(100); 
 DECLARE _$SUM_OUTQTY   DECIMAL(20,8);  
-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************
-- <기타입고 이력삭제 순서 > 
-- 1. 기타입고이력 삭제 
-- 1_1. COMLOT 원복
-- 1_2. COMOUTLOT 삭제
-- 1_3. COMOUT 수정 or 삭제
-- ****************************************************************************
  
  IF $LOTKEYLIST = '' THEN
    CALL COMERR('삭제할 이력을 선택하세요.');
    LEAVE PROC;
  END IF;

  WHILE LENGTH($LOTKEYLIST) > 0 DO
    CALL COMSPLIT($LOTKEYLIST, _$LOTKEY);
    CALL COMSPLIT($OUTKEYLIST, _$OUTKEY);
  
    IF _$LOTKEY = '' THEN
      CALL COMERR('로트번호가 없습니다.');
      LEAVE PROC;
    END IF;

    IF _$OUTKEY = '' THEN
      CALL COMERR('출고키가 없습니다.');
      LEAVE PROC;
    END IF;

    SET _$WARECD = IFNULL((SELECT COMOUT.WARECD FROM COMOUT INNER JOIN COMOUTLOT ON COMOUT.OUTKEY = COMOUTLOT.OUTKEY
                                                            WHERE COMOUT.OUTKEY = _$OUTKEY AND COMOUTLOT.LOTKEY = _$LOTKEY), '');
    SET _$OUTQTY  = IFNULL((SELECT OUTQTY FROM COMOUTLOT WHERE OUTKEY = _$OUTKEY AND LOTKEY = _$LOTKEY), 0);
    SET _$ITEMID = IFNULL((SELECT COMOUT.ITEMID FROM COMOUT INNER JOIN COMOUTLOT ON COMOUT.OUTKEY = COMOUTLOT.OUTKEY 
                                                            WHERE COMOUT.OUTKEY = _$OUTKEY AND COMOUTLOT.LOTKEY = _$LOTKEY), '');
    SET _$ITEMCG = IFNULL((SELECT ITEMCG FROM MSTITEM WHERE ITEMID = _$ITEMID), '');
    SET _$OUTDATE = IFNULL((SELECT OUTDATE FROM COMOUT WHERE OUTKEY = _$OUTKEY), '');

    IF _$WARECD = '' THEN
      CALL COMERR('출고창고가 없습니다.');
      LEAVE PROC;
    END IF;

    IF _$ITEMID = '' THEN
      CALL COMERR('품목코드가 없습니다.');
      LEAVE PROC;
    END IF;

    IF NOT EXISTS (SELECT LOTKEY FROM COMLOT WHERE WARECD = _$WARECD AND LOTKEY = _$LOTKEY) THEN
      CALL COMERR(CONCAT('창고에 로트가 없습니다.\n', GPCD('WARECD', _$WARECD), '\n', _$LOTKEY));
      LEAVE PROC;
    END IF;

-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- 1-1. COMLOT 원복
    UPDATE COMLOT 
    SET LOTQTY = LOTQTY + _$OUTQTY
      , MTIME  = CALLTIME()
      , MEMP   = CALLEMP()
      , MPRG   = CALLPRG()
    WHERE WARECD = _$WARECD 
      AND LOTKEY = _$LOTKEY;
-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- 1-2. COMOUTLOT 삭제
    DELETE FROM COMOUTLOT WHERE OUTKEY = _$OUTKEY AND LOTKEY = _$LOTKEY;

-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- 1-3. COMOUT 수정 or 삭제

    DELETE FROM COMOUT WHERE OUTKEY = _$OUTKEY;

  END WHILE;

-- ****************************************************************************
END IF; END