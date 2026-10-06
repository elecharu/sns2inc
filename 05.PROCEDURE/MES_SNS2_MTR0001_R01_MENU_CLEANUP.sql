-- *****************************************************************************
-- Comment: MTR0001_R01 메뉴 재등록을 위한 기존 메뉴 데이터 정리
-- Create:  2026-10-06  Codex  삭제 대상 조회 및 메뉴 데이터 삭제 SQL 작성
-- Modify:  2026-10-06  Codex  프로그램 기본정보와 권한을 유지하고 해당 메뉴만 삭제
-- *****************************************************************************

-- 먼저 이 조회문만 실행하여 기존 행이 삭제할 더미 데이터인지 확인
SELECT *
FROM MES_SNS2.SYSMENU
WHERE PRGCD = 'MTR0001_R01';

-- 확인한 더미 메뉴 삭제: 아래 블록은 별도로 실행
START TRANSACTION;

DELETE FROM MES_SNS2.SYSMENU
WHERE PRGCD = 'MTR0001_R01';

SELECT ROW_COUNT() AS DELETE_CNT;

SELECT COUNT(*) AS REMAIN_CNT
FROM MES_SNS2.SYSMENU
WHERE PRGCD = 'MTR0001_R01';

COMMIT;
