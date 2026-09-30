-- *****************************************************************************
-- Comment: 설비점검계획 리비전 관리 테이블 생성, 점검실적 적용 리비전 컬럼 추가, 승인 테이블 이름 변경
-- Create:  2026-09-30  한성수  설비그룹·설비별 정기점검 계획 REV 관리 신규 생성
-- *****************************************************************************
CREATE TABLE IF NOT EXISTS `MES_SNS2`.`MSTEQMREV_HEADER` (
  `PLANTP`     char(1)        NOT NULL DEFAULT '' COMMENT 'G: 설비그룹, E: 설비',
  `PLANCD`     varchar(50)    NOT NULL DEFAULT '' COMMENT '설비그룹코드 또는 설비코드',
  `REVNUM`     int(11)        NOT NULL DEFAULT 0  COMMENT '리비전 번호 (0: 제정)',
  `APRVSTT`    char(1)        NOT NULL DEFAULT '' COMMENT '빈 값: 대기, A: 승인, R: 반려',
  `REMARK`     varchar(1000)  NOT NULL DEFAULT '' COMMENT '개정내용',
  `REQTIME`    varchar(19)    NOT NULL DEFAULT '' COMMENT '수정시간',
  `REQEMP`     varchar(20)    NOT NULL DEFAULT '' COMMENT '작성자',
  `REQPRG`     varchar(100)   NOT NULL DEFAULT '' COMMENT '수정프로그램',
  `APRVTIME`   varchar(19)    NOT NULL DEFAULT '' COMMENT '승인·반려 처리시간',
  `APRVEMP`    varchar(20)    NOT NULL DEFAULT '' COMMENT '승인자',
  `APRVPRG`    varchar(100)   NOT NULL DEFAULT '' COMMENT '처리프로그램',
  `REJREASON`  varchar(1000)  NOT NULL DEFAULT '' COMMENT '반려사유',
  `RTIME`      varchar(19)    NOT NULL DEFAULT '' COMMENT '등록시간',
  `REMP`       varchar(20)    NOT NULL DEFAULT '' COMMENT '등록자',
  `RPRG`       varchar(100)   NOT NULL DEFAULT '' COMMENT '등록프로그램',
  `MTIME`      varchar(19)    NOT NULL DEFAULT '' COMMENT '수정시간',
  `MEMP`       varchar(20)    NOT NULL DEFAULT '' COMMENT '수정자',
  `MPRG`       varchar(100)   NOT NULL DEFAULT '' COMMENT '수정프로그램',
  PRIMARY KEY (`PLANTP`, `PLANCD`, `REVNUM`),
  KEY `IX_MSTEQMREV_HEADER_STT` (`PLANTP`, `APRVSTT`, `PLANCD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='설비점검계획 리비전 관리(헤더)';

CREATE TABLE IF NOT EXISTS `MES_SNS2`.`MSTEQMREV_DETAIL` (
  `PLANTP`     char(1)        NOT NULL DEFAULT '' COMMENT 'G: 설비그룹, E: 설비',
  `PLANCD`     varchar(50)    NOT NULL DEFAULT '' COMMENT '설비그룹코드 또는 설비코드',
  `REVNUM`     int(11)        NOT NULL DEFAULT 0  COMMENT '승인된 리비전 번호',
  `EQMCD`      varchar(20)    NOT NULL DEFAULT '' COMMENT '설비코드',
  `CHKKNDCD`   varchar(20)    NOT NULL DEFAULT '' COMMENT '항목키',
  `CHKCYCLE`   varchar(10)    NOT NULL DEFAULT '' COMMENT '점검주기',
  `SORTNO`     decimal(20,0)  NOT NULL DEFAULT 0  COMMENT '정렬순서',
  `CHKKNDNM`   varchar(1000)  NOT NULL DEFAULT '' COMMENT '승인 당시 점검명',
  `CHKLOC`     varchar(1000)  NOT NULL DEFAULT '' COMMENT '승인 당시 점검항목',
  `CHKMTH`     varchar(1000)  NOT NULL DEFAULT '' COMMENT '승인 당시 점검방법',
  `CHKVALTP`   varchar(10)    NOT NULL DEFAULT '' COMMENT '승인 당시 점검값구분',
  `REMARK`     varchar(1000)  NOT NULL DEFAULT '' COMMENT '비고',
  `RTIME`      varchar(19)    NOT NULL DEFAULT '' COMMENT '등록시간',
  `REMP`       varchar(20)    NOT NULL DEFAULT '' COMMENT '등록자',
  `RPRG`       varchar(100)   NOT NULL DEFAULT '' COMMENT '등록프로그램',
  `MTIME`      varchar(19)    NOT NULL DEFAULT '' COMMENT '수정시간',
  `MEMP`       varchar(20)    NOT NULL DEFAULT '' COMMENT '수정자',
  `MPRG`       varchar(100)   NOT NULL DEFAULT '' COMMENT '수정프로그램',
  PRIMARY KEY (`PLANTP`, `PLANCD`, `REVNUM`, `EQMCD`, `CHKKNDCD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='설비점검계획 리비전 관리(디테일)';

ALTER TABLE `MES_SNS2`.`CHKRSTEQM`
  ADD COLUMN IF NOT EXISTS `REVNUM` int(11) NULL DEFAULT NULL COMMENT '적용 설비 리비전 번호' AFTER `CHKCYCLE`;

RENAME TABLE `MES_SNS2`.`EQMPLAN_APRV` TO `MES_SNS2`.`CHKPLANEQM_APRV`;
ALTER TABLE `MES_SNS2`.`CHKPLANEQM_APRV` COMMENT = '설비점검계획 승인 관리';
