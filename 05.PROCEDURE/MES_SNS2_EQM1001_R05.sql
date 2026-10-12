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
-- 			2026-10-08 					한성수	최신 REV DETAIL의 전체 항목 수로 목록 조회 전환
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
WHEN 'LIST_PLAN' THEN -- 최신 점검계획 목록 조회
  IF COALESCE($PLANTP, '') NOT IN ('G', 'E') THEN
    CALL COMERR('점검계획 구분이 올바르지 않습니다.');
    LEAVE PROC;
  END IF;
  SELECT
    PLAN_REV.PLANTP, IF(PLAN_REV.PLANTP = 'G', '설비그룹', '설비별') AS PLANTPNM,
    PLAN_REV.PLANCD, COALESCE(COMTYPE.TPNM, MSTEQM.EQMNM, PLAN_REV.PLANCD) AS PLANNM,
    PLAN_ITEM.ITEMCNT AS PLANITEMCNT, CONCAT('REV.', PLAN_REV.REVNUM) AS REVNM, PLAN_REV.REMARK,
    CASE PLAN_REV.APRVSTT WHEN 'A' THEN '승인' WHEN 'R' THEN '반려' ELSE '대기' END AS APRVSTTNM,
    CASE WHEN PLAN_REV.APRVSTT = 'A' THEN PLAN_REV.APRVEMP ELSE '' END AS APRVEMP,
    PLAN_REV.REQTIME,
    CASE WHEN PLAN_REV.APRVSTT IN ('A', 'R') THEN PLAN_REV.APRVTIME ELSE '' END AS APRVTIME,
    CASE WHEN PLAN_REV.APRVSTT = 'R' THEN PLAN_REV.REJREASON ELSE '' END AS REJREASON,
    PLAN_REV.APRVSTT
  FROM MSTEQMREV_HEADER PLAN_REV
  INNER JOIN (SELECT PLANCD, MAX(REVNUM) AS REVNUM FROM MSTEQMREV_HEADER WHERE PLANTP = $PLANTP GROUP BY PLANCD) LAST_REV
    ON LAST_REV.PLANCD = PLAN_REV.PLANCD AND LAST_REV.REVNUM = PLAN_REV.REVNUM
  INNER JOIN (SELECT REVCD, COUNT(*) AS ITEMCNT FROM MSTEQMREV_DETAIL GROUP BY REVCD) PLAN_ITEM
    ON PLAN_ITEM.REVCD = PLAN_REV.REVCD
  LEFT JOIN COMTYPE ON PLAN_REV.PLANTP = 'G' AND COMTYPE.GPCD = 'FM116' AND COMTYPE.TPCD = PLAN_REV.PLANCD AND COMTYPE.USEYN = 'Y'
  LEFT JOIN MSTEQM ON PLAN_REV.PLANTP = 'E' AND MSTEQM.FANO = PLAN_REV.PLANCD AND MSTEQM.USEYN = 'Y'
  WHERE PLAN_REV.PLANTP = $PLANTP
    AND (($PLANTP = 'G' AND COMTYPE.TPCD IS NOT NULL AND (COALESCE($EQMGRP, '') = '' OR PLAN_REV.PLANCD = $EQMGRP))
      OR ($PLANTP = 'E' AND MSTEQM.FANO IS NOT NULL AND (COALESCE($FANO, '') = '' OR MSTEQM.FANO LIKE CONCAT('%', $FANO, '%') OR MSTEQM.EQMNM LIKE CONCAT('%', $FANO, '%'))))
    AND (COALESCE($APRVSTT, '') = '' OR ($APRVSTT = 'W' AND PLAN_REV.APRVSTT NOT IN ('A', 'R')) OR PLAN_REV.APRVSTT = $APRVSTT)
  ORDER BY PLAN_REV.PLANCD;
-- *****************************************************************************
END CASE;
END
