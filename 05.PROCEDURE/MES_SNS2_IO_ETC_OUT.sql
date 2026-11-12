CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_ETC_OUT(
-- *****************************************************************************
-- Comment: 기타 출고 프로시저
-- Create: 2026-09-04: 김영철
-- Modify: 2026-11-11: ERP 인터페이스(ETC_OUT) 송신 추가
-- ***************************************************************************** 
 IN $ITEMID         VARCHAR(50),
 IN $OUTDATE         VARCHAR(10),
 IN $OUTTP           VARCHAR(20),
 IN $EMPCD          VARCHAR(20),
 IN $REMARK         VARCHAR(100),

 IN $LOTKEYLIST     MEDIUMTEXT,
 IN $OUTQTYLIST      MEDIUMTEXT
 
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************

 DECLARE _$LOTKEY   VARCHAR(100);
 DECLARE _$OUTQTY    VARCHAR(100);
 DECLARE _$OUTKEY    VARCHAR(100);
 DECLARE _$WARECD    VARCHAR(20);

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************
-- <기타출고 이력생성 순서 > 
-- 1. 기타출고 이력
-- 1_1. 출고수량 입력여부 확인
-- 1_2. COMOUTLOT 생성
-- 1_3. COMOUT 생성
-- 1_4. COMLOT 업데이트
-- ****************************************************************************
  IF $ITEMID = '' THEN
    CALL COMERR('품목ID가 없습니다. (IO_OUT_ETC)');
    LEAVE PROC;
  END IF;

  IF $OUTDATE = '' THEN
    CALL COMERR('출고일자가 없습니다. (IO_OUT_ETC)');
    LEAVE PROC;
  END IF;

  IF $OUTTP = '' THEN
    CALL COMERR('출고구분이 없습니다. (IO_OUT_ETC)');
    LEAVE PROC;
  END IF;

  IF $EMPCD = '' THEN
    CALL COMERR('사원이 없습니다. (IO_OUT_ETC)');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT EMPCD FROM MSTEMP WHERE EMPCD =  $EMPCD) THEN
    CALL COMERR('존재하지 않는 사원입니다. (IO_OUT_ETC)');
    LEAVE PROC;
  END IF;

  IF $REMARK = '' THEN
    CALL COMERR('사유가 없습니다. (IO_OUT_ETC)');
    LEAVE PROC;
  END IF;

  IF $LOTKEYLIST = '' THEN
    CALL COMERR('로트리스트가 없습니다. (IO_OUT_ETC)');
    LEAVE PROC;
  END IF;

  IF $OUTQTYLIST = '' THEN
    CALL COMERR('출고수량 리스트가 없습니다. (IO_OUT_ETC)');
    LEAVE PROC;
  END IF;

--   SET _$SUMOUTQTY = 0;

  WHILE LENGTH($LOTKEYLIST) > 0 DO

    CALL COMSPLIT($LOTKEYLIST, _$LOTKEY);
    CALL COMSPLIT($OUTQTYLIST, _$OUTQTY);

    SELECT WARECD INTO _$WARECD 
      FROM COMLOT 
      WHERE LOTKEY = _$LOTKEY;

    SET _$OUTKEY = GETKEY('OUTKEY'); 

-- ----------------------------------------------------------------------------------------------------------------------------------------
    -- 1_1. 출고수량 여부 확인
    IF _$OUTQTY <= 0 THEN
      CALL COMERR('출고수량을 확인바랍니다. (IO_OUT_ETC)');
      LEAVE PROC;
    END IF; 
-- ----------------------------------------------------------------------------------------------------------------------------------------
-- 1_2. COMOUTLOT 테이블에 출고정보가 INSERT
    INSERT INTO COMOUTLOT
      (OUTKEY, LOTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, ITEMID,  RTIME, REMP, RPRG)
      VALUES
      (_$OUTKEY, _$LOTKEY, _$WARECD, $OUTTP, $OUTDATE, _$OUTQTY, $ITEMID, CALLTIME(), CALLEMP(), CALLPRG());
-- ----------------------------------------------------------------------------------------------------------------------------------------
-- 1_3. COMOUT 테이블 출고정보 UPDATE
    INSERT INTO COMOUT
      (OUTKEY, WARECD, OUTTP, OUTDATE, 
       OUTQTY, ITEMID, EMPCD, REMARK, 
       RTIME, REMP, RPRG)
      VALUES
      (_$OUTKEY, _$WARECD, $OUTTP, $OUTDATE, 
       _$OUTQTY, $ITEMID, $EMPCD, $REMARK, 
       CALLTIME(), CALLEMP(), CALLPRG());
  
-- ----------------------------------------------------------------------------------------------------------------------------------------
  -- 1_4. COMLOT 테이블 출고정보 UPDATE
      UPDATE COMLOT
        SET LOTQTY = LOTQTY - _$OUTQTY,
            CRTTIME = GETTIME(),
            CRTQTY = LOTQTY,
            REMARK = $REMARK,
            MTIME = CALLTIME(),
            MEMP = CALLEMP(),
            MPRG = CALLPRG()
      WHERE LOTKEY = _$LOTKEY
        AND ITEMID = $ITEMID
        AND WARECD = _$WARECD;

-- ----------------------------------------------------------------------------------------------------------------------------------------
  -- 1_5. ERP 인터페이스 (기타출고 : I, LOT 별 출고번호 OUTKEY)
      CALL IO_ERP_INTERFACE('ETC_OUT', _$OUTKEY, 'I');

      IF IFNULL(@ERRMSG, '') <> '' THEN
        LEAVE PROC;
      END IF;

    END WHILE;

-- ****************************************************************************
END IF; END