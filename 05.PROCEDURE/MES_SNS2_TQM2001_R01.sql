CREATE DEFINER = 'root'@'%'
PROCEDURE MES_SNS2.TQM2001_R01(
-- *****************************************************************************
-- Comment: 부적합 판정등록 (품질팀)
--          ) LIST_LOT    : 불량창고(재공 04S130_N, 제품 04S230_N) 현재고와 판정상태
--          ) LIST_JUDGE  : 선택 로트의 판정이력 (TQMJUDGE)
--          ) SAVE_JUDGE  : 판정 등록·수정. 한 로트를 수량 나눠 여러 건 판정할 수 있다
--                          (후처리 안 된 판정수량 합 <= 현재 재고수량)
--          ) SAVE_JUDGE_MULTI: 여러 로트 일괄판정. 로트마다 미판정수량 전부로 판정 1건씩 만든다
--          ) DELETE_JUDGE: 판정 삭제 (후처리 안 된 판정만)
--          ) PRINT_MOVE  : 판정 1건의 공정이동표 (리포트 TQM2001.exe R01, 양식은 TML2010_R01 공정이동표와 같음)
--          ) 판정이력만 만든다. 판정에 따른 후처리(이동·폐기·반출·양품전환)는 다른 화면에서 하고
--            그 화면이 TQMJUDGE.PROCYN 을 'Y' 로 바꾼다.
-- Create: 2026-11-09
-- Modify: 2026-11-09 판정상태를 공통코드(JUDGESTT)로 표시 (JUDGESTTNM 제거)
--         2026-11-09 품목유형(ITEMCG, 공통코드 DM100) 조회조건·조회컬럼 추가 ($ITEMCG 파라미터 추가)
--         2026-11-09 여러 로트 일괄판정 SAVE_JUDGE_MULTI 추가 (파라미터 6개 추가)
--         2026-11-09 판정자를 화면에서 선택 (CALLEMP 대신 $EMPCD_LIST / $EMPCD, 파라미터 2개 추가)
--         2026-11-09 판정이력에 판정자명(EMPNM) 추가, 로그인 사원 이름 조회 INFO_EMP 추가
--         2026-11-09 공정이동표 출력 PRINT_MOVE 추가, SAVE_JUDGE·SAVE_JUDGE_MULTI 가 저장한 판정키(JUDGEKEYS) 반환
--         2026-11-10 발생내용(BADCD, MSTBAD 대분류 폐기 QM210I210N) 추가. 판정유형이 불량이면 필수
--                    (협력사 클레임등록 TQM3001_R01 에서 씀, 파라미터 $BADCD·$BADCD_LIST 2개 추가)
--         2026-11-12 조회조건 생산일자 삭제 (파라미터 $SDATE·$EDATE 삭제)
-- *****************************************************************************
  IN $WARECD VARCHAR(100),            -- 불량창고
  IN $ITEMCG VARCHAR(100),            -- 품목유형 (공통코드 DM100)
  IN $ITEMID VARCHAR(100),            -- 품목ID
  IN $JUDGESTT VARCHAR(10),           -- 판정상태 (공통코드 JUDGESTT: N 미판정 / P 일부판정 / Y 판정완료)
  IN $LOTKEY VARCHAR(100),            -- 로트번호
  IN $LOTKEY_LIST MEDIUMTEXT,         -- 일괄판정 로트번호 목록
  IN $WARECD_LIST MEDIUMTEXT,         -- 일괄판정 창고 목록
  IN $JUDGEDATE VARCHAR(10),          -- 일괄판정 판정일자
  IN $JUDGETP VARCHAR(100),           -- 일괄판정 판정유형
  IN $JUDGEBADTP VARCHAR(100),        -- 일괄판정 불량구분
  IN $BADCD VARCHAR(100),             -- 일괄판정 발생내용 (MSTBAD.BADCD)
  IN $REMARK VARCHAR(1000),           -- 일괄판정 비고
  IN $EMPCD VARCHAR(100),             -- 일괄판정 판정자, 공정이동표 출력자
  IN $JUDGEKEY_LIST MEDIUMTEXT,       -- 판정키 목록 (신규는 ''), 공정이동표는 판정키 1개
  IN $JUDGEDATE_LIST MEDIUMTEXT,      -- 판정일자 목록
  IN $JUDGETP_LIST MEDIUMTEXT,        -- 판정유형 목록
  IN $JUDGEBADTP_LIST MEDIUMTEXT,     -- 불량구분 목록
  IN $BADCD_LIST MEDIUMTEXT,          -- 발생내용 목록
  IN $JUDGEQTY_LIST MEDIUMTEXT,       -- 판정수량 목록
  IN $EMPCD_LIST MEDIUMTEXT,          -- 판정자 목록
  IN $REMARK_LIST MEDIUMTEXT,         -- 비고 목록
-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- *****************************************************************************
  DECLARE _$LOTKEY_LIST MEDIUMTEXT;
  DECLARE _$WARECD_LIST MEDIUMTEXT;
  DECLARE _$LOTKEY VARCHAR(100);
  DECLARE _$WARECD VARCHAR(100);
  DECLARE _$JUDGEKEY_LIST MEDIUMTEXT;
  DECLARE _$JUDGEDATE_LIST MEDIUMTEXT;
  DECLARE _$JUDGETP_LIST MEDIUMTEXT;
  DECLARE _$JUDGEBADTP_LIST MEDIUMTEXT;
  DECLARE _$BADCD_LIST MEDIUMTEXT;
  DECLARE _$JUDGEQTY_LIST MEDIUMTEXT;
  DECLARE _$REMARK_LIST MEDIUMTEXT;
  DECLARE _$EMPCD_LIST MEDIUMTEXT;
  DECLARE _$EMPCD VARCHAR(100);
  DECLARE _$JUDGEKEY VARCHAR(100);
  DECLARE _$JUDGEDATE VARCHAR(10);
  DECLARE _$JUDGETP VARCHAR(100);
  DECLARE _$JUDGEBADTP VARCHAR(100);
  DECLARE _$BADCD VARCHAR(100);
  DECLARE _$JUDGEQTY_TXT VARCHAR(100);
  DECLARE _$JUDGEQTY DECIMAL(20, 8);
  DECLARE _$REMARK VARCHAR(1000);
  DECLARE _$ITEMID INT(11);
  DECLARE _$LOTQTY DECIMAL(20, 8);
  DECLARE _$SUMQTY DECIMAL(20, 8);
  DECLARE _$OLDQTY DECIMAL(20, 8);
  DECLARE _$NEWQTY DECIMAL(20, 8);
  DECLARE _$PRINTKEYS MEDIUMTEXT;    -- 저장한 판정키 (쉼표 구분, 공정이동표 출력용)
  DECLARE _$LVL INT;
-- *****************************************************************************
CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_LOT' THEN  -- 불량재고 목록 (grid1)

  SELECT
      BAD_LOT.WARECD, BAD_LOT.WARENM, BAD_LOT.LOTKEY, BAD_LOT.ITEMCG, BAD_LOT.ITEMCD, BAD_LOT.ITEMNM
    , BAD_LOT.ITEMSPEC, BAD_LOT.PRCNM, BAD_LOT.PRDDATE
    , BAD_LOT.LOTQTY, BAD_LOT.JUDGEQTY, BAD_LOT.LOTQTY - BAD_LOT.JUDGEQTY AS REMAINQTY
    , BAD_LOT.JUDGESTT
    , BAD_LOT.ITEMID
  FROM (
          SELECT
              COMLOT.WARECD
            , IFNULL(MSTWARE.WARENM, COMLOT.WARECD) AS WARENM
            , COMLOT.LOTKEY
            , MSTITEM.ITEMCG
            , MSTITEM.ITEMCD
            , MSTITEM.ITEMNM
            , MSTITEM.ITEMSPEC
            , IFNULL(MSTPRC.PRCNM, COMLOT.PRCCD) AS PRCNM
            , COMLOT.PRDDATE
            , COMLOT.LOTQTY
            , IFNULL(LOT_JUDGE.JUDGEQTY, 0) AS JUDGEQTY
            , CASE -- 판정상태 (공통코드 JUDGESTT)
                WHEN IFNULL(LOT_JUDGE.JUDGEQTY, 0) = 0 THEN 'N'
                WHEN LOT_JUDGE.JUDGEQTY < COMLOT.LOTQTY THEN 'P'
                ELSE 'Y'
              END AS JUDGESTT
            , COMLOT.ITEMID
          FROM COMLOT
          LEFT JOIN MSTWARE
            ON MSTWARE.WARECD = COMLOT.WARECD
          LEFT JOIN MSTITEM
            ON MSTITEM.ITEMID = COMLOT.ITEMID
          LEFT JOIN MSTPRC
            ON MSTPRC.PRCCD = COMLOT.PRCCD
          LEFT JOIN (
                      -- 후처리 안 된 판정수량 합계
                      SELECT
                          TQMJUDGE.LOTKEY
                        , TQMJUDGE.WARECD
                        , SUM(TQMJUDGE.JUDGEQTY) AS JUDGEQTY
                      FROM TQMJUDGE
                      WHERE TQMJUDGE.PROCYN = 'N'
                      GROUP BY TQMJUDGE.LOTKEY, TQMJUDGE.WARECD
                    ) AS LOT_JUDGE
            ON LOT_JUDGE.LOTKEY = COMLOT.LOTKEY
           AND LOT_JUDGE.WARECD = COMLOT.WARECD
          WHERE COMLOT.WARECD IN ('04S130_N', '04S230_N') -- 재공 불량창고, 제품 불량창고
            AND COMLOT.LOTQTY > 0
            AND ($WARECD = '' OR COMLOT.WARECD = $WARECD)
            AND ($ITEMCG = '' OR MSTITEM.ITEMCG = $ITEMCG)
            AND ($ITEMID = '' OR COMLOT.ITEMID = $ITEMID)
       ) AS BAD_LOT
  WHERE ($JUDGESTT = '' OR BAD_LOT.JUDGESTT = $JUDGESTT)
  ORDER BY BAD_LOT.PRDDATE, BAD_LOT.LOTKEY;

-- ****************************************************************************
WHEN 'LIST_JUDGE' THEN  -- 선택 로트의 판정이력 (grid2)

  SELECT
      TQMJUDGE.JUDGEKEY
    , TQMJUDGE.JUDGEDATE
    , TQMJUDGE.JUDGETP
    , TQMJUDGE.JUDGEBADTP
    , TQMJUDGE.BADCD
    , IFNULL(MSTBAD.BADNM, '') AS BADNM
    , TQMJUDGE.JUDGEQTY
    , TQMJUDGE.EMPCD
    , IFNULL(MSTEMP.EMPNM, '') AS EMPNM
    , TQMJUDGE.REMARK
    , TQMJUDGE.PROCYN
  FROM TQMJUDGE
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = TQMJUDGE.EMPCD
  LEFT JOIN MSTBAD
    ON MSTBAD.BADCD = TQMJUDGE.BADCD
  WHERE TQMJUDGE.LOTKEY = $LOTKEY
    AND TQMJUDGE.WARECD = $WARECD
  ORDER BY TQMJUDGE.JUDGEDATE, TQMJUDGE.JUDGEKEY;

-- ****************************************************************************
WHEN 'INFO_EMP' THEN  -- 판정자 기본값(로그인 사원) 이름

  SELECT
      MSTEMP.EMPCD
    , MSTEMP.EMPNM
  FROM MSTEMP
  WHERE MSTEMP.EMPCD = $EMPCD;

-- ****************************************************************************
WHEN 'SAVE_JUDGE' THEN  -- 판정 등록·수정

  IF $LOTKEY = '' OR $WARECD = '' THEN
    CALL COMERR('불량재고를 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 신규 판정은 판정키가 '' 라서 판정키 목록만으로는 건수를 알 수 없다
  IF LENGTH(CONCAT(IFNULL($JUDGEKEY_LIST, ''), IFNULL($JUDGEDATE_LIST, '')
                 , IFNULL($JUDGETP_LIST, ''), IFNULL($JUDGEQTY_LIST, ''))) = 0 THEN
    CALL COMERR('저장할 판정이 없습니다.');
    LEAVE PROC;
  END IF;

  SELECT
      COMLOT.ITEMID
    , COMLOT.LOTQTY
    INTO _$ITEMID, _$LOTQTY
    FROM COMLOT
    WHERE COMLOT.LOTKEY = $LOTKEY
      AND COMLOT.WARECD = $WARECD;

  IF IFNULL(_$LOTQTY, 0) <= 0 THEN
    CALL COMERR(CONCAT('불량재고가 없습니다. 이미 후처리되었을 수 있습니다.'
                      , '\n- 로트번호: ', $LOTKEY
                      )
               );
    LEAVE PROC;
  END IF;

  -- 1. 판정 확인 (쓰기 전에 전부 확인)
  SET _$JUDGEKEY_LIST = $JUDGEKEY_LIST;
  SET _$JUDGEDATE_LIST = $JUDGEDATE_LIST;
  SET _$JUDGETP_LIST = $JUDGETP_LIST;
  SET _$JUDGEBADTP_LIST = $JUDGEBADTP_LIST;
  SET _$BADCD_LIST = $BADCD_LIST;
  SET _$JUDGEQTY_LIST = $JUDGEQTY_LIST;
  SET _$EMPCD_LIST = $EMPCD_LIST;
  SET _$OLDQTY = 0;   -- 수정하는 판정의 기존 수량 합
  SET _$NEWQTY = 0;   -- 저장할 판정수량 합

  WHILE LENGTH(CONCAT(_$JUDGEKEY_LIST, _$JUDGEDATE_LIST, _$JUDGETP_LIST, _$JUDGEQTY_LIST)) > 0 DO
    CALL COMSPLIT(_$JUDGEKEY_LIST, _$JUDGEKEY);
    CALL COMSPLIT(_$JUDGEDATE_LIST, _$JUDGEDATE);
    CALL COMSPLIT(_$JUDGETP_LIST, _$JUDGETP);
    CALL COMSPLIT(_$JUDGEBADTP_LIST, _$JUDGEBADTP);
    CALL COMSPLIT(_$BADCD_LIST, _$BADCD);
    CALL COMSPLIT(_$JUDGEQTY_LIST, _$JUDGEQTY_TXT);
    CALL COMSPLIT(_$EMPCD_LIST, _$EMPCD);
    SET _$JUDGEQTY = CAST(IF(IFNULL(_$JUDGEQTY_TXT, '') = '', '0', _$JUDGEQTY_TXT) AS DECIMAL(20, 8));

    IF IFNULL(_$JUDGEDATE, '') = '' THEN
      CALL COMERR('판정일자를 입력하세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL(_$EMPCD, '') = '' THEN
      CALL COMERR('판정자를 선택하세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL(_$JUDGETP, '') = '' THEN
      CALL COMERR('판정유형을 선택하세요.');
      LEAVE PROC;
    END IF;

    IF _$JUDGETP = 'BAD' AND IFNULL(_$JUDGEBADTP, '') = '' THEN
      CALL COMERR('판정유형이 불량이면 불량구분(1공장/2공장/외주)을 선택하세요.');
      LEAVE PROC;
    END IF;

    IF _$JUDGETP = 'BAD' AND IFNULL(_$BADCD, '') = '' THEN
      CALL COMERR('판정유형이 불량이면 발생내용을 선택하세요.');
      LEAVE PROC;
    END IF;

    -- 발생내용은 대분류 폐기(QM210I210N) 불량코드만
    IF _$JUDGETP = 'BAD' AND NOT EXISTS (SELECT MSTBAD.BADCD
                                           FROM MSTBAD
                                           WHERE MSTBAD.BADCD = _$BADCD
                                             AND MSTBAD.BADTP1 = 'QM210I210N') THEN
      CALL COMERR(CONCAT('발생내용은 대분류가 폐기인 불량코드만 고를 수 있습니다.', '\n- 불량코드: ', _$BADCD));
      LEAVE PROC;
    END IF;

    IF _$JUDGEQTY <= 0 THEN
      CALL COMERR('판정수량을 입력하세요.');
      LEAVE PROC;
    END IF;

    IF IFNULL(_$JUDGEKEY, '') <> '' THEN
      IF NOT EXISTS (SELECT TQMJUDGE.JUDGEKEY
                       FROM TQMJUDGE
                       WHERE TQMJUDGE.JUDGEKEY = _$JUDGEKEY
                         AND TQMJUDGE.LOTKEY = $LOTKEY
                         AND TQMJUDGE.WARECD = $WARECD) THEN
        CALL COMERR(CONCAT('판정이력이 없습니다. 다시 조회하세요.', '\n- 판정키: ', _$JUDGEKEY));
        LEAVE PROC;
      END IF;

      IF EXISTS (SELECT TQMJUDGE.JUDGEKEY
                   FROM TQMJUDGE
                   WHERE TQMJUDGE.JUDGEKEY = _$JUDGEKEY
                     AND TQMJUDGE.PROCYN = 'Y') THEN
        CALL COMERR(CONCAT('후처리된 판정은 수정할 수 없습니다.', '\n- 판정일자: ', _$JUDGEDATE));
        LEAVE PROC;
      END IF;

      SET _$OLDQTY = _$OLDQTY + (SELECT TQMJUDGE.JUDGEQTY
                                   FROM TQMJUDGE
                                   WHERE TQMJUDGE.JUDGEKEY = _$JUDGEKEY);
    END IF;

    SET _$NEWQTY = _$NEWQTY + _$JUDGEQTY;
  END WHILE;

  -- 후처리 안 된 판정수량 합(수정분은 새 수량으로) <= 현재 재고수량
  SET _$SUMQTY = IFNULL((SELECT SUM(TQMJUDGE.JUDGEQTY)
                           FROM TQMJUDGE
                           WHERE TQMJUDGE.LOTKEY = $LOTKEY
                             AND TQMJUDGE.WARECD = $WARECD
                             AND TQMJUDGE.PROCYN = 'N'), 0)
                 - _$OLDQTY + _$NEWQTY;

  IF _$SUMQTY > _$LOTQTY THEN
    CALL COMERR(CONCAT('판정수량 합계가 재고수량을 넘습니다.'
                      , '\n- 재고수량: ', FORMAT(_$LOTQTY, 0)
                      , '\n- 판정수량 합계: ', FORMAT(_$SUMQTY, 0)
                      )
               );
    LEAVE PROC;
  END IF;

  -- 2. 저장
  SET _$JUDGEKEY_LIST = $JUDGEKEY_LIST;
  SET _$JUDGEDATE_LIST = $JUDGEDATE_LIST;
  SET _$JUDGETP_LIST = $JUDGETP_LIST;
  SET _$JUDGEBADTP_LIST = $JUDGEBADTP_LIST;
  SET _$BADCD_LIST = $BADCD_LIST;
  SET _$JUDGEQTY_LIST = $JUDGEQTY_LIST;
  SET _$REMARK_LIST = $REMARK_LIST;
  SET _$EMPCD_LIST = $EMPCD_LIST;
  SET _$PRINTKEYS = '';

  WHILE LENGTH(CONCAT(_$JUDGEKEY_LIST, _$JUDGEDATE_LIST, _$JUDGETP_LIST, _$JUDGEQTY_LIST)) > 0 DO
    CALL COMSPLIT(_$JUDGEKEY_LIST, _$JUDGEKEY);
    CALL COMSPLIT(_$JUDGEDATE_LIST, _$JUDGEDATE);
    CALL COMSPLIT(_$JUDGETP_LIST, _$JUDGETP);
    CALL COMSPLIT(_$JUDGEBADTP_LIST, _$JUDGEBADTP);
    CALL COMSPLIT(_$BADCD_LIST, _$BADCD);
    CALL COMSPLIT(_$JUDGEQTY_LIST, _$JUDGEQTY_TXT);
    CALL COMSPLIT(_$REMARK_LIST, _$REMARK);
    CALL COMSPLIT(_$EMPCD_LIST, _$EMPCD);
    SET _$JUDGEQTY = CAST(_$JUDGEQTY_TXT AS DECIMAL(20, 8));

    -- 불량이 아니면 불량구분·발생내용을 비운다
    IF _$JUDGETP <> 'BAD' THEN
      SET _$JUDGEBADTP = '';
      SET _$BADCD = '';
    END IF;

    IF IFNULL(_$JUDGEKEY, '') = '' THEN
      SET _$JUDGEKEY = GETKEY('JUDGEKEY');  -- 공정이동표 출력에 쓰려고 먼저 채번

      INSERT INTO TQMJUDGE (
          JUDGEKEY
        , JUDGEDATE
        , LOTKEY
        , WARECD
        , ITEMID
        , JUDGETP
        , JUDGEBADTP
        , BADCD
        , JUDGEQTY
        , EMPCD
        , PROCYN
        , REMARK
        , RTIME, REMP, RPRG)
      VALUES (
          _$JUDGEKEY
        , _$JUDGEDATE
        , $LOTKEY
        , $WARECD
        , _$ITEMID
        , _$JUDGETP
        , _$JUDGEBADTP
        , IFNULL(_$BADCD, '')
        , _$JUDGEQTY
        , _$EMPCD
        , 'N'
        , IFNULL(_$REMARK, '')
        , CALLTIME(), CALLEMP(), CALLPRG()
      );
    ELSE
      UPDATE TQMJUDGE
        SET JUDGEDATE = _$JUDGEDATE
          , JUDGETP = _$JUDGETP
          , JUDGEBADTP = _$JUDGEBADTP
          , BADCD = IFNULL(_$BADCD, '')
          , JUDGEQTY = _$JUDGEQTY
          , EMPCD = _$EMPCD
          , REMARK = IFNULL(_$REMARK, '')
          , MTIME = CALLTIME()
          , MEMP = CALLEMP()
          , MPRG = CALLPRG()
        WHERE TQMJUDGE.JUDGEKEY = _$JUDGEKEY;
    END IF;

    SET _$PRINTKEYS = CONCAT(_$PRINTKEYS, IF(_$PRINTKEYS = '', '', ','), _$JUDGEKEY);
  END WHILE;

  -- 저장한 판정키 (화면에서 공정이동표 출력에 씀)
  SELECT _$PRINTKEYS AS JUDGEKEYS;

-- ****************************************************************************
WHEN 'SAVE_JUDGE_MULTI' THEN  -- 여러 로트 일괄판정 (로트마다 미판정수량 전부)

  IF IFNULL($LOTKEY_LIST, '') = '' THEN
    CALL COMERR('일괄판정할 불량재고를 체크하세요.');
    LEAVE PROC;
  END IF;

  IF $JUDGEDATE = '' THEN
    CALL COMERR('판정일자를 입력하세요.');
    LEAVE PROC;
  END IF;

  IF $EMPCD = '' THEN
    CALL COMERR('판정자를 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $JUDGETP = '' THEN
    CALL COMERR('판정유형을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $JUDGETP = 'BAD' AND $JUDGEBADTP = '' THEN
    CALL COMERR('판정유형이 불량이면 불량구분(1공장/2공장/외주)을 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $JUDGETP = 'BAD' AND $BADCD = '' THEN
    CALL COMERR('판정유형이 불량이면 발생내용을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 발생내용은 대분류 폐기(QM210I210N) 불량코드만
  IF $JUDGETP = 'BAD' AND NOT EXISTS (SELECT MSTBAD.BADCD
                                        FROM MSTBAD
                                        WHERE MSTBAD.BADCD = $BADCD
                                          AND MSTBAD.BADTP1 = 'QM210I210N') THEN
    CALL COMERR(CONCAT('발생내용은 대분류가 폐기인 불량코드만 고를 수 있습니다.', '\n- 불량코드: ', $BADCD));
    LEAVE PROC;
  END IF;

  -- 1. 로트마다 미판정수량 확인 (쓰기 전에 전부 확인)
  SET _$LOTKEY_LIST = $LOTKEY_LIST;
  SET _$WARECD_LIST = $WARECD_LIST;

  WHILE LENGTH(_$LOTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT(_$WARECD_LIST, _$WARECD);

    SET _$LOTQTY = 0;  -- SELECT INTO 가 0건이면 이전 로트 값이 남으므로 비운다
    SELECT
        COMLOT.LOTQTY
      INTO _$LOTQTY
      FROM COMLOT
      WHERE COMLOT.LOTKEY = _$LOTKEY
        AND COMLOT.WARECD = _$WARECD;

    SET _$SUMQTY = IFNULL((SELECT SUM(TQMJUDGE.JUDGEQTY)
                             FROM TQMJUDGE
                             WHERE TQMJUDGE.LOTKEY = _$LOTKEY
                               AND TQMJUDGE.WARECD = _$WARECD
                               AND TQMJUDGE.PROCYN = 'N'), 0);

    IF IFNULL(_$LOTQTY, 0) - _$SUMQTY <= 0 THEN
      CALL COMERR(CONCAT('미판정수량이 없습니다. 다시 조회하세요.'
                        , '\n- 로트번호: ', _$LOTKEY
                        )
                 );
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 저장
  SET _$LOTKEY_LIST = $LOTKEY_LIST;
  SET _$WARECD_LIST = $WARECD_LIST;

  -- 불량이 아니면 불량구분·발생내용을 비운다
  SET _$JUDGEBADTP = IF($JUDGETP = 'BAD', $JUDGEBADTP, '');
  SET _$BADCD = IF($JUDGETP = 'BAD', $BADCD, '');
  SET _$PRINTKEYS = '';

  WHILE LENGTH(_$LOTKEY_LIST) > 0 DO
    CALL COMSPLIT(_$LOTKEY_LIST, _$LOTKEY);
    CALL COMSPLIT(_$WARECD_LIST, _$WARECD);

    SELECT
        COMLOT.ITEMID
      , COMLOT.LOTQTY
      INTO _$ITEMID, _$LOTQTY
      FROM COMLOT
      WHERE COMLOT.LOTKEY = _$LOTKEY
        AND COMLOT.WARECD = _$WARECD;

    SET _$SUMQTY = IFNULL((SELECT SUM(TQMJUDGE.JUDGEQTY)
                             FROM TQMJUDGE
                             WHERE TQMJUDGE.LOTKEY = _$LOTKEY
                               AND TQMJUDGE.WARECD = _$WARECD
                               AND TQMJUDGE.PROCYN = 'N'), 0);

    SET _$JUDGEKEY = GETKEY('JUDGEKEY');  -- 공정이동표 출력에 쓰려고 먼저 채번

    INSERT INTO TQMJUDGE (
        JUDGEKEY
      , JUDGEDATE
      , LOTKEY
      , WARECD
      , ITEMID
      , JUDGETP
      , JUDGEBADTP
      , BADCD
      , JUDGEQTY
      , EMPCD
      , PROCYN
      , REMARK
      , RTIME, REMP, RPRG)
    VALUES (
        _$JUDGEKEY
      , $JUDGEDATE
      , _$LOTKEY
      , _$WARECD
      , _$ITEMID
      , $JUDGETP
      , _$JUDGEBADTP
      , _$BADCD
      , _$LOTQTY - _$SUMQTY
      , $EMPCD
      , 'N'
      , IFNULL($REMARK, '')
      , CALLTIME(), CALLEMP(), CALLPRG()
    );

    SET _$PRINTKEYS = CONCAT(_$PRINTKEYS, IF(_$PRINTKEYS = '', '', ','), _$JUDGEKEY);
  END WHILE;

  -- 저장한 판정키 (화면에서 공정이동표 출력에 씀)
  SELECT _$PRINTKEYS AS JUDGEKEYS;

-- ****************************************************************************
WHEN 'DELETE_JUDGE' THEN  -- 판정 삭제

  IF IFNULL($JUDGEKEY_LIST, '') = '' THEN
    CALL COMERR('삭제할 판정을 선택하세요.');
    LEAVE PROC;
  END IF;

  -- 1. 후처리된 판정이 섞여 있으면 막는다
  SET _$JUDGEKEY_LIST = $JUDGEKEY_LIST;

  WHILE LENGTH(_$JUDGEKEY_LIST) > 0 DO
    CALL COMSPLIT(_$JUDGEKEY_LIST, _$JUDGEKEY);

    IF EXISTS (SELECT TQMJUDGE.JUDGEKEY
                 FROM TQMJUDGE
                 WHERE TQMJUDGE.JUDGEKEY = _$JUDGEKEY
                   AND TQMJUDGE.PROCYN = 'Y') THEN
      CALL COMERR('후처리된 판정은 삭제할 수 없습니다.');
      LEAVE PROC;
    END IF;
  END WHILE;

  -- 2. 삭제
  SET _$JUDGEKEY_LIST = $JUDGEKEY_LIST;

  WHILE LENGTH(_$JUDGEKEY_LIST) > 0 DO
    CALL COMSPLIT(_$JUDGEKEY_LIST, _$JUDGEKEY);

    DELETE
      FROM TQMJUDGE
      WHERE TQMJUDGE.JUDGEKEY = _$JUDGEKEY
        AND TQMJUDGE.PROCYN = 'N';
  END WHILE;

-- ****************************************************************************
-- 공정이동표 (판정 1건에 1장, 리포트 TQM2001.exe R01)
-- 양식·로트추적은 TML2010_R01 PRINT_MOVE 와 같고, 수량은 판정수량, 로트추적 첫 줄은 판정이력
-- ****************************************************************************
WHEN 'PRINT_MOVE' THEN  -- 판정 공정이동표

  IF IFNULL($JUDGEKEY_LIST, '') = '' THEN
    CALL COMERR('판정키가 없습니다.');
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT TQMJUDGE.JUDGEKEY
                   FROM TQMJUDGE
                   WHERE TQMJUDGE.JUDGEKEY = $JUDGEKEY_LIST) THEN
    CALL COMERR(CONCAT('판정이력이 없습니다.', '\n- 판정키: ', $JUDGEKEY_LIST));
    LEAVE PROC;
  END IF;

  -- 0. 생산품·생산정보·로트 (수량은 판정수량)
  SELECT
      MSTITEM.ITEMCD
    , MSTITEM.ITEMNM
    , MSTITEM.ITEMSPEC
    , '' AS HEATNO       -- TML2010_R01 과 같이 아직 빈값
    , '' AS HEATLOTKEY
    , IFNULL(PRDWORK.WORKDATE, IFNULL(COMLOT.PRDDATE, '')) AS PRDDATE
    , IFNULL(MSTEMP.EMPNM, IFNULL(PRDRST.EMPCD, '')) AS EMPNM
    , IFNULL(LEFT(PRDRST.RSTTIME, 16), '') AS RSTTIME
    , TQMJUDGE.LOTKEY
    , IFNULL(MSTLINE.LINENM, IFNULL(PRDRST.LINECD, '')) AS LINENM
    , IFNULL(MSTPRC.PRCNM, '') AS PRCNM
    , IFNULL(MSTLINE_EQM.EQMNM, '') AS EQMNM
    , IFNULL(GPCD('DM150', MSTITEM.ITEMUNIT), '') AS UNITNM
    , FORMAT(TQMJUDGE.JUDGEQTY, 0) AS QTY
    , IFNULL((SELECT MSTEMP.EMPNM FROM MSTEMP WHERE MSTEMP.EMPCD = $EMPCD LIMIT 1), $EMPCD) AS PRINTEMPNM
    , CALLTIME() AS PRINTTIME
  FROM TQMJUDGE
  INNER JOIN MSTITEM
    ON MSTITEM.ITEMID = TQMJUDGE.ITEMID
  LEFT JOIN COMLOT
    ON COMLOT.LOTKEY = TQMJUDGE.LOTKEY
   AND COMLOT.WARECD = TQMJUDGE.WARECD
  LEFT JOIN PRDRSTLOT
    ON PRDRSTLOT.LOTKEY = TQMJUDGE.LOTKEY
  LEFT JOIN PRDRST
    ON PRDRST.PRDRSTKEY = PRDRSTLOT.PRDRSTKEY
  LEFT JOIN PRDWORK
    ON PRDWORK.PRDWORKKEY = PRDRST.PRDWORKKEY
  LEFT JOIN MSTEMP
    ON MSTEMP.EMPCD = PRDRST.EMPCD
  LEFT JOIN MSTLINE
    ON MSTLINE.LINECD = PRDRST.LINECD
  LEFT JOIN MSTPRC
    ON MSTPRC.PRCCD = IFNULL(PRDRST.PRCCD, COMLOT.PRCCD)
  LEFT JOIN MSTLINE_EQM
    ON MSTLINE_EQM.EQMCD = PRDRST.EQMCD
  WHERE TQMJUDGE.JUDGEKEY = $JUDGEKEY_LIST
  LIMIT 1
  ;

  -- 1. 로트추적: 첫 줄은 판정이력, 그 다음 판정한 로트부터 투입로트를 거슬러 원소재까지
  --    (TML2010_R01 PRINT_MOVE 와 같은 방식: 사내 실적 PRDRSTLOT → PRDRSTUSE, 외주 실적 OSCRSTLOT → OSCRSTUSE, 둘 다 없으면 원소재)
  DROP TABLE IF EXISTS TEMP_TRACE;
  CREATE TEMPORARY TABLE TEMP_TRACE (
    SEQ    INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    LVL    INT NOT NULL,
    LOTKEY VARCHAR(100) NOT NULL,
    RSTTP  VARCHAR(1) NOT NULL,     -- J 판정, P 사내, O 외주, '' 원소재
    RSTKEY VARCHAR(100) NOT NULL
  );

  DROP TABLE IF EXISTS TEMP_CUR;
  CREATE TEMPORARY TABLE TEMP_CUR (
    LOTKEY VARCHAR(100) NOT NULL,
    RSTTP  VARCHAR(1) NOT NULL,
    RSTKEY VARCHAR(100) NOT NULL
  );

  DROP TABLE IF EXISTS TEMP_NEXT;
  CREATE TEMPORARY TABLE TEMP_NEXT (
    LOTKEY VARCHAR(100) NOT NULL
  );

  -- 판정이력 (첫 줄)
  INSERT INTO TEMP_TRACE (LVL, LOTKEY, RSTTP, RSTKEY)
  SELECT -1, TQMJUDGE.LOTKEY, 'J', TQMJUDGE.JUDGEKEY
  FROM TQMJUDGE
  WHERE TQMJUDGE.JUDGEKEY = $JUDGEKEY_LIST;

  -- 판정한 로트를 만든 실적 (사내 → 외주 → 원소재 순으로 찾음)
  INSERT INTO TEMP_CUR (LOTKEY, RSTTP, RSTKEY)
  SELECT
      JUDGELOT.LOTKEY
    , IF(JUDGELOT.PRDRSTKEY <> '', 'P', IF(JUDGELOT.OSCRSTKEY <> '', 'O', ''))
    , IF(JUDGELOT.PRDRSTKEY <> '', JUDGELOT.PRDRSTKEY, JUDGELOT.OSCRSTKEY)
  FROM (SELECT
            TQMJUDGE.LOTKEY
          , IFNULL((SELECT PRDRSTLOT.PRDRSTKEY FROM PRDRSTLOT WHERE PRDRSTLOT.LOTKEY = TQMJUDGE.LOTKEY LIMIT 1), '') AS PRDRSTKEY
          , IFNULL((SELECT OSCRSTLOT.OSCRSTKEY FROM OSCRSTLOT WHERE OSCRSTLOT.LOTKEY = TQMJUDGE.LOTKEY LIMIT 1), '') AS OSCRSTKEY
        FROM TQMJUDGE
        WHERE TQMJUDGE.JUDGEKEY = $JUDGEKEY_LIST) AS JUDGELOT;

  SET _$LVL = 0;
  WHILE _$LVL < 30 AND EXISTS (SELECT TEMP_CUR.LOTKEY FROM TEMP_CUR) DO  -- 30단계 넘으면 끊음 (잘못된 순환 방지)
    INSERT INTO TEMP_TRACE (LVL, LOTKEY, RSTTP, RSTKEY)
    SELECT _$LVL, TEMP_CUR.LOTKEY, TEMP_CUR.RSTTP, TEMP_CUR.RSTKEY
    FROM TEMP_CUR
    ORDER BY TEMP_CUR.LOTKEY;

    -- 이번 단계 로트를 만든 실적의 투입로트
    DELETE FROM TEMP_NEXT;

    INSERT INTO TEMP_NEXT (LOTKEY)
    SELECT PRDRSTUSE.USELOTKEY
    FROM PRDRSTUSE
    INNER JOIN TEMP_CUR
      ON TEMP_CUR.RSTTP = 'P'
     AND TEMP_CUR.RSTKEY = PRDRSTUSE.PRDRSTKEY;

    INSERT INTO TEMP_NEXT (LOTKEY)
    SELECT OSCRSTUSE.USELOTKEY
    FROM OSCRSTUSE
    INNER JOIN TEMP_CUR
      ON TEMP_CUR.RSTTP = 'O'
     AND TEMP_CUR.RSTKEY = OSCRSTUSE.OSCRSTKEY;

    -- 다음 단계: 투입로트마다 그 로트를 만든 실적 (사내 → 외주 → 원소재 순으로 찾음)
    DELETE FROM TEMP_CUR;

    INSERT INTO TEMP_CUR (LOTKEY, RSTTP, RSTKEY)
    SELECT
        NEXTLOT.LOTKEY
      , IF(NEXTLOT.PRDRSTKEY <> '', 'P', IF(NEXTLOT.OSCRSTKEY <> '', 'O', ''))
      , IF(NEXTLOT.PRDRSTKEY <> '', NEXTLOT.PRDRSTKEY, NEXTLOT.OSCRSTKEY)
    FROM (SELECT DISTINCT
              TEMP_NEXT.LOTKEY
            , IFNULL((SELECT PRDRSTLOT.PRDRSTKEY FROM PRDRSTLOT WHERE PRDRSTLOT.LOTKEY = TEMP_NEXT.LOTKEY LIMIT 1), '') AS PRDRSTKEY
            , IFNULL((SELECT OSCRSTLOT.OSCRSTKEY FROM OSCRSTLOT WHERE OSCRSTLOT.LOTKEY = TEMP_NEXT.LOTKEY LIMIT 1), '') AS OSCRSTKEY
          FROM TEMP_NEXT) AS NEXTLOT;

    SET _$LVL = _$LVL + 1;
  END WHILE;

  -- 품번, 작업장(판정 = 품질판정, 사내 = 작업장명, 외주 = 외주처명), 공정(판정 = 판정유형(불량구분), 사내 = 실적공정, 외주 = 로트의 공정)
  -- 원소재는 품번·로트번호만
  SELECT
      TEMP_TRACE.SEQ AS NO
    , IFNULL(MSTITEM.ITEMCD, '') AS ITEMCD
    , CASE
        WHEN TEMP_TRACE.RSTTP = 'J' THEN '품질판정'
        WHEN TEMP_TRACE.RSTTP = 'P' THEN IFNULL(MSTLINE.LINENM, PRDRST.LINECD)
        WHEN TEMP_TRACE.RSTTP = 'O' THEN IFNULL(MSTCUST.CUSTNM, OSCRST.CUSTCD)
      ELSE '' END AS LINENM
    , CASE
        WHEN TEMP_TRACE.RSTTP = 'J' THEN CONCAT(IFNULL(GPCD('JUDGETP', TQMJUDGE.JUDGETP), TQMJUDGE.JUDGETP)
                                               , IF(TQMJUDGE.JUDGEBADTP = '', ''
                                                   , CONCAT('(', IFNULL(GPCD('JUDGEBADTP', TQMJUDGE.JUDGEBADTP), TQMJUDGE.JUDGEBADTP), ')')))
        WHEN TEMP_TRACE.RSTTP = '' THEN ''
      ELSE IFNULL(MSTPRC.PRCNM, '') END AS PRCNM
    , TEMP_TRACE.LOTKEY
  FROM TEMP_TRACE
  LEFT JOIN TQMJUDGE
    ON TEMP_TRACE.RSTTP = 'J'
   AND TQMJUDGE.JUDGEKEY = TEMP_TRACE.RSTKEY
  LEFT JOIN PRDRST
    ON TEMP_TRACE.RSTTP = 'P'
   AND PRDRST.PRDRSTKEY = TEMP_TRACE.RSTKEY
  LEFT JOIN OSCRST
    ON TEMP_TRACE.RSTTP = 'O'
   AND OSCRST.OSCRSTKEY = TEMP_TRACE.RSTKEY
  LEFT JOIN MSTITEM
    ON MSTITEM.ITEMID = COALESCE(TQMJUDGE.ITEMID, PRDRST.ITEMID, OSCRST.ITEMID, (SELECT COMLOT.ITEMID FROM COMLOT WHERE COMLOT.LOTKEY = TEMP_TRACE.LOTKEY LIMIT 1))
  LEFT JOIN MSTLINE
    ON MSTLINE.LINECD = PRDRST.LINECD
  LEFT JOIN MSTCUST
    ON MSTCUST.CUSTCD = OSCRST.CUSTCD
  LEFT JOIN MSTPRC
    ON MSTPRC.PRCCD = IF(TEMP_TRACE.RSTTP = 'P', PRDRST.PRCCD, (SELECT COMLOT.PRCCD FROM COMLOT WHERE COMLOT.LOTKEY = TEMP_TRACE.LOTKEY LIMIT 1))
  ORDER BY TEMP_TRACE.SEQ
  ;

  DROP TABLE IF EXISTS TEMP_TRACE;
  DROP TABLE IF EXISTS TEMP_CUR;
  DROP TABLE IF EXISTS TEMP_NEXT;

-- ****************************************************************************
END CASE;  END
