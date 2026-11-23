CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.MST3001_R04(
-- *****************************************************************************
-- Comment: 생산팀 소모품 정보 (INC 2공장 소모자재 안전재고 관리)
-- Create:  2026-10-27 17:13 : 김영철
-- Modify:
-- *****************************************************************************
  IN $COMPANYCD       VARCHAR(100),
  IN $FACTORYCD       VARCHAR(100),
  IN $ITEMID          VARCHAR(100),
  IN $ENDYN           VARCHAR(1),
  IN $ITEMCG          VARCHAR(100),
  IN $ITEMID_LIST     MEDIUMTEXT,
  IN $SAFEQTY_LIST    MEDIUMTEXT,
-- *****************************************************************************
  IN $CALLTYPE        VARCHAR(100)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$ITEMID     VARCHAR(100);
  DECLARE _$SAFEQTY    VARCHAR(100);

-- *****************************************************************************
  CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'SEL_ITEM' THEN -- INC 2공장 소모자재 품목 및 안전재고·현재고 조회

    SET $ITEMID = TRIM(IFNULL($ITEMID, ''));
    SET $ENDYN = IF(IFNULL($ENDYN, '') = 'Y', 'Y', 'N');

    SELECT CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID,
           MSTITEM.ITEMCD,
           MSTITEM.COMPANYCD,
           MSTITEM_FACTORY.FACTORYCD,
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
           IFNULL(MSTITEM_PRDCONSUM.SAFEQTY, 0) AS SAFEQTY,
           IFNULL(MSTITEM_PRDCONSUM.LOTQTY, 0) AS LOTQTY,
           CASE WHEN IFNULL(MSTITEM_PRDCONSUM.LOTQTY, 0) < IFNULL(MSTITEM_PRDCONSUM.SAFEQTY, 0)
                THEN 'PINK'
                ELSE ''
           END AS BACKGROUND
    FROM MSTITEM
    INNER JOIN MSTITEM_FACTORY ON MSTITEM.ITEMID = MSTITEM_FACTORY.ITEMID
    LEFT JOIN MSTITEM_PRDCONSUM ON MSTITEM_PRDCONSUM.ITEMID = MSTITEM.ITEMID
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

  WHEN 'SAVE_ITEM' THEN -- 소모품 안전재고 저장 (없으면 등록)

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
                          AND MSTITEM.ITEMCG = 'DM100750') THEN
          CALL COMERR(CONCAT('소모자재 품목이 아닙니다. [', _$ITEMID, ']'));
          LEAVE PROC;
        END IF;

        IF _$SAFEQTY NOT REGEXP '^[0-9]+(\\.[0-9]+)?$' THEN
          CALL COMERR(CONCAT('안전재고는 0 이상의 숫자로 입력하십시오. [', _$ITEMID, ']'));
          LEAVE PROC;
        END IF;

        IF EXISTS (SELECT 1
                     FROM MSTITEM_PRDCONSUM
                     WHERE MSTITEM_PRDCONSUM.FACTORYCD = '07'
                       AND MSTITEM_PRDCONSUM.ITEMID = CAST(_$ITEMID AS UNSIGNED)) THEN
          UPDATE MSTITEM_PRDCONSUM
            SET MSTITEM_PRDCONSUM.SAFEQTY = CAST(_$SAFEQTY AS DECIMAL(20, 8)),
                MSTITEM_PRDCONSUM.MTIME = CALLTIME(),
                MSTITEM_PRDCONSUM.MEMP = CALLEMP(),
                MSTITEM_PRDCONSUM.MPRG = CALLPRG()
            WHERE MSTITEM_PRDCONSUM.FACTORYCD = '07'
                AND MSTITEM_PRDCONSUM.ITEMID = CAST(_$ITEMID AS UNSIGNED);
        ELSE
          INSERT INTO MSTITEM_PRDCONSUM (
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

  END CASE;
END
