CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_SALOUT_LOT(
-- *****************************************************************************
-- Comment: 출하 출고확정 (SALOUTLOT 에 적힌 LOT 별 출하량만큼 출고창고 재고 차감) - TML5000_R01 출하등록
--          IO_SALOUT_OSC 와 달리 LOT 를 현재고 전량으로 맞추지 않음 (출하량 수정 가능), 재고는 LOT + 출고창고로 찾음
--          출고구분 : 출하(SALOUT.SALOUTTP)를 따름 (01 고객사 판매출고 / 011 유상사급 판매출고)
-- Create: 2026-11-10
-- Modify: 2026-11-11 ERP 인터페이스(SALOUTLOT) 송신 추가
--         2026-11-19 출고구분을 01 고정에서 출하의 SALOUTTP 로 (유상사급 창고 출하는 011)
-- *****************************************************************************
  IN $SALOUTKEY  VARCHAR(20),     -- 출하번호 (미확정 OUTYN = 'N')
  IN $OUTDATE    VARCHAR(10)      -- 출하일자
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$WARECD   VARCHAR(100);
  DECLARE _$OUTKEY   VARCHAR(20);
  DECLARE _$OUTTP    VARCHAR(10);
  DECLARE _$OUTQTY   DECIMAL(20, 8);
-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  IF IFNULL($SALOUTKEY, '') = '' THEN
    CALL COMERR('출하번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($OUTDATE, '') = '' THEN
    CALL COMERR('출하일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY AND SALOUT.OUTYN = 'N') THEN
    CALL COMERR('출고확정할 출하가 없습니다.');
    LEAVE PROC;
  END IF;

  SET _$WARECD = (SELECT SALOUT.WARECD FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY);
  SET _$OUTTP = IFNULL(NULLIF((SELECT SALOUT.SALOUTTP FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY), ''), '01');

  -- 출하량이 출고창고 재고보다 많은 LOT
  IF EXISTS (SELECT 1
               FROM SALOUTLOT
               LEFT JOIN COMLOT ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
                               AND COMLOT.WARECD = _$WARECD
               WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
                 AND (COMLOT.LOTKEY IS NULL OR SALOUTLOT.LOTQTY > COMLOT.LOTQTY OR SALOUTLOT.LOTQTY <= 0)) THEN
    CALL COMERR(CONCAT('출하량이 출고창고 재고보다 많거나 0 인 LOT 가 있습니다.'
                      , '\n- 로트번호: ', (SELECT SALOUTLOT.LOTKEY
                                            FROM SALOUTLOT
                                            LEFT JOIN COMLOT ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
                                                            AND COMLOT.WARECD = _$WARECD
                                            WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
                                              AND (COMLOT.LOTKEY IS NULL OR SALOUTLOT.LOTQTY > COMLOT.LOTQTY OR SALOUTLOT.LOTQTY <= 0)
                                            LIMIT 1)));
    LEAVE PROC;
  END IF;

  SET _$OUTQTY = (SELECT IFNULL(SUM(SALOUTLOT.LOTQTY), 0) FROM SALOUTLOT WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY);
  SET _$OUTKEY = GETKEY('OUTKEY');

  -- 출고 이력 (LOT 별 COMOUTLOT, 출하 1건 COMOUT)
  INSERT INTO COMOUTLOT (OUTKEY, LOTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, PRCCD, ITEMID, OLDQTY, REMARK, RTIME, REMP, RPRG)
  SELECT _$OUTKEY, SALOUTLOT.LOTKEY, _$WARECD, _$OUTTP, $OUTDATE, SALOUTLOT.LOTQTY, COMLOT.PRCCD, COMLOT.ITEMID, COMLOT.LOTQTY, IFNULL(SALOUTLOT.REMARK, '')
       , CALLTIME(), CALLEMP(), CALLPRG()
  FROM SALOUTLOT
  INNER JOIN COMLOT ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY
                   AND COMLOT.WARECD = _$WARECD
  WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY;

  INSERT INTO COMOUT (OUTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, ITEMID, PRCCD, EMPCD, SALOUTKEY, RTIME, REMP, RPRG)
  SELECT _$OUTKEY, _$WARECD, _$OUTTP, $OUTDATE, _$OUTQTY, SALOUT.ITEMID
       , IFNULL((SELECT MAX(COMLOT.PRCCD)   -- 공정 : 출하 LOT 재고의 공정
                   FROM SALOUTLOT
                   INNER JOIN COMLOT ON COMLOT.LOTKEY = SALOUTLOT.LOTKEY AND COMLOT.WARECD = _$WARECD
                   WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY), '')
       , CALLEMP(), $SALOUTKEY, CALLTIME(), CALLEMP(), CALLPRG()
  FROM SALOUT
  WHERE SALOUT.SALOUTKEY = $SALOUTKEY;

  -- 재고 차감 (출고창고의 그 LOT 만)
  UPDATE COMLOT
  INNER JOIN SALOUTLOT ON SALOUTLOT.LOTKEY = COMLOT.LOTKEY
     SET COMLOT.LOTQTY = COMLOT.LOTQTY - SALOUTLOT.LOTQTY
       , COMLOT.MTIME  = CALLTIME()
       , COMLOT.MEMP   = CALLEMP()
       , COMLOT.MPRG   = CALLPRG()
   WHERE SALOUTLOT.SALOUTKEY = $SALOUTKEY
     AND COMLOT.WARECD = _$WARECD;

  -- 출고확정
  UPDATE SALOUT
     SET SALOUT.OUTYN      = 'Y'
       , SALOUT.OUTQTY     = _$OUTQTY
       , SALOUT.SALOUTDATE = $OUTDATE
       , SALOUT.OUTTIME    = CONCAT($OUTDATE, ' ', RIGHT(GETTIME(), 8))
       , SALOUT.MTIME      = CALLTIME()
       , SALOUT.MEMP       = CALLEMP()
       , SALOUT.MPRG       = CALLPRG()
   WHERE SALOUT.SALOUTKEY = $SALOUTKEY;

  -- ERP 인터페이스 (출하LOT : I)
  CALL IO_ERP_INTERFACE('SALOUTLOT', $SALOUTKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

-- ****************************************************************************
END IF; END
