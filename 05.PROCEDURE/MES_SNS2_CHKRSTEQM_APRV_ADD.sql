-- *****************************************************************************
-- Comment: 설비점검 실적(CHKRSTEQM) 승인자·승인일시 컬럼 추가 (EQM1001_S04 승인·승인취소)
-- Create:  2026-11-16  한성수
-- *****************************************************************************
-- 순서: 1. 컬럼 없음 확인 → 2. 컬럼 추가 → 3. 결과 확인 → 4. EQM1001_S04 프로시저 저장 → 5. MES_SNS2_EQM1001_S04_SYSTEM_PARAMETERS.sql 실행
-- 참고: CHKRSTEQM에 INSERT 하는 프로시저(EQM1001_R04·TAL0001_R05·TAL0001_R08)는 모두 컬럼을 지정하므로 기본값('')으로 들어감

-- 1. 컬럼 없음 확인 (0건이어야 함)
SELECT COLUMN_NAME
FROM information_schema.COLUMNS
WHERE TABLE_SCHEMA = 'MES_SNS2'
  AND TABLE_NAME = 'CHKRSTEQM'
  AND COLUMN_NAME IN ('APRVEMP', 'APRVTIME');

-- 2. 컬럼 추가 (비고 다음)
ALTER TABLE MES_SNS2.CHKRSTEQM
  ADD COLUMN APRVEMP VARCHAR(20) NOT NULL DEFAULT '' COMMENT '승인자' AFTER REMARK,
  ADD COLUMN APRVTIME VARCHAR(19) NOT NULL DEFAULT '' COMMENT '승인일시' AFTER APRVEMP;

-- 3. 결과 확인 (2건)
SELECT COLUMN_NAME, COLUMN_TYPE, COLUMN_DEFAULT, COLUMN_COMMENT
FROM information_schema.COLUMNS
WHERE TABLE_SCHEMA = 'MES_SNS2'
  AND TABLE_NAME = 'CHKRSTEQM'
  AND COLUMN_NAME IN ('APRVEMP', 'APRVTIME');
