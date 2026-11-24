CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`EQM1001_R01`(
-- *****************************************************************************
-- Comment: 설비이력관리 
-- Create: 	2025-06-24  	생성 			이대규
-- Modify: 	2026-09-16 		마이그레이션	한성수
-- 			2026-09-16 					한성수	MSTEQM.FANO 바인딩 변경 및 서식 정리
-- 			2026-10-06 					한성수	작업자 조회·입력값 검증 보완 및 미사용 정리
-- 			2026-11-09 					한성수	수리이력 사진(EQMREP_IMG) 조회·등록·삭제 추가
-- 			2026-11-13 					한성수	2공장 설비 분류 컬럼·검색 조건 추가
-- 			2026-11-19 					한성수	공무작업일지 등록·조회 추가 및 수리키 형식 변경
-- 			2026-11-20 					한성수	공무작업일지 조회·삭제·출력 정비, 비가동 자동연결 및 미사용 분기 제거
-- 			2026-11-23 					한성수	부품 선택(LIST_PART) 2공장 재고 등록 품목 기준으로 변경
-- 			2026-11-24 					한성수	공무작업일지 수리시간 반환, 등록일자 기준 조회 및 작업자 중복 확인
-- 			2026-11-24 					한성수	부품 선택(LIST_PART) 수리시작일 ~ 종료일에 수리 설비로 출고된 부품 출고이력 기준으로 변경
-- *****************************************************************************
  IN $SDATE            VARCHAR(10),     -- 조회 시작일자
  IN $EDATE            VARCHAR(10),     -- 조회 종료일자
  IN $LINECD           VARCHAR(20),     -- 작업장
  IN $EQMTP            VARCHAR(20),     -- 설비구분
  IN $EQMGROUP1        VARCHAR(20),     -- 설비대분류
  IN $EQMCD            VARCHAR(20),     -- 설비코드
  IN $EMPCD            VARCHAR(20),     -- 사원코드
  IN $EQMREPKEY        VARCHAR(20),     -- 설비수리키
  IN $MALFUNCTION      VARCHAR(1000),   -- 고장내용
  IN $HANDLE           VARCHAR(1000),   -- 조치내용
  IN $FILEKEY          VARCHAR(100),    -- 사진 파일키
  IN $WORKTP           VARCHAR(20),     -- 작업구분 (FM300)
  IN $FAILTP           VARCHAR(20),     -- 고장유형 (FM307)
  IN $FAILPART         VARCHAR(20),     -- 고장부위 (FM303)
  IN $STOPTP           VARCHAR(20),     -- 중단구분 (FM304)
  IN $PRDNONKEY        VARCHAR(20),     -- 비가동키
  IN $CAUSE            VARCHAR(1000),   -- 원인분석
  IN $PREVENT          VARCHAR(1000),   -- 특이사항 및 재발방지대책

  IN $EMPCD_LIST       MEDIUMTEXT,
  IN $EQMREPKEY_LIST   MEDIUMTEXT,      -- 공무작업일지 삭제 수리키 목록
  IN $PARTQTY_LIST     MEDIUMTEXT,
  IN $PARTTP_LIST      MEDIUMTEXT,      -- 사용부품 구분 (OUT / SPECIAL)
  IN $INOUTKEY_LIST    MEDIUMTEXT,      -- 사용부품 출고키
  IN $ITEMID_LIST      MEDIUMTEXT,      -- 사용부품 품목ID
  IN $PARTNM_LIST      MEDIUMTEXT,      -- 사용부품 부품명
  IN $PARTSPEC_LIST    MEDIUMTEXT,      -- 사용부품 규격
  IN $PARTUNIT_LIST    MEDIUMTEXT,      -- 사용부품 단위 (DM150)
  IN $PARTREMARK_LIST  MEDIUMTEXT,      -- 사용부품 비고
  IN $INOUTDATE_LIST   MEDIUMTEXT,      -- 사용부품 출고일자

-- *****************************************************************************
  IN $CALLTYPE         VARCHAR(50),
  IN $KEYWORD          VARCHAR(1000)
)
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************
  DECLARE _$EMPCD       VARCHAR(100);
  DECLARE _$EMPCD_LIST  MEDIUMTEXT;
  DECLARE _$EQMREPKEY   VARCHAR(20);
  DECLARE _$FIRSTEMP    VARCHAR(100);
  DECLARE _$LIST1       MEDIUMTEXT;
  DECLARE _$LIST2       MEDIUMTEXT;
  DECLARE _$LIST3       MEDIUMTEXT;
  DECLARE _$LIST4       MEDIUMTEXT;
  DECLARE _$LIST5       MEDIUMTEXT;
  DECLARE _$LIST6       MEDIUMTEXT;
  DECLARE _$LIST7       MEDIUMTEXT;
  DECLARE _$LIST8       MEDIUMTEXT;
  DECLARE _$LIST9       MEDIUMTEXT;
  DECLARE _$PARTTP      VARCHAR(100);
  DECLARE _$INOUTKEY    VARCHAR(100);
  DECLARE _$ITEMID      VARCHAR(100);
  DECLARE _$PARTNM      VARCHAR(1000);
  DECLARE _$PARTSPEC    VARCHAR(1000);
  DECLARE _$PARTQTY     VARCHAR(100);
  DECLARE _$PARTUNIT    VARCHAR(100);
  DECLARE _$PARTREMARK  VARCHAR(1000);
  DECLARE _$INOUTDATE   VARCHAR(100);
  DECLARE _$SEQ         INT DEFAULT 0;
  DECLARE _$PRDNONKEY   VARCHAR(20);

CASE $CALLTYPE

-- *****************************************************************************
WHEN 'LIST_EQMREP' THEN  -- 공무작업일지 목록 (작성된 일지만)

  SELECT
    EQMREP.EQMREPKEY,                    -- 설비수리키
    MSTEQM.FACTORYCD,                    -- 공장
    MSTEQM.LINECD,                       -- 작업장
    MSTEQM.EQMTP,                        -- 설비구분
    MSTEQM.EQMGROUP1,                    -- 설비대분류
    EQMREP.EQMCD,                        -- 설비코드
    MSTEQM.EQMNM,                        -- 설비명
    LEFT(EQMREP.REPSTIME, 10) AS REPSDAY,-- 수리시작일자
    SUBSTRING(EQMREP.REPSTIME, 12, 5) AS REPSTIME,-- 수리시작시간
    LEFT(EQMREP.REPETIME, 10) AS REPEDAY,-- 수리종료일자
    SUBSTRING(EQMREP.REPETIME, 12, 5) AS REPETIME,-- 수리종료시간
    IF(EQMREP.REPETIME = '', 0, TIMESTAMPDIFF(MINUTE, EQMREP.REPSTIME, EQMREP.REPETIME)) AS REPMIN -- 수리시간(분)
  FROM EQMREP
  INNER JOIN MSTEQM ON MSTEQM.FANO = EQMREP.EQMCD
  WHERE EQMREP.REGTIME BETWEEN CONCAT($SDATE, ' 00:00') AND CONCAT($EDATE, ' 23:59:59')
    AND MSTEQM.FACTORYCD = '07'
    AND ($LINECD = '' OR MSTEQM.LINECD = $LINECD)
    AND ($EQMTP = '' OR MSTEQM.EQMTP = $EQMTP)
    AND ($EQMGROUP1 = '' OR MSTEQM.EQMGROUP1 = $EQMGROUP1)
    AND EQMREP.EQMCD LIKE CONCAT('%', $EQMCD, '%')
    AND ($EMPCD = '' OR EXISTS (SELECT 1 FROM EQMREP_EMP WHERE EQMREP_EMP.EQMREPKEY = EQMREP.EQMREPKEY AND EQMREP_EMP.EMPCD = $EMPCD))
    AND EQMREP.EQMREPTP = 'EQM01'
    AND EQMREP.WORKTP <> ''  -- 공무작업일지를 작성한 수리 기록만 (새 작성은 [추가] → LIST_REP_WAIT)
  ORDER BY EQMREP.REGTIME, EQMREP.EQMREPKEY;

-- *****************************************************************************
WHEN 'LIST_PART' THEN  -- 공무작업일지 부품 선택 목록 = 부품 출고이력 (수리시작일 ~ 수리종료일에 수리 설비로 출고된 설비부품 출고, INOUT_EQMPARTS OUT)
  SELECT
    I.INOUTKEY,                           -- 출고키
    I.INOUTDATE,                          -- 출고일자
    I.ITEMID,
    IFNULL(T.ITEMCD, '') AS ITEMCD,
    IFNULL(T.ITEMNM, '') AS ITEMNM,
    IFNULL(T.ITEMSPEC, '') AS ITEMSPEC,
    IFNULL(T.ITEMUNIT, '') AS ITEMUNIT,   -- 단위 (공통코드 DM150)
    I.INOUTQTY,                           -- 출고수량
    I.REMARK                              -- 출고 비고
  FROM EQMREP AS R
  INNER JOIN INOUT_EQMPARTS AS I
    ON I.INOROUT = 'OUT'
   AND I.EQMCD = R.EQMCD
   AND I.INOUTDATE BETWEEN LEFT(R.REPSTIME, 10) AND IF(R.REPETIME = '', LEFT(R.REPSTIME, 10), LEFT(R.REPETIME, 10))  -- 수리시작일 ~ 수리종료일
  LEFT JOIN MSTITEM AS T ON T.ITEMID = I.ITEMID
  WHERE R.EQMREPKEY = $EQMREPKEY
  ORDER BY I.INOUTKEY;

-- *****************************************************************************
WHEN 'LIST_REP_WAIT' THEN  -- 공무작업일지 등록할 수리 기록 (수리가 끝났고 작업일지 미작성, 등록일자가 조회기간 안 = 목록 LIST_EQMREP 와 같은 기준)
  SELECT
    R.EQMREPKEY,
    LEFT(R.REPSTIME, 16) AS REPSTIME,
    LEFT(R.REPETIME, 16) AS REPETIME,
    TIMESTAMPDIFF(MINUTE, R.REPSTIME, R.REPETIME) AS REPMIN,
    M.LINECD,
    R.EQMCD,
    IFNULL(M.EQMNM, R.EQMCD) AS EQMNM,
    IF(R.EQMCALLKEY = '', '직접 수리', '호출') AS REPGUBUN,
    IFNULL((SELECT GROUP_CONCAT(IFNULL(P.EMPNM, W.EMPCD) ORDER BY (W.EMPCD = R.EMPCD) DESC, W.RTIME, W.EMPCD SEPARATOR ', ')
              FROM EQMREP_EMP AS W
              LEFT JOIN MSTEMP AS P ON P.EMPCD = W.EMPCD
             WHERE W.EQMREPKEY = R.EQMREPKEY), '') AS EMPNMS,
    R.MALFUNCTION
  FROM EQMREP AS R
  INNER JOIN MSTEQM AS M ON M.FANO = R.EQMCD
  WHERE R.EQMREPTP = 'EQM01'
    AND R.REPETIME <> ''
    AND R.WORKTP = ''
    AND M.FACTORYCD = '07'
    AND R.REGTIME BETWEEN CONCAT($SDATE, ' 00:00') AND CONCAT($EDATE, ' 23:59:59')
    AND ($LINECD = '' OR M.LINECD = $LINECD)
    AND ($EQMTP = '' OR M.EQMTP = $EQMTP)
    AND ($EQMGROUP1 = '' OR M.EQMGROUP1 = $EQMGROUP1)
    AND R.EQMCD LIKE CONCAT('%', $EQMCD, '%')
  ORDER BY R.REPETIME DESC, R.EQMREPKEY;

-- *****************************************************************************
WHEN 'GET_EQMREP_WORK' THEN  -- 공무작업일지 조회 (화면 가운데 공무작업일지, [0] 수리 기록·작업일지, [1] 작업자, [2] 사용 부품)
  -- 작업일지 미작성(작업구분 빈값)이고 비가동이 연결되지 않은 수리는 수리 설비 생산라인의 비가동 중 수리시간과 가장 많이 겹친 것을 자동 연결값으로 반환 (NONAUTO = 'Y', 저장해야 반영)
  SET _$PRDNONKEY = IFNULL((SELECT PRDNONKEY FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY), '');
  IF _$PRDNONKEY = '' AND EXISTS (SELECT 1 FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY AND WORKTP = '' AND REPETIME <> '') THEN
    SET _$PRDNONKEY = IFNULL((
      SELECT N.PRDNONKEY
        FROM EQMREP AS R
       INNER JOIN MSTEQM_MATCH AS X ON X.FANO = R.EQMCD
       INNER JOIN PRDRSTNON AS N ON N.EQMCD = X.EQMCD
       WHERE R.EQMREPKEY = $EQMREPKEY
         AND N.NONSTIME < R.REPETIME
         AND (N.NONETIME = '' OR N.NONETIME > R.REPSTIME)
       ORDER BY TIMESTAMPDIFF(MINUTE, GREATEST(N.NONSTIME, R.REPSTIME), LEAST(IF(N.NONETIME = '', R.REPETIME, N.NONETIME), R.REPETIME)) DESC,
                ABS(TIMESTAMPDIFF(MINUTE, N.NONSTIME, R.REPSTIME)), N.PRDNONKEY
       LIMIT 1), '');
  END IF;

  SELECT
    R.EQMREPKEY,
    R.EQMCD,
    R.WORKTP,
    R.FAILTP,
    R.FAILPART,
    R.STOPTP,
    LEFT(R.REPSTIME, 10)        AS REPSDAY,
    SUBSTRING(R.REPSTIME, 12, 5) AS REPSTIME,
    LEFT(R.REPETIME, 10)        AS REPEDAY,
    SUBSTRING(R.REPETIME, 12, 5) AS REPETIME,
    IF(R.REPETIME = '', 0, GREATEST(TIMESTAMPDIFF(MINUTE, R.REPSTIME, R.REPETIME), 0)) AS REPMIN, -- 수리시간(분), 종료가 시작보다 빠르면 0
    _$PRDNONKEY                 AS PRDNONKEY,
    IF(R.PRDNONKEY = '' AND _$PRDNONKEY <> '', 'Y', 'N') AS NONAUTO, -- 자동 연결값 (아직 저장 안 됨)
    IFNULL(NON.NONINFO, '')     AS NONINFO,
    LEFT(IFNULL(NON.NONSTIME, ''), 10)        AS NONSDAY,  -- 비가동 발생일자
    SUBSTRING(IFNULL(NON.NONSTIME, ''), 12, 5) AS NONSTIME, -- 비가동 발생시간
    LEFT(IFNULL(NON.NONETIME, ''), 10)        AS NONEDAY,  -- 비가동 종료일자 (진행 중이면 빈값)
    SUBSTRING(IFNULL(NON.NONETIME, ''), 12, 5) AS NONETIME, -- 비가동 종료시간
    IFNULL(NON.STOPMIN, 0)      AS STOPMIN,
    R.MALFUNCTION,
    R.CAUSE,
    R.HANDLE,
    R.PREVENT
  FROM EQMREP AS R
  LEFT JOIN (
    SELECT
      N.PRDNONKEY,
      CONCAT(IFNULL(MAX(M.NONNM), MAX(N.NONCD)), IF(MAX(N.NONETIME) = '', ' (진행 중)', '')) AS NONINFO, -- 비가동 유형
      MAX(N.NONSTIME) AS NONSTIME,
      MAX(N.NONETIME) AS NONETIME,
      IF(MAX(N.NONETIME) = '', 0, TIMESTAMPDIFF(MINUTE, MAX(N.NONSTIME), MAX(N.NONETIME))) AS STOPMIN
    FROM PRDRSTNON AS N
    LEFT JOIN MSTNON AS M ON M.LINECD = N.LINECD AND M.NONCD = N.NONCD
    WHERE N.PRDNONKEY = _$PRDNONKEY
    GROUP BY N.PRDNONKEY
  ) AS NON ON NON.PRDNONKEY = _$PRDNONKEY
  WHERE R.EQMREPKEY = $EQMREPKEY
    AND R.EQMREPTP = 'EQM01';

  SELECT
    W.EMPCD,
    IFNULL(P.EMPNM, W.EMPCD) AS EMPNM
  FROM EQMREP_EMP AS W
  INNER JOIN EQMREP AS R ON R.EQMREPKEY = W.EQMREPKEY
  LEFT JOIN MSTEMP AS P ON P.EMPCD = W.EMPCD
  WHERE W.EQMREPKEY = $EQMREPKEY
  ORDER BY (W.EMPCD = R.EMPCD) DESC, W.RTIME, W.EMPCD;  -- 대표 작업자가 첫 번째

  SELECT
    P.PARTTP,
    CASE P.PARTTP WHEN 'OUT' THEN '출고' WHEN 'PART' THEN '부품' ELSE '스페셜' END AS PARTTPNM,
    P.INOUTKEY,
    P.ITEMID,
    P.INOUTDATE,
    P.PARTNM,
    P.PARTSPEC,
    P.PARTQTY,
    P.PARTUNIT,
    P.REMARK
  FROM EQMREP_PART AS P
  WHERE P.EQMREPKEY = $EQMREPKEY
  ORDER BY P.SEQ;

-- *****************************************************************************
WHEN 'ADD_EQMREP_WORK' THEN  -- 공무작업일지 저장 = 수리 기록(태블릿 수리시작·종료로 생긴 EQMREP)에 공무작업일지 항목 기록 (EQMREP, EQMREP_EMP, EQMREP_PART)
  -- 새 수리 기록은 만들지 않음: 설비·수리시작/종료·소요일은 수리 기록 값 그대로, 수리가 끝난 기록만
  -- 필수: 수리 기록, 작업구분, 작업자 / 대표 작업자(EQMREP.EMPCD) = 첫 번째 작업자, 작업자·사용 부품은 화면 목록으로 다시 저장
  -- 등록일시·수리업체·금액·수리유형·비고는 그대로
  SET $EQMREPKEY = TRIM(IFNULL($EQMREPKEY, ''));
  IF $EQMREPKEY = '' OR NOT EXISTS (SELECT 1 FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY AND EQMREPTP = 'EQM01') THEN
    CALL COMERR('공무작업일지를 등록할 수리 기록을 선택하세요.');
    LEAVE PROC;
  END IF;
  IF EXISTS (SELECT 1 FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY AND REPETIME = '') THEN
    CALL COMERR(CONCAT('수리가 끝나지 않은 기록입니다.', '\n태블릿에서 수리종료 후 등록하세요.'));
    LEAVE PROC;
  END IF;

  IF NOT EXISTS (SELECT 1 FROM COMTYPE WHERE GPCD = 'FM300' AND TPCD = $WORKTP) THEN
    CALL COMERR('작업구분을 선택하세요.');
    LEAVE PROC;
  END IF;
  IF $FAILTP <> '' AND NOT EXISTS (SELECT 1 FROM COMTYPE WHERE GPCD = 'FM307' AND TPCD = $FAILTP) THEN
    CALL COMERR('고장유형을 다시 선택하세요.');
    LEAVE PROC;
  END IF;
  IF $FAILPART <> '' AND NOT EXISTS (SELECT 1 FROM COMTYPE WHERE GPCD = 'FM303' AND TPCD = $FAILPART) THEN
    CALL COMERR('고장부위를 다시 선택하세요.');
    LEAVE PROC;
  END IF;
  IF $STOPTP <> '' AND NOT EXISTS (SELECT 1 FROM COMTYPE WHERE GPCD = 'FM304' AND TPCD = $STOPTP) THEN
    CALL COMERR('중단구분을 다시 선택하세요.');
    LEAVE PROC;
  END IF;

  IF $PRDNONKEY <> '' THEN
    IF NOT EXISTS (SELECT 1 FROM PRDRSTNON WHERE PRDNONKEY = $PRDNONKEY) THEN
      CALL COMERR(CONCAT('연결된 비가동 기록을 찾을 수 없습니다.', '\n공무작업일지를 다시 열어 등록하세요.'));
      LEAVE PROC;
    END IF;
    IF NOT EXISTS (SELECT 1
                     FROM PRDRSTNON AS N
                    INNER JOIN MSTEQM_MATCH AS X ON X.EQMCD = N.EQMCD
                    WHERE N.PRDNONKEY = $PRDNONKEY
                      AND X.FANO = (SELECT EQMCD FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY)) THEN
      CALL COMERR(CONCAT('수리 설비가 속한 생산라인의 비가동이 아닙니다.', '\n공무작업일지를 다시 열어 등록하세요.'));
      LEAVE PROC;
    END IF;
  END IF;

  IF IFNULL($EMPCD_LIST, '') = '' THEN
    CALL COMERR('작업자를 추가해주세요.');
    LEAVE PROC;
  END IF;
  SET _$EMPCD_LIST = $EMPCD_LIST;
  SET _$FIRSTEMP = '';
  SET _$LIST1 = ',';  -- 확인한 작업자 (중복 확인용)
  WHILE LENGTH(_$EMPCD_LIST) > 0 DO
    CALL COMSPLIT(_$EMPCD_LIST, _$EMPCD);
    IF NOT EXISTS (SELECT 1 FROM MSTEMP WHERE EMPCD = _$EMPCD) THEN
      CALL COMERR('등록된 작업자를 선택하세요.');
      LEAVE PROC;
    END IF;
    IF LOCATE(CONCAT(',', _$EMPCD, ','), _$LIST1) > 0 THEN
      CALL COMERR(CONCAT('같은 작업자가 두 번 추가되어 있습니다.', '\n- 작업자: ', IFNULL((SELECT EMPNM FROM MSTEMP WHERE EMPCD = _$EMPCD), _$EMPCD)));
      LEAVE PROC;
    END IF;
    SET _$LIST1 = CONCAT(_$LIST1, _$EMPCD, ',');
    IF _$FIRSTEMP = '' THEN SET _$FIRSTEMP = _$EMPCD; END IF;
  END WHILE;

  -- 사용 자재·부품 확인 (부품명 필수, 수량 0보다 큰 숫자, 출고 부품은 출고이력·부품은 설비부품 기준정보 확인, 단위는 공통코드 DM150, 출고일자는 날짜 형식)
  SET _$LIST1 = IFNULL($PARTTP_LIST, '');
  SET _$LIST2 = IFNULL($INOUTKEY_LIST, '');
  SET _$LIST3 = IFNULL($PARTNM_LIST, '');
  SET _$LIST4 = IFNULL($PARTQTY_LIST, '');
  SET _$LIST5 = IFNULL($ITEMID_LIST, '');
  SET _$LIST7 = IFNULL($PARTUNIT_LIST, '');
  SET _$LIST9 = IFNULL($INOUTDATE_LIST, '');
  WHILE LENGTH(_$LIST1) > 0 DO
    CALL COMSPLIT(_$LIST1, _$PARTTP);
    CALL COMSPLIT(_$LIST2, _$INOUTKEY);
    CALL COMSPLIT(_$LIST3, _$PARTNM);
    CALL COMSPLIT(_$LIST4, _$PARTQTY);
    CALL COMSPLIT(_$LIST5, _$ITEMID);
    CALL COMSPLIT(_$LIST7, _$PARTUNIT);
    CALL COMSPLIT(_$LIST9, _$INOUTDATE);
    IF _$PARTTP NOT IN ('OUT', 'PART', 'SPECIAL') THEN
      CALL COMERR('사용 부품 구분을 확인하세요.');
      LEAVE PROC;
    END IF;
    IF TRIM(_$PARTNM) = '' THEN
      CALL COMERR('사용 부품의 부품명을 입력하세요.');
      LEAVE PROC;
    END IF;
    IF TRIM(_$PARTQTY) NOT REGEXP '^[0-9]+(\\.[0-9]+)?$' OR CAST(TRIM(_$PARTQTY) AS DECIMAL(20, 8)) <= 0 THEN
      CALL COMERR(CONCAT('사용 부품 수량을 0보다 크게 입력하세요.', '\n- 부품: ', _$PARTNM));
      LEAVE PROC;
    END IF;
    IF _$PARTTP = 'OUT' AND NOT EXISTS (SELECT 1 FROM INOUT_EQMPARTS WHERE INOUTKEY = _$INOUTKEY AND INOROUT = 'OUT') THEN
      CALL COMERR(CONCAT('출고 이력을 찾을 수 없는 부품입니다.', '\n- 부품: ', _$PARTNM));
      LEAVE PROC;
    END IF;
    IF _$PARTTP = 'PART' AND NOT EXISTS (SELECT 1 FROM MSTITEM WHERE ITEMID = _$ITEMID AND ITEMCG = 'DM100700') THEN
      CALL COMERR(CONCAT('설비부품 기준정보에 없는 부품입니다. 부품을 다시 선택하세요.', '\n- 부품: ', _$PARTNM));
      LEAVE PROC;
    END IF;
    IF TRIM(_$PARTUNIT) <> '' AND NOT EXISTS (SELECT 1 FROM COMTYPE WHERE GPCD = 'DM150' AND TPCD = TRIM(_$PARTUNIT)) THEN
      CALL COMERR(CONCAT('사용 부품 단위를 다시 선택하세요.', '\n- 부품: ', _$PARTNM));
      LEAVE PROC;
    END IF;
    IF TRIM(_$INOUTDATE) <> ''
      AND (TRIM(_$INOUTDATE) NOT REGEXP '^[1-9][0-9]{3}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$'
           OR DAY(STR_TO_DATE(TRIM(_$INOUTDATE), '%Y-%m-%d')) > DAY(LAST_DAY(CONCAT(LEFT(TRIM(_$INOUTDATE), 7), '-01')))) THEN
      CALL COMERR(CONCAT('사용 부품 출고일자를 올바르게 입력하세요.', '\n- 부품: ', _$PARTNM));
      LEAVE PROC;
    END IF;
  END WHILE;

  UPDATE EQMREP
     SET WORKTP      = $WORKTP,
         FAILTP      = $FAILTP,
         FAILPART    = $FAILPART,
         STOPTP      = $STOPTP,
         PRDNONKEY   = $PRDNONKEY,
         EMPCD       = _$FIRSTEMP,
         MALFUNCTION = IFNULL($MALFUNCTION, ''),
         CAUSE       = IFNULL($CAUSE, ''),
         HANDLE      = IFNULL($HANDLE, ''),
         PREVENT     = IFNULL($PREVENT, ''),
         MTIME       = CALLTIME(),
         MEMP        = CALLEMP(),
         MPRG        = CALLPRG()
   WHERE EQMREPKEY = $EQMREPKEY
     AND EQMREPTP = 'EQM01';

  DELETE FROM EQMREP_EMP WHERE EQMREPKEY = $EQMREPKEY;
  DELETE FROM EQMREP_PART WHERE EQMREPKEY = $EQMREPKEY;

  WHILE LENGTH($EMPCD_LIST) > 0 DO
    CALL COMSPLIT($EMPCD_LIST, _$EMPCD);
    INSERT INTO EQMREP_EMP (
      EQMREPKEY, EMPCD,
      RTIME, REMP, RPRG
    ) VALUES (
      $EQMREPKEY, _$EMPCD,
      CALLTIME(), CALLEMP(), CALLPRG()
    );
  END WHILE;

  SET _$LIST1 = IFNULL($PARTTP_LIST, '');
  SET _$LIST2 = IFNULL($INOUTKEY_LIST, '');
  SET _$LIST3 = IFNULL($PARTNM_LIST, '');
  SET _$LIST4 = IFNULL($PARTQTY_LIST, '');
  SET _$LIST5 = IFNULL($ITEMID_LIST, '');
  SET _$LIST6 = IFNULL($PARTSPEC_LIST, '');
  SET _$LIST7 = IFNULL($PARTUNIT_LIST, '');
  SET _$LIST8 = IFNULL($PARTREMARK_LIST, '');
  SET _$LIST9 = IFNULL($INOUTDATE_LIST, '');
  SET _$SEQ = 0;
  WHILE LENGTH(_$LIST1) > 0 DO
    CALL COMSPLIT(_$LIST1, _$PARTTP);
    CALL COMSPLIT(_$LIST2, _$INOUTKEY);
    CALL COMSPLIT(_$LIST3, _$PARTNM);
    CALL COMSPLIT(_$LIST4, _$PARTQTY);
    CALL COMSPLIT(_$LIST5, _$ITEMID);
    CALL COMSPLIT(_$LIST6, _$PARTSPEC);
    CALL COMSPLIT(_$LIST7, _$PARTUNIT);
    CALL COMSPLIT(_$LIST8, _$PARTREMARK);
    CALL COMSPLIT(_$LIST9, _$INOUTDATE);
    SET _$SEQ = _$SEQ + 1;

    INSERT INTO EQMREP_PART (
      EQMREPKEY, SEQ, PARTTP, INOUTKEY, ITEMID, INOUTDATE,
      PARTNM, PARTSPEC, PARTQTY, PARTUNIT, REMARK,
      RTIME, REMP, RPRG
    ) VALUES (
      $EQMREPKEY, _$SEQ, _$PARTTP,
      IF(_$PARTTP = 'OUT', _$INOUTKEY, ''), IF(_$PARTTP IN ('OUT', 'PART'), _$ITEMID, ''), TRIM(_$INOUTDATE),
      TRIM(_$PARTNM), TRIM(_$PARTSPEC), CAST(TRIM(_$PARTQTY) AS DECIMAL(20, 8)), TRIM(_$PARTUNIT), TRIM(_$PARTREMARK),
      CALLTIME(), CALLEMP(), CALLPRG()
    );
  END WHILE;

  SELECT $EQMREPKEY AS EQMREPKEY;

-- *****************************************************************************
WHEN 'DELETE_WORKLOG' THEN  -- 공무작업일지 삭제 = 작업일지 항목·사용 부품만 비움 (태블릿 수리 기록·작업자·사진, 고장현상(호출이유)은 그대로 → 미작성)
  WHILE LENGTH($EQMREPKEY_LIST) > 0 DO
    CALL COMSPLIT($EQMREPKEY_LIST, _$EQMREPKEY);

    UPDATE EQMREP
       SET WORKTP    = '',
           FAILTP    = '',
           FAILPART  = '',
           STOPTP    = '',
           PRDNONKEY = '',
           CAUSE     = '',
           HANDLE    = '',
           PREVENT   = '',
           MTIME     = CALLTIME(),
           MEMP      = CALLEMP(),
           MPRG      = CALLPRG()
     WHERE EQMREPKEY = _$EQMREPKEY
       AND EQMREPTP = 'EQM01';

    DELETE FROM EQMREP_PART WHERE EQMREPKEY = _$EQMREPKEY;
  END WHILE;

-- *****************************************************************************
WHEN 'PRINT_WORKLOG' THEN  -- 공무작업일지 출력 (리포트 EQM1001_R01: [0] 일지, [1] 작업자, [2] 사용 자재·부품)

  IF NOT EXISTS (SELECT 1 FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY AND EQMREPTP = 'EQM01' AND WORKTP <> '') THEN
    CALL COMERR(CONCAT('공무작업일지를 작성하지 않은 수리 기록입니다.', '\n- 문서번호: ', IFNULL($EQMREPKEY, '')));
    LEAVE PROC;
  END IF;

  SELECT
      R.EQMREPKEY                                                   -- 문서번호
    , IFNULL(GPCD('FM300', R.WORKTP), R.WORKTP) AS WORKTPNM         -- 작업구분
    , LEFT(R.MTIME, 10) AS WRITEDATE                                -- 작성일
    , IF(R.REPETIME = '', '진행중', '완결') AS PROGRESS              -- 진행상태
    , TRIM(CONCAT(IFNULL(L.LINENM, M.LINECD), ' ', IFNULL(GPCD('FM100', M.EQMTP), ''), ' ', IFNULL(GPCD('FM113', M.EQMGROUP1), ''))) AS LINEINFO -- 라인 (작업장 공정 라인)
    , R.EQMCD                                                       -- 설비번호
    , IFNULL(M.EQMNM, R.EQMCD) AS EQMNM                             -- 설비명
    , IFNULL(GPCD('FM307', R.FAILTP), '') AS FAILTPNM               -- 고장유형
    , IFNULL(GPCD('FM303', R.FAILPART), '') AS FAILPARTNM           -- 고장부위
    , IFNULL(GPCD('FM304', R.STOPTP), '') AS STOPTPNM               -- 중단구분
    , IFNULL(NON.NONSTIME, '') AS NONSTIME                          -- 비가동 발생일시
    , IFNULL(NON.NONETIME, '') AS NONETIME                          -- 비가동 종료일시
    , IFNULL(NON.STOPMIN, '') AS STOPMIN                            -- 정지시간(분)
    , LEFT(R.REPSTIME, 16) AS REPSTIME                              -- 수리 시작시간
    , LEFT(R.REPETIME, 16) AS REPETIME                              -- 수리 종료시간
    , IF(R.REPETIME = '', '', TIMESTAMPDIFF(MINUTE, R.REPSTIME, R.REPETIME)) AS REPMIN -- 수리시간(분)
    , R.MALFUNCTION                                                 -- 고장현상 / 작업내용
    , R.CAUSE                                                       -- 원인분석
    , R.HANDLE                                                      -- 조치내역
    , R.PREVENT                                                     -- 특이사항 및 재발방지대책
  FROM EQMREP AS R
  LEFT JOIN MSTEQM AS M
    ON M.FANO = R.EQMCD
  LEFT JOIN MSTLINE AS L
    ON L.LINECD = M.LINECD
  LEFT JOIN (
    SELECT
        N.PRDNONKEY
      , LEFT(MAX(N.NONSTIME), 16) AS NONSTIME
      , LEFT(MAX(N.NONETIME), 16) AS NONETIME
      , IF(MAX(N.NONETIME) = '', '', TIMESTAMPDIFF(MINUTE, MAX(N.NONSTIME), MAX(N.NONETIME))) AS STOPMIN
    FROM PRDRSTNON AS N
    WHERE N.PRDNONKEY = (SELECT PRDNONKEY FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY)
    GROUP BY N.PRDNONKEY
  ) AS NON
    ON NON.PRDNONKEY = R.PRDNONKEY
   AND R.PRDNONKEY <> ''
  WHERE R.EQMREPKEY = $EQMREPKEY;

  SELECT
      IFNULL(P.EMPNM, W.EMPCD) AS EMPNM
  FROM EQMREP_EMP AS W
  INNER JOIN EQMREP AS R
    ON R.EQMREPKEY = W.EQMREPKEY
  LEFT JOIN MSTEMP AS P
    ON P.EMPCD = W.EMPCD
  WHERE W.EQMREPKEY = $EQMREPKEY
  ORDER BY (W.EMPCD = R.EMPCD) DESC, W.RTIME, W.EMPCD;  -- 대표 작업자가 첫 번째

  SELECT
      P.PARTNM                                                                              -- 부품명
    , P.PARTSPEC                                                                            -- 규격
    , TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM CAST(P.PARTQTY AS CHAR))) AS PARTQTY     -- 수량 (소수점 뒤 0 제거)
    , IFNULL(C.TPNM, P.PARTUNIT) AS PARTUNITNM                                              -- 단위
    , P.REMARK                                                                              -- 비고
  FROM EQMREP_PART AS P
  LEFT JOIN COMTYPE AS C
    ON C.GPCD = 'DM150'
   AND C.TPCD = P.PARTUNIT
  WHERE P.EQMREPKEY = $EQMREPKEY
  ORDER BY P.SEQ;

-- *****************************************************************************
WHEN 'LIST_EQMREP_IMG' THEN  -- 수리이력 사진 조회
  SELECT
    EQMREP_IMG.FILEKEY,
    FILEURL(EQMREP_IMG.FILEKEY) AS FILEURL
  FROM EQMREP_IMG
  WHERE EQMREP_IMG.EQMREPKEY = $EQMREPKEY
  ORDER BY EQMREP_IMG.RTIME, EQMREP_IMG.FILEKEY;

-- *****************************************************************************
WHEN 'ADD_EQMREP_IMG' THEN  -- 수리이력 사진 등록 (업로드한 파일키 연결)
  IF NOT EXISTS (SELECT 1 FROM EQMREP WHERE EQMREPKEY = $EQMREPKEY AND EQMREPTP = 'EQM01' LIMIT 1) THEN
    CALL COMERR('수리이력을 선택하세요.');
    LEAVE PROC;
  END IF;
  IF TRIM(IFNULL($FILEKEY, '')) = '' THEN
    CALL COMERR('사진을 선택하세요.');
    LEAVE PROC;
  END IF;

  INSERT INTO EQMREP_IMG (
    EQMREPKEY, FILEKEY,
    RTIME, REMP, RPRG
  ) VALUES (
    $EQMREPKEY, $FILEKEY,
    CALLTIME(), CALLEMP(), CALLPRG()
  );

-- *****************************************************************************
WHEN 'DELETE_EQMREP_IMG' THEN  -- 수리이력 사진 삭제 (파일은 화면에서 삭제)
  IF NOT EXISTS (SELECT 1 FROM EQMREP_IMG WHERE EQMREPKEY = $EQMREPKEY AND FILEKEY = $FILEKEY LIMIT 1) THEN
    CALL COMERR('사진을 다시 조회한 후 삭제하세요.');
    LEAVE PROC;
  END IF;

  DELETE FROM EQMREP_IMG WHERE EQMREPKEY = $EQMREPKEY AND FILEKEY = $FILEKEY;

-- *****************************************************************************
END CASE; 

END
