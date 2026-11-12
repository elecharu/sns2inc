CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`LOT1003_R01`(
-- *****************************************************************************
-- Comment: 재고실사관리
-- Create: 	2024-10-31  	생성 			이대규
-- Modify: 	2026-11-11 					한성수	재고실사 관리 마이그레이션 및 승인·취소 검증 추가
-- *****************************************************************************
  IN $SDATE           VARCHAR(10),
  IN $EDATE           VARCHAR(10),
  IN $WARECD          VARCHAR(100),
  IN $ITEMCG          VARCHAR(100),
  IN $CHKKEY          VARCHAR(20),
  IN $ITEMIDLIST      MEDIUMTEXT,
  IN $CHKGROUPKEY     VARCHAR(20),
  IN $CHKNM           VARCHAR(100),
  IN $CHKDATE         VARCHAR(10),
  IN $CHKKEYLIST      MEDIUMTEXT,

-- *****************************************************************************
  IN $CALLTYPE        VARCHAR(50),
  IN $KEYWORD         VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$CHKKEY      VARCHAR(20);
  DECLARE _$CHKLOTKEY   VARCHAR(100);
  DECLARE _$LOTLIST     MEDIUMTEXT;
  DECLARE _$KEYLIST     MEDIUMTEXT;

  CASE $CALLTYPE
  -- *****************************************************************************
  WHEN 'LIST_COMCHK_GROUP' THEN -- 실사그룹 조회

    IF $WARECD = '' THEN
      CALL COMERR('창고를 선택하세요.');
      LEAVE PROC;
    END IF;

    SELECT COMCHK_GROUP.CHKGROUPKEY, COMCHK_GROUP.CHKDATE, MSTITEM.ITEMCG,
           COMCHK_GROUP.CHKWARECD AS WARECD, MSTWARE.WARENM, COMCHK_GROUP.CHKNM,
           SUM(IFNULL(COMCHKLOT.LOTOLDQTY, 0)) AS OLDSUMQTY,
           SUM(IFNULL(COMCHKLOT.LOTCHKQTY, 0)) AS LOTCHKQTY,
           SUM(IFNULL(COMCHKLOT.LOTOLDQTY, 0)) - SUM(IFNULL(COMCHKLOT.LOTCHKQTY, 0)) AS DIFFQTY,
           IF(EXISTS (SELECT CHKKEY FROM COMCHK WHERE CHKGROUPKEY = COMCHK_GROUP.CHKGROUPKEY AND CHKAPPYN <> 'Y'), 'N', 'Y') AS DONEYN
    FROM COMCHK_GROUP
    INNER JOIN COMCHK
      ON COMCHK.CHKGROUPKEY = COMCHK_GROUP.CHKGROUPKEY
    LEFT JOIN COMCHKLOT
      ON COMCHKLOT.CHKKEY = COMCHK.CHKKEY
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = COMCHK.CHKITEMCD
    LEFT JOIN MSTWARE
      ON MSTWARE.WARECD = COMCHK_GROUP.CHKWARECD
    WHERE COMCHK_GROUP.CHKDATE BETWEEN $SDATE AND $EDATE
      AND COMCHK_GROUP.CHKWARECD = $WARECD
      AND MSTITEM.ITEMCG LIKE CONCAT($ITEMCG, '%')
    GROUP BY COMCHK_GROUP.CHKGROUPKEY
    ORDER BY COMCHK_GROUP.CHKDATE, COMCHK_GROUP.CHKWARECD, COMCHK_GROUP.CHKNM;

  -- *****************************************************************************
  WHEN 'LIST_COMCHK' THEN -- 실사품목리스트 조회

    SELECT COMCHK.CHKKEY, MSTITEM.ITEMCG, MSTITEM.ITEMCD, MSTITEM.ITEMNM,
           SUM(IFNULL(COMCHKLOT.LOTOLDQTY, 0)) AS OLDSUMQTY,
           SUM(IFNULL(COMCHKLOT.LOTCHKQTY, 0)) AS LOTCHKQTY,
           SUM(IFNULL(COMCHKLOT.LOTCHKQTY, 0) - IFNULL(COMCHKLOT.LOTOLDQTY, 0)) AS DIFFQTY,
           COMCHK.CHKAPPYN
    FROM COMCHK
    LEFT JOIN COMCHKLOT
      ON COMCHKLOT.CHKKEY = COMCHK.CHKKEY
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = COMCHK.CHKITEMCD
    WHERE COMCHK.CHKGROUPKEY = $CHKGROUPKEY
    GROUP BY COMCHK.CHKKEY
    ORDER BY MSTITEM.ITEMCG, MSTITEM.ITEMCD;

  -- *****************************************************************************
  WHEN 'LIST_COMCHKLOT' THEN -- 실사로트리스트 조회

    SELECT CHKKEY, CHKLOTKEY, CHKSCANTIME, LOTOLDQTY, LOTCHKQTY, LOTCHKQTY - LOTOLDQTY AS DIFFQTY
    FROM COMCHKLOT
    WHERE CHKKEY = $CHKKEY
    ORDER BY CHKLOTKEY;

  -- *****************************************************************************
  WHEN 'SEARCH_ITEMLIST' THEN -- 실사지시생성 팝업 재고 품목 조회

    SELECT MSTITEM.ITEMID, MSTITEM.ITEMCD, MSTITEM.ITEMCG, MSTITEM.ITEMNM
    FROM MSTITEM
    WHERE ($ITEMCG = '' OR MSTITEM.ITEMCG = $ITEMCG)
      AND EXISTS (SELECT LOTKEY FROM COMLOT WHERE COMLOT.ITEMID = MSTITEM.ITEMID AND COMLOT.LOTQTY > 0 AND ($WARECD = '' OR COMLOT.WARECD = $WARECD))
    ORDER BY MSTITEM.ITEMCD, MSTITEM.ITEMCG, MSTITEM.ITEMNM;

  -- *****************************************************************************
  WHEN 'COMCHK_ADD' THEN -- 실사지시 생성

    CALL IO_COMCHK_ADD($CHKDATE, $WARECD, $CHKNM, $ITEMIDLIST);

  -- *****************************************************************************
  WHEN 'COMCHK_DEL' THEN -- 실사품목 삭제

    CALL IO_COMCHK_DEL($CHKGROUPKEY, $CHKKEYLIST);

  -- *****************************************************************************
  WHEN 'COMCHK_CONFIRM' THEN -- 실사승인 (선택한 품목 중 이미 승인된 품목이 있으면 아무것도 승인하지 않음)

    SET _$KEYLIST = $CHKKEYLIST;

    WHILE LENGTH(_$KEYLIST) > 0 DO
      CALL COMSPLIT(_$KEYLIST, _$CHKKEY);

      IF (SELECT CHKAPPYN FROM COMCHK WHERE CHKKEY = _$CHKKEY) = 'Y' THEN
        CALL COMERR('이미 승인된 품목이 선택되어 있습니다.\n승인된 품목을 선택 해제한 후 다시 승인해주세요.');
        LEAVE PROC;
      END IF;
    END WHILE;

    WHILE LENGTH($CHKKEYLIST) > 0 DO
      CALL COMSPLIT($CHKKEYLIST, _$CHKKEY);

      CALL IO_COMCHK_CONFIRM(_$CHKKEY);
    END WHILE;

  -- *****************************************************************************
  WHEN 'COMCHK_CANCEL' THEN -- 실사승인 취소 (선택한 품목 중 미승인 품목이 있으면 아무것도 취소하지 않음, 전산재고 원복 후 로트 실사수량도 입력 전으로 초기화)

    SET _$KEYLIST = $CHKKEYLIST;

    WHILE LENGTH(_$KEYLIST) > 0 DO
      CALL COMSPLIT(_$KEYLIST, _$CHKKEY);

      IF IFNULL((SELECT CHKAPPYN FROM COMCHK WHERE CHKKEY = _$CHKKEY), '') <> 'Y' THEN
        CALL COMERR('승인되지 않은 품목이 선택되어 있습니다.\n승인되지 않은 품목을 선택 해제한 후 다시 취소해주세요.');
        LEAVE PROC;
      END IF;
    END WHILE;

    CALL IO_COMCHK_CANCEL($CHKGROUPKEY, $CHKKEYLIST);

    WHILE LENGTH($CHKKEYLIST) > 0 DO
      CALL COMSPLIT($CHKKEYLIST, _$CHKKEY);

      SET _$LOTLIST = (SELECT GROUP_CONCAT(CHKLOTKEY SEPARATOR '»') FROM COMCHKLOT WHERE CHKKEY = _$CHKKEY AND CHKSCANTIME <> '');

      WHILE LENGTH(_$LOTLIST) > 0 DO
        CALL COMSPLIT(_$LOTLIST, _$CHKLOTKEY);

        CALL IO_COMCHKLOT_DEL(_$CHKKEY, _$CHKLOTKEY);
      END WHILE;
    END WHILE;

  -- *****************************************************************************
  END CASE;
END
