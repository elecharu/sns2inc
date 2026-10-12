-- *****************************************************************************
-- Comment: EQM1001_R05 COMCALLC 파라미터 메타데이터
-- Create:  2026-09-22  한성수  설비점검계획 승인관리 프로시저 파라미터 등록
-- Modify:  2026-10-08  한성수  현재 프로시저 정의로 파라미터 삭제·재등록
-- *****************************************************************************
-- MES_SNS2_EQM1001_R05.sql 프로시저를 먼저 저장한 후 이 파일 전체 실행
START TRANSACTION;
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2' AND SPECIFIC_NAME = 'EQM1001_R05';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2' AND SPECIFIC_NAME = 'EQM1001_R05';
COMMIT;

-- 정상 건수: 10
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2' AND SPECIFIC_NAME = 'EQM1001_R05'
ORDER BY ORDINAL_POSITION;
