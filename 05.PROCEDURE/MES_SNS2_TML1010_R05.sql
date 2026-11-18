CREATE DEFINER=`root`@`%` 
PROCEDURE `MES_SNS2`.`TML1010_R05`(
-- *****************************************************************************
-- Comment: 현장터미널 설비부품 출고등록
-- Create:  2025-10-27  생성          신정수
-- Modify:  2026-10-16                한성수  발주 조회 중복 조인 제거, 재고조회 미등록 품목 필터링 및 쿼리 최적화
--          2026-10-19                한성수  INC 2공장(07) 고정, 파라미터 15건 최적화, ENDYN 표준화, 라벨 반환데이터 통일
--          2026-11-17                한성수  설비부품 출고등록 전용 전환 (입고 기능 TML1010_R08 분리 및 미사용 파라미터 제거)
--          2026-11-18                한성수  출고 이력 출고취소 추가 (이력 삭제 및 재고 복원), 출고 라인·설비 저장 및 라인별 설비 목록 추가, 출고 이력 라인·설비 표시, 설비부품 로케이션 지정·해제 추가, 재고 조회 중요도등급·로케이션 조건 추가, 출고 이력 설비부품코드 표시, 불필요 JOIN·NULL 처리·중복 조회 정리
-- *****************************************************************************
  IN $SDATE       VARCHAR(10),
  IN $EDATE       VARCHAR(10),
  IN $ITEMID      VARCHAR(100),
  IN $OUTDATE     VARCHAR(10),
  IN $OUTTP       VARCHAR(100),
  IN $OUTQTY      DECIMAL(20, 8),
  IN $EMPCD       VARCHAR(100),
  IN $EQMGROUP1   VARCHAR(100),
  IN $EQMCD       VARCHAR(100),
  IN $INOUTKEY    VARCHAR(100),
  IN $LOCACD      VARCHAR(100),
  IN $GRADE       VARCHAR(100),
-- *****************************************************************************
  IN $CALLTYPE    VARCHAR(50)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$OLDQTY DECIMAL(20, 8);
  DECLARE _$ITEMID VARCHAR(100);
  DECLARE _$ITEMCD VARCHAR(100);
  DECLARE _$OUTQTY DECIMAL(20, 8);

-- *****************************************************************************
  SET $SDATE  = IFNULL($SDATE, '');
  SET $EDATE  = IFNULL($EDATE, '');
  SET $GRADE  = IFNULL($GRADE, '');
  SET $LOCACD = IFNULL($LOCACD, '');

  -- 부품 선택 확인
  IF $CALLTYPE IN ('OUT_EQMPARTS', 'LIST_OUT_EQMPARTS', 'LABEL_REPRINT', 'SET_LOCA', 'CLEAR_LOCA') THEN
    IF IFNULL($ITEMID, '') = '' THEN
      CALL COMERR('부품을 선택해주세요.');
      LEAVE PROC;
    END IF;
  END IF;

  -- 출고자 입력 확인
  IF $CALLTYPE = 'OUT_EQMPARTS' THEN
    IF IFNULL(TRIM($EMPCD), '') = '' THEN
      CALL COMERR('출고자를 선택해주세요.');
      LEAVE PROC;
    END IF;
  END IF;

  CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_EQMPARTS' THEN -- INC 2공장 설비부품 재고 조회

    SELECT CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID,
           MSTITEM.ITEMCD, MSTITEM.ITEMNM, MSTITEM.ITEMUNIT,
           MSTITEM_EQMPARTS.GRADE, MSTITEM_EQMPARTS.LOCACD,
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

  WHEN 'LIST_EQMCD' THEN -- 출고 팝업 라인별 설비 목록

    SELECT CONCAT(MSTEQM.FANO, '  ', MSTEQM.EQMNM) AS Label, MSTEQM.FANO AS Value
    FROM MSTEQM
    WHERE MSTEQM.FACTORYCD = '07'
      AND MSTEQM.USEYN = 'Y'
      AND MSTEQM.EQMGROUP1 = $EQMGROUP1
    ORDER BY MSTEQM.FANO;

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

    IF _$OLDQTY < $OUTQTY THEN
      CALL COMERR('현재고가 부족합니다.');
      LEAVE PROC;
    END IF;

    -- 입출고 이력 등록
    INSERT INTO INOUT_EQMPARTS (
        INOUTKEY, INOROUT, INOUTDATE, INOUTTP_EQMPARTS, INOUTQTY, OLDQTY,
        ITEMID, EMPCD, EQMGROUP1, EQMCD, REMARK,
        RTIME, REMP, RPRG
    ) VALUES (
        GETKEY('INOUTKEY'), 'OUT', $OUTDATE, $OUTTP, $OUTQTY, _$OLDQTY,
        $ITEMID, $EMPCD, IFNULL($EQMGROUP1, ''), IFNULL($EQMCD, ''), '',
        CALLTIME(), CALLEMP(), CALLPRG()
    );

    -- 설비부품 재고 차감
    UPDATE MSTITEM_EQMPARTS
    SET LOTQTY = LOTQTY - $OUTQTY,
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE ITEMID = $ITEMID
      AND FACTORYCD = '07';

-- *****************************************************************************

  WHEN 'LIST_OUT_EQMPARTS' THEN -- 설비부품 출고 이력 조회

    -- 선택 부품 하나의 이력이므로 설비부품코드는 한 번만 조회
    SET _$ITEMCD = (SELECT ITEMCD FROM MSTITEM WHERE ITEMID = $ITEMID LIMIT 1);

    SELECT INOUT_EQMPARTS.INOUTKEY, INOUT_EQMPARTS.INOUTDATE,
           GPCD('INOUTTP_EQMPARTS', INOUT_EQMPARTS.INOUTTP_EQMPARTS) AS INOUTTPNM,
           GPCD('FM113', INOUT_EQMPARTS.EQMGROUP1) AS EQMGROUP1NM,
           IF(INOUT_EQMPARTS.EQMCD = '', '', CONCAT(INOUT_EQMPARTS.EQMCD, '  ', IFNULL(MSTEQM.EQMNM, ''))) AS EQMNM,
           _$ITEMCD AS ITEMCD,
           CAST(INOUT_EQMPARTS.INOUTQTY AS DOUBLE) AS OUTQTY,
           GPCD('EMPCD', INOUT_EQMPARTS.EMPCD) AS EMPNM
    FROM INOUT_EQMPARTS
    LEFT JOIN MSTEQM
      ON MSTEQM.FANO = INOUT_EQMPARTS.EQMCD
    WHERE INOUT_EQMPARTS.ITEMID = $ITEMID
      AND INOUT_EQMPARTS.INOROUT = 'OUT'
      AND ($SDATE = '' OR INOUT_EQMPARTS.INOUTDATE >= $SDATE)
      AND ($EDATE = '' OR INOUT_EQMPARTS.INOUTDATE <= $EDATE)
    ORDER BY INOUT_EQMPARTS.RTIME ASC;

-- *****************************************************************************

  WHEN 'CANCEL_OUT_EQMPARTS' THEN -- 설비부품 출고취소

    -- 취소할 출고 이력 취득 (집계라 이력이 없어도 한 행이 나와 NULL로 받음)
    SELECT MAX(ITEMID), MAX(INOUTQTY)
      INTO _$ITEMID, _$OUTQTY
    FROM INOUT_EQMPARTS
    WHERE INOUTKEY = $INOUTKEY
      AND INOROUT = 'OUT'
    FOR UPDATE;

    IF _$ITEMID IS NULL THEN
      CALL COMERR('취소할 출고 이력이 없습니다.');
      LEAVE PROC;
    END IF;

    -- 출고 이력 삭제
    DELETE FROM INOUT_EQMPARTS
    WHERE INOUTKEY = $INOUTKEY;

    -- 설비부품 재고 복원
    UPDATE MSTITEM_EQMPARTS
    SET LOTQTY = LOTQTY + _$OUTQTY,
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE ITEMID = _$ITEMID
      AND FACTORYCD = '07';

-- *****************************************************************************

  WHEN 'LIST_LOCA' THEN -- 설비부품 로케이션 기준정보 목록

    SELECT CONCAT(MSTLOCA_EQMPARTS.LOCACD, '  ', IFNULL(MSTLOCA_EQMPARTS.LOCANM, '')) AS Label,
           MSTLOCA_EQMPARTS.LOCACD AS Value,
           IFNULL(MSTLOCA_EQMPARTS.LOCANM, MSTLOCA_EQMPARTS.LOCACD) AS LOCANM
    FROM MSTLOCA_EQMPARTS
    ORDER BY MSTLOCA_EQMPARTS.LOCACD;

-- *****************************************************************************

  WHEN 'SET_LOCA' THEN -- 설비부품 로케이션 지정

    IF NOT EXISTS (SELECT 1 FROM MSTLOCA_EQMPARTS WHERE LOCACD = $LOCACD LIMIT 1) THEN
      CALL COMERR('로케이션을 선택해주세요.');
      LEAVE PROC;
    END IF;

    UPDATE MSTITEM_EQMPARTS
    SET LOCACD = $LOCACD,
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE ITEMID = $ITEMID
      AND FACTORYCD = '07';

-- *****************************************************************************

  WHEN 'CLEAR_LOCA' THEN -- 설비부품 로케이션 해제

    UPDATE MSTITEM_EQMPARTS
    SET LOCACD = '',
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE ITEMID = $ITEMID
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
