CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_SALOUT_OSC(
-- *****************************************************************************
-- Comment: 외주처 판매출고 출고확정 프로시저 (출고구분 31: 판매출고(유상사급 소재))
-- Create: 2026-10-26 17:02:      TML5000_R02 MAKE_SALOUT 에서 분리
-- Modify:
-- *****************************************************************************
  IN $SALOUTKEY  VARCHAR(20),     -- 출하번호 (미확정 OUTYN = 'N')
  IN $OUTTIME    VARCHAR(19)      -- 출고일자
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$WARECD   VARCHAR(100);
  DECLARE _$OUTKEY   VARCHAR(20);
  DECLARE _$OUTTP    VARCHAR(100);
  DECLARE _$OUTQTY   DECIMAL(20, 8);
  DECLARE _$ZEROCNT  INT;
  DECLARE _$WARECNT  INT;
-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************
-- <외주처 판매출고 확정 순서>
-- 1. 입력값·출하 확인
-- 2. 스캔 LOT 확인 (확정 시점 재고 0, 출고창고와 다른 창고)
-- 3. 출하 LOT 수량을 확정 시점 재고 수량으로 맞춤
-- 4. COMOUTLOT / COMOUT 생성
-- 5. COMLOT 재고 차감
-- 6. SALOUT 출고확정 (OUTYN = 'Y')
-- ****************************************************************************

  -- 1. 입력값·출하 확인
  IF $SALOUTKEY = '' THEN
    CALL COMERR('출하번호가 없습니다. (IO_SALOUT_OSC)');
    LEAVE PROC;
  END IF;

  IF $OUTTIME = '' THEN
    CALL COMERR('출고일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY) THEN
    CALL COMERR('존재하지 않는 출하입니다. (IO_SALOUT_OSC)');
    LEAVE PROC;
  END IF;

  IF (SELECT SALOUT.OUTYN FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY) = 'Y' THEN
    CALL COMERR('이미 출고확정된 출하입니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM SALOUTLOT WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY) THEN
    CALL COMERR('스캔한 재고가 없습니다.');
    LEAVE PROC;
  END IF;

  SET _$WARECD = (SELECT SALOUT.WARECD FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY);

  -- 2. 스캔 LOT 확인 (확정 시점 재고/창고)
  SET _$ZEROCNT = (SELECT IFNULL(SUM(COMLOT.LOTQTY <= 0), 0)
                   FROM SALOUTLOT
                   INNER JOIN COMLOT
                     ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
                   WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY);

  SET _$WARECNT = (SELECT IFNULL(SUM(COMLOT.WARECD <> _$WARECD), 0)
                   FROM SALOUTLOT
                   INNER JOIN COMLOT
                     ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
                   WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY);

  IF _$ZEROCNT > 0 THEN
    CALL COMERR('스캔한 로트중 재고 수량이 0인 재고가 포함되어 있습니다.');
    LEAVE PROC;
  END IF;

  IF _$WARECNT > 0 THEN
    CALL COMERR('스캔한 로트중 현재고 창고가 출고창고와 다른 재고가 있습니다.');
    LEAVE PROC;
  END IF;

  -- 3. 확정 시점 재고 수량으로 출하 수량 맞춤
  UPDATE SALOUTLOT
  INNER JOIN COMLOT
    ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
  SET SALOUTLOT.LOTQTY = COMLOT.LOTQTY
    , SALOUTLOT.MTIME = CALLTIME()
    , SALOUTLOT.MEMP = CALLEMP()
    , SALOUTLOT.MPRG = CALLPRG()
  WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
  ;

  SET _$OUTQTY = (SELECT IFNULL(SUM(SALOUTLOT.LOTQTY), 0) FROM SALOUTLOT WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY);

  -- 4. 재고 출고 이력 (COMOUTLOT / COMOUT)
  SET _$OUTKEY = GETKEY('COMOUT');
  SET _$OUTTP = '31';  -- 판매출고 (유상사급 소재)

  INSERT INTO COMOUTLOT (
      OUTKEY, LOTKEY, WARECD, OUTTP
    , OUTDATE, OUTQTY, PRCCD, ITEMID
    , OLDQTY
    , RTIME, REMP, RPRG)
  SELECT
      _$OUTKEY, SALOUTLOT.LOTKEY, _$WARECD, _$OUTTP
    , $OUTTIME, SALOUTLOT.LOTQTY, COMLOT.PRCCD, COMLOT.ITEMID
    , COMLOT.LOTQTY
    , CALLTIME(), CALLEMP(), CALLPRG()
  FROM SALOUTLOT
  INNER JOIN COMLOT
    ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
  WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
  ;

  INSERT INTO COMOUT (
      OUTKEY, WARECD, OUTTP, OUTDATE
    , OUTQTY, ITEMID, PRCCD, EMPCD
    , SALOUTKEY
    , RTIME, REMP, RPRG)
  SELECT
      _$OUTKEY, _$WARECD, _$OUTTP, $OUTTIME
    , IFNULL(SUM(SALOUTLOT.LOTQTY), 0), COMLOT.ITEMID, COMLOT.PRCCD, CALLEMP()
    , $SALOUTKEY
    , CALLTIME(), CALLEMP(), CALLPRG()
  FROM SALOUTLOT
  INNER JOIN COMLOT
    ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
  WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
  ;

  -- 5. 재고 차감
  UPDATE SALOUTLOT
  INNER JOIN COMLOT
    ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
  SET COMLOT.LOTQTY = COMLOT.LOTQTY - SALOUTLOT.LOTQTY
    , COMLOT.MTIME = CALLTIME()
    , COMLOT.MEMP = CALLEMP()
    , COMLOT.MPRG = CALLPRG()
  WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
  ;

  -- 6. 출고확정
  UPDATE SALOUT
  SET OUTYN = 'Y'
    , OUTQTY = _$OUTQTY
    , SALOUTDATE = $OUTTIME
    , OUTTIME = $OUTTIME
    , MTIME = CALLTIME()
    , MEMP = CALLEMP()
    , MPRG = CALLPRG()
  WHERE SALOUT.SALOUTKEY = $SALOUTKEY
  ;

-- ****************************************************************************
END IF; END
