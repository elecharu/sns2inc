CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD4001_S01(
-- *****************************************************************************
-- Comment: 재고조회
-- Create: 2026-08-31 13:56 : 김영철 
-- Modify: 
-- *****************************************************************************

 IN $COMPANYCD VARCHAR(20),   -- 법인
 IN $ITEMID VARCHAR(20),      -- 품목ID
 IN $WARECD VARCHAR(25),      -- 창고코드
 IN $PRCCD VARCHAR(25),       -- 공정코드
 IN $LOTKEY VARCHAR(20),      -- LOT번호
 IN $ITEMCG VARCHAR(10),      -- 품목유형
 IN $FACTORYCD VARCHAR(10),   -- 공장
 IN $CONDITION VARCHAR(1),    -- 안전재고확인 

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
    , ITEM.ITEMID
    , ITEM.ITEMCG
    , SAFT.FACTORYCD
    , ITEM.ITEMCD
    , ITEM.ITEMNM
    , ITEM.ITEMUNIT
    , ITEM.ITEMSPEC
    , IFNULL(LOT.LOTQTY, 0)               AS LOTQTY
    , IFNULL(SAFT.SAFEQTY, 0)             AS SAFEQTY
    , IFNULL(SAFT.STDQTY, 0)              AS STDQTY
    , CASE
        WHEN IFNULL(LOT.LOTQTY, 0) < IFNULL(SAFT.SAFEQTY, 0)
         AND IFNULL(SAFT.SAFEQTY, 0) <> 0
        THEN 'PINK'
        ELSE ''
      END                                 AS BACKGROUND
  FROM MSTITEM AS ITEM
  INNER JOIN MSTITEM_FACTORY AS SAFT
          ON SAFT.ITEMID = ITEM.ITEMID
  INNER JOIN (
          SELECT
                WARECD
              , ITEMID
              , SUM(LOTQTY) AS LOTQTY
          FROM COMLOT
          WHERE ($WARECD = '' OR WARECD LIKE CONCAT('%', $WARECD, '%'))
            AND ($LOTKEY = '' OR LOTKEY LIKE CONCAT('%', $LOTKEY, '%'))
          GROUP BY WARECD, ITEMID
  ) AS LOT
          ON LOT.ITEMID = ITEM.ITEMID
  WHERE ($FACTORYCD = '' OR SAFT.FACTORYCD LIKE CONCAT('%', $FACTORYCD, '%'))
    AND ($ITEMCG    = '' OR ITEM.ITEMCG    LIKE CONCAT('%', $ITEMCG, '%'))
    AND ($KEYWORD   = '' OR ITEM.EONO      LIKE CONCAT('%', $KEYWORD, '%'))
    AND ($ITEMID    = '' OR ITEM.ITEMID    LIKE CONCAT('%', $ITEMID, '%'))
    AND (
          $CONDITION <> 'Y'
          OR (
                IFNULL(LOT.LOTQTY, 0) < IFNULL(SAFT.SAFEQTY, 0)
            AND IFNULL(SAFT.SAFEQTY, 0) <> 0
          )
        )
    AND ITEM.ENDYN = 'N'
    AND IFNULL(LOT.LOTQTY, 0) > 0
  ORDER BY LOT.WARECD
         , ITEM.ITEMCG
         , SAFT.FACTORYCD
         , ITEM.ITEMCD
   ;
      
-- -- *****************************************************************************
WHEN 'INFO_COMLOT' THEN

  SELECT 
      COMLOT.LOTKEY
    , COMLOT.LOTQTY
    , MSTWARE.WARENM AS WARECD
    , COMLOT.RTIME
    FROM COMLOT
    LEFT JOIN MSTWARE
      ON MSTWARE.WARECD = COMLOT.WARECD
    WHERE COMLOT.ITEMID = $ITEMID
      AND COMLOT.WARECD = $WARECD
      AND COMLOT.LOTQTY > 0;

-- *****************************************************************************
END CASE;  END