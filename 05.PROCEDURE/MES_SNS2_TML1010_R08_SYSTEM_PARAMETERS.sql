-- *****************************************************************************
-- Comment: TML1010_R08 설비부품 입고등록 호출 파라미터 등록
-- Create:  2026-11-17  한성수  TML1010_R08 파라미터 등록 스크립트 신규 작성 (총 12건)
-- Modify:  2026-11-18  한성수  조회 조건 중요도등급 GRADE, 입고취소 INOUTKEY 추가 (총 14건)
-- *****************************************************************************

-- TML1010_R08 프로시저 저장 후 아래 쿼리를 실행하여 SYSTEM_PARAMETERS에 등록
START TRANSACTION;

DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'TML1010_R08';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT *
FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'TML1010_R08';

COMMIT;

-- 파라미터 정상 등록 확인 (총 14건)
SELECT ORDINAL_POSITION,
       PARAMETER_NAME,
       DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'TML1010_R08'
ORDER BY ORDINAL_POSITION;
