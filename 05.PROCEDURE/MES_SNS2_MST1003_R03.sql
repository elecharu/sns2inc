CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.MST1003_R03(
-- *****************************************************************************
-- Comment: 불량코드관리
-- Create: 2024-02-22 13:50: 김영철
-- Modify: 2026-11-27: 불량코드별 연결 검사항목(MSTBAD_STD) 관리 - 현장 불량등록(TML2010_R01) 불량상세 목록용
--           SEL_BAD 연결검사항목 컬럼(STDNMS), SEL_BADSTD, SAVE_BADSTD, $BADCD·$STDCD_LIST 추가
-- *****************************************************************************
  IN $TPNM VARCHAR(20),
  IN $FACTORYCD VARCHAR(20),
  IN $BADTP1 VARCHAR(20),
  IN $BADTP2 VARCHAR(20),
  IN $BADCD VARCHAR(10),
  IN $STDCD_LIST MEDIUMTEXT,
  IN $CALLTYPE VARCHAR(50),
  IN $KEYWORD VARCHAR(1000)
  )
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$STDCD     VARCHAR(100);
  DECLARE _$STDCD_ALL MEDIUMTEXT;
-- *****************************************************************************
  CASE $CALLTYPE
-- ****************************************************************************
  WHEN 'SEL_BAD' THEN

    SELECT
      MSTBAD.BADCD, MSTBAD.BADNM, MSTBAD.USEYN,
      GPCD('QM210', MSTBAD.BADTP1) AS BADTP1, GPCD('QM220', MSTBAD.BADTP2) AS BADTP2, MSTBAD.BADTP3,
      MSTBAD.M5, MSTBAD.M6, MSTBAD.M7, MSTBAD.IQCYN,
      MSTBAD.PQCYN, MSTBAD.OQCYN, MSTBAD.M11, MSTBAD.M12, MSTBAD.M20,
      IFNULL((SELECT GROUP_CONCAT(MSTSTD.STDNM ORDER BY MSTSTD.STDNM SEPARATOR ', ')
                FROM MSTBAD_STD
                INNER JOIN MSTSTD ON MSTSTD.STDCD = MSTBAD_STD.STDCD
               WHERE MSTBAD_STD.BADCD = MSTBAD.BADCD), '') AS STDNMS
      FROM MSTBAD
      INNER JOIN MSTFACTORY ON MSTBAD.M20 = MSTFACTORY.FACTORYCD
      WHERE MSTBAD.BADNM LIKE CONCAT('%', $TPNM, '%')
        AND MSTBAD.BADTP1 LIKE CONCAT('%', $BADTP1, '%')
        AND MSTBAD.BADTP2 LIKE CONCAT('%', $BADTP2, '%')
        AND MSTFACTORY.FACTORYCD LIKE CONCAT('%', $FACTORYCD, '%')
    ORDER BY MSTBAD.BADTP1, MSTBAD.BADTP2, MSTBAD.BADCD;

-- ****************************************************************************
  WHEN 'SEL_BADSTD' THEN -- 연결 검사항목(오른쪽 그리드): 자주검사(PRCTEST) 검사항목 전체, 그 불량코드에 연결된 것은 체크

    SELECT MSTSTD.STDCD,
           MSTSTD.STDNM,
           MSTSTD.STDPOINT,
           IF(MSTBAD_STD.BADCD IS NULL, 'N', 'Y') AS isRowCheck
      FROM MSTSTD
      LEFT JOIN MSTBAD_STD
             ON MSTBAD_STD.BADCD = $BADCD
            AND MSTBAD_STD.STDCD = MSTSTD.STDCD
     WHERE MSTSTD.STDTP = 'PRCTEST'
        OR MSTBAD_STD.BADCD IS NOT NULL -- 검사구분이 바뀌었어도 이미 연결된 항목은 보여준다
     ORDER BY IF(MSTBAD_STD.BADCD IS NULL, 1, 0), MSTSTD.STDNM, MSTSTD.STDCD;

-- ****************************************************************************
  WHEN 'SAVE_BADSTD' THEN -- 연결 검사항목 저장: 넘어온(체크한) 항목은 연결 등록, 빠진 항목은 연결 삭제

    IF IFNULL($BADCD, '') = '' THEN
      CALL COMERR('불량코드를 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 체크를 푼 항목 삭제 (리스트는 'A»B»' 형태라 앞에 » 를 붙여 '»코드»' 로 비교)
    SET _$STDCD_ALL = CONCAT('»', IFNULL($STDCD_LIST, ''));

    DELETE FROM MSTBAD_STD
     WHERE MSTBAD_STD.BADCD = $BADCD
       AND _$STDCD_ALL NOT LIKE CONCAT('%»', MSTBAD_STD.STDCD, '»%');

    WHILE LENGTH($STDCD_LIST) > 0 DO
      CALL COMSPLIT($STDCD_LIST, _$STDCD);

      SET _$STDCD = TRIM(IFNULL(_$STDCD, ''));

      IF _$STDCD <> '' AND NOT EXISTS (SELECT 1 FROM MSTBAD_STD
                                        WHERE MSTBAD_STD.BADCD = $BADCD
                                          AND MSTBAD_STD.STDCD = _$STDCD) THEN
        INSERT INTO MSTBAD_STD
          (BADCD, STDCD, RTIME, REMP, RPRG)
        VALUES
          ($BADCD, _$STDCD, CALLTIME(), CALLEMP(), CALLPRG());
      END IF;
    END WHILE;

-- ****************************************************************************
  END CASE;
END
