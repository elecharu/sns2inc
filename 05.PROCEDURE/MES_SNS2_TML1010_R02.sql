CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML1010_R02(
-- *****************************************************************************
-- Comment: 무상사급 납품등록
-- Create: 2026-10-01 김영철
-- Modify: 2026-11-12: 외주이동 시 재고가 움직이지 않도록 변경 - 재고 조회에서 입고 전 거래명세서에 올라간 LOT 제외
-- Modify: 2026-11-12: 시편수량($TESTQTY_LIST) 추가 (이동량에 포함)
-- Modify: 2026-11-12: ERP POP 화면 구조(바코드 스캔) 로 변경 - SCAN_LOT 추가 (출고창고 $OUTWARE, 스캔 LOT $SCANLOT)
-- Modify: 2026-11-12: [거래명세서 발행]·[이동내역삭제] 탭 - LIST_INVOICE 추가 ($SDATE, $EDATE)
-- Modify: 2026-11-12: 입고창고($INWARE) 추가 - 납품등록 시 거래명세서에 저장 (IO_MOVELOT)
-- *****************************************************************************
  IN $CUSTCD            VARCHAR(100),
  IN $ITEMID            VARCHAR(100),
  IN $MOVEDATE          VARCHAR(100),
  IN $INWARE            VARCHAR(100),
  IN $OUTWARE           VARCHAR(100),
  IN $SCANLOT           VARCHAR(100),
  IN $INVOICEKEY        VARCHAR(100),
  IN $SDATE              VARCHAR(100),
  IN $EDATE              VARCHAR(100),

  IN $WARECD_LIST       MEDIUMTEXT,
  IN $LOTKEY_LIST       MEDIUMTEXT,
  IN $LOTQTY_LIST       MEDIUMTEXT,
  IN $TESTQTY_LIST      MEDIUMTEXT,
  
-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC:  BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC  
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$ITEMID       VARCHAR(100);
  DECLARE _$LOTQTY       DECIMAL(20, 8);
  DECLARE _$CARINQTY     DECIMAL(20, 8);
  DECLARE _$LOTUNIT      DECIMAL(20, 8);
  
  DECLARE _$LABELCD      VARCHAR(100);
  DECLARE _$WARECD       VARCHAR(100);
  DECLARE _$LOTTP        VARCHAR(100);
  DECLARE _$OUTKEY       VARCHAR(100);
  DECLARE _$OUTTP        VARCHAR(100);

  DECLARE _$NUM          DECIMAL(20, 8);
  DECLARE _$NEEDQTY      DECIMAL(20, 8);
  DECLARE _$REMAINQTY    DECIMAL(20, 8);
  DECLARE _$QTY          DECIMAL(20, 8);
  
  DECLARE _$INVOICEKEY   VARCHAR(100);
  
  DECLARE _$STOCKLOTKEY  VARCHAR(100);
  DECLARE _$STOCKWARECD  VARCHAR(100);
  DECLARE _$STOCKQTY     DECIMAL(20, 8);
  DECLARE _$USEQTY       DECIMAL(20, 8);

-- ****************************************************************************
CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_COMLOT' THEN

  SELECT 
    A.ITEMID, B.ITEMCD, B.ITEMSPEC, A.LOTKEY,
    B.ITEMNM, A.CUSTCD, A.WARECD, A.LOTTP,
    B.ITEMUNIT, A.LOTQTY,
    CASE WHEN A.LOTTP = '02' THEN 'YELLOW' ELSE 'WHITH' END AS BACKGROUND
    FROM COMLOT AS A
    INNER JOIN MSTITEM AS B ON A.ITEMID = B.ITEMID
    INNER JOIN MSTWARE AS C ON A.WARECD = C.WARECD
    WHERE A.ITEMID LIKE CONCAT('%', $ITEMID, '%')
      AND A.LOTQTY > 0
      AND A.CUSTCD LIKE CONCAT('%', $CUSTCD, '%')
      AND C.CUSTCD <> ''
      AND NOT EXISTS (SELECT 1                                    -- 입고 전 납품(03) 거래명세서에 올라간 LOT 제외
                        FROM MTRCUST_INVOICE_DETAIL AS PD
                       INNER JOIN MTRCUST_INVOICE_HEADER AS PH ON PH.INVOICEKEY = PD.INVOICEKEY AND PH.INVOICETP = '03'
                       WHERE PD.LOTKEY = A.LOTKEY
                         AND PD.WARECD = A.WARECD
                         AND NOT EXISTS (SELECT 1 FROM MTRIN WHERE MTRIN.INVOICEKEY = PH.INVOICEKEY))
  ORDER BY A.WARECD, A.LOTKEY, A.LOTTP;

-- ****************************************************************************
WHEN 'SCAN_LOT' THEN -- LOT 바코드 스캔 : 로그인한 외주처 창고에 재고가 있으면 그리드에 추가할 행

  IF IFNULL($CUSTCD, '') = '' THEN
    CALL COMERR('거래처 정보가 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($OUTWARE, '') = '' THEN
    CALL COMERR('출고창고가 없습니다. 외주처 창고 설정을 확인하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MSTWARE WHERE MSTWARE.WARECD = $OUTWARE AND MSTWARE.CUSTCD = $CUSTCD) THEN
    CALL COMERR('출고창고가 로그인한 외주처 창고가 아닙니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($SCANLOT, '') = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM COMLOT WHERE COMLOT.LOTKEY = $SCANLOT AND COMLOT.WARECD = $OUTWARE) THEN
    CALL COMERR(CONCAT('출고창고에 없는 로트번호입니다.'
                      , '\n- 창고: ', IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = $OUTWARE), $OUTWARE)
                      , '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  IF (SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = $SCANLOT AND COMLOT.WARECD = $OUTWARE) <= 0 THEN
    CALL COMERR(CONCAT('재고수량이 0 입니다.', '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  -- 입고 전 납품(03) 거래명세서에 이미 올라간 LOT 는 다시 올릴 수 없음
  IF EXISTS (SELECT 1
               FROM MTRCUST_INVOICE_DETAIL AS PD
              INNER JOIN MTRCUST_INVOICE_HEADER AS PH ON PH.INVOICEKEY = PD.INVOICEKEY AND PH.INVOICETP = '03'
              WHERE PD.LOTKEY = $SCANLOT
                AND PD.WARECD = $OUTWARE
                AND NOT EXISTS (SELECT 1 FROM MTRIN WHERE MTRIN.INVOICEKEY = PH.INVOICEKEY)) THEN
    CALL COMERR(CONCAT('입고 전 거래명세서에 이미 등록된 LOT 입니다.', '\n- 로트번호: ', $SCANLOT));
    LEAVE PROC;
  END IF;

  SELECT
      COMLOT.LOTKEY
    , COMLOT.WARECD
    , CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL(COMLOT.HEATNO, '') AS HEATNO
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , COMLOT.LOTTP
    , COMLOT.LOTQTY AS MOVEQTY   -- 이동량 기본 = 현재고
    , 0 AS TESTQTY               -- 시편수량 (이동량에 포함)
    , COMLOT.LOTQTY              -- 잔여재고량
    , '' AS REMARK
  FROM COMLOT
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = COMLOT.ITEMID
  WHERE COMLOT.LOTKEY = $SCANLOT
    AND COMLOT.WARECD = $OUTWARE;
-- ****************************************************************************
WHEN 'MOVE_LOT' THEN  -- 납품 LOT 등록

  CALL IO_MOVELOT($CUSTCD, $MOVEDATE, $INWARE, $WARECD_LIST, $LOTKEY_LIST, $LOTQTY_LIST, $TESTQTY_LIST);

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- 결과 반환
  SELECT D.INVOICEKEY
       , I.ITEMCD
       , I.ITEMNM
       , D.LOTKEY
       , D.LOTQTY
       , H.INVOICEDATE  AS MOVEDATE
       , GPCD('CUSTCD', H.CUSTCD_GIVER) AS OUTCUSTCD
       , CONCAT('S&S INC 2공장 ', IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = H.INWARE), '')) AS INCUSTCD
       , '' AS INDATE
       , GPCD('LOTTP', D.LOTTP) AS LOTTP
    FROM MTRCUST_INVOICE_DETAIL AS D
   INNER JOIN MTRCUST_INVOICE_HEADER AS H ON D.INVOICEKEY = H.INVOICEKEY
   INNER JOIN MSTITEM AS I ON D.ITEMID = I.ITEMID
   WHERE D.INVOICEKEY = @INVOICEKEY
   ORDER BY D.LOTKEY, D.LOTTP;

-- ****************************************************************************
WHEN 'LIST_INVOICE' THEN -- 이동 거래명세서 조회 (이동일자 기간, 로그인한 외주처가 낸 무상사급 납품(외주이동) 거래명세서) - [거래명세서 발행]·[이동내역삭제] 탭

  SELECT H.INVOICEKEY
       , H.INVOICEDATE AS MOVEDATE
       , IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = H.INWARE), '') AS INNM
       , COUNT(D.LOTKEY) AS LOTCNT
       , SUM(D.LOTQTY) AS TOTQTY
       , SUM(IFNULL(D.TESTQTY, 0)) AS TESTQTY
       , IF(EXISTS (SELECT 1 FROM MTRIN WHERE MTRIN.INVOICEKEY = H.INVOICEKEY), '입고완료', '입고대기') AS STATUSNM
       , GPCD('EMPCD', H.EMPCD) AS EMPNM
       , H.RTIME
    FROM MTRCUST_INVOICE_HEADER AS H
   INNER JOIN MTRCUST_INVOICE_DETAIL AS D ON D.INVOICEKEY = H.INVOICEKEY
   WHERE H.INVOICETP = '03'
     AND H.CUSTCD_GIVER = $CUSTCD
     AND LEFT(H.INVOICEDATE, 10) BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
   GROUP BY H.INVOICEKEY, H.INVOICEDATE, H.INWARE, H.CUSTCD_RECIEVER, H.EMPCD, H.RTIME
   ORDER BY H.RTIME DESC;

-- ****************************************************************************
WHEN 'DEL_MOVE_LOT' THEN  
 
  CALL IO_MOVELOT_DEL($INVOICEKEY);

-- * ***************************************************************************
END CASE; END
