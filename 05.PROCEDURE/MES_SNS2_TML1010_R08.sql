CREATE DEFINER=`root`@`%` 
PROCEDURE `MES_SNS2`.`TML1010_R08`(
-- *****************************************************************************
-- Comment: 현장터미널 설비부품 입고등록
-- Create:  2026-11-17  생성          한성수  TML1010_R05 설비부품 입출고에서 입고등록·입고이력·라벨출력 분리
-- Modify:  2026-11-18                한성수  재고조회 등급·로케이션 조건, 입고취소 추가, 발주 잔량 MES 입고 기준 계산, 입고공장 기준 발주 조회
--          2026-11-24                한성수  재고조회 삭제, 발주조회·발주 품목별 일괄 입고 추가, 입고 이력 일괄 취소·라벨 재발행, 입고 가능 상태 발주확정·발주승인 제한
-- *****************************************************************************
  IN $SDATE          VARCHAR(10),
  IN $EDATE          VARCHAR(10),
  IN $FACTORYCD      VARCHAR(100),
  IN $CUSTCD         VARCHAR(100),
  IN $INDATE         VARCHAR(10),
  IN $INTP           VARCHAR(100),
  IN $MTRODRKEY      VARCHAR(100),
  IN $MTRODRSEQ_LIST MEDIUMTEXT,
  IN $INQTY_LIST     MEDIUMTEXT,
  IN $EMPCD          VARCHAR(100),
  IN $INOUTKEY_LIST  MEDIUMTEXT,
-- *****************************************************************************
  IN $CALLTYPE       VARCHAR(50)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$OLDQTY    DECIMAL(20, 8);
  DECLARE _$ITEMID    VARCHAR(100);
  DECLARE _$CANQTY    DECIMAL(20, 8);
  DECLARE _$FACTORYCD VARCHAR(10);
  DECLARE _$MTRODRSEQ VARCHAR(100);
  DECLARE _$INQTY     DECIMAL(20, 8);
  DECLARE _$ITEMCD    VARCHAR(100);
  DECLARE _$SEQ       INT;
  DECLARE _$INOUTKEY  VARCHAR(100);

-- *****************************************************************************
  SET $SDATE     = IFNULL($SDATE, '');
  SET $EDATE     = IFNULL($EDATE, '');
  SET $FACTORYCD = IFNULL($FACTORYCD, '');
  SET $CUSTCD    = IFNULL($CUSTCD, '');

  -- 입고자 입력 확인
  IF $CALLTYPE = 'IN_EQMPARTS' THEN
    IF IFNULL(TRIM($EMPCD), '') = '' THEN
      CALL COMERR('입고자를 선택해주세요.');
      LEAVE PROC;
    END IF;
  END IF;

  CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_MTRODR' THEN -- 입고 가능 발주 목록

    SELECT MTRODR.MTRODRKEY, MTRODR.MTRODRDATE,
           GPCD('MM110', MTRODR.MTRODRSTT) AS MTRODRSTTNM,
           IFNULL(MSTCUST.CUSTNM, MTRODR.CUSTCD) AS CUSTNM
    FROM MTRODR
    INNER JOIN (SELECT MTRODRD.MTRODRKEY
                FROM MTRODRD
                INNER JOIN MSTITEM
                  ON MSTITEM.ITEMID = MTRODRD.ITEMID
                LEFT JOIN (SELECT MTRODRKEY, MTRODRSEQ, SUM(INOUTQTY) AS INQTY
                           FROM INOUT_EQMPARTS
                           WHERE INOROUT = 'IN'
                             AND MTRODRKEY <> ''
                           GROUP BY MTRODRKEY, MTRODRSEQ) INSUM
                  ON INSUM.MTRODRKEY = MTRODRD.MTRODRKEY
                 AND INSUM.MTRODRSEQ = MTRODRD.MTRODRSEQ
                WHERE MSTITEM.COMPANYCD = '60'
                  AND MSTITEM.ITEMCG = 'DM100700'
                  AND MTRODRD.MTRODRSTT IN ('MM110200', 'MM110201')
                  AND IFNULL(MTRODRD.ODRQTY, 0) > IFNULL(INSUM.INQTY, 0)
                GROUP BY MTRODRD.MTRODRKEY) ODRD
      ON ODRD.MTRODRKEY = MTRODR.MTRODRKEY
    LEFT JOIN MSTCUST
      ON MSTCUST.CUSTCD = MTRODR.CUSTCD
    WHERE ($FACTORYCD = '' OR MTRODR.INFACTORYCD = $FACTORYCD)
      AND ($SDATE = '' OR MTRODR.MTRODRDATE >= $SDATE)
      AND ($EDATE = '' OR MTRODR.MTRODRDATE <= $EDATE)
      AND ($CUSTCD = '' OR MTRODR.CUSTCD = $CUSTCD)
    ORDER BY MTRODR.MTRODRDATE DESC, MTRODR.MTRODRKEY DESC;

-- *****************************************************************************

  WHEN 'LIST_MTRODRD' THEN -- 선택 발주 입고 가능 품목

    SELECT MTRODRD.MTRODRKEY, MTRODRD.MTRODRSEQ,
           CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID,
           GPCD('MM110', MTRODRD.MTRODRSTT) AS MTRODRSTTNM,
           MSTITEM.ITEMCD, MSTITEM.ITEMNM, MSTITEM.ITEMSPEC,
           CAST(IFNULL(MTRODRD.ODRQTY, 0) AS DOUBLE) AS ODRQTY,
           CAST(IFNULL(MTRODRD.ODRQTY, 0) - IFNULL(INSUM.INQTY, 0) AS DOUBLE) AS REMAINQTY,
           CAST(IFNULL(MTRODRD.ODRQTY, 0) - IFNULL(INSUM.INQTY, 0) AS DOUBLE) AS INQTY
    FROM MTRODRD
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = MTRODRD.ITEMID
    LEFT JOIN (SELECT MTRODRSEQ, SUM(INOUTQTY) AS INQTY
               FROM INOUT_EQMPARTS
               WHERE MTRODRKEY = $MTRODRKEY
                 AND INOROUT = 'IN'
               GROUP BY MTRODRSEQ) INSUM
      ON INSUM.MTRODRSEQ = MTRODRD.MTRODRSEQ
    WHERE MTRODRD.MTRODRKEY = $MTRODRKEY
      AND MSTITEM.COMPANYCD = '60'
      AND MSTITEM.ITEMCG = 'DM100700'
      AND MTRODRD.MTRODRSTT IN ('MM110200', 'MM110201')
      AND IFNULL(MTRODRD.ODRQTY, 0) > IFNULL(INSUM.INQTY, 0)
    ORDER BY MTRODRD.MTRODRSEQ;

-- *****************************************************************************

  WHEN 'IN_EQMPARTS' THEN -- 발주 품목별 일괄 입고등록

    IF IFNULL($MTRODRKEY, '') = '' THEN
      CALL COMERR('입고할 발주를 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL($INDATE, '') = '' THEN
      CALL COMERR('입고일자를 입력하십시오.');
      LEAVE PROC;
    END IF;

    IF IFNULL($INTP, '') = '' THEN
      CALL COMERR('입고구분을 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 품목별 입고수량
    DROP TEMPORARY TABLE IF EXISTS TEMP_IN;
    CREATE TEMPORARY TABLE TEMP_IN (
        SEQ       INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        MTRODRSEQ INT,
        INQTY     DECIMAL(20, 8),
        ITEMID    VARCHAR(100) DEFAULT '',
        DONEYN    VARCHAR(1) DEFAULT 'N'
    );

    SET $MTRODRSEQ_LIST = IFNULL($MTRODRSEQ_LIST, '');
    SET $INQTY_LIST     = IFNULL($INQTY_LIST, '');

    WHILE LENGTH($MTRODRSEQ_LIST) > 0 DO
      CALL COMSPLIT($MTRODRSEQ_LIST, _$MTRODRSEQ);
      CALL COMSPLIT($INQTY_LIST, _$INQTY);

      IF IFNULL(_$INQTY, 0) < 0 THEN
        CALL COMERR('입고수량은 0보다 작을 수 없습니다.');
        LEAVE PROC;
      END IF;

      IF IFNULL(_$MTRODRSEQ, '') <> '' AND IFNULL(_$INQTY, 0) > 0 THEN
        INSERT INTO TEMP_IN (MTRODRSEQ, INQTY)
        VALUES (_$MTRODRSEQ, _$INQTY);
      END IF;
    END WHILE;

    IF NOT EXISTS (SELECT 1 FROM TEMP_IN) THEN
      CALL COMERR('입고수량을 0보다 크게 입력하십시오.');
      LEAVE PROC;
    END IF;

    -- 발주 입고공장 취득 (동시 입고 잠금)
    SET _$FACTORYCD = (SELECT INFACTORYCD FROM MTRODR WHERE MTRODRKEY = $MTRODRKEY FOR UPDATE);

    IF IFNULL(_$FACTORYCD, '') = '' THEN
      CALL COMERR('입고할 발주 정보가 없습니다.');
      LEAVE PROC;
    END IF;

    -- 입고 가능 품목 확인 (설비부품·발주확정·발주승인 상태)
    SET _$ITEMCD = (SELECT IFNULL(MSTITEM.ITEMCD, CAST(TEMP_IN.MTRODRSEQ AS CHAR))
                    FROM TEMP_IN
                    LEFT JOIN MTRODRD
                      ON MTRODRD.MTRODRKEY = $MTRODRKEY
                     AND MTRODRD.MTRODRSEQ = TEMP_IN.MTRODRSEQ
                    LEFT JOIN MSTITEM
                      ON MSTITEM.ITEMID = MTRODRD.ITEMID
                    WHERE MTRODRD.MTRODRKEY IS NULL
                       OR IFNULL(MSTITEM.ITEMCG, '') <> 'DM100700'
                       OR IFNULL(MTRODRD.MTRODRSTT, '') NOT IN ('MM110200', 'MM110201')
                    LIMIT 1);

    IF _$ITEMCD IS NOT NULL THEN
      CALL COMERR(CONCAT('입고할 수 없는 발주 품목입니다. (', _$ITEMCD, ')'));
      LEAVE PROC;
    END IF;

    -- 미입고량 초과 확인 (발주량 - MES 입고 이력 합계)
    SET _$ITEMCD = (SELECT MSTITEM.ITEMCD
                    FROM TEMP_IN
                    INNER JOIN MTRODRD
                      ON MTRODRD.MTRODRKEY = $MTRODRKEY
                     AND MTRODRD.MTRODRSEQ = TEMP_IN.MTRODRSEQ
                    INNER JOIN MSTITEM
                      ON MSTITEM.ITEMID = MTRODRD.ITEMID
                    LEFT JOIN (SELECT MTRODRSEQ, SUM(INOUTQTY) AS INQTY
                               FROM INOUT_EQMPARTS
                               WHERE MTRODRKEY = $MTRODRKEY
                                 AND INOROUT = 'IN'
                               GROUP BY MTRODRSEQ) INSUM
                      ON INSUM.MTRODRSEQ = TEMP_IN.MTRODRSEQ
                    WHERE TEMP_IN.INQTY > IFNULL(MTRODRD.ODRQTY, 0) - IFNULL(INSUM.INQTY, 0)
                    LIMIT 1);

    IF _$ITEMCD IS NOT NULL THEN
      CALL COMERR(CONCAT('입고수량이 미입고량보다 많습니다. (', _$ITEMCD, ')'));
      LEAVE PROC;
    END IF;

    -- 입고 품목ID 반영
    UPDATE TEMP_IN
    INNER JOIN MTRODRD
      ON MTRODRD.MTRODRKEY = $MTRODRKEY
     AND MTRODRD.MTRODRSEQ = TEMP_IN.MTRODRSEQ
    SET TEMP_IN.ITEMID = MTRODRD.ITEMID;

    -- 발주 입고공장 설비부품 재고 정보 확인
    SET _$ITEMCD = (SELECT MSTITEM.ITEMCD
                    FROM TEMP_IN
                    INNER JOIN MSTITEM
                      ON MSTITEM.ITEMID = TEMP_IN.ITEMID
                    LEFT JOIN MSTITEM_EQMPARTS
                      ON MSTITEM_EQMPARTS.ITEMID = TEMP_IN.ITEMID
                     AND MSTITEM_EQMPARTS.FACTORYCD = _$FACTORYCD
                    WHERE MSTITEM_EQMPARTS.ITEMID IS NULL
                    LIMIT 1);

    IF _$ITEMCD IS NOT NULL THEN
      CALL COMERR(CONCAT('입고공장 설비부품 재고 정보가 없습니다. (', _$ITEMCD, ')'));
      LEAVE PROC;
    END IF;

    -- 품목별 입고 이력 등록 및 재고 증가
    WHILE EXISTS (SELECT 1 FROM TEMP_IN WHERE DONEYN = 'N') DO
      SET _$SEQ = (SELECT MIN(SEQ) FROM TEMP_IN WHERE DONEYN = 'N');

      SELECT MTRODRSEQ, INQTY, ITEMID
        INTO _$MTRODRSEQ, _$INQTY, _$ITEMID
      FROM TEMP_IN
      WHERE SEQ = _$SEQ;

      SET _$OLDQTY = (SELECT LOTQTY FROM MSTITEM_EQMPARTS WHERE ITEMID = _$ITEMID AND FACTORYCD = _$FACTORYCD LIMIT 1 FOR UPDATE);

      INSERT INTO INOUT_EQMPARTS (
          INOUTKEY, INOROUT, INOUTDATE, INOUTTP_EQMPARTS, INOUTQTY, OLDQTY,
          ITEMID, EMPCD, MTRODRKEY, MTRODRSEQ, REMARK,
          RTIME, REMP, RPRG
      ) VALUES (
          GETKEY('INOUTKEY'), 'IN', $INDATE, $INTP, _$INQTY, _$OLDQTY,
          _$ITEMID, $EMPCD, $MTRODRKEY, _$MTRODRSEQ, '',
          CALLTIME(), CALLEMP(), CALLPRG()
      );

      UPDATE MSTITEM_EQMPARTS
      SET LOTQTY = LOTQTY + _$INQTY,
          MTIME  = CALLTIME(),
          MEMP   = CALLEMP(),
          MPRG   = CALLPRG()
      WHERE ITEMID = _$ITEMID
        AND FACTORYCD = _$FACTORYCD;

      UPDATE TEMP_IN
      SET DONEYN = 'Y'
      WHERE SEQ = _$SEQ;
    END WHILE;

    -- 입고 품목 라벨 출력 데이터 반환
    SELECT 'EQMPARTS' AS LABELCD;

    SELECT MSTITEM.ITEMNM, MSTITEM.ITEMCD, MSTITEM.ITEMID
    FROM TEMP_IN
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = TEMP_IN.ITEMID
    ORDER BY TEMP_IN.SEQ;

-- *****************************************************************************

  WHEN 'LIST_IN_EQMPARTS' THEN -- 입고 이력 조회

    SELECT INOUT_EQMPARTS.INOUTKEY, INOUT_EQMPARTS.INOUTDATE,
           INOUT_EQMPARTS.MTRODRKEY,
           IFNULL(MSTCUST.CUSTNM, IFNULL(MTRODR.CUSTCD, '')) AS CUSTNM,
           MSTITEM.ITEMCD, MSTITEM.ITEMNM,
           CAST(INOUT_EQMPARTS.INOUTQTY AS DOUBLE) AS INQTY,
           GPCD('EMPCD', INOUT_EQMPARTS.EMPCD) AS EMPNM,
           INOUT_EQMPARTS.RTIME
    FROM INOUT_EQMPARTS
    LEFT JOIN MSTITEM
      ON MSTITEM.ITEMID = INOUT_EQMPARTS.ITEMID
    LEFT JOIN MTRODR
      ON MTRODR.MTRODRKEY = INOUT_EQMPARTS.MTRODRKEY
    LEFT JOIN MSTCUST
      ON MSTCUST.CUSTCD = MTRODR.CUSTCD
    WHERE INOUT_EQMPARTS.INOROUT = 'IN'
      AND ($FACTORYCD = '' OR IFNULL(MTRODR.INFACTORYCD, '07') = $FACTORYCD)
      AND ($CUSTCD = '' OR MTRODR.CUSTCD = $CUSTCD)
      AND ($SDATE = '' OR INOUT_EQMPARTS.INOUTDATE >= $SDATE)
      AND ($EDATE = '' OR INOUT_EQMPARTS.INOUTDATE <= $EDATE)
    ORDER BY INOUT_EQMPARTS.RTIME DESC;

-- *****************************************************************************

  WHEN 'CANCEL_IN_EQMPARTS' THEN -- 입고 이력 일괄 취소

    IF IFNULL($INOUTKEY_LIST, '') = '' THEN
      CALL COMERR('입고 취소할 이력을 체크해주세요.');
      LEAVE PROC;
    END IF;

    WHILE LENGTH($INOUTKEY_LIST) > 0 DO
      CALL COMSPLIT($INOUTKEY_LIST, _$INOUTKEY);

      IF IFNULL(_$INOUTKEY, '') <> '' THEN
        -- 취소할 입고 이력·입고공장 취득 (발주 없는 입고는 2공장)
        SELECT MAX(INOUT_EQMPARTS.ITEMID), MAX(INOUT_EQMPARTS.INOUTQTY), MAX(IFNULL(MTRODR.INFACTORYCD, '07'))
          INTO _$ITEMID, _$CANQTY, _$FACTORYCD
        FROM INOUT_EQMPARTS
        LEFT JOIN MTRODR
          ON MTRODR.MTRODRKEY = INOUT_EQMPARTS.MTRODRKEY
        WHERE INOUT_EQMPARTS.INOUTKEY = _$INOUTKEY
          AND INOUT_EQMPARTS.INOROUT = 'IN'
        FOR UPDATE;

        IF _$ITEMID IS NULL THEN
          CALL COMERR('취소할 입고 이력이 없습니다. 다시 조회해주세요.');
          LEAVE PROC;
        END IF;

        -- 입고 후 출고되어 현재고가 부족하면 취소 불가
        SET _$OLDQTY = IFNULL((SELECT LOTQTY FROM MSTITEM_EQMPARTS WHERE ITEMID = _$ITEMID AND FACTORYCD = _$FACTORYCD LIMIT 1 FOR UPDATE), 0);
        IF _$OLDQTY < _$CANQTY THEN
          SET _$ITEMCD = (SELECT ITEMCD FROM MSTITEM WHERE ITEMID = _$ITEMID);
          CALL COMERR(CONCAT('현재고가 입고수량보다 적어 입고를 취소할 수 없습니다. (', IFNULL(_$ITEMCD, _$ITEMID), ')'));
          LEAVE PROC;
        END IF;

        -- 입고 이력 삭제
        DELETE FROM INOUT_EQMPARTS
        WHERE INOUTKEY = _$INOUTKEY;

        -- 설비부품 재고 차감
        UPDATE MSTITEM_EQMPARTS
        SET LOTQTY = LOTQTY - _$CANQTY,
            MTIME  = CALLTIME(),
            MEMP   = CALLEMP(),
            MPRG   = CALLPRG()
        WHERE ITEMID = _$ITEMID
          AND FACTORYCD = _$FACTORYCD;
      END IF;
    END WHILE;

-- *****************************************************************************

  WHEN 'LABEL_REPRINT' THEN -- 입고 이력 라벨 재발행

    IF IFNULL($INOUTKEY_LIST, '') = '' THEN
      CALL COMERR('라벨을 재발행할 이력을 체크해주세요.');
      LEAVE PROC;
    END IF;

    DROP TEMPORARY TABLE IF EXISTS TEMP_LABEL;
    CREATE TEMPORARY TABLE TEMP_LABEL (
        SEQ      INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        INOUTKEY VARCHAR(100)
    );

    WHILE LENGTH($INOUTKEY_LIST) > 0 DO
      CALL COMSPLIT($INOUTKEY_LIST, _$INOUTKEY);

      IF IFNULL(_$INOUTKEY, '') <> '' THEN
        INSERT INTO TEMP_LABEL (INOUTKEY)
        VALUES (_$INOUTKEY);
      END IF;
    END WHILE;

    SELECT 'EQMPARTS' AS LABELCD;

    SELECT MSTITEM.ITEMNM, MSTITEM.ITEMCD, MSTITEM.ITEMID
    FROM TEMP_LABEL
    INNER JOIN INOUT_EQMPARTS
      ON INOUT_EQMPARTS.INOUTKEY = TEMP_LABEL.INOUTKEY
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = INOUT_EQMPARTS.ITEMID
    ORDER BY TEMP_LABEL.SEQ;

-- *****************************************************************************

  END CASE;

END
