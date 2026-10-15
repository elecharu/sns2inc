CREATE DEFINER=`root`@`%` 
PROCEDURE `MES_SNS2`.`MTR0001_R04`(
-- *****************************************************************************
-- Comment: 설비부품 발주관리 (발주헤더 및 발주상세 조회)
-- Create:  2026-10-12  생성    한성수
-- Modify:  2026-10-14          한성수  발주헤더·상세 분리 조회, 사원명 조인(DOUBLE 에러 방지) 및 발주서 출력 리포트(CALL_RPT) 조회 추가
--          2026-10-15          한성수  사원코드, 공장 마스터 사업장 연결
-- *****************************************************************************
  IN $COMPANYCD       VARCHAR(100),
  IN $FACTORYCD       VARCHAR(100),
  IN $SDATE           VARCHAR(10),
  IN $EDATE           VARCHAR(10),
  IN $CUSTCD          VARCHAR(20),
  IN $MTRODRKEY       VARCHAR(20),

-- *****************************************************************************
  IN $CALLTYPE        VARCHAR(50),
  IN $KEYWORD         VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************

  CASE $CALLTYPE
  -- *****************************************************************************

  WHEN 'LIST_MTRODR' THEN -- 설비부품 발주헤더 목록 조회 (발주디테일에 설비부품이 있는 발주헤더만 조회)

    SET $SDATE = COALESCE($SDATE, '');
    SET $EDATE = COALESCE($EDATE, '');
    SET $FACTORYCD = COALESCE($FACTORYCD, '');
    SET $CUSTCD = COALESCE($CUSTCD, '');

    SELECT MTRODR.MTRODRDATE, MTRODR.MTRODRKEY, MTRODR.MTRODRSTT,
           MTRODR.CUSTCD, MSTCUST.CUSTNM,
           MTRODR.EXPDATE,
           CASE 
             WHEN COALESCE(MTRODR.ODREMPID, 0) = 0 THEN ''
             ELSE COALESCE(NULLIF(TRIM(MSTEMP.EMPNM), ''), CAST(MTRODR.ODREMPID AS CHAR))
           END AS ODREMPID
    FROM MTRODR
    INNER JOIN (
      SELECT DISTINCT ODRD.MTRODRKEY
      FROM MTRODRD ODRD
      INNER JOIN MSTITEM ITEM 
        ON ITEM.ITEMID = ODRD.ITEMID
       AND (COALESCE($COMPANYCD, '') = '' OR ITEM.COMPANYCD = $COMPANYCD)
       AND ITEM.ITEMCG LIKE 'DM1007%'
    ) EQM_ODR
      ON EQM_ODR.MTRODRKEY = MTRODR.MTRODRKEY
    LEFT JOIN MSTCUST
      ON MSTCUST.CUSTCD = MTRODR.CUSTCD
    LEFT JOIN MSTEMP
      ON MTRODR.ODREMPID > 0
     AND (MSTEMP.EMPID = CAST(MTRODR.ODREMPID AS CHAR) OR MSTEMP.EMPCD = CAST(MTRODR.ODREMPID AS CHAR))
    WHERE ($SDATE = '' OR MTRODR.MTRODRDATE >= DATE_FORMAT($SDATE, '%Y-%m-%d'))
      AND ($EDATE = '' OR MTRODR.MTRODRDATE <= DATE_FORMAT($EDATE, '%Y-%m-%d'))
      AND ($FACTORYCD = '' OR $FACTORYCD IN (MTRODR.ODRFACTORY, MTRODR.INFACTORYCD)
                          OR COALESCE(MTRODR.INFACTORYCD, '') = '')
      AND ($CUSTCD = '' OR MTRODR.CUSTCD = $CUSTCD)
    ORDER BY MTRODR.MTRODRDATE DESC, MTRODR.MTRODRKEY DESC;

  -- *****************************************************************************

  WHEN 'LIST_MTRODRD' THEN -- 선택된 발주헤더의 설비부품 발주상세 목록 조회

    IF COALESCE($MTRODRKEY, '') = '' THEN
      LEAVE PROC;
    END IF;

    SELECT MTRODRD.MTRODRSEQ, MTRODRD.MTRODRSTT,
           MSTITEM.ITEMCG, MSTITEM.ITEMCD, MSTITEM.ITEMNM, MSTITEM.ITEMSPEC,
           MTRODRD.EXPDATE,
           MTRODRD.ODRQTY, MTRODRD.MTRODRPRICE, MTRODRD.MTRODRAMT,
           MTRODRD.MTRODRFPRICE, MTRODRD.MTRODRFAMT
    FROM MTRODRD
    LEFT JOIN MSTITEM
      ON MSTITEM.ITEMID = MTRODRD.ITEMID
     AND (COALESCE($COMPANYCD, '') = '' OR MSTITEM.COMPANYCD = $COMPANYCD)
    WHERE MTRODRD.MTRODRKEY = $MTRODRKEY
      AND (MSTITEM.ITEMCG IS NULL OR MSTITEM.ITEMCG LIKE 'DM1007%')
    ORDER BY MTRODRD.MTRODRSEQ ASC;

  -- *****************************************************************************

  WHEN 'CALL_RPT' THEN -- 설비부품 발주서 출력 리포트 데이터 조회

    IF COALESCE($MTRODRKEY, '') = '' THEN
      CALL COMERR('발주번호를 확인해주세요.');
      LEAVE PROC;
    END IF;

    -- Table 0: 발주 헤더 및 공급자(자사)·공급받는자(거래처) 정보
    SELECT MTRODR.MTRODRKEY,
           MTRODR.MTRODRDATE,
           LEFT(MTRODR.EXPDATE, 10) AS EXPDATE,
           COALESCE(MSTCUST.CUSTNM, '') AS CUSTNM, -- 거래처 이름0
           COALESCE(MSTCUST.REPRETEL, '') AS CUSTTEL, -- 거래처 전화번호
           COALESCE(MSTCUST.CUSTFAX, '') AS CUSTFAX, -- 거래처 팩스
           COALESCE(MSTCUST.REGBUSSNUM, '') AS CUSTBIZNO, -- 거래처 사업자 번호
           COALESCE(MSTBDV.BDVBNM_PRT, '') AS COMPANYNM, -- 사업장명 (인쇄용)
           COALESCE(MSTBDV.BDVREGNO, '') AS COMPANYBIZNO, -- 사업장 사업자 번호
           COALESCE(MSTBDV.BDVNMENG, '') AS PRESIDENT, -- 사업장 대표자명 (PRESIDENT 컬럼과 값이 서로 바뀐거 같지만 우선 데이터 상 BDVNMENG로 진행)
           COALESCE(MSTBDV.ADDR_PRT, '') AS COMPANYADDR, -- 사업장 주소(인쇄용)
           COALESCE(MSTBDV.REPRETEL, '') AS COMPANYTEL, -- 사업장 대표전화
           COALESCE(MSTBDV.FAXNO, '') AS COMPANYFAX, -- 사업장 대표Fax
           CASE
             WHEN COALESCE(MTRODR.ODREMPID, 0) = 0 THEN ''
             WHEN NULLIF(TRIM(MSTEMP.EMPNM), '') IS NULL THEN CAST(MTRODR.ODREMPID AS CHAR)
             ELSE CONCAT_WS(' ',
                    NULLIF(GPCD('DEPTCD', MSTEMP.DEPTCD), ''),
                    CONCAT('(', CONCAT_WS(' ', TRIM(MSTEMP.EMPNM),
                      NULLIF(GPCD('POSBC', MSTEMP.POSBC), ''),
                      NULLIF(TRIM(MSTEMP.MOBILE), '')), ')'))
           END AS EMPINFO,
           COALESCE(MTRODR.REMARK, '') AS REMARK
    FROM MTRODR
    LEFT JOIN MSTCUST
      ON MSTCUST.CUSTCD = MTRODR.CUSTCD
    LEFT JOIN MSTFACTORY
      ON MSTFACTORY.FACTORYCD = MTRODR.ODRFACTORY
    LEFT JOIN MSTBDV
      ON MSTBDV.BDVCD = MSTFACTORY.BDVCD
    LEFT JOIN MSTEMP
      ON MTRODR.ODREMPID > 0
     AND (MSTEMP.EMPID = CAST(MTRODR.ODREMPID AS CHAR) OR MSTEMP.EMPCD = CAST(MTRODR.ODREMPID AS CHAR)) -- MSTEMP.EMPID가 비어있음
    WHERE MTRODR.MTRODRKEY = $MTRODRKEY
    LIMIT 1;

    -- Table 1: 발주 품목 디테일 목록
    SELECT MSTITEM.ITEMNM,
           MSTITEM.ITEMSPEC,
           CASE 
             WHEN MSTITEM.ITEMUNIT = 'DM150100' THEN 'EA'
             ELSE COALESCE(GPCD('DM150', MSTITEM.ITEMUNIT), 'EA')
           END AS ITEMUNIT,
           COALESCE(MTRODRD.MTRODRPRICE, 0) AS PRICE,
           COALESCE(MTRODRD.ODRQTY, 0) AS QTY,
           COALESCE(MTRODRD.MTRODRAMT, 0) AS AMT,
           COALESCE(MTRODRD.REMARK, '') AS REMARK
    FROM MTRODRD
    LEFT JOIN MSTITEM
      ON MSTITEM.ITEMID = MTRODRD.ITEMID
    WHERE MTRODRD.MTRODRKEY = $MTRODRKEY
    ORDER BY MTRODRD.MTRODRSEQ ASC;

  -- *****************************************************************************
  ELSE
    CALL COMERR('파라미터값을 확인해주세요.');
    LEAVE PROC;
  -- *****************************************************************************
  END CASE;

END