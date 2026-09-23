-- *****************************************************************************
-- Comment: EQM1001_R05 프로그램·메뉴·권한 등록
-- Create:  2026-09-22  한성수  설비 정기점검 계획승인관리 화면 등록
-- *****************************************************************************
INSERT INTO SYSPRG (
  PRGCD, PRGNM, PKGTP,
  SEARCHYN, ADDYN, SAVEYN, DELETEYN, PRINTYN, EXPORTYN, HIDDENYN,
  PRGSTT, RATE, STRDT, ENDDT,
  CONFIRMYN, CONFIRMEMPCD, CONFIRMDT,
  REQUEST, DEV, ORI, MANUALYN, MANUALFILE, ORIPRGCD, ORIPRGNM, REMARK,
  RTIME, REMP, RPRG, MTIME, MEMP, MPRG
) VALUES (
  'EQM1001_R05', '설비 정기점검 계획승인관리', 'EQM',
  'Y', 'N', 'N', 'N', 'N', 'N', 'N',
  '30', 0, '', '',
  'N', '', '',
  '설비그룹·설비별 정기점검 계획 승인관리', '한성수', 'NEW', '', '', '', '', '',
  DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'), 'SYSTEM', 'EQM1001_R05_INIT', '', '', ''
) ON DUPLICATE KEY UPDATE
  PRGNM = VALUES(PRGNM),
  REQUEST = VALUES(REQUEST),
  DEV = VALUES(DEV),
  MTIME = DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'),
  MEMP = 'SYSTEM',
  MPRG = 'EQM1001_R05_INIT';

INSERT INTO SYSMENU (
  PKGTP, CATECD, PRGCD, MENUNM, SORTNO, REMARK,
  RTIME, REMP, RPRG, MTIME, MEMP, MPRG
) VALUES (
  'EQM', '30', 'EQM1001_R05', '설비 정기점검 계획승인관리', 5, '',
  DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'), 'SYSTEM', 'EQM1001_R05_INIT', '', '', ''
) ON DUPLICATE KEY UPDATE
  MENUNM = VALUES(MENUNM),
  SORTNO = VALUES(SORTNO),
  MTIME = DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'),
  MEMP = 'SYSTEM',
  MPRG = 'EQM1001_R05_INIT';

INSERT INTO SYSAUTPRG (
  INOUTTP, AUTCD, PRGCD,
  SEARCHYN, ADDYN, SAVEYN, DELETEYN, PRINTYN, EXPORTYN, FAXYN, REMARK,
  RTIME, REMP, RPRG, MTIME, MEMP, MPRG
) VALUES
(
  'IN', 'ADMIN', 'EQM1001_R05',
  'Y', 'N', 'N', 'N', 'N', 'N', 'N', '',
  DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'), 'SYSTEM', 'EQM1001_R05_INIT', '', '', ''
),
(
  'IN', 'MNG01', 'EQM1001_R05',
  'Y', 'N', 'N', 'N', 'N', 'N', 'N', '',
  DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'), 'SYSTEM', 'EQM1001_R05_INIT', '', '', ''
)
ON DUPLICATE KEY UPDATE
  SEARCHYN = VALUES(SEARCHYN),
  MTIME = DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'),
  MEMP = 'SYSTEM',
  MPRG = 'EQM1001_R05_INIT';
