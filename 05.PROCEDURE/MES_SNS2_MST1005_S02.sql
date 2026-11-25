CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`MST1005_S02`(
-- *****************************************************************************
-- Comment: 설비등급별 설비 조회
-- Create: 	2026-11-25  	생성 			한성수
-- Modify: 	2026-11-25 					한성수	공장 조건 설비등급별 설비대수·등급 기준 집계(설비 없는 등급 포함), 선택 등급 설비 목록 조회
-- *****************************************************************************
  IN $FACTORYCD         VARCHAR(10),   -- 공장
  IN $EQMGRADE          VARCHAR(10),   -- 설비등급

-- *****************************************************************************
  IN $CALLTYPE          VARCHAR(50),
  IN $KEYWORD           VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_GRADE' THEN -- 설비등급별 설비대수 집계 (설비등급기준 사용중 리비전의 모든 등급, 설비 없는 등급은 0대)

    WITH EQM_CNT AS (
      SELECT EQMGRADE, COUNT(*) AS EQMCNT
      FROM MSTEQM
      WHERE USEYN = 'Y'
        AND FACTORYCD = $FACTORYCD
      GROUP BY EQMGRADE
    ), GRADE_SCORE AS (
      SELECT EQMGRADE, SCORENM, MNGNM, CHKCYCLE2
      FROM MSTEQM_GRADEREV_SCORE
      WHERE REVCD = (SELECT REVCD FROM MSTEQM_GRADEREV WHERE USEYN = 'Y' LIMIT 1)
    )
    SELECT GRADE_LIST.EQMGRADE, GRADE_SCORE.SCORENM, GRADE_SCORE.MNGNM, GRADE_SCORE.CHKCYCLE2,
           IFNULL(EQM_CNT.EQMCNT, 0) AS EQMCNT
    FROM (
      SELECT EQMGRADE FROM GRADE_SCORE

      UNION

      SELECT EQMGRADE FROM EQM_CNT
    ) GRADE_LIST
    LEFT JOIN GRADE_SCORE
      ON GRADE_SCORE.EQMGRADE = GRADE_LIST.EQMGRADE
    LEFT JOIN EQM_CNT
      ON EQM_CNT.EQMGRADE = GRADE_LIST.EQMGRADE
    LEFT JOIN COMTYPE
      ON COMTYPE.GPCD = 'FM110'
     AND COMTYPE.TPCD = GRADE_LIST.EQMGRADE
    ORDER BY COMTYPE.SORTNO IS NULL, COMTYPE.SORTNO, GRADE_LIST.EQMGRADE;

-- *****************************************************************************

  WHEN 'LIST_EQM' THEN -- 선택 등급의 설비 목록 조회

    SELECT MSTEQM.LINECD, MSTEQM.EQMTP, MSTEQM.EQMGROUP1, MSTEQM.EQMGUBUN,
           MSTEQM.FANO, MSTEQM.EQMNM, MSTEQM.EQMSTT, LEFT(MSTEQM.SETDATE, 10) AS SETDATE
    FROM MSTEQM
    WHERE MSTEQM.USEYN = 'Y'
      AND MSTEQM.FACTORYCD = $FACTORYCD
      AND MSTEQM.EQMGRADE = $EQMGRADE
    ORDER BY MSTEQM.LINECD, MSTEQM.EQMTP, MSTEQM.EQMGROUP1, MSTEQM.FANO;

-- *****************************************************************************
END CASE;

END
