CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`EQM1001_R04`(
-- *****************************************************************************
-- Comment: 설비 정기점검 등록 
-- Create: 	2025-06-27  	생성 			이대규
-- Modify: 	2026-09-15 		마이그레이션	한성수
-- 			2026-09-16 					한성수	MSTEQM.FANO(설비코드) 컬럼 바인딩 변경
-- 			2026-09-22 					한성수	승인된 설비그룹·설비별 정기점검 계획만 실행
-- 			2026-09-30 					한성수	설비 승인 리비전(REV) 승인본 기준 점검 및 점검실적 적용 리비전 기록
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
  IN $REVNUM        VARCHAR(20),

  
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
  DECLARE _$REVNUM       INT;
  DECLARE _$PENDREVNUM   INT;

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
  -- 설비그룹 승인 리비전이 있고, 설비의 최신 승인 리비전에 정기점검 항목이 있는 설비 (개정 중에도 직전 승인본으로 점검)
  INNER JOIN (
    SELECT MSTEQMREV_HEADER.PLANCD
    FROM MSTEQMREV_HEADER
    WHERE MSTEQMREV_HEADER.PLANTP = 'G'
      AND MSTEQMREV_HEADER.APRVSTT = 'A'
    GROUP BY MSTEQMREV_HEADER.PLANCD
  ) GRP_REV
    ON GRP_REV.PLANCD = MSTEQM.EQMGUBUN
  INNER JOIN (
    SELECT EQM_LAST.PLANCD
    FROM (
      SELECT MSTEQMREV_HEADER.PLANCD,
             MAX(MSTEQMREV_HEADER.REVNUM) AS REVNUM
      FROM MSTEQMREV_HEADER
      WHERE MSTEQMREV_HEADER.PLANTP = 'E'
        AND MSTEQMREV_HEADER.APRVSTT = 'A'
      GROUP BY MSTEQMREV_HEADER.PLANCD
    ) EQM_LAST
    INNER JOIN MSTEQMREV_DETAIL
      ON MSTEQMREV_DETAIL.PLANTP = 'E'
     AND MSTEQMREV_DETAIL.PLANCD = EQM_LAST.PLANCD
     AND MSTEQMREV_DETAIL.REVNUM = EQM_LAST.REVNUM
    GROUP BY EQM_LAST.PLANCD
  ) EQM_REV
    ON EQM_REV.PLANCD = MSTEQM.FANO
  WHERE MSTEQM.USEYN = 'Y'
    AND (MSTEQM.FANO LIKE CONCAT('%', $EQMCD, '%') OR MSTEQM.EQMNM LIKE CONCAT('%', $EQMCD, '%'))
    
  GROUP BY MSTEQM.FANO
  ORDER BY MSTEQM.FANO;
-- * ***************************************************************************
WHEN 'LIST_CHKPLANEQM_EQM02' THEN -- 정기점검계획 조회 (설비 승인 리비전 승인본)

  -- 적용 리비전: 설비의 승인된 최신 리비전 (설비그룹도 승인 리비전이 있어야 함)
  SELECT MAX(EQM_REV.REVNUM) INTO _$REVNUM
  FROM MSTEQM
  INNER JOIN MSTEQMREV_HEADER GRP_REV
    ON GRP_REV.PLANTP = 'G'
   AND GRP_REV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_REV.APRVSTT = 'A'
  INNER JOIN MSTEQMREV_HEADER EQM_REV
    ON EQM_REV.PLANTP = 'E'
   AND EQM_REV.PLANCD = MSTEQM.FANO
   AND EQM_REV.APRVSTT = 'A'
  WHERE MSTEQM.FANO = $EQMCD
    AND MSTEQM.USEYN = 'Y';

  IF _$REVNUM IS NULL THEN
    CALL COMERR('승인된 정기점검 계획만 처리할 수 있습니다.');
    LEAVE PROC;
  END IF;

  -- 진행 중(대기·반려)인 다음 리비전 안내용
  SET _$PENDREVNUM = (SELECT MSTEQMREV_HEADER.REVNUM
                      FROM MSTEQMREV_HEADER
                      WHERE MSTEQMREV_HEADER.PLANTP = 'E'
                        AND MSTEQMREV_HEADER.PLANCD = $EQMCD
                        AND MSTEQMREV_HEADER.APRVSTT <> 'A'
                      LIMIT 1);

  SELECT
    MSTEQMREV_DETAIL.EQMCD,
    MSTEQMREV_DETAIL.CHKKNDCD,
    MSTEQMREV_DETAIL.CHKKNDNM,
    MSTEQMREV_DETAIL.CHKLOC,
    MSTEQMREV_DETAIL.CHKMTH,
    MSTEQMREV_DETAIL.CHKVALTP,
    MSTEQMREV_DETAIL.CHKCYCLE,
    '' AS CHKVALUE,
    _$REVNUM AS REVNUM,
    CONCAT('REV.', _$REVNUM) AS REVNM,
    COALESCE(CONCAT('REV.', _$PENDREVNUM), '') AS PENDREVNM
  FROM MSTEQMREV_DETAIL
  WHERE MSTEQMREV_DETAIL.PLANTP = 'E'
    AND MSTEQMREV_DETAIL.PLANCD = $EQMCD
    AND MSTEQMREV_DETAIL.REVNUM = _$REVNUM
  ORDER BY MSTEQMREV_DETAIL.SORTNO
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

  IF COALESCE($REVNUM, '') NOT REGEXP '^[0-9]+$' THEN
    CALL COMERR('적용 REV가 없습니다. 정기점검 등록 창을 다시 열어주세요.');
    LEAVE PROC;
  END IF;

  -- 팝업을 열 때 적용한 리비전이 그 설비의 승인 리비전인지 확인 (그 사이 새 리비전이 승인돼도 원래 리비전으로 기록)
  SELECT COUNT(*) INTO _$PLANAPRV_CNT
  FROM MSTEQM
  INNER JOIN MSTEQMREV_HEADER GRP_REV
    ON GRP_REV.PLANTP = 'G'
   AND GRP_REV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_REV.APRVSTT = 'A'
  INNER JOIN MSTEQMREV_HEADER EQM_REV
    ON EQM_REV.PLANTP = 'E'
   AND EQM_REV.PLANCD = MSTEQM.FANO
   AND EQM_REV.REVNUM = $REVNUM
   AND EQM_REV.APRVSTT = 'A'
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
    SOLUTION, REVNUM, RTIME, REMP, RPRG
  ) 
  VALUES (
    _$CHKRSTKEY, '02', $EQMCD,
    $EMPCD, $BASEDATE, $PROBLEM,
    $SOLUTION, $REVNUM, CALLTIME(), CALLEMP(), CALLPRG()
  ); 


  WHILE LENGTH($CHKKNDCD_LIST) > 0 DO  
    CALL COMSPLIT($CHKKNDCD_LIST, _$CHKKNDCD);
    CALL COMSPLIT($CHKKNDNM_LIST, _$CHKKNDNM);
    CALL COMSPLIT($CHKLOC_LIST, _$CHKLOC);
    CALL COMSPLIT($CHKMTH_LIST, _$CHKMTH);
    CALL COMSPLIT($CHKVALTP_LIST, _$CHKVALTP);
    CALL COMSPLIT($CHKCYCLE_LIST, _$CHKCYCLE);  
    CALL COMSPLIT($CHKVALUE_LIST, _$CHKVALUE);
   
    SET _$SORTNO = (SELECT SORTNO FROM MSTEQMREV_DETAIL WHERE PLANTP = 'E' AND PLANCD = $EQMCD AND REVNUM = $REVNUM AND CHKKNDCD = _$CHKKNDCD); 
         
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
  INNER JOIN MSTEQMREV_HEADER GRP_REV
    ON GRP_REV.PLANTP = 'G'
   AND GRP_REV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_REV.APRVSTT = 'A'
  INNER JOIN MSTEQMREV_HEADER EQM_REV
    ON EQM_REV.PLANTP = 'E'
   AND EQM_REV.PLANCD = MSTEQM.FANO
   AND EQM_REV.APRVSTT = 'A'
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
    CHKRSTEQM.RTIME,
    CHKRSTEQM.REVNUM,
    COALESCE(CONCAT('REV.', CHKRSTEQM.REVNUM), '') AS REVNM
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
  INNER JOIN MSTEQMREV_HEADER GRP_REV
    ON GRP_REV.PLANTP = 'G'
   AND GRP_REV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_REV.APRVSTT = 'A'
  INNER JOIN MSTEQMREV_HEADER EQM_REV
    ON EQM_REV.PLANTP = 'E'
   AND EQM_REV.PLANCD = MSTEQM.FANO
   AND EQM_REV.APRVSTT = 'A'
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
  INNER JOIN MSTEQMREV_HEADER GRP_REV
    ON GRP_REV.PLANTP = 'G'
   AND GRP_REV.PLANCD = MSTEQM.EQMGUBUN
   AND GRP_REV.APRVSTT = 'A'
  INNER JOIN MSTEQMREV_HEADER EQM_REV
    ON EQM_REV.PLANTP = 'E'
   AND EQM_REV.PLANCD = MSTEQM.FANO
   AND EQM_REV.APRVSTT = 'A'
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