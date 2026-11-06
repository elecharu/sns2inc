CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.MST1002_R05(
-- *****************************************************************************
-- Comment: 라인정보
-- Create: 2024-02-22 13:50: 김영철
-- Modify: 2026-10-28 18:44: 김영철 라인별 세부공정(MSTLINE_EQM_PRCDETAIL) 관리
--           SEL_LINE_EQM 세부공정 컬럼(PRCDETAILNM), SEL_POP_PRCDETAIL, SAVE_PRCDETAIL 추가
--         2026-11-03: 김영철 라인별 설비 매칭(MSTEQM_MATCH) 관리
--           SEL_LINE_EQM 매칭설비 컬럼(FANONM), SEL_EQMMATCH, SAVE_EQMMATCH(SEQ 라인별 채번), $FANO_LIST 추가
-- *****************************************************************************

  IN $FACTORYCD VARCHAR(20),
  IN $LINECD VARCHAR(20),
  IN $PRCCD VARCHAR(20),
  IN $EQMCD VARCHAR(20),
  IN $USEYN VARCHAR(1),
  IN $CALLTYPE VARCHAR(50),
  IN $KEYWORD VARCHAR(1000),
  IN $PRCDETAIL_LIST MEDIUMTEXT,
  IN $REMARK_LIST MEDIUMTEXT,
  IN $FANO_LIST MEDIUMTEXT
  )
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$PRCDETAIL     VARCHAR(20);
  DECLARE _$REMARK        VARCHAR(1000);
  DECLARE _$PRCDETAIL_ALL MEDIUMTEXT;
  DECLARE _$FANO          VARCHAR(50);
  DECLARE _$FANO_ALL      MEDIUMTEXT;
-- *****************************************************************************

  CASE $CALLTYPE
-- ****************************************************************************

  WHEN 'SEL_LINE_EQM' THEN

    SELECT
      A.USEYN, A.EQMCD, A.EQMNO, A.EQMNM,
      C.FACTORYCD, C.LINECD, C.LINENM,
      GPCD('PRCCD', A.PRCCD) AS PRCNM,
      GPCD('PP135', A.GROUP_BC) AS GROUP_BC,
      A.CCCD,
      A.SDT, A.EDT, A.REMARK, A.SORTNO
      , A.RTIME
      , A.REMP
      , IFNULL(MSTLINE_EQM_PRCDETAIL_GROUP.PRCDETAILNM, '') AS PRCDETAILNM
      , IFNULL(MSTEQM_MATCH_GROUP.FANONM, '') AS FANONM
      FROM MSTLINE_EQM AS A
      INNER JOIN MSTLINE AS C ON A.LINECD = C.LINECD
      LEFT JOIN ( -- 라인별 세부공정을 공통코드 순번대로 한 칸에 (OP10, OP20, OP30 ...)
        SELECT MSTLINE_EQM_PRCDETAIL.EQMCD,
               GROUP_CONCAT(IFNULL(COMTYPE.TPNM, MSTLINE_EQM_PRCDETAIL.PRCDETAIL)
                            ORDER BY COMTYPE.SORTNO, MSTLINE_EQM_PRCDETAIL.PRCDETAIL
                            SEPARATOR ', ') AS PRCDETAILNM
          FROM MSTLINE_EQM_PRCDETAIL
          LEFT JOIN COMTYPE
                 ON COMTYPE.GPCD = 'PRCDETAIL'
                AND COMTYPE.TPCD = MSTLINE_EQM_PRCDETAIL.PRCDETAIL
         GROUP BY MSTLINE_EQM_PRCDETAIL.EQMCD
      ) AS MSTLINE_EQM_PRCDETAIL_GROUP ON MSTLINE_EQM_PRCDETAIL_GROUP.EQMCD = A.EQMCD
      LEFT JOIN ( -- 라인에 매칭된 설비를 설비번호 순으로 한 칸에
        SELECT MSTEQM_MATCH.EQMCD,
               GROUP_CONCAT(IFNULL(MSTEQM.EQMNM, MSTEQM_MATCH.FANO)
                            ORDER BY MSTEQM_MATCH.FANO
                            SEPARATOR ', ') AS FANONM
          FROM MSTEQM_MATCH
          LEFT JOIN MSTEQM ON MSTEQM.FANO = MSTEQM_MATCH.FANO
         GROUP BY MSTEQM_MATCH.EQMCD
      ) AS MSTEQM_MATCH_GROUP ON MSTEQM_MATCH_GROUP.EQMCD = A.EQMCD
      WHERE C.FACTORYCD LIKE CONCAT('%', $FACTORYCD, '%')
        AND A.LINECD LIKE CONCAT('%', $LINECD, '%')
        AND A.PRCCD LIKE CONCAT('%', $PRCCD, '%')
        AND A.USEYN = $USEYN
      ORDER BY C.FACTORYCD, C.LINECD, A.PRCCD, A.EQMCD;

-- ****************************************************************************

  WHEN 'SEL_POP_PRCDETAIL' THEN -- 세부공정 관리 팝업: 전체 세부공정, 그 라인에 등록된 것은 체크

    SELECT COMTYPE.TPCD AS PRCDETAIL,
           COMTYPE.TPNM AS PRCDETAILNM,
           IFNULL(MSTLINE_EQM_PRCDETAIL.REMARK, '') AS REMARK,
           IF(MSTLINE_EQM_PRCDETAIL.EQMCD IS NULL, 'N', 'Y') AS isRowCheck
      FROM COMTYPE
      LEFT JOIN MSTLINE_EQM_PRCDETAIL
             ON MSTLINE_EQM_PRCDETAIL.EQMCD = $EQMCD
            AND MSTLINE_EQM_PRCDETAIL.PRCDETAIL = COMTYPE.TPCD
     WHERE COMTYPE.GPCD = 'PRCDETAIL'
       AND (COMTYPE.USEYN = 'Y' OR MSTLINE_EQM_PRCDETAIL.EQMCD IS NOT NULL)
     ORDER BY COMTYPE.SORTNO, COMTYPE.TPCD;

-- ****************************************************************************

  WHEN 'SAVE_PRCDETAIL' THEN -- 세부공정 관리 저장: 넘어온(체크한) 세부공정은 등록·비고 수정, 빠진 세부공정은 삭제

    IF IFNULL($EQMCD, '') = '' THEN
      CALL COMERR('라인을 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 체크를 푼 세부공정 삭제 (리스트는 'OP10»OP20»' 형태라 앞에 » 를 붙여 '»코드»' 로 비교)
    SET _$PRCDETAIL_ALL = CONCAT('»', IFNULL($PRCDETAIL_LIST, ''));

    DELETE FROM MSTLINE_EQM_PRCDETAIL
     WHERE MSTLINE_EQM_PRCDETAIL.EQMCD = $EQMCD
       AND _$PRCDETAIL_ALL NOT LIKE CONCAT('%»', MSTLINE_EQM_PRCDETAIL.PRCDETAIL, '»%');

    WHILE LENGTH($PRCDETAIL_LIST) > 0 DO
      CALL COMSPLIT($PRCDETAIL_LIST, _$PRCDETAIL);
      CALL COMSPLIT($REMARK_LIST, _$REMARK);

      SET _$PRCDETAIL = TRIM(IFNULL(_$PRCDETAIL, ''));
      SET _$REMARK = IFNULL(_$REMARK, '');

      IF NOT EXISTS (SELECT 1 FROM MSTLINE_EQM_PRCDETAIL
                      WHERE MSTLINE_EQM_PRCDETAIL.EQMCD = $EQMCD
                        AND MSTLINE_EQM_PRCDETAIL.PRCDETAIL = _$PRCDETAIL) THEN
        INSERT INTO MSTLINE_EQM_PRCDETAIL
          (EQMCD, PRCDETAIL, REMARK, RTIME, REMP, RPRG)
        VALUES
          ($EQMCD, _$PRCDETAIL, _$REMARK, CALLTIME(), CALLEMP(), CALLPRG());
      ELSE
        UPDATE MSTLINE_EQM_PRCDETAIL
           SET MSTLINE_EQM_PRCDETAIL.REMARK = _$REMARK
             , MTIME = CALLTIME()
             , MEMP = CALLEMP()
             , MPRG = CALLPRG()
         WHERE MSTLINE_EQM_PRCDETAIL.EQMCD = $EQMCD
           AND MSTLINE_EQM_PRCDETAIL.PRCDETAIL = _$PRCDETAIL
           AND IFNULL(MSTLINE_EQM_PRCDETAIL.REMARK, '') <> _$REMARK;
      END IF;
    END WHILE;

-- ****************************************************************************

  WHEN 'SEL_EQMMATCH' THEN -- 라인별 설비매칭(오른쪽 그리드): 그 라인과 같은 작업장의 설비, 그 라인에 매칭된 것은 체크

    SELECT MSTEQM.FANO,
           MSTEQM.EQMNM,
           MSTLINE.LINENM,
           IF(MSTEQM_MATCH.EQMCD IS NULL, 'N', 'Y') AS isRowCheck
      FROM MSTEQM
      LEFT JOIN MSTLINE ON MSTLINE.LINECD = MSTEQM.LINECD
      LEFT JOIN MSTEQM_MATCH
             ON MSTEQM_MATCH.EQMCD = $EQMCD
            AND MSTEQM_MATCH.FANO = MSTEQM.FANO
     WHERE (MSTEQM.USEYN = 'Y'
            AND MSTEQM.LINECD = (SELECT MSTLINE_EQM.LINECD FROM MSTLINE_EQM
                                  WHERE MSTLINE_EQM.EQMCD = $EQMCD LIMIT 1))
        OR MSTEQM_MATCH.EQMCD IS NOT NULL -- 작업장이 달라도 이미 매칭된 설비는 보여준다
     ORDER BY MSTEQM.FANO;

-- ****************************************************************************

  WHEN 'SAVE_EQMMATCH' THEN -- 설비 매칭 저장: 넘어온(체크한) 설비는 매칭 등록, 빠진 설비는 매칭 삭제

    IF IFNULL($EQMCD, '') = '' THEN
      CALL COMERR('라인을 선택해주세요.');
      LEAVE PROC;
    END IF;

    -- 체크를 푼 설비 삭제 (리스트는 'FA01»FA02»' 형태라 앞에 » 를 붙여 '»코드»' 로 비교)
    SET _$FANO_ALL = CONCAT('»', IFNULL($FANO_LIST, ''));

    DELETE FROM MSTEQM_MATCH
     WHERE MSTEQM_MATCH.EQMCD = $EQMCD
       AND _$FANO_ALL NOT LIKE CONCAT('%»', MSTEQM_MATCH.FANO, '»%');

    WHILE LENGTH($FANO_LIST) > 0 DO
      CALL COMSPLIT($FANO_LIST, _$FANO);

      SET _$FANO = TRIM(IFNULL(_$FANO, ''));

      IF NOT EXISTS (SELECT 1 FROM MSTEQM_MATCH
                      WHERE MSTEQM_MATCH.EQMCD = $EQMCD
                        AND MSTEQM_MATCH.FANO = _$FANO) THEN
        -- PK 가 (EQMCD, SEQ) 라 라인별 마지막 순번 + 1 로 채번
        INSERT INTO MSTEQM_MATCH
          (EQMCD, SEQ, FANO, RTIME, REMP, RPRG)
        SELECT $EQMCD, IFNULL(MAX(MSTEQM_MATCH.SEQ), 0) + 1, _$FANO, CALLTIME(), CALLEMP(), CALLPRG()
          FROM MSTEQM_MATCH
         WHERE MSTEQM_MATCH.EQMCD = $EQMCD;
      END IF;
    END WHILE;

-- ****************************************************************************
  END CASE;
END
