CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.SYS0001_R03(
-- *****************************************************************************
-- Comment: 메뉴관리
-- Create: 2025-03-27 이대규
-- Modify: 2026-11-16  현장프로그램 메뉴타일 색(SYSPRG.TILECOLOR)·아이콘(SYSPRG.TILEICON) 추가

-- *****************************************************************************
 IN $PKGTP VARCHAR(10), -- 패키지
 IN $CATECD VARCHAR(20),
 IN $PRGCD VARCHAR(20),
 IN $MENUNM VARCHAR(100),
 IN $PRGSTT VARCHAR(20),
 IN $SORTNO DECIMAL(20, 0),
 IN $DEV VARCHAR(20),
 IN $ORI VARCHAR(20),
 IN $ORIPRGCD VARCHAR(20),
 IN $ORIPRGNM VARCHAR(100),
 IN $REMARK VARCHAR(1000),
 IN $TILECOLOR VARCHAR(20), -- 현장 메뉴타일 색 (공통코드 TMLCOLOR)
 IN $TILEICON VARCHAR(20),  -- 현장 메뉴타일 아이콘 (공통코드 TMLICON)
-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

-- DECLARE _$V01 VARCHAR(1000);

-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_WEBPKG' THEN

  SELECT
    P.PKGTP, CONCAT(K.PKGNM)AS GRP,
    M.CATECD, C.CATENM, M.PRGCD, M.MENUNM, M.SORTNO, 
    P.RATE, P.STRDT, P.ENDDT,
    P.PRGSTT, P.DEV, P.ORI, P.ORIPRGCD, P.ORIPRGNM,
    P.REMARK,
    P.TILECOLOR, P.TILEICON,
    CASE
      WHEN P.PRGSTT = '50' THEN 'Pink'
      WHEN P.ORI = 'MES' THEN 'HoneyDew'
      WHEN P.ORI = 'MIPL' THEN 'Lavender'
      ELSE ''
    END AS BACKGROUND,
    CASE 
      WHEN P.PRGSTT = '20' THEN 'IndianRed'
      WHEN P.PRGSTT = '30' THEN 'SteelBlue'
      WHEN P.PRGSTT = '40' THEN 'SeaGreen'
      ELSE ''
    END AS FOREGROUND
    FROM SYSMENU AS M
    LEFT JOIN SYSPRG AS P 
    ON M.PRGCD = P.PRGCD
    LEFT JOIN SYSCATE AS C 
    ON M.PKGTP = C.PKGTP 
    AND M.CATECD = C.CATECD
    LEFT JOIN SYSPKG AS K 
    ON M.PKGTP = K.PKGTP
    WHERE M.PKGTP LIKE CONCAT('%', $PKGTP, '%')
      AND P.PRGSTT LIKE CONCAT('%', $PRGSTT, '%')
      AND P.DEV LIKE CONCAT('%', $DEV, '%')
      AND K.USEYN = 'Y'
      AND CASE WHEN $PRGSTT = '' THEN P.PRGSTT <> '50' ELSE TRUE END
    #  AND C.USEYN = 'Y'
    ORDER BY M.CATECD, M.SORTNO;

-- ****************************************************************************
WHEN 'ADD_WEBPRG' THEN

  REPLACE INTO SYSPRG (
    PRGCD, PRGNM, PKGTP, PRGSTT, DEV,
    ORI, ORIPRGCD, ORIPRGNM,
    REMARK, RTIME, REMP, RPRG
    ) VALUES (
    $PRGCD, $MENUNM, $PKGTP, $PRGSTT, $DEV,
    $ORI, $ORIPRGCD, $ORIPRGNM,
    $REMARK, CALLTIME(), CALLEMP(), CALLPRG()
    );

  INSERT INTO SYSAUTPRG (
    INOUTTP, AUTCD, PRGCD,
    RTIME, REMP, RPRG
    ) VALUES (
    'IN', 'MNG01', $PRGCD,
    CALLTIME(), CALLEMP(), CALLPRG()
    );

  INSERT INTO SYSAUTPRG (
    INOUTTP, AUTCD, PRGCD,
    RTIME, REMP, RPRG
    ) VALUES (
    'IN', 'ADMIN', $PRGCD,
    CALLTIME(), CALLEMP(), CALLPRG()
    );

  INSERT INTO SYSAUTPRG (
    INOUTTP, AUTCD, PRGCD,
    RTIME, REMP, RPRG
    ) VALUES (
    'IN', 'ALL', $PRGCD,
    CALLTIME(), CALLEMP(), CALLPRG()
    );

  INSERT INTO SYSAUTPRG (
    INOUTTP, AUTCD, PRGCD,
    RTIME, REMP, RPRG
    ) VALUES (
    'OUT', 'ALL', $PRGCD,
    CALLTIME(), CALLEMP(), CALLPRG()
    );

  INSERT INTO SYSMENU (
    PKGTP, CATECD, PRGCD, MENUNM,
    RTIME, REMP, RPRG
    ) VALUES (
    $PKGTP, $CATECD, $PRGCD, $MENUNM,
    CALLTIME(), CALLEMP(), CALLPRG()
    );
     
-- ****************************************************************************
WHEN 'SAVE_WEBPRG' THEN

  UPDATE SYSPRG SET
    PRGNM = $MENUNM,
    PRGSTT = $PRGSTT,
    DEV = $DEV,
    ORI = $ORI,
    ORIPRGCD = $ORIPRGCD,
    ORIPRGNM = $ORIPRGNM,
    TILECOLOR = IFNULL($TILECOLOR, ''),
    TILEICON = IFNULL($TILEICON, ''),
    MTIME = CALLTIME(),
    MEMP = CALLEMP(),
    MPRG = CALLPRG()
    WHERE PRGCD = $PRGCD;

  -- 메뉴 이름까지 수정하려면..
  UPDATE SYSMENU SET
    SORTNO = $SORTNO,
    MENUNM = $MENUNM,
    MTIME = CALLTIME(),
    MEMP = CALLEMP(),
    MPRG = CALLPRG()
    WHERE PRGCD = $PRGCD;

-- ****************************************************************************
WHEN 'SAVE_REMARK' THEN

  UPDATE SYSPRG SET
    REMARK = $REMARK,
    MTIME = CALLTIME(),
    MEMP = CALLEMP(),
    MPRG = CALLPRG()
    WHERE PRGCD = $PRGCD;
-- ****************************************************************************
WHEN 'DEL_WEBPRG' THEN

  DELETE FROM SYSPRG WHERE PRGCD = $PRGCD;

  DELETE FROM SYSAUTPRG WHERE PRGCD = $PRGCD;

  DELETE FROM SYSAUTPRGUSER WHERE PRGCD = $PRGCD;

  DELETE FROM SYSMENU WHERE PRGCD = $PRGCD;
-- ****************************************************************************

END CASE; END