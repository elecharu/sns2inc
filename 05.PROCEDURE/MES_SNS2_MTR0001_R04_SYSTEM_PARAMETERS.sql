-- *****************************************************************************
-- Comment: MTR0001_R04 설비부품 발주조회 호출 파라미터 등록
-- Create:  2026-10-12  한성수
-- Modify:  2026-10-13  한성수  실제 발주키·ERP 수신키 기준 13개 파라미터 등록
--          2026-10-14  한성수  발주헤더 및 발주상세 분리 조회 파라미터(8건) 등록
-- *****************************************************************************
-- MTR0001_R04 프로시저 저장 후 아래 쿼리를 실행하여 SYSTEM_PARAMETERS에 등록
START TRANSACTION;
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'MTR0001_R04';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'MTR0001_R04';
COMMIT;

-- 파라미터 정상 등록 확인 (총 8건)
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'MTR0001_R04'
ORDER BY ORDINAL_POSITION;
