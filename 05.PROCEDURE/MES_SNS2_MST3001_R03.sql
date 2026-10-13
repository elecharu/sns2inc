CREATE DEFINER=`root`@`%` 
PROCEDURE `MES_SNS2`.`MST3001_R03`(
-- *****************************************************************************
-- Comment: 설비부품정보
-- Create: 	2025-06-20  	생성 			이대규
-- Modify: 	2026-10-12 					한성수	설비부품 대상 MSTITEM 및 현재고(MSTITEM_EQMPARTS)/안전재고(MSTITEM_FACTORY) 연동
-- *****************************************************************************
  IN $PARTCD         VARCHAR(20),   
  IN $PARTNM         VARCHAR(100),
  IN $SPEC           VARCHAR(100),
  IN $STOCKQTY       DECIMAL(20, 8),
  IN $REMARK         VARCHAR(100),
  IN $SAFEQTY        DECIMAL(20, 8),
  IN $UNIT           VARCHAR(20),
  IN $IMGFILEKEY     VARCHAR(100),
  IN $TYPE           VARCHAR(100),
  IN $FILEKEY        VARCHAR(100),

  IN $PARTCD_LIST    MEDIUMTEXT,
  IN $PARTNM_LIST    MEDIUMTEXT,
  IN $SPEC_LIST      MEDIUMTEXT,
  IN $REMARK_LIST    MEDIUMTEXT,
  IN $SAFEQTY_LIST   MEDIUMTEXT,
  IN $UNIT_LIST      MEDIUMTEXT,
  IN $TYPE_LIST      MEDIUMTEXT,
-- *****************************************************************************
  IN $CALLTYPE       VARCHAR(50), 
  IN $KEYWORD        VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y'; 
-- *****************************************************************************
  DECLARE _$ITEMID   INT;
  DECLARE _$PARTCD   VARCHAR(100);  
  DECLARE _$PARTNM   VARCHAR(100);    
  DECLARE _$SPEC     VARCHAR(100);    
  DECLARE _$REMARK   VARCHAR(100);
  DECLARE _$SAFEQTY  VARCHAR(100);
  DECLARE _$UNIT     VARCHAR(20);
  DECLARE _$TYPE     VARCHAR(100);

-- *****************************************************************************
  CASE $CALLTYPE
-- *****************************************************************************
  WHEN 'LIST_EQMPART' THEN -- 설비 부품 조회
    SET $PARTCD  = TRIM(IFNULL($PARTCD, ''));
    SET $PARTNM  = TRIM(IFNULL($PARTNM, ''));
    SET $KEYWORD = TRIM(IFNULL($KEYWORD, ''));

    SELECT ITEM.ITEMCD AS PARTCD,
           ITEM.ITEMNM AS PARTNM,
           COALESCE(ITEM.ITEMSPEC, '') AS SPEC,
           COALESCE(ITEM.MODELCD, '') AS TYPE,
           COALESCE(ITEM.ITEMUNIT, '') AS UNIT,
           COALESCE(STOCK.LOTQTY, 0) AS STOCKQTY,
           COALESCE(SAFE.SAFEQTY, 0) AS SAFEQTY,
           COALESCE(ITEM.REMARK, '') AS REMARK,
           '' AS FILEKEY,
           '' AS FILENAME,
           '' AS FILEURL
    FROM (
      SELECT ITEMCD,
             MAX(ITEMID) AS ITEMID,
             MAX(ITEMNM) AS ITEMNM,
             MAX(ITEMSPEC) AS ITEMSPEC,
             MAX(MODELCD) AS MODELCD,
             MAX(ITEMUNIT) AS ITEMUNIT,
             MAX(REMARK) AS REMARK
      FROM MSTITEM
      WHERE ITEMCG = 'DM100700'
        AND ENDYN = 'N'
        AND ($PARTCD = '' OR ITEMCD LIKE CONCAT('%', $PARTCD, '%'))
        AND ($PARTNM = '' OR ITEMNM LIKE CONCAT('%', $PARTNM, '%'))
        AND ($KEYWORD = '' OR ITEMCD LIKE CONCAT('%', $KEYWORD, '%') OR ITEMNM LIKE CONCAT('%', $KEYWORD, '%'))
      GROUP BY ITEMCD
    ) ITEM
    LEFT JOIN MSTITEM_EQMPARTS STOCK ON STOCK.ITEMID = ITEM.ITEMID AND STOCK.FACTORYCD = '07'
    LEFT JOIN MSTITEM_FACTORY SAFE ON SAFE.ITEMID = ITEM.ITEMID AND SAFE.FACTORYCD = '07'
    ORDER BY ITEM.ITEMCD;

-- *****************************************************************************
  WHEN 'ADD_EQMPART' THEN -- 설비 부품 추가
    SET $PARTCD   = TRIM(IFNULL($PARTCD, ''));
    SET $PARTNM   = TRIM(IFNULL($PARTNM, ''));
    SET $TYPE     = TRIM(IFNULL($TYPE, ''));
    SET $SPEC     = TRIM(IFNULL($SPEC, ''));
    SET $UNIT     = TRIM(IFNULL($UNIT, ''));
    SET $STOCKQTY = IFNULL($STOCKQTY, 0);
    SET $SAFEQTY  = IFNULL($SAFEQTY, 0);
    SET $REMARK   = TRIM(IFNULL($REMARK, ''));

    IF $PARTCD = '' THEN
      CALL COMERR('부품코드를 입력해주세요.');
      LEAVE PROC;
    END IF;

    IF $PARTNM = '' THEN
      CALL COMERR('부품명을 입력해주세요.');
      LEAVE PROC;
    END IF;

    IF EXISTS (SELECT 1 FROM MSTITEM WHERE ITEMCD = $PARTCD AND ITEMCG = 'DM100700' AND ENDYN = 'N' LIMIT 1) THEN
      CALL COMERR(CONCAT('이미 등록되어 있는 부품입니다. (', $PARTCD, ')'));
      LEAVE PROC;
    END IF;

    INSERT INTO MSTITEM (
      ITEMCD, ITEMNM, ITEMSPEC, ITEMUNIT,
      ITEMCG, MODELCD, REMARK, ENDYN,
      RTIME, REMP, RPRG
    ) VALUES (
      $PARTCD, $PARTNM, $SPEC, CASE WHEN $UNIT = '' THEN 'DM150100' ELSE $UNIT END,
      'DM100700', $TYPE, $REMARK, 'N',
      CALLTIME(), CALLEMP(), CALLPRG()
    );

    SET _$ITEMID = LAST_INSERT_ID();

    IF $STOCKQTY > 0 THEN
      INSERT INTO MSTITEM_EQMPARTS (
        ITEMID, FACTORYCD, LOTQTY,
        RTIME, REMP, RPRG
      ) VALUES (
        _$ITEMID, '07', $STOCKQTY,
        CALLTIME(), CALLEMP(), CALLPRG()
      ) ON DUPLICATE KEY UPDATE
        LOTQTY = $STOCKQTY,
        MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG();
    END IF;

    IF $SAFEQTY > 0 THEN
      INSERT INTO MSTITEM_FACTORY (
        FACTORYCD, ITEMID, SAFEQTY, SAFEYN,
        RTIME, REMP, RPRG
      ) VALUES (
        '07', _$ITEMID, $SAFEQTY, '1',
        CALLTIME(), CALLEMP(), CALLPRG()
      ) ON DUPLICATE KEY UPDATE
        SAFEQTY = $SAFEQTY, SAFEYN = '1',
        MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG();
    END IF;

-- *****************************************************************************
  WHEN 'UPDATE_EQMPART' THEN -- 설비 부품 수정
    WHILE LENGTH($PARTCD_LIST) > 0 DO
      CALL COMSPLIT($PARTCD_LIST, _$PARTCD);
      CALL COMSPLIT($PARTNM_LIST, _$PARTNM);
      CALL COMSPLIT($SPEC_LIST, _$SPEC);
      CALL COMSPLIT($REMARK_LIST, _$REMARK);
      CALL COMSPLIT($SAFEQTY_LIST, _$SAFEQTY);
      CALL COMSPLIT($UNIT_LIST, _$UNIT);
      CALL COMSPLIT($TYPE_LIST, _$TYPE);

      SET _$ITEMID = (SELECT ITEMID FROM MSTITEM WHERE ITEMCD = _$PARTCD AND ITEMCG = 'DM100700' LIMIT 1);

      IF _$ITEMID IS NOT NULL THEN
        UPDATE MSTITEM SET
          ITEMNM   = _$PARTNM,
          ITEMSPEC = _$SPEC,
          ITEMUNIT = CASE WHEN _$UNIT = '' THEN ITEMUNIT ELSE _$UNIT END,
          MODELCD  = _$TYPE,
          REMARK   = _$REMARK,
          MTIME    = CALLTIME(),
          MEMP     = CALLEMP(),
          MPRG     = CALLPRG()
        WHERE ITEMID = _$ITEMID;

        IF _$SAFEQTY <> '' THEN
          INSERT INTO MSTITEM_FACTORY (
            FACTORYCD, ITEMID, SAFEQTY, SAFEYN,
            RTIME, REMP, RPRG
          ) VALUES (
            '07', _$ITEMID, CAST(_$SAFEQTY AS DECIMAL(18, 5)), '1',
            CALLTIME(), CALLEMP(), CALLPRG()
          ) ON DUPLICATE KEY UPDATE
            SAFEQTY = CAST(_$SAFEQTY AS DECIMAL(18, 5)), SAFEYN = '1',
            MTIME = CALLTIME(), MEMP = CALLEMP(), MPRG = CALLPRG();
        END IF;
      END IF;
    END WHILE;

-- *****************************************************************************
  WHEN 'DELETE_EQMPART' THEN -- 설비 부품 삭제
    WHILE LENGTH($PARTCD_LIST) > 0 DO
      CALL COMSPLIT($PARTCD_LIST, _$PARTCD);

      SET _$ITEMID = (SELECT ITEMID FROM MSTITEM WHERE ITEMCD = _$PARTCD AND ITEMCG = 'DM100700' LIMIT 1);

      IF _$ITEMID IS NOT NULL THEN
        IF EXISTS (SELECT 1 FROM MSTEQMSUB WHERE EQMSUB = _$PARTCD OR EQMSUB = (SELECT ITEMNM FROM MSTITEM WHERE ITEMID = _$ITEMID LIMIT 1) LIMIT 1) THEN
          CALL COMERR(CONCAT('설비에 등록된 부품은 삭제할 수 없습니다. (', _$PARTCD, ')'));
          LEAVE PROC;
        END IF;

        DELETE FROM MSTITEM_EQMPARTS
        WHERE ITEMID = _$ITEMID AND FACTORYCD = '07';

        UPDATE MSTITEM_FACTORY SET
          SAFEQTY = 0,
          MTIME = CALLTIME(),
          MEMP  = CALLEMP(),
          MPRG  = CALLPRG()
        WHERE ITEMID = _$ITEMID AND FACTORYCD = '07';

        UPDATE MSTITEM SET
          ENDYN = 'Y',
          MTIME = CALLTIME(),
          MEMP  = CALLEMP(),
          MPRG  = CALLPRG()
        WHERE ITEMID = _$ITEMID;
      END IF;
    END WHILE;

-- *****************************************************************************
  WHEN 'GET_FILEURL' THEN -- 부품 첨부파일 조회
    SELECT '' AS FILEKEY,
           '' AS FILENAME,
           '' AS FILEURL;

-- *****************************************************************************
  WHEN 'UPLOAD_FILE' THEN -- 사진 추가
    SET $PARTCD  = TRIM(IFNULL($PARTCD, ''));
    SET $FILEKEY = TRIM(IFNULL($FILEKEY, ''));

    IF $PARTCD = '' THEN
      CALL COMERR('부품코드를 선택하세요.');
      LEAVE PROC;
    END IF;

-- *****************************************************************************
  WHEN 'DEL_FILE' THEN -- 사진 삭제
    SET $PARTCD = TRIM(IFNULL($PARTCD, ''));

    IF $PARTCD = '' THEN
      CALL COMERR('부품코드를 선택하세요.');
      LEAVE PROC;
    END IF;

-- *****************************************************************************
  END CASE;
END