CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TQM1002_R01(
-- *****************************************************************************
-- Comment: 출하검사 등록 - 주간출하계획(SALOUTPLAN_W)을 골라 그 품목의 출하검사 기준(STDTP = 'OUTTEST')으로 검사
--          ) 출하계획 1건 = 검사 1건: TQMRST.SALOUTPLANKEY = SALOUTPLAN_W.SALOUTPLANKEY (2026-11-13 사용자 결정)
--          ) 검사항목 줄마다 측정치 X1~X10 (시료수만큼) 와 판정 (TQMRSTKND.STDVALCHK ~ STDVALCHK10, JUDGE)
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
--         2026-11-26 김영철 LIST_STD 검사항목에 시료수(SAMPLESIZE) 추가 (시료수만큼만 측정치 입력칸 사용)
--         2026-11-26 김영철 측정치 X1~X5 → X1~X10 확장 (SAVE_RST·LIST_STD·PRINT), PRINT 에 시료수(SAMPLESIZE) 추가 (사용자 지시)
--         2026-11-26 김영철 APPROVE 종합판정이 불합격(FINALJUDGE = 'N')이면 승인 차단. LIST·LIST_STD·PRINT 에 적용 리비전(REVNUM, 개정일) 추가 (사용자 지시)
--         2026-11-26 김영철 출하성적서 고객사별 엑셀 양식: 양식 관리(LIST_FORM·SAVE_FORM·DELETE_FORM)·계획별 양식 선택(SET_PLANFORM)·출력용 양식 조회(FORM_INFO) 추가, LIST 에 양식(FORMKEY·FORMNM)·거래처·고객, PRINT 에 거래처·고객·출하일자 추가 (사용자 지시)
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
  IN $X6_LIST MEDIUMTEXT,             -- 측정치 X6 목록
   IN $X7_LIST MEDIUMTEXT,             -- 측정치 X7 목록
   IN $X8_LIST MEDIUMTEXT,             -- 측정치 X8 목록
   IN $X9_LIST MEDIUMTEXT,             -- 측정치 X9 목록
   IN $X10_LIST MEDIUMTEXT,             -- 측정치 X10 목록
  IN $JUDGE_LIST MEDIUMTEXT,          -- 판정 목록 (Y 합격, N 불합격)
  IN $APRVEMP VARCHAR(20),            -- 승인자 (APPROVE)
  IN $SALOUTPLANKEY_LIST MEDIUMTEXT,  -- 승인할 출하계획키 목록 (APPROVE)
  IN $FORMKEY VARCHAR(20),            -- 성적서 양식키 (SAVE_FORM·DELETE_FORM·SET_PLANFORM)
  IN $FORMNM VARCHAR(100),            -- 양식명 (SAVE_FORM)
  IN $ENDCUSTCD VARCHAR(100),         -- 양식 적용 고객 (SAVE_FORM, 비우면 조건 없음)
  IN $DEFAULTYN VARCHAR(1),           -- 거래처 기본 양식 여부 (SAVE_FORM)
  IN $USEYN VARCHAR(1),               -- 양식 사용여부 (SAVE_FORM)
  IN $FILEKEY VARCHAR(100),           -- 양식 엑셀 파일키 (SAVE_FORM)
  IN $SHEETNAME VARCHAR(100),         -- 채울 시트명 (SAVE_FORM, 비우면 첫 시트)
  IN $FORMREMARK VARCHAR(1000),       -- 양식 비고 (SAVE_FORM)
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
  DECLARE _$X6_LIST MEDIUMTEXT;
  DECLARE _$X7_LIST MEDIUMTEXT;
  DECLARE _$X8_LIST MEDIUMTEXT;
  DECLARE _$X9_LIST MEDIUMTEXT;
  DECLARE _$X10_LIST MEDIUMTEXT;
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
  DECLARE _$X6 VARCHAR(100);
  DECLARE _$X7 VARCHAR(100);
  DECLARE _$X8 VARCHAR(100);
  DECLARE _$X9 VARCHAR(100);
  DECLARE _$X10 VARCHAR(100);
  DECLARE _$JUDGE VARCHAR(10);
  DECLARE _$SALOUTPLANKEY_LIST MEDIUMTEXT;
  DECLARE _$SALOUTPLANKEY VARCHAR(100);
  DECLARE _$ITEMCD VARCHAR(100);
  DECLARE _$NEWFORMKEY VARCHAR(20);
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
    , IFNULL((SELECT MSTRPTREV_HEADER.REVNUM
                FROM MSTRPTREV_HEADER
                WHERE MSTRPTREV_HEADER.REVCD = IFNULL(TQMRST.REVCD,
                      (SELECT REVH.REVCD
                         FROM MSTRPTREV_ITEM AS REVI
                         INNER JOIN MSTRPTREV_HEADER AS REVH
                           ON REVH.REVCD = REVI.REVCD
                         WHERE REVI.ITEMID = SALOUTPLAN_W.ITEMID
                           AND REVH.STDTP = 'OUTTEST'
                           AND REVH.USEYN = 'Y'
                         ORDER BY REVH.REVNUM DESC
                         LIMIT 1))), '') AS REVNUM   -- 적용 리비전 (검사 전이면 사용중인 최신 리비전)
    , SALOUTPLAN_W.CUSTCD
    , SALOUTPLAN_W.ENDCUSTCD
    , IFNULL(RFX.FORMKEY, '') AS FORMKEY   -- 이 계획에 적용되는 성적서 양식 (작업자가 고른 것, 없으면 거래처·고객·품목 규칙)
    , IFNULL(RFX.FORMNM, '') AS FORMNM    , CASE WHEN TQMRST.FINALJUDGE = 'Y' THEN 'LIGHTCYAN'
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
  LEFT JOIN MSTRPTFORM AS RFX
    ON RFX.FORMKEY = (SELECT RF.FORMKEY
                        FROM MSTRPTFORM AS RF
                        WHERE RF.USEYN = 'Y'
                          AND (RF.FORMKEY = SALOUTPLAN_W.RPTFORMKEY
                               OR (SALOUTPLAN_W.RPTFORMKEY = ''
                                   AND (RF.ITEMID = 0 OR RF.ITEMID = SALOUTPLAN_W.ITEMID)
                                   AND (RF.ENDCUSTCD = '' OR RF.ENDCUSTCD = SALOUTPLAN_W.ENDCUSTCD)
                                   AND (RF.CUSTCD = '' OR RF.CUSTCD = SALOUTPLAN_W.CUSTCD)
                                   AND (RF.ITEMID <> 0 OR RF.ENDCUSTCD <> '' OR RF.CUSTCD <> '')))
                        ORDER BY (RF.FORMKEY = SALOUTPLAN_W.RPTFORMKEY) DESC
                               , (RF.ITEMID <> 0) * 4 + (RF.ENDCUSTCD <> '') * 2 + (RF.CUSTCD <> '') DESC
                               , (RF.DEFAULTYN = 'Y') DESC
                               , RF.FORMKEY
                        LIMIT 1)
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
    , IFNULL((SELECT MSTRPTREV_HEADER.REVNUM FROM MSTRPTREV_HEADER WHERE MSTRPTREV_HEADER.REVCD = _$REVCD), '') AS REVNUM   -- 적용 리비전
    , IFNULL((SELECT LEFT(MSTRPTREV_HEADER.REGDATE, 10) FROM MSTRPTREV_HEADER WHERE MSTRPTREV_HEADER.REVCD = _$REVCD), '') AS REVDATE   -- 개정일
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
    , IFNULL(TQMRSTKND.STDVALCHK6, '') AS X6
    , IFNULL(TQMRSTKND.STDVALCHK7, '') AS X7
    , IFNULL(TQMRSTKND.STDVALCHK8, '') AS X8
    , IFNULL(TQMRSTKND.STDVALCHK9, '') AS X9
    , IFNULL(TQMRSTKND.STDVALCHK10, '') AS X10
    , IFNULL(TQMRSTKND.JUDGE, '') AS JUDGE
    , MSTRPTREV_DETAIL.REVCD
    , MSTRPTREV_DETAIL.STDCD
    , MSTRPTREV_DETAIL.PRCCD
    , MSTRPTREV_DETAIL.PRCDETAIL
    , MSTRPTREV_DETAIL.STDVAL     -- 측정 판정용 (화면 숨김)
    , MSTRPTREV_DETAIL.STDRANGE
    , MSTRPTREV_DETAIL.STDMINUS
    , MSTRPTREV_DETAIL.STDPLUS
    , MSTRPTREV_DETAIL.SAMPLESIZE  -- 시료수 (검사기준 관리 TQC1001_R02 에서 정한 값, 화면이 측정치 입력칸 수를 정하는 데 씀)
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
  SET _$X6_LIST = $X6_LIST;
  SET _$X7_LIST = $X7_LIST;
  SET _$X8_LIST = $X8_LIST;
  SET _$X9_LIST = $X9_LIST;
  SET _$X10_LIST = $X10_LIST;
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
    CALL COMSPLIT(_$X6_LIST, _$X6);
    CALL COMSPLIT(_$X7_LIST, _$X7);
    CALL COMSPLIT(_$X8_LIST, _$X8);
    CALL COMSPLIT(_$X9_LIST, _$X9);
    CALL COMSPLIT(_$X10_LIST, _$X10);
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
          , STDVALCHK6 = IFNULL(_$X6, '')
          , STDVALCHK7 = IFNULL(_$X7, '')
          , STDVALCHK8 = IFNULL(_$X8, '')
          , STDVALCHK9 = IFNULL(_$X9, '')
          , STDVALCHK10 = IFNULL(_$X10, '')
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
        , STDVALCHK6
        , STDVALCHK7
        , STDVALCHK8
        , STDVALCHK9
        , STDVALCHK10
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
        , IFNULL(_$X6, '')
        , IFNULL(_$X7, '')
        , IFNULL(_$X8, '')
        , IFNULL(_$X9, '')
        , IFNULL(_$X10, '')
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

    IF IFNULL((SELECT TQMRST.FINALJUDGE FROM TQMRST WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY), '') = 'N' THEN
      CALL COMERR(CONCAT('불합격인 출하검사는 승인할 수 없습니다.\n- 품번: ', _$ITEMCD));
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
    , IFNULL((SELECT CONCAT('Rev.', MSTRPTREV_HEADER.REVNUM) FROM MSTRPTREV_HEADER WHERE MSTRPTREV_HEADER.REVCD = TQMRST.REVCD), '') AS REVNUM_TXT   -- 적용 리비전 (그 검사의 리비전)
    , IFNULL(PC1.CUSTNM, '') AS CUSTNM         -- 거래처 (엑셀 양식 표시어 {거래처})
    , IFNULL(PC2.CUSTNM, '') AS ENDCUSTNM      -- 고객 ({고객})
    , IFNULL(SALOUTPLAN_W.OUTDATE, '') AS OUTDATE   -- 출하계획일자 ({출하일자})
  FROM TQMRST
  LEFT JOIN SALOUTPLAN_W
    ON SALOUTPLAN_W.SALOUTPLANKEY = TQMRST.SALOUTPLANKEY
  LEFT JOIN MSTCUST AS PC1
    ON PC1.CUSTCD = SALOUTPLAN_W.CUSTCD
  LEFT JOIN MSTCUST AS PC2
    ON PC2.CUSTCD = SALOUTPLAN_W.ENDCUSTCD
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
    , IFNULL(TQMRSTKND.STDVALCHK6, '') AS X6
    , IFNULL(TQMRSTKND.STDVALCHK7, '') AS X7
    , IFNULL(TQMRSTKND.STDVALCHK8, '') AS X8
    , IFNULL(TQMRSTKND.STDVALCHK9, '') AS X9
    , IFNULL(TQMRSTKND.STDVALCHK10, '') AS X10
    , MSTRPTREV_DETAIL.SAMPLESIZE  -- 시료수 (성적서 측정치 칸 수를 정하는 데 씀)
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
WHEN 'LIST_FORM' THEN  -- 성적서 양식 목록 (양식 관리 팝업)

  SELECT
      RF.FORMKEY
    , RF.FORMNM
    , RF.CUSTCD
    , IFNULL(MSTCUST1.CUSTNM, '') AS CUSTNM
    , RF.ENDCUSTCD
    , IFNULL(MSTCUST2.CUSTNM, '') AS ENDCUSTNM
    , IF(RF.ITEMID = 0, '', CAST(RF.ITEMID AS CHAR)) AS ITEMID
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , RF.DEFAULTYN
    , RF.USEYN
    , RF.FILEKEY
    , IFNULL(COMFILE.FILENAME, '') AS FILENAME
    , RF.SHEETNAME
    , RF.REMARK
  FROM MSTRPTFORM AS RF
  LEFT JOIN MSTCUST AS MSTCUST1
    ON MSTCUST1.CUSTCD = RF.CUSTCD
  LEFT JOIN MSTCUST AS MSTCUST2
    ON MSTCUST2.CUSTCD = RF.ENDCUSTCD
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = RF.ITEMID
  LEFT JOIN COMFILE
    ON COMFILE.FILEKEY = RF.FILEKEY
  ORDER BY RF.USEYN DESC, MSTCUST1.CUSTNM, RF.FORMNM;

-- ****************************************************************************
WHEN 'SAVE_FORM' THEN  -- 성적서 양식 저장 (양식키가 없으면 새로 등록, 있으면 수정)

  IF IFNULL($FORMNM, '') = '' THEN
    CALL COMERR('양식명을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($CUSTCD, '') = '' AND IFNULL($ENDCUSTCD, '') = '' AND IFNULL($ITEMID, '') = '' THEN
    CALL COMERR('적용 대상(거래처, 고객, 품목 중 하나 이상)을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($FILEKEY, '') = '' THEN
    CALL COMERR('양식 엑셀 파일을 올리세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT COMFILE.FILEKEY FROM COMFILE WHERE COMFILE.FILEKEY = $FILEKEY) THEN
    CALL COMERR('올린 양식 파일을 찾을 수 없습니다. 파일을 다시 올리세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($FORMKEY, '') = '' THEN
    SET _$NEWFORMKEY = CONCAT('F', LPAD(IFNULL((SELECT MAX(CAST(SUBSTRING(MSTRPTFORM.FORMKEY, 2) AS UNSIGNED)) FROM MSTRPTFORM), 0) + 1, 4, '0'));

    INSERT INTO MSTRPTFORM (FORMKEY, FORMNM, CUSTCD, ENDCUSTCD, ITEMID, DEFAULTYN, USEYN, FILEKEY, SHEETNAME, REMARK, RTIME, REMP, RPRG)
    VALUES (_$NEWFORMKEY, $FORMNM, IFNULL($CUSTCD, ''), IFNULL($ENDCUSTCD, ''), IFNULL(CAST(NULLIF($ITEMID, '') AS SIGNED), 0),
            IF($DEFAULTYN = 'Y', 'Y', 'N'), IF($USEYN = 'N', 'N', 'Y'), $FILEKEY, IFNULL($SHEETNAME, ''), IFNULL($FORMREMARK, ''),
            CALLTIME(), CALLEMP(), CALLPRG());
  ELSE
    IF NOT EXISTS (SELECT MSTRPTFORM.FORMKEY FROM MSTRPTFORM WHERE MSTRPTFORM.FORMKEY = $FORMKEY) THEN
      CALL COMERR('수정할 양식을 찾을 수 없습니다.');
      LEAVE PROC;
    END IF;

    SET _$NEWFORMKEY = $FORMKEY;

    UPDATE MSTRPTFORM
      SET FORMNM = $FORMNM
        , CUSTCD = IFNULL($CUSTCD, '')
        , ENDCUSTCD = IFNULL($ENDCUSTCD, '')
        , ITEMID = IFNULL(CAST(NULLIF($ITEMID, '') AS SIGNED), 0)
        , DEFAULTYN = IF($DEFAULTYN = 'Y', 'Y', 'N')
        , USEYN = IF($USEYN = 'N', 'N', 'Y')
        , FILEKEY = $FILEKEY
        , SHEETNAME = IFNULL($SHEETNAME, '')
        , REMARK = IFNULL($FORMREMARK, '')
        , MTIME = CALLTIME()
        , MEMP = CALLEMP()
        , MPRG = CALLPRG()
      WHERE MSTRPTFORM.FORMKEY = _$NEWFORMKEY;
  END IF;

  -- 거래처 기본 양식은 거래처마다 하나만
  IF $DEFAULTYN = 'Y' AND IFNULL($CUSTCD, '') <> '' THEN
    UPDATE MSTRPTFORM
      SET DEFAULTYN = 'N'
        , MTIME = CALLTIME()
        , MEMP = CALLEMP()
        , MPRG = CALLPRG()
      WHERE MSTRPTFORM.CUSTCD = $CUSTCD
        AND MSTRPTFORM.FORMKEY <> _$NEWFORMKEY
        AND MSTRPTFORM.DEFAULTYN = 'Y';
  END IF;

  SELECT _$NEWFORMKEY AS FORMKEY;

-- ****************************************************************************
WHEN 'DELETE_FORM' THEN  -- 성적서 양식 삭제 (계획에서 고른 양식은 자동 선택으로 되돌림)

  IF IFNULL($FORMKEY, '') = '' THEN
    CALL COMERR('삭제할 양식을 선택하세요.');
    LEAVE PROC;
  END IF;

  UPDATE SALOUTPLAN_W
    SET RPTFORMKEY = ''
    WHERE SALOUTPLAN_W.RPTFORMKEY = $FORMKEY;

  DELETE FROM MSTRPTFORM
    WHERE MSTRPTFORM.FORMKEY = $FORMKEY;

-- ****************************************************************************
WHEN 'SET_PLANFORM' THEN  -- 출하계획에 성적서 양식 지정 (양식키가 비면 자동 선택으로)

  IF IFNULL($SALOUTPLANKEY, '') = '' THEN
    CALL COMERR('출하계획을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($FORMKEY, '') <> '' AND NOT EXISTS (SELECT MSTRPTFORM.FORMKEY FROM MSTRPTFORM WHERE MSTRPTFORM.FORMKEY = $FORMKEY) THEN
    CALL COMERR('선택한 양식을 찾을 수 없습니다.');
    LEAVE PROC;
  END IF;

  UPDATE SALOUTPLAN_W
    SET RPTFORMKEY = IFNULL($FORMKEY, '')
      , MTIME = CALLTIME()
      , MEMP = CALLEMP()
      , MPRG = CALLPRG()
    WHERE SALOUTPLAN_W.SALOUTPLANKEY = $SALOUTPLANKEY;

-- ****************************************************************************
WHEN 'FORM_INFO' THEN  -- 출력용: 이 출하계획에 적용되는 엑셀 양식 (없으면 FORMKEY 빈값 → 기본 양식으로 출력). 리포트 TQM1002.exe 가 호출
  SELECT
      IFNULL(RFX.FORMKEY, '') AS FORMKEY
    , IFNULL(RFX.FORMNM, '') AS FORMNM
    , IFNULL(COMFILE.FILEPATH, '') AS FILEPATH
    , IFNULL(RFX.SHEETNAME, '') AS SHEETNAME
  FROM SALOUTPLAN_W
  LEFT JOIN MSTRPTFORM AS RFX
    ON RFX.FORMKEY = (SELECT RF.FORMKEY
                        FROM MSTRPTFORM AS RF
                        WHERE RF.USEYN = 'Y'
                          AND (RF.FORMKEY = SALOUTPLAN_W.RPTFORMKEY
                               OR (SALOUTPLAN_W.RPTFORMKEY = ''
                                   AND (RF.ITEMID = 0 OR RF.ITEMID = SALOUTPLAN_W.ITEMID)
                                   AND (RF.ENDCUSTCD = '' OR RF.ENDCUSTCD = SALOUTPLAN_W.ENDCUSTCD)
                                   AND (RF.CUSTCD = '' OR RF.CUSTCD = SALOUTPLAN_W.CUSTCD)
                                   AND (RF.ITEMID <> 0 OR RF.ENDCUSTCD <> '' OR RF.CUSTCD <> '')))
                        ORDER BY (RF.FORMKEY = SALOUTPLAN_W.RPTFORMKEY) DESC
                               , (RF.ITEMID <> 0) * 4 + (RF.ENDCUSTCD <> '') * 2 + (RF.CUSTCD <> '') DESC
                               , (RF.DEFAULTYN = 'Y') DESC
                               , RF.FORMKEY
                        LIMIT 1)
  LEFT JOIN COMFILE
    ON COMFILE.FILEKEY = RFX.FILEKEY
  WHERE SALOUTPLAN_W.SALOUTPLANKEY = IFNULL($SALOUTPLANKEY, '');

-- ****************************************************************************
END CASE;
-- *****************************************************************************
END