CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML2050_R01(
-- *****************************************************************************
-- Comment: 생산기술팀 호출 (POP)
-- Create: 2026-10-22
-- Modify: 2026-10-22 설비구분/라인 조회, 호출 등록(ADD_CALL) 추가
--         2026-10-22 현황판 진행 중 호출(LIST_CALL) 추가
--         2026-10-22 설비코드를 MSTEQM.FANO 기준으로 수정 (MSTEQM 에 EQMCD/EQMNO 없음)
--         2026-10-22 호출자 목록(LIST_CALLEMP) 추가, 호출자는 MSTEQM_CALLEMP 등록 사원만 허용
--         2026-10-22 현황판(LIST_CALL)을 호출설비(EQMCALLEMP_EQM.EQMCD) 단위로 변경
--         2026-10-22 호출 취소(DEL_CALL) 추가 - 호출이력 삭제 방식
--         2026-10-22 호출이유 목록(LIST_REASON) 추가 - 작업장별 비가동코드(MSTNON)
--         2026-10-22 작업장 목록(LIST_LINE) 추가 - 외주 작업장(OSCCUSTCD 있음) 제외, $FACTORYCD 파라미터 추가
--         2026-10-22 도착(LIST_ARRVEMP, ADD_ARRIVE) 추가, $EMPCD_LIST 파라미터 추가
--                    현황판에 도착자/도착 후 경과시간 추가
--         2026-10-22 호출 등록(ADD_CALL)을 설비 1대당 호출 1건으로 변경 (도착/수리를 설비 단위로)
--         2026-10-22 수리시작(LIST_REPEMP, ADD_REPAIR) 추가 - 호출 기준 / 직접 수리
--                    현황판에 직접 수리 중인 설비, 수리자, 수리 후 경과시간 추가
--         2026-10-22 수리종료(END_REPAIR), 이력조회(LIST_HISTORY) 추가
--                    $EQMREPKEY, $MALFUNCTION, $ISSUE, $HANDLE, $SDATE, $EDATE 파라미터 추가
--         2026-10-22 호출이유(LIST_REASON)를 MSTNON → 공통코드 EQMCALLRSN 으로 변경
--         2026-10-22 수리종료는 종료시각/소요일만 기록 ($MALFUNCTION, $ISSUE, $HANDLE 파라미터 제거)
--         2026-10-22 이력조회 설비 기준 조회 추가
--         2026-11-19 한성수 호출·수리 인원 작업장 기준 변경 및 수리키 형식 변경
--         2026-11-20 한성수 수리키 순번 2자리(01) 시작
--         2026-11-24 한성수 호출사원 작업장 기준 조회로 변경
--         2026-11-25 호출 알림(LIST_NOTICE) 추가 - 호출 등록 후 두레이 메신저로 지정한 사람에게 전송
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50),
  IN $LINECD VARCHAR(100),
  IN $EQMTP VARCHAR(100),
  IN $EQMGROUP1 VARCHAR(100),
  IN $EMPCD_CALL VARCHAR(100),
  IN $REMARK VARCHAR(100),
  IN $EQMCD_LIST MEDIUMTEXT,
  IN $EQMCALLKEY VARCHAR(100),
  IN $EQMCD VARCHAR(100),
  IN $FACTORYCD VARCHAR(20),
  IN $EMPCD_LIST MEDIUMTEXT,
  IN $EQMREPKEY VARCHAR(100),
  IN $SDATE VARCHAR(10),
  IN $EDATE VARCHAR(10)
  )
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$EQMCD VARCHAR(100);
  DECLARE _$EMPCD VARCHAR(100);
  DECLARE _$CHK_LIST MEDIUMTEXT;
  DECLARE _$EQMCALLKEY VARCHAR(100);
  DECLARE _$FIRSTKEY VARCHAR(100);
  DECLARE _$FIRSTEMP VARCHAR(100);
  DECLARE _$EQMREPKEY VARCHAR(100);
  DECLARE _$NOW VARCHAR(19);
-- *****************************************************************************
  CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_LINE' THEN -- 작업장 목록 (외주 작업장 제외)

  SELECT
    A.LINECD, A.LINENM
  FROM MSTLINE AS A
  WHERE A.USEYN = 'Y'
    AND A.EDT = ''
    AND A.OSCCUSTCD = ''  -- 외주작업장 제외
    AND A.FACTORYCD LIKE CONCAT('%', $FACTORYCD, '%')
  ORDER BY A.LINECD, A.LINENM;

-- ****************************************************************************
WHEN 'LIST_EQMTP' THEN -- 작업장별 설비구분(공정) 목록

  IF $LINECD = '' THEN
    CALL COMERR('작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT
    A.EQMTP, GPCD('FM100', A.EQMTP) AS EQMTPNM
  FROM MSTEQM AS A
  WHERE A.LINECD = $LINECD
    AND A.USEYN = 'Y'
    AND A.EQMTP <> ''
  GROUP BY A.EQMTP
  ORDER BY A.EQMTP;

-- ****************************************************************************
WHEN 'LIST_EQMGROUP1' THEN -- 설비대분류(라인) 목록

  IF $LINECD = '' THEN
    CALL COMERR('작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT
    A.EQMGROUP1, GPCD('FM113', A.EQMGROUP1) AS EQMGROUP1NM
  FROM MSTEQM AS A
  WHERE A.LINECD = $LINECD
    AND A.EQMTP = $EQMTP
    AND A.USEYN = 'Y'
    AND A.EQMGROUP1 <> ''
  GROUP BY A.EQMGROUP1
  ORDER BY A.EQMGROUP1;

-- ****************************************************************************
WHEN 'LIST_EQM' THEN -- 라인별 설비 목록 (진행 중인 호출 포함)

  IF $LINECD = '' THEN
    CALL COMERR('작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 진행 중인 호출: 해당 설비의 수리가 아직 종료되지 않은 호출
  -- 설비코드 = MSTEQM.FANO (설비번호, EQMCALLEMP_EQM.EQMCD / EQMREP.EQMCD 와 같은 값)
  SELECT
    A.FANO AS EQMCD, A.FANO AS EQMNO, A.EQMNM, A.EQMNM_DETAIL,
    A.EQMTP, A.EQMGROUP1,
    IFNULL(O.EQMCALLKEY, '') AS EQMCALLKEY,
    IF(O.EQMCALLKEY IS NULL, 'N', 'Y') AS CALLYN,
    IF(EXISTS (SELECT 1 FROM EQMREP AS R3
                WHERE R3.EQMCD = A.FANO
                  AND R3.EQMREPTP = 'EQM01'
                  AND R3.REPETIME = ''), 'Y', 'N') AS REPYN  -- 수리 중인 설비
  FROM MSTEQM AS A
  LEFT JOIN (
    SELECT E.EQMCD, MAX(C.EQMCALLKEY) AS EQMCALLKEY
    FROM EQMCALLEMP AS C
    INNER JOIN EQMCALLEMP_EQM AS E ON C.EQMCALLKEY = E.EQMCALLKEY
    WHERE C.LINECD = $LINECD
      AND NOT EXISTS (SELECT 1 FROM EQMREP AS R
                       WHERE R.EQMCALLKEY = C.EQMCALLKEY
                         AND R.EQMCD = E.EQMCD
                         AND R.REPETIME <> '')
    GROUP BY E.EQMCD
  ) AS O ON A.FANO = O.EQMCD
  WHERE A.LINECD = $LINECD
    AND A.EQMTP = $EQMTP
    AND A.EQMGROUP1 = $EQMGROUP1
    AND A.USEYN = 'Y'
  ORDER BY A.FANO;

-- ****************************************************************************
WHEN 'LIST_CALL' THEN -- 진행 중인 호출 (현황판, 설비 단위)
  -- 1) 호출: 1행 = 호출설비(EQMCALLEMP_EQM) 1건. 설비를 모르는 라인 호출은 EQMCD = '' 로 1행
  --    완료: 그 설비의 수리가 종료(EQMREP.REPETIME <> '') → 제외
  --    상태: REPAIR(그 설비 수리중) > ARRIVE(호출 도착) > CALL(호출)
  -- 2) 직접 수리: 호출 없이 시작한 수리(EQMREP.EQMCALLKEY = '') 중 진행 중인 것 → REPAIR

  IF $LINECD = '' THEN
    CALL COMERR('작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT X.* FROM (
    SELECT
      C.EQMCALLKEY,
      IFNULL(E.EQMCD, '') AS EQMCD,
      IFNULL(M.EQMNM, '') AS EQMNM,
      C.LINECD, C.EQMTP, C.EQMGROUP1,
      GPCD('FM113', C.EQMGROUP1) AS EQMGROUP1NM,
      C.CALLTIME, C.ARRVTIME, C.REMARK,
      C.EMPCD_CALL, IFNULL(P.EMPNM, C.EMPCD_CALL) AS EMPNM_CALL,
      (SELECT COUNT(*) FROM EQMCALLEMP_EQM AS E2 WHERE E2.EQMCALLKEY = C.EQMCALLKEY) AS EQMCNT,
      IFNULL(R.EQMREPKEY, '') AS EQMREPKEY,
      IFNULL(R.REPSTIME, '') AS REPSTIME,
      CASE WHEN R.EQMREPKEY IS NOT NULL THEN 'REPAIR'
           WHEN C.ARRVTIME <> '' THEN 'ARRIVE'
           ELSE 'CALL' END AS CALLSTAT,
      -- 경과시간: 호출 → 호출시각부터, 도착 → 도착시각부터, 수리중 → 수리시작부터
      TIMESTAMPDIFF(MINUTE, CASE WHEN R.EQMREPKEY IS NOT NULL THEN R.REPSTIME
                                 WHEN C.ARRVTIME <> '' THEN C.ARRVTIME
                                 ELSE C.CALLTIME END, NOW()) AS ELAPSEMIN,
      -- 도착자: 첫 사람 이름 + 인원수
      IFNULL((SELECT IFNULL(P2.EMPNM, A.EQMPCD_ARRV)
                FROM EQMCALLEMP_ARRV AS A
                LEFT JOIN MSTEMP AS P2 ON A.EQMPCD_ARRV = P2.EMPCD
               WHERE A.EQMCALLKEY = C.EQMCALLKEY
               ORDER BY A.RTIME, A.EQMPCD_ARRV
               LIMIT 1), '') AS ARRVEMPNM,
      (SELECT COUNT(*) FROM EQMCALLEMP_ARRV AS A WHERE A.EQMCALLKEY = C.EQMCALLKEY) AS ARRVCNT,
      -- 수리자: 첫 사람 이름 + 인원수
      IFNULL((SELECT IFNULL(P3.EMPNM, W.EMPCD)
                FROM EQMREP_EMP AS W
                LEFT JOIN MSTEMP AS P3 ON W.EMPCD = P3.EMPCD
               WHERE W.EQMREPKEY = R.EQMREPKEY
               ORDER BY W.RTIME, W.EMPCD
               LIMIT 1), '') AS REPEMPNM,
      (SELECT COUNT(*) FROM EQMREP_EMP AS W WHERE W.EQMREPKEY = R.EQMREPKEY) AS REPCNT
    FROM EQMCALLEMP AS C
    LEFT JOIN EQMCALLEMP_EQM AS E ON C.EQMCALLKEY = E.EQMCALLKEY
    LEFT JOIN MSTEQM AS M ON E.EQMCD = M.FANO
    LEFT JOIN MSTEMP AS P ON C.EMPCD_CALL = P.EMPCD
    LEFT JOIN EQMREP AS R ON R.EQMCALLKEY = C.EQMCALLKEY
                         AND R.EQMCD = E.EQMCD
                         AND R.REPETIME = ''
    WHERE C.LINECD = $LINECD
      AND NOT EXISTS (SELECT 1 FROM EQMREP AS R2
                       WHERE R2.EQMCALLKEY = C.EQMCALLKEY
                         AND R2.EQMCD = E.EQMCD
                         AND R2.REPETIME <> '')

    UNION ALL

    SELECT
      '' AS EQMCALLKEY,
      R.EQMCD,
      M.EQMNM,
      M.LINECD, M.EQMTP, M.EQMGROUP1,
      GPCD('FM113', M.EQMGROUP1) AS EQMGROUP1NM,
      R.REPSTIME AS CALLTIME, '' AS ARRVTIME, '직접 수리' AS REMARK,
      R.EMPCD AS EMPCD_CALL, IFNULL(P.EMPNM, R.EMPCD) AS EMPNM_CALL,
      1 AS EQMCNT,
      R.EQMREPKEY,
      R.REPSTIME,
      'REPAIR' AS CALLSTAT,
      TIMESTAMPDIFF(MINUTE, R.REPSTIME, NOW()) AS ELAPSEMIN,
      '' AS ARRVEMPNM,
      0 AS ARRVCNT,
      IFNULL((SELECT IFNULL(P3.EMPNM, W.EMPCD)
                FROM EQMREP_EMP AS W
                LEFT JOIN MSTEMP AS P3 ON W.EMPCD = P3.EMPCD
               WHERE W.EQMREPKEY = R.EQMREPKEY
               ORDER BY W.RTIME, W.EMPCD
               LIMIT 1), '') AS REPEMPNM,
      (SELECT COUNT(*) FROM EQMREP_EMP AS W WHERE W.EQMREPKEY = R.EQMREPKEY) AS REPCNT
    FROM EQMREP AS R
    INNER JOIN MSTEQM AS M ON R.EQMCD = M.FANO
    LEFT JOIN MSTEMP AS P ON R.EMPCD = P.EMPCD
    WHERE R.EQMCALLKEY = ''
      AND R.EQMREPTP = 'EQM01'
      AND R.REPETIME = ''
      AND M.LINECD = $LINECD
  ) AS X
  ORDER BY X.CALLTIME, X.EQMCD;

-- ****************************************************************************
WHEN 'LIST_REASON' THEN -- 호출이유 목록 (공통코드 EQMCALLRSN: 생기팀 호출사유)

  SELECT
    A.TPCD AS RSNCD, A.TPNM AS RSNNM
  FROM COMTYPE AS A
  WHERE A.GPCD = 'EQMCALLRSN'
    AND A.USEYN = 'Y'
  ORDER BY A.SORTNO, A.TPCD;

-- ****************************************************************************
WHEN 'LIST_CALLEMP' THEN -- 호출 대상 (작업장에 배치된 생기팀 전원 = MSTEQM_CALLEMP.EQMCD = 작업장)

  IF $LINECD = '' THEN
    CALL COMERR('작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT
    C.EMPCD, IFNULL(P.EMPNM, C.EMPCD) AS EMPNM
  FROM MSTEQM_CALLEMP AS C
  LEFT JOIN MSTEMP AS P ON C.EMPCD = P.EMPCD
  WHERE C.EQMCD = $LINECD
  ORDER BY P.EMPNM, C.EMPCD;

-- ****************************************************************************
WHEN 'ADD_CALL' THEN -- 호출 등록

  IF $LINECD = '' OR $EQMTP = '' OR $EQMGROUP1 = '' THEN
    CALL COMERR('작업장, 설비구분, 라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 호출 대상 = 작업장에 배치된 생기팀 전원 (인원 선택 없음), $EMPCD_CALL = 단말기 작업자
  IF NOT EXISTS (SELECT 1 FROM MSTEQM_CALLEMP WHERE EQMCD = $LINECD) THEN
    CALL COMERR(CONCAT('이 작업장에 배치된 생기팀 호출사원이 없습니다.'
                      , '\n기준정보(작업장별 호출사원 정보)에서 먼저 등록하세요.'));
    LEAVE PROC;
  END IF;

  IF $EQMCD_LIST = '' THEN
    -- 라인 호출(설비 모름): 같은 라인에 설비가 정해지지 않은 호출이 있으면 중복
    IF EXISTS (SELECT 1 FROM EQMCALLEMP AS C
                WHERE C.LINECD = $LINECD
                  AND C.EQMTP = $EQMTP
                  AND C.EQMGROUP1 = $EQMGROUP1
                  AND NOT EXISTS (SELECT 1 FROM EQMCALLEMP_EQM AS E WHERE E.EQMCALLKEY = C.EQMCALLKEY)) THEN
      CALL COMERR('이 라인은 이미 호출되어 있습니다.');
      LEAVE PROC;
    END IF;
  ELSE
    -- 설비 호출: 수리가 끝나지 않은 호출이 있는 설비는 중복
    SET _$CHK_LIST = $EQMCD_LIST;
    WHILE LENGTH(_$CHK_LIST) > 0 DO
      CALL COMSPLIT(_$CHK_LIST, _$EQMCD);

      IF EXISTS (SELECT 1 FROM EQMCALLEMP AS C
                  INNER JOIN EQMCALLEMP_EQM AS E ON C.EQMCALLKEY = E.EQMCALLKEY
                  WHERE E.EQMCD = _$EQMCD
                    AND NOT EXISTS (SELECT 1 FROM EQMREP AS R
                                     WHERE R.EQMCALLKEY = C.EQMCALLKEY
                                       AND R.EQMCD = E.EQMCD
                                       AND R.REPETIME <> '')) THEN
        CALL COMERR(CONCAT('이미 호출된 설비입니다.'
                          , '\n- 설비: ', IFNULL((SELECT EQMNM FROM MSTEQM WHERE FANO = _$EQMCD), _$EQMCD)
                          ));
        LEAVE PROC;
      END IF;
    END WHILE;
  END IF;

  -- 호출은 설비 1대당 1건 (설비 여러 대 선택 → 호출 여러 건). 라인 호출은 설비 없이 1건
  SET _$NOW = CALLTIME();
  SET _$FIRSTKEY = '';
  SET _$CHK_LIST = IF($EQMCD_LIST = '', '»', $EQMCD_LIST); -- 라인 호출도 한 번 돌도록

  WHILE LENGTH(_$CHK_LIST) > 0 DO
    CALL COMSPLIT(_$CHK_LIST, _$EQMCD);

    SET _$EQMCALLKEY = GETKEY('EQMCALLKEY');
    IF _$FIRSTKEY = '' THEN SET _$FIRSTKEY = _$EQMCALLKEY; END IF;

    INSERT INTO EQMCALLEMP (
        EQMCALLKEY
      , LINECD
      , EQMTP
      , EQMGROUP1
      , CALLDATE
      , CALLTIME
      , EMPCD_CALL
      , REMARK
      , RTIME, REMP, RPRG)
    VALUES (
        _$EQMCALLKEY
      , $LINECD
      , $EQMTP
      , $EQMGROUP1
      , LEFT(_$NOW, 10)
      , _$NOW
      , $EMPCD_CALL
      , $REMARK
      , _$NOW, CALLEMP(), CALLPRG()
    );

    IF _$EQMCD <> '' THEN
      INSERT INTO EQMCALLEMP_EQM (
          EQMCALLKEY
        , EQMCD
        , RTIME, REMP, RPRG)
      VALUES (
          _$EQMCALLKEY
        , _$EQMCD
        , _$NOW, CALLEMP(), CALLPRG()
      );
    END IF;
  END WHILE;

  SELECT _$FIRSTKEY AS EQMCALLKEY;

-- ****************************************************************************
WHEN 'DEL_CALL' THEN -- 호출 취소 (호출이력 삭제)
  -- 선택한 설비 1대를 호출에서 삭제, 남은 설비가 없으면 호출 헤더까지 삭제
  -- 설비를 모르는 라인 호출($EQMCD = '')은 호출 헤더 삭제
  -- 도착 전(호출 상태)만 가능

  IF NOT EXISTS (SELECT 1 FROM EQMCALLEMP WHERE EQMCALLKEY = $EQMCALLKEY) THEN
    CALL COMERR('이미 처리되었거나 없는 호출입니다.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM EQMCALLEMP WHERE EQMCALLKEY = $EQMCALLKEY AND ARRVTIME <> '')
     OR EXISTS (SELECT 1 FROM EQMREP WHERE EQMCALLKEY = $EQMCALLKEY) THEN
    CALL COMERR('도착 또는 수리가 시작된 호출은 취소할 수 없습니다.');
    LEAVE PROC;
  END IF;

  IF $EQMCD <> '' THEN
    DELETE FROM EQMCALLEMP_EQM
     WHERE EQMCALLKEY = $EQMCALLKEY
       AND EQMCD = $EQMCD;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM EQMCALLEMP_EQM WHERE EQMCALLKEY = $EQMCALLKEY) THEN
    DELETE FROM EQMCALLEMP_ARRV WHERE EQMCALLKEY = $EQMCALLKEY;
    DELETE FROM EQMCALLEMP WHERE EQMCALLKEY = $EQMCALLKEY;
  END IF;

-- ****************************************************************************
WHEN 'LIST_ARRVEMP' THEN -- 도착자 후보 (호출 작업장에 등록된 MSTEQM_CALLEMP 생기팀 호출사원)

  SELECT
    C.EMPCD, IFNULL(P.EMPNM, C.EMPCD) AS EMPNM
  FROM EQMCALLEMP AS H
  INNER JOIN MSTEQM_CALLEMP AS C ON C.EQMCD = H.LINECD
  LEFT JOIN MSTEMP AS P ON C.EMPCD = P.EMPCD
  WHERE H.EQMCALLKEY = $EQMCALLKEY
  ORDER BY P.EMPNM, C.EMPCD;

-- ****************************************************************************
WHEN 'ADD_ARRIVE' THEN -- 도착 등록 (호출 단위: 같이 호출된 설비 모두 도착)

  IF NOT EXISTS (SELECT 1 FROM EQMCALLEMP WHERE EQMCALLKEY = $EQMCALLKEY) THEN
    CALL COMERR('이미 처리되었거나 없는 호출입니다.');
    LEAVE PROC;
  END IF;

  IF $EMPCD_LIST = '' THEN
    CALL COMERR('도착자를 선택하세요.');
    LEAVE PROC;
  END IF;

  SET _$NOW = CALLTIME();

  -- 아직 도착 전인 경우에만 (다른 단말에서 먼저 등록했으면 0건)
  UPDATE EQMCALLEMP
     SET ARRVDATE = LEFT(_$NOW, 10)
       , ARRVTIME = _$NOW
       , MTIME = _$NOW, MEMP = CALLEMP(), MPRG = CALLPRG()
   WHERE EQMCALLKEY = $EQMCALLKEY
     AND ARRVTIME = '';

  IF ROW_COUNT() = 0 THEN
    CALL COMERR('이미 도착 등록된 호출입니다.');
    LEAVE PROC;
  END IF;

  WHILE LENGTH($EMPCD_LIST) > 0 DO
    CALL COMSPLIT($EMPCD_LIST, _$EMPCD);

    IF _$EMPCD <> '' THEN
      INSERT INTO EQMCALLEMP_ARRV (
          EQMCALLKEY
        , EQMPCD_ARRV
        , RTIME, REMP, RPRG)
      VALUES (
          $EQMCALLKEY
        , _$EMPCD
        , _$NOW, CALLEMP(), CALLPRG()
      );
    END IF;
  END WHILE;

-- ****************************************************************************
WHEN 'LIST_REPEMP' THEN -- 수리시작 인원 후보 (작업장에 배치된 생기팀 = MSTEQM_CALLEMP.EQMCD = 작업장)
  -- 선택한 인원이 도착자(도착 전 호출)와 수리자로 함께 등록됨
  -- ARRVYN: 이 호출의 도착자 (화면에서 기본 선택)

  SELECT
    C.EMPCD, IFNULL(P.EMPNM, C.EMPCD) AS EMPNM,
    IF(EXISTS (SELECT 1 FROM EQMCALLEMP_ARRV AS A
                WHERE A.EQMCALLKEY = $EQMCALLKEY
                  AND A.EQMPCD_ARRV = C.EMPCD), 'Y', 'N') AS ARRVYN
  FROM MSTEQM_CALLEMP AS C
  LEFT JOIN MSTEMP AS P ON C.EMPCD = P.EMPCD
  WHERE C.EQMCD = $LINECD
  ORDER BY P.EMPNM, C.EMPCD;

-- ****************************************************************************
WHEN 'ADD_REPAIR' THEN -- 수리시작 등록 (EQMREP, EQMREP_EMP)
  -- $EQMCALLKEY 있음: 호출 기준 수리. 도착 전이면 도착도 함께 등록(도착자 = 수리자)
  --                   라인 호출(설비 없음)이면 선택한 설비를 호출설비로 연결
  -- $EQMCALLKEY 없음: 직접 수리 (호출 없이 설비 선택)
  -- 수리유형 EQM01(설비), 시간 형식은 설비이력(EQM1001)과 같게 yyyy-mm-dd hh:mi

  IF $EQMCD = '' THEN
    CALL COMERR('수리할 설비를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MSTEQM WHERE FANO = $EQMCD) THEN
    CALL COMERR(CONCAT('없는 설비입니다.', '\n- 설비: ', $EQMCD));
    LEAVE PROC;
  END IF;

  IF $EMPCD_LIST = '' THEN
    CALL COMERR('수리자를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM EQMREP WHERE EQMCD = $EQMCD AND EQMREPTP = 'EQM01' AND REPETIME = '') THEN
    CALL COMERR(CONCAT('이미 수리 중인 설비입니다.'
                      , '\n- 설비: ', IFNULL((SELECT EQMNM FROM MSTEQM WHERE FANO = $EQMCD), $EQMCD)));
    LEAVE PROC;
  END IF;

  SET _$NOW = CALLTIME();

  IF $EQMCALLKEY <> '' THEN

    IF NOT EXISTS (SELECT 1 FROM EQMCALLEMP WHERE EQMCALLKEY = $EQMCALLKEY) THEN
      CALL COMERR('이미 처리되었거나 없는 호출입니다.');
      LEAVE PROC;
    END IF;

    IF EXISTS (SELECT 1 FROM EQMREP WHERE EQMCALLKEY = $EQMCALLKEY AND EQMCD = $EQMCD) THEN
      CALL COMERR('이미 수리가 등록된 호출입니다.');
      LEAVE PROC;
    END IF;

    IF EXISTS (SELECT 1 FROM EQMCALLEMP_EQM WHERE EQMCALLKEY = $EQMCALLKEY) THEN
      -- 설비가 정해진 호출: 호출된 설비만
      IF NOT EXISTS (SELECT 1 FROM EQMCALLEMP_EQM WHERE EQMCALLKEY = $EQMCALLKEY AND EQMCD = $EQMCD) THEN
        CALL COMERR('호출된 설비가 아닙니다.');
        LEAVE PROC;
      END IF;
    ELSE
      -- 라인 호출: 그 라인 설비인지 확인 후 호출설비로 연결
      IF NOT EXISTS (SELECT 1 FROM EQMCALLEMP AS H
                      INNER JOIN MSTEQM AS M ON M.LINECD = H.LINECD
                                            AND M.EQMTP = H.EQMTP
                                            AND M.EQMGROUP1 = H.EQMGROUP1
                      WHERE H.EQMCALLKEY = $EQMCALLKEY
                        AND M.FANO = $EQMCD) THEN
        CALL COMERR('호출한 라인의 설비가 아닙니다.');
        LEAVE PROC;
      END IF;

      INSERT INTO EQMCALLEMP_EQM (
          EQMCALLKEY
        , EQMCD
        , RTIME, REMP, RPRG)
      VALUES (
          $EQMCALLKEY
        , $EQMCD
        , _$NOW, CALLEMP(), CALLPRG()
      );
    END IF;

    -- 도착 전이면 도착도 함께 등록 (도착자 = 수리자)
    IF EXISTS (SELECT 1 FROM EQMCALLEMP WHERE EQMCALLKEY = $EQMCALLKEY AND ARRVTIME = '') THEN
      UPDATE EQMCALLEMP
         SET ARRVDATE = LEFT(_$NOW, 10)
           , ARRVTIME = _$NOW
           , MTIME = _$NOW, MEMP = CALLEMP(), MPRG = CALLPRG()
       WHERE EQMCALLKEY = $EQMCALLKEY;

      SET _$CHK_LIST = $EMPCD_LIST;
      WHILE LENGTH(_$CHK_LIST) > 0 DO
        CALL COMSPLIT(_$CHK_LIST, _$EMPCD);
        IF _$EMPCD <> '' THEN
          INSERT INTO EQMCALLEMP_ARRV (
              EQMCALLKEY
            , EQMPCD_ARRV
            , RTIME, REMP, RPRG)
          VALUES (
              $EQMCALLKEY
            , _$EMPCD
            , _$NOW, CALLEMP(), CALLPRG()
          );
        END IF;
      END WHILE;
    END IF;

  END IF;

  -- 대표 수리자 = 첫 번째 선택자
  SET _$CHK_LIST = $EMPCD_LIST;
  CALL COMSPLIT(_$CHK_LIST, _$FIRSTEMP);

  SET _$EQMREPKEY = GETKEY('EQMREPNO');  -- 수리키 = MT-YYYY-MMDD-순번 (그날 발생 순서대로 +1, 순번 2자리 01부터, 100건부터 3자리)
  SET _$EQMREPKEY = CONCAT('MT-20', LEFT(_$EQMREPKEY, 2), '-', SUBSTRING(_$EQMREPKEY, 3, 4), '-', LPAD(CAST(RIGHT(_$EQMREPKEY, 6) AS UNSIGNED), GREATEST(2, LENGTH(CAST(RIGHT(_$EQMREPKEY, 6) AS UNSIGNED))), '0'));

  INSERT INTO EQMREP (
      EQMREPKEY
    , EQMCALLKEY
    , EQMCD
    , EQMREPTP
    , REGTIME
    , REPSTIME
    , REPETIME
    , REPUTIME
    , EMPCD
    , MALFUNCTION
    , RTIME, REMP, RPRG)
  VALUES (
      _$EQMREPKEY
    , $EQMCALLKEY
    , $EQMCD
    , 'EQM01'
    , LEFT(_$NOW, 16)
    , LEFT(_$NOW, 16)
    , ''
    , 0
    , _$FIRSTEMP
    , IFNULL((SELECT LEFT(REMARK, 100) FROM EQMCALLEMP WHERE EQMCALLKEY = $EQMCALLKEY), '') -- 고장현상 = 호출이유
    , _$NOW, CALLEMP(), CALLPRG()
  );

  WHILE LENGTH($EMPCD_LIST) > 0 DO
    CALL COMSPLIT($EMPCD_LIST, _$EMPCD);
    IF _$EMPCD <> '' THEN
      INSERT INTO EQMREP_EMP (
          EQMREPKEY
        , EMPCD
        , RTIME, REMP, RPRG)
      VALUES (
          _$EQMREPKEY
        , _$EMPCD
        , _$NOW, CALLEMP(), CALLPRG()
      );
    END IF;
  END WHILE;

  SELECT _$EQMREPKEY AS EQMREPKEY;

-- ****************************************************************************
WHEN 'END_REPAIR' THEN -- 수리종료 (EQMREP 종료시각/소요일만 기록)
  -- 소요일(REPUTIME) = 설비이력(EQM1001) 과 같게 종료일 - 시작일 + 1

  IF NOT EXISTS (SELECT 1 FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY) THEN
    CALL COMERR('없는 수리입니다.');
    LEAVE PROC;
  END IF;

  SET _$NOW = CALLTIME();

  UPDATE EQMREP
     SET REPETIME = LEFT(_$NOW, 16)
       , REPUTIME = DATEDIFF(LEFT(_$NOW, 10), LEFT(REPSTIME, 10)) + 1
       , MTIME = _$NOW, MEMP = CALLEMP(), MPRG = CALLPRG()
   WHERE EQMREPKEY = $EQMREPKEY
     AND REPETIME = '';

  IF ROW_COUNT() = 0 THEN
    CALL COMERR('이미 종료된 수리입니다.');
    LEAVE PROC;
  END IF;

-- ****************************************************************************
WHEN 'LIST_HIS_EQM' THEN -- 이력조회 설비 목록 (작업장 전체 설비)

  SELECT
    A.FANO AS EQMCD, A.EQMNM
  FROM MSTEQM AS A
  WHERE A.LINECD = $LINECD
    AND A.USEYN = 'Y'
  ORDER BY A.FANO;

-- ****************************************************************************
WHEN 'LIST_HISTORY' THEN -- 이력조회 (호출 설비 단위 + 직접 수리, $EQMCD 가 있으면 그 설비만)
  -- 기간: 호출일자(직접 수리는 수리시작일자) 기준
  -- 대기(분) = 도착 - 호출, 수리(분) = 수리종료 - 수리시작

  IF $LINECD = '' THEN
    CALL COMERR('작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT X.* FROM (
    SELECT
      '호출' AS GUBUN,
      C.EQMCALLKEY,
      IFNULL(E.EQMCD, '') AS EQMCD,
      IF(E.EQMCD IS NULL, CONCAT(GPCD('FM113', C.EQMGROUP1), ' (설비 모름)'), IFNULL(M.EQMNM, E.EQMCD)) AS EQMNM,
      C.REMARK,
      IFNULL(P.EMPNM, C.EMPCD_CALL) AS EMPNM_CALL,
      C.CALLTIME,
      C.ARRVTIME,
      IFNULL((SELECT GROUP_CONCAT(IFNULL(P2.EMPNM, A.EQMPCD_ARRV) ORDER BY A.RTIME SEPARATOR ', ')
                FROM EQMCALLEMP_ARRV AS A
                LEFT JOIN MSTEMP AS P2 ON A.EQMPCD_ARRV = P2.EMPCD
               WHERE A.EQMCALLKEY = C.EQMCALLKEY), '') AS ARRVEMPNMS,
      IFNULL(R.EQMREPKEY, '') AS EQMREPKEY,
      IFNULL(R.REPSTIME, '') AS REPSTIME,
      IFNULL(R.REPETIME, '') AS REPETIME,
      IFNULL((SELECT GROUP_CONCAT(IFNULL(P3.EMPNM, W.EMPCD) ORDER BY W.RTIME SEPARATOR ', ')
                FROM EQMREP_EMP AS W
                LEFT JOIN MSTEMP AS P3 ON W.EMPCD = P3.EMPCD
               WHERE W.EQMREPKEY = R.EQMREPKEY), '') AS REPEMPNMS,
      IF(C.ARRVTIME = '', NULL, TIMESTAMPDIFF(MINUTE, C.CALLTIME, C.ARRVTIME)) AS WAITMIN,
      IF(IFNULL(R.REPETIME, '') = '', NULL, TIMESTAMPDIFF(MINUTE, R.REPSTIME, R.REPETIME)) AS REPMIN,
      CASE WHEN IFNULL(R.REPETIME, '') <> '' THEN '완료'
           WHEN R.EQMREPKEY IS NOT NULL THEN '수리중'
           WHEN C.ARRVTIME <> '' THEN '도착'
           ELSE '호출' END AS STATNM,
      IFNULL(R.MALFUNCTION, '') AS MALFUNCTION,
      IFNULL(R.ISSUE, '') AS ISSUE,
      IFNULL(R.HANDLE, '') AS HANDLE
    FROM EQMCALLEMP AS C
    LEFT JOIN EQMCALLEMP_EQM AS E ON C.EQMCALLKEY = E.EQMCALLKEY
    LEFT JOIN MSTEQM AS M ON E.EQMCD = M.FANO
    LEFT JOIN MSTEMP AS P ON C.EMPCD_CALL = P.EMPCD
    LEFT JOIN EQMREP AS R ON R.EQMCALLKEY = C.EQMCALLKEY
                         AND R.EQMCD = E.EQMCD
    WHERE C.LINECD = $LINECD
      AND C.CALLDATE BETWEEN $SDATE AND $EDATE
      AND ($EQMCD = '' OR E.EQMCD = $EQMCD)

    UNION ALL

    SELECT
      '직접 수리' AS GUBUN,
      '' AS EQMCALLKEY,
      R.EQMCD,
      IFNULL(M.EQMNM, R.EQMCD) AS EQMNM,
      '' AS REMARK,
      '' AS EMPNM_CALL,
      '' AS CALLTIME,
      '' AS ARRVTIME,
      '' AS ARRVEMPNMS,
      R.EQMREPKEY,
      R.REPSTIME,
      R.REPETIME,
      IFNULL((SELECT GROUP_CONCAT(IFNULL(P3.EMPNM, W.EMPCD) ORDER BY W.RTIME SEPARATOR ', ')
                FROM EQMREP_EMP AS W
                LEFT JOIN MSTEMP AS P3 ON W.EMPCD = P3.EMPCD
               WHERE W.EQMREPKEY = R.EQMREPKEY), '') AS REPEMPNMS,
      NULL AS WAITMIN,
      IF(R.REPETIME = '', NULL, TIMESTAMPDIFF(MINUTE, R.REPSTIME, R.REPETIME)) AS REPMIN,
      IF(R.REPETIME = '', '수리중', '완료') AS STATNM,
      R.MALFUNCTION,
      R.ISSUE,
      R.HANDLE
    FROM EQMREP AS R
    INNER JOIN MSTEQM AS M ON R.EQMCD = M.FANO
    WHERE R.EQMCALLKEY = ''
      AND R.EQMREPTP = 'EQM01'
      AND M.LINECD = $LINECD
      AND LEFT(R.REPSTIME, 10) BETWEEN $SDATE AND $EDATE
      AND ($EQMCD = '' OR R.EQMCD = $EQMCD)
  ) AS X
  ORDER BY IF(X.CALLTIME = '', X.REPSTIME, X.CALLTIME) DESC, X.EQMCD;

-- ****************************************************************************
WHEN 'LIST_NOTICE' THEN -- 호출 알림(두레이 메신저) 받는 사람. 공통코드 DOORAY / CALL_NOTICE : REF01 = 받는 사람 이메일 계정, REF02 = API 토큰

  SELECT A.REF01 AS USERCODE, A.REF02 AS TOKEN
    FROM COMTYPE AS A
   WHERE A.GPCD = 'DOORAY'
     AND A.TPCD = 'CALL_NOTICE'
     AND A.USEYN = 'Y'
     AND IFNULL(A.REF01, '') <> ''
     AND IFNULL(A.REF02, '') <> '';

-- ****************************************************************************
END CASE;
END
