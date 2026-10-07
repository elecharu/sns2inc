CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`EQM1001_R05`(
-- *****************************************************************************
-- Comment: 설비점검계획 승인관리
-- Create:  2026-09-22  한성수  설비그룹·설비별 정기점검 계획 승인, 반려 및 계획서 출력 데이터 조회
-- Modify: 	2026-09-23 					한성수	승인자 조회 추가
-- 			2026-09-29 					한성수	반려 시 승인자 비움 처리 및 설비별 승인자 조회 추가
-- 			2026-09-30 					한성수	리비전(REV) 이력·승인본 저장/조회 추가, 개정내용 저장 및 항목 코드명 반환
-- 			2026-10-01 					한성수	REVCD 기준 승인본 관리, 설비그룹 승인 시 소속 반려 설비 검증 추가
-- 			2026-10-02 					한성수	승인상태 필터 추가, 계획서 출력 개편(설비별 지원·제한 해제), 승인/REV 검증 처리
-- 			2026-10-06 					한성수	R03 REV 기능 분리·항목 수 선집계, 승인 상태 헤더 통합 및 중복 승인 저장 제거; 승인·반려·출력 R03 이관 후 목록 조회만 유지
-- *****************************************************************************
  IN $EQMGRP     VARCHAR(50),
  IN $FANO       VARCHAR(50),
  IN $PLANTP     CHAR(1),
  IN $PLANCD     VARCHAR(50),
  IN $APRVSTT    CHAR(1),
  IN $REJREASON  VARCHAR(1000),
  IN $REVNUM     VARCHAR(20),
  IN $REMARK     VARCHAR(1000),

-- *****************************************************************************
  IN $CALLTYPE   VARCHAR(50),
  IN $KEYWORD    VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
CASE $CALLTYPE

-- *****************************************************************************
WHEN 'LIST_PLAN' THEN -- 점검계획 목록 조회

  IF $PLANTP = 'G' THEN
    SELECT
      'G' AS PLANTP,
      '설비그룹' AS PLANTPNM,
      PLAN_ITEM.EQMGUBUN AS PLANCD,
      COMTYPE.TPNM AS PLANNM,
      PLAN_ITEM.ITEMCNT AS PLANITEMCNT,
      COALESCE(CONCAT('REV.', PLAN_REV.REVNUM), '') AS REVNM,
      COALESCE(PLAN_REV.REMARK, '') AS REMARK,
      CASE PLAN_REV.APRVSTT
        WHEN 'A' THEN '승인'
        WHEN 'R' THEN '반려'
        ELSE '대기'
      END AS APRVSTTNM,
      CASE WHEN PLAN_REV.APRVSTT = 'A' THEN COALESCE(PLAN_REV.APRVEMP, '') ELSE '' END AS APRVEMP,
      COALESCE(PLAN_REV.REQTIME, '') AS REQTIME,
      CASE WHEN PLAN_REV.APRVSTT IN ('A', 'R') THEN PLAN_REV.APRVTIME ELSE '' END AS APRVTIME,
      CASE WHEN PLAN_REV.APRVSTT = 'R' THEN PLAN_REV.REJREASON ELSE '' END AS REJREASON,
      COALESCE(PLAN_REV.APRVSTT, '') AS APRVSTT
    -- 사용 설비의 정기점검 항목을 그룹별로 먼저 집계
    FROM (
      SELECT MSTEQM.EQMGUBUN, COUNT(DISTINCT CHKPLANEQM.CHKKNDCD) AS ITEMCNT
      FROM MSTEQM
      INNER JOIN CHKPLANEQM
        ON CHKPLANEQM.EQMCD = MSTEQM.FANO
       AND CHKPLANEQM.CHKTP = '02'
       AND CHKPLANEQM.USEYN = 'Y'
      WHERE MSTEQM.USEYN = 'Y'
        AND MSTEQM.EQMGUBUN <> ''
        AND ($EQMGRP IS NULL OR $EQMGRP = '' OR MSTEQM.EQMGUBUN = $EQMGRP)
      GROUP BY MSTEQM.EQMGUBUN
    ) PLAN_ITEM
    INNER JOIN COMTYPE
      ON COMTYPE.GPCD = 'FM116'
     AND COMTYPE.TPCD = PLAN_ITEM.EQMGUBUN
    -- 최신 리비전 (진행 중인 리비전이 있으면 그 리비전)
    LEFT JOIN (
      SELECT MSTEQMREV_HEADER.PLANCD, MAX(MSTEQMREV_HEADER.REVNUM) AS REVNUM
      FROM MSTEQMREV_HEADER
      WHERE MSTEQMREV_HEADER.PLANTP = 'G'
      GROUP BY MSTEQMREV_HEADER.PLANCD
    ) LAST_REV
      ON LAST_REV.PLANCD = PLAN_ITEM.EQMGUBUN
    LEFT JOIN MSTEQMREV_HEADER PLAN_REV
      ON PLAN_REV.PLANTP = 'G'
     AND PLAN_REV.PLANCD = LAST_REV.PLANCD
     AND PLAN_REV.REVNUM = LAST_REV.REVNUM
    -- 승인상태 필터 (W: 대기)
    WHERE (COALESCE($APRVSTT, '') = ''
        OR ($APRVSTT = 'W' AND COALESCE(PLAN_REV.APRVSTT, '') NOT IN ('A', 'R'))
        OR PLAN_REV.APRVSTT = $APRVSTT)
    ORDER BY PLAN_ITEM.EQMGUBUN;

  ELSEIF $PLANTP = 'E' THEN
    SELECT
      'E' AS PLANTP,
      '설비별' AS PLANTPNM,
      MSTEQM.FANO AS PLANCD,
      MSTEQM.EQMNM AS PLANNM,
      PLAN_ITEM.ITEMCNT AS PLANITEMCNT,
      COALESCE(CONCAT('REV.', PLAN_REV.REVNUM), '') AS REVNM,
      COALESCE(PLAN_REV.REMARK, '') AS REMARK,
      CASE PLAN_REV.APRVSTT
        WHEN 'A' THEN '승인'
        WHEN 'R' THEN '반려'
        ELSE '대기'
      END AS APRVSTTNM,
      CASE WHEN PLAN_REV.APRVSTT = 'A' THEN COALESCE(PLAN_REV.APRVEMP, '') ELSE '' END AS APRVEMP,
      COALESCE(PLAN_REV.REQTIME, '') AS REQTIME,
      CASE WHEN PLAN_REV.APRVSTT IN ('A', 'R') THEN PLAN_REV.APRVTIME ELSE '' END AS APRVTIME,
      CASE WHEN PLAN_REV.APRVSTT = 'R' THEN PLAN_REV.REJREASON ELSE '' END AS REJREASON,
      COALESCE(PLAN_REV.APRVSTT, '') AS APRVSTT
    FROM MSTEQM
    -- 항목 키(CHKKNDCD·EQMCD)가 유일하므로 중복 집계 없이 설비별 건수 계산
    INNER JOIN (
      SELECT CHKPLANEQM.EQMCD, COUNT(*) AS ITEMCNT
      FROM CHKPLANEQM
      WHERE CHKPLANEQM.CHKTP = '02'
        AND CHKPLANEQM.USEYN = 'Y'
      GROUP BY CHKPLANEQM.EQMCD
    ) PLAN_ITEM
      ON PLAN_ITEM.EQMCD = MSTEQM.FANO
    -- 최신 리비전 (진행 중인 리비전이 있으면 그 리비전)
    LEFT JOIN (
      SELECT MSTEQMREV_HEADER.PLANCD, MAX(MSTEQMREV_HEADER.REVNUM) AS REVNUM
      FROM MSTEQMREV_HEADER
      WHERE MSTEQMREV_HEADER.PLANTP = 'E'
      GROUP BY MSTEQMREV_HEADER.PLANCD
    ) LAST_REV
      ON LAST_REV.PLANCD = MSTEQM.FANO
    LEFT JOIN MSTEQMREV_HEADER PLAN_REV
      ON PLAN_REV.PLANTP = 'E'
     AND PLAN_REV.PLANCD = LAST_REV.PLANCD
     AND PLAN_REV.REVNUM = LAST_REV.REVNUM
    WHERE MSTEQM.USEYN = 'Y'
      AND ($FANO IS NULL OR $FANO = '' OR MSTEQM.FANO LIKE CONCAT('%', $FANO, '%') OR MSTEQM.EQMNM LIKE CONCAT('%', $FANO, '%'))
      -- 승인상태 필터 (W: 대기 = 승인·반려가 아닌 상태)
      AND (COALESCE($APRVSTT, '') = ''
        OR ($APRVSTT = 'W' AND COALESCE(PLAN_REV.APRVSTT, '') NOT IN ('A', 'R'))
        OR PLAN_REV.APRVSTT = $APRVSTT)
    ORDER BY MSTEQM.FANO;

  ELSE
    CALL COMERR('점검계획 구분이 올바르지 않습니다.');
    LEAVE PROC;
  END IF;
-- *****************************************************************************
END CASE;
END
