-- *****************************************************************************
-- Comment: EQM1001_S03 설비 비가동 조회 호출 파라미터 등록
-- Create:  2026-11-26  한성수  프로시저 재작성 (6건 → 8건)
-- Modify:  2026-11-27  한성수  수리 이력 조회 공정(설비구분)·라인(설비대분류)·설비번호 추가 (8건 → 11건)
-- *****************************************************************************
-- EQM1001_S03 프로시저 저장 후 아래 트랜잭션을 실행
START TRANSACTION;
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_S03';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_S03';
COMMIT;

-- 정상 11건: SDATE 1번, EDATE 2번, LINECD 3번, PRCCD 4번, EQMCD 5번, NONGROUPCD1 6번, EQMTP 7번, EQMGROUP1 8번, FANO 9번, CALLTYPE 10번, KEYWORD 11번
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_S03'
ORDER BY ORDINAL_POSITION;
