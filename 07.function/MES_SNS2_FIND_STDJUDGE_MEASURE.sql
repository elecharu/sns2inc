CREATE DEFINER = 'root'@'%'
FUNCTION MES_SNS2.FIND_STDJUDGE_MEASURE( -- 검사기준 출력함수 (2023-12-15 신정수)
    $STDRANGE VARCHAR(100)  -- 범위
  , $STDVAL DECIMAL(20,8)   -- 기준값
  , $STDUNIT VARCHAR(100)   -- 단위
  , $STDMINUS DECIMAL(20,8) -- 오차(-)
  , $STDPLUS  DECIMAL(20,8) -- 오차(+)
  )
  RETURNS varchar(100) CHARSET utf8
BEGIN  
  IF $STDRANGE IN ( '01', '02', '03', '04') THEN  -- 기준값범위 : ↑, ↓
    RETURN CASE WHEN GPCD('STDUNIT', $STDUNIT) = 'ø' THEN CONCAT(GPCD('STDUNIT', $STDUNIT), CAST($STDVAL AS DOUBLE), ' ', GPCD('STDRANGE', $STDRANGE))  -- 단위ø 면 숫자앞에 붙이기 
           ELSE CONCAT(CAST($STDVAL AS DOUBLE), GPCD('STDUNIT', $STDUNIT), ' ', GPCD('STDRANGE', $STDRANGE))
           END;
  ELSEIF $STDRANGE IN ( '06', '07' ) THEN -- 기준값범위 : ~
    RETURN IF( CAST($STDMINUS AS DOUBLE) = 0 AND CAST($STDPLUS AS DOUBLE) = 0  -- 공차가 모두 0이면
              , CONCAT(CAST($STDVAL AS DOUBLE), GPCD('STDUNIT', $STDUNIT))  -- 기준값만 출력
              , CASE WHEN GPCD('STDUNIT', $STDUNIT) = 'ø' THEN CONCAT(  GPCD('STDUNIT', $STDUNIT)
                                                                      , CAST($STDVAL + $STDMINUS AS DOUBLE)
                                                                      , '~', CAST($STDVAL + $STDPLUS AS DOUBLE)
                                                                     )  -- 단위ø 면 숫자앞에 붙이기 
                     ELSE CONCAT( CAST($STDVAL + $STDMINUS AS DOUBLE)
                                  , '~', CAST($STDVAL + $STDPLUS AS DOUBLE)
                                  , GPCD('STDUNIT', $STDUNIT)
                                )
                END 
             );  
  ELSEIF $STDRANGE = '05' THEN  -- =
    RETURN CONCAT(CAST($STDVAL AS DOUBLE), GPCD('STDUNIT', $STDUNIT));
  ELSE
    RETURN GPCD('STDRANGE', $STDRANGE);
  END IF;
END