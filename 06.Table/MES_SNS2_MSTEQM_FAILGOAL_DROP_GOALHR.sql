-- *****************************************************************************
-- Comment: 설비고장율 설비별 목표 테이블 GOALHR(년 목표 비가동시간) 컬럼 삭제
-- Create:  2026-11-27  한성수
-- *****************************************************************************
-- 설비고장율 현황(EQM1001_S05)은 설비 목표 중 목표 점유율만 사용, 설비 년 목표 비가동시간은 어디에도 쓰지 않음
-- MST1006_R01 프로시저를 먼저 저장한 뒤 실행 (이전 프로시저는 이 컬럼을 조회하므로 삭제 후 오류)
-- 입력되어 있던 설비 년 목표 비가동시간 값은 함께 지워짐 (목표 점유율은 그대로)
ALTER TABLE MES_SNS2.MSTEQM_FAILGOAL
  DROP COLUMN GOALHR;

-- 확인: GOALHR 없이 SYEAR, FANO, GOALRATE, RTIME ~ MPRG
SELECT COLUMN_NAME, COLUMN_TYPE, COLUMN_COMMENT
FROM information_schema.COLUMNS
WHERE TABLE_SCHEMA = 'MES_SNS2'
  AND TABLE_NAME = 'MSTEQM_FAILGOAL'
ORDER BY ORDINAL_POSITION;
