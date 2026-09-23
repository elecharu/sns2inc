-- *****************************************************************************
-- Comment: 설비점검계획 승인 상태 테이블
-- Create:  2026-09-22  한성수  설비그룹·설비별 정기점검 계획 승인관리 신규 생성
-- *****************************************************************************
CREATE TABLE IF NOT EXISTS `MES_SNS2`.`EQMPLAN_APRV` (
  `PLANTP`     CHAR(1)       NOT NULL COMMENT 'G: 설비그룹, E: 설비',
  `PLANCD`     VARCHAR(50)   NOT NULL COMMENT '설비그룹코드 또는 설비코드',
  `APRVSTT`    CHAR(1)       NOT NULL DEFAULT 'P' COMMENT 'P: 대기, A: 승인, R: 반려',
  `REQTIME`    VARCHAR(19)   NOT NULL,
  `REQEMP`     VARCHAR(20)   NOT NULL,
  `REQPRG`     VARCHAR(100)  NOT NULL,
  `APRVTIME`   VARCHAR(19)   NOT NULL DEFAULT '',
  `APRVEMP`    VARCHAR(20)   NOT NULL DEFAULT '',
  `APRVPRG`    VARCHAR(100)  NOT NULL DEFAULT '',
  `REJREASON`  VARCHAR(1000) NOT NULL DEFAULT '',
  `RTIME`      VARCHAR(19)   NOT NULL,
  `REMP`       VARCHAR(20)   NOT NULL,
  `RPRG`       VARCHAR(100)  NOT NULL,
  `MTIME`      VARCHAR(19)   NOT NULL DEFAULT '',
  `MEMP`       VARCHAR(20)   NOT NULL DEFAULT '',
  `MPRG`       VARCHAR(100)  NOT NULL DEFAULT '',
  PRIMARY KEY (`PLANTP`, `PLANCD`),
  KEY `IX_EQMPLAN_APRV_STT` (`APRVSTT`, `PLANTP`, `PLANCD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='설비 정기점검 계획 승인 상태';
