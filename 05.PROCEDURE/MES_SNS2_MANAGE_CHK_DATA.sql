-- *****************************************************************************
-- Comment: 설비점검(EQM1001_R02) 공통코드 및 테스트 데이터 조회 / 삭제 스크립트
-- Create: 2026-09-15 점검 관련 공통코드(COMTYPE/COMTYPEGP) 및 점검항목(MSTCHKKND) 관리용
-- *****************************************************************************
USE `MES_SNS2`;

-- =============================================================================
-- [1] 데이터 조회 (SELECT)
-- =============================================================================

-- 1-1. 공통코드 그룹(COMTYPEGP) 5종 조회
-- CHKLOC(설비점검항목), CHKTP(점검유형), CHKMTH(점검방법), CHKCYCLE(점검주기), CHKVALTP(점검값유형)
SELECT GPCD, GPNM, SYSYN, OPENYN, USEYN, REMARK, RTIME, REMP
  FROM COMTYPEGP 
 WHERE GPCD IN ('CHKLOC', 'CHKTP', 'CHKMTH', 'CHKCYCLE', 'CHKVALTP')
 ORDER BY GPCD;

-- 1-2. 공통코드 상세(COMTYPE) 34건 조회
SELECT GPCD, TPCD, TPNM, SORTNO, USEYN, REF01, REF02, REMARK, RTIME, REMP
  FROM COMTYPE 
 WHERE GPCD IN ('CHKLOC', 'CHKTP', 'CHKMTH', 'CHKCYCLE', 'CHKVALTP')
 ORDER BY GPCD, SORTNO, TPCD;

-- 1-3. 설비점검항목 마스터(MSTCHKKND) 등록 데이터 조회 (화면 및 테스트 데이터)
SELECT CHKKNDCD, CHKKNDNM, CHKTP, CHKLOC, CHKMTH, CHKCYCLE, CHKVALTP, SORTNO, USEYN, REMARK, RTIME, REMP
  FROM MSTCHKKND
 ORDER BY CHKTP, SORTNO, CHKKNDCD;


-- =============================================================================
-- [2] 데이터 삭제 (DELETE)
-- ※ 주의사항:
--   1. 외래키(FK_COMTYPE_COMTYPEGP)가 걸려 있으므로 상세(COMTYPE)를 먼저 삭제한 후
--      그룹(COMTYPEGP)을 삭제해야 오류가 발생하지 않습니다.
--   2. 공통코드를 삭제하면 EQM1001_R02 화면 로드 시 다시 SQL 문법 에러(near 'CHKLOC')가
--      발생하므로, 원복 또는 초기화 목적으로만 신중히 실행하세요.
--   3. 필요 시 각 명령문의 주석(--)을 해제하여 실행하세요.
-- =============================================================================

-- 2-1. [선택] 설비점검항목 마스터(MSTCHKKND) 테스트 데이터만 삭제
-- DELETE FROM MSTCHKKND WHERE CHKKNDCD IN ('001', '002', '003', '004', '005', '006');
-- 또는 'TEST' 키워드가 들어간 항목 삭제:
-- DELETE FROM MSTCHKKND WHERE CHKKNDNM LIKE '%TEST%';

-- 2-2. [필수 순서 1] 공통코드 상세(COMTYPE) 점검 관련 코드 34건 삭제
-- DELETE FROM COMTYPE 
--  WHERE GPCD IN ('CHKLOC', 'CHKTP', 'CHKMTH', 'CHKCYCLE', 'CHKVALTP');

-- 2-3. [필수 순서 2] 공통코드 그룹(COMTYPEGP) 점검 관련 그룹 5종 삭제
-- DELETE FROM COMTYPEGP 
--  WHERE GPCD IN ('CHKLOC', 'CHKTP', 'CHKMTH', 'CHKCYCLE', 'CHKVALTP');
