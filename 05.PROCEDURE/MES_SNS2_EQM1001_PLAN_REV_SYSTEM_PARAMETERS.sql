-- *****************************************************************************
-- Comment: EQM1001_R05·R04 COMCALLC 파라미터 메타데이터 재등록
-- Create:  2026-09-30  한성수  점검계획 리비전(REV) 관리 입력값 추가에 따른 재등록 (R05: $REVNUM·$REMARK, R04: $REVNUM)
-- Modify:  2026-10-01  한성수  R04 입력값 이름 변경 ($REVNUM → $REVCD)에 따른 재등록, 백업본은 없을 때만 생성
-- 			2026-10-06  한성수  R03 개정 이력 파라미터 별도 등록 안내
-- *****************************************************************************
-- 백업본 생성은 프로시저 교체 전에, 삭제·재등록은 각 프로시저 교체 직후에 실행합니다.
-- 이미 실행한 DB에서 리비전 키(REVCD) 전환만 하는 경우 EQM1001_R04 부분만 다시 실행합니다. (R05 입력값은 변경 없음)
-- R03 개정 이력 입력값은 MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql로 별도 재등록합니다.

-- *****************************************************************************
-- EQM1001_R05

-- 백업본 생성 (프로시저 교체 전)
CREATE TABLE IF NOT EXISTS MES_SNS2.SYSTEM_PARAMETERS_BAK_EQM1001_R05 AS
SELECT * FROM MES_SNS2.SYSTEM_PARAMETERS
 WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
   AND SPECIFIC_NAME = 'EQM1001_R05';

-- 등록된 파라미터 삭제 (프로시저 교체 직후)
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
 WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
   AND SPECIFIC_NAME = 'EQM1001_R05';

-- 새로운 파라미터 생성
REPLACE INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT *
  FROM information_schema.PARAMETERS
 WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
   AND SPECIFIC_NAME = 'EQM1001_R05';

-- 파라미터 확인 (10건: 7번 $REVNUM, 8번 $REMARK, 9번 $CALLTYPE, 10번 $KEYWORD)
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
  FROM MES_SNS2.SYSTEM_PARAMETERS
 WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
   AND SPECIFIC_NAME = 'EQM1001_R05'
 ORDER BY ORDINAL_POSITION;

-- *****************************************************************************
-- EQM1001_R04

-- 백업본 생성 (프로시저 교체 전)
CREATE TABLE IF NOT EXISTS MES_SNS2.SYSTEM_PARAMETERS_BAK_EQM1001_R04 AS
SELECT * FROM MES_SNS2.SYSTEM_PARAMETERS
 WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
   AND SPECIFIC_NAME = 'EQM1001_R04';

-- 등록된 파라미터 삭제 (프로시저 교체 직후)
DELETE FROM MES_SNS2.SYSTEM_PARAMETERS
 WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
   AND SPECIFIC_NAME = 'EQM1001_R04';

-- 새로운 파라미터 생성
REPLACE INTO MES_SNS2.SYSTEM_PARAMETERS
SELECT *
  FROM information_schema.PARAMETERS
 WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
   AND SPECIFIC_NAME = 'EQM1001_R04';

-- 파라미터 확인 (22건: 16번 $REVCD, 21번 $CALLTYPE, 22번 $KEYWORD)
SELECT ORDINAL_POSITION, PARAMETER_NAME, DATA_TYPE
  FROM MES_SNS2.SYSTEM_PARAMETERS
 WHERE SPECIFIC_SCHEMA = 'MES_SNS2'
   AND SPECIFIC_NAME = 'EQM1001_R04'
 ORDER BY ORDINAL_POSITION;

-- *****************************************************************************
-- 되돌릴 때 (프로시저를 백업본으로 되돌린 뒤 실행)
-- DELETE FROM MES_SNS2.SYSTEM_PARAMETERS WHERE SPECIFIC_SCHEMA = 'MES_SNS2' AND SPECIFIC_NAME = 'EQM1001_R05';
-- INSERT INTO MES_SNS2.SYSTEM_PARAMETERS SELECT * FROM MES_SNS2.SYSTEM_PARAMETERS_BAK_EQM1001_R05;
-- DELETE FROM MES_SNS2.SYSTEM_PARAMETERS WHERE SPECIFIC_SCHEMA = 'MES_SNS2' AND SPECIFIC_NAME = 'EQM1001_R04';
-- INSERT INTO MES_SNS2.SYSTEM_PARAMETERS SELECT * FROM MES_SNS2.SYSTEM_PARAMETERS_BAK_EQM1001_R04;
