---
trigger: always_on
---

# Stored Procedure Compilation & Delimiter Rule (DB 툴 컴파일 오류 방지 규칙)

DB 클라이언트 도구(DBeaver, HeidiSQL 등)를 통해 MariaDB 저장 프로시저를 생성하거나 반영할 때 구문 분석 파싱 오류(`SQL Error [1064]`)를 방지하기 위해 다음 원칙을 준수합니다.

---

### 1. 배경 및 원인 (DBeaver / HeidiSQL SQL Error [1064] 실사례)
- **오류 증상**: `SQL Error [1064]: You have an error in your SQL syntax ... near 'WHEN ...' at line XX`
- **발생 원인**:
  - 프로시저 내부에는 각 `WHEN ... THEN` 분기마다 `SELECT ... ;`와 같이 수많은 세미콜론(`;`)이 존재합니다.
  - MariaDB 서버의 문제가 아니라, **DB 클라이언트 도구(DBeaver, HeidiSQL 등)의 명령문 구분자(Statement Delimiter) 파싱 방식 때문**에 발생합니다.
  - DBeaver에서 **단일 쿼리 실행(`Ctrl + Enter`)**을 누르거나 일반 스크립트 실행 시, 도구가 프로시저 내부의 세미콜론(`;`)을 단일 쿼리의 끝으로 인식하여 문장을 강제로 자르고, 그 다음 줄인 `WHEN '...' THEN`부터 별개의 독립된 SQL 문장으로 서버에 전송합니다.
  - MariaDB 서버는 아무런 컨텍스트 없이 날아온 `WHEN '...' THEN` 단독 문장을 파싱할 수 없으므로 1064 구문 오류를 발생시킵니다.

---

### 2. 올바른 컴파일 및 DB 반영 3대 방법
- **방법 1 (가장 권장 - Routine Editor 직접 수정)**:
  - DBeaver 좌측 네비게이터에서 해당 프로시저(`EQM1001_R03` 등)를 더블 클릭 ➔ [소스] 탭에 전체 코드를 붙여넣고 하단의 **`저장(Save / Ctrl + S)`** 버튼을 누르면 DBeaver가 자체적으로 단일 DDL로 안전하게 컴파일합니다.
- **방법 2 (스크립트 창에서 전체 실행)**:
  - SQL 편집기에서 `Ctrl + Enter`(단일 문장 실행)를 누르지 말고, `Ctrl + A`로 전체 선택 후 반드시 **`Alt + X` (SQL 스크립트 실행)**를 실행해야 합니다.
- **방법 3 (DELIMITER 명시)**:
  - SQL 편집기에서 스크립트로 직접 생성할 때는 최상단과 최하단에 `DELIMITER`를 명시하여 툴이 세미콜론 단위로 자르지 못하도록 방지합니다:
    ```sql
    DELIMITER $$
    DROP PROCEDURE IF EXISTS `{SCHEMA}`.`EQM1001_R03` $$
    CREATE DEFINER=`root`@`%` 
    PROCEDURE `{SCHEMA}`.`EQM1001_R03`(...)
    PROC: BEGIN
      ...
    END $$
    DELIMITER ;
    ```
