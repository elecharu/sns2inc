CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML2010_R01(
-- *****************************************************************************
-- Comment: 생산실적등록 (현장)
-- Create: 2026-10-26 신정수
-- Modify:
-- *****************************************************************************
  IN $LINECD VARCHAR(100),     -- 작업장
  IN $PRCCD VARCHAR(100),       -- 공정
  IN $EQMCD VARCHAR(100),      -- 라인
  IN $SCANLOT VARCHAR(100),
  IN $ITEMID INT(11),          -- 생산품목ID
  IN $EMPCD_LIST MEDIUMTEXT,   -- 라인 작업자 사원코드 목록
  IN $DNTP VARCHAR(100),       -- 주야구분 (PP161)
  IN $WORKSDAY VARCHAR(10),    -- 작업시작일
  IN $WORKSTIME VARCHAR(8),    -- 작업시작시간
  IN $WORKEDAY VARCHAR(10),    -- 작업종료일
  IN $WORKETIME VARCHAR(8),    -- 작업종료시간
  IN $LOTKEY_LIST MEDIUMTEXT,  -- 투입로트 목록
  IN $USEQTY_LIST MEDIUMTEXT,  -- 투입로트별 사용량 목록
  IN $BADCD VARCHAR(100),      -- 불량코드
  IN $BADDETAIL VARCHAR(100),  -- 불량상세
  IN $BADQTY DECIMAL(20, 0),   -- 불량수량
  IN $NONTP VARCHAR(20),       -- 비가동유형 (PP409)
  IN $NONCD VARCHAR(20),       -- 비가동코드
  IN $NONSTIME VARCHAR(19),    -- 비가동 시작시간
  IN $NONETIME VARCHAR(19),    -- 비가동 종료시간
  IN $REMARK VARCHAR(1000),    -- 비고
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
  -- *****************************************************************************
-- SET @DEBUGLOGYN = 'Y';
  DECLARE _$WARECD VARCHAR(100);
  DECLARE _$ITEMID INT(11);
  DECLARE _$PDATE VARCHAR(10);
  DECLARE _$EMPCD VARCHAR(100);
  DECLARE _$PRDNONKEY VARCHAR(20);
-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'SCAN_LOT' THEN  -- 투입로트 스캔
  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $SCANLOT = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;  

  SET _$WARECD = '04S111_N'; -- 자재투입창고

  IF NOT EXISTS (SELECT LOTKEY FROM COMLOT WHERE WARECD = _$WARECD AND LOTKEY = $SCANLOT) THEN
    CALL COMERR(CONCAT('해당 창고에 존재하지 않는 로트번호입니다.'
                      , '\n- 창고: ', (SELECT WARENM FROM MSTWARE WHERE WARECD = _$WARECD)
                      , '\n- 로트번호: ', $SCANLOT
                      )
               );
    LEAVE PROC;
  END IF;

  IF (SELECT LOTQTY FROM COMLOT WHERE WARECD = _$WARECD AND LOTKEY = $SCANLOT) = 0 THEN
    CALL COMERR(CONCAT('재고수량이 0 입니다.'
                      , '\n- 창고: ', (SELECT WARENM FROM MSTWARE WHERE WARECD = _$WARECD)
                      , '\n- 로트번호: ', $SCANLOT
                      )
               );
    LEAVE PROC;
  END IF;

  
  -- 1. BOM으로 모품목 찾기
  -- 2. 생산품이 작업장, 공정, 라인에서 작업가능한지 확인
  --    작업안되면 가능한 작업장, 공정 리턴 
  --    작업되면 투입추가
  -- 3. 생산품 리턴
  --    생산품이 2개이상이면 팝업창에서 선택

  -- 투입로트 품목
  SELECT COMLOT.ITEMID
  INTO _$ITEMID
  FROM COMLOT
  WHERE COMLOT.WARECD = _$WARECD
    AND COMLOT.LOTKEY = $SCANLOT
  LIMIT 1;

  -- 1. BOM으로 모품목 찾기
  IF NOT EXISTS (SELECT MSTBOM.MITEMID
                   FROM MSTBOM
                   WHERE MSTBOM.CITEMID = _$ITEMID
                     AND MSTBOM.USEYN = 'Y'
                     AND (MSTBOM.USETODT IS NULL OR MSTBOM.USETODT = '' OR LEFT(MSTBOM.USETODT, 4) = '9999')) THEN
    CALL COMERR(CONCAT('BOM에 등록된 모품목이 없습니다.'
                      , '\n- 품목코드: ', (SELECT MSTITEM.ITEMCD FROM MSTITEM WHERE MSTITEM.ITEMID = _$ITEMID)
                      , '\n- 품명: ', (SELECT MSTITEM.ITEMNM FROM MSTITEM WHERE MSTITEM.ITEMID = _$ITEMID)
                      )
               );
    LEAVE PROC;
  END IF;

  -- 2. 모품목 중 선택한 작업장, 공정에서 생산하는 품목이 있는지 확인 (기본 라우팅)
  IF NOT EXISTS (SELECT MSTBOM.MITEMID
                   FROM MSTBOM
                   INNER JOIN MSTROUT_MATCH
                     ON MSTROUT_MATCH.ITEMID = MSTBOM.MITEMID                    
                   INNER JOIN MSTROUT_DETAIL
                     ON MSTROUT_DETAIL.ROUTCD = MSTROUT_MATCH.ROUTCD
                    AND MSTROUT_DETAIL.LINCD = $LINECD
                    AND MSTROUT_DETAIL.PRCCD = $PRCCD
                   INNER JOIN MSTROUT
                     ON MSTROUT.ROUTCD = MSTROUT_MATCH.ROUTCD
                   WHERE MSTBOM.CITEMID = _$ITEMID
                     AND MSTBOM.USEYN = 'Y'
                     AND (MSTBOM.USETODT IS NULL OR MSTBOM.USETODT = '' OR LEFT(MSTBOM.USETODT, 4) = '9999')
                     AND MSTROUT_MATCH.BASEYN = 'Y'
                     AND MSTROUT.USEYN = 'Y') THEN
    IF NOT EXISTS (SELECT MSTBOM.MITEMID
                     FROM MSTBOM
                     INNER JOIN MSTROUT_MATCH
                       ON MSTROUT_MATCH.ITEMID = MSTBOM.MITEMID                    
                     INNER JOIN MSTROUT_DETAIL
                       ON MSTROUT_DETAIL.ROUTCD = MSTROUT_MATCH.ROUTCD
                      AND MSTROUT_DETAIL.LINCD != $LINECD
                     INNER JOIN MSTROUT
                       ON MSTROUT.ROUTCD = MSTROUT_MATCH.ROUTCD
                     WHERE MSTBOM.CITEMID = _$ITEMID
                       AND MSTBOM.USEYN = 'Y'
                       AND (MSTBOM.USETODT IS NULL OR MSTBOM.USETODT = '' OR LEFT(MSTBOM.USETODT, 4) = '9999')
                       AND MSTROUT_MATCH.BASEYN = 'Y'
                       AND MSTROUT.USEYN = 'Y') THEN
        CALL COMERR(CONCAT('스캔한 투입품목으로 생산하는 모품목이 없습니다.'
                          , '\n- 품목코드: ', (SELECT MSTITEM.ITEMCD FROM MSTITEM WHERE MSTITEM.ITEMID = _$ITEMID)
                          , '\n- 품명: ', (SELECT MSTITEM.ITEMNM FROM MSTITEM WHERE MSTITEM.ITEMID = _$ITEMID)
                          )
                   );
        LEAVE PROC;
    ELSE
      SELECT
          'NO_BOM' AS RESULT
        , MSTROUT_DETAIL.LINCD AS LINECD
        , MSTROUT_DETAIL.PRCCD
        , CONCAT('품목 :', (SELECT MSTITEM.ITEMCD FROM MSTITEM WHERE MSTITEM.ITEMID = _$ITEMID)
                ,'\n작업장 :', (SELECT LINENM FROM MSTLINE WHERE LINECD = $LINECD), ', 공정: ', (SELECT PRCNM FROM MSTPRC WHERE PRCCD = $PRCCD)             
                ,'\n선택한 작업장 및 공정으로 지정된 라우팅이 없습니다.\n'
                ,'\n기본작업장 :', MSTLINE.LINENM, ', 기본공정: ', MSTPRC.PRCNM                
                ,'\n해당 작업장 및 기본공정으로 자동변경됩니다.\n스캔을 다시 진행해주세요.'
                )
          AS MSG
      FROM MSTBOM
      INNER JOIN MSTITEM
        ON MSTITEM.ITEMID = MSTBOM.MITEMID
      INNER JOIN MSTROUT_MATCH
        ON MSTROUT_MATCH.ITEMID = MSTBOM.MITEMID   
      INNER JOIN MSTROUT_DETAIL
        ON MSTROUT_DETAIL.ROUTCD = MSTROUT_MATCH.ROUTCD
       AND MSTROUT_DETAIL.LINCD != $LINECD 
      INNER JOIN MSTROUT
       ON MSTROUT.ROUTCD = MSTROUT_MATCH.ROUTCD
      LEFT JOIN MSTLINE
        ON MSTLINE.LINECD = MSTROUT_DETAIL.LINCD
      LEFT JOIN MSTPRC
        ON MSTPRC.PRCCD = MSTROUT_DETAIL.PRCCD
      WHERE MSTBOM.CITEMID = _$ITEMID
        AND MSTBOM.USEYN = 'Y'
        AND (MSTBOM.USETODT IS NULL OR MSTBOM.USETODT = '' OR LEFT(MSTBOM.USETODT, 4) = '9999')
        AND MSTROUT_MATCH.BASEYN = 'Y'   
        AND MSTROUT.USEYN = 'Y'
      ORDER BY MSTROUT.ROUTCD
      LIMIT 1
      ;
    END IF;
  ELSE

  
    -- 3. 모품목 리스트 출력 (선택한 작업장, 공정에서 생산하는 품목만, 기본 라우팅)
    SELECT
        'YES_BOM' AS RESULT
      , CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
      , MSTITEM.ITEMCD
      , MSTITEM.ITEMNM
      , MSTITEM.ITEMSPEC
      , $SCANLOT AS LOTKEY
    FROM MSTBOM
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = MSTBOM.MITEMID
    INNER JOIN MSTROUT_MATCH
      ON MSTROUT_MATCH.ITEMID = MSTBOM.MITEMID   
    INNER JOIN MSTROUT_DETAIL
      ON MSTROUT_DETAIL.ROUTCD = MSTROUT_MATCH.ROUTCD
     AND MSTROUT_DETAIL.LINCD = $LINECD
     AND MSTROUT_DETAIL.PRCCD = $PRCCD   
    INNER JOIN MSTROUT
     ON MSTROUT.ROUTCD = MSTROUT_MATCH.ROUTCD
    WHERE MSTBOM.CITEMID = _$ITEMID
      AND MSTBOM.USEYN = 'Y'
      AND (MSTBOM.USETODT IS NULL OR MSTBOM.USETODT = '' OR LEFT(MSTBOM.USETODT, 4) = '9999')
      AND MSTROUT_MATCH.BASEYN = 'Y'   
      AND MSTROUT.USEYN = 'Y'
    GROUP BY MSTITEM.ITEMID
    ORDER BY MSTITEM.ITEMCD
    ;
  END IF;

-- ****************************************************************************
WHEN 'LIST_INPUT' THEN  -- 투입로트 조회, 생산품 조회 

  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 0. 투입로트 조회
  SELECT
      MSTITEM.ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , GPCD('DM100', MSTITEM.ITEMCG) AS ITEMCG
    , GPCD('DM150', MSTITEM.ITEMUNIT) AS ITEMUNIT
    , COMLOT.LOTKEY
    , COMLOT.LOTQTY
    , COMLOT.WARECD
    , MSTWARE.WARENM
  FROM PRDLINESCAN
  INNER JOIN COMLOT
    ON COMLOT.WARECD = PRDLINESCAN.WARECD
   AND COMLOT.LOTKEY = PRDLINESCAN.LOTKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = COMLOT.ITEMID
  INNER JOIN MSTWARE
    ON MSTWARE.WARECD = COMLOT.WARECD
  WHERE PRDLINESCAN.LINECD = $LINECD
    AND PRDLINESCAN.PRCCD = $PRCCD    
    AND PRDLINESCAN.EQMCD = $EQMCD
  ORDER BY PRDLINESCAN.SCANTIME
  ;

  -- 계획일자: 자정 이후 야간(00:00 ~ 야간 종료시간 PP161102N.REF02)이면 어제, 아니면 오늘
  IF SUBSTRING(CALLTIME(), 12, 5) < (SELECT COMTYPE.REF02 FROM COMTYPE WHERE COMTYPE.GPCD = 'PP161' AND COMTYPE.TPCD = 'PP161102N') THEN
    SET _$PDATE = DATE_FORMAT(DATE_SUB(GETDATE(), INTERVAL 1 DAY), '%Y-%m-%d');
  ELSE
    SET _$PDATE = GETDATE();
  END IF;

  -- 1. 생산품 조회 (계획일자 주간생산계획 수량 포함, 없거나 0이면 빈칸)
  SELECT
      CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , IF(IFNULL(PLAN_TODAY.PLANQTY_DAY, 0) = 0, '', FORMAT(PLAN_TODAY.PLANQTY_DAY, 0)) AS PLANQTY_DAY
    , IF(IFNULL(PLAN_TODAY.PLANQTY_NIGHT, 0) = 0, '', FORMAT(PLAN_TODAY.PLANQTY_NIGHT, 0)) AS PLANQTY_NIGHT
  FROM PRDLINEITEM
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = PRDLINEITEM.ITEMID
  LEFT JOIN (
              -- 같은 날짜가 계획월(PMONTH)별로 두 줄일 수 있어 한 줄로 묶음
              SELECT
                  PRDPLAN_W.ITEMID
                , PRDPLAN_W.EQMCD
                , MAX(PRDPLAN_W.PLANQTY_DAY) AS PLANQTY_DAY
                , MAX(PRDPLAN_W.PLANQTY_NIGHT) AS PLANQTY_NIGHT
              FROM PRDPLAN_W
              WHERE PRDPLAN_W.PDATE = _$PDATE
              GROUP BY PRDPLAN_W.ITEMID
                     , PRDPLAN_W.EQMCD
            ) AS PLAN_TODAY
    ON PLAN_TODAY.ITEMID = PRDLINEITEM.ITEMID
   AND PLAN_TODAY.EQMCD = PRDLINEITEM.EQMCD
  WHERE PRDLINEITEM.LINECD = $LINECD
    AND PRDLINEITEM.PRCCD = $PRCCD
    AND PRDLINEITEM.EQMCD = $EQMCD
  ;

  -- 2. 라인 작업자 조회
  SELECT
      PRDLINEEMP.EMPCD
    , IFNULL(MSTEMP.EMPNM, '') AS EMPNM
  FROM PRDLINEEMP
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = PRDLINEEMP.EMPCD
  WHERE PRDLINEEMP.LINECD = $LINECD
    AND PRDLINEEMP.PRCCD = $PRCCD
    AND PRDLINEEMP.EQMCD = $EQMCD
  ORDER BY MSTEMP.EMPNM
  ;

  -- 3. 라인 불량 목록
  SELECT
      PRDLINEBAD.RTIME AS BADTIME
    , IFNULL(MSTBAD.BADNM, '') AS BADNM
    , PRDLINEBAD.BADDETAIL
    , PRDLINEBAD.BADQTY
    , GPCD('QM210', MSTBAD.BADTP1) AS BADTP1NM
    , GPCD('QM220', MSTBAD.BADTP2) AS BADTP2NM
    , PRDLINEBAD.BADCD
  FROM PRDLINEBAD
  LEFT JOIN MSTBAD
    ON MSTBAD.BADCD = PRDLINEBAD.BADCD
  WHERE PRDLINEBAD.LINECD = $LINECD
    AND PRDLINEBAD.PRCCD = $PRCCD
    AND PRDLINEBAD.EQMCD = $EQMCD
  ORDER BY PRDLINEBAD.RTIME
  ;

  -- 4. 라인 불량수량 합계
  SELECT IFNULL(SUM(PRDLINEBAD.BADQTY), 0) AS BADQTY
  FROM PRDLINEBAD
  WHERE PRDLINEBAD.LINECD = $LINECD
    AND PRDLINEBAD.PRCCD = $PRCCD
    AND PRDLINEBAD.EQMCD = $EQMCD
  ;

  -- 5. 라인 비가동 목록 (이번 작업분: 작업완료 전이라 작업키가 빈 것, LIST_NON 과 같음)
  SELECT
      IFNULL(GPCD('PP409', MSTNON.NONGROUPCD1), '') AS NONTPNM
    , IFNULL(MSTNON.NONNM, '') AS NONNM
    , PRDRSTNON.NONSTIME
    , PRDRSTNON.NONETIME
    , IF(PRDRSTNON.NONETIME = '', NULL, TIMESTAMPDIFF(MINUTE, PRDRSTNON.NONSTIME, PRDRSTNON.NONETIME)) AS NONMIN
  FROM PRDRSTNON
  LEFT JOIN MSTNON
    ON MSTNON.LINECD = PRDRSTNON.LINECD
   AND MSTNON.NONCD = PRDRSTNON.NONCD
  WHERE PRDRSTNON.EQMCD = $EQMCD
    AND PRDRSTNON.PRDWORKKEY = ''
  ORDER BY PRDRSTNON.NONSTIME
  ;

-- ****************************************************************************
WHEN 'ADD_INPUT' THEN  -- 투입로트 등록

  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $SCANLOT = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;  

  SET _$WARECD = '04S111_N'; -- 자재투입창고

  IF NOT EXISTS (SELECT LOTKEY FROM COMLOT WHERE WARECD = _$WARECD AND LOTKEY = $SCANLOT) THEN
    CALL COMERR(CONCAT('해당 창고에 존재하지 않는 로트번호입니다.'
                      , '\n- 창고: ', (SELECT WARENM FROM MSTWARE WHERE WARECD = _$WARECD)
                      , '\n- 로트번호: ', $SCANLOT
                      )
               );
    LEAVE PROC;
  END IF;

  IF (SELECT LOTQTY FROM COMLOT WHERE WARECD = _$WARECD AND LOTKEY = $SCANLOT) = 0 THEN
    CALL COMERR(CONCAT('재고수량이 0 입니다.'
                      , '\n- 창고: ', (SELECT WARENM FROM MSTWARE WHERE WARECD = _$WARECD)
                      , '\n- 로트번호: ', $SCANLOT
                      )
               );
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT LOTKEY FROM PRDLINESCAN WHERE LINECD = $LINECD AND PRCCD = $PRCCD AND WARECD = _$WARECD AND LOTKEY = $SCANLOT) THEN
    CALL COMERR(CONCAT('이미 투입된 로트입니다.'
                      , '\n- 창고: ', (SELECT WARENM FROM MSTWARE WHERE WARECD = _$WARECD)
                      , '\n- 로트번호: ', $SCANLOT
                      )
               );
    LEAVE PROC;
  END IF;
  
  -- 3. 자재투입등록
  INSERT INTO PRDLINESCAN (
      LINECD
    , PRCCD
    , EQMCD
    , WARECD
    , LOTKEY
    , SCANTIME
    , RTIME, REMP, RPRG)
  VALUES (
      $LINECD
    , $PRCCD
    , $EQMCD
    , _$WARECD
    , $SCANLOT
    , CALLTIME()
    , CALLTIME(), CALLEMP(), CALLPRG()
  );
-- ****************************************************************************
WHEN 'DEL_INPUT' THEN  -- 투입로트 삭제

  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $SCANLOT = '' THEN
    CALL COMERR('로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  SET _$WARECD = '04S111_N'; -- 자재투입창고

  IF NOT EXISTS (SELECT LOTKEY FROM PRDLINESCAN WHERE LINECD = $LINECD AND PRCCD = $PRCCD AND WARECD = _$WARECD AND LOTKEY = $SCANLOT) THEN
    CALL COMERR(CONCAT('투입되지 않은 로트번호입니다.'
                      , '\n- 로트번호: ', $SCANLOT
                      )
               );
    LEAVE PROC;
  END IF;

  DELETE
  FROM PRDLINESCAN
  WHERE PRDLINESCAN.LINECD = $LINECD
    AND PRDLINESCAN.PRCCD = $PRCCD
    AND PRDLINESCAN.EQMCD = $EQMCD
    AND PRDLINESCAN.WARECD = _$WARECD
    AND PRDLINESCAN.LOTKEY = $SCANLOT;

  -- 라인에 남은 투입로트가 없으면 라인 생산품 정보도 삭제
  IF NOT EXISTS (SELECT PRDLINESCAN.LOTKEY
                   FROM PRDLINESCAN
                   WHERE PRDLINESCAN.LINECD = $LINECD
                     AND PRDLINESCAN.PRCCD = $PRCCD
                     AND PRDLINESCAN.EQMCD = $EQMCD) THEN
    DELETE
    FROM PRDLINEITEM
    WHERE PRDLINEITEM.LINECD = $LINECD
      AND PRDLINEITEM.PRCCD = $PRCCD
      AND PRDLINEITEM.EQMCD = $EQMCD;
  END IF;
-- ****************************************************************************
WHEN 'SET_LINEITEM' THEN  -- 생산품 선택

  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($ITEMID, 0) = 0 THEN
    CALL COMERR('생산품목을 선택하세요.');
    LEAVE PROC;
  END IF;

  INSERT INTO PRDLINEITEM (
      LINECD
    , PRCCD
    , EQMCD
    , ITEMID
    , INPUTTIME
    , RTIME, REMP, RPRG)
  VALUES (
      $LINECD
    , $PRCCD
    , $EQMCD
    , $ITEMID
    , CALLTIME()
    , CALLTIME(), CALLEMP(), CALLPRG()
  )
  ON DUPLICATE KEY UPDATE
      ITEMID    = $ITEMID
    , INPUTTIME = CALLTIME()
    , MTIME     = CALLTIME()
    , MEMP      = CALLEMP()
    , MPRG      = CALLPRG()
  ;
-- ****************************************************************************
WHEN 'LIST_EMP' THEN  -- 작업자 선택용 사원 목록 (이 라인 작업자는 체크)

  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT
      IF(PRDLINEEMP.EMPCD IS NULL, 'N', 'Y') AS ISCHECKED
    , MSTEMP.EMPCD
    , MSTEMP.EMPNM
  FROM MSTEMP
  LEFT JOIN PRDLINEEMP
    ON PRDLINEEMP.EMPCD = MSTEMP.EMPCD
   AND PRDLINEEMP.LINECD = $LINECD
   AND PRDLINEEMP.PRCCD = $PRCCD
   AND PRDLINEEMP.EQMCD = $EQMCD
  WHERE MSTEMP.FACTORYCD = '07'    -- 2공장
    AND MSTEMP.DEPTCD = '44F20'    -- 생산팀
    AND MSTEMP.STATBC = 'HR125100' -- 근무
  ORDER BY MSTEMP.EMPNM
  ;
-- ****************************************************************************
WHEN 'SAVE_LINEEMP' THEN  -- 라인 작업자 저장 (체크한 사원으로 교체)

  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  DELETE
    FROM PRDLINEEMP
    WHERE PRDLINEEMP.LINECD = $LINECD
      AND PRDLINEEMP.PRCCD = $PRCCD
      AND PRDLINEEMP.EQMCD = $EQMCD;

  WHILE LENGTH($EMPCD_LIST) > 0 DO
    CALL COMSPLIT($EMPCD_LIST, _$EMPCD);

    INSERT INTO PRDLINEEMP (
        LINECD
      , PRCCD
      , EQMCD
      , EMPCD
      , RTIME, REMP, RPRG)
    VALUES (
        $LINECD
      , $PRCCD
      , $EQMCD
      , _$EMPCD
      , CALLTIME(), CALLEMP(), CALLPRG()
    );
  END WHILE;
-- ****************************************************************************
WHEN 'WORK_DONE' THEN  -- 작업완료 (작업지시·작업이력·생산실적·자재출고·실적로트 입고)

  CALL IO_PRDRST($LINECD, $PRCCD, $EQMCD, $ITEMID, $DNTP
                , $WORKSDAY, $WORKSTIME, $WORKEDAY, $WORKETIME
                , $LOTKEY_LIST, $USEQTY_LIST);

-- ****************************************************************************
WHEN 'SAVE_LINEBAD' THEN  -- 라인 불량정보 저장 (같은 불량코드·불량상세면 수량 합산)

  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $BADCD = '' THEN
    CALL COMERR('불량코드를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($BADQTY, 0) <= 0 THEN
    CALL COMERR('불량수량을 입력하세요.');
    LEAVE PROC;
  END IF;

  -- 라인 작업자 중 사원코드가 가장 작은 사람 (IO_PRDRST 의 PRDWORK.EMPCD 와 같은 기준)
  SELECT MIN(PRDLINEEMP.EMPCD) INTO _$EMPCD
    FROM PRDLINEEMP
    WHERE PRDLINEEMP.LINECD = $LINECD
      AND PRDLINEEMP.PRCCD = $PRCCD
      AND PRDLINEEMP.EQMCD = $EQMCD;

  IF IFNULL(_$EMPCD, '') = '' THEN
    CALL COMERR('작업자를 선택하세요.');
    LEAVE PROC;
  END IF;

  INSERT INTO PRDLINEBAD (
      LINECD
    , PRCCD
    , EQMCD
    , BADCD
    , BADDETAIL
    , BADQTY
    , EMPCD
    , RTIME, REMP, RPRG)
  VALUES (
      $LINECD
    , $PRCCD
    , $EQMCD
    , $BADCD
    , $BADDETAIL
    , $BADQTY
    , _$EMPCD
    , CALLTIME(), CALLEMP(), CALLPRG()
  )
  ON DUPLICATE KEY UPDATE
      BADQTY = PRDLINEBAD.BADQTY + $BADQTY
    , MTIME = CALLTIME()
    , MEMP = CALLEMP()
    , MPRG = CALLPRG();

  -- 화면 불량 탭·불량수량 갱신용 (LIST_INPUT 3, 4번과 같음)
  SELECT
      PRDLINEBAD.RTIME AS BADTIME
    , IFNULL(MSTBAD.BADNM, '') AS BADNM
    , PRDLINEBAD.BADDETAIL
    , PRDLINEBAD.BADQTY
    , GPCD('QM210', MSTBAD.BADTP1) AS BADTP1NM
    , GPCD('QM220', MSTBAD.BADTP2) AS BADTP2NM
    , PRDLINEBAD.BADCD
  FROM PRDLINEBAD
  LEFT JOIN MSTBAD
    ON MSTBAD.BADCD = PRDLINEBAD.BADCD
  WHERE PRDLINEBAD.LINECD = $LINECD
    AND PRDLINEBAD.PRCCD = $PRCCD
    AND PRDLINEBAD.EQMCD = $EQMCD
  ORDER BY PRDLINEBAD.RTIME
  ;

  SELECT IFNULL(SUM(PRDLINEBAD.BADQTY), 0) AS BADQTY
  FROM PRDLINEBAD
  WHERE PRDLINEBAD.LINECD = $LINECD
    AND PRDLINEBAD.PRCCD = $PRCCD
    AND PRDLINEBAD.EQMCD = $EQMCD
  ;

-- ****************************************************************************
WHEN 'DEL_LINEBAD' THEN  -- 라인 불량정보 삭제

  IF $LINECD = '' OR $PRCCD = '' OR $EQMCD = '' THEN
    CALL COMERR('생산작업장, 생산공정, 생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $BADCD = '' THEN
    CALL COMERR('삭제할 불량을 선택하세요.');
    LEAVE PROC;
  END IF;

  DELETE
    FROM PRDLINEBAD
    WHERE PRDLINEBAD.LINECD = $LINECD
      AND PRDLINEBAD.PRCCD = $PRCCD
      AND PRDLINEBAD.EQMCD = $EQMCD
      AND PRDLINEBAD.BADCD = $BADCD
      AND PRDLINEBAD.BADDETAIL = $BADDETAIL;

  -- 화면 불량 탭·불량수량 갱신용 (LIST_INPUT 3, 4번과 같음)
  SELECT
      PRDLINEBAD.RTIME AS BADTIME
    , IFNULL(MSTBAD.BADNM, '') AS BADNM
    , PRDLINEBAD.BADDETAIL
    , PRDLINEBAD.BADQTY
    , GPCD('QM210', MSTBAD.BADTP1) AS BADTP1NM
    , GPCD('QM220', MSTBAD.BADTP2) AS BADTP2NM
    , PRDLINEBAD.BADCD
  FROM PRDLINEBAD
  LEFT JOIN MSTBAD
    ON MSTBAD.BADCD = PRDLINEBAD.BADCD
  WHERE PRDLINEBAD.LINECD = $LINECD
    AND PRDLINEBAD.PRCCD = $PRCCD
    AND PRDLINEBAD.EQMCD = $EQMCD
  ORDER BY PRDLINEBAD.RTIME
  ;

  SELECT IFNULL(SUM(PRDLINEBAD.BADQTY), 0) AS BADQTY
  FROM PRDLINEBAD
  WHERE PRDLINEBAD.LINECD = $LINECD
    AND PRDLINEBAD.PRCCD = $PRCCD
    AND PRDLINEBAD.EQMCD = $EQMCD
  ;

-- ****************************************************************************
-- 비가동 (TML2040_R01 참고, 설비 대신 라인 기준. 작업키·실적키는 작업완료 전이라 빈값)
-- ****************************************************************************
WHEN 'CHK_NON' THEN  -- 라인에 진행 중(종료 안 된) 비가동 확인

  IF EXISTS (SELECT PRDRSTNON.PRDNONKEY
               FROM PRDRSTNON
               WHERE PRDRSTNON.EQMCD = $EQMCD
                 AND PRDRSTNON.NONETIME = ''
                 AND PRDRSTNON.PRDWORKKEY = '') THEN
    SELECT
        'Y' AS CHK
      , PRDRSTNON.NONSTIME
      , IFNULL(MSTNON.NONGROUPCD1, '') AS NONTP -- 유형은 저장하지 않고 MSTNON(LINECD, NONCD)에서 가져옴
      , PRDRSTNON.NONCD
      , PRDRSTNON.REMARK
    FROM PRDRSTNON
    LEFT JOIN MSTNON ON MSTNON.LINECD = PRDRSTNON.LINECD AND MSTNON.NONCD = PRDRSTNON.NONCD
    WHERE PRDRSTNON.EQMCD = $EQMCD
      AND PRDRSTNON.NONETIME = ''
      AND PRDRSTNON.PRDWORKKEY = ''
    ORDER BY PRDRSTNON.NONSTIME DESC
    LIMIT 1;
  ELSE
    SELECT 'N' AS CHK;
  END IF;

-- ****************************************************************************
WHEN 'LIST_NON' THEN  -- 라인 비가동 목록 (비가동 시작·종료 후 비가동 탭 갱신, LIST_INPUT 5번과 같음)

  SELECT
      IFNULL(GPCD('PP409', MSTNON.NONGROUPCD1), '') AS NONTPNM
    , IFNULL(MSTNON.NONNM, '') AS NONNM
    , PRDRSTNON.NONSTIME
    , PRDRSTNON.NONETIME
    , IF(PRDRSTNON.NONETIME = '', NULL, TIMESTAMPDIFF(MINUTE, PRDRSTNON.NONSTIME, PRDRSTNON.NONETIME)) AS NONMIN
  FROM PRDRSTNON
  LEFT JOIN MSTNON
    ON MSTNON.LINECD = PRDRSTNON.LINECD
   AND MSTNON.NONCD = PRDRSTNON.NONCD
  WHERE PRDRSTNON.EQMCD = $EQMCD
    AND PRDRSTNON.PRDWORKKEY = ''
  ORDER BY PRDRSTNON.NONSTIME
  ;

-- ****************************************************************************
WHEN 'LIST_NONTP' THEN  -- 비가동 유형 (작업장 기준)

  SELECT MSTNON.NONGROUPCD1 AS NONTP, NON_HEAD.TPNM AS TPNM
    FROM MSTNON
    INNER JOIN (
      SELECT TPCD, TPNM
        FROM COMTYPE
        WHERE GPCD = 'PP409'
      ) AS NON_HEAD ON MSTNON.NONGROUPCD1 = NON_HEAD.TPCD
    WHERE MSTNON.LINECD = $LINECD
      AND MSTNON.FACTORYCD = '07' -- 2공장
      AND MSTNON.USEYN = 'Y'
    GROUP BY MSTNON.NONGROUPCD1;

-- ****************************************************************************
WHEN 'LIST_MSTNON' THEN  -- 비가동 코드 (유형·작업장 기준)

  SELECT MSTNON.NONCD, MSTNON.NONNM
    FROM MSTNON
    WHERE MSTNON.NONGROUPCD1 = $NONTP
      AND MSTNON.LINECD = $LINECD;

-- ****************************************************************************
WHEN 'START_NON' THEN  -- 비가동 시작 (비가동코드는 종료 때 골라도 됨)

  IF $LINECD = '' OR $PRCCD = '' OR $EQMCD = '' THEN
    CALL COMERR('생산작업장, 생산공정, 생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $NONSTIME = '' THEN
    CALL COMERR('비가동 시작시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT PRDRSTNON.PRDNONKEY
               FROM PRDRSTNON
               WHERE PRDRSTNON.EQMCD = $EQMCD
                 AND PRDRSTNON.NONETIME = ''
                 AND PRDRSTNON.PRDWORKKEY = '') THEN
    CALL COMERR('이미 진행 중인 비가동이 있습니다. 종료 후 시작하세요.');
    LEAVE PROC;
  END IF;

  SET _$PRDNONKEY = GETKEY('PRDRSTNON'); -- TML2040 과 같은 키 (중복 방지)

  INSERT INTO PRDRSTNON (
      PRDNONKEY
    , PRDWORKKEY
    , PRDRSTKEY
    , LINECD
    , EQMCD
    , NONCD
    , NONSTIME
    , NONETIME
    , AUTOYN
    , REMARK
    , RTIME, REMP, RPRG)
  VALUES (
      _$PRDNONKEY
    , ''
    , ''
    , $LINECD
    , $EQMCD
    , $NONCD
    , $NONSTIME
    , ''
    , 'N'
    , $REMARK
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

-- ****************************************************************************
WHEN 'END_NON' THEN  -- 비가동 종료 (설비수리 EQMREP 연동은 하지 않음, 시작 때 비운 코드는 여기서 받음)

  IF $EQMCD = '' THEN
    CALL COMERR('생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $NONETIME = '' THEN
    CALL COMERR('비가동 종료시간을 입력하세요.');
    LEAVE PROC;
  END IF;

  -- SELECT INTO 는 행이 없으면 NOT FOUND 로 COMCALLC 가 롤백하므로 SET = (SELECT) 사용
  SET _$PRDNONKEY = (SELECT PRDRSTNON.PRDNONKEY
                       FROM PRDRSTNON
                       WHERE PRDRSTNON.EQMCD = $EQMCD
                         AND PRDRSTNON.NONETIME = ''
                         AND PRDRSTNON.PRDWORKKEY = ''
                       ORDER BY PRDRSTNON.NONSTIME DESC
                       LIMIT 1);

  IF IFNULL(_$PRDNONKEY, '') = '' THEN
    CALL COMERR('진행 중인 비가동이 없습니다.');
    LEAVE PROC;
  END IF;

--   IF (SELECT PRDRSTNON.AUTOYN FROM PRDRSTNON WHERE PRDRSTNON.PRDNONKEY = _$PRDNONKEY) = 'Y' THEN
--     CALL COMERR('자동생성 비가동은 수동처리 불가');
--     LEAVE PROC;
--   END IF;

  IF $NONETIME <= (SELECT PRDRSTNON.NONSTIME FROM PRDRSTNON WHERE PRDRSTNON.PRDNONKEY = _$PRDNONKEY) THEN
    CALL COMERR('비가동 종료시간이 시작시간보다 늦어야 합니다.');
    LEAVE PROC;
  END IF;

  -- 종료 때 고른 코드가 없으면 시작 때 저장된 코드를 쓰고, 둘 다 없으면 막음
  IF $NONCD = '' AND (SELECT PRDRSTNON.NONCD FROM PRDRSTNON WHERE PRDRSTNON.PRDNONKEY = _$PRDNONKEY) = '' THEN
    CALL COMERR('비가동코드를 선택하세요.');
    LEAVE PROC;
  END IF;

  UPDATE PRDRSTNON
  SET NONETIME = $NONETIME
    , NONCD = IF($NONCD = '', PRDRSTNON.NONCD, $NONCD)
    , REMARK = $REMARK
    , MTIME = CALLTIME()
    , MEMP = CALLEMP()
    , MPRG = CALLPRG()
  WHERE PRDRSTNON.PRDNONKEY = _$PRDNONKEY;

-- ****************************************************************************
-- 설비 일상점검 (TAL0001_R05 참고, 설비는 선택한 라인에 매칭된 설비 MSTEQM_MATCH)
-- ****************************************************************************
WHEN 'LIST_FANO' THEN  -- 라인 설비 목록

  IF $LINECD = '' OR $PRCCD = '' OR $EQMCD = '' THEN
    CALL COMERR('생산작업장, 생산공정, 생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT
      MSTEQM.FANO
    , MSTEQM.EQMNM
  FROM MSTEQM_MATCH
  INNER JOIN MSTEQM
    ON MSTEQM.FANO = MSTEQM_MATCH.FANO
  WHERE MSTEQM_MATCH.EQMCD = $EQMCD
    AND MSTEQM.FACTORYCD = '07' -- 2공장
    AND MSTEQM.USEYN = 'Y'
  ORDER BY MSTEQM_MATCH.SEQ, MSTEQM.FANO
  ;

-- ****************************************************************************
END CASE;
-- ****************************************************************************
END