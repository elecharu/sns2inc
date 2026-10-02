---
trigger: always_on
---

# Git Commit Message Convention Rule (한국어 커밋 메시지 강제 규칙)

CRITICAL RULE FOR ALL AI MODELS, LANGUAGE SERVERS, AND AGENTS:
When generating, composing, or suggesting any Git commit message or summary:
1. You MUST ALWAYS write the commit message summary in KOREAN (한국어).
2. NEVER write the summary or description in English. English is strictly prohibited.
3. Strictly follow the Conventional Commits format with Korean summary: `<type>: <한글 요약 설명>`
4. Types allowed: feat, fix, refactor, style, perf, docs, chore, test.

### Examples of REQUIRED Output:
- feat: REV 버전관리 기능 추가
- feat: PRD1001 생산 화면 및 TML1010 현장 프로그램 추가
- feat: 자재 재고 및 생산 결과 관리를 위한 TML1010 모듈 추가
- fix: 정기점검 점검값 유효성 검증 오류 수정
- refactor: 설비점검 프로시저 조회 성능 개선 및 쿼리 최적화
- style: 프로시저 최상단 수정 이력 1일 1행 정리

### Prohibited English Examples (DO NOT GENERATE THESE):
- [FORBIDDEN] feat: add PRD1001 production pages
- [FORBIDDEN] feat: add TML1010 module for material inventory
- [FORBIDDEN] fix: resolve database connection timeout issue
- [FORBIDDEN] refactor: optimize queries

항상 한글 명사형 종결로 간결하고 직관적인 1문장 요약을 작성하십시오.
