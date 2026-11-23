CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.MST3001_R05(
-- *****************************************************************************
-- Comment: 외주처 소모품 분류등록 (INC 2공장 소모공구류 사용위치 관리)
-- Create:  2026-10-28 : 김영철
-- Modify:  2026-10-28 : 김영철 좌우 분할(품목 / 사용위치) + 일괄 추가 팝업용 SEL_CLASSIFY, SEL_POP_EQM, SEL_POP_TURRET, ADD_ITEM 추가
-- Modify:  2026-11-03 : 김영철 품목유형 소모자재(DM100750) → 소모공구류(DM100990)
-- Modify:  2026-11-03 : 김영철 ADD_ITEM·SAVE_ITEM 제품·세부공정·터렛 빈 값 불가
-- Modify:  2026-11-03 : 김영철 SEL_CLASSIFY 를 선택한 품목 1건($ITEMID) 기준으로 (위치별 묶음·품목별 위치수 제거)
-- Modify:  2026-11-03 : 김영철 SEL_CLASSIFY 품목수(ITEMCNT) 제거,SEL_ITEM 공장 조건·재고 공장을 $FACTORYCD 로 (DB 에서 고친 내용 반영)
-- Modify:  2026-10-30 : 김영철 SEL_ITEM 안전재고·현재고·위치수를 공장 07 기준으로, SAVE_ITEM 위치 중복 시 에러
-- Modify:  2026-10-30 : 김영철 안전재고 저장 SAVE_SAFEQTY 추가 (파라미터 SAFEQTY_LIST 추가)
-- Modify:  2026-10-30 : 김영철 여러 품목 동시 수정·삭제 (SEL_CLASSIFY 를 ITEMID_LIST 위치별 묶음으로, SAVE_ITEM 은 품목별 수정/추가/제외), SEL_POP_DEL 제거
-- *****************************************************************************
  IN $COMPANYCD             VARCHAR(100),
  IN $FACTORYCD             VARCHAR(100),
  IN $ITEMID                VARCHAR(100),
  IN $ENDYN                 VARCHAR(1),
  IN $ITEMCG                VARCHAR(100),
  IN $LINECD                VARCHAR(100),
  IN $PRCCD                 VARCHAR(100),
  IN $ITEMID_LIST           MEDIUMTEXT,
  IN $LINECD_LIST           MEDIUMTEXT,
  IN $PRCCD_LIST            MEDIUMTEXT,
  IN $EQMCD_LIST            MEDIUMTEXT,
  IN $ITEMID_PRD_LIST       MEDIUMTEXT,
  IN $PRCDETAIL_LIST        MEDIUMTEXT,
  IN $TURRET_LIST           MEDIUMTEXT,
  IN $OLD_LINECD_LIST       MEDIUMTEXT,
  IN $OLD_PRCCD_LIST        MEDIUMTEXT,
  IN $OLD_EQMCD_LIST        MEDIUMTEXT,
  IN $OLD_ITEMID_PRD_LIST   MEDIUMTEXT,
  IN $OLD_PRCDETAIL_LIST    MEDIUMTEXT,
  IN $OLD_TURRET_LIST       MEDIUMTEXT,
  IN $SAFEQTY_LIST          MEDIUMTEXT,
-- *****************************************************************************
  IN $CALLTYPE              VARCHAR(100)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$ITEMID         VARCHAR(100);
  DECLARE _$LINECD         VARCHAR(100);
  DECLARE _$PRCCD          VARCHAR(100);
  DECLARE _$EQMCD          VARCHAR(100);
  DECLARE _$ITEMID_PRD     VARCHAR(100);
  DECLARE _$PRCDETAIL      VARCHAR(100);
  DECLARE _$TURRET         VARCHAR(100);
  DECLARE _$OLD_LINECD     VARCHAR(100);
  DECLARE _$OLD_PRCCD      VARCHAR(100);
  DECLARE _$OLD_EQMCD      VARCHAR(100);
  DECLARE _$OLD_ITEMID_PRD VARCHAR(100);
  DECLARE _$OLD_PRCDETAIL  VARCHAR(100);
  DECLARE _$OLD_TURRET     VARCHAR(100);
  DECLARE _$SAFEQTY        VARCHAR(100);
  DECLARE _$FACTORYCD      VARCHAR(100);
  DECLARE _$ADDCNT         INT DEFAULT 0;
  DECLARE _$SKIPCNT        INT DEFAULT 0;

-- *****************************************************************************
  CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'SEL_ITEM' THEN -- INC 2공장 소모공구류 품목 조회 (품목 1건 = 1행, 등록된 사용위치 수 포함)

    SET $ITEMID = TRIM(IFNULL($ITEMID, ''));
    SET $ENDYN = IF(IFNULL($ENDYN, '') = 'Y', 'Y', 'N');

    SELECT CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID,
           MSTITEM.ITEMCD,
           MSTITEM.ITEMNM,
           MSTITEM.ITEMSPEC,
           IFNULL(MSTITEM_OSCCONSUM.SAFEQTY, 0) AS SAFEQTY,
           IFNULL(MSTITEM_OSCCONSUM.LOTQTY, 0) AS LOTQTY,
           (SELECT COUNT(*)
              FROM MSTITEM_OSCCONSUM_CLASSIFY
              WHERE MSTITEM_OSCCONSUM_CLASSIFY.ITEMID = MSTITEM.ITEMID
                AND MSTITEM_OSCCONSUM_CLASSIFY.FACTORYCD = $FACTORYCD) AS LOCCNT,
           MSTITEM.ITEM_LVL1,
           MSTITEM.ITEM_LVL2,
           MSTITEM.ITEM_LVL3,
           MSTITEM.ITEM_LVL4,
           MSTITEM.ITEMUNIT,
           MSTITEM.ITEMSRC,
           MSTITEM.ENDYN,
           CASE
             WHEN IFNULL(MSTITEM_OSCCONSUM.LOTQTY, 0) < IFNULL(MSTITEM_OSCCONSUM.SAFEQTY, 0) THEN 'PINK'
             ELSE ''
           END AS BACKGROUND
    FROM MSTITEM
    INNER JOIN MSTITEM_FACTORY ON MSTITEM.ITEMID = MSTITEM_FACTORY.ITEMID
    LEFT JOIN MSTITEM_OSCCONSUM
           ON MSTITEM_OSCCONSUM.ITEMID = MSTITEM.ITEMID
          AND MSTITEM_OSCCONSUM.FACTORYCD = $FACTORYCD
    WHERE MSTITEM.COMPANYCD LIKE CONCAT('%', $COMPANYCD, '%')
      AND MSTITEM_FACTORY.FACTORYCD LIKE CONCAT('%', $FACTORYCD, '%')
      AND MSTITEM.ITEMCG = $ITEMCG
      AND MSTITEM.ENDYN = $ENDYN
      AND ($ITEMID = ''
           OR MSTITEM.ITEMID LIKE CONCAT('%', $ITEMID, '%')
           OR MSTITEM.ITEMCD LIKE CONCAT('%', $ITEMID, '%')
           OR MSTITEM.ITEMNM LIKE CONCAT('%', $ITEMID, '%')
          )
    ORDER BY MSTITEM.ITEMCD;

  -- *****************************************************************************

  WHEN 'SEL_CLASSIFY' THEN -- 선택한 품목의 사용위치 조회

    -- 빈 값을 숫자로 바꾸면 경고가 나고 COMCALLC 가 에러로 돌려주므로 0 으로 바꿔 둔다
    SET $ITEMID = IF(TRIM(IFNULL($ITEMID, '')) = '', '0', TRIM($ITEMID));

    SELECT MSTITEM_OSCCONSUM_CLASSIFY.LINECD,
           MSTITEM_OSCCONSUM_CLASSIFY.PRCCD,
           MSTITEM_OSCCONSUM_CLASSIFY.EQMCD,
           CASE
             WHEN MSTITEM_OSCCONSUM_CLASSIFY.ITEMID_PRD = 0 THEN ''
             ELSE CAST(MSTITEM_OSCCONSUM_CLASSIFY.ITEMID_PRD AS CHAR)
           END AS ITEMID_PRD,
           MSTITEM_OSCCONSUM_CLASSIFY.PRCDETAIL,
           MSTITEM_OSCCONSUM_CLASSIFY.TURRET
    FROM MSTITEM_OSCCONSUM_CLASSIFY
    LEFT JOIN COMTYPE
           ON COMTYPE.GPCD = 'TURRET'
          AND COMTYPE.TPCD = MSTITEM_OSCCONSUM_CLASSIFY.TURRET
    WHERE MSTITEM_OSCCONSUM_CLASSIFY.ITEMID = $ITEMID
      AND MSTITEM_OSCCONSUM_CLASSIFY.FACTORYCD = '07'
    ORDER BY MSTITEM_OSCCONSUM_CLASSIFY.LINECD,
             MSTITEM_OSCCONSUM_CLASSIFY.PRCCD,
             MSTITEM_OSCCONSUM_CLASSIFY.EQMCD,
             MSTITEM_OSCCONSUM_CLASSIFY.PRCDETAIL,
             COMTYPE.SORTNO;

  -- *****************************************************************************

  WHEN 'SEL_POP_EQM' THEN -- 일괄 추가 팝업: 작업장(·공정)의 라인 목록

    SELECT MSTLINE_EQM.LINECD,
           MSTLINE_EQM.PRCCD,
           MSTLINE_EQM.EQMCD,
           MSTLINE_EQM.EQMNM,
           '' AS ITEMID_PRD,
           '' AS PRCDETAIL
    FROM MSTLINE_EQM
    INNER JOIN MSTLINE
           ON MSTLINE.LINECD = MSTLINE_EQM.LINECD
    WHERE MSTLINE_EQM.USEYN = 'Y'
      AND MSTLINE.FACTORYCD = '07'
      AND MSTLINE_EQM.LINECD = IFNULL($LINECD, '')
      AND (IFNULL($PRCCD, '') = '' OR MSTLINE_EQM.PRCCD = $PRCCD)
    ORDER BY MSTLINE_EQM.SORTNO, MSTLINE_EQM.EQMCD;

  -- *****************************************************************************

  WHEN 'SEL_POP_TURRET' THEN -- 일괄 추가 팝업: 터렛 목록

    SELECT COMTYPE.TPCD AS TURRET,
           COMTYPE.TPNM AS TURRETNM
    FROM COMTYPE
    WHERE COMTYPE.GPCD = 'TURRET'
      AND COMTYPE.USEYN = 'Y'
    ORDER BY COMTYPE.SORTNO, COMTYPE.TPCD;

  -- *****************************************************************************

  WHEN 'ADD_ITEM' THEN -- 일괄 추가: 이미 등록된 사용위치는 건너뛰고 나머지만 등록

    IF TRIM(IFNULL($ITEMID_LIST, '')) = '' THEN
      CALL COMERR('추가할 사용위치가 없습니다.');
      LEAVE PROC;
    END IF;

    WHILE LENGTH($ITEMID_LIST) > 0 DO
      CALL COMSPLIT($ITEMID_LIST, _$ITEMID);
      CALL COMSPLIT($LINECD_LIST, _$LINECD);
      CALL COMSPLIT($PRCCD_LIST, _$PRCCD);
      CALL COMSPLIT($EQMCD_LIST, _$EQMCD);
      CALL COMSPLIT($ITEMID_PRD_LIST, _$ITEMID_PRD);
      CALL COMSPLIT($PRCDETAIL_LIST, _$PRCDETAIL);
      CALL COMSPLIT($TURRET_LIST, _$TURRET);

      SET _$ITEMID     = TRIM(IFNULL(_$ITEMID, ''));
      SET _$LINECD     = TRIM(IFNULL(_$LINECD, ''));
      SET _$PRCCD      = TRIM(IFNULL(_$PRCCD, ''));
      SET _$EQMCD      = TRIM(IFNULL(_$EQMCD, ''));
      SET _$ITEMID_PRD = IF(TRIM(IFNULL(_$ITEMID_PRD, '')) = '', '0', TRIM(_$ITEMID_PRD));
      SET _$PRCDETAIL  = TRIM(IFNULL(_$PRCDETAIL, ''));
      SET _$TURRET     = TRIM(IFNULL(_$TURRET, ''));

      IF _$ITEMID <> '' THEN
        IF NOT EXISTS (SELECT 1 FROM MSTITEM
                        WHERE MSTITEM.ITEMID = _$ITEMID
                          AND MSTITEM.ITEMCG = 'DM100990') THEN
          CALL COMERR(CONCAT('소모공구류 품목이 아닙니다. [', _$ITEMID, ']'));
          LEAVE PROC;
        END IF;

        IF _$ITEMID_PRD = '0' OR _$PRCDETAIL = '' OR _$TURRET = '' THEN
          CALL COMERR('제품, 세부공정, 터렛을 모두 선택하십시오.');
          LEAVE PROC;
        END IF;

        IF EXISTS (SELECT 1
                     FROM MSTITEM_OSCCONSUM_CLASSIFY
                     WHERE MSTITEM_OSCCONSUM_CLASSIFY.ITEMID = _$ITEMID
                       AND MSTITEM_OSCCONSUM_CLASSIFY.FACTORYCD = '07'
                       AND MSTITEM_OSCCONSUM_CLASSIFY.LINECD = _$LINECD
                       AND MSTITEM_OSCCONSUM_CLASSIFY.PRCCD = _$PRCCD
                       AND MSTITEM_OSCCONSUM_CLASSIFY.EQMCD = _$EQMCD
                       AND MSTITEM_OSCCONSUM_CLASSIFY.ITEMID_PRD = _$ITEMID_PRD
                       AND MSTITEM_OSCCONSUM_CLASSIFY.PRCDETAIL = _$PRCDETAIL
                       AND MSTITEM_OSCCONSUM_CLASSIFY.TURRET = _$TURRET) THEN
          SET _$SKIPCNT = _$SKIPCNT + 1;
        ELSE
          INSERT INTO MSTITEM_OSCCONSUM_CLASSIFY (
            FACTORYCD, ITEMID, LINECD, PRCCD, EQMCD,
            ITEMID_PRD, PRCDETAIL, TURRET,
            RTIME, REMP, RPRG
          ) VALUES (
            '07', CAST(_$ITEMID AS UNSIGNED), _$LINECD, _$PRCCD, _$EQMCD,
            CAST(_$ITEMID_PRD AS UNSIGNED), _$PRCDETAIL, _$TURRET,
            CALLTIME(), CALLEMP(), CALLPRG()
          );
          SET _$ADDCNT = _$ADDCNT + 1;
        END IF;
      END IF;
    END WHILE;

    SELECT _$ADDCNT AS ADDCNT, _$SKIPCNT AS SKIPCNT;

  -- *****************************************************************************

  WHEN 'SAVE_SAFEQTY' THEN -- 외주처 소모품 안전재고 저장 (없으면 등록)

    IF TRIM(IFNULL($ITEMID_LIST, '')) = '' THEN
      CALL COMERR('저장할 품목을 선택해주세요.');
      LEAVE PROC;
    END IF;

    WHILE LENGTH($ITEMID_LIST) > 0 DO
      CALL COMSPLIT($ITEMID_LIST, _$ITEMID);
      CALL COMSPLIT($SAFEQTY_LIST, _$SAFEQTY);

      SET _$ITEMID  = TRIM(IFNULL(_$ITEMID, ''));
      SET _$SAFEQTY = TRIM(IFNULL(_$SAFEQTY, ''));
      IF _$SAFEQTY = '' THEN
        SET _$SAFEQTY = '0';
      END IF;

      IF _$ITEMID <> '' THEN
        IF NOT EXISTS (SELECT 1 FROM MSTITEM
                        WHERE MSTITEM.ITEMID = _$ITEMID
                          AND MSTITEM.ITEMCG = 'DM100990') THEN
          CALL COMERR(CONCAT('소모공구류 품목이 아닙니다. [', _$ITEMID, ']'));
          LEAVE PROC;
        END IF;

        IF _$SAFEQTY NOT REGEXP '^[0-9]+(\\.[0-9]+)?$' THEN
          CALL COMERR(CONCAT('안전재고는 0 이상의 숫자로 입력하십시오. [', _$ITEMID, ']'));
          LEAVE PROC;
        END IF;

        IF EXISTS (SELECT 1
                     FROM MSTITEM_OSCCONSUM
                     WHERE MSTITEM_OSCCONSUM.FACTORYCD = '07'
                       AND MSTITEM_OSCCONSUM.ITEMID = CAST(_$ITEMID AS UNSIGNED)) THEN
          UPDATE MSTITEM_OSCCONSUM
            SET MSTITEM_OSCCONSUM.SAFEQTY = CAST(_$SAFEQTY AS DECIMAL(20, 8)),
                MSTITEM_OSCCONSUM.MTIME = CALLTIME(),
                MSTITEM_OSCCONSUM.MEMP = CALLEMP(),
                MSTITEM_OSCCONSUM.MPRG = CALLPRG()
            WHERE MSTITEM_OSCCONSUM.FACTORYCD = '07'
                AND MSTITEM_OSCCONSUM.ITEMID = CAST(_$ITEMID AS UNSIGNED);
        ELSE
          INSERT INTO MSTITEM_OSCCONSUM (
            FACTORYCD, ITEMID, SAFEQTY, LOTQTY,
            RTIME, REMP, RPRG
          ) VALUES (
            '07', CAST(_$ITEMID AS UNSIGNED), CAST(_$SAFEQTY AS DECIMAL(20, 8)), 0,
            CALLTIME(), CALLEMP(), CALLPRG()
          );
        END IF;
      END IF;
    END WHILE;

  -- *****************************************************************************

  WHEN 'SAVE_ITEM' THEN -- 사용위치 저장 (품목마다: 새 위치는 등록, 기존 위치는 수정, 원래 위치가 없는 품목은 제외. 같은 위치가 이미 있으면 에러)

    IF TRIM(IFNULL($ITEMID_LIST, '')) = '' THEN
      CALL COMERR('저장할 행을 선택해주세요.');
      LEAVE PROC;
    END IF;

    WHILE LENGTH($ITEMID_LIST) > 0 DO
      CALL COMSPLIT($ITEMID_LIST, _$ITEMID);
      CALL COMSPLIT($LINECD_LIST, _$LINECD);
      CALL COMSPLIT($PRCCD_LIST, _$PRCCD);
      CALL COMSPLIT($EQMCD_LIST, _$EQMCD);
      CALL COMSPLIT($ITEMID_PRD_LIST, _$ITEMID_PRD);
      CALL COMSPLIT($PRCDETAIL_LIST, _$PRCDETAIL);
      CALL COMSPLIT($TURRET_LIST, _$TURRET);
      CALL COMSPLIT($OLD_LINECD_LIST, _$OLD_LINECD);
      CALL COMSPLIT($OLD_PRCCD_LIST, _$OLD_PRCCD);
      CALL COMSPLIT($OLD_EQMCD_LIST, _$OLD_EQMCD);
      CALL COMSPLIT($OLD_ITEMID_PRD_LIST, _$OLD_ITEMID_PRD);
      CALL COMSPLIT($OLD_PRCDETAIL_LIST, _$OLD_PRCDETAIL);
      CALL COMSPLIT($OLD_TURRET_LIST, _$OLD_TURRET);

      SET _$ITEMID         = TRIM(IFNULL(_$ITEMID, ''));
      SET _$LINECD         = TRIM(IFNULL(_$LINECD, ''));
      SET _$PRCCD          = TRIM(IFNULL(_$PRCCD, ''));
      SET _$EQMCD          = TRIM(IFNULL(_$EQMCD, ''));
      SET _$ITEMID_PRD     = IF(TRIM(IFNULL(_$ITEMID_PRD, '')) = '', '0', TRIM(_$ITEMID_PRD));
      SET _$PRCDETAIL      = TRIM(IFNULL(_$PRCDETAIL, ''));
      SET _$TURRET         = TRIM(IFNULL(_$TURRET, ''));
      SET _$OLD_LINECD     = TRIM(IFNULL(_$OLD_LINECD, ''));
      SET _$OLD_PRCCD      = TRIM(IFNULL(_$OLD_PRCCD, ''));
      SET _$OLD_EQMCD      = TRIM(IFNULL(_$OLD_EQMCD, ''));
      SET _$OLD_ITEMID_PRD = IF(TRIM(IFNULL(_$OLD_ITEMID_PRD, '')) = '', '0', TRIM(_$OLD_ITEMID_PRD));
      SET _$OLD_PRCDETAIL  = TRIM(IFNULL(_$OLD_PRCDETAIL, ''));
      SET _$OLD_TURRET     = TRIM(IFNULL(_$OLD_TURRET, ''));

      IF _$ITEMID <> '' THEN
        IF NOT EXISTS (SELECT 1 FROM MSTITEM
                        WHERE MSTITEM.ITEMID = _$ITEMID
                          AND MSTITEM.ITEMCG = 'DM100990') THEN
          CALL COMERR(CONCAT('소모공구류 품목이 아닙니다. [', _$ITEMID, ']'));
          LEAVE PROC;
        END IF;

        IF _$LINECD = '' AND _$PRCCD = '' AND _$EQMCD = '' AND _$ITEMID_PRD = '0'
           AND _$PRCDETAIL = '' AND _$TURRET = '' THEN
          CALL COMERR(CONCAT('사용위치를 입력하십시오. [', _$ITEMID, ']'));
          LEAVE PROC;
        END IF;

        IF _$ITEMID_PRD = '0' OR _$PRCDETAIL = '' OR _$TURRET = '' THEN
          CALL COMERR('제품, 세부공정, 터렛을 모두 선택하십시오.');
          LEAVE PROC;
        END IF;

        -- 바꾼(또는 새) 위치가 이 품목에 이미 있으면 중복 에러 (화면에서 먼저 막고, 여기는 안전장치)
        IF (_$LINECD <> _$OLD_LINECD OR _$PRCCD <> _$OLD_PRCCD OR _$EQMCD <> _$OLD_EQMCD
            OR _$ITEMID_PRD <> _$OLD_ITEMID_PRD OR _$PRCDETAIL <> _$OLD_PRCDETAIL OR _$TURRET <> _$OLD_TURRET)
           AND EXISTS (SELECT 1
                         FROM MSTITEM_OSCCONSUM_CLASSIFY
                         WHERE MSTITEM_OSCCONSUM_CLASSIFY.ITEMID = CAST(_$ITEMID AS UNSIGNED)
                           AND MSTITEM_OSCCONSUM_CLASSIFY.FACTORYCD = '07'
                           AND MSTITEM_OSCCONSUM_CLASSIFY.LINECD = _$LINECD
                           AND MSTITEM_OSCCONSUM_CLASSIFY.PRCCD = _$PRCCD
                           AND MSTITEM_OSCCONSUM_CLASSIFY.EQMCD = _$EQMCD
                           AND MSTITEM_OSCCONSUM_CLASSIFY.ITEMID_PRD = CAST(_$ITEMID_PRD AS UNSIGNED)
                           AND MSTITEM_OSCCONSUM_CLASSIFY.PRCDETAIL = _$PRCDETAIL
                           AND MSTITEM_OSCCONSUM_CLASSIFY.TURRET = _$TURRET) THEN
          CALL COMERR(CONCAT('이미 등록된 사용위치입니다. 다시 설정하십시오. [',
                             (SELECT MSTITEM.ITEMCD FROM MSTITEM WHERE MSTITEM.ITEMID = _$ITEMID), ']'));
          LEAVE PROC;

        -- 새 위치 (조회 당시 값이 없음): 등록
        ELSEIF _$OLD_LINECD = '' AND _$OLD_PRCCD = '' AND _$OLD_EQMCD = '' AND _$OLD_ITEMID_PRD = '0'
               AND _$OLD_PRCDETAIL = '' AND _$OLD_TURRET = '' THEN
          INSERT INTO MSTITEM_OSCCONSUM_CLASSIFY (
            FACTORYCD, ITEMID, LINECD, PRCCD, EQMCD,
            ITEMID_PRD, PRCDETAIL, TURRET,
            RTIME, REMP, RPRG
          ) VALUES (
            '07', CAST(_$ITEMID AS UNSIGNED), _$LINECD, _$PRCCD, _$EQMCD,
            CAST(_$ITEMID_PRD AS UNSIGNED), _$PRCDETAIL, _$TURRET,
            CALLTIME(), CALLEMP(), CALLPRG()
          );
          SET _$ADDCNT = _$ADDCNT + 1;

        -- 기존 위치: 이 품목에 원래 위치가 있으면 수정, 없으면 제외 (여러 품목 중 일부에만 있는 위치)
        ELSEIF EXISTS (SELECT 1
                     FROM MSTITEM_OSCCONSUM_CLASSIFY
                     WHERE MSTITEM_OSCCONSUM_CLASSIFY.ITEMID = CAST(_$ITEMID AS UNSIGNED)
                       AND MSTITEM_OSCCONSUM_CLASSIFY.FACTORYCD = '07'
                       AND MSTITEM_OSCCONSUM_CLASSIFY.LINECD = _$OLD_LINECD
                       AND MSTITEM_OSCCONSUM_CLASSIFY.PRCCD = _$OLD_PRCCD
                       AND MSTITEM_OSCCONSUM_CLASSIFY.EQMCD = _$OLD_EQMCD
                       AND MSTITEM_OSCCONSUM_CLASSIFY.ITEMID_PRD = CAST(_$OLD_ITEMID_PRD AS UNSIGNED)
                       AND MSTITEM_OSCCONSUM_CLASSIFY.PRCDETAIL = _$OLD_PRCDETAIL
                       AND MSTITEM_OSCCONSUM_CLASSIFY.TURRET = _$OLD_TURRET) THEN
          UPDATE MSTITEM_OSCCONSUM_CLASSIFY
            SET MSTITEM_OSCCONSUM_CLASSIFY.LINECD = _$LINECD,
                MSTITEM_OSCCONSUM_CLASSIFY.PRCCD = _$PRCCD,
                MSTITEM_OSCCONSUM_CLASSIFY.EQMCD = _$EQMCD,
                MSTITEM_OSCCONSUM_CLASSIFY.ITEMID_PRD = CAST(_$ITEMID_PRD AS UNSIGNED),
                MSTITEM_OSCCONSUM_CLASSIFY.PRCDETAIL = _$PRCDETAIL,
                MSTITEM_OSCCONSUM_CLASSIFY.TURRET = _$TURRET,
                MSTITEM_OSCCONSUM_CLASSIFY.MTIME = CALLTIME(),
                MSTITEM_OSCCONSUM_CLASSIFY.MEMP = CALLEMP(),
                MSTITEM_OSCCONSUM_CLASSIFY.MPRG = CALLPRG()
            WHERE MSTITEM_OSCCONSUM_CLASSIFY.ITEMID = CAST(_$ITEMID AS UNSIGNED)
                AND MSTITEM_OSCCONSUM_CLASSIFY.FACTORYCD = '07'
                AND MSTITEM_OSCCONSUM_CLASSIFY.LINECD = _$OLD_LINECD
                AND MSTITEM_OSCCONSUM_CLASSIFY.PRCCD = _$OLD_PRCCD
                AND MSTITEM_OSCCONSUM_CLASSIFY.EQMCD = _$OLD_EQMCD
                AND MSTITEM_OSCCONSUM_CLASSIFY.ITEMID_PRD = CAST(_$OLD_ITEMID_PRD AS UNSIGNED)
                AND MSTITEM_OSCCONSUM_CLASSIFY.PRCDETAIL = _$OLD_PRCDETAIL
                AND MSTITEM_OSCCONSUM_CLASSIFY.TURRET = _$OLD_TURRET;
          SET _$ADDCNT = _$ADDCNT + 1;
        ELSE
          SET _$SKIPCNT = _$SKIPCNT + 1;
        END IF;
      END IF;
    END WHILE;

    SELECT _$ADDCNT AS SAVECNT, _$SKIPCNT AS SKIPCNT;

  -- *****************************************************************************

  WHEN 'DEL_ITEM' THEN -- 사용위치 삭제 (OLD_ 값 = 조회 당시 저장돼 있던 위치)

    IF TRIM(IFNULL($ITEMID_LIST, '')) = '' THEN
      CALL COMERR('삭제할 행을 선택해주세요.');
      LEAVE PROC;
    END IF;

    WHILE LENGTH($ITEMID_LIST) > 0 DO
      CALL COMSPLIT($ITEMID_LIST, _$ITEMID);
      CALL COMSPLIT($OLD_LINECD_LIST, _$OLD_LINECD);
      CALL COMSPLIT($OLD_PRCCD_LIST, _$OLD_PRCCD);
      CALL COMSPLIT($OLD_EQMCD_LIST, _$OLD_EQMCD);
      CALL COMSPLIT($OLD_ITEMID_PRD_LIST, _$OLD_ITEMID_PRD);
      CALL COMSPLIT($OLD_PRCDETAIL_LIST, _$OLD_PRCDETAIL);
      CALL COMSPLIT($OLD_TURRET_LIST, _$OLD_TURRET);

      SET _$ITEMID         = TRIM(IFNULL(_$ITEMID, ''));
      SET _$OLD_LINECD     = TRIM(IFNULL(_$OLD_LINECD, ''));
      SET _$OLD_PRCCD      = TRIM(IFNULL(_$OLD_PRCCD, ''));
      SET _$OLD_EQMCD      = TRIM(IFNULL(_$OLD_EQMCD, ''));
      SET _$OLD_ITEMID_PRD = IF(TRIM(IFNULL(_$OLD_ITEMID_PRD, '')) = '', '0', TRIM(_$OLD_ITEMID_PRD));
      SET _$OLD_PRCDETAIL  = TRIM(IFNULL(_$OLD_PRCDETAIL, ''));
      SET _$OLD_TURRET     = TRIM(IFNULL(_$OLD_TURRET, ''));

      IF _$ITEMID <> '' THEN
        DELETE FROM MSTITEM_OSCCONSUM_CLASSIFY
          WHERE MSTITEM_OSCCONSUM_CLASSIFY.ITEMID = CAST(_$ITEMID AS UNSIGNED)
              AND MSTITEM_OSCCONSUM_CLASSIFY.FACTORYCD = '07'
              AND MSTITEM_OSCCONSUM_CLASSIFY.LINECD = _$OLD_LINECD
              AND MSTITEM_OSCCONSUM_CLASSIFY.PRCCD = _$OLD_PRCCD
              AND MSTITEM_OSCCONSUM_CLASSIFY.EQMCD = _$OLD_EQMCD
              AND MSTITEM_OSCCONSUM_CLASSIFY.ITEMID_PRD = CAST(_$OLD_ITEMID_PRD AS UNSIGNED)
              AND MSTITEM_OSCCONSUM_CLASSIFY.PRCDETAIL = _$OLD_PRCDETAIL
              AND MSTITEM_OSCCONSUM_CLASSIFY.TURRET = _$OLD_TURRET;
      END IF;
    END WHILE;

  -- *****************************************************************************

  END CASE;
END
