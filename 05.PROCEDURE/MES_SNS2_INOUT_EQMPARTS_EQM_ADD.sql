-- *****************************************************************************
-- Comment: 설비부품 입출고 이력(INOUT_EQMPARTS) 출고 라인·설비 컬럼 추가 (TML1010_R05 출고등록)
-- Create:  2026-11-18  한성수
-- *****************************************************************************
-- 순서: 1. 컬럼 없음 확인 → 2. 컬럼 추가 → 3. 결과 확인 → 4. TML1010_R05 프로시저 저장 → 5. MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql 실행
-- 참고: INOUT_EQMPARTS에 INSERT 하는 프로시저(TML1010_R08·TAL0001_R09)는 모두 컬럼을 지정하므로 기본값('')으로 들어감

-- 1. 컬럼 없음 확인 (0건이어야 함)
SELECT COLUMN_NAME
FROM information_schema.COLUMNS
WHERE TABLE_SCHEMA = 'MES_SNS2'
  AND TABLE_NAME = 'INOUT_EQMPARTS'
  AND COLUMN_NAME IN ('EQMGROUP1', 'EQMCD');

-- 2. 컬럼 추가 (처리자 다음)
ALTER TABLE MES_SNS2.INOUT_EQMPARTS
  ADD COLUMN EQMGROUP1 VARCHAR(100) NOT NULL DEFAULT '' COMMENT '라인' AFTER EMPCD,
  ADD COLUMN EQMCD VARCHAR(100) NOT NULL DEFAULT '' COMMENT '설비' AFTER EQMGROUP1;

-- 3. 결과 확인 (2건)
SELECT COLUMN_NAME, COLUMN_TYPE, COLUMN_DEFAULT, COLUMN_COMMENT
FROM information_schema.COLUMNS
WHERE TABLE_SCHEMA = 'MES_SNS2'
  AND TABLE_NAME = 'INOUT_EQMPARTS'
  AND COLUMN_NAME IN ('EQMGROUP1', 'EQMCD');

-- *****************************************************************************
-- 롤백 (필요할 때만, 아래 줄의 주석을 풀어서 실행)
-- 주의: 컬럼 삭제 전에 TML1010_R05 프로시저를 라인·설비를 쓰지 않는 이전 버전으로 먼저 되돌려야 함
--       (현재 프로시저는 출고 등록 시 EQMGROUP1·EQMCD에 저장하므로 컬럼이 없으면 출고 등록 오류)
--       삭제하면 이미 저장된 출고 라인·설비 값도 함께 사라짐
-- *****************************************************************************

-- R1. 롤백 전 저장된 라인·설비 건수 확인
-- SELECT COUNT(*) AS CNT
-- FROM MES_SNS2.INOUT_EQMPARTS
-- WHERE EQMGROUP1 <> '' OR EQMCD <> '';

-- R2. 컬럼 삭제
-- ALTER TABLE MES_SNS2.INOUT_EQMPARTS
--   DROP COLUMN EQMCD,
--   DROP COLUMN EQMGROUP1;

-- R3. 결과 확인 (0건)
-- SELECT COLUMN_NAME
-- FROM information_schema.COLUMNS
-- WHERE TABLE_SCHEMA = 'MES_SNS2'
--   AND TABLE_NAME = 'INOUT_EQMPARTS'
--   AND COLUMN_NAME IN ('EQMGROUP1', 'EQMCD');
