-- *****************************************************************************
-- Comment: 초기화된 승인이력의 APRVKEY·REVCD 및 PK 구성
-- Create:  2026-10-08  한성수
-- *****************************************************************************
-- 00_CHECK.sql에서 승인이력 0건 확인 후 아래 ALTER 한 문장 실행
ALTER TABLE MES_SNS2.CHKPLANEQM_APRV
  ADD COLUMN IF NOT EXISTS APRVKEY VARCHAR(20) NOT NULL DEFAULT '' COMMENT '승인이력키' FIRST,
  ADD COLUMN IF NOT EXISTS REVCD VARCHAR(20) NOT NULL DEFAULT '' COMMENT '리비전키' AFTER APRVKEY,
  DROP PRIMARY KEY,
  DROP COLUMN IF EXISTS APRVID,
  DROP INDEX IF EXISTS IX_EQMPLAN_APRV_REV,
  ADD PRIMARY KEY (APRVKEY),
  ADD INDEX IX_EQMPLAN_APRV_REV (REVCD, APRVTIME, APRVKEY);
