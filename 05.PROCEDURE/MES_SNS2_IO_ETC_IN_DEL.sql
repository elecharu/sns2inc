CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_ETC_IN_DEL(
-- *****************************************************************************
-- Comment: 기타입고이력 삭제 프로시저
-- Create: 2024-11-21: 이대규
-- Modify: 
-- ***************************************************************************** 
 IN $LOTKEYLIST     MEDIUMTEXT,
 IN $INKEYLIST      MEDIUMTEXT
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
 DECLARE _$LOTKEY  VARCHAR(100);   
 DECLARE _$INKEY   VARCHAR(100);  
 DECLARE _$WARECD  VARCHAR(100);   
 DECLARE _$WARENM  VARCHAR(1000);   
 DECLARE _$INQTY   DECIMAL(20,8);
 DECLARE _$ITEMID  VARCHAR(100);
 DECLARE _$INDATE   VARCHAR(100);    
 DECLARE _$ITEMCG   VARCHAR(100); 
 DECLARE _$SUM_INQTY   DECIMAL(20,8);  
-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************
-- <기타입고 이력삭제 순서 > 
-- 1. 기타입고이력 삭제 
-- 1_1. COMLOT 원복
-- 1_2. COMINLOT 삭제
-- 1_3. COMIN 수정 or 삭제
-- ****************************************************************************

  IF $LOTKEYLIST = '' THEN
    CALL COMERR('삭제할 이력을 선택하세요.');
    LEAVE PROC;
  END IF;

  WHILE LENGTH($LOTKEYLIST) > 0 DO
    CALL COMSPLIT($LOTKEYLIST, _$LOTKEY);
    CALL COMSPLIT($INKEYLIST, _$INKEY);
  
    IF _$LOTKEY = '' THEN
      CALL COMERR('로트번호가 없습니다.');
      LEAVE PROC;
    END IF;

    IF _$INKEY = '' THEN
      CALL COMERR('입고키가 없습니다.');
      LEAVE PROC;
    END IF;

    SET _$WARECD = IFNULL((SELECT COMIN.WARECD FROM COMIN INNER JOIN COMINLOT ON COMIN.INKEY = COMINLOT.INKEY 
                                                          WHERE COMIN.INKEY = _$INKEY AND COMINLOT.LOTKEY = _$LOTKEY), '');
   
    SET _$INQTY  = IFNULL((SELECT INQTY FROM COMINLOT WHERE INKEY = _$INKEY AND LOTKEY = _$LOTKEY), 0);
    SET _$ITEMID = IFNULL((SELECT COMIN.ITEMID FROM COMIN INNER JOIN COMINLOT ON COMIN.INKEY = COMINLOT.INKEY 
                                                          WHERE COMIN.INKEY = _$INKEY AND COMINLOT.LOTKEY = _$LOTKEY), '');
    SET _$ITEMCG = IFNULL((SELECT ITEMCG FROM MSTITEM WHERE ITEMID = _$ITEMID), '');
    SET _$INDATE = IFNULL((SELECT INDATE FROM COMIN WHERE INKEY = _$INKEY), '');

    SET _$WARENM  = IFNULL((SELECT WARENM FROM MSTWARE WHERE WARECD = _$WARECD), '');

    IF _$WARECD = '' THEN
      CALL COMERR('입고창고가 없습니다.');
      LEAVE PROC;
    END IF;

    IF _$ITEMID = '' THEN
      CALL COMERR('품목ID가 없습니다.');
      LEAVE PROC;
    END IF;

    IF NOT EXISTS (SELECT LOTKEY FROM COMLOT WHERE WARECD = _$WARECD AND LOTKEY = _$LOTKEY) THEN
      CALL COMERR(CONCAT('창고에 로트가 없습니다.\n', _$WARENM, '\n', _$LOTKEY));
      LEAVE PROC;
    END IF;

    IF (SELECT LOTQTY FROM COMLOT WHERE WARECD = _$WARECD AND LOTKEY = _$LOTKEY) < _$INQTY  THEN
      CALL COMERR(CONCAT('재고수량이 부족합니다.\n', _$WARENM, '\n', _$LOTKEY));
      LEAVE PROC;
    END IF;    

-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- 1-1. COMLOT 원복
    UPDATE COMLOT 
    SET LOTQTY = LOTQTY - _$INQTY
      , MTIME  = CALLTIME()
      , MEMP   = CALLEMP()
      , MPRG   = CALLPRG()
    WHERE WARECD = _$WARECD 
      AND LOTKEY = _$LOTKEY;

    IF (SELECT LOTQTY FROM COMLOT WHERE WARECD = _$WARECD AND LOTKEY = _$LOTKEY) = 0 THEN
      DELETE FROM COMLOT WHERE LOTKEY = _$LOTKEY AND WARECD = _$WARECD;
    END IF;
-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- 1-2. COMINLOT 삭제
    DELETE FROM COMINLOT WHERE INKEY = _$INKEY AND LOTKEY = _$LOTKEY;

-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------   
-- 1-3. COMIN 삭제
    DELETE FROM COMIN WHERE INKEY = _$INKEY;
  END WHILE;

-- ****************************************************************************
END IF; END