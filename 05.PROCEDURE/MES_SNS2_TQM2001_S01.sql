CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TQM2001_S01(
-- *****************************************************************************
-- Comment: 부적합 판정조회 (품질팀)
--          ) LIST: 판정일자 기준 부적합 판정이력(TQMJUDGE)과 후처리 여부
--          ) 후처리 후 재고가 불량창고에서 다른 창고로 옮겨지면 판정등록(TQM2001_R01)에서는 안 보이므로
--            판정이력 자체를 조회한다
--          ) 후처리 일시·화면은 따로 남기는 컬럼이 없어 후처리된 판정의 MTIME·MPRG 를 보여준다
--            (후처리된 판정은 수정·삭제가 막혀 있으므로 마지막 수정 = 후처리)
--            후처리화면은 SYSPRG.PRGNM, SYSPRG 에 없으면 화면코드 그대로
-- Create: 2026-11-12
-- Modify: 2026-11-12 현재 재고위치(NOWWARE) 삭제, 후처리화면을 화면명(SYSPRG.PRGNM)으로 표시
-- *****************************************************************************
  IN $SDATE VARCHAR(10),          -- 판정일자 시작
  IN $EDATE VARCHAR(10),          -- 판정일자 종료
  IN $JUDGETP VARCHAR(100),       -- 판정유형 (공통코드 JUDGETP)
  IN $PROCYN VARCHAR(1),          -- 후처리여부 ('' 전체, N 미처리, Y 처리완료)
  IN $ITEMCG VARCHAR(100),        -- 품목유형 (공통코드 DM100)
  IN $ITEMID VARCHAR(100),        -- 품목ID
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST' THEN  -- 부적합 판정이력

  IF $SDATE = '' OR $EDATE = '' THEN
    CALL COMERR('판정일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  SELECT
      TQMJUDGE.JUDGEDATE, TQMJUDGE.JUDGETP, TQMJUDGE.JUDGEBADTP, TQMJUDGE.BADCD
    , IFNULL(MSTBAD.BADNM, '') AS BADNM
    , TQMJUDGE.LOTKEY, MSTITEM.ITEMCG, MSTITEM.ITEMCD, MSTITEM.ITEMNM, MSTITEM.ITEMSPEC
    , IFNULL(MSTWARE.WARENM, TQMJUDGE.WARECD) AS WARENM
    , TQMJUDGE.JUDGEQTY
    , TQMJUDGE.EMPCD
    , IFNULL(MSTEMP.EMPNM, '') AS EMPNM
    , TQMJUDGE.REMARK
    , TQMJUDGE.PROCYN
    , IF(TQMJUDGE.PROCYN = 'Y', LEFT(TQMJUDGE.MTIME, 16), '') AS PROCTIME
    , IF(TQMJUDGE.PROCYN = 'Y'
       , IFNULL((SELECT SYSPRG.PRGNM FROM SYSPRG WHERE SYSPRG.PRGCD = TQMJUDGE.MPRG LIMIT 1), TQMJUDGE.MPRG)
       , '') AS PROCPRGNM
    , TQMJUDGE.JUDGEKEY
    , TQMJUDGE.WARECD
    , TQMJUDGE.ITEMID
  FROM TQMJUDGE
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = TQMJUDGE.ITEMID
  LEFT JOIN MSTBAD
    ON MSTBAD.BADCD = TQMJUDGE.BADCD
  LEFT JOIN MSTWARE
    ON MSTWARE.WARECD = TQMJUDGE.WARECD
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = TQMJUDGE.EMPCD
  WHERE TQMJUDGE.JUDGEDATE BETWEEN $SDATE AND $EDATE
    AND ($JUDGETP = '' OR TQMJUDGE.JUDGETP = $JUDGETP)
    AND ($PROCYN = '' OR TQMJUDGE.PROCYN = $PROCYN)
    AND ($ITEMCG = '' OR MSTITEM.ITEMCG = $ITEMCG)
    AND ($ITEMID = '' OR TQMJUDGE.ITEMID = $ITEMID)
  ORDER BY TQMJUDGE.JUDGEDATE, TQMJUDGE.LOTKEY, TQMJUDGE.JUDGEKEY;

-- ****************************************************************************
END CASE;  END
