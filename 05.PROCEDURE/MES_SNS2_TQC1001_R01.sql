CREATE DEFINER = 'root'@'localhost'
PROCEDURE MES_SNS2.TQC1001_R01(
-- *****************************************************************************
-- Comment: 검사항목 관리
-- Create: 2025-07-16  이대규
-- Modify:
-- *****************************************************************************
  IN $STDTP     VARCHAR(100), -- 검사구분
  
  IN $STDCD       VARCHAR(100),   -- 검사항목코드
  IN $STDNM       VARCHAR(100),   -- 검사항목명
  IN $STDCHKTP    VARCHAR(100),   -- 검사방법
  IN $STDMACHINE  VARCHAR(100),   -- 측정기기
  IN $STDPOINT    VARCHAR(100),   -- 측정부위
  IN $STDRANGE    TEXT,           -- 범위
  IN $STDUNIT     VARCHAR(100),   -- 단위
  IN $STDJUDGE    VARCHAR(100),   -- 판정기준
  IN $REMARK      VARCHAR(1000),  -- 비고
  IN $IMGFILEKEY  VARCHAR(100),   -- 파일등록     
  IN $FILEKEY     VARCHAR(100),   -- 파일등록키
  IN $STDCYCLE    VARCHAR(20),     -- 검사주기
  IN $FILENAME    VARCHAR(100),
  IN $STDTP_LIST  MEDIUMTEXT,
  IN $STDCD_LIST  MEDIUMTEXT,
  IN $STDNM_LIST  MEDIUMTEXT,
  IN $STDCHKTP_LIST MEDIUMTEXT,
  IN $STDMACHINE_LIST MEDIUMTEXT,
  IN $STDPOINT_LIST MEDIUMTEXT,
  IN $STDCYCLE_LIST MEDIUMTEXT,
  IN $STDUNIT_LIST  MEDIUMTEXT,
  IN $STDRANGE_LIST MEDIUMTEXT,
  IN $STDJUDGE_LIST MEDIUMTEXT,
  IN $REMARK_LIST MEDIUMTEXT,
  IN $SDATE     VARCHAR(20),
  IN $EDATE     VARCHAR(20),
  IN $ITEMCD    VARCHAR(20),
  IN $DEVKEY    VARCHAR(100),

-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$STDCD VARCHAR(100);

  DECLARE _$STDTP VARCHAR(20);
  DECLARE _$STDNM VARCHAR(100);
  DECLARE _$STDCHKTP VARCHAR(20);
  DECLARE _$STDMACHINE  VARCHAR(20);
  DECLARE _$STDPOINT   VARCHAR(20);
  DECLARE _$STDCYCLE  VARCHAR(20);
  DECLARE _$STDUNIT   VARCHAR(20);
  DECLARE _$STDRANGE  VARCHAR(20);
  DECLARE _$STDJUDGE  VARCHAR(100);
  DECLARE _$REMARK    VARCHAR(100);

-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_MSTSTD' THEN  -- 검사항목 조회 

  SELECT 
    MSTSTD.STDTP,       -- 검사구분
    MSTSTD.STDCD,       -- 검사항목코드
    MSTSTD.STDNM,       -- 검사항목
    MSTSTD.STDCHKTP,    -- 검사방법
    MSTSTD.STDMACHINE,  -- 측정기기
    MSTSTD.STDPOINT,    -- 측정부위
    MSTSTD.STDCYCLE,    -- 검사주기
    MSTSTD.STDUNIT,     -- 단위
    MSTSTD.STDRANGE,    -- 검사범위
    MSTSTD.STDJUDGE,    -- 판정기준
    MSTSTD.REMARK,      -- 비고
    MSTSTD.IMGFILEKEY,
    FILENAME(MSTSTD.IMGFILEKEY) AS FILENAME,
    FILEURL(MSTSTD.IMGFILEKEY) AS FILEURL
  FROM MSTSTD
  LEFT JOIN COMTYPE
         ON COMTYPE.GPCD = 'STDTP'
        AND COMTYPE.TPCD = MSTSTD.STDTP
  WHERE MSTSTD.STDTP LIKE CONCAT($STDTP, '%')
    AND MSTSTD.STDNM LIKE CONCAT('%', $KEYWORD, '%')
    AND COMTYPE.TPCD <> '3DTEST'
  ORDER BY IFNULL(COMTYPE.SORTNO, 0) ASC, MSTSTD.RTIME;

-- ****************************************************************************
WHEN 'ADD_MSTSTD' THEN -- 검사항목 추가

  IF $STDTP = '' THEN
    CALL COMERR('검사구분을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $STDCHKTP = '' THEN
    CALL COMERR('검사방법을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $STDNM = '' THEN
    CALL COMERR('검사항목명을 입력하세요.');
    LEAVE PROC;
  END IF;

  -- 검사항목 코드 자동완성
  IF (SELECT COUNT(*) FROM MSTSTD) = 0 THEN
    SET _$STDCD = 1;
    ELSE
    SET _$STDCD = FORMAT((SELECT MAX(CAST(STDCD AS DOUBLE)) + 1 FROM MSTSTD), 0);
  END IF;

  INSERT INTO MSTSTD (
      STDTP
    , STDCD
    , STDNM
    , STDCHKTP
    , STDMACHINE
    , STDPOINT
    , STDRANGE
    , STDUNIT
    , STDJUDGE
    , STDCYCLE
    , IMGFILEKEY
    , REMARK
    , RTIME, REMP, RPRG
  )
  VALUES (
      $STDTP
    , _$STDCD
    , $STDNM
    , $STDCHKTP
    , $STDMACHINE
    , $STDPOINT
    , $STDRANGE
    , $STDUNIT
    , $STDJUDGE
    , $STDCYCLE
    , $IMGFILEKEY
    , $REMARK
    , CALLTIME(), CALLEMP(), CALLPRG()
  );
-- ****************************************************************************
WHEN 'UPDATE_MSTSTD' THEN -- 검사항목 수정


  WHILE LENGTH($STDCD_LIST) > 0 DO

    CALL COMSPLIT($STDCD_LIST, _$STDCD);
    CALL COMSPLIT($STDTP_LIST, _$STDTP);
    CALL COMSPLIT($STDNM_LIST, _$STDNM);
    CALL COMSPLIT($STDCHKTP_LIST, _$STDCHKTP);
    CALL COMSPLIT($STDMACHINE_LIST, _$STDMACHINE);

    CALL COMSPLIT($STDPOINT_LIST, _$STDPOINT);
    CALL COMSPLIT($STDCYCLE_LIST, _$STDCYCLE);
    CALL COMSPLIT($STDUNIT_LIST, _$STDUNIT);
    CALL COMSPLIT($STDRANGE_LIST, _$STDRANGE);

    CALL COMSPLIT($STDJUDGE_LIST, _$STDJUDGE);
    CALL COMSPLIT($REMARK_LIST, _$REMARK);

    IF _$STDTP = 'REGULARTEST' AND _$STDCD = ''  THEN  -- 3D 측정값(정기검사) 팝업창에서 그리드로 넘어오게 되면, 항목명만 끌고 오기때문에 STDCD를 따로 정해줘야함
 
        
        IF (SELECT COUNT(*) FROM MSTSTD) = 0 THEN
        SET _$STDCD = 1;
        ELSE
        SET _$STDCD = FORMAT((SELECT MAX(CAST(STDCD AS DOUBLE)) + 1 FROM MSTSTD), 0);
        END IF;
      
       
        INSERT INTO MSTSTD (
        STDTP, STDCD, STDNM, STDMACHINE, STDPOINT,
        STDCHKTP, STDRANGE, STDJUDGE, STDUNIT, STDCYCLE,
        RTIME, REMP, RPRG
        ) VALUES (
        _$STDTP, _$STDCD, _$STDNM, _$STDMACHINE, _$STDPOINT,
        _$STDCHKTP, _$STDRANGE, '', _$STDUNIT, _$STDCYCLE,
        CALLTIME(), CALLEMP(), CALLPRG() );
      

    ELSE

     IF _$STDCD = '' THEN          
       CALL COMERR('검사항목코드가 없습니다.');
       LEAVE PROC;
     END IF;
  
     IF _$STDTP = '' THEN
       CALL COMERR('검사구분을 선택하세요.');
       LEAVE PROC;
     END IF;
  
     IF _$STDNM = '' THEN
       CALL COMERR('검사항목명을 입력하세요.');
       LEAVE PROC;
     END IF;
  
     IF _$STDCHKTP = '' THEN
       CALL COMERR('검사방법을 선택하세요.');
       LEAVE PROC;
     END IF;

     UPDATE MSTSTD
     SET STDTP      = _$STDTP    
       , STDNM      = _$STDNM
       , STDCHKTP   = _$STDCHKTP
       , STDMACHINE = _$STDMACHINE
       , STDPOINT   = _$STDPOINT
       , STDRANGE   = _$STDRANGE
       , STDUNIT    = _$STDUNIT
       , STDJUDGE   = _$STDJUDGE
       , STDCYCLE   = _$STDCYCLE
       , REMARK     = _$REMARK
       , MTIME      = CALLTIME()
       , MEMP       = CALLEMP()
       , MPRG       = CALLPRG()
     WHERE STDCD = _$STDCD
    ;
    END IF;

  END WHILE;
 
-- ****************************************************************************
WHEN 'DELETE_MSTSTD' THEN -- 검사항목 삭제

   WHILE LENGTH($STDCD_LIST) > 0 DO
    CALL COMSPLIT($STDCD_LIST, _$STDCD);

      IF _$STDCD = '' THEN
        CALL COMERR('검사항목을 선택하세요.');
        LEAVE PROC;
      END IF;
    
      IF EXISTS (SELECT MSTRPTREV_DETAIL.REVCD 
                FROM MSTSTD 
                INNER JOIN MSTRPTREV_DETAIL
                  ON MSTRPTREV_DETAIL.STDCD = MSTSTD.STDCD            
                WHERE MSTSTD.STDCD = _$STDCD) THEN
        CALL COMERR('해당 검사항목을 사용하는 리비전이 존재하여 삭제할 수 없습니다.');
        LEAVE PROC;
      END IF;
    
      DELETE FROM MSTSTD WHERE STDCD = _$STDCD;
  END WHILE;


-- ****************************************************************************
WHEN 'COPY_MSTSTD' THEN -- 검사항목 복사 -- 항목을 복사할시 품명에 (복사)가 자동으로 붙어서 저장
  IF $STDTP_LIST = '' THEN 
    CALL COMERR('복사할 검사항목을 선택하세요.');  
    LEAVE PROC;
  END IF;

  WHILE LENGTH($STDTP_LIST) > 0 DO

    CALL COMSPLIT($STDTP_LIST, _$STDTP);
    CALL COMSPLIT($STDNM_LIST, _$STDNM);
    CALL COMSPLIT($STDCHKTP_LIST, _$STDCHKTP);
    CALL COMSPLIT($STDMACHINE_LIST, _$STDMACHINE);

    CALL COMSPLIT($STDPOINT_LIST, _$STDPOINT);
    CALL COMSPLIT($STDCYCLE_LIST, _$STDCYCLE);
    CALL COMSPLIT($STDUNIT_LIST, _$STDUNIT);
    CALL COMSPLIT($STDRANGE_LIST, _$STDRANGE);

    CALL COMSPLIT($STDJUDGE_LIST, _$STDJUDGE);
    CALL COMSPLIT($REMARK_LIST, _$REMARK);

        -- 검사항목 코드 자동완성
    IF (SELECT COUNT(*) FROM MSTSTD) = 0 THEN
      SET _$STDCD = 1;
      ELSE
      SET _$STDCD = FORMAT((SELECT MAX(CAST(STDCD AS DOUBLE)) + 1 FROM MSTSTD), 0);
    END IF;


    INSERT INTO MSTSTD (
        STDTP, STDCD, STDNM, STDCHKTP, 
        STDMACHINE, STDPOINT, STDRANGE, 
        STDUNIT, STDJUDGE, STDCYCLE, REMARK, 
        RTIME, REMP, RPRG
        ) VALUES (
        _$STDTP, _$STDCD, CONCAT(_$STDNM, '(복사)'), 
        _$STDCHKTP, _$STDMACHINE, _$STDPOINT, 
        _$STDRANGE, _$STDUNIT, _$STDJUDGE, _$STDCYCLE, _$REMARK, 
        CALLTIME(), CALLEMP(), CALLPRG());


  END WHILE;

-- ****************************************************************************
WHEN 'LIST_FILE_3D' THEN -- 팝업창 3D 측정갑 헤더

  SELECT DEVICE_3D_HEADER.DEVKEY,
         DEVICE_3D_HEADER.FILENAME,
         DEVICE_3D_HEADER.DEVDATE
    FROM DEVICE_3D_HEADER
   WHERE DEVICE_3D_HEADER.DEVDATE BETWEEN $SDATE AND $EDATE
     AND SUBSTRING_INDEX(DEVICE_3D_HEADER.FILENAME, '_', 1) LIKE CONCAT('%', $ITEMCD, '%')
ORDER BY DEVICE_3D_HEADER.RTIME;


-- * ***************************************************************************
WHEN 'LIST_DEVICE_3D' THEN  -- 팝업창 3D 측정값  세부항목

  SELECT 
    DEVKEY,
    NAME,
    CONTROL,
    CASE 
        WHEN NOMINAL = 0 THEN '' 
        ELSE REPLACE(FORMAT(NOMINAL, 3), ',', '') 
    END AS NOMINAL,
    CASE 
        WHEN MEAVAL = 0 THEN '' 
        ELSE REPLACE(FORMAT(MEAVAL, 3), ',', '') 
    END AS MEAVAL,
    CONCAT(GPCD('STDRANGE', DEVICE_3D_DETAIL.STDRANGE), ROUND(TOLVAL, 3)) AS TOLVAL,
    REPLACE(FORMAT(DEVVAL, 3), ',', '') AS DEVVAL,
    CASE 
        WHEN DEVICE_3D_DETAIL.TESTYN = 'N' THEN '불합격'
        ELSE '합격' 
    END AS TESTYN,
    CASE 
        WHEN OUTTOL = 0 THEN '' 
        ELSE REPLACE(FORMAT(OUTTOL, 3), ',', '') 
    END AS OUTTOL,
    CASE 
        WHEN DEVICE_3D_DETAIL.TESTYN = 'N' THEN 'RED' 
        ELSE 'WHITE' 
    END AS BACKGROUND,
    CASE 
        WHEN DEVICE_3D_DETAIL.TESTYN = 'N' THEN 'WHITE' 
        ELSE 'BLACK' 
    END AS FOREGROUND

    FROM DEVICE_3D_DETAIL
    WHERE DEVKEY = $DEVKEY
    ORDER BY SEQ ASC
    ;


-- ****************************************************************************
END CASE;  END