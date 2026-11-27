CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`EQM1001_S03`(
-- *****************************************************************************
-- Comment: 설비 비가동 조회
-- Create: 	2026-11-26  	생성 			한성수
-- Modify: 	2026-11-26 					한성수	비가동일자·작업장·공정·라인·비가동 대분류 조건 2공장 라인 비가동 이력 조회(LIST_RSTNON)로 재작성, 작업장·공정·라인명·비가동 대분류·비가동명·고장여부·비고 표시, 없는 컬럼 참조·작업지시 정보 제거
-- 			2026-11-27 					한성수	설비고장율 현황(EQM1001_S05) 막대 수리 이력 조회(LIST_EQMREP) 추가, 공정(설비구분)·라인(설비대분류)·설비번호 파라미터 추가, 수리 이력은 작업장·공정·라인 없어도 조회(비우면 2공장 전체)
-- *****************************************************************************
  IN $SDATE             VARCHAR(10),   -- 비가동일자 시작 (수리 이력은 수리시작일 시작)
  IN $EDATE             VARCHAR(10),   -- 비가동일자 종료 (수리 이력은 수리시작일 종료)
  IN $LINECD            VARCHAR(10),   -- 작업장
  IN $PRCCD             VARCHAR(10),   -- 공정
  IN $EQMCD             VARCHAR(20),   -- 라인
  IN $NONGROUPCD1       VARCHAR(10),   -- 비가동 대분류
  IN $EQMTP             VARCHAR(10),   -- 공정(설비구분, 수리 이력)
  IN $EQMGROUP1         VARCHAR(10),   -- 라인(설비대분류, 수리 이력)
  IN $FANO              VARCHAR(50),   -- 설비번호 (수리 이력, 비우면 라인 전체)

-- *****************************************************************************
  IN $CALLTYPE          VARCHAR(50),
  IN $KEYWORD           VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$NEXTDATE    VARCHAR(10);    -- 수리 이력 수리시작일 종료 다음 날

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

  WHEN 'LIST_EQMREP' THEN -- 설비 수리 이력 (설비번호 없으면 호출 수리, 있으면 그 설비 공무작업일지 수리 - 설비고장율 현황 막대와 같은 기준)

    IF IFNULL($SDATE, '') NOT REGEXP '^[0-9]{4}-[0-9]{2}-[0-9]{2}$' OR IFNULL($EDATE, '') NOT REGEXP '^[0-9]{4}-[0-9]{2}-[0-9]{2}$' THEN
      CALL COMERR('조회기간을 선택하세요.');
      LEAVE PROC;
    END IF;

    SET _$NEXTDATE = DATE_FORMAT(DATE_ADD($EDATE, INTERVAL 1 DAY), '%Y-%m-%d');

    -- 설비고장율 현황과 같은 기준: 선택 라인 2공장 사용 설비의 수리종료된 설비 수리, 수리시작일이 조회기간 안
    SELECT MSTEQM.LINECD,
           MSTEQM.EQMTP,
           MSTEQM.EQMGROUP1,
           EQMREP.EQMCD,
           MSTEQM.EQMNM,
           IF(EQMREP.EQMCALLKEY = '', '직접 수리', '호출') AS REPGUBUN,
           LEFT(EQMREP.REPSTIME, 16) AS REPSTIME,
           LEFT(EQMREP.REPETIME, 16) AS REPETIME,
           TIMESTAMPDIFF(MINUTE, EQMREP.REPSTIME, EQMREP.REPETIME) AS REPMIN,
           EQMREP.WORKTP,
           EQMREP.FAILTP,
           EQMREP.FAILPART,
           EQMREP.MALFUNCTION,
           EQMREP.HANDLE
    FROM EQMREP
    INNER JOIN MSTEQM
      ON MSTEQM.FANO = EQMREP.EQMCD
    WHERE MSTEQM.FACTORYCD = '07'
      AND MSTEQM.USEYN = 'Y'
      AND ($LINECD = '' OR MSTEQM.LINECD = $LINECD)
      AND ($EQMTP = '' OR MSTEQM.EQMTP = $EQMTP)
      AND ($EQMGROUP1 = '' OR MSTEQM.EQMGROUP1 = $EQMGROUP1)
      AND EQMREP.EQMREPTP = 'EQM01'
      AND (   ($FANO = '' AND EQMREP.EQMCALLKEY <> '')
           OR ($FANO <> '' AND EQMREP.EQMCD = $FANO AND EQMREP.WORKTP <> '')
          )
      AND EQMREP.REPETIME <> ''
      AND EQMREP.REPETIME >= EQMREP.REPSTIME
      AND EQMREP.REPSTIME >= $SDATE
      AND EQMREP.REPSTIME < _$NEXTDATE
    ORDER BY EQMREP.REPSTIME, EQMREP.EQMREPKEY;

-- *****************************************************************************
END CASE;

END
