# MES 프로젝트 작업 이력 및 변경 관리 대장 (Work History)

> **문서 목적**: 본 문서는 에이전트 대화 세션 전환이나 브라우저/UI 세션 변경과 무관하게, 지금까지 진행된 작업 내역을 누락 없이 영구 보존하고 이후 작업을 지속적으로 이어서 추적·관리하기 위한 공식 작업 기록 대장입니다.  
> **최초 작성일**: 2026-09-18  
> **최종 갱신일**: 2026-10-01
> **인코딩 표준**: UTF-8 with BOM (CRLF)

---

## 📌 [기록 관리 가이드라인]
1. **작업 추가 규칙**: 새로운 작업(화면, C#, SQL, 프로시저, 버그 수정 등)을 진행할 때마다 본 문서의 최신 날짜 섹션에 작업 항목과 상세 내용을 누적 기록합니다.
2. **주석 및 네이밍 표준**: 소스코드에는 `// YYYY-MM-DD 기능설명` 표준을 준수하며, 본 문서에는 원인 분석, 설계 의도, 수정 파일 링크를 명시합니다.
3. **컴파일 및 빌드 검증**: 소스 수정 후에는 반드시 컴파일 빌드 무결성(MSBuild 등)을 확인하고 그 결과를 기재합니다.
4. **대화 기록 및 불러오기 연계**: 모든 사용자 요청 및 작업 결과는 본 문서에 실시간 동기화되어, 새 세션이나 나중에 작업 재개 시 "불러오기"를 통해 이전 맥락을 100% 이어받습니다.

---

## 🕒 2026-10-01 (목) 작업 내역

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
| **대기** | 사용자 추가 요청 사항 | 이어서 진행할 화면/기능 요청 시 즉시 반영 및 본 대장에 기록 갱신 예정 | - |

---
*위 기록은 사용자 요청에 따라 지속적으로 업데이트됩니다.*
