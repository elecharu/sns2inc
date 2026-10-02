# MES 프로젝트 작업 이력 및 변경 관리 대장 (Work History)

> **문서 목적**: 본 문서는 에이전트 대화 세션 전환이나 브라우저/UI 세션 변경과 무관하게, 지금까지 진행된 작업 내역을 누락 없이 영구 보존하고 이후 작업을 지속적으로 이어서 추적·관리하기 위한 공식 작업 기록 대장입니다.  
> **최초 작성일**: 2026-09-18  
> **최종 갱신일**: 2026-10-02
> **인코딩 표준**: UTF-8 with BOM (CRLF)

---

## 📌 [기록 관리 가이드라인]
1. **작업 추가 규칙**: 새로운 작업(화면, C#, SQL, 프로시저, 버그 수정 등)을 진행할 때마다 본 문서의 최신 날짜 섹션에 작업 항목과 상세 내용을 누적 기록합니다.
2. **주석 및 네이밍 표준**: 소스코드에는 `// YYYY-MM-DD 기능설명` 표준을 준수하며, 본 문서에는 원인 분석, 설계 의도, 수정 파일 링크를 명시합니다.
3. **컴파일 및 빌드 검증**: 소스 수정 후에는 반드시 컴파일 빌드 무결성(MSBuild 등)을 확인하고 그 결과를 기재합니다.
4. **대화 기록 및 불러오기 연계**: 모든 사용자 요청 및 작업 결과는 본 문서에 실시간 동기화되어, 새 세션이나 나중에 작업 재개 시 "불러오기"를 통해 이전 맥락을 100% 이어받습니다.

---

## 🕒 2026-10-02 (금) 작업 내역

### 1. AI Git 커밋 메시지 한글 생성 규칙 제정 및 환경 설정
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
| **대기** | 사용자 추가 요청 사항 | 이어서 진행할 화면/기능 요청 시 즉시 반영 및 본 대장에 기록 갱신 예정 | - |

---
*위 기록은 사용자 요청에 따라 지속적으로 업데이트됩니다.*
