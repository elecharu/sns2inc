# MES 프로젝트 작업 이력 및 변경 관리 대장 (Work History)

> **문서 목적**: 본 문서는 에이전트 대화 세션 전환이나 브라우저/UI 세션 변경과 무관하게, 지금까지 진행된 작업 내역을 누락 없이 영구 보존하고 이후 작업을 지속적으로 이어서 추적·관리하기 위한 공식 작업 기록 대장입니다.  
> **최초 작성일**: 2026-09-18  
> **최종 갱신일**: 2026-10-07
> **인코딩 표준**: UTF-8 with BOM (CRLF)

---

## 📌 [기록 관리 가이드라인]
1. **작업 추가 규칙**: 새로운 작업(화면, C#, SQL, 프로시저, 버그 수정 등)을 진행할 때마다 본 문서의 최신 날짜 섹션에 작업 항목과 상세 내용을 누적 기록합니다.
2. **주석 및 네이밍 표준**: 소스코드에는 `// YYYY-MM-DD 기능설명` 표준을 준수하며, 본 문서에는 원인 분석, 설계 의도, 수정 파일 링크를 명시합니다.
3. **컴파일 및 빌드 검증**: 소스 수정 후에는 반드시 컴파일 빌드 무결성(MSBuild 등)을 확인하고 그 결과를 기재합니다.
4. **대화 기록 및 불러오기 연계**: 모든 사용자 요청 및 작업 결과는 본 문서에 실시간 동기화되어, 새 세션이나 나중에 작업 재개 시 "불러오기"를 통해 이전 맥락을 100% 이어받습니다.

---

## 🕒 2026-10-07 (수) 작업 내역

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
- **검증 결과**: IIS Express(http://localhost:55085/) 호출 검증 결과 MST3001_R03.aspx 및 TOL0003_R05.aspx 모두 200 OK 정상 서빙 확인, 전 파일 UTF-8 with BOM 및 CRLF 무결성 검증 완료


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
  - `doGenerateCommitMessage` 핸들러 내에서 언어 서버의 생성 결과(`t.commitMessage?.commitMessageSummary`) 수신 후, 커밋 입력창(`V.inputBox.value`)에 주입하기 직전에 Conventional Commits 접두사(`feat: `, `fix: `, `refactor: ` 등)를 유지하면서 설명문을 자연스러운 한국어로 자동 변환/번역하여 채워넣도록 패치.
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
| **완료** | 01.Office/PAGEMST/MST3001/MST3001_R03 (aspx, aspx.cs, js), 01.Office/PAGETOL/TOL0003/TOL0003_R05 (aspx, aspx.cs, js) | MST3001_R03 및 TOL0003_R05 표준화 완료, IIS Express 200 OK 서빙 확인 | IIS Express(http://localhost:55085/) 호출 검증 결과 MST3001_R03.aspx 및 TOL0003_R05.aspx 모두 200 OK 정상 서빙 확인, 전 파일 UTF-8 with BOM 및 CRLF 무결성 검증 완료 |
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
| **대기** | 사용자 추가 요청 사항 | 이어서 진행할 화면/기능 요청 시 즉시 반영 및 본 대장에 기록 갱신 예정 | - |

---
*위 기록은 사용자 요청에 따라 지속적으로 업데이트됩니다.*
