-- *****************************************************************************
-- Comment: MST3001_R03 설비부품정보 호출 파라미터 등록
-- Create:  2026-10-12  한성수
-- Modify:  2026-10-13  한성수  로케이션 코드 수정용 $OLD_LOCACD_LIST 반영 (총 13건)
--          2026-10-14  한성수  중요도등급 $GRADE_LIST 반영 (총 14건)
-- *****************************************************************************

-- MST3001_R03 프로시저 저장 후 아래 쿼리를 실행하여 SYSTEM_PARAMETERS에 등록
START TRANSACTION;

DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'MST3001_R03';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * 
FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'MST3001_R03';

COMMIT;

-- 파라미터 정상 등록 확인 (총 14건)
SELECT ORDINAL_POSITION,
       PARAMETER_NAME,
       DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'MST3001_R03'
ORDER BY ORDINAL_POSITION;
