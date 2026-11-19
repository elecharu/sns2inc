CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.SAL3002_S03(
-- *****************************************************************************
-- Comment: 재고 입출고 조회 (일일 마감) - 생산관리팀 "일일 마감 (2공장 - 외부 재고출고나 이동이력 조회)" 양식
--          2공장과 외부(1공장, 외주처, 고객사) 사이의 재고 입출고 이력. LOT 한 줄 = 한 행
--          ) 구분
--            1->2 사업장    : 입고 INTP 03 (사업장이동) 중 2공장 창고(MSTWARE.FACTORYCD 07)로 들어온 것
--            2->1 사업장    : 출고 OUTTP 03 (사업장이동) 중 2공장 창고에서 나간 것
--            외주반출       : 출고 OUTTP 공통코드 REF02 = Y
--            외주재작업반출 : 출고 OUTTP 공통코드 REF05 = Y
--            외주이동       : 출고 OUTTP 공통코드 REF03 = Y
--            외주입고       : 입고 INTP  공통코드 REF02 = Y
--            출하이동       : 출고 OUTTP 공통코드 REF04 = Y
--          ) 거래처 = 사업장이동은 '1공장'. 그 밖에는 아래 순서로 처음 나오는 거래처
--            출고 : 출하 거래처(SALOUT.CUSTCD) → 그 창고의 외주처 → 같은 이동(GROUPKEY) 입고창고의 외주처 → 거래명세서 공급받는자
--            입고 : 그 창고의 외주처 → 같은 이동(GROUPKEY) 출고창고의 외주처 → 거래명세서 공급자
--          ) 명세서번호 = 거래명세서키만. 없으면 빈칸
--            출고·1->2 사업장 : COMOUT·COMIN.INVOICEKEY
--            외주입고         : 가입고의 거래명세서 번호 (COMIN.MTRINKEY → MTRIN.INVOICEKEY)
--            (출하는 TML5000_R01·R02 가 출하 거래명세서 SALINVOICE 를 만들 때 COMOUT.INVOICEKEY 에 넣는다)
--          ) LIST  : 화면 그리드
--            PRINT : 리포트(SAL3002.exe S03). 결과셋 1 머리글(조회기간) 1행, 결과셋 2 LIST 와 같은 목록
-- Create: 2026-11-17
-- Modify: 2026-11-17 명세서번호는 거래명세서키만 (그룹키·입출고키로 대체하지 않음) (사용자 지시)
--         2026-11-18 외주입고 명세서번호·공급자를 COMIN.INVOICEKEY 대신 MTRIN.INVOICEKEY 로 (1->2 사업장은 그대로) (사용자 지시)
-- *****************************************************************************
  IN $SDATE VARCHAR(10),              -- 조회 시작일
  IN $EDATE VARCHAR(10),              -- 조회 종료일
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

  -- 출고 이력 (사업장이동 2->1, 외주반출, 외주재작업반출, 외주이동, 출하이동)
  DROP TEMPORARY TABLE IF EXISTS TEMP_INOUT;
  CREATE TEMPORARY TABLE TEMP_INOUT AS
    SELECT
        CASE
          WHEN COMOUT.OUTTP = '03' THEN 2
          WHEN OUTTP.REF02 = 'Y' THEN 3
          WHEN OUTTP.REF05 = 'Y' THEN 4
          WHEN OUTTP.REF03 = 'Y' THEN 5
          ELSE 7
        END AS SORTNO
      , CASE
          WHEN COMOUT.OUTTP = '03' THEN '2->1 사업장'
          WHEN OUTTP.REF02 = 'Y' THEN '외주반출'
          WHEN OUTTP.REF05 = 'Y' THEN '외주재작업반출'
          WHEN OUTTP.REF03 = 'Y' THEN '외주이동'
          ELSE '출하이동'
        END AS GUBUN
      , COMOUT.OUTDATE AS IODATE
      , CASE
          WHEN COMOUT.OUTTP = '03' THEN '1공장'
          ELSE COALESCE(NULLIF(SALOUT.CUSTCD, ''),
                        NULLIF(MSTWARE.CUSTCD, ''),
                        (SELECT MSTWARE2.CUSTCD
                           FROM COMIN
                           INNER JOIN MSTWARE AS MSTWARE2 ON MSTWARE2.WARECD = COMIN.WARECD
                          WHERE COMOUT.GROUPKEY <> ''
                            AND COMIN.GROUPKEY = COMOUT.GROUPKEY
                            AND MSTWARE2.CUSTCD <> ''
                          LIMIT 1),
                        NULLIF(MTRCUST_INVOICE_HEADER.CUSTCD_RECIEVER, ''),
                        '')
        END AS CUSTCD
      , COMOUT.INVOICEKEY AS DOCNO
      , COMOUT.ITEMID
      , IFNULL(COMOUTLOT.LOTKEY, '') AS LOTKEY
      , IFNULL(COMOUTLOT.OUTQTY, COMOUT.OUTQTY) AS QTY
      , COMOUT.RTIME
      FROM COMOUT
      INNER JOIN COMTYPE AS OUTTP
        ON OUTTP.GPCD = 'OUTTP'
       AND OUTTP.TPCD = COMOUT.OUTTP
      LEFT JOIN COMOUTLOT
        ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
      LEFT JOIN MSTWARE
        ON MSTWARE.WARECD = COMOUT.WARECD
      LEFT JOIN SALOUT
        ON SALOUT.SALOUTKEY = COMOUT.SALOUTKEY
       AND COMOUT.SALOUTKEY <> ''
      LEFT JOIN MTRCUST_INVOICE_HEADER
        ON MTRCUST_INVOICE_HEADER.INVOICEKEY = COMOUT.INVOICEKEY
       AND COMOUT.INVOICEKEY <> ''
     WHERE COMOUT.OUTDATE BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
       AND ((COMOUT.OUTTP = '03' AND MSTWARE.FACTORYCD = '07')
         OR OUTTP.REF02 = 'Y' OR OUTTP.REF03 = 'Y' OR OUTTP.REF04 = 'Y' OR OUTTP.REF05 = 'Y');

  -- 입고 이력 (사업장이동 1->2, 외주입고)
  INSERT INTO TEMP_INOUT
    SELECT
        CASE WHEN COMIN.INTP = '03' THEN 1 ELSE 6 END AS SORTNO
      , CASE WHEN COMIN.INTP = '03' THEN '1->2 사업장' ELSE '외주입고' END AS GUBUN
      , COMIN.INDATE AS IODATE
      , CASE
          WHEN COMIN.INTP = '03' THEN '1공장'
          ELSE COALESCE(NULLIF(MSTWARE.CUSTCD, ''),
                        (SELECT MSTWARE2.CUSTCD
                           FROM COMOUT
                           INNER JOIN MSTWARE AS MSTWARE2 ON MSTWARE2.WARECD = COMOUT.WARECD
                          WHERE COMIN.GROUPKEY <> ''
                            AND COMOUT.GROUPKEY = COMIN.GROUPKEY
                            AND MSTWARE2.CUSTCD <> ''
                          LIMIT 1),
                        NULLIF(MTRCUST_INVOICE_HEADER.CUSTCD_GIVER, ''),
                        '')
        END AS CUSTCD
      , CASE WHEN COMIN.INTP = '03' THEN COMIN.INVOICEKEY  -- 1->2 사업장: 그대로
             ELSE IFNULL(MTRIN.INVOICEKEY, '')               -- 외주입고: 가입고의 거래명세서 번호
        END AS DOCNO
      , COMIN.ITEMID
      , IFNULL(COMINLOT.LOTKEY, '') AS LOTKEY
      , IFNULL(COMINLOT.INQTY, COMIN.INQTY) AS QTY
      , COMIN.RTIME
      FROM COMIN
      INNER JOIN COMTYPE AS INTP
        ON INTP.GPCD = 'INTP'
       AND INTP.TPCD = COMIN.INTP
      LEFT JOIN COMINLOT
        ON COMINLOT.INKEY = COMIN.INKEY
      LEFT JOIN MSTWARE
        ON MSTWARE.WARECD = COMIN.WARECD
      LEFT JOIN MTRIN
        ON MTRIN.MTRINKEY = COMIN.MTRINKEY
       AND COMIN.MTRINKEY <> ''
      LEFT JOIN MTRCUST_INVOICE_HEADER  -- 거래명세서 공급자 (외주입고 거래처에만 씀)
        ON MTRCUST_INVOICE_HEADER.INVOICEKEY = MTRIN.INVOICEKEY
       AND MTRIN.INVOICEKEY <> ''
     WHERE COMIN.INDATE BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
       AND ((COMIN.INTP = '03' AND MSTWARE.FACTORYCD = '07')
         OR INTP.REF02 = 'Y');

-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST' THEN  -- 화면 그리드

  SELECT
      TEMP_INOUT.GUBUN, TEMP_INOUT.IODATE,
      IFNULL(NULLIF(MSTCUST.CUSTNM, ''), TEMP_INOUT.CUSTCD) AS CUSTNM,
      TEMP_INOUT.DOCNO, MSTITEM.ITEMCD,
      MSTITEM.ITEMNM, MSTITEM.ITEMSPEC, TEMP_INOUT.QTY, TEMP_INOUT.LOTKEY
    FROM TEMP_INOUT
    LEFT JOIN MSTCUST
      ON MSTCUST.CUSTCD = TEMP_INOUT.CUSTCD
    LEFT JOIN MSTITEM
      ON MSTITEM.ITEMID = TEMP_INOUT.ITEMID
    ORDER BY TEMP_INOUT.SORTNO, TEMP_INOUT.IODATE, CUSTNM, TEMP_INOUT.DOCNO, MSTITEM.ITEMCD, TEMP_INOUT.RTIME, TEMP_INOUT.LOTKEY;

-- ****************************************************************************
WHEN 'PRINT' THEN  -- 리포트 (SAL3002.exe S03)

  SELECT CONCAT('조회기간: ', LEFT($SDATE, 10), ' ~ ', LEFT($EDATE, 10)) AS PERIOD;

  SELECT
      TEMP_INOUT.GUBUN, TEMP_INOUT.IODATE,
      IFNULL(NULLIF(MSTCUST.CUSTNM, ''), TEMP_INOUT.CUSTCD) AS CUSTNM,
      TEMP_INOUT.DOCNO, MSTITEM.ITEMCD,
      MSTITEM.ITEMNM, MSTITEM.ITEMSPEC, TEMP_INOUT.QTY, TEMP_INOUT.LOTKEY
    FROM TEMP_INOUT
    LEFT JOIN MSTCUST
      ON MSTCUST.CUSTCD = TEMP_INOUT.CUSTCD
    LEFT JOIN MSTITEM
      ON MSTITEM.ITEMID = TEMP_INOUT.ITEMID
    ORDER BY TEMP_INOUT.SORTNO, TEMP_INOUT.IODATE, CUSTNM, TEMP_INOUT.DOCNO, MSTITEM.ITEMCD, TEMP_INOUT.RTIME, TEMP_INOUT.LOTKEY;

-- ****************************************************************************
END CASE;

  DROP TEMPORARY TABLE IF EXISTS TEMP_INOUT;
END
