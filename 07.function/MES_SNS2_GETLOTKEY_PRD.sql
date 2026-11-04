CREATE DEFINER = 'root'@'%'
FUNCTION MES_SNS2.GETLOTKEY_PRD($PRDDATE VARCHAR(10), $PRCCD VARCHAR(10), $DNTP VARCHAR(10))
  RETURNS varchar(100) CHARSET utf8
-- *****************************************************************************
-- Comment: 로트번호 채번 (생산실적 등록 시 실적로트)
--          형식: 공장기호(II) + 연도2자리 + 월기호(공통코드 PP810) + 일2자리(생산일자)
--                + 공정기호(MSTPRC.PRCSEMT) + '-' + 주야구분 + 순번3자리
--          예  : 2026-10-15, 공정기호 20, 주간 D → II26J1520-D001, II26J1520-D002, ...
--          ) $PRDDATE : 생산일자 (yyyy-MM-dd)
--          ) $PRCCD    : 공정코드 (MSTPRC.PRCCD)
--          ) $DNTP     : 주야구분 기호 (예: D)
--          ) 순번은 생산일자 + 공정기호 + 주야구분 별로 001부터 시작
--            (COMKEY: KEYTYPE = 'LOTPRD_' + 공정기호 + '_' + 주야구분, KEYDATE = 생산일자)
--          ) 오류 시 @ERRMSG 에 내용을 남기고 '' 반환
-- Create: 2026-10-23 16:20: 신정수
-- Modify: 2026-10-23 16:20: 신정수
-- *****************************************************************************
BEGIN

  DECLARE _$PLANTCD VARCHAR(10) DEFAULT 'II';         -- 공장기호
  DECLARE _$KEYTYPE VARCHAR(100);
  DECLARE _$DATE    DATE;
  DECLARE _$KEYDATE VARCHAR(10);
  DECLARE _$MONCD   VARCHAR(10);
  DECLARE _$PRCSEMT VARCHAR(20);
  DECLARE _$KEYSEQ  INT;
  DECLARE _$KEYVALUE VARCHAR(100);

  -- 1. 생산일자 확인 (yyyy-MM-dd)
  SET _$DATE = STR_TO_DATE($PRDDATE, '%Y-%m-%d');
  IF _$DATE IS NULL THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_PRD: 생산일자가 올바르지 않습니다. {0}', IFNULL($PRDDATE, ''));
    RETURN '';
  END IF;
  SET _$KEYDATE = DATE_FORMAT(_$DATE, '%Y-%m-%d');

  -- 2. 월기호 (공통코드 PP810 : REF01 = 월, TPNM = 월기호)
  SET _$MONCD = (
                  SELECT TPNM
                  FROM COMTYPE
                  WHERE GPCD = 'PP810'
                    AND CAST(REF01 AS UNSIGNED) = MONTH(_$DATE)
                  ORDER BY SORTNO
                  LIMIT 1
                );
  IF IFNULL(_$MONCD, '') = '' THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_PRD: 공통코드(PP810)에 월기호가 없습니다. {0}월', MONTH(_$DATE));
    RETURN '';
  END IF;

  -- 3. 공정기호 (MSTPRC.PRCSEMT)
  SET _$PRCSEMT = (SELECT PRCSEMT FROM MSTPRC WHERE PRCCD = $PRCCD);
  IF IFNULL(_$PRCSEMT, '') = '' THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_PRD: 공정기호가 없습니다. 공정코드 {0}', IFNULL($PRCCD, ''));
    RETURN '';
  END IF;

  -- 4. 주야구분 확인
  IF IFNULL($DNTP, '') = '' THEN
    SET @ERRMSG = 'GETLOTKEY_PRD: 주야구분이 없습니다.';
    RETURN '';
  END IF;

  -- 5. 순번 증가 (생산일자 + 공정기호 + 주야구분 별)
  -- ) 공정코드가 아니라 공정기호로 나눔: 공정기호가 같은 공정끼리 로트번호가 겹치지 않게
  -- ) UPDATE 를 먼저 해서 행 잠금을 잡은 뒤 증가된 순번을 다시 읽음 (sql_mode 와 무관하게 동작)
  SET _$KEYTYPE = CONCAT('LOTPRD_', _$PRCSEMT, '_', $DNTP);

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

  -- 6. 순번 3자리 초과 시 오류 (중복 로트번호 방지)
  IF _$KEYSEQ > 999 THEN
    SET @ERRMSG = FORMAT_V1('GETLOTKEY_PRD: 로트번호 순번(999)을 초과했습니다. {0}', CONCAT(_$KEYDATE, ' ', _$PRCSEMT, ' ', $DNTP));
    RETURN '';
  END IF;

  -- 7. 로트번호 조합
  SET _$KEYVALUE = CONCAT(
                     _$PLANTCD
                   , DATE_FORMAT(_$DATE, '%y')
                   , _$MONCD
                   , DATE_FORMAT(_$DATE, '%d')
                   , _$PRCSEMT
                   , '-'
                   , $DNTP
                   , LPAD(_$KEYSEQ, 3, '0')
                   );

  UPDATE COMKEY SET KEYVALUE = _$KEYVALUE
  WHERE KEYTYPE = _$KEYTYPE AND KEYDATE = _$KEYDATE;

  RETURN _$KEYVALUE;

END
