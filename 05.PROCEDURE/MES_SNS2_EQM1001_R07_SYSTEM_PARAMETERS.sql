-- *****************************************************************************
-- Comment: EQM1001_R07 신규 생성 후 호출 파라미터 등록
-- Create:  2026-11-16  한성수
-- Modify:  2026-11-17  한성수  예방보전 점검(CHKTP '03') 조회·등록·수정·삭제 파라미터 추가 후 재등록
-- *****************************************************************************
-- R07 프로시저 저장 후 아래 트랜잭션을 실행
START TRANSACTION;
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_R07';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_R07';
COMMIT;

-- 정상 19건: SDATE~REMARK_LIST 1~17번, CALLTYPE 18번, KEYWORD 19번
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'EQM1001_R07'
ORDER BY ORDINAL_POSITION;
