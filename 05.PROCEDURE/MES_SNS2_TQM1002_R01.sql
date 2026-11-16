CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TQM1002_R01(
-- *****************************************************************************
-- Comment: 출하검사 등록 - 주간출하계획(SALOUTPLAN_W)을 골라 그 품목의 출하검사 기준(STDTP = 'OUTTEST')으로 검사
--          ) 출하계획 1건 = 검사 1건: TQMRST.SALOUTPLANKEY = SALOUTPLAN_W.SALOUTPLANKEY (2026-11-13 사용자 결정)
--          ) 검사항목 줄마다 측정치 X1~X5 와 판정 (TQMRSTKND.STDVALCHK ~ STDVALCHK5, JUDGE)
--          ) LIST      : 주간출하계획 (출하일자 기간, 구분, 거래처, 품목) + 검사상태 (미검사 / 검사중 / 합격 / 불합격)
--          ) LIST_STD  : 결과셋 1 = 검사 헤더 (검사일자·검사자, 검사 전이면 빈값)
--                        결과셋 2 = 검사항목 + 측정치·판정. 검사한 계획이면 그 검사의 리비전, 아니면 품목의 사용중인 출하검사 리비전
--          ) SAVE_RST  : 화면에서 판정한 검사항목 전체의 측정치·판정 저장. 헤더가 없으면 만들고, 있으면 검사일자·검사자를 화면 값으로 바꾼다
--                        검사확정시간(FIXTIME) = 저장한 시각
--          ) APPROVE   : 체크한 출하계획들의 검사 승인 (TQMRST.APRVEMP·APRVTIME). 미검사·검사중 계획이 있으면 전부 막는다
--          ) APPROVE_CANCEL: 체크한 출하계획들의 승인취소. 승인 안 된 계획이 있으면 전부 막는다
--          ) PRINT     : 검사성적서(갑지) 출력 (리포트 TQM1002.exe R01, 출하계획 1건씩). 결과셋 1 머리, 2 검사항목
--          ) 승인된 검사는 SAVE_RST 로 수정할 수 없다 (승인취소 후 수정)
-- Create: 2026-11-13
-- Modify: 2026-11-13 LIST 조회조건 거래처(CUSTCD)·품목(ITEMID) 추가
--         2026-11-13 검사시간($TQMTIME) 없앰. FIXTIME = 저장한 시각, 화면 표시는 검사일자(TQMDATE) (사용자 지시)
--         2026-11-13 검사값 입력을 측정치 X1~X5(TQMRSTKND.STDVALCHK~5) 로 변경, 검사항목 전체 한 번에 저장.
--                    LIST_VALUE·TQMRST_VALUE·시료수·최소/최대/평균 없앰 (사용자 지시)
--         2026-11-13 승인(APPROVE) 추가, LIST 에 승인자·승인일시 (사용자 지시)
--         2026-11-13 승인취소(APPROVE_CANCEL) 추가, 승인된 검사 수정(SAVE_RST) 막음 (사용자 지시)
--         2026-11-16 검사성적서 출력(PRINT) 추가, 비고란 수량(QTY_TXT) 추가
-- *****************************************************************************
  IN $SDATE VARCHAR(10),              -- 출하일자 시작 (LIST)
  IN $EDATE VARCHAR(10),              -- 출하일자 끝
  IN $OUTPLANTP VARCHAR(10),          -- 구분 (EXP 수출 / DOM 내수, '' 전체)
  IN $CUSTCD VARCHAR(100),            -- 거래처 (LIST, 출하계획의 거래처 또는 고객)
  IN $ITEMID VARCHAR(20),             -- 품목ID (LIST)
  IN $SALOUTPLANKEY VARCHAR(100),     -- 출하계획키
  IN $REVCD VARCHAR(100),             -- 출하검사 리비전
  IN $TQMDATE VARCHAR(10),            -- 검사일자
  IN $EMPCD VARCHAR(100),             -- 검사자
  IN $STDCD_LIST MEDIUMTEXT,          -- 검사항목코드 목록 (SAVE_RST)
  IN $STDPART_LIST MEDIUMTEXT,        -- 세부항목 목록
  IN $PRCCD_LIST MEDIUMTEXT,          -- 공정 목록
  IN $PRCDETAIL_LIST MEDIUMTEXT,      -- 세부공정 목록
  IN $X1_LIST MEDIUMTEXT,             -- 측정치 X1 목록
  IN $X2_LIST MEDIUMTEXT,             -- 측정치 X2 목록
  IN $X3_LIST MEDIUMTEXT,             -- 측정치 X3 목록
  IN $X4_LIST MEDIUMTEXT,             -- 측정치 X4 목록
  IN $X5_LIST MEDIUMTEXT,             -- 측정치 X5 목록
  IN $JUDGE_LIST MEDIUMTEXT,          -- 판정 목록 (Y 합격, N 불합격)
  IN $APRVEMP VARCHAR(20),            -- 승인자 (APPROVE)
  IN $SALOUTPLANKEY_LIST MEDIUMTEXT,  -- 승인할 출하계획키 목록 (APPROVE)
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$ITEMID INT(11);
  DECLARE _$REVCD VARCHAR(100);
  DECLARE _$TQMRSTKEY VARCHAR(100);
  DECLARE _$STDCD_LIST MEDIUMTEXT;
  DECLARE _$STDPART_LIST MEDIUMTEXT;
  DECLARE _$PRCCD_LIST MEDIUMTEXT;
  DECLARE _$PRCDETAIL_LIST MEDIUMTEXT;
  DECLARE _$X1_LIST MEDIUMTEXT;
  DECLARE _$X2_LIST MEDIUMTEXT;
  DECLARE _$X3_LIST MEDIUMTEXT;
  DECLARE _$X4_LIST MEDIUMTEXT;
  DECLARE _$X5_LIST MEDIUMTEXT;
  DECLARE _$JUDGE_LIST MEDIUMTEXT;
  DECLARE _$STDCD VARCHAR(100);
  DECLARE _$STDPART VARCHAR(100);
  DECLARE _$PRCCD VARCHAR(100);
  DECLARE _$PRCDETAIL VARCHAR(100);
  DECLARE _$X1 VARCHAR(100);
  DECLARE _$X2 VARCHAR(100);
  DECLARE _$X3 VARCHAR(100);
  DECLARE _$X4 VARCHAR(100);
  DECLARE _$X5 VARCHAR(100);
  DECLARE _$JUDGE VARCHAR(10);
  DECLARE _$SALOUTPLANKEY_LIST MEDIUMTEXT;
  DECLARE _$SALOUTPLANKEY VARCHAR(100);
  DECLARE _$ITEMCD VARCHAR(100);
-- *****************************************************************************
  IF $CALLTYPE IN ('LIST_STD', 'SAVE_RST', 'PRINT') THEN
    SET _$ITEMID = IFNULL((SELECT SALOUTPLAN_W.ITEMID
                             FROM SALOUTPLAN_W
                             WHERE SALOUTPLAN_W.SALOUTPLANKEY = IFNULL($SALOUTPLANKEY, '')), 0);

    IF _$ITEMID = 0 THEN
      CALL COMERR('출하계획을 선택하세요.');
      LEAVE PROC;
    END IF;

    -- 이 출하계획의 검사 (출하계획 1건 = 검사 1건)
    SET _$TQMRSTKEY = IFNULL((SELECT TQMRST.TQMRSTKEY
                                FROM TQMRST
                                WHERE TQMRST.SALOUTPLANKEY = $SALOUTPLANKEY
                                LIMIT 1), '');
  END IF;
-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST' THEN  -- 주간출하계획 + 검사상태 (grid1)

  IF IFNULL($SDATE, '') = '' OR IFNULL($EDATE, '') = '' THEN
    CALL COMERR('출하일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  SELECT
      SALOUTPLAN_W.SALOUTPLANKEY
    , CASE SALOUTPLAN_W.OUTPLANTP
        WHEN 'EXP' THEN '수출'
        WHEN 'DOM' THEN '내수'
      ELSE SALOUTPLAN_W.OUTPLANTP END AS OUTPLANTPNM
    , SALOUTPLAN_W.OUTDATE
    , IFNULL(MSTCUST1.CUSTNM, '') AS CUSTNM
    , IFNULL(MSTCUST2.CUSTNM, '') AS ENDCUSTNM
    , CAST(SALOUTPLAN_W.ITEMID AS CHAR) AS ITEMID
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , IFNULL(MSTITEM.ITEMNM, '') AS ITEMNM
    , SALOUTPLAN_W.PLANQTY
    , IFNULL(LEFT(TQMRST.TQMDATE, 10), '') AS TQMDATE
    , IFNULL(MSTEMP.EMPNM, IFNULL(TQMRST.EMPCD, '')) AS EMPNM
    , CASE
        WHEN TQMRST.TQMRSTKEY IS NULL THEN '미검사'
        WHEN TQMRST.FINALJUDGE = 'N' THEN '불합격'
        WHEN (SELECT COUNT(*) FROM TQMRSTKND WHERE TQMRSTKND.TQMRSTKEY = TQMRST.TQMRSTKEY)
           < (SELECT COUNT(*) FROM MSTRPTREV_DETAIL WHERE MSTRPTREV_DETAIL.REVCD = TQMRST.REVCD) THEN '검사중'
      ELSE '합격' END AS INSPSTT
    , IFNULL(MSTEMP2.EMPNM, IFNULL(TQMRST.APRVEMP, '')) AS APRVEMPNM
    , IFNULL(LEFT(TQMRST.APRVTIME, 16), '') AS APRVTIME
    , IFNULL(TQMRST.TQMRSTKEY, '') AS TQMRSTKEY
    , CASE WHEN TQMRST.FINALJUDGE = 'Y' THEN 'LIGHTCYAN'
           WHEN TQMRST.FINALJUDGE = 'N' THEN 'PINK'
      ELSE ''
      END AS BACKGROUND
  FROM SALOUTPLAN_W
  LEFT JOIN MSTCUST AS MSTCUST1
    ON MSTCUST1.CUSTCD = SALOUTPLAN_W.CUSTCD
  LEFT JOIN MSTCUST AS MSTCUST2
    ON MSTCUST2.CUSTCD = SALOUTPLAN_W.ENDCUSTCD
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = SALOUTPLAN_W.ITEMID
  LEFT JOIN TQMRST
    ON TQMRST.SALOUTPLANKEY = SALOUTPLAN_W.SALOUTPLANKEY
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = TQMRST.EMPCD
  LEFT JOIN MSTEMP AS MSTEMP2
    ON MSTEMP2.EMPCD = TQMRST.APRVEMP
  WHERE SALOUTPLAN_W.OUTDATE BETWEEN $SDATE AND $EDATE
    AND (IFNULL($OUTPLANTP, '') = '' OR SALOUTPLAN_W.OUTPLANTP = $OUTPLANTP)
    AND (IFNULL($CUSTCD, '') = '' OR SALOUTPLAN_W.CUSTCD = $CUSTCD OR SALOUTPLAN_W.ENDCUSTCD = $CUSTCD)
    AND (IFNULL($ITEMID, '') = '' OR SALOUTPLAN_W.ITEMID = $ITEMID)
  ORDER BY SALOUTPLAN_W.OUTDATE, SALOUTPLAN_W.OUTPLANTP DESC, SALOUTPLAN_W.SALOUTPLANKEY;

-- ****************************************************************************
WHEN 'LIST_STD' THEN  -- 검사 헤더 + 검사항목·측정치 (출하계획 선택)

  -- 검사한 계획이면 그 검사의 리비전, 아니면 품목의 사용중인 출하검사 리비전
  IF _$TQMRSTKEY <> '' THEN
    SET _$REVCD = (SELECT TQMRST.REVCD FROM TQMRST WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY);
  ELSE
    SET _$REVCD = IFNULL((SELECT MSTRPTREV_HEADER.REVCD
                            FROM MSTRPTREV_ITEM
                            INNER JOIN MSTRPTREV_HEADER
                              ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_ITEM.REVCD
                            WHERE MSTRPTREV_ITEM.ITEMID = _$ITEMID
                              AND MSTRPTREV_HEADER.STDTP = 'OUTTEST'
                              AND MSTRPTREV_HEADER.USEYN = 'Y'
                            ORDER BY MSTRPTREV_HEADER.REVNUM DESC
                            LIMIT 1), '');
  END IF;

  IF _$REVCD = '' THEN
    CALL COMERR('사용중인 출하검사 기준이 없습니다.\n검사표준관리에서 출하검사 기준을 등록하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 검사 헤더 (검사 전이면 빈값, 화면이 오늘·로그인 사원으로 채운다)
  SELECT
      _$TQMRSTKEY AS TQMRSTKEY
    , IFNULL(LEFT(TQMRST.TQMDATE, 10), '') AS TQMDATE
    , IFNULL(TQMRST.EMPCD, '') AS EMPCD
  FROM (SELECT 1 AS ONEROW) AS ONEROW
  LEFT JOIN TQMRST
    ON TQMRST.TQMRSTKEY = _$TQMRSTKEY;

  -- 2. 검사항목 + 측정치·판정 (저장 전이면 빈값)
  SELECT
      MSTRPTREV_DETAIL.SORTNO
    , MSTRPTREV_DETAIL.STDNM
    , MSTRPTREV_DETAIL.STDPART
    , MSTRPTREV_DETAIL.FEATURE
    , MSTRPTREV_DETAIL.STDCHKTP
    , MSTRPTREV_DETAIL.STDMACHINE
    , CASE
        WHEN MSTRPTREV_DETAIL.STDCHKTP = '02' THEN FIND_STDJUDGE_MEASURE(MSTRPTREV_DETAIL.STDRANGE, MSTRPTREV_DETAIL.STDVAL, MSTRPTREV_DETAIL.STDUNIT, MSTRPTREV_DETAIL.STDMINUS, MSTRPTREV_DETAIL.STDPLUS)
      ELSE MSTRPTREV_DETAIL.STDJUDGE END AS STDJUDGE  -- 판정기준 (측정이면 기준값·공차로 생성)
    , IFNULL(TQMRSTKND.STDVALCHK, '') AS X1
    , IFNULL(TQMRSTKND.STDVALCHK2, '') AS X2
    , IFNULL(TQMRSTKND.STDVALCHK3, '') AS X3
    , IFNULL(TQMRSTKND.STDVALCHK4, '') AS X4
    , IFNULL(TQMRSTKND.STDVALCHK5, '') AS X5
    , IFNULL(TQMRSTKND.JUDGE, '') AS JUDGE
    , MSTRPTREV_DETAIL.REVCD
    , MSTRPTREV_DETAIL.STDCD
    , MSTRPTREV_DETAIL.PRCCD
    , MSTRPTREV_DETAIL.PRCDETAIL
    , MSTRPTREV_DETAIL.STDVAL     -- 측정 판정용 (화면 숨김)
    , MSTRPTREV_DETAIL.STDRANGE
    , MSTRPTREV_DETAIL.STDMINUS
    , MSTRPTREV_DETAIL.STDPLUS
  FROM MSTRPTREV_DETAIL
  LEFT JOIN TQMRSTKND
    ON TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
   AND TQMRSTKND.STDCD = MSTRPTREV_DETAIL.STDCD
   AND TQMRSTKND.PRCCD = MSTRPTREV_DETAIL.PRCCD
   AND TQMRSTKND.STDPART = MSTRPTREV_DETAIL.STDPART
   AND TQMRSTKND.PRCDETAIL = MSTRPTREV_DETAIL.PRCDETAIL
  WHERE MSTRPTREV_DETAIL.REVCD = _$REVCD
  ORDER BY MSTRPTREV_DETAIL.SORTNO;

-- ****************************************************************************
WHEN 'SAVE_RST' THEN  -- 판정한 검사항목 전체의 측정치·판정 저장 (저장 버튼)

  IF IFNULL($REVCD, '') = '' OR IFNULL($STDCD_LIST, '') = '' THEN
    CALL COMERR('저장할 검사항목이 없습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($TQMDATE, '') = '' THEN
    CALL COMERR('검사일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($EMPCD, '') = '' THEN
    CALL COMERR('검사자를 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 0. 판정 확인 (쓰기 전에 전부 확인)
  SET _$JUDGE_LIST = $JUDGE_LIST;
  WHILE LENGTH(_$JUDGE_LIST) > 0 DO
    CALL COMSPLIT(_$JUDGE_LIST, _$JUDGE);
    IF IFNULL(_$JUDGE, '') NOT IN ('Y', 'N') THEN
      CALL COMERR('판정(합격/불합격)이 없는 검사항목이 있습니다.');
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 승인된 검사는 수정할 수 없다
  IF _$TQMRSTKEY <> '' AND IFNULL((SELECT TQMRST.APRVTIME FROM TQMRST WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY), '') <> '' THEN
    CALL COMERR('승인된 검사는 수정할 수 없습니다.\n승인취소 후 수정하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 헤더: 없으면 만들고, 있으면 검사일자·검사자를 화면 값으로 (검사확정시간 FIXTIME = 저장한 시각)
  IF _$TQMRSTKEY = '' THEN
    SET _$TQMRSTKEY = GETKEY('TQMRSTKEY');

    INSERT INTO TQMRST (
        TQMRSTKEY
      , REVCD
      , TQMDATE
      , SALOUTPLANKEY
      , ITEMID
      , EMPCD
      , FIXTIME
      , RTIME, REMP, RPRG)
    VALUES (
        _$TQMRSTKEY
      , $REVCD
      , $TQMDATE
      , $SALOUTPLANKEY
      , _$ITEMID
      , $EMPCD
      , CALLTIME()
      , CALLTIME(), CALLEMP(), CALLPRG()
    );
  ELSE
    UPDATE TQMRST
      SET TQMDATE = $TQMDATE
        , EMPCD = $EMPCD
        , FIXTIME = CALLTIME()
        , MTIME = CALLTIME()
        , MEMP = CALLEMP()
        , MPRG = CALLPRG()
      WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY;
  END IF;

  -- 2. 검사항목별 측정치·판정 (이미 저장된 항목이면 수정)
  SET _$STDCD_LIST = $STDCD_LIST;
  SET _$STDPART_LIST = $STDPART_LIST;
  SET _$PRCCD_LIST = $PRCCD_LIST;
  SET _$PRCDETAIL_LIST = $PRCDETAIL_LIST;
  SET _$X1_LIST = $X1_LIST;
  SET _$X2_LIST = $X2_LIST;
  SET _$X3_LIST = $X3_LIST;
  SET _$X4_LIST = $X4_LIST;
  SET _$X5_LIST = $X5_LIST;
  SET _$JUDGE_LIST = $JUDGE_LIST;

  WHILE LENGTH(_$STDCD_LIST) > 0 DO
    CALL COMSPLIT(_$STDCD_LIST, _$STDCD);
    CALL COMSPLIT(_$STDPART_LIST, _$STDPART);
    CALL COMSPLIT(_$PRCCD_LIST, _$PRCCD);
    CALL COMSPLIT(_$PRCDETAIL_LIST, _$PRCDETAIL);
    CALL COMSPLIT(_$X1_LIST, _$X1);
    CALL COMSPLIT(_$X2_LIST, _$X2);
    CALL COMSPLIT(_$X3_LIST, _$X3);
    CALL COMSPLIT(_$X4_LIST, _$X4);
    CALL COMSPLIT(_$X5_LIST, _$X5);
    CALL COMSPLIT(_$JUDGE_LIST, _$JUDGE);

    IF EXISTS (SELECT TQMRSTKND.TQMRSTKEY
                 FROM TQMRSTKND
                 WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
                   AND TQMRSTKND.STDCD = _$STDCD
                   AND TQMRSTKND.PRCCD = _$PRCCD
                   AND TQMRSTKND.STDPART = _$STDPART
                   AND TQMRSTKND.PRCDETAIL = _$PRCDETAIL) THEN
      UPDATE TQMRSTKND
        SET STDVALCHK = IFNULL(_$X1, '')
          , STDVALCHK2 = IFNULL(_$X2, '')
          , STDVALCHK3 = IFNULL(_$X3, '')
          , STDVALCHK4 = IFNULL(_$X4, '')
          , STDVALCHK5 = IFNULL(_$X5, '')
          , JUDGE = _$JUDGE
          , MTIME = CALLTIME()
          , MEMP = CALLEMP()
          , MPRG = CALLPRG()
        WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
          AND TQMRSTKND.STDCD = _$STDCD
          AND TQMRSTKND.PRCCD = _$PRCCD
          AND TQMRSTKND.STDPART = _$STDPART
          AND TQMRSTKND.PRCDETAIL = _$PRCDETAIL;
    ELSE
      INSERT INTO TQMRSTKND (
          TQMRSTKEY
        , STDCD
        , STDPART
        , PRCCD
        , PRCDETAIL
        , STDVALCHK
        , STDVALCHK2
        , STDVALCHK3
        , STDVALCHK4
        , STDVALCHK5
        , JUDGE
        , RTIME, REMP, RPRG)
      VALUES (
          _$TQMRSTKEY
        , _$STDCD
        , IFNULL(_$STDPART, '')
        , IFNULL(_$PRCCD, '')
        , IFNULL(_$PRCDETAIL, '')
        , IFNULL(_$X1, '')
        , IFNULL(_$X2, '')
        , IFNULL(_$X3, '')
        , IFNULL(_$X4, '')
        , IFNULL(_$X5, '')
        , _$JUDGE
        , CALLTIME(), CALLEMP(), CALLPRG()
      );
    END IF;
  END WHILE;

  -- 3. 종합판정: 불합격 항목이 하나라도 있으면 N
  UPDATE TQMRST
    SET FINALJUDGE = IF(EXISTS (SELECT TQMRSTKND.TQMRSTKEY
                                  FROM TQMRSTKND
                                  WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
                                    AND TQMRSTKND.JUDGE = 'N'), 'N', 'Y')
    WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY;

  -- 출하계획 줄 갱신 (검사일자·검사자·검사상태, LIST 와 같은 기준)
  SELECT
      TQMRST.TQMRSTKEY
    , LEFT(TQMRST.TQMDATE, 10) AS TQMDATE
    , IFNULL(MSTEMP.EMPNM, TQMRST.EMPCD) AS EMPNM
    , CASE
        WHEN TQMRST.FINALJUDGE = 'N' THEN '불합격'
        WHEN (SELECT COUNT(*) FROM TQMRSTKND WHERE TQMRSTKND.TQMRSTKEY = TQMRST.TQMRSTKEY)
           < (SELECT COUNT(*) FROM MSTRPTREV_DETAIL WHERE MSTRPTREV_DETAIL.REVCD = TQMRST.REVCD) THEN '검사중'
      ELSE '합격' END AS INSPSTT
  FROM TQMRST
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = TQMRST.EMPCD
  WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY;

-- ****************************************************************************
WHEN 'APPROVE' THEN  -- 체크한 출하계획들의 검사 승인 (승인 버튼)

  IF IFNULL($APRVEMP, '') = '' THEN
    CALL COMERR('승인자를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($SALOUTPLANKEY_LIST, '') = '' THEN
    CALL COMERR('승인할 출하계획을 체크하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 전부 확인한 뒤에 승인한다: 검사가 없거나(미검사) 판정 안 한 항목이 남은(검사중) 계획이 있으면 막는다
  SET _$SALOUTPLANKEY_LIST = $SALOUTPLANKEY_LIST;
  WHILE LENGTH(_$SALOUTPLANKEY_LIST) > 0 DO
    CALL COMSPLIT(_$SALOUTPLANKEY_LIST, _$SALOUTPLANKEY);

    SET _$ITEMCD = IFNULL((SELECT MSTITEM.ITEMCD
                             FROM SALOUTPLAN_W
                             LEFT JOIN MSTITEM
                               ON MSTITEM.ITEMID = SALOUTPLAN_W.ITEMID
                             WHERE SALOUTPLAN_W.SALOUTPLANKEY = _$SALOUTPLANKEY), _$SALOUTPLANKEY);

    SET _$TQMRSTKEY = IFNULL((SELECT TQMRST.TQMRSTKEY
                                FROM TQMRST
                                WHERE TQMRST.SALOUTPLANKEY = _$SALOUTPLANKEY
                                LIMIT 1), '');

    IF _$TQMRSTKEY = '' THEN
      CALL COMERR(CONCAT('검사하지 않은 출하계획은 승인할 수 없습니다.\n- 품번: ', _$ITEMCD));
      LEAVE PROC;
    END IF;

    IF (SELECT COUNT(*) FROM TQMRSTKND WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY)
     < (SELECT COUNT(*)
          FROM TQMRST
          INNER JOIN MSTRPTREV_DETAIL
            ON MSTRPTREV_DETAIL.REVCD = TQMRST.REVCD
          WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY) THEN
      CALL COMERR(CONCAT('검사중(판정 안 한 검사항목이 있는) 출하계획은 승인할 수 없습니다.\n- 품번: ', _$ITEMCD));
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 승인 (이미 승인된 검사는 승인자·승인일시를 새 값으로)
  SET _$SALOUTPLANKEY_LIST = $SALOUTPLANKEY_LIST;
  WHILE LENGTH(_$SALOUTPLANKEY_LIST) > 0 DO
    CALL COMSPLIT(_$SALOUTPLANKEY_LIST, _$SALOUTPLANKEY);

    UPDATE TQMRST
      SET APRVEMP = $APRVEMP
        , APRVTIME = CALLTIME()
        , MTIME = CALLTIME()
        , MEMP = CALLEMP()
        , MPRG = CALLPRG()
      WHERE TQMRST.SALOUTPLANKEY = _$SALOUTPLANKEY;
  END WHILE;

-- ****************************************************************************
WHEN 'APPROVE_CANCEL' THEN  -- 체크한 출하계획들의 승인취소 (승인취소 버튼)

  IF IFNULL($SALOUTPLANKEY_LIST, '') = '' THEN
    CALL COMERR('승인취소할 출하계획을 체크하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 전부 확인한 뒤에 취소한다: 승인 안 된 계획이 있으면 막는다
  SET _$SALOUTPLANKEY_LIST = $SALOUTPLANKEY_LIST;
  WHILE LENGTH(_$SALOUTPLANKEY_LIST) > 0 DO
    CALL COMSPLIT(_$SALOUTPLANKEY_LIST, _$SALOUTPLANKEY);

    IF NOT EXISTS (SELECT TQMRST.TQMRSTKEY
                     FROM TQMRST
                     WHERE TQMRST.SALOUTPLANKEY = _$SALOUTPLANKEY
                       AND TQMRST.APRVTIME <> '') THEN
      SET _$ITEMCD = IFNULL((SELECT MSTITEM.ITEMCD
                               FROM SALOUTPLAN_W
                               LEFT JOIN MSTITEM
                                 ON MSTITEM.ITEMID = SALOUTPLAN_W.ITEMID
                               WHERE SALOUTPLAN_W.SALOUTPLANKEY = _$SALOUTPLANKEY), _$SALOUTPLANKEY);
      CALL COMERR(CONCAT('승인되지 않은 출하계획은 승인취소할 수 없습니다.\n- 품번: ', _$ITEMCD));
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 승인취소 (승인자·승인일시를 비운다)
  SET _$SALOUTPLANKEY_LIST = $SALOUTPLANKEY_LIST;
  WHILE LENGTH(_$SALOUTPLANKEY_LIST) > 0 DO
    CALL COMSPLIT(_$SALOUTPLANKEY_LIST, _$SALOUTPLANKEY);

    UPDATE TQMRST
      SET APRVEMP = ''
        , APRVTIME = ''
        , MTIME = CALLTIME()
        , MEMP = CALLEMP()
        , MPRG = CALLPRG()
      WHERE TQMRST.SALOUTPLANKEY = _$SALOUTPLANKEY;
  END WHILE;

-- ****************************************************************************
WHEN 'PRINT' THEN  -- 검사성적서(갑지) 출력 (리포트 TQM1002.exe R01, 출하계획 1건)

  IF _$TQMRSTKEY = '' THEN
    CALL COMERR('검사하지 않은 출하계획은 성적서를 출력할 수 없습니다.');
    LEAVE PROC;
  END IF;

  -- 결과셋 1: 머리 (날짜는 양식 표기대로 문자열로 만든다)
  SELECT
      IFNULL(DATE_FORMAT(NULLIF(LEFT(TQMRST.TQMDATE, 10), ''), '작성일 : %Y년 %m월 %d일'), '') AS TQMDATE_TXT
    , IFNULL(MSTITEM.ITEMNM, '') AS ITEMNM
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , IFNULL(MSTITEM.EONO, '') AS EONO
    , IFNULL(MSTITEM.MODELCD, '') AS MODELCD
    , IFNULL(MSTEMP.EMPNM, TQMRST.EMPCD) AS EMPNM
    , IFNULL(MSTEMP2.EMPNM, TQMRST.APRVEMP) AS APRVEMPNM
    , TQMRST.FINALJUDGE
    , IFNULL(CONCAT('수량 ', FORMAT(SALOUTPLAN_W.PLANQTY, 0), 'EA'), '') AS QTY_TXT   -- 비고란 수량 (출하계획 출하수량)
  FROM TQMRST
  LEFT JOIN SALOUTPLAN_W
    ON SALOUTPLAN_W.SALOUTPLANKEY = TQMRST.SALOUTPLANKEY
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = TQMRST.ITEMID
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = TQMRST.EMPCD
  LEFT JOIN MSTEMP AS MSTEMP2
    ON MSTEMP2.EMPCD = TQMRST.APRVEMP
  WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY;

  -- 결과셋 2: 검사항목 (그 검사의 리비전 항목 전체, 검사기준 순서. 판정 Y/N → OK/NG)
  SELECT
      CONCAT(MSTRPTREV_DETAIL.STDNM, IF(MSTRPTREV_DETAIL.STDPART <> '', CONCAT(' ', MSTRPTREV_DETAIL.STDPART), '')) AS STDNM
    , CASE
        WHEN MSTRPTREV_DETAIL.STDCHKTP = '02' THEN FIND_STDJUDGE_MEASURE(MSTRPTREV_DETAIL.STDRANGE, MSTRPTREV_DETAIL.STDVAL, MSTRPTREV_DETAIL.STDUNIT, MSTRPTREV_DETAIL.STDMINUS, MSTRPTREV_DETAIL.STDPLUS)
      ELSE MSTRPTREV_DETAIL.STDJUDGE END AS STDJUDGE
    , IFNULL(TQMRSTKND.STDVALCHK, '') AS X1
    , IFNULL(TQMRSTKND.STDVALCHK2, '') AS X2
    , IFNULL(TQMRSTKND.STDVALCHK3, '') AS X3
    , IFNULL(TQMRSTKND.STDVALCHK4, '') AS X4
    , IFNULL(TQMRSTKND.STDVALCHK5, '') AS X5
    , CASE TQMRSTKND.JUDGE WHEN 'Y' THEN 'OK' WHEN 'N' THEN 'NG' ELSE '' END AS JUDGE
  FROM TQMRST
  INNER JOIN MSTRPTREV_DETAIL
    ON MSTRPTREV_DETAIL.REVCD = TQMRST.REVCD
  LEFT JOIN TQMRSTKND
    ON TQMRSTKND.TQMRSTKEY = TQMRST.TQMRSTKEY
   AND TQMRSTKND.STDCD = MSTRPTREV_DETAIL.STDCD
   AND TQMRSTKND.PRCCD = MSTRPTREV_DETAIL.PRCCD
   AND TQMRSTKND.STDPART = MSTRPTREV_DETAIL.STDPART
   AND TQMRSTKND.PRCDETAIL = MSTRPTREV_DETAIL.PRCDETAIL
  WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY
  ORDER BY MSTRPTREV_DETAIL.SORTNO;

-- ****************************************************************************
END CASE;
-- *****************************************************************************
END