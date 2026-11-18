CREATE DEFINER=`root`@`%` 
PROCEDURE `MES_SNS2`.`TML1010_R08`(
-- *****************************************************************************
-- Comment: 현장터미널 설비부품 입고등록
-- Create:  2026-11-17  생성          한성수  TML1010_R05 설비부품 입출고에서 입고등록·입고이력·라벨출력 분리
-- Modify:  2026-11-18                한성수  재고 조회 중요도등급·로케이션 조건 추가, 입고 이력 입고취소 추가 (이력 삭제, 재고 차감), 입고 시 로케이션 덮어쓰기 제거, 불필요 NULL 처리·중복 조회 정리, 발주 잔량을 MES 입고 이력 합계로 계산하고 발주 입고수량·진행상태 변경 제거 (ERP 인터페이스 덮어쓰기 대응), 입고 가능 발주 상태를 진행 중 상태(발주·발주확정·발주승인)로 변경, 발주 공장 조건을 발주공장에서 입고공장(INC 2공장) 기준으로 변경
-- *****************************************************************************
  IN $SDATE       VARCHAR(10),
  IN $EDATE       VARCHAR(10),
  IN $ITEMID      VARCHAR(100),
  IN $CUSTCD      VARCHAR(100),
  IN $INDATE      VARCHAR(10),
  IN $INTP        VARCHAR(100),
  IN $INQTY       DECIMAL(20, 8),
  IN $LOCACD      VARCHAR(100),
  IN $MTRODRKEY   VARCHAR(100),
  IN $MTRODRSEQ   VARCHAR(100),
  IN $EMPCD       VARCHAR(100),
  IN $GRADE       VARCHAR(100),
  IN $INOUTKEY    VARCHAR(100),
-- *****************************************************************************
  IN $CALLTYPE    VARCHAR(50)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$OLDQTY    DECIMAL(20, 8);
  DECLARE _$REMAINQTY DECIMAL(20, 8);
  DECLARE _$ITEMID    VARCHAR(100);
  DECLARE _$CANQTY    DECIMAL(20, 8);

-- *****************************************************************************
  SET $SDATE  = IFNULL($SDATE, '');
  SET $EDATE  = IFNULL($EDATE, '');
  SET $CUSTCD = IFNULL($CUSTCD, '');
  SET $GRADE  = IFNULL($GRADE, '');
  SET $LOCACD = IFNULL($LOCACD, '');

  -- 부품 선택 확인
  IF $CALLTYPE IN ('LIST_ODR_EQMPARTS', 'IN_EQMPARTS', 'LIST_IN_EQMPARTS', 'LABEL_REPRINT') THEN
    IF IFNULL($ITEMID, '') = '' THEN
      CALL COMERR('부품을 선택해주세요.');
      LEAVE PROC;
    END IF;
  END IF;

  -- 입고자 입력 확인
  IF $CALLTYPE = 'IN_EQMPARTS' THEN
    IF IFNULL(TRIM($EMPCD), '') = '' THEN
      CALL COMERR('입고자를 선택해주세요.');
      LEAVE PROC;
    END IF;
  END IF;

  CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_EQMPARTS' THEN -- INC 2공장 설비부품 재고 조회

    SELECT CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID,
           MSTITEM.ITEMCD, MSTITEM.ITEMNM, MSTITEM.ITEMSPEC, MSTITEM.ITEMUNIT,
           MSTITEM_EQMPARTS.GRADE,
           IFNULL(MSTLOCA_EQMPARTS.LOCANM, MSTITEM_EQMPARTS.LOCACD) AS LOCANM,
           CAST(MSTITEM_EQMPARTS.SAFEQTY AS DOUBLE) AS SAFEQTY,
           CAST(MSTITEM_EQMPARTS.LOTQTY AS DOUBLE) AS LOTQTY,
           IF(MSTITEM_EQMPARTS.LOTQTY < MSTITEM_EQMPARTS.SAFEQTY, 'PINK', '') AS BACKGROUND
    FROM MSTITEM
    INNER JOIN MSTITEM_EQMPARTS
      ON MSTITEM_EQMPARTS.ITEMID = MSTITEM.ITEMID
     AND MSTITEM_EQMPARTS.FACTORYCD = '07'
    LEFT JOIN MSTLOCA_EQMPARTS
      ON MSTLOCA_EQMPARTS.LOCACD = MSTITEM_EQMPARTS.LOCACD
    WHERE MSTITEM.COMPANYCD = '60'
      AND MSTITEM.ITEMCG = 'DM100700'
      AND MSTITEM.ENDYN = 'N'
      AND ($GRADE = '' OR MSTITEM_EQMPARTS.GRADE = $GRADE)
      AND ($LOCACD = '' OR MSTITEM_EQMPARTS.LOCACD = $LOCACD)
    ORDER BY MSTITEM.ITEMCD, MSTITEM.ITEMID;

-- *****************************************************************************

  WHEN 'LIST_GRADE' THEN -- 조회 조건 중요도등급 목록

    SELECT DISTINCT MSTITEM_EQMPARTS.GRADE AS Label, MSTITEM_EQMPARTS.GRADE AS Value
    FROM MSTITEM
    INNER JOIN MSTITEM_EQMPARTS
      ON MSTITEM_EQMPARTS.ITEMID = MSTITEM.ITEMID
     AND MSTITEM_EQMPARTS.FACTORYCD = '07'
    WHERE MSTITEM.COMPANYCD = '60'
      AND MSTITEM.ITEMCG = 'DM100700'
      AND MSTITEM.ENDYN = 'N'
      AND MSTITEM_EQMPARTS.GRADE <> ''
    ORDER BY Value;

-- *****************************************************************************

  WHEN 'LIST_LOCA' THEN -- 조회 조건 로케이션 목록

    SELECT IFNULL(MSTLOCA_EQMPARTS.LOCANM, MSTLOCA_EQMPARTS.LOCACD) AS Label,
           MSTLOCA_EQMPARTS.LOCACD AS Value
    FROM MSTLOCA_EQMPARTS
    ORDER BY MSTLOCA_EQMPARTS.LOCACD;

-- *****************************************************************************

  WHEN 'LIST_ODR_EQMPARTS' THEN -- 선택 부품 입고 가능 발주 목록 (입고량은 MES 입고 이력 합계)

    SELECT MTRODRD.MTRODRKEY, MTRODRD.MTRODRSEQ, MTRODR.MTRODRDATE,
           IFNULL(MSTCUST.CUSTNM, MTRODR.CUSTCD) AS CUSTNM,
           CAST(IFNULL(MTRODRD.ODRQTY, 0) AS DOUBLE) AS ODRQTY,
           CAST(IFNULL(INSUM.INQTY, 0) AS DOUBLE) AS PREV_INQTY,
           CAST(IFNULL(MTRODRD.ODRQTY, 0) - IFNULL(INSUM.INQTY, 0) AS DOUBLE) AS REMAINQTY
    FROM MTRODRD
    INNER JOIN MTRODR
      ON MTRODR.MTRODRKEY = MTRODRD.MTRODRKEY
    LEFT JOIN MSTCUST
      ON MSTCUST.CUSTCD = MTRODR.CUSTCD
    LEFT JOIN (SELECT MTRODRKEY, MTRODRSEQ, SUM(INOUTQTY) AS INQTY
               FROM INOUT_EQMPARTS
               WHERE ITEMID = $ITEMID
                 AND INOROUT = 'IN'
                 AND MTRODRKEY <> ''
               GROUP BY MTRODRKEY, MTRODRSEQ) INSUM
      ON INSUM.MTRODRKEY = MTRODRD.MTRODRKEY
     AND INSUM.MTRODRSEQ = MTRODRD.MTRODRSEQ
    WHERE MTRODRD.ITEMID = $ITEMID
      AND MTRODR.INFACTORYCD = '07'
      AND ($SDATE = '' OR MTRODR.MTRODRDATE >= $SDATE)
      AND ($EDATE = '' OR MTRODR.MTRODRDATE <= $EDATE)
      AND ($CUSTCD = '' OR MTRODR.CUSTCD = $CUSTCD)
      AND MTRODRD.MTRODRSTT IN ('MM110100', 'MM110200', 'MM110201')
      AND IFNULL(MTRODRD.ODRQTY, 0) > IFNULL(INSUM.INQTY, 0)
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

    -- 선택 발주의 잔여수량 확인 (발주량 - MES 입고 이력 합계, 발주 행 잠금으로 동시 입고 순차 처리)
    SET _$REMAINQTY = (SELECT IFNULL(MTRODRD.ODRQTY, 0)
                       FROM MTRODRD
                       INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRODRD.MTRODRKEY
                       WHERE MTRODRD.MTRODRKEY = $MTRODRKEY
                         AND MTRODRD.MTRODRSEQ = $MTRODRSEQ
                         AND MTRODRD.ITEMID = $ITEMID
                         AND MTRODR.INFACTORYCD = '07'
                         AND MTRODRD.MTRODRSTT IN ('MM110100', 'MM110200', 'MM110201') FOR UPDATE)
                    - IFNULL((SELECT SUM(INOUTQTY)
                              FROM INOUT_EQMPARTS
                              WHERE MTRODRKEY = $MTRODRKEY
                                AND MTRODRSEQ = $MTRODRSEQ
                                AND INOROUT = 'IN'), 0);
    IF _$REMAINQTY IS NULL OR $INQTY > _$REMAINQTY THEN
      CALL COMERR('선택한 발주의 잔여수량을 확인해주세요.');
      LEAVE PROC;
    END IF;

    -- 기존 재고량 취득 (재고 목록은 2공장 재고가 있는 부품만 보이므로 없으면 오류)
    SET _$OLDQTY = (SELECT LOTQTY FROM MSTITEM_EQMPARTS WHERE ITEMID = $ITEMID AND FACTORYCD = '07' LIMIT 1 FOR UPDATE);

    IF _$OLDQTY IS NULL THEN
      CALL COMERR('INC 2공장 설비부품 재고 정보가 없습니다.');
      LEAVE PROC;
    END IF;

    -- 입고 이력 등록
    INSERT INTO INOUT_EQMPARTS (
        INOUTKEY, INOROUT, INOUTDATE, INOUTTP_EQMPARTS, INOUTQTY, OLDQTY,
        ITEMID, EMPCD, MTRODRKEY, MTRODRSEQ, REMARK,
        RTIME, REMP, RPRG
    ) VALUES (
        GETKEY('INOUTKEY'), 'IN', $INDATE, $INTP, $INQTY, _$OLDQTY,
        $ITEMID, $EMPCD, $MTRODRKEY, $MTRODRSEQ, '',
        CALLTIME(), CALLEMP(), CALLPRG()
    );

    -- 설비부품 재고 증가
    UPDATE MSTITEM_EQMPARTS
    SET LOTQTY = LOTQTY + $INQTY,
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE ITEMID = $ITEMID
      AND FACTORYCD = '07';

    -- 입고 등록 라벨 출력 데이터 반환
    SELECT 'EQMPARTS' AS LABELCD;

    SELECT MSTITEM.ITEMNM, MSTITEM.ITEMCD, MSTITEM.ITEMID
    FROM MSTITEM
    WHERE MSTITEM.ITEMID = $ITEMID;

-- *****************************************************************************

  WHEN 'LIST_IN_EQMPARTS' THEN -- 설비부품 입고 이력 조회

    SELECT INOUT_EQMPARTS.INOUTKEY, INOUT_EQMPARTS.INOUTDATE,
           GPCD('INOUTTP_EQMPARTS', INOUT_EQMPARTS.INOUTTP_EQMPARTS) AS INOUTTPNM,
           CAST(INOUT_EQMPARTS.INOUTQTY AS DOUBLE) AS INQTY,
           GPCD('EMPCD', INOUT_EQMPARTS.EMPCD) AS EMPNM
    FROM INOUT_EQMPARTS
    WHERE INOUT_EQMPARTS.ITEMID = $ITEMID
      AND INOUT_EQMPARTS.INOROUT = 'IN'
      AND ($SDATE = '' OR INOUT_EQMPARTS.INOUTDATE >= $SDATE)
      AND ($EDATE = '' OR INOUT_EQMPARTS.INOUTDATE <= $EDATE)
    ORDER BY INOUT_EQMPARTS.RTIME ASC;

-- *****************************************************************************

  WHEN 'CANCEL_IN_EQMPARTS' THEN -- 설비부품 입고취소

    -- 취소할 입고 이력 취득 (집계라 이력이 없어도 한 행이 나와 NULL로 받음)
    SELECT MAX(ITEMID), MAX(INOUTQTY)
      INTO _$ITEMID, _$CANQTY
    FROM INOUT_EQMPARTS
    WHERE INOUTKEY = $INOUTKEY
      AND INOROUT = 'IN'
    FOR UPDATE;

    IF _$ITEMID IS NULL THEN
      CALL COMERR('취소할 입고 이력이 없습니다.');
      LEAVE PROC;
    END IF;

    -- 입고 후 출고되어 현재고가 부족하면 취소 불가
    SET _$OLDQTY = IFNULL((SELECT LOTQTY FROM MSTITEM_EQMPARTS WHERE ITEMID = _$ITEMID AND FACTORYCD = '07' LIMIT 1 FOR UPDATE), 0);
    IF _$OLDQTY < _$CANQTY THEN
      CALL COMERR('현재고가 입고수량보다 적어 입고를 취소할 수 없습니다.');
      LEAVE PROC;
    END IF;

    -- 입고 이력 삭제
    DELETE FROM INOUT_EQMPARTS
    WHERE INOUTKEY = $INOUTKEY;

    -- 설비부품 재고 차감
    UPDATE MSTITEM_EQMPARTS
    SET LOTQTY = LOTQTY - _$CANQTY,
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE ITEMID = _$ITEMID
      AND FACTORYCD = '07';

-- *****************************************************************************

  WHEN 'LABEL_REPRINT' THEN -- 선택 부품 라벨 재발행

    SELECT 'EQMPARTS' AS LABELCD;

    SELECT MSTITEM.ITEMNM, MSTITEM.ITEMCD, MSTITEM.ITEMID
    FROM MSTITEM
    WHERE MSTITEM.ITEMID = $ITEMID;

-- *****************************************************************************

  END CASE;

END
