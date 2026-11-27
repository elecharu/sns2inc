CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML2040_R01(
-- *****************************************************************************
-- Comment: 비가동 조회
-- Create: 2026-10-12 13:21: 김영철
-- Modify: 2026-11-11: 비가동 ERP 인터페이스(PRDRSTNON) 송신 추가 (등록·종료 I, 수정 U)
-- Modify: 2026-11-18: 2공장 PRDRSTNON 테이블에 없는 FANO(상세설비)·NONTP(비가동유형) 컬럼 사용 제거. 비가동유형은 MSTNON.NONGROUPCD1 에서 읽고,
--                     FANO 는 화면 호환을 위해 빈 값으로 돌려줌. 파라미터($FANO, $NONTP)는 화면 호출 형식 유지를 위해 그대로 둠
-- Modify: 2026-11-27: 고장내용 → 문제점, 수리내역상세 → 조치사항 (메시지·주석, 컬럼 PROBLEM·SOLUTION 은 그대로)
--                     LIST_LINE 추가: 비가동은 생산라인별 등록, 작업장·공정 조건으로 생산라인(MSTLINE_EQM) 버튼 목록. 파라미터 $LINECD·$PRCCD 추가
--                     LIST_LINE 에 RUNKEY (진행 중 비가동키) 추가: 생산실적등록(TML2010)에서 넘어오면 진행 중이면 종료, 아니면 시작 팝업
--                     SPLIT_NON 추가: 종료된 비가동을 분할 시각 하나로 2건 (앞쪽 코드 $NONCD, 뒤쪽 코드 $NONCD2). 파라미터 $SPLITTIME·$NONCD2 추가
--                     START_NON_LINE 추가: 비가동 시작 (라인 단위, TML2010 START_NON 과 같음). 비가동유형 공통코드 PP410 → PP409. END_NON_KEY 는 코드 비우면 시작 때 코드 사용
--                     END_NON_KEY 추가: 그리드에서 고른 진행 중 비가동을 비가동키로 종료 (종료시간·비가동코드·비고, ERP I, 고장이면 EQMREP)
--                     LIST_LINE 에 RUNYN (진행 중 비가동 있음) 추가 (화면 B안 라인 목록 빨간 점)
--                     LIST_PRDRSTNON: 조회일자($DATE) 하루 → 조회기간($SDATE~$EDATE, 비가동 시작시간 기준). 파라미터 $EDATE 추가
-- Modify: 2026-11-27 김영철 비가동 삭제(DEL_PRDRSTNON) 시 ERP 인터페이스 D 송신 추가 (기존: MES 만 삭제하고 ERP 로는 송신 없음)
-- *****************************************************************************

	IN $PRDNONKEY VARCHAR(20),
	IN $PRDWORKKEY VARCHAR(20),
	IN $EQMCD VARCHAR(20),
	IN $NONCD VARCHAR(10),
	IN $SDATE VARCHAR(19),
	IN $NONSTIME VARCHAR(19),
	IN $NONETIME VARCHAR(19),
	IN $AUTOYN VARCHAR(1),
	IN $REMARK VARCHAR(1000),
	IN $TMLCD VARCHAR(20),
	IN $TOOLCD VARCHAR(20),
	IN $PROBLEM VARCHAR(1000),
	IN $SOLUTION VARCHAR(1000),
	IN $NONTP VARCHAR(10),
	IN $USETOOLCD VARCHAR(20),
	IN $INPUTTOOLCD VARCHAR(20),
	IN $FANO VARCHAR(20),
	IN $EQMREPNO VARCHAR(20),
	IN $DATE VARCHAR(10),
	IN $LINECD VARCHAR(20),     -- 2026-11-27 작업장 (LIST_LINE)
	IN $PRCCD VARCHAR(20),      -- 2026-11-27 공정 (LIST_LINE)
	IN $EDATE VARCHAR(10),      -- 2026-11-27 조회기간 끝 (LIST_PRDRSTNON, 시작은 $SDATE)
	IN $SPLITTIME VARCHAR(19),  -- 2026-11-27 비가동 분할 시각 (SPLIT_NON)
	IN $NONCD2 VARCHAR(10),     -- 2026-11-27 분할 뒤쪽 비가동코드 (SPLIT_NON, 앞쪽은 $NONCD)
	IN $CALLTYPE VARCHAR(50),
	IN $KEYWORD VARCHAR(1000)

)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC

  DECLARE _$PRDNONKEY VARCHAR(20);
  DECLARE _$PRDWORKKEY VARCHAR(20);
  DECLARE _$NONTP VARCHAR(20);
  DECLARE _$NONCD VARCHAR(20);
  DECLARE _$LINECD VARCHAR(20);

-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_LINE' THEN  -- 2026-11-27 생산라인 버튼 목록 (작업장 필수 아님, 공정·라인은 비우면 전체)

  SELECT MSTLINE_EQM.EQMCD,
         MSTLINE_EQM.EQMNM,
         IFNULL(MSTPRC.PRCNM, '') AS PRCNM,
         IF(EXISTS (SELECT 1 FROM PRDRSTNON WHERE PRDRSTNON.EQMCD = MSTLINE_EQM.EQMCD AND PRDRSTNON.NONETIME = ''), 'Y', 'N') AS RUNYN,   -- 진행 중(종료 안 된) 비가동 있음 (화면 빨간 점)
         IFNULL((SELECT RUN_N.PRDNONKEY FROM PRDRSTNON AS RUN_N WHERE RUN_N.EQMCD = MSTLINE_EQM.EQMCD AND RUN_N.NONETIME = '' ORDER BY RUN_N.NONSTIME DESC LIMIT 1), '') AS RUNKEY   -- 2026-11-27 진행 중 비가동키 (생산실적등록에서 넘어오면 바로 종료 팝업)
    FROM MSTLINE_EQM
    INNER JOIN MSTLINE ON MSTLINE.LINECD = MSTLINE_EQM.LINECD
    LEFT JOIN MSTPRC ON MSTPRC.PRCCD = MSTLINE_EQM.PRCCD
    WHERE MSTLINE_EQM.USEYN = 'Y'
      AND MSTLINE.FACTORYCD = '07'
      AND (IFNULL($LINECD, '') = '' OR MSTLINE_EQM.LINECD = $LINECD)
      AND (IFNULL($PRCCD, '') = '' OR MSTLINE_EQM.PRCCD = $PRCCD)
      AND (IFNULL($EQMCD, '') = '' OR MSTLINE_EQM.EQMCD = $EQMCD)
    ORDER BY MSTLINE_EQM.LINECD, MSTLINE_EQM.PRCCD, MSTLINE_EQM.EQMCD;

-- ****************************************************************************
WHEN 'LIST_EQM' THEN  -- (예전 방식: 비가동 이력이 있는 라인만. 화면은 LIST_LINE 사용)

  SELECT PRDRSTNON.EQMCD,
         MSTLINE_EQM.EQMNO,
         MSTLINE_EQM.EQMNM
    FROM PRDRSTNON
    INNER JOIN MSTLINE_EQM ON PRDRSTNON.EQMCD = MSTLINE_EQM.EQMCD
    WHERE MSTLINE_EQM.USEYN = 'Y'
    GROUP BY PRDRSTNON.EQMCD
    ORDER BY MSTLINE_EQM.EQMCD;

-- ****************************************************************************
WHEN 'LIST_MSTNON' THEN

  SELECT LINECD
    INTO _$LINECD
    FROM MSTLINE_EQM
    WHERE EQMCD = $EQMCD;

  SELECT MSTNON.NONCD, MSTNON.NONNM
    FROM MSTNON
    WHERE MSTNON.NONGROUPCD1 = $NONTP
      AND MSTNON.LINECD = _$LINECD;

-- ****************************************************************************
-- 비가동 유형 조회
WHEN 'LIST_NONTP' THEN

  SELECT LINECD
    INTO _$LINECD
    FROM MSTLINE_EQM
    WHERE EQMCD = $EQMCD;

  SELECT MSTNON.NONGROUPCD1 AS NONTP, NON_HEAD.TPNM AS TPNM
    FROM MSTNON
    INNER JOIN (
      SELECT TPCD, TPNM
        FROM COMTYPE
        WHERE GPCD = 'PP409'   -- 2026-11-27 PP410(1공장) → PP409 (생산실적등록 TML2010 과 같음)
      ) AS NON_HEAD ON MSTNON.NONGROUPCD1 = NON_HEAD.TPCD
    WHERE LINECD = _$LINECD
      AND FACTORYCD = '07' -- 2공장
      AND USEYN = 'Y'
    GROUP BY NONGROUPCD1;

-- ****************************************************************************
WHEN 'SHOW_PRDRSTNON_UP' THEN

  IF (SELECT NONETIME FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY) = '' THEN
    CALL COMERR('종료된 비가동만 수정이 가능합니다.');
    LEAVE PROC;
  END IF;

  SELECT PRDNONKEY,
         LEFT(NONSTIME, 10) AS NONSDAY,
         LEFT(NONETIME, 10) AS NONEDAY,
         RIGHT(NONSTIME, 8) AS NONSTIME,
         RIGHT(NONETIME, 8) AS NONETIME,
         '' AS FANO   -- 2공장 PRDRSTNON 에 FANO 컬럼 없음
    FROM PRDRSTNON
    WHERE PRDNONKEY = $PRDNONKEY;

-- ****************************************************************************
WHEN 'LIST_PRDRSTNON' THEN

  SELECT PRDRSTNON.PRDNONKEY,
         PRDRSTNON.PRDWORKKEY,
         PRDRSTNON.EQMCD,
         GPCD('LINEEQM', PRDRSTNON.EQMCD) AS EQMNM,
         PRDRSTNON.NONCD,
         LEFT(PRDRSTNON.NONSTIME, 16) AS NONSTIME,
         LEFT(PRDRSTNON.NONETIME, 16) AS NONETIME,
         CASE WHEN PRDRSTNON.NONETIME <> ''
              THEN CONCAT(TIMESTAMPDIFF(MINUTE, PRDRSTNON.NONSTIME, PRDRSTNON.NONETIME), '분')
         END AS NONTIME,
         PRDRSTNON.AUTOYN,
         PRDRSTNON.REMARK,
         IFNULL(MSTNON.NONNM, '') AS NONNM,
         PRDRSTNON.PROBLEM,
         PRDRSTNON.SOLUTION,
         IFNULL(GPCD('PP409', MSTNON.NONGROUPCD1), '') AS NONTP, -- 2026-11-27 PP410 → PP409 (2공장, TML2010 과 같음)
         '' AS FANO,     -- 2공장 PRDRSTNON 에 FANO 컬럼 없음
         '' AS FANONM
    FROM PRDRSTNON
    INNER JOIN MSTLINE_EQM ON PRDRSTNON.EQMCD = MSTLINE_EQM.EQMCD
    LEFT JOIN MSTNON ON PRDRSTNON.NONCD = MSTNON.NONCD
                    AND MSTLINE_EQM.LINECD = MSTNON.LINECD
    WHERE PRDRSTNON.EQMCD = $EQMCD
      AND PRDRSTNON.NONSTIME >= $SDATE   -- 2026-11-27 조회기간 (비가동 시작시간 기준)
      AND PRDRSTNON.NONSTIME < DATE_FORMAT(DATE_ADD($EDATE, INTERVAL 1 DAY), '%Y-%m-%d')
    GROUP BY PRDRSTNON.PRDNONKEY
    ORDER BY PRDRSTNON.NONSTIME;

-- ****************************************************************************
WHEN 'INFO_PRDRSTNON' THEN

  SELECT PRDRSTNON.PRDNONKEY,
         PRDRSTNON.PRDWORKKEY,
         PRDRSTNON.NONSTIME,
         PRDRSTNON.NONETIME,
         PRDRSTNON.NONCD,
         GPCD('NONCD', PRDRSTNON.NONCD) AS NONNM,
         IFNULL(MSTNON.NONGROUPCD1, '') AS NONTP,
         '' AS FANO   -- 2공장 PRDRSTNON 에 FANO 컬럼 없음
    FROM PRDRSTNON
    LEFT JOIN MSTNON ON PRDRSTNON.NONCD = MSTNON.NONCD
    WHERE PRDRSTNON.PRDNONKEY = $PRDNONKEY
      AND PRDRSTNON.EQMCD = $EQMCD
    ORDER BY PRDRSTNON.NONSTIME;

-- ****************************************************************************
WHEN 'CHK_TIMER' THEN

  SELECT PRDWORKKEY
    INTO _$PRDWORKKEY
    FROM PRDWORK
    WHERE EQMCD = $EQMCD AND WORKETIME = ''
    LIMIT 1;

  IF NOT EXISTS (SELECT PRDNONKEY FROM PRDRSTNON WHERE PRDWORKKEY = _$PRDWORKKEY) THEN
    SELECT 'N' AS CHK;
  ELSE
    SELECT 'Y' AS CHK,
           PRDRSTNON.NONSTIME,
           PRDRSTNON.NONCD,
           MSTNON.NONGROUPCD1 AS NONTP
      FROM PRDRSTNON
      LEFT JOIN MSTNON ON PRDRSTNON.NONCD = MSTNON.NONCD
      WHERE PRDRSTNON.PRDWORKKEY = _$PRDWORKKEY
        AND PRDRSTNON.NONETIME = ''
      LIMIT 1;
  END IF;

-- ****************************************************************************
WHEN 'ADD_PRDRSTNON' THEN

  IF $NONSTIME = '' THEN
    CALL COMERR('비가동 시작시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF $NONETIME = '' THEN
    CALL COMERR('비가동 종료시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF $NONSTIME = $NONETIME THEN
    CALL COMERR('비가동 시작시간과 종료시간이 같습니다.');
    LEAVE PROC;
  END IF;

  IF $NONCD = '' THEN
    CALL COMERR('비가동코드를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  SET _$PRDNONKEY = GETKEY('PRDRSTNON');

  SELECT PRDWORKKEY
    INTO $PRDWORKKEY
    FROM PRDWORK
    WHERE EQMCD = $EQMCD AND WORKETIME = ''
    LIMIT 1;

  INSERT INTO PRDRSTNON (
    PRDNONKEY, PRDWORKKEY, EQMCD, NONCD,
    NONSTIME, NONETIME, AUTOYN, REMARK,
    RTIME, REMP, RPRG
  ) VALUES (
    _$PRDNONKEY, $PRDWORKKEY, $EQMCD, $NONCD,
    $NONSTIME, $NONETIME, 'N', $REMARK,
    CALLTIME(), CALLEMP(), CALLPRG()
  );

  -- ERP 인터페이스 (비가동 등록 : I)
  CALL IO_ERP_INTERFACE('PRDRSTNON', _$PRDNONKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

-- ****************************************************************************
WHEN 'UP_PRDRSTNON' THEN

  IF $NONSTIME = '' THEN
    CALL COMERR('비가동 시작시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF $NONETIME = '' THEN
    CALL COMERR('비가동 종료시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF $NONSTIME = $NONETIME THEN
    CALL COMERR('비가동 시작시간과 종료시간이 같습니다.');
    LEAVE PROC;
  END IF;

  IF $NONCD = '' THEN
    CALL COMERR('비가동코드를 선택하세요.');
    LEAVE PROC;
  END IF;

  UPDATE PRDRSTNON
    SET NONSTIME = $NONSTIME,
        NONETIME = $NONETIME,
        NONCD    = $NONCD,
        MTIME    = GETTIME(),
        MEMP     = CALLEMP(),
        MPRG     = CALLPRG()
    WHERE PRDNONKEY = $PRDNONKEY;

  -- ERP 인터페이스 (비가동 수정 : U)
  CALL IO_ERP_INTERFACE('PRDRSTNON', $PRDNONKEY, 'U');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

-- ****************************************************************************
-- 비가동 문제점/조치사항 조회
WHEN 'SEL_PRDRSTNON_PROBLEM' THEN

  IF (SELECT NONCD FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY) = '600_N' THEN
    CALL COMERR('식사 비가동은 문제점/조치사항을 입력 할 수 없습니다.');
    LEAVE PROC;
  END IF;

  SELECT PROBLEM, SOLUTION
    FROM PRDRSTNON
    WHERE PRDNONKEY = $PRDNONKEY;

-- ****************************************************************************
WHEN 'UP_PRDRSTNON_PROBLEM' THEN

  UPDATE PRDRSTNON
    SET PROBLEM  = $PROBLEM,
        SOLUTION = $SOLUTION,
        MTIME    = GETTIME(),
        MEMP     = CALLEMP(),
        MPRG     = CALLPRG()
    WHERE PRDNONKEY = $PRDNONKEY;

  -- ERP 인터페이스 (비가동 문제점/조치사항 수정 : U, 종료된 비가동만 송신됨)
  CALL IO_ERP_INTERFACE('PRDRSTNON', $PRDNONKEY, 'U');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

-- ****************************************************************************
WHEN 'DEL_PRDRSTNON' THEN

  IF $PRDNONKEY = '' THEN
    CALL COMERR('비가동내용을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF (SELECT NONETIME FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY AND EQMCD = $EQMCD) = '' THEN
    CALL COMERR('종료된 비가동만 삭제가 가능합니다.');
    LEAVE PROC;
  END IF;

  -- ERP 인터페이스 (비가동 삭제 : D, 삭제 전에 송신. 종료된 비가동만 송신됨)
  IF EXISTS (SELECT 1 FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY AND EQMCD = $EQMCD) THEN
    CALL IO_ERP_INTERFACE('PRDRSTNON', $PRDNONKEY, 'D');

    IF IFNULL(@ERRMSG, '') <> '' THEN
      LEAVE PROC;
    END IF;
  END IF;

  DELETE FROM PRDRSTNON
    WHERE PRDNONKEY = $PRDNONKEY
      AND EQMCD = $EQMCD;

-- ****************************************************************************
WHEN 'START_NON_LINE' THEN  -- 2026-11-27 비가동 시작 (라인 단위, 생산실적등록 TML2010 START_NON 과 같음: 작업키 없음, 비가동코드는 종료 때 골라도 됨)

  IF IFNULL($EQMCD, '') = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($NONSTIME, '') = '' THEN
    CALL COMERR('비가동 시작시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT 1 FROM PRDRSTNON WHERE PRDRSTNON.EQMCD = $EQMCD AND PRDRSTNON.NONETIME = '') THEN
    CALL COMERR('이미 진행 중인 비가동이 있습니다. 종료 후 시작하세요.');
    LEAVE PROC;
  END IF;

  SET _$LINECD = IFNULL((SELECT MSTLINE_EQM.LINECD FROM MSTLINE_EQM WHERE MSTLINE_EQM.EQMCD = $EQMCD LIMIT 1), '');   -- 작업장 (MSTNON 조인용)
  SET _$PRDNONKEY = GETKEY('PRDRSTNON');

  INSERT INTO PRDRSTNON (
      PRDNONKEY, PRDWORKKEY, PRDRSTKEY, LINECD, EQMCD, NONCD,
      NONSTIME, NONETIME, AUTOYN, REMARK,
      RTIME, REMP, RPRG
  ) VALUES (
      _$PRDNONKEY, '', '', _$LINECD, $EQMCD, IFNULL($NONCD, ''),
      $NONSTIME, '', 'N', IFNULL($REMARK, ''),
      CALLTIME(), CALLEMP(), CALLPRG()
  );

-- ****************************************************************************
WHEN 'END_NON_KEY' THEN  -- 2026-11-27 그리드에서 고른 진행 중 비가동 종료 (비가동코드 바꿀 수 있음, 작업 진행 여부와 상관없이 비가동키로)

  IF IFNULL($PRDNONKEY, '') = '' THEN
    CALL COMERR('종료할 비가동을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY AND NONETIME = '') THEN
    CALL COMERR('진행 중인 비가동이 아닙니다. (이미 종료됨)');
    LEAVE PROC;
  END IF;

  IF (SELECT AUTOYN FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY) = 'Y' THEN
    CALL COMERR('자동생성 비가동은 수동처리 불가');
    LEAVE PROC;
  END IF;

  IF IFNULL($NONETIME, '') = '' THEN
    CALL COMERR('비가동 종료시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  -- 종료 때 고른 코드가 없으면 시작 때 저장된 코드를 쓰고, 둘 다 없으면 막음 (TML2010 END_NON 과 같음)
  IF IFNULL($NONCD, '') = '' AND (SELECT NONCD FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY) = '' THEN
    CALL COMERR('비가동코드를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $NONETIME <= (SELECT NONSTIME FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY) THEN
    CALL COMERR('종료시간은 시작시간보다 뒤여야 합니다.');
    LEAVE PROC;
  END IF;

  UPDATE PRDRSTNON
    SET NONETIME = $NONETIME,
        NONCD    = IF(IFNULL($NONCD, '') = '', NONCD, $NONCD),
        REMARK   = IF(IFNULL($REMARK, '') <> '', $REMARK, REMARK),
        MTIME    = GETTIME(),
        MEMP     = CALLEMP(),
        MPRG     = CALLPRG()
    WHERE PRDNONKEY = $PRDNONKEY;

  -- ERP 인터페이스 (비가동 종료 : I, END_NON 과 같음)
  CALL IO_ERP_INTERFACE('PRDRSTNON', $PRDNONKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;


-- ****************************************************************************
WHEN 'SPLIT_NON' THEN  -- 2026-11-27 종료된 비가동 분할: 분할 시각 하나로 2건 (앞쪽 = 원래 비가동, 뒤쪽 = 새 비가동)
  -- 앞쪽: 시작 ~ 분할 시각, 비가동코드 $NONCD, 문제점·조치사항·비고는 그대로
  -- 뒤쪽: 분할 시각 ~ 원래 종료, 비가동코드 $NONCD2, 문제점·조치사항·비고는 비움
  -- ERP 인터페이스: 앞쪽 수정 U, 뒤쪽 등록 I

  IF IFNULL($PRDNONKEY, '') = '' THEN
    CALL COMERR('분할할 비가동을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY AND NONETIME <> '') THEN
    CALL COMERR('종료된 비가동만 분할할 수 있습니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($SPLITTIME, '') = '' THEN
    CALL COMERR('분할 시각을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF $SPLITTIME <= (SELECT NONSTIME FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY)
     OR $SPLITTIME >= (SELECT NONETIME FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY) THEN
    CALL COMERR('분할 시각은 비가동 시작시간과 종료시간 사이여야 합니다.');
    LEAVE PROC;
  END IF;

  IF IFNULL($NONCD, '') = '' OR IFNULL($NONCD2, '') = '' THEN
    CALL COMERR('앞쪽·뒤쪽 비가동코드를 모두 선택하세요.');
    LEAVE PROC;
  END IF;

  SET _$PRDNONKEY = GETKEY('PRDRSTNON');

  -- 뒤쪽 (새 비가동)
  INSERT INTO PRDRSTNON (
      PRDNONKEY, PRDWORKKEY, PRDRSTKEY, LINECD, EQMCD, NONCD,
      NONSTIME, NONETIME, AUTOYN, REMARK,
      RTIME, REMP, RPRG
  )
  SELECT _$PRDNONKEY, PRDRSTNON.PRDWORKKEY, PRDRSTNON.PRDRSTKEY, PRDRSTNON.LINECD, PRDRSTNON.EQMCD, $NONCD2,
         $SPLITTIME, PRDRSTNON.NONETIME, 'N', '',
         CALLTIME(), CALLEMP(), CALLPRG()
    FROM PRDRSTNON
    WHERE PRDRSTNON.PRDNONKEY = $PRDNONKEY;

  -- 앞쪽 (원래 비가동)
  UPDATE PRDRSTNON
    SET NONETIME = $SPLITTIME,
        NONCD    = $NONCD,
        MTIME    = GETTIME(),
        MEMP     = CALLEMP(),
        MPRG     = CALLPRG()
    WHERE PRDNONKEY = $PRDNONKEY;

  CALL IO_ERP_INTERFACE('PRDRSTNON', $PRDNONKEY, 'U');
  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  CALL IO_ERP_INTERFACE('PRDRSTNON', _$PRDNONKEY, 'I');
  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

-- ****************************************************************************
END CASE;

END