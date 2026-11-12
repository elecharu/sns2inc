CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TQM3001_R01(
-- *****************************************************************************
-- Comment: 협력사 클레임등록 (품질팀) - "CLAIM 통보서" (공문서 + 산출내역서) 양식
--          ) 클레임 1건 = 협력사(귀책처) × 발생월. 발생기간은 그 달 1일~말일
--          ) 귀책처 = 판정한 로트를 만든 외주실적(OSCRSTLOT → OSCRST.CUSTCD)의 거래처,
--            외주 로트가 아니면 불량구분(JUDGEBADTP) 코드 (TQM3001_S01 협력사 불량조회와 같은 기준)
--          ) 대상 판정: 판정유형 불량(BAD), 불량구분 1공장(FAC1)·외주(OSC)
--          ) LIST     : 발생월의 귀책처 목록 (불량수량, 등록한 클레임)
--          ) INFO_HEAD: 클레임 머리글. 등록 전이면 기본값 (예정일자 = 작성일 오늘, 확정일자 +7일, 제목 자동)
--          ) LIST_ITEM: 품목별 손실비용. 수량 기본값 = 발생월 판정수량 합, 발생내용 기본값 = 판정 발생내용(BADCD) 이름
--                       등록한 클레임에 없는 불량 품목은 뒤에 붙여 보여준다 (NEWYN = 'Y')
--          ) SAVE     : 머리글 + 품목 저장. 처음 저장할 때 클레임키 = 문서번호 SSI-yy-mm-NNN 을 매긴다
--                       (SSI 고정, yy-mm = 예정일자(= 작성일)의 연·월, NNN = 그 연·월의 순번)
--          ) DELETE   : 클레임 삭제
--          ) PRINT    : CLAIM 통보서 (리포트 TQM3001.exe R01, 1장 공문서 + 2장 산출내역서). 결과셋 1 머리글, 2 품목
--          ) 발생 손실 비용만 다룬다. 산출내역서의 제반비용 산출 표·이의제기·CLAIM 비용(예정/확정)은
--            출력물에서 빈칸으로 둔다 (2026-11-10 사용자 지시)
-- Create: 2026-11-10
-- Modify:
-- *****************************************************************************
  IN $SMONTH VARCHAR(10),             -- 발생월 (YYYY-MM)
  IN $CUSTCD VARCHAR(100),            -- 귀책처
  IN $PLANDATE VARCHAR(10),           -- 예정일자
  IN $CONFDATE VARCHAR(10),           -- 확정일자
  IN $EMPCD VARCHAR(100),             -- 담당
  IN $RECVNM VARCHAR(200),            -- 수신
  IN $REFNM VARCHAR(200),             -- 참조
  IN $TITLE VARCHAR(500),             -- 제목
  IN $REMARK VARCHAR(1000),           -- 비고
  IN $ITEMID_LIST MEDIUMTEXT,         -- 품목ID 목록
  IN $BADCONT_LIST MEDIUMTEXT,        -- 발생내용 목록
  IN $CLAIMQTY_LIST MEDIUMTEXT,       -- 수량 목록
  IN $INPRICE_LIST MEDIUMTEXT,        -- 입고단가 목록
  IN $MFGPRICE_LIST MEDIUMTEXT,       -- 제조단가 목록
  IN $SALEPRICE_LIST MEDIUMTEXT,      -- 판매단가 목록
  IN $ETCAMT_LIST MEDIUMTEXT,         -- 품목 제반비용 목록
  IN $ITEMREMARK_LIST MEDIUMTEXT,     -- 품목 비고 목록
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$MSDATE VARCHAR(10);       -- 발생월 1일
  DECLARE _$MEDATE VARCHAR(10);       -- 발생월 말일
  DECLARE _$CLAIMKEY VARCHAR(100);
  DECLARE _$DOCPREFIX VARCHAR(20);
  DECLARE _$TITLE VARCHAR(500);
  DECLARE _$ITEMCNT INT;
  DECLARE _$SEQ INT;
  DECLARE _$ITEMID_LIST MEDIUMTEXT;
  DECLARE _$BADCONT_LIST MEDIUMTEXT;
  DECLARE _$CLAIMQTY_LIST MEDIUMTEXT;
  DECLARE _$INPRICE_LIST MEDIUMTEXT;
  DECLARE _$MFGPRICE_LIST MEDIUMTEXT;
  DECLARE _$SALEPRICE_LIST MEDIUMTEXT;
  DECLARE _$ETCAMT_LIST MEDIUMTEXT;
  DECLARE _$ITEMREMARK_LIST MEDIUMTEXT;
  DECLARE _$ITEMID VARCHAR(100);
  DECLARE _$BADCONT VARCHAR(1000);
  DECLARE _$CLAIMQTY_TXT VARCHAR(100);
  DECLARE _$INPRICE_TXT VARCHAR(100);
  DECLARE _$MFGPRICE_TXT VARCHAR(100);
  DECLARE _$SALEPRICE_TXT VARCHAR(100);
  DECLARE _$ETCAMT_TXT VARCHAR(100);
  DECLARE _$ITEMREMARK VARCHAR(1000);
  DECLARE _$CLAIMQTY DECIMAL(20, 8);
  DECLARE _$INPRICE DECIMAL(20, 8);
  DECLARE _$MFGPRICE DECIMAL(20, 8);
  DECLARE _$SALEPRICE DECIMAL(20, 8);
  DECLARE _$ETCAMT DECIMAL(20, 8);
-- *****************************************************************************
  IF $CALLTYPE IN ('LIST', 'INFO_HEAD', 'LIST_ITEM', 'SAVE', 'DELETE', 'PRINT') AND IFNULL($SMONTH, '') = '' THEN
    CALL COMERR('발생월을 입력하세요.');
    LEAVE PROC;
  END IF;

  SET _$MSDATE = CONCAT(LEFT($SMONTH, 7), '-01');
  SET _$MEDATE = DATE_FORMAT(LAST_DAY(_$MSDATE), '%Y-%m-%d');

  -- 등록한 클레임 (없으면 '')
  SET _$CLAIMKEY = IFNULL((SELECT TQMCLAIM.CLAIMKEY
                             FROM TQMCLAIM
                             WHERE TQMCLAIM.CLAIMMONTH = LEFT($SMONTH, 7)
                               AND TQMCLAIM.CUSTCD = $CUSTCD), '');

  -- 발생월 불량 판정 (1공장·외주) + 귀책처
  IF $CALLTYPE IN ('LIST', 'INFO_HEAD', 'LIST_ITEM') THEN
    DROP TEMPORARY TABLE IF EXISTS TEMP_CLAIM_JUDGE;
    CREATE TEMPORARY TABLE TEMP_CLAIM_JUDGE AS
      SELECT
          IF(IFNULL(LOT_OSC.CUSTCD, '') <> '', LOT_OSC.CUSTCD, TQMJUDGE.JUDGEBADTP) AS CUSTCD
        , TQMJUDGE.ITEMID
        , TQMJUDGE.BADCD
        , TQMJUDGE.JUDGEQTY
      FROM TQMJUDGE
      LEFT JOIN (
                  -- 로트를 만든 외주실적의 거래처 (로트당 하나)
                  SELECT
                      OSCRSTLOT.LOTKEY
                    , MAX(OSCRST.CUSTCD) AS CUSTCD
                  FROM OSCRSTLOT
                  INNER JOIN OSCRST
                    ON OSCRST.OSCRSTKEY = OSCRSTLOT.OSCRSTKEY
                  GROUP BY OSCRSTLOT.LOTKEY
                ) AS LOT_OSC
        ON LOT_OSC.LOTKEY = TQMJUDGE.LOTKEY
      WHERE TQMJUDGE.JUDGEDATE BETWEEN _$MSDATE AND _$MEDATE
        AND TQMJUDGE.JUDGETP = 'BAD'
        AND TQMJUDGE.JUDGEBADTP IN ('FAC1', 'OSC');

    -- 선택한 귀책처의 품목별 판정수량·발생내용
    DROP TEMPORARY TABLE IF EXISTS TEMP_CLAIM_ITEM;
    CREATE TEMPORARY TABLE TEMP_CLAIM_ITEM AS
      SELECT
          TEMP_CLAIM_JUDGE.ITEMID
        , IFNULL(GROUP_CONCAT(DISTINCT MSTBAD.BADNM ORDER BY MSTBAD.BADNM SEPARATOR ', '), '') AS BADCONT
        , SUM(TEMP_CLAIM_JUDGE.JUDGEQTY) AS JUDGEQTY
      FROM TEMP_CLAIM_JUDGE
      LEFT JOIN MSTBAD
        ON MSTBAD.BADCD = TEMP_CLAIM_JUDGE.BADCD
      WHERE TEMP_CLAIM_JUDGE.CUSTCD = IFNULL($CUSTCD, '')
      GROUP BY TEMP_CLAIM_JUDGE.ITEMID;
  END IF;
-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST' THEN  -- 발생월 귀책처 목록 (grid1)

  DROP TEMPORARY TABLE IF EXISTS TEMP_CLAIM_CUST;
  CREATE TEMPORARY TABLE TEMP_CLAIM_CUST (
      CUSTCD VARCHAR(100) NOT NULL PRIMARY KEY
    , BADQTY DECIMAL(20, 8) NOT NULL DEFAULT 0
  );

  INSERT INTO TEMP_CLAIM_CUST (CUSTCD, BADQTY)
    SELECT
        TEMP_CLAIM_JUDGE.CUSTCD
      , SUM(TEMP_CLAIM_JUDGE.JUDGEQTY)
    FROM TEMP_CLAIM_JUDGE
    GROUP BY TEMP_CLAIM_JUDGE.CUSTCD;

  -- 불량 판정이 지워졌어도 등록한 클레임은 보이게
  INSERT IGNORE INTO TEMP_CLAIM_CUST (CUSTCD, BADQTY)
    SELECT
        TQMCLAIM.CUSTCD
      , 0
    FROM TQMCLAIM
    WHERE TQMCLAIM.CLAIMMONTH = LEFT($SMONTH, 7);

  SELECT
      LEFT($SMONTH, 7) AS CLAIMMONTH
    , TEMP_CLAIM_CUST.CUSTCD
    , IFNULL(MSTCUST.CUSTNM, IFNULL(NULLIF(GPCD('JUDGEBADTP', TEMP_CLAIM_CUST.CUSTCD), ''), TEMP_CLAIM_CUST.CUSTCD)) AS CUSTNM
    , TEMP_CLAIM_CUST.BADQTY
    , IF(TQMCLAIM.CLAIMKEY IS NULL, 'N', 'Y') AS SAVEYN
    , IFNULL(TQMCLAIM.CLAIMKEY, '') AS CLAIMKEY
    , IFNULL(TQMCLAIM.PLANDATE, '') AS PLANDATE
    , TQMCLAIM.TOTAMT
  FROM TEMP_CLAIM_CUST
  LEFT JOIN TQMCLAIM
    ON TQMCLAIM.CLAIMMONTH = LEFT($SMONTH, 7)
   AND TQMCLAIM.CUSTCD = TEMP_CLAIM_CUST.CUSTCD
  LEFT JOIN MSTCUST
    ON MSTCUST.CUSTCD = TEMP_CLAIM_CUST.CUSTCD
  ORDER BY IF(TEMP_CLAIM_CUST.CUSTCD = 'FAC1', 0, 1), CUSTNM;

-- ****************************************************************************
WHEN 'INFO_HEAD' THEN  -- 클레임 머리글 (등록 전이면 기본값)

  IF _$CLAIMKEY <> '' THEN
    SELECT
        TQMCLAIM.CLAIMKEY
      , TQMCLAIM.PLANDATE
      , TQMCLAIM.CONFDATE
      , TQMCLAIM.EMPCD
      , TQMCLAIM.RECVNM
      , TQMCLAIM.REFNM
      , TQMCLAIM.TITLE
      , TQMCLAIM.REMARK
    FROM TQMCLAIM
    WHERE TQMCLAIM.CLAIMKEY = _$CLAIMKEY;
  ELSE
    -- 제목 기본값: 첫 품목 "품번 품명 발생내용 외 N件"
    SET _$TITLE = IFNULL((SELECT
                              TRIM(CONCAT(IFNULL(MSTITEM.ITEMCD, ''), ' ', IFNULL(MSTITEM.ITEMNM, ''), ' ', TEMP_CLAIM_ITEM.BADCONT))
                            FROM TEMP_CLAIM_ITEM
                            LEFT JOIN MSTITEM
                              ON MSTITEM.ITEMID = TEMP_CLAIM_ITEM.ITEMID
                            ORDER BY MSTITEM.ITEMCD
                            LIMIT 1), '');
    SET _$ITEMCNT = (SELECT COUNT(*) FROM TEMP_CLAIM_ITEM);

    SELECT
        '' AS CLAIMKEY
      , DATE_FORMAT(CALLTIME(), '%Y-%m-%d') AS PLANDATE                              -- 예정일자: 당일
      , DATE_FORMAT(DATE_ADD(CALLTIME(), INTERVAL 7 DAY), '%Y-%m-%d') AS CONFDATE   -- 확정일자: 당일 + 7일
      , '' AS EMPCD          -- 담당 기본값(로그인 사원 ItsPage.EMPCD)은 화면에서 넣는다. CALLEMP() 는 사원코드가 아니라 로그인 ID
      , IFNULL((SELECT MSTCUST.CUSTNM FROM MSTCUST WHERE MSTCUST.CUSTCD = $CUSTCD)
             , IFNULL(NULLIF(GPCD('JUDGEBADTP', $CUSTCD), ''), $CUSTCD)) AS RECVNM
      , '품질부서장 / 영업부서장' AS REFNM
      , CONCAT(_$TITLE, IF(_$ITEMCNT > 1, CONCAT(' 외 ', _$ITEMCNT - 1, '件'), '')) AS TITLE
      , '' AS REMARK;
  END IF;

-- ****************************************************************************
WHEN 'LIST_ITEM' THEN  -- 품목별 손실비용 (grid2)

  DROP TEMPORARY TABLE IF EXISTS TEMP_CLAIM_ROW;
  CREATE TEMPORARY TABLE TEMP_CLAIM_ROW (
      SORTNO INT NOT NULL
    , CLAIMSEQ INT NOT NULL
    , ITEMID INT NOT NULL
    , BADCONT VARCHAR(1000) NOT NULL DEFAULT ''
    , JUDGEQTY DECIMAL(20, 8) NULL
    , CLAIMQTY DECIMAL(20, 8) NOT NULL DEFAULT 0
    , INPRICE DECIMAL(20, 8) NOT NULL DEFAULT 0
    , MFGPRICE DECIMAL(20, 8) NOT NULL DEFAULT 0
    , SALEPRICE DECIMAL(20, 8) NOT NULL DEFAULT 0
    , ETCAMT DECIMAL(20, 8) NOT NULL DEFAULT 0
    , CLAIMAMT DECIMAL(20, 8) NOT NULL DEFAULT 0
    , REMARK VARCHAR(1000) NOT NULL DEFAULT ''
    , NEWYN VARCHAR(1) NOT NULL DEFAULT 'N'
  );

  -- 1. 등록한 품목
  INSERT INTO TEMP_CLAIM_ROW (SORTNO, CLAIMSEQ, ITEMID, BADCONT, JUDGEQTY, CLAIMQTY, INPRICE, MFGPRICE, SALEPRICE, ETCAMT, CLAIMAMT, REMARK, NEWYN)
    SELECT
        0
      , TQMCLAIMD.CLAIMSEQ
      , TQMCLAIMD.ITEMID
      , TQMCLAIMD.BADCONT
      , TEMP_CLAIM_ITEM.JUDGEQTY
      , TQMCLAIMD.CLAIMQTY
      , TQMCLAIMD.INPRICE
      , TQMCLAIMD.MFGPRICE
      , TQMCLAIMD.SALEPRICE
      , TQMCLAIMD.ETCAMT
      , TQMCLAIMD.CLAIMAMT
      , TQMCLAIMD.REMARK
      , 'N'
    FROM TQMCLAIMD
    LEFT JOIN TEMP_CLAIM_ITEM
      ON TEMP_CLAIM_ITEM.ITEMID = TQMCLAIMD.ITEMID
    WHERE TQMCLAIMD.CLAIMKEY = _$CLAIMKEY;

  -- 2. 판정은 있는데 클레임에 없는 품목 (등록 전이면 전부)
  INSERT INTO TEMP_CLAIM_ROW (SORTNO, CLAIMSEQ, ITEMID, BADCONT, JUDGEQTY, CLAIMQTY, INPRICE, MFGPRICE, SALEPRICE, ETCAMT, CLAIMAMT, REMARK, NEWYN)
    SELECT
        1
      , 0
      , TEMP_CLAIM_ITEM.ITEMID
      , TEMP_CLAIM_ITEM.BADCONT
      , TEMP_CLAIM_ITEM.JUDGEQTY
      , TEMP_CLAIM_ITEM.JUDGEQTY
      , 0
      , 0
      , 0
      , 0
      , 0
      , ''
      , IF(_$CLAIMKEY = '', 'N', 'Y')
    FROM TEMP_CLAIM_ITEM
    WHERE NOT EXISTS (SELECT TQMCLAIMD.ITEMID
                        FROM TQMCLAIMD
                        WHERE TQMCLAIMD.CLAIMKEY = _$CLAIMKEY
                          AND TQMCLAIMD.ITEMID = TEMP_CLAIM_ITEM.ITEMID);

  SELECT
      TEMP_CLAIM_ROW.CLAIMSEQ
    , CAST(TEMP_CLAIM_ROW.ITEMID AS CHAR) AS ITEMID
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , IFNULL(MSTITEM.ITEMNM, '') AS ITEMNM
    , TEMP_CLAIM_ROW.BADCONT
    , TEMP_CLAIM_ROW.JUDGEQTY
    , TEMP_CLAIM_ROW.CLAIMQTY
    , TEMP_CLAIM_ROW.INPRICE
    , TEMP_CLAIM_ROW.MFGPRICE
    , TEMP_CLAIM_ROW.SALEPRICE
    , TEMP_CLAIM_ROW.ETCAMT
    , TEMP_CLAIM_ROW.CLAIMAMT
    , TEMP_CLAIM_ROW.REMARK
    , TEMP_CLAIM_ROW.NEWYN
    , IF(TEMP_CLAIM_ROW.NEWYN = 'Y', '#FFF2CC', '') AS BACKGROUND  -- 등록 뒤 새로 생긴 불량 품목
  FROM TEMP_CLAIM_ROW
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = TEMP_CLAIM_ROW.ITEMID
  ORDER BY TEMP_CLAIM_ROW.SORTNO, TEMP_CLAIM_ROW.CLAIMSEQ, MSTITEM.ITEMCD;

-- ****************************************************************************
WHEN 'SAVE' THEN  -- 머리글 + 품목 저장

  IF IFNULL($CUSTCD, '') = '' THEN
    CALL COMERR('협력사를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($PLANDATE, '') = '' THEN
    CALL COMERR('예정일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($ITEMID_LIST, '') = '' THEN
    CALL COMERR('저장할 품목이 없습니다.');
    LEAVE PROC;
  END IF;

  -- 1. 품목 확인 (쓰기 전에 전부 확인)
  SET _$ITEMID_LIST = $ITEMID_LIST;
  SET _$CLAIMQTY_LIST = $CLAIMQTY_LIST;
  SET _$INPRICE_LIST = $INPRICE_LIST;
  SET _$MFGPRICE_LIST = $MFGPRICE_LIST;
  SET _$SALEPRICE_LIST = $SALEPRICE_LIST;
  SET _$ETCAMT_LIST = $ETCAMT_LIST;

  WHILE LENGTH(_$ITEMID_LIST) > 0 DO
    CALL COMSPLIT(_$ITEMID_LIST, _$ITEMID);
    CALL COMSPLIT(_$CLAIMQTY_LIST, _$CLAIMQTY_TXT);
    CALL COMSPLIT(_$INPRICE_LIST, _$INPRICE_TXT);
    CALL COMSPLIT(_$MFGPRICE_LIST, _$MFGPRICE_TXT);
    CALL COMSPLIT(_$SALEPRICE_LIST, _$SALEPRICE_TXT);
    CALL COMSPLIT(_$ETCAMT_LIST, _$ETCAMT_TXT);
    SET _$CLAIMQTY = CAST(IF(IFNULL(_$CLAIMQTY_TXT, '') = '', '0', _$CLAIMQTY_TXT) AS DECIMAL(20, 8));
    SET _$INPRICE = CAST(IF(IFNULL(_$INPRICE_TXT, '') = '', '0', _$INPRICE_TXT) AS DECIMAL(20, 8));
    SET _$MFGPRICE = CAST(IF(IFNULL(_$MFGPRICE_TXT, '') = '', '0', _$MFGPRICE_TXT) AS DECIMAL(20, 8));
    SET _$SALEPRICE = CAST(IF(IFNULL(_$SALEPRICE_TXT, '') = '', '0', _$SALEPRICE_TXT) AS DECIMAL(20, 8));
    SET _$ETCAMT = CAST(IF(IFNULL(_$ETCAMT_TXT, '') = '', '0', _$ETCAMT_TXT) AS DECIMAL(20, 8));

    IF IFNULL(_$ITEMID, '') = '' THEN
      CALL COMERR('품목이 없는 줄이 있습니다.');
      LEAVE PROC;
    END IF;

    IF _$CLAIMQTY < 0 OR _$INPRICE < 0 OR _$MFGPRICE < 0 OR _$SALEPRICE < 0 OR _$ETCAMT < 0 THEN
      CALL COMERR(CONCAT('수량·단가·제반비용은 0 이상이어야 합니다.', '\n- 품목ID: ', _$ITEMID));
      LEAVE PROC;
    END IF;

    -- 합계금액에 쓸 단가가 하나로 정해져야 한다
    IF (_$INPRICE > 0) + (_$MFGPRICE > 0) + (_$SALEPRICE > 0) > 1 THEN
      CALL COMERR(CONCAT('입고·제조·판매단가 중 하나만 입력하세요.', '\n- 품목ID: ', _$ITEMID));
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 머리글 (처음 저장이면 클레임키 = 문서번호 SSI-yy-mm-NNN, 예정일자 연·월의 다음 순번)
  IF _$CLAIMKEY = '' THEN
    SET _$DOCPREFIX = CONCAT('SSI-', DATE_FORMAT($PLANDATE, '%y-%m'), '-');
    SET _$CLAIMKEY = CONCAT(_$DOCPREFIX
                          , LPAD(IFNULL((SELECT MAX(CAST(SUBSTRING(TQMCLAIM.CLAIMKEY, LENGTH(_$DOCPREFIX) + 1) AS UNSIGNED))
                                           FROM TQMCLAIM
                                           WHERE TQMCLAIM.CLAIMKEY LIKE CONCAT(_$DOCPREFIX, '%')), 0) + 1, 3, '0'));

    INSERT INTO TQMCLAIM (
        CLAIMKEY
      , CLAIMMONTH
      , CUSTCD
      , PLANDATE
      , CONFDATE
      , EMPCD
      , RECVNM
      , REFNM
      , TITLE
      , REMARK
      , RTIME, REMP, RPRG)
    VALUES (
        _$CLAIMKEY
      , LEFT($SMONTH, 7)
      , $CUSTCD
      , $PLANDATE
      , IFNULL($CONFDATE, '')
      , IFNULL($EMPCD, '')
      , IFNULL($RECVNM, '')
      , IFNULL($REFNM, '')
      , IFNULL($TITLE, '')
      , IFNULL($REMARK, '')
      , CALLTIME(), CALLEMP(), CALLPRG()
    );
  ELSE
    UPDATE TQMCLAIM
      SET PLANDATE = $PLANDATE
        , CONFDATE = IFNULL($CONFDATE, '')
        , EMPCD = IFNULL($EMPCD, '')
        , RECVNM = IFNULL($RECVNM, '')
        , REFNM = IFNULL($REFNM, '')
        , TITLE = IFNULL($TITLE, '')
        , REMARK = IFNULL($REMARK, '')
        , MTIME = CALLTIME()
        , MEMP = CALLEMP()
        , MPRG = CALLPRG()
      WHERE TQMCLAIM.CLAIMKEY = _$CLAIMKEY;
  END IF;

  -- 3. 품목: 화면 순서대로 다시 넣는다 (순번 = NO)
  DELETE FROM TQMCLAIMD WHERE TQMCLAIMD.CLAIMKEY = _$CLAIMKEY;

  SET _$ITEMID_LIST = $ITEMID_LIST;
  SET _$BADCONT_LIST = $BADCONT_LIST;
  SET _$CLAIMQTY_LIST = $CLAIMQTY_LIST;
  SET _$INPRICE_LIST = $INPRICE_LIST;
  SET _$MFGPRICE_LIST = $MFGPRICE_LIST;
  SET _$SALEPRICE_LIST = $SALEPRICE_LIST;
  SET _$ETCAMT_LIST = $ETCAMT_LIST;
  SET _$ITEMREMARK_LIST = $ITEMREMARK_LIST;
  SET _$SEQ = 0;

  WHILE LENGTH(_$ITEMID_LIST) > 0 DO
    CALL COMSPLIT(_$ITEMID_LIST, _$ITEMID);
    CALL COMSPLIT(_$BADCONT_LIST, _$BADCONT);
    CALL COMSPLIT(_$CLAIMQTY_LIST, _$CLAIMQTY_TXT);
    CALL COMSPLIT(_$INPRICE_LIST, _$INPRICE_TXT);
    CALL COMSPLIT(_$MFGPRICE_LIST, _$MFGPRICE_TXT);
    CALL COMSPLIT(_$SALEPRICE_LIST, _$SALEPRICE_TXT);
    CALL COMSPLIT(_$ETCAMT_LIST, _$ETCAMT_TXT);
    CALL COMSPLIT(_$ITEMREMARK_LIST, _$ITEMREMARK);
    SET _$CLAIMQTY = CAST(IF(IFNULL(_$CLAIMQTY_TXT, '') = '', '0', _$CLAIMQTY_TXT) AS DECIMAL(20, 8));
    SET _$INPRICE = CAST(IF(IFNULL(_$INPRICE_TXT, '') = '', '0', _$INPRICE_TXT) AS DECIMAL(20, 8));
    SET _$MFGPRICE = CAST(IF(IFNULL(_$MFGPRICE_TXT, '') = '', '0', _$MFGPRICE_TXT) AS DECIMAL(20, 8));
    SET _$SALEPRICE = CAST(IF(IFNULL(_$SALEPRICE_TXT, '') = '', '0', _$SALEPRICE_TXT) AS DECIMAL(20, 8));
    SET _$ETCAMT = CAST(IF(IFNULL(_$ETCAMT_TXT, '') = '', '0', _$ETCAMT_TXT) AS DECIMAL(20, 8));
    SET _$SEQ = _$SEQ + 1;

    INSERT INTO TQMCLAIMD (
        CLAIMKEY
      , CLAIMSEQ
      , ITEMID
      , BADCONT
      , CLAIMQTY
      , INPRICE
      , MFGPRICE
      , SALEPRICE
      , ETCAMT
      , CLAIMAMT
      , REMARK
      , RTIME, REMP, RPRG)
    VALUES (
        _$CLAIMKEY
      , _$SEQ
      , _$ITEMID
      , IFNULL(_$BADCONT, '')
      , _$CLAIMQTY
      , _$INPRICE
      , _$MFGPRICE
      , _$SALEPRICE
      , _$ETCAMT
      , _$CLAIMQTY * (_$INPRICE + _$MFGPRICE + _$SALEPRICE) + _$ETCAMT  -- 단가는 하나만 입력되어 있다
      , IFNULL(_$ITEMREMARK, '')
      , CALLTIME(), CALLEMP(), CALLPRG()
    );
  END WHILE;

  -- 4. 발생 손실 비용 합계
  UPDATE TQMCLAIM
    SET TOTAMT = IFNULL((SELECT SUM(TQMCLAIMD.CLAIMAMT)
                           FROM TQMCLAIMD
                           WHERE TQMCLAIMD.CLAIMKEY = _$CLAIMKEY), 0)
    WHERE TQMCLAIM.CLAIMKEY = _$CLAIMKEY;

  SELECT _$CLAIMKEY AS CLAIMKEY;

-- ****************************************************************************
WHEN 'DELETE' THEN  -- 클레임 삭제

  IF _$CLAIMKEY = '' THEN
    CALL COMERR('등록한 클레임이 없습니다.');
    LEAVE PROC;
  END IF;

  DELETE FROM TQMCLAIMD WHERE TQMCLAIMD.CLAIMKEY = _$CLAIMKEY;
  DELETE FROM TQMCLAIM WHERE TQMCLAIM.CLAIMKEY = _$CLAIMKEY;

-- ****************************************************************************
WHEN 'PRINT' THEN  -- CLAIM 통보서 출력 (리포트 TQM3001.exe R01)

  IF _$CLAIMKEY = '' THEN
    CALL COMERR('저장한 클레임만 출력할 수 있습니다.');
    LEAVE PROC;
  END IF;

  -- 결과셋 1: 머리글 (날짜는 양식 표기대로 문자열로 만든다)
  SELECT
      TQMCLAIM.CLAIMKEY AS DOCNO                                                  -- 문서번호 = 클레임키
    , IFNULL(DATE_FORMAT(NULLIF(TQMCLAIM.PLANDATE, ''), '%Y년%m월%d일'), '') AS DOCDATE_TXT   -- 공문서 작성일 (= 예정일자)
    , IFNULL(DATE_FORMAT(NULLIF(TQMCLAIM.PLANDATE, ''), '%Y년 %m월 %d일'), '') AS PLANDATE_TXT  -- 산출내역서 ■ 예정일자
    , IFNULL(DATE_FORMAT(NULLIF(TQMCLAIM.CONFDATE, ''), '%Y년 %m월 %d일'), '') AS CONFDATE_TXT  -- 산출내역서 □ 확정일자
    , IFNULL(DATE_FORMAT(NULLIF(TQMCLAIM.CONFDATE, ''), '%m/%d'), '') AS OBJDATE_MD   -- 공문서 "05/14 限 서면 제출" (확정일자)
    , IFNULL(MSTEMP.EMPNM, TQMCLAIM.EMPCD) AS EMPNM
    , TQMCLAIM.RECVNM
    , TQMCLAIM.REFNM
    , TQMCLAIM.TITLE
    , CONCAT(DATE_FORMAT(_$MSDATE, '%y.%m.%d'), ' ~ ', DATE_FORMAT(_$MEDATE, '%y.%m.%d')) AS PERIOD
  FROM TQMCLAIM
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = TQMCLAIM.EMPCD
  WHERE TQMCLAIM.CLAIMKEY = _$CLAIMKEY;

  -- 결과셋 2: 품목
  SELECT
      TQMCLAIMD.CLAIMSEQ
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , IFNULL(MSTITEM.ITEMNM, '') AS ITEMNM
    , TQMCLAIMD.BADCONT
    , TQMCLAIMD.CLAIMQTY
    , TQMCLAIMD.INPRICE
    , TQMCLAIMD.MFGPRICE
    , TQMCLAIMD.SALEPRICE
    , TQMCLAIMD.ETCAMT
    , TQMCLAIMD.CLAIMAMT
  FROM TQMCLAIMD
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = TQMCLAIMD.ITEMID
  WHERE TQMCLAIMD.CLAIMKEY = _$CLAIMKEY
  ORDER BY TQMCLAIMD.CLAIMSEQ;

-- ****************************************************************************
END CASE;
-- *****************************************************************************
END
