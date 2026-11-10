CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`TAL0001_R09`(
-- *****************************************************************************
-- Comment: 설비부품 출고등록 (태블릿)
-- Create: 	2026-11-10  	생성 			한성수	TML1010_R05(현장터미널 설비부품 입출고)의 재고조회·출고등록·출고 이력·라벨출력을 태블릿 전용으로 생성 (입고 제외)
-- *****************************************************************************
  IN $SDATE           VARCHAR(10),
  IN $EDATE           VARCHAR(10),
  IN $ITEMID          VARCHAR(100),
  IN $OUTDATE         VARCHAR(10),
  IN $OUTTP           VARCHAR(100),
  IN $OUTQTY          DECIMAL(20, 8),
  IN $EMPCD           VARCHAR(100),

-- *****************************************************************************
  IN $CALLTYPE        VARCHAR(50),
  IN $KEYWORD         VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$OLDQTY      DECIMAL(20, 8);

  CASE $CALLTYPE
  -- *****************************************************************************

  WHEN 'LIST_EQMPARTS' THEN -- INC 2공장 설비부품 재고 조회

    SELECT MSTITEM.ITEMID, MSTITEM.ITEMCD, MSTITEM.ITEMNM, MSTITEM.ITEMUNIT,
           COALESCE(MSTITEM_EQMPARTS.GRADE, MSTITEM.GRADE, '') AS GRADE,
           COALESCE(MSTLOCA_EQMPARTS.LOCANM, MSTITEM_EQMPARTS.LOCACD, '') AS LOCANM,
           COALESCE(MSTITEM_EQMPARTS.SAFEQTY, 0) AS SAFEQTY, COALESCE(MSTITEM_EQMPARTS.LOTQTY, 0) AS LOTQTY,
           -- 현재고가 안전재고보다 적으면 행 배경 분홍색
           CASE WHEN COALESCE(MSTITEM_EQMPARTS.LOTQTY, 0) < COALESCE(MSTITEM_EQMPARTS.SAFEQTY, 0) THEN 'PINK' ELSE '' END AS BACKGROUND
    FROM MSTITEM
    INNER JOIN MSTITEM_EQMPARTS
      ON MSTITEM_EQMPARTS.ITEMID = MSTITEM.ITEMID
     AND MSTITEM_EQMPARTS.FACTORYCD = '07'
    LEFT JOIN MSTLOCA_EQMPARTS
      ON MSTLOCA_EQMPARTS.LOCACD = MSTITEM_EQMPARTS.LOCACD
    WHERE MSTITEM.COMPANYCD = '60'
      AND MSTITEM.ITEMCG = 'DM100700'
      AND MSTITEM.ENDYN = 'N'
    ORDER BY MSTITEM.ITEMCD, MSTITEM.ITEMID;

  -- *****************************************************************************

  WHEN 'OUT_EQMPARTS' THEN -- 설비부품 출고등록

    IF COALESCE($ITEMID, '') = '' THEN
      CALL COMERR('부품을 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF COALESCE($OUTDATE, '') = '' THEN
      CALL COMERR('출고일자를 입력해주세요.');
      LEAVE PROC;
    END IF;

    IF COALESCE($OUTTP, '') = '' THEN
      CALL COMERR('출고구분을 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF COALESCE($OUTQTY, 0) <= 0 THEN
      CALL COMERR('출고수량을 0보다 크게 입력해주세요.');
      LEAVE PROC;
    END IF;

    IF COALESCE($EMPCD, '') = '' THEN
      CALL COMERR('출고자를 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 출고 전 현재고 (입출고 이력 OLDQTY)
    SET _$OLDQTY = COALESCE((SELECT LOTQTY FROM MSTITEM_EQMPARTS WHERE ITEMID = $ITEMID AND FACTORYCD = '07' LIMIT 1 FOR UPDATE), 0);

    IF _$OLDQTY < $OUTQTY THEN
      CALL COMERR(CONCAT('출고수량이 현재고(', FORMAT(_$OLDQTY, 0), ')를 초과할 수 없습니다.'));
      LEAVE PROC;
    END IF;

    INSERT INTO INOUT_EQMPARTS (
      INOUTKEY, INOROUT, INOUTDATE, INOUTTP_EQMPARTS, INOUTQTY, OLDQTY,
      ITEMID, EMPCD, REMARK, RTIME, REMP, RPRG
    ) VALUES (
      GETKEY('INOUTKEY'), 'OUT', $OUTDATE, $OUTTP, $OUTQTY, _$OLDQTY,
      $ITEMID, $EMPCD, '', CALLTIME(), CALLEMP(), CALLPRG()
    );

    UPDATE MSTITEM_EQMPARTS
    SET LOTQTY = LOTQTY - $OUTQTY,
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE ITEMID = $ITEMID
      AND FACTORYCD = '07';

  -- *****************************************************************************

  WHEN 'LIST_OUT_EQMPARTS' THEN -- 설비부품 출고 이력 조회

    SELECT INOUTDATE, INOUTTP_EQMPARTS AS OUTTP, INOUTQTY AS OUTQTY, EMPCD
    FROM INOUT_EQMPARTS
    WHERE ITEMID = $ITEMID
      AND INOROUT = 'OUT'
      AND INOUTDATE BETWEEN $SDATE AND $EDATE
    ORDER BY RTIME;

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
