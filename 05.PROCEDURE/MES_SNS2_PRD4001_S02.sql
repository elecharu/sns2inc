CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD4001_S02(
-- *****************************************************************************
-- Comment: 로트별 재고조회
-- Create: 2026-09-01 11:29 : 김영철 
-- Modify: 
-- *****************************************************************************

 IN $COMPANYCD VARCHAR(20),   -- 법인
 IN $ITEMID VARCHAR(20),      -- 품목ID
 IN $WARECD VARCHAR(25),      -- 창고코드
 IN $PRCCD VARCHAR(25),       -- 공정코드
 IN $LOTKEY VARCHAR(20),      -- LOT번호
 IN $ITEMCG VARCHAR(10),      -- 품목유형
 IN $FACTORYCD VARCHAR(10),   -- 공장

-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC:  BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC  
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
CASE $CALLTYPE
-- *****************************************************************************
WHEN 'LIST_COMLOT' THEN

  SELECT 
      LOT.WARECD
    , GPCD('WARECD', LOT.WARECD) AS WARENM
    , ITEM.ITEMCG
    , ITEM.ITEMCD
    , ITEM.ITEMNM
    , ITEM.ITEMSPEC
    , LOT.LOTKEY
    , LOT.LOTQTY
    , ITEM.ITEMUNIT
    , MSTITEM_FACTORY.FACTORYCD
    FROM COMLOT AS LOT
    INNER JOIN MSTITEM AS ITEM ON LOT.ITEMID = ITEM.ITEMID
    INNER JOIN MSTITEM_FACTORY
      ON MSTITEM_FACTORY.ITEMID = ITEM.ITEMID
    WHERE ($FACTORYCD = '' OR MSTITEM_FACTORY.FACTORYCD LIKE CONCAT('%', $FACTORYCD, '%'))
      AND ($ITEMCG    = '' OR ITEM.ITEMCG    LIKE CONCAT('%', $ITEMCG, '%'))
      AND ($KEYWORD   = '' OR ITEM.EONO      LIKE CONCAT('%', $KEYWORD, '%'))
      AND ($ITEMID    = '' OR ITEM.ITEMID    LIKE CONCAT('%', $ITEMID, '%'))
      AND ($WARECD    = '' OR LOT.WARECD    LIKE CONCAT('%', $WARECD, '%'))
      AND ITEM.ENDYN = 'N'
      AND LOT.LOTQTY > 0
    ORDER BY LOT.WARECD, ITEM.ITEMCG, MSTITEM_FACTORY.FACTORYCD, ITEM.ITEMCD, LOT.LOTKEY;

-- *****************************************************************************
END CASE;  END