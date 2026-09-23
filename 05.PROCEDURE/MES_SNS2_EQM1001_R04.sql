CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`EQM1001_R04`(
-- *****************************************************************************
-- Comment: 설비 정기점검 등록 
-- Create: 	2025-06-27  	생성 			이대규
-- Modify: 	2026-09-15 		마이그레이션	한성수
-- 			2026-09-16 					한성수	MSTEQM.FANO(설비코드) 컬럼 바인딩 변경
-- 			2026-09-22 					한성수	승인된 설비그룹·설비별 정기점검 계획만 실행
-- *****************************************************************************
  IN $SYEAR         VARCHAR(50),
  IN $YYYYMM         VARCHAR(50),

  IN $EQMCD         VARCHAR(20),
  IN $CHKRSTKEY     VARCHAR(20),
  IN $CHKKNDCD_LIST MEDIUMTEXT,
  IN $CHKKNDNM_LIST MEDIUMTEXT,
  IN $CHKLOC_LIST   MEDIUMTEXT,
  IN $CHKMTH_LIST   MEDIUMTEXT,
  IN $CHKVALTP_LIST MEDIUMTEXT,
  IN $CHKCYCLE_LIST MEDIUMTEXT,
  IN $CHKVALUE_LIST MEDIUMTEXT,
    
  IN $BASEDATE      VARCHAR(50),
  IN $EMPCD         VARCHAR(20),
  IN $PROBLEM       VARCHAR(1000),
  IN $SOLUTION      VARCHAR(1000),

  
  IN $CHKRSTKEY_LIST  MEDIUMTEXT,
  IN $EMPCD_LIST      MEDIUMTEXT,
  IN $PROBLEM_LIST    MEDIUMTEXT,
  IN $SOLUTION_LIST   MEDIUMTEXT,


-- *****************************************************************************
IN  $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y'; 
-- *****************************************************************************
  DECLARE _$CHKKNDCD  VARCHAR(100);
  DECLARE _$CHKKNDNM  VARCHAR(100);
  DECLARE _$CHKLOC    VARCHAR(100);
  DECLARE _$CHKMTH    VARCHAR(100);
  DECLARE _$CHKVALTP  VARCHAR(100);
  DECLARE _$CHKCYCLE  VARCHAR(100);
  DECLARE _$CHKVALUE  VARCHAR(100);
  DECLARE _$CHKRSTKEY VARCHAR(100);

  DECLARE _$EMPCD     VARCHAR(20);
  DECLARE _$PROBLEM   VARCHAR(1000);
  DECLARE _$SOLUTION  VARCHAR(1000);

  DECLARE _$SORTNO    DECIMAL(20, 8);
  DECLARE _$PLANAPRV_CNT INT DEFAULT 0;

CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_CYCLE_EQMCD' THEN  -- 정기점검 계획조회
  
  IF $SYEAR = '' THEN
    CALL COMERR('조회년도를 지정해주세요.');
    LEAVE PROC;
  END IF;  

  SELECT 
    MSTEQM.FANO,
    MSTEQM.FANO AS EQMCD,
    MSTEQM.EQMNM,
    $SYEAR AS YEAR,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_01 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-01')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_01 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-01')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M01,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_02 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-02')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_02 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-02')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M02,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_03 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-03')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_03 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-03')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M03,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_04 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-04')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_04 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-04')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M04,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_05 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-05')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_05 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-05')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M05,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_06 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-06')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_06 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-06')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M06,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_07 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-07')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_07 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-07')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M07,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_08 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-08')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_08 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-08')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M08,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_09 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-09')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_09 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-09')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M09,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_10 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-10')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_10 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-10')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M10,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_11 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-11')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_11 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-11')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M11,
    CASE WHEN (CHKPLANEQM_YEARPLAN.MONTH_12 = '●') 
              AND EXISTS (SELECT CHKRSTKEY 
                          FROM CHKRSTEQM 
                          WHERE CHKTP = '02' 
                            AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                            AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-12')
                          )
         THEN '점검완료'
         WHEN (CHKPLANEQM_YEARPLAN.MONTH_12 = '●') 
              AND NOT EXISTS (SELECT CHKRSTKEY 
                              FROM CHKRSTEQM 
                              WHERE CHKTP = '02' 
                                AND CHKRSTEQM.EQMCD = MSTEQM.FANO 
                                AND LEFT(CHKRSTEQM.BASEDATE, 7) = CONCAT($SYEAR, '-12')
                              )
         THEN '점검필요'
         ELSE ''
    END AS M12
  FROM MSTEQM
  LEFT JOIN CHKPLANEQM_YEARPLAN 
         ON CHKPLANEQM_YEARPLAN.EQMCD = MSTEQM.FANO
        AND CHKPLANEQM_YEARPLAN.YEAR = $SYEAR
  LEFT JOIN CHKPLANEQM
        ON CHKPLANEQM.EQMCD = MSTEQM.FANO
  INNER JOIN EQMPLAN_APRV GRP_APRV
    ON GRP_APRV.PLANTP = 'G'
   AND GRP_APRV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_APRV.APRVSTT = 'A'
  INNER JOIN EQMPLAN_APRV EQM_APRV
    ON EQM_APRV.PLANTP = 'E'
   AND EQM_APRV.PLANCD = MSTEQM.FANO
   AND EQM_APRV.APRVSTT = 'A'
  WHERE MSTEQM.USEYN = 'Y'
    AND (MSTEQM.FANO LIKE CONCAT('%', $EQMCD, '%') OR MSTEQM.EQMNM LIKE CONCAT('%', $EQMCD, '%'))
    AND CHKPLANEQM.CHKTP = '02'
    
  GROUP BY MSTEQM.FANO
  ORDER BY MSTEQM.FANO;
-- * ***************************************************************************
WHEN 'LIST_CHKPLANEQM_EQM02' THEN -- 정기점검계획 조회 

  SELECT COUNT(*) INTO _$PLANAPRV_CNT
  FROM MSTEQM
  INNER JOIN EQMPLAN_APRV GRP_APRV
    ON GRP_APRV.PLANTP = 'G'
   AND GRP_APRV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_APRV.APRVSTT = 'A'
  INNER JOIN EQMPLAN_APRV EQM_APRV
    ON EQM_APRV.PLANTP = 'E'
   AND EQM_APRV.PLANCD = MSTEQM.FANO
   AND EQM_APRV.APRVSTT = 'A'
  WHERE MSTEQM.FANO = $EQMCD
    AND MSTEQM.USEYN = 'Y';

  IF _$PLANAPRV_CNT = 0 THEN
    CALL COMERR('승인된 정기점검 계획만 처리할 수 있습니다.');
    LEAVE PROC;
  END IF;
  SELECT 

    CHKPLANEQM.EQMCD,
    CHKPLANEQM.CHKKNDCD,
    MSTCHKKND.CHKKNDNM,
    MSTCHKKND.CHKLOC,
    MSTCHKKND.CHKMTH,
    MSTCHKKND.CHKVALTP,
    CHKPLANEQM.CHKCYCLE,
    '' AS CHKVALUE
  FROM CHKPLANEQM
  INNER JOIN MSTCHKKND 
    ON MSTCHKKND.CHKKNDCD = CHKPLANEQM.CHKKNDCD
  WHERE CHKPLANEQM.EQMCD = $EQMCD
    AND CHKPLANEQM.USEYN = 'Y'
    AND CHKPLANEQM.CHKTP = '02'
  ORDER BY CHKPLANEQM.SORTNO
  ;    

-- ****************************************************************************
WHEN 'ADD_CHKRSTEQM' THEN -- 정기점검 등록 

  IF $EQMCD = '' THEN
    CALL COMERR('설비코드가 비어있습니다.');
    LEAVE PROC;
  END IF;
  
  IF $BASEDATE = '' THEN
    CALL COMERR('점검일자를 선택해주세요.');
    LEAVE PROC;
  END IF;

  IF LEFT($BASEDATE, 7) != $YYYYMM THEN
    CALL COMERR('점검일자의 년월이 계획년월과 다릅니다.');
    LEAVE PROC;
  END IF;

  IF $EMPCD = '' THEN
    CALL COMERR('점검자를 선택해주세요.');
    LEAVE PROC;
  END IF;

  SELECT COUNT(*) INTO _$PLANAPRV_CNT
  FROM MSTEQM
  INNER JOIN EQMPLAN_APRV GRP_APRV
    ON GRP_APRV.PLANTP = 'G'
   AND GRP_APRV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_APRV.APRVSTT = 'A'
  INNER JOIN EQMPLAN_APRV EQM_APRV
    ON EQM_APRV.PLANTP = 'E'
   AND EQM_APRV.PLANCD = MSTEQM.FANO
   AND EQM_APRV.APRVSTT = 'A'
  WHERE MSTEQM.FANO = $EQMCD
    AND MSTEQM.USEYN = 'Y';

  IF _$PLANAPRV_CNT = 0 THEN
    CALL COMERR('승인된 정기점검 계획만 처리할 수 있습니다.');
    LEAVE PROC;
  END IF;
  SET _$CHKRSTKEY = GETKEY('CHKRSTKEY'); 


  INSERT INTO CHKRSTEQM (
    CHKRSTKEY, CHKTP, EQMCD, 
    EMPCD, BASEDATE, PROBLEM, 
    SOLUTION, RTIME, REMP, RPRG
  ) 
  VALUES (
    _$CHKRSTKEY, '02', $EQMCD,
    $EMPCD, $BASEDATE, $PROBLEM,
    $SOLUTION, CALLTIME(), CALLEMP(), CALLPRG()
  ); 


  WHILE LENGTH($CHKKNDCD_LIST) > 0 DO  
    CALL COMSPLIT($CHKKNDCD_LIST, _$CHKKNDCD);
    CALL COMSPLIT($CHKKNDNM_LIST, _$CHKKNDNM);
    CALL COMSPLIT($CHKLOC_LIST, _$CHKLOC);
    CALL COMSPLIT($CHKMTH_LIST, _$CHKMTH);
    CALL COMSPLIT($CHKVALTP_LIST, _$CHKVALTP);
    CALL COMSPLIT($CHKCYCLE_LIST, _$CHKCYCLE);  
    CALL COMSPLIT($CHKVALUE_LIST, _$CHKVALUE);
   
    SET _$SORTNO = (SELECT SORTNO FROM CHKPLANEQM WHERE EQMCD = $EQMCD AND CHKKNDCD = _$CHKKNDCD AND CHKTP = '02'); 
         
    INSERT INTO CHKRSTEQMKND (
    CHKRSTKEY, CHKKNDCD, CHKKNDNM, CHKLOC, 
    CHKMTH, CHKVALTP, CHKVALUE, SORTNO,
    RTIME, REMP, RPRG
    ) VALUES (
    _$CHKRSTKEY, _$CHKKNDCD, _$CHKKNDNM, _$CHKLOC,
    _$CHKMTH, _$CHKVALTP, _$CHKVALUE, _$SORTNO,
    CALLTIME(), CALLEMP(), CALLPRG())
    ;
  
  END WHILE;

-- * ***************************************************************************
WHEN 'SEARCH_CHKRSTEQM' THEN  -- 해당월의 정기점검 조회

  IF $EQMCD = '' THEN
    CALL COMERR('설비코드가 비어있습니다.');
    LEAVE PROC;
  END IF;

  SELECT COUNT(*) INTO _$PLANAPRV_CNT
  FROM MSTEQM
  INNER JOIN EQMPLAN_APRV GRP_APRV
    ON GRP_APRV.PLANTP = 'G'
   AND GRP_APRV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_APRV.APRVSTT = 'A'
  INNER JOIN EQMPLAN_APRV EQM_APRV
    ON EQM_APRV.PLANTP = 'E'
   AND EQM_APRV.PLANCD = MSTEQM.FANO
   AND EQM_APRV.APRVSTT = 'A'
  WHERE MSTEQM.FANO = $EQMCD
    AND MSTEQM.USEYN = 'Y';

  IF _$PLANAPRV_CNT = 0 THEN
    CALL COMERR('승인된 정기점검 계획만 처리할 수 있습니다.');
    LEAVE PROC;
  END IF;
  SET _$CHKRSTKEY = IFNULL((SELECT CHKRSTKEY FROM CHKRSTEQM WHERE EQMCD = $EQMCD AND LEFT(BASEDATE,7) = $YYYYMM ORDER BY BASEDATE, CHKRSTKEY LIMIT 1), '');


  SELECT 
    CHKRSTEQM.CHKRSTKEY,
    CHKRSTEQM.CHKTP,
    CHKRSTEQM.EQMCD,
    CHKRSTEQM.EMPCD,
    CHKRSTEQM.BASEDATE,
    LEFT(CHKRSTEQM.BASEDATE, 7) AS YYYYMM,
    CHKRSTEQM.PROBLEM,
    CHKRSTEQM.SOLUTION,
    CHKRSTEQM.RTIME  
  FROM CHKRSTEQM  
  WHERE CHKRSTKEY = _$CHKRSTKEY
  ;

  SELECT 
    CHKRSTEQMKND.CHKRSTKEY,
    CHKRSTEQMKND.CHKKNDCD,
    CHKRSTEQMKND.CHKKNDNM,
    CHKRSTEQMKND.CHKLOC,
    CHKRSTEQMKND.CHKMTH,
    CHKRSTEQMKND.CHKVALTP,
    CHKRSTEQMKND.CHKVALUE
  FROM CHKRSTEQMKND
  WHERE CHKRSTEQMKND.CHKRSTKEY = _$CHKRSTKEY  
  ORDER BY CHKRSTEQMKND.SORTNO
  ;
-- ****************************************************************************
WHEN 'SAVE_CHKRSTEQM' THEN -- 정기점검 수정

  IF $CHKRSTKEY = '' THEN
    CALL COMERR('점검키가 없습니다.');
    LEAVE PROC;
  END IF;

  IF $BASEDATE = '' THEN
    CALL COMERR('점검일자를 선택해주세요.');
    LEAVE PROC;
  END IF;

  IF LEFT($BASEDATE, 7) != $YYYYMM THEN
    CALL COMERR('점검일자의 년월이 계획년월과 다릅니다.');
    LEAVE PROC;
  END IF;

  IF $EMPCD = '' THEN
    CALL COMERR('점검자를 선택해주세요.');
    LEAVE PROC;
  END IF;

  SELECT COUNT(*) INTO _$PLANAPRV_CNT
  FROM CHKRSTEQM
  INNER JOIN MSTEQM
    ON MSTEQM.FANO = CHKRSTEQM.EQMCD
  INNER JOIN EQMPLAN_APRV GRP_APRV
    ON GRP_APRV.PLANTP = 'G'
   AND GRP_APRV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_APRV.APRVSTT = 'A'
  INNER JOIN EQMPLAN_APRV EQM_APRV
    ON EQM_APRV.PLANTP = 'E'
   AND EQM_APRV.PLANCD = MSTEQM.FANO
   AND EQM_APRV.APRVSTT = 'A'
  WHERE CHKRSTEQM.CHKRSTKEY = $CHKRSTKEY
    AND MSTEQM.USEYN = 'Y';

  IF _$PLANAPRV_CNT = 0 THEN
    CALL COMERR('승인된 정기점검 계획만 처리할 수 있습니다.');
    LEAVE PROC;
  END IF;
  UPDATE CHKRSTEQM 

  SET
    EMPCD = $EMPCD,
    BASEDATE = $BASEDATE,
    PROBLEM = $PROBLEM,
    SOLUTION = $SOLUTION,
    MTIME = CALLTIME(),
    MEMP = CALLEMP(),
    MPRG = CALLPRG()
  WHERE CHKRSTKEY = $CHKRSTKEY
  ;

  WHILE LENGTH($CHKKNDCD_LIST) > 0 DO
    CALL COMSPLIT($CHKKNDCD_LIST, _$CHKKNDCD);
    CALL COMSPLIT($CHKVALUE_LIST, _$CHKVALUE);

    UPDATE CHKRSTEQMKND 
    SET
      CHKVALUE = _$CHKVALUE,
      MTIME = CALLTIME(),
      MEMP = CALLEMP(),
      MPRG = CALLPRG()
    WHERE CHKRSTKEY = $CHKRSTKEY
      AND CHKKNDCD = _$CHKKNDCD
    ;
  END WHILE;
  
-- ****************************************************************************
WHEN 'DELETE_CHKRSTEQM' THEN -- 정기점검 삭제
  IF $CHKRSTKEY = '' THEN
    CALL COMERR('점검키가 없습니다.');
    LEAVE PROC;
  END IF;

  SELECT COUNT(*) INTO _$PLANAPRV_CNT
  FROM CHKRSTEQM
  INNER JOIN MSTEQM
    ON MSTEQM.FANO = CHKRSTEQM.EQMCD
  INNER JOIN EQMPLAN_APRV GRP_APRV
    ON GRP_APRV.PLANTP = 'G'
   AND GRP_APRV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_APRV.APRVSTT = 'A'
  INNER JOIN EQMPLAN_APRV EQM_APRV
    ON EQM_APRV.PLANTP = 'E'
   AND EQM_APRV.PLANCD = MSTEQM.FANO
   AND EQM_APRV.APRVSTT = 'A'
  WHERE CHKRSTEQM.CHKRSTKEY = $CHKRSTKEY
    AND MSTEQM.USEYN = 'Y';

  IF _$PLANAPRV_CNT = 0 THEN
    CALL COMERR('승인된 정기점검 계획만 처리할 수 있습니다.');
    LEAVE PROC;
  END IF;
  DELETE FROM CHKRSTEQMKND WHERE CHKRSTKEY = $CHKRSTKEY;    

  DELETE FROM CHKRSTEQM WHERE CHKRSTKEY = $CHKRSTKEY; 

-- ****************************************************************************
END CASE; END