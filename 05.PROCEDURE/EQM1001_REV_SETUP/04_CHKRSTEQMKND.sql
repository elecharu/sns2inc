-- *****************************************************************************
-- Comment: 점검실적 항목의 그룹·설비 출처 및 PK 구성
-- Create:  2026-10-08  한성수
-- *****************************************************************************
ALTER TABLE MES_SNS2.CHKRSTEQMKND
  ADD COLUMN IF NOT EXISTS PLANTP CHAR(1) NOT NULL DEFAULT '' COMMENT 'G: 그룹, E: 설비, 빈 값: 기존실적' AFTER CHKRSTKEY,
  DROP PRIMARY KEY,
  ADD PRIMARY KEY (CHKRSTKEY, PLANTP, CHKKNDCD);
