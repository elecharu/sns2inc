CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD6001_S01(
-- *****************************************************************************
-- Comment: 설비 일상점검 조회 (EQM1001_S04 설비 정기점검 조회 기준, CHKTP = '01' 일상점검 고정)
-- Create: 2026-10-23 13:58:
-- *****************************************************************************
  IN $SDATE       VARCHAR(20),      -- 점검일자 시작
  IN $EDATE       VARCHAR(20),      -- 점검일자 끝
  IN $EQMCD       VARCHAR(20),      -- 설비코드
  IN $CHKRSTKEY   VARCHAR(20),      -- 점검키
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_CHKRSTEQM' THEN  -- 일상점검 이력

  SELECT
      CHKRSTEQM.BASEDATE
    , LEFT(CHKRSTEQM.CHKTIME, 16) AS CHKTIME
    , CHKRSTEQM.EMPCD
    , CHKRSTEQM.EQMCD
    , GPCD('EQMCD', CHKRSTEQM.EQMCD) AS EQMNM
    , CHKRSTEQM.PROBLEM
    , CHKRSTEQM.SOLUTION
    , CHKRSTEQM.CHKRSTKEY
    , CHKRSTEQM.RTIME
  FROM CHKRSTEQM
  WHERE CHKRSTEQM.CHKTP = '01'
    AND CHKRSTEQM.BASEDATE BETWEEN $SDATE AND $EDATE
    AND CHKRSTEQM.EQMCD LIKE CONCAT('%', $EQMCD, '%')
  ORDER BY CHKRSTEQM.BASEDATE, CHKRSTEQM.EQMCD, CHKRSTEQM.CHKTIME
  ;

-- ****************************************************************************
WHEN 'LIST_CHKRSTEQMKND' THEN  -- 일상점검 항목

  SELECT
      CHKRSTEQMKND.CHKRSTKEY
    , CHKRSTEQMKND.CHKKNDCD
    , CHKRSTEQMKND.CHKKNDNM
    , CHKRSTEQMKND.CHKLOC
    , CHKRSTEQMKND.CHKMTH
    , CHKRSTEQMKND.CHKVALTP
    , CHKRSTEQMKND.CHKVALUE
    , CHKRSTEQMKND.REMARK
  FROM CHKRSTEQMKND
  WHERE CHKRSTEQMKND.CHKRSTKEY = $CHKRSTKEY
  ORDER BY (CHKRSTEQMKND.PLANTP = 'G') DESC, CHKRSTEQMKND.SORTNO, CHKRSTEQMKND.CHKKNDCD
  ;

-- ****************************************************************************
END CASE; END
