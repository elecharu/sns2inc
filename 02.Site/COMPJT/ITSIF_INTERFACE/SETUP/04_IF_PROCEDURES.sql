-- ITSIF_INTERFACE 설치 스크립트 (원본 DB: IF_MES_SNS_FAC2, 추출일 2026-10-27)
-- 대상 DB 를 선택한 뒤 실행하세요. 예) USE IF_MES_SNS_FAC2;

DELIMITER $$

DROP PROCEDURE IF EXISTS `MES_IF_COMTYPE`$$
CREATE PROCEDURE `MES_IF_COMTYPE`(
  IN $IF_KEY_LIST MEDIUMTEXT,        -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,       -- 인터페이스 구분(I/U/D)

  IN $BASE_CD_LIST MEDIUMTEXT,       -- 기준코드 (base_cd)
  IN $MAIN_CD_LIST MEDIUMTEXT,       -- 그룹코드 (main_cd -> GPCD)
  IN $SUB_CD_LIST MEDIUMTEXT,        -- 상세코드 (sub_cd -> TPCD)
  IN $TITLE_LIST MEDIUMTEXT,         -- 상세명 (title -> TPNM)
  IN $USE_YN_LIST MEDIUMTEXT,        -- 사용여부 (use_yn)

  IN $M1_LIST MEDIUMTEXT,            -- 참조01
  IN $M2_LIST MEDIUMTEXT,            -- 참조02
  IN $M3_LIST MEDIUMTEXT,            -- 참조03
  IN $M4_LIST MEDIUMTEXT,            -- 참조04
  IN $M5_LIST MEDIUMTEXT,            -- 참조05
  IN $M6_LIST MEDIUMTEXT,            -- 참조06
  IN $M7_LIST MEDIUMTEXT,            -- 참조07
  IN $M8_LIST MEDIUMTEXT,            -- 참조08
  IN $M9_LIST MEDIUMTEXT,            -- 참조09
  IN $M10_LIST MEDIUMTEXT,           -- 참조10
  IN $M11_LIST MEDIUMTEXT,           -- 참조11
  IN $M12_LIST MEDIUMTEXT,           -- 참조12
  IN $M13_LIST MEDIUMTEXT,           -- 참조13
  IN $M14_LIST MEDIUMTEXT,           -- 참조14
  IN $M15_LIST MEDIUMTEXT,           -- 참조15
  IN $M16_LIST MEDIUMTEXT,           -- 참조16
  IN $M17_LIST MEDIUMTEXT,           -- 참조17
  IN $M18_LIST MEDIUMTEXT,           -- 참조18
  IN $M19_LIST MEDIUMTEXT,           -- 참조19
  IN $M20_LIST MEDIUMTEXT,           -- 참조20

  IN $RMKS_LIST MEDIUMTEXT           -- 비고 (rmks)
)
PROC: BEGIN

-- *************************************************************
-- 변수 선언
-- *************************************************************
DECLARE _$IFKEY INT;
DECLARE _$FIRSTKEY INT DEFAULT 0;
DECLARE _$IF_TYPE VARCHAR(1);

DECLARE _$BASE_CD VARCHAR(50);       -- 기준코드
DECLARE _$MAIN_CD VARCHAR(20);       -- 그룹코드 (GPCD)
DECLARE _$SUB_CD VARCHAR(100);       -- 상세코드 (TPCD)
DECLARE _$TITLE VARCHAR(1000);       -- 상세명 (TPNM)
DECLARE _$USE_YN VARCHAR(1);         -- 사용여부

DECLARE _$M1 VARCHAR(255);
DECLARE _$M2 VARCHAR(255);
DECLARE _$M3 VARCHAR(255);
DECLARE _$M4 VARCHAR(255);
DECLARE _$M5 VARCHAR(255);
DECLARE _$M6 VARCHAR(255);
DECLARE _$M7 VARCHAR(255);
DECLARE _$M8 VARCHAR(255);
DECLARE _$M9 VARCHAR(255);
DECLARE _$M10 VARCHAR(255);

DECLARE _$M11 VARCHAR(255);
DECLARE _$M12 VARCHAR(255);
DECLARE _$M13 VARCHAR(255);
DECLARE _$M14 VARCHAR(255);
DECLARE _$M15 VARCHAR(255);
DECLARE _$M16 VARCHAR(255);
DECLARE _$M17 VARCHAR(255);
DECLARE _$M18 VARCHAR(255);
DECLARE _$M19 VARCHAR(255);
DECLARE _$M20 VARCHAR(255);

DECLARE _$RMKS VARCHAR(1000);        -- 비고

-- *************************************************************
-- 오류 처리
-- *************************************************************
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
BEGIN

    GET DIAGNOSTICS CONDITION 1
        @sqlstate = RETURNED_SQLSTATE,
        @errno = MYSQL_ERRNO,
        @text = MESSAGE_TEXT;

    SET @full_error =
        CONCAT(
            'ERROR ',
            @errno,
            ' (',
            @sqlstate,
            '): ',
            @text
        );

    INSERT INTO IF_ERR_LOG
    (
        IFKEY,
        IFGB,
        IFNAME,
        IF_TYPE,
        READTIME,
        ERRMSG
    )
    VALUES
    (
        _$IFKEY,
        'ERP',
        'MES_IF_COMTYPE',
        _$IF_TYPE,
        GETTIME(),
        @full_error
    );

    COMMIT;

END;

SET _$FIRSTKEY = 0;

-- *************************************************************
-- 인터페이스 LOOP
-- *************************************************************
WHILE LENGTH($MAIN_CD_LIST) > 0 DO

  CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
  CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

  CALL COMSPLIT($BASE_CD_LIST, _$BASE_CD);    -- 기준코드
  CALL COMSPLIT($MAIN_CD_LIST, _$MAIN_CD);    -- 그룹코드
  CALL COMSPLIT($SUB_CD_LIST, _$SUB_CD);      -- 상세코드
  CALL COMSPLIT($TITLE_LIST, _$TITLE);        -- 상세명
  CALL COMSPLIT($USE_YN_LIST, _$USE_YN);      -- 사용여부

  CALL COMSPLIT($M1_LIST, _$M1);
  CALL COMSPLIT($M2_LIST, _$M2);
  CALL COMSPLIT($M3_LIST, _$M3);
  CALL COMSPLIT($M4_LIST, _$M4);
  CALL COMSPLIT($M5_LIST, _$M5);
  CALL COMSPLIT($M6_LIST, _$M6);
  CALL COMSPLIT($M7_LIST, _$M7);
  CALL COMSPLIT($M8_LIST, _$M8);
  CALL COMSPLIT($M9_LIST, _$M9);
  CALL COMSPLIT($M10_LIST, _$M10);

  CALL COMSPLIT($M11_LIST, _$M11);
  CALL COMSPLIT($M12_LIST, _$M12);
  CALL COMSPLIT($M13_LIST, _$M13);
  CALL COMSPLIT($M14_LIST, _$M14);
  CALL COMSPLIT($M15_LIST, _$M15);
  CALL COMSPLIT($M16_LIST, _$M16);
  CALL COMSPLIT($M17_LIST, _$M17);
  CALL COMSPLIT($M18_LIST, _$M18);
  CALL COMSPLIT($M19_LIST, _$M19);
  CALL COMSPLIT($M20_LIST, _$M20);

  CALL COMSPLIT($RMKS_LIST, _$RMKS);

  IF _$FIRSTKEY = 0 THEN
      SET _$FIRSTKEY = _$IFKEY;
  END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_COMMON_DTL → COMTYPE
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN
  
    IF NOT EXISTS
    (
        SELECT 1
        FROM MES_SNS2.COMTYPE
        WHERE GPCD = _$MAIN_CD
          AND TPCD = _$BASE_CD
    )
    THEN
  
        INSERT INTO MES_SNS2.COMTYPE
        (
            GPCD,        -- 그룹코드
            TPCD,        -- 상세코드
            BASECD,      -- 기준코드
            TPNM,        -- 상세명
            USEYN,       -- 사용여부
  
            REF01, REF02, REF03, REF04, REF05,
            REF06, REF07, REF08, REF09, REF10,
            REF11, REF12, REF13, REF14, REF15,
            REF16, REF17, REF18, REF19, REF20,
  
            REMARK,      -- 비고
  
            RTIME,       -- 생성일
            REMP,        -- 생성자
            RPRG         -- 생성프로그램
        )
        VALUES
        (
            _$MAIN_CD,
            CONCAT(_$MAIN_CD, _$SUB_CD),
            _$BASE_CD,
            _$TITLE,
            IF(_$USE_YN = 1, 'Y', 'N'),
  
            _$M1, _$M2, _$M3, _$M4, _$M5,
            _$M6, _$M7, _$M8, _$M9, _$M10,
            _$M11, _$M12, _$M13, _$M14, _$M15,
            _$M16, _$M17, _$M18, _$M19, _$M20,
  
            _$RMKS,
  
            GETTIME(),
            'ERP',
            'IF'
        );
  
    END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_COMMON_DTL → COMTYPE
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

    IF NOT EXISTS
    (
        SELECT 1
        FROM MES_SNS2.COMTYPE
        WHERE GPCD = _$MAIN_CD
          AND TPCD = _$BASE_CD
    )
    THEN
  
        INSERT INTO MES_SNS2.COMTYPE
        (
            GPCD, TPCD, BASECD, TPNM, USEYN,
            REF01, REF02, REF03, REF04, REF05,
            REF06, REF07, REF08, REF09, REF10,
            REF11, REF12, REF13, REF14, REF15,
            REF16, REF17, REF18, REF19, REF20,
            REMARK,
            RTIME, REMP, RPRG
        )
        VALUES
        (
            _$MAIN_CD, CONCAT(_$MAIN_CD, _$SUB_CD), _$BASE_CD, _$TITLE, IF(_$USE_YN = 1, 'Y', 'N'),
            _$M1, _$M2, _$M3, _$M4, _$M5,
            _$M6, _$M7, _$M8, _$M9, _$M10,
            _$M11, _$M12, _$M13, _$M14, _$M15,
            _$M16, _$M17, _$M18, _$M19, _$M20,
            _$RMKS,
            GETTIME(), 'ERP', 'IF'
        );
  
    ELSE
  
        UPDATE MES_SNS2.COMTYPE
        SET
            BASECD  = IF(_$BASE_CD <> '', _$BASE_CD, BASECD),  -- 기준코드
            TPNM    = IF(_$TITLE <> '', _$TITLE, TPNM),         -- 상세명
            USEYN   = IF(_$USE_YN <> '', IF(_$USE_YN = 1, 'Y', 'N'), USEYN),      -- 사용여부
            REF01   = IF(_$M1 <> '', _$M1, REF01),              -- 참조01
            REF02   = IF(_$M2 <> '', _$M2, REF02),              -- 참조02
            REF03   = IF(_$M3 <> '', _$M3, REF03),              -- 참조03
            REF04   = IF(_$M4 <> '', _$M4, REF04),              -- 참조04
            REF05   = IF(_$M5 <> '', _$M5, REF05),              -- 참조05
            REF06   = IF(_$M6 <> '', _$M6, REF06),              -- 참조06
            REF07   = IF(_$M7 <> '', _$M7, REF07),              -- 참조07
            REF08   = IF(_$M8 <> '', _$M8, REF08),              -- 참조08
            REF09   = IF(_$M9 <> '', _$M9, REF09),              -- 참조09
            REF10   = IF(_$M10 <> '', _$M10, REF10),            -- 참조10
            REF11   = IF(_$M11 <> '', _$M11, REF11),            -- 참조11
            REF12   = IF(_$M12 <> '', _$M12, REF12),            -- 참조12
            REF13   = IF(_$M13 <> '', _$M13, REF13),            -- 참조13
            REF14   = IF(_$M14 <> '', _$M14, REF14),            -- 참조14
            REF15   = IF(_$M15 <> '', _$M15, REF15),            -- 참조15
            REF16   = IF(_$M16 <> '', _$M16, REF16),            -- 참조16
            REF17   = IF(_$M17 <> '', _$M17, REF17),            -- 참조17
            REF18   = IF(_$M18 <> '', _$M18, REF18),            -- 참조18
            REF19   = IF(_$M19 <> '', _$M19, REF19),            -- 참조19
            REF20   = IF(_$M20 <> '', _$M20, REF20),            -- 참조20
            REMARK  = IF(_$RMKS <> '', _$RMKS, REMARK),         -- 비고
            MTIME   = GETTIME(),                       -- 수정일
            MEMP    = 'ERP',             -- 수정자
            MPRG    = 'IF'                                      -- 수정프로그램
        WHERE GPCD = _$MAIN_CD
          AND TPCD = _$BASE_CD;
  
    END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_COMMON_DTL → COMTYPE
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN
  
      DELETE
      FROM MES_SNS2.COMTYPE
      WHERE GPCD = _$MAIN_CD
        AND TPCD = _$BASE_CD;
  
  END IF;

END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_COMTYPE';
  
  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
    AND IFNAME = 'MES_IF_COMTYPE';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_COMTYPEGP`$$
CREATE PROCEDURE `MES_IF_COMTYPEGP`(
  IN $IF_KEY_LIST MEDIUMTEXT,        -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,       -- 인터페이스 구분(I/U/D)

  IN $MAIN_CD_LIST MEDIUMTEXT,      -- 헤더코드
  IN $TITLE_LIST MEDIUMTEXT,        -- 헤더명
  IN $MDL_CD_LIST MEDIUMTEXT,       -- 모듈코드
  IN $GRP_NM_LIST MEDIUMTEXT,       -- 그룹명
  IN $USE_YN_LIST MEDIUMTEXT,       -- 사용여부

  IN $M1_LIST MEDIUMTEXT,           -- 참조설명01
  IN $M2_LIST MEDIUMTEXT,           -- 참조설명02
  IN $M3_LIST MEDIUMTEXT,           -- 참조설명03
  IN $M4_LIST MEDIUMTEXT,           -- 참조설명04
  IN $M5_LIST MEDIUMTEXT,           -- 참조설명05
  IN $M6_LIST MEDIUMTEXT,           -- 참조설명06
  IN $M7_LIST MEDIUMTEXT,           -- 참조설명07
  IN $M8_LIST MEDIUMTEXT,           -- 참조설명08
  IN $M9_LIST MEDIUMTEXT,           -- 참조설명09
  IN $M10_LIST MEDIUMTEXT,          -- 참조설명10
  IN $M11_LIST MEDIUMTEXT,          -- 참조설명11
  IN $M12_LIST MEDIUMTEXT,          -- 참조설명12
  IN $M13_LIST MEDIUMTEXT,          -- 참조설명13
  IN $M14_LIST MEDIUMTEXT,          -- 참조설명14
  IN $M15_LIST MEDIUMTEXT,          -- 참조설명15
  IN $M16_LIST MEDIUMTEXT,          -- 참조설명16
  IN $M17_LIST MEDIUMTEXT,          -- 참조설명17
  IN $M18_LIST MEDIUMTEXT,          -- 참조설명18
  IN $M19_LIST MEDIUMTEXT,          -- 참조설명19
  IN $M20_LIST MEDIUMTEXT,          -- 참조설명20

  IN $RMKS_LIST MEDIUMTEXT          -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);
  
  DECLARE _$MAIN_CD VARCHAR(20);        -- 헤더코드
  DECLARE _$TITLE VARCHAR(100);         -- 헤더명
  DECLARE _$MDL_CD VARCHAR(10);         -- 모듈코드
  DECLARE _$GRP_NM VARCHAR(100);        -- 그룹명
  DECLARE _$USE_YN VARCHAR(1);          -- 사용여부
  
  DECLARE _$M1 VARCHAR(255);
  DECLARE _$M2 VARCHAR(255);
  DECLARE _$M3 VARCHAR(255);
  DECLARE _$M4 VARCHAR(255);
  DECLARE _$M5 VARCHAR(255);
  DECLARE _$M6 VARCHAR(255);
  DECLARE _$M7 VARCHAR(255);
  DECLARE _$M8 VARCHAR(255);
  DECLARE _$M9 VARCHAR(255);
  DECLARE _$M10 VARCHAR(255);
  
  DECLARE _$M11 VARCHAR(255);
  DECLARE _$M12 VARCHAR(255);
  DECLARE _$M13 VARCHAR(255);
  DECLARE _$M14 VARCHAR(255);
  DECLARE _$M15 VARCHAR(255);
  DECLARE _$M16 VARCHAR(255);
  DECLARE _$M17 VARCHAR(255);
  DECLARE _$M18 VARCHAR(255);
  DECLARE _$M19 VARCHAR(255);
  DECLARE _$M20 VARCHAR(255);
  
  DECLARE _$RMKS VARCHAR(1000);         -- 비고
  
  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN
  
      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;
  
  
      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );
  
      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_COMTYPEGP',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );
   
      COMMIT;
  
  END;
  
  SET _$FIRSTKEY = 0;
  
  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($MAIN_CD_LIST) > 0 DO
  
    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);
  
    CALL COMSPLIT($MAIN_CD_LIST, _$MAIN_CD);    -- 헤더코드
    CALL COMSPLIT($TITLE_LIST, _$TITLE);        -- 헤더명
    CALL COMSPLIT($MDL_CD_LIST, _$MDL_CD);      -- 모듈코드
    CALL COMSPLIT($GRP_NM_LIST, _$GRP_NM);      -- 그룹명
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);      -- 사용여부
  
    CALL COMSPLIT($M1_LIST, _$M1);
    CALL COMSPLIT($M2_LIST, _$M2);
    CALL COMSPLIT($M3_LIST, _$M3);
    CALL COMSPLIT($M4_LIST, _$M4);
    CALL COMSPLIT($M5_LIST, _$M5);
    CALL COMSPLIT($M6_LIST, _$M6);
    CALL COMSPLIT($M7_LIST, _$M7);
    CALL COMSPLIT($M8_LIST, _$M8);
    CALL COMSPLIT($M9_LIST, _$M9);
    CALL COMSPLIT($M10_LIST, _$M10);
  
    CALL COMSPLIT($M11_LIST, _$M11);
    CALL COMSPLIT($M12_LIST, _$M12);
    CALL COMSPLIT($M13_LIST, _$M13);
    CALL COMSPLIT($M14_LIST, _$M14);
    CALL COMSPLIT($M15_LIST, _$M15);
    CALL COMSPLIT($M16_LIST, _$M16);
    CALL COMSPLIT($M17_LIST, _$M17);
    CALL COMSPLIT($M18_LIST, _$M18);
    CALL COMSPLIT($M19_LIST, _$M19);
    CALL COMSPLIT($M20_LIST, _$M20);
  
    CALL COMSPLIT($RMKS_LIST, _$RMKS);
  
    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = _$IFKEY;
    END IF;
  
    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_COMMON → COMTYPEGP
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
    
      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.COMTYPEGP
          WHERE GPCD = _$MAIN_CD
      )
      THEN
    
          INSERT INTO MES_SNS2.COMTYPEGP
          (
              GPCD,       -- 헤더코드
              GPNM,       -- 헤더명
              MDLCD,      -- 모듈코드
              GRPNM,      -- 그룹명
              USEYN,      -- 사용여부
    
              REF01NM,
              REF02NM,
              REF03NM,
              REF04NM,
              REF05NM,
              REF06NM,
              REF07NM,
              REF08NM,
              REF09NM,
              REF10NM,
    
              REF11NM,
              REF12NM,
              REF13NM,
              REF14NM,
              REF15NM,
              REF16NM,
              REF17NM,
              REF18NM,
              REF19NM,
              REF20NM,
    
              REMARK,
    
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$MAIN_CD,
              _$TITLE,
              _$MDL_CD,
              _$GRP_NM,
              _$USE_YN,
    
              _$M1,
              _$M2,
              _$M3,
              _$M4,
              _$M5,
              _$M6,
              _$M7,
              _$M8,
              _$M9,
              _$M10,
    
              _$M11,
              _$M12,
              _$M13,
              _$M14,
              _$M15,
              _$M16,
              _$M17,
              _$M18,
              _$M19,
              _$M20,
    
              _$RMKS,
    
              GETTIME(),
              'ERP',
              'IF'
          );
    
      END IF;
    
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_COMMON → COMTYPEGP
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
    
      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.COMTYPEGP
          WHERE GPCD = _$MAIN_CD
      )
      THEN
      
        INSERT INTO MES_SNS2.COMTYPEGP
        (
            GPCD,
            GPNM,
            MDLCD,
            GRPNM,
            USEYN,
      
            REF01NM,
            REF02NM,
            REF03NM,
            REF04NM,
            REF05NM,
            REF06NM,
            REF07NM,
            REF08NM,
            REF09NM,
            REF10NM,
      
            REF11NM,
            REF12NM,
            REF13NM,
            REF14NM,
            REF15NM,
            REF16NM,
            REF17NM,
            REF18NM,
            REF19NM,
            REF20NM,
      
            REMARK,
      
            RTIME,
            REMP,
            RPRG
        )
        VALUES
        (
            _$MAIN_CD,
            _$TITLE,
            _$MDL_CD,
            _$GRP_NM,
            _$USE_YN,
      
            _$M1,
            _$M2,
            _$M3,
            _$M4,
            _$M5,
            _$M6,
            _$M7,
            _$M8,
            _$M9,
            _$M10,
      
            _$M11,
            _$M12,
            _$M13,
            _$M14,
            _$M15,
            _$M16,
            _$M17,
            _$M18,
            _$M19,
            _$M20,
      
            _$RMKS,
      
            GETTIME(),
            'ERP',
            'IF'
        );
      
      ELSE
      
        UPDATE MES_SNS2.COMTYPEGP
        SET
            GPNM = IF(_$TITLE <> '', _$TITLE, GPNM),                 -- 헤더명
            MDLCD = IF(_$MDL_CD <> '', _$MDL_CD, MDLCD),             -- 모듈코드
            GRPNM = IF(_$GRP_NM <> '', _$GRP_NM, GRPNM),             -- 그룹명
            USEYN = IF(_$USE_YN <> '', _$USE_YN, USEYN),             -- 사용여부
            REF01NM = IF(_$M1 <> '', _$M1, REF01NM),                   -- 참조설명01
            REF02NM = IF(_$M2 <> '', _$M2, REF02NM),                   -- 참조설명02
            REF03NM = IF(_$M3 <> '', _$M3, REF03NM),                   -- 참조설명03
            REF04NM = IF(_$M4 <> '', _$M4, REF04NM),                   -- 참조설명04
            REF05NM = IF(_$M5 <> '', _$M5, REF05NM),                   -- 참조설명05
            REF06NM = IF(_$M6 <> '', _$M6, REF06NM),                   -- 참조설명06
            REF07NM = IF(_$M7 <> '', _$M7, REF07NM),                   -- 참조설명07
            REF08NM = IF(_$M8 <> '', _$M8, REF08NM),                   -- 참조설명08
            REF09NM = IF(_$M9 <> '', _$M9, REF09NM),                   -- 참조설명09
            REF10NM = IF(_$M10 <> '', _$M10, REF10NM),                 -- 참조설명10
            REF11NM = IF(_$M11 <> '', _$M11, REF11NM),                 -- 참조설명11
            REF12NM = IF(_$M12 <> '', _$M12, REF12NM),                 -- 참조설명12
            REF13NM = IF(_$M13 <> '', _$M13, REF13NM),                 -- 참조설명13
            REF14NM = IF(_$M14 <> '', _$M14, REF14NM),                 -- 참조설명14
            REF15NM = IF(_$M15 <> '', _$M15, REF15NM),                 -- 참조설명15
            REF16NM = IF(_$M16 <> '', _$M16, REF16NM),                 -- 참조설명16
            REF17NM = IF(_$M17 <> '', _$M17, REF17NM),                 -- 참조설명17
            REF18NM = IF(_$M18 <> '', _$M18, REF18NM),                 -- 참조설명18
            REF19NM = IF(_$M19 <> '', _$M19, REF19NM),                 -- 참조설명19
            REF20NM = IF(_$M20 <> '', _$M20, REF20NM),                 -- 참조설명20
            REMARK = IF(_$RMKS <> '', _$RMKS, REMARK),                -- 비고
            MTIME = GETTIME(),                                        -- 수정일
            MEMP = 'ERP',                                             -- 수정자
            MPRG = 'IF'                                               -- 수정프로그램
        WHERE GPCD = _$MAIN_CD;
      
      END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_COMMON → COMTYPEGP
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
    
        DELETE
        FROM MES_SNS2.COMTYPEGP
        WHERE GPCD = _$MAIN_CD;
    
    END IF;
  
  END WHILE;
  
  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_COMTYPEGP';
  
  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_COMTYPEGP';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTBAD`$$
CREATE PROCEDURE `MES_IF_MSTBAD`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $BASE_CD_LIST MEDIUMTEXT,         -- 기초코드 (PK)
    IN $MAIN_CD_LIST MEDIUMTEXT,         -- 대분류코드
    IN $SUB_CD_LIST MEDIUMTEXT,          -- 미실적대체부문
    IN $TITLE_LIST MEDIUMTEXT,           -- 발의내용(불량명)
    IN $ORD_SQ_LIST MEDIUMTEXT,          -- 정렬순서
    IN $USER_YN_LIST MEDIUMTEXT,         -- 사용자정의여부
    IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
    IN $OLD_CD_LIST MEDIUMTEXT,          -- 구품목코드
    IN $RMKS_LIST MEDIUMTEXT,            -- 비고

    IN $M1_LIST MEDIUMTEXT,              -- 대분류 (BADTP1)
    IN $M2_LIST MEDIUMTEXT,              -- 중분류 (BADTP2)
    IN $M3_LIST MEDIUMTEXT,              -- 소분류 (BADTP3)
    IN $M4_LIST MEDIUMTEXT,              -- 관리4 (M4)
    IN $M5_LIST MEDIUMTEXT,              -- 불량제외 (M5)
    IN $M6_LIST MEDIUMTEXT,              -- 폐각제외 (M6)
    IN $M7_LIST MEDIUMTEXT,              -- 만성불량 (M7)
    IN $M8_LIST MEDIUMTEXT,              -- 수입검사 (IQCYN)
    IN $M9_LIST MEDIUMTEXT,              -- 공정검사 (PQCYN)
    IN $M10_LIST MEDIUMTEXT,             -- 완성검사 (OQCYN)
    IN $M11_LIST MEDIUMTEXT,             -- 관리11 (M11)
    IN $M12_LIST MEDIUMTEXT,             -- 관리12 (M12)
    IN $M13_LIST MEDIUMTEXT,             -- 관리13 (M13)
    IN $M14_LIST MEDIUMTEXT,             -- 관리14 (M14)
    IN $M15_LIST MEDIUMTEXT,             -- 관리15 (M15)
    IN $M16_LIST MEDIUMTEXT,             -- 관리16 (M16)
    IN $M17_LIST MEDIUMTEXT,             -- 관리17 (M17)
    IN $M18_LIST MEDIUMTEXT,             -- 관리18 (M18)
    IN $M19_LIST MEDIUMTEXT,             -- 관리19 (M19)
    IN $M20_LIST MEDIUMTEXT              -- 공장 (M20)
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$BASE_CD VARCHAR(10);
  DECLARE _$MAIN_CD VARCHAR(5);
  DECLARE _$SUB_CD VARCHAR(5);
  DECLARE _$TITLE VARCHAR(100);
  DECLARE _$ORD_SQ VARCHAR(50);
  DECLARE _$USER_YN VARCHAR(1);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$OLD_CD VARCHAR(20);
  DECLARE _$RMKS VARCHAR(1000);

  DECLARE _$M1 VARCHAR(1000);
  DECLARE _$M2 VARCHAR(1000);
  DECLARE _$M3 VARCHAR(1000);
  DECLARE _$M4 VARCHAR(1000);
  DECLARE _$M5 VARCHAR(1000);
  DECLARE _$M6 VARCHAR(1000);
  DECLARE _$M7 VARCHAR(1000);
  DECLARE _$M8 VARCHAR(1000);
  DECLARE _$M9 VARCHAR(1000);
  DECLARE _$M10 VARCHAR(1000);
  DECLARE _$M11 VARCHAR(1000);
  DECLARE _$M12 VARCHAR(1000);
  DECLARE _$M13 VARCHAR(1000);
  DECLARE _$M14 VARCHAR(1000);
  DECLARE _$M15 VARCHAR(1000);
  DECLARE _$M16 VARCHAR(1000);
  DECLARE _$M17 VARCHAR(1000);
  DECLARE _$M18 VARCHAR(1000);
  DECLARE _$M19 VARCHAR(1000);
  DECLARE _$M20 VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTBAD',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($BASE_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($BASE_CD_LIST, _$BASE_CD);
    CALL COMSPLIT($MAIN_CD_LIST, _$MAIN_CD);
    CALL COMSPLIT($SUB_CD_LIST, _$SUB_CD);
    CALL COMSPLIT($TITLE_LIST, _$TITLE);
    CALL COMSPLIT($ORD_SQ_LIST, _$ORD_SQ);
    CALL COMSPLIT($USER_YN_LIST, _$USER_YN);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
    CALL COMSPLIT($OLD_CD_LIST, _$OLD_CD);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    CALL COMSPLIT($M1_LIST, _$M1);
    CALL COMSPLIT($M2_LIST, _$M2);
    CALL COMSPLIT($M3_LIST, _$M3);
    CALL COMSPLIT($M4_LIST, _$M4);
    CALL COMSPLIT($M5_LIST, _$M5);
    CALL COMSPLIT($M6_LIST, _$M6);
    CALL COMSPLIT($M7_LIST, _$M7);
    CALL COMSPLIT($M8_LIST, _$M8);
    CALL COMSPLIT($M9_LIST, _$M9);
    CALL COMSPLIT($M10_LIST, _$M10);
    CALL COMSPLIT($M11_LIST, _$M11);
    CALL COMSPLIT($M12_LIST, _$M12);
    CALL COMSPLIT($M13_LIST, _$M13);
    CALL COMSPLIT($M14_LIST, _$M14);
    CALL COMSPLIT($M15_LIST, _$M15);
    CALL COMSPLIT($M16_LIST, _$M16);
    CALL COMSPLIT($M17_LIST, _$M17);
    CALL COMSPLIT($M18_LIST, _$M18);
    CALL COMSPLIT($M19_LIST, _$M19);
    CALL COMSPLIT($M20_LIST, _$M20);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자)
    -- *************************************************************
    SET _$IFKEY  = NULLIF(TRIM(_$IFKEY), '');
    SET _$ORD_SQ = NULLIF(TRIM(_$ORD_SQ), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_BAD → MSTBAD
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTBAD
            WHERE BADCD = _$BASE_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTBAD
            (
                BADCD,
                MAINCD,
                SUBCD,
                BADNM,
                SORTNO,
                USERYN,
                USEYN,
                OLDCD,
                BADTP1,
                BADTP2,
                BADTP3,
                M4,
                M5,
                M6,
                M7,
                IQCYN,
                PQCYN,
                OQCYN,
                M11,
                M12,
                M13,
                M14,
                M15,
                M16,
                M17,
                M18,
                M19,
                M20,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$BASE_CD,
                _$MAIN_CD,
                _$SUB_CD,
                _$TITLE,
                IFNULL(CONVERT(_$ORD_SQ, SIGNED), 0),
                IF(_$USER_YN = '1', 'Y', 'N'),
                IF(_$USE_YN = '1', 'Y', 'N'),
                _$OLD_CD,
                _$M1,
                _$M2,
                IF(_$M3 = '1', 'Y', 'N'),
                _$M4,
                _$M5,
                _$M6,
                _$M7,
                IF(_$M8 = '1', 'Y', 'N'),
                _$M9,
                _$M10,
                IF(_$M11 = '1', 'Y', 'N'),
                _$M12,
                _$M13,
                _$M14,
                _$M15,
                _$M16,
                _$M17,
                _$M18,
                _$M19,
                _$M20,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_BAD → MSTBAD
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTBAD
            WHERE BADCD = _$BASE_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTBAD
            (
                BADCD,
                MAINCD,
                SUBCD,
                BADNM,
                SORTNO,
                USERYN,
                USEYN,
                OLDCD,
                BADTP1,
                BADTP2,
                BADTP3,
                M4,
                M5,
                M6,
                M7,
                IQCYN,
                PQCYN,
                OQCYN,
                M11,
                M12,
                M13,
                M14,
                M15,
                M16,
                M17,
                M18,
                M19,
                M20,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$BASE_CD,
                _$MAIN_CD,
                _$SUB_CD,
                _$TITLE,
                IFNULL(CONVERT(_$ORD_SQ, SIGNED), 0),
                IF(_$USER_YN = '1', 'Y', 'N'),
                IF(_$USE_YN = '1', 'Y', 'N'),
                _$OLD_CD,
                _$M1,
                _$M2,
                IF(_$M3 = '1', 'Y', 'N'),
                _$M4,
                _$M5,
                _$M6,
                _$M7,
                IF(_$M8 = '1', 'Y', 'N'),
                _$M9,
                _$M10,
                IF(_$M11 = '1', 'Y', 'N'),
                _$M12,
                _$M13,
                _$M14,
                _$M15,
                _$M16,
                _$M17,
                _$M18,
                _$M19,
                _$M20,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTBAD
            SET
                MAINCD = IF(_$MAIN_CD <> '', _$MAIN_CD, MAINCD),
                SUBCD  = IF(_$SUB_CD <> '', _$SUB_CD, SUBCD),
                BADNM  = IF(_$TITLE <> '', _$TITLE, BADNM),
                SORTNO = IFNULL(CONVERT(_$ORD_SQ, SIGNED), 0),
                USERYN = IF(_$USER_YN <> '', IF(_$USER_YN = '1', 'Y', 'N'), USERYN),
                USEYN  = IF(_$USE_YN <> '', IF(_$USE_YN = '1', 'Y', 'N'), USEYN),
                OLDCD  = IF(_$OLD_CD <> '', _$OLD_CD, OLDCD),
                BADTP1 = IF(_$M1 <> '', _$M1, BADTP1),
                BADTP2 = IF(_$M2 <> '', _$M2, BADTP2),
                BADTP3 = IF(_$M3 <> '', IF(_$M3 = '1', 'Y', 'N'), BADTP3),
                M4     = IF(_$M4 <> '', _$M4, M4),
                M5     = IF(_$M5 <> '', _$M5, M5),
                M6     = IF(_$M6 <> '', _$M6, M6),
                M7     = IF(_$M7 <> '', _$M7, M7),
                IQCYN  = IF(_$M8 <> '', IF(_$M8 = '1', 'Y', 'N'), IQCYN),
                PQCYN  = IF(_$M9 <> '', _$M9, PQCYN),
                OQCYN  = IF(_$M10 <> '', _$M10, OQCYN),
                M11    = IF(_$M11 <> '', IF(_$M11 = '1', 'Y', 'N'), M11),
                M12    = IF(_$M12 <> '', _$M12, M12),
                M13    = IF(_$M13 <> '', _$M13, M13),
                M14    = IF(_$M14 <> '', _$M14, M14),
                M15    = IF(_$M15 <> '', _$M15, M15),
                M16    = IF(_$M16 <> '', _$M16, M16),
                M17    = IF(_$M17 <> '', _$M17, M17),
                M18    = IF(_$M18 <> '', _$M18, M18),
                M19    = IF(_$M19 <> '', _$M19, M19),
                M20    = IF(_$M20 <> '', _$M20, M20),
                REMARK = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME  = GETTIME(),
                MEMP   = 'ERP',
                MPRG   = 'IF'
            WHERE BADCD = _$BASE_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_BAD → MSTBAD
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTBAD
        WHERE BADCD = _$BASE_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTBAD';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTBAD';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTBAS_STOCK`$$
CREATE PROCEDURE `MES_IF_MSTBAS_STOCK`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드 (PK)
    IN $STD_MON_LIST MEDIUMTEXT,         -- 기준년월 (PK)
    IN $ITM_ID_LIST MEDIUMTEXT,          -- 품목ID (PK)
    IN $ITM_CD_LIST MEDIUMTEXT,          -- 품목코드
    IN $STOCK_QTY_LIST MEDIUMTEXT        -- 현재고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$STD_MON VARCHAR(10);
  DECLARE _$ITM_ID INT;
  DECLARE _$ITM_CD VARCHAR(20);
  DECLARE _$STOCK_QTY DECIMAL(18,0);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTBAS_STOCK',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($FAC_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);
  
    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
    CALL COMSPLIT($STD_MON_LIST, _$STD_MON);
    CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
    CALL COMSPLIT($ITM_CD_LIST, _$ITM_CD);
    CALL COMSPLIT($STOCK_QTY_LIST, _$STOCK_QTY);
  
    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = _$IFKEY;
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_BAS_STOCK → MSTBAS_STOCK
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTBAS_STOCK
            WHERE FACTORYCD = _$FAC_CD
              AND STDMON    = _$STD_MON
              AND ITEMID    = _$ITM_ID
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTBAS_STOCK
            (
                FACTORYCD,
                STDMON,
                ITEMID,
                ITEMCD,
                STOCKQTY,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$FAC_CD,
                _$STD_MON,
                _$ITM_ID,
                _$ITM_CD,
                _$STOCK_QTY,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_BAS_STOCK → MSTBAS_STOCK
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTBAS_STOCK
            WHERE FACTORYCD = _$FAC_CD
              AND STDMON    = _$STD_MON
              AND ITEMID    = _$ITM_ID
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTBAS_STOCK
            (
                FACTORYCD,
                STDMON,
                ITEMID,
                ITEMCD,
                STOCKQTY,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$FAC_CD,
                _$STD_MON,
                _$ITM_ID,
                _$ITM_CD,
                _$STOCK_QTY,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTBAS_STOCK
            SET
                ITEMCD   = IF(_$ITM_CD <> '', _$ITM_CD, ITEMCD),
                STOCKQTY = IF(_$STOCK_QTY IS NOT NULL, _$STOCK_QTY, STOCKQTY),
                MTIME    = GETTIME(),
                MEMP = 'ERP',
                MPRG = 'IF'
            WHERE FACTORYCD = _$FAC_CD
              AND STDMON    = _$STD_MON
              AND ITEMID    = _$ITM_ID;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_BAS_STOCK → MSTBAS_STOCK
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTBAS_STOCK
        WHERE FACTORYCD = _$FAC_CD
          AND STDMON    = _$STD_MON
          AND ITEMID    = _$ITM_ID;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTBAS_STOCK';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTBAS_STOCK';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTBDV`$$
CREATE PROCEDURE `MES_IF_MSTBDV`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $BS_CD_LIST MEDIUMTEXT,           -- 사업장코드
  IN $BS_NM_LIST MEDIUMTEXT,           -- 사업장명
  IN $BS_BNM_LIST MEDIUMTEXT,          -- 사업장명_약칭
  IN $CEO_NM_LIST MEDIUMTEXT,          -- 대표자명
  IN $BS_ENM_LIST MEDIUMTEXT,          -- 사업장 영문명
  IN $BIZ_NO_LIST MEDIUMTEXT,          -- 사업자등록번호
  IN $BIZ_PNM_LIST MEDIUMTEXT,         -- 사업장명_인쇄용
  IN $BIZ_KIND_LIST MEDIUMTEXT,        -- 업종
  IN $BIZ_TYPE_LIST MEDIUMTEXT,        -- 업태
  IN $BIZ_KIND_PRT_LIST MEDIUMTEXT,    -- 업종_인쇄용
  IN $BIZ_TYPE_PRT_LIST MEDIUMTEXT,    -- 업태_인쇄용
  IN $TAX_AREA_LIST MEDIUMTEXT,        -- 사업소면적_과세
  IN $NOTAX_AREA_LIST MEDIUMTEXT,      -- 사업소면적_비과세
  IN $NAT_CD_LIST MEDIUMTEXT,          -- 국가코드
  IN $BIZ_BC_LIST MEDIUMTEXT,          -- 사업군
  IN $CURY_BC_LIST MEDIUMTEXT,         -- 통화구분
  IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
  IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
  IN $OPEN_DT_LIST MEDIUMTEXT,         -- 개설일자
  IN $ZIP_CD_LIST MEDIUMTEXT,          -- 우편번호
  IN $ADDR_LIST MEDIUMTEXT,            -- 주소
  IN $ADDR_PRT_LIST MEDIUMTEXT,        -- 주소_인쇄용
  IN $TEL_LIST MEDIUMTEXT,             -- 대표전화
  IN $FAX_LIST MEDIUMTEXT,             -- 대표Fax
  IN $EMAIL_LIST MEDIUMTEXT,           -- Email
  IN $HOMEPAGE_LIST MEDIUMTEXT,        -- HomePage
  IN $TEL2_LIST MEDIUMTEXT,            -- 전화2
  IN $HOMETAX_ID_LIST MEDIUMTEXT,      -- HomeTaxID
  IN $FAX2_LIST MEDIUMTEXT,            -- 대표Fax(해외)
  IN $TAX_OFC_CD_LIST MEDIUMTEXT,      -- 관할세무서코드
  IN $LOCAL_OFC_CD_LIST MEDIUMTEXT,    -- 지방세납부관공서
  IN $TAX_PAY_CD_LIST MEDIUMTEXT,      -- 세무서납세코드
  IN $VAT_CLOSE_DT_LIST MEDIUMTEXT,    -- 부가세마감일
  IN $HEAD_YN_LIST MEDIUMTEXT,         -- 본사여부
  IN $BANK_CD_LIST MEDIUMTEXT,         -- 은행코드
  IN $ACCT_NM_LIST MEDIUMTEXT,         -- 예금주
  IN $ACCT_NO_LIST MEDIUMTEXT,         -- 계좌번호
  IN $FRN_YN_LIST MEDIUMTEXT,          -- 외국인단일세율적용여부
  IN $CON_IN_TM_LIST MEDIUMTEXT,       -- 출근감안시간-분
  IN $CON_OUT_TM_LIST MEDIUMTEXT,      -- 퇴근감안시간-분
  IN $UNIT_TM_LIST MEDIUMTEXT,         -- 단위시간-분
  IN $TAX_BANK_LIST MEDIUMTEXT,        -- 부가세환급은행코드
  IN $TAX_ACCT_LIST MEDIUMTEXT,        -- 부가세환급계좌
  IN $TAX_BANK_LOC_LIST MEDIUMTEXT,    -- 부가세환급지점
  IN $TAX_BS_LIST MEDIUMTEXT,          -- 신고사업장
  IN $APP_BS_LIST MEDIUMTEXT,          -- 귀속사업장
  IN $CO_CD_LIST MEDIUMTEXT,           -- 법인코드
  IN $IMG_LIST MEDIUMTEXT,             -- 사진
  IN $DISP_SQ_LIST MEDIUMTEXT,         -- 순서
  IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
  IN $DIV_CD_LIST MEDIUMTEXT,          -- 회계단위코드

  IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$BS_CD VARCHAR(10);
  DECLARE _$BS_NM VARCHAR(100);
  DECLARE _$BS_BNM VARCHAR(50);
  DECLARE _$CEO_NM VARCHAR(100);
  DECLARE _$BS_ENM VARCHAR(100);
  DECLARE _$BIZ_NO VARCHAR(20);
  DECLARE _$BIZ_PNM VARCHAR(100);
  DECLARE _$BIZ_KIND VARCHAR(50);
  DECLARE _$BIZ_TYPE VARCHAR(50);
  DECLARE _$BIZ_KIND_PRT VARCHAR(50);
  DECLARE _$BIZ_TYPE_PRT VARCHAR(50);
  DECLARE _$TAX_AREA VARCHAR(50);
  DECLARE _$NOTAX_AREA VARCHAR(50);
  DECLARE _$NAT_CD VARCHAR(10);
  DECLARE _$BIZ_BC VARCHAR(10);
  DECLARE _$CURY_BC VARCHAR(10);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$OPEN_DT VARCHAR(50);
  DECLARE _$ZIP_CD VARCHAR(20);
  DECLARE _$ADDR VARCHAR(200);
  DECLARE _$ADDR_PRT VARCHAR(100);
  DECLARE _$TEL VARCHAR(50);
  DECLARE _$FAX VARCHAR(50);
  DECLARE _$EMAIL VARCHAR(100);
  DECLARE _$HOMEPAGE VARCHAR(100);
  DECLARE _$TEL2 VARCHAR(50);
  DECLARE _$HOMETAX_ID VARCHAR(20);
  DECLARE _$FAX2 VARCHAR(50);
  DECLARE _$TAX_OFC_CD VARCHAR(20);
  DECLARE _$LOCAL_OFC_CD VARCHAR(20);
  DECLARE _$TAX_PAY_CD VARCHAR(20);
  DECLARE _$VAT_CLOSE_DT VARCHAR(50);
  DECLARE _$HEAD_YN VARCHAR(1);
  DECLARE _$BANK_CD VARCHAR(20);
  DECLARE _$ACCT_NM VARCHAR(50);
  DECLARE _$ACCT_NO VARCHAR(50);
  DECLARE _$FRN_YN VARCHAR(1);
  DECLARE _$CON_IN_TM VARCHAR(50);
  DECLARE _$CON_OUT_TM VARCHAR(50);
  DECLARE _$UNIT_TM VARCHAR(50);
  DECLARE _$TAX_BANK VARCHAR(50);
  DECLARE _$TAX_ACCT VARCHAR(50);
  DECLARE _$TAX_BANK_LOC VARCHAR(50);
  DECLARE _$TAX_BS VARCHAR(10);
  DECLARE _$APP_BS VARCHAR(10);
  DECLARE _$CO_CD VARCHAR(10);
  DECLARE _$IMG VARCHAR(1000);
  DECLARE _$DISP_SQ VARCHAR(50);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$DIV_CD VARCHAR(10);

  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTBDV',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($BS_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($BS_CD_LIST, _$BS_CD);
    CALL COMSPLIT($BS_NM_LIST, _$BS_NM);
    CALL COMSPLIT($BS_BNM_LIST, _$BS_BNM);
    CALL COMSPLIT($CEO_NM_LIST, _$CEO_NM);
    CALL COMSPLIT($BS_ENM_LIST, _$BS_ENM);
    CALL COMSPLIT($BIZ_NO_LIST, _$BIZ_NO);
    CALL COMSPLIT($BIZ_PNM_LIST, _$BIZ_PNM);
    CALL COMSPLIT($BIZ_KIND_LIST, _$BIZ_KIND);
    CALL COMSPLIT($BIZ_TYPE_LIST, _$BIZ_TYPE);
    CALL COMSPLIT($BIZ_KIND_PRT_LIST, _$BIZ_KIND_PRT);
    CALL COMSPLIT($BIZ_TYPE_PRT_LIST, _$BIZ_TYPE_PRT);
    CALL COMSPLIT($TAX_AREA_LIST, _$TAX_AREA);
    CALL COMSPLIT($NOTAX_AREA_LIST, _$NOTAX_AREA);
    CALL COMSPLIT($NAT_CD_LIST, _$NAT_CD);
    CALL COMSPLIT($BIZ_BC_LIST, _$BIZ_BC);
    CALL COMSPLIT($CURY_BC_LIST, _$CURY_BC);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($OPEN_DT_LIST, _$OPEN_DT);
    CALL COMSPLIT($ZIP_CD_LIST, _$ZIP_CD);
    CALL COMSPLIT($ADDR_LIST, _$ADDR);
    CALL COMSPLIT($ADDR_PRT_LIST, _$ADDR_PRT);
    CALL COMSPLIT($TEL_LIST, _$TEL);
    CALL COMSPLIT($FAX_LIST, _$FAX);
    CALL COMSPLIT($EMAIL_LIST, _$EMAIL);
    CALL COMSPLIT($HOMEPAGE_LIST, _$HOMEPAGE);
    CALL COMSPLIT($TEL2_LIST, _$TEL2);
    CALL COMSPLIT($HOMETAX_ID_LIST, _$HOMETAX_ID);
    CALL COMSPLIT($FAX2_LIST, _$FAX2);
    CALL COMSPLIT($TAX_OFC_CD_LIST, _$TAX_OFC_CD);
    CALL COMSPLIT($LOCAL_OFC_CD_LIST, _$LOCAL_OFC_CD);
    CALL COMSPLIT($TAX_PAY_CD_LIST, _$TAX_PAY_CD);
    CALL COMSPLIT($VAT_CLOSE_DT_LIST, _$VAT_CLOSE_DT);
    CALL COMSPLIT($HEAD_YN_LIST, _$HEAD_YN);
    CALL COMSPLIT($BANK_CD_LIST, _$BANK_CD);
    CALL COMSPLIT($ACCT_NM_LIST, _$ACCT_NM);
    CALL COMSPLIT($ACCT_NO_LIST, _$ACCT_NO);
    CALL COMSPLIT($FRN_YN_LIST, _$FRN_YN);
    CALL COMSPLIT($CON_IN_TM_LIST, _$CON_IN_TM);
    CALL COMSPLIT($CON_OUT_TM_LIST, _$CON_OUT_TM);
    CALL COMSPLIT($UNIT_TM_LIST, _$UNIT_TM);
    CALL COMSPLIT($TAX_BANK_LIST, _$TAX_BANK);
    CALL COMSPLIT($TAX_ACCT_LIST, _$TAX_ACCT);
    CALL COMSPLIT($TAX_BANK_LOC_LIST, _$TAX_BANK_LOC);
    CALL COMSPLIT($TAX_BS_LIST, _$TAX_BS);
    CALL COMSPLIT($APP_BS_LIST, _$APP_BS);
    CALL COMSPLIT($CO_CD_LIST, _$CO_CD);
    CALL COMSPLIT($IMG_LIST, _$IMG);
    CALL COMSPLIT($DISP_SQ_LIST, _$DISP_SQ);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
    CALL COMSPLIT($DIV_CD_LIST, _$DIV_CD);

    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY       = NULLIF(TRIM(_$IFKEY), '');
    SET _$TAX_AREA    = NULLIF(TRIM(_$TAX_AREA), '');
    SET _$NOTAX_AREA  = NULLIF(TRIM(_$NOTAX_AREA), '');
    SET _$CON_IN_TM   = NULLIF(TRIM(_$CON_IN_TM), '');
    SET _$CON_OUT_TM  = NULLIF(TRIM(_$CON_OUT_TM), '');
    SET _$UNIT_TM     = NULLIF(TRIM(_$UNIT_TM), '');
    SET _$DISP_SQ     = NULLIF(TRIM(_$DISP_SQ), '');

    SET _$FR_DT       = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT       = NULLIF(TRIM(_$TO_DT), '');
    SET _$OPEN_DT     = NULLIF(TRIM(_$OPEN_DT), '');
    SET _$VAT_CLOSE_DT = NULLIF(TRIM(_$VAT_CLOSE_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_BDV → MSTBDV
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTBDV
            WHERE BDVCD = _$BS_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTBDV
            (
                BDVCD,
                BDVNM,
                BDVBNM,
                PRESIDENT,
                BDVNMENG,
                BDVREGNO,
                BDVBNM_PRT,
                INDKIND,
                INDTYPE,
                INDKIND_PRT,
                INDTYPE_PRT,
                TAX_AREA,
                NOTAX_AREA,
                NATCD,
                BIZ_BC,
                CURY_BC,
                FRDT,
                TODT,
                OPENDT,
                ZIPCD,
                ADDR,
                ADDR_PRT,
                REPRETEL,
                FAXNO,
                EMAIL,
                HOMEURL,
                REPRETEL2,
                HOMETAX_ID,
                FAX2,
                TAX_OFCCD,
                LOCAL_OFCCD,
                TAX_PAYCD,
                VAT_CLOSEDT,
                HEADYN,
                BANKCD,
                ACCTNM,
                ACCTNO,
                FRNYN,
                CON_IN_TM,
                CON_OUT_TM,
                UNIT_TM,
                TAX_BANK,
                TAX_ACCT,
                TAX_BANK_LOC,
                TAX_BS,
                APP_BS,
                COMPANYCD,
                IMG,
                DISPSEQ,
                USEYN,
                DIV_CD,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$BS_CD,
                _$BS_NM,
                _$BS_BNM,
                _$CEO_NM,
                _$BS_ENM,
                _$BIZ_NO,
                _$BIZ_PNM,
                _$BIZ_KIND,
                _$BIZ_TYPE,
                _$BIZ_KIND_PRT,
                _$BIZ_TYPE_PRT,
                IFNULL(CONVERT(_$TAX_AREA, DECIMAL(20,0)), 0),
                IFNULL(CONVERT(_$NOTAX_AREA, DECIMAL(20,0)), 0),
                _$NAT_CD,
                _$BIZ_BC,
                _$CURY_BC,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                IF(_$OPEN_DT IS NULL, NULL, GETDATETIME(_$OPEN_DT)),
                _$ZIP_CD,
                _$ADDR,
                _$ADDR_PRT,
                _$TEL,
                _$FAX,
                _$EMAIL,
                _$HOMEPAGE,
                _$TEL2,
                _$HOMETAX_ID,
                _$FAX2,
                _$TAX_OFC_CD,
                _$LOCAL_OFC_CD,
                _$TAX_PAY_CD,
                IF(_$VAT_CLOSE_DT IS NULL, NULL, GETDATETIME(_$VAT_CLOSE_DT)),
                _$HEAD_YN,
                _$BANK_CD,
                _$ACCT_NM,
                _$ACCT_NO,
                _$FRN_YN,
                IFNULL(CONVERT(_$CON_IN_TM, SIGNED), 0),
                IFNULL(CONVERT(_$CON_OUT_TM, SIGNED), 0),
                IFNULL(CONVERT(_$UNIT_TM, SIGNED), 0),
                _$TAX_BANK,
                _$TAX_ACCT,
                _$TAX_BANK_LOC,
                _$TAX_BS,
                _$APP_BS,
                _$CO_CD,
                _$IMG,
                IFNULL(CONVERT(_$DISP_SQ, SIGNED), 0),
                IF(_$USE_YN = '1', 'Y', 'N'),
                _$DIV_CD,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_BDV → MSTBDV
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTBDV
          WHERE BDVCD = _$BS_CD
      )
      THEN
  
        INSERT INTO MES_SNS2.MSTBDV
        (
            BDVCD,
            BDVNM,
            BDVBNM,
            PRESIDENT,
            BDVNMENG,
            BDVREGNO,
            BDVBNM_PRT,
            INDKIND,
            INDTYPE,
            INDKIND_PRT,
            INDTYPE_PRT,
            TAX_AREA,
            NOTAX_AREA,
            NATCD,
            BIZ_BC,
            CURY_BC,
            FRDT,
            TODT,
            OPENDT,
            ZIPCD,
            ADDR,
            ADDR_PRT,
            REPRETEL,
            FAXNO,
            EMAIL,
            HOMEURL,
            REPRETEL2,
            HOMETAX_ID,
            FAX2,
            TAX_OFCCD,
            LOCAL_OFCCD,
            TAX_PAYCD,
            VAT_CLOSEDT,
            HEADYN,
            BANKCD,
            ACCTNM,
            ACCTNO,
            FRNYN,
            CON_IN_TM,
            CON_OUT_TM,
            UNIT_TM,
            TAX_BANK,
            TAX_ACCT,
            TAX_BANK_LOC,
            TAX_BS,
            APP_BS,
            COMPANYCD,
            IMG,
            DISPSEQ,
            USEYN,
            DIV_CD,
            REMARK,
            RTIME,
            REMP,
            RPRG
        )
        VALUES
        (
            _$BS_CD,
            _$BS_NM,
            _$BS_BNM,
            _$CEO_NM,
            _$BS_ENM,
            _$BIZ_NO,
            _$BIZ_PNM,
            _$BIZ_KIND,
            _$BIZ_TYPE,
            _$BIZ_KIND_PRT,
            _$BIZ_TYPE_PRT,
            IFNULL(CONVERT(_$TAX_AREA, DECIMAL(20,0)), 0),
            IFNULL(CONVERT(_$NOTAX_AREA, DECIMAL(20,0)), 0),
            _$NAT_CD,
            _$BIZ_BC,
            _$CURY_BC,
            IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
            IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
            IF(_$OPEN_DT IS NULL, NULL, GETDATETIME(_$OPEN_DT)),
            _$ZIP_CD,
            _$ADDR,
            _$ADDR_PRT,
            _$TEL,
            _$FAX,
            _$EMAIL,
            _$HOMEPAGE,
            _$TEL2,
            _$HOMETAX_ID,
            _$FAX2,
            _$TAX_OFC_CD,
            _$LOCAL_OFC_CD,
            _$TAX_PAY_CD,
            IF(_$VAT_CLOSE_DT IS NULL, NULL, GETDATETIME(_$VAT_CLOSE_DT)),
            _$HEAD_YN,
            _$BANK_CD,
            _$ACCT_NM,
            _$ACCT_NO,
            _$FRN_YN,
            IFNULL(CONVERT(_$CON_IN_TM, SIGNED), 0),
            IFNULL(CONVERT(_$CON_OUT_TM, SIGNED), 0),
            IFNULL(CONVERT(_$UNIT_TM, SIGNED), 0),
            _$TAX_BANK,
            _$TAX_ACCT,
            _$TAX_BANK_LOC,
            _$TAX_BS,
            _$APP_BS,
            _$CO_CD,
            _$IMG,
            IFNULL(CONVERT(_$DISP_SQ, SIGNED), 0),
            IF(_$USE_YN = '1', 'Y', 'N'),
            _$DIV_CD,
            _$RMKS,
            GETTIME(),
            'ERP',
            'IF'
        );
          
      ELSE
    
        UPDATE MES_SNS2.MSTBDV
        SET
            BDVNM       = IF(_$BS_NM <> '', _$BS_NM, BDVNM),
            BDVBNM      = IF(_$BS_BNM <> '', _$BS_BNM, BDVBNM),
            PRESIDENT   = IF(_$CEO_NM <> '', _$CEO_NM, PRESIDENT),
            BDVNMENG    = IF(_$BS_ENM <> '', _$BS_ENM, BDVNMENG),
            BDVREGNO    = IF(_$BIZ_NO <> '', _$BIZ_NO, BDVREGNO),
            BDVBNM_PRT  = IF(_$BIZ_PNM <> '', _$BIZ_PNM, BDVBNM_PRT),
            INDKIND     = IF(_$BIZ_KIND <> '', _$BIZ_KIND, INDKIND),
            INDTYPE     = IF(_$BIZ_TYPE <> '', _$BIZ_TYPE, INDTYPE),
            INDKIND_PRT = IF(_$BIZ_KIND_PRT <> '', _$BIZ_KIND_PRT, INDKIND_PRT),
            INDTYPE_PRT = IF(_$BIZ_TYPE_PRT <> '', _$BIZ_TYPE_PRT, INDTYPE_PRT),
            TAX_AREA    = IFNULL(CONVERT(_$TAX_AREA, DECIMAL(20,0)), 0),
            NOTAX_AREA  = IFNULL(CONVERT(_$NOTAX_AREA, DECIMAL(20,0)), 0),
            NATCD       = IF(_$NAT_CD <> '', _$NAT_CD, NATCD),
            BIZ_BC      = IF(_$BIZ_BC <> '', _$BIZ_BC, BIZ_BC),
            CURY_BC     = IF(_$CURY_BC <> '', _$CURY_BC, CURY_BC),
            FRDT        = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
            TODT        = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
            OPENDT      = IF(_$OPEN_DT IS NULL, NULL, GETDATETIME(_$OPEN_DT)),
            ZIPCD       = IF(_$ZIP_CD <> '', _$ZIP_CD, ZIPCD),
            ADDR        = IF(_$ADDR <> '', _$ADDR, ADDR),
            ADDR_PRT    = IF(_$ADDR_PRT <> '', _$ADDR_PRT, ADDR_PRT),
            REPRETEL    = IF(_$TEL <> '', _$TEL, REPRETEL),
            FAXNO       = IF(_$FAX <> '', _$FAX, FAXNO),
            EMAIL       = IF(_$EMAIL <> '', _$EMAIL, EMAIL),
            HOMEURL     = IF(_$HOMEPAGE <> '', _$HOMEPAGE, HOMEURL),
            REPRETEL2   = IF(_$TEL2 <> '', _$TEL2, REPRETEL2),
            HOMETAX_ID  = IF(_$HOMETAX_ID <> '', _$HOMETAX_ID, HOMETAX_ID),
            FAX2        = IF(_$FAX2 <> '', _$FAX2, FAX2),
            TAX_OFCCD   = IF(_$TAX_OFC_CD <> '', _$TAX_OFC_CD, TAX_OFCCD),
            LOCAL_OFCCD = IF(_$LOCAL_OFC_CD <> '', _$LOCAL_OFC_CD, LOCAL_OFCCD),
            TAX_PAYCD   = IF(_$TAX_PAY_CD <> '', _$TAX_PAY_CD, TAX_PAYCD),
            VAT_CLOSEDT = IF(_$VAT_CLOSE_DT IS NULL, NULL, GETDATETIME(_$VAT_CLOSE_DT)),
            HEADYN      = IF(_$HEAD_YN <> '', _$HEAD_YN, HEADYN),
            BANKCD      = IF(_$BANK_CD <> '', _$BANK_CD, BANKCD),
            ACCTNM      = IF(_$ACCT_NM <> '', _$ACCT_NM, ACCTNM),
            ACCTNO      = IF(_$ACCT_NO <> '', _$ACCT_NO, ACCTNO),
            FRNYN       = IF(_$FRN_YN <> '', _$FRN_YN, FRNYN),
            CON_IN_TM   = IFNULL(CONVERT(_$CON_IN_TM, SIGNED), 0),
            CON_OUT_TM  = IFNULL(CONVERT(_$CON_OUT_TM, SIGNED), 0),
            UNIT_TM     = IFNULL(CONVERT(_$UNIT_TM, SIGNED), 0),
            TAX_BANK    = IF(_$TAX_BANK <> '', _$TAX_BANK, TAX_BANK),
            TAX_ACCT    = IF(_$TAX_ACCT <> '', _$TAX_ACCT, TAX_ACCT),
            TAX_BANK_LOC= IF(_$TAX_BANK_LOC <> '', _$TAX_BANK_LOC, TAX_BANK_LOC),
            TAX_BS      = IF(_$TAX_BS <> '', _$TAX_BS, TAX_BS),
            APP_BS      = IF(_$APP_BS <> '', _$APP_BS, APP_BS),
            COMPANYCD   = IF(_$CO_CD <> '', _$CO_CD, COMPANYCD),
            IMG         = IF(_$IMG <> '', _$IMG, IMG),
            DISPSEQ     = IFNULL(CONVERT(_$DISP_SQ, SIGNED), 0),
            USEYN       = IF(_$USE_YN <> '', IF(_$USE_YN = '1', 'Y', 'N'), USEYN),
            DIV_CD      = IF(_$DIV_CD <> '', _$DIV_CD, DIV_CD),
            REMARK      = IF(_$RMKS <> '', _$RMKS, REMARK),
            MTIME       = GETTIME(),
            MEMP        = 'ERP',
            MPRG        = 'IF'
        WHERE BDVCD = _$BS_CD;
      
      END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_BDV → MSTBDV
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTBDV
        WHERE BDVCD = _$BS_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTBDV';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTBDV';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTBOM`$$
CREATE PROCEDURE `MES_IF_MSTBOM`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $ITM_PID_LIST MEDIUMTEXT,         -- 모품목ID (PK)
  IN $ITM_CID_LIST MEDIUMTEXT,         -- 자품목ID (PK)
  IN $REG_ID_LIST MEDIUMTEXT,          -- 등록ID
  IN $SQ_NO_LIST MEDIUMTEXT,           -- 순번
  IN $USG_QTY_LIST MEDIUMTEXT,         -- 소요량
  IN $LOS_RT_LIST MEDIUMTEXT,          -- 로스율
  IN $ACT_QTY_LIST MEDIUMTEXT,         -- 실소요량
  IN $UM_BC_LIST MEDIUMTEXT,           -- 단위
  IN $SRC_BC_LIST MEDIUMTEXT,          -- 공급구분
  IN $USE_BC_LIST MEDIUMTEXT,          -- 출고구분
  IN $PRC_CD_LIST MEDIUMTEXT,          -- 공정코드
  IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
  IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
  IN $DRAW_NO_LIST MEDIUMTEXT,         -- 도면번호
  IN $ECO_NO_LIST MEDIUMTEXT,          -- ECO번호
  IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부

  IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ITM_PID VARCHAR(50);
  DECLARE _$ITM_CID VARCHAR(50);
  DECLARE _$REG_ID VARCHAR(50);
  DECLARE _$SQ_NO VARCHAR(50);
  DECLARE _$USG_QTY VARCHAR(50);
  DECLARE _$LOS_RT VARCHAR(50);
  DECLARE _$ACT_QTY VARCHAR(50);
  DECLARE _$UM_BC VARCHAR(10);
  DECLARE _$SRC_BC VARCHAR(10);
  DECLARE _$USE_BC VARCHAR(10);
  DECLARE _$PRC_CD VARCHAR(10);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$DRAW_NO VARCHAR(50);
  DECLARE _$ECO_NO VARCHAR(50);
  DECLARE _$USE_YN VARCHAR(1);

  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTBOM',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ITM_PID_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($ITM_PID_LIST, _$ITM_PID);
    CALL COMSPLIT($ITM_CID_LIST, _$ITM_CID);
    CALL COMSPLIT($REG_ID_LIST, _$REG_ID);
    CALL COMSPLIT($SQ_NO_LIST, _$SQ_NO);
    CALL COMSPLIT($USG_QTY_LIST, _$USG_QTY);
    CALL COMSPLIT($LOS_RT_LIST, _$LOS_RT);
    CALL COMSPLIT($ACT_QTY_LIST, _$ACT_QTY);
    CALL COMSPLIT($UM_BC_LIST, _$UM_BC);
    CALL COMSPLIT($SRC_BC_LIST, _$SRC_BC);
    CALL COMSPLIT($USE_BC_LIST, _$USE_BC);
    CALL COMSPLIT($PRC_CD_LIST, _$PRC_CD);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($DRAW_NO_LIST, _$DRAW_NO);
    CALL COMSPLIT($ECO_NO_LIST, _$ECO_NO);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);

    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
    SET _$ITM_PID = NULLIF(TRIM(_$ITM_PID), '');
    SET _$ITM_CID = NULLIF(TRIM(_$ITM_CID), '');
    SET _$REG_ID  = NULLIF(TRIM(_$REG_ID), '');
    SET _$SQ_NO   = NULLIF(TRIM(_$SQ_NO), '');
    SET _$USG_QTY = NULLIF(TRIM(_$USG_QTY), '');
    SET _$LOS_RT  = NULLIF(TRIM(_$LOS_RT), '');
    SET _$ACT_QTY = NULLIF(TRIM(_$ACT_QTY), '');
    SET _$FR_DT   = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT   = NULLIF(TRIM(_$TO_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_BOM → MSTBOM
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTBOM
            WHERE MITEMID = CONVERT(_$ITM_PID, SIGNED)
              AND CITEMID = CONVERT(_$ITM_CID, SIGNED)
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTBOM
            (
                MITEMID,
                CITEMID,
                REGID,
                PRCSEQ,
                MUSAGE,
                LUSAGE,
                CUSAGE,
                BOMUNIT,
                SRC_BC,
                USE_BC,
                PRCCD,
                USEFRDT,
                USETODT,
                DRAWNO,
                ECONO,
                USEYN,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_PID, SIGNED),
                CONVERT(_$ITM_CID, SIGNED),
                IFNULL(CONVERT(_$REG_ID, SIGNED), 0),
                IFNULL(CONVERT(_$SQ_NO, SIGNED), 0),
                IFNULL(CONVERT(_$USG_QTY, DECIMAL(20,8)), 0),
                IFNULL(CONVERT(_$LOS_RT, DECIMAL(20,8)), 0),
                IFNULL(CONVERT(_$ACT_QTY, DECIMAL(20,8)), 0),
                _$UM_BC,
                _$SRC_BC,
                _$USE_BC,
                _$PRC_CD,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$DRAW_NO,
                _$ECO_NO,
                _$USE_YN = IF(_$USE_YN = '1', 'Y', 'N'),
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_BOM → MSTBOM
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTBOM
            WHERE MITEMID = CONVERT(_$ITM_PID, SIGNED)
              AND CITEMID = CONVERT(_$ITM_CID, SIGNED)
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTBOM
            (
                MITEMID,
                CITEMID,
                REGID,
                PRCSEQ,
                MUSAGE,
                LUSAGE,
                CUSAGE,
                BOMUNIT,
                SRC_BC,
                USE_BC,
                PRCCD,
                USEFRDT,
                USETODT,
                DRAWNO,
                ECONO,
                USEYN,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_PID, SIGNED),
                CONVERT(_$ITM_CID, SIGNED),
                IFNULL(CONVERT(_$REG_ID, SIGNED), 0),
                IFNULL(CONVERT(_$SQ_NO, SIGNED), 0),
                IFNULL(CONVERT(_$USG_QTY, DECIMAL(20,8)), 0),
                IFNULL(CONVERT(_$LOS_RT, DECIMAL(20,8)), 0),
                IFNULL(CONVERT(_$ACT_QTY, DECIMAL(20,8)), 0),
                _$UM_BC,
                _$SRC_BC,
                _$USE_BC,
                _$PRC_CD,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$DRAW_NO,
                _$ECO_NO,
                _$USE_YN = IF(_$USE_YN = '1', 'Y', 'N'),
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTBOM
            SET
                REGID   = IFNULL(CONVERT(_$REG_ID, SIGNED), 0),
                PRCSEQ  = IFNULL(CONVERT(_$SQ_NO, SIGNED), 0),
                MUSAGE  = IFNULL(CONVERT(_$USG_QTY, DECIMAL(20,8)), 0),
                LUSAGE  = IFNULL(CONVERT(_$LOS_RT, DECIMAL(20,8)), 0),
                CUSAGE  = IFNULL(CONVERT(_$ACT_QTY, DECIMAL(20,8)), 0),
                BOMUNIT = IF(_$UM_BC <> '', _$UM_BC, BOMUNIT),
                SRC_BC  = IF(_$SRC_BC <> '', _$SRC_BC, SRC_BC),
                USE_BC  = IF(_$USE_BC <> '', _$USE_BC, USE_BC),
                PRCCD   = IF(_$PRC_CD <> '', _$PRC_CD, PRCCD),
                USEFRDT = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                USETODT = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                DRAWNO  = IF(_$DRAW_NO <> '', _$DRAW_NO, DRAWNO),
                ECONO   = IF(_$ECO_NO <> '', _$ECO_NO, ECONO),
                USEYN   = IF(_$USE_YN <> '', _$USE_YN = IF(_$USE_YN = '1', 'Y', 'N'), USEYN),
                REMARK  = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME   = GETTIME(),
                MEMP    = 'ERP',
                MPRG    = 'IF'
            WHERE MITEMID = CONVERT(_$ITM_PID, SIGNED)
              AND CITEMID = CONVERT(_$ITM_CID, SIGNED);
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_BOM → MSTBOM
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTBOM
        WHERE MITEMID = CONVERT(_$ITM_PID, SIGNED)
          AND CITEMID = CONVERT(_$ITM_CID, SIGNED);
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTBOM';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTBOM';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTCOMPANY`$$
CREATE PROCEDURE `MES_IF_MSTCOMPANY`(
  IN $IF_KEY_LIST MEDIUMTEXT,        -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,       -- 인터페이스 구분(I/U/D)

  IN $CO_CD_LIST MEDIUMTEXT,         -- 법인코드
  IN $CO_NO_LIST MEDIUMTEXT,         -- 법인등록번호
  IN $CO_NM_LIST MEDIUMTEXT,         -- 법인명
  IN $CO_BNM_LIST MEDIUMTEXT,        -- 법인명_약칭
  IN $CO_DT_LIST MEDIUMTEXT,         -- 법인설립일
  IN $FR_DT_LIST MEDIUMTEXT,         -- 적용시작일
  IN $TO_DT_LIST MEDIUMTEXT,         -- 적용종료일
  IN $CO_BC_LIST MEDIUMTEXT,         -- 법인구분
  IN $BIZ_BC_LIST MEDIUMTEXT,        -- 사업군
  IN $HEAD_BS_LIST MEDIUMTEXT,       -- 본지점사업장
  IN $NAT_CD_LIST MEDIUMTEXT,        -- 국가코드
  IN $ADDR_LIST MEDIUMTEXT,          -- 주소
  IN $ZIP_CD_LIST MEDIUMTEXT,        -- 우편번호
  IN $CEO_NM_LIST MEDIUMTEXT,        -- 대표자명
  IN $CEO_ID_LIST MEDIUMTEXT,        -- 대표자주민번호
  IN $APPROV_NO_LIST MEDIUMTEXT,     -- 총괄승인납부번호
  IN $TRADE_NO_LIST MEDIUMTEXT,      -- 무역업허가번호
  IN $SYS_CD_LIST MEDIUMTEXT,        -- 회계계정체계코드
  IN $CURY_BC_LIST MEDIUMTEXT,       -- 통화구분
  IN $CAPITAL_AMT_LIST MEDIUMTEXT,   -- 자본금
  IN $SET_MON_LIST MEDIUMTEXT,       -- 결산월
  IN $VAT_KD_LIST MEDIUMTEXT,        -- 부가세구분
  IN $VAT_BC_LIST MEDIUMTEXT,        -- 사업자구분
  IN $LOGO_LIST MEDIUMTEXT,          -- Logo
  IN $STAMP_LIST MEDIUMTEXT,         -- 법인직인
  IN $STAMP2_LIST MEDIUMTEXT,        -- 법인직인_증명서용
  IN $STAMP_TRADE_LIST MEDIUMTEXT,   -- Signature(무역업사용)
  IN $BACK_IMG_LIST MEDIUMTEXT,      -- 배경사진
  IN $FTA_CD_LIST MEDIUMTEXT,        -- FTA기업코드
  IN $CUST_CD_LIST MEDIUMTEXT,       -- 거래처코드
  IN $MAIN_CO_LIST MEDIUMTEXT,       -- 법인코드(기본)
  IN $MAIN_DT_LIST MEDIUMTEXT,       -- 기본일자
  IN $MAIN_YN_LIST MEDIUMTEXT,       -- 기본발주업체여부
  IN $DISP_SQ_LIST MEDIUMTEXT,       -- 순서

  IN $RMKS_LIST MEDIUMTEXT           -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$CO_CD VARCHAR(10);
  DECLARE _$CO_NO VARCHAR(20);
  DECLARE _$CO_NM VARCHAR(100);
  DECLARE _$CO_BNM VARCHAR(50);
  DECLARE _$CO_DT VARCHAR(40);
  DECLARE _$FR_DT VARCHAR(40);
  DECLARE _$TO_DT VARCHAR(40);
  DECLARE _$CO_BC VARCHAR(10);
  DECLARE _$BIZ_BC VARCHAR(10);
  DECLARE _$HEAD_BS VARCHAR(10);
  DECLARE _$NAT_CD VARCHAR(10);
  DECLARE _$ADDR VARCHAR(300);
  DECLARE _$ZIP_CD VARCHAR(20);
  DECLARE _$CEO_NM VARCHAR(100);
  DECLARE _$CEO_ID VARCHAR(50);
  DECLARE _$APPROV_NO VARCHAR(50);
  DECLARE _$TRADE_NO VARCHAR(50);
  DECLARE _$SYS_CD VARCHAR(10);
  DECLARE _$CURY_BC VARCHAR(10);
  DECLARE _$CAPITAL_AMT VARCHAR(20);
  DECLARE _$SET_MON VARCHAR(2);
  DECLARE _$VAT_KD VARCHAR(10);
  DECLARE _$VAT_BC VARCHAR(10);
  DECLARE _$LOGO VARCHAR(100);
  DECLARE _$STAMP VARCHAR(100);
  DECLARE _$STAMP2 VARCHAR(100);
  DECLARE _$STAMP_TRADE VARCHAR(100);
  DECLARE _$BACK_IMG VARCHAR(100);
  DECLARE _$FTA_CD VARCHAR(20);
  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$MAIN_CO VARCHAR(10);
  DECLARE _$MAIN_DT VARCHAR(20);
  DECLARE _$MAIN_YN VARCHAR(1);
  DECLARE _$DISP_SQ INT;

  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTCOMPANY',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($CO_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);
  
    CALL COMSPLIT($CO_CD_LIST, _$CO_CD);
    CALL COMSPLIT($CO_NO_LIST, _$CO_NO);
    CALL COMSPLIT($CO_NM_LIST, _$CO_NM);
    CALL COMSPLIT($CO_BNM_LIST, _$CO_BNM);
    CALL COMSPLIT($CO_DT_LIST, _$CO_DT);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($CO_BC_LIST, _$CO_BC);
    CALL COMSPLIT($BIZ_BC_LIST, _$BIZ_BC);
    CALL COMSPLIT($HEAD_BS_LIST, _$HEAD_BS);
    CALL COMSPLIT($NAT_CD_LIST, _$NAT_CD);
    CALL COMSPLIT($ADDR_LIST, _$ADDR);
    CALL COMSPLIT($ZIP_CD_LIST, _$ZIP_CD);
    CALL COMSPLIT($CEO_NM_LIST, _$CEO_NM);
    CALL COMSPLIT($CEO_ID_LIST, _$CEO_ID);
    CALL COMSPLIT($APPROV_NO_LIST, _$APPROV_NO);
    CALL COMSPLIT($TRADE_NO_LIST, _$TRADE_NO);
    CALL COMSPLIT($SYS_CD_LIST, _$SYS_CD);
    CALL COMSPLIT($CURY_BC_LIST, _$CURY_BC);
    CALL COMSPLIT($CAPITAL_AMT_LIST, _$CAPITAL_AMT);
    CALL COMSPLIT($SET_MON_LIST, _$SET_MON);
    CALL COMSPLIT($VAT_KD_LIST, _$VAT_KD);
    CALL COMSPLIT($VAT_BC_LIST, _$VAT_BC);
    CALL COMSPLIT($LOGO_LIST, _$LOGO);
    CALL COMSPLIT($STAMP_LIST, _$STAMP);
    CALL COMSPLIT($STAMP2_LIST, _$STAMP2);
    CALL COMSPLIT($STAMP_TRADE_LIST, _$STAMP_TRADE);
    CALL COMSPLIT($BACK_IMG_LIST, _$BACK_IMG);
    CALL COMSPLIT($FTA_CD_LIST, _$FTA_CD);
    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
    CALL COMSPLIT($MAIN_CO_LIST, _$MAIN_CO);
    CALL COMSPLIT($MAIN_DT_LIST, _$MAIN_DT);
    CALL COMSPLIT($MAIN_YN_LIST, _$MAIN_YN);
    CALL COMSPLIT($DISP_SQ_LIST, _$DISP_SQ);
  
    CALL COMSPLIT($RMKS_LIST, _$RMKS);
  
    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = _$IFKEY;
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_COMPANY → MSTCOMPANY
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTCOMPANY
            WHERE COMPANYCD = _$CO_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTCOMPANY
            (
                COMPANYCD,
                COMPANYNO,
                COMPANYNM,
                COMPANYBNM,
                COMPANYDT,
                FRDT,
                TODT,
                COMPANY_BC,
                BIZ_BC,
                HEAD_BS,
                NATCD,
                ADDR,
                ZIPCD,
                PRESIDENT,
                PRESIDENTID,
                APPROVNO,
                TRADENO,
                SYSCD,
                CURY_BC,
                CAPITAL_AMT,
                SET_MON,
                VAT_KD,
                VAT_BC,
                LOGO,
                STSTAMP,
                STASTAMP2,
                STAMP_TRTRADE,
                BACK_IMG,
                FTACD,
                DISPSQ,
                COSTCD,
                COMPANY_CO,
                MAINDT,
                MAINYN,
                SEQ,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$CO_CD,
                _$CO_NO,
                _$CO_NM,
                _$CO_BNM,
                GETDATETIME(_$CO_DT),
                GETDATETIME(_$FR_DT),
                GETDATETIME(_$TO_DT),
                _$CO_BC,
                _$BIZ_BC,
                _$HEAD_BS,
                _$NAT_CD,
                _$ADDR,
                _$ZIP_CD,
                _$CEO_NM,
                _$CEO_ID,
                _$APPROV_NO,
                _$TRADE_NO,
                _$SYS_CD,
                _$CURY_BC,
                _$CAPITAL_AMT,
                _$SET_MON,
                _$VAT_KD,
                _$VAT_BC,
                _$LOGO,
                _$STAMP,
                _$STAMP2,
                _$STAMP_TRADE,
                _$BACK_IMG,
                _$FTA_CD,
                NULL,
                _$CUST_CD,
                _$MAIN_CO,
                GETDATETIME(_$MAIN_DT),
                _$MAIN_YN,
                _$DISP_SQ,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_COMPANY → MSTCOMPANY
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTCOMPANY
            WHERE COMPANYCD = _$CO_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTCOMPANY
            (
                COMPANYCD,
                COMPANYNO,
                COMPANYNM,
                COMPANYBNM,
                COMPANYDT,
                FRDT,
                TODT,
                COMPANY_BC,
                BIZ_BC,
                HEAD_BS,
                NATCD,
                ADDR,
                ZIPCD,
                PRESIDENT,
                PRESIDENTID,
                APPROVNO,
                TRADENO,
                SYSCD,
                CURY_BC,
                CAPITAL_AMT,
                SET_MON,
                VAT_KD,
                VAT_BC,
                LOGO,
                STSTAMP,
                STASTAMP2,
                STAMP_TRTRADE,
                BACK_IMG,
                FTACD,
                DISPSQ,
                COSTCD,
                COMPANY_CO,
                MAINDT,
                MAINYN,
                SEQ,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$CO_CD,
                _$CO_NO,
                _$CO_NM,
                _$CO_BNM,
                GETDATETIME(_$CO_DT),
                GETDATETIME(_$FR_DT),
                GETDATETIME(_$TO_DT),
                _$CO_BC,
                _$BIZ_BC,
                _$HEAD_BS,
                _$NAT_CD,
                _$ADDR,
                _$ZIP_CD,
                _$CEO_NM,
                _$CEO_ID,
                _$APPROV_NO,
                _$TRADE_NO,
                _$SYS_CD,
                _$CURY_BC,
                _$CAPITAL_AMT,
                _$SET_MON,
                _$VAT_KD,
                _$VAT_BC,
                _$LOGO,
                _$STAMP,
                _$STAMP2,
                _$STAMP_TRADE,
                _$BACK_IMG,
                _$FTA_CD,
                NULL,
                _$CUST_CD,
                _$MAIN_CO,
                GETDATETIME(_$MAIN_DT),
                _$MAIN_YN,
                _$DISP_SQ,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTCOMPANY
            SET
                COMPANYNO     = IF(_$CO_NO <> '', _$CO_NO, COMPANYNO),
                COMPANYNM     = IF(_$CO_NM <> '', _$CO_NM, COMPANYNM),
                COMPANYBNM    = IF(_$CO_BNM <> '', _$CO_BNM, COMPANYBNM),
                COMPANYDT     = IF(_$CO_DT <> '', GETDATETIME(_$CO_DT), COMPANYDT),
                FRDT          = IF(_$FR_DT <> '', GETDATETIME(_$FR_DT), FRDT),
                TODT          = IF(_$TO_DT <> '', GETDATETIME(_$TO_DT), TODT),
                COMPANY_BC    = IF(_$CO_BC <> '', _$CO_BC, COMPANY_BC),
                BIZ_BC        = IF(_$BIZ_BC <> '', _$BIZ_BC, BIZ_BC),
                HEAD_BS       = IF(_$HEAD_BS <> '', _$HEAD_BS, HEAD_BS),
                NATCD         = IF(_$NAT_CD <> '', _$NAT_CD, NATCD),
                ADDR          = IF(_$ADDR <> '', _$ADDR, ADDR),
                ZIPCD         = IF(_$ZIP_CD <> '', _$ZIP_CD, ZIPCD),
                PRESIDENT     = IF(_$CEO_NM <> '', _$CEO_NM, PRESIDENT),
                PRESIDENTID   = IF(_$CEO_ID <> '', _$CEO_ID, PRESIDENTID),
                APPROVNO      = IF(_$APPROV_NO <> '', _$APPROV_NO, APPROVNO),
                TRADENO       = IF(_$TRADE_NO <> '', _$TRADE_NO, TRADENO),
                SYSCD         = IF(_$SYS_CD <> '', _$SYS_CD, SYSCD),
                CURY_BC       = IF(_$CURY_BC <> '', _$CURY_BC, CURY_BC),
                CAPITAL_AMT   = IF(_$CAPITAL_AMT <> '', _$CAPITAL_AMT, CAPITAL_AMT),
                SET_MON       = IF(_$SET_MON <> '', _$SET_MON, SET_MON),
                VAT_KD        = IF(_$VAT_KD <> '', _$VAT_KD, VAT_KD),
                VAT_BC        = IF(_$VAT_BC <> '', _$VAT_BC, VAT_BC),
                LOGO          = IF(_$LOGO <> '', _$LOGO, LOGO),
                STSTAMP       = IF(_$STAMP <> '', _$STAMP, STSTAMP),
                STASTAMP2     = IF(_$STAMP2 <> '', _$STAMP2, STASTAMP2),
                STAMP_TRTRADE = IF(_$STAMP_TRADE <> '', _$STAMP_TRADE, STAMP_TRTRADE),
                BACK_IMG      = IF(_$BACK_IMG <> '', _$BACK_IMG, BACK_IMG),
                FTACD         = IF(_$FTA_CD <> '', _$FTA_CD, FTACD),
                COSTCD        = IF(_$CUST_CD <> '', _$CUST_CD, COSTCD),
                COMPANY_CO    = IF(_$MAIN_CO <> '', _$MAIN_CO, COMPANY_CO),
                MAINDT        = IF(_$MAIN_DT <> '', GETDATETIME(_$MAIN_DT), MAINDT),
                MAINYN        = IF(_$MAIN_YN <> '', _$MAIN_YN, MAINYN),
                SEQ           = IF(_$DISP_SQ IS NOT NULL, _$DISP_SQ, SEQ),
                REMARK        = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME         = GETTIME(),
                MEMP          = 'ERP',
                MPRG          = 'IF'
            WHERE COMPANYCD = _$CO_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_COMPANY → MSTCOMPANY
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTCOMPANY
        WHERE COMPANYCD = _$CO_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTCOMPANY';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTCOMPANY';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTCUST`$$
CREATE PROCEDURE `MES_IF_MSTCUST`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $CUST_CD_LIST MEDIUMTEXT,         -- 거래처코드 (PK)
  IN $CUST_NM_LIST MEDIUMTEXT,         -- 거래처명
  IN $CUST_ENM_LIST MEDIUMTEXT,        -- 영문명
  IN $PRT_NM_LIST MEDIUMTEXT,          -- 출력명
  IN $CO_CD_LIST MEDIUMTEXT,           -- 법인코드
  IN $GRP1_CD_LIST MEDIUMTEXT,         -- 대분류코드
  IN $GRP2_CD_LIST MEDIUMTEXT,         -- 중분류코드
  IN $GRP3_CD_LIST MEDIUMTEXT,         -- 소분류코드
  IN $CUST_BC_LIST MEDIUMTEXT,         -- 거래처구분
  IN $CUST_KD_LIST MEDIUMTEXT,         -- 거래처형태
  IN $CO_KD_LIST MEDIUMTEXT,           -- 기업구분
  IN $MNG_KD_LIST MEDIUMTEXT,          -- 경영구분
  IN $SIZE_BC_LIST MEDIUMTEXT,         -- 기업규모
  IN $LV_BC_LIST MEDIUMTEXT,           -- 점검중요도구분
  IN $CREDIT_BC_LIST MEDIUMTEXT,       -- 신용등급구분
  IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
  IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
  IN $SAL_YN_LIST MEDIUMTEXT,          -- 매출여부
  IN $PUR_YN_LIST MEDIUMTEXT,          -- 매입여부
  IN $DE_BC_LIST MEDIUMTEXT,           -- 매출지역구분
  IN $DI_BC_LIST MEDIUMTEXT,           -- 매입지역구분
  IN $TAX_BC_LIST MEDIUMTEXT,          -- 과세구분
  IN $ISS_BC_LIST MEDIUMTEXT,          -- 계산서발행구분
  IN $SAL_CUST_LIST MEDIUMTEXT,        -- 매출정산거래처코드
  IN $PUR_CUST_LIST MEDIUMTEXT,        -- 매입정산거래처코드
  IN $PSET_BC_LIST MEDIUMTEXT,         -- 결재조건
  IN $DAY_BC_LIST MEDIUMTEXT,          -- 정기지급일
  IN $PAY_BC_LIST MEDIUMTEXT,          -- 결재지급구분
  IN $NAT_CD_LIST MEDIUMTEXT,          -- 국가코드
  IN $CURY_BC_LIST MEDIUMTEXT,         -- 결재통화코드
  IN $CURY_BC2_LIST MEDIUMTEXT,        -- 통화코드2
  IN $ZIP_CD_LIST MEDIUMTEXT,          -- 우편번호
  IN $ADDR1_LIST MEDIUMTEXT,           -- 주소1
  IN $ADDR2_LIST MEDIUMTEXT,           -- 주소2
  IN $ADDR_PRT_LIST MEDIUMTEXT,        -- 주소_인쇄용
  IN $TEL_LIST MEDIUMTEXT,             -- 대표전화
  IN $FAX_LIST MEDIUMTEXT,             -- 대표Fax
  IN $HOMEPAGE_LIST MEDIUMTEXT,        -- HomePage
  IN $ESERO_LIST MEDIUMTEXT,          -- 전자계산서담당
  IN $EMAIL_LIST MEDIUMTEXT,           -- Email
  IN $ETEL_LIST MEDIUMTEXT,            -- 계산서담당전화
  IN $MAIN_CUST_LIST MEDIUMTEXT,       -- 거래처본사/본점
  IN $BIZ_NO_LIST MEDIUMTEXT,          -- 사업자등록번호
  IN $BIZ_TYPE_LIST MEDIUMTEXT,        -- 업태
  IN $BIZ_KIND_LIST MEDIUMTEXT,        -- 업종
  IN $CEO_NM_LIST MEDIUMTEXT,          -- 대표자명
  IN $CEO_REG_NO_LIST MEDIUMTEXT,      -- 대표자주민번호
  IN $SALES_AMT_LIST MEDIUMTEXT,       -- 매출액
  IN $EMP_CNT_LIST MEDIUMTEXT,         -- 종업원수
  IN $ITEMS_LIST MEDIUMTEXT,           -- 거래품목
  IN $TAX_NO_LIST MEDIUMTEXT,          -- 세무서번호
  IN $ACCT_YN_LIST MEDIUMTEXT,         -- 계좌개설
  IN $BANK_CD_LIST MEDIUMTEXT,         -- 은행코드
  IN $ACCT_NM_LIST MEDIUMTEXT,         -- 예금주
  IN $ACCT_NO_LIST MEDIUMTEXT,         -- 계좌번호
  IN $CO_NO_LIST MEDIUMTEXT,           -- 법인등록번호
  IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
  IN $RPT_BC_LIST MEDIUMTEXT,          -- 거래명세서유형
  IN $INSP_BC_LIST MEDIUMTEXT,         -- 검사구분
  IN $EXCH_BC_LIST MEDIUMTEXT,         -- 환율적용기준
  IN $EMP_NO_LIST MEDIUMTEXT,          -- 담당자사번
  IN $RMKS_LIST MEDIUMTEXT,            -- 비고
  IN $RMKS2_LIST MEDIUMTEXT            -- 비고2
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$CUST_NM VARCHAR(100);
  DECLARE _$CUST_ENM VARCHAR(100);
  DECLARE _$PRT_NM VARCHAR(100);
  DECLARE _$CO_CD VARCHAR(10);
  DECLARE _$GRP1_CD VARCHAR(20);
  DECLARE _$GRP2_CD VARCHAR(20);
  DECLARE _$GRP3_CD VARCHAR(20);
  DECLARE _$CUST_BC VARCHAR(10);
  DECLARE _$CUST_KD VARCHAR(10);
  DECLARE _$CO_KD VARCHAR(10);
  DECLARE _$MNG_KD VARCHAR(10);
  DECLARE _$SIZE_BC VARCHAR(10);
  DECLARE _$LV_BC VARCHAR(10);
  DECLARE _$CREDIT_BC VARCHAR(10);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$SAL_YN VARCHAR(1);
  DECLARE _$PUR_YN VARCHAR(1);
  DECLARE _$DE_BC VARCHAR(10);
  DECLARE _$DI_BC VARCHAR(10);
  DECLARE _$TAX_BC VARCHAR(10);
  DECLARE _$ISS_BC VARCHAR(10);
  DECLARE _$SAL_CUST VARCHAR(20);
  DECLARE _$PUR_CUST VARCHAR(20);
  DECLARE _$PSET_BC VARCHAR(10);
  DECLARE _$DAY_BC VARCHAR(10);
  DECLARE _$PAY_BC VARCHAR(10);
  DECLARE _$NAT_CD VARCHAR(10);
  DECLARE _$CURY_BC VARCHAR(10);
  DECLARE _$CURY_BC2 VARCHAR(10);
  DECLARE _$ZIP_CD VARCHAR(20);
  DECLARE _$ADDR1 VARCHAR(1000);
  DECLARE _$ADDR2 VARCHAR(1000);
  DECLARE _$ADDR_PRT VARCHAR(1000);
  DECLARE _$TEL VARCHAR(1000);
  DECLARE _$FAX VARCHAR(1000);
  DECLARE _$HOMEPAGE VARCHAR(1000);
  DECLARE _$ESERO VARCHAR(50);
  DECLARE _$EMAIL VARCHAR(50);
  DECLARE _$ETEL VARCHAR(50);
  DECLARE _$MAIN_CUST VARCHAR(20);
  DECLARE _$BIZ_NO VARCHAR(100);
  DECLARE _$BIZ_TYPE VARCHAR(50);
  DECLARE _$BIZ_KIND VARCHAR(50);
  DECLARE _$CEO_NM VARCHAR(100);
  DECLARE _$CEO_REG_NO VARCHAR(100);
  DECLARE _$SALES_AMT VARCHAR(50);
  DECLARE _$EMP_CNT VARCHAR(50);
  DECLARE _$ITEMS VARCHAR(1000);
  DECLARE _$TAX_NO VARCHAR(20);
  DECLARE _$ACCT_YN VARCHAR(1);
  DECLARE _$BANK_CD VARCHAR(20);
  DECLARE _$ACCT_NM VARCHAR(50);
  DECLARE _$ACCT_NO VARCHAR(50);
  DECLARE _$CO_NO VARCHAR(30);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$RPT_BC VARCHAR(10);
  DECLARE _$INSP_BC VARCHAR(10);
  DECLARE _$EXCH_BC VARCHAR(10);
  DECLARE _$EMP_NO VARCHAR(10);
  DECLARE _$RMKS VARCHAR(1000);
  DECLARE _$RMKS2 VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTCUST',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($CUST_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
    CALL COMSPLIT($CUST_NM_LIST, _$CUST_NM);
    CALL COMSPLIT($CUST_ENM_LIST, _$CUST_ENM);
    CALL COMSPLIT($PRT_NM_LIST, _$PRT_NM);
    CALL COMSPLIT($CO_CD_LIST, _$CO_CD);
    CALL COMSPLIT($GRP1_CD_LIST, _$GRP1_CD);
    CALL COMSPLIT($GRP2_CD_LIST, _$GRP2_CD);
    CALL COMSPLIT($GRP3_CD_LIST, _$GRP3_CD);
    CALL COMSPLIT($CUST_BC_LIST, _$CUST_BC);
    CALL COMSPLIT($CUST_KD_LIST, _$CUST_KD);
    CALL COMSPLIT($CO_KD_LIST, _$CO_KD);
    CALL COMSPLIT($MNG_KD_LIST, _$MNG_KD);
    CALL COMSPLIT($SIZE_BC_LIST, _$SIZE_BC);
    CALL COMSPLIT($LV_BC_LIST, _$LV_BC);
    CALL COMSPLIT($CREDIT_BC_LIST, _$CREDIT_BC);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($SAL_YN_LIST, _$SAL_YN);
    CALL COMSPLIT($PUR_YN_LIST, _$PUR_YN);
    CALL COMSPLIT($DE_BC_LIST, _$DE_BC);
    CALL COMSPLIT($DI_BC_LIST, _$DI_BC);
    CALL COMSPLIT($TAX_BC_LIST, _$TAX_BC);
    CALL COMSPLIT($ISS_BC_LIST, _$ISS_BC);
    CALL COMSPLIT($SAL_CUST_LIST, _$SAL_CUST);
    CALL COMSPLIT($PUR_CUST_LIST, _$PUR_CUST);
    CALL COMSPLIT($PSET_BC_LIST, _$PSET_BC);
    CALL COMSPLIT($DAY_BC_LIST, _$DAY_BC);
    CALL COMSPLIT($PAY_BC_LIST, _$PAY_BC);
    CALL COMSPLIT($NAT_CD_LIST, _$NAT_CD);
    CALL COMSPLIT($CURY_BC_LIST, _$CURY_BC);
    CALL COMSPLIT($CURY_BC2_LIST, _$CURY_BC2);
    CALL COMSPLIT($ZIP_CD_LIST, _$ZIP_CD);
    CALL COMSPLIT($ADDR1_LIST, _$ADDR1);
    CALL COMSPLIT($ADDR2_LIST, _$ADDR2);
    CALL COMSPLIT($ADDR_PRT_LIST, _$ADDR_PRT);
    CALL COMSPLIT($TEL_LIST, _$TEL);
    CALL COMSPLIT($FAX_LIST, _$FAX);
    CALL COMSPLIT($HOMEPAGE_LIST, _$HOMEPAGE);
    CALL COMSPLIT($ESERO_LIST, _$ESERO);
    CALL COMSPLIT($EMAIL_LIST, _$EMAIL);
    CALL COMSPLIT($ETEL_LIST, _$ETEL);
    CALL COMSPLIT($MAIN_CUST_LIST, _$MAIN_CUST);
    CALL COMSPLIT($BIZ_NO_LIST, _$BIZ_NO);
    CALL COMSPLIT($BIZ_TYPE_LIST, _$BIZ_TYPE);
    CALL COMSPLIT($BIZ_KIND_LIST, _$BIZ_KIND);
    CALL COMSPLIT($CEO_NM_LIST, _$CEO_NM);
    CALL COMSPLIT($CEO_REG_NO_LIST, _$CEO_REG_NO);
    CALL COMSPLIT($SALES_AMT_LIST, _$SALES_AMT);
    CALL COMSPLIT($EMP_CNT_LIST, _$EMP_CNT);
    CALL COMSPLIT($ITEMS_LIST, _$ITEMS);
    CALL COMSPLIT($TAX_NO_LIST, _$TAX_NO);
    CALL COMSPLIT($ACCT_YN_LIST, _$ACCT_YN);
    CALL COMSPLIT($BANK_CD_LIST, _$BANK_CD);
    CALL COMSPLIT($ACCT_NM_LIST, _$ACCT_NM);
    CALL COMSPLIT($ACCT_NO_LIST, _$ACCT_NO);
    CALL COMSPLIT($CO_NO_LIST, _$CO_NO);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
    CALL COMSPLIT($RPT_BC_LIST, _$RPT_BC);
    CALL COMSPLIT($INSP_BC_LIST, _$INSP_BC);
    CALL COMSPLIT($EXCH_BC_LIST, _$EXCH_BC);
    CALL COMSPLIT($EMP_NO_LIST, _$EMP_NO);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);
    CALL COMSPLIT($RMKS2_LIST, _$RMKS2);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY     = NULLIF(TRIM(_$IFKEY), '');
    SET _$SALES_AMT = NULLIF(TRIM(_$SALES_AMT), '');
    SET _$EMP_CNT   = NULLIF(TRIM(_$EMP_CNT), '');
    SET _$FR_DT     = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT     = NULLIF(TRIM(_$TO_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_CUST → MSTCUST
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTCUST
            WHERE CUSTCD = _$CUST_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTCUST
            (
                CUSTCD, CUSTNM, CUSTNMEN, CUSTNM_PRT, COMPANYCD, GPCD1, GPCD2, GPCD3,
                CUSTTP, CUST_KD, COM_KD, MNG_KD, SIZE_BC, LV_BC, CREDIT_BC,
                TRADESDT, TRADEEDT, SALYN, PURYN, DE_BC, DI_BC, TAX_BC, ISS_BC,
                CUSTSALCD, CUSTPURCD, PSET_BC, DAY_BC, PAY_BC, NATCD, CURY_BC, CURY_BC2,
                ZIP_CD, CUSTADDR1, CUSTADDR2, ADDR_PRT, REPRETEL, CUSTFAX, HOMEURL,
                ESERO, EMAIL, ETEL, CUSTMAIN, REGBUSSNUM, BIZTYPE_PRT, BIZKIND_PRT,
                PRESIDENT, REPREREGNO, SALES_AMT, EMP_CNT, TRADEITEM, TAXNO, ACCTYN,
                BANKCD, ACCTNM, ACCTNO, INCREGNO, USEYN, RPT_BC, INSP_BC, EXCH_BC,
                CHARGENO, REMARK, REMARK2, RTIME, REMP, RPRG
            )
            VALUES
            (
                _$CUST_CD, _$CUST_NM, _$CUST_ENM, _$PRT_NM, _$CO_CD, _$GRP1_CD, _$GRP2_CD, _$GRP3_CD,
                _$CUST_BC, _$CUST_KD, _$CO_KD, _$MNG_KD, _$SIZE_BC, _$LV_BC, _$CREDIT_BC,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$SAL_YN, _$PUR_YN, _$DE_BC, _$DI_BC, _$TAX_BC, _$ISS_BC,
                _$SAL_CUST, _$PUR_CUST, _$PSET_BC, _$DAY_BC, _$PAY_BC, _$NAT_CD, _$CURY_BC, _$CURY_BC2,
                _$ZIP_CD, _$ADDR1, _$ADDR2, _$ADDR_PRT, _$TEL, _$FAX, _$HOMEPAGE,
                _$ESERO, _$EMAIL, _$ETEL, _$MAIN_CUST, _$BIZ_NO, _$BIZ_TYPE, _$BIZ_KIND,
                _$CEO_NM, _$CEO_REG_NO,
                IFNULL(CONVERT(_$SALES_AMT, DECIMAL(15,0)), 0),
                IFNULL(CONVERT(_$EMP_CNT, SIGNED), 0),
                _$ITEMS, _$TAX_NO, _$ACCT_YN,
                _$BANK_CD, _$ACCT_NM, _$ACCT_NO, _$CO_NO, IF(_$USE_YN = '1', 'Y', 'N'), _$RPT_BC, _$INSP_BC, _$EXCH_BC,
                _$EMP_NO, _$RMKS, _$RMKS2, GETTIME(), 'ERP', 'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_CUST → MSTCUST
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTCUST
            WHERE CUSTCD = _$CUST_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTCUST
            (
                CUSTCD, CUSTNM, CUSTNMEN, CUSTNM_PRT, COMPANYCD, GPCD1, GPCD2, GPCD3,
                CUSTTP, CUST_KD, COM_KD, MNG_KD, SIZE_BC, LV_BC, CREDIT_BC,
                TRADESDT, TRADEEDT, SALYN, PURYN, DE_BC, DI_BC, TAX_BC, ISS_BC,
                CUSTSALCD, CUSTPURCD, PSET_BC, DAY_BC, PAY_BC, NATCD, CURY_BC, CURY_BC2,
                ZIP_CD, CUSTADDR1, CUSTADDR2, ADDR_PRT, REPRETEL, CUSTFAX, HOMEURL,
                ESERO, EMAIL, ETEL, CUSTMAIN, REGBUSSNUM, BIZTYPE_PRT, BIZKIND_PRT,
                PRESIDENT, REPREREGNO, SALES_AMT, EMP_CNT, TRADEITEM, TAXNO, ACCTYN,
                BANKCD, ACCTNM, ACCTNO, INCREGNO, USEYN, RPT_BC, INSP_BC, EXCH_BC,
                CHARGENO, REMARK, REMARK2, RTIME, REMP, RPRG
            )
            VALUES
            (
                _$CUST_CD, _$CUST_NM, _$CUST_ENM, _$PRT_NM, _$CO_CD, _$GRP1_CD, _$GRP2_CD, _$GRP3_CD,
                _$CUST_BC, _$CUST_KD, _$CO_KD, _$MNG_KD, _$SIZE_BC, _$LV_BC, _$CREDIT_BC,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$SAL_YN, _$PUR_YN, _$DE_BC, _$DI_BC, _$TAX_BC, _$ISS_BC,
                _$SAL_CUST, _$PUR_CUST, _$PSET_BC, _$DAY_BC, _$PAY_BC, _$NAT_CD, _$CURY_BC, _$CURY_BC2,
                _$ZIP_CD, _$ADDR1, _$ADDR2, _$ADDR_PRT, _$TEL, _$FAX, _$HOMEPAGE,
                _$ESERO, _$EMAIL, _$ETEL, _$MAIN_CUST, _$BIZ_NO, _$BIZ_TYPE, _$BIZ_KIND,
                _$CEO_NM, _$CEO_REG_NO,
                IFNULL(CONVERT(_$SALES_AMT, DECIMAL(15,0)), 0),
                IFNULL(CONVERT(_$EMP_CNT, SIGNED), 0),
                _$ITEMS, _$TAX_NO, _$ACCT_YN,
                _$BANK_CD, _$ACCT_NM, _$ACCT_NO, _$CO_NO, IF(_$USE_YN = '1', 'Y', 'N'), _$RPT_BC, _$INSP_BC, _$EXCH_BC,
                _$EMP_NO, _$RMKS, _$RMKS2, GETTIME(), 'ERP', 'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTCUST
            SET
                CUSTNM     = IF(_$CUST_NM <> '', _$CUST_NM, CUSTNM),
                CUSTNMEN   = IF(_$CUST_ENM <> '', _$CUST_ENM, CUSTNMEN),
                CUSTNM_PRT = IF(_$PRT_NM <> '', _$PRT_NM, CUSTNM_PRT),
                COMPANYCD  = IF(_$CO_CD <> '', _$CO_CD, COMPANYCD),
                GPCD1      = IF(_$GRP1_CD <> '', _$GRP1_CD, GPCD1),
                GPCD2      = IF(_$GRP2_CD <> '', _$GRP2_CD, GPCD2),
                GPCD3      = IF(_$GRP3_CD <> '', _$GRP3_CD, GPCD3),
                CUSTTP     = IF(_$CUST_BC <> '', _$CUST_BC, CUSTTP),
                CUST_KD    = IF(_$CUST_KD <> '', _$CUST_KD, CUST_KD),
                COM_KD     = IF(_$CO_KD <> '', _$CO_KD, COM_KD),
                MNG_KD     = IF(_$MNG_KD <> '', _$MNG_KD, MNG_KD),
                SIZE_BC    = IF(_$SIZE_BC <> '', _$SIZE_BC, SIZE_BC),
                LV_BC      = IF(_$LV_BC <> '', _$LV_BC, LV_BC),
                CREDIT_BC  = IF(_$CREDIT_BC <> '', _$CREDIT_BC, CREDIT_BC),
                TRADESDT   = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                TRADEEDT   = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                SALYN      = IF(_$SAL_YN <> '', _$SAL_YN, SALYN),
                PURYN      = IF(_$PUR_YN <> '', _$PUR_YN, PURYN),
                DE_BC      = IF(_$DE_BC <> '', _$DE_BC, DE_BC),
                DI_BC      = IF(_$DI_BC <> '', _$DI_BC, DI_BC),
                TAX_BC     = IF(_$TAX_BC <> '', _$TAX_BC, TAX_BC),
                ISS_BC     = IF(_$ISS_BC <> '', _$ISS_BC, ISS_BC),
                CUSTSALCD  = IF(_$SAL_CUST <> '', _$SAL_CUST, CUSTSALCD),
                CUSTPURCD  = IF(_$PUR_CUST <> '', _$PUR_CUST, CUSTPURCD),
                PSET_BC    = IF(_$PSET_BC <> '', _$PSET_BC, PSET_BC),
                DAY_BC     = IF(_$DAY_BC <> '', _$DAY_BC, DAY_BC),
                PAY_BC     = IF(_$PAY_BC <> '', _$PAY_BC, PAY_BC),
                NATCD      = IF(_$NAT_CD <> '', _$NAT_CD, NATCD),
                CURY_BC    = IF(_$CURY_BC <> '', _$CURY_BC, CURY_BC),
                CURY_BC2   = IF(_$CURY_BC2 <> '', _$CURY_BC2, CURY_BC2),
                ZIP_CD     = IF(_$ZIP_CD <> '', _$ZIP_CD, ZIP_CD),
                CUSTADDR1  = IF(_$ADDR1 <> '', _$ADDR1, CUSTADDR1),
                CUSTADDR2  = IF(_$ADDR2 <> '', _$ADDR2, CUSTADDR2),
                ADDR_PRT   = IF(_$ADDR_PRT <> '', _$ADDR_PRT, ADDR_PRT),
                REPRETEL   = IF(_$TEL <> '', _$TEL, REPRETEL),
                CUSTFAX    = IF(_$FAX <> '', _$FAX, CUSTFAX),
                HOMEURL    = IF(_$HOMEPAGE <> '', _$HOMEPAGE, HOMEURL),
                ESERO      = IF(_$ESERO <> '', _$ESERO, ESERO),
                EMAIL      = IF(_$EMAIL <> '', _$EMAIL, EMAIL),
                ETEL       = IF(_$ETEL <> '', _$ETEL, ETEL),
                CUSTMAIN   = IF(_$MAIN_CUST <> '', _$MAIN_CUST, CUSTMAIN),
                REGBUSSNUM = IF(_$BIZ_NO <> '', _$BIZ_NO, REGBUSSNUM),
                BIZTYPE_PRT= IF(_$BIZ_TYPE <> '', _$BIZ_TYPE, BIZTYPE_PRT),
                BIZKIND_PRT= IF(_$BIZ_KIND <> '', _$BIZ_KIND, BIZKIND_PRT),
                PRESIDENT  = IF(_$CEO_NM <> '', _$CEO_NM, PRESIDENT),
                REPREREGNO = IF(_$CEO_REG_NO <> '', _$CEO_REG_NO, REPREREGNO),
                SALES_AMT  = IFNULL(CONVERT(_$SALES_AMT, DECIMAL(15,0)), 0),
                EMP_CNT    = IFNULL(CONVERT(_$EMP_CNT, SIGNED), 0),
                TRADEITEM  = IF(_$ITEMS <> '', _$ITEMS, TRADEITEM),
                TAXNO      = IF(_$TAX_NO <> '', _$TAX_NO, TAXNO),
                ACCTYN     = IF(_$ACCT_YN <> '', _$ACCT_YN, ACCTYN),
                BANKCD     = IF(_$BANK_CD <> '', _$BANK_CD, BANKCD),
                ACCTNM     = IF(_$ACCT_NM <> '', _$ACCT_NM, ACCTNM),
                ACCTNO     = IF(_$ACCT_NO <> '', _$ACCT_NO, ACCTNO),
                INCREGNO   = IF(_$CO_NO <> '', _$CO_NO, INCREGNO),
                USEYN      = IF(_$USE_YN <> '', IF(_$USE_YN = '1', 'Y', 'N'), USEYN),
                RPT_BC     = IF(_$RPT_BC <> '', _$RPT_BC, RPT_BC),
                INSP_BC    = IF(_$INSP_BC <> '', _$INSP_BC, INSP_BC),
                EXCH_BC    = IF(_$EXCH_BC <> '', _$EXCH_BC, EXCH_BC),
                CHARGENO   = IF(_$EMP_NO <> '', _$EMP_NO, CHARGENO),
                REMARK     = IF(_$RMKS <> '', _$RMKS, REMARK),
                REMARK2    = IF(_$RMKS2 <> '', _$RMKS2, REMARK2),
                MTIME      = GETTIME(),
                MEMP       = 'ERP',
                MPRG       = 'IF'
            WHERE CUSTCD = _$CUST_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_CUST → MSTCUST
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTCUST
        WHERE CUSTCD = _$CUST_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTCUST';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTCUST';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTCUST_DETAIL`$$
CREATE PROCEDURE `MES_IF_MSTCUST_DETAIL`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $CUST_CD_LIST MEDIUMTEXT,         -- 거래처코드 (PK)
  IN $CO_CD_LIST MEDIUMTEXT,           -- 법인코드 (PK)
  IN $SAL_YN_LIST MEDIUMTEXT,          -- 매출여부
  IN $DE_BC_LIST MEDIUMTEXT,           -- 지역구분
  IN $SAL_TAX_BC_LIST MEDIUMTEXT,      -- 매출부가세구분
  IN $SAL_CUST_LIST MEDIUMTEXT,        -- 매출정산거래처코드
  IN $SAL_KD_LIST MEDIUMTEXT,          -- 판매구분
  IN $DC_RT_LIST MEDIUMTEXT,           -- 할인율
  IN $TRAN_BC_LIST MEDIUMTEXT,         -- 운송방법
  IN $SSET_BC_LIST MEDIUMTEXT,         -- 판매설정구분
  IN $SAL_RID_LIST MEDIUMTEXT,         -- 매출담당자
  IN $RPT_BC_LIST MEDIUMTEXT,          -- 신고구분
  IN $PUR_YN_LIST MEDIUMTEXT,          -- 매입여부
  IN $DI_BC_LIST MEDIUMTEXT,           -- 매입지역구분
  IN $PUR_TAX_BC_LIST MEDIUMTEXT,      -- 매입부가세구분
  IN $PUR_CUST_LIST MEDIUMTEXT,        -- 매입정산거래처코드
  IN $PSET_BC_LIST MEDIUMTEXT,         -- 결제조건
  IN $DAY_BC_LIST MEDIUMTEXT,          -- 지급일조건
  IN $PAY_BC_LIST MEDIUMTEXT,          -- 지급구분
  IN $PUR_RID_LIST MEDIUMTEXT,         -- 매입담당ID
  IN $LOC_YN_LIST MEDIUMTEXT           -- 현지여부 (loc_yn)
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$CO_CD VARCHAR(10);
  DECLARE _$SAL_YN VARCHAR(1);
  DECLARE _$DE_BC VARCHAR(10);
  DECLARE _$SAL_TAX_BC VARCHAR(10);
  DECLARE _$SAL_CUST VARCHAR(20);
  DECLARE _$SAL_KD VARCHAR(10);
  DECLARE _$DC_RT VARCHAR(50);
  DECLARE _$TRAN_BC VARCHAR(10);
  DECLARE _$SSET_BC VARCHAR(10);
  DECLARE _$SAL_RID VARCHAR(50);
  DECLARE _$RPT_BC VARCHAR(10);
  DECLARE _$PUR_YN VARCHAR(1);
  DECLARE _$DI_BC VARCHAR(10);
  DECLARE _$PUR_TAX_BC VARCHAR(10);
  DECLARE _$PUR_CUST VARCHAR(20);
  DECLARE _$PSET_BC VARCHAR(10);
  DECLARE _$DAY_BC VARCHAR(10);
  DECLARE _$PAY_BC VARCHAR(10);
  DECLARE _$PUR_RID VARCHAR(50);
  DECLARE _$LOC_YN VARCHAR(1);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTCUST_DETAIL',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($CUST_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
    CALL COMSPLIT($CO_CD_LIST, _$CO_CD);
    CALL COMSPLIT($SAL_YN_LIST, _$SAL_YN);
    CALL COMSPLIT($DE_BC_LIST, _$DE_BC);
    CALL COMSPLIT($SAL_TAX_BC_LIST, _$SAL_TAX_BC);
    CALL COMSPLIT($SAL_CUST_LIST, _$SAL_CUST);
    CALL COMSPLIT($SAL_KD_LIST, _$SAL_KD);
    CALL COMSPLIT($DC_RT_LIST, _$DC_RT);
    CALL COMSPLIT($TRAN_BC_LIST, _$TRAN_BC);
    CALL COMSPLIT($SSET_BC_LIST, _$SSET_BC);
    CALL COMSPLIT($SAL_RID_LIST, _$SAL_RID);
    CALL COMSPLIT($RPT_BC_LIST, _$RPT_BC);
    CALL COMSPLIT($PUR_YN_LIST, _$PUR_YN);
    CALL COMSPLIT($DI_BC_LIST, _$DI_BC);
    CALL COMSPLIT($PUR_TAX_BC_LIST, _$PUR_TAX_BC);
    CALL COMSPLIT($PUR_CUST_LIST, _$PUR_CUST);
    CALL COMSPLIT($PSET_BC_LIST, _$PSET_BC);
    CALL COMSPLIT($DAY_BC_LIST, _$DAY_BC);
    CALL COMSPLIT($PAY_BC_LIST, _$PAY_BC);
    CALL COMSPLIT($PUR_RID_LIST, _$PUR_RID);
    CALL COMSPLIT($LOC_YN_LIST, _$LOC_YN);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자)
    -- *************************************************************
    SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
    SET _$DC_RT   = NULLIF(TRIM(_$DC_RT), '');
    SET _$SAL_RID = NULLIF(TRIM(_$SAL_RID), '');
    SET _$PUR_RID = NULLIF(TRIM(_$PUR_RID), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_CUST_DTL → MSTCUST_DETAIL
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTCUST_DETAIL
          WHERE CUSTCD    = _$CUST_CD
            AND COMPANYCD = _$CO_CD
      )
      THEN
  
          INSERT INTO MES_SNS2.MSTCUST_DETAIL
          (
              CUSTCD,
              COMPANYCD,
              SALYN,
              DE_BC,
              SAL_TAX_BC,
              CUSTSALCD,
              SAL_KD,
              DC_RT,
              TRAN_BC,
              SSET_BC,
              SAL_RID,
              RPT_BC,
              PURYN,
              DI_BC,
              PUR_TAX_BC,
              CUSTPURCD,
              PSET_BC,
              DAY_BC,
              PAY_BC,
              PUR_RID,
              LOC_YN,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$CUST_CD,
              _$CO_CD,
              IF(_$SAL_YN = '1', 'Y', 'N'),
              _$DE_BC,
              _$SAL_TAX_BC,
              _$SAL_CUST,
              _$SAL_KD,
              IFNULL(CONVERT(_$DC_RT, DECIMAL(10,2)), 0),
              _$TRAN_BC,
              _$SSET_BC,
              IFNULL(CONVERT(_$SAL_RID, SIGNED), 0),
              _$RPT_BC,
              _$PUR_YN,
              _$DI_BC,
              _$PUR_TAX_BC,
              _$PUR_CUST,
              _$PSET_BC,
              _$DAY_BC,
              _$PAY_BC,
              IFNULL(CONVERT(_$PUR_RID, SIGNED), 0),
              _$LOC_YN,
              GETTIME(),
              'ERP',
              'IF'
          );
  
      END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_CUST_DTL → MSTCUST_DETAIL
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTCUST_DETAIL
            WHERE CUSTCD    = _$CUST_CD
              AND COMPANYCD = _$CO_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTCUST_DETAIL
            (
                CUSTCD,
                COMPANYCD,
                SALYN,
                DE_BC,
                SAL_TAX_BC,
                CUSTSALCD,
                SAL_KD,
                DC_RT,
                TRAN_BC,
                SSET_BC,
                SAL_RID,
                RPT_BC,
                PURYN,
                DI_BC,
                PUR_TAX_BC,
                CUSTPURCD,
                PSET_BC,
                DAY_BC,
                PAY_BC,
                PUR_RID,
                LOC_YN,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$CUST_CD,
                _$CO_CD,
                IF(_$SAL_YN = '1', 'Y', 'N'),
                _$DE_BC,
                _$SAL_TAX_BC,
                _$SAL_CUST,
                _$SAL_KD,
                IFNULL(CONVERT(_$DC_RT, DECIMAL(10,2)), 0),
                _$TRAN_BC,
                _$SSET_BC,
                IFNULL(CONVERT(_$SAL_RID, SIGNED), 0),
                _$RPT_BC,
                _$PUR_YN,
                _$DI_BC,
                _$PUR_TAX_BC,
                _$PUR_CUST,
                _$PSET_BC,
                _$DAY_BC,
                _$PAY_BC,
                IFNULL(CONVERT(_$PUR_RID, SIGNED), 0),
                _$LOC_YN,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTCUST_DETAIL
            SET
                SALYN      = IF(_$SAL_YN <> '', IF(_$SAL_YN = '1', 'Y', 'N'), SALYN),
                DE_BC      = IF(_$DE_BC <> '', _$DE_BC, DE_BC),
                SAL_TAX_BC = IF(_$SAL_TAX_BC <> '', _$SAL_TAX_BC, SAL_TAX_BC),
                CUSTSALCD  = IF(_$SAL_CUST <> '', _$SAL_CUST, CUSTSALCD),
                SAL_KD     = IF(_$SAL_KD <> '', _$SAL_KD, SAL_KD),
                DC_RT      = IFNULL(CONVERT(_$DC_RT, DECIMAL(10,2)), 0),
                TRAN_BC    = IF(_$TRAN_BC <> '', _$TRAN_BC, TRAN_BC),
                SSET_BC    = IF(_$SSET_BC <> '', _$SSET_BC, SSET_BC),
                SAL_RID    = IFNULL(CONVERT(_$SAL_RID, SIGNED), 0),
                RPT_BC     = IF(_$RPT_BC <> '', _$RPT_BC, RPT_BC),
                PURYN      = IF(_$PUR_YN <> '', _$PUR_YN, PURYN),
                DI_BC      = IF(_$DI_BC <> '', _$DI_BC, DI_BC),
                PUR_TAX_BC = IF(_$PUR_TAX_BC <> '', _$PUR_TAX_BC, PUR_TAX_BC),
                CUSTPURCD  = IF(_$PUR_CUST <> '', _$PUR_CUST, CUSTPURCD),
                PSET_BC    = IF(_$PSET_BC <> '', _$PSET_BC, PSET_BC),
                DAY_BC     = IF(_$DAY_BC <> '', _$DAY_BC, DAY_BC),
                PAY_BC     = IF(_$PAY_BC <> '', _$PAY_BC, PAY_BC),
                PUR_RID    = IFNULL(CONVERT(_$PUR_RID, SIGNED), 0),
                LOC_YN     = IF(_$LOC_YN <> '', _$LOC_YN, LOC_YN),
                MTIME      = GETTIME(),
                MEMP       = 'ERP',
                MPRG       = 'IF'
            WHERE CUSTCD    = _$CUST_CD
              AND COMPANYCD = _$CO_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_CUST_DTL → MSTCUST_DETAIL
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTCUST_DETAIL
        WHERE CUSTCD    = _$CUST_CD
          AND COMPANYCD = _$CO_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTCUST_DETAIL';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTCUST_DETAIL';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTDEPT`$$
CREATE PROCEDURE `MES_IF_MSTDEPT`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $DEPT_CD_LIST MEDIUMTEXT,         -- 부서코드 (PK)
  IN $DEPT_NM_LIST MEDIUMTEXT,         -- 부서명
  IN $DEPT_ENM_LIST MEDIUMTEXT,        -- 부서영문명
  IN $APP_DT_LIST MEDIUMTEXT,          -- 변경적용일
  IN $BS_CD_LIST MEDIUMTEXT,           -- 사업장코드
  IN $DIV_CD_LIST MEDIUMTEXT,          -- 회계단위코드
  IN $CC_CD_LIST MEDIUMTEXT,           -- 원가부문코드
  IN $GRP_CD_LIST MEDIUMTEXT,          -- 사업부코드
  IN $UP_DEPT_LIST MEDIUMTEXT,         -- 상위부서코드
  IN $ACC_DEPT_LIST MEDIUMTEXT,        -- 전표부서코드
  IN $BUD_DEPT_LIST MEDIUMTEXT,        -- 예산부서코드
  IN $DEPT_BC_LIST MEDIUMTEXT,         -- 부서구분
  IN $DEPT_KD_LIST MEDIUMTEXT,         -- 부서유형
  IN $GRP1_BC_LIST MEDIUMTEXT,         -- 분류구분1
  IN $GRP2_BC_LIST MEDIUMTEXT,         -- 분류구분2
  IN $GRP3_BC_LIST MEDIUMTEXT,         -- 분류구분3
  IN $WORK_BC_LIST MEDIUMTEXT,         -- 직군구분
  IN $RT_KD_LIST MEDIUMTEXT,           -- 임율분류
  IN $RT_BC_LIST MEDIUMTEXT,           -- 임율구분
  IN $BUD_YN_LIST MEDIUMTEXT,          -- 예산관리여부
  IN $TO_YN_LIST MEDIUMTEXT,           -- T/O관리여부
  IN $HEAD_EMP_LIST MEDIUMTEXT,        -- 부서장사번
  IN $OLD_DEPT_LIST MEDIUMTEXT,        -- 구부서코드
  IN $TREE_YN_LIST MEDIUMTEXT,         -- 조직도출력여부
  IN $PRT_SQ_LIST MEDIUMTEXT,          -- 출력순번
  IN $FLD_YN_LIST MEDIUMTEXT,          -- 현장여부
  IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
  IN $FR_DT_LIST MEDIUMTEXT,           -- 생성일(시작일)
  IN $TO_DT_LIST MEDIUMTEXT,           -- 종료일
  IN $AUTO_YN_LIST MEDIUMTEXT,         -- 부서이력에 의한 등록여부
  IN $RMKS_LIST MEDIUMTEXT,            -- 비고

  IN $CID_LIST MEDIUMTEXT,             -- 등록자ID
  IN $CDT_LIST MEDIUMTEXT,             -- 등록일
  IN $MID_LIST MEDIUMTEXT,             -- 수정자ID
  IN $MDT_LIST MEDIUMTEXT,             -- 수정일
  IN $OLD_DEPT_CD_LIST MEDIUMTEXT      -- 구부서코드2
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$DEPT_CD VARCHAR(10);
  DECLARE _$DEPT_NM VARCHAR(100);
  DECLARE _$DEPT_ENM VARCHAR(100);
  DECLARE _$APP_DT VARCHAR(50);
  DECLARE _$BS_CD VARCHAR(10);
  DECLARE _$DIV_CD VARCHAR(10);
  DECLARE _$CC_CD VARCHAR(10);
  DECLARE _$GRP_CD VARCHAR(10);
  DECLARE _$UP_DEPT VARCHAR(10);
  DECLARE _$ACC_DEPT VARCHAR(10);
  DECLARE _$BUD_DEPT VARCHAR(10);
  DECLARE _$DEPT_BC VARCHAR(10);
  DECLARE _$DEPT_KD VARCHAR(10);
  DECLARE _$GRP1_BC VARCHAR(10);
  DECLARE _$GRP2_BC VARCHAR(10);
  DECLARE _$GRP3_BC VARCHAR(10);
  DECLARE _$WORK_BC VARCHAR(10);
  DECLARE _$RT_KD VARCHAR(10);
  DECLARE _$RT_BC VARCHAR(10);
  DECLARE _$BUD_YN VARCHAR(1);
  DECLARE _$TO_YN VARCHAR(1);
  DECLARE _$HEAD_EMP VARCHAR(20);
  DECLARE _$OLD_DEPT VARCHAR(10);
  DECLARE _$TREE_YN VARCHAR(1);
  DECLARE _$PRT_SQ VARCHAR(50);
  DECLARE _$FLD_YN VARCHAR(1);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$AUTO_YN VARCHAR(1);
  DECLARE _$RMKS VARCHAR(100);

  DECLARE _$OLD_DEPT_CD VARCHAR(20);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTDEPT',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($DEPT_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($DEPT_CD_LIST, _$DEPT_CD);
    CALL COMSPLIT($DEPT_NM_LIST, _$DEPT_NM);
    CALL COMSPLIT($DEPT_ENM_LIST, _$DEPT_ENM);
    CALL COMSPLIT($APP_DT_LIST, _$APP_DT);
    CALL COMSPLIT($BS_CD_LIST, _$BS_CD);
    CALL COMSPLIT($DIV_CD_LIST, _$DIV_CD);
    CALL COMSPLIT($CC_CD_LIST, _$CC_CD);
    CALL COMSPLIT($GRP_CD_LIST, _$GRP_CD);
    CALL COMSPLIT($UP_DEPT_LIST, _$UP_DEPT);
    CALL COMSPLIT($ACC_DEPT_LIST, _$ACC_DEPT);
    CALL COMSPLIT($BUD_DEPT_LIST, _$BUD_DEPT);
    CALL COMSPLIT($DEPT_BC_LIST, _$DEPT_BC);
    CALL COMSPLIT($DEPT_KD_LIST, _$DEPT_KD);
    CALL COMSPLIT($GRP1_BC_LIST, _$GRP1_BC);
    CALL COMSPLIT($GRP2_BC_LIST, _$GRP2_BC);
    CALL COMSPLIT($GRP3_BC_LIST, _$GRP3_BC);
    CALL COMSPLIT($WORK_BC_LIST, _$WORK_BC);
    CALL COMSPLIT($RT_KD_LIST, _$RT_KD);
    CALL COMSPLIT($RT_BC_LIST, _$RT_BC);
    CALL COMSPLIT($BUD_YN_LIST, _$BUD_YN);
    CALL COMSPLIT($TO_YN_LIST, _$TO_YN);
    CALL COMSPLIT($HEAD_EMP_LIST, _$HEAD_EMP);
    CALL COMSPLIT($OLD_DEPT_LIST, _$OLD_DEPT);
    CALL COMSPLIT($TREE_YN_LIST, _$TREE_YN);
    CALL COMSPLIT($PRT_SQ_LIST, _$PRT_SQ);
    CALL COMSPLIT($FLD_YN_LIST, _$FLD_YN);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($AUTO_YN_LIST, _$AUTO_YN);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    CALL COMSPLIT($OLD_DEPT_CD_LIST, _$OLD_DEPT_CD);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY  = NULLIF(TRIM(_$IFKEY), '');
    SET _$PRT_SQ = NULLIF(TRIM(_$PRT_SQ), '');
    SET _$APP_DT = NULLIF(TRIM(_$APP_DT), '');
    SET _$FR_DT  = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT  = NULLIF(TRIM(_$TO_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_DEPT → MSTDEPT
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTDEPT
            WHERE DEPTCD = _$DEPT_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTDEPT
            (
                DEPTCD,
                DEPTNM,
                DEPT_ENM,
                APPDT,
                BDVCD,
                DIVCD,
                CCCD,
                GRPCD,
                UPDEPT,
                ACCDEPT,
                BUDDEPT,
                DEPTBC,
                DEPTKD,
                GRP1BC,
                GRP2BC,
                GRP3BC,
                WORKBC,
                RTKD,
                RTBC,
                BUDYN,
                TOYN,
                HEADEMP,
                OLD_DEPTCD,
                TMLYN,
                PRTSQ,
                FLDYN,
                USEYN,
                SDT,
                EDT,
                AUTOYN,
                OLD_DEPT_CD,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$DEPT_CD,
                _$DEPT_NM,
                _$DEPT_ENM,
                IF(_$APP_DT IS NULL, NULL, LEFT(GETDATETIME(_$APP_DT), 8)),
                _$BS_CD,
                _$DIV_CD,
                _$CC_CD,
                _$GRP_CD,
                _$UP_DEPT,
                _$ACC_DEPT,
                _$BUD_DEPT,
                _$DEPT_BC,
                _$DEPT_KD,
                _$GRP1_BC,
                _$GRP2_BC,
                _$GRP3_BC,
                _$WORK_BC,
                _$RT_KD,
                _$RT_BC,
                _$BUD_YN,
                _$TO_YN,
                _$HEAD_EMP,
                _$OLD_DEPT,
                _$TREE_YN,
                IFNULL(CONVERT(_$PRT_SQ, SIGNED), 0),
                _$FLD_YN,
                _$USE_YN,
                IF(_$FR_DT IS NULL, NULL, LEFT(GETDATETIME(_$FR_DT), 8)),
                IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                _$AUTO_YN,
                _$OLD_DEPT_CD,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_DEPT → MSTDEPT
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTDEPT
            WHERE DEPTCD = _$DEPT_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTDEPT
            (
                DEPTCD,
                DEPTNM,
                DEPT_ENM,
                APPDT,
                BDVCD,
                DIVCD,
                CCCD,
                GRPCD,
                UPDEPT,
                ACCDEPT,
                BUDDEPT,
                DEPTBC,
                DEPTKD,
                GRP1BC,
                GRP2BC,
                GRP3BC,
                WORKBC,
                RTKD,
                RTBC,
                BUDYN,
                TOYN,
                HEADEMP,
                OLD_DEPTCD,
                TMLYN,
                PRTSQ,
                FLDYN,
                USEYN,
                SDT,
                EDT,
                AUTOYN,
                OLD_DEPT_CD,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$DEPT_CD,
                _$DEPT_NM,
                _$DEPT_ENM,
                IF(_$APP_DT IS NULL, NULL, LEFT(GETDATETIME(_$APP_DT), 8)),
                _$BS_CD,
                _$DIV_CD,
                _$CC_CD,
                _$GRP_CD,
                _$UP_DEPT,
                _$ACC_DEPT,
                _$BUD_DEPT,
                _$DEPT_BC,
                _$DEPT_KD,
                _$GRP1_BC,
                _$GRP2_BC,
                _$GRP3_BC,
                _$WORK_BC,
                _$RT_KD,
                _$RT_BC,
                _$BUD_YN,
                _$TO_YN,
                _$HEAD_EMP,
                _$OLD_DEPT,
                _$TREE_YN,
                IFNULL(CONVERT(_$PRT_SQ, SIGNED), 0),
                _$FLD_YN,
                _$USE_YN,
                IF(_$FR_DT IS NULL, NULL, LEFT(GETDATETIME(_$FR_DT), 8)),
                IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                _$AUTO_YN,
                _$OLD_DEPT_CD,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTDEPT
            SET
                DEPTNM      = IF(_$DEPT_NM <> '', _$DEPT_NM, DEPTNM),
                DEPT_ENM    = IF(_$DEPT_ENM <> '', _$DEPT_ENM, DEPT_ENM),
                APPDT       = IF(_$APP_DT IS NULL, NULL, LEFT(GETDATETIME(_$APP_DT), 8)),
                BDVCD       = IF(_$BS_CD <> '', _$BS_CD, BDVCD),
                DIVCD       = IF(_$DIV_CD <> '', _$DIV_CD, DIVCD),
                CCCD        = IF(_$CC_CD <> '', _$CC_CD, CCCD),
                GRPCD       = IF(_$GRP_CD <> '', _$GRP_CD, GRPCD),
                UPDEPT      = IF(_$UP_DEPT <> '', _$UP_DEPT, UPDEPT),
                ACCDEPT     = IF(_$ACC_DEPT <> '', _$ACC_DEPT, ACCDEPT),
                BUDDEPT     = IF(_$BUD_DEPT <> '', _$BUD_DEPT, BUDDEPT),
                DEPTBC      = IF(_$DEPT_BC <> '', _$DEPT_BC, DEPTBC),
                DEPTKD      = IF(_$DEPT_KD <> '', _$DEPT_KD, DEPTKD),
                GRP1BC      = IF(_$GRP1_BC <> '', _$GRP1_BC, GRP1BC),
                GRP2BC      = IF(_$GRP2_BC <> '', _$GRP2_BC, GRP2BC),
                GRP3BC      = IF(_$GRP3_BC <> '', _$GRP3_BC, GRP3BC),
                WORKBC      = IF(_$WORK_BC <> '', _$WORK_BC, WORKBC),
                RTKD        = IF(_$RT_KD <> '', _$RT_KD, RTKD),
                RTBC        = IF(_$RT_BC <> '', _$RT_BC, RTBC),
                BUDYN       = IF(_$BUD_YN <> '', _$BUD_YN, BUDYN),
                TOYN        = IF(_$TO_YN <> '', _$TO_YN, TOYN),
                HEADEMP     = IF(_$HEAD_EMP <> '', _$HEAD_EMP, HEADEMP),
                OLD_DEPTCD  = IF(_$OLD_DEPT <> '', _$OLD_DEPT, OLD_DEPTCD),
                TMLYN       = IF(_$TREE_YN <> '', _$TREE_YN, TMLYN),
                PRTSQ       = IFNULL(CONVERT(_$PRT_SQ, SIGNED), 0),
                FLDYN       = IF(_$FLD_YN <> '', _$FLD_YN, FLDYN),
                USEYN       = IF(_$USE_YN <> '', _$USE_YN, USEYN),
                SDT         = IF(_$FR_DT IS NULL, NULL, LEFT(GETDATETIME(_$FR_DT), 8)),
                EDT         = IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                AUTOYN      = IF(_$AUTO_YN <> '', _$AUTO_YN, AUTOYN),
                OLD_DEPT_CD = IF(_$OLD_DEPT_CD <> '', _$OLD_DEPT_CD, OLD_DEPT_CD),
                REMARK      = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME       = GETTIME(),
                MEMP        = 'ERP',
                MPRG        = 'IF'
            WHERE DEPTCD = _$DEPT_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_DEPT → MSTDEPT
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTDEPT
        WHERE DEPTCD = _$DEPT_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTDEPT';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTDEPT';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTEMP`$$
CREATE PROCEDURE `MES_IF_MSTEMP`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $ID_LIST MEDIUMTEXT,              -- 아이디 (PK)
  IN $EMP_NO_LIST MEDIUMTEXT,          -- 사번
  IN $EMP_NM_LIST MEDIUMTEXT,          -- 성명
  IN $BIR_DT_LIST MEDIUMTEXT,          -- 생년월일
  IN $GEN_TY_LIST MEDIUMTEXT,          -- 성별구분
  IN $BS_CD_LIST MEDIUMTEXT,           -- 사업장코드
  IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드
  IN $DEPT_CD_LIST MEDIUMTEXT,         -- 부서코드
  IN $WORK_BC_LIST MEDIUMTEXT,         -- 근무직구분
  IN $HIGH_BC_LIST MEDIUMTEXT,         -- 직위구분
  IN $DUTY_BC_LIST MEDIUMTEXT,         -- 직책구분
  IN $STAT_BC_LIST MEDIUMTEXT,         -- 진행상태
  IN $EMAIL_LIST MEDIUMTEXT,           -- Email
  IN $MOBILE_LIST MEDIUMTEXT,          -- 핸드폰
  IN $DEPT_TEL_LIST MEDIUMTEXT,        -- 부서전화
  IN $OLD_EMP_NO_LIST MEDIUMTEXT       -- 구사번
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ID VARCHAR(50);
  DECLARE _$EMP_NO VARCHAR(20);
  DECLARE _$EMP_NM VARCHAR(50);
  DECLARE _$BIR_DT VARCHAR(10);
  DECLARE _$GEN_TY VARCHAR(10);
  DECLARE _$BS_CD VARCHAR(10);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$DEPT_CD VARCHAR(10);
  DECLARE _$WORK_BC VARCHAR(10);
  DECLARE _$HIGH_BC VARCHAR(10);
  DECLARE _$DUTY_BC VARCHAR(10);
  DECLARE _$STAT_BC VARCHAR(10);
  DECLARE _$EMAIL VARCHAR(100);
  DECLARE _$MOBILE VARCHAR(50);
  DECLARE _$DEPT_TEL VARCHAR(50);
  DECLARE _$OLD_EMP_NO VARCHAR(50);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTEMP',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ID_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($ID_LIST, _$ID);
    CALL COMSPLIT($EMP_NO_LIST, _$EMP_NO);
    CALL COMSPLIT($EMP_NM_LIST, _$EMP_NM);
    CALL COMSPLIT($BIR_DT_LIST, _$BIR_DT);
    CALL COMSPLIT($GEN_TY_LIST, _$GEN_TY);
    CALL COMSPLIT($BS_CD_LIST, _$BS_CD);
    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
    CALL COMSPLIT($DEPT_CD_LIST, _$DEPT_CD);
    CALL COMSPLIT($WORK_BC_LIST, _$WORK_BC);
    CALL COMSPLIT($HIGH_BC_LIST, _$HIGH_BC);
    CALL COMSPLIT($DUTY_BC_LIST, _$DUTY_BC);
    CALL COMSPLIT($STAT_BC_LIST, _$STAT_BC);
    CALL COMSPLIT($EMAIL_LIST, _$EMAIL);
    CALL COMSPLIT($MOBILE_LIST, _$MOBILE);
    CALL COMSPLIT($DEPT_TEL_LIST, _$DEPT_TEL);
    CALL COMSPLIT($OLD_EMP_NO_LIST, _$OLD_EMP_NO);

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = _$IFKEY;
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_EMP → MSTEMP
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTEMP
            WHERE EMPID = _$ID
              AND EMPCD = _$EMP_NO
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTEMP
            (
                EMPID,
                EMPCD,
                EMPNM,
                BIRTHDT,
                GENDERTP,
                BDVCD,
                FACTORYCD,
                DEPTCD,
                WORKTP,
                POSBC,
                DUTYBC,
                STATBC,
                EMAIL,
                MOBILE,
                DEPTTEL,
                OLDEMPCD,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$ID,
                _$EMP_NO,
                _$EMP_NM,
                _$BIR_DT,
                _$GEN_TY,
                _$BS_CD,
                _$FAC_CD,
                _$DEPT_CD,
                _$WORK_BC,
                _$HIGH_BC,
                _$DUTY_BC,
                _$STAT_BC,
                _$EMAIL,
                _$MOBILE,
                _$DEPT_TEL,
                _$OLD_EMP_NO,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_EMP → MSTEMP
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTEMP
            WHERE EMPID = _$ID
              AND EMPCD = _$EMP_NO
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTEMP
            (
                EMPID,
                EMPCD,
                EMPNM,
                BIRTHDT,
                GENDERTP,
                BDVCD,
                FACTORYCD,
                DEPTCD,
                WORKTP,
                POSBC,
                DUTYBC,
                STATBC,
                EMAIL,
                MOBILE,
                DEPTTEL,
                OLDEMPCD,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$ID,
                _$EMP_NO,
                _$EMP_NM,
                _$BIR_DT,
                _$GEN_TY,
                _$BS_CD,
                _$FAC_CD,
                _$DEPT_CD,
                _$WORK_BC,
                _$HIGH_BC,
                _$DUTY_BC,
                _$STAT_BC,
                _$EMAIL,
                _$MOBILE,
                _$DEPT_TEL,
                _$OLD_EMP_NO,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTEMP
            SET
                EMPID     = IF(_$ID <> '', _$ID, EMPID),
                EMPCD     = IF(_$EMP_NO <> '', _$EMP_NO, EMPCD),
                EMPNM     = IF(_$EMP_NM <> '', _$EMP_NM, EMPNM),
                BIRTHDT   = IF(_$BIR_DT <> '', _$BIR_DT, BIRTHDT),
                GENDERTP  = IF(_$GEN_TY <> '', _$GEN_TY, GENDERTP),
                BDVCD     = IF(_$BS_CD <> '', _$BS_CD, BDVCD),
                FACTORYCD = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
                DEPTCD    = IF(_$DEPT_CD <> '', _$DEPT_CD, DEPTCD),
                WORKTP    = IF(_$WORK_BC <> '', _$WORK_BC, WORKTP),
                POSBC     = IF(_$HIGH_BC <> '', _$HIGH_BC, POSBC),
                DUTYBC    = IF(_$DUTY_BC <> '', _$DUTY_BC, DUTYBC),
                STATBC    = IF(_$STAT_BC <> '', _$STAT_BC, STATBC),
                EMAIL     = IF(_$EMAIL <> '', _$EMAIL, EMAIL),
                MOBILE    = IF(_$MOBILE <> '', _$MOBILE, MOBILE),
                DEPTTEL   = IF(_$DEPT_TEL <> '', _$DEPT_TEL, DEPTTEL),
                OLDEMPCD  = IF(_$OLD_EMP_NO <> '', _$OLD_EMP_NO, OLDEMPCD),
                MTIME     = GETTIME(),
                MEMP      = 'ERP',
                MPRG      = 'IF'
            WHERE EMPID = _$ID
              AND EMPCD = _$EMP_NO;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_EMP → MSTEMP
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTEMP
        WHERE EMPID = _$ID
          AND EMPCD = _$EMP_NO;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTEMP';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTEMP';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTEMP_OSC`$$
CREATE PROCEDURE `MES_IF_MSTEMP_OSC`(
-- *****************************************************************************
-- Comment: 외주업체계정 수신
-- Create: 2024-12-10 : 김영철
-- Modify: 
-- *****************************************************************************
  IN $IF_KEY_LIST MEDIUMTEXT,
  IN $IF_TYPE_LIST MEDIUMTEXT,
  IN $ID_LIST MEDIUMTEXT, -- ERP계정ID
  IN $EMP_NO_LIST MEDIUMTEXT, -- 사번
  IN $EMP_NM_LIST MEDIUMTEXT, -- 사원명
  IN $USR_TY_LIST MEDIUMTEXT, -- 유저타입
  IN $CUST_CD_LIST MEDIUMTEXT, -- 거래처코드
  IN $USE_YN_LIST MEDIUMTEXT, -- 사용여부
  IN $BDV_CD_LIST MEDIUMTEXT, -- 소속 사업장
  IN $FAC_CD_LIST MEDIUMTEXT, -- 소속 공장
  IN $DEPT_CD_LIST MEDIUMTEXT, -- 소속 부서
  IN $WC_CD_LIST MEDIUMTEXT, -- 작업장코드
  IN $WH_CD_LIST MEDIUMTEXT -- 창고코드
  )
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT;
  DECLARE _$IF_TYPE VARCHAR(1);
  DECLARE _$ID VARCHAR(100); -- ERP계정ID
  DECLARE _$EMP_NO VARCHAR(100); -- 사번
  DECLARE _$EMP_NM VARCHAR(100); -- 사원명
  DECLARE _$USR_TY VARCHAR(100); -- 유저타입
  DECLARE _$CUST_CD VARCHAR(100); -- 거래처코드
  DECLARE _$USE_YN VARCHAR(100); -- 사용여부
  DECLARE _$BDV_CD VARCHAR(100); -- 소속사업장 
  DECLARE _$FAC_CD VARCHAR(100); -- 소속공장
  DECLARE _$DEPT_CD VARCHAR(100); -- 소속부서
  DECLARE _$WC_CD VARCHAR(250); -- 작업장코드
  DECLARE _$WH_CD VARCHAR(250); -- 창고코드

-- *****************************************************************************
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION

  BEGIN

  GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
  SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
  
  INSERT INTO IF_ERR_LOG (
    IFKEY, IFGB, IFNAME, IF_TYPE, READTIME, ERRMSG 
    ) VALUES (
    _$IFKEY, 'ERP', 'MES_IF_MSTEMP_OSC_HIST', _$IF_TYPE, GETTIME(), @full_error
    );

  COMMIT;
  END;

-- ****************************************************************************
DECLARE CONTINUE HANDLER FOR NOT FOUND 

  BEGIN
    
  GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
  SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
    
  INSERT INTO IF_ERR_LOG (
    IFKEY, IFGB, IFNAME, IF_TYPE, READTIME, ERRMSG 
    ) VALUES (
    _$IFKEY, 'ERP', 'MES_IF_MSTEMP_OSC_HIST', _$IF_TYPE, GETTIME(), @full_error
    );

  COMMIT;
  END;

-- ****************************************************************************
DECLARE CONTINUE HANDLER FOR SQLWARNING

  BEGIN
    
  GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
  SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
  
  INSERT INTO IF_ERR_LOG (
    IFKEY, IFGB, IFNAME, IF_TYPE, READTIME, ERRMSG 
    ) VALUES (
    _$IFKEY, 'ERP', 'MES_IF_MSTEMP_OSC_HIST', _$IF_TYPE, GETTIME(), @full_error
    );

  COMMIT;
  END;

-- **************************************************************************** 

  SET _$FIRSTKEY = 0;

  WHILE LENGTH($ID_LIST) > 0 DO
    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);
    CALL COMSPLIT($ID_LIST, _$ID); -- ID
    CALL COMSPLIT($EMP_NO_LIST, _$EMP_NO); -- 사번 
    CALL COMSPLIT($EMP_NM_LIST, _$EMP_NM); -- 사원명
    CALL COMSPLIT($USR_TY_LIST, _$USR_TY); -- 유저타입
    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD); -- 거래처코드
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN); -- 사용여부
    CALL COMSPLIT($BDV_CD_LIST, _$BDV_CD); -- 소속사업장
    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD); -- 소속공장
    CALL COMSPLIT($DEPT_CD_LIST, _$DEPT_CD); -- 소속부서
    CALL COMSPLIT($WC_CD_LIST, _$WC_CD); -- 작업장코드
    CALL COMSPLIT($WH_CD_LIST, _$WH_CD); -- 창고코드

    IF _$FIRSTKEY = 0 THEN
      SET _$FIRSTKEY = _$IFKEY;
    END IF;

    IF _$IF_TYPE = 'I' THEN
    -- 외주업체계정 입력 부분 ---------------------------------------------------------------
        IF NOT EXISTS (
          SELECT *
            FROM MES_SNS.MSTEMP_OSC
            WHERE EMPNO = _$EMP_NO
            )
        THEN          
            -- 입고 정보
            INSERT INTO MES_SNS.MSTEMP_OSC(
              EMPID, EMPNO, EMPNM, USRTP, 
              CUSTCD, USEYN, BDVCD, FACTORYCD,
              DEPTCD, LINECD, WARECD,
              REMP, RTIME, RPRG)
              VALUES(
              _$ID,       -- ERP계정  
              _$EMP_NO,   -- 사번
              _$EMP_NM,   -- 사원명
              _$USR_TY,   -- 유저타입
              _$CUST_CD,  -- 거래처코드
              IF(_$USE_YN = '1', 'Y', 'N'),   -- 사용여부
              _$BDV_CD,   -- 소속사업장
              _$FAC_CD,   -- 소속공장
              _$DEPT_CD,  -- 소속부서
              _$WC_CD,    -- 작업장코드
              _$WH_CD,    -- 창고코드
              'ERP',      -- 등록자
              GETTIME(),  -- 등록시간
              'IF'        -- 등록프로그램
              ); 
        END IF;
            
            INSERT INTO MES_SNS.MSTEMP(
              EMPID, EMPCD, EMPNM, EMPSEX,
              BDVCD, FACTORYCD,
              EMPSTT, EMAIL, REMP)
            SELECT EMPID, EMPNO, EMPNM, '',
              BDVCD, FACTORYCD,
              'HR125100', '', REMP
              FROM MES_SNS.MSTEMP_OSC
              WHERE EMPNO = _$EMP_NO;

            INSERT INTO MES_SNS.MSTTMLEMP(
              TMLCD, EMPCD, 
              REMARK, RTIME, REMP, RPRG)
            SELECT EMPNO, EMPNO,
              '', RTIME, REMP, RPRG
              FROM MES_SNS.MSTEMP_OSC
              WHERE EMPNO = _$EMP_NO;

            INSERT INTO MES_SNS.SYSUSER (
              USERID, USERNM, WEBUSERPASS, EMPCD, 
              LOCKYN, AUTCD, COMPANYCD, FACTORYCD,
              REMARK, RTIME, REMP, RPRG )
            SELECT
              A.EMPNO, A.EMPNM, SHA2(CONCAT('SNS', UPPER(A.EMPNO)), 256), A.EMPNO, 
              'N', '', B.COMPANYCD, A.FACTORYCD,
              '외주처 POP 계정', MES_SNS.CALLTIME(), MES_SNS.CALLEMP(), MES_SNS.CALLPRG()
              FROM MES_SNS.MSTEMP_OSC AS A
              JOIN MES_SNS.MSTFACTORY AS B ON A.FACTORYCD = B.FACTORYCD
              WHERE A.EMPNO = _$EMP_NO
                AND A.WARECD <> '';
          
            INSERT INTO MES_SNS.MSTTML (
              TMLCD, TMLNM, LINECD, FACTORYCD, 
              WARECD, OSCYN,
              RTIME, REMP, RPRG )
            SELECT
              EMPNO, EMPNM, LINECD, FACTORYCD,
              WARECD, 'Y',
              MES_SNS.CALLTIME(), MES_SNS.CALLEMP(), MES_SNS.CALLPRG()
              FROM MES_SNS.MSTEMP_OSC
              WHERE EMPNO = _$EMP_NO
                AND WARECD <> '';

    ELSEIF _$IF_TYPE = 'U' THEN
    -- 품목정보 수정 부분 ------------------------------------------------------
      IF NOT EXISTS (
          SELECT *
            FROM MES_SNS.MSTEMP_OSC
            WHERE EMPNO = _$EMP_NO
            )
        THEN          
            -- 입고 정보
            INSERT INTO MES_SNS.MSTEMP_OSC(
              EMPID, EMPNO, EMPNM, USRTP, 
              CUSTCD, USEYN, BDVCD, FACTORYCD,
              DEPTCD, LINECD, WARECD,
              REMP, RTIME, RPRG)
              VALUES(
              _$ID,       -- ERP계정  
              _$EMP_NO,   -- 사번
              _$EMP_NM,   -- 사원명
              _$USR_TY,   -- 유저타입
              _$CUST_CD,  -- 거래처코드
              IF(_$USE_YN = '1', 'Y', 'N'),   -- 사용여부
              _$BDV_CD,   -- 소속사업장
              _$FAC_CD,   -- 소속공장
              _$DEPT_CD,  -- 소속부서
              _$WC_CD,    -- 작업장코드
              _$WH_CD,    -- 창고코드
              'ERP',      -- 등록자
              GETTIME(),  -- 등록시간
              'IF'        -- 등록프로그램
              );      
            
            INSERT INTO MES_SNS.MSTEMP(
              EMPID, EMPCD, EMPNM, EMPSEX,
              BDVCD, FACTORYCD,
              EMPSTT, EMAIL, REMP)
            SELECT EMPID, EMPNO, EMPNM, '',
              BDVCD, FACTORYCD,
              'HR125100', '', REMP
              FROM MES_SNS.MSTEMP_OSC
              WHERE EMPNO = _$EMP_NO;

            INSERT INTO MES_SNS.MSTTMLEMP(
              TMLCD, EMPCD, 
              REMARK, RTIME, REMP, RPRG)
            SELECT EMPNO, EMPNO,
              '', RTIME, REMP, RPRG
              FROM MES_SNS.MSTEMP_OSC
              WHERE EMPNO = _$EMP_NO;

            INSERT INTO MES_SNS.SYSUSER (
              USERID, USERNM, WEBUSERPASS, EMPCD, 
              LOCKYN, AUTCD, COMPANYCD, FACTORYCD,
              REMARK, RTIME, REMP, RPRG )
            SELECT
              A.EMPNO, A.EMPNM, SHA2(CONCAT('SNS', UPPER(A.EMPNO)), 256), A.EMPNO, 
              'N', '', B.COMPANYCD, A.FACTORYCD,
              '외주처 POP 계정', MES_SNS.CALLTIME(), MES_SNS.CALLEMP(), MES_SNS.CALLPRG()
              FROM MES_SNS.MSTEMP_OSC AS A
              JOIN MES_SNS.MSTFACTORY AS B ON A.FACTORYCD = B.FACTORYCD
              WHERE A.EMPNO = _$EMP_NO
                AND A.WARECD <> '';
          
            INSERT INTO MES_SNS.MSTTML (
              TMLCD, TMLNM, LINECD, FACTORYCD, 
              WARECD, OSCYN,
              RTIME, REMP, RPRG )
            SELECT
              EMPNO, EMPNM, LINECD, FACTORYCD,
              WARECD, 'Y',
              MES_SNS.CALLTIME(), MES_SNS.CALLEMP(), MES_SNS.CALLPRG()
              FROM MES_SNS.MSTEMP_OSC
              WHERE EMPNO = _$EMP_NO
                AND WARECD <> '';
      ELSE
        UPDATE MES_SNS.MSTEMP_OSC
         SET
           EMPID = IF(_$ID <> '', _$ID, EMPID), -- ERP 계정ID
           EMPNO = IF(_$EMP_NO <> '', _$EMP_NO, EMPNO), -- 사번
           EMPNM = IF(_$EMP_NM <> '', _$EMP_NM, EMPNM), -- 사원명
           USRTP = IF(_$USR_TY <> '', _$USR_TY, USRTP), -- 유저타입 ("SC700200") = 협력업체
           CUSTCD = IF(_$CUST_CD <> '', _$CUST_CD, CUSTCD), -- 거래처코드
           USEYN = IF(_$USE_YN <> '', IF(_$USE_YN = '1', 'Y', 'N'), USEYN), -- 사용여부
           BDVCD = IF(_$BDV_CD <> '', _$BDV_CD, BDVCD), -- 소속 사업장
           FACTORYCD = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD), -- 소속 공장
           DEPTCD = IF(_$DEPT_CD <> '', _$DEPT_CD, DEPTCD), -- 소속 부서
           LINECD = IF(_$WC_CD <> '', _$WC_CD, LINECD), -- 작업장 코드
           WARECD = IF(_$WH_CD <> '', _$WH_CD, WARECD) -- 창고 코드
         WHERE EMPNO = _$EMP_NO;
        
        -- 1. MSTEMP 테이블 삽입 또는 갱신
        INSERT INTO MES_SNS.MSTEMP (
          EMPID, EMPCD, EMPNM, EMPSEX,
          BDVCD, FACTORYCD,
          EMPSTT, EMAIL, REMP
        )
        SELECT EMPID, EMPNO, EMPNM, '',
          BDVCD, FACTORYCD,
          'HR125100', '', REMP
        FROM MES_SNS.MSTEMP_OSC
        WHERE EMPNO = _$EMP_NO
        ON DUPLICATE KEY UPDATE 
          EMPCD = VALUES(EMPCD),
          EMPNM = VALUES(EMPNM),
          BDVCD = VALUES(BDVCD),
          FACTORYCD = VALUES(FACTORYCD),
          EMPSTT = VALUES(EMPSTT),
          REMP = VALUES(REMP);
        
        -- 2. MSTTMLEMP 테이블 삽입 또는 갱신
        INSERT INTO MES_SNS.MSTTMLEMP (
          TMLCD, EMPCD, 
          REMARK, RTIME, REMP, RPRG
        )
        SELECT EMPNO, EMPNO,
          '', RTIME, REMP, RPRG
        FROM MES_SNS.MSTEMP_OSC
        WHERE EMPNO = _$EMP_NO
        ON DUPLICATE KEY UPDATE 
          REMARK = VALUES(REMARK),
          RTIME = VALUES(RTIME),
          REMP = VALUES(REMP),
          RPRG = VALUES(RPRG);
        
        -- 3. SYSUSER 테이블 삽입 또는 갱신
        INSERT INTO MES_SNS.SYSUSER (
          USERID, USERNM, WEBUSERPASS, EMPCD, 
          LOCKYN, AUTCD, COMPANYCD, FACTORYCD,
          REMARK, RTIME, REMP, RPRG
        )
        SELECT
          A.EMPNO, A.EMPNM, SHA2(CONCAT('SNS', UPPER(A.EMPNO)), 256), A.EMPNO, 
          'N', '', B.COMPANYCD, A.FACTORYCD,
          '외주처 POP 계정', MES_SNS.CALLTIME(), MES_SNS.CALLEMP(), MES_SNS.CALLPRG()
        FROM MES_SNS.MSTEMP_OSC AS A
        JOIN MES_SNS.MSTFACTORY AS B ON A.FACTORYCD = B.FACTORYCD
        WHERE A.EMPNO = _$EMP_NO
          AND A.WARECD <> ''
        ON DUPLICATE KEY UPDATE 
          USERNM = VALUES(USERNM),
          WEBUSERPASS = VALUES(WEBUSERPASS),
          FACTORYCD = VALUES(FACTORYCD),
          RTIME = VALUES(RTIME),
          REMP = VALUES(REMP),
          RPRG = VALUES(RPRG);
        
        -- 4. MSTTML 테이블 삽입 또는 갱신
        INSERT INTO MES_SNS.MSTTML (
          TMLCD, TMLNM, LINECD, FACTORYCD, 
          WARECD, OSCYN,
          RTIME, REMP, RPRG
        )
        SELECT
          EMPNO, EMPNM, LINECD, FACTORYCD,
          WARECD, 'Y',
          MES_SNS.CALLTIME(), MES_SNS.CALLEMP(), MES_SNS.CALLPRG()
        FROM MES_SNS.MSTEMP_OSC
        WHERE EMPNO = _$EMP_NO
          AND WARECD <> ''
        ON DUPLICATE KEY UPDATE 
          TMLNM = VALUES(TMLNM),
          LINECD = VALUES(LINECD),
          FACTORYCD = VALUES(FACTORYCD),
          WARECD = VALUES(WARECD),
          OSCYN = VALUES(OSCYN),
          RTIME = VALUES(RTIME),
          REMP = VALUES(REMP),
          RPRG = VALUES(RPRG);

--         UPDATE MES_SNS.MSTEMP
--           SET EMPCD = IF(_$EMP_NO <> '', _$EMP_NO, EMPCD),
--               EMPNM = IF(_$EMP_NM <> '', _$EMP_NM, EMPNM) -- 사원명
--           WHERE EMPCD = _$EMP_NO;
-- 
--         UPDATE MES_SNS.MSTTMLEMP
--           SET TMLCD = IF(_$EMP_NO <> '', _$EMP_NO, TMLCD),
--               EMPCD = IF(_$EMP_NO <> '', _$EMP_NO, TMLCD)
--           WHERE EMPCD = _$EMP_NO;
--             
--         UPDATE MES_SNS.SYSUSER
--           SET USERNM = IF(_$EMP_NM <> '', _$EMP_NM, USERNM), -- 사원명
--               FACTORYCD = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD) -- 소속 공장 
--           WHERE EMPCD = _$EMP_NO;
-- 
--         UPDATE MES_SNS.MSTTML
--           SET TMLNM = IF(_$EMP_NM <> '', _$EMP_NM, TMLNM), -- 사원명
--               FACTORYCD = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD), -- 소속 공장 
--               LINECD = IF(_$WC_CD <> '', _$WC_CD, LINECD), -- 작업장 코드
--               WARECD = IF(_$WH_CD <> '', _$WH_CD, WARECD) -- 창고 코드
--           WHERE TMLCD = _$EMP_NO;
      END IF;
  
    ELSEIF _$IF_TYPE = 'D' THEN
    -- 품목정보 삭제 부분 ------------------------------------------------
      DELETE
        FROM MES_SNS.MSTEMP_OSC 
        WHERE EMPNO = _$EMP_NO;

      DELETE
        FROM MES_SNS.MSTEMP
        WHERE EMPCD = _$EMP_NO;

      DELETE
        FROM MES_SNS.MSTTMLEMP
        WHERE EMPCD = _$EMP_NO;

      DELETE
        FROM MES_SNS.SYSUSER
        WHERE EMPCD = _$EMP_NO;
      
      DELETE
        FROM MES_SNS.MSTTML
        WHERE TMLCD = _$EMP_NO;

    END IF;

  END WHILE;

  UPDATE IFSTD SET LASTTIME = GETTIME() WHERE PROCNAME = 'MES_IF_MSTEMP_OSC';

  SELECT IFKEY FROM IF_ERR_LOG WHERE IFKEY >= _$FIRSTKEY AND IFNAME = 'MES_IF_MSTEMP_OSC_HIST';

-- *****************************************************************************
END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTEQM`$$
CREATE PROCEDURE `MES_IF_MSTEQM`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $FA_NO_LIST MEDIUMTEXT,           -- 설비번호 (PK)
    IN $FA_NM_LIST MEDIUMTEXT,           -- 설비명
    IN $FA_FNM_LIST MEDIUMTEXT,          -- 설비상세명
    IN $FA_BC_LIST MEDIUMTEXT,           -- 설비구분
    IN $FA_GUBUN_LIST MEDIUMTEXT,        -- 설비신규구분
    IN $GRP1_CD_LIST MEDIUMTEXT,         -- 대분류코드
    IN $GRP2_CD_LIST MEDIUMTEXT,         -- 중분류코드
    IN $GRP3_CD_LIST MEDIUMTEXT,         -- 소분류코드
    IN $EQUIP_KD_LIST MEDIUMTEXT,        -- 설비등급구분
    IN $STAT_BC_LIST MEDIUMTEXT,         -- 진행상태
    IN $SET_DT_LIST MEDIUMTEXT,          -- 설치일
    IN $OUT_DT_LIST MEDIUMTEXT,          -- 출고일자(폐기일자)
    IN $MAKE_DT_LIST MEDIUMTEXT,         -- 작성일자(제작일자)
    IN $MAKER_LIST MEDIUMTEXT,           -- 제조사
    IN $SER_NO_LIST MEDIUMTEXT,          -- 제작일련번호
    IN $NAT_CD_LIST MEDIUMTEXT,          -- 국가코드
    IN $CURY_BC_LIST MEDIUMTEXT,         -- 통화구분
    IN $BUY_FAMT_LIST MEDIUMTEXT,        -- 구매가격
    IN $BUY_AMT_LIST MEDIUMTEXT,         -- 매입일반공급가
    IN $AST_NO_LIST MEDIUMTEXT,          -- 자산번호
    IN $INV_NO_LIST MEDIUMTEXT,          -- 설비투자번호
    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드
    IN $WC_CD_LIST MEDIUMTEXT,           -- 작업장코드
    IN $PROD_YN_LIST MEDIUMTEXT,         -- 생산연동여부
    IN $CHK_DEPT_LIST MEDIUMTEXT,        -- 관리부서코드
    IN $CHK_EMP_LIST MEDIUMTEXT,         -- 점검담당사번
    IN $OWN_BC_LIST MEDIUMTEXT,          -- 소유구분
    IN $OWN_CUST_LIST MEDIUMTEXT,        -- 소유업체코드
    IN $USAGE_LIST MEDIUMTEXT,           -- 용도
    IN $PWR_LIST MEDIUMTEXT,             -- 사용전력
    IN $DIV_YN_LIST MEDIUMTEXT,          -- 배부대상여부
    IN $EVAL_YN_LIST MEDIUMTEXT,         -- 고과승인여부
    IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
    IN $RMKS_LIST MEDIUMTEXT,            -- 비고
    IN $CHK_FRDT_LIST MEDIUMTEXT,        -- 점검시작일
    IN $CHK_TODT_LIST MEDIUMTEXT         -- 점검종료일
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$FA_NO VARCHAR(50);
  DECLARE _$FA_NM VARCHAR(100);
  DECLARE _$FA_FNM VARCHAR(100);
  DECLARE _$FA_BC VARCHAR(10);
  DECLARE _$FA_GUBUN VARCHAR(10);
  DECLARE _$GRP1_CD VARCHAR(10);
  DECLARE _$GRP2_CD VARCHAR(10);
  DECLARE _$GRP3_CD VARCHAR(10);
  DECLARE _$EQUIP_KD VARCHAR(10);
  DECLARE _$STAT_BC VARCHAR(10);
  DECLARE _$SET_DT VARCHAR(50);
  DECLARE _$OUT_DT VARCHAR(50);
  DECLARE _$MAKE_DT VARCHAR(50);
  DECLARE _$MAKER VARCHAR(50);
  DECLARE _$SER_NO VARCHAR(50);
  DECLARE _$NAT_CD VARCHAR(10);
  DECLARE _$CURY_BC VARCHAR(10);
  DECLARE _$BUY_FAMT VARCHAR(50);
  DECLARE _$BUY_AMT VARCHAR(50);
  DECLARE _$AST_NO VARCHAR(30);
  DECLARE _$INV_NO VARCHAR(20);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$WC_CD VARCHAR(10);
  DECLARE _$PROD_YN VARCHAR(1);
  DECLARE _$CHK_DEPT VARCHAR(20);
  DECLARE _$CHK_EMP VARCHAR(20);
  DECLARE _$OWN_BC VARCHAR(10);
  DECLARE _$OWN_CUST VARCHAR(20);
  DECLARE _$USAGE VARCHAR(100);
  DECLARE _$PWR VARCHAR(50);
  DECLARE _$DIV_YN VARCHAR(1);
  DECLARE _$EVAL_YN VARCHAR(1);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$RMKS VARCHAR(1000);
  DECLARE _$CHK_FRDT VARCHAR(50);
  DECLARE _$CHK_TODT VARCHAR(50);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTEQM',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($FA_NO_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($FA_NO_LIST, _$FA_NO);
    CALL COMSPLIT($FA_NM_LIST, _$FA_NM);
    CALL COMSPLIT($FA_FNM_LIST, _$FA_FNM);
    CALL COMSPLIT($FA_BC_LIST, _$FA_BC);
    CALL COMSPLIT($FA_GUBUN_LIST, _$FA_GUBUN);
    CALL COMSPLIT($GRP1_CD_LIST, _$GRP1_CD);
    CALL COMSPLIT($GRP2_CD_LIST, _$GRP2_CD);
    CALL COMSPLIT($GRP3_CD_LIST, _$GRP3_CD);
    CALL COMSPLIT($EQUIP_KD_LIST, _$EQUIP_KD);
    CALL COMSPLIT($STAT_BC_LIST, _$STAT_BC);
    CALL COMSPLIT($SET_DT_LIST, _$SET_DT);
    CALL COMSPLIT($OUT_DT_LIST, _$OUT_DT);
    CALL COMSPLIT($MAKE_DT_LIST, _$MAKE_DT);
    CALL COMSPLIT($MAKER_LIST, _$MAKER);
    CALL COMSPLIT($SER_NO_LIST, _$SER_NO);
    CALL COMSPLIT($NAT_CD_LIST, _$NAT_CD);
    CALL COMSPLIT($CURY_BC_LIST, _$CURY_BC);
    CALL COMSPLIT($BUY_FAMT_LIST, _$BUY_FAMT);
    CALL COMSPLIT($BUY_AMT_LIST, _$BUY_AMT);
    CALL COMSPLIT($AST_NO_LIST, _$AST_NO);
    CALL COMSPLIT($INV_NO_LIST, _$INV_NO);
    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
    CALL COMSPLIT($WC_CD_LIST, _$WC_CD);
    CALL COMSPLIT($PROD_YN_LIST, _$PROD_YN);
    CALL COMSPLIT($CHK_DEPT_LIST, _$CHK_DEPT);
    CALL COMSPLIT($CHK_EMP_LIST, _$CHK_EMP);
    CALL COMSPLIT($OWN_BC_LIST, _$OWN_BC);
    CALL COMSPLIT($OWN_CUST_LIST, _$OWN_CUST);
    CALL COMSPLIT($USAGE_LIST, _$USAGE);
    CALL COMSPLIT($PWR_LIST, _$PWR);
    CALL COMSPLIT($DIV_YN_LIST, _$DIV_YN);
    CALL COMSPLIT($EVAL_YN_LIST, _$EVAL_YN);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);
    CALL COMSPLIT($CHK_FRDT_LIST, _$CHK_FRDT);
    CALL COMSPLIT($CHK_TODT_LIST, _$CHK_TODT);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY    = NULLIF(TRIM(_$IFKEY), '');
    SET _$BUY_FAMT = NULLIF(TRIM(_$BUY_FAMT), '');
    SET _$BUY_AMT  = NULLIF(TRIM(_$BUY_AMT), '');
    SET _$PWR      = NULLIF(TRIM(_$PWR), '');
    SET _$SET_DT   = NULLIF(TRIM(_$SET_DT), '');
    SET _$OUT_DT   = NULLIF(TRIM(_$OUT_DT), '');
    SET _$MAKE_DT  = NULLIF(TRIM(_$MAKE_DT), '');
    SET _$CHK_FRDT = NULLIF(TRIM(_$CHK_FRDT), '');
    SET _$CHK_TODT = NULLIF(TRIM(_$CHK_TODT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_EQM → MSTEQM
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTEQM
            WHERE FANO = _$FA_NO
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTEQM
            (
                FANO,
                EQMNM,
                EQMNM_DETAIL,
                EQMTP,
                EQMGUBUN,
                EQMGROUP1,
                EQMGROUP2,
                EQMGROUP3,
                EQMGRADE,
                EQMSTT,
                SETDATE,
                SCRAPDATE,
                MKDATE,
                MKCUST,
                SERNO,
                NATCD,
                CURY_BC,
                BUYFAMT,
                BUYAMT,
                ASTNO,
                INVNO,
                FACTORYCD,
                LINECD,
                PRODYN,
                DEPTCD,
                EMPCD,
                OWN_DIV,
                OWNCUST,
                USETYPE,
                EPOWER,
                DIVYN,
                EVALYN,
                USEYN,
                REMARK,
                CHKSDT,
                CHKEDT,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$FA_NO,
                _$FA_NM,
                _$FA_FNM,
                _$FA_BC,
                _$FA_GUBUN,
                _$GRP1_CD,
                _$GRP2_CD,
                _$GRP3_CD,
                _$EQUIP_KD,
                _$STAT_BC,
                IF(_$SET_DT IS NULL, NULL, GETDATETIME(_$SET_DT)),
                IF(_$OUT_DT IS NULL, NULL, GETDATETIME(_$OUT_DT)),
                IF(_$MAKE_DT IS NULL, NULL, GETDATETIME(_$MAKE_DT)),
                _$MAKER,
                _$SER_NO,
                _$NAT_CD,
                _$CURY_BC,
                IFNULL(CONVERT(_$BUY_FAMT, DECIMAL(18,0)), 0),
                IFNULL(CONVERT(_$BUY_AMT, DECIMAL(18,0)), 0),
                _$AST_NO,
                _$INV_NO,
                _$FAC_CD,
                _$WC_CD,
                IF(_$PROD_YN = 1, 'Y', 'N'),
                _$CHK_DEPT,
                _$CHK_EMP,
                _$OWN_BC,
                _$OWN_CUST,
                _$USAGE,
                IFNULL(CONVERT(_$PWR, DECIMAL(10,0)), 0),
                IF(_$DIV_YN = 1, 'Y', 'N'),
                IF(_$EVAL_YN = 1, 'Y', 'N'),
                IF(_$USE_YN = 1, 'Y', 'N'),
                _$RMKS,
                IF(_$CHK_FRDT IS NULL, NULL, GETDATETIME(_$CHK_FRDT)),
                IF(_$CHK_TODT IS NULL, NULL, GETDATETIME(_$CHK_TODT)),
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_EQM → MSTEQM
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTEQM
            WHERE FANO = _$FA_NO
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTEQM
            (
                FANO,
                EQMNM,
                EQMNM_DETAIL,
                EQMTP,
                EQMGUBUN,
                EQMGROUP1,
                EQMGROUP2,
                EQMGROUP3,
                EQMGRADE,
                EQMSTT,
                SETDATE,
                SCRAPDATE,
                MKDATE,
                MKCUST,
                SERNO,
                NATCD,
                CURY_BC,
                BUYFAMT,
                BUYAMT,
                ASTNO,
                INVNO,
                FACTORYCD,
                LINECD,
                PRODYN,
                DEPTCD,
                EMPCD,
                OWN_DIV,
                OWNCUST,
                USETYPE,
                EPOWER,
                DIVYN,
                EVALYN,
                USEYN,
                REMARK,
                CHKSDT,
                CHKEDT,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$FA_NO,
                _$FA_NM,
                _$FA_FNM,
                _$FA_BC,
                _$FA_GUBUN,
                _$GRP1_CD,
                _$GRP2_CD,
                _$GRP3_CD,
                _$EQUIP_KD,
                _$STAT_BC,
                IF(_$SET_DT IS NULL, NULL, GETDATETIME(_$SET_DT)),
                IF(_$OUT_DT IS NULL, NULL, GETDATETIME(_$OUT_DT)),
                IF(_$MAKE_DT IS NULL, NULL, GETDATETIME(_$MAKE_DT)),
                _$MAKER,
                _$SER_NO,
                _$NAT_CD,
                _$CURY_BC,
                IFNULL(CONVERT(_$BUY_FAMT, DECIMAL(18,0)), 0),
                IFNULL(CONVERT(_$BUY_AMT, DECIMAL(18,0)), 0),
                _$AST_NO,
                _$INV_NO,
                _$FAC_CD,
                _$WC_CD,
                IF(_$PROD_YN = 1, 'Y', 'N'),
                _$CHK_DEPT,
                _$CHK_EMP,
                _$OWN_BC,
                _$OWN_CUST,
                _$USAGE,
                IFNULL(CONVERT(_$PWR, DECIMAL(10,0)), 0),
                IF(_$DIV_YN = 1, 'Y', 'N'),
                IF(_$EVAL_YN = 1, 'Y', 'N'),
                IF(_$USE_YN = 1, 'Y', 'N'),
                _$RMKS,
                IF(_$CHK_FRDT IS NULL, NULL, GETDATETIME(_$CHK_FRDT)),
                IF(_$CHK_TODT IS NULL, NULL, GETDATETIME(_$CHK_TODT)),
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTEQM
            SET
                EQMNM        = IF(_$FA_NM <> '', _$FA_NM, EQMNM),
                EQMNM_DETAIL = IF(_$FA_FNM <> '', _$FA_FNM, EQMNM_DETAIL),
                EQMTP        = IF(_$FA_BC <> '', _$FA_BC, EQMTP),
                EQMGUBUN     = IF(_$FA_GUBUN <> '', _$FA_GUBUN, EQMGUBUN),
                EQMGROUP1    = IF(_$GRP1_CD <> '', _$GRP1_CD, EQMGROUP1),
                EQMGROUP2    = IF(_$GRP2_CD <> '', _$GRP2_CD, EQMGROUP2),
                EQMGROUP3    = IF(_$GRP3_CD <> '', _$GRP3_CD, EQMGROUP3),
                EQMGRADE     = IF(_$EQUIP_KD <> '', _$EQUIP_KD, EQMGRADE),
                EQMSTT       = IF(_$STAT_BC <> '', _$STAT_BC, EQMSTT),
                SETDATE      = IF(_$SET_DT IS NULL, NULL, GETDATETIME(_$SET_DT)),
                SCRAPDATE    = IF(_$OUT_DT IS NULL, NULL, GETDATETIME(_$OUT_DT)),
                MKDATE       = IF(_$MAKE_DT IS NULL, NULL, GETDATETIME(_$MAKE_DT)),
                MKCUST       = IF(_$MAKER <> '', _$MAKER, MKCUST),
                SERNO        = IF(_$SER_NO <> '', _$SER_NO, SERNO),
                NATCD        = IF(_$NAT_CD <> '', _$NAT_CD, NATCD),
                CURY_BC      = IF(_$CURY_BC <> '', _$CURY_BC, CURY_BC),
                BUYFAMT      = IFNULL(CONVERT(_$BUY_FAMT, DECIMAL(18,0)), 0),
                BUYAMT       = IFNULL(CONVERT(_$BUY_AMT, DECIMAL(18,0)), 0),
                ASTNO        = IF(_$AST_NO <> '', _$AST_NO, ASTNO),
                INVNO        = IF(_$INV_NO <> '', _$INV_NO, INVNO),
                FACTORYCD    = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
                LINECD       = IF(_$WC_CD <> '', _$WC_CD, LINECD),
                PRODYN       = IF(_$PROD_YN <> '', IF(_$PROD_YN = 1, 'Y', 'N'), PRODYN),
                DEPTCD       = IF(_$CHK_DEPT <> '', _$CHK_DEPT, DEPTCD),
                EMPCD        = IF(_$CHK_EMP <> '', _$CHK_EMP, EMPCD),
                OWN_DIV      = IF(_$OWN_BC <> '', _$OWN_BC, OWN_DIV),
                OWNCUST      = IF(_$OWN_CUST <> '', _$OWN_CUST, OWNCUST),
                USETYPE      = IF(_$USAGE <> '', _$USAGE, USETYPE),
                EPOWER       = IFNULL(CONVERT(_$PWR, DECIMAL(10,0)), 0),
                DIVYN        = IF(_$DIV_YN <> '', IF(_$DIV_YN = 1, 'Y', 'N'), DIVYN),
                EVALYN       = IF(_$EVAL_YN <> '', IF(_$EVAL_YN = 1, 'Y', 'N'), EVALYN),
                USEYN        = IF(_$USE_YN <> '', IF(_$USE_YN = 1, 'Y', 'N'), USEYN),
                REMARK       = IF(_$RMKS <> '', _$RMKS, REMARK),
                CHKSDT       = IF(_$CHK_FRDT IS NULL, NULL, GETDATETIME(_$CHK_FRDT)),
                CHKEDT       = IF(_$CHK_TODT IS NULL, NULL, GETDATETIME(_$CHK_TODT)),
                MTIME        = GETTIME(),
                MEMP         = 'ERP',
                MPRG         = 'IF'
            WHERE FANO = _$FA_NO;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_EQM → MSTEQM
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTEQM
        WHERE FANO = _$FA_NO;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTEQM';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTEQM';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTEQM_MATCH`$$
CREATE PROCEDURE `MES_IF_MSTEQM_MATCH`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $MC_CD_LIST MEDIUMTEXT,           -- 설비코드 (PK)
  IN $SQ_NO_LIST MEDIUMTEXT,           -- 순번 (PK)
  IN $FA_NO_LIST MEDIUMTEXT,           -- 설비번호
  IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$MC_CD VARCHAR(20);
  DECLARE _$SQ_NO INT;
  DECLARE _$FA_NO VARCHAR(50);
  DECLARE _$RMKS VARCHAR(50);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTEQM_MATCH',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($MC_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($MC_CD_LIST, _$MC_CD);
    CALL COMSPLIT($SQ_NO_LIST, _$SQ_NO);
    CALL COMSPLIT($FA_NO_LIST, _$FA_NO);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = _$IFKEY;
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_EQM_MATCH → MSTEQM_MATCH
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTEQM_MATCH
            WHERE EQMCD = _$MC_CD
              AND SEQ   = _$SQ_NO
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTEQM_MATCH
            (
                EQMCD,
                SEQ,
                FANO,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$MC_CD,
                _$SQ_NO,
                _$FA_NO,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_EQM_MATCH → MSTEQM_MATCH
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTEQM_MATCH
            WHERE EQMCD = _$MC_CD
              AND SEQ   = _$SQ_NO
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTEQM_MATCH
            (
                EQMCD,
                SEQ,
                FANO,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$MC_CD,
                _$SQ_NO,
                _$FA_NO,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTEQM_MATCH
            SET
                FANO   = IF(_$FA_NO <> '', _$FA_NO, FANO),
                REMARK = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME  = GETTIME(),
                MEMP   = 'ERP',
                MPRG   = 'IF'
            WHERE EQMCD = _$MC_CD
              AND SEQ   = _$SQ_NO;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_EQM_MATCH → MSTEQM_MATCH
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTEQM_MATCH
        WHERE EQMCD = _$MC_CD
          AND SEQ   = _$SQ_NO;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTEQM_MATCH';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTEQM_MATCH';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTEQM_STD`$$
CREATE PROCEDURE `MES_IF_MSTEQM_STD`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드 (PK)
    IN $ITM_ID_LIST MEDIUMTEXT,          -- 품목ID (PK)
    IN $WC_CD_LIST MEDIUMTEXT,           -- 작업장코드 (PK)
    IN $PRC_CD_LIST MEDIUMTEXT,          -- 공정코드
    IN $MC_CD_LIST MEDIUMTEXT,           -- 설비코드 (PK)
    IN $SQ_NO_LIST MEDIUMTEXT,           -- 순번
    IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일 (PK)
    IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
    IN $MAIN_YN_LIST MEDIUMTEXT,         -- 기본발주업체여부

    IN $CT_LIST MEDIUMTEXT,              -- 생산시간
    IN $EFFI_LIST MEDIUMTEXT             -- 효율
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$ITM_ID VARCHAR(10);
  DECLARE _$WC_CD VARCHAR(20);
  DECLARE _$PRC_CD VARCHAR(20);
  DECLARE _$MC_CD VARCHAR(20);
  DECLARE _$SQ_NO VARCHAR(50);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$MAIN_YN VARCHAR(1);

  DECLARE _$CT VARCHAR(50);
  DECLARE _$EFFI VARCHAR(50);

  DECLARE _$SDT VARCHAR(19);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTEQM_STD',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($FAC_CD_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
      CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
      CALL COMSPLIT($WC_CD_LIST, _$WC_CD);
      CALL COMSPLIT($PRC_CD_LIST, _$PRC_CD);
      CALL COMSPLIT($MC_CD_LIST, _$MC_CD);
      CALL COMSPLIT($SQ_NO_LIST, _$SQ_NO);
      CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
      CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
      CALL COMSPLIT($MAIN_YN_LIST, _$MAIN_YN);

      CALL COMSPLIT($CT_LIST, _$CT);
      CALL COMSPLIT($EFFI_LIST, _$EFFI);

      -- *************************************************************
      -- 빈문자열('') → NULL (숫자/날짜)
      -- *************************************************************
      SET _$IFKEY = NULLIF(TRIM(_$IFKEY), '');
      SET _$SQ_NO = NULLIF(TRIM(_$SQ_NO), '');
      SET _$CT    = NULLIF(TRIM(_$CT), '');
      SET _$EFFI  = NULLIF(TRIM(_$EFFI), '');
      SET _$FR_DT = NULLIF(TRIM(_$FR_DT), '');
      SET _$TO_DT = NULLIF(TRIM(_$TO_DT), '');

      SET _$SDT = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT));

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_STD → MSTEQM_STD
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTEQM_STD
          WHERE FACTORYCD = _$FAC_CD
            AND ITEMID    = _$ITM_ID
            AND LINECD    = _$WC_CD
            AND EQMCD     = _$MC_CD
            AND SDT       = _$SDT
      )
      THEN

          INSERT INTO MES_SNS2.MSTEQM_STD
          (
              FACTORYCD,
              ITEMID,
              LINECD,
              PRCCD,
              EQMCD,
              SEQ,
              SDT,
              EDT,
              MAINYN,
              CT,
              EFFI,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$FAC_CD,
              _$ITM_ID,
              _$WC_CD,
              _$PRC_CD,
              _$MC_CD,
              IFNULL(CONVERT(_$SQ_NO, SIGNED), 0),
              _$SDT,
              IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              _$MAIN_YN,
              IFNULL(CONVERT(_$CT, DECIMAL(18,5)), 0),
              IFNULL(CONVERT(_$EFFI, DECIMAL(18,5)), 0),
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_STD → MSTEQM_STD
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTEQM_STD
          WHERE FACTORYCD = _$FAC_CD
            AND ITEMID    = _$ITM_ID
            AND LINECD    = _$WC_CD
            AND EQMCD     = _$MC_CD
            AND SDT       = _$SDT
      )
      THEN

          INSERT INTO MES_SNS2.MSTEQM_STD
          (
              FACTORYCD,
              ITEMID,
              LINECD,
              PRCCD,
              EQMCD,
              SEQ,
              SDT,
              EDT,
              MAINYN,
              CT,
              EFFI,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$FAC_CD,
              _$ITM_ID,
              _$WC_CD,
              _$PRC_CD,
              _$MC_CD,
              IFNULL(CONVERT(_$SQ_NO, SIGNED), 0),
              _$SDT,
              IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              _$MAIN_YN,
              IFNULL(CONVERT(_$CT, DECIMAL(18,5)), 0),
              IFNULL(CONVERT(_$EFFI, DECIMAL(18,5)), 0),
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTEQM_STD
          SET
              PRCCD  = IF(_$PRC_CD <> '', _$PRC_CD, PRCCD),
              SEQ    = IFNULL(CONVERT(_$SQ_NO, SIGNED), 0),
              EDT    = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              MAINYN = IF(_$MAIN_YN <> '', _$MAIN_YN, MAINYN),
              CT     = IFNULL(CONVERT(_$CT, DECIMAL(18,5)), 0),
              EFFI   = IFNULL(CONVERT(_$EFFI, DECIMAL(18,5)), 0),
              MTIME  = GETTIME(),
              MEMP   = 'ERP',
              MPRG   = 'IF'
          WHERE FACTORYCD = _$FAC_CD
            AND ITEMID    = _$ITM_ID
            AND LINECD    = _$WC_CD
            AND EQMCD     = _$MC_CD
            AND SDT       = _$SDT;

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_STD → MSTEQM_STD
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTEQM_STD
      WHERE FACTORYCD = _$FAC_CD
        AND ITEMID    = _$ITM_ID
        AND LINECD    = _$WC_CD
        AND EQMCD     = _$MC_CD
        AND SDT       = _$SDT;

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTEQM_STD';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTEQM_STD';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTFACTORY`$$
CREATE PROCEDURE `MES_IF_MSTFACTORY`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드
  IN $FAC_NM_LIST MEDIUMTEXT,          -- 공장명
  IN $FAC_BNM_LIST MEDIUMTEXT,         -- 공장명_약칭
  IN $CO_CD_LIST MEDIUMTEXT,           -- 법인코드
  IN $BS_CD_LIST MEDIUMTEXT,           -- 사업장코드
  IN $MNG_FAC_LIST MEDIUMTEXT,         -- 관리공장코드
  IN $PO_FAC_LIST MEDIUMTEXT,          -- 발주공장코드
  IN $SET_CD_LIST MEDIUMTEXT,          -- 결산단위코드
  IN $MM_DEPT_LIST MEDIUMTEXT,         -- 자재관리부서
  IN $PP_DEPT_LIST MEDIUMTEXT,         -- 생산관리부서
  IN $FM_DEPT_LIST MEDIUMTEXT,         -- 설비보전부서
  IN $DISP_SQ_LIST MEDIUMTEXT,         -- 순서

  IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$FAC_NM VARCHAR(100);
  DECLARE _$FAC_BNM VARCHAR(50);
  DECLARE _$CO_CD VARCHAR(10);
  DECLARE _$BS_CD VARCHAR(10);
  DECLARE _$MNG_FAC VARCHAR(10);
  DECLARE _$PO_FAC VARCHAR(10);
  DECLARE _$SET_CD VARCHAR(10);
  DECLARE _$MM_DEPT VARCHAR(10);
  DECLARE _$PP_DEPT VARCHAR(10);
  DECLARE _$FM_DEPT VARCHAR(10);
  DECLARE _$DISP_SQ INT;

  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTFACTORY',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($FAC_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
    CALL COMSPLIT($FAC_NM_LIST, _$FAC_NM);
    CALL COMSPLIT($FAC_BNM_LIST, _$FAC_BNM);
    CALL COMSPLIT($CO_CD_LIST, _$CO_CD);
    CALL COMSPLIT($BS_CD_LIST, _$BS_CD);
    CALL COMSPLIT($MNG_FAC_LIST, _$MNG_FAC);
    CALL COMSPLIT($PO_FAC_LIST, _$PO_FAC);
    CALL COMSPLIT($SET_CD_LIST, _$SET_CD);
    CALL COMSPLIT($MM_DEPT_LIST, _$MM_DEPT);
    CALL COMSPLIT($PP_DEPT_LIST, _$PP_DEPT);
    CALL COMSPLIT($FM_DEPT_LIST, _$FM_DEPT);
    CALL COMSPLIT($DISP_SQ_LIST, _$DISP_SQ);

    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = _$IFKEY;
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_FACTORY → MSTFACTORY
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTFACTORY
            WHERE FACTORYCD = _$FAC_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTFACTORY
            (
                FACTORYCD,
                FACTORYNM,
                FACTORYBNM,
                COMPANYCD,
                BDVCD,
                MNG_FACTORY,
                PO_FACTORY,
                SETCD,
                MM_DEPT,
                PP_DEPT,
                FM_DEPT,
                DISPSEQ,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$FAC_CD,
                _$FAC_NM,
                _$FAC_BNM,
                _$CO_CD,
                _$BS_CD,
                _$MNG_FAC,
                _$PO_FAC,
                _$SET_CD,
                _$MM_DEPT,
                _$PP_DEPT,
                _$FM_DEPT,
                _$DISP_SQ,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_FACTORY → MSTFACTORY
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTFACTORY
            WHERE FACTORYCD = _$FAC_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTFACTORY
            (
                FACTORYCD,
                FACTORYNM,
                FACTORYBNM,
                COMPANYCD,
                BDVCD,
                MNG_FACTORY,
                PO_FACTORY,
                SETCD,
                MM_DEPT,
                PP_DEPT,
                FM_DEPT,
                DISPSEQ,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$FAC_CD,
                _$FAC_NM,
                _$FAC_BNM,
                _$CO_CD,
                _$BS_CD,
                _$MNG_FAC,
                _$PO_FAC,
                _$SET_CD,
                _$MM_DEPT,
                _$PP_DEPT,
                _$FM_DEPT,
                _$DISP_SQ,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTFACTORY
            SET
                FACTORYNM   = IF(_$FAC_NM <> '', _$FAC_NM, FACTORYNM),
                FACTORYBNM  = IF(_$FAC_BNM <> '', _$FAC_BNM, FACTORYBNM),
                COMPANYCD   = IF(_$CO_CD <> '', _$CO_CD, COMPANYCD),
                BDVCD       = IF(_$BS_CD <> '', _$BS_CD, BDVCD),
                MNG_FACTORY = IF(_$MNG_FAC <> '', _$MNG_FAC, MNG_FACTORY),
                PO_FACTORY  = IF(_$PO_FAC <> '', _$PO_FAC, PO_FACTORY),
                SETCD       = IF(_$SET_CD <> '', _$SET_CD, SETCD),
                MM_DEPT     = IF(_$MM_DEPT <> '', _$MM_DEPT, MM_DEPT),
                PP_DEPT     = IF(_$PP_DEPT <> '', _$PP_DEPT, PP_DEPT),
                FM_DEPT     = IF(_$FM_DEPT <> '', _$FM_DEPT, FM_DEPT),
                DISPSEQ     = IF(_$DISP_SQ IS NOT NULL, _$DISP_SQ, DISPSEQ),
                REMARK      = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME       = GETTIME(),
                MEMP        = 'ERP',
                MPRG        = 'IF'
            WHERE FACTORYCD = _$FAC_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_FACTORY → MSTFACTORY
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTFACTORY
        WHERE FACTORYCD = _$FAC_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTFACTORY';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTFACTORY';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTITEM`$$
CREATE PROCEDURE `MES_IF_MSTITEM`(
  IN $IF_KEY_LIST MEDIUMTEXT,           -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,          -- 인터페이스 구분(I/U/D)

  IN $ITM_ID_LIST MEDIUMTEXT,           -- 품목ID (PK)
  IN $ITM_CD_LIST MEDIUMTEXT,           -- 품목코드
  IN $CO_CD_LIST MEDIUMTEXT,            -- 법인코드
  IN $MODEL_CD_LIST MEDIUMTEXT,         -- 차종코드
  IN $COLOR_CD_LIST MEDIUMTEXT,         -- 칼라코드
  IN $MY_CD_LIST MEDIUMTEXT,            -- MY코드
  IN $ITM_NM_LIST MEDIUMTEXT,           -- 품목명
  IN $ITM_BNM_LIST MEDIUMTEXT,          -- 품목세부명
  IN $MAIN_PART_LIST MEDIUMTEXT,        -- 주요원자재ID
  IN $MAIN_ID_LIST MEDIUMTEXT,          -- 대표품목ID
  IN $TRAN_ID_LIST MEDIUMTEXT,          -- 전환상품ID
  IN $PAIR_ID_LIST MEDIUMTEXT,          -- 제품ID
  IN $PAIR_CD_LIST MEDIUMTEXT,          -- 관리코드
  IN $SPEC_LIST MEDIUMTEXT,             -- 규격
  IN $UM_BC_LIST MEDIUMTEXT,            -- 단위
  IN $SRC_BC_LIST MEDIUMTEXT,           -- 공급구분
  IN $ITM_BC_LIST MEDIUMTEXT,           -- 품목구분
  IN $GRP1_CD_LIST MEDIUMTEXT,          -- 대분류코드
  IN $GRP2_CD_LIST MEDIUMTEXT,          -- 중분류코드
  IN $GRP3_CD_LIST MEDIUMTEXT,          -- 소분류코드
  IN $GRP4_CD_LIST MEDIUMTEXT,          -- 공정분류
  IN $FR_DT_LIST MEDIUMTEXT,            -- 적용시작일
  IN $TO_DT_LIST MEDIUMTEXT,            -- 적용종료일
  IN $END_YN_LIST MEDIUMTEXT,           -- 마감여부
  IN $END_UID_LIST MEDIUMTEXT,          -- 종료처리자ID
  IN $END_BC_LIST MEDIUMTEXT,           -- 마감구분
  IN $INSP_BC_LIST MEDIUMTEXT,          -- 검사구분
  IN $PLAN_BC_LIST MEDIUMTEXT,          -- 개선계획승인구분
  IN $OLD_CD_LIST MEDIUMTEXT,           -- 구품목코드
  IN $BAR_CODE_LIST MEDIUMTEXT,         -- 바코드
  IN $GRADE_BC_LIST MEDIUMTEXT,         -- 장애등급구분
  IN $CB_ITM_LIST MEDIUMTEXT,           -- 콤비품번
  IN $CB_YN_LIST MEDIUMTEXT,            -- 콤비여부
  IN $GRP5_CD_LIST MEDIUMTEXT,          -- 세분류
  IN $PART_NO_LIST MEDIUMTEXT,          -- Part No (Lapping)
  IN $INIT_CD_LIST MEDIUMTEXT,          -- Initial No (Lapping)
  IN $IO_YN_LIST MEDIUMTEXT,            -- 수불관리여부
  IN $SEPA_YN_LIST MEDIUMTEXT,          -- Separate여부
  IN $NAT_CD_LIST MEDIUMTEXT,           -- 국가코드
  IN $HS_CD_LIST MEDIUMTEXT,            -- HS코드
  IN $REV_LIST MEDIUMTEXT,              -- 차수
  IN $DRAW_NO_LIST MEDIUMTEXT,          -- 도면번호
  IN $SECT_NO_LIST MEDIUMTEXT,          -- Section DWG No
  IN $DRAW_DT_LIST MEDIUMTEXT,          -- 도면발행일자
  IN $SIZE_BC_LIST MEDIUMTEXT,          -- 기업규모
  IN $DRAW_QTY_LIST MEDIUMTEXT,         -- 도면매수
  IN $WGT_LIST MEDIUMTEXT,              -- 중량
  IN $MAT_LIST MEDIUMTEXT,              -- 재질
  IN $LNG_LIST MEDIUMTEXT,              -- 길이
  IN $DIA_LIST MEDIUMTEXT,              -- 직경
  IN $THK_LIST MEDIUMTEXT,              -- 두께
  IN $WID_LIST MEDIUMTEXT,              -- 폭
  IN $ST_LIST MEDIUMTEXT,               -- ST
  IN $CT_LIST MEDIUMTEXT,               -- CT
  IN $TRANDAY_LIST MEDIUMTEXT,          -- 조달일수
  IN $SPEC1_LIST MEDIUMTEXT,            -- 내광성_외관
  IN $SPEC2_LIST MEDIUMTEXT,            -- 규격2
  IN $SPEC3_LIST MEDIUMTEXT,            -- 규격3
  IN $SPEC4_LIST MEDIUMTEXT,            -- 가로-폭
  IN $SPEC5_LIST MEDIUMTEXT,            -- 내열노화성_외관
  IN $SPEC6_LIST MEDIUMTEXT,            -- 강종
  IN $SPEC7_LIST MEDIUMTEXT,            -- 규격7
  IN $SPEC8_LIST MEDIUMTEXT,            -- 규격8
  IN $SPEC9_LIST MEDIUMTEXT,            -- 규격9
  IN $SPEC10_LIST MEDIUMTEXT,           -- 규격10
  IN $SPEC11_LIST MEDIUMTEXT,           -- 규격11
  IN $SPEC12_LIST MEDIUMTEXT,           -- 규격12
  IN $SPEC13_LIST MEDIUMTEXT,           -- 규격13
  IN $SPEC14_LIST MEDIUMTEXT,           -- 규격14
  IN $SPEC15_LIST MEDIUMTEXT,           -- 양산
  IN $SPEC16_LIST MEDIUMTEXT,           -- A/S
  IN $SPEC17_LIST MEDIUMTEXT,           -- 규격17
  IN $SPEC18_LIST MEDIUMTEXT,           -- 규격18
  IN $SPEC19_LIST MEDIUMTEXT,           -- 규격19
  IN $SPEC20_LIST MEDIUMTEXT,           -- 규격20
  IN $EXP_DAYS_LIST MEDIUMTEXT,         -- 유효기간(일)
  IN $STD_BOX_QTY_LIST MEDIUMTEXT,      -- 기준 BOX 내 수량
  IN $LINK_ID_LIST MEDIUMTEXT,          -- Link 품목ID
  IN $WONGA_ID_LIST MEDIUMTEXT,         -- 원가품목ID
  IN $PRODUCT_DT_LIST MEDIUMTEXT,       -- 양산이관일
  IN $PACK_QTY_LIST MEDIUMTEXT,         -- 포장개수
  IN $PACK_LAY_LIST MEDIUMTEXT,         -- 적입단수
  IN $DEPT_CD_LIST MEDIUMTEXT,          -- 부서코드
  IN $DEV_RID_LIST MEDIUMTEXT,          -- 개발담당자ID
  IN $OLD_ITM_ID_LIST MEDIUMTEXT,       -- 구품목ID

  IN $RMKS_LIST MEDIUMTEXT              -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ITM_ID VARCHAR(50);
  DECLARE _$ITM_CD VARCHAR(50);
  DECLARE _$CO_CD VARCHAR(10);
  DECLARE _$MODEL_CD VARCHAR(20);
  DECLARE _$COLOR_CD VARCHAR(10);
  DECLARE _$MY_CD VARCHAR(10);
  DECLARE _$ITM_NM VARCHAR(100);
  DECLARE _$ITM_BNM VARCHAR(100);
  DECLARE _$MAIN_PART VARCHAR(50);
  DECLARE _$MAIN_ID VARCHAR(50);
  DECLARE _$TRAN_ID VARCHAR(50);
  DECLARE _$PAIR_ID VARCHAR(50);
  DECLARE _$PAIR_CD VARCHAR(50);
  DECLARE _$SPEC VARCHAR(100);
  DECLARE _$UM_BC VARCHAR(10);
  DECLARE _$SRC_BC VARCHAR(10);
  DECLARE _$ITM_BC VARCHAR(10);
  DECLARE _$GRP1_CD VARCHAR(20);
  DECLARE _$GRP2_CD VARCHAR(20);
  DECLARE _$GRP3_CD VARCHAR(20);
  DECLARE _$GRP4_CD VARCHAR(20);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$END_YN VARCHAR(1);
  DECLARE _$END_UID VARCHAR(50);
  DECLARE _$END_BC VARCHAR(10);
  DECLARE _$INSP_BC VARCHAR(10);
  DECLARE _$PLAN_BC VARCHAR(10);
  DECLARE _$OLD_CD VARCHAR(50);
  DECLARE _$BAR_CODE VARCHAR(50);
  DECLARE _$GRADE_BC VARCHAR(10);
  DECLARE _$CB_ITM VARCHAR(50);
  DECLARE _$CB_YN VARCHAR(10);
  DECLARE _$GRP5_CD VARCHAR(20);
  DECLARE _$PART_NO VARCHAR(20);
  DECLARE _$INIT_CD VARCHAR(10);
  DECLARE _$IO_YN VARCHAR(1);
  DECLARE _$SEPA_YN VARCHAR(1);
  DECLARE _$NAT_CD VARCHAR(10);
  DECLARE _$HS_CD VARCHAR(50);
  DECLARE _$REV VARCHAR(50);
  DECLARE _$DRAW_NO VARCHAR(50);
  DECLARE _$SECT_NO VARCHAR(30);
  DECLARE _$DRAW_DT VARCHAR(50);
  DECLARE _$SIZE_BC VARCHAR(10);
  DECLARE _$DRAW_QTY VARCHAR(50);
  DECLARE _$WGT VARCHAR(50);
  DECLARE _$MAT VARCHAR(20);
  DECLARE _$LNG VARCHAR(50);
  DECLARE _$DIA VARCHAR(50);
  DECLARE _$THK VARCHAR(50);
  DECLARE _$WID VARCHAR(50);
  DECLARE _$ST VARCHAR(50);
  DECLARE _$CT VARCHAR(50);
  DECLARE _$TRANDAY VARCHAR(50);
  DECLARE _$SPEC1 VARCHAR(50);
  DECLARE _$SPEC2 VARCHAR(50);
  DECLARE _$SPEC3 VARCHAR(20);
  DECLARE _$SPEC4 VARCHAR(20);
  DECLARE _$SPEC5 VARCHAR(20);
  DECLARE _$SPEC6 VARCHAR(50);
  DECLARE _$SPEC7 VARCHAR(20);
  DECLARE _$SPEC8 VARCHAR(20);
  DECLARE _$SPEC9 VARCHAR(20);
  DECLARE _$SPEC10 VARCHAR(20);
  DECLARE _$SPEC11 VARCHAR(20);
  DECLARE _$SPEC12 VARCHAR(20);
  DECLARE _$SPEC13 VARCHAR(20);
  DECLARE _$SPEC14 VARCHAR(20);
  DECLARE _$SPEC15 VARCHAR(20);
  DECLARE _$SPEC16 VARCHAR(20);
  DECLARE _$SPEC17 VARCHAR(20);
  DECLARE _$SPEC18 VARCHAR(20);
  DECLARE _$SPEC19 VARCHAR(20);
  DECLARE _$SPEC20 VARCHAR(20);
  DECLARE _$EXP_DAYS VARCHAR(50);
  DECLARE _$STD_BOX_QTY VARCHAR(50);
  DECLARE _$LINK_ID VARCHAR(50);
  DECLARE _$WONGA_ID VARCHAR(50);
  DECLARE _$PRODUCT_DT VARCHAR(50);
  DECLARE _$PACK_QTY VARCHAR(50);
  DECLARE _$PACK_LAY VARCHAR(50);
  DECLARE _$DEPT_CD VARCHAR(10);
  DECLARE _$DEV_RID VARCHAR(50);
  DECLARE _$OLD_ITM_ID VARCHAR(50);

  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTITEM',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ITM_ID_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
    CALL COMSPLIT($ITM_CD_LIST, _$ITM_CD);
    CALL COMSPLIT($CO_CD_LIST, _$CO_CD);
    CALL COMSPLIT($MODEL_CD_LIST, _$MODEL_CD);
    CALL COMSPLIT($COLOR_CD_LIST, _$COLOR_CD);
    CALL COMSPLIT($MY_CD_LIST, _$MY_CD);
    CALL COMSPLIT($ITM_NM_LIST, _$ITM_NM);
    CALL COMSPLIT($ITM_BNM_LIST, _$ITM_BNM);
    CALL COMSPLIT($MAIN_PART_LIST, _$MAIN_PART);
    CALL COMSPLIT($MAIN_ID_LIST, _$MAIN_ID);
    CALL COMSPLIT($TRAN_ID_LIST, _$TRAN_ID);
    CALL COMSPLIT($PAIR_ID_LIST, _$PAIR_ID);
    CALL COMSPLIT($PAIR_CD_LIST, _$PAIR_CD);
    CALL COMSPLIT($SPEC_LIST, _$SPEC);
    CALL COMSPLIT($UM_BC_LIST, _$UM_BC);
    CALL COMSPLIT($SRC_BC_LIST, _$SRC_BC);
    CALL COMSPLIT($ITM_BC_LIST, _$ITM_BC);
    CALL COMSPLIT($GRP1_CD_LIST, _$GRP1_CD);
    CALL COMSPLIT($GRP2_CD_LIST, _$GRP2_CD);
    CALL COMSPLIT($GRP3_CD_LIST, _$GRP3_CD);
    CALL COMSPLIT($GRP4_CD_LIST, _$GRP4_CD);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($END_YN_LIST, _$END_YN);
    CALL COMSPLIT($END_UID_LIST, _$END_UID);
    CALL COMSPLIT($END_BC_LIST, _$END_BC);
    CALL COMSPLIT($INSP_BC_LIST, _$INSP_BC);
    CALL COMSPLIT($PLAN_BC_LIST, _$PLAN_BC);
    CALL COMSPLIT($OLD_CD_LIST, _$OLD_CD);
    CALL COMSPLIT($BAR_CODE_LIST, _$BAR_CODE);
    CALL COMSPLIT($GRADE_BC_LIST, _$GRADE_BC);
    CALL COMSPLIT($CB_ITM_LIST, _$CB_ITM);
    CALL COMSPLIT($CB_YN_LIST, _$CB_YN);
    CALL COMSPLIT($GRP5_CD_LIST, _$GRP5_CD);
    CALL COMSPLIT($PART_NO_LIST, _$PART_NO);
    CALL COMSPLIT($INIT_CD_LIST, _$INIT_CD);
    CALL COMSPLIT($IO_YN_LIST, _$IO_YN);
    CALL COMSPLIT($SEPA_YN_LIST, _$SEPA_YN);
    CALL COMSPLIT($NAT_CD_LIST, _$NAT_CD);
    CALL COMSPLIT($HS_CD_LIST, _$HS_CD);
    CALL COMSPLIT($REV_LIST, _$REV);
    CALL COMSPLIT($DRAW_NO_LIST, _$DRAW_NO);
    CALL COMSPLIT($SECT_NO_LIST, _$SECT_NO);
    CALL COMSPLIT($DRAW_DT_LIST, _$DRAW_DT);
    CALL COMSPLIT($SIZE_BC_LIST, _$SIZE_BC);
    CALL COMSPLIT($DRAW_QTY_LIST, _$DRAW_QTY);
    CALL COMSPLIT($WGT_LIST, _$WGT);
    CALL COMSPLIT($MAT_LIST, _$MAT);
    CALL COMSPLIT($LNG_LIST, _$LNG);
    CALL COMSPLIT($DIA_LIST, _$DIA);
    CALL COMSPLIT($THK_LIST, _$THK);
    CALL COMSPLIT($WID_LIST, _$WID);
    CALL COMSPLIT($ST_LIST, _$ST);
    CALL COMSPLIT($CT_LIST, _$CT);
    CALL COMSPLIT($TRANDAY_LIST, _$TRANDAY);
    CALL COMSPLIT($SPEC1_LIST, _$SPEC1);
    CALL COMSPLIT($SPEC2_LIST, _$SPEC2);
    CALL COMSPLIT($SPEC3_LIST, _$SPEC3);
    CALL COMSPLIT($SPEC4_LIST, _$SPEC4);
    CALL COMSPLIT($SPEC5_LIST, _$SPEC5);
    CALL COMSPLIT($SPEC6_LIST, _$SPEC6);
    CALL COMSPLIT($SPEC7_LIST, _$SPEC7);
    CALL COMSPLIT($SPEC8_LIST, _$SPEC8);
    CALL COMSPLIT($SPEC9_LIST, _$SPEC9);
    CALL COMSPLIT($SPEC10_LIST, _$SPEC10);
    CALL COMSPLIT($SPEC11_LIST, _$SPEC11);
    CALL COMSPLIT($SPEC12_LIST, _$SPEC12);
    CALL COMSPLIT($SPEC13_LIST, _$SPEC13);
    CALL COMSPLIT($SPEC14_LIST, _$SPEC14);
    CALL COMSPLIT($SPEC15_LIST, _$SPEC15);
    CALL COMSPLIT($SPEC16_LIST, _$SPEC16);
    CALL COMSPLIT($SPEC17_LIST, _$SPEC17);
    CALL COMSPLIT($SPEC18_LIST, _$SPEC18);
    CALL COMSPLIT($SPEC19_LIST, _$SPEC19);
    CALL COMSPLIT($SPEC20_LIST, _$SPEC20);
    CALL COMSPLIT($EXP_DAYS_LIST, _$EXP_DAYS);
    CALL COMSPLIT($STD_BOX_QTY_LIST, _$STD_BOX_QTY);
    CALL COMSPLIT($LINK_ID_LIST, _$LINK_ID);
    CALL COMSPLIT($WONGA_ID_LIST, _$WONGA_ID);
    CALL COMSPLIT($PRODUCT_DT_LIST, _$PRODUCT_DT);
    CALL COMSPLIT($PACK_QTY_LIST, _$PACK_QTY);
    CALL COMSPLIT($PACK_LAY_LIST, _$PACK_LAY);
    CALL COMSPLIT($DEPT_CD_LIST, _$DEPT_CD);
    CALL COMSPLIT($DEV_RID_LIST, _$DEV_RID);
    CALL COMSPLIT($OLD_ITM_ID_LIST, _$OLD_ITM_ID);

    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY       = NULLIF(TRIM(_$IFKEY), '');
    SET _$ITM_ID      = NULLIF(TRIM(_$ITM_ID), '');
    SET _$MAIN_PART   = NULLIF(TRIM(_$MAIN_PART), '');
    SET _$MAIN_ID     = NULLIF(TRIM(_$MAIN_ID), '');
    SET _$TRAN_ID     = NULLIF(TRIM(_$TRAN_ID), '');
    SET _$PAIR_ID     = NULLIF(TRIM(_$PAIR_ID), '');
    SET _$END_UID     = NULLIF(TRIM(_$END_UID), '');
    SET _$CB_ITM      = NULLIF(TRIM(_$CB_ITM), '');
    SET _$DRAW_QTY    = NULLIF(TRIM(_$DRAW_QTY), '');
    SET _$WGT         = NULLIF(TRIM(_$WGT), '');
    SET _$LNG         = NULLIF(TRIM(_$LNG), '');
    SET _$DIA         = NULLIF(TRIM(_$DIA), '');
    SET _$THK         = NULLIF(TRIM(_$THK), '');
    SET _$WID         = NULLIF(TRIM(_$WID), '');
    SET _$ST          = NULLIF(TRIM(_$ST), '');
    SET _$CT          = NULLIF(TRIM(_$CT), '');
    SET _$TRANDAY     = NULLIF(TRIM(_$TRANDAY), '');
    SET _$SPEC1       = NULLIF(TRIM(_$SPEC1), '');
    SET _$SPEC2       = NULLIF(TRIM(_$SPEC2), '');
    SET _$EXP_DAYS    = NULLIF(TRIM(_$EXP_DAYS), '');
    SET _$STD_BOX_QTY = NULLIF(TRIM(_$STD_BOX_QTY), '');
    SET _$LINK_ID     = NULLIF(TRIM(_$LINK_ID), '');
    SET _$WONGA_ID    = NULLIF(TRIM(_$WONGA_ID), '');
    SET _$PACK_QTY    = NULLIF(TRIM(_$PACK_QTY), '');
    SET _$PACK_LAY    = NULLIF(TRIM(_$PACK_LAY), '');
    SET _$DEV_RID     = NULLIF(TRIM(_$DEV_RID), '');
    SET _$OLD_ITM_ID  = NULLIF(TRIM(_$OLD_ITM_ID), '');

    SET _$FR_DT       = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT       = NULLIF(TRIM(_$TO_DT), '');
    SET _$DRAW_DT     = NULLIF(TRIM(_$DRAW_DT), '');
    SET _$PRODUCT_DT  = NULLIF(TRIM(_$PRODUCT_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_ITEM → MSTITEM
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM
            (
                ITEMID,
                ITEMCD,
                COMPANYCD,
                MODELCD,
                COLORCD,
                MYCD,
                ITEMNM,
                ITEMBNM,
                MAINPARTID,
                MAINITEMID,
                TRANGOODSID,
                PAIRID,
                PAIRCD,
                ITEMSPEC,
                ITEMUNIT,
                ITEMSRC,
                ITEMCG,
                ITEM_LVL1,
                ITEM_LVL2,
                ITEM_LVL3,
                ITEM_LVL4,
                VALID_FROM_DT,
                VALID_TO_DT,
                ENDYN,
                ENDUSEID,
                ENDREASON,
                INSPEC,
                PRDPLANGROUP,
                ITEMOLDCD,
                BARCD,
                GRADE,
                CBITEMNO,
                CBYN,
                ITEM_LVL5,
                PARTNO,
                INITCD,
                IOYN,
                SEPAYN,
                NAT_CD,
                HS_CD,
                REV,
                EONO,
                SECT_NO,
                EODT,
                EOSIZE,
                EOQTY,
                ITWEIGHT,
                ITMAT,
                ITLENGTH,
                SIZE_UNIT,
                DUKE,
                POK,
                ST,
                CT,
                TRANDAY,
                SPEC1,
                SPEC2,
                SPEC3,
                SPEC4,
                SPEC5,
                SPEC6,
                SPEC7,
                SPEC8,
                SPEC9,
                SPEC10,
                SPEC11,
                SPEC12,
                SPEC13,
                SPEC14,
                SPEC15,
                SPEC16,
                SPEC17,
                SPEC18,
                SPEC19,
                SPEC20,
                EXPDAY,
                BOXQTY,
                LINK_ID,
                WONGA_ID,
                PRODUCT_DT,
                PACK_QTY,
                PACK_LAY,
                DEPT_CD,
                DEV_RID,
                OLD_ITEMID,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_ID, SIGNED),
                _$ITM_CD,
                _$CO_CD,
                _$MODEL_CD,
                _$COLOR_CD,
                _$MY_CD,
                _$ITM_NM,
                _$ITM_BNM,
                CONVERT(_$MAIN_PART, SIGNED),
                CONVERT(_$MAIN_ID, SIGNED),
                CONVERT(_$TRAN_ID, SIGNED),
                CONVERT(_$PAIR_ID, SIGNED),
                _$PAIR_CD,
                _$SPEC,
                _$UM_BC,
                _$SRC_BC,
                _$ITM_BC,
                _$GRP1_CD,
                _$GRP2_CD,
                _$GRP3_CD,
                _$GRP4_CD,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                IF(_$END_YN = '1', 'Y', 'N'),
                CONVERT(_$END_UID, SIGNED),
                _$END_BC,
                _$INSP_BC,
                _$PLAN_BC,
                _$OLD_CD,
                _$BAR_CODE,
                _$GRADE_BC,
                CONVERT(_$CB_ITM, SIGNED),
                _$CB_YN,
                _$GRP5_CD,
                _$PART_NO,
                _$INIT_CD,
                _$IO_YN,
                _$SEPA_YN,
                _$NAT_CD,
                _$HS_CD,
                _$REV,
                _$DRAW_NO,
                _$SECT_NO,
                IF(_$DRAW_DT IS NULL, NULL, GETDATETIME(_$DRAW_DT)),
                _$SIZE_BC,
                CONVERT(_$DRAW_QTY, SIGNED),
                CONVERT(_$WGT, DECIMAL(20,4)),
                _$MAT,
                CONVERT(_$LNG, DECIMAL(20,4)),
                CONVERT(_$DIA, DECIMAL(20,4)),
                CONVERT(_$THK, DECIMAL(20,4)),
                CONVERT(_$WID, DECIMAL(20,4)),
                CONVERT(_$ST, DECIMAL(20,4)),
                CONVERT(_$CT, DECIMAL(20,4)),
                CONVERT(_$TRANDAY, DECIMAL(20,4)),
                CONVERT(_$SPEC1, DECIMAL(20,4)),
                CONVERT(_$SPEC2, DECIMAL(20,4)),
                _$SPEC3,
                _$SPEC4,
                _$SPEC5,
                _$SPEC6,
                _$SPEC7,
                _$SPEC8,
                _$SPEC9,
                _$SPEC10,
                _$SPEC11,
                _$SPEC12,
                _$SPEC13,
                _$SPEC14,
                _$SPEC15,
                _$SPEC16,
                _$SPEC17,
                _$SPEC18,
                _$SPEC19,
                _$SPEC20,
                CONVERT(_$EXP_DAYS, SIGNED),
                CONVERT(_$STD_BOX_QTY, DECIMAL(20,4)),
                CONVERT(_$LINK_ID, SIGNED),
                CONVERT(_$WONGA_ID, SIGNED),
                IF(_$PRODUCT_DT IS NULL, NULL, GETDATETIME(_$PRODUCT_DT)),
                CONVERT(_$PACK_QTY, DECIMAL(20,4)),
                CONVERT(_$PACK_LAY, SIGNED),
                _$DEPT_CD,
                CONVERT(_$DEV_RID, SIGNED),
                CONVERT(_$OLD_ITM_ID, SIGNED),
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_ITEM → MSTITEM
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM
            (
                ITEMID,
                ITEMCD,
                COMPANYCD,
                MODELCD,
                COLORCD,
                MYCD,
                ITEMNM,
                ITEMBNM,
                MAINPARTID,
                MAINITEMID,
                TRANGOODSID,
                PAIRID,
                PAIRCD,
                ITEMSPEC,
                ITEMUNIT,
                ITEMSRC,
                ITEMCG,
                ITEM_LVL1,
                ITEM_LVL2,
                ITEM_LVL3,
                ITEM_LVL4,
                VALID_FROM_DT,
                VALID_TO_DT,
                ENDYN,
                ENDUSEID,
                ENDREASON,
                INSPEC,
                PRDPLANGROUP,
                ITEMOLDCD,
                BARCD,
                GRADE,
                CBITEMNO,
                CBYN,
                ITEM_LVL5,
                PARTNO,
                INITCD,
                IOYN,
                SEPAYN,
                NAT_CD,
                HS_CD,
                REV,
                EONO,
                SECT_NO,
                EODT,
                EOSIZE,
                EOQTY,
                ITWEIGHT,
                ITMAT,
                ITLENGTH,
                SIZE_UNIT,
                DUKE,
                POK,
                ST,
                CT,
                TRANDAY,
                SPEC1,
                SPEC2,
                SPEC3,
                SPEC4,
                SPEC5,
                SPEC6,
                SPEC7,
                SPEC8,
                SPEC9,
                SPEC10,
                SPEC11,
                SPEC12,
                SPEC13,
                SPEC14,
                SPEC15,
                SPEC16,
                SPEC17,
                SPEC18,
                SPEC19,
                SPEC20,
                EXPDAY,
                BOXQTY,
                LINK_ID,
                WONGA_ID,
                PRODUCT_DT,
                PACK_QTY,
                PACK_LAY,
                DEPT_CD,
                DEV_RID,
                OLD_ITEMID,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_ID, SIGNED),
                _$ITM_CD,
                _$CO_CD,
                _$MODEL_CD,
                _$COLOR_CD,
                _$MY_CD,
                _$ITM_NM,
                _$ITM_BNM,
                CONVERT(_$MAIN_PART, SIGNED),
                CONVERT(_$MAIN_ID, SIGNED),
                CONVERT(_$TRAN_ID, SIGNED),
                CONVERT(_$PAIR_ID, SIGNED),
                _$PAIR_CD,
                _$SPEC,
                _$UM_BC,
                _$SRC_BC,
                _$ITM_BC,
                _$GRP1_CD,
                _$GRP2_CD,
                _$GRP3_CD,
                _$GRP4_CD,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                IF(_$END_YN = '1', 'Y', 'N'),
                CONVERT(_$END_UID, SIGNED),
                _$END_BC,
                _$INSP_BC,
                _$PLAN_BC,
                _$OLD_CD,
                _$BAR_CODE,
                _$GRADE_BC,
                CONVERT(_$CB_ITM, SIGNED),
                _$CB_YN,
                _$GRP5_CD,
                _$PART_NO,
                _$INIT_CD,
                _$IO_YN,
                _$SEPA_YN,
                _$NAT_CD,
                _$HS_CD,
                _$REV,
                _$DRAW_NO,
                _$SECT_NO,
                IF(_$DRAW_DT IS NULL, NULL, GETDATETIME(_$DRAW_DT)),
                _$SIZE_BC,
                CONVERT(_$DRAW_QTY, SIGNED),
                CONVERT(_$WGT, DECIMAL(20,4)),
                _$MAT,
                CONVERT(_$LNG, DECIMAL(20,4)),
                CONVERT(_$DIA, DECIMAL(20,4)),
                CONVERT(_$THK, DECIMAL(20,4)),
                CONVERT(_$WID, DECIMAL(20,4)),
                CONVERT(_$ST, DECIMAL(20,4)),
                CONVERT(_$CT, DECIMAL(20,4)),
                CONVERT(_$TRANDAY, DECIMAL(20,4)),
                CONVERT(_$SPEC1, DECIMAL(20,4)),
                CONVERT(_$SPEC2, DECIMAL(20,4)),
                _$SPEC3,
                _$SPEC4,
                _$SPEC5,
                _$SPEC6,
                _$SPEC7,
                _$SPEC8,
                _$SPEC9,
                _$SPEC10,
                _$SPEC11,
                _$SPEC12,
                _$SPEC13,
                _$SPEC14,
                _$SPEC15,
                _$SPEC16,
                _$SPEC17,
                _$SPEC18,
                _$SPEC19,
                _$SPEC20,
                CONVERT(_$EXP_DAYS, SIGNED),
                CONVERT(_$STD_BOX_QTY, DECIMAL(20,4)),
                CONVERT(_$LINK_ID, SIGNED),
                CONVERT(_$WONGA_ID, SIGNED),
                IF(_$PRODUCT_DT IS NULL, NULL, GETDATETIME(_$PRODUCT_DT)),
                CONVERT(_$PACK_QTY, DECIMAL(20,4)),
                CONVERT(_$PACK_LAY, SIGNED),
                _$DEPT_CD,
                CONVERT(_$DEV_RID, SIGNED),
                CONVERT(_$OLD_ITM_ID, SIGNED),
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTITEM
            SET
                ITEMCD        = IF(_$ITM_CD <> '', _$ITM_CD, ITEMCD),
                COMPANYCD     = IF(_$CO_CD <> '', _$CO_CD, COMPANYCD),
                MODELCD       = IF(_$MODEL_CD <> '', _$MODEL_CD, MODELCD),
                COLORCD       = IF(_$COLOR_CD <> '', _$COLOR_CD, COLORCD),
                MYCD          = IF(_$MY_CD <> '', _$MY_CD, MYCD),
                ITEMNM        = IF(_$ITM_NM <> '', _$ITM_NM, ITEMNM),
                ITEMBNM       = IF(_$ITM_BNM <> '', _$ITM_BNM, ITEMBNM),
                MAINPARTID    = CONVERT(_$MAIN_PART, SIGNED),
                MAINITEMID    = CONVERT(_$MAIN_ID, SIGNED),
                TRANGOODSID   = CONVERT(_$TRAN_ID, SIGNED),
                PAIRID        = CONVERT(_$PAIR_ID, SIGNED),
                PAIRCD        = IF(_$PAIR_CD <> '', _$PAIR_CD, PAIRCD),
                ITEMSPEC      = IF(_$SPEC <> '', _$SPEC, ITEMSPEC),
                ITEMUNIT      = IF(_$UM_BC <> '', _$UM_BC, ITEMUNIT),
                ITEMSRC       = IF(_$SRC_BC <> '', _$SRC_BC, ITEMSRC),
                ITEMCG        = IF(_$ITM_BC <> '', _$ITM_BC, ITEMCG),
                ITEM_LVL1     = IF(_$GRP1_CD <> '', _$GRP1_CD, ITEM_LVL1),
                ITEM_LVL2     = IF(_$GRP2_CD <> '', _$GRP2_CD, ITEM_LVL2),
                ITEM_LVL3     = IF(_$GRP3_CD <> '', _$GRP3_CD, ITEM_LVL3),
                ITEM_LVL4     = IF(_$GRP4_CD <> '', _$GRP4_CD, ITEM_LVL4),
                VALID_FROM_DT = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                VALID_TO_DT   = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                ENDYN         = IF(_$END_YN <> '', IF(_$END_YN = '1', 'Y', 'N'), ENDYN),
                ENDUSEID      = CONVERT(_$END_UID, SIGNED),
                ENDREASON     = IF(_$END_BC <> '', _$END_BC, ENDREASON),
                INSPEC        = IF(_$INSP_BC <> '', _$INSP_BC, INSPEC),
                PRDPLANGROUP  = IF(_$PLAN_BC <> '', _$PLAN_BC, PRDPLANGROUP),
                ITEMOLDCD     = IF(_$OLD_CD <> '', _$OLD_CD, ITEMOLDCD),
                BARCD         = IF(_$BAR_CODE <> '', _$BAR_CODE, BARCD),
                GRADE         = IF(_$GRADE_BC <> '', _$GRADE_BC, GRADE),
                CBITEMNO       = CONVERT(_$CB_ITM, SIGNED),
                CBYN          = IF(_$CB_YN <> '', _$CB_YN, CBYN),
                ITEM_LVL5     = IF(_$GRP5_CD <> '', _$GRP5_CD, ITEM_LVL5),
                PARTNO        = IF(_$PART_NO <> '', _$PART_NO, PARTNO),
                INITCD        = IF(_$INIT_CD <> '', _$INIT_CD, INITCD),
                IOYN          = IF(_$IO_YN <> '', _$IO_YN, IOYN),
                SEPAYN        = IF(_$SEPA_YN <> '', _$SEPA_YN, SEPAYN),
                NAT_CD        = IF(_$NAT_CD <> '', _$NAT_CD, NAT_CD),
                HS_CD         = IF(_$HS_CD <> '', _$HS_CD, HS_CD),
                REV           = IF(_$REV <> '', _$REV, REV),
                EONO          = IF(_$DRAW_NO <> '', _$DRAW_NO, EONO),
                SECT_NO       = IF(_$SECT_NO <> '', _$SECT_NO, SECT_NO),
                EODT          = IF(_$DRAW_DT IS NULL, NULL, GETDATETIME(_$DRAW_DT)),
                EOSIZE        = IF(_$SIZE_BC <> '', _$SIZE_BC, EOSIZE),
                EOQTY         = CONVERT(_$DRAW_QTY, SIGNED),
                ITWEIGHT      = CONVERT(_$WGT, DECIMAL(20,4)),
                ITMAT         = IF(_$MAT <> '', _$MAT, ITMAT),
                ITLENGTH      = CONVERT(_$LNG, DECIMAL(20,4)),
                SIZE_UNIT     = CONVERT(_$DIA, DECIMAL(20,4)),
                DUKE          = CONVERT(_$THK, DECIMAL(20,4)),
                POK           = CONVERT(_$WID, DECIMAL(20,4)),
                ST            = CONVERT(_$ST, DECIMAL(20,4)),
                CT            = CONVERT(_$CT, DECIMAL(20,4)),
                TRANDAY       = CONVERT(_$TRANDAY, DECIMAL(20,4)),
                SPEC1         = CONVERT(_$SPEC1, DECIMAL(20,4)),
                SPEC2         = CONVERT(_$SPEC2, DECIMAL(20,4)),
                SPEC3         = IF(_$SPEC3 <> '', _$SPEC3, SPEC3),
                SPEC4         = IF(_$SPEC4 <> '', _$SPEC4, SPEC4),
                SPEC5         = IF(_$SPEC5 <> '', _$SPEC5, SPEC5),
                SPEC6         = IF(_$SPEC6 <> '', _$SPEC6, SPEC6),
                SPEC7         = IF(_$SPEC7 <> '', _$SPEC7, SPEC7),
                SPEC8         = IF(_$SPEC8 <> '', _$SPEC8, SPEC8),
                SPEC9         = IF(_$SPEC9 <> '', _$SPEC9, SPEC9),
                SPEC10        = IF(_$SPEC10 <> '', _$SPEC10, SPEC10),
                SPEC11        = IF(_$SPEC11 <> '', _$SPEC11, SPEC11),
                SPEC12        = IF(_$SPEC12 <> '', _$SPEC12, SPEC12),
                SPEC13        = IF(_$SPEC13 <> '', _$SPEC13, SPEC13),
                SPEC14        = IF(_$SPEC14 <> '', _$SPEC14, SPEC14),
                SPEC15        = IF(_$SPEC15 <> '', _$SPEC15, SPEC15),
                SPEC16        = IF(_$SPEC16 <> '', _$SPEC16, SPEC16),
                SPEC17        = IF(_$SPEC17 <> '', _$SPEC17, SPEC17),
                SPEC18        = IF(_$SPEC18 <> '', _$SPEC18, SPEC18),
                SPEC19        = IF(_$SPEC19 <> '', _$SPEC19, SPEC19),
                SPEC20        = IF(_$SPEC20 <> '', _$SPEC20, SPEC20),
                EXPDAY        = CONVERT(_$EXP_DAYS, SIGNED),
                BOXQTY        = CONVERT(_$STD_BOX_QTY, DECIMAL(20,4)),
                LINK_ID       = CONVERT(_$LINK_ID, SIGNED),
                WONGA_ID      = CONVERT(_$WONGA_ID, SIGNED),
                PRODUCT_DT    = IF(_$PRODUCT_DT IS NULL, NULL, GETDATETIME(_$PRODUCT_DT)),
                PACK_QTY      = CONVERT(_$PACK_QTY, DECIMAL(20,4)),
                PACK_LAY      = CONVERT(_$PACK_LAY, SIGNED),
                DEPT_CD       = IF(_$DEPT_CD <> '', _$DEPT_CD, DEPT_CD),
                DEV_RID       = CONVERT(_$DEV_RID, SIGNED),
                OLD_ITEMID    = CONVERT(_$OLD_ITM_ID, SIGNED),
                REMARK        = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME         = GETTIME(),
                MEMP          = 'ERP',
                MPRG          = 'IF'
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED);
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_ITEM → MSTITEM
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTITEM
        WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED);
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTITEM';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTITEM';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTITEM_FACTORY`$$
CREATE PROCEDURE `MES_IF_MSTITEM_FACTORY`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드 (PK)
  IN $ITM_ID_LIST MEDIUMTEXT,          -- 품목ID (PK)
  IN $ITM_DEPT_LIST MEDIUMTEXT,        -- 품목관리부서코드
  IN $ITM_UID_LIST MEDIUMTEXT,         -- 품목담당자ID
  IN $PO_UID_LIST MEDIUMTEXT,          -- 구매담당자ID
  IN $LOT_QTY_LIST MEDIUMTEXT,         -- 생산LOT량
  IN $SAFE_QTY_LIST MEDIUMTEXT,        -- 안전재고
  IN $STD_QTY_LIST MEDIUMTEXT,         -- 적정재고
  IN $UP_RT_LIST MEDIUMTEXT,           -- 인상율(발주여유율)
  IN $SNP_MAX_LIST MEDIUMTEXT,         -- SNP Max
  IN $SNP_MIN_LIST MEDIUMTEXT,         -- SNP Min
  IN $MRP_YN_LIST MEDIUMTEXT,          -- MRP작업대상여부
  IN $SAFE_YN_LIST MEDIUMTEXT,         -- 안전재고적용여부
  IN $CAL_BC_LIST MEDIUMTEXT,          -- 계산구분
  IN $DO_BC_LIST MEDIUMTEXT,           -- D/O구분
  IN $LOC_LIST MEDIUMTEXT,             -- Location

  IN $UPH_LIST MEDIUMTEXT,             -- UPH
  IN $MOLD_CNT_LIST MEDIUMTEXT,        -- 금형기준타발수
  IN $MOLD_PRD_LIST MEDIUMTEXT         -- 금형공정순서
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$ITM_ID VARCHAR(50);
  DECLARE _$ITM_DEPT VARCHAR(10);
  DECLARE _$ITM_UID VARCHAR(50);
  DECLARE _$PO_UID VARCHAR(50);
  DECLARE _$LOT_QTY VARCHAR(50);
  DECLARE _$SAFE_QTY VARCHAR(50);
  DECLARE _$STD_QTY VARCHAR(50);
  DECLARE _$UP_RT VARCHAR(50);
  DECLARE _$SNP_MAX VARCHAR(50);
  DECLARE _$SNP_MIN VARCHAR(50);
  DECLARE _$MRP_YN VARCHAR(1);
  DECLARE _$SAFE_YN VARCHAR(1);
  DECLARE _$CAL_BC VARCHAR(10);
  DECLARE _$DO_BC VARCHAR(10);
  DECLARE _$LOC VARCHAR(50);

  DECLARE _$UPH VARCHAR(50);
  DECLARE _$MOLD_CNT VARCHAR(50);
  DECLARE _$MOLD_PRD VARCHAR(8);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTITEM_FACTORY',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($FAC_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
    CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
    CALL COMSPLIT($ITM_DEPT_LIST, _$ITM_DEPT);
    CALL COMSPLIT($ITM_UID_LIST, _$ITM_UID);
    CALL COMSPLIT($PO_UID_LIST, _$PO_UID);
    CALL COMSPLIT($LOT_QTY_LIST, _$LOT_QTY);
    CALL COMSPLIT($SAFE_QTY_LIST, _$SAFE_QTY);
    CALL COMSPLIT($STD_QTY_LIST, _$STD_QTY);
    CALL COMSPLIT($UP_RT_LIST, _$UP_RT);
    CALL COMSPLIT($SNP_MAX_LIST, _$SNP_MAX);
    CALL COMSPLIT($SNP_MIN_LIST, _$SNP_MIN);
    CALL COMSPLIT($MRP_YN_LIST, _$MRP_YN);
    CALL COMSPLIT($SAFE_YN_LIST, _$SAFE_YN);
    CALL COMSPLIT($CAL_BC_LIST, _$CAL_BC);
    CALL COMSPLIT($DO_BC_LIST, _$DO_BC);
    CALL COMSPLIT($LOC_LIST, _$LOC);

    CALL COMSPLIT($UPH_LIST, _$UPH);
    CALL COMSPLIT($MOLD_CNT_LIST, _$MOLD_CNT);
    CALL COMSPLIT($MOLD_PRD_LIST, _$MOLD_PRD);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자)
    -- *************************************************************
    SET _$IFKEY    = NULLIF(TRIM(_$IFKEY), '');
    SET _$ITM_ID   = NULLIF(TRIM(_$ITM_ID), '');
    SET _$ITM_UID  = NULLIF(TRIM(_$ITM_UID), '');
    SET _$PO_UID   = NULLIF(TRIM(_$PO_UID), '');
    SET _$LOT_QTY  = NULLIF(TRIM(_$LOT_QTY), '');
    SET _$SAFE_QTY = NULLIF(TRIM(_$SAFE_QTY), '');
    SET _$STD_QTY  = NULLIF(TRIM(_$STD_QTY), '');
    SET _$UP_RT    = NULLIF(TRIM(_$UP_RT), '');
    SET _$SNP_MAX  = NULLIF(TRIM(_$SNP_MAX), '');
    SET _$SNP_MIN  = NULLIF(TRIM(_$SNP_MIN), '');
    SET _$UPH      = NULLIF(TRIM(_$UPH), '');
    SET _$MOLD_CNT = NULLIF(TRIM(_$MOLD_CNT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_ITEM_FACTORY → MSTITEM_FACTORY
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM_FACTORY
            WHERE FACTORYCD = _$FAC_CD
              AND ITEMID    = CONVERT(_$ITM_ID, SIGNED)
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM_FACTORY
            (
                FACTORYCD,
                ITEMID,
                ITEMDEPT,
                ITEMEMPID,
                ODREMPID,
                PRDQTY,
                SAFEQTY,
                STDQTY,
                ODRUPRT,
                SNPMAX,
                SNPMIN,
                MRPYN,
                SAFEYN,
                CALBC,
                DOBC,
                LOCACD,
                UPH,
                MOLDCNT,
                MOLDPRD,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$FAC_CD,
                CONVERT(_$ITM_ID, SIGNED),
                _$ITM_DEPT,
                IFNULL(CONVERT(_$ITM_UID, SIGNED), 0),
                IFNULL(CONVERT(_$PO_UID, SIGNED), 0),
                IFNULL(CONVERT(_$LOT_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$SAFE_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$STD_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$UP_RT, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$SNP_MAX, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$SNP_MIN, DECIMAL(18,5)), 0),
                _$MRP_YN,
                _$SAFE_YN,
                _$CAL_BC,
                _$DO_BC,
                _$LOC,
                IFNULL(CONVERT(_$UPH, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$MOLD_CNT, SIGNED), 0),
                _$MOLD_PRD,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_ITEM_FACTORY → MSTITEM_FACTORY
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM_FACTORY
            WHERE FACTORYCD = _$FAC_CD
              AND ITEMID    = CONVERT(_$ITM_ID, SIGNED)
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM_FACTORY
            (
                FACTORYCD,
                ITEMID,
                ITEMDEPT,
                ITEMEMPID,
                ODREMPID,
                PRDQTY,
                SAFEQTY,
                STDQTY,
                ODRUPRT,
                SNPMAX,
                SNPMIN,
                MRPYN,
                SAFEYN,
                CALBC,
                DOBC,
                LOCACD,
                UPH,
                MOLDCNT,
                MOLDPRD,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$FAC_CD,
                CONVERT(_$ITM_ID, SIGNED),
                _$ITM_DEPT,
                IFNULL(CONVERT(_$ITM_UID, SIGNED), 0),
                IFNULL(CONVERT(_$PO_UID, SIGNED), 0),
                IFNULL(CONVERT(_$LOT_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$SAFE_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$STD_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$UP_RT, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$SNP_MAX, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$SNP_MIN, DECIMAL(18,5)), 0),
                _$MRP_YN,
                _$SAFE_YN,
                _$CAL_BC,
                _$DO_BC,
                _$LOC,
                IFNULL(CONVERT(_$UPH, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$MOLD_CNT, SIGNED), 0),
                _$MOLD_PRD,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTITEM_FACTORY
            SET
                ITEMDEPT  = IF(_$ITM_DEPT <> '', _$ITM_DEPT, ITEMDEPT),
                ITEMEMPID = IFNULL(CONVERT(_$ITM_UID, SIGNED), 0),
                ODREMPID  = IFNULL(CONVERT(_$PO_UID, SIGNED), 0),
                PRDQTY    = IFNULL(CONVERT(_$LOT_QTY, DECIMAL(18,5)), 0),
                SAFEQTY   = IFNULL(CONVERT(_$SAFE_QTY, DECIMAL(18,5)), 0),
                STDQTY    = IFNULL(CONVERT(_$STD_QTY, DECIMAL(18,5)), 0),
                ODRUPRT   = IFNULL(CONVERT(_$UP_RT, DECIMAL(18,5)), 0),
                SNPMAX    = IFNULL(CONVERT(_$SNP_MAX, DECIMAL(18,5)), 0),
                SNPMIN    = IFNULL(CONVERT(_$SNP_MIN, DECIMAL(18,5)), 0),
                MRPYN     = IF(_$MRP_YN <> '', _$MRP_YN, MRPYN),
                SAFEYN    = IF(_$SAFE_YN <> '', _$SAFE_YN, SAFEYN),
                CALBC     = IF(_$CAL_BC <> '', _$CAL_BC, CALBC),
                DOBC      = IF(_$DO_BC <> '', _$DO_BC, DOBC),
                LOCACD    = IF(_$LOC <> '', _$LOC, LOCACD),
                UPH       = IFNULL(CONVERT(_$UPH, DECIMAL(18,5)), 0),
                MOLDCNT   = IFNULL(CONVERT(_$MOLD_CNT, SIGNED), 0),
                MOLDPRD   = IF(_$MOLD_PRD <> '', _$MOLD_PRD, MOLDPRD),
                MTIME     = GETTIME(),
                MEMP      = 'ERP',
                MPRG      = 'IF'
            WHERE FACTORYCD = _$FAC_CD
              AND ITEMID    = CONVERT(_$ITM_ID, SIGNED);
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_ITEM_FACTORY → MSTITEM_FACTORY
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTITEM_FACTORY
        WHERE FACTORYCD = _$FAC_CD
          AND ITEMID    = CONVERT(_$ITM_ID, SIGNED);
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTITEM_FACTORY';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTITEM_FACTORY';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTITEM_MMP`$$
CREATE PROCEDURE `MES_IF_MSTITEM_MMP`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $ITM_ID_LIST MEDIUMTEXT,          -- 품목ID (PK)
  IN $CUST_CD_LIST MEDIUMTEXT,         -- 거래처코드 (PK)
  IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드 (PK)
  IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일 (PK)
  IN $CHG_DT_LIST MEDIUMTEXT,          -- 변경일자 (PK)
  IN $UM_BC_LIST MEDIUMTEXT,           -- 단위 (PK)
  IN $CURY_BC_LIST MEDIUMTEXT,         -- 통화구분 (PK)
  IN $UP_BC_LIST MEDIUMTEXT,           -- 진급구분
  IN $UP_LIST MEDIUMTEXT,              -- 단가
  IN $ADM_YN_LIST MEDIUMTEXT,          -- 승인여부
  IN $ADM_DT_LIST MEDIUMTEXT,          -- 승인일자
  IN $ADM_UID_LIST MEDIUMTEXT,         -- 승인자ID
  IN $RMKS_LIST MEDIUMTEXT,            -- 비고
  IN $PAY_BC_LIST MEDIUMTEXT,          -- 지급구분
  IN $SEP_BC_LIST MEDIUMTEXT,          -- SEP_BC
  IN $ENT_BC_LIST MEDIUMTEXT,          -- 입력경로
  IN $PRC_BC_LIST MEDIUMTEXT           -- PRC_BC (PK)
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ITM_ID VARCHAR(50);
  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$CHG_DT VARCHAR(50);
  DECLARE _$UM_BC VARCHAR(10);
  DECLARE _$CURY_BC VARCHAR(10);
  DECLARE _$UP_BC VARCHAR(10);
  DECLARE _$UP VARCHAR(50);
  DECLARE _$ADM_YN VARCHAR(1);
  DECLARE _$ADM_DT VARCHAR(50);
  DECLARE _$ADM_UID VARCHAR(50);
  DECLARE _$RMKS VARCHAR(50);
  DECLARE _$PAY_BC VARCHAR(20);
  DECLARE _$SEP_BC VARCHAR(20);
  DECLARE _$ENT_BC VARCHAR(20);
  DECLARE _$PRC_BC VARCHAR(20);

  DECLARE _$SDT VARCHAR(8);
  DECLARE _$CHGDT VARCHAR(8);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTITEM_MMP',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ITM_ID_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($CHG_DT_LIST, _$CHG_DT);
    CALL COMSPLIT($UM_BC_LIST, _$UM_BC);
    CALL COMSPLIT($CURY_BC_LIST, _$CURY_BC);
    CALL COMSPLIT($UP_BC_LIST, _$UP_BC);
    CALL COMSPLIT($UP_LIST, _$UP);
    CALL COMSPLIT($ADM_YN_LIST, _$ADM_YN);
    CALL COMSPLIT($ADM_DT_LIST, _$ADM_DT);
    CALL COMSPLIT($ADM_UID_LIST, _$ADM_UID);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);
    CALL COMSPLIT($PAY_BC_LIST, _$PAY_BC);
    CALL COMSPLIT($SEP_BC_LIST, _$SEP_BC);
    CALL COMSPLIT($ENT_BC_LIST, _$ENT_BC);
    CALL COMSPLIT($PRC_BC_LIST, _$PRC_BC);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
    SET _$ITM_ID  = NULLIF(TRIM(_$ITM_ID), '');
    SET _$UP      = NULLIF(TRIM(_$UP), '');
    SET _$ADM_UID = NULLIF(TRIM(_$ADM_UID), '');
    SET _$FR_DT   = NULLIF(TRIM(_$FR_DT), '');
    SET _$CHG_DT  = NULLIF(TRIM(_$CHG_DT), '');
    SET _$ADM_DT  = NULLIF(TRIM(_$ADM_DT), '');

    SET _$SDT   = IF(_$FR_DT IS NULL, NULL, LEFT(GETDATETIME(_$FR_DT), 8));
    SET _$CHGDT = IF(_$CHG_DT IS NULL, NULL, LEFT(GETDATETIME(_$CHG_DT), 8));

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_MMP → MSTITEM_MMP
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM_MMP
            WHERE ITEMID    = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD    = _$CUST_CD
              AND FACTORYCD = _$FAC_CD
              AND SDT       = _$SDT
              AND CHGDT     = _$CHGDT
              AND UMCD      = _$UM_BC
              AND CURYBC    = _$CURY_BC
              AND PRCBC     = _$PRC_BC
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM_MMP
            (
                ITEMID,
                CUSTCD,
                FACTORYCD,
                SDT,
                CHGDT,
                UMCD,
                CURYBC,
                UPBC,
                UP,
                `ADM YN`,
                ADMDT,
                ADMUID,
                REMARK,
                PAYBC,
                SEPBC,
                ENTBC,
                PRCBC,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_ID, SIGNED),
                _$CUST_CD,
                _$FAC_CD,
                _$SDT,
                _$CHGDT,
                _$UM_BC,
                _$CURY_BC,
                _$UP_BC,
                IFNULL(CONVERT(_$UP, DECIMAL(18,5)), 0),
                _$ADM_YN,
                IF(_$ADM_DT IS NULL, NULL, LEFT(GETDATETIME(_$ADM_DT), 8)),
                IFNULL(CONVERT(_$ADM_UID, SIGNED), 0),
                _$RMKS,
                _$PAY_BC,
                _$SEP_BC,
                _$ENT_BC,
                _$PRC_BC,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_MMP → MSTITEM_MMP
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM_MMP
            WHERE ITEMID    = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD    = _$CUST_CD
              AND FACTORYCD = _$FAC_CD
              AND SDT       = _$SDT
              AND CHGDT     = _$CHGDT
              AND UMCD      = _$UM_BC
              AND CURYBC    = _$CURY_BC
              AND PRCBC     = _$PRC_BC
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM_MMP
            (
                ITEMID,
                CUSTCD,
                FACTORYCD,
                SDT,
                CHGDT,
                UMCD,
                CURYBC,
                UPBC,
                UP,
                `ADM YN`,
                ADMDT,
                ADMUID,
                REMARK,
                PAYBC,
                SEPBC,
                ENTBC,
                PRCBC,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_ID, SIGNED),
                _$CUST_CD,
                _$FAC_CD,
                _$SDT,
                _$CHGDT,
                _$UM_BC,
                _$CURY_BC,
                _$UP_BC,
                IFNULL(CONVERT(_$UP, DECIMAL(18,5)), 0),
                _$ADM_YN,
                IF(_$ADM_DT IS NULL, NULL, LEFT(GETDATETIME(_$ADM_DT), 8)),
                IFNULL(CONVERT(_$ADM_UID, SIGNED), 0),
                _$RMKS,
                _$PAY_BC,
                _$SEP_BC,
                _$ENT_BC,
                _$PRC_BC,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTITEM_MMP
            SET
                UPBC     = IF(_$UP_BC <> '', _$UP_BC, UPBC),
                UP       = IFNULL(CONVERT(_$UP, DECIMAL(18,5)), 0),
                `ADM YN` = IF(_$ADM_YN <> '', _$ADM_YN, `ADM YN`),
                ADMDT    = IF(_$ADM_DT IS NULL, NULL, LEFT(GETDATETIME(_$ADM_DT), 8)),
                ADMUID   = IFNULL(CONVERT(_$ADM_UID, SIGNED), 0),
                REMARK   = IF(_$RMKS <> '', _$RMKS, REMARK),
                PAYBC    = IF(_$PAY_BC <> '', _$PAY_BC, PAYBC),
                SEPBC    = IF(_$SEP_BC <> '', _$SEP_BC, SEPBC),
                ENTBC    = IF(_$ENT_BC <> '', _$ENT_BC, ENTBC),
                MTIME    = GETTIME(),
                MEMP     = 'ERP',
                MPRG     = 'IF'
            WHERE ITEMID    = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD    = _$CUST_CD
              AND FACTORYCD = _$FAC_CD
              AND SDT       = _$SDT
              AND CHGDT     = _$CHGDT
              AND UMCD      = _$UM_BC
              AND CURYBC    = _$CURY_BC
              AND PRCBC     = _$PRC_BC;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_MMP → MSTITEM_MMP
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTITEM_MMP
        WHERE ITEMID    = CONVERT(_$ITM_ID, SIGNED)
          AND CUSTCD    = _$CUST_CD
          AND FACTORYCD = _$FAC_CD
          AND SDT       = _$SDT
          AND CHGDT     = _$CHGDT
          AND UMCD      = _$UM_BC
          AND CURYBC    = _$CURY_BC
          AND PRCBC     = _$PRC_BC;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTITEM_MMP';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTITEM_MMP';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTITEM_MMV`$$
CREATE PROCEDURE `MES_IF_MSTITEM_MMV`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $ITM_ID_LIST MEDIUMTEXT,          -- 품목ID (PK)
  IN $CUST_CD_LIST MEDIUMTEXT,         -- 납품거래처코드 (PK)
  IN $CUST_CD2_LIST MEDIUMTEXT,        -- 매입거래처코드
  IN $UM_BC_LIST MEDIUMTEXT,           -- 구매단위코드
  IN $DOM_BC_LIST MEDIUMTEXT,          -- 내외자구분
  IN $TAX_BC_LIST MEDIUMTEXT,          -- 과세구분
  IN $LV_BC_LIST MEDIUMTEXT,           -- 검사수준구분
  IN $PAY_BC_LIST MEDIUMTEXT,          -- 결재조건구분
  IN $LTM_LIST MEDIUMTEXT,             -- 리드타임
  IN $MIN_QTY_LIST MEDIUMTEXT,         -- 최소구매수량
  IN $MAX_QTY_LIST MEDIUMTEXT,         -- 최대구매수량
  IN $PCK_QTY_LIST MEDIUMTEXT,         -- 포장단위수량
  IN $PO_YN_LIST MEDIUMTEXT,           -- 발주적용여부
  IN $MAIN_YN_LIST MEDIUMTEXT,         -- 기본발주업체여부
  IN $END_YN_LIST MEDIUMTEXT,          -- 거래종료여부
  IN $PO_RT_LIST MEDIUMTEXT,           -- 기본발주비율
  IN $PART_CD_LIST MEDIUMTEXT,         -- 거래처품번
  IN $PART_NM_LIST MEDIUMTEXT,         -- 거래처품명
  IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
  IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일

  IN $CUST_CD3_LIST MEDIUMTEXT,        -- 거래처코드3
  IN $PRC_BC_LIST MEDIUMTEXT           -- 단가구분
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ITM_ID VARCHAR(50);
  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$CUST_CD2 VARCHAR(20);
  DECLARE _$UM_BC VARCHAR(10);
  DECLARE _$DOM_BC VARCHAR(10);
  DECLARE _$TAX_BC VARCHAR(10);
  DECLARE _$LV_BC VARCHAR(10);
  DECLARE _$PAY_BC VARCHAR(10);
  DECLARE _$LTM VARCHAR(50);
  DECLARE _$MIN_QTY VARCHAR(50);
  DECLARE _$MAX_QTY VARCHAR(50);
  DECLARE _$PCK_QTY VARCHAR(50);
  DECLARE _$PO_YN VARCHAR(1);
  DECLARE _$MAIN_YN VARCHAR(1);
  DECLARE _$END_YN VARCHAR(1);
  DECLARE _$PO_RT VARCHAR(50);
  DECLARE _$PART_CD VARCHAR(50);
  DECLARE _$PART_NM VARCHAR(100);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);

  DECLARE _$CUST_CD3 VARCHAR(20);
  DECLARE _$PRC_BC VARCHAR(20);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTITEM_MMV',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ITM_ID_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
    CALL COMSPLIT($CUST_CD2_LIST, _$CUST_CD2);
    CALL COMSPLIT($UM_BC_LIST, _$UM_BC);
    CALL COMSPLIT($DOM_BC_LIST, _$DOM_BC);
    CALL COMSPLIT($TAX_BC_LIST, _$TAX_BC);
    CALL COMSPLIT($LV_BC_LIST, _$LV_BC);
    CALL COMSPLIT($PAY_BC_LIST, _$PAY_BC);
    CALL COMSPLIT($LTM_LIST, _$LTM);
    CALL COMSPLIT($MIN_QTY_LIST, _$MIN_QTY);
    CALL COMSPLIT($MAX_QTY_LIST, _$MAX_QTY);
    CALL COMSPLIT($PCK_QTY_LIST, _$PCK_QTY);
    CALL COMSPLIT($PO_YN_LIST, _$PO_YN);
    CALL COMSPLIT($MAIN_YN_LIST, _$MAIN_YN);
    CALL COMSPLIT($END_YN_LIST, _$END_YN);
    CALL COMSPLIT($PO_RT_LIST, _$PO_RT);
    CALL COMSPLIT($PART_CD_LIST, _$PART_CD);
    CALL COMSPLIT($PART_NM_LIST, _$PART_NM);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);

    CALL COMSPLIT($CUST_CD3_LIST, _$CUST_CD3);
    CALL COMSPLIT($PRC_BC_LIST, _$PRC_BC);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
    SET _$ITM_ID  = NULLIF(TRIM(_$ITM_ID), '');
    SET _$LTM     = NULLIF(TRIM(_$LTM), '');
    SET _$MIN_QTY = NULLIF(TRIM(_$MIN_QTY), '');
    SET _$MAX_QTY = NULLIF(TRIM(_$MAX_QTY), '');
    SET _$PCK_QTY = NULLIF(TRIM(_$PCK_QTY), '');
    SET _$PO_RT   = NULLIF(TRIM(_$PO_RT), '');
    SET _$FR_DT   = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT   = NULLIF(TRIM(_$TO_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_MMV → MSTITEM_MMV
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM_MMV
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD = _$CUST_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM_MMV
            (
                ITEMID,
                CUSTCD,
                CUSTCD2,
                UMCD,
                DOMBC,
                TAXBC,
                LVBC,
                PAYBC,
                LTM,
                MINQTY,
                MAXQTY,
                PACKQTY,
                POYN,
                MAINYN,
                ENDYN,
                PORT,
                CUSTNO,
                CUSTNM,
                SDT,
                EDT,
                CUSTCD3,
                PRCBC,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_ID, SIGNED),
                _$CUST_CD,
                _$CUST_CD2,
                _$UM_BC,
                _$DOM_BC,
                _$TAX_BC,
                _$LV_BC,
                _$PAY_BC,
                IFNULL(CONVERT(_$LTM, SIGNED), 0),
                IFNULL(CONVERT(_$MIN_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$MAX_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$PCK_QTY, DECIMAL(18,5)), 0),
                _$PO_YN,
                _$MAIN_YN,
                _$END_YN,
                IFNULL(CONVERT(_$PO_RT, DECIMAL(12,4)), 0),
                _$PART_CD,
                _$PART_NM,
                IF(_$FR_DT IS NULL, NULL, LEFT(GETDATETIME(_$FR_DT), 8)),
                IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                _$CUST_CD3,
                _$PRC_BC,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_MMV → MSTITEM_MMV
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM_MMV
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD = _$CUST_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM_MMV
            (
                ITEMID,
                CUSTCD,
                CUSTCD2,
                UMCD,
                DOMBC,
                TAXBC,
                LVBC,
                PAYBC,
                LTM,
                MINQTY,
                MAXQTY,
                PACKQTY,
                POYN,
                MAINYN,
                ENDYN,
                PORT,
                CUSTNO,
                CUSTNM,
                SDT,
                EDT,
                CUSTCD3,
                PRCBC,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_ID, SIGNED),
                _$CUST_CD,
                _$CUST_CD2,
                _$UM_BC,
                _$DOM_BC,
                _$TAX_BC,
                _$LV_BC,
                _$PAY_BC,
                IFNULL(CONVERT(_$LTM, SIGNED), 0),
                IFNULL(CONVERT(_$MIN_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$MAX_QTY, DECIMAL(18,5)), 0),
                IFNULL(CONVERT(_$PCK_QTY, DECIMAL(18,5)), 0),
                _$PO_YN,
                _$MAIN_YN,
                _$END_YN,
                IFNULL(CONVERT(_$PO_RT, DECIMAL(12,4)), 0),
                _$PART_CD,
                _$PART_NM,
                IF(_$FR_DT IS NULL, NULL, LEFT(GETDATETIME(_$FR_DT), 8)),
                IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                _$CUST_CD3,
                _$PRC_BC,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTITEM_MMV
            SET
                CUSTCD2 = IF(_$CUST_CD2 <> '', _$CUST_CD2, CUSTCD2),
                UMCD    = IF(_$UM_BC <> '', _$UM_BC, UMCD),
                DOMBC   = IF(_$DOM_BC <> '', _$DOM_BC, DOMBC),
                TAXBC   = IF(_$TAX_BC <> '', _$TAX_BC, TAXBC),
                LVBC    = IF(_$LV_BC <> '', _$LV_BC, LVBC),
                PAYBC   = IF(_$PAY_BC <> '', _$PAY_BC, PAYBC),
                LTM     = IFNULL(CONVERT(_$LTM, SIGNED), 0),
                MINQTY  = IFNULL(CONVERT(_$MIN_QTY, DECIMAL(18,5)), 0),
                MAXQTY  = IFNULL(CONVERT(_$MAX_QTY, DECIMAL(18,5)), 0),
                PACKQTY = IFNULL(CONVERT(_$PCK_QTY, DECIMAL(18,5)), 0),
                POYN    = IF(_$PO_YN <> '', _$PO_YN, POYN),
                MAINYN  = IF(_$MAIN_YN <> '', _$MAIN_YN, MAINYN),
                ENDYN   = IF(_$END_YN <> '', _$END_YN, ENDYN),
                PORT    = IFNULL(CONVERT(_$PO_RT, DECIMAL(12,4)), 0),
                CUSTNO  = IF(_$PART_CD <> '', _$PART_CD, CUSTNO),
                CUSTNM  = IF(_$PART_NM <> '', _$PART_NM, CUSTNM),
                SDT     = IF(_$FR_DT IS NULL, NULL, LEFT(GETDATETIME(_$FR_DT), 8)),
                EDT     = IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                CUSTCD3 = IF(_$CUST_CD3 <> '', _$CUST_CD3, CUSTCD3),
                PRCBC   = IF(_$PRC_BC <> '', _$PRC_BC, PRCBC),
                MTIME   = GETTIME(),
                MEMP    = 'ERP',
                MPRG    = 'IF'
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD = _$CUST_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_MMV → MSTITEM_MMV
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTITEM_MMV
        WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
          AND CUSTCD = _$CUST_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTITEM_MMV';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTITEM_MMV';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTITEM_SDV`$$
CREATE PROCEDURE `MES_IF_MSTITEM_SDV`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $ITM_ID_LIST MEDIUMTEXT,          -- 품목ID (PK)
  IN $CUST_CD_LIST MEDIUMTEXT,         -- 납품거래처코드 (PK)
  IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일 (PK)
  IN $CUST_CD2_LIST MEDIUMTEXT,        -- 매출거래처코드
  IN $PART_CODE_LIST MEDIUMTEXT,       -- 거래처품번
  IN $PART_NAME_LIST MEDIUMTEXT,       -- 거래처품명
  IN $UM_BC_LIST MEDIUMTEXT,           -- 단위
  IN $DOC1_YN_LIST MEDIUMTEXT,         -- DOC1_YN
  IN $DOC2_YN_LIST MEDIUMTEXT,         -- DOC2_YN
  IN $DOC3_YN_LIST MEDIUMTEXT,         -- DOC3_YN
  IN $TAG_YN_LIST MEDIUMTEXT,          -- TAG_YN
  IN $RPT_YN_LIST MEDIUMTEXT,          -- 매출근보고여부
  IN $PASS_YN_LIST MEDIUMTEXT,         -- PASS_YN
  IN $MAIN_YN_LIST MEDIUMTEXT,         -- 기본발주업체여부
  IN $END_YN_LIST MEDIUMTEXT,          -- 거래종료여부
  IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
  IN $DC_RT_LIST MEDIUMTEXT            -- 단가할인율(표준가)
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ITM_ID VARCHAR(50);
  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$CUST_CD2 VARCHAR(20);
  DECLARE _$PART_CODE VARCHAR(50);
  DECLARE _$PART_NAME VARCHAR(100);
  DECLARE _$UM_BC VARCHAR(10);
  DECLARE _$DOC1_YN VARCHAR(1);
  DECLARE _$DOC2_YN VARCHAR(1);
  DECLARE _$DOC3_YN VARCHAR(1);
  DECLARE _$TAG_YN VARCHAR(1);
  DECLARE _$RPT_YN VARCHAR(1);
  DECLARE _$PASS_YN VARCHAR(1);
  DECLARE _$MAIN_YN VARCHAR(1);
  DECLARE _$END_YN VARCHAR(1);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$DC_RT VARCHAR(50);

  DECLARE _$SDT VARCHAR(8);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTITEM_SDV',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ITM_ID_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($CUST_CD2_LIST, _$CUST_CD2);
    CALL COMSPLIT($PART_CODE_LIST, _$PART_CODE);
    CALL COMSPLIT($PART_NAME_LIST, _$PART_NAME);
    CALL COMSPLIT($UM_BC_LIST, _$UM_BC);
    CALL COMSPLIT($DOC1_YN_LIST, _$DOC1_YN);
    CALL COMSPLIT($DOC2_YN_LIST, _$DOC2_YN);
    CALL COMSPLIT($DOC3_YN_LIST, _$DOC3_YN);
    CALL COMSPLIT($TAG_YN_LIST, _$TAG_YN);
    CALL COMSPLIT($RPT_YN_LIST, _$RPT_YN);
    CALL COMSPLIT($PASS_YN_LIST, _$PASS_YN);
    CALL COMSPLIT($MAIN_YN_LIST, _$MAIN_YN);
    CALL COMSPLIT($END_YN_LIST, _$END_YN);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($DC_RT_LIST, _$DC_RT);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY  = NULLIF(TRIM(_$IFKEY), '');
    SET _$ITM_ID = NULLIF(TRIM(_$ITM_ID), '');
    SET _$DC_RT  = NULLIF(TRIM(_$DC_RT), '');
    SET _$FR_DT  = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT  = NULLIF(TRIM(_$TO_DT), '');

    SET _$SDT = IF(_$FR_DT IS NULL, NULL, LEFT(GETDATETIME(_$FR_DT), 8));

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_SDV → MSTITEM_SDV
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM_SDV
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD = _$CUST_CD
              AND SDT    = _$SDT
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM_SDV
            (
                ITEMID,
                CUSTCD,
                SDT,
                CUSTCD2,
                CUSTNO,
                CUSTNM,
                UMCD,
                DOC1YN,
                DOC2YN,
                DOC3YN,
                TAGYN,
                RPTYN,
                PASSYN,
                MAINYN,
                ENDYN,
                EDT,
                DCRT,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_ID, SIGNED),
                _$CUST_CD,
                _$SDT,
                _$CUST_CD2,
                _$PART_CODE,
                _$PART_NAME,
                _$UM_BC,
                _$DOC1_YN,
                _$DOC2_YN,
                _$DOC3_YN,
                _$TAG_YN,
                _$RPT_YN,
                _$PASS_YN,
                _$MAIN_YN,
                _$END_YN,
                IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                IFNULL(CONVERT(_$DC_RT, DECIMAL(10,2)), 0),
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_SDV → MSTITEM_SDV
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTITEM_SDV
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD = _$CUST_CD
              AND SDT    = _$SDT
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTITEM_SDV
            (
                ITEMID,
                CUSTCD,
                SDT,
                CUSTCD2,
                CUSTNO,
                CUSTNM,
                UMCD,
                DOC1YN,
                DOC2YN,
                DOC3YN,
                TAGYN,
                RPTYN,
                PASSYN,
                MAINYN,
                ENDYN,
                EDT,
                DCRT,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                CONVERT(_$ITM_ID, SIGNED),
                _$CUST_CD,
                _$SDT,
                _$CUST_CD2,
                _$PART_CODE,
                _$PART_NAME,
                _$UM_BC,
                _$DOC1_YN,
                _$DOC2_YN,
                _$DOC3_YN,
                _$TAG_YN,
                _$RPT_YN,
                _$PASS_YN,
                _$MAIN_YN,
                _$END_YN,
                IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                IFNULL(CONVERT(_$DC_RT, DECIMAL(10,2)), 0),
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTITEM_SDV
            SET
                CUSTCD2 = IF(_$CUST_CD2 <> '', _$CUST_CD2, CUSTCD2),
                CUSTNO  = IF(_$PART_CODE <> '', _$PART_CODE, CUSTNO),
                CUSTNM  = IF(_$PART_NAME <> '', _$PART_NAME, CUSTNM),
                UMCD    = IF(_$UM_BC <> '', _$UM_BC, UMCD),
                DOC1YN  = IF(_$DOC1_YN <> '', _$DOC1_YN, DOC1YN),
                DOC2YN  = IF(_$DOC2_YN <> '', _$DOC2_YN, DOC2YN),
                DOC3YN  = IF(_$DOC3_YN <> '', _$DOC3_YN, DOC3YN),
                TAGYN   = IF(_$TAG_YN <> '', _$TAG_YN, TAGYN),
                RPTYN   = IF(_$RPT_YN <> '', _$RPT_YN, RPTYN),
                PASSYN  = IF(_$PASS_YN <> '', _$PASS_YN, PASSYN),
                MAINYN  = IF(_$MAIN_YN <> '', _$MAIN_YN, MAINYN),
                ENDYN   = IF(_$END_YN <> '', _$END_YN, ENDYN),
                EDT     = IF(_$TO_DT IS NULL, NULL, LEFT(GETDATETIME(_$TO_DT), 8)),
                DCRT    = IFNULL(CONVERT(_$DC_RT, DECIMAL(10,2)), 0),
                MTIME   = GETTIME(),
                MEMP    = 'ERP',
                MPRG    = 'IF'
            WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
              AND CUSTCD = _$CUST_CD
              AND SDT    = _$SDT;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_SDV → MSTITEM_SDV
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTITEM_SDV
        WHERE ITEMID = CONVERT(_$ITM_ID, SIGNED)
          AND CUSTCD = _$CUST_CD
          AND SDT    = _$SDT;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTITEM_SDV';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTITEM_SDV';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTLINE`$$
CREATE PROCEDURE `MES_IF_MSTLINE`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $WC_CD_LIST MEDIUMTEXT,           -- 작업장코드 (PK)
  IN $WC_NM_LIST MEDIUMTEXT,           -- 작업장명
  IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드
  IN $CUST_CD_LIST MEDIUMTEXT,         -- 거래처코드 (외주업체코드)
  IN $DEPT_CD_LIST MEDIUMTEXT,         -- 부서코드 (생산부서코드)
  IN $GRP_BC_LIST MEDIUMTEXT,          -- 작업장그룹
  IN $PART_OUT_WH_LIST MEDIUMTEXT,     -- 사용자재출고창고
  IN $SEMI_OUT_WH_LIST MEDIUMTEXT,     -- 사용반제품출고창고
  IN $PROD_OUT_WH_LIST MEDIUMTEXT,     -- 사용제품출고창고
  IN $SEMI_IN_WH_LIST MEDIUMTEXT,      -- 생산반제품입고창고
  IN $PROD_IN_WH_LIST MEDIUMTEXT,      -- 생산제품입고창고
  IN $DIS_OUT_WH_LIST MEDIUMTEXT,      -- 폐기출고창고
  IN $MH_YN_LIST MEDIUMTEXT,           -- 생산성(공수)관리
  IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
  IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
  IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
  IN $SUM_WC_LIST MEDIUMTEXT,          -- 집계작업장
  IN $PRC_CD_LIST MEDIUMTEXT,          -- 공정코드 (대표공정코드)
  IN $RMKS_LIST MEDIUMTEXT,            -- 비고
  IN $SUB_YN_LIST MEDIUMTEXT           -- 외주창고여부
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$WC_CD VARCHAR(10);
  DECLARE _$WC_NM VARCHAR(50);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$DEPT_CD VARCHAR(10);
  DECLARE _$GRP_BC VARCHAR(10);
  DECLARE _$PART_OUT_WH VARCHAR(10);
  DECLARE _$SEMI_OUT_WH VARCHAR(10);
  DECLARE _$PROD_OUT_WH VARCHAR(10);
  DECLARE _$SEMI_IN_WH VARCHAR(10);
  DECLARE _$PROD_IN_WH VARCHAR(10);
  DECLARE _$DIS_OUT_WH VARCHAR(10);
  DECLARE _$MH_YN VARCHAR(1);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$SUM_WC VARCHAR(10);
  DECLARE _$PRC_CD VARCHAR(10);
  DECLARE _$RMKS VARCHAR(1000);
  DECLARE _$SUB_YN VARCHAR(1);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTLINE',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($WC_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($WC_CD_LIST, _$WC_CD);
    CALL COMSPLIT($WC_NM_LIST, _$WC_NM);
    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
    CALL COMSPLIT($DEPT_CD_LIST, _$DEPT_CD);
    CALL COMSPLIT($GRP_BC_LIST, _$GRP_BC);
    CALL COMSPLIT($PART_OUT_WH_LIST, _$PART_OUT_WH);
    CALL COMSPLIT($SEMI_OUT_WH_LIST, _$SEMI_OUT_WH);
    CALL COMSPLIT($PROD_OUT_WH_LIST, _$PROD_OUT_WH);
    CALL COMSPLIT($SEMI_IN_WH_LIST, _$SEMI_IN_WH);
    CALL COMSPLIT($PROD_IN_WH_LIST, _$PROD_IN_WH);
    CALL COMSPLIT($DIS_OUT_WH_LIST, _$DIS_OUT_WH);
    CALL COMSPLIT($MH_YN_LIST, _$MH_YN);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($SUM_WC_LIST, _$SUM_WC);
    CALL COMSPLIT($PRC_CD_LIST, _$PRC_CD);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);
    CALL COMSPLIT($SUB_YN_LIST, _$SUB_YN);

    -- *************************************************************
    -- 빈문자열('') → NULL (날짜)
    -- *************************************************************
    SET _$IFKEY = NULLIF(TRIM(_$IFKEY), '');
    SET _$FR_DT = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT = NULLIF(TRIM(_$TO_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_LINE → MSTLINE
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTLINE
            WHERE LINECD = _$WC_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTLINE
            (
                LINECD,
                LINENM,
                FACTORYCD,
                OSCCUSTCD,
                PRDDEPTCD,
                LINEGROUP,
                PRART_OUT_WH,
                SEMI_OUT_WH,
                PROD_OUT_WH,
                SEMI_IN_WH,
                PROD_IN_WH,
                DIS_OUT_WH,
                MHYN,
                USEYN,
                SDT,
                EDT,
                SUMWC,
                PRCCD,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$WC_CD,
                _$WC_NM,
                _$FAC_CD,
                _$CUST_CD,
                _$DEPT_CD,
                _$GRP_BC,
                _$PART_OUT_WH,
                _$SEMI_OUT_WH,
                _$PROD_OUT_WH,
                _$SEMI_IN_WH,
                _$PROD_IN_WH,
                _$DIS_OUT_WH,
                IF(_$MH_YN = '1', 'Y', 'N'),
                IF(_$USE_YN = '1', 'Y', 'N'),
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$SUM_WC,
                _$PRC_CD,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_LINE → MSTLINE
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTLINE
            WHERE LINECD = _$WC_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTLINE
            (
                LINECD,
                LINENM,
                FACTORYCD,
                OSCCUSTCD,
                PRDDEPTCD,
                LINEGROUP,
                PRART_OUT_WH,
                SEMI_OUT_WH,
                PROD_OUT_WH,
                SEMI_IN_WH,
                PROD_IN_WH,
                DIS_OUT_WH,
                MHYN,
                USEYN,
                SDT,
                EDT,
                SUMWC,
                PRCCD,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$WC_CD,
                _$WC_NM,
                _$FAC_CD,
                _$CUST_CD,
                _$DEPT_CD,
                _$GRP_BC,
                _$PART_OUT_WH,
                _$SEMI_OUT_WH,
                _$PROD_OUT_WH,
                _$SEMI_IN_WH,
                _$PROD_IN_WH,
                _$DIS_OUT_WH,
                IF(_$MH_YN = '1', 'Y', 'N'),
                IF(_$USE_YN = '1', 'Y', 'N'),
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$SUM_WC,
                _$PRC_CD,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTLINE
            SET
                LINENM       = IF(_$WC_NM <> '', _$WC_NM, LINENM),
                FACTORYCD    = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
                OSCCUSTCD    = IF(_$CUST_CD <> '', _$CUST_CD, OSCCUSTCD),
                PRDDEPTCD    = IF(_$DEPT_CD <> '', _$DEPT_CD, PRDDEPTCD),
                LINEGROUP    = IF(_$GRP_BC <> '', _$GRP_BC, LINEGROUP),
                PRART_OUT_WH = IF(_$PART_OUT_WH <> '', _$PART_OUT_WH, PRART_OUT_WH),
                SEMI_OUT_WH  = IF(_$SEMI_OUT_WH <> '', _$SEMI_OUT_WH, SEMI_OUT_WH),
                PROD_OUT_WH  = IF(_$PROD_OUT_WH <> '', _$PROD_OUT_WH, PROD_OUT_WH),
                SEMI_IN_WH   = IF(_$SEMI_IN_WH <> '', _$SEMI_IN_WH, SEMI_IN_WH),
                PROD_IN_WH   = IF(_$PROD_IN_WH <> '', _$PROD_IN_WH, PROD_IN_WH),
                DIS_OUT_WH   = IF(_$DIS_OUT_WH <> '', _$DIS_OUT_WH, DIS_OUT_WH),
                MHYN         = IF(_$MH_YN <> '', IF(_$MH_YN = '1', 'Y', 'N'), MHYN),
                USEYN        = IF(_$USE_YN <> '', IF(_$USE_YN = '1', 'Y', 'N'), USEYN),
                SDT          = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                EDT          = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                SUMWC        = IF(_$SUM_WC <> '', _$SUM_WC, SUMWC),
                PRCCD        = IF(_$PRC_CD <> '', _$PRC_CD, PRCCD),
                REMARK       = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME        = GETTIME(),
                MEMP         = 'ERP',
                MPRG         = 'IF'
            WHERE LINECD = _$WC_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_LINE → MSTLINE
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTLINE
        WHERE LINECD = _$WC_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTLINE';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTLINE';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTLINE_EQM`$$
CREATE PROCEDURE `MES_IF_MSTLINE_EQM`(
  IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
  IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

  IN $MC_CD_LIST MEDIUMTEXT,           -- 설비코드 (PK)
  IN $MC_NO_LIST MEDIUMTEXT,           -- 기기번호
  IN $MC_NM_LIST MEDIUMTEXT,           -- 기기명
  IN $WC_CD_LIST MEDIUMTEXT,           -- 작업장코드
  IN $FA_NO_LIST MEDIUMTEXT,           -- 설비번호
  IN $GRP_BC_LIST MEDIUMTEXT,          -- 설비분류
  IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
  IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
  IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
  IN $RMKS_LIST MEDIUMTEXT,            -- 비고

  IN $CC_CD_LIST MEDIUMTEXT,           -- 원가부문코드
  IN $PRC_CD_LIST MEDIUMTEXT,          -- 공정코드
  IN $MC_BC_LIST MEDIUMTEXT,           -- 설비구분
  IN $SQ_LIST MEDIUMTEXT               -- 순번
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$MC_CD VARCHAR(20);
  DECLARE _$MC_NO VARCHAR(100);
  DECLARE _$MC_NM VARCHAR(100);
  DECLARE _$WC_CD VARCHAR(10);
  DECLARE _$FA_NO VARCHAR(20);
  DECLARE _$GRP_BC VARCHAR(10);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$RMKS VARCHAR(1000);

  DECLARE _$CC_CD VARCHAR(10);
  DECLARE _$PRC_CD VARCHAR(10);
  DECLARE _$MC_BC VARCHAR(10);
  DECLARE _$SQ VARCHAR(50);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTLINE_EQM',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($MC_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($MC_CD_LIST, _$MC_CD);
    CALL COMSPLIT($MC_NO_LIST, _$MC_NO);
    CALL COMSPLIT($MC_NM_LIST, _$MC_NM);
    CALL COMSPLIT($WC_CD_LIST, _$WC_CD);
    CALL COMSPLIT($FA_NO_LIST, _$FA_NO);
    CALL COMSPLIT($GRP_BC_LIST, _$GRP_BC);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    CALL COMSPLIT($CC_CD_LIST, _$CC_CD);
    CALL COMSPLIT($PRC_CD_LIST, _$PRC_CD);
    CALL COMSPLIT($MC_BC_LIST, _$MC_BC);
    CALL COMSPLIT($SQ_LIST, _$SQ);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY = NULLIF(TRIM(_$IFKEY), '');
    SET _$SQ    = NULLIF(TRIM(_$SQ), '');
    SET _$FR_DT = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT = NULLIF(TRIM(_$TO_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_LINE_EQM → MSTLINE_EQM
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTLINE_EQM
            WHERE EQMCD = _$MC_CD
        )
        THEN
  
            INSERT INTO MES_SNS2.MSTLINE_EQM
            (
                EQMCD,
                EQMNO,
                EQMNM,
                LINECD,
                FANO,
                GROUP_BC,
                USEYN,
                SDT,
                EDT,
                REMARK,
                CCCD,
                PRCCD,
                EQM_BC,
                SORTNO,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$MC_CD,
                _$MC_NO,
                _$MC_NM,
                _$WC_CD,
                _$FA_NO,
                _$GRP_BC,
                IF(_$USE_YN = 1, 'Y', 'N'),
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$RMKS,
                _$CC_CD,
                _$PRC_CD,
                _$MC_BC,
                IFNULL(CONVERT(_$SQ, SIGNED), 0),
                GETTIME(),
                'ERP',
                'IF'
            );
  
        END IF;
  
    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_LINE_EQM → MSTLINE_EQM
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN
  
        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTLINE_EQM
            WHERE EQMCD = _$MC_CD
        )
        THEN
            INSERT INTO MES_SNS2.MSTLINE_EQM
            (
                EQMCD,
                EQMNO,
                EQMNM,
                LINECD,
                FANO,
                GROUP_BC,
                USEYN,
                SDT,
                EDT,
                REMARK,
                CCCD,
                PRCCD,
                EQM_BC,
                SORTNO,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$MC_CD,
                _$MC_NO,
                _$MC_NM,
                _$WC_CD,
                _$FA_NO,
                _$GRP_BC,
                IF(_$USE_YN = 1, 'Y', 'N'),
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$RMKS,
                _$CC_CD,
                _$PRC_CD,
                _$MC_BC,
                IFNULL(CONVERT(_$SQ, SIGNED), 0),
                GETTIME(),
                'ERP',
                'IF'
            );
  
        ELSE
  
            UPDATE MES_SNS2.MSTLINE_EQM
            SET
                EQMNO    = IF(_$MC_NO <> '', _$MC_NO, EQMNO),
                EQMNM    = IF(_$MC_NM <> '', _$MC_NM, EQMNM),
                LINECD   = IF(_$WC_CD <> '', _$WC_CD, LINECD),
                FANO     = IF(_$FA_NO <> '', _$FA_NO, FANO),
                GROUP_BC = IF(_$GRP_BC <> '', _$GRP_BC, GROUP_BC),
                USEYN    = IF(_$USE_YN <> '', IF(_$USE_YN = 1, 'Y', 'N'), USEYN),
                SDT      = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                EDT      = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                REMARK   = IF(_$RMKS <> '', _$RMKS, REMARK),
                CCCD     = IF(_$CC_CD <> '', _$CC_CD, CCCD),
                PRCCD    = IF(_$PRC_CD <> '', _$PRC_CD, PRCCD),
                EQM_BC   = IF(_$MC_BC <> '', _$MC_BC, EQM_BC),
                SORTNO   = IFNULL(CONVERT(_$SQ, SIGNED), 0),
                MTIME    = GETTIME(),
                MEMP     = 'ERP',
                MPRG     = 'IF'
            WHERE EQMCD = _$MC_CD;
  
        END IF;
  
    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_LINE_EQM → MSTLINE_EQM
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN
  
        DELETE
        FROM MES_SNS2.MSTLINE_EQM
        WHERE EQMCD = _$MC_CD;
  
    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTLINE_EQM';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTLINE_EQM';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTLINE_PRC`$$
CREATE PROCEDURE `MES_IF_MSTLINE_PRC`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $WC_CD_LIST MEDIUMTEXT,           -- 작업장코드 (PK)
    IN $PRC_CD_LIST MEDIUMTEXT,          -- 공정코드 (PK)
    IN $PART_OUT_WH_LIST MEDIUMTEXT,     -- 사용자재출고창고
    IN $SEMI_OUT_WH_LIST MEDIUMTEXT,     -- 사용반제품출고창고
    IN $PROD_OUT_WH_LIST MEDIUMTEXT,     -- 사용제품출고창고
    IN $SEMI_IN_WH_LIST MEDIUMTEXT,      -- 생산반제품입고창고
    IN $PROD_IN_WH_LIST MEDIUMTEXT,      -- 생산제품입고창고
    IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
    IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
    IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
    IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$WC_CD VARCHAR(10);
  DECLARE _$PRC_CD VARCHAR(10);
  DECLARE _$PART_OUT_WH VARCHAR(10);
  DECLARE _$SEMI_OUT_WH VARCHAR(10);
  DECLARE _$PROD_OUT_WH VARCHAR(10);
  DECLARE _$SEMI_IN_WH VARCHAR(10);
  DECLARE _$PROD_IN_WH VARCHAR(10);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTLINE_PRC',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($WC_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($WC_CD_LIST, _$WC_CD);
    CALL COMSPLIT($PRC_CD_LIST, _$PRC_CD);
    CALL COMSPLIT($PART_OUT_WH_LIST, _$PART_OUT_WH);
    CALL COMSPLIT($SEMI_OUT_WH_LIST, _$SEMI_OUT_WH);
    CALL COMSPLIT($PROD_OUT_WH_LIST, _$PROD_OUT_WH);
    CALL COMSPLIT($SEMI_IN_WH_LIST, _$SEMI_IN_WH);
    CALL COMSPLIT($PROD_IN_WH_LIST, _$PROD_IN_WH);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    -- *************************************************************
    -- 빈문자열('') → NULL (날짜)
    -- *************************************************************
    SET _$IFKEY = NULLIF(TRIM(_$IFKEY), '');
    SET _$FR_DT = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT = NULLIF(TRIM(_$TO_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_LINE_PROC → MSTLINE_PRC
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN

        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTLINE_PRC
            WHERE LINECD = _$WC_CD
              AND PRCCD  = _$PRC_CD
        )
        THEN

            INSERT INTO MES_SNS2.MSTLINE_PRC
            (
                LINECD,
                PRCCD,
                PART_OUT_WH,
                SEMI_OUT_WH,
                PROD_OUT_WH,
                SEMI_IN_WH,
                PROD_IN_WH,
                SDT,
                EDT,
                USYN,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$WC_CD,
                _$PRC_CD,
                _$PART_OUT_WH,
                _$SEMI_OUT_WH,
                _$PROD_OUT_WH,
                _$SEMI_IN_WH,
                _$PROD_IN_WH,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$USE_YN,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );

        END IF;

    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_LINE_PROC → MSTLINE_PRC
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN

        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTLINE_PRC
            WHERE LINECD = _$WC_CD
              AND PRCCD  = _$PRC_CD
        )
        THEN

            INSERT INTO MES_SNS2.MSTLINE_PRC
            (
                LINECD,
                PRCCD,
                PART_OUT_WH,
                SEMI_OUT_WH,
                PROD_OUT_WH,
                SEMI_IN_WH,
                PROD_IN_WH,
                SDT,
                EDT,
                USYN,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                _$WC_CD,
                _$PRC_CD,
                _$PART_OUT_WH,
                _$SEMI_OUT_WH,
                _$PROD_OUT_WH,
                _$SEMI_IN_WH,
                _$PROD_IN_WH,
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$USE_YN,
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );

        ELSE

            UPDATE MES_SNS2.MSTLINE_PRC
            SET
                PART_OUT_WH = IF(_$PART_OUT_WH <> '', _$PART_OUT_WH, PART_OUT_WH),
                SEMI_OUT_WH = IF(_$SEMI_OUT_WH <> '', _$SEMI_OUT_WH, SEMI_OUT_WH),
                PROD_OUT_WH = IF(_$PROD_OUT_WH <> '', _$PROD_OUT_WH, PROD_OUT_WH),
                SEMI_IN_WH  = IF(_$SEMI_IN_WH <> '', _$SEMI_IN_WH, SEMI_IN_WH),
                PROD_IN_WH  = IF(_$PROD_IN_WH <> '', _$PROD_IN_WH, PROD_IN_WH),
                SDT         = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                EDT         = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                USYN        = IF(_$USE_YN <> '', _$USE_YN, USYN),
                REMARK      = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME       = GETTIME(),
                MEMP        = 'ERP',
                MPRG        = 'IF'
            WHERE LINECD = _$WC_CD
              AND PRCCD  = _$PRC_CD;

        END IF;

    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_LINE_PROC → MSTLINE_PRC
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN

        DELETE
        FROM MES_SNS2.MSTLINE_PRC
        WHERE LINECD = _$WC_CD
          AND PRCCD  = _$PRC_CD;

    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTLINE_PRC';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTLINE_PRC';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTMAGAM_MON`$$
CREATE PROCEDURE `MES_IF_MSTMAGAM_MON`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $FLAG_LIST MEDIUMTEXT,            -- 마감유형 (PK)
    IN $MNG_NO_LIST MEDIUMTEXT,          -- 로트정보 (PK)
    IN $MAGAM_DT_LIST MEDIUMTEXT         -- 마감일자
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$FLAG VARCHAR(10);
  DECLARE _$MNG_NO VARCHAR(20);
  DECLARE _$MAGAM_DT VARCHAR(40);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTMAGAM_MON',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($FLAG_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($FLAG_LIST, _$FLAG);
      CALL COMSPLIT($MNG_NO_LIST, _$MNG_NO);
      CALL COMSPLIT($MAGAM_DT_LIST, _$MAGAM_DT);

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = _$IFKEY;
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- 2FAC_MES_MAGAM_MON → MSTMAGAM_MON
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTMAGAM_MON
          WHERE MAGAMTP = _$FLAG
            AND LOTEKEY = _$MNG_NO
      )
      THEN

          INSERT INTO MES_SNS2.MSTMAGAM_MON
          (
              MAGAMTP,
              LOTEKEY,
              MAGAMDT,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$FLAG,
              _$MNG_NO,
              LEFT(GETDATETIME(_$MAGAM_DT), 8),
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- 2FAC_MES_MAGAM_MON → MSTMAGAM_MON
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTMAGAM_MON
          WHERE MAGAMTP = _$FLAG
            AND LOTEKEY = _$MNG_NO
      )
      THEN

          INSERT INTO MES_SNS2.MSTMAGAM_MON
          (
              MAGAMTP,
              LOTEKEY,
              MAGAMDT,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$FLAG,
              _$MNG_NO,
              LEFT(GETDATETIME(_$MAGAM_DT), 8),
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTMAGAM_MON
          SET
              MAGAMDT = IF(_$MAGAM_DT <> '', LEFT(GETDATETIME(_$MAGAM_DT), 8), MAGAMDT),
              MTIME   = GETTIME(),
              MEMP    = 'ERP',
              MPRG    = 'IF'
          WHERE MAGAMTP = _$FLAG
            AND LOTEKEY = _$MNG_NO;

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- 2FAC_MES_MAGAM_MON → MSTMAGAM_MON
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTMAGAM_MON
      WHERE MAGAMTP = _$FLAG
        AND LOTEKEY = _$MNG_NO;

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTMAGAM_MON';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTMAGAM_MON';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTMAGAM_PRD`$$
CREATE PROCEDURE `MES_IF_MSTMAGAM_PRD`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $CO_CD_LIST MEDIUMTEXT,           -- 법인코드 (PK)
    IN $END_DT_LIST MEDIUMTEXT           -- 마감일자 (PK)
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$CO_CD VARCHAR(10);
  DECLARE _$END_DT VARCHAR(50);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTMAGAM_PRD',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($CO_CD_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($CO_CD_LIST, _$CO_CD);
      CALL COMSPLIT($END_DT_LIST, _$END_DT);

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = _$IFKEY;
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- 2FAC_MES_MAGAM_PRD → MSTMAGAM_PRD
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTMAGAM_PRD
          WHERE BDVCD = _$CO_CD
            AND EDT   = LEFT(GETDATETIME(_$END_DT), 10)
      )
      THEN

          INSERT INTO MES_SNS2.MSTMAGAM_PRD
          (
              BDVCD,
              EDT,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$CO_CD,
              LEFT(_$END_DT, 10),
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- 2FAC_MES_MAGAM_PRD → MSTMAGAM_PRD
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTMAGAM_PRD
          WHERE BDVCD = _$CO_CD
            AND EDT   = LEFT(GETDATETIME(_$END_DT), 10)
      )
      THEN

          INSERT INTO MES_SNS2.MSTMAGAM_PRD
          (
              BDVCD,
              EDT,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$CO_CD,
              LEFT(_$END_DT, 10),
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTMAGAM_PRD
          SET
              MTIME = GETTIME(),
              MEMP  = 'ERP',
              MPRG  = 'IF'
          WHERE BDVCD = _$CO_CD
            AND EDT   = LEFT(_$END_DT, 10);

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- 2FAC_MES_MAGAM_PRD → MSTMAGAM_PRD
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTMAGAM_PRD
      WHERE BDVCD = _$CO_CD
        AND EDT   = LEFT(_$END_DT, 10);

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTMAGAM_PRD';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTMAGAM_PRD';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTNON`$$
CREATE PROCEDURE `MES_IF_MSTNON`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $WC_CD_LIST MEDIUMTEXT,           -- 작업장코드 (PK)
    IN $STOP_CD_LIST MEDIUMTEXT,         -- 비가동코드 (PK)
    IN $STOP_NM_LIST MEDIUMTEXT,         -- 비가동명
    IN $PLAN_YN_LIST MEDIUMTEXT,         -- 제출서류계획(계획여부)
    IN $STOP_YN_LIST MEDIUMTEXT,         -- 정지로스
    IN $SPEED_YN_LIST MEDIUMTEXT,        -- 속도로스
    IN $DOWN_YN_LIST MEDIUMTEXT,         -- 고장여부
    IN $GRP1_CD_LIST MEDIUMTEXT,         -- 대분류코드
    IN $GRP2_CD_LIST MEDIUMTEXT,         -- 중분류코드
    IN $RMKS_LIST MEDIUMTEXT,            -- 비고

    IN $FAC_CD_LIST MEDIUMTEXT           -- 공장코드
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$WC_CD VARCHAR(20);
  DECLARE _$STOP_CD VARCHAR(10);
  DECLARE _$STOP_NM VARCHAR(100);
  DECLARE _$PLAN_YN VARCHAR(1);
  DECLARE _$STOP_YN VARCHAR(1);
  DECLARE _$SPEED_YN VARCHAR(1);
  DECLARE _$DOWN_YN VARCHAR(1);
  DECLARE _$GRP1_CD VARCHAR(10);
  DECLARE _$GRP2_CD VARCHAR(10);
  DECLARE _$RMKS VARCHAR(1000);

  DECLARE _$FAC_CD VARCHAR(10);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTNON',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($WC_CD_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($WC_CD_LIST, _$WC_CD);
      CALL COMSPLIT($STOP_CD_LIST, _$STOP_CD);
      CALL COMSPLIT($STOP_NM_LIST, _$STOP_NM);
      CALL COMSPLIT($PLAN_YN_LIST, _$PLAN_YN);
      CALL COMSPLIT($STOP_YN_LIST, _$STOP_YN);
      CALL COMSPLIT($SPEED_YN_LIST, _$SPEED_YN);
      CALL COMSPLIT($DOWN_YN_LIST, _$DOWN_YN);
      CALL COMSPLIT($GRP1_CD_LIST, _$GRP1_CD);
      CALL COMSPLIT($GRP2_CD_LIST, _$GRP2_CD);
      CALL COMSPLIT($RMKS_LIST, _$RMKS);

      CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = _$IFKEY;
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_NON → MSTNON
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTNON
          WHERE LINECD = _$WC_CD
            AND NONCD  = _$STOP_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTNON
          (
              LINECD,
              NONCD,
              NONNM,
              PLANYN,
              STOPYN,
              SPEEDYN,
              BADYN,
              NONGROUPCD1,
              NONGROUPCD2,
              FACTORYCD,
              USEYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$WC_CD,
              _$STOP_CD,
              _$STOP_NM,
              IF(_$PLAN_YN = '1', 'Y', 'N'),
              IF(_$STOP_YN = '1', 'Y', 'N'),
              IF(_$SPEED_YN = '1', 'Y', 'N'),
              IF(_$DOWN_YN = '1', 'Y', 'N'),
              _$GRP1_CD,
              _$GRP2_CD,
              _$FAC_CD,
              'Y',
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_NON → MSTNON
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTNON
          WHERE LINECD = _$WC_CD
            AND NONCD  = _$STOP_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTNON
          (
              LINECD,
              NONCD,
              NONNM,
              PLANYN,
              STOPYN,
              SPEEDYN,
              BADYN,
              NONGROUPCD1,
              NONGROUPCD2,
              FACTORYCD,
              USEYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$WC_CD,
              _$STOP_CD,
              _$STOP_NM,
              IF(_$PLAN_YN = '1', 'Y', 'N'),
              IF(_$STOP_YN = '1', 'Y', 'N'),
              IF(_$SPEED_YN = '1', 'Y', 'N'),
              IF(_$DOWN_YN = '1', 'Y', 'N'),
              _$GRP1_CD,
              _$GRP2_CD,
              _$FAC_CD,
              'Y',
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTNON
          SET
              NONNM       = IF(_$STOP_NM <> '', _$STOP_NM, NONNM),
              PLANYN      = IF(_$PLAN_YN <> '', IF(_$PLAN_YN = '1', 'Y', 'N'), PLANYN),
              STOPYN      = IF(_$STOP_YN <> '', IF(_$STOP_YN = '1', 'Y', 'N'), STOPYN),
              SPEEDYN     = IF(_$SPEED_YN <> '', IF(_$SPEED_YN = '1', 'Y', 'N'), SPEEDYN),
              BADYN       = IF(_$DOWN_YN <> '', IF(_$DOWN_YN = '1', 'Y', 'N'), BADYN),
              NONGROUPCD1 = IF(_$GRP1_CD <> '', _$GRP1_CD, NONGROUPCD1),
              NONGROUPCD2 = IF(_$GRP2_CD <> '', _$GRP2_CD, NONGROUPCD2),
              FACTORYCD   = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
              REMARK      = IF(_$RMKS <> '', _$RMKS, REMARK),
              MTIME       = GETTIME(),
              MEMP        = 'ERP',
              MPRG        = 'IF'
          WHERE LINECD = _$WC_CD
            AND NONCD  = _$STOP_CD;

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_NON → MSTNON
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTNON
      WHERE LINECD = _$WC_CD
        AND NONCD  = _$STOP_CD;

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTNON';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTNON';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTPRC`$$
CREATE PROCEDURE `MES_IF_MSTPRC`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $PRC_CD_LIST MEDIUMTEXT,          -- 공정코드 (PK)
    IN $PRC_NM_LIST MEDIUMTEXT,          -- 공정명
    IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
    IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
    IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
    IN $RMKS_LIST MEDIUMTEXT,            -- 비고

    IN $GUBUN_BC_LIST MEDIUMTEXT,        -- 사내외구분
    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드
    IN $PRC_SEMI_LIST MEDIUMTEXT,        -- 반제품구분
    IN $PRC_GU_LIST MEDIUMTEXT,          -- 공정구분
    IN $WO_YN_LIST MEDIUMTEXT,           -- 지시필요여부
    IN $BOX_YN_LIST MEDIUMTEXT           -- 박스순번관리여부
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- *************************************************************
  DECLARE _$IFKEY INT;
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$PRC_CD VARCHAR(10);
  DECLARE _$PRC_NM VARCHAR(50);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$FR_DT VARCHAR(40);
  DECLARE _$TO_DT VARCHAR(40);
  DECLARE _$RMKS VARCHAR(1000);

  DECLARE _$GUBUN_BC VARCHAR(20);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$PRC_SEMI VARCHAR(20);
  DECLARE _$PRC_GU VARCHAR(10);
  DECLARE _$WO_YN VARCHAR(1);
  DECLARE _$BOX_YN VARCHAR(1);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          _$IFKEY,
          'ERP',
          'MES_IF_MSTPRC',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($PRC_CD_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($PRC_CD_LIST, _$PRC_CD);
      CALL COMSPLIT($PRC_NM_LIST, _$PRC_NM);
      CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
      CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
      CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
      CALL COMSPLIT($RMKS_LIST, _$RMKS);

      CALL COMSPLIT($GUBUN_BC_LIST, _$GUBUN_BC);
      CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
      CALL COMSPLIT($PRC_SEMI_LIST, _$PRC_SEMI);
      CALL COMSPLIT($PRC_GU_LIST, _$PRC_GU);
      CALL COMSPLIT($WO_YN_LIST, _$WO_YN);
      CALL COMSPLIT($BOX_YN_LIST, _$BOX_YN);

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = _$IFKEY;
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_PRC → MSTPRC
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTPRC
          WHERE PRCCD = _$PRC_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTPRC
          (
              PRCCD,
              PRCNM,
              USEYN,
              SDT,
              EDT,
              GUBUN_BC,
              FACTORYCD,
              PRCSEMT,
              PRCGROUP,
              INSYN,
              BOXYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$PRC_CD,
              _$PRC_NM,
              IF(_$USE_YN = 1, 'Y', 'N'),
              GETDATETIME(_$FR_DT),
              GETDATETIME(_$TO_DT),
              _$GUBUN_BC,
              _$FAC_CD,
              _$PRC_SEMI,
              _$PRC_GU,
              _$WO_YN,
              _$BOX_YN,
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_PRC → MSTPRC
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTPRC
          WHERE PRCCD = _$PRC_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTPRC
          (
              PRCCD,
              PRCNM,
              USEYN,
              SDT,
              EDT,
              GUBUN_BC,
              FACTORYCD,
              PRCSEMT,
              PRCGROUP,
              INSYN,
              BOXYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$PRC_CD,
              _$PRC_NM,
              IF(_$USE_YN = 1, 'Y', 'N'),
              GETDATETIME(_$FR_DT),
              GETDATETIME(_$TO_DT),
              _$GUBUN_BC,
              _$FAC_CD,
              _$PRC_SEMI,
              _$PRC_GU,
              _$WO_YN,
              _$BOX_YN,
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTPRC
          SET
              PRCNM     = IF(_$PRC_NM <> '', _$PRC_NM, PRCNM),
              USEYN     = IF(_$USE_YN <> '', IF(_$USE_YN = 1, 'Y', 'N'), USEYN),
              SDT       = IF(_$FR_DT <> '', GETDATETIME(_$FR_DT), SDT),
              EDT       = IF(_$TO_DT <> '', GETDATETIME(_$TO_DT), EDT),
              GUBUN_BC  = IF(_$GUBUN_BC <> '', _$GUBUN_BC, GUBUN_BC),
              FACTORYCD = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
              PRCSEMT   = IF(_$PRC_SEMI <> '', _$PRC_SEMI, PRCSEMT),
              PRCGROUP  = IF(_$PRC_GU <> '', _$PRC_GU, PRCGROUP),
              INSYN     = IF(_$WO_YN <> '', _$WO_YN, INSYN),
              BOXYN     = IF(_$BOX_YN <> '', _$BOX_YN, BOXYN),
              REMARK    = IF(_$RMKS <> '', _$RMKS, REMARK),
              MTIME     = GETTIME(),
              MEMP      = 'ERP',
              MPRG      = 'IF'
          WHERE PRCCD = _$PRC_CD;

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_PRC → MSTPRC
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTPRC
      WHERE PRCCD = _$PRC_CD;

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTPRC';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTPRC';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTPRCBAD`$$
CREATE PROCEDURE `MES_IF_MSTPRCBAD`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드 (PK)
    IN $WC_CD_LIST MEDIUMTEXT,           -- 작업장코드 (PK)
    IN $BAD_CD_LIST MEDIUMTEXT,          -- 불량코드 (PK)
    IN $BAD_NM_LIST MEDIUMTEXT,          -- 불량명
    IN $DISP_SQ_LIST MEDIUMTEXT,         -- 순서
    IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
    IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$WC_CD VARCHAR(10);
  DECLARE _$BAD_CD VARCHAR(10);
  DECLARE _$BAD_NM VARCHAR(50);
  DECLARE _$DISP_SQ VARCHAR(50);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTPRCBAD',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($FAC_CD_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
      CALL COMSPLIT($WC_CD_LIST, _$WC_CD);
      CALL COMSPLIT($BAD_CD_LIST, _$BAD_CD);
      CALL COMSPLIT($BAD_NM_LIST, _$BAD_NM);
      CALL COMSPLIT($DISP_SQ_LIST, _$DISP_SQ);
      CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
      CALL COMSPLIT($RMKS_LIST, _$RMKS);

      -- *************************************************************
      -- 빈문자열('') → NULL (숫자)
      -- *************************************************************
      SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
      SET _$DISP_SQ = NULLIF(TRIM(_$DISP_SQ), '');

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_PRCBAD → MSTPRCBAD
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTPRCBAD
          WHERE FACTORYCD = _$FAC_CD
            AND LINECD    = _$WC_CD
            AND BADCD     = _$BAD_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTPRCBAD
          (
              FACTORYCD,
              LINECD,
              BADCD,
              BADNM,
              SORTNO,
              USEYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$FAC_CD,
              _$WC_CD,
              _$BAD_CD,
              _$BAD_NM,
              IFNULL(CONVERT(_$DISP_SQ, SIGNED), 0),
              _$USE_YN,
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_PRCBAD → MSTPRCBAD
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTPRCBAD
          WHERE FACTORYCD = _$FAC_CD
            AND LINECD    = _$WC_CD
            AND BADCD     = _$BAD_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTPRCBAD
          (
              FACTORYCD,
              LINECD,
              BADCD,
              BADNM,
              SORTNO,
              USEYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$FAC_CD,
              _$WC_CD,
              _$BAD_CD,
              _$BAD_NM,
              IFNULL(CONVERT(_$DISP_SQ, SIGNED), 0),
              _$USE_YN,
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTPRCBAD
          SET
              BADNM  = IF(_$BAD_NM <> '', _$BAD_NM, BADNM),
              SORTNO = IFNULL(CONVERT(_$DISP_SQ, SIGNED), 0),
              USEYN  = IF(_$USE_YN <> '', _$USE_YN, USEYN),
              REMARK = IF(_$RMKS <> '', _$RMKS, REMARK),
              MTIME  = GETTIME(),
              MEMP   = 'ERP',
              MPRG   = 'IF'
          WHERE FACTORYCD = _$FAC_CD
            AND LINECD    = _$WC_CD
            AND BADCD     = _$BAD_CD;

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_PRCBAD → MSTPRCBAD
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTPRCBAD
      WHERE FACTORYCD = _$FAC_CD
        AND LINECD    = _$WC_CD
        AND BADCD     = _$BAD_CD;

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTPRCBAD';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTPRCBAD';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTROUT`$$
CREATE PROCEDURE `MES_IF_MSTROUT`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $ROUT_CD_LIST MEDIUMTEXT,         -- Routing코드 (PK)
    IN $ROUT_NM_LIST MEDIUMTEXT,         -- Routing명
    IN $ROUT_BC_LIST MEDIUMTEXT,         -- Routing구분
    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드
    IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
    IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
    IN $ENT_ID_LIST MEDIUMTEXT,          -- 등록ID
    IN $RMKS_LIST MEDIUMTEXT,            -- 비고

    IN $OLD_CD_LIST MEDIUMTEXT,          -- 구품목코드
    IN $USE_YN_LIST MEDIUMTEXT           -- 사용여부
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ROUT_CD VARCHAR(50);
  DECLARE _$ROUT_NM VARCHAR(100);
  DECLARE _$ROUT_BC VARCHAR(10);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$ENT_ID VARCHAR(50);
  DECLARE _$RMKS VARCHAR(1000);

  DECLARE _$OLD_CD VARCHAR(50);
  DECLARE _$USE_YN VARCHAR(1);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTROUT',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ROUT_CD_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($ROUT_CD_LIST, _$ROUT_CD);
      CALL COMSPLIT($ROUT_NM_LIST, _$ROUT_NM);
      CALL COMSPLIT($ROUT_BC_LIST, _$ROUT_BC);
      CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
      CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
      CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
      CALL COMSPLIT($ENT_ID_LIST, _$ENT_ID);
      CALL COMSPLIT($RMKS_LIST, _$RMKS);

      CALL COMSPLIT($OLD_CD_LIST, _$OLD_CD);
      CALL COMSPLIT($USE_YN_LIST, _$USE_YN);

      -- *************************************************************
      -- 빈문자열('') → NULL (숫자/날짜)
      -- *************************************************************
      SET _$IFKEY  = NULLIF(TRIM(_$IFKEY), '');
      SET _$ENT_ID = NULLIF(TRIM(_$ENT_ID), '');
      SET _$FR_DT  = NULLIF(TRIM(_$FR_DT), '');
      SET _$TO_DT  = NULLIF(TRIM(_$TO_DT), '');

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_ROUT → MSTROUT
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTROUT
          WHERE ROUTCD = _$ROUT_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTROUT
          (
              ROUTCD,
              ROUTNM,
              ROUT_BC,
              FACTORYCD,
              SDT,
              EDT,
              ENTID,
              OLDROUTCD,
              USEYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$ROUT_CD,
              _$ROUT_NM,
              _$ROUT_BC,
              _$FAC_CD,
              IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
              IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              IFNULL(CONVERT(_$ENT_ID, SIGNED), 0),
              _$OLD_CD,
              _$USE_YN = IF(_$USE_YN = '1', 'Y', 'N'),
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_ROUT → MSTROUT
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTROUT
          WHERE ROUTCD = _$ROUT_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTROUT
          (
              ROUTCD,
              ROUTNM,
              ROUT_BC,
              FACTORYCD,
              SDT,
              EDT,
              ENTID,
              OLDROUTCD,
              USEYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$ROUT_CD,
              _$ROUT_NM,
              _$ROUT_BC,
              _$FAC_CD,
              IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
              IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              IFNULL(CONVERT(_$ENT_ID, SIGNED), 0),
              _$OLD_CD,
              _$USE_YN = IF(_$USE_YN = '1', 'Y', 'N'),
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTROUT
          SET
              ROUTNM    = IF(_$ROUT_NM <> '', _$ROUT_NM, ROUTNM),
              ROUT_BC   = IF(_$ROUT_BC <> '', _$ROUT_BC, ROUT_BC),
              FACTORYCD = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
              SDT       = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
              EDT       = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              ENTID     = IFNULL(CONVERT(_$ENT_ID, SIGNED), 0),
              OLDROUTCD = IF(_$OLD_CD <> '', _$OLD_CD, OLDROUTCD),
              USEYN     = IF(_$USE_YN <> '', _$USE_YN = IF(_$USE_YN = '1', 'Y', 'N'), USEYN),
              REMARK    = IF(_$RMKS <> '', _$RMKS, REMARK),
              MTIME     = GETTIME(),
              MEMP      = 'ERP',
              MPRG      = 'IF'
          WHERE ROUTCD = _$ROUT_CD;

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_ROUT → MSTROUT
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTROUT
      WHERE ROUTCD = _$ROUT_CD;

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTROUT';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTROUT';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTROUT_DETAIL`$$
CREATE PROCEDURE `MES_IF_MSTROUT_DETAIL`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $ROUT_CD_LIST MEDIUMTEXT,         -- Routing코드 (PK)
    IN $ROUT_SQ_LIST MEDIUMTEXT,         -- Routing순번 (PK)
    IN $PRC_CD_LIST MEDIUMTEXT,          -- 공정코드
    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드
    IN $WC_CD_LIST MEDIUMTEXT,           -- 작업장코드
    IN $MC_CD_LIST MEDIUMTEXT,           -- 설비코드
    IN $ENT_YN_LIST MEDIUMTEXT,          -- 생산투입보고여부
    IN $END_YN_LIST MEDIUMTEXT,          -- 마감여부
    IN $AUTO_YN_LIST MEDIUMTEXT,         -- 자동입력
    IN $OUT_YN_LIST MEDIUMTEXT,          -- 자동출고처리여부
    IN $INSP_BC_LIST MEDIUMTEXT,         -- 검사구분
    IN $LEAD_TM_LIST MEDIUMTEXT,         -- 공정간리드타임
    IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
    IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
    IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ROUT_CD VARCHAR(50);
  DECLARE _$ROUT_SQ VARCHAR(50);
  DECLARE _$PRC_CD VARCHAR(10);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$WC_CD VARCHAR(10);
  DECLARE _$MC_CD VARCHAR(20);
  DECLARE _$ENT_YN VARCHAR(1);
  DECLARE _$END_YN VARCHAR(1);
  DECLARE _$AUTO_YN VARCHAR(1);
  DECLARE _$OUT_YN VARCHAR(1);
  DECLARE _$INSP_BC VARCHAR(10);
  DECLARE _$LEAD_TM VARCHAR(50);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTROUT_DETAIL',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ROUT_CD_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($ROUT_CD_LIST, _$ROUT_CD);
      CALL COMSPLIT($ROUT_SQ_LIST, _$ROUT_SQ);
      CALL COMSPLIT($PRC_CD_LIST, _$PRC_CD);
      CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
      CALL COMSPLIT($WC_CD_LIST, _$WC_CD);
      CALL COMSPLIT($MC_CD_LIST, _$MC_CD);
      CALL COMSPLIT($ENT_YN_LIST, _$ENT_YN);
      CALL COMSPLIT($END_YN_LIST, _$END_YN);
      CALL COMSPLIT($AUTO_YN_LIST, _$AUTO_YN);
      CALL COMSPLIT($OUT_YN_LIST, _$OUT_YN);
      CALL COMSPLIT($INSP_BC_LIST, _$INSP_BC);
      CALL COMSPLIT($LEAD_TM_LIST, _$LEAD_TM);
      CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
      CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
      CALL COMSPLIT($RMKS_LIST, _$RMKS);

      -- *************************************************************
      -- 빈문자열('') → NULL (숫자/날짜)
      -- *************************************************************
      SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
      SET _$ROUT_SQ = NULLIF(TRIM(_$ROUT_SQ), '');
      SET _$LEAD_TM = NULLIF(TRIM(_$LEAD_TM), '');
      SET _$FR_DT   = NULLIF(TRIM(_$FR_DT), '');
      SET _$TO_DT   = NULLIF(TRIM(_$TO_DT), '');

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_ROUT_DTL → MSTROUT_DETAIL
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTROUT_DETAIL
          WHERE ROUTCD  = _$ROUT_CD
            AND ROUTSEQ = CONVERT(_$ROUT_SQ, SIGNED)
      )
      THEN

          INSERT INTO MES_SNS2.MSTROUT_DETAIL
          (
              ROUTCD,
              ROUTSEQ,
              PRCCD,
              FACTORYCD,
              LINCD,
              EQMCD,
              ENTYN,
              ENDYN,
              AUTOYN,
              OUTYN,
              INSPC_BC,
              READTIME,
              SDT,
              EDT,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$ROUT_CD,
              CONVERT(_$ROUT_SQ, SIGNED),
              _$PRC_CD,
              _$FAC_CD,
              _$WC_CD,
              _$MC_CD,
              _$ENT_YN = IF(_$ENT_YN = '1', 'Y', 'N'),
              _$END_YN = IF(_$END_YN = '1', 'Y', 'N'),
              _$AUTO_YN = IF(_$AUTO_YN = '1', 'Y', 'N'),
              _$OUT_YN = IF(_$OUT_YN = '1', 'Y', 'N'),
              _$INSP_BC,
              IFNULL(CONVERT(_$LEAD_TM, SIGNED), 0),
              IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
              IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_ROUT_DTL → MSTROUT_DETAIL
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTROUT_DETAIL
          WHERE ROUTCD  = _$ROUT_CD
            AND ROUTSEQ = CONVERT(_$ROUT_SQ, SIGNED)
      )
      THEN

          INSERT INTO MES_SNS2.MSTROUT_DETAIL
          (
              ROUTCD,
              ROUTSEQ,
              PRCCD,
              FACTORYCD,
              LINCD,
              EQMCD,
              ENTYN,
              ENDYN,
              AUTOYN,
              OUTYN,
              INSPC_BC,
              READTIME,
              SDT,
              EDT,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$ROUT_CD,
              CONVERT(_$ROUT_SQ, SIGNED),
              _$PRC_CD,
              _$FAC_CD,
              _$WC_CD,
              _$MC_CD,
              _$ENT_YN = IF(_$ENT_YN = '1', 'Y', 'N'),
              _$END_YN = IF(_$END_YN = '1', 'Y', 'N'),
              _$AUTO_YN = IF(_$AUTO_YN = '1', 'Y', 'N'),
              _$OUT_YN = IF(_$OUT_YN = '1', 'Y', 'N'),
              _$INSP_BC,
              IFNULL(CONVERT(_$LEAD_TM, SIGNED), 0),
              IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
              IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTROUT_DETAIL
          SET
              PRCCD    = IF(_$PRC_CD <> '', _$PRC_CD, PRCCD),
              FACTORYCD= IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
              LINCD    = IF(_$WC_CD <> '', _$WC_CD, LINCD),
              EQMCD    = IF(_$MC_CD <> '', _$MC_CD, EQMCD),
              ENTYN    = IF(_$ENT_YN <> '', IF(_$ENT_YN = '1', 'Y', 'N'), ENTYN),
              ENDYN    = IF(_$END_YN <> '', IF(_$END_YN = '1', 'Y', 'N'), ENDYN),
              AUTOYN   = IF(_$AUTO_YN <> '', IF(_$AUTO_YN = '1', 'Y', 'N'), AUTOYN),
              OUTYN    = IF(_$OUT_YN <> '', IF(_$OUT_YN = '1', 'Y', 'N'), OUTYN),
              INSPC_BC = IF(_$INSP_BC <> '', _$INSP_BC, INSPC_BC),
              READTIME = IFNULL(CONVERT(_$LEAD_TM, SIGNED), 0),
              SDT      = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
              EDT      = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
              REMARK   = IF(_$RMKS <> '', _$RMKS, REMARK),
              MTIME    = GETTIME(),
              MEMP     = 'ERP',
              MPRG     = 'IF'
          WHERE ROUTCD  = _$ROUT_CD
            AND ROUTSEQ = CONVERT(_$ROUT_SQ, SIGNED);

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_ROUT_DTL → MSTROUT_DETAIL
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTROUT_DETAIL
      WHERE ROUTCD  = _$ROUT_CD
        AND ROUTSEQ = CONVERT(_$ROUT_SQ, SIGNED);

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTROUT_DETAIL';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTROUT_DETAIL';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTROUT_MATCH`$$
CREATE PROCEDURE `MES_IF_MSTROUT_MATCH`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $ITM_ID_LIST MEDIUMTEXT,          -- 품목ID (PK)
    IN $ROUT_CD_LIST MEDIUMTEXT,         -- Routing코드 (PK)
    IN $BAS_YN_LIST MEDIUMTEXT,          -- 기본여부
    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드 (PK)
    IN $PLAN_RT_LIST MEDIUMTEXT,         -- 계획비율
    IN $FIT_LOT_LIST MEDIUMTEXT,         -- 적정생산LOT
    IN $MIN_LOT_LIST MEDIUMTEXT,         -- 최소생산LOT
    IN $MAX_LOT_LIST MEDIUMTEXT,         -- 최대생산LOT
    IN $FR_DT_LIST MEDIUMTEXT,           -- 적용시작일
    IN $TO_DT_LIST MEDIUMTEXT,           -- 적용종료일
    IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$ITM_ID VARCHAR(50);
  DECLARE _$ROUT_CD VARCHAR(50);
  DECLARE _$BAS_YN VARCHAR(1);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$PLAN_RT VARCHAR(50);
  DECLARE _$FIT_LOT VARCHAR(50);
  DECLARE _$MIN_LOT VARCHAR(50);
  DECLARE _$MAX_LOT VARCHAR(50);
  DECLARE _$FR_DT VARCHAR(50);
  DECLARE _$TO_DT VARCHAR(50);
  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTROUT_MATCH',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($ITM_ID_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
    CALL COMSPLIT($ROUT_CD_LIST, _$ROUT_CD);
    CALL COMSPLIT($BAS_YN_LIST, _$BAS_YN);
    CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
    CALL COMSPLIT($PLAN_RT_LIST, _$PLAN_RT);
    CALL COMSPLIT($FIT_LOT_LIST, _$FIT_LOT);
    CALL COMSPLIT($MIN_LOT_LIST, _$MIN_LOT);
    CALL COMSPLIT($MAX_LOT_LIST, _$MAX_LOT);
    CALL COMSPLIT($FR_DT_LIST, _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST, _$TO_DT);
    CALL COMSPLIT($RMKS_LIST, _$RMKS);

    -- *************************************************************
    -- 빈문자열('') → NULL (숫자/날짜)
    -- *************************************************************
    SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
    SET _$ITM_ID  = NULLIF(TRIM(_$ITM_ID), '');
    SET _$PLAN_RT = NULLIF(TRIM(_$PLAN_RT), '');
    SET _$FIT_LOT = NULLIF(TRIM(_$FIT_LOT), '');
    SET _$MIN_LOT = NULLIF(TRIM(_$MIN_LOT), '');
    SET _$MAX_LOT = NULLIF(TRIM(_$MAX_LOT), '');
    SET _$FR_DT   = NULLIF(TRIM(_$FR_DT), '');
    SET _$TO_DT   = NULLIF(TRIM(_$TO_DT), '');

    IF _$FIRSTKEY = 0 THEN
        SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
    END IF;

    -- *************************************************************
    -- I : 신규등록
    -- FAC2_MES_ROUT_MATCH → MSTROUT_MATCH
    -- *************************************************************
    IF _$IF_TYPE = 'I' THEN

        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTROUT_MATCH
            WHERE ITEMID    = IFNULL(CONVERT(_$ITM_ID, SIGNED), 0)
              AND ROUTCD    = _$ROUT_CD
              AND FACTORYCD = _$FAC_CD
        )
        THEN

            INSERT INTO MES_SNS2.MSTROUT_MATCH
            (
                ITEMID,
                ROUTCD,
                BASEYN,
                FACTORYCD,
                PLAN_RT,
                LOT_FIT,
                LOT_MIN,
                LOT_MAX,
                SDT,
                EDT,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                IFNULL(CONVERT(_$ITM_ID, SIGNED), 0),
                _$ROUT_CD,
                IF(_$BAS_YN = 1, 'Y', 'N'),
                _$FAC_CD,
                IFNULL(CONVERT(_$PLAN_RT, DECIMAL(5,0)), 0),
                IFNULL(CONVERT(_$FIT_LOT, DECIMAL(18,0)), 0),
                IFNULL(CONVERT(_$MIN_LOT, DECIMAL(18,0)), 0),
                IFNULL(CONVERT(_$MAX_LOT, DECIMAL(18,0)), 0),
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );

        END IF;

    -- *************************************************************
    -- U : 수정
    -- FAC2_MES_ROUT_MATCH → MSTROUT_MATCH
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'U' THEN

        IF NOT EXISTS
        (
            SELECT 1
            FROM MES_SNS2.MSTROUT_MATCH
            WHERE ITEMID    = IFNULL(CONVERT(_$ITM_ID, SIGNED), 0)
              AND ROUTCD    = _$ROUT_CD
              AND FACTORYCD = _$FAC_CD
        )
        THEN

            INSERT INTO MES_SNS2.MSTROUT_MATCH
            (
                ITEMID,
                ROUTCD,
                BASEYN,
                FACTORYCD,
                PLAN_RT,
                LOT_FIT,
                LOT_MIN,
                LOT_MAX,
                SDT,
                EDT,
                REMARK,
                RTIME,
                REMP,
                RPRG
            )
            VALUES
            (
                IFNULL(CONVERT(_$ITM_ID, SIGNED), 0),
                _$ROUT_CD,
                IF(_$BAS_YN = 1, 'Y', 'N'),
                _$FAC_CD,
                IFNULL(CONVERT(_$PLAN_RT, DECIMAL(5,0)), 0),
                IFNULL(CONVERT(_$FIT_LOT, DECIMAL(18,0)), 0),
                IFNULL(CONVERT(_$MIN_LOT, DECIMAL(18,0)), 0),
                IFNULL(CONVERT(_$MAX_LOT, DECIMAL(18,0)), 0),
                IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                _$RMKS,
                GETTIME(),
                'ERP',
                'IF'
            );

        ELSE

            UPDATE MES_SNS2.MSTROUT_MATCH
            SET
                BASEYN    = IF(_$BAS_YN <> '', IF(_$BAS_YN = 1, 'Y', 'N'), BASEYN),
                PLAN_RT   = IFNULL(CONVERT(_$PLAN_RT, DECIMAL(5,0)), 0),
                LOT_FIT   = IFNULL(CONVERT(_$FIT_LOT, DECIMAL(18,0)), 0),
                LOT_MIN   = IFNULL(CONVERT(_$MIN_LOT, DECIMAL(18,0)), 0),
                LOT_MAX   = IFNULL(CONVERT(_$MAX_LOT, DECIMAL(18,0)), 0),
                SDT       = IF(_$FR_DT IS NULL, NULL, GETDATETIME(_$FR_DT)),
                EDT       = IF(_$TO_DT IS NULL, NULL, GETDATETIME(_$TO_DT)),
                REMARK    = IF(_$RMKS <> '', _$RMKS, REMARK),
                MTIME     = GETTIME(),
                MEMP      = 'ERP',
                MPRG      = 'IF'
            WHERE ITEMID    = IFNULL(CONVERT(_$ITM_ID, SIGNED), 0)
              AND ROUTCD    = _$ROUT_CD
              AND FACTORYCD = _$FAC_CD;

        END IF;

    -- *************************************************************
    -- D : 삭제
    -- FAC2_MES_ROUT_MATCH → MSTROUT_MATCH
    -- *************************************************************
    ELSEIF _$IF_TYPE = 'D' THEN

        DELETE
        FROM MES_SNS2.MSTROUT_MATCH
        WHERE ITEMID    = IFNULL(CONVERT(_$ITM_ID, SIGNED), 0)
          AND ROUTCD    = _$ROUT_CD
          AND FACTORYCD = _$FAC_CD;

    END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTROUT_MATCH';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTROUT_MATCH';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTWARE`$$
CREATE PROCEDURE `MES_IF_MSTWARE`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $WH_CD_LIST MEDIUMTEXT,           -- 창고코드 (PK)
    IN $WH_NM_LIST MEDIUMTEXT,           -- 창고명
    IN $FAC_CD_LIST MEDIUMTEXT,          -- 공장코드
    IN $MAT_YN_LIST MEDIUMTEXT,          -- 자재창고여부
    IN $PROC_YN_LIST MEDIUMTEXT,         -- 공정창고여부
    IN $PART_YN_LIST MEDIUMTEXT,         -- 구매입고창고여부
    IN $PROD_YN_LIST MEDIUMTEXT,         -- 생산인원여부(제품창고)
    IN $VMI_YN_LIST MEDIUMTEXT,          -- 가상창고여부
    IN $RTN_YN_LIST MEDIUMTEXT,          -- 반려여부(출하반품)
    IN $SAL_YN_LIST MEDIUMTEXT,          -- 매출여부(매출창고여부)
    IN $SUB_YN_LIST MEDIUMTEXT,          -- 외주창고여부
    IN $HEAD_YN_LIST MEDIUMTEXT,         -- 본사여부(본사창고여부)
    IN $BAD_YN_LIST MEDIUMTEXT,          -- 불량창고여부
    IN $SAL_COMMON_YN_LIST MEDIUMTEXT,   -- 공통매출창고
    IN $USE_YN_LIST MEDIUMTEXT,          -- 사용여부
    IN $MINUS_YN_LIST MEDIUMTEXT,        -- (-)재고허용
    IN $CUST_CD_LIST MEDIUMTEXT,         -- 거래처코드
    IN $DEPT_CD_LIST MEDIUMTEXT,         -- 부서코드
    IN $DISP_SQ_LIST MEDIUMTEXT,         -- 순서(정렬순서)
    IN $RMKS_LIST MEDIUMTEXT             -- 비고
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$WH_CD VARCHAR(10);
  DECLARE _$WH_NM VARCHAR(100);
  DECLARE _$FAC_CD VARCHAR(10);
  DECLARE _$MAT_YN VARCHAR(1);
  DECLARE _$PROC_YN VARCHAR(1);
  DECLARE _$PART_YN VARCHAR(1);
  DECLARE _$PROD_YN VARCHAR(1);
  DECLARE _$VMI_YN VARCHAR(1);
  DECLARE _$RTN_YN VARCHAR(1);
  DECLARE _$SAL_YN VARCHAR(1);
  DECLARE _$SUB_YN VARCHAR(1);
  DECLARE _$HEAD_YN VARCHAR(1);
  DECLARE _$BAD_YN VARCHAR(1);
  DECLARE _$SAL_COMMON_YN VARCHAR(1);
  DECLARE _$USE_YN VARCHAR(1);
  DECLARE _$MINUS_YN VARCHAR(1);
  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$DEPT_CD VARCHAR(10);
  DECLARE _$DISP_SQ VARCHAR(50);
  DECLARE _$RMKS VARCHAR(1000);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_MSTWARE',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($WH_CD_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($WH_CD_LIST, _$WH_CD);
      CALL COMSPLIT($WH_NM_LIST, _$WH_NM);
      CALL COMSPLIT($FAC_CD_LIST, _$FAC_CD);
      CALL COMSPLIT($MAT_YN_LIST, _$MAT_YN);
      CALL COMSPLIT($PROC_YN_LIST, _$PROC_YN);
      CALL COMSPLIT($PART_YN_LIST, _$PART_YN);
      CALL COMSPLIT($PROD_YN_LIST, _$PROD_YN);
      CALL COMSPLIT($VMI_YN_LIST, _$VMI_YN);
      CALL COMSPLIT($RTN_YN_LIST, _$RTN_YN);
      CALL COMSPLIT($SAL_YN_LIST, _$SAL_YN);
      CALL COMSPLIT($SUB_YN_LIST, _$SUB_YN);
      CALL COMSPLIT($HEAD_YN_LIST, _$HEAD_YN);
      CALL COMSPLIT($BAD_YN_LIST, _$BAD_YN);
      CALL COMSPLIT($SAL_COMMON_YN_LIST, _$SAL_COMMON_YN);
      CALL COMSPLIT($USE_YN_LIST, _$USE_YN);
      CALL COMSPLIT($MINUS_YN_LIST, _$MINUS_YN);
      CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
      CALL COMSPLIT($DEPT_CD_LIST, _$DEPT_CD);
      CALL COMSPLIT($DISP_SQ_LIST, _$DISP_SQ);
      CALL COMSPLIT($RMKS_LIST, _$RMKS);

      -- *************************************************************
      -- 빈문자열('') → NULL (숫자)
      -- *************************************************************
      SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
      SET _$DISP_SQ = NULLIF(TRIM(_$DISP_SQ), '');

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_WARE → MSTWARE
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTWARE
          WHERE WARECD = _$WH_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTWARE
          (
              WARECD,
              WARENM,
              FACTORYCD,
              MTRYN,
              PRCYN,
              PARTYN,
              PRODYN,
              VMIYN,
              RTNYN,
              SALYN,
              SUBYN,
              HEADYN,
              BAD_YN,
              SAL_COMMON_YN,
              USEYN,
              MINUS_YN,
              CUSTCD,
              DEPTCD,
              SORTNO,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$WH_CD,
              _$WH_NM,
              _$FAC_CD,
              IF(_$MAT_YN = 1, 'Y', 'N'),
              IF(_$PROC_YN = 1, 'Y', 'N'),
              IF(_$PART_YN = 1, 'Y', 'N'),
              IF(_$PROD_YN = 1, 'Y', 'N'),
              IF(_$VMI_YN = 1, 'Y', 'N'),
              IF(_$RTN_YN = 1, 'Y', 'N'),
              IF(_$SAL_YN = 1, 'Y', 'N'),
              IF(_$SUB_YN = 1, 'Y', 'N'),
              IF(_$HEAD_YN = 1, 'Y', 'N'),
              IF(_$BAD_YN = 1, 'Y', 'N'),
              IF(_$SAL_COMMON_YN = 1, 'Y', 'N'),
              IF(_$USE_YN = 1, 'Y', 'N'),
              IF(_$MINUS_YN = 1, 'Y', 'N'),
              _$CUST_CD,
              _$DEPT_CD,
              IFNULL(CONVERT(_$DISP_SQ, DECIMAL(20,0)), 0),
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_WARE → MSTWARE
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.MSTWARE
          WHERE WARECD = _$WH_CD
      )
      THEN

          INSERT INTO MES_SNS2.MSTWARE
          (
              WARECD,
              WARENM,
              FACTORYCD,
              MTRYN,
              PRCYN,
              PARTYN,
              PRODYN,
              VMIYN,
              RTNYN,
              SALYN,
              SUBYN,
              HEADYN,
              BAD_YN,
              SAL_COMMON_YN,
              USEYN,
              MINUS_YN,
              CUSTCD,
              DEPTCD,
              SORTNO,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$WH_CD,
              _$WH_NM,
              _$FAC_CD,
              IF(_$MAT_YN = 1, 'Y', 'N'),
              IF(_$PROC_YN = 1, 'Y', 'N'),
              IF(_$PART_YN = 1, 'Y', 'N'),
              IF(_$PROD_YN = 1, 'Y', 'N'),
              IF(_$VMI_YN = 1, 'Y', 'N'),
              IF(_$RTN_YN = 1, 'Y', 'N'),
              IF(_$SAL_YN = 1, 'Y', 'N'),
              IF(_$SUB_YN = 1, 'Y', 'N'),
              IF(_$HEAD_YN = 1, 'Y', 'N'),
              IF(_$BAD_YN = 1, 'Y', 'N'),
              IF(_$SAL_COMMON_YN = 1, 'Y', 'N'),
              IF(_$USE_YN = 1, 'Y', 'N'),
              IF(_$MINUS_YN = 1, 'Y', 'N'),
              _$CUST_CD,
              _$DEPT_CD,
              IFNULL(CONVERT(_$DISP_SQ, DECIMAL(20,0)), 0),
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.MSTWARE
          SET
              WARENM        = IF(_$WH_NM <> '', _$WH_NM, WARENM),
              FACTORYCD     = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
              MTRYN         = IF(_$MAT_YN <> '', IF(_$MAT_YN = 1, 'Y', 'N'), MTRYN),
              PRCYN         = IF(_$PROC_YN <> '', IF(_$PROC_YN = 1, 'Y', 'N'), PRCYN),
              PARTYN        = IF(_$PART_YN <> '', IF(_$PART_YN = 1, 'Y', 'N'), PARTYN),
              PRODYN        = IF(_$PROD_YN <> '', IF(_$PROD_YN = 1, 'Y', 'N'), PRODYN),
              VMIYN         = IF(_$VMI_YN <> '', IF(_$VMI_YN = 1, 'Y', 'N'), VMIYN),
              RTNYN         = IF(_$RTN_YN <> '', IF(_$RTN_YN = 1, 'Y', 'N'), RTNYN),
              SALYN         = IF(_$SAL_YN <> '', IF(_$SAL_YN = 1, 'Y', 'N'), SALYN),
              SUBYN         = IF(_$SUB_YN <> '', IF(_$SUB_YN = 1, 'Y', 'N'), SUBYN),
              HEADYN        = IF(_$HEAD_YN <> '', IF(_$HEAD_YN = 1, 'Y', 'N'), HEADYN),
              BAD_YN        = IF(_$BAD_YN <> '', IF(_$BAD_YN = 1, 'Y', 'N'), BAD_YN),
              SAL_COMMON_YN = IF(_$SAL_COMMON_YN <> '', IF(_$SAL_COMMON_YN = 1, 'Y', 'N'), SAL_COMMON_YN),
              USEYN         = IF(_$USE_YN <> '', IF(_$USE_YN = 1, 'Y', 'N'), USEYN),
              MINUS_YN      = IF(_$MINUS_YN <> '', IF(_$MINUS_YN = 1, 'Y', 'N'), MINUS_YN),
              CUSTCD        = IF(_$CUST_CD <> '', _$CUST_CD, CUSTCD),
              DEPTCD        = IF(_$DEPT_CD <> '', _$DEPT_CD, DEPTCD),
              SORTNO        = IFNULL(CONVERT(_$DISP_SQ, DECIMAL(20,0)), 0),
              REMARK        = IF(_$RMKS <> '', _$RMKS, REMARK),
              MTIME         = GETTIME(),
              MEMP          = 'ERP',
              MPRG          = 'IF'
          WHERE WARECD = _$WH_CD;

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_WARE → MSTWARE
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.MSTWARE
      WHERE WARECD = _$WH_CD;

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_MSTWARE';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_MSTWARE';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MTRODR`$$
CREATE PROCEDURE `MES_IF_MTRODR`(
    IN $IF_KEY_LIST   MEDIUMTEXT,   -- 인터페이스 KEY
    IN $IF_TYPE_LIST  MEDIUMTEXT,   -- 인터페이스 구분(I/U/D)
    IN $PO_NO_LIST    MEDIUMTEXT,   -- 발주번호
    IN $PO_DT_LIST    MEDIUMTEXT,   -- 발주일자
    IN $DLV_DT_LIST   MEDIUMTEXT,   -- 납기일자
    IN $DLV_RID_LIST  MEDIUMTEXT,   -- 납품자ID
    IN $CUST_CD_LIST  MEDIUMTEXT,   -- 거래처코드
    IN $PO_KD_LIST    MEDIUMTEXT,   -- 발주유형 BC:MM101
    IN $PO_BC_LIST    MEDIUMTEXT,   -- 발주구분 BC:MM100
    IN $URG_BC_LIST   MEDIUMTEXT,   -- 긴급구분 BC:MM105
    IN $CURY_BC_LIST  MEDIUMTEXT,   -- 통화구분 BC:BC400
    IN $EX_RT_LIST    MEDIUMTEXT,   -- 환율
    IN $DI_BC_LIST    MEDIUMTEXT,   -- 매입지역구분 BC:MM060
    IN $PO_DEPT_LIST  MEDIUMTEXT,   -- 발주부서코드
    IN $PO_RID_LIST   MEDIUMTEXT,   -- 발주담당자ID
    IN $PO_FAC_LIST   MEDIUMTEXT,   -- 발주공장코드
    IN $IN_FAC_LIST   MEDIUMTEXT,   -- 입고공장코드
    IN $IN_WH_LIST    MEDIUMTEXT,   -- 입고창고코드
    IN $IN_CUST_LIST  MEDIUMTEXT,   -- 입고거래처코드
    IN $STAT_BC_LIST  MEDIUMTEXT,   -- 진행상태
    IN $ENT_BC_LIST   MEDIUMTEXT,   -- 입력경로
    IN $RMKS_LIST     MEDIUMTEXT,   -- 비고
    IN $MOV_NO_LIST   MEDIUMTEXT,   -- 이동번호
    IN $MOV_SQ_LIST   MEDIUMTEXT    -- 이동순번
)
PROC: BEGIN

    DECLARE _$IFKEY     INT;
    DECLARE _$FIRSTKEY  INT DEFAULT 0;
    DECLARE _$IF_TYPE   VARCHAR(1);

    DECLARE _$PO_NO     VARCHAR(20);
    DECLARE _$PO_DT     VARCHAR(30);
    DECLARE _$DLV_DT    VARCHAR(30);
    DECLARE _$DLV_RID   VARCHAR(20);
    DECLARE _$CUST_CD   VARCHAR(100);
    DECLARE _$PO_KD     VARCHAR(10);
    DECLARE _$PO_BC     VARCHAR(10);
    DECLARE _$URG_BC    VARCHAR(10);
    DECLARE _$CURY_BC   VARCHAR(10);
    DECLARE _$EX_RT     VARCHAR(50);
    DECLARE _$DI_BC     VARCHAR(10);
    DECLARE _$PO_DEPT   VARCHAR(10);
    DECLARE _$PO_RID    VARCHAR(20);
    DECLARE _$PO_FAC    VARCHAR(10);
    DECLARE _$IN_FAC    VARCHAR(10);
    DECLARE _$IN_WH     VARCHAR(10);
    DECLARE _$IN_CUST   VARCHAR(20);
    DECLARE _$STAT_BC   VARCHAR(10);
    DECLARE _$ENT_BC    VARCHAR(10);
    DECLARE _$RMKS      VARCHAR(200);
    DECLARE _$MOV_NO    VARCHAR(20);
    DECLARE _$MOV_SQ    VARCHAR(20);

    DECLARE _$N_DLV_RID INT            DEFAULT 0;
    DECLARE _$N_PO_RID  INT            DEFAULT 0;
    DECLARE _$N_MOV_SQ  INT            DEFAULT 0;
    DECLARE _$N_EX_RT   DECIMAL(18,5)  DEFAULT 0;

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        GET DIAGNOSTICS CONDITION 1
            @sqlstate = RETURNED_SQLSTATE,
            @errno    = MYSQL_ERRNO,
            @text     = MESSAGE_TEXT;

        INSERT INTO IF_ERR_LOG (IFKEY, IFGB, IFNAME, IF_TYPE, READTIME, ERRMSG)
        VALUES (
            _$IFKEY,
            'ERP',
            'MES_IF_MTRODR',
            _$IF_TYPE,
            GETTIME(),
            CONCAT('ERROR ', @errno, ' (', @sqlstate, '): ', @text)
        );

        COMMIT;
    END;

    WHILE LENGTH($PO_NO_LIST) > 0 DO

        CALL COMSPLIT($IF_KEY_LIST,  _$IFKEY);
        CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);
        CALL COMSPLIT($PO_NO_LIST,   _$PO_NO);
        CALL COMSPLIT($PO_DT_LIST,   _$PO_DT);
        CALL COMSPLIT($DLV_DT_LIST,  _$DLV_DT);
        CALL COMSPLIT($DLV_RID_LIST, _$DLV_RID);
        CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
        CALL COMSPLIT($PO_KD_LIST,   _$PO_KD);
        CALL COMSPLIT($PO_BC_LIST,   _$PO_BC);
        CALL COMSPLIT($URG_BC_LIST,  _$URG_BC);
        CALL COMSPLIT($CURY_BC_LIST, _$CURY_BC);
        CALL COMSPLIT($EX_RT_LIST,   _$EX_RT);
        CALL COMSPLIT($DI_BC_LIST,   _$DI_BC);
        CALL COMSPLIT($PO_DEPT_LIST, _$PO_DEPT);
        CALL COMSPLIT($PO_RID_LIST,  _$PO_RID);
        CALL COMSPLIT($PO_FAC_LIST,  _$PO_FAC);
        CALL COMSPLIT($IN_FAC_LIST,  _$IN_FAC);
        CALL COMSPLIT($IN_WH_LIST,   _$IN_WH);
        CALL COMSPLIT($IN_CUST_LIST, _$IN_CUST);
        CALL COMSPLIT($STAT_BC_LIST, _$STAT_BC);
        CALL COMSPLIT($ENT_BC_LIST,  _$ENT_BC);
        CALL COMSPLIT($RMKS_LIST,    _$RMKS);
        CALL COMSPLIT($MOV_NO_LIST,  _$MOV_NO);
        CALL COMSPLIT($MOV_SQ_LIST,  _$MOV_SQ);

        SET _$N_DLV_RID = CAST(IFNULL(NULLIF(_$DLV_RID, ''), '0') AS SIGNED);
        SET _$N_PO_RID  = CAST(IFNULL(NULLIF(_$PO_RID,  ''), '0') AS SIGNED);
        SET _$N_MOV_SQ  = CAST(IFNULL(NULLIF(_$MOV_SQ,  ''), '0') AS SIGNED);
        SET _$N_EX_RT   = CAST(IFNULL(NULLIF(_$EX_RT,   ''), '0') AS DECIMAL(18,5));

        IF _$FIRSTKEY = 0 THEN
            SET _$FIRSTKEY = _$IFKEY;
        END IF;

        IF _$IF_TYPE = 'I' THEN

            INSERT IGNORE INTO MES_SNS2.MTRODR (
                MTRODRKEY, MTRODRDATE, EXPDATE, CUSTEMPID, CUSTCD,
                ODRTP, ODRBC, URGBC, CURYBC, EXRT, DIBC,
                ODRDEPT, ODREMPID, ODRFACTORY, INFACTORYCD, INWARECD, INCUSTCD,
                MTRODRSTT, ODRENTBC, MOVNO, MOVSQ, REMARK,
                RTIME, REMP, RPRG
            ) VALUES (
                _$PO_NO,
                LEFT(_$PO_DT, 10),
                LEFT(_$DLV_DT, 10),
                _$N_DLV_RID,
                _$CUST_CD,
                _$PO_KD, _$PO_BC, _$URG_BC, _$CURY_BC,
                _$N_EX_RT,
                _$DI_BC, _$PO_DEPT,
                _$N_PO_RID,
                _$PO_FAC, _$IN_FAC, _$IN_WH, _$IN_CUST,
                _$STAT_BC, _$ENT_BC, _$MOV_NO,
                _$N_MOV_SQ,
                _$RMKS,
                GETTIME(), 'ERP', 'IF'
            );

        ELSEIF _$IF_TYPE = 'U' THEN

            INSERT INTO MES_SNS2.MTRODR (
                MTRODRKEY, MTRODRDATE, EXPDATE, CUSTEMPID, CUSTCD,
                ODRTP, ODRBC, URGBC, CURYBC, EXRT, DIBC,
                ODRDEPT, ODREMPID, ODRFACTORY, INFACTORYCD, INWARECD, INCUSTCD,
                MTRODRSTT, ODRENTBC, MOVNO, MOVSQ, REMARK,
                RTIME, REMP, RPRG
            ) VALUES (
                _$PO_NO,
                LEFT(_$PO_DT, 10),
                LEFT(_$DLV_DT, 10),
                _$N_DLV_RID,
                _$CUST_CD,
                _$PO_KD, _$PO_BC, _$URG_BC, _$CURY_BC,
                _$N_EX_RT,
                _$DI_BC, _$PO_DEPT,
                _$N_PO_RID,
                _$PO_FAC, _$IN_FAC, _$IN_WH, _$IN_CUST,
                _$STAT_BC, _$ENT_BC, _$MOV_NO,
                _$N_MOV_SQ,
                _$RMKS,
                GETTIME(), 'ERP', 'IF'
            )
            ON DUPLICATE KEY UPDATE
                MTRODRDATE  = IF(_$PO_DT   <> '', LEFT(_$PO_DT, 10), MTRODRDATE),
                EXPDATE     = IF(_$DLV_DT  <> '', LEFT(_$DLV_DT, 10), EXPDATE),
                CUSTEMPID   = IF(_$DLV_RID <> '', _$N_DLV_RID, CUSTEMPID),
                CUSTCD      = IF(_$CUST_CD <> '', _$CUST_CD, CUSTCD),
                ODRTP       = IF(_$PO_KD   <> '', _$PO_KD, ODRTP),
                ODRBC       = IF(_$PO_BC   <> '', _$PO_BC, ODRBC),
                URGBC       = IF(_$URG_BC  <> '', _$URG_BC, URGBC),
                CURYBC      = IF(_$CURY_BC <> '', _$CURY_BC, CURYBC),
                EXRT        = IF(_$EX_RT   <> '', _$N_EX_RT, EXRT),
                DIBC        = IF(_$DI_BC   <> '', _$DI_BC, DIBC),
                ODRDEPT     = IF(_$PO_DEPT <> '', _$PO_DEPT, ODRDEPT),
                ODREMPID    = IF(_$PO_RID  <> '', _$N_PO_RID, ODREMPID),
                ODRFACTORY  = IF(_$PO_FAC  <> '', _$PO_FAC, ODRFACTORY),
                INFACTORYCD = IF(_$IN_FAC  <> '', _$IN_FAC, INFACTORYCD),
                INWARECD    = IF(_$IN_WH   <> '', _$IN_WH, INWARECD),
                INCUSTCD    = IF(_$IN_CUST <> '', _$IN_CUST, INCUSTCD),
                MTRODRSTT   = IF(_$STAT_BC <> '', _$STAT_BC, MTRODRSTT),
                ODRENTBC    = IF(_$ENT_BC  <> '', _$ENT_BC, ODRENTBC),
                MOVNO       = IF(_$MOV_NO  <> '', _$MOV_NO, MOVNO),
                MOVSQ       = IF(_$MOV_SQ  <> '', _$N_MOV_SQ, MOVSQ),
                REMARK      = IF(_$RMKS    <> '', _$RMKS, REMARK),
                MEMP        = 'ERP',
                MTIME       = GETTIME(),
                MPRG        = 'IF';

        ELSEIF _$IF_TYPE = 'D' THEN

            DELETE FROM MES_SNS2.MTRODRD
             WHERE MTRODRKEY = _$PO_NO;

            DELETE FROM MES_SNS2.MTRODR
             WHERE MTRODRKEY = _$PO_NO;

        END IF;

    END WHILE;

    UPDATE IFSTD
       SET LASTTIME = GETTIME()
     WHERE PROCNAME = 'MES_IF_MTRODR';

    IF _$FIRSTKEY > 0 THEN
        SELECT IFKEY
          FROM IF_ERR_LOG
         WHERE IFKEY >= _$FIRSTKEY
           AND IFNAME = 'MES_IF_MTRODR';
    END IF;

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MTRODRD`$$
CREATE PROCEDURE `MES_IF_MTRODRD`(
    IN $IF_KEY_LIST    MEDIUMTEXT,
    IN $IF_TYPE_LIST   MEDIUMTEXT,
    IN $PO_NO_LIST     MEDIUMTEXT,
    IN $PO_SQ_LIST     MEDIUMTEXT,
    IN $ITM_ID_LIST    MEDIUMTEXT,
    IN $PO_QTY_LIST    MEDIUMTEXT,
    IN $PO_UP_LIST     MEDIUMTEXT,
    IN $PO_AMT_LIST    MEDIUMTEXT,
    IN $PO_FUP_LIST    MEDIUMTEXT,
    IN $PO_FAMT_LIST   MEDIUMTEXT,
    IN $DLV_UM_LIST    MEDIUMTEXT,
    IN $DLV_DT_LIST    MEDIUMTEXT,
    IN $DEL_DT_LIST    MEDIUMTEXT,
    IN $DEL_RID_LIST   MEDIUMTEXT,
    IN $REQ_NO_LIST    MEDIUMTEXT,
    IN $REQ_SQ_LIST    MEDIUMTEXT,
    IN $MRP_NO_LIST    MEDIUMTEXT,
    IN $MRP_SQ_LIST    MEDIUMTEXT,
    IN $DLV_QTY_LIST   MEDIUMTEXT,
    IN $IN_QTY_LIST    MEDIUMTEXT,
    IN $STAT_BC_LIST   MEDIUMTEXT,
    IN $CLS_RMKS_LIST  MEDIUMTEXT,
    IN $RMKS_LIST      MEDIUMTEXT,
    IN $FILE_NO_LIST   MEDIUMTEXT,
    IN $MOV_SQ_LIST    MEDIUMTEXT,
    IN $MOV_NO_LIST    MEDIUMTEXT,
    IN $RMKS2_LIST     MEDIUMTEXT,
    IN $FILE_SQ_LIST   MEDIUMTEXT
)
PROC: BEGIN

    DECLARE _$IFKEY     INT;
    DECLARE _$FIRSTKEY  INT DEFAULT 0;
    DECLARE _$IF_TYPE   VARCHAR(1);

    DECLARE _$PO_NO     VARCHAR(20);
    DECLARE _$PO_SQ     VARCHAR(20);
    DECLARE _$ITM_ID    VARCHAR(20);
    DECLARE _$PO_QTY    VARCHAR(50);
    DECLARE _$PO_UP     VARCHAR(50);
    DECLARE _$PO_AMT    VARCHAR(50);
    DECLARE _$PO_FUP    VARCHAR(50);
    DECLARE _$PO_FAMT   VARCHAR(50);
    DECLARE _$DLV_UM    VARCHAR(10);
    DECLARE _$DLV_DT    VARCHAR(30);
    DECLARE _$DEL_DT    VARCHAR(30);
    DECLARE _$DEL_RID   VARCHAR(20);
    DECLARE _$REQ_NO    VARCHAR(20);
    DECLARE _$REQ_SQ    VARCHAR(20);
    DECLARE _$MRP_NO    VARCHAR(20);
    DECLARE _$MRP_SQ    VARCHAR(20);
    DECLARE _$DLV_QTY   VARCHAR(50);
    DECLARE _$IN_QTY    VARCHAR(50);
    DECLARE _$STAT_BC   VARCHAR(10);
    DECLARE _$CLS_RMKS  VARCHAR(300);
    DECLARE _$RMKS      VARCHAR(100);
    DECLARE _$FILE_NO   VARCHAR(20);
    DECLARE _$MOV_SQ    VARCHAR(20);
    DECLARE _$MOV_NO    VARCHAR(20);
    DECLARE _$RMKS2     VARCHAR(1000);
    DECLARE _$FILE_SQ   VARCHAR(20);

    DECLARE _$N_PO_SQ    INT           DEFAULT 0;
    DECLARE _$N_ITM_ID   INT           DEFAULT 0;
    DECLARE _$N_DEL_RID  INT           DEFAULT 0;
    DECLARE _$N_REQ_SQ   INT           DEFAULT 0;
    DECLARE _$N_MRP_SQ   INT           DEFAULT 0;
    DECLARE _$N_MOV_SQ   INT           DEFAULT 0;
    DECLARE _$N_FILE_SQ  INT           DEFAULT 0;
    DECLARE _$N_PO_QTY   DECIMAL(18,5) DEFAULT 0;
    DECLARE _$N_PO_UP    DECIMAL(18,5) DEFAULT 0;
    DECLARE _$N_PO_AMT   DECIMAL(18,5) DEFAULT 0;
    DECLARE _$N_PO_FUP   DECIMAL(18,5) DEFAULT 0;
    DECLARE _$N_PO_FAMT  DECIMAL(18,5) DEFAULT 0;
    DECLARE _$N_DLV_QTY  DECIMAL(18,5) DEFAULT 0;
    DECLARE _$N_IN_QTY   DECIMAL(18,5) DEFAULT 0;
    DECLARE _$D_DLV_DT   VARCHAR(19);
    DECLARE _$D_DEL_DT   VARCHAR(19);

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        GET DIAGNOSTICS CONDITION 1
            @sqlstate = RETURNED_SQLSTATE,
            @errno    = MYSQL_ERRNO,
            @text     = MESSAGE_TEXT;

        INSERT INTO IF_ERR_LOG (IFKEY, IFGB, IFNAME, IF_TYPE, READTIME, ERRMSG)
        VALUES (
            _$IFKEY,
            'ERP',
            'MES_IF_MTRODRD',
            _$IF_TYPE,
            GETTIME(),
            CONCAT('ERROR ', @errno, ' (', @sqlstate, '): ', @text)
        );

        COMMIT;
    END;

    WHILE LENGTH($PO_NO_LIST) > 0 DO

        CALL COMSPLIT($IF_KEY_LIST,   _$IFKEY);
        CALL COMSPLIT($IF_TYPE_LIST,  _$IF_TYPE);
        CALL COMSPLIT($PO_NO_LIST,    _$PO_NO);
        CALL COMSPLIT($PO_SQ_LIST,    _$PO_SQ);
        CALL COMSPLIT($ITM_ID_LIST,   _$ITM_ID);
        CALL COMSPLIT($PO_QTY_LIST,   _$PO_QTY);
        CALL COMSPLIT($PO_UP_LIST,    _$PO_UP);
        CALL COMSPLIT($PO_AMT_LIST,   _$PO_AMT);
        CALL COMSPLIT($PO_FUP_LIST,   _$PO_FUP);
        CALL COMSPLIT($PO_FAMT_LIST,  _$PO_FAMT);
        CALL COMSPLIT($DLV_UM_LIST,   _$DLV_UM);
        CALL COMSPLIT($DLV_DT_LIST,   _$DLV_DT);
        CALL COMSPLIT($DEL_DT_LIST,   _$DEL_DT);
        CALL COMSPLIT($DEL_RID_LIST,  _$DEL_RID);
        CALL COMSPLIT($REQ_NO_LIST,   _$REQ_NO);
        CALL COMSPLIT($REQ_SQ_LIST,   _$REQ_SQ);
        CALL COMSPLIT($MRP_NO_LIST,   _$MRP_NO);
        CALL COMSPLIT($MRP_SQ_LIST,   _$MRP_SQ);
        CALL COMSPLIT($DLV_QTY_LIST,  _$DLV_QTY);
        CALL COMSPLIT($IN_QTY_LIST,   _$IN_QTY);
        CALL COMSPLIT($STAT_BC_LIST,  _$STAT_BC);
        CALL COMSPLIT($CLS_RMKS_LIST, _$CLS_RMKS);
        CALL COMSPLIT($RMKS_LIST,     _$RMKS);
        CALL COMSPLIT($FILE_NO_LIST,  _$FILE_NO);
        CALL COMSPLIT($MOV_SQ_LIST,   _$MOV_SQ);
        CALL COMSPLIT($MOV_NO_LIST,   _$MOV_NO);
        CALL COMSPLIT($RMKS2_LIST,    _$RMKS2);
        CALL COMSPLIT($FILE_SQ_LIST,  _$FILE_SQ);

        SET _$N_PO_SQ   = CAST(IFNULL(NULLIF(_$PO_SQ,   ''), '0') AS SIGNED);
        SET _$N_ITM_ID  = CAST(IFNULL(NULLIF(_$ITM_ID,  ''), '0') AS SIGNED);
        SET _$N_DEL_RID = CAST(IFNULL(NULLIF(_$DEL_RID, ''), '0') AS SIGNED);
        SET _$N_REQ_SQ  = CAST(IFNULL(NULLIF(_$REQ_SQ,  ''), '0') AS SIGNED);
        SET _$N_MRP_SQ  = CAST(IFNULL(NULLIF(_$MRP_SQ,  ''), '0') AS SIGNED);
        SET _$N_MOV_SQ  = CAST(IFNULL(NULLIF(_$MOV_SQ,  ''), '0') AS SIGNED);
        SET _$N_FILE_SQ = CAST(IFNULL(NULLIF(_$FILE_SQ, ''), '0') AS SIGNED);
        SET _$N_PO_QTY  = CAST(IFNULL(NULLIF(_$PO_QTY,  ''), '0') AS DECIMAL(18,5));
        SET _$N_PO_UP   = CAST(IFNULL(NULLIF(_$PO_UP,   ''), '0') AS DECIMAL(18,5));
        SET _$N_PO_AMT  = CAST(IFNULL(NULLIF(_$PO_AMT,  ''), '0') AS DECIMAL(18,5));
        SET _$N_PO_FUP  = CAST(IFNULL(NULLIF(_$PO_FUP,  ''), '0') AS DECIMAL(18,5));
        SET _$N_PO_FAMT = CAST(IFNULL(NULLIF(_$PO_FAMT, ''), '0') AS DECIMAL(18,5));
        SET _$N_DLV_QTY = CAST(IFNULL(NULLIF(_$DLV_QTY, ''), '0') AS DECIMAL(18,5));
        SET _$N_IN_QTY  = CAST(IFNULL(NULLIF(_$IN_QTY,  ''), '0') AS DECIMAL(18,5));
        SET _$D_DLV_DT  = CASE WHEN _$DLV_DT = '' THEN NULL ELSE GETDATETIME(_$DLV_DT) END;
        SET _$D_DEL_DT  = CASE WHEN _$DEL_DT = '' THEN NULL ELSE GETDATETIME(_$DEL_DT) END;

        IF _$FIRSTKEY = 0 THEN
            SET _$FIRSTKEY = _$IFKEY;
        END IF;

        IF _$IF_TYPE = 'I' THEN

            INSERT IGNORE INTO MES_SNS2.MTRODRD (
                MTRODRKEY, MTRODRSEQ, ITEMID,
                ODRQTY, MTRODRPRICE, MTRODRAMT, MTRODRFPRICE, MTRODRFAMT,
                DLVUM, EXPDATE, ODRDELDT, ODRDELEMPID,
                REQNO, REQSEQ, MRPNO, MRPSEQ,
                DLVQTY, INQTY, MTRODRSTT, CLSREMARK,
                FILENO, MOVSQ, MOVNO, RMKS2, FILESQ, REMARK,
                RTIME, REMP, RPRG
            ) VALUES (
                _$PO_NO,
                _$N_PO_SQ,
                _$N_ITM_ID,
                _$N_PO_QTY,
                _$N_PO_UP,
                _$N_PO_AMT,
                _$N_PO_FUP,
                _$N_PO_FAMT,
                _$DLV_UM,
                _$D_DLV_DT,
                _$D_DEL_DT,
                _$N_DEL_RID,
                _$REQ_NO,
                _$N_REQ_SQ,
                _$MRP_NO,
                _$N_MRP_SQ,
                _$N_DLV_QTY,
                _$N_IN_QTY,
                _$STAT_BC,
                _$CLS_RMKS,
                _$FILE_NO,
                _$N_MOV_SQ,
                _$MOV_NO,
                _$RMKS2,
                _$N_FILE_SQ,
                _$RMKS,
                GETTIME(), 'ERP', 'IF'
            );

        ELSEIF _$IF_TYPE = 'U' THEN

            INSERT INTO MES_SNS2.MTRODRD (
                MTRODRKEY, MTRODRSEQ, ITEMID,
                ODRQTY, MTRODRPRICE, MTRODRAMT, MTRODRFPRICE, MTRODRFAMT,
                DLVUM, EXPDATE, ODRDELDT, ODRDELEMPID,
                REQNO, REQSEQ, MRPNO, MRPSEQ,
                DLVQTY, INQTY, MTRODRSTT, CLSREMARK,
                FILENO, MOVSQ, MOVNO, RMKS2, FILESQ, REMARK,
                RTIME, REMP, RPRG
            ) VALUES (
                _$PO_NO,
                _$N_PO_SQ,
                _$N_ITM_ID,
                _$N_PO_QTY,
                _$N_PO_UP,
                _$N_PO_AMT,
                _$N_PO_FUP,
                _$N_PO_FAMT,
                _$DLV_UM,
                _$D_DLV_DT,
                _$D_DEL_DT,
                _$N_DEL_RID,
                _$REQ_NO,
                _$N_REQ_SQ,
                _$MRP_NO,
                _$N_MRP_SQ,
                _$N_DLV_QTY,
                _$N_IN_QTY,
                _$STAT_BC,
                _$CLS_RMKS,
                _$FILE_NO,
                _$N_MOV_SQ,
                _$MOV_NO,
                _$RMKS2,
                _$N_FILE_SQ,
                _$RMKS,
                GETTIME(), 'ERP', 'IF'
            )
            ON DUPLICATE KEY UPDATE
                ITEMID       = IF(_$ITM_ID   <> '', _$N_ITM_ID, ITEMID),
                ODRQTY       = IF(_$PO_QTY   <> '', _$N_PO_QTY, ODRQTY),
                MTRODRPRICE  = IF(_$PO_UP    <> '', _$N_PO_UP, MTRODRPRICE),
                MTRODRAMT    = IF(_$PO_AMT   <> '', _$N_PO_AMT, MTRODRAMT),
                MTRODRFPRICE = IF(_$PO_FUP   <> '', _$N_PO_FUP, MTRODRFPRICE),
                MTRODRFAMT   = IF(_$PO_FAMT  <> '', _$N_PO_FAMT, MTRODRFAMT),
                DLVUM        = IF(_$DLV_UM   <> '', _$DLV_UM, DLVUM),
                EXPDATE      = IF(_$DLV_DT   <> '', _$D_DLV_DT, EXPDATE),
                ODRDELDT     = IF(_$DEL_DT   <> '', _$D_DEL_DT, ODRDELDT),
                ODRDELEMPID  = IF(_$DEL_RID  <> '', _$N_DEL_RID, ODRDELEMPID),
                REQNO        = IF(_$REQ_NO   <> '', _$REQ_NO, REQNO),
                REQSEQ       = IF(_$REQ_SQ   <> '', _$N_REQ_SQ, REQSEQ),
                MRPNO        = IF(_$MRP_NO   <> '', _$MRP_NO, MRPNO),
                MRPSEQ       = IF(_$MRP_SQ   <> '', _$N_MRP_SQ, MRPSEQ),
                DLVQTY       = IF(_$DLV_QTY  <> '', _$N_DLV_QTY, DLVQTY),
                INQTY        = IF(_$IN_QTY   <> '', _$N_IN_QTY, INQTY),
                MTRODRSTT    = IF(_$STAT_BC  <> '', _$STAT_BC, MTRODRSTT),
                CLSREMARK    = IF(_$CLS_RMKS <> '', _$CLS_RMKS, CLSREMARK),
                FILENO       = IF(_$FILE_NO  <> '', _$FILE_NO, FILENO),
                MOVSQ        = IF(_$MOV_SQ   <> '', _$N_MOV_SQ, MOVSQ),
                MOVNO        = IF(_$MOV_NO   <> '', _$MOV_NO, MOVNO),
                RMKS2        = IF(_$RMKS2    <> '', _$RMKS2, RMKS2),
                FILESQ       = IF(_$FILE_SQ  <> '', _$N_FILE_SQ, FILESQ),
                REMARK       = IF(_$RMKS     <> '', _$RMKS, REMARK),
                MTIME        = GETTIME(),
                MEMP         = 'ERP',
                MPRG         = 'IF';

        ELSEIF _$IF_TYPE = 'D' THEN

            DELETE FROM MES_SNS2.MTRODRD
             WHERE MTRODRKEY = _$PO_NO
               AND MTRODRSEQ = _$N_PO_SQ;

        END IF;

    END WHILE;

    UPDATE IFSTD
       SET LASTTIME = GETTIME()
     WHERE PROCNAME = 'MES_IF_MTRODRD';

    IF _$FIRSTKEY > 0 THEN
        SELECT IFKEY
          FROM IF_ERR_LOG
         WHERE IFKEY >= _$FIRSTKEY
           AND IFNAME = 'MES_IF_MTRODRD';
    END IF;

END$$

DROP PROCEDURE IF EXISTS `MES_IF_SALODR`$$
CREATE PROCEDURE `MES_IF_SALODR`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $SO_NO_LIST MEDIUMTEXT,           -- 수주번호 (PK)
    IN $SO_DT_LIST MEDIUMTEXT,           -- 수주일자
    IN $SO_BS_LIST MEDIUMTEXT,           -- 수주사업장
    IN $SO_FAC_LIST MEDIUMTEXT,          -- 수주공장
    IN $SO_DEPT_LIST MEDIUMTEXT,         -- 수주부서
    IN $SO_RID_LIST MEDIUMTEXT,          -- 공급처담당자ID
    IN $DLV_DT_LIST MEDIUMTEXT,          -- 납기일자
    IN $SAL_BC_LIST MEDIUMTEXT,          -- 매출구분
    IN $DE_BC_LIST MEDIUMTEXT,           -- 지역구분
    IN $NAT_CD_LIST MEDIUMTEXT,          -- 국가코드
    IN $CUST_CD_LIST MEDIUMTEXT,         -- 거래처코드
    IN $CUST_CD2_LIST MEDIUMTEXT,        -- 매출거래처코드
    IN $CUST_CD3_LIST MEDIUMTEXT,        -- 거래처코드3
    IN $CUST_PO_LIST MEDIUMTEXT,         -- 거래처PO번호
    IN $DLV_YARD_LIST MEDIUMTEXT,        -- 납품장소
    IN $REQ_DOC_LIST MEDIUMTEXT,         -- 요청서류
    IN $CURY_BC_LIST MEDIUMTEXT,         -- 통화구분
    IN $EX_RT_LIST MEDIUMTEXT,           -- 환율
    IN $SETL_BC_LIST MEDIUMTEXT,         -- 결제조건
    IN $VAT_BC_LIST MEDIUMTEXT,          -- 부가세구분
    IN $VAT_RT_LIST MEDIUMTEXT,          -- 부가세율
    IN $SO_FAMT_LIST MEDIUMTEXT,         -- 수주금액_수주통화
    IN $SO_AMT_LIST MEDIUMTEXT,          -- 수주금액_기준통화
    IN $SO_VAT_LIST MEDIUMTEXT,          -- 부가세
    IN $EXPORT_CD_LIST MEDIUMTEXT,       -- 수출자코드
    IN $ITM_TY_LIST MEDIUMTEXT,          -- 품목유형
    IN $FREIGHT_BC_LIST MEDIUMTEXT,      -- 운임지불조건
    IN $AMT_BC_LIST MEDIUMTEXT,          -- 가격조건
    IN $PAY_BC_LIST MEDIUMTEXT,          -- 지급구분
    IN $DAY_BC_LIST MEDIUMTEXT,          -- 결제조건(일)
    IN $TRAN_BC_LIST MEDIUMTEXT,         -- 운송방법
    IN $PORT_LOAD_LIST MEDIUMTEXT,       -- 선적항
    IN $PORT_UNLOAD_LIST MEDIUMTEXT,     -- 하역항
    IN $PLAN_DT_LIST MEDIUMTEXT,         -- 계획일자
    IN $LIM_DT_LIST MEDIUMTEXT,          -- 발주예정마감일
    IN $ARR_DT_LIST MEDIUMTEXT,          -- 도착예정일
    IN $FILE_NO_LIST MEDIUMTEXT,         -- File번호
    IN $PRO_NO_LIST MEDIUMTEXT,          -- 견적번호
    IN $PRO_REV_LIST MEDIUMTEXT,         -- Rev
    IN $STAT_BC_LIST MEDIUMTEXT,         -- 진행상태
    IN $ENT_BC_LIST MEDIUMTEXT,          -- 입력경로
    IN $RMKS_LIST MEDIUMTEXT,            -- 비고

    IN $SO_BC_LIST MEDIUMTEXT,           -- 수주구분
    IN $ACC_DT_LIST MEDIUMTEXT,          -- 확정일
    IN $ACC_RID_LIST MEDIUMTEXT          -- 확정자
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$SO_NO VARCHAR(20);
  DECLARE _$SO_DT VARCHAR(50);
  DECLARE _$SO_BS VARCHAR(10);
  DECLARE _$SO_FAC VARCHAR(10);
  DECLARE _$SO_DEPT VARCHAR(10);
  DECLARE _$SO_RID VARCHAR(50);
  DECLARE _$DLV_DT VARCHAR(50);
  DECLARE _$SAL_BC VARCHAR(10);
  DECLARE _$DE_BC VARCHAR(10);
  DECLARE _$NAT_CD VARCHAR(10);
  DECLARE _$CUST_CD VARCHAR(20);
  DECLARE _$CUST_CD2 VARCHAR(20);
  DECLARE _$CUST_CD3 VARCHAR(20);
  DECLARE _$CUST_PO VARCHAR(50);
  DECLARE _$DLV_YARD VARCHAR(50);
  DECLARE _$REQ_DOC VARCHAR(50);
  DECLARE _$CURY_BC VARCHAR(10);
  DECLARE _$EX_RT VARCHAR(50);
  DECLARE _$SETL_BC VARCHAR(10);
  DECLARE _$VAT_BC VARCHAR(10);
  DECLARE _$VAT_RT VARCHAR(50);
  DECLARE _$SO_FAMT VARCHAR(50);
  DECLARE _$SO_AMT VARCHAR(50);
  DECLARE _$SO_VAT VARCHAR(50);
  DECLARE _$EXPORT_CD VARCHAR(20);
  DECLARE _$ITM_TY VARCHAR(10);
  DECLARE _$FREIGHT_BC VARCHAR(10);
  DECLARE _$AMT_BC VARCHAR(10);
  DECLARE _$PAY_BC VARCHAR(10);
  DECLARE _$DAY_BC VARCHAR(10);
  DECLARE _$TRAN_BC VARCHAR(10);
  DECLARE _$PORT_LOAD VARCHAR(10);
  DECLARE _$PORT_UNLOAD VARCHAR(10);
  DECLARE _$PLAN_DT VARCHAR(50);
  DECLARE _$LIM_DT VARCHAR(50);
  DECLARE _$ARR_DT VARCHAR(50);
  DECLARE _$FILE_NO VARCHAR(20);
  DECLARE _$PRO_NO VARCHAR(20);
  DECLARE _$PRO_REV VARCHAR(50);
  DECLARE _$STAT_BC VARCHAR(10);
  DECLARE _$ENT_BC VARCHAR(10);
  DECLARE _$RMKS VARCHAR(500);

  DECLARE _$SO_BC VARCHAR(10);
  DECLARE _$ACC_DT VARCHAR(50);
  DECLARE _$ACC_RID VARCHAR(50);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_SALODR',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($SO_NO_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($SO_NO_LIST, _$SO_NO);
      CALL COMSPLIT($SO_DT_LIST, _$SO_DT);
      CALL COMSPLIT($SO_BS_LIST, _$SO_BS);
      CALL COMSPLIT($SO_FAC_LIST, _$SO_FAC);
      CALL COMSPLIT($SO_DEPT_LIST, _$SO_DEPT);
      CALL COMSPLIT($SO_RID_LIST, _$SO_RID);
      CALL COMSPLIT($DLV_DT_LIST, _$DLV_DT);
      CALL COMSPLIT($SAL_BC_LIST, _$SAL_BC);
      CALL COMSPLIT($DE_BC_LIST, _$DE_BC);
      CALL COMSPLIT($NAT_CD_LIST, _$NAT_CD);
      CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
      CALL COMSPLIT($CUST_CD2_LIST, _$CUST_CD2);
      CALL COMSPLIT($CUST_CD3_LIST, _$CUST_CD3);
      CALL COMSPLIT($CUST_PO_LIST, _$CUST_PO);
      CALL COMSPLIT($DLV_YARD_LIST, _$DLV_YARD);
      CALL COMSPLIT($REQ_DOC_LIST, _$REQ_DOC);
      CALL COMSPLIT($CURY_BC_LIST, _$CURY_BC);
      CALL COMSPLIT($EX_RT_LIST, _$EX_RT);
      CALL COMSPLIT($SETL_BC_LIST, _$SETL_BC);
      CALL COMSPLIT($VAT_BC_LIST, _$VAT_BC);
      CALL COMSPLIT($VAT_RT_LIST, _$VAT_RT);
      CALL COMSPLIT($SO_FAMT_LIST, _$SO_FAMT);
      CALL COMSPLIT($SO_AMT_LIST, _$SO_AMT);
      CALL COMSPLIT($SO_VAT_LIST, _$SO_VAT);
      CALL COMSPLIT($EXPORT_CD_LIST, _$EXPORT_CD);
      CALL COMSPLIT($ITM_TY_LIST, _$ITM_TY);
      CALL COMSPLIT($FREIGHT_BC_LIST, _$FREIGHT_BC);
      CALL COMSPLIT($AMT_BC_LIST, _$AMT_BC);
      CALL COMSPLIT($PAY_BC_LIST, _$PAY_BC);
      CALL COMSPLIT($DAY_BC_LIST, _$DAY_BC);
      CALL COMSPLIT($TRAN_BC_LIST, _$TRAN_BC);
      CALL COMSPLIT($PORT_LOAD_LIST, _$PORT_LOAD);
      CALL COMSPLIT($PORT_UNLOAD_LIST, _$PORT_UNLOAD);
      CALL COMSPLIT($PLAN_DT_LIST, _$PLAN_DT);
      CALL COMSPLIT($LIM_DT_LIST, _$LIM_DT);
      CALL COMSPLIT($ARR_DT_LIST, _$ARR_DT);
      CALL COMSPLIT($FILE_NO_LIST, _$FILE_NO);
      CALL COMSPLIT($PRO_NO_LIST, _$PRO_NO);
      CALL COMSPLIT($PRO_REV_LIST, _$PRO_REV);
      CALL COMSPLIT($STAT_BC_LIST, _$STAT_BC);
      CALL COMSPLIT($ENT_BC_LIST, _$ENT_BC);
      CALL COMSPLIT($RMKS_LIST, _$RMKS);

      CALL COMSPLIT($SO_BC_LIST, _$SO_BC);
      CALL COMSPLIT($ACC_DT_LIST, _$ACC_DT);
      CALL COMSPLIT($ACC_RID_LIST, _$ACC_RID);

      -- *************************************************************
      -- 빈문자열('') → NULL (숫자/날짜)
      -- *************************************************************
      SET _$IFKEY   = NULLIF(TRIM(_$IFKEY), '');
      SET _$SO_RID  = NULLIF(TRIM(_$SO_RID), '');
      SET _$EX_RT   = NULLIF(TRIM(_$EX_RT), '');
      SET _$VAT_RT  = NULLIF(TRIM(_$VAT_RT), '');
      SET _$SO_FAMT = NULLIF(TRIM(_$SO_FAMT), '');
      SET _$SO_AMT  = NULLIF(TRIM(_$SO_AMT), '');
      SET _$SO_VAT  = NULLIF(TRIM(_$SO_VAT), '');
      SET _$PRO_REV = NULLIF(TRIM(_$PRO_REV), '');
      SET _$ACC_RID = NULLIF(TRIM(_$ACC_RID), '');
      SET _$SO_DT   = NULLIF(TRIM(_$SO_DT), '');
      SET _$DLV_DT  = NULLIF(TRIM(_$DLV_DT), '');
      SET _$PLAN_DT = NULLIF(TRIM(_$PLAN_DT), '');
      SET _$LIM_DT  = NULLIF(TRIM(_$LIM_DT), '');
      SET _$ARR_DT  = NULLIF(TRIM(_$ARR_DT), '');
      SET _$ACC_DT  = NULLIF(TRIM(_$ACC_DT), '');

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_SALODR → SALODR
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.SALODR
          WHERE SALODRKEY = _$SO_NO
      )
      THEN

          INSERT INTO MES_SNS2.SALODR
          (
              SALODRKEY,
              ODRDATE,
              BDVCD,
              FACTORYCD,
              DEPTP,
              EMPCD,
              DELIVERYDT,
              SALBC,
              DEBC,
              NATCD,
              CUSTCD,
              CUSTCD2,
              CUSTCD3,
              CUSTPO,
              DLVYARD,
              REQDOC,
              CURYBC,
              EXRT,
              SETBC,
              VATCD,
              VARRT,
              SOFMAMT,
              SOAMAT,
              SOVAVAT,
              EXCCD,
              ITTTY,
              FRBBC,
              AMBBC,
              PABBC,
              DABBC,
              TRBC,
              POLOAD,
              POUNLOAD,
              PLDT,
              LIDDT,
              ARDDT,
              FILENO,
              PRONO,
              PROREV,
              STATBC,
              ENTBC,
              SOBCBC,
              ACCDT,
              ACCRID,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$SO_NO,
              IF(_$SO_DT IS NULL, NULL, GETDATETIME(_$SO_DT)),
              _$SO_BS,
              _$SO_FAC,
              _$SO_DEPT,
              IFNULL(CONVERT(_$SO_RID, SIGNED), 0),
              IF(_$DLV_DT IS NULL, NULL, GETDATETIME(_$DLV_DT)),
              _$SAL_BC,
              _$DE_BC,
              _$NAT_CD,
              _$CUST_CD,
              _$CUST_CD2,
              _$CUST_CD3,
              _$CUST_PO,
              _$DLV_YARD,
              _$REQ_DOC,
              _$CURY_BC,
              IFNULL(CONVERT(_$EX_RT, DECIMAL(18,5)), 0),
              _$SETL_BC,
              _$VAT_BC,
              IFNULL(CONVERT(_$VAT_RT, DECIMAL(18,5)), 0),
              IFNULL(CONVERT(_$SO_FAMT, DECIMAL(18,5)), 0),
              IFNULL(CONVERT(_$SO_AMT, DECIMAL(18,5)), 0),
              IFNULL(CONVERT(_$SO_VAT, DECIMAL(18,5)), 0),
              _$EXPORT_CD,
              _$ITM_TY,
              _$FREIGHT_BC,
              _$AMT_BC,
              _$PAY_BC,
              _$DAY_BC,
              _$TRAN_BC,
              _$PORT_LOAD,
              _$PORT_UNLOAD,
              IF(_$PLAN_DT IS NULL, NULL, GETDATETIME(_$PLAN_DT)),
              IF(_$LIM_DT IS NULL, NULL, GETDATETIME(_$LIM_DT)),
              IF(_$ARR_DT IS NULL, NULL, GETDATETIME(_$ARR_DT)),
              _$FILE_NO,
              _$PRO_NO,
              IFNULL(CONVERT(_$PRO_REV, SIGNED), 0),
              _$STAT_BC,
              _$ENT_BC,
              _$SO_BC,
              IF(_$ACC_DT IS NULL, NULL, GETDATETIME(_$ACC_DT)),
              IFNULL(CONVERT(_$ACC_RID, SIGNED), 0),
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_SALODR → SALODR
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.SALODR
          WHERE SALODRKEY = _$SO_NO
      )
      THEN

          INSERT INTO MES_SNS2.SALODR
          (
              SALODRKEY,
              ODRDATE,
              BDVCD,
              FACTORYCD,
              DEPTP,
              EMPCD,
              DELIVERYDT,
              SALBC,
              DEBC,
              NATCD,
              CUSTCD,
              CUSTCD2,
              CUSTCD3,
              CUSTPO,
              DLVYARD,
              REQDOC,
              CURYBC,
              EXRT,
              SETBC,
              VATCD,
              VARRT,
              SOFMAMT,
              SOAMAT,
              SOVAVAT,
              EXCCD,
              ITTTY,
              FRBBC,
              AMBBC,
              PABBC,
              DABBC,
              TRBC,
              POLOAD,
              POUNLOAD,
              PLDT,
              LIDDT,
              ARDDT,
              FILENO,
              PRONO,
              PROREV,
              STATBC,
              ENTBC,
              SOBCBC,
              ACCDT,
              ACCRID,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$SO_NO,
              IF(_$SO_DT IS NULL, NULL, GETDATETIME(_$SO_DT)),
              _$SO_BS,
              _$SO_FAC,
              _$SO_DEPT,
              IFNULL(CONVERT(_$SO_RID, SIGNED), 0),
              IF(_$DLV_DT IS NULL, NULL, GETDATETIME(_$DLV_DT)),
              _$SAL_BC,
              _$DE_BC,
              _$NAT_CD,
              _$CUST_CD,
              _$CUST_CD2,
              _$CUST_CD3,
              _$CUST_PO,
              _$DLV_YARD,
              _$REQ_DOC,
              _$CURY_BC,
              IFNULL(CONVERT(_$EX_RT, DECIMAL(18,5)), 0),
              _$SETL_BC,
              _$VAT_BC,
              IFNULL(CONVERT(_$VAT_RT, DECIMAL(18,5)), 0),
              IFNULL(CONVERT(_$SO_FAMT, DECIMAL(18,5)), 0),
              IFNULL(CONVERT(_$SO_AMT, DECIMAL(18,5)), 0),
              IFNULL(CONVERT(_$SO_VAT, DECIMAL(18,5)), 0),
              _$EXPORT_CD,
              _$ITM_TY,
              _$FREIGHT_BC,
              _$AMT_BC,
              _$PAY_BC,
              _$DAY_BC,
              _$TRAN_BC,
              _$PORT_LOAD,
              _$PORT_UNLOAD,
              IF(_$PLAN_DT IS NULL, NULL, GETDATETIME(_$PLAN_DT)),
              IF(_$LIM_DT IS NULL, NULL, GETDATETIME(_$LIM_DT)),
              IF(_$ARR_DT IS NULL, NULL, GETDATETIME(_$ARR_DT)),
              _$FILE_NO,
              _$PRO_NO,
              IFNULL(CONVERT(_$PRO_REV, SIGNED), 0),
              _$STAT_BC,
              _$ENT_BC,
              _$SO_BC,
              IF(_$ACC_DT IS NULL, NULL, GETDATETIME(_$ACC_DT)),
              IFNULL(CONVERT(_$ACC_RID, SIGNED), 0),
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.SALODR
          SET
              ODRDATE    = IF(_$SO_DT IS NULL, NULL, GETDATETIME(_$SO_DT)),
              BDVCD      = IF(_$SO_BS <> '', _$SO_BS, BDVCD),
              FACTORYCD  = IF(_$SO_FAC <> '', _$SO_FAC, FACTORYCD),
              DEPTP      = IF(_$SO_DEPT <> '', _$SO_DEPT, DEPTP),
              EMPCD      = IFNULL(CONVERT(_$SO_RID, SIGNED), 0),
              DELIVERYDT = IF(_$DLV_DT IS NULL, NULL, GETDATETIME(_$DLV_DT)),
              SALBC      = IF(_$SAL_BC <> '', _$SAL_BC, SALBC),
              DEBC       = IF(_$DE_BC <> '', _$DE_BC, DEBC),
              NATCD      = IF(_$NAT_CD <> '', _$NAT_CD, NATCD),
              CUSTCD     = IF(_$CUST_CD <> '', _$CUST_CD, CUSTCD),
              CUSTCD2    = IF(_$CUST_CD2 <> '', _$CUST_CD2, CUSTCD2),
              CUSTCD3    = IF(_$CUST_CD3 <> '', _$CUST_CD3, CUSTCD3),
              CUSTPO     = IF(_$CUST_PO <> '', _$CUST_PO, CUSTPO),
              DLVYARD    = IF(_$DLV_YARD <> '', _$DLV_YARD, DLVYARD),
              REQDOC     = IF(_$REQ_DOC <> '', _$REQ_DOC, REQDOC),
              CURYBC     = IF(_$CURY_BC <> '', _$CURY_BC, CURYBC),
              EXRT       = IFNULL(CONVERT(_$EX_RT, DECIMAL(18,5)), 0),
              SETBC      = IF(_$SETL_BC <> '', _$SETL_BC, SETBC),
              VATCD      = IF(_$VAT_BC <> '', _$VAT_BC, VATCD),
              VARRT      = IFNULL(CONVERT(_$VAT_RT, DECIMAL(18,5)), 0),
              SOFMAMT    = IFNULL(CONVERT(_$SO_FAMT, DECIMAL(18,5)), 0),
              SOAMAT     = IFNULL(CONVERT(_$SO_AMT, DECIMAL(18,5)), 0),
              SOVAVAT    = IFNULL(CONVERT(_$SO_VAT, DECIMAL(18,5)), 0),
              EXCCD      = IF(_$EXPORT_CD <> '', _$EXPORT_CD, EXCCD),
              ITTTY       = IF(_$ITM_TY <> '', _$ITM_TY, ITTTY),
              FRBBC       = IF(_$FREIGHT_BC <> '', _$FREIGHT_BC, FRBBC),
              AMBBC      = IF(_$AMT_BC <> '', _$AMT_BC, AMBBC),
              PABBC      = IF(_$PAY_BC <> '', _$PAY_BC, PABBC),
              DABBC      = IF(_$DAY_BC <> '', _$DAY_BC, DABBC),
              TRBC       = IF(_$TRAN_BC <> '', _$TRAN_BC, TRBC),
              POLOAD     = IF(_$PORT_LOAD <> '', _$PORT_LOAD, POLOAD),
              POUNLOAD   = IF(_$PORT_UNLOAD <> '', _$PORT_UNLOAD, POUNLOAD),
              PLDT       = IF(_$PLAN_DT IS NULL, NULL, GETDATETIME(_$PLAN_DT)),
              LIDDT      = IF(_$LIM_DT IS NULL, NULL, GETDATETIME(_$LIM_DT)),
              ARDDT      = IF(_$ARR_DT IS NULL, NULL, GETDATETIME(_$ARR_DT)),
              FILENO     = IF(_$FILE_NO <> '', _$FILE_NO, FILENO),
              PRONO      = IF(_$PRO_NO <> '', _$PRO_NO, PRONO),
              PROREV     = IFNULL(CONVERT(_$PRO_REV, SIGNED), 0),
              STATBC     = IF(_$STAT_BC <> '', _$STAT_BC, STATBC),
              ENTBC      = IF(_$ENT_BC <> '', _$ENT_BC, ENTBC),
              SOBCBC     = IF(_$SO_BC <> '', _$SO_BC, SOBCBC),
              ACCDT      = IF(_$ACC_DT IS NULL, NULL, GETDATETIME(_$ACC_DT)),
              ACCRID     = IFNULL(CONVERT(_$ACC_RID, SIGNED), 0),
              REMARK     = IF(_$RMKS <> '', _$RMKS, REMARK),
              MTIME      = GETTIME(),
              MEMP       = 'ERP',
              MPRG       = 'IF'
          WHERE SALODRKEY = _$SO_NO;

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_SALODR → SALODR
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.SALODR
      WHERE SALODRKEY = _$SO_NO;

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_SALODR';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_SALODR';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_SALODRD`$$
CREATE PROCEDURE `MES_IF_SALODRD`(
    IN $IF_KEY_LIST MEDIUMTEXT,          -- 인터페이스 KEY
    IN $IF_TYPE_LIST MEDIUMTEXT,         -- 인터페이스 구분(I/U/D)

    IN $SO_NO_LIST MEDIUMTEXT,           -- 수주번호 (PK)
    IN $SO_SQ_LIST MEDIUMTEXT,           -- 수주순번 (PK)
    IN $ITM_ID_LIST MEDIUMTEXT,          -- 품목ID
    IN $UM_BC_LIST MEDIUMTEXT,           -- 단위
    IN $SO_QTY_LIST MEDIUMTEXT,          -- 수량
    IN $SO_FUP_LIST MEDIUMTEXT,          -- 수주단가_수주통화
    IN $SO_FAMT_LIST MEDIUMTEXT,         -- 수주금액_수주통화
    IN $SO_UP_LIST MEDIUMTEXT,           -- 수주단가_기준통화
    IN $SO_AMT_LIST MEDIUMTEXT,          -- 수주금액_기준통화
    IN $SO_VAT_LIST MEDIUMTEXT,          -- 부가세
    IN $DLV_DT_LIST MEDIUMTEXT,          -- 납기일자
    IN $REQ_TOT_LIST MEDIUMTEXT,         -- 요청수량
    IN $OUT_QTY_LIST MEDIUMTEXT,         -- 출고수량
    IN $DOC1_YN_LIST MEDIUMTEXT,         -- 문서1여부
    IN $DOC2_YN_LIST MEDIUMTEXT,         -- 문서2여부
    IN $DOC3_YN_LIST MEDIUMTEXT,         -- 문서3여부
    IN $PRO_NO_LIST MEDIUMTEXT,          -- 견적번호
    IN $PRO_REV_LIST MEDIUMTEXT,         -- Rev
    IN $PRO_SQ_LIST MEDIUMTEXT,          -- 등록순번
    IN $FILE_NO_LIST MEDIUMTEXT,         -- File번호
    IN $FILE_SQ_LIST MEDIUMTEXT,         -- File순번
    IN $RS_ID_LIST MEDIUMTEXT,           -- 주문ID
    IN $STAT_BC_LIST MEDIUMTEXT,         -- 진행상태
    IN $RMKS_LIST MEDIUMTEXT,            -- 비고

    IN $SM_CD_LIST MEDIUMTEXT,           -- 판매모델 코드
    IN $BAS_FUP_LIST MEDIUMTEXT,         -- 기본단가
    IN $OPT_FUP_LIST MEDIUMTEXT,         -- 옵션단가
    IN $BAS_FAMT_LIST MEDIUMTEXT,        -- 기본금액
    IN $OPT_FAMT_LIST MEDIUMTEXT,        -- 옵션금액
    IN $SERL_NO_LIST MEDIUMTEXT,         -- Serial No.
    IN $MC_CD_LIST MEDIUMTEXT,           -- 설비코드
    IN $REQST_BC_LIST MEDIUMTEXT,        -- 요청구분
    IN $SO_ADD_YN_LIST MEDIUMTEXT        -- 추가수주여부
)
PROC: BEGIN

  -- *************************************************************
  -- 변수 선언
  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지)
  -- 숫자형은 INSERT/UPDATE 시 CONVERT, 빈값이면 0
  -- *************************************************************
  DECLARE _$IFKEY VARCHAR(50);
  DECLARE _$FIRSTKEY INT DEFAULT 0;
  DECLARE _$IF_TYPE VARCHAR(1);

  DECLARE _$SO_NO VARCHAR(20);
  DECLARE _$SO_SQ VARCHAR(50);
  DECLARE _$ITM_ID VARCHAR(50);
  DECLARE _$UM_BC VARCHAR(10);
  DECLARE _$SO_QTY VARCHAR(50);
  DECLARE _$SO_FUP VARCHAR(50);
  DECLARE _$SO_FAMT VARCHAR(50);
  DECLARE _$SO_UP VARCHAR(50);
  DECLARE _$SO_AMT VARCHAR(50);
  DECLARE _$SO_VAT VARCHAR(50);
  DECLARE _$DLV_DT VARCHAR(50);
  DECLARE _$REQ_TOT VARCHAR(50);
  DECLARE _$OUT_QTY VARCHAR(50);
  DECLARE _$DOC1_YN VARCHAR(1);
  DECLARE _$DOC2_YN VARCHAR(1);
  DECLARE _$DOC3_YN VARCHAR(1);
  DECLARE _$PRO_NO VARCHAR(20);
  DECLARE _$PRO_REV VARCHAR(50);
  DECLARE _$PRO_SQ VARCHAR(50);
  DECLARE _$FILE_NO VARCHAR(20);
  DECLARE _$FILE_SQ VARCHAR(50);
  DECLARE _$RS_ID VARCHAR(50);
  DECLARE _$STAT_BC VARCHAR(10);
  DECLARE _$RMKS VARCHAR(200);

  DECLARE _$SM_CD VARCHAR(50);
  DECLARE _$BAS_FUP VARCHAR(50);
  DECLARE _$OPT_FUP VARCHAR(50);
  DECLARE _$BAS_FAMT VARCHAR(50);
  DECLARE _$OPT_FAMT VARCHAR(50);
  DECLARE _$SERL_NO VARCHAR(50);
  DECLARE _$MC_CD VARCHAR(100);
  DECLARE _$REQST_BC VARCHAR(10);
  DECLARE _$SO_ADD_YN VARCHAR(1);

  -- *************************************************************
  -- 오류 처리
  -- *************************************************************
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN

      GET DIAGNOSTICS CONDITION 1
          @sqlstate = RETURNED_SQLSTATE,
          @errno = MYSQL_ERRNO,
          @text = MESSAGE_TEXT;

      SET @full_error =
          CONCAT(
              'ERROR ',
              @errno,
              ' (',
              @sqlstate,
              '): ',
              @text
          );

      INSERT INTO IF_ERR_LOG
      (
          IFKEY,
          IFGB,
          IFNAME,
          IF_TYPE,
          READTIME,
          ERRMSG
      )
      VALUES
      (
          CONVERT(_$IFKEY, SIGNED),
          'ERP',
          'MES_IF_SALODRD',
          _$IF_TYPE,
          GETTIME(),
          @full_error
      );

      COMMIT;

  END;

  SET _$FIRSTKEY = 0;

  -- *************************************************************
  -- 인터페이스 LOOP
  -- *************************************************************
  WHILE LENGTH($SO_NO_LIST) > 0 DO

      CALL COMSPLIT($IF_KEY_LIST, _$IFKEY);
      CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

      CALL COMSPLIT($SO_NO_LIST, _$SO_NO);
      CALL COMSPLIT($SO_SQ_LIST, _$SO_SQ);
      CALL COMSPLIT($ITM_ID_LIST, _$ITM_ID);
      CALL COMSPLIT($UM_BC_LIST, _$UM_BC);
      CALL COMSPLIT($SO_QTY_LIST, _$SO_QTY);
      CALL COMSPLIT($SO_FUP_LIST, _$SO_FUP);
      CALL COMSPLIT($SO_FAMT_LIST, _$SO_FAMT);
      CALL COMSPLIT($SO_UP_LIST, _$SO_UP);
      CALL COMSPLIT($SO_AMT_LIST, _$SO_AMT);
      CALL COMSPLIT($SO_VAT_LIST, _$SO_VAT);
      CALL COMSPLIT($DLV_DT_LIST, _$DLV_DT);
      CALL COMSPLIT($REQ_TOT_LIST, _$REQ_TOT);
      CALL COMSPLIT($OUT_QTY_LIST, _$OUT_QTY);
      CALL COMSPLIT($DOC1_YN_LIST, _$DOC1_YN);
      CALL COMSPLIT($DOC2_YN_LIST, _$DOC2_YN);
      CALL COMSPLIT($DOC3_YN_LIST, _$DOC3_YN);
      CALL COMSPLIT($PRO_NO_LIST, _$PRO_NO);
      CALL COMSPLIT($PRO_REV_LIST, _$PRO_REV);
      CALL COMSPLIT($PRO_SQ_LIST, _$PRO_SQ);
      CALL COMSPLIT($FILE_NO_LIST, _$FILE_NO);
      CALL COMSPLIT($FILE_SQ_LIST, _$FILE_SQ);
      CALL COMSPLIT($RS_ID_LIST, _$RS_ID);
      CALL COMSPLIT($STAT_BC_LIST, _$STAT_BC);
      CALL COMSPLIT($RMKS_LIST, _$RMKS);

      CALL COMSPLIT($SM_CD_LIST, _$SM_CD);
      CALL COMSPLIT($BAS_FUP_LIST, _$BAS_FUP);
      CALL COMSPLIT($OPT_FUP_LIST, _$OPT_FUP);
      CALL COMSPLIT($BAS_FAMT_LIST, _$BAS_FAMT);
      CALL COMSPLIT($OPT_FAMT_LIST, _$OPT_FAMT);
      CALL COMSPLIT($SERL_NO_LIST, _$SERL_NO);
      CALL COMSPLIT($MC_CD_LIST, _$MC_CD);
      CALL COMSPLIT($REQST_BC_LIST, _$REQST_BC);
      CALL COMSPLIT($SO_ADD_YN_LIST, _$SO_ADD_YN);

      -- *************************************************************
      -- 빈문자열('') → NULL (숫자/날짜)
      -- *************************************************************
      SET _$IFKEY    = NULLIF(TRIM(_$IFKEY), '');
      SET _$SO_SQ    = NULLIF(TRIM(_$SO_SQ), '');
      SET _$ITM_ID   = NULLIF(TRIM(_$ITM_ID), '');
      SET _$SO_QTY   = NULLIF(TRIM(_$SO_QTY), '');
      SET _$SO_FUP   = NULLIF(TRIM(_$SO_FUP), '');
      SET _$SO_FAMT  = NULLIF(TRIM(_$SO_FAMT), '');
      SET _$SO_UP    = NULLIF(TRIM(_$SO_UP), '');
      SET _$SO_AMT   = NULLIF(TRIM(_$SO_AMT), '');
      SET _$SO_VAT   = NULLIF(TRIM(_$SO_VAT), '');
      SET _$REQ_TOT  = NULLIF(TRIM(_$REQ_TOT), '');
      SET _$OUT_QTY  = NULLIF(TRIM(_$OUT_QTY), '');
      SET _$PRO_REV  = NULLIF(TRIM(_$PRO_REV), '');
      SET _$PRO_SQ   = NULLIF(TRIM(_$PRO_SQ), '');
      SET _$FILE_SQ  = NULLIF(TRIM(_$FILE_SQ), '');
      SET _$RS_ID    = NULLIF(TRIM(_$RS_ID), '');
      SET _$BAS_FUP  = NULLIF(TRIM(_$BAS_FUP), '');
      SET _$OPT_FUP  = NULLIF(TRIM(_$OPT_FUP), '');
      SET _$BAS_FAMT = NULLIF(TRIM(_$BAS_FAMT), '');
      SET _$OPT_FAMT = NULLIF(TRIM(_$OPT_FAMT), '');
      SET _$DLV_DT   = NULLIF(TRIM(_$DLV_DT), '');

      IF _$FIRSTKEY = 0 THEN
          SET _$FIRSTKEY = CONVERT(_$IFKEY, SIGNED);
      END IF;

  -- *************************************************************
  -- I : 신규등록
  -- FAC2_MES_SALODR_SUB → SALODRD
  -- *************************************************************
  IF _$IF_TYPE = 'I' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.SALODRD
          WHERE SALODRKEY = _$SO_NO
            AND ODRSEQ    = CONVERT(_$SO_SQ, SIGNED)
      )
      THEN

          INSERT INTO MES_SNS2.SALODRD
          (
              SALODRKEY,
              ODRSEQ,
              ITEMID,
              ITEMUNIT,
              SALQTY,
              SALFUP,
              SALFAMT,
              SALUP,
              SALAMT,
              SALVAT,
              DLVDT,
              REQTOT,
              RELEASEQTY,
              DOC1YN,
              DOC2YN,
              DOC3YN,
              PRONO,
              PROREV,
              PROSQ,
              FILENO,
              FILESQ,
              RSID,
              SALODRSTT,
              SMCD,
              BASFUP,
              OPTFUP,
              BASFAMT,
              OPTFAMT,
              SERLNO,
              EQMCD,
              REQSTBC,
              SOADDYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$SO_NO,
              CONVERT(_$SO_SQ, SIGNED),
              IFNULL(CONVERT(_$ITM_ID, SIGNED), 0),
              _$UM_BC,
              IFNULL(CONVERT(_$SO_QTY, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_FUP, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_FAMT, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_UP, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_AMT, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_VAT, DECIMAL(20,0)), 0),
              IF(_$DLV_DT IS NULL, NULL, LEFT(GETDATETIME(_$DLV_DT), 10)),
              IFNULL(CONVERT(_$REQ_TOT, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$OUT_QTY, DECIMAL(20,0)), 0),
              _$DOC1_YN,
              _$DOC2_YN,
              _$DOC3_YN,
              _$PRO_NO,
              IFNULL(CONVERT(_$PRO_REV, SIGNED), 0),
              IFNULL(CONVERT(_$PRO_SQ, SIGNED), 0),
              _$FILE_NO,
              IFNULL(CONVERT(_$FILE_SQ, SIGNED), 0),
              IFNULL(CONVERT(_$RS_ID, SIGNED), 0),
              _$STAT_BC,
              _$SM_CD,
              IFNULL(CONVERT(_$BAS_FUP, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$OPT_FUP, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$BAS_FAMT, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$OPT_FAMT, DECIMAL(20,0)), 0),
              _$SERL_NO,
              _$MC_CD,
              _$REQST_BC,
              _$SO_ADD_YN,
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      END IF;

  -- *************************************************************
  -- U : 수정
  -- FAC2_MES_SALODR_SUB → SALODRD
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'U' THEN

      IF NOT EXISTS
      (
          SELECT 1
          FROM MES_SNS2.SALODRD
          WHERE SALODRKEY = _$SO_NO
            AND ODRSEQ    = CONVERT(_$SO_SQ, SIGNED)
      )
      THEN

          INSERT INTO MES_SNS2.SALODRD
          (
              SALODRKEY,
              ODRSEQ,
              ITEMID,
              ITEMUNIT,
              SALQTY,
              SALFUP,
              SALFAMT,
              SALUP,
              SALAMT,
              SALVAT,
              DLVDT,
              REQTOT,
              RELEASEQTY,
              DOC1YN,
              DOC2YN,
              DOC3YN,
              PRONO,
              PROREV,
              PROSQ,
              FILENO,
              FILESQ,
              RSID,
              SALODRSTT,
              SMCD,
              BASFUP,
              OPTFUP,
              BASFAMT,
              OPTFAMT,
              SERLNO,
              EQMCD,
              REQSTBC,
              SOADDYN,
              REMARK,
              RTIME,
              REMP,
              RPRG
          )
          VALUES
          (
              _$SO_NO,
              CONVERT(_$SO_SQ, SIGNED),
              IFNULL(CONVERT(_$ITM_ID, SIGNED), 0),
              _$UM_BC,
              IFNULL(CONVERT(_$SO_QTY, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_FUP, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_FAMT, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_UP, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_AMT, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$SO_VAT, DECIMAL(20,0)), 0),
              IF(_$DLV_DT IS NULL, NULL, LEFT(GETDATETIME(_$DLV_DT), 10)),
              IFNULL(CONVERT(_$REQ_TOT, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$OUT_QTY, DECIMAL(20,0)), 0),
              _$DOC1_YN,
              _$DOC2_YN,
              _$DOC3_YN,
              _$PRO_NO,
              IFNULL(CONVERT(_$PRO_REV, SIGNED), 0),
              IFNULL(CONVERT(_$PRO_SQ, SIGNED), 0),
              _$FILE_NO,
              IFNULL(CONVERT(_$FILE_SQ, SIGNED), 0),
              IFNULL(CONVERT(_$RS_ID, SIGNED), 0),
              _$STAT_BC,
              _$SM_CD,
              IFNULL(CONVERT(_$BAS_FUP, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$OPT_FUP, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$BAS_FAMT, DECIMAL(20,0)), 0),
              IFNULL(CONVERT(_$OPT_FAMT, DECIMAL(20,0)), 0),
              _$SERL_NO,
              _$MC_CD,
              _$REQST_BC,
              _$SO_ADD_YN,
              _$RMKS,
              GETTIME(),
              'ERP',
              'IF'
          );

      ELSE

          UPDATE MES_SNS2.SALODRD
          SET
              ITEMID     = IFNULL(CONVERT(_$ITM_ID, SIGNED), 0),
              ITEMUNIT   = IF(_$UM_BC <> '', _$UM_BC, ITEMUNIT),
              SALQTY     = IFNULL(CONVERT(_$SO_QTY, DECIMAL(20,0)), 0),
              SALFUP     = IFNULL(CONVERT(_$SO_FUP, DECIMAL(20,0)), 0),
              SALFAMT    = IFNULL(CONVERT(_$SO_FAMT, DECIMAL(20,0)), 0),
              SALUP      = IFNULL(CONVERT(_$SO_UP, DECIMAL(20,0)), 0),
              SALAMT     = IFNULL(CONVERT(_$SO_AMT, DECIMAL(20,0)), 0),
              SALVAT     = IFNULL(CONVERT(_$SO_VAT, DECIMAL(20,0)), 0),
              DLVDT      = IF(_$DLV_DT IS NULL, NULL, LEFT(GETDATETIME(_$DLV_DT), 10)),
              REQTOT     = IFNULL(CONVERT(_$REQ_TOT, DECIMAL(20,0)), 0),
              RELEASEQTY = IFNULL(CONVERT(_$OUT_QTY, DECIMAL(20,0)), 0),
              DOC1YN     = IF(_$DOC1_YN <> '', _$DOC1_YN, DOC1YN),
              DOC2YN     = IF(_$DOC2_YN <> '', _$DOC2_YN, DOC2YN),
              DOC3YN     = IF(_$DOC3_YN <> '', _$DOC3_YN, DOC3YN),
              PRONO      = IF(_$PRO_NO <> '', _$PRO_NO, PRONO),
              PROREV     = IFNULL(CONVERT(_$PRO_REV, SIGNED), 0),
              PROSQ      = IFNULL(CONVERT(_$PRO_SQ, SIGNED), 0),
              FILENO     = IF(_$FILE_NO <> '', _$FILE_NO, FILENO),
              FILESQ     = IFNULL(CONVERT(_$FILE_SQ, SIGNED), 0),
              RSID       = IFNULL(CONVERT(_$RS_ID, SIGNED), 0),
              SALODRSTT  = IF(_$STAT_BC <> '', _$STAT_BC, SALODRSTT),
              SMCD       = IF(_$SM_CD <> '', _$SM_CD, SMCD),
              BASFUP     = IFNULL(CONVERT(_$BAS_FUP, DECIMAL(20,0)), 0),
              OPTFUP     = IFNULL(CONVERT(_$OPT_FUP, DECIMAL(20,0)), 0),
              BASFAMT    = IFNULL(CONVERT(_$BAS_FAMT, DECIMAL(20,0)), 0),
              OPTFAMT    = IFNULL(CONVERT(_$OPT_FAMT, DECIMAL(20,0)), 0),
              SERLNO     = IF(_$SERL_NO <> '', _$SERL_NO, SERLNO),
              EQMCD      = IF(_$MC_CD <> '', _$MC_CD, EQMCD),
              REQSTBC    = IF(_$REQST_BC <> '', _$REQST_BC, REQSTBC),
              SOADDYN    = IF(_$SO_ADD_YN <> '', _$SO_ADD_YN, SOADDYN),
              REMARK     = IF(_$RMKS <> '', _$RMKS, REMARK),
              MTIME      = GETTIME(),
              MEMP       = 'ERP',
              MPRG       = 'IF'
          WHERE SALODRKEY = _$SO_NO
            AND ODRSEQ    = CONVERT(_$SO_SQ, SIGNED);

      END IF;

  -- *************************************************************
  -- D : 삭제
  -- FAC2_MES_SALODR_SUB → SALODRD
  -- *************************************************************
  ELSEIF _$IF_TYPE = 'D' THEN

      DELETE
      FROM MES_SNS2.SALODRD
      WHERE SALODRKEY = _$SO_NO
        AND ODRSEQ    = CONVERT(_$SO_SQ, SIGNED);

  END IF;

  END WHILE;

  -- *************************************************************
  -- 인터페이스 최종 처리
  -- *************************************************************
  UPDATE IFSTD
  SET LASTTIME = GETTIME()
  WHERE PROCNAME = 'MES_IF_SALODRD';

  SELECT IFKEY
  FROM IF_ERR_LOG
  WHERE IFKEY >= _$FIRSTKEY
  AND IFNAME = 'MES_IF_SALODRD';

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MTRREQ`$$
CREATE PROCEDURE `MES_IF_MTRREQ`(
  IN $IF_KEY_LIST   MEDIUMTEXT,   -- 인터페이스 KEY
  IN $IF_TYPE_LIST  MEDIUMTEXT,   -- 인터페이스 구분(I/U/D)

  IN $REQ_NO_LIST   MEDIUMTEXT,   -- 구매의뢰 번호 (PK)
  IN $REQ_DT_LIST   MEDIUMTEXT,   -- 구매의뢰 일자
  IN $REQ_BC_LIST   MEDIUMTEXT,   -- 구매의뢰구분 BC:MM030
  IN $DEPT_CD_LIST  MEDIUMTEXT,   -- 구매의뢰부서
  IN $REG_ID_LIST   MEDIUMTEXT,   -- 구매의뢰자 사번
  IN $FAC_CD_LIST   MEDIUMTEXT,   -- 구매의뢰 공장
  IN $IN_WH_LIST    MEDIUMTEXT,   -- 입고창고
  IN $CID_LIST      MEDIUMTEXT,   -- 생성자
  IN $CDT_LIST      MEDIUMTEXT,   -- 생성일
  IN $MID_LIST      MEDIUMTEXT,   -- 수정자
  IN $MDT_LIST      MEDIUMTEXT    -- 수정일
)
PROC: BEGIN
-- *****************************************************************************
-- Comment: 구매의뢰 수신 (ERP FAC2_MES_SOMO → MES_SNS2.MTRREQ)
-- Create: 2026-11-11
-- *****************************************************************************

  -- COMSPLIT 수신은 전부 VARCHAR (빈값 '' 대입 오류 방지), 숫자형은 저장할 때 변환
  DECLARE _$IFKEY     VARCHAR(50);
  DECLARE _$FIRSTKEY  INT DEFAULT 0;
  DECLARE _$IF_TYPE   VARCHAR(1);

  DECLARE _$REQ_NO    VARCHAR(50);
  DECLARE _$REQ_DT    VARCHAR(30);
  DECLARE _$REQ_BC    VARCHAR(20);
  DECLARE _$DEPT_CD   VARCHAR(20);
  DECLARE _$REG_ID    VARCHAR(20);
  DECLARE _$FAC_CD    VARCHAR(20);
  DECLARE _$IN_WH     VARCHAR(20);
  DECLARE _$CID       VARCHAR(20);
  DECLARE _$CDT       VARCHAR(30);
  DECLARE _$MID       VARCHAR(20);
  DECLARE _$MDT       VARCHAR(30);

  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1
      @sqlstate = RETURNED_SQLSTATE,
      @errno    = MYSQL_ERRNO,
      @text     = MESSAGE_TEXT;

    INSERT INTO IF_ERR_LOG (IFKEY, IFGB, IFNAME, IF_TYPE, READTIME, ERRMSG)
    VALUES (
      CONVERT(_$IFKEY, SIGNED),
      'ERP',
      'MES_IF_MTRREQ',
      _$IF_TYPE,
      GETTIME(),
      CONCAT('ERROR ', @errno, ' (', @sqlstate, '): ', @text)
    );

    COMMIT;
  END;

  WHILE LENGTH($REQ_NO_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST,  _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($REQ_NO_LIST,  _$REQ_NO);
    CALL COMSPLIT($REQ_DT_LIST,  _$REQ_DT);
    CALL COMSPLIT($REQ_BC_LIST,  _$REQ_BC);
    CALL COMSPLIT($DEPT_CD_LIST, _$DEPT_CD);
    CALL COMSPLIT($REG_ID_LIST,  _$REG_ID);
    CALL COMSPLIT($FAC_CD_LIST,  _$FAC_CD);
    CALL COMSPLIT($IN_WH_LIST,   _$IN_WH);
    CALL COMSPLIT($CID_LIST,     _$CID);
    CALL COMSPLIT($CDT_LIST,     _$CDT);
    CALL COMSPLIT($MID_LIST,     _$MID);
    CALL COMSPLIT($MDT_LIST,     _$MDT);

    IF _$FIRSTKEY = 0 THEN
      SET _$FIRSTKEY = CONVERT(IFNULL(NULLIF(TRIM(_$IFKEY), ''), '0'), SIGNED);
    END IF;

    -- I : 신규등록 (이미 있으면 무시)
    IF _$IF_TYPE = 'I' THEN

      INSERT IGNORE INTO MES_SNS2.MTRREQ (
        REQNO, REQDATE, REQBC, REQDEPT, REQEMPID, FACTORYCD, INWARECD,
        CID, CDT, MID, MDT,
        RTIME, REMP, RPRG
      ) VALUES (
        _$REQ_NO, LEFT(_$REQ_DT, 10), _$REQ_BC, _$DEPT_CD,
        CONVERT(IFNULL(NULLIF(TRIM(_$REG_ID), ''), '0'), SIGNED), _$FAC_CD, _$IN_WH,
        CONVERT(IFNULL(NULLIF(TRIM(_$CID), ''), '0'), SIGNED), LEFT(_$CDT, 19),
        CONVERT(IFNULL(NULLIF(TRIM(_$MID), ''), '0'), SIGNED), LEFT(_$MDT, 19),
        GETTIME(), 'ERP', 'IF'
      );

    -- U : 수정 (없으면 등록, 빈 값은 기존 값 유지)
    ELSEIF _$IF_TYPE = 'U' THEN

      INSERT INTO MES_SNS2.MTRREQ (
        REQNO, REQDATE, REQBC, REQDEPT, REQEMPID, FACTORYCD, INWARECD,
        CID, CDT, MID, MDT,
        RTIME, REMP, RPRG
      ) VALUES (
        _$REQ_NO, LEFT(_$REQ_DT, 10), _$REQ_BC, _$DEPT_CD,
        CONVERT(IFNULL(NULLIF(TRIM(_$REG_ID), ''), '0'), SIGNED), _$FAC_CD, _$IN_WH,
        CONVERT(IFNULL(NULLIF(TRIM(_$CID), ''), '0'), SIGNED), LEFT(_$CDT, 19),
        CONVERT(IFNULL(NULLIF(TRIM(_$MID), ''), '0'), SIGNED), LEFT(_$MDT, 19),
        GETTIME(), 'ERP', 'IF'
      )
      ON DUPLICATE KEY UPDATE
        REQDATE   = IF(_$REQ_DT   <> '', LEFT(_$REQ_DT, 10), REQDATE),
        REQBC     = IF(_$REQ_BC   <> '', _$REQ_BC, REQBC),
        REQDEPT   = IF(_$DEPT_CD  <> '', _$DEPT_CD, REQDEPT),
        REQEMPID  = IF(_$REG_ID   <> '', CONVERT(_$REG_ID, SIGNED), REQEMPID),
        FACTORYCD = IF(_$FAC_CD   <> '', _$FAC_CD, FACTORYCD),
        INWARECD  = IF(_$IN_WH    <> '', _$IN_WH, INWARECD),
        CID       = IF(_$CID      <> '', CONVERT(_$CID, SIGNED), CID),
        CDT       = IF(_$CDT      <> '', LEFT(_$CDT, 19), CDT),
        MID       = IF(_$MID      <> '', CONVERT(_$MID, SIGNED), MID),
        MDT       = IF(_$MDT      <> '', LEFT(_$MDT, 19), MDT),
        MTIME     = GETTIME(),
        MEMP      = 'ERP',
        MPRG      = 'IF';

    -- D : 삭제 (상세 먼저)
    ELSEIF _$IF_TYPE = 'D' THEN

      DELETE FROM MES_SNS2.MTRREQD WHERE REQNO = _$REQ_NO;
      DELETE FROM MES_SNS2.MTRREQ  WHERE REQNO = _$REQ_NO;

    END IF;

  END WHILE;

  UPDATE IFSTD
     SET LASTTIME = GETTIME()
   WHERE PROCNAME = 'MES_IF_MTRREQ';

  IF _$FIRSTKEY > 0 THEN
    SELECT IFKEY
      FROM IF_ERR_LOG
     WHERE IFKEY >= _$FIRSTKEY
       AND IFNAME = 'MES_IF_MTRREQ';
  END IF;

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MTRREQD`$$
CREATE PROCEDURE `MES_IF_MTRREQD`(
  IN $IF_KEY_LIST   MEDIUMTEXT,   -- 인터페이스 KEY
  IN $IF_TYPE_LIST  MEDIUMTEXT,   -- 인터페이스 구분(I/U/D)

  IN $REQ_NO_LIST   MEDIUMTEXT,   -- 구매의뢰 번호 (PK)
  IN $REQ_SQ_LIST   MEDIUMTEXT,   -- 구매의뢰 순번 (PK)
  IN $ITM_ID_LIST   MEDIUMTEXT,   -- 품목ID
  IN $CUST_CD_LIST  MEDIUMTEXT,   -- 구매 거래처
  IN $UM_BC_LIST    MEDIUMTEXT,   -- 품목단위 (KG DM150150 / EA DM150100)
  IN $REQ_QTY_LIST  MEDIUMTEXT,   -- 구매의뢰 수량
  IN $REQ_UP_LIST   MEDIUMTEXT,   -- 구매 개당 단가
  IN $REQ_AMT_LIST  MEDIUMTEXT,   -- 구매 총 액
  IN $CID_LIST      MEDIUMTEXT,   -- 생성자
  IN $CDT_LIST      MEDIUMTEXT,   -- 생성일
  IN $MID_LIST      MEDIUMTEXT,   -- 수정자
  IN $MDT_LIST      MEDIUMTEXT    -- 수정일
)
PROC: BEGIN
-- *****************************************************************************
-- Comment: 구매의뢰 상세 수신 (ERP FAC2_MES_SOMO_DTL → MES_SNS2.MTRREQD)
-- Create: 2026-11-11
-- *****************************************************************************

  DECLARE _$IFKEY     VARCHAR(50);
  DECLARE _$FIRSTKEY  INT DEFAULT 0;
  DECLARE _$IF_TYPE   VARCHAR(1);

  DECLARE _$REQ_NO    VARCHAR(50);
  DECLARE _$REQ_SQ    VARCHAR(20);
  DECLARE _$ITM_ID    VARCHAR(20);
  DECLARE _$CUST_CD   VARCHAR(20);
  DECLARE _$UM_BC     VARCHAR(20);
  DECLARE _$REQ_QTY   VARCHAR(50);
  DECLARE _$REQ_UP    VARCHAR(50);
  DECLARE _$REQ_AMT   VARCHAR(50);
  DECLARE _$CID       VARCHAR(20);
  DECLARE _$CDT       VARCHAR(30);
  DECLARE _$MID       VARCHAR(20);
  DECLARE _$MDT       VARCHAR(30);

  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1
      @sqlstate = RETURNED_SQLSTATE,
      @errno    = MYSQL_ERRNO,
      @text     = MESSAGE_TEXT;

    INSERT INTO IF_ERR_LOG (IFKEY, IFGB, IFNAME, IF_TYPE, READTIME, ERRMSG)
    VALUES (
      CONVERT(_$IFKEY, SIGNED),
      'ERP',
      'MES_IF_MTRREQD',
      _$IF_TYPE,
      GETTIME(),
      CONCAT('ERROR ', @errno, ' (', @sqlstate, '): ', @text)
    );

    COMMIT;
  END;

  WHILE LENGTH($REQ_NO_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST,  _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($REQ_NO_LIST,  _$REQ_NO);
    CALL COMSPLIT($REQ_SQ_LIST,  _$REQ_SQ);
    CALL COMSPLIT($ITM_ID_LIST,  _$ITM_ID);
    CALL COMSPLIT($CUST_CD_LIST, _$CUST_CD);
    CALL COMSPLIT($UM_BC_LIST,   _$UM_BC);
    CALL COMSPLIT($REQ_QTY_LIST, _$REQ_QTY);
    CALL COMSPLIT($REQ_UP_LIST,  _$REQ_UP);
    CALL COMSPLIT($REQ_AMT_LIST, _$REQ_AMT);
    CALL COMSPLIT($CID_LIST,     _$CID);
    CALL COMSPLIT($CDT_LIST,     _$CDT);
    CALL COMSPLIT($MID_LIST,     _$MID);
    CALL COMSPLIT($MDT_LIST,     _$MDT);

    IF _$FIRSTKEY = 0 THEN
      SET _$FIRSTKEY = CONVERT(IFNULL(NULLIF(TRIM(_$IFKEY), ''), '0'), SIGNED);
    END IF;

    -- I : 신규등록 (이미 있으면 무시)
    IF _$IF_TYPE = 'I' THEN

      INSERT IGNORE INTO MES_SNS2.MTRREQD (
        REQNO, REQSEQ, ITEMID, CUSTCD, UMCD,
        REQQTY, REQUP, REQAMT,
        CID, CDT, MID, MDT,
        RTIME, REMP, RPRG
      ) VALUES (
        _$REQ_NO, CONVERT(IFNULL(NULLIF(TRIM(_$REQ_SQ), ''), '0'), SIGNED),
        CONVERT(IFNULL(NULLIF(TRIM(_$ITM_ID), ''), '0'), SIGNED), _$CUST_CD, _$UM_BC,
        CONVERT(IFNULL(NULLIF(TRIM(_$REQ_QTY), ''), '0'), DECIMAL(18,5)),
        CONVERT(IFNULL(NULLIF(TRIM(_$REQ_UP), ''), '0'), DECIMAL(18,5)),
        CONVERT(IFNULL(NULLIF(TRIM(_$REQ_AMT), ''), '0'), DECIMAL(18,5)),
        CONVERT(IFNULL(NULLIF(TRIM(_$CID), ''), '0'), SIGNED), LEFT(_$CDT, 19),
        CONVERT(IFNULL(NULLIF(TRIM(_$MID), ''), '0'), SIGNED), LEFT(_$MDT, 19),
        GETTIME(), 'ERP', 'IF'
      );

    -- U : 수정 (없으면 등록, 빈 값은 기존 값 유지)
    ELSEIF _$IF_TYPE = 'U' THEN

      INSERT INTO MES_SNS2.MTRREQD (
        REQNO, REQSEQ, ITEMID, CUSTCD, UMCD,
        REQQTY, REQUP, REQAMT,
        CID, CDT, MID, MDT,
        RTIME, REMP, RPRG
      ) VALUES (
        _$REQ_NO, CONVERT(IFNULL(NULLIF(TRIM(_$REQ_SQ), ''), '0'), SIGNED),
        CONVERT(IFNULL(NULLIF(TRIM(_$ITM_ID), ''), '0'), SIGNED), _$CUST_CD, _$UM_BC,
        CONVERT(IFNULL(NULLIF(TRIM(_$REQ_QTY), ''), '0'), DECIMAL(18,5)),
        CONVERT(IFNULL(NULLIF(TRIM(_$REQ_UP), ''), '0'), DECIMAL(18,5)),
        CONVERT(IFNULL(NULLIF(TRIM(_$REQ_AMT), ''), '0'), DECIMAL(18,5)),
        CONVERT(IFNULL(NULLIF(TRIM(_$CID), ''), '0'), SIGNED), LEFT(_$CDT, 19),
        CONVERT(IFNULL(NULLIF(TRIM(_$MID), ''), '0'), SIGNED), LEFT(_$MDT, 19),
        GETTIME(), 'ERP', 'IF'
      )
      ON DUPLICATE KEY UPDATE
        ITEMID = IF(_$ITM_ID  <> '', CONVERT(_$ITM_ID, SIGNED), ITEMID),
        CUSTCD = IF(_$CUST_CD <> '', _$CUST_CD, CUSTCD),
        UMCD   = IF(_$UM_BC   <> '', _$UM_BC, UMCD),
        REQQTY = IF(_$REQ_QTY <> '', CONVERT(_$REQ_QTY, DECIMAL(18,5)), REQQTY),
        REQUP  = IF(_$REQ_UP  <> '', CONVERT(_$REQ_UP, DECIMAL(18,5)), REQUP),
        REQAMT = IF(_$REQ_AMT <> '', CONVERT(_$REQ_AMT, DECIMAL(18,5)), REQAMT),
        CID    = IF(_$CID     <> '', CONVERT(_$CID, SIGNED), CID),
        CDT    = IF(_$CDT     <> '', LEFT(_$CDT, 19), CDT),
        MID    = IF(_$MID     <> '', CONVERT(_$MID, SIGNED), MID),
        MDT    = IF(_$MDT     <> '', LEFT(_$MDT, 19), MDT),
        MTIME  = GETTIME(),
        MEMP   = 'ERP',
        MPRG   = 'IF';

    -- D : 삭제
    ELSEIF _$IF_TYPE = 'D' THEN

      DELETE FROM MES_SNS2.MTRREQD
       WHERE REQNO  = _$REQ_NO
         AND REQSEQ = CONVERT(IFNULL(NULLIF(TRIM(_$REQ_SQ), ''), '0'), SIGNED);

    END IF;

  END WHILE;

  UPDATE IFSTD
     SET LASTTIME = GETTIME()
   WHERE PROCNAME = 'MES_IF_MTRREQD';

  IF _$FIRSTKEY > 0 THEN
    SELECT IFKEY
      FROM IF_ERR_LOG
     WHERE IFKEY >= _$FIRSTKEY
       AND IFNAME = 'MES_IF_MTRREQD';
  END IF;

END$$

DROP PROCEDURE IF EXISTS `MES_IF_MSTITEM_GRP_DTL`$$
CREATE PROCEDURE `MES_IF_MSTITEM_GRP_DTL`(
  IN $IF_KEY_LIST   MEDIUMTEXT,   -- 인터페이스 KEY
  IN $IF_TYPE_LIST  MEDIUMTEXT,   -- 인터페이스 구분(I/U/D)

  IN $SUB_CD_LIST   MEDIUMTEXT,   -- 그룹 세부 코드 (PK)
  IN $SUB_NM_LIST   MEDIUMTEXT,   -- 세부 명
  IN $GRP_CD_LIST   MEDIUMTEXT,   -- 그룹코드
  IN $SUB_NO_LIST   MEDIUMTEXT,   -- 서브코드
  IN $ELE_CD_LIST   MEDIUMTEXT,   -- 코드구성
  IN $FR_DT_LIST    MEDIUMTEXT,   -- 시작일
  IN $TO_DT_LIST    MEDIUMTEXT,   -- 종료일
  IN $RMKS_LIST     MEDIUMTEXT,   -- 비고
  IN $FAC_CD_LIST   MEDIUMTEXT    -- 공장코드
)
PROC: BEGIN
-- *****************************************************************************
-- Comment: 품목그룹 세부 수신 (ERP FAC2_MES_ITEM_GRP_DTL → MES_SNS2.MSTITEM_GRP_DTL)
-- Create: 2026-11-11
-- *****************************************************************************

  DECLARE _$IFKEY     VARCHAR(50);
  DECLARE _$FIRSTKEY  INT DEFAULT 0;
  DECLARE _$IF_TYPE   VARCHAR(1);

  DECLARE _$SUB_CD    VARCHAR(20);
  DECLARE _$SUB_NM    VARCHAR(50);
  DECLARE _$GRP_CD    VARCHAR(10);
  DECLARE _$SUB_NO    VARCHAR(20);
  DECLARE _$ELE_CD    VARCHAR(10);
  DECLARE _$FR_DT     VARCHAR(30);
  DECLARE _$TO_DT     VARCHAR(30);
  DECLARE _$RMKS      VARCHAR(50);
  DECLARE _$FAC_CD    VARCHAR(10);

  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1
      @sqlstate = RETURNED_SQLSTATE,
      @errno    = MYSQL_ERRNO,
      @text     = MESSAGE_TEXT;

    INSERT INTO IF_ERR_LOG (IFKEY, IFGB, IFNAME, IF_TYPE, READTIME, ERRMSG)
    VALUES (
      CONVERT(_$IFKEY, SIGNED),
      'ERP',
      'MES_IF_MSTITEM_GRP_DTL',
      _$IF_TYPE,
      GETTIME(),
      CONCAT('ERROR ', @errno, ' (', @sqlstate, '): ', @text)
    );

    COMMIT;
  END;

  WHILE LENGTH($SUB_CD_LIST) > 0 DO

    CALL COMSPLIT($IF_KEY_LIST,  _$IFKEY);
    CALL COMSPLIT($IF_TYPE_LIST, _$IF_TYPE);

    CALL COMSPLIT($SUB_CD_LIST,  _$SUB_CD);
    CALL COMSPLIT($SUB_NM_LIST,  _$SUB_NM);
    CALL COMSPLIT($GRP_CD_LIST,  _$GRP_CD);
    CALL COMSPLIT($SUB_NO_LIST,  _$SUB_NO);
    CALL COMSPLIT($ELE_CD_LIST,  _$ELE_CD);
    CALL COMSPLIT($FR_DT_LIST,   _$FR_DT);
    CALL COMSPLIT($TO_DT_LIST,   _$TO_DT);
    CALL COMSPLIT($RMKS_LIST,    _$RMKS);
    CALL COMSPLIT($FAC_CD_LIST,  _$FAC_CD);

    IF _$FIRSTKEY = 0 THEN
      SET _$FIRSTKEY = CONVERT(IFNULL(NULLIF(TRIM(_$IFKEY), ''), '0'), SIGNED);
    END IF;

    -- I : 신규등록 (이미 있으면 무시)
    IF _$IF_TYPE = 'I' THEN

      INSERT IGNORE INTO MES_SNS2.MSTITEM_GRP_DTL (
        SUBCD, SUBNM, GRPCD, SUBNO, ELECD, FRDT, TODT, RMKS, FACTORYCD,
        RTIME, REMP, RPRG
      ) VALUES (
        _$SUB_CD, _$SUB_NM, _$GRP_CD, _$SUB_NO, _$ELE_CD,
        LEFT(_$FR_DT, 10), LEFT(_$TO_DT, 10), _$RMKS, _$FAC_CD,
        GETTIME(), 'ERP', 'IF'
      );

    -- U : 수정 (없으면 등록)
    ELSEIF _$IF_TYPE = 'U' THEN

      INSERT INTO MES_SNS2.MSTITEM_GRP_DTL (
        SUBCD, SUBNM, GRPCD, SUBNO, ELECD, FRDT, TODT, RMKS, FACTORYCD,
        RTIME, REMP, RPRG
      ) VALUES (
        _$SUB_CD, _$SUB_NM, _$GRP_CD, _$SUB_NO, _$ELE_CD,
        LEFT(_$FR_DT, 10), LEFT(_$TO_DT, 10), _$RMKS, _$FAC_CD,
        GETTIME(), 'ERP', 'IF'
      )
      ON DUPLICATE KEY UPDATE
        SUBNM     = IF(_$SUB_NM <> '', _$SUB_NM, SUBNM),
        GRPCD     = IF(_$GRP_CD <> '', _$GRP_CD, GRPCD),
        SUBNO     = IF(_$SUB_NO <> '', _$SUB_NO, SUBNO),
        ELECD     = IF(_$ELE_CD <> '', _$ELE_CD, ELECD),
        FRDT      = IF(_$FR_DT  <> '', LEFT(_$FR_DT, 10), FRDT),
        TODT      = LEFT(_$TO_DT, 10),
        RMKS      = IF(_$RMKS   <> '', _$RMKS, RMKS),
        FACTORYCD = IF(_$FAC_CD <> '', _$FAC_CD, FACTORYCD),
        MTIME     = GETTIME(),
        MEMP      = 'ERP',
        MPRG      = 'IF';

    -- D : 삭제
    ELSEIF _$IF_TYPE = 'D' THEN

      DELETE FROM MES_SNS2.MSTITEM_GRP_DTL WHERE SUBCD = _$SUB_CD;

    END IF;

  END WHILE;

  UPDATE IFSTD
     SET LASTTIME = GETTIME()
   WHERE PROCNAME = 'MES_IF_MSTITEM_GRP_DTL';

  IF _$FIRSTKEY > 0 THEN
    SELECT IFKEY
      FROM IF_ERR_LOG
     WHERE IFKEY >= _$FIRSTKEY
       AND IFNAME = 'MES_IF_MSTITEM_GRP_DTL';
  END IF;

END$$

DELIMITER ;
