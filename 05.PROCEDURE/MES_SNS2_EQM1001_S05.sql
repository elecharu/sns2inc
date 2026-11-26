CREATE DEFINER=`root`@`%`
PROCEDURE `MES_SNS2`.`EQM1001_S05`(
-- *****************************************************************************
-- Comment: 설비고장율 현황
-- Create: 	2026-11-25  	생성 			한성수
-- Modify: 	2026-11-25 					한성수	라인 연간 고장 목표대비 달성(호출 수리시간 / 매칭 생산라인 작업시간, 겹치는 작업시간 1회)
-- 			2026-11-26 					한성수	차트 축 기준용 월 가동시간(WORKHR) 반환, 평균을 가동시간 있는 달 기준으로 변경, 설비별 고장 현황(LIST_EQM_FAIL)·설비별 고장부위 현황(LIST_EQM_PART) 추가
-- *****************************************************************************
  IN $SYEAR             VARCHAR(4),    -- 조회년도
  IN $LINECD            VARCHAR(10),   -- 작업장
  IN $EQMTP             VARCHAR(10),   -- 공정(설비구분)
  IN $EQMGROUP1         VARCHAR(10),   -- 라인(설비대분류)

-- *****************************************************************************
  IN $CALLTYPE          VARCHAR(50),
  IN $KEYWORD           VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$NOWYM       VARCHAR(7);
  DECLARE _$LASTMM      INT;            -- 집계 마지막 월 (지난 해 12월, 올해 이번 달)
  DECLARE _$TITLE       VARCHAR(200);
  DECLARE _$SUMNON      DECIMAL(20, 2);
  DECLARE _$SUMWORK     DECIMAL(20, 2);
  DECLARE _$MMCNT       INT;

  -- 차트 공통: 조회년도·라인 확인, 선택 라인 설비, 라인 월별 가동시간(점유율 차트만)
  IF $CALLTYPE IN ('LIST_CHART', 'LIST_EQM_FAIL', 'LIST_EQM_PART') THEN
    IF IFNULL($SYEAR, '') NOT REGEXP '^[0-9]{4}$' THEN
      CALL COMERR('조회년도를 선택하세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL($LINECD, '') = '' OR IFNULL($EQMTP, '') = '' OR IFNULL($EQMGROUP1, '') = '' THEN
      CALL COMERR('작업장·공정·라인을 선택하세요.');
      LEAVE PROC;
    END IF;

    SET _$TITLE = CONCAT($SYEAR, '년 ', IFNULL((SELECT LINENM FROM MSTLINE WHERE LINECD = $LINECD LIMIT 1), $LINECD), ' ',
                         GPCD('FM100', $EQMTP), ' ', GPCD('FM113', $EQMGROUP1));

    -- 선택 라인의 설비 (2공장 사용 설비)
    DROP TEMPORARY TABLE IF EXISTS TMP_EQM;
    CREATE TEMPORARY TABLE TMP_EQM (
      FANO     VARCHAR(50)  NOT NULL,
      PRIMARY KEY (FANO)
    );

    INSERT INTO TMP_EQM (FANO)
    SELECT FANO
    FROM MSTEQM
    WHERE FACTORYCD = '07'
      AND USEYN = 'Y'
      AND LINECD = $LINECD
      AND EQMTP = $EQMTP
      AND EQMGROUP1 = $EQMGROUP1;
  END IF;

  IF $CALLTYPE IN ('LIST_CHART', 'LIST_EQM_FAIL') THEN
    -- 라인 월별 가동(분): 선택 라인 설비에 매칭된 생산라인(MSTEQM_MATCH)의 작업시작~작업종료, 같은 생산라인에서 겹치는 작업시간은 한 번만, 작업일자 월 기준
    DROP TEMPORARY TABLE IF EXISTS TMP_WORK;
    CREATE TEMPORARY TABLE TMP_WORK (
      MM       INT            NOT NULL,
      WORKMIN  DECIMAL(20, 2) NOT NULL,
      PRIMARY KEY (MM)
    );

    INSERT INTO TMP_WORK (MM, WORKMIN)
    SELECT MONTH(WORK_SPAN.WORKDATE),
           SUM(TIMESTAMPDIFF(MINUTE, WORK_SPAN.SPANSTIME, WORK_SPAN.SPANETIME))
    FROM (
      -- 겹치는 작업끼리 묶은 가동 구간 (첫 작업시작 ~ 가장 늦은 작업종료)
      SELECT WORK_GRP.EQMCD, WORK_GRP.GRPNO, MIN(WORK_GRP.WORKDATE) AS WORKDATE,
             MIN(WORK_GRP.WORKSTIME) AS SPANSTIME, MAX(WORK_GRP.WORKETIME) AS SPANETIME
      FROM (
        -- 앞 작업들의 가장 늦은 작업종료보다 늦게 시작하면 새 구간
        SELECT WORK_ORD.EQMCD, WORK_ORD.WORKDATE, WORK_ORD.WORKSTIME, WORK_ORD.WORKETIME,
               SUM(IF(WORK_ORD.PREVETIME IS NULL OR WORK_ORD.WORKSTIME > WORK_ORD.PREVETIME, 1, 0))
                 OVER (PARTITION BY WORK_ORD.EQMCD ORDER BY WORK_ORD.WORKSTIME, WORK_ORD.WORKETIME, WORK_ORD.PRDWORKKEY) AS GRPNO
        FROM (
          SELECT PRDWORK.EQMCD, PRDWORK.PRDWORKKEY, PRDWORK.WORKDATE, PRDWORK.WORKSTIME, PRDWORK.WORKETIME,
                 MAX(PRDWORK.WORKETIME) OVER (PARTITION BY PRDWORK.EQMCD ORDER BY PRDWORK.WORKSTIME, PRDWORK.WORKETIME, PRDWORK.PRDWORKKEY
                                             ROWS BETWEEN UNBOUNDED PRECEDING AND 1 PRECEDING) AS PREVETIME
          FROM PRDWORK
          INNER JOIN (
            SELECT MSTEQM_MATCH.EQMCD
            FROM MSTEQM_MATCH
            INNER JOIN TMP_EQM
              ON TMP_EQM.FANO = MSTEQM_MATCH.FANO
            GROUP BY MSTEQM_MATCH.EQMCD
          ) PRD_LINE
            ON PRD_LINE.EQMCD = PRDWORK.EQMCD
          WHERE PRDWORK.WORKDATE BETWEEN CONCAT($SYEAR, '-01-01') AND CONCAT($SYEAR, '-12-31')
            AND PRDWORK.WORKETIME > PRDWORK.WORKSTIME
        ) WORK_ORD
      ) WORK_GRP
      GROUP BY WORK_GRP.EQMCD, WORK_GRP.GRPNO
    ) WORK_SPAN
    GROUP BY MONTH(WORK_SPAN.WORKDATE);
  END IF;

-- *****************************************************************************
CASE $CALLTYPE
-- *****************************************************************************

  WHEN 'LIST_CHART' THEN -- 라인 연간 고장 목표대비 달성 (비가동 = 호출 수리시작~수리종료, 가동 = 매칭 생산라인 작업시작~작업종료)

    SET _$NOWYM = LEFT(CALLTIME(), 7);
    SET _$LASTMM = CASE WHEN $SYEAR < LEFT(_$NOWYM, 4) THEN 12
                        WHEN $SYEAR = LEFT(_$NOWYM, 4) THEN CAST(RIGHT(_$NOWYM, 2) AS UNSIGNED)
                        ELSE 0 END;

    -- 차트 행 (0 목표, 1 평균, 2~13 = 1~12월, 목표 값은 화면에서 표시), 집계 마지막 월까지만 값 0부터 시작
    DROP TEMPORARY TABLE IF EXISTS TMP_MONTH;
    CREATE TEMPORARY TABLE TMP_MONTH (
      SORTNO   INT            NOT NULL,
      MM       INT            NOT NULL,
      GUBUN    VARCHAR(20)    NOT NULL,
      NONMIN   DECIMAL(20, 2) NULL,
      WORKMIN  DECIMAL(20, 2) NULL,
      PRIMARY KEY (SORTNO)
    );

    INSERT INTO TMP_MONTH (SORTNO, MM, GUBUN) VALUES
      (0, 0, CONCAT(RIGHT($SYEAR, 2), '년 목표')), (1, 0, CONCAT(RIGHT($SYEAR, 2), '년 평균')),
      (2, 1, '1월'), (3, 2, '2월'), (4, 3, '3월'), (5, 4, '4월'), (6, 5, '5월'), (7, 6, '6월'),
      (8, 7, '7월'), (9, 8, '8월'), (10, 9, '9월'), (11, 10, '10월'), (12, 11, '11월'), (13, 12, '12월');

    UPDATE TMP_MONTH
    SET NONMIN = 0, WORKMIN = 0
    WHERE SORTNO >= 2
      AND MM <= _$LASTMM;

    -- 월별 비가동(분): 선택 라인 설비의 호출 수리 중 수리종료된 건, 수리시작 월 기준
    UPDATE TMP_MONTH
    INNER JOIN (
      SELECT MONTH(EQMREP.REPSTIME) AS MM,
             SUM(TIMESTAMPDIFF(MINUTE, EQMREP.REPSTIME, EQMREP.REPETIME)) AS NONMIN
      FROM EQMREP
      INNER JOIN TMP_EQM
        ON TMP_EQM.FANO = EQMREP.EQMCD
      WHERE EQMREP.EQMREPTP = 'EQM01'
        AND EQMREP.EQMCALLKEY <> ''
        AND EQMREP.REPETIME <> ''
        AND EQMREP.REPETIME >= EQMREP.REPSTIME
        AND EQMREP.REPSTIME >= CONCAT($SYEAR, '-01-01')
        AND EQMREP.REPSTIME < CONCAT($SYEAR + 1, '-01-01')
      GROUP BY MONTH(EQMREP.REPSTIME)
    ) NON_SUM
      ON NON_SUM.MM = TMP_MONTH.MM
    SET TMP_MONTH.NONMIN = NON_SUM.NONMIN
    WHERE TMP_MONTH.SORTNO >= 2;

    -- 월별 가동(분): 라인 월별 가동시간
    UPDATE TMP_MONTH
    INNER JOIN TMP_WORK
      ON TMP_WORK.MM = TMP_MONTH.MM
    SET TMP_MONTH.WORKMIN = TMP_WORK.WORKMIN
    WHERE TMP_MONTH.SORTNO >= 2;

    -- 평균: 가동시간이 있는 달의 월 평균 (점유율 = 그 달들의 합계 비가동 / 합계 가동)
    SELECT SUM(NONMIN), SUM(WORKMIN), COUNT(*)
      INTO _$SUMNON, _$SUMWORK, _$MMCNT
    FROM TMP_MONTH
    WHERE SORTNO >= 2
      AND WORKMIN > 0;

    UPDATE TMP_MONTH
    SET NONMIN  = IF(_$MMCNT > 0, _$SUMNON / _$MMCNT, NULL),
        WORKMIN = IF(_$MMCNT > 0, _$SUMWORK / _$MMCNT, NULL)
    WHERE SORTNO = 1;

    SELECT GUBUN,
           CAST(ROUND(NONMIN / 60, 1) AS DOUBLE) AS NONHR,
           CAST(IF(WORKMIN > 0, ROUND(NONMIN / WORKMIN * 100, 2), NULL) AS DOUBLE) AS NONRATE,
           CAST(ROUND(WORKMIN / 60, 1) AS DOUBLE) AS WORKHR,
           CONCAT(_$TITLE, ' 설비 고장율 현황') AS TITLE
    FROM TMP_MONTH
    ORDER BY SORTNO;

    DROP TEMPORARY TABLE IF EXISTS TMP_MONTH;
    DROP TEMPORARY TABLE IF EXISTS TMP_WORK;
    DROP TEMPORARY TABLE IF EXISTS TMP_EQM;

-- *****************************************************************************

  WHEN 'LIST_EQM_FAIL' THEN -- 라인 설비별 고장 현황 (설비 = 공무작업일지 작성 수리, 총 라인 = 호출 수리, 점유율 = 조회년도 라인 총가동시간 대비)

    SET _$SUMWORK = (SELECT SUM(WORKMIN) FROM TMP_WORK);

    -- 총 라인 고장시간(분): 선택 라인 설비의 호출 수리 중 수리종료된 건
    SELECT IFNULL(SUM(TIMESTAMPDIFF(MINUTE, EQMREP.REPSTIME, EQMREP.REPETIME)), 0)
      INTO _$SUMNON
    FROM EQMREP
    INNER JOIN TMP_EQM
      ON TMP_EQM.FANO = EQMREP.EQMCD
    WHERE EQMREP.EQMREPTP = 'EQM01'
      AND EQMREP.EQMCALLKEY <> ''
      AND EQMREP.REPETIME <> ''
      AND EQMREP.REPETIME >= EQMREP.REPSTIME
      AND EQMREP.REPSTIME >= CONCAT($SYEAR, '-01-01')
      AND EQMREP.REPSTIME < CONCAT($SYEAR + 1, '-01-01');

    -- 설비별 비가동(분): 공무작업일지를 작성한 수리(EQMREP.WORKTP 있음) 중 수리종료된 건, 총 라인 값은 행마다 같이 반환
    SELECT CONCAT(MSTEQM.EQMNM, CHAR(10), MSTEQM.FANO) AS GUBUN,
           CAST(ROUND(IFNULL(EQM_SUM.NONMIN, 0) / 60, 1) AS DOUBLE) AS NONHR,
           CAST(IF(_$SUMWORK > 0, ROUND(IFNULL(EQM_SUM.NONMIN, 0) / _$SUMWORK * 100, 2), NULL) AS DOUBLE) AS NONRATE,
           CAST(ROUND(_$SUMNON / 60, 1) AS DOUBLE) AS LINENONHR,
           CAST(IF(_$SUMWORK > 0, ROUND(_$SUMNON / _$SUMWORK * 100, 2), NULL) AS DOUBLE) AS LINENONRATE,
           CAST(ROUND(_$SUMWORK / 60, 1) AS DOUBLE) AS WORKHR,
           CONCAT(_$TITLE, ' 설비별 고장 현황') AS TITLE
    FROM MSTEQM
    LEFT JOIN (
      SELECT EQMREP.EQMCD,
             SUM(TIMESTAMPDIFF(MINUTE, EQMREP.REPSTIME, EQMREP.REPETIME)) AS NONMIN
      FROM EQMREP
      INNER JOIN TMP_EQM
        ON TMP_EQM.FANO = EQMREP.EQMCD
      WHERE EQMREP.EQMREPTP = 'EQM01'
        AND EQMREP.WORKTP <> ''
        AND EQMREP.REPETIME <> ''
        AND EQMREP.REPETIME >= EQMREP.REPSTIME
        AND EQMREP.REPSTIME >= CONCAT($SYEAR, '-01-01')
        AND EQMREP.REPSTIME < CONCAT($SYEAR + 1, '-01-01')
      GROUP BY EQMREP.EQMCD
    ) EQM_SUM
      ON EQM_SUM.EQMCD = MSTEQM.FANO
    WHERE MSTEQM.FACTORYCD = '07'
      AND MSTEQM.USEYN = 'Y'
      AND MSTEQM.LINECD = $LINECD
      AND MSTEQM.EQMTP = $EQMTP
      AND MSTEQM.EQMGROUP1 = $EQMGROUP1
    ORDER BY MSTEQM.FANO;

    DROP TEMPORARY TABLE IF EXISTS TMP_WORK;
    DROP TEMPORARY TABLE IF EXISTS TMP_EQM;

-- *****************************************************************************

  WHEN 'LIST_EQM_PART' THEN -- 라인·설비별 고장부위 현황 (공무작업일지 작성 수리의 고장부위별 수리시간, 비중 = 라인 또는 설비 고장시간 대비)

    -- 설비·고장부위별 수리시간(분): 공무작업일지를 작성한 수리(EQMREP.WORKTP 있음) 중 수리종료된 건, 고장부위 없으면 ''
    DROP TEMPORARY TABLE IF EXISTS TMP_PART;
    CREATE TEMPORARY TABLE TMP_PART (
      FANO     VARCHAR(100)   NOT NULL,
      FAILPART VARCHAR(20)    NOT NULL,
      PARTMIN  DECIMAL(20, 2) NOT NULL,
      PRIMARY KEY (FANO, FAILPART)
    );

    INSERT INTO TMP_PART (FANO, FAILPART, PARTMIN)
    SELECT EQMREP.EQMCD, EQMREP.FAILPART,
           SUM(TIMESTAMPDIFF(MINUTE, EQMREP.REPSTIME, EQMREP.REPETIME))
    FROM EQMREP
    INNER JOIN TMP_EQM
      ON TMP_EQM.FANO = EQMREP.EQMCD
    WHERE EQMREP.EQMREPTP = 'EQM01'
      AND EQMREP.WORKTP <> ''
      AND EQMREP.REPETIME <> ''
      AND EQMREP.REPETIME >= EQMREP.REPSTIME
      AND EQMREP.REPSTIME >= CONCAT($SYEAR, '-01-01')
      AND EQMREP.REPSTIME < CONCAT($SYEAR + 1, '-01-01')
    GROUP BY EQMREP.EQMCD, EQMREP.FAILPART;

    SET _$SUMNON = (SELECT SUM(PARTMIN) FROM TMP_PART);

    -- 1) 총 라인: 고장부위별 수리시간과 라인 고장시간 대비 비중(%)
    SELECT FAILPART,
           IF(FAILPART = '', '고장부위 미입력', GPCD('FM303', FAILPART)) AS FAILPARTNM,
           CAST(SUM(PARTMIN) AS SIGNED) AS PARTMIN,
           CAST(ROUND(SUM(PARTMIN) / 60, 1) AS DOUBLE) AS PARTHR,
           CAST(ROUND(SUM(PARTMIN) / _$SUMNON * 100, 1) AS DOUBLE) AS PARTRATE,
           CAST(ROUND(_$SUMNON / 60, 1) AS DOUBLE) AS TOTHR
    FROM TMP_PART
    WHERE PARTMIN > 0
    GROUP BY FAILPART
    ORDER BY FAILPART = '', FAILPART;

    -- 2) 설비별: 라인 설비 전체(이력 없는 설비는 고장부위 빈 행 1개), 고장부위별 수리시간과 설비 고장시간 대비 비중(%)
    SELECT MSTEQM.FANO, MSTEQM.EQMNM, PART_SUM.FAILPART,
           IF(PART_SUM.FAILPART = '', '고장부위 미입력', GPCD('FM303', PART_SUM.FAILPART)) AS FAILPARTNM,
           CAST(PART_SUM.PARTMIN AS SIGNED) AS PARTMIN,
           CAST(ROUND(PART_SUM.PARTMIN / 60, 1) AS DOUBLE) AS PARTHR,
           CAST(ROUND(PART_SUM.PARTMIN / PART_SUM.EQMMIN * 100, 1) AS DOUBLE) AS PARTRATE,
           CAST(ROUND(PART_SUM.EQMMIN / 60, 1) AS DOUBLE) AS TOTHR,
           CONCAT(_$TITLE, ' 설비별 고장부위 현황') AS TITLE
    FROM MSTEQM
    LEFT JOIN (
      SELECT FANO, FAILPART, PARTMIN,
             SUM(PARTMIN) OVER (PARTITION BY FANO) AS EQMMIN
      FROM TMP_PART
      WHERE PARTMIN > 0
    ) PART_SUM
      ON PART_SUM.FANO = MSTEQM.FANO
    WHERE MSTEQM.FACTORYCD = '07'
      AND MSTEQM.USEYN = 'Y'
      AND MSTEQM.LINECD = $LINECD
      AND MSTEQM.EQMTP = $EQMTP
      AND MSTEQM.EQMGROUP1 = $EQMGROUP1
    ORDER BY MSTEQM.FANO, PART_SUM.FAILPART = '', PART_SUM.FAILPART;

    DROP TEMPORARY TABLE IF EXISTS TMP_PART;
    DROP TEMPORARY TABLE IF EXISTS TMP_EQM;

-- *****************************************************************************
END CASE;

END
