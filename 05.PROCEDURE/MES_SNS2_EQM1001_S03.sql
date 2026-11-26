CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`EQM1001_S03`(
-- *****************************************************************************
-- Comment: 설비 비가동 조회
-- Create: 	2026-11-26  	생성 			한성수
-- Modify: 	2026-11-26 					한성수	비가동일자·작업장·공정·라인·비가동 대분류 조건 2공장 라인 비가동 이력 조회(LIST_RSTNON)로 재작성, 작업장·공정·라인명·비가동 대분류·비가동명·고장여부·비고 표시, 없는 컬럼 참조·작업지시 정보 제거
-- *****************************************************************************
  IN $SDATE             VARCHAR(10),   -- 비가동일자 시작
  IN $EDATE             VARCHAR(10),   -- 비가동일자 종료
  IN $LINECD            VARCHAR(10),   -- 작업장
  IN $PRCCD             VARCHAR(10),   -- 공정
  IN $EQMCD             VARCHAR(20),   -- 라인
  IN $NONGROUPCD1       VARCHAR(10),   -- 비가동 대분류

-- *****************************************************************************
  IN $CALLTYPE          VARCHAR(50),
  IN $KEYWORD           VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_RSTNON' THEN -- 비가동 이력 조회 (진행 중인 비가동은 시간 0)

    SELECT PRDRSTNON.PRDNONKEY,
           LEFT(PRDRSTNON.NONSTIME, 10) AS NONDATE,
           MSTLINE.LINENM,
           IFNULL(MSTPRC.PRCNM, MSTLINE_EQM.PRCCD) AS PRCNM,
           MSTLINE_EQM.EQMNM,
           IFNULL(MSTNON.NONGROUPCD1, '') AS NONGROUPCD1,
           IFNULL(MSTNON.NONNM, PRDRSTNON.NONCD) AS NONNM,
           IFNULL(MSTNON.BADYN, '') AS BADYN,
           LEFT(PRDRSTNON.NONSTIME, 16) AS NONSTIME,
           LEFT(PRDRSTNON.NONETIME, 16) AS NONETIME,
           IF(PRDRSTNON.NONETIME = '', 0, TIMESTAMPDIFF(MINUTE, PRDRSTNON.NONSTIME, PRDRSTNON.NONETIME)) AS NONTIME,
           PRDRSTNON.PROBLEM,
           PRDRSTNON.SOLUTION,
           PRDRSTNON.REMARK,
           GPCD('EMPCD', PRDRSTNON.REMP) AS EMPNM
    FROM PRDRSTNON
    INNER JOIN MSTLINE
      ON MSTLINE.LINECD = PRDRSTNON.LINECD
    INNER JOIN MSTLINE_EQM
      ON MSTLINE_EQM.EQMCD = PRDRSTNON.EQMCD
    LEFT JOIN MSTPRC
      ON MSTPRC.PRCCD = MSTLINE_EQM.PRCCD
    LEFT JOIN MSTNON
      ON MSTNON.LINECD = PRDRSTNON.LINECD
     AND MSTNON.NONCD = PRDRSTNON.NONCD
    WHERE MSTLINE.FACTORYCD = '07'
      AND LEFT(PRDRSTNON.NONSTIME, 10) BETWEEN $SDATE AND $EDATE
      AND ($LINECD = '' OR PRDRSTNON.LINECD = $LINECD)
      AND ($PRCCD = '' OR MSTLINE_EQM.PRCCD = $PRCCD)
      AND ($EQMCD = '' OR PRDRSTNON.EQMCD = $EQMCD)
      AND ($NONGROUPCD1 = '' OR MSTNON.NONGROUPCD1 = $NONGROUPCD1)
    ORDER BY PRDRSTNON.NONSTIME;

-- *****************************************************************************
END CASE;

END
