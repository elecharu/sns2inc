-- *****************************************************************************
-- Comment: TAL0001_R09 설비부품 출고등록(태블릿) 호출 파라미터 재등록
-- Create:  2026-11-20  한성수  TML1010_R05와 같은 워크플로우 변경으로 라인·설비·출고키·로케이션·중요도등급 파라미터 5개 추가 (9건 → 14건)
-- Modify:  2026-11-25  한성수  출고 팝업 작업장 조건 LINECD 추가 (14건 → 15건)
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

-- 정상 15건: LINECD 8번, EQMGROUP1 9번, EQMCD 10번, INOUTKEY 11번, LOCACD 12번, GRADE 13번, CALLTYPE 14번, KEYWORD 15번
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME = 'TAL0001_R09'
ORDER BY ORDINAL_POSITION;
