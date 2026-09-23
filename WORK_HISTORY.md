# MES 프로젝트 작업 이력 및 변경 관리 대장 (Work History)

> **문서 목적**: 본 문서는 에이전트 대화 세션 전환이나 브라우저/UI 세션 변경과 무관하게, 지금까지 진행된 작업 내역을 누락 없이 영구 보존하고 이후 작업을 지속적으로 이어서 추적·관리하기 위한 공식 작업 기록 대장입니다.  
> **최초 작성일**: 2026-09-18  
> **최종 갱신일**: 2026-09-18  
> **인코딩 표준**: UTF-8 with BOM (CRLF)

---

## 📌 [기록 관리 가이드라인]
1. **작업 추가 규칙**: 새로운 작업(화면, C#, SQL, 프로시저, 버그 수정 등)을 진행할 때마다 본 문서의 최신 날짜 섹션에 작업 항목과 상세 내용을 누적 기록합니다.
2. **주석 및 네이밍 표준**: 소스코드에는 `// YYYY-MM-DD 기능설명` 표준을 준수하며, 본 문서에는 원인 분석, 설계 의도, 수정 파일 링크를 명시합니다.
3. **컴파일 및 빌드 검증**: 소스 수정 후에는 반드시 컴파일 빌드 무결성(MSBuild 등)을 확인하고 그 결과를 기재합니다.

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
| **완료** | [EQM1001_R03.aspx](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.aspx) | 1.설비그룹 / 2.설비별 / 3.주기관리 3단 탭 구성 및 컨트롤 ID 분리 표준화 | 브라우저 탭 전환 및 렌더링 검증 완료 |
| **완료** | [EQM1001_R03.js](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/01.Office/PAGEEQM/EQM1001/EQM1001_R03.js) | 설비그룹 그리드(grid_GRP1, grid_GRP2) 정의 및 3개 탭 조회 분기 확장 | 콘솔 에러 0건 확인 완료 |
| **완료** | [TML5001 - R01_POP1.xaml.cs](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01_POP1.xaml.cs) | 검사 합부판정 로직 리팩터링 및 주석 표준화 | MSBuild 통과, 로직 검증 완료 |
| **완료** | [TML5001 - R01.xaml / .cs](file:///d:/ITS_MES_KJ_VA.1.0/02.Site/TMLPJT/TML5001/R01.xaml) | `SetPopInfo GPCD is empty` 생명주기 오류 디스패처 비동기 큐 개선 | 하드코딩 완전 제거 |
| **완료** | [MES_SNS2_EQM1001_S01.sql](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/05.PROCEDURE/MES_SNS2_EQM1001_S01.sql) | 설비이력카드 출력 리포트 쿼리 최적화 | 로컬 SQL 파일 반영 완료 |
| **대기** | 사용자 추가 요청 사항 | 이어서 진행할 화면/기능 요청 시 즉시 반영 및 본 대장에 기록 갱신 예정 | - |

---
*위 기록은 사용자 요청에 따라 지속적으로 업데이트됩니다.*
