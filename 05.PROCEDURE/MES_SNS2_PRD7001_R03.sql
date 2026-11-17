CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD7001_R03(
-- *****************************************************************************
-- Comment: 단말기별 프로그램 정보
-- Create: 2023-11-23 16:36: 김영철 
-- Modify: 2026-11-16  현장프로그램 메뉴타일 반칸 여부(TILEHALFYN)·열바꿈 여부(TILEBREAKYN) 추가
-- *****************************************************************************
  IN $TMLCD       VARCHAR(20),    -- 단말기 코드
  IN $TMLNM       VARCHAR(20),    -- 단말기 이름
  IN $BDVCD       VARCHAR(10),    -- 사업장
  IN $PRGCD       VARCHAR(20),    -- 프로그램 코드
  IN $PRGNM       VARCHAR(50),    -- 프로그램 이름
  IN $SORTNO      DECIMAL(20, 8), -- 정렬 순서
  IN $USEYN       VARCHAR(1),     -- 사용 여부
  IN $REMARK      VARCHAR(1000),  -- 비고
  IN $TTMLCD      VARCHAR(20),    -- 복사 대상 TMLCD

  IN $PRGCD_LIST  MEDIUMTEXT,
  IN $PRGNM_LIST  MEDIUMTEXT,
  IN $SORTNO_LIST MEDIUMTEXT,
  IN $USEYN_LIST  MEDIUMTEXT,
  IN $REMARK_LIST MEDIUMTEXT,
  IN $TILEHALFYN_LIST  MEDIUMTEXT,  -- 현장 메뉴타일 반칸 여부 (Y: 가로 절반)
  IN $TILEBREAKYN_LIST MEDIUMTEXT,  -- 현장 메뉴타일 열바꿈 여부 (Y: 이 메뉴 다음부터 다음 열)

-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y'; 
-- *****************************************************************************

  DECLARE _$PRGCD     VARCHAR(20);
  DECLARE _$PRGNM     VARCHAR(50);
  DECLARE _$SORTNO    DECIMAL(20, 0);
  DECLARE _$USEYN     VARCHAR(10);
  DECLARE _$REMARK    VARCHAR(1000);
  DECLARE _$TILEHALFYN  VARCHAR(1);
  DECLARE _$TILEBREAKYN VARCHAR(1);

-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
-- 단말기 정보 조회

WHEN 'LIST_MSTTML' THEN

  SELECT
    TMLCD, TMLNM,
    FACTORYCD
    FROM MSTTML
    WHERE ( TMLCD LIKE CONCAT('%', $KEYWORD, '%')
      OR    TMLNM LIKE CONCAT('%', $KEYWORD, '%')
      OR    FACTORYCD LIKE CONCAT('%', $KEYWORD, '%'))
    AND FACTORYCD = '07'
    ORDER BY SORTNO, TMLCD;

-- ****************************************************************************
-- 단말기별 프로그램 정보 조회

WHEN 'LIST_MSTTMLPRG' THEN

  SELECT
    TP.PRGCD,   TRIM(TP.PRGNM) AS PRGNM,   CASE WHEN TP.SORTNO > 0 THEN TP.SORTNO END AS SORTNO,
    TP.USEYN,   TP.TILEHALFYN,  TP.TILEBREAKYN,
    TP.REMARK,  'Y' AS REGYN
    FROM MSTTMLPRG AS TP
    WHERE TP.TMLCD = $TMLCD
    ORDER BY TP.USEYN DESC, TP.SORTNO;

-- ****************************************************************************
-- 단말기별 프로그램 정보 추가, 저장
WHEN 'UP_MSTTMLPRG' THEN

  WHILE LENGTH($PRGCD_LIST) > 0 DO
    CALL COMSPLIT($PRGCD_LIST,  _$PRGCD);
    CALL COMSPLIT($PRGNM_LIST,  _$PRGNM);
    CALL COMSPLIT($SORTNO_LIST, _$SORTNO);
    CALL COMSPLIT($USEYN_LIST,  _$USEYN);
    CALL COMSPLIT($REMARK_LIST, _$REMARK);
    CALL COMSPLIT($TILEHALFYN_LIST,  _$TILEHALFYN);
    CALL COMSPLIT($TILEBREAKYN_LIST, _$TILEBREAKYN);

    IF _$SORTNO = '' AND _$SORTNO IS NULL THEN
      CALL COMERR('순번 설정값이 없는 메뉴가 있습니다.');
      LEAVE PROC;
    END IF;

    IF _$SORTNO = 0 THEN
      SELECT IFNULL(MAX(TP.SORTNO), 0) + 1
        INTO _$SORTNO
        FROM MSTTMLPRG AS TP
        WHERE TP.TMLCD = $TMLCD
          AND TP.SORTNO NOT IN (99, 100);
    END IF;

    INSERT INTO MSTTMLPRG (
      TMLCD,      PRGCD,        PRGNM,      SORTNO,     USEYN,
      TILEHALFYN, TILEBREAKYN,
      REMARK,     RTIME,        REMP,       RPRG
      ) VALUES (
      $TMLCD,     _$PRGCD,      _$PRGNM,    _$SORTNO,   _$USEYN,
      IF(_$TILEHALFYN = 'Y', 'Y', 'N'),  IF(_$TILEBREAKYN = 'Y', 'Y', 'N'),
      _$REMARK,   CALLTIME(),   CALLEMP(),  CALLPRG()
      ) ON DUPLICATE KEY UPDATE
      TMLCD     = $TMLCD,
      PRGCD     = _$PRGCD,
      PRGNM     = _$PRGNM,
      SORTNO    = _$SORTNO,
      USEYN     = _$USEYN,
      TILEHALFYN  = IF(_$TILEHALFYN = 'Y', 'Y', 'N'),
      TILEBREAKYN = IF(_$TILEBREAKYN = 'Y', 'Y', 'N'),
      REMARK    = _$REMARK,
      MTIME     = CALLTIME(),
      MEMP      = CALLEMP(),
      MPRG      = CALLPRG();

  END WHILE;  

-- ****************************************************************************
-- 단말기별 프로그램 정보 삭제

WHEN 'DEL_MSTTMLPRG' THEN

  WHILE LENGTH($PRGCD_LIST) > 0 DO
    CALL COMSPLIT($PRGCD_LIST,  _$PRGCD);
    
    DELETE MSTTMLPRG
      FROM MSTTMLPRG
      WHERE TMLCD = $TMLCD
        AND PRGCD = _$PRGCD;

  END WHILE;

-- ****************************************************************************
-- 단말기 프로그램 정보 복사

WHEN 'COPY_MSTTML' THEN

  IF $TTMLCD = $TMLCD THEN
    CALL COMERR('선택한 단말기와 복사할 단말기가 같습니다.');
    LEAVE PROC;
  END IF;

  DELETE MSTTMLPRG
    FROM MSTTMLPRG
    WHERE TMLCD = $TTMLCD;

  INSERT INTO MSTTMLPRG (
    TMLCD,  PRGCD, PRGNM, SORTNO, USEYN,
    TILEHALFYN, TILEBREAKYN,
    REMARK, RTIME, REMP,  RPRG
    )
    SELECT
      $TTMLCD, PRGCD, PRGNM, SORTNO, USEYN,
      TILEHALFYN, TILEBREAKYN,
      CONCAT('COPY FROM ', $TMLCD), CALLTIME(), CALLEMP(),  CALLPRG()
      FROM  MSTTMLPRG
      WHERE TMLCD = $TMLCD;

-- ****************************************************************************
END CASE; END