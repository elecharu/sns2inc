CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`EQM1001_S04`(
-- *****************************************************************************
-- Comment: 설비점검조회
-- Create: 	2025-06-27  	생성 			이대규
-- Modify: 	2026-09-15 		마이그레이션	한성수
-- 			2026-09-16 					한성수	설비점검실적(CHKRSTEQM, CHKRSTEQMKND) 조회 마이그레이션
-- *****************************************************************************
  IN $SDATE     VARCHAR(20),
  IN $EDATE     VARCHAR(20),
  IN $CHKTP     VARCHAR(20), 
  IN $EQMCD     VARCHAR(20), 
  IN $CHKRSTKEY VARCHAR(20),
-- *****************************************************************************
IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y'; 
-- *****************************************************************************

CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_CHKRSTEQM' THEN

  SELECT 
    CHKRSTEQM.BASEDATE,
    CHKRSTEQM.CHKTP,
    CHKRSTEQM.EMPCD,
    CHKRSTEQM.EQMCD,
    GPCD('EQMCD', CHKRSTEQM.EQMCD) AS EQMNM,
    CHKRSTEQM.PROBLEM,
    CHKRSTEQM.SOLUTION,
    CHKRSTEQM.CHKRSTKEY,
    CHKRSTEQM.RTIME
  FROM CHKRSTEQM
  JOIN COMTYPE ON COMTYPE.TPCD = CHKRSTEQM.CHKTP
                    AND COMTYPE.GPCD = 'CHKTP'
  
  WHERE CHKRSTEQM.BASEDATE BETWEEN $SDATE AND $EDATE
    AND CHKRSTEQM.CHKTP LIKE CONCAT ('%', $CHKTP, '%')
    AND CHKRSTEQM.EQMCD LIKE CONCAT ('%', $EQMCD, '%')
  ORDER BY CHKRSTEQM.BASEDATE, CHKRSTEQM.CHKTP, CHKRSTEQM.EQMCD
  ;

-- ****************************************************************************
WHEN 'LIST_CHKRSTEQMKND' THEN
  
  SELECT 
    CHKRSTEQMKND.CHKRSTKEY,
    CHKRSTEQMKND.CHKKNDCD,
    CHKRSTEQMKND.CHKKNDNM,
    CHKRSTEQMKND.CHKLOC,
    CHKRSTEQMKND.CHKMTH,
    CHKRSTEQMKND.CHKVALTP,
    CHKRSTEQMKND.CHKVALUE
  FROM CHKRSTEQMKND

  WHERE CHKRSTEQMKND.CHKRSTKEY = $CHKRSTKEY

  ORDER BY CHKRSTEQMKND.SORTNO
  ;

-- ****************************************************************************
END CASE; END