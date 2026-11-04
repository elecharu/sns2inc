-- ITSIF_INTERFACE 설치 스크립트 (원본 DB: IF_MES_SNS_FAC2, 추출일 2026-10-27)
-- 대상 DB 를 선택한 뒤 실행하세요. 예) USE IF_MES_SNS_FAC2;

DELIMITER $$

DROP FUNCTION IF EXISTS `ADDDATE_MONTH`$$
CREATE FUNCTION `ADDDATE_MONTH`($BASEDATE VARCHAR(10), $VAL INT) RETURNS varchar(10) CHARSET utf8
BEGIN

  RETURN DATE_FORMAT(ADDDATE(CAST($BASEDATE AS DATETIME), interval $VAL month), '%Y-%m-%d');

END$$

DROP FUNCTION IF EXISTS `GETDATE`$$
CREATE FUNCTION `GETDATE`() RETURNS varchar(10) CHARSET utf8
BEGIN

  RETURN DATE_FORMAT(CURDATE(), '%Y-%m-%d');

END$$

DROP FUNCTION IF EXISTS `GETDATETIME`$$
CREATE FUNCTION `GETDATETIME`($BASEDATE VARCHAR(30)) RETURNS varchar(19) CHARSET utf8
BEGIN

  DECLARE _$AA VARCHAR(19);

  SET _$AA = ''; -- 변수 초기화

    IF $BASEDATE <> '' THEN 
      CASE 
        WHEN LOCATE('오전', $BASEDATE) > 0 THEN 
          SET _$AA = DATE_FORMAT(STR_TO_DATE(REPLACE($BASEDATE, '오전', ''), '%Y-%m-%d %h:%i:%s'), '%Y-%m-%d %H:%i:%s');
        WHEN LOCATE('오후', $BASEDATE) > 0 THEN 
          SET _$AA = DATE_FORMAT( 
                        IF(
                            HOUR(STR_TO_DATE(REPLACE($BASEDATE, '오후', ''), '%Y-%m-%d %h:%i:%s')) < 12, 
                            STR_TO_DATE(REPLACE($BASEDATE, '오후', ''), '%Y-%m-%d %h:%i:%s') + INTERVAL 12 HOUR,
                            STR_TO_DATE(REPLACE($BASEDATE, '오후', ''), '%Y-%m-%d %h:%i:%s')
                            ),
                          '%Y-%m-%d %H:%i:%s');
        ELSE 
          SET _$AA = IFNULL($BASEDATE, DATE_FORMAT(STR_TO_DATE($BASEDATE, '%Y-%m-%d %h:%i:%s'), '%Y-%m-%d %H:%i:%s'));  
      END CASE;
    END IF;

  RETURN _$AA;

END$$

DROP FUNCTION IF EXISTS `GETPARAM`$$
CREATE FUNCTION `GETPARAM`($PARAM MEDIUMTEXT, $NAME VARCHAR(100)) RETURNS mediumtext CHARSET utf8
BEGIN

  DECLARE _$SINDEX INT;
  DECLARE _$RTNVALUE MEDIUMTEXT;

  SET $PARAM = REPLACE($PARAM, '$', '');
  SET $NAME = CONCAT('┃', REPLACE($NAME, '$', ''), '»');

  SET _$SINDEX = INSTR($PARAM, $NAME);
  IF _$SINDEX = 0 THEN RETURN ''; END IF;

  SET _$RTNVALUE = SUBSTRING($PARAM, _$SINDEX + CHAR_LENGTH($NAME));

  RETURN SUBSTRING(_$RTNVALUE, 1, INSTR(_$RTNVALUE, '┃') - 1);

END$$

DROP FUNCTION IF EXISTS `GETTIME`$$
CREATE FUNCTION `GETTIME`() RETURNS varchar(19) CHARSET utf8
BEGIN

  RETURN DATE_FORMAT(SYSDATE(), '%Y-%m-%d %T');

END$$

DELIMITER ;
