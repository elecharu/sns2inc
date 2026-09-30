---
name: work-history-manager
description: >-
  Automated work history recording, session restoration, and continuous progress tracking using WORK_HISTORY.md.
  Use whenever the user asks to load previous work ('지난 작업 불러와줘', '이어서 진행해줘', '작업 이력 확인') or automatically
  after modifying files and completing tasks to persist project history.
---

# Work History Manager & Session Restoration Skill

본 스킬은 MES 프로젝트 진행 중 발생하는 모든 사용자 요청, 코드 수정, 설계 결정 및 검증 결과를 [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)에 **스스로 자동 기록**하고, 사용자가 **"지난 작업 불러와줘"**라고 요청했을 때 **직전 작업 맥락을 즉각 100% 복원하여 끊김 없이 작업을 이어갈 수 있도록** 지원하는 표준 스킬입니다.

---

## 🚀 1. 빠른 불러오기 워크플로우 (Fast Load & Resume)

사용자가 **"지난 작업 불러와줘"**, **"이어서 진행해줘"**, **"지난번 하던거"**, **"작업 이력 확인"** 등의 요청을 했을 때 실행합니다.

### 실행 단계:
1. 최신 작업 내역을 스크립트로 신속하게 조회:
   ```bash
   node .agents/skills/work-history-manager/scripts/sync_history.js --read-latest
   ```
2. 사용자에게 **3단계 표준 브리핑** 제공:
   - **1단계 (직전 완료 작업)**: 가장 최근 날짜에 완료된 주요 작업 및 수정한 핵심 파일 링크.
   - **2단계 (현재 상태 요약)**: 대기열(WIP) 상의 현재 진행/대기 상태.
   - **3단계 (다음 작업 제안)**: 이어서 착수해야 할 작업 목록을 구체적으로 제시하고 확인 요청.

---

## 💾 2. 자동 기록 워크플로우 (Auto-Record Workflow)

소스코드(`.aspx`, `.js`, `.cs`, `.sql` 등)를 수정하거나 특정 버그/기능 구현을 완료한 모든 턴(Turn)에서는, **사용자의 추가 요청이 없어도 에이전트가 종료 전 자동으로 기록**을 남깁니다.

### 실행 방법:
- **자동화 스크립트 활용**:
  ```bash
  node .agents/skills/work-history-manager/scripts/sync_history.js --add-task "[작업제목]" "[수정파일목록]" "[배경및원인]" "[작업상세내용]" "[검증결과]" "[완료/진행중]" "[WIP설명]"
  ```
- 또는 직접 [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)에 오늘 날짜 섹션을 확인하고 추가/수정.

### 기록 필수 5대 항목:
1. **작업 일자 및 번호/제목**: `### N. [프로그램ID] 작업 명칭`
2. **수정/대상 파일**: 정확한 파일 링크 (`[파일명](file:///...)`)
3. **배경 및 원인 분석**: 문제 발생 원인 또는 신규 요구사항 배경
4. **작업 상세 내용**: 구체적 구현 로직 및 변경점
5. **검증 결과 및 WIP 상태**: 컴파일/빌드, 브라우저 렌더링, 콘솔 에러 0건 여부

---

## 🛡️ 3. 인코딩 및 파일 무결성 보장

[WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)는 프로젝트의 핵심 자산이므로 항상 다음 검증을 수행합니다:
```bash
node .agents/skills/work-history-manager/scripts/sync_history.js --validate
```
- **UTF-8 with BOM (`\xef\xbb\xbf`)** 필수 유지.
- **Windows CRLF (`\r\n`)** 개행 통일 (`\r\r\n` 방지).
