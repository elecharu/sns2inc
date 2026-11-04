CREATE DEFINER = 'root'@'%'
FUNCTION MES_SNS2.GETLOTKEY_DLV($LOTDATE VARCHAR(10))
  RETURNS varchar(100) CHARSET utf8
-- *****************************************************************************
-- Comment: 로트번호 채번 (납품등록 일자 기준)
--          형식: 공장기호(II) + 연도2자리 + 월기호(공통코드 PP811) + 일2자리 + '-' + 순번3자리
--          예  : 2026-10-10 → II26K10-001, II26K10-002, ...
--          ) 순번은 납품등록 일자별로 001부터 시작 (COMKEY: KEYTYPE = 'LOTKEY_DLV', KEYDATE = 납품등록일자)
--          ) 오류 시 @ERRMSG 에 내용을 남기고 '' 반환
-- Create: 2026-10-21
-- Modify:
-- *****************************************************************************
BEGIN

  DECLARE _$PLANTCD VARCHAR(10) DEFAULT 'II';         -- 공장기호
  DECLARE _$KEYTYPE VARCHAR(20) DEFAULT 'LOTKEY_DLV';
  DECLARE _$DATE    DATE;
  DECLARE _$KEYDATE VARCHAR(10);
  DECLARE _$MONCD   VARCHAR(10);
  DECLARE _$KEYSEQ  INT;
  DECLARE _$KEYVALUE VARCHAR(100);

  -- 1. 납품등록 일자 확인 (yyyy-MM-dd)
  SET _$DATE = STR_TO_DATE($LOTDATE, '%Y-%m-%d');
  IF _$DATE IS NULL THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_DLV: 납품등록 일자가 올바르지 않습니다. {0}', IFNULL($LOTDATE, ''));
    RETURN '';
  END IF;
  SET _$KEYDATE = DATE_FORMAT(_$DATE, '%Y-%m-%d');

  -- 2. 월기호 (공통코드 PP811 : REF01 = 월, TPNM = 월기호)
  SET _$MONCD = (
                  SELECT TPNM
                  FROM COMTYPE
                  WHERE GPCD = 'PP811'
                    AND CAST(REF01 AS UNSIGNED) = MONTH(_$DATE)
                  ORDER BY SORTNO
                  LIMIT 1
                );
  IF IFNULL(_$MONCD, '') = '' THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_DLV: 공통코드(PP811)에 월기호가 없습니다. {0}월', MONTH(_$DATE));
    RETURN '';
  END IF;

  -- 3. 순번 증가 (일자별)
  -- ) UPDATE 를 먼저 해서 행 잠금을 잡은 뒤 증가된 순번을 다시 읽음 (sql_mode 와 무관하게 동작)
  UPDATE COMKEY SET
    KEYSEQ = KEYSEQ + 1,
    MTIME = GETTIME(),
    MEMP = IFNULL(@CALLEMP, ''),
    MPRG = IFNULL(@CALLPRG, '')
  WHERE KEYTYPE = _$KEYTYPE AND KEYDATE = _$KEYDATE;

  IF ROW_COUNT() = 0 THEN
    INSERT INTO COMKEY (KEYTYPE, KEYDATE, KEYSEQ, KEYVALUE, RTIME, REMP, RPRG)
      VALUES (_$KEYTYPE, _$KEYDATE, 1, '', GETTIME(), IFNULL(@CALLEMP, ''), IFNULL(@CALLPRG, ''));
  END IF;

  SET _$KEYSEQ = (SELECT KEYSEQ FROM COMKEY WHERE KEYTYPE = _$KEYTYPE AND KEYDATE = _$KEYDATE);

  -- 4. 순번 3자리 초과 시 오류 (중복 로트번호 방지)
  IF _$KEYSEQ > 999 THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_DLV: 일자별 로트번호 순번(999)을 초과했습니다. {0}', _$KEYDATE);
    RETURN '';
  END IF;

  -- 5. 로트번호 조합
  SET _$KEYVALUE = CONCAT(
                     _$PLANTCD
                   , DATE_FORMAT(_$DATE, '%y')
                   , _$MONCD
                   , DATE_FORMAT(_$DATE, '%d')
                   , '-'
                   , LPAD(_$KEYSEQ, 3, '0')
                   );

  UPDATE COMKEY SET KEYVALUE = _$KEYVALUE
  WHERE KEYTYPE = _$KEYTYPE AND KEYDATE = _$KEYDATE;

  RETURN _$KEYVALUE;

END
