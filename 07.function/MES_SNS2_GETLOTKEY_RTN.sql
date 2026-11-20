CREATE DEFINER = 'root'@'%'
FUNCTION MES_SNS2.GETLOTKEY_RTN($RTNDATE VARCHAR(10))
  RETURNS varchar(100) CHARSET utf8
-- *****************************************************************************
-- Comment: 로트번호 채번 (제품 반입등록 TML6001_R01 : 공정이동표 없이 반입된 제품의 새 로트)
--          형식: 'RT' + 반입일자 yyMMdd + '-' + 순번3자리
--          예  : 2026-11-20 → RT261120-001, RT261120-002, ...
--          ) $RTNDATE : 반입일자 (yyyy-MM-dd)
--          ) 순번은 반입일자별로 001부터 시작 (COMKEY: KEYTYPE = 'LOTRTN', KEYDATE = 반입일자)
--          ) 오류 시 @ERRMSG 에 내용을 남기고 '' 반환
-- Create: 2026-11-20
-- *****************************************************************************
BEGIN

  DECLARE _$KEYTYPE  VARCHAR(100) DEFAULT 'LOTRTN';
  DECLARE _$DATE     DATE;
  DECLARE _$KEYDATE  VARCHAR(10);
  DECLARE _$KEYSEQ   INT;
  DECLARE _$KEYVALUE VARCHAR(100);

  -- 1. 반입일자 확인 (yyyy-MM-dd)
  SET _$DATE = STR_TO_DATE($RTNDATE, '%Y-%m-%d');
  IF _$DATE IS NULL THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_RTN: 반입일자가 올바르지 않습니다. {0}', IFNULL($RTNDATE, ''));
    RETURN '';
  END IF;
  SET _$KEYDATE = DATE_FORMAT(_$DATE, '%Y-%m-%d');

  -- 2. 순번 증가 (반입일자별)
  -- ) UPDATE 를 먼저 해서 행 잠금을 잡은 뒤 증가된 순번을 다시 읽음 (GETLOTKEY_PRD 와 같은 방식)
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

  -- 3. 순번 3자리 초과 시 오류 (중복 로트번호 방지)
  IF _$KEYSEQ > 999 THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_RTN: 로트번호 순번(999)을 초과했습니다. {0}', _$KEYDATE);
    RETURN '';
  END IF;

  -- 4. 로트번호 조합
  SET _$KEYVALUE = CONCAT('RT', DATE_FORMAT(_$DATE, '%y%m%d'), '-', LPAD(_$KEYSEQ, 3, '0'));

  UPDATE COMKEY SET KEYVALUE = _$KEYVALUE
  WHERE KEYTYPE = _$KEYTYPE AND KEYDATE = _$KEYDATE;

  RETURN _$KEYVALUE;

END
