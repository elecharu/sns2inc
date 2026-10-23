CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.LOT1002_R01(
-- *****************************************************************************
-- Comment: 재고 기타입고 등록
-- Create: 2026-09-02 : 11:46 : 김영철
-- Modify: 
-- *****************************************************************************
  IN $FACTORYCD    VARCHAR(20),
  IN $COMPANYCD    VARCHAR(20),
  IN $ITEMCG       VARCHAR(100),
  IN $ITEMID       VARCHAR(50),
  IN $INDATE      VARCHAR(10),
  IN $INTP        VARCHAR(20),
  IN $EMPCD        VARCHAR(20),
  IN $REMARK       VARCHAR(100), 
  
  IN $LOTKEYLIST   MEDIUMTEXT,
  IN $INQTYLIST   MEDIUMTEXT,
  IN $ITEMID_LIST   MEDIUMTEXT,

-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC:  BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC  
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************  
 DECLARE _$WARETP   VARCHAR(20);
-- ****************************************************************************
CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_ITEM' THEN 
  
  SELECT 
      CAST(A.ITEMID AS CHAR) AS ITEMID
    , ITEMCG
    , ITEMCD
    , EONO
    , ITEMSPEC
    , ITEMNM
    , ITEMSRC    
  FROM MSTITEM AS A 
  INNER JOIN MSTITEM_FACTORY AS B ON A.ITEMID = B.ITEMID
  WHERE A.ITEMID LIKE CONCAT($ITEMID, '%')
    AND A.ITEMCG LIKE CONCAT($ITEMCG, '%')
    AND B.FACTORYCD = '07'
  ORDER BY A.ITEMCG, A.ITEMID, A.ITEMCD;

-- * ***************************************************************************
WHEN 'LIST_COMLOT_LOTLIST' THEN   
  -- 품목별 로트리스트 조회 
  SELECT                                        
      LOTKEY AS LOTKEY                         -- 로트번호
    , LOTQTY AS LOTQTY                       -- 로트수량    
    , MSTITEM.ITEMUNIT
    , PRDDATE AS PRDDATE                     -- 생산일자
  FROM COMLOT
  INNER JOIN MSTITEM ON COMLOT.ITEMID = MSTITEM.ITEMID
  WHERE COMLOT.ITEMID = $ITEMID
    AND LOTQTY > 0
  ORDER BY COMLOT.RTIME;
  
-- * ***************************************************************************
WHEN 'ETC_IN' THEN  

  CALL IO_ETC_IN($INDATE, $INTP, $EMPCD, $REMARK, $LOTKEYLIST, $INQTYLIST, $ITEMID_LIST);   

-- ****************************************************************************
WHEN 'INFO_ITEM' THEN -- 사용자가 입력한 품번의 품목코드, 품명 리턴 

  SELECT 
      CAST(ITEMID AS CHAR) AS ITEMID
    , ITEMCD
    , ITEMNM
    , ITEMCG
    , ITEMSPEC
  FROM MSTITEM
  WHERE ITEMID = $ITEMID;

-- * ***************************************************************************
END CASE;  END