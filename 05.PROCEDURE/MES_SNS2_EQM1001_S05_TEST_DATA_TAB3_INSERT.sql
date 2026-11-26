-- *****************************************************************************
-- Comment: EQM1001_S05 탭3(설비별 부품별 현황) 확인용 테스트 데이터 등록 (M16 작업장 / 열전 / T1, 2026년)
-- Create:  2026-11-26  한성수
-- *****************************************************************************
-- 먼저 탭1·탭2 테스트 데이터(MES_SNS2_EQM1001_S05_TEST_DATA_INSERT.sql, _TAB2_INSERT.sql)가 등록되어 있어야 함
-- 공무작업일지를 작성한 테스트 수리 31건에 2공장 고장부위(FM303, 공무작업일지 고장부위 목록 FM303I2__N)를 넣음
--   베어링1(모터) FM303I201N, 비접촉식센서 FM303I221N, 접촉식센서 FM303I222N, PLC 프로그램이상 FM303I239N,
--   컨베아 벨트 FM303I268N, 로보트 부품 FM303I247N, 기계부품교환(小) FM303I215N
--   탭2 직접 수리 2건(예방 정비)은 고장부위 없이 둠 → 그래프에 '고장부위 미입력'으로 표시
-- 되돌리기: MES_SNS2_EQM1001_S05_TEST_DATA_TAB3_DELETE.sql
-- *****************************************************************************
SET @NOW = DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s');

START TRANSACTION;

UPDATE MES_SNS2.EQMREP
SET FAILPART = CASE EQMREPKEY
                  WHEN 'TESTS05-0107-1' THEN 'FM303I201N'
                  WHEN 'TESTS05-0115-2' THEN 'FM303I239N'
                  WHEN 'TESTS05-0123-3' THEN 'FM303I215N'
                  WHEN 'TESTS05-0206-1' THEN 'FM303I222N'
                  WHEN 'TESTS05-0216-2' THEN 'FM303I247N'
                  WHEN 'TESTS05-0224-3' THEN 'FM303I221N'
                  WHEN 'TESTS05-0306-1' THEN 'FM303I268N'
                  WHEN 'TESTS05-0312-D' THEN 'FM303I201N'
                  WHEN 'TESTS05-0316-2' THEN 'FM303I239N'
                  WHEN 'TESTS05-0324-3' THEN 'FM303I215N'
                  WHEN 'TESTS05-0407-1' THEN 'FM303I222N'
                  WHEN 'TESTS05-0415-2' THEN 'FM303I247N'
                  WHEN 'TESTS05-0423-3' THEN 'FM303I221N'
                  WHEN 'TESTS05-0507-1' THEN 'FM303I268N'
                  WHEN 'TESTS05-0515-2' THEN 'FM303I201N'
                  WHEN 'TESTS05-0525-3' THEN 'FM303I239N'
                  WHEN 'TESTS05-0605-1' THEN 'FM303I215N'
                  WHEN 'TESTS05-0615-2' THEN 'FM303I222N'
                  WHEN 'TESTS05-0623-3' THEN 'FM303I247N'
                  WHEN 'TESTS05-0707-1' THEN 'FM303I221N'
                  WHEN 'TESTS05-0715-2' THEN 'FM303I268N'
                  WHEN 'TESTS05-0723-3' THEN 'FM303I201N'
                  WHEN 'TESTS05-0807-1' THEN 'FM303I239N'
                  WHEN 'TESTS05-0817-2' THEN 'FM303I215N'
                  WHEN 'TESTS05-0825-3' THEN 'FM303I222N'
                  WHEN 'TESTS05-0907-1' THEN 'FM303I247N'
                  WHEN 'TESTS05-0915-2' THEN 'FM303I221N'
                  WHEN 'TESTS05-0923-3' THEN 'FM303I268N'
                  WHEN 'TESTS05-1007-1' THEN 'FM303I201N'
                  WHEN 'TESTS05-1015-2' THEN 'FM303I239N'
                  WHEN 'TESTS05-1023-3' THEN 'FM303I215N'
                  ELSE FAILPART
               END,
    MTIME = @NOW,
    MEMP  = 'TEST',
    MPRG  = 'TEST_S05'
WHERE EQMREPKEY LIKE 'TESTS05-%'
  AND RPRG = 'TEST_S05'
  AND WORKTP <> ''
  AND REPSTIME < '2026-11-01';

COMMIT;

-- 확인 (고장부위별 건수, 7개 부위 31건)
SELECT FAILPART, GPCD('FM303', FAILPART) AS FAILPARTNM, COUNT(*) AS CNT
FROM MES_SNS2.EQMREP
WHERE EQMREPKEY LIKE 'TESTS05-%'
  AND RPRG = 'TEST_S05'
  AND FAILPART <> ''
GROUP BY FAILPART
ORDER BY FAILPART;
