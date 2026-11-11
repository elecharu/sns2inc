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
  IN $WARECD      VARCHAR(100),   -- 입고창고
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
    , ITEMSPEC
    , ITEMNM
    , IFNULL(STOCK.SUMQTY, 0) AS SUMQTY        -- 현재고 (2공장 창고)
  FROM MSTITEM AS A
  INNER JOIN MSTITEM_FACTORY AS B ON A.ITEMID = B.ITEMID
  LEFT JOIN (
              SELECT
                  COMLOT.ITEMID
                , SUM(COMLOT.LOTQTY) AS SUMQTY
              FROM COMLOT
              INNER JOIN MSTWARE
                ON MSTWARE.WARECD = COMLOT.WARECD
               AND MSTWARE.FACTORYCD = '07'
              WHERE COMLOT.LOTQTY > 0
              GROUP BY COMLOT.ITEMID
            ) AS STOCK  -- 품목별 현재고
    ON STOCK.ITEMID = A.ITEMID
  WHERE A.ITEMID LIKE CONCAT($ITEMID, '%')
    AND A.ITEMCG LIKE CONCAT($ITEMCG, '%')
    AND B.FACTORYCD = '07'
    AND A.ENDYN != 'Y'
  ORDER BY A.ITEMCG, A.ITEMID, A.ITEMCD;

-- * ***************************************************************************
WHEN 'LIST_COMLOT_LOTLIST' THEN   
  -- 품목별 로트리스트 조회 
  SELECT                                        
      LOTKEY AS LOTKEY                         -- 로트번호
    , COMLOT.WARECD                          -- 창고코드
    , IFNULL(MSTWARE.WARENM, '') AS WARENM   -- 창고명
    , LOTQTY AS LOTQTY                       -- 로트수량
    , MSTITEM.ITEMUNIT
    , PRDDATE AS PRDDATE                     -- 생산일자
  FROM COMLOT
  INNER JOIN MSTITEM ON COMLOT.ITEMID = MSTITEM.ITEMID
  LEFT JOIN MSTWARE ON MSTWARE.WARECD = COMLOT.WARECD
  WHERE COMLOT.ITEMID = $ITEMID
    AND LOTQTY > 0
  ORDER BY COMLOT.RTIME;
  
-- * ***************************************************************************
WHEN 'ETC_IN' THEN

  IF IFNULL($WARECD, '') = '' THEN
    CALL COMERR('입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  CALL IO_ETC_IN($INDATE, $INTP, $EMPCD, $REMARK, $LOTKEYLIST, $INQTYLIST, $ITEMID_LIST, $WARECD);

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