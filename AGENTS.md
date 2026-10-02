# 프로젝트 공통 지침

이 저장소의 작업 규칙은 `.agents/rules/` 아래 문서를 따릅니다.

## 커밋 메시지 생성 규칙 (Commit Message Generation)

커밋 메시지를 생성할 때는 **반드시 한국어로 작성**합니다. 기본 예시가 영어여도 요약은 영어로 쓰지 않습니다.
Always write the commit message summary in Korean, even if the default examples are in English. Never write the summary in English.

- 형식: `<type>: <한글 요약>` (Conventional Commits)
- type: `feat`, `fix`, `refactor`, `style`, `perf`, `docs` (영문 소문자 그대로 사용)
- 요약은 한 문장, 명사형 종결, 따옴표·마침표 없이 작성
- 올바른 예:
  - `feat: 점검계획 승인상태 필터 추가`
  - `fix: 동일 월 정기점검 중복 등록 방지`
  - `refactor: 화면 입력값 검증 로직 프로시저로 이동`
  - `docs: 작업 이력 및 프로젝트 규칙 문서 갱신`
- 잘못된 예: `feat: add approval status filter`, `refactor: optimize routine inspection queries`

자세한 기준은 `.agents/rules/commit_message.md`를 따릅니다.
