CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TQC1001_R02(
-- *****************************************************************************
-- Comment: 검사표준 관리 
-- Create: 2026-10-19 김영철
-- Modify: 2026-11-25 김영철 리비전 개정일(REGDATE)·작성자(REVEMPNM)·개정사유(REVREASON) 저장 - RENEW_REV 자동 채움, LIST_RPTREV 조회, UPDATE_REV(수정 저장) 추가
-- Modify: 2026-11-25 김영철 검사항목별 이미지(여러 장) - LIST_DETAIL_IMAGE / ADD_DETAIL_IMAGE / DEL_DETAIL_IMAGE 추가 (MSTRPTREV_DETAIL_IMAGE), 리비전 갱신 시 이미지 복사, 항목·리비전 삭제 시 이미지 삭제, 항목 조회에 IMGCNT 추가
-- Modify: 2026-11-26 김영철 UPDATE_MSTRPTREV_DETAIL 시료수는 1~10 정수만 저장 (출하검사 측정치 X1~X10)
-- Modify: 2026-11-26 자주검사 L/R 유무(MSTRPTREV_DETAIL.LRYN) 조회·저장, 리비전 갱신 시 복사. $LRYN_LIST 파라미터 추가
-- *****************************************************************************

  IN $STDTP             VARCHAR(100), -- 검사구분
  IN $ITEMID            VARCHAR(20),  -- 품목코드
  IN $ITEMCG            VARCHAR(20),  -- 품목구분
  IN $REVCD             VARCHAR(20),  -- 품목구분
  IN $FILEKEY           VARCHAR(100),
  IN $ORGDATE           VARCHAR(20),
  IN $STDCD             VARCHAR(20),
  IN $OLDREVCD          VARCHAR(20),

  IN $STDCD_LIST        MEDIUMTEXT,
  IN $STDPART_LIST      MEDIUMTEXT,
  IN $PRCDETAIL_LIST    MEDIUMTEXT,
  IN $FEATURE_LIST      MEDIUMTEXT,
  IN $STDNM_LIST        MEDIUMTEXT,
  IN $STDCHKTP_LIST     MEDIUMTEXT,
  IN $STDMACHINE_LIST   MEDIUMTEXT,
  IN $STDPOINT_LIST     MEDIUMTEXT,
  IN $STDVAL_LIST       MEDIUMTEXT,
  IN $STDRANGE_LIST     MEDIUMTEXT,
  IN $STDMINUS_LIST     MEDIUMTEXT,
  IN $STDPLUS_LIST      MEDIUMTEXT,
  IN $STDUNIT_LIST      MEDIUMTEXT,
  IN $STDCYCLE_LIST     MEDIUMTEXT,
  IN $STDJUDGE_LIST     TEXT,
  IN $REMARK_LIST       MEDIUMTEXT,
  IN $SORTNO_LIST       MEDIUMTEXT,
  IN $SAMPLESIZE_LIST   MEDIUMTEXT,
  IN $LRYN_LIST         MEDIUMTEXT,   -- L/R 유무 (Y/N, 자주검사) 2026-11-26

  IN $REGDATE           VARCHAR(50), -- 개정일 (리비전 저장 UPDATE_REV)
  IN $REVEMPNM          VARCHAR(50),   -- 작성자 (리비전 저장 UPDATE_REV)
  IN $REVREASON         VARCHAR(1000), -- 개정사유 (리비전 저장 UPDATE_REV)
  IN $STDPART           VARCHAR(100),  -- 세부항목 (항목 이미지)
  IN $PRCDETAIL         VARCHAR(100),  -- 세부공정 (항목 이미지)
  IN $IMGNO             VARCHAR(20),   -- 이미지 순번 (항목 이미지 삭제)
  IN $REVNUM            VARCHAR(20),
  IN $SDATE             VARCHAR(50),
  IN $EDATE             VARCHAR(50),
  IN $DEVKEY            VARCHAR(100),

-- *****************************************************************************  
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC:  BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC  
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************  

  DECLARE _$REVNUM  VARCHAR(100);
  DECLARE _$REVCD   VARCHAR(50);
  DECLARE _$REVCD_MAX VARCHAR(100);

  DECLARE _$STDCD VARCHAR(100);
  DECLARE _$STDPART VARCHAR(100);
  DECLARE _$STDNM VARCHAR(100);
  DECLARE _$STDCHKTP VARCHAR(100);
  DECLARE _$STDMACHINE VARCHAR(100);
  DECLARE _$STDPOINT VARCHAR(100);
  DECLARE _$STDVAL VARCHAR(100);
  DECLARE _$STDRANGE VARCHAR(100);
  DECLARE _$STDMINUS VARCHAR(100);
  DECLARE _$STDCYCLE  VARCHAR(20);
  DECLARE _$STDPLUS VARCHAR(100);
  DECLARE _$STDUNIT VARCHAR(100);
  DECLARE _$REMARK VARCHAR(100);
  DECLARE _$SORTNO VARCHAR(100);
  DECLARE _$SAMPLESIZE VARCHAR(100);
  DECLARE _$LRYN VARCHAR(10);
  DECLARE _$PRCDETAIL VARCHAR(100);
  DECLARE _$FEATURE VARCHAR(100);

  DECLARE _$ORGDATE VARCHAR(50);

  DECLARE _$STDJUDGE TEXT;

-- ****************************************************************************
CASE $CALLTYPE
-- * *************************************************************************** 
WHEN 'LIST_STDTP' THEN -- 검사구분 조회 (grid1 조회)

  SELECT
      COMTYPE.TPCD AS STDTP,
      COMTYPE.TPNM AS STDTPNM
  FROM COMTYPE
  WHERE COMTYPE.GPCD = 'STDTP'
    AND COMTYPE.USEYN = 'Y'
  ORDER BY COMTYPE.SORTNO;

-- * *************************************************************************** 
WHEN 'LIST_MSTITEM' THEN -- 품목 조회 (grid2 조회)

  IF $STDTP = '' THEN
    CALL COMERR('검사구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT 
    LIST_ITEM.EXISTSYN,
    LIST_ITEM.ITEMCG,
    CAST(LIST_ITEM.ITEMID AS CHAR) AS ITEMID,
    LIST_ITEM.ITEMCD,
    LIST_ITEM.ITEMNM
  FROM (
        SELECT
          IF(MSTRPTREV_ITEM.REVCD IS NOT NULL, 'Y', 'N') AS EXISTSYN,
          MSTITEM.ITEMCG,
          MSTITEM.ITEMID,
          MSTITEM.ITEMCD,
          MSTITEM.ITEMNM
        FROM MSTITEM
        INNER JOIN MSTITEM_FACTORY ON MSTITEM.ITEMID = MSTITEM_FACTORY.ITEMID
        LEFT JOIN MSTRPTREV_ITEM ON MSTRPTREV_ITEM.ITEMID = MSTITEM.ITEMID
        LEFT JOIN MSTRPTREV_HEADER ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_ITEM.REVCD
        WHERE MSTITEM.ENDYN = 'N'
          AND (CASE WHEN $STDTP = 'PRCTEST' THEN MSTITEM.PRCTEST_YN = 'Y'
                    WHEN $STDTP = 'OUTTEST' THEN MSTITEM.OUTTEST_YN = 'Y'                    
               ELSE 1=1 END
              )
          AND MSTITEM.ITEMID LIKE CONCAT('%', $ITEMID, '%')
          AND MSTITEM.ITEMCG LIKE CONCAT('%', $ITEMCG, '%')
       GROUP BY MSTITEM.ITEMID
       ) AS LIST_ITEM
  ORDER BY IF(LIST_ITEM.EXISTSYN = 'Y', 1, 2),
              LIST_ITEM.ITEMCG,
              LIST_ITEM.ITEMID;

-- -- * *************************************************************************** 
WHEN 'LIST_RPTREV' THEN -- 품목의 검사리비전 조회  (gird3)

  IF $STDTP = '' THEN
    CALL COMERR('검사구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $ITEMID = '' THEN
    CALL COMERR('품목을 선택하세요.');
    LEAVE PROC;
  END IF;
  
  SELECT 
    MSTRPTREV_HEADER.REVCD,
    MSTRPTREV_HEADER.REVNUM,
    MSTRPTREV_HEADER.USEYN,
    MSTRPTREV_HEADER.STDTP,
    MSTRPTREV_HEADER.REGDATE,    -- 개정일
    MSTRPTREV_HEADER.REVEMPNM,   -- 작성자
    MSTRPTREV_HEADER.REVREASON   -- 개정사유
  FROM MSTRPTREV_HEADER
  JOIN MSTRPTREV_ITEM ON MSTRPTREV_ITEM.REVCD = MSTRPTREV_HEADER.REVCD
  WHERE MSTRPTREV_HEADER.STDTP = $STDTP
    AND MSTRPTREV_ITEM.ITEMID = $ITEMID
  ORDER BY MSTRPTREV_HEADER.REVNUM DESC;

-- -- * *************************************************************************** 
WHEN 'LIST_MSTRPTREV_DETAIL' THEN -- 검사표준 리비전 디테일정보 조회 (검사항목 리스트 grid4)

  IF $REVCD = '' THEN
    CALL COMERR('리비전을 선택하세요.');
    LEAVE PROC;
  END IF;

  SELECT 
    REVCD,               -- 리비전
    STDCD,               -- 검사코드
    STDNM,               -- 검사항목
    STDPART,             -- 세부항목
    PRCDETAIL,           -- 설비중분류
    FEATURE,             -- 특성
    STDNM,               -- 검사항목
    STDCHKTP,            -- 검사방법
    STDMACHINE,          -- 측정기기
    STDPOINT,            -- 측정부위
    STDCYCLE,            -- 검사주기
    STDVAL,              -- 기준값
    STDUNIT,             -- 단위
    STDRANGE,            -- 범위
    STDMINUS,            -- 오차(-)
    STDPLUS,             -- 오차(+)
    STDJUDGE,            -- 판정기준
    SAMPLESIZE,          -- 시료수
    LRYN,                -- L/R 유무 (자주검사) 2026-11-26
    REMARK,              -- 비고
    SORTNO,
    (SELECT COUNT(*) FROM MSTRPTREV_DETAIL_IMAGE AS IMG
      WHERE IMG.REVCD = MSTRPTREV_DETAIL.REVCD
        AND IMG.STDCD = MSTRPTREV_DETAIL.STDCD
        AND IMG.STDPART = MSTRPTREV_DETAIL.STDPART
        AND IMG.PRCDETAIL = MSTRPTREV_DETAIL.PRCDETAIL) AS IMGCNT   -- 이미지 장수
  FROM MSTRPTREV_DETAIL
  WHERE REVCD = $REVCD
  ORDER BY SORTNO;

-- -- * *************************************************************************** 
WHEN 'DEL_REV' THEN -- 검사표준 리비전 헤더정보 삭제 (리비전 삭제 버튼)

  IF $REVCD = '' THEN
    CALL COMERR('리비전을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $STDTP = '' THEN
    CALL COMERR('검사구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $ITEMID = '' THEN
    CALL COMERR('품목을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT TQMRSTKEY FROM TQMRST WHERE REVCD = $REVCD) THEN
    CALL COMERR('해당 리비전으로 등록한 검사이력이 있어서 삭제할 수 없습니다.');
    LEAVE PROC;
  END IF;

  --  출하검사 삭제 
  DELETE FROM MSTRPTREV_HEADER WHERE REVCD = $REVCD;
  DELETE FROM MSTRPTREV_DETAIL WHERE REVCD = $REVCD;
  DELETE FROM MSTRPTREV_ITEM   WHERE REVCD = $REVCD;
  DELETE FROM MSTRPTREV_IMAGE   WHERE REVCD = $REVCD;
  DELETE FROM MSTRPTREV_DETAIL_IMAGE WHERE REVCD = $REVCD;

  IF NOT EXISTS (SELECT MSTRPTREV_HEADER.REVCD 
                   FROM MSTRPTREV_ITEM INNER JOIN MSTRPTREV_HEADER ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_ITEM.REVCD
                  WHERE MSTRPTREV_ITEM.ITEMID = $ITEMID
                    AND MSTRPTREV_HEADER.STDTP = $STDTP
                    AND MSTRPTREV_HEADER.USEYN = 'Y') THEN
    SET _$REVCD_MAX = IFNULL((SELECT MAX(MSTRPTREV_HEADER.REVCD)
                                FROM MSTRPTREV_ITEM INNER JOIN MSTRPTREV_HEADER ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_ITEM.REVCD
                               WHERE MSTRPTREV_ITEM.ITEMID = $ITEMID
                                 AND MSTRPTREV_HEADER.STDTP = $STDTP)
                                      , '');
    UPDATE MSTRPTREV_HEADER 
    SET USEYN = 'Y'
      , MTIME = CALLTIME()
      , MEMP = CALLEMP()
      , MPRG = CALLPRG()
    WHERE REVCD = _$REVCD_MAX;
  END IF;

-- * *************************************************************************** 
WHEN 'RENEW_REV' THEN -- 리비전 갱신  (리비전 갱신 버튼)

  IF $STDTP = '' THEN
    CALL COMERR('검사구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $ITEMID = '' THEN
      CALL COMERR('품목을 선택하세요.');
      LEAVE PROC;
  END IF;

  SET _$REVNUM = IFNULL((SELECT MAX(MSTRPTREV_HEADER.REVNUM) + 1
                           FROM MSTRPTREV_ITEM 
                     INNER JOIN MSTRPTREV_HEADER 
                             ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_ITEM.REVCD
                          WHERE MSTRPTREV_ITEM.ITEMID = $ITEMID
                            AND MSTRPTREV_HEADER.STDTP = $STDTP)
                            ,  1);

  SET _$REVCD = GETKEY('REVCD');

  SELECT IFNULL(MSTRPTREV_HEADER.ORGDATE, '')
    INTO _$ORGDATE
    FROM MSTRPTREV_HEADER 
    INNER JOIN MSTRPTREV_ITEM ON MSTRPTREV_ITEM.REVCD = MSTRPTREV_HEADER.REVCD
    WHERE MSTRPTREV_ITEM.ITEMID = $ITEMID
    AND MSTRPTREV_HEADER.STDTP = $STDTP
    AND MSTRPTREV_HEADER.USEYN = 'Y'; 

  -- 이전 리비전 사용중지 
  UPDATE MSTRPTREV_ITEM 
  INNER JOIN MSTRPTREV_HEADER 
          ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_ITEM.REVCD
    SET MSTRPTREV_HEADER.USEYN = 'N',
        MSTRPTREV_HEADER.MTIME = CALLTIME(),
        MSTRPTREV_HEADER.MEMP = CALLEMP(),
        MSTRPTREV_HEADER.MPRG = CALLPRG()
  WHERE MSTRPTREV_ITEM.ITEMID = $ITEMID
    AND MSTRPTREV_HEADER.STDTP = $STDTP
    AND MSTRPTREV_HEADER.USEYN = 'Y';       

  -- 신규 리비전 추가
  INSERT INTO MSTRPTREV_HEADER (
      REVCD
    , REVNUM
    , STDTP
    , USEYN
    , ORGDATE
    , REGDATE
    , REVEMPNM
    , REVREASON
    , RTIME, REMP, RPRG)
  VALUES (
      _$REVCD
    , _$REVNUM
    , $STDTP
    , 'Y'
    , IFNULL(_$ORGDATE, '')
    , GETDATE()
    , IFNULL(NULLIF(GPCD('EMPCD', CALLEMP()), ''), CALLEMP())   -- 작성자 : 로그인 사용자 (화면에서 수정 가능)
    , ''                                                         -- 개정사유 : 화면에서 입력
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

  INSERT INTO MSTRPTREV_ITEM (
      REVCD
    , ITEMID
    , RTIME, REMP, RPRG)
  VALUES(
      _$REVCD
    , $ITEMID
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

  INSERT INTO MSTRPTREV_DETAIL (
              REVCD, STDCD, STDNM, STDCHKTP, 
              STDPART, PRCDETAIL, FEATURE,
              STDMACHINE, STDPOINT, STDCYCLE, STDVAL, STDRANGE,
              STDMINUS, STDPLUS, STDUNIT, STDJUDGE, NO,
              SORTNO, SAMPLESIZE, LRYN, IMGFILEKEY, REMARK,
              RTIME, REMP, RPRG)
       SELECT _$REVCD, STDCD, STDNM, STDCHKTP,
              STDPART, PRCDETAIL, FEATURE,
              STDMACHINE, STDPOINT, STDCYCLE, STDVAL, STDRANGE,
              STDMINUS, STDPLUS, STDUNIT, STDJUDGE, NO,
              SORTNO, SAMPLESIZE, LRYN, IMGFILEKEY, REMARK,
              CALLTIME(), CALLEMP(), CALLPRG()
         FROM MSTRPTREV_DETAIL
        WHERE REVCD = $OLDREVCD;

  -- 검사항목 이미지 복사 (같은 파일을 새 리비전도 가리킴)
  INSERT INTO MSTRPTREV_DETAIL_IMAGE (
              REVCD, STDCD, STDPART, PRCDETAIL, NO, IMAGEKEY, REMARK,
              RTIME, REMP, RPRG)
       SELECT _$REVCD, STDCD, STDPART, PRCDETAIL, NO, IMAGEKEY, REMARK,
              CALLTIME(), CALLEMP(), CALLPRG()
         FROM MSTRPTREV_DETAIL_IMAGE
        WHERE REVCD = $OLDREVCD;

  -- 리비전코드 리턴 
  SELECT _$REVCD AS REVCD;

-- * ***************************************************************************
WHEN 'UPDATE_REV' THEN -- 리비전 개정일·작성자·개정사유 저장 (리비전 저장 버튼, 검사이력이 있어도 수정 가능)

  IF IFNULL($REVCD, '') = '' THEN
    CALL COMERR('리비전을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF IFNULL($REGDATE, '') = '' THEN
    CALL COMERR('개정일을 입력하세요.');
    LEAVE PROC;
  END IF;

  UPDATE MSTRPTREV_HEADER
     SET REGDATE   = LEFT($REGDATE, 10)
       , REVEMPNM  = IFNULL($REVEMPNM, '')
       , REVREASON = IFNULL($REVREASON, '')
       , MTIME = CALLTIME()
       , MEMP  = CALLEMP()
       , MPRG  = CALLPRG()
   WHERE REVCD = $REVCD;

-- -- * ***************************************************************************
WHEN 'LIST_STD' THEN -- 검사항목 조회  (추가(팝업) 버튼)

  IF $STDTP = '' THEN
    CALL COMERR('검사구분이 없습니다.');
    LEAVE PROC;
  END IF;
  
  IF EXISTS (SELECT TQMRSTKEY FROM TQMRST WHERE REVCD = $REVCD) THEN
    CALL COMERR('해당 리비전으로 등록한 검사이력이 있어서 추가할 수 없습니다.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT TQMRST.TQMRSTKEY  FROM MSTRPTREV_ITEM  LEFT JOIN TQMRST ON TQMRST.REVCD = MSTRPTREV_ITEM.REVCD  WHERE TQMRST.REVCD = $REVCD AND MSTRPTREV_ITEM.ITEMID = $ITEMID) THEN
    CALL COMERR('해당 리비전으로 등록한 검사이력이 있어서 추가할 수 없습니다.');
    LEAVE PROC;
  END IF;

  SELECT
      MSTSTD.STDCD
    , MSTSTD.STDNM
    , MSTSTD.STDCHKTP
    , MSTSTD.STDPOINT
    , MSTSTD.STDMACHINE
    , MSTSTD.STDUNIT
    , MSTSTD.STDRANGE
    , MSTSTD.STDJUDGE    
    , MSTSTD.REMARK
    , MSTSTD.STDCYCLE
    , MSTSTD.IMGFILEKEY AS FILEKEY
    , FILENAME(MSTSTD.IMGFILEKEY) AS FILENAME
    , FILEURL(MSTSTD.IMGFILEKEY) AS FILEURL
  FROM MSTSTD
  WHERE MSTSTD.STDTP = $STDTP
  ORDER BY MSTSTD.STDCD;

-- -- * *************************************************************************** 
WHEN 'UPDATE_MSTRPTREV_DETAIL' THEN -- 검사표준 리비전 디테일 저장 (검사항목리스트 저장 버튼)

  IF $REVCD = '' THEN
    CALL COMERR('리비전을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT TQMRSTKEY FROM TQMRST WHERE REVCD = $REVCD) THEN
    CALL COMERR('검사항목 리스트를 수정할 수 없습니다.\n - 원인 : 해당 리비전으로 검사이력 존재');
    LEAVE PROC;
  END IF;

  WHILE LENGTH($STDCD_LIST) > 0 DO
    CALL COMSPLIT($STDCD_LIST, _$STDCD);
    CALL COMSPLIT($STDNM_LIST, _$STDNM);

    CALL COMSPLIT($STDPART_LIST, _$STDPART);
    CALL COMSPLIT($PRCDETAIL_LIST, _$PRCDETAIL);
    CALL COMSPLIT($FEATURE_LIST, _$FEATURE);

    CALL COMSPLIT($STDCHKTP_LIST, _$STDCHKTP);
    CALL COMSPLIT($STDMACHINE_LIST, _$STDMACHINE);
    CALL COMSPLIT($STDPOINT_LIST, _$STDPOINT);
    CALL COMSPLIT($STDCYCLE_LIST, _$STDCYCLE);
    CALL COMSPLIT($STDVAL_LIST, _$STDVAL);
    CALL COMSPLIT($STDRANGE_LIST, _$STDRANGE);
    CALL COMSPLIT($STDMINUS_LIST, _$STDMINUS);
    CALL COMSPLIT($STDPLUS_LIST, _$STDPLUS);
    CALL COMSPLIT($STDUNIT_LIST, _$STDUNIT);
    CALL COMSPLIT($STDJUDGE_LIST, _$STDJUDGE);
    CALL COMSPLIT($REMARK_LIST, _$REMARK);
    CALL COMSPLIT($SORTNO_LIST, _$SORTNO);
    CALL COMSPLIT($SAMPLESIZE_LIST, _$SAMPLESIZE);
    CALL COMSPLIT($LRYN_LIST, _$LRYN);
    SET _$LRYN = IF(IFNULL(_$LRYN, '') = 'Y', 'Y', 'N');   -- 2026-11-26 L/R 유무 (안 넘어오면 N)

    IF _$STDCHKTP = '' THEN
      CALL COMERR('검사항목을 선택하세요.');
      LEAVE PROC;
    END IF;

    -- 시료수는 1~10 의 정수 (출하검사 등록 측정치 X1~X10)
    IF IFNULL(_$SAMPLESIZE, '') <> '' AND (CAST(_$SAMPLESIZE AS DECIMAL(20, 8)) < 1 OR CAST(_$SAMPLESIZE AS DECIMAL(20, 8)) > 10 OR CAST(_$SAMPLESIZE AS DECIMAL(20, 8)) <> FLOOR(CAST(_$SAMPLESIZE AS DECIMAL(20, 8)))) THEN
      CALL COMERR('시료수는 1~10 사이의 정수만 입력할 수 있습니다.');
      LEAVE PROC;
    END IF;

    IF EXISTS (
      SELECT 1 
        FROM MSTRPTREV_DETAIL 
        WHERE REVCD = $REVCD 
          AND STDCD = _$STDCD
          AND STDPART = _$STDPART
          AND PRCDETAIL = _$PRCDETAIL
        ) THEN
     
      UPDATE MSTRPTREV_DETAIL SET
        STDNM = _$STDNM
      , STDPART = _$STDPART
      , PRCDETAIL = _$PRCDETAIL
      , FEATURE = _$FEATURE
      , STDCHKTP = _$STDCHKTP
      , STDMACHINE = _$STDMACHINE
      , STDPOINT = _$STDPOINT
      , STDCYCLE = _$STDCYCLE
      , STDVAL = IF(_$STDVAL = '', 0, CAST(_$STDVAL AS DOUBLE))
      , STDRANGE = _$STDRANGE
      , STDMINUS = IF(_$STDMINUS = '', 0, CAST(_$STDMINUS AS DOUBLE))
      , STDPLUS = IF(_$STDPLUS = '', 0, CAST(_$STDPLUS AS DOUBLE))
      , STDUNIT = _$STDUNIT
      , STDJUDGE = _$STDJUDGE
      , REMARK = _$REMARK
      , SORTNO = _$SORTNO
      , SAMPLESIZE = IF(_$SAMPLESIZE = '', 0, _$SAMPLESIZE)
      , LRYN = _$LRYN
      , MTIME = CALLTIME()
      , MEMP = CALLEMP()
      , MPRG = CALLPRG()
      WHERE REVCD = $REVCD 
        AND STDCD = _$STDCD
        AND STDPART = _$STDPART
        AND PRCDETAIL = _$PRCDETAIL;

    ELSE 
    
      INSERT INTO MSTRPTREV_DETAIL (
          REVCD
        , STDCD
        , STDPART
        , PRCDETAIL
        , FEATURE
        , STDNM
        , STDCHKTP
        , STDMACHINE
        , STDPOINT
        , STDCYCLE
        , STDVAL
        , STDRANGE
        , STDMINUS
        , STDPLUS
        , STDUNIT
        , STDJUDGE
        , REMARK
        , SORTNO
        , SAMPLESIZE
        , LRYN
        , RTIME, REMP, RPRG
      )
      VALUES (
          $REVCD
        , _$STDCD
        , _$STDPART
        , _$PRCDETAIL
        , _$FEATURE
        , _$STDNM
        , _$STDCHKTP
        , _$STDMACHINE
        , _$STDPOINT
        , _$STDCYCLE
        , IF(_$STDVAL = '', 0, CAST(_$STDVAL AS DOUBLE))
        , _$STDRANGE
        , IF(_$STDMINUS = '', 0, CAST(_$STDMINUS AS DOUBLE))
        , IF(_$STDPLUS = '', 0, CAST(_$STDPLUS AS DOUBLE))
        , _$STDUNIT
        , _$STDJUDGE
        , _$REMARK
        , _$SORTNO
        , IF(_$SAMPLESIZE = '', 0, _$SAMPLESIZE)
        , _$LRYN
        , CALLTIME(), CALLEMP(), CALLPRG()
      );

    END IF;

  END WHILE;

-- -- * *************************************************************************** 
WHEN 'DELETE_MSTRPTREV_DETAIL' THEN -- 검사표준 리비전 디테일 삭제 (검사항목리스트 삭제 버튼)

  IF IFNULL($REVCD, '') = '' THEN
    CALL COMERR('리비전을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT TQMRSTKEY FROM TQMRST WHERE REVCD = $REVCD) THEN
    CALL COMERR('검사항목 리스트를 삭제할 수 없습니다.\n - 원인 : 해당 리비전으로 검사이력 존재');
    LEAVE PROC;
  END IF;

  WHILE LENGTH($STDCD_LIST) > 0 DO
    CALL COMSPLIT($STDCD_LIST, _$STDCD);
    CALL COMSPLIT($STDPART_LIST, _$STDPART);
    CALL COMSPLIT($PRCDETAIL_LIST, _$PRCDETAIL);
    CALL COMSPLIT($FEATURE_LIST, _$FEATURE);
    
    IF IFNULL(_$STDCD, '') = '' THEN
      CALL COMERR('검사항목을 추가하세요.');
      LEAVE PROC;
    END IF;

    DELETE FROM MSTRPTREV_DETAIL 
    WHERE REVCD = $REVCD 
      AND STDCD = _$STDCD
      AND STDPART = _$STDPART
      AND PRCDETAIL = _$PRCDETAIL;

    DELETE FROM MSTRPTREV_DETAIL_IMAGE
    WHERE REVCD = $REVCD
      AND STDCD = _$STDCD
      AND STDPART = _$STDPART
      AND PRCDETAIL = _$PRCDETAIL;

  END WHILE;

-- * ***************************************************************************
WHEN 'LIST_DETAIL_IMAGE' THEN -- 검사항목 이미지 조회 (이미지 팝업)

  SELECT
      NO
    , IMAGEKEY AS FILEKEY
    , FILENAME(IMAGEKEY) AS FILENAME
    , FILEURL(IMAGEKEY) AS FILEURL
    , REMARK
  FROM MSTRPTREV_DETAIL_IMAGE
  WHERE REVCD = $REVCD
    AND STDCD = $STDCD
    AND STDPART = IFNULL($STDPART, '')
    AND PRCDETAIL = IFNULL($PRCDETAIL, '')
  ORDER BY NO;

-- * ***************************************************************************
WHEN 'ADD_DETAIL_IMAGE' THEN -- 검사항목 이미지 추가 (파일 업로드 후 등록)

  IF IFNULL($FILEKEY, '') = '' THEN
    CALL COMERR('업로드된 파일이 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM MSTRPTREV_DETAIL
                  WHERE REVCD = $REVCD AND STDCD = $STDCD
                    AND STDPART = IFNULL($STDPART, '') AND PRCDETAIL = IFNULL($PRCDETAIL, '')) THEN
    CALL COMERR('저장된 검사항목이 아닙니다.\n먼저 검사항목을 저장한 뒤 이미지를 등록하세요.');
    LEAVE PROC;
  END IF;

  INSERT INTO MSTRPTREV_DETAIL_IMAGE (
      REVCD, STDCD, STDPART, PRCDETAIL, NO, IMAGEKEY, REMARK
    , RTIME, REMP, RPRG)
  VALUES (
      $REVCD, $STDCD, IFNULL($STDPART, ''), IFNULL($PRCDETAIL, '')
    , IFNULL((SELECT MAX(IMG.NO) FROM MSTRPTREV_DETAIL_IMAGE AS IMG
               WHERE IMG.REVCD = $REVCD AND IMG.STDCD = $STDCD
                 AND IMG.STDPART = IFNULL($STDPART, '') AND IMG.PRCDETAIL = IFNULL($PRCDETAIL, '')), 0) + 1
    , $FILEKEY, ''
    , CALLTIME(), CALLEMP(), CALLPRG()
  );

-- * ***************************************************************************
WHEN 'DEL_DETAIL_IMAGE' THEN -- 검사항목 이미지 삭제 (선택한 1장)

  IF IFNULL($IMGNO, '') = '' THEN
    CALL COMERR('삭제할 이미지를 선택하세요.');
    LEAVE PROC;
  END IF;

  DELETE FROM MSTRPTREV_DETAIL_IMAGE
  WHERE REVCD = $REVCD
    AND STDCD = $STDCD
    AND STDPART = IFNULL($STDPART, '')
    AND PRCDETAIL = IFNULL($PRCDETAIL, '')
    AND NO = $IMGNO;

-- -- * ***************************************************************************
WHEN 'LIST_MSTITEM_COPY' THEN -- 품목 조회 (복사(팝업) 버튼)

  IF $STDTP = '' THEN
    CALL COMERR('검사구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT TQMRSTKEY FROM TQMRST WHERE REVCD = $REVCD) THEN
    CALL COMERR('해당 리비전으로 등록한 검사이력이 있어서 복사할 수 없습니다.');
    LEAVE PROC;
  END IF;

  SELECT 
      LIST_ITEM.EXISTSYN,
      LIST_ITEM.ITEMCG,
      LIST_ITEM.ITEMID,
      LIST_ITEM.ITEMNM
    FROM (
          SELECT
            IF(MAX(MSTRPTREV_HEADER.REVCD) IS NOT NULL, 'Y', 'N') AS EXISTSYN,
            MSTITEM.ITEMCG,
            MSTITEM.ITEMID,
            MSTITEM.ITEMNM
          FROM MSTITEM
          LEFT JOIN MSTRPTREV_ITEM ON MSTRPTREV_ITEM.ITEMID = MSTITEM.ITEMID
          LEFT JOIN MSTRPTREV_HEADER ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_ITEM.REVCD
                                     AND MSTRPTREV_HEADER.STDTP = $STDTP
          WHERE MSTITEM.ENDYN = 'N'
            AND MSTITEM.PRCTEST_YN = 'Y'
            AND MSTITEM.ITEMID LIKE CONCAT('%', $ITEMID, '%')
            AND MSTITEM.ITEMCG LIKE CONCAT('%', $ITEMCG, '%')
            AND MSTRPTREV_HEADER.REVCD <> ''
         GROUP BY MSTITEM.ITEMID
          ) AS LIST_ITEM
    ORDER BY IF(LIST_ITEM.EXISTSYN = 'Y', 1, 2),
                LIST_ITEM.ITEMCG,
                LIST_ITEM.ITEMID;

-- ****************************************************************************
WHEN 'PRINT_REPORT' THEN

 -- 하단 그리드 부분
  SELECT 
    ROW_NUMBER() OVER (ORDER BY MSTRPTREV_DETAIL.SORTNO) AS SEQ, -- 순번
    MSTRPTREV_HEADER.REVCD,     -- 검사표준 리비전코드
    GPCD('STDMACHINE', MSTRPTREV_DETAIL.STDMACHINE) AS STDMACHINE, -- 측정기기
    CONCAT(SUBSTRING(MSTRPTREV_DETAIL.STDJUDGE, 1, 20), '\n', '\n', SUBSTRING(MSTRPTREV_DETAIL.STDJUDGE, 41, 20)) AS STDJUDGE,
    MSTRPTREV_DETAIL.STDCD,   -- 검사항목코드    
    GPCD('STDCYCLE', MSTRPTREV_DETAIL.STDCYCLE) AS STDCYCLE

  FROM MSTRPTREV_DETAIL
  JOIN MSTRPTREV_HEADER ON MSTRPTREV_HEADER.REVCD = MSTRPTREV_DETAIL.REVCD
  LEFT JOIN MSTRPTREV_ITEM  ON MSTRPTREV_ITEM.REVCD = MSTRPTREV_HEADER.REVCD

  WHERE MSTRPTREV_ITEM.ITEMID = $ITEMID -- 같은 품목
    AND MSTRPTREV_HEADER.STDTP = 'PRCTEST' -- 
--     AND MSTRPTREV_HEADER.USEYN = 'Y' -- 사용중인 리비전
    AND MSTRPTREV_HEADER.REVCD = $REVCD
  ORDER BY MSTRPTREV_DETAIL.SORTNO;

  SELECT 
  MSTRPTREV_HEADER.REVNUM AS REVNUM, -- 개정번호
  CONCAT('DUQ-', MSTITEM.CARMODEL, MSTITEM.REGNO) AS REVCD,  -- 등록번호
  MSTRPTREV_ITEM.ITEMID AS ITEMCD,     
  MSTITEM.CARMODEL,
  MSTITEM.ITEMNM,
  MSTITEM.PRCCD,
  MSTRPTREV_HEADER.ORGDATE AS OTIME,
  MSTRPTREV_HEADER.REGDATE AS NTIME,
  FILEURL(MSTRPTREV_IMAGE.IMAGEKEY) AS IMAGE -- 이미지 파일
  FROM MSTRPTREV_HEADER
  LEFT JOIN MSTRPTREV_ITEM ON MSTRPTREV_ITEM.REVCD = MSTRPTREV_HEADER.REVCD
  LEFT JOIN MSTRPTREV_IMAGE ON MSTRPTREV_IMAGE.REVCD = MSTRPTREV_HEADER.REVCD
  JOIN MSTITEM ON MSTITEM.ITEMID = MSTRPTREV_ITEM.ITEMID
  WHERE MSTRPTREV_HEADER.REVCD = $REVCD
    AND MSTRPTREV_ITEM.ITEMID = $ITEMID;

-- ******************************************************************************************************************
END CASE;  END