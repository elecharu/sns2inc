CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML1020_R07(
-- *****************************************************************************
-- Comment: 유상사급 자재입고확인 - 외주처가 자재이동(TML1010_R06, INVOICETP 05) 한 거래명세서번호 또는 LOT번호 스캔
--          입고확인 때 이 거래명세서의 LOT 를 사내창고(04S100_N)에 입고(IO_MTRINVOICE, INTP 011, ERP DLV 송신)한 뒤 자재투입창고(04S111_N) 재고이동 (IO_MOVELOT_WARE, 입출고구분 02)
--          ERP I/F : 유상사급 자재입고확인 CSM (FAC2_ERP_IF_CSM, ERP 수신 정의서 V1.3 시트 10)
--          이동 GROUPKEY 는 거래명세서 헤더(MOVEGROUPKEY)에 남겨 반출(TML1020_R08) 때 되돌림
-- Create: 2026-11-12
-- Modify: 2026-11-19: 입고수불을 납품등록(TML1010_R01)에서 이 화면으로 이동 - 입고확인 때 납품 LOT 를 입고일자로 사내창고에 입고(INTP 011)
-- Modify: 2026-11-23: 납품등록이 거래명세서를 만들지 않으므로 이 자재이동 거래명세서(05) 로 바로 입고 (ERP 납품번호 = 2MES + 이 거래명세서번호)
-- Modify: 2026-11-18: ERP I/F 를 창고이동 WORK_10 에서 전용 테이블 CSM 으로 변경 (ERP 수신 정의서 V1.3)
-- Modify: 2026-11-16: 입고(IO_MTRINVOICE) → 사내창고→자재투입창고 재고이동으로 변경. 대상 거래명세서를 납품(01) 에서 자재이동(05) 으로 변경
-- *****************************************************************************
  IN $MTRINDATE       VARCHAR(10),
  IN $BARCODE         VARCHAR(100),
  IN $INVOICEKEY_LIST MEDIUMTEXT,
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$INVOICEKEY   VARCHAR(100);
  DECLARE _$LOTKEY_LIST  MEDIUMTEXT;
  DECLARE _$QTY_LIST     MEDIUMTEXT;
  DECLARE _$CNT          INT DEFAULT 0;

-- ****************************************************************************
CASE $CALLTYPE

-- ****************************************************************************
WHEN 'SCAN_BARCODE' THEN -- 거래명세서번호 또는 LOT번호 스캔 → 그 자재이동 거래명세서의 LOT 목록

  IF TRIM(IFNULL($BARCODE, '')) = '' THEN
    CALL COMERR('거래명세서번호 또는 LOT번호를 스캔하세요.');
    LEAVE PROC;
  END IF;

  -- 자재이동(05) 거래명세서번호로 먼저 찾고, 없으면 LOT번호로 그 LOT 의 자재이동 거래명세서를 찾는다
  IF EXISTS (SELECT 1
               FROM MTRCUST_INVOICE_HEADER
               WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = TRIM($BARCODE)
                 AND MTRCUST_INVOICE_HEADER.INVOICETP = '05') THEN
    SET _$INVOICEKEY = TRIM($BARCODE);
  ELSE
    SET _$INVOICEKEY = (SELECT MTRCUST_INVOICE_DETAIL.INVOICEKEY
                          FROM MTRCUST_INVOICE_DETAIL
                          INNER JOIN MTRCUST_INVOICE_HEADER ON MTRCUST_INVOICE_HEADER.INVOICEKEY = MTRCUST_INVOICE_DETAIL.INVOICEKEY
                                                           AND MTRCUST_INVOICE_HEADER.INVOICETP = '05'
                          WHERE MTRCUST_INVOICE_DETAIL.LOTKEY = TRIM($BARCODE)
                          LIMIT 1);
  END IF;

  IF IFNULL(_$INVOICEKEY, '') = '' THEN
    CALL COMERR(CONCAT('[', TRIM($BARCODE), '] 유상사급 자재이동 거래명세서번호 또는 LOT번호가 아닙니다.'));
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM MTRCUST_INVOICE_HEADER
              WHERE MTRCUST_INVOICE_HEADER.INVOICEKEY = _$INVOICEKEY AND IFNULL(MTRCUST_INVOICE_HEADER.MOVEGROUPKEY, '') <> '') THEN
    CALL COMERR(CONCAT('이미 입고확인된 거래명세서입니다. (', _$INVOICEKEY, ')'));
    LEAVE PROC;
  END IF;

  SELECT
    MTRCUST_INVOICE_DETAIL.INVOICEKEY,
    GPCD('CUSTCD', MTRCUST_INVOICE_HEADER.CUSTCD_GIVER) AS OUTCUSTNM,
    IFNULL((SELECT MSTWARE.WARENM FROM MSTWARE WHERE MSTWARE.WARECD = '04S111_N'), '') AS INWARENM,   -- 입고확인 = 자재투입창고로 이동
    MSTITEM.ITEMCD,
    MSTITEM.ITEMNM,
    MSTITEM.ITEMSPEC,
    MTRCUST_INVOICE_DETAIL.LOTKEY,
    IFNULL(MTRCUSTLOT.HEATNO, '') AS HEATNO,
    IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM,
    MTRCUST_INVOICE_DETAIL.LOTQTY AS INQTY,
    '' AS REMARK
  FROM MTRCUST_INVOICE_DETAIL
  INNER JOIN MTRCUST_INVOICE_HEADER ON MTRCUST_INVOICE_HEADER.INVOICEKEY = MTRCUST_INVOICE_DETAIL.INVOICEKEY
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = MTRCUST_INVOICE_DETAIL.ITEMID
  LEFT JOIN MTRCUSTLOT ON MTRCUSTLOT.LOTKEY = MTRCUST_INVOICE_DETAIL.LOTKEY
  WHERE MTRCUST_INVOICE_DETAIL.INVOICEKEY = _$INVOICEKEY
  ORDER BY MTRCUST_INVOICE_DETAIL.LOTKEY;

-- ****************************************************************************
WHEN 'ADD_MTRIN' THEN -- 스캔한 자재이동 거래명세서들을 입고일자로 입고확인 (사내창고 04S100_N → 자재투입창고 04S111_N 재고이동)

  IF IFNULL($MTRINDATE, '') = '' THEN
    CALL COMERR('입고일자를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($INVOICEKEY_LIST, '') = '' THEN
    CALL COMERR('입고확인할 거래명세서번호 또는 LOT번호를 스캔하세요.');
    LEAVE PROC;
  END IF;

  SET SESSION group_concat_max_len = 1000000;

  WHILE LENGTH($INVOICEKEY_LIST) > 0 DO
    CALL COMSPLIT($INVOICEKEY_LIST, _$INVOICEKEY);

    IF IFNULL(_$INVOICEKEY, '') <> '' THEN

      IF NOT EXISTS (SELECT 1 FROM MTRCUST_INVOICE_HEADER WHERE INVOICEKEY = _$INVOICEKEY AND INVOICETP = '05') THEN
        CALL COMERR(CONCAT('유상사급 자재이동 거래명세서가 아닙니다. (', _$INVOICEKEY, ')'));
        LEAVE PROC;
      END IF;

      IF EXISTS (SELECT 1 FROM MTRCUST_INVOICE_HEADER WHERE INVOICEKEY = _$INVOICEKEY AND IFNULL(MOVEGROUPKEY, '') <> '') THEN
        CALL COMERR(CONCAT('이미 입고확인된 거래명세서입니다. (', _$INVOICEKEY, ')'));
        LEAVE PROC;
      END IF;

      SET _$LOTKEY_LIST = (SELECT GROUP_CONCAT(MTRCUST_INVOICE_DETAIL.LOTKEY ORDER BY MTRCUST_INVOICE_DETAIL.LOTKEY SEPARATOR '»')
                             FROM MTRCUST_INVOICE_DETAIL
                             WHERE MTRCUST_INVOICE_DETAIL.INVOICEKEY = _$INVOICEKEY);
      SET _$QTY_LIST    = (SELECT GROUP_CONCAT(MTRCUST_INVOICE_DETAIL.LOTQTY ORDER BY MTRCUST_INVOICE_DETAIL.LOTKEY SEPARATOR '»')
                             FROM MTRCUST_INVOICE_DETAIL
                             WHERE MTRCUST_INVOICE_DETAIL.INVOICEKEY = _$INVOICEKEY);

      -- 입고수불 : 이 자재이동 거래명세서(05) 의 LOT 를 입고일자로 사내창고(04S100_N)에 입고 (INTP 011, ERP DLV 송신. 납품번호 = 2MES + 이 거래명세서번호)
      CALL IO_MTRINVOICE(_$INVOICEKEY, '04S100_N', '04S100_N', '04S100_N', '04S100_N', $MTRINDATE);

      IF IFNULL(@ERRMSG, '') <> '' THEN
        LEAVE PROC;
      END IF;

      -- 사내창고 → 자재투입창고 재고이동 (출고구분 02 / 입고구분 02)
      CALL IO_MOVELOT_WARE($MTRINDATE, '04S100_N', '04S111_N', '02', '02', _$LOTKEY_LIST, _$QTY_LIST);

      IF IFNULL(@ERRMSG, '') <> '' THEN
        LEAVE PROC;
      END IF;

      -- 이동 GROUPKEY 를 거래명세서에 남김 (반출 때 되돌림)
      UPDATE MTRCUST_INVOICE_HEADER
         SET MOVEGROUPKEY = @MOVEGROUPKEY
           , MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG()
       WHERE INVOICEKEY = _$INVOICEKEY;

      -- ERP 인터페이스 (유상사급 자재입고확인 FAC2_ERP_IF_CSM : 입고확인번호 = 2CM + 이동 GROUPKEY)
      CALL IO_ERP_INTERFACE('CSM', @MOVEGROUPKEY, 'I');

      IF IFNULL(@ERRMSG, '') <> '' THEN
        LEAVE PROC;
      END IF;

      SET _$CNT = _$CNT + 1;
    END IF;
  END WHILE;

  SELECT _$CNT AS CNT;

-- ****************************************************************************
END CASE; END
