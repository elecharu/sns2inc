-- *****************************************************************************
-- Comment: 점검실적에 적용 설비그룹 REV 키 추가
-- Create:  2026-10-08  한성수
-- *****************************************************************************
ALTER TABLE MES_SNS2.CHKRSTEQM
  ADD COLUMN IF NOT EXISTS GRPREVCD VARCHAR(20) NOT NULL DEFAULT '' COMMENT '적용 설비그룹 리비전키' AFTER REVCD;
