---
trigger: always_on
---

# Project Coding & Naming Convention Rule (Anti-AI Code Style)

MES 프로젝트의 일관성을 유지하고, 외부 프론트엔드 라이브러리나 AI 특유의 이질적인 코딩 스타일을 배제하여 기존 현업 개발자가 작성한 코드와 완벽히 융화되도록 다음 규칙을 반드시 준수합니다.

### 1. AI 특유의 이질적인 영문 네이밍 금지 (인위적인 긴 변수명 배제)
- **배경**: AI 모델이 생성하는 코드는 웹 모던 프레임워크(React/Vue)나 영미권 오픈소스 관례를 따라 지나치게 길고 장황한 영어 복합어를 남발하여, 기존 C#/MES 개발자 스타일의 레포지토리와 심각한 이질감을 유발합니다.
- **변수명 규칙 (간결하고 직관적인 MES 표준 네이밍)**:
  - 사람/사원명: `inspectorName`, `targetInspector` (지양) ➔ `empNm`, `empName` (권장)
  - 그리드 셀 값: `monthlyPlanValue`, `currentValue` (지양) ➔ `cellVal`, `val` (권장)
  - 건수/카운트: `appliedEqmCount`, `checkedCount` (지양) ➔ `saveCnt`, `cnt` (권장)
  - 배열/목록: `selectedMonthFields`, `monthFields` (지양) ➔ `arrSelMonth`, `arrMonth` (권장)
  - 존재 여부/플래그: `registeredMonths` (지양) ➔ `existMonths`, `isExist` (권장)
- **비교 예시**:
  ```javascript
  // [지양 - AI 특유의 장황한 변수명]
  var targetInspector = (ItsFind.GetNameValue('find_EMP') || '').trim();
  var selectedMonthFields = [];
  var appliedEqmCount = 0;

  // [권장 - 기존 프로젝트 스타일의 직관적인 변수명]
  var empNm = (ItsFind.GetNameValue('find_EMP') || ItsFind.GetValue('find_EMP') || '').trim();
  var arrSelMonth = [];
  var saveCnt = 0;
  ```

### 2. 함수 및 컨트롤 ID 명명 표준 (프로젝트 관례 통일)
- **함수 네이밍 (대문자+밑줄, 같은 메뉴 화면 형식 우선)**:
  - 함수명을 정하기 전에 **같은 메뉴 폴더(예: `PAGESAL`)의 기존 화면 JS를 먼저 확인**하고, 그 형식을 그대로 따릅니다. 같은 메뉴에 예가 없으면 같은 프로젝트 업무 화면에서 가장 많이 쓰는 형식을 따릅니다.
  - 기본 형식은 **대문자+밑줄(동작_대상)** 입니다: `SEARCH_LOT`, `SEARCH_CON`, `SCAN_QRCODE`, `ERP_SAVE`, `POP_SEARCH`
  - `updateToggleAllMonthsButton`, `checkIfInspectorSelected` (지양 - 장황한 카멜케이스) ➔ `SET_ALL_MONTH`, `CHECK_EMP` (권장)
  - 파스칼케이스(`SearchLot`, `ShowPlanReason`)는 같은 메뉴 화면이 그 형식을 쓰는 경우에만 사용합니다. 공통·로그인 스크립트(`PAGECOM` 등)나 에이전트가 작성·수정한 화면은 판단 기준으로 삼지 않습니다 (`priority_reference_verification.md` 1항).
  - 이미 작성된 화면의 함수명은 요청 없이 다른 형식으로 바꾸지 않습니다.
- **컨트롤 ID 네이밍 (간결하고 정형화된 약어 사용)**:
  - 버튼 ID: `btn_TOGGLE_ALL_MONTHS` (지양) ➔ `btn_ALL_MONTH` (권장), `btn_APPLY_CYCLE_BATCH` (지양) ➔ `btn_SAVE_BATCH` (권장)
  - 라벨/카운트 ID: `lbl_CYCLE_BATCH_COUNT` (지양) ➔ `lbl_BATCH_CNT` (권장)
  - 체크박스 클래스: `chk_batch_month` (지양) ➔ `chk_MONTH` (권장)
- **이름 오타 수정 범위 (이번 작업에서 직접 수정하는 부분만)**:
  - 이번 요청으로 직접 작성·수정하는 기능의 이름(컨트롤 ID, 이벤트 연결, 변수, CALLTYPE, 파라미터)에 누가 봐도 확실한 철자 오타가 있으면 수정합니다. 예: 분할취소 기능 구현 중 버튼 `btn_SPLIT_CANCLE_SALOUT` ➔ `btn_SPLIT_CANCEL_SALOUT`
  - 수정할 때는 같은 이름을 쓰는 곳(aspx ID, js 이벤트, 프로시저 CALLTYPE·파라미터, `SYSTEM_PARAMETERS`)을 함께 바꾸고, 전체 검색으로 남은 참조가 없는지 확인합니다.
  - 이번 작업에서 수정하지 않는 기존 코드의 오타는 프로젝트 어디에 있든 수정하지 않습니다. 예: 같은 화면이라도 손대지 않는 출하완료 조회 `chk_SEARCH_FINSIH_SALOUT`·`$YN_SEARCH_FINSIH_SALOUT`는 그대로 둡니다.
  - 일부러 줄였거나 프로젝트 관례일 수 있는 이름처럼 오타인지 확실하지 않으면 수정하지 않습니다.

### 3. 인위적인 AI 주석 스타일 금지 (자연스러운 개발자 주석)
- **번호 매기기 주석 절대 금지**:
  - `// 1. 점검자 취득`, `// 2. 대상 월 확인`, `// 3. 설비별 바인딩`, `// 4. DB 즉시 저장` 등 기계적으로 번호를 나열하는 AI 특유의 주석을 절대 작성하지 않습니다.
- **자연스럽고 간결한 기능 설명**:
  - `// 점검자 미선택 시`, `// 선택 설비 월별 점검자 바인딩`, `// 연간 점검계획 즉시 저장` 처럼 실제 사람이 작성하는 형태의 자연스러운 주석을 작성합니다.
- **날짜 주석 형식 준수 (`Optimization.md`와의 연계)**:
  - 신규 함수/이벤트 블록 최상단에는 반드시 `// YYYY-MM-DD [위치] 상세 기능설명`을 작성하되, 내부 로직의 세부 주석은 번호 없이 간결하고 자연스럽게 작성합니다.
  - 단, `ItsPage.Load` 위에는 날짜 주석 없이 템플릿 주석 `/* 페이지 로드 시 수행 */`만 둡니다 (`Optimization.md` 2항 예외).

### 4. 불필요한 고도화 자바스크립트 문법 지양 및 jQuery/ItsFramework 일관성 유지
- 브라우저 호환성 및 기존 레거시 프레임워크와의 조화를 위해 최신 ES6+ 고도화 문법(`Object.entries`, 복합 비구조화 할당, 화살표 함수 등)의 무분별한 사용을 지양하고, 기존 프로젝트가 사용하는 직관적인 jQuery / ItsFramework API 스타일(`ItsGrid`, `ItsFind`, `ItsPop`, `ItsMsg`)을 철저히 준수합니다.
