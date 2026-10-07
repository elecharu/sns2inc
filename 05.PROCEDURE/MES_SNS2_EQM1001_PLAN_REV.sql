-- *****************************************************************************
-- Comment: 설비점검계획 REV·승인 관리 테이블 생성 및 점검실적 적용 리비전 컬럼 추가
-- Create:  2026-09-30  한성수  설비그룹·설비별 정기점검 계획 REV 관리 신규 생성
-- Modify:  2026-10-01  한성수  리비전 키(REVCD) PK 적용 (헤더: REVCD, 디테일: REVCD·CHKKNDCD), 점검실적 적용 리비전을 REVCD로 변경
-- Modify:  2026-10-06  한성수  승인 상태 REV 헤더 통합, 구 승인 테이블 이름 변경 제거; DETAIL은 REVCD로 HEADER 정보 참조
-- *****************************************************************************
CREATE TABLE IF NOT EXISTS `MES_SNS2`.`MSTEQMREV_HEADER` (
  `REVCD`      varchar(20)    NOT NULL DEFAULT '' COMMENT '리비전키 (GETKEY(''REVCD''))',
  `PLANTP`     char(1)        NOT NULL DEFAULT '' COMMENT 'G: 설비그룹, E: 설비',
  `PLANCD`     varchar(50)    NOT NULL DEFAULT '' COMMENT '설비그룹코드 또는 설비코드',
  `REVNUM`     int(11)        NOT NULL DEFAULT 0  COMMENT '리비전 번호 (0: 제정)',
  `APRVSTT`    char(1)        NOT NULL DEFAULT '' COMMENT '빈 값: 대기, A: 승인, R: 반려',
  `REMARK`     varchar(1000)  NOT NULL DEFAULT '' COMMENT '개정내용',
  `REQTIME`    varchar(19)    NOT NULL DEFAULT '' COMMENT '요청일시',
  `REQEMP`     varchar(20)    NOT NULL DEFAULT '' COMMENT '요청자',
  `REQPRG`     varchar(100)   NOT NULL DEFAULT '' COMMENT '요청프로그램',
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
  PRIMARY KEY (`REVCD`),
  UNIQUE KEY `UX_MSTEQMREV_HEADER_REV` (`PLANTP`, `PLANCD`, `REVNUM`),
  KEY `IX_MSTEQMREV_HEADER_STT` (`PLANTP`, `APRVSTT`, `PLANCD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='설비점검계획 리비전 관리(헤더)';

CREATE TABLE IF NOT EXISTS `MES_SNS2`.`MSTEQMREV_DETAIL` (
  `REVCD`      varchar(20)    NOT NULL DEFAULT '' COMMENT '리비전키',
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
  PRIMARY KEY (`REVCD`, `CHKKNDCD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='설비점검계획 리비전 관리(디테일)';

ALTER TABLE `MES_SNS2`.`CHKRSTEQM`
  ADD COLUMN IF NOT EXISTS `REVCD` varchar(20) NULL DEFAULT NULL COMMENT '적용 설비 리비전키' AFTER `CHKCYCLE`;

