CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.MST1002_R04(
-- *****************************************************************************
-- Comment: 공정정보관리
-- Create: 2024-02-22 13:50: 김영철
-- Modify: 
-- *****************************************************************************
  IN $FACTORYCD VARCHAR(20), 
  IN $GUBUN_BC VARCHAR(20), 
  IN $USEYN VARCHAR(1),
  IN $CALLTYPE VARCHAR(50), 
  IN $KEYWORD VARCHAR(1000),
  IN $PRCCD_LIST MEDIUMTEXT,
  IN $WEEKPLANYN_LIST MEDIUMTEXT
  )
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$PRCCD VARCHAR(100);
  DECLARE _$WEEKPLANYN VARCHAR(1);
-- *****************************************************************************
  CASE $CALLTYPE
-- ****************************************************************************
WHEN 'SEL_PRC' THEN -- 공정정보 조회 
  
  SELECT 
    B.FACTORYNM, A.FACTORYCD, A.PRCCD, A.PRCNM, A.USEYN, 
    A.SDT, A.EDT, A.REMARK, A.REMP, 
    A.RTIME, A.MEMP, A.MTIME, A.GUBUN_BC, 
    A.PRCSEMT, A.PRCGROUP, A.INSYN, A.BOXYN,
    A.WEEKPLANYN
  FROM MSTPRC AS A
  INNER JOIN MSTFACTORY AS B ON A.FACTORYCD = B.FACTORYCD
  WHERE A.FACTORYCD LIKE CONCAT('%', $FACTORYCD, '%')
    AND A.GUBUN_BC LIKE CONCAT('%', $GUBUN_BC, '%')
    AND A.USEYN = $USEYN
  ORDER BY A.FACTORYCD, A.GUBUN_BC, A.PRCCD;

-- ****************************************************************************
WHEN 'SAVE_MSTPRC' THEN -- 공정정보 저장

  WHILE LENGTH($PRCCD_LIST) > 0 DO
    CALL COMSPLIT($PRCCD_LIST, _$PRCCD);
    CALL COMSPLIT($WEEKPLANYN_LIST, _$WEEKPLANYN);

    IF NOT EXISTS (SELECT PRCCD FROM MSTPRC WHERE PRCCD = _$PRCCD) THEN
      CALL COMERR(CONCAT('존재하지 않는 공정입니다.', '\n- 공정코드: ', _$PRCCD));
      LEAVE PROC;
    END IF;

    UPDATE MSTPRC
    SET MSTPRC.WEEKPLANYN = _$WEEKPLANYN
      , MTIME = CALLTIME()
      , MEMP = CALLEMP()
      , MPRG = CALLPRG()
    WHERE PRCCD = _$PRCCD
    ;
  END WHILE;
-- ****************************************************************************
END CASE;
END