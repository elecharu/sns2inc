-- *****************************************************************************
-- Comment: TML1010_R05 설비부품 입출고 재고관리 호출 파라미터 등록
-- Create:  2026-10-16  정다솔  TML1010_R05 파라미터 등록 스크립트 신규 작성 (총 18건)
-- Modify:  2026-10-16  한성수  발주 검색 거래처 유지 및 입고지 파라미터 제거 (총 19건)
--          2026-10-19  한성수  INC 2공장 고정 및 미사용 파라미터(ITEMCD/KEYWORD/REMARK) 제거 (총 15건)
-- *****************************************************************************

-- TML1010_R05 프로시저 저장 후 아래 쿼리를 실행하여 SYSTEM_PARAMETERS에 등록
START TRANSACTION;

DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'TML1010_R05';

INSERT INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT * 
FROM information_schema.PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'TML1010_R05';

COMMIT;

-- 파라미터 정상 등록 확인 (총 15건)
SELECT ORDINAL_POSITION,
       PARAMETER_NAME,
       DATA_TYPE
FROM MES_SNS2.SYSTEM_PARAMETERS
WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
  AND SPECIFIC_NAME   = 'TML1010_R05'
ORDER BY ORDINAL_POSITION;
