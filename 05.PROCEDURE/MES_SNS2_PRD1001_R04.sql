CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD1001_R04(
-- *****************************************************************************
-- Comment: 주간출하계획등록 - 생산관리팀 출하계획 엑셀(수출 / 내수)을 올려 SALOUTPLAN_W 에 저장
--          ) 엑셀은 화면(JS)에서 읽는다. 프로시저는 품목·거래처 찾기와 저장만 한다
--          ) LIST  : 저장된 출하계획 조회 (출하일자 기간, 구분, 거래처)
--          ) MATCH : 결과셋 1 = 엑셀 품번(ITEMCD) 목록 순서대로 품목ID·품명 (법인 COMPANYCD = '60' 품목만.
--                    같은 품번이 여럿이면 2공장(07) 품목, 그중 최근 ITEMID)
--                    결과셋 2 = 거래처 목록 (법인 60). 엑셀 거래처명과 가장 비슷한 거래처·코드로 이름 찾기는 화면에서 한다
--          ) SAVE  : 추가 저장. 기존 출하계획은 지우지 않는다 (전부 확인한 뒤에 넣는다)
--          ) DELETE: 선택한 출하계획 삭제
-- Create: 2026-11-12
-- Modify: 2026-11-12 MATCH 품목 찾기를 법인 COMPANYCD = '60' 품목으로 한정
--         2026-11-12 MATCH 거래처 목록을 법인 60 거래처(MSTCUST_DETAIL)로 한정 (찾기 팝업과 같은 범위)
--         2026-11-12 MATCH 결과셋 1 ITEMCD 를 엑셀 품번 대신 매칭된 MSTITEM.ITEMCD 로 (못 찾으면 '')
--         2026-11-12 SAVE 덮어쓰기(기간 삭제) 없앰. 추가만 한다 (사용자 지시)
-- *****************************************************************************
  IN $SDATE VARCHAR(10),              -- 기간 시작 (조회)
  IN $EDATE VARCHAR(10),              -- 기간 끝
  IN $OUTPLANTP VARCHAR(10),          -- 구분 (EXP 수출 / DOM 내수)
  IN $CUSTCD VARCHAR(100),            -- 거래처 (조회조건)
  IN $ITEMCD_LIST MEDIUMTEXT,         -- 품번 목록 (MATCH)
  IN $OUTDATE_LIST MEDIUMTEXT,        -- 출하일자 목록 (SAVE)
  IN $CUSTCD_LIST MEDIUMTEXT,         -- 거래처 목록
  IN $ENDCUSTCD_LIST MEDIUMTEXT,      -- 고객 목록
  IN $ITEMID_LIST MEDIUMTEXT,         -- 품목ID 목록
  IN $PLANQTY_LIST MEDIUMTEXT,        -- 출하계획수량 목록
  IN $PACKQTY_LIST MEDIUMTEXT,        -- 적입수량 목록
  IN $PLTQTY_LIST MEDIUMTEXT,         -- 파렛트수 목록
  IN $OUTTIME_LIST MEDIUMTEXT,        -- 출하예정시간 목록
  IN $ARRVTIME_LIST MEDIUMTEXT,       -- 도착예정시간 목록
  IN $REMARK_LIST MEDIUMTEXT,         -- 비고 목록
  IN $SALOUTPLANKEY_LIST MEDIUMTEXT,  -- 출하계획키 목록 (DELETE)
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$SEQ INT;
  DECLARE _$ITEMCD_LIST MEDIUMTEXT;
  DECLARE _$OUTDATE_LIST MEDIUMTEXT;
  DECLARE _$CUSTCD_LIST MEDIUMTEXT;
  DECLARE _$ENDCUSTCD_LIST MEDIUMTEXT;
  DECLARE _$ITEMID_LIST MEDIUMTEXT;
  DECLARE _$PLANQTY_LIST MEDIUMTEXT;
  DECLARE _$PACKQTY_LIST MEDIUMTEXT;
  DECLARE _$PLTQTY_LIST MEDIUMTEXT;
  DECLARE _$OUTTIME_LIST MEDIUMTEXT;
  DECLARE _$ARRVTIME_LIST MEDIUMTEXT;
  DECLARE _$REMARK_LIST MEDIUMTEXT;
  DECLARE _$SALOUTPLANKEY_LIST MEDIUMTEXT;
  DECLARE _$ITEMCD VARCHAR(100);
  DECLARE _$OUTDATE VARCHAR(100);
  DECLARE _$CUSTCD VARCHAR(100);
  DECLARE _$ENDCUSTCD VARCHAR(100);
  DECLARE _$ITEMID VARCHAR(100);
  DECLARE _$PLANQTY_TXT VARCHAR(100);
  DECLARE _$PACKQTY_TXT VARCHAR(100);
  DECLARE _$PLTQTY_TXT VARCHAR(100);
  DECLARE _$OUTTIME VARCHAR(100);
  DECLARE _$ARRVTIME VARCHAR(100);
  DECLARE _$REMARK VARCHAR(1000);
  DECLARE _$SALOUTPLANKEY VARCHAR(100);
  DECLARE _$PLANQTY DECIMAL(20, 8);
  DECLARE _$PACKQTY DECIMAL(20, 8);
  DECLARE _$PLTQTY DECIMAL(20, 8);
  DECLARE _$CNT INT;
-- *****************************************************************************
  IF $CALLTYPE = 'LIST' AND (IFNULL($SDATE, '') = '' OR IFNULL($EDATE, '') = '') THEN
    CALL COMERR('기간을 입력하세요.');
    LEAVE PROC;
  END IF;
-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST' THEN  -- 저장된 출하계획 조회 (grid1)

  SELECT
      SALOUTPLAN_W.SALOUTPLANKEY
    , SALOUTPLAN_W.OUTPLANTP
    , CASE SALOUTPLAN_W.OUTPLANTP
        WHEN 'EXP' THEN '수출'
        WHEN 'DOM' THEN '내수'
      ELSE SALOUTPLAN_W.OUTPLANTP END AS OUTPLANTPNM
    , SALOUTPLAN_W.OUTDATE
    , SALOUTPLAN_W.CUSTCD
    , IFNULL(MSTCUST1.CUSTNM, '') AS CUSTNM
    , SALOUTPLAN_W.ENDCUSTCD
    , IFNULL(MSTCUST2.CUSTNM, '') AS ENDCUSTNM
    , CAST(SALOUTPLAN_W.ITEMID AS CHAR) AS ITEMID
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , IFNULL(MSTITEM.ITEMNM, '') AS ITEMNM
    , SALOUTPLAN_W.PLANQTY
    , SALOUTPLAN_W.PACKQTY
    , SALOUTPLAN_W.PLTQTY
    , SALOUTPLAN_W.OUTTIME
    , SALOUTPLAN_W.ARRVTIME
    , SALOUTPLAN_W.REMARK
    , SALOUTPLAN_W.RTIME
  FROM SALOUTPLAN_W
  LEFT JOIN MSTCUST AS MSTCUST1
    ON MSTCUST1.CUSTCD = SALOUTPLAN_W.CUSTCD
  LEFT JOIN MSTCUST AS MSTCUST2
    ON MSTCUST2.CUSTCD = SALOUTPLAN_W.ENDCUSTCD
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = SALOUTPLAN_W.ITEMID
  WHERE SALOUTPLAN_W.OUTDATE BETWEEN $SDATE AND $EDATE
    AND (IFNULL($OUTPLANTP, '') = '' OR SALOUTPLAN_W.OUTPLANTP = $OUTPLANTP)
    AND (IFNULL($CUSTCD, '') = '' OR SALOUTPLAN_W.CUSTCD = $CUSTCD OR SALOUTPLAN_W.ENDCUSTCD = $CUSTCD)
  ORDER BY SALOUTPLAN_W.OUTPLANTP DESC, SALOUTPLAN_W.OUTDATE, SALOUTPLAN_W.SALOUTPLANKEY;

-- ****************************************************************************
WHEN 'MATCH' THEN  -- 엑셀 품번 → 품목ID, 거래처 목록 (grid2)

  DROP TEMPORARY TABLE IF EXISTS TEMP_OUTPLAN_ITEMCD;
  CREATE TEMPORARY TABLE TEMP_OUTPLAN_ITEMCD (
      SEQ INT NOT NULL PRIMARY KEY
    , ITEMCD VARCHAR(100) NOT NULL DEFAULT ''
    , ITEMID INT NOT NULL DEFAULT 0
    , ITEMCNT INT NOT NULL DEFAULT 0
  );

  SET _$ITEMCD_LIST = IFNULL($ITEMCD_LIST, '');
  SET _$SEQ = 0;

  WHILE LENGTH(_$ITEMCD_LIST) > 0 DO
    CALL COMSPLIT(_$ITEMCD_LIST, _$ITEMCD);
    SET _$SEQ = _$SEQ + 1;

    INSERT INTO TEMP_OUTPLAN_ITEMCD (SEQ, ITEMCD)
    VALUES (_$SEQ, TRIM(IFNULL(_$ITEMCD, '')));
  END WHILE;

  -- 법인 60 품목에서만 찾는다 (2026-11-12 사용자 지시). 같은 품번이 여럿이면 2공장(07) 품목, 그중 최근 ITEMID
  UPDATE TEMP_OUTPLAN_ITEMCD
    SET ITEMID = IFNULL((SELECT MSTITEM.ITEMID
                           FROM MSTITEM
                           WHERE MSTITEM.ITEMCD = TEMP_OUTPLAN_ITEMCD.ITEMCD
                             AND MSTITEM.COMPANYCD = '60'
                             AND IFNULL(MSTITEM.ENDYN, '') <> 'Y'
                           ORDER BY EXISTS (SELECT MSTITEM_FACTORY.ITEMID
                                              FROM MSTITEM_FACTORY
                                              WHERE MSTITEM_FACTORY.ITEMID = MSTITEM.ITEMID
                                                AND MSTITEM_FACTORY.FACTORYCD = '07') DESC
                                  , MSTITEM.ITEMID DESC
                           LIMIT 1), 0)
      , ITEMCNT = (SELECT COUNT(*)
                     FROM MSTITEM
                     WHERE MSTITEM.ITEMCD = TEMP_OUTPLAN_ITEMCD.ITEMCD
                       AND MSTITEM.COMPANYCD = '60'
                       AND IFNULL(MSTITEM.ENDYN, '') <> 'Y');

  -- 결과셋 1: 품번별 품목. ITEMCD = 매칭된 품목의 품번 (못 찾으면 ''), ITEMCNT = 같은 품번 품목 수
  SELECT
      TEMP_OUTPLAN_ITEMCD.SEQ
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , IF(TEMP_OUTPLAN_ITEMCD.ITEMID = 0, '', CAST(TEMP_OUTPLAN_ITEMCD.ITEMID AS CHAR)) AS ITEMID
    , IFNULL(MSTITEM.ITEMNM, '') AS ITEMNM
    , TEMP_OUTPLAN_ITEMCD.ITEMCNT
  FROM TEMP_OUTPLAN_ITEMCD
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = TEMP_OUTPLAN_ITEMCD.ITEMID
  ORDER BY TEMP_OUTPLAN_ITEMCD.SEQ;

  -- 결과셋 2: 거래처 (법인 60, 사용 중). 화면 찾기 팝업 DC_FIND 'CUSTCD_COMPANY' 와 같은 범위
  SELECT
      MSTCUST.CUSTCD
    , MSTCUST.CUSTNM
    , IFNULL(MSTCUST.CUSTNMEN, '') AS CUSTNMEN
  FROM MSTCUST
  WHERE MSTCUST.USEYN = 'Y'
    AND EXISTS (SELECT MSTCUST_DETAIL.CUSTCD
                  FROM MSTCUST_DETAIL
                  WHERE MSTCUST_DETAIL.CUSTCD = MSTCUST.CUSTCD
                    AND MSTCUST_DETAIL.COMPANYCD = '60')
  ORDER BY MSTCUST.CUSTCD;

-- ****************************************************************************
WHEN 'SAVE' THEN  -- 추가 저장 (기존 출하계획은 지우지 않는다)

  IF IFNULL($OUTPLANTP, '') NOT IN ('EXP', 'DOM') THEN
    CALL COMERR('구분(수출/내수)이 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($ITEMID_LIST, '') = '' THEN
    CALL COMERR('저장할 출하계획이 없습니다.');
    LEAVE PROC;
  END IF;

  -- 1. 전부 확인한 뒤에 넣는다
  SET _$OUTDATE_LIST = $OUTDATE_LIST;
  SET _$CUSTCD_LIST = $CUSTCD_LIST;
  SET _$ITEMID_LIST = $ITEMID_LIST;
  SET _$PLANQTY_LIST = $PLANQTY_LIST;
  SET _$OUTTIME_LIST = $OUTTIME_LIST;
  SET _$ARRVTIME_LIST = $ARRVTIME_LIST;
  SET _$SEQ = 0;

  WHILE LENGTH(_$ITEMID_LIST) > 0 DO
    CALL COMSPLIT(_$OUTDATE_LIST, _$OUTDATE);
    CALL COMSPLIT(_$CUSTCD_LIST, _$CUSTCD);
    CALL COMSPLIT(_$ITEMID_LIST, _$ITEMID);
    CALL COMSPLIT(_$PLANQTY_LIST, _$PLANQTY_TXT);
    CALL COMSPLIT(_$OUTTIME_LIST, _$OUTTIME);
    CALL COMSPLIT(_$ARRVTIME_LIST, _$ARRVTIME);
    SET _$SEQ = _$SEQ + 1;

    IF IFNULL(_$OUTDATE, '') NOT REGEXP '^[0-9]{4}-[0-9]{2}-[0-9]{2}$' THEN
      CALL COMERR(CONCAT(_$SEQ, '번째 줄: 출하일자가 없거나 형식이 틀립니다.'));
      LEAVE PROC;
    END IF;

    IF IFNULL(_$CUSTCD, '') = '' THEN
      CALL COMERR(CONCAT(_$SEQ, '번째 줄: 거래처를 선택하세요.'));
      LEAVE PROC;
    END IF;

    SET _$CNT = (SELECT COUNT(*) FROM MSTITEM WHERE MSTITEM.ITEMID = CAST(IF(IFNULL(_$ITEMID, '') = '', '0', _$ITEMID) AS UNSIGNED));
    IF _$CNT = 0 THEN
      CALL COMERR(CONCAT(_$SEQ, '번째 줄: 품목을 찾을 수 없습니다. 품번을 확인하세요.'));
      LEAVE PROC;
    END IF;

    SET _$PLANQTY = CAST(IF(IFNULL(_$PLANQTY_TXT, '') = '', '0', _$PLANQTY_TXT) AS DECIMAL(20, 8));
    IF _$PLANQTY <= 0 THEN
      CALL COMERR(CONCAT(_$SEQ, '번째 줄: 출하수량은 0보다 커야 합니다.'));
      LEAVE PROC;
    END IF;

    IF IFNULL(_$OUTTIME, '') <> '' AND _$OUTTIME NOT REGEXP '^[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}$' THEN
      CALL COMERR(CONCAT(_$SEQ, '번째 줄: 출하시간은 YYYY-MM-DD HH:mm 으로 입력하세요.'));
      LEAVE PROC;
    END IF;

    IF IFNULL(_$ARRVTIME, '') <> '' AND _$ARRVTIME NOT REGEXP '^[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}$' THEN
      CALL COMERR(CONCAT(_$SEQ, '번째 줄: 도착시간은 YYYY-MM-DD HH:mm 으로 입력하세요.'));
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 저장
  SET _$OUTDATE_LIST = $OUTDATE_LIST;
  SET _$CUSTCD_LIST = $CUSTCD_LIST;
  SET _$ENDCUSTCD_LIST = $ENDCUSTCD_LIST;
  SET _$ITEMID_LIST = $ITEMID_LIST;
  SET _$PLANQTY_LIST = $PLANQTY_LIST;
  SET _$PACKQTY_LIST = $PACKQTY_LIST;
  SET _$PLTQTY_LIST = $PLTQTY_LIST;
  SET _$OUTTIME_LIST = $OUTTIME_LIST;
  SET _$ARRVTIME_LIST = $ARRVTIME_LIST;
  SET _$REMARK_LIST = $REMARK_LIST;

  WHILE LENGTH(_$ITEMID_LIST) > 0 DO
    CALL COMSPLIT(_$OUTDATE_LIST, _$OUTDATE);
    CALL COMSPLIT(_$CUSTCD_LIST, _$CUSTCD);
    CALL COMSPLIT(_$ENDCUSTCD_LIST, _$ENDCUSTCD);
    CALL COMSPLIT(_$ITEMID_LIST, _$ITEMID);
    CALL COMSPLIT(_$PLANQTY_LIST, _$PLANQTY_TXT);
    CALL COMSPLIT(_$PACKQTY_LIST, _$PACKQTY_TXT);
    CALL COMSPLIT(_$PLTQTY_LIST, _$PLTQTY_TXT);
    CALL COMSPLIT(_$OUTTIME_LIST, _$OUTTIME);
    CALL COMSPLIT(_$ARRVTIME_LIST, _$ARRVTIME);
    CALL COMSPLIT(_$REMARK_LIST, _$REMARK);
    SET _$PLANQTY = CAST(IF(IFNULL(_$PLANQTY_TXT, '') = '', '0', _$PLANQTY_TXT) AS DECIMAL(20, 8));
    SET _$PACKQTY = CAST(IF(IFNULL(_$PACKQTY_TXT, '') = '', '0', _$PACKQTY_TXT) AS DECIMAL(20, 8));
    SET _$PLTQTY = CAST(IF(IFNULL(_$PLTQTY_TXT, '') = '', '0', _$PLTQTY_TXT) AS DECIMAL(20, 8));

    INSERT INTO SALOUTPLAN_W (
        OUTPLANTP
      , OUTDATE
      , CUSTCD
      , ENDCUSTCD
      , ITEMID
      , PLANQTY
      , PACKQTY
      , PLTQTY
      , OUTTIME
      , ARRVTIME
      , REMARK
      , RTIME, REMP, RPRG)
    VALUES (
        $OUTPLANTP
      , _$OUTDATE
      , _$CUSTCD
      , IFNULL(_$ENDCUSTCD, '')
      , CAST(_$ITEMID AS UNSIGNED)
      , _$PLANQTY
      , _$PACKQTY
      , _$PLTQTY
      , IFNULL(_$OUTTIME, '')
      , IFNULL(_$ARRVTIME, '')
      , IFNULL(_$REMARK, '')
      , CALLTIME(), CALLEMP(), CALLPRG()
    );
  END WHILE;

-- ****************************************************************************
WHEN 'DELETE' THEN  -- 선택한 출하계획 삭제

  SET _$SALOUTPLANKEY_LIST = IFNULL($SALOUTPLANKEY_LIST, '');

  WHILE LENGTH(_$SALOUTPLANKEY_LIST) > 0 DO
    CALL COMSPLIT(_$SALOUTPLANKEY_LIST, _$SALOUTPLANKEY);

    DELETE FROM SALOUTPLAN_W
      WHERE SALOUTPLAN_W.SALOUTPLANKEY = CAST(_$SALOUTPLANKEY AS UNSIGNED);
  END WHILE;

-- ****************************************************************************
END CASE;
-- *****************************************************************************
END
