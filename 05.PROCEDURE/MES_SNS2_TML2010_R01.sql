CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TML2010_R01(
-- *****************************************************************************
-- Comment: 생산실적등록 (현장)
-- Create: 2026-10-26 신정수
-- Modify: 2026-11-19 16:36 신정수 공정이동표 발행 팝업: 실적로트 조회(LIST_MOVE), 잔량 자재로트(LIST_REMAIN),
--           PRINT_MOVE 에 $PRINTTP = 'REMAIN'(자재로트 현재고로 출력) 추가
--         2026-11-19 17:40 신정수 소라벨(해외 수출) 출력 PRINT_LABEL (MAGNA / 일반), LIST_MOVE 라벨번호
--         2026-11-23 투입창고: 투입로트 품목이 반제품(ITEMCG DM100150)이면 재공품창고(04S131_N), 아니면 자재투입창고(04S111_N)
--           SCAN_LOT·ADD_INPUT 은 품목유형으로, DEL_INPUT 은 투입 목록(PRDLINESCAN.WARECD)으로, PRINT_MOVE 잔량은 두 창고에서 찾음
--         2026-11-23 실적삭제: LIST_RST(최근 실적 어제·오늘), DEL_RST(실적로트 미사용일 때 IO_PRDRST 되돌림 + ERP D 송신)
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
  IN $LOTKEY VARCHAR(100),     -- 실적로트번호 (공정이동표 출력)
  IN $SDATE VARCHAR(10),       -- 공정이동표 발행: 생산일자 시작일
  IN $EDATE VARCHAR(10),       -- 공정이동표 발행: 생산일자 종료일
  IN $ALLYN VARCHAR(1),        -- 공정이동표 발행: 실적 조회 (Y 면 현재고 없는 로트까지)
  IN $PRINTTP VARCHAR(10),     -- 공정이동표 출력 구분 ('' 실적로트, REMAIN 자재로트 잔량)
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
  DECLARE _$LVL INT;
  DECLARE _$LABELTP VARCHAR(10);   -- 소라벨 양식 (MAGNA / NORMAL)
  DECLARE _$LABELKEY VARCHAR(20);  -- 라벨번호 (PRDRSTLOT.LABELKEY)
  DECLARE _$PRDRSTKEY VARCHAR(100);  -- 실적삭제
  DECLARE _$PRDWORKKEY VARCHAR(100);
  DECLARE _$PRDINSKEY VARCHAR(100);
  DECLARE _$GOODWARE VARCHAR(100);
  DECLARE _$BADWARE VARCHAR(100);
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

  -- 투입창고: 투입로트 품목이 반제품(DM100150)이면 재공품창고(04S131_N), 아니면 자재투입창고(04S111_N)  2026-11-23
  SET _$WARECD = IF(IFNULL((SELECT MSTITEM.ITEMCG
                              FROM COMLOT
                              INNER JOIN MSTITEM
                                ON MSTITEM.ITEMID = COMLOT.ITEMID
                              WHERE COMLOT.LOTKEY = $SCANLOT
                              LIMIT 1), '') = 'DM100150', '04S131_N', '04S111_N');

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

  -- 투입창고: 투입로트 품목이 반제품(DM100150)이면 재공품창고(04S131_N), 아니면 자재투입창고(04S111_N)  2026-11-23
  SET _$WARECD = IF(IFNULL((SELECT MSTITEM.ITEMCG
                              FROM COMLOT
                              INNER JOIN MSTITEM
                                ON MSTITEM.ITEMID = COMLOT.ITEMID
                              WHERE COMLOT.LOTKEY = $SCANLOT
                              LIMIT 1), '') = 'DM100150', '04S131_N', '04S111_N');

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

  -- 투입창고: 투입 목록(PRDLINESCAN)에 저장된 창고 (반제품 04S131_N / 그 외 04S111_N)  2026-11-23
  SET _$WARECD = IFNULL((SELECT PRDLINESCAN.WARECD
                           FROM PRDLINESCAN
                           WHERE PRDLINESCAN.LINECD = $LINECD
                             AND PRDLINESCAN.PRCCD = $PRCCD
                             AND PRDLINESCAN.EQMCD = $EQMCD
                             AND PRDLINESCAN.LOTKEY = $SCANLOT
                           LIMIT 1), '04S111_N');

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

  -- ERP 인터페이스 (비가동 종료 : I)
  CALL IO_ERP_INTERFACE('PRDRSTNON', _$PRDNONKEY, 'I');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

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
WHEN 'LIST_MOVE' THEN  -- 공정이동표 발행: 작업장·공정의 생산일자(작업일 PRDWORK.WORKDATE) 기간 실적로트 (양품·불량 현재고 포함)
  -- 생산일자는 작업시작일 기준이라 자정 넘어 등록한 야간 실적도 작업일로 잡힘 (RSTTIME 은 등록 시각)
  -- 양품재고 = 실적 입고창고(PRDRST.WARECD), 불량재고 = 불량창고(제품 04S230_N, 반제품 04S130_N) 의 같은 로트 현재고 (IO_PRDRST 와 같음)
  -- 실적 조회($ALLYN = 'Y')가 아니면 양품·불량 현재고가 하나라도 있는 로트만

  IF $LINECD = '' THEN
    CALL COMERR('생산작업장을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRCCD = '' THEN
    CALL COMERR('생산공정을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $SDATE = '' OR $EDATE = '' THEN
    CALL COMERR('생산일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  SELECT
      IFNULL(MSTEMP.EMPNM, PRDRST.EMPCD) AS EMPNM
    , PRDWORK.WORKDATE
    , CASE PRDINS.DNTP WHEN 'DAY' THEN '주간' WHEN 'NIGHT' THEN '야간' ELSE '' END AS DNTPNM  -- 작업지시 주야구분 (IO_PRDRST 가 DAY/NIGHT 로 저장)
    , PRDRSTLOT.LOTKEY
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , MSTITEM.ITEMCD
    , '' AS HEATNO       -- 아직 빈값 (PRINT_MOVE 와 같음)
    , PRDRSTLOT.LOTQTY AS GOODQTY
    , PRDRSTLOT.BADQTY
    , IFNULL(COMLOT1.LOTQTY, 0) AS GOODSTOCKQTY
    , IFNULL(COMLOT2.LOTQTY, 0) AS BADSTOCKQTY
    , PRDRST.PRDRSTKEY
    , PRDRSTLOT.LABELKEY -- 라벨번호 (소라벨)
  FROM PRDRST
  INNER JOIN PRDRSTLOT
    ON PRDRSTLOT.PRDRSTKEY = PRDRST.PRDRSTKEY
  INNER JOIN PRDWORK
    ON PRDWORK.PRDWORKKEY = PRDRST.PRDWORKKEY
  LEFT JOIN PRDINS
    ON PRDINS.PRDINSKEY = PRDWORK.PRDINSKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = PRDRST.ITEMID
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = PRDRST.EMPCD
  LEFT JOIN COMLOT AS COMLOT1  -- 양품 현재고
    ON COMLOT1.LOTKEY = PRDRSTLOT.LOTKEY
   AND COMLOT1.WARECD = PRDRST.WARECD
  LEFT JOIN COMLOT AS COMLOT2  -- 불량 현재고
    ON COMLOT2.LOTKEY = PRDRSTLOT.LOTKEY
   AND COMLOT2.WARECD = IF(MSTITEM.ITEMCG = 'DM100100', '04S230_N', '04S130_N')
  WHERE PRDRST.LINECD = $LINECD
    AND PRDRST.PRCCD = $PRCCD
    AND PRDWORK.WORKDATE BETWEEN $SDATE AND $EDATE
    AND ($ALLYN = 'Y' OR IFNULL(COMLOT1.LOTQTY, 0) > 0 OR IFNULL(COMLOT2.LOTQTY, 0) > 0)
  ORDER BY PRDWORK.WORKDATE DESC, PRDRST.RSTTIME DESC, PRDRSTLOT.LOTKEY DESC
  ;

-- ****************************************************************************
WHEN 'PRINT_LABEL' THEN  -- 소라벨(해외 수출) 출력 데이터: 실적로트 1건
  -- 양식: 이 품목의 매출처 단가(MSTITEM_SDV, 거래종료 제외)에 MAGNA(9054740899)가 있으면 MAGNA 라벨(TMLPRINT.PRD_2),  (2026-11-23 당월 수주 SALODR → MSTITEM_SDV)
  --       아니고 품목 PARTNO·INITCD 가 둘 다 있으면 일반 라벨(TMLPRINT.PRD_3), 둘 다 아니면 오류
  -- 일반 라벨인데 라벨번호가 없으면(라벨번호 생기기 전 실적) 여기서 채번해 저장
  -- 결과: LABELTP(MAGNA/NORMAL), PARTNO, ITEMNM, CUSTADDR, LOTKEY, LOTQTY(양품수량), PRDRSTKEY, PRDDATE(작업일), LABELKEY

  IF $LOTKEY = '' THEN
    CALL COMERR('실적로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT PRDRSTLOT.LOTKEY FROM PRDRSTLOT WHERE PRDRSTLOT.LOTKEY = $LOTKEY) THEN
    CALL COMERR(CONCAT('실적로트가 없습니다.', '\n- 로트번호: ', $LOTKEY));
    LEAVE PROC;
  END IF;

  SET _$ITEMID = (SELECT PRDRST.ITEMID
                    FROM PRDRSTLOT
                    INNER JOIN PRDRST
                      ON PRDRST.PRDRSTKEY = PRDRSTLOT.PRDRSTKEY
                    WHERE PRDRSTLOT.LOTKEY = $LOTKEY
                    LIMIT 1);

  IF EXISTS (SELECT MSTITEM_SDV.ITEMID
               FROM MSTITEM_SDV
               WHERE MSTITEM_SDV.ITEMID = _$ITEMID
                 AND MSTITEM_SDV.CUSTCD = '9054740899'  -- MAGNA
                 AND IFNULL(MSTITEM_SDV.ENDYN, '') <> 'Y') THEN
    SET _$LABELTP = 'MAGNA';
  ELSEIF EXISTS (SELECT MSTITEM.ITEMID
                   FROM MSTITEM
                   WHERE MSTITEM.ITEMID = _$ITEMID
                     AND IFNULL(MSTITEM.PARTNO, '') <> ''
                     AND IFNULL(MSTITEM.INITCD, '') <> '') THEN
    SET _$LABELTP = 'NORMAL';
  ELSE
    CALL COMERR(CONCAT('소라벨 출력 대상 품목이 아닙니다.'
                      , '\n(매출처 단가에 MAGNA 가 없고, 품목의 PART NO·INITIAL 이 없습니다.)'
                      , '\n- 품목코드: ', (SELECT MSTITEM.ITEMCD FROM MSTITEM WHERE MSTITEM.ITEMID = _$ITEMID)
                      , '\n- 로트번호: ', $LOTKEY
                      )
               );
    LEAVE PROC;
  END IF;

  -- 일반 라벨인데 라벨번호가 없으면 생산일자(작업일) 기준으로 채번
  IF _$LABELTP = 'NORMAL'
     AND (SELECT PRDRSTLOT.LABELKEY FROM PRDRSTLOT WHERE PRDRSTLOT.LOTKEY = $LOTKEY LIMIT 1) = '' THEN
    SET _$LABELKEY = (SELECT GETLABELKEY(PRDWORK.WORKDATE, MSTITEM.INITCD)
                        FROM PRDRSTLOT
                        INNER JOIN PRDRST
                          ON PRDRST.PRDRSTKEY = PRDRSTLOT.PRDRSTKEY
                        INNER JOIN PRDWORK
                          ON PRDWORK.PRDWORKKEY = PRDRST.PRDWORKKEY
                        INNER JOIN MSTITEM
                          ON MSTITEM.ITEMID = PRDRST.ITEMID
                        WHERE PRDRSTLOT.LOTKEY = $LOTKEY
                        LIMIT 1);

    IF IFNULL(_$LABELKEY, '') = '' THEN
      CALL COMERR(CONCAT('라벨번호를 만들지 못했습니다. 생산일자를 확인하세요.', '\n- 로트번호: ', $LOTKEY));
      LEAVE PROC;
    END IF;

    UPDATE PRDRSTLOT
    SET LABELKEY = _$LABELKEY
      , MTIME = CALLTIME()
      , MEMP = CALLEMP()
      , MPRG = CALLPRG()
    WHERE PRDRSTLOT.LOTKEY = $LOTKEY
      AND PRDRSTLOT.LABELKEY = '';
  END IF;

  SELECT
      _$LABELTP AS LABELTP
    , IFNULL(MSTITEM.PARTNO, '') AS PARTNO
    , MSTITEM.ITEMNM
    , IFNULL((SELECT MSTCUST.CUSTADDR2  -- 매출처 단가(MSTITEM_SDV) 거래처 주소, 거래종료 제외·기본업체 우선·최근 적용
                FROM MSTITEM_SDV
                INNER JOIN MSTCUST
                  ON MSTCUST.CUSTCD = MSTITEM_SDV.CUSTCD
                WHERE MSTITEM_SDV.ITEMID = PRDRST.ITEMID
                  AND IFNULL(MSTITEM_SDV.ENDYN, '') <> 'Y'
                ORDER BY IF(MSTITEM_SDV.MAINYN = 'Y', 0, 1), MSTITEM_SDV.SDT DESC
                LIMIT 1), '') AS CUSTADDR
    , PRDRSTLOT.LOTKEY
    , FORMAT(PRDRSTLOT.LOTQTY, 0) AS LOTQTY
    , PRDRSTLOT.PRDRSTKEY
    , PRDWORK.WORKDATE AS PRDDATE
    , PRDRSTLOT.LABELKEY
  FROM PRDRSTLOT
  INNER JOIN PRDRST
    ON PRDRST.PRDRSTKEY = PRDRSTLOT.PRDRSTKEY
  INNER JOIN PRDWORK
    ON PRDWORK.PRDWORKKEY = PRDRST.PRDWORKKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = PRDRST.ITEMID
  WHERE PRDRSTLOT.LOTKEY = $LOTKEY
  LIMIT 1
  ;

-- ****************************************************************************
WHEN 'LIST_REMAIN' THEN  -- 공정이동표 잔량발행: 실적로트가 사용한 자재로트 중 현재고가 남은 것

  IF $LOTKEY = '' THEN
    CALL COMERR('실적로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  SELECT
      PRDRSTUSE.USELOTKEY AS LOTKEY
    , MAX(COMLOT.LOTQTY) AS LOTQTY
  FROM PRDRSTLOT
  INNER JOIN PRDRSTUSE
    ON PRDRSTUSE.PRDRSTKEY = PRDRSTLOT.PRDRSTKEY
  INNER JOIN COMLOT
    ON COMLOT.LOTKEY = PRDRSTUSE.USELOTKEY
   AND COMLOT.WARECD = PRDRSTUSE.USEWARECD
  WHERE PRDRSTLOT.LOTKEY = $LOTKEY
    AND COMLOT.LOTQTY > 0
  GROUP BY PRDRSTUSE.USELOTKEY
  ORDER BY PRDRSTUSE.USELOTKEY
  ;

-- ****************************************************************************
-- 공정이동표 (작업완료 후 양품로트·불량로트 각 1장, 양식 TMLPRINT.PRD_1)
--   $PRINTTP = 'REMAIN' 이면 자재투입창고(04S111_N)·재공품창고(04S131_N, 반제품) 자재로트의 현재고로 출력 (공정이동표 발행 팝업의 잔량발행)
-- ****************************************************************************
WHEN 'PRINT_MOVE' THEN  -- 실적로트 공정이동표

  IF $LOTKEY = '' THEN
    CALL COMERR('실적로트번호가 없습니다.');
    LEAVE PROC;
  END IF;

  IF $PRINTTP = 'REMAIN' THEN
    IF NOT EXISTS (SELECT COMLOT.LOTKEY FROM COMLOT WHERE COMLOT.LOTKEY = $LOTKEY AND COMLOT.WARECD IN ('04S111_N', '04S131_N')) THEN
      CALL COMERR(CONCAT('자재투입창고·재공품창고에 없는 로트번호입니다.', '\n- 로트번호: ', $LOTKEY));
      LEAVE PROC;
    END IF;

    -- 0. 자재로트 품목·현재고 (이 로트를 만든 사내 실적이 있으면 그 생산정보, 없으면 빈값)
    SELECT
        MSTITEM.ITEMCD
      , MSTITEM.ITEMNM
      , MSTITEM.ITEMSPEC
      , '' AS HEATNO
      , '' AS HEATLOTKEY
      , IFNULL(PRDWORK.WORKDATE, IFNULL(COMLOT.PRDDATE, '')) AS PRDDATE
      , IFNULL(MSTEMP.EMPNM, IFNULL(PRDRST.EMPCD, '')) AS EMPNM
      , IFNULL(LEFT(PRDRST.RSTTIME, 16), '') AS RSTTIME
      , COMLOT.LOTKEY
      , IFNULL(MSTLINE.LINENM, IFNULL(PRDRST.LINECD, '')) AS LINENM
      , IFNULL(MSTPRC.PRCNM, '') AS PRCNM
      , IFNULL(MSTLINE_EQM.EQMNM, '') AS EQMNM
      , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
      , FORMAT(COMLOT.LOTQTY, 0) AS GOODQTY
      , '0' AS BADQTY
      , '' AS BADTPNM
      , IFNULL((SELECT MSTEMP.EMPNM FROM MSTEMP WHERE MSTEMP.EMPCD = CALLEMP() LIMIT 1), CALLEMP()) AS PRINTEMPNM
      , CALLTIME() AS PRINTTIME
    FROM COMLOT
    INNER JOIN MSTITEM
      ON MSTITEM.ITEMID = COMLOT.ITEMID
    LEFT JOIN PRDRST
      ON PRDRST.PRDRSTKEY = (SELECT PRDRSTLOT.PRDRSTKEY FROM PRDRSTLOT WHERE PRDRSTLOT.LOTKEY = COMLOT.LOTKEY LIMIT 1)
    LEFT JOIN PRDWORK
      ON PRDWORK.PRDWORKKEY = PRDRST.PRDWORKKEY
    LEFT JOIN MSTEMP
      ON MSTEMP.EMPCD = PRDRST.EMPCD
    LEFT JOIN MSTLINE
      ON MSTLINE.LINECD = PRDRST.LINECD
    LEFT JOIN MSTPRC
      ON MSTPRC.PRCCD = IFNULL(PRDRST.PRCCD, COMLOT.PRCCD)
    LEFT JOIN MSTLINE_EQM
      ON MSTLINE_EQM.EQMCD = PRDRST.EQMCD
    WHERE COMLOT.LOTKEY = $LOTKEY
      AND COMLOT.WARECD IN ('04S111_N', '04S131_N')
    ORDER BY COMLOT.LOTQTY DESC
    LIMIT 1
    ;
  ELSE
  -- 0. 생산품·생산정보·생산로트 (양품수량·불량수량, 불량 대분류는 불량코드가 여러 개면 모두)
  SELECT
      MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , '' AS HEATNO       -- 아직 빈값 (2026-11-06 사용자 지시)
    , '' AS HEATLOTKEY
    , IFNULL(PRDWORK.WORKDATE, '') AS PRDDATE
    , IFNULL(MSTEMP.EMPNM, PRDRST.EMPCD) AS EMPNM
    , LEFT(PRDRST.RSTTIME, 16) AS RSTTIME
    , PRDRSTLOT.LOTKEY
    , IFNULL(MSTLINE.LINENM, PRDRST.LINECD) AS LINENM
    , IFNULL(MSTPRC.PRCNM, PRDRST.PRCCD) AS PRCNM
    , IFNULL(MSTLINE_EQM.EQMNM, '') AS EQMNM
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , FORMAT(PRDRSTLOT.LOTQTY, 0) AS GOODQTY
    , FORMAT(PRDRSTLOT.BADQTY, 0) AS BADQTY
    , IFNULL((SELECT GROUP_CONCAT(DISTINCT GPCD('QM210', MSTBAD.BADTP1) ORDER BY MSTBAD.BADTP1 SEPARATOR ', ')
                FROM PRDRSTBAD
                INNER JOIN MSTBAD
                  ON MSTBAD.BADCD = PRDRSTBAD.BADCD
                WHERE PRDRSTBAD.PRDRSTKEY = PRDRST.PRDRSTKEY), '') AS BADTPNM
    , IFNULL((SELECT MSTEMP.EMPNM FROM MSTEMP WHERE MSTEMP.EMPCD = CALLEMP() LIMIT 1), CALLEMP()) AS PRINTEMPNM
    , CALLTIME() AS PRINTTIME
  FROM PRDRSTLOT
  INNER JOIN PRDRST
    ON PRDRST.PRDRSTKEY = PRDRSTLOT.PRDRSTKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = PRDRST.ITEMID
  LEFT JOIN PRDWORK
    ON PRDWORK.PRDWORKKEY = PRDRST.PRDWORKKEY
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = PRDRST.EMPCD
  LEFT JOIN MSTLINE
    ON MSTLINE.LINECD = PRDRST.LINECD
  LEFT JOIN MSTPRC
    ON MSTPRC.PRCCD = PRDRST.PRCCD
  LEFT JOIN MSTLINE_EQM
    ON MSTLINE_EQM.EQMCD = PRDRST.EQMCD
  WHERE PRDRSTLOT.LOTKEY = $LOTKEY
  LIMIT 1
  ;
  END IF;

  -- 1. 로트추적: 현공정 생산로트부터 투입로트를 거슬러 원소재까지
  --    사내 실적(PRDRSTLOT → PRDRSTUSE), 외주 실적(OSCRSTLOT → OSCRSTUSE), 둘 다 없으면 원소재
  --    투입로트가 여러 개면 모두 표시 (같은 단계 안은 로트번호 순)
  DROP TABLE IF EXISTS TEMP_TRACE;
  CREATE TEMPORARY TABLE TEMP_TRACE (
    SEQ    INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    LVL    INT NOT NULL,
    LOTKEY VARCHAR(100) NOT NULL,
    RSTTP  VARCHAR(1) NOT NULL,     -- P 사내, O 외주, '' 원소재
    RSTKEY VARCHAR(100) NOT NULL
  );

  DROP TABLE IF EXISTS TEMP_CUR;
  CREATE TEMPORARY TABLE TEMP_CUR (
    LOTKEY VARCHAR(100) NOT NULL,
    RSTTP  VARCHAR(1) NOT NULL,
    RSTKEY VARCHAR(100) NOT NULL
  );

  DROP TABLE IF EXISTS TEMP_NEXT;
  CREATE TEMPORARY TABLE TEMP_NEXT (
    LOTKEY VARCHAR(100) NOT NULL
  );

  -- 시작 로트를 만든 실적 (사내 → 외주 → 원소재 순, 잔량발행 자재로트는 원소재일 수 있음)
  INSERT INTO TEMP_CUR (LOTKEY, RSTTP, RSTKEY)
  SELECT
      $LOTKEY
    , IF(STARTLOT.PRDRSTKEY <> '', 'P', IF(STARTLOT.OSCRSTKEY <> '', 'O', ''))
    , IF(STARTLOT.PRDRSTKEY <> '', STARTLOT.PRDRSTKEY, STARTLOT.OSCRSTKEY)
  FROM (SELECT
            IFNULL((SELECT PRDRSTLOT.PRDRSTKEY FROM PRDRSTLOT WHERE PRDRSTLOT.LOTKEY = $LOTKEY LIMIT 1), '') AS PRDRSTKEY
          , IFNULL((SELECT OSCRSTLOT.OSCRSTKEY FROM OSCRSTLOT WHERE OSCRSTLOT.LOTKEY = $LOTKEY LIMIT 1), '') AS OSCRSTKEY
       ) AS STARTLOT;

  SET _$LVL = 0;
  WHILE _$LVL < 30 AND EXISTS (SELECT TEMP_CUR.LOTKEY FROM TEMP_CUR) DO  -- 30단계 넘으면 끊음 (잘못된 순환 방지)
    INSERT INTO TEMP_TRACE (LVL, LOTKEY, RSTTP, RSTKEY)
    SELECT _$LVL, TEMP_CUR.LOTKEY, TEMP_CUR.RSTTP, TEMP_CUR.RSTKEY
    FROM TEMP_CUR
    ORDER BY TEMP_CUR.LOTKEY;

    -- 이번 단계 로트를 만든 실적의 투입로트
    DELETE FROM TEMP_NEXT;

    INSERT INTO TEMP_NEXT (LOTKEY)
    SELECT PRDRSTUSE.USELOTKEY
    FROM PRDRSTUSE
    INNER JOIN TEMP_CUR
      ON TEMP_CUR.RSTTP = 'P'
     AND TEMP_CUR.RSTKEY = PRDRSTUSE.PRDRSTKEY;

    INSERT INTO TEMP_NEXT (LOTKEY)
    SELECT OSCRSTUSE.USELOTKEY
    FROM OSCRSTUSE
    INNER JOIN TEMP_CUR
      ON TEMP_CUR.RSTTP = 'O'
     AND TEMP_CUR.RSTKEY = OSCRSTUSE.OSCRSTKEY;

    -- 다음 단계: 투입로트마다 그 로트를 만든 실적 (사내 → 외주 → 원소재 순으로 찾음)
    DELETE FROM TEMP_CUR;

    INSERT INTO TEMP_CUR (LOTKEY, RSTTP, RSTKEY)
    SELECT
        NEXTLOT.LOTKEY
      , IF(NEXTLOT.PRDRSTKEY <> '', 'P', IF(NEXTLOT.OSCRSTKEY <> '', 'O', ''))
      , IF(NEXTLOT.PRDRSTKEY <> '', NEXTLOT.PRDRSTKEY, NEXTLOT.OSCRSTKEY)
    FROM (SELECT DISTINCT
              TEMP_NEXT.LOTKEY
            , IFNULL((SELECT PRDRSTLOT.PRDRSTKEY FROM PRDRSTLOT WHERE PRDRSTLOT.LOTKEY = TEMP_NEXT.LOTKEY LIMIT 1), '') AS PRDRSTKEY
            , IFNULL((SELECT OSCRSTLOT.OSCRSTKEY FROM OSCRSTLOT WHERE OSCRSTLOT.LOTKEY = TEMP_NEXT.LOTKEY LIMIT 1), '') AS OSCRSTKEY
          FROM TEMP_NEXT) AS NEXTLOT;

    SET _$LVL = _$LVL + 1;
  END WHILE;

  -- 품번, 작업장(사내 = 작업장명, 외주 = 외주처명), 공정(사내 = 실적공정, 외주 = 로트의 공정), 원소재는 품번·로트번호만
  SELECT
      TEMP_TRACE.SEQ AS NO
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , CASE
        WHEN TEMP_TRACE.RSTTP = 'P' THEN IFNULL(MSTLINE.LINENM, PRDRST.LINECD)
        WHEN TEMP_TRACE.RSTTP = 'O' THEN IFNULL(MSTCUST.CUSTNM, OSCRST.CUSTCD)
      ELSE '' END AS LINENM
    , IF(TEMP_TRACE.RSTTP = '', '', IFNULL(MSTPRC.PRCNM, '')) AS PRCNM
    , TEMP_TRACE.LOTKEY
  FROM TEMP_TRACE
  LEFT JOIN PRDRST
    ON TEMP_TRACE.RSTTP = 'P'
   AND PRDRST.PRDRSTKEY = TEMP_TRACE.RSTKEY
  LEFT JOIN OSCRST
    ON TEMP_TRACE.RSTTP = 'O'
   AND OSCRST.OSCRSTKEY = TEMP_TRACE.RSTKEY
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = COALESCE(PRDRST.ITEMID, OSCRST.ITEMID, (SELECT COMLOT.ITEMID FROM COMLOT WHERE COMLOT.LOTKEY = TEMP_TRACE.LOTKEY LIMIT 1))
  LEFT JOIN MSTLINE
    ON MSTLINE.LINECD = PRDRST.LINECD
  LEFT JOIN MSTCUST
    ON MSTCUST.CUSTCD = OSCRST.CUSTCD
  LEFT JOIN MSTPRC
    ON MSTPRC.PRCCD = IF(TEMP_TRACE.RSTTP = 'P', PRDRST.PRCCD, (SELECT COMLOT.PRCCD FROM COMLOT WHERE COMLOT.LOTKEY = TEMP_TRACE.LOTKEY LIMIT 1))
  ORDER BY TEMP_TRACE.SEQ
  ;

  DROP TABLE IF EXISTS TEMP_TRACE;
  DROP TABLE IF EXISTS TEMP_CUR;
  DROP TABLE IF EXISTS TEMP_NEXT;

-- ****************************************************************************
WHEN 'LIST_RST' THEN  -- 실적삭제 팝업: 이 작업장·공정·라인의 최근 실적 (작업일 어제·오늘)  2026-11-23

  IF $LINECD = '' OR $PRCCD = '' OR $EQMCD = '' THEN
    CALL COMERR('생산작업장, 생산공정, 생산라인을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT
      PRDRST.PRDRSTKEY
    , PRDWORK.WORKDATE
    , CASE PRDINS.DNTP WHEN 'DAY' THEN '주간' WHEN 'NIGHT' THEN '야간' ELSE '' END AS DNTPNM
    , LEFT(PRDRST.RSTTIME, 16) AS RSTTIME
    , PRDRSTLOT.LOTKEY
    , MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , PRDRST.PRODQTY
    , PRDRST.GOODQTY
    , PRDRST.BADQTY
    , IFNULL(MSTEMP.EMPNM, PRDRST.EMPCD) AS EMPNM
  FROM PRDRST
  INNER JOIN PRDRSTLOT
    ON PRDRSTLOT.PRDRSTKEY = PRDRST.PRDRSTKEY
  INNER JOIN PRDWORK
    ON PRDWORK.PRDWORKKEY = PRDRST.PRDWORKKEY
  LEFT JOIN PRDINS
    ON PRDINS.PRDINSKEY = PRDWORK.PRDINSKEY
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = PRDRST.ITEMID
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = PRDRST.EMPCD
  WHERE PRDRST.LINECD = $LINECD
    AND PRDRST.PRCCD = $PRCCD
    AND PRDRST.EQMCD = $EQMCD
    AND PRDWORK.WORKDATE >= DATE_FORMAT(DATE_SUB(GETDATE(), INTERVAL 1 DAY), '%Y-%m-%d')
  ORDER BY PRDRST.RSTTIME DESC
  ;

-- ****************************************************************************
WHEN 'DEL_RST' THEN  -- 실적삭제 (실적로트 = $LOTKEY). 실적로트(양품·불량)를 아직 쓰지 않았을 때만  2026-11-23
  -- IO_PRDRST 가 만든 것을 되돌림: 투입로트 재고 원복, 자재사용 출고, 실적로트 입고·현재고, 실적·작업이력·작업지시 삭제
  -- ERP 에 생산실적·작업지시 삭제(D) 송신 (ERP 마감된 실적이면 IO_ERP_INTERFACE 가 막음). 라인 비가동(PRDRSTNON)은 그대로 둠

  IF IFNULL($LOTKEY, '') = '' THEN
    CALL COMERR('삭제할 실적을 선택하세요.');
    LEAVE PROC;
  END IF;

  SET _$PRDRSTKEY = (SELECT PRDRSTLOT.PRDRSTKEY FROM PRDRSTLOT WHERE PRDRSTLOT.LOTKEY = $LOTKEY LIMIT 1);

  IF _$PRDRSTKEY IS NULL OR NOT EXISTS (SELECT PRDRST.PRDRSTKEY FROM PRDRST WHERE PRDRST.PRDRSTKEY = _$PRDRSTKEY) THEN
    CALL COMERR(CONCAT('생산실적이 없습니다.', '\n- 실적로트: ', $LOTKEY));
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT PRDRST.PRDRSTKEY FROM PRDRST
                   WHERE PRDRST.PRDRSTKEY = _$PRDRSTKEY
                     AND PRDRST.LINECD = $LINECD
                     AND PRDRST.PRCCD = $PRCCD) THEN
    CALL COMERR('선택한 작업장·공정의 실적이 아닙니다.');
    LEAVE PROC;
  END IF;

  SET _$PRDWORKKEY = (SELECT PRDRST.PRDWORKKEY FROM PRDRST WHERE PRDRST.PRDRSTKEY = _$PRDRSTKEY);
  SET _$PRDINSKEY = (SELECT PRDWORK.PRDINSKEY FROM PRDWORK WHERE PRDWORK.PRDWORKKEY = _$PRDWORKKEY);
  SET _$GOODWARE = (SELECT PRDRST.WARECD FROM PRDRST WHERE PRDRST.PRDRSTKEY = _$PRDRSTKEY);
  SET _$BADWARE = (SELECT IF(MSTITEM.ITEMCG = 'DM100100', '04S230_N', '04S130_N')   -- 불량창고 (IO_PRDRST 와 같음)
                     FROM PRDRST
                     INNER JOIN MSTITEM ON MSTITEM.ITEMID = PRDRST.ITEMID
                     WHERE PRDRST.PRDRSTKEY = _$PRDRSTKEY);

  -- 실적로트를 이동·투입·출고했으면 삭제 불가 (출고 이력이 있거나, 현재고가 생산수량과 다르거나, 다른 창고에 있음)
  IF EXISTS (SELECT COMOUTLOT.LOTKEY FROM COMOUTLOT WHERE COMOUTLOT.LOTKEY = $LOTKEY)
     OR EXISTS (SELECT COMLOT.LOTKEY FROM COMLOT
                  WHERE COMLOT.LOTKEY = $LOTKEY
                    AND (COMLOT.WARECD NOT IN (_$GOODWARE, _$BADWARE) OR COMLOT.LOTQTY <> COMLOT.CRTQTY))
     OR ((SELECT PRDRST.GOODQTY FROM PRDRST WHERE PRDRST.PRDRSTKEY = _$PRDRSTKEY) > 0
         AND NOT EXISTS (SELECT COMLOT.LOTKEY FROM COMLOT WHERE COMLOT.LOTKEY = $LOTKEY AND COMLOT.WARECD = _$GOODWARE))
     OR ((SELECT PRDRST.BADQTY FROM PRDRST WHERE PRDRST.PRDRSTKEY = _$PRDRSTKEY) > 0
         AND NOT EXISTS (SELECT COMLOT.LOTKEY FROM COMLOT WHERE COMLOT.LOTKEY = $LOTKEY AND COMLOT.WARECD = _$BADWARE)) THEN
    CALL COMERR(CONCAT('실적로트를 이미 사용(이동·투입·출고)하여 삭제할 수 없습니다.', '\n- 실적로트: ', $LOTKEY));
    LEAVE PROC;
  END IF;

  -- ERP 삭제 송신 (지우기 전에, 생산실적 → 작업지시 순서)
  CALL IO_ERP_INTERFACE('PRDRST', _$PRDRSTKEY, 'D');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  CALL IO_ERP_INTERFACE('PRDINS', _$PRDINSKEY, 'D');

  IF IFNULL(@ERRMSG, '') <> '' THEN
    LEAVE PROC;
  END IF;

  -- 1. 투입로트 재고 원복
  UPDATE COMLOT
   INNER JOIN PRDRSTUSE
      ON PRDRSTUSE.USELOTKEY = COMLOT.LOTKEY
     AND PRDRSTUSE.USEWARECD = COMLOT.WARECD
     SET COMLOT.LOTQTY = COMLOT.LOTQTY + PRDRSTUSE.USEQTY
       , COMLOT.MTIME = CALLTIME()
       , COMLOT.MEMP = CALLEMP()
       , COMLOT.MPRG = CALLPRG()
   WHERE PRDRSTUSE.PRDRSTKEY = _$PRDRSTKEY;

  -- 2. 자재사용 출고 이력
  DELETE FROM COMOUTLOT WHERE COMOUTLOT.OUTKEY IN (SELECT COMOUT.OUTKEY FROM COMOUT WHERE COMOUT.PRDRSTKEY = _$PRDRSTKEY);
  DELETE FROM COMOUT WHERE COMOUT.PRDRSTKEY = _$PRDRSTKEY;

  -- 3. 실적로트 입고 이력 + 현재고 (양품·불량)
  DELETE FROM COMINLOT WHERE COMINLOT.INKEY IN (SELECT COMIN.INKEY FROM COMIN WHERE COMIN.PRDRSTKEY = _$PRDRSTKEY);
  DELETE FROM COMIN WHERE COMIN.PRDRSTKEY = _$PRDRSTKEY;
  DELETE FROM COMLOT WHERE COMLOT.LOTKEY = $LOTKEY AND COMLOT.PRDRSTKEY = _$PRDRSTKEY;

  -- 4. 생산실적
  DELETE FROM PRDRSTUSE WHERE PRDRSTUSE.PRDRSTKEY = _$PRDRSTKEY;
  DELETE FROM PRDRSTBAD WHERE PRDRSTBAD.PRDRSTKEY = _$PRDRSTKEY;
  DELETE FROM PRDRSTLOT WHERE PRDRSTLOT.PRDRSTKEY = _$PRDRSTKEY;
  DELETE FROM PRDRST WHERE PRDRST.PRDRSTKEY = _$PRDRSTKEY;

  -- 5. 작업이력·작업지시
  DELETE FROM PRDWORK_EMP WHERE PRDWORK_EMP.PRDWORKKEY = _$PRDWORKKEY;
  DELETE FROM PRDWORK WHERE PRDWORK.PRDWORKKEY = _$PRDWORKKEY;
  DELETE FROM PRDINS WHERE PRDINS.PRDINSKEY = _$PRDINSKEY;

-- ****************************************************************************
END CASE;
-- ****************************************************************************
END