-- *****************************************************************************
-- Comment: EQM1001_R03 개정 이력 파라미터 등록
-- Create:  2026-10-06  한성수  REV 조회·저장 및 승인·반려 이관에 따른 R03 파라미터 추가
-- Modify:  2026-10-08  한성수  DETAIL 사용여부 제거 후 29개 파라미터 재등록·백업 테이블 생성 제거
-- *****************************************************************************
-- MES_SNS2_EQM1001_R03.sql 프로시저를 먼저 저장한 후 이 파일 전체 실행
START TRANSACTION;
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2' AND SPECIFIC_NAME = 'EQM1001_R03';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2' AND SPECIFIC_NAME = 'EQM1001_R03';
COMMIT;

-- 정상 건수: 29
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2' AND SPECIFIC_NAME = 'EQM1001_R03'
ORDER BY ORDINAL_POSITION;
