CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.MST1001_R03(
-- *****************************************************************************
-- Comment: BOM정보등록
-- Create: 2026-09-10 10:10: 김영철 
-- *****************************************************************************
  IN $COMPANYCD VARCHAR(100),     
  IN $ITEMCG VARCHAR(100),     
  IN $ITEMID VARCHAR(100),      -- '품목ID'
  IN $ITEMCD VARCHAR(100),      -- '품목코드'
  IN $USEYN VARCHAR(1),      

-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  CASE $CALLTYPE
-- ****************************************************************************
  WHEN 'SEL_BOM' THEN
   IF $COMPANYCD = '' THEN 
      CALL COMERR('법인을 선택하십시오.');
      LEAVE PROC;
   END IF; 

   IF $ITEMCG = '' THEN 
      CALL COMERR('품목분류을 선택하십시오.');
      LEAVE PROC;
   END IF; 

    SELECT
      B.COMPANYCD,
      CAST(A.MITEMID AS CHAR) AS MITEMID, 
      B.ITEMCD AS MITEMCD, B.ITEMNM AS MITEMNM, B.ITEMCG AS MITEMCG,
      A.CITEMID, 
      C.ITEMCD AS CITEMCD, C.ITEMNM AS CITEMNM, C.ITEMCG AS CITEMCG,
      A.REGID, A.PRCSEQ, A.PRCCD, MSTPRC.PRCNM, MSTPRC.FACTORYCD,
      A.MUSAGE, A.LUSAGE, A.CUSAGE, A.BOMUNIT, 
      A.SRC_BC, A.USE_BC, A.PRCCD, A.USEFRDT, 
      A.USETODT, A.DRAWNO, A.ECONO, A.USEYN,
      A.REMARK, A.REMP, A.RTIME
    FROM MSTBOM AS A
    INNER JOIN MSTITEM AS B ON A.MITEMID = B.ITEMID
    INNER JOIN MSTITEM AS C ON A.CITEMID = C.ITEMID
    LEFT JOIN MSTPRC
      ON MSTPRC.PRCCD = A.PRCCD
    WHERE B.COMPANYCD = $COMPANYCD
      AND B.ITEMCG = $ITEMCG
      AND B.ITEMCD LIKE CONCAT('%', $ITEMCD, '%')
      AND A.USEYN = $USEYN
    ORDER BY B.COMPANYCD, B.ITEMCG, B.ITEMID, B.ITEMCD, C.ITEMCD, A.PRCSEQ, A.USEYN;

-- ****************************************************************************
  END CASE;
END