CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`MST1006_R01`(
-- *****************************************************************************
-- Comment: 설비고장율 목표관리
-- Create: 	2026-11-26  	생성 			한성수
-- Modify: 	2026-11-26 					한성수	목표년도별 라인 목표(LIST_LINE·SAVE_LINE)·라인 설비별 목표(LIST_EQM·SAVE_EQM) 조회·저장 (목표 점유율·년 목표 비가동시간, 둘 다 비우면 목표 삭제)
-- Modify: 	2026-11-27 					한성수	설비 목표 년 목표 비가동시간 삭제(설비고장율 현황에서 사용 안 함), 설비 목표는 목표 점유율만 조회·저장, 라인 년 목표 비가동시간은 정수만 입력, 저장 후 선택 라인 찾기용 LINEKEY 삭제
-- *****************************************************************************
  IN $SYEAR             VARCHAR(4),    -- 목표년도
  IN $LINECD            VARCHAR(10),   -- 작업장
  IN $EQMTP             VARCHAR(10),   -- 공정(설비구분)
  IN $EQMGROUP1         VARCHAR(10),   -- 라인(설비대분류)
  IN $FANO              VARCHAR(50),   -- 설비번호
  IN $GOALRATE          VARCHAR(20),   -- 목표 점유율(%), 빈 값은 미입력
  IN $GOALHR            VARCHAR(20),   -- 년 목표 비가동시간(hr, 정수), 빈 값은 미입력

-- *****************************************************************************
  IN $CALLTYPE          VARCHAR(50),
  IN $KEYWORD           VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  IF IFNULL($SYEAR, '') NOT REGEXP '^[0-9]{4}$' THEN
    CALL COMERR('목표년도를 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 저장 공통: 목표 점유율은 빈 값 또는 0 이상 숫자, 년 목표 비가동시간은 빈 값 또는 0 이상 정수
  IF $CALLTYPE IN ('SAVE_LINE', 'SAVE_EQM') THEN
    SET $GOALRATE = TRIM(IFNULL($GOALRATE, ''));
    SET $GOALHR = TRIM(IFNULL($GOALHR, ''));

    IF $GOALRATE <> '' AND $GOALRATE NOT REGEXP '^[0-9]+([.][0-9]+)?$' THEN
      CALL COMERR('목표 점유율은 0 이상 숫자로 입력하세요.');
      LEAVE PROC;
    END IF;

    IF $GOALHR <> '' AND $GOALHR NOT REGEXP '^[0-9]+$' THEN
      CALL COMERR('년 목표 비가동시간은 0 이상 정수로 입력하세요.');
      LEAVE PROC;
    END IF;
  END IF;

-- *****************************************************************************
CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_LINE' THEN -- 라인별 목표 조회 (2공장 사용 설비의 작업장·공정·라인)

    SELECT $SYEAR AS SYEAR,
           LINE_LIST.LINECD,
           LINE_LIST.EQMTP,
           LINE_LIST.EQMGROUP1,
           CAST(MSTEQM_FAILGOAL_LINE.GOALRATE AS DOUBLE) AS GOALRATE,
           MSTEQM_FAILGOAL_LINE.GOALHR
    FROM (
      SELECT LINECD, EQMTP, EQMGROUP1
      FROM MSTEQM
      WHERE FACTORYCD = '07'
        AND USEYN = 'Y'
        AND LINECD <> ''
        AND EQMTP <> ''
        AND EQMGROUP1 <> ''
        AND ($LINECD = '' OR LINECD = $LINECD)
        AND ($EQMTP = '' OR EQMTP = $EQMTP)
        AND ($EQMGROUP1 = '' OR EQMGROUP1 = $EQMGROUP1)
      GROUP BY LINECD, EQMTP, EQMGROUP1
    ) LINE_LIST
    LEFT JOIN MSTEQM_FAILGOAL_LINE
      ON MSTEQM_FAILGOAL_LINE.SYEAR = $SYEAR
     AND MSTEQM_FAILGOAL_LINE.LINECD = LINE_LIST.LINECD
     AND MSTEQM_FAILGOAL_LINE.EQMTP = LINE_LIST.EQMTP
     AND MSTEQM_FAILGOAL_LINE.EQMGROUP1 = LINE_LIST.EQMGROUP1
    ORDER BY LINE_LIST.LINECD, LINE_LIST.EQMTP, LINE_LIST.EQMGROUP1;

-- *****************************************************************************

  WHEN 'LIST_EQM' THEN -- 선택 라인의 설비별 목표 조회

    SELECT $SYEAR AS SYEAR,
           MSTEQM.FANO,
           MSTEQM.EQMNM,
           CAST(MSTEQM_FAILGOAL.GOALRATE AS DOUBLE) AS GOALRATE
    FROM MSTEQM
    LEFT JOIN MSTEQM_FAILGOAL
      ON MSTEQM_FAILGOAL.SYEAR = $SYEAR
     AND MSTEQM_FAILGOAL.FANO = MSTEQM.FANO
    WHERE MSTEQM.FACTORYCD = '07'
      AND MSTEQM.USEYN = 'Y'
      AND MSTEQM.LINECD = $LINECD
      AND MSTEQM.EQMTP = $EQMTP
      AND MSTEQM.EQMGROUP1 = $EQMGROUP1
    ORDER BY MSTEQM.FANO;

-- *****************************************************************************

  WHEN 'SAVE_LINE' THEN -- 라인 목표 저장 (목표 점유율·년 목표 비가동시간 둘 다 비우면 목표 삭제)

    IF $GOALRATE = '' AND $GOALHR = '' THEN
      DELETE FROM MSTEQM_FAILGOAL_LINE
      WHERE SYEAR = $SYEAR
        AND LINECD = $LINECD
        AND EQMTP = $EQMTP
        AND EQMGROUP1 = $EQMGROUP1;
    ELSE
      INSERT INTO MSTEQM_FAILGOAL_LINE (
        SYEAR, LINECD, EQMTP, EQMGROUP1, GOALRATE, GOALHR,
        RTIME, REMP, RPRG
      ) VALUES (
        $SYEAR, $LINECD, $EQMTP, $EQMGROUP1, NULLIF($GOALRATE, ''), NULLIF($GOALHR, ''),
        CALLTIME(), CALLEMP(), CALLPRG()
      )
      ON DUPLICATE KEY UPDATE
        GOALRATE = VALUES(GOALRATE),
        GOALHR   = VALUES(GOALHR),
        MTIME    = CALLTIME(),
        MEMP     = CALLEMP(),
        MPRG     = CALLPRG();
    END IF;

-- *****************************************************************************

  WHEN 'SAVE_EQM' THEN -- 설비 목표 저장 (목표 점유율 비우면 목표 삭제)

    IF $GOALRATE = '' THEN
      DELETE FROM MSTEQM_FAILGOAL
      WHERE SYEAR = $SYEAR
        AND FANO = $FANO;
    ELSE
      INSERT INTO MSTEQM_FAILGOAL (
        SYEAR, FANO, GOALRATE,
        RTIME, REMP, RPRG
      ) VALUES (
        $SYEAR, $FANO, $GOALRATE,
        CALLTIME(), CALLEMP(), CALLPRG()
      )
      ON DUPLICATE KEY UPDATE
        GOALRATE = VALUES(GOALRATE),
        MTIME    = CALLTIME(),
        MEMP     = CALLEMP(),
        MPRG     = CALLPRG();
    END IF;

-- *****************************************************************************
END CASE;

END
