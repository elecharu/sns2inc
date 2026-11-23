CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD6001_R01(
-- *****************************************************************************
-- Comment: 설비 일상점검 항목 등록 (EQM1001_R02 정기점검 항목 등록과 동일, CHKTP = '01' 일상점검)
-- Create: 2026-10-23 10:10:
-- *****************************************************************************
  IN $CHKTP         VARCHAR(20),
  IN $CHKKNDCD      VARCHAR(100),
  IN $CHKKNDNM      VARCHAR(1000),
  IN $CHKLOC        VARCHAR(100),
  IN $CHKMTH        VARCHAR(100),
  IN $CHKVALTP      VARCHAR(100),
  IN $SORTNO        DECIMAL(20, 8),
  IN $USEYN         VARCHAR(1),
  IN $REMARK        VARCHAR(1000),
  IN $CHKCYCLE      VARCHAR(20),
  IN $CHKKNDCD_LIST MEDIUMTEXT,
  IN $CHKLOC_LIST   MEDIUMTEXT,
  IN $CHKKNDNM_LIST MEDIUMTEXT,
  IN $CHKMTH_LIST   MEDIUMTEXT,
  IN $CHKTP_LIST    MEDIUMTEXT,
  IN $CHKVALTP_LIST MEDIUMTEXT,
  IN $USEYN_LIST    MEDIUMTEXT,
  IN $REMARK_LIST   MEDIUMTEXT,
  IN $CHKCYCLE_LIST MEDIUMTEXT,
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$CHKKNDCD  VARCHAR(100);
  DECLARE _$CHKLOC    VARCHAR(100);
  DECLARE _$CHKKNDNM  VARCHAR(1000);
  DECLARE _$CHKMTH    VARCHAR(100);
  DECLARE _$CHKVALTP  VARCHAR(100);
  DECLARE _$USEYN     VARCHAR(1);
  DECLARE _$REMARK    VARCHAR(1000);
  DECLARE _$CHKCYCLE  VARCHAR(20);
CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_MSTCHKKND' THEN
  SELECT
    MSTCHKKND.CHKKNDCD,
    MSTCHKKND.CHKKNDNM,
    MSTCHKKND.CHKTP,
    MSTCHKKND.CHKLOC,
    MSTCHKKND.CHKMTH,
    MSTCHKKND.CHKVALTP,
    MSTCHKKND.CHKCYCLE,
    MSTCHKKND.SORTNO,
    MSTCHKKND.USEYN,
    MSTCHKKND.REMARK
  FROM MSTCHKKND
  WHERE MSTCHKKND.CHKTP = '01'
    AND (MSTCHKKND.CHKKNDCD LIKE CONCAT('%', $KEYWORD, '%')
      OR MSTCHKKND.CHKKNDNM LIKE CONCAT('%', $KEYWORD, '%'))
  ;

-- ****************************************************************************
WHEN 'ADD_MSTCHKKND' THEN

  IF $CHKKNDCD = '' THEN
      CALL COMERR('점검코드를 입력하세요.');
      LEAVE PROC;
  END IF;

  IF $CHKKNDNM = '' THEN
      CALL COMERR('점검명을 입력하세요.');
      LEAVE PROC;
  END IF;

  -- 점검코드는 일상/정기 구분 없이 MSTCHKKND 전체에서 중복 불가
  IF EXISTS (SELECT 1 FROM MSTCHKKND WHERE CHKKNDCD = $CHKKNDCD ) THEN
      CALL COMERR('이미 등록되는 점검코드 입니다.');
      LEAVE PROC;
  END IF;

  IF $CHKLOC = '' THEN
    CALL COMERR('점검항목을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $CHKMTH = '' THEN
    CALL COMERR('점검방법을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $CHKVALTP = '' THEN
    CALL COMERR('점검값 구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $SORTNO = '' OR $SORTNO IS NULL THEN
    SELECT IFNULL(MAX(SORTNO), 0) + 1 INTO $SORTNO
    FROM MSTCHKKND
    WHERE CHKTP = '01';
  END IF;

  INSERT INTO MSTCHKKND (
    CHKKNDCD, CHKKNDNM, CHKTP, CHKCYCLE,
    CHKLOC, CHKMTH, CHKVALTP,
    SORTNO, USEYN, REMARK,
    RTIME, REMP, RPRG
    ) VALUES (
    $CHKKNDCD, $CHKKNDNM, '01', $CHKCYCLE,
    $CHKLOC, $CHKMTH, $CHKVALTP,
    $SORTNO, $USEYN, $REMARK,
    CALLTIME(), CALLEMP(), CALLPRG());


-- ****************************************************************************
WHEN 'SAVE_MSTCHKKND' THEN

  WHILE LENGTH($CHKKNDCD_LIST) > 0 DO

    CALL COMSPLIT($CHKKNDCD_LIST, _$CHKKNDCD);
    CALL COMSPLIT($CHKLOC_LIST, _$CHKLOC);
    CALL COMSPLIT($CHKKNDNM_LIST, _$CHKKNDNM);
    CALL COMSPLIT($CHKCYCLE_LIST, _$CHKCYCLE);
    CALL COMSPLIT($CHKMTH_LIST, _$CHKMTH);
    CALL COMSPLIT($CHKVALTP_LIST, _$CHKVALTP);
    CALL COMSPLIT($USEYN_LIST, _$USEYN);
    CALL COMSPLIT($REMARK_LIST, _$REMARK);

    IF EXISTS (SELECT 1 FROM MSTEQMREV_DETAIL WHERE CHKKNDCD = _$CHKKNDCD) THEN
      CALL COMERR('설비점검계획에 등록된 항목은 수정이 불가능 합니다.');
      LEAVE PROC;
    END IF;

    UPDATE MSTCHKKND SET
      CHKLOC = _$CHKLOC,
      CHKKNDNM = _$CHKKNDNM,
      CHKMTH = _$CHKMTH,
      CHKVALTP = _$CHKVALTP,
      CHKCYCLE = _$CHKCYCLE,
      USEYN = _$USEYN,
      REMARK = _$REMARK,
      MTIME = CALLTIME(),
      MEMP = CALLEMP(),
      MPRG = CALLPRG()
    WHERE
      CHKKNDCD = _$CHKKNDCD
      AND CHKTP = '01'
    ;
  END WHILE;

-- ****************************************************************************
WHEN 'DELETE_MSTCHKKND' THEN

  WHILE LENGTH($CHKKNDCD_LIST) > 0 DO

    CALL COMSPLIT($CHKKNDCD_LIST, _$CHKKNDCD);

    IF EXISTS (SELECT 1 FROM MSTEQMREV_DETAIL WHERE CHKKNDCD = _$CHKKNDCD) THEN
      CALL COMERR('설비점검계획에 등록된 항목은 삭제 할 수 없습니다.');
      LEAVE PROC;
    END IF;

    IF EXISTS (SELECT 1 FROM CHKRSTEQMKND WHERE CHKKNDCD = _$CHKKNDCD) THEN
      CALL COMERR('점검실적이 있는 항목은 삭제 할 수 없습니다.');
      LEAVE PROC;
    END IF;

    DELETE FROM MSTCHKKND WHERE CHKKNDCD = _$CHKKNDCD AND CHKTP = '01';

  END WHILE;


-- ****************************************************************************
END CASE; END
