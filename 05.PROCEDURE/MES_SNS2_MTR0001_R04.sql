CREATE DEFINER=`root`@`%` 
PROCEDURE `MES_SNS2`.`MTR0001_R04`(
-- *****************************************************************************
-- Comment: 설비부품 발주관리 (발주헤더 및 발주상세 조회)
-- Create:  2026-10-12  생성    한성수
-- Modify:  2026-10-14          한성수  발주헤더·상세 분리 조회, 사원명 조인(DOUBLE 에러 방지) 및 발주서 출력 리포트(CALL_RPT) 조회 추가
--          2026-10-15          한성수  발주서 출력 SQL 작성
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

  WHEN 'LIST_MTRODR' THEN -- 설비부품 발주헤더 목록 조회

    SELECT MTRODR.MTRODRDATE,
           MTRODR.MTRODRKEY,
           MTRODR.MTRODRSTT,
           MTRODR.CUSTCD,
           MSTCUST.CUSTNM,
           MTRODR.EXPDATE,
           COALESCE(MSTEMP.EMPNM, NULLIF(MTRODR.ODREMPID, 0), '') AS ODREMPID
    FROM MTRODR
    INNER JOIN (
      SELECT DISTINCT ODRD.MTRODRKEY
      FROM MTRODRD ODRD
      INNER JOIN MSTITEM ITEM ON ITEM.ITEMID = ODRD.ITEMID
      WHERE ITEM.ITEMCG = 'DM100700'
        AND (COALESCE($COMPANYCD, '') = '' OR ITEM.COMPANYCD = $COMPANYCD)
    ) EQM_ODR ON EQM_ODR.MTRODRKEY = MTRODR.MTRODRKEY
    LEFT JOIN MSTCUST ON MSTCUST.CUSTCD = MTRODR.CUSTCD
    LEFT JOIN MSTEMP
      ON MTRODR.ODREMPID > 0
     AND MSTEMP.EMPID = MTRODR.ODREMPID
    WHERE (COALESCE($SDATE, '') = '' OR MTRODR.MTRODRDATE >= $SDATE)
      AND (COALESCE($EDATE, '') = '' OR MTRODR.MTRODRDATE <= $EDATE)
      AND (COALESCE($FACTORYCD, '') = '' OR MTRODR.ODRFACTORY = $FACTORYCD)
      AND (COALESCE($CUSTCD, '') = '' OR MTRODR.CUSTCD = $CUSTCD)
    ORDER BY MTRODR.MTRODRDATE DESC, MTRODR.MTRODRKEY DESC;

  -- *****************************************************************************

  WHEN 'LIST_MTRODRD' THEN -- 선택된 발주헤더의 설비부품 발주상세 목록 조회

    SELECT MTRODRD.MTRODRSEQ,
           MTRODRD.MTRODRSTT,
           MSTITEM.ITEMCG,
           MSTITEM.ITEMCD,
           MSTITEM.ITEMNM,
           MSTITEM.ITEMSPEC,
           LEFT(MTRODRD.EXPDATE, 10) AS EXPDATE,
           MTRODRD.ODRQTY,
           MTRODRD.MTRODRPRICE,
           MTRODRD.MTRODRAMT,
           MTRODRD.MTRODRFPRICE,
           MTRODRD.MTRODRFAMT
    FROM MTRODRD
    INNER JOIN MSTITEM ON MSTITEM.ITEMID = MTRODRD.ITEMID
    WHERE MTRODRD.MTRODRKEY = $MTRODRKEY
      AND MSTITEM.ITEMCG = 'DM100700'
    ORDER BY MTRODRD.MTRODRSEQ ASC;

  -- *****************************************************************************

  WHEN 'CALL_RPT' THEN -- 설비부품 발주서 출력 리포트 데이터 조회

  	IF COALESCE($MTRODRKEY, '') = '' THEN
      CALL COMERR('출력할 발주를 선택해주세요.');
      LEAVE PROC;
    END IF;
      
    -- Table 0: 발주 헤더 및 공급자(자사)·공급받는자(거래처) 정보
    SELECT MTRODR.MTRODRKEY,
           MTRODR.MTRODRDATE, -- 발주승인날짜 따로 없어서 임시로 사용중
           LEFT(MTRODR.EXPDATE, 10) AS EXPDATE, -- 납기일자
           MSTCUST.CUSTNM, -- 거래처 이름
           MSTCUST.REPRETEL AS CUSTTEL, -- 거래처 전화번호
           MSTCUST.CUSTFAX,	-- 거래처 팩스번호
           MSTCUST.REGBUSSNUM AS CUSTBIZNO,	-- 거래처 사업자번호
           MSTBDV.BDVBNM_PRT AS COMPANYNM,	-- 사업장명 (인쇄용)
           MSTBDV.BDVREGNO AS COMPANYBIZNO, -- 사업장 사업자 번호
           MSTBDV.BDVNMENG AS PRESIDENT, -- 사업장 대표자명 (PRESIDENT 컬럼과 값이 서로 바뀐거 같지만 우선 데이터 상 BDVNMENG로 진행)
           MSTBDV.ADDR_PRT AS COMPANYADDR, -- 사업장 주소(인쇄용)
           MSTBDV.REPRETEL AS COMPANYTEL, -- 사업장 대표전화
           MSTBDV.FAXNO AS COMPANYFAX, -- 사업장 대표Fax
           CASE
             WHEN MSTEMP.EMPNM IS NOT NULL THEN
               CONCAT_WS(' ', GPCD('DEPTCD', MSTEMP.DEPTCD),
                 CONCAT('(', CONCAT_WS(' ', MSTEMP.EMPNM, GPCD('POSBC', MSTEMP.POSBC), MSTEMP.MOBILE), ')'))
             WHEN MTRODR.ODREMPID > 0 THEN CAST(MTRODR.ODREMPID AS CHAR)
             ELSE ''
           END AS EMPINFO,
           MTRODR.REMARK
    FROM MTRODR
    LEFT JOIN MSTCUST ON MSTCUST.CUSTCD = MTRODR.CUSTCD
    LEFT JOIN MSTFACTORY ON MSTFACTORY.FACTORYCD = MTRODR.ODRFACTORY
    LEFT JOIN MSTBDV ON MSTBDV.BDVCD = MSTFACTORY.BDVCD
    LEFT JOIN MSTEMP
      ON MTRODR.ODREMPID > 0
     AND MSTEMP.EMPID =  MTRODR.ODREMPID
    WHERE MTRODR.MTRODRKEY = $MTRODRKEY;

    -- Table 1: 발주 품목 디테일 목록
    SELECT MSTITEM.ITEMNM,
           MSTITEM.ITEMSPEC,
           COALESCE(GPCD('DM150', MSTITEM.ITEMUNIT), 'EA') AS ITEMUNIT,
           MTRODRD.MTRODRPRICE AS PRICE,
           MTRODRD.ODRQTY AS QTY,
           MTRODRD.MTRODRAMT AS AMT,
           MTRODRD.REMARK
    FROM MTRODRD
    INNER JOIN MSTITEM ON MSTITEM.ITEMID = MTRODRD.ITEMID
    WHERE MTRODRD.MTRODRKEY = $MTRODRKEY
      AND MSTITEM.ITEMCG = 'DM100700'
    ORDER BY MTRODRD.MTRODRSEQ ASC;

  -- *****************************************************************************
  ELSE
    CALL COMERR('파라미터값을 확인해주세요.');
    LEAVE PROC;
  -- *****************************************************************************
  END CASE;

END