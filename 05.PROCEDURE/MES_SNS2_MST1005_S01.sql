CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`MST1005_S01`(
-- *****************************************************************************
-- Comment: 설비등급기준 관리
-- Create: 	2026-11-04  	생성 			한성수
-- Modify: 	2026-11-05 					한성수	영역별 저장·원래 키 변경·이전 리비전 조회 전용·구간 겹침 검증, 저장/삭제 검증 분기 분리·공통 확인·변수 정리
-- *****************************************************************************
  IN $REVCD             VARCHAR(20),   -- 리비전 코드
  IN $OLDREVCD          VARCHAR(20),   -- 갱신 원본 리비전 코드
  IN $GMCD              VARCHAR(20),   -- 평가항목코드
  IN $REMARK            VARCHAR(1000), -- 리비전 비고
  IN $GMCD_LIST         MEDIUMTEXT,    -- 평가항목
  IN $GMNM_LIST         MEDIUMTEXT,
  IN $GMTP_LIST         MEDIUMTEXT,
  IN $CALCTP_LIST       MEDIUMTEXT,
  IN $SORTNO_LIST       MEDIUMTEXT,
  IN $REMARK_LIST       MEDIUMTEXT,
  IN $D2_GMCD_LIST      MEDIUMTEXT,    -- 점수별 평가기준
  IN $D2_SCORE_LIST     MEDIUMTEXT,
  IN $D2_ORG_SCORE_LIST MEDIUMTEXT,    -- 조회 시점 점수 (점수 변경 시 기존 행 식별)
  IN $D2_SCORENM_LIST   MEDIUMTEXT,
  IN $D2_MINVAL_LIST    MEDIUMTEXT,
  IN $D2_MAXVAL_LIST    MEDIUMTEXT,
  IN $D2_REMARK_LIST    MEDIUMTEXT,
  IN $EQMGRADE_LIST     MEDIUMTEXT,    -- 설비등급 기준
  IN $GR_ORG_EQMGRADE_LIST MEDIUMTEXT, -- 조회 시점 설비등급 (분류 변경 시 기존 행 식별)
  IN $GR_SCORENM_LIST   MEDIUMTEXT,
  IN $GR_MINVAL_LIST    MEDIUMTEXT,
  IN $GR_MAXVAL_LIST    MEDIUMTEXT,
  IN $MNGNM_LIST        MEDIUMTEXT,
  IN $CHKCYCLE2_LIST    MEDIUMTEXT,

-- *****************************************************************************
  IN $CALLTYPE          VARCHAR(50),
  IN $KEYWORD           VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$REVCD       VARCHAR(20);
  DECLARE _$REVNUM      INT;
  DECLARE _$GMCD        VARCHAR(20);
  DECLARE _$GMNM        VARCHAR(100);
  DECLARE _$GMTP        VARCHAR(10);
  DECLARE _$CALCTP      VARCHAR(10);
  DECLARE _$SORTNO      VARCHAR(20);
  DECLARE _$REMARK      VARCHAR(1000);
  DECLARE _$SCORE       VARCHAR(20);
  DECLARE _$SCORENM     VARCHAR(100);
  DECLARE _$MINVAL      VARCHAR(100);
  DECLARE _$MAXVAL      VARCHAR(100);
  DECLARE _$EQMGRADE    VARCHAR(10);
  DECLARE _$MNGNM       VARCHAR(100);
  DECLARE _$CHKCYCLE2   VARCHAR(10);
  DECLARE _$MSG         VARCHAR(500);  -- 안내 문구 (행 이름·구간 겹침 안내)
  DECLARE _$ORGKEY      VARCHAR(20);
  DECLARE _$SAVEDGMCD   MEDIUMTEXT DEFAULT '';

  -- 1. 리비전 선택 확인 (전체 리비전 조회 LIST_REV, 신규 복사 RENEW_REV 제외)
  IF $CALLTYPE NOT IN ('LIST_REV', 'RENEW_REV') AND $REVCD = '' THEN
    CALL COMERR('리비전을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 2. 저장 및 삭제 공통 확인 (대상 리비전 존재 확인)
  IF $CALLTYPE LIKE 'SAVE_%' OR $CALLTYPE LIKE 'DEL_%' THEN
    SET _$REVNUM = (SELECT REVNUM FROM MSTEQM_GRADEREV WHERE REVCD = $REVCD LIMIT 1 FOR UPDATE);

    IF _$REVNUM IS NULL THEN
      CALL COMERR('선택한 리비전이 없습니다.<br>다시 조회하세요.');
      LEAVE PROC;
    END IF;

    -- 3-1. 기준 저장 제한 검증 (SAVE_D, SAVE_D2, SAVE_SCORE - 비고 저장 SAVE_REV는 허용)
    IF $CALLTYPE IN ('SAVE_D', 'SAVE_D2', 'SAVE_SCORE') THEN
      -- 이전 리비전 수정 차단
      IF _$REVNUM < (SELECT MAX(REVNUM) FROM MSTEQM_GRADEREV) THEN
        CALL COMERR(CONCAT('이전 리비전(REV ', _$REVNUM, ')은 조회만 가능합니다.<br>가장 최근 리비전에서 수정하세요.'));
        LEAVE PROC;
      END IF;

      -- 평가이력 존재 시 수정 차단
      IF EXISTS (SELECT 1 FROM EQMGRADEEVAL WHERE REVCD = $REVCD LIMIT 1) THEN
        CALL COMERR('해당 리비전으로 등록한 평가이력이 있어서 변경할 수 없습니다.<br>리비전 갱신 후 변경하세요.');
        LEAVE PROC;
      END IF;
    END IF;

    -- 3-2. 삭제 제한 검증 (DEL_REV, DEL_D, DEL_D2, DEL_SCORE)
    IF $CALLTYPE LIKE 'DEL_%' THEN
      -- 이전 리비전 삭제 차단
      IF _$REVNUM < (SELECT MAX(REVNUM) FROM MSTEQM_GRADEREV) THEN
        IF $CALLTYPE = 'DEL_REV' THEN
          CALL COMERR(CONCAT('이전 리비전(REV ', _$REVNUM, ')은 삭제할 수 없습니다.<br>가장 최근 리비전만 삭제할 수 있습니다.'));
        ELSE
          CALL COMERR(CONCAT('이전 리비전(REV ', _$REVNUM, ')은 조회만 가능합니다.<br>가장 최근 리비전에서 수정하세요.'));
        END IF;
        LEAVE PROC;
      END IF;

      -- 평가이력 존재 시 삭제 차단
      IF EXISTS (SELECT 1 FROM EQMGRADEEVAL WHERE REVCD = $REVCD LIMIT 1) THEN
        CALL COMERR('해당 리비전으로 등록한 평가이력이 있어서 삭제할 수 없습니다.');
        LEAVE PROC;
      END IF;
    END IF;
  END IF;

-- *****************************************************************************
CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_REV' THEN -- 리비전 조회

    SELECT REVCD, REVNUM, USEYN, REMARK
    FROM MSTEQM_GRADEREV
    ORDER BY REVNUM DESC;

-- *****************************************************************************

  WHEN 'LIST_D' THEN -- 평가항목 조회

    SELECT GMCD, GMNM, GMTP, CALCTP, SORTNO, REMARK
    FROM MSTEQM_GRADEREV_D
    WHERE REVCD = $REVCD
    ORDER BY SORTNO, GMCD;

-- *****************************************************************************

  WHEN 'LIST_D2' THEN -- 선택 평가항목의 점수별 평가기준 조회 

    IF $REVCD = '' OR $GMCD NOT REGEXP '^[0-9]+$' THEN
      CALL COMERR('평가항목을 선택하세요.');
      LEAVE PROC;
    END IF;

    SELECT GMCD, SCORE, SCORE AS ORG_SCORE, SCORENM, MINVAL, MAXVAL, REMARK
    FROM MSTEQM_GRADEREV_D2
    WHERE REVCD = $REVCD
      AND GMCD = $GMCD
    ORDER BY SCORE;

-- *****************************************************************************

  WHEN 'LIST_SCORE' THEN -- 설비등급 기준 조회

    SELECT MSTEQM_GRADEREV_SCORE.EQMGRADE, MSTEQM_GRADEREV_SCORE.EQMGRADE AS ORG_EQMGRADE, MSTEQM_GRADEREV_SCORE.SCORENM,
           MSTEQM_GRADEREV_SCORE.MINVAL, MSTEQM_GRADEREV_SCORE.MAXVAL, MSTEQM_GRADEREV_SCORE.MNGNM, MSTEQM_GRADEREV_SCORE.CHKCYCLE2
    FROM MSTEQM_GRADEREV_SCORE
    LEFT JOIN COMTYPE
      ON COMTYPE.GPCD = 'FM110'
     AND COMTYPE.TPCD = MSTEQM_GRADEREV_SCORE.EQMGRADE
    WHERE MSTEQM_GRADEREV_SCORE.REVCD = $REVCD
    ORDER BY COMTYPE.SORTNO, MSTEQM_GRADEREV_SCORE.EQMGRADE;

-- *****************************************************************************

  WHEN 'RENEW_REV' THEN -- 리비전 갱신 (선택 리비전 기준 복사, 신규 리비전만 사용중)

    IF $OLDREVCD <> '' AND NOT EXISTS (SELECT 1 FROM MSTEQM_GRADEREV WHERE REVCD = $OLDREVCD LIMIT 1) THEN
      CALL COMERR('갱신할 리비전을 다시 조회하세요.');
      LEAVE PROC;
    END IF;

    SET _$REVNUM = (SELECT COALESCE(MAX(REVNUM), 0) + 1 FROM MSTEQM_GRADEREV);
    SET _$REVCD  = GETKEY('REVCD');

    UPDATE MSTEQM_GRADEREV
    SET USEYN = 'N',
        MTIME = CALLTIME(),
        MEMP  = CALLEMP(),
        MPRG  = CALLPRG()
    WHERE USEYN = 'Y';

    INSERT INTO MSTEQM_GRADEREV (
      REVCD, REVNUM, USEYN, RTIME, REMP, RPRG
    ) VALUES (
      _$REVCD, _$REVNUM, 'Y', CALLTIME(), CALLEMP(), CALLPRG()
    );

    INSERT INTO MSTEQM_GRADEREV_D (
      REVCD, GMCD, GMNM, GMTP, CALCTP, SORTNO, REMARK, RTIME, REMP, RPRG
    )
    SELECT _$REVCD, GMCD, GMNM, GMTP, CALCTP, SORTNO, REMARK, CALLTIME(), CALLEMP(), CALLPRG()
    FROM MSTEQM_GRADEREV_D
    WHERE REVCD = $OLDREVCD;

    INSERT INTO MSTEQM_GRADEREV_D2 (
      REVCD, GMCD, SCORE, SCORENM, MINVAL, MAXVAL, REMARK, RTIME, REMP, RPRG
    )
    SELECT _$REVCD, GMCD, SCORE, SCORENM, MINVAL, MAXVAL, REMARK, CALLTIME(), CALLEMP(), CALLPRG()
    FROM MSTEQM_GRADEREV_D2
    WHERE REVCD = $OLDREVCD;

    INSERT INTO MSTEQM_GRADEREV_SCORE (
      REVCD, EQMGRADE, SCORENM, MINVAL, MAXVAL, MNGNM, CHKCYCLE2, RTIME, REMP, RPRG
    )
    SELECT _$REVCD, EQMGRADE, SCORENM, MINVAL, MAXVAL, MNGNM, CHKCYCLE2, CALLTIME(), CALLEMP(), CALLPRG()
    FROM MSTEQM_GRADEREV_SCORE
    WHERE REVCD = $OLDREVCD;

    SELECT _$REVCD AS REVCD;

-- *****************************************************************************

  WHEN 'SAVE_REV' THEN -- 리비전 비고 저장

    UPDATE MSTEQM_GRADEREV
    SET REMARK = $REMARK,
        MTIME  = CALLTIME(),
        MEMP   = CALLEMP(),
        MPRG   = CALLPRG()
    WHERE REVCD = $REVCD;

-- *****************************************************************************

  WHEN 'SAVE_D' THEN -- 평가항목 저장 (신규 항목은 항목코드 발번)

    WHILE LENGTH($GMCD_LIST) > 0 DO
      CALL COMSPLIT($GMCD_LIST, _$GMCD);
      CALL COMSPLIT($GMNM_LIST, _$GMNM);
      CALL COMSPLIT($GMTP_LIST, _$GMTP);
      CALL COMSPLIT($CALCTP_LIST, _$CALCTP);
      CALL COMSPLIT($SORTNO_LIST, _$SORTNO);
      CALL COMSPLIT($REMARK_LIST, _$REMARK);

      IF TRIM(_$GMNM) = '' THEN
        CALL COMERR('평가항목명을 입력하세요.');
        LEAVE PROC;
      END IF;

      IF NOT EXISTS (SELECT 1 FROM COMTYPE WHERE GPCD = 'GMTP' AND TPCD = _$GMTP AND USEYN = 'Y' LIMIT 1) THEN
        CALL COMERR(CONCAT(_$GMNM, '의 구분을 선택하세요.'));
        LEAVE PROC;
      END IF;

      IF _$CALCTP <> '' AND NOT EXISTS (SELECT 1 FROM COMTYPE WHERE GPCD = 'CALCTP' AND TPCD = _$CALCTP AND USEYN = 'Y' LIMIT 1) THEN
        CALL COMERR(CONCAT(_$GMNM, '의 계산구분을 확인하세요.'));
        LEAVE PROC;
      END IF;

      IF _$SORTNO NOT REGEXP '^[0-9]{1,20}$' THEN
        CALL COMERR(CONCAT(_$GMNM, '의 NO(', _$SORTNO, ')를 확인하세요.<br>NO는 20자리 이내 정수로 입력하세요.'));
        LEAVE PROC;
      END IF;

      IF _$GMCD = '' THEN
        SET _$GMCD = (SELECT COALESCE(MAX(GMCD), 0) + 1 FROM MSTEQM_GRADEREV_D);

        INSERT INTO MSTEQM_GRADEREV_D (
          REVCD, GMCD, GMNM, GMTP, CALCTP, SORTNO, REMARK, RTIME, REMP, RPRG
        ) VALUES (
          $REVCD, _$GMCD, _$GMNM, _$GMTP, _$CALCTP, _$SORTNO, _$REMARK, CALLTIME(), CALLEMP(), CALLPRG()
        );
      ELSE
        IF NOT EXISTS (SELECT 1 FROM MSTEQM_GRADEREV_D WHERE REVCD = $REVCD AND GMCD = _$GMCD LIMIT 1) THEN
          CALL COMERR('저장할 평가항목을 다시 조회하세요.');
          LEAVE PROC;
        END IF;

        UPDATE MSTEQM_GRADEREV_D
        SET GMNM   = _$GMNM,
            GMTP   = _$GMTP,
            CALCTP = _$CALCTP,
            SORTNO = _$SORTNO,
            REMARK = _$REMARK,
            MTIME  = CALLTIME(),
            MEMP   = CALLEMP(),
            MPRG   = CALLPRG()
        WHERE REVCD = $REVCD
          AND GMCD = _$GMCD;

        -- 계산구분이 없는 항목은 점수별 평가기준의 최소·최대값을 쓰지 않으므로 비움
        IF _$CALCTP = '' THEN
          UPDATE MSTEQM_GRADEREV_D2
          SET MINVAL = '',
              MAXVAL = '',
              MTIME  = CALLTIME(),
              MEMP   = CALLEMP(),
              MPRG   = CALLPRG()
          WHERE REVCD = $REVCD
            AND GMCD = _$GMCD
            AND (MINVAL <> '' OR MAXVAL <> '');
        END IF;
      END IF;

      SET _$SAVEDGMCD = CONCAT(_$SAVEDGMCD, _$GMCD, '»');
    END WHILE;

    -- 저장한 행 순서대로 평가항목코드 반환 (화면에서 저장한 행 다시 선택)
    SELECT _$SAVEDGMCD AS GMCD_LIST;

-- *****************************************************************************

  WHEN 'SAVE_D2' THEN -- 점수별 평가기준 저장 (최소값 이상 ~ 최대값 미만, 최소 = 최대면 그 값, 빈 값은 제한 없음)

    WHILE LENGTH($D2_GMCD_LIST) > 0 DO
      CALL COMSPLIT($D2_GMCD_LIST, _$GMCD);
      CALL COMSPLIT($D2_SCORE_LIST, _$SCORE);
      CALL COMSPLIT($D2_ORG_SCORE_LIST, _$ORGKEY);
      CALL COMSPLIT($D2_SCORENM_LIST, _$SCORENM);
      CALL COMSPLIT($D2_MINVAL_LIST, _$MINVAL);
      CALL COMSPLIT($D2_MAXVAL_LIST, _$MAXVAL);
      CALL COMSPLIT($D2_REMARK_LIST, _$REMARK);

      SET _$MINVAL = TRIM(_$MINVAL);
      SET _$MAXVAL = TRIM(_$MAXVAL);

      IF _$GMCD = '' THEN
        CALL COMERR('평가항목을 선택하세요.');
        LEAVE PROC;
      END IF;

      SET _$GMNM = (SELECT GMNM FROM MSTEQM_GRADEREV_D WHERE REVCD = $REVCD AND GMCD = _$GMCD LIMIT 1);

      IF _$GMNM IS NULL THEN
        CALL COMERR('저장할 평가항목을 다시 조회하세요.');
        LEAVE PROC;
      END IF;

      -- 계산구분이 없는 항목은 최소·최대값을 쓰지 않으므로 비워서 저장
      SET _$CALCTP = (SELECT CALCTP FROM MSTEQM_GRADEREV_D WHERE REVCD = $REVCD AND GMCD = _$GMCD LIMIT 1);

      IF _$CALCTP = '' THEN
        SET _$MINVAL = '';
        SET _$MAXVAL = '';
      END IF;

      IF _$SCORE NOT REGEXP '^-?[0-9]{1,5}$' THEN
        CALL COMERR(CONCAT(_$GMNM, '의 점수(', _$SCORE, ')를 확인하세요.<br>점수는 -99999 ~ 99999 정수로 입력하세요.'));
        LEAVE PROC;
      END IF;

      SET _$MSG = CONCAT(_$GMNM, ' ', _$SCORE, '점');

      IF (_$MINVAL <> '' AND _$MINVAL NOT REGEXP '^-?[0-9]+([.][0-9]+)?$')
         OR (_$MAXVAL <> '' AND _$MAXVAL NOT REGEXP '^-?[0-9]+([.][0-9]+)?$') THEN
        CALL COMERR(CONCAT(_$MSG, '의<br>최소값·최대값은 숫자로 입력하세요.'));
        LEAVE PROC;
      END IF;

      IF _$MINVAL <> '' AND _$MAXVAL <> '' THEN
        IF (_$MINVAL + 0E0) > (_$MAXVAL + 0E0) THEN
          CALL COMERR(CONCAT(_$MSG, '의<br>최소값은 최대값보다 클 수 없습니다.'));
          LEAVE PROC;
        END IF;

        -- 최소 = 최대(예: 0, 0)는 그 값과 같을 때로 판정, 표기를 최소값으로 통일
        IF (_$MINVAL + 0E0) = (_$MAXVAL + 0E0) THEN
          SET _$MAXVAL = _$MINVAL;
        END IF;
      END IF;

      IF _$ORGKEY <> '' AND CAST(_$ORGKEY AS SIGNED) <> CAST(_$SCORE AS SIGNED) THEN
        -- 저장된 행의 점수 변경 : 조회 시점 점수 행을 새 점수로 변경
        IF NOT EXISTS (SELECT 1 FROM MSTEQM_GRADEREV_D2 WHERE REVCD = $REVCD AND GMCD = _$GMCD AND SCORE = _$ORGKEY LIMIT 1) THEN
          CALL COMERR('저장할 평가기준을 다시 조회하세요.');
          LEAVE PROC;
        END IF;

        IF EXISTS (SELECT 1 FROM MSTEQM_GRADEREV_D2 WHERE REVCD = $REVCD AND GMCD = _$GMCD AND SCORE = _$SCORE LIMIT 1) THEN
          CALL COMERR(CONCAT(_$MSG, '은 이미 등록되어 있습니다.<br>기존 ', _$SCORE, '점 행을 먼저 저장하거나 삭제하세요.'));
          LEAVE PROC;
        END IF;

        UPDATE MSTEQM_GRADEREV_D2
        SET SCORE   = _$SCORE,
            SCORENM = _$SCORENM,
            MINVAL  = _$MINVAL,
            MAXVAL  = _$MAXVAL,
            REMARK  = _$REMARK,
            MTIME   = CALLTIME(),
            MEMP    = CALLEMP(),
            MPRG    = CALLPRG()
        WHERE REVCD = $REVCD
          AND GMCD = _$GMCD
          AND SCORE = _$ORGKEY;
      ELSE
        INSERT INTO MSTEQM_GRADEREV_D2 (
          REVCD, GMCD, SCORE, SCORENM, MINVAL, MAXVAL, REMARK, RTIME, REMP, RPRG
        ) VALUES (
          $REVCD, _$GMCD, _$SCORE, _$SCORENM, _$MINVAL, _$MAXVAL, _$REMARK, CALLTIME(), CALLEMP(), CALLPRG()
        )
        ON DUPLICATE KEY UPDATE
          SCORENM = _$SCORENM,
          MINVAL  = _$MINVAL,
          MAXVAL  = _$MAXVAL,
          REMARK  = _$REMARK,
          MTIME   = CALLTIME(),
          MEMP    = CALLEMP(),
          MPRG    = CALLPRG();
      END IF;
    END WHILE;

    -- 같은 평가항목 안에서 점수별 구간(최소값 이상 ~ 최대값 미만, 최소 = 최대면 그 값)이 겹치면 저장 불가
    SET _$MSG = (
      SELECT LEFT(CONCAT(_$GMNM, '의 ',
                         SCORE_A.SCORE, '점(', SCORE_A.MINVAL, '~', SCORE_A.MAXVAL, ')과 ',
                         SCORE_B.SCORE, '점(', SCORE_B.MINVAL, '~', SCORE_B.MAXVAL, ') 구간이 겹칩니다.<br>최소값(이상)·최대값(미만)을 확인하세요.'), 500)
      FROM MSTEQM_GRADEREV_D2 AS SCORE_A
      INNER JOIN MSTEQM_GRADEREV_D2 AS SCORE_B
        ON SCORE_B.REVCD = SCORE_A.REVCD
       AND SCORE_B.GMCD = SCORE_A.GMCD
       AND SCORE_B.SCORE > SCORE_A.SCORE
      WHERE SCORE_A.REVCD = $REVCD
        AND SCORE_A.GMCD = _$GMCD
        AND NOT (SCORE_A.MINVAL = '' AND SCORE_A.MAXVAL = '')
        AND NOT (SCORE_B.MINVAL = '' AND SCORE_B.MAXVAL = '')
        AND (CASE WHEN SCORE_B.MINVAL <> '' AND SCORE_B.MINVAL = SCORE_B.MAXVAL THEN (IF(SCORE_A.MINVAL = '', '-1E300', SCORE_A.MINVAL) + 0E0) <= (IF(SCORE_B.MAXVAL = '', '1E300', SCORE_B.MAXVAL) + 0E0) ELSE (IF(SCORE_A.MINVAL = '', '-1E300', SCORE_A.MINVAL) + 0E0) < (IF(SCORE_B.MAXVAL = '', '1E300', SCORE_B.MAXVAL) + 0E0) END)
        AND (CASE WHEN SCORE_A.MINVAL <> '' AND SCORE_A.MINVAL = SCORE_A.MAXVAL THEN (IF(SCORE_B.MINVAL = '', '-1E300', SCORE_B.MINVAL) + 0E0) <= (IF(SCORE_A.MAXVAL = '', '1E300', SCORE_A.MAXVAL) + 0E0) ELSE (IF(SCORE_B.MINVAL = '', '-1E300', SCORE_B.MINVAL) + 0E0) < (IF(SCORE_A.MAXVAL = '', '1E300', SCORE_A.MAXVAL) + 0E0) END)
      LIMIT 1
    );

    IF _$MSG IS NOT NULL THEN
      CALL COMERR(_$MSG);
      LEAVE PROC;
    END IF;

-- *****************************************************************************

  WHEN 'SAVE_SCORE' THEN -- 설비등급 기준 저장 (합계점수 최소점수 이상 ~ 최대점수 미만, 최소 = 최대면 그 점수, 빈 값은 제한 없음)

    WHILE LENGTH($EQMGRADE_LIST) > 0 DO
      CALL COMSPLIT($EQMGRADE_LIST, _$EQMGRADE);
      CALL COMSPLIT($GR_ORG_EQMGRADE_LIST, _$ORGKEY);
      CALL COMSPLIT($GR_SCORENM_LIST, _$SCORENM);
      CALL COMSPLIT($GR_MINVAL_LIST, _$MINVAL);
      CALL COMSPLIT($GR_MAXVAL_LIST, _$MAXVAL);
      CALL COMSPLIT($MNGNM_LIST, _$MNGNM);
      CALL COMSPLIT($CHKCYCLE2_LIST, _$CHKCYCLE2);

      SET _$MINVAL = TRIM(_$MINVAL);
      SET _$MAXVAL = TRIM(_$MAXVAL);

      SET _$MSG = (SELECT TPNM FROM COMTYPE WHERE GPCD = 'FM110' AND TPCD = _$EQMGRADE AND USEYN = 'Y' LIMIT 1);

      IF _$MSG IS NULL THEN
        CALL COMERR('분류(설비등급)를 선택하세요.');
        LEAVE PROC;
      END IF;

      IF _$MINVAL = '' AND _$MAXVAL = '' THEN
        CALL COMERR(CONCAT(_$MSG, '등급의 최소점수 또는 최대점수를 입력하세요.'));
        LEAVE PROC;
      END IF;

      IF (_$MINVAL <> '' AND _$MINVAL NOT REGEXP '^-?[0-9]+([.][0-9]+)?$')
         OR (_$MAXVAL <> '' AND _$MAXVAL NOT REGEXP '^-?[0-9]+([.][0-9]+)?$') THEN
        CALL COMERR(CONCAT(_$MSG, '등급의 최소점수·최대점수는 숫자로 입력하세요.'));
        LEAVE PROC;
      END IF;

      IF _$MINVAL <> '' AND _$MAXVAL <> '' THEN
        IF (_$MINVAL + 0E0) > (_$MAXVAL + 0E0) THEN
          CALL COMERR(CONCAT(_$MSG, '등급의 최소점수(', _$MINVAL, ')는<br>최대점수(', _$MAXVAL, ')보다 클 수 없습니다.'));
          LEAVE PROC;
        END IF;

        -- 최소 = 최대는 그 점수와 같을 때로 판정, 표기를 최소점수로 통일
        IF (_$MINVAL + 0E0) = (_$MAXVAL + 0E0) THEN
          SET _$MAXVAL = _$MINVAL;
        END IF;
      END IF;

      IF _$ORGKEY <> '' AND _$ORGKEY <> _$EQMGRADE THEN
        -- 저장된 행의 분류 변경 : 조회 시점 설비등급 행을 새 설비등급으로 변경
        IF NOT EXISTS (SELECT 1 FROM MSTEQM_GRADEREV_SCORE WHERE REVCD = $REVCD AND EQMGRADE = _$ORGKEY LIMIT 1) THEN
          CALL COMERR('저장할 설비등급 기준을 다시 조회하세요.');
          LEAVE PROC;
        END IF;

        IF EXISTS (SELECT 1 FROM MSTEQM_GRADEREV_SCORE WHERE REVCD = $REVCD AND EQMGRADE = _$EQMGRADE LIMIT 1) THEN
          CALL COMERR(CONCAT(_$MSG, '등급은 이미 등록되어 있습니다.<br>기존 ', _$MSG, '등급 행을 먼저 저장하거나 삭제하세요.'));
          LEAVE PROC;
        END IF;

        UPDATE MSTEQM_GRADEREV_SCORE
        SET EQMGRADE  = _$EQMGRADE,
            SCORENM   = _$SCORENM,
            MINVAL    = _$MINVAL,
            MAXVAL    = _$MAXVAL,
            MNGNM     = _$MNGNM,
            CHKCYCLE2 = _$CHKCYCLE2,
            MTIME     = CALLTIME(),
            MEMP      = CALLEMP(),
            MPRG      = CALLPRG()
        WHERE REVCD = $REVCD
          AND EQMGRADE = _$ORGKEY;
      ELSE
        INSERT INTO MSTEQM_GRADEREV_SCORE (
          REVCD, EQMGRADE, SCORENM, MINVAL, MAXVAL, MNGNM, CHKCYCLE2, RTIME, REMP, RPRG
        ) VALUES (
          $REVCD, _$EQMGRADE, _$SCORENM, _$MINVAL, _$MAXVAL, _$MNGNM, _$CHKCYCLE2, CALLTIME(), CALLEMP(), CALLPRG()
        )
        ON DUPLICATE KEY UPDATE
          SCORENM   = _$SCORENM,
          MINVAL    = _$MINVAL,
          MAXVAL    = _$MAXVAL,
          MNGNM     = _$MNGNM,
          CHKCYCLE2 = _$CHKCYCLE2,
          MTIME     = CALLTIME(),
          MEMP      = CALLEMP(),
          MPRG      = CALLPRG();
      END IF;
    END WHILE;

    -- [메시지] 같은 리비전 안에서 등급별 점수 구간(최소점수 이상 ~ 최대점수 미만, 최소 = 최대면 그 점수)이 겹치면 저장 불가
    SET _$MSG = (
      SELECT LEFT(CONCAT(IFNULL(GRADE_A.TPNM, SCORE_A.EQMGRADE), '등급(', SCORE_A.MINVAL, '~', SCORE_A.MAXVAL, ')과 ',
                         IFNULL(GRADE_B.TPNM, SCORE_B.EQMGRADE), '등급(', SCORE_B.MINVAL, '~', SCORE_B.MAXVAL, ')의 점수 구간이 겹칩니다.<br>최소점수(이상)·최대점수(미만)를 확인하세요.'), 500)
      FROM MSTEQM_GRADEREV_SCORE AS SCORE_A
      INNER JOIN MSTEQM_GRADEREV_SCORE AS SCORE_B
        ON SCORE_B.REVCD = SCORE_A.REVCD
       AND SCORE_B.EQMGRADE > SCORE_A.EQMGRADE
      LEFT JOIN COMTYPE AS GRADE_A
        ON GRADE_A.GPCD = 'FM110'
       AND GRADE_A.TPCD = SCORE_A.EQMGRADE
      LEFT JOIN COMTYPE AS GRADE_B
        ON GRADE_B.GPCD = 'FM110'
       AND GRADE_B.TPCD = SCORE_B.EQMGRADE
      WHERE SCORE_A.REVCD = $REVCD
        AND (CASE WHEN SCORE_B.MINVAL <> '' AND SCORE_B.MINVAL = SCORE_B.MAXVAL THEN (IF(SCORE_A.MINVAL = '', '-1E300', SCORE_A.MINVAL) + 0E0) <= (IF(SCORE_B.MAXVAL = '', '1E300', SCORE_B.MAXVAL) + 0E0) ELSE (IF(SCORE_A.MINVAL = '', '-1E300', SCORE_A.MINVAL) + 0E0) < (IF(SCORE_B.MAXVAL = '', '1E300', SCORE_B.MAXVAL) + 0E0) END)
        AND (CASE WHEN SCORE_A.MINVAL <> '' AND SCORE_A.MINVAL = SCORE_A.MAXVAL THEN (IF(SCORE_B.MINVAL = '', '-1E300', SCORE_B.MINVAL) + 0E0) <= (IF(SCORE_A.MAXVAL = '', '1E300', SCORE_A.MAXVAL) + 0E0) ELSE (IF(SCORE_B.MINVAL = '', '-1E300', SCORE_B.MINVAL) + 0E0) < (IF(SCORE_A.MAXVAL = '', '1E300', SCORE_A.MAXVAL) + 0E0) END)
      LIMIT 1
    );

    IF _$MSG IS NOT NULL THEN
      CALL COMERR(_$MSG);
      LEAVE PROC;
    END IF;

-- *****************************************************************************

  WHEN 'DEL_REV' THEN -- 리비전 삭제 (가장 최근 리비전만, 삭제 후 남은 가장 최근 리비전을 사용중으로)

    DELETE FROM MSTEQM_GRADEREV_D2    WHERE REVCD = $REVCD;
    DELETE FROM MSTEQM_GRADEREV_D     WHERE REVCD = $REVCD;
    DELETE FROM MSTEQM_GRADEREV_SCORE WHERE REVCD = $REVCD;
    DELETE FROM MSTEQM_GRADEREV       WHERE REVCD = $REVCD;

    SET _$REVNUM = (SELECT MAX(REVNUM) FROM MSTEQM_GRADEREV);

    UPDATE MSTEQM_GRADEREV
    SET USEYN = IF(REVNUM = _$REVNUM, 'Y', 'N'),
        MTIME = CALLTIME(),
        MEMP  = CALLEMP(),
        MPRG  = CALLPRG()
    WHERE USEYN <> IF(REVNUM = _$REVNUM, 'Y', 'N');

-- *****************************************************************************

  WHEN 'DEL_D' THEN -- 평가항목 삭제 (점수별 평가기준 포함)

    WHILE LENGTH($GMCD_LIST) > 0 DO
      CALL COMSPLIT($GMCD_LIST, _$GMCD);

      DELETE FROM MSTEQM_GRADEREV_D2 WHERE REVCD = $REVCD AND GMCD = _$GMCD;
      DELETE FROM MSTEQM_GRADEREV_D  WHERE REVCD = $REVCD AND GMCD = _$GMCD;
    END WHILE;

-- *****************************************************************************

  WHEN 'DEL_D2' THEN -- 점수별 평가기준 삭제

    IF $GMCD NOT REGEXP '^[0-9]+$' THEN
      CALL COMERR('평가항목을 선택하세요.');
      LEAVE PROC;
    END IF;

    WHILE LENGTH($D2_SCORE_LIST) > 0 DO
      CALL COMSPLIT($D2_SCORE_LIST, _$SCORE);

      DELETE FROM MSTEQM_GRADEREV_D2 WHERE REVCD = $REVCD AND GMCD = $GMCD AND SCORE = _$SCORE;
    END WHILE;

-- *****************************************************************************

  WHEN 'DEL_SCORE' THEN -- 설비등급 기준 삭제

    WHILE LENGTH($EQMGRADE_LIST) > 0 DO
      CALL COMSPLIT($EQMGRADE_LIST, _$EQMGRADE);

      DELETE FROM MSTEQM_GRADEREV_SCORE WHERE REVCD = $REVCD AND EQMGRADE = _$EQMGRADE;
    END WHILE;

-- *****************************************************************************
END CASE;

END
