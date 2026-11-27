CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_MOVELOT_WARE_DEL(
-- *****************************************************************************
-- Comment: LOT 창고이동 삭제 (IO_MOVELOT_WARE 로 만든 이동 1건 = GROUPKEY 단위를 되돌림)
--          입고창고에서 이동량을 빼 출고창고로 돌려놓고, 출고·입고 이력(COMOUT·COMOUTLOT·COMIN·COMINLOT) 삭제
--          ERP 로는 송신한 I 행을 D 로 다시 송신 (IO_ERP_INTERFACE WORK_DEL)
-- Create: 2026-11-12
-- Modify: 2026-11-27 김영철 ERP 전송 여부와 상관없이 삭제 가능, 삭제 시 D 송신 (기존: 미전송 행은 삭제, 전송된 이동은 삭제 불가)
-- *****************************************************************************
  IN $GROUPKEY_LIST   MEDIUMTEXT      -- 삭제할 이동 GROUPKEY 목록 (COMSPLIT 구분자)
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$GROUPKEY  VARCHAR(100);
  DECLARE _$CNT       INT DEFAULT 0;
  DECLARE _$MAGAMDT   VARCHAR(10);

  DECLARE _$DONE      INT DEFAULT 0;
  DECLARE _$OUTKEY    VARCHAR(100);
  DECLARE _$LOTKEY    VARCHAR(100);
  DECLARE _$OUTWARE   VARCHAR(20);
  DECLARE _$INWARE    VARCHAR(20);
  DECLARE _$QTY       DECIMAL(20, 8);

  DECLARE CUR_LOT CURSOR FOR
    SELECT COMOUTLOT.OUTKEY, COMOUTLOT.LOTKEY, COMOUTLOT.WARECD, COMINLOT.WARECD, COMOUTLOT.OUTQTY
      FROM COMOUT
     INNER JOIN COMOUTLOT ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
     INNER JOIN COMIN ON COMIN.GROUPKEY = COMOUT.GROUPKEY
     INNER JOIN COMINLOT ON COMINLOT.INKEY = COMIN.INKEY
                        AND COMINLOT.LOTKEY = COMOUTLOT.LOTKEY
     WHERE COMOUT.GROUPKEY = _$GROUPKEY;

  DECLARE CONTINUE HANDLER FOR NOT FOUND SET _$DONE = 1;

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  IF IFNULL($GROUPKEY_LIST, '') = '' THEN
    CALL COMERR('삭제할 이동 이력이 없습니다.');
    LEAVE PROC;
  END IF;

  WHILE LENGTH(IFNULL($GROUPKEY_LIST, '')) > 0 DO
    CALL COMSPLIT($GROUPKEY_LIST, _$GROUPKEY);

    IF IFNULL(_$GROUPKEY, '') <> '' THEN

      IF NOT EXISTS (SELECT 1 FROM COMOUT WHERE COMOUT.GROUPKEY = _$GROUPKEY) THEN
        CALL COMERR('이미 삭제되었거나 없는 이동 이력입니다.');
        LEAVE PROC;
      END IF;

      -- ERP 마감 확인 (이동일자)
      SET _$MAGAMDT = (SELECT MIN(COMOUT.OUTDATE) FROM COMOUT WHERE COMOUT.GROUPKEY = _$GROUPKEY);

      IF EXISTS (SELECT 1 FROM MSTMAGAM_PRD WHERE MSTMAGAM_PRD.BDVCD = '71' AND MSTMAGAM_PRD.EDT = _$MAGAMDT) THEN
        CALL COMERR(CONCAT('ERP에서 마감된 일자 입니다. (', _$MAGAMDT, ')'));
        LEAVE PROC;
      END IF;

      -- 1. 확인 : 입고창고 재고가 이동량보다 적으면 (이미 사용·이동됨) 삭제 불가
      SET _$DONE = 0;
      OPEN CUR_LOT;
      LOOP_CHK: LOOP
        FETCH CUR_LOT INTO _$OUTKEY, _$LOTKEY, _$OUTWARE, _$INWARE, _$QTY;
        IF _$DONE = 1 THEN LEAVE LOOP_CHK; END IF;

        IF IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = _$INWARE), 0) < _$QTY THEN
          CLOSE CUR_LOT;
          CALL COMERR(CONCAT('입고창고 재고가 이동량보다 적어 삭제할 수 없습니다. (이미 사용된 재고)'
                            , '\n- 로트번호: ', _$LOTKEY));
          LEAVE PROC;
        END IF;
      END LOOP LOOP_CHK;
      CLOSE CUR_LOT;

      -- 2. 되돌림 : 입고창고 차감, 출고창고 복원
      SET _$DONE = 0;
      OPEN CUR_LOT;
      LOOP_DEL: LOOP
        FETCH CUR_LOT INTO _$OUTKEY, _$LOTKEY, _$OUTWARE, _$INWARE, _$QTY;
        IF _$DONE = 1 THEN LEAVE LOOP_DEL; END IF;

        UPDATE COMLOT
           SET COMLOT.LOTQTY = COMLOT.LOTQTY - _$QTY
             , COMLOT.CRTQTY = COMLOT.CRTQTY - _$QTY
             , COMLOT.MTIME  = CALLTIME()
             , COMLOT.MEMP   = CALLEMP()
             , COMLOT.MPRG   = CALLPRG()
         WHERE COMLOT.LOTKEY = _$LOTKEY
           AND COMLOT.WARECD = _$INWARE;

        -- 이 이동으로 새로 만들어진 입고창고 LOT (수량 0, 생성량 0) 는 삭제
        DELETE FROM COMLOT
         WHERE COMLOT.LOTKEY = _$LOTKEY
           AND COMLOT.WARECD = _$INWARE
           AND COMLOT.LOTQTY = 0
           AND COMLOT.CRTQTY = 0;

        UPDATE COMLOT
           SET COMLOT.LOTQTY = COMLOT.LOTQTY + _$QTY
             , COMLOT.MTIME  = CALLTIME()
             , COMLOT.MEMP   = CALLEMP()
             , COMLOT.MPRG   = CALLPRG()
         WHERE COMLOT.LOTKEY = _$LOTKEY
           AND COMLOT.WARECD = _$OUTWARE;
      END LOOP LOOP_DEL;
      CLOSE CUR_LOT;

      -- 3. 이력 삭제 (출고 → 입고)
      DELETE COMOUTLOT FROM COMOUTLOT
       INNER JOIN COMOUT ON COMOUT.OUTKEY = COMOUTLOT.OUTKEY
       WHERE COMOUT.GROUPKEY = _$GROUPKEY;

      DELETE FROM COMOUT WHERE COMOUT.GROUPKEY = _$GROUPKEY;

      DELETE COMINLOT FROM COMINLOT
       INNER JOIN COMIN ON COMIN.INKEY = COMINLOT.INKEY
       WHERE COMIN.GROUPKEY = _$GROUPKEY;

      DELETE FROM COMIN WHERE COMIN.GROUPKEY = _$GROUPKEY;

      -- ERP 인터페이스 (창고이동 삭제 : 송신한 I 를 D 로 다시 송신)
      CALL IO_ERP_INTERFACE('WORK_DEL', _$GROUPKEY, 'D');

      IF IFNULL(@ERRMSG, '') <> '' THEN
        LEAVE PROC;
      END IF;

      SET _$CNT = _$CNT + 1;
    END IF;
  END WHILE;

  SELECT _$CNT AS DELCNT;

-- ****************************************************************************
END IF; END
