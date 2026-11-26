-- *****************************************************************************
-- Comment: EQM1001_S05 탭2(설비별 고장현황) 확인용 테스트 데이터 등록 (M16 작업장 / 열전 / T1, 2026년)
-- Create:  2026-11-26  한성수
-- *****************************************************************************
-- 먼저 탭1 테스트 데이터(MES_SNS2_EQM1001_S05_TEST_DATA_INSERT.sql)가 등록되어 있어야 함 (호출 수리·생산 작업·설비 매칭)
-- 등록·변경 데이터 (모두 RPRG 또는 MPRG = 'TEST_S05', 되돌리기는 MES_SNS2_EQM1001_S05_TEST_DATA_TAB2_DELETE.sql)
--   1) 탭1 테스트 수리 중 1 ~ 10월 호출 수리 30건 + 3월 직접 수리 1건을 공무작업일지 작성 상태로 변경
--      (작업구분 WORKTP 'FM300200' 사후(돌발보전)), 11월 호출 수리 3건(190분)은 일지 미작성으로 둠
--   2) 공무작업일지만 있는 직접 수리 2건 추가 (작업구분 'FM300100' 예방(계획보전))
--      6월 17일 I2U-019N 240분, 9월 16일 I2T-025N 180분
-- 예상 결과 (조회년도 2026, 작업장 M16, 공정 열전, 라인 T1, 라인 총가동 4,700hr)
--   총 라인 고장 시간 31.8hr / 0.68% (호출 수리 1,908분, 11월 미작성 포함)
--   I2M-005N 10.6hr / 0.22%, I2T-024N 4.8hr / 0.10%, I2T-025N 8.8hr / 0.19%, I2T-026N 6.3hr / 0.13%, I2U-019N 10.1hr / 0.21%
--   설비 합계 2,438분 = 호출 1,908분 - 11월 미작성 190분 + 직접 수리 720분
-- *****************************************************************************
SET @NOW = DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s');

START TRANSACTION;

-- 1) 1 ~ 10월 테스트 수리 공무작업일지 작성 상태로 변경
UPDATE MES_SNS2.EQMREP
SET WORKTP = 'FM300200',
    MTIME  = @NOW,
    MEMP   = 'TEST',
    MPRG   = 'TEST_S05'
WHERE EQMREPKEY LIKE 'TESTS05-%'
  AND RPRG = 'TEST_S05'
  AND REPSTIME < '2026-11-01';

-- 2) 공무작업일지만 있는 직접 수리 추가
INSERT INTO MES_SNS2.EQMREP (
  EQMREPKEY, EQMCALLKEY, EQMCD, EQMREPTP, WORKTP, REGTIME, REPSTIME, REPETIME,
  MALFUNCTION, REMARK, RTIME, REMP, RPRG
)
VALUES
  ('TESTS05W-0617-1', '', 'I2U-019N', 'EQM01', 'FM300100', '2026-06-17 13:00', '2026-06-17 13:00', '2026-06-17 17:00', '테스트 예방 정비', 'TEST_S05', @NOW, 'TEST', 'TEST_S05'),
  ('TESTS05W-0916-1', '', 'I2T-025N', 'EQM01', 'FM300100', '2026-09-16 13:00', '2026-09-16 13:00', '2026-09-16 16:00', '테스트 예방 정비', 'TEST_S05', @NOW, 'TEST', 'TEST_S05');

COMMIT;

-- 확인 (작성 31건, 미작성 3건, 추가 직접 수리 2건)
SELECT IF(WORKTP = '', '일지 미작성', '일지 작성') AS GUBUN, COUNT(*) AS CNT
FROM MES_SNS2.EQMREP
WHERE (EQMREPKEY LIKE 'TESTS05-%' OR EQMREPKEY LIKE 'TESTS05W-%')
  AND RPRG = 'TEST_S05'
GROUP BY IF(WORKTP = '', '일지 미작성', '일지 작성');
