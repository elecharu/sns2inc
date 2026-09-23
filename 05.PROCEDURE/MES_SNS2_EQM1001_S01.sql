CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`EQM1001_S01`(
-- *****************************************************************************
-- Comment: 이력카드 
-- Create: 	2025-07-04  	생성 			이대규
-- Modify: 	2026-09-16 		마이그레이션	한성수
-- 			2026-09-17 					한성수	설비이력카드(QSP-4111-03) 표준 양식 맞춤 데이터 컬럼 확장
-- 			2026-09-17 					한성수	수리시간(분) 계산 로직 변경 및 보전구분 기본값 공백 처리
-- 			2026-09-17 					한성수	컬럼 매핑 단순화(IFNULL/GPCD 통일) 및 구매가격 기본값(0(KRW)) 적용
-- *****************************************************************************
  IN $EQMCD            VARCHAR(20),     -- 설비코드

-- *****************************************************************************
  IN $CALLTYPE         VARCHAR(50),
  IN $KEYWORD          VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

CASE $CALLTYPE

-- *****************************************************************************
WHEN 'LIST_EQMCD' THEN  -- 설비 목록 조회
  SELECT 
    MSTEQM.FANO        AS EQMCD,
    MSTEQM.EQMNM
  FROM MSTEQM
  WHERE MSTEQM.FANO LIKE CONCAT('%', $EQMCD, '%')
  ORDER BY MSTEQM.FANO;

-- *****************************************************************************
WHEN 'CALL_RPT' THEN  -- 이력카드 출력 리포트 데이터 조회

  -- [0] 이력카드 상단 설비 마스터 정보 (QSP-4111-03 양식)
  SELECT 
    MSTEQM.FANO                                                    AS EQMCD,       -- 관리번호
    MSTEQM.EQMNM                                                   AS EQMNM,       -- 설비명
    IFNULL(MSTEQM.EQMNM_DETAIL, '')                                AS EQMSPEC,     -- 규격
    IFNULL(MSTEQM.SERNO, '')                                       AS SERNO,       -- 제조번호
    IFNULL(MSTEQM.MKCUST, '')                                      AS MKCUST,      -- 메이커 (제조사?)
    IFNULL(DATE_FORMAT(MSTEQM.MKDATE, '%Y년 %m월 %d일'), '')        AS MKDATE,      -- 제작일자
    IFNULL(MSTEQM.EPOWER, '')                                      AS EPOWER,      -- 사용전력(KVA)
    ''                                                             AS VOLT,        -- 전압(V)
    IFNULL(NULLIF(GPCD('FM110', MSTEQM.EQMGRADE), ''), MSTEQM.EQMGRADE)           AS EQMGRADE,    -- 설비등급
    IFNULL((SELECT CUSTNM FROM MSTCUST WHERE CUSTCD = MSTEQM.OWNCUST), MSTEQM.OWNCUST) AS BUYCUST,     -- 구입회사  (소유회사?)
    IFNULL(DATE_FORMAT(MSTEQM.SETDATE, '%Y년 %m월 %d일'), '')       AS SETDATE,     -- 설치일자
    CONCAT(FORMAT(IFNULL(MSTEQM.BUYFAMT, 0), 0), '(', IFNULL(NULLIF(GPCD('BC400', MSTEQM.CURY_BC), ''), 'KRW'), ')') AS BUYAMT, -- 구입금액
    IFNULL(NULLIF(GPCD('MD111', MSTEQM.OWN_DIV), ''), MSTEQM.OWN_DIV)             AS OWN_DIV,     -- 소유구분
    IFNULL(MSTEQM.USETYPE, '')                                     AS USETYPE,     -- 가공아이템
    IFNULL(NULLIF(GPCD('FM100', MSTEQM.EQMTP), ''), MSTEQM.EQMTP)                 AS EQMTP,       -- 공정구분
    IFNULL(NULLIF(GPCD('FM113', MSTEQM.EQMGROUP1), ''), MSTEQM.EQMGROUP1)         AS EQMGROUP1,   -- 설비대분류
    IFNULL(NULLIF(GPCD('FM114', MSTEQM.EQMGROUP2), ''), MSTEQM.EQMGROUP2)         AS EQMGROUP2,   -- 설비중분류
    IFNULL(NULLIF(GPCD('FM115', MSTEQM.EQMGROUP3), ''), MSTEQM.EQMGROUP3)         AS EQMGROUP3,   -- 설비소분류
    ''                                                             AS FILEPATH,    -- 도해사진1
    ''                                                             AS FILEPATH2    -- 도해사진2
  FROM MSTEQM
  WHERE MSTEQM.FANO = $EQMCD
  LIMIT 1;

  -- [1] 이력카드 하단 검교정 및 수리현황 정보
  SET @ROWNUM := 0;

  SELECT 
    @ROWNUM := @ROWNUM + 1                                         AS NO,
    IFNULL(DATE_FORMAT(EQMREP.REGTIME, '%Y년 %m월'), '')            AS REPDATE,         -- 수리일
    IFNULL(EQMREP.HANDLE, IFNULL(EQMREP.MALFUNCTION, ''))          AS REPKND_CONTENTS, -- 교정 및 수리내용
    CASE 
      WHEN TIMESTAMPDIFF(MINUTE, EQMREP.REPSTIME, EQMREP.REPETIME) > 0 
      THEN FORMAT(TIMESTAMPDIFF(MINUTE, EQMREP.REPSTIME, EQMREP.REPETIME), 0)
      ELSE ''
    END                                                            AS REPTIME,         -- 수리시간(분)
    IFNULL((
      SELECT GROUP_CONCAT(MSTEMP.EMPNM SEPARATOR ', ')
      FROM EQMREP_EMP
      JOIN MSTEMP ON MSTEMP.EMPCD = EQMREP_EMP.EMPCD
      WHERE EQMREP_EMP.EQMREPKEY = EQMREP.EQMREPKEY
    ), IFNULL(EQMREP.EMPCD, ''))                                   AS EMPNAME,         -- 수리인원
    IFNULL(NULLIF(GPCD('FM300', EQMREP.EQMREPTP), ''), EQMREP.EQMREPTP)           AS MAINT_DIV,       -- 보전구분
    IFNULL(EQMREP.REMARK, '')                                      AS REMARK           -- 비고
  FROM EQMREP
  WHERE EQMREP.EQMCD = $EQMCD
  ORDER BY EQMREP.REGTIME;

-- *****************************************************************************
END CASE;

END
