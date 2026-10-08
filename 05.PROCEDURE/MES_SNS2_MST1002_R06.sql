CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`MST1002_R06`(
-- *****************************************************************************
-- Comment: 설비정보관리
-- Create: 	2024-02-22  	생성 			김영철
-- Modify: 	2026-10-08 					한성수	설비그룹코드(EQMGUBUN) 및 설비그룹명(EQMGRPNM) 컬럼 반환 추가
-- *****************************************************************************

  IN $FACTORYCD VARCHAR(20), 
  IN $EQMTP VARCHAR(20), 
  IN $EQMGROUP1 VARCHAR(20), 
  IN $EQMGROUP2 VARCHAR(20), 
  IN $EQMGROUP3 VARCHAR(20), 
  IN $EQMGRADE VARCHAR(20), 
  IN $EQMSTT VARCHAR(20), 
  IN $CALLTYPE VARCHAR(50), 
  IN $EQMCD VARCHAR(20),
  IN $LINECD VARCHAR(20),
  IN $USEYN VARCHAR(1), 
  IN $KEYWORD VARCHAR(1000)
  )
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  CASE $CALLTYPE
-- ****************************************************************************
   WHEN 'SEL_EQM' THEN

    SELECT
      A.FANO,
      COALESCE(A.EQMGUBUN, '') AS EQMGUBUN,
      COALESCE(COMTYPE.TPNM, '') AS EQMGRPNM,
      A.EQMNM, A.EQMNM_DETAIL, A.EQMTP, 
      A.EQMGROUP1, A.EQMGROUP2, A.EQMGROUP3, A.EQMGRADE, 
      A.EQMSTT, A.SETDATE, A.SCRAPDATE, A.MKDATE, 
      A.MKCUST, A.SERNO, A.NATCD, A.CURY_BC, 
      A.BUYFAMT, A.BUYAMT, A.ASTNO, A.INVNO, 
      A.FACTORYCD, A.LINECD, A.PRODYN, A.DEPTCD, 
      A.EMPCD, A.OWN_DIV, A.OWNCUST, A.USETYPE, 
      A.EPOWER, A.DIVYN, A.EVALYN, A.REMARK, 
      A.CHKSDT, A.CHKEDT, A.USEYN
    FROM MSTEQM AS A
    LEFT JOIN COMTYPE
      ON COMTYPE.GPCD = 'FM116'
     AND COMTYPE.TPCD = A.EQMGUBUN
    WHERE A.FACTORYCD LIKE CONCAT('%', $FACTORYCD, '%')
      AND A.LINECD LIKE CONCAT('%', $LINECD, '%')
      AND A.EQMTP LIKE CONCAT('%', $EQMTP, '%')
      AND A.EQMGROUP1 LIKE CONCAT('%', $EQMGROUP1, '%')
--       AND A.EQMGROUP2 LIKE CONCAT('%', $EQMGROUP2, '%')
--       AND A.EQMGROUP3 LIKE CONCAT('%', $EQMGROUP3, '%')
      AND A.EQMGRADE LIKE CONCAT('%', $EQMGRADE, '%')
      AND A.EQMSTT LIKE CONCAT('%', $EQMSTT, '%')
      AND A.USEYN = $USEYN
    ORDER BY A.FACTORYCD, A.LINECD, A.EQMTP, A.EQMGROUP1, A.EQMGROUP2, A.EQMGROUP3, A.FANO;

-- ****************************************************************************
  END CASE;
END