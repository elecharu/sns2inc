CREATE DEFINER=`root`@`%` 
PROCEDURE `MES_SNS2`.`TML1010_R05`(
-- *****************************************************************************
-- Comment: 현장터미널 설비부품 입출고 재고관리
-- Create:  2025-10-27  신정수
-- Modify:  2026-10-16  한성수  발주 조회 중복 조인 제거, 재고조회 미등록 품목 필터링 및 쿼리 최적화
--          2026-10-19  한성수  INC 2공장(07) 고정, 파라미터 15건 최적화, ENDYN 표준화, 라벨 반환데이터(ITEMNM/ITEMCD/ITEMID) 통일
-- *****************************************************************************
  IN $SDATE       VARCHAR(10),
  IN $EDATE       VARCHAR(10),
  IN $ITEMID      VARCHAR(100),
  IN $CUSTCD      VARCHAR(100),
  IN $INDATE      VARCHAR(10),  
  IN $INTP        VARCHAR(100),
  IN $INQTY       DECIMAL(20, 8),
  IN $OUTDATE     VARCHAR(10),  
  IN $OUTTP       VARCHAR(100),
  IN $OUTQTY      DECIMAL(20, 8),
  IN $LOCACD      VARCHAR(100),
  IN $MTRODRKEY   VARCHAR(100),
  IN $MTRODRSEQ   VARCHAR(100),
  IN $EMPCD       VARCHAR(100),
-- *****************************************************************************
  IN $CALLTYPE    VARCHAR(50)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$OLDQTY    DECIMAL(20, 8);
  DECLARE _$REMAINQTY DECIMAL(20, 8);

-- *****************************************************************************
  SET $SDATE   = IFNULL($SDATE, '');
  SET $EDATE   = IFNULL($EDATE, '');
  SET $CUSTCD  = IFNULL($CUSTCD, '');

  -- 부품 선택 확인
  IF $CALLTYPE IN ('LIST_ODR_EQMPARTS', 'IN_EQMPARTS', 'OUT_EQMPARTS', 'LIST_INOUT_EQMPARTS', 'LABEL_REPRINT') THEN
    IF IFNULL($ITEMID, '') = '' THEN
      CALL COMERR('부품을 선택해주세요.');
      LEAVE PROC;
    END IF;
  END IF;

  -- 입출고자 입력 확인
  IF $CALLTYPE IN ('IN_EQMPARTS', 'OUT_EQMPARTS') THEN
    IF IFNULL(TRIM($EMPCD), '') = '' THEN
      CALL COMERR(CASE WHEN $CALLTYPE = 'IN_EQMPARTS' THEN '입고자를 선택해주세요.' ELSE '출고자를 선택해주세요.' END);
      LEAVE PROC;
    END IF;
  END IF;

  CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_EQMPARTS' THEN -- INC 2공장 설비부품 재고 조회
    
    SELECT CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID,
           MSTITEM.ITEMCD,
           MSTITEM.ITEMNM,
           MSTITEM.ITEMSPEC,
           IFNULL(MSTITEM_EQMPARTS.GRADE, IFNULL(MSTITEM.GRADE, '')) AS GRADE,
           IFNULL(MSTLOCA_EQMPARTS.LOCANM, IFNULL(MSTITEM_EQMPARTS.LOCACD, '')) AS LOCANM,
           IFNULL(MSTITEM_EQMPARTS.LOCACD, '') AS LOCACD,
           CAST(IFNULL(MSTITEM_EQMPARTS.SAFEQTY, 0) AS DOUBLE) AS SAFEQTY,
           CAST(IFNULL(MSTITEM_EQMPARTS.LOTQTY, 0) AS DOUBLE) AS LOTQTY,
           MSTITEM.ITEMUNIT,
           CASE WHEN IFNULL(MSTITEM_EQMPARTS.LOTQTY, 0) < IFNULL(MSTITEM_EQMPARTS.SAFEQTY, 0)
                THEN 'PINK'
                ELSE ''
           END AS BACKGROUND
    FROM MSTITEM
    LEFT JOIN MSTITEM_EQMPARTS
      ON MSTITEM_EQMPARTS.ITEMID = MSTITEM.ITEMID
     AND MSTITEM_EQMPARTS.FACTORYCD = '07'
    LEFT JOIN MSTLOCA_EQMPARTS
      ON MSTLOCA_EQMPARTS.LOCACD = MSTITEM_EQMPARTS.LOCACD
    WHERE MSTITEM.COMPANYCD = '60'
      AND MSTITEM.ITEMCG = 'DM100700'
      AND MSTITEM.ENDYN = 'N'
      AND MSTITEM_EQMPARTS.ITEMID IS NOT NULL
    ORDER BY MSTITEM.ITEMCD, MSTITEM.ITEMID;

-- *****************************************************************************

  WHEN 'LIST_ODR_EQMPARTS' THEN -- 선택된 설비부품 발주 목록 조회 (입고 팝업용)

    SELECT MTRODRD.MTRODRKEY, MTRODRD.MTRODRSEQ, MTRODR.MTRODRDATE,
           IFNULL(MSTCUST.CUSTNM, MTRODR.CUSTCD) AS CUSTNM,
           CAST(MTRODRD.ODRQTY AS DOUBLE) AS ODRQTY,
           CAST(IFNULL(MTRODRD.INQTY, 0) AS DOUBLE) AS PREV_INQTY,
           CAST(MTRODRD.ODRQTY - IFNULL(MTRODRD.INQTY, 0) AS DOUBLE) AS REMAINQTY
    FROM MTRODRD
    INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRODRD.MTRODRKEY
    LEFT JOIN MSTCUST ON MSTCUST.CUSTCD = MTRODR.CUSTCD
    WHERE MTRODRD.ITEMID = $ITEMID
      AND MTRODR.ODRFACTORY = '07'
      AND ($SDATE = '' OR MTRODR.MTRODRDATE >= $SDATE)
      AND ($EDATE = '' OR MTRODR.MTRODRDATE <= $EDATE)
      AND ($CUSTCD = '' OR MTRODR.CUSTCD = $CUSTCD)
      AND MTRODRD.MTRODRSTT IN ('MM110201', 'MM110300')
      AND MTRODRD.ODRQTY > IFNULL(MTRODRD.INQTY, 0)
    ORDER BY MTRODR.MTRODRDATE DESC, MTRODRD.MTRODRKEY DESC, MTRODRD.MTRODRSEQ;

-- *****************************************************************************

  WHEN 'IN_EQMPARTS' THEN -- 설비부품 입고등록

    IF IFNULL($MTRODRKEY, '') = '' OR IFNULL($MTRODRSEQ, '') = '' THEN
      CALL COMERR('입고할 발주를 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL($INDATE, '') = '' THEN
      CALL COMERR('입고일자를 입력하십시오.');
      LEAVE PROC;
    END IF;

    IF IFNULL($INQTY, 0) <= 0 THEN
      CALL COMERR('입고수량을 0보다 크게 입력하십시오.');
      LEAVE PROC;
    END IF;

    IF IFNULL($INTP, '') = '' THEN
      CALL COMERR('입고구분을 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 선택 발주의 잔여수량 확인
    SET _$REMAINQTY = (SELECT MTRODRD.ODRQTY - IFNULL(MTRODRD.INQTY, 0)
                        FROM MTRODRD
                        INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRODRD.MTRODRKEY
                        WHERE MTRODRD.MTRODRKEY = $MTRODRKEY 
                          AND MTRODRD.MTRODRSEQ = $MTRODRSEQ
                          AND MTRODRD.ITEMID = $ITEMID
                          AND MTRODR.ODRFACTORY = '07'
                          AND MTRODRD.MTRODRSTT IN ('MM110201', 'MM110300') FOR UPDATE);
    IF _$REMAINQTY IS NULL OR $INQTY > _$REMAINQTY THEN
      CALL COMERR('선택한 발주의 잔여수량을 확인해주세요.');
      LEAVE PROC;
    END IF;

    -- 기존 재고량 취득
    SET _$OLDQTY = IFNULL((SELECT LOTQTY FROM MSTITEM_EQMPARTS WHERE ITEMID = $ITEMID AND FACTORYCD = '07' LIMIT 1 FOR UPDATE), 0);

    -- 입출고 이력 등록
    INSERT INTO INOUT_EQMPARTS (
        INOUTKEY, INOROUT, INOUTDATE, INOUTTP_EQMPARTS, INOUTQTY, OLDQTY,
        ITEMID, EMPCD, MTRODRKEY, MTRODRSEQ, REMARK,
        RTIME, REMP, RPRG
    ) VALUES (
        GETKEY('INOUTKEY'), 'IN', $INDATE, $INTP, $INQTY, _$OLDQTY,
        $ITEMID, $EMPCD, $MTRODRKEY, $MTRODRSEQ, '',
        CALLTIME(), CALLEMP(), CALLPRG()
    );

    -- 설비부품 재고 반영 (신규 또는 누적)
    INSERT INTO MSTITEM_EQMPARTS (
        ITEMID, FACTORYCD, LOTQTY, SAFEQTY, LOCACD,
        RTIME, REMP, RPRG
    ) VALUES (
        $ITEMID, '07', $INQTY, 0, IFNULL($LOCACD, ''),
        CALLTIME(), CALLEMP(), CALLPRG()
    )
    ON DUPLICATE KEY UPDATE
        LOTQTY = LOTQTY + $INQTY,
        LOCACD = IF(IFNULL($LOCACD, '') <> '', $LOCACD, LOCACD),
        MTIME = CALLTIME(),
        MEMP = CALLEMP(),
        MPRG = CALLPRG();

    -- 선택 발주의 입고수량과 진행상태 반영
    UPDATE MTRODRD
    SET MTRODRSTT = CASE WHEN IFNULL(INQTY, 0) + $INQTY >= ODRQTY THEN 'MM110500' ELSE 'MM110300' END,
        INQTY = IFNULL(INQTY, 0) + $INQTY,
        MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG()
    WHERE MTRODRKEY = $MTRODRKEY
      AND MTRODRSEQ = $MTRODRSEQ;

    -- 입고 등록 라벨 출력 데이터 반환
    SELECT 'EQMPARTS' AS LABELCD;

    SELECT MSTITEM.ITEMNM, MSTITEM.ITEMCD, MSTITEM.ITEMID
    FROM MSTITEM
    WHERE MSTITEM.ITEMID = $ITEMID;

-- *****************************************************************************

  WHEN 'OUT_EQMPARTS' THEN -- 설비부품 출고등록

    IF IFNULL($OUTDATE, '') = '' THEN
      CALL COMERR('출고일자를 입력하십시오.');
      LEAVE PROC;
    END IF;

    IF IFNULL($OUTQTY, 0) <= 0 THEN
      CALL COMERR('출고수량을 0보다 크게 입력하십시오.');
      LEAVE PROC;
    END IF;

    IF IFNULL($OUTTP, '') = '' THEN
      CALL COMERR('출고구분을 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 기존 재고량 취득
    SET _$OLDQTY = IFNULL((SELECT LOTQTY FROM MSTITEM_EQMPARTS WHERE ITEMID = $ITEMID AND FACTORYCD = '07' LIMIT 1 FOR UPDATE), 0);

    IF (_$OLDQTY - $OUTQTY) < 0 THEN
      CALL COMERR('현재고가 부족합니다.');
      LEAVE PROC;
    END IF;

    -- 입출고 이력 등록
    INSERT INTO INOUT_EQMPARTS (
        INOUTKEY, INOROUT, INOUTDATE, INOUTTP_EQMPARTS, INOUTQTY, OLDQTY,
        ITEMID, EMPCD, REMARK,
        RTIME, REMP, RPRG
    ) VALUES (
        GETKEY('INOUTKEY'), 'OUT', $OUTDATE, $OUTTP, $OUTQTY, _$OLDQTY,
        $ITEMID, $EMPCD, '',
        CALLTIME(), CALLEMP(), CALLPRG()
    );

    -- 설비부품 재고 차감
    UPDATE MSTITEM_EQMPARTS
    SET LOTQTY = LOTQTY - $OUTQTY,
        MTIME = CALLTIME(),
        MEMP = CALLEMP(),
        MPRG = CALLPRG()
    WHERE ITEMID = $ITEMID
      AND FACTORYCD = '07';

-- *****************************************************************************

  WHEN 'LIST_INOUT_EQMPARTS' THEN -- 설비부품 입출고 이력 조회

    SELECT INOUT_EQMPARTS.INOUTDATE,
           CASE INOUT_EQMPARTS.INOROUT WHEN 'IN' THEN '입고' WHEN 'OUT' THEN '출고' END AS INOROUT,
           GPCD('INOUTTP_EQMPARTS', INOUT_EQMPARTS.INOUTTP_EQMPARTS) AS INOUTTPNM,
           CAST(CASE WHEN INOUT_EQMPARTS.INOROUT = 'IN' THEN INOUT_EQMPARTS.INOUTQTY ELSE 0 END AS DOUBLE) AS INQTY,
           CAST(CASE WHEN INOUT_EQMPARTS.INOROUT = 'OUT' THEN INOUT_EQMPARTS.INOUTQTY ELSE 0 END AS DOUBLE) AS OUTQTY,
           GPCD('EMPCD', INOUT_EQMPARTS.EMPCD) AS EMPNM
    FROM INOUT_EQMPARTS
    WHERE INOUT_EQMPARTS.ITEMID = $ITEMID
      AND ($SDATE = '' OR INOUT_EQMPARTS.INOUTDATE >= $SDATE)
      AND ($EDATE = '' OR INOUT_EQMPARTS.INOUTDATE <= $EDATE)
    ORDER BY INOUT_EQMPARTS.RTIME ASC;

-- *****************************************************************************

  WHEN 'LABEL_REPRINT' THEN -- 선택 부품 라벨 재발행

    SELECT 'EQMPARTS' AS LABELCD;

    SELECT MSTITEM.ITEMNM, MSTITEM.ITEMCD, MSTITEM.ITEMID
    FROM MSTITEM
    WHERE MSTITEM.ITEMID = $ITEMID;

-- *****************************************************************************

  END CASE;

END

