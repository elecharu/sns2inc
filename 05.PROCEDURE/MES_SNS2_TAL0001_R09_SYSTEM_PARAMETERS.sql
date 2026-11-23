-- *****************************************************************************
-- Comment: TAL0001_R09 설비부품 출고등록(태블릿) 호출 파라미터 재등록
-- Create:  2026-11-20  한성수  TML1010_R05와 같은 워크플로우 변경으로 라인·설비·출고키·로케이션·중요도등급 파라미터 5개 추가 (9건 → 14건)
-- *****************************************************************************
-- R09 프로시저 전체 저장 후 아래 트랜잭션을 실행
START TRANSACTION;
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'TAL0001_R09';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'TAL0001_R09';
COMMIT;

-- 정상 14건: EQMGROUP1 8번, EQMCD 9번, INOUTKEY 10번, LOCACD 11번, GRADE 12번, CALLTYPE 13번, KEYWORD 14번
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'TAL0001_R09'
ORDER BY ORDINAL_POSITION;
