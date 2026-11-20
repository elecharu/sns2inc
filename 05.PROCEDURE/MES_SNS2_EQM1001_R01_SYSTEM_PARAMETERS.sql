-- *****************************************************************************
-- Comment: EQM1001_R01 공무작업일지 입력항목(WORKTP~PREVENT)·사용부품 목록(PARTTP_LIST~PARTREMARK_LIST) 추가 후 호출 파라미터 재등록
-- Create:  2026-11-13  한성수
-- Modify:  2026-11-19  한성수  공무작업일지 파라미터 14개 추가 (45건 → 59건)
--          2026-11-20  한성수  그리드 저장(SAVE_EQMREP) 전용 목록 파라미터 14개 제거, 사용부품 출고일자 목록(INOUTDATE_LIST) 추가, 삭제·작업자 별도 저장·미사용 분기 정리로 파라미터 15개 제거 (59건 → 31건), 출고 부품 선택 기간 제한 제거로 REPSDAY 제거 (31건 → 30건), 공무작업일지 삭제용 EQMREPKEY_LIST 추가 (30건 → 31건)
-- *****************************************************************************
-- MES_SNS2_EQM1001_R01_ALTER_TABLE.sql 실행 → R01 프로시저 전체 저장 후 아래 트랜잭션을 실행
START TRANSACTION;
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_R01';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_R01';
COMMIT;

-- 정상 31건: WORKTP~PREVENT 12~18번, EMPCD_LIST 19번, EQMREPKEY_LIST 20번, PARTTP_LIST~PARTREMARK_LIST 22~28번, INOUTDATE_LIST 29번, CALLTYPE 30번, KEYWORD 31번
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_R01'
ORDER BY ORDINAL_POSITION;
