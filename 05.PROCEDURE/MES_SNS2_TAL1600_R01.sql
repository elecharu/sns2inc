CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`TAL1600_R01`(
-- *****************************************************************************
-- Comment: 재고실사 등록 (태블릿)
-- Create: 	2026-11-12  	생성 			한성수	재고실사 등록(태블릿) 신규 생성
-- *****************************************************************************
  IN $WARECD          VARCHAR(100),
  IN $CHKGROUPKEY     VARCHAR(20),
  IN $CHKKEY          VARCHAR(20),
  IN $LOTKEY          VARCHAR(100),
  IN $CHKQTY          DECIMAL(20, 8),

-- *****************************************************************************
  IN $CALLTYPE        VARCHAR(50),
  IN $KEYWORD         VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$WARECD      VARCHAR(100);
  DECLARE _$ITEMID      VARCHAR(100);
  DECLARE _$CHKKEY      VARCHAR(20);

  CASE $CALLTYPE
  -- *****************************************************************************
  WHEN 'LIST_COMCHK_GROUP' THEN -- 실사지시 조회 (승인 안 된 실사지시, 로트 등록 진행)

    IF $WARECD = '' THEN
      CALL COMERR('창고를 지정하세요.');
      LEAVE PROC;
    END IF;

    SELECT COMCHK_GROUP.CHKGROUPKEY, COMCHK_GROUP.CHKDATE, COMCHK_GROUP.CHKWARECD AS WARECD, MSTWARE.WARENM, COMCHK_GROUP.CHKNM,
           COUNT(DISTINCT COMCHK.CHKKEY) AS ITEMCNT,
           SUM(IF(COMCHKLOT.CHKSCANTIME <> '', 1, 0)) AS SCANLOTCNT,
           COUNT(COMCHKLOT.CHKLOTKEY) AS LOTCNT
    FROM COMCHK_GROUP
    INNER JOIN COMCHK
      ON COMCHK.CHKGROUPKEY = COMCHK_GROUP.CHKGROUPKEY
     AND COMCHK.CHKAPPYN <> 'Y'
    LEFT JOIN COMCHKLOT
      ON COMCHKLOT.CHKKEY = COMCHK.CHKKEY
    LEFT JOIN MSTWARE
      ON MSTWARE.WARECD = COMCHK_GROUP.CHKWARECD
    WHERE COMCHK_GROUP.CHKAPPYN <> 'Y'
      AND COMCHK_GROUP.CHKWARECD = $WARECD
    GROUP BY COMCHK_GROUP.CHKGROUPKEY
    ORDER BY COMCHK_GROUP.CHKDATE, COMCHK_GROUP.CHKNM;

  -- *****************************************************************************
  WHEN 'LIST_COMCHK' THEN -- 실사품목 조회 (승인 안 된 품목, 실사수량 0 흰색·같으면 초록·다르면 분홍)

    SELECT COMCHK.CHKKEY, MSTITEM.ITEMID, MSTITEM.ITEMCG, MSTITEM.ITEMCD, MSTITEM.ITEMNM,
           SUM(COMCHKLOT.LOTOLDQTY) AS LOTQTY,
           SUM(COMCHKLOT.LOTCHKQTY) AS CHKQTY,
           SUM(IF(COMCHKLOT.CHKSCANTIME <> '', 1, 0)) AS SCANLOTCNT,
           COUNT(COMCHKLOT.CHKLOTKEY) AS LOTCNT,
           CASE WHEN SUM(COMCHKLOT.LOTCHKQTY) = 0 THEN 'WHITE'
                WHEN SUM(COMCHKLOT.LOTOLDQTY) = SUM(COMCHKLOT.LOTCHKQTY) THEN 'LIGHTGREEN'
                ELSE 'PINK' END AS BACKGROUND
    FROM COMCHK
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = COMCHK.CHKITEMCD
    INNER JOIN COMCHKLOT
      ON COMCHKLOT.CHKKEY = COMCHK.CHKKEY
    WHERE COMCHK.CHKGROUPKEY = $CHKGROUPKEY
      AND COMCHK.CHKAPPYN <> 'Y'
    GROUP BY COMCHK.CHKKEY
    ORDER BY MSTITEM.ITEMCG, MSTITEM.ITEMCD;

  -- *****************************************************************************
  WHEN 'LIST_COMLOT' THEN -- 실사로트 조회 (로트별 전산·실사수량, 품목 합계)

    SELECT COMCHKLOT.CHKKEY, COMCHKLOT.CHKLOTKEY AS LOTKEY, COMCHKLOT.LOTOLDQTY AS LOTQTY, COMCHKLOT.LOTCHKQTY AS SCANQTY,
           COMCHKLOT.CHKSCANTIME,
           CASE WHEN COMCHKLOT.CHKSCANTIME = '' THEN 'WHITE'
                WHEN COMCHKLOT.LOTOLDQTY = COMCHKLOT.LOTCHKQTY THEN 'LIGHTGREEN'
                ELSE 'PINK' END AS BACKGROUND
    FROM COMCHKLOT
    WHERE COMCHKLOT.CHKKEY = $CHKKEY
    ORDER BY COMCHKLOT.CHKLOTKEY;

    SELECT FORMAT(SUM(COMCHKLOT.LOTOLDQTY), 0) AS LOTQTY, FORMAT(SUM(COMCHKLOT.LOTCHKQTY), 0) AS CHKQTY
    FROM COMCHKLOT
    WHERE COMCHKLOT.CHKKEY = $CHKKEY;

  -- *****************************************************************************
  WHEN 'COMCHKLOT_SCAN' THEN -- 로트 스캔 (실사품목 로트인지·재고 0·이미 등록 확인 후 전산재고와 실사키 반환)

    IF $CHKGROUPKEY = '' THEN
      CALL COMERR('실사그룹키가 없습니다.');
      LEAVE PROC;
    END IF;

    IF $LOTKEY = '' THEN
      CALL COMERR('LOT를 입력해주세요.');
      LEAVE PROC;
    END IF;

    SET _$WARECD = IFNULL((SELECT CHKWARECD FROM COMCHK_GROUP WHERE CHKGROUPKEY = $CHKGROUPKEY), '');

    IF _$WARECD = '' THEN
      CALL COMERR('창고코드가 없습니다.');
      LEAVE PROC;
    END IF;

    SET _$ITEMID = IFNULL((SELECT ITEMID FROM COMLOT WHERE LOTKEY = $LOTKEY AND WARECD = _$WARECD), '');

    IF _$ITEMID = '' THEN
      CALL COMERR('존재하지 않는 LOT 입니다.');
      LEAVE PROC;
    END IF;

    SET _$CHKKEY = IFNULL((SELECT CHKKEY FROM COMCHK WHERE CHKGROUPKEY = $CHKGROUPKEY AND CHKITEMCD = _$ITEMID), '');

    IF _$CHKKEY = '' THEN
      CALL COMERR(CONCAT('실사품목에 속하지 않는 품목의 LOT입니다. ', $LOTKEY));
      LEAVE PROC;
    END IF;

    IF NOT EXISTS (SELECT CHKLOTKEY FROM COMCHKLOT WHERE CHKKEY = _$CHKKEY AND CHKLOTKEY = $LOTKEY) THEN
      CALL COMERR(CONCAT('실사지시에 없는 LOT입니다. ', $LOTKEY));
      LEAVE PROC;
    END IF;

    IF EXISTS (SELECT LOTKEY FROM COMLOT WHERE LOTKEY = $LOTKEY AND WARECD = _$WARECD AND LOTQTY = 0) THEN
      CALL COMERR('재고 수량이 0 입니다.');
      LEAVE PROC;
    END IF;

    IF (SELECT CHKSCANTIME FROM COMCHKLOT WHERE CHKKEY = _$CHKKEY AND CHKLOTKEY = $LOTKEY) <> '' THEN
      CALL COMERR('이미 실사등록 하셨습니다.');
      LEAVE PROC;
    END IF;

    SELECT LOTQTY, _$CHKKEY AS CHKKEY
    FROM COMLOT
    WHERE LOTKEY = $LOTKEY
      AND WARECD = _$WARECD;

  -- *****************************************************************************
  WHEN 'COMCHKLOT_ADD' THEN -- 실사 등록 (LOT 미입력, 음수 수량, 실사지시에 없는 로트는 IO_COMCHKLOT_ADD 전에 먼저 확인)

    IF $LOTKEY = '' THEN
      CALL COMERR('LOT를 입력해주세요.');
      LEAVE PROC;
    END IF;

    IF $CHKQTY < 0 THEN
      CALL COMERR('실사 수량은 0 이상으로 입력해주세요.');
      LEAVE PROC;
    END IF;

    IF NOT EXISTS (SELECT COMCHKLOT.CHKLOTKEY
                   FROM COMCHK
                   INNER JOIN COMCHKLOT
                     ON COMCHKLOT.CHKKEY = COMCHK.CHKKEY
                   WHERE COMCHK.CHKGROUPKEY = $CHKGROUPKEY
                     AND COMCHKLOT.CHKLOTKEY = $LOTKEY) THEN
      CALL COMERR(CONCAT('실사지시에 없는 LOT입니다. ', $LOTKEY));
      LEAVE PROC;
    END IF;

    CALL IO_COMCHKLOT_ADD($CHKGROUPKEY, $LOTKEY, $CHKQTY);

  -- *****************************************************************************
  WHEN 'COMCHKLOT_DEL' THEN -- 실사 등록 삭제 (실사수량 0, 스캔정보 초기화)

    CALL IO_COMCHKLOT_DEL($CHKKEY, $LOTKEY);

  -- *****************************************************************************
  END CASE;
END
