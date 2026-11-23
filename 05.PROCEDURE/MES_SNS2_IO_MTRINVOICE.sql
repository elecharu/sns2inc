CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.IO_MTRINVOICE(
-- *****************************************************************************
-- Comment: 거래명세서 입고 등록
-- Create: 2026-10-08 김영철
-- Modify: 2026-11-09: 입고일자($INDATE) 추가 - 재고이력·입고이력·재고 생성일을 입고일자로 (비우면 오늘)
-- Modify: 2026-11-11: 입고 시 ERP 인터페이스(DLV) 송신 추가
-- Modify: 2026-11-12: 거래명세서의 시편수량은 입고 후 시편창고로 이동 (IO_MOVELOT_TEST)
-- Modify: 2026-11-12: 무상사급 납품(03) 은 외주이동 때 재고가 움직이지 않으므로, 입고 때 외주처 재고 차감 + 출고이력(COMOUT, 구분 82) 생성 추가
-- Modify: 2026-11-12: 거래명세서에 입고창고(INWARE, 외주이동 TML1010 R02 에서 선택)가 있으면 그 창고로 입고, 입고 후 ERP 인터페이스(WORK_21 외주입고) 송신 추가
-- Modify: 2026-11-19: 원자재·상품 구매(MM100910) 거래명세서 입고구분(INTP) 82 → 01 (구매입고)
-- Modify: 2026-11-19: 유상사급 구매(MM100900) 거래명세서 입고구분(INTP) 82 → 011 (구매입고(유상사급)). 입고는 유상사급 자재입고확인(TML1020_R07)에서 호출
-- *****************************************************************************
  IN $INVOICEKEY      VARCHAR(50),
  IN $MATERWARECD     VARCHAR(20),
  IN $PRODUCTWARECD   VARCHAR(20),
  IN $GOODSWARECD     VARCHAR(20),
  IN $TESTWARECD      VARCHAR(20),
  IN $INDATE          VARCHAR(10)
-- *****************************************************************************
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************

  DECLARE _$INDATE      VARCHAR(10);
  DECLARE _$INTIME      VARCHAR(19);
  DECLARE _$INKEY       VARCHAR(20);
  DECLARE _$MTRINKEY    VARCHAR(20);
  DECLARE _$INTP        VARCHAR(10);
  DECLARE _$ITEMID      VARCHAR(50);
  DECLARE _$ITEMCG      VARCHAR(20);
  DECLARE _$LOTTP       VARCHAR(10);
  DECLARE _$WARECD      VARCHAR(20);
  DECLARE _$HDRWARE     VARCHAR(20);   -- 거래명세서에 저장된 입고창고
  DECLARE _$HDRTP       VARCHAR(20);   -- 거래명세서 유형 (01 납품, 03 무상사급 납품)
  DECLARE _$OUTKEY      VARCHAR(20);
  DECLARE _$OUTWARE     VARCHAR(20);   -- 외주처 출고창고
  DECLARE _$OUTWARE_LIST MEDIUMTEXT;

  DECLARE _$ITEMID_LIST MEDIUMTEXT;

-- ****************************************************************************
IF IFNULL(@ERRMSG, '') = '' THEN
-- ****************************************************************************

  -- 1. 입력값 검증
  IF IFNULL($INVOICEKEY, '') = '' THEN
    CALL COMERR('거래명세서 번호가 없습니다.');
    LEAVE PROC;
  END IF;

  SET _$ITEMID_LIST = IFNULL((SELECT GROUP_CONCAT(DISTINCT ITEMID ORDER BY ITEMID ASC SEPARATOR '»')
                                FROM MTRCUST_INVOICE_DETAIL
                                WHERE INVOICEKEY = $INVOICEKEY), ''); 

  IF IFNULL(_$ITEMID_LIST, '') = '' THEN
    CALL COMERR('입고할 품목이 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($MATERWARECD, '') = '' THEN
    CALL COMERR('원자재 입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($PRODUCTWARECD, '') = '' THEN
    CALL COMERR('반제품 입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($GOODSWARECD, '') = '' THEN
    CALL COMERR('상품 입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($TESTWARECD, '') = '' THEN
    CALL COMERR('시편 입고창고를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MTRCUST_INVOICE_DETAIL WHERE INVOICEKEY = $INVOICEKEY) THEN
    CALL COMERR('거래명세서 상세가 없습니다.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM MTRIN WHERE INVOICEKEY = $INVOICEKEY) THEN
    CALL COMERR('입고이력이 존재하는 거래명세서 입니다.');
    LEAVE PROC;
  END IF;

  -- 입고구분 : 원자재·상품 구매(MM100910, 자재입고확인 TML1020_R09) 는 01(구매입고), 유상사급 구매(MM100900, 자재입고확인 TML1020_R07) 는 011(구매입고(유상사급)),
  --           그 외 외주입고는 82(무상사급 납품입고)
  SET _$INTP = CASE
                 WHEN EXISTS (SELECT 1
                                FROM MTRCUST_INVOICE_DETAIL AS D
                               INNER JOIN MTRCUSTLOT AS L ON L.LOTKEY = D.LOTKEY
                               INNER JOIN MTRODR AS O ON O.MTRODRKEY = L.MTRODRKEY
                               WHERE D.INVOICEKEY = $INVOICEKEY
                                 AND O.ODRBC = 'MM100910') THEN '01'
                 WHEN EXISTS (SELECT 1
                                FROM MTRCUST_INVOICE_DETAIL AS D
                               INNER JOIN MTRCUSTLOT AS L ON L.LOTKEY = D.LOTKEY
                               INNER JOIN MTRODR AS O ON O.MTRODRKEY = L.MTRODRKEY
                               WHERE D.INVOICEKEY = $INVOICEKEY
                                 AND O.ODRBC = 'MM100900') THEN '011'
                 ELSE '82'
               END;
  SET _$HDRTP = IFNULL((SELECT MTRCUST_INVOICE_HEADER.INVOICETP FROM MTRCUST_INVOICE_HEADER WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = $INVOICEKEY), '');
  SET _$HDRWARE = IFNULL((SELECT MTRCUST_INVOICE_HEADER.INWARE FROM MTRCUST_INVOICE_HEADER WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = $INVOICEKEY), '');

  -- 입고일자 (수불일자). 시간은 등록 시각
  SET _$INDATE = IF(IFNULL($INDATE, '') = '', GETDATE(), LEFT($INDATE, 10));
  SET _$INTIME = CONCAT(_$INDATE, ' ', RIGHT(GETTIME(), 8));

  WHILE LENGTH(IFNULL(_$ITEMID_LIST, '')) > 0 DO
    CALL COMSPLIT(_$ITEMID_LIST, _$ITEMID);

    IF IFNULL(_$ITEMID, '') = '' THEN
      CALL COMERR('품목 또는 구분 정보가 없습니다.');
      LEAVE PROC;
    END IF;

    SET _$ITEMCG = (SELECT ITEMCG FROM MSTITEM WHERE ITEMID = _$ITEMID);

    -- 입고창고 결정 (시편 우선)
    SET _$WARECD = CASE
                     WHEN _$HDRWARE <> ''       THEN _$HDRWARE   -- 거래명세서에 입고창고가 있으면 그 창고
                     WHEN _$LOTTP  = '02'       THEN $TESTWARECD
                     WHEN _$ITEMCG = 'DM100300' THEN $MATERWARECD
                     WHEN _$ITEMCG = 'DM100150' THEN $PRODUCTWARECD
                     WHEN _$ITEMCG = 'DM100200' THEN $GOODSWARECD
                     ELSE ''
                   END;

    IF IFNULL(_$WARECD, '') = '' THEN
      CALL COMERR(CONCAT(_$ITEMID, ' 품목에 해당하는 입고창고가 없습니다.'));
      LEAVE PROC;
    END IF;

    -- 해당 품목+구분의 LOT이 상세에 실제로 있는지 확인
    IF NOT EXISTS (SELECT 1
                     FROM MTRCUST_INVOICE_DETAIL
                    WHERE INVOICEKEY = $INVOICEKEY
                      AND ITEMID = _$ITEMID) THEN
      CALL COMERR(CONCAT(_$ITEMID, ' 품목이 없습니다.'));
      LEAVE PROC;
    END IF;

    SET _$MTRINKEY = GETKEY('MTRIN');
    SET _$INKEY    = GETKEY('INKEY');

    -- 재고이력
    INSERT INTO COMIN (
        INKEY, ITEMID, WARECD, INTP, INDATE, INQTY,
        EMPCD, MTRINKEY, INVOICEKEY, RTIME, REMP, RPRG
    )
    SELECT _$INKEY, _$ITEMID, _$WARECD, _$INTP, _$INDATE, SUM(LOTQTY),
           CALLEMP(), _$MTRINKEY, INVOICEKEY, CALLTIME(), CALLEMP(), CALLPRG()
      FROM MTRCUST_INVOICE_DETAIL
     WHERE INVOICEKEY = $INVOICEKEY
       AND ITEMID = _$ITEMID
    GROUP BY ITEMID;

    -- 재고상세이력
    INSERT INTO COMINLOT (
        INKEY, LOTKEY, WARECD, INTP, INDATE, INQTY, ITEMID,
        RTIME, REMP, RPRG
    )
    SELECT _$INKEY, LOTKEY, _$WARECD, _$INTP, _$INDATE, LOTQTY, ITEMID,
           CALLTIME(), CALLEMP(), CALLPRG()
      FROM MTRCUST_INVOICE_DETAIL
     WHERE INVOICEKEY = $INVOICEKEY
       AND ITEMID = _$ITEMID;

    -- 입고이력
    INSERT INTO MTRIN (
        MTRINKEY, INVOICEKEY, MTRINTIME, MTRINTP, CUSTCD,
        ITEMID, WARECD, EMPCD, INDATE, INQTY,
        RTIME, REMP, RPRG
    )
    SELECT _$MTRINKEY, $INVOICEKEY, _$INTIME, _$INTP, A.CUSTCD_GIVER,
           _$ITEMID, _$WARECD, CALLEMP(), _$INDATE, SUM(B.LOTQTY),
           CALLTIME(), CALLEMP(), CALLPRG()
      FROM MTRCUST_INVOICE_HEADER AS A
     INNER JOIN MTRCUST_INVOICE_DETAIL AS B ON A.INVOICEKEY = B.INVOICEKEY
     WHERE A.INVOICEKEY = $INVOICEKEY
       AND B.ITEMID     = _$ITEMID
     GROUP BY B.ITEMID;

    -- 입고상세이력
    INSERT INTO MTRINLOT (
        MTRINKEY, LOTKEY, LOTQTY, MTRINTIME, RTIME, REMP, RPRG
    )
    SELECT _$MTRINKEY, LOTKEY, LOTQTY, _$INTIME,
           CALLTIME(), CALLEMP(), CALLPRG()
      FROM MTRCUST_INVOICE_DETAIL
     WHERE INVOICEKEY = $INVOICEKEY
       AND ITEMID = _$ITEMID;

    -- ERP 인터페이스 (외주처 원자재 납품, 입고번호 기준)
    CALL IO_ERP_INTERFACE('DLV', _$MTRINKEY, 'I');

    IF IFNULL(@ERRMSG, '') <> '' THEN
      LEAVE PROC;
    END IF;

    -- 무상사급 납품(03) : 외주이동 때는 재고가 움직이지 않으므로 입고 때 외주처 재고 차감 + 출고이력 생성
    --   (출고이력이 이미 있는 예전 거래명세서는 건너뜀)
    IF _$HDRTP = '03'
       AND NOT EXISTS (SELECT 1 FROM COMOUT WHERE COMOUT.INVOICEKEY = $INVOICEKEY AND COMOUT.ITEMID = _$ITEMID) THEN

      SET _$OUTWARE_LIST = IFNULL((SELECT GROUP_CONCAT(DISTINCT D.WARECD ORDER BY D.WARECD ASC SEPARATOR '»')
                                     FROM MTRCUST_INVOICE_DETAIL AS D
                                    WHERE D.INVOICEKEY = $INVOICEKEY
                                      AND D.ITEMID = _$ITEMID
                                      AND IFNULL(D.WARECD, '') <> ''), '');

      IF _$OUTWARE_LIST = '' THEN
        CALL COMERR('거래명세서에 외주처 출고창고 정보가 없습니다.');
        LEAVE PROC;
      END IF;

      WHILE LENGTH(IFNULL(_$OUTWARE_LIST, '')) > 0 DO
        CALL COMSPLIT(_$OUTWARE_LIST, _$OUTWARE);

        IF EXISTS (SELECT 1
                     FROM MTRCUST_INVOICE_DETAIL AS D
                     LEFT JOIN COMLOT AS L ON L.LOTKEY = D.LOTKEY AND L.WARECD = D.WARECD
                    WHERE D.INVOICEKEY = $INVOICEKEY
                      AND D.ITEMID = _$ITEMID
                      AND D.WARECD = _$OUTWARE
                      AND IFNULL(L.LOTQTY, 0) < D.LOTQTY) THEN
          CALL COMERR('외주처 재고가 입고수량보다 적어 입고할 수 없습니다.');
          LEAVE PROC;
        END IF;

        SET _$OUTKEY = GETKEY('OUTKEY');

        INSERT INTO COMOUT (
            OUTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, ITEMID,
            EMPCD, INVOICEKEY, RTIME, REMP, RPRG
        )
        SELECT _$OUTKEY, _$OUTWARE, '82', _$INDATE, SUM(D.LOTQTY), _$ITEMID,
               CALLEMP(), $INVOICEKEY, CALLTIME(), CALLEMP(), CALLPRG()
          FROM MTRCUST_INVOICE_DETAIL AS D
         WHERE D.INVOICEKEY = $INVOICEKEY
           AND D.ITEMID = _$ITEMID
           AND D.WARECD = _$OUTWARE;

        INSERT INTO COMOUTLOT (
            OUTKEY, LOTKEY, WARECD, OUTTP, OUTDATE, OUTQTY, ITEMID, OLDQTY,
            RTIME, REMP, RPRG
        )
        SELECT _$OUTKEY, D.LOTKEY, _$OUTWARE, '82', _$INDATE, D.LOTQTY, D.ITEMID, L.LOTQTY,
               CALLTIME(), CALLEMP(), CALLPRG()
          FROM MTRCUST_INVOICE_DETAIL AS D
         INNER JOIN COMLOT AS L ON L.LOTKEY = D.LOTKEY AND L.WARECD = D.WARECD
         WHERE D.INVOICEKEY = $INVOICEKEY
           AND D.ITEMID = _$ITEMID
           AND D.WARECD = _$OUTWARE;

        UPDATE COMLOT AS L
         INNER JOIN MTRCUST_INVOICE_DETAIL AS D ON D.LOTKEY = L.LOTKEY AND D.WARECD = L.WARECD
           SET L.LOTQTY = L.LOTQTY - D.LOTQTY,
               L.MTIME  = CALLTIME(),
               L.MEMP   = CALLEMP(),
               L.MPRG   = CALLPRG()
         WHERE D.INVOICEKEY = $INVOICEKEY
           AND D.ITEMID = _$ITEMID
           AND D.WARECD = _$OUTWARE;

      END WHILE;
    END IF;
    -- 재고 생성
    INSERT INTO COMLOT (
        LOTKEY, WARECD, LOTQTY, ITEMID, CRTTIME, CRTQTY,
        CUSTCD, MTRINKEY, LOTTP, RTIME, REMP, RPRG
    )
    SELECT B.LOTKEY, _$WARECD, B.LOTQTY, B.ITEMID, _$INTIME, B.LOTQTY,
           A.CUSTCD_GIVER, _$MTRINKEY, B.LOTTP, CALLTIME(), CALLEMP(), CALLPRG()
      FROM MTRCUST_INVOICE_HEADER AS A
     INNER JOIN MTRCUST_INVOICE_DETAIL AS B ON A.INVOICEKEY = B.INVOICEKEY
     WHERE A.INVOICEKEY = $INVOICEKEY
       AND B.ITEMID = _$ITEMID;

  END WHILE;

  -- 시편수량 : 입고창고에 들어온 LOT 의 시편수량을 시편창고로 이동
  CALL IO_MOVELOT_TEST($INVOICEKEY, '', _$INDATE);

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- ERP 인터페이스 (외주입고, 거래명세서 기준. 무상사급 납품(03) 거래명세서만 송신)
  CALL IO_ERP_INTERFACE('WORK_21', $INVOICEKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

 -- ****************************************************************************
END IF; END