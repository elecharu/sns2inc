CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML1010_R04(
-- *****************************************************************************
-- Comment: 외주간 재고 이동
-- Create: 2026-10-08 : 김영철
-- Modify: 2026-11-12: [거래명세서 발행]·[이동내역삭제] 탭 - LIST_INVOICE, DEL_MOVE_LOT(IO_MOVELOT_OSC_DEL) 추가 ($INVOICEKEY, $SDATE, $EDATE)
-- Modify: 2026-11-12: 시편수량($TESTQTY_LIST) 추가 (이동량에 포함)
-- Modify: 2026-11-12: ERP POP 화면 구조(바코드 스캔) 로 변경 - SCAN_LOT 추가 (출고창고 $OUTWARE, 스캔 LOT $SCANLOT)
-- Modify: 2026-11-12: 재고 조회에서 입고 전 외주이동 거래명세서에 올라간 LOT 제외
-- Modify: 2026-11-12: 이동 거래처 선택 → 입고창고($INWARE, 외주창고) 선택. 이동 거래처는 입고창고의 거래처로 정함
-- *****************************************************************************
  IN $CUSTCD            VARCHAR(100),
  IN $ITEMID            VARCHAR(100),
  IN $MOVEDATE          VARCHAR(100),
  IN $MOVECUSTCD        VARCHAR(100),
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

--   DECLARE _$ITEMID       VARCHAR(100);
  
-- ****************************************************************************
CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_COMLOT' THEN

  SELECT 
    A.WARECD, A.LOTKEY, A.ITEMID, B.ITEMCD, 
    B.ITEMNM, B.ITEMSPEC, A.LOTQTY, B.ITEMUNIT,
    A.LOTTP,
    CASE WHEN A.LOTTP = '02' THEN 'YELLOW' ELSE 'WHITH' END AS BACKGROUND
    FROM COMLOT AS A
    INNER JOIN MSTITEM AS B ON A.ITEMID = B.ITEMID
    INNER JOIN MSTWARE AS C ON A.WARECD = C.WARECD
    WHERE C.CUSTCD LIKE CONCAT('%', $CUSTCD, '%')
      AND A.ITEMID LIKE CONCAT('%', $ITEMID, '%')
      AND LOTQTY > 0
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

  IF IFNULL($INWARE, '') = '' THEN
    CALL COMERR('입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 입고창고(외주창고)의 거래처 = 이동 거래처
  SET $MOVECUSTCD = IFNULL((SELECT MSTWARE.CUSTCD FROM MSTWARE WHERE MSTWARE.WARECD = $INWARE AND MSTWARE.USEYN = 'Y'), '');

  IF $MOVECUSTCD = '' THEN
    CALL COMERR('입고창고는 외주처 창고만 선택할 수 있습니다.');
    LEAVE PROC;
  END IF;

  CALL IO_MOVELOT_OSC($CUSTCD, $MOVEDATE, $MOVECUSTCD, $WARECD_LIST, $LOTKEY_LIST, $LOTQTY_LIST, $TESTQTY_LIST);

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
       , H.INVOICEDATE  AS INDATE
       , GPCD('CUSTCD', H.CUSTCD_GIVER) AS OUTCUSTCD
       , GPCD('CUSTCD', H.CUSTCD_RECIEVER) AS INCUSTCD
       , GPCD('LOTTP', D.LOTTP) AS LOTTP
    FROM MTRCUST_INVOICE_DETAIL AS D
   INNER JOIN MTRCUST_INVOICE_HEADER AS H ON D.INVOICEKEY = H.INVOICEKEY
   INNER JOIN MSTITEM AS I ON D.ITEMID = I.ITEMID
   WHERE D.INVOICEKEY = @INVOICEKEY
   ORDER BY D.LOTTP, D.LOTKEY;

-- ****************************************************************************
WHEN 'LIST_INVOICE' THEN -- 이동 거래명세서 조회 (이동일자 기간, 로그인한 외주처가 낸 외주간 이동 거래명세서) - [거래명세서 발행]·[이동내역삭제] 탭

  SELECT H.INVOICEKEY
       , H.INVOICEDATE AS MOVEDATE
       , GPCD('CUSTCD', H.CUSTCD_RECIEVER) AS INNM
       , COUNT(D.LOTKEY) AS LOTCNT
       , SUM(D.LOTQTY) AS TOTQTY
       , SUM(IFNULL(D.TESTQTY, 0)) AS TESTQTY
       , '이동완료' AS STATUSNM
       , GPCD('EMPCD', H.EMPCD) AS EMPNM
       , H.RTIME
    FROM MTRCUST_INVOICE_HEADER AS H
   INNER JOIN MTRCUST_INVOICE_DETAIL AS D ON D.INVOICEKEY = H.INVOICEKEY
   WHERE H.INVOICETP = '04'
     AND H.CUSTCD_GIVER = $CUSTCD
     AND LEFT(H.INVOICEDATE, 10) BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
   GROUP BY H.INVOICEKEY, H.INVOICEDATE, H.INWARE, H.CUSTCD_RECIEVER, H.EMPCD, H.RTIME
   ORDER BY H.RTIME DESC;

-- ****************************************************************************
WHEN 'DEL_MOVE_LOT' THEN -- 외주간 이동 삭제 (재고 원복)

  CALL IO_MOVELOT_OSC_DEL($INVOICEKEY);

-- * ***************************************************************************
END CASE; END
