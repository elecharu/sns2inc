CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`IO_COMCHK_CANCEL`(
-- *****************************************************************************
-- Comment: 재고실사 승인취소 프로시저
-- Create: 	2024-11-21  	생성 			이대규
-- Modify: 	2026-11-11 					한성수	재고실사 승인취소 마이그레이션 및 로트 재고 원복 처리
-- 			2026-11-24 					한성수	로트 재고 원복을 이전재고(OLDQTY) 덮어쓰기에서 현재고 기준 출고수량 가산·입고수량 차감(로트·창고별 합산)으로 변경
-- *****************************************************************************
  IN $CHKGROUPKEY   VARCHAR(20),
  IN $CHKKEYLIST    MEDIUMTEXT
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$ITEMID    VARCHAR(100);
  DECLARE _$CHKKEY    VARCHAR(20);
  DECLARE _$WARECD    VARCHAR(100);
  DECLARE _$CHKTIME   VARCHAR(19);
  DECLARE _$EMPCD     VARCHAR(100);
-- *****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- *****************************************************************************
-- <재고실사 승인취소 순서>
-- 1. COMLOT 원복
-- 2. COMINLOT, COMOUTLOT 삭제
-- 3. COMIN, COMOUT 삭제
-- 4. COMCHK 수정
-- 5. COMCHK_GROUP 수정
-- *****************************************************************************
  IF $CHKGROUPKEY = '' THEN
    CALL COMERR('실사그룹키가 비어있습니다.');
    LEAVE PROC;
  END IF;

  SET _$EMPCD = IFNULL((SELECT EMPCD FROM SYSUSER WHERE USERID = CALLEMP()), ''); -- 로그인 사원코드

  WHILE LENGTH($CHKKEYLIST) > 0 DO
    CALL COMSPLIT($CHKKEYLIST, _$CHKKEY);

    SET _$WARECD  = (SELECT COMCHK_GROUP.CHKWARECD FROM COMCHK INNER JOIN COMCHK_GROUP ON COMCHK_GROUP.CHKGROUPKEY = COMCHK.CHKGROUPKEY WHERE COMCHK.CHKKEY = _$CHKKEY);
    SET _$ITEMID  = (SELECT CHKITEMCD FROM COMCHK WHERE CHKKEY = _$CHKKEY);
    SET _$CHKTIME = (SELECT CHKAPPTIME FROM COMCHK WHERE CHKKEY = _$CHKKEY);

    IF _$WARECD = '' THEN
      CALL COMERR('창고코드가 비어있습니다.');
      LEAVE PROC;
    END IF;

    IF _$ITEMID = '' THEN
      CALL COMERR('품목ID가 비어있습니다.');
      LEAVE PROC;
    END IF;

    IF _$CHKTIME = '' THEN
      CALL COMERR('승인시간이 비었습니다.');
      LEAVE PROC;
    END IF;

    -- 승인 이후 같은 창고·품목으로 입고 또는 출고가 생겼으면 취소 불가
    IF EXISTS (SELECT INKEY FROM COMIN WHERE WARECD = _$WARECD AND ITEMID = _$ITEMID AND RTIME > _$CHKTIME) THEN
      CALL COMERR('승인 후 입고가 발생하여 취소할 수 없습니다. (동일 창고, 품목 기준)');
      LEAVE PROC;
    END IF;

    IF EXISTS (SELECT OUTKEY FROM COMOUT WHERE WARECD = _$WARECD AND ITEMID = _$ITEMID AND RTIME > _$CHKTIME) THEN
      CALL COMERR('승인 후 출고가 발생하여 취소할 수 없습니다. (동일 창고, 품목 기준)');
      LEAVE PROC;
    END IF;

    -- 1. COMLOT 원복 (현재고 기준 가감, 같은 로트·창고는 합산 후 1회 반영)
    -- 실사출고 취소: 현재고 + 출고수량
    UPDATE COMLOT
    INNER JOIN (SELECT COMOUTLOT.LOTKEY, COMOUT.WARECD, SUM(COMOUTLOT.OUTQTY) AS OUTQTY
                  FROM COMOUT
                 INNER JOIN COMOUTLOT
                    ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
                 WHERE COMOUT.CHKKEY = _$CHKKEY
                 GROUP BY COMOUTLOT.LOTKEY, COMOUT.WARECD) OUTLOT
      ON OUTLOT.LOTKEY = COMLOT.LOTKEY
     AND OUTLOT.WARECD = COMLOT.WARECD
       SET COMLOT.LOTQTY = COMLOT.LOTQTY + OUTLOT.OUTQTY,
           COMLOT.MTIME = CALLTIME(), COMLOT.MEMP = CALLEMP(), COMLOT.MPRG = CALLPRG();

    -- 실사입고 취소: 현재고 - 입고수량
    UPDATE COMLOT
    INNER JOIN (SELECT COMINLOT.LOTKEY, COMIN.WARECD, SUM(COMINLOT.INQTY) AS INQTY
                  FROM COMIN
                 INNER JOIN COMINLOT
                    ON COMINLOT.INKEY = COMIN.INKEY
                 WHERE COMIN.CHKKEY = _$CHKKEY
                 GROUP BY COMINLOT.LOTKEY, COMIN.WARECD) INLOT
      ON INLOT.LOTKEY = COMLOT.LOTKEY
     AND INLOT.WARECD = COMLOT.WARECD
       SET COMLOT.LOTQTY = COMLOT.LOTQTY - INLOT.INQTY,
           COMLOT.MTIME = CALLTIME(), COMLOT.MEMP = CALLEMP(), COMLOT.MPRG = CALLPRG();

    -- 2. COMINLOT, COMOUTLOT 삭제
    DELETE COMINLOT FROM COMINLOT
    INNER JOIN COMIN
      ON COMIN.INKEY = COMINLOT.INKEY
    WHERE COMIN.CHKKEY = _$CHKKEY;

    DELETE COMOUTLOT FROM COMOUTLOT
    INNER JOIN COMOUT
      ON COMOUT.OUTKEY = COMOUTLOT.OUTKEY
    WHERE COMOUT.CHKKEY = _$CHKKEY;

    -- 3. COMIN, COMOUT 삭제
    DELETE FROM COMIN WHERE CHKKEY = _$CHKKEY;
    DELETE FROM COMOUT WHERE CHKKEY = _$CHKKEY;

    -- 4. COMCHK 실사등록 상태로 원복
    UPDATE COMCHK
       SET CHKAPPYN = 'N', CHKAPPEMP = '', CHKAPPTIME = '',
           MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG()
     WHERE CHKKEY = _$CHKKEY;
  END WHILE;

  -- 5. COMCHK_GROUP 미승인으로 수정
  IF (SELECT CHKAPPYN FROM COMCHK_GROUP WHERE CHKGROUPKEY = $CHKGROUPKEY) = 'Y' THEN
    UPDATE COMCHK_GROUP
       SET CHKAPPYN = 'N', CHKAPPEMP = _$EMPCD, CHKAPPTIME = CALLTIME(),
           MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG()
     WHERE CHKGROUPKEY = $CHKGROUPKEY;
  END IF;
-- *****************************************************************************
END IF;
END
