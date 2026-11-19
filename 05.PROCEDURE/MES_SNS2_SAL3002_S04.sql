CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.SAL3002_S04(
-- *****************************************************************************
-- Comment: 출하실적조회 - 조회기간에 출하한 LOT 목록 (LOT 한 줄 = 한 행, 합계 줄 없음)
--          ) 판매계획대비 출하실적조회(SAL3002_S02) 세부내역 탭을 품목별로 묶지 않고 LOT 별로 펼친 것.
--            금액·계획 관련 칸(단가·계획·달성율·차이·변동사유 등)은 뺐다
--          ) 기간 = 출하일자(SALOUT.SALOUTDATE)
--          ) 범위는 S02 와 같다: 2공장 사업장(SALODR.BDVCD 71) 수주에 연결된 출하 중 품목 공장 06/07
--            2공장 = 품목 공장 07, 1공장 = 품목 공장 06 (둘 다면 2공장). 1공장은 맨 아래 '1공장' 구간
--          ) 구분 = 수주 지역구분(SALODR.DEBC, 공통코드 SD300)
--          ) LOT = SALOUTLOT. LOT 이력이 없는 출하는 LOT 칸을 비우고 출하수량(SALOUT.OUTQTY)으로 한 줄
--          ) 총계는 화면 그리드 자동 합계(isSubTotalGrid)로 낸다. 프로시저는 LOT 줄만 돌려준다
-- Create: 2026-11-17
-- Modify: 2026-11-17 조회조건 구분(수출/내수)·고객사·품목 추가 (사용자 지시)
--         2026-11-17 총계 줄을 프로시저에서 빼고 그리드 자동 합계로 바꿈 (사용자 지시)
-- *****************************************************************************
  IN $SDATE VARCHAR(10),              -- 조회 시작일 (출하일자)
  IN $EDATE VARCHAR(10),              -- 조회 종료일
  IN $DEBC VARCHAR(100),              -- 구분 (수주 지역구분 SD300, 빈값 = 전체)
  IN $CUSTCD VARCHAR(100),            -- 고객사 (빈값 = 전체)
  IN $ITEMID VARCHAR(100),            -- 품목ID (빈값 = 전체)
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  IF IFNULL($SDATE, '') = '' OR IFNULL($EDATE, '') = '' THEN
    CALL COMERR('조회기간을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF LEFT($SDATE, 10) > LEFT($EDATE, 10) THEN
    CALL COMERR('조회 시작일이 종료일보다 늦습니다.');
    LEAVE PROC;
  END IF;
-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST' THEN  -- 출하 LOT 목록

  SELECT
      LIST.DEBCNM
    , LIST.CUSTCD
    , LIST.CUSTNM
    , LIST.ITEMID
    , LIST.ITEMNM
    , LIST.ITEMCD
    , LIST.SALOUTDATE
    , LIST.SALODRNO
    , LIST.SALOUTKEY
    , LIST.LOTKEY
    , LIST.HEATNO
    , LIST.OUTQTY
    , LIST.REMARK
  FROM (
         SELECT
             IF(FAC2.ITEMID IS NULL, '1공장'
                , IFNULL(NULLIF(GPCD('SD300', SALODR.DEBC), ''), SALODR.DEBC)) AS DEBCNM
           , IF(FAC2.ITEMID IS NULL, 10000
                , CAST(IFNULL((SELECT COMTYPE.SORTNO
                                 FROM COMTYPE
                                 WHERE COMTYPE.GPCD = 'SD300'
                                   AND COMTYPE.TPCD = SALODR.DEBC), 999) AS SIGNED)) AS DEBCSORT   -- 1공장은 맨 아래
           , IF(FAC2.ITEMID IS NULL, 'FAC1', SALODR.DEBC) AS DEBC
           , SALOUT.CUSTCD
           , IFNULL(MSTCUST.CUSTNM, SALOUT.CUSTCD) AS CUSTNM
           , CAST(SALOUT.ITEMID AS CHAR) AS ITEMID
           , IFNULL(MSTITEM.ITEMNM, '') AS ITEMNM
           , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
           , CAST(LEFT(SALOUT.SALOUTDATE, 10) AS CHAR(10)) AS SALOUTDATE
           , CONCAT(SALOUT.SALODRKEY, '-', SALOUT.ODRSEQ) AS SALODRNO
           , SALOUT.SALOUTKEY
           , IFNULL(SALOUTLOT.LOTKEY, '') AS LOTKEY
           , IFNULL(SALOUTLOT.HEATNO, '') AS HEATNO
           , IFNULL(SALOUTLOT.LOTQTY, SALOUT.OUTQTY) AS OUTQTY
           , IFNULL(SALOUTLOT.REMARK, '') AS REMARK
         FROM SALOUT
         INNER JOIN SALODR
           ON SALODR.SALODRKEY = SALOUT.SALODRKEY
         LEFT JOIN SALOUTLOT
           ON SALOUTLOT.SALOUTKEY = SALOUT.SALOUTKEY
         LEFT JOIN MSTCUST
           ON MSTCUST.CUSTCD = SALOUT.CUSTCD
         LEFT JOIN MSTITEM
           ON MSTITEM.ITEMID = SALOUT.ITEMID
         LEFT JOIN (SELECT DISTINCT MSTITEM_FACTORY.ITEMID
                      FROM MSTITEM_FACTORY
                      WHERE MSTITEM_FACTORY.FACTORYCD = '07') AS FAC2   -- 2공장 품목
           ON FAC2.ITEMID = SALOUT.ITEMID
         WHERE SALOUT.SALOUTDATE BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
           AND SALODR.BDVCD = '71'   -- 2공장 사업장 수주만
           AND EXISTS (SELECT MSTITEM_FACTORY.ITEMID
                         FROM MSTITEM_FACTORY
                         WHERE MSTITEM_FACTORY.ITEMID = SALOUT.ITEMID
                           AND MSTITEM_FACTORY.FACTORYCD IN ('06', '07'))
           AND (IFNULL($DEBC, '') = '' OR SALODR.DEBC = $DEBC)
           AND (IFNULL($CUSTCD, '') = '' OR SALOUT.CUSTCD = $CUSTCD)
           AND (IFNULL($ITEMID, '') = '' OR SALOUT.ITEMID = $ITEMID)
       ) AS LIST
  ORDER BY LIST.DEBCSORT, LIST.DEBC, LIST.CUSTNM, LIST.CUSTCD, LIST.ITEMCD, LIST.ITEMID
         , LIST.SALOUTDATE, LIST.SALOUTKEY, LIST.LOTKEY;

-- ****************************************************************************
END CASE;
-- *****************************************************************************
END
