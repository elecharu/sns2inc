CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`PRD6001_S03`(
-- *****************************************************************************
-- Comment: 공무작업일지 조회·출력 (2공장)
--          공무작업일지 = EQMREP(EQM01) 중 EQM1001_R01 에서 작업일지를 작성한 수리 기록(WORKTP <> '')
--          작업자 = EQMREP_EMP (대표 작업자 EQMREP.EMPCD 먼저), 사용 자재·부품 = EQMREP_PART, 비가동 = PRDRSTNON (EQMREP.PRDNONKEY)
-- Create: 2024-04-30 11:30: 김영철
-- Modify: 2026-11-05 : 김영철 2공장 테이블 기준으로 변경
--                       설비수리 EQMREP 2공장 컬럼으로 (비가동 PRDRSTNON 연결 없음), 고장유형(FM307) → 수리유형(ISSUE)
--                       근무일 함수(MAKEINS_IFDT) 대신 완료시간 06:00 기준 범위 조건, MSTEMP.WORKDUTY 없음 → ''
--         2026-11-06 : 김영철 SEL_EQMREP 에 작업장(LINENM)·설비구분(EQMTPNM)·설비대분류(EQMGROUP1NM) 추가
--         2026-11-18 : 한성수 SEL_EQMREPDAILY 개선업무에 설비명(EQMNM) 추가
--         2026-11-20 : 한성수 공무작업일보(설비수리·개선업무·요청사항)를 공무작업일지 조회(LIST_WORKLOG)·출력(PRINT_WORKLOG)으로 전면 변경, 기존 분기·파라미터 삭제
-- *****************************************************************************
  IN $SDATE VARCHAR(10),              -- 조회 시작일자 (수리종료일)
  IN $EDATE VARCHAR(10),              -- 조회 종료일자 (수리종료일)
  IN $LINECD VARCHAR(20),             -- 작업장
  IN $EQMTP VARCHAR(20),              -- 설비구분 (공정)
  IN $EQMGROUP1 VARCHAR(20),          -- 설비대분류 (라인)
  IN $EQMCD VARCHAR(20),              -- 설비코드 (MSTEQM.FANO)
  IN $WORKTP VARCHAR(20),             -- 작업구분 (FM300, '' = 전체)
  IN $FAILTP VARCHAR(20),             -- 고장유형 (FM307, '' = 전체)
  IN $EQMREPKEY VARCHAR(20),          -- 설비수리키 (출력)

-- *****************************************************************************
  IN $CALLTYPE VARCHAR(50), IN $KEYWORD VARCHAR(1000))
PROC: BEGIN -- @CALLEMP, @CALLPRG, @CALLHOST, @CALLIP, @CALLMAC
-- SET @DEBUGLOGYN = 'Y';
-- *****************************************************************************

CASE $CALLTYPE
-- ****************************************************************************
WHEN 'LIST_WORKLOG' THEN  -- 공무작업일지 목록 (수리종료일이 조회기간 안, 작업일지 작성한 수리 기록)

  SELECT
      R.EQMREPKEY                                       -- 문서번호 (설비수리키)
    , R.WORKTP                                          -- 작업구분
    , LEFT(R.MTIME, 10) AS WRITEDATE                    -- 작성일 (작업일지 마지막 저장일)
    , M.LINECD                                          -- 작업장
    , M.EQMTP                                           -- 설비구분 (공정)
    , M.EQMGROUP1                                       -- 설비대분류 (라인)
    , R.EQMCD                                           -- 설비코드
    , IFNULL(M.EQMNM, R.EQMCD) AS EQMNM                 -- 설비명
    , R.FAILTP                                          -- 고장유형
    , R.FAILPART                                        -- 고장부위
    , R.STOPTP                                          -- 중단구분
    , IFNULL(NON.NONSTIME, '') AS NONSTIME              -- 비가동 발생일시
    , IFNULL(NON.NONETIME, '') AS NONETIME              -- 비가동 종료일시
    , IFNULL(NON.STOPMIN, 0) AS STOPMIN                 -- 정지시간(분)
    , LEFT(R.REPSTIME, 16) AS REPSTIME                  -- 수리 시작시간
    , LEFT(R.REPETIME, 16) AS REPETIME                  -- 수리 종료시간
    , TIMESTAMPDIFF(MINUTE, R.REPSTIME, R.REPETIME) AS REPMIN -- 수리시간(분)
    , IFNULL((SELECT GROUP_CONCAT(IFNULL(P.EMPNM, W.EMPCD) ORDER BY (W.EMPCD = R.EMPCD) DESC, W.RTIME, W.EMPCD SEPARATOR ', ')
                FROM EQMREP_EMP AS W
                LEFT JOIN MSTEMP AS P ON P.EMPCD = W.EMPCD
               WHERE W.EQMREPKEY = R.EQMREPKEY), '') AS EMPNMS -- 작업자 (대표 작업자 먼저)
    , R.MALFUNCTION                                     -- 고장현상 / 작업내용
    , R.CAUSE                                           -- 원인분석
    , R.HANDLE                                          -- 조치내역
    , IFNULL((SELECT GROUP_CONCAT(CONCAT(P.PARTNM, ' ', TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM CAST(P.PARTQTY AS CHAR))), IFNULL(C.TPNM, P.PARTUNIT)) ORDER BY P.SEQ SEPARATOR ', ')
                FROM EQMREP_PART AS P
                LEFT JOIN COMTYPE AS C ON C.GPCD = 'DM150' AND C.TPCD = P.PARTUNIT
               WHERE P.EQMREPKEY = R.EQMREPKEY), '') AS PARTS -- 사용 자재 / 부품
    , R.PREVENT                                         -- 특이사항 및 재발방지대책
  FROM EQMREP AS R
  INNER JOIN MSTEQM AS M
    ON M.FANO = R.EQMCD
  LEFT JOIN (
    SELECT
        N.PRDNONKEY
      , LEFT(MAX(N.NONSTIME), 16) AS NONSTIME
      , LEFT(MAX(N.NONETIME), 16) AS NONETIME
      , IF(MAX(N.NONETIME) = '', 0, TIMESTAMPDIFF(MINUTE, MAX(N.NONSTIME), MAX(N.NONETIME))) AS STOPMIN
    FROM PRDRSTNON AS N
    GROUP BY N.PRDNONKEY
  ) AS NON
    ON NON.PRDNONKEY = R.PRDNONKEY
   AND R.PRDNONKEY <> ''
  WHERE R.EQMREPTP = 'EQM01'
    AND R.WORKTP <> ''
    AND R.REPETIME <> ''
    AND M.FACTORYCD = '07'
    AND LEFT(R.REPETIME, 10) BETWEEN $SDATE AND $EDATE
    AND ($LINECD = '' OR M.LINECD = $LINECD)
    AND ($EQMTP = '' OR M.EQMTP = $EQMTP)
    AND ($EQMGROUP1 = '' OR M.EQMGROUP1 = $EQMGROUP1)
    AND R.EQMCD LIKE CONCAT('%', $EQMCD, '%')
    AND ($WORKTP = '' OR R.WORKTP = $WORKTP)
    AND ($FAILTP = '' OR R.FAILTP = $FAILTP)
  ORDER BY R.REPETIME DESC, R.EQMREPKEY;

-- ****************************************************************************
WHEN 'PRINT_WORKLOG' THEN  -- 공무작업일지 출력 ([0] 일지, [1] 작업자, [2] 사용 자재·부품)

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

-- ****************************************************************************
END CASE; END
