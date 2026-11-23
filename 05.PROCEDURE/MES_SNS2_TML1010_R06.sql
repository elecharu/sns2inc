CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML1010_R06(
-- *****************************************************************************
-- Comment: 유상사급 자재이동 (외주처 → S&S 사내) - 납품등록(TML1010_R01)한 유상사급 LOT 를 스캔해 거래명세서(INVOICETP 05) 발행
--          재고는 움직이지 않음 (납품등록·자재이동 모두 수불 없음). 이동 이력(거래명세서)만 남기고,
--          사내 입고확인(TML1020_R07) 때 사내창고(04S100_N) 입고(INTP 011) 후 자재투입창고(04S111_N) 재고이동
--          수량 수정 불가 (납품 LOT 전량). 외주이동(TML1010_R02) 과 같은 화면 구조
-- Create: 2026-11-16
-- Modify: 2026-11-19: 납품등록 때 입고하지 않으므로 사내창고 입고 여부·재고 확인 제거 (입고는 입고확인 TML1020_R07 에서)
-- Modify: 2026-11-23: 납품등록이 거래명세서(01) 를 만들지 않으므로 납품 LOT(MTRCUSTLOT) 기준으로 스캔·거래명세서(05) 발행. 거래명세서는 여기서 처음 생김
-- Modify: 2026-11-23: ERP 화면과 같게 출고창고(= 발주입고창고 MTRODR.INWARECD)·입고창고 표시. 첫 스캔 LOT 의 발주입고창고로 정하고 이후 스캔 LOT 는 같은 창고인지 확인
-- *****************************************************************************
  IN $CUSTCD            VARCHAR(100),
  IN $MOVEDATE          VARCHAR(100),
  IN $SCANLOT           VARCHAR(100),
  IN $INVOICEKEY        VARCHAR(100),
  IN $SDATE             VARCHAR(100),
  IN $EDATE             VARCHAR(100),
  IN $LOTKEY_LIST       MEDIUMTEXT,
  IN $OUTWARE           VARCHAR(100),   -- 출고창고 = 발주입고창고 (첫 스캔 LOT 의 MTRODR.INWARECD). 스캔 때는 이미 스캔한 LOT 의 창고
  IN $INWARE            VARCHAR(100),   -- 입고창고 : 자재창고(원자재) → 자재투입창고, 상품창고 → 상품출하창고(유상사급)
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$LOTKEY       VARCHAR(100);
  DECLARE _$INVOICEKEY   VARCHAR(100);

-- ****************************************************************************
CASE $CALLTYPE

-- ****************************************************************************
WHEN 'SCAN_LOT' THEN -- LOT 바코드 스캔 : 로그인한 외주처가 납품등록한 유상사급 LOT 이면 그리드에 추가할 행 (이동량 = 납품 LOT 전량)

  IF IFNULL($CUSTCD, '') = '' THEN
    CALL COMERR('거래처 정보가 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($SCANLOT, '') = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1
                   FROM MTRCUSTLOT
                   INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                   WHERE MTRCUSTLOT.LOTKEY = $SCANLOT
                     AND MTRODR.CUSTCD = $CUSTCD) THEN
    CALL COMERR(CONCAT('납품등록한 로트번호가 아닙니다.', '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1
                   FROM MTRCUSTLOT
                   INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                   WHERE MTRCUSTLOT.LOTKEY = $SCANLOT
                     AND MTRODR.ODRBC = 'MM100900') THEN
    CALL COMERR(CONCAT('유상사급 발주 납품 LOT 가 아닙니다.', '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  -- 발주입고창고 : 자재창고(원자재) / 상품창고만 자재이동 가능
  IF NOT EXISTS (SELECT 1
                   FROM MTRCUSTLOT
                   INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                   WHERE MTRCUSTLOT.LOTKEY = $SCANLOT
                     AND MTRODR.INWARECD IN ('04S100_N', '04S120_N')) THEN
    CALL COMERR(CONCAT('자재이동할 수 없는 발주입고창고입니다. (자재창고·상품창고만 가능)'
                      , '\n- 로트번호: ', $SCANLOT
                      , '\n- 발주입고창고: ', IFNULL((SELECT MSTWARE.WARENM
                                                        FROM MTRCUSTLOT
                                                       INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                                                       INNER JOIN MSTWARE ON MSTWARE.WARECD = MTRODR.INWARECD
                                                       WHERE MTRCUSTLOT.LOTKEY = $SCANLOT LIMIT 1), '')));
    LEAVE PROC;
  END IF;

  -- 두 번째 스캔부터 : 이미 스캔한 LOT 와 발주입고창고가 같아야 함
  IF IFNULL($OUTWARE, '') <> '' AND NOT EXISTS (SELECT 1
                                                  FROM MTRCUSTLOT
                                                  INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                                                  WHERE MTRCUSTLOT.LOTKEY = $SCANLOT
                                                    AND MTRODR.INWARECD = $OUTWARE) THEN
    CALL COMERR(CONCAT('이미 스캔한 LOT 와 발주입고창고가 다릅니다.'
                      , '\n- 로트번호: ', $SCANLOT
                      , '\n- 이 LOT 발주입고창고: ', IFNULL((SELECT MSTWARE.WARENM
                                                              FROM MTRCUSTLOT
                                                             INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                                                             INNER JOIN MSTWARE ON MSTWARE.WARECD = MTRODR.INWARECD
                                                             WHERE MTRCUSTLOT.LOTKEY = $SCANLOT LIMIT 1), '')
                      , '\n- 스캔한 LOT 발주입고창고: ', IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = $OUTWARE), $OUTWARE)));
    LEAVE PROC;
  END IF;

  -- 이미 입고된 LOT (예전 방식으로 납품등록 때 입고된 것) 는 이동 불가
  IF EXISTS (SELECT 1 FROM MTRINLOT WHERE MTRINLOT.LOTKEY = $SCANLOT) THEN
    CALL COMERR(CONCAT('이미 입고된 LOT 입니다. (예전 방식으로 납품등록한 LOT)', '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  -- 이미 자재이동(05) 거래명세서에 올라간 LOT 는 다시 올릴 수 없음
  IF EXISTS (SELECT 1
               FROM MTRCUST_INVOICE_DETAIL
               INNER JOIN MTRCUST_INVOICE_HEADER ON MTRCUST_INVOICE_HEADER.INVOICEKEY = MTRCUST_INVOICE_DETAIL.INVOICEKEY
                                                AND MTRCUST_INVOICE_HEADER.INVOICETP = '05'
               WHERE MTRCUST_INVOICE_DETAIL.LOTKEY = $SCANLOT) THEN
    CALL COMERR(CONCAT('이미 자재이동에 등록된 LOT 입니다.', '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  SELECT
      MTRCUSTLOT.LOTKEY
    , MTRODR.INWARECD AS WARECD                                          -- 출고창고 = 발주입고창고
    , IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = MTRODR.INWARECD), '') AS WARENM
    , CASE MTRODR.INWARECD WHEN '04S100_N' THEN '04S111_N' WHEN '04S120_N' THEN '04S140_N' ELSE '' END AS INWARECD   -- 입고창고
    , CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL(MTRCUSTLOT.HEATNO, '') AS HEATNO
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , '01' AS LOTTP
    , MTRCUSTLOT.LOTQTY AS MOVEQTY   -- 이동량 = 납품 LOT 전량 (수정 불가)
    , '' AS REMARK
  FROM MTRCUSTLOT
  INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = MTRCUSTLOT.ITEMID
  WHERE MTRCUSTLOT.LOTKEY = $SCANLOT;

-- ****************************************************************************
WHEN 'MOVE_LOT' THEN -- 자재이동 등록 : 스캔한 LOT 들로 거래명세서(05) 발행. 재고는 움직이지 않음

  IF IFNULL($CUSTCD, '') = '' THEN
    CALL COMERR('거래처 정보가 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($MOVEDATE, '') = '' THEN
    CALL COMERR('이동일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($LOTKEY_LIST, '') = '' THEN
    CALL COMERR('이동할 LOT 를 스캔하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($OUTWARE, '') = '' THEN
    CALL COMERR('출고창고(발주입고창고)가 없습니다. LOT 바코드를 스캔하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($INWARE, '') <> CASE $OUTWARE WHEN '04S100_N' THEN '04S111_N' WHEN '04S120_N' THEN '04S140_N' ELSE '' END THEN
    CALL COMERR('출고창고에 맞는 입고창고가 아닙니다. (자재창고 → 자재투입창고, 상품창고 → 상품출하창고(유상사급))');
    LEAVE PROC;
  END IF;

  SET _$INVOICEKEY = GETKEY('INVOICEKEY');

  INSERT INTO MTRCUST_INVOICE_HEADER (
      INVOICEKEY, INVOICETP, INVOICEDATE, CUSTCD_GIVER, CUSTCD_RECIEVER, INWARE,
      EMPCD, RTIME, REMP, RPRG
  )
  VALUES (
      _$INVOICEKEY, '05', LEFT($MOVEDATE, 10), $CUSTCD, '', '04S100_N',
      CALLEMP(), CALLTIME(), CALLEMP(), CALLPRG()
  );

  WHILE LENGTH(IFNULL($LOTKEY_LIST, '')) > 0 DO
    CALL COMSPLIT($LOTKEY_LIST, _$LOTKEY);

    IF IFNULL(_$LOTKEY, '') <> '' THEN

      IF NOT EXISTS (SELECT 1
                       FROM MTRCUSTLOT
                       INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                       WHERE MTRCUSTLOT.LOTKEY = _$LOTKEY
                         AND MTRODR.CUSTCD = $CUSTCD) THEN
        CALL COMERR(CONCAT('납품등록한 로트번호가 아닙니다.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      IF NOT EXISTS (SELECT 1
                       FROM MTRCUSTLOT
                       INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                       WHERE MTRCUSTLOT.LOTKEY = _$LOTKEY
                         AND MTRODR.ODRBC = 'MM100900') THEN
        CALL COMERR(CONCAT('유상사급 발주 납품 LOT 가 아닙니다.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      IF NOT EXISTS (SELECT 1
                       FROM MTRCUSTLOT
                       INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRCUSTLOT.MTRODRKEY
                       WHERE MTRCUSTLOT.LOTKEY = _$LOTKEY
                         AND MTRODR.INWARECD = $OUTWARE) THEN
        CALL COMERR(CONCAT('발주입고창고가 다른 LOT 입니다.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      IF EXISTS (SELECT 1 FROM MTRINLOT WHERE MTRINLOT.LOTKEY = _$LOTKEY) THEN
        CALL COMERR(CONCAT('이미 입고된 LOT 입니다. (예전 방식으로 납품등록한 LOT)', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      -- 이미 자재이동(05) 거래명세서(이번 등록분 포함)에 올라간 LOT 는 다시 올릴 수 없음
      IF EXISTS (SELECT 1
                   FROM MTRCUST_INVOICE_DETAIL
                   INNER JOIN MTRCUST_INVOICE_HEADER ON MTRCUST_INVOICE_HEADER.INVOICEKEY = MTRCUST_INVOICE_DETAIL.INVOICEKEY
                                                    AND MTRCUST_INVOICE_HEADER.INVOICETP = '05'
                   WHERE MTRCUST_INVOICE_DETAIL.LOTKEY = _$LOTKEY) THEN
        CALL COMERR(CONCAT('이미 자재이동에 등록된 LOT 입니다.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      -- 거래명세서 상세 (이동량 = 납품 LOT 전량, 수량 수정 불가)
      INSERT INTO MTRCUST_INVOICE_DETAIL (
          INVOICEKEY, LOTKEY, LOTQTY, ITEMID, LOTTP, WARECD, TESTQTY, RTIME, REMP, RPRG)
      SELECT _$INVOICEKEY, MTRCUSTLOT.LOTKEY, MTRCUSTLOT.LOTQTY, MTRCUSTLOT.ITEMID,
             '01', '04S100_N', 0, CALLTIME(), CALLEMP(), CALLPRG()
        FROM MTRCUSTLOT
       WHERE MTRCUSTLOT.LOTKEY = _$LOTKEY;
    END IF;
  END WHILE;

  IF NOT EXISTS (SELECT 1 FROM MTRCUST_INVOICE_DETAIL WHERE MTRCUST_INVOICE_DETAIL.INVOICEKEY = _$INVOICEKEY) THEN
    CALL COMERR('이동할 LOT 가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 결과 반환 (등록 직후 팝업·출력용)
  SELECT MTRCUST_INVOICE_DETAIL.INVOICEKEY
       , MSTITEM.ITEMCD
       , MSTITEM.ITEMNM
       , MTRCUST_INVOICE_DETAIL.LOTKEY
       , MTRCUST_INVOICE_DETAIL.LOTQTY
       , MTRCUST_INVOICE_HEADER.INVOICEDATE AS MOVEDATE
       , GPCD('CUSTCD', MTRCUST_INVOICE_HEADER.CUSTCD_GIVER) AS OUTCUSTCD
       , CONCAT('S&S INC 2공장 ', IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = MTRCUST_INVOICE_HEADER.INWARE), '')) AS INCUSTCD
       , '' AS INDATE
       , GPCD('LOTTP', MTRCUST_INVOICE_DETAIL.LOTTP) AS LOTTP
    FROM MTRCUST_INVOICE_DETAIL
   INNER JOIN MTRCUST_INVOICE_HEADER ON MTRCUST_INVOICE_HEADER.INVOICEKEY = MTRCUST_INVOICE_DETAIL.INVOICEKEY
   INNER JOIN MSTITEM ON MSTITEM.ITEMID = MTRCUST_INVOICE_DETAIL.ITEMID
   WHERE MTRCUST_INVOICE_DETAIL.INVOICEKEY = _$INVOICEKEY
   ORDER BY MTRCUST_INVOICE_DETAIL.LOTKEY;

-- ****************************************************************************
WHEN 'LIST_INVOICE' THEN -- 자재이동 거래명세서 조회 (이동일자 기간, 로그인한 외주처가 낸 유상사급 자재이동) - [거래명세서 발행]·[이동내역삭제] 탭

  SELECT MTRCUST_INVOICE_HEADER.INVOICEKEY
       , MTRCUST_INVOICE_HEADER.INVOICEDATE AS MOVEDATE
       , IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = MTRCUST_INVOICE_HEADER.INWARE), '') AS INNM
       , COUNT(MTRCUST_INVOICE_DETAIL.LOTKEY) AS LOTCNT
       , SUM(MTRCUST_INVOICE_DETAIL.LOTQTY) AS TOTQTY
       , IF(IFNULL(MTRCUST_INVOICE_HEADER.MOVEGROUPKEY, '') <> '', '입고확인완료', '입고확인대기') AS STATUSNM
       , GPCD('EMPCD', MTRCUST_INVOICE_HEADER.EMPCD) AS EMPNM
       , MTRCUST_INVOICE_HEADER.RTIME
    FROM MTRCUST_INVOICE_HEADER
   INNER JOIN MTRCUST_INVOICE_DETAIL ON MTRCUST_INVOICE_DETAIL.INVOICEKEY = MTRCUST_INVOICE_HEADER.INVOICEKEY
   WHERE MTRCUST_INVOICE_HEADER.INVOICETP = '05'
     AND MTRCUST_INVOICE_HEADER.CUSTCD_GIVER = $CUSTCD
     AND LEFT(MTRCUST_INVOICE_HEADER.INVOICEDATE, 10) BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
   GROUP BY MTRCUST_INVOICE_HEADER.INVOICEKEY, MTRCUST_INVOICE_HEADER.INVOICEDATE, MTRCUST_INVOICE_HEADER.INWARE,
            MTRCUST_INVOICE_HEADER.MOVEGROUPKEY, MTRCUST_INVOICE_HEADER.EMPCD, MTRCUST_INVOICE_HEADER.RTIME
   ORDER BY MTRCUST_INVOICE_HEADER.RTIME DESC;

-- ****************************************************************************
WHEN 'DEL_MOVE_LOT' THEN -- 자재이동 삭제 (입고확인 전만)

  IF IFNULL($INVOICEKEY, '') = '' THEN
    CALL COMERR('거래명세서 번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MTRCUST_INVOICE_HEADER
                  WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = $INVOICEKEY AND MTRCUST_INVOICE_HEADER.INVOICETP = '05') THEN
    CALL COMERR('존재하지 않는 자재이동 거래명세서입니다.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM MTRCUST_INVOICE_HEADER
              WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = $INVOICEKEY AND IFNULL(MTRCUST_INVOICE_HEADER.MOVEGROUPKEY, '') <> '') THEN
    CALL COMERR('입고확인이 끝난 자재이동은 삭제할 수 없습니다. (자재반출로 처리하세요)');
    LEAVE PROC;
  END IF;

  DELETE FROM MTRCUST_INVOICE_DETAIL WHERE MTRCUST_INVOICE_DETAIL.INVOICEKEY = $INVOICEKEY;
  DELETE FROM MTRCUST_INVOICE_HEADER WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = $INVOICEKEY;

-- ****************************************************************************
END CASE; END
