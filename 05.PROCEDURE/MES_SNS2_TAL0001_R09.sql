CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`TAL0001_R09`(
-- *****************************************************************************
-- Comment: 설비부품 출고등록 (태블릿)
-- Create: 	2026-11-10  	생성 			한성수	TML1010_R05(현장터미널 설비부품 입출고)의 재고조회·출고등록·출고 이력·라벨출력을 태블릿 전용으로 생성 (입고 제외)
-- Modify:  2026-11-20                한성수  TML1010_R05와 같은 워크플로우로 변경 (재고 조회 중요도등급·로케이션 조건, 출고 라인·설비 저장, 출고 이력 라인·설비·설비부품코드 표시, 출고취소(이력 삭제 및 재고 복원), 로케이션 지정·해제 추가, 출고 이력 기간 미입력 허용, 화면 확인 대신 프로시저에서 지정 로케이션 없음 확인)
--          2026-11-23                한성수  불필요 코드 정리 (출고자 확인을 출고 분기로 이동, 품목ID 문자 변환 제거)
-- *****************************************************************************
  IN $SDATE           VARCHAR(10),
  IN $EDATE           VARCHAR(10),
  IN $ITEMID          VARCHAR(100),
  IN $OUTDATE         VARCHAR(10),
  IN $OUTTP           VARCHAR(100),
  IN $OUTQTY          DECIMAL(20, 8),
  IN $EMPCD           VARCHAR(100),
  IN $EQMGROUP1       VARCHAR(100),
  IN $EQMCD           VARCHAR(100),
  IN $INOUTKEY        VARCHAR(100),
  IN $LOCACD          VARCHAR(100),
  IN $GRADE           VARCHAR(100),

-- *****************************************************************************
  IN $CALLTYPE        VARCHAR(50),
  IN $KEYWORD         VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$OLDQTY      DECIMAL(20, 8);
  DECLARE _$ITEMID      VARCHAR(100);
  DECLARE _$ITEMCD      VARCHAR(100);
  DECLARE _$OUTQTY      DECIMAL(20, 8);

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

  CASE $CALLTYPE
  -- *****************************************************************************

  WHEN 'LIST_EQMPARTS' THEN -- INC 2공장 설비부품 재고 조회

    SELECT MSTITEM.ITEMID,
           MSTITEM.ITEMCD, MSTITEM.ITEMNM, MSTITEM.ITEMUNIT,
           MSTITEM_EQMPARTS.GRADE, MSTITEM_EQMPARTS.LOCACD,
           IFNULL(MSTLOCA_EQMPARTS.LOCANM, MSTITEM_EQMPARTS.LOCACD) AS LOCANM,
           CAST(MSTITEM_EQMPARTS.SAFEQTY AS DOUBLE) AS SAFEQTY,
           CAST(MSTITEM_EQMPARTS.LOTQTY AS DOUBLE) AS LOTQTY,
           -- 현재고가 안전재고보다 적으면 행 배경 분홍색
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

  WHEN 'OUT_EQMPARTS' THEN -- 설비부품 출고등록

    IF IFNULL(TRIM($EMPCD), '') = '' THEN
      CALL COMERR('출고자를 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL($OUTDATE, '') = '' THEN
      CALL COMERR('출고일자를 입력해주세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL($OUTQTY, 0) <= 0 THEN
      CALL COMERR('출고수량을 0보다 크게 입력해주세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL($OUTTP, '') = '' THEN
      CALL COMERR('출고구분을 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 출고 전 현재고 (입출고 이력 OLDQTY)
    SET _$OLDQTY = IFNULL((SELECT LOTQTY FROM MSTITEM_EQMPARTS WHERE ITEMID = $ITEMID AND FACTORYCD = '07' LIMIT 1 FOR UPDATE), 0);

    IF _$OLDQTY < $OUTQTY THEN
      CALL COMERR(CONCAT('출고수량이 현재고(', FORMAT(_$OLDQTY, 0), ')를 초과할 수 없습니다.'));
      LEAVE PROC;
    END IF;

    -- 출고 이력 등록
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

    IF IFNULL((SELECT LOCACD FROM MSTITEM_EQMPARTS WHERE ITEMID = $ITEMID AND FACTORYCD = '07' LIMIT 1), '') = '' THEN
      CALL COMERR('지정된 로케이션이 없습니다.');
      LEAVE PROC;
    END IF;

    UPDATE MSTITEM_EQMPARTS
    SET LOCACD = '',
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE ITEMID = $ITEMID
      AND FACTORYCD = '07';

  -- *****************************************************************************

  WHEN 'GET_LABELCD' THEN -- 설비부품 라벨 양식

    SELECT 'EQMPARTS' AS LABELCD;

  -- *****************************************************************************

  WHEN 'LABEL_REPRINT' THEN -- 선택 부품 라벨 출력 데이터

    SELECT ITEMNM, ITEMCD, ITEMID
    FROM MSTITEM
    WHERE ITEMID = $ITEMID;

  -- *****************************************************************************

  END CASE;
END
