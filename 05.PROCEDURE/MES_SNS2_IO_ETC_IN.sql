CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_ETC_IN(
-- *****************************************************************************
-- Comment: 기타 입고 프로시저
-- Create: 2026-09-04: 김영철
-- Modify: 2026-11-10: 입고창고($WARECD) 파라미터 추가 (지정 시 신규/기존 로트 모두 해당 창고로 입고)
-- *****************************************************************************
  IN $INDATE      VARCHAR(10),
  IN $INTP        VARCHAR(20),
  IN $EMPCD       VARCHAR(20),
  IN $REMARK      VARCHAR(100),
  IN $LOTKEYLIST  MEDIUMTEXT,
  IN $INQTYLIST   MEDIUMTEXT,
  IN $ITEMID_LIST MEDIUMTEXT,
  IN $WARECD      VARCHAR(100)   -- 입고창고 (빈값이면 기존 로트는 로트의 창고, 신규 로트는 품목유형별 기본창고)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC

  DECLARE _$LOTKEY    VARCHAR(100) DEFAULT '';
  DECLARE _$INQTY     VARCHAR(100) DEFAULT '';
  DECLARE _$INQTY_N   DECIMAL(18,4) DEFAULT 0;
  DECLARE _$INKEY     VARCHAR(100) DEFAULT '';
  DECLARE _$LABELCD   VARCHAR(100) DEFAULT '';
  DECLARE _$ITEMTP    VARCHAR(100) DEFAULT '';
  DECLARE _$ITEMID    VARCHAR(100) DEFAULT '';
  DECLARE _$WARECD    VARCHAR(100) DEFAULT '';
  DECLARE _$LOT_ITEM  VARCHAR(100) DEFAULT '';
  DECLARE _$PRCCD  VARCHAR(100) DEFAULT '';

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************
-- <기타입고 이력생성 순서>
-- 1_1. 입력값 검증
-- 1_2. COMINLOT 생성
-- 1_3. COMIN 생성
-- 1_4. COMLOT 생성/수량가산
-- ****************************************************************************

  IF IFNULL($INDATE, '') = '' THEN
    CALL COMERR('입고일자가 없습니다. (IO_ETC_IN)');
    LEAVE PROC;
  END IF;

  IF IFNULL($INTP, '') = '' THEN
    CALL COMERR('입고구분이 없습니다. (IO_ETC_IN)');
    LEAVE PROC;
  END IF;

  IF IFNULL($EMPCD, '') = '' THEN
    CALL COMERR('사원이 없습니다. (IO_ETC_IN)');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MSTEMP WHERE EMPCD = $EMPCD) THEN
    CALL COMERR('존재하지 않는 사원입니다. (IO_ETC_IN)');
    LEAVE PROC;
  END IF;

  IF IFNULL($REMARK, '') = '' THEN
    CALL COMERR('사유가 없습니다. (IO_ETC_IN)');
    LEAVE PROC;
  END IF;

  IF IFNULL($ITEMID_LIST, '') = '' THEN
    CALL COMERR('품목ID 리스트가 없습니다. (IO_ETC_IN)');
    LEAVE PROC;
  END IF;

  IF IFNULL($INQTYLIST, '') = '' THEN
    CALL COMERR('입고수량 리스트가 없습니다. (IO_ETC_IN)');
    LEAVE PROC;
  END IF;

  IF IFNULL($WARECD, '') <> '' AND NOT EXISTS (SELECT 1 FROM MSTWARE WHERE WARECD = $WARECD) THEN
    CALL COMERR(CONCAT('존재하지 않는 창고입니다. [', $WARECD, '] (IO_ETC_IN)'));
    LEAVE PROC;
  END IF;

  -- 품목 리스트 기준으로 루프 (신규로트는 LOTKEYLIST가 비어있을 수 있음)
  WHILE LENGTH($ITEMID_LIST) > 0 DO

    CALL COMSPLIT($LOTKEYLIST,  _$LOTKEY);
    CALL COMSPLIT($INQTYLIST,   _$INQTY);
    CALL COMSPLIT($ITEMID_LIST, _$ITEMID);

    SET _$LOTKEY = IFNULL(_$LOTKEY, '');
    SET _$INQTY  = IFNULL(_$INQTY, '');
    SET _$ITEMID = IFNULL(_$ITEMID, '');
    SET _$WARECD = '';
    SET _$LABELCD = '';
    SET _$ITEMTP = '';
    SET _$LOT_ITEM = '';

    IF _$ITEMID = '' THEN
      CALL COMERR('품목ID가 없습니다. (IO_ETC_IN)');
      LEAVE PROC;
    END IF;

    SET _$INQTY_N = CAST(_$INQTY AS DECIMAL(18,4));
    IF _$INQTY_N <= 0 THEN
      CALL COMERR('입고수량을 확인바랍니다. (IO_ETC_IN)');
      LEAVE PROC;
    END IF;

    SET _$ITEMTP = IFNULL((SELECT ITEMCG FROM MSTITEM WHERE ITEMID = _$ITEMID), '');

    IF _$ITEMTP = '' THEN
      CALL COMERR('품목유형이 없습니다. (IO_ETC_IN)');
      LEAVE PROC;
    END IF;

    -- 라벨코드: GETLOTKEY 채번용 (창고코드와 별개)
    -- ※ 원자재 유형코드가 DM100100으로 중복 기입되어 있었음. 실제 코드 확인 필요.
    CASE _$ITEMTP
      WHEN 'DM100100' THEN 
        SET _$LABELCD = 'PRD01';  -- 제품
      WHEN 'DM100150' THEN 
        SET _$LABELCD = 'PRD01';       -- 반제품
      ELSE                 
        SET _$LABELCD = 'MTR01';  -- 원자재 등
    END CASE;

    -- ----------------------------------------------------------------
    -- 창고 결정
    -- 입고창고($WARECD) 지정 시: 신규/기존 로트 모두 해당 창고
    --   ) 기존 로트가 다른 창고에만 있으면 해당 창고에 같은 로트번호로 새로 생성 (COMLOT PK = LOTKEY + WARECD)
    -- 미지정 시: 기존 로트는 로트의 창고, 신규 로트는 품목유형별 기본창고
    -- ----------------------------------------------------------------
    SET _$WARECD = $WARECD;

        
    IF _$LOTKEY <> '' THEN
      IF EXISTS (SELECT 1 FROM COMLOT WHERE LOTKEY = _$LOTKEY AND WARECD = _$WARECD) THEN
        SELECT ITEMID
          INTO _$LOT_ITEM
        FROM COMLOT
        WHERE LOTKEY = _$LOTKEY
          AND WARECD = _$WARECD
        ORDER BY CRTTIME DESC
        LIMIT 1;  
  
        IF IFNULL(_$LOT_ITEM, '') <> '' AND _$LOT_ITEM <> _$ITEMID THEN
          CALL COMERR(CONCAT('로트번호의 품목이 일치하지 않습니다. [', _$LOTKEY, '] (IO_ETC_IN)'));
          LEAVE PROC;
        END IF;
      END IF;
    END IF;


    -- 신규 로트 채번
    IF _$LOTKEY = '' THEN
      IF _$LABELCD = '' THEN
        CALL COMERR(CONCAT('로트 채번용 라벨코드가 없습니다. 품목유형=', _$ITEMTP, ' (IO_ETC_IN)'));
        LEAVE PROC;
      END IF;

      IF EXISTS (SELECT 
                   MSTROUT_MATCH.ROUTCD
                 FROM MSTROUT_MATCH
                 INNER JOIN MSTROUT
                   ON MSTROUT.ROUTCD = MSTROUT_MATCH.ROUTCD
                  AND MSTROUT.USEYN = 'Y'
                 WHERE MSTROUT_MATCH.ITEMID = _$ITEMID) THEN
        SET _$PRCCD = IFNULL((
                                SELECT 
                                  MSTROUT_DETAIL.PRCCD
                                FROM MSTROUT_MATCH
                                INNER JOIN MSTROUT
                                 ON MSTROUT.ROUTCD = MSTROUT_MATCH.ROUTCD
                                AND MSTROUT.USEYN = 'Y'
                                INNER JOIN MSTROUT_DETAIL
                                  ON MSTROUT_DETAIL.ROUTCD = MSTROUT.ROUTCD                                                                      
                                WHERE MSTROUT_MATCH.ITEMID = _$ITEMID
                                LIMIT 1
                             ), '');

        SET _$LOTKEY = GETLOTKEY_PRD($INDATE, _$PRCCD, 'D');
      ELSE
        SET _$LOTKEY = GETLOTKEY_DLV($INDATE);
      END IF;
      
    END IF;

    SET _$INKEY = GETKEY('INKEY');

    -- 1_2. COMINLOT 생성
    INSERT INTO COMINLOT (
      INKEY, LOTKEY, WARECD, INTP, INDATE, INQTY, ITEMID,
      RTIME, REMP, RPRG
    ) VALUES (
      _$INKEY, _$LOTKEY, _$WARECD, $INTP, $INDATE, _$INQTY_N, _$ITEMID,
      CALLTIME(), CALLEMP(), CALLPRG()
    );

    -- 1_3. COMIN 생성
    INSERT INTO COMIN (
      INKEY, WARECD, INTP, INDATE,
      INQTY, ITEMID, EMPCD, REMARK,
      RTIME, REMP, RPRG
    ) VALUES (
      _$INKEY, _$WARECD, $INTP, $INDATE,
      _$INQTY_N, _$ITEMID, $EMPCD, $REMARK,
      CALLTIME(), CALLEMP(), CALLPRG()
    );

    -- 1_4. COMLOT 생성 / 수량 가산
    IF EXISTS (
      SELECT 1 FROM COMLOT
      WHERE WARECD = _$WARECD
        AND LOTKEY = _$LOTKEY
    ) THEN
      UPDATE COMLOT
         SET LOTQTY    = LOTQTY + _$INQTY_N
           , MTIME     = CALLTIME()
           , MEMP      = CALLEMP()
           , MPRG      = CALLPRG()
       WHERE WARECD = _$WARECD
         AND LOTKEY = _$LOTKEY;
    ELSE
      INSERT INTO COMLOT (
        LOTKEY, WARECD, LABELCD, LOTQTY,
        ITEMID, CRTTIME, CRTQTY, PRDDATE,
        REMARK, RTIME, REMP, RPRG
      ) VALUES (
        _$LOTKEY, _$WARECD, _$LABELCD, _$INQTY_N,
        _$ITEMID, GETTIME(), _$INQTY_N, $INDATE,
        $REMARK, CALLTIME(), CALLEMP(), CALLPRG()
      );
    END IF;

  END WHILE;

-- ****************************************************************************
END IF;
END