# Conversation & Work History Tracking Rule (Auto-Save & Auto-Resume)

모든 대화와 작업 내용을 누락 없이 영구 기록하여, 세션이 종료되거나 새로운 대화창으로 전환되더라도 언제든지 이전 작업 맥락을 완벽히 불러와 연속성 있게 작업을 이어갈 수 있도록 다음 원칙을 반드시 준수합니다.

### 1. 작업 완료 시 자동 기록 의무 (Auto-Save Mandate)
- **위치**: 프로젝트 루트 디렉터리의 [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)
- **무조건 자동 저장 원칙**:
  - 화면 UI(`.aspx`), 스크립트(`.js`), 백엔드 C#(`.cs`), DB 프로시저(`.sql`) 등 소스 코드를 생성/수정하거나, 버그 해결 및 화면 검증을 완료한 모든 작업 턴(Turn)에서는 **사용자가 "저장해줘" 또는 "기록해줘"라고 별도로 요청하지 않아도 에이전트가 스스로 [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)에 작업 내역과 하단 [현재 작업 상태 (Work In Progress)] 테이블을 최신 상태로 자동 업데이트/저장**해야 합니다.
- **기록 필수 5대 항목**:
  1. 작업 일자 및 번호/제목 (예: `### 1. TQC1001_R02 검사 조회 로직 개선`)
  2. 수정/추가된 파일의 정확한 경로 및 파일 링크 (`[파일명](file:///...)`)
  3. 사용자 요청 사항 및 작업 배경/원인 분석
  4. 구체적인 해결 내용 및 적용 로직
  5. 검증 결과 및 현재 진행 상태 (진행 중 / 완료 / 대기)

### 2. "지난 작업 불러와줘" 자동 복원 프로토콜 (Auto-Load & Resume Protocol)
- **트리거 발화**:
  - 사용자가 "지난 작업 불러와줘", "이어서 진행해줘", "이전 작업 내용", "지난번 하던거", "작업 이력 확인" 등 세션 복원성 명령을 내린 경우.
- **3단계 복원 절차**:
  1. **1단계 (이력 조회)**: 자동화 스크립트(`node .agents/skills/work-history-manager/scripts/sync_history.js --read-latest`) 또는 [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)를 즉시 조회합니다.
  2. **2단계 (3단 브리핑)**:
     - **직전 완료 작업**: 가장 최근 일자에 완료된 작업 요약 및 수정 파일 링크
     - **현재 상태 요약**: WIP 테이블 상의 대기 및 진행 상태
     - **다음 작업 제안**: 이어서 즉시 착수해야 할 작업(To-Do) 목록을 구체적으로 제시
  3. **3단계 (즉시 착수)**: 사용자의 확인 또는 지시에 따라 지체 없이 다음 개발 작업에 돌입합니다.

### 3. 자동화 도구 및 스크립트 활용
- `.agents/skills/work-history-manager/` 스킬과 내장 스크립트를 적극 활용합니다.
  - 최신 이력 읽기: `node .agents/skills/work-history-manager/scripts/sync_history.js --read-latest`
  - 신규 작업 추가: `node .agents/skills/work-history-manager/scripts/sync_history.js --add-task [제목] [파일] [배경] [상세] [검증] [상태] [WIP]`
  - 무결성 검증: `node .agents/skills/work-history-manager/scripts/sync_history.js --validate`

### 4. 파일 무결성 및 인코딩 준수
- [WORK_HISTORY.md](file:///d:/ITS_MES_SNSINC_FAC2_VA.1.0/WORK_HISTORY.md)를 갱신할 때는 반드시 `encoding.md` 규칙에 따라 **UTF-8 with BOM** 및 **CRLF 개행**을 철저히 유지하며, 기존 과거 이력을 임의로 삭제하거나 훼손하지 않습니다.
