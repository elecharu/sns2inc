CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.SAVE_PRDPLA_W(
    $SDATE VARCHAR(10), $EDATE VARCHAR(10), $PDATE VARCHAR(10)
  , $ITEMID VARCHAR(100)
  , $EQMCD VARCHAR(100)
  , $CT VARCHAR(100)
  , $EFFI VARCHAR(100)
  , $UPH VARCHAR(100)
  , $ONESQTY VARCHAR(100)
  , $PLAN_DAY VARCHAR(100), $PLAN_NIGHT VARCHAR(100))
PROC: BEGIN

  -- 주간생산계획 저장 프로시저 

  DECLARE _$PMONTH VARCHAR(7);
  DECLARE _$PLANQTY_DAY DECIMAL(20, 8);
  DECLARE _$PLANQTY_NIGHT DECIMAL(20, 8);
  DECLARE _$PLANSTOP_DAY VARCHAR(1);
  DECLARE _$PLANSTOP_NIGHT VARCHAR(1);

  SET _$PMONTH = LEFT($SDATE, 7);

  IF $PDATE BETWEEN $SDATE AND $EDATE THEN
--     IF $PDATE >= GETDATE() THEN 
    IF $PDATE < GETDATE() THEN 
      -- 주간
      IF $PLAN_DAY != '' THEN
        IF $PLAN_DAY = '계획정지' THEN
          SET _$PLANSTOP_DAY = 'Y';
          SET _$PLANQTY_DAY = 0;
        ELSE
          SET _$PLANSTOP_DAY = 'N';
          SET _$PLANQTY_DAY = CAST($PLAN_DAY AS DECIMAL(20, 8));
        END IF;
  
        INSERT INTO PRDPLAN_W (
            PMONTH
          , PDATE
          , ITEMID
          , EQMCD
          , CT
          , EFFI
          , UPH
          , ONESQTY
          , PLANQTY_DAY
          , PLANSTOP_DAY
          , RTIME, REMP, RPRG)
        VALUES (
            _$PMONTH
          , $PDATE
          , CAST($ITEMID AS INT)
          , $EQMCD
          , CAST($CT AS DECIMAL(20, 8))
          , CAST($EFFI AS DECIMAL(20, 8))
          , CAST($UPH AS DECIMAL(20, 8))
          , CAST($ONESQTY AS DECIMAL(20, 8))
          , _$PLANQTY_DAY
          , _$PLANSTOP_DAY
          , CALLTIME(), CALLEMP(), CALLPRG()
        )
        ON DUPLICATE KEY UPDATE          
            CT = CAST($CT AS DECIMAL(20, 8))
          , EFFI = CAST($EFFI AS DECIMAL(20, 8))
          , UPH = CAST($UPH AS DECIMAL(20, 8))
          , ONESQTY = CAST($ONESQTY AS DECIMAL(20, 8))
          , PLANQTY_DAY = _$PLANQTY_DAY
          , PLANSTOP_DAY = _$PLANSTOP_DAY
          , MTIME = CALLTIME()
          , MEMP  = CALLEMP()
          , MPRG  = CALLPRG()
        ;
      END IF;
  
      -- 야간
      IF $PLAN_NIGHT IS NOT NULL AND $PLAN_NIGHT != '' THEN
        IF $PLAN_NIGHT = '계획정지' THEN
          SET _$PLANSTOP_NIGHT = 'Y';
          SET _$PLANQTY_NIGHT = 0;
        ELSE
          SET _$PLANSTOP_NIGHT = 'N';
          SET _$PLANQTY_NIGHT = CAST($PLAN_NIGHT AS DECIMAL(20, 8));
        END IF;
  
        INSERT INTO PRDPLAN_W (
            PMONTH
          , PDATE
          , ITEMID
          , EQMCD
          , CT
          , EFFI
          , UPH
          , ONESQTY
          , PLANQTY_NIGHT
          , PLANSTOP_NIGHT
          , RTIME, REMP, RPRG)
        VALUES (
            _$PMONTH
          , $PDATE
          , CAST($ITEMID AS INT)
          , $EQMCD
          , CAST($CT AS DECIMAL(20, 8))
          , CAST($EFFI AS DECIMAL(20, 8))
          , CAST($UPH AS DECIMAL(20, 8))
          , CAST($ONESQTY AS DECIMAL(20, 8))
          , _$PLANQTY_NIGHT
          , _$PLANSTOP_NIGHT
          , CALLTIME(), CALLEMP(), CALLPRG()
        )
        ON DUPLICATE KEY UPDATE          
            CT = CAST($CT AS DECIMAL(20, 8))
          , EFFI = CAST($EFFI AS DECIMAL(20, 8))
          , UPH = CAST($UPH AS DECIMAL(20, 8))
          , ONESQTY = CAST($ONESQTY AS DECIMAL(20, 8))
          , PLANQTY_NIGHT = _$PLANQTY_NIGHT
          , PLANSTOP_NIGHT = _$PLANSTOP_NIGHT
          , MTIME = CALLTIME()
          , MEMP  = CALLEMP()
          , MPRG  = CALLPRG()
        ;
      END IF;

      IF EXISTS (SELECT 1 FROM PRDPLAN_W WHERE PMONTH = _$PMONTH AND PDATE = $PDATE AND ITEMID = $ITEMID AND EQMCD = $EQMCD ) THEN
        IF $PLAN_DAY = '' AND $PLAN_NIGHT = '' THEN
          DELETE FROM PRDPLAN_W 
          WHERE PMONTH = _$PMONTH 
            AND PDATE = $PDATE 
            AND ITEMID = $ITEMID 
            AND EQMCD = $EQMCD
          ;
        ELSEIF $PLAN_DAY = '' AND $PLAN_NIGHT != '' THEN
          UPDATE PRDPLAN_W 
          SET PLANQTY_DAY = 0
            , PLANSTOP_DAY = 'N'
            , MTIME = CALLTIME()
            , MEMP = CALLEMP()
            , MPRG = CALLPRG()
          WHERE PMONTH = _$PMONTH 
            AND PDATE = $PDATE 
            AND ITEMID = $ITEMID 
            AND EQMCD = $EQMCD
          ;
        ELSEIF $PLAN_DAY != '' AND $PLAN_NIGHT = '' THEN
          UPDATE PRDPLAN_W 
          SET PLANQTY_NIGHT = 0
            , PLANSTOP_NIGHT = 'N'
            , MTIME = CALLTIME()
            , MEMP = CALLEMP()
            , MPRG = CALLPRG()
          WHERE PMONTH = _$PMONTH 
            AND PDATE = $PDATE 
            AND ITEMID = $ITEMID 
            AND EQMCD = $EQMCD
          ;
        END IF;
      END IF;

    END IF;
  END IF;

END