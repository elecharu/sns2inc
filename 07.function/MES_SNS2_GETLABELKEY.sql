CREATE DEFINER = 'root'@'%'
FUNCTION MES_SNS2.GETLABELKEY($PRDDATE VARCHAR(10), $INITCD VARCHAR(10))
  RETURNS varchar(20) CHARSET utf8
-- *****************************************************************************
-- Comment: 실적로트 라벨번호 채번 (소라벨, 해외 수출용)
--          형식: 생산일자 YYMMDD + INITCD(MSTITEM.INITCD) + 순번3자리
--          예  : 2026-10-15, INITCD D → 261015D001, 261015D002, ...
--          ) $PRDDATE : 생산일자 (yyyy-MM-dd)
--          ) $INITCD  : 품목 Initial No (MSTITEM.INITCD)
--          ) 순번은 생산일자 + INITCD 별로 001 부터, PRDRSTLOT.LABELKEY 의 최대 순번 + 1
--          ) 생산일자가 올바르지 않거나 INITCD 가 없으면 '' 반환
-- Create: 2026-11-19 17:40: 신정수
-- Modify: 2026-11-19 17:40: 신정수
-- *****************************************************************************
BEGIN

  DECLARE _$DATE   DATE;
  DECLARE _$PREFIX VARCHAR(20);
  DECLARE _$SEQ    INT;

  SET _$DATE = STR_TO_DATE($PRDDATE, '%Y-%m-%d');
  IF _$DATE IS NULL OR IFNULL($INITCD, '') = '' THEN
    RETURN '';
  END IF;

  SET _$PREFIX = CONCAT(DATE_FORMAT(_$DATE, '%y%m%d'), $INITCD);

  -- 같은 생산일자 + INITCD 의 가장 큰 순번 (다른 INITCD 가 앞부분이 같아도 길이로 구분)
  SET _$SEQ = (SELECT IFNULL(MAX(CAST(RIGHT(PRDRSTLOT.LABELKEY, 3) AS UNSIGNED)), 0)
                 FROM PRDRSTLOT
                 WHERE PRDRSTLOT.LABELKEY LIKE CONCAT(_$PREFIX, '%')
                   AND LENGTH(PRDRSTLOT.LABELKEY) = LENGTH(_$PREFIX) + 3);

  RETURN CONCAT(_$PREFIX, LPAD(_$SEQ + 1, 3, '0'));

END
