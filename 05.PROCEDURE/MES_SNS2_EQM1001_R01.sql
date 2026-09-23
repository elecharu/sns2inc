CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`EQM1001_R01`(
-- *****************************************************************************
-- Comment: 설비이력관리 
-- Create: 	2025-06-24  	생성 			이대규
-- Modify: 	2026-09-16 		마이그레이션	한성수
-- 			2026-09-16 					한성수	MSTEQM.FANO(설비코드) 컬럼 바인딩 변경 및 구분선/코드 정렬
-- *****************************************************************************
  IN $SDATE            VARCHAR(10),     -- 조회 시작일자
  IN $EDATE            VARCHAR(10),     -- 조회 종료일자
  IN $EQMCD            VARCHAR(20),     -- 설비코드
  IN $EMPCD            VARCHAR(20),     -- 사원코드
  IN $EQMREPKEY        VARCHAR(20),     -- 설비수리키
  IN $PARTCD           VARCHAR(20),
  IN $REGDAY           VARCHAR(100),    -- 등록일자
  IN $REPSDAY          VARCHAR(100),    -- 발생일자
  IN $REPEDAY          VARCHAR(100),    -- 완료일자
  IN $REGTIME          VARCHAR(100),    -- 등록시간
  IN $REPSTIME         VARCHAR(100),    -- 발생시간
  IN $REPETIME         VARCHAR(100),    -- 완료시간
  IN $REPCUST          VARCHAR(100),    -- 수리업체
  IN $REPUTIME         DECIMAL(20, 8),  -- 소요일
  IN $REPAMT           DECIMAL(20, 8),  -- 수리금액
  IN $ISSUE            VARCHAR(20),     -- 수리유형
  IN $PARTQTY          DECIMAL(20, 8),  -- 부품수량
  IN $MALFUNCTION      VARCHAR(1000),   -- 고장내용
  IN $HANDLE           VARCHAR(1000),   -- 조치내용
  IN $REMARK           VARCHAR(100),    -- 비고

  IN $EMPCD_LIST       MEDIUMTEXT,
  IN $EQMREPKEY_LIST   MEDIUMTEXT,
  IN $REGDAY_LIST      MEDIUMTEXT,
  IN $REGTIME_LIST     MEDIUMTEXT,
  IN $REPSDAY_LIST     MEDIUMTEXT,
  IN $REPSTIME_LIST    MEDIUMTEXT,
  IN $REPEDAY_LIST     MEDIUMTEXT,
  IN $REPETIME_LIST    MEDIUMTEXT,
  IN $REPUTIME_LIST    MEDIUMTEXT,
  IN $EQMCD_LIST       MEDIUMTEXT,
  IN $PARTCD_LIST      MEDIUMTEXT,
  IN $PARTQTY_LIST     MEDIUMTEXT,
  IN $REPAMT_LIST      MEDIUMTEXT,
  IN $REPCUST_LIST     MEDIUMTEXT,
  IN $ISSUE_LIST       MEDIUMTEXT,
  IN $MALFUNCTION_LIST MEDIUMTEXT,
  IN $HANDLE_LIST      MEDIUMTEXT,
  IN $REMARK_LIST      MEDIUMTEXT,

-- *****************************************************************************
  IN $CALLTYPE         VARCHAR(50),
  IN $KEYWORD          VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$EMPCD       VARCHAR(20);
  DECLARE _$REPSDAYTIME VARCHAR(20);
  DECLARE _$REGDAYTIME  VARCHAR(20);
  DECLARE _$REPEDAYTIME VARCHAR(20);
  DECLARE _$EQMREPKEY   VARCHAR(20);
  DECLARE _$REGDAY      VARCHAR(100);
  DECLARE _$REGTIME     VARCHAR(100);
  DECLARE _$REPSDAY     VARCHAR(100);
  DECLARE _$REPSTIME    VARCHAR(100);
  DECLARE _$REPEDAY     VARCHAR(100);
  DECLARE _$REPETIME    VARCHAR(100);
  DECLARE _$REPUTIME    DECIMAL(20, 8);
  DECLARE _$EQMCD       VARCHAR(100);
  DECLARE _$PARTCD      VARCHAR(100);
  DECLARE _$PARTQTY     DECIMAL(20, 8);
  DECLARE _$REPAMT      DECIMAL(20, 8);
  DECLARE _$REPCUST     VARCHAR(100);
  DECLARE _$ISSUE       VARCHAR(100);
  DECLARE _$MALFUNCTION VARCHAR(1000);
  DECLARE _$HANDLE      VARCHAR(1000);
  DECLARE _$REMARK      VARCHAR(1000);

CASE $CALLTYPE

-- *****************************************************************************
WHEN 'LIST_EQMREP' THEN  -- 설비이력조회
  SELECT
    EQMREP.EQMREPKEY,                    -- 설비수리키
    LEFT(EQMREP.REGTIME, 10)  AS REGDAY, -- 등록일자
    RIGHT(EQMREP.REGTIME, 5)  AS REGTIME,-- 등록시간
    LEFT(EQMREP.REPSTIME, 10) AS REPSDAY,-- 발생일자
    RIGHT(EQMREP.REPSTIME, 5) AS REPSTIME,-- 발생시간
    LEFT(EQMREP.REPETIME, 10) AS REPEDAY,-- 완료일자
    RIGHT(EQMREP.REPETIME, 5) AS REPETIME,-- 완료시간
    EQMREP.REPUTIME,                     -- 소요일
    EQMREP.EQMCD,                        -- 설비코드
    MSTEQM.EQMNM,                        -- 설비명
    EQMREP.REPAMT,
    EQMREP.REPCUST,
    EQMREP.ISSUE,
    EQMREP.MALFUNCTION,
    EQMREP.HANDLE,
    EQMREP.REMARK
  FROM EQMREP
  JOIN MSTEQM ON MSTEQM.FANO = EQMREP.EQMCD
  WHERE LEFT(EQMREP.REGTIME, 10) BETWEEN $SDATE AND $EDATE
    AND EQMREP.EQMCD LIKE CONCAT('%', $EQMCD, '%')
    AND EQMREP.EMPCD LIKE CONCAT('%', $EMPCD, '%')
    AND EQMREP.EQMREPTP = 'EQM01'
  ORDER BY EQMREP.REGTIME;

-- *****************************************************************************
WHEN 'LIST_EMPCD' THEN  -- 설비이력 관련 작업자 조회
  SELECT
    EQMREP_EMP.EQMREPKEY,
    EQMREP_EMP.EMPCD,
    MSTEMP.EMPNM
  FROM EQMREP_EMP
  JOIN MSTEMP ON MSTEMP.EMPCD = EQMREP_EMP.EMPCD
  WHERE EQMREP_EMP.EQMREPKEY = $EQMREPKEY;

-- *****************************************************************************
WHEN 'ADD_EQMREP' THEN  -- 팝업창 설비이력 저장
  IF $EQMCD = '' THEN
    CALL COMERR('설비코드를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF $REGDAY = '' THEN
    CALL COMERR('등록일자를 입력하세요.');
    LEAVE PROC;
  ELSE
    IF $REGTIME = '' THEN
      CALL COMERR('등록시간을 입력하세요.');
      LEAVE PROC;
    END IF;
  END IF;

  IF $REPSDAY = '' THEN
    CALL COMERR('발생일자를 입력하세요.');
    LEAVE PROC;
  ELSE
    IF $REPSTIME = '' THEN
      CALL COMERR('발생시간을 입력하세요.');
      LEAVE PROC;
    END IF;
  END IF;

  IF $REPEDAY <> '' AND $REPETIME = '' THEN
    CALL COMERR('완료시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  SET $EQMREPKEY = GETKEY('EQMREPKEY');

  SET _$REGDAYTIME  = IFNULL(CONCAT($REGDAY, ' ', $REGTIME), '');
  SET _$REPSDAYTIME = IFNULL(CONCAT($REPSDAY, ' ', $REPSTIME), '');
  SET _$REPEDAYTIME = IFNULL(CONCAT($REPEDAY, ' ', $REPETIME), '');

  INSERT INTO EQMREP (
    EQMREPKEY, EQMCD, EQMREPTP,
    REGTIME, REPSTIME, REPETIME, REPUTIME,
    REPAMT, REPCUST, EMPCD,
    HANDLE, MALFUNCTION, ISSUE, REMARK,
    RTIME, REMP, RPRG
  ) VALUES (
    $EQMREPKEY, $EQMCD, 'EQM01',
    _$REGDAYTIME, _$REPSDAYTIME, _$REPEDAYTIME, $REPUTIME,
    $REPAMT, $REPCUST, CALLEMP(),
    $HANDLE, $MALFUNCTION, $ISSUE, $REMARK,
    CALLTIME(), CALLEMP(), CALLPRG()
  );

  WHILE LENGTH($EMPCD_LIST) > 0 DO
    CALL COMSPLIT($EMPCD_LIST, _$EMPCD);

    INSERT INTO EQMREP_EMP (
      EQMREPKEY, EMPCD,
      RTIME, REMP, RPRG
    ) VALUES (
      $EQMREPKEY, _$EMPCD,
      CALLTIME(), CALLEMP(), CALLPRG()
    );
  END WHILE;

-- *****************************************************************************
WHEN 'SAVE_EQMREP' THEN  -- 수정 후 저장
  WHILE LENGTH($EQMREPKEY_LIST) > 0 DO
    CALL COMSPLIT($EQMREPKEY_LIST, _$EQMREPKEY);
    CALL COMSPLIT($REGDAY_LIST, _$REGDAY);
    CALL COMSPLIT($REGTIME_LIST, _$REGTIME);
    CALL COMSPLIT($REPSDAY_LIST, _$REPSDAY);
    CALL COMSPLIT($REPSTIME_LIST, _$REPSTIME);
    CALL COMSPLIT($REPEDAY_LIST, _$REPEDAY);
    CALL COMSPLIT($REPETIME_LIST, _$REPETIME);
    CALL COMSPLIT($REPUTIME_LIST, _$REPUTIME);
    CALL COMSPLIT($EQMCD_LIST, _$EQMCD);
    CALL COMSPLIT($REPAMT_LIST, _$REPAMT);
    CALL COMSPLIT($REPCUST_LIST, _$REPCUST);
    CALL COMSPLIT($ISSUE_LIST, _$ISSUE);
    CALL COMSPLIT($MALFUNCTION_LIST, _$MALFUNCTION);
    CALL COMSPLIT($HANDLE_LIST, _$HANDLE);
    CALL COMSPLIT($REMARK_LIST, _$REMARK);

    IF _$REGDAY = '' THEN
      CALL COMERR('등록일자를 입력하세요.');
      LEAVE PROC;
    END IF;

    IF _$REGTIME = '' THEN
      CALL COMERR('등록일시를 입력하세요.');
      LEAVE PROC;
    END IF;

    IF _$REPSDAY = '' THEN
      CALL COMERR('발생일자를 입력하세요.');
      LEAVE PROC;
    END IF;

    IF _$REPSTIME = '' THEN
      CALL COMERR('발생일시를 입력하세요.');
      LEAVE PROC;
    END IF;

    IF _$REPEDAY <> '' AND _$REPETIME = '' THEN
      CALL COMERR('완료일시를 입력하세요.');
      LEAVE PROC;
    END IF;

    IF _$EQMCD = '' THEN
      CALL COMERR('설비를 입력하세요.');
      LEAVE PROC;
    END IF;

    IF _$PARTCD = '' THEN
      CALL COMERR('부품을 입력하세요.');
      LEAVE PROC;
    END IF;

    IF _$REPCUST = '' THEN
      CALL COMERR('수리 업체를 입력하세요.');
      LEAVE PROC;
    END IF;

    IF _$ISSUE = '' THEN
      CALL COMERR('수리 유형을 입력하세요.');
      LEAVE PROC;
    END IF;

    SET _$REGDAYTIME  = IFNULL(CONCAT(_$REGDAY, ' ', _$REGTIME), '');
    SET _$REPSDAYTIME = IFNULL(CONCAT(_$REPSDAY, ' ', _$REPSTIME), '');
    SET _$REPEDAYTIME = IFNULL(CONCAT(_$REPEDAY, ' ', _$REPETIME), '');

    UPDATE EQMREP SET
      EQMCD       = _$EQMCD,
      REGTIME     = _$REGDAYTIME,
      REPSTIME    = _$REPSDAYTIME,
      REPETIME    = _$REPEDAYTIME,
      REPUTIME    = _$REPUTIME,
      REPAMT      = _$REPAMT,
      REPCUST     = _$REPCUST,
      EMPCD       = CALLEMP(),
      HANDLE      = _$HANDLE,
      MALFUNCTION = _$MALFUNCTION,
      ISSUE       = _$ISSUE,
      REMARK      = _$REMARK,
      MTIME       = CALLTIME(),
      MEMP        = CALLEMP(),
      MPRG        = CALLPRG()
    WHERE EQMREPKEY = _$EQMREPKEY;
  END WHILE;

-- *****************************************************************************
WHEN 'DELETE_EQMREP' THEN  -- 설비이력 삭제
  WHILE LENGTH($EQMREPKEY_LIST) > 0 DO
    CALL COMSPLIT($EQMREPKEY_LIST, _$EQMREPKEY);
    DELETE FROM EQMREP_EMP WHERE EQMREPKEY = _$EQMREPKEY;
    DELETE FROM EQMREP     WHERE EQMREPKEY = _$EQMREPKEY;
  END WHILE;

-- *****************************************************************************
WHEN 'SAVE_EMPCD' THEN  -- 작업자 사원 추가
  IF (SELECT 1 FROM EQMREP_EMP WHERE EQMREPKEY = $EQMREPKEY AND EMPCD = $EMPCD) THEN
    CALL COMERR('이미 추가되어 있는 사원정보입니다.');
    LEAVE PROC;
  END IF;

  INSERT INTO EQMREP_EMP (
    EQMREPKEY, EMPCD,
    RTIME, REMP, RPRG
  ) VALUES (
    $EQMREPKEY, $EMPCD,
    CALLTIME(), CALLEMP(), CALLPRG()
  );

-- *****************************************************************************
WHEN 'DELETE_EMPCD' THEN  -- 작업자 사원 행삭제
  WHILE LENGTH($EMPCD_LIST) > 0 DO
    CALL COMSPLIT($EMPCD_LIST, _$EMPCD);

    IF (SELECT COUNT(*) FROM EQMREP_EMP WHERE EQMREPKEY = $EQMREPKEY AND EMPCD <> _$EMPCD) = 0 THEN
      CALL COMERR('최소 한 명의 사원은 남아있어야 합니다.');
      LEAVE PROC;
    END IF;

    DELETE FROM EQMREP_EMP WHERE EQMREPKEY = $EQMREPKEY AND EMPCD = _$EMPCD;
  END WHILE;

-- *****************************************************************************
END CASE; 

END
