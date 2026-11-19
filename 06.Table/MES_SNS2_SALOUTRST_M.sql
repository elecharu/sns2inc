CREATE TABLE MES_SNS2.SALOUTRST_M (
  RSTMONTH VARCHAR(7) NOT NULL DEFAULT '' COMMENT '조회년월 (YYYY-MM, 수주일자 기준)',
  CUSTCD VARCHAR(20) NOT NULL DEFAULT '' COMMENT '거래처코드 (SALODR.CUSTCD)',
  ITEMID INT(11) NOT NULL DEFAULT 0 COMMENT '품목ID (SALODRD.ITEMID)',
  OUTCHGTP VARCHAR(20) NOT NULL DEFAULT '' COMMENT '변동사유 - 공통코드 OUTCHGTP (REF01 = Y 이면 판매계획 조정 대상)',
  NOOUTCAUSE VARCHAR(1000) NOT NULL DEFAULT '' COMMENT '미출고 원인',
  MEASURE VARCHAR(1000) NOT NULL DEFAULT '' COMMENT '대책',
  REMARK VARCHAR(1000) NOT NULL DEFAULT '' COMMENT '비고',
  RTIME VARCHAR(19) NOT NULL DEFAULT '' COMMENT '등록시간',
  REMP VARCHAR(20) NOT NULL DEFAULT '' COMMENT '등록자',
  RPRG VARCHAR(100) NOT NULL DEFAULT '' COMMENT '등록프로그램',
  MTIME VARCHAR(19) NOT NULL DEFAULT '' COMMENT '수정시간',
  MEMP VARCHAR(20) NOT NULL DEFAULT '' COMMENT '수정자',
  MPRG VARCHAR(100) NOT NULL DEFAULT '' COMMENT '수정프로그램',
  PRIMARY KEY (RSTMONTH, CUSTCD, ITEMID)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci
COMMENT = '판매계획(수주) 대비 출하실적 - 변동사유·미출고원인·대책 (월 × 거래처 × 품목, SAL3002_S02 상세탭에서 입력)'
ROW_FORMAT = DYNAMIC;

-- *****************************************************************************
-- 공통코드: 변동사유 (OUTCHGTP) - 화면 그리드 콤보가 이 그룹을 읽는다.
-- COMTYPEGP 에 그룹이 없으면 DC_COMBO 가 GPCD 를 쿼리로 실행해 오류가 나므로 화면보다 먼저 넣을 것.
-- REF01 = 'Y' : 판매계획 조정 대상 (메인탭 "4. 판매계획 대비 실적" 의 B 에 차액을 더한다. 엑셀의 발주감소 + 선적지연)
-- 순서·이름은 2026년 03월 판매계획대비 출하실적(세부)_2공장.xlsx 표지 "3. 변동사유 기준" 그대로
-- 정상출고는 코드로 두지 않는다: 변동사유를 비워 둔 품목 = 정상출고 (SAL3002_S02 3번 표가 '정상출고' 로 집계)
-- *****************************************************************************
INSERT INTO MES_SNS2.COMTYPEGP (
    GPCD, GPNM, SYSYN, MESCOLUMN,
    REF01NM, REF02NM, REF03NM, REF04NM, REF05NM,
    REF06NM, REF07NM, REF08NM, REF09NM, REF10NM,
    REF11NM, REF12NM, REF13NM, REF14NM, REF15NM,
    REF16NM, REF17NM, REF18NM, REF19NM, REF20NM,
    REMARK, RTIME, REMP, RPRG)
VALUES (
    'OUTCHGTP', '출하 변동사유', 'N', 'OUTCHGTP',
    '판매계획 조정대상(Y/N)', '', '', '', '',
    '', '', '', '', '',
    '', '', '', '', '',
    '', '', '', '', '',
    'SAL3002_S02 판매계획대비 출하실적조회', DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'), 'admin', 'SAL3002_S02');

INSERT INTO MES_SNS2.COMTYPE (
    GPCD, TPCD, TPNM, SORTNO, USEYN,
    REF01, REF02, REF03, REF04, REF05,
    REF06, REF07, REF08, REF09, REF10,
    REF11, REF12, REF13, REF14, REF15,
    REF16, REF17, REF18, REF19, REF20,
    REMARK, RTIME, REMP, RPRG)
SELECT 'OUTCHGTP', CODE.TPCD, CODE.TPNM, CODE.SORTNO, 'Y',
       CODE.REF01, '', '', '', '',
       '', '', '', '', '',
       '', '', '', '', '',
       '', '', '', '', '',
       '', DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%s'), 'admin', 'SAL3002_S02'
  FROM (SELECT 'ODRDEC' AS TPCD, '발주감소' AS TPNM, 1 AS SORTNO, 'Y' AS REF01
        UNION ALL SELECT 'SHIPDLY', '선적지연', 2, 'Y'
        UNION ALL SELECT 'ODRADD', '추가발주', 3, 'N'
        UNION ALL SELECT 'PRDDLY', '생산지연', 4, 'N'
        UNION ALL SELECT 'MTRNOIN', '원소재미입고', 5, 'N'
        UNION ALL SELECT 'QCISSUE', '품질문제', 6, 'N'
        UNION ALL SELECT 'OSCDLY', '외주공정지연', 7, 'N') AS CODE;
