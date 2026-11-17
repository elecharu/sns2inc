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
-- 			2026-11-16 					한성수	설비 분류·공장 필터 추가, 점검이력 승인·승인취소 및 점검시트 담당란 승인자 표시, 개정이력 계획 승인 조회 제거, 개정이력 REV 번호 저장값 그대로 표시
-- 			2026-11-17 					한성수	점검이력 점검일자·등록일시 오래된 순 정렬, 예방보전 점검시트 개정이력에 정기점검 계획 REV 표시, 개정이력 작성자 사원명 표시(이전 로그인 ID 저장분은 사용자 사원코드로 연결)
-- *****************************************************************************
  IN $SDATE          VARCHAR(20),
  IN $EDATE          VARCHAR(20),
  IN $CHKTP          VARCHAR(20),
  IN $FACTORYCD      VARCHAR(20),
  IN $LINECD         VARCHAR(20),
  IN $EQMTP          VARCHAR(20),
  IN $EQMGROUP1      VARCHAR(20),
  IN $EQMCD          VARCHAR(20),
  IN $CHKRSTKEY      VARCHAR(20),
  IN $APRVEMP        VARCHAR(20),   -- 승인자 (APPROVE)
  IN $CHKRSTKEY_LIST MEDIUMTEXT,    -- 체크한 점검이력 (APPROVE, APPROVE_CANCEL)
-- *****************************************************************************
IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$CHKRSTKEY      VARCHAR(100);
  DECLARE _$CHKRSTKEY_LIST MEDIUMTEXT;
  DECLARE _$EQMINFO        VARCHAR(200);

CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_CHKRSTEQM' THEN

  SET $FACTORYCD = '07';

  SELECT
    CHKRSTEQM.BASEDATE,
    CHKRSTEQM.CHKTP,
    CHKRSTEQM.EMPCD,
    IFNULL(MSTEQM.FACTORYCD, '') AS FACTORYCD,
    IFNULL(MSTEQM.LINECD, '')    AS LINECD,
    IFNULL(MSTEQM.EQMTP, '')     AS EQMTP,
    IFNULL(MSTEQM.EQMGROUP1, '') AS EQMGROUP1,
    CHKRSTEQM.EQMCD,
    GPCD('EQMCD', CHKRSTEQM.EQMCD) AS EQMNM,
    CHKRSTEQM.PROBLEM,
    CHKRSTEQM.SOLUTION,
    CHKRSTEQM.CHKRSTKEY,
    CHKRSTEQM.RTIME,
    -- 승인자·승인일시 (승인 안 했으면 빈 값)
    CHKRSTEQM.APRVEMP,
    COALESCE(APRV_EMP.EMPNM, CHKRSTEQM.APRVEMP) AS APRVEMPNM,
    LEFT(CHKRSTEQM.APRVTIME, 16) AS APRVTIME
  FROM CHKRSTEQM
  JOIN COMTYPE ON COMTYPE.TPCD = CHKRSTEQM.CHKTP
                    AND COMTYPE.GPCD = 'CHKTP'
  LEFT JOIN MSTEQM ON MSTEQM.FANO = CHKRSTEQM.EQMCD
  LEFT JOIN MSTEMP APRV_EMP ON APRV_EMP.EMPCD = NULLIF(CHKRSTEQM.APRVEMP, '')

  WHERE CHKRSTEQM.BASEDATE BETWEEN $SDATE AND $EDATE
    AND CHKRSTEQM.CHKTP LIKE CONCAT ('%', $CHKTP, '%')
    AND ($FACTORYCD = '' OR MSTEQM.FACTORYCD = $FACTORYCD)
    AND ($LINECD = '' OR MSTEQM.LINECD = $LINECD)
    AND ($EQMTP = '' OR MSTEQM.EQMTP = $EQMTP)
    AND ($EQMGROUP1 = '' OR MSTEQM.EQMGROUP1 = $EQMGROUP1)
    AND CHKRSTEQM.EQMCD LIKE CONCAT ('%', $EQMCD, '%')
  ORDER BY CHKRSTEQM.BASEDATE, CHKRSTEQM.RTIME, CHKRSTEQM.CHKRSTKEY
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
WHEN 'APPROVE' THEN -- 체크한 점검이력 승인 (TQM1002_R01 방식, 이미 승인된 이력은 승인자·승인일시를 새 값으로)

  IF COALESCE($APRVEMP, '') = '' OR NOT EXISTS (SELECT 1 FROM MSTEMP WHERE EMPCD = $APRVEMP LIMIT 1) THEN
    CALL COMERR('승인자를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF COALESCE($CHKRSTKEY_LIST, '') = '' THEN
    CALL COMERR('승인할 점검이력을 체크하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 전부 확인한 뒤에 승인: 없는(삭제된) 점검이력이 있으면 막는다
  SET _$CHKRSTKEY_LIST = $CHKRSTKEY_LIST;
  WHILE LENGTH(_$CHKRSTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$CHKRSTKEY_LIST, _$CHKRSTKEY);

    IF NOT EXISTS (SELECT 1 FROM CHKRSTEQM WHERE CHKRSTKEY = _$CHKRSTKEY LIMIT 1) THEN
      CALL COMERR('조회한 점검이력이 없습니다. 다시 조회해주세요.');
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 승인
  SET _$CHKRSTKEY_LIST = $CHKRSTKEY_LIST;
  WHILE LENGTH(_$CHKRSTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$CHKRSTKEY_LIST, _$CHKRSTKEY);

    UPDATE CHKRSTEQM
    SET APRVEMP  = $APRVEMP,
        APRVTIME = CALLTIME(),
        MTIME    = CALLTIME(),
        MEMP     = CALLEMP(),
        MPRG     = CALLPRG()
    WHERE CHKRSTKEY = _$CHKRSTKEY;
  END WHILE;

-- ****************************************************************************
WHEN 'APPROVE_CANCEL' THEN -- 체크한 점검이력 승인취소 (TQM1002_R01 방식, 승인자·승인일시 비움)

  IF COALESCE($CHKRSTKEY_LIST, '') = '' THEN
    CALL COMERR('승인취소할 점검이력을 체크하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 전부 확인한 뒤에 취소: 승인 안 된 점검이력이 있으면 막는다
  SET _$CHKRSTKEY_LIST = $CHKRSTKEY_LIST;
  WHILE LENGTH(_$CHKRSTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$CHKRSTKEY_LIST, _$CHKRSTKEY);

    IF NOT EXISTS (SELECT 1 FROM CHKRSTEQM WHERE CHKRSTKEY = _$CHKRSTKEY AND APRVTIME <> '' LIMIT 1) THEN
      SET _$EQMINFO = COALESCE((SELECT CONCAT('[', EQMCD, '] ', BASEDATE) FROM CHKRSTEQM WHERE CHKRSTKEY = _$CHKRSTKEY LIMIT 1), _$CHKRSTKEY);
      CALL COMERR(CONCAT('승인되지 않은 점검이력은 승인취소할 수 없습니다.\n- ', _$EQMINFO));
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 승인취소
  SET _$CHKRSTKEY_LIST = $CHKRSTKEY_LIST;
  WHILE LENGTH(_$CHKRSTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$CHKRSTKEY_LIST, _$CHKRSTKEY);

    UPDATE CHKRSTEQM
    SET APRVEMP  = '',
        APRVTIME = '',
        MTIME    = CALLTIME(),
        MEMP     = CALLEMP(),
        MPRG     = CALLPRG()
    WHERE CHKRSTKEY = _$CHKRSTKEY;
  END WHILE;

-- ****************************************************************************
WHEN 'CALL_CHKRST_RPT' THEN -- 점검 시트 출력 데이터 조회

  IF COALESCE($CHKRSTKEY, '') = '' THEN
    CALL COMERR('출력할 점검이력을 선택해주세요.');
    LEAVE PROC;
  END IF;

  -- 점검 시트 상단: 설비 정보·점검일자, 하단 서명란: 점검자(점검실적)·담당(점검이력 승인자, 사원명 없으면 사번, 승인 전은 빈칸)
  -- 담당란 값은 레포트 필드명 MNGEMPNM 그대로 사용
  SELECT COALESCE(MSTEQM.EQMNM, GPCD('EQMCD', CHKRSTEQM.EQMCD)) AS EQMNM,
         COALESCE(MSTEQM.EQMNM_DETAIL, '') AS EQMSPEC,
         CHKRSTEQM.EQMCD, CHKRSTEQM.BASEDATE AS CHKDATE,
         COALESCE(NULLIF(MSTLINE.LINENM, ''), MSTEQM.LINECD, '') AS LINENM,
         COALESCE(NULLIF(GPCD('FM100', MSTEQM.EQMTP), ''), MSTEQM.EQMTP, '') AS PROCESSNM,
         COALESCE(CHK_EMP.EMPNM, CHKRSTEQM.EMPCD) AS CHKEMPNM,
         CASE WHEN CHKRSTEQM.APRVTIME <> '' THEN COALESCE(APRV_EMP.EMPNM, CHKRSTEQM.APRVEMP) ELSE '' END AS MNGEMPNM
  FROM CHKRSTEQM
  LEFT JOIN MSTEQM
    ON MSTEQM.FANO = CHKRSTEQM.EQMCD
  LEFT JOIN MSTLINE
    ON MSTLINE.LINECD = MSTEQM.LINECD
  LEFT JOIN MSTEMP CHK_EMP
    ON CHK_EMP.EMPCD = CHKRSTEQM.EMPCD
  LEFT JOIN MSTEMP APRV_EMP
    ON APRV_EMP.EMPCD = NULLIF(CHKRSTEQM.APRVEMP, '')
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

  -- 점검 시트 하단 개정 이력: 해당 설비의 설비별 계획 + 설비그룹 계획 전체 REV (점검구분 일치, 예방보전('03')은 정기점검('02') 계획 사용, 기존 정기점검 REV는 점검구분 빈 값 포함, 최신순)
  SELECT PLAN_REV.REVNUM,
         CASE PLAN_REV.PLANTP WHEN 'G' THEN '그룹' ELSE '설비' END AS PLANTPNM,
         PLAN_REV.REMARK,
         COALESCE(REQ_EMP.EMPNM, '') AS REQEMPNM
  FROM CHKRSTEQM
  LEFT JOIN MSTEQM
    ON MSTEQM.FANO = CHKRSTEQM.EQMCD
  LEFT JOIN MSTEQMREV_HEADER GRP_REV
    ON GRP_REV.REVCD = NULLIF(CHKRSTEQM.GRPREVCD, '')
  INNER JOIN MSTEQMREV_HEADER PLAN_REV
    ON (   (PLAN_REV.PLANTP = 'E' AND PLAN_REV.PLANCD = CHKRSTEQM.EQMCD)
        OR (PLAN_REV.PLANTP = 'G' AND PLAN_REV.PLANCD = COALESCE(GRP_REV.PLANCD, MSTEQM.EQMGUBUN))
       )
   AND (PLAN_REV.CHKTP = IF(CHKRSTEQM.CHKTP = '03', '02', CHKRSTEQM.CHKTP) OR (CHKRSTEQM.CHKTP IN ('02', '03') AND PLAN_REV.CHKTP = ''))
  -- 작성자: 처음 저장한 사원(REQEMP 사원코드, 이전 로그인 ID 저장분은 사용자 사원코드로 연결)
  LEFT JOIN SYSUSER REQ_USER
    ON REQ_USER.USERID = PLAN_REV.REQEMP
  LEFT JOIN MSTEMP REQ_EMP
    ON REQ_EMP.EMPCD = COALESCE(REQ_USER.EMPCD, PLAN_REV.REQEMP)
  WHERE CHKRSTEQM.CHKRSTKEY = $CHKRSTKEY
  ORDER BY PLAN_REV.RTIME DESC, PLAN_REV.PLANTP, PLAN_REV.REVNUM DESC;

-- ****************************************************************************
END CASE; END