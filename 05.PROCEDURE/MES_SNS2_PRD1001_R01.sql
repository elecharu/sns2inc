CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD1001_R01(
  -- *****************************************************************************
-- Comment: 월간생산계획 등록
-- Create: 2026-09-23 신정수 
-- Modify: 
-- *****************************************************************************
  IN $SMONTH VARCHAR(10),      -- 조회년월
  IN $FACTORYCD VARCHAR(20),   -- 공장코드
  IN $ITEMID INT,              -- 품목번호
  IN $ITEMCD VARCHAR(20),      -- 품목코드 
  
  IN $REG_DATA_VIEW VARCHAR(1),  -- 계획등록건만 보기
-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y'; 
-- *****************************************************************************
  DECLARE _$WORKHOURS DECIMAL(20, 8);
-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_MONTHPLAN' THEN  -- 월생산계획 조회 

  IF EXISTS (SELECT ITEMID FROM PRDPLAN_M WHERE PMONTH = $SMONTH) THEN
    SELECT
        PLAN.ITEMID
      , MSTITEM.ITEMCD
      , MSTITEM.ITEMNM
      , MSTITEM.ITEMSPEC      
      , PLAN.SALFUP
      , PLAN.UPH
      , PLAN.COUNT_LINE
      , PLAN.WORKHOURS
      , PLAN.SUMQTY
      , PLAN.CAPAQTY
      , (PLAN.CAPAQTY * PLAN.SALFUP) AS CAPAAMT
      , PLAN.ODRQTY
      , (PLAN.CAPAQTY * PLAN.ODRQTY) AS ODRQMT
      , PLAN.PLANQTY
      , (PLAN.CAPAQTY * PLAN.PLANQTY) AS PLANQMT
      , IF(PLAN.CAPAQTY = 0, 0, ROUND(PLAN.PLANQTY / PLAN.CAPAQTY * 100, 1)) AS LOADFACTOR -- 부하율 = 월생산계획수량 / 생산CAPA수량 * 100
      , IF(PLAN.UPH = 0, 0, ROUND(PLAN.PLANQTY / (PLAN.UPH * 20), 1)) AS WORKDAYS_EXPECTED  -- 생산계획수량을 만드는데 필요한 근무일수 = 월생산계획수량 / (UPH * 20 hours)
    FROM PRDPLAN_M AS PLAN
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = PLAN.ITEMID
    WHERE PLAN.PMONTH = $SMONTH
    ORDER BY PLAN.ITEMID
    ;
  ELSE
    SET _$WORKHOURS = IFNULL((
                                SELECT
                                  SUM(DAYTIME + NIGHTTIME + OVERTIME_DY + OVERTIME_NT) / 60
                                FROM PRDWORKTIME
                                WHERE LEFT(WORKDATE, 7) = $SMONTH
                             ), 0);    

    SELECT
        RESULT.ITEMID
      , RESULT.ITEMCD
      , RESULT.ITEMNM
      , RESULT.ITEMSPEC
      , RESULT.SALFUP
      , RESULT.UPH
      , RESULT.COUNT_LINE
      , RESULT.WORKHOURS
      , RESULT.SUMQTY
      , RESULT.CAPAQTY
      , RESULT.CAPAAMT
      , RESULT.ODRQTY
      , RESULT.ODRAMT
      , RESULT.PLANQTY
      , RESULT.PLANAMT
      , IF(RESULT.CAPAQTY = 0, 0, ROUND(RESULT.PLANQTY / RESULT.CAPAQTY * 100, 1)) AS LOADFACTOR -- 부하율 = 월생산계획수량 / 생산CAPA수량 * 100
      , IF(RESULT.UPH = 0, 0, ROUND(RESULT.PLANQTY / (RESULT.UPH * 20), 1)) AS WORKDAYS_EXPECTED  -- 생산계획수량을 만드는데 필요한 근무일수 = 월생산계획수량 / (UPH * 20 hours)
    FROM (
            SELECT
                SALODRD.ITEMID
              , MSTITEM.ITEMCD
              , MSTITEM.ITEMNM
              , MSTITEM.ITEMSPEC  
              , SALODRD.SALFUP
              , ITEM_FAC.UPH
              , IFNULL(MEI_ITEM.COUNT_LINE, 0) AS COUNT_LINE
              , _$WORKHOURS AS WORKHOURS
              , IFNULL(COMLOT_ITEM.SUMQTY, 0) AS SUMQTY
              , ITEM_FAC.UPH * _$WORKHOURS AS CAPAQTY
              , (ITEM_FAC.UPH * _$WORKHOURS) * SALODRD.SALFUP AS CAPAAMT
              , SUM(SALODRD.SALQTY) AS ODRQTY
              , SUM(SALODRD.SALQTY) * SALODRD.SALFUP AS ODRAMT
              , SUM(SALODRD.SALQTY) AS PLANQTY
              , SUM(SALODRD.SALQTY) * SALODRD.SALFUP AS PLANAMT
            FROM SALODR
            INNER JOIN SALODRD
            INNER JOIN MSTITEM
              ON MSTITEM.ITEMID = SALODRD.ITEMID
            INNER JOIN MSTITEM_FACTORY AS ITEM_FAC
              ON ITEM_FAC.ITEMID = MSTITEM.ITEMID
            LEFT JOIN (
                        SELECT
                            COMLOT.ITEMID
                          , SUM(COMLOT.LOTQTY) AS SUMQTY
                        FROM COMLOT
                        WHERE COMLOT.WARECD = '04S200_N'  -- 제품창고
                          AND LOTQTY > 0
                        GROUP BY COMLOT.ITEMID
                      ) AS COMLOT_ITEM  -- 제품별 현재고
              ON COMLOT_ITEM.ITEMID = MSTITEM.ITEMID
            LEFT JOIN (
                        SELECT
                            MEI.ITEMID
                          , COUNT(MEI.EQMCD) AS COUNT_LINE
                        FROM MSTLINE_EQM_ITEM AS MEI     
                        GROUP BY MEI.ITEMID
                      ) AS MEI_ITEM -- 제품별 생산라인수 
              ON MEI_ITEM.ITEMID = SALODRD.ITEMID
            WHERE LEFT(SALODR.ODRDATE, 7) = $SMONTH
              AND ITEM_FAC.FACTORYCD = $FACTORYCD -- 수주품목이 2공장
            GROUP BY SALODRD.ITEMID
         ) AS RESULT
    ORDER BY RESULT.ITEMCD
    ;
  END IF;
-- ****************************************************************************
END CASE; END