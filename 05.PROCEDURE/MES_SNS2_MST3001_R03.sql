CREATE DEFINER=`root`@`%` 
PROCEDURE `MES_SNS2`.`MST3001_R03`(
-- *****************************************************************************
-- Comment: 설비부품정보 마스터관리
-- Create:  2024-02-22  13:50   김영철
-- Modify:  2026-10-13          한성수  부품재고·로케이션 최적화 조회/저장, 안전재고 부족 시 핑크색(BACKGROUND) 표기, 로케이션 코드 수정 및 중복 검증·SQL 튜닝
--          2026-10-14          한성수  로케이션 연동·초기화 및 비움 삭제 처리, 중요도등급(GRADE) 저장 및 공통 감사함수 적용
-- *****************************************************************************
  IN $COMPANYCD       VARCHAR(100),
  IN $FACTORYCD       VARCHAR(100),
  IN $ITEMID          VARCHAR(100),
  IN $ITEMCG          VARCHAR(100),
  IN $ITEMID_LIST     MEDIUMTEXT,
  IN $GRADE_LIST      MEDIUMTEXT,
  IN $SAFEQTY_LIST    MEDIUMTEXT,
  IN $LOCACD_LIST     VARCHAR(2000),
  IN $LOCANM_LIST     VARCHAR(4000),
  IN $OLD_LOCACD_LIST VARCHAR(2000),
  IN $CALLTYPE        VARCHAR(100),
  IN $ENDYN           VARCHAR(1),
  IN $KEYWORD         VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$ITEMID     VARCHAR(100);
  DECLARE _$GRADE      VARCHAR(100);
  DECLARE _$SAFEQTY    VARCHAR(100);
  DECLARE _$LOCACD     VARCHAR(100);
  DECLARE _$LOCANM     VARCHAR(100);
  DECLARE _$OLD_LOCACD VARCHAR(100);

-- *****************************************************************************
  CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'SEL_ITEM' THEN -- 설비부품 품목 마스터 및 재고·로케이션 조회 (화면 표시용 필수 컬럼 최적화)
    
    IF TRIM(COALESCE($COMPANYCD, '')) = '' THEN 
      CALL COMERR('법인을 선택하십시오.');
      LEAVE PROC;
    END IF; 

    IF COALESCE($FACTORYCD, '') = '' THEN
      SET $FACTORYCD = '07';
    END IF;

    SET $ITEMCG = 'DM100700';
    SET $ITEMID = TRIM(COALESCE($ITEMID, ''));

    SELECT CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID,
           MSTITEM.ITEMCD,
           MSTITEM.COMPANYCD,
           MSTITEM.ITEMCG,
           MSTITEM.ITEMNM,
           MSTITEM.ITEMSPEC,
           MSTITEM.ITEM_LVL1,
           MSTITEM.ITEM_LVL2,
           MSTITEM.ITEM_LVL3,
           MSTITEM.ITEM_LVL4,
           MSTITEM.ITEMUNIT,
           MSTITEM.ITEMSRC,
           MSTITEM.ENDYN,
           MSTITEM.IOYN,
           MSTITEM.SEPAYN,
           COALESCE(MSTITEM_EQMPARTS.GRADE, MSTITEM.GRADE, '') AS GRADE,
           COALESCE(MSTITEM_EQMPARTS.SAFEQTY, 0) AS SAFEQTY,
           COALESCE(MSTITEM_EQMPARTS.LOTQTY, 0) AS LOTQTY,
           COALESCE(MSTITEM_EQMPARTS.LOCACD, '') AS LOCACD,
           COALESCE(MSTLOCA_EQMPARTS.LOCANM, '') AS LOCANM,
           CASE WHEN COALESCE(MSTITEM_EQMPARTS.LOTQTY, 0) < COALESCE(MSTITEM_EQMPARTS.SAFEQTY, 0)
                THEN 'PINK'
                ELSE ''
           END AS BACKGROUND
    FROM MSTITEM
    LEFT JOIN MSTITEM_EQMPARTS
      ON MSTITEM_EQMPARTS.ITEMID = MSTITEM.ITEMID
     AND MSTITEM_EQMPARTS.FACTORYCD = $FACTORYCD
    LEFT JOIN MSTLOCA_EQMPARTS
      ON MSTLOCA_EQMPARTS.LOCACD = MSTITEM_EQMPARTS.LOCACD
    WHERE MSTITEM.COMPANYCD = $COMPANYCD
      AND MSTITEM.ITEMCG = 'DM100700'
      AND MSTITEM.ENDYN = $ENDYN
      AND (   $ITEMID = ''
           OR MSTITEM.ITEMID LIKE CONCAT('%', $ITEMID, '%')
           OR MSTITEM.ITEMCD LIKE CONCAT('%', $ITEMID, '%')
           OR MSTITEM.ITEMNM LIKE CONCAT('%', $ITEMID, '%')
          )
    ORDER BY MSTITEM.COMPANYCD, MSTITEM.ITEMCD;

  -- *****************************************************************************

  WHEN 'SAVE_ITEM' THEN -- 설비부품 등급·안전재고·로케이션코드 저장
    
    IF TRIM(COALESCE($ITEMID_LIST, '')) = '' THEN
      CALL COMERR('저장할 품목을 선택해주세요.');
      LEAVE PROC;
    END IF;

    IF COALESCE($FACTORYCD, '') = '' THEN
      SET $FACTORYCD = '07';
    END IF;

    WHILE LENGTH($ITEMID_LIST) > 0 DO
      CALL COMSPLIT($ITEMID_LIST, _$ITEMID);
      CALL COMSPLIT($GRADE_LIST, _$GRADE);
      CALL COMSPLIT($SAFEQTY_LIST, _$SAFEQTY);
      CALL COMSPLIT($LOCACD_LIST, _$LOCACD);

      SET _$ITEMID  = TRIM(COALESCE(_$ITEMID, ''));
      SET _$GRADE   = TRIM(COALESCE(_$GRADE, ''));
      SET _$SAFEQTY = TRIM(COALESCE(_$SAFEQTY, '0'));
      SET _$LOCACD  = TRIM(COALESCE(_$LOCACD, ''));

      IF _$ITEMID <> '' THEN
        IF EXISTS (SELECT 1 FROM MSTITEM_EQMPARTS WHERE FACTORYCD = $FACTORYCD AND ITEMID = CAST(_$ITEMID AS UNSIGNED) LIMIT 1) THEN
          UPDATE MSTITEM_EQMPARTS
          SET GRADE   = _$GRADE,
              SAFEQTY = CAST(_$SAFEQTY AS DECIMAL(20, 8)),
              LOCACD  = _$LOCACD,
              MTIME   = CALLTIME(),
              MEMP    = CALLEMP(),
              MPRG    = CALLPRG()
          WHERE FACTORYCD = $FACTORYCD
            AND ITEMID = CAST(_$ITEMID AS UNSIGNED);
        ELSE
          INSERT INTO MSTITEM_EQMPARTS (
            FACTORYCD, ITEMID, GRADE, SAFEQTY, LOCACD,
            RTIME, REMP, RPRG, MTIME, MEMP, MPRG
          ) VALUES (
            $FACTORYCD, CAST(_$ITEMID AS UNSIGNED), _$GRADE,
            CAST(_$SAFEQTY AS DECIMAL(20, 8)), _$LOCACD,
            CALLTIME(), CALLEMP(), CALLPRG(), '', '', ''
          );
        END IF;
      END IF;
    END WHILE;

  -- *****************************************************************************

  WHEN 'SEL_LOCA' THEN -- 설비부품 로케이션 기준정보 조회
    
    SET $KEYWORD = TRIM(COALESCE($KEYWORD, ''));

    SELECT MSTLOCA_EQMPARTS.LOCACD,
           COALESCE(MSTLOCA_EQMPARTS.LOCANM, '') AS LOCANM
    FROM MSTLOCA_EQMPARTS
    WHERE (   $KEYWORD = ''
           OR MSTLOCA_EQMPARTS.LOCACD LIKE CONCAT('%', $KEYWORD, '%')
           OR MSTLOCA_EQMPARTS.LOCANM LIKE CONCAT('%', $KEYWORD, '%')
          )
    ORDER BY MSTLOCA_EQMPARTS.LOCACD;

  -- *****************************************************************************

  WHEN 'SAVE_LOCA' THEN -- 설비부품 로케이션 기준정보 저장 (중복 검증 및 신규 INSERT / 수정 UPDATE)
    
    IF TRIM(COALESCE($LOCANM_LIST, '')) = '' THEN
      CALL COMERR('저장할 로케이션 데이터를 입력해주세요.');
      LEAVE PROC;
    END IF;

    WHILE LENGTH($LOCANM_LIST) > 0 DO
      CALL COMSPLIT($LOCACD_LIST, _$LOCACD);
      CALL COMSPLIT($LOCANM_LIST, _$LOCANM);
      CALL COMSPLIT($OLD_LOCACD_LIST, _$OLD_LOCACD);

      SET _$LOCACD     = TRIM(COALESCE(_$LOCACD, ''));
      SET _$LOCANM     = TRIM(COALESCE(_$LOCANM, ''));
      SET _$OLD_LOCACD = TRIM(COALESCE(_$OLD_LOCACD, ''));

      IF _$LOCACD = '' THEN
        CALL COMERR('로케이션 코드를 입력해주세요.');
        LEAVE PROC;
      END IF;

      IF _$LOCANM = '' THEN
        CALL COMERR('로케이션 명을 입력해주세요.');
        LEAVE PROC;
      END IF;

      -- 로케이션 코드 중복 검사 (신규 등록 시 기존 코드 중복 또는 수정 시 타 행 코드와의 중복 방지)
      IF EXISTS (
        SELECT 1
        FROM MSTLOCA_EQMPARTS
        WHERE LOCACD = _$LOCACD
          AND LOCACD <> _$OLD_LOCACD
        LIMIT 1
      ) THEN
        CALL COMERR(CONCAT('이미 등록된 로케이션 코드입니다. [', _$LOCACD, ']'));
        LEAVE PROC;
      END IF;

      -- 1) 수정: 기존 로케이션 코드가 있는 경우 UPDATE
      IF _$OLD_LOCACD <> '' THEN
        UPDATE MSTLOCA_EQMPARTS
        SET LOCACD = _$LOCACD,
            LOCANM = _$LOCANM,
            MTIME  = CALLTIME(),
            MEMP   = CALLEMP(),
            MPRG   = CALLPRG()
        WHERE LOCACD = _$OLD_LOCACD;

        -- 코드가 변경된 경우 부품 재고 테이블의 로케이션 코드도 연쇄 갱신
        IF _$OLD_LOCACD <> _$LOCACD THEN
          UPDATE MSTITEM_EQMPARTS
          SET LOCACD = _$LOCACD,
              MTIME  = CALLTIME(),
              MEMP   = CALLEMP(),
              MPRG   = CALLPRG()
          WHERE LOCACD = _$OLD_LOCACD;
        END IF;

      -- 2) 신규: 기존 로케이션 코드가 없는 경우 INSERT
      ELSE
        INSERT INTO MSTLOCA_EQMPARTS (
          LOCACD,
          LOCANM,
          RTIME,
          REMP,
          RPRG,
          MTIME,
          MEMP,
          MPRG
        ) VALUES (
          _$LOCACD,
          _$LOCANM,
          CALLTIME(),
          CALLEMP(),
          CALLPRG(),
          '',
          '',
          ''
        );
      END IF;
    END WHILE;

  -- *****************************************************************************

  WHEN 'DEL_LOCA' THEN -- 설비부품 로케이션 기준정보 삭제
    
    IF TRIM(COALESCE($LOCACD_LIST, '')) = '' THEN
      CALL COMERR('삭제할 로케이션을 선택해주세요.');
      LEAVE PROC;
    END IF;

    WHILE LENGTH($LOCACD_LIST) > 0 DO
      CALL COMSPLIT($LOCACD_LIST, _$LOCACD);
      SET _$LOCACD = TRIM(COALESCE(_$LOCACD, ''));

      IF _$LOCACD <> '' THEN
        -- 설비부품 현재고 테이블에 지정되어 사용 중인지 확인
        IF EXISTS (SELECT 1 FROM MSTITEM_EQMPARTS WHERE LOCACD = _$LOCACD LIMIT 1) THEN
          CALL COMERR(CONCAT('로케이션 [', _$LOCACD, ']은 현재 설비부품 재고에 지정되어 있어 삭제할 수 없습니다.'));
          LEAVE PROC;
        END IF;

        DELETE FROM MSTLOCA_EQMPARTS
        WHERE LOCACD = _$LOCACD;
      END IF;
    END WHILE;

  -- *****************************************************************************

  END CASE;
END