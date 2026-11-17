CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`EQM1001_R07`(
-- *****************************************************************************
-- Comment: 설비 예방보전 점검등록
-- Create: 	2026-11-16  	생성 			한성수	설비 목록 조회 (TAL0001_R05와 같은 조건)
-- *****************************************************************************
  IN $LINECD         VARCHAR(20),   -- 조회조건 작업장
  IN $EQMTP          VARCHAR(50),   -- 조회조건 공정 (MSTEQM.EQMTP, FM100)
  IN $EQMGROUP1      VARCHAR(50),   -- 조회조건 라인 (MSTEQM.EQMGROUP1, FM113)
-- *****************************************************************************
  IN $CALLTYPE       VARCHAR(50),
  IN $KEYWORD        VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
CASE $CALLTYPE
-- *****************************************************************************
WHEN 'LIST_EQMCD' THEN -- 설비 목록 (2공장 사용 설비, 작업장·공정·라인 조건)
  SELECT MSTEQM.FANO AS EQMCD,
         MSTEQM.EQMNM,
         MSTEQM.EQMTP,
         MSTEQM.EQMGROUP1
  FROM MSTEQM
  WHERE MSTEQM.FACTORYCD = '07'
    AND MSTEQM.USEYN = 'Y'
    AND ($LINECD = '' OR MSTEQM.LINECD = $LINECD)
    AND ($EQMTP = '' OR MSTEQM.EQMTP = $EQMTP)
    AND ($EQMGROUP1 = '' OR MSTEQM.EQMGROUP1 = $EQMGROUP1)
  ORDER BY MSTEQM.FANO;

-- *****************************************************************************
END CASE; END
