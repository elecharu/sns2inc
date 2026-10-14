---
trigger: always_on
---

# Procedure Development Rule

데이터베이스 프로시저 및 SQL 소스 파일을 작성하거나 수정할 때 코드 품질, 가독성, 추적성 및 시스템 안정성을 보장하기 위해 다음 원칙을 반드시 준수합니다.

### 0. [최우선 0순위 원칙] 실제 서버 DB 조작 및 공통 컴포넌트 수정 절대 금지
- **실제 서버 DB 직접 반영 절대 금지**:
  - 프로시저, 함수, 테이블 등 데이터베이스 객체를 생성/수정/삭제할 때 **실제 연결된 서버 DB에 쿼리(`CREATE`, `ALTER`, `DROP`, `INSERT`, `UPDATE`, `DELETE` 등)를 직접 실행하는 행위를 절대 엄금합니다.**
  - 모든 작업은 반드시 프로젝트 내 존재하는 프로시저 폴더(`05.PROCEDURE/` 등) 안의 **로컬 소스 파일(`.sql`)만을 수정**해야 하며, DB 반영은 사용자가 직접 진행합니다.
- **공통 컴포넌트 프로시저 및 함수 임의 변경 절대 금지**:
  - `DC_FIND`, `DC_COMBO`, `GPCD` 등 전체 시스템 및 모든 화면에서 공통으로 참조하는 핵심 공통 DB 객체는 개별 화면의 개발 편의나 요구사항을 이유로 **절대 임의로 수정/변경하지 않습니다.**
  - 개별 화면 요구사항은 반드시 해당 화면 전용 소스 파일(`.js`, `.aspx`) 및 화면 전용 프로시저 내에서 독립적으로 처리합니다.

### 0-1. [서버 다운 방지 절대 원칙] SELECT WHERE 절 내 상관 서브쿼리(NOT EXISTS / EXISTS) 사용 절대 금지
- **배경 및 원인 (2026-09-02, 2026-09-21 DB 서버 크래시 실사례)**:
  - 시스템의 ADO.NET 드라이버(`MySql.Data.dll` 6.9.9, 레거시 버전)와 공통 디스패처 프로시저 `COMCALLC`(동적 `PREPARE ... EXECUTE` 커넥션 풀 재사용 환경) 간의 결합 이슈로 인해, **여러 행을 반환하는 SELECT 문의 `WHERE` 절 안에 외부 행(바깥 테이블 컬럼)을 참조하는 상관 서브쿼리(`NOT EXISTS`, `EXISTS`)가 존재할 경우 MariaDB 옵티마이저의 세미조인/구체화 과정에서 프로토콜 충돌이 발생하여 MariaDB 데몬(mysqld) 프로세스 자체가 SIGSEGV 크래시로 다운**됩니다.
  - 이로 인해 클라이언트(웹 애플리케이션)에 `"Fatal error encountered during command execution."` (Lost connection to MySQL server / WinError 10054) 예외가 발생하고 DB 연결이 즉시 단절됩니다.
- **위험 / 안전 구분 기준**:
  - **위험 (절대 사용 금지 - DB 서버 크래시 유발)**:
    - `WHERE` 절에서 행 필터링 용도로 사용되는 모든 상관 서브쿼리 (`WHERE ... AND NOT EXISTS (...)`, `WHERE ... AND EXISTS (...)`, `WHERE ... OR EXISTS (...)`)
  - **안전 (사용 허용)**:
    - `SELECT` 컬럼 목록 안에서 행별 계산/표시용 상관 서브쿼리 (`CASE WHEN EXISTS (...) THEN 'Y' ELSE 'N' END`) — 단순 행 단위 계산 경로이므로 안전
    - 프로시저 제어문 단독 스칼라 존재 확인 (`IF EXISTS (SELECT 1 FROM ... WHERE KEY = $KEY) THEN`) — 외부 SELECT 행과 상관되지 않는 단독 쿼리이므로 안전
- **표준 대체 구현 패턴 (Anti-join 및 조인 변환)**:
  - **`NOT EXISTS` 대체 -> Anti-join (`LEFT JOIN ... WHERE 조인테이블.PK IS NULL`)**:
    ```sql
    -- [위험 - 절대 금지 (서버 다운 유발)]
    SELECT A.* FROM TABLE_A A
    WHERE NOT EXISTS (SELECT 1 FROM TABLE_B B WHERE B.KEY = A.KEY);

    -- [안전 - 표준 권장 (Anti-join)]
    SELECT A.* FROM TABLE_A A
    LEFT JOIN TABLE_B B ON B.KEY = A.KEY
    WHERE B.KEY IS NULL;
    ```
  - **`EXISTS` 대체 -> `INNER JOIN` 또는 `LEFT JOIN`**:
    ```sql
    -- [위험 - 절대 금지]
    SELECT A.* FROM TABLE_A A
    WHERE EXISTS (SELECT 1 FROM TABLE_B B WHERE B.KEY = A.KEY);

    -- [안전 - 표준 권장 (INNER JOIN)]
    SELECT A.* FROM TABLE_A A
    INNER JOIN TABLE_B B ON B.KEY = A.KEY;
    ```
  - **코드명 조건 검색용 `EXISTS` 대체 -> `LEFT JOIN`**:
    ```sql
    -- [위험 - 절대 금지]
    WHERE M.GRP = $GRP OR EXISTS (SELECT 1 FROM COMTYPE CT WHERE CT.GPCD = 'FM116' AND CT.TPCD = M.GRP AND CT.TPNM LIKE CONCAT('%', $GRP, '%'))

    -- [안전 - 표준 권장 (LEFT JOIN 후 WHERE 절에서 직접 필터링)]
    FROM (...) M
    LEFT JOIN COMTYPE CT ON CT.GPCD = 'FM116' AND CT.TPCD = M.GRP
    WHERE (IFNULL($GRP, '') = '' OR M.GRP LIKE CONCAT('%', $GRP, '%') OR CT.TPNM LIKE CONCAT('%', $GRP, '%'))
    ```

### 0-2. [DB 툴 컴파일 오류 방지] Stored Procedure 컴파일 시 구분자(Delimiter) 및 SQL Error [1064] 주의사항
- **배경 및 원인 (DBeaver / HeidiSQL `SQL Error [1064] near 'WHEN ...' at line XX` 실사례)**:
  - 프로시저 내부에는 각 `WHEN ... THEN` 분기마다 `SELECT ... ;`와 같이 수많은 세미콜론(`;`)이 존재합니다.
  - MariaDB 서버의 문제가 아니라, **DB 클라이언트 도구(DBeaver, HeidiSQL 등)의 명령문 구분자(Statement Delimiter) 파싱 방식 때문**에 발생합니다.
  - DBeaver에서 **단일 쿼리 실행(`Ctrl + Enter`)**을 누르거나 일반 스크립트 실행 시, 도구가 프로시저 내부의 세미콜론(`;`)을 단일 쿼리의 끝으로 인식하여 문장을 강제로 자르고, 그 다음 줄인 `WHEN '...' THEN`부터 별개의 독립된 SQL 문장으로 서버에 전송합니다.
  - MariaDB 서버는 아무런 컨텍스트 없이 날아온 `WHEN '...' THEN` 단독 문장을 파싱할 수 없으므로 `SQL Error [1064]: You have an error in your SQL syntax ... near 'WHEN ...' at line XX` 에러를 발생시킵니다.
- **올바른 컴파일 및 반영 방법**:
  - **방법 1 (가장 권장 - Routine Editor 직접 수정)**:
    - DBeaver 좌측 네비게이터에서 해당 프로시저(`EQM1001_R03`)를 더블 클릭 -> [소스] 탭에 전체 코드를 붙여넣고 하단의 **`저장(Save / Ctrl + S)`** 버튼을 누르면 DBeaver가 자체적으로 단일 DDL로 안전하게 컴파일합니다.
  - **방법 2 (스크립트 창에서 전체 실행)**:
    - SQL 편집기에서 `Ctrl + Enter`(단일 문장 실행)를 누르지 말고, `Ctrl + A`로 전체 선택 후 반드시 **`Alt + X` (SQL 스크립트 실행)**를 실행해야 합니다.
  - **방법 3 (DELIMITER 명시)**:
    - SQL 편집기에서 스크립트로 직접 생성할 때는 최상단과 최하단에 `DELIMITER`를 명시하여 툴이 세미콜론 단위로 자르지 못하도록 방지합니다:
      ```sql
      DELIMITER $$
      DROP PROCEDURE IF EXISTS `MES_SNS2`.`EQM1001_R03` $$
      CREATE DEFINER=`root`@`%` 
      PROCEDURE `MES_SNS2`.`EQM1001_R03`(...)
      PROC: BEGIN
        ...
      END $$
      DELIMITER ;
      ```

### 0-3. [프로시저 최상단 선언부 서식 표준] CREATE DEFINER 및 PROCEDURE 2행 개행 선언 강제 (한 줄 선언 절대 금지)
- **배경 및 원칙**:
  - 프로시저 최상단 선언부는 `CREATE DEFINER=... PROCEDURE ...(...)`와 같이 한 줄로 붙여 쓰는 것을 절대 금지하며, 반드시 `CREATE DEFINER=`root`@`%``와 `PROCEDURE `MES_SNS2`.`프로시저명`(`을 **2행으로 분리 개행하여 작성**합니다.
  - 한 줄로 작성할 경우 DBeaver / HeidiSQL 등 DB 클라이언트 도구의 루틴 에디터 및 소스 비교 뷰에서 가독성을 심각하게 저해하고 프로젝트 코드 컨벤션과 불일치하므로 엄격히 배제합니다.
- **표준 서식 모범 예시**:
  ```sql
  -- [올바른 예 - 2행 분리 개행 (필수)]
  CREATE DEFINER=`root`@`%` 
  PROCEDURE `MES_SNS2`.`MST3001_R03`(
  -- *****************************************************************************
  -- Comment: 설비부품정보 마스터관리
  -- Create:  2024-02-22  13:50   김영철
  ...

  -- [잘못된 예 - 한 줄 선언 (절대 금지)]
  CREATE DEFINER=`root`@`%` PROCEDURE `MES_SNS2`.`MST3001_R03`(
  ```

### 1. SQL 가시성(가독성) 및 성능 최적화 원칙
- **가시성 및 직관적 구조 (누가 읽어도 이해하기 쉬운 코드)**:
  - 복잡하고 장황한 다중 중첩 `CASE WHEN`, 불필요한 문자열 자르기 및 중복 형변환을 지양하고, 가장 직관적이고 깔끔한 단일 문장이나 표준 내장 함수를 활용하여 간략하게 작성합니다.
  - 불필요하거나 중복된 연산, 가독성을 저해하는 잉여 로직은 적극적으로 정리 및 제거합니다.
- **성능 고려(Performance-First)**:
  - 단일 건 매칭 쿼리에는 `LIMIT 1`을 명시하여 불필요한 테이블 풀 스캔을 방지합니다.
  - 행(Row)마다 반복 호출되는 비효율적인 함수 호출이나 중복 연산을 최소화하여 실행 속도와 CPU 부하를 최적화합니다.

- **JOIN·테이블 구조 검토 필수**:
  - [SQL 구조 및 JOIN 최소화 규칙](sql_structure.md)을 적용하여 중복 참조·컬럼·연산을 제거합니다. JOIN을 여러 번 겹쳐 복잡하게 만들지 말고, 누구나 데이터 연결 흐름을 쉽게 읽을 수 있도록 간단하고 직관적으로 작성합니다.

### 1-1. 입력값 검증 및 조건문 중복 방지
- **조건 작성 전 실행 흐름 확인**: 앞선 공통 검증, `SET`·`SELECT INTO`에 의한 값 변경, `LEAVE`·`RETURN` 종료 여부를 확인하고 해당 조건에 도달할 때 가능한 값을 먼저 파악합니다.
- **같은 값·같은 조건은 한 번만 검증**: 앞에서 NULL·빈 값 등을 검사하고 오류 시 종료했다면, 값이 변경되지 않는 다음 분기에서 같은 검사를 반복하지 않습니다. 여러 분기에 공통인 검증은 실제로 필요한 분기 범위에 한 번만 배치합니다.
- **정규화 후 불가능한 조건 제거**: `CASE` 등으로 결과를 특정 값으로 제한했다면 항상 참·거짓이 되는 후속 조건을 추가하지 않습니다. 원래 입력의 유효성 검사가 필요하면 정규화 전에 수행하고, 기본값을 허용할지 먼저 결정합니다.
- **다른 검증과 구분**: 입력 형식, 대상 존재 여부, 승인 상태, 권한은 서로 다른 검증입니다. DB 값이 변경되거나 잠금 후 다시 확인해야 하는 경우에는 중복으로 단정하지 않고 재검증 목적을 확인합니다.
- **NULL 처리 확인**: `NOT IN`, `=`, `<>`는 NULL에서 참·거짓 대신 NULL이 될 수 있으므로, 조건을 줄일 때 NULL·빈 값·정상 값·잘못된 값의 처리 결과와 오류 메시지·종료 흐름을 확인합니다.
- **구체적인 적용 예**:
  - `SAVE_PLAN_STATUS`: 앞에서 `$PLANCD`의 NULL·빈 값을 검사하고 `LEAVE PROC` 했다면, 다음 IF에서는 `$PLANTP`만 검증합니다.
  - `CALL_PLAN_RPT`: `CASE WHEN $PLANTP = 'E' THEN 'E' ELSE 'G' END` 이후의 `NOT IN ('G', 'E')` 검사는 항상 거짓이므로 제외합니다. 원래 `$PLANTP`를 검증하려면 CASE 전에 검사합니다.
- **최종 검토 필수**: 수정한 조건뿐 아니라 앞뒤 공통 검증과 관련 분기를 함께 읽고, 중복 검사·도달할 수 없는 분기·검증 누락이 없는지 확인한 뒤 완료합니다.

### 2. 최상단 이력 주석(Comment / Modify) 필수 기재 (1일 1행 원칙 준수)
- SQL 파일을 수정한 후에는 프로시저 최상단 Comment 선언부 아래 `Modify` 영역에 날짜, 이름, 작업내용을 반드시 기재합니다 (`procedure_history.md` 준수).
- **1일 1행(하루 한 줄) 작성 원칙**:
  - 동일 일자에 여러 작업 및 수정을 진행하더라도 날짜(`YYYY-MM-DD`)별로 반드시 단 한 줄(1행)로 간결하게 통합 요약하여 작성합니다. 동일 날짜의 다중 행 나열을 금지합니다.
  ```sql
  -- Comment: 설비점검조회
  -- Create: 	2025-06-27  	생성 			이대규
  -- Modify: 	2026-09-15 		마이그레이션	한성수
  -- 			2026-09-16 					한성수	1일 1행으로 간결하게 통합된 작업내용
  ```

### 3. 코드 들여쓰기 및 열 정렬 표준화 (가독성 최적화 지침)
- **파라미터 및 변수 정렬**:
  - 입력 파라미터(`IN`) 및 변수 선언(`DECLARE`) 시 변수명, 데이터 타입, 주석이 일직선으로 정렬되도록 일관된 탭/공백 정렬을 적용합니다.
- **제어문 및 SQL 블록 들여쓰기 (계층 구조)**:
  - `PROC: BEGIN` 아래의 공통 검증 및 본문 블록은 기본 2스페이스 들여쓰기를 적용합니다.
  - `CASE $CALLTYPE`의 각 `WHEN ... THEN` 분기 선언은 2스페이스(`  WHEN ... THEN`), 분기 선언 바로 다음 줄에는 빈 줄 1행을 배치하여 시각적 구분을 명확히 합니다.
  - 분기 내부의 실행 코드(`IF`, `SET`, `SELECT` 등)는 4스페이스 들여쓰기(`    `)를 적용하며, 중첩 제어문 내부는 6스페이스 단위로 계층화합니다.
  - 논리적인 실행 단위(입력값 검증, 변수 초기화/전처리, 메인 DML 실행 등) 사이에는 빈 줄을 적절히 배치하여 가독성을 극대화합니다.
- **SELECT 절 및 INSERT 절 컬럼 열 정렬 (한 줄 다중 컬럼 가로 나열 표준)**:
  - 복수 컬럼 나열 시 다른 테이블을 복잡하게 참조하거나 장황한 별칭/가공식이 붙지 않는 이상, **한 줄에 1개 컬럼씩 무의미하게 수십 줄로 세로 나열하는 방식을 지양하고 연관된 컬럼 그룹 단위로 한 줄에 여러 개의 컬럼을 가로로 나열**합니다.
  - 연관된 식별키군, 명칭/규격군, 수량/단가/금액군, 주소/연락처군, 등록/수정 정보 등의 단위로 행을 묶어 가독성과 코드 압축성을 극대화합니다.
  - `INSERT INTO 테이블 (COL1, COL2, COL3, ...) VALUES (...)` 구문도 동일하게 한 행에 여러 컬럼씩 그룹화하여 작성합니다.
  - 다중 테이블 조인 시 각 테이블의 출처나 복잡한 가공식(`CASE WHEN`, 연산식 등)이 들어간 경우에 한해서만 시각적 구분을 위해 1행 1~2개 단위로 개행 정렬합니다.
- **SQL 주요 절(Clause) 및 JOIN/WHERE 정렬**:
  - `SELECT`, `FROM`, `INNER JOIN`, `LEFT JOIN`, `WHERE`, `GROUP BY`, `ORDER BY` 등의 주요 키워드는 동일한 들여쓰기 기준선(4스페이스)에 일직선으로 배치합니다.
  - `JOIN`의 `ON` 조건절은 JOIN 키워드보다 2스페이스 들여써서 6스페이스(`      ON ...`)로 배치하고, 조인 후속 `AND` 조건절은 `ON`의 시작 기준선에 맞추어 5~6스페이스(`     AND ...`)로 정렬합니다.
  - `WHERE` 절의 단일 조건은 6스페이스(`      AND 컬럼 = 값`)에 정렬하고, 복합 `OR` 조건(검색어 필터 등)은 괄호 안쪽과 `OR` 키워드가 수직으로 일치하도록 아래 패턴으로 정렬합니다:
    ```sql
          AND (   $KEYWORD = ''
               OR TABLE.COL1 LIKE CONCAT('%', $KEYWORD, '%')
               OR TABLE.COL2 LIKE CONCAT('%', $KEYWORD, '%')
              )
    ```
  - `UNION ALL` 구문은 위아래 빈 줄을 두고 주요 키워드와 동일한 들여쓰기로 배치합니다.
- **표준 서식 모범 예시 (`MST3001_R03` 기준)**:
  ```sql
  WHEN 'SEL_ITEM' THEN -- 설비부품 품목 마스터 및 재고·로케이션 조회 (화면 표시용 필수 컬럼 최적화)
    
    IF TRIM(COALESCE($COMPANYCD, '')) = '' THEN 
      CALL COMERR('법인을 선택하십시오.');
      LEAVE PROC;
    END IF; 

    SET $ITEMCG = 'DM100700';
    SET $ITEMID = TRIM(COALESCE($ITEMID, ''));

    SELECT CAST(MSTITEM.ITEMID AS CHAR) AS ITEMID,
           MSTITEM.ITEMCD,
           MSTITEM.COMPANYCD,
           MSTITEM.ITEMCG,
           MSTITEM.ITEMNM,
           MSTITEM.ITEMSPEC,
           MSTITEM.ITEM_LVL1,
           MSTITEM.ITEM_LVL2,
           MSTITEM.ITEM_LVL3,
           MSTITEM.ITEM_LVL4,
           MSTITEM.ITEMUNIT,
           MSTITEM.ITEMSRC,
           MSTITEM.ENDYN,
           MSTITEM.IOYN,
           MSTITEM.SEPAYN,
           COALESCE(MSTITEM_EQMPARTS.GRADE, MSTITEM.GRADE, '') AS GRADE,
           COALESCE(MSTITEM_EQMPARTS.SAFEQTY, 0) AS SAFEQTY,
           COALESCE(MSTITEM_EQMPARTS.LOTQTY, 0) AS LOTQTY,
           COALESCE(MSTITEM_EQMPARTS.LOCACD, '') AS LOCACD,
           COALESCE(MSTLOCA_EQMPARTS.LOCANM, '') AS LOCANM
    FROM MSTITEM
    LEFT JOIN MSTITEM_EQMPARTS
      ON MSTITEM_EQMPARTS.ITEMID = MSTITEM.ITEMID
     AND (COALESCE($FACTORYCD, '') = '' OR MSTITEM_EQMPARTS.FACTORYCD = $FACTORYCD)
    LEFT JOIN MSTLOCA_EQMPARTS
      ON MSTLOCA_EQMPARTS.LOCACD = MSTITEM_EQMPARTS.LOCACD
    WHERE MSTITEM.COMPANYCD = $COMPANYCD
      AND MSTITEM.ITEMCG = 'DM100700'
      AND MSTITEM.ENDYN = $ENDYN
      AND (   $ITEMID = ''
           OR MSTITEM.ITEMID LIKE CONCAT('%', $ITEMID, '%')
           OR MSTITEM.ITEMCD LIKE CONCAT('%', $ITEMID, '%')
           OR MSTITEM.ITEMNM LIKE CONCAT('%', $ITEMID, '%')
          )
    ORDER BY MSTITEM.COMPANYCD, MSTITEM.ITEMCD;
  ```

### 4. 표준 구분선(`-- *****************************************************************************`) 필수 선언
- 프로시저 파일에서 주요 블록 구분이 필요할 때는 반드시 프로젝트 표준 구분선인 `-- *****************************************************************************`를 선언하여 블록 간 가독성을 유지합니다.
- **주요 필수 선언 위치**:
  1. 최상단 Comment / Create / Modify 주석 블록 위와 아래
  2. 일반 파라미터 리스트와 시스템 파라미터(`$CALLTYPE`, `$KEYWORD`) 사이
  3. `PROC: BEGIN` 아래 및 `DECLARE` 변수 선언 시작 전
  4. `CASE $CALLTYPE`의 각 `WHEN ... THEN` 분기 사이 및 `END CASE;` 직전

### 5. 프로시저 내부 기능 주석 간소화 원칙 (SQL 전용: 날짜 표기 금지 및 직관적 기능명 기재)
- **[중요] SQL 소스 파일(`.sql`) 전용 규칙**:
  - 이 날짜 표기 금지 규칙은 **오직 데이터베이스 프로시저 및 SQL 파일(`.sql`) 내부 로직에만 한정**하여 적용됩니다.
  - 웹 화면 및 비즈니스 로직 소스 코드(`.aspx`, `.js`, `.cs`)는 기능 추가 및 변경 시 날짜 주석(`// YYYY-MM-DD ...`) 작성이 필수(`Optimization.md` 참조)이므로, 이 둘을 절대로 혼동하여 일반 소스 코드의 날짜 주석을 삭제해서는 안 됩니다.
- **SQL 내부 코드 라인에 날짜 표기 절대 금지**:
  - SQL 파일에서 수정 일자(`YYYY-MM-DD`) 및 작업자 정보는 반드시 프로시저 최상단의 `Modify` 이력 영역에만 기재합니다.
  - 프로시저 내부의 분기문(`WHEN '...' THEN`)이나 개별 쿼리/제어문 주석에는 `-- YYYY-MM-DD ...`와 같은 날짜를 절대 작성하지 않습니다. 내부 로직의 날짜 표기는 코드를 복잡하게 만듭니다.
- **간결하고 직관적인 기능 명칭 작성**:
  - `WHEN 'CALLTYPE' THEN` 분기 주석에는 화면의 탭 명칭, 특정 UI 컨트롤 번호(그리드 번호 등), 파라미터 조건 등 불필요하게 장황한 수식어를 배제하고, 해당 분기가 수행하는 핵심 기능을 간결하고 직관적으로 기재합니다.
  - **나쁜 예 (날짜 포함 및 과도하게 장황한 주석)**:
    ```sql
    -- [지양] 날짜 및 과도하게 장황한 화면/UI 설명 포함
    WHEN 'LIST_GRP_EQM02_ADD' THEN -- 2026-09-21 설비그룹 점검계획 탭: 선택 설비그룹에 미등록된 정기점검 항목 조회
    WHEN 'LIST_MSTEQM'        THEN -- 2026-09-16 좌측 설비목록 그리드(grid1) 조회 (MSTEQM.FANO 사용)
    ```
  - **좋은 예 (날짜 없이 직관적이고 간결한 주석)**:
    ```sql
    -- [권장] 날짜 없이 핵심 기능만 간결하게 명시
    WHEN 'LIST_GRP_EQM02_ADD' THEN -- 설비그룹 미등록 정기점검 항목 조회
    WHEN 'LIST_MSTEQM'        THEN -- 설비 목록 조회
    WHEN 'REG_GRP_EQM02'     THEN -- 설비그룹 정기점검 항목 등록
    WHEN 'SAVE_GRP_EQM02'    THEN -- 설비그룹 정기점검 항목 저장
    ```
- **과도한 장식용 배너/구분선 지양**:
  - `======`나 `------` 등 임의의 배너 주석을 남발하지 않으며, 구분이 필요한 경우 프로젝트 표준 구분선(`-- *****************************************************************************`)과 간결한 단일 행 주석만을 사용합니다.

### 6. 공통 감사(Audit) 함수 필수 사용 원칙 (`CALLTIME()`, `CALLEMP()`, `CALLPRG()`)
- **배경**:
  - 데이터베이스 등록/수정 시 시스템 기본 일시 함수(`NOW()`, `SYSDATE()`)나 세션 변수(`@CALLEMP`, `@CALLPRG`), 또는 로컬 변수(`_$NOW`)를 임의로 대입하는 방식을 엄격히 금지합니다.
  - 프로젝트 공통 내장 함수인 `CALLTIME()`, `CALLEMP()`, `CALLPRG()`를 호출하여 감사(Audit) 정보의 형식과 정합성을 보장합니다.
- **적용 표준**:
  - **신규 등록 (INSERT)**:
    - 등록 정보 컬럼: `RTIME = CALLTIME()`, `REMP = CALLEMP()`, `RPRG = CALLPRG()`
    - 수정 정보 컬럼(초기화): 관례에 따라 빈 문자열(`''`) 또는 `CALLTIME()`, `CALLEMP()`, `CALLPRG()`로 지정
  - **기존 수정 (UPDATE)**:
    - 수정 정보 컬럼: `MTIME = CALLTIME()`, `MEMP = CALLEMP()`, `MPRG = CALLPRG()`
  - **금지 패턴**:
    - `SET _$NOW = DATE_FORMAT(NOW(), ...);` 후 `_$NOW` 대입 (금지)
    - `MEMP = @CALLEMP`, `MPRG = @CALLPRG` 세션 변수 직접 참조 (금지 -> `CALLEMP()`, `CALLPRG()` 함수 호출 필수)



