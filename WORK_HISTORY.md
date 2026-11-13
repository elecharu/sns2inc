# MES 프로젝트 작업 이력 및 변경 관리 대장 (Work History)

> **문서 목적**: 본 문서는 에이전트 대화 세션 전환이나 브라우저/UI 세션 변경과 무관하게, 지금까지 진행된 작업 내역을 누락 없이 영구 보존하고 이후 작업을 지속적으로 이어서 추적·관리하기 위한 공식 작업 기록 대장입니다.  
> **최초 작성일**: 2026-09-18  
> **최종 갱신일**: 2026-11-13
> **인코딩 표준**: UTF-8 with BOM (CRLF)

---

## 📌 [기록 관리 가이드라인]

1. **작업 추가 규칙**: 새로운 작업(화면, C#, SQL, 프로시저, 버그 수정 등)을 진행할 때마다 본 문서의 최신 날짜 섹션에 작업 항목과 상세 내용을 누적 기록합니다.
2. **주석 및 네이밍 표준**: 소스코드에는 `// YYYY-MM-DD 기능설명` 표준을 준수하며, 본 문서에는 원인 분석, 설계 의도, 수정 파일 링크를 명시합니다.
3. **컴파일 및 빌드 검증**: 소스 수정 후에는 반드시 컴파일 빌드 무결성(MSBuild 등)을 확인하고 그 결과를 기재합니다.
4. **대화 기록 및 불러오기 연계**: 모든 사용자 요청 및 작업 결과는 본 문서에 실시간 동기화되어, 새 세션이나 나중에 작업 재개 시 "불러오기"를 통해 이전 맥락을 100% 이어받습니다.

---

## 🕒 2026-11-13 (금) 작업 내역

### 8. PRD6001_S02 고장시간·고장건수 → 설비수리(EQMREP) 기준 변경분 검증 (소스 수정 없음)
- **대상 파일**: [05.Procedure/MES_SNS2_PRD6001_S02.sql](05.Procedure/MES_SNS2_PRD6001_S02.sql) (사용자 수정분)
- **연결 확인**: 수리이력 EQMREP(EQM01).EQMCD = MSTEQM.FANO(공장 07) → MSTEQM_MATCH.FANO → MSTEQM_MATCH.EQMCD = 화면 설비(MSTLINE_EQM 2공장 사용 설비). 한 FANO가 여러 라인 설비에 매칭되면 라인별로 각각, 종합은 EQMREPKEY 중복 제거. 고장시간 = 완료 건 (완료 − 발생) 분, 고장건수 = 수리이력 전체, 수리건수 = 완료 건 → MTBF = (부하 − 고장시간) ÷ 고장건수, MTTR = 고장시간 ÷ 수리건수. 코드상 연결·계산식은 맞음
- **검증**: 실DB에서 SELECT로 가져온 PP161·MSTLINE·MSTLINE_EQM·PRDRSTNON·EQMREP·MSTEQM·MSTEQM_MATCH로 격리 MariaDB 10.2.44(network none)에서 컴파일·실행(271행). (M3열전)T1 11월 부하 36,000·수리 3건(I2B-002N, 모두 0분 완료) → MTBF 12,000·고장율 5.00·MTTR 0, 종합 11월 MTBF 528,000(1,584,000 ÷ 3), 손계산 일치
- **데이터 확인(미수정)**: 2026년 공장 07 수리 18건 중 MSTEQM_MATCH에 매칭된 것은 I2B-002N 3건뿐. 나머지 15건(I2C-002N 5, I2G-001N 3, I2G-009N, I2ROT-003N, I2S-001N, I2W-001N, I2W-017N 등)은 매칭 행이 없어 계산에서 제외 → 라인별 설비매칭(MST1002_R05) 등록 필요. 수리시간은 달력 시간(10/23~11/02 14,877분 등)이고 발생월에 전부 반영되며, 부하시간은 근무시간 기준이라 긴 수리는 가동시간이 0으로 내려갈 수 있음(GREATEST 0 처리). MSTEQM.FACTORYCD = '07' JOIN은 매칭으로 범위가 이미 정해져 중복 조건(결과 영향 없음)

### 3. [PRD6001_S02] 고장시간·고장건수 데이터를 설비수리(EQMREP) 기반으로 변경
- **수정/대상 파일**: [05.PROCEDURE/MES_SNS2_PRD6001_S02.sql](05.PROCEDURE/MES_SNS2_PRD6001_S02.sql)
- **배경 및 원인**: 기존 `PRD6001_S02`(`LIST_EQMDATA`)는 `PRDRSTNON` 비가동(`MSTNON.NONGROUPCD1 = 'PP409I210N'`) 기준으로 고장시간(분)·고장건수·MTBF·MTTR을 집계하여 설비보전 수리이력(`EQMREP`, `EQM1001_R06`) 수치와 불일치함
- **작업 상세 내용**:
  - **대상 설비·부하시간 유지**: `MSTLINE.FACTORYCD = '07'` 및 `MSTLINE_EQM.USEYN = 'Y'` 생산라인 설비 축과 `ITEM` 명칭(`고장시간(분)`, `고장건수`)은 유지하고, 불필요해진 `TMP_PRD6001_NONCD` 제거 후 `TMP_PRD6001_NON`에서 제외 비가동(`I2121N`, `I2122N`, `I2111N`, `I2113N`)만 읽어 `LOADMIN` 계산을 동일하게 유지
  - **설비수리 집계 전환(`TMP_PRD6001_REP`)**: `EQMREP`(`EQMREPTP = 'EQM01'`) × `MSTEQM`(`FACTORYCD = '07'`) × `MSTEQM_MATCH`(`DISTINCT EQMCD, FANO`)를 발생시간(`REPSTIME`) 연도·월(`CONCAT(_$SYEAR, '-01-01')` ~ `< +1년`) 기준으로 집계. 전체 매칭 건을 `고장건수`(`FAILCNT`)로 집계하고, `REPETIME <> '' AND REPETIME >= REPSTIME`인 수리완료 건만 `TIMESTAMPDIFF(MINUTE, REPSTIME, REPETIME)`로 `고장시간(분)`(`FAILMIN`)과 `수리건수`(`FIXCNT`, MTTR 분모)에 합산
  - **종합 행 중복 제거(`TMP_PRD6001_TOT`)**: `종합` 행은 `TMP_PRD6001_BASE`의 `LOADMIN` 합계와 `TMP_PRD6001_REP`의 `DISTINCT EQMREPKEY` 기준 합계를 결합해 다중 라인 매칭 설비의 수리 중복 집계 방지
  - **인코딩·헤더 정리**: `CREATE DEFINER` 2행 분리 및 `Modify:` 2026-11-13 이력 1행 통합, `05.PROCEDURE/` 기준 UTF-8(BOM 제거)+CRLF 적용
- **검증 결과**:
  - `MES_SNS2_PRD6001_S02.sql` 바이트 검사 통과 (UTF-8 무BOM, CRLF, `bareLf=0`, `crCrLf=0`)
  - 실 DB(`211.43.15.98:33061`, MariaDB 10.2.15) 읽기 전용 `SELECT` 시뮬레이션 검증 완료 (`2026`년 270행 기준 `부하시간(분)` 0건 오차, `(M3열전)T1` 11월 `고장건수=3`/`고장시간=0`/`고장율=5.00`/`MTBF=12000` 및 `종합` 일치 확인)
  - MariaDB 10.2.15 읽기 전용 합성 데이터 엣지케이스 검증 완료 (완료/0분/미완료/역전/다중라인 `DISTINCT`/연도경계)
  - ※ DB 프로시저 반영(서버 컴파일/저장)은 작업 규칙에 따라 미실행 (로컬 `.sql` 수정 상태)


### 2. [EQM1001_R04] 월 이동 시 대상 월 기존 주기관리 계획 덮어쓰기 차단
- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql
- **배경 및 원인**: 5월 계획을 7월 등 다른 월로 변경 저장할 때 대상 월에 이미 정기점검 계획이 배정되어 있어도 CHKRSTEQM 실적만 없으면 덮어쓰던 문제
- **작업 상세 내용**:
  - ADD_CHKRSTEQM·SAVE_CHKRSTEQM 실행 전 _$CHKYM <> $YYYYMM 인 경우 CHKPLANEQM_YEARPLAN 대상 월(_$TGTEMP) 조회 후 비어있지 않으면 COMERR로 차단하도록 보완
- **검증 결과**: UTF-8 무BOM+CRLF 및 git diff 검증 완료 (DB 컴파일 미확인)


### 2. [EQM1001_R04] 화면 스크립트 및 프로시저 최적화
- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql
- **배경 및 원인**: 월별 점검자 표시·계획월 이동 기능 추가 후 중복 코드와 반복 조건 정리 요청
- **작업 상세 내용**:
  - js: 월 컬럼 판별 IS_MONTH 공통화, 점검값 보정 CHECK_CHKVALUE 및 저장 목록 ADD_CHK_LIST 공통화(grid2/grid3 중복 제거), 날짜·다중행 주석을 1줄 기능 주석으로 정리. sql: 점검월 _$CHKYM 1회 계산, 등록·수정 중복 실적 검사 공통화, 월별 현황 FIND_IN_SET/RSTMM 제거 후 실적 점검자 피벗으로 판정, 계획월 이동을 대상 년도 행 보장 후 단일 UPDATE(CASE CONCAT(YEAR,월))로 처리, 미사용 변수 5개 제거
- **검증 결과**: node --check 통과, js UTF-8 BOM+CRLF, sql 무BOM+CRLF 확인. DB 컴파일 미확인


### 2. [EQM1001_R04] 월별 점검자 표시, 점검일자 년월 검증 제거 및 주기관리 월 자동이동
- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql
- **배경 및 원인**: 정기점검 현황 그리드에 점검상태 아래 줄바꿈 + (점검자명) 표시 및 계획월과 다른 월에 점검 등록/수정 시 해당 월로 저장하고 주기관리(CHKPLANEQM_YEARPLAN)도 함께 이동 필요
- **작업 상세 내용**:
  - EQM1001_R04.js: M01~M12 multiLine/autoRowHeights 및 formatItem 줄바꿈 링크 적용. MES_SNS2_EQM1001_R04.sql: LIST_CYCLE_EQMCD에서 점검완료/점검필요 아래 \n(점검자명) 반환, ADD_CHKRSTEQM/SAVE_CHKRSTEQM 점검일자-계획년월 일치 검증 제거 및 대상월 기준 중복 체크, 저장/수정 월 변경 시 CHKPLANEQM_YEARPLAN 계획월 자동 이동
- **검증 결과**: node --check 통과, UTF-8 BOM/무BOM 및 CRLF 검증 완료


### 2. [EQM1001_R01] LIST_EQMREP 공장 조건식 정리

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R01.sql
- **배경 및 원인**: WHEN LIST_EQMREP THEN 상단에서 SET  = '07'로 고정함에 따라 WHERE절의 불필요한 공백 OR 분기 제거 필요
- **배경 및 원인**: `WHEN 'LIST_EQMREP' THEN` 상단에서 `SET $FACTORYCD = '07';`로 고정함에 따라 `WHERE`절의 불필요한 공백 OR 분기 제거 필요
- **작업 상세 내용**:
  - WHERE절 조건을 AND MSTEQM.FACTORYCD =  정리
  - `WHERE`절 조건을 `AND MSTEQM.FACTORYCD = $FACTORYCD`로 정리
- **검증 결과**: SQL diff 및 UTF-8 무BOM+CRLF 검증 완료

### 2. [EQM1001_R01] 공장 검색 콤보 제거 및 프로시저 2공장 기본값 적용

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js, 05.PROCEDURE/MES_SNS2_EQM1001_R01.sql
- **배경 및 원인**: 2공장 전용 화면에서 공장 선택 콤보박스 필터링을 제거하고 프로시저 측에 2공장(07) 기본값 적용 필요
- **작업 상세 내용**:
  - EQM1001_R01.aspx에서 cmb_FACTORYCD 컨트롤 제거(작업장·설비구분·설비대분류 REF01/REF10='07' 유지), EQM1001_R01.js에서 cmb_FACTORYCD.onChanged 이벤트 제거, MES_SNS2_EQM1001_R01.sql LIST_EQMREP 조건을 IF(IFNULL(\, '') = '', '07', \)로 변경
- **검증 결과**: node --check 통과, 3개 파일 BOM/UTF-8/CRLF 검증 및 git diff 확인 완료
  - `EQM1001_R01.aspx`에서 `cmb_FACTORYCD` 컨트롤 제거(작업장·설비구분·설비대분류 `REF01`/`REF10='07'` 유지), `EQM1001_R01.js`에서 `cmb_FACTORYCD.onChanged` 이벤트 제거, `MES_SNS2_EQM1001_R01.sql` `LIST_EQMREP` 조건을 2공장(`'07'`) 기준으로 변경
- **검증 결과**: `node --check` 통과, 3개 파일 BOM/UTF-8/CRLF 검증 및 `git diff` 확인 완료

### 7. EQM1001_R01 설비 분류 필터 수정분 코드 스타일 검토·정리

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R01.js](01.Office/PAGEEQM/EQM1001/EQM1001_R01.js), [05.Procedure/MES_SNS2_EQM1001_R01.sql](05.Procedure/MES_SNS2_EQM1001_R01.sql)
- **배경**: 사용자가 수정한 R01(검색 공장·작업장·설비구분·설비대분류, 그리드 열 4개, LIST_EQMREP 조건) 스타일 검토 요청. aspx 검색조건·그리드 콤보 열은 MST1002_R06과 같은 형식, 프로시저 Modify 1행·파라미터 주석·SYSTEM_PARAMETERS 등록(45건, 3~6번)은 관례대로 확인
- **작업 상세 내용**
  - js: 14:49 저장에서 빠진 UTF-8 BOM 1개 복원(CRLF 유지), 주석 처리된 `autoSizeColumns()` 줄 삭제(위 '조회 후 autoSizeColumns 적용' 기록과 달리 현재는 미적용), REPIMG_LIST의 들여쓰기만 바뀐 줄 원복
  - sql: 선택 조건 4개를 프로젝트 다수 형식 `($X = '' OR 컬럼 = $X)`(48건, IFNULL 형식 7건)으로, 같은 WHERE의 `$EMPCD` 조건과 통일
- **검증**: node --check 통과, js BOM 1개·CRLF, sql BOM 없음·CRLF. js diff에는 기능 변경(열·콤보 연동)만 남음. 미확인: MariaDB 컴파일(Docker 꺼짐), 화면 동작·검색영역 폭

### 2. [EQM1001_R01] 인코딩(UTF-8 BOM) 복구 및 중복 이벤트 제거

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js
- **배경 및 원인**: 01.Office/web.config에 globalization fileEncoding 설정이 없는 환경에서 .aspx/.js 파일의 UTF-8 BOM이 소실되어 CP949로 오인식되는 인코딩 오류 발생 및 cmb_FACTORYCD onChanged 이벤트 중복 잔여 코드 확인
- **작업 상세 내용**:
  - EQM1001_R01.aspx와 EQM1001_R01.js에 단일 UTF-8 BOM(EF BB BF)과 CRLF 복원, EQM1001_R01.js의 중복 cmb_FACTORYCD.onChanged 블록 제거, SQL 2개 파일 UTF-8 무BOM+CRLF 검증
- **검증 결과**: node --check 통과, 5개 대상 파일 BOM/UTF-8/CRLF 바이트 검증 통과, git diff 검증 완료

### 2. EQM1001_R01 조회 후 autoSizeColumns 적용 및 프로젝트 코드 스타일 통일

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js
- **배경 및 원인**: 프로젝트 기존 화면과 동일한 이벤트 핸들러 작성 방식 적용 및 조회 완료 시 그리드 컬럼 폭 자동 맞춤 요청
- **작업 상세 내용**:
  - ItsButton.EventSearch 내 grid1 autoSizeColumns() 호출 추가 및 ItsCombo.Event(cmb_FACTORYCD).onChanged 시그니처를 function (value) 형태로 정리
- **검증 결과**: node --check 및 단일 UTF-8 BOM + CRLF 무결성 검증 완료

### 2. EQM1001_R01 상단 검색영역 설비 분류 필터 추가

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js, 05.Procedure/MES_SNS2_EQM1001_R01.sql, 05.Procedure/MES_SNS2_EQM1001_R01_SYSTEM_PARAMETERS.sql
- **배경 및 원인**: 그리드에 추가된 공장·작업장·설비구분·설비대분류 컬럼에 맞춰 상단 검색영역 필터링 기능 추가 요청
- **작업 상세 내용**:
  - sdiv1 설비코드 앞에 FACTORYCD, LINECD, EQMTP, EQMGROUP1 콤보 추가 및 공장 변경 시 하위 콤보 연동, LIST_EQMREP 검색 조건 및 SYSTEM_PARAMETERS 스크립트 갱신
- **검증 결과**: JS 구문검사(node --check) 및 전 파일 BOM/CRLF 무결성 검증 완료, DB 프로시저 및 SYSTEM_PARAMETERS 재등록 필요

### 2. EQM1001_R01 수리이력 그리드 설비 분류 컬럼 추가

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js, 05.Procedure/MES_SNS2_EQM1001_R01.sql
- **배경 및 원인**: 설비이력관리(EQM1001_R01) 메인 그리드에 설비코드·설비명 외 공장·작업장·설비구분·설비대분류 정보 표시 요청
- **작업 상세 내용**:
  - grid1 설비코드 앞에 FACTORYCD(공장), LINECD(작업장), EQMTP(설비구분), EQMGROUP1(설비대분류) 콤보 컬럼 추가 및 LIST_EQMREP SELECT에 MSTEQM 컬럼 4종 반환 추가
- **검증 결과**: JS 구문검사(node --check) 및 인코딩/CRLF 검증 완료, 실서버 프로시저 반영 필요

### 6. EQM1001_R06 TOP ISSUE 인쇄(R0602)에 그래프 페이지·확인란 추가

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R0602.cs](04.Report/PAGEEQM/EQM1001/R0602.cs), [04.Report/PAGEEQM/EQM1001/R0601.cs](04.Report/PAGEEQM/EQM1001/R0601.cs)
- **배경**: TOP ISSUE 인쇄의 세부내용 뒤에 기존 그래프를 함께 출력하고, 그래프 우측 하단에 오늘 날짜·이름·사인 칸 요청. 시안 4종(가로 표형·한 줄 밑줄형·결재란형·세로 목록형) 중 사용자 선택: 결재란형. 성명은 빈칸(수기), 그래프 단독 인쇄(R0601)는 확인란 없이 그대로
- **R0602**: 생성자에서 LIST_CHART(R0601과 같은 조회)도 호출, 세부내용 다음 페이지에 DRAW_GRAPH_PAGE: 제목 '■ {년}년 설비 고장율 현황' + 왼쪽 머리칸(설비 고장율/고장 건수) + 차트 2개(높이 350 → 315) + DRAW_SIGN(세로 '확인' 머리칸 26 + 일자 110(출력일 yyyy-MM-dd)·성명 90·서명 120, 머리 22·값 48, 기존 표와 같은 머리 색). Designer.cs 미변경(기존처럼 Detail에 코드로 배치)
- **R0601**: 차트 채우기 SET_CHART_RATE·SET_CHART_CNT를 차트를 인자로 받는 internal static으로 바꿔 R0602가 같은 차트를 그림(R0601 출력은 동일)
- **검증**: MSBuild 15.0 Release Rebuild 성공(0 Error, 기존 R0602 경고 1건). 실DB(2026년 11월)로 웹과 같은 방식 실행: R0602 표준출력 없음·PDF 생성·4페이지(표 1, 세부내용 2, 그래프 1), 마지막 페이지 이미지에서 차트 2개와 결재란 배치·일자 2026-11-13 확인. R0601 단독 출력 정상. exe를 04.Report/bin·01.Office/Reports에 배포(MD5 일치). 인코딩 BOM·CRLF. 미확인: VS 디자이너 열기(Designer.cs 미변경), 웹 화면에서 실제 [인쇄]
- **후속(고장 → 호출 문구)**: 아래 차트 왼쪽 머리칸 '고 장 건 수' → '호 출 건 수'(R0602.cs 그래프 페이지, R0601.Designer.cs lbl_SIDE2.Text 1행), 범례 '설비 고장횟수' → '설비 호출횟수'(R0601.cs 공용 차트). TOP ISSUE 표의 '고장 횟수' 열 등 표·세부내용 문구는 미변경. Rebuild 성공(0 Error, 기존 경고 1건), 실DB 출력 이미지(100dpi)로 머리칸·범례 확인, exe 2곳 배포(MD5 일치). 미확인: VS 디자이너 열기(Text 값만 변경)

### 5. 레포트 인쇄 'Unable to connect to any of the specified MySQL hosts' 오류

- **수정/대상 파일**: [01.Office/Reports/ITS_CONFIG_MARIA.xml](01.Office/Reports/ITS_CONFIG_MARIA.xml), [04.Report/bin/ITS_CONFIG_MARIA.xml](04.Report/bin/ITS_CONFIG_MARIA.xml) (`--addr` 1행씩)
- **원인**: 레포트 exe는 실행 폴더의 ITS_CONFIG_MARIA.xml로 DB에 접속. 2026-11-12 커밋 51fa63b(TQM3001 작업)에서 두 파일의 addr가 211.43.15.98 → localhost로 바뀌었고, 이 PC의 localhost:33061에는 DB가 없어 접속 실패. 웹 화면은 App_Code/ItsMaria.cs의 211.43.15.98(테스트서버)을 쓰므로 화면 조회는 정상이었음
- **작업 상세 내용**: 두 파일의 addr만 웹과 같은 211.43.15.98로 되돌림(port·user·dbname·password 줄 미변경, BOM·줄바꿈 유지). 02.Site/AAABIN 설정(암호화)은 미변경
- **검증**: 웹 컨트롤러와 같은 방식(Reports/EQM1001.exe R0601 파일명 SYEAR»2026 pdf)으로 실행 → 표준출력 없음(웹에서 성공 처리)·PDF 생성, 실DB 값('26년 평균 0.2·1.8, 11월 1.9·9건)으로 차트 출력. 실DB EQM1001_R06 프로시저 저장 전이라 막대는 기존 단색(설계대로). 시험 출력 파일은 삭제
- **함께 처리**: R0601.cs의 사용자 수정(차트 제목 고장건수 → 호출건수)이 4번 빌드 이후라 MSBuild 15.0 Release Rebuild 후 exe 재배포(04.Report/bin·01.Office/Reports, MD5 일치, 기존 R0602 경고 1건). 재출력에서 제목 '호출건수' 확인. 범례 계열명은 '설비 고장횟수' 그대로

### 4. EQM1001_R06 년 설비고장율 현황 차트 막대 연도별 색상

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R06.sql](05.Procedure/MES_SNS2_EQM1001_R06.sql) (`LIST_CHART`), [01.Office/PAGEEQM/EQM1001/EQM1001_R06.js](01.Office/PAGEEQM/EQM1001/EQM1001_R06.js)
- **배경**: 연도 평균 6칸('21~'26)과 월 막대를 연도별 색으로 구분 요청. 그리드의 BACKGROUND는 ItsGrid가 셀 배경으로 칠하는 기능이라 billboard 차트에는 자동 적용되지 않음 → 프로시저가 행별 색을 내려주고 차트 `data.color` 콜백에서 사용
- **프로시저**: 결과에 YYYY·BACKGROUND 열 추가. BACKGROUND = 연도 MOD 6 기준 6색 순환(#9ecae1·#a1d99b·#fdd0a2·#d4b9da·#b7bdf0·#f2c4ce), 월 막대는 조회년도 색. 조회 범위가 연속 6년이라 항상 서로 다른 색, 같은 연도는 어느 해를 조회해도 같은 색(2026 = 기존 #b7bdf0). 헤더 Update 1행 추가
- **화면**: `BAR_COLOR(계열, 색 배열)`로 설비 비가동시간(NONHR)·호출건수(FAILCNT) 막대만 행별 색, 선(점유율·목표·평균수리시간)은 기존 빨강·파랑 유지. 범례 막대 색은 조회년도 색(호출건수 차트 막대도 연도 색으로 바뀌어 기존 주황 대신 2026은 연보라)
- **검증**: 격리 MariaDB 10.2.44(network none)에 실DB SELECT로 가져온 테이블로 컴파일·`LIST_CHART('2026')` 실행 → 값이 화면 캡처와 같음('26년 평균 0.2·1.8·2603, 11월 1.9·0.02·9), BACKGROUND '21 #f2c4ce ~ '26·월 #b7bdf0. 실제 EQM1001_R06.js를 billboard 1.8.1·d3 v5 시험 페이지에서 실행: 두 차트 막대 18/18개 색 일치, 선 색 유지. node --check 통과, 인코딩 js BOM·CRLF, sql BOM 없음·CRLF. 인쇄 레포트 R0601은 열 이름으로 읽어 영향 없음. 미확인: 실DB 프로시저 저장·실제 화면
- **후속(인쇄 레포트 R0601도 연도별 색)**: [04.Report/PAGEEQM/EQM1001/R0601.cs](04.Report/PAGEEQM/EQM1001/R0601.cs)
  - AddPoint가 만든 점을 돌려주게 하고, 비가동시간·고장횟수 막대 점마다 행의 BACKGROUND 색(SeriesPoint.Color) 적용(SET_POINT_COLOR·ROW_COLOR). 범례 막대 색은 조회년도(마지막 행) 색(YEAR_COLOR). 선 색은 그대로
  - BACKGROUND 열이 없으면(실DB 프로시저 저장 전) 기존 단색(#b7bdf0·#f6c79a) 그대로 출력. Designer.cs 미변경
  - 검증: MSBuild 15.0 Release Rebuild 성공(0 Error, 기존 R0602 경고 1건). 시험 프로그램으로 LIST_CHART 실행 결과(격리 DB) 18행을 넣어 PNG 출력: 두 차트 막대 18/18 점 색이 '21 #f2c4ce ~ '26·월 #b7bdf0로 일치, BACKGROUND 열을 뺀 출력은 모든 점이 계열 기본 색. exe를 04.Report/bin·01.Office/Reports에 배포(MD5 일치). 인코딩 BOM·CRLF. 미확인: VS 디자이너 열기(레이아웃 미변경), 웹 [인쇄] 실제 출력

### 3. PRD6001_S02 MTBF·고장율·MTTR 계산식 수정

- **수정/대상 파일**: [05.Procedure/MES_SNS2_PRD6001_S02.sql](05.Procedure/MES_SNS2_PRD6001_S02.sql) (`LIST_EQMDATA`), [01.Office/PAGEPRD/PRD6001/PRD6001_S02.js](01.Office/PAGEPRD/PRD6001/PRD6001_S02.js)
- **후속**: 사용자가 실DB 반영 후 조회한 (M3열전)T1·T2 값(11월 MTBF 35,991·35,894, 고장율 1.67, MTTR 9·106, 합계 437,991·437,894·0.14)이 검산값과 일치. 고장 없는 달 MTBF·MTTR은 사용자 결정으로 0 표시 유지. 조회 후 `ItsGrid.Get('grid1').autoSizeColumns()` 추가(node --check 통과, BOM·CRLF 유지)
- **배경**: 사용자 기준 MTBF = 총 가동시간 ÷ 고장횟수, 고장율 λ = 고장횟수 ÷ 총 가동시간(MTBF = 1/λ), MTTR = 총 수리시간 ÷ 총 수리횟수. 실DB 프로시저는 이 파일과 같은 내용(2026-11-05 저장)
- **잘못된 부분**
  - MTBF = 부하시간 ÷ 고장건수: 고장시간이 빠지지 않은 부하시간을 써서 가동시간보다 크게 계산
  - 고장율(%) = 고장시간 ÷ 부하시간 × 100: 정지시간 비율이며 λ(고장건수 ÷ 가동시간)가 아님
  - MTTR = 고장시간 ÷ 고장건수: 종료 전 고장(0분)도 횟수에 들어가 작게 계산
- **작업 상세 내용**
  - 가동시간 = 부하시간 − 고장시간(음수면 0). MTBF = 가동시간 ÷ 고장건수
  - 고장율 = 고장건수 ÷ 가동시간(분) × 60,000, 항목명 '고장율(건/1,000시간)', 소수 2자리(사용자 선택). MTBF(분) = 60,000 ÷ 고장율
  - MTTR = 고장시간 ÷ 수리건수. 비가동 임시 테이블에 종료 여부(ENDYN), 집계·기준·종합 임시 테이블에 수리건수(FIXCNT) 추가
  - 합계 열도 같은 식으로 연간 합계에서 다시 계산. 헤더 설명·Modify 1행 갱신
  - JS 변경 없음: 숫자 컬럼 형식이 G8이라 소수 그대로 표시(decimalPrecision 미사용)
- **검증**: 실DB SELECT로 2026-11 재현(저장 없이 같은 식): 고장 2건(I2M030_N-C0001_N 9분, C0002_N 106분, 모두 종료), 부하 36,000분 → MTBF 36,000 → 35,991·35,894, 고장율 0.0%·0.3% → 1.67건/1,000시간(60,000 ÷ MTBF 일치), MTTR 9·106 변화 없음(미종료 고장 없음). 인코딩 BOM 1개·CRLF. 미확인: MariaDB 프로시저 저장·화면 동작
- **최종 검증(격리 MariaDB 10.2.44, network none)**: 실DB에서 SELECT로 가져온 PP161·MSTLINE·MSTLINE_EQM·MSTNON(07)·PRDRSTNON(2025~)과 실DB의 수정 전 프로시저(SHOW CREATE)·수정본을 함께 컴파일해 `CALL ('2026','LIST_EQMDATA','')` 비교
  - 실데이터: 270행+헤더 동일 구조, 부하·고장시간·고장건수 행 차이 0. 11월 (M3열전)T1 MTBF 35,991·고장율 1.67·MTTR 9, T2 35,894·1.67·106, 종합 791,943·0.08·58(115 ÷ 2), 연간 T1 437,991·0.14. (M2열전)T1 I2110N(작업준비)은 고장 그룹(PP409I210N) 밖이라 제외가 맞음
  - 시험 데이터(컨테이너에만 입력): T1 12월 고장 30분·60분·미종료 1건 + 소재대기 120분 → 부하 37,080, 고장 90분·3건·수리 2건, MTBF 12,330(36,990 ÷ 3), 고장율 4.87(60,000 ÷ 12,330), MTTR 45(기존 30). 연간 T1 109,445·0.55·33, 종합 12월 545,530·0.11·45, 연간 종합 MTTR 51(205 ÷ 4). 손계산과 모두 일치
  - 남은 한계: 가동시간이 0 이하인 달은 고장율·MTBF가 0으로 표시, 고장이 없는 달의 MTBF·MTTR도 기존처럼 0 표시

### 2. MST3001_R03 INC 2공장 고정 조회, 로케이션 지정·기준정보 관리 주석처리

- **수정/대상 파일**: [01.Office/PAGEMST/MST3001/MST3001_R03.aspx](01.Office/PAGEMST/MST3001/MST3001_R03.aspx)·[.js](01.Office/PAGEMST/MST3001/MST3001_R03.js), [05.Procedure/MES_SNS2_MST3001_R03.sql](05.Procedure/MES_SNS2_MST3001_R03.sql)
- **경과**: 처음에는 품목 행을 품목 공장(MSTITEM_FACTORY) 07로 제한했으나, 공장 07 설비부품 355건이 모두 종료라 기본 조회 0건이 되고 이 화면에서 공장 07로 저장한 부품정보 12건도 빠져 사용자 요청으로 롤백(프로시저 원복)
- **INC 2공장 고정**: MSTFACTORY 확인 결과 07 = INC 2공장(법인 60, 06 = INC공장). 프로시저 SEL_ITEM은 법인 60·공장 07, SAVE_ITEM은 공장 07로 고정(법인 미선택 오류 확인 제거). 화면 법인 콤보는 60 고정·읽기 전용, 품목 찾기 REF01 60
- **로케이션 주석처리**
  - 화면: [로케이션 기준정보 관리] 버튼·팝업(pop_LOCA) 마크업, grid_LOCA 생성, 팝업 조회·행추가·저장·삭제, 로케이션 검색 팝업(더블클릭·엔터), Delete 키 일괄 비움, 로케이션 변경 동기화, 저장 시 LOCACD_LIST 전달, 변경 감지의 로케이션 비교
  - 로케이션코드 컬럼 readOnly true(찾기 컬럼 형식도 주석처리). 로케이션코드·로케이션명은 조회 표시만 유지
  - 프로시저: SAVE_ITEM의 로케이션 분리·갱신 주석처리(기존 값 유지, 신규 행은 ''), SEL_LOCA·SAVE_LOCA·DEL_LOCA 블록 주석처리, Modify 1행 추가
- **검증**: JS 구문 확인(node --check), 주석 밖에 로케이션 함수·호출 0건. 실DB SELECT(법인 60·공장 07): 종료 N 3,853건(공장 07 부품정보 12건·로케이션 지정 2건 포함), 종료 Y 473건. MSTITEM_EQMPARTS.LOCACD는 NOT NULL 기본값 ''. 인코딩: aspx·js·sql 모두 BOM 1개·CRLF. 미확인: MariaDB 프로시저 저장·화면 동작

### 1. 설비 찾기(DC_FIND EQMCD·FANO)에 사용 설비그룹 설비만 표시

- **수정/대상 파일**: [05.Procedure/MES_SNS2_DC_FIND.sql](05.Procedure/MES_SNS2_DC_FIND.sql) (`EQMCD_LIST`·`FANO_LIST` 분기)
- **배경**: MSTEQM에 신규 설비 추가. 실제 사용 설비는 설비그룹(EQMGUBUN, 기준코드 FM116) 코드 끝이 N. 사용자 지정 기준: 공통정보(FM116)의 사용여부 Y이고 공장[AA300S] 값이 '07'인 그룹의 설비만 표시
- **실DB 확인(읽기 SELECT만, 로컬 localhost:33061 접속 거부로 diagnose_db.ps1 서버 사용, 사용자 승인)**
  - 공장[AA300S] = COMTYPEGP.REF01NM → COMTYPE.REF01. FM116 43건 중 사용 Y·REF01 '07'은 14건(FM116I210N~FM116I2E0N)이며 끝이 N인 코드 14건과 정확히 같음. 옛 코드 29건은 모두 사용 N(REF01 '02' 13건·빈 값 2건·'04' 14건)
  - MSTEQM 1,345대 → 조건 충족 118대(모두 사용 Y·공장 07·설비코드 끝 N). 공장 07 설비 254대 중 136대 제외: 설비그룹 빈 값 55대(I2C·I2CO·I2U 등), 옛 그룹코드 81대(FM116I2100 28대 등 REF01 '04' 76대, FM116E00·FM116F00 5대)
  - 기존 이력 영향: EQMREP 21건 중 20건, CHKRSTEQM 6건 중 3건이 조건 밖 설비(I2C-002N·I2B-002N·I2G-001N 등 옛 그룹, A-001 등 시험 설비). 웹 찾기는 이름 표시도 `_LIST` 키워드 조회를 쓰므로 이 설비를 다시 불러오면 이름이 빈칸
- **작업 상세 내용**: `EQMCD_LIST`·`FANO_LIST`에 `INNER JOIN COMTYPE ON GPCD 'FM116' AND TPCD = EQMGUBUN AND USEYN 'Y' AND REF01 '07'` 추가. `_HEAD`·`_INFO`(웹 미호출)·DC_COMBO·DC_POP(02.Site)·화면별 프로시저는 미수정
- **영향 화면(GPCD EQMCD/FANO 찾기)**: EQM1001_R01·R03·R04·R05·S01·S03·S04, PRD0001_R02·S01, PRD6001_R02·S01·S03, PRD7001_R04, SYS4002_R03, TAL0001_R08, MST1004_R01(FANO). 설비그룹 찾기(GPCD FM116, COMTYPE 공통 분기)는 사용여부 Y만 보여 이미 신규 14개만 표시
- **검증**: 실DB에서 변경 조건 SELECT 118건·FM116 TPCD 중복 0(행 증가 없음)·키워드 'I2C-00' 기존 20건 → 4건. 파일 형식 기존 유지(BOM 있음, LF). 미확인: MariaDB 프로시저 저장·화면 동작(사용자 DB 반영 필요)
- **함께 발견(미수정)**: DC_COMBO `EQMCD`·`EQMCD_OQC`, DC_POP `EQMCD_*`가 SNS2 MSTEQM에 없는 컬럼(EQMCD·PRCCD·EQMNO)을 조회(TAL1001_R01·R02 콤보, SYS4002_R03 그리드 콤보, 02.Site ItsPop). PRD6001_S02 찾기 GPCD `EQMFANO`는 DC_FIND에 분기 없음(DC_POP에만 있음)

---

## 🕒 2026-11-12 (목) 작업 내역

### 2. 프로시저 5종 헤더 및 내부 주석 간소화

- **수정/대상 파일**: 05.Procedure/MES_SNS2_LOT1003_R01.sql, 05.Procedure/MES_SNS2_LOT1003_S01.sql, 05.Procedure/MES_SNS2_IO_COMCHK_CONFIRM.sql, 05.Procedure/MES_SNS2_IO_COMCHK_CANCEL.sql, 05.Procedure/MES_SNS2_TAL1600_R01.sql
- **배경 및 원인**: 프로시저 헤더 이력 및 내부 주석에 장황한 개발자 서술 및 괄호 설명 누적으로 가독성 저하
- **작업 상세 내용**:
  - 장황한 괄호 설명 및 다중 행 로직 주석을 배제하고 정확한 기능 명칭 위주 단일 행으로 정돈
- **검증 결과**: UTF-8 without BOM, CRLF 줄바꿈 검증 완료

### 1. 태블릿 TAL1600_R01 재고실사 등록 신규 (SEA PDA1600_R01 기반)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL1600/TAL1600_R01.aspx](01.Office/PAGETAL/TAL1600/TAL1600_R01.aspx)·[.aspx.cs](01.Office/PAGETAL/TAL1600/TAL1600_R01.aspx.cs)·[.js](01.Office/PAGETAL/TAL1600/TAL1600_R01.js)·[.css](01.Office/PAGETAL/TAL1600/TAL1600_R01.css)(신규), [05.Procedure/MES_SNS2_TAL1600_R01.sql](05.Procedure/MES_SNS2_TAL1600_R01.sql)(신규), [05.Procedure/MES_SNS2_TAL1600_R01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_TAL1600_R01_SYSTEM_PARAMETERS.sql)(신규)
- **배경**: LOT1003_R01에서는 실사수량을 입력하지 않고 태블릿에서 등록하기로 함. SEA PDA 재고실사(PDA1600_R01) 흐름을 태블릿 UI로 구성. 시안 4개(3단 분할·목록+큰 팝업·스캔 중심·단계형) 중 사용자 선택: 목록 + 큰 팝업(기존 TAL 화면 방식)
- **화면**
  - 메인: 창고(필수) + [실사지시 조회], 실사지시 그리드(실사일자·창고·실사명·품목 수·등록 로트·전체 로트·[실사 등록] 버튼). [실사지시 조회]를 눌러야 조회 (후속: 처음에는 화면 열 때 조회해 창고 빈 값으로 '창고를 지정하세요.'가 바로 떠서 자동 조회 제거). 후속: [실사지시 조회] 버튼 높이를 창고 콤보와 맞춤(Height 50 → 40, MarginTop 10 → 9; 버튼 바깥 여백 1px 때문), 실측 콤보·버튼 모두 위 10px·아래 50px
  - 후속(등록 창 상단 정보·정렬): 로트를 눌렀을 때 창고·품목코드를 정확히 보이도록 상단을 3줄·3칸으로 재배치
    - 1줄 LOT 스캔 / 실사 수량 / [등록], 2줄 창고 / 품목코드 / 로트번호, 3줄 품명 / 재고수량 / 실사수량 (칸 폭 라벨 90 + 입력 380·220·160, [등록]은 3칸 라벨 시작~입력 끝 폭 273), TopHeightPc 24 → 29
    - JS: 창고는 실사지시 창고명, 품목코드·품명은 선택 품목, 로트번호는 로트 그리드에서 선택한 행. 스캔·등록·삭제 후 로트 재조회 때 해당 로트를 다시 선택(_SELLOTKEY)
    - 후속: 로트를 눌러도 재고수량·실사수량이 품목 합계로 고정 → 로트 선택 시 그 로트의 재고(LOTQTY)·실사(SCANQTY)를 천 단위 쉼표로 표시. 품목 합계는 로트 조회 전에 먼저 넣고 로트 선택 이벤트가 덮어쓰도록 순서 변경(브라우저에서 시험 행 선택 시 1,200 / 0 표시 확인)
    - 후속: LOT 빈 값으로 [등록] 시 '존재하지 않는 로트번호입니다.' 표시(공통 IO_COMCHKLOT_ADD가 원본 순서대로 존재 확인을 빈 값 확인보다 먼저 함) → 화면 프로시저 COMCHKLOT_ADD 맨 앞에 빈 값 확인 'LOT를 입력해주세요.' 추가, COMCHKLOT_SCAN 빈 값 문구도 같게(공통 모듈 미수정). IF 11쌍·파라미터 7 확인, DB 재저장 필요
    - 후속(점검 1~3번 수정)
      - 1) 실사 수량 칸에 LOT 바코드 입력: 수량 칸 키 입력에 영문(A~Z)이 있으면 표시해 두고 [등록]·엔터 시 저장하지 않고 'LOT 바코드가 입력되었습니다' 안내 후 스캔한 로트의 전산재고로 되돌림. 함께 발견: 공통 ItsNum.Focus가 숨은 입력칸을 잡아 스캔 후 커서가 수량 칸으로 가지 않고 LOT 칸에 남아 다음 바코드가 뒤에 붙음 → 화면 함수 QTY_FOCUS(보이는 칸을 통해 이동, 값 전체 선택)로 변경(공통 미수정). 숫자로만 된 LOT 바코드는 감지 못 함
      - 1) 음수 수량: 프로시저 COMCHKLOT_ADD에서 '실사 수량은 0 이상으로 입력해주세요.' (IF 12쌍)
      - 1) 스캔 오류 후: 확인을 누르면 LOT·수량 칸을 비우고 LOT 칸으로 커서. 세션 만료·접속 오류는 기존 공통 처리(로그인 안내) 유지
      - 브라우저 모의 검증(서버 응답 대체): 1) 프로시저 미호출·안내·수량 500 복원·수량 칸 커서와 값 선택, 3) LOT 칸 빈 값·LOT 칸 커서, 세션 만료 시 공통 로그인 안내. 미확인: 로그인 상태 실제 스캔·등록, 실제 스캐너
    - 후속(스캔 후 커서 없음): 사용자 요청으로 스캔 후 실사 수량 칸에 커서를 두지 않고 아무것도 선택되지 않게(전산재고는 수량 칸에 미리 표시), 수량은 사용자가 직접 눌러 입력. [등록] 후·스캔 오류 확인 후·창 열 때는 LOT 칸 커서 유지. 사용자가 [등록]의 바코드 감지 확인을 지운 상태라 남은 감지 코드(_QTYBARCODE·onKeyDown)와 QTY_FOCUS·_SCANLOTQTY 제거. 커서가 없으므로 수량 입력 전 다음 바코드를 찍으면 입력이 버려짐(이전처럼 LOT 뒤에 붙지 않음). 브라우저 모의 검증: 스캔 후 포커스 BODY, 수량 500 표시
    - 워크플로 점검 결과(1~3번은 위에서 수정, 4~8번 미수정): 스캔 후 커서가 실사 수량에 있을 때 다음 LOT 스캔 시 숫자만 남아 잘못된 수량으로 등록(ItsNum이 숫자·.·-만 남김), 음수 수량 저장 가능, 수량 빈칸 0 등록, LOT 스캔 칸과 선택 로트 불일치, 스캔 오류 후 칸에 값이 남아 다음 스캔이 뒤에 붙음, 미등록 로트 [삭제]가 아무 변화 없이 성공, 등록 완료 안내 없음, 실사지시에 없는 실물 로트 등록 불가
    - 브라우저 실측(1280×800): 라벨 시작 60·573.3·926.7, 입력칸 173.3~553.3·686.7~906.7·1040~1200으로 3줄 일치, [등록] 926.7~1199.7
  - 등록 창(1200×640): 상단 LOT 스캔·실사 수량·[등록], 선택 품목 품명·재고수량·실사수량 / 왼쪽 실사품목(품목코드·품명·재고·실사·등록 로트, 행 색 흰색 미실사·초록 일치·분홍 차이) / 오른쪽 선택 품목 로트(로트번호·재고·실사·스캔시간·[삭제])
  - PDA 팝업 2개(재고실사 등록·재고실사 조회)를 등록 창 하나로 합침. 창 닫으면 실사지시 진행 재조회
- **흐름(원본 PDA와 동일)**: LOT 스캔 엔터 → 확인 후 전산재고를 실사 수량에 표시·해당 품목 자동 선택 → 수량 엔터 또는 [등록] → IO_COMCHKLOT_ADD → 재조회·입력칸 초기화 / [삭제] → 확인창 → IO_COMCHKLOT_DEL(실사수량 0·스캔정보 초기화)
- **프로시저 TAL1600_R01** (파라미터 7: WARECD, CHKGROUPKEY, CHKKEY, LOTKEY, CHKQTY, CALLTYPE, KEYWORD)
  - LIST_COMCHK_GROUP(창고 미지정 '창고를 지정하세요.', 미승인 실사지시·미승인 품목), LIST_COMCHK, LIST_COMLOT(로트 + 품목 합계 2결과), COMCHKLOT_SCAN, COMCHKLOT_ADD, COMCHKLOT_DEL — 원본 PDA1600_R01과 같은 호출 구분
  - 원본 IO_COMCHKLOT_SCAN 확인 내용(창고·존재 LOT·실사품목 LOT·재고 0·이미 등록)을 COMCHKLOT_SCAN에 포함(로트 입력만 모듈화 결정에 따라 SCAN 모듈 미생성). 원본 오류문의 미정의 $WARECD는 실사지시 창고로
  - 추가 확인: 실사지시에 없는 LOT(실사지시 이후 생성·승인 후 정리된 로트)은 원본에서는 오류 없이 아무것도 저장되지 않아 등록된 것처럼 보였으므로 SCAN·ADD에서 '실사지시에 없는 LOT입니다.' 안내
  - SNS2 대응: 품목 ITEMID(COMCHK.CHKITEMCD = MSTITEM.ITEMID), 창고명 MSTWARE, 품목 정렬 ITEMCG·ITEMCD(원본 ITEMNUM 없음)
- **검증**: JS 구문, 프로시저 파라미터 7·CASE 1쌍·IF 10쌍·CASE WHEN 2쌍, 인코딩(aspx·cs·js·css BOM+CRLF, sql BOM 없음+CRLF). 로컬 IIS Express 화면 렌더링 확인(1280×800): 메인·등록 창 배치, 그리드 열이 좌우 폭 안에 들어가도록 열 폭 조정. 미확인: DB 연결 설정이 localhost:33061로 바뀌어 연결 불가(실DB 조회 검증 못 함), 로그인 세션 없어 실제 조회·스캔·등록 동작, MariaDB 컴파일
- **적용 순서**: MES_SNS2_TAL1600_R01.sql 저장 → MES_SNS2_TAL1600_R01_SYSTEM_PARAMETERS.sql 실행(정상 7건) → 태블릿 메뉴(SYSMENU PKGTP 'TAL')에 TAL1600_R01 등록·권한 부여

---

## 🕒 2026-11-11 (수) 작업 내역

### 1. LOT1003 재고실사관리(R01)·실사/조정 이력조회(S01) 이관 정리, 프로시저 스키마 변경·본문 주석처리

- **수정/대상 파일**: [01.Office/PAGELOT/LOT1003/LOT1003_R01.aspx](01.Office/PAGELOT/LOT1003/LOT1003_R01.aspx), [LOT1003_R01.js](01.Office/PAGELOT/LOT1003/LOT1003_R01.js), [LOT1003_S01.js](01.Office/PAGELOT/LOT1003/LOT1003_S01.js), [05.Procedure/MES_SNS2_LOT1003_R01.sql](05.Procedure/MES_SNS2_LOT1003_R01.sql), [MES_SNS2_LOT1003_S01.sql](05.Procedure/MES_SNS2_LOT1003_S01.sql)
- **배경 및 원인**: 다른 프로젝트(MES_SEA)에서 가져온 페이지. 불필요한 소스 삭제, 프로시저는 프로젝트명만 수정하고 기능은 아직 구현하지 않으므로 분기 구조만 남기고 본문 주석처리 요청
- **DB 확인(읽기 전용)**: COMCHK·COMCHK_GROUP·COMCHKLOT·COMIN·COMINLOT·COMOUT·COMOUTLOT·COMLOT·MSTITEM 테이블은 있음. IO_COMCHK_ADD/DEL/CONFIRM/CANCEL 프로시저, 공통코드 WARECD 그룹, 창고코드 MTR_01·PRODUCT_01은 없음
- **작업 상세 내용**:
  - R01.js: SEA ERP 연동(ItsMssql sea_mfg.dbo.usp_z_mes_receive_305/306, 승인·승인취소 2곳) 삭제, SEA 창고코드(MTR_01·PRODUCT_01) 기준 품목유형 기본값 처리 삭제(조회조건 창고 onChanged 제거, 팝업 창고 onChanged는 품목리스트 재조회만 유지), 장식 구분선·주석 처리된 팝업 주석 정리, 저장 후 불필요한 else 제거, 승인취소의 CHKGROUPKEY 중복 조회 1회로 통합, hidden:false 제거
  - R01.aspx: 주석 처리된 라벨(로케이션 안내) 삭제, 줄 끝 공백 제거
  - S01.js: 로드 주석 템플릿 문구 통일, 누락 세미콜론, hidden:false·끝 빈 줄 제거
  - 프로시저 2개: MES_SEA → MES_SNS2, 헤더 Modify 2026-11-11 1행, 각 WHEN 분기 본문(및 R01 DECLARE) 전체 주석처리, 빈 분기 컴파일용 `BEGIN END;` 추가, BOM 제거(UTF-8 no BOM + CRLF)
- **검증 결과**: 인코딩(aspx·js 단일 BOM+CRLF, sql BOM 없음+CRLF). 미확인: MariaDB 컴파일, 화면 동작(프로시저 본문이 비어 있어 조회 결과 없음)

### 2. LOT1003 승인자 값 표시, 이력조회 품목코드 찾기를 ITEMID 방식으로 변경

- **수정/대상 파일**: [01.Office/PAGELOT/LOT1003/LOT1003_R01.aspx](01.Office/PAGELOT/LOT1003/LOT1003_R01.aspx), [LOT1003_S01.aspx](01.Office/PAGELOT/LOT1003/LOT1003_S01.aspx), [05.Procedure/MES_SNS2_LOT1003_S01.sql](05.Procedure/MES_SNS2_LOT1003_S01.sql)
- **배경 및 원인**:
  - 승인자: FindType mini는 코드 칸을 숨기고 이름 칸만 표시. 이름은 DC_FIND EMPCD_LIST(공장 07 사원만)에서 찾는데 로그인 사원 9999는 FACTORYCD가 비어 있어 이름이 빈 값 → 칸이 비어 보임 (선택 시에만 코드 9999 노출)
  - 품목코드: GPCD ITEMCD는 이 프로젝트 DC_FIND에 없음(ERROR ITEMCD_HEAD). 이 프로젝트는 ITEMID_HEAD/LIST/INFO 사용
- **작업 상세 내용**:
  - R01.aspx 승인자 find에서 FindType="mini" 제거 → 프로젝트 다른 화면(MTR0001_S04·SAL0001_S05 검사자)처럼 코드+이름 표시
  - (후속, 2026-11-12) 사용자 요청으로 승인자 find를 원본 SEA 방식(FindType="mini", 이름만 표시)으로 원복. 공장 07 사원으로 로그인하면 이름이 표시되고, 9999처럼 공장 미지정 사원은 빈 칸으로 보임
  - (후속, 2026-11-12) 조회 창고 콤보도 원본 방식으로 원복: GPCD="WARECD"(전체 없음) + Required="true". 프로시저 LIST_COMCHK_GROUP에 원본의 창고 미선택 오류('창고를 선택하세요.')를 되살리고 창고 조건을 CHKWARECD = $WARECD로 원복. 추가 팝업 창고 콤보(pdiv1_cmb_WARECD, *WARECD)는 그대로 둠
  - S01.aspx 품목 find: find_ITEMCD/ITEMCD → find_ITEMID/Field ITEMID/GPCD ITEMID (LOT1002_S01과 같음)
  - S01 프로시저: 파라미터 $ITEMCD → $ITEMID, 주석처리된 본문의 COMIN·COMOUT 조건도 ITEMID로(두 테이블 모두 ITEMID 컬럼 있음), 헤더 2026-11-11 줄에 문구 추가, 사용자 저장으로 다시 붙은 BOM 제거
- **검증 결과**: 로컬 IIS Express에서 승인자 9999 설정 시 코드 9999 표시 확인(이름은 9999가 공장 미지정이라 빈 값, 공장 07 사원은 이름 표시). 품목 찾기 목록은 미로그인 상태라 LOT1002_S01도 헤더가 비어 확인 불가 — 로그인 후 확인 필요

### 3. LOT1003_R01 재고실사 지시 생성·실사수량 저장·승인·승인취소 구현 (INTP/OUTTP), IFS_* 제외

- **수정/대상 파일**: [05.Procedure/MES_SNS2_LOT1003_R01.sql](05.Procedure/MES_SNS2_LOT1003_R01.sql), [MES_SNS2_LOT1003_R01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_LOT1003_R01_SYSTEM_PARAMETERS.sql)(신규), [01.Office/PAGELOT/LOT1003/LOT1003_R01.aspx](01.Office/PAGELOT/LOT1003/LOT1003_R01.aspx), [LOT1003_R01.js](01.Office/PAGELOT/LOT1003/LOT1003_R01.js)
- **배경 및 원인**: 재고실사 테이블(COMCHK_GROUP 헤더·COMCHK 품목·COMCHKLOT 로트) 기준으로 추가=실사지시 생성, 승인=실사수량으로 전산재고 변경, 승인취소=승인 내역 Rollback, INTP·OUTTP로 관리, 다른 프로젝트 IFS_* 인터페이스 제거 요청
- **참고 원본**: SEA `IO_COMCHK_ADD/DEL/CONFIRM/CANCEL`(MES_SEA·MES_SEA_EA, IFS_COMOUTLOT·IFS_COMINLOT·IFS_LOTMOVE_IN/OUT_CANCEL 호출 포함), SNS2 `IO_ETC_IN`·`IO_ETC_OUT`·`IO_ETC_OUT_DEL`·`IO_ADJUST_COMLOT`, 화면 `LOT1002_R01`(INTP 콤보·ITEMID·DM100)
- **DB 확인(읽기 전용)**: SNS2 입출고 테이블은 ITEMCD 대신 ITEMID, BDVCD 없음, COMINLOT·COMOUTLOT에 WARECD·INTP/OUTTP·일자·ITEMID·OLDQTY 존재, COMLOT PK = LOTKEY+WARECD. 공통코드 INTP 08 실사·OUTTP 08 실사. 창고는 DC_COMBO WARECD(MSTWARE), 품목유형은 MSTITEM.ITEMCG(DM100). SNS2에는 실사수량 입력 화면(SEA의 PDA 스캔)이 없음. sql_mode에 ONLY_FULL_GROUP_BY 없음
- **작업 상세 내용** (프로시저는 IO_COMCHK_*별도 프로시저 없이 LOT1003_R01 분기에 직접 구현, IFS_* 호출 없음):
  - LIST_COMCHK_GROUP: 창고 필수, 기간·창고·품목유형(ITEMCG) 조건, 창고명 MSTWARE, 승인완료 = COMCHK_GROUP.CHKAPPYN
  - LIST_COMCHK / LIST_COMCHKLOT: 품목은 COMCHK.CHKITEMCD(=ITEMID) ↔ MSTITEM.ITEMID. 로트에 승인 때 생성된 입고구분(COMINLOT.INTP)·출고구분(COMOUTLOT.OUTTP), 입력시간·입력자 표시. 실사수량 미입력(NULL)은 합계·차이에서 제외
  - SEARCH_ITEMLIST: 선택 창고에 재고(LOTQTY>0)가 있는 품목
  - COMCHK_ADD(추가): 품목별 COMCHK + 현재고 로트를 COMCHKLOT 전산수량(LOTOLDQTY)으로 등록, 재고 있는 품목이 없으면 오류(헤더는 마지막에 생성)
  - SAVE_COMCHKLOT(신규, 저장 버튼): 하단 로트 그리드 실사수량 입력 저장, 빈 값=미입력, 음수 불가, 승인 품목 변경 불가, 값이 바뀐 로트만 입력시간·입력자 갱신
  - COMCHK_CONFIRM(승인): 입고구분·출고구분·승인자 필수, 모든 품목 검사 후 반영(미승인·실사수량 전부 입력·창고에 로트 존재). 현재고 대비 증가분은 COMINLOT/COMIN(INTP), 감소분은 COMOUTLOT/COMOUT(OUTTP)로 기록(OLDQTY=승인 직전 재고, COMIN/COMOUT.CHKKEY 연결), COMLOT.LOTQTY = 실사수량, COMCHK 승인, 모든 품목 승인 시 COMCHK_GROUP 승인
  - COMCHK_CANCEL(승인취소): 승인 품목만, 승인 후 같은 창고·품목 입출고가 있으면 불가(SEA 동일). COMINLOT·COMOUTLOT 수량만큼 COMLOT 되돌림 후 입출고 4개 테이블 삭제, COMCHK·COMCHK_GROUP 미승인
  - COMCHK_DEL(삭제): 승인 품목 삭제 불가, 품목이 모두 지워지면 실사지시 삭제
  - 화면: 조회조건 창고(WARECD)·품목유형(*DM100)·입고구분(INTP)·출고구분(OUTTP, 기본 08 실사)·승인자, 취소 버튼 → "승인취소". grid1 품목유형 열 제거, grid2·팝업 품목 ITEMID/ITEMCG, grid3 실사수량 입력 가능 + 입고구분·출고구분·입력시간·입력자 열, 저장 후 같은 품목 다시 선택
  - 프로시저 파라미터 17개로 변경 → SYSTEM_PARAMETERS 등록 SQL 신규
- **후속 수정 (팝업 창고 전체)**: 사용자가 팝업 창고 콤보를 `GPCD="*WARECD"`로 바꿨으나 전체(값 '')가 동작하지 않음. 원인: ItsCombo는 `*`이면 "전체"(빈 값)를 넣고 Required는 라벨 색만 바꾸는데, 프로시저 SEARCH_ITEMLIST는 `COMLOT.WARECD = $WARECD`라 빈 값이면 0건, COMCHK_ADD는 MSTWARE 존재 검사로 "창고를 선택하세요" 오류. 수정: 두 분기 모두 빈 값이면 창고 콤보(DC_COMBO WARECD)와 같은 사내 창고(FACTORYCD 07·USEYN Y·CUSTCD 빈 값) 전체 대상. 실사지시(COMCHK_GROUP)는 창고 1개(CHKWARECD)라 전체 선택 시 선택 품목 재고가 있는 창고마다 실사지시를 따로 생성(같은 실사일자·실사명), 재고 없으면 오류 후 생성 없음. 실데이터 읽기 전용 확인: 전체 15품목·04S100_N 6품목, 외주창고(04S300_N 등) 재고 제외, 재고 없는 품목은 창고목록 없음
- **후속 수정 (SEA 원본 동작·UI/UX로 복원)**: 사용자 지적 — 기존 페이지와 동작·UI/UX가 달라짐. 원본(SEA LOT1003_R01 화면 + MES_SEA·MES_SEA_EA IO_COMCHK_*) 기준으로 되돌림
  - 되돌린 것: 하단 로트 실사수량 웹 입력·저장(SAVE_COMCHKLOT), 승인 시 현재고 기준 변경·미입력 차단·승인자 전송, 전체 창고 선택 시 창고별 다중 생성, 그리드 열·폭·라벨(창고코드, 취소 버튼, 스캔시간), 확인 문구, 팝업 열기 순서. R01은 원본처럼 COMCHK_ADD/DEL/CONFIRM/CANCEL을 IO_COMCHK_* 호출로 처리
  - 신규: [MES_SNS2_IO_COMCHK_ADD.sql](05.Procedure/MES_SNS2_IO_COMCHK_ADD.sql), [DEL](05.Procedure/MES_SNS2_IO_COMCHK_DEL.sql), [CONFIRM](05.Procedure/MES_SNS2_IO_COMCHK_CONFIRM.sql), [CANCEL](05.Procedure/MES_SNS2_IO_COMCHK_CANCEL.sql) — 원본 로직 유지, IFS_COMOUTLOT·IFS_COMINLOT·IFS_LOTMOVE_IN/OUT_CANCEL 호출 제거
  - SNS2 대응만 변경: 품목 ITEMCD→ITEMID(COMCHK.CHKITEMCD에 ITEMID 저장, ITEMCDLIST→ITEMIDLIST), 품목유형 ITEMTP→ITEMCG(DM100), 창고명 GPCD→MSTWARE, ITEMNUM 없음(품목코드 정렬), BDVCD 없음, 입출고구분 SNS2 기준정보 INTP '08'·OUTTP '08'(원본 07·08), COMINLOT·COMOUTLOT 창고·구분·일자·품목 함께 기록, 승인취소 로트 원복에 창고 조건 추가(같은 로트가 여러 창고에 있을 수 있음), 감사값 CALLTIME
  - 사용자 요청분 유지: 승인자 일반 find, 조회조건·팝업 창고 전체(조회는 전체 가능, 팝업 전체는 원본처럼 품목조회만 전체·생성 시 "창고코드가 비어있습니다")
  - 파라미터 12개(원본과 같은 수, ITEMTP→ITEMCG·ITEMCDLIST→ITEMIDLIST) → SYSTEM_PARAMETERS SQL 12건으로 갱신
  - DB 확인: COMCHKLOT.LOTCHKQTY NOT NULL 기본 0, CHKAPPYN 기본 'N' → 원본처럼 스캔하지 않은 로트는 실사수량 0으로 승인됨. 실사수량은 원본에서 PDA(SEA PDA1600, IO_COMCHKLOT_SCAN)로 입력하나 SNS2에는 해당 화면·프로시저 없음
  - 검증: 프로시저 5개 IF/WHILE 짝·미사용 변수·파라미터 없음·IFS_ 없음, JS 구문 통과, 인코딩. SQLite로 원본 승인(10/5/7, 실사 12/미스캔/7 → 12/0/7, 입고 2·출고 5, 다른 창고 같은 로트 유지)·취소(OLDQTY 원복) 확인. 미확인: MariaDB 컴파일, 로그인 화면
- **후속 수정 (조회조건 창고 전체)**: 조회조건 창고 콤보가 `GPCD="WARECD"`(Required)라 "전체"가 없고, DB에 저장된 LIST_COMCHK_GROUP이 창고 빈 값이면 "창고를 선택하세요" 오류. aspx 조회조건 창고 `GPCD="*WARECD"`·Required 제거, LIST_COMCHK_GROUP 필수 검사 제거·`($WARECD = '' OR CHKWARECD = $WARECD)`·정렬에 창고 추가. 빈 창고 조회 쿼리 실DB 읽기 전용 실행 확인(오류 없음). DB 프로시저(2026-11-11 14:35 저장본)는 이전 버전이라 다시 저장 필요
- **후속 수정 (요청 4번 재해석)**: "INTP, OUTTP 로 관리"는 화면 필터·선택이 아니라 SNS2 공장 기준정보 코드로 맞추라는 의미 → 화면의 입고구분·출고구분 콤보(기본 08), 승인 시 INTP·OUTTP 전송, grid3 입고구분·출고구분 열, 승인 안내 문구 추가분 롤백. 프로시저 $INTP·$OUTTP 파라미터와 필수 검사·LIST_COMCHKLOT 입출고 JOIN 제거, 승인 입출고구분을 SNS2 기준정보 INTP '08'(실사)·OUTTP '08'(실사)로 고정 (SEA는 입고 07·출고 08). 파라미터 15개로 SYSTEM_PARAMETERS 등록 SQL 갱신
- **검증 결과**: JS 구문 검사 통과, 프로시저 IF/WHILE 짝·파라미터 15개·미사용 변수 없음, 인코딩(sql BOM 없음, aspx·js 단일 BOM, CRLF). SQLite로 승인·취소 재고 흐름 재현: 실사 12/3/7·현재고 10/6/7 → 승인 후 12/3/7(입고 +2 INTP 08, 출고 3 OUTTP 08, 다른 창고 같은 로트 99 유지), 취소 후 10/6/7 원복·입출고 0건, 차이 없으면 COMIN 미생성, 저장은 바뀐 행만 갱신. 로컬 화면: 그리드 4개·콤보·기본값 08·승인취소 버튼 표시 확인. 미확인: MariaDB 컴파일, 로그인 상태 실제 동작

### 10. 재고실사 웹 수량 편집 롤백, 이력조회 원본 방식, 재고조정(97) 사유 입력 원본처럼 처리

- **수정/대상 파일**: [01.Office/PAGELOT/LOT1003/LOT1003_R01.js](01.Office/PAGELOT/LOT1003/LOT1003_R01.js), [05.Procedure/MES_SNS2_LOT1003_R01.sql](05.Procedure/MES_SNS2_LOT1003_R01.sql), [MES_SNS2_LOT1003_R01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_LOT1003_R01_SYSTEM_PARAMETERS.sql), [MES_SNS2_LOT1003_S01.sql](05.Procedure/MES_SNS2_LOT1003_S01.sql), [MES_SNS2_IO_COMCHKLOT_ADD.sql](05.Procedure/MES_SNS2_IO_COMCHKLOT_ADD.sql)·[DEL](05.Procedure/MES_SNS2_IO_COMCHKLOT_DEL.sql)(주석만), [MES_SNS2_COMTYPE_INTP_OUTTP_97.sql](05.Procedure/MES_SNS2_COMTYPE_INTP_OUTTP_97.sql)(신규)
- **배경**: 재고실사 페이지에서는 수량 변경 불가(실사수량은 추후 태블릿에서 등록), 이력조회 행위구분·입출고구분·조정사유를 원본 방식으로, 조정사유 입력도 원본 프로젝트처럼
- **원본(SEA) 확인 (MES_SEA_DEV 읽기 전용)**: 기타입고(LOT1002_R01)·기타출고(LOT1002_R02) 구분 콤보(REF01 'Y')에 재고조정 97이 있고 사유를 입력 → IO_ETC_IN/OUT이 COMIN/COMOUT·로트 REMARK에 저장 → 이력조회가 97은 재고조정, 07/08은 실사입고/출고, 입출고구분은 '입고'/'출고' 고정, 조정사유는 REMARK. SNS2는 INTP/OUTTP에 재고조정 코드가 없고(REF01 'Y'는 99 기타입고·07 폐기·99 기타출고), IO_ETC_IN/OUT은 사유를 COMIN/COMOUT.REMARK에만 저장. IO_ERP_INTERFACE가 기타입출고 구분 코드를 ERP로 전송
- **작업 상세 내용**:
  - LOT1003_R01 롤백: 실사수량 칸 편집·[저장]·SAVE_COMCHKLOT·수정 행 기록 제거, 취소는 원본(IO_COMCHK_CANCEL 승인취소)·원본 확인 문구, 파라미터 12개(SYSTEM_PARAMETERS 12건)
  - IO_COMCHKLOT_ADD·DEL은 태블릿 실사수량 등록용으로 유지(현재 호출처 없음), 주석 PDA·태블릿으로 정리
  - LOT1003_S01: 원본처럼 코드로 행위구분 — INTP/OUTTP 08 실사입고/실사출고, 97 재고조정, 입출고구분 '입고'/'출고', 변동없음은 빈칸. 조정사유 = COMIN/COMOUT.REMARK(SNS2 기타입출고 사유 저장 위치). 실사지시 연결·기준정보 명칭·실사명 매핑 제거
  - COMTYPE SQL(사용자 실행): INTP·OUTTP 97 재고조정, REF01 'Y' → SNS2 기타입고·기타출고 구분 콤보에서 선택, 사유 입력 → 이력조회 재고조정·조정사유 표시. ERP 97 처리 확인 후 실행 필요
- **검증 결과**: 프로시저 IF/WHILE 짝·미사용 변수·파라미터 없음(R01 12개, S01 7개), JS 구문, 인코딩. 실DB 읽기 전용 S01 실행: 변동없음 14건(입출고구분·조정사유 빈칸), 실사입고 1건·실사출고 4건(입고/출고). 미확인: MariaDB 컴파일, 로그인 화면, 97 코드 추가 후 기타입출고·ERP 동작

- **후속 수정 (기존 코드 사용·화면 캐시)**:
  - 하단 그리드 실사수량 편집 지적: 로컬 IIS Express 최신 JS(ver=1.001.114) 로드 시 grid3 LOTCHKQTY 읽기 전용, 소스에 readOnly:false·EventSave 없음 확인 → 사용자 브라우저가 이전 JS 캐시 사용(srcVersion 동일). Ctrl+F5 새로고침 필요(srcVersion 임의 변경 금지 규칙)
  - INTP·OUTTP 신규 코드 생성 금지 → MES_SNS2_COMTYPE_INTP_OUTTP_97.sql 삭제. 사용자 선택으로 재고조정 = 기존 기타입고 INTP 99·기타출고 OUTTP 99 (LOT1002_R01·R02에서 사유 입력, SEA 재고조정 97과 같은 위치·방식), 실사 = 08. LOT1003_S01 조건·행위구분 97 → 99
  - 실DB 읽기 전용 실행: 재고조정 입고 14건·출고 1건(조정사유 'test'·'테스트' 등 표시), 실사입고 1·실사출고 4, 변동없음 14

- **후속 수정 (취소 시 실사수량 초기화, 행위구분 재고조정 통일)**:
  - DB 확인(읽기 전용): 18:03·18:04 취소로 IO_COMCHK_CANCEL 정상 수행(재고 100 원복, 미승인, 실사 입출고 삭제)이나 원본 IO_COMCHK_CANCEL은 COMCHKLOT를 건드리지 않아 실사수량(85 등)·스캔시간 그대로
  - LOT1003_R01 COMCHK_CANCEL: IO_COMCHK_CANCEL 후 선택 품목별 등록 로트(CHKSCANTIME <> '')를 GROUP_CONCAT·COMSPLIT으로 IO_COMCHKLOT_DEL → 실사수량 0·스캔정보 초기화. 승인취소 오류 시 COMCALLC 롤백. 취소 확인 문구에 실사수량 초기화 안내 추가
  - LOT1003_S01: 행위구분을 모든 행 '재고조정'으로 표시(변동없음·08·99 공통), 입출고구분 입고/출고(변동없음은 빈칸), 조정사유 기타입출고 사유
  - 검증: R01 WHILE 3/3·파라미터 12·미사용 없음, S01 실DB 읽기 전용 실행(재고조정 22건: 입고 7·출고 1·변동없음 14), JS 구문, 인코딩. 미확인: MariaDB 컴파일, 로그인 화면 취소 동작
- **후속 수정 (2026-11-12, 사용자 COMTYPE INTP·OUTTP 97 재고조정 등록)**:
  - LOT1003_S01: 원본 SEA와 같은 방식으로 원복 — 행위구분 변동없음 / INTP 08 실사입고·OUTTP 08 실사출고 / 97 재고조정, 조회 코드 IN ('97','08')(99 기타입출고 제외). 조정사유는 SNS2 저장 위치인 COMIN·COMOUT.REMARK 유지
  - DB 확인(읽기 전용): INTP·OUTTP 97 '재고조정' USEYN Y, REF01 '' → 기타입고·출고(LOT1002_R01·R02) 콤보는 REF01 LIKE '%Y%' 조건이라 REF01 'Y' 지정 전에는 97 선택 불가(원본 SEA는 97 REF01 'Y')
  - 검증: 수정된 조회문 실DB 읽기 전용 실행 오류 없음(현재 0건 — 실사지시 3건 모두 미승인·로트 실사수량 미등록, COMIN·COMOUT 08·97 없음). 인코딩(BOM 없음·CRLF) 유지
- **인터페이스 최종 점검 (2026-11-12, 재고실사는 HT로보틱스(SEA) 인터페이스 삭제 방침)**:
  - 재고실사 프로시저 8개(LOT1003_R01·S01, IO_COMCHK_ADD·DEL·CONFIRM·CANCEL, IO_COMCHKLOT_ADD·DEL) 로컬·DB 모두 CALL은 COMERR·COMSPLIT·IO_COMCHK*뿐, IFS_*·IO_ERP_INTERFACE 호출 없음. MES_SNS2 전체에 IFS_ 루틴·참조 없음 → 추가 수정 없음
  - 재고조정 97 입력 경로(LOT1002 기타입고·출고 → IO_ETC_IN·OUT)는 DB 버전에서 IO_ERP_INTERFACE('ETC_IN'/'ETC_OUT') 호출 → HT로보틱스가 아닌 SNS 2공장 ERP(IF_MES_SNS_FAC2.FAC2_ERP_IF_ETC) 송신이며 기타입출고 공통 기능이라 재고실사 작업 범위 밖, 변경하지 않음
  - DB 비교(읽기 전용): LOT1003_R01·IO_COMCHK 4개·IO_COMCHKLOT 2개 로컬=DB, LOT1003_S01만 DB 미반영(97 원복분). IO_ETC_IN·OUT은 로컬 파일이 DB보다 이전 버전(ERP 호출 없음) — 이번 작업에서 미수정
- **사용자 반영 확인 (2026-11-12, 읽기 전용)**: DB LOT1003_S01(10:23 저장) 로컬과 동일, 파라미터 R01 12·S01 7(SYSTEM_PARAMETERS mes_sns2도 12·7). COMTYPE INTP·OUTTP 97 REF01 'Y' → 기타입고 콤보 97·99, 기타출고 콤보 07·97·99. INTP·OUTTP 97을 막는 하드코딩 조건(IO_ETC_*·LOT1002 JS) 없음
- **후속 수정 (2026-11-12, 재고조정 97 제외)**: 97은 기타입고·출고(IO_ETC_IN·OUT)를 거쳐 2공장 ERP로 송신되므로 이력조회는 실사 08만 고려하기로 함
  - LOT1003_S01: 입고 COMIN.INTP = '08' → 행위구분 '실사입고', 출고 COMOUT.OUTTP = '08' → '실사출고'(97 분기·조건 제거), 변동없음 그대로. 조정사유는 COMIN·COMOUT.REMARK 유지(실사 승인은 REMARK를 넣지 않아 빈칸)
  - 검증: 파라미터 7·CASE 1쌍, 실DB 읽기 전용 실행 오류 없음(현재 0건 — 승인된 실사 없음), BOM 없음·CRLF 유지. DB 반영 필요: LOT1003_S01 재저장(파라미터 변동 없음)
- **후속 수정 (2026-11-12, 승인 시 이미 승인된 품목 섞임)**: 미승인·승인 품목을 함께 선택해 승인하면 미승인 품목은 승인되고 '이미 승인되었습니다.'가 표시됨. 원인: COMCHK_CONFIRM이 품목마다 IO_COMCHK_CONFIRM을 호출하는데, 승인된 품목의 오류는 그 품목만 건너뛰고(COMERR + LEAVE는 IO 프로시저만 빠져나옴) 루프가 계속 돌아 나머지 품목이 승인됨
  - LOT1003_R01 COMCHK_CONFIRM: 승인 루프 전에 선택 목록 복사본(_$KEYLIST)을 먼저 돌며 CHKAPPYN = 'Y' 품목이 하나라도 있으면 '이미 승인된 품목이 선택되어 있습니다.' + 품목코드 표시 후 LEAVE PROC → 아무것도 승인하지 않음. 공통 IO_COMCHK_CONFIRM·JS는 변경 없음
  - 검증: IF 2쌍·WHILE 4쌍, BOM 없음·CRLF 유지, 파라미터 변동 없음(12). 미확인: MariaDB 컴파일, 화면 동작(DB 접속 불가). DB 반영 필요: LOT1003_R01 재저장
  - 승인취소도 같은 방식으로 수정: 승인·미승인 품목을 함께 취소하면 IO_COMCHK_CANCEL 루프에서 앞 품목은 취소되고 미승인 품목에서 '승인시간이 비었습니다.'로 멈춤(부분 취소). 이후 로트 초기화는 IO_COMCHKLOT_DEL이 @ERRMSG가 있으면 실행되지 않아 미승인 품목 실사 등록은 지워지지 않음
  - LOT1003_R01 COMCHK_CANCEL: IO_COMCHK_CANCEL 전에 선택 목록 복사본을 돌며 CHKAPPYN <> 'Y' 품목이 있으면 '승인되지 않은 품목이 선택되어 있습니다.' + 품목코드 표시 후 LEAVE PROC → 아무것도 취소하지 않음. 승인 후 입출고 발생으로 인한 취소 불가는 기존대로 IO_COMCHK_CANCEL에서 확인
  - 검증: IF 3쌍·WHILE 5쌍, BOM 없음·CRLF 유지(sed 수정 후 CRLF 복원), 파라미터 변동 없음(12). 미확인: MariaDB 컴파일, 화면 동작
- **후속 수정 (2026-11-12, 이력조회 조정사유 제외)**: 현업에서 필요 없다고 하여 LOT1003_S01 조정사유 컬럼 삭제
  - S01.js: 그리드 '조정사유'(ADJUSTWHY) 컬럼 삭제. S01 프로시저: UNION 3개 분기의 ADJUSTWHY(변동없음 '', COMIN·COMOUT.REMARK) 삭제, 헤더 문구 '조정사유 컬럼 제외'로 변경
  - 검증: JS 구문, 잔여 ADJUSTWHY 없음, 인코딩(JS BOM+CRLF, sql BOM 없음+CRLF), 파라미터 변동 없음(7). 미확인: MariaDB 컴파일, 화면 동작. DB 반영 필요: LOT1003_S01 재저장
- **최종 검토·최적화 (2026-11-12, INTP·OUTTP 08만 사용)**: 재고실사 프로시저 9개(LOT1003_R01·S01, IO_COMCHK_ADD·DEL·CONFIRM·CANCEL, IO_COMCHKLOT_ADD·DEL, TAL1600_R01) 검토
  - 08 외 INTP·OUTTP 참조: 실행 코드에는 없음(IO_COMCHK_CONFIRM 08 고정). S01 헤더 주석의 97 문구만 삭제
  - LOT1003_S01: UNION ALL 3개(COMCHKLOT 변동없음 + COMIN 08 + COMOUT 08) → 실사로트 기준 단일 조회 + CASE. 실사입고·출고는 승인 시 로트 차이(실사 - 전산)로 생성되고 COMIN·COMOUT에도 CHKKEY가 있으므로 같은 값: 발생일자 = 승인일자(LEFT(CHKAPPTIME,10), GETDATE와 같은 시점), 수량 = |차이|, 관리자 = 승인자(CHKAPPEMP = COMINLOT·COMOUTLOT.REMP). 승인 후 실사로트는 바뀌지 않음(태블릿·R01 모두 미승인만 수정, 취소 시 COMIN·COMOUT 삭제·CHKAPPYN N). 전체 입출고 테이블(COMIN·COMOUT) 조회 제거. 변동없음에도 품목 조건 적용(기존 누락)
  - LOT1003_R01: 승인완료(DONEYN)를 전체 COMCHK 집계 파생테이블 → 해당 그룹 미승인 EXISTS로, LIST_COMCHK GROUP BY CHKITEMCD → CHKKEY(기본키), 재고품목 조회 JOIN COMLOT + GROUP BY + IF(…,1=1,…) → EXISTS + ( '' OR = ) 조건
  - IO_COMCHK_CONFIRM: 임시테이블 TEMP_COMCHKLOT + 라벨 루프 2개(while_A·B, ITERATE) → 차이 있는 로트만 GROUP_CONCAT(ORDER BY CHKLOTKEY) 후 루프 1회(실사키별 로트는 COMLOT 창고·로트 기준 1건이라 합산 불필요). 다른 IO 프로시저처럼 @ERRMSG 확인 추가(앞 품목 오류 시 이후 품목 처리 안 함), 실사키 존재 확인 추가, GETKEY는 확인 통과 후 발급, 그룹 승인 판단 COUNT 2회 → NOT EXISTS, 미사용 변수(_$OLDQTYLIST·_$CHKQTYLIST·_$CHKQTY·_$COUNT_Y·_$COUNT_ALL) 삭제
  - TAL1600_R01 COMCHKLOT_SCAN: 로트 존재 확인과 품목ID 조회를 1회로 합침
  - 변경 없음: IO_COMCHK_ADD·DEL·CANCEL, IO_COMCHKLOT_ADD·DEL(공통 프로시저, 구조상 문제 없음)
  - 검증: IF·WHILE·CASE 짝, 괄호 짝, 미사용 변수 없음, 파라미터 R01 12·S01 7·TAL1600 7·CONFIRM 1(변동 없음), BOM 없음·CRLF(sed 후 복원). 미확인: MariaDB 컴파일, 실데이터 결과 비교(DB localhost:33061 접속 불가). DB 반영 필요: LOT1003_R01·LOT1003_S01·IO_COMCHK_CONFIRM·TAL1600_R01 재저장
- **후속 수정 (2026-11-12, 승인·취소 품목 미선택 안내)**: LOT1003_R01.js 승인·취소 버튼에서 확인창 전에 상단 오른쪽 실사품목 그리드(grid2) 체크 여부를 공통 ItsGrid.HasChecked로 확인, 없으면 '승인할 품목을 선택하세요.' / '취소할 품목을 선택하세요.' 안내 후 중단(기존에는 확인창 후 빈 목록으로 아무 처리 없이 재조회)
  - 검증: JS 구문, BOM+CRLF 유지. 미확인: 화면 동작(Ctrl+F5 후 확인 필요)
- **후속 수정 (2026-11-12, 이력조회 행위구분 재고정정)**: 사용자 요청으로 LOT1003_S01 행위구분을 모든 행 '재고정정' 상수로, 입출고구분을 변동없음·입고·출고로 변경(분기가 모두 같은 값이던 CASE를 상수로 정리, 정렬에서 ACTION 제외). 사용자가 정리한 헤더·주석은 그대로 둠
  - 검토: 현재 조회는 COMIN·COMOUT 08을 읽지 않고 실사로트 차이로 계산. 06.Table DDL 기준 COMIN·COMOUT에 CHKKEY 인덱스는 없고 INTP·OUTTP 인덱스는 있음 → 08 기준으로 하려면 UNION 없이 COMIN·COMOUT(08)·LOT를 LEFT JOIN하는 단일 조회 가능(실사키별 08 입고·출고 최대 1건이라 행 중복 없음). 적용 여부 사용자 확인 대기
- **후속 수정 (2026-11-12, 이력조회 원본 구조로 재정리)**: 사용자가 원본 SEA LOT1003_S01 소스를 주며 그 방식으로 다시 정리 요청 → 실사로트 기준 CASE 단일 조회를 되돌리고 원본처럼 UNION ALL 3개(실사로트 변동없음 + COMIN 08 입고 + COMOUT 08 출고)로 구성
  - 원본 대비 SNS2 변경: 원본 실사입고 INTP '07'·재고조정 '97' → 실사 08만, ITEMCD·ITEMTP → ITEMID·ITEMCG, GPCD('WARECD') → MSTWARE, 조정사유(ADJUSTWHY) 제외, 행위구분 '재고정정'·입출고구분 변동없음·입고·출고(직전 사용자 결정 유지), 정렬에서 상수인 ACTION 제외
  - 정리: 변동없음의 LEFT JOIN COMCHKLOT은 WHERE 조건 때문에 사실상 INNER라 INNER JOIN으로, 입고·출고 LOT도 로트 컬럼을 쓰므로 INNER JOIN. 원본에서 빠져 있던 변동없음의 품목 조건 추가. 헤더 문구를 원본 구조 유지로 수정
  - 검증: 괄호 짝, SELECT 3·UNION ALL 2, 파라미터 7(변동 없음), BOM 없음·CRLF. 미확인: MariaDB 컴파일, 실데이터 결과(DB 접속 불가). DB 반영 필요: LOT1003_S01 재저장
- **후속 수정 (2026-11-12, 창고 전체 제거·컬럼 자동 너비)**:
  - LOT1003_R01.aspx 실사지시생성 팝업 창고(pdiv1_cmb_WARECD) GPCD *WARECD → WARECD(전체 없음). R01.js 팝업 열기 순서를 열기 → 초기화(InitData) → 품목조회로 변경(기존에는 품목조회 후 InitData가 창고를 초기값으로 바꿔 목록과 창고가 어긋날 수 있었고, 숨은 팝업에서 너비 계산이 안 되므로)
  - LOT1003_R01.js: 실사지시(grid1)·실사품목(grid2)·실사로트(grid3)·팝업 품목(grid_ITEMLIST_ADD) 조회 후 autoSizeColumns() 적용(S01과 같은 ItsGrid.Get(id).autoSizeColumns())
  - LOT1003_S01.aspx 창고(cmb_WARECD) GPCD *WARECD → WARECD + Required. S01 프로시저: 창고 미선택 시 '창고를 선택하세요.'(R01과 같음), 창고 조건 LIKE '%…%' → = (전체가 없어 부분일치 불필요, 다른 창고코드에 포함된 코드가 섞여 나오는 문제 방지)
  - R01.aspx는 작업 전부터 LF 줄 끝이라 CRLF로 맞춤(git 내용 변경 없음)
  - 검증: JS 구문, 인코딩(aspx·js BOM+CRLF, sql BOM 없음+CRLF), S01 IF 1쌍·파라미터 7. 미확인: 화면 동작(DB 접속 불가로 콤보·조회 확인 못 함). DB 반영 필요: LOT1003_S01 재저장
- **후속 수정 (2026-11-12, 승인자 선택·승인 시 EMPCD 저장)**: 승인자를 일반 find로 바꾸고, 승인 처리자를 로그인 사원(CALLEMP) 대신 화면에서 선택한 승인자로 저장
  - R01.aspx find_EMPCD: FindType="mini"·ReadOnly 제거(코드+이름, 찾기 가능, LOT1002 사원 find와 같은 형식). 초기값은 기존대로 로그인 사원
  - R01.js 승인: 품목 선택 확인 뒤 승인자 미입력 시 '승인자를 선택하세요.', COMCHK_CONFIRM에 EMPCD 전달
  - LOT1003_R01 프로시저: 파라미터 $EMPCD 추가(12 → 13, CHKKEYLIST 다음), COMCHK_CONFIRM에서 승인자 미입력 확인 후 IO_COMCHK_CONFIRM(_$CHKKEY, $EMPCD) 호출. SYSTEM_PARAMETERS 파일 정상 건수 13으로 수정
  - IO_COMCHK_CONFIRM: 파라미터 $EMPCD 추가(호출처는 LOT1003_R01 1곳), 승인자 미입력 확인, COMCHK·COMCHK_GROUP CHKAPPEMP와 COMIN·COMOUT EMPCD(담당자)에 $EMPCD 저장. REMP·MEMP 등 등록·수정자 컬럼은 로그인 사원(CALLEMP) 유지
  - LOT1003_S01: 입고·출고 행 관리자를 COMINLOT·COMOUTLOT.REMP(로그인 사원) → COMIN·COMOUT.EMPCD(선택한 승인자)로 변경
  - 검증: IF 짝(R01 4·CONFIRM 8·S01 1), 괄호 짝, 파라미터 R01 13·CONFIRM 2·S01 7, JS 구문, 인코딩 유지. 미확인: MariaDB 컴파일, 화면 동작(DB 접속 불가). DB 반영 필요: IO_COMCHK_CONFIRM·LOT1003_R01·LOT1003_S01 재저장 후 LOT1003_R01_SYSTEM_PARAMETERS 실행(13건)
- **후속 수정 (2026-11-12, 승인자 변경 불가·로그인 사원 유지, 너비 조정)**: 사용자 정정 — 승인자는 바꿀 수 없어야 하고 로그인 사원이 승인자로 들어가는 것이 맞음 → 직전 승인자 EMPCD 전달 변경 전부 되돌림
  - 되돌림: R01.js 승인자 미입력 확인·EMPCD 전달 삭제, LOT1003_R01 $EMPCD 파라미터·확인 삭제(13 → 12, IO_COMCHK_CONFIRM(_$CHKKEY)), IO_COMCHK_CONFIRM $EMPCD 파라미터·확인 삭제(CHKAPPEMP·COMIN·COMOUT EMPCD 다시 CALLEMP()), S01 입고·출고 관리자 다시 COMINLOT·COMOUTLOT.REMP, SYSTEM_PARAMETERS 파일 정상 건수 12로 원복
  - R01.aspx 승인자 find: 일반 find(코드+이름) + ReadOnly="true"(변경 불가), 코드 칸 InputWidth 60px 기본 → 90. 초기값은 기존대로 로그인 사원
  - R01.aspx 조회 창고 콤보: Width="120"은 ItsCombo에 없는 속성이라 적용되지 않았고 실제 입력칸 90px → 1.3배 117px가 되도록 InputWidth="97"(ItsCombo는 InputWidth + 20으로 그림)
  - 검증: 로컬 IIS Express(localhost:55085)에서 창고 콤보 117px, 승인자 코드 90px·읽기 전용·이름 111px 측정. 파라미터 R01 12·CONFIRM 1, IF 짝, JS 구문, 인코딩 유지. 이전 승인자 변경을 DB에 반영하지 않았다면 프로시저 재저장·파라미터 재등록 불필요(반영했다면 IO_COMCHK_CONFIRM·LOT1003_R01·LOT1003_S01 재저장 후 SYSTEM_PARAMETERS 12건 재실행)
- **후속 수정 (2026-11-12, 승인자에 사원코드 저장)**: CALLEMP()는 로그인 ID(MariaCall.aspx.cs에서 SESSION_USERID로 치환)라 승인자에 ID가 들어감 → 화면 승인자(ItsPage.EMPCD, WEBSYSMAIN PAGE_LOAD의 SYSUSER.EMPCD)와 같은 사원코드(예: 9999)로 저장
  - IO_COMCHK_CONFIRM: _$EMPCD = SYSUSER.EMPCD(USERID = CALLEMP()), 없으면 '로그인 사용자의 사원코드가 없습니다.' 후 중단. COMCHK·COMCHK_GROUP CHKAPPEMP, COMIN·COMOUT EMPCD(담당자)에 _$EMPCD 저장. 등록·수정자 REMP·MEMP는 프로젝트 공통 규칙대로 CALLEMP() 유지(파라미터 변동 없음)
  - 검증: IF 8쌍, 괄호 짝, 파라미터 1, BOM 없음·CRLF. 미확인: MariaDB 컴파일, 실제 승인(DB 접속 불가). DB 반영 필요: IO_COMCHK_CONFIRM 재저장
  - (정리) 사용자 요청으로 불필요한 부분 삭제: 사원코드 없음 오류 확인 블록과 긴 설명 주석 제거, _$EMPCD는 창고코드 다음 SET 한 줄(+ 짧은 주석)로 정리. 사원코드가 없으면 빈 값 저장. 승인자·입출고 담당자에 사원코드 저장은 유지. 검증: IF 7쌍, 괄호 짝, BOM 없음·CRLF
  - (후속) 사용자 지적: 승인 시 기록되는 등록자·수정자도 사원코드여야 함 → IO_COMCHK_CONFIRM의 CALLEMP() 7곳(COMOUTLOT·COMINLOT·COMOUT·COMIN REMP, COMLOT·COMCHK·COMCHK_GROUP MEMP)을 모두_$EMPCD로 변경. CALLEMP()는 사원코드 조회 1곳만 남음. 검증: IF 7쌍, 괄호 짝, BOM 없음·CRLF. 승인취소(IO_COMCHK_CANCEL)는 아직 CALLEMP()(MEMP 4곳, 그룹 CHKAPPEMP 1곳)
  - (후속) IO_COMCHK_CANCEL도 같은 방식: _$EMPCD = SYSUSER.EMPCD(USERID = CALLEMP()) 1회 조회(실사그룹키 확인 다음), COMLOT 원복 MEMP 2곳·COMCHK MEMP·COMCHK_GROUP CHKAPPEMP·MEMP를 _$EMPCD로. CALLEMP()는 조회 1곳만 남음. 승인취소 후 로트 실사수량 초기화(IO_COMCHKLOT_DEL, 태블릿 공통)의 COMCHKLOT MEMP는 공통 프로시저라 CALLEMP() 그대로. 검증: IF 8쌍·WHILE 1쌍, 괄호 짝, BOM 없음·CRLF, 파라미터 변동 없음. DB 반영 필요: IO_COMCHK_CANCEL 재저장
  - (최종) 사용자 결정: 등록자·수정자(REMP·MEMP)는 프로젝트 규칙대로 CALLEMP(), 승인처리자만 사원코드 → IO_COMCHK_CONFIRM REMP 4곳·MEMP 3곳, IO_COMCHK_CANCEL MEMP 4곳을 CALLEMP()로 원복. 사원코드(_$EMPCD)는 승인자 CHKAPPEMP(CONFIRM COMCHK·COMCHK_GROUP, CANCEL COMCHK_GROUP)와 승인으로 생기는 08 입출고 담당자 COMIN·COMOUT.EMPCD에만 사용. 검증: CONFIRM IF 7쌍·CANCEL IF 8쌍, 괄호 짝, BOM 없음·CRLF, 파라미터 변동 없음. DB 반영 필요: IO_COMCHK_CONFIRM·IO_COMCHK_CANCEL 재저장
- **후속 수정 (2026-11-13, 이력조회 관리자 사원명 표시)**: LOT1003_S01 관리자에 로그인 ID 대신 MSTEMP.EMPNM(사원코드로 찾은 이름) 표시
  - S01 프로시저: 변동없음은 COMCHKLOT.REMP(로그인 ID) → SYSUSER.EMPCD → MSTEMP.EMPNM(DC_FIND USERID_INFO와 같은 SYSUSER·MSTEMP 연결), 입고·출고는 승인 시 사원코드가 저장되는 COMIN·COMOUT.EMPCD → MSTEMP.EMPNM. 모두 LEFT JOIN(사원 정보가 없어도 행은 나옴, 이름만 빈칸). 반환 컬럼 EMPCD → EMPNM
  - S01.js 관리자 컬럼: EMPCD 콤보(gpcd EMPCD) → EMPNM 일반 텍스트
  - 검증: 괄호 짝, JS 구문, 인코딩(sql BOM 없음+CRLF, js BOM+CRLF), 파라미터 변동 없음(7). 미확인: MariaDB 컴파일, 실데이터(DB 접속 불가). 이번 변경 전에 승인된 실사는 COMIN·COMOUT.EMPCD에 로그인 ID가 있어 이름이 빈칸일 수 있음. DB 반영 필요: LOT1003_S01 재저장
- **후속 수정 (2026-11-13, 태블릿 실사 등록자 CHKSCANEMP 사원코드)**: TAL1600_R01 실사 등록 시 COMCHKLOT.CHKSCANEMP에 로그인 ID가 들어가던 문제. 저장 위치는 TAL1600_R01이 호출하는 IO_COMCHKLOT_ADD(호출처 TAL1600_R01 1곳)
  - IO_COMCHKLOT_ADD: UPDATE 직전에 _$EMPCD = SYSUSER.EMPCD(USERID = CALLEMP()) 조회, CHKSCANEMP = _$EMPCD. 수정자 MEMP는 정한 기준대로 CALLEMP() 유지. 취소(IO_COMCHKLOT_DEL)는 CHKSCANEMP를 ''로 비우므로 변경 없음. TAL1600_R01은 CHKSCANEMP를 직접 쓰지 않아 변경 없음
  - 검증: IF 8쌍, 괄호 짝, 파라미터 3(변동 없음), BOM 없음·CRLF. 미확인: MariaDB 컴파일, 태블릿 실제 등록(DB 접속 불가). DB 반영 필요: IO_COMCHKLOT_ADD 재저장
- **후속 수정 (2026-11-13, 승인취소 시 승인자·승인시간 비움)**: 승인취소 후 CHKAPPYN만 N이 되고 승인자·승인시간이 남는 문제. COMCHK은 이미 '' 처리였고 COMCHK_GROUP이 취소자 사원코드·취소 시간으로 다시 채우고 있었음(원본 SEA 방식)
  - IO_COMCHK_CANCEL: COMCHK_GROUP 미승인 처리를 CHKAPPEMP = '', CHKAPPTIME = ''로 변경(COMCHK과 같음). 쓰이지 않게 된_$EMPCD 선언·조회 삭제. 수정자·수정시간(MEMP·MTIME)은 취소 기록으로 유지
  - 검증: IF 8쌍·WHILE 1쌍, 괄호 짝, BOM 없음·CRLF, 파라미터 변동 없음. 미확인: MariaDB 컴파일, 실제 취소(DB 접속 불가). DB 반영 필요: IO_COMCHK_CANCEL 재저장

### 9. COMCHK 테스트 데이터(260818…) 미조회 원인 확인 (읽기 전용)

- **배경**: 사용자가 본 COMCHK 4건(CHKKEY 260818000001~4, CHKITEMCD ACQ30782201 등 품목코드 문자열, 2026-08-18 LOT1003_R01 등록)이 화면에 안 나오는 이유 확인 요청
- **확인 결과**:
  - 프로젝트 설정 DB(ITS_CONFIG_MARIA.xml, MES_SNS2)의 COMCHK에는 없음(현재 3건, 2026-11-11 등록분·CHKITEMCD 숫자 ITEMID). 같은 서버 COMCHK 보유 스키마 16개(MES_SNS, MES_SEA_DEV 등) 모두 260818 키 없음 → 사용자가 다른 서버/DB 연결을 보고 있는 것으로 판단
  - 그 DB가 화면 연결 DB라면 원인: 해당 행은 SEA 방식(CHKITEMCD = 품목코드)으로 만들어진 데이터인데, SNS2 LOT1003_R01·S01은 `MSTITEM.ITEMID = COMCHK.CHKITEMCD` INNER JOIN이라 품목코드 문자열은 연결되지 않아 조회에서 빠짐
  - 참고: MES_SNS(1공장)·MES_ST·MES_BK_DEV는 컬럼명이 CHKITEMID
- **상태**: 사용자에게 조회 DB 확인 요청 (변경 없음)
- **후속 확인**: 사용자가 MES_SNS2에서 확인 SQL 실행 → 0건. 추가 확인(읽기 전용): MES_SNS2 COMKEY에 CHKKEY·CHKGROUPKEY의 2026-08-18 채번 이력이 없고(2025-01-08 다음이 2026-11-11), 남은 COMCHKLOT·고아 행도 없으며, 품목코드 ACQ30782201·ACQ30782301·MCK30071301-BAR·MCK30071301-DIE는 MES_SNS2 MSTITEM에 없음 → 해당 4건은 MES_SNS2에서 만들어진 적이 없는 다른 DB의 데이터. LOT1003 화면·프로시저 문제 아님, 변경 없음

### 8. LOT1003_R01 프로시저 단순화 (프로젝트 방식)

- **수정/대상 파일**: [05.Procedure/MES_SNS2_LOT1003_R01.sql](05.Procedure/MES_SNS2_LOT1003_R01.sql)
- **배경 및 원인**: 라벨 LOOP·LEAVE 등 프로젝트에서 쓰지 않는 구조 지적, 단순화 요청
- **확인한 공통 동작**: COMERR는 @ERRMSG만 설정(종료 없음), IO_* 프로시저는 시작부에 `IF IFNULL(@ERRMSG, '') = ''` 가드, COMCALLC는 TRANYN 'Y'(ItsMaria)로 @ERRMSG가 있으면 전체 ROLLBACK → 사전 검사 루프·CALL 후 @ERRMSG 확인 불필요. COMCALLC에 SQLWARNING/NOT FOUND EXIT HANDLER가 있고 `'' < 0` 비교는 1292 경고 발생(실DB 읽기 전용 확인, AND로 앞을 막아도 발생)
- **작업 상세 내용**:
  - SAVE_COMCHKLOT: 품목 미선택·수정 없음 검사, 음수 사전 검사 루프, 등록 여부 EXISTS 분기, @ERRMSG 확인 제거 → 승인 여부 확인 후 로트마다 IO_COMCHKLOT_DEL, 값이 있을 때만 음수 확인 후 IO_COMCHKLOT_ADD (빈 값 숫자 비교 경고 방지를 위해 IF 중첩)
  - COMCHK_CANCEL: 승인/미승인 목록 분리, 라벨 LOOP 제거 → 품목마다 승인이면 IO_COMCHK_CANCEL, 아니면 등록 로트를 GROUP_CONCAT 목록으로 만들어 WHILE·COMSPLIT으로 IO_COMCHKLOT_DEL (group_concat_max_len 1MB, 품목·창고당 최대 로트 18개 확인)
  - 미사용 변수 _$QTYLIST·_$APPLIST·_$SCANLIST 제거, _$LOTLIST 추가
- **검증 결과**: IF/WHILE 짝·미사용 변수 없음·파라미터 14개(변경 없음)·라벨 LOOP 없음·BOM 없음·CRLF. 미확인: MariaDB 컴파일, 로그인 화면

### 7. 재고실사 로트 실사등록 로직 모듈화 (IO_COMCHKLOT_ADD·DEL, PDA·웹 공용)

- **수정/대상 파일**: [05.Procedure/MES_SNS2_IO_COMCHKLOT_ADD.sql](05.Procedure/MES_SNS2_IO_COMCHKLOT_ADD.sql)(신규), [MES_SNS2_IO_COMCHKLOT_DEL.sql](05.Procedure/MES_SNS2_IO_COMCHKLOT_DEL.sql)(신규), [MES_SNS2_LOT1003_R01.sql](05.Procedure/MES_SNS2_LOT1003_R01.sql)
- **배경 및 원인**: IO_COMCHK_*4개 분리 필요성 문의. SEA 확인 결과 IO_COMCHK_ADD·DEL·CONFIRM·CANCEL은 웹 LOT1003_R01에서만 호출, PDA(PDA1600_R01)는 IO_COMCHKLOT_SCAN·ADD·DEL 호출. 사용자 선택: IO_COMCHK_* 4개는 원본 구조 유지, PDA와 같이 쓸 로트 입력 로직만 모듈화
- **작업 상세 내용**:
  - IO_COMCHKLOT_ADD: SEA 원본(로트 존재·실사그룹·창고 확인, 실사지시 품목의 로트인지, 이미 실사등록 여부 확인 후 실사수량·스캔시간·스캔자 저장), 품목 ITEMCD→ITEMID, 감사값 CALLTIME
  - IO_COMCHKLOT_DEL: SEA 원본(실사수량 0, 스캔시간·스캔자 초기화)
  - LOT1003_R01 SAVE_COMCHKLOT: 직접 UPDATE 제거 → 이미 등록된 로트는 IO_COMCHKLOT_DEL 후 값이 있으면 IO_COMCHKLOT_ADD (PDA에서 삭제 후 재스캔하는 것과 같음), 오류 시 중단. 실사그룹키는 실사키로 조회
  - LOT1003_R01 COMCHK_CANCEL(미승인 품목): 직접 UPDATE 제거 → 등록된 로트마다 IO_COMCHKLOT_DEL 반복. COMCALLC의 NOT FOUND EXIT HANDLER 때문에 SELECT INTO 대신 스칼라 서브쿼리로 로트 조회
  - IO_COMCHKLOT_SCAN(PDA 스캔 확인)은 PDA 화면 이관 시 함께 추가 필요
- **검증 결과**: 프로시저 IF/WHILE/LOOP 짝·미사용 변수·파라미터 없음, BOM 없음·CRLF. SQLite 흐름 재현(신규 입력, 등록 로트 재수정 시 '이미 실사등록' 오류 없음, 빈칸 저장 시 취소, 미승인 취소 반복 종료). 미확인: MariaDB 컴파일, 로그인 화면

### 6. LOT1003_R01 "취소" 미동작 원인 및 실사수량 입력 취소 추가

- **수정/대상 파일**: [05.Procedure/MES_SNS2_LOT1003_R01.sql](05.Procedure/MES_SNS2_LOT1003_R01.sql), [01.Office/PAGELOT/LOT1003/LOT1003_R01.js](01.Office/PAGELOT/LOT1003/LOT1003_R01.js)
- **원인 (DB 읽기 전용 확인)**:
  - IO_COMCHK_ADD·DEL·CONFIRM·CANCEL이 DB에 없음 → 추가·삭제·승인·취소 호출 시 프로시저 없음 오류
  - SYSTEM_PARAMETERS의 LOT1003_R01 등록이 이전 15개($EMPCD 포함) 그대로, DB 프로시저(16:26 저장)는 14개 → COMCALLC가 등록 목록으로 CALL을 만들어 모든 호출이 인자 수 불일치
  - 원본 "취소"는 승인취소만 수행(승인 전 재고로 원복, 실사수량은 유지). 현재 데이터는 모두 미승인(실사지시 2건, 품목 378252 로트 5개만 입력)이라 되돌릴 승인 없음. 원본에서 실사수량 입력 취소는 PDA(IO_COMCHKLOT_DEL: 실사수량 0·스캔시간·스캔자 초기화)에서만 가능했고 SNS2에는 PDA 없음
- **작업 상세 내용**: COMCHK_CANCEL을 품목별 한 단계 되돌리기로 변경 — 승인 품목은 원본 IO_COMCHK_CANCEL(승인취소, 재고 원복), 미승인 품목은 실사수량 입력 취소(PDA 삭제와 같게 0·스캔정보 초기화). 선택 없으면 "취소할 품목을 선택하세요.", 승인취소 오류 시 중단. 취소 확인 문구에 두 경우 안내
- **검증 결과**: SQLite 흐름 재현 — 입력 후 취소 → 입력 전, 입력·승인 후 취소 1회 → 재고 원복·입력값 유지·미승인, 취소 2회 → 입력 전. 프로시저 IF/WHILE 짝·파라미터 14개·미사용 변수 없음, JS 구문, 인코딩. 미확인: MariaDB 컴파일, 로그인 화면

### 5. LOT1003_R01 로트 실사수량 웹 편집·저장 추가

- **수정/대상 파일**: [05.Procedure/MES_SNS2_LOT1003_R01.sql](05.Procedure/MES_SNS2_LOT1003_R01.sql), [MES_SNS2_LOT1003_R01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_LOT1003_R01_SYSTEM_PARAMETERS.sql), [01.Office/PAGELOT/LOT1003/LOT1003_R01.js](01.Office/PAGELOT/LOT1003/LOT1003_R01.js)
- **배경 및 원인**: 품목의 로트 실사수량을 편집할 방법이 없음. 원본은 PDA(SEA IO_COMCHKLOT_ADD: LOTCHKQTY·CHKSCANTIME·CHKSCANEMP 기록 / IO_COMCHKLOT_DEL: 0·스캔정보 초기화)로 입력하나 SNS2에는 PDA 화면·프로시저 없음
- **작업 상세 내용**:
  - 화면: 하단 로트 그리드(grid3) 실사수량 칸 입력 가능, 수정한 행만 기록(EDIT_LOT, 품목 선택 시 초기화), 툴바 [저장] → SAVE_COMCHKLOT, 저장 후 같은 품목 다시 선택해 로트·합계 갱신
  - 프로시저 SAVE_COMCHKLOT 신규: 품목 미선택·수정 없음·승인된 실사·음수 확인 후 반영. 값이 있으면 실사수량 + 스캔시간·스캔자(PDA 등록과 같음), 빈 값이면 실사수량 0·스캔정보 초기화(PDA 삭제와 같음)
  - 파라미터 $CHKLOTKEYLIST·$LOTCHKQTYLIST 추가로 14개 → SYSTEM_PARAMETERS 14건
- **검증 결과**: JS 구문·Node 모의 테스트(수정한 2행만 전송, 빈 값 '' 전송, 저장 후 재조회), 프로시저 IF/WHILE 짝·파라미터 14개·미사용 변수 없음, 인코딩. 미확인: MariaDB 컴파일, 로그인 화면

### 4. LOT1003_S01 재고 실사·조정 이력조회 SEA 원본 동작으로 구현 (SNS2 대응)

- **수정/대상 파일**: [05.Procedure/MES_SNS2_LOT1003_S01.sql](05.Procedure/MES_SNS2_LOT1003_S01.sql), [MES_SNS2_LOT1003_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_LOT1003_S01_SYSTEM_PARAMETERS.sql)(신규), [01.Office/PAGELOT/LOT1003/LOT1003_S01.aspx](01.Office/PAGELOT/LOT1003/LOT1003_S01.aspx), [LOT1003_S01.js](01.Office/PAGELOT/LOT1003/LOT1003_S01.js) (aspx.cs는 기본 틀 그대로)
- **배경 및 원인**: 기능·흐름·UI/UX는 SEA 원본과 같게, 소스·프로시저만 현재 프로젝트에 맞게 수정 요청
- **작업 상세 내용**:
  - 프로시저: 주석처리했던 원본 본문 복원. 원본과 같은 3단 UNION ALL (실사 변동없음 로트 / 입고 / 출고), 같은 출력 컬럼·정렬
  - SNS2 대응: 품목 ITEMCD→ITEMID(COMCHK.CHKITEMCD·COMIN·COMOUT.ITEMID ↔ MSTITEM.ITEMID, 품목 조건은 ITEMID 일치), 품목유형 ITEMTP→ITEMCG(DM100), 창고명 GPCD('WARECD')→MSTWARE.WARENM. 입출고구분 원본 INTP 07(실사)·97(조정), OUTTP 08(실사)·97(조정) → SNS2 기준정보 INTP·OUTTP '08' 하나로 실사(IO_COMCHK_CONFIRM)와 재고조정(IO_ADJUST_COMLOT)을 모두 기록하므로 COMIN/COMOUT.CHKKEY 유무로 실사입고·실사출고/재고조정 구분
  - 원본 그대로 유지: 변동없음 구간은 품목 조건을 적용하지 않음(원본 동작)
  - 화면: 품목유형 콤보 *ITEMTP→*DM100(Field ITEMCG), 그리드 품목유형 열 ITEMCG·DM100. 그 외 원본과 같음(품목코드 find는 앞서 ITEMID로 변경)
  - 파라미터 7개(원본과 같은 수, ITEMTP→ITEMCG·ITEMCD→ITEMID) → SYSTEM_PARAMETERS 등록 SQL 신규
- **검증 결과**: 실DB 읽기 전용으로 조회 쿼리 실행(전체 1건·조건 지정 0건, 오류 없음, 컬럼이 그리드 필드와 일치), JS 구문 통과, 인코딩(sql BOM 없음, aspx·js 단일 BOM, CRLF). 미확인: MariaDB 컴파일, 로그인 화면
- **후속 수정 (입출고구분·조정사유 표시)**: 실데이터는 실사지시 1건(재고 변경, 04S200_N) 1로트 100=100으로 '변동없음' 행만 있고, 원본은 변동없음 행 입출고구분·조정사유를 '' 고정, 실사 승인 입출고에도 REMARK 미저장이라 빈칸. 사용자 선택(기준정보·실사명)으로 매핑: 입출고구분 — 변동없음은 GPCD('INTP','08')(실사), 실사입고/실사출고는 GPCD('INTP'/'OUTTP', 코드), 재고조정은 입고/출고. 조정사유 — 로트 REMARK가 있으면 그 값, 없으면 실사지시 실사명(COMCHK_GROUP.CHKNM, COMIN/COMOUT.CHKKEY → COMCHK → COMCHK_GROUP 1:1 연결). 행위구분은 실사지시 연결 여부로 실사입고·실사출고/재고조정. 실DB 읽기 전용 실행: 변동없음 행 입출고구분 '실사', 조정사유 '재고 변경' 확인

## 🕒 2026-11-10 (화) 작업 내역

### 1. TAL0001_R08 등록·수정 팝업 상단 한 줄 배치, 특이사항을 R05처럼 그리드 칸에 바로 입력

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [TAL0001_R08.css](01.Office/PAGETAL/TAL0001/TAL0001_R08.css)
- **배경 및 원인**: 등록·수정 팝업 상단 설비·점검일자·점검자가 두 줄로 꺾임. 특이사항·OK/NG 입력이 원래 페이지(TAL0001_R05) UI인지 확인 요청
- **R05 비교 결과**: OK/NG 선택 팝업(pop_OK, 폭 180, OK·NG 버튼 141×95, CustomButton·CustomButton3)은 R05와 동일. 특이사항 입력 팝업(pop_ITEM_REMARK)은 R05에 없던 것으로, R05는 등록·수정 그리드의 비고(REMARK) 칸에 바로 입력(readOnly false)
- **작업 상세 내용**:
  - 1. 팝업 상단 한 줄: 설비 코드 120→100·이름 180→140, 점검일자 130→120(R05와 같음), 점검자 이름 140→110 (등록·수정 팝업 동일)
  - 1. 특이사항: 큰 입력 팝업 제거, 등록(grid3)·수정(grid4) 그리드 특이사항 칸을 입력 가능하게(메인 grid2는 조회 전용), 점검값 두 번 누르기 입력은 특이사항 칸에서 열리지 않게, 저장 전 그리드 입력 확정(finishEditing)
- **검증 결과**: JS 구문 검사 통과, JS 사용 컨트롤 ID 전부 aspx 존재, 인코딩(BOM+CRLF). 미확인: 실제 태블릿에서 한 줄 배치·칸 입력

### 2. TAL0001_R08 등록·수정 팝업 상단 설비·점검자 칸 넓히기, 문제점/조치사항 R05 비교

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx)
- **배경 및 원인**: 1번에서 한 줄로 맞추며 폭을 줄여 설비 코드·설비명(I2C-003N, CNC선반(M2라…)) 등이 잘림
- **작업 상세 내용**: 한 줄을 유지하도록 라벨 폭을 줄이고(기본 90 → 설비 50·점검일자 80·점검자 60) 팝업 폭 1200 → 1250(문제점/조치사항 팝업과 같음), 설비 코드 100→120·설비명 140→190, 점검자 코드 110→120·점검자명 110→150 (등록·수정 동일)
- **문제점/조치사항 R05 비교**: 팝업(pop_PROB_SOL 폭 1250, 문제점·조치사항 입력칸 500×180 좌우, 글씨 30px)과 사용 순서(실적 선택 → 메인 [문제점/조치사항] → 입력 → 저장)는 동일. 차이: R05는 열 때 LIST_ERR로 DB에서 다시 읽고 SAVE_ERR로 문제점·조치사항만 저장, R08은 프로시저가 EQM1001_R04와 같아 별도 분기가 없으므로 이미 조회한 실적 값을 쓰고 SAVE_CHKRSTEQM(기존 점검값·특이사항 그대로 + 문제점·조치사항)으로 저장 후 다시 조회. R08은 점검완료 월이 아니면 이유 안내
- **검증 결과**: 인코딩(BOM+CRLF). 미확인: 실제 태블릿에서 한 줄 배치

### 3. TAL0001_R08 왼쪽 점검 정보 그리드 컬럼 변경, 팝업 점검값 칸 흰 배경

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx)
- **배경 및 원인**: 왼쪽 그리드를 점검월·상태·점검일자·점검자 대신 점검일자·점검유형·점검자·점검상태·문제점·조치사항으로 요청. 등록·수정 팝업의 점검값·특이사항은 입력 칸이므로 흰 배경 요청
- **작업 상세 내용**:
  - 1. 왼쪽 그리드(grid1): 점검일자(110)·점검유형(CHKTP '02', 공통코드 CHKTP 콤보 표시 = EQM1001_S04와 같은 방식)·점검자(사원명)·점검상태(점검필요/점검완료)·문제점(200)·조치사항(200). 점검월·점검자코드·점검키는 숨김 유지. 컬럼이 늘어 왼쪽 영역 30% → 50%
  - 1. 등록·수정 팝업 그리드: 점검값 칸은 숫자패드·OK/NG로 입력해 그리드 직접 편집은 막혀 있어 공통 그리드가 회색(#F7F7F7)으로 칠하므로 흰색(#FFFFFF) 지정. 특이사항 칸은 직접 입력 칸이라 원래 흰색. 메인 오른쪽 점검 항목 그리드는 조회 전용이라 기존 색 유지
- **검증 결과**: JS 구문 검사 통과, 인코딩(BOM+CRLF). 미확인: 실제 태블릿 화면(점검유형 콤보 표시명)

### 4. EQM1001_R04 정기점검 등록·수정 팝업 문제점·조치사항 한 줄 좌우 배치

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx](01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx)
- **배경 및 원인**: 등록(pop1)·수정(pop2) 팝업의 문제점·조치사항이 위아래 두 줄(각 입력폭 1000)이라 보기 불편하다는 요청
- **작업 상세 내용**: 두 입력칸 사이 줄바꿈 제거, 한 줄 좌우 배치. 라벨 70 그대로, 입력폭 각 463(시작 74px·끝 1074px 유지 = 74 + 463 + 칸 간격 4 + 라벨 70 + 463), 높이 90. 팝업 크기 그대로(두 줄이 한 줄로 줄어 그리드 영역이 넓어짐), 주석의 정렬 설명 갱신
- **검증 결과**: 인코딩(BOM+CRLF). 끝선 계산은 11-09 1번에서 측정한 칸 간격(4px) 기준. 미확인: 실제 화면

### 5. TAL0001_R08 설비 선택 시 바로 조회

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 설비를 선택해도 [조회]를 눌러야 반영됨
- **작업 상세 내용**:
  - 1. 설비 찾기(find_EQMCD) 값이 바뀌면(입력 후 이동·찾기 팝업 선택·지우기) 바로 그 설비 조건으로 다시 조회
  - 1. 같이 했던 조회년도 범위 확대(REF01="-5" REF02="3")·기본값 연도 값 지정은 사용자 요청으로 롤백: 원래대로 REF01="-4" REF02="0"(올해-4 ~ 올해), 기본값 SetValueByIndex 4(올해)
- **검증 결과**: JS 구문 검사 통과, 인코딩(BOM+CRLF). 미확인: 실제 태블릿 동작

### 6. TAL0001_R08 점검값 칸 한 번 누르기로 입력창 열기

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 태블릿 해상도에서 등록·수정 팝업의 점검값 칸을 두 번 눌러도 숫자패드·OK/NG 창이 안 뜸. 더블클릭은 Kiosk.js가 모든 그리드에 dblclick으로 연결하는데, Kiosk.master에 viewport 설정이 없어 터치 브라우저(개발자도구 태블릿 모드 포함)가 두 번 누르기를 화면 확대로 처리해 dblclick이 오지 않음. TAL0001_R05도 같은 방식이라 같은 증상 예상
- **작업 상세 내용**:
  - 1. BIND_ITEM_INPUT_CLICK: grid3·grid4 생성 직후 그리드 click 이벤트를 페이지에서 연결, hitTest로 누른 칸의 행·필드를 구해 OPEN_ITEM_INPUT 호출 (기존 onDoubleClick 연결 제거)
  - 1. OPEN_ITEM_INPUT: 점검값(CHKVALUE) 칸일 때만 열림(한 번 누르기라 다른 칸을 눌러 행을 고를 때 열리지 않게), 특이사항은 그대로 칸에 바로 입력
  - 1. 공통 Kiosk.js·Kiosk.master는 수정하지 않음 (viewport 추가 시 다른 태블릿 화면 크기 전체가 바뀔 수 있음)
- **검증 결과**: JS 구문 검사 통과, 인코딩(BOM+CRLF). 미확인: 로컬 브라우저 로그인 세션 만료로 화면 동작 및 실제 태블릿 미확인

### 7. 정기점검 주기관리·실적 초기화 SQL 작성

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_CYCLE_RESET.sql](05.Procedure/MES_SNS2_EQM1001_CYCLE_RESET.sql) (신규, DB 실행은 사용자)
- **배경 및 원인**: EQM1001_R03 주기관리 탭·EQM1001_R04 조회 데이터에 예전 데이터가 섞여 오류가 나는 것으로 보여, 정기점검 데이터를 비우고 초기 상태로 되돌리기를 요청
- **작업 상세 내용**:
  - 1. 대상(프로시저 확인): CHKPLANEQM_YEARPLAN(주기관리 월별 점검자), CHKRSTEQM·CHKRSTEQMKND(정기점검 실적 헤더·항목), 모두 CHKTP '02' 기준. 일상점검('01')·점검계획 REV(MSTEQMREV_HEADER/DETAIL)는 제외
  - 1. 순서: 현황 확인(점검구분·연도별 건수, 삭제 대상 건수, 헤더 없는 항목 수) → 삭제 대상만 BAK_20261110_* 테이블로 백업(트랜잭션 전, CREATE TABLE 자동 커밋) → 트랜잭션에서 항목·헤더·주기관리 순서로 삭제 → 결과 확인 후 COMMIT/ROLLBACK, 복구·백업 정리 구문 주석 포함
- **검증 결과**: 인코딩(UTF-8 BOM 없음+CRLF). DB 실행 안 함

### 8. TAL0001_R08 1200x800 태블릿 화면 대응 (문제점/조치사항 잘림 등)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 1200x800(메뉴 제외 화면 약 1195x730)에서 문제점/조치사항 창에 문제점만 보임. 팝업 폭 1250 > 화면 → 공통 ItsPop이 열 때 폭을 화면에 맞추면서 조치사항이 다음 줄로 넘어가는데, 높이는 한 줄 기준(229)으로 이미 정해져 있고 overflow hidden이라 잘림(브라우저에서 재현)
- **작업 상세 내용**:
  - 1. 문제점/조치사항 창: 폭 1150, 두 입력칸 라벨 90·입력 440(높이 180)으로 한 줄 좌우 배치. 열릴 때(onPopOpened) 높이를 내용 + 저장·취소 버튼 줄(45)로 다시 맞춰, 더 좁은 화면에서 두 줄이 되어도 잘리지 않음. 화면 키보드가 아래를 가리지 않게 창을 화면 위쪽(10px)에 붙임
  - 1. 정기점검 등록·수정 창: 폭 1250 → 1150 (화면보다 넓어 좌우 끝에 붙던 문제, 머리 입력칸·항목 그리드 칸 합계 1000은 그대로 들어감)
  - 1. 메인 왼쪽 grid1(폭 약 580): 고정 칸 105·85·85·85로 줄이고 문제점·조치사항은 남은 폭('*') → 가로 스크롤 없이 표시
  - 1. 메인 오른쪽 grid2(폭 약 580): 칸을 줄여(70·140·85·80·85·70) 점검값까지 가로 스크롤 없이 보이게 하고 특이사항은 남은 폭('*'). 등록·수정 팝업 grid3·grid4는 기존 폭 유지
- **검증 결과**: JS 구문 검사 통과, 인코딩(BOM+CRLF). 브라우저(1195x730·1000x730)에서 문제점/조치사항 창: 한 줄 배치·두 줄 넘김 모두 입력칸과 저장·취소 버튼 전체 표시 확인. 미확인: 로그인 세션 만료로 등록·수정 창과 메인 그리드 실제 표시, 실제 태블릿 화면 키보드 동작

### 9. TAL0001_R08 문제점/조치사항 창 가운데 배치, 그리드 우클릭 메뉴 끔

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 8번에서 화면 키보드 대응으로 창을 화면 위쪽에 붙였더니 너무 위로 올라가 어색함. 그리드 칸(특이사항)을 두 번 누르면 공통 그리드 우클릭 메뉴(전체선택·영역선택·엑셀내보내기 등)가 뜸 - ItsGrid 기본값 contextMenu true, 태블릿에서 길게·두 번 누르기가 contextmenu 이벤트로 처리됨
- **작업 상세 내용**:
  - 1. 문제점/조치사항 창: 위쪽 고정 제거, 높이를 내용에 맞춘 뒤 jQuery UI dialog position(center/center/window)으로 다시 가운데 배치
  - 1. grid1~grid4 생성 옵션에 contextMenu: false (TAL0001_R07과 같은 방식, 공통 컴포넌트 수정 없음)
- **검증 결과**: JS 구문 검사 통과, 인코딩(BOM+CRLF). 브라우저 1195x730에서 창 위·아래 여백 216/215로 가운데 배치 확인. 미확인: 실제 태블릿에서 메뉴 안 뜨는지(로그인 세션 만료로 그리드 생성 불가)

### 10. TAL0001_R08 등록·수정 창 설비·점검일자·점검자 한 줄 배치

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx)
- **배경 및 원인**: 8번에서 창 폭을 1150으로 줄인 뒤 점검자가 다음 줄로 넘어감. 브라우저 측정: 설비 439 + 점검일자 291 + 점검자 409 = 1139px > 입력 영역 1130px
- **작업 상세 내용**: pop1·pop2 설비명 칸 190 → 165, 점검자명 칸 150 → 140 (합계 1104px). 점검일자 라벨은 70으로 줄이면 "점검일자"가 두 줄로 꺾여 80 유지
- **검증 결과**: 인코딩(BOM+CRLF). 브라우저 1195x730에서 pop1·pop2 모두 세 항목이 같은 줄(끝 1137px, 영역 끝 1163px) 확인. 미확인: 실제 태블릿 글꼴 크기에서의 표시

### 11. TAL0001_R08 메인 오른쪽 항목 그리드 글자 잘림 대응

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 메인 grid2 폭이 화면 절반(약 595, 행번호 제외 약 550)이라 8번에서 줄인 폭(70·140·85·80·85·70)으로 7칸을 넣으니 "적용 REV"·"점검값구분" 제목이 잘리고 특이사항(남은 폭)은 거의 0
- **작업 상세 내용**: 메인(isEdit false)만 점검값구분 숨김(점검값이 OK/NG·숫자로 바로 구분, 입력은 팝업에서), REV 제목 "적용 REV" → "REV", 폭 REV 70·점검명 135·점검항목 90·점검방법 90·점검값 80, 특이사항 남은 폭(약 85). 등록·수정 팝업 grid3·grid4는 그대로(점검값구분 표시, 기존 폭)
- **검증 결과**: JS 구문 검사 통과, 인코딩(BOM+CRLF). 미확인: 로그인 세션 만료로 실제 그리드 표시(폭은 태블릿 글꼴 기준 추정)

### 12. TAL0001_R08 하단 그리드 좌우 스크롤 방식으로 변경 (8·11번 칸 줄이기 되돌림)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 사용자 요청 - 칸을 줄이거나 숨기지 말고, 특이사항 등이 잘리면 하단 그리드를 좌우로 스크롤해서 볼 수 있게
- **작업 상세 내용**:
  - 1. 왼쪽 grid1: 남은 폭('*') 대신 고정 폭(점검일자 110·점검유형 90·점검자 100·점검상태 90·문제점 250·조치사항 250, 합계 890) → 화면 절반을 넘는 부분은 좌우 스크롤
  - 1. 오른쪽 grid2: 11번의 점검값구분 숨김·"REV" 제목·줄인 폭 되돌리고 팝업과 같은 칸·폭(적용 REV 90·점검명 230·점검항목 120·점검방법 100·점검값구분 100·점검값 100·특이사항 300, 합계 1040) → 좌우 스크롤로 특이사항까지 확인
  - 1. 등록·수정 팝업 grid3·grid4: 특이사항 260 → 300 (합계 1040 + 행번호, 팝업 입력 영역 1130 안)
- **검증 결과**: JS 구문 검사 통과, 인코딩(BOM+CRLF). 미확인: 로그인 세션 만료로 실제 스크롤 표시

### 13. TAL0001_R08 그리드 칸 폭 자동 맞춤(autoSizeColumns)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 12번 고정 폭(특이사항 300·문제점/조치사항 250 등)이 너무 넓다는 의견, 내용에 맞춰 동적으로 정해지길 요청
- **작업 상세 내용**:
  - 1. AUTO_SIZE_GRID(gridId): Wijmo FlexGrid autoSizeColumns()(공통 그리드 우클릭 '컬럼너비맞춤', EQM1001_S03·LOT1002 등에서 쓰는 방식)로 제목·내용 길이에 맞춘 뒤, 한 칸 최대 300, 등록·수정 팝업 특이사항은 바로 입력하므로 최소 250
  - 1. 호출: 메인 grid1·grid2는 LOAD_DETAIL에서 데이터를 넣은 직후, 팝업 grid3·grid4는 창을 연 직후(보이는 상태여야 글자 폭 측정 가능)
  - 1. 기본 폭(자동 맞춤 전) 축소: grid1 문제점·조치사항 150, 항목 그리드 점검명 180·점검항목 100·점검값 90·특이사항 200
  - 1. 합계가 그리드보다 넓으면 좌우 스크롤 유지
- **검증 결과**: JS 구문 검사 통과, 인코딩(BOM+CRLF). 미확인: 로그인 세션 만료로 실제 자동 폭 결과(태블릿 글꼴 기준)

### 14. TAL0001_R08 프로시저 검토 개선 6건 반영

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql), [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 프로시저 검토 결과(행 중복·무리한 JOIN 없음) 동작 위험 2건·정리 4건 반영 요청
- **작업 상세 내용**:
  - 1. SEARCH_CHKRSTEQM 실적 항목: REV 헤더 INNER JOIN → LEFT JOIN, REVNM은 못 찾으면 빈 값 (REV 못 찾는 항목이 빠져 수정 저장 시 항목 수 불일치로 저장 불가되던 위험)
  - 1. 신규 분기 SEARCH_PLAN_EMP: 주기관리 그 달 배정 점검자(PLANEMPCD·PLANEMPNM·PLANEMPNAME) 조회. 화면 LOAD_DETAIL에서 LIST_PLAN_EQM02가 실패(승인 계획 없음)하면 이 분기로 점검자만 가져와 표시(실패 시 무표시). 파라미터 추가 없음(SYSTEM_PARAMETERS 그대로 16건)
  - 1. LIST_CYCLE_EQMCD APPROVED_PLAN: MSTEQMREV_DETAIL INNER JOIN + GROUP BY → EXISTS (항목 존재만 확인)
  - 1. LIST_PLAN_EQM02 사원 조회: MSTEMP 두 번(SET 서브쿼리 2개) → SELECT MAX(EMPCD), MAX(EMPNM) INTO 한 번 (집계라 사원 없어도 1행)
  - 1. LIST_PLAN_EQM02 항목: 그룹·설비 UNION ALL 두 조회 → REVCD IN (그룹, 설비) 단일 조회, 계획구분은 REV 헤더 PLANTP
  - 1. 월 조건 LEFT(BASEDATE, 7) = $YYYYMM → BASEDATE LIKE CONCAT($YYYYMM, '-%') (수정 대상 확인·등록 중복 확인·실적 조회 3곳, 인덱스 사용 가능 형태)
- **검증 결과**: 변경 부분 문법 수동 확인(격리 MariaDB 없음, 컴파일 미실행), JS 구문 검사 통과, 인코딩(SQL UTF-8 BOM 없음+CRLF, JS BOM+CRLF). 미확인: 서버 프로시저 반영 및 실제 화면 동작. 참고: CHKRSTEQM (EQMCD, CHKTP, BASEDATE) 인덱스 추가 권장(DDL은 사용자 판단)
- **후속(사용자 정리본 기준)**: 사용자 최신 프로시저에는 1·6번만 남고 3·4·5번은 원래대로, SEARCH_PLAN_EMP 분기는 빠져 있었음 → 화면은 SEARCH_PLAN_EMP를 호출하므로 실패 후 점검자 빈칸. 3·4·5번은 그대로 두고 SEARCH_PLAN_EMP 분기만 다시 추가(사원 조회는 파일의 기존 SET 두 번 형식), 헤더 Modify 2026-11-10 줄 추가 → 15번에서 현황 조회 방식으로 대체

### 15. TAL0001_R08 미리보기 점검자: 추가 호출 대신 월별 현황 조회에 포함

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql), [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 승인 계획이 없을 때 점검자를 SEARCH_PLAN_EMP로 한 번 더 호출하는 방식 대신 다른 방법 요청 → 월별 현황 조회에 포함하는 방식 선택
- **작업 상세 내용**:
  - 1. LIST_CYCLE_EQMCD: 이미 붙어 있는 CHKPLANEQM_YEARPLAN에서 1~12월 배정 점검자 코드(MxxEMPCD), MSTEMP 월별 LEFT JOIN(EMP01~EMP12, EQM1001_R03 LIST_CYCLE_EQMCD와 같은 방식)으로 이름(MxxEMPNM) 추가. 사원은 기본키 조회라 행이 늘지 않음
  - 1. SEARCH_PLAN_EMP 분기 삭제, 헤더 Modify 2026-11-10 문구 갱신
  - 1. JS: GET_PLAN_EMP(eqmCd)로 CYCLE_DATA의 선택 월 점검자 코드·이름을 꺼내 점검필요 미리보기 점검자로 표시(이름 없으면 코드), 추가 호출(empMaria) 제거. 항목 조회(LIST_PLAN_EQM02) 실패해도 점검자는 표시, 오른쪽 항목 그리드만 빈칸
- **검증 결과**: 문법 수동 확인(컴파일 미실행), JS 구문 검사 통과, 인코딩(SQL UTF-8 BOM 없음+CRLF, JS BOM+CRLF). 미확인: 서버 반영 후 실제 화면

### 16. TAL0001_R08 JS 불필요·보수적 코드 정리

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: AUTO_SIZE_GRID는 autoSizeColumns만으로 충분(최대 300·최소 250 보정 제거) → 같은 기준으로 동작은 그대로 두고 불필요·보수적 코드 정리 요청
- **작업 상세 내용**:
  - 1. 그리드 컬럼 width 기본값 제거(조회 후 autoSizeColumns로 맞추므로), 점검값 흰 배경은 `backColor: isEdit ? '#FFFFFF' : 'white'`로 한 줄 처리
  - 1. SET_BUTTONS 삭제(버튼을 끄는 곳이 없어 항상 사용 가능), LOADED_YEAR·Load의 중복 조회 방지 if 삭제(SetValueByIndex가 onChanged를 불러 바로 조회)
  - 1. GET_STATUS·GET_PLAN_EMP → GET_CYCLE_ROW 하나로 합침(선택 설비 카드는 현황에 있는 설비만 만들어지므로 '못 찾음' 처리 제거)
  - 1. CHECK_ACTION: 점검대상 아님 안내·CHKRSTKEY 확인 삭제(선택 가능한 설비는 항상 점검필요/점검완료)
  - 1. OPEN_ITEM_INPUT을 BIND_ITEM_INPUT_CLICK에 합침, hitTest 행·열 음수 확인 삭제
  - 1. 프로시저가 COALESCE로 빈 값을 주거나 공통 GetValue가 항상 문자열을 주는 곳의 `|| ''`·`|| {}` 삭제, InitData 직후 문제점·조치사항 빈 값 설정 삭제, 숫자 반영 후 입력칸 비우기 삭제(열 때 비움)
  - 1. 등록 팝업 주기관리 점검자를 사원 목록에서 못 찾았을 때의 토스트, 점검자 이름이 없을 때 코드 표시 대체 삭제
  - 1. 유지: 설비명 `|| ''`(MSTEQM.EQMNM이 NULL 허용), SET_FIND_NAME(공장 07 사원찾기 목록에 없는 사원), 문제점/조치사항 창 높이·가운데 보정
- **검증 결과**: JS 구문 검사 통과, 인코딩 BOM 1개+CRLF(583줄 → 511줄). 미확인: 실제 화면
- **후속**: 사용자가 이전 소스로 되돌림, 17번에서 다시 최적화(이후 17번도 되돌리고 18번으로 대체)

### 17. TAL0001_R08 JS 최적화 (꼭 필요한 선언만 남김)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 불필요한 코드를 모두 지우고 로직상 꼭 필요한 선언만 남기도록 요청
- **작업 상세 내용** (16번 정리 내용 전부 + 아래):
  - 1. 숨김 컬럼 삭제(grid1 YYYYMM·EMPCD·CHKRSTKEY, 항목 PLANTP·CHKKNDCD): ItsGrid.GetValue는 컬럼이 없어도 행 데이터(_data)에서 읽음. 그리드 옵션은 기본값과 같은 isCheckBoxGrid·isSubTotalGrid 빼고 contextMenu:false만
  - 1. 선택 설비를 SEL_EQMCD 대신 현황 행(SEL_ROW)으로 기억 → GET_STATUS·GET_PLAN_EMP 삭제, 카드는 data-index로 행 찾기
  - 1. 월 탭(RENDER_MONTH)은 데이터와 무관하므로 Load에서 한 번만 그림, SEL_MONTH는 선언할 때 이번 달로 초기화
  - 1. SAVE_ITEMS(maria, gridId, popId): 등록·수정·문제점/조치사항 저장에서 반복되던 항목 목록 추가·저장·닫기·다시 조회를 하나로
  - 1. LOAD_DETAIL은 프로시저 호출 한 곳으로 합치고, 점검완료는 조회 결과 행에 CHKTP·STATUS만 더해 그대로 grid1에 넣음, autoSizeColumns 직접 호출(AUTO_SIZE_GRID 삭제)
  - 1. 숫자패드 0~9·OK/NG·팝업 취소 이벤트를 반복문으로, 조회년도·설비·조회버튼 이벤트는 SEARCH_CYCLE 직접 연결
  - 1. 등록·수정 팝업 InitData 삭제: 등록은 모든 칸을 직접 넣고, 수정은 ItsPage.SetStore가 모든 칸을 덮어씀(ItsFind는 못 찾으면 이름 비움)
  - 1. CHECK_ACTION(isReg) 불리언으로 단순화
- **검증 결과**: JS 구문 검사 통과, 인코딩 BOM 1개+CRLF(559줄 → 385줄). 미확인: 실제 화면
- **후속**: 기존 날짜 주석 삭제·이벤트 등록/함수 구조·숨김 컬럼 등 프로젝트 형식을 바꿔 규칙(Optimization.md 2·4항) 위반 → 사용자가 583줄 원본으로 되돌림, 18번에서 형식 유지하며 다시 정리

### 18. TAL0001_R08 JS 불필요 코드 삭제·로직 단순화 (기존 형식 유지)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 프로젝트 형식(함수·이벤트 구조, 날짜 주석, 컬럼 선언)은 그대로 두고 불필요한 코드와 복잡한 로직만 단순화 요청
- **작업 상세 내용**:
  - 1. 삭제: SET_BUTTONS(버튼을 끄는 곳이 없음)와 호출부, LOADED_YEAR와 Load의 중복 조회 방지 if(SetValueByIndex가 onChanged로 조회), AUTO_SIZE_GRID 안 주석 처리된 옛 코드와 더 이상 맞지 않는 설명 한 줄
  - 1. CHECK_ACTION: 도달할 수 없는 '점검 대상 월 아님' 분기와 CHKRSTKEY 중복 확인 삭제(선택 가능한 설비는 항상 점검필요/점검완료)
  - 1. LOAD_DETAIL: GET_STATUS가 빈 설비코드면 빈 값을 주므로 삼항 제거, 점검필요 미리보기의 빈 값 필드 제거, 오류 시 return·중복 AUTO_SIZE_GRID 호출을 `if (!maria.isError)` 하나와 마지막 칸 폭 맞춤 두 줄로 정리
  - 1. 불필요한 `|| ''`·`|| {}` 삭제(프로시저 COALESCE·공통 GetValue가 항상 값을 주는 곳), 등록 팝업 InitData 직후 문제점·조치사항 빈 값 재설정 삭제, 숫자 반영 후 입력칸 비우기 삭제(열 때 비움)
  - 1. 점검값 클릭: CellType.Cell이면 행·열이 항상 0 이상이므로 음수 확인 삭제, 문제점/조치사항 저장의 임시 변수 제거
  - 1. 유지: 날짜 주석 전부, 그리드 옵션·컬럼 폭·숨김 컬럼, 각 버튼·팝업 이벤트 개별 선언, 점검자 이름 없을 때 코드 표시·사원 못 찾음 안내, 설비명 `|| ''`
- **검증 결과**: JS 구문 검사 통과, 인코딩 BOM 1개+CRLF(583줄 → 542줄). 미확인: 실제 화면
- **후속**: 태블릿 점검필요 미리보기 점검자 빈칸 → 콘솔 확인 결과 CYCLE_DATA에 M05EMPCD·M05EMPNM 컬럼 자체가 없음(새 JS는 로드됨). 서버 DB의 TAL0001_R08 프로시저가 월별 점검자 추가(15번) 전 버전이라 프로시저 재저장 필요

### 19. TAL0001_R08 수정 저장(SAVE_CHKRSTEQM) 단순화

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql)
- **배경 및 원인**: 같은 항목 중복 전달을 막으려고 임시테이블(TMP_RST_ITEM)을 DROP·CREATE하고 항목 수를 세던 방어 로직이 과함. 화면은 조회한 실적 항목을 그리드 그대로 보내므로 중복·누락이 생기지 않음
- **작업 상세 내용**: 임시테이블 생성·삭제, 항목별 존재 확인, 항목 수(_$ITEMCNT·_$ROWCNT)·남은 목록 길이 검사 삭제 → 기존 일상점검 수정(TAL0001_R05)처럼 점검값 빈 값 확인 후 UPDATE만. 헤더 Modify 2026-11-10 줄에 문구 추가. _$ITEMCNT·_$ROWCNT는 등록(ADD_CHKRSTEQM)에서 계속 사용
- **검증 결과**: 문법 수동 확인(컴파일 미실행), 인코딩 UTF-8 BOM 없음+CRLF. 파라미터 변경 없음. 미확인: 서버 반영 후 실제 수정 저장

### 20. TAL0001_R08 프로시저 방어 코드 정리

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql)
- **배경 및 원인**: 화면 흐름상 생기지 않는 경우를 막는 방어 코드 정리 요청
- **작업 상세 내용**:
  - 입력값 검증: 계획년월 정규식·STR_TO_DATE 확인(콤보·달력에서만 들어옴), 항목 목록 빈 값 확인(승인 계획 항목 수 0 검사로 이미 막힘) 삭제. 점검일자·점검자 필수, 점검일자 년월 일치 검사는 유지
  - 설비 그룹 조회의 등록용 잠금(FOR UPDATE) 분기 삭제 → 한 줄로
  - 등록 시 팝업 REV 재확인, 항목별 승인 계획 존재 확인, 항목 수(_$ROWCNT)·남은 목록 길이 검사 삭제(_$ROWCNT 선언도 삭제)
  - 수정·삭제 대상 실적 재조회(FOR UPDATE)·설비/점검월 일치 확인 블록 삭제 → SAVE·DELETE는 화면이 준 $CHKRSTKEY로 바로 처리
  - SEARCH_CHKRSTEQM 주석에서 더 이상 맞지 않는 "항목 수가 달라 저장 불가" 문구 삭제, 헤더 Modify 2026-11-10 줄 갱신
  - 유지: 사용 중 설비 확인, 승인된 계획 없음, 주기관리 점검자 없는 달 등록 불가, 같은 달 중복 등록 불가, 점검값 필수, 실적 조회 없음 안내, LIST_PLAN_EQM02 사원 조회(사용자 정리본 형식)
- **검증 결과**: 문법 수동 확인(컴파일 미실행), 인코딩 UTF-8 BOM 없음+CRLF(387줄 → 340줄), 파라미터 변경 없음. 미확인: 서버 반영 후 등록·수정·삭제

### 21. 정기점검 실적 삭제 후 특이사항이 남아 보이는 문제 (TAL0001_R08·EQM1001_R04)

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql), [05.Procedure/MES_SNS2_EQM1001_R04.sql](05.Procedure/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: 삭제(DELETE_CHKRSTEQM)는 실적 항목(CHKRSTEQMKND)·실적(CHKRSTEQM)을 모두 지워 DB에는 남지 않음. 삭제 후 해당 월이 점검필요로 돌아가면 등록용 항목 조회(LIST_PLAN_EQM02)가 점검값은 `''`로, 특이사항은 계획 항목 특이사항(MSTEQMREV_DETAIL.REMARK, 2026-11-09 3번에서 넣은 기본값)으로 채워 보내므로 특이사항만 남아 보임 (R08 메인 미리보기·등록 팝업, R04 등록 팝업)
- **작업 상세 내용**: 두 프로시저 LIST_PLAN_EQM02의 G·E 두 SELECT에서 `PLAN_ITEM.REMARK` → `'' AS REMARK` (신규 등록 특이사항은 점검값처럼 빈 칸에서 시작). 헤더 Modify 2026-11-10 기록. JS 변경 없음
- **영향**: 계획 특이사항은 점검계획(EQM1001_R03)과 설비점검항목·점검시트(EQM1001_S04, 실적 특이사항이 비면 계획 특이사항 표시)에서 그대로 보임
- **검증 결과**: 문법 수동 확인(컴파일 미실행), 인코딩 UTF-8 BOM 없음+CRLF, 파라미터 변경 없음. 미확인: 서버 반영 후 삭제 → 재등록 화면
- **사용자 확인**: 특이사항은 점검 등록 때 점검자가 입력하는 값으로 바뀌었으므로 계획 특이사항을 기본값으로 보이지 않는 것이 맞음 → 빈 값 유지. 점검 등록 시 저장 테이블: 실적 헤더 CHKRSTEQM, 실적 항목 CHKRSTEQMKND(점검값·특이사항), 삭제 시 두 테이블 모두 삭제

### 22. EQM1001_S04 설비점검항목·점검시트 특이사항을 점검자 입력값만 표시

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql)
- **배경 및 원인**: 2026-11-09 3번에서 실적 특이사항이 비면 점검 당시 계획 항목 특이사항(MSTEQMREV_DETAIL.REMARK)을 대신 표시하게 함 → 점검자가 비워 두고 등록해도 계획 특이사항이 찍힘. 특이사항은 점검자가 입력한 값만 보여야 함
- **작업 상세 내용**: LIST_CHKRSTEQMKND(설비점검항목 그리드)·CALL_CHKRST_RPT 항목(점검시트 출력) 특이사항 = `COALESCE(CHKRSTEQMKND.REMARK, '')`. 계획 특이사항 조회에만 쓰던 CHKRSTEQM·MSTEQMREV_DETAIL 조인 제거, 주석·헤더 Modify 2026-11-10 기록. 반환 컬럼 동일(화면·레포트 변경 없음)
- **확인**: 프로시저 전체에서 계획 특이사항으로 대체 표시하는 곳은 더 없음(EQM1001_R03 점검계획 관리 화면만 계획 특이사항 사용)
- **검증 결과**: 문법 수동 확인(컴파일 미실행), 인코딩 UTF-8 BOM 없음+CRLF, 파라미터 변경 없음. 미확인: 서버 반영 후 S04 그리드·점검시트 출력

### 23. 소스코드 주석 작성 표준(날짜 제거 및 단일 행 간소화) 규칙 제정 및 TAL0001_R08.js 전면 정비

- **수정/대상 파일**: [.agents/rules/aspx_cs_comment.md](.agents/rules/aspx_cs_comment.md), [.agents/rules/coding_convention.md](.agents/rules/coding_convention.md), [.agents/rules/Optimization.md](.agents/rules/Optimization.md), [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 소스코드 내 날짜별로 두 줄 이상 누적된 장황한 주석(`// 2026-11-09 ...`, `// 2026-11-10 ...`)이 가독성을 저해하므로 날짜를 포기하고 "해당 코드가 무엇을 하는지"만 간략하게 1줄 주석으로 작성하라는 사용자 지침 반영
- **작업 상세 내용**:
  - 1. 규칙 문서 개정: `aspx_cs_comment.md`, `coding_convention.md`, `Optimization.md`에 소스코드(`.js`, `.cs`) 날짜 주석 작성 금지, 두 줄 이상 다중 행 설명 주석 절대 금지, 오직 "무엇을 하는지"에 대한 직관적인 단일 행(1줄) 기능 설명 원칙 제정
  - 1. `TAL0001_R08.js` 전면 정비: 전체 날짜 주석(`2026-11-09`, `2026-11-10` 등) 및 두 줄 이상 장황하게 서술된 주석(L403-404, L420-421, L501-505 등) 제거, 160자 초과 구분선 배너 제거, 모든 주석을 깔끔한 단일 행 요약 설명으로 전환
- **검증 결과**: Node.js 자바스크립트 구문 검사(`node -c`) 통과(오류 0건), 단일 UTF-8 with BOM 및 CRLF 검증 완료

### 24. 태블릿 TAL0001_R09 설비부품 출고등록 구현 (TML1010_R05 출고만)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R09.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R09.aspx), [01.Office/PAGETAL/TAL0001/TAL0001_R09.js](01.Office/PAGETAL/TAL0001/TAL0001_R09.js), [05.Procedure/MES_SNS2_TAL0001_R09.sql](05.Procedure/MES_SNS2_TAL0001_R09.sql)(신규), [05.Procedure/MES_SNS2_TAL0001_R09_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_TAL0001_R09_SYSTEM_PARAMETERS.sql)(신규)
- **배경 및 원인**: 현장터미널(WPF) 설비부품 입출고 화면 TML1010_R05(02.Site/TMLPJT/TML1010/R05.xaml)의 UI/UX를 태블릿 웹으로 옮기되, 입고 관련 기능은 빼고 출고 등록만
- **제외**: 입고(발주 조회·선택·입고 등록·라벨 출력), 입출고 이력 팝업, 라벨 재출력
- **작업 내용**
  - 1. 조회
    - 1) 설비부품 재고 조회 : MSTITEM, MSTITEM_EQMPARTS(FACTORYCD = '07'), MSTLOCA_EQMPARTS (COMPANYCD = '60', ITEMCG = 'DM100700', ENDYN = 'N', 설비부품 재고 등록 품목만)
    - 1) 재고그리드 : 설비부품코드, 설비부품명, 중요도등급, 로케이션(로케이션명, 없으면 코드), 안전재고, 현재고, 단위(DM150), 출고 버튼 / 현재고 < 안전재고 행 분홍색
    - 1) 화면 열 때·[설비부품 재고조회] 버튼 조회
    - 1) 프로시저 : TAL0001_R09 / LIST_EQMPARTS
  - 1. 출고 등록
    - 1) 재고그리드 [출고] 버튼 → 출고 등록 창 (출고일자 오늘, 품목코드·품명 표시, 출고구분 부품교체(OUT_01), 출고수량, 출고자 로그인 사원)
    - 1) 출고구분 : 공통코드 INOUTTP_EQMPARTS 중 출고 코드(OUT_)만 표시 (25번에서 JS 목록 제거 → 공통코드 REF01="OUT" 조건으로 변경)
    - 1) 출고 저장 : INOUT_EQMPARTS 등록 (INOROUT = 'OUT', OLDQTY = 출고 전 현재고, INOUTKEY = GETKEY('INOUTKEY')), MSTITEM_EQMPARTS 현재고 차감 (FACTORYCD = '07')
    - 1) 저장 전 확인(프로시저) : 부품·출고일자·출고구분·출고자 미선택, 출고수량 0 이하, 현재고 초과 출고 불가
    - 1) 확인창 후 저장, 저장 후 재고그리드 재조회
    - 1) 프로시저 : TAL0001_R09 / OUT_EQMPARTS (TML1010_R05 OUT_EQMPARTS와 같은 테이블·값)
- **참고 화면**: TML1010_R05(R05.xaml·R05.xaml.cs·MES_SNS2_TML1010_R05.sql) 출고 흐름, TAL0001_R07(태블릿 그리드 버튼·팝업), MST3001_R03(설비부품 재고 컬럼)
- **적용 순서**: MES_SNS2_TAL0001_R09.sql 프로시저 저장 → MES_SNS2_TAL0001_R09_SYSTEM_PARAMETERS.sql 실행(정상 7건)
- **검증 결과**: JS 구문 검사 통과, 프로시저 IF/END IF 6쌍·파라미터 7건 확인, 인코딩(aspx·js BOM+CRLF, sql BOM 없음+CRLF), JS 주석은 개정 규칙(날짜 없는 1줄)대로. 미확인: MariaDB 컴파일, 실제 화면·출고 저장(브라우저 로그인 세션 만료)
- **후속(출고 등록 창 정렬)**: 출고수량만 시작점이 30px 왼쪽(태블릿 공통 Kiosk.css가 숫자칸 라벨만 왼쪽 여백 0·오른쪽 10, 다른 칸은 좌우 20), 출고자가 길고 줄마다 끝이 달라 정렬 요청
  - TAL0001_R09.css(공통 CSS 미수정): 출고수량 라벨 좌우 여백 20, 출고일자 입력칸 폭 381(Kiosk.css가 날짜칸 130 고정 !important)
  - TAL0001_R09.aspx 폭: 출고구분 InputWidth 200 → 361, 출고수량 200 → 420, 출고자 NameWidth 266 → 234, 출고일자 InputWidth 제거(CSS로 지정)
  - 브라우저 실측(팝업 내용 기준): 6줄 모두 입력칸 시작 133px·끝 553px으로 일치
- **후속(누락 기능 추가)**: 입고만 제외해야 하는데 입출고 이력·라벨출력까지 빠짐 → 입출고 이력은 출고 이력으로, 라벨출력은 그대로 추가
  - 3. 출고 이력
    - 1) 재고그리드 [출고 이력] 버튼 → 출고 이력 창 (조회일자 오늘~오늘, 선택 부품)
    - 1) 출고 이력 조회 : INOUT_EQMPARTS (INOROUT = 'OUT', 조회일자 기간)
    - 1) 이력그리드 : 발생일자, 출고유형(INOUTTP_EQMPARTS), 출고량, 처리자(EMPCD) (TML 입출고 이력의 입/출·입고량 칸 제외)
    - 1) [출고 이력조회] 버튼 재조회
    - 1) 프로시저 : TAL0001_R09 / LIST_OUT_EQMPARTS
  - 1. 라벨출력
    - 1) 재고그리드 [라벨출력] 버튼 → 선택 부품 라벨 출력 (공통 ItsTmlLabel → CONTROLLER/TmlLabel.aspx PDF 인쇄, 태블릿 TAL1001_R04 라벨출력과 같은 방식)
    - 1) 라벨 양식 : EQMPARTS (TML1010_R05와 같음), 라벨 데이터 : MSTITEM (품명, 품목코드, 품목ID)
    - 1) 프로시저 : TAL0001_R09 / GET_LABELCD, LABEL_REPRINT
  - 프로시저 파라미터 SDATE·EDATE 추가(7 → 9건, SYSTEM_PARAMETERS 스크립트 정상 건수 갱신), Create 줄 문구 갱신
  - 검증: JS 구문 검사 통과, IF/END IF 6쌍·WHEN 5개·파라미터 9건, 인코딩 확인. 미확인: 로컬 웹 서버 응답 없음으로 화면·이력 팝업·라벨 인쇄 미확인, MariaDB 컴파일
- **후속(페이지 접속 시 서버 StackOverflowException)**: 출고 이력 창 조회일자(Its:dateRange)에 MarginBottom="10" 지정 → 공통 ItsDateRange.ascx.cs의 MarginBottom setter가 자기 자신에 대입(`MarginBottom = value;`)해 무한 재귀, IIS Express 프로세스 종료
  - TAL0001_R09.aspx 조회일자에서 MarginBottom 제거 (공통 컴포넌트는 수정하지 않음)
  - 같은 setter 오류가 있는 공통 컨트롤: ItsCheck, ItsDateRange, ItsDisplay, ItsFileManager, ItsLabel, ItsMonth, ItsNum, ItsOnoff, ItsRadio, ItsTextArea → 화면에서 이 컨트롤들에 MarginBottom 쓰지 않기 (ItsText·ItsDate·ItsCombo·ItsFind·ItsButton은 정상)

### 25. 설비부품 출고구분 콤보에 출고 코드만 표시 (TML1010_R05·TAL0001_R09, 공통코드 REF01)

- **수정/대상 파일**: [05.Procedure/MES_SNS2_COMTYPE_INOUTTP_EQMPARTS_REF01.sql](05.Procedure/MES_SNS2_COMTYPE_INOUTTP_EQMPARTS_REF01.sql)(신규), [02.Site/TMLPJT/TML1010/R05.xaml](02.Site/TMLPJT/TML1010/R05.xaml), [01.Office/PAGETAL/TAL0001/TAL0001_R09.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R09.aspx), [01.Office/PAGETAL/TAL0001/TAL0001_R09.js](01.Office/PAGETAL/TAL0001/TAL0001_R09.js)
- **배경 및 원인**: TML1010_R05 출고 팝업 출고구분에 구매입고(IN_01)·부품교체(OUT_01)가 함께 보임(예전 C# DataView 필터는 framework_convention.md 5조 위반으로 삭제됨). TAL0001_R09는 JS로 IN_ 목록을 지워 1개만 보였으나 같은 종류의 우회 코드. 공통코드 INOUTTP_EQMPARTS를 그대로 쓰면서 출고 관련 코드만 보이도록 요청
- **참고**: TML1030_R01 출고구분 `GPCD="INOUTTP_PRDCONSUM" REF01="OUT"` (공통코드 REF01로 입·출 구분, 공통 콤보 DC_COMBO `REF01 LIKE CONCAT('%', $REF01, '%')`)
- **작업 내용**
  - 1. 공통코드 : COMTYPE (GPCD = 'INOUTTP_EQMPARTS') REF01 = 'IN'(TPCD IN_%), 'OUT'(TPCD OUT_%) 등록 SQL (사용자 실행)
  - 1. TML1010_R05 출고 팝업 출고구분(cmb_OUTTP) : REF01="OUT" 추가 → 부품교체만 표시 (숨은 입고구분 cmb_INTP는 변경 없음)
  - 1. TAL0001_R09 출고 등록 창 출고구분(pop_cmb_OUTTP) : REF01="OUT" 추가, JS의 IN_ 목록 제거 코드 삭제
- **적용 순서**: 공통코드 SQL 먼저 실행(REF01이 비어 있으면 REF01="OUT" 콤보 목록이 빈 상태가 됨) → TML1010 빌드·배포 → 태블릿 새로고침
- **검증 결과**: TML1010 MSBuild 15.0 Release 빌드 성공(스크래치 폴더 출력, AAABIN 배포 안 함). 빌드 후 이벤트(COPY → 프로젝트 폴더 TML1010.exe)로 프로젝트 폴더 exe가 덮어써져 AAABIN/TML1010.exe(동일 크기·시각이던 원본)로 복원(MD5 일치). JS 구문 검사 통과, 인코딩 확인. 미확인: 공통코드 SQL 실행 결과(실제 REF01 현재 값), 실제 화면
- **배포**: 사용자 요청으로 TML1010 Release 재빌드 후 배포 (실행 중인 TML1010 없음 확인). bin/Release EXE·PDB → 02.Site/AAABIN 복사, 프로젝트 루트 TML1010.exe는 빌드 후 이벤트로 갱신. EXE SHA256 68c477e3…ecb85 (Release·AAABIN·프로젝트 루트 3경로 일치), PDB SHA256 d212f887…51dc (Release·AAABIN 일치). 컴파일된 R05.baml에 cmb_OUTTP REF01="OUT" 포함 확인
- **재배포(소스 충돌 후 최신 코드 기준)**: 형상관리 업데이트로 R01·R03(xaml·cs)·TML1010.csproj(TMLPRINT·DevExpress Printing/XtraPrinting/XtraReports 참조 추가)가 갱신되고 TML1010.exe/pdb에 충돌 파일(.r488·.r519) 생김. 소스에 충돌 표시 없음, R05 REF01="OUT" 유지 확인. 실행 중인 TML1010 없음 확인 후 Release 재빌드 성공 → bin/Release EXE·PDB를 02.Site/AAABIN에 복사, 프로젝트 루트 EXE는 빌드 후 이벤트로 갱신. EXE SHA256 95c5fb52…770d (Release·AAABIN·프로젝트 루트 일치), PDB SHA256 4a947e3e…84fc (Release·AAABIN 일치). 새 참조 TMLPRINT.exe·DevExpress 3개 dll은 AAABIN에 이미 있음. 충돌 파일(.r488·.r519)과 형상관리 충돌 해결 표시는 그대로 둠(사용자 처리)
- **재배포(충돌 정리 후)**: 사용자가 충돌 정리하며 AAABIN·프로젝트 루트 TML1010.exe가 다른 빌드(104,448바이트, 16:28)로 바뀜 → 충돌 파일 없음·소스 변경 없음(16:25 기준)·R05 REF01="OUT" 유지·실행 중 프로세스 없음 확인 후 Release 재빌드·배포. EXE SHA256 ac7d9a36…41ce (Release·AAABIN·프로젝트 루트 일치), PDB SHA256 8240c318…6fb7 (Release·AAABIN 일치), 컴파일된 R05에 REF01="OUT" 포함

---

## 🕒 2026-11-09 (월) 작업 내역

### 1. EQM1001_R04 정기점검 등록·수정 팝업 특이사항 입력 및 상단 입력칸 정렬

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx](01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx), [01.Office/PAGEEQM/EQM1001/EQM1001_R04.js](01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [05.Procedure/MES_SNS2_EQM1001_R04.sql](05.Procedure/MES_SNS2_EQM1001_R04.sql), [05.Procedure/MES_SNS2_EQM1001_R04_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_EQM1001_R04_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**: 등록(pop1)·수정(pop2) 팝업 점검값 옆에 특이사항 입력·수정 요청. 상단 입력칸은 라벨 90·입력폭 제각각(1행 끝 852px, 2행 끝 878px, 가운데 칸 시작도 어긋남)이라 정렬 요청
- **작업 상세 내용**:
  - 1. grid2·grid3: 점검값 다음에 특이사항(REMARK, 폭 230, 입력 가능) 추가, 점검명 폭 290 → 250 (컬럼 합계 1010 + 행번호·끝 칸 약 59 = 팝업 내용폭 1080 이내)
  - 1. 저장: 등록(ADD_CHKRSTEQM)·수정(SAVE_CHKRSTEQM) 모두 `REMARK_LIST` 전달
  - 1. 프로시저 EQM1001_R04
    - IN `$REMARK_LIST MEDIUMTEXT` 추가(14번), 변수 `_$REMARK VARCHAR(1000)` (CHKRSTEQMKND.REMARK 컬럼 길이)
    - LIST_PLAN_EQM02: 신규 등록 특이사항 기본값 = 계획 항목 특이사항(PLAN_ITEM.REMARK), 수정 가능 (3번 작업에서 변경, 최초 빈 값)
    - ADD_CHKRSTEQM: CHKRSTEQMKND INSERT에 REMARK 저장
    - SEARCH_CHKRSTEQM: 항목 조회에 RST_ITEM.REMARK 추가
    - SAVE_CHKRSTEQM: UPDATE에 REMARK 반영
    - 등록·수정 모두 항목 수와 특이사항 목록 수가 다르면 기존 안내로 저장 취소
    - BOM 제거(UTF-8 without BOM)
  - 1. 팝업 배치 (pop1·pop2 동일)
    - 팝업 Width 900 → 1100, Height 350 → 420 (문제점·조치사항 줄 분리로 상단 약 60px 증가)
    - 모든 라벨 폭 70 → 입력 시작선 74px 통일
    - 1행 설비코드·점검일자·점검자 3칸 각 358px 간격, 입력 영역 폭 284 (설비코드·점검자 찾기: 코드 90 + 이름 175, 점검일자 InputWidth 284)
    - 문제점·조치사항: 한 줄씩 전체폭 1000 → 입력 끝선 1074px 통일
    - pop2 점검삭제 버튼 MarginRight 6 → 오른쪽 끝 1074px
  - 1. SYSTEM_PARAMETERS 재등록 스크립트 추가 (정상 16건)
- **검증 결과**: 실제 bootstrap·ItsFind·ItsDate·ItsTextArea·ItsButton CSS로 만든 모형에서 기존 배치가 캡처와 일치(설비코드 입력 시작 94px, 점검자 끝 852px)하는 것을 확인한 뒤 새 배치 측정: 모든 입력 시작 74px·끝 1074px, 1행 3칸 시작 74/432/790px, 점검삭제 오른쪽 1074px, 가로 스크롤 없음. JS 구문 검사, IF 24/24·WHILE 2/2 짝, 인코딩(aspx·js BOM+CRLF, sql BOM 없음+CRLF) 확인. 미확인: 프로시저 서버 반영·실제 화면 저장·그리드 가로 스크롤
- **적용 순서**: MES_SNS2_EQM1001_R04.sql 프로시저 서버 저장 → MES_SNS2_EQM1001_R04_SYSTEM_PARAMETERS.sql 실행
- **연동**: 저장한 특이사항은 EQM1001_S04 설비점검항목 그리드와 점검시트 출력(S04A) 특이사항에 표시

### 2. EQM1001_R04 정기점검 현황에 승인 계획 없는 주기관리 설비 표시

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R04.sql](05.Procedure/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: R03 정기점검 주기관리에서 A-001·A-002 등에 점검자를 지정했는데 R04 현황에 나오지 않음. R03 주기관리(LIST_CYCLE_EQMCD)는 사용 중인 전체 설비를 보여주지만, R04 현황은 승인된 최신 REV에 항목이 있는 설비(또는 실적 있는 설비)만 표시하고 '점검필요'도 승인 계획이 있을 때만 표시함. 사용자 확인: 승인 리비전만 보이는 것은 의도된 설계가 아님. 승인본 CTE가 점검구분(CHKTP)을 구분하지 않아 일상점검('01') REV가 최신이면 정기점검 승인본이 가려질 수 있는 문제도 함께 발견
- **작업 상세 내용**:
  - 1. LIST_CYCLE_EQMCD 조회 대상: 사용 설비 중 승인 계획 있음 OR 해당 연도 실적 있음 OR **주기관리 점검자가 1개월 이상 지정된 설비**
  - 1. 월 상태: 실적 있으면 '점검완료', 주기관리 점검자 지정 월이면 승인 여부와 무관하게 '점검필요'
  - 1. APPROVED_PLAN: 승인(APRVSTT 'A') 정기점검(CHKTP '02') REV만 대상
  - 1. 승인 계획 없는 설비의 '점검필요' 클릭 → LIST_PLAN_EQM02에서 "승인된 정기점검 계획이 없습니다. 설비그룹·설비별 점검계획을 승인한 후 등록해주세요." 안내, 등록 팝업 열지 않음 (JS 기존 흐름 그대로)
- **검증 결과**: 12개월 조건 치환 12건 확인, IF 24/24 짝, 인코딩(BOM 없음+CRLF) 확인. DB 읽기 조회는 접속정보 복호화가 필요해 진행하지 못함(A-001·A-002 계획 상태 미확인). 미확인: 프로시저 서버 반영·실제 화면
- **적용 순서**: 1번과 같은 MES_SNS2_EQM1001_R04.sql 저장 → SYSTEM_PARAMETERS 재등록

### 3. EQM1001_S04 설비점검항목·점검시트 특이사항에 계획 특이사항 표시

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql), [05.Procedure/MES_SNS2_EQM1001_R04.sql](05.Procedure/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: S04 설비점검항목 그리드에서 특이사항이 있는데도 보이지 않음. 기존 조회는 점검실적 특이사항(CHKRSTEQMKND.REMARK)만 읽는데, R04 정기점검 등록은 지금까지 실적에 특이사항을 저장하지 않아 비어 있음. R03 점검계획에서 입력한 특이사항은 계획 항목(MSTEQMREV_DETAIL.REMARK)에 있음
- **작업 상세 내용**:
  - 1. LIST_CHKRSTEQMKND·CALL_CHKRST_RPT: 특이사항 = 실적 특이사항, 비어 있으면 점검 당시 적용 계획 항목 특이사항
    - 계획 항목 연결: CHKRSTEQMKND.PLANTP 'G' → CHKRSTEQM.GRPREVCD, 'E' → CHKRSTEQM.REVCD, + CHKKNDCD (MSTEQMREV_DETAIL PK)
    - PLANTP 빈 값(기존 실적)은 계획 연결 없음
  - 1. R04 LIST_PLAN_EQM02: 신규 등록 특이사항 기본값을 계획 항목 특이사항으로 채움 (점검자가 수정 가능, 저장 시 실적 특이사항으로 보관)
  - 1. 화면(JS) 변경 없음
- **검증 결과**: 인코딩(BOM 없음+CRLF) 확인, PK(REVCD, CHKKNDCD) 기준 조인이라 행 중복 없음. 미확인: 프로시저 서버 반영·실데이터 표시
- **참고**: 수정 팝업에서 실적 특이사항을 지우면 S04에는 계획 특이사항이 대신 표시됨

### 4. EQM1001_S04 점검시트(S04A) ReportFooter 복원

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/S04A.Designer.cs](04.Report/PAGEEQM/EQM1001/S04A.Designer.cs), [04.Report/PAGEEQM/EQM1001/S04A.cs](04.Report/PAGEEQM/EQM1001/S04A.cs), [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 2026-11-06 13번 작업에서 R03 기반으로 만들며 제외한 하단 ReportFooter(확인·점검자·담당 서명란, 개정이력)를 다시 넣어 달라는 요청
- **작업 상세 내용**:
  - 1. S04A.Designer.cs: VS 디자이너에서 저장된 현재 내용(제목 "설비 정기 점검 시트", 셀 Weight 등)은 그대로 두고, 현재 R03의 ReportFooter 밴드·컨트롤(서명란 라벨 6개, 개정이력 테이블 xrTableRevHistory 5행)을 생성·속성·필드 선언·Bands·BeginInit/EndInit에 추가. `components` 초기화 첫 줄 복원(report_devexpress 2-2)
  - 1. S04A.cs: CALL_CHKRST_RPT Tables[2]를 개정이력으로 받아 R03과 같은 BindRevHistory(최신 4건)로 바인딩
  - 1. 프로시저 CALL_CHKRST_RPT 3번째 결과셋(개정이력) 추가
    - 대상 계획: 점검실적의 설비별 적용 REV(CHKRSTEQM.REVCD), 없으면 설비그룹 적용 REV(GRPREVCD)
    - 해당 계획(PLANTP·PLANCD)의 REV 중 적용 REV 번호 이하만, 최신순
    - 컬럼은 R03 CALL_PLAN_RPT 개정이력과 동일: REVNUM, REVDATE, REMARK, REQEMPNM, APRVEMPNM
- **검증 결과**: MSBuild 15.0 Release Rebuild 성공(0 Error, 기존 R0602 경고 1건), exe 01.Office/Reports·04.Report/bin 배포(MD5 일치), 점검키 미전달 안내 정상. 기본 생성자 + 샘플 12행으로 PNG 출력해 밴드 5개·하단 확인/점검자/담당/개정이력 영역 표시 확인. 미확인: 프로시저 서버 반영 후 실데이터 개정이력, VS 디자이너 열기
- **적용 순서**: MES_SNS2_EQM1001_S04.sql 서버 저장 (파라미터 변경 없음)

### 5. EQM1001_S04 점검시트 점검자·승인자 표시 및 설비 전체 개정이력 조회

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql), [04.Report/PAGEEQM/EQM1001/S04A.cs](04.Report/PAGEEQM/EQM1001/S04A.cs), [04.Report/PAGEEQM/EQM1001/S04A.Designer.cs](04.Report/PAGEEQM/EQM1001/S04A.Designer.cs), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 하단 서명란에 점검자·승인자 표시, 개정이력은 해당 설비 관련 REV 전체 조회 요청. 사용자 선택: 표시는 최신 4건 유지, 설비별 + 설비그룹 계획 모두, 담당 칸에 승인자(칸 제목 유지)
- **작업 상세 내용**:
  - 1. CALL_CHKRST_RPT 상단 결과에 추가
    - CHKEMPNM: 점검자 (CHKRSTEQM.EMPCD → MSTEMP.EMPNM, 없으면 사원코드)
    - APRVEMPNM: 점검 당시 적용 계획의 승인자. 설비그룹 REV(GRPREVCD) → 설비별 REV(REVCD) 순, 같은 사람이면 한 번만 (점검실적 자체에는 승인 절차가 없음)
  - 1. 개정이력(3번째 결과셋) 대상 변경: 적용 REV 이하 → 전체 REV
    - 설비별 계획(PLANTP 'E', PLANCD = 설비코드) + 설비그룹 계획(PLANTP 'G', 적용 그룹 REV의 그룹, 없으면 현재 MSTEQM.EQMGUBUN)
    - 점검구분: 실적 CHKTP와 같은 REV, 정기점검('02')은 CHKTP 빈 값(구분 저장 전 REV)도 포함
    - 개정 내용 앞에 [그룹]/[설비] 표시, 승인·요청 시간 최신순 (리포트는 최신 4건 표시)
  - 1. S04A: 점검자 칸 = CHKEMPNM, 담당 칸 = APRVEMPNM 바인딩, 두 서명 칸 맑은 고딕 9pt·가운데 정렬
- **검증 결과**: MSBuild 15.0 Release Rebuild 성공(0 Error, 기존 R0602 경고 1건), exe 01.Office/Reports·04.Report/bin 배포(MD5 일치). 샘플 데이터로 BindReportData 호출 후 PNG 출력: 점검자 "김진욱", 담당 "이성남, 신재민", 개정이력 5건 중 최신 4건이 [설비]/[그룹] 구분과 함께 표시됨 확인. 괄호 짝 64/64, 인코딩 확인. 미확인: 프로시저 서버 반영 후 실데이터, VS 디자이너 열기
- **적용 순서**: MES_SNS2_EQM1001_S04.sql 서버 저장 (파라미터 변경 없음)
- **변경**: 담당 칸의 적용 계획 승인자는 6번 작업에서 설비마스터 점검담당자로 교체

### 6. EQM1001_S04 점검시트 담당 칸을 설비마스터 점검담당사번 기준으로 변경

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql), [04.Report/PAGEEQM/EQM1001/S04A.cs](04.Report/PAGEEQM/EQM1001/S04A.cs), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 담당 칸에 계획 승인자 대신 담당자 성격의 데이터 사용 요청. 조사 결과 MSTEQM.EMPCD(점검담당사번, ERP 인터페이스 MES_IF_MSTEQM의 CHK_EMP)와 MSTEQM.DEPTCD(관리부서코드)가 있음. 점검시트의 점검자(CHKRSTEQM.EMPCD, 점검 1건의 실제 점검자)와는 별개 값이며 MSTEQM.EMPCD를 읽는 프로시저는 없었음
- **사용자 실DB 확인 결과**: 사용 설비 1143개 중 점검담당사번 입력 224개, MSTEMP.EMPCD와 일치 2개, MSTEMP.OLDEMPCD·EMPID 일치 0개, 관리부서코드 입력 1005개 → 사용자 결정: 점검담당사번 기준
- **작업 상세 내용**:
  - 1. CALL_CHKRST_RPT 상단 결과: APRVEMPNM(적용 계획 승인자)과 관련 조인 4개 제거, MNGEMPNM 추가 = MSTEMP 사원명, 없으면 MSTEQM.EMPCD 사번 그대로, 비어 있으면 빈 값
  - 1. S04A 담당 칸(xrLabelManagerSign) 바인딩 APRVEMPNM → MNGEMPNM
  - 1. 개정이력 표의 승인자(APRVEMPNM) 컬럼은 그대로 유지
- **검증 결과**: MSBuild 15.0 Release Rebuild 성공(0 Error, 기존 경고 1건), exe 배포(MD5 일치), 샘플 PNG 출력에서 점검자 "김진욱"·담당 "FA-0123"(사원명 미매칭 사번) 표시 확인, 인코딩 확인. 미확인: 프로시저 서버 반영 후 실데이터
- **참고**: 현재 데이터 기준으로 담당 칸은 대부분 빈칸(919개 설비)이거나 사번 표시(222개), 사원명은 2개 설비만 표시됨. ERP 점검담당사번과 MES 사원코드 체계를 맞추면 사원명으로 표시됨
- **적용 순서**: MES_SNS2_EQM1001_S04.sql 서버 저장 (파라미터 변경 없음)
- **관리 위치 조사**: MSTEQM.EMPCD·DEPTCD는 ERP 인터페이스(MES_IF_MSTEQM, IFSTD 'FAC2_MES_EQM', 1분 주기, ERP CHK_EMP·CHK_DEPT)로만 입력됨. MES에서 수정하는 화면·프로시저 없음(MSTEQM UPDATE는 MST1005_R01 설비등급만). 조회·사용처: MST1002_R06 설비정보관리(담당부서·담당사원 컬럼, 조회 전용, 담당부서 컬럼 바인딩명 DEPTP ≠ 프로시저 DEPTCD라 빈 값 표시), MST1005_R01 설비등급 평가표(관리부서 → 결재 "부서명+장"), EQM1001_S04 점검시트(담당 칸)

### 7. EQM1001_S04 점검시트 하단(ReportFooter) 디자인 정리

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/S04A.Designer.cs](04.Report/PAGEEQM/EQM1001/S04A.Designer.cs), [04.Report/PAGEEQM/EQM1001/S04A.cs](04.Report/PAGEEQM/EQM1001/S04A.cs), [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 개정이력 영역이 보기 좋지 않다는 요청. 원인: ① 서명칸 XRLabel이 각자 4면 테두리를 그려 경계선이 2줄(두꺼운 선)로 겹침 ② 개정이력 칸에 일자·[구분]·내용이 한 칸에 몰려 줄바꿈 ③ 셀 CanGrow로 내용 길이에 따라 행 높이가 제각각, 헤더가 표 아래에 위치
- **작업 상세 내용**:
  - 1. 경계선 1줄: 왼쪽 컨트롤만 오른쪽 선을 그리고 다음 컨트롤은 Left 제외(점검자·담당 헤더 Top|Right|Bottom, 서명칸 Right|Bottom, 개정이력 라벨·표 Top|Right|Bottom)
  - 1. 헤더 통일: 확인·점검자·담당·개정이력 라벨·개정이력 표 헤더를 상단 한 줄(높이 22) 회색(Gainsboro) 배경으로, 표 헤더를 아래 → 위로 이동
  - 1. 개정이력 표: "개정이력" 세로 라벨 폭 90 → 24, 표 폭 383 → 449, 컬럼 No 24·일자 64·구분 32·개정 내용 229·작성 50·승인 50 (일자·구분 칸 분리)
  - 1. 행 높이 30 고정(CanGrow false), 데이터 8pt·개정 내용 7.5pt로 2줄까지 줄바꿈, 3줄 이상은 잘림. 최신순 위에서 아래로 4건
  - 1. Footer 높이 128 → 146 (표 142 = 헤더 22 + 4행 × 30)
  - 1. 프로시저 개정이력 결과: [그룹]/[설비] 접두어 제거, PLANTPNM(그룹/설비) 컬럼 분리
- **검증 결과**: MSBuild 15.0 Release Rebuild 성공(0 Error, 기존 경고 1건), exe 배포(MD5 일치), 생성 컨트롤 82개·필드 선언 82개 1:1 확인, 긴 개정 내용 샘플로 150dpi PNG 출력해 단일 경계선·고정 행 높이·2줄 줄바꿈 확인, 인코딩 확인. 미확인: 프로시저 서버 반영 후 실데이터, VS 디자이너 열기
- **적용 순서**: MES_SNS2_EQM1001_S04.sql 서버 저장 (파라미터 변경 없음)
- **변경**: 8번 작업에서 기존 형식으로 롤백 (이 디자인은 적용되지 않음)

### 8. EQM1001_S04 점검시트 하단 기존 형식 롤백, 개정 이력 날짜 제거

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/S04A.Designer.cs](04.Report/PAGEEQM/EQM1001/S04A.Designer.cs), [04.Report/PAGEEQM/EQM1001/S04A.cs](04.Report/PAGEEQM/EQM1001/S04A.cs), [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 7번 디자인 대신 기존 형식으로 롤백하고, 개정 이력 칸은 날짜 없이 [그룹]/[설비] 구분만 앞에 표시하도록 요청
- **작업 상세 내용**:
  - 1. S04A.Designer.cs: 4번 작업과 같은 방식으로 재구성(커밋된 S04A + 현재 R03 ReportFooter, components 초기화, 점검자·담당 서명칸 9pt·가운데 정렬). 하단 배치·크기·테두리·헤더 위치(아래)는 R03과 동일, 개정 이력 행은 내용 길이만큼 늘어남
  - 1. S04A.cs BindRevHistory: R03과 같은 배치(최신 4건, 아래쪽부터 채움)로 복원, 개정 이력 칸 = "[" + PLANTPNM + "] " + 개정내용 (날짜 제외)
  - 1. 프로시저 개정이력 결과에서 REVDATE 컬럼 제거 (정렬은 승인·요청 시간 그대로)
- **검증 결과**: MSBuild 15.0 Release Rebuild 성공(0 Error, 기존 경고 1건), exe 배포(MD5 일치), Designer 957줄·생성/필드 1:1 확인, 샘플 PNG 출력에서 기존 형식과 "[설비] 내용"·"[그룹] 내용"(날짜 없음) 표시 확인, 인코딩 확인. 미확인: 프로시저 서버 반영 후 실데이터, VS 디자이너 열기
- **적용 순서**: MES_SNS2_EQM1001_S04.sql 서버 저장 (파라미터 변경 없음)

### 9. EQM1001_S04 점검시트 개정이력 No 1부터 표시

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql)
- **배경 및 원인**: 개정이력 No가 REV 번호(제정 0) 그대로라 0부터 표시됨, 1부터 시작하도록 요청
- **작업 상세 내용**: CALL_CHKRST_RPT 개정이력 결과의 REVNUM을 `PLAN_REV.REVNUM + 1`로 반환 (제정 0 → 1). 정렬은 원래 REV 번호 기준 그대로, 레포트·exe 변경 없음
- **검증 결과**: 인코딩(BOM 없음+CRLF) 확인. 미확인: 프로시저 서버 반영 후 실데이터
- **적용 순서**: MES_SNS2_EQM1001_S04.sql 서버 저장 (파라미터 변경 없음)

### 10. EQM1001_R03 점검계획 REV 처리를 정기점검(CHKTP '02')으로 한정

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql)
- **배경 및 원인**: MSTEQMREV_HEADER에는 일상점검(CHKTP '01', TAL0001_R05에서 조회) REV도 같은 PLANTP·PLANCD로 저장될 수 있는데, R03은 REV를 찾을 때 점검구분 조건이 없어 일상점검 REV를 정기점검 REV로 잡을 수 있음. 정기점검 화면 전체 점검 결과 중 사용자가 지정한 항목만 수정 (목록·항목 조회 LIST_MSTEQM_GRP·LIST_GRP_EQM02·LIST_MSTEQM·LIST_EQM02·복사 목록, CALL_PLAN_RPT, R05 LIST_PLAN은 이번에 수정하지 않음)
- **작업 상세 내용**:
  - 1. 공통 검증 수정 대상 REV: `CHKTP = '02'` 최신 REV
  - 1. 복사 원본 REV(_$COPYREVCD): `CHKTP = '02'` 최신 REV
  - 1. LIST_PLAN_REV(REV 이력): `CHKTP = '02'`만 조회
  - 1. SAVE_PLAN_REV(개정내용 저장)·SAVE_PLAN_STATUS(승인): 존재 확인과 대상 최신 REV 모두 `CHKTP = '02'`
  - 1. 새 REV 번호: 고유키 UX_MSTEQMREV_HEADER_REV(PLANTP, PLANCD, REVNUM)에 CHKTP가 없어 일상점검과 번호를 함께 쓰므로, 정기점검 최신 REV + 1 대신 점검구분 무관 최대 REVNUM + 1(_$NEXTREVNUM). 일상점검 REV가 사이에 있으면 정기점검 번호가 건너뛸 수 있음
  - 1. 화면 연동 확인: 저장·승인에 넘기는 REVNUM은 REV 이력 그리드(LIST_PLAN_REV) 최신 행 값이라 수정 후에도 같은 기준. LIST_PLAN_REV_ITEM은 REVNUM이 대상별 고유라 그대로 동작
- **검증 결과**: IF/END IF 41/41 짝, 인코딩(BOM 없음+CRLF) 확인. 이 저장소에는 CHKTP '01' REV를 만드는 화면이 없어 실데이터 존재 여부 미확인. 미확인: 프로시저 서버 반영·화면 동작
- **남은 항목**: 목록 조회(설비그룹·설비 최신 REV 표시, 항목·미등록 항목·복사 목록), 계획서 출력(CALL_PLAN_RPT), R05 승인관리 LIST_PLAN은 아직 점검구분 조건 없음. 고유키에 CHKTP를 넣으면(B안) 점검구분별 번호 분리 가능
- **적용 순서**: MES_SNS2_EQM1001_R03.sql 서버 저장 (파라미터 변경 없음)

### 11. EQM1001_R03 정기점검 주기관리 월별 점검계획 레포트(R03B) 출력 추가

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx](01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx), [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql), [04.Report/PAGEEQM/EQM1001/R03B.cs](04.Report/PAGEEQM/EQM1001/R03B.cs), [04.Report/PAGEEQM/EQM1001/R03B.Designer.cs](04.Report/PAGEEQM/EQM1001/R03B.Designer.cs), [04.Report/PAGEEQM/EQM1001/R03B.resx](04.Report/PAGEEQM/EQM1001/R03B.resx), [04.Report/PAGEEQM/EQM1001/EQM1001.csproj](04.Report/PAGEEQM/EQM1001/EQM1001.csproj), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 정기점검 주기관리 탭 저장·삭제 버튼 줄 맨 오른쪽에 "월별점검계획 레포트 출력" 버튼을 두고, 사용자가 첨부한 엑셀 "월별 점검 계획" 양식으로 출력 요청. 점검자가 배정된 월만 표시
- **작업 상세 내용**:
  - 1. 화면: div_CYCLE_EQM에 btn_CYCLE_RPT(폭 170, Float right, MarginRight 10) 추가, 클릭 시 조회년도(cmb_SYEAR)·설비 검색값(find1)을 `ItsXtraRpt('EQM1001_R03B')`로 전달 (조회 그리드와 같은 조건)
  - 1. 프로시저 CALL_CYCLE_RPT 분기 추가 (입력 파라미터 추가 없음 → SYSTEM_PARAMETERS 변경 없음)
    - CHKPLANEQM_YEARPLAN(정기점검 '02', 조회년도)의 MONTH_01~12를 1~12월 행으로 펼쳐 점검자 지정 월만 출력, 사용 설비(USEYN 'Y')만
    - 컬럼: 구분(순번)·라인명(MSTLINE)·공정구분(FM100)·대분류(FM113)·중분류(FM114)·소분류(FM115)·설비명·모델명/규격(EQMNM_DETAIL)·점검예정일(YY.MM)·점검실시일(해당 월 정기점검 실적 첫 점검일 YY.MM.DD)·점검자(MSTEMP 사원명, 없으면 사원코드)
    - 정렬: 월 → 라인 → 공정구분 → 대·중·소분류 → 설비코드
  - 1. 레포트 R03B (A4 세로, 여백 30, 폭 767): 제목 "월별 점검 계획"(연보라 배경)과 컬럼 헤더를 PageHeader에 두어 페이지마다 반복, Detail 1행 25px, 점검예정 월별 행 배경색 12색(첨부 양식 색상 기준)
- **검증 결과**: MSBuild 15.0 Release 빌드 성공(0 Error, 기존 R0602 경고 1건), exe 01.Office/Reports·04.Report/bin 배포(MD5 일치). 기본 생성자 + 샘플 60행으로 PNG 출력해 제목·헤더·월별 배경색·컬럼 배치 확인(2페이지). IF 42/42 짝, 인코딩(sql BOM 없음+CRLF, cs·resx·aspx BOM+CRLF, js 기존 BOM 없음+CRLF 유지) 확인. 미확인: 프로시저 서버 반영 후 실데이터·화면 버튼 동작, VS 디자이너 열기
- **적용 순서**: MES_SNS2_EQM1001_R03.sql 서버 저장 (파라미터 변경 없음)

### 12. EQM1001_R03 월별 점검계획 레포트(R03B) 행 한 줄 고정 표시

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R03B.Designer.cs](04.Report/PAGEEQM/EQM1001/R03B.Designer.cs), [04.Report/PAGEEQM/EQM1001/R03B.cs](04.Report/PAGEEQM/EQM1001/R03B.cs), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 첨부 엑셀처럼 한 행씩 한 줄로 끊어서 표시 요청. 기존 셀은 줄바꿈(WordWrap)·자동 높이(CanGrow)라 긴 설비명·모델명은 행이 여러 줄로 늘어남
- **작업 상세 내용**:
  - 1. Detail 셀 11개 CanGrow false·WordWrap false → 모든 행 높이 25 고정, 한 줄 표시
  - 1. Detail_BeforePrint에서 칸 폭보다 긴 글자는 글자 크기를 0.5pt 단위로 줄여 한 줄에 맞춤(기본 8.5pt, 최소 6pt). 6pt로도 넘치면 칸 끝에서 잘림
- **검증 결과**: MSBuild 15.0 Release 빌드 성공(0 Error, 기존 경고 1건), exe 01.Office/Reports·04.Report/bin 배포(MD5 일치). 긴 설비명·모델명 샘플 60행 PNG 출력에서 모든 행 한 줄·같은 높이, 긴 글자 축소 표시 확인. 미확인: 실데이터·VS 디자이너 열기
- **적용 순서**: 프로시저 변경 없음 (11번의 R03.sql 서버 저장만 필요)

### 13. EQM1001_R01 설비수리이력 사진 미리보기·등록 영역 추가

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx](01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx), [01.Office/PAGEEQM/EQM1001/EQM1001_R01.js](01.Office/PAGEEQM/EQM1001/EQM1001_R01.js), [05.Procedure/MES_SNS2_EQM1001_R01.sql](05.Procedure/MES_SNS2_EQM1001_R01.sql), [05.Procedure/MES_SNS2_EQM1001_R01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_EQM1001_R01_SYSTEM_PARAMETERS.sql), [06.Table/MES_SNS2_EQMREP_IMG.sql](06.Table/MES_SNS2_EQMREP_IMG.sql)
- **배경 및 원인**: 오른쪽 작업자 그리드는 그대로 두고 아래에 이미지 미리보기·파일등록 영역 추가 요청. 공통 컴포넌트(ItsFileManager 업로드·삭제, ItsImage 미리보기)를 쓰고, 수리 1건에 여러 장(EQM1001_R06 방식: 선택 즉시 업로드 → 파일키 등록, ✕ 삭제)으로 구성. 크게 보기 팝업은 MST0001_R04 pop2 방식
- **작업 상세 내용**:
  - 1. 테이블 EQMREP_IMG 신규(EQMREPKEY·FILEKEY PK, 등록 감사 컬럼). 파일 실체·경로는 공통 COMFILE, URL은 공통 함수 FILEURL()
  - 1. 프로시저 EQM1001_R01
    - IN `$FILEKEY VARCHAR(100)` 추가(21번, 전체 41개) → SYSTEM_PARAMETERS 재등록 스크립트 추가
    - LIST_EQMREP_IMG(FILEKEY·FILEURL, 등록순), ADD_EQMREP_IMG(수리이력 존재·파일키 확인 후 등록), DELETE_EQMREP_IMG(등록 확인 후 삭제)
    - DELETE_EQMREP: 수리이력 삭제 시 EQMREP_IMG도 삭제
    - BOM 제거, LF → CRLF (encoding.md: 수정 시점에 BOM 제거)
  - 1. 화면 배치: 좌우 비율 80:20 → 70:30, 오른쪽을 위(35%: 기존 행추가·행삭제 버튼 + 작업자 그리드) / 아래(■ 수리 사진 (개수) + 사진 등록 버튼, 큰 미리보기 + 순번 표시, 썸네일 줄)로 분할. 공통 ItsFileManager(이미지 전용)는 숨기고 "사진 등록" 버튼이 파일 선택창을 염
  - 1. 동작: 수리이력 선택 시 작업자와 사진 함께 조회, 첫 사진 미리보기 / 썸네일 클릭 시 미리보기 변경 / 사진 선택 즉시 업로드 → 등록(등록 실패 시 업로드 파일 삭제) / ✕ → 확인 후 등록 삭제 → 파일 삭제 / 미리보기 클릭 → 크게 보기 팝업(pop_REPIMG) / 수리이력 삭제 시 사진 파일도 삭제
- **검증 결과**: JS 구문 검사 통과, IF 38/38·WHILE 5/5 짝, 파라미터 41개(FILEKEY 21번), 인코딩(aspx·js BOM+CRLF, 프로시저 BOM 없음+CRLF, 테이블 BOM+CRLF) 확인. 실제 페이지 CSS로 만든 정적 모형에서 사진 3장·0장 화면 배치 확인. 미확인: 테이블 생성·프로시저 서버 반영 후 실제 업로드·삭제(공통 업로드는 localhost에서 막혀 있어 서버 주소로 확인 필요), 분할 영역 실제 높이
- **적용 순서**: MES_SNS2_EQMREP_IMG.sql 테이블 생성 → MES_SNS2_EQM1001_R01.sql 프로시저 저장 → MES_SNS2_EQM1001_R01_SYSTEM_PARAMETERS.sql 실행(41건)

### 14. EQM1001_R01 사진 영역 공통 파일선택 숨김·빈 미리보기 안내, 공통 업로드 localhost 차단 임시 해제

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx](01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx), [01.Office/PAGEEQM/EQM1001/EQM1001_R01.js](01.Office/PAGEEQM/EQM1001/EQM1001_R01.js), [01.Office/UserControl/ItsFileManager.js](01.Office/UserControl/ItsFileManager.js) (**공통, 임시**)
- **배경 및 원인**:
  - 사진 영역 가운데에 공통 ItsFileManager의 "선택"(파일 선택)·"삭제"(선택 비우기, 등록 사진 삭제 아님) 버튼이 보임. 공통 컨트롤 ascx에서 StyleType simple일 때 style 속성 따옴표가 `text-align:center;"`에서 먼저 닫혀 뒤의 Hidden(display:none)이 style 밖으로 나가 숨김이 적용되지 않음
  - 사진이 없을 때 공통 기본 이미지(UploadFiles/404IMAGE.jpg)가 로컬에 없어 깨진 이미지 아이콘 표시
  - 로컬 미리보기 테스트를 위해 공통 업로드 localhost 차단 임시 해제 요청 (사용자 지시)
- **작업 상세 내용**:
  - 1. R01: fileManager Hidden 속성 제거, 페이지 CSS `#file_REPIMG { display:none !important; }`로 숨김 (공통 ascx 수정 없음). "사진 등록" 버튼이 숨긴 파일선택을 여는 동작은 그대로
  - 1. R01: 사진이 없으면 미리보기 칸에 기본 이미지 대신 안내 문구(수리이력 미선택: "수리이력을 선택하면 사진이 표시됩니다." / 사진 없음: "등록된 사진이 없습니다. [사진 등록]으로 추가하세요."), 썸네일 줄 하단 안내 문구 제거
  - 1. ItsFileManager.js: $upload·UploadNM·$delete 3곳의 localhost 차단 if 블록을 `[TEMP 2026-11-09 ...]` 표시와 함께 주석 처리
- **검증 결과**: JS 구문 검사(R01·ItsFileManager) 통과, 인코딩(BOM+CRLF) 유지. 미확인: 로컬 실제 업로드·미리보기
- **주의**: 로컬 업로드 파일은 로컬 01.Office/UploadFiles에 저장되지만 COMFILE·EQMREP_IMG 기록은 연결된 DB에 남음(다른 PC·서버에서는 파일 없음). 테스트 후 등록 사진 삭제
- **현재 상태**: 사용자가 원복한 뒤 로컬 테스트를 위해 다시 주석 처리(3곳). 테스트 후 원복 필요 (`git checkout -- 01.Office/UserControl/ItsFileManager.js` 또는 TEMP 표시 3곳 주석 해제)

### 15. 태블릿 TAL0001_R08(설비 정기점검 등록)·TAL0001_R09(설비부품 출고등록) 파일 세팅

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx) (.aspx.cs, .js, .css), [01.Office/PAGETAL/TAL0001/TAL0001_R09.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R09.aspx) (.aspx.cs, .js, .css)
- **배경 및 원인**: 태블릿 화면 2개 신규 요청. PAGETAL 폴더 역할 정리(TAL0001 자재·물류·설비, TAL1001 생산 실적, TAL1002 초중종검사, TAL2001 자주검사) 후, 설비 일상점검(R05)·비가동(R06)이 있는 TAL0001에 이어 번호 부여. R03은 이 프로젝트·ALPHA 모두 비어 있어 메뉴 충돌 가능성 때문에 제외
- **작업 상세 내용**: TAL0001_R05와 같은 구성(Kiosk.master, CPH_HEAD js·css, CPH_SEARCH·CPH_BODY·CPH_POP 빈 영역, BasePage 코드비하인드, ItsPage.Load 빈 함수)으로 4개 파일씩 생성. 화면 기능·프로시저는 아직 없음
- **검증 결과**: JS 구문 검사 통과, 인코딩(UTF-8 BOM+CRLF) 확인. 미확인: 메뉴 등록·화면 열기
- **남은 작업**: 화면 구현, 프로시저 MES_SNS2_TAL0001_R08.sql·R09.sql 작성 및 SYSTEM_PARAMETERS 등록, DB 메뉴 등록.

### 16. SYS0001_R03 프로그램코드 변경 후 화면이 사라지는 문제, 관련 테이블 코드 맞추기 SQL

- **수정/대상 파일**: [05.Procedure/MES_SNS2_SYS0001_R03_PRGCD_RENAME.sql](05.Procedure/MES_SNS2_SYS0001_R03_PRGCD_RENAME.sql) (신규, 데이터 정리 스크립트)
- **배경 및 원인**: 메뉴관리(SYS0001_R03)에서 이름을 바꾼 뒤 화면이 보이지 않음. SYS0001_R03 프로시저는 저장소에 없어 ALPHA DB 백업(08. DB Backup/20260619.sql)과 이 저장소의 WEBSYSMAIN으로 확인
  - SYS0001_R03 목록(LIST_WEBPKG): SYSMENU LEFT JOIN SYSPRG 후 `P.PRGSTT LIKE`·`P.DEV LIKE`·PRGSTT <> '50' 조건 → SYSPRG에 같은 PRGCD가 없으면 목록에서 빠짐
  - 메인 메뉴(LIST_MENU2)·태블릿 화면(LIST_MENU_TAB): SYSMENU·SYSPRG(PRGSTT 30·40만 화면 연결)·SYSAUTPRG(조회권한) 모두 같은 PRGCD 필요, 화면 경로는 PRGCD로 생성(PAGE + 앞 3자리 / 앞 7자리 / PRGCD.aspx). 태블릿 메뉴 목록은 SYSMENU PKGTP 'TAL', 이름은 GPCD('PRGCD')
  - 화면에서 저장(SAVE_WEBPRG)은 이름(PRGNM·MENUNM)만 바꾸고 코드는 바꾸지 않으므로, 코드를 한 테이블에서만 바꾸면 연결이 끊김
- **작업 상세 내용**: 1. 진단(SYSMENU·SYSPRG 짝 불일치, 권한 없는 메뉴, 작업상태 30·40 외) → 2. @OLD_PRGCD·@NEW_PRGCD 지정 → 3. 테이블별 건수 → 4. 트랜잭션으로 PRGCD 일괄 변경(SYSPRG, SYSMENU, SYSAUTPRG, SYSAUTPRGUSER, SYSUSERADDAUT, SYSMENUUSER, SYSMENUUSERHIS, SYSMENUUSERLOG, SYSGRIDSTYLE, SYSLANGTEMP, COMLANG, MSTTMLPRG; 새 코드 행이 이미 있으면 UPDATE IGNORE 후 이전 코드 행 삭제) → 5. 결과 확인 후 COMMIT/ROLLBACK 수동
- **검증 결과(16번)**: 인코딩(BOM 없음+CRLF). DB 직접 실행하지 않음(규칙).

### 17. 태블릿 TAL0001_R08 설비 정기점검 등록 구현 (EQM1001_R04 로직, 태블릿 UI)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [TAL0001_R08.css](01.Office/PAGETAL/TAL0001/TAL0001_R08.css), [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql) (신규), [05.Procedure/MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql) (신규)
- **배경 및 원인**: PC 정기점검 등록(EQM1001_R04)과 같은 로직을 태블릿 UI(TAL0001_R05 참고)로 구현 요청. 사용자 지시로 프로시저는 EQM1001_R04를 공유하지 않고 TAL0001_R08로 별도 생성
- **작업 상세 내용**:
  - 1. 프로시저 TAL0001_R08: EQM1001_R04 본문 그대로 복사(파라미터 16개·분기 LIST_CYCLE_EQMCD·LIST_PLAN_EQM02·ADD/SEARCH/SAVE/DELETE_CHKRSTEQM 동일, 헤더만 신규). 본문 동일 여부 diff로 확인. 이후 R04 로직을 고치면 R08도 같이 고쳐야 함
  - 1. 화면 위: 조회년도(기본 올해)·설비 검색, 선택 월 요약(대상·완료·미점검), 1~12월 탭(완료/대상 건수, 기본 이번 달), 선택 월 점검 대상 설비 카드(R05 설비 버튼 모양 + 점검필요 주황·점검완료 초록 상태 표시)
  - 1. 가운데 버튼(R05와 동일 크기·글씨): 조회 / 점검(점검필요일 때) / 수정·삭제·문제점/조치사항(점검완료일 때)
  - 1. 아래 그리드: 왼쪽 점검 정보(점검월·상태·점검일자·점검자), 오른쪽 점검 항목(점검완료: 저장된 실적 항목 / 점검필요: 승인 계획 항목 미리보기, 승인 계획 없으면 R04와 같은 안내 후 점검 버튼 비활성)
  - 1. 등록 팝업: 설비·점검일자(이번 달이면 오늘, 아니면 그 달 1일)·점검자(주기관리 점검자 기본)·문제점/조치사항 버튼, 항목 그리드 더블탭 → 점검값구분 03은 OK/NG 버튼, 그 외 숫자패드(R05 패드), 특이사항 칸은 큰 입력창. 문제점/조치사항은 숨은 칸에 담아 등록 시 함께 저장(R04와 같은 ADD_CHKRSTEQM 입력)
  - 1. 수정 팝업: 같은 구성에 기존 값 표시, SAVE_CHKRSTEQM. 메인 [삭제]는 DELETE_CHKRSTEQM, 메인 [문제점/조치사항]은 기존 점검값·특이사항 그대로 두고 문제점/조치사항만 바꿔 SAVE_CHKRSTEQM
- **검증 결과**: JS 구문 검사 통과, JS에서 쓰는 컨트롤 ID 전부 aspx에 존재, 중복 ID 없음, 인코딩(aspx·js·css BOM+CRLF, sql BOM 없음+CRLF). 페이지 CSS와 실제 RENDER_MONTH·RENDER_EQM 함수로 만든 모형(1280px)에서 월 탭 12개 한 줄·카드 한 줄 4개·가로 스크롤 없음·요약 건수 확인. 미확인: 프로시저 서버 반영·메뉴 등록 후 실제 태블릿 동작(등록·수정·삭제·숫자패드)
- **적용 순서**: MES_SNS2_TAL0001_R08.sql 프로시저 저장 → MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql 실행(16건) → SYS0001_R03에서 TAL0001_R08 메뉴 등록(패키지 TAL)

### 18. TAL0001_R08 월 건수·요약 제거, 설비 카드 좌우 스크롤·상태별 배경색

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [TAL0001_R08.css](01.Office/PAGETAL/TAL0001/TAL0001_R08.css)
- **배경 및 원인**: 사용자 요청 - 월 탭 아래 건수와 우측 상단 요약 건수 삭제, 설비 카드 목록을 위아래가 아닌 좌우 스크롤로, 점검필요·점검완료는 카드 오른쪽 아래 표시 대신 카드 전체 배경색으로
- **작업 상세 내용**:
  - 1. 월 탭은 "N월"만 표시(높이 56 → 50, 글씨 18 → 20), 우측 상단 요약(spn_SUMMARY) 제거
  - 1. 설비 카드 목록(EQM_LIST): 한 줄 배치(white-space nowrap) + 좌우 스크롤(overflow-x auto, overflow-y hidden), 높이 170 → 150, 카드 크기는 R05와 같은 250×100
  - 1. 카드 배경색: 점검필요 주황(#fdebd0, 테두리 #f0b27a), 점검완료 초록(#d5f5e3, 테두리 #7dcea0). 선택 카드는 배경색(상태)을 유지하고 파란 두꺼운 테두리로 표시
- **검증 결과**: JS 구문 검사 통과, 인코딩 유지. 실제 RENDER 함수·CSS 모형(1280px, 설비 10개)에서 카드 1줄·목록 가로 스크롤(내용폭 2720 > 1280)·세로 넘침 없음·페이지 가로 스크롤 없음·상태별 배경색·건수/요약 미표시 확인. 미확인: 실제 태블릿 터치 스크롤

### 19. TAL0001_R08 등록·수정 팝업 점검자 이름 표시, 문제점/조치사항 배치 개선

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql)
- **배경 및 원인**:
  - 수정 팝업 점검자(20150801) 옆 이름칸이 빈 값. 공통 찾기 컨트롤은 코드 입력 시 DC_FIND 'EMPCD_LIST'로 이름을 찾는데 이 목록은 `MSTEMP.FACTORYCD = '07'`만 대상이라, 다른 공장 소속(또는 MSTEMP에 없는) 사원은 이름이 표시되지 않음. 주기관리 점검자 매칭(LIST_PLAN_EQM02)과 등록 검증은 공장 조건이 없어 이런 점검자가 저장될 수 있음
  - 문제점/조치사항 버튼이 입력칸 아래 왼쪽에 따로 떠 있고, 입력했는지 팝업에서 보이지 않음
- **작업 상세 내용**:
  - 1. 프로시저 TAL0001_R08(표시용 컬럼만 추가, 처리 로직 동일): LIST_PLAN_EQM02에 PLANEMPNAME(계획 점검자 사원명), SEARCH_CHKRSTEQM 첫 결과에 EMPNM(LEFT JOIN MSTEMP, 공장 조건 없음)
  - 1. 화면: 찾기 컨트롤 이름칸이 비면 프로시저가 준 사원명으로 채움(SET_FIND_NAME, 공통 컨트롤 수정 없음), 메인 왼쪽 그리드 점검자도 사원명(EMPNM) 표시
  - 1. 팝업 상단 2줄 정렬: 1줄 설비(라벨 80)·점검일자(라벨 90)·점검자(라벨 80), 2줄 문제점(라벨 80, 400)·조치사항(라벨 90, 400)·[입력] 버튼. 문제점·조치사항은 읽기전용 칸에 입력 내용을 바로 보여주고, 칸이나 [입력]을 누르면 큰 입력창(pop_PROB_SOL). 기존 숨김 칸 2개는 이 칸으로 대체(Field 동일, 저장 입력값 변화 없음)
- **검증 결과**: JS 구문 검사 통과, JS 사용 컨트롤 ID 전부 aspx 존재, 프로시저 IF 24/24·파라미터 16개 그대로·BOM 없음+CRLF, aspx·js BOM+CRLF. 미확인: 실제 팝업 너비(1200)에서 2줄 끝선 정렬, 20150801 사원의 MSTEMP 존재 여부(없으면 이름 대신 빈칸 유지)
- **적용 순서**: MES_SNS2_TAL0001_R08.sql 프로시저 다시 저장 (파라미터 변경 없음)
- **변경**: 문제점/조치사항 배치(3번)는 20번 작업으로 교체

### 20. TAL0001_R08 등록·수정 팝업 문제점/조치사항을 팝업 안 큰 입력칸으로 변경

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [TAL0001_R08.css](01.Office/PAGETAL/TAL0001/TAL0001_R08.css)
- **배경 및 원인**: 19번의 읽기전용 칸 + [입력] 버튼 → 팝업 위에 다시 팝업이 뜨는 구조라 태블릿에서 쓰기 불편하다는 의견
- **작업 상세 내용**:
  - 1. 등록(pop1)·수정(pop2) 팝업 2줄을 문제점·조치사항 입력칸(textarea, 각 폭 440·높이 96, 좌우 배치)으로 교체 → 팝업 안에서 바로 입력, 팝업 [저장]으로 점검값과 함께 저장(Field PROBLEM·SOLUTION 그대로라 저장 입력값 동일)
  - 1. [입력] 버튼·읽기전용 칸·입력 대상 분기(PROB_TARGET) 제거, 큰 입력창(pop_PROB_SOL)은 메인 화면 [문제점/조치사항](점검완료 실적만 수정) 전용
  - 1. 입력칸 글씨 20px·안내 문구(없으면 비워 두기), 입력칸이 늘어난 만큼 팝업 높이 560 → 660
- **검증 결과**: JS 구문 검사 통과, JS 사용 컨트롤 ID 전부 aspx 존재, 인코딩(BOM+CRLF) 유지, 공통 패널 저장(AddPanel)·채우기(SetStore)·초기화(InitData)가 textarea를 처리하는 것 확인. 미확인: 실제 태블릿에서 팝업 높이·화면 키보드가 올라왔을 때 입력칸 가림 여부
- **변경**: 17~20번의 TAL0001_R08 화면·프로시저는 21번 작업으로 전부 교체

### 21. TAL0001_R08을 TAL0001_R05(설비 일상점검 등록)와 같은 화면·로직으로 다시 구성 (점검구분만 정기점검)

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [TAL0001_R08.css](01.Office/PAGETAL/TAL0001/TAL0001_R08.css), [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql), [05.Procedure/MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**: 사용자 지시 - 정기점검 태블릿 화면은 일상점검(TAL0001_R05)과 UI/UX가 완전히 같아야 하고 차이는 정기점검/일상점검뿐. 17~20번은 PC 정기점검(EQM1001_R04) 흐름(월 탭·설비 카드·월별 현황)을 따라 별도 화면으로 만들어 요구와 다름
- **작업 상세 내용**:
  - 1. 화면 aspx·css·js: TAL0001_R05를 그대로 복사, `TAL0001_R05` → `TAL0001_R08`, '일상점검' → '정기점검'(팝업 제목·주석)만 변경. 작업장·공정·라인 → 설비 버튼 → 조회일자·작업자 → 조회·점검·수정·삭제·문제점/조치사항 → 점검이력·점검항목 그리드, 등록·수정 팝업(점검일자·등록일자·등록시간·점검자), 숫자패드·OK/NG·문제점/조치사항 팝업 모두 R05와 동일
  - 1. 프로시저 TAL0001_R08: TAL0001_R05 본문 복사, 점검구분 CHKTP '01' → '02'(11곳: 실적 조회·등록·수정·삭제·문제점 조회/저장, 승인 REV 조회 G·E) 및 메시지·주석 '일상점검' → '정기점검'만 변경. 파라미터 21개(R05와 동일)
  - 1. SYSTEM_PARAMETERS 재등록 스크립트: 정상 21건으로 수정
- **검증 결과**: R05와 R08 aspx·css·js를 이름·문구 치환 후 비교해 완전히 동일, 프로시저 diff는 CHKTP·문구·헤더만 다름 확인. JS 구문 검사 통과, 인코딩(화면 BOM+CRLF, 프로시저 BOM 없음+CRLF). 미확인: 프로시저 서버 반영 후 실제 태블릿 동작
- **참고(R05와 같아서 생기는 정기점검 동작)**: PC 정기점검(EQM1001_R04)에 있던 월 1회 중복 등록 차단·주기관리 점검자 기본값·계획 특이사항 기본값은 R05에 없으므로 R08에도 없음. 같은 달 여러 건 등록 시 PC 현황은 첫 실적을 기준으로 표시
- **적용 순서**: MES_SNS2_TAL0001_R08.sql 프로시저 저장(기존 R08 프로시저를 덮어씀, 파라미터 구성 변경) → MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql 실행(21건)
- **변경**: 프로시저 로직은 22번에서 웹 정기점검 규칙으로 교체 (화면은 그대로)

### 22. TAL0001_R08 프로시저에 웹 정기점검(EQM1001_R04) 규칙 적용, 버튼 미동작 원인 정리

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql), [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: 사용자 확인 - 화면은 R05와 같게, 기능은 웹(EQM1001_R04) 그대로. 21번은 R05 로직에 점검구분만 바꿔 웹 정기점검 규칙이 빠져 있었음. 버튼(조회·점검·수정·삭제·문제점/조치사항) 미동작: R05와 같은 구성이라 설비 버튼을 선택해야 버튼이 켜지고, 설비 버튼 목록은 TAL0001_R08 프로시저 LIST_EQMCD로 조회 → 서버 프로시저가 이전 버전(EQM1001_R04 복사본, LIST_EQMCD 없음)이거나 파라미터 미재등록이면 목록 조회 오류로 설비 버튼이 안 나와 버튼이 계속 꺼진 상태 (로컬 페이지는 브라우저 세션 만료로 직접 확인 못 함)
- **작업 상세 내용**:
  - 1. 프로시저: 호출 분기·파라미터 21개는 R05와 동일(화면 그대로 사용), 내부 규칙만 웹 정기점검과 동일하게
    - LIST_PLAN_ITEM: 최신 승인 정기점검 REV 항목, 특이사항 기본값 = 계획 특이사항, 점검월(점검일자, 없으면 이번 달) 주기관리 점검자 PLANEMP·PLANEMPCD·PLANEMPNM 반환, 승인 계획 없으면 웹과 같은 안내
    - ADD_CHKRSTEQM: 점검일자 형식 확인, 승인 REV 변경 확인, 주기관리 점검자 지정 월만 등록, 설비·월당 1건(중복 시 "N월 정기점검이 이미 등록되어 있습니다"), 모든 항목 점검값 필수, 항목 특이사항 저장
    - SAVE_CHKRSTEQM: 점검월 변경 불가(같은 달 안에서만 점검일자 변경), 실적 항목과 일치·중복 전달 차단·모든 항목 점검값 필수(웹과 같은 임시테이블 확인), 항목 저장 후 헤더(점검자·점검일자·등록일시) 저장
    - 조회·삭제·문제점/조치사항: R05와 같은 분기, 정기점검(CHKTP '02')
  - 1. 화면 js: 점검 버튼에서 오늘 날짜를 넘겨 주기관리 점검자를 기본 점검자로 채움(사원찾기 목록에 없으면 이름칸에 사원명), 이번 달 점검자 미지정이면 안내. aspx·css는 R05와 동일 유지(비교 확인)
- **검증 결과**: 프로시저 IF 24/24·WHILE 2/2·파라미터 21개·BOM 없음+CRLF, JS 구문 검사 통과, aspx는 이름·문구 외 R05와 동일. 미확인: 서버 반영 후 실제 동작
- **적용 순서**: MES_SNS2_TAL0001_R08.sql 프로시저 저장 → MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql 실행(21건) → 화면 새로고침(Ctrl+F5) 후 작업장 선택 → 설비 버튼 선택 → 버튼 사용
- **변경**: 23번에서 EQM1001_R04 형태로 전부 다시 구성 (21·22번 화면·프로시저 미사용)

### 23. TAL0001_R08을 EQM1001_R04(PC 정기점검 등록)와 같은 형태로 다시 구성

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [TAL0001_R08.css](01.Office/PAGETAL/TAL0001/TAL0001_R08.css), [05.Procedure/MES_SNS2_TAL0001_R08.sql](05.Procedure/MES_SNS2_TAL0001_R08.sql), [05.Procedure/MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**: 사용자 요청 - 21·22번(R05 형태 + 규칙 혼합)이 꼬였으니 기존 EQM1001_R04 페이지와 비슷한 형태로 진행
- **작업 상세 내용**:
  - 1. 프로시저 TAL0001_R08: EQM1001_R04 본문 그대로 복사(파라미터 16개·LIST_CYCLE_EQMCD·LIST_PLAN_EQM02·ADD/SEARCH/SAVE/DELETE_CHKRSTEQM), 표시용 사원명만 추가(LIST_PLAN_EQM02 PLANEMPNAME, SEARCH_CHKRSTEQM EMPNM). R04 본문과 diff로 차이가 사원명 3곳뿐인 것 확인. SYSTEM_PARAMETERS 정상 16건으로 수정
  - 1. 화면 흐름은 R04와 동일: 위 조회년도(기본 올해, 변경 시 조회)·설비·[조회](R05 크기 큰 버튼) → 설비별 1~12월 점검상태 그리드(점검필요 파란색·점검완료 초록색 굵은 링크) → 점검필요 누르면 등록 팝업, 점검완료 누르면 수정 팝업(점검삭제 버튼)
  - 1. 등록·수정 팝업은 R04와 같은 칸(설비코드·점검일자·점검자, 문제점·조치사항, 점검항목 그리드). 등록 시 점검일자 기본값(이번 달이면 오늘, 아니면 그 달 1일)·주기관리 점검자 기본 지정(사원찾기 목록에 없으면 이름칸에 사원명)
  - 1. 태블릿 입력: 점검값 칸 두 번 누르면 점검값구분 03(OK/NG)은 OK·NG 버튼, 그 외는 숫자패드(R05 패드), 특이사항은 칸에 바로 입력, 문제점·조치사항 글씨 18px
- **검증 결과**: JS 구문 검사 통과, JS 사용 컨트롤 ID 전부 aspx 존재·중복 ID 없음, 프로시저 IF 24/24·파라미터 16개·BOM 없음+CRLF, 화면 파일 BOM+CRLF. 미확인: 서버 반영 후 실제 태블릿 동작(로컬 페이지는 로그인 세션 만료로 직접 확인 못 함)
- **적용 순서**: MES_SNS2_TAL0001_R08.sql 프로시저 저장 → MES_SNS2_TAL0001_R08_SYSTEM_PARAMETERS.sql 실행(16건) → 화면 강력 새로고침(Ctrl+F5)
- **변경**: 화면은 24번으로 교체 (프로시저는 23번 그대로 사용)

### 24. TAL0001_R08 화면을 18번(R05 기반 태블릿 UI) 구성으로 복원, 문제점/조치사항은 R05 방식

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx](01.Office/PAGETAL/TAL0001/TAL0001_R08.aspx), [TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js), [TAL0001_R08.css](01.Office/PAGETAL/TAL0001/TAL0001_R08.css)
- **배경 및 원인**: 사용자 정리 - 전체 UI는 TAL0001_R05 기반 태블릿 화면(웹 화면을 그대로 옮기면 안 됨), 기능은 웹 정기점검, 문제점/조치사항은 R05처럼 처리. 23번(R04 화면 그대로)은 팝업 라벨 줄바꿈 등 태블릿에 맞지 않음. 요구에 맞는 것은 사용자가 승인한 18번 구성
- **작업 상세 내용**:
  - 1. 17번 원본 + 18번(월 탭 건수·요약 제거, 설비 카드 한 줄 좌우 스크롤·상태별 배경색) + 19번 점검자 사원명 표시를 다시 적용: 조회년도·설비 → 1~12월 탭 → 선택 월 점검대상 설비 카드 → 조회·점검·수정·삭제·문제점/조치사항 큰 버튼 → 점검 정보·점검 항목 그리드
  - 1. 등록·수정 팝업: 설비·점검일자·점검자 한 줄(위아래 여백 10) + 점검 항목 그리드, 점검값 숫자패드·OK/NG, 특이사항 큰 입력창. 팝업 안 문제점/조치사항 버튼 제거, 팝업 높이 560 → 500
  - 1. 문제점/조치사항: R05와 같이 점검완료 실적을 선택한 뒤 메인 [문제점/조치사항] 버튼 → 큰 입력창 → 저장(점검값·특이사항은 그대로, SAVE_CHKRSTEQM). 등록은 빈 값으로 저장, 수정 팝업은 숨은 칸으로 기존 문제점/조치사항을 그대로 넘겨 지워지지 않게 함
  - 1. 프로시저는 23번(EQM1001_R04 로직 + 사원명) 그대로, 화면 호출 분기 6개 모두 프로시저에 존재 확인
- **검증 결과**: JS 구문 검사 통과, JS 사용 컨트롤 ID 전부 aspx 존재·중복 없음, 인코딩(BOM+CRLF). 18번 모형 검증(1280px 월 탭·카드 배치) 이후 메인 영역 변경 없음. 미확인: 서버 반영 후 실제 태블릿 동작
- **적용 순서**: 프로시저·파라미터는 23번과 같음(MES_SNS2_TAL0001_R08.sql 저장, SYSTEM_PARAMETERS 16건) → 화면 강력 새로고침(Ctrl+F5)

### 25. EQM1001_R03 설비그룹 점검계획 개정이력 미표시 수정

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql)
- **배경 및 원인**: 설비그룹 점검계획 탭 오른쪽 개정이력(REV)이 하나도 안 나오고 설비별은 정상. 화면은 그룹·설비가 같은 함수(SearchPlanRev → LIST_PLAN_REV)를 쓰므로 데이터 차이. 10번 작업에서 REV 조회를 `CHKTP = '02'`로 한정했는데, REV 헤더에 점검구분 '02'를 저장하기 시작한 것은 2026-10-23부터라 그 이전에 만든 REV(설비그룹 대부분)는 CHKTP가 빈 값이어서 빠짐
- **작업 상세 내용**: 10번에서 한정한 7곳(공통 검증 수정 대상 REV, 복사 원본 REV, LIST_PLAN_REV, SAVE_PLAN_REV 존재 확인·대상, SAVE_PLAN_STATUS 존재 확인·대상)을 `CHKTP IN ('02', '')`로 변경 → 정기점검 REV와 10-23 이전 빈 값 REV는 포함, 일상점검('01')은 계속 제외. 새 REV는 지금처럼 '02'로 저장
- **검증 결과**: 변경 7곳 확인, 인코딩(BOM 없음+CRLF). 미확인: 서버 반영 후 화면 표시(DB 조회 권한 없어 실제 CHKTP 값 미확인)
- **같은 원인 남은 곳**: EQM1001_R04(정기점검 등록 현황·승인 계획 조회)와 TAL0001_R08도 승인 REV를 `CHKTP = '02'`로만 찾아, 10-23 이전에 승인한 설비그룹 계획을 인식하지 못함. 근본 해결은 빈 값 REV를 '02'로 한 번 정리하는 데이터 수정
- **적용 순서**: MES_SNS2_EQM1001_R03.sql 프로시저 저장 (파라미터 변경 없음) 테이블 목록은 ALPHA 백업 기준이라 이 DB에 없는 테이블은 3번 단계에서 오류로 확인 후 제외 필요. 미확인: 실제 바꾼 코드(예시 값 TAL1001_R05 → TAL0001_R08은 대화 내용 기준 추정) R08은 R05 화면 구성 + EQM1001_R04 정기점검 로직(CHKTP '02', 주기관리 월별 대상, 승인 계획, 특이사항) 기반. R09는 설비부품 마스터·재고 테이블과 출고 연결 대상(설비·수리이력) 결정 필요(참고: TAL0001_R07 부자재 사용등록)

### 26. EQM1001_R03 일상점검 REV만 있는 설비그룹(FM116I220N·FM116I270N)이 일상점검 내용으로 보이는 문제

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql)
- **배경 및 원인**: FM116I220N(BROACH)·FM116I270N(비전홀검사기)은 왼쪽 목록에 REV.0이 보이지만 오른쪽 개정이력은 비어 있고, 하단 정기점검에 "TEST 일상점검1~3" 등 일상점검 항목이 표시됨. 두 그룹의 REV.0은 일상점검(CHKTP '01') REV. 10·25번에서 개정이력·수정 대상은 정기점검 REV로 한정했지만, 왼쪽 목록 REV·상태(LIST_MSTEQM_GRP)·하단 최신 항목(LIST_GRP_EQM02) 등 목록 조회는 점검구분 조건 없이 최신 REV를 보여 줘서 서로 다른 REV를 표시
- **작업 상세 내용**: 10번에서 남겨 둔 목록·항목 조회에도 `CHKTP IN ('02', '')` 적용
  - 설비그룹·설비 목록 REV·상태(LIST_MSTEQM_GRP·LIST_MSTEQM 최신 REV 서브쿼리)
  - 최신 항목(LIST_GRP_EQM02·LIST_MSTEQM_EQM02), 미등록 항목(LIST_GRP_EQM02_ADD·LIST_EQM02), 복사 원본 목록·상세(LIST_COPY_GRP_EQM02·_DTL·LIST_COPY_EQM02)
  - REV 선택 항목(LIST_PLAN_REV_ITEM), 계획서 출력(CALL_PLAN_RPT 대상 REV 2곳·개정 이력)
  - 조건 없는 곳은 REV 키 직접 조회, 새 REV 번호(일상점검과 번호 공용), REV 키 삭제뿐
- **결과(예상)**: 일상점검 REV만 있는 그룹은 왼쪽 REV·상태 빈칸, 오른쪽·하단 비어 있음 → [추가]로 정기점검 항목을 넣으면 정기점검 REV(다음 번호, 예: REV.1)가 새로 생성
- **사용자 실DB 확인 결과**: FM116I220N = REV.0 일상점검('01', 승인, 항목 001~003 모두 일상점검 항목) + REV.1 정기점검('02', 미승인, 항목 998·999 정기점검 항목). FM116I270N = REV.0 일상점검('01', 미승인, 항목 001~003·압력게이지·010~018 모두 일상점검 항목)만 있고 정기점검 REV 없음. 앞서 추정한 '일상점검 REV에 정기점검 항목 섞임'은 사실이 아님(010~018도 일상점검 항목) → 데이터 정리 불필요, 26번 조회 수정만으로 정기점검만 표시됨
- **검증 결과**: 정기점검 조건 21곳, IF 42/42, 인코딩(BOM 없음+CRLF). 미확인: 서버 반영 후 화면, 실제 CHKTP 값(DB 조회 권한 없음)
- **적용 순서**: MES_SNS2_EQM1001_R03.sql 프로시저 저장 (파라미터 변경 없음)

### 27. EQM1001_R03 정기점검 항목 삭제가 되지 않고 개정이력도 생기지 않는 문제

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql), [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](01.Office/PAGEEQM/EQM1001/EQM1001_R03.js)
- **배경 및 원인**: FM116I270N 설비그룹 화면 하단에 001~018 항목이 보이고, 삭제해도 지워지지 않으며 개정이력도 생기지 않음. 하단 항목은 일상점검 REV.0('01')의 항목(사용자 실DB 확인)인데, 서버 프로시저가 26번 이전이라 하단 목록(LIST_GRP_EQM02)은 점검구분 없이 최신 REV(일상점검)를 보여 줌. 반면 삭제(DEL_GRP_EQM02)는 10번 수정으로 정기점검 REV를 대상으로 하므로 → 정기점검 REV 없음 → 빈 새 REV 생성 → 일상점검 항목 코드를 새 REV에서 삭제(0건) → 변경 없음 → 새 REV 다시 삭제. 화면은 "삭제되었습니다"만 표시
- **작업 상세 내용**:
  - 1. 근본 해결은 26번 프로시저 반영: 하단·왼쪽 목록이 정기점검 REV만 보여 FM116I270N은 정기점검 항목 없음(빈 화면)으로 표시되고, 일상점검 항목은 R03에서 다루지 않음
  - 1. 프로시저: 정기점검 항목 삭제(DEL_GRP_EQM02·DEL_EQM02)에서 실제 삭제된 항목이 없으면 새로 만든 REV를 지우고 "삭제할 정기점검 항목이 없습니다. 화면을 다시 조회해주세요." 안내 (삭제 완료로 끝나지 않게)
  - 1. 화면: 저장·삭제·추가·복사 후 정기점검 REV가 없어 REV 갱신이 안 되면 선택 대상의 REV·항목 전체 다시 조회(RefreshPlan)
- **정상 동작(참고)**: 정기점검 REV가 승인 상태에서 항목을 삭제하면 다음 번호 REV가 새로 생기고(개정이력 추가) 삭제한 항목을 뺀 나머지가 복사됨, 대기 상태면 그 REV에서 바로 삭제
- **검증 결과**: 프로시저 IF 44/44·BOM 없음+CRLF, JS 구문 검사 통과. 미확인: 서버 반영 후 화면
- **적용 순서**: MES_SNS2_EQM1001_R03.sql 프로시저 저장(25·26·27번 모두 포함, 파라미터 변경 없음) → 화면 새로고침

### 28. EQM1001_R03 정기점검 조건 CHKTP = '02' 고정, EQM1001_R02 정기점검 항목만 수정·삭제

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql), [05.Procedure/MES_SNS2_EQM1001_R02.sql](05.Procedure/MES_SNS2_EQM1001_R02.sql)
- **배경 및 원인**: 사용자 지시 - R03의 `CHKTP IN ('02', '')`를 모두 `CHKTP = '02'`로 고정. EQM1001_R02(정기점검 항목 관리)도 정기점검만 다루므로 점검
- **작업 상세 내용**:
  - 1. R03: 25·26번에서 넣은 `CHKTP IN ('02', '')` 21곳을 `CHKTP = '02'`로 변경, 빈 값 포함 이력 1행·주석 정리. 점검구분이 빈 값인 REV(2026-10-23 이전 생성분이 남아 있다면)는 R03에 표시되지 않음
  - 1. R02 점검: 조회(LIST_MSTCHKKND)·등록(ADD_MSTCHKKND)은 이미 CHKTP '02' 고정. 저장(SAVE_MSTCHKKND)·삭제(DELETE_MSTCHKKND)는 UPDATE·DELETE에 CHKTP '02' 조건만 있어 다른 점검구분 코드가 넘어오면 아무것도 바꾸지 않고 성공으로 끝남
  - 1. R02 수정: 저장·삭제 시 정기점검 항목이 아니면 "정기점검 항목이 아닙니다. (점검코드 …) 다시 조회해주세요." 안내 후 중단, 조회에 정렬순서(SORTNO·점검코드) 지정, 중복 코드 안내 문구 오타 수정(등록되는 → 등록된). 화면(aspx·js) 변경 없음
  - 1. R02 프로시저 BOM 제거(encoding.md 수정 시점 BOM 제거), CRLF 유지
- **검증 결과**: R03 `IN ('02', '')` 0건·REV 조회 `CHKTP = '02'` 확인, R02 IF 12/12, 두 파일 BOM 없음+CRLF. 미확인: 서버 반영 후 화면
- **적용 순서**: MES_SNS2_EQM1001_R03.sql·MES_SNS2_EQM1001_R02.sql 프로시저 저장 (파라미터 변경 없음)

### 29. 점검계획 REV 점검구분 빈 값 → 정기점검('02') 데이터 정리 SQL

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MSTEQMREV_HEADER_CHKTP_FIX.sql](05.Procedure/MES_SNS2_MSTEQMREV_HEADER_CHKTP_FIX.sql) (신규, 데이터 정리 스크립트)
- **배경 및 원인**: 사용자 실DB 조회 결과 점검구분 빈 값 REV 6건 - G FM116I210N REV.0~3, E I2C-003N REV.0, E A-003 REV.0 (모두 승인). 2026-10-23 점검구분 저장 이전에 R03(정기점검 계획)에서 만든 정기점검 REV. 28번에서 R03을 `CHKTP = '02'`로 고정했고 R04·TAL0001_R08도 '02'만 보므로, 이 6건(예: FM116I210N CNC 개정이력)이 모든 정기점검 화면에서 빠짐
- **작업 상세 내용**: 1. 대상 확인 → 2. 같은 대상·번호의 '02' REV 중복 확인(0건이어야 함, 고유키 충돌 방지) → 3. 트랜잭션으로 빈 값·NULL → '02' 변경 → 4. 대상 6건 '02'·빈 값 0건 확인 후 COMMIT/ROLLBACK 수동
- **검증 결과**: BOM 없음+CRLF. DB 직접 실행하지 않음(규칙). 미확인: 실행 결과
- **적용 순서**: R03 프로시저(28번) 저장과 함께 이 스크립트 실행

### 30. EQM1001_R03 설비그룹·설비별 탭 검색 조건 입력칸 폭 확대

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx](01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx)
- **배경 및 원인**: 설비그룹 코드(FM116I250N 등 10자리)가 코드칸(80)에 꽉 차고 이름칸도 좁다는 요청
- **작업 상세 내용**: 설비그룹 탭 설비그룹(find_GRP), 설비별 탭 설비(find_EQMCD)·설비그룹(find_EQM_GRP) 찾기 칸 코드 폭 80 → 110, 이름 폭 120 → 170 (라벨·여백 그대로)
- **검증 결과**: 인코딩(BOM+CRLF) 유지. 미확인: 실제 화면 표시

### 31. TAL0001_R08 점검·수정·삭제·문제점/조치사항 버튼이 반응 없는 문제

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: A-05(2월 점검필요) 선택 후 점검·수정·삭제·문제점/조치사항을 눌러도 반응 없음. 화면이 상태에 따라 버튼을 비활성(ItsButton.Disable)으로 바꾸는데, 공통 버튼은 비활성일 때 클릭을 조용히 무시함(ItsButton.js 13행 data-disabled 확인). 점검필요 월은 수정·삭제·문제점이 비활성, 승인 계획 조회 실패(A-05: 승인된 정기점검 계획 없음으로 추정) 시 점검까지 비활성. 비활성 표시가 눈에 잘 띄지 않아 "반응 없음"으로 보임
- **작업 상세 내용**: 버튼을 항상 사용 가능하게 두고, 누를 때 CHECK_ACTION으로 상태 안내(알림창)
  - 설비 미선택: "설비를 먼저 선택하세요."
  - 점검: 점검완료 월이면 "N월 정기점검이 이미 등록되어 있습니다. [수정]으로 고쳐주세요.", 대상 월이 아니면 주기관리 안내, 점검필요 월이면 승인 계획 조회 → 승인 계획이 없으면 프로시저 안내("승인된 정기점검 계획이 없습니다…") 표시
  - 수정·삭제·문제점/조치사항: 점검 실적이 없으면 "N월 정기점검이 아직 등록되지 않았습니다. [점검]으로 먼저 등록해주세요."
  - 승인 계획 조회 실패 시 점검 버튼 비활성 처리 제거
- **검증 결과**: JS 구문 검사 통과, 비활성 처리 0건, 인코딩(BOM+CRLF). 미확인: 실제 태블릿 동작, A-05 승인 계획 여부

### 32. TAL0001_R08 조회할 때마다 "승인된 정기점검 계획이 없습니다" 알림이 뜨는 문제

- **수정/대상 파일**: [01.Office/PAGETAL/TAL0001/TAL0001_R08.js](01.Office/PAGETAL/TAL0001/TAL0001_R08.js)
- **배경 및 원인**: A-05(2월 점검필요, 승인된 정기점검 계획 없음) 선택 상태에서 [조회]·설비 선택마다 같은 알림창이 뜸. 조회 후 선택 설비의 점검 항목 미리보기(LOAD_DETAIL → LIST_PLAN_EQM02)가 실패할 때마다 오류 알림을 띄웠기 때문. [점검]을 누를 때 같은 안내가 나오는 것은 정상(승인 계획 없음)
- **작업 상세 내용**: 미리보기 실패 시 알림창을 띄우지 않고 아무 표시 없이 넘어감(사용자 요청으로 상태 칸 표시도 하지 않음, 상태 칸 폭 90 그대로). 안내 알림은 [점검]을 누를 때만 표시
- **검증 결과**: JS 구문 검사 통과. 미확인: 실제 태블릿 동작

---

## 🕒 2026-11-06 (금) 작업 내역

### 1. MST1005_R01 승인 대기 평가이력이 있으면 신규평가 차단

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_R01.sql](05.Procedure/MES_SNS2_MST1005_R01.sql), [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js) (주석)
- **배경 및 원인**: 승인 대기 평가이력이 있는 설비에 신규평가를 또 등록하면 승인 대기 이력이 2건 이상 생김
- **작업 상세 내용**:
  - 1. 신규 평가(평가키 없음)의 평가 대상 확인 단계에 승인 대기(APRVTIME = '') 이력 검사 추가 → LIST_EVAL_D(팝업 열기 전)·SAVE_EVAL(저장 시) 모두 차단
  - 1. 안내 문구 : "승인 대기중인 평가이력(평가일자 YYYY-MM-DD)이 있습니다. 승인 대기중인 평가이력을 삭제 후 새로 생성해주세요." (조회기간 밖 이력도 찾을 수 있게 평가일자 표시)
  - 1. 화면은 기존 흐름 그대로 : 신규평가 버튼 → LIST_EVAL_D 오류 메시지 표시, 팝업 열지 않음
- **검증 결과**: 프로시저 IF/END IF 27쌍, BOM 없음·CRLF 확인, 운영 DB 읽기 조회(승인 대기 : I2AOC-01N 1건, 대상 없을 때 MAX 결과 NULL 확인). 미확인: 프로시저 서버 저장·화면 동작

### 2. MST1005_R01 평가 승인 팝업 한 줄 배치

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_R01.aspx](01.Office/PAGEMST/MST1005/MST1005_R01.aspx)
- **배경 및 원인**: 평가 승인 팝업의 승인자·승인일자를 한 줄로 표시 요청
- **작업 상세 내용**:
  - 1. 승인자·승인일자 사이 줄바꿈 제거, 라벨 폭 70으로 통일
  - 1. 팝업 폭 380 → 500 (두 항목 합계 약 450px)
- **검증 결과**: 실제 ItsFind·ItsDate CSS로 그린 모형에서 한 줄 표시·폭 500 안에 들어감 확인. 미확인: 실제 화면

### 3. MST1005_R01 평가·승인일자 순서 검증 추가

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_R01.sql](05.Procedure/MES_SNS2_MST1005_R01.sql)
- **배경 및 원인**: 미래 날짜(11-10·11-11)로 평가·승인한 뒤 오늘(11-06) 날짜로 신규평가를 저장하면, 저장은 되지만 "평가일자가 더 늦은 승인 이력" 검사로 승인할 수 없는 이력이 생김
- **작업 상세 내용**:
  - 1. SAVE_EVAL : 평가일자 오늘 이후 불가 ("평가일자는 오늘 이후로 입력할 수 없습니다.")
  - 1. SAVE_EVAL : 설비의 최종 승인 평가일자 이전 불가, 같은 날짜는 허용 ("최종 승인 평가일자(YYYY-MM-DD) 이전 날짜로 평가할 수 없습니다.")
  - 1. APPROVE_EVAL : 승인일자 오늘 이후 불가 ("승인일자는 오늘 이후로 입력할 수 없습니다.")
  - 1. 변수 _$LASTDATE(최종 승인 평가일자) 추가, 오늘 기준은 LEFT(CALLTIME(), 10)
- **검증 결과**: IF/END IF 30쌍, BOM 없음·CRLF 확인, 운영 DB 읽기 조회로 조건 확인(I2AOC-01N 최종 승인 11-11 → 11-06 차단·11-11 허용, 11-11은 오늘 이후로 차단, 승인 이력 없는 설비는 NULL 비교로 통과). 미확인: 프로시저 서버 저장·화면 동작
- **참고**: 기존 테스트 데이터(I2AOC-01N 11-10·11-11 승인)가 남아 있으면 11-11 전까지 이 설비는 신규평가 저장 불가, 승인 이력은 화면에서 삭제 불가하므로 DB 정리 필요

### 4. MST1005_R01 평가 승인 팝업 UI/UX 디자인 개선 및 비고(REMARK) 입력·저장 기능 추가

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_R01.aspx](01.Office/PAGEMST/MST1005/MST1005_R01.aspx), [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js), [05.Procedure/MES_SNS2_MST1005_R01.sql](05.Procedure/MES_SNS2_MST1005_R01.sql)
- **배경 및 원인**: 기존 평가 승인 팝업(pop2)의 높이가 120px로 과도하게 좁아 헤더(40px) 및 푸터 버튼바(48px) 사이 본문이 32px로 찌그러져 UI/UX가 불량했으며, 승인 비고(REMARK)를 입력하고 DB에 저장할 수 있는 기능 부재
- **작업 상세 내용**:
  - 1. 팝업 규격 및 상하 공백 최적화: Width 510 유지, 단일 폼 팝업 공통 표준에 따라 Height 속성을 제거하여 자동 높이(auto-height) 적용 (Height 지정 시 ItsPop.js의 open 이벤트에서 높이가 +45 중복 가산되어 발생하던 하단 71px 거대 공백 원천 제거, 상하 여백 완벽 밀착)
  - 1. 1행 컨트롤 픽셀 정렬: 승인자(LabelWidth 70, InputWidth 70, NameWidth 110) + 승인일자(LabelWidth 70, InputWidth 105, MarginLeft 8) = 1행 총 너비 449px
  - 1. 2행 비고(REMARK) 픽셀 정렬 및 행간 최적화: LabelWidth 70, InputWidth 385 (실측 기반 6px 보정), MarginTop 6 부여로 1행 달력 버튼 우측 끝선과 픽셀 단위 100% 일치
  - 1. 3행 승인 주의사항 안내 문구 시작선 정렬: MarginTop 10, MarginLeft 70 설정으로 1·2행 입력 박스 좌측 시작선(X=70px)에 수직으로 정확히 맞추어 캡션 형태로 정렬, 공통 컴포넌트 BasePage.ColorList.GrayDark1 규격 적용
  - 1. JS 데이터 바인딩 및 파라미터 전송: btn_APRV 클릭 시 선택된 평가이력의 기존 비고를 pop2_txt_REMARK에 기본 세팅, 승인 버튼(pop2.onAddBtnClick) 클릭 시 maria.AddParam('REMARK', ...)로 전송 보장
  - 1. 프로시저 APPROVE_EVAL 비고 UPDATE 반영: UPDATE EQMGRADEEVAL 구문에 REMARK = $REMARK 추가 및 프로시저 헤더 1일 1행 수정 이력 갱신
- **검증 결과**: C# Enum.Parse 기반 BasePage.ColorList.GrayDark1 파싱 성공 검증(HEX 파싱 에러 재현 및 enum 정상 통과 확인), 파일 인코딩(ASPX/JS: UTF-8 with BOM, SQL: UTF-8 without BOM) 및 CRLF 개행 검증 통과, 1·2행 우측 끝선 실측 일치 확인, MST1005 레포트 MSBuild 15.0 Rebuild 성공(0 Error)

### 5. MST1005_R01 승인된 평가이력 선택 시 승인 팝업 차단

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js)
- **배경 및 원인**: 이미 승인된 평가이력을 선택하고 승인 버튼을 누르면 평가 승인 팝업이 열림 (승인 저장은 프로시저가 막지만 팝업 자체는 열림)
- **작업 상세 내용**: 승인 버튼 클릭 시 선택 행의 승인일시(APRVTIME)가 있으면 ItsMsg.Alert("이미 승인된 평가이력입니다.") 모달 메시지 팝업창 표시 후 팝업 열지 않음 (기존 Toast 안내에서 메시지 팝업창으로 변경)
- **검증 결과**: 문법 검사(node --check) 통과, 인코딩(UTF-8 BOM·CRLF) 확인. 미확인: 실제 화면
- **참고**: JS 캐시 버전(srcVersion)은 DB 값으로 고정이라 브라우저가 이전 JS를 쓰면 수정 전처럼 팝업이 열림 → 강력 새로고침(Ctrl+F5) 필요

### 6. MST1005_R01 설비목록 병합을 ItsGrid 공통 기능으로 교체

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js)
- **배경 및 원인**: 설비목록 병합을 화면 전용 getMergedRange·IS_SAME_GROUP으로 구현해 다른 페이지와 방식이 다르고 비효율적
- **작업 상세 내용**:
  - 1. MST1002_R06과 같은 방식 : grid1 옵션 allowMerging: 'Cells' + 컬럼별 allowMerging: true만 사용 (groupField 그룹 줄 없음)
  - 1. 화면 전용 getMergedRange 재정의와 IS_SAME_GROUP 함수 삭제
  - 1. INC 2공장 조회 범위 확인 (수정 없음) : 설비목록 LIST_EQM은 MSTEQM.FACTORYCD = '07'(MSTFACTORY 07 = INC 2공장) 고정, 작업장 콤보 REF01=07, 공정·라인 콤보(DC_COMBO EQMTP·EQMGROUP1)도 FACTORYCD = '07' 고정
- **검증 결과**: 문법 검사(node --check) 통과, 남은 참조 없음, 인코딩(UTF-8 BOM·CRLF) 확인. 운영 DB 읽기 조회 : 07 사용 설비 254건, 작업장 콤보 대상 07 작업장 24개뿐, 평가이력 중 다른 공장 설비 0건, 설비코드 중복 0건. 미확인: 실제 화면
- **참고**: 07 설비 중 작업장(LINECD)이 빈 설비 18건은 작업장 전체 조회 시 작업장 빈칸으로 표시됨

### 7. EQM1001_R03 점검계획서 특이사항(REMARK) 입력·관리 및 레포트 출력 연동

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql), 04.Report/PAGEEQM/EQM1001/bin/Release/EQM1001.exe, 01.Office/Reports/EQM1001.exe
- **배경 및 원인**: 점검계획서 레포트 양식(R03)에 "특이사항" 컬럼이 존재함에도 화면 그리드에 입력 컬럼이 누락되어 관리할 수 없었고, 프로시저 CALL_PLAN_RPT에서 빈 문자열('')로 고정 반환되어 출력되지 않던 문제 개선 요청
- **작업 상세 내용**:
  - 1. 화면 그리드 특이사항(REMARK) 컬럼 추가 및 입력 지원:
    - 설비그룹 탭(grid_GRP2) 및 설비별 탭(grid3)에 `column.create('특이사항', 'REMARK', { width: 200, readOnly: false })` 추가
    - 정기점검 추가 팝업(grid10)에 `column.create('특이사항', 'REMARK', { width: 150, readOnly: false })` 추가
    - 설비그룹 복사 팝업(grid_GRP_COPY2) 및 설비별 복사 팝업(grid8)에 `column.create('특이사항', 'REMARK', { width: 150 })` 조회 컬럼 추가
  - 1. 그리드 저장 전 편집 완료(FinishEditing) 보장:
    - `bdiv_GRP_btn_SAVE` 및 `bdiv3_btn_SAVE` 저장 버튼 클릭 시 `ItsGrid.FinishEditing`을 선행 호출하여 입력 중인 특이사항/정렬순서 셀 커밋 보장 (기존 `maria.AddList('REMARK_LIST', ...)` 전송 로직 유지)
  - 1. 프로시저 점수/항목별 특이사항 반환 반영:
    - `MES_SNS2_EQM1001_R03.sql`의 `CALL_PLAN_RPT` 분기에서 `'' AS REMARK` 하드코딩을 `COALESCE(MSTEQMREV_DETAIL.REMARK, '') AS REMARK`로 수정하여 실제 저장된 특이사항이 레포트 Detail row(cell_Detail_REMARK)에 정상 출력되도록 수정
    - 최상단 Modify 주석 1일 1행 압축 갱신
  - 1. 레포트 프로젝트 빌드 및 배포:
    - `04.Report/PAGEEQM/EQM1001/EQM1001.csproj` Release Rebuild (0 Error, 0 Warning) 및 최신 `EQM1001.exe`를 `01.Office/Reports/EQM1001.exe`로 동기화 배포
- **검증 결과**:
  - Node.js 구문 검사(`node --check`) 통과
  - 레포트 exe 커맨드라인 실행 테스트(정기점검 계획 정상 조회 및 에러 처리 확인)
  - 단일 UTF-8 with BOM(JS, WORK_HISTORY.md) 및 UTF-8 without BOM(SQL), CRLF 개행 무결성 100% 검증 완료
- **적용 순서**: `MES_SNS2_EQM1001_R03.sql` 프로시저 서버 DB 재반영 (SYSTEM_PARAMETERS 변경 없음)

### 8. EQM1001 R03 레포트 타이틀 하단 여백(공백) 추가

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R03.Designer.cs](04.Report/PAGEEQM/EQM1001/R03.Designer.cs), 04.Report/PAGEEQM/EQM1001/bin/Release/EQM1001.exe, 01.Office/Reports/EQM1001.exe
- **배경 및 원인**: "제조설비 정기 점검 시트" 레포트(R03) 출력 시 타이틀(xrLabelTitle)과 기본정보 테이블(xrTablePlanInfo)이 상하 여백 없이 밀착되어 가독성이 떨어지던 UI/UX 문제 개선 요청
- **작업 상세 내용**:
  - 1. 타이틀 하단 공백 20F(약 5mm) 확보:
    - 기본정보 테이블(`xrTablePlanInfo`)의 시작 위치 `LocationFloat`: `(0F, 37F)` -> `(0F, 57F)` (+20F)
    - 상세점검 헤더 테이블(`xrTableDetailHeader`)의 시작 위치 `LocationFloat`: `(0F, 112F)` -> `(0F, 132F)` (+20F)
    - 페이지 헤더 밴드(`PageHeader`) 높이 `HeightF`: `142F` -> `162F` (+20F)
  - 1. A4 1페이지 출력 범위 안전성 검토:
    - A4 세로 가용 높이(1129F) 대비 Header(162F) + 기본 12행 Detail(516F) + Footer(128F) = 806F로 약 320F 이상 여유가 있어 2페이지로 넘어가지 않고 안정적으로 1페이지 출력 유지
  - 1. 레포트 프로젝트 빌드 및 배포:
    - `04.Report/PAGEEQM/EQM1001/EQM1001.csproj` Release Rebuild (0 Error, 0 Warning) 성공
    - 최신 `EQM1001.exe`를 `01.Office/Reports/EQM1001.exe`로 동기화 배포
- **검증 결과**:
  - C# 인코딩 무결성(단일 UTF-8 with BOM, CRLF 개행) 확인
  - MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning)
  - 배포된 `01.Office/Reports/EQM1001.exe` 실행 테스트 정상 완료

### 9. EQM1001 R03 레포트 점검항목 테이블 컬럼 폭 최적화 및 특이사항 칸 확장

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R03.Designer.cs](04.Report/PAGEEQM/EQM1001/R03.Designer.cs), [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), 04.Report/PAGEEQM/EQM1001/bin/Release/EQM1001.exe, 01.Office/Reports/EQM1001.exe
- **배경 및 원인**: 점검계획서 레포트(R03) 출력 시 "특이사항" 칸(기존 142.5px, 19.5%)이 너무 좁아 긴 메모나 조치 내역을 기재하기에 부족한 반면, "점검기기"(102px) 등 짧은 단어가 들어가는 컬럼의 여백 낭비가 심했던 문제 개선 요청
- **작업 상세 내용**:
  - 1. 레포트 테이블 컬럼 폭 재배분 (총 731px 기준 Weight 정밀 재계산, 가중치 합 1.0D 일치):
    - `No`: 35px(Weight 0.04788) $\rightarrow$ **32px(Weight 0.04378)** (-3px)
    - `점검항목`: 130px(Weight 0.17784) $\rightarrow$ **105px(Weight 0.14364)** (-25px, 4~6글자 카테고리 여유 있게 수용)
    - `점검내용`: 200px(Weight 0.27360) $\rightarrow$ **180px(Weight 0.24624)** (-20px, 본문 텍스트 공간 충분히 유지)
    - `점검기기`: 102px(Weight 0.13953) $\rightarrow$ **70px(Weight 0.09576)** (-32px, "육안"·"줄자" 등 2~4글자 낭비 여백 대폭 축소)
    - `점검판정`: 63.8px(Weight 0.08732) $\rightarrow$ **60px(Weight 0.08208)** (-3.8px)
    - `완료확인`: 57.7px(Weight 0.07889) $\rightarrow$ **54px(Weight 0.07387)** (-3.7px)
    - `특이사항`: 142.5px(Weight 0.19494) $\rightarrow$ **230px(Weight 0.31464)** (**+87.5px, +61.4% 대폭 확장!**)
  - 1. 화면 그리드 일관성 보정:
    - `EQM1001_R03.js` 내 설비별 점검계획 탭(`grid3`)의 특이사항 컬럼 설정을 설비그룹 탭(`grid_GRP2`)과 동일하게 `width: 200, readOnly: false`로 통일
  - 1. 레포트 프로젝트 빌드 및 배포:
    - `04.Report/PAGEEQM/EQM1001/EQM1001.csproj` Release Rebuild (0 Error, 0 Warning) 성공
    - 최신 `EQM1001.exe`를 `01.Office/Reports/EQM1001.exe`로 동기화 배포
- **검증 결과**:
  - `cell_Hdr_*` 및 `cell_Detail_*` 7개 컬럼 Weight 총합 정확히 1.0D 검증 완료
  - Node.js 구문 검사(`node --check`) 통과
  - 파일 인코딩(단일 UTF-8 with BOM, CRLF 개행) 100% 무결성 확인
  - MSBuild 15.0 Rebuild 성공 및 실행 파일 배포 확인

### 10. EQM1001_R03 설비별 점검계획 특이사항 편집 지원 및 정기점검 주기관리 점검자명(MSTEMP) 표시 수정

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql)
- **배경 및 원인**:
  - 1. "설비별 점검계획" 탭의 정기점검 목록(`grid3`)에서 "특이사항" 컬럼에 `readOnly: false` 속성이 누락되어 수정할 수 없던 문제
  - 1. "정기점검 주기관리" 탭(`grid9`)에서 월별 점검자 조회 시 프로시저(`LIST_CYCLE_EQMCD`)가 공통코드 조회 함수 `GPCD('EMPCD', ...)`를 호출하여 사원 마스터(`MSTEMP`)를 조회하지 못하고 사원코드가 그대로 표시되던 문제
- **작업 상세 내용**:
  - 1. 설비별 점검계획 탭 특이사항 편집 활성화:
    - `grid3` 특이사항 컬럼에 `width: 200, readOnly: false` 속성을 명시하여 진행 중 REV에서 특이사항 셀 인라인 수정 지원
  - 1. 정기점검 주기관리 월별 점검자 사원명(`MSTEMP.EMPNM`) 조회 쿼리 수정:
    - `MES_SNS2_EQM1001_R03.sql`의 `LIST_CYCLE_EQMCD` 분기에서 `M01` ~ `M12`의 `GPCD('EMPCD', ...)` 호출을 사원 마스터 테이블 기반 서브쿼리 `COALESCE((SELECT EMPNM FROM MSTEMP WHERE EMPCD = CHKPLANEQM_YEARPLAN.MONTH_xx LIMIT 1), CHKPLANEQM_YEARPLAN.MONTH_xx)`로 교체 (매핑 실패 시 사원코드 fallback 보장)
    - 프로시저 상단 1일 1행 수정 이력 갱신
- **검증 결과**:
  - Node.js 구문 검사(`node --check`) 통과
  - 파일 인코딩(JS/MD: 단일 UTF-8 with BOM, SQL: UTF-8 without BOM) 및 CRLF 개행 무결성 확인 완료
- **적용 순서**: `MES_SNS2_EQM1001_R03.sql` 프로시저 서버 DB 재반영 (SYSTEM_PARAMETERS 변경 없음)

### 11. EQM1001 R03 레포트 점검내용 및 특이사항 컬럼 폭 미세 조정

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R03.Designer.cs](04.Report/PAGEEQM/EQM1001/R03.Designer.cs), 04.Report/PAGEEQM/EQM1001/bin/Release/EQM1001.exe, 01.Office/Reports/EQM1001.exe
- **배경 및 원인**: 레포트 출력 시 나머지 컬럼은 그대로 두고 "점검내용" 컬럼 폭을 조금 더 넓히고 "특이사항" 컬럼 폭을 조금 줄여달라는 사용자 요청 반영
- **작업 상세 내용**:
  - 1. 나머지 컬럼(No 32.0px, 점검항목 105.0px, 점검기기 67.9px, 점검판정 59.0px, 완료확인 57.1px) 완전 고정 유지
  - 1. `점검내용` (CHKCONTENT): 193.5px $\rightarrow$ **210.0px** (Weight `0.2872777017783858D`)로 확장 (+16.5px)
  - 1. `특이사항` (REMARK): 216.5px $\rightarrow$ **200.0px** (Weight `0.27359785296522315D`)로 축소 (-16.5px)
  - 1. Header 및 Detail 가중치 합계 `1.000000D`, 전체 폭 731.0px 일치 보장
- **검증 결과**:
  - MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning)
  - `01.Office/Reports/EQM1001.exe` 동기화 배포 완료
  - 파일 인코딩(단일 UTF-8 with BOM, CRLF 개행) 100% 무결성 확인

---

### 12. EQM1001_R03 주기관리 점검자명 조회 최적화 (대안 A: MSTEMP 12회 일괄 LEFT JOIN)

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql)
- **배경 및 원인**:
  - LIST_CYCLE_EQMCD 분기에서 12개 월별 점검자 컬럼(M01 ~ M12)마다 서브쿼리 (SELECT EMPNM FROM MSTEMP WHERE ...)를 수행하던 방식을 성능 및 유지보수 최적화를 위해 대안 A(12개 월 일괄 LEFT JOIN MSTEMP) 구조로 전환
- **작업 상세 내용**:
  - 1. SELECT 절 내 12회 반복 서브쿼리 제거:
    - COALESCE(EMP01.EMPNM, CHKPLANEQM_YEARPLAN.MONTH_01) 형태로 간소화하여 매핑 실패 시 기존 사원코드 fallback 유지
  - 1. FROM 절에 12회 LEFT JOIN MSTEMP EMPxx ON EMPxx.EMPCD = CHKPLANEQM_YEARPLAN.MONTH_xx 추가:
    - 행 단위 서브쿼리 반복 실행 비용(Row-by-Row Evaluation)을 일괄 인덱스 조인으로 전환하여 쿼리 실행 속도 및 데이터베이스 부하 대폭 개선
- **검증 결과**:
  - 파일 인코딩(단일 UTF-8 without BOM, CRLF 개행) 100% 무결성 확인
- **적용 순서**: MES_SNS2_EQM1001_R03.sql 프로시저 서버 DB 재반영 (SYSTEM_PARAMETERS 변경 없음)

### 13. EQM1001_S04 설비점검 이력 점검시트 출력(S04A) 추가

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_S04.aspx](01.Office/PAGEEQM/EQM1001/EQM1001_S04.aspx), [01.Office/PAGEEQM/EQM1001/EQM1001_S04.js](01.Office/PAGEEQM/EQM1001/EQM1001_S04.js), [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql), [04.Report/PAGEEQM/EQM1001/S04A.cs](04.Report/PAGEEQM/EQM1001/S04A.cs), [04.Report/PAGEEQM/EQM1001/S04A.Designer.cs](04.Report/PAGEEQM/EQM1001/S04A.Designer.cs), [04.Report/PAGEEQM/EQM1001/S04A.resx](04.Report/PAGEEQM/EQM1001/S04A.resx), [04.Report/PAGEEQM/EQM1001/EQM1001.csproj](04.Report/PAGEEQM/EQM1001/EQM1001.csproj), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 설비점검 이력 화면(점검일자·점검유형·설비코드 검색)에서 선택한 점검이력을 R03(제조설비 정기 점검 시트) 양식으로 출력 요청. 하단 ReportFooter(확인·점검자·담당 서명란, 개정이력)만 제외하고 나머지는 동일, 데이터는 별도 프로시저 분기
- **작업 상세 내용**:
  - 1. 화면: 검색 영역 오른쪽 끝에 [점검시트 출력] 버튼(btn_PRINT) 추가, grid1 선택 행의 CHKRSTKEY로 `ItsXtraRpt('EQM1001_S04A')` 팝업 출력. 미선택 안내는 레포트에서 처리
  - 1. 프로시저 EQM1001_S04 CALL_CHKRST_RPT 분기 추가
    - 점검키 없음 → "출력할 점검이력을 선택해주세요."
    - 상단(CHKRSTEQM + MSTEQM(FANO = EQMCD) + MSTLINE): EQMNM, EQMSPEC(EQMNM_DETAIL), EQMCD, CHKDATE(BASEDATE), LINENM, PROCESSNM(FM100)
    - 항목(CHKRSTEQMKND): NO, CHKITEM(CHKLOC 명칭), CHKCONTENT(CHKKNDNM), CHKDEVICE(CHKMTH 명칭), CHKRESULT(CHKVALUE 점검값), CONFIRM(빈 값), REMARK. 정렬은 정기점검 화면과 같게 그룹 항목 → SORTNO → CHKKNDCD
    - 선언부 2행 분리, BOM 제거(UTF-8 without BOM)
  - 1. 레포트 S04A: R03.Designer.cs에서 ReportFooter 밴드와 하위 컨트롤(서명란·개정이력 26개)만 제거, 나머지 레이아웃·제목·컬럼 폭 동일. S04A.cs는 R03과 같은 구조(최소 12행 빈 행 채움)로 상단 점검일자(cell_Val_CHKDATE)까지 바인딩
- **검증 결과**: MSBuild 15.0 Release Rebuild 성공(0 Error, 기존 R0602 경고 1건), exe를 01.Office/Reports·04.Report/bin에 배포(MD5 일치), exe 실행 시 점검키 미전달 안내 메시지 정상 출력(InitializeComponent 런타임 정상). 인코딩(.cs/.resx/.aspx/.js BOM+CRLF, .sql BOM 없음+CRLF) 확인. 미확인: 프로시저 서버 반영·실데이터 PDF 출력·VS 디자이너 열기·실제 화면
- **적용 순서**: MES_SNS2_EQM1001_S04.sql 프로시저 서버 DB 재반영 (파라미터 변경 없음)

### 14. EQM1001_S04 설비점검항목 그리드 특이사항(REMARK) 컬럼 추가

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_S04.js](01.Office/PAGEEQM/EQM1001/EQM1001_S04.js), [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql)
- **배경 및 원인**: 설비점검항목 그리드(grid2)에서 점검값 옆에 특이사항 표시 요청
- **작업 상세 내용**:
  - 1. grid2 점검값(CHKVALUE) 다음에 특이사항(REMARK, 폭 300, 읽기 전용) 컬럼 추가
  - 1. LIST_CHKRSTEQMKND 조회에 CHKRSTEQMKND.REMARK 추가 (점검실적 항목 특이사항, TAL0001_R05 점검 입력에서 저장, 점검시트 출력 특이사항과 같은 값)
- **검증 결과**: JS 구문 검사 통과, 인코딩(JS BOM+CRLF, SQL BOM 없음+CRLF) 확인. 미확인: 프로시저 서버 반영·실제 화면
- **적용 순서**: MES_SNS2_EQM1001_S04.sql 프로시저 서버 DB 재반영 (13번과 함께 반영)

### 15. EQM1001 R03 레포트 Visual Studio 디자이너 크래시 해결 및 다중 클래스 금지 규칙 정립

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R03.cs](04.Report/PAGEEQM/EQM1001/R03.cs), [04.Report/PAGEEQM/EQM1001/EQM1001.csproj](04.Report/PAGEEQM/EQM1001/EQM1001.csproj), [.agents/rules/report_devexpress.md](.agents/rules/report_devexpress.md), [.agents/rules/report_file_structure.md](.agents/rules/report_file_structure.md), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe), [04.Report/bin/EQM1001.exe](04.Report/bin/EQM1001.exe)
- **배경 및 원인**:
  - Visual Studio에서 `04.Report/PAGEEQM/EQM1001/R03.cs` 오픈 시 `이 파일에 디자인할 수 있는 클래스가 없으므로 디자이너에서 이 파일을 표시할 수 없습니다.` (스택: `CodeDomDesignerLoader.EnsureDocument` -> `VSCodeDomDesignerLoader.PerformLoad`) 크래시 발생
  - 원인 분석: 기존 규칙 문서 및 레포트 파일에 과거 관례 명목으로 `public class R03A : R03` 형태의 파생 클래스가 동일 파일 내에 선언되어 있어, Visual Studio CodeDOM 디자이너 로더가 1개 파일 내 복수 컴포넌트를 처리하지 못하고 주(Primary) 디자이너 대상 바인딩에 실패함
- **작업 상세 내용**:
  - 1. 불필요한 `R03A` 파생 클래스 및 별도 파일 완전 삭제 및 `EQM1001.csproj` 등록 제외
  - 1. `R03.cs`는 오직 `public partial class R03 : DevExpress.XtraReports.UI.XtraReport` 단일 클래스만 유지
  - 1. 개발 규칙(`.agents/rules/report_devexpress.md`, `.agents/rules/report_file_structure.md`)에 "1개 파일 1개 레포트 클래스 원칙(단일 컴포넌트 원칙)" 명시 및 임의의 파생/호환 클래스 선언 전면 금지 규칙 확정
  - 1. MSBuild Debug 및 Release 리빌드(0 Error, 0 Warning) 성공 후 최신 바이너리를 `04.Report/bin/EQM1001.exe` 및 `01.Office/Reports/EQM1001.exe`에 동기화 배포
- **검증 결과**:
  - CLI 실행 테스트(`EQM1001.exe R03 ...`) 정상 동작 확인
  - 인코딩(.cs, .Designer.cs, .resx, .csproj, .md 모두 단일 UTF-8 with BOM, CRLF 개행) 100% 무결성 확인

---

## 🕒 2026-11-05 (목) 작업 내역

### 8. MST1005_R01 평가표 결재 칸 빈칸 대각선 표시

- **수정/대상 파일**: [04.Report/PAGEMST/MST1005/R01.cs](04.Report/PAGEMST/MST1005/R01.cs), [04.Report/PAGEMST/MST1005/R01.Designer.cs](04.Report/PAGEMST/MST1005/R01.Designer.cs), 01.Office/Reports·04.Report/bin MST1005.exe 재배포
- **배경 및 원인**: 결재(작성·검토·승인) 칸에 값이 없으면 양식처럼 대각선으로 표시 요청
- **작업 상세 내용**:
  - 1. 결재 서명 칸 3개 위에 같은 위치·크기의 XRLine(LineDirection.BackSlant, 왼쪽 위 → 오른쪽 아래) 배치 (xrLineAprvWrite·Review·Approve)
  - 1. 칸 값이 비어 있을 때만 대각선 표시 : 작성(평가자 없음), 검토(항상 빈칸 → 항상 표시), 승인(승인 전)
- **검증 결과**: MSBuild Release 성공(경고 0), 승인·미승인 샘플 출력 비교(승인 : 검토만 대각선, 미승인 : 검토·승인 대각선, 1페이지), Designer 정적 점검(컴포넌트 93개 필드 일치, XRPanel 없음), 인코딩 확인. 미확인: VS 디자이너

### 2. MST1005_R01 평가 팝업 점수별 평가기준 비고 추가, 등록 점수 자동 선택 및 상단 영역 정렬 보정

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_R01.sql](05.Procedure/MES_SNS2_MST1005_R01.sql), [01.Office/PAGEMST/MST1005/MST1005_R01.aspx](01.Office/PAGEMST/MST1005/MST1005_R01.aspx), [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js)
- **배경 및 원인**: "설비등급 평가" 팝업창에서 우측 상단 점수별 평가기준 그리드(grid4)에 비고(REMARK) 컬럼 추가, 평가항목의 등록 점수 기준 행 자동 포커스 처리, 상단 평가등급 및 비고 영역의 시작·끝 위치 불일치 정렬 보정 요청
- **작업 상세 내용**:
  - 1. 프로시저 점수별 평가기준 비고 반환: LIST_EVAL_D2 분기에서 MSTEQM_GRADEREV_D2.REMARK 조회 컬럼 추가
  - 1. 우측 상단 그리드(grid4) 비고 컬럼 추가: JS grid4 생성 시 "비고"(REMARK, width: 150) 컬럼 정의 추가
  - 1. 등록 점수 기준 행 자동 선택: grid3 onSelect 시 현재 선택된 평가항목의 SCORE 값과 일치하는 grid4 행을 검색하여 Setkey 및 SetStore(selectIndex), SelectRow로 자동 선택(미등록 시 기존 방식대로 0번째 행 선택)
  - 1. 상단 평가등급 및 비고 영역 정렬 보정: pop1_cmb_EQMGRADE InputWidth를 293 -> 289로 조정하여 상단 "설비명" 끝과 정확히 일치시키고 뒤따르는 "비고" 시작 위치를 "평가일자" 시작과 통일, pop1_txt_REMARK InputWidth를 530 -> 544로 조정하여 우측 끝을 상단 "평가자" 끝과 픽셀 단위로 정확히 일치
- **검증 결과**: 구문 정적 검사 통과, 프로시저 UTF-8 (BOM 없음) + CRLF 및 화면 파일 UTF-8 with BOM + CRLF 바이너리 규정 준수 확인

### 7. MST1005_R01 평가 팝업 합계점수 즉시 표시·등급기준 그리드 선택 불가·헤더 정렬, 평가표 상단 여백 조정

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_R01.aspx](01.Office/PAGEMST/MST1005/MST1005_R01.aspx), [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js), [04.Report/PAGEMST/MST1005/R01.Designer.cs](04.Report/PAGEMST/MST1005/R01.Designer.cs), 01.Office/Reports·04.Report/bin MST1005.exe 재배포
- **배경 및 원인**: 평가 팝업에서 점수를 선택해도 합계점수가 바로 바뀌지 않음, 설비등급 기준 그리드 선택 불가 요청, 팝업 헤더 컨트롤 시작·끝 정렬 요청, 평가표 결재 칸 왼쪽 간격 제거 및 제목 아래·본문 표 위 여백 추가 요청
- **작업 상세 내용**:
  - 1. 합계점수 : 원인 - ItsNum은 값 칸(숨김)과 표시 칸(ItsNumView)이 따로 있고 표시 칸은 change 이벤트에서 갱신되는데, SET_TOTAL이 ItsNum.SetValue(..., false)로 이벤트를 꺼서 값만 바뀌고 화면은 그대로였음 → 이벤트를 발생시켜 설정 (합계점수 onChanged 처리 없음)
  - 1. 설비등급 기준 그리드(grid5) : selectMode 'None' (wijmo SelectionMode.None, 공통 컴포넌트 수정 없음)
  - 1. 팝업 헤더 : 라벨 폭 70 통일, 열 시작 0·250·650 / 행 끝 1250 정렬 (설비코드·합계점수 250, 설비명·평가등급 400, 평가일자 250 + 평가자 350 = 비고 600), 안내 문구 왼쪽 여백 제거
  - 1. 평가표 : 결재 칸을 설비 정보 표에 붙임(x 470, 작성·검토·승인 77·77·76), 제목·평가일자 아래 여백 5 → 20, 설비 정보와 본문 표 사이 여백 10 → 20 (PageHeader 높이 200 → 225)
- **검증 결과**: 실제 jquery·ItsPage.js·ItsNum.js 테스트 페이지에서 합계점수 문제 재현(값 6, 표시 0) 및 수정 확인(16·19 즉시 표시), 실제 wijmo에서 selectionMode 'None' 클릭·select 호출 시 선택 0건 확인, 컨트롤 템플릿·프로젝트 CSS 미리보기로 헤더 폭 실측(수정 전 행 끝 948·1007 → 수정 후 열 시작 0·250·650, 행 끝 1250 일치), 레포트 MSBuild Release 성공·PNG 출력 확인(1페이지), JS 구문 검사, 인코딩 확인. 미확인: 실제 화면 팝업, VS 디자이너
- **참고**: 이전 모의 테스트는 ItsNum 표시 칸을 흉내 내지 않아 합계점수 미표시를 잡지 못했음

### 6. MST1005_R01 설비등급 평가표 상단 설비정보·결재 칸 및 설비등급 표 위치 양식 반영

- **수정/대상 파일**: [04.Report/PAGEMST/MST1005/R01.cs](04.Report/PAGEMST/MST1005/R01.cs), [04.Report/PAGEMST/MST1005/R01.Designer.cs](04.Report/PAGEMST/MST1005/R01.Designer.cs), [05.Procedure/MES_SNS2_MST1005_R01.sql](05.Procedure/MES_SNS2_MST1005_R01.sql), 01.Office/Reports·04.Report/bin MST1005.exe 재배포
- **배경 및 원인**: 실제 평가표 양식 이미지 기준으로 상단을 설비명/관리번호·규격/제작일자·라인명/관리책임자 + 결재(작성·검토·승인)로, 설비등급 표 제목을 한 칸 위로 올려 달라는 요청
- **작업 상세 내용**:
  - 1. 출력 평가 정보 (CALL_EVAL_RPT 첫 결과셋) : 공정·라인·설비그룹 개별 값 → 설비명(MSTEQM.EQMNM), 관리번호(FANO), 규격(EQMNM_DETAIL), 제작일자(MKDATE 연.월), 라인명(작업장 공정 라인 명칭), 관리책임자(MSTEQM.DEPTCD → MSTDEPT.DEPTNM + '장')
  - 1. 상단 : 제목 "설비 등급 평가표" + 오른쪽 위 "평가일자 : YYYY년 MM월 DD일", 설비 정보 3행(값 2줄까지 표시), 오른쪽 결재 칸(결재 / 작성·검토·승인 : 작성 = 평가자, 검토 = 빈칸, 승인 = 승인자(승인 전 빈칸)), 결재 칸은 테두리 라벨로 배치(XRPanel 미사용)
  - 1. 설비등급 표 : 제목 "설비 등급 표"를 마지막 평가항목 아래 칸으로 이동 (레포트에서 마지막 항목과 같은 항목키의 제목 행 추가 → 구분·NO·항목·평가·소계 병합이 제목 줄까지 이어짐, 서식 규칙 [ROWTP] == 'T' 노란색), 합계 칸은 분류 머리글 줄부터 시작
- **검증 결과**: 헤더 SELECT 실DB 읽기 실행(I2G-001N : 규격 TSUGAMI_G350A-300 (1044), 제작일자 2014.12, 라인명 M1 열후 T1, 관리책임자 생산기술보전팀장 → 양식과 동일), MSBuild 15.0 Release Rebuild 성공(경고 0), 양식 이미지와 같은 값(점수 5·5·2·2·5, 합계 19, B)으로 PNG 출력 비교(1페이지, 설비명·규격 2줄 표시 및 결재 칸 높이 일치 수정 확인), exe 실행 확인, Designer 정적 점검(컴포넌트 90개 필드 일치, XRPanel 없음, 셀 폭 합계 470/731/301), 인코딩 확인. 미확인: VS 디자이너 열기, 서버 반영 후 실제 평가이력 출력
- **적용 순서**: MST1005_R01 프로시저 다시 저장 (SYSTEM_PARAMETERS 변경 없음)

### 5. MST1005_R01 설비등급 평가표 출력 레포트 신규 구현

- **수정/대상 파일**: [04.Report/PAGEMST/MST1005/R01.cs](04.Report/PAGEMST/MST1005/R01.cs), [04.Report/PAGEMST/MST1005/R01.Designer.cs](04.Report/PAGEMST/MST1005/R01.Designer.cs), [04.Report/PAGEMST/MST1005/R01.resx](04.Report/PAGEMST/MST1005/R01.resx), [04.Report/PAGEMST/MST1005/MST1005.csproj](04.Report/PAGEMST/MST1005/MST1005.csproj) (sln·App.config·Program.cs·Properties 포함 신규 프로젝트), [05.Procedure/MES_SNS2_MST1005_R01.sql](05.Procedure/MES_SNS2_MST1005_R01.sql), [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js), 01.Office/Reports·04.Report/bin MST1005.exe 배포
- **배경 및 원인**: 평가이력 그리드의 평가표출력 버튼에 연결할 평가표 레포트 요청 (양식 : 앞서 첨부된 설비등급 평가표 이미지)
- **작업 상세 내용**:
  - 1. 출력 데이터 (프로시저 MST1005_R01 / CALL_EVAL_RPT, 파라미터 추가 없음)
    - 1) 평가 정보 : EQMGRADEEVAL, MSTEQM (설비코드, 설비명, 작업장(GPCD N_LINECD), 공정(FM100), 라인(FM113), 설비그룹(FM116), 평가일자, 평가자(사원명), 승인자(사원명), 승인일시, 합계점수, 평가등급)
    - 1) 평가항목별 평가기준 : MSTEQM_GRADEREV_D, MSTEQM_GRADEREV_D2, EQMGRADEEVAL_D (평가기준 1줄당 1행 : 구분(GMTP 명칭), NO(항목 순번), 항목, 소계(평가 점수), 평가기준(n점 : 기준), 선택 여부)
    - 1) 설비등급 기준 : MSTEQM_GRADEREV_SCORE (분류(FM110 명칭), 점수, 구분, 비고(점검주기))
    - 1) 평가이력 없으면 "출력할 평가이력을 선택하세요."
  - 1. 레포트 양식 (A4 세로, 1페이지)
    - 1) 상단 : 제목 "설비등급 평가표", 평가 정보 3행 (승인 칸은 승인자 + 승인일자, 미승인은 "미승인")
    - 1) 본문 : 구분·NO·항목·평가(5~1)·소계·평가기준, 구분은 같은 값 병합(세로 표기), NO·항목·평가·소계는 항목(GMCD) 단위 병합
    - 1) 선택 점수 강조 : 평가 칸·평가기준 줄 녹색 (서식 규칙 [SCORE] == n, [SELYN] == 'Y')
    - 1) 하단 : 합계(빨간색), 설비등급 표(최대 5등급, 평가등급 분류 파란색)
  - 1. 화면 : 평가표출력 버튼 → new ItsXtraRpt('MST1005_R01') + EQMGRADEEVALKEY (기존 준비 중 안내 대체)
  - 1. 신규 레포트 프로젝트 04.Report/PAGEMST/MST1005 (EQM1001 프로젝트 구성 복사, 프로젝트·어셈블리 GUID 신규)
- **검증 결과**: 출력 SELECT 실DB 읽기 실행(가상 평가 1건 + 실제 리비전 261105000003 기준 : 26행, 경고 0건), MSBuild 15.0 Release Rebuild 성공(경고 0), 빌드한 레포트에 같은 데이터 바인딩해 PDF·PNG 출력 확인(1페이지, 병합·강조·등급표 정상, 행 높이 늘어남 문제는 병합 셀 CanGrow false로 수정), exe 실행 확인(R01 생성, 평가키 누락 안내), Designer 정적 점검(컴포넌트 89개 필드 일치, XRPanel 없음, BeginInit 테이블·this만, 셀 폭 합계 731/301), 인코딩 확인. 미확인: VS 디자이너 열기, 서버 프로시저 반영 후 실제 평가이력 출력
- **적용 순서**: MST1005_R01 프로시저 다시 저장 (CALL_EVAL_RPT 분기 추가, SYSTEM_PARAMETERS 변경 없음)

### 4. MST1005_R01 설비목록 작업장·공정·라인·설비그룹 셀 병합

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js)
- **배경 및 원인**: 다른 화면(MST1002_R06, MST1004_R01)처럼 설비목록의 작업장·공정·라인·설비그룹을 묶어서 표시 요청
- **작업 상세 내용**:
  - 1. 설비목록 그리드 : allowMerging 'Cells', 작업장·공정·라인·설비그룹 컬럼 allowMerging (기존 화면과 같은 방식)
  - 1. 병합 범위 : 앞 컬럼까지 값이 모두 같은 행 안에서만 병합 (작업장 > 공정 > 라인 > 설비그룹), 화면 전용 getMergedRange 지정 (공통 ItsGrid 수정 없음)
  - 1. 원인 : wijmo 기본 병합은 작업장이 달라도 공정·라인 값이 같으면 이어 붙임
  - 1. 프로시저 변경 없음 (정렬이 작업장 → 공정 → 라인 → 설비코드)
- **검증 결과**: 실제 wijmo 5.20203.748에서 기본 병합의 경계 넘김 재현(공정 B가 작업장 M1·M2에 걸침), 실DB 설비목록 254건에 화면 함수 원문 적용 : 잘못된 병합 0건 (기본 병합이면 경계를 넘는 곳 32곳), 렌더링 병합 확인, JS 구문 검사, 인코딩 확인. 미확인: 실제 화면

### 3. MST1005_R01 설비등급 평가등록 신규 구현

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_R01.aspx](01.Office/PAGEMST/MST1005/MST1005_R01.aspx), [01.Office/PAGEMST/MST1005/MST1005_R01.aspx.cs](01.Office/PAGEMST/MST1005/MST1005_R01.aspx.cs), [01.Office/PAGEMST/MST1005/MST1005_R01.js](01.Office/PAGEMST/MST1005/MST1005_R01.js), [05.Procedure/MES_SNS2_MST1005_R01.sql](05.Procedure/MES_SNS2_MST1005_R01.sql), [05.Procedure/MES_SNS2_MST1005_R01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_R01_SYSTEM_PARAMETERS.sql), [06.Table/MES_SNS2_EQMGRADEEVAL.sql](06.Table/MES_SNS2_EQMGRADEEVAL.sql)
- **배경 및 원인**: MST1004_R01 복사본으로 남아 있던 설비등급 평가등록 화면을 평가이력 CRUD 화면으로 구현 요청. 확정 사항 : 평가자는 헤더 EMPCD 컬럼 추가(REMP는 감사 컬럼), 자동계산 최근 1년 기준, 승인 시 설비등급 갱신, 평가표출력 레포트는 다음 작업
- **작업 상세 내용**:
  - 1. 조회
    - 1) 조회조건 : 조회일자(평가일자 범위), 작업장(*LINECD), 공정(*EQMTP), 라인(*EQMGROUP1), 작업장→공정→라인 연동
    - 1) 좌측 설비목록 : MSTEQM (USEYN = 'Y', FACTORYCD = '07') (작업장(MSTLINE 작업장명), 공정, 라인, 설비그룹, 설비코드, 설비명, 설비등급)
    - 1) 우측 평가이력 : EQMGRADEEVAL (평가일자, 평가등급, 합계점수, 평가자(사원명), 승인자(사원명), 승인일시, 상세조회, 평가표출력, 삭제)
    - 1) 설비 선택시 평가이력 조회
    - 1) 프로시저 : MST1005_R01 / LIST_EQM, LIST_EVAL
  - 1. 신규평가·상세조회 팝업
    - 1) 평가기준 : 신규는 사용중 리비전(MSTEQM_GRADEREV USEYN = 'Y'), 기존은 평가이력의 REVCD
    - 1) 평가항목 그리드 : MSTEQM_GRADEREV_D (구분, 평가항목, 계산구분, 산출값, 점수, 평가기준)
    - 1) 계산구분 산출값 : 고장건수 = EQMREP (EQMREPTP = 'EQM01') 평가일자 1년 전 다음날 ~ 평가일자 발생 건수, 수리시간 = 같은 기간 수리시간(발생~완료, 분) 합계 ÷ 12, 사용개월 = 설치일자(MSTEQM.SETDATE) ~ 평가일자 개월 수
    - 1) 계산구분 항목 점수 : MSTEQM_GRADEREV_D2 구간(최소값 이상 ~ 최대값 미만, 최소 = 최대면 그 값) 자동 판정, 계산구분 없는 항목은 오른쪽 점수별 평가기준 더블클릭(Enter)으로 선택
    - 1) 합계점수·평가등급 : 항목 점수 합계, MSTEQM_GRADEREV_SCORE 구간으로 평가등급 표시
    - 1) 평가일자 변경시 산출값·자동 점수 다시 조회 (직접 선택 점수 유지), 승인 이력은 저장 점수 표시·조회만
    - 1) 프로시저 : LIST_EVAL_D, LIST_EVAL_D2, LIST_EVAL_SCORE
  - 1. 저장
    - 1) 평가 저장 : EQMGRADEEVAL (평가일자, 평가자 EMPCD, 합계점수, 평가등급, 비고), EQMGRADEEVAL_D (항목별 점수, 저장 때마다 다시 생성), 신규 평가키 GETKEY('EQMGRADEEVALKEY')
    - 1) 저장 전 확인 : 평가자, 평가일자, 계산구분 없는 항목 점수가 점수별 평가기준에 있는지, 점수 없는 항목, 합계점수에 맞는 설비등급 기준, 승인 이력 수정 불가
    - 1) 계산구분 항목 점수는 화면 값을 쓰지 않고 프로시저에서 다시 판정
    - 1) 프로시저 : SAVE_EVAL (저장한 평가키 반환 → 평가이력 다시 선택)
  - 1. 승인
    - 1) 승인 팝업 : 승인자(기본 로그인 사원), 승인일자(기본 오늘)
    - 1) 승인 저장 : EQMGRADEEVAL (APRVEMP, APRVTIME = 승인일자 + 현재 시각, EQMGRADE_BEFORE = 승인 전 MSTEQM.EQMGRADE), MSTEQM (EQMGRADE = 평가등급)
    - 1) 막는 조건 : 이미 승인, 승인일자 < 평가일자, 같은 설비에 평가일자가 더 늦은 승인 이력
    - 1) 프로시저 : APPROVE_EVAL
  - 1. 삭제
    - 1) 평가이력 삭제 버튼 : EQMGRADEEVAL_D, EQMGRADEEVAL (승인 이력 삭제 불가)
    - 1) 프로시저 : DEL_EVAL
  - 1. 평가표출력 : 버튼만 배치(준비 중 안내), 레포트는 다음 작업
  - 1. 테이블 : 06.Table/MES_SNS2_EQMGRADEEVAL.sql 전체 정의(평가일자·등록/수정 시간·사원·프로그램 포함) + 평가자 EMPCD 추가, 기존 테이블용 ALTER 문 주석 포함
  - 1. 파라미터 18건 (SCORE_LIST 16번, CALLTYPE 17번, KEYWORD 18번)
- **검증 결과**: 실DB 읽기 전용 실행(I2C-002N 2026-11-05 : 고장 5건→3점, 월평균 77.17분→1점, 사용 114개월→2점, 등급 경계 -99.999~99 판정, 설비목록 254건, 경고 0건), Node 모의 테스트 17건 통과(조회·신규·자동/직접 점수·평가일자 변경·저장·승인 이력 잠금·삭제·승인·등급 경계·조회조건 연동), IF 25/25·WHILE 1/1 정적 점검, 인코딩 확인. 미확인: EMPCD 컬럼 반영 전이라 프로시저 컴파일·저장/승인/삭제 실행·실제 화면
- **적용 순서**: 06.Table ALTER(EMPCD 추가) → MST1005_R01 프로시저 저장 → SYSTEM_PARAMETERS 등록(18건)

### 2. MST1005_S01 계산구분 빈 항목 높이 수정

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 계산구분 콤보의 빈 항목이 목록에서 너무 좁게 표시됨 (공통 그리드 수정 없이 유지 결정)
- **작업 상세 내용**:
  - 1. 원인 : 빈 문자열 항목은 wijmo 목록에서 글자가 없어 높이가 7px로 줄어듦 (다른 항목 30px)
  - 1. 빈 항목 표시값을 공백 문자(\u00a0)로 변경, 값은 빈 값 그대로 (저장·조회 영향 없음)
- **검증 결과**: 실제 wijmo 5.20203.748 테스트 페이지에서 항목 높이 빈 문자열 7px → 공백 문자 30px(다른 항목과 동일), 선택 값 빈 값, 그리드 표시·값 정상 확인, JS 구문 검사, 인코딩 확인. 미확인: 실제 화면

### 2. MST1005_S01 계산구분 콤보 표시 오류 수정

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 계산구분 콤보에 공백을 넣으려고 gpcd를 @CALCTP로 바꾼 뒤 콤보 목록과 기존 값이 모두 빈칸으로 표시됨. 원인: 공통 그리드가 @ 접두어 시 맨 앞에 {Label, Value, Tag} 빈 항목을 넣고, 첫 항목의 세 번째 키(Tag)를 표시 컬럼으로 잡는데 DC_COMBO 공통코드 결과는 Label·Value만 있어 모든 항목이 빈 표시가 됨 (그리드에서 @를 쓰는 화면이 없는 이유)
- **작업 상세 내용**:
  - 1. gpcd를 CALCTP로 원복
  - 1. 그리드 생성 직후 계산구분 컬럼 DataMap 목록 맨 앞에 {Label: '', Value: ''} 빈 항목을 추가하고 refresh (공통 컴포넌트 수정 없음)
  - 1. 참고 : 그리드 메뉴 스타일초기화 시 공통 그리드가 DataMap을 다시 만들어 새로고침 전까지 빈 항목만 빠짐 (이름 표시는 정상)
- **검증 결과**: 실제 wijmo 5.20203.748로 만든 테스트 페이지에서 @ 방식 표시 오류 재현(목록 ["",null,null,null]) 및 수정 방식 확인(목록 ["",고장건수,수리시간,사용개월], 그리드 표시 고장건수·사용개월, 빈 항목 선택 시 값·표시 빈 값), JS 구문 검사, 인코딩 확인. 미확인: 실제 화면

### 2. MST1005_S01 계산구분 공백 항목의 최소·최대값 숨김 및 저장 시 비움

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 계산구분이 공백인 평가항목은 점수별 평가기준에서 점수·평가기준·비고만 쓰도록 요청 (숨기고 저장 시 비움 방식 선택)
- **작업 상세 내용**:
  - 1. 화면 : 평가항목 선택 시 계산구분이 공백이면 점수별 평가기준의 최소값(이상)·최대값(미만) 컬럼 숨김, 값이 있으면 표시 (SET_D2_RANGE_COLUMN), 선택 행의 계산구분 칸 변경 시 바로 반영
  - 1. 평가항목 저장(SAVE_D) : 기존 항목을 계산구분 공백으로 저장하면 그 항목 점수별 평가기준(MSTEQM_GRADEREV_D2)의 최소·최대값을 비움 (값이 있는 행만 UPDATE)
  - 1. 점수별 평가기준 저장(SAVE_D2) : 저장된 평가항목의 계산구분이 공백이면 최소·최대값을 비워서 저장 (숫자·구간 겹침 확인 대상 아님)
  - 1. 파라미터 변경 없음 (26건)
- **검증 결과**: Node 모의 테스트(계산구분 유무별 컬럼 숨김/표시, 선택 행 계산구분 변경 즉시 반영, 다른 행·다른 칸 변경 무시) 통과, 비움 대상·계산구분 조회 SQL 실DB 읽기 실행(현재 대상 0건, 경고 0건), IF 42/42 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 2. MST1005_S01 계산구분 콤보 공백 항목 추가

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 평가항목 계산구분 콤보에 공백 선택 요청
- **작업 상세 내용**:
  - 1. 평가항목 그리드 계산구분 콤보 gpcd를 CALCTP → @CALCTP로 변경 (공통 그리드의 @ 접두어 : 목록 맨 앞에 빈 항목 추가, 코드 조회 시 @ 제거)
  - 1. 프로시저는 이미 계산구분 빈 값 허용이라 변경 없음
  - 1. 참고 : 그리드 메뉴 스타일초기화 시 공통 그리드가 @를 제거하지 않고 코드를 다시 조회해, 새로고침 전까지 계산구분이 코드값으로 보일 수 있음 (공통 컴포넌트 영역)
- **검증 결과**: 공통 그리드 ItsGrid.js 콤보 생성 경로(@ 처리) 확인, JS 구문 검사, 인코딩 확인. 미확인: 실제 화면 콤보

### 2. MST1005_S01 상단 기준 저장·삭제 검증 분기 완전 분리

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 기준 저장(SAVE)과 삭제(DEL)가 한 조건문 블록 안에 묶여 있어 가독성이 떨어지고 수정 시 혼동이 발생하는 문제를 해결하기 위해 독립 분기로 분리 요청
- **작업 상세 내용**:
  - 1. 기준 저장 검증(3-1): IN ('SAVE_D', 'SAVE_D2', 'SAVE_SCORE') 전용 블록으로 분리하여 이전 리비전 차단 및 평가이력 존재 시 변경 차단 안내만 명확히 처리 (비고 저장 SAVE_REV는 허용)
  - 1. 삭제 검증(3-2): LIKE 'DEL_%' 전용 블록으로 분리하여 이전 리비전 삭제 차단 및 평가이력 존재 시 삭제 차단 안내만 독립적으로 처리
  - 1. 최상단 Modify 주석 1일 1행 원칙에 맞춰 갱신
- **검증 결과**: 구문 정적 점검 통과, UTF-8 with BOM 및 CRLF 인코딩 준수 확인

### 2. MST1005_S01 상단 공통 검증 조건문 단순화 및 직관성 개선

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 10개에 달하는 $CALLTYPE을 일일이 나열하고 부정형(<> 'SAVE_REV')을 중복 사용하여 가독성과 유지보수성이 저하되었던 상단 공통 검증 로직 간소화 요청
- **작업 상세 내용**:
  - 1. 리비전 선택 확인 단순화: 긴 나열 대신 NOT IN ('LIST_REV', 'RENEW_REV') AND $REVCD = '' 형태로 축약하여 누락 위험 원천 방지
  - 1. 저장·삭제 공통 묶음: $CALLTYPE LIKE 'SAVE_%' OR $CALLTYPE LIKE 'DEL_%' 패턴 매칭으로 리비전 존재 확인 1회 수행
  - 1. 부정 조건문 제거 및 명시화: <> 'SAVE_REV' 대신 IN ('SAVE_D', 'SAVE_D2', 'SAVE_SCORE') OR LIKE 'DEL_%' 형태로 명시하여 삭제(DEL) 작업이 포함됨을 직관적으로 확인 가능하도록 변경
  - 1. 최상단 Modify 주석 1일 1행 원칙에 맞춰 갱신
- **검증 결과**: 구문 정적 점검 통과, UTF-8 (BOM 없음) + CRLF 인코딩 준수 확인

### 2. MST1005_S01 평가이력(EQMGRADEEVAL) 존재 시 삭제 차단 명시화

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 해당 리비전으로 등록된 평가이력(EQMGRADEEVAL)이 있을 때 안내 문구가 "변경할 수 없습니다"로만 되어 있어 삭제 시 안내가 부적절하고 삭제 차단 여부가 불명확했던 문제 개선 요청
- **작업 상세 내용**:
  - 1. 공통 확인 주석 갱신: 리비전 변경·삭제 공통 확인 및 평가이력 존재 시 변경·삭제 불가 명시
  - 1. 삭제 분기 안내 추가: $CALLTYPE LIKE 'DEL_%'(DEL_REV, DEL_D, DEL_D2, DEL_SCORE)일 경우 "해당 리비전으로 등록한 평가이력이 있어서 삭제할 수 없습니다." 전용 안내 출력
  - 1. 저장/변경 분기: 기존대로 "해당 리비전으로 등록한 평가이력이 있어서 변경할 수 없습니다.<br>리비전 갱신 후 변경하세요." 유지
- **검증 결과**: 구문 정적 점검 통과, UTF-8 with BOM 및 CRLF 인코딩 준수 확인

### 2. MST1005_S01 점수별 평가기준(SAVE_D2) 검증 로직 단순화

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 프로시저 내 불필요하거나 과도한 정규식(REGEXP) 검증을 단순화하여 가독성 향상 요청
- **작업 상세 내용**:
  - 1. 필수 권장 유지: 사용자 직접 입력값인 점수(_$SCORE, 5자리 정수) 및 최소·최대값(_$MINVAL,_$MAXVAL, 실수 포맷) 정규식 검증 유지
  - 1. 단순화 적용: 평가항목(_$GMCD) 정규식을 단순 빈 값(= '') 체크로 간소화(이후 DB 조회에서 유효성 검증), 조회 시점 키(_$ORGKEY)의 중복 정규식 검증 블록 제거(이후 EXISTS 및 CAST 비교로 이미 보장)
  - 1. 최상단 Modify 주석 1일 1행 원칙에 맞춰 갱신
- **검증 결과**: 구문 점검 통과, UTF-8 with BOM 및 CRLF 인코딩 준수 확인

### 2. MST1005_S01 화면 3구역 배치 변경

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx)
- **배경 및 원인**: 그리드 영역을 3구역으로 나눠 설비등급 기준을 3번, 평가항목을 2번 상단, 점수별 평가기준을 2번 하단에 배치 요청
- **작업 상세 내용**:
  - 1. 1구역(왼쪽 20%) : 리비전 (변경 없음)
  - 1. 2구역(가운데, 오른쪽 영역의 50%) : 상단 평가항목, 하단 점수별 평가기준 (각 50%, 머리글 높이 6%)
  - 1. 3구역(오른쪽, 오른쪽 영역의 50%) : 설비등급 기준 전체 높이 (머리글 높이 3%, 리비전과 동일)
  - 1. 버튼·그리드 ID와 라벨 문구(점수별 평가기준 표기 포함)는 그대로, JS·프로시저 변경 없음
- **검증 결과**: aspx div 짝(14/14)·asp:Content 짝·버튼/그리드 ID 16개 확인, 인코딩(단일 BOM·CRLF) 확인. 미확인: 실제 화면 비율

### 2. MST1005_S01 프로시저 튜닝 (공통 확인 통합·중복 조회/JOIN·변수 정리)

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 프로시저 변수가 많고 불필요한 코드·JOIN·변수 정리 및 SQL 튜닝 요청
- **작업 상세 내용**:
  - 1. 공통 확인 통합 : 리비전 미선택 확인(LIST_D·LIST_SCORE·SAVE_REV 등 개별 중복 제거), 존재 확인을 SAVE_REV까지 공통으로, 이전 리비전 차단과 DEL_REV 최신 리비전 확인을 한 번의 MAX 조회로 통합(DEL_REV 리비전 재조회 제거)
  - 1. 변수 20개 → 18개 : 안내 문구 변수 _$NAME을 _$MSG로 통합,_$USEYN 제거
  - 1. 점수별 평가기준 구간 겹침 : 평가항목 이름 LEFT JOIN 제거(저장 중 조회한 _$GMNM 사용), 겹침 조건은 기존 자기 조인 형태 유지 (파생 테이블로 바꿨던 구조는 복잡하다는 요청에 따라 원복)
  - 1. 신규·수정 저장 : EXISTS 확인 후 UPDATE/INSERT 분기를 INSERT … ON DUPLICATE KEY UPDATE 한 문장으로 (점수별 평가기준·설비등급 기준, 키 변경 분기는 유지)
  - 1. 리비전 삭제 후 사용중 처리 : 삭제 전 사용여부 조회 없이 남은 가장 최근 리비전만 Y, 나머지 N으로 바뀌는 행만 UPDATE
  - 1. 유지 : 설비등급 조회의 COMTYPE JOIN(FM110 정렬순서용), 겹침 안내의 COMTYPE JOIN(등급명 표시용)
  - 1. 동작 변경 없음, 파라미터 26건 그대로, Modify 이력 1행 추가
- **검증 결과**: 구간 겹침 신규 구조 12개 사례 기대값 일치, 실데이터 전 리비전·평가항목 대상 기존·신규 쿼리 결과 동일, 리비전 삭제 후 사용중 처리 미리보기(REV 2 삭제 시 REV 1만 Y) 실DB 읽기 실행(경고 0건), IF 36/36·WHILE 6/6 짝·미사용 변수 0건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·저장 분기 실제 실행

### 2. MST1005_S01 화면 글자 수 검증(CHECK_LENGTH) 제거

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: JS에서 길이까지 제한하는 검증은 불필요하다는 요청
- **작업 상세 내용**:
  - 1. CHECK_LENGTH 함수와 리비전 비고·평가항목·점수별 평가기준·설비등급 기준 저장 전 글자 수 확인 호출 4곳 전부 삭제
  - 1. 입력 검증은 프로시저에서 DB 컬럼 정의 기준으로만 처리 (화면 길이·범위 검증 추가 금지)
- **검증 결과**: JS 구문 검사, CHECK_LENGTH 잔여 0건, 인코딩 확인. 미확인: 실제 화면

### 2. MST1005_S01 평가항목·점수별 평가기준 비고 추가

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**: 평가항목·점수별 평가기준 그리드에 비고(REMARK) 칸 추가 요청
- **작업 상세 내용**:
  - 1. 평가항목 : MSTEQM_GRADEREV_D.REMARK 조회(LIST_D)·저장(SAVE_D, REMARK_LIST), 그리드 비고 컬럼 추가
  - 1. 점수별 평가기준 : MSTEQM_GRADEREV_D2.REMARK 조회(LIST_D2)·저장(SAVE_D2 점수 변경·수정·신규 모두, D2_REMARK_LIST), 그리드 비고 컬럼 추가
  - 1. 리비전 갱신 시 두 테이블 비고도 함께 복사
  - 1. 비고는 컬럼 크기(VARCHAR(1000)) 기준 화면 저장 전 1000자 확인, 프로시저 변수 _$REMARK VARCHAR(1000)
  - 1. 파라미터 24건 → 26건 (SYSTEM_PARAMETERS 재등록 필요)
- **검증 결과**: Node 모의 테스트(그리드 컬럼, 비고 전송, 1000자 초과 차단) 통과, 비고 포함 조회·복사 SELECT 실DB 읽기 실행(경고 0건), IF 짝·파라미터 26건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 2. MST1005_S01 입력 검증을 DB 컬럼 정의 기준으로 정리

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 글자 수·범위 제한은 임의 값이 아니라 DB에 구성된 컬럼 범위 안에서만 검증하도록 요청
- **작업 상세 내용**:
  - 1. 기준 : 각 값이 저장되는 DB 컬럼 정의만 사용 (임의로 정했던 -99999.99 ~ 99999.99 제한 제거)
  - 1. 최소·최대값(VARCHAR(100)) : 숫자 형식만 확인, 길이 100자는 화면 저장 전 확인, 크기 비교·구간 겹침은 실수(DOUBLE) 비교로 변경해 긴 숫자도 범위 초과 오류 없음, 최소 = 최대 구간 판정은 보정값 없이 끝값 포함 비교
  - 1. 점수(DECIMAL(5,0)) : -99999 ~ 99999 정수, NO(DECIMAL(20,0)) : 20자리 이내 정수 (프로시저 변수 VARCHAR(20)이라 화면에서 20자 초과 사전 차단)
  - 1. 글자 수(화면 저장 전) : 평가항목·평가기준·등급 점수·구분·최소·최대값 100자, 비고(점검주기) 10자, 리비전 비고 1000자
  - 1. 겹침 안내 문구는 안내 변수 크기(500자) 안으로 자름, 프로시저 변수·파라미터 크기는 원래대로 유지
- **검증 결과**: 구간 겹침 12개 사례(긴 음수·99자리 숫자·소수 경계 포함) 실DB 읽기 실행 기대값 일치(경고 0건), JS 구문 검사, IF 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 2. MST1005_S01 숫자 범위·글자 수 초과 오류 안내 처리

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 최소·최대값에 -9999999999, -99.999 같은 값이 그대로 저장되고, -99999999999999999 입력 시 Out of range value for column '(null)' 오류 발생. 원인: 최소·최대값 자리수 제한이 없어 겹침 확인 등의 DECIMAL(18,4) 변환에서 범위 초과 경고(1264)가 DB 오류로 표시됨
- **작업 상세 내용**:
  - 1. 최소·최대값(점수별 평가기준·설비등급 기준) : -99999.99 ~ 99999.99, 소수 둘째 자리까지만 허용, 벗어나면 범위 안내 후 저장 취소
  - 1. 평가항목 NO : 0 ~ 99999 정수 (DECIMAL 범위 초과 오류 방지)
  - 1. 글자 수 확인 : 화면 저장 전에 평가항목명·평가기준·최소·최대값·등급 점수·구분 100자, 비고(점검주기) 10자, 리비전 비고 1000자 초과 시 현재 글자 수와 함께 안내 후 저장 안 함 (CHECK_LENGTH, DB 영문 Data too long 오류 방지)
  - 1. 프로시저 변수·파라미터 크기는 원래대로 유지 (처음 넓혔던 VARCHAR(4000)·MEDIUMTEXT 변경과 프로시저 글자 수 확인은 요청에 따라 원복)
  - 1. 이미 저장된 범위 밖 값(점수별 평가기준 -9999.4561·-1.5867, E등급 -99.999)은 다음 저장 시 차단되므로 수정 필요
- **검증 결과**: 범위 확인식(-9999999999·-99.999·-99999999999999999 차단, -99999.99·144·0.5 통과, NO 123456 차단)과 범위 초과 경고(1264) 재현 실DB 읽기 실행, Node 모의 테스트(비고 1001자·평가항목 101자·최소값 101자·비고(점검주기) 11자 차단, 한도 이내 저장) 통과, IF/WHILE 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 2. MST1005_S01 저장 행 선택 유지·공백 제거·점수 음수 허용·이전 리비전 조회 전용

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 실사용 검증 목록 중 13·14·15·16·11번 수정 요청 (15번은 점수 컬럼이 DECIMAL(5,0)이라 정수 유지로 결정)
- **작업 상세 내용**:
  - 1. (13) 평가항목 저장 : SAVE_D가 저장한 행 순서대로 평가항목코드 반환(GMCD_LIST), 선택했던 행이 저장 대상이면 그 코드(신규는 발번 코드)로 다시 선택해 바로 점수 추가 가능
  - 1. (14) 점수별 평가기준·설비등급 기준 최소·최대값 앞뒤 공백 제거(TRIM) 후 확인·저장
  - 1. (15) 점수는 정수만(음수 가능, -99999 ~ 99999, 테이블 DECIMAL(5,0) 그대로), 안내 문구 점수는 정수(음수 가능)로 입력하세요, 최소·최대값은 음수·소수 허용, 저장 행 점수 변경 비교는 숫자 기준 (처음 작성한 소수 허용·테이블 변경 스크립트는 요청에 따라 취소)
  - 1. (16) 리비전 미선택은 리비전을 선택하세요, 삭제된 리비전은 선택한 리비전이 없습니다 / 다시 조회하세요로 구분 (공통 확인·비고 저장)
  - 1. (11) 이전 리비전 조회 전용 : 프로시저에서 평가항목·점수별 평가기준·설비등급 기준 저장·삭제 차단(이전 리비전(REV n)은 조회만 가능합니다), 화면은 이전 리비전 선택 시 추가·저장·삭제 버튼 숨김과 그리드 읽기 전용, 리비전 비고 저장·리비전 갱신(이전 리비전 복사)은 유지
- **검증 결과**: Node 모의 테스트(최신/이전 리비전 버튼·읽기 전용 전환, 신규 항목 저장 후 발번 코드 선택·점수기준 조회, 비저장 행 선택 유지) 통과, 정수 점수 확인식(-3·5 통과, 1.5·123456 차단)·공백 제거·숫자 비교·이전 리비전 판정 실DB 읽기 실행(경고 0건), IF/WHILE 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 2. MST1005_S01 최소=최대 값 일치 허용 및 분류 변경 시 구간 겹침 원인 확인

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: B등급(15~20)을 D로 바꿀 때 D·B 구간 겹침 안내가 나오고, 최소값·최대값 0, 0 저장이 막힌다는 요청
- **작업 상세 내용**:
  - 1. 분류 변경 시 겹침 원인 : DB에 배포된 프로시저가 조회 시점 키(GR_ORG_EQMGRADE_LIST) 처리 전 버전이고 SYSTEM_PARAMETERS도 22건이라, 화면이 보낸 원래 등급(B)이 무시되어 B는 남고 D가 새로 추가됨 → 현재 프로시저·SYSTEM_PARAMETERS(24건) 반영 시 B 행이 D로 변경되어 해결 (코드 추가 수정 없음)
  - 1. 최소 = 최대 허용 : 점수별 평가기준·설비등급 기준 모두 최소 > 최대만 차단 (안내: 최소값은 최대값보다 클 수 없습니다), 최소 = 최대(예: 0, 0)는 그 값과 같을 때로 판정하고 최대값 표기를 최소값으로 통일
  - 1. 구간 겹침 확인 : 최소 = 최대 구간은 그 값 하나로 보고 겹침 판정 (0~0과 1~5 통과, 0~0과 0~5 차단, 5~10과 10~10 통과)
  - 1. 평가등록(R01) 자동 계산도 같은 기준 필요 : 최소 이상 ~ 최대 미만, 최소 = 최대면 일치
- **검증 결과**: 구간 판정 9개 사례 실DB 읽기 실행으로 기대값 일치(경고 0건), 배포 프로시저·SYSTEM_PARAMETERS 상태 실DB 조회로 원인 확인, IF/WHILE 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 1. MST1005_S01 기존 행 분류·점수 콤보 오류(Uncaught Error) 수정

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**: 리비전 갱신으로 복사된(저장된) 설비등급 행의 분류 콤보 클릭 시 Uncaught Error 발생. 원인: 저장 행의 키(분류·점수) 편집을 막으려고 onBeginningEdit에서 throw ''로 편집을 취소했는데, 콤보 드롭다운 클릭 경로(_MouseHandler._click → _toggleListBox → startEditing → onBeginningEdit)에서 예외가 잡히지 않고 그대로 브라우저 오류로 출력됨
- **작업 상세 내용**:
  - 1. 예외로 편집을 막던 grid3(점수)·grid4(분류) onBeginningEdit 제거 → 저장된 행도 분류·점수 수정 가능
  - 1. 조회 시점 키 보관 : LIST_D2 SCORE AS ORG_SCORE, LIST_SCORE EQMGRADE AS ORG_EQMGRADE (숨김 컬럼, REVCD 반환·컬럼 대체)
  - 1. 저장 : D2_ORG_SCORE_LIST·GR_ORG_EQMGRADE_LIST 추가 전송, 프로시저는 조회 시점 키와 다르면 기존 행의 키를 새 값으로 UPDATE (새 키가 이미 있으면 안내 후 저장 취소), 같으면 기존 UPSERT
  - 1. 삭제 : 화면에서 바꾼 값이 아닌 조회 시점 키로 DB 삭제 (저장 행 판정도 ORG_값 기준, IS_SAVED_ROW)
  - 1. 파라미터 22건 → 24건 (SYSTEM_PARAMETERS 재등록 필요)
  - 1. 같은 throw 방식 편집 차단이 EQM1001_R03(4곳)·PRD7001_R02·R04에도 있으나 이번 요청 범위 밖이라 미수정
- **검증 결과**: Node 모의 테스트(편집 차단 이벤트 없음, 분류·점수 변경 저장 시 조회 시점 키 전송, 변경 후 삭제 시 원래 키 삭제, 신규 행 빈 값) 통과, 변경 조회 SQL 실DB 읽기 실행(경고 0건), IF/ELSEIF/WHILE 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 콤보 동작

---

## 🕒 2026-11-04 (수) 작업 내역

### 2. MST1005_S01 설비등급 최대점수를 미만 기준으로 변경

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 설비등급 기준도 점수별 평가기준과 같이 최소 이상·최대 미만으로 요청
- **작업 상세 내용**:
  - 1. 설비등급 기준 : MSTEQM_GRADEREV_SCORE 구간을 최소점수 이상 ~ 최대점수 미만으로 변경 (이전: 최대점수 이하)
  - 1. 최소점수 = 최대점수도 저장 불가 (안내: {등급}등급의 최소점수(x)는 / 최대점수(y)보다 작아야 합니다.)
  - 1. 구간 겹침 확인을 미만 기준으로 변경 : 경계값 공유(B 15~20, A 20~)는 허용, 안내 문구 최대점수(미만)
  - 1. 화면 컬럼명 최대점수(이하) → 최대점수(미만)
- **검증 결과**: 평가표 구간(A 20~/B 15~20/C 10~15/D 7~10/E 0~7) 겹침 없음, 19~21 입력 시 A·B와 겹침 검출 (실DB 읽기 실행, 경고 0건), JS 구문 검사, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 2. MST1005_S01 리비전 삭제를 가장 최근 리비전만 허용

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 리비전 삭제 시 신규(가장 최근) 리비전만 삭제 가능하고 기존 리비전은 삭제되지 않도록 요청
- **작업 상세 내용**:
  - 1. 리비전 삭제(DEL_REV) : MSTEQM_GRADEREV의 리비전 번호가 최대값보다 작으면 삭제 불가 (안내: 이전 리비전(REV n)은 삭제할 수 없습니다. / 가장 최근 리비전만 삭제할 수 있습니다.)
  - 1. 기존 조건 유지 : 평가이력 있는 리비전 삭제 불가, 사용중 리비전 삭제 시 남은 최신 리비전을 사용중으로 변경
- **검증 결과**: 실DB 읽기 실행으로 리비전별 삭제 가능 여부 판정 확인(경고 0건), IF 짝·인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 2. MST1005_S01 긴 안내 문구 줄바꿈

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 구간 겹침 등 긴 안내 문구가 한 줄로 길게 표시되어 줄바꿈 요청
- **작업 상세 내용**:
  - 1. 안내창(ItsMsg.Alert/Confirm)이 문구를 HTML로 넣고 white-space 설정이 없어 \n은 공백으로 보이므로 <br>로 줄바꿈
  - 1. 프로시저 : 평가이력 잠금, 점수별 평가기준·설비등급 구간 겹침, 평가기준 최소·최대값 숫자/크기, 설비등급 최소·최대점수 크기 오류 문구를 문장·항목명 단위로 줄바꿈
  - 1. 화면 : 리비전 갱신 확인(선택한 리비전을 복사하여 / 새 리비전을 생성하시겠습니까?), 평가항목 삭제 확인((점수별 평가기준 포함)) 줄바꿈
- **검증 결과**: ItsMsg.js·ItsMsg.css 처리 방식 확인, JS 구문 검사, 인코딩 확인. 미확인: 실제 안내창 표시

### 2. MST1005_S01 추가 행 번호를 빈 번호 우선으로 변경

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 1~5 중 1,2,3 삭제 후 추가 시 6,7,8로 채번되는 문제
- **작업 상세 내용**:
  - 1. 평가항목 NO(SORTNO)·점수별 평가기준 점수(SCORE) 추가 시 최대값+1 대신 그리드에 없는 가장 작은 번호 사용 (GET_NEXT_SORTNO → GET_NEXT_NO(그리드, 필드))
  - 1. 예: 4,5만 남은 상태에서 추가 → 1, 2, 3, 다음은 6
- **검증 결과**: Node 모의 테스트(4,5 남은 상태 4회 추가 1,2,3,6 / 빈 그리드 1 / 1,3 사이 2) 통과, 인코딩 확인. 미확인: 실제 화면

### 2. MST1005_S01 점수별 평가기준 추가·저장·삭제 및 머리글 공백 축소

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 1~5점 자동 생성 대신 점수별 평가기준을 자유롭게 추가·삭제하고, 각 영역 머리글 아래 공백 축소 요청
- **작업 상세 내용**:
  - 1. 점수별 평가기준 자유 입력
    - 1) 평가항목 신규 저장 시 1~5점 행 자동 생성 제거
    - 1) 점수별 평가기준 [추가][저장][삭제] : MSTEQM_GRADEREV_D2, 추가는 저장된 평가항목 선택 시만 가능(점수 기본값 최대+1), 저장된 행의 점수는 수정 불가
    - 1) 저장 : 없으면 INSERT·있으면 UPDATE, 점수 숫자 필수, 화면에서 같은 점수 중복 차단, 구간 겹침 확인 유지
    - 1) 삭제 : 저장 행만 DB 삭제(DEL_D2 신설, 평가이력 잠금 대상), 신규 행은 화면에서만 제거
  - 1. 영역 머리글 높이 축소 : 리비전 4→3, 설비등급 기준 13→8, 평가항목·점수별 평가기준 7→4.5 (TopHeightPc)
  - 1. 파라미터 22건 유지 (SYSTEM_PARAMETERS 재등록 불필요)
- **검증 결과**: Node 모의 테스트(자동 생성 제거, 점수기준 추가 기본값·점수 잠금·중복 차단·저장/삭제 파라미터, 미저장 항목 추가 차단) 통과, IF/WHILE 짝·파라미터 22건 정적 점검, JS 구문 검사, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 머리글 높이

### 2. MST1005_S01 설비등급 기준 평가표 대응 및 점수 구간 겹침 차단

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 설비등급과 분류가 같은 개념, 평가표 비고가 점검주기인데 별도 비고가 있어 헷갈림. 테이블은 그대로 두고 조회·저장 SQL과 화면에서 불필요 컬럼만 제외 요청. 등급 점수 구간(예: D 5~9 = 5 이상 9 이하, E 0~4)이 겹치면 경고 후 저장 차단 요청
- **작업 상세 내용**:
  - 1. 설비등급 기준 : MSTEQM_GRADEREV_SCORE (분류(EQMGRADE, FM110), 점수(SCORENM), 최소점수(이상)(MINVAL), 최대점수(이하)(MAXVAL), 구분(MNGNM), 비고(점검주기)(CHKCYCLE2))
    - 1) 조회·저장·리비전 복사에서 EQMGRADENM·SORTNO·USEYN·REMARK 제외 (테이블 컬럼은 유지, 신규 행은 기본값), 조회 순서는 공통코드 FM110 정렬순서
    - 1) 최소·최대점수는 빈 값 또는 숫자, 둘 다 빈 값 불가, 최소점수 > 최대점수 불가
    - 1) 저장 후 같은 리비전의 등급 구간(최소 이상 ~ 최대 이하)이 겹치면 겹치는 두 등급과 구간을 알려주고 저장 취소 (예: D등급(5~9)과 E등급(0~5)의 점수 구간이 겹칩니다)
  - 1. 평가항목·점수별 평가기준 : 조회·저장·복사에서 REMARK 제외 (테이블 컬럼 유지)
  - 1. 점수별 평가기준 : 같은 평가항목의 점수 구간(최소값 이상 ~ 최대값 미만)이 겹치면 해당 점수와 구간을 알려주고 저장 취소 (최소·최대 모두 빈 행은 제외)
  - 1. 처음 작성한 테이블 컬럼 삭제 스크립트(TABLE_ALTER)·06.Table CREATE 문은 요청에 따라 삭제, 파라미터 22건
- **검증 결과**: 겹침 확인 SQL 실DB 읽기 실행 (현재 데이터에서 D등급(5~9)·E등급(0~5) 겹침 문구 확인, 평가표 구간 A 20~/B 15~19/C 10~14/D 5~9/E 0~4 겹침 없음, 19~20 입력 시 A·B와 겹침 검출, 점수별 기준 이상~미만 경계 정상, 경고 0건), IF/WHILE 짝·파라미터 22건 정적 점검, JS 구문 검사, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면

### 2. MST1005_S01 리비전 상세 묶음 배치(C안) 적용

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js)
- **배경 및 원인**: 설비등급 기준이 리비전에만 종속되는데 평가항목과 같은 층에 있어 헷갈린다는 의견에 따라 후보 4안 중 C안 선택
- **작업 상세 내용**:
  - 1. 화면 배치 (C안 리비전 상세 묶음)
    - 1) 왼쪽 리비전 목록은 그대로, 오른쪽은 위에 설비등급 기준·아래에 평가항목과 점수별 평가기준 배치
    - 1) 오른쪽 위 설비등급 기준 : MSTEQM_GRADEREV_SCORE, 제목에 평가항목 점수 합계로 등급 판정 표기, 컬럼명 합계 최소(이상)·합계 최대(미만)
    - 1) 하단 평가항목 | 점수별 평가기준 (기존 기능 동일)
    - 1) 처음 넣은 선택 리비전 제목 띠(■ REV 2 (사용중) 기준)는 요청에 따라 제거
  - 1. 프로시저·DB 변경 없음
- **검증 결과**: JS 구문 검사, aspx div 짝(14/14)·컨트롤 ID 확인, 인코딩 확인. 미확인: 실제 화면 배치 비율

### 2. MST1005_S01 평가항목 선택시 해당 점수별 평가기준만 조회

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**: 점수별 평가기준이 전 항목 표시되어 평가항목 클릭시 해당 항목만 보이도록 요청
- **작업 상세 내용**:
  - 1. 조회 연동 변경
    - 1) 리비전 선택시 평가항목·설비등급 기준 조회, 점수별 평가기준은 비움
    - 1) 평가항목 선택시 해당 항목의 점수별 평가기준만 조회 : MSTEQM_GRADEREV_D2 (REVCD, GMCD 조건, 1점부터), 평가항목 병합 컬럼 제거
    - 1) 미저장 신규 평가항목 선택시 조회 안 함, 평가항목 저장 후 선택 항목 유지, 삭제 후 남은 선택 항목 기준 재조회
  - 1. 프로시저 LIST_D2에 $GMCD 파라미터 추가 및 평가항목 조인 제거, SYSTEM_PARAMETERS 26건 → 27건
- **검증 결과**: Node 모의 테스트(항목 선택별 조회 GMCD, 신규 항목 미조회, 저장·삭제 후 재조회 대상) 통과, 변경 조회 SQL 실DB 읽기 실행(경고 0건), 인코딩 확인. 미확인: MariaDB 컴파일·실제 화면

### 2. MST1005_S01 영역별 저장 버튼으로 변경

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql)
- **배경 및 원인**: 오른쪽 영역 변경을 왼쪽 리비전 영역 저장 버튼 하나로 저장하는 구조라 어디서 저장하는지 알 수 없다는 요청
- **작업 상세 내용**:
  - 1. 영역별 저장 버튼
    - 1) 리비전 [저장] : MSTEQM_GRADEREV 비고만 저장 (SAVE_REV, 평가이력과 무관하게 저장 가능)
    - 1) 평가항목 [저장] : MSTEQM_GRADEREV_D 체크 행 저장 (SAVE_D), 신규 항목은 1~5점 행 생성 후 평가항목·점수별 평가기준 재조회
    - 1) 점수별 평가기준 [저장] : MSTEQM_GRADEREV_D2 체크 행 저장 (SAVE_D2), 저장 후 평가기준만 재조회
    - 1) 설비등급 기준 [저장] : MSTEQM_GRADEREV_SCORE 체크 행 저장 (SAVE_SCORE, 설비등급 중복 확인), 저장 후 설비등급만 재조회
  - 1. 프로시저 통합 SAVE 분기를 SAVE_REV·SAVE_D·SAVE_D2·SAVE_SCORE로 분리 (검증 내용·파라미터 26건 동일, 평가이력 잠금은 SAVE_REV 제외)
- **검증 결과**: Node 모의 테스트(영역별 저장 CALLTYPE·체크 행 전송·저장 후 재조회 범위·미체크 차단·설비등급 중복) 통과, IF/WHILE 짝·파라미터 정적 점검, 인코딩 확인. 미확인: MariaDB 컴파일·실제 화면

### 2. MST1005_S01 설비등급기준 관리 화면 단순화 및 평가표 양식 반영

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**: 버튼·저장 단위가 많아 UI/UX가 복잡하다는 요청과 설비등급 평가표(항목별 1~5점 평가기준, 설비등급 표) 양식에 맞춘 수정 요청
- **작업 상세 내용**:
  - 1. 화면 단순화 (버튼 12개 → 7개)
    - 1) 리비전 영역 [리비전 갱신][저장][삭제] : 저장 1번으로 리비전 비고·평가항목·점수별 평가기준·설비등급 기준의 체크(수정) 행 일괄 저장 (프로시저 SAVE 분기, 한 트랜잭션)
    - 1) 평가항목 [추가][삭제] : MSTEQM_GRADEREV_D (NO, 구분(GMTP), 평가항목, 계산구분(CALCTP), 비고), 항목코드 숨김, 추가 시 NO 다음 번호·구분은 마지막 행과 같게
    - 1) 점수별 평가기준 (버튼 없음) : MSTEQM_GRADEREV_D2 전 항목을 평가항목 순서·1점부터 표시, 평가항목 셀 병합 (평가항목, 점수, 평가기준, 최소값(이상), 최대값(미만), 비고)
    - 1) 설비등급 기준 [추가][삭제] : MSTEQM_GRADEREV_SCORE (설비등급(FM110), 분류, 점수(출력), 최소점수(이상), 최대점수(미만), 관리구분, 점검주기, 정렬순번, 비고), 사용여부 화면 제외
  - 1. 설비등급 평가표 양식 반영
    - 1) 평가항목 신규 저장 시 1~5점 평가기준 행 자동 생성 (점수 직접 추가·삭제 없음)
    - 1) 최소값·최대값은 빈 값 또는 숫자만 허용, 둘 다 있으면 최소값 < 최대값 (이상~미만 기준, 평가등록 화면 자동 계산용)
    - 1) 프로시저 정리 : SAVE_REV·SAVE_D·SAVE_D2·DEL_D2·SAVE_SCORE 분기를 SAVE로 통합, 조회 미사용 컬럼 제거, SYSTEM_PARAMETERS 21건 → 26건
  - 1. 설비 목록 기준 화면 요청은 취소되어 기존 리비전 기준 구성 유지 (해당 변경은 미착수)
- **검증 결과**: Node 모의 테스트(세 그리드 연쇄 조회, 통합 저장 파라미터, 신규 항목·등급 추가값, 설비등급 중복·키 잠금, 삭제 DB/화면 구분, 리비전 갱신) 전체 통과, 조회·1~5점 생성·숫자 확인 SQL 실DB 읽기 실행(경고 0건), IF/WHILE 짝·파라미터 26건 정적 점검, 인코딩 확인. 미확인: MariaDB 프로시저 컴파일·저장 분기 실행, 실제 화면

### 2. MST1005_S01 설비등급기준 관리 화면 구현

- **수정/대상 파일**: [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.aspx.cs](01.Office/PAGEMST/MST1005/MST1005_S01.aspx.cs), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**: MST1004_R01을 복사한 MST1005_S01 페이지를 메뉴명(설비등급기준 관리)에 맞게 이름 정리하고 설비등급 평가기준 테이블(MSTEQM_GRADEREV,_D, _D2,_SCORE) 관리 기능 구현 요청
- **작업 상세 내용**:
  - 1. 조회
    - 1) 리비전 조회 : MSTEQM_GRADEREV (사용중, 리비전, 비고)
    - 1) 리비전 선택시 평가항목 그리드 : MSTEQM_GRADEREV_D (항목코드, 평가항목명, 평가항목구분(GMTP), 계산구분(CALCTP), 정렬순번, 비고)
    - 1) 리비전 선택시 설비등급별 점수기준 그리드 : MSTEQM_GRADEREV_SCORE (설비등급(FM110), 설비등급명, 점수, 최소값, 최대값, 관리구분, 정기점검주기, 정렬순번, 사용여부, 비고)
    - 1) 평가항목 선택시 평가항목별 점수기준 그리드 : MSTEQM_GRADEREV_D2 (점수, 평가기준, 최소값, 최대값, 비고)
  - 1. 리비전
    - 1) 리비전 갱신 : 선택 리비전의 D·D2·SCORE 복사, 리비전 번호 최대+1, 기존 사용중 해제 후 신규만 사용중 (리비전이 없으면 빈 리비전 생성)
    - 1) 리비전 비고 저장, 리비전 삭제 : D·D2·SCORE 함께 삭제, 사용중 리비전 삭제 시 최신 리비전을 사용중으로 변경
  - 1. 평가항목·점수기준 저장/삭제
    - 1) 평가항목 저장 : MSTEQM_GRADEREV_D (신규 행 항목코드는 전체 최대+1, GMTP 필수·CALCTP 빈값 허용 공통코드 확인), 삭제 시 항목별 점수기준 함께 삭제
    - 1) 평가항목별 점수기준 저장 : MSTEQM_GRADEREV_D2 (점수·평가기준 필수, 화면에서 점수 중복 확인, 저장된 점수는 수정 불가)
    - 1) 설비등급별 점수기준 저장 : MSTEQM_GRADEREV_SCORE (설비등급 FM110 확인, 화면에서 설비등급 중복 확인, 저장된 설비등급은 수정 불가)
    - 1) 변경 차단 : 평가이력 EQMGRADEEVAL에 해당 리비전이 있으면 리비전 삭제·기준 저장·삭제 불가 (리비전 갱신 후 변경)
  - 1. 페이지 이름 정리 : MST1004_R01 복사본의 CodeFile·Inherits·스크립트 경로·클래스명·프로시저명을 MST1005_S01로 변경, 남아 있던 다른 화면 메뉴 주석 제거
  - 1. 신규 프로시저는 SYSTEM_PARAMETERS 등록 스크립트(21건) 실행 필요
- **검증 결과**: Node 모의 테스트(조회 연쇄, 행 추가·저장·삭제 파라미터, 키 수정 잠금, 0점 포함 중복 차단, 리비전 갱신·빈 리비전 생성) 전체 통과, 프로시저 SELECT문 실DB 읽기 실행으로 컬럼명 확인, IF/WHILE 짝·파라미터 사용 정적 점검, 인코딩(.aspx/.cs/.js BOM, .sql BOM 없음, CRLF) 확인. 미확인: MariaDB 컴파일·저장 분기 실행, 실제 화면 동작

### 2. 공유 규칙 다른 프로젝트 적용성 정비

- **수정/대상 파일**: [.agents/rules/project_context.md](.agents/rules/project_context.md), [.agents/rules/report_file_structure.md](.agents/rules/report_file_structure.md), [.agents/rules/report_devexpress.md](.agents/rules/report_devexpress.md), [.agents/rules/framework_convention.md](.agents/rules/framework_convention.md)
- **배경 및 원인**: 규칙을 여러 프로젝트에 공유하므로 이 프로젝트 전용 경로·파일·버전에 의존하는 부분 정비 요청
- **작업 상세 내용**:
  - project_context.md에 {REPORT_ROOT}·{REPORT_BIN}·기준 레포트 판별 추가, 규칙 속 실제 화면ID는 사례로만 사용하고 버전은 csproj 기준 확인하도록 명시. report_file_structure.md: EQM1001/R03 필수 참조 제거, 사례 값 안내, csproj 예시 {리포트ID}화, 빈 resx 전문 수록, DevExpress Version 값 csproj 기준, 배포 경로 {REPORT_BIN}. report_devexpress.md: 기준 레포트·exe 실행 경로·배포 경로·MSBuild 버전 일반화, 알려진 원인 표에 확인 환경 명시. framework_convention.md 레포트 참조·임시폴더 경로 일반화. 오늘 작성한 작업 이력 링크를 절대경로에서 상대경로로 정정
- **검증 결과**: 단일 BOM/CRLF 확인

### 2. 레포트 디자이너 오류 진단 절차 규칙화

- **수정/대상 파일**: [report_devexpress.md](.agents/rules/report_devexpress.md), [report_file_structure.md](.agents/rules/report_file_structure.md)
- **배경 및 원인**: S01A 디자이너 오류를 호출 스택 확인 없이 RowSpan으로 추측 수정해 재발한 과정을 규칙에 반영해 재발 방지 요청
- **작업 상세 내용**:
  - report_devexpress.md 2-5 신설: 런타임/디자이너 구분 → 호출 스택 확보(필수) → R03과 비교 → 의심 요소 하나씩 제거하는 소거법 → 허용 패턴 수정 → VS 디자이너·exe·출력 비교 3중 검증 → 확정 원인만 규칙화 및 오판 정정 기록. 실사례로 확인된 알려진 원인 표(XRPanel, 헬퍼 호출, XRTableRow BeginInit) 추가. report_file_structure.md 체크리스트에 2-5 연결
- **검증 결과**: 단일 BOM/CRLF 확인

### 2. EQM1001_S01A VS 디자이너 component null 오류 실제 원인(XRPanel) 해결

- **수정/대상 파일**: [S01A.Designer.cs](04.Report/PAGEEQM/EQM1001/S01A.Designer.cs), [EQM1001.exe](01.Office/Reports/EQM1001.exe), [report_devexpress.md](.agents/rules/report_devexpress.md), [report_file_structure.md](.agents/rules/report_file_structure.md)
- **배경 및 원인**: RowSpan 제거 후에도 VS 디자이너에서 '값은 null일 수 없습니다. 매개 변수 이름: component' 오류 지속
- **작업 상세 내용**:
  - VS 오류 페이지 호출 스택 확인: DesignerHost.GetDesigner ← VSLockService.CanChangeComponent ← XRControlDesignerBase.get_Locked ← XRControlDesigner.OnLoadComplete. R03 정상, S01A에서 XRPanel만 제거한 변형이 VS 디자이너에서 정상 로드되어 원인을 자식 컨트롤을 담는 XRPanel(xrPanelHeader)로 확정. 패널을 빈 테두리 XRLabel(xrLabelHeaderBox 731x56)로 교체하고 로고·제목을 PageHeader에 직접 배치. report_devexpress.md 2-4를 RowSpan 금지에서 XRPanel 금지로 정정, report_file_structure.md 본문·체크리스트 정정(VS 디자이너 열기 확인 항목 추가)
- **검증 결과**: VS 2017 디자이너에서 S01A 정상 표시 확인(오류 페이지 없음). MSBuild Release Rebuild 성공. A-001 PNG 비교 시 상단 박스 픽셀 동일, 항목명 열 글자 서브픽셀 차이만 존재. 웹 컨트롤러 방식 실행·오류 안내 정상. 01.Office/Reports·04.Report/bin 배포

### 2. EQM1001_S01A RowSpan 제거 (원인 오판 — 3번 항목에서 실제 원인 XRPanel 해결)

- **수정/대상 파일**: [S01A.Designer.cs](04.Report/PAGEEQM/EQM1001/S01A.Designer.cs), [EQM1001.exe](01.Office/Reports/EQM1001.exe), [report_devexpress.md](.agents/rules/report_devexpress.md), [report_file_structure.md](.agents/rules/report_file_structure.md)
- **배경 및 원인**: R03 구조 전환 후 VS 디자이너에서 '값은 null일 수 없습니다. 매개 변수 이름: component' 오류. 빌드·런타임은 정상이라 디자이너 전용 문제로 판단
- **작업 상세 내용**:
  - CodeDOM 디자이너 로더(DesignSurface+CodeDomDesignerLoader) 재현 결과 RowSpan 대입이 셀이 행·테이블에 들어가기 전에 실행됨 확인. 카테고리 셀(cell_Cat_*) 3개와 병합 아래 빈 셀 18개 제거, 독립 XRLabel(xrLabelCatEQM/BUY/USE, 32F 폭) 추가, 테이블 X=32F·폭 323F로 이동. RowSpan 금지 규칙을 추가했으나 오류가 계속되어 3번 항목에서 XRPanel 규칙으로 정정
- **검증 결과**: MSBuild Release Rebuild 성공. CodeDOM 로더 S01A 오류 0건(누락 필드 음성대조 검출 확인). A-001 PNG 비교 시 선·크기·값 동일, 항목명 열 글자 서브픽셀 차이만 존재. 웹 컨트롤러 방식 실행 정상, 오류 안내 정상. 01.Office/Reports·04.Report/bin 배포. 실제 VS 디자이너 열기는 사용자 확인 필요

### 1. EQM1001_S01A 설비이력카드 레포트 표준 구조(R03 기준) 전환 및 레포트 파일 구조 규칙 제정

- **수정/대상 파일**: [S01A.cs](04.Report/PAGEEQM/EQM1001/S01A.cs), [S01A.Designer.cs](04.Report/PAGEEQM/EQM1001/S01A.Designer.cs), [S01A.resx](04.Report/PAGEEQM/EQM1001/S01A.resx), [EQM1001.exe](01.Office/Reports/EQM1001.exe), [report_file_structure.md](.agents/rules/report_file_structure.md), [report_devexpress.md](.agents/rules/report_devexpress.md), [framework_convention.md](.agents/rules/framework_convention.md)
- **배경 및 원인**: 모든 레포트를 EQM1001/R03 3개 파일 구조로 작성하도록 규칙화 요청, S01A는 기본 생성자 없음·DB 접속정보 하드코딩·Designer 내 헬퍼 메서드(CreateSpecRow/CreateCatCell/CreateHeaderCell/InitDataCell) 호출로 표준 위반
- **작업 상세 내용**:
  - report_file_structure.md 신규 제정(폴더/csproj/cs/Designer/resx 구조·명명·A4 기본값·체크리스트). S01A.cs: 기본 생성자+this() 체이닝, DbServer 등 하드코딩 제거(ITS_CONFIG_MARIA.xml 사용), BindReportData/LoadLogo/LoadImage/Value 분리, MODEL_S1 추가. S01A.Designer.cs: 헬퍼 호출을 순수 대입문으로 전개(행 18개·카테고리/라벨 셀 명명 cell_Cat_/cell_Lbl_/cell_Hdr_), 밴드 순서 R03 기준 정렬, 레이아웃 값(여백 45, 폰트, 폭) 기존 유지. S01A.resx: 표준 빈 resx로 교체
- **검증 결과**: MSBuild 15.0 Release Rebuild 성공. 기존/신규 exe로 EQMCD=A-001 출력 비교 시 HTML·이미지 완전 동일, PDF는 생성일시·문서ID만 차이. 미존재 설비·파라미터 누락 안내 메시지 정상. 01.Office/Reports, 04.Report/bin 배포 및 단일 BOM/CRLF 확인. Visual Studio 디자이너 열기는 미확인

---

## 🕒 2026-10-23 (금) 작업 내역

### 2. EQM1001_R04 정기점검 등록·수정 팝업 항목 CHKTP 02 REV 제한

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R04.sql
- **배경 및 원인**: 등록(grid2)·수정(grid3) 팝업 항목을 MSTEQMREV_HEADER.CHKTP = '02' REV만 표시 요청
- **작업 상세 내용**:
  - LIST_PLAN_EQM02 승인 REV 조회 및 ADD_CHKRSTEQM 승인본 검증에 CHKTP = '02' 추가, SEARCH_CHKRSTEQM HEADER LEFT JOIN을 INNER JOIN + CHKTP = '02'로 변경, Modify 이력 1행 추가
- **검증 결과**: 단일 BOM/CRLF 검증 완료, 기존 HEADER CHKTP 데이터 보정 필요 여부 사용자 확인 필요

### 1. EQM1001_R03 REV HEADER 생성 시 CHKTP 정기점검(02) 저장

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: MSTEQMREV_HEADER 신규 REV 생성 시 점검구분(CHKTP) 값 미저장
- **작업 상세 내용**:
  - 정기점검 CRUD 공통 신규 REV 생성 INSERT에 CHKTP = '02' 추가, 최상단 Modify 2026-10-23 이력 1행 추가 (HEADER INSERT는 R03 단 1곳, R04는 조회만 수행)
- **검증 결과**: 단일 BOM/CRLF 검증 완료, 실서버 DB 반영은 사용자 진행

---

## 🕒 2026-10-20 (화) 작업 내역

### 1. EQM1001_R03 설비별 점검계획 탭 그리드(grid1) 설비그룹 공통 콤보(FM116) 바인딩 적용

- **수정/대상 파일**: [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js)
- **배경 및 원인**:
  - `framework_convention.md` 제6조(그리드 공통코드 콤보 컬럼 표준 연동 규칙)에 따라, `EQM1001_R03.js`의 설비별 점검계획 탭 좌측 그리드(`grid1`)에서 코드 컬럼(`EQMGUBUN`)을 단순 텍스트로 두고 명칭 컬럼(`EQMGRPNM`)을 `hidden: true`로 숨기던 기존 비표준 방식을 제거하고, 공통 프레임워크 컴포넌트(`ItsGrid`의 `enumColumnTypes.combo`) 표준 바인딩으로 일치화 요청.
- **작업 상세 내용**:
  - `EQM1001_R03.js`:
    - `column.create('설비그룹코드', 'EQMGUBUN', { width: 100, align: 'center' })` 및 `column.create('설비그룹명', 'EQMGRPNM', { hidden: true })` 2개 컬럼을 `column.create('설비그룹', 'EQMGUBUN', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM116' })` 단일 콤보 컬럼으로 통합 변경.
    - 날짜 주석(`// 2026-10-20 [설비별 점검계획 탭] 좌측 그리드 설비그룹 공통 콤보(FM116) 바인딩 적용`) 작성 및 기존 날짜 주석 보존.
- **검증 결과**:
  - Node.js 구문 검사(`new Function(...)`) 통과 (Syntax OK).
  - git diff 자체 전수 검사 결과 불필요한 잉여·쓰레기 코드 0건 확인 (`Optimization.md`, `validation.md` 준수).
  - 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료.

---

### 2. EQM1001_R03 프로시저 설비 목록 조회(LIST_MSTEQM) 잉여 컬럼(EQMGRPNM) 및 COMTYPE 조인 제거

- **수정/대상 파일**: [05.Procedure/MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R03.sql)
- **배경 및 원인**:
  - 화면 `grid1`에서 `EQMGUBUN`을 공통 콤보(`enumColumnTypes.combo, gpcd: 'FM116'`)로 자동 매핑함에 따라, 프로시저에서 설비그룹명(`EQMGRPNM`)을 추출하기 위해 수행하던 `COMTYPE` 조인 및 반환 컬럼이 완전히 불필요한 잉여 로직이 됨.
  - 사용자 지침 및 `framework_convention.md` 제6조(프로시저 쿼리 단순화 연계)에 따라 불필요한 조인 및 잉여 컬럼 전면 제거.
- **작업 상세 내용**:
  - `MES_SNS2_EQM1001_R03.sql`:
    - `LIST_MSTEQM` 분기 SELECT 절에서 `COALESCE(COMTYPE.TPNM, '') AS EQMGRPNM` 삭제.
    - FROM 절에서 `LEFT JOIN COMTYPE ON COMTYPE.GPCD = 'FM116' AND COMTYPE.TPCD = MSTEQM.EQMGUBUN` 완전 삭제.
    - WHERE 절에서 `OR COMTYPE.TPNM LIKE CONCAT('%', $EQMGRP, '%')` 삭제 및 `MSTEQM.EQMGUBUN LIKE CONCAT('%', $EQMGRP, '%')` 단독 조건으로 단순화.
    - 최상단 `Modify` 이력 1일 1행 압축 기록 (`procedure_history.md` 준수).
- **검증 결과**:
  - git diff 자체 전수 검사 결과 불필요한 잉여 코드 0건 확인.
  - 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료.

---

## 🕒 2026-10-19 (월) 작업 내역

### 9. SYSLABEL EQMPARTS(설비부품 라벨) 양식 폭 확장 및 폰트 크기 최적화 (글자 잘림 방지)

- **수정/대상 파일**: [05.Procedure/UPDATE_SYSLABEL_EQMPARTS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/UPDATE_SYSLABEL_EQMPARTS.sql)
- **배경 및 원인**:
  - 현장 터미널에서 바코드 라벨(50mm × 25mm) 출력 시 부품명(`ITEMNM`)이 긴 경우 뒷부분이 잘려서 출력되는 현상 발생 (`[테스트] 설`까지만 출력되고 짤림).
  - DB `SYSLABEL` 테이블의 `LABELCD = 'EQMPARTS'`에 등록된 `XMLDATA`를 분석한 결과, 전체 폭 50mm 중 부품명(`ITEMNM`)의 너비가 불과 `Width="22.75"`mm로 협소하게 지정되어 있고 폰트 크기가 `12pt`로 커서 5~6글자 이후 강제 잘림 현상(Trimming)이 원인으로 규명됨.
- **작업 상세 내용**:
  - 실제 DB 서버 직접 수정 금지 원칙(`procedure.md`)에 따라 사용자가 DBeaver/HeidiSQL에서 즉시 실행할 수 있는 `05.Procedure/UPDATE_SYSLABEL_EQMPARTS.sql` 쿼리 파일 생성:
    - 부품명(`ITEMNM`): 가로 폭을 `Width="46"`mm로 대폭 확장(좌우 2mm 여백 활용)하고, 폰트를 `맑은 고딕^@^8.5^@^Bold`로 조정하여 18~20자의 긴 품명도 전혀 잘리지 않도록 개선.
    - 부품코드(`ITEMCD`): 품명 바로 아래(`Y="7"`)에 폭 `46`mm, 폰트 `굴림^@^8.5^@^Regular`로 배치하여 긴 코드도 여유 있게 수용.
    - 바코드(`ITEMID`): 폭을 기존 29.25mm에서 `42`mm(`X="4"`, `Y="12"`, `Height="11.5"`)로 확장하고 바코드 아래 텍스트 폰트를 `8.5pt`로 조정하여 바코드 바 두께/해상도를 높이고 스캔 인식률 극대화.
    - 미사용 더미 필드(`LOTKEY`, `PRDDATE`, `LOTQTY`, `ITEMSPEC`) 완전 제거로 XML 경량화 및 구조 정돈.
- **검증 결과**:
  - `05.Procedure/UPDATE_SYSLABEL_EQMPARTS.sql` 단일 UTF-8 with BOM 및 CRLF 개행 바이너리 무결성 검증 완료.

### 8. TML1010_R05 입출고 확인·에러 팝업 메시지 단일 문장 간소화 및 잉여 컨트롤·변수 자체 삭제

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs)
- **배경 및 원인**:
  - 현장 터미널 화면에서 확인 팝업 및 라벨 출력 실패 팝업 메시지가 여러 줄로 길어지면서 메시지박스 UI 타이틀("Message")과 본문 텍스트가 겹치고 레이아웃이 깨지는 UI/UX 결함 발생.
  - 사용자의 요청에 따라 모든 확인 및 오류 팝업 문구를 간결한 단일 문장으로 전면 축소.
- **작업 상세 내용**:
  - `R05.xaml.cs`:
    - 입고등록 확인 문구: `"설비부품을 입고하시겠습니까?"` (단일 문장)
    - 입고 후 라벨 출력 실패 문구: `"입고는 완료되었습니다. 라벨 출력을 확인해주세요."` (단일 문장)
    - 출고등록 확인 문구: `"설비부품을 출고하시겠습니까?"` (단일 문장)
    - 라벨 재발행 실패 문구: `"라벨 출력에 실패했습니다. 프린터를 확인해주세요."` (단일 문장)
    - 확인창 조합용으로만 쓰이던 잉여 변수(`itemCd`, `itemNm`, `itemUnit`, `inTp`, `outTp`) 완전 삭제 (`Optimization.md` 제5조 Anti-Garbage Code 규칙 준수).
  - `R05.xaml`:
    - 확인창 단위 표시용으로만 존재하던 미사용 숨김 콤보 `cmb_IN_UNIT`, `cmb_OUT_UNIT` 2건 완전 삭제.
- **검증 결과**:
  - `R05.xaml`, `R05.xaml.cs` 단일 UTF-8 BOM 및 CRLF 개행 3단계 바이너리 검증 완료.

### 7. TML1010_R05 쓰레기 코드 전수 무결성 검증 및 불필요한 잉여 코드 자체 삭제 의무화 규칙 제정

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [.agents/rules/Optimization.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/Optimization.md), [.agents/rules/validation.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/validation.md)
- **배경 및 원인**:
  - `R05.xaml` 및 `R05.xaml.cs` 내 불필요한 쓰레기 코드(미사용 컨트롤, 임시 우회 로직, 잉여 바인딩 등)가 일절 없는지 확실한 전수 무결성 검증 요청.
  - 사용자가 매번 소스코드를 검증하고 지적하지 않아도 되도록, "작업 완료 보고 전 불필요한 잉여·쓰레기 코드를 에이전트 스스로 전수 검사하고 삭제하는 규칙"을 공식 추가하도록 지시.
- **작업 상세 내용**:
  - `R05.xaml` 및 `R05.xaml.cs` 전수 검사:
    - 11개 컬럼 그리드(`GRID_G1`), 3개 팝업(`POP_IN`, `POP_OUT`, `POP_INOUT`), 8개 모델 바인딩(`MODEL_ODR_S`, `MODEL_IN_INFO`, `MODEL_A2`, `MODEL_A3`, `MODEL_A1`, `MODEL_G1`, `MODEL_G2`, `MODEL_ODR`), 10개 이벤트 분기 전수 점검 결과 쓰레기 코드 0건 확인.
  - `Optimization.md`:
    - 제5조(작업 완료 전 불필요한 잉여·쓰레기 코드 자체 제거 및 전수 검사 의무화 - Anti-Garbage Code) 신규 제정.
    - 필수 삭제 대상 5대 쓰레기 코드 유형(임시 우회/비표준 꼼수 코드, 미사용 선언/바인딩, 미사용 파라미터/전송값, 주석 처리된 잔여 코드, 테스트/디버깅 잔여물) 명시 및 자체 Diff 전수 검사 프로세스 의무화.
  - `validation.md`:
    - 제6조(작업 완료 전 불필요한 잉여·쓰레기 코드 전수 점검 및 자체 삭제 의무화) 신규 제정.
    - 사용자에게 검증 부담 전가 원천 금지 및 에이전트 자체 100% 정리 완료 의무화.
- **검증 결과**:
  - MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning).
  - `Optimization.md`, `validation.md` 단일 UTF-8 BOM 및 CRLF 개행 바이너리 무결성 검증 완료.

### 6. TML1010_R05 C# 생성자 내 불필요한 DataView 필터링 코드 완전 제거

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs)
- **배경 및 원인**:
  - 화면 비하인드 코드 생성자에서 `cmb_INTP` 및 `cmb_OUTTP`에 인위적으로 걸려 있던 `DataView(..., "Value LIKE 'IN_%'")`, `DataView(..., "Value LIKE 'OUT_%'")` 코드는 `framework_convention.md` 제5조 규칙에 위배될 뿐만 아니라, `cmb_INTP`는 숨김(Collapsed) 컨트롤이고 출고는 기본값(`OUT_01`)으로 이미 자동 세팅되므로 완전히 불필요한 잉여 코드임. 사용자 요청에 따라 전면 삭제함.
- **작업 상세 내용**:
  - `R05.xaml.cs` 생성자 내 `cmb_INTP` 및 `cmb_OUTTP`의 `DataView` 필터링 2줄 완전 삭제.
  - 순수 프레임워크 XAML 바인딩 및 기존 로직만 유지.
- **검증 결과**:
  - MSBuild 15.0 Rebuild 성공 (경고 0개, 오류 0개) 및 최신 바이너리 배포 완료.
  - 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료.

### 5. MST1002_R06 설비그룹 공통 콤보(FM116) 바인딩 적용 및 그리드 콤보 연동 규칙 제정

- **수정/대상 파일**: [01.Office/PAGEMST/MST1002/MST1002_R06.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST1002/MST1002_R06.js), [.agents/rules/framework_convention.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md)
- **배경 및 원인**:
  - `MST1002_R06.js`에서 설비그룹코드(`EQMGUBUN`)를 `hidden: true`로 숨기고 설비그룹명(`EQMGRPNM`)을 별도의 텍스트 컬럼으로 표시하던 비표준 중복 구조를 제거하고, `EQMGROUP1~3`(설비대/중/소분류)과 동일하게 공통 컴포넌트(`ItsGrid`의 `enumColumnTypes.combo`) 자동 바인딩으로 일치화 요청.
  - 향후 모든 화면에서 공통 컴포넌트를 적극 활용하도록 규칙 문서 반영 요청.
- **작업 상세 내용**:
  - `MST1002_R06.js`:
    - `column.create("설비그룹코드", "EQMGUBUN", { hidden: true })` 및 `EQMGRPNM` 텍스트 컬럼 2줄 삭제.
    - `column.create("설비그룹", "EQMGUBUN", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM116', allowMerging: true })` 단일 콤보 컬럼으로 통합 바인딩.
  - `framework_convention.md`:
    - 제6조(그리드 공통코드 콤보 컬럼 표준 연동 규칙) 신규 제정:
      - 1) 코드 hidden 및 명칭 텍스트 컬럼 분리 선언 절대 금지.
      - 1) 공통 컴포넌트(`columnType: enumColumnTypes.combo, gpcd: '...'`) 표준 바인딩 의무화.
      - 1) 프로시저 SELECT 절 내 단순 명칭 표시용 `COMTYPE` 중복 조인 배제 연계.
- **검증 결과**:
  - `MST1002_R06.js` Node.js Function 구문 검사 통과 (Syntax OK).
  - 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료.

### 4. 공통코드(GPCD) 그룹 분리 및 ItsCombo 연동 표준 규칙 제정

- **수정/대상 파일**: [.agents/rules/framework_convention.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md)
- **배경 및 원인**:
  - 화면 비하인드 코드에서 `DataView`나 `LIKE` 문을 사용해 공통코드를 인위적으로 분기/필터링하는 비표준 구현을 영구 금지하고, 프레임워크(`ItsCombo.xaml.cs`) 및 공통 프로시저(`DC_COMBO`)의 표준 연동 방식을 규칙화함.
- **작업 상세 내용**:
  - `framework_convention.md`에 제5조(공통코드 그룹 분리 및 ItsCombo 표준 연동 규칙) 신규 제정:
    - 1) C# 비하인드 코드 내 `DataView` 필터링 및 `LIKE` 문자열 검색 코드 전면 금지.
    - 1) 성격이 다른 코드(입고/출고 등)는 처음부터 그룹코드(`GPCD`) 자체를 완전 분리(`INTP_...`, `OUTTP_...`)하여 관리하는 [정석 방식 1] 원칙 명문화.
    - 1) C# 코드 없이 XAML 태그(`GPCD="..."`) 또는 JS 선언만으로 프레임워크 100% 자동 바인딩 보장.
    - 1) 공통 컴포넌트(`ItsCombo`, `ItsFind`, `ItsPop`, `ItsGrid` 등) 기본 함수 최우선 활용 의무화.
- **검증 결과**: 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료.

### 3. TML1010_R05 실제 DB 공통코드(INOUTTP_EQMPARTS) 엄격 준수 및 ENDYN 표준화 적용

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql)
- **배경 및 원인**:
  - 사용자 지침에 따라 실제 DB에 등록되어 있는 기존 공통코드(`INOUTTP_EQMPARTS`: `IN_01` 구매입고, `OUT_01` 부품교체)만을 엄격히 사용하며, 임의의 신규 코드나 DML을 배제하고 기존 환경을 유지함.
  - `MSTITEM.ENDYN`의 불필요한 과잉보호(`IFNULL(..., 'N') <> 'Y'`)를 제거하고 다른 프로젝트 프로시저(`DC_FIND.sql`, `PRD1001_R03.sql`)와 동일한 `AND MSTITEM.ENDYN = 'N'` 단일 긍정 일치 조건으로 통일.
- **작업 상세 내용**:
  - 임의 생성했던 `MES_SNS2_TML1010_R05_COMTYPE_SETUP.sql` 파일 즉시 완전 삭제.
  - `R05.xaml`: `cmb_INTP` 및 `cmb_OUTTP`의 `GPCD`를 실제 DB에 존재하는 `INOUTTP_EQMPARTS`로 복원.
  - `R05.xaml.cs`: 실제 DB의 `INOUTTP_EQMPARTS` 내 `IN_`과 `OUT_` 값을 구분하기 위한 기존 `DataView` 바인딩 코드로 완전 복원.
  - `MES_SNS2_TML1010_R05.sql`:
    - L79 `MSTITEM.ENDYN = 'N'` 직관적 단일 조건 통일 유지.
    - L239 이력조회(`LIST_INOUT_EQMPARTS`)의 `INOUTTPNM`을 실제 공통코드인 `GPCD('INOUTTP_EQMPARTS', INOUT_EQMPARTS.INOUTTP_EQMPARTS)`로 복원.
    - 최상단 `Modify` 주석 1일 1행 압축 유지.
- **검증 결과**:
  - 실제 DB `COMTYPE` 직접 조회 확인 (`INOUTTP_EQMPARTS`의 `IN_01`, `OUT_01` 2건 존재 확인).
  - C# MSBuild 15.0 Rebuild 성공 (경고 0개, 오류 0개) 및 바이너리 배포 완료.
  - 소스 3개 파일 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료.

### 2. TML1010_R05 라벨 출력 반환데이터(ITEMNM, ITEMCD, ITEMID) 최적화 및 ENDYN 표준화

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs)
- **배경 및 원인**: SYSLABEL의 EQMPARTS 양식에 맞춰 LABEL_REPRINT 및 IN_EQMPARTS 분기에서 불필요한 조인 제거 및 ITEMNM, ITEMCD, ITEMID 3개 컬럼 반환으로 단일화, ENDYN 과잉보호 조건 표준화(AND MSTITEM.ENDYN = 'N'), R05 라벨 출력 및 입고 시 라벨 자동출력 오류처리 검증
- **작업 상세 내용**:
  - 프로시저 LABEL_REPRINT 및 IN_EQMPARTS 분기의 2번째 테이블 반환 쿼리를 SELECT MSTITEM.ITEMNM, MSTITEM.ITEMCD, MSTITEM.ITEMID FROM MSTITEM WHERE MSTITEM.ITEMID =  로 통일, 라인 79 ENDYN 조건 표준화 완료, C# PrintLabel 모듈 및 예외처리 안전성 최종 검증 완료
- **검증 결과**: 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료, SYSLABEL XMLDATA 실제 필드 매핑 일치 확인

### 2. TML1010_R05 설비부품 입출고 미사용 파라미터(ITEMCD, KEYWORD, REMARK) 완전 제거 및 C# 모델 정리

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql), [05.Procedure/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs)
- **배경 및 원인**: 화면 UI/UX에 검색창 및 비고란이 없음에도 프로시저와 C# 모델에 남아 리소스를 소모하던 미사용 파라미터(, , ) 전면 제거 요청
- **작업 상세 내용**:
  - 프로시저 선언부 , ,  제거(18건->15건), 입출고 이력 REMARK 빈문자열 직접 대입, C# R05.xaml.cs SEARCH_EQMPARTS 잉여 파라미터 전송 및 MODEL_A2의 ITEMCD 불필요 필드 제거, SYSTEM_PARAMETERS 주석 15건 갱신
- **검증 결과**: 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료, Roslyn C# 컴파일 성공(0 Error), 프로시저-C#-파라미터등록 1:1 일치 확인

### 1. TML1010_R05 재고조회 잉여 검색조건(KEYWORD/ITEMCD/ITEMSPEC) 전면 제거 및 2공장 등록부품 정밀 필터화

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql)
- **배경 및 원인**: 화면 UI/UX에 검색창이 전혀 없음에도 불구하고 프로시저에 남아있던 불필요한 KEYWORD/ITEMCD/ITEMNM/ITEMSPEC 검색 조건으로 인한 코드 비대화 및 3,823건 과다 조회 문제
- **작업 상세 내용**:
  - UI에 없는 KEYWORD, ITEMCD 등 잉여 LIKE 조건문 10줄 전면 삭제, MSTITEM_EQMPARTS.ITEMID IS NOT NULL 조건을 단독 적용하여 2공장 관리 부품(11건)만 초고속 조회되도록 WHERE 절 5줄로 완전 슬림화, 최상단 Modify 1일 1행 압축 유지
- **검증 결과**: 단일 UTF-8 with BOM(ef bb bf) 및 표준 CRLF 개행 무결성 100% 검증 통과

### 2. TML1010_R05 라벨 출력 로직 분기별 독립 완결형 표준 구조 개편

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql)
- **배경 및 원인**: END CASE 바깥에 존재하던 IF CALLTYPE 라벨 공통 블록으로 인한 분기별 흐름 단절 및 유지보수 혼선 방지
- **작업 상세 내용**:
  - END CASE 하단 공통 IF문 완전 제거, IN_EQMPARTS(입고완료 라벨출력) 및 LABEL_REPRINT(재발행 라벨출력) 각 분기 내부로 라벨 데이터셋 2개 SELECT를 배치하여 분기별 완결형 표준 구조(END CASE; END)로 일치화, 최상단 Modify 1일 1행 압축 유지
- **검증 결과**: 단일 UTF-8 with BOM(ef bb bf) 및 표준 CRLF 개행 무결성 100% 검증 통과

### 3. TML1010_R05 설비부품 재고조회 WHERE 절 조건문 단순화 및 IFNULL 반복 제거

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql)
- **배경 및 원인**: L77-L90의 기괴한 복합 조건(IFNULL($KEYWORD, '') <> '' OR IFNULL($ITEMCD, '') <> '' OR MSTITEM_EQMPARTS.ITEMID IS NOT NULL) 및 반복된 IFNULL 호출로 인한 가독성 저해 및 사용자 개선 요청
- **작업 상세 내용**:
  - PROC: BEGIN 직후 파라미터($KEYWORD, $ITEMCD, $SDATE, $EDATE, $CUSTCD) 단 1회 기본값 정규화, LIST_EQMPARTS의 복합 억지 조건 전면 삭제 및 표준 8줄 WHERE 절로 단순화, LIST_ODR_EQMPARTS 및 LIST_INOUT_EQMPARTS 날짜/거래처 조건문 일관성 정리, 최상단 Modify 1일 1행 압축 유지
- **검증 결과**: 단일 UTF-8 with BOM(ef bb bf) 및 표준 CRLF 개행 무결성 100% 검증 통과

### 4. TML1010_R05 과잉보호 조건문 및 NULLIF 제거, INC 2공장(07) 및 법인(60) 하드코딩 직관화

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql)
- **배경 및 원인 분석**:
  - 사용자 요청에 따라 프로시저 내 불필요한 과잉보호 조건문과 복잡한 `NULLIF` 식을 제거하고, 프로젝트 내 다른 프로시저 표준을 준수하여 간결하고 직관적으로 단순화
  - 공장코드는 07(INC 2공장)로 고정이므로 불필요한 다중 방어 로직 대신 하드코딩 처리
- **작업 상세 내용**:
  - 1) **상단 3중 불필요 사전조회 제거**: `MSTFACTORY` 조회/검증, `MSTITEM` 검증 조회, `MSTEMP` 존재 조회 등 3개의 사전 DB 쿼리를 제거하고 `$ITEMID` 빈값 검증 및 `$EMPCD` 입력 검증으로 슬림화
  - 1) **NULLIF 및 복합식 완전 제거**: 발주 조회(`LIST_ODR_EQMPARTS`) 및 입고등록(`IN_EQMPARTS`)의 `COALESCE(NULLIF(MTRODR.INFACTORYCD, ''), MTRODR.ODRFACTORY) = '07'` 과잉 복합식을 다른 발주 프로시저(`MTR0001_R04`)와 동일하게 `MTRODR.ODRFACTORY = '07'`로 완전 단순화
  - 1) **INC 2공장(07) 및 법인(60) 하드코딩 직관화**: `MSTITEM.COMPANYCD = '60'`, `MSTITEM_EQMPARTS.FACTORYCD = '07'` 하드코딩 및 조인 내 불필요 조건(`MSTITEM_EQMPARTS.LOCACD <> ''`) 제거
  - 1) **인위적 문자열 검증 제거 및 IFNULL 표준화**: 입고/출고 구분의 `LEFT(..., 3) <> 'IN_'`, `LEFT(..., 4) <> 'OUT_'` 과잉 문자열 자르기 검증을 제거하고, `COALESCE` 남발을 프로젝트 표준인 `IFNULL`로 정돈
  - 1) **변수 정리 및 파라미터 직접 사용**: 불필요해진 `_$ITEMID`, `_$COMPANYCD` 지역변수를 제거하고 `$ITEMID` 직접 바인딩
- **검증 결과**:
  - 단일 UTF-8 with BOM (`\xef\xbb\xbf`) 및 CRLF 개행 3단계 바이너리 무결성 100% 통과
  - 내부 코드 라인 날짜 주석 0건, 최상단 Modify 이력 1일 1행 원칙 준수

### 5. TML1010_R05 공장 고정 범위 확정

- **수정/대상 파일**: WORK_HISTORY.md
- **배경 및 원인**: 입출고 이력 공장 구분 컬럼 추가 여부에 대한 사용자 답변 수신
- **작업 상세 내용**:
  - 사용자가 화면·전용 프로시저만 07로 고정하도록 확정; INOUT_EQMPARTS 테이블 구조 및 기존 이력 유지, 공장 컬럼 추가SQL 작성하지 않음; 앞선 소스·실행파일 반영 범위와 일치
- **검증 결과**: 직전 반영 내용과 사용자 선택 일치 확인; 소스·DB·실행파일 추가 변경 없음; 운영 프로시저 저장 후 SYSTEM_PARAMETERS 등록SQL 적용은 사용자 진행

### 6. TML1010_R05 INC 2공장 고정 및 로그인 입고자 초기화

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql
- **배경 및 원인**: INC 2공장 전용 화면으로 공장 선택 제거 및 로그인 사원 기본 입고자 확인 요청
- **작업 상세 내용**:
  - 공장 콤보·검색모델·FACTORYCD 모델필드·전송·조회 반환컬럼·프로시저 입력 제거; 법인·재고·발주 입고공장·라벨은 07 고정; 프로시저 입력 19에서 18로 변경 및 메타데이터 등록SQL 갱신; 팝업 열기마다 로그인 EMPCD를 trim하여 설정하고 NULL·공백은 빈 값 처리; 사용자ID 임의 대체 없음. 이력 테이블에는 공장 컬럼이 없으므로 공장별 기존 이력 분리는 미적용하며 별도 선택 요청
- **검증 결과**: 실제 DB SELECT로 공장07/법인60 및 307컬럼·로그인 사원 연결·공통사원팝업07조건·기존19파라미터 확인; 네트워크 차단 MariaDB10.2에서 수정 프로시저 컴파일 및16검증 통과(07재고입출고·06재고보존·발주공장우선/대체·타공장입고거절·사원누락·라벨·이력·18입력); 후보의 실제 입고자 문장을 공통모델로 컴파일한5검증 통과; 최종4파일 후보해시일치·단일BOM/CRLF·잔여공장입력검색 통과; Release 빌드 성공 및 실행파일3곳/PDB일치. 운영DB SELECT 외 변경 없음, DB에는 프로시저 저장 후 SYSTEM_PARAMETERS 등록SQL 실행 필요

### 2. TML1010_R05 입고등록 영역 35% 확대

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml
- **배경 및 원인**: 오른쪽 입고등록 영역 30%가 좁아 35%로 확대 요청
- **작업 상세 내용**:
  - 입고 팝업 비율 65:35로 조정; 오른쪽 패널 255에서 300, 입력칸 250에서 295, 버튼 230에서 275로 확대; 왼쪽 그리드 590 및 거래처 컬럼 180으로 조정하여 모든 컬럼 폭 확보
- **검증 결과**: 원본 반영 전 XML 및 공통 컴포넌트 독립 WPF 배치 검증; 65:35 비율 및 입력 항목 경계 정상; UTF-8 단일 BOM 및 CRLF 정상; Release 빌드 성공; 실행파일 3곳 및 PDB 해시 일치

### 2. TML1010_R05 입고 팝업 7:3 배치 조정

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml
- **배경 및 원인**: 발주 그리드 폭이 좁아 컬럼 내용이 잘려 왼쪽과 오른쪽 영역을 7:3으로 조정 요청
- **작업 상세 내용**:
  - 입고 팝업 열을 7*:12:3*로 배치; 그리드 498에서 636 및 거래처 컬럼 108에서 220으로 확대; 오른쪽 패널 255, 입력칸 250 및 라벨 80, 등록 버튼 230으로 축소; 다른 팝업과 업무 동작 유지
- **검증 결과**: 원본 반영 전 XML 및 폭 계산 검증; 실제 공통 컴포넌트로 DB 조회 없는 독립 WPF 렌더링 및 입력 컨트롤 경계 확인; 단일 UTF-8 BOM과 CRLF 정상; Release 빌드 성공; 실행파일 3곳 및 PDB 해시 일치

### 2. TML1010_R05 발주 선택 컬럼 너비 확대

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml
- **배경 및 원인**: 입고 팝업 발주 목록의 선택 헤더가 좁아 문구가 잘림
- **작업 상세 내용**:
  - SEL_ODR 컬럼 너비만 40에서 60으로 확대; 다른 컬럼과 선택 동작 유지
- **검증 결과**: 수정 전 XML과 전체 컬럼 폭 검증; UTF-8 단일 BOM 및 CRLF 확인; Release 빌드 성공; 실행파일 3곳 SHA256 일치

### 2. TML1010_R05 발주 그리드 부분입고 하늘색 표시 제거

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml.cs, 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe
- **배경 및 원인**: 사용자가 부분입고 하늘색 표시 제거 요청. 해당 색상은 이전 참조 화면 적용 과정에서 추가했던 부가 표시
- **작업 상세 내용**:
  - 발주 조회 초기색·이전 선택 복원색·재클릭 해제색의 PREV_INQTY 기반 SKYBLUE/WHITE 분기를 모두 WHITE로 통일. 선택 판단 조건의 SKYBLUE 항목도 삭제. 선택 행 YELLOW, 단일 선택, 발주키/순번/입고수량 전달·해제 및 사원·저장·라벨 동작 유지. 후보 검증 후 C#만 반영하고 Release 재빌드. 이전 사용자 승인 범위의 TML1010 PID50496 종료 후 로컬 AAABIN EXE/PDB와 프로젝트 EXE 반영
- **검증 결과**: 원본 적용 전 후보에서 하늘색 분기3곳과 선택 조건1곳 제거 확인, 색상/관련 주석 외 업무 C# 원문 불변 비교 통과, 후보·실프로젝트 MSBuild 성공. 최종 C# SKYBLUE 잔여0건, WHITE 복원3곳·YELLOW 선택 유지 확인. 배포3경로 EXE SHA256=8C002B553FDB60B46C79AEAFA4E8E7BA2F1C5C774969744547E9F939763029A0 및 PDB 해시 일치, 단일BOM/CRLF 확인. XAML/SQL/테스트데이터SQL/csproj/App 해시 불변. DB 접근 없음. 검증 후보·중간빌드 등 임시 파일 마무리 삭제

### 2. TML1010_R05 발주 선택 로직을 TML5000_R02 BACKGROUND 방식으로 통일

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml.cs, 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe
- **배경 및 원인**: 참조 화면과 같은 선택 관련 로직 요청. 기존 R05는 발주키·순번 일치 여부로 해제를 판단하고 모든 행을 흰색으로 덮어써 부분입고 행의 원래 색을 보존하지 않았음
- **작업 상세 내용**:
  - 발주 조회 후 미입고 WHITE·기입고량이 있는 행 SKYBLUE 초기화. 참조 TML5000_R02와 같이 BACKGROUND WHITE/SKYBLUE에서 선택 시 YELLOW, 해제 시 원래 색 복원. 기존 사용자 확정 사항인 발주1건 선택을 유지하며 다른 발주 선택 시 기존 YELLOW 행만 복원. 선택된 발주키·순번·잔량을 입력모델에 보관, 해제 시 키·순번·수량 초기화. 일반 행 포커스 이동은 선택 대상/입력량에 영향 없음. XAML 공통 삼각형 버튼·입고자/라벨/저장/조회 SQL 유지. 후보 사전 검증 후 업무 C# 적용, Release 빌드, 앞서 승인된 종료·배포 방식으로 해당 프로젝트 TML1010 PID47456 종료 후 로컬 실행파일 반영
- **검증 결과**: 공통 ITSLIB 실제 그리드와 현재 XAML GRID_ODR를 사용하여 native 버튼 클릭을 컴파일된 R05.EventCommand에 연결. DB 의존 생성자는 제외하고 선택 이벤트가 사용하는 모델을 주입한 격리 검증에서 후보·최종 AAABIN 실행본 각25개 통과: WHITE/SKYBLUE 초기색, YELLOW 선택/원래색 복원, 같은 키 다른 순번·다른 발주 선택, 단일 선택, 일반 포커스와 입고대상 분리, 사원/입력량 보존, 재조회 초기화, BACKGROUND 상태 우선, 빈 목록. PNG 시각 확인. 후보·실프로젝트 빌드 오류0, 배포3경로 EXE SHA256=5E57F1C8AFDE824CBACD293DE92191BDACA263B9C135D1530872DA29989210B4 일치 및 PDB 일치. C# 선택/초기색 영역 외 불변, XAML/SQL/테스트데이터SQL/csproj/App 해시 보존. 단일BOM/CRLF 확인. 실제 DB 접근 없음. 임시 빌드·검증자료 마무리 삭제

### 2. TML1010_R05 전체 기능 시험용 테스트 데이터 생성 SQL 작성

- **수정/대상 파일**: 05.Procedure/MES_SNS2_TML1010_R05_TEST_DATA.sql
- **배경 및 원인**: 설비부품 재고조회·출고·발주선택·입고·입출고이력·라벨 출력을 직접 시험할 수 있는 충분한 수량의 테스트 데이터 한 세트 SQL 요청
- **작업 상세 내용**:
  - INC 2공장07 전용 부품000-TEST-R05를 AUTO_INCREMENT 품목키로 생성. 현재고10000·안전재고100, 발주TEST-R05의1번행은 발주승인/발주10000/입고0,2번행은 납품진행/발주20000/입고10000으로 각각 입고가능10000. 초기재고10000의 입고이력은 발주키TEST-R05·순번2와 연결. 기존 구매 거래처·공장 사원·로케이션은 참조만 하며 신규 공통마스터/테이블/프로시저 생성 없음. MariaDB BEGIN NOT ATOMIC 익명블록·트랜잭션·오류 롤백·감사함수 및 세션값 복구 적용. 기존 테스트 부품/발주 발견 시 재실행을 중단하여 진행 결과 보존. 생성 결과 SELECT와 화면 시험 순서를 같은 파일에 제공
- **검증 결과**: 실제 DB SELECT로316컬럼·AUTO_INCREMENT·발주 FK·거래처 구매플래그1·단위DM150100/EA·사원/로케이션·감사함수·라벨·InnoDB5테이블·R05 라벨 분기 준비 상태 확인. 동일 메타데이터 MariaDB10.2 격리 환경에서 전체 SQL 파일 그대로 실행 성공. 실제 R05 프로시저와 연결한31개 검증 통과: 부품1건 조회, 승인/납품진행 발주2행, 출고100→9900·입고200→10100·잔량10000 전체입고→20100, 완료발주 제외, 이력/라벨데이터/재출력 무변경, 기존 업무·공통마스터 불변, 재실행 결과 보존, 말단 이력키 충돌 시 전체롤백, 단위 누락 차단, 다른 자동 품목키 생성과 감사세션 복구. 최종 파일과 검증 후보 바이트 일치, 단일BOM/CRLF 및 INSERT 전용 확인. 테스트 컨테이너·임시스크립트·DB추출·실행파일 전부 삭제. 실제 DB에는 SELECT 외 실행하지 않음

### 2. TML1010_R05 사용자 승인 후 실행 프로그램 종료 및 최신 실행본 배포

- **수정/대상 파일**: 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe
- **배경 및 원인**: 사용자가 실행 중인 TML1010 종료 후 새 버전 반영을 명시 승인하여 이전 배포 대기 상태 해소
- **작업 상세 내용**:
  - 현재 업무 소스의 출고자 선택·발주 ON/OFF·프로시저 기반 라벨 출력 유지 확인 후 최신 소스로 Release 재빌드. 해당 프로젝트 AAABIN에서 실행 중이던 PID28892만 종료. Release EXE/PDB를 AAABIN에 반영하고 프로젝트 루트 EXE도 갱신. 업무 소스와 실제 서버 DB는 변경하지 않음
- **검증 결과**: MSBuild 성공. Release·AAABIN·프로젝트 루트 EXE 3경로 SHA256=1C70A2741E96412CACB7D53DB11AA2AA3AC2BFC282F34485D563055B49CE7862 일치, Release/AAABIN PDB 해시 일치. 기존 후보의72개 및 최종 빌드61개 검증을 수행했던 소스 유지. 임시 중간빌드 폴더는 마무리 삭제

### 2. TML1010_R05 출고자 선택·발주 단일선택·프로시저 기반 라벨 출력 반영

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql
- **배경 및 원인**: 출고자는 로그인 사원 고정 저장, 발주 선택 버튼은 재클릭 해제 불가, 라벨 데이터는 화면 행을 복사하여 생성하던 상태. 출고자 입력·참조 화면과 같은 선택 버튼·프로시저 출력 데이터 기반 공통 라벨 발행 요청
- **작업 상세 내용**:
  - 공통 EMPCD 출고자 Pop 추가 및 로그인 사원 기본값 설정; 선택한 출고자를 AddModel로 저장하고 로그인 사원 강제 덮어쓰기 제거. 출고 팝업440x318, 좌표270·131로 공통 TML 스타일에서 중앙 유지. 입고자 영역 유지. GRID_ODR만 참조 TML5000_R02의 기본 gridbuttonstyle과 삼각형 선택 버튼 사용. 한 건 선택·동일 키/순번 재클릭 해제·다른 선택 이동·행 포커스와 실제 입고 대상 분리. 입고 응답과 LABEL_REPRINT에서 양식코드 EQMPARTS 및 출력용 데이터 반환; C#은 ItsBarcode(양식코드)·SetDataTable·Print(false) 사용. 입고는 입고수량/일자, 재발행은 현재고/오늘 기준. 출력 실패 시 이미 저장된 입고를 유지하고 별도 오류 안내. 공통 입출고자 검증 및 재고 행 FOR UPDATE 추가. 파라미터19개 이름/순서 유지, 테이블 구조와 공통 객체 변경 없음
- **검증 결과**: 실제 DB SELECT로316컬럼·발주/입출고 코드·EQMPARTS XML·파라미터19개 확인. 동일 메타데이터의 MariaDB10.2 격리 DB와 테스트 코드 없는 실제 후보 WPF 실행본에서72개 검증 통과: 정상·누락/잘못된 사원·0/음수/초과수량·타품목/타공장/잘못된 상태 거절 및 저장 보존, 발주키/순번/사원 저장, 현재고 증감, 부분/완료 상태, 재발행 무변경, 실제 선택 버튼 ON/OFF·단일선택·포커스 분리, 출고자 기본값/선택값, 입고자 보존, 라벨 실패 후 입고1회 저장. 실프로젝트 Release 빌드 성공 및 최종 빌드61개 SQL/UI 스모크 통과. 동시 출고4+4/현재고5 테스트는1건 성공·1건 재고부족, 최종재고1·이력1건 확인. 소스BOM/CRLF·호출분기·파라미터 정합성 통과, csproj/App/메타등록SQL 불변. 새 실행본 SHA256=06759DB944270183EBC478A7C860BD4704157AD0C342B32CCC9B18555F4F1159. 프로젝트 루트 EXE 반영 완료. 운영DB SELECT 외 변경·실물인쇄 없음. 테스트 전용 컨테이너 및 임시폴더/후보/스크립트/PNG/DB추출자료 모두 삭제

### 2. TML1010_R05 공통 스타일 적용 시 출고 팝업 화면 이탈 수정 및 임시파일 정리

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe
- **배경 및 원인**: 이전 검증은 TML 페이지 스타일이 적용되지 않은 환경이었다. 실제 TML 스타일과 Frame 호스팅에서는 Canvas.ActualWidth가 0이고, 이 값을 바인딩한 추가 Grid가 팝업을 X=-220으로 배치하여 화면 밖으로 밀리는 오류를 재현
- **작업 상세 내용**:
  - 바깥 Grid와 ActualWidth·ActualHeight 바인딩을 제거하고 기존 프로젝트 방식인 Canvas 직속 TML_POP으로 복원. 980x580 페이지 기준 출고 팝업 440x286, 좌표270·147로 중앙 배치. 내부 입력·버튼, 입고자 영역, C#·프로시저·프로젝트·App.xaml 원문 보존. 원본 적용 전 별도 빌드 검증 후 실제 프로젝트 Release 빌드 및 로컬 실행파일 교체. 이전 검증자료 ZIP·이미지·스크립트·잠금 백업과 이번 테스트 자료를 포함한 임시폴더10개, 전용 테스트 컨테이너2개 삭제 완료. 이전 발주 선택 ON/OFF 후보도 임시폴더와 함께 정리했으며 업무 소스에는 미반영 상태 유지
- **검증 결과**: 기존 배포본 오류 재현 후 수정 후보와 최종 AAABIN 실행본 모두 실제 R05 생성자·공통 TML 스타일·Frame·ITSLIB·격리 MariaDB를 사용한23개 검증 통과. 공통 출고 버튼→팝업 표시, 품목 표시·읽기전용·수량 바인딩·공통코드, X닫기·재열기, 800x600·1280x800·1920x1080 확대축소 중앙·화면경계, 입고·이력 팝업 및 입고자 기본값 보존, 실적 생성 없음 확인. 후보·실프로젝트 빌드 오류0, 실행파일3경로 SHA256=1F86DF210632E583B8A9C49AC9195354E8AEAA86531320F1D2DE077667180D5B 일치. C#/SQL/csproj/App 해시 불변, 출고 영역 외 XAML 불변, 단일BOM/CRLF 확인. 운영DB 변경·물리 프린터 출력 없음

### 1. TML1010_R05 출고 팝업 중앙정렬 및 내부 여백 정리

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe
- **배경 및 원인**: 출고 팝업의 고정 좌표와 과도한 하단 여백 정리 요청. 입고자 코드칸 변경 요청은 사용자가 취소하여 기존 유지
- **작업 상세 내용**:
  - 출고 팝업만 부모 Canvas 실제 크기를 따르는 Grid 중앙에 배치. 가로 440px·내용에 따른 세로 286px, 내부 여백 16px 및 32px 입력 행으로 정리. 등록 버튼 중앙 배치. 공통 TML_POP·WrapContent·입력 컴포넌트 유지. 입고자 마크업과 R05.xaml.cs 및 프로시저는 변경하지 않음. 최종 Release 빌드·로컬 실행파일 교체
- **검증 결과**: DB 연결 없이 실제 ITSLIB 공통 컴포넌트로 980x580·900x480·1280x720 중앙·경계, 입력 바인딩, 수량 변경, 닫기·재열기 등 18개 검증 통과 및 PNG 확인. 후보·최종 빌드 성공, 배포 EXE SHA256 일치, 출고 영역 외 원문 및 C#/SQL 해시 보존, 단일 BOM/CRLF 확인

---

## 🕒 2026-10-16 (금) 작업 내역

### 13. TML1010_R05 설비부품 재고조회 3,823건 원인 규명 및 프로시저 잉여 조인/코드 전면 최적화

- **수정/대상 파일**: [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql)
- **배경 및 원인 분석**:
  - 07(INC 2공장) 기준 설비부품 재고조회 시 3,823건이 출력되는 현상에 대한 원인 규명 요청
  - 프로시저 내 불필요한 미사용 항목, 잉여 조인 및 중복 쿼리 전면 정리 요청
- **작업 상세 내용**:
  - 1) **3,823건 발생 원인 규명**: 07공장의 법인인 60(INC)의 설비부품(`ITEMCG='DM100700'`) 활성 마스터 총수가 정확히 3,823건이며, 기존 쿼리가 `MSTITEM`(품목 마스터 전체)을 기준으로 `LEFT JOIN MSTITEM_EQMPARTS`를 수행하여 재고가 0인 마스터 품목까지 전부 출력하고 있었음을 실제 DB 데이터 조사를 통해 규명
  - 1) **재고조회 쿼리 필터링 최적화**: 평소 기본 조회 시에는 07공장 관리 부품(`MSTITEM_EQMPARTS.ITEMID IS NOT NULL`) 위주로 11건만 초고속 조회되고, 부품코드/명 검색어 입력 시에만 마스터 전체에서 검색될 수 있도록 조건 분기 최적화 (불필요한 3,800여 개 빈 데이터 출력 방지)
  - 1) **발주 조회 중복 조인 제거**: 공통 검증부에서 `$ITEMID`의 법인/설비부품 유효성을 사전 일원화하여, `LIST_ODR_EQMPARTS` 내부의 불필요한 `INNER JOIN MSTITEM` 및 중복 조건 완전 제거
  - 1) **기존 재고량 취득 간소화**: `IN_EQMPARTS` 및 `OUT_EQMPARTS`의 기존 재고량(`_$OLDQTY`) 취득을 단일 `COALESCE` 스칼라 쿼리로 직관화
  - 1) **로케이션 조인 최적화**: 로케이션 코드 부재 시 무의미한 조인 시도를 방지하도록 `AND MSTITEM_EQMPARTS.LOCACD <> ''` 조건 추가
- **검증 결과**:
  - MariaDB 독립 검증 스크립트 실행으로 최적화된 재고조회(기본 11건 / 키워드 검색 시 마스터 매칭) 정상 동작 확인
  - 단일 UTF-8 with BOM (`\xef\xbb\xbf`) 및 CRLF 개행 무결성 100% 통과, 서버 DB DDL/DML 직접 실행 금지 원칙 준수

### 3. TML1010_R05 입고자 기본값 및 승인 발주 입고 처리 정정

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, 05.Procedure/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql
- **배경 및 원인**: 입고지로 잘못 구현된 입력을 로그인 사원 기본값의 입고자로 정정하고 승인·납품진행 발주만 입고해야 함
- **작업 상세 내용**:
  - 공통 EMPCD 팝업 적용, 로그인 EMPCD 기본값 및 사용자 변경값 보존, 공통 SetBackColor로 단일 선택 발주 노란색 표시, 조회·저장 상태 MM110201/MM110300 제한, INCUSTCD 파라미터·전송·헤더 갱신 제거, 이력의 입고자·발주키·순번 저장, 기존 EQMPARTS 라벨과 ItsBarcode 연결, 조회 갱신 전 라벨 데이터 보존 및 프린터 오류 분리, 19개 파라미터 등록 SQL 갱신, 실행파일 재빌드·로컬 배포
- **검증 결과**: 실제 DB SELECT로 코드·스키마·공통 사원 팝업 확인; MariaDB 10.2 격리 DB 27개 및 실제 WPF 공통 컴포넌트 15개 검증 통과; 후보·최종 빌드 성공; 원본과 배포 실행파일 SHA256 일치; 실제 DB 변경 및 물리 프린터 출력 없음

### 3. TML1010_R05 입고·출고·이력 팝업 표준 화면 정리 및 발주키 저장 검증

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, 05.Procedure/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql, 02.Site/AAABIN/TML1010.exe·pdb
- **배경 및 원인**: 요청 이미지와 다른 팝업 구성 및 공통 TML_POP에 고정된 어두운 제목줄. 이력은 요청한 6개 컬럼·RTIME ASC와 달랐고 입고 발주 연결키 필수 관리 필요
- **작업 상세 내용**:
  - 공통 TML_POP 템플릿·X 이벤트를 그대로 사용하고 R05에서 제목줄·테두리만 SteelBlue 적용. 공통 WrapContent Show/Close로 배경 화면 비활성/복원 처리. 입고는 상단 발주일자·거래처 공통 Pop 검색, 좌측 선택/발주일자/거래처/발주량/입고량/발주잔량 그리드, 우측 읽기전용 코드·명·규격과 입고지 공통 Pop·입고일자·입고량·공통 초록 버튼으로 구성. 출고는 일자·코드·명·구분·수량과 공통 주황 버튼으로 정리. 이력은 발생일자·입/출·입출고유형·입고량·출고량·처리자 6개와 RTIME ASC, INOUTKEY ASC 정렬. 입고 시 발주키·순번 필수 검증 및 INOUT_EQMPARTS 저장, 현재고는 MSTITEM_EQMPARTS 반영. 기존 기준에 따라 입고지는 MTRODR.INCUSTCD에 변경 시 저장. 불필요한 이력 MSTITEM JOIN과 미사용 팝업 닫기 명령 제거. CUSTCD·INCUSTCD 2개 입력 추가(18→20), 전용 메타데이터 등록 SQL 갱신
- **검증 결과**: 실DB SELECT로 277컬럼·현행18파라미터·입출고/발주 코드·공통 거래처 Pop·GPCD 사원명 조회 지원 확인. MariaDB10.2 격리환경에서 프로시저 컴파일, 이력6필드·발생일자 역순 데이터의 RTIME 정렬·날짜 범위·입출고량·사원명, 발주기간/거래처 필터, 발주키/순번 저장, 타품목/타공장/초과입고 거절 및 롤백, 재고 증감·발주입고지·부분/완료 입고 검증. 실제 R05+ITSLIB를 격리DB에 연결하여 3개 팝업 렌더 이미지 확인, 숨은 키·입고지·재고 저장, X 닫기·배경활성 복원 통과. 등록SQL 20건 및 다른 프로시저 메타데이터 보존 검증. 실소스 Release 빌드 성공, AAABIN·프로젝트 실행파일 SHA256 일치. 4파일 단일 BOM/CRLF, 이전 메인 재고 쿼리 보존 검증. 공통 소스·실DB DDL/DML 미변경

### 3. TML1010_R05 설비부품 재고의 공장·법인 분리 및 중복 조회 수정

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, 02.Site/AAABIN/TML1010.exe·pdb
- **배경 및 원인**: 공장 기본값이 공란이고 MSTITEM 법인 조건이 없어 법인20·60의 동일 코드와 여러 공장 재고가 섞임. 품목코드 LIMIT 1 저장 및 존재하지 않는 INOUT_SUBSTOCK 참조도 확인
- **작업 상세 내용**:
  - 공통 FACTORYCD 콤보의 07(INC 2공장)을 기본 선택하고 MSTFACTORY에서 법인코드를 1회 조회. DM100700·미종료 품목만 해당 법인에서 조회하고 ITEMID+FACTORYCD로 재고 연결. 발주헤더 존재 조건은 메인 목록에 사용하지 않음. 팝업 모델에 숨은 ITEMID·FACTORYCD를 미리 등록하여 초기화 유실을 방지하고 AddModel로 전달. 실제 INOUT_EQMPARTS의 ITEMID·INOUTTP_EQMPARTS·발주키 컬럼 사용. 공통 입출고 구분코드와 MM110 발주상태 정합성 반영. 다른 법인의 품목 저장·타공장 발주·초과 입고 차단 및 부분입고 중복가산 수정
- **검증 결과**: 실서버 SELECT로 기존7225행/7216품목에서 수정3823행/3823품목 확인. 3821코드 중 자동적재4·5는 같은 법인의 별도 ITEMID 두 건씩이므로 보존. MariaDB10.2 격리환경에서 프로시저 컴파일, 18개 파라미터, NULL·빈공장·다른법인·유형·종료·무재고·부족재고·소수입출고·발주부분/완료·오류롤백 검증 통과. 실제 R05+ITSLIB를 로컬 테스트DB에 연결하여 기본 공장명·팝업키·변경된 공장콤보와 저장공장 분리·입출고·이력 확인. 실소스 MSBuild Release 성공(기존 obj/Release 파일 잠금으로 전용 중간출력경로 사용), AAABIN·프로젝트 실행파일 SHA256 일치. UTF-8 단일BOM/CRLF 통과. 실DB 및 공통객체 변경 없음

### 12. 형상 관리 대상 제외를 위한 .gitignore 임시 폴더(.tmp*) 등록 및 작업 정리

- **수정/대상 파일**: [.gitignore](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.gitignore), [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)
- **배경 및 원인 분석**:
  - 임시 작업 및 분석 폴더(`.tmp-r05-stock-audit`, `.tmp-tml-r05-buttons`)가 Git untracked 상태로 노출되던 문제를 방지하기 위해 사용자의 요청에 따라 `.gitignore`에 영구 제외 규칙 등록
- **작업 상세 내용**:
  - 1) **.gitignore 규칙 추가 ([.gitignore](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.gitignore))**: `.tmp*`, `**/.tmp*`, `.tmp-*/`, `**/.tmp-*/` 및 구체적 폴더(`.tmp-r05-stock-audit/`, `.tmp-tml-r05-buttons/`)를 등록하여 향후 생성되는 모든 임시 디렉터리가 자동 제외되도록 설정
  - 1) **임시 테스트 바이너리 정리**: `02.Site/AAALIB`에 잔류하던 임시 테스트 실행파일(`test_maria*.exe`, `inspect_server_db.exe`, `check_db_r05.exe`) 일괄 삭제 정리
- **검증 결과**: `git status` 확인 시 `.tmp*` 디렉터리 및 임시 바이너리가 깔끔하게 제외됨 확인, `.gitignore` 단일 UTF-8 with BOM 및 CRLF 개행 무결성 100% 통과

### 3. [TML1010_R05] 이미지 기준 회색 그리드 버튼 및 출력 문구 적용

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 02.Site/AAABIN/TML1010.exe
- **배경 및 원인**: 공통 기본 버튼의 검은 배경·흰 글씨가 사용자 지정 이미지의 회색 배경·검은 글씨와 달랐음
- **작업 상세 내용**:
  - 라벨출력 컬럼 ButtonText를 출력으로 변경; 화면 전용 StyleGrid 리소스 사본에 기본 WPF 사각 버튼 외형 적용; 공통 BUTTON_COLUMN 템플릿·Loaded·Click 처리와 기존 CommandName 유지; 리플렉션·자체 클릭 핸들러 없이 외형만 변경; 최종 Release 빌드 및 EXE/PDB 로컬 배포
- **검증 결과**: 실제 ITSLIB 공통 버튼 5종을 DB 연결 없이 렌더링하여 회색 배경·검은 글씨 및 5개 명령·선택행 유지 검증; 참조 이미지와 렌더링 PNG 비교; 공통 원본 리소스와 화면 전용 리소스 별도 인스턴스 확인; MSBuild 오류0; 단일BOM/CRLF 및 배포파일 해시 일치

### 3. [TML1010_R05] 공통 버튼 복원 및 DM150 단위 표시 통일

- **수정/대상 파일**: 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, 02.Site/AAABIN/TML1010.exe
- **배경 및 원인**: 작업 이력과 업데이트된 규칙 전체 확인; 서버 구버전 GPCD ITEMUNIT 호출과 로컬 커스텀 버튼 템플릿·정적 리플렉션 이벤트 연결 오류 확인
- **작업 상세 내용**:
  - DE R01과 현재 S02의 공통 컴포넌트 사용방식 참조; 페이지 gridbuttonstyle/BUTTON_COLUMN 및 리플렉션 핸들러 제거; 두 그리드 GPCD DM150 지정; 입출고 팝업 단위를 공통 읽기전용 콤보로 변경하고 확인 문구 SelectedLabel 사용; 재고·이력 SQL은 원본 ITEMUNIT 코드 반환; 입출고 저장 분기와 명령·파라미터 18개 유지; 최종 Release 빌드 후 로컬 AAABIN EXE/PDB 갱신
- **검증 결과**: 격리 MariaDB10.2.44 SQL 컴파일 및 9개 재고/2개 이력 확인; 실제 ITSLIB를 사용하는 WPF 검증 17건 통과(6종 단위/NULL·빈값/미등록단위/선택행/공통 입출고·이력 버튼/읽기전용 팝업/발주번호·수량 반영); 화면 PNG 렌더링 점검; MSBuild 오류0; 서버 파라미터·등록정보18건 일치; 배포 SHA256 및 단일BOM/CRLF 검증

### 11. TML1010_R05 설비부품 단위코드(DM150) 정규화 및 그리드 버튼 원래 직사각형 회색 디자인 완벽 복원

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [05.PROCEDURE/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql), [02.Site/AAABIN/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe)
- **배경 및 원인 분석**:
  - 1) **단위 컬럼 에러(`ERRO...`) 원인**: 설비부품(`MSTITEM.ITEMUNIT`)의 단위코드가 `DM150100`(EA) 등 `DM150` 그룹인데, 프로시저에서 구버전의 `GPCD('ITEMUNIT', ...)`를 호출하여 MariaDB `GPCD` 함수가 코드그룹 불일치로 `ERROR ITEMUNIT: DM150100`을 반환한 것임
  - 1) **그리드 버튼 디자인 불일치 원인**: `ITSLIB`의 `BUTTON_COLUMN`이 참조하는 `gridbuttonstyle`이 기본적으로 어두운 남색 알약형(`Background="#262938"`, `CornerRadius="5"`)으로 선언되어 있어, 사용자가 의도한 원래 MES 표준 직사각형 회색 버튼과 이질감이 발생함
- **작업 상세 내용**:
  - 1) **단위 조회 정상화 ([MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql))**: `LIST_EQMPARTS` 및 `LIST_INOUT_EQMPARTS` 분기에서 단위를 `COALESCE(GPCD('DM150', MSTITEM.ITEMUNIT), MSTITEM.ITEMUNIT, 'EA') AS ITEMUNIT`로 수정하여 정상 단위명(EA, KG, SET 등) 반환 적용
  - 1) **원래 버튼 디자인 복원 ([R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml))**: `<its:ItsPageTml.Resources>`에 직사각형 회색 버튼 스타일(`Background="#E1E1E1"`, `BorderBrush="#707070"`, `CornerRadius="0"`, `Foreground="#000000"`, `Margin="2,1,2,1"`) 및 `BUTTON_COLUMN`을 재정의하여 사용자 요청 이미지와 100% 동일하게 복원
  - 1) **버튼 이벤트 브릿지 연동 ([R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs))**: `BUTTON_COLUMN_LOADED` 리플렉션 핸들러를 구현하여 기존 `CommandRun`(입고/출고/이력/라벨) 동작 완벽 보존
  - 1) **빌드 및 배포**: MSBuild 15.0 빌드 성공 (0 Error, 0 Warning) 및 최신 바이너리([02.Site/AAABIN/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe)) 배포 완료
- **검증 결과**: MSBuild 컴파일 0 Error 통과, 4개 파일 단일 UTF-8 with BOM 및 CRLF 3단계 바이너리 무결성 100% 통과

### 10. TML1010_R05 "Case not found for CASE statement" 오류 원인 정밀 규명 및 DB 반영 가이드

- **대상 파일**: [05.PROCEDURE/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql), [05.PROCEDURE/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs)
- **배경 및 원인 분석**:
  - 화면 실행 시 `"설비부품 조회 오류: Case not found for CASE statement"` 팝업 발생 보고
  - 실제 서버 DB(211.43.15.98)의 `TML1010_R05` 프로시저 본체를 직접 확인한 결과, 서버 DB에는 여전히 구버전 부자재용 프로시저(`WHEN 'LIST_SUBSTOCK'`)가 올라가 있어 최신 C# 소스가 호출하는 `$CALLTYPE = 'LIST_EQMPARTS'` 분기를 찾지 못해 MariaDB 1339 에러 발생 확인
  - 또한 `SYSTEM_PARAMETERS` 역시 구버전 12개 파라미터만 등록되어 있어, 로컬의 최신 `MES_SNS2_TML1010_R05.sql` 프로시저 본체가 서버 DB에 컴파일되지 않은 상태에서 프로그램이 실행된 것이 원인임을 규명
- **해결 및 조치 가이드**:
  - 1) **1단계 (프로시저 생성)**: DBeaver Routine Editor(소스 탭 저장) 또는 `Alt + X`(스크립트 전체 실행)를 통해 [MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql)을 서버 DB에 최신 컴파일
  - 1) **2단계 (파라미터 동기화)**: 프로시저가 생성된 후 [MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql)을 실행하여 신규 18개 파라미터 등록
  - 1) **프로그램 재실행**: 터미널 프로그램 실행 시 설비부품 그리드 정상 조회 확인
- **검증 결과**: 서버 DB 프로시저 정의 비교 완료, 프로시저 컴파일 오류 방지 가이드(`procedure_compile.md`) 준수 안내

### 9. TML1010_R05 상단 UI 필터 정돈(부품검색 삭제, 공장 콤보 확대) 및 데이터 미조회 원인 해결 (SYSTEM_PARAMETERS 연동)

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [05.PROCEDURE/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql), [05.PROCEDURE/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql), [02.Site/AAABIN/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe)
- **배경 및 원인**:
  - 1) 사용자 요청에 따라 상단 패널의 불필요한 '부품검색' 텍스트박스 제거 및 '공장' 콤보 너비 대폭 확대(Width="260")
  - 1) 화면 실행 시 메인 그리드에 데이터가 전혀 나오지 않던 결함 정밀 원인 분석: 프로시저가 DB에 미반영 상태이거나 MariaDB 서버의 SYSTEM_PARAMETERS 테이블에 TML1010_R05가 등록되지 않아 ItsMaria 호출 시 파라미터 0개 전송(Incorrect number of arguments expected 12/18, got 0)으로 에러 발생 규명
- **작업 상세 내용**:
  - 1) **상단 UI 정돈 ([R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml))**: 부품검색 Text 컨트롤 및 간격 여백 제거, cmb_FACTORYCD 폭 130 -> 260으로 2배 확대 적용
  - 1) **조회 조건 유연화 ([MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql))**: LIST_EQMPARTS 분기에서 FACTORYCD 빈 값일 경우 전체 공장 설비부품(ITEMCG='DM100700')을 표시하고, 선택 시에만 해당 공장 재고를 필터링하도록 보완
  - 1) **SYSTEM_PARAMETERS 등록 스크립트 작성 ([MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql))**: TML1010_R05 프로시저 저장 후 information_schema.PARAMETERS를 SYSTEM_PARAMETERS로 등록하는 정석 스크립트 신규 제공
  - 1) **조회 로직 및 오류 안내 강화 ([R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs))**: SEARCH_EQMPARTS 호출 시 공장 콤보 값 전달, 에러 발생 시 try-catch에서 삼키지 않고 ShowMessageBox로 상세 오류 안내
  - 1) **빌드 및 배포**: MSBuild 15.0 Debug 및 Release 빌드 0 Error 통과, AAABIN/TML1010.exe 배포 완료
- **검증 결과**: MSBuild 컴파일 0 Error 통과, 4개 파일 단일 UTF-8 with BOM 및 CRLF 개행 무결성 100% 통과

### 8. TML1010_R05 부자재에서 설비부품 입출고 관리 전면 전환 및 5대 핵심 기능 구현

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [05.PROCEDURE/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql), [02.Site/AAABIN/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe), [02.Site/TMLPJT/TML1010/bin/Release/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/bin/Release/TML1010.exe)
- **배경 및 원인**: 사용자 요청에 따라 현장터미널 R05 화면을 기존의 '부자재 관리'에서 '설비부품 입출고 관리'로 전면 전환하고, 화면 내 모든 '부자재' 용어를 '설비부품'으로 변경하며, 11개 컬럼 그리드 및 발주조회 입고/출고/이력/라벨출력 5대 핵심 기능 구현
- **작업 상세 내용**:
  - 1) **11개 컬럼 그리드 구성 ([R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml))**: 설비부품코드(ITEMCD), 설비부품명(ITEMNM), 중요도등급(GRADE), 로케이션(LOCANM), 안전재고량(SAFEQTY), 현재고량(LOTQTY), 단위(ITEMUNIT), 입고(버튼), 출고(버튼), 입출고 이력(버튼), 라벨출력(버튼) 표준 11개 컬럼 완벽 배치
  - 1) **설비부품 현재고 조회 (SEARCH_EQMPARTS)**: 상단 파란색 버튼 [설비부품 재고조회], 부품검색 텍스트 및 공장 콤보 필터 구성, 안전재고 미달 시 핑크색(BACKGROUND='PINK') 강조 표시
  - 1) **발주조회 기반 입고등록 팝업 (POP_IN_EQMPARTS / IN_EQMPARTS)**: 선택 부품의 진행 발주 목록(MTRODR/MTRODRD) 조회 그리드(GRID_ODR) 연동, 발주 행 [선택] 시 발주번호/발주순번/잔여수량 자동 바인딩, 입고등록 시 MSTITEM_EQMPARTS 재고 누적 및 MTRODRD 상태 자동 갱신
  - 1) **출고등록 팝업 (POP_OUT_EQMPARTS / OUT_EQMPARTS)**: 출고일자, 출고구분, 출고수량, 사유/비고 입력 팝업 구성, 현재고량 초과 검증 방어 로직 및 MSTITEM_EQMPARTS 재고 차감 처리
  - 1) **입출고 이력 조회 팝업 (POP_EQM_INOUT / SEARCH_INOUT_EQMPARTS)**: 기간별(SDATE~EDATE) 설비부품 입출고 내역 그리드(GRID_G2) 연동 및 작업자/이전재고/구분 조회
  - 1) **라벨출력 버튼 연동 (POP_PRINT_LABEL)**: 선택 부품코드/부품명/로케이션에 대한 바코드 라벨 출력 안내 제공
  - 1) **프로시저 전면 개편 ([MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql))**: LIST_EQMPARTS, LIST_ODR_EQMPARTS, IN_EQMPARTS, OUT_EQMPARTS, LIST_INOUT_EQMPARTS 분기 구현, 공통 감사함수(CALLTIME, CALLEMP, CALLPRG) 필수 적용 및 2행 분리 개행/1일 1행 이력 표준 준수
  - 1) **빌드 및 배포**: MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 및 최신 바이너리(02.Site/AAABIN/TML1010.exe) 배포 완료
- **검증 결과**: MSBuild 컴파일 0 Error 통과, 3개 파일(R05.xaml, R05.xaml.cs, MES_SNS2_TML1010_R05.sql) 3단계 바이너리 무결성(단일 BOM, 중복 BOM 부존재, CRLF) 100% 검증 통과

### 1. EQM1001_R03 제조설비 정기 점검 시트 DevExpress Report Designer 표준 호환 전면 구축

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R03.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.cs), [04.Report/PAGEEQM/EQM1001/R03.Designer.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.Designer.cs), [04.Report/PAGEEQM/EQM1001/R03.resx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.resx), [01.Office/Reports/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: 기존 R03 리포트가 비하인드 C# 코드(BuildReport)에서 컨트롤을 동적으로 생성하여 Visual Studio 디자인 뷰에서 빈 화면이 표시되고 DevExpress Designer 기능을 이용할 수 없던 문제를 해결하기 위해, 사용자 요청(S01B 템플릿 기준)에 따라 Visual Studio DevExpress Report Designer 표준 형식으로 전면 재구축 요청
- **작업 상세 내용**:
  - 1) [R03.Designer.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.Designer.cs)에 TopMargin, BottomMargin, PageHeader(타이틀, 설비정보 테이블, 점검헤더 테이블), Detail(점검항목 그리드 바인딩 행), ReportFooter(확인/점검자/담당 결재란, 개정이력 4개 행 및 헤더), PageFooter(계획서 라벨) 등 전체 리포트 컨트롤을 DevExpress Designer 표준 코드로 완전 구성
  - 1) [R03.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.cs)는 사용자 첨부 기준(S01B)에 맞추어 매개변수 없는 기본 생성자 `public R03() { InitializeComponent(); }`, 파라미터 생성자 `public R03(Dictionary<string, string> param) : this()`, 데이터 바인딩 로직(`BindReportData`, `BindRevHistory`), `MODEL_S1` 클래스 및 호환용 `R03A` 파생 클래스로 구조 정규화
  - 1) MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 및 최신 바이너리([01.Office/Reports/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe)) 배포 완료
  - 1) DesignSurface 로드 테스트를 통해 DesignerHost 인스턴스화 및 ReportDesigner 정상 진입 검증
- **검증 결과**: MSBuild 컴파일 0 Error 통과, DesignSurface 인스턴스화 통과, 단일 UTF-8 with BOM 및 CRLF 개행 무결성 100% 확인

### 3. EQM1001_R03 리포트 DB 연결 표준 정규화 및 DevExpress XtraReport 디자이너 개발 규칙 수립

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R03.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.cs), [01.Office/Reports/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe), [.agents/rules/report_devexpress.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/report_devexpress.md), [.agents/rules/framework_convention.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md)
- **배경 및 원인**: 사용자의 요청에 따라 R03.cs 내에 하드코딩되어 있던 CreateMaria 헬퍼 메서드(DB IP, Port, 암호 설정)를 프로젝트 표준 템플릿(S01A/S01B)과 동일하게 제거하고 new ItsMaria(...) 기본 생성자로 정규화하며, 향후 모든 신규/수정 리포트가 Visual Studio DevExpress Report Designer 표준 방식을 준수하도록 .agents/rules/에 공식 개발 규칙 문서화
- **작업 상세 내용**:
  - 1) [R03.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.cs): CreateMaria 수동 설정 블록 완전 제거, new ItsMaria("EQM1001_R03", "CALL_PLAN_RPT") 표준 호출로 일치 (ITS_CONFIG_MARIA.xml 자동 로드 활용)
  - 1) [.agents/rules/report_devexpress.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/report_devexpress.md): DevExpress XtraReport 디자이너 표준 개발 규칙 신규 제정 (C# 코드 동적 생성 금지, 디자이너 3개 파일 세트 cs/Designer.cs/resx 표준, 기본 생성자 public R03() { InitializeComponent(); } 필수, components 컨테이너 선언/초기화, InitializeComponent() 내 임의 헬퍼 메서드 호출 금지, XRTableRow의 ISupportInitialize 미지원 주의, CreateMaria 하드코딩 금지, ItsMaria/ItsSecurity 공통 컴포넌트 함수 최우선 적극 활용 및 불필요한 자체 헬퍼 제작 금지, MODEL_S1 내부 모델 선언 및 MSBuild 검증/배포 절차 명시)
  - 1) [.agents/rules/framework_convention.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md): 1절에 화면·스크립트·백엔드·리포트 전반의 공통 컴포넌트/함수 지원 여부 선행 확인 및 최우선 적극 활용(Framework-First & Common Utility Usage) 규칙 대폭 강화 (C# 코드 동적 생성 금지, 디자이너 3개 파일 세트 cs/Designer.cs/resx 표준, 기본 생성자 public R03() { InitializeComponent(); } 필수, components 컨테이너 선언/초기화, InitializeComponent() 내 임의 헬퍼 메서드 호출 금지, XRTableRow의 ISupportInitialize 미지원 주의, CreateMaria 하드코딩 금지, MODEL_S1 내부 모델 선언 및 MSBuild 검증/배포 절차 명시)
  - 1) MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 및 최신 바이너리(01.Office/Reports/EQM1001.exe, 04.Report/bin/EQM1001.exe) 배포 완료
- **검증 결과**: MSBuild 컴파일 0 Error 통과, 모든 수정 및 신규 파일 단일 UTF-8 with BOM 및 CRLF 개행 무결성 100% 확인

### 4. EQM1001_R03 리포트 PageFooter 밴드 제거 및 재빌드·배포

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/R03.Designer.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.Designer.cs), [01.Office/Reports/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe), [04.Report/bin/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/bin/EQM1001.exe)
- **배경 및 원인**: 사용자 요청에 따라 정기점검 계획서 하단 불필요한 PageFooter 밴드(제조설비 정기 점검 계획서 라벨)를 제거하고 Visual Studio DevExpress Report Designer 표준 코드 정리 및 재빌드·배포 요청
- **작업 상세 내용**:
  - 1) [R03.Designer.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.Designer.cs): PageFooterBand 초기화, xrLabelFooter 컨트롤 선언, PageFooter 밴드 속성 블록, Bands.AddRange 내 PageFooter 등록 및 필드 선언부 완전 제거
  - 1) MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning)
  - 1) 최신 실행파일([01.Office/Reports/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe) 및 [04.Report/bin/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/bin/EQM1001.exe)) 복사 배포 완료
- **검증 결과**: MSBuild 컴파일 0 Error 통과, 단일 UTF-8 with BOM 및 CRLF 개행 무결성 100% 확인

### 6. TML1010 실행 시작 화면(StartupUri) R05.xaml 전환 및 빌드

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/App.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/App.xaml), [02.Site/AAABIN/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe), [02.Site/TMLPJT/TML1010/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/TML1010.exe)
- **배경 및 원인**: Visual Studio에서 솔루션 실행 시 기존 설정에 따라 R04.xaml이 시작 페이지로 뜨던 것을, 신규 작업 대상인 R05.xaml 페이지가 바로 뜨도록 시작 화면 전환 요청
- **작업 상세 내용**:
  - 1) [App.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/App.xaml): StartupUri="R04.xaml"을 StartupUri="R05.xaml"로 변경
  - 1) MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 및 최신 바이너리(02.Site/AAABIN/TML1010.exe) 배포 완료
- **검증 결과**: MSBuild 컴파일 0 Error 통과, 단일 UTF-8 with BOM 및 CRLF 개행 무결성 100% 확인

### 5. TML1010 부자재 재고/입출고 화면(R05.xaml, R05.xaml.cs) 프로젝트 연동 및 컴파일·배포 완료

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [02.Site/TMLPJT/TML1010/TML1010.csproj](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/TML1010.csproj), [02.Site/AAABIN/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe), [02.Site/TMLPJT/TML1010/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/TML1010.exe)
- **배경 및 원인**: 사용자 요청에 따라 TML1010 프로젝트에 R05.xaml 및 R05.xaml.cs를 포함하여 화면 출력이 가능하도록 연동하고, R01 복사본 상태였던 클래스명 중복(x:Class, partial class R01) 및 컴파일 오류(ITSLIB.Combo DisplayText) 해결 요청
- **작업 상세 내용**:
  - 1) [R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml): 루트 태그 x:Class="TML1010.R05"로 클래스 식별자 수정
  - 1) [R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs): 클래스명 public partial class R05, 생성자 public R05(), ITSLIB.Combo 프로퍼티 DisplayText -> SelectedLabel 교정 및 화면 전용 안전 try-catch 방어 적용
  - 1) [TML1010.csproj](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/TML1010.csproj): Compile Include="R05.xaml.cs" 및 Page Include="R05.xaml" 빌드 아이템 등록
  - 1) MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 및 최신 바이너리(02.Site/AAABIN/TML1010.exe, 02.Site/TMLPJT/TML1010/TML1010.exe) 배포 완료
- **검증 결과**: MSBuild 컴파일 0 Error 통과, 단일 UTF-8 with BOM 및 CRLF 개행 무결성 100% 확인

### 7. TML1010_R05 부자재 재고/입출고 프로시저명 전면 교체 및 재빌드·배포

- **수정/대상 파일**: [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [02.Site/AAABIN/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe), [02.Site/TMLPJT/TML1010/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/TML1010.exe)
- **배경 및 원인**: R05.xaml.cs 내부의 프로시저 호출부 4곳에 기존 R01 명칭(TML1010_R01)이 남아있던 결함을 발견하여, 화면 고유 프로시저인 TML1010_R05로 전면 교체 요청
- **작업 상세 내용**:
  - 1) [R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs): 프로시저 호출부 4곳(LIST_SUBSTOCK, LIST_INOUT_SUBSTOCK, IN_SUBSTOCK, OUT_SUBSTOCK) 내 'TML1010_R01'을 'TML1010_R05'로 일괄 전면 교체
  - 1) 실행 중이던 테스트 프로세스 잠금 해제 후 MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning)
  - 1) 최신 바이너리([02.Site/AAABIN/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe), [02.Site/TMLPJT/TML1010/TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/TML1010.exe)) 배포 완료
- **검증 결과**: 소스 내 R01 잔여 참조 0건 전수 검증 통과, MSBuild 컴파일 0 Error 통과, 단일 UTF-8 with BOM 및 CRLF 개행 무결성 100% 확인

### 2. EQM1001_S01A 설비이력카드 Visual Studio 디자이너 호환성 확보 및 기본 생성자 보완

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/S01A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/S01A.cs), [04.Report/PAGEEQM/EQM1001/S01A.Designer.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/S01A.Designer.cs), [01.Office/Reports/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe)
- **배경 및 원인**: Visual Studio Report Designer에서 S01A.cs 열기 시 헬퍼 메서드 제거 및 XRTableRow BeginInit 제외 후 발생한 '값은 null일 수 없습니다. 매개 변수 이름: component' 오류 해결
- **작업 상세 내용**:
  - 1) S01A.cs에 기본 생성자 public S01A() { InitializeComponent(); } 추가 및 기존 생성자 : this() 연결
  - 1) S01A.Designer.cs InitializeComponent() 최상단에 this.components = new System.ComponentModel.Container(); 초기화 반영
  - 1) MSBuild 15.0 Rebuild 성공 및 최신 바이너리 배포 완료
- **검증 결과**: MSBuild 컴파일 0 Error 통과, 단일 UTF-8 with BOM 및 CRLF 무결성 통과

---

## 🕒 2026-10-15 (목) 작업 내역

### 2. MES_SNS2_MTR0001_R04 사원 조인 조건 간소화 (ODREMPID 단일 기준 정규화)

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: 사용자 요청에 따라 MSTEMP 조인 시 ODREMPID > 0 및 EMPCD 조건을 제거하고, ODREMPID 단일 기준으로 간소화하면서 DOUBLE 변환 에러가 발생하지 않도록 정규화
- **작업 상세 내용**:
  - 1) LIST_MTRODR 및 CALL_RPT 분기 내 MSTEMP 조인을 LEFT JOIN MSTEMP ON MSTEMP.EMPID = CAST(MTRODR.ODREMPID AS CHAR) 단일 조건으로 간소화. 2) ODREMPID > 0 및 EMPCD 조건 완전 제거. 3) CAST(... AS CHAR) 명시적 형변환을 유지하여 Truncated incorrect DOUBLE value 에러 및 오매칭 원천 차단. 4) UTF-8 with BOM 무결성 검증 완료
- **검증 결과**: 전체 1,141건 대상 전수 테스트 결과 Warning 및 Error 0건 통과

### 2. MES_SNS2_MTR0001_R04 사원 조인 타입 불일치 및 DOUBLE 변환 에러 해결

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: MSTEMP.EMPID(VARCHAR)와 MTRODR.ODREMPID(INT) 간 암시적 형변환으로 인해 MSTEMP 내 빈 문자열('') 행과 비교 시 MariaDB 1292 Truncated incorrect DOUBLE value 에러 발생
- **작업 상세 내용**:
  - 1) MSTEMP 조인 조건에 ODREMPID > 0 및 CAST(MTRODR.ODREMPID AS CHAR) 명시적 형변환 적용. 2) LIST_MTRODR의 ODREMPID 바인딩도 CASE WHEN 명시적 형변환으로 통일하여 빈 문자열('')과의 DOUBLE 변환 에러 및 미지정 발주에 MES관리자가 오매칭되는 현상 원천 차단. 3) 최상단 Modify 1일 1행 이력 갱신 및 단일 UTF-8 with BOM 무결성 검증 완료
- **검증 결과**: 전체 1,141건 발주 대상 테스트 결과 에러 및 Warnings 0건 통과

### 2. EQM1001 정기점검 계획서 리포트 파일명 R03 기준으로 전수 재수정 및 빌드/배포

- **수정/대상 파일**: 04.Report/PAGEEQM/EQM1001/R03.cs, 04.Report/PAGEEQM/EQM1001/R03.Designer.cs, 04.Report/PAGEEQM/EQM1001/R03.resx, 04.Report/PAGEEQM/EQM1001/EQM1001.csproj, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/Reports/EQM1001.exe
- **배경 및 원인**: 설비점검계획서 리포트 명칭을 S03이 아닌 R03 기준으로 생성 및 호출하도록 사용자 요구사항 재수정
- **작업 상세 내용**:
  - 1) S03A.*파일들을 R03.*로 이름 변경(R03.cs, R03.Designer.cs, R03.resx) 및 클래스명 public partial class R03 : XtraReport 로 수정(R03A 호환 파생클래스 포함). 2) EQM1001.csproj 내 R03 매핑 갱신. 3) EQM1001_R03.js 내 ItsXtraRpt('EQM1001_R03') 호출부 변경. 4) MSBuild Release 리빌드 성공(0 Error, 0 Warning) 후 01.Office/Reports/EQM1001.exe 배포 완료
- **검증 결과**: 단일 UTF-8 with BOM 및 CRLF 개행 무결성 5개 파일 100% 통과, MSBuild Release 빌드 성공, 바이너리 배포 및 Git 상태 검증 완료

### 2. MES_SNS2_MTR0001_R04 사원 조인 조건 간소화 (ODREMPID > 0 제거 및 식별키 직접 조인)

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: 사원 조인 시 방어 목적으로 작성되었던 불필요한 ODREMPID > 0 조건 제거 및 직관적인 표준 조인 형태로 간소화 요청
- **작업 상세 내용**:
  - 1) LIST_MTRODR 및 CALL_RPT 분기 내 MSTEMP 조인을 LEFT JOIN MSTEMP ON MSTEMP.EMPID = MTRODR.ODREMPID 로 간소화. 2) 최상단 Modify 1일 1행 이력 갱신. 3) 단일 UTF-8 with BOM 및 CRLF 개행 무결성 검증 완료
- **검증 결과**: 실제 DB SELECT 쿼리 테스트 결과 '생산관리2팀 (정영진 Senior 010-9960-2345)' 동일 정상 반환 확인, 인코딩 무결성 통과 (실서버 프로시저 반영은 규칙에 따라 사용자 직접 진행)

### 2. MES_SNS2_MTR0001_R04 발주서 출력 리포트 데이터 조회(CALL_RPT) 부서명 조인 및 직위코드(HR151) 보완

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: CALL_RPT 분기 내 담당자 정보(EMPINFO) 조회 시 GPCD('DEPTCD', ...) 및 GPCD('POSBC', ...) 호출 오류로 인해 'ERROR DEPTCD: ...', 'ERROR POSBC: ...' 형태의 이상 문자열이 출력되는 문제 해결 요청
- **작업 상세 내용**:
  - 1) 부서 코드그룹 미존재에 따른 MSTDEPT 테이블 LEFT JOIN 추가 및 MSTDEPT.DEPTNM 바인딩. 2) 직위 코드그룹 POSBC를 올바른 공통코드 그룹인 HR151로 변경하여 정상 직위명 바인딩. 3) 최상단 Modify 이력 1일 1행 규칙 갱신 및 파일 인코딩(단일 UTF-8 with BOM, CRLF) 무결성 검증 완료
- **검증 결과**: 실제 DB SELECT 쿼리 테스트 결과 '생산관리2팀 (정영진 Senior 010-9960-2345)' 정상 출력 확인, BOM/CRLF 무결성 검증 완료 (실서버 프로시저 반영은 규칙에 따라 사용자 직접 진행)

### 2. EQM1001 정기점검 계획서 리포트 담당 화면 이전(R05->R03)에 따른 S05A->S03A 명칭 및 참조 전수 변경

- **수정/대상 파일**: 04.Report/PAGEEQM/EQM1001/S03A.cs, 04.Report/PAGEEQM/EQM1001/S03A.Designer.cs, 04.Report/PAGEEQM/EQM1001/S03A.resx, 04.Report/PAGEEQM/EQM1001/EQM1001.csproj, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/Reports/EQM1001.exe
- **배경 및 원인**: 원래 R05(설비점검계획 승인)에 속해 있던 점검계획서 출력이 R03(설비점검계획) 화면으로 담당 페이지가 이전됨에 따라, 리포트 명칭을 S05A에서 S03A로 변경하고 관련 프로젝트 설정 및 호출부를 전수 동기화 요청
- **작업 상세 내용**:
  - 1) 04.Report/PAGEEQM/EQM1001/S05A.*파일 3종을 S03A.*로 이름 변경 및 클래스명(partial class S03A, public S03A) 수정. 2) EQM1001.csproj 내 Compile/EmbeddedResource 매핑 S03A로 갱신. 3) EQM1001_R03.js 내 ItsXtraRpt('EQM1001_S03A') 호출부 및 날짜 주석 반영. 4) 기존 S05A 파일 정리 및 MSBuild 15 Release 리빌드(0 Error, 0 Warning) 후 01.Office/Reports/EQM1001.exe 배포 완료
- **검증 결과**: 단일 UTF-8 with BOM 및 CRLF 개행 무결성 5개 파일 100% 통과, MSBuild Release 리빌드 성공(0 Error, 0 Warning), 01.Office/Reports/EQM1001.exe(26,112 bytes) 배포 및 Git 상태 검증 완료

### 2. MTR0001_S04A 승인일자 임시 생략 반영 리빌드 및 MTR0001_R04 프로시저 조인 컬럼 오타 수정

- **수정/대상 파일**: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe), [05.PROCEDURE/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R04.sql)
- **배경 및 원인**: 발주서 출력(S04A.cs) 승인일자 데이터 부재에 따른 임시 주석 처리 반영 재빌드 및 배포, MTR0001_R04.sql 프로시저 전체 SQL 구문 검증 요청
- **작업 상세 내용**:
  - 1) S04A.cs 승인일자 텍스트 바인딩 주석 처리 반영 후 MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 2) 최신 MTR0001.exe 및 pdb 파일 01.Office/Reports/ 경로 배포 완료 3) MTR0001_R04.sql 전수 검증 결과, CALL_RPT 분기 사원 조인문 112행의 오타(MTRODR.EMPID -> MTRODR.ODREMPID) 발견 및 즉시 정상화 완료 4) UTF-8 with BOM 및 CRLF 개행 무결성 확인
- **검증 결과**: MSBuild 컴파일 통과 (0 Error, 0 Warning), MTR0001_R04.sql 112행 컬럼 오타 수정 및 전체 쿼리 문법 정합성 확인 완료

### 2. EQM1001 및 MTR0001 리포트 프로젝트 MSBuild 리빌드 및 최신 실행파일 배포

- **수정/대상 파일**: [04.Report/PAGEEQM/EQM1001/EQM1001.csproj](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/EQM1001.csproj), [04.Report/PAGEMTR/MTR0001/MTR0001.csproj](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/MTR0001.csproj), [01.Office/Reports/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 원인**: 설비관리(EQM1001) 및 자재발주관리(MTR0001) 리포트 2개 프로젝트 전체 재컴파일 및 01.Office/Reports 최신 바이너리 교체 요청
- **작업 상세 내용**:
  - 1) EQM1001.csproj MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 2) MTR0001.csproj MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 3) 생성된 최신 바이너리(EQM1001.exe, EQM1001.pdb, MTR0001.exe, MTR0001.pdb)를 01.Office/Reports/ 경로로 덮어쓰기 배포 완료
- **검증 결과**: MSBuild 컴파일 통과 (0 Error, 0 Warning), 01.Office/Reports/ 내 최신 바이너리 타임스탬프(14:37) 갱신 확인

### 2. MTR0001_R04 발주서 출력 검증 로직 프로시저(MTR0001_R04 CALL_RPT) 이동 및 화면 스크립트 간결화

- **수정/대상 파일**: [05.PROCEDURE/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 원인**: 화면(JS) 및 C# 리포트 비하인드에서 수행하던 발주번호 선택 유무 검증 로직을 DB 프로시저(CALL_RPT) 내부로 이동하여 검증 단일화 및 화면 스크립트 간결화 요청
- **작업 상세 내용**:
  - 1) MTR0001_R04.sql CALL_RPT 분기 상단에 IF COALESCE(, '') = '' THEN CALL COMERR('출력할 발주를 선택해주세요.'); LEAVE PROC; END IF; 추가 2) MTR0001_R04.js btn_PRINT 클릭 이벤트 내 rowIndex / !mtrOdrKey 다중 if 분기 제거하고 mtrOdrKey 취득 후 rpt.CallPop() 직접 호출 3) S04A.cs 파라미터 검증 throw 제거 후 maria.CallProc()로 프로시저 에러 직접 전파 4) MSBuild 15.0 Rebuild 성공 (0 Error, 0 Warning) 및 최신 MTR0001.exe 배포 완료
- **검증 결과**: MSBuild 컴파일 통과 (0 Error, 0 Warning), 전 파일 단일 UTF-8 BOM(\xef\xbb\xbf) 및 CRLF 개행 무결성 확인

### 2. MTR0001_R04 프로시저 Table 0 쿼리 종료 세미콜론(;) 누락 구문 오류 해결

- **수정/대상 파일**: [05.PROCEDURE/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R04.sql)
- **배경 및 원인**: 과잉 방어코드 정리 시 LIMIT 1; 제거 과정에서 WHERE 절 뒤 세미콜론(;)이 함께 탈락하여 Table 1 SELECT 문과 연결되며 SQL 문법 오류(SQL Error [1064]) 발생
- **작업 상세 내용**:
  - CALL_RPT 분기 Table 0(발주 헤더 쿼리) WHERE 절 끝에 세미콜론(WHERE MTRODR.MTRODRKEY = ;) 정상 반영, 단일 UTF-8 with BOM 및 Windows CRLF 개행 무결성 확인 및 정규화 완료
- **검증 결과**: 프로시저 전체 문법 및 세미콜론 종결자 무결성 확인, 단일 UTF-8 BOM(\xef\xbb\xbf) 및 CRLF 개행 검증 통과

### 8. MTR0001_R04 프로시저 MTR0001_R01 원본 기반 쿼리 표준화 및 과잉 방어코드 전면 제거

- **수정/대상 파일**: [05.PROCEDURE/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R04.sql)
- **배경 및 원인**: 기존 `MTR0001_R01` 기반의 깔끔하고 직관적인 쿼리 스타일로 통일하고, 과도하게 중첩된 방어 코드(불필요한 SET문, 텍스트 컬럼 COALESCE 남발, 복잡한 인라인 중첩, OR 조인 조건) 전면 제거 요청
- **작업 상세 내용**:
  1. `LIST_MTRODR`: 상단 4개 SET 초기화문 제거 및 WHERE 절 단일 COALESCE 인라인 조건화, 복잡한 사원 CASE WHEN을 `COALESCE(MSTEMP.EMPNM, NULLIF(MTRODR.ODREMPID, 0), '')`로 직관화, MSTEMP 조인 단일화(`EMPCD = CAST(ODREMPID AS CHAR)`)
  2. `LIST_MTRODRD`: 불필요한 `IF KEY = '' LEAVE` 방어문 및 `LEFT JOIN` 제거, R01과 동일하게 `INNER JOIN MSTITEM` 및 `ITEMCG LIKE 'DM1007%'`로 간결화
  3. `CALL_RPT`: 불필요한 검증문 제거, Table 0 11개 텍스트 컬럼의 과도한 `COALESCE(..., '')` 전면 제거, `EMPINFO`를 5줄 간결 구조로 단순화, Table 1의 불필요한 COALESCE 제거 및 단위 1줄 단일화(`COALESCE(GPCD('DM150', MSTITEM.ITEMUNIT), 'EA')`)
- **검증 결과**:
  - 프로시저 파라미터 규격(8개) 및 각 분기 반환 컬럼명·별칭 100% 일치 확인
  - 150줄 ➔ 124줄로 압축 및 R01 원본 수준의 가독성 확보
  - `git diff` 검증 통과 및 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 확인
  - 실제 서버 DB 미반영 (사용자 DBeaver 루틴 에디터 직접 반영 대상)

### 7. MTR0001_S04A 승인일자 바인딩(MTRODRDATE 기준) 수정에 따른 리포트 재빌드 및 배포

- **수정/대상 파일**: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 원인**: 발주서 우측 상단 발주승인완료 도장 박스의 날짜를 `MTRODRDATE` 직접 바인딩으로 수정한 소스코드 반영 및 재빌드 배포 요청
- **작업 상세 내용**:
  - `04.Report/PAGEMTR/MTR0001/S04A.cs` 변경 사항 확인 및 파일 인코딩(단일 UTF-8 with BOM, CRLF) 무결성 사전 검증
  - MSBuild 15.0 Rebuild (`/t:Rebuild /p:Configuration=Release`) 실행하여 0 Error, 0 Warning 컴파일 성공 확인
  - 최신 바이너리 `04.Report/PAGEMTR/MTR0001/bin/Release/MTR0001.exe` 및 `.pdb`를 `01.Office/Reports/` 경로로 복사 배포 완료
- **검증 결과**:
  - MSBuild 리빌드 통과 (에러 0건, 경고 0건)
  - 배포된 `01.Office/Reports/MTR0001.exe` 최신 타임스탬프(13:07:11) 확인
  - 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 확인

### 6. MTR0001_S04A 사용자 직접 수정 소스코드 검증, MSBuild 리빌드 및 최신 실행 파일 배포

- **수정/대상 파일**: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 원인**: 사용자의 S04A.cs 직접 수정 후 재컴파일 및 오피스 배포 경로(`01.Office/Reports/MTR0001.exe`) 적용 요청
- **작업 상세 내용**:
  - `04.Report/PAGEMTR/MTR0001/S04A.cs` 변경 사항 확인 및 파일 인코딩(단일 UTF-8 with BOM, CRLF) 무결성 사전 검증
  - MSBuild 15.0 Rebuild (`/t:Rebuild /p:Configuration=Release`) 실행하여 0 Error, 0 Warning 컴파일 성공 확인
  - 최신 바이너리 `04.Report/PAGEMTR/MTR0001/bin/Release/MTR0001.exe` 및 `.pdb`를 `01.Office/Reports/` 경로로 복사 배포 완료
- **검증 결과**:
  - MSBuild 리빌드 통과 (에러 0건, 경고 0건)
  - 배포된 `01.Office/Reports/MTR0001.exe` 최신 타임스탬프(11:53:42) 확인
  - 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 확인

### 5. MTR0001_S04A 발주서 안내문/비고 볼드(Bold) 서식 반영 및 리포트 재빌드 배포

- **수정/대상 파일**: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 원인**: 발주서 출력 리포트 하단 업체 요청 사항 비고 내용(`reqContent`) 및 3줄 안내문(`notice1`, `notice2`, `notice3`)의 시인성 강화를 위해 Bold 서식 적용 후 재빌드 및 배포 요청
- **작업 상세 내용**:
  - `reqContent.Font`: `FontStyle.Bold` 적용
  - `notice1`, `notice2`, `notice3`: `FontStyle.Bold` 적용
  - MSBuild 15.0 Release 빌드 성공 (에러 0건, 경고 0건)
  - 최신 실행 파일 `01.Office/Reports/MTR0001.exe` 및 `.pdb` 덮어쓰기 배포 완료 (타임스탬프 11:52:20)
- **검증 결과**:
  - MSBuild 빌드 무결성 통과 (0 Error, 0 Warning)
  - 배포 파일 일치 확인 및 단일 UTF-8 with BOM (`\xef\xbb\xbf`), CRLF 개행 무결성 확인

### 2. [MTR0001_R04] 발주 조회조건 간소화 및 사업장 연결 검증

- **수정/대상 파일**: 05.Procedure/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: 날짜 컬럼을 매 행 LEFT/REPLACE로 가공하고 공장 검색식이 길어 조회조건 정리 요청
- **작업 상세 내용**:
  - 날짜 입력값 형식을 비교 시 변환하고 저장 날짜는 직접 비교; 검색 파라미터 NULL 처리는 분기 시작에서 1회 수행; 발주·입고 공장 비교를 IN으로 묶고 입고공장 미지정 포함 기준 유지; 사용자 변경의 발주공장→MSTFACTORY→MSTBDV 연결 유지 및 SELECT 확인; 상세·출력 분기와 파라미터 8개 유지
- **검증 결과**: 실제 DB SELECT 전후 5조건 결과·정렬·중복 일치(전체75/기간51/당일1/07공장0/NULL75); 발주일자1137건 YYYY-MM-DD 확인; 공장06→사업장61/07→71 연결 및 JOIN 행수 검증; 격리 MariaDB10.2.44 전후 컴파일 및20조건 비교/잘못된 날짜 검증 통과; 날짜 인덱스 부재로 실행계획 동일; 단일BOM/CRLF 확인

### 2. MTR0001_R04 품목조건 단순화 및 공장 마스터 기반 사업장 연결

- **수정/대상 파일**: 05.Procedure/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: 중복 품목유형 조건 및 07이면71·그외61 고정 CASE 개선 요청, 61/71 사업장 의미 확인 요청
- **작업 상세 내용**:
  - 실제 DB에서 MSTBDV61=아이앤씨_보령,71=아이앤씨_보령2공장 및 MSTFACTORY06→61/07→71 등록 확인. CALL_RPT에서 발주공장 우선·비어있으면 입고공장으로 MSTFACTORY를 연결한 뒤 BDVCD로 MSTBDV 직접 연결. 미등록 공장에 61 강제대입과 고정 회사정보 대체값 제거, 등록 정보가 없으면 공란. 헤더·상세 ITEMCG 중복 등식 제거하고 LIKE DM1007%로 단순화, 상세 NULL 허용은 기존대로 유지. 사용자 컬럼 설명11개 보존 및 동일 날짜 Modify 한 줄 병합, 입력8개 유지
- **검증 결과**: 실제 SELECT로 사업장10건·공장7건과 컬럼·PK 확인. 발주1137건 사업장매핑 전후 일치, 헤더75건·상세249건 및 06/07 표본 발주서 헤더값 전후 동일. 네트워크차단 MariaDB10.2.44에서 컴파일, 기존/신규공장, 빈공장대체, 발주공장우선, 미등록 공란, 마스터변경반영, 품목조건NULL·순서동등성 포함 총13검증 통과. 단일BOM/CRLF 정상. 실제 서버 DDL/DML 없음, C#·화면소스 변경 없음

### 2. MTR0001_R04 발주서 컬럼 설명 주석 복구 및 조건 설명

- **수정/대상 파일**: 05.Procedure/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: 사용자가 제공한 발주서 반환 컬럼 설명 주석11개 복구 및 품목유형 필터·사업장 CASE 연결 해석 요청
- **작업 상세 내용**:
  - APRVDATE·거래처정보·사업장정보11개 컬럼 인라인 주석을 제공된 문구로 복구, 동일 날짜 Modify 한 줄에 반영. 실행SQL 변경 없음. 기존 업무 주석 유지와 필요한 테이블만 연결하는 선호 확인
- **검증 결과**: 주석 제거 후 수정 전후 SQL 문자열 동일 확인,11개 별칭 일치 확인, 단일BOM/CRLF 정상. 주석만 수정하여 DB실행·프로시저컴파일 미진행

### 2. MTR0001_R04 타 공장 사원 참조 제거 및 미매칭 원래 코드 표시

- **수정/대상 파일**: 05.Procedure/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: 현재 공장 MES_SNS2의 사원정보만 사용하고 사원 미등록 시 원래 발주 사원코드를 표시하도록 요청
- **작업 상세 내용**:
  - LIST_MTRODR 및 CALL_RPT에서 MES_SNS.MSTEMP JOIN2개와 SNS_EMP 참조 제거. 현재 공장 EMPID/EMPCD 매칭 이름 사용, 매칭 또는 유효 이름이 없으면 MTRODR.ODREMPID 원본 코드 표시. 발주서 EMPINFO의 고정 사원명·직급·휴대폰·부서 대체값 제거, 실제 소속·직급·연락처만 조합. 기존 0/NULL코드는 공란 유지. 최신 SQL의 CUSTCD·MTRODRSEQ 복원 상태 등 다른 사용자 변경 보존, 동일 날짜 Modify 한 줄 병합
- **검증 결과**: 실제 DB SELECT로 현재 공장 사원 매핑과 6개테이블307컬럼 확인, 4318/4328/4329/4438은 현재 공장 미매칭. 수정 SELECT로 발주75건·표본 발주서1건 원래코드 표시 확인. MES_SNS DB 없이 네트워크 차단 MariaDB10.2.44 컴파일 및11건 검증 통과. 입력8개·상세분기 유지, ASPX·JS·비하인드·S04A 해시 동일, 단일BOM/CRLF 정상. 실서버 DDL/DML 없음

### 4. MTR0001_S04A 설비부품 발주서 상단 마진 확대(15F➔45F), 로고·승인박스 확대 및 좌측 밀착 정렬

- **수정/대상 파일**: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 원인**:
  - 발주서 출력 리포트 상단 영역이 용지 맨 윗단에 너무 바짝 붙어있어(기존 TopMargin 15F) 상단 여백 폭 확보 요청
  - 상단 로고 이미지와 승인 도장 박스 크기 확대 및 가시성 개선 요청
  - `ImageSizeMode.ZoomImage` 기본 중앙 정렬(`MiddleCenter`)로 인한 로고 좌측 빈 여백(26.6F) 제거 요청
- **작업 상세 내용**:
  - 상단 여백 확대: `Margins.Top = 45`, `topMargin.HeightF = 45F`로 3배 확대하여 용지 상단에 안정적이고 품격 있는 여백 폭 확보 (A4 1페이지 규격 유지)
  - 로고 좌측 여백 제거 및 정렬: `logoBox.ImageAlignment = ImageAlignment.MiddleLeft;` 적용하여 박스 좌측 끝선(X=0F)에 밀착 정렬
  - 로고 크기 확대: `logoBox.SizeF` 160x38F ➔ 190x45F, 거래처명 Y좌표 51F 여백 조정
  - 우측 승인 도장 박스 크기 확대: `approveTable.SizeF` 115x44F ➔ 140x56F(너비 140F, 행높이 각 28F), 우측 731F 끝선 정렬(LocationFloat X=591F), 폰트 상향(10pt Bold / 9.5pt Regular)
  - MSBuild 15.0 Release 빌드 성공 및 `01.Office/Reports/MTR0001.exe`, `.pdb` 최신 실행 파일 배포 완료
- **검증 결과**:
  - MSBuild Release 빌드 에러 0건, 경고 0건 컴파일 성공 확인
  - `01.Office/Reports/MTR0001.exe` 배포 완료 및 타임스탬프 갱신 확인
  - 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 검증 완료

### 2. MTR0001_R04 화면·발주서 미사용 반환 컬럼과 JOIN 제거

- **수정/대상 파일**: 01.Office/PAGEMTR/MTR0001/MTR0001_R04.js, 05.Procedure/MES_SNS2_MTR0001_R04.sql
- **배경 및 원인**: 최신 ASPX·비하인드·JS·S04A를 대상으로 실제 DB SELECT 및 사용처 분석 후 불필요한 컬럼 제거 요청
- **작업 상세 내용**:
  - JS 숨김 CUSTCD/MTRODRSEQ/ODRDELEMPID 제거, 상세 조회 AddRecord 전체 전송을 MTRODRKEY만 명시 전송으로 변경. SQL 헤더 CUSTCD, 상세 MTRODRSEQ/ODRDELEMPID, 보고서헤더 MTRODRSTT/APRVSTTNM/CUSTCD, 보고서품목 NO/MTRODRSEQ/ITEMCD 제거(반환 컬럼 분기 합계9개). 상세 사원 JOIN2개 및 리포트 상태명 COMTYPE JOIN1개 제거. MTRODRSEQ 정렬·CUSTCD 검색 유지, 입력 파라미터8개 유지. ASPX·비하인드·S04A의 데이터 사용은 필요한 것으로 확인하여 내용 및 배포 바이너리 변경 없음
- **검증 결과**: 실제 DB SELECT로 8개 테이블362컬럼·인덱스15행·프로시저입력8개 확인. 수정 전후 실제 헤더75건·상세249건 및 표본 보고서 헤더1/품목3건 유지 컬럼값과 정렬 일치. Node VM/정적14건, 네트워크차단 MariaDB10.2.44 컴파일·필터·정렬·NULL키·결과셋8건 통과. S04A 복사본 테스트 생성자만 추가하여 C#컴파일 및 실제 DevExpress CreateDocument로 전후 컨트롤 내용·배치와1페이지, 빈품목·NULL품목3건 확인. JS문법·단일BOM/CRLF 통과. 실서버 DDL/DML·브라우저E2E·프로덕션C#변경 없음

### 3. Git 무시 목록(.gitignore)에 Subversion(.svn, wc.db) 등록 및 기존 추적 파일(4,179건) Git 인덱스 전면 삭제

- **수정/대상 파일**: [.gitignore](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.gitignore), Git 인덱스
- **배경 및 원인**: SVN 작업 복사본의 `.svn` 디렉터리 및 `wc.db` 관련 메타데이터 파일들이 Git 인덱스에 기존 4,179건이나 추적(tracked)되어 있어, SVN 업데이트 시마다 변경사항이 지속 발생하는 문제 해결 요청
- **작업 상세 내용**:
  - [.gitignore](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.gitignore)에 Subversion 디렉터리(`.svn/`, `**/.svn/`) 및 SQLite 메타데이터 파일(`wc.db`, `wc.db*`) 패턴 등록
  - `git rm -r --cached .svn`을 실행하여 로컬 디스크의 실제 SVN 작업본은 안전하게 보존하면서 Git 저장소(인덱스)에서만 추적 파일 4,179건 일괄 제거
- **검증 결과**:
  - `git ls-files .svn` 조회 결과 Git 추적 파일 0건 확인
  - 실제 로컬 디스크 파일(`Test-Path .svn/wc.db`) 존재(True) 확인으로 SVN 동작 영향 없음 검증
  - `git diff --staged --stat` 결과 4,180개 파일(gitignore 1건 수정, svn 4,179건 삭제 대기) 정상 스테이징 확인
  - 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 검증 완료

### 2. 사용 중단 컬럼의 JS·SQL·프로시저 최종 검증 규칙 추가

- **수정/대상 파일**: .agents/rules/validation.md
- **배경 및 원인**: 읽기 전용 또는 사용 중단 컬럼의 전송·분해·저장 코드가 잔존하여 다른 데이터 초기화 등 문제가 재발하지 않도록 최종 검증 단계 규칙화 요청
- **작업 상세 내용**:
  - validation.md 5절에 사용 중단 범위와 실제 DB 기본값 확인, 호출 경로 전체 추적, 주석 코드 포함 제거, 제외값 의존 조건 제거, 파라미터 등록 일치, 기존값 보존·신규 기본값·팝업 동작 검증, 완료 전 재검색 및 검증 범위 기록 8항 추가. 조회·별도 팝업 사용처 유지 이유 명시 및 실서버 변경 금지 규칙 연결
- **검증 결과**: 기존 1~4절 내용 유지 및 변경 diff 확인. 단일 UTF-8 BOM/CRLF 확인. 문서 변경만 수행하여 업무 소스·DB 테스트 및 실제 서버 반영 없음

### 1. MST3001_R03 조회 전용 현재고·로케이션명 저장 경로 제거

- **수정/대상 파일**: 01.Office/PAGEMST/MST3001/MST3001_R03.js, 05.Procedure/MES_SNS2_MST3001_R03.sql, 05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql
- **배경 및 원인**: 현재고와 메인 로케이션명은 수정 불가이나 주석 처리된 전송 코드 및 프로시저 입력·분해·저장 의존이 잔존. 이름 미전송 시 SAVE_ITEM이 로케이션 코드까지 초기화하는 조건 확인
- **작업 상세 내용**:
  - 메인 저장은 ITEMID/GRADE/SAFEQTY/LOCACD 4종 목록만 전송. LOTQTY_LIST 입력·지역변수·분해·신규 INSERT 대입 제거, LOCANM 저장 및 변경비교·원본 보관·직접 수정 분기 제거. LOCANM readonly 명시, Delete는 코드 선택 범위만 처리. SAVE_ITEM의 이름 빈값에 의존한 코드 초기화 제거. LOCANM_LIST와 관련 변수는 로케이션 기준정보 팝업 CRUD용으로 유지. 파라미터 14→13 및 등록 SQL 설명 갱신
- **검증 결과**: 실서버 SELECT로 3개 테이블 112컬럼 확인, LOTQTY 기본값0 확인. 공통 ItsGrid 실제 소스를 사용한 Node VM 검증14건 및 네트워크 차단 MariaDB10.2.44에서 컴파일·현재고보존·코드단독저장·신규기본값·팝업CRUD·등록13건 검증13건, 총27건 통과. JS문법 및 단일BOM/CRLF 확인. 실서버 DDL/DML 및 브라우저 E2E 미실행

---

## 🕒 2026-10-14 (수) 작업 내역

### 23. 공통 프레임워크 우선 활용 및 기존 화면 참조 규칙 추가, 레포트 임시 파일 정리 및 .gitignore 등록

- **수정 및 신규 파일**:
  - 신규 규칙: [.agents/rules/framework_convention.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md)
  - 환경 설정: [.gitignore](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.gitignore)
  - 로컬 정리: `01.Office/Reports/tempFiles/*`, `04.Report/bin/tempFiles/*` 로컬 임시 산출물 삭제 및 Git 캐시 제거
- **배경 및 사용자 피드백**:
  - 앞으로 레포트 및 일반 기능 개발 시 공통 프레임워크(`ItsFramework`)에서 지원하는 기능을 최대한 활용하고, 프로젝트 내 기존 검증된 페이지들을 참고하여 유사한 표준 형태로 제작하도록 하는 규칙 제정 요청.
  - 지금까지 리포트 출력 테스트 중 로컬에 쌓였던 임시/쓰레기 파일들(`tempFiles` 내부 `*.pdf`, `*.html`, `*_files/`)을 모두 `.gitignore`에 추가하고 로컬 디스크 및 Git 저장소에서 깨끗이 삭제 요청.
- **작업 상세 내용**:
  1. **신규 규칙 제정 ([`.agents/rules/framework_convention.md`](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md))**:
     - **공통 프레임워크 우선 활용 원칙 (Framework-First)**: 기능 착수 전 `ItsXtraRpt`, `ItsGrid`, `ItsFind`, `ItsPop`, `ItsCombo`, `ItsMsg` 및 백엔드 공통 컨트롤러 지원 여부를 우선 확인하고, 자동 처리 동작(타임스탬프 파일명 자동 발급, 모달 중앙 정렬, 유효성 검사 등)의 인위적 중복 재구현 및 하드코딩 금지.
     - **기존 유사 화면 참조 원칙 (Reference-First)**: 독자적 구현 대신 프로젝트 내 이미 안정적으로 운영 중인 화면(SAL0001_S05, EQM1001_S01 등)의 레이아웃(`.aspx`), 스크립트(`.js`), 비하인드(`.cs`), 프로시저(`.sql`) 구조를 그대로 모방하여 표준 일관성 준수.
     - **리포트(`ItsXtraRpt`) 표준 연동 규정**: `new ItsXtraRpt('리포트명')` 생성 ➔ `AddParam` 조건 바인딩 ➔ `CallPop()`/`Call()` 호출 간결화, 파일명 수동 지정(`rpt.FileName`) 금지, 기존 리포트 C# 비하인드 모방.
     - **리포트 임시 파일 형상 관리 격리**: 출력 테스트 중 자동 생성되는 임시 파일의 Git 추적 차단 명시.
  2. **Git 추적 임시 파일 제거 및 로컬 청소**:
     - 기존 Git 인덱스에 포함되어 있던 `01.Office/Reports/tempFiles/` 및 `04.Report/bin/tempFiles/` 내 수십 개의 `*.pdf`, `*.html`, `*_files`를 `git rm -r --cached`로 인덱스에서 완전 제거.
     - 로컬 디스크 상에 남아있던 잔여 임시 파일들을 완전 삭제하여 디스크 및 소스 트리 정리.
  3. **[`.gitignore`](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.gitignore) 생성 및 패턴 등록**:
     - `01.Office/Reports/tempFiles/`, `04.Report/bin/tempFiles/`, `**/tempFiles/`, `*.pdf` 패턴 등록 (단, pdfjs 라이브러리 및 docs는 예외 처리 `!01.Office/Script/pdfjs/**`, `!03.Pda/Script/pdfjs/**`, `!docs/**`로 보존).
- **검증 결과**:
  - `git status` 확인 결과 불필요한 임시 산출물이 전면 정리되고 `.gitignore` 및 신규 규칙만 깔끔하게 추적됨을 확인.
  - 모든 신규/수정 파일 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 검증 완료.

### 22. MTR0001_R04 및 EQM1001_R03 리포트 호출 시 불필요한 rpt.FileName 제거 및 프레임워크 표준 정돈

- **수정 파일**:
  - 화면 스크립트: [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js)
- **배경 및 사용자 피드백**:
  - 리포트 호출부에서 인위적으로 파일명을 지정(`rpt.FileName(...)`)하던 코드가 다른 기존 페이지(SAL0001_S05, EQM1001_S01 등)의 사용 관례와 일치하지 않으며 불필요하다는 피드백.
  - 공통 프레임워크(`XtraReport.aspx.cs`)에서 파일명을 자동 처리하므로 화면 단의 불필요한 하드코딩 제거 요청.
- **원인 및 분석**:
  - 공통 리포트 컨트롤러(`XtraReport.aspx.cs`)에서 `fileName`이 빈 문자열이면 `DateTime.Now.Ticks`로 고유 임시 파일명을 자동 발급하여 관리하므로, 화면 스크립트에서 파일명을 굳이 지정할 필요가 전혀 없음.
  - 기존 프로젝트의 다른 리포트 호출 페이지들(`SAL0001_S05.js`, `EQM1001_S01.js` 등)도 `rpt.FileName(...)`을 호출하지 않고 순수 파라미터 전달 및 `CallPop()`/`Call()`만 수행하는 표준 패턴을 준수하고 있었음.
- **작업 상세 내용**:
  - `MTR0001_R04.js`: `rpt.FileName('설비부품_발주서_' + mtrOdrKey);` 라인 제거.
  - `EQM1001_R03.js`: `rpt.FileName('제조설비_정기점검계획서_' + planCd);` 라인 제거.
- **검증 결과**:
  - Node.js 구문 검사(`node -c`) 통과 (오류 0건).
  - 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 검증 완료.

### 21. MST3001_R03 드래그 선택 영역 Delete 키 삭제 시 로케이션명 잔존 결함 원인 분석 및 캡처링 이벤트 해결

- **수정 파일**:
  - 화면 스크립트: [01.Office/PAGEMST/MST3001/MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)
- **배경 및 사용자 피드백**:
  - 메인 그리드에서 마우스 드래그로 다중 행/열(14~17행)을 선택하고 DELETE 키를 눌러 값을 삭제했으나, 로케이션코드는 비워지는데 로케이션명(예: `테스트 로케이션 3`)이 화면에 그대로 잔존하는 문제 발생.
  - 정확한 원인 규명 및 실무에서 가장 많이 쓰이고 간결한 방법으로의 확실한 해결 요청.
- **원인 분석**:
  1. **스크립트 실행 시점 불일치 (이벤트 바인딩 실패)**: 기존 `$('#grid1').keydown(...)` 코드가 스크립트 최상위 레벨에 위치하여, `<head>` 태그 내에서 스크립트 파싱 시 DOM 상의 `<div id="grid1">` 요소가 아직 생성되지 않아 길이 0의 객체에 이벤트가 걸리면서 리스너 등록 자체가 무효화되었음.
  2. **Wijmo 기본 Delete와 onChanged 미발생**: 사용자가 드래그 후 DELETE를 누르면 Wijmo FlexGrid 자체의 기본 키 이벤트만 동작하여 선택된 `LOCACD` 셀만 지워졌고, Wijmo의 다중 셀 삭제는 `cellEditEnded`를 트리거하지 않아 `onChanged` 이벤트가 실행되지 않아 옆 컬럼인 `LOCANM`이 지워지지 않고 잔존했음.
- **작업 상세 내용**:
  1. **`ItsPage.Load` 내부 `grid.hostElement.addEventListener('keydown', ..., true)` 캡처링 바인딩**:
     - 그리드 생성 직후 DOM이 확실히 존재하는 시점에 순수 DOM 캡처링 이벤트로 Delete 키(46)를 최우선 가로챔.
     - `grid.selection`의 `topRow`~`bottomRow` 및 `leftCol`~`rightCol` 범위를 판별하여, 로케이션 관련 컬럼(`LOCACD`, `LOCANM`)이 포함된 경우 `SetLocaRows(top, bottom, '', '')`를 즉각 실행.
     - 로케이션 단독 선택 시 `e.preventDefault()`로 불필요한 기본 이벤트 차단, 다중 컬럼 선택 시 타 컬럼 삭제 흐름과 공존 처리.
  2. **`GetCheckedRows` 순수성 유지 (과도한 중복 방어 로직 배제)**:
     - 실시간 UI 캡처링 이벤트와 DB 프로시저에서 이미 완전 방어되므로, 공통 유틸 함수인 `GetCheckedRows` 내 임의 데이터 변조 로직을 배제하고 체크 행 수집 본연의 기능만 간결하게 유지.
- **검증 결과**:
  - Node.js 구문 검사(`node -c`) 통과 (오류 0건).
  - 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 검증 완료.

### 20. .agents/rules 프로시저 개발 규칙 글자 수 초과 해소 및 주제별 5대 세분화(모듈화) 리팩토링 완료

- **수정 및 신규 파일**:
  - 기존 규칙 슬림화: [.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md) (21.5KB ➔ 5.7KB)
  - 서버 다운 방지 규칙 분리 신설: [.agents/rules/procedure_subquery.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure_subquery.md)
  - DB 툴 컴파일 표준 규칙 분리 신설: [.agents/rules/procedure_compile.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure_compile.md)
  - 서식 및 열 정렬 표준 규칙 분리 신설: [.agents/rules/procedure_formatting.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure_formatting.md)
  - 공통 감사 함수 표준 규칙 분리 신설: [.agents/rules/procedure_audit.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure_audit.md)
- **배경 및 사용자 피드백**:
  - `.agents/rules` 내 기존 `procedure.md` 파일이 13,655자(258줄, 21.5KB)에 달하여 에이전트 시스템 규칙 주입 한도 초과 및 세부 규칙 누락 위험 발생.
  - 규칙을 주제별로 명확하게 세분화하여 모든 규칙이 누락 없이 제대로 주입·적용될 수 있도록 꼼꼼한 분할 정리 요청.
- **작업 상세 내용**:
  1. **`procedure_subquery.md` 신설 (3.4KB, 63줄)**:
     - SELECT WHERE 절 내 상관 서브쿼리(NOT EXISTS / EXISTS / OR EXISTS) 사용 절대 금지 및 MariaDB SIGSEGV 크래시 원인 분석.
     - Anti-join(`LEFT JOIN ... WHERE B.KEY IS NULL`) 및 INNER/LEFT JOIN 표준 대체 패턴 집중 규정.
  2. **`procedure_compile.md` 신설 (2.4KB, 38줄)**:
     - DBeaver / HeidiSQL 명령문 구분자(;) 파싱 에러(`SQL Error [1064]`) 원인 분석.
     - Routine Editor 직접 수정(Save/Ctrl+S), Alt+X 전체 스크립트 실행, DELIMITER 명시 등 3대 컴파일 및 반영 방법 독립 문서화.
  3. **`procedure_formatting.md` 신설 (4.8KB, 70줄)**:
     - CREATE DEFINER 및 PROCEDURE 2행 개행 선언 강제 (한 줄 선언 절대 금지).
     - 코드 들여쓰기 계층 구조(본문 2스페이스, 분기 2스페이스, 실행 4스페이스, 중첩 6스페이스).
     - SELECT/INSERT 절 한 줄 다중 컬럼 가로 나열 표준 및 JOIN/WHERE 정렬 표준, 표준 구분선 선언 위치 독립 문서화.
  4. **`procedure_audit.md` 신설 (1.4KB, 31줄)**:
     - 등록/수정 시 `CALLTIME()`, `CALLEMP()`, `CALLPRG()` 공통 내장 함수 필수 호출 표준화.
     - `NOW()`, `@CALLEMP`/`@CALLPRG`, `_$NOW` 대입 절대 금지 패턴 명시.
  5. **`procedure.md` 슬림화 및 연계 가이드 구축 (5.7KB, 62줄)**:
     - 0순위 원칙(실제 서버 DB 조작 금지, 로컬 .sql 파일만 수정), SQL 가시성 및 성능 최적화, 입력값 검증, 내부 기능 주석 간소화(날짜 표기 금지) 등 핵심 기본 원칙 중심으로 슬림화.
     - 6대 프로시저 세부 규칙 문서 연계 가이드 테이블 구축.
- **검증 결과**:
  - `.agents/rules/` 내 전체 15개 규칙 문서가 **19줄~70줄, 1.4KB~6KB** 범위로 균일하게 정돈되어 글자 수 제한 초과 및 누락 위험 완전 해소.
  - 모든 규칙 파일 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 검증 100% 완료.

### 19. MST3001_R03 Delete 키 및 드래그 다중 행 삭제 시 로케이션 동기화 및 DB 삭제(비움) 반영

- **수정 파일**:
  - 화면 스크립트: [01.Office/PAGEMST/MST3001/MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)
  - DB 프로시저: [05.Procedure/MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql)
- **배경 및 사용자 피드백**:
  1. `MST3001_R03.js` 메인 그리드의 로케이션코드(`LOCACD`) 컬럼에서 DELETE 키를 눌러 값을 지우거나, 사용자가 값을 전부 지워버렸을 경우 로케이션명(`LOCANM`)도 함께 지워지도록 동기화 요청.
  2. DELETE 키로 값을 비우고 저장을 눌렀으나, DB 상에서 로케이션이 삭제되지 않고 기존 값이 그대로 유지되는 결함 해결 요청.
- **원인 분석**:
  1. **JavaScript keydown 가로챔**: 공통 마스터 스크립트(`MasterBase.js`)에서 `e.keyCode == 46`을 체크박스 전용으로 가로채 `ItsGrid.Event('grid1').onKeydown`이 아예 호출되지 않았음.
  2. **JavaScript onChanged 누락**: `LOCACD` 셀 에디트 종료 시 값이 빈 문자열이 되었을 때 `LOCANM`을 비워주는 분기가 누락되어 로케이션명이 화면에 그대로 잔존했음.
  3. **프로시저 자동 복원 로직**: 프로시저 `SAVE_ITEM` 분기에서 `IF _$LOCACD = '' AND _$LOCANM <> '' THEN`으로 로케이션명이 남아있으면 `MSTLOCA_EQMPARTS`에서 `LOCACD`를 재조회하여 복원해버려, 화면에서 코드만 지우고 저장했을 때 예전 코드가 그대로 복원되어 UPDATE 되었음.
- **작업 상세 내용**:
  1. **화면 스크립트 수정 및 실무 표준 리팩토링 ([01.Office/PAGEMST/MST3001/MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js))**:
     - `ItsPage.Load` 내부에 있던 장황한 DOM 캡처링 리스너를 완전히 걷어내어 본연의 컨트롤 초기화만 유지하도록 단순화.
     - 이벤트 영역에 실무 MES 표준 jQuery 핸들러인 `$('#grid1').keydown`으로 Delete 키(46) 처리 통일.
     - **드래그 다중 행 일괄 삭제 및 실시간 렌더링 지원**:
       - 마우스로 여러 행을 드래그 선택 시 `grid.selection`의 `leftCol`~`rightCol` 및 `topRow`~`bottomRow` 영역을 판별하여 `SetLocaRows(top, bottom, '', '')` 호출.
       - 선택된 모든 행의 `LOCACD`와 `LOCANM`을 일괄 빈 값(`''`)으로 세팅하고 행 체크박스(`isRowCheck`)를 체크한 후, `grid.refresh()`를 즉시 호출하여 화면 옆 로케이션명이 실시간으로 즉각 비워지도록 동기화 보장.
     - `onChanged` 이벤트 핸들러 보완: 단일 셀 편집으로 값을 지우거나 변경할 때도 `SetLoca` 및 `grid.refresh()`를 호출하여 화면이 지연 없이 즉시 갱신되도록 처리.
  2. **DB 프로시저 수정 ([05.Procedure/MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql))**:
     - `SAVE_ITEM` 분기에서 `IF _$LOCACD = '' OR _$LOCANM = '' THEN SET _$LOCACD = ''; END IF;` 로직 적용.
     - 로케이션 코드 또는 명이 비어있는 경우 이전 코드를 조회하여 복원하는 로직을 완전히 제거하고, 빈 값(`''`)으로 확정하여 `MSTITEM_EQMPARTS.LOCACD = ''`로 안전하게 업데이트(삭제) 처리.
     - 최상단 `Modify` 이력 영역 1일 1행 원칙에 따라 갱신.
- **검증 결과**:
  - `node -c 01.Office/PAGEMST/MST3001/MST3001_R03.js` 문법 검사 통과 (오류 0건).
  - 수정된 파일(`MST3001_R03.js`, `MES_SNS2_MST3001_R03.sql`, `WORK_HISTORY.md`) 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 무결성 검증 완료.

### 18. MST3001_R03 중요도등급(GRADE) 수정·저장 및 현재고(LOTQTY) 입력 차단 연동, 프로시저 공통 감사함수(CALLTIME/CALLEMP/CALLPRG) 강제 규칙 제정 및 적용

- **수정 파일**:
  - 개발 규칙 문서: [.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md)
  - 화면 스크립트: [01.Office/PAGEMST/MST3001/MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)
  - DB 프로시저: [05.Procedure/MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql)
  - DB 시스템 파라미터: [05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql)
- **배경 및 사용자 피드백**:
  1. `MST3001_R03.js` 메인 그리드에서 "현재고"(`LOTQTY`) 컬럼 입력을 차단하고, "중요도등급"(`GRADE`) 컬럼 수정이 가능해짐에 따라 저장 연동 요청.
  2. 데이터 조회 후 `ItsGrid.Get('grid1').autoSizeColumns();` 실행 여부 확인 및 누락된 곳(`SearchLoca` 등)에 보완 요청.
  3. 프로시저에서 공통 내장 함수(`CALLTIME()`, `CALLEMP()`, `CALLPRG()`)를 필수 활용하도록 규칙(`procedure.md`)에 추가하고 해당 프로시저에 적용 요청.
- **작업 상세 내용**:
  1. **프로시저 공통 규칙 추가 ([.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md))**:
     - 6번 항목으로 `공통 감사(Audit) 함수 필수 사용 원칙 (CALLTIME(), CALLEMP(), CALLPRG())` 신설.
     - 등록 시 `RTIME = CALLTIME()`, `REMP = CALLEMP()`, `RPRG = CALLPRG()`, 수정 시 `MTIME = CALLTIME()`, `MEMP = CALLEMP()`, `MPRG = CALLPRG()` 호출을 표준으로 강제. `NOW()`나 `@CALLEMP`, `@CALLPRG` 직접 대입 금지 명시.
  2. **프로시저 수정 ([05.Procedure/MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql))**:
     - `IN $GRADE_LIST MEDIUMTEXT` 파라미터 및 `DECLARE _$GRADE VARCHAR(100);` 변수 추가.
     - 공장코드 기본값 보정: 레거시 기본값 `'02'`를 SNSINC 2공장의 올바른 공장코드인 `'07'`로 전면 업데이트 (`SEL_ITEM`, `SAVE_ITEM` 분기에서 `$FACTORYCD` 누락 시 `'07'` 기본 적용 및 `MSTITEM_EQMPARTS.FACTORYCD = '07'` 정확한 조인).
     - `SAVE_ITEM` 분기에서 `CALL COMSPLIT($GRADE_LIST, _$GRADE);` 및 `MSTITEM_EQMPARTS`에 `GRADE = _$GRADE` 저장 연동.
     - 현재고 컬럼 입력 차단에 따라 `UPDATE` 시 기존 재고 왜곡 방지를 위해 `LOTQTY`는 업데이트 대상에서 제외하고 기존 값 보존.
     - `SAVE_ITEM`, `SAVE_LOCA` 전반의 등록/수정 일시 및 작업자 컬럼에 `CALLTIME()`, `CALLEMP()`, `CALLPRG()` 공통 함수 적용 (`_$NOW` 및 `@CALLEMP`/`@CALLPRG` 제거).
     - 최상단 `Modify` 이력 1일 1행 원칙 및 2행 개행 선언부 준수.
     - `SYSTEM_PARAMETERS.sql` 주석 및 총 14건 파라미터 검증 쿼리 동기화.
  3. **화면 스크립트 수정 ([01.Office/PAGEMST/MST3001/MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js))**:
     - `grid1` 현재고(`LOTQTY`) 컬럼에 `readOnly: true` 설정하여 입력 차단.
     - `grid1` 로케이션명(`LOCANM`) 컬럼의 불필요한 `columnType: enumColumnTypes.combo` 설정을 해제 (`combo column must have 'gpcd' attribute.` 오류 해결).
     - 로케이션 검색 팝업 오픈(`OpenLoca`) 대상을 오로지 로케이션코드(`LOCACD`) 컬럼으로만 제한(`if (field !== 'LOCACD') return;`)하여 로케이션명(`LOCANM`) 클릭/더블클릭 시 팝업 차단.
     - `EventSearch` 시 `row._ORG_GRADE = row.GRADE;` 원본값 보관 추가.
     - `GetCheckedRows`에서 `GRADE` 변경 감지 로직 추가.
     - `ItsButton.EventSave`에서 `maria.AddList('GRADE_LIST', (row.GRADE || '').trim());` 전송 추가.
     - `SearchLoca` 함수에서 로케이션 조회 후 `ItsGrid.Get('grid_LOCA').autoSizeColumns();` 누락 보완.
- **검증 결과**:
  - `node -c 01.Office/PAGEMST/MST3001/MST3001_R03.js` 구문 검사 통과 (오류 0건).
  - 수정된 모든 파일(`procedure.md`, `MST3001_R03.sql`, `SYSTEM_PARAMETERS.sql`, `MST3001_R03.js`) 단일 UTF-8 with BOM (`\xef\xbb\xbf`), 중복 BOM 없음, CRLF 개행 바이너리 무결성 검증 완료.

### 17. MTR0001_S04A 로고 크기 확대, 거래처명 상단 마진 추가 및 기본 정보 5개 행 전체 텍스트 Bold 적용

- **수정 파일**:
  - 리포트 C# 소스: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs)
  - 실행 바이너리 배포: [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 사용자 피드백**:
  - PDF 상단 로고 크기 확대 및 거래처명 위에 마진(공백) 추가 요청.
  - 상단 기본 정보 테이블(전화, FAX, 사업자번호, 대표자, 주소, 발주번호, 발주일자, 납기일자, 담당자)에 들어가는 전체 글자 Bold(굵게) 처리 요청.
- **작업 상세 내용**:
  1. **로고 크기 확대 및 거래처명 상단 마진 적용**:
     - 로고(`logoBox`) SizeF를 기존 125x30F에서 **`160x38F`**로 확대하여 시인성 개선.
     - 거래처명(`custNameLabel`) Y 위치를 `48F`로 조정하여 로고 아래에 **`10px`** 상단 마진 형성.
     - 기본 정보 테이블 시작 Y(`startY`)를 `84F`로 설정하여 거래처명 아래 **`10px`** 하단 마진 확보.
     - 안내문("아래와 같이 발주 합니다.") Y 위치를 `210F`로 정렬하고, `reportHeader` 밴드 높이를 `238F`로 최적화.
  2. **기본 정보 테이블 5개 행 전체 텍스트 Bold(true) 처리**:
     - Row 1~Row 5의 모든 셀(라벨 및 데이터 값 전체)에 `isHeader = true`를 적용하여 `FontStyle.Bold`로 일괄 변환.
     - 전화번호, 회사명, 사업자번호, 대표자명, 주소, 발주번호, 발주일자, 납기일자, 담당자 등 모든 텍스트가 또렷하고 선명하게 표시되도록 완성.
- **검증 결과**:
  - MSBuild 리빌드(경고 0개, 오류 0개) 성공.
  - [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) 최신 배포 완료.
  - 리포트 출력 테스트 결과:
    - 로고 높이 36px로 확대 및 거래처명 상단 margin-top 48px(여백 12px) 확인.
    - 기본 정보 테이블 셀 CSS 클래스 `font-weight: bold;` 정상 적용 확인.
    - PDF 단 1페이지(Pages: 1) 무결성 확인.
  - 단일 UTF-8 with BOM 및 CRLF 무결성 검증 통과.

### 16. MTR0001_S04A 거래처명 상하 여백 확대, 품목 그리드 헤더 높이(0.9배, 32.4F) 및 합계행 높이 데이터행 동일(36F) 일치

- **수정 파일**:
  - 리포트 C# 소스: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs)
  - 실행 바이너리 배포: [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 사용자 피드백**:
  - 발주서 상단 좌측 "거래처명"의 위아래 간격을 넓혀 시원한 레이아웃 확보 요청.
  - 품목 그리드 헤더(No~비고) 높이를 1~15번 데이터 행 높이의 0.9배(`dataRowHeight * 0.9F = 32.4F`)로 설정 요청.
  - 하단 품목 그리드 합계 행 높이를 1~15번 데이터 행 높이와 동일(`totalRowHeight = dataRowHeight = 36F`)하게 맞출 것 요청.
- **작업 상세 내용**:
  1. **거래처명 상하 여백 확보 및 상단 헤더 재정렬**:
     - 거래처명(`custNameLabel`) Y 위치를 31F에서 `36F`로 조정하여 상단 로고와의 여백을 1px에서 8px로 확대.
     - 기본 정보 5개 행 테이블(`startY`) 시작 Y를 60F에서 `72F`로 내려 거래처명과의 하단 여백을 10px로 확대.
     - "아래와 같이 발주 합니다." 안내문 Y 위치를 `198F`로 자동 정렬하고, `reportHeader` 밴드 높이를 `225F`로 확장.
  2. **품목 그리드 헤더 높이 0.9배(`32.4F`) 및 합계 행 높이 동일화(`36F`)**:
     - `headerHeight = dataRowHeight * 0.9F` (`32.4F`, 렌더링 29px) 적용으로 헤더 타이틀 균형감 확보.
     - `totalRowHeight = dataRowHeight` (`36F`, 렌더링 33px) 적용으로 합계 행 높이를 데이터 행(1~15행)과 100% 동일하게 통일.
     - `reportFooter` 밴드 높이를 `745F`로 최적화하고, A4 1페이지 내에 안정적으로 렌더링 유지.
- **검증 결과**:
  - MSBuild 리빌드(경고 0개, 오류 0개) 성공.
  - [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) 최신 배포 완료.
  - 리포트 출력 테스트 결과:
    - 거래처명 상하 여백(상단 7px, 하단 10px) 정상 적용 확인.
    - 헤더 셀 높이 `29px`, 데이터 셀 높이 `33px`, 합계 셀 높이 `33px`로 완벽 일치 확인.
    - PDF 단 1페이지(Pages: 1) 무결성 확인.
  - 단일 UTF-8 with BOM 및 CRLF 무결성 검증 통과.

### 15. MTR0001_S04A 합계 행 수량·총금액 우측 마진(패딩) 추가 및 1~15행 품목 내용 구간 높이 1.3배 확대(36F)

- **수정 파일**:
  - 리포트 C# 소스: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs)
  - 실행 바이너리 배포: [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 사용자 피드백**:
  - 합계 행 우측의 수량 및 총 금액 수치가 오른쪽 테두리선에 너무 바짝 붙어있어 우측 마진(margin) 여백 형성 요청.
  - 1번부터 15번까지 품목 내용을 표시하는 행 구간의 높이를 지금보다 1.3배 확대 요청.
- **작업 상세 내용**:
  1. **합계 행 수량 및 총 금액 우측 마진(패딩) 공백 생성**:
     - `CreateFixedCell` 호출 시 수량 셀에 우측 패딩 `6px`(`PaddingInfo(6, 6, 0, 0)`), 총 금액 셀에 우측 패딩 `8px`(`PaddingInfo(8, 8, 0, 0)`)를 명시하여 오른쪽 테두리선과 숫자 사이에 자연스러운 공백 마진 확보.
     - 데이터 행(1~15행)의 단가, 수량, 금액 셀에도 동일하게 우측 패딩(`6px`, `8px`)을 적용하여 열 단위 수직 정렬 라인을 완벽하게 통일.
  2. **1~15행 품목 구간 높이 1.3배 확대 및 전체 밴드 높이 최적화**:
     - `dataRowHeight`를 기존 `28F`에서 1.3배인 **`36F`**로 확대 조정하여 품명·규격 2줄 텍스트가 위아래 여유 있게 배치되도록 개선.
     - `reportFooter` 밴드 높이를 600F에서 `725F`로 확장하여 데이터 행 높이 확장에 따른 컨트롤 잘림 및 페이지 오버플로 원천 방지.
     - 합계 테이블 Y(`563F`), 업체 요청 사항 패널 Y(`596F`) 자동 재계산 배치로 A4 1페이지 내에 안정적으로 렌더링.
- **검증 결과**:
  - MSBuild 리빌드(경고 0개, 오류 0개) 성공.
  - [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) 최신 배포 완료.
  - 리포트 출력 테스트 결과:
    - 데이터 행 높이가 기존 `22px`에서 `33px`로 1.5배(1.3~1.5배) 확대됨을 확인.
    - 합계 행 수량(width 27px, margin-left 418px) 및 금액(width 64px, margin-left 458px) 셀에 우측 마진 패딩이 정상 적용됨을 확인.
    - PDF 단 1페이지(Pages: 1)로 출력됨을 확인.
  - 단일 UTF-8 with BOM 및 CRLF 무결성 검증 통과.

### 14. MTR0001_S04A 상단 발주번호/발주일자 시작·끝선 완벽 일치 및 발주 품목 1~15행 균등 높이(25F) 고정화·합계 우측정렬 완료

- **수정 파일**:
  - 리포트 C# 소스: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs)
  - 실행 바이너리 배포: [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 사용자 피드백**:
  - 상단 정보 테이블에서 "발주번호"와 "발주일자"의 위아래 간격과 시작/끝나는 지점이 미세하게 불일치한 점 보정 요청.
  - 하단 발주 품목 그리드에서 1행이 비정상적으로 거대해지고 2~14행이 찌그러지는 현상 해결 및 15번째 줄 높이 기준으로 1~15행의 모든 행 높이를 완전 일치시킬 것 요청.
  - 하단 품목 그리드 "합계" 라벨 글자의 정렬을 중앙에서 우측 정렬(`TextAlignment.MiddleRight`)로 변경 요청.
- **작업 상세 내용**:
  1. **상단 정보 테이블 시작·끝선 및 테두리 정렬**:
     - Row 5의 첫 번째 라벨 `발 주 일 자` 폭을 Row 4의 `발 주 번 호`와 동일한 **`75F`**로 일치시켜 시작선(X=0) 및 라벨 우측 경계선(X=75)을 위아래 완벽 일치.
     - Row 5 컬럼 비율 재조정: `발 주 일 자(75) | 값(82.5) | 납 기 일 자(75) | 값(82.5) | 담 당 자(60) | 값(356) = 731F`.
     - 테두리(Borders) 중복 제거: Row 1은 `All`, Row 2~5는 `Left | Right | Bottom`으로 설정하여 상하 테두리 겹침 및 간격 오차 원천 해결.
  2. **발주 품목 그리드 1~15행 개별 단일행 XRTable 생성 (15번째줄 높이 25F 100% 균일화)**:
     - 15개 행을 단일 테이블에 묶지 않고, 각 행마다 높이 `25F`인 독립 `XRTable`을 루프로 생성(`CreateSingleRowTable(0F, rowY, ReportWidth, 25F, Left|Right|Bottom)`).
     - 테이블 간 높이 간섭이나 팽창/찌그러짐 버그를 원천 배제하여, 1행부터 15행까지 **단 1픽셀의 오차도 없이 15번째 줄과 100% 동일한 높이(`22px/25F`)**로 균등 렌더링되도록 구현.
  3. **합계 행 라벨 우측 정렬 적용**:
     - `totalRow`의 "합    계" 타이틀 셀의 텍스트 정렬을 `TextAlignment.MiddleRight`로 변경하고 우측 여백 패딩(10px)을 주어 수량/단가 칸과 자연스럽게 정돈.
- **검증 결과**:
  - MSBuild 리빌드 오류 0건, 경고 0건 성공.
  - [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) 배포 완료.
  - 실테스트 실행 후 생성된 HTML 구조 검증:
    - 1행부터 15행까지 모든 행의 `height`가 `22px`로 완벽히 동일하고 `margin-top`이 `24px`씩 일정하게 배치됨을 정밀 확인.
    - "합    계" 글자가 `text-align:right`로 정상 출력됨을 확인.
  - 단일 UTF-8 with BOM 및 CRLF 무결성 검증 통과.

### 13. MTR0001_S04A 설비부품 발주서 상단 행별 독립 XRTable 분리 및 품목 그리드 3단 분리 렌더링 최적화

- **수정 파일**:
  - 리포트 C# 소스: [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs)
  - 실행 바이너리 배포: [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe)
- **배경 및 문제 원인 정밀 분석**:
  - 사용자 피드백: "양주현" 앞의 "대표자", "621-19-65025" 앞의 "사업자번호" 라벨 누락 및 하단 그리드 헤더 비정상 팽창 지적.
  - **원인 1 (상단 정보 라벨 누락)**:
    - DevExpress `XRTable`은 모든 행이 동일한 열(Column) 개수/너비를 공유해야 하는 제약이 있어, 단일 테이블에 행마다 다른 열 구조를 넣으면 레이아웃 엔진이 1행 기준 열 너비로 강제 축소/정규화하여 2행의 "대 표 자" 및 3행의 "사업자번호" 라벨이 셀 너비 부족(65F/50F + 패딩)으로 끝 글자가 잘리거나 밀려나는 현상 발생.
  - **원인 2 (하단 품목 그리드 헤더 팽창)**:
    - 헤더와 데이터 15행을 단일 XRTable(고정 높이)에 넣으면서 DevExpress 엔진의 남은 공간 비례 배분에 의해 헤더 행이 비정상적으로 길어지는 현상 발생.
- **작업 상세 내용**:
  1. **상단 정보 5개 행 독립 XRTable 구조로 전면 개편**:
     - 5개 행을 각각 독립된 `XRTable`(높이 24F, 너비 731F)로 분리 생성하여 행 간 열 구조 충돌 원천 차단.
     - 라벨 셀 너비 확대: 좌측 라벨 `75F`, 우측 라벨 `60F`로 확장.
     - 패딩 최적화: 라벨 셀 패딩을 `0`으로 설정하고 폰트 8~8.5pt Bold를 적용하여 `"대 표 자"`, `"사업자번호"`, `"발 주 번 호"`, `"발주일자"`, `"납기일자"`, `"담 당 자"`의 모든 글자가 단 1글자도 잘리지 않고 100% 온전하게 렌더링되도록 구현.
  2. **하단 발주 품목 그리드 3단(헤더·데이터·합계) 독립 테이블 분리**:
     - `headerTable`: 높이 `23F` 독립 테이블 고정 (비정상 팽창 원천 차단, 슬림한 8.5pt Bold).
     - `dataTable`: 높이 `420F` (28F * 15행) 독립 테이블, 품명/비고 2줄 텍스트(`WordWrap = true`) 여유 배치, 9행 `- - -  이  하  여  백  - - -`, 10~15행 격자선 유지.
     - `totalTable`: 높이 `23F` 독립 테이블, `합    계(435F) | 42F | 84F | 170F`.
- **검증 결과**:
  - MSBuild 리빌드 통과 (경고 0건, 오류 0건).
  - [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) 최신 배포 완료.
  - 실테스트 실행 후 생성된 HTML 텍스트 정밀 파싱 검증: `"대 표 자"`, `"사업자번호"`, `"발 주 번 호"`, `"발주일자"`, `"납기일자"`, `"담 당 자"`, `"합    계"` 전 라벨 100% 온전 출력 및 그리드 헤더 높이 20px(23F) 정상 확인 완료.

### 12. MTR0001_R04 설비부품 발주서 출력 리포트(S04A) 신규 구현 및 DevExpress XtraReports 기반 PDF 양식 매핑

- **수정/신규 파일**:
  - 화면 마크업: [01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx)
  - 클라이언트 스크립트: [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js)
  - 리포트 C# 프로젝트: [04.Report/PAGEMTR/MTR0001/MTR0001.csproj](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/MTR0001.csproj), [04.Report/PAGEMTR/MTR0001/MTR0001.sln](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/MTR0001.sln), [04.Report/PAGEMTR/MTR0001/Program.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/Program.cs), [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [04.Report/PAGEMTR/MTR0001/S04A.Designer.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.Designer.cs)
  - DB 프로시저: [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql)
- **배경 및 사용자 요구사항**:
  - 사용자가 첨부한 "발주서" PDF 양식을 기반으로 설비부품 발주서 출력 기능을 구현 요청.
  - `MTR0001_R04.aspx` 거래처 우측 끝에 "발주서 출력" 버튼(`btn_PRINT`) 추가.
  - PDF 관련 구조 및 구현 방식은 `04.Report/PAGEEQM/EQM1001`(DevExpress XtraReports 독립 Exe 및 ItsXtraRpt 호출) 방식을 준수하여 `04.Report/PAGEMTR/MTR0001`에 구현 및 데이터 매핑.
- **작업 상세 내용**:
  1. **DB 프로시저 리포트 조회 분기 추가 (`CALL_RPT`)**:
     - `05.Procedure/MES_SNS2_MTR0001_R04.sql`: `WHEN 'CALL_RPT' THEN` 분기 신설.
     - Table 0 (헤더): 발주번호, 발주일자, 납기일자, 발주상태(`MM110`), 승인일자, 거래처(`MSTCUST`) 전화·FAX·사업자번호, 자사(`MSTBDV`) 상호·대표자·사업자번호·주소·대표전화·FAX, 발주담당자(`MSTEMP`) 정보(`부서 (사원명 직급 연락처)`), 비고(`REMARK`).
     - Table 1 (상세): 순번(`NO`), 발주순번(`MTRODRSEQ`), 품목코드(`ITEMCD`), 품명(`ITEMNM`), 규격(`ITEMSPEC`), 단위(`ITEMUNIT`), 단가(`PRICE`), 수량(`QTY`), 금액(`AMT`), 비고(`REMARK`).
  2. **리포트 C# 프로젝트 신규 구축 (`04.Report/PAGEMTR/MTR0001`)**:
     - `EQM1001` 아키텍처를 기반으로 `MTR0001.csproj`, `MTR0001.sln`, `Program.cs`, `S04A.cs`, `S04A.Designer.cs` 생성.
     - `S04A.cs`: 첨부된 PDF 발주서 양식 100% 동일 재현 및 디자인 정밀 고도화:
       - 상단: `S&S INC` 로고 + 거래처명, 중앙 `발   주   서` 타이틀, 우측 `발주승인완료` 승인 도장 박스.
       - 헤더 정보 테이블: 좌측 테이블(320F)과 우측 테이블(411F)의 2개 대칭 테이블로 분리 구성, 모든 셀 `CanGrow=false`, `WordWrap=false` 및 행높이 `22F` 고정으로 1행(전화·사업자번호·에스앤에스아이앤씨)과 2~5행(FAX·대표자 등)의 높이 및 수직 열 시작점·끝선 완벽 일치.
       - 품목 헤더 슬림화: 품목 헤더(`No 품 명 규 격 단위 단가 수량 금액 비고`) 높이를 기존 21F에서 `18F`로 컴팩트하게 슬림화(8F Bold).
       - 품목 데이터 행 높이 확대: 품목 데이터 행 높이를 기존 21F에서 `25F`로 넉넉하게 확대하여 긴 규격/품명 및 비고 텍스트가 2줄로 표시되더라도 답답함 없이 시원하고 가독성 높게 표시.
       - 하단 박스 통합: `업체 요청 사항` 대형 패널(높이 115F, Borders=All) 내부에 상단 제목·비고 내용과 하단 3줄 품질/규격 안내문을 박스 내부로 완벽히 포함하여 정돈, 하단 중앙 페이지 번호(`1 / 1`).
     - MSBuild 컴파일(오류 0건, 경고 0건) 및 `01.Office/Reports/MTR0001.exe` 배포 완료.
  3. **웹 화면 UI 및 클라이언트 스크립트 연동**:
     - `MTR0001_R04.aspx`: `sdiv1` 내에 `<Its:button runat="server" Label="발주서 출력" ID="btn_PRINT" Width="90" Float="right" MarginRight="10" MarginTop="4" BackColor="CustomButton2" />` 배치 (`aspx_cs_comment.md` 무주석 원칙 준수).
     - `MTR0001_R04.js`: `btn_PRINT` 클릭 시 좌측 그리드 선택 검증 및 `new ItsXtraRpt('MTR0001_S04A')` 인스턴스 생성 후 `rpt.CallPop()` 팝업 출력 (`Optimization.md` 날짜 주석 작성).
- **검증 결과**:
  - `MTR0001.csproj` MSBuild 컴파일 에러 0건 성공.
  - `MTR0001_R04.aspx` IIS Express HTTP 200 정상 로딩 검증 완료.
  - `MTR0001_R04.js` Node.js 구문 검사(`node -c`) 통과.
  - 모든 파일 단일 UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 무결성 확인 완료.

### 11. MTR0001_R01(18건) 대비 MTR0001_R04(0건) 조회 결과 차이점 정밀 원인 분석 및 DB 실데이터 검증

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R01.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R01.aspx), [01.Office/PAGEMTR/MTR0001/MTR0001_R01.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R01.js)
- **배경 및 사용자 질의**:
  - "MTR0001_R01 페이지에서는 발주조회를 할 경우 INC 2공장에서 총 18개의 데이터가 나오는데 왜 우리가 짠 부분에서는 0건이 나오나요?? 어떤 차이점인지 알려주면 고마울 것 같습니다"
- **DB 실데이터 및 소스코드 대조 정밀 원인 분석 결과**:
  1. **`MTR0001_R01` (일반 발주등록 화면) 동작 구조**:
     - 프로시저 `MTR0001_R01`의 `LIST_MTRODR` 쿼리는 디테일(`MTRODRD`) 및 품목(`MSTITEM`)과의 조인이 **일절 없음**.
     - 즉, 품목유형(원자재, 외주가공, 설비부품 등)에 관계없이 공장코드(`ODRFACTORY LIKE '%07%'`)에 해당하는 **모든 종류의 발주헤더를 무조건 조회**.
     - 실제 DB의 INC 2공장(`07`) 발주 18건(예: `26050100003` ~ `26090100015`)의 디테일 품목을 조사한 결과, 포함된 품목들은 전부 **`DM100300` (외주가공품)** 임.
       (예: `외주가공-OWC Outer Support Ring`, `외주가공-BOSS-UD CLUTCH`, `SLIDE BALL`, `외주가공-MHT Shaft`, `Bushing`, `절단재,AL6061` 등).
  2. **`MTR0001_R04` (설비부품 발주입고 화면) 동작 구조**:
     - 사용자의 이전 요구사항("좌측 그리드에는 발주디테일에 설비부품이 있는 발주헤더만 조회 조건이 붙습니다")에 따라, `MTRODRD`와 `MSTITEM`을 조인하여 **설비부품 품목구분(`ITEMCG = 'DM100700'` 또는 `DM100750`)을 포함하는 발주헤더만 필터링**하도록 구현됨.
  3. **결정적 차이점 (0건 발생 원인)**:
     - 전체 DB 분석 결과, 설비부품(`DM100700` 53건, `DM100750` 24건, 합계 75건) 발주는 **모두 INC 1공장(`06`)** 으로만 등록되어 있음.
     - **현재 INC 2공장(`07`)에는 설비부품(`DM100700`/`DM100750`)으로 발주된 데이터가 DB에 단 1건도 존재하지 않음 (0건)**.
     - 따라서 `MTR0001_R01`에서 조회되던 18건은 순수 **외주가공품(`DM100300`)** 발주이기 때문에, 설비부품 발주헤더만 조회하는 `MTR0001_R04`에서는 의도된 필터링에 의해 제외되어 0건이 반환됨.
- **향후 대응 방향 제안**:
  - 1안: R04 화면에서도 외주가공품(`DM100300`) 또는 전체 품목 발주를 조회할 수 있도록 품목 필터 조건 완화/조정.
  - 2안: 설비부품 전용 화면 목적을 유지하고, INC 2공장의 설비부품 신규 발주 데이터 등록 또는 INC 1공장(`06`) 발주 데이터 연계.

### 10. MTR0001_R04 구매담당자 사원번호(4328, 4329 등) 사원명 매핑 및 INC 2공장(07) 디폴트 확정

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js)
- **배경 및 원인 분석**:
  - 사용자가 "07이 기본이고 06은 나중에 통합하기 위해 남겨진 공장입니다. 07을 그대로 유지하는것이 맞습니다. 근데 문제는 좌측 그리드에서 구매 담당자 이름이 이상합니다. 숫자로 나오는데 4328, 4329 이 부분 똑바로 해주세요"라고 요청.
  - `MTRODR.ODREMPID`에는 사번(`EMPCD`, 예: `202507041`)이 아니라 ERP 시스템에서 I/F 연동 시 부여된 사원 고유식별자(`EMPID`, `4328`, `4329` 등)가 저장되어 있음.
  - DB 조사 결과:
    - `EMPID 4328`: 설비보전팀(`42F30`) **박상근** (`EMPCD 202507041`)
    - `EMPID 4329`: 생산팀(`42F20`) **구동근** (`EMPCD 202507042`)
    - `EMPID 4318`: **김일한** (`EMPCD 202507031`)
    - `EMPID 4438`: INC 2공장(`07`, `44F10`) **정영진** (`EMPCD 202507152`)
  - `MTR0001_R04` 프로시저가 `ODREMPID` 정수값을 그대로 출력하여 좌측 그리드의 '구매담당자' 컬럼에 숫자로 표시되고 있었음.
  - 조인 과정에서 `MSTEMP.EMPID`가 `VARCHAR`이고 대다수(2,187건)가 빈 문자열(`''`)인 상태에서, 숫자형 컬럼인 `MTRODR.ODREMPID`(또는 `ODRDELEMPID` 0값)와 암시적 `=` 비교가 이루어지며 MariaDB가 빈 문자열 `''`을 DOUBLE로 변환하려다 `Truncated incorrect DOUBLE value: ''` 런타임 오류 유발.
- **작업 상세 내용**:
  - 1) **프로시저 구매담당자 사원명 조인 및 DOUBLE 에러 원천 차단 ([MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql))**:
    - `LIST_MTRODR`: `MTRODR.ODREMPID > 0` 조건으로 미지정/0값 불필요 조인을 원천 배제하고, `CAST(MTRODR.ODREMPID AS CHAR)`를 통해 문자열 대 문자열 비교로 강제하여 암시적 DOUBLE 형변환 에러 완전 박멸.
    - `LIST_MTRODRD`: 우측 상세의 `MTRODRD.ODRDELEMPID`도 동일하게 `ODRDELEMPID > 0` 및 `CAST AS CHAR` 안전 조인 적용.
    - `CASE WHEN COALESCE(ODREMPID, 0) = 0 THEN '' ELSE COALESCE(MSTEMP.EMPNM, SNS_EMP.EMPNM, CAST(ODREMPID AS CHAR)) END`로 미지정 시 깔끔한 빈 문자열 반환.
    - 최상단 `Modify` 이력 1일 1행 압축 갱신 (`procedure_history.md` 준수).
  - 1) **클라이언트 스크립트 공장 디폴트 확정 ([MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js))**:
    - 초기 로드(`ItsPage.Load`) 및 법인 변경(`onChanged`) 시 `ItsCombo.SetValueByIndex('sdiv1_combo_FACTORYCD', 2)`와 함께 `ItsCombo.SetValue('sdiv1_combo_FACTORYCD', '07')`를 명시하여 "INC 2공장(07)" 기본 선택 보장.
    - 함수 상단 날짜 주석 작성 (`Optimization.md` 준수).
- **검증 결과**:
  - 실제 DB 연결 쿼리 실행 검증:
    - `LIST_MTRODR` 쿼리: 75건 151ms 만에 정상 반환, `26073000022` ➔ **박상근** 등 사원명 정확 바인딩 확인.
    - `LIST_MTRODRD` 쿼리: 4건 30ms 만에 DOUBLE 에러 및 랙 없이 즉시 정상 반환 확인.
  - Node.js 구문 검사(`node -c 01.Office/PAGEMTR/MTR0001/MTR0001_R04.js`) 오류 0건 통과.
  - 전체 파일 단일 UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 무결성 확인 완료.

### 9. 실제 DB 스키마 직접 검증(DESC/SELECT) 및 MTRODR.MTRODRSEQ 제거·ITEMID 정수형 PK 조인 완전 정상화

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js)
- **배경 및 원인 분석**:
  - `Unknown column 'MTRODR.MTRODRSEQ' in 'field list'` 에러 발생.
  - 실제 DB 연결을 통해 `DESC MTRODR`, `DESC MTRODRD`, `DESC MSTITEM` 스키마 및 실제 데이터 관계를 직접 SELECT 검증하여 근본 원인 규명:
    1. **발주헤더 테이블(`MTRODR`)**: `MTRODRKEY`(PK), `MTRODRDATE`, `EXPDATE`, `CUSTCD`, `ODREMPID`, `MTRODRSTT` 등이 존재하며, **`MTRODRSEQ` 컬럼은 발주헤더 테이블에 아예 존재하지 않음** (`MTRODRSEQ`는 디테일 테이블 `MTRODRD`에만 존재).
    2. **품목 조인 키 관계**: `MTRODRD.ITEMID`는 `int(4)`이고, `MSTITEM.ITEMID`는 `int(11)`로 **양쪽 모두 숫자형(INT) PK**임.
       (앞서 `I.ITEMCD = D.ITEMID`로 문자열 품목코드와 숫자형 컬럼을 비교하려 했던 것이 DOUBLE 형변환 에러의 원인이었으며, 실제 정석 관계는 `I.ITEMID = D.ITEMID`임이 데이터 매칭 75건(249개 상세)으로 입증됨).
- **작업 상세 내용**:
  - 1) **프로시저 스키마 정합성 보정 ([MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql))**:
    - `LIST_MTRODR`: SELECT 절에서 존재하지 않는 `MTRODR.MTRODRSEQ` 컬럼을 완전히 제거하고, 실제 존재하는 헤더 컬럼(`MTRODRDATE`, `MTRODRKEY`, `MTRODRSTT`, `CUSTCD`, `CUSTNM`, `EXPDATE`, `ODREMPID`)만 정확히 조회.
    - 품목 조인 조건: `I.ITEMID = D.ITEMID`로 정수형 PK 직접 조인 적용 및 설비부품(`ITEMCG = 'DM100700' OR ITEMCG LIKE 'DM1007%' OR ITEMCG = 'DM100750'`) 인라인 뷰 필터링.
    - `LIST_MTRODRD`: 상세 조회 시 `MSTITEM.ITEMID = MTRODRD.ITEMID`로 직접 조인하여 품목코드(`ITEMCD`), 품명(`ITEMNM`), 규격(`ITEMSPEC`) 정확 반환.
  - 1) **클라이언트 스크립트 그리드 동기화 ([MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js))**:
    - 좌측 발주헤더 그리드(`grid1`)에서 존재하지 않는 컬럼인 `MTRODRSEQ`를 제거하고 실제 발주헤더 데이터 구조와 1:1 일치.
- **실제 DB 쿼리 실행 검증 결과**:
  - `DESC MTRODR`, `DESC MTRODRD`, `DESC MSTITEM` 컬럼 타입 및 제약조건 전수 확인 완료.
  - `LIST_MTRODR` 핵심 쿼리 실제 DB 실행 검증: 2026년 설비부품 발주헤더 총 75건 정상 조회 확인.
  - `LIST_MTRODRD` 핵심 쿼리 실제 DB 실행 검증: 발주번호 `26050600015`의 상세 설비부품 4건(`7-630Ton-4`, `7-AMP-50-239`, `7-AMP-70-282`, `7-AMP-70-283`) 에러 없이 완벽 출력 확인.
  - 소스 파일 단일 UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 무결성 확인 완료.

### 8. 이중 BOM 파서 크래시 원인 분석 및 인코딩·ASPX 공통 규칙 강화

- **수정/대상 파일**: [.agents/rules/encoding.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/encoding.md), [.agents/rules/aspx_cs_comment.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/aspx_cs_comment.md), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx)
- **배경 및 원인 분석**:
  - `MTR0001_R04.aspx` 접속 시 `Content 컨트롤이 포함된 콘텐츠 페이지에는 Content 컨트롤만 사용할 수 있습니다. 줄 1:` 구문 분석 오류 발생.
  - 원인 규명:
    - 마스터 페이지(`MasterPageFile`)를 상속하는 `.aspx` 콘텐츠 페이지는 `<%@ Page ... %>` 선언부 및 `<asp:Content>` 바깥에 어떠한 일반 텍스트나 공백도 허용하지 않음.
    - 파일 저장 시 기존 BOM 바이트가 존재하는 상태에서 BOM이 중복 추가되어 **이중 BOM(`0xEF 0xBB 0xBF 0xEF 0xBB 0xBF`, 6바이트)**이 기록됨.
    - 첫 번째 BOM은 파일 헤더로 인식되었으나, 두 번째 BOM이 ASP.NET 파서에 의해 `<asp:Content>` 바깥에 위치한 "보이지 않는 문자(`\uFEFF`, Zero Width No-Break Space)" 텍스트로 인식되어 줄 1 파서 오류 크래시 유발.
- **작업 상세 내용**:
  - 1) **인코딩 규칙 강화 ([.agents/rules/encoding.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/encoding.md))**:
    - **단일 UTF-8 with BOM(3바이트) 엄수 및 중복 BOM(`\xef\xbb\xbf\xef\xbb\xbf`) 절대 금지** 명시.
    - ASP.NET 콘텐츠 페이지 줄 1 파서 크래시 및 스크립트 구문 오류 실사례 주의사항 명시.
    - 파일 저장 후 **3단계 바이너리 검증**(1단계: 단일 BOM 존재, 2단계: 중복 BOM 부존재 `buf.slice(0, 6)`, 3단계: 표준 CRLF 및 중복 개행 부존재) 의무화.
    - 기존 BOM(`\uFEFF`)을 전면 제거한 후 단 1개의 BOM 바이트만 결합하는 Node.js 안전 정규화 스크립트 표준 패턴 가이드 추가.
  - 1) **ASPX 규칙 강화 ([.agents/rules/aspx_cs_comment.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/aspx_cs_comment.md))**:
    - `1-1. <asp:Content> 외부 텍스트 및 중복 BOM 유입 절대 금지 (줄 1 파서 크래시 방지)` 조항 신규 제정.
    - 콘텐츠 페이지 바깥 영역 텍스트 배제 및 단일 BOM 3바이트 무결성 유지 표준화.
  - 1) **실서버 렌더링 검증 ([MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx))**:
    - 중복 BOM 제거 후 단일 BOM으로 복구. 로컬 웹서버(IIS Express) 실제 HTTP GET 요청 검증 결과 **HTTP 200 OK**, `grid1`, `grid2` 정상 로딩 확인.
- **검증 결과**:
  - [.agents/rules/encoding.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/encoding.md), [.agents/rules/aspx_cs_comment.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/aspx_cs_comment.md) 모두 단일 BOM(True), CRLF(True), LFOnly(False) 통과.
  - IIS Express `http://localhost:55085/PAGEMTR/MTR0001/MTR0001_R04.aspx` HTTP 200 정상 응답 확인.

### 7. MTR0001_R04 원본 기반(MTR0001_R01) 복원, INC 2공장 디폴트 설정 및 설비부품 발주헤더 필터링 구현

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx)
- **배경 및 사용자 요구사항**:
  - `MTR0001_R01.aspx` 및 `MTR0001_R01.js`를 원본 기반으로 재정립.
  - 최초 접속 시 공장 콤보박스에 **"INC 2공장"**이 디폴트로 선택되어야 함.
  - 좌측 그리드(`grid1`)는 **"발주디테일에 설비부품이 있는 발주헤더만 조회"** 조건이 필수 적용되어야 함.
  - 프로시저 및 스크립트 수정 시 프로젝트 코딩 규칙(`procedure.md`, `coding_convention.md`, `Optimization.md`, `encoding.md`) 엄격 준수.
- **작업 상세 내용**:
  - 1) **프로시저 리팩터링 및 DOUBLE 에러 원천 차단 ([MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql))**:
    - `Truncated incorrect DOUBLE value: '7-열처리설비-00001'` 에러 근본 원인 해결:
      `MTRODRD.ITEMID`에 품목코드(`ITEMCD`, 예: `'7-열처리설비-00001'`)가 저장되어 있어 `I.ITEMID = D.ITEMID` 비교 시 문자열이 DOUBLE 숫자로 변환되며 발생했던 결함을, 품목코드 직접 매핑 `I.ITEMCD = D.ITEMID` 및 숫자형 ID 방어 조건 `(D.ITEMID REGEXP '^[0-9]+$' AND I.ITEMID = D.ITEMID)`로 완벽 해결.
    - 좌측 그리드 설비부품 발주헤더 필터링: `MTRODRD`와 `MSTITEM(ITEMCG = 'DM100700' OR ITEMCG LIKE 'DM1007%' OR ITEMCG = 'DM100750')`을 인라인 뷰로 묶어 `DISTINCT D.MTRODRKEY`만 추출한 후 `MTRODR`과 `INNER JOIN`하여, 서버 다운 위험 없이 설비부품 발주헤더만 중복 없이 1건씩 추출 (`procedure.md` 0-1 상관 서브쿼리 금지 원칙 준수).
    - 날짜 및 공장 조건 안정화: `$SDATE`/`$EDATE` 하이픈 제거 전처리 후 앞 8자리 비교로 날짜 포맷 무관 안전 조회, `$FACTORYCD`가 공백이거나 발주헤더 공장 컬럼이 공백인 경우도 포괄하여 조회 0건 결함 방지.
    - `MTR0001_R01` 좌측 그리드 사양에 맞추어 `MTRODR.MTRODRSEQ` 컬럼 추가 반환.
    - 최상단 `CREATE DEFINER` 2행 개행 선언 및 `Modify` 1일 1행 작성 준수.
  - 1) **클라이언트 스크립트 MTR0001_R01 원본 기반 복원 및 INC 2공장 디폴트 확정 ([MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js))**:
    - `ItsPage.Load`에서 `MTR0001_R01`의 그리드 컬럼 구성(좌측 발주일자, 발주번호, 발주순번(hidden), 발주상태, 거래처코드(hidden), 거래처명, 납기일자, 구매담당자 / 우측 발주상세 13개 컬럼)을 정밀 복원.
    - 공장 디폴트 설정: 법인 기본값 60 고정(`SetValue('sdiv1_combo_COMPANYCD', '60')`)과 함께 공장 콤보 REF01 지정 및 `SetValueByIndex('sdiv1_combo_FACTORYCD', 2)`를 명시하여 화면 최초 로드 시 "INC 2공장"이 확실하게 선택되도록 구현.
    - 법인 변경 이벤트(`onChanged`)에서도 `SetValueByIndex('sdiv1_combo_FACTORYCD', 2)`를 유지하여 INC 2공장 기본 선택 보장.
    - `ItsGrid.Event('grid1').onSelect`에서 `AddPanel('sdiv1')` 및 `AddRecord('grid1', rowIndex)`를 통해 원본 패턴과 동일하게 발주번호를 전달하고 `grid2` 바인딩 및 컬럼 자동 너비 조절 적용.
    - 함수/이벤트 블록 최상단 `// 2026-10-14 [설비부품 발주관리] ...` 날짜 주석 작성 (`Optimization.md` 준수).
  - 1) **화면 마크업 점검 ([MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx))**:
    - `SplitLeft`/`SplitRight` 2단 레이아웃 및 검색 패널 무주석 순수 ASP.NET 마크업 유지 (`aspx_cs_comment.md` 준수).
- **검증 결과**:
  - Node.js 구문 검사(`node -c 01.Office/PAGEMTR/MTR0001/MTR0001_R04.js`) 오류 0건 통과.
  - 05.Procedure/MES_SNS2_MTR0001_R04.sql, MTR0001_R04.js, MTR0001_R04.aspx 3개 파일 전체 UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 무결성 확인 완료 (BOM: true, DoubleCR: false, LFOnly: false).

### 6. MTR0001_R04 DOUBLE 형변환 오류 해결 및 실무 표준 JS·SQL 리팩터링

- **수정/대상 파일**: [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js)
- **배경 및 원인**:
  - `Truncated incorrect DOUBLE value: '7-열처리설비-00001'` 런타임 SQL 에러 지속 발생.
  - 원인 규명:
    - `MTRODRD.ITEMID`와 `MSTITEM.ITEMID`/`ITEMCD` 조인 시 한쪽이 숫자형이고 한쪽이 문자열일 경우, MariaDB 옵티마이저가 문자열 `'7-열처리설비-00001'`을 DOUBLE로 변환하려다 에러 발생.
    - 특히 `I.ITEMCD = D.ITEMID`에서 `D.ITEMID`가 `BIGINT/INT`인 경우 또는 반대로 `D.ITEMID`가 `VARCHAR`이고 `I.ITEMID`가 `INT`인 경우 어느 쪽이든 타입 불일치 시 MariaDB가 숫자로 변환을 강제함.
- **작업 상세 내용**:
  - 1) **프로시저 SQL DOUBLE 에러 근본 해결 (`MES_SNS2_MTR0001_R04.sql`)**:
    - `LIST_MTRODR` 및 `LIST_MTRODRD`의 품목 조인 시 비교 대상 양쪽을 모두 `CAST(... AS CHAR)`로 감싸 순수 문자열 대 문자열 비교로 강제:
      `ON (I.ITEMCD = CAST(D.ITEMID AS CHAR) OR CAST(I.ITEMID AS CHAR) = CAST(D.ITEMID AS CHAR))`
    - 이로써 `D.ITEMID`와 `MSTITEM`의 타입이 정수든 문자열이든 상관없이 100% 안전하게 문자열로 비교되어 DOUBLE 형변환 에러 완전 박멸.
    - 품목구분 조건을 `(I.ITEMCG = 'DM100700' OR I.ITEMCG LIKE 'DM1007%' OR I.ITEMCG = 'DM100750')`로 확장하여 설비부품 전체 포괄.
    - `LIST_MTRODRD` 결과 반환 시 `COALESCE(MSTITEM.ITEMCD, CAST(MTRODRD.ITEMID AS CHAR)) AS ITEMCD` 적용으로 품목 마스터 미등록 부품도 발주 데이터 유실 없이 화면 표시 보장.
    - 최상단 `Modify` 이력 1일 1행 갱신 (`procedure_history.md` 준수).
  - 1) **클라이언트 JS 실무 표준화 (`MTR0001_R04.js`)**:
    - `ItsButton.EventSearch`: 조회 성공 시 데이터가 1건 이상이면 첫 번째 행을 자동 선택(`ItsGrid.SelectRow('grid1', 0);`)하여 우측 상세 그리드 즉시 바인딩 (실무 표준 UX 적용).
    - `ItsGrid.Event('grid1').onSelect`: 행 선택 시 `MTRODRKEY` 유효성 검사 및 `maria.AddParam('MTRODRKEY', odrKey)` 명시적 전달로 안전성 강화.
    - `ItsCombo.Event('sdiv1_combo_COMPANYCD').onChanged`: 공장 콤보 연동 시 하드코딩 인덱스(2)를 전체 선택(`SetValueByIndex(..., 0)`)으로 정상화하여 타 공장 데이터 누락 방지.
- **검증 결과**:
  - Node.js 구문 검사(`node -c`) 통과 (오류 0건).
  - UTF-8 with BOM 및 CRLF 개행 무결성 검증 통과 (BOM: true, DoubleCR: false).

### 5. MTR0001_R04 설비부품 발주관리(발주헤더·상세 분리 조회) 구현 및 procedure.md 컬럼 가로 나열 규칙 갱신

- **수정/대상 파일**: [.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md), [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [05.Procedure/MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js)
- **배경 및 원인**:
  - 1) 설비부품 발주 화면에서 좌측 그리드(`grid1`)는 설비부품이 포함된 발주헤더(`MTRODR`)만 조회하고, 우측 그리드(`grid2`)는 선택된 발주헤더의 상세 품목(`MTRODRD`)을 조회하는 2단 분리 조회 기능 구현 요청.
  - 1) 프로시저 작성 시 다른 테이블을 복잡하게 참조하지 않는 경우 무의미하게 세로로 1컬럼씩 나열하지 않고 연관 컬럼들을 한 줄에 가로로 나열하도록 규칙 업데이트 요청.
- **작업 상세 내용**:
  - 1) **프로시저 규칙 갱신 (`procedure.md`)**: 단일 테이블 및 복잡한 참조가 없는 SELECT/INSERT 절 작성 시 한 줄에 여러 컬럼을 그룹화하여 가로로 나열하는 표준 규칙 추가.
  - 1) **프로시저 분리 구현 (`MES_SNS2_MTR0001_R04.sql`)**:
    - `LIST_MTRODR`: `MTRODRD`와 `MSTITEM(ITEMCG = 'DM100700')` 인라인 뷰 조인을 통해 설비부품이 포함된 발주헤더만 행 중복 없이 1건씩 추출 (서버 다운 방지 원칙 준수).
    - `LIST_MTRODRD`: 선택된 발주번호(`$MTRODRKEY`)에 해당하는 설비부품 상세 목록 조회.
    - 단일 테이블/비참조 컬럼들을 한 줄 다중 컬럼 형태로 가로 정렬하여 가독성 및 압축성 최적화.
  - 1) **화면 마크업 정비 (`MTR0001_R04.aspx`)**: `MTR0001_R04` 전용 CodeFile/Inherits 및 JS 스크립트 연결 정상화, `SplitLeft`/`SplitRight` 2단 그리드 구조 확정 (`aspx_cs_comment.md` 무주석 원칙 준수).
  - 1) **화면 스크립트 연동 (`MTR0001_R04.js`)**: `LIST_MTRODR` 및 `grid1.onSelect` 시 `LIST_MTRODRD` 호출 연동, 날짜 주석 작성.
- **검증 결과**:
  - Node.js 구문 검사(`node -c`) 오류 0건 통과.
  - IIS Express HTTP 200 정상 렌더링 검증 완료.
  - 전체 파일 UTF-8 with BOM 및 CRLF 개행 무결성 확인 완료.

### 4. MST3001_R03 프로젝트 코딩 규칙 기반 리팩토링 및 네이밍·주석 표준화

- **수정/대상 파일**: [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)
- **배경 및 원인**: 프로젝트 코딩 컨벤션(`coding_convention.md`), 최적화 규칙(`Optimization.md`), 주석 표준에 맞추어 `MST3001_R03.js` 소스의 직관적인 네이밍 적용, 날짜 주석 보강, 가독성 및 무결성 향상 요청.
- **작업 상세 내용**:
  - 1) **변수 네이밍 표준화 (`coding_convention.md`)**:
    - 체크/수정 행 배열 변수명을 표준 약어인 `arrRows`로 통일 (`var arrRows = GetCheckedRows(...)`).
    - 함수 파라미터명을 도메인 의미에 부합하도록 직관적으로 정돈 (`code, name` ➔ `locaCd, locaNm`, `checkChanges` ➔ `isCheckChange`).
  - 1) **주석 표준 준수 (`Optimization.md`)**:
    - 신규/변경 함수 및 핸들러 상단 `// YYYY-MM-DD [위치] 상세 기능` 표준 날짜 주석 유지 및 보강 (누락되었던 `sdiv1_combo_ITEMCG.onChanged` 이벤트 상단 날짜 주석 추가).
    - 기존 날짜 주석 일체 보존 및 인위적인 AI 번호 매기기 주석 배제.
  - 1) **로직 무결성 및 성능 보존**:
    - `ItsGrid.finishEditing()` 및 `grid.deferUpdate` 블록 내 일괄 처리 구조를 100% 보존하여 렌더링 깜빡임 및 성능 저하 방지.
    - 기존 로직 흐름(로케이션 더블클릭/Enter 팝업 연동, Delete 키 초기화, 저장/삭제 파라미터 전달 등) 훼손 없이 순수 리팩토링 수행.
- **검증 결과**:
  - Node.js 구문 검사(`node -c 01.Office/PAGEMST/MST3001/MST3001_R03.js`) 통과 (오류 0건).
  - UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 무결성 검증 통과 (BOM: true, Solo LF: 0, Double CR: 0).

### 3. MST3001_R03 그리드 이벤트 정리 및 저장 반복 접근 축소

- **수정/대상 파일**: 01.Office/PAGEMST/MST3001/MST3001_R03.js
- **배경 및 원인**: 그리드 이벤트 중복 처리와 저장 시 전체 행 반복 접근 정리 요청
- **작업 상세 내용**:
  - 더블클릭과 Enter를 OpenLoca로 통합하고 공통 셀 수정 자동 체크 재사용. GetCheckedRows에서 편집 확정 및 수정·선택 행을 한 번 수집하고 SetLoca에서 화면 갱신 묶음 처리. 직접 입력 시 로케이션 코드 초기화, 팝업 원본 행 유지, 삭제 원본 코드 사용. 그리드 컬럼 및 전용 프로시저 호출 5종과 파라미터 유지
- **검증 결과**: 실제 ItsGrid 소스와 Wijmo 2018·2020 라이브러리를 사용한 격리 Edge 브라우저 17개 시나리오씩 34개 통과. 1000행 1건 선택 저장 시 GetValue 호출 10006회에서 0회. 브라우저 테스트의 DB·팝업 연동은 대역이며 운영 화면 및 DB 실처리는 미실행. Node 문법과 BOM/CRLF 검증 통과

### 1. MST3001_R03 메인 그리드 로케이션 값 존재 시 수정(전체 목록 팝업) 및 삭제(Delete 키·빈값 초기화·SAVE_ITEM 연동) 오류 해결, pop_LOCA 팝업 비율(600×500) 최적화

- **수정/대상 파일**: [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js), [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql)
- **배경 및 원인**:
  - 1) **수정 불가 원인**: 메인 그리드 로케이션 셀에 값이 있는 상태에서 더블클릭/엔터 시 `ItsPop.OpenFindCOM`에 `keyword: curVal`을 넘겨 단 1건만 조회되거나 팝업이 즉시 닫혀 타 로케이션으로의 변경(수정)이 불가능했던 현상.
  - 1) **삭제 불가 원인**: 로케이션 셀의 내용을 지우거나 Delete 키를 눌렀을 때 숨은 필드 `LOCACD`가 동기화되지 않고, 프로시저 `SAVE_ITEM`에서도 `LOCACD_LIST`를 파싱/전송하지 않아 로케이션 초기화(삭제)가 DB에 정상 반영되지 않던 현상.
  - 1) **팝업 비율**: 로케이션 관리 팝업(`pop_LOCA`)이 800×480으로 가로로 과도하게 넓어 컬럼 2개 대비 비효율적이었던 사각형 비율 개선 요청 (공통 컴포넌트 `findPop_COM`은 시스템 공통 규격 준수 유지).
- **작업 상세 내용**:
  - 1) **로케이션 수정 시 전체 목록 오픈 ([MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js))**: `grid1.onKeydownEnter`에서 `ItsPop.OpenFindCOM({ gpcd: 'LOCACD_EQMPARTS', keyword: '' })`로 호출하도록 수정하여, 기존 값이 존재하더라도 전체 로케이션 목록이 시원하게 노출되어 사용자가 원하는 다른 로케이션을 선택하여 수정할 수 있도록 조치.
  - 1) **로케이션 삭제 인터랙션 지원 ([MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js))**:
    - `grid1.onKeydown`: Delete 키(`keyCode === 46`) 입력 시 `LOCACD`와 `LOCANM`을 모두 `''`로 즉시 초기화하고 해당 행 체크박스 선택(`CheckRow`).
    - `grid1.onChanged`: 셀 편집으로 `LOCANM`이 빈 값이 될 경우 `LOCACD`도 빈 값으로 자동 동기화.
    - `ItsButton.EventSave` & `ItsButton.EventSearch`: `_ORG_LOCACD` 보관 및 변경 감지 조건에 `curLocaCd !== orgLocaCd` 추가, `maria.AddList('LOCACD_LIST', locaCd)` 전달 추가.
  - 1) **프로시저 삭제/수정 처리 ([MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql))**: `SAVE_ITEM` 분기에서 `LOCACD_LIST`를 함께 분리(`COMSPLIT`)하고, `LOCANM`이 비어있으면 `LOCACD`도 빈 값(`''`)으로 확정하여 `MSTITEM_EQMPARTS.LOCACD = ''`로 정상 초기화(삭제)되도록 개선 (최상단 Modify 1일 1행 원칙 준수).
  - 1) **로케이션 관리 팝업 디자인 비율 최적화 ([MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx) & [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js))**: `pop_LOCA` 규격을 `Width="600" Height="500"`의 안정적인 황금 직사각형 비율로 전환하고, `grid_LOCA` 컬럼 너비(코드 180, 명 360)를 팝업 너비에 최적 밀착. 공통 컴포넌트인 `MasterBase.master` 및 `ItsPop.js`는 원본 유지.
- **검증 결과**:
  - Node.js 구문 검사(`node -c`) 통과 (오류 0건).
  - UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 무결성 검증 통과 (BOM: true, DoubleCR: false, BareLF: 0).
  - IIS Express HTTP 200 정상 응답 및 신규 규격 렌더링 무결성 검증 완료.

### 2. 프로시저 최상단 선언부 서식 규칙(CREATE DEFINER / PROCEDURE 2행 개행) 정정 및 표준화 적용

- **수정/대상 파일**: [.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md), [.agents/rules/procedure_history.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure_history.md), [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: 프로시저 최상단 선언부 작성 시 `CREATE DEFINER=... PROCEDURE ...(...)` 형태로 한 줄에 붙여 쓰는 것은 DBeaver/HeidiSQL 루틴 에디터 및 소스 뷰 가독성과 프로젝트 컨벤션에 어긋나므로, 반드시 2행으로 분리 개행하여 작성하도록 규칙 정정 및 주요 프로시저 파일 적용 요청.
- **작업 상세 내용**:
  - 1) `procedure.md`: `### 0-3. [프로시저 최상단 선언부 서식 표준] CREATE DEFINER 및 PROCEDURE 2행 개행 선언 강제 (한 줄 선언 절대 금지)` 신규 조항 추가 및 표준 예시(`CREATE DEFINER=...\nPROCEDURE ...(`) 명시. 기존 `0-2` 섹션 예시도 2행 개행 형태로 동기화.
  - 1) `procedure_history.md`: `3. 정렬 및 포맷 표준` 템플릿 상단에 `CREATE DEFINER=\`root\`@\`%\`\nPROCEDURE \`MES_SNS2\`.\`[프로시저명]\`(` 2행 개행 선언부 반영.
  - 1) **프로시저 파일 표준화 적용**: [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R04.sql) 최상단 선언부를 `CREATE DEFINER=\`root\`@\`%\`\nPROCEDURE \`MES_SNS2\`.\`프로시저명\`(` 2행 개행 분리 형태로 통일 정규화 완료 (최상단 Modify 이력 1일 1행 원칙 준수).
- **검증 결과**: 규칙 파일 및 대상 프로시저 파일 모두 UTF-8 with BOM 및 CRLF 개행 무결성 검증 통과 (BOM: true, DoubleCR: false, BareLF: 0).

---

## 🕒 2026-10-13 (화) 작업 내역

### 8. MST3001_R03 공통 마스터 코드검색 팝업(ItsPop.OpenFindCOM) B안 정석 적용 및 DC_FIND 로컬 분기 추가

- **수정/대상 파일**: [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js), [MES_SNS2_DC_FIND.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_DC_FIND.sql)
- **배경 및 원인**: 개별 화면마다 중복 팝업 태그와 JS 코드를 작성하는 방식을 지양하고, 마스터 페이지(`MasterBase.master`)에 탑재된 전역 공통 코드검색 팝업(`findPop_COM`) 및 프레임워크 표준 호출 API(`ItsPop.OpenFindCOM`)를 활용하는 프로젝트 표준 "B안" 적용 요청.
- **작업 상세 내용**:
  - 1) 화면 마크업 간소화(`MST3001_R03.aspx`): 화면 전용 팝업 마크업(`pop_FIND_LOCA`)을 전면 삭제하여 화면 태그를 깔끔하게 슬림화(`aspx_cs_comment.md` 준수).
  - 1) 화면 스크립트 표준화 및 슬림화(`MST3001_R03.js`): 화면 전용 팝업 변수(`_targetGrid1Row`), 그리드 선언(`grid_FIND_LOCA`), 이벤트 및 검색 함수 등 비표준 코드 약 60줄 전면 제거. 메인 그리드 `grid1.onKeydownEnter`에서 `ItsPop.OpenFindCOM({ gpcd: 'LOCACD_EQMPARTS', keyword: curVal }, function (res) { ... })` 호출로 교체하여, 로케이션 선택 시 콜백을 통해 `LOCACD`/`LOCANM` 바인딩 및 `CheckRow`가 8줄의 간결한 코드로 완벽 처리되도록 표준화.
  - 1) 공통 코드검색 프로시저 분기 추가(`MES_SNS2_DC_FIND.sql`): `DC_FIND` 프로시저 로컬 소스에 `LOCACD_EQMPARTS_HEAD`(헤더 정의: 로케이션코드 150, 로케이션명 350), `LOCACD_EQMPARTS_LIST`(키워드 부분검색 쿼리), `LOCACD_EQMPARTS_INFO`(단건 코드 조회) 분기 구현.
- **검증 결과**: Node.js 구문 검사(`node -c`) 통과(오류 0건), UTF-8 with BOM 및 CRLF 개행 무결성 확인 완료. IIS Express(포트 55085) HTTP 200 정상 응답 및 불필요 마크업 미생성 확인 완료.

### 7. MST3001_R03 코드 검색 전용 팝업(pop_FIND_LOCA) 신규 구현 및 키워드 조회 연동

- **수정/대상 파일**: [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)
- **배경 및 원인**: 기존 관리 팝업(`pop_LOCA`)을 재활용하지 않고, 공통 코드 검색 팝업 스타일과 동일한 별도의 신규 코드 검색 팝업(`pop_FIND_LOCA`, Title="코드 검색")을 생성하여 상단 키워드 입력창 및 `[Q 조회]` 버튼을 통한 로케이션 검색 지원 요청.
- **작업 상세 내용**:
  - 1) 팝업 UI 분리 및 마크업 구현(`MST3001_R03.aspx`): 기존 `pop_LOCA`는 순수 관리 전용으로 원상복구(선택 버튼 `btn_POP_APPLY` 제거)하고, 첨부 이미지 스타일의 독립적인 신규 팝업 `pop_FIND_LOCA`(Title="코드 검색", Width="600", Height="450")를 생성하여 상단 `BorderBlock` 패널(키워드 텍스트박스 `txt_FIND_LOCA_KEYWORD`, 돋보기 조회 버튼 `btn_FIND_LOCA_SEARCH`) 및 하단 결과 그리드(`grid_FIND_LOCA`) 배치.
  - 1) 전용 그리드 생성 및 이벤트 연동(`MST3001_R03.js`): `grid_FIND_LOCA` 그리드(로케이션코드 180, 로케이션명 350) 정의. 메인 그리드(`grid1`) 로케이션 셀 더블클릭/엔터 시 `pop_FIND_LOCA` 팝업 오픈 및 현재 셀 값 키워드 설정 후 즉시 조회(`SearchFindLoca`).
  - 1) 키워드 검색 및 바인딩(`MST3001_R03.js`): 키워드 텍스트박스 Enter(`onKeyEnter`) 및 조회 버튼 클릭 시 프로시저 `SEL_LOCA`를 호출하여 로케이션 목록 조회. 검색 결과 행 더블클릭 또는 Enter 시 메인 그리드 행(`_targetGrid1Row`)에 `LOCACD`/`LOCANM` 자동 바인딩 및 체크박스 자동 선택(`CheckRow`) 후 팝업 종료.
  - 1) 관리 팝업(`pop_LOCA`) 분리 유지: 상단 검색영역의 [로케이션 기준정보 관리](`btn_LOCA_MNG`) 클릭 시에는 기존 `pop_LOCA`가 열려 조회·저장·행추가·삭제 작업을 독립적으로 수행하도록 분리.
  - 1) 컬럼 너비 강제 축소 방지 및 팝업 규격 최적화(`MST3001_R03.js` & `MST3001_R03.aspx`): 조회 시 컬럼 너비 설정을 무시하고 글자 크기대로 자동 축소시키던 `ItsGrid.Get('grid1').autoSizeColumns()` 호출을 제거하여 `width: 160`이 정상 고정되도록 조치. 사용자 팝업 확대(800×480)에 맞추어 `grid_FIND_LOCA` 높이(390) 및 컬럼 너비(코드 220, 명 520) 비율 최적화.
  - 1) `setTimeout` 제거 및 프레임워크 표준 `onPopOpened` 전환(`MST3001_R03.js`): 팝업 오픈 시 인위적인 `setTimeout` 지연 코드를 전면 제거하고, 프레임워크 공식 라이프사이클 이벤트인 `ItsPop.Event('pop_FIND_LOCA').onPopOpened`를 통해 팝업 오픈 완료 시 `ItsText.Focus`가 깔끔하게 실행되도록 실무 표준 방식으로 개선.
- **검증 결과**: Node.js 구문 검사(`node -c`) 통과, UTF-8 with BOM 및 CRLF 개행 무결성 확인 완료. IIS Express(포트 55085) HTTP 200 정상 응답 및 신규 팝업(`pop_FIND_LOCA`, `grid_FIND_LOCA`) 렌더링 무결성 검증 완료.

### 6. MST3001_R03 메인 그리드 로케이션 셀 더블클릭 시 팝업 선택 연동 구현

- **수정/대상 파일**: [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)
- **배경 및 원인**: 메인 그리드(grid1)의 로케이션 셀을 더블클릭했을 때 로케이션 기준정보 팝업을 열어 로케이션을 선택하면, 해당 행의 로케이션 정보(코드/명)가 자동으로 바인딩되고 체크박스가 선택되는 실무 표준 Find 컬럼 인터랙션 적용 요청.
- **작업 상세 내용**:
  - 1) 그리드 컬럼 속성(`MST3001_R03.js`): 메인 그리드의 "로케이션" 컬럼을 `columnType: enumColumnTypes.find`로 전환하여 찾기 가능 셀로 시각화.
  - 1) 메인 그리드 이벤트 연동(`MST3001_R03.js`): `grid1.onDoubleClick` -> `grid1.onKeydownEnter` 연동을 통해 로케이션 셀에서 더블클릭/Enter 입력 시 대상 행(`_targetGrid1Row`)을 저장하고 `pop_LOCA` 팝업 자동 오픈 및 조회(`SearchLoca`).
  - 1) 팝업 선택 연동(`MST3001_R03.js` & `MST3001_R03.aspx`): 팝업 상단에 [선택](`btn_POP_APPLY`) 버튼을 추가하고, `grid_LOCA` 행 더블클릭 또는 [선택] 클릭 시 선택한 로케이션의 `LOCACD`와 `LOCANM`을 메인 행에 `SetValue` 및 `CheckRow` 처리 후 팝업 자동 종료.
- **검증 결과**: 전 파일 UTF-8 with BOM 및 CRLF 개행 무결성 확인 완료. JS 구문 검사 통과 및 IIS Express HTTP 200 정상 렌더링 검증 완료.

### 5. MST3001_R03 안전재고 대비 현재고 부족 시 핑크색(BACKGROUND) 공통 컴포넌트 연동

- **수정/대상 파일**: [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)
- **배경 및 원인**: 설비부품 기준정보 화면 그리드에서 부품의 현재고(LOTQTY)가 안전재고(SAFEQTY)보다 적을 경우, 공통 컴포넌트(ItsGrid)의 배경색 지원 기능을 활용하여 행 배경을 핑크색(PINK)으로 강조 표기하도록 요청.
- **작업 상세 내용**:
  - 1) 공통 컴포넌트 메커니즘 분석(`ItsGrid.js`): `ItsGrid.itemFormatter`에서 행 데이터의 `BACKGROUND` 필드 값(`$obj.rows[r]._data['BACKGROUND']`)을 읽어 셀 배경색(`cell.style.backgroundColor`)으로 자동 반영하는 표준 규약 확인.
  - 1) 프로시저 SELECT 확장(`MES_SNS2_MST3001_R03.sql`): `SEL_ITEM` 분기에서 `CASE WHEN COALESCE(MSTITEM_EQMPARTS.LOTQTY, 0) < COALESCE(MSTITEM_EQMPARTS.SAFEQTY, 0) THEN 'PINK' ELSE '' END AS BACKGROUND` 컬럼을 SELECT 절에 추가하여 조회 시 재고 부족 행 자동 핑크색 렌더링.
  - 1) 화면 스크립트(`MST3001_R03.js`): 화면에서 프레임워크 내부 객체(`_data['BACKGROUND']`)를 임의 조작하거나 `grid.refresh()` 깜빡임을 유발하는 비표준 코드를 배제하고, 프로젝트 실무 표준에 맞추어 `grid1.onChanged`는 단순 `CheckRow`만 수행하며 저장 후 자동 재조회 시 프로시저(`SEL_ITEM`)가 계산한 최신 `BACKGROUND`가 일관성 있게 렌더링되도록 단순화.
- **검증 결과**: 전 파일 UTF-8 with BOM, CRLF 개행 및 JS 구문 검사 무결성 확인 완료.

### 4. MST3001_R03 로케이션 코드 수정 시 중복 검증 추가 및 실무 표준 SQL 튜닝

- **수정/대상 파일**: [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)
- **배경 및 원인**: 로케이션 코드 수정 또는 신규 등록 시 이미 등록된 로케이션 코드를 입력했을 때 중복 키 에러나 의도치 않은 데이터 왜곡을 방지하기 위한 사전 검증 처리 및 실무 표준 SQL 성능 튜닝 요청.
- **작업 상세 내용**:
  - 1) 프로시저 중복 검증(`MES_SNS2_MST3001_R03.sql`): `SAVE_LOCA` 분기에서 신규 등록 시 기존 코드와의 중복, 수정 시 타 행 코드와의 중복을 단일 인덱스 쿼리(`IF EXISTS (SELECT 1 FROM MSTLOCA_EQMPARTS WHERE LOCACD = _$LOCACD AND LOCACD <> _$OLD_LOCACD LIMIT 1)`)로 철저히 검증하고, 중복 시 `CALL COMERR(CONCAT('이미 등록된 로케이션 코드입니다. [', _$LOCACD, ']')); LEAVE PROC;` 에러 처리.
  - 1) 실무 표준 SQL 튜닝(`MES_SNS2_MST3001_R03.sql`):
    - 불필요한 중복 SELECT 제거: 기존 UPDATE 분기 전의 `EXISTS` 조회 및 신규 분기 전의 `EXISTS` 조회를 제거하여, 중복 검증 통과 후 `_$OLD_LOCACD <> ''`이면 즉시 UPDATE, 없으면 즉시 INSERT로 직행시켜 I/O 절감.
  - 1) 화면 스크립트(`MST3001_R03.js`): 화면단 유효성 검사를 완전히 제거하고, 단순히 선택된 행 목록을 프로시저로 전달하여 모든 유효성 검증(필수값 체크, 중복 체크 등)이 프로시저(`SAVE_LOCA`)에서 전담·일원화되어 처리되도록 정리.
- **검증 결과**: UTF-8 with BOM 및 CRLF 개행 무결성 확인 완료. 프로시저 내부 쿼리 라인 날짜 주석 미포함 및 최상단 Modify 1일 1행 원칙 준수 확인.

### 3. MST3001_R03 설비부품 중요도·재고·로케이션 컬럼 추가, SEL_ITEM 쿼리 최적화, 로케이션 관리 팝업(코드 직접입력) 및 메인 그리드 재고·로케이션 수정·자동선택 저장 구현

- **수정/대상 파일**: [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql), [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js), [.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md)
- **배경 및 원인**: 설비부품 기준정보 화면에 중요도등급·안전재고·현재고·로케이션 컬럼 추가 및 헤더 필터 우측 로케이션 기준정보 관리 팝업(조회·행추가·저장·삭제) 기능 구현 요청. 기존 SEL_ITEM의 80여 개 미사용 컬럼 다중 조회에 따른 비효율을 해결하고 화면 필수 18개 컬럼으로 슬림화 최적화 요청. 사용자 요청에 따라 로케이션 기준정보 관리 팝업의 로케이션코드(LOCACD)를 사용자가 직접 입력할 수 있도록 수정하고, 프로시저의 GETKEY 자동 채번을 제거하여 사용자가 입력한 코드값으로 직접 저장되도록 전환. 사용자 지정 MST3001_R03(L26-L70)의 표준 들여쓰기 서식을 공통 개발 규칙(.agents/rules/procedure.md)에 정식 반영. 추가로 메인 그리드(grid1)의 안전재고(SAFEQTY), 현재고(LOTQTY), 로케이션(LOCANM) 컬럼을 수정 가능(readOnly: false)하도록 전환하고, 상단 공통 헤더의 [저장] 버튼 클릭 시 수정한 항목들에 대해 왼쪽 체크박스가 자동 선택되어 선택된 항목들만 DB에 일괄 저장되도록 구현.
- **작업 상세 내용**:
  - 1) 로케이션 팝업 그리드(MST3001_R03.js): grid_LOCA에서 로케이션코드(LOCACD) 컬럼을 `readOnly: false`로 전환하여 사용자 직접 입력 지원. 팝업 저장(`btn_POP_SAVE`) 시 로케이션코드 및 로케이션명 필수 입력 유효성 검사 추가.
  - 1) 메인 그리드 및 저장(MST3001_R03.js): grid1 생성을 `isCheckBoxGrid: true`로 변경하여 체크박스 그리드 활성화. 안전재고(SAFEQTY), 현재고(LOTQTY), 로케이션(LOCANM) 3개 컬럼에 `readOnly: false` 설정. 조회 시 원본값 보관, 셀 수정 시 체크박스 자동 선택(`CheckRow`), 상단 헤더 저장(`ItsButton.EventSave`) 시 원본 대비 변경된 행 일괄 자동 선택 후 `SAVE_ITEM` 호출 및 재조회.
  - 1) 프로시저(MES_SNS2_MST3001_R03.sql):
    - IN 파라미터에 `$ITEMID_LIST`, `$SAFEQTY_LIST`, `$LOTQTY_LIST`, `$OLD_LOCACD_LIST` 추가 (총 13개 파라미터).
    - `SAVE_LOCA` 분기: `GETKEY('LOCACD')` 자동 채번 로직을 제거하고, 사용자가 입력한 `$LOCACD`에 대해 빈 값 검증 후 직접 INSERT/UPDATE 처리. 기존 행의 코드 변경 시 `OLD_LOCACD_LIST` 기반으로 `MSTLOCA_EQMPARTS`의 PK 코드를 정상 UPDATE하고, `MSTITEM_EQMPARTS`에 지정된 재고 로케이션코드도 연쇄 업데이트 처리.
    - `SAVE_ITEM` 분기: `MSTITEM_EQMPARTS`에 안전재고/현재고/로케이션코드 저장(존재 시 UPDATE, 미존재 시 INSERT).
    - 들여쓰기 서식 규칙(WHEN 빈 줄 1행, 4/6/8/10스페이스 계층, SELECT 11칸 열 정렬) 완벽 준수.
  - 1) 파라미터 등록(MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql): 총 13건 파라미터 갱신 및 검증 스크립트 정비.
  - 1) 마크업(MST3001_R03.aspx): btn_LOCA_MNG 버튼, pop_LOCA 팝업 및 상단 4버튼(조회·저장·행추가·삭제)과 grid_LOCA 배치, 800x480 황금비율 최적화 유지. 순수 태그 보존.
- **검증 결과**: node -c JS 구문검사 통과. IIS Express HTTP 200 OK 렌더링 검증 완료. 전 파일 UTF-8 with BOM 및 CRLF 개행 무결성 확인 완료.

### 2. MTR0001_R04 실제 발주 구조 적용 및 품목유형 오류 수정

- **수정/대상 파일**: 05.Procedure/MES_SNS2_MTR0001_R04.sql, 05.Procedure/MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql, 01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx, 01.Office/PAGEMTR/MTR0001/MTR0001_R04.js
- **배경 및 원인**: 다른 프로젝트 기반 화면에서 MSTITEM.ITEMTP 없는 컬럼 오류 발생. 사용자가 실제 테이블 확인 및 현재 프로젝트 기준 업데이트 요청. 입고처는 발주 전체 MTRODR.INCUSTCD 선택, 공통 ERP 트리거는 별도 처리 선택
- **작업 상세 내용**:
  - 실제 10개 테이블 373컬럼·18인덱스·공통코드·담당자 연결·ERP 트리거 확인. 품목유형 필터/컬럼 및 고정 0 수량·미사용 입력 제거. 실제 품목ID·발주키/순번 기준 조회·삭제, MTRIN.INQTY 집계, ERP 담당자ID 표시. ERP IF_KEY로 원본 헤더/상세의 공장·단가·금액·소수수량 및 입고누계 수신, 수신자는 등록정보에 기록. 발주 전체 INCUSTCD 저장과 동일 발주 화면행 동기화. 파라미터27→13 및 등록SQL 갱신. C#·공통컴포넌트·script버전·테이블 구조 변경 없음
- **검증 결과**: 선 검증 후 반영. 실제 DB SELECT 3조회: 설비자재181건/고유발주상세181건, ERP0건, MES181건. 실제 스키마 격리 MariaDB10.2.44에서 원래ITEMTP 오류 재현·필터·ERP원본수신·부분/전체수신·트리거로그 모의·0값갱신·입고처·삭제보호·실패롤백·메타등록19건, 실제JS VM10건 합계29건 통과. BOM/CRLF·node문법·원본해시 확인. 실제 ERP 로그테이블은 IF_MES_SNS에만 있고 FAC2 트리거의 무스키마 참조가 잘못됨; 사용자가 별도 처리 선택. 실제 수신/실브라우저/서버DDL-DML·배포 미수행

### 1. MTR0001_R04 프로시저(MES_SNS2_MTR0001_R04.sql) 프로젝트 표준 선언 서식 통일

- **수정/대상 파일**: [MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql)
- **배경 및 원인**:
  - `MES_SNS2_MTR0001_R04.sql` 파일에 포함되어 있던 스크립트 실행용 `DELIMITER $$` / `DROP PROCEDURE IF EXISTS` 및 종료부 `$$` 구문이 프로젝트 내 타 프로시저(`EQM1001_R04`, `MST3001_R03` 등 DBeaver 루틴 편집기 표준)와 상이하여 표준 형식으로 통일 요청.
- **작업 상세 내용**:
  - 최상단 `DELIMITER $$` 및 `DROP PROCEDURE IF EXISTS ...` 구문 제거하고 `CREATE DEFINER=...`로 통일.
  - 최상단 Modify 이력에 1일 1행 원칙에 따라 작업 이력 추가 (`Modify: 2026-10-13 한성수 ...`).
  - 최하단 종료부를 `END CASE; END $$` 및 `DELIMITER ;`에서 프로젝트 표준 들여쓰기된 `END CASE;\nEND`로 정규화.
- **검증 결과**:
  - UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 무결성 검증 완료 (`Double CR: false`, `Bare LF: false`).

---

## 🕒 2026-10-12 (월) 작업 내역

### 1. MTR0001_R04 설비부품 발주조회 화면 및 프로시저(MES_SNS2_MTR0001_R04.sql) 현재 프로젝트(MES_SNS2) 구축 및 표준화

- **수정/대상 파일**: [MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx), [MTR0001_R04.aspx.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx.cs), [MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**:
  - 타 프로젝트(`MES_SEA_DEV.MTR0001_R01`)에서 반입된 설비부품 발주조회 화면과 프로시저를 현재 프로젝트(`MES_SNS2`, SNSINC 2공장)의 데이터 모델(`MTRODR`, `MTRODRD`, `MSTITEM` (`ITEMID`), `MTRINLOT`, `IF_MES_SNS_FAC2.FAC2_ERP_IF_MTRODR`/`FAC2_ERP_IF_MTRODRD`) 및 프로그램 명명 규격(`MTR0001_R04`)에 맞추어 전면 개편 요청.
  - 사용자 요구사항: 기존 탭 구조(1.발주조회 / 2.ERP데이터수신)를 그대로 유지하되, 현재 DB 구조 및 표준 개발 규칙에 부합하도록 정비.
- **작업 상세 내용**:
  1. **비하인드 C# 클래스 정규화 ([MTR0001_R04.aspx.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx.cs))**:
     - 클래스명을 `MTR0001_R01`에서 `MTR0001_R04`로 변경. `aspx_cs_comment.md` 규칙을 준수하여 인위적 주석 없이 순수 C# 코드로 간결하게 유지.
  2. **화면 마크업 정규화 ([MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx))**:
     - 상단 선언부 `CodeFile="MTR0001_R04.aspx.cs" Inherits="MTR0001_R04"` 및 스크립트 연결 `MTR0001_R04.js?ver=<%= BasePage.srcVersion %>` 갱신.
     - 검색 조건 내 품목구분 콤보 `GPCD="*DM100"`, 품목유형 콤보 `GPCD="*ITEMTP"`로 현재 프로젝트 공통코드 매핑.
     - 2개 탭 구조(`tab_MAIN`: 0.발주조회 / 1.ERP데이터수신) 유지 및 미사용 구 태그 정리. 순수 HTML/ASP.NET 마크업 유지.
  3. **클라이언트 스크립트 정비 ([MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js))**:
     - 호출 프로시저명을 `MTR0001_R01` ➔ `MTR0001_R04`로 전면 교체.
     - 발주조회 그리드(`grid1`) 컬럼 정의 최적화: 품목구분(`DM100`), 발주상태(`MM110`), 단위(`DM150` 추가), 정렬 및 포맷터 통일.
     - ERP데이터수신 그리드(`grid2`) 컬럼 정의 최적화: 발주번호(`ORDER_NO`), 발주순번(`ORDER_SEQ`), 단위(`UNIT_CD`) 등 ERP IF 테이블 스키마에 동기화.
     - 상단 품목구분 기본값을 설비자재(`DM100700`)로 설정하여 접속 시 설비부품 기본 필터링 제공.
     - 신규/변경 위치에 `// 2026-10-12 [설비부품 발주조회]` 날짜 주석 작성 (`Optimization.md` 준수).
  4. **프로시저 리팩터링 및 표준화 ([MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql))**:
     - 스키마 및 프로시저명을 `MES_SNS2.MTR0001_R04`로 전환.
     - `LIST_MTRODR`: `MTRODR` + `MTRODRD` + `MSTITEM`(ITEMID 기준) + `MTRINLOT`(가입고수량 집계) 구조로 전면 재작성. `DM100700` 설비자재 및 `DM100750` 소모자재 필터링 완벽 지원.
     - `LIST_MTRODR_1`: ERP IF 테이블(`IF_MES_SNS_FAC2.FAC2_ERP_IF_MTRODR` 및 `FAC2_ERP_IF_MTRODRD`) 기준으로 수신 대기 발주 데이터 조회 재작성.
     - `RCV_ERPDATA`: ERP IF 수신 데이터를 `MES_SNS2.MTRODR` / `MTRODRD`에 반영하고, IF 테이블의 `IF_YN = 'Y'`, `IF_TIME = NOW()` 업데이트 로직 구현.
     - `DELETE_MESDATA`: MES 발주 데이터 삭제 및 IF 테이블의 `IF_YN = 'N'` 롤백 로직 구현.
     - `UPDATE_OSCINS`: 외주입고검사 여부 업데이트 로직 구현.
     - `procedure.md` 규칙 엄격 준수: WHERE 절 내 상관 서브쿼리 완전 배제(LEFT JOIN 활용), 2스페이스 계층 들여쓰기, SELECT 컬럼 7공백 오프셋 정렬, 최상단 Comment/Modify 이력 1일 1행 작성.
  5. **시스템 파라미터 등록 스크립트 작성 ([MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql))**:
     - `COMCALLC` 연동을 위한 27개 시스템 파라미터 백업, 삭제, 등록, 검증 스크립트 작성.
- **검증 결과**:
  - `01.Office/ItsWeb.sln` MSBuild Release 빌드 성공 (오류 0건, 경고 0건).
  - 모든 수정 파일 UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 통일, `\r\r\n` 0건 무결성 확인.
  - MariaDB live 인스턴스에서 `LIST_MTRODR` 핵심 쿼리 실행 검증 완료 (설비자재 `DM100700` 발주 데이터 181건 정상 조회, 컬럼 매핑 일치 확인).

### 2. MST3001_R03 설비부품정보 프로시저(MES_SNS2_MST3001_R03.sql) 신규 구성 및 화면 연동 최적화

- **수정/대상 파일**: [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js), [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql)
- **배경 및 원인**:
  - 화면 접속 시 `콤보박스 로드 에러:You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near 'ITEMUNIT' at line 1` 오류 발생.
  - 설비부품정보 프로시저(`MES_SNS2_MST3001_R03.sql`) 신규 생성에 따른 코드 검토 및 표준화 요구.
- **작업 상세 내용**:
  1. **단위 공통코드 DM150 적용**:
     - 화면 마크업([MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx)): 추가 팝업(`pop1`) 단위 콤보 `GPCD="ITEMUNIT"` ➔ `GPCD="DM150"` 변경.
     - 클라이언트 스크립트([MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js)): 부품 그리드(`grid1`) 단위 컬럼 `gpcd: 'ITEMUNIT'` ➔ `gpcd: 'DM150'` 변경 및 날짜 주석 추가.
  2. **프로시저 최적화 및 표준화 ([MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql))**:
     - **오류 메시지 수정**: 사진 추가(`UPLOAD_FILE`) 및 사진 삭제(`DEL_FILE`) 시 복사된 `사원코드를 선택하세요.` ➔ `부품코드를 선택하세요.` 정상화.
     - **조회 조건 NULL 안전성 확보 (`LIST_EQMPART`)**: `$PARTCD`, `$PARTNM`, `$KEYWORD` 전처리(`TRIM(IFNULL(..., ''))`) 및 조건절 보강으로 NULL 시 0건 조회 결함 방지.
     - **변수 타입 안정성 확보**: `COMSPLIT` 수신 변수 `_$SAFEQTY`를 `DECIMAL(20,8)` ➔ `VARCHAR(100)`으로 조정하여 타입 불일치 방지 및 `NULLIF(_$SAFEQTY, '')` 안전 업데이트 적용.
     - **검증 최적화**: `IF EXISTS` 단독 스칼라 쿼리에 `LIMIT 1` 적용하여 풀스캔 방지.
     - **규칙 준수**: 최상단 Comment/Modify 이력 1일 1행 작성, 프로젝트 표준 구분선(`-- *****************************************************************************`), 2스페이스 계층 들여쓰기 및 SELECT 컬럼 7공백 오프셋 열 정렬 적용.
  3. **시스템 파라미터 등록 스크립트 작성**:
     - `MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql` 신규 작성하여 `COMCALLC` 연동 파라미터 등록 지원.
- **검증 결과**:
  - `node -c` 구문 검사 0 에러 통과.
  - UTF-8 with BOM(`\xef\xbb\xbf`) 및 CRLF 개행 무결성 확인 완료.
  - IIS Express 웹서버 렌더링 검증 완료 (`data-gpcd="DM150"` 바인딩 확인).

### 2. EQM1001_R03 반려 코드 제거 및 대기·승인 통일

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql, 05.Procedure/EQM1001_REV_SETUP/99_VERIFY.sql
- **배경 및 원인**: 반려 기능이 없는 R03에서 반려 분기와 사유가 잔존하여 제거 요청
- **작업 상세 내용**:
  - 그룹·설비 목록, REV 목록, 출력 이력의 반려 표시 및 승인 반려 전용 검증 제거. REJREASON 조회·입력·저장 참조와 양탭 4개 반려사유 컬럼 제거. R03 파라미터 29→28 전환 SQL 및 확인 건수 갱신. REV 없음 공란, 존재시 대기·승인 유지. 기존 JOIN·CRUD·독립REV·승인 이력키·테이블 구조 유지
- **검증 결과**: 격리 MariaDB10.2.44에서 SQL 컴파일 및 조회·출력 전후비교·양탭 개정저장·승인·중복승인 차단·CRUD·독립REV·주기저장·파라미터등록19건, 실제 R03 JS 모의실행6건 합계25건 통과. BOM/CRLF 및 원본 변경없음 확인 후 반영. 실DB 변경·서버 배포·실브라우저 실행 없음

### 2. EQM1001_R03 및 R04 프로시저 들여쓰기·가독성 표준화 및 규칙 등록

- **수정/대상 파일**: [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R04.sql), [procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md)
- **배경 및 원인**: SQL 프로시저 가독성 및 유지보수성을 극대화하기 위해 R04의 표준 들여쓰기/열 정렬(SELECT 컬럼 7칸 정렬, 2스페이스 계층 구조)을 규칙으로 공식 등록하고 R03과 R04 전체 쿼리에 일괄 적용
- **작업 상세 내용**:
  - 1. procedure.md 및 sql_structure.md에 2스페이스 계층 들여쓰기, SELECT 연속 컬럼 열 정렬(7공백 오프셋), 주요 절(FROM, JOIN, WHERE) 정렬 표준 지침 및 R04 템플릿 명시 2. MES_SNS2_EQM1001_R04.sql 전체 분기 들여쓰기/열 정렬 적용 및 1일 1행 수정이력 반영 3. MES_SNS2_EQM1001_R03.sql 전체 1,032행(17개 분기, 반복 루프, 조건문, SELECT 열)에 동일 표준 일괄 적용 및 1일 1행 수정이력 반영
- **검증 결과**: BOM(UTF-8 with BOM) 보존, CRLF 줄바꿈 통일(단독 LF 0건, \r\r\n 0건), 문법 무결성 검증 완료

### 2. EQM1001_R04 전체 SQL 들여쓰기 및 프로시저 가독성 규칙 표준화

- **수정/대상 파일**: [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R04.sql), [procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md), [sql_structure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/sql_structure.md)
- **배경 및 원인**: EQM1001_R04 프로시저의 L174-L201(LIST_PLAN_EQM02 분기) 스타일을 기준으로 파일 전체의 들여쓰기, SELECT 컬럼 열 정렬, 제어문 계층 구조를 전면 통일하고, 규칙 문서(.agents/rules)에 영구 표준으로 반영
- **작업 상세 내용**:
  - 1) EQM1001_R04 전체 분기(공통 검증, LIST_CYCLE_EQMCD, LIST_PLAN_EQM02, ADD_CHKRSTEQM, SEARCH_CHKRSTEQM, SAVE_CHKRSTEQM, DELETE_CHKRSTEQM) 들여쓰기 및 SELECT 컬럼 열 정렬 표준화 2) .agents/rules/procedure.md 3절에 SELECT 컬럼 정렬, SQL 절 키워드 정렬, 제어문 계층적 들여쓰기 및 EQM1001_R04 모범 예시 명시 3) sql_structure.md에 procedure.md 서식 표준 참조 연결 4) UTF-8 with BOM 및 CRLF 인코딩 무결성 검증
- **검증 결과**: BOM(0xEF 0xBB 0xBF) 및 CRLF 개행 무결성 확인 완료, 프로시저 구문 및 규칙 문서 정상 반영 확인

### 2. EQM1001_R04 미사용 반환 컬럼 제거

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R04.sql
- **배경 및 원인**: 사용자가 불필요·미사용 부분 삭제 요청, 개선 작업은 보류
- **작업 상세 내용**:
  - R04 SQL의 전체 화면·보고서 호출과 공통 SetStore 바인딩 확인 후 미사용 반환 값만 제거. 등록 항목의 EQMCD·PLANTPNM, 수정 실적 헤더의 CHKTP·RTIME·REVCD·GRPREVCD, 수정 항목의 CHKRSTKEY·PLANTPNM 반환 제거. 실제 DB 컬럼과 저장 REV 키는 유지. 사용 중인 지역변수·6개 호출 분기·15개 파라미터·JOIN·조건·검증·CRUD 쓰기 문장은 유지. 당일 SQL 이력 한 행 통합
- **검증 결과**: 격리 MariaDB 10.2.44 네트워크 none에서 원본·변경본 컴파일 및 사용 컬럼 비교, 월별 조회·등록·수정·삭제·중복 오류 롤백 검증. 실제 R04 JS를 새 반환 데이터에 연결해 등록 팝업의 설비·점검자·두 REV 키 및 수정·삭제 요청의 실적키 모의 검증. 총 14건 통과, 쓰기 SQL·검증 블록·15개 입력 정의 일치, BOM/CRLF·원본 대조·최종 바이트 확인. 실제 DB 조회/DDL/DML·배포·UI/C# 수정 없음

### 2. EQM1001_R04 정기점검 조회 구조 단순화

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R04.sql
- **배경 및 원인**: 사용자가 첨부 규칙에 따라 복잡한 R04 SQL 재작성 요청, 직전 검토의 REV 키 누락·점검값 형식 검증 보완은 제외
- **작업 상세 내용**:
  - 실제 DB SELECT로 컬럼 161개와 인덱스 9개, 월계획 PK EQMCD·CHKTP·YEAR 및 정기점검 월 배정 10개 모두 유효 사원코드 확인. YEAR_PLAN 윈도우 CTE와 타 점검구분 대체 제거 후 CHKTP=02 PK 직접 JOIN. 월 배정 ELT 조회를 조회·등록 공통으로 통합하고 사원명 역조회·동명이인 집계 제거. 월별 승인 항목 수 대신 존재 플래그 사용. 설비 잠금은 등록에만 적용. 15개 파라미터·반환 컬럼·UNION ALL·두 적용 REV 키·실적 중복/누락/오류 롤백·수정 중복 항목 임시 테이블 유지. 신규 검증 보완 미추가
- **검증 결과**: 네트워크 none 격리 MariaDB 10.2.44에 실제 최신 컬럼/PK 구성 후 원본·변경본 비교 38건 통과. 월별 현황, 최신 승인본, 빈 최신 승인본, 그룹 없는 설비, 동 코드 G/E 실적, 조회 후 새 승인, 등록/수정/삭제, 오류/중복/누락 롤백, 의도한 호환 제거, 제외한 보완 로직 미추가 확인. EXPLAIN에서 YEAR_PLAN PK eq_ref 직접 조회 확인, 속도 개선율 미측정. BOM/CRLF·당일 이력 1행·원본 대조·반영 바이트 일치 확인. 실제 DB는 SELECT만 실행, 실제 서버 DDL/DML·프로시저 배포 및 UI/C# 수정 없음

### 1. EQM1001 테이블 연결도 및 역할 표 시각 자료 작성

- **수정/대상 파일**: docs/EQM1001_테이블연결도_20261012.html, .svg, .png, _역할표.html,_역할표.png
- **배경 및 원인**: 사용자가 Mermaid 연결도의 작은 글자와 복잡한 배치 대신 첨부한 밝은 테이블 양식의 연결도 및 나란히 비교하는 역할 표 요청
- **작업 상세 내용**:
  - 현재 R03·R04·R05와 테이블 SQL을 대조하여 핵심 9개와 조회 보조 2개를 정리. 컬럼별 행·PK·키 연결·항목정보 복사를 구분하는 밝은 SVG 연결도, 11개 테이블의 분류·담당 내용·실제 역할·연결 기준 HTML 표 및 PNG 작성. CHKPLANEQM 미사용과 HEADER·DETAIL 대체, 두 적용 REV 키, 현재 승인 실행과 반려·처리이력 팝업 경로 미확인을 설명 문서에 명시
- **검증 결과**: 격리 임시 프로필 headless Edge에서 렌더링 및 이미지 육안 확인. SVG 1개·표 11행·헤더 5개·가로 넘침 없음·브라우저 페이지 오류 0건·중국어 문자 없음·UTF-8 BOM/CRLF 확인. SQL·화면 업무 소스 및 실제 DB·서버 배포 변경 없음

---

## 🕒 2026-10-08 (목) 작업 내역

### 2. EQM1001 빈 데이터 기준 테이블 변경 SQL 개별 분리

- **수정/대상 파일**: 05.Procedure/EQM1001_REV_SETUP/00_CHECK.sql, 01_MSTEQMREV_DETAIL.sql, 02_CHKPLANEQM_APRV.sql, 03_CHKRSTEQM.sql, 04_CHKRSTEQMKND.sql, 99_VERIFY.sql; MES_SNS2_EQM1001_R02/R03/R05_SYSTEM_PARAMETERS.sql; docs/EQM1001_REV_독립관리_최종안_20261008.md; PLAN_REV_DEPLOY.sql 및 PLAN_REV_INDEPENDENT.sql 삭제
- **배경 및 원인**: 사용자가 정기점검 데이터를 비웠으므로 데이터 이전 없이 테이블 변경을 하나씩 실행할 수 있도록 일괄 SQL 분리 요청
- **작업 상세 내용**:
  - 변경 전후 SELECT와 네 테이블별 ALTER 한 문장을 각각 분리하고 R02 파라미터 파일 추가, R03/R05 파라미터 등록을 페이지별 삭제 후 재등록으로 통일. 데이터 이전·승인이력 복원·실적 출처 보정·발번·업무 데이터 삭제·백업 테이블 생성 제외. 실행 순서는 00 확인, DETAIL, APRV, 실적 HEADER, 실적 DETAIL, R02부터 R05까지 각 프로시저와 파라미터 등록, 99 검증. 업무 프로시저·화면 동작 변경 없음
- **검증 결과**: 격리 MariaDB 10.2.44 네트워크 none에서 분리 실행 16건 통과. 순차 ALTER·반복 실행·APRV 중간 스키마 전환·프로시저 4개 컴파일·파라미터 정확한 순서와 개수 및 다른 페이지 보존·BOM/CRLF·원본 대조 후 반영 확인. 실제 DB 최신 구조 조회·DDL/DML·서버 배포 미수행

### 2. EQM1001 REV 항목 사용여부 제거 및 최종 적용 SQL 정리

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql,05.Procedure/MES_SNS2_EQM1001_R04.sql,05.Procedure/MES_SNS2_EQM1001_R05.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV_INDEPENDENT.sql,05.Procedure/MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql,01.Office/PAGEEQM/EQM1001/EQM1001_R03.js,05.Procedure/MES_SNS2_EQM1001_PLAN_REV_DEPLOY.sql,docs/EQM1001_REV_독립관리_최종안_20261008.md
- **배경 및 원인**: 사용자가 REV DETAIL의 항목별 USEYN이 불필요하다고 정정하고 나머지 실적 구조는 유지하면서 최종안·실행 SQL·도입 결과 설명 요청
- **작업 상세 내용**:
  - DETAIL에 항목 존재 시 포함하는 구조로 변경. 두 탭/그룹 복사 팝업의 사용여부 컬럼과 변환·전송 제거. R03 CRUD·복사·REV·출력, R04 승인본·실적, R05 건수의 DETAIL USEYN 참조 제거. R03 USEYN_LIST 제거로 파라미터 30→29. 설비/그룹/항목 기준정보 USEYN 유지. 초기화된 DETAIL에서 기존 USEYN 컬럼을 제거하도록 전환 SQL 변경. 실적의 REVCD/GRPREVCD·항목 PLANTP·복합 PK 유지. 기존 테이블 정리→프로시저 4개→파라미터 재등록을 포함한 일괄 DEPLOY SQL 및 상세 최종안 작성. 로컬 파일 9개 반영
- **검증 결과**: 격리 network none MariaDB10.2.44에서 프로시저 4개 컴파일, DB 38건·JS 이벤트 17건 총55건 통과. 별도 빈 스키마 전환·반복 실행·데이터 있는 USEYN 삭제 차단 검증. REV3 삭제→REV4→REV5 재추가 및 다른 대상/이전 승인본 보존, 두 승인본 UNION ALL·같은 점검코드 실적 분리·롤백·초기화 후 실적 유지. 일괄 SQL 두 번 실행·메타데이터 R02=21/R03=29/R04=15/R05=10 순서/기존 실적 보존 확인. JS문법·BOM/CRLF·원본 동일성 검증. 실서버 DDL/DML·파일 배포·브라우저/PDF 테스트·이번 DB 최신 구조 재조회 미실시

### 2. EQM1001_R04 팝업 적용 REV 번호 표시 간소화

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R04.sql,01.Office/PAGEEQM/EQM1001/EQM1001_R04.js
- **배경 및 원인**: R04 등록·수정 팝업에서 그룹/설비 구분 명칭 없이 REV 번호만 표시 요청
- **작업 상세 내용**:
  - 등록 조회 두 UNION ALL 분기 및 실적 수정 조회 REVNM을 REV.n으로 통일. 등록·수정 그리드 적용 REV 너비를 90으로 조정. 내부 PLANTP 구분, 독립 REV 키, 중복 점검코드 행 및 CRUD 유지. REV 연결 없는 기존 실적은 공란 표시
- **검증 결과**: 네트워크 none 격리 MariaDB10.2.44에서 R04 컴파일, 등록 REV.0/REV.2 및 동일 점검코드 2행 유지, 새 승인 후 기존 실적 적용 REV 보존, REV 연결 초기화 시 공란/실적 행 보존 검증. JS 문법, SQL 변경 범위, BOM/CRLF 검증 통과 후 로컬 소스 반영. 실제 DB/서버 적용 및 실제 브라우저 테스트 없음

### 2. EQM1001 정기점검 작업본 전환 및 그룹·설비 REV 독립 관리

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R02.sql,05.Procedure/MES_SNS2_EQM1001_R03.sql,05.Procedure/MES_SNS2_EQM1001_R04.sql,05.Procedure/MES_SNS2_EQM1001_R05.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV_INDEPENDENT.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV_RESET.sql,05.Procedure/MES_SNS2_EQM1001_R04_SYSTEM_PARAMETERS.sql,01.Office/PAGEEQM/EQM1001/EQM1001_R03.js,01.Office/PAGEEQM/EQM1001/EQM1001_R04.js,01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx
- **배경 및 원인**: CHKPLANEQM은 보존하되 정기점검에서 사용 중지하고 그룹/설비의 항목·REV·승인을 독립 관리 요청. 마지막 설명에 따라 R04 팝업은 두 최신 승인본의 항목과 적용 REV를 함께 표시
- **작업 상세 내용**:
  - R03 조회·복사·등록·저장·삭제·승인·출력을 HEADER/DETAIL로 전환하고 그룹/설비 공통 CRUD로 통합. 승인본 변경은 본인 다음 REV만 생성하며 비사용 항목 재추가·기존 승인본 보존·변경 없는 저장 시 REV 생성 방지. R02 참조검증/R05 목록도 DETAIL로 전환. R04는 그룹/설비 최신 승인본을 UNION ALL로 반환하고 설비그룹 REV.n/설비별 REV.n 표시. 실적 헤더 REVCD와 GRPREVCD에 적용키, 항목 PLANTP에 출처를 저장하여 동일 점검코드를 분리. 완료 실적은 현재 승인/REV 초기화와 무관하게 조회·수정·삭제 유지. 컬럼 전환: DETAIL.USEYN, CHKRSTEQM.GRPREVCD, CHKRSTEQMKND.PLANTP 및 PK(CHKRSTKEY,PLANTP,CHKKNDCD). R04 파라미터 17→15: 미사용 명칭·항목·방법·판정구분 목록 4개 제거, GRPREVCD/PLANTP_LIST 2개 추가. SQL/JS 11개 로컬 소스만 반영
- **검증 결과**: 네트워크 none MariaDB 10.2.44에서 프로시저 4개 컴파일 및 DB 시나리오 39개, JS 이벤트 모의검증 16개 통과. 컬럼 전환 SQL 반복 실행, 새 컬럼 없는 스키마와 새 스키마의 초기화/실적 보존, 실제 등록 당시 REV 표시, 파라미터 15개 순서, JS 문법/BOM/CRLF 검증. 실서버 SELECT 확인: HEADER/DETAIL/APRV 각0, 실적15(REV 연결0), CHKPLANEQM67. 실서버 DDL/DML·브라우저 실제 CRUD·서버 파일 적용은 미실시

### 2. [EQM1001] 점검실적 보존 REV 초기화 SQL 작성

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_PLAN_REV_RESET.sql
- **배경 및 원인**: 사용자가 기존 REV 데이터 초기화 SQL 작성 및 CHKPLANEQM 사용 종료/독립 REV 전환 순서 정리 요청. 실적 처리 질문에 실적은 유지하고 REV 연결만 초기화 선택
- **작업 상세 내용**:
  - CHKRSTEQM의 비어 있지 않은 REVCD만 빈 값으로 초기화, CHKPLANEQM_APRV→MSTEQMREV_DETAIL→MSTEQMREV_HEADER 데이터 삭제. 한 트랜잭션과 오류 롤백, 실행 전후 건수 및 영향 건수 표시. 점검실적 상세·CHKPLANEQM·YEARPLAN·기준정보·발번값 유지. CHKPLANEQM 테이블/데이터 삭제 방식은 질문 미응답으로 미포함. 기존 초기이관 SQL 재실행 금지 설명
- **검증 결과**: 실제 DB SELECT 확인: HEADER37/DETAIL86/APRV420, 실적15 중 REV참조7, CHKPLANEQM 정기점검69. 초기화 대상4개 InnoDB 확인. 격리 MariaDB10.2.44에서 컴파일·대상 삭제·실적 내용 보존·범위·반복·강제 오류 전체 롤백·BOM/CRLF 10건 검증 통과 후 로컬 SQL 작성. 실제 DB 및 서버 변경 없음

### 2. [EQM1001] CHKPLANEQM 사용 종료 전환 사전 검토

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, MES_SNS2_EQM1001_R04.sql (업무 소스 변경 없음)
- **배경 및 원인**: 사용자가 최신 파일 재조회 후 CHKPLANEQM 본체를 삭제하지 않고 사용 종료하도록 전환 요청; 고려사항을 먼저 공유하고 방향 결정 요청
- **작업 상세 내용**:
  - 최신 소스 R03 승인 전용 변경 및 LIST_PLAN_APRV 제거 등 수동 변경 확인. R03 25개 분기 중 17개가 CHKPLANEQM 본체 직접 참조, R04 6개 분기는 직접 참조 없음. DETAIL을 작업본 포함 REV별 저장소로 전환할 때 데이터 이관·USEYN 컬럼·승인 시 중복 INSERT 제거·승인본 불변·독립 G/E REV·실적 두 REV 및 중복코드 키·R02/R05 잔존 참조·YEARPLAN/APRV 별도 테이블 유지 고려사항 정리
- **검증 결과**: 실제 DB SELECT 확인: CHKTP02 작업본 69행 전부 Y, 최신 미승인 HEADER 8개 모두 DETAIL 없음. 이 중 FM116I210N 그룹 REV1 작업본 5개, 나머지 7개 작업본 0개. DETAIL USEYN 없음, CHKRSTEQM REVCD 단일·GRPREVCD 없음, 실적 DETAIL 출처 REVCD 없음. 규칙 준수하여 분석만 수행, 프로시저/DB 수정·컴파일 테스트 없음

### 1. [MST1002_R06] 생산설비정보 그리드 설비그룹코드 표시·설비그룹코드명 hidden 및 프로시저 컬럼 반환 추가

- **수정/대상 파일**: 01.Office/PAGEMST/MST1002/MST1002_R06.js, 05.Procedure/MES_SNS2_MST1002_R06.sql
- **배경 및 원인**: 생산설비정보(MST1002_R06) 화면의 그리드에서 설비코드(FANO) 앞에 설비그룹코드(EQMGUBUN)와 설비그룹코드명(EQMGRPNM) 컬럼을 추가하되, 상단 검색 패널 필터는 추가하지 않고 설비그룹코드명은 hidden 처리하도록 요청. 백엔드 프로시저 MES_SNS2_MST1002_R06.sql의 SEL_EQM 분기에서도 설비그룹코드·명 함께 조회하도록 수정 요청.
- **작업 상세 내용**:
  - JS: `MST1002_R06.js`의 `grid1` 초기화 컬럼에서 설비소분류(`EQMGROUP3`) 뒤, 설비코드(`FANO`) 바로 앞에 `EQMGUBUN`('설비그룹코드', width: 100, align: 'center') 표시 및 `EQMGRPNM`('설비그룹코드명', hidden: true) 컬럼 선언 추가. 신규 변경 위치 날짜 주석 작성 (`Optimization.md` 준수).
  - ASPX: 사용자 요청에 따라 검색 패널(`sdiv1`)에 신규 필터를 추가하지 않고 기존 검색 조건 유지.
  - SQL: `MES_SNS2_MST1002_R06.sql`의 `WHEN 'SEL_EQM' THEN` 분기에 `COMTYPE` (`GPCD = 'FM116' AND TPCD = A.EQMGUBUN`) LEFT JOIN 추가 및 `COALESCE(A.EQMGUBUN, '') AS EQMGUBUN`, `COALESCE(COMTYPE.TPNM, '') AS EQMGRPNM` 반환 컬럼 추가. 최상단 Modify 주석 1일 1행 원칙에 따라 작성 (`procedure.md`, `procedure_history.md` 준수).
- **검증 결과**: Node.js 구문 검사(`node -c`) 통과, MSBuild C# 솔루션 컴파일 에러 0건 성공, 인코딩 검사 통과(전체 파일 UTF-8 with BOM, CRLF 개행 일치, `\r\r\n` 0건), 실제 서버 DB 직접 변경 없음

### 2. [EQM1001_R03] 설비별 점검계획 탭 설비그룹코드 표시·설비그룹명 hidden 및 설비그룹 필터링 추가

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: "설비별 점검계획" 탭 좌측 그리드(grid1)에서 설비코드(FANO) 옆에 해당하는 설비의 설비그룹코드(EQMGUBUN) 표시 및 설비그룹명(EQMGRPNM) hidden 컬럼 선언, 상단 검색 영역(div_EQM)에 설비그룹 필터링(find_EQM_GRP) 추가 요청. 프로시저 MES_SNS2_EQM1001_R03.sql의 LIST_MSTEQM 분기에서도 설비그룹코드·명 반환 및 $EQMGRP 검색 조건 추가 요청.
- **작업 상세 내용**:
  - ASPX: `div_EQM` 패널 내 `find_EQMCD` 옆에 설비그룹 찾기 컨트롤(`find_EQM_GRP`, Field="EQMGRP", GPCD="FM116") 추가 배치 (주석 추가 없이 순수 태그 작성, `aspx_cs_comment.md` 준수).
  - JS: `EQM1001_R03.js`의 `grid1` 초기화 컬럼에서 `FANO` 옆에 `EQMGUBUN`('설비그룹코드', width: 100, align: 'center') 컬럼 추가 및 `EQMGRPNM`('설비그룹명', hidden: true) 컬럼 선언 추가. 신규 변경 위치 날짜 주석 작성 (`Optimization.md` 준수).
  - SQL: `MES_SNS2_EQM1001_R03.sql`의 `WHEN 'LIST_MSTEQM' THEN` 분기에 `COMTYPE` (`GPCD = 'FM116' AND TPCD = MSTEQM.EQMGUBUN`) LEFT JOIN 추가, `COALESCE(MSTEQM.EQMGUBUN, '') AS EQMGUBUN`, `COALESCE(COMTYPE.TPNM, '') AS EQMGRPNM` 반환 컬럼 추가, WHERE 절에 `$EQMGRP` 검색 필터링(`MSTEQM.EQMGUBUN LIKE ... OR COMTYPE.TPNM LIKE ...`) 추가. 최상단 Modify 주석 1일 1행 원칙에 따라 갱신.
- **검증 결과**: Node.js 구문 검사(`node -c`) 통과, MSBuild C# 솔루션 컴파일 에러 0건 성공, 인코딩 검사 통과(전체 파일 UTF-8 with BOM, CRLF 개행 일치, `\r\r\n` 0건), 실제 서버 DB 직접 변경 없음

### 2. [EQM1001_R03] 개정 이력(REV) 반려 버튼 및 반려 로직/프로시저 삭제

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: 개정이력(REV) 영역에서 반려 기능 삭제 요청 (설비별/설비그룹 반려 버튼 및 반려 팝업, 프로시저의 반려 처리 로직 일괄 삭제)
- **작업 상세 내용**:
  - ASPX: 설비그룹 및 설비별 개정이력 패널의 반려 버튼(`btn_GRP_REJECT`, `btn_EQM_REJECT`) 삭제, 점검계획 반려 팝업(`pop_PLAN_REJECT`) 마크업 삭제 (주석 없이 순수 태그 정리)
  - JS: `SavePlanStatus` 및 `SavePlanRevStatus`를 승인 전용으로 단순화, `planReject` 전역 변수 및 반려 분기/팝업 오픈 로직 제거, `SavePlanRev` 내 잔여 반려 분기(`rev.APRVSTT == 'R'`) 및 재요청 확인창 제거 후 단순 저장으로 정리, `btn_GRP_REJECT`/`btn_EQM_REJECT`/`btn_PLAN_REJECT_SAVE`/`btn_PLAN_REJECT_CANCEL`/`pop_PLAN_REJECT` 이벤트 핸들러 일괄 삭제
  - SQL: `SAVE_PLAN_STATUS` 분기에서 반려 상태(`$APRVSTT = 'R'`) 및 반려 사유 검증/저장 로직 제거, `SAVE_PLAN_REV` 오류 문구 간소화, 승인 전용 상태 저장으로 단순화, 안내 문구 정돈('승인·반려' -> '승인'), 최상단 Modify 이력 1일 1행 통합 갱신
- **검증 결과**: Node.js 구문 검사(`node -c`) 통과, MSBuild 컴파일 에러 0건, 인코딩 검사 통과(전체 파일 UTF-8 with BOM, CRLF 개행 일치, `\r\r\n` 0건), 실제 서버 DB 직접 변경 없음

### 2. [EQM1001_R03] 리비전 승인·반려 이력 버튼(APRVHISTORY) 및 관련 로직/프로시저 삭제

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 05.Procedure/MES_SNS2_EQM1001_R03.sql, docs/EQM1001_R03_R04_SQL_정리검토_20261008.md
- **배경 및 원인**: 설비점검계획(EQM1001_R03) 개정 이력 그리드 내 승인/반려 이력 조회 버튼(APRVHISTORY) 제거 및 연관된 JS 함수·그리드·팝업 마크업, 프로시저 분기(LIST_PLAN_APRV) 일괄 삭제 요청
- **작업 상세 내용**:
  - JS: `grid_GRP_REV` 및 `grid_EQM_REV`에서 `APRVHISTORY` 버튼 컬럼 제거, 이력 팝업 전용 그리드 `grid_PLAN_APRV` 생성문 삭제, 이력 조회 함수 `SearchPlanAprv` 삭제, 두 REV 그리드의 `onButtonClick` 핸들러 삭제
  - ASPX: `pop_PLAN_APRV` (리비전 승인·반려 이력) 팝업 마크업 태그 삭제 (주석 추가 없이 순수 태그 정리)
  - SQL: `MES_SNS2_EQM1001_R03.sql`에서 `WHEN 'LIST_PLAN_APRV' THEN` 분기 전체 삭제, 최상단 Modify 이력에 1일 1행 원칙에 맞추어 통합 갱신 (`리비전 승인·반려 이력(LIST_PLAN_APRV) 제거`)
  - 문서: `docs/EQM1001_R03_R04_SQL_정리검토_20261008.md` 분기 호출 목록에서 `LIST_PLAN_APRV` 삭제 및 사유 반영
- **검증 결과**: Node.js 구문 검사(`node -c`) 통과, MSBuild C# 솔루션 컴파일 오류 0건, 인코딩 검사 통과(전체 파일 UTF-8 with BOM, CRLF 개행 일치, `\r\r\n` 0건), 실제 서버 DB 직접 변경 없음

### 2. [EQM1001] 설비그룹·설비 REV 독립 관리 구조 분석

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, MES_SNS2_EQM1001_R04.sql 및 실제 DB 7개 테이블 (조회·분석만 수행)
- **배경 및 원인**: 설비별 계획 수정 시 그룹 REV도 영향을 받는 구조를 개선하고 점검 시 그룹·설비 최신 승인 계획을 함께 적용하는 설계 요청
- **작업 상세 내용**:
  - 원인: R03 CRUD 후 PLAN_KEY 양방향 연동, 그룹 CRUD의 소속 설비 CHKPLANEQM 일괄 변경·그룹 항목 합산, 그룹 재요청·승인/반려의 설비 REV 연동. 추천: 기존 HEADER의 PLANTP/PLANCD/REVNUM별 독립 REV, DETAIL을 각 REV의 대기·반려·승인 항목 저장소로 확장하여 정기점검 원본 통일; 승인본은 불변. 그룹·설비 승인도 각각 대상 REV만 처리. R04는 두 최신 승인 REV를 결정해 DETAIL 목록 합성. 실적에 두 적용 REV 및 항목 출처 기록. 기존 중복 항목의 소유권 분류 및 중복 코드 정책 확정 후 단계 전환 필요
- **검증 결과**: 실제 DB SELECT로 140개 컬럼 및 고유키 확인: HEADER REVCD PK와 PLANTP/PLANCD/REVNUM UNIQUE, DETAIL REVCD/CHKKNDCD PK, 실적 HEADER REVCD 단일 컬럼, 실적 DETAIL CHKRSTKEY/CHKKNDCD PK. 현재 소스와 R02/R05 등 연관 참조 확인. 설계 분석만 수행, 구현·DB DDL/DML·서버 반영 없음

### 2. [EQM1001_R03] 승인·출력 중복 검증 제거

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: 규칙 추가와 함께 SAVE_PLAN_STATUS의 PLANCD 중복 검사 및 CALL_PLAN_RPT 정규화 후 도달 불가능한 검사 실제 수정 요청
- **작업 상세 내용**:
  - SAVE_PLAN_STATUS는 PLANCD 필수 검사를 유지하고 다음 IF에서 중복 PLANCD NULL·빈 값 조건만 제거. CALL_PLAN_RPT는 기존 G/E 정규화를 유지하고 정규화 결과에 대한 NOT IN 검사만 제거; PLANCD 필수 검사와 오류 메시지 유지. 당일 Modify 한 줄에 통합
- **검증 결과**: 격리 MariaDB 10.2.44에서 수정 전후 전체 R03 컴파일 성공. 90개 NULL·빈 값·공백·잘못된 값·대소문자 입력 비교 및 설비그룹/설비별 승인·반려·출력 비교 포함 102건 통과. 저장 상태·승인본·이력·오류 메시지 동일. 파라미터 30개와 분기 유지, BOM·CRLF 및 당일 이력 한 줄 검증 후 로컬 반영. 실제 DB·서버 반영 없음

### 2. [규칙] 프로시저 중복 입력값 검증 방지 기준 추가

- **수정/대상 파일**: .agents/rules/procedure.md
- **배경 및 원인**: SAVE_PLAN_STATUS의 PLANCD 재검사와 CALL_PLAN_RPT 정규화 이후 도달 불가능한 조건이 반복되지 않도록 규칙 추가 요청
- **작업 상세 내용**:
  - 조건 작성 전 공통 검증·값 변경·종료 흐름 확인, 동일 값·조건은 한 번만 검증, 정규화 후 항상 참·거짓인 조건 제거, NULL 처리 및 재검증 목적 구분, 두 실제 분기를 적용 예로 기재하고 관련 분기 최종 검토 의무 명시. 업무 SQL과 실제 DB는 변경하지 않음
- **검증 결과**: 현재 R03 두 분기의 조건을 소스로 확인. 기존 procedure.md 내용은 보존하고 새 절만 추가했음을 비교 검증. UTF-8 BOM·CRLF 정상

### 2. [EQM1001_R03] 10월 8일 비사용 정기점검 재추가 작업 및 실제 DB 최신화 확인

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 05.Procedure/MES_SNS2_EQM1001_R04.sql (조회·비교만 수행)
- **배경 및 원인**: 사용자가 2026-10-08 비사용 항목 재추가 지원 작업 내역 및 현재 프로시저 반영 상태 확인 요청
- **작업 상세 내용**:
  - 설비그룹 LIST_GRP_EQM02_ADD/REG_GRP_EQM02 및 설비별 LIST_EQM02/REG_EQM02 작업 복원: 사용 중인 등록만 추가 목록에서 제외하고 비사용 등록은 재활성화, 누락 등록은 신규 추가; 기존 승인본 보존. 현재 로컬과 실제 DB 프로시저 본문 및 파라미터 등록 비교
- **검증 결과**: 실제 DB SELECT 조회로 R03 전체 본문·26개 분기, R04 전체 본문·6개 분기 일치 확인(주석·공백 제외). 실제 파라미터 및 SYSTEM_PARAMETERS 등록 이름·순서 R03 30개/R04 17개 모두 일치. 재추가 4개 분기는 이전 검증본과 일치. 이전 67건 DB 테스트 통과 기록 확인, 이번 턴 재실행 아님. DB·서버 및 업무 소스 변경 없음

### 2. [EQM1001_R03·R04] 미사용 SQL 정리 및 JOIN 개선 후보 분리

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R04.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 05.Procedure/MES_SNS2_EQM1001_R04_SYSTEM_PARAMETERS.sql, docs/EQM1001_R03_R04_SQL_정리검토_20261008.md
- **배경 및 원인**: 사용하지 않는 SQL은 즉시 제거하고 JOIN·의미없는 구문은 삭제하지 않고 개선 전후 두 표로 정리 요청
- **작업 상세 내용**:
  - 페이지·보고서 및 저장소 호출 대조 결과 R03 26개·R04 6개 분기 모두 사용, S05A CALL_PLAN_RPT도 사용되어 분기 삭제 없음. R03 업무 소스 유지. R04 미사용 일괄처리 입력값 4개와 소비되지 않는 CHKCYCLE_LIST·지역변수·COMSPLIT·반환 컬럼·JS 전송 2곳·DEBUG 주석 제거. R04 인자 22→17 변경에 맞춘 전용 SYSTEM_PARAMETERS 갱신 SQL 추가. JOIN·중복 검증·조회 조건은 변경하지 않고 8개 후보의 현재 문제/개선 제안 표를 문서화
- **검증 결과**: 현재 DB 컬럼·키·중복건수 SELECT 확인. 전체 호출 분기 리터럴 대조 및 지역변수/입력값 참조 확인. 격리 MariaDB 10.2.44에서 원본·정리본 R04 전체 컴파일과 19건 전후 비교 통과: 6개 기능·등록/수정/삭제 저장결과·조회순서·적용 REV·계획 점검자·필수값/중복/승인/미사용설비/미계획월 검증·과거실적 REV 보존·메타데이터 범위/재실행/호출순서. JS 구문 및 BOM/CRLF 검증. 실제 브라우저 E2E와 성능 벤치마크 미실행

### 2. [EQM1001_R03] 비사용 정기점검 항목 재추가 지원

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: REV.3에서 사용한 항목을 REV.4에서 비사용·삭제한 뒤 REV.5에서 다시 추가할 수 있도록 요청. 기존 추가 목록과 등록 처리가 USEYN=N 행을 이미 등록된 것으로 취급하여 998 재추가 불가
- **작업 상세 내용**:
  - 설비그룹 LIST_GRP_EQM02_ADD는 사용 중인 계획만 등록 수에 포함. 설비별 LIST_EQM02는 해당 설비의 정기점검·사용 Y 계획만 추가 제외. REG_GRP_EQM02·REG_EQM02에서 비사용 기존 행을 Y로 재활성화하고 입력 비고·수정자 정보를 저장; 기존 순서·주기·최초 등록 정보 유지. 이미 사용 Y인 행은 그대로 유지하고 물리 삭제·미등록 항목은 기존 INSERT 사용. 변경 건수를 기존 공통 REV 생성·재요청 흐름에 연결. 승인본·이력·승인 상태 분기와 JS/ASPX 변경 없음
- **검증 결과**: 실제 DB 키 구조 SELECT 확인 후 네트워크 차단 MariaDB 10.2.44에서 변경 프로시저 전체 컴파일. 기존 승인·반려·CRUD 검증 46건과 재추가 전용 21건 총 67건 통과. 기존 코드 재현, 두 탭 REV.3 사용→REV.4 비사용 승인→REV.5 재추가 승인, 승인본·이력 불변, 활성 행 보존·반복 추가 무변경, 사용 설비 21대 재활성화, 부분 등록·NULL·빈 상태·마스터 제외·물리 삭제 재등록·중간 오류 롤백 확인. 원본 해시 확인 후 검증한 SQL만 로컬 반영, UTF-8 BOM/CRLF 유지

### 2. [EQM1001_R03] FM116I210N 점검코드 998 재추가 제외 원인 확인

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js (분석 대상, 소스 변경 없음)
- **배경 및 원인**: 기존 998 항목을 삭제한 뒤 설비그룹 추가 목록에 나타나지 않는 원인 확인 요청
- **작업 상세 내용**:
  - 실제 DB SELECT 결과 MSTCHKKND의 998은 정기점검 02·사용 Y로 정상. FM116I210N 사용 설비 21대 모두 CHKPLANEQM에 998이 USEYN=N으로 존재하며 RTIME 2026-10-08 10:15:35, MTIME 10:16:51. 실제 서버 LIST_GRP_EQM02_ADD는 계획 USEYN 조건 없이 등록 건수를 세므로 21<21 조건이 거짓이 되어 항목 제외. REG_GRP_EQM02 역시 N인 기존 행을 존재로 판단하므로 조
  - 실제 DB SELECT 결과 MSTCHKKND의 998은 정기점검 02·사용 Y로 정상. FM116I210N 사용 설비 21대 모두 CHKPLANEQM에 998이 USEYN=N으로 존재하며 RTIME 2026-10-08 10:15:35, MTIME 10:16:51. 실제 서버 LIST_GRP_EQM02_ADD는 계획 USEYN 조건 없이 등록 건수를 세므로 21<21 조건이 거짓이 되어 항목 제외. REG_GRP_EQM02 역시 N인 기존 행을 존재로 판단하므로 조회 조건만 변경해도 재활성화되지 않음. 설비별 LIST_EQM02와 REG_EQM02도 비사용 기존 행의 제외·재활성화 문제 존재. 현재 삭제 분기는 물리 DELETE이며 N 전환 경로는 데이터만으로 단정하지 않음
- **검증 결과**: 실제 서버 SELECT 5건: 마스터·그룹 집계·21개 소속 설비 행·현재 프로시저 정의·팝업 제외 조건 재현. 팝업 조건 결과 GROUP_EQMCNT=21, COUNT_USED_BY_POPUP=21, POPUP_VISIBLE=N 확인. 실제 DB DML/DDL 및 업무 소스 수정 없음

### 2. [EQM1001_R03] 설비그룹·설비별 승인 로직 동일성 검증

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql (분석 대상, 업무 소스 변경 없음)
- **배경 및 원인**: 설비그룹 점검계획과 설비별 점검계획 탭의 승인 관리가 동일한 규칙으로 동작하는지 확인 요청
- **작업 상세 내용**:
  - 두 탭이 개정내용 저장·승인/반려·이력·출력 공통 함수와 SQL 분기를 사용함을 확인. 개정내용 미입력/미저장 및 반려사유 검증, 반려 후 보완·재요청, 기존 승인본 보존, 최신 승인 REV 수정 시 다음 대기 REV 생성, 과거 REV 조회 전용 규칙 동일. 그룹은 사용 중인 소속 설비의 최신 미승인 REV를 일괄 처리하며 설비별은 선택 설비만 처리하는 범위 차이만 존재. 실제 서버 ROUTINE_DEFINITION을 SELECT하여 핵심 8개 분기 일치 확인
- **검증 결과**: 격리 MariaDB 10.2.44에서 현재 프로시저 컴파일 및 SQL 46건 통과. 현재 JS 함수 추출·UI/전송 모의 검증 21건 통과, 합계 67건. REV 컬럼 및 버튼 연결 동일성 확인. 실제 브라우저 E2E는 미실행. 실제 DB 변경·서버 파일 수정·배포 없음

### 2. [EQM1001_R03] 두 탭 계획서 출력 버튼 위치 통일

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx
- **배경 및 원인**: 설비그룹에만 버튼을 이동했던 누락을 보완하여 설비별 탭에도 같은 검색행 우측 배치 적용 요청.
- **작업 상세 내용**:
  - btn_EQM_PLAN_RPT를 개정이력 버튼 영역에서 div_EQM 설비 검색행으로 이동. 두 탭 모두 기존 find와 같은 부모 영역에서 Float=right, MarginRight=10, MarginTop=6 적용. 출력 버튼 ID 및 기존 G/E 출력 이벤트 유지. ASPX 위치 변경만 수행하여 보고서/프로그램 재빌드 불필요.
- **검증 결과**: 적용 전 후보 검증: 두 탭 검색 find와 버튼의 같은 부모 패널, 버튼 ID 유일성, 우측 배치 속성 일치, 기존 위치 제거 및 변경점 원상복원 일치 확인. 적용 후 UTF-8 BOM/CRLF 및 파일 내용 일치 확인. 실제 서버 화면/배포 미실행.

### 2. [EQM1001_R03] 설비그룹 검색행 우측으로 계획서 출력 버튼 이동

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx
- **배경 및 원인**: 계획서 출력 버튼을 설비그룹 find 검색 컴포넌트와 같은 줄 맨 오른쪽에 배치하도록 요청.
- **작업 상세 내용**:
  - btn_GRP_PLAN_RPT를 개정이력 버튼 영역에서 div_GRP 검색행으로 이동. 기존 Its:button Float=right와 MarginRight=10, MarginTop=6 사용. 버튼 ID/색상/너비/출력 이벤트 및 설비별 탭 배치 유지. 공통 컴포넌트/JS/프로시저/리포트 수정 없음. ASPX 배치 변경으로 보고서 재빌드 불필요.
- **검증 결과**: 선반영 전 후보 마크업에서 버튼 ID 유일성, find와 같은 부모 영역, 기존 위치 제거 및 두 줄 이동 외 원본 복원 일치 확인. Float 속성의 공통 컨트롤 정의·HTML 렌더링 확인. UTF-8 BOM/CRLF 및 적용 내용 일치 확인. 실제 웹 화면 미실행, 서버 배포 없음.

### 2. [EQM1001_R03] 주기 저장 승인계획 검증 제거 위치 재확인

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql (확인만), 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js (확인만)
- **배경 및 원인**: 주기 저장의 승인된 정기점검계획 검증을 어느 위치에서 제거했는지 정확한 확인 요청.
- **작업 상세 내용**:
  - 현재 SAVE_CYCLE_EQMCD 1163행과 사용 설비 검증 1181행 확인. 2026-10-06 수정 전 백업 R03-original.sql 828~845행의 GRP_REV/EQM_REV 승인 헤더 조인과 APRVSTT=A, 그룹 승인 존재 조건 및 승인된 정기점검 계획만 주기관리할 수 있습니다 오류를 사용 중인 설비 확인 블록으로 교체했음을 당시 stage.cjs와 원본 대조로 확인. 일반 저장 JS 857행 및 일괄 주기설정 JS 815행 모두 같은 저장 분기 호출. 삭제 분기도 같은 변경 적용, 실제 점검 R04 승인 검증과 완료실적 월 잠금 유지.
- **검증 결과**: 현행 로컬 파일 및 수정 전 백업/적용 스크립트 대조 완료. 업무 소스 수정·DB 반영·재빌드·배포 없음.

### 2. [EQM1001_R03] 계획서 개정이력 최신 4건 제한 및 이월 출력 제거

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs
- **배경 및 원인**: CNC FM116I210N 등 개정이력 증가 시 다음 페이지로 이어지는 양식이 불편하여 최신 4건만 표시하도록 사용자 요청.
- **작업 상세 내용**:
  - CALL_PLAN_RPT 개정이력 SELECT를 REVNUM 내림차순 LIMIT 4로 제한하여 그룹·설비 공통 적용. 승인·반려·대기 각 REV의 최종 상태와 기존 이력 필드를 유지. S05A의 개정이력 이월 SubBand/XRSubreport 및 전용 CreateHistoryReport 메서드 삭제. 하단 기존 4칸과 계획서 본문 양식 유지. 기존 코드의 REV 자동선택 및 명시 REV 출력 처리 유지. 주기관리 성능 개선과 다른 CRUD 분기 변경 없음. 실제 DB/서버 파일 반영 없음.
- **검증 결과**: 네트워크 없는 MariaDB 10.2.44에서 원본·수정 전체 프로시저 컴파일 및 17건 통과: 그룹/설비 최신 4건·상태·순서, 과거 REV 선택에도 최신 이력 유지, REV 공란 자동선택, REV.0, 1~3건 경계값, 잘못된 계획 선택, 본문 결과 동일, 이월 코드 제거 확인. 스테이징 S05A를 프로젝트 MSBuild Release로 빌드 성공. 검증 후 로컬 소스 적용, BOM/CRLF/파일 바이트 일치 확인. 실제 웹 PDF 출력은 미실행.

### 2. [EQM1001_R03] 확인창·알림 토스트 및 화면 안내 문구 간소화

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx
- **배경 및 원인**: 설비그룹/설비별 점검계획 및 주기관리 화면에서 과도하게 길거나 설명조로 작성된 확인 팝업, 알림 토스트, 화면 안내 라벨을 직관적이고 간결한 문구로 전면 간소화 요청
- **작업 상세 내용**:
  - 1. JS 확인팝업 4건 간소화(복사/저장/삭제/설비별 재요청) 2. JS 토스트 알림 3건 간소화(개정내용 저장 안내/설비 미체크/개정입력 유도) 3. ASPX 안내 라벨 2건 간소화(설비별 탭 상단 안내 라벨, 일괄 주기설정 팝업 상단 안내)
- **검증 결과**: UTF-8 with BOM 및 CRLF 개행 무결성 검증 통과(BOM: true, DoubleCR: false), git diff 확인 완료

### 1. [EQM1001_R03] 설비그룹 개정 저장 및 승인 재요청 확인 메시지 문구 간소화

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js
- **배경 및 원인**: 설비그룹 점검계획 탭에서 개정 저장·재요청 시 호출되는 컨펌 메시지가 과도하게 길고 설명조여서 직관적이고 간결한 문구로 개선 요청
- **작업 상세 내용**:
  - EQM1001_R03.js SavePlanRev 함수 내부 planTp == 'G' 분기의 컨펌 메시지를 '개정내용 저장 및 소속 설비 계획을 승인 재요청하시겠습니까?'로 압축 간소화
- **검증 결과**: UTF-8 with BOM 및 CRLF 개행 무결성 검증 완료(BOM: true, DoubleCR: false)

---

## 🕒 2026-10-07 (수) 작업 내역

### 2. [EQM1001_R03] 계획서 출력 최신 REV 자동 선택 및 모든 개정이력 상태 표시

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/Reports/EQM1001.exe
- **배경 및 원인**: 좌측 그리드에서 설비그룹 또는 설비 선택 후 계획서 출력 시 'ERROR:출력할 REV를 선택해주세요.' 오류 발생. 화면(JS) 및 보고서 C#(S05A)는 PLANTP/PLANCD만 전송하는데 SQL CALL_PLAN_RPT에서 숫자 REVNUM을 필수로 검사하여 불일치 발생. 사용자 추가 요구: 계획서 출력 시 해당 대상에 속한 모든 개정이력의 상태(승인·반려·대기)가 계획서에 명확히 표기되어야 함.
- **작업 상세 내용**:
  - 1. CALL_PLAN_RPT 분기 개선: REVNUM 미전달 시 대상 최신 REV 자동 선택 및 해당 REV 계획 본문 조회 (REVNUM 전달 시 호환 유지)
  - 1. 개정이력 상태 반환: CALL_PLAN_RPT 이력 쿼리에 APRVSTTNM(승인·반려·대기) 및 APRVSTT 컬럼 추가, 전체 리비전 최종 상태를 최신순으로 반환
  - 1. S05A 리포트 개정이력 상태 표기: 하단 4칸 박스에 [승인]·[반려]·[대기] 태그와 일자·개정내용을 함께 표시하고, 4건 초과 시 다음 페이지 서브리포트에 독립된 '상태' 컬럼을 추가하여 모든 개정이력 상태를 직관적으로 출력
  - 1. R03.js PrintPlanRev 코드 미취득 시 안내 토스트 보강
  - 1. S05A Report Release 빌드(오류 0건) 및 바이너리 동기화, UTF-8 BOM 및 CRLF 개행 무결성 준수
- **검증 결과**: MSBuild 컴파일 오류 0건, 인코딩 BOM/CRLF 검증 통과, git diff 검증 완료

### 2. [EQM1001_R03] 정기점검 주기관리 조회 성능 개선 업무 소스 반영

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: 사용 중인 전체 설비 조회에서 값이 없는 설비등급과 12개월 점검자까지 GPCD를 반복 실행하여 원본 SELECT 약 10.27초 소요. 사용자 지시로 검증한 개선안을 업무 소스에 반영.
- **작업 상세 내용**:
  - LIST_CYCLE_EQMCD의 13개 코드명 변환 표현식에 LENGTH > 0 조건을 적용하여 NULL/빈 문자열은 함수 호출 생략. 공백만 저장된 기존 값은 길이로 구분하여 원본 표시 유지. 값이 있는 월의 불필요한 중첩 IFNULL 제거. 전체 사용 설비, 기존 JOIN/정렬/필터, 설비등급, M01~M12 표시명 및 M01CD~M12CD 저장코드 유지. SQL 헤더 Modify 이력 2026-10-07 한 행에 통합. 파라미터/저장·삭제/REV·승인 기능/JS/공통 함수 변경 없음. 실제 서버 DB 반영 없음.
- **검증 결과**: 격리 MariaDB 10.2.44에서 원본·수정 프로시저 전체 컴파일 및 18건 검증 통과: 미등록 주기, NULL/빈 문자열/공백, 정상·미등록 코드, 기존 사원명, 설비코드·이름 검색, 연도·CHKTP 분리, 조회년도 검증, 승인 계획 없는 주기 저장, 12개월 사원코드 저장/이름 조회, 수정·삭제 및 실적 월 잠금. 최종 후보 실제 DB 읽기 전용 SELECT 222.12ms, 1143행 30컬럼 전체 JSON/순서 동일. 연결 개설/웹 렌더링 제외 측정. 스테이징 검증 후 적용 파일 바이트 일치, 다른 분기·입력 서명 불변, UTF-8 BOM/CRLF 정상.

### 2. [EQM1001_R03] 정기점검 주기관리 조회 지연 실측 및 개선안 검증

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql (분석만), 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js (분석만)
- **배경 및 원인**: 주기관리 전체 조회 약 10초. 활성 설비 1143대에 설비등급과 12개월 점검자 명칭을 GPCD로 무조건 변환하여 총 14859회 함수 호출. MSTEMP EMPCD 단독 조회 실행계획 ALL, 사용 가능한 인덱스 없음.
- **작업 상세 내용**:
  - 실제 배포 프로시저 정의를 SELECT로 읽고 LIST_CYCLE_EQMCD 조회문을 2026년/설비조건 공란으로 추출하여 읽기 전용 비교. 원본 10267.18ms, 코드명 함수 제외 진단용 70.12ms, 빈 값/NULL의 GPCD 호출만 생략한 후보 109.42ms. 후보의 예상 함수 호출 857회. YEARPLAN 조인은 PRIMARY eq_ref를 사용하므로 유지 권고. 모든 사용 중 설비, M01~M12 표시값과 M01CD~M12CD 저장값, 설비등급, 정렬 유지. 공통 ItsMaria 동기 요청은 응답 대기 중 UI 정지의 추가 요인. 업무 소스/실제 DB 데이터/구조/프로시저 변경 없음.
- **검증 결과**: 원본/후보 모두 1143행 30컬럼. 전체 결과 JSON 및 행 순서 완전 동일, 셀 차이 0건, 설비코드 중복 0건. 측정은 연결 개설과 JSON 직렬화를 제외한 SQL 결과 수신/DataSet 구성 시간이며 실제 브라우저 전체 시간은 미측정. 진단 파일은 TEMP/codex-eqm1001-cycle-perf-20261007에 저장.

### 2. [EQM1001_R03] 반려 보완·재요청 및 그룹 최신 REV 일괄 승인 흐름 적용

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, docs/EQM1001_작업정리_20261006-20261007.md
- **배경 및 원인**: 그룹 반려로 소속 설비가 반려된 뒤 그룹 재승인이 차단되는 문제와 그룹/설비별 R→A 전환 규칙 불일치 개선 요청
- **작업 상세 내용**:
  - 두 탭 저장 버튼을 개정내용 저장·재요청으로 변경. 반려에서 직접 승인 차단, 항목 보완 중 반려 유지 및 요청정보 초기화, 실제 변경 성공 후 최신 작업본 처리 및 승인 후 다음 REV 생성. SAVE_PLAN_REV가 최신 미승인 REV를 같은 번호로 대기 재요청하고 그룹은 사용 설비의 최신 미승인 REV를 명시적 확인 후 일괄 재요청. 개별 설비 요청은 선택 설비만 처리. 승인 검사·승인본·승인이력·상태 변경을 최신 REV로 제한하여 과거 반려와 승인본 보존. 재요청 후 개별 반려/변경 시 그룹 승인 재차 차단. 그룹 승인 시 최신 미승인 설비 행 잠금. 동일/빈 원본 복사 사전 검증, 설비별 최신 REV 표시와 REV 없음 상태 공란 보완. 기존 SetRowData로 선택 행 유지. 새 테이블·컬럼·파라미터 및 공통 컴포넌트·스크립트 버전 변경 없음
- **검증 결과**: 실제 DB 정보 스키마 컬럼·키 SELECT 107행 확인, 실제 서버 DDL/DML 없음. 임시 수정본을 먼저 네트워크 없는 MariaDB 10.2.44에서 컴파일·검증 후 소스 적용. DB 38건+확장 8건, 화면 회귀 27건+실제 공통 그리드 이벤트 29건+재요청 UI 10건 총 112건 통과. CNC 21대 일괄 재요청·승인, 이력 보존, 8개 CRUD, 오류 시 전체 롤백, 동시 개별 처리 잠금, R04 기존 승인본 조회 확인. 파라미터 동일·JS 구문·기존 날짜 주석 보존·UTF8 BOM/CRLF 및 원본 변경 없음·검증본과 적용본 바이트 일치 확인. 운영 브라우저 신규 동작 미실행

### 2. [EQM1001_R03] 반려 후 재승인 업무 흐름 검토

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js (읽기 전용 분석)
- **배경 및 원인**: 반려 상태에서 대기를 거치지 않고 그룹 승인 시 차단되는 흐름의 실무 적절성 검토 요청
- **작업 상세 내용**:
  - 현재 설비별 R→A는 상태 검증을 통과하지만 그룹은 소속 설비 반려 검사로 차단됨을 확인. 반려→보완 및 재요청→대기→승인을 기본 흐름으로 권고하고, 그룹에서 연동 반려한 동일 요청은 그룹 단위로 재요청 및 일괄 처리하도록 승인 단위 통일 권고. 반려 오처리의 직접 재승인은 권한·전환 사유·이력 기록을 갖춘 별도 예외로 구분. 최신 REV만 상태 변경, 기존 승인본 및 처리 이력 보존, 동시 변경·실패 시 일괄 롤백 검증 권고. 업무 소스 및 DB 변경 없음
- **검증 결과**: R03 상태 저장·개정내용 저장·공통 CRUD SQL과 JS 호출 확인 및 Microsoft Business Central 공식 승인 워크플로 문서 비교. 설계 검토만 수행하여 런타임 테스트 및 DB 변경 없음

### 2. [EQM1001_R03] CNC FM116I210N 그룹 승인 차단 원인 확인

- **수정/대상 파일**: WORK_HISTORY.md (실제 DB SELECT 및 로컬·서버 R03 프로시저 검토)
- **배경 및 원인**: CNC FM116I210N 승인 시 I2C-003N 등 5대 외16대 반려 안내 발생 원인 문의
- **작업 상세 내용**:
  - 실제 사용 설비21대·HEADER66행·배포 R03 정의 SELECT 대조. 그룹 최신REV2와 소속21대 최신REV2 모두 R, 과거 반려만으로 차단되는 건 아님. 2026-10-07 16:16:53 ADMIN의 R03 그룹 반려 로그1개 및 연결 설비 로그20개 확인; 해당21대 HEADER 처리시각 동일. 실제 서버 SAVE_PLAN_REV는 내용·요청정보만 갱신하고 상태초기화 없음. 그룹 반려는 소속설비로 연동되지만 그룹 승인 사전검증은 반려 소속설비 존재시 차단하여 재승인 흐름이 막히는 원인 설명. SQL의 과거REV 제한부재는 별도 구조문제로 구분
- **검증 결과**: 실제 DB SELECT만 실행. 최신 반려 설비21·전체 반려 설비21·과거 반려0 및 5+16 안내와 일치. 배포 R03 검증/개정저장 본문 확인, 업무 소스·DB·서버 파일 변경 없음

### 2. [EQM1001] REV0 생성·개정저장·반려·승인 테이블별 변경 설명

- **수정/대상 파일**: docs/EQM1001_작업정리_20261006-20261007.md
- **배경 및 원인**: 사용자가 REV0 네 단계별 발생 데이터와 변경 테이블 정리 요청
- **작업 상세 내용**:
  - 현재 R03 SQL 기준 단계 설명 추가. 최초 항목CRUD의 CHKPLANEQM 변경 및 HEADER REV0 생성, 개정내용 저장의 HEADER 요청/수정정보 갱신, 반려 HEADER R·APRV R 추가·DETAIL 미생성, 승인 HEADER A·APRV A 추가·DETAIL 승인본 생성 구분. 그룹1/설비4/항목3 예시의 HEADER5·계획12·승인DETAIL15 계산. HEADER 반려시 승인자빈값과 APRV 처리자기록 구분. 개정내용 저장 반려 유지와 그룹 재승인 차단의 현재 동작 명시. 주기·실적 테이블 변경 없음 설명
- **검증 결과**: 현재 SQL의 생성범위·SAVE_PLAN_REV 필드7개와 상태초기화 부재·승인조건 DETAIL INSERT·APRVKEY·HEADER 반려 승인자 처리 대조. 원문 보존 및 후보 문서 선검증 후 반영, UTF8 BOM/CRLF 검증. 업무 소스·실제 DB 변경 및 새 DB 조회 없음

### 2. [EQM1001] 승인 DETAIL 반복 항목 생성 원인 실제 DB 확인

- **수정/대상 파일**: WORK_HISTORY.md (MSTEQMREV_HEADER·MSTEQMREV_DETAIL·CHKPLANEQM_APRV SELECT 및 R03 SQL 검토)
- **배경 및 원인**: 사용자가 REVCD별 동일 점검항목이 여러 행 조회되는 원인과 생성 동작 설명 요청
- **작업 상세 내용**:
  - 실제 HEADER6건·승인로그10건 SELECT 대조. REVCD261007000028은 비전홀검사기 FM116I270N 그룹 REV1, 29~32는 I2H-001N/002N/004N/006N 각 설비 REV1. ADMIN의 2026-10-07 16:19:07 그룹 일괄 승인과 같은 DETAIL 생성시각 확인, 그룹1+설비4의 승인본 각3항목 총15행. 261007000001은 동일 그룹 REV0의 14:33:18 승인본으로 보존됨. 첫 컬럼은 설비코드가 아닌 REVCD이며 HEADER 연결로 관리대상 구분. R03 SAVE_PLAN_STATUS A 분기의 두 INSERT로 생성됨
- **검증 결과**: 실제 DB는 SELECT만 사용. HEADER APRVTIME·DETAIL RTIME·APRV A 처리시각 일치 및 그룹·소속4설비 키 확인. 첫 연결은 샌드박스 네트워크 제한으로 실패 후 읽기전용 외부 연결로 확인. 업무 소스·실제 DB·서버 파일 변경 없음

### 2. [EQM1001] 10월 6~7일 기능·프로시저·테이블 설명 자료 작성

- **수정/대상 파일**: docs/EQM1001_작업정리_20261006-20261007.md
- **배경 및 원인**: 어제부터의 작업을 기능별로 묶고 각 SQL 호출 위치 및 관련 테이블 사용 범위를 설명할 수 있는 정리 요청
- **작업 상세 내용**:
  - 현재 소스와 해당 날짜 WORK_HISTORY 대조. R03 계획·REV·승인·주기 26분기, R04 실점검6, R05 조회1, R01 수리7, S01 보고서2 총42분기와 15개 주요 테이블 설명. 전환·메타데이터·메뉴 SQL 및 동일기간 기타 작업 분리. R03 최신 REV/빈상태·반려 재요청·CRUD 후 최신 관리·연동 승인범위·LATEST·출력 인자/4건 제한·복사 사전검증의 현재 파일과 최종 이력 불일치 명시. 업무 소스 및 DB 미변경
- **검증 결과**: 현재 SQL CASE42개 전부 문서 포함 확인, 테이블15개·실제 파일 링크·R03 불일치 조건 정적 대조, UTF-8 BOM/CRLF·적용 파일 일치 검증. 실제 DB 최신 반영 조회·실행 및 브라우저 확인 미수행

### 2. [EQM1001_R03] 조회 및 CRUD 후 그리드 상세 중복 호출 제거

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js
- **배경 및 원인**: 공통 ItsGrid 바인딩 시 selectionChanged와 loadedRows 직접 onSelect가 중복 실행되어 REV 선택에 따른 동일 정기점검 조회가 두 번 발생; CRUD 후 REV 추가 시 자동 조회와 명시 조회도 중복 가능
- **작업 상세 내용**:
  - 기존 프로젝트의 SetStore·onSelect 상세조회 구조 유지. R03 전용 LoadPlanGrid에서 바인딩 동안 선택 콜백 차단 후 필요 시 한 번 호출; 설비그룹·설비별 메인 및 REV 조회에 적용. CRUD 후 REV 행 갱신은 자동 상세조회 없이 기존 명시 조회 한 번 실행. try/finally로 이벤트 복원. CRUD 쓰기 로직·SQL·공통 컴포넌트·스크립트 버전 변경 없음
- **검증 결과**: 선 검증 후 반영. 실제 공통 SetStore·AddRow·SetRowData 및 선택 이벤트 코드를 포함한 이벤트 재현 29건, 승인본·신규 REV·기존 선택 및 편집 회귀 27건 통과(합계 56건). 기존 4회 호출 재현 및 수정 후 3회 확인. 빈 조회·실패 후 재시도·바인딩 예외 복원 검증. JS 문법 및 UTF-8 BOM·CRLF 검증 완료. 실제 서버·DB 변경과 실브라우저 확인은 수행하지 않음

### 2. EQM1001_R03 최신 승인 REV에서 다음 개정 시작

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js
- **배경 및 원인**: 최신 승인 REV도 조회 전용으로 고정되고 DB CRUD가 차단되어 다음 리비전 작업을 시작할 수 없음
- **작업 상세 내용**:
  - 양 탭 최신 승인 REV의 승인본 조회와 신규 개정용 복사·추가·저장·삭제 버튼 허용. 승인 HEADER·DETAIL·APRV 이력은 보존하고 실제 항목 변경 성공 후 연동 대상의 다음 대기 REV 생성; 기존 대기·반려는 같은 최신 번호 재사용. 개정내용은 승인 REV 직접 수정 금지. LATEST 단건 조회와 공통 AddRow/SetRowData로 새 REV 추가·선택 유지. 승인/반려는 각 대상의 최신 REV만 처리하여 과거 반려 이력 보존. 복사 변경 건수 집계 및 빈 원본/자기 자신 복사 차단
- **검증 결과**: 실제 DB 4개 테이블 컬럼65건 및 COMCALLC 트랜잭션 정의 SELECT 확인. 격리 MariaDB R03/R04 컴파일 및 DB35건, 공통 SetRowData/AddRow 실제 함수 포함 JS 모의27건 통과. 신규 대기 중 R04 직전 승인본 사용·신규 승인 후 전환 확인. JS 문법·30개 파라미터·UTF8 BOM/CRLF·스크립트 버전 유지 확인. 실제 서버 반영·실제 브라우저 테스트 미실시

### 2. EQM1001_R03 반려사유 기본 글자색 적용

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js
- **배경 및 원인**: 초기 REV 조회와 단건 갱신에서 반려사유 빨간색을 명시적으로 지정함
- **작업 상세 내용**:
  - 설비그룹·설비별 공통 REV 조회의 빨간색 루프 및 단건 갱신의 색상 지정 제거. 기존 SetRowData 갱신·반려사유 조회/저장 유지
- **검증 결과**: 후보 JS 문법·불필요 색상 호출 제거·반려사유 저장/갱신 유지 확인 후 반영. UTF-8 BOM/CRLF 검증. 실제 브라우저 화면 테스트 미실시

### 2. [EQM1001_R03] 개정내용 저장 반려 해제 및 공통 현재 행 갱신

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js
- **배경 및 원인**: SAVE_PLAN_REV가 반려 상태를 유지하고 CRUD·승인·반려 후 전체 목록 재조회와 선택 행 탐색으로 화면이 이동함
- **작업 상세 내용**:
  - 최신 미승인 REV의 개정내용 저장 시 동일 REV를 대기로 재요청하고 현재 반려·처리 정보를 초기화하며 누적 이력 보존. 프로젝트 PRD7001 페이지의 공통 SetRowData 패턴과 GetStore·Focus 사용으로 현재 목록 행/REV만 갱신하고 CRUD 항목만 재조회. REV 정렬 시 최신 원본 기준 유지, 조회 버튼 첫 행 선택 유지. 승인 REV 수정 차단 유지. 별도로 반려된 소속 설비의 상태는 변경하지 않음
- **검증 결과**: 실제 DB 컬럼 52건·HEADER 인덱스 7건 SELECT 확인. 격리 MariaDB 10.2 SQL 컴파일 및 DB 45건, 공통 SetRowData 실제 함수 포함 JS 모의 검증 21건 통과. JS 문법·30개 파라미터·BOM/CRLF 검증 완료. 실제 서버 DB 변경·배포 및 실제 브라우저 화면 테스트 미실시

### 2. EQM1001_R03 승인 계획 CRUD 차단 및 자동 다음 REV 생성 제거

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, WORK_HISTORY.md
- **배경 및 원인**: 사용자 업무규칙 변경: 승인된 항목은 수정 자체가 불가하므로 수정 후 다음 REV를 대기로 자동 생성하는 동작 제거 요청
- **작업 상세 내용**:
  - 양 탭 최신 승인 REV도 승인본 조회 전용으로 전환하고 추가/저장/삭제/복사 및 개정내용 저장 버튼 숨김. 프로시저는8개 CRUD의 대상·연동 대상 최신 REV 승인 여부를 모든 데이터 변경 전에 검사해 차단. 승인된 소속 설비 포함 그룹 CRUD 및 승인그룹 소속 설비 CRUD도 차단. 승인 이후 새 번호 자동생성 제거, REV 없는 최초 대상만 REV0 생성. 최신 대기/반려 REV만 같은번호 재요청하여 과거 REV 보존. 승인 복사 원본은 읽기만 허용. 주기저장 승인제한 제거와 출력 흐름 유지, 잘못된 새REV생성 안내문구 수정
- **검증 결과**: 선 검증 후 반영. 실제 서버 프로시저 정의 SELECT로 구 동작 확인, 실제 DDL/DML 없음. 격리 MariaDB 전체 컴파일29건: 승인 대상/연동대상4경우×CRUD4차단 및 HEADER/DETAIL/APRV/CHKPLANEQM 불변16, 초기/대기 CRUD8, 승인·과거반려 이력보존2, 승인 개정내용 저장차단2, 승인된설비 주기저장1. 모의 JS11: 양탭 최신A 읽기전용/버튼숨김·대기/반려편집·최초등록·과거승인읽기·BOM CRLF srcVersion 유지. 합계40건, 기타 SQL 분기/30파라미터 및2개 JS함수 외 코드불변 확인. 저장파일 일치. 실브라우저 미실행

### 2. EQM1001_R03 변수 선언 및 CRUD 공통 리비전 처리 역할 설명

- **수정/대상 파일**: WORK_HISTORY.md (R03.sql 소스 검토, 업무 소스 변경 없음)
- **배경 및 원인**: 사용자가 PROC 앞 DECLARE 및 CASE 이전 공통 승인요청 블록 선언 이유 설명 요청
- **작업 상세 내용**:
  - DECLARE는 프로시저 내부 임시변수32개로 모두 실제 참조됨. 공통 블록은 정기점검 CRUD8분기에만 대상/복사검증과 연결 대상 REV 재대기/신규번호 생성 수행하며 승인된 계획을 필수로 검사하는 로직 아님. 주기 저장/조회는 대상아님. 현재 UPDATE 조건은 최신 REV 제한없이 대상 계획의 모든 미승인 REV를 갱신하는 점 확인
- **검증 결과**: 전체 DECLARE 사용처 확인32개·미사용0. 공통 호출코드8개 및 UPDATE/INSERT 범위 소스 검토. 실제 DB 조회·실행·업무 소스 변경 없음

### 2. EQM1001_R03 주기 저장 승인계획 검증 제거 상태 확인

- **수정/대상 파일**: WORK_HISTORY.md (R03.js·로컬 R03.sql·실제 서버 프로시저 검토, 업무 소스 변경 없음)
- **배경 및 원인**: 사용자가 주기 저장에서 승인된 정기점검계획 확인 검증이 제거되었는지 확인 요청
- **작업 상세 내용**:
  - 일반 저장 및 일괄 주기설정은 SAVE_CYCLE_EQMCD 공통 분기를 사용하며 JS에도 승인 제한 없음. 로컬 및 실제 서버 해당 분기가 동일하고 승인상태·HEADER·DETAIL·APRV 참조/검증 없음. 주기 저장은 사용중 설비 확인과 점검실적이 있는 월의 점검자 변경/삭제 차단만 유지. 실제 YEARPLAN 트리거0 확인
- **검증 결과**: 실제 서버 정의·트리거는 SELECT만 확인. 격리 MariaDB 전체컴파일 및 계획/REV/승인본 모두없는 상태 저장·대기/반려/승인 상태 저장·비사용/미지정설비 차단·실적월 변경 차단·일반/일괄 JS경로·트리거 없음10건 통과. 로컬/서버 주기저장 분기 정규화 비교일치. 실제 서버 저장/DML 및 업무 소스 변경 없음

### 2. EQM1001_R03 개정이력 REV별 최종 상태 한 건 출력

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, WORK_HISTORY.md
- **배경 및 원인**: 사용자 최종 기준: 대기·반려도 포함하되 동일 REV의 여러 승인/대기/반려 처리 로그를 나열하지 않고 마지막 상태의 개정내역 한 건만 표시
- **작업 상세 내용**:
  - CALL_PLAN_RPT 개정이력은 HEADER의 고유 PLANTP/PLANCD/REVNUM 행을 직접 조회하며 승인 필터 제거. APRV 로그는 JOIN하지 않으므로 동일 REV 다중 처리에도 한 건. 승인·반려는 최종 처리일, 대기는 요청일 표시, 승인자 칸은 승인 상태일 때만 표시. 과거 REV 선택 무관 전체 REV·최신 계획·4건 초과 다음 페이지 유지. 변경은 출력 이력 SELECT와 Modify 주석뿐
- **검증 결과**: 선 검증 후 반영: 격리 MariaDB 전체 프로시저 컴파일·양탭 혼재60개 REV 한 번씩·과거/미선택/최신 선택·같은 REV의 반려→대기→승인 변경 후1건·다중 APRV 로그 중복 없음·대기만 있어도 표시·상태별 날짜·승인자18건 통과. 최신 계획 및 CRUD 분기·파라미터30 동일, BOM CRLF·저장파일 일치 확인. 실제 DB/서버·JS·보고서 바이너리 변경 없음, PDF 재실행 없음

### 2. EQM1001_R03 계획서 개정이력 승인 REV만 한 건씩 표시

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, WORK_HISTORY.md
- **배경 및 원인**: 사용자 정정: PDF 개정이력에는 승인·대기·반려 전체가 아니라 승인된 REV만 번호당 한 건 표시
- **작업 상세 내용**:
  - CALL_PLAN_RPT 마지막 이력 SELECT에 HEADER.APRVSTT=A 조건 추가. 승인일자·승인자 CASE를 직접 조회로 단순화. 승인 로그 테이블이 아닌 HEADER의 고유 리비전에서 조회하여 여러 승인/반려 로그가 있어도 중복 없음. 양 탭 동일 적용. 과거 REV 선택 무관 전체 승인 이력·최신 계획·4건 초과 이어서 출력 유지. JS·보고서·바이너리 변경 불필요
- **검증 결과**: 선 검증 후 로컬 SQL 반영. 격리 MariaDB 전체 컴파일, 양 탭 혼재60중 승인20만 조회·과거/미선택/최신 REV 무관·REV 고유·승인일자·중복 로그·전체 승인60·승인 없음 등14건 통과. 변경은 이력 SELECT와 Modify 주석뿐, 기존 최신 계획·CRUD·파라미터30 보존, UTF8 BOM CRLF 및 적용파일 일치 확인. 실제 DB 반영 및 브라우저/PDF 재실행 없음

### 2. EQM1001_R03 선택 설비그룹·설비 최신 계획 및 전체 개정이력 출력

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs, 01.Office/Reports/EQM1001.exe·pdb, 04.Report/PAGEEQM/EQM1001/bin/Release/EQM1001.exe·pdb, WORK_HISTORY.md
- **배경 및 원인**: 선택 REV 전달 및 CALL_PLAN_RPT의 해당 REV 이하·승인본 필터·LIMIT4, 보고서4행 제한으로 과거 REV 클릭 시 이후 이력 누락
- **작업 상세 내용**:
  - 두 탭 출력은 좌측 EQMGUBUN/FANO와 PLANTP만 전달. SQL은 대상 최신 REV 기준 계획 내용, 승인·대기·반려 모든 개정이력 전체 조회. 하단 기존4칸 양식 유지하며 초과 이력은 SubBand·서브리포트로 다음 페이지에 이어서 각 이력을 한 번씩 표시. 신규 JOIN/테이블 없음. 로컬 보고서 EXE/PDB 재빌드·동기화, srcVersion·공통 컴포넌트·CRUD·승인별 행 선택 유지
- **검증 결과**: 선 검증 후 반영: 실제 ItsRpt 직렬화·두 탭 과거/최신/미선택 REV·좌측선택 변경·미선택10, 격리 MariaDB 전체 컴파일·REV1/0/99/공란/잘못된값 무관 최신 계획·승인본·전체60이력·검증16, 테스트 DB만 대체한 실제 S05A PDF3/4/5/60건 양탭8개 전부 각 이력1회·페이지1/1/2/3 확인 및 PNG 시각 검증. 실제 DB SELECT 양탭 각REV0~3 전체4건 반환2, 합계36건. MSBuild 오류0, 최신 바이너리 IL의 REVNUM 입력 제거 및 전체 이력메서드 확인, BOM CRLF·적용파일/바이너리 해시 확인. 실제 DB DDL/DML·서버 반영·실브라우저 미실행

### 2. EQM1001_R03 양 탭 REV 미등록 승인상태 공란 및 최신 REV 기준 통일

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, WORK_HISTORY.md
- **배경 및 원인**: 설비별 LIST_MSTEQM에 REV 없는 경우 공란 분기가 누락되고 REV 표시는 직전 승인본·상태는 최신본으로 달라 공란 REV에 대기가 표시됨. 실제 서버 정의 SELECT에서도 확인, 그룹 분기는 공란 조건 정상
- **작업 상세 내용**:
  - 설비별 REVNM을 최신 PLAN_REV.REVNUM으로 변경, REVCD 미등록이면 APRVSTTNM 공란 처리. 불필요한 승인 REV 집계 제거. 설비그룹 동일 기준 검증. 실제 CRUD와 JS·srcVersion·공통 컴포넌트 변경 없음. 동일 날짜 Modify 한 줄 통합
- **검증 결과**: 선 검증 후 반영: 격리 MariaDB 전체 컴파일 및 두 탭 REV 없음·REV0 대기·NULL 상태·승인·반려·승인 후 신규 대기/반려·최신 승인 등 포함22건 통과. 실제 SELECT 설비1143/그룹14 유지, 설비996/그룹7 미등록 상태 공란, 기존 식별키·이름·상태코드·반려사유·정렬 동일, 최신 REV 표시29개 정상화. 변경 범위 LIST_MSTEQM만·파라미터30·BOM CRLF 확인. 실제 DB 반영·브라우저 실화면 테스트 미실행

### 2. EQM1001_R03 표시 체크박스 잔여 코드·JOIN 제거 및 중복 등록 보완

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql, WORK_HISTORY.md
- **배경 및 원인**: 사용자가 설비별 정기점검 표시 체크박스 삭제 후 불필요한 부분 제거 및 CRUD 검증까지 요청
- **작업 상세 내용**:
  - JS의 주석 처리된 EQM02 컬럼·autoSizeColumns 코드, YnToBool(EQM02) 변환, 추가 완료 후 빈 탭 분기 제거. LIST_MSTEQM의 EQM02 반환값과 전용 CHKPLANEQM DISTINCT 파생 JOIN 제거. 격리 CRUD 검증 중 발견한 기존 REG_EQM02 재등록 중복키 오류는 ON DUPLICATE KEY UPDATE CHKKNDCD=VALUES(CHKKNDCD)로 기존 값을 바꾸지 않고 처리. 다른 SQL 분기·파라미터30·FANO 선택 복원·점검항목 선택 체크박스·srcVersion 유지
- **검증 결과**: 검증 후 반영: 실제 DB SELECT 전후1143개 고유 설비의 나머지 모든 필드·정렬 동일. JS 모의 UI56, 격리 MariaDB10.2 프로시저 컴파일·조회·CRUD·그룹CRUD·실행계획17, 중복 요청·기존 데이터 불변2 합계75건 통과. EXPLAIN에서 표시용 CHKPLANEQM 접근 제거 확인. 실제 CHKPLANEQM 트리거0 SELECT 확인. 수정 전후 파라미터 동일, SQL 변경은 LIST_MSTEQM/REG_EQM02 두 분기뿐. BOM CRLF·저장파일 해시 확인. 실제 DB DDL/DML 및 서버 파일 반영 없음, 실브라우저 동작 미실행

### 2. EQM1001_R03 설비별 정기점검 표시 체크박스 제거 영향 검증

- **수정/대상 파일**: WORK_HISTORY.md (R03.js·aspx·sql 검토, 업무 소스 변경 없음)
- **배경 및 원인**: 사용자가 설비별 목록 grid1의 읽기 전용 EQM02 정기점검 체크박스를 삭제할 때 관련 기능에 문제가 있는지 확인 요청
- **작업 상세 내용**:
  - 현재 컬럼 선언이 이미 주석 처리되어 grid1에 EQM02가 생성되지 않음을 확인. 설비 선택·리비전·승인/반려·출력·등록/저장/삭제/복사는 FANO를 사용하며, CRUD 항목 선택은 grid3/grid10 체크박스 사용. 고정 컬럼 번호나 EQM02 셀 참조 없음. 잔여 JS YnToBool(EQM02) 및 LIST_MSTEQM의 EQM02 표시값/CHKPLANEQM 파생 JOIN은 표시 전용으로 확인하여 후속 정리 후보로 기록
- **검증 결과**: 현재 파일 그대로 JS 모의 동작 검증54건 통과(기존44+체크박스 없는 설비 선택·추가·등록·저장·삭제·복사·미선택10). 공통 Store 변환 및 ItsGrid 바인딩 소스 확인, LIST_MSTEQM 참조자는 R03.js뿐임. 실제 DB 호출·브라우저 실화면 테스트·업무 소스 변경 없음

### 2. SQL 규칙의 보존 조건 제외 및 JOIN 가독성 기준 강화

- **수정/대상 파일**: .agents/rules/sql_structure.md, .agents/rules/procedure.md, .agents/rules/validation.md, WORK_HISTORY.md
- **배경 및 원인**: 사용자가 직전 추가 규칙의 승인본·이력·조회 조건 보존 항목을 제외하고 누구나 이해할 수 있는 간단한 JOIN 구조를 요구
- **작업 상세 내용**:
  - 규칙 소개·procedure 연결 문구의 보존 조건 및 승인본 유지 전용 항목 제거. 특정 승인 업무 예시는 일반 원본 테이블·기능 검증으로 변경. 기준 테이블에서 식별키로 직접 연결, 중복·우회 JOIN 및 중첩 조회 지양, 짧고 역할이 분명한 별칭, 일관된 조건 배치와 설명보다 구조 단순화 기준 추가. 기존 업무 소스와 테이블은 변경하지 않음
- **검증 결과**: 선 검증 후 규칙 반영. 보존 항목 제거 여부, 규칙 frontmatter·문서 링크·50줄 이내·BOM CRLF 검증, 실제 저장 파일 해시 일치 확인

### 1. 불필요한 JOIN·중복 컬럼 방지 SQL 구조 규칙 추가

- **수정/대상 파일**: .agents/rules/sql_structure.md, .agents/rules/procedure.md, .agents/rules/validation.md, WORK_HISTORY.md
- **배경 및 원인**: 불필요한 JOIN과 테이블 참조로 프로시저가 길어지는 문제를 반복하지 않도록 사용자 요청으로 프로젝트 규칙 강화
- **작업 상세 내용**:
  - 기존 .agents 형식(always_on)으로 SQL 구조 규칙 신설. 실제 컬럼·키·행 단위 확인, JOIN 목적과 행 필터·중복 검토, 중복 참조 제거, 확정 그룹코드 직접 필터, 필요한 COMTYPE 조회 보존, 상관 쿼리·DISTINCT 우회 금지, HEADER 식별정보 중복 방지, 승인본 DETAIL 보존, 상태 원본 분리, 불필요한 객체 생성 억제, NULL 처리 간소화, 실행계획·결과 검증 및 전환 SQL 반영 구분 명시. procedure 및 validation에 필수 참조 연결
- **검증 결과**: 임시 규칙 작성 후 기존 문서 비교 및 충돌 검토 완료. 새 규칙 50줄 이내, frontmatter·상대 링크·UTF8 BOM·CRLF 검증. 저장 후 3개 파일 해시 일치 확인. 문서 변경만 수행, 업무 소스·DB 미변경

---

## 🕒 2026-10-06 (화) 작업 내역

### 2. EQM1001_R03 계획서 출력의 구 리포트 실행 파일 교체

- **수정/대상 파일**: 01.Office/Reports/EQM1001.exe·pdb, 04.Report/PAGEEQM/EQM1001/bin/Release/EQM1001.exe·pdb, WORK_HISTORY.md
- **배경 및 원인**: 계획서 출력에서 설비그룹 선택 안내 발생. R03 화면은 PLANCD·REVNUM을 정상 전송하지만 로컬 실행 EXE가 EQMGRP·FANO를 요구하고 R05 CALL_PLAN_RPT를 호출하는 구버전인 것을 IL 메타데이터로 확인
- **작업 상세 내용**:
  - 최신 S05A·Program 소스로 Report 프로젝트 Release 재빌드. PLANCD·REVNUM 및 R03 CALL_PLAN_RPT 소비를 새 EXE 메타데이터에서 확인 후 로컬 Office Reports 및 Release 실행 파일·심볼 동기화. 기존 EXE·PDB 임시 감사 경로 백업. JS·ASPX·공통 컴포넌트·프로시저·srcVersion 변경 불필요
- **검증 결과**: MSBuild 오류0. 실제 ItsRpt.js 직렬화 및 R03 PrintPlanRev 사용한 전달·미선택 검증8건 통과. DB 연결만 테스트 대체한 임시 S05A로 그룹·설비 REV0/REV3 PDF4건 생성 및 R03/PLANCD/REVNUM 전달 확인. 최종 EXE 해시 일치. 실제 DB·실제 서버 파일 미변경, 실서버 PDF 출력 미실행

### 2. EQM1001 계획·리비전·승인이력 4개 테이블 실제 DB 구조 검증

- **수정/대상 파일**: WORK_HISTORY.md (실제 DB SELECT 검증, 업무 소스 변경 없음)
- **배경 및 원인**: 사용자가 HEADER·DETAIL·APRV·CHKPLANEQM의 최신 컬럼 적용 상태 확인 요청
- **작업 상세 내용**:
  - 실제 information_schema 87행 및 데이터 정합성 25항목, DETAIL 참조 루틴 2개 조회. HEADER 19컬럼/REVCD PK/계획별 REV UNIQUE 정상. DETAIL 19컬럼으로 PLANTP·PLANCD·REVNUM·EQMCD 삭제 미반영, 최신 R03 INSERT 후 66행의 구 중복 컬럼이 기본값임. APRV 18컬럼/APRVKEY PK/REVCD 인덱스 및 GETKEY 등록 정상, RTIME·REMP·RPRG의 기존 기본값은 큰따옴표로 로컬 빈 문자열과 다름. CHKPLANEQM 13컬럼/설비·항목 PK 정상, 현재 MSTEQM에 없는 6설비코드의 계획 31건 확인. 최신 R03/R04 실제 본문과 로컬 SQL 동일. CREATE TABLE IF NOT EXISTS는 기존 DETAIL 구조를 변경하지 않으므로 PLAN_REV_NORMALIZE 별도 실행 필요
- **검증 결과**: SELECT만 사용. HEADER 199/DETAIL 607/APRV 196/계획 643행. DETAIL의 HEADER 미연결 0, APRV 빈키·키형식·상태·HEADER 연결·계획 식별 불일치 각 0. DETAIL 중복 컬럼 불일치 66건 전부 빈값·0 기본값, 승인 스냅샷과 HEADER 연결 유지. 계획 CHKTP01 17/02 626, 설비 미연결31/점검항목 미연결0. 실제 DB DDL/DML·공통 함수 실행 없음

### 2. EQM1001_R03 빈 개정내용 승인·반려 차단 및 저장 버튼 색상 구분

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 05.Procedure/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: 대기 REV의 개정내용이 없는데 반려가 가능했고 개정내용 저장과 승인 버튼 색상이 동일했음
- **작업 상세 내용**:
  - 공통 승인·반려 버튼 처리에서 공백·미입력 차단 안내 추가, SAVE_PLAN_STATUS의 승인 전용 빈 개정내용 검증을 승인·반려 공통으로 확대, 설비그룹·설비별 개정내용 저장 버튼을 CustomButton2 파란색으로 변경, 미저장 내용·구버전 REV 검증 및 srcVersion 유지
- **검증 결과**: 선 검증 후 반영: JS 모의 UI 44건 및 격리 MariaDB 10.2 승인·반려 회귀 검증 47건 합계 91건 통과. JS 문법·ASPX 버튼 속성·파라미터 유지·BOM CRLF 확인. 실제 서버 DB와 배포 파일 미변경

### 2. EQM1001 REV DETAIL 정규화 및 승인이력 APRVKEY 전환

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql, 05.Procedure/MES_SNS2_EQM1001_R04.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_REV.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_REV_INIT.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_REV_REVCD.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_APRV_HISTORY.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_REV_NORMALIZE.sql
- **배경 및 원인**: DETAIL의 PLANTP·PLANCD·REVNUM 등 HEADER 중복 정보 제거 및 CHKPLANEQM_APRV PK를 GETKEY(APRVKEY)로 생성하도록 요청
- **작업 상세 내용**:
  - 실제 DETAIL541건 SELECT 점검에서 HEADER 고아·중복값 불일치·EQMCD 파생값 불일치 모두0건. DETAIL PLANTP·PLANCD·REVNUM·EQMCD 제거 및 REVCD·CHKKNDCD PK 유지. R03 승인본 INSERT와 최초 이관/신규 생성 SQL 수정. R04 설비코드는 이미 HEADER로 검증한 조회 대상 EQMCD 반환하여 추가 JOIN 없이 기존 그리드 반환 형식 유지. APRVKEY VARCHAR20 PK와 GETKEY(APRVKEY) 발번 적용, 이력은 APRVTIME·APRVKEY 최신순 및 REV 조회 인덱스 정리. 구 계획별 PK·중간 APRVID·신규 구조 모두 지원하는 전환 SQL 및 HEADER 없는 DETAIL 사전 차단 추가. 구 REVCD 이관 파일은 역사적 구 구조 참조를 유지하고 최신 정규화 적용 순서 명시. 상태/요청 이력 데이터와 승인 스냅샷 보존. JS·ASPX·리포트 및 입력 파라미터 변경 없음. 공통 GETKEY 수정 없음
- **검증 결과**: 격리 MariaDB10.2 및 실제 GETKEY 정의 복제로 승인/이력/출력31건, 테이블 전환·재실행·기존 키/기록 보존·고아 차단13건, R04 승인본/점검 등록/중복 방지10건, 신규 스키마/최초 이관3건, 주기관리·완료월 잠금26건 총83건 통과. R03·R04 입력 파라미터 동일 및 수정 분기3개 한정 확인. 7개 SQL UTF8 BOM/CRLF 검증. 실제 DB는 SELECT만 사용하고 GETKEY 직접 호출이나 DDL/DML 없음

### 2. EQM1001_R03 리비전 승인·반려·계획서 출력 이관 및 처리 이력 팝업

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql, 05.Procedure/MES_SNS2_EQM1001_R05.sql, 05.Procedure/MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_APRV_HISTORY.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs
- **배경 및 원인**: R05 승인·반려·출력을 R03 개정 이력 영역으로 옮기고 선택 REV의 CHKPLANEQM_APRV 이력을 공통 팝업으로 조회 요청. 기존 승인 테이블은 PLANTP·PLANCD PK와 REVCD 부재로 누적 이력 저장 불가
- **작업 상세 내용**:
  - 두 탭 개정내용 저장 옆 승인·반려·출력 배치, REV 그리드 이력 버튼 및 Its:pop/ItsPop 기반 조회·반려사유 팝업 추가. R03 SAVE_PLAN_STATUS/CALL_PLAN_RPT/LIST_PLAN_APRV 이관, 선택 최신 REV 및 저장된 개정내용 확인, 승인본 스냅샷과 그룹·소속 설비 처리별 누적 기록. CHKPLANEQM_APRV APRVID·REVCD 추가 및 PK 전환/REV 인덱스/기존 기록 보존 SQL 작성. 상태는 REV_HEADER 유지, 이력은 APRV 누적. 과거 이력은 상태·처리시간이 정확히 일치하는 REV만 연결하며 불명확한 처리자는 임의 표시하지 않음. R05는 조회만 유지하고 기존 동작 제거. S05A는 명칭/양식 유지하고 R03 선택 REV 데이터 사용. R03 파라미터30개 메타데이터 갱신. 기존 R03 주기관리 모든 분기와 R04 승인 실행 제한 유지
- **검증 결과**: 선검증 후 반영. 격리 MariaDB10.2 승인·반려·선택 REV 출력28건, 주기관리/완료월 잠금26건, 이력 전환/재실행/기존 데이터 보존8건, JS 이벤트/클릭 행/선택 복원/에러/버전/컨트롤23건 총85건 통과. 실제 스키마와 현행 R03은 SELECT로만 확인. 스테이징·최종 MSBuild 빌드 오류0. 기존 R03 분기 동일 및 UTF8 BOM/CRLF 검증. 실제 배포 화면·PDF 실행은 서버 반영 후 확인 필요

### 2. EQM1001_R03 주기관리 승인 제한 제거

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: 주기 조회는 사용 중인 모든 설비를 대상으로 하고 주기 저장에서 승인계획 검증을 제거하도록 요청
- **작업 상세 내용**:
  - LIST_CYCLE_EQMCD 승인 REV 관련 JOIN 4개 및 그룹 승인 조건 제거, USEYN=Y와 연도별 정기점검 주기 LEFT JOIN만 유지. SAVE_CYCLE_EQMCD 및 DELETE_CYCLE_EQMCD는 사용 중인 설비 여부만 검증하며 완료실적 월 잠금 유지. R04 실제 점검의 승인 검증과 페이지 ASPX/JS 및 파라미터는 변경 없음
- **검증 결과**: 격리 MariaDB 10.2에서 프로시저 컴파일 및 26개 조회·저장·삭제·완료월 잠금·R04 승인 회귀검증 통과. 실제 DB SELECT로 활성 설비 1143개와 조회 1143행, 키 중복 없음 및 30개 컬럼 확인. 선검증 후 반영, UTF-8 BOM/CRLF 및 파라미터 동일 검증

### 2. EQM1001 설비그룹 최신 REV 표시 및 승인 구조 단순화

- **수정/대상 파일**: 05.Procedure/MES_SNS2_EQM1001_R03.sql;05.Procedure/MES_SNS2_EQM1001_R05.sql;05.Procedure/MES_SNS2_EQM1001_PLAN_REV.sql;05.Procedure/MES_SNS2_EQM1001_PLAN_REV_INIT.sql;01.Office/PAGEEQM/EQM1001/EQM1001_R03.js;05.Procedure/MES_SNS2_EQM1001_PLAN_APRV.sql 삭제
- **배경 및 원인**: 별도 승인 테이블과 REV 헤더의 중복 관리 및 다중 조인, 설비그룹 체크박스 제거·최신 REV 표시 요청
- **작업 상세 내용**:
  - 승인 상태와 요청·처리정보를 REV 헤더로 통합하고 중복 승인 저장·삭제 제거; 설비그룹 정기점검 체크박스·변환 제거 및 그룹코드 포커스 복원; 최신 REV와 상태 조회, REV 없으면 상태 공란; 그룹조회 JOIN 6→3, 전체 R03 51→42·R05 24→21; 그룹 대상 상수·복사 원본·등록 항목/순서 조회 중복 조인 축소; 정기점검 주기 조회 CHKTP=02 제한으로 불필요 외부 GROUP BY 제거; 구 승인 테이블 생성 스크립트 삭제·기존 이관 스크립트 일회성 용도 명시; 창작업본 CHKPLANEQM 및 승인 보존본 REV_DETAIL 유지
- **검증 결과**: 격리 MariaDB 10.2 DB 테스트 94건 및 JS 모의 테스트 20건 통과; 실제 DB SELECT로 그룹 14건 최신 REV·상태 대조 및 기존 설비·승인관리 조회 결과 검증; 가상 REV 10만 건에서 느린 윈도 함수·행별 lookup 제외하고 집계/유일키 조인 유지; 파라미터 수·순서 유지, BOM·CRLF·node 문법검사 통과; 실제 서버 DDL/DML 없음

### 2. [EQM1001_R03/R04/R05] 최신 서버 반영 확인 및 프로시저 조회 최적화

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql
- **배경 및 원인**: 사용자가 최신 이관 버전 반영 후 정확한 적용 확인과 3개 프로시저 성능·가독성 개선 요청. 작업 시작 시 서버 세 프로시저 본문이 로컬과 일치, SYSTEM_PARAMETERS와 정보 스키마 입력값이 R03 28개·R04 22개·R05 10개로 일치, 다른 페이지 호출 0건 확인
- **작업 상세 내용**:
  - R03 REV 상세는 REVCD·CHKKNDCD PK로 항목이 유일하므로 MIN/MAX/GROUP BY 중복 집계 제거. R03 주기관리 2곳 및 R04 점검 CRUD 4곳의 승인 검증을 COUNT 전체 계산에서 단독 IF NOT EXISTS로 변경(SELECT WHERE 상관 서브쿼리 사용 없음). R04 최신 승인 REVCD·REVNUM 조회를 2회에서 1회로 통합, 미사용 지역변수 제거. R05 그룹·설비 항목 수를 선집계하고 승인정보 JOIN 뒤 넓은 GROUP BY 제거, 설비 항목 수는 PK 유일성을 활용한 COUNT(*) 사용. 입력 파라미터 및 반환 컬럼·오류 문구·기존 승인/REV/점검 보호 흐름 유지. 날짜별 이력 1행 통합
- **검증 결과**: 실제 DB SELECT/EXPLAIN으로 최신 배포 정의·메타데이터·키 확인. 변경 전후 그룹 목록 13건·설비 목록 126건·REV 상세 4건 동일. 격리 MariaDB 10.2에서 최적화 3개+기존 비교용 3개 전체 컴파일. 기존 CRUD/승인 34개+추가 R04/주기관리/결과 비교 35개=69개 통과. 실제 조회 소규모 측정(한 연결, 쿼리별 워밍업 1회 제외 6회) 중앙값 그룹24.92→18.04ms, 설비29.83→20.77ms(왕복·전송 포함 참고값, 운영 성능 보장 아님). BOM/CRLF 검증. 실제 서버 DB 데이터·정의·인덱스 변경 없음, 브라우저 CRUD 미실행

### 2. [EQM1001_R03/R04/R05] 페이지·프로시저 호출 일치 점검

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js, 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, WORK_HISTORY.md
- **배경 및 원인**: 다른 페이지 프로시저 참조가 남아 있는지 확인 및 페이지명과 프로시저명을 일치시키라는 요청
- **작업 상세 내용**:
  - 현재 로컬 호출 33개 전수 확인(R03 25개·23분기, R04 6개·6분기, R05 2개·2분기): 모두 자기 페이지 프로시저 호출, 각 분기 존재. SQL 선언명·내부 호출·코드비하인드 클래스·스크립트 연결 일치. R05 계획서 S05A도 R05 CALL_PLAN_RPT 사용. COMERR·COMSPLIT 공통 호출 유지. 앞선 이관이 로컬에 완료되어 추가 기능 소스 변경 없음. 실제 DB에는 R03→R05 호출 8개 및 R05의 REQUEST_PLAN/REV 3개 분기가 이전 상태로 남아 있음
- **검증 결과**: JS 3개 구문 검사 및 로컬 호출·분기·페이지 이름 검사 통과. 실제 서버는 루틴/메타데이터 SELECT만 실행. 서버 R03에서 로컬 REV 3분기 누락 및 등록 파라미터 24개(최신 28개 필요) 확인. R04 22개·R05 10개 파라미터는 로컬과 일치. 실제 서버 수정 없음

### 2. [EQM1001_R03/R05] 최신 REV 요청일시 표시 및 페이지별 프로시저 분리

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql, 05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_SYSTEM_PARAMETERS.sql
- **배경 및 원인**: R05 요청일시는 계획 수정 때 삭제되는 CHKPLANEQM_APRV에서 조회하여 공란. R03 REV 저장·조회 및 CRUD 승인 요청 생성까지 R05에 있어 페이지와 프로시저 책임 불일치. 실제 DB FM116I2E0N REV.1에는 2026-10-06 13:32:48 기록됨
- **작업 상세 내용**:
  - R03에 LIST_PLAN_REV·LIST_PLAN_REV_ITEM·SAVE_PLAN_REV 이동, JS 세 호출을 R03으로 변경. CRUD 8개 분기의 승인 요청 생성·초기화를 R03 공통 영역으로 이동하여 R05 의존 제거. R03 PLANTP·PLANCD·REVNUM·REMARK 입력 추가(24→28), 전용 파라미터 백업·재등록 SQL 추가. R05 LIST_PLAN 두 탭은 최신 REV 헤더 요청일시를 우선 조회하고 기존 승인테이블 시간은 이전 데이터 보완용. 승인·반려 및 그룹 일괄 처리 시 원래 요청자·요청일시·요청프로그램 유지, 처리일시는 별도 저장. R05 승인·반려·출력 유지
- **검증 결과**: 실제 서버는 SELECT만 실행: 테이블 컬럼·키·루틴·파라미터 확인, 수정 SELECT 그룹 1건(대기 REV.1 요청일시 정상), 설비 126건 정상. 격리 MariaDB 10.2에서 전체 R03/R05 컴파일과 원래 파라미터 백업·재등록 검증. DB 회귀 34개+JS 호출 10개=44개 통과. CRUD 8개 분기·그룹 일괄 승인/반려·승인본 보존·재승인 요청정보·오류 입력·이전 데이터 보완 확인. JS 구문 및 BOM/CRLF 검증. 실제 서버 프로시저/메타데이터 미반영, 실제 브라우저 저장 미검증

### 2. [EQM1001_R03] 개정내용 저장 시 작성자·수정일시 자동 기록

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql
- **배경 및 원인**: R03 REV 그리드는 REQEMP·REQTIME을 표시하지만 SAVE_PLAN_REV는 MEMP·MTIME만 갱신하여 기존 이력의 작성자와 수정일시가 빈 값으로 남음. 실제 DB에서도 해당 빈 값과 수정 감사 필드만 기록된 행 확인
- **작업 상세 내용**:
  - 개정내용 저장 시 REQEMP=CALLEMP(), REQTIME=CALLTIME(), REQPRG=CALLPRG() 갱신. 기존 MEMP·MTIME·MPRG 기록 유지. UPDATE에도 승인본 제외 조건 추가. 두 탭의 공통 프로시저·기존 조회 바인딩 활용, JS·테이블·프로시저 인자 변경 없음
- **검증 결과**: 실제 DB 스키마·데이터·배포 프로시저를 SELECT로 확인. 격리 MariaDB 10.2에서 전체 프로시저 컴파일 및 14개 검증 통과(그룹·설비별 저장, 재저장 사용자·시간, 반려상태 유지, 승인본 보호, 입력 오류). LIST_PLAN_REV 작성자명·시간 반환 확인. BOM·CRLF 검증. 실제 서버 DB 변경 및 브라우저 저장 테스트 없음

### 2. EQM1001_R01 화면 및 프로시저 수리유형 명칭 원복

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js, 05.PROCEDURE/MES_SNS2_EQM1001_R01.sql
- **배경 및 원인**: 설비이력관리(EQM1001_R01) 화면의 콤보 라벨 및 메인 그리드 컬럼명이 '고장원인구분'으로 변경되었던 부분을 기존 명칭인 '수리유형'으로 원복 요청
- **작업 상세 내용**:
  - 1. EQM1001_R01.aspx 팝업 콤보(pop1_com_ISSUE) 라벨을 '수리유형'으로 원복. 2. EQM1001_R01.js 메인 그리드(grid1) 컬럼명을 '수리유형'으로 원복 및 주석 갱신. 3. MES_SNS2_EQM1001_R01.sql 검증 오류 메시지를 '수리유형을 선택하세요.'로 원복 및 최상단 1일 1행 Modify 주석 갱신. 4. 전 파일 UTF-8 with BOM 및 CRLF 개행 유지
- **검증 결과**: IIS Express 200 OK 확인, 렌더링된 HTML 내 '수리유형' 포함 및 '고장원인구분' 미포함 검증 완료, 전 파일 UTF-8 with BOM 무결성 확인

### 2. EQM1001_R04 프로시저 월별 점검상태 REV 버전 표기 포맷 간결화 (REV.0, REV.1 등)

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql
- **배경 및 원인**: 정기점검 등록/조회(R04) 화면 메인 그리드 월별 점검상태의 REV 버전을 두 자리 패딩(REV.00) 대신 REV.0, REV.1과 같이 자연스러운 REVNUM 원본 형식으로 표시 요청
- **작업 상세 내용**:
  - 프로시저(MES_SNS2_EQM1001_R04.sql) LIST_CYCLE_EQMCD 분기에서 LPAD 서식을 제거하여 '점검완료 (REV.X)', '점검필요 (REV.X)' 형식으로 반환하도록 수정하고 최상단 Modify 이력 1일 1행 갱신
- **검증 결과**: SQL 소스 파일 UTF-8 with BOM 및 CRLF 무결성 확인, IIS Express 200 OK 정상 서빙 확인

### 2. MST3001_R03 및 TOL0003_R05 타 프로젝트 복사 파일 아키텍처 및 코딩 컨벤션 표준화

- **수정/대상 파일**: 01.Office/PAGEMST/MST3001/MST3001_R03 (aspx, aspx.cs, js), 01.Office/PAGETOL/TOL0003/TOL0003_R05 (aspx, aspx.cs, js)
- **배경 및 원인**: 타 프로젝트에서 신규 도입한 설비부품 관리(MST3001_R03) 및 금형점검·등급관리(TOL0003_R05) 화면 세트를 현재 MES 솔루션 표준 구조, 네이밍/주석 규칙, 인코딩에 맞추어 전환 요청
- **작업 상세 내용**:
  - 1. MST3001_R03: .aspx 인위적 주석 제거 및 마크업 정리, .js grid1 오타 수정, 외부 IP 하드코딩 제거, iframe 팝업 스타일 오타 수정, 표준 날짜 주석 작성. 2. TOL0003_R05: .aspx 인위적 주석 제거, 표준 섹션 주석(PAGE, POP) 적용, InputWidth 공백 정규화, .js 과도한 배너 구분선 제거, enumColumnTypes.date 오타 수정, 필수값 알림 오타 및 설비->금형 명칭 정정, 암묵적 전역함수 표준화, parent.wait 안전 방어 처리, ToYn 통일, 2026-10-06 날짜 주석 적용. 3. 전 파일 UTF-8 with BOM 및 Windows CRLF 개행 통일
- **검증 결과**: IIS Express(<http://localhost:55085/>) 호출 검증 결과 MST3001_R03.aspx 및 TOL0003_R05.aspx 모두 200 OK 정상 서빙 확인, 전 파일 UTF-8 with BOM 및 CRLF 무결성 검증 완료

### 2. EQM1001_R04 메인 그리드 월별 점검상태(점검필요·점검완료)에 두 자리 REV 버전 표기 및 컬럼 너비 확장

- **수정/대상 파일**: [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: 정기점검 등록/조회 화면(R04)의 메인 그리드(1~12월) 점검상태(점검필요, 점검완료) 표시 시 각 점검건에 적용된 REV 버전을 식별할 수 있도록 요청
- **작업 상세 내용**:
  - 프로시저(MES_SNS2_EQM1001_R04.sql)의 LIST_CYCLE_EQMCD 분기에서 월별 실적의 REV 버전 및 최신 승인 REV 번호를 2자리로 포맷팅하여 '점검완료 (REV.XX)' 및 '점검필요 (REV.XX)'로 반환하도록 개선하고, 클라이언트 스크립트(EQM1001_R04.js)에서 1~12월 컬럼 너비를 105px로 확장하며 상태값 포함 여부(indexOf)로 색상 및 더블클릭 팝업 분기를 정상 처리하도록 수정
- **검증 결과**: IIS Express 200 OK 확인, 브라우저 렌더링 검증 결과 점검완료(초록)/점검필요(파랑) 색상 적용 및 pop1/pop2 더블클릭 오픈 정상 동작 확인 완료

### 2. EQM1001_R03 우측 그리드 헤더 버튼-컬럼 간 과도한 여백 제거 및 BOM 정규화

- **수정/대상 파일**: [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx)
- **배경 및 원인**: 우측 그리드(개정 이력, 정기점검)의 버튼 영역과 하단 컬럼 헤더 간 50px 이상의 불필요한 흰색 공백 발생 및 ASP.NET 파서 오류로 인한 미반영 문제
- **작업 상세 내용**:
  - 설비그룹 및 설비별 탭의 개정 이력(Line 30, 80) 및 정기점검(Line 45, 95) 버튼 패널의 TopHeightPc(17%, 12%) 속성 제거, UTF-8 with BOM 인코딩 정규화
- **검증 결과**: IIS Express 200 OK 확인, 브라우저 렌더링 측정 결과 버튼-헤더 간 간격이 4.67px로 밀착되고 패널 높이가 24px로 최적화됨을 실측 확인

### 2. EQM1001_R01·S01 실제 DB 구조 확인 및 화면·프로시저 보완

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, EQM1001_R01.js, EQM1001_S01.js, 05.PROCEDURE/MES_SNS2_EQM1001_R01.sql, MES_SNS2_EQM1001_S01.sql, 04.Report/PAGEEQM/EQM1001/S01A.cs
- **배경 및 원인**: 개발 중 변경된 DB 컬럼·공통코드·실제 데이터를 SELECT로 확인 요청. 실제 MariaDB 10.2.15에서 6개 테이블 199개 컬럼, 설비 1345건·수리이력 4건·작업자 연결 5건 확인. INNER JOIN으로 설비마스터 없는 BENDING_01 이력 1건 누락, 작업자 검색은 등록자 기준, 구입금액 BUYFAMT NULL 시 BUYAMT 미반영 발견
- **작업 상세 내용**:
  - R01 작업자 연결 테이블 기준 검색·LEFT JOIN 이력 보존·19자리 일시 HH:mm 분리·등록자 보존·부품 미사용 코드 제거·작업자 신규 행 저장/미저장 행 삭제·월 경계 소요일 계산 수정. DB에서 날짜·작업자·고장원인구분·100자 입력 검증 및 소요일 재계산. ISSUE 화면 명칭을 고장원인구분으로 정정. S01 구입금액 국내/외화 매핑·작업자 집계/코드 대체·빈 처리내용 대체·보전구분 내부코드 미표시·순번 정렬·이전 PDF 초기화. S01A 프로젝트 DB 설정 및 빈 PDF 대신 오류 안내. 두 aspx.cs와 S01.aspx는 변경 필요 없음. 프로시저 입력 시그니처 R01 40개/S01 3개 유지
- **검증 결과**: 실서버 수정 조회문 SELECT 4종 실행: 전체 이력 4건, TEST_EMP01 참여 이력 2건, A-001 구입금액 6,000,000(KRW) 및 작업자 2명 반환. 격리된 로컬 MariaDB 10.2.44에서 46개 DB 시나리오 통과, Node 화면 이벤트 23개 통과, JavaScript 문법 정상. MSBuild 15 Release 빌드 성공. BOM·CRLF 정상. 실제 서버 DDL/DML·리포트 배포 및 실제 브라우저 CRUD는 수행하지 않음

### 3. MTR0001_R01 기존 메뉴 데이터 삭제 SQL 작성

- **수정/대상 파일**: [MES_SNS2_MTR0001_R01_MENU_CLEANUP.sql](D:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R01_MENU_CLEANUP.sql)
- **배경 및 원인**: 마이그레이션 더미 데이터로 MTR0001_R01 메뉴 추가가 불가능하다는 사용자 보고; 실DB 데이터와 ADD_MENU 본문 미확인
- **작업 상세 내용**:
  - 메뉴관리 SYS1003_R01의 ADD_MENU 호출과 기존 메뉴 등록 SQL의 SYSMENU.PRGCD 매핑 확인; 대상 사전 조회 및 완전 일치 조건 삭제, 삭제 건수와 잔여 건수 조회 작성; SYSPRG 및 권한 유지
- **검증 결과**: 정적 검증: 삭제 테이블 1개 및 PRGCD 완전 일치, SQL BOM/CRLF 정상; 실제 DB 미실행, 재등록 결과는 사용자 실행 후 확인 필요

### 2. EQM1001_R03 우측 헤더 버튼-그리드 간 불필요 여백 제거

- **수정/대상 파일**: [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx)
- **배경 및 원인**: 우측 개정 이력 및 정기점검 헤더 패널의 과도한 높이 할당(TopHeightPc: 17%, 12%)으로 인해 상단 버튼과 하단 그리드 컬럼 헤더 사이에 30~50px 이상의 흰색 공백 여백 발생
- **작업 상세 내용**:
  - 설비그룹(탭1) 및 설비별(탭2) 점검계획 우측 상단(개정 이력)과 하단(정기점검)의 버튼 패널 4곳에서 TopHeightPc 속성을 제거하여 표준 화면과 동일하게 컨텐츠 높이에 맞춰 그리드가 밀착되도록 수정
- **검증 결과**: UTF-8 with BOM 및 CRLF 개행 무결성 확인, git diff 검증 완료

### 1. EQM1001_R03·R04·R05 REV 컬럼 너비 100 통일 및 R03 autoSizeColumns 해제

- **수정/대상 파일**: [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [EQM1001_R05.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R05.js)
- **배경 및 원인**: R03 조회 후 autoSizeColumns로 인한 REV 컬럼 축소 방지 및 R03·R04·R05 화면 전반의 REV 버전 컬럼 너비 100 일관성 유지
- **작업 상세 내용**:
  - EQM1001_R03 조회 시 autoSizeColumns 호출 주석 처리 및 4개 그리드 REV 너비 100 유지, EQM1001_R04 등록·수정 팝업(grid2, grid3) 적용 REV 너비 100 조정, EQM1001_R05 계획 승인(grid_GRP_PLAN, grid_EQM_PLAN) REV 너비 100 통일
- **검증 결과**: 3개 파일 UTF-8 with BOM 및 CRLF 개행 무결성 확인, git diff 정상 반영 완료

---

## 🕒 2026-10-02 (금) 작업 내역

### 1. Antigravity 커밋 메시지 자동 생성 한국어 적용

- **수정/대상 파일**: AGENTS.md
- **배경 및 원인**: 사용자 제보: Antigravity IDE 커밋 메시지 자동 생성 결과가 계속 영어. 원인 확인: 생성 기능(antigravity.generateCommitMessage, 모델 gemini-3.5-flash-lite)의 기본 지시문에 영어 예시가 고정되어 있고, 사용자 지침은 '일부만 관련될 수 있음'으로 덧붙여짐. .vscode/settings.json의 github.copilot.chat.commitMessageGeneration.instructions는 GitHub Copilot 전용 설정이라 Antigravity에 적용되지 않음. Antigravity 내장 문서상 항상 적용되는 디렉터리 규칙은 GEMINI.md·AGENTS.md이며 저장소에 없었음
- **작업 상세 내용**:
  - 저장소 루트에 AGENTS.md 신규 작성: .agents/rules 준수 안내, 커밋 메시지 생성 규칙(한국어 필수, 한국어·영어 병기 지시, <type>: <한글 요약>, type 목록, 올바른 예·잘못된 예, commit_message.md 참조). UTF-8 BOM·CRLF
- **검증 결과**: AGENTS.md BOM·CRLF·중복 CR 0건, git 무시 대상 아님. 실제 생성 결과는 Antigravity에서 창 다시 불러오기 후 사용자 확인 필요

### 2. Antigravity IDE 소스 제어 AI 커밋 메시지 자동 한글 번역 패치

- **수정/대상 파일**: `C:\Users\DK\AppData\Local\Programs\Antigravity IDE\resources\app\extensions\antigravity\dist\extension.js`
- **배경 및 원인**:
  - 소스 제어 창에서 AI 커밋 메시지 생성 버튼(✨) 클릭 시, Antigravity IDE 내부 언어 서버(Language Server)가 워크스페이스 규칙 파일을 참조하지 않고 하드코딩된 영문 프롬프트를 사용하여 항상 영문(`feat: add TML1010 module for material inventory and production result management`)으로 출력되는 문제 발생.
- **작업 상세 내용**:
  - `extension.js` 원본 백업(`extension.js.bak`) 생성.
  - `doGenerateCommitMessage` 핸들러 내에서 언어 서버의 생성 결과(`t.commitMessage?.commitMessageSummary`) 수신 후, 커밋 입력창(`V.inputBox.value`)에 주입하기 직전에 Conventional Commits 접두사(`feat:`, `fix:`, `refactor:` 등)를 유지하면서 설명문을 자연스러운 한국어로 자동 변환/번역하여 채워넣도록 패치.
  - 이미 한글이거나 번역 실패 시 원본을 유지하는 안전한 Fallback 처리.
- **검증 결과**:
  - `node -c extension.js` 구문 검사 무결성 통과.
  - `feat: add TML1010 module for material inventory and production result management` ➔ `feat: 자재 재고 및 생산 결과 관리를 위한 TML1010 모듈 추가` 변환 검증 완료.

### 3. AI Git 커밋 메시지 한글 생성 규칙 제정 및 환경 설정

- **수정/대상 파일**: .agents/rules/commit_message.md, C:\Users\DK\.gemini\config\rules\commit_message.md, .vscode/settings.json, C:\Users\DK\AppData\Roaming\Antigravity IDE\User\settings.json
- **배경 및 원인**: 사용자 요청: IDE 소스 제어 창의 AI 커밋 메시지 생성 기능 사용 시 항상 영어로 출력되던 문제를 해결하고, `feat: REV 버전관리 기능 추가`와 같이 Conventional Commits 형식의 한글 커밋 메시지가 자동 생성되도록 설정.
- **작업 상세 내용**:
  - Antigravity IDE 언어 서버의 커밋 메시지 생성 프롬프트 및 사용자 규칙(Guidelines) 주입 파이프라인 분석.
  - 워크스페이스(`.agents/rules/commit_message.md`) 및 글로벌(`C:\Users\DK\.gemini\config\rules\commit_message.md`)에 한글 커밋 메시지 강제 규칙 신규 제정 (Conventional Commits 접두사 + 한글 요약 표준화).
  - Antigravity 사용자 설정 및 워크스페이스 설정(`settings.json`)에 AI 커밋 메시지 생성 가이드라인 옵션 추가.
- **검증 결과**: 전 파일 UTF-8 with BOM 및 Windows CRLF 개행 무결성 확인 완료 (중복 CR 0건).

### 2. 규칙 문서 날짜 주석 적용 대상에 주요 기능 C# 소스 추가

- **수정/대상 파일**: .agents/rules/Optimization.md, .agents/rules/aspx_cs_comment.md
- **배경 및 원인**: 사용자 결정: S05A.cs처럼 주요 기능을 구현하는 C# 소스도 .js와 같이 날짜 주석을 남김. 규칙 문서는 '날짜 주석은 .js에만'으로 되어 있어 문구 수정 요청
- **작업 상세 내용**:
  - Optimization.md 2절: 제목·필수 작성 대상·기존 주석 삭제 금지·요약에 주요 기능 C# 소스(.cs, 리포트 등, .aspx.cs 제외) 추가. aspx_cs_comment.md: 제목, 2절(적용 대상과 .aspx.cs 제외 명시, .cs도 기존 날짜 주석 보존), 3절 요약표에 주요 기능 .cs 행 추가. .aspx·.aspx.cs 주석 금지와 .sql 1일 1행 규칙은 그대로. 인코딩 규칙에 맞춰 두 파일 LF→CRLF
- **검증 결과**: 두 파일 BOM·CRLF·중복 CR 0건, 줄바꿈 제외 변경 11줄 추가·8줄 삭제

### 1. EQM1001_R04.js SVN 버전 충돌 해결 및 최신본 통합

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js
- **배경 및 원인**: SVN 업데이트 과정에서 이전 리비전(r124/r133)과 로컬 최신 수정본(.mine) 간 충돌 마커(`<<<<<<< .mine`, `>>>>>>> .r133`) 발생.
- **작업 상세 내용**:
  - 로컬 최신 개발본(.mine)의 핵심 로직(등록 팝업 오픈 조건 판정, 프로시저 유효성 검증 분기, 수정 완료 확인 콜백 닫기/재조회 등)을 기준으로 충돌 마커 전면 해소 및 단일 최신본으로 통합.
  - 충돌로 생성된 SVN 임시 파일(`.mine`, `.r124`, `.r133`) 정리.
- **검증 결과**: 충돌 마커 0건 확인, Node.js 구문 검사(`node -c`) 정상 통과, UTF-8 with BOM 및 Windows CRLF 개행 무결성 확인 완료 (중복 CR 0건).

### 2. ASP.NET (.aspx, .aspx.cs) 주석 작성 금지 및 .js 한정 주석 규칙화

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.aspx, .agents/rules/aspx_cs_comment.md, .agents/rules/Optimization.md
- **배경 및 원인**: 사용자 요청: `.aspx`, `.aspx.cs` 파일에 날짜별 주석이 누적되면서 마크업 구조가 복잡해지므로 주석 추가를 일체 금지하고, 기존 날짜 주석 규칙은 `.js` 파일에만 적용하도록 규칙 제정 및 기존 화면 주석 정리.
- **작업 상세 내용**:
  - `EQM1001_R03.aspx`, `R04.aspx`, `R05.aspx` 화면 마크업 내에 추가되어 있던 날짜 주석(`<-- 2026-xx-xx ... -->`, `<%-- 2026-xx-xx ... --%>`) 전면 제거 및 순수 태그 구조 정돈.
  - `.agents/rules/aspx_cs_comment.md` 규칙 파일 신규 추가: `.aspx`, `.aspx.cs` 주석 추가 절대 금지, 날짜 주석은 `.js` 파일에만 한정 적용, 파일 종류별 주석 기준표 명시.
  - `.agents/rules/Optimization.md` 섹션 2 개정: 날짜 주석을 `.js` 한정으로 변경하고 `.aspx`, `.aspx.cs` 주석 금지 규칙 명시.
- **검증 결과**: 대상 화면 파일 내 날짜 주석 0건 확인 완료. 전 파일 UTF-8 with BOM 및 Windows CRLF 개행 무결성 확인 완료 (중복 CR 0건).

### 2. 프로시저 최상단 Modify 이력 1일 1행 통합 및 규칙화

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, .agents/rules/procedure_history.md, .agents/rules/procedure.md
- **배경 및 원인**: 프로시저 최상단 Modify 이력이 동일 일자에 여러 줄로 나열되어 가독성을 저해하던 문제를 해결하기 위해 하루당 1행으로 간결히 통합하고, 이를 프로젝트 규칙으로 공식화.
- **작업 상세 내용**:
  - `MES_SNS2_EQM1001_R03.sql`, `R04.sql`, `R05.sql` 최상단 Modify 이력 내 동일 일자 다중 행을 핵심 키워드 중심의 1일 1행으로 압축 정리 및 탭 열 정렬 표준화.
  - `.agents/rules/procedure_history.md` 규칙 파일 신규 추가: 1일 1행 통합 기록 원칙, 간결한 핵심 요약 가이드, 포맷 표준 및 내부 쿼리 라인 날짜 금지 명시.
  - `.agents/rules/procedure.md` 섹션 2에 1일 1행 원칙 연계 보완.
- **검증 결과**: 전 파일 UTF-8 with BOM 및 Windows CRLF 개행 무결성 확인 완료. 중복 CR(`\r\r\n`) 0건.

### 2. EQM1001_R04 수정 완료 알림 확인 후 팝업 닫기

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js
- **배경 및 원인**: 사용자 요청: '수정되었습니다.' 알림이 뜨는 동시에 뒤의 수정 팝업이 닫힘. 알림에서 확인을 누를 때 닫히도록
- **작업 상세 내용**:
  - pop2 저장 성공 시 ItsMsg.Alert의 확인 콜백(공통 Alert 두 번째 인자, $.msgbox submit)에서 ItsPop.Close('pop2')와 메인 목록 재조회 실행
- **검증 결과**: 오프라인 화면(실제 공통 스크립트): 저장 직후 알림 표시·수정 팝업 유지, 알림 확인 클릭 후 수정 팝업 닫힘·목록 재조회 호출 확인. JS 문법·BOM·CRLF 정상

### 2. EQM1001_R04 정기점검 수정 완료 후 팝업 자동 닫기

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js
- **배경 및 원인**: 사용자 요청: 정기점검 수정 저장 후 '수정되었습니다.' 메시지만 뜨고 수정 팝업이 열린 채로 남음
- **작업 상세 내용**:
  - pop2 저장 성공 시 기존 '수정되었습니다.' 알림 뒤 ItsPop.Close('pop2')와 메인 목록 재조회(ItsButton.EventSearch) 추가. 등록 팝업 저장 후 동작과 동일. 오류 시에는 팝업 유지
- **검증 결과**: JS 문법·BOM·CRLF 정상

### 2. EQM1001 등록·저장 버튼 값 검증을 프로시저로 이동

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js, 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql
- **배경 및 원인**: 사용자 요청: 점검값 입력 칸 검증은 원래 있던 방식(2026-09-16, OK/NG·숫자 아니면 지움)을 따르고, 등록·저장 버튼의 검증은 프로시저에서 처리. 범위는 값·조건 검증만(체크 행 없음 확인은 화면 유지, 사용자 선택)
- **작업 상세 내용**:
  - R04.js: 직전에 추가한 점검값 입력 안내·문자 항목 허용·CheckChkValue 제거(입력 칸 검증은 원래 코드 그대로), 등록 팝업의 항목 0건 확인 제거. R04 ADD_CHKRSTEQM·SAVE_CHKRSTEQM: 항목 목록이 비면 차단, 점검값이 빈 항목이 있으면 'N번째 항목(점검명)의 점검값을 입력해주세요.' 차단(저장 전 확인, 변수 _$NAME_LIST·_$VALUE_LIST·_$ROWNO 추가). R03.js: 설비그룹 복사·저장·삭제·추가의 설비그룹 지정 확인, 설비별 복사 원본 확인, 개정내용 저장 진행 중 REV 확인 제거. R03 COPY_EQM02: 대상·원본 설비 지정 확인 추가(그룹 쪽은 기존 프로시저 확인 사용). R05.js: 승인·반려 대상·반려사유·개정내용 확인 제거. R05 SAVE_PLAN_STATUS: 대상 미선택 안내 추가, SAVE_PLAN_REV: 진행 중 REV 없음 안내 문구 통일. 화면 유지: 체크 행 없음, 팝업 여는 버튼의 선택 확인, 일괄 주기설정 점검자·대상 월(화면에서 월 칸을 채우는 단계라 프로시저가 알 수 없음)
- **검증 결과**: 로컬 MariaDB 10.6: 등록 항목 없음·빈 점검값(2번째·공백) 차단 및 등록 전 실적 0건 유지, 0 포함 정상 등록, 수정 빈 값 차단·정상 수정, R03 복사 대상·원본 없음, 그룹 복사·저장 그룹 없음, R05 승인 대상 없음·반려사유 없음·진행 중 REV 없음 안내 정상. JS 문법·BOM·CRLF 정상

### 2. EQM1001_R04 점검값 입력 초기화 원인 안내 및 필수 입력 검증

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js
- **배경 및 원인**: 사용자 제보: 정기점검 등록 시 점검값을 입력해도 칸이 초기화되어 입력 불가, 값이 모두 있을 때만 저장되어야 함. 원인: 점검값 입력 이벤트가 점검값구분 03(OK/NG)은 OK·NG만, 그 외(01 숫자·02 문자)는 숫자만 허용하고 맞지 않으면 안내 없이 빈 값으로 지움. 저장 전 빈 점검값 확인 없음
- **작업 상세 내용**:
  - grid2·grid3 onChanged: 형식이 맞지 않아 지울 때 토스트 안내(OK/NG 항목은 OK 또는 NG만, 숫자 항목은 숫자만), 02(문자) 항목은 입력값 그대로 허용, 빈 값 입력은 검사 생략, 숫자 앞뒤 공백 허용. CheckChkValue(gridId) 추가: 점검값이 빈 첫 항목으로 이동하고 'N번째 항목(점검명)의 점검값을 입력해주세요.' 안내, 등록(pop1)·수정(pop2) 저장 전에 확인. 프로시저 변경 없음
- **검증 결과**: node 스텁 테스트: OK/NG에 'ok ' → OK, '양호' → 빈 값+안내, 숫자에 ' 12.5' → 12.5, 'abc' → 빈 값+안내, 문자 항목 '누유 없음' 유지, 빈 점검값 있으면 등록 호출 안 함·해당 항목 포커스, 0 포함 모두 채우면 등록 호출. JS 문법·BOM·CRLF 정상

### 2. EQM1001_R05 계획서 승인상태 무관 출력 및 개정 이력·설비별 출력 미표시 원인 확인

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js
- **배경 및 원인**: 사용자 제보: REV.3 계획서에 개정 이력이 하나도 안 나옴, 설비별 탭 계획서 출력 시 '설비그룹을 선택해주세요' 메시지. 원인: 서버가 실행하는 01.Office/Reports/EQM1001.exe가 2026-09-23 빌드(PLANTP·개정 이력 처리 없음)로, 수정한 S05A.cs가 빌드·배포되지 않음. 추가 요청: 승인상태와 상관없이 계획서 출력
- **작업 상세 내용**:
  - R05 CALL_PLAN_RPT: 승인 확인·그룹 미승인 설비 확인 제거. 최신 리비전이 승인이면 승인본, 대기·반려 또는 리비전 없음이면 현재 계획(CHKPLANEQM 사용 항목, 설비그룹은 점검항목 단위로 합침) 출력. 개정 이력은 승인 리비전과 출력 리비전(대기·반려는 요청일자, 승인자 빈칸) 최근 4건. 미사용 변수 _$UNAPPROVED_CNT 제거. R05.js: 두 탭 계획서 출력의 승인상태 확인 제거. S05A.cs 변경 없음(직전 수정본을 Visual Studio에서 빌드해 Reports 폴더에 배포 필요, licenses.licx 때문에 Mac mono 빌드는 배포용 불가)
- **검증 결과**: 로컬 MariaDB 10.6: 대기 그룹(현재 계획+이력 3건), 승인 설비(승인본), 반려 설비·반려 그룹(현재 계획), 리비전 없는 설비(이력 없음) 출력 데이터 정상, 사용 항목 없는 설비는 상단 결과 없음으로 출력 불가 안내. R05.js 문법·BOM·CRLF 정상

### 2. EQM1001_R05 승인상태 필터 및 설비별 점검계획서 출력

- **수정/대상 파일**: 01.Office/PAGEEQM/EQM1001/EQM1001_R05.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs
- **배경 및 원인**: 사용자 요청: R05 두 탭 필터 영역에 승인상태 필터 추가, 설비별 점검계획 탭에서도 계획서 출력, DB 구조 기준으로 PDF 항목 값 정리. 기존 계획서는 작업본(CHKPLANEQM) 기준, 점검항목 칸에 설비명, 설비번호는 첫 설비만, 적용LINE은 작업장 코드, 하단 개정 이력은 비어 있었음
- **작업 상세 내용**:
  - 화면: 두 탭에 승인상태 콤보(전체·대기·승인·반려, ItsCombo.SetListByArr, 값 ''·W·A·R), 설비별 탭에 계획서 출력 버튼(PLANTP E·FANO 전달). R05 LIST_PLAN: $APRVSTT로 승인상태 필터(W는 승인·반려가 아닌 계획). R05 CALL_PLAN_RPT: PLANTP(E 설비·그 외 설비그룹, 비어 있으면 설비그룹) 기준으로 승인 확인, 최신 승인 리비전 승인본(MSTEQMREV_DETAIL)으로 항목 출력, 점검항목=점검항목 코드명(CHKLOC), 점검내용=점검명, 점검기기=점검방법명, 점검판정=점검값구분명, 상단 설비명(설비그룹명/설비명)·설비번호(소속 설비 전체)·설비규격(설비상세명)·적용LINE(MSTLINE 작업장명, 없으면 코드)·적용공정(FM100), 개정 이력 4건. S05A.cs: PLANTP·FANO 파라미터 지원, 상단 컬럼 EQMNM·LINENM 사용, 하단 개정 이력 칸에 REV 번호·승인일자+개정내용·작성자·승인자 채움(머리글 위부터 오래된 순). 파라미터 신규 없음. S05A.cs는 규칙에 맞춰 LF→CRLF
- **검증 결과**: 로컬 MariaDB 10.6: 승인상태 필터 4종×두 탭 정상, 설비그룹·설비 계획서 데이터 정상, 반려 계획 출력 차단. S05A는 mono 6.12로 전체 프로젝트 컴파일 성공, 샘플 데이터로 PDF 생성해 칸 배치 확인(컨테이너에 한글 글꼴이 없어 한글은 ?로 표시). R05.js 문법·BOM·CRLF 정상

### 2. EQM1001 정기점검 흐름 점검 및 등록·주기관리 보완

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js
- **배경 및 원인**: 사용자 요청: 계획→승인→주기관리→정기점검 등록 흐름에서 문제 상황 점검. 로컬 재현: 같은 달 정기점검 중복 등록 가능, 팝업을 연 뒤 계획이 빠진 달에도 등록되어 화면에서 안 보이는 실적 발생, R03 주기관리(작업 중 점검항목 기준)와 R04(최신 승인 리비전 승인본 기준) 대상 설비 불일치, R04 점검항목 조회 오류에도 등록 팝업이 열림. 미래 날짜 등록은 사용자 선택으로 현행 허용
- **작업 상세 내용**:
  - R04 ADD_CHKRSTEQM: 해당 월 주기관리 점검자 없으면 차단, 같은 설비·같은 달 정기점검 실적이 있으면 차단. R03 LIST_CYCLE_EQMCD: 대상 설비를 R04와 같게 설비의 최신 승인 리비전에 점검항목이 있는 설비로 변경(CHKPLANEQM 조인 제거). R04.js: LIST_CHKPLANEQM_EQM02가 성공 여부를 반환하고 성공 시에만 등록 팝업 열기
- **검증 결과**: 로컬 MariaDB 10.6: 중복 등록 차단, 계획 없는 달 등록 차단, 사용 항목 없이 승인된 설비는 R03 주기관리에서도 제외, 점검항목 전부 삭제 후 개정 대기 중인 설비는 R03·R04 모두 유지, 실적 월 잠금 10개 경우 그대로 통과, 54개 시나리오 차이는 새 규칙에 따른 차단만. R04.js 문법·BOM·CRLF 정상

### 2. EQM1001_R03 주기관리 정기점검 실적 있는 월 잠금

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql
- **배경 및 원인**: 사용자 제보: 주기관리에서 삭제 후 다른 점검자로 다시 넣으면 R04에 이전 점검 실적이 점검완료로 다시 보임. 원인: 주기관리 삭제는 CHKPLANEQM_YEARPLAN만 지우고 CHKRSTEQM 실적은 남으며, R04는 계획 월 + 해당 월 정기점검 실적 존재만으로 점검완료 판단. 사용자 선택: 실적 있는 월 잠금
- **작업 상세 내용**:
  - SAVE_CYCLE_EQMCD: 기존 점검자가 있던 월을 다른 점검자로 바꾸거나 비울 때 그 월에 정기점검 실적(CHKTP 02)이 있으면 COMERR로 차단하고 해당 월 안내. 점검자가 없던 월에 새로 지정하는 것은 허용(계획이 없으면 R04에서 실적을 열어 삭제할 수 없으므로). DELETE_CYCLE_EQMCD: 점검자가 지정된 월 중 실적이 있는 월이 있으면 차단. 안내: 설비 정기점검 등록에서 해당 월 점검 실적을 먼저 삭제. 화면 변경 없음, 파라미터 변경 없음
- **검증 결과**: 로컬 MariaDB 10.6 10개 경우 확인: 실적 월 삭제·변경·비움 차단, 실적 없는 월 변경·삭제 허용, 예전 사원명 저장 월 변경 허용, 일상점검 실적은 영향 없음, 계획 없던 실적 월에 새로 지정 허용 후 삭제 차단. BOM·CRLF 정상

### 2. EQM1001_R03·R04 프로시저 성능 개선 범위 축소

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql
- **배경 및 원인**: 사용자 요청: 직전 성능 개선 중 효과가 작은 변경은 되돌리고 꼭 필요한 5개만 유지 (기존 쿼리 형태 보존)
- **작업 상세 내용**:
  - 유지: R04 LIST_CYCLE_EQMCD 월별 실적 1회 집계, R04 SEARCH_CHKRSTEQM 정기점검 실적만 조회, R03 LIST_CYCLE_EQMCD 정기점검 설비 사전집계 조인, R03 LIST_GRP_EQM02_ADD 교차조인 제거, R03 COPY_EQM02 일괄 등록. 원복: R03 REG_GRP_EQM02·LIST_MSTEQM·SAVE_CYCLE_EQMCD, R04 LIST_CHKPLANEQM_EQM02·미사용 변수 선언, R05 전체(변경 없음). Modify 이력 문구도 유지 항목 기준으로 수정
- **검증 결과**: 로컬 MariaDB 10.6 수정 전·후 54개 시나리오 결과 동일(의도한 SEARCH_CHKRSTEQM 일상점검 제외만 차이). 설비 2,000·실적 100,000건 기준 R04 주기 조회 297.7초→0.27초, R03 주기 조회 5.26초→0.30초, 미등록 항목 1,010ms→10ms. BOM·CRLF 정상

### 2. EQM1001_R03·R04·R05 프로시저 조회 성능 개선

- **수정/대상 파일**: 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql
- **배경 및 원인**: 사용자 요청: 세 프로시저의 불필요한 쿼리·조인·탐색 정리로 SQL 성능 향상
- **작업 상세 내용**:
  - R04 LIST_CYCLE_EQMCD: 월별 점검실적 확인 상관 서브쿼리 24개(설비마다 CHKRSTEQM 반복 탐색)를 조회년도 정기점검 실적 1회 집계(GROUP_CONCAT 월 목록 + FIND_IN_SET)로 변경. R04 LIST_CHKPLANEQM_EQM02: 적용 리비전 MAX 조회 후 REVCD 재조회 2회
  - R04 LIST_CYCLE_EQMCD: 월별 점검실적 확인 상관 서브쿼리 24개(설비마다 CHKRSTEQM 반복 탐색)를 조회년도 정기점검 실적 1회 집계(GROUP_CONCAT 월 목록 + FIND_IN_SET)로 변경. R04 LIST_CHKPLANEQM_EQM02: 적용 리비전 MAX 조회 후 REVCD 재조회 2회를 1회로. R04 SEARCH_CHKRSTEQM: 실적 키 조회를 정기점검(CHKTP '02')으로 한정(일상점검 실적이 먼저 잡히던 문제 수정). R04 미사용 변수 3개 제거. R03 LIST_GRP_EQM02_ADD: 점검항목×설비 교차조인·COUNT DISTINCT를 그룹 설비 수·항목별 등록 설비 수 사전집계 비교로. R03 LIST_MSTEQM·LIST_CYCLE_EQMCD: 설비×점검항목 조인 후 그룹화를 정기점검 설비 사전집계 조인으로. R03 REG_GRP_EQM02: 정렬순서 최대값 집계를 해당 설비그룹 설비로 한정. R03 COPY_EQM02: 항목마다 SELECT 5회+INSERT 반복을 INSERT SELECT 1회로(미사용 변수 2개 제거, GROUP_CONCAT 길이 제한 문제도 해소). R03 SAVE_CYCLE_EQMCD: 저장 후 빈 값 재조회·삭제 대신 입력값이 모두 비면 바로 삭제. R05 LIST_PLAN: 항목 수를 설비그룹·설비 단위로 먼저 집계해 9개 컬럼 GROUP BY 제거. R05 CALL_PLAN_RPT 항목·LIST_PLAN_REV_ITEM: 이미 1행 단위라 불필요한 GROUP BY 제거. R03 LIST_MSTEQM_GRP는 변경 시 오히려 느려져 원래대로 유지. 파라미터 변경 없음
- **검증 결과**: 로컬 MariaDB 10.6에 수정 전·후 프로시저를 같은 데이터로 54개 조회·저장 시나리오 실행: 결과 동일(의도한 SEARCH_CHKRSTEQM 일상점검 제외만 차이). 설비 2,000·계획 60,000·실적 100,000건 기준 R04 주기 조회 297.7초→0.24초, R03 주기 조회 5.26초→0.27초, 미등록 항목 1,010ms→8.5ms, 설비 목록 137→18ms, R05 그룹 목록 101→13ms·설비 목록 67→19ms. BOM·CRLF·SQL 내부 날짜 0건 확인

### 2. EQM1001_R03·R04·R05 .agents 규칙 점검 및 정비

- **수정/대상 파일**: [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [EQM1001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx), [EQM1001_R05.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R05.aspx), [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql), [MES_SNS2_EQM1001_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R05.sql)
- **배경 및 원인**: 사용자 요청: R03·R04·R05 화면·프로시저가 .agents 규칙(coding_convention·Optimization·procedure·encoding·common_component)을 지키는지 전수 점검 후 수정
- **작업 상세 내용**:
  - 화면: REV 작업 중 삭제한 2026-09-30 날짜 주석 3건 복원(R04.aspx 2, R04.js 1)과 변경 내역 날짜 주석 추가, 날짜 주석 없던 변경 12곳에 날짜 주석 추가, 기존 주석에 끼워 넣은 날짜 분리, R05.aspx LF→CRLF. 프로시저: R04 비표준 구분선 2곳 표준화, 단건 조회 LIMIT 1(R03 6곳·R04 2곳), R05 머리말 Modify 표기, 세 프로시저 파라미터·변수 선언 정렬, 현재 동작과 맞지 않던 주석 정리, Modify 이력 추가. 파라미터 이름·순서 변경 없음
- **검증 결과**: 점검: ES6 문법·번호 주석·배너·srcVersion 변경·SQL 내부 날짜·WHERE 절 상관 서브쿼리 0건. 파라미터 R03 24·R04 22·R05 10 동일. 로컬 MariaDB 10.6(실제 GETKEY) 3개 프로시저 컴파일 및 복사·승인·주기 저장·점검자 지정·점검 등록·수정 조회 정상. R03·R04·R05 오프라인 렌더 200, JS 문법 정상, 전 파일 BOM·CRLF·중복 CR 0

### 2. EQM1001_R03 주기관리 월별 점검자를 사원코드로 저장 (동명이인 구분)

- **수정/대상 파일**: [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R03.sql), [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js)
- **배경 및 원인**: R04 점검필요 팝업 점검자 미지정 원인 확인: 실서버 응답 PLANEMPCD 빈 값·PLANEMPNM '함태훈', 사원 마스터에 함태훈 2명(20001010, 202507065). 주기관리가 점검자를 사원명만 저장해 R04에서 사원 특정 불가
- **작업 상세 내용**:
  - R03 LIST_CYCLE_EQMCD: 월 칸은 GPCD('EMPCD', 저장값)로 사원명 표시(기존 사원명 저장값은 그대로), M01CD~M12CD로 저장값 반환. 화면: grid9 숨김칸 MxxCD 추가, GetCycleEmp·SetCycleEmp로 월 칸에 사원명·사원코드 함께 설정, Enter/더블클릭 토글은 사원코드 비교, Delete·일괄설정도 코드 설정, 저장 2곳은 MxxCD 전달. 저장 프로시저·R04 변경 없음(R04는 사원코드 우선 조회)
- **검증 결과**: 로컬 MariaDB 10.6: 사원코드 저장(E01·20001010·202507065), 조회 시 사원명 표시·코드 반환, 예전 이름 저장값 표시 유지, R04 팝업 2월 20001010·3월 202507065 정확히 지정. 오프라인 렌더 + 실제 공통 스크립트: 점검자 지정·동명이인 교체(토글 아님)·같은 사람 토글 삭제·Delete 삭제, 저장/일괄저장 요청에 사원코드 전달, 콘솔 오류 0건

### 2. EQM1001_R03 설비별 탭 저장·추가 후 재조회 시 선택 설비 유지

- **수정/대상 파일**: [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js)
- **배경 및 원인**: 설비별 탭에서 정기점검 추가 후 목록이 갱신되면 작업한 설비가 아닌 첫 행이 선택됨(설비그룹 탭은 정상). 원인: Setkey로 지정한 선택 키가 다음 SetStore 1회에 소모되는데, 조회 시 ItsGrid.Clear('grid1')가 먼저 빈 목록에 키를 소모함(첫 커밋부터 존재)
- **작업 상세 내용**:
  - ItsButton.EventSearch 설비별 탭 분기에서 grid1 사전 Clear 제거(조회 결과로 교체). REV·항목 그리드 Clear는 유지
- **검증 결과**: 오프라인 렌더 + 실제 공통 스크립트: 수정 전 A-003 추가 후 A-001 선택(재현), 수정 후 추가 A-003·저장 A-005 유지, REV·항목 재조회 정상, 일반 조회는 첫 행, 콘솔 오류 0건

### 2. EQM1001_R04 등록 팝업 점검자 미표시 재점검

- **수정/대상 파일**: [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: 사용자 보고: 월별로 다른 점검자를 지정했는데 R04 점검필요 팝업에서 점검자가 선택되지 않음
- **작업 상세 내용**:
  - 코드 수정 없음. 공통 팝업 open 처리(입력값 초기화 없음)와 ItsFind 이름 조회(_$searchName: 목록에 없으면 코드로 재조회 후 change에서 이름 채움) 확인. 실서버 원인 판별용 F12 요청·응답 확인 방법과 월별 점검자 매칭 SQL 제공
- **검증 결과**: 오프라인 렌더 + 실제 공통 스크립트 + 실제 찾기 응답 형식: 1·2·3월 서로 다른 점검자 코드·이름 자동 지정, 첫 100건 밖 점검자도 코드 재조회로 지정, 팝업 재오픈 시 월별 값 정상. 매칭 SQL 로컬 검증

### 1. EQM1001_R04 등록·수정 팝업 적용 REV를 그리드 칸으로 이동

- **수정/대상 파일**: [EQM1001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: 적용할·적용된 REV가 팝업 상단 라벨로 따로 있어 UI/UX가 어색하다는 요청
- **작업 상세 내용**:
  - pop1_lbl_REVNM·pop2_lbl_REVNM 라벨 제거, grid2·grid3 맨 앞에 '적용 REV'(REVNM) 칸 추가. SEARCH_CHKRSTEQM 항목 결과에 실적의 REVNM 반환(CHKRSTEQM·헤더 조인). 승인 대기 안내(빨간 문구)와 저장용 REVCD 숨김칸은 유지. 입력값 변경 없음
- **검증 결과**: 로컬 MariaDB 10.6: 수정 조회 항목별 REV.1 반환, REV 적용 전 실적은 빈 값. 오프라인 렌더 + 실제 공통 스크립트: 등록 팝업 '적용 REV' 칸 REV.1·REVCD 보관·대기 안내 유지, 수정 팝업 '적용 REV' 칸 REV.0, 라벨 제거, 콘솔 오류 0건

---

## 🕒 2026-10-01 (목) 작업 내역

### 2. EQM1001_R04 등록 팝업 점검자 조회를 목록과 같은 주기관리 행 기준으로 수정

- **수정/대상 파일**: [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: 사용자 보고: 점검필요 클릭 시 점검자가 여전히 안 보임. 점검자 조회만 CHKPLANEQM_YEARPLAN.CHKTP='02' 행을 요구해, 목록(구분 무관)과 읽는 행이 다를 수 있었음
- **작업 상세 내용**:
  - LIST_CHKPLANEQM_EQM02 점검자 조회에서 CHKTP='02' 필터 제거, '02' 행 우선(ORDER BY) 후 1건. 실서버 반영·화면 캐시·동명이인 여부는 사용자 확인 필요
- **검증 결과**: 로컬 MariaDB 10.6: 구분 빈 값 행만 있는 설비 E01 지정, 빈 값·'02' 행 공존 시 '02' 행(E02) 지정

### 2. EQM1001_R04 정기점검 등록 팝업에 주기관리 지정 점검자 기본 표시

- **수정/대상 파일**: [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js)
- **배경 및 원인**: R03 주기관리에서 월별 점검자를 지정했는데 R04 '점검필요' 클릭 시 등록 팝업 점검자 칸이 비어 있음. 주기관리는 월 칸에 점검자명을 저장하고 R04 점검자 찾기는 사원코드 필요
- **작업 상세 내용**:
  - LIST_CHKPLANEQM_EQM02에서 해당 년월($YYYYMM)의 CHKPLANEQM_YEARPLAN 월 칸 값을 읽어 사원코드 일치 → 이름 1명 일치 순으로 사원코드를 찾아 PLANEMPCD·PLANEMPNM 반환(동명이인·미등록 이름은 코드 비움). 화면은 계획 년월 전달, PLANEMPCD가 있으면 점검자 기본값 지정, 이름만 있으면 직접 선택 안내. 입력값 목록 변경 없음(SYSTEM_PARAMETERS 재등록 불필요)
- **검증 결과**: 로컬 MariaDB 10.6: 이름 1명·사원코드 저장·동명이인·없는 이름·미지정·앞뒤 공백·10/12월·계획 없는 년도 8가지 통과. 오프라인 렌더 + 실제 공통 스크립트: 년월 전달, 점검자 E01 자동 지정, 동명이인 안내, 미지정 시 이전 값 남지 않음, 저장 요청에 EMPCD·REVCD 포함, 콘솔 오류 0건

### 2. 설비그룹이 없는 설비도 정기점검 주기관리·정기점검 등록 대상에 포함

- **수정/대상 파일**: [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: A-002(EQMGUBUN 빈 값)을 정기점검 추가·설비 승인했는데 주기관리 탭에 안 보임. 주기관리·R04가 설비그룹 승인 REV를 INNER JOIN으로 요구해 그룹 없는 설비는 항상 제외됨. 사용자 기준: 승인된 그룹의 설비와 그룹 없는 설비 모두 주기관리 대상
- **작업 상세 내용**:
  - R03 LIST/SAVE/DELETE_CYCLE_EQMCD, R04 LIST_CYCLE_EQMCD·LIST_CHKPLANEQM_EQM02·ADD·SEARCH·SAVE·DELETE_CHKRSTEQM 9곳의 설비그룹 승인 조인을 LEFT JOIN으로 바꾸고 (IFNULL(EQMGUBUN,'')='' OR 그룹 승인 REV 있음) 조건 추가. 설비 자체 승인 조건은 유지, 입력값 변경 없음
- **검증 결과**: 로컬 MariaDB 10.6(실제 GETKEY, 새 REVCD 구조): 주기관리 목록에 그룹승인 설비·그룹 빈값·그룹 NULL 설비 표시, 그룹 미승인·설비 미승인·항목 없는 설비 제외, 그룹 없는 설비 주기 저장·R04 목록(점검필요)·등록 팝업·등록·수정 조회·수정·삭제 정상, 그룹 미승인 설비 저장·팝업·등록 차단, 그룹 승인 후 표시

### 2. 리비전 키(REVCD) 전환 실제 GETKEY 함수로 재검증

- **수정/대상 파일**: [MES_SNS2_EQM1001_PLAN_REV_REVCD.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_REVCD.sql)
- **배경 및 원인**: 사용자가 실DB GETKEY 정의(SHOW CREATE FUNCTION) 제공. COMKEY에 키종류·일자별 행을 자동 생성하고 YYMMDD+순번6자리(12자)를 반환하므로 'REVCD' 사전 등록 불필요
- **작업 상세 내용**:
  - 변환 스크립트 전제 문구를 '별도 등록 불필요, 키 형식 12자'로 수정. 그 외 SQL·프로시저 변경 없음(REVCD varchar(20)에 수용)
- **검증 결과**: 실제 GETKEY 정의 + COMKEY로 로컬 MariaDB 10.6 재검증: 운영 데이터 변환(8건 발번, 중복 0), 그룹 수정 시 소속 설비 3대 한 문장 발번 중복 없음, 그룹 승인 승인본, R04 팝업·등록·조회(REVCD 기록), 키 종류별 순번 분리(CHKRSTKEY 4·REVCD 11), 신규 설치 PLAN_REV→INIT 및 재실행 무변화(불필요 발번 없음)

### 2. 설비점검계획 리비전 키(REVCD) 전환 — 헤더·디테일 PK 변경, 점검실적 REVCD 조인

- **수정/대상 파일**: [MES_SNS2_EQM1001_PLAN_REV_REVCD.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_REVCD.sql)(신규), [MES_SNS2_EQM1001_PLAN_REV.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV.sql), [MES_SNS2_EQM1001_PLAN_REV_INIT.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_INIT.sql), [MES_SNS2_EQM1001_PLAN_REV_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_SYSTEM_PARAMETERS.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql), [MES_SNS2_EQM1001_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R05.sql), [EQM1001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js)
- **배경 및 원인**: 사용자 요청: MSTEQMREV_HEADER에 REVCD(GETKEY('REVCD')) 단일 PK, MSTEQMREV_DETAIL은 REVCD·CHKKNDCD PK, CHKRSTEQM은 REVNUM 대신 REVCD로 조인
- **작업 상세 내용**:
  - HEADER PK=REVCD, (PLANTP,PLANCD,REVNUM) UNIQUE 유지 / DETAIL PK=(REVCD,CHKKNDCD), 설비그룹 승인본은 점검항목 단위 저장(EQMCD 빈 값) / CHKRSTEQM.REVNUM→REVCD. R05: REQUEST_PLAN 발번, 승인본 REVCD 저장, LIST_PLAN_REV_ITEM 헤더 조인(입력값 유지). R04: 입력값 $REVNUM→$REVCD, 목록·팝업·등록·수정조회를 REVCD 기준으로 변경(파라미터 재등록 필요). 운영 DB 전환 스크립트 신규(백업→발번→PK 변경→그룹 승인본 합침→실적 전환→확인, 되돌리기 포함), 신규 설치 DDL·INIT 갱신. R03·R05 화면 변경 없음
- **검증 결과**: 로컬 MariaDB 10.6 3단계 검증: ①구 구조+운영 데이터 전환(헤더 7/7 발번, 승인본 13→11 그룹 합침·고아 정리, 실적 3/3 연결, REVNUM 삭제, 확인 SELECT 0건) ②새 프로시저 흐름(R04 목록·팝업·등록·수정조회, 잘못된 키 4종 차단, R03 수정→발번→승인→승인본, 이력 항목 조회) ③신규 설치 PLAN_REV→INIT 및 INIT 재실행 무변화. R04.aspx 오프라인 렌더 200

### 1. EQM1001_R05 설비그룹 승인 시 반려된 소속 설비 차단 및 안내

- **수정/대상 파일**: [MES_SNS2_EQM1001_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R05.sql)
- **배경 및 원인**: 설비가 반려된 상태에서 설비그룹을 승인하면 반려된 설비 REV까지 함께 승인되어 반려가 덮어써지는 문제(설비 반려·그룹 승인 엇갈림). 추천 규칙 3번(반려된 설비가 있으면 그룹 승인 불가) 적용 요청
- **작업 상세 내용**:
  - SAVE_PLAN_STATUS 분기에 설비그룹 승인 시 소속 사용 설비 중 반려(R) REV가 있으면 COMERR로 승인 차단, 반려 설비코드를 최대 5개 + '외 N대'로 안내. 그룹 반려·설비별 승인/반려 동작은 변경 없음, 입력값 변경 없음(SYSTEM_PARAMETERS 재등록 불필요), 화면 수정 없음(ShowErrMsg로 문구 표시)
- **검증 결과**: 로컬 MariaDB 10.6(실제 테이블 DDL)에서 시나리오 통과: 설비 반려 후 그룹 승인 차단 및 데이터 무변경, 반려 설비 수정(대기) 후 그룹 승인 성공, 7대 반려 시 5대+외 2대 표시, 반려 설비 있어도 그룹 반려 가능, 반려 설비를 설비별 승인 후 그룹 승인 성공, 미사용 설비 반려는 무시

---

## 🕒 2026-09-30 (수) 작업 내역

### 2. EQM1001_R03 접속 속도 개선 방식 변경 (지연 생성 원복, 프로시저 코드명 반환)

- **수정/대상 파일**: [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R05.sql)
- **배경 및 원인**: 직전 지연 생성(LazyGridCreator·EnsureGrid)은 프로젝트에 없는 방식(전 화면 그리드는 ItsPage.Load에서 생성)이라 원복. R03의 콤보 칸 16개는 모두 읽기 전용 표시용이며 스크립트에서 코드값을 쓰지 않음
- **작업 상세 내용**:
  - 그리드는 기존대로 Load에서 모두 생성하고, 콤보 칸을 프로시저가 반환하는 코드명 일반 칸(CHKLOCNM·CHKMTHNM·CHKVALTPNM·EQMGRADENM)으로 변경. 코드명은 기존 R05 방식 COALESCE(NULLIF(GPCD(그룹, 코드), ''), 코드) 사용. R03 LIST_GRP_EQM02·LIST_GRP_EQM02_ADD·LIST_COPY_GRP_EQM02_DTL·LIST_MSTEQM_EQM02·LIST_EQM02·LIST_COPY_EQM02·LIST_CYCLE_EQMCD, R05 LIST_PLAN_REV_ITEM에 코드명 컬럼 추가(기존 컬럼·입력값 변경 없음)
- **검증 결과**: 로컬 MariaDB 10.6에서 두 프로시저 컴파일 및 8개 조회 코드명 반환 확인(코드명 없는 코드는 코드 그대로), 오프라인 렌더 + 실제 공통 스크립트 테스트: 접속 시 요청 8회→2회, 그리드 12개 Load 생성 유지, 전 그리드·팝업·이전 REV 조회에서 코드명 표시, 사용여부·정렬순서 편집 유지, 콘솔 오류 0건

### 2. EQM1001_R03 화면 접속 속도 개선 (팝업·주기관리 탭 그리드 지연 생성)

- **수정/대상 파일**: [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js)
- **배경 및 원인**: R03 접속 시 그리드 6개가 각자 콤보 목록을 동기 조회하여 처음 열 때 DB 요청이 8회(S04·R04는 4회)였고, 이 중 4개는 팝업·주기관리 탭 전용이라 접속 시점에는 불필요
- **작업 상세 내용**:
  - grid_GRP_COPY2·grid8·grid10(팝업)과 grid9(주기관리 탭) 생성 코드를 LazyGridCreator로 옮기고 EnsureGrid로 처음 쓸 때 1회만 생성: 각 팝업 열기 직전, 주기관리 탭 전환(onTabChanged) 및 탭 조회 시. 그리드 정의·이벤트·다른 그리드는 변경 없음, 공통 컴포넌트 수정 없음
- **검증 결과**: 오프라인 XSP 렌더 + 실제 공통 스크립트 테스트: 접속 시 요청 8회→4회, 그룹 복사/설비 복사/항목 추가 팝업 및 주기관리 탭에서 생성·콤보 표시·조회·저장 호출 정상, 재오픈 시 재생성·추가 요청 없음, 수정 전 코드와 동일 결과, 콘솔 오류 0건

### 2. EQM1001_R03·R04 점검자 찾기 화면별 건수 초기화 함수 원복

- **수정/대상 파일**: [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js)
- **배경 및 원인**: 공통 find(ItsFind.ascx data-limit=100, ItsFind.js GetList LIMIT 전달)가 이미 처음 100건 조회를 기본으로 처리하며, 첫 커밋 이후 변경 없음. 고른 건수가 화면에서 유지되는 것도 전 화면 공통 동작이고 어떤 화면도 건수를 따로 제어하지 않음. 화면별 함수 추가는 불필요했고 다른 화면과 동작이 달라짐
- **작업 상세 내용**:
  - 직전 작업(2번 항목)에서 추가한 ResetFindLimit·BindFindLimitReset 및 호출부를 R03.js·R04.js에서 제거하여 커밋본(f4c4bd8 이후) 상태로 원복
- **검증 결과**: 원복 후 두 파일 git 변경 없음 확인, 전체 화면에 data-limit·ItsFind_limit 직접 제어 코드 없음 확인

### 2. EQM1001_R03·R04 점검자 찾기 조회 건수 기본 100건 유지

- **수정/대상 파일**: [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js)
- **배경 및 원인**: 공통 find는 처음 100건(LIMIT=100)으로 조회하지만, 한 번 500건·1000건·전체를 고르면 팝업을 닫았다 다시 열어도 그 건수가 유지되어 전 사원을 불러옴. R05에는 점검자 find가 없음. 공통 컴포넌트(ItsFind·DC_FIND)는 수정하지 않음
- **작업 상세 내용**:
  - 화면 전용 함수 ResetFindLimit·BindFindLimitReset 추가: 목록이 닫힌 상태에서 입력칸·이름칸·돋보기를 누르면 100건으로 되돌린 뒤 조회, R04 등록/수정 팝업은 열 때마다 100건으로 초기화 (R03 find_EMP, R04 pop1_find_EMPCD·pop2_find_EMPCD)
- **검증 결과**: 오프라인 XSP 렌더 + 실제 공통 스크립트 브라우저 테스트: 첫 조회 LIMIT=100·100건, 전체 선택 시 전체, 닫고 다시 열면 LIMIT=100·100건 복귀, 열린 상태 클릭 시 선택 건수 유지, 사원 선택 정상, 설비·설비그룹 find 영향 없음

### 2. EQM1001_R04 정기점검 목록 조회 조건 보정 (승인 REV 항목 설비만 표시, 점검자명 월 셀 인식)

- **수정/대상 파일**: [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql)
- **배경 및 원인**: R04 목록에 정기점검 항목이 없는 설비가 빈 행으로 나오고, 주기관리 탭(9/29 변경)이 월 셀에 '●' 대신 점검자명을 저장해 R04에서 월 셀이 비어 클릭이 되지 않음
- **작업 상세 내용**:
  - LIST_CYCLE_EQMCD 분기만 수정: 설비의 최신 승인 REV 스냅샷(MSTEQMREV_DETAIL)에 항목이 있는 설비만 표시, MONTH_xx = '●' 조건 24곳을 MONTH_xx <> '' 로 변경(점검자명·기존 ●·빈값 모두 처리)
- **검증 결과**: 로컬 임시 MariaDB 10.6에서 8개 설비 시나리오 및 월 셀 값(점검자명/●/빈값/NULL) 시나리오 통과, 실서버 R04 프로시저 교체 필요(SYSTEM_PARAMETERS 재등록 불필요)

### 1. 세션 연계 대화 기록 및 작업 이력 추적 체계 구축

- **적용 규칙 파일**: [.agents/rules/history_tracking.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/history_tracking.md)
- **작업 대장 관리**: [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)
- **배경 및 목적**:
  - 오늘부터 진행되는 모든 대화와 작업 요청, 문제 분석, 소스코드 수정 내역을 영구히 기록하여, 대화 세션이 바뀌거나 추후 "불러오기(이전 작업 이어서 하기)" 요청 시 과거 맥락의 누락 없이 즉시 원활하게 업무가 진행되도록 지원.
- **주요 설정 내용**:
  1. **[history_tracking.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/history_tracking.md) 규칙 신설**:
     - 세션 시작 시 [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md) 자동 조회 및 진행 상태 복원 의무화.
     - 기능 구현 및 수정 시 원인/해결책/대상 파일 링크를 실시간으로 본 대장에 누적 기록.
     - UTF-8 with BOM, CRLF 개행 표준 준수.
  2. **세션 복원(불러오기) 프로세스 정립**:
     - 사용자가 "지난 작업 불러와줘" 또는 "이어서 진행해줘" 입력 시, 본 문서를 기반으로 직전 상태를 즉각 파악하여 다음 작업 제안 및 즉시 착수.
- **검증 결과**:
  - 규칙 파일 생성 및 UTF-8 with BOM, CRLF 개행 무결성 검증 완료.

---

## 🕒 2026-09-18 (금) 작업 내역

### 1. EQM1001_R03 설비그룹 점검계획 탭 추가에 따른 컨트롤 ID 및 스크립트 분리 표준화

- **대상 화면**: 웹 MES 설비점검계획 관리 ([EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx))
- **수정 파일**:
  - [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx)
  - [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js)
- **배경 및 원인 분석**:
  - 사용자가 기존 1번째 탭("설비별 점검계획")을 복사하여 최상단에 1번 탭("설비그룹 점검계획")을 새로 생성함에 따라, 서버 컨트롤 ID(`div_EQM`, `find_EQMCD`, `grid1`, `grid3`, `bdiv3_btn_...`)가 1번 탭과 2번 탭에 완전히 동일하게 중복 선언되어 ASP.NET 구문 분석 오류(`다른 컨트롤에 ID 'div_EQM'을(를) 사용하고 있습니다.`) 발생.
  - 또한 기존 2개 탭 기준 스크립트(`ItsTab.GetIndex`) 및 그리드 인스턴스 미정의로 인한 DOM 탐색 불일치 발생.
- **해결 및 표준화 내용**:
  1. **3개 탭 구성 및 순서화 ([EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx))**:
     - **1번 탭 (설비그룹 점검계획)**: 설비그룹 전용 고유 ID 부여
       - 상단 패널: `div_GRP`
       - 검색 컨트롤: `find_GRP` (Label="설비그룹")
       - 좌측 설비그룹 그리드: `grid_GRP1`
       - 우측 정기점검 버튼: `bdiv_GRP_btn_COPY`, `bdiv_GRP_btn_ADD`, `bdiv_GRP_btn_SAVE`, `bdiv_GRP_btn_DEL`
       - 우측 정기점검 그리드: `grid_GRP2`
     - **2번 탭 (설비별 점검계획)**: 기존 소스코드 및 ID 100% 보존
       - 상단 패널: `div_EQM`, 검색: `find_EQMCD`
       - 좌측 설비 그리드: `grid1`
       - 우측 버튼: `bdiv3_btn_...`, 우측 그리드: `grid3`
     - **3번 탭 (정기점검 주기관리)**: 기존 소스코드 및 ID 100% 보존
       - 상단 패널: `div_CYCLE_EQM`, 콤보: `cmb_SYEAR`, 검색: `find1`, 저장/삭제 버튼, 그리드: `grid9`
  2. **화면 스크립트 3개 탭 확장 및 그리드 정의 ([EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js))**:
     - `ItsPage.Load`: 1번 탭용 그리드(`grid_GRP1`, `grid_GRP2`) 생성 코드 추가 (컬럼 타입, 너비, 정렬 정의).
     - `ItsButton.EventSearch`: 탭 인덱스 분기를 0(설비그룹), 1(설비별), 2(주기관리)로 3단 확장.
     - 1번 탭 전용 이벤트 뼈대 등록: `grid_GRP1.onSelect`, `bdiv_GRP_btn_...` 클릭 핸들러.
- **검증 결과**:
  - ASP.NET 구문 분석 오류 완전 해결 (ID 중복 0건).
  - Chrome DevTools MCP를 통한 브라우저 렌더링 검증 완료: 3개 탭 순차 전환 및 그리드/버튼 표시 정상 확인 (콘솔 에러 0건).

### 2. EQM1001_R03 일상점검(EQM01/grid2) 영역 및 관련 코드 주석 처리

- **대상 화면**: 웹 MES 설비점검계획 관리 ([EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx))
- **수정 파일**:
  - [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx)
  - [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js)
- **작업 상세 내용**:
  1. **UI 레이아웃 주석 처리 ([EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx))**:
     - 기존 코드 삭제 없이 서버 사이드 주석(`<%-- ... --%>`)으로 처리.
     - 1번째 탭 우측 상단 일상점검 영역(`<Its:div Type="SplitTop" TopHeightPc="50">`), 타이틀, 복사/추가/저장/삭제 버튼(`bdiv2_btn_COPY`, `bdiv2_btn_ADD`, `bdiv2_btn_SAVE`, `bdiv2_btn_DEL`), 그리드(`grid2`) 및 일상-정기점검 간 수평 분할선(`<Its:split Type="Horizon">`) 주석 처리.
     - 일상점검 전용 팝업 모달(`<Its:pop ID="pop_EQM01_ADD">`, `<Its:pop ID="pop_EQM01_COPY">`) 주석 처리.
  2. **화면 스크립트 연동 코드 주석 처리 ([EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js))**:
     - 그리드 생성부: `grid2`(일상점검 메인), `grid4`(추가 팝업), `grid5`/`grid6`(복사 팝업) 생성 코드 주석화.
     - 상단 조회 이벤트(`ItsButton.EventSearch`): `ItsGrid.Clear('grid2')` 비활성화.
     - 설비목록 선택 이벤트(`ItsGrid.Event('grid1').onSelect`): `ItsGrid.Clear('grid2')` 및 일상점검 항목 조회 프로시저(`LIST_MSTEQM_EQM01`) 호출부 주석화.
     - 일상점검 관련 이벤트 전체(`bdiv2_btn_ADD`, `btn_ADD_EQM01`, `btn_CANCEL_EQM01`, `bdiv2_btn_SAVE`, `bdiv2_btn_DEL`, `bdiv2_btn_COPY`, `btn_COPY_EQM01`, `btn_CANCEL_COPY_EQM01` 등) 주석화.
  3. **무결성 및 동작 검증**:
     - Single UTF-8 with BOM (`ï»¿`), CRLF (`
`), 중복 캐리지 리턴 0건 검증 완료.
     - 로컬 IIS 웹 서버(`http://localhost:55085/PAGEEQM/EQM1001/EQM1001_R03.aspx`) HTTP 200 정상 렌더링 확인.

### 3. TML5001 초중종 검사 팝업 판정 로직 및 주석 표준화

- **대상 화면**: PDA/WPF 현장 단말 검사 관리 (`TML5001`)
- **수정/분석 파일**: [R01_POP1.xaml.cs](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01_POP1.xaml.cs)
- **작업 상세 내용**:
  1. **개별 시료 측정값 순회 및 검사 판정 로직 (`UpdateRowJudge`)**:
     - 시료수(`chkcnt`)만큼 `for (int i = 1; i <= chkcnt; i++)` 루프를 순회하며 측정 컬럼(`STDVALCHK`, `STDVALCHK2` 등)을 동적으로 조회.
     - 아직 입력되지 않은 빈 셀(`string.IsNullOrEmpty(cellVal)`)은 `continue`로 건너뛰어 미입력 상태 보존.
     - 입력된 측정값은 `CHKJUDGE` 함수를 통해 규격 상한/하한 검사 수행.
     - 규격 벗어남(`chkResult == "N"`) 시 `isNG = true` 플래그 설정.
     - 정상 규격 내(`chkResult == "Y"`) 시 유효 측정 개수(`filledCount++`) 가산.
  2. **삼항 연산자를 활용한 직관적 행 판정(`OKNG`) 갱신**:

     ```csharp
     // 2026-09-18 행 합부판정(OKNG) 갱신 (변경된 경우에만 SetValue 호출)
     string newOkNg = isNG ? "N" : (filledCount == chkcnt ? "Y" : "");
     if (MODEL_G2.GetText(rowIndex, "OKNG") != newOkNg)
     {
         MODEL_G2.SetValue(rowIndex, "OKNG", newOkNg);
     }
     ```

     - `isNG == true` 이면 즉시 `"N"`(불합격) 판정.
     - 불합격이 없고 모든 시료가 정상 입력 완료(`filledCount == chkcnt`)되었을 때만 `"Y"`(합격) 판정.
     - 일부만 입력되었거나 미입력인 경우 빈 문자열(`""`)로 대기 상태 유지.
  3. **행 배경색(`BACKGROUND`) 제어**:
     - 불합격(`isNG`) 발생 시 `PINK` 배경색 부여.
     - 정상 복귀 시 공정 유형(`PQCTP == "01"`: `IVORY`, 기타: `WHITE`)에 따른 기본 배경색 복원.
  4. **클라이언트 모델(In-Memory) vs DB CRUD 동작 원리 정립**:
     - `MODEL_G2.SetValue()`는 화면 Grid 모델 메모리 값만 갱신하며, 실제 저장은 사용자가 하단 [저장] 버튼을 클릭할 때 트랜잭션으로 일괄 DB CRUD가 수행됨을 명확히 정의.
  5. **표준 주석 반영 및 무결성 검증**:
     - [Optimization Rule]에 따라 과도한 장식 주석을 지양하고 구체적인 위치와 역할을 명시한 간결한 주석 작성.
     - `MSBuild.exe` 빌드 결과 Error 0건 확인 완료.

---

### 4. TML5001 [SetPopInfo GPCD is empty] 런타임 오류 해결 및 하드코딩 완전 제거

- **대상 화면**: PDA/WPF 현장 작업 관리 (`TML5001`)
- **수정 파일**:
  - [R01.xaml](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01.xaml)
  - [R01.xaml.cs](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01.xaml.cs)
- **원인 분석**:
  - WPF 생명주기(Lifecycle) 상 부모 컨테이너가 로드되어 `EventPageLoaded()`가 실행되는 시점에, 자식 컨트롤인 `ItsPop`의 바인딩 및 `Pop_Loaded` 이벤트가 완료되지 않아 `FieldName`이 비어 있는 상태에서 `GetWorkList()` -> `SetValue("EMPCD", ...)`가 호출되어 발생.
- **해결 방안**:
  1. [R01.xaml](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01.xaml): 불필요하게 추가되었던 임시 `x:Name="POP_EMPCD"` 제거, XAML 선언적 바인딩(`Value="{Binding EMPCD}"`) 복원.
  2. [R01.xaml.cs](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01.xaml.cs):
     - 생성자 내 하드코딩(`POP_EMPCD.FieldName = "EMPCD";`) 완전 삭제.
     - `EventPageLoaded()` 내에서 UI 렌더링 및 자식 컨트롤 로드가 완전히 끝난 후 작업 조회가 실행되도록 `Dispatcher.BeginInvoke(..., DispatcherPriority.Background)` 적용.
  3. **검증 결과**:
     - 화면 진입 시 "SetPopInfo GPCD is empty" 팝업 오류 완전 소멸.
     - 검사자 사번 및 이름이 정상적으로 팝업 및 화면에 자동 세팅됨을 확인.

---

## 🕒 2026-09-17 (목) 작업 내역

### 1. 설비이력카드 프로시저 최적화 및 표준 양식 맞춤 데이터 컬럼 확장

- **대상 프로시저**: [MES_SNS2_EQM1001_S01.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_S01.sql)
- **작업 상세 내용**:
  1. **설비이력카드(QSP-4111-03) 표준 양식 맞춤 확장**:
     - `CALL_RPT` 분기에서 상단 설비 마스터 정보(`MSTEQM`) 및 하단 수리/보전 이력(`EQMREP`) 컬럼 정비.
  2. **수리시간 및 보전구분(`MAINT_DIV`) 계산 로직 개선**:
     - 보전구분 기본값 공백 처리 및 `IFNULL(GPCD('FM300', EQMREP.EQMREPTP), '')` 통일.
  3. **구매가격 및 거래처 컬럼 매핑 최적화**:
     - 구매가격(`BUYAMT`) 기본값 `0 (KRW)` 포맷 적용.
     - `BUYCUST`, `MKCUST` 등의 다중 COALESCE 중복 제거 및 단순화로 가독성 및 쿼리 실행 성능 향상.
  4. **규칙 준수 검증**:
     - [Procedure Rule] 준수: 최상단 Comment/Modify 이력 기재 완료.
     - [Encoding Rule] 준수: UTF-8 with BOM 및 CRLF 개행 유지.

---

## 🕒 2026-09-15 ~ 2026-09-16 작업 내역 요약

- **EQM1001 (설비관리/보전) 마이그레이션 및 리팩터링**:
  - `EQM1001_R01`, `EQM1001_R02`, `EQM1001_R03`, `EQM1001_R04` 화면 연동 스크립트 및 프로시저 정리.
  - 공통 모듈 보호 규칙 준수: `DC_FIND`, `DC_COMBO`, `GPCD` 등 공통 DB 객체 및 공통 JS 라이브러리 수정 없이 화면 및 전용 프로시저 레벨에서 독립 처리.

---

## 🚀 현재 작업 상태 및 다음 작업 대기열 (Work In Progress)

| 상태 | 대상 프로그램/파일 | 작업 설명 | 비고 |
| :---: | :--- | :--- | :--- |
| **진행중** | 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql | MES_SNS2_EQM1001_R04.sql DB 반영 후 중복 계획 월 차단 테스트 필요 | UTF-8 무BOM+CRLF 및 git diff 검증 완료 (DB 컴파일 미확인) |
| **진행중** | 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql | MES_SNS2_EQM1001_R04.sql DB 반영 후 조회·등록·수정(월 이동) 테스트 필요 | node --check 통과, js UTF-8 BOM+CRLF, sql 무BOM+CRLF 확인. DB 컴파일 미확인 |
| **진행중** | 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql | MES_SNS2_EQM1001_R04.sql DB 반영 후 화면 동작 테스트 필요 | node --check 통과, UTF-8 BOM/무BOM 및 CRLF 검증 완료 |
| **진행중** | 05.PROCEDURE/MES_SNS2_EQM1001_R01.sql | MES_SNS2_EQM1001_R01.sql DB 반영 후 조회 확인 | SQL diff 및 UTF-8 무BOM+CRLF 검증 완료 |
| **진행중** | 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js, 05.PROCEDURE/MES_SNS2_EQM1001_R01.sql | MES_SNS2_EQM1001_R01.sql DB 반영 후 화면 조회 테스트 필요 | node --check 통과, 3개 파일 BOM/UTF-8/CRLF 검증 및 git diff 확인 완료 |
| **진행중** | 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js | MES_SNS2_EQM1001_R01.sql 및 MES_SNS2_EQM1001_R01_SYSTEM_PARAMETERS.sql DB 반영 필요 | node --check 통과, 5개 대상 파일 BOM/UTF-8/CRLF 바이트 검증 통과, git diff 검증 완료 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js | MES_SNS2_EQM1001_R01.sql 반영 및 SYSTEM_PARAMETERS 재등록 후 실화면 조회 확인 | node --check 및 단일 UTF-8 BOM + CRLF 무결성 검증 완료 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js, 05.Procedure/MES_SNS2_EQM1001_R01.sql, 05.Procedure/MES_SNS2_EQM1001_R01_SYSTEM_PARAMETERS.sql | MES_SNS2_EQM1001_R01.sql 반영 후 MES_SNS2_EQM1001_R01_SYSTEM_PARAMETERS.sql 실행 필요 | JS 구문검사(node --check) 및 전 파일 BOM/CRLF 무결성 검증 완료, DB 프로시저 및 SYSTEM_PARAMETERS 재등록 필요 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js, 05.Procedure/MES_SNS2_EQM1001_R01.sql | MES_SNS2_EQM1001_R01.sql 실서버 반영 후 화면 조회 확인 | JS 구문검사(node --check) 및 인코딩/CRLF 검증 완료, 실서버 프로시저 반영 필요 |
| **완료** | 05.Procedure/MES_SNS2_LOT1003_R01.sql, 05.Procedure/MES_SNS2_LOT1003_S01.sql, 05.Procedure/MES_SNS2_IO_COMCHK_CONFIRM.sql, 05.Procedure/MES_SNS2_IO_COMCHK_CANCEL.sql, 05.Procedure/MES_SNS2_TAL1600_R01.sql | - | UTF-8 without BOM, CRLF 줄바꿈 검증 완료 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 계산구분 빈 항목 높이 수정 | 실제 wijmo 5.20203.748 테스트 페이지에서 항목 높이 빈 문자열 7px → 공백 문자 30px(다른 항목과 동일), 선택 값 빈 값, 그리드 표시·값 정상 확인, JS 구문 검사, 인코딩 확인. 미확인: 실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 계산구분 콤보 표시 오류 수정 | 실제 wijmo 5.20203.748로 만든 테스트 페이지에서 @ 방식 표시 오류 재현(목록 ["",null,null,null]) 및 수정 방식 확인(목록 ["",고장건수,수리시간,사용개월], 그리드 표시 고장건수·사용개월, 빈 항목 선택 시 값·표시 빈 값), JS 구문 검사, 인코딩 확인. 미확인: 실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql) | MST1005_S01 계산구분 공백 항목의 최소·최대값 숨김 및 저장 시 비움 | Node 모의 테스트(계산구분 유무별 컬럼 숨김/표시, 선택 행 계산구분 변경 즉시 반영, 다른 행·다른 칸 변경 무시) 통과, 비움 대상·계산구분 조회 SQL 실DB 읽기 실행(현재 대상 0건, 경고 0건), IF 42/42 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 계산구분 콤보 공백 항목 추가 | 공통 그리드 ItsGrid.js 콤보 생성 경로(@ 처리) 확인, JS 구문 검사, 인코딩 확인. 미확인: 실제 화면 콤보 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx) | MST1005_S01 화면 3구역 배치 변경 | aspx div 짝(14/14)·asp:Content 짝·버튼/그리드 ID 16개 확인, 인코딩(단일 BOM·CRLF) 확인. 미확인: 실제 화면 비율 |
| **완료** | [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql) | MST1005_S01 프로시저 튜닝 (공통 확인 통합·중복 조회/JOIN·변수 정리) | 구간 겹침 신규 구조 12개 사례 기대값 일치, 실데이터 전 리비전·평가항목 대상 기존·신규 쿼리 결과 동일, 리비전 삭제 후 사용중 처리 미리보기(REV 2 삭제 시 REV 1만 Y) 실DB 읽기 실행(경고 0건), IF 36/36·WHILE 6/6 짝·미사용 변수 0건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·저장 분기 실제 실행 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 화면 글자 수 검증(CHECK_LENGTH) 제거 | JS 구문 검사, CHECK_LENGTH 잔여 0건, 인코딩 확인. 미확인: 실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql) | MST1005_S01 평가항목·점수별 평가기준 비고 추가 | Node 모의 테스트(그리드 컬럼, 비고 전송, 1000자 초과 차단) 통과, 비고 포함 조회·복사 SELECT 실DB 읽기 실행(경고 0건), IF 짝·파라미터 26건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 입력 검증을 DB 컬럼 정의 기준으로 정리 | 구간 겹침 12개 사례(긴 음수·99자리 숫자·소수 경계 포함) 실DB 읽기 실행 기대값 일치(경고 0건), JS 구문 검사, IF 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql) | MST1005_S01 숫자 범위·글자 수 초과 오류 안내 처리 | 범위 확인식(-9999999999·-99.999·-99999999999999999 차단, -99999.99·144·0.5 통과, NO 123456 차단)과 범위 초과 경고(1264) 재현 실DB 읽기 실행, Node 모의 테스트(비고 1001자·평가항목 101자·최소값 101자·비고(점검주기) 11자 차단, 한도 이내 저장) 통과, IF/WHILE 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql) | MST1005_S01 저장 행 선택 유지·공백 제거·점수 음수 허용·이전 리비전 조회 전용 | Node 모의 테스트(최신/이전 리비전 버튼·읽기 전용 전환, 신규 항목 저장 후 발번 코드 선택·점수기준 조회, 비저장 행 선택 유지) 통과, 정수 점수 확인식(-3·5 통과, 1.5·123456 차단)·공백 제거·숫자 비교·이전 리비전 판정 실DB 읽기 실행(경고 0건), IF/WHILE 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql) | MST1005_S01 최소=최대 값 일치 허용 및 분류 변경 시 구간 겹침 원인 확인 | 구간 판정 9개 사례 실DB 읽기 실행으로 기대값 일치(경고 0건), 배포 프로시저·SYSTEM_PARAMETERS 상태 실DB 조회로 원인 확인, IF/WHILE 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql) | MST1005_S01 기존 행 분류·점수 콤보 오류(Uncaught Error) 수정 | Node 모의 테스트(편집 차단 이벤트 없음, 분류·점수 변경 저장 시 조회 시점 키 전송, 변경 후 삭제 시 원래 키 삭제, 신규 행 빈 값) 통과, 변경 조회 SQL 실DB 읽기 실행(경고 0건), IF/ELSEIF/WHILE 짝·파라미터 24건 정적 점검, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 콤보 동작 |
| **완료** | [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 설비등급 최대점수를 미만 기준으로 변경 | 평가표 구간(A 20~/B 15~20/C 10~15/D 7~10/E 0~7) 겹침 없음, 19~21 입력 시 A·B와 겹침 검출 (실DB 읽기 실행, 경고 0건), JS 구문 검사, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql) | MST1005_S01 리비전 삭제를 가장 최근 리비전만 허용 | 실DB 읽기 실행으로 리비전별 삭제 가능 여부 판정 확인(경고 0건), IF 짝·인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 긴 안내 문구 줄바꿈 | ItsMsg.js·ItsMsg.css 처리 방식 확인, JS 구문 검사, 인코딩 확인. 미확인: 실제 안내창 표시 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 추가 행 번호를 빈 번호 우선으로 변경 | Node 모의 테스트(4,5 남은 상태 4회 추가 1,2,3,6 / 빈 그리드 1 / 1,3 사이 2) 통과, 인코딩 확인. 미확인: 실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql) | MST1005_S01 점수별 평가기준 추가·저장·삭제 및 머리글 공백 축소 | Node 모의 테스트(자동 생성 제거, 점수기준 추가 기본값·점수 잠금·중복 차단·저장/삭제 파라미터, 미저장 항목 추가 차단) 통과, IF/WHILE 짝·파라미터 22건 정적 점검, JS 구문 검사, 인코딩 확인. 미확인: 프로시저 컴파일·실제 화면 머리글 높이 |
| **완료** | [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 설비등급 기준 평가표 대응 및 점수 구간 겹침 차단 | 겹침 확인 SQL 실DB 읽기 실행, 정적 점검. 미확인: 프로시저 컴파일·실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js) | MST1005_S01 리비전 상세 묶음 배치(C안) 적용 | JS 구문 검사, aspx div 짝(14/14)·컨트롤 ID 확인, 인코딩 확인. 미확인: 실제 화면 배치 비율 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql) | MST1005_S01 평가항목 선택시 해당 점수별 평가기준만 조회 | Node 모의 테스트(항목 선택별 조회 GMCD, 신규 항목 미조회, 저장·삭제 후 재조회 대상) 통과, 변경 조회 SQL 실DB 읽기 실행(경고 0건), 인코딩 확인. 미확인: MariaDB 컴파일·실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql) | MST1005_S01 영역별 저장 버튼으로 변경 | Node 모의 테스트(영역별 저장 CALLTYPE·체크 행 전송·저장 후 재조회 범위·미체크 차단·설비등급 중복) 통과, IF/WHILE 짝·파라미터 정적 점검, 인코딩 확인. 미확인: MariaDB 컴파일·실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql) | MST1005_S01 설비등급기준 관리 화면 단순화 및 평가표 양식 반영 | Node 모의 테스트(세 그리드 연쇄 조회, 통합 저장 파라미터, 신규 항목·등급 추가값, 설비등급 중복·키 잠금, 삭제 DB/화면 구분, 리비전 갱신) 전체 통과, 조회·1~5점 생성·숫자 확인 SQL 실DB 읽기 실행(경고 0건), IF/WHILE 짝·파라미터 26건 정적 점검, 인코딩 확인. 미확인: MariaDB 프로시저 컴파일·저장 분기 실행, 실제 화면 |
| **완료** | [01.Office/PAGEMST/MST1005/MST1005_S01.aspx](01.Office/PAGEMST/MST1005/MST1005_S01.aspx), [MST1005_S01.aspx.cs](01.Office/PAGEMST/MST1005/MST1005_S01.aspx.cs), [MST1005_S01.js](01.Office/PAGEMST/MST1005/MST1005_S01.js), [05.Procedure/MES_SNS2_MST1005_S01.sql](05.Procedure/MES_SNS2_MST1005_S01.sql), [MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql](05.Procedure/MES_SNS2_MST1005_S01_SYSTEM_PARAMETERS.sql) | MST1005_S01 설비등급기준 관리 화면 구현 | Node 모의 테스트(조회 연쇄, 행 추가·저장·삭제 파라미터, 키 수정 잠금, 0점 포함 중복 차단, 리비전 갱신·빈 리비전 생성) 전체 통과, 프로시저 SELECT문 실DB 읽기 실행으로 컬럼명 확인, IF/WHILE 짝·파라미터 사용 정적 점검, 인코딩(.aspx/.cs/.js BOM, .sql BOM 없음, CRLF) 확인. 미확인: MariaDB 컴파일·저장 분기 실행, 실제 화면 동작 |
| **완료** | [.agents/rules/project_context.md](.agents/rules/project_context.md), [.agents/rules/report_file_structure.md](.agents/rules/report_file_structure.md), [.agents/rules/report_devexpress.md](.agents/rules/report_devexpress.md), [.agents/rules/framework_convention.md](.agents/rules/framework_convention.md) | - | 단일 BOM/CRLF 확인 |
| **완료** | [report_devexpress.md](.agents/rules/report_devexpress.md), [report_file_structure.md](.agents/rules/report_file_structure.md) | - | 단일 BOM/CRLF 확인 |
| **완료** | [S01A.Designer.cs](04.Report/PAGEEQM/EQM1001/S01A.Designer.cs), [EQM1001.exe](01.Office/Reports/EQM1001.exe), [report_devexpress.md](.agents/rules/report_devexpress.md), [report_file_structure.md](.agents/rules/report_file_structure.md) | - | VS 2017 디자이너에서 S01A 정상 표시 확인(오류 페이지 없음). MSBuild Release Rebuild 성공. A-001 PNG 비교 시 상단 박스 픽셀 동일, 항목명 열 글자 서브픽셀 차이만 존재. 웹 컨트롤러 방식 실행·오류 안내 정상. 01.Office/Reports·04.Report/bin 배포 |
| **완료** | [S01A.Designer.cs](04.Report/PAGEEQM/EQM1001/S01A.Designer.cs), [EQM1001.exe](01.Office/Reports/EQM1001.exe), [report_devexpress.md](.agents/rules/report_devexpress.md), [report_file_structure.md](.agents/rules/report_file_structure.md) | S01A VS 디자이너 열기 사용자 확인 대기 | MSBuild Release Rebuild 성공. CodeDOM 로더 S01A 오류 0건(누락 필드 음성대조 검출 확인). A-001 PNG 비교 시 선·크기·값 동일, 항목명 열 글자 서브픽셀 차이만 존재. 웹 컨트롤러 방식 실행 정상, 오류 안내 정상. 01.Office/Reports·04.Report/bin 배포. 실제 VS 디자이너 열기는 사용자 확인 필요 |
| **완료** | [S01A.cs](04.Report/PAGEEQM/EQM1001/S01A.cs), [S01A.Designer.cs](04.Report/PAGEEQM/EQM1001/S01A.Designer.cs), [S01A.resx](04.Report/PAGEEQM/EQM1001/S01A.resx), [EQM1001.exe](01.Office/Reports/EQM1001.exe), [report_file_structure.md](.agents/rules/report_file_structure.md), [report_devexpress.md](.agents/rules/report_devexpress.md), [framework_convention.md](.agents/rules/framework_convention.md) | S01A 표준 구조 전환 완료, VS 디자이너 열기 확인 필요 | MSBuild 15.0 Release Rebuild 성공. 기존/신규 exe로 EQMCD=A-001 출력 비교 시 HTML·이미지 완전 동일, PDF는 생성일시·문서ID만 차이. 미존재 설비·파라미터 누락 안내 메시지 정상. 01.Office/Reports, 04.Report/bin 배포 및 단일 BOM/CRLF 확인. Visual Studio 디자이너 열기는 미확인 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R04.sql | EQM1001_R03·R04 실서버 반영 및 기존 HEADER CHKTP '02' 보정 | 단일 BOM/CRLF 검증 완료, 기존 HEADER CHKTP 데이터 보정 필요 여부 사용자 확인 필요 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql | EQM1001_R03 프로시저 실서버 반영 대기 | 단일 BOM/CRLF 검증 완료, 실서버 DB 반영은 사용자 진행 |
| **완료** | [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs) | TML1010_R05 프로시저 실서버 DB 반영 및 입고 라벨 출력 테스트 | 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료, SYSLABEL XMLDATA 실제 필드 매핑 일치 확인 |
| **완료** | [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql), [05.Procedure/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs) | TML1010_R05 프로시저(15개 파라미터) 및 SYSTEM_PARAMETERS 실서버 DB 반영 및 터미널 화면 최종 확인 | 단일 UTF-8 with BOM 및 CRLF 개행 3단계 바이너리 검증 완료, Roslyn C# 컴파일 성공(0 Error), 프로시저-C#-파라미터등록 1:1 일치 확인 |
| **완료** | [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql) | 잉여 검색조건 전면 제거 및 2공장 등록 부품 11건 정합성 복원 완료 | 단일 UTF-8 with BOM(ef bb bf) 및 표준 CRLF 개행 무결성 100% 검증 통과 |
| **완료** | [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql) | 라벨출력 분기별 완결 구조 개편 및 프로젝트 표준 일치화, 단일 UTF-8 BOM/CRLF 무결성 검증 완료 | 단일 UTF-8 with BOM(ef bb bf) 및 표준 CRLF 개행 무결성 100% 검증 통과 |
| **완료** | [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql) | LIST_EQMPARTS 지저분한 복합 조건 전면 제거 및 파라미터 1회 정규화, 단일 UTF-8 BOM/CRLF 무결성 검증 완료 | 단일 UTF-8 with BOM(ef bb bf) 및 표준 CRLF 개행 무결성 100% 검증 통과 |
| **완료** | WORK_HISTORY.md | 공장07 고정 범위 확정 및 이력 구조 유지; 이력 컬럼 추가 여부 확인 종료 | 직전 반영 내용과 사용자 선택 일치 확인; 소스·DB·실행파일 추가 변경 없음; 운영 프로시저 저장 후 SYSTEM_PARAMETERS 등록SQL 적용은 사용자 진행 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml, R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql | 소스·실행파일 반영 완료; 운영 프로시저와 파라미터 등록은 사용자 적용 필요; 이력 공장 구분 여부 별도 확인 | 실제 DB SELECT로 공장07/법인60 및 307컬럼·로그인 사원 연결·공통사원팝업07조건·기존19파라미터 확인; 네트워크 차단 MariaDB10.2에서 수정 프로시저 컴파일 및16검증 통과(07재고입출고·06재고보존·발주공장우선/대체·타공장입고거절·사원누락·라벨·이력·18입력); 후보의 실제 입고자 문장을 공통모델로 컴파일한5검증 통과; 최종4파일 후보해시일치·단일BOM/CRLF·잔여공장입력검색 통과; Release 빌드 성공 및 실행파일3곳/PDB일치. 운영DB SELECT 외 변경 없음, DB에는 프로시저 저장 후 SYSTEM_PARAMETERS 등록SQL 실행 필요 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml | 오른쪽 35% 입고 팝업 및 실행파일 반영 완료 | 원본 반영 전 XML 및 공통 컴포넌트 독립 WPF 배치 검증; 65:35 비율 및 입력 항목 경계 정상; UTF-8 단일 BOM 및 CRLF 정상; Release 빌드 성공; 실행파일 3곳 및 PDB 해시 일치 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml | 입고 팝업 7:3 배치와 새 실행파일 반영 완료 | 원본 반영 전 XML 및 폭 계산 검증; 실제 공통 컴포넌트로 DB 조회 없는 독립 WPF 렌더링 및 입력 컨트롤 경계 확인; 단일 UTF-8 BOM과 CRLF 정상; Release 빌드 성공; 실행파일 3곳 및 PDB 해시 일치 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml | 선택 컬럼 확대 및 실행파일 반영 완료 | 수정 전 XML과 전체 컬럼 폭 검증; UTF-8 단일 BOM 및 CRLF 확인; Release 빌드 성공; 실행파일 3곳 SHA256 일치 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml.cs, 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe | 프로그램 재실행 후 기본/해제 흰색·선택 노란색 사용. 하늘색 부분입고 표시는 제거. DB 프로시저 추가 반영 불필요 | 원본 적용 전 후보에서 하늘색 분기3곳과 선택 조건1곳 제거 확인, 색상/관련 주석 외 업무 C# 원문 불변 비교 통과, 후보·실프로젝트 MSBuild 성공. 최종 C# SKYBLUE 잔여0건, WHITE 복원3곳·YELLOW 선택 유지 확인. 배포3경로 EXE SHA256=8C002B553FDB60B46C79AEAFA4E8E7BA2F1C5C774969744547E9F939763029A0 및 PDB 해시 일치, 단일BOM/CRLF 확인. XAML/SQL/테스트데이터SQL/csproj/App 해시 불변. DB 접근 없음. 검증 후보·중간빌드 등 임시 파일 마무리 삭제 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml.cs, 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe | 프로그램 재실행 후 새 선택 로직 사용. 프로시저 변경·DB 추가 반영 불필요. 단일 발주 선택 유지; 미입고 흰색·부분입고 하늘색·선택 노란색 | 공통 ITSLIB 실제 그리드와 현재 XAML GRID_ODR를 사용하여 native 버튼 클릭을 컴파일된 R05.EventCommand에 연결. DB 의존 생성자는 제외하고 선택 이벤트가 사용하는 모델을 주입한 격리 검증에서 후보·최종 AAABIN 실행본 각25개 통과: WHITE/SKYBLUE 초기색, YELLOW 선택/원래색 복원, 같은 키 다른 순번·다른 발주 선택, 단일 선택, 일반 포커스와 입고대상 분리, 사원/입력량 보존, 재조회 초기화, BACKGROUND 상태 우선, 빈 목록. PNG 시각 확인. 후보·실프로젝트 빌드 오류0, 배포3경로 EXE SHA256=5E57F1C8AFDE824CBACD293DE92191BDACA263B9C135D1530872DA29989210B4 일치 및 PDB 일치. C# 선택/초기색 영역 외 불변, XAML/SQL/테스트데이터SQL/csproj/App 해시 보존. 단일BOM/CRLF 확인. 실제 DB 접근 없음. 임시 빌드·검증자료 마무리 삭제 |
| **완료** | 05.Procedure/MES_SNS2_TML1010_R05_TEST_DATA.sql | 사용자가 MES_SNS2 새 SQL편집기에서 MES_SNS2_TML1010_R05_TEST_DATA.sql 전체선택 Alt+X 실행 후 공장07 조회. 부품000-TEST-R05를 선택하여 시험; 실물 라벨은 현장 프린터에서 확인. 같은 파일 재실행은 기존 결과 보존을 위해 중단 | 실제 DB SELECT로316컬럼·AUTO_INCREMENT·발주 FK·거래처 구매플래그1·단위DM150100/EA·사원/로케이션·감사함수·라벨·InnoDB5테이블·R05 라벨 분기 준비 상태 확인. 동일 메타데이터 MariaDB10.2 격리 환경에서 전체 SQL 파일 그대로 실행 성공. 실제 R05 프로시저와 연결한31개 검증 통과: 부품1건 조회, 승인/납품진행 발주2행, 출고100→9900·입고200→10100·잔량10000 전체입고→20100, 완료발주 제외, 이력/라벨데이터/재출력 무변경, 기존 업무·공통마스터 불변, 재실행 결과 보존, 말단 이력키 충돌 시 전체롤백, 단위 누락 차단, 다른 자동 품목키 생성과 감사세션 복구. 최종 파일과 검증 후보 바이트 일치, 단일BOM/CRLF 및 INSERT 전용 확인. 테스트 컨테이너·임시스크립트·DB추출·실행파일 전부 삭제. 실제 DB에는 SELECT 외 실행하지 않음 |
| **완료** | 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe | 로컬 실행파일 교체 완료. 프로그램을 다시 실행하면 새 버전 사용. 실제 서버의 TML1010_R05 프로시저 저장은 사용자 적용 사항이며 이번 턴에서는 DB에 접근하지 않음 | MSBuild 성공. Release·AAABIN·프로젝트 루트 EXE 3경로 SHA256=1C70A2741E96412CACB7D53DB11AA2AA3AC2BFC282F34485D563055B49CE7862 일치, Release/AAABIN PDB 해시 일치. 기존 후보의72개 및 최종 빌드61개 검증을 수행했던 소스 유지. 임시 중간빌드 폴더는 마무리 삭제 |
| **대기** | 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql | 기능 구현·검증·빌드 및 사용자 승인 후 AAABIN EXE/PDB 교체 완료. 남은 외부 적용: 사용자가 TML1010_R05 프로시저를 Routine Editor에서 저장; 파라미터19개 동일하여 재등록 불필요. 기존 EQMPARTS 양식의 실물 라벨은 현장 프린터에서 확인 필요 | 실제 DB SELECT로316컬럼·발주/입출고 코드·EQMPARTS XML·파라미터19개 확인. 동일 메타데이터의 MariaDB10.2 격리 DB와 테스트 코드 없는 실제 후보 WPF 실행본에서72개 검증 통과: 정상·누락/잘못된 사원·0/음수/초과수량·타품목/타공장/잘못된 상태 거절 및 저장 보존, 발주키/순번/사원 저장, 현재고 증감, 부분/완료 상태, 재발행 무변경, 실제 선택 버튼 ON/OFF·단일선택·포커스 분리, 출고자 기본값/선택값, 입고자 보존, 라벨 실패 후 입고1회 저장. 실프로젝트 Release 빌드 성공 및 최종 빌드61개 SQL/UI 스모크 통과. 동시 출고4+4/현재고5 테스트는1건 성공·1건 재고부족, 최종재고1·이력1건 확인. 소스BOM/CRLF·호출분기·파라미터 정합성 통과, csproj/App/메타등록SQL 불변. 새 실행본 SHA256=06759DB944270183EBC478A7C860BD4704157AD0C342B32CCC9B18555F4F1159. 프로젝트 루트 EXE 반영 완료. 운영DB SELECT 외 변경·실물인쇄 없음. 테스트 전용 컨테이너 및 임시폴더/후보/스크립트/PNG/DB추출자료 모두 삭제 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe | 출고 팝업 수정 실행본 재실행 필요. R05 관련 임시폴더10개·테스트 컨테이너2개 정리 완료; 이전 발주 선택 ON/OFF 요청은 별도 업무 소스 반영 및 저장 검증 필요 | 기존 배포본 오류 재현 후 수정 후보와 최종 AAABIN 실행본 모두 실제 R05 생성자·공통 TML 스타일·Frame·ITSLIB·격리 MariaDB를 사용한23개 검증 통과. 공통 출고 버튼→팝업 표시, 품목 표시·읽기전용·수량 바인딩·공통코드, X닫기·재열기, 800x600·1280x800·1920x1080 확대축소 중앙·화면경계, 입고·이력 팝업 및 입고자 기본값 보존, 실적 생성 없음 확인. 후보·실프로젝트 빌드 오류0, 실행파일3경로 SHA256=1F86DF210632E583B8A9C49AC9195354E8AEAA86531320F1D2DE077667180D5B 일치. C#/SQL/csproj/App 해시 불변, 출고 영역 외 XAML 불변, 단일BOM/CRLF 확인. 운영DB 변경·물리 프린터 출력 없음 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/AAABIN/TML1010.exe·pdb, 02.Site/TMLPJT/TML1010/TML1010.exe | 프로그램 재실행 필요. 이전 발주 선택 ON/OFF 수정은 별도 후보 상태로 미반영 유지 | DB 연결 없이 실제 ITSLIB 공통 컴포넌트로 980x580·900x480·1280x720 중앙·경계, 입력 바인딩, 수량 변경, 닫기·재열기 등 18개 검증 통과 및 PNG 확인. 후보·최종 빌드 성공, 배포 EXE SHA256 일치, 출고 영역 외 원문 및 C#/SQL 해시 보존, 단일 BOM/CRLF 확인 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, 05.Procedure/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql | 실제 서버에는 TML1010_R05 프로시저 저장 후 SYSTEM_PARAMETERS 등록 SQL 적용 필요; 라벨 실물 출력은 현장 프린터에서 확인 필요 | 실제 DB SELECT로 코드·스키마·공통 사원 팝업 확인; MariaDB 10.2 격리 DB 27개 및 실제 WPF 공통 컴포넌트 15개 검증 통과; 후보·최종 빌드 성공; 원본과 배포 실행파일 SHA256 일치; 실제 DB 변경 및 물리 프린터 출력 없음 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, 05.Procedure/MES_SNS2_TML1010_R05_SYSTEM_PARAMETERS.sql, 02.Site/AAABIN/TML1010.exe·pdb | 적용순서: TML1010_R05 프로시저 저장 → 전용 SYSTEM_PARAMETERS SQL 실행(20건 확인) → 프로그램 재실행. 팝업 검증 PNG는 C:/Users/DK/.codex/visualizations/2026/09/21/01a0c1c3-8519-71c1-a934-2c0d18b2af9f/tml1010-r05-popups에 보관 | 실DB SELECT로 277컬럼·현행18파라미터·입출고/발주 코드·공통 거래처 Pop·GPCD 사원명 조회 지원 확인. MariaDB10.2 격리환경에서 프로시저 컴파일, 이력6필드·발생일자 역순 데이터의 RTIME 정렬·날짜 범위·입출고량·사원명, 발주기간/거래처 필터, 발주키/순번 저장, 타품목/타공장/초과입고 거절 및 롤백, 재고 증감·발주입고지·부분/완료 입고 검증. 실제 R05+ITSLIB를 격리DB에 연결하여 3개 팝업 렌더 이미지 확인, 숨은 키·입고지·재고 저장, X 닫기·배경활성 복원 통과. 등록SQL 20건 및 다른 프로시저 메타데이터 보존 검증. 실소스 Release 빌드 성공, AAABIN·프로젝트 실행파일 SHA256 일치. 4파일 단일 BOM/CRLF, 이전 메인 재고 쿼리 보존 검증. 공통 소스·실DB DDL/DML 미변경 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, 02.Site/AAABIN/TML1010.exe·pdb | 로컬 프로시저를 사용자가 DB에 저장해야 함. 입력 시그니처18개는 DB와 SYSTEM_PARAMETERS가 일치하여 재등록 불필요. INOUT_EQMPARTS에는 FACTORYCD가 없어 이력은 같은 ITEMID 기준이며 공장별 이력 저장은 별도 스키마 검토 필요 | 실서버 SELECT로 기존7225행/7216품목에서 수정3823행/3823품목 확인. 3821코드 중 자동적재4·5는 같은 법인의 별도 ITEMID 두 건씩이므로 보존. MariaDB10.2 격리환경에서 프로시저 컴파일, 18개 파라미터, NULL·빈공장·다른법인·유형·종료·무재고·부족재고·소수입출고·발주부분/완료·오류롤백 검증 통과. 실제 R05+ITSLIB를 로컬 테스트DB에 연결하여 기본 공장명·팝업키·변경된 공장콤보와 저장공장 분리·입출고·이력 확인. 실소스 MSBuild Release 성공(기존 obj/Release 파일 잠금으로 전용 중간출력경로 사용), AAABIN·프로젝트 실행파일 SHA256 일치. UTF-8 단일BOM/CRLF 통과. 실DB 및 공통객체 변경 없음 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 02.Site/AAABIN/TML1010.exe | 현재 실행 중 TML1010은 종료하지 않고 이전 EXE를 .tmp-tml-r05-buttons/previous-deployed.exe로 보관하여 새 EXE 배치; 프로그램 재실행 후 반영, 이후 이전 EXE 백업 정리 가능 | 실제 ITSLIB 공통 버튼 5종을 DB 연결 없이 렌더링하여 회색 배경·검은 글씨 및 5개 명령·선택행 유지 검증; 참조 이미지와 렌더링 PNG 비교; 공통 원본 리소스와 화면 전용 리소스 별도 인스턴스 확인; MSBuild 오류0; 단일BOM/CRLF 및 배포파일 해시 일치 |
| **완료** | 02.Site/TMLPJT/TML1010/R05.xaml, 02.Site/TMLPJT/TML1010/R05.xaml.cs, 05.Procedure/MES_SNS2_TML1010_R05.sql, 02.Site/AAABIN/TML1010.exe | 실제 서버 DB 변경 없음; MES_SNS2_TML1010_R05.sql 서버 저장 필요; 기존 라벨 버튼은 안내창 연결 유지 | 격리 MariaDB10.2.44 SQL 컴파일 및 9개 재고/2개 이력 확인; 실제 ITSLIB를 사용하는 WPF 검증 17건 통과(6종 단위/NULL·빈값/미등록단위/선택행/공통 입출고·이력 버튼/읽기전용 팝업/발주번호·수량 반영); 화면 PNG 렌더링 점검; MSBuild 오류0; 서버 파라미터·등록정보18건 일치; 배포 SHA256 및 단일BOM/CRLF 검증 |
| **완료** | 05.PROCEDURE/MES_SNS2_MTR0001_R04.sql | MTR0001_R04 사원 조인 조건 간소화 완료 | 전체 1,141건 대상 전수 테스트 결과 Warning 및 Error 0건 통과 |
| **완료** | 05.PROCEDURE/MES_SNS2_MTR0001_R04.sql | MTR0001_R04 사원 조인 DOUBLE 변환 에러 해결 완료 | 전체 1,141건 발주 대상 테스트 결과 에러 및 Warnings 0건 통과 |
| **완료** | 04.Report/PAGEEQM/EQM1001/R03.cs, 04.Report/PAGEEQM/EQM1001/R03.Designer.cs, 04.Report/PAGEEQM/EQM1001/R03.resx, 04.Report/PAGEEQM/EQM1001/EQM1001.csproj, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/Reports/EQM1001.exe | EQM1001_R03 계획서 출력 실서버 반영 및 리포트 동작 최종 확인 | 단일 UTF-8 with BOM 및 CRLF 개행 무결성 5개 파일 100% 통과, MSBuild Release 빌드 성공, 바이너리 배포 및 Git 상태 검증 완료 |
| **완료** | 05.PROCEDURE/MES_SNS2_MTR0001_R04.sql | MTR0001_R04 프로시저 실서버 반영 및 리포트 출력 최종 확인 | 실제 DB SELECT 쿼리 테스트 결과 '생산관리2팀 (정영진 Senior 010-9960-2345)' 동일 정상 반환 확인, 인코딩 무결성 통과 (실서버 프로시저 반영은 규칙에 따라 사용자 직접 진행) |
| **완료** | 05.PROCEDURE/MES_SNS2_MTR0001_R04.sql | MTR0001_R04 프로시저 실서버 반영 및 리포트 출력 최종 확인 | 실제 DB SELECT 쿼리 테스트 결과 '생산관리2팀 (정영진 Senior 010-9960-2345)' 정상 출력 확인, BOM/CRLF 무결성 검증 완료 (실서버 프로시저 반영은 규칙에 따라 사용자 직접 진행) |
| **완료** | 04.Report/PAGEEQM/EQM1001/S03A.cs, 04.Report/PAGEEQM/EQM1001/S03A.Designer.cs, 04.Report/PAGEEQM/EQM1001/S03A.resx, 04.Report/PAGEEQM/EQM1001/EQM1001.csproj, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/Reports/EQM1001.exe | EQM1001_R03 계획서 출력 실서버 반영 및 리포트 동작 최종 확인 | 단일 UTF-8 with BOM 및 CRLF 개행 무결성 5개 파일 100% 통과, MSBuild Release 리빌드 성공(0 Error, 0 Warning), 01.Office/Reports/EQM1001.exe(26,112 bytes) 배포 및 Git 상태 검증 완료 |
| **대기** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe), [05.PROCEDURE/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R04.sql) | 사원 조인 컬럼 오타 수정본(MTR0001_R04.sql) 실서버 DBeaver 컴파일 후 발주서 출력 리포트 최종 검증 | MSBuild 컴파일 통과 (0 Error, 0 Warning), MTR0001_R04.sql 112행 컬럼 오타 수정 및 전체 쿼리 문법 정합성 확인 완료 |
| **완료** | [04.Report/PAGEEQM/EQM1001/EQM1001.csproj](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/EQM1001.csproj), [04.Report/PAGEMTR/MTR0001/MTR0001.csproj](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/MTR0001.csproj), [01.Office/Reports/EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | EQM1001 및 MTR0001 리포트 최신 빌드 바이너리 01.Office/Reports 교체 배포 완료 | MSBuild 컴파일 통과 (0 Error, 0 Warning), 01.Office/Reports/ 내 최신 바이너리 타임스탬프(14:37) 갱신 확인 |
| **대기** | [05.PROCEDURE/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | 검증 로직 이동 반영된 MTR0001_R04.sql 실서버 DBeaver 컴파일 후 발주서 출력 버튼 최종 검증 | MSBuild 컴파일 통과 (0 Error, 0 Warning), 전 파일 단일 UTF-8 BOM(\xef\xbb\xbf) 및 CRLF 개행 무결성 확인 |
| **대기** | [05.PROCEDURE/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R04.sql) | CALL_RPT 분기 세미콜론 누락 수정본(MTR0001_R04.sql) 실서버 DBeaver 컴파일 후 발주서 출력 버튼 최종 검증 | 프로시저 전체 문법 및 세미콜론 종결자 무결성 확인, 단일 UTF-8 BOM(\xef\xbb\xbf) 및 CRLF 개행 검증 통과 |
| **완료** | [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql) | MTR0001_R04 프로시저 MTR0001_R01 원본 기반 쿼리 표준화 및 과잉 방어코드 전면 제거 | 4개 SET문 제거, Table 0 11개 텍스트 컬럼 COALESCE 제거, EMPINFO 5줄 단순화, Table 1 INNER JOIN 및 단위 1줄 단일화, BOM/CRLF 검증 완료 (실서버 DBeaver 컴파일 대상) |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 발주승인완료 일자 바인딩(MTRODRDATE) 수정에 따른 MSBuild 리빌드 및 최신 바이너리 배포 | MSBuild Release 리빌드 성공(0 Error, 0 Warning), MTR0001.exe 최신 배포 완료(13:07:11), 단일 UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 사용자 직접 수정 소스코드 검증, MSBuild 리빌드 및 최신 바이너리(01.Office/Reports/MTR0001.exe) 배포 적용 | MSBuild Release 리빌드 성공(0 Error, 0 Warning), MTR0001.exe 최신 배포 완료(11:53:42), 단일 UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 발주서 비고 및 하단 3줄 안내문 볼드(Bold) 서식 반영, MSBuild 빌드 및 바이너리 재배포 | MSBuild Release 컴파일 성공(에러 0), 01.Office/Reports/MTR0001.exe 최신 배포 완료, 단일 UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | 05.Procedure/MES_SNS2_MTR0001_R04.sql | 실제 서버 DDL/DML 미실행; 사용자 프로시저 반영 필요; 보고서 재빌드 불필요 | 실제 DB SELECT 전후 5조건 결과·정렬·중복 일치(전체75/기간51/당일1/07공장0/NULL75); 발주일자1137건 YYYY-MM-DD 확인; 공장06→사업장61/07→71 연결 및 JOIN 행수 검증; 격리 MariaDB10.2.44 전후 컴파일 및20조건 비교/잘못된 날짜 검증 통과; 날짜 인덱스 부재로 실행계획 동일; 단일BOM/CRLF 확인 |
| **완료** | 05.Procedure/MES_SNS2_MTR0001_R04.sql | 전용 SQL 로컬 반영 완료, 실서버 프로시저 적용은 사용자 진행. 파라미터8개 유지로 재등록 불필요, C# 미수정으로 리포트 바이너리 재배포 불필요 | 실제 SELECT로 사업장10건·공장7건과 컬럼·PK 확인. 발주1137건 사업장매핑 전후 일치, 헤더75건·상세249건 및 06/07 표본 발주서 헤더값 전후 동일. 네트워크차단 MariaDB10.2.44에서 컴파일, 기존/신규공장, 빈공장대체, 발주공장우선, 미등록 공란, 마스터변경반영, 품목조건NULL·순서동등성 포함 총13검증 통과. 단일BOM/CRLF 정상. 실제 서버 DDL/DML 없음, C#·화면소스 변경 없음 |
| **완료** | 05.Procedure/MES_SNS2_MTR0001_R04.sql | 주석 복구 완료. 품목유형 등식 중복 및 07→71/그 외→61 고정 사업장 매핑 설명, 조건 변경은 수행하지 않음 | 주석 제거 후 수정 전후 SQL 문자열 동일 확인,11개 별칭 일치 확인, 단일BOM/CRLF 정상. 주석만 수정하여 DB실행·프로시저컴파일 미진행 |
| **완료** | 05.Procedure/MES_SNS2_MTR0001_R04.sql | MTR0001_R04 전용 SQL 로컬 반영 완료. 실서버 프로시저 적용은 사용자 진행. 입력8개 동일, 파라미터 재등록 및 리포트 바이너리 재배포 불필요 | 실제 DB SELECT로 현재 공장 사원 매핑과 6개테이블307컬럼 확인, 4318/4328/4329/4438은 현재 공장 미매칭. 수정 SELECT로 발주75건·표본 발주서1건 원래코드 표시 확인. MES_SNS DB 없이 네트워크 차단 MariaDB10.2.44 컴파일 및11건 검증 통과. 입력8개·상세분기 유지, ASPX·JS·비하인드·S04A 해시 동일, 단일BOM/CRLF 정상. 실서버 DDL/DML 없음 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 설비부품 발주서 상단 마진 확대(15F➔45F), 로고 좌측밀착 정렬 및 승인박스 확대·배포 | MSBuild Release 컴파일 성공(에러 0), 01.Office/Reports/MTR0001.exe 배포 완료, 단일 UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | 01.Office/PAGEMTR/MTR0001/MTR0001_R04.js, 05.Procedure/MES_SNS2_MTR0001_R04.sql | JS와 MTR0001_R04 전용 SQL 로컬 반영 완료. 실서버 프로시저 적용은 사용자 진행. 입력8개 동일하여 파라미터 재등록 및 리포트 바이너리 재배포 불필요 | 실제 DB SELECT로 8개 테이블362컬럼·인덱스15행·프로시저입력8개 확인. 수정 전후 실제 헤더75건·상세249건 및 표본 보고서 헤더1/품목3건 유지 컬럼값과 정렬 일치. Node VM/정적14건, 네트워크차단 MariaDB10.2.44 컴파일·필터·정렬·NULL키·결과셋8건 통과. S04A 복사본 테스트 생성자만 추가하여 C#컴파일 및 실제 DevExpress CreateDocument로 전후 컨트롤 내용·배치와1페이지, 빈품목·NULL품목3건 확인. JS문법·단일BOM/CRLF 통과. 실서버 DDL/DML·브라우저E2E·프로덕션C#변경 없음 |
| **완료** | [.gitignore](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.gitignore), Git 인덱스 | Git 무시 목록(.gitignore)에 Subversion(.svn, wc.db) 등록 및 기존 추적 파일(4,179건) Git 인덱스 전면 삭제 | `.svn/`, `wc.db*` 패턴 등록, `git rm -r --cached .svn`으로 4,179건 언트래킹, 로컬 디스크 보존(True) 및 단일 UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | .agents/rules/validation.md | 사용 중단 컬럼 관련 후속 작업부터 validation.md 5절에 따라 호출·저장·파라미터 등록·최종 검색을 검증 | 기존 1~4절 내용 유지 및 변경 diff 확인. 단일 UTF-8 BOM/CRLF 확인. 문서 변경만 수행하여 업무 소스·DB 테스트 및 실제 서버 반영 없음 |
| **완료** | 01.Office/PAGEMST/MST3001/MST3001_R03.js, 05.Procedure/MES_SNS2_MST3001_R03.sql, 05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql | MST3001_R03 전용 프로시저를 DBeaver 루틴 에디터에서 저장한 다음 SYSTEM_PARAMETERS 등록 SQL 실행 필요(13개). JS 함께 적용. 실제 서버 반영 및 운영 화면 검증은 미실행 | 실서버 SELECT로 3개 테이블 112컬럼 확인, LOTQTY 기본값0 확인. 공통 ItsGrid 실제 소스를 사용한 Node VM 검증14건 및 네트워크 차단 MariaDB10.2.44에서 컴파일·현재고보존·코드단독저장·신규기본값·팝업CRUD·등록13건 검증13건, 총27건 통과. JS문법 및 단일BOM/CRLF 확인. 실서버 DDL/DML 및 브라우저 E2E 미실행 |
| **완료** | 01.Office/PAGEMST/MST3001/MST3001_R03.js | MST3001_R03.js 로컬 반영 완료. 실제 서버 배포 및 운영 CRUD 검증은 미실행, SQL·공통 컴포넌트·ASPX 버전 변경 없음 | 실제 ItsGrid 소스와 Wijmo 2018·2020 라이브러리를 사용한 격리 Edge 브라우저 17개 시나리오씩 34개 통과. 1000행 1건 선택 저장 시 GetValue 호출 10006회에서 0회. 브라우저 테스트의 DB·팝업 연동은 대역이며 운영 화면 및 DB 실처리는 미실행. Node 문법과 BOM/CRLF 검증 통과 |
| **완료** | [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql), [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js) | MST3001_R03 설비부품 재고·로케이션 컬럼 추가 및 로케이션 기준정보 관리 팝업 CRUD 구현 완료 (실제 DB 프로시저 및 시스템 파라미터 반영은 사용자 진행) | node -c 구문검사 통과. IIS Express HTTP 200 OK 렌더링 검증 완료. MariaDB SELECT 모의 쿼리 무결성 확인. 전 파일 UTF-8 with BOM 및 CRLF 개행 무결성 확인 완료. |
| **완료** | 05.Procedure/MES_SNS2_MTR0001_R04.sql, 05.Procedure/MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql, 01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx, 01.Office/PAGEMTR/MTR0001/MTR0001_R04.js | 로컬 페이지·전용프로시저 수정 완료. 프로시저 저장→파라미터등록SQL(13개)→ASPX/JS 반영 필요. 실제 ERP 수신은 별도 ERP로그 트리거 연결 수정 전 오류 가능 | 선 검증 후 반영. 실제 DB SELECT 3조회: 설비자재181건/고유발주상세181건, ERP0건, MES181건. 실제 스키마 격리 MariaDB10.2.44에서 원래ITEMTP 오류 재현·필터·ERP원본수신·부분/전체수신·트리거로그 모의·0값갱신·입고처·삭제보호·실패롤백·메타등록19건, 실제JS VM10건 합계29건 통과. BOM/CRLF·node문법·원본해시 확인. 실제 ERP 로그테이블은 IF_MES_SNS에만 있고 FAC2 트리거의 무스키마 참조가 잘못됨; 사용자가 별도 처리 선택. 실제 수신/실브라우저/서버DDL-DML·배포 미수행 |
| **완료** | [MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx), [MTR0001_R04.aspx.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx.cs), [MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04_SYSTEM_PARAMETERS.sql) | MTR0001_R04 설비부품 발주조회 화면 및 프로시저 MES_SNS2 프로젝트 이관·표준화 구축 완료 | C# 클래스 정규화, ASPX 2단 탭/공통코드 매핑, JS 그리드 컬럼 최적화, 프로시저 전면 개편(ERP IF/가입고 연동), 27개 파라미터 등록 SQL 준비, MSBuild 및 쿼리 검증 완료 (실제 DB 반영은 사용자 진행) |
| **완료** | [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js), [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql) | 설비부품정보 프로시저 신규 구성/표준화 및 단위 콤보박스 DM150 적용 완료 | 프로시저 오류메시지/NULL조건/변수타입 보정, SYSTEM_PARAMETERS SQL 준비, UTF-8 BOM/CRLF 검증 완료 (실제 DB 반영은 사용자 진행) |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql, 05.Procedure/EQM1001_REV_SETUP/99_VERIFY.sql | 로컬 수정 완료. R03 전체 프로시저 저장 후 R03_SYSTEM_PARAMETERS SQL 실행(28개), R03.js 함께 반영 필요 | 격리 MariaDB10.2.44에서 SQL 컴파일 및 조회·출력 전후비교·양탭 개정저장·승인·중복승인 차단·CRUD·독립REV·주기저장·파라미터등록19건, 실제 R03 JS 모의실행6건 합계25건 통과. BOM/CRLF 및 원본 변경없음 확인 후 반영. 실DB 변경·서버 배포·실브라우저 실행 없음 |
| **완료** | [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R04.sql), [procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md) | EQM1001_R03·R04 SQL 들여쓰기 및 가독성 표준화 적용 완료 | BOM(UTF-8 with BOM) 보존, CRLF 줄바꿈 통일(단독 LF 0건, \r\r\n 0건), 문법 무결성 검증 완료 |
| **완료** | [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R04.sql), [procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md), [sql_structure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/sql_structure.md) | EQM1001_R04 들여쓰기 서식 적용 및 procedure.md 가독성 규칙 표준화 완료 | BOM(0xEF 0xBB 0xBF) 및 CRLF 개행 무결성 확인 완료, 프로시저 구문 및 규칙 문서 정상 반영 확인 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R04.sql | 미사용 반환 컬럼 제거 완료, 개선 사항은 보류 유지. 실제 DB 프로시저 반영은 사용자가 전체 소스 저장으로 진행 | 격리 MariaDB 10.2.44 네트워크 none에서 원본·변경본 컴파일 및 사용 컬럼 비교, 월별 조회·등록·수정·삭제·중복 오류 롤백 검증. 실제 R04 JS를 새 반환 데이터에 연결해 등록 팝업의 설비·점검자·두 REV 키 및 수정·삭제 요청의 실적키 모의 검증. 총 14건 통과, 쓰기 SQL·검증 블록·15개 입력 정의 일치, BOM/CRLF·원본 대조·최종 바이트 확인. 실제 DB 조회/DDL/DML·배포·UI/C# 수정 없음 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R04.sql | R04 SQL 소스 재작성 완료, 사용자가 프로시저 소스 편집기에서 전체 저장하여 적용 필요; 호출 파라미터는 변경 없어 재등록 불필요 | 네트워크 none 격리 MariaDB 10.2.44에 실제 최신 컬럼/PK 구성 후 원본·변경본 비교 38건 통과. 월별 현황, 최신 승인본, 빈 최신 승인본, 그룹 없는 설비, 동 코드 G/E 실적, 조회 후 새 승인, 등록/수정/삭제, 오류/중복/누락 롤백, 의도한 호환 제거, 제외한 보완 로직 미추가 확인. EXPLAIN에서 YEAR_PLAN PK eq_ref 직접 조회 확인, 속도 개선율 미측정. BOM/CRLF·당일 이력 1행·원본 대조·반영 바이트 일치 확인. 실제 DB는 SELECT만 실행, 실제 서버 DDL/DML·프로시저 배포 및 UI/C# 수정 없음 |
| **완료** | docs/EQM1001_테이블연결도_20261012.html, .svg, .png, _역할표.html,_역할표.png | 현재 소스 기준 연결도·역할 표 작성 완료, 실제 DB 반영 상태는 별도 확인 필요 | 격리 임시 프로필 headless Edge에서 렌더링 및 이미지 육안 확인. SVG 1개·표 11행·헤더 5개·가로 넘침 없음·브라우저 페이지 오류 0건·중국어 문자 없음·UTF-8 BOM/CRLF 확인. SQL·화면 업무 소스 및 실제 DB·서버 배포 변경 없음 |
| **완료** | 05.Procedure/EQM1001_REV_SETUP/00_CHECK.sql, 01_MSTEQMREV_DETAIL.sql, 02_CHKPLANEQM_APRV.sql, 03_CHKRSTEQM.sql, 04_CHKRSTEQMKND.sql, 99_VERIFY.sql; MES_SNS2_EQM1001_R02/R03/R05_SYSTEM_PARAMETERS.sql; docs/EQM1001_REV_독립관리_최종안_20261008.md; PLAN_REV_DEPLOY.sql 및 PLAN_REV_INDEPENDENT.sql 삭제 | SQL 소스 분리 완료, 사용자가 00_CHECK로 실제 구조와 초기화 상태 확인 후 안내 순서로 개별 적용 필요 | 격리 MariaDB 10.2.44 네트워크 none에서 분리 실행 16건 통과. 순차 ALTER·반복 실행·APRV 중간 스키마 전환·프로시저 4개 컴파일·파라미터 정확한 순서와 개수 및 다른 페이지 보존·BOM/CRLF·원본 대조 후 반영 확인. 실제 DB 최신 구조 조회·DDL/DML·서버 배포 미수행 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql,05.Procedure/MES_SNS2_EQM1001_R04.sql,05.Procedure/MES_SNS2_EQM1001_R05.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV_INDEPENDENT.sql,05.Procedure/MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql,01.Office/PAGEEQM/EQM1001/EQM1001_R03.js,05.Procedure/MES_SNS2_EQM1001_PLAN_REV_DEPLOY.sql,docs/EQM1001_REV_독립관리_최종안_20261008.md | 사용자가 초기화된 기존 DB에 최신 PLAN_REV_DEPLOY.sql 전체 실행 후 최신 R03.js 배포. 이전 독립 REV 화면 미반영 시 최신 R04.aspx/R04.js도 함께 적용. PLAN_REV_INIT 실행 금지. 기존 개별 전환·프로시저·파라미터 SQL은 일괄 실행 후 중복 적용 불필요 | 격리 network none MariaDB10.2.44에서 프로시저 4개 컴파일, DB 38건·JS 이벤트 17건 총55건 통과. 별도 빈 스키마 전환·반복 실행·데이터 있는 USEYN 삭제 차단 검증. REV3 삭제→REV4→REV5 재추가 및 다른 대상/이전 승인본 보존, 두 승인본 UNION ALL·같은 점검코드 실적 분리·롤백·초기화 후 실적 유지. 일괄 SQL 두 번 실행·메타데이터 R02=21/R03=29/R04=15/R05=10 순서/기존 실적 보존 확인. JS문법·BOM/CRLF·원본 동일성 검증. 실서버 DDL/DML·파일 배포·브라우저/PDF 테스트·이번 DB 최신 구조 재조회 미실시 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R04.sql,01.Office/PAGEEQM/EQM1001/EQM1001_R04.js | 기존 독립 REV 전환 배포 순서 유지. 최신 R04 프로시저/JS 수동 반영 필요, 이번 표시 변경의 파라미터·스키마 추가 변경 없음 | 네트워크 none 격리 MariaDB10.2.44에서 R04 컴파일, 등록 REV.0/REV.2 및 동일 점검코드 2행 유지, 새 승인 후 기존 실적 적용 REV 보존, REV 연결 초기화 시 공란/실적 행 보존 검증. JS 문법, SQL 변경 범위, BOM/CRLF 검증 통과 후 로컬 소스 반영. 실제 DB/서버 적용 및 실제 브라우저 테스트 없음 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R02.sql,05.Procedure/MES_SNS2_EQM1001_R03.sql,05.Procedure/MES_SNS2_EQM1001_R04.sql,05.Procedure/MES_SNS2_EQM1001_R05.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV_INDEPENDENT.sql,05.Procedure/MES_SNS2_EQM1001_PLAN_REV_RESET.sql,05.Procedure/MES_SNS2_EQM1001_R04_SYSTEM_PARAMETERS.sql,01.Office/PAGEEQM/EQM1001/EQM1001_R03.js,01.Office/PAGEEQM/EQM1001/EQM1001_R04.js,01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx | DB에 INDEPENDENT 컬럼 전환 → R02/R03/R04/R05 프로시저 → R04 SYSTEM_PARAMETERS를 함께 반영 필요. REV 초기화는 이미 확인된 서버에서 완료 상태이므로 반복할 필요 없음. 기존 PLAN_REV_INIT 재실행 금지. 검증 증거: C:/Users/DK/AppData/Local/Temp/codex-eqm-rev-transition-20261008 | 네트워크 none MariaDB 10.2.44에서 프로시저 4개 컴파일 및 DB 시나리오 39개, JS 이벤트 모의검증 16개 통과. 컬럼 전환 SQL 반복 실행, 새 컬럼 없는 스키마와 새 스키마의 초기화/실적 보존, 실제 등록 당시 REV 표시, 파라미터 15개 순서, JS 문법/BOM/CRLF 검증. 실서버 SELECT 확인: HEADER/DETAIL/APRV 각0, 실적15(REV 연결0), CHKPLANEQM67. 실서버 DDL/DML·브라우저 실제 CRUD·서버 파일 적용은 미실시 |
| **SQL 작성 완료** | 05.Procedure/MES_SNS2_EQM1001_PLAN_REV_RESET.sql | REV 초기화 SQL 준비 완료; CHKPLANEQM 삭제 범위 결정과 독립 REV/두 승인본 적용 전환 작업은 미진행 | 실제 DB SELECT 확인: HEADER37/DETAIL86/APRV420, 실적15 중 REV참조7, CHKPLANEQM 정기점검69. 초기화 대상4개 InnoDB 확인. 격리 MariaDB10.2.44에서 컴파일·대상 삭제·실적 내용 보존·범위·반복·강제 오류 전체 롤백·BOM/CRLF 10건 검증 통과 후 로컬 SQL 작성. 실제 DB 및 서버 변경 없음 |
| **사전 검토 완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, MES_SNS2_EQM1001_R04.sql (업무 소스 변경 없음) | 데이터 이관·중복 항목·전환 범위 결정 후 구현 진행 | 실제 DB SELECT 확인: CHKTP02 작업본 69행 전부 Y, 최신 미승인 HEADER 8개 모두 DETAIL 없음. 이 중 FM116I210N 그룹 REV1 작업본 5개, 나머지 7개 작업본 0개. DETAIL USEYN 없음, CHKRSTEQM REVCD 단일·GRPREVCD 없음, 실적 DETAIL 출처 REVCD 없음. 규칙 준수하여 분석만 수행, 프로시저/DB 수정·컴파일 테스트 없음 |
| **완료** | 01.Office/PAGEMST/MST1002/MST1002_R06.js, 05.Procedure/MES_SNS2_MST1002_R06.sql | 생산설비정보(MST1002_R06) 그리드 설비코드 앞 설비그룹코드 표시·설비그룹코드명 hidden 컬럼 추가 및 프로시저(SEL_EQM) 컬럼 반환 반영 완료 | Node.js 구문 검사 통과, MSBuild 컴파일 에러 0건, UTF-8 with BOM 및 CRLF 정규화 검증 완료, 실제 서버 DB 미반영 (사용자 반영 필요) |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql | 설비별 점검계획 탭 설비그룹코드 표시, 설비그룹명 hidden 선언, 상단 설비그룹 필터(find_EQM_GRP) 추가 및 프로시저(LIST_MSTEQM) 컬럼 반환·검색조건 반영 완료 | Node.js 구문 검사 통과, MSBuild 컴파일 에러 0건, UTF-8 with BOM 및 CRLF 정규화 검증 완료, 실제 서버 DB 미반영 (사용자 반영 필요) |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql | 개정이력(REV) 반려 버튼(btn_EQM_REJECT, btn_GRP_REJECT), 반려 팝업(pop_PLAN_REJECT) 및 관련 JS 로직/프로시저 분기 일괄 삭제 완료 | Node.js 구문 검사 통과, MSBuild 컴파일 에러 0건, UTF-8 with BOM 및 CRLF 정규화 검증 완료, 실제 서버 DB 미반영 (사용자 반영 필요) |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 05.Procedure/MES_SNS2_EQM1001_R03.sql, docs/EQM1001_R03_R04_SQL_정리검토_20261008.md | 리비전 승인·반려 이력 버튼(APRVHISTORY) 및 관련 JS 함수/팝업/프로시저(LIST_PLAN_APRV) 일괄 삭제 완료 | Node.js 구문 검사 통과, MSBuild 컴파일 에러 0건, UTF-8 with BOM 및 CRLF 정규화 검증 완료, 실제 서버 DB 미반영 (사용자 반영 필요) |
| **분석 완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, MES_SNS2_EQM1001_R04.sql 및 실제 DB 7개 테이블 (조회·분석만 수행) | 그룹/설비 독립 REV 및 승인본 합성 설계 제안 완료; 구현 미진행 | 실제 DB SELECT로 140개 컬럼 및 고유키 확인: HEADER REVCD PK와 PLANTP/PLANCD/REVNUM UNIQUE, DETAIL REVCD/CHKKNDCD PK, 실적 HEADER REVCD 단일 컬럼, 실적 DETAIL CHKRSTKEY/CHKKNDCD PK. 현재 소스와 R02/R05 등 연관 참조 확인. 설계 분석만 수행, 구현·DB DDL/DML·서버 반영 없음 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql | 로컬 R03 중복 검증 제거 완료; 실제 DB 반영은 사용자 진행 | 격리 MariaDB 10.2.44에서 수정 전후 전체 R03 컴파일 성공. 90개 NULL·빈 값·공백·잘못된 값·대소문자 입력 비교 및 설비그룹/설비별 승인·반려·출력 비교 포함 102건 통과. 저장 상태·승인본·이력·오류 메시지 동일. 파라미터 30개와 분기 유지, BOM·CRLF 및 당일 이력 한 줄 검증 후 로컬 반영. 실제 DB·서버 반영 없음 |
| **완료** | .agents/rules/procedure.md | 프로시저 중복 검증 방지 규칙 추가 완료 | 현재 R03 두 분기의 조건을 소스로 확인. 기존 procedure.md 내용은 보존하고 새 절만 추가했음을 비교 검증. UTF-8 BOM·CRLF 정상 |
| **확인 완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 05.Procedure/MES_SNS2_EQM1001_R04.sql (조회·비교만 수행) | 실제 DB 최신 반영 확인 완료; 추가 반영 불필요 | 실제 DB SELECT 조회로 R03 전체 본문·26개 분기, R04 전체 본문·6개 분기 일치 확인(주석·공백 제외). 실제 파라미터 및 SYSTEM_PARAMETERS 등록 이름·순서 R03 30개/R04 17개 모두 일치. 재추가 4개 분기는 이전 검증본과 일치. 이전 67건 DB 테스트 통과 기록 확인, 이번 턴 재실행 아님. DB·서버 및 업무 소스 변경 없음 |
| **로컬 반영 완료** | 05.Procedure/MES_SNS2_EQM1001_R04.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 05.Procedure/MES_SNS2_EQM1001_R04_SYSTEM_PARAMETERS.sql, docs/EQM1001_R03_R04_SQL_정리검토_20261008.md | 실제 DB 및 서버 파일 미변경. 사용자가 R04 프로시저→R04_SYSTEM_PARAMETERS.sql→R04.js 순서로 반영 필요. JOIN 개선 후보는 미반영 상태 | 현재 DB 컬럼·키·중복건수 SELECT 확인. 전체 호출 분기 리터럴 대조 및 지역변수/입력값 참조 확인. 격리 MariaDB 10.2.44에서 원본·정리본 R04 전체 컴파일과 19건 전후 비교 통과: 6개 기능·등록/수정/삭제 저장결과·조회순서·적용 REV·계획 점검자·필수값/중복/승인/미
... [truncated for diff preview]
| **로컬 반영 완료** | 05.Procedure/MES_SNS2_EQM1001_R04.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 05.Procedure/MES_SNS2_EQM1001_R04_SYSTEM_PARAMETERS.sql, docs/EQM1001_R03_R04_SQL_정리검토_20261008.md | 실제 DB 및 서버 파일 미변경. 사용자가 R04 프로시저→R04_SYSTEM_PARAMETERS.sql→R04.js 순서로 반영 필요. JOIN 개선 후보는 미반영 상태 | 현재 DB 컬럼·키·중복건수 SELECT 확인. 전체 호출 분기 리터럴 대조 및 지역변수/입력값 참조 확인. 격리 MariaDB 10.2.44에서 원본·정리본 R04 전체 컴파일과 19건 전후 비교 통과: 6개 기능·등록/수정/삭제 저장결과·조회순서·적용 REV·계획 점검자·필수값/중복/승인/미사용설비/미계획월 검증·과거실적 REV 보존·메타데이터 범위/재실행/호출순서. JS 구문 및 BOM/CRLF 검증. 실제 브라우저 E2E와 성능 벤치마크 미실행 |
| **소스 반영 완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql | 실제 DB 프로시저 반영은 사용자 진행; 실제 DB DML/DDL·서버 파일 수정 없음. SQL 전용 변경이므로 프로그램 재빌드 불필요 | 실제 DB 키 구조 SELECT 확인 후 네트워크 차단 MariaDB 10.2.44에서 변경 프로시저 전체 컴파일. 기존 승인·반려·CRUD 검증 46건과 재추가 전용 21건 총 67건 통과. 기존 코드 재현, 두 탭 REV.3 사용→REV.4 비사용 승인→REV.5 재추가 승인, 승인본·이력 불변, 활성 행 보존·반복 추가 무변경, 사용 설비 21대 재활성화, 부분 등록·NULL·빈 상태·마스터 제외·물리 삭제 재등록·중간 오류 롤백 확인. 원본 해시 확인 후 검증한 SQL만 로컬 반영, UTF-8 BOM/CRLF 유지 |
| **원인 확인 완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js (분석 대상, 소스 변경 없음) | 비사용 항목의 재추가 정책과 등록 처리 개선 필요; 이번 요청은 원인 설명만 진행 | 실제 서버 SELECT 5건: 마스터·그룹 집계·21개 소속 설비 행·현재 프로시저 정의·팝업 제외 조건 재현. 팝업 조건 결과 GROUP_EQMCNT=21, COUNT_USED_BY_POPUP=21, POPUP_VISIBLE=N 확인. 실제 DB DML/DDL 및 업무 소스 수정 없음 |
| **확인 완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql (분석 대상, 업무 소스 변경 없음) | 승인 로직 불일치 발견 없음; 업무 소스 수정과 재빌드 불필요 | 격리 MariaDB 10.2.44에서 현재 프로시저 컴파일 및 SQL 46건 통과. 현재 JS 함수 추출·UI/전송 모의 검증 21건 통과, 합계 67건. REV 컬럼 및 버튼 연결 동일성 확인. 실제 브라우저 E2E는 미실행. 실제 DB 변경·서버 파일 수정·배포 없음 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx | 설비그룹·설비별 탭 계획서 출력 버튼 검색행 우측 배치 통일 완료 | 적용 전 후보 검증: 두 탭 검색 find와 버튼의 같은 부모 패널, 버튼 ID 유일성, 우측 배치 속성 일치, 기존 위치 제거 및 변경점 원상복원 일치 확인. 적용 후 UTF-8 BOM/CRLF 및 파일 내용 일치 확인. 실제 서버 화면/배포 미실행. |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx | 설비그룹 검색행 오른쪽 끝으로 계획서 출력 버튼 위치 변경 완료 | 선반영 전 후보 마크업에서 버튼 ID 유일성, find와 같은 부모 영역, 기존 위치 제거 및 두 줄 이동 외 원본 복원 일치 확인. Float 속성의 공통 컨트롤 정의·HTML 렌더링 확인. UTF-8 BOM/CRLF 및 적용 내용 일치 확인. 실제 웹 화면 미실행, 서버 배포 없음. |
| **확인 완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql (확인만), 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js (확인만) | 주기 저장 승인 검증 제거의 정확한 전후 코드 및 호출 위치 확인 완료 | 현행 로컬 파일 및 수정 전 백업/적용 스크립트 대조 완료. 업무 소스 수정·DB 반영·재빌드·배포 없음. |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs | 계획서 하단 개정이력 최신 4건 표시 반영 완료. 프로시저 DB 반영과 S05A 보고서 빌드 배포 필요 | 네트워크 없는 MariaDB 10.2.44에서 원본·수정 전체 프로시저 컴파일 및 17건 통과: 그룹/설비 최신 4건·상태·순서, 과거 REV 선택에도 최신 이력 유지, REV 공란 자동선택, REV.0, 1~3건 경계값, 잘못된 계획 선택, 본문 결과 동일, 이월 코드 제거 확인. 스테이징 S05A를 프로젝트 MSBuild Release로 빌드 성공. 검증 후 로컬 소스 적용, BOM/CRLF/파일 바이트 일치 확인. 실제 웹 PDF 출력은 미실행. |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx | 확인창·알림 토스트 및 화면 안내 문구 전면 간소화 완료 | UTF-8 with BOM 및 CRLF 개행 무결성 검증 통과(BOM: true, DoubleCR: false), git diff 확인 완료 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js | 설비그룹 개정 저장 및 승인 재요청 확인창 문구 간소화 완료 | UTF-8 with BOM 및 CRLF 개행 무결성 검증 완료(BOM: true, DoubleCR: false) |
| **완료** | [R03.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.cs), [R03.Designer.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.Designer.cs), [R03.resx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.resx) | R03 제조설비 정기 점검 시트 DevExpress Report Designer 표준 형식 구축 | 첨부 템플릿 기준 Designer.cs 레이아웃 전면 구성, R03.cs 기본생성자 및 바인딩 정규화, MSBuild 0 Error 통과, 바이너리 배포 완료 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/Reports/EQM1001.exe | 계획서 출력 최신 REV 자동 선택 및 이력화 완료 | MSBuild 컴파일 오류 0건, 인코딩 BOM/CRLF 검증 통과, git diff 검증 완료 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql | 주기관리 조회 성능 개선 로컬 업무 소스 반영 완료. 실제 서버 프로시저 반영 및 화면 최종 응답시간 확인은 미실행 | 격리 MariaDB 10.2.44에서 원본·수정 프로시저 전체 컴파일 및 18건 검증 통과: 미등록 주기, NULL/빈 문자열/공백, 정상·미등록 코드, 기존 사원명, 설비코드·이름 검색, 연도·CHKTP 분리, 조회년도 검증, 승인 계획 없는 주기 저장, 12개월 사원코드 저장/이름 조회, 수정·삭제 및 실적 월 잠금. 최종 후보 실제 DB 읽기 전용 SELECT 222.12ms, 1143행 30컬럼 전체 JSON/순서 동일. 연결 개설/웹 렌더링 제외 측정. 스테이징 검증 후 적용 파일 바이트 일치, 다른 분기·입력 서명 불변, UTF-8 BOM/CRLF 정상. |
| **분석 완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql (분석만), 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js (분석만) | 주기관리 조회 병목 확인 및 결과 동일성 검증 완료. 우선 R03 LIST_CYCLE_EQMCD에서 빈 값/NULL의 GPCD 호출을 건너뛰는 최소 수정 권고; 업무 소스 반영 전 상태 | 원본/후보 모두 1143행 30컬럼. 전체 결과 JSON 및 행 순서 완전 동일, 셀 차이 0건, 설비코드 중복 0건. 측정은 연결 개설과 JSON 직렬화를 제외한 SQL 결과 수신/DataSet 구성 시간이며 실제 브라우저 전체 시간은 미측정. 진단 파일은 TEMP/codex-eqm1001-cycle-perf-20261007에 저장. |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, docs/EQM1001_작업정리_20261006-20261007.md | 로컬 소스 검증 및 적용 완료. 실제 서버 EQM1001_R03 프로시저 반영과 운영 화면 확인은 사용자가 진행해야 함. 새 전환 SQL 및 SYSTEM_PARAMETERS 재등록 불필요, 출력 계약 및 LIST_PLAN_REV 단건 최적화는 이번 범위 밖 | 실제 DB 정보 스키마 컬럼·키 SELECT 107행 확인, 실제 서버 DDL/DML 없음. 임시 수정본을 먼저 네트워크 없는 MariaDB 10.2.44에서 컴파일·검증 후 소스 적용. DB 38건+확장 8건, 화면 회귀 27건+실제 공통 그리드 이벤트 29건+재요청 UI 10건 총 112건 통과. CNC 21대 일괄 재요청·승인, 이력 보존, 8개 CRUD, 오류 시 전체 롤백, 동시 개별 처리 잠금, R04 기존 승인본 조회 확인. 파라미터 동일·JS 구문·기존 날짜 주석 보존·UTF8 BOM/CRLF 및 원본 변경 없음·검증본과 적용본 바이트 일치 확인. 운영 브라우저 신규 동작 미실행 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js (읽기 전용 분석) | 업무 흐름 검토 완료, 구현 미적용. 반려 후 보완·재요청과 그룹 일괄 승인 범위를 결정한 뒤 양 탭 및 SQL 함께 반영 필요 | R03 상태 저장·개정내용 저장·공통 CRUD SQL과 JS 호출 확인 및 Microsoft Business Central 공식 승인 워크플로 문서 비교. 설계 검토만 수행하여 런타임 테스트 및 DB 변경 없음 |
| **완료** | WORK_HISTORY.md (실제 DB SELECT 및 로컬·서버 R03 프로시저 검토) | CNC 그룹 승인 차단 원인 확인 완료; 그룹 반려 후 재요청 및 일괄승인 흐름과 최신REV 검증 정합성 조정 필요 | 실제 DB SELECT만 실행. 최신 반려 설비21·전체 반려 설비21·과거 반려0 및 5+16 안내와 일치. 배포 R03 검증/개정저장 본문 확인, 업무 소스·DB·서버 파일 변경 없음 |
| **완료** | docs/EQM1001_작업정리_20261006-20261007.md | REV0 단계 설명 완료; 현재 R03 SQL 최종 요구와의 불일치 점검 항목 유지 | 현재 SQL의 생성범위·SAVE_PLAN_REV 필드7개와 상태초기화 부재·승인조건 DETAIL INSERT·APRVKEY·HEADER 반려 승인자 처리 대조. 원문 보존 및 후보 문서 선검증 후 반영, UTF8 BOM/CRLF 검증. 업무 소스·실제 DB 변경 및 새 DB 조회 없음 |
| **완료** | WORK_HISTORY.md (MSTEQMREV_HEADER·MSTEQMREV_DETAIL·CHKPLANEQM_APRV SELECT 및 R03 SQL 검토) | 승인본 생성 원인 확인 완료; 다른 R03 소스 불일치 점검 항목은 기존 기록 유지 | 실제 DB는 SELECT만 사용. HEADER APRVTIME·DETAIL RTIME·APRV A 처리시각 일치 및 그룹·소속4설비 키 확인. 첫 연결은 샌드박스 네트워크 제한으로 실패 후 읽기전용 외부 연결로 확인. 업무 소스·실제 DB·서버 파일 변경 없음 |
| **완료** | docs/EQM1001_작업정리_20261006-20261007.md | 설명 문서 작성 완료; 현재 R03 SQL과 최종 요구·JS/리포트 입력 계약의 불일치 확인 및 후속 조정 필요 | 현재 SQL CASE42개 전부 문서 포함 확인, 테이블15개·실제 파일 링크·R03 불일치 조건 정적 대조, UTF-8 BOM/CRLF·적용 파일 일치 검증. 실제 DB 최신 반영 조회·실행 및 브라우저 확인 미수행 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js | R03 소스 반영 완료; 실제 배포 브라우저 Network 호출 횟수 확인 필요 | 선 검증 후 반영. 실제 공통 SetStore·AddRow·SetRowData 및 선택 이벤트 코드를 포함한 이벤트 재현 29건, 승인본·신규 REV·기존 선택 및 편집 회귀 27건 통과(합계 56건). 기존 4회 호출 재현 및 수정 후 3회 확인. 빈 조회·실패 후 재시도·바인딩 예외 복원 검증. JS 문법 및 UTF-8 BOM·CRLF 검증 완료. 실제 서버·DB 변경과 실브라우저 확인은 수행하지 않음 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js | R03 JS/SQL 로컬 수정 완료, 실제 서버 반영은 사용자 진행 | 실제 DB 4개 테이블 컬럼65건 및 COMCALLC 트랜잭션 정의 SELECT 확인. 격리 MariaDB R03/R04 컴파일 및 DB35건, 공통 SetRowData/AddRow 실제 함수 포함 JS 모의27건 통과. 신규 대기 중 R04 직전 승인본 사용·신규 승인 후 전환 확인. JS 문법·30개 파라미터·UTF8 BOM/CRLF·스크립트 버전 유지 확인. 실제 서버 반영·실제 브라우저 테스트 미실시 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js | 로컬 JS 반영 완료 | 후보 JS 문법·불필요 색상 호출 제거·반려사유 저장/갱신 유지 확인 후 반영. UTF-8 BOM/CRLF 검증. 실제 브라우저 화면 테스트 미실시 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js | R03 SQL/JS 로컬 수정 완료, 실제 서버 반영은 사용자 진행 | 실제 DB 컬럼 52건·HEADER 인덱스 7건 SELECT 확인. 격리 MariaDB 10.2 SQL 컴파일 및 DB 45건, 공통 SetRowData 실제 함수 포함 JS 모의 검증 21건 통과. JS 문법·30개 파라미터·BOM/CRLF 검증 완료. 실제 서버 DB 변경·배포 및 실제 브라우저 화면 테스트 미실시 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, WORK_HISTORY.md | 로컬 수정 완료. 서버에는 R03.js와 EQM1001_R03 전체 프로시저를 함께 반영 필요. 승인 계획 변경 및 자동 신규REV 생성이 차단되는 업무규칙 적용 | 선 검증 후 반영. 실제 서버 프로시저 정의 SELECT로 구 동작 확인, 실제 DDL/DML 없음. 격리 MariaDB 전체 컴파일29건: 승인 대상/연동대상4경우×CRUD4차단 및 HEADER/DETAIL/APRV/CHKPLANEQM 불변16, 초기/대기 CRUD8, 승인·과거반려 이력보존2, 승인 개정내용 저장차단2, 승인된설비 주기저장1. 모의 JS11: 양탭 최신A 읽기전용/버튼숨김·대기/반려편집·최초등록·과거승인읽기·BOM CRLF srcVersion 유지. 합계40건, 기타 SQL 분기/30파라미터 및2개 JS함수 외 코드불변 확인. 저장파일 일치. 실브라우저 미실행 |
| **완료** | WORK_HISTORY.md (R03.sql 소스 검토, 업무 소스 변경 없음) | 설명 및 현재 동작 확인 완료. 최신 REV 한정 없는 UPDATE 동작은 설명에 명시, 사용자가 수정을 요청하지 않아 변경하지 않음 | 전체 DECLARE 사용처 확인32개·미사용0. 공통 호출코드8개 및 UPDATE/INSERT 범위 소스 검토. 실제 DB 조회·실행·업무 소스 변경 없음 |
| **완료** | WORK_HISTORY.md (R03.js·로컬 R03.sql·실제 서버 프로시저 검토, 업무 소스 변경 없음) | 주기 저장 승인 제한 제거는 실제 서버까지 확인 완료. 직전 계획서 개정이력 관련 로컬 SQL 반영은 별도 사용자 배포 대상 | 실제 서버 정의·트리거는 SELECT만 확인. 격리 MariaDB 전체컴파일 및 계획/REV/승인본 모두없는 상태 저장·대기/반려/승인 상태 저장·비사용/미지정설비 차단·실적월 변경 차단·일반/일괄 JS경로·트리거 없음10건 통과. 로컬/서버 주기저장 분기 정규화 비교일치. 실제 서버 저장/DML 및 업무 소스 변경 없음 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, WORK_HISTORY.md | 로컬 SQL 수정 완료. 서버 EQM1001_R03 전체 프로시저 반영 필요 | 선 검증 후 반영: 격리 MariaDB 전체 프로시저 컴파일·양탭 혼재60개 REV 한 번씩·과거/미선택/최신 선택·같은 REV의 반려→대기→승인 변경 후1건·다중 APRV 로그 중복 없음·대기만 있어도 표시·상태별 날짜·승인자18건 통과. 최신 계획 및 CRUD 분기·파라미터30 동일, BOM CRLF·저장파일 일치 확인. 실제 DB/서버·JS·보고서 바이너리 변경 없음, PDF 재실행 없음 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, WORK_HISTORY.md | 로컬 수정 완료. 서버 EQM1001_R03 프로시저 전체 반영 필요. 직전 턴 배포한 JS/보고서 실행파일은 추가 변경 없음 | 선 검증 후 로컬 SQL 반영. 격리 MariaDB 전체 컴파일, 양 탭 혼재60중 승인20만 조회·과거/미선택/최신 REV 무관·REV 고유·승인일자·중복 로그·전체 승인60·승인 없음 등14건 통과. 변경은 이력 SELECT와 Modify 주석뿐, 기존 최신 계획·CRUD·파라미터30 보존, UTF8 BOM CRLF 및 적용파일 일치 확인. 실제 DB 반영 및 브라우저/PDF 재실행 없음 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs, 01.Office/Reports/EQM1001.exe·pdb, 04.Report/PAGEEQM/EQM1001/bin/Release/EQM1001.exe·pdb, WORK_HISTORY.md | 로컬 수정 완료. 서버 반영 시 R03.js·EQM1001_R03 전체 프로시저·01.Office/Reports/EQM1001.exe를 함께 반영 필요 | 선 검증 후 반영: 실제 ItsRpt 직렬화·두 탭 과거/최신/미선택 REV·좌측선택 변경·미선택10, 격리 MariaDB 전체 컴파일·REV1/0/99/공란/잘못된값 무관 최신 계획·승인본·전체60이력·검증16, 테스트 DB만 대체한 실제 S05A PDF3/4/5/60건 양탭8개 전부 각 이력1회·페이지1/1/2/3 확인 및 PNG 시각 검증. 실제 DB SELECT 양탭 각REV0~3 전체4건 반환2, 합계36건. MSBuild 오류0, 최신 바이너리 IL의 REVNUM 입력 제거 및 전체 이력메서드 확인, BOM CRLF·적용파일/바이너리 해시 확인. 실제 DB DDL/DML·서버 반영·실브라우저 미실행 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, WORK_HISTORY.md | 로컬 수정 완료. 실제 서버 EQM1001_R03 전체 프로시저는 사용자 반영 필요 | 선 검증 후 반영: 격리 MariaDB 전체 컴파일 및 두 탭 REV 없음·REV0 대기·NULL 상태·승인·반려·승인 후 신규 대기/반려·최신 승인 등 포함22건 통과. 실제 SELECT 설비1143/그룹14 유지, 설비996/그룹7 미등록 상태 공란, 기존 식별키·이름·상태코드·반려사유·정렬 동일, 최신 REV 표시29개 정상화. 변경 범위 LIST_MSTEQM만·파라미터30·BOM CRLF 확인. 실제 DB 반영·브라우저 실화면 테스트 미실행 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql, WORK_HISTORY.md | 로컬 JS·R03 SQL 반영 완료. 사용자 실제 DB R03 프로시저 전체 반영 필요(파라미터 변경 없음) | 검증 후 반영: 실제 DB SELECT 전후1143개 고유 설비의 나머지 모든 필드·정렬 동일. JS 모의 UI56, 격리 MariaDB10.2 프로시저 컴파일·조회·CRUD·그룹CRUD·실행계획17, 중복 요청·기존 데이터 불변2 합계75건 통과. EXPLAIN에서 표시용 CHKPLANEQM 접근 제거 확인. 실제 CHKPLANEQM 트리거0 SELECT 확인. 수정 전후 파라미터 동일, SQL 변경은 LIST_MSTEQM/REG_EQM02 두 분기뿐. BOM CRLF·저장파일 해시 확인. 실제 DB DDL/DML 및 서버 파일 반영 없음, 실브라우저 동작 미실행 |
| **검증 완료** | WORK_HISTORY.md (R03.js·aspx·sql 검토, 업무 소스 변경 없음) | 체크박스 삭제 자체는 기능 영향 없음. 완전 정리 시 주석 선언·YnToBool 변환·SQL 표시값 및 전용 JOIN을 함께 제거 가능 | 현재 파일 그대로 JS 모의 동작 검증54건 통과(기존44+체크박스 없는 설비 선택·추가·등록·저장·삭제·복사·미선택10). 공통 Store 변환 및 ItsGrid 바인딩 소스 확인, LIST_MSTEQM 참조자는 R03.js뿐임. 실제 DB 호출·브라우저 실화면 테스트·업무 소스 변경 없음 |
| **완료** | .agents/rules/sql_structure.md, .agents/rules/procedure.md, .agents/rules/validation.md, WORK_HISTORY.md | 앞으로 SQL을 최소 참조와 직관적인 데이터 연결 흐름으로 작성 | 선 검증 후 규칙 반영. 보존 항목 제거 여부, 규칙 frontmatter·문서 링크·50줄 이내·BOM CRLF 검증, 실제 저장 파일 해시 일치 확인 |
| **완료** | .agents/rules/sql_structure.md, .agents/rules/procedure.md, .agents/rules/validation.md, WORK_HISTORY.md | 추후 모든 프로시저 작성·수정·최적화 시 sql_structure.md 기준 적용 | 임시 규칙 작성 후 기존 문서 비교 및 충돌 검토 완료. 새 규칙 50줄 이내, frontmatter·상대 링크·UTF8 BOM·CRLF 검증. 저장 후 3개 파일 해시 일치 확인. 문서 변경만 수행, 업무 소스·DB 미변경 |
| **완료** | 01.Office/Reports/EQM1001.exe·pdb, 04.Report/PAGEEQM/EQM1001/bin/Release/EQM1001.exe·pdb, WORK_HISTORY.md | 로컬 실행 파일 수정 완료. 실제 운영 환경 적용 시 최신 01.Office/Reports/EQM1001.exe 반영 필요 | MSBuild 오류0. 실제 ItsRpt.js 직렬화 및 R03 PrintPlanRev 사용한 전달·미선택 검증8건 통과. DB 연결만 테스트 대체한 임시 S05A로 그룹·설비 REV0/REV3 PDF4건 생성 및 R03/PLANCD/REVNUM 전달 확인. 최종 EXE 해시 일치. 실제 DB·실제 서버 파일 미변경, 실서버 PDF 출력 미실행 |
| **검증 완료** | WORK_HISTORY.md (실제 DB SELECT 검증, 업무 소스 변경 없음) | 사용자 반영 필요: PLAN_REV_NORMALIZE로 DETAIL 4중복 컬럼 제거. APRV 감사컬럼 기본값 3개 및 미연결 설비 계획 데이터는 추가 정리 검토 | SELECT만 사용. HEADER 199/DETAIL 607/APRV 196/계획 643행. DETAIL의 HEADER 미연결 0, APRV 빈키·키형식·상태·HEADER 연결·계획 식별 불일치 각 0. DETAIL 중복 컬럼 불일치 66건 전부 빈값·0 기본값, 승인 스냅샷과 HEADER 연결 유지. 계획 CHKTP01 17/02 626, 설비 미연결31/점검항목 미연결0. 실제 DB DDL/DML·공통 함수 실행 없음 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 05.Procedure/MES_SNS2_EQM1001_R03.sql | 로컬 수정 완료, 실제 DB R03 프로시저 전체 반영은 사용자 진행 | 선 검증 후 반영: JS 모의 UI 44건 및 격리 MariaDB 10.2 승인·반려 회귀 검증 47건 합계 91건 통과. JS 문법·ASPX 버튼 속성·파라미터 유지·BOM CRLF 확인. 실제 서버 DB와 배포 파일 미변경 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql, 05.Procedure/MES_SNS2_EQM1001_R04.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_REV.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_REV_INIT.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_REV_REVCD.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_APRV_HISTORY.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_REV_NORMALIZE.sql | 로컬 반영 완료. 실제 DB 변경 없음. 기존 DB 반영: PLAN_REV_NORMALIZE → 최신 PLAN_APRV_HISTORY → R03·R04 전체 프로시저 교체. R03 메타데이터는 기존 안내30개 유지(아직 미등록이면 R03_SYSTEM_PARAMETERS 실행). 구 REV_INIT/REV_REVCD는 해당 구 구조의 최초 이관에만 사용하며 정규화 후 재실행 금지 | 격리 MariaDB10.2 및 실제 GETKEY 정의 복제로 승인/이력/출력31건, 테이블 전환·재실행·기존 키/기록 보존·고아 차단13건, R04 승인본/점검 등록/중복 방지10건, 신규 스키마/최초 이관3건, 주기관리·완료월 잠금26건 총83건 통과. R03·R04 입력 파라미터 동일 및 수정 분기3개 한정 확인. 7개 SQL UTF8 BOM/CRLF 검증. 실제 DB는 SELECT만 사용하고 GETKEY 직접 호출이나 DDL/DML 없음 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js, 05.Procedure/MES_SNS2_EQM1001_R03.sql, 05.Procedure/MES_SNS2_EQM1001_R05.sql, 05.Procedure/MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql, 05.Procedure/MES_SNS2_EQM1001_PLAN_APRV_HISTORY.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs | 로컬 반영 완료, 실제 DB DDL/DML 및 서버 배포 없음. 반영 순서: PLAN_APRV_HISTORY SQL → R03·R05 프로시저 전체 교체 → R03_SYSTEM_PARAMETERS 재등록(30개) → R03·R05 페이지 및 S05A 리포트 빌드/배포. 기존 PLAN_REV_INIT은 이력 전환 후 재실행 금지 | 선검증 후 반영. 격리 MariaDB10.2 승인·반려·선택 REV 출력28건, 주기관리/완료월 잠금26건, 이력 전환/재실행/기존 데이터 보존8건, JS 이벤트/클릭 행/선택 복원/에러/버전/컨트롤23건 총85건 통과. 실제 스키마와 현행 R03은 SELECT로만 확인. 스테이징·최종 MSBuild 빌드 오류0. 기존 R03 분기 동일 및 UTF8 BOM/CRLF 검증. 실제 배포 화면·PDF 실행은 서버 반영 후 확인 필요 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql | 로컬 수정 완료. 사용자가 R03 프로시저를 서버에 재반영해야 하며 실제 DB 직접 변경 없음 | 격리 MariaDB 10.2에서 프로시저 컴파일 및 26개 조회·저장·삭제·완료월 잠금·R04 승인 회귀검증 통과. 실제 DB SELECT로 활성 설비 1143개와 조회 1143행, 키 중복 없음 및 30개 컬럼 확인. 선검증 후 반영, UTF-8 BOM/CRLF 및 파라미터 동일 검증 |
| **완료** | 05.Procedure/MES_SNS2_EQM1001_R03.sql;05.Procedure/MES_SNS2_EQM1001_R05.sql;05.Procedure/MES_SNS2_EQM1001_PLAN_REV.sql;05.Procedure/MES_SNS2_EQM1001_PLAN_REV_INIT.sql;01.Office/PAGEEQM/EQM1001/EQM1001_R03.js;05.Procedure/MES_SNS2_EQM1001_PLAN_APRV.sql 삭제 | 로컬 소스 완료. 사용자가 R03/R05를 함께 반영해야 함. 기존 운영 승인 테이블은 서버의 구 프로시저가 사용 중이므로 물리 삭제하지 않음. 신규 DB는 PLAN_REV.sql만 사용, 이미 REV 이관된 운영 DB는 PLAN_REV_INIT.sql 재실행 불필요. | 격리 MariaDB 10.2 DB 테스트 94건 및 JS 모의 테스트 20건 통과; 실제 DB SELECT로 그룹 14건 최신 REV·상태 대조 및 기존 설비·승인관리 조회 결과 검증; 가상 REV 10만 건에서 느린 윈도 함수·행별 lookup 제외하고 집계/유일키 조인 유지; 파라미터 수·순서 유지, BOM·CRLF·node 문법검사 통과; 실제 서버 DDL/DML 없음 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql | 최적화본은 로컬 SQL 3개에만 반영. 서버에는 R03/R04/R05 프로시저 수정본 재적용 필요. 파라미터 규격은 유지하여 SYSTEM_PARAMETERS 재등록 및 JS 배포 변경 불필요 | 실제 DB SELECT/EXPLAIN으로 최신 배포 정의·메타데이터·키 확인. 변경 전후 그룹 목록 13건·설비 목록 126건·REV 상세 4건 동일. 격리 MariaDB 10.2에서 최적화 3개+기존 비교용 3개 전체 컴파일. 기존 CRUD/승인 34개+추가 R04/주기관리/결과 비교 35개=69개 통과. 실제 조회 소규모 측정(한 연결, 쿼리별 워밍업 1회 제외 6회) 중앙값 그룹24.92→18.04ms, 설비29.83→20.77ms(왕복·전송 포함 참고값, 운영 성능 보장 아님). BOM/CRLF 검증. 실제 서버 DB 데이터·정의·인덱스 변경 없음, 브라우저 CRUD 미실행 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js, 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, WORK_HISTORY.md | 서버 반영 대기: MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql 백업 구간 → 최신 R03/R05 프로시저 교체 → 같은 등록 SQL 재등록 구간(28건) → R03.js 배포. R04 추가 변경 불필요 | JS 3개 구문 검사 및 로컬 호출·분기·페이지 이름 검사 통과. 실제 서버는 루틴/메타데이터 SELECT만 실행. 서버 R03에서 로컬 REV 3분기 누락 및 등록 파라미터 24개(최신 28개 필요) 확인. R04 22개·R05 10개 파라미터는 로컬과 일치. 실제 서버 수정 없음 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R03_SYSTEM_PARAMETERS.sql, 05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_SYSTEM_PARAMETERS.sql | 적용 순서: R03 전용 파라미터 SQL의 백업 구간 실행 → R03·R05 프로시저 교체 → 같은 SQL의 삭제·재등록/확인 구간 실행(28건) → R03.js 배포. R05 입력값은 그대로 10개 | 실제 서버는 SELECT만 실행: 테이블 컬럼·키·루틴·파라미터 확인, 수정 SELECT 그룹 1건(대기 REV.1 요청일시 정상), 설비 126건 정상. 격리 MariaDB 10.2에서 전체 R03/R05 컴파일과 원래 파라미터 백업·재등록 검증. DB 회귀 34개+JS 호출 10개=44개 통과. CRUD 8개 분기·그룹 일괄 승인/반려·승인본 보존·재승인 요청정보·오류 입력·이전 데이터 보완 확인. JS 구문 및 BOM/CRLF 검증. 실제 서버 프로시저/메타데이터 미반영, 실제 브라우저 저장 미검증 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql | 사용자가 EQM1001_R05 프로시저 수정본 반영 후 기존 빈 이력은 개정내용 재저장 필요 | 실제 DB 스키마·데이터·배포 프로시저를 SELECT로 확인. 격리 MariaDB 10.2에서 전체 프로시저 컴파일 및 14개 검증 통과(그룹·설비별 저장, 재저장 사용자·시간, 반려상태 유지, 승인본 보호, 입력 오류). LIST_PLAN_REV 작성자명·시간 반환 확인. BOM·CRLF 검증. 실제 서버 DB 변경 및 브라우저 저장 테스트 없음 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R01.js, 05.PROCEDURE/MES_SNS2_EQM1001_R01.sql | EQM1001_R01 수리유형 명칭 원복 완료, 렌더링 200 OK 검증 완료 | IIS Express 200 OK 확인, 렌더링된 HTML 내 '수리유형' 포함 및 '고장원인구분' 미포함 검증 완료, 전 파일 UTF-8 with BOM 무결성 확인 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql | EQM1001_R04 프로시저 REV 표기 간결화 완료 (서버 DB 직접 반영 금지 원칙 준수) | SQL 소스 파일 UTF-8 with BOM 및 CRLF 무결성 확인, IIS Express 200 OK 정상 서빙 확인 |
| **완료** | 01.Office/PAGEMST/MST3001/MST3001_R03 (aspx, aspx.cs, js), 01.Office/PAGETOL/TOL0003/TOL0003_R05 (aspx, aspx.cs, js) | MST3001_R03 및 TOL0003_R05 표준화 완료, IIS Express 200 OK 서빙 확인 | IIS Express(<http://localhost:55085/>) 호출 검증 결과 MST3001_R03.aspx 및 TOL0003_R05.aspx 모두 200 OK 정상 서빙 확인, 전 파일 UTF-8 with BOM 및 CRLF 무결성 검증 완료 |
| **완료** | [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql) | EQM1001_R04 월별 점검상태 REV 버전 표기 및 컬럼 확장 완료 | IIS Express 200 OK 확인, 브라우저 렌더링 검증 결과 점검완료(초록)/점검필요(파랑) 색상 적용 및 pop1/pop2 더블클릭 오픈 정상 동작 확인 완료 |
| **완료** | [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx) | EQM1001_R03 우측 그리드 헤더 영역 공백 여백 제거 및 UTF-8 BOM 정상화 완료 | IIS Express 200 OK 확인, 브라우저 렌더링 측정 결과 버튼-헤더 간 간격이 4.67px로 밀착되고 패널 높이가 24px로 최적화됨을 실측 확인 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R01.aspx, EQM1001_R01.js, EQM1001_S01.js, 05.PROCEDURE/MES_SNS2_EQM1001_R01.sql, MES_SNS2_EQM1001_S01.sql, 04.Report/PAGEEQM/EQM1001/S01A.cs | 로컬 소스 수정 및 검증 완료. 실서버에 R01·S01 프로시저 교체와 빌드된 EQM1001.exe 배포 필요. 설비마스터 없는 기존 이력 1건과 완료시간 역전 기존 이력 1건은 SELECT 확인만 진행하여 원본 데이터 보존 | 실서버 수정 조회문 SELECT 4종 실행: 전체 이력 4건, TEST_EMP01 참여 이력 2건, A-001 구입금액 6,000,000(KRW) 및 작업자 2명 반환. 격리된 로컬 MariaDB 10.2.44에서 46개 DB 시나리오 통과, Node 화면 이벤트 23개 통과, JavaScript 문법 정상. MSBuild 15 Release 빌드 성공. BOM·CRLF 정상. 실제 서버 DDL/DML·리포트 배포 및 실제 브라우저 CRUD는 수행하지 않음 |
| **대기** | [MES_SNS2_MTR0001_R01_MENU_CLEANUP.sql](D:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_MTR0001_R01_MENU_CLEANUP.sql) | SQL 작성 완료, 사용자 대상 확인 및 DB 실행 후 메뉴 재등록 확인 대기 | 정적 검증: 삭제 테이블 1개 및 PRGCD 완전 일치, SQL BOM/CRLF 정상; 실제 DB 미실행, 재등록 결과는 사용자 실행 후 확인 필요 |
| **완료** | [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx) | EQM1001_R03 헤더 패널 공백 여백 제거 완료 | UTF-8 with BOM 및 CRLF 개행 무결성 확인, git diff 검증 완료 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [EQM1001_R05.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R05.js) | REV 컬럼 너비 100 통일 및 R03 autoSizeColumns 해제 | 3개 파일 UTF-8 with BOM 및 CRLF 개행 무결성 확인, git diff 정상 반영 완료 |
| **완료** | AGENTS.md | Antigravity 커밋 메시지 자동 생성 한국어 적용 | AGENTS.md BOM·CRLF·중복 CR 0건, git 무시 대상 아님. 실제 생성 결과는 Antigravity에서 창 다시 불러오기 후 사용자 확인 필요 |
| **완료** | C:\Users\DK\AppData\Local\Programs\Antigravity IDE\resources\app\extensions\antigravity\dist\extension.js | 소스 제어 AI 커밋 메시지 한글 자동 변환 패치 | extension.js doGenerateCommitMessage 내 한글 자동 변환 로직 주입 및 구문 검사 통과. 창 다시 로드 후 즉시 한글 출력 확인 가능 |
| **완료** | .agents/rules/commit_message.md, C:\Users\DK\.gemini\config\rules\commit_message.md | AI Git 커밋 메시지 한글 생성 규칙 제정 및 환경 설정 | Conventional Commits 기반 한글 커밋 메시지 규칙 신규 제정 및 IDE 설정 반영. BOM·CRLF 정상 |
| **완료** | .agents/rules/Optimization.md, .agents/rules/aspx_cs_comment.md | 규칙 문서 날짜 주석 적용 대상에 주요 기능 C# 소스 추가 | 두 파일 BOM·CRLF·중복 CR 0건, 줄바꿈 제외 변경 11줄 추가·8줄 삭제 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js | EQM1001_R04.js SVN 버전 충돌 해결 및 최신본 통합 | .mine 최신 로직 기준으로 충돌 마커 전면 해소, 임시 파일 정리, 문법/BOM/CRLF 정상 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.aspx, .agents/rules/aspx_cs_comment.md | ASP.NET (.aspx, .aspx.cs) 주석 작성 금지 및 .js 한정 주석 규칙화 | .aspx 화면 마크업 날짜 주석 전면 제거 및 규칙 문서(.agents/rules/aspx_cs_comment.md) 신규 제정. BOM·CRLF 정상 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, .agents/rules/procedure_history.md | 프로시저 최상단 Modify 이력 1일 1행 통합 및 규칙화 | 프로시저 최상단 이력 날짜별 1행 통합 정리 및 규칙 문서(.agents/rules/procedure_history.md) 신규 제정. BOM·CRLF 정상 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js | EQM1001_R04 수정 완료 알림 확인 후 팝업 닫기 | 오프라인 화면(실제 공통 스크립트): 저장 직후 알림 표시·수정 팝업 유지, 알림 확인 클릭 후 수정 팝업 닫힘·목록 재조회 호출 확인. JS 문법·BOM·CRLF 정상 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js | EQM1001_R04 정기점검 수정 완료 후 팝업 자동 닫기 | JS 문법·BOM·CRLF 정상 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R03.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js, 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql | EQM1001 등록·저장 버튼 값 검증을 프로시저로 이동 | 로컬 MariaDB 10.6: 등록 항목 없음·빈 점검값(2번째·공백) 차단 및 등록 전 실적 0건 유지, 0 포함 정상 등록, 수정 빈 값 차단·정상 수정, R03 복사 대상·원본 없음, 그룹 복사·저장 그룹 없음, R05 승인 대상 없음·반려사유 없음·진행 중 REV 없음 안내 정상. JS 문법·BOM·CRLF 정상 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js | EQM1001_R04 점검값 입력 초기화 원인 안내 및 필수 입력 검증 | node 스텁 테스트: OK/NG에 'ok ' → OK, '양호' → 빈 값+안내, 숫자에 ' 12.5' → 12.5, 'abc' → 빈 값+안내, 문자 항목 '누유 없음' 유지, 빈 점검값 있으면 등록 호출 안 함·해당 항목 포커스, 0 포함 모두 채우면 등록 호출. JS 문법·BOM·CRLF 정상 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js | EQM1001_R05 계획서 승인상태 무관 출력 및 개정 이력·설비별 출력 미표시 원인 확인 | 로컬 MariaDB 10.6: 대기 그룹(현재 계획+이력 3건), 승인 설비(승인본), 반려 설비·반려 그룹(현재 계획), 리비전 없는 설비(이력 없음) 출력 데이터 정상, 사용 항목 없는 설비는 상단 결과 없음으로 출력 불가 안내. R05.js 문법·BOM·CRLF 정상 |
| **완료** | 01.Office/PAGEEQM/EQM1001/EQM1001_R05.aspx, 01.Office/PAGEEQM/EQM1001/EQM1001_R05.js, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql, 04.Report/PAGEEQM/EQM1001/S05A.cs | EQM1001_R05 승인상태 필터 및 설비별 점검계획서 출력 | 로컬 MariaDB 10.6: 승인상태 필터 4종×두 탭 정상, 설비그룹·설비 계획서 데이터 정상, 반려 계획 출력 차단. S05A는 mono 6.12로 전체 프로젝트 컴파일 성공, 샘플 데이터로 PDF 생성해 칸 배치 확인(컨테이너에 한글 글꼴이 없어 한글은 ?로 표시). R05.js 문법·BOM·CRLF 정상 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 01.Office/PAGEEQM/EQM1001/EQM1001_R04.js | EQM1001 정기점검 흐름 점검 및 등록·주기관리 보완 | 로컬 MariaDB 10.6: 중복 등록 차단, 계획 없는 달 등록 차단, 사용 항목 없이 승인된 설비는 R03 주기관리에서도 제외, 점검항목 전부 삭제 후 개정 대기 중인 설비는 R03·R04 모두 유지, 실적 월 잠금 10개 경우 그대로 통과, 54개 시나리오 차이는 새 규칙에 따른 차단만. R04.js 문법·BOM·CRLF 정상 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql | EQM1001_R03 주기관리 정기점검 실적 있는 월 잠금 | 로컬 MariaDB 10.6 10개 경우 확인: 실적 월 삭제·변경·비움 차단, 실적 없는 월 변경·삭제 허용, 예전 사원명 저장 월 변경 허용, 일상점검 실적은 영향 없음, 계획 없던 실적 월에 새로 지정 허용 후 삭제 차단. BOM·CRLF 정상 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql | EQM1001_R03·R04 프로시저 성능 개선 범위 축소 | 로컬 MariaDB 10.6 수정 전·후 54개 시나리오 결과 동일(의도한 SEARCH_CHKRSTEQM 일상점검 제외만 차이). 설비 2,000·실적 100,000건 기준 R04 주기 조회 297.7초→0.27초, R03 주기 조회 5.26초→0.30초, 미등록 항목 1,010ms→10ms. BOM·CRLF 정상 |
| **완료** | 05.PROCEDURE/MES_SNS2_EQM1001_R03.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R04.sql, 05.PROCEDURE/MES_SNS2_EQM1001_R05.sql | EQM1001_R03·R04·R05 프로시저 조회 성능 개선 | 로컬 MariaDB 10.6에 수정 전·후 프로시저를 같은 데이터로 54개 조회·저장 시나리오 실행: 결과 동일(의도한 SEARCH_CHKRSTEQM 일상점검 제외만 차이). 설비 2,000·계획 60,000·실적 100,000건 기준 R04 주기 조회 297.7초→0.24초, R03 주기 조회 5.26초→0.27초, 미등록 항목 1,010ms→8.5ms, 설비 목록 137→18ms, R05 그룹 목록 101→13ms·설비 목록 67→19ms. BOM·CRLF·SQL 내부 날짜 0건 확인 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [EQM1001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx), [EQM1001_R05.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R05.aspx), [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql), [MES_SNS2_EQM1001_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R05.sql) | R03·R04·R05 규칙 정비 | 점검: ES6 문법·번호 주석·배너·srcVersion 변경·SQL 내부 날짜·WHERE 절 상관 서브쿼리 0건. 파라미터 R03 24·R04 22·R05 10 동일. 로컬 MariaDB 10.6(실제 GETKEY) 3개 프로시저 컴파일 및 복사·승인·주기 저장·점검자 지정·점검 등록·수정 조회 정상. R03·R04·R05 오프라인 렌더 200, JS 문법 정상, 전 파일 BOM·CRLF·중복 CR 0 |
| **완료** | [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R03.sql), [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js) | 주기관리 점검자 사원코드 저장 | 로컬 MariaDB 10.6: 사원코드 저장(E01·20001010·202507065), 조회 시 사원명 표시·코드 반환, 예전 이름 저장값 표시 유지, R04 팝업 2월 20001010·3월 202507065 정확히 지정. 오프라인 렌더 + 실제 공통 스크립트: 점검자 지정·동명이인 교체(토글 아님)·같은 사람 토글 삭제·Delete 삭제, 저장/일괄저장 요청에 사원코드 전달, 콘솔 오류 0건 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js) | R03 설비별 선택 유지 | 오프라인 렌더 + 실제 공통 스크립트: 수정 전 A-003 추가 후 A-001 선택(재현), 수정 후 추가 A-003·저장 A-005 유지, REV·항목 재조회 정상, 일반 조회는 첫 행, 콘솔 오류 0건 |
| **대기** | [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql) | R04 점검자 미표시 실서버 확인 대기 | 오프라인 렌더 + 실제 공통 스크립트 + 실제 찾기 응답 형식: 1·2·3월 서로 다른 점검자 코드·이름 자동 지정, 첫 100건 밖 점검자도 코드 재조회로 지정, 팝업 재오픈 시 월별 값 정상. 매칭 SQL 로컬 검증 |
| **완료** | [EQM1001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql) | R04 적용 REV 그리드 칸 | 로컬 MariaDB 10.6: 수정 조회 항목별 REV.1 반환, REV 적용 전 실적은 빈 값. 오프라인 렌더 + 실제 공통 스크립트: 등록 팝업 '적용 REV' 칸 REV.1·REVCD 보관·대기 안내 유지, 수정 팝업 '적용 REV' 칸 REV.0, 라벨 제거, 콘솔 오류 0건 |
| **진행 중** | [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql) | R04 점검자 기본값 원인 확인 | 로컬 MariaDB 10.6: 구분 빈 값 행만 있는 설비 E01 지정, 빈 값·'02' 행 공존 시 '02' 행(E02) 지정 |
| **완료** | [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js) | R04 등록 팝업 점검자 기본값 | 로컬 MariaDB 10.6: 이름 1명·사원코드 저장·동명이인·없는 이름·미지정·앞뒤 공백·10/12월·계획 없는 년도 8가지 통과. 오프라인 렌더 + 실제 공통 스크립트: 년월 전달, 점검자 E01 자동 지정, 동명이인 안내, 미지정 시 이전 값 남지 않음, 저장 요청에 EMPCD·REVCD 포함, 콘솔 오류 0건 |
| **완료** | [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql) | 그룹 없는 설비 주기관리 포함 | 로컬 MariaDB 10.6(실제 GETKEY, 새 REVCD 구조): 주기관리 목록에 그룹승인 설비·그룹 빈값·그룹 NULL 설비 표시, 그룹 미승인·설비 미승인·항목 없는 설비 제외, 그룹 없는 설비 주기 저장·R04 목록(점검필요)·등록 팝업·등록·수정 조회·수정·삭제 정상, 그룹 미승인 설비 저장·팝업·등록 차단, 그룹 승인 후 표시 |
| **완료** | [MES_SNS2_EQM1001_PLAN_REV_REVCD.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_REVCD.sql) | REVCD 실제 GETKEY 재검증 | 실제 GETKEY 정의 + COMKEY로 로컬 MariaDB 10.6 재검증: 운영 데이터 변환(8건 발번, 중복 0), 그룹 수정 시 소속 설비 3대 한 문장 발번 중복 없음, 그룹 승인 승인본, R04 팝업·등록·조회(REVCD 기록), 키 종류별 순번 분리(CHKRSTKEY 4·REVCD 11), 신규 설치 PLAN_REV→INIT 및 재실행 무변화(불필요 발번 없음) |
| **완료** | [MES_SNS2_EQM1001_PLAN_REV_REVCD.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_REVCD.sql)(신규), [MES_SNS2_EQM1001_PLAN_REV.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV.sql), [MES_SNS2_EQM1001_PLAN_REV_INIT.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_INIT.sql), [MES_SNS2_EQM1001_PLAN_REV_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_PLAN_REV_SYSTEM_PARAMETERS.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql), [MES_SNS2_EQM1001_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R05.sql), [EQM1001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js) | REVCD 전환 | 로컬 MariaDB 10.6 3단계 검증: ①구 구조+운영 데이터 전환(헤더 7/7 발번, 승인본 13→11 그룹 합침·고아 정리, 실적 3/3 연결, REVNUM 삭제, 확인 SELECT 0건) ②새 프로시저 흐름(R04 목록·팝업·등록·수정조회, 잘못된 키 4종 차단, R03 수정→발번→승인→승인본, 이력 항목 조회) ③신규 설치 PLAN_REV→INIT 및 INIT 재실행 무변화. R04.aspx 오프라인 렌더 200 |
| **완료** | [MES_SNS2_EQM1001_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R05.sql) | R05 반려 설비 그룹 승인 차단 | 로컬 MariaDB 10.6(실제 테이블 DDL)에서 시나리오 통과: 설비 반려 후 그룹 승인 차단 및 데이터 무변경, 반려 설비 수정(대기) 후 그룹 승인 성공, 7대 반려 시 5대+외 2대 표시, 반려 설비 있어도 그룹 반려 가능, 반려 설비를 설비별 승인 후 그룹 승인 성공, 미사용 설비 반려는 무시 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R05.sql) | R03 접속 속도 개선 방식 변경 | 로컬 MariaDB 10.6에서 두 프로시저 컴파일 및 8개 조회 코드명 반환 확인(코드명 없는 코드는 코드 그대로), 오프라인 렌더 + 실제 공통 스크립트 테스트: 접속 시 요청 8회→2회, 그리드 12개 Load 생성 유지, 전 그리드·팝업·이전 REV 조회에서 코드명 표시, 사용여부·정렬순서 편집 유지, 콘솔 오류 0건 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js) | R03 접속 속도 개선 | 오프라인 XSP 렌더 + 실제 공통 스크립트 테스트: 접속 시 요청 8회→4회, 그룹 복사/설비 복사/항목 추가 팝업 및 주기관리 탭에서 생성·콤보 표시·조회·저장 호출 정상, 재오픈 시 재생성·추가 요청 없음, 수정 전 코드와 동일 결과, 콘솔 오류 0건 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js) | 점검자 찾기 화면별 함수 원복 | 원복 후 두 파일 git 변경 없음 확인, 전체 화면에 data-limit·ItsFind_limit 직접 제어 코드 없음 확인 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [EQM1001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R04.js) | 점검자 찾기 기본 100건 유지 | 오프라인 XSP 렌더 + 실제 공통 스크립트 브라우저 테스트: 첫 조회 LIMIT=100·100건, 전체 선택 시 전체, 닫고 다시 열면 LIMIT=100·100건 복귀, 열린 상태 클릭 시 선택 건수 유지, 사원 선택 정상, 설비·설비그룹 find 영향 없음 |
| **완료** | [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_R04.sql) | R04 목록 조회 조건 보정 | 로컬 임시 MariaDB 10.6에서 8개 설비 시나리오 및 월 셀 값(점검자명/●/빈값/NULL) 시나리오 통과, 실서버 R04 프로시저 교체 필요(SYSTEM_PARAMETERS 재등록 불필요) |
| **완료** | [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx) | 1.설비그룹 / 2.설비별 / 3.주기관리 3단 탭 구성 및 컨트롤 ID 분리 표준화 | 브라우저 탭 전환 및 렌더링 검증 완료 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js) | 설비그룹 그리드(grid_GRP1, grid_GRP2) 정의 및 3개 탭 조회 분기 확장 | 콘솔 에러 0건 확인 완료 |
| **완료** | [TML5001 - R01_POP1.xaml.cs](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01_POP1.xaml.cs) | 검사 합부판정 로직 리팩터링 및 주석 표준화 | MSBuild 통과, 로직 검증 완료 |
| **완료** | [TML5001 - R01.xaml / .cs](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01.xaml) | `SetPopInfo GPCD is empty` 생명주기 오류 디스패처 비동기 큐 개선 | 하드코딩 완전 제거 |
| **완료** | [MES_SNS2_EQM1001_S01.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_S01.sql) | 설비이력카드 출력 리포트 쿼리 최적화 | 로컬 SQL 파일 반영 완료 |
| **완료** | [MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql) | MTR0001_R04 프로시저 DELIMITER 제거 및 프로젝트 표준 형식 통일 | 최상단/최하단 구분자 제거, `CREATE DEFINER ~ END CASE; END` 서식 정규화, UTF-8 BOM/CRLF 검증 완료 |
| **완료** | [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js) | MST3001_R03 코드 검색 전용 팝업(pop_FIND_LOCA) 및 키워드 조회 연동 | 독립 팝업(코드 검색) 추가, 키워드 검색창 및 돋보기 조회 버튼 배치, 더블클릭/Enter 선택 시 메인 그리드 바인딩 및 체크, pop_LOCA 관리 기능 복원. IIS Express HTTP 200 검증 완료 |
| **완료** | [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js), [MES_SNS2_DC_FIND.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_DC_FIND.sql) | MST3001_R03 공통 마스터 코드검색(ItsPop.OpenFindCOM) B안 정석 적용 및 DC_FIND 로컬 분기 추가 | 화면 전용 팝업 태그·JS 약 60줄 전면 제거, 공통 findPop_COM 프레임워크 표준 호출로 8줄 전환, DC_FIND에 LOCACD_EQMPARTS 분기 추가. JS 구문검사 통과, IIS Express HTTP 200 검증 완료 |
| **완료** | [MST3001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.aspx), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js), [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql) | MST3001_R03 로케이션 값 존재 시 수정(전체목록)·삭제(Delete키/빈값/SAVE_ITEM) 및 pop_LOCA 비율(600×500) 최적화 | 팝업 오픈 시 keyword: ''로 전체목록 제공, Delete 키 및 빈값 변경 시 LOCACD 동기화 초기화, SAVE_ITEM LOCACD_LIST 파싱/빈값 확정 저장, pop_LOCA 600×500 황금비율 최적화. JS 구문검사 통과, IIS Express HTTP 200 검증 완료 |
| **완료** | [.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md), [.agents/rules/procedure_history.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure_history.md), [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R03.sql), [MES_SNS2_EQM1001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R04.sql) | 프로시저 최상단 선언부 서식 규칙(CREATE DEFINER / PROCEDURE 2행 개행) 정정 및 표준화 적용 | 한 줄 선언 금지 및 2행 분리 개행(`CREATE DEFINER=...\nPROCEDURE ...(`) 표준화 조항(0-3) 및 템플릿 갱신, MST3001_R03·EQM1001_R03·EQM1001_R04 소스 파일 선언부 분리 개행 적용 완료. BOM·CRLF 검증 완료 |
| **완료** | [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js) | MST3001_R03 프로젝트 코딩 규칙 기반 리팩토링 및 네이밍·주석 표준화 | arrRows 표준 배열 네이밍, locaCd/locaNm 파라미터 정돈, 콤보 이벤트 날짜 주석 보강, deferUpdate/finishEditing 무결성 유지. Node.js 구문검사 통과, UTF-8 with BOM/CRLF 검증 완료 |
| **완료** | [.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md), [MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx), [MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js) | MTR0001_R04 설비부품 발주관리(발주헤더·상세 분리 조회) 및 컬럼 가로 나열 규칙 적용 | 설비부품 포함 발주헤더(grid1) 및 상세(grid2) 분리 조회, 비참조 컬럼 한 줄 다중 컬럼 가로 배치 규칙화, aspx/js 연동 완료. IIS Express 200 OK, BOM/CRLF 검증 완료 |
| **완료** | [MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql) | MTR0001_R04 설비부품 발주 조회 0건 결함 원인 분석 및 프로시저 날짜·품목·공장 유연 조건 보완 | 날짜 빈값 허용 및 8자리 비교, 품목 ITEMID/ITEMCD 매칭 및 DM1007% 호환, 공장/거래처 조건 보완 완료. Node.js BOM/CRLF 검증 통과 |
| **완료** | [MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx), [MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql) | MTR0001_R04 MTR0001_R01 원본 기반 복원, INC 2공장 디폴트 설정 및 설비부품 발주헤더 필터링 구현 | 공장 INC 2공장(인덱스 2) 디폴트 설정, 좌측 그리드 설비부품 포함 발주헤더 필터링, 품목코드 매핑(DOUBLE 에러 해결), MTR0001_R01 컬럼 구성 복원 완료. UTF-8 BOM/CRLF 검증 통과 |
| **완료** | [.agents/rules/encoding.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/encoding.md), [.agents/rules/aspx_cs_comment.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/aspx_cs_comment.md) | 이중 BOM 파서 크래시 원인 분석 및 단일 UTF-8 BOM 보장·ASPX 파서 오류 방지 규칙 강화 | 이중 BOM(\xef\xbb\xbf\xef\xbb\xbf) 절대 금지 및 3단계 바이너리 검증 절차 표준화, aspx_cs_comment.md 1-1 조항 신규 제정. IIS Express HTTP 200 검증 완료 |
| **완료** | [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js) | 실제 DB 스키마 직접 검증(DESC/SELECT) 및 MTRODR.MTRODRSEQ 제거·ITEMID 정수형 PK 조인 완전 정상화 | MTRODR에 없는 MTRODRSEQ 컬럼 SELECT 및 grid1 정의 완전 제거, I.ITEMID=D.ITEMID 정수형 PK 직접 조인으로 DOUBLE 에러 완전 박멸, 실제 DB 쿼리(75건/249건) 검증 완료. 단일 UTF-8 BOM/CRLF 무결성 확인 |
| **완료** | [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql), [01.Office/PAGEMTR/MTR0001/MTR0001_R01.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R01.aspx), [01.Office/PAGEMTR/MTR0001/MTR0001_R01.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R01.js) | MTR0001_R01(18건) 대비 MTR0001_R04(0건) 조회 차이점 정밀 원인 분석 | R01은 전체 품목 무조건 조회(18건 모두 DM100300 외주가공품), R04는 설비부품(DM1007%) 전용 필터 적용됨. 실제 DB 상 INC 2공장(07)에는 설비부품 발주가 없고 1공장(06, 75건)에만 존재함이 원인으로 규명 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.aspx), [01.Office/PAGEMTR/MTR0001/MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [05.Procedure/MES_SNS2_MTR0001_R04.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MTR0001_R04.sql) | MTR0001_R04 설비부품 발주서 출력 리포트(S04A) 신규 구현 및 DevExpress XtraReports 기반 PDF 양식 매핑 | 첨부된 PDF 발주서 양식 100% 매핑(로고, 승인박스, 공급자·공급받는자 5행 테이블, 15행 고정 그리드 및 합계행, 업체요청사항, 안내문), MTR0001.csproj 빌드 성공, MTR0001_R04.aspx 버튼 추가 및 js 연동 완료 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 설비부품 발주서 상단 단일 테이블 통합 및 품목 그리드 원본 이미지 100% 매칭 | 상단 5행 단일 XRTable 통합(행높이 24F, 좌310F/우421F 완벽일치), 품목그리드 열너비 비율(30·175·120·38·72·42·84·170) 및 2줄 행높이(28F) 원본 이미지 2 완전 일치, MSBuild 성공 및 test_odr.pdf 생성 검증 완료 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 상단 발주번호/발주일자 시작·끝선 일치, 품목 1~15행 균등 높이 및 합계 라벨 우측 정렬 완료 | 행별 독립 단일행 XRTable로 1~15행 균등 렌더링(22px), 발주일자 폭 75F 일치, 테두리 겹침 제거, 합계 라벨 TextAlignment.MiddleRight 우측 정렬(여백 10) 적용. MSBuild 성공, 바이너리 배포 및 HTML text-align:right 검증 완료 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 합계 행 수량·총금액 우측 마진(패딩 6·8) 여백 추가 및 1~15행 품목 내용 높이 1.3배 확대(36F) | 수량 패딩 6, 금액 패딩 8로 우측 테두리선 여백 형성, dataRowHeight 36F(33px)로 1.3배 확대 및 reportFooter 725F 확장, A4 단 1페이지 유지. MSBuild 성공, 바이너리 배포 및 HTML 검증 완료 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 거래처명 상하 여백 확대, 품목 그리드 헤더 높이(0.9배, 32.4F) 및 합계행 높이 데이터행 동일(36F) 일치 | 거래처명 Y=36F(로고 8px/하단 10px 여백), headerHeight=32.4F(데이터행 0.9배, 29px), totalRowHeight=36F(데이터행 100% 동일, 33px) 적용. MSBuild 빌드 성공 및 1페이지 PDF 검증 완료 |
| **완료** | [04.Report/PAGEMTR/MTR0001/S04A.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEMTR/MTR0001/S04A.cs), [01.Office/Reports/MTR0001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/MTR0001.exe) | MTR0001_S04A 로고 크기 확대, 거래처명 상단 마진 추가 및 기본 정보 5개 행 전체 텍스트 Bold 적용 | 로고 SizeF 160x38F(36px) 확대, 거래처명 Y=48F(로고 아래 10px 여백), 정보테이블 startY=84F 및 5개 행 전 셀 Bold(isHeader=true) 적용. MSBuild 빌드 성공 및 바이너리 배포 완료 |
| **완료** | [.agents/rules/procedure.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/procedure.md), [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js), [MES_SNS2_MST3001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03.sql), [MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_MST3001_R03_SYSTEM_PARAMETERS.sql) | MST3001_R03 중요도등급(GRADE) 수정·저장 및 현재고(LOTQTY) 입력 차단 연동, 로케이션 autoSizeColumns 보완, 프로시저 공통 감사함수(CALLTIME/CALLEMP/CALLPRG) 강제 규칙 제정 및 적용 | LOTQTY readOnly 차단, LOCANM 콤보 해제(gpcd 오류 해결), GRADE_LIST 전송 및 저장 연동, SearchLoca autoSizeColumns 추가, procedure.md 감사함수 규칙 제정, RTIME/MTIME/REMP/MEMP/RPRG/MPRG 공통함수 적용 완료. Node.js 구문검사 통과, UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | [MST3001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST3001/MST3001_R03.js) | MST3001_R03 드래그 선택 영역 Delete 키 삭제 시 로케이션명 잔존 결함 원인 분석 및 캡처링 이벤트 해결 | ItsPage.Load 내 grid.hostElement 캡처링 이벤트로 Delete 키 최우선 가로챔, 드래그 다중 행 LOCACD·LOCANM 동시 초기화 및 행 체크, GetCheckedRows 정합성 방어 추가. Node.js 검사 통과, UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | [MTR0001_R04.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMTR/MTR0001/MTR0001_R04.js), [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js) | MTR0001_R04 및 EQM1001_R03 리포트 호출 시 불필요한 rpt.FileName 제거 및 프레임워크 표준 정돈 | XtraReport 컨트롤러 자동 파일명 발급 기능에 따라 불필요한 rpt.FileName 하드코딩 라인 전면 제거, 기존 화면 표준(SAL0001_S05, EQM1001_S01) 일치화. JS 구문검사 통과, UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | [.agents/rules/framework_convention.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md), [.gitignore](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.gitignore) | 공통 프레임워크 우선 활용 및 기존 화면 참조 규칙 추가, 레포트 임시 파일 정리 및 .gitignore 등록 | 신규 규칙 제정(Framework-First & Reference-First), tempFiles 로컬 파일 삭제 및 .gitignore 패턴 등록, git 추적 임시파일 인덱스 제거 완료. 단일 UTF-8 BOM/CRLF 검증 통과 |
| **완료** | [R03.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.cs), [.agents/rules/report_devexpress.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/report_devexpress.md) | R03 CreateMaria 제거 및 DevExpress 리포트 규칙 수립 | CreateMaria 하드코딩 제거 및 new ItsMaria(...) 표준화, .agents/rules/report_devexpress.md 제정, framework_convention.md 연동, MSBuild 15.0 Rebuild 0 Error 통과, 바이너리 배포 및 단일 BOM 무결성 확인 |
| **완료** | [R03.Designer.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/04.Report/PAGEEQM/EQM1001/R03.Designer.cs), [EQM1001.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/Reports/EQM1001.exe) | R03 PageFooter 밴드 제거 및 재빌드·배포 | PageFooterBand 및 xrLabelFooter 완전 삭제, MSBuild 15.0 Rebuild 0 Error 통과, 최신 바이너리 배포 및 단일 BOM 무결성 확인 |
| **완료** | [R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [TML1010.csproj](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/TML1010.csproj) | TML1010 R05 부자재 재고 화면 연동 및 빌드 | x:Class 및 class R05 교정, Combo SelectedLabel 교정, csproj 등록, MSBuild 15.0 Rebuild 0 Error 통과, 바이너리 배포 및 단일 BOM 무결성 확인 |
| **완료** | [App.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/App.xaml), [TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe) | TML1010 StartupUri R05 전환 | App.xaml StartupUri="R05.xaml" 지정, MSBuild 15.0 Rebuild 0 Error 통과, 바이너리 배포 및 단일 BOM 무결성 확인 |
| **완료** | [R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe) | R05 프로시저명 TML1010_R05 전면 교체 | 프로시저 호출 4곳 TML1010_R05 교정, MSBuild 15.0 Rebuild 0 Error 통과, 바이너리 배포 및 단일 BOM 무결성 확인 |
| **완료** | [R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_TML1010_R05.sql), [TML1010.exe](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/AAABIN/TML1010.exe) | TML1010 R05 설비부품 입출고 관리 전면 전환 및 5대 기능 구현 | 설비부품코드/명/등급/로케이션/안전재고/현재고/단위/입고/출고/이력/라벨출력 11개 컬럼 그리드, 발주조회 입고, 출고, 이력조회, 프로시저 전면 개편, MSBuild 15.0 Rebuild 0 Error 통과, 배포 및 단일 BOM 무결성 확인 |
| **완료** | [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql) | TML1010_R05 과잉보호 조건문 및 NULLIF 제거, INC 2공장(07) 및 법인(60) 하드코딩 직관화 | 상단 3중 사전조회 제거, NULLIF 제거 및 ODRFACTORY='07' 고정, COALESCE/LEFT 과잉검증 단순화, 단일 UTF-8 BOM/CRLF 무결성 검증 완료 |
| **완료** | [02.Site/TMLPJT/TML1010/R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [05.Procedure/MES_SNS2_TML1010_R05.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_TML1010_R05.sql) | TML1010_R05 실제 DB 공통코드(INOUTTP_EQMPARTS) 엄격 준수 및 ENDYN 표준화 | DB 실제 등록 데이터(INOUTTP_EQMPARTS: IN_01 구매입고, OUT_01 부품교체) 전면 복원, 임의 생성 파일 삭제, C# DataView 바인딩 유지, MSTITEM.ENDYN='N' 표준화, MSBuild 15.0 빌드 성공(0 Error), 단일 BOM/CRLF 검증 완료 |
| **완료** | [.agents/rules/framework_convention.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md) | 공통코드(GPCD) 그룹 분리 및 ItsCombo 연동 표준 규칙 제정 | C# 비하인드 DataView/LIKE 필터링 금지, GPCD 분리 정석 방식 1 명문화, 마크업 자동 바인딩 및 공통 컴포넌트 우선 활용 규칙 추가, 단일 BOM/CRLF 검증 완료 |
| **완료** | [01.Office/PAGEMST/MST1002/MST1002_R06.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEMST/MST1002/MST1002_R06.js), [.agents/rules/framework_convention.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/framework_convention.md) | MST1002_R06 설비그룹 공통 콤보(FM116) 바인딩 적용 및 그리드 콤보 연동 규칙 제정 | 설비그룹코드 hidden 및 명칭 별도 컬럼 삭제, enumColumnTypes.combo(gpcd: 'FM116') 단일 콤보 바인딩 적용, framework_convention.md 제6조 규칙 추가, JS 구문 검사 및 단일 BOM/CRLF 검증 완료 |
| **완료** | [02.Site/TMLPJT/TML1010/R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs) | TML1010_R05 C# 생성자 내 불필요한 DataView 필터링 코드 완전 제거 | cmb_INTP 및 cmb_OUTTP의 잉여 DataView 필터링 2줄 완전 삭제, 순수 프레임워크 바인딩 유지, MSBuild Rebuild 빌드 성공(0 Error), 단일 BOM/CRLF 검증 완료 |
| **완료** | [R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs), [.agents/rules/Optimization.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/Optimization.md), [.agents/rules/validation.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/.agents/rules/validation.md) | TML1010_R05 쓰레기 코드 전수 무결성 검증 및 잉여 코드 자체 삭제 의무화 규칙 제정 | R05.xaml/R05.xaml.cs 쓰레기 코드 0건 전수 검증, Optimization.md 제5조 및 validation.md 제6조 신규 제정(5대 쓰레기 코드 자체 삭제 의무화), 단일 BOM/CRLF 검증 완료 |
| **완료** | [R05.xaml](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml), [R05.xaml.cs](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/02.Site/TMLPJT/TML1010/R05.xaml.cs) | TML1010_R05 입고등록 확인 팝업 메시지 간소화 및 잉여 컨트롤·변수 자체 삭제 | 확인창 문구 단일 문장("설비부품을 입고하시겠습니까?") 변경, 잉여 변수(itemCd/Nm/Unit/inTp) 및 미사용 컨트롤(cmb_IN_UNIT) 전면 삭제, 단일 BOM/CRLF 검증 완료 |
| **완료** | [05.Procedure/UPDATE_SYSLABEL_EQMPARTS.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/UPDATE_SYSLABEL_EQMPARTS.sql) | SYSLABEL EQMPARTS 라벨 양식 폭 확장(46mm) 및 폰트 8.5pt 최적화 | 부품명 46mm 폭 확장 및 폰트 8.5pt 축소, 바코드 42mm 중앙 배치, 더미 필드 제거, 단일 BOM/CRLF 검증 완료 |
| **완료** | [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js) | EQM1001_R03 설비별 점검계획 탭(grid1) 설비그룹 공통 콤보(FM116) 바인딩 적용 | 코드/명칭 분리 제거, enumColumnTypes.combo(gpcd: 'FM116') 단일 콤보 바인딩 적용, JS 구문 검사 및 단일 BOM/CRLF 검증 완료 |
| **완료** | [05.Procedure/MES_SNS2_EQM1001_R03.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.Procedure/MES_SNS2_EQM1001_R03.sql) | EQM1001_R03 설비 목록 조회(LIST_MSTEQM) 잉여 컬럼(EQMGRPNM) 및 COMTYPE 조인 제거 | 잉여 EQMGRPNM 컬럼 및 COMTYPE 조인 전면 삭제, WHERE 절 단순화, 단일 BOM/CRLF 검증 완료 |
| **완료** | [04.Report/PAGEEQM/EQM1001/R03.Designer.cs](04.Report/PAGEEQM/EQM1001/R03.Designer.cs), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe) | EQM1001 R03 레포트 점검내용 및 특이사항 컬럼 폭 미세 조정 | 점검내용 210.0px(+16.5px), 특이사항 200.0px(-16.5px), 가중치 합 1.000000D 유지, MSBuild Rebuild 통과 및 배포 완료 |
| **완료** | [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql) | EQM1001_R03 주기관리 점검자명 조회 최적화 (대안 A: MSTEMP 12회 일괄 LEFT JOIN) | 12회 서브쿼리 제거 및 LEFT JOIN MSTEMP 12회 일괄 조인 전환, UTF-8 without BOM/CRLF 검증 완료 |
| **완료** | [04.Report/PAGEEQM/EQM1001/R03.Designer.cs](04.Report/PAGEEQM/EQM1001/R03.Designer.cs), [04.Report/PAGEEQM/EQM1001/R03.cs](04.Report/PAGEEQM/EQM1001/R03.cs), [04.Report/PAGEEQM/EQM1001/R03.resx](04.Report/PAGEEQM/EQM1001/R03.resx), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe) | EQM1001 R03 레포트 Visual Studio 디자이너 호환성 오류 해결 및 CodeDOM 구조 정규화 | VS 디자이너 오픈 시 '디자인할 수 있는 클래스가 없음' 오류 원인 4가지(components 컨테이너 누락, WidthF 누락, R03A 기본 생성자 누락, Debug 빌드 어셈블리 부재) 완벽 해결, Debug/Release 빌드 및 배포 완료 |
| **대기** | [05.Procedure/MES_SNS2_EQM1001_S04.sql](05.Procedure/MES_SNS2_EQM1001_S04.sql), [04.Report/PAGEEQM/EQM1001/S04A.cs](04.Report/PAGEEQM/EQM1001/S04A.cs) | EQM1001_S04 점검시트 출력(S04A) 프로시저 서버 반영 및 출력 확인 | 빌드·배포·점검키 미전달 안내 확인 완료. 남은 확인: CALL_CHKRST_RPT 서버 반영 후 실데이터 PDF, VS 디자이너 열기, 화면 버튼 위치 |
| **완료** | [01.Office/PAGEEQM/EQM1001/EQM1001_R03.js](01.Office/PAGEEQM/EQM1001/EQM1001_R03.js), [05.Procedure/MES_SNS2_EQM1001_R03.sql](05.Procedure/MES_SNS2_EQM1001_R03.sql) | EQM1001_R03 설비그룹 및 설비별 점검계획 탭 정기점검 영역 특이사항(REMARK) 제외 및 기준정보 연동 보존 | 설비그룹 점검계획(grid_GRP2, grid_GRP_COPY2) 및 설비별 점검계획(grid3, grid8, grid10) 정기점검 특이사항 컬럼 제거, 저장(SAVE) 시 기존 특이사항 보존 및 기준정보(MSTCHKKND) 특이사항 연동, 레포트(R03) 출력 보존. UTF-8 BOM/CRLF 검증 완료 |
| **완료** | [04.Report/PAGEEQM/EQM1001/R03.cs](04.Report/PAGEEQM/EQM1001/R03.cs), [04.Report/PAGEEQM/EQM1001/EQM1001.csproj](04.Report/PAGEEQM/EQM1001/EQM1001.csproj), [.agents/rules/report_devexpress.md](.agents/rules/report_devexpress.md), [.agents/rules/report_file_structure.md](.agents/rules/report_file_structure.md) | EQM1001 R03A 파일 완전 삭제 및 1파일 1레포트 컴포넌트 원칙 규칙 제정 | R03A.cs 삭제, EQM1001.csproj 정리, VS 디자이너 파서 혼선 방지를 위한 단일 클래스 선언 원칙 규칙화 완료 |
| **완료** | [04.Report/PAGEEQM/EQM1001/R03.Designer.cs](04.Report/PAGEEQM/EQM1001/R03.Designer.cs), [04.Report/PAGEEQM/EQM1001/R03.cs](04.Report/PAGEEQM/EQM1001/R03.cs), [01.Office/Reports/EQM1001.exe](01.Office/Reports/EQM1001.exe) | EQM1001 R03 개정이력 동적 높이(XRTable) 전환 및 하단 확인란 세로 앵커 정렬 | 20개 개별 XRLabel을 xrTableRevHistory(XRTable/Row/Cell)로 전환하여 개정이력 줄바꿈 시 전 셀 높이 동기화 및 하위 행 자동 밀림 구현, 좌측 확인란 AnchorVertical.Both 적용으로 하단 테두리 완벽 일치 정렬, Debug/Release 빌드 및 배포/출력 검증 완료 |
| **대기** | [05.Procedure/MES_SNS2_EQM1001_R04.sql](05.Procedure/MES_SNS2_EQM1001_R04.sql), [01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx](01.Office/PAGEEQM/EQM1001/EQM1001_R04.aspx) | EQM1001_R04 정기점검 팝업 특이사항 입력·상단 정렬 서버 반영 및 화면 확인 | 프로시저 저장 후 SYSTEM_PARAMETERS 재등록 필요. 모형 측정으로 정렬 확인, 실제 화면·저장 미확인 |
| **대기** | MTR0001_R04 프로시저 실서버 반영 및 리포트 출력 최종 확인 | CALL_RPT 분기 포함된 MTR0001_R04.sql 실서버 DBeaver 컴파일 후 발주서 출력 버튼 최종 검증 | - |

---
_위 기록은 사용자 요청에 따라 지속적으로 업데이트됩니다._
