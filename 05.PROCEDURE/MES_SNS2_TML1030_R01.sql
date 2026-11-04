CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML1030_R01(
-- *****************************************************************************
-- Comment: 현장터미널 생산팀 소모품 입출고등록 
-- Create:  2026-10-27 17:36 : 김영철
-- Modify:
-- *****************************************************************************
  IN $SDATE       VARCHAR(10),
  IN $EDATE       VARCHAR(10),
  IN $ITEMID      VARCHAR(100),
  IN $CUSTCD      VARCHAR(100),
  IN $INDATE      VARCHAR(10),
  IN $INQTY       DECIMAL(20, 8),
  IN $OUTDATE     VARCHAR(10),
  IN $OUTTP       VARCHAR(100),
  IN $OUTQTY      DECIMAL(20, 8),
  IN $MTRODRKEY   VARCHAR(100),
  IN $MTRODRSEQ   VARCHAR(100),
  IN $EMPCD       VARCHAR(100),
-- *****************************************************************************
  IN $CALLTYPE    VARCHAR(50)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************

  DECLARE _$OLDQTY DECIMAL(20, 8);
  DECLARE _$REMAINQTY DECIMAL(20, 8);
  DECLARE _$INTP VARCHAR(10);

-- *****************************************************************************
  CASE $CALLTYPE
-- *****************************************************************************
  WHEN 'LIST_PRDCONSUM' THEN -- INC 2공장 소모품 재고 조회 (안전재고 등록 품목)

    SELECT 
        MSTITEM.ITEMCD
      , MSTITEM.ITEMNM
      , IFNULL(MSTITEM_PRDCONSUM.SAFEQTY, 0) AS SAFEQTY
      , IFNULL(MSTITEM_PRDCONSUM.LOTQTY, 0) AS LOTQTY
      , MSTITEM.ITEMUNIT
      , MSTITEM.ITEMID AS ITEMID
      , MSTITEM.ITEMSPEC
      , CASE
          WHEN MSTITEM_PRDCONSUM.LOTQTY < MSTITEM_PRDCONSUM.SAFEQTY THEN 'PINK'
          ELSE '' 
        END AS BACKGROUND
      FROM MSTITEM
      INNER JOIN MSTITEM_FACTORY ON MSTITEM.ITEMID = MSTITEM_FACTORY.ITEMID
      LEFT JOIN MSTITEM_PRDCONSUM ON MSTITEM_PRDCONSUM.ITEMID = MSTITEM.ITEMID
      WHERE MSTITEM.COMPANYCD = '60'
        AND MSTITEM.ITEMCG = 'DM100750'
        AND MSTITEM.ENDYN = 'N'
--         AND MSTITEM_FACTORY.FACTORYCD = '07'
      ORDER BY MSTITEM.ITEMCD, MSTITEM.ITEMID;

-- *****************************************************************************
  WHEN 'LIST_ODR_PRDCONSUM' THEN -- 선택 소모품의 2공장 미입고 발주 조회 (입고 팝업)

    SET $ITEMID = IFNULL($ITEMID, '');
    SET $SDATE = IFNULL($SDATE, '');
    SET $EDATE = IFNULL($EDATE, '');
    SET $CUSTCD = IFNULL($CUSTCD, '');

    IF $ITEMID = '' THEN
      CALL COMERR('소모품을 선택해주세요.');
      LEAVE PROC;
    END IF;

    SELECT 
        MTRODR.MTRODRDATE
      , IFNULL(MSTCUST.CUSTNM, MTRODR.CUSTCD) AS CUSTNM
      , MTRODRD.ODRQTY AS ODRQTY
      , IFNULL(INOUT_PRDCONSUM.INQTY, 0) AS PREV_INQTY
      , MTRODRD.ODRQTY - IFNULL(INOUT_PRDCONSUM.INQTY, 0) AS REMAINQTY
      , MTRODRD.MTRODRKEY
      , MTRODRD.MTRODRSEQ
      FROM MTRODRD
      INNER JOIN MTRODR ON MTRODR.MTRODRKEY = MTRODRD.MTRODRKEY
      INNER JOIN MSTCUST ON MSTCUST.CUSTCD = MTRODR.CUSTCD
      -- 발주별 입고량: 소모품 입고이력(INOUT_PRDCONSUM) 의 발주키별 입고수량 합계
      LEFT JOIN (SELECT INOUT_PRDCONSUM.MTRODRKEY, INOUT_PRDCONSUM.MTRODRSEQ, SUM(INOUT_PRDCONSUM.INOUTQTY) AS INQTY
                   FROM INOUT_PRDCONSUM
                   WHERE INOUT_PRDCONSUM.ITEMID = $ITEMID
                     AND INOUT_PRDCONSUM.INOROUT = 'IN'
                   GROUP BY INOUT_PRDCONSUM.MTRODRKEY, INOUT_PRDCONSUM.MTRODRSEQ) AS INOUT_PRDCONSUM
        ON INOUT_PRDCONSUM.MTRODRKEY = MTRODRD.MTRODRKEY
        AND INOUT_PRDCONSUM.MTRODRSEQ = MTRODRD.MTRODRSEQ
      WHERE MTRODRD.ITEMID = $ITEMID
        AND ($SDATE = '' OR MTRODR.MTRODRDATE >= $SDATE)
        AND ($EDATE = '' OR MTRODR.MTRODRDATE <= $EDATE)
        AND ($CUSTCD = '' OR MTRODR.CUSTCD = $CUSTCD)
        AND MTRODRD.MTRODRSTT IN ('MM110201', 'MM110300')
        AND MTRODRD.ODRQTY > IFNULL(INOUT_PRDCONSUM.INQTY, 0)
      ORDER BY MTRODR.MTRODRDATE DESC, MTRODRD.MTRODRKEY DESC, MTRODRD.MTRODRSEQ;

-- *****************************************************************************

  WHEN 'IN_PRDCONSUM' THEN -- 소모품 입고등록 (입고이력에 발주키 매칭)

    SET $ITEMID = TRIM(IFNULL($ITEMID, ''));
    SET $EMPCD = TRIM(IFNULL($EMPCD, ''));
    SET $MTRODRKEY = TRIM(IFNULL($MTRODRKEY, ''));
    SET $MTRODRSEQ = TRIM(IFNULL($MTRODRSEQ, ''));

    IF $ITEMID = '' THEN
      CALL COMERR('소모품을 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF NOT EXISTS (SELECT 1
                     FROM MSTITEM
                     WHERE MSTITEM.ITEMID = $ITEMID
                       AND MSTITEM.ITEMCG = 'DM100750') THEN
      CALL COMERR('소모자재 품목이 아닙니다.');
      LEAVE PROC;
    END IF;

    IF $EMPCD = '' THEN
      CALL COMERR('입고자를 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF $MTRODRKEY = '' OR $MTRODRSEQ = '' THEN
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

    SET _$INTP = 'IN_01';

    -- 선택 발주의 잔여수량 확인 (발주량 - 소모품 입고이력의 그 발주 입고수량 합계)
    SET _$REMAINQTY = (SELECT MTRODRD.ODRQTY - IFNULL((SELECT SUM(INOUT_PRDCONSUM.INOUTQTY)
                                                         FROM INOUT_PRDCONSUM
                                                         WHERE INOUT_PRDCONSUM.MTRODRKEY = MTRODRD.MTRODRKEY
                                                           AND INOUT_PRDCONSUM.MTRODRSEQ = MTRODRD.MTRODRSEQ
                                                           AND INOUT_PRDCONSUM.INOROUT = 'IN'), 0)
                         FROM MTRODRD
                         INNER JOIN MTRODR
                             ON MTRODR.MTRODRKEY = MTRODRD.MTRODRKEY
                         WHERE MTRODRD.MTRODRKEY = $MTRODRKEY
                             AND MTRODRD.MTRODRSEQ = $MTRODRSEQ
                             AND MTRODRD.ITEMID = $ITEMID
                             AND MTRODRD.MTRODRSTT IN ('MM110201', 'MM110300'));

    IF _$REMAINQTY IS NULL OR $INQTY > _$REMAINQTY THEN
      CALL COMERR('선택한 발주의 잔여수량을 확인해주세요.');
      LEAVE PROC;
    END IF;

    -- 기존 재고량
    SET _$OLDQTY = IFNULL((SELECT MSTITEM_PRDCONSUM.LOTQTY
                             FROM MSTITEM_PRDCONSUM
                             WHERE MSTITEM_PRDCONSUM.ITEMID = $ITEMID
                                 AND MSTITEM_PRDCONSUM.FACTORYCD = '07'), 0);

    -- 입출고 이력 등록 (발주키 매칭)
    INSERT INTO INOUT_PRDCONSUM (
      INOUTKEY, INOROUT, INOUTDATE, INOUTTP_PRDCONSUM, INOUTQTY,
      OLDQTY, ITEMID, EMPCD, MTRODRKEY, MTRODRSEQ,
      REMARK, RTIME, REMP, RPRG
    ) VALUES (
      GETKEY('INOUTKEY'), 'IN', $INDATE, _$INTP, $INQTY,
      _$OLDQTY, $ITEMID, $EMPCD, $MTRODRKEY, $MTRODRSEQ,
      '', CALLTIME(), CALLEMP(), CALLPRG()
    );

    -- 소모품 재고 반영 (없으면 등록, 있으면 누적)
    IF EXISTS (SELECT 1
                 FROM MSTITEM_PRDCONSUM
                 WHERE MSTITEM_PRDCONSUM.FACTORYCD = '07'
                   AND MSTITEM_PRDCONSUM.ITEMID = $ITEMID) THEN
      UPDATE MSTITEM_PRDCONSUM
        SET MSTITEM_PRDCONSUM.LOTQTY = MSTITEM_PRDCONSUM.LOTQTY + $INQTY,
            MSTITEM_PRDCONSUM.MTIME = CALLTIME(),
            MSTITEM_PRDCONSUM.MEMP = CALLEMP(),
            MSTITEM_PRDCONSUM.MPRG = CALLPRG()
        WHERE MSTITEM_PRDCONSUM.FACTORYCD = '07'
            AND MSTITEM_PRDCONSUM.ITEMID = $ITEMID;
    ELSE
      INSERT INTO MSTITEM_PRDCONSUM (
        FACTORYCD, ITEMID, SAFEQTY, LOTQTY,
        RTIME, REMP, RPRG
      ) VALUES (
        '07', $ITEMID, 0, $INQTY,
        CALLTIME(), CALLEMP(), CALLPRG()
      );
    END IF;

-- *****************************************************************************
  WHEN 'OUT_PRDCONSUM' THEN -- 소모품 출고등록

    SET $ITEMID = TRIM(IFNULL($ITEMID, ''));
    SET $EMPCD = TRIM(IFNULL($EMPCD, ''));

    IF $ITEMID = '' THEN
      CALL COMERR('소모품을 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF NOT EXISTS (SELECT 1
                     FROM MSTITEM
                     WHERE MSTITEM.ITEMID = $ITEMID
                       AND MSTITEM.COMPANYCD = '60'
                       AND MSTITEM.ITEMCG = 'DM100750') THEN
      CALL COMERR('소모자재 품목이 아닙니다.');
      LEAVE PROC;
    END IF;

    IF $EMPCD = '' THEN
      CALL COMERR('출고자를 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL($OUTDATE, '') = '' THEN
      CALL COMERR('출고일자를 입력하십시오.');
      LEAVE PROC;
    END IF;

    IF IFNULL($OUTQTY, 0) <= 0 THEN
      CALL COMERR('출고수량을 0보다 크게 입력하십시오.');
      LEAVE PROC;
    END IF;

    IF NOT EXISTS (SELECT 1
                     FROM COMTYPE
                     WHERE COMTYPE.GPCD = 'INOUTTP_PRDCONSUM'
                       AND COMTYPE.TPCD = $OUTTP
                       AND COMTYPE.TPCD LIKE 'OUT\_%') THEN
      CALL COMERR('출고구분을 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 기존 재고량
    SET _$OLDQTY = IFNULL((SELECT MSTITEM_PRDCONSUM.LOTQTY
                             FROM MSTITEM_PRDCONSUM
                             WHERE MSTITEM_PRDCONSUM.ITEMID = $ITEMID
                                 AND MSTITEM_PRDCONSUM.FACTORYCD = '07'), 0);

    IF _$OLDQTY - $OUTQTY < 0 THEN
      CALL COMERR('현재고가 부족합니다.');
      LEAVE PROC;
    END IF;

    -- 입출고 이력 등록
    INSERT INTO INOUT_PRDCONSUM (
      INOUTKEY, INOROUT, INOUTDATE, INOUTTP_PRDCONSUM, INOUTQTY,
      OLDQTY, ITEMID, EMPCD, REMARK,
      RTIME, REMP, RPRG
    ) VALUES (
      GETKEY('INOUTKEY'), 'OUT', $OUTDATE, $OUTTP, $OUTQTY,
      _$OLDQTY, $ITEMID, $EMPCD, '',
      CALLTIME(), CALLEMP(), CALLPRG()
    );

    -- 소모품 재고 차감
    UPDATE MSTITEM_PRDCONSUM
      SET MSTITEM_PRDCONSUM.LOTQTY = MSTITEM_PRDCONSUM.LOTQTY - $OUTQTY,
          MSTITEM_PRDCONSUM.MTIME = CALLTIME(),
          MSTITEM_PRDCONSUM.MEMP = CALLEMP(),
          MSTITEM_PRDCONSUM.MPRG = CALLPRG()
      WHERE MSTITEM_PRDCONSUM.ITEMID = $ITEMID
          AND MSTITEM_PRDCONSUM.FACTORYCD = '07';

-- *****************************************************************************

  WHEN 'LIST_INOUT_PRDCONSUM' THEN -- 소모품 입출고 이력 조회

    SET $ITEMID = TRIM(IFNULL($ITEMID, ''));
    SET $SDATE = TRIM(IFNULL($SDATE, ''));
    SET $EDATE = TRIM(IFNULL($EDATE, ''));

    IF $ITEMID = '' THEN
      CALL COMERR('소모품을 선택해주세요.');
      LEAVE PROC;
    END IF;

    SELECT INOUT_PRDCONSUM.INOUTDATE,
           CASE INOUT_PRDCONSUM.INOROUT
             WHEN 'IN' THEN '입고'
             WHEN 'OUT' THEN '출고'
             ELSE '' END AS INOROUT,
           GPCD('INOUTTP_PRDCONSUM', INOUT_PRDCONSUM.INOUTTP_PRDCONSUM) AS INOUTTPNM,
           CAST(CASE
                  WHEN INOUT_PRDCONSUM.INOROUT = 'IN' THEN INOUT_PRDCONSUM.INOUTQTY
                  ELSE 0 END AS DOUBLE) AS INQTY,
           CAST(CASE
                  WHEN INOUT_PRDCONSUM.INOROUT = 'OUT' THEN INOUT_PRDCONSUM.INOUTQTY
                  ELSE 0 END AS DOUBLE) AS OUTQTY,
           GPCD('EMPCD', INOUT_PRDCONSUM.EMPCD) AS EMPNM
      FROM INOUT_PRDCONSUM
      WHERE INOUT_PRDCONSUM.ITEMID = $ITEMID
          AND ($SDATE = '' OR INOUT_PRDCONSUM.INOUTDATE >= $SDATE)
          AND ($EDATE = '' OR INOUT_PRDCONSUM.INOUTDATE <= $EDATE)
      ORDER BY INOUT_PRDCONSUM.RTIME, INOUT_PRDCONSUM.INOUTKEY;

-- *****************************************************************************

  END CASE;

END
