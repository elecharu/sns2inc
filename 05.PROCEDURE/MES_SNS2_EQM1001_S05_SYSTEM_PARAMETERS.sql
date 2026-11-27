-- *****************************************************************************
-- Comment: EQM1001_S05 설비고장율 현황 호출 파라미터 등록
-- Create:  2026-11-25  한성수  신규 프로시저 (6건)
-- Modify:  2026-11-26  한성수  조회기간 시작일(SDATE)·종료일(EDATE) 추가 (8건)
-- *****************************************************************************
-- EQM1001_S05 프로시저 저장 후 아래 트랜잭션을 실행
START TRANSACTION;
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_S05';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_S05';
COMMIT;

-- 정상 8건: SYEAR 1번, LINECD 2번, EQMTP 3번, EQMGROUP1 4번, SDATE 5번, EDATE 6번, CALLTYPE 7번, KEYWORD 8번
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_S05'
ORDER BY ORDINAL_POSITION;
