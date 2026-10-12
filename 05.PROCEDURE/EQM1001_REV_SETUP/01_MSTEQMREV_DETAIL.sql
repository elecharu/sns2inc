-- *****************************************************************************
-- Comment: 초기화된 REV DETAIL의 불필요한 컬럼 제거
-- Create:  2026-10-08  한성수
-- *****************************************************************************
-- 00_CHECK.sql에서 DETAIL 0건 확인 후 아래 ALTER 한 문장 실행
ALTER TABLE MES_SNS2.MSTEQMREV_DETAIL
  DROP COLUMN IF EXISTS USEYN,
  DROP COLUMN IF EXISTS PLANTP,
  DROP COLUMN IF EXISTS PLANCD,
  DROP COLUMN IF EXISTS REVNUM,
  DROP COLUMN IF EXISTS EQMCD;
