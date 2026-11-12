CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_MOVELOT_WARE(
-- *****************************************************************************
-- Comment: LOT 창고이동 (같은 LOT 번호로 창고별 재고 관리) - TML1020_R02 외주반출 등 창고이동 공통
--          출고창고 LOT 에서 이동량만큼 빼고, 입고창고에 같은 LOT 번호로 더함 (없으면 새로 만듦)
--          LOT 마다 출고(COMOUT·COMOUTLOT)·입고(COMIN·COMINLOT) 이력, 한 번 이동은 같은 GROUPKEY
-- Create: 2026-11-10
-- Modify: 2026-11-11: 이동 GROUPKEY 를 @MOVEGROUPKEY 로 남김 (호출 화면의 ERP 인터페이스용)
-- *****************************************************************************
  IN $MOVEDATE      VARCHAR(10),    -- 이동일자 (수불일자)
  IN $OUTWARE       VARCHAR(20),    -- 출고창고
  IN $INWARE        VARCHAR(20),    -- 입고창고
  IN $OUTTP         VARCHAR(10),    -- 출고구분 (OUTTP)
  IN $INTP          VARCHAR(10),    -- 입고구분 (INTP)
  IN $LOTKEY_LIST   MEDIUMTEXT,     -- 이동 LOT
  IN $MOVEQTY_LIST  MEDIUMTEXT      -- LOT 별 이동량
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$GROUPKEY  VARCHAR(100);
  DECLARE _$OUTKEY    VARCHAR(100);
  DECLARE _$INKEY     VARCHAR(100);
  DECLARE _$LOTKEY    VARCHAR(100);
  DECLARE _$MOVEQTY   DECIMAL(20, 8);
  DECLARE _$LOTQTY    DECIMAL(20, 8);
  DECLARE _$INQTY     DECIMAL(20, 8);
  DECLARE _$ITEMID    VARCHAR(100);
  DECLARE _$PRCCD     VARCHAR(100);
  DECLARE _$MOVETIME  VARCHAR(19);
  DECLARE _$CNT       INT DEFAULT 0;

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  IF IFNULL($MOVEDATE, '') = '' THEN
    CALL COMERR('이동일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($OUTWARE, '') = '' OR IFNULL($INWARE, '') = '' THEN
    CALL COMERR('출고창고와 입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $OUTWARE = $INWARE THEN
    CALL COMERR('출고창고와 입고창고가 같습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($LOTKEY_LIST, '') = '' THEN
    CALL COMERR('이동할 LOT 를 스캔하세요.');
    LEAVE PROC;
  END IF;

  SET _$GROUPKEY = GETKEY('GETGROUPKEY');
  SET _$MOVETIME = CONCAT(LEFT($MOVEDATE, 10), ' ', RIGHT(GETTIME(), 8));

  WHILE LENGTH($LOTKEY_LIST) > 0 DO
    CALL COMSPLIT($LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT($MOVEQTY_LIST, _$MOVEQTY);

    IF IFNULL(_$LOTKEY, '') <> '' THEN

      SET _$LOTQTY = NULL;
      SELECT COMLOT.LOTQTY, COMLOT.ITEMID, COMLOT.PRCCD
        INTO _$LOTQTY, _$ITEMID, _$PRCCD
        FROM COMLOT
        WHERE COMLOT.LOTKEY = _$LOTKEY
          AND COMLOT.WARECD = $OUTWARE;

      IF _$LOTQTY IS NULL THEN
        CALL COMERR(CONCAT('출고창고에 없는 LOT 입니다.'
                          , '\n- 창고: ', IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = $OUTWARE), $OUTWARE)
                          , '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      IF IFNULL(_$MOVEQTY, 0) <= 0 THEN
        CALL COMERR(CONCAT('이동량을 입력하세요.', '\n- 로트번호: ', _$LOTKEY));
        LEAVE PROC;
      END IF;

      IF _$MOVEQTY > _$LOTQTY THEN
        CALL COMERR(CONCAT('이동량이 재고량보다 많습니다.'
                          , '\n- 로트번호: ', _$LOTKEY
                          , '\n- 재고량: ', FORMAT(_$LOTQTY, 0)
                          , '\n- 이동량: ', FORMAT(_$MOVEQTY, 0)));
        LEAVE PROC;
      END IF;

      SET _$OUTKEY = GETKEY('OUTKEY');
      SET _$INKEY  = GETKEY('INKEY');

      -- 1. 출고 : 출고창고 LOT 차감
      INSERT INTO COMOUT (OUTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, ITEMID, PRCCD, EMPCD, GROUPKEY, RTIME, REMP, RPRG)
      VALUES (_$OUTKEY, $OUTWARE, $OUTTP, LEFT($MOVEDATE, 10), _$MOVEQTY, _$ITEMID, _$PRCCD, CALLEMP(), _$GROUPKEY, CALLTIME(), CALLEMP(), CALLPRG());

      INSERT INTO COMOUTLOT (OUTKEY, LOTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, PRCCD, ITEMID, OLDQTY, RTIME, REMP, RPRG)
      VALUES (_$OUTKEY, _$LOTKEY, $OUTWARE, $OUTTP, LEFT($MOVEDATE, 10), _$MOVEQTY, _$PRCCD, _$ITEMID, _$LOTQTY, CALLTIME(), CALLEMP(), CALLPRG());

      UPDATE COMLOT
         SET COMLOT.LOTQTY = COMLOT.LOTQTY - _$MOVEQTY
           , COMLOT.MTIME  = CALLTIME()
           , COMLOT.MEMP   = CALLEMP()
           , COMLOT.MPRG   = CALLPRG()
       WHERE COMLOT.LOTKEY = _$LOTKEY
         AND COMLOT.WARECD = $OUTWARE;

      -- 2. 입고 : 입고창고에 같은 LOT 번호로 더함 (없으면 출고 LOT 정보를 복사해 새로 만듦)
      SET _$INQTY = IFNULL((SELECT COMLOT.LOTQTY FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = $INWARE), 0);

      INSERT INTO COMIN (INKEY, WARECD, INTP, INDATE, INQTY, ITEMID, PRCCD, EMPCD, GROUPKEY, RTIME, REMP, RPRG)
      VALUES (_$INKEY, $INWARE, $INTP, LEFT($MOVEDATE, 10), _$MOVEQTY, _$ITEMID, _$PRCCD, CALLEMP(), _$GROUPKEY, CALLTIME(), CALLEMP(), CALLPRG());

      INSERT INTO COMINLOT (INKEY, LOTKEY, WARECD, INTP, INDATE, INQTY, PRCCD, ITEMID, OLDQTY, RTIME, REMP, RPRG)
      VALUES (_$INKEY, _$LOTKEY, $INWARE, $INTP, LEFT($MOVEDATE, 10), _$MOVEQTY, _$PRCCD, _$ITEMID, _$INQTY, CALLTIME(), CALLEMP(), CALLPRG());

      IF EXISTS (SELECT 1 FROM COMLOT WHERE COMLOT.LOTKEY = _$LOTKEY AND COMLOT.WARECD = $INWARE) THEN
        UPDATE COMLOT
           SET COMLOT.LOTQTY = COMLOT.LOTQTY + _$MOVEQTY
             , COMLOT.CRTQTY = COMLOT.CRTQTY + _$MOVEQTY   -- 이 창고로 들어온 양 (LOTQTY <> CRTQTY 를 '사용됨' 으로 보는 곳이 있어 같이 늘림)
             , COMLOT.MTIME  = CALLTIME()
             , COMLOT.MEMP   = CALLEMP()
             , COMLOT.MPRG   = CALLPRG()
         WHERE COMLOT.LOTKEY = _$LOTKEY
           AND COMLOT.WARECD = $INWARE;
      ELSE
        -- 실적·입고 키(MTRINKEY·PRDRSTKEY·OSCRSTKEY·SALOUTKEY)는 원래 LOT 에만 두고 복사하지 않음 (실적·입고 취소 판단이 꼬이지 않게)
        INSERT INTO COMLOT (
            LOTKEY, WARECD, LABELCD, LOTQTY, HEATNO, ITEMID, PRCCD, CRTTIME, CRTQTY, PRDDATE, CUSTCD, CUSTLOTKEY, LOTTP, GROUPKEY
          , RTIME, REMP, RPRG)
        SELECT
            COMLOT.LOTKEY, $INWARE, COMLOT.LABELCD, _$MOVEQTY, COMLOT.HEATNO, COMLOT.ITEMID, COMLOT.PRCCD, _$MOVETIME, _$MOVEQTY
          , COMLOT.PRDDATE, COMLOT.CUSTCD, COMLOT.CUSTLOTKEY, COMLOT.LOTTP, _$GROUPKEY
          , CALLTIME(), CALLEMP(), CALLPRG()
        FROM COMLOT
        WHERE COMLOT.LOTKEY = _$LOTKEY
          AND COMLOT.WARECD = $OUTWARE;
      END IF;

      SET _$CNT = _$CNT + 1;
    END IF;
  END WHILE;

  SET @MOVEGROUPKEY = _$GROUPKEY;   -- 호출한 화면이 ERP 인터페이스(WORK_xx) 를 보낼 때 쓰는 이동 GROUPKEY

  SELECT _$GROUPKEY AS GROUPKEY, _$CNT AS LOTCNT;

-- ****************************************************************************
END IF; END