CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.PRD9001_R02(
-- *****************************************************************************
-- Comment: 근무시간 관리
-- Create: 2024-01-19 11:55: 김영철
-- Modify: 2024-06-14 15:40: 박제홍      주간, 야간 연장근무시간 추가 (주간:180분, 야간:150분), 금토요일은 연장근무 0 기본값
--         2024-06-24 15:30: 박제홍      월~목 주간연장(180) 야간연장(150) / 금 주간연장(0), 야간연장(120) / 토 주간연장(0) 야간연장(150)
--         2025-09-02 17:00: 박제홍      
-- *****************************************************************************
  IN $WORKDATE  VARCHAR(10),
  IN $PRCCD     VARCHAR(20),
  IN $EQMCD     VARCHAR(20),
  IN $DAYTIME   DECIMAL(20, 0),
  IN $NIGHTTIME DECIMAL(20, 0),
  IN $OVERTIME_DY  DECIMAL(20, 0),
  IN $OVERTIME_NT  DECIMAL(20, 0),
  IN $HOLIDAY   VARCHAR(1),
  IN $BDVCD     VARCHAR(20),
  IN $REMARK    VARCHAR(1000),
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_WORKTIME' THEN -- 월 근무시간 조회 

  SELECT
    'A' AS SORT,
    HMP.YMD AS YMD,
    CONCAT(IF(HMP.REMARK = '', '', CONCAT(HMP.REMARK, ' / ')),  GPCD('DILIGCD', HMP.DILIGCD)) AS CONTENT,
    CASE HMP.DILIGCD
      WHEN '130' THEN 'IndianRed'
      WHEN '310' THEN 'IndianRed'
      WHEN '320' THEN 'Theme'
      WHEN '410' THEN 'Purple'
      WHEN '420' THEN 'Green'
    END AS BACKGROUND,
    CASE HMP.DILIGCD
      WHEN '130' THEN 'IndianRed'
      WHEN '310' THEN 'IndianRed' 
      WHEN '320' THEN 'Theme'
      WHEN '410' THEN 'Purple'
      WHEN '420' THEN 'Green'
    END AS BORDER,
    'White' AS TEXTCOLOR
    FROM HRMMONTHPLAN AS HMP
    WHERE HMP.YMD BETWEEN CONCAT(LEFT($WORKDATE, 7), '-01') AND LAST_DAY(CONCAT(LEFT($WORKDATE, 7), '-01'))
  UNION ALL
  SELECT
    'B' AS SORT,
    WORKDATE AS YMD,    CONCAT('주간 : ', MAX(DAYTIME)) AS CONTENT,    '#2c437b' AS BACKGROUND,    '#2c437b' AS BORDER,    '' AS TEXTCOLOR
    FROM PRDWORKTIME
    WHERE WORKDATE BETWEEN CONCAT(LEFT($WORKDATE, 7), '-01') AND LAST_DAY(CONCAT(LEFT($WORKDATE, 7), '-01'))
    GROUP BY WORKDATE
  UNION ALL
  SELECT
    'C' AS SORT,
    WORKDATE AS YMD,    CONCAT('야간 : ', MAX(NIGHTTIME)) AS CONTENT,  '#2c437b' AS BACKGROUND,    '#2c437b' AS BORDER,    '' AS TEXTCOLOR
    FROM PRDWORKTIME
    WHERE WORKDATE BETWEEN CONCAT(LEFT($WORKDATE, 7), '-01') AND LAST_DAY(CONCAT(LEFT($WORKDATE, 7), '-01'))
    GROUP BY WORKDATE
  UNION ALL
  SELECT
    'D' AS SORT,
    WORKDATE AS YMD,    CONCAT('주간연장 : ', MAX(OVERTIME_DY)) AS CONTENT,   '#2c437b' AS BACKGROUND,    '#2c437b' AS BORDER,    '' AS TEXTCOLOR
    FROM PRDWORKTIME
    WHERE WORKDATE BETWEEN CONCAT(LEFT($WORKDATE, 7), '-01') AND LAST_DAY(CONCAT(LEFT($WORKDATE, 7), '-01'))
    GROUP BY WORKDATE
  UNION ALL
  SELECT
    'E' AS SORT,
    WORKDATE AS YMD,    CONCAT('야간연장 : ', MAX(OVERTIME_NT)) AS CONTENT,   '#2c437b' AS BACKGROUND,    '#2c437b' AS BORDER,    '' AS TEXTCOLOR
    FROM PRDWORKTIME
    WHERE WORKDATE BETWEEN CONCAT(LEFT($WORKDATE, 7), '-01') AND LAST_DAY(CONCAT(LEFT($WORKDATE, 7), '-01'))
    GROUP BY WORKDATE;

-- ****************************************************************************
WHEN 'GET_WORKTIME' THEN

  SELECT $WORKDATE AS WORKDATE, MAX(DAYTIME) AS DAYTIME, 
         MAX(NIGHTTIME) AS NIGHTTIME, 
         MAX(OVERTIME_DY) AS OVERTIME_DY,
         MAX(OVERTIME_NT) AS OVERTIME_NT
    FROM PRDWORKTIME
   WHERE PRDWORKTIME.WORKDATE = $WORKDATE;

-- ****************************************************************************
WHEN 'UP_WORKTIME' THEN

  UPDATE PRDWORKTIME SET
    DAYTIME   = $DAYTIME,
    NIGHTTIME = $NIGHTTIME,
    OVERTIME_DY = $OVERTIME_DY,
    OVERTIME_NT = $OVERTIME_NT,
    HOLIDAY   = $HOLIDAY,
    REMARK    = $REMARK,
    MTIME     = CALLTIME(),
    MEMP      = CALLEMP(),
    MPRG      = CALLPRG()
    WHERE WORKDATE = $WORKDATE
  ;

-- ****************************************************************************
WHEN 'SET_WORKTIME' THEN  -- 근무시간 일괄등록 

  INSERT INTO PRDWORKTIME (
    WORKDATE,
    DAYTIME, NIGHTTIME, OVERTIME_DY, OVERTIME_NT, 
    HOLIDAY, BDVCD,
    REMARK, RTIME, REMP, RPRG
  )
  SELECT
    WORKTIME.DT,
    CASE WHEN WORKTIME.DAY = '일요일' THEN 0 ELSE 480 END AS DAYTIME,
    CASE WHEN WORKTIME.DAY = '일요일' THEN 0 ELSE 480 END AS NIGHTTIME,
    CASE 
      WHEN WORKTIME.DAY = '일요일' THEN 0
      ELSE 60
    END AS OVERTIME_DY,
    CASE 
      WHEN WORKTIME.DAY = '일요일' THEN 0
      ELSE 60
    END AS OVERTIME_NT,
    WORKTIME.HOLYYN, 'A',
    '', CALLTIME(), CALLEMP(), CALLPRG()
    FROM (
            SELECT 
              DAY.DT, 
              DAY.HOLYYN,
              GETDAYOFWEEK(DAY.DT) AS DAY
            FROM (
                    SELECT A.DT,
                    CASE WHEN H.DILIGCD IN('130', '310') THEN 'Y' ELSE 'N' END AS HOLYYN
                    FROM (
                            SELECT  
                              LAST_DAY(CONCAT($WORKDATE, '-01')) - INTERVAL (a.a + (10 * b.a) + (100 * c.a)) DAY AS DT
                            FROM (SELECT 0 AS a 
                                  UNION ALL SELECT 1 
                                  UNION ALL SELECT 2 
                                  UNION ALL SELECT 3 
                                  UNION ALL SELECT 4 
                                  UNION ALL SELECT 5 
                                  UNION ALL SELECT 6 
                                  UNION ALL SELECT 7 
                                  UNION ALL SELECT 8 
                                  UNION ALL SELECT 9
                            ) AS a
                            CROSS JOIN (SELECT 0 as a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
                            ) AS b
                            CROSS JOIN (SELECT 0 as a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
                            ) AS c
                    ) AS A
                    LEFT JOIN HRMMONTHPLAN  AS H 
                      ON A.DT = H.YMD
                    WHERE A.DT BETWEEN CONCAT($WORKDATE, '-01') 
                      AND LAST_DAY(CONCAT($WORKDATE, '-01'))
            ) AS DAY
    ) AS WORKTIME
  ON DUPLICATE KEY UPDATE
    MTIME = CALLTIME();

-- ****************************************************************************

END CASE; END