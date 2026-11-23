CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.LOT1002_S01(
-- *****************************************************************************
-- Comment: 기타 입출고 이력 조회·삭제
-- Modify: 2026-11-19: 기타출고 이력의 출고구분을 COMOUTLOT.ETCTP(공통코드 ETCTP)로 조회 (COMOUT.OUTTP 는 99 고정)
-- *****************************************************************************
  IN $SDATE       VARCHAR(10),
  IN $EDATE       VARCHAR(10),
  IN $WARECD      VARCHAR(20),
  IN $ITEMCG      VARCHAR(20),
  IN $ITEMID      VARCHAR(50),
  IN $LOTKEYLIST  MEDIUMTEXT,
  IN $INKEYLIST   MEDIUMTEXT,
  IN $OUTKEYLIST  MEDIUMTEXT,
-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))PROC:  BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
-- *****************************************************************************
CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_IN_ETC' THEN

  SELECT
      COMIN.INKEY, -- 입고키
      COMIN.INDATE, -- 입고일자
      COMIN.RTIME,  -- 등록일시
      COMIN.WARECD, -- 창고코드
      GPCD('WARECD', COMIN.WARECD) AS WARENM, -- 창고명
      COMIN.INTP, -- 입고구분
      GPCD('EMPCD', COMIN.EMPCD) AS EMPNM, -- 사원
      COMIN.REMARK, -- 사유
      MSTITEM.ITEMCG, -- 품목유형
      MSTITEM.ITEMNM, -- 품명
      COMIN.ITEMID,
      MSTITEM.ITEMCD, -- 품목코드
      COMINLOT.LOTKEY,  -- 로트번호
      COMINLOT.INQTY -- 입고수량
    FROM COMIN
    INNER JOIN COMINLOT
            ON COMINLOT.INKEY = COMIN.INKEY
    INNER JOIN MSTITEM
            ON MSTITEM.ITEMID = COMIN.ITEMID
    WHERE COMIN.INDATE BETWEEN $SDATE AND $EDATE
      AND COMIN.INTP IN (SELECT TPCD FROM COMTYPE WHERE COMTYPE.GPCD = 'INTP')
      AND COMIN.WARECD LIKE CONCAT ('%', $WARECD, '%')
      AND COMIN.REMARK != ''
      AND COMIN.ITEMID LIKE CONCAT ($ITEMID,'%')
      AND MSTITEM.ITEMCG    LIKE CONCAT($ITEMCG, '%')
    ORDER BY COMIN.INDATE, COMIN.INTP, COMIN.EMPCD, COMIN.REMARK, MSTITEM.ITEMCG, COMINLOT.LOTKEY;

-- * ***************************************************************************
WHEN 'LIST_OUT_ETC' THEN

  SELECT
    COMOUT.OUTKEY, -- 출고키
    COMOUT.OUTDATE, -- 출고일자
    COMOUT.RTIME, -- 등록일시
    COMOUT.WARECD, -- 창고코드
    GPCD('WARECD', COMOUT.WARECD) AS WARENM, -- 창고명
    COMOUTLOT.ETCTP, -- 출고구분 (공통코드 ETCTP)
    GPCD('EMPCD', COMOUT.EMPCD) AS EMPNM, -- 사원
    COMOUT.REMARK,  -- 사유
    MSTITEM.ITEMCG, -- 품목유형
    MSTITEM.ITEMNM, -- 품명
    COMOUT.ITEMID, -- 품번
    MSTITEM.ITEMCD, -- 품목코드
    COMOUTLOT.LOTKEY, -- 로트번호
    COMOUTLOT.OUTQTY -- 출고수량
    FROM COMOUT
    INNER JOIN COMOUTLOT
            ON COMOUTLOT.OUTKEY = COMOUT.OUTKEY
    INNER JOIN MSTITEM
            ON MSTITEM.ITEMID = COMOUT.ITEMID
    WHERE COMOUT.OUTDATE BETWEEN $SDATE AND $EDATE
      AND COMOUT.OUTTP IN (SELECT TPCD FROM COMTYPE WHERE COMTYPE.GPCD = 'OUTTP' AND COMTYPE.REF01 = 'Y')
      AND COMOUT.WARECD LIKE CONCAT ('%', $WARECD, '%')
      AND COMOUT.REMARK != ''
      AND COMOUT.ITEMID LIKE CONCAT ($ITEMID,'%')
      AND MSTITEM.ITEMCG    LIKE CONCAT($ITEMCG, '%')
    ORDER BY COMOUT.OUTDATE, COMOUTLOT.ETCTP, COMOUT.EMPCD, COMOUT.REMARK, MSTITEM.ITEMCG, COMOUTLOT.LOTKEY;

-- * ***************************************************************************
WHEN 'ETC_IN_DEL' THEN   -- 기타입고 이력삭제

  CALL IO_ETC_IN_DEL ($LOTKEYLIST, $INKEYLIST);

-- * ***************************************************************************
WHEN 'ETC_OUT_DEL' THEN   -- 기타출고 이력삭제

  CALL IO_ETC_OUT_DEL ($LOTKEYLIST, $OUTKEYLIST);

-- * ***************************************************************************
END CASE;  END