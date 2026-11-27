-- 2026-11-27 불량코드별 연결 검사항목 (치수 불량 '외경' → 자주검사 검사항목 '외경' 등)
--   현장 생산실적등록(TML2010_R01) 불량등록 때, 생산품의 자주검사 기준(MSTRPTREV_DETAIL) 중 연결된 검사항목 줄을 불량상세 목록으로 보여준다
--   관리 화면: 불량코드관리(MST1003_R03) 오른쪽 그리드
CREATE TABLE MES_SNS2.MSTBAD_STD (
  BADCD VARCHAR(10) NOT NULL DEFAULT '' COMMENT '불량코드 (MSTBAD)',
  STDCD VARCHAR(100) NOT NULL DEFAULT '' COMMENT '검사항목코드 (MSTSTD)',
  RTIME VARCHAR(19) NOT NULL DEFAULT '' COMMENT '등록시간',
  REMP VARCHAR(20) NOT NULL DEFAULT '' COMMENT '등록자',
  RPRG VARCHAR(100) NOT NULL DEFAULT '' COMMENT '등록프로그램',
  PRIMARY KEY (BADCD, STDCD)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci
COMMENT = '불량코드별 연결 검사항목 (불량상세 목록용)'
ROW_FORMAT = DYNAMIC;
