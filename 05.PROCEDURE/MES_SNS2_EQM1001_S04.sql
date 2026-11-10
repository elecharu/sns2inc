CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`EQM1001_S04`(
-- *****************************************************************************
-- Comment: 설비점검조회
-- Create: 	2025-06-27  	생성 			이대규
-- Modify: 	2026-09-15 		마이그레이션	한성수
-- 			2026-09-16 					한성수	설비점검실적 조회 마이그레이션
-- 			2026-11-06 					한성수	점검시트 출력(CALL_CHKRST_RPT) 및 특이사항 조회 추가
-- 			2026-11-09 					한성수	점검시트 개정이력 및 점검담당자 조회 연동
-- 			2026-11-10 					한성수	점검실적 입력 특이사항 단독 표기 (계획 특이사항 대체 제거)
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

-- *****************************************************************                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     **********
WHEN 'LIST_CHKRSTEQMKND' THEN
  
  -- 특이사항: 점검자가 점검 등록·수정 때 입력한 점검실적 특이사항
  SELECT
    CHKRSTEQMKND.CHKRSTKEY,
    CHKRSTEQMKND.CHKKNDCD,
    CHKRSTEQMKND.CHKKNDNM,
    CHKRSTEQMKND.CHKLOC,
    CHKRSTEQMKND.CHKMTH,
    CHKRSTEQMKND.CHKVALTP,
    CHKRSTEQMKND.CHKVALUE,
    COALESCE(CHKRSTEQMKND.REMARK, '') AS REMARK
  FROM CHKRSTEQMKND

  WHERE CHKRSTEQMKND.CHKRSTKEY = $CHKRSTKEY

  ORDER BY CHKRSTEQMKND.SORTNO
  ;

-- ****************************************************************************
WHEN 'CALL_CHKRST_RPT' THEN -- 점검 시트 출력 데이터 조회

  IF COALESCE($CHKRSTKEY, '') = '' THEN
    CALL COMERR('출력할 점검이력을 선택해주세요.');
    LEAVE PROC;
  END IF;

  -- 점검 시트 상단: 설비 정보·점검일자, 하단 서명란: 점검자(점검실적)·담당(설비마스터 점검담당사번, 사원명 없으면 사번)
  SELECT COALESCE(MSTEQM.EQMNM, GPCD('EQMCD', CHKRSTEQM.EQMCD)) AS EQMNM,
         COALESCE(MSTEQM.EQMNM_DETAIL, '') AS EQMSPEC,
         CHKRSTEQM.EQMCD, CHKRSTEQM.BASEDATE AS CHKDATE,
         COALESCE(NULLIF(MSTLINE.LINENM, ''), MSTEQM.LINECD, '') AS LINENM,
         COALESCE(NULLIF(GPCD('FM100', MSTEQM.EQMTP), ''), MSTEQM.EQMTP, '') AS PROCESSNM,
         COALESCE(CHK_EMP.EMPNM, CHKRSTEQM.EMPCD) AS CHKEMPNM,
         COALESCE(MNG_EMP.EMPNM, MSTEQM.EMPCD, '') AS MNGEMPNM
  FROM CHKRSTEQM
  LEFT JOIN MSTEQM
    ON MSTEQM.FANO = CHKRSTEQM.EQMCD
  LEFT JOIN MSTLINE
    ON MSTLINE.LINECD = MSTEQM.LINECD
  LEFT JOIN MSTEMP CHK_EMP
    ON CHK_EMP.EMPCD = CHKRSTEQM.EMPCD
  LEFT JOIN MSTEMP MNG_EMP
    ON MNG_EMP.EMPCD = NULLIF(MSTEQM.EMPCD, '')
  WHERE CHKRSTEQM.CHKRSTKEY = $CHKRSTKEY
  LIMIT 1;

  -- 점검 시트 항목: 점검실적 항목별 점검값, 특이사항은 점검자가 입력한 점검실적 특이사항
  SELECT ROW_NUMBER() OVER (ORDER BY (CHKRSTEQMKND.PLANTP = 'G') DESC, CHKRSTEQMKND.SORTNO, CHKRSTEQMKND.CHKKNDCD) AS NO,
         COALESCE(NULLIF(GPCD('CHKLOC', CHKRSTEQMKND.CHKLOC), ''), CHKRSTEQMKND.CHKLOC) AS CHKITEM,
         CHKRSTEQMKND.CHKKNDNM AS CHKCONTENT,
         COALESCE(NULLIF(GPCD('CHKMTH', CHKRSTEQMKND.CHKMTH), ''), CHKRSTEQMKND.CHKMTH) AS CHKDEVICE,
         CHKRSTEQMKND.CHKVALUE AS CHKRESULT,
         '' AS CONFIRM,
         COALESCE(CHKRSTEQMKND.REMARK, '') AS REMARK
  FROM CHKRSTEQMKND
  WHERE CHKRSTEQMKND.CHKRSTKEY = $CHKRSTKEY
  ORDER BY (CHKRSTEQMKND.PLANTP = 'G') DESC, CHKRSTEQMKND.SORTNO, CHKRSTEQMKND.CHKKNDCD;

  -- 점검 시트 하단 개정 이력: 해당 설비의 설비별 계획 + 설비그룹 계획 전체 REV (점검구분 일치, 기존 정기점검 REV는 점검구분 빈 값 포함, 최신순)
  SELECT PLAN_REV.REVNUM + 1 AS REVNUM,
         CASE PLAN_REV.PLANTP WHEN 'G' THEN '그룹' ELSE '설비' END AS PLANTPNM,
         PLAN_REV.REMARK,
         COALESCE(REQ_EMP.EMPNM, PLAN_REV.REQEMP) AS REQEMPNM,
         CASE WHEN PLAN_REV.APRVSTT = 'A' THEN COALESCE(APRV_EMP.EMPNM, PLAN_REV.APRVEMP) ELSE '' END AS APRVEMPNM
  FROM CHKRSTEQM
  LEFT JOIN MSTEQM
    ON MSTEQM.FANO = CHKRSTEQM.EQMCD
  LEFT JOIN MSTEQMREV_HEADER GRP_REV
    ON GRP_REV.REVCD = NULLIF(CHKRSTEQM.GRPREVCD, '')
  INNER JOIN MSTEQMREV_HEADER PLAN_REV
    ON (   (PLAN_REV.PLANTP = 'E' AND PLAN_REV.PLANCD = CHKRSTEQM.EQMCD)
        OR (PLAN_REV.PLANTP = 'G' AND PLAN_REV.PLANCD = COALESCE(GRP_REV.PLANCD, MSTEQM.EQMGUBUN))
       )
   AND (PLAN_REV.CHKTP = CHKRSTEQM.CHKTP OR (CHKRSTEQM.CHKTP = '02' AND PLAN_REV.CHKTP = ''))
  LEFT JOIN MSTEMP REQ_EMP
    ON REQ_EMP.EMPCD = PLAN_REV.REQEMP
  LEFT JOIN MSTEMP APRV_EMP
    ON APRV_EMP.EMPCD = PLAN_REV.APRVEMP
  WHERE CHKRSTEQM.CHKRSTKEY = $CHKRSTKEY
  ORDER BY CASE WHEN PLAN_REV.APRVSTT = 'A' THEN PLAN_REV.APRVTIME ELSE PLAN_REV.REQTIME END DESC,
           PLAN_REV.PLANTP, PLAN_REV.REVNUM DESC;

-- ****************************************************************************
END CASE; END