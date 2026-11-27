CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TAL2001_R01(
-- *****************************************************************************
-- Comment: 자주검사 등록 (태블릿)
-- Create: 2026-10-30 신정수
-- Modify: 2026-11-02 검사결과 저장(SAVE_RST) 추가
-- Modify: 2026-11-02 검사일시 검사이력 조회(LIST_STD 결과값, LIST_VALUE) 추가
-- Modify: 2026-11-02 이미 저장된 검사항목은 수정(SAVE_RST)
-- Modify: 2026-11-26 LIST_STD 검사주기(STDCYCLE)별로 이번 주기에 검사한 항목은 숨김 (TML2010 자주검사 팝업도 같이 적용)
--                    1회/1hr(4) 정시 1시간, 1회/2hr(2) 근무조 시작부터 2시간, 1회/shift(5) 근무조, 3회/shift(1) 근무조 3번, 1회/1일(6) 작업일
--                    공구교환(7)·시업시(8)·그 밖은 항상 표시. 이 검사일시에 저장한 항목은 수정할 수 있게 항상 표시
--                    L/R 유무(LRYN), 검사값(결과셋 2) 추가 (태블릿 그리드 하나 입력)
--                    0. 생산품 결과에 자주검사 리비전번호 REVNUM 추가 (화면 표시)
--                    진행(CYCLEINFO) 모든 주기: 근무조(1회/1일은 작업일) 안 횟수 / 해야 할 횟수 (1hr = 근무조 시간 수, 2hr = 그 절반, 3회/shift = 3, 1회 = 1)
-- *****************************************************************************
  IN $LINECD VARCHAR(100),     -- 작업장
  IN $PRCCD VARCHAR(100),      -- 공정
  IN $EQMCD VARCHAR(100),      -- 라인
  IN $ITEMID VARCHAR(20),      -- 생산품ID
  IN $REVCD VARCHAR(100),      -- 자주검사 리비전
  IN $STDCD VARCHAR(100),      -- 검사항목코드
  IN $STDPART VARCHAR(100),    -- 세부항목
  IN $PRCDETAIL VARCHAR(100),  -- 세부공정
  IN $SAMPLESIZE VARCHAR(20),  -- 시료수
  IN $TQMDATE VARCHAR(10),     -- 검사일자 (화면 입력)
  IN $TQMTIME VARCHAR(5),      -- 검사시간 (HH:mm)
  IN $EMPCD VARCHAR(100),      -- 검사자
  IN $JUDGE VARCHAR(1),        -- 합불판정 (Y 합격, N 불합격)
  IN $SEQ_LIST MEDIUMTEXT,     -- 검사값 행 순번 목록
  IN $VALUE_LIST MEDIUMTEXT,   -- 검사값(L) 목록
  IN $VALUE2_LIST MEDIUMTEXT,  -- 검사값(R) 목록
  IN $TQMRSTKEY VARCHAR(100),  -- 검사키 (검사값 조회)
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
  -- *****************************************************************************
-- SET @DEBUGLOGYN = 'Y';
  DECLARE _$ITEMID INT(11);
  DECLARE _$REVCD VARCHAR(100);
  DECLARE _$TQMDATE VARCHAR(10);
  DECLARE _$FIXTIME VARCHAR(19);
  DECLARE _$TQMRSTKEY VARCHAR(100);
  DECLARE _$SEQ VARCHAR(20);
  DECLARE _$VALUE VARCHAR(100);
  DECLARE _$VALUE2 VARCHAR(100);
  DECLARE _$DAYST VARCHAR(5);        -- 주간 시작 (PP161100N.REF01)
  DECLARE _$NIGHTST VARCHAR(5);      -- 야간 시작 (PP161102N.REF01)
  DECLARE _$CHKTIME DATETIME;        -- 화면 검사일시
  DECLARE _$WORKDATE DATE;           -- 작업일
  DECLARE _$SHIFTST VARCHAR(19);     -- 근무조 시작·끝
  DECLARE _$SHIFTED VARCHAR(19);
  DECLARE _$DAYSTART VARCHAR(19);    -- 작업일 시작·끝
  DECLARE _$DAYEND VARCHAR(19);
  DECLARE _$HOURST VARCHAR(19);      -- 정시 1시간 시작·끝
  DECLARE _$HOURED VARCHAR(19);
  DECLARE _$HOUR2ST VARCHAR(19);     -- 근무조 시작부터 2시간 칸 시작·끝
  DECLARE _$HOUR2ED VARCHAR(19);
  DECLARE _$NIGHTED VARCHAR(5);      -- 야간 종료 (PP161102N.REF02)
  DECLARE _$SHIFTHRS INT DEFAULT 0;  -- 근무조 시간 수 (1회/1hr 진행 분모)
-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_STD' THEN  -- 라인 생산품, 현재 사용중인 자주검사 리비전의 검사항목 조회

  IF $LINECD = '' THEN
    CALL COMERR('작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT PRDLINEITEM.ITEMID
                   FROM PRDLINEITEM
                  WHERE PRDLINEITEM.LINECD = $LINECD
                    AND PRDLINEITEM.PRCCD = $PRCCD
                    AND PRDLINEITEM.EQMCD = $EQMCD) THEN
    CALL COMERR('해당 라인에 생산중인 품목이 없습니다.');
    LEAVE PROC;
  END IF;

  -- 라인 생산품 (생산실적등록 TML2010 에서 선택한 품목)
  SET _$ITEMID = IFNULL((SELECT PRDLINEITEM.ITEMID
                           FROM PRDLINEITEM
                          WHERE PRDLINEITEM.LINECD = $LINECD
                            AND PRDLINEITEM.PRCCD = $PRCCD
                            AND PRDLINEITEM.EQMCD = $EQMCD), 0);

  -- 생산품의 사용중인 자주검사 리비전
  SET _$REVCD = IFNULL((SELECT MSTRPTREV_HEADER.REVCD
                          FROM MSTRPTREV_ITEM
                          INNER JOIN MSTRPTREV_HEADER
                            ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_ITEM.REVCD
                         WHERE MSTRPTREV_ITEM.ITEMID = _$ITEMID
                           AND MSTRPTREV_HEADER.STDTP = 'PRCTEST'
                           AND MSTRPTREV_HEADER.USEYN = 'Y'
                         ORDER BY MSTRPTREV_HEADER.REVNUM DESC
                         LIMIT 1), '');

  IF _$REVCD = '' THEN
    CALL COMERR('사용중인 자주검사 기준이 없습니다.\n검사표준관리에서 검사기준을 등록하세요.');
    LEAVE PROC;
  END IF;

  -- 화면 검사일시의 검사이력 헤더 (저장 SAVE_RST 와 같은 기준, 검사시간이 HH:mm 이 아니면 이력 없음)
  SET _$TQMRSTKEY = '';
  IF $TQMDATE <> '' AND $TQMTIME REGEXP '^([01][0-9]|2[0-3]):[0-5][0-9]$' THEN
    SET _$FIXTIME = CONCAT($TQMDATE, ' ', $TQMTIME, ':00');
    SET _$TQMRSTKEY = IFNULL((SELECT TQMRST.TQMRSTKEY
                                FROM TQMRST
                               WHERE TQMRST.REVCD = _$REVCD
                                 AND TQMRST.LINECD = $EQMCD
                                 AND TQMRST.ITEMID = _$ITEMID
                                 AND TQMRST.FIXTIME = _$FIXTIME
                               LIMIT 1), '');
  END IF;

  -- 2026-11-26 검사주기 기간 (화면 검사일시 기준. 검사시간이 HH:mm 이 아니면 주기 확인 안 함)
  -- 근무조: 주간 = 주간시작~야간시작, 야간 = 야간시작~다음날 주간시작 (주간시작 전 새벽은 전날 작업일의 야간)
  SET _$CHKTIME = NULL;
  IF $TQMDATE <> '' AND $TQMTIME REGEXP '^([01][0-9]|2[0-3]):[0-5][0-9]$' THEN
    SET _$CHKTIME = STR_TO_DATE(CONCAT($TQMDATE, ' ', $TQMTIME, ':00'), '%Y-%m-%d %H:%i:%s');
    SET _$DAYST = IFNULL(NULLIF((SELECT COMTYPE.REF01 FROM COMTYPE WHERE COMTYPE.GPCD = 'PP161' AND COMTYPE.TPCD = 'PP161100N'), ''), '06:00');
    SET _$NIGHTST = IFNULL(NULLIF((SELECT COMTYPE.REF01 FROM COMTYPE WHERE COMTYPE.GPCD = 'PP161' AND COMTYPE.TPCD = 'PP161102N'), ''), '16:00');

    SET _$WORKDATE = IF($TQMTIME < _$DAYST, DATE_SUB(DATE($TQMDATE), INTERVAL 1 DAY), DATE($TQMDATE));

    SET _$DAYSTART = CONCAT(DATE_FORMAT(_$WORKDATE, '%Y-%m-%d'), ' ', _$DAYST, ':00');
    SET _$DAYEND = CONCAT(DATE_FORMAT(DATE_ADD(_$WORKDATE, INTERVAL 1 DAY), '%Y-%m-%d'), ' ', _$DAYST, ':00');

    IF $TQMTIME >= _$DAYST AND $TQMTIME < _$NIGHTST THEN
      SET _$SHIFTST = _$DAYSTART;
      SET _$SHIFTED = CONCAT(DATE_FORMAT(_$WORKDATE, '%Y-%m-%d'), ' ', _$NIGHTST, ':00');
    ELSE
      SET _$SHIFTST = CONCAT(DATE_FORMAT(_$WORKDATE, '%Y-%m-%d'), ' ', _$NIGHTST, ':00');
      SET _$SHIFTED = _$DAYEND;
    END IF;

    SET _$HOURST = DATE_FORMAT(_$CHKTIME, '%Y-%m-%d %H:00:00');
    SET _$HOURED = DATE_FORMAT(DATE_ADD(_$CHKTIME, INTERVAL 1 HOUR), '%Y-%m-%d %H:00:00');

    SET _$HOUR2ST = DATE_FORMAT(DATE_ADD(STR_TO_DATE(_$SHIFTST, '%Y-%m-%d %H:%i:%s')
                                       , INTERVAL FLOOR(TIMESTAMPDIFF(MINUTE, STR_TO_DATE(_$SHIFTST, '%Y-%m-%d %H:%i:%s'), _$CHKTIME) / 120) * 120 MINUTE)
                              , '%Y-%m-%d %H:%i:%s');
    SET _$HOUR2ED = DATE_FORMAT(DATE_ADD(STR_TO_DATE(_$HOUR2ST, '%Y-%m-%d %H:%i:%s'), INTERVAL 120 MINUTE), '%Y-%m-%d %H:%i:%s');

    -- 근무조 시간 수: 주간 = 주간시작~야간시작, 야간 = 야간시작~야간종료(PP161102N.REF02) (2026-11-26 진행 표시)
    SET _$NIGHTED = IFNULL(NULLIF((SELECT COMTYPE.REF02 FROM COMTYPE WHERE COMTYPE.GPCD = 'PP161' AND COMTYPE.TPCD = 'PP161102N'), ''), '02:00');
    IF $TQMTIME >= _$DAYST AND $TQMTIME < _$NIGHTST THEN
      SET _$SHIFTHRS = FLOOR(MOD(TIME_TO_SEC(CONCAT(_$NIGHTST, ':00')) - TIME_TO_SEC(CONCAT(_$DAYST, ':00')) + 86400, 86400) / 3600);
    ELSE
      SET _$SHIFTHRS = FLOOR(MOD(TIME_TO_SEC(CONCAT(_$NIGHTED, ':00')) - TIME_TO_SEC(CONCAT(_$NIGHTST, ':00')) + 86400, 86400) / 3600);
    END IF;
  END IF;

  -- 0. 생산품
  SELECT
      CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IFNULL((SELECT CAST(MSTRPTREV_HEADER.REVNUM AS SIGNED) FROM MSTRPTREV_HEADER WHERE MSTRPTREV_HEADER.REVCD = _$REVCD), '') AS REVNUM   -- 2026-11-26 자주검사 리비전번호 (화면 표시)
  FROM MSTITEM
  WHERE MSTITEM.ITEMID = _$ITEMID
  ;

  -- 1. 검사항목 (사용중인 자주검사 리비전)
  --    2026-11-26 이번 주기에 이미 검사한 항목은 숨김 (아래 바깥 WHERE). DONECNT = 이 검사일시를 뺀 이번 주기 검사 횟수
  SELECT A.*
       , CASE WHEN _$CHKTIME IS NULL THEN ''
              WHEN A.STDCYCLE = '4' THEN CONCAT(A.PERIODCNT, '/', _$SHIFTHRS)           -- 1회/1hr: 근무조 안 횟수 / 근무조 시간 수
              WHEN A.STDCYCLE = '2' THEN CONCAT(A.PERIODCNT, '/', FLOOR(_$SHIFTHRS / 2)) -- 1회/2hr
              WHEN A.STDCYCLE = '1' THEN CONCAT(A.PERIODCNT, '/3')                        -- 3회/shift
              WHEN A.STDCYCLE IN ('5', '6') THEN CONCAT(A.PERIODCNT, '/1')                -- 1회/shift, 1회/1일(작업일)
         ELSE '' END AS CYCLEINFO   -- 진행 (2026-11-26 모든 주기, 공구교환·시업시 제외)
  FROM (
  SELECT
      MSTRPTREV_DETAIL.SORTNO
    , MSTRPTREV_DETAIL.STDNM
    , MSTRPTREV_DETAIL.STDPART
    , MSTRPTREV_DETAIL.FEATURE
    , MSTRPTREV_DETAIL.STDCHKTP
    , MSTRPTREV_DETAIL.STDMACHINE
    , MSTRPTREV_DETAIL.STDPOINT
    , MSTRPTREV_DETAIL.STDCYCLE
    , CASE
        WHEN MSTRPTREV_DETAIL.STDCHKTP = '02' THEN FIND_STDJUDGE_MEASURE(MSTRPTREV_DETAIL.STDRANGE, MSTRPTREV_DETAIL.STDVAL, MSTRPTREV_DETAIL.STDUNIT, MSTRPTREV_DETAIL.STDMINUS, MSTRPTREV_DETAIL.STDPLUS)
      ELSE MSTRPTREV_DETAIL.STDJUDGE END AS STDJUDGE  -- 판정기준 (측정이면 기준값·공차로 생성)
    , MSTRPTREV_DETAIL.SAMPLESIZE
    , MSTRPTREV_DETAIL.REVCD
    , MSTRPTREV_DETAIL.STDCD
    , MSTRPTREV_DETAIL.PRCDETAIL
    , MSTRPTREV_DETAIL.STDVAL     -- 측정 판정용 (화면 숨김)
    , MSTRPTREV_DETAIL.STDRANGE
    , MSTRPTREV_DETAIL.STDMINUS
    , MSTRPTREV_DETAIL.STDPLUS
    , IFNULL(TQMRSTKND.MINVAL, '') AS MINVAL    -- 검사이력 (없으면 빈칸)
    , IFNULL(TQMRSTKND.MAXVAL, '') AS MAXVAL
    , IFNULL(TQMRSTKND.AVG, '') AS AVG
    , IFNULL(TQMRSTKND.JUDGE, '') AS JUDGE
    , CASE TQMRSTKND.JUDGE WHEN 'Y' THEN '합격' WHEN 'N' THEN '불합격' ELSE '' END AS JUDGENM
    , IFNULL(TQMRSTKND.TQMRSTKEY, '') AS TQMRSTKEY
    , MSTRPTREV_DETAIL.LRYN       -- L/R 유무 (Y 면 검사값 L·R 둘 다)
    , CASE WHEN _$CHKTIME IS NULL THEN 0
           ELSE (SELECT COUNT(*)
                   FROM TQMRSTKND K
                   INNER JOIN TQMRST H
                     ON H.TQMRSTKEY = K.TQMRSTKEY
                  WHERE H.LINECD = $EQMCD
                    AND H.FIXTIME <> _$FIXTIME
                    AND H.FIXTIME >= CASE MSTRPTREV_DETAIL.STDCYCLE WHEN '4' THEN _$HOURST WHEN '2' THEN _$HOUR2ST WHEN '6' THEN _$DAYSTART ELSE _$SHIFTST END
                    AND H.FIXTIME <  CASE MSTRPTREV_DETAIL.STDCYCLE WHEN '4' THEN _$HOURED WHEN '2' THEN _$HOUR2ED WHEN '6' THEN _$DAYEND ELSE _$SHIFTED END
                    AND K.STDCD = MSTRPTREV_DETAIL.STDCD
                    AND K.PRCCD = $PRCCD
                    AND K.STDPART = MSTRPTREV_DETAIL.STDPART
                    AND K.PRCDETAIL = MSTRPTREV_DETAIL.PRCDETAIL)
      END AS DONECNT
    , CASE WHEN _$CHKTIME IS NULL THEN 0
           ELSE (SELECT COUNT(*)
                   FROM TQMRSTKND K
                   INNER JOIN TQMRST H
                     ON H.TQMRSTKEY = K.TQMRSTKEY
                  WHERE H.LINECD = $EQMCD
                    AND H.FIXTIME >= IF(MSTRPTREV_DETAIL.STDCYCLE = '6', _$DAYSTART, _$SHIFTST)
                    AND H.FIXTIME <  IF(MSTRPTREV_DETAIL.STDCYCLE = '6', _$DAYEND, _$SHIFTED)
                    AND K.STDCD = MSTRPTREV_DETAIL.STDCD
                    AND K.PRCCD = $PRCCD
                    AND K.STDPART = MSTRPTREV_DETAIL.STDPART
                    AND K.PRCDETAIL = MSTRPTREV_DETAIL.PRCDETAIL)
      END AS PERIODCNT   -- 진행 표시용: 근무조(1회/1일은 작업일) 안 검사 횟수 (이 검사일시 포함)
  FROM MSTRPTREV_DETAIL
  LEFT JOIN TQMRSTKND
    ON TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
   AND TQMRSTKND.STDCD = MSTRPTREV_DETAIL.STDCD
   AND TQMRSTKND.PRCCD = $PRCCD
   AND TQMRSTKND.STDPART = MSTRPTREV_DETAIL.STDPART
   AND TQMRSTKND.PRCDETAIL = MSTRPTREV_DETAIL.PRCDETAIL
  WHERE MSTRPTREV_DETAIL.REVCD = _$REVCD
  ) A
  WHERE A.TQMRSTKEY <> ''                                        -- 이 검사일시에 저장한 항목은 수정할 수 있게 표시
     OR (A.STDCYCLE IN ('4', '2', '5', '6') AND A.DONECNT = 0)  -- 1회/1hr·1회/2hr·1회/shift·1회/1일: 이번 주기에 안 했으면
     OR (A.STDCYCLE = '1' AND A.DONECNT < 3)                    -- 3회/shift: 근무조에 3번 안 했으면
     OR A.STDCYCLE NOT IN ('4', '2', '5', '6', '1')             -- 공구교환(7)·시업시(8)·그 밖: 항상
  ORDER BY A.SORTNO
  ;

  -- 2. 이 검사일시에 저장한 검사값 (태블릿 그리드에 시료 순서대로 채움, 2026-11-26)
  SELECT
      TQMRST_VALUE.STDCD
    , TQMRST_VALUE.STDPART
    , TQMRST_VALUE.PRCDETAIL
    , TQMRST_VALUE.VALUE
    , TQMRST_VALUE.VALUE2
  FROM TQMRST_VALUE
  WHERE TQMRST_VALUE.TQMRSTKEY = _$TQMRSTKEY
    AND TQMRST_VALUE.PRCCD = $PRCCD
  ORDER BY TQMRST_VALUE.STDCD, TQMRST_VALUE.STDPART, TQMRST_VALUE.PRCDETAIL, TQMRST_VALUE.VALUEKEY
  ;

-- ****************************************************************************
WHEN 'LIST_VALUE' THEN  -- 저장된 검사항목의 시료 검사값 (검사항목 선택)

  SELECT
      TQMRST_VALUE.VALUE
    , TQMRST_VALUE.VALUE2
    , TQMRST_VALUE.VALUEKEY
  FROM TQMRST_VALUE
  WHERE TQMRST_VALUE.TQMRSTKEY = $TQMRSTKEY
    AND TQMRST_VALUE.STDCD = $STDCD
    AND TQMRST_VALUE.PRCCD = $PRCCD
    AND TQMRST_VALUE.STDPART = $STDPART
    AND TQMRST_VALUE.PRCDETAIL = $PRCDETAIL
  ORDER BY TQMRST_VALUE.VALUEKEY
  ;

-- ****************************************************************************
WHEN 'SAVE_RST' THEN  -- 검사항목 검사결과·검사값 저장 (저장 버튼)

  IF $LINECD = '' OR $PRCCD = '' OR $EQMCD = '' THEN
    CALL COMERR('작업장, 공정, 라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $ITEMID = '' OR $REVCD = '' THEN
    CALL COMERR('생산품의 자주검사 기준이 없습니다.');
    LEAVE PROC;
  END IF;

  IF $STDCD = '' THEN
    CALL COMERR('검사항목을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $TQMDATE = '' THEN
    CALL COMERR('검사일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF NOT $TQMTIME REGEXP '^([01][0-9]|2[0-3]):[0-5][0-9]$' THEN
    CALL COMERR('검사시간을 HH:mm 형식으로 입력하세요.');
    LEAVE PROC;
  END IF;

  IF $EMPCD = '' THEN
    CALL COMERR('검사자를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $JUDGE NOT IN ('Y', 'N') THEN
    CALL COMERR('합격 또는 불합격을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 검사일자(TQMDATE)는 작업일 기준: 검사시간이 야간 종료시간(PP161102N.REF02)보다 이르면 전날
  IF $TQMTIME < (SELECT COMTYPE.REF02 FROM COMTYPE WHERE COMTYPE.GPCD = 'PP161' AND COMTYPE.TPCD = 'PP161102N') THEN
    SET _$TQMDATE = DATE_FORMAT(DATE_SUB($TQMDATE, INTERVAL 1 DAY), '%Y-%m-%d');
  ELSE
    SET _$TQMDATE = $TQMDATE;
  END IF;

  -- 검사확정시간(FIXTIME)은 화면에 입력한 일자·시간 그대로
  SET _$FIXTIME = CONCAT($TQMDATE, ' ', $TQMTIME, ':00');

  -- 같은 검사일시·라인·품목·리비전의 헤더가 있으면 그 헤더에 항목 추가
  SET _$TQMRSTKEY = IFNULL((SELECT TQMRST.TQMRSTKEY
                              FROM TQMRST
                             WHERE TQMRST.REVCD = $REVCD
                               AND TQMRST.LINECD = $EQMCD
                               AND TQMRST.ITEMID = $ITEMID
                               AND TQMRST.FIXTIME = _$FIXTIME
                             LIMIT 1), '');

  -- 헤더 (라인코드 = 화면 라인 EQMCD)
  IF _$TQMRSTKEY = '' THEN
    SET _$TQMRSTKEY = GETKEY('TQMRSTKEY');

    INSERT INTO TQMRST (
        TQMRSTKEY
      , REVCD
      , TQMDATE
      , LINECD
      , ITEMID
      , EMPCD
      , FIXTIME
      , RTIME, REMP, RPRG
    )
    VALUES (
        _$TQMRSTKEY
      , $REVCD
      , _$TQMDATE
      , $EQMCD
      , $ITEMID
      , $EMPCD
      , _$FIXTIME
      , CALLTIME(), CALLEMP(), CALLPRG()
    );
  END IF;

  -- 검사항목 결과 (같은 헤더에 이미 저장된 항목이면 수정)
  IF EXISTS (SELECT TQMRSTKND.TQMRSTKEY
               FROM TQMRSTKND
              WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
                AND TQMRSTKND.STDCD = $STDCD
                AND TQMRSTKND.PRCCD = $PRCCD
                AND TQMRSTKND.STDPART = $STDPART
                AND TQMRSTKND.PRCDETAIL = $PRCDETAIL) THEN
    UPDATE TQMRSTKND
    SET JUDGE = $JUDGE
      , SAMPLESIZE = IF($SAMPLESIZE = '', 0, $SAMPLESIZE)
      , MTIME = CALLTIME()
      , MEMP = CALLEMP()
      , MPRG = CALLPRG()
    WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
      AND TQMRSTKND.STDCD = $STDCD
      AND TQMRSTKND.PRCCD = $PRCCD
      AND TQMRSTKND.STDPART = $STDPART
      AND TQMRSTKND.PRCDETAIL = $PRCDETAIL;

    -- 기존 검사값은 지우고 화면 값으로 다시 저장
    DELETE FROM TQMRST_VALUE
    WHERE TQMRST_VALUE.TQMRSTKEY = _$TQMRSTKEY
      AND TQMRST_VALUE.STDCD = $STDCD
      AND TQMRST_VALUE.PRCCD = $PRCCD
      AND TQMRST_VALUE.STDPART = $STDPART
      AND TQMRST_VALUE.PRCDETAIL = $PRCDETAIL;
  ELSE
    INSERT INTO TQMRSTKND (
        TQMRSTKEY
      , STDCD
      , STDPART
      , PRCCD
      , PRCDETAIL
      , JUDGE
      , SAMPLESIZE
      , RTIME, REMP, RPRG
    )
    VALUES (
        _$TQMRSTKEY
      , $STDCD
      , $STDPART
      , $PRCCD
      , $PRCDETAIL
      , $JUDGE
      , IF($SAMPLESIZE = '', 0, $SAMPLESIZE)
      , CALLTIME(), CALLEMP(), CALLPRG()
    );
  END IF;

  -- 시료 검사값 (L·R 둘 다 빈 행은 저장 안 함)
  WHILE LENGTH($SEQ_LIST) > 0 DO
    CALL COMSPLIT($SEQ_LIST, _$SEQ);
    CALL COMSPLIT($VALUE_LIST, _$VALUE);
    CALL COMSPLIT($VALUE2_LIST, _$VALUE2);

    IF TRIM(_$VALUE) <> '' OR TRIM(_$VALUE2) <> '' THEN
      INSERT INTO TQMRST_VALUE (
          VALUEKEY
        , REVCD
        , STDCD
        , STDPART
        , PRCCD
        , PRCDETAIL
        , VALUE
        , VALUE2
        , TQMRSTKEY
        , EQMCD
        , RTIME, REMP, RPRG
      )
      VALUES (
          GETKEY('VALUEKEY')
        , $REVCD
        , $STDCD
        , $STDPART
        , $PRCCD
        , $PRCDETAIL
        , TRIM(_$VALUE)
        , TRIM(_$VALUE2)
        , _$TQMRSTKEY
        , $EQMCD
        , CALLTIME(), CALLEMP(), CALLPRG()
      );
    END IF;
  END WHILE;

  -- 검사값 최소·최대·평균 (L·R 중 숫자 값만, 평균은 소수 4자리 반올림, 숫자 값이 없으면 빈값)
  UPDATE TQMRSTKND
  INNER JOIN (SELECT MIN(A.VAL) AS MINVAL
                   , MAX(A.VAL) AS MAXVAL
                   , ROUND(AVG(A.VAL), 4) AS AVGVAL
                FROM (SELECT CAST(TQMRST_VALUE.VALUE AS DECIMAL(20, 8)) AS VAL
                        FROM TQMRST_VALUE
                       WHERE TQMRST_VALUE.TQMRSTKEY = _$TQMRSTKEY
                         AND TQMRST_VALUE.STDCD = $STDCD
                         AND TQMRST_VALUE.PRCCD = $PRCCD
                         AND TQMRST_VALUE.STDPART = $STDPART
                         AND TQMRST_VALUE.PRCDETAIL = $PRCDETAIL
                         AND TQMRST_VALUE.VALUE REGEXP '^-?[0-9]+(\\.[0-9]+)?$'
                      UNION ALL
                      SELECT CAST(TQMRST_VALUE.VALUE2 AS DECIMAL(20, 8)) AS VAL
                        FROM TQMRST_VALUE
                       WHERE TQMRST_VALUE.TQMRSTKEY = _$TQMRSTKEY
                         AND TQMRST_VALUE.STDCD = $STDCD
                         AND TQMRST_VALUE.PRCCD = $PRCCD
                         AND TQMRST_VALUE.STDPART = $STDPART
                         AND TQMRST_VALUE.PRCDETAIL = $PRCDETAIL
                         AND TQMRST_VALUE.VALUE2 REGEXP '^-?[0-9]+(\\.[0-9]+)?$') A) S
  SET TQMRSTKND.MINVAL = IFNULL(TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM S.MINVAL)), '')  -- 뒤의 0 제거 (12.50000000 → 12.5)
    , TQMRSTKND.MAXVAL = IFNULL(TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM S.MAXVAL)), '')
    , TQMRSTKND.AVG = IFNULL(TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM S.AVGVAL)), '')
  WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
    AND TQMRSTKND.STDCD = $STDCD
    AND TQMRSTKND.PRCCD = $PRCCD
    AND TQMRSTKND.STDPART = $STDPART
    AND TQMRSTKND.PRCDETAIL = $PRCDETAIL;

  -- 종합판정: 불합격 항목이 하나라도 있으면 N
  UPDATE TQMRST
  SET FINALJUDGE = IF(EXISTS (SELECT TQMRSTKND.TQMRSTKEY
                                FROM TQMRSTKND
                               WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
                                 AND TQMRSTKND.JUDGE = 'N'), 'N', 'Y')
    , MTIME = CALLTIME()
    , MEMP = CALLEMP()
    , MPRG = CALLPRG()
  WHERE TQMRST.TQMRSTKEY = _$TQMRSTKEY;

  -- 저장한 검사항목 결과 (화면 검사항목 줄에 표시)
  SELECT
      TQMRSTKND.TQMRSTKEY
    , TQMRSTKND.MINVAL
    , TQMRSTKND.MAXVAL
    , TQMRSTKND.AVG
    , TQMRSTKND.JUDGE
    , CASE TQMRSTKND.JUDGE WHEN 'Y' THEN '합격' WHEN 'N' THEN '불합격' ELSE '' END AS JUDGENM
  FROM TQMRSTKND
  WHERE TQMRSTKND.TQMRSTKEY = _$TQMRSTKEY
    AND TQMRSTKND.STDCD = $STDCD
    AND TQMRSTKND.PRCCD = $PRCCD
    AND TQMRSTKND.STDPART = $STDPART
    AND TQMRSTKND.PRCDETAIL = $PRCDETAIL
  ;

-- ******************************************************************************************************************
END CASE;  END