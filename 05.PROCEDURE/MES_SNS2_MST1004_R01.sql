CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.MST1004_R01(
-- *****************************************************************************
-- Comment: 설비별 생기팀 호출사원 정보
-- Create: 2026-10-20 17:51: 김영철
-- Modify: 2026-10-27: 조회조건 공장·작업장·사원 추가 (LIST_EQM_CALLEMP)
--         2026-11-24: 한성수 호출사원 작업장 기준 등록·조회로 변경
--         2026-11-25: 한성수 이미 등록된 호출사원 안내를 한 번에 모아서 표시, 등록 팝업 사원 목록 사원코드 순 정렬
-- *****************************************************************************

  IN $FACTORYCD       VARCHAR(10),       -- 공장
  IN $EQMCD           VARCHAR(20),
  IN $LINECD          VARCHAR(20),
  IN $EMPCD           VARCHAR(20),

  IN $EMPCD_LIST      MEDIUMTEXT,        -- 선택 사원CD 목록
  IN $EQMCD_LIST      MEDIUMTEXT,
  IN $DELAYMIN_ARRIVE_LIST      MEDIUMTEXT,
  IN $DELAYMIN_REPAIR_LIST      MEDIUMTEXT,

  IN $EQMTP           VARCHAR(10),       -- 설비구분
  IN $EQMGROUP1       VARCHAR(10),       -- 설비대분류
  IN $EQMGROUP2       VARCHAR(10),       -- 설비중분류
  IN $EQMGROUP3       VARCHAR(10),       -- 설비소분류
  IN $FANO            VARCHAR(50),       -- 설비번호

  IN $DELAYMIN_ARRIVE DECIMAL(20, 0),    -- 호출도착 지연시간(분)
  IN $DELAYMIN_REPAIR DECIMAL(20, 0),    -- 수리종료 지연시간(분)

  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';

  DECLARE _$EMPCD     VARCHAR(100) DEFAULT '';
  DECLARE _$EQMCD     VARCHAR(50)  DEFAULT '';
  DECLARE _$DELAYMIN_ARRIVE VARCHAR(100) DEFAULT '';
  DECLARE _$DELAYMIN_REPAIR VARCHAR(100) DEFAULT '';
  DECLARE _$CHK_LIST  MEDIUMTEXT   DEFAULT '';
  DECLARE _$DUPNM     VARCHAR(2000) DEFAULT '';

-- *****************************************************************************
  CASE $CALLTYPE
-- ****************************************************************************
  WHEN 'LIST_EQM_CALLEMP' THEN

    SELECT
        EQMCD -- 작업장코드
      , MSTLINE.LINENM
      , MSTEMP.EMPCD
      , MSTEMP.EMPNM
      , DELAYMIN_ARRIVE
      , DELAYMIN_REPAIR
      FROM MSTEQM_CALLEMP
      INNER JOIN MSTEMP ON MSTEQM_CALLEMP.EMPCD = MSTEMP.EMPCD
      INNER JOIN MSTLINE ON MSTEQM_CALLEMP.EQMCD = MSTLINE.LINECD
      WHERE (IFNULL($FACTORYCD, '') = '' OR MSTLINE.FACTORYCD = $FACTORYCD)
        AND (IFNULL($LINECD, '') = '' OR MSTEQM_CALLEMP.EQMCD = $LINECD)
        AND (IFNULL($EMPCD, '') = '' OR MSTEQM_CALLEMP.EMPCD = $EMPCD)
    ORDER BY MSTEQM_CALLEMP.EQMCD
            , MSTEMP.EMPCD;

-- ****************************************************************************
  WHEN 'LIST_EMP' THEN

    SELECT
        EMPCD
      , EMPNM
      , MSTDEPT.DEPTNM AS DEPTCD
      FROM MSTEMP
      INNER JOIN MSTDEPT ON MSTEMP.DEPTCD = MSTDEPT.DEPTCD
      WHERE EMPCD LIKE CONCAT('%', $EMPCD, '%')
        AND EMPID <> ''
        AND MSTEMP.DEPTCD = '44F30'
      ORDER BY EMPCD;

-- ****************************************************************************
  WHEN 'INS_EQM_CALLEMP' THEN

    IF IFNULL($EMPCD_LIST, '') = '' THEN
      CALL COMERR('등록할 사원이 없습니다.');
      LEAVE PROC;
    END IF;

    IF IFNULL($LINECD, '') = '' THEN
      CALL COMERR('작업장을 선택하세요.');
      LEAVE PROC;
    END IF;

    -- 사원 확인 및 이미 등록된 사원 모으기 (한 번에 안내)
    SET _$CHK_LIST = $EMPCD_LIST;
    WHILE IFNULL(_$CHK_LIST, '') <> '' DO
      CALL COMSPLIT(_$CHK_LIST, _$EMPCD);

      -- 사원코드 조회
      SET _$EMPCD = IFNULL((SELECT EMPCD FROM MSTEMP WHERE EMPCD = _$EMPCD), '');

      IF _$EMPCD = '' THEN
        CALL COMERR(CONCAT('사원(', _$EMPCD, ')을 찾을 수 없습니다.'));
        LEAVE PROC;
      END IF;

      -- 중복 확인
      IF EXISTS(
        SELECT 1
          FROM MSTEQM_CALLEMP
         WHERE EQMCD = $LINECD
           AND EMPCD = _$EMPCD) THEN
        SET _$DUPNM = CONCAT(_$DUPNM, IF(_$DUPNM = '', '', ', '), GPCD('EMPCD', _$EMPCD));
      END IF;
    END WHILE;

    IF _$DUPNM <> '' THEN
      CALL COMERR(CONCAT('이미 등록된 호출사원입니다. (', _$DUPNM, ')'));
      LEAVE PROC;
    END IF;

    -- 바깥 루프 : 사원
    WHILE IFNULL($EMPCD_LIST, '') <> '' DO
      CALL COMSPLIT($EMPCD_LIST, _$EMPCD);

      -- EQMCD에 작업장코드 저장
      INSERT INTO MSTEQM_CALLEMP(
        EQMCD, EMPCD, DELAYMIN_ARRIVE, DELAYMIN_REPAIR,
        RTIME, REMP, RPRG)
        VALUES(
        $LINECD, _$EMPCD, IFNULL($DELAYMIN_ARRIVE, 0), IFNULL($DELAYMIN_REPAIR, 0),
        CALLTIME(), CALLEMP(), CALLPRG()
      );
    END WHILE;

-- ****************************************************************************
  WHEN 'UPD_EQM_CALLEMP' THEN

    IF IFNULL($EQMCD_LIST, '') = '' OR IFNULL($EMPCD_LIST, '') = '' THEN
      CALL COMERR('수정할 호출사원이 없습니다.');
      LEAVE PROC;
    END IF;

    -- 바깥 루프 : 사원
    WHILE IFNULL($EMPCD_LIST, '') <> '' DO
      CALL COMSPLIT($EMPCD_LIST, _$EMPCD);
      CALL COMSPLIT($EQMCD_LIST, _$EQMCD);
      CALL COMSPLIT($DELAYMIN_ARRIVE_LIST, _$DELAYMIN_ARRIVE);
      CALL COMSPLIT($DELAYMIN_REPAIR_LIST, _$DELAYMIN_REPAIR);

      -- 호출사원 지연시간 수정
      UPDATE MSTEQM_CALLEMP
         SET DELAYMIN_ARRIVE = IFNULL(_$DELAYMIN_ARRIVE, 0),
             DELAYMIN_REPAIR = IFNULL(_$DELAYMIN_REPAIR, 0),
             RTIME = CALLTIME(),
             REMP = CALLEMP(),
             RPRG = CALLPRG()
       WHERE EQMCD = _$EQMCD
         AND EMPCD = _$EMPCD;

    END WHILE;

-- ****************************************************************************
WHEN 'DEL_EQM_CALLEMP' THEN

    IF IFNULL($EQMCD_LIST, '') = '' OR IFNULL($EMPCD_LIST, '') = '' THEN
      CALL COMERR('삭제할 호출사원을 선택하세요.');
      LEAVE PROC;
    END IF;

    WHILE IFNULL($EQMCD_LIST, '') <> '' DO
      CALL COMSPLIT($EQMCD_LIST, _$EQMCD);
      CALL COMSPLIT($EMPCD_LIST, _$EMPCD);

      DELETE FROM MSTEQM_CALLEMP
       WHERE EQMCD = _$EQMCD
         AND EMPCD = _$EMPCD;

    END WHILE;

-- ****************************************************************************
  END CASE;
END
