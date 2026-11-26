-- *****************************************************************************
-- Comment: EQM1001_S05 탭3(설비별 부품별 현황) 확인용 테스트 데이터 되돌리기 (MES_SNS2_EQM1001_S05_TEST_DATA_TAB3_INSERT.sql 로 넣은 고장부위 비우기)
-- Create:  2026-11-26  한성수
-- *****************************************************************************
-- 테스트 수리의 고장부위만 비움 (테스트 수리 자체는 탭2 → 탭1 되돌리기·삭제 SQL로 정리)
START TRANSACTION;

UPDATE MES_SNS2.EQMREP
SET FAILPART = ''
WHERE (EQMREPKEY LIKE 'TESTS05-%' OR EQMREPKEY LIKE 'TESTS05W-%')
  AND RPRG = 'TEST_S05';

COMMIT;

-- 확인 (고장부위 있는 테스트 수리 0건)
SELECT COUNT(*) AS CNT
FROM MES_SNS2.EQMREP
WHERE (EQMREPKEY LIKE 'TESTS05-%' OR EQMREPKEY LIKE 'TESTS05W-%')
  AND RPRG = 'TEST_S05'
  AND FAILPART <> '';
