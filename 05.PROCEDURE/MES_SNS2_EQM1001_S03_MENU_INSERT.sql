-- *****************************************************************************
-- Comment: EQM1001_S03 설비 비가동 조회 프로그램·메뉴 등록 (생산기술보전팀 > 설비고장/수리)
-- Create:  2026-11-26  한성수
-- *****************************************************************************
-- 메뉴관리(SYS0001_R03) 화면추가(ADD_WEBPRG)와 같은 내용을 등록
--   SYSPRG    1건 : 프로그램명 '설비 비가동 조회', 작업상태 30(진행), 작업자 한성수, 출처 NEW
--   SYSAUTPRG 4건 : IN MNG01, IN ADMIN, IN ALL, OUT ALL (조회권한 Y, 나머지 N)
--   SYSMENU   1건 : 생산기술보전팀(EQM) > 설비고장/수리(40), 정렬순서 6 (MTBF/MTTR 다음, 맨 아래)
-- 이미 있는 행은 건너뜀 (다시 실행해도 중복 오류 없음), 순서 변경·삭제는 메뉴관리 화면에서
-- 실행 후 Office 다시 로그인하면 메뉴에 표시
-- *****************************************************************************
SET @NOW = DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s');
SET @EMP = 'admin';

START TRANSACTION;

INSERT IGNORE INTO MES_SNS2.SYSPRG (
  PRGCD, PRGNM, PKGTP, PRGSTT, DEV, ORI,
  RTIME, REMP, RPRG
) VALUES (
  'EQM1001_S03', '설비 비가동 조회', 'EQM', '30', '한성수', 'NEW',
  @NOW, @EMP, 'SYS0001_R03'
);

INSERT IGNORE INTO MES_SNS2.SYSAUTPRG (
  INOUTTP, AUTCD, PRGCD,
  RTIME, REMP, RPRG
) VALUES
  ('IN', 'MNG01', 'EQM1001_S03', @NOW, @EMP, 'SYS0001_R03'),
  ('IN', 'ADMIN', 'EQM1001_S03', @NOW, @EMP, 'SYS0001_R03'),
  ('IN', 'ALL', 'EQM1001_S03', @NOW, @EMP, 'SYS0001_R03'),
  ('OUT', 'ALL', 'EQM1001_S03', @NOW, @EMP, 'SYS0001_R03');

INSERT IGNORE INTO MES_SNS2.SYSMENU (
  PKGTP, CATECD, PRGCD, MENUNM, SORTNO,
  RTIME, REMP, RPRG
) VALUES (
  'EQM', '40', 'EQM1001_S03', '설비 비가동 조회', 6,
  @NOW, @EMP, 'SYS0001_R03'
);

COMMIT;

-- 확인 1 (정상: SYSPRG 1건, SYSAUTPRG 4건, SYSMENU 1건)
SELECT 'SYSPRG' AS TBL, COUNT(*) AS CNT FROM MES_SNS2.SYSPRG WHERE PRGCD = 'EQM1001_S03'
UNION ALL
SELECT 'SYSAUTPRG', COUNT(*) FROM MES_SNS2.SYSAUTPRG WHERE PRGCD = 'EQM1001_S03'
UNION ALL
SELECT 'SYSMENU', COUNT(*) FROM MES_SNS2.SYSMENU WHERE PRGCD = 'EQM1001_S03';

-- 확인 2 (설비고장/수리 메뉴 순서)
SELECT M.SORTNO, M.PRGCD, M.MENUNM, P.PRGSTT
FROM MES_SNS2.SYSMENU M
LEFT JOIN MES_SNS2.SYSPRG P
  ON P.PRGCD = M.PRGCD
WHERE M.PKGTP = 'EQM'
  AND M.CATECD = '40'
ORDER BY M.SORTNO;
