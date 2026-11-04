CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.ITSLOGIN(
-- *****************************************************************************
-- Comment: 로그인 화면
-- Create: 2016-11-27 11:26: 
-- Modify: 2021-09-17 09:30: 박제홍      로그인 이력 생성
-- *****************************************************************************
 IN $LOGIN_USER VARCHAR(20),
 IN $LOGIN_PASS VARCHAR(1000),
 IN $SYSURL     VARCHAR(1000),
 IN $SESSION_LOGINKEY VARCHAR(20),
 IN $USERIP VARCHAR(50),
 IN $MACADDR VARCHAR(50),
-- *****************************************************************************
 IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y'; 
-- *****************************************************************************

-- DECLARE _$V01 VARCHAR(1000);
  DECLARE _$LOGINKEY VARCHAR(20);
  DECLARE _$LOGINTIME VARCHAR(19);

-- ****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LOGIN' THEN

  IF NOT EXISTS (SELECT USERID FROM SYSUSER WHERE USERID = $LOGIN_USER) THEN
    CALL COMERR('사용자 아이디를 정확하게 입력하세요.');
    LEAVE PROC;
  END IF;


  IF NOT EXISTS (SELECT USERID FROM SYSUSER WHERE USERID = $LOGIN_USER AND WEBUSERPASS = SHA2(CONCAT('SB', $LOGIN_PASS),256)) THEN
    CALL COMERR('패스워드가 정확하지 않습니다.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT USERID FROM SYSUSER WHERE USERID = $LOGIN_USER AND LOCKYN = 'Y') THEN
    CALL COMERR('로그인이 제한된 사용자입니다.');
    LEAVE PROC;
  END IF;

  SET _$LOGINKEY = GETKEY('SYSLOGINHIS');
  SET _$LOGINTIME = GETTIME();

  INSERT INTO SYSLOGINHIS (
    LOGINKEY, USERID, LOGINTYPE, LOGINTIME, LOGOUTTYPE, LOGOUTTIME,
    IP, MOBILEYN, TMLUID, RTIME, REMP, RPRG
    ) VALUES (
    _$LOGINKEY, $LOGIN_USER, 'TML_LOGIN', _$LOGINTIME, '', '',
    $USERIP, 'N', $MACADDR, GETTIME(), '', '');

  SELECT _$LOGINKEY AS LOGINKEY, _$LOGINTIME AS LOGINTIME;

--   SELECT EMPCD FROM SYSUSER WHERE USERID = $LOGIN_USER AND USERPASS = $LOGIN_PASS;
-- ****************************************************************************
WHEN 'LOGIN_SSO' THEN

  IF NOT EXISTS (SELECT USERID FROM SYSUSER WHERE USERID = $LOGIN_USER) THEN
    CALL COMERR('사용자 아이디를 정확하게 입력하세요.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT USERID FROM SYSUSER WHERE USERID = $LOGIN_USER AND WEBUSERPASS = SHA2(CONCAT('DB', $LOGIN_PASS),256)) THEN
    CALL COMERR('패스워드가 정확하지 않습니다.');
    LEAVE PROC;
  END IF;

  IF EXISTS (SELECT USERID FROM SYSUSER WHERE USERID = $LOGIN_USER AND LOCKYN = 'Y') THEN
    CALL COMERR('로그인이 제한된 사용자입니다.');
    LEAVE PROC;
  END IF;

  SELECT EMPCD FROM SYSUSER WHERE USERID = $LOGIN_USER AND WEBUSERPASS = SHA2(CONCAT('DB', $LOGIN_PASS),256);
-- ****************************************************************************
WHEN 'USER_INFO' THEN

  SELECT MSTEMP.BDVCD, SYSUSER.USERID AS USERID, MSTEMP.EMPCD AS EMPCD, MSTEMP.EMPNM,
--     MSTEMP.ENNM, MSTEMP.JPNM, MSTEMP.CNNM, 
    MSTEMP.DEPTP, MSTEMP.POSTP, MSTEMP.EMPTP    
    FROM SYSUSER
    LEFT JOIN MSTEMP ON SYSUSER.EMPCD = MSTEMP.EMPCD
    WHERE SYSUSER.USERID = $LOGIN_USER 
--       AND (SYSUSER.USERPASS = $LOGIN_PASS
--            OR WEBUSERPASS = SHA2(CONCAT('DB',$LOGIN_PASS), 256)
--       )
    LIMIT 1;
-- 
--   IF $SYSURL <> '' THEN
-- 
--     UPDATE COMTYPE SET REF01 = $SYSURL
--       WHERE GPCD = 'GLOBAL' AND TPCD = 'SYSURL';
-- 
--   END IF;

-- ****************************************************************************
WHEN 'LOGOUT' THEN

  UPDATE SYSLOGINHIS SET
    LOGOUTTYPE = 'TML_LOGOUT', 
    LOGOUTTIME = GETTIME(),
    MTIME = GETTIME(), MEMP = '', MPRG = ''
    WHERE LOGINKEY = $SESSION_LOGINKEY;

-- ****************************************************************************
END CASE; END