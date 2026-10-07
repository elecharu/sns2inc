CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.SYS0001_R04(
-- *****************************************************************************
-- Comment: 사용자관리
-- Create: 2025-03-27 이대규
-- *****************************************************************************
 IN $USERID VARCHAR(20), -- 로그인ID
 IN $PASSWORD VARCHAR(100), -- 비밀번호
 IN $CHPASSWORD VARCHAR(100), -- 비밀번호 확인 
 IN $EMPCD VARCHAR(20), -- 사원코드
 IN $CUSTCD VARCHAR(100),
 IN $LOCKYN VARCHAR(1), -- 잠금여부
 IN $AUTCD VARCHAR(10), -- 권한코드
 IN $LANGUAGE VARCHAR(20),
 IN $REMARK VARCHAR(1000), -- 비고
-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

-- DECLARE _$V01 VARCHAR(1000);

-- ****************************************************************************
CASE $CALLTYPE
-- * ***************************************************************************
WHEN 'LIST_SYSUSER' THEN

  SELECT 
    SYSUSER.USERID, 
    '****' AS USERPASS,
    SYSUSER.EMPCD, 
    SYSUSER.CUSTCD,
    IFNULL(MSTCUST.CUSTNM, '') AS CUSTNM,
    SYSUSER.LOCKYN, 
    SYSUSER.AUTCD, 
    SYSUSER.REMARK,
    SYSUSER.LANGUAGE
  FROM SYSUSER
  LEFT JOIN MSTEMP ON MSTEMP.EMPCD = SYSUSER.EMPCD
  LEFT JOIN MSTCUST
    ON MSTCUST.CUSTCD = SYSUSER.CUSTCD  
  WHERE (SYSUSER.USERID LIKE CONCAT('%', $KEYWORD, '%')
    OR SYSUSER.EMPCD LIKE CONCAT('%', $KEYWORD, '%')
    OR MSTEMP.EMPNM LIKE CONCAT('%', $KEYWORD, '%')
    OR SYSUSER.REMARK LIKE CONCAT('%', $KEYWORD, '%'));

-- * ***************************************************************************
WHEN 'ADD_SYSUSER' THEN

  IF $USERID = '' THEN
    CALL COMERR('ID를 입력하지 않았습니다.');
    LEAVE PROC;
  END IF;

  IF $EMPCD = '' THEN
    CALL COMERR('사원을 선택하지 않았습니다.');
    LEAVE PROC;
  END IF;

  IF $AUTCD = '' THEN
    CALL COMERR('권한을 선택하지 않았습니다.');
    LEAVE PROC;
  END IF;

  IF $PASSWORD = '' THEN
    CALL COMERR('비밀번호를 입력하지 않았습니다.');
    LEAVE PROC;
  END IF;

  IF $PASSWORD <> $CHPASSWORD THEN
    CALL COMERR('비밀번호와 비밀번호확인이 다릅니다.');
    LEAVE PROC;
  END IF;

  IF $CUSTCD != '' THEN
    IF NOT EXISTS (SELECT CUSTCD FROM MSTCUST WHERE CUSTCD = $CUSTCD) THEN
      CALL COMERR(CONCAT('기준정보에 존재하지 않는 거래처코드입니다.', '\n- 거래처코드: ', $CUSTCD));
      LEAVE PROC;
    END IF;
  END IF;

  INSERT INTO SYSUSER (
    USERID, WEBUSERPASS, EMPCD, LOCKYN, AUTCD, 
    CUSTCD,
    REMARK
    ) VALUES (
    $USERID, SHA2(CONCAT('SB',$PASSWORD), 256), $EMPCD, $LOCKYN, $AUTCD, 
    $CUSTCD,
    $REMARK
    );

  INSERT INTO SYSAUTUSER (
    USERID, AUTCD, USEYN, RTIME, REMP, RPRG
    ) VALUES (
    $USERID, $AUTCD, 'Y', CALLTIME(), CALLEMP(), CALLPRG()
    );

-- ****************************************************************************
WHEN 'DEL_SYSUSER' THEN

  DELETE SYSUSER
    FROM SYSUSER
    WHERE SYSUSER.USERID = $USERID;

    DELETE SYSAUTUSER
    FROM SYSAUTUSER
    WHERE SYSAUTUSER.USERID = $USERID;

-- ****************************************************************************
WHEN 'UP_SYSUSER' THEN

  UPDATE SYSUSER SET 
--     SYSUSER.USERPASS = 
--     CASE WHEN $PASSWORD = 'RVgxR3uCV09r+HEZPy92HQ==' THEN SYSUSER.USERPASS ELSE $PASSWORD END, 
    SYSUSER.LOCKYN = $LOCKYN, 
    SYSUSER.CUSTCD = $CUSTCD,
--     SYSUSER.AUTCD = $AUTCD, 
    SYSUSER.LANGUAGE = $LANGUAGE, 
    SYSUSER.REMARK = $REMARK
    WHERE SYSUSER.USERID = $USERID;

  -- ****************************************************************************

WHEN 'CHANGE_PASSWORD' THEN

  IF $PASSWORD = '' THEN
    CALL COMERR('변경할 비밀번호를 입력하지 않았습니다.');
    LEAVE PROC;
  END IF;

  IF $PASSWORD <> $CHPASSWORD THEN
    CALL COMERR('비밀번호와 비밀번호확인이 다릅니다.');
    LEAVE PROC;
  END IF;

  UPDATE SYSUSER SET 
    SYSUSER.WEBUSERPASS =  SHA2(CONCAT('SB',$PASSWORD), 256)
    WHERE SYSUSER.USERID = $USERID;

-- ****************************************************************************
END CASE; END