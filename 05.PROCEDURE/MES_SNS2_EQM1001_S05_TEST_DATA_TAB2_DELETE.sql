-- *****************************************************************************
-- Comment: EQM1001_S05 탭2(설비별 고장현황) 확인용 테스트 데이터 되돌리기 (MES_SNS2_EQM1001_S05_TEST_DATA_TAB2_INSERT.sql 로 바꾼 것)
-- Create:  2026-11-26  한성수
-- *****************************************************************************
-- 탭2 로 추가한 직접 수리 삭제, 탭1 테스트 수리는 공무작업일지 미작성 상태로 되돌림 (탭1 테스트 데이터 자체는 그대로)
-- 탭1 테스트 데이터까지 모두 지우려면 이어서 MES_SNS2_EQM1001_S05_TEST_DATA_DELETE.sql 실행
START TRANSACTION;

DELETE FROM MES_SNS2.EQMREP
WHERE EQMREPKEY LIKE 'TESTS05W-%'
  AND RPRG = 'TEST_S05';

UPDATE MES_SNS2.EQMREP
SET WORKTP = ''
WHERE EQMREPKEY LIKE 'TESTS05-%'
  AND RPRG = 'TEST_S05';

COMMIT;

-- 확인 (추가 직접 수리 0건, 일지 작성 0건)
SELECT 'TAB2 직접 수리' AS GUBUN, COUNT(*) AS CNT FROM MES_SNS2.EQMREP WHERE EQMREPKEY LIKE 'TESTS05W-%' AND RPRG = 'TEST_S05'
UNION ALL SELECT '일지 작성', COUNT(*) FROM MES_SNS2.EQMREP WHERE EQMREPKEY LIKE 'TESTS05-%' AND RPRG = 'TEST_S05' AND WORKTP <> '';
