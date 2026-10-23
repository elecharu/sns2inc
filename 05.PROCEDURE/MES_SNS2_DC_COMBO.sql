CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.DC_COMBO(
-- *****************************************************************************
-- Comment: COMBOBOX
-- Create: 2016-11-10 14:45: 
-- Modify: 2016-11-10 14:45: 
-- *****************************************************************************
  IN $GPCD VARCHAR(20000),
  IN $REF01 VARCHAR(20),
  IN $REF02 VARCHAR(20),
  IN $REF03 VARCHAR(20),
  IN $REF04 VARCHAR(20),
  IN $REF05 VARCHAR(20),
  IN $REF06 VARCHAR(20),
  IN $REF07 VARCHAR(20),
  IN $REF08 VARCHAR(20),
  IN $REF09 VARCHAR(20),
  IN $REF10 VARCHAR(20)
)
PROC: BEGIN

  DECLARE _$SYEAR INT;
  DECLARE _$EYEAR INT;
  DECLARE _$HOUR INT DEFAULT 0;
  DECLARE _$MINUTE INT DEFAULT 0;

-- *****************************************************************************  
  IF EXISTS (SELECT GPCD FROM COMTYPEGP WHERE GPCD = $GPCD) THEN 
    
    -- SELECT CONCAT(TPCD, '•', TPNM) AS Label, TPCD AS Value
    SELECT TPNM AS Label, TPCD AS Value -- , REF01, REF02, REF03, REF04, REF05
      FROM COMTYPE
      WHERE GPCD = $GPCD AND USEYN = 'Y'
      AND REF01 LIKE CONCAT('%', $REF01, '%')
      AND REF02 LIKE CONCAT('%', $REF02, '%')
      AND REF03 LIKE CONCAT('%', $REF03, '%')
      AND REF04 LIKE CONCAT('%', $REF04, '%')
      AND REF05 LIKE CONCAT('%', $REF05, '%')
      AND REF06 LIKE CONCAT('%', $REF06, '%')
      AND REF20 LIKE CONCAT('%', $REF10, '%') -- 260910 KYC : S&S ERP 기준정보 공통코드 20 컬럼에 공장 데이터를 조회 하기 위함
      ORDER BY SORTNO;
    
-- *****************************************************************************  
  ELSEIF $GPCD = 'MONTH' THEN

    SELECT '01월' AS Label, '01' AS Value
    UNION SELECT '02월' AS Label, '02' AS Value
    UNION SELECT '03월' AS Label, '03' AS Value
    UNION SELECT '04월' AS Label, '04' AS Value
    UNION SELECT '05월' AS Label, '05' AS Value
    UNION SELECT '06월' AS Label, '06' AS Value
    UNION SELECT '07월' AS Label, '07' AS Value
    UNION SELECT '08월' AS Label, '08' AS Value
    UNION SELECT '09월' AS Label, '09' AS Value
    UNION SELECT '10월' AS Label, '10' AS Value
    UNION SELECT '11월' AS Label, '11' AS Value
    UNION SELECT '12월' AS Label, '12' AS Value;

-- *****************************************************************************  
  ELSEIF $GPCD = 'YEAR' THEN

    IF $REF01 = '' THEN SET $REF01 = '-5'; END IF;
    IF $REF02 = '' THEN SET $REF02 = '3'; END IF;

    DROP TABLE IF EXISTS TEMP_YEAR_COMBO;
    CREATE TEMPORARY TABLE TEMP_YEAR_COMBO ( 
      Label VARCHAR(100),
      Value VARCHAR(4)
    );

    SET _$SYEAR = LEFT(GETDATE(), 4) + $REF01;
    SET _$EYEAR = LEFT(GETDATE(), 4) + $REF02;

    WHILE _$SYEAR <= _$EYEAR DO

      INSERT INTO TEMP_YEAR_COMBO (Label, Value)
        VALUES (CONCAT(_$SYEAR, '년'), _$SYEAR);
      SET _$SYEAR = _$SYEAR + 1;

    END WHILE;

    SELECT * FROM TEMP_YEAR_COMBO;

-- *****************************************************************************  
  ELSEIF $GPCD = 'SALOUT_YEAR' THEN -- 매출 발생한 연도

    SELECT CONCAT(LEFT(SALOUTTIME, 4), '년') AS Label, LEFT(SALOUTTIME, 4) AS Value FROM SALOUT GROUP BY LEFT(SALOUTTIME, 4);

-- *****************************************************************************  
  ELSEIF $GPCD = 'WEEKTYPE' THEN

    SELECT '1주차' AS Label, '01' AS Value
    UNION SELECT '2주차' AS Label, '02' AS Value
    UNION SELECT '3주차' AS Label, '03' AS Value
    UNION SELECT '4주차' AS Label, '04' AS Value
    UNION SELECT '5주차' AS Label, '05' AS Value;

-- *****************************************************************************  
  ELSEIF $GPCD = 'BADTP_PRCCD' THEN  -- 불량유형(공정필터링 추가) (2026-08-11 신정수)

  SELECT COMTYPE.TPNM AS Label, COMTYPE.TPCD AS Value
  FROM MSTBAD
  INNER JOIN COMTYPE
    ON COMTYPE.GPCD = 'BADTP'
   AND COMTYPE.TPCD = MSTBAD.BADTP
  WHERE MSTBAD.PRCCD LIKE CONCAT('%', $REF01, '%')
  GROUP BY MSTBAD.BADTP
  ;

-- *****************************************************************************  
  ELSEIF $GPCD = 'FANO' THEN

    SELECT 
      MSTEQM.EQMNM AS Label, 
      MSTEQM.FANO AS Value, 
      MSTEQM.EQMNM AS Tag
      FROM MSTEQM
      INNER JOIN MSTEQM_MATCH ON MSTEQM.FANO = MSTEQM_MATCH.FANO
      WHERE MSTEQM_MATCH.EQMCD LIKE CONCAT('%', $REF01, '%')
        AND MSTEQM.USEYN = 'Y'
      ORDER BY MSTEQM.FANO;

-- *****************************************************************************  
  ELSEIF $GPCD = 'EQMTP' THEN

    SELECT 
      GPCD('FM100', EQMTP) AS Label, 
      EQMTP AS Value, 
      GPCD('FM100', EQMTP) AS Tag
      FROM MSTEQM
      WHERE USEYN = 'Y'
        AND LINECD LIKE CONCAT('%', $REF01, '%')
      GROUP BY EQMTP
      ORDER BY EQMTP;

-- *****************************************************************************  
  ELSEIF $GPCD = 'EQMGROUP1' THEN

    SELECT 
      GPCD('FM113', EQMGROUP1) AS Label, 
      EQMGROUP1 AS Value, 
      GPCD('FM113', EQMGROUP1) AS Tag
      FROM MSTEQM
      WHERE USEYN = 'Y'
        AND LINECD LIKE CONCAT('%', $REF01, '%')
        AND EQMTP LIKE CONCAT('%', $REF02, '%')
      GROUP BY EQMGROUP1
      ORDER BY EQMGROUP1;

-- *****************************************************************************  
  ELSEIF $GPCD = 'EQMGROUP2' THEN

    SELECT 
      GPCD('FM114', EQMGROUP2) AS Label, 
      EQMGROUP2 AS Value, 
      GPCD('FM114', EQMGROUP2) AS Tag
      FROM MSTEQM
      WHERE USEYN = 'Y'
        AND LINECD LIKE CONCAT('%', $REF01, '%')
        AND EQMTP LIKE CONCAT('%', $REF02, '%')
        AND EQMGROUP1 LIKE CONCAT('%', $REF03, '%')
      GROUP BY EQMGROUP2
      ORDER BY EQMGROUP2;

-- *****************************************************************************  
  ELSEIF $GPCD = 'EQMGROUP3' THEN

    SELECT 
      GPCD('FM115', EQMGROUP3) AS Label, 
      EQMGROUP3 AS Value, 
      GPCD('FM115', EQMGROUP3) AS Tag
      FROM MSTEQM
      WHERE USEYN = 'Y'
        AND LINECD LIKE CONCAT('%', $REF01, '%')
        AND EQMTP LIKE CONCAT('%', $REF02, '%')
        AND EQMGROUP1 LIKE CONCAT('%', $REF03, '%')
        AND EQMGROUP2 LIKE CONCAT('%', $REF04, '%')
      GROUP BY EQMGROUP3
      ORDER BY EQMGROUP3;

-- *****************************************************************************  
  ELSEIF $GPCD = 'PRCCD' THEN

    SELECT 
      MSTPRC.PRCNM AS Label, 
      MSTPRC.PRCCD AS Value, 
      MSTPRC.PRCNM AS Tag
      FROM MSTPRC
      WHERE MSTPRC.FACTORYCD LIKE CONCAT('%', $REF01,'%')
        AND MSTPRC.GUBUN_BC LIKE CONCAT('%', $REF02, '%') -- 사내, 외주 확인
        AND USEYN = 'Y'
      ORDER BY MSTPRC.PRCCD;

-- *****************************************************************************  
  ELSEIF $GPCD = 'PRCCD_AFTERCUT' THEN  -- 가공 후 공정

  SELECT MSTPRC.PRCNM AS Label, MSTPRC.PRCCD AS Value
  FROM MSTPRC
  WHERE MSTPRC.USEYN = 'Y'
    AND MSTPRC.PRCCD NOT IN ('CUT', 'ASY')
    AND MSTPRC.PRCTP = 'IN'
  ORDER BY MSTPRC.SORTNO, MSTPRC.PRCCD
  LIMIT 100;
-- *****************************************************************************  
  ELSEIF $GPCD = 'PRCCD_TML' THEN -- 단말기에 설정된 공정리스트 조회 
      SELECT MSTPRC.PRCNM AS Label, MSTPRC.PRCCD AS Value
        FROM MSTPRC
        WHERE MSTPRC.USEYN = 'Y'
          AND MSTPRC.FACTORY = (SELECT FACTORY FROM MSTTML WHERE TMLCD = $REF01 LIMIT 1)
        ORDER BY MSTPRC.SORTNO, MSTPRC.PRCCD
        LIMIT 100;
-- *****************************************************************************  

  ELSEIF $GPCD = 'PRCTYPE' THEN

    SELECT '성형' AS Label, 'FRM' AS Value
    UNION SELECT '검사포장' AS Label, 'PAK' AS Value;

-- ***************************************************************************** 
  ELSEIF $GPCD = 'PCT_TYPE' THEN

    SELECT '생산량' AS Label, 'PRODQTY' AS Value
    UNION SELECT 'PPM' AS Label, 'PPM' AS Value
    UNION SELECT '손실금액' AS Label, 'PRICE' AS Value;
-- *****************************************************************************  

  ELSEIF $GPCD = 'PCT_TYPE2' THEN

    SELECT 'PPM' AS Label, 'PPM' AS Value
    UNION SELECT '%' AS Label, 'PERCE' AS Value;

-- *****************************************************************************  

  ELSEIF $GPCD = 'CHKORDER' THEN

    SELECT '수량' AS Label, 'ORDERQTY' AS Value
    UNION SELECT 'PPM' AS Label, 'ORDERPPM' AS Value
    UNION SELECT '금액' AS Label, 'ORDERPRI' AS Value;

-- *****************************************************************************  

  ELSEIF $GPCD = 'ITEMTYPE' THEN

    SELECT '전체' AS Label, '00' AS Value
    UNION SELECT '배기' AS Label, '01' AS Value
    UNION SELECT '샤시' AS Label, '02' AS Value;

-- *****************************************************************************  
  ELSEIF $GPCD = 'WARECD' THEN -- 사내 창고만 조회
    
    SELECT MSTWARE.WARENM AS Label, MSTWARE.WARECD AS Value
      FROM MSTWARE
      WHERE MSTWARE.USEYN = 'Y'
        AND CASE 
              WHEN $REF01 = '' THEN MSTWARE.FACTORYCD = '07' 
              ELSE MSTWARE.FACTORYCD LIKE CONCAT('%', $REF01, '%')
            END
        AND ($REF02 = '' OR MSTWARE.SUBYN = $REF02)
--         AND MESYN = 'Y' -- 현장에 문제가 생김
        AND CUSTCD = ''
      ORDER BY MSTWARE.WARECD;

-- *****************************************************************************  
  ELSEIF $GPCD = 'WARECD_OSC' THEN -- 외주 창고만 조회
    
    SELECT MSTWARE.WARENM AS Label, MSTWARE.WARECD AS Value
      FROM MSTWARE
      WHERE MSTWARE.USEYN = 'Y'
        AND CASE 
              WHEN $REF01 = '' THEN MSTWARE.FACTORYCD = '07' 
              ELSE MSTWARE.FACTORYCD LIKE CONCAT('%', $REF01, '%')
            END
        AND ($REF02 = '' OR MSTWARE.SUBYN = $REF02)
--         AND MESYN = 'Y' -- 현장에 문제가 생김
        AND CUSTCD <> '' -- 외주처 창고인 경우 거래처가 있음
      ORDER BY MSTWARE.WARECD;

-- *****************************************************************************  
  ELSEIF $GPCD = 'WARECD_GOOD' THEN
    
    SELECT MSTWARE.WARENM AS Label, MSTWARE.WARECD AS Value
      FROM MSTWARE
      WHERE MSTWARE.USEYN = 'Y'
        AND CASE 
              WHEN $REF01 = '' THEN MSTWARE.FACTORYCD = '07' 
              ELSE MSTWARE.FACTORYCD LIKE CONCAT('%', $REF01, '%')
            END
        AND ($REF02 = '' OR MSTWARE.SUBYN = $REF02)
        AND BAD_YN = 'N'
        AND CUSTCD = ''
      ORDER BY MSTWARE.WARECD;
-- *****************************************************************************  
  ELSEIF $GPCD = 'WARECD_BAD' THEN
    
    SELECT MSTWARE.WARENM AS Label, MSTWARE.WARECD AS Value
      FROM MSTWARE
      WHERE MSTWARE.USEYN = 'Y'
        AND CASE 
              WHEN $REF01 = '' THEN MSTWARE.FACTORYCD = '07' 
              ELSE MSTWARE.FACTORYCD LIKE CONCAT('%', $REF01, '%')
            END
        AND ($REF02 = '' OR MSTWARE.SUBYN = $REF02)
        AND BAD_YN = 'Y'
        AND CUSTCD = ''
      ORDER BY MSTWARE.WARECD;

-- *****************************************************************************  
  ELSEIF $GPCD = 'MTRIN_WARECD' THEN    
    
    SELECT MSTWARE.WARENM AS Label
         , MSTWARE.WARECD AS Value
      FROM MSTWARE
     WHERE MSTWARE.USEYN = 'Y'
       AND MSTWARE.FACTORYCD = '07'
       AND IF($REF01 = '' OR $REF01 = 'Y'
            , MSTWARE.CUSTCD = ''
            , 1 = 1)
     ORDER BY MSTWARE.WARECD;

-- *****************************************************************************  
  ELSEIF $GPCD = 'TOOLCD' THEN

    -- SELECT CONCAT(MSTTOOL.TOOLCD, '•', MSTTOOL.TOOLNM) AS Label, MSTTOOL.TOOLCD AS Value
    SELECT MSTTOOL.TOOLNM AS Label, MSTTOOL.TOOLCD AS Value
      FROM MSTTOOL
      WHERE MSTTOOL.ITEMCD LIKE CONCAT('%', $REF01, '%')
      ORDER BY MSTTOOL.TOOLCD, MSTTOOL.TOOLNM
      LIMIT 100;

-- *****************************************************************************  
  ELSEIF $GPCD = 'TMLCD' THEN

    IF $REF01 IN ('YI', 'IBI') THEN

      SELECT MSTTML.TMLNM AS Label, MSTTML.TMLCD AS Value
        FROM MSTTML
        WHERE MSTTML.REF01 LIKE CONCAT('%', $REF01, '%')
        ORDER BY MSTTML.SORTNO, MSTTML.TMLCD, MSTTML.TMLNM
        LIMIT 100;

    ELSE

      SELECT MSTTML.TMLNM AS Label, MSTTML.TMLCD AS Value
        FROM MSTTML
        ORDER BY MSTTML.SORTNO, MSTTML.TMLCD, MSTTML.TMLNM
        LIMIT 100;

    END IF;

-- *****************************************************************************  
  ELSEIF $GPCD = 'AUTCD' THEN

    -- SELECT CONCAT(SYSAUT.AUTCD, '•', SYSAUT.AUTNM) AS Label, SYSAUT.AUTCD AS Value
    SELECT SYSAUT.AUTNM AS Label, SYSAUT.AUTCD AS Value
      FROM SYSAUT
      -- WHERE AUTTP CONCAT('%', $REF01, '%')
      ORDER BY SYSAUT.SORTNO
      LIMIT 100;

-- *****************************************************************************  
  ELSEIF $GPCD = 'NONCD' THEN

    -- SELECT CONCAT(MSTNON.NONCD, '•', MSTNON.NONNM) AS Label, MSTNON.NONCD AS Value
    SELECT MSTNON.NONNM AS Label, MSTNON.NONCD AS Value
      FROM MSTNON
      WHERE NONTP LIKE CONCAT('%', $REF01, '%')
      ORDER BY MSTNON.SORTNO, MSTNON.NONCD
      LIMIT 100;

-- *****************************************************************************
  ELSEIF $GPCD = 'COMPANYCD' THEN

    SELECT
      COMPANYNM AS Label,
      COMPANYCD AS Value
      FROM MSTCOMPANY
      WHERE MSTCOMPANY.COMPANYCD LIKE CONCAT('%', $REF01, '%')
      AND MSTCOMPANY.TODT = '' 
      ORDER BY COMPANYCD, COMPANYNM;

-- *****************************************************************************
  ELSEIF $GPCD = 'FACTORYCD' THEN

    SELECT 
      MSTFACTORY.FACTORYNM AS Label, 
      MSTFACTORY.FACTORYCD AS Value
      FROM MSTFACTORY
      LEFT JOIN MSTCOMPANY ON MSTFACTORY.COMPANYCD = MSTCOMPANY.COMPANYCD
      WHERE MSTFACTORY.COMPANYCD LIKE CONCAT('%', $REF01, '%')
      AND MSTCOMPANY.TODT = ''
      ORDER BY FACTORYCD, FACTORYNM;

-- *****************************************************************************  
  ELSEIF $GPCD = 'CUSTCD' THEN

    SELECT MSTCUST.CUSTNM AS Label, 
      MSTCUST.CUSTCD AS Value, 
      MSTCUST.CUSTNM AS Tag
      FROM MSTCUST
      ORDER BY MSTCUST.CUSTCD, MSTCUST.CUSTNM
      ;
     
 -- *****************************************************************************  

  ELSEIF $GPCD = 'CUSTPURSALE' THEN

    SELECT '구매처' AS Label, '1' AS Value, '구매처' AS Tag
    UNION SELECT '판매처' AS Label, '2' AS Value, '판매처' AS Tag;

-- *****************************************************************************  
  ELSEIF $GPCD = 'EMPCD' THEN

    SELECT MSTEMP.EMPNM AS Label, 
      MSTEMP.EMPCD AS Value,
      MSTEMP.EMPNM AS Tag
      FROM MSTEMP
      ORDER BY MSTEMP.EMPNM;

-- *****************************************************************************  
  ELSEIF $GPCD = 'DEPTCD' THEN

    SELECT MSTDEPT.DEPTNM AS Label, 
      MSTDEPT.DEPTCD AS Value,
      MSTDEPT.DEPTNM AS Tag
    FROM MSTDEPT
    WHERE BDVCD LIKE CONCAT('%', $REF01, '%')
    ORDER BY MSTDEPT.DEPTCD, MSTDEPT.DEPTNM;

-- *****************************************************************************  
  ELSEIF $GPCD = 'BADCD' THEN

    -- SELECT CONCAT(MSTBAD.BADCD, '•', MSTBAD.BADNM) AS Label, MSTBAD.BADCD AS Value
    SELECT MSTBAD.BADNM AS Label, MSTBAD.BADCD AS Value
      FROM MSTBAD
      WHERE MSTBAD.BADTP LIKE CONCAT('%', $REF01, '%')
        AND MSTBAD.PRCCD LIKE CONCAT('%', $REF02, '%')
      ORDER BY MSTBAD.BADCD, MSTBAD.BADNM
      LIMIT 100;

-- *****************************************************************************  
  ELSEIF $GPCD = 'TMLCD' THEN

    -- SELECT CONCAT(MSTTML.TMLCD, '•', MSTTML.TMLNM) AS Label, MSTTML.TMLCD AS Value
    SELECT MSTTML.TMLNM AS Label, MSTTML.TMLCD AS Value
      FROM MSTTML
      WHERE MSTTML.BDVCD LIKE CONCAT('%', $REF01, '%')
      ORDER BY MSTTML.TMLNM
      LIMIT 100;

-- *****************************************************************************  
  ELSEIF $GPCD = 'BDVCD' THEN

    SELECT 
      MSTBDV.BDVNM AS Label, 
      MSTBDV.BDVCD AS Value
      FROM MSTBDV
      WHERE MSTBDV.COMPANYCD LIKE CONCAT('%', $REF01, '%') 
      AND (MSTBDV.TODT = '' OR MSTBDV.TODT IS NULL)
      ORDER BY MSTBDV.BDVCD, MSTBDV.BDVNM;

-- *****************************************************************************  
  ELSEIF $GPCD = 'TANKCD' THEN

    -- SELECT CONCAT(MSTTANK.TANKCD, '•', MSTTANK.TANKNM) AS Label, MSTTANK.TANKCD AS Value
    SELECT MSTTANK.TANKNM AS Label, MSTTANK.TANKCD AS Value
      FROM MSTTANK
      WHERE MSTTANK.TANKCD LIKE CONCAT('%', $REF01, '%')
      ORDER BY MSTTANK.TANKNM
      LIMIT 100;

-- *****************************************************************************
  ELSEIF $GPCD = 'TRCCD' THEN

    -- SELECT CONCAT(MSTTRC.TRCCD, '•', MSTTRC.TRCNM) AS Label, MSTTRC.TRCCD Value
    SELECT MSTTRC.TRCNM AS Label, MSTTRC.TRCCD AS Value
      FROM MSTTRC
      -- WHERE MSTTRC.TRCCD LIKE CONCAT('%', $REF01, '%')
      ORDER BY MSTTRC.TRCNM
      LIMIT 100;

-- *****************************************************************************
  ELSEIF $GPCD = 'MITEMID' THEN

    SELECT CONCAT(MSTITEM.ITEMCD, ' • ', MSTITEM.ITEMNM) AS Label, MSTBOM.MITEMID Value
      FROM MSTBOM
      INNER JOIN MSTITEM ON MSTBOM.MITEMID = MSTITEM.ITEMID
      WHERE MSTBOM.CITEMID = $REF01
        AND MSTBOM.USEYN = 'Y'
      ORDER BY MSTBOM.MITEMID;

-- *****************************************************************************
  ELSEIF $GPCD = 'CITEMCD' THEN

    SELECT MSTITEM.ITEMNM AS Label, MSTBOM.MITEMID AS Value
      FROM MSTBOM
      INNER JOIN MSTITEM ON MSTBOM.MITEMID = MSTITEM.ITEMID
      WHERE MSTBOM.CITEMID = $REF01
      ORDER BY MSTBOM.MITEMID;

-- *****************************************************************************
  ELSEIF $GPCD = 'CUTITEM' THEN

    -- SELECT CONCAT(MSTBOM_CUT.MITEMCD, '•', MSTBOM_CUT.ITEMNM) AS Label, MSTBOM_CUT.MITEMCD Value
--     SELECT CONCAT(MSTITEM.ITEMCD, '/', MSTBOM_CUT.CUTTOOLCD) AS Label, CONCAT(MSTITEM.ITEMCD, '/', MSTBOM_CUT.CUTTOOLCD) AS Value
  SELECT MSTITEM.ITEMNM AS Label, CONCAT(MSTITEM.ITEMCD, '/', MSTBOM_CUT.CUTTOOLCD) AS Value
      FROM MSTBOM_CUT
      LEFT JOIN MSTITEM ON MSTBOM_CUT.CUTITEMCD = MSTITEM.ITEMCD
      WHERE MSTBOM_CUT.ITEMCD = $REF01
        AND MSTBOM_CUT.USEYN = 'Y'
      ORDER BY MSTBOM_CUT.CUTITEMCD;

-- *****************************************************************************
  ELSEIF $GPCD = 'BAWITEM' THEN

    -- SELECT CONCAT(MSTBOM_CUT.MITEMCD, '•', MSTBOM_CUT.ITEMNM) AS Label, MSTBOM_CUT.MITEMCD Value
    SELECT CONCAT(MSTITEM.ITEMCD, '/', MSTBOM_BAW.BAWTOOLCD) AS Label, CONCAT(MSTBOM_BAW.BAWITEMCD, '/', MSTBOM_BAW.BAWTOOLCD) AS Value
      FROM MSTBOM_BAW
      LEFT JOIN MSTITEM ON MSTBOM_BAW.BAWITEMCD = MSTITEM.ITEMCD
      WHERE MSTBOM_BAW.ITEMCD = $REF01
      ORDER BY MSTBOM_BAW.BAWITEMCD;

-- *****************************************************************************
  ELSEIF $GPCD = 'EQMCD' THEN

    -- REF01 유형 REF02 공정
    -- SELECT CONCAT(MSTEQM.EQMCD, '•', MSTEQM.EQMNM) AS Label, MSTEQM.EQMCD Value
    IF $REF01 <> '' THEN

      SELECT MSTEQM.EQMNM AS Label, MSTEQM.EQMCD AS Value
        FROM MSTEQM
        WHERE MSTEQM.EQMTP = $REF01
        ORDER BY MSTEQM.EQMCD;

    ELSEIF $REF02 <> '' THEN

      SELECT MSTEQM.EQMNM AS Label, MSTEQM.EQMCD AS Value
        FROM MSTEQM
        WHERE MSTEQM.PRCCD = $REF02
        ORDER BY MSTEQM.EQMCD;

    ELSE

      SELECT MSTEQM.EQMNM AS Label, MSTEQM.EQMCD AS Value
        FROM MSTEQM
        WHERE MSTEQM.EQMCD LIKE CONCAT('%', $REF01, '%')
        ORDER BY MSTEQM.EQMCD;

    END IF;

    
-- *****************************************************************************
  ELSEIF $GPCD = 'EQMCD_OQC' THEN

      SELECT MSTEQM.EQMNO AS Label, MSTEQM.EQMCD AS Value
        FROM MSTEQM
        WHERE MSTEQM.EQMCD LIKE CONCAT('%', $REF01, '%')
          AND MSTEQM.PRCCD = 'OQC01'
        ORDER BY MSTEQM.EQMNO;

-- *****************************************************************************
   ELSEIF $GPCD = 'LABELCD' THEN

    -- SELECT CONCAT(MSTBOM.CITEMCD, '•', MSTITEM.ITEMNM) AS Label, MSTBOM.CITEMCD Value
    SELECT SYSLABEL.LABELCD AS Label, SYSLABEL.LABELCD AS Value
      FROM SYSLABEL
      ORDER BY SYSLABEL.LABELCD;

-- *****************************************************************************
   ELSEIF $GPCD = 'EXPDATA' THEN

    -- SELECT CONCAT(MSTBOM.CITEMCD, '•', MSTITEM.ITEMNM) AS Label, MSTBOM.CITEMCD Value
    SELECT CONCAT(MSTITEMEXP.ITEMCD, '/', MSTITEMEXP.MODELTP, '/', MSTITEMEXP.PARTNO, '/', MSTITEMEXP.PLACE, '/', MSTITEMEXP.LOCALPLACE) AS Label,
      MSTITEMEXP.ITEMEXPKEY AS Value
      FROM MSTITEMEXP
      WHERE MSTITEMEXP.ITEMCD LIKE CONCAT('%', $REF01, '%');

-- *****************************************************************************
   ELSEIF $GPCD = 'TPTOOL' THEN

     IF $REF02 = 'TOOL' THEN
    
        SELECT COMTYPE.TPNM AS Label, COMTYPE.TPCD AS Value
          FROM COMTYPE
          WHERE COMTYPE.GPCD ='TOOLTP'
            AND COMTYPE.TPCD IN ('IM','IN','IO') ;

     ELSEIF $REF02 <> '' THEN
    
        SELECT COMTYPE.TPNM AS Label, COMTYPE.TPCD AS Value
          FROM COMTYPE
          WHERE COMTYPE.GPCD ='TOOLTP'
            AND COMTYPE.TPCD NOT IN ('IP', 'IQ', 'IR');
     ELSE
    
        SELECT COMTYPE.TPNM AS Label, COMTYPE.TPCD AS Value
          FROM COMTYPE
          WHERE COMTYPE.GPCD ='TOOLTP';
     
     END IF;
-- *****************************************************************************
   ELSEIF $GPCD = 'PKGTP' THEN
  
      SELECT PKGNM AS Label, PKGTP AS Value
        FROM SYSPKG;

-- *****************************************************************************
   ELSEIF $GPCD = 'PKGTP_E' THEN
  
      SELECT PKGNM AS Label, PKGTP AS Value
        FROM SYSPKG;

-- -- *****************************************************************************  
    ELSEIF $GPCD = 'CATECD' THEN
      SELECT '' AS Label, '' AS Value
      UNION ALL  
      SELECT CATENM AS Label, CATECD AS Value
        FROM SYSCATE
       WHERE PKGTP = $REF01;
-- *****************************************************************************
   ELSEIF $GPCD = 'PRGSTT_E' THEN
  
      SELECT '대기' AS Label, '10' AS Value
      UNION SELECT '배정' AS Label, '20' AS Value
      UNION SELECT '진행' AS Label, '30' AS Value
      UNION SELECT '완료' AS Label, '40' AS Value
      UNION SELECT '삭제' AS Label, '50' AS Value
      UNION SELECT '숨김' AS Label, '60' AS Value;

-- *****************************************************************************
   ELSEIF $GPCD = 'PRGORI_E' THEN
  
      SELECT 'NEW' AS Label, 'NEW' AS Value
      UNION SELECT 'MIPL' AS Label, 'MIPL' AS Value
      UNION SELECT 'MES' AS Label, 'MES' AS Value;

-- *****************************************************************************
   ELSEIF $GPCD = 'STOPTIME' THEN
  
      SELECT '5분' AS Label, '5' AS Value
      UNION SELECT '10분' AS Label, '10' AS Value
      UNION SELECT '30분' AS Label, '30' AS Value
      UNION SELECT '60분' AS Label, '60' AS Value;

-- *****************************************************************************

  ELSEIF $GPCD = 'INCLUDEYN' THEN

    SELECT
      '포함' AS Label,
      'Y' AS Value,
      '포함' AS Tag
    UNION
    SELECT
      '제외' AS Label,
      'N' AS Value,
      '제외' AS Tag;

-- *****************************************************************************
  ELSEIF $GPCD = 'MOVEWORKGROUP' THEN

    SELECT
        '전체' AS Label,
        '' AS Value,
        '전체' AS Tag
        FROM dual
        WHERE $REF01 <> ''
    UNION ALL
    SELECT
      COMTYPE.TPNM AS Label,
      COMTYPE.TPCD AS Value,
      COMTYPE.TPNM AS Tag
      FROM COMTYPE
      WHERE COMTYPE.GPCD = 'WORKGROUP'
        AND COMTYPE.TPCD <> $REF01;     

-- *****************************************************************************
  ELSEIF $GPCD = 'TERMTP' THEN

    SELECT
      '주별' AS Label,
      1 AS Value,
      '주별' AS Tag
    UNION
    SELECT
      '월별' AS Label,
      2 AS Value,
      '월별' AS Tag;

-- *****************************************************************************

  ELSEIF $GPCD = 'DILIGCD' THEN

    SELECT HRMDILIGENCD.DILIGNM AS Label, 
      HRMDILIGENCD.DILIGCD AS Value,
      HRMDILIGENCD.DILIGNM AS Tag
      FROM HRMDILIGENCD
      WHERE CASE WHEN $REF01 = 'Y' THEN HRMDILIGENCD.DAYYN = 'Y' ELSE 1 = 1 END
        AND CASE WHEN $REF02 = 'Y' THEN HRMDILIGENCD.MONYN = 'Y' ELSE 1 = 1 END
      ORDER BY HRMDILIGENCD.SORTSEQ
      ;

-- *****************************************************************************

  ELSEIF $GPCD = 'CALDILIGCD' THEN

    SELECT HRMDILIGENCD.DILIGNM AS Label, 
      HRMDILIGENCD.DILIGCD AS Value,
      HRMDILIGENCD.DILIGNM AS Tag
      FROM HRMDILIGENCD
      WHERE HRMDILIGENCD.DILIGCD IN('130', '310', '320', '420')
      ORDER BY HRMDILIGENCD.DILIGCD, HRMDILIGENCD.DILIGNM
    ;

-- *****************************************************************************
  ELSEIF $GPCD = 'YESNO' THEN

    SELECT '예' AS Label,
      'Y' AS Value,
      '예' AS Tag
      UNION
      SELECT '아니오' AS Label,
        'N' AS Value,
        '아니오' AS Tag;


-- *****************************************************************************
  ELSEIF $GPCD = 'INCLUDEYN' THEN

    SELECT
      '포함' AS Label,
      'Y' AS Value,
      '포함' AS Tag
    UNION
    SELECT
      '미포함' AS Label,
      'N' AS Value,
      '미포함' AS Tag;

-- *****************************************************************************
  ELSEIF $GPCD = 'BRANDCD' THEN

    -- SELECT CONCAT(MSTTOOL.TOOLCD, '•', MSTTOOL.TOOLNM) AS Label, MSTTOOL.TOOLCD AS Value
    SELECT MSTBRAND.BRANDCD AS Label, MSTBRAND.BRANDCD AS Value
      FROM MSTBRAND
      ORDER BY MSTBRAND.BRANDCD, MSTBRAND.BRANDNM
      LIMIT 100;
-- *****************************************************************************

  ELSEIF $GPCD = 'EXCRATE' THEN

    SELECT
      '기준환율' AS Label,
      'EXBASERT' AS Value,
      '기준환율' AS Tag
    UNION
    SELECT
      '현금구매가' AS Label,
      'EXCASHBUY' AS Value,
      '현금구매가' AS Tag
    UNION
    SELECT
      '현금판매가' AS Label,
      'EXCASHSALE' AS Value,
      '현금판매가' AS Tag
    UNION
    SELECT
      '송금구매가' AS Label,
      'EXCTTBUY' AS Value,
      '송금구매가' AS Tag
    UNION
    SELECT
      '송금판매가' AS Label,
      'EXCTTSALE' AS Value,
      '송금판매가' AS Tag;

-- *****************************************************************************

    ELSEIF $GPCD = 'PAYMETHODA' THEN

      SELECT SALODR.PAYMETHODA AS Label, SALODR.PAYMETHOD AS Value
      FROM SALODR
      ORDER BY SALODR.PAYMETHOD, SALODR.PAYMETHODA
      LIMIT 100;

-- *****************************************************************************

    ELSEIF $GPCD = 'PRICECONDA' THEN

      SELECT SALODR.PRICECONDA AS Label, SALODR.PRICECOND AS Value
      FROM SALODR
      ORDER BY SALODR.PRICECOND, SALODR.PRICECONDA
      LIMIT 100;

-- *****************************************************************************

    ELSEIF $GPCD = 'SHIPMETHODA' THEN

      SELECT SALODR.SHIPMETHODA AS Label, SALODR.SHIPMETHOD AS Value
      FROM SALODR
      ORDER BY SALODR.SHIPMETHOD, SALODR.SHIPMETHODA
      LIMIT 100;

-- *****************************************************************************

    ELSEIF $GPCD = 'PARTSHIPA' THEN

      SELECT SALODR.PARTSHIPA AS Label, SALODR.PARTSHIP AS Value
      FROM SALODR
      ORDER BY SALODR.PARTSHIP, SALODR.PARTSHIPA
      LIMIT 100;

-- *****************************************************************************

    ELSEIF $GPCD = 'ALLOWCD' THEN

      SELECT HRMALLOWCD.ALLOWNM AS Label, HRMALLOWCD.ALLOWCD AS Value
        FROM HRMALLOWCD
        ORDER BY HRMALLOWCD.ALLOWCD, ALLOWTP
        LIMIT 100;

-- *****************************************************************************  
  ELSEIF $GPCD = 'BDVTEL' THEN

    -- SELECT CONCAT(MSTBDV.BDVCD, '•', MSTBDV.BDVNM) AS Label, MSTBDV.BDVCD AS Value
    SELECT MSTBDV.TELNO AS Label, MSTBDV.TELNO AS Value, MSTBDV.BDVNM AS Tag
      FROM MSTBDV
      -- WHERE MSTBDV.BDVCD LIKE CONCAT('%', $REF01, '%')
      WHERE MSTBDV.USEYN = 'Y'
      ORDER BY MSTBDV.BDVCD, MSTBDV.BDVNM;
-- *****************************************************************************
  ELSEIF $GPCD = 'HOUR' THEN
    DROP TABLE IF EXISTS TEMP_HOUR_COMBO;
    CREATE TEMPORARY TABLE TEMP_HOUR_COMBO ( 
      Label VARCHAR(100),
      Value VARCHAR(4),
      Tag VARCHAR(100)
    );
    WHILE _$HOUR < 24 DO
      INSERT INTO TEMP_HOUR_COMBO
             SELECT 
                    CASE WHEN _$HOUR < 10 THEN CONCAT('0',_$HOUR) ELSE _$HOUR END AS Label,
                    _$HOUR AS Value,
                    CASE WHEN _$HOUR < 10 THEN CONCAT('0',_$HOUR) ELSE _$HOUR END AS Tag;
      SET _$HOUR = _$HOUR + 1;
    END WHILE;
    
    SELECT * FROM TEMP_HOUR_COMBO;
-- *****************************************************************************
  ELSEIF $GPCD = 'MINUTE' THEN
    DROP TABLE IF EXISTS TEMP_MINUTE_COMBO;
    CREATE TEMPORARY TABLE TEMP_MINUTE_COMBO ( 
      Label VARCHAR(100),
      Value VARCHAR(4),
      Tag VARCHAR(100)
    );
    WHILE _$MINUTE < 60 DO
      INSERT INTO TEMP_MINUTE_COMBO
             SELECT 
                    CASE WHEN _$MINUTE < 10 THEN CONCAT('0',_$MINUTE) ELSE _$MINUTE END AS Label,
                    _$MINUTE AS Value,
                    CASE WHEN _$MINUTE < 10 THEN CONCAT('0',_$MINUTE) ELSE _$MINUTE END AS Tag;
      SET _$MINUTE = _$MINUTE + 1;
    END WHILE;

    SELECT * FROM TEMP_MINUTE_COMBO;

-- *****************************************************************************
--   ELSEIF $GPCD = 'DEPNAME' THEN
-- 
--     SELECT
--       MSTDEPT.DEPTNM AS Label,
--       MSTDEPT.DEPTP AS Value,
--       MSTDEPT.DEPTNM AS Tag
--       FROM MSTDEPT
--       WHERE MSTDEPT.USEYN = 'Y'
--       LIMIT 100;

-- *****************************************************************************  

  ELSEIF $GPCD = 'TMLEQM' THEN

    SELECT '전체' AS Label, 'ALLP' AS Value
    UNION SELECT 'A동' AS Label, 'AP' AS Value
    UNION SELECT 'B동 OR H동' AS Label, 'BP' AS Value;

-- *****************************************************************************  
  ELSEIF $GPCD = 'RANKING' THEN

    SELECT '10위' AS Label, '10' AS Value, '10위' AS Tag
    UNION SELECT '20위' AS Label, '20' AS Value, '20위' AS Tag
    UNION SELECT '30위' AS Label, '30' AS Value, '30위' AS Tag
    UNION SELECT '40위' AS Label, '40' AS Value, '40위' AS Tag
    UNION SELECT '50위' AS Label, '50' AS Value, '50위' AS Tag
    UNION SELECT '70위' AS Label, '70' AS Value, '70위' AS Tag
    UNION SELECT '100위' AS Label, '100' AS Value, '100위' AS Tag
    UNION SELECT '200위' AS Label, '200' AS Value, '200위' AS Tag;

-- *****************************************************************************
  ELSEIF $GPCD = 'AREACD' THEN

    SELECT MSTAREA.AREANM AS Label, 
      MSTAREA.AREACD AS Value,
      MSTAREA.AREANM AS Tag
      FROM MSTAREA
      ORDER BY MSTAREA.AREACD, MSTAREA.AREANM
      ;
-- *****************************************************************************
   ELSEIF $GPCD = 'CARCD' THEN

    SELECT MSTCARINFO.CARNAME AS Label, 
      MSTCARINFO.CARCD AS Value,
      MSTCARINFO.CARNAME AS Tag
      FROM MSTCARINFO
      ORDER BY MSTCARINFO.CARNAME, MSTCARINFO.CARCD
      ;

-- *****************************************************************************

  ELSEIF $GPCD = 'DEPTOWNER' THEN

    SELECT ME.EMPNM AS Label, ME.EMPCD AS Value, ME.EMPNM AS Tag
      FROM MSTEMP AS ME;

-- *****************************************************************************
  ELSEIF $GPCD = 'EXTIMATETP' THEN
    SELECT ME.TPNM AS Label, ME.TPCD AS Value
      FROM COMTYPE AS ME
     WHERE ME.GPCD = 'EXTIMATETP';

-- *****************************************************************************  
  
  ELSEIF $GPCD = 'SALDATETYPE' THEN

    SELECT
      '검수일자' AS Label,
      '1' AS Value,
      '검수일자' AS Tag
    UNION
    SELECT
      '출고일자' AS Label,
      '2' AS Value,
      '출고일자' AS Tag;   

-- *****************************************************************************  

  ELSEIF $GPCD = 'LINECD' THEN

    SELECT 
      MSTLINE.LINENM AS Label, 
      MSTLINE.LINECD AS Value
      FROM MSTLINE
      WHERE MSTLINE.USEYN = 'Y'
        AND MSTLINE.EDT = ''
        AND MSTLINE.FACTORYCD LIKE CONCAT('%', $REF01, '%')
      ORDER BY LINECD, LINENM;

-- *****************************************************************************  
  ELSEIF $GPCD = 'A' OR $GPCD = '' THEN

      SELECT 'ADDD' AS Label, '' AS Value;
-- *****************************************************************************  
  ELSEIF $GPCD = 'BOX2' THEN

    SELECT 'BOX' AS Label, 'A' AS Value
      UNION SELECT 'PALLET' AS Label, 'B' AS Value;
-- *****************************************************************************  
  ELSEIF $GPCD = 'YESNO2' THEN

    SELECT 'YES' AS Label, 'YES' AS Value
      UNION SELECT 'NO' AS Label, 'NO' AS Value;

-- *****************************************************************************  
  ELSEIF $GPCD = 'COMPCD' THEN

    SELECT
      COMPNM AS Label,
      COMPCD AS Value,
      COMPNM AS Tag
      FROM MSTCOMPANY
      ORDER BY COMPCD, COMPNM;

-- *****************************************************************************        
  ELSEIF $GPCD = 'CENTERCD' THEN

    SELECT
      MSTCENTER.CENTERNM AS Label,
      MSTCENTER.CENTERCD AS Value,
      MSTCENTER.CENTERNM AS Tag
      FROM MSTCENTER
      ORDER BY MSTCENTER.CENTERCD, MSTCENTER.CENTERNM;

-- *****************************************************************************
   ELSEIF $GPCD = 'PKGTP_SCM' THEN  -- SCM 패키지 추가
  
      SELECT PKGNM AS Label, PKGTP AS Value
        FROM SYSPKG
      WHERE USEYN = 'Y'
        AND PKGTP != 'MY';

-- *****************************************************************************
   ELSEIF $GPCD = 'PRGSTT_E' THEN
  
      SELECT '대기' AS Label, '10' AS Value
      UNION SELECT '배정' AS Label, '20' AS Value
      UNION SELECT '진행' AS Label, '30' AS Value
      UNION SELECT '완료' AS Label, '40' AS Value
      UNION SELECT '삭제' AS Label, '50' AS Value
      UNION SELECT '숨김' AS Label, '60' AS Value;

-- *****************************************************************************  
    ELSEIF $GPCD = 'CATECD_SCM' THEN  -- SCM 카테고리 추가 
      SELECT '' AS Label, '' AS Value
      UNION ALL  
      SELECT CATENM AS Label, CATECD AS Value
        FROM SYSCATE
       WHERE PKGTP = $REF01;

-- *****************************************************************************
   ELSEIF $GPCD = 'PRGORI_E' THEN
  
      SELECT 'NEW' AS Label, 'NEW' AS Value
      UNION SELECT 'MIPL' AS Label, 'MIPL' AS Value
      UNION SELECT 'MES' AS Label, 'MES' AS Value;

-- *****************************************************************************  
  ELSEIF $GPCD = 'AUTCD_SCM' THEN -- SCM 권한 추가 (2024-11-28 신정수)

    -- SELECT CONCAT(SYSAUT.AUTCD, '•', SYSAUT.AUTNM) AS Label, SYSAUT.AUTCD AS Value
    SELECT SYSAUT.AUTNM AS Label, SYSAUT.AUTCD AS Value
      FROM SYSAUT AS SYSAUT
      -- WHERE AUTTP CONCAT('%', $REF01, '%')
      ORDER BY SYSAUT.SORTNO
      LIMIT 100;

-- *****************************************************************************  

  ELSE -- 쿼리문 바로 실행
  
    SET @CALLPROC = $GPCD;
    PREPARE CALLPROC FROM @CALLPROC;
    EXECUTE CALLPROC ;
    DEALLOCATE PREPARE CALLPROC;  


-- *****************************************************************************  
END IF; END