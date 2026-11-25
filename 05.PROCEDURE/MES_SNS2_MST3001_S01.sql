CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`MST3001_S01`(
-- *****************************************************************************
-- Comment: 설비별 사용부품 조회
-- Create: 	2026-11-25  	생성 			한성수
-- Modify: 	2026-11-25 					한성수	설비 목록 조회(설비그룹·설비코드 조건 포함), 선택 설비 출고일자 기간 사용부품 집계
-- *****************************************************************************
  IN $SDATE             VARCHAR(10),   -- 출고 시작일자
  IN $EDATE             VARCHAR(10),   -- 출고 종료일자
  IN $LINECD            VARCHAR(10),   -- 작업장
  IN $EQMTP             VARCHAR(10),   -- 공정(설비구분)
  IN $EQMGROUP1         VARCHAR(10),   -- 라인(설비대분류)
  IN $EQMGRP            VARCHAR(10),   -- 설비그룹
  IN $EQMCD             VARCHAR(50),   -- 조회조건 설비코드
  IN $FANO              VARCHAR(50),   -- 설비번호

-- *****************************************************************************
  IN $CALLTYPE          VARCHAR(50),
  IN $KEYWORD           VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_EQM' THEN -- 설비 목록 조회 (INC 2공장)

    SELECT MSTEQM.LINECD, MSTEQM.EQMTP, MSTEQM.EQMGROUP1, MSTEQM.EQMGUBUN,
           MSTEQM.FANO, MSTEQM.EQMNM
    FROM MSTEQM
    WHERE MSTEQM.USEYN = 'Y'
      AND MSTEQM.FACTORYCD = '07'
      AND ($LINECD = '' OR MSTEQM.LINECD = $LINECD)
      AND ($EQMTP = '' OR MSTEQM.EQMTP = $EQMTP)
      AND ($EQMGROUP1 = '' OR MSTEQM.EQMGROUP1 = $EQMGROUP1)
      AND ($EQMGRP = '' OR MSTEQM.EQMGUBUN = $EQMGRP)
      AND ($EQMCD = '' OR MSTEQM.FANO LIKE CONCAT('%', $EQMCD, '%'))
    ORDER BY MSTEQM.LINECD, MSTEQM.EQMTP, MSTEQM.EQMGROUP1, MSTEQM.FANO;

-- *****************************************************************************

  WHEN 'LIST_PARTS' THEN -- 선택 설비의 출고일자 기간 사용부품 집계 (설비부품 출고 이력)

    SELECT MSTITEM.ITEMCD, MSTITEM.ITEMNM, MSTITEM.ITEMSPEC, MSTITEM.ITEMUNIT,
           OUT_SUM.OUTCNT, OUT_SUM.OUTQTY
    FROM (
      SELECT ITEMID, COUNT(*) AS OUTCNT, CAST(SUM(INOUTQTY) AS DOUBLE) AS OUTQTY
      FROM INOUT_EQMPARTS
      WHERE INOROUT = 'OUT'
        AND EQMCD = $FANO
        AND INOUTDATE BETWEEN $SDATE AND $EDATE
      GROUP BY ITEMID
    ) OUT_SUM
    LEFT JOIN MSTITEM
      ON MSTITEM.ITEMID = OUT_SUM.ITEMID
    ORDER BY MSTITEM.ITEMCD;

-- *****************************************************************************
END CASE;

END
