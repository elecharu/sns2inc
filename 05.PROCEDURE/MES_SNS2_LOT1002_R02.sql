CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.LOT1002_R02(
-- *****************************************************************************
-- Comment: 재고 기타출고 등록
-- Create: 2026-09-02 : 11:47 : 김영철
-- Modify:  
-- *****************************************************************************
  IN $WARECD       VARCHAR(20),
  IN $ITEMCG       VARCHAR(20),
  IN $ITEMID       VARCHAR(50),
  IN $OUTDATE      VARCHAR(10),
  IN $OUTTP        VARCHAR(20),
  IN $EMPCD        VARCHAR(20),
  IN $REMARK       VARCHAR(100), 
  
  IN $LOTKEYLIST   MEDIUMTEXT,
  IN $OUTQTYLIST   MEDIUMTEXT,

  IN $SDATE       VARCHAR(10),
  IN $EDATE       VARCHAR(10),
-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC:  BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC  
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************  

-- ****************************************************************************
CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_COMLOT_ITEM' THEN 

  SELECT 
    MSTITEM.ITEMID,
    COMLOT.WARECD,                              -- 창고코드
    GPCD('WARECD', COMLOT.WARECD) AS WARENM,    -- 창고명
    MSTITEM.ITEMCG,                             -- 품목유형   
    MSTITEM.ITEMCD,                             -- 품목코드
    MSTITEM.ITEMNM,                             -- 품번
    SUM(COMLOT.LOTQTY) AS LOTQTY                -- 재고 
  FROM COMLOT
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = COMLOT.ITEMID
  INNER JOIN MSTITEM_FACTORY ON MSTITEM.ITEMID = MSTITEM_FACTORY.ITEMID
  WHERE MSTITEM.ITEMID   LIKE CONCAT($ITEMID, '%')
    AND IF($ITEMCG= '', 1=1, MSTITEM.ITEMCG = $ITEMCG)
    AND MSTITEM_FACTORY.FACTORYCD = '07'
  GROUP BY MSTITEM.ITEMID
  ORDER BY COMLOT.WARECD, MSTITEM.ITEMCG, MSTITEM.ITEMCD;

-- * ***************************************************************************
WHEN 'LIST_COMLOT_LOTLIST' THEN   
  -- 품목별 로트리스트 조회 
   SELECT                                        -- 생산일자 부분 정확한 컬럼 필요
    LOTKEY,                         -- 로트번호
    LOTQTY                          -- 로트수량    
  FROM COMLOT 
  WHERE ITEMID = $ITEMID
    AND LOTQTY > 0                            -- 로트수량이 하나 이상인것만 조회되도록.
  ORDER BY RTIME;

-- * ***************************************************************************
WHEN 'ETC_OUT' THEN  

  CALL IO_ETC_OUT($ITEMID, $OUTDATE, $OUTTP, $EMPCD, $REMARK, $LOTKEYLIST, $OUTQTYLIST);   

-- * ***************************************************************************
END CASE;  END