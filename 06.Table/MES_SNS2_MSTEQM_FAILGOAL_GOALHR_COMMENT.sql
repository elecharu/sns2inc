-- *****************************************************************************
-- Comment: 설비고장율 라인별 목표 테이블 GOALHR 컬럼 정수형 변경 및 설명 변경 (월 목표 → 년 목표 비가동시간)
-- Create:  2026-11-26  한성수
-- Modify:  2026-11-27  한성수  DECIMAL(10, 1) → INT(11) 정수형 변경
-- *****************************************************************************
-- 이미 만든 MSTEQM_FAILGOAL_LINE 용: 자료형 DECIMAL(10, 1) → INT(11), 설명 변경
-- 실행 전 확인: 소수 값이 있는 목표 (결과가 없어야 함, 있으면 정수로 고친 뒤 실행)
SELECT SYEAR, LINECD, EQMTP, EQMGROUP1, GOALHR
FROM MES_SNS2.MSTEQM_FAILGOAL_LINE
WHERE GOALHR <> TRUNCATE(GOALHR, 0);

ALTER TABLE MES_SNS2.MSTEQM_FAILGOAL_LINE
  MODIFY COLUMN GOALHR INT(11) DEFAULT NULL COMMENT '년 목표 비가동시간(hr) (설비고장율 현황 년 목표 막대, 비우면 월 평균 가동시간 × 목표 점유율)';

-- 확인
SELECT TABLE_NAME, COLUMN_NAME, COLUMN_TYPE, COLUMN_COMMENT
FROM information_schema.COLUMNS
WHERE TABLE_SCHEMA = 'MES_SNS2'
  AND TABLE_NAME = 'MSTEQM_FAILGOAL_LINE'
  AND COLUMN_NAME = 'GOALHR';
