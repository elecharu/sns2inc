CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`MST1004_R01`(
-- *****************************************************************************
-- Comment: 설비별 생기팀 호출사원 정보
-- Create: 2026-10-20 17:51: KYC
-- Modify: 
-- *****************************************************************************

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
-- *****************************************************************************

  DECLARE _$FANO_LIST MEDIUMTEXT;

  DECLARE _$EMPCD     VARCHAR(100) DEFAULT '';
  DECLARE _$FANO      VARCHAR(50)  DEFAULT '';
  DECLARE _$EQMCD     VARCHAR(50)  DEFAULT '';
  DECLARE _$FANO_REST MEDIUMTEXT   DEFAULT '';
  DECLARE _$DELAYMIN_ARRIVE VARCHAR(100) DEFAULT '';
  DECLARE _$DELAYMIN_REPAIR VARCHAR(100) DEFAULT '';

-- *****************************************************************************
  CASE $CALLTYPE
-- ****************************************************************************
  WHEN 'LIST_EQM_CALLEMP' THEN

    SELECT 
        EQMCD
      , MSTEQM.LINECD
      , MSTLINE.LINENM
      , GPCD('FM100', MSTEQM.EQMTP) AS EQMTP
      , GPCD('FM113', MSTEQM.EQMGROUP1) AS EQMGROUP1
      , GPCD('FM114', MSTEQM.EQMGROUP2) AS EQMGROUP2
      , GPCD('FM115', MSTEQM.EQMGROUP3) AS EQMGROUP3
      , MSTEQM.EQMNM
      , MSTEMP.EMPCD
      , MSTEMP.EMPNM
      , DELAYMIN_ARRIVE
      , DELAYMIN_REPAIR
      FROM MSTEQM_CALLEMP
      INNER JOIN MSTEMP ON MSTEQM_CALLEMP.EMPCD = MSTEMP.EMPCD
      INNER JOIN MSTEQM ON MSTEQM_CALLEMP.EQMCD = MSTEQM.FANO
      INNER JOIN MSTLINE ON MSTEQM.LINECD = MSTLINE.LINECD
    WHERE MSTLINE.LINECD LIKE CONCAT('%', $LINECD, '%')
      AND MSTEMP.EMPCD LIKE CONCAT('%', $EMPCD, '%')
    ORDER BY MSTEQM.LINECD
            , MSTEQM.EQMTP
            , MSTEQM.EQMGROUP1
            , MSTEQM.EQMGROUP2
            , MSTEQM.EQMGROUP3
            , MSTEQM_CALLEMP.EQMCD
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
      ORDER BY EMPNM, MSTDEPT.DEPTNM;

-- ****************************************************************************
  WHEN 'INS_EQM_CALLEMP' THEN

    IF IFNULL($EMPCD_LIST, '') = '' THEN
      CALL COMERR('등록할 사원이 없습니다.');
      LEAVE PROC;
    END IF;
   
    IF IFNULL($LINECD, '') = '' AND IFNULL($EQMTP, '') = ''
      AND IFNULL($EQMGROUP1, '') = '' AND IFNULL($EQMGROUP2, '') = ''
      AND IFNULL($EQMGROUP3, '') = '' AND IFNULL($FANO, '')      = '' THEN
      CALL COMERR('작업장, 설비구분, 설비분류, 설비번호 중 하나 이상 입력하세요.');
      LEAVE PROC;
    END IF;

    SET _$FANO_LIST = IFNULL((SELECT GROUP_CONCAT(DISTINCT FANO ORDER BY FANO ASC SEPARATOR '»')
                              FROM MSTEQM
                             WHERE USEYN = 'Y'
                               AND (IFNULL($LINECD, '') = '' OR LINECD = $LINECD)
                               AND (IFNULL($EQMTP, '') = '' OR EQMTP = $EQMTP)
                               AND (IFNULL($EQMGROUP1, '') = '' OR EQMGROUP1 = $EQMGROUP1)
                               AND (IFNULL($EQMGROUP2, '') = '' OR EQMGROUP2 = $EQMGROUP2)
                               AND (IFNULL($EQMGROUP3, '') = '' OR EQMGROUP3 = $EQMGROUP3)
                               AND (IFNULL($FANO, '') = '' OR FANO = $FANO)), '');

    IF _$FANO_LIST = '' THEN
      CALL COMERR('조건에 해당하는 설비가 없습니다.');
      LEAVE PROC;
    END IF;
  
    -- 바깥 루프 : 사원
    WHILE IFNULL($EMPCD_LIST, '') <> '' DO
      CALL COMSPLIT($EMPCD_LIST, _$EMPCD);

      -- 사원코드 조회
      SET _$EMPCD = IFNULL((SELECT EMPCD FROM MSTEMP WHERE EMPCD = _$EMPCD), '');

      IF _$EMPCD = '' THEN
        CALL COMERR(CONCAT('사원(', _$EMPCD, ')을 찾을 수 없습니다.'));
        LEAVE PROC;
      END IF;
    
      SET _$FANO_REST = _$FANO_LIST;

      WHILE IFNULL(_$FANO_REST, '') <> '' DO
        CALL COMSPLIT(_$FANO_REST, _$FANO);

        -- 중복 확인
        IF EXISTS(
          SELECT 1
            FROM MSTEQM_CALLEMP
           WHERE EQMCD = _$FANO
             AND EMPCD = _$EMPCD) THEN
          CALL COMERR(CONCAT('이미 등록된 호출사원입니다. ',
            GPCD('EMPCD', _$EMPCD), '(', _$EMPCD, ') / 설비 ', _$FANO));
          LEAVE PROC;
        END IF;
    
        INSERT INTO MSTEQM_CALLEMP(
          EQMCD, EMPCD, DELAYMIN_ARRIVE, DELAYMIN_REPAIR, 
          RTIME, REMP, RPRG)
          VALUES(
          _$FANO, _$EMPCD, IFNULL($DELAYMIN_ARRIVE, 0), IFNULL($DELAYMIN_REPAIR, 0),
          CALLTIME(), CALLEMP(), CALLPRG()
        );
      END WHILE;
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