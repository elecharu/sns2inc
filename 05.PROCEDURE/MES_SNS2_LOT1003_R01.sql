CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`LOT1003_R01`(
-- *****************************************************************************
-- Comment: 재고실사관리
-- Create: 	2024-10-31  	생성 			이대규
-- Modify: 	2026-11-11 					한성수	마이그레이션 (SEA 원본 동작 유지, 품목 ITEMID·품목유형 ITEMCG·창고명 MSTWARE로 변경, 승인취소 시 로트 실사수량 초기화)
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
           IF(COMCHK_COUNT.COUNT_N = 0, 'Y', 'N') AS DONEYN
    FROM COMCHK_GROUP
    INNER JOIN COMCHK
      ON COMCHK.CHKGROUPKEY = COMCHK_GROUP.CHKGROUPKEY
    LEFT JOIN COMCHKLOT
      ON COMCHKLOT.CHKKEY = COMCHK.CHKKEY
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = COMCHK.CHKITEMCD
    LEFT JOIN MSTWARE
      ON MSTWARE.WARECD = COMCHK_GROUP.CHKWARECD
    INNER JOIN (SELECT CHKGROUPKEY, SUM(IF(CHKAPPYN != 'Y', 1, 0)) AS COUNT_N
                FROM COMCHK
                GROUP BY CHKGROUPKEY) AS COMCHK_COUNT
      ON COMCHK_COUNT.CHKGROUPKEY = COMCHK_GROUP.CHKGROUPKEY
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
    GROUP BY COMCHK.CHKITEMCD
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
    INNER JOIN COMLOT
      ON COMLOT.ITEMID = MSTITEM.ITEMID
     AND COMLOT.LOTQTY > 0
    WHERE IF($ITEMCG = '', 1 = 1, MSTITEM.ITEMCG = $ITEMCG)
      AND IF($WARECD = '', 1 = 1, COMLOT.WARECD = $WARECD)
    GROUP BY MSTITEM.ITEMID
    ORDER BY MSTITEM.ITEMCD, MSTITEM.ITEMCG, MSTITEM.ITEMNM;

  -- *****************************************************************************
  WHEN 'COMCHK_ADD' THEN -- 실사지시 생성

    CALL IO_COMCHK_ADD($CHKDATE, $WARECD, $CHKNM, $ITEMIDLIST);

  -- *****************************************************************************
  WHEN 'COMCHK_DEL' THEN -- 실사품목 삭제

    CALL IO_COMCHK_DEL($CHKGROUPKEY, $CHKKEYLIST);

  -- *****************************************************************************
  WHEN 'COMCHK_CONFIRM' THEN -- 실사승인

    WHILE LENGTH($CHKKEYLIST) > 0 DO
      CALL COMSPLIT($CHKKEYLIST, _$CHKKEY);

      CALL IO_COMCHK_CONFIRM(_$CHKKEY);
    END WHILE;

  -- *****************************************************************************
  WHEN 'COMCHK_CANCEL' THEN -- 실사승인 취소 (전산재고 원복 후 로트 실사수량도 입력 전으로 초기화)

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
