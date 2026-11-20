CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML5000_R02(
-- *****************************************************************************
-- Comment: 외주처 판매출고
-- Create : 2026-10-12 13:21: 김영철
-- Modify : 2026-11-11 PRINT_SALOUT 추가 (거래명세서 출고부서용 출력 - TMLPRINT.SAL_1)
--          (저장소 파일이 DB 보다 오래돼서, DB 에 올라가 있던 프로시저를 기준으로 맞춤) 
-- *****************************************************************************

  IN $CUSTCD VARCHAR(20),               -- 거래처정보
  IN $ITEMID VARCHAR(20),               -- 품목ID
  IN $EMPCD VARCHAR(20),                -- 사원코드 (미사용, 파라미터 구성 유지용)
  IN $LOTKEY VARCHAR(100),              -- 로트번호
  IN $SALOUTKEY VARCHAR(20),            -- 출하번호
  IN $SDATE VARCHAR(10),                -- 지시일자
  IN $EDATE VARCHAR(10),
  IN $SALOUTGROUPKEY VARCHAR(50),       -- 지시번호
  IN $OUTTIME VARCHAR(19),              -- 출고일자
  IN $WARECD VARCHAR(100),

  IN $OUTLIST MEDIUMTEXT,               -- 거래명세서 발행을 위한 SALOUTKEY 리스트
  IN $SALODRLIST MEDIUMTEXT,            -- 수주선택 (1건)
  IN $ODRSEQLIST MEDIUMTEXT,            -- 수주상세선택 (1건)

-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$ITEMID VARCHAR(50);
  DECLARE _$SALITEM VARCHAR(50);          -- 수주 품목
  DECLARE _$LOTQTY DECIMAL(20, 8);
  DECLARE _$LOTWARE VARCHAR(100);         -- 스캔 LOT의 현재 창고

  DECLARE _$LOTCNT INT;

  DECLARE _$SALOUTKEY VARCHAR(20);
  DECLARE _$SALODRKEY VARCHAR(20);
  DECLARE _$ODRSEQ VARCHAR(100);
  DECLARE _$SALOUTGROUPKEY VARCHAR(20);
  DECLARE _$OUTLIST MEDIUMTEXT;
  DECLARE _$OPENWARE VARCHAR(100);        -- 미확정 출하의 창고

  DECLARE _$FLAG VARCHAR(10);
  DECLARE _$KEYDATE VARCHAR(10);
  DECLARE _$SEQ INT;

-- ****************************************************************************
  -- 선택한 수주 (1건)
  CALL COMSPLIT($SALODRLIST, _$SALODRKEY);
  CALL COMSPLIT($ODRSEQLIST, _$ODRSEQ);
  SET _$SALODRKEY = IFNULL(_$SALODRKEY, '');
  SET _$ODRSEQ = IFNULL(_$ODRSEQ, '');

-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'SEL_SALODR' THEN -- 수주 조회 (SALODR / SALODRD / SALOUT / SALOUTLOT 기준, MSTITEM 은 표시용)

  SELECT
      B.SALODRKEY,
      B.ODRSEQ,
      B.DLVDT,
      A.CUSTCD,
      GPCD('CUSTCD', A.CUSTCD) AS CUSTNM,
      C.ITEMID,
      C.ITEMCD,
      C.ITEMNM,
      C.ITEMSPEC,
      B.SALQTY,
      IFNULL(OUT_SUM.OUTQTY, 0) AS OUTQTY,
      IFNULL(OPEN_SUM.OPENQTY, 0) AS OPENQTY,
      IF(B.SALQTY <= IFNULL(OUT_SUM.OUTQTY, 0), 'SKYBLUE', 'WHITE') AS BACKGROUND
    FROM SALODR AS A
    INNER JOIN SALODRD AS B ON A.SALODRKEY = B.SALODRKEY
    INNER JOIN MSTITEM AS C ON B.ITEMID = C.ITEMID
    INNER JOIN MSTITEM_FACTORY AS D ON C.ITEMID = D.ITEMID
    LEFT JOIN (
        -- 수주 상세별 출고 완료 수량 (확정 출하)
        SELECT SALODRKEY, ODRSEQ, SUM(OUTQTY) AS OUTQTY
          FROM SALOUT
          WHERE OUTYN = 'Y'
          GROUP BY SALODRKEY, ODRSEQ
    ) AS OUT_SUM ON B.SALODRKEY = OUT_SUM.SALODRKEY
                AND B.ODRSEQ = OUT_SUM.ODRSEQ
    LEFT JOIN (
        -- 수주 상세별 스캔했지만 출고확정 전인 수량 (미확정 출하의 스캔 LOT)
        SELECT S.SALODRKEY, S.ODRSEQ, SUM(L.LOTQTY) AS OPENQTY
          FROM SALOUT AS S
          INNER JOIN SALOUTLOT AS L ON S.SALOUTKEY = L.SALOUTKEY
          WHERE S.OUTYN = 'N'
          GROUP BY S.SALODRKEY, S.ODRSEQ
    ) AS OPEN_SUM ON B.SALODRKEY = OPEN_SUM.SALODRKEY
                 AND B.ODRSEQ = OPEN_SUM.ODRSEQ
    WHERE B.DLVDT BETWEEN $SDATE AND $EDATE
      AND B.ITEMID LIKE CONCAT('%', $ITEMID, '%')
      AND A.CUSTCD LIKE CONCAT('%', $CUSTCD, '%')
      -- AND A.FACTORYCD = '07' -- 2공장 수주
      AND A.BDVCD = '71'
      AND D.FACTORYCD = '06' -- 1공장 품목인경우 유상사급 수주
    ORDER BY B.DLVDT, B.SALODRKEY, B.ODRSEQ, A.CUSTCD;

-- ****************************************************************************
WHEN 'LIST_SCANLOT' THEN -- 선택한 수주의 미확정(OUTYN = 'N') 출하 스캔 목록

  SELECT
      A.LOTKEY,
      A.LOTQTY AS SCANQTY,
      C.ITEMUNIT,
      A.HEATNO,
      B.WARECD,
      B.SALOUTKEY
    FROM SALOUTLOT AS A
    INNER JOIN SALOUT AS B ON A.SALOUTKEY = B.SALOUTKEY
    INNER JOIN MSTITEM AS C ON B.ITEMID = C.ITEMID
    WHERE B.SALODRKEY = _$SALODRKEY
      AND B.ODRSEQ = _$ODRSEQ
      AND B.OUTYN = 'N'
    ORDER BY A.SCANTIME, A.LOTKEY;

-- ****************************************************************************
WHEN 'SCAN_LOT' THEN -- 스캔 → SALOUT(미확정) + SALOUTLOT 생성

  IF _$SALODRKEY = '' THEN
    CALL COMERR('선택한 수주가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 스캔한 로트 정보
  SELECT ITEMID, LOTQTY, WARECD
    INTO _$ITEMID, _$LOTQTY, _$LOTWARE
    FROM COMLOT
    WHERE LOTKEY = $LOTKEY;

  IF $LOTKEY = '' OR _$ITEMID IS NULL THEN
    CALL COMERR('로트번호를 확인하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL(_$LOTQTY, 0) <= 0 THEN
    CALL COMERR('모두 사용된 로트입니다.');
    LEAVE PROC;
  END IF;

  IF _$LOTWARE <> $WARECD THEN
    CALL COMERR(CONCAT('스캔한 LOT의 창고 위치는 ', GPCD('WARECD', $WARECD), '가 아닙니다.'));
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM SALOUTLOT AS A
              INNER JOIN SALOUT AS B ON A.SALOUTKEY = B.SALOUTKEY
              WHERE A.LOTKEY = $LOTKEY
                AND B.OUTYN = 'N') THEN
    CALL COMERR('이미 스캔된 로트입니다.');
    LEAVE PROC;
  END IF;

  -- 스캔 품목과 선택한 수주 품목 비교
  SET _$SALITEM = (SELECT ITEMID FROM SALODRD
                    WHERE SALODRKEY = _$SALODRKEY
                      AND ODRSEQ = _$ODRSEQ
                    LIMIT 1);

  IF IFNULL(_$SALITEM, '') <> _$ITEMID THEN
    CALL COMERR('선택한 수주 품목에 해당하는 LOT가 아닙니다.');
    LEAVE PROC;
  END IF;

  -- 이 수주의 미확정 출하 (없으면 생성)
  SET _$SALOUTKEY = (SELECT SALOUTKEY FROM SALOUT
                      WHERE SALODRKEY = _$SALODRKEY
                        AND ODRSEQ = _$ODRSEQ
                        AND OUTYN = 'N'
                      ORDER BY SALOUTKEY
                      LIMIT 1);

  SET _$OPENWARE = (SELECT WARECD FROM SALOUT WHERE SALOUTKEY = _$SALOUTKEY);

  IF _$SALOUTKEY IS NOT NULL AND _$OPENWARE <> $WARECD THEN
    CALL COMERR(CONCAT('이미 스캔한 출고창고(', GPCD('WARECD', _$OPENWARE), ')와 다릅니다.'));
    LEAVE PROC;
  END IF;

  IF _$SALOUTKEY IS NULL THEN

    -- 출하 1건 = 수주 1건 (SALOUTGROUP 사용 안 함)
    SET _$SALOUTKEY = GETKEY('SALOUT');

    INSERT INTO SALOUT (
      SALOUTKEY, SALODRKEY, ODRSEQ, SALOUTGROUPKEY,
      SALOUTTP, SALOUTDATE, CUSTCD, ITEMID,
      WARECD, EMPCD, OUTQTY, OUTYN, OUTTIME,
      RTIME, REMP, RPRG)
    SELECT
      _$SALOUTKEY, B.SALODRKEY, B.ODRSEQ, '',
      '01', $OUTTIME, A.CUSTCD, B.ITEMID,
      $WARECD, CALLEMP(), 0, 'N', '',
      CALLTIME(), CALLEMP(), CALLPRG()
      FROM SALODR AS A
      JOIN SALODRD AS B ON A.SALODRKEY = B.SALODRKEY
      WHERE B.SALODRKEY = _$SALODRKEY
        AND B.ODRSEQ = _$ODRSEQ;

  END IF;

  INSERT INTO SALOUTLOT (
    SALOUTKEY, LOTKEY, LOTQTY, HEATNO, SCANTIME,
    RTIME, REMP, RPRG)
  SELECT
    _$SALOUTKEY, LOTKEY, LOTQTY, HEATNO, CALLTIME(),
    CALLTIME(), CALLEMP(), CALLPRG()
    FROM COMLOT
    WHERE LOTKEY = $LOTKEY;

  UPDATE SALOUT
     SET OUTQTY = (SELECT IFNULL(SUM(LOTQTY), 0) FROM SALOUTLOT WHERE SALOUTKEY = _$SALOUTKEY)
       , MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG()
   WHERE SALOUTKEY = _$SALOUTKEY;

  SELECT
      A.LOTKEY,
      A.LOTQTY AS SCANQTY,
      C.ITEMUNIT,
      A.HEATNO,
      B.WARECD,
      B.SALOUTKEY
    FROM SALOUTLOT AS A
    INNER JOIN SALOUT AS B ON A.SALOUTKEY = B.SALOUTKEY
    INNER JOIN MSTITEM AS C ON B.ITEMID = C.ITEMID
    WHERE A.SALOUTKEY = _$SALOUTKEY
    ORDER BY A.SCANTIME, A.LOTKEY;

-- ****************************************************************************
WHEN 'DEL_SCANLOT' THEN -- 미확정 출하에서 스캔 LOT 삭제

  SET _$SALOUTKEY = (SELECT A.SALOUTKEY FROM SALOUTLOT AS A
                      INNER JOIN SALOUT AS B ON A.SALOUTKEY = B.SALOUTKEY
                      WHERE A.LOTKEY = $LOTKEY
                        AND B.OUTYN = 'N'
                      LIMIT 1);

  IF _$SALOUTKEY IS NULL THEN
    CALL COMERR('삭제할 스캔 로트가 없습니다.');
    LEAVE PROC;
  END IF;

  DELETE FROM SALOUTLOT WHERE SALOUTKEY = _$SALOUTKEY AND LOTKEY = $LOTKEY;

  IF EXISTS (SELECT 1 FROM SALOUTLOT WHERE SALOUTKEY = _$SALOUTKEY) THEN
    UPDATE SALOUT
       SET OUTQTY = (SELECT IFNULL(SUM(LOTQTY), 0) FROM SALOUTLOT WHERE SALOUTKEY = _$SALOUTKEY)
         , MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG()
     WHERE SALOUTKEY = _$SALOUTKEY;
  ELSE
    -- 남은 스캔이 없으면 미확정 출하 삭제
    DELETE FROM SALOUT WHERE SALOUTKEY = _$SALOUTKEY;
  END IF;

  SELECT
      A.LOTKEY,
      A.LOTQTY AS SCANQTY,
      C.ITEMUNIT,
      A.HEATNO,
      B.WARECD,
      B.SALOUTKEY
    FROM SALOUTLOT AS A
    INNER JOIN SALOUT AS B ON A.SALOUTKEY = B.SALOUTKEY
    INNER JOIN MSTITEM AS C ON B.ITEMID = C.ITEMID
    WHERE A.SALOUTKEY = _$SALOUTKEY
    ORDER BY A.SCANTIME, A.LOTKEY;

-- ****************************************************************************
WHEN 'MAKE_SALOUT' THEN -- 출고확정: OUTYN = 'Y' + 재고 출고/차감

  IF $OUTTIME = '' THEN
    CALL COMERR('출고일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  SET _$SALOUTKEY = (SELECT SALOUTKEY FROM SALOUT
                      WHERE SALODRKEY = _$SALODRKEY
                        AND ODRSEQ = _$ODRSEQ
                        AND OUTYN = 'N'
                      ORDER BY SALOUTKEY
                      LIMIT 1);

  IF _$SALOUTKEY IS NULL THEN
    CALL COMERR('스캔한 재고가 없습니다.');
    LEAVE PROC;
  END IF;

  -- 재고 검증·출고·차감·출고확정은 IO 프로시저에서 처리
  CALL IO_SALOUT_OSC(_$SALOUTKEY, $OUTTIME);

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  SELECT _$SALOUTKEY AS SALOUTKEY;

-- ****************************************************************************
WHEN 'LIST_SALOUT_HISTORY' THEN -- 출하 이력 (확정 출하 1건 = 1행)

  SELECT
      B.SALOUTKEY,
      B.OUTTIME,
      GPCD('CUSTCD', B.CUSTCD) AS CUSTNM,
      I.ITEMNM,
      B.OUTQTY,
      (SELECT COUNT(*) FROM SALOUTLOT AS C WHERE C.SALOUTKEY = B.SALOUTKEY) AS LOTCNT
    FROM SALOUT AS B
    INNER JOIN MSTITEM AS I ON B.ITEMID = I.ITEMID
    WHERE B.OUTYN = 'Y'
      AND B.SALOUTTP = '01'
      AND IF($SALOUTKEY = '',
             B.OUTTIME BETWEEN $SDATE AND $EDATE,
             B.SALOUTKEY = $SALOUTKEY)
      AND EXISTS (SELECT 1 FROM COMOUT AS O WHERE O.SALOUTKEY = B.SALOUTKEY AND O.OUTTP = '31') -- 이 화면(유상사급 판매출고) 출하만
    ORDER BY B.OUTTIME DESC, B.SALOUTKEY DESC;

-- ****************************************************************************
WHEN 'LIST_SALOUTLOT_HISTORY' THEN -- 출하 이력 상세 (LOT)

  SELECT
      B.SALOUTKEY,
      C.LOTKEY, C.LOTQTY,
      C.HEATNO, I.EONO, I.ITEMCD, I.ITEMNM, I.ITEMSPEC
    FROM SALOUT AS B
    JOIN MSTITEM AS I ON B.ITEMID = I.ITEMID
    JOIN SALOUTLOT AS C ON B.SALOUTKEY = C.SALOUTKEY
    JOIN COMLOT AS D ON C.LOTKEY = D.LOTKEY
    WHERE B.SALOUTKEY = $SALOUTKEY
      AND B.OUTYN = 'Y';

-- ****************************************************************************
WHEN 'PRINT' THEN -- 거래명세서 발행 (출하 1건)

  IF $OUTLIST = 'NO' THEN
    SELECT CONCAT($SALOUTKEY, '»') AS OUTLIST
      FROM SALOUT
      WHERE SALOUTKEY = $SALOUTKEY
        AND OUTYN = 'Y';
  ELSE
    CALL TMLPRINT('SALOUT_LIST', '', '', $OUTLIST);
  END IF;

-- ****************************************************************************
WHEN 'DEL_SALOUT' THEN -- 출하취소 (확정 출하 1건): 재고 복원 후 출하 삭제

  -- 재고 복원·출고이력 삭제·출하 삭제는 IO 프로시저에서 처리
  CALL IO_SALOUT_OSC_DEL($SALOUTKEY);


-- ****************************************************************************
WHEN 'PRINT_SALOUT' THEN -- 거래명세서 (출고부서용) : 출하 1건 (TMLPRINT.SAL_1)  2026-11-11

  IF IFNULL($SALOUTKEY, '') = '' THEN
    CALL COMERR('출하번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM SALOUT WHERE SALOUT.SALOUTKEY = $SALOUTKEY AND SALOUT.OUTYN = 'Y') THEN
    CALL COMERR('출고확정된 출하가 아닙니다.');
    LEAVE PROC;
  END IF;

  -- [0] 공급자 (S&S INC 2공장, 사업장 71)
  SELECT
      TRIM(REPLACE(MSTBDV.BDVBNM_PRT, '2공장', '')) AS BDVNM
    , MSTBDV.BDVNMENG AS BNAME
    , MSTBDV.BDVREGNO AS BNUM
    , MSTBDV.ADDR AS ADDR
    , MSTBDV.REPRETEL AS TEL
    , MSTBDV.FAXNO AS FAX
    , MSTBDV.INDTYPE AS ITYPE
    , MSTBDV.INDKIND AS IKIND
  FROM MSTBDV
  WHERE MSTBDV.BDVCD = '71';

  -- [1] 공급받는자 (납품처) + 거래일자·담당자
  SELECT
      IFNULL(MSTCUST.CUSTNM_PRT, MSTCUST.CUSTNM) AS COMPNAME
    , MSTCUST.PRESIDENT AS PRES
    , MSTCUST.REGBUSSNUM AS BUSNM
    , MSTCUST.ADDR_PRT AS ADDR
    , MSTCUST.REPRETEL AS TEL
    , MSTCUST.CUSTFAX AS FAX
    , MSTCUST.BIZTYPE_PRT AS DTYPE
    , MSTCUST.BIZKIND_PRT AS DKIND
    , SALOUT.SALOUTDATE AS SALTIME
    , IFNULL(GPCD('EMPCD', SALOUT.EMPCD), '') AS EMPNM
  FROM SALOUT
  LEFT JOIN MSTCUST ON MSTCUST.CUSTCD = SALOUT.CUSTCD
  WHERE SALOUT.SALOUTKEY = $SALOUTKEY;

  -- [2] 품목 (LOT 1개 = 1줄)
  SELECT
      MSTITEM.ITEMCD AS ITEMCD
    , MSTITEM.ITEMNM AS ITEMNM
    , MSTITEM.ITEMSPEC AS ITEMSPEC
    , FORMAT(SALOUTLOT.LOTQTY, 0) AS OUTQTY
    , '' AS BOX
    , '' AS BOXNM
    , IFNULL(SALOUTLOT.REMARK, '') AS REMARK
  FROM SALOUT
  INNER JOIN SALOUTLOT ON SALOUTLOT.SALOUTKEY = SALOUT.SALOUTKEY
  INNER JOIN MSTITEM ON MSTITEM.ITEMID = SALOUT.ITEMID
  WHERE SALOUT.SALOUTKEY = $SALOUTKEY
  ORDER BY SALOUTLOT.LOTKEY;

  -- [3] 총 수량·출하번호
  SELECT
      FORMAT(IFNULL(SUM(SALOUT.OUTQTY), 0), 0) AS SUMQTY
    , $SALOUTKEY AS GROUPKEY
    , '' AS REMARK
  FROM SALOUT
  WHERE SALOUT.SALOUTKEY = $SALOUTKEY;

-- ****************************************************************************
END CASE; END
