CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML1020_R09(
-- *****************************************************************************
-- Comment: 자재입고확인 (원자재·상품 납품 거래명세서 입고확인, TML1020_R01 외주입고를 복사. 출력물 없음)
-- Create: 2026-11-16 (TML1020_R01 복사)
-- *****************************************************************************
  IN $MTRINDATE       VARCHAR(10),
  IN $BARCODE         VARCHAR(100),
  IN $INVOICEKEY_LIST MEDIUMTEXT,
  IN $SDATE          VARCHAR(10),    -- 입고내역 조회 시작일
  IN $EDATE          VARCHAR(10),    -- 입고내역 조회 종료일
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$INVOICEKEY  VARCHAR(100);
  DECLARE _$LIST        MEDIUMTEXT;

-- ****************************************************************************
CASE $CALLTYPE

-- ****************************************************************************
WHEN 'SCAN_BARCODE' THEN -- 거래명세서번호 또는 LOT번호 스캔 → 그 거래명세서의 LOT 목록

  IF TRIM(IFNULL($BARCODE, '')) = '' THEN
    CALL COMERR('거래명세서번호 또는 LOT번호를 스캔하세요.');
    LEAVE PROC;
  END IF;

  -- 거래명세서번호로 먼저 찾고, 없으면 LOT번호로 그 LOT 의 거래명세서를 찾는다
  IF EXISTS (SELECT 1
               FROM MTRCUST_INVOICE_HEADER
               WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = TRIM($BARCODE)) THEN
    SET _$INVOICEKEY = TRIM($BARCODE);
  ELSE
    SET _$INVOICEKEY = (SELECT MTRCUST_INVOICE_DETAIL.INVOICEKEY
                          FROM MTRCUST_INVOICE_DETAIL
                          WHERE MTRCUST_INVOICE_DETAIL.LOTKEY = TRIM($BARCODE)
                          LIMIT 1);
  END IF;

  IF IFNULL(_$INVOICEKEY, '') = '' THEN
    CALL COMERR(CONCAT('[', TRIM($BARCODE), '] 거래명세서번호 또는 LOT번호가 아닙니다.'));
    LEAVE PROC;
  END IF;

  IF (SELECT MTRCUST_INVOICE_HEADER.CUSTCD_RECIEVER
        FROM MTRCUST_INVOICE_HEADER
        WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = _$INVOICEKEY) <> '' THEN
    CALL COMERR('사내 납품 거래명세서가 아닙니다.');
    LEAVE PROC;
  END IF;

  -- 원자재·상품 납품(INVOICETP 01, 무상사급 구매 MM100910) 거래명세서만
  IF NOT EXISTS (SELECT 1
                   FROM MTRCUST_INVOICE_HEADER AS H
                  WHERE H.INVOICEKEY = _$INVOICEKEY
                    AND H.INVOICETP = '01'
                    AND EXISTS (SELECT 1
                                  FROM MTRCUST_INVOICE_DETAIL AS D
                                 INNER JOIN MTRCUSTLOT AS L ON L.LOTKEY = D.LOTKEY
                                 INNER JOIN MTRODR AS O ON O.MTRODRKEY = L.MTRODRKEY
                                 WHERE D.INVOICEKEY = H.INVOICEKEY
                                   AND O.ODRBC = 'MM100910')) THEN
    CALL COMERR('원자재·상품 납품 거래명세서가 아닙니다. (자재입고확인 대상이 아닙니다)');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM MTRIN WHERE MTRIN.INVOICEKEY = _$INVOICEKEY) THEN
    CALL COMERR(CONCAT('이미 입고된 거래명세서입니다. (', _$INVOICEKEY, ')'));
    LEAVE PROC;
  END IF;

  -- 입고창고는 IO_MTRINVOICE 와 같은 기준 (시편 → 원자재 → 반제품 → 상품)
  SELECT
    MTRCUST_INVOICE_DETAIL.INVOICEKEY,
    GPCD('CUSTCD', MTRCUST_INVOICE_HEADER.CUSTCD_GIVER) AS OUTCUSTNM,
    IFNULL(MSTWARE.WARENM, '') AS INWARENM,
    MSTITEM.ITEMCD,
    MSTITEM.ITEMNM,
    MSTITEM.ITEMSPEC,
    MTRCUST_INVOICE_DETAIL.LOTKEY,
    IFNULL(MTRCUSTLOT.HEATNO, '') AS HEATNO,
    IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM,
    MTRCUST_INVOICE_DETAIL.LOTQTY AS INQTY,
    '' AS REMARK
  FROM MTRCUST_INVOICE_DETAIL
  INNER JOIN MTRCUST_INVOICE_HEADER ON MTRCUST_INVOICE_HEADER.INVOICEKEY = MTRCUST_INVOICE_DETAIL.INVOICEKEY
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = MTRCUST_INVOICE_DETAIL.ITEMID
  LEFT JOIN MTRCUSTLOT ON MTRCUSTLOT.LOTKEY = MTRCUST_INVOICE_DETAIL.LOTKEY
  LEFT JOIN MSTWARE ON MSTWARE.WARECD = CASE WHEN IFNULL(MTRCUST_INVOICE_HEADER.INWARE, '') <> '' THEN MTRCUST_INVOICE_HEADER.INWARE
                                             WHEN MTRCUST_INVOICE_DETAIL.LOTTP = '02' THEN '04S132_N'
                                             WHEN MSTITEM.ITEMCG = 'DM100300' THEN '04S100_N'
                                             WHEN MSTITEM.ITEMCG = 'DM100150' THEN '04S131_N'
                                             WHEN MSTITEM.ITEMCG = 'DM100200' THEN '04S120_N'
                                        END
  WHERE MTRCUST_INVOICE_DETAIL.INVOICEKEY = _$INVOICEKEY
  ORDER BY MTRCUST_INVOICE_DETAIL.LOTKEY;

-- ****************************************************************************
WHEN 'ADD_MTRIN' THEN -- 스캔한 거래명세서들을 입고일자로 입고

  IF IFNULL($MTRINDATE, '') = '' THEN
    CALL COMERR('입고일자를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($INVOICEKEY_LIST, '') = '' THEN
    CALL COMERR('입고할 거래명세서번호 또는 LOT번호를 스캔하세요.');
    LEAVE PROC;
  END IF;

  SET _$LIST = REPLACE($INVOICEKEY_LIST, '»', ','); -- 출력용 (COMSPLIT 가 $INVOICEKEY_LIST 를 줄여 나감)

  WHILE LENGTH($INVOICEKEY_LIST) > 0 DO
    CALL COMSPLIT($INVOICEKEY_LIST, _$INVOICEKEY);

    IF IFNULL(_$INVOICEKEY, '') <> '' THEN
      -- 원자재·상품 납품(INVOICETP 01, 무상사급 구매 MM100910) 거래명세서만
      IF NOT EXISTS (SELECT 1
                       FROM MTRCUST_INVOICE_HEADER AS H
                      WHERE H.INVOICEKEY = _$INVOICEKEY
                        AND H.INVOICETP = '01'
                        AND EXISTS (SELECT 1
                                      FROM MTRCUST_INVOICE_DETAIL AS D
                                     INNER JOIN MTRCUSTLOT AS L ON L.LOTKEY = D.LOTKEY
                                     INNER JOIN MTRODR AS O ON O.MTRODRKEY = L.MTRODRKEY
                                     WHERE D.INVOICEKEY = H.INVOICEKEY
                                       AND O.ODRBC = 'MM100910')) THEN
        CALL COMERR('원자재·상품 납품 거래명세서가 아닙니다. (자재입고확인 대상이 아닙니다)');
        LEAVE PROC;
      END IF;
      -- 원자재 04S100_N / 반제품 04S131_N / 상품 04S120_N / 시편 04S132_N
      CALL IO_MTRINVOICE(_$INVOICEKEY, '04S100_N', '04S131_N', '04S120_N', '04S132_N', $MTRINDATE);

      IF IFNULL(@ERRMSG, '') <> '' THEN
        LEAVE PROC;
      END IF;
    END IF;
  END WHILE;

  -- 입고된 LOT 수 (출력물 없음)
  SELECT COUNT(*) AS LOTCNT
    FROM MTRIN
   INNER JOIN MTRINLOT ON MTRINLOT.MTRINKEY = MTRIN.MTRINKEY
   WHERE MTRIN.INVOICEKEY <> ''
     AND FIND_IN_SET(MTRIN.INVOICEKEY, _$LIST) > 0;

-- ****************************************************************************
WHEN 'LIST_MTRIN' THEN -- 입고내역 조회 (입고일자 기간, 거래명세서 단위) - [입고취소] 탭

  SELECT MTRIN.INVOICEKEY
       , MIN(MTRIN.INDATE) AS INDATE
       , GPCD('CUSTCD', H.CUSTCD_GIVER) AS OUTCUSTNM
       , IF(H.INVOICETP = '03', '무상사급', '납품') AS INVOICETPNM
       , GROUP_CONCAT(DISTINCT IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = MTRIN.WARECD), MTRIN.WARECD) SEPARATOR ',') AS INWARENM
       , (SELECT COUNT(*) FROM MTRCUST_INVOICE_DETAIL AS D WHERE D.INVOICEKEY = MTRIN.INVOICEKEY) AS LOTCNT
       , SUM(MTRIN.INQTY) AS INQTY
       , GPCD('EMPCD', MIN(MTRIN.EMPCD)) AS EMPNM
       , MIN(MTRIN.RTIME) AS RTIME
    FROM MTRIN
   INNER JOIN MTRCUST_INVOICE_HEADER AS H ON H.INVOICEKEY = MTRIN.INVOICEKEY
   WHERE IFNULL(MTRIN.INVOICEKEY, '') <> ''
     AND H.INVOICETP = '01'
     AND EXISTS (SELECT 1 FROM MTRCUST_INVOICE_DETAIL AS D2
                  INNER JOIN MTRCUSTLOT AS L2 ON L2.LOTKEY = D2.LOTKEY
                  INNER JOIN MTRODR AS O2 ON O2.MTRODRKEY = L2.MTRODRKEY
                 WHERE D2.INVOICEKEY = H.INVOICEKEY AND O2.ODRBC = 'MM100910')   -- 유상사급 납품(납품등록 때 입고)은 제외
     AND MTRIN.INDATE BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
   GROUP BY MTRIN.INVOICEKEY, H.CUSTCD_GIVER, H.INVOICETP
   ORDER BY MIN(MTRIN.RTIME) DESC;

-- ****************************************************************************
WHEN 'CANCEL_MTRIN' THEN -- 입고 취소 (선택한 거래명세서들, 입고대기 상태로 되돌림)

  IF IFNULL($INVOICEKEY_LIST, '') = '' THEN
    CALL COMERR('취소할 입고내역을 선택하세요.');
    LEAVE PROC;
  END IF;

  WHILE LENGTH($INVOICEKEY_LIST) > 0 DO
    CALL COMSPLIT($INVOICEKEY_LIST, _$INVOICEKEY);

    IF IFNULL(_$INVOICEKEY, '') <> '' THEN
      CALL IO_MTRINVOICE_CANCEL(_$INVOICEKEY);

      IF IFNULL(@ERRMSG, '') <> '' THEN
        LEAVE PROC;
      END IF;
    END IF;
  END WHILE;

-- ****************************************************************************
END CASE; END