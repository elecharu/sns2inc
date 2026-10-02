CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD1001_R02(
  -- *****************************************************************************
-- Comment: 주간생산계획 등록
-- Create: 2026-10-01 신정수 
-- Modify: 
-- *****************************************************************************
  IN $SDATE VARCHAR(10),      
  IN $EDATE VARCHAR(10),      
  IN $FACTORYCD VARCHAR(100),   -- 공장코드
  IN $ITEMID INT,              -- 품목번호
  IN $ITEMCD VARCHAR(100),      -- 품목코드   

-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y'; 
-- *****************************************************************************
  DECLARE _$PRODUCT_LIST MEDIUMTEXT;
  DECLARE _$ITEMID_PRODUCT INT;
  DECLARE _$COUNT INT;
-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_WEEKPLAN' THEN  -- 주간 생산계획 조회 

  IF LEFT($SDATE, 7) != LEFT($EDATE, 7) THEN
    CALL COMERR('시작일과 종료일의 월이 다르게 조회할 수는 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT ITEMID FROM PRDPLAN_M WHERE PMONTH = LEFT($SDATE, 7) AND APPYN = 'Y') THEN
    CALL COMERR(CONCAT('확정된 월생산계획이 없습니다.'
                      , '\n- 계획월: ', LEFT($SDATE, 7)
                      )
               );
    LEAVE PROC;
  END IF;

  -- 주간 생산계획 만들 반제품 찾기 (열전, 열후, 롤링, 조립, 절단 공정만)
  DROP TABLE IF EXISTS TEMP_END;
  CREATE TEMPORARY TABLE TEMP_END (
    LEVEL  DECIMAL(20, 0) NOT NULL,
    ENDYN  VARCHAR(1) NOT NULL,
    IDX    VARCHAR(1000) NOT NULL,
    PIDX   VARCHAR(1000) NOT NULL,
    MITEMID VARCHAR(100) NOT NULL,
    ITEMID VARCHAR(100) NOT NULL,
    MUSAGE DECIMAL(20, 8),
    CUSAGE DECIMAL(20, 8),
    PRCCD VARCHAR(100) NOT NULL,
    BOMSEQ INT 
  );

  DROP TABLE IF EXISTS TEMP_CUR;
  CREATE TEMPORARY TABLE TEMP_CUR (
    IDX    VARCHAR(1000) NOT NULL,
    PIDX   VARCHAR(1000) NOT NULL,
    MITEMID VARCHAR(100) NOT NULL,
    ITEMID VARCHAR(100) NOT NULL,
    MUSAGE DECIMAL(20, 8),
    CUSAGE DECIMAL(20, 8),
    PRCCD VARCHAR(100) NOT NULL,
    BOMSEQ INT 
  );

  SET _$PRODUCT_LIST = IFNULL((
                                SELECT
                                  GROUP_CONCAT(PLAN_M.ITEMID ORDER BY ITEMID ASC SEPARATOR '»')
                                FROM PRDPLAN_M AS PLAN_M
                                WHERE PLAN_M.PMONTH = LEFT($SDATE, 7)
                              ), '');

  WHILE LENGTH(_$PRODUCT_LIST) > 0 DO
    CALL COMSPLIT(_$PRODUCT_LIST, _$ITEMID_PRODUCT);

    INSERT INTO TEMP_END (LEVEL, ENDYN, IDX, PIDX, MITEMID, ITEMID, BOMSEQ,  PRCCD)
    SELECT 0, 'N', ITEMID, '', '', ITEMID, 0, ''
    FROM MSTITEM
    WHERE MSTITEM.ITEMID = _$ITEMID_PRODUCT;
  
    SET _$COUNT = 1;
  
    WHILE _$COUNT < 20 DO
  
      TRUNCATE TABLE TEMP_CUR;
      INSERT INTO TEMP_CUR (IDX,  PIDX, 
        MITEMID, ITEMID, 
        MUSAGE, CUSAGE, BOMSEQ,
        PRCCD
      )
      SELECT 
        CONCAT(TEMP_END.IDX, '      ' , MSTBOM.CITEMID),   TEMP_END.IDX,     
        MSTBOM.MITEMID,  MSTBOM.CITEMID,    
        MSTBOM.MUSAGE, MSTBOM.CUSAGE, MSTBOM.PRCSEQ,
        MSTBOM.PRCCD
      FROM TEMP_END
      INNER JOIN MSTBOM 
      ON TEMP_END.ITEMID = MSTBOM.MITEMID
      WHERE TEMP_END.ENDYN = 'N';
  
      UPDATE TEMP_END SET ENDYN = 'Y';
  
      INSERT INTO TEMP_END (LEVEL, ENDYN, IDX, PIDX, MITEMID, ITEMID, MUSAGE, CUSAGE, BOMSEQ, PRCCD)
      SELECT _$COUNT, 'N', IDX, PIDX, MITEMID, ITEMID, MUSAGE, CUSAGE, BOMSEQ, PRCCD
      FROM TEMP_CUR;
  
      SET _$COUNT = _$COUNT + 1;   
    END WHILE;
  END WHILE;

-- ****************************************************************************
END CASE; END