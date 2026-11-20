CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.SAL4001_S01(
-- *****************************************************************************
-- Comment: 고객사 반품이력 조회 - 조회기간에 고객사에서 되돌아와 반입한 제품 목록 (반입 1건 = 한 행)
--          ) 반입은 현장 제품 반입등록(TML6001_R01)이 저장한다
--            COMOUT·COMOUTLOT 출고구분 OUTTP 20(출하반품), OUTQTY 마이너스, 반입 거래처 COMOUT.CUSTCD
--            창고는 제품불량창고(04S230_N). 여기서는 창고로 거르지 않고 OUTTP 20 전부 보여준다 (창고 칸)
--          ) 기간 = 반입일자(COMOUT.OUTDATE)
--          ) 반입구분 = 공정이동표(출하 LOT 을 스캔) / 신규(무표)(공정이동표 없이 와서 RT 로트 채번) - TML6001_R01 LIST_RTN 과 같은 기준
--          ) 원출하일자 = 그 LOT 을 그 고객사에 출하한 마지막 출하일자 (SALOUT 확정 01·011). 무표는 빈칸
--          ) 판정 = 반입 뒤 등록된 부적합 판정(TQMJUDGE) 중 마지막 판정유형과 판정수량 합
--          ) 총계는 화면 그리드 자동 합계(isSubTotalGrid)로 낸다
-- Create: 2026-11-20
-- *****************************************************************************
  IN $SDATE VARCHAR(10),              -- 조회 시작일 (반입일자)
  IN $EDATE VARCHAR(10),              -- 조회 종료일
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
WHEN 'LIST' THEN  -- 반품(반입) 이력

  SELECT
      CAST(LEFT(COMOUT.OUTDATE, 10) AS CHAR(10)) AS RTNDATE
    , COMOUT.CUSTCD
    , IFNULL(MSTCUST.CUSTNM, COMOUT.CUSTCD) AS CUSTNM
    , CAST(COMOUT.ITEMID AS CHAR) AS ITEMID
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , IFNULL(MSTITEM.ITEMNM, '') AS ITEMNM
    , IFNULL(MSTITEM.ITEMSPEC, '') AS ITEMSPEC
    , IF(EXISTS (SELECT 1 FROM SALOUTLOT WHERE SALOUTLOT.LOTKEY = COMOUTLOT.LOTKEY)
       , '공정이동표', '신규(무표)') AS RTNTPNM
    , IFNULL(COMOUTLOT.LOTKEY, '') AS LOTKEY
    , IFNULL(COMLOT.HEATNO, '') AS HEATNO
    , -COMOUT.OUTQTY AS RTNQTY
    , IFNULL((SELECT CAST(LEFT(MAX(SALOUT.SALOUTDATE), 10) AS CHAR(10))
                FROM SALOUTLOT
                INNER JOIN SALOUT
                  ON SALOUT.SALOUTKEY = SALOUTLOT.SALOUTKEY
                WHERE SALOUTLOT.LOTKEY = COMOUTLOT.LOTKEY
                  AND SALOUT.CUSTCD = COMOUT.CUSTCD
                  AND SALOUT.OUTYN = 'Y'
                  AND SALOUT.SALOUTTP IN ('01', '011')), '') AS SALOUTDATE
    , IFNULL(MSTWARE.WARENM, COMOUT.WARECD) AS WARENM
    , IFNULL(COMLOT.LOTQTY, 0) AS LOTQTY          -- 반입창고 현재고
    , IFNULL((SELECT TQMJUDGE.JUDGETP
                FROM TQMJUDGE
                WHERE TQMJUDGE.LOTKEY = COMOUTLOT.LOTKEY
                  AND TQMJUDGE.WARECD = COMOUT.WARECD
                  AND TQMJUDGE.RTIME >= COMOUT.RTIME
                ORDER BY TQMJUDGE.JUDGEDATE DESC, TQMJUDGE.JUDGEKEY DESC
                LIMIT 1), '') AS JUDGETP
    , IFNULL((SELECT SUM(TQMJUDGE.JUDGEQTY)
                FROM TQMJUDGE
                WHERE TQMJUDGE.LOTKEY = COMOUTLOT.LOTKEY
                  AND TQMJUDGE.WARECD = COMOUT.WARECD
                  AND TQMJUDGE.RTIME >= COMOUT.RTIME), 0) AS JUDGEQTY
    , IFNULL(COMOUT.REMARK, '') AS REMARK
    , IFNULL(MSTEMP.EMPNM, COMOUT.REMP) AS EMPNM
    , LEFT(COMOUT.RTIME, 16) AS RTIME
    , COMOUT.OUTKEY
  FROM COMOUT
  LEFT JOIN COMOUTLOT
    ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = COMOUT.ITEMID
  LEFT JOIN MSTCUST
    ON MSTCUST.CUSTCD = COMOUT.CUSTCD
  LEFT JOIN MSTWARE
    ON MSTWARE.WARECD = COMOUT.WARECD
  LEFT JOIN COMLOT
    ON COMLOT.LOTKEY = COMOUTLOT.LOTKEY
   AND COMLOT.WARECD = COMOUT.WARECD
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = COMOUT.REMP
  WHERE COMOUT.OUTTP = '20'   -- 출하반품
    AND COMOUT.OUTDATE BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
    AND (IFNULL($CUSTCD, '') = '' OR COMOUT.CUSTCD = $CUSTCD)
    AND (IFNULL($ITEMID, '') = '' OR COMOUT.ITEMID = $ITEMID)
  ORDER BY COMOUT.OUTDATE, CUSTNM, COMOUT.CUSTCD, ITEMCD, COMOUT.RTIME, LOTKEY;

-- ****************************************************************************
END CASE;
-- *****************************************************************************
END
