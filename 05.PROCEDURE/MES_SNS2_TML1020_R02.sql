CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML1020_R02(
-- *****************************************************************************
-- Comment: 외주반출 (SNS 2공장 사내 양품창고 → 외주처 창고 재고이동)
--          이동할 LOT 바코드 스캔 → 그리드에 추가 (이동량 기본 = 현재고, 수정 가능) → 등록
--          같은 LOT 번호로 창고별 재고 관리 (IO_MOVELOT_WARE), 입출고구분 02 창고이동
-- Create: 2026-11-10
-- Modify: 2026-11-12: [이동내역삭제] 탭 - LIST_MOVE(조회), DEL_MOVE(삭제, IO_MOVELOT_WARE_DEL) 추가
-- Modify: 2026-11-11: 등록 후 ERP 인터페이스(WORK_20, 창고이동 FLAG 20 외주반출) 송신 추가
-- *****************************************************************************
  IN $MOVEDATE      VARCHAR(10),    -- 이동일자
  IN $OUTWARE       VARCHAR(20),    -- 출고창고 (사내 양품창고)
  IN $INWARE        VARCHAR(20),    -- 입고창고 (외주처 창고)
  IN $SCANLOT       VARCHAR(100),   -- 스캔 LOT
  IN $LOTKEY_LIST   MEDIUMTEXT,     -- 이동 LOT
  IN $MOVEQTY_LIST  MEDIUMTEXT,     -- LOT 별 이동량
  IN $SDATE        VARCHAR(10),    -- 이동내역 조회 시작일
  IN $EDATE        VARCHAR(10),    -- 이동내역 조회 종료일
  IN $GROUPKEY_LIST MEDIUMTEXT,    -- 삭제할 이동 GROUPKEY
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

-- ****************************************************************************
CASE $CALLTYPE

-- ****************************************************************************
WHEN 'SCAN_LOT' THEN -- LOT 스캔 : 출고창고에 재고가 있으면 그리드에 추가할 행

  IF IFNULL($OUTWARE, '') = '' THEN
    CALL COMERR('출고창고를 선택하세요.');
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

  SELECT
      COMLOT.LOTKEY
    , CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL(COMLOT.HEATNO, '') AS HEATNO
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , COMLOT.LOTQTY AS MOVEQTY   -- 이동량 기본 = 현재고
    , COMLOT.LOTQTY              -- 잔여재고량
    , '' AS REMARK
  FROM COMLOT
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = COMLOT.ITEMID
  WHERE COMLOT.LOTKEY = $SCANLOT
    AND COMLOT.WARECD = $OUTWARE;

-- ****************************************************************************
WHEN 'ADD_MOVE' THEN -- 등록 : 사내 양품창고 → 외주처 창고

  IF IFNULL($OUTWARE, '') = '' THEN
    CALL COMERR('출고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($INWARE, '') = '' THEN
    CALL COMERR('입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MSTWARE WHERE MSTWARE.WARECD = $OUTWARE AND IFNULL(MSTWARE.CUSTCD, '') = '') THEN
    CALL COMERR('출고창고는 사내 창고만 선택할 수 있습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MSTWARE WHERE MSTWARE.WARECD = $INWARE AND IFNULL(MSTWARE.CUSTCD, '') <> '') THEN
    CALL COMERR('입고창고는 외주처 창고만 선택할 수 있습니다.');
    LEAVE PROC;
  END IF;

  CALL IO_MOVELOT_WARE($MOVEDATE, $OUTWARE, $INWARE, '02', '02', $LOTKEY_LIST, $MOVEQTY_LIST);

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- ERP 인터페이스 (창고이동 FLAG 20 외주반출 : I)
  CALL IO_ERP_INTERFACE('WORK_20', @MOVEGROUPKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

-- ****************************************************************************
WHEN 'LIST_MOVE' THEN -- 이동내역 조회 (이동일자 기간, 이 메뉴로 등록한 이동만, LOT 행 단위)

  SELECT
      COMOUT.GROUPKEY
    , COMOUT.OUTDATE AS MOVEDATE
    , COMOUTLOT.LOTKEY
    , CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = COMOUTLOT.WARECD), COMOUTLOT.WARECD) AS OUTWARENM
    , IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = COMINLOT.WARECD), COMINLOT.WARECD) AS INWARENM
    , COMOUTLOT.OUTQTY AS MOVEQTY
    , IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = COMINLOT.LOTKEY AND COMLOT.WARECD = COMINLOT.WARECD), 0) AS INLOTQTY
    , GPCD('EMPCD', COMOUT.EMPCD) AS EMPNM
    , COMOUT.RTIME
  FROM COMOUT
  INNER JOIN COMOUTLOT ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
  INNER JOIN COMIN ON COMIN.GROUPKEY = COMOUT.GROUPKEY
  INNER JOIN COMINLOT ON COMINLOT.INKEY = COMIN.INKEY
                     AND COMINLOT.LOTKEY = COMOUTLOT.LOTKEY
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = COMOUTLOT.ITEMID
  WHERE COMOUT.OUTTP = '02'
    AND COMOUT.RPRG = 'TML1020_R02'
    AND COMOUT.OUTDATE BETWEEN LEFT($SDATE, 10) AND LEFT($EDATE, 10)
  ORDER BY COMOUT.RTIME DESC, COMOUTLOT.LOTKEY;

-- ****************************************************************************
WHEN 'DEL_MOVE' THEN -- 이동내역 삭제 (선택한 이동 건 전체를 되돌림, 재고 원복)

  CALL IO_MOVELOT_WARE_DEL($GROUPKEY_LIST);

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

-- ****************************************************************************
END CASE; END