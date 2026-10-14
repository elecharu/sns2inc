---
trigger: always_on
---

# Stored Procedure Correlated Subquery Prevention Rule (DB 서버 다운 방지 원칙)

데이터베이스 프로시저 작성 시 MariaDB 서버 데몬(mysqld) 프로세스 크래시(SIGSEGV)를 원천 방지하기 위해 다음 원칙을 절대적으로 준수합니다.

---

### 1. [서버 다운 방지 절대 원칙] SELECT WHERE 절 내 상관 서브쿼리(NOT EXISTS / EXISTS) 사용 절대 금지
- **배경 및 원인 (2026-09-02, 2026-09-21 DB 서버 크래시 실사례)**:
  - 시스템의 ADO.NET 드라이버(`MySql.Data.dll` 6.9.9, 레거시 버전)와 공통 디스패처 프로시저 `COMCALLC`(동적 `PREPARE ... EXECUTE` 커넥션 풀 재사용 환경) 간의 결합 이슈로 인해 발생합니다.
  - **여러 행을 반환하는 SELECT 문의 `WHERE` 절 안에 외부 행(바깥 테이블 컬럼)을 참조하는 상관 서브쿼리(`NOT EXISTS`, `EXISTS`, `OR EXISTS`)가 존재할 경우, MariaDB 옵티마이저의 세미조인/구체화 과정에서 프로토콜 충돌이 발생하여 MariaDB 데몬(mysqld) 프로세스 자체가 SIGSEGV 크래시로 다운**됩니다.
  - 이로 인해 클라이언트(웹 애플리케이션)에 `"Fatal error encountered during command execution."` (Lost connection to MySQL server / WinError 10054) 예외가 발생하고 DB 연결이 즉시 단절됩니다.

---

### 2. 위험 / 안전 서브쿼리 구분 기준
- **위험 (절대 사용 금지 - DB 서버 크래시 유발)**:
  - `WHERE` 절에서 행 필터링 용도로 사용되는 모든 상관 서브쿼리
    - `WHERE ... AND NOT EXISTS (SELECT 1 FROM ... WHERE B.KEY = A.KEY)`
    - `WHERE ... AND EXISTS (SELECT 1 FROM ... WHERE B.KEY = A.KEY)`
    - `WHERE ... OR EXISTS (SELECT 1 FROM ... WHERE B.KEY = A.KEY)`
- **안전 (사용 허용)**:
  - `SELECT` 컬럼 목록 안에서 행별 계산/표시용 상관 서브쿼리 (`CASE WHEN EXISTS (...) THEN 'Y' ELSE 'N' END`) — 단순 행 단위 계산 경로이므로 안전
  - 프로시저 제어문 단독 스칼라 존재 확인 (`IF EXISTS (SELECT 1 FROM ... WHERE KEY = $KEY) THEN`) — 외부 SELECT 행과 상관되지 않는 단독 쿼리이므로 안전

---

### 3. 표준 대체 구현 패턴 (Anti-join 및 조인 변환)
- **`NOT EXISTS` 대체 ➔ Anti-join (`LEFT JOIN ... WHERE 조인테이블.PK IS NULL`)**:
  ```sql
  -- [위험 - 절대 금지 (서버 다운 유발)]
  SELECT A.* FROM TABLE_A A
  WHERE NOT EXISTS (SELECT 1 FROM TABLE_B B WHERE B.KEY = A.KEY);

  -- [안전 - 표준 권장 (Anti-join)]
  SELECT A.* FROM TABLE_A A
  LEFT JOIN TABLE_B B ON B.KEY = A.KEY
  WHERE B.KEY IS NULL;
  ```
- **`EXISTS` 대체 ➔ `INNER JOIN` 또는 `LEFT JOIN`**:
  ```sql
  -- [위험 - 절대 금지]
  SELECT A.* FROM TABLE_A A
  WHERE EXISTS (SELECT 1 FROM TABLE_B B WHERE B.KEY = A.KEY);

  -- [안전 - 표준 권장 (INNER JOIN)]
  SELECT A.* FROM TABLE_A A
  INNER JOIN TABLE_B B ON B.KEY = A.KEY;
  ```
- **코드명 조건 검색용 `EXISTS` 대체 ➔ `LEFT JOIN`**:
  ```sql
  -- [위험 - 절대 금지]
  WHERE M.GRP = $GRP OR EXISTS (SELECT 1 FROM COMTYPE CT WHERE CT.GPCD = 'FM116' AND CT.TPCD = M.GRP AND CT.TPNM LIKE CONCAT('%', $GRP, '%'))

  -- [안전 - 표준 권장 (LEFT JOIN 후 WHERE 절에서 직접 필터링)]
  FROM (...) M
  LEFT JOIN COMTYPE CT ON CT.GPCD = 'FM116' AND CT.TPCD = M.GRP
  WHERE (IFNULL($GRP, '') = '' OR M.GRP LIKE CONCAT('%', $GRP, '%') OR CT.TPNM LIKE CONCAT('%', $GRP, '%'))
  ```
