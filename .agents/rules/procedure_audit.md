---
trigger: always_on
---

# Database Audit Function Rule (공통 감사 함수 필수 사용 원칙)

데이터베이스 프로시저 작성 시 등록/수정 일시 및 작업자 정보의 정합성을 보장하기 위해 다음 원칙을 절대적으로 준수합니다.

---

### 1. 공통 감사(Audit) 함수 필수 사용 원칙 (`CALLTIME()`, `CALLEMP()`, `CALLPRG()`)
- **배경**:
  - 데이터베이스 등록/수정 시 시스템 기본 일시 함수(`NOW()`, `SYSDATE()`)나 세션 변수(`@CALLEMP`, `@CALLPRG`), 또는 로컬 변수(`_$NOW`)를 임의로 대입하는 방식을 엄격히 금지합니다.
  - 프로젝트 공통 내장 함수인 `CALLTIME()`, `CALLEMP()`, `CALLPRG()`를 호출하여 감사(Audit) 정보의 형식과 정합성을 보장합니다.

---

### 2. DML 적용 표준
- **신규 등록 (INSERT)**:
  - 등록 정보 컬럼: `RTIME = CALLTIME()`, `REMP = CALLEMP()`, `RPRG = CALLPRG()`
  - 수정 정보 컬럼(초기화): 관례에 따라 빈 문자열(`''`) 또는 `CALLTIME()`, `CALLEMP()`, `CALLPRG()`로 지정
- **기존 수정 (UPDATE)**:
  - 수정 정보 컬럼: `MTIME = CALLTIME()`, `MEMP = CALLEMP()`, `MPRG = CALLPRG()`

---

### 3. 절대 금지 패턴 (DO NOT USE)
- `SET _$NOW = DATE_FORMAT(NOW(), ...);` 후 `_$NOW` 대입 (금지)
- `NOW()`, `SYSDATE()` 직접 대입 (금지)
- `MEMP = @CALLEMP`, `MPRG = @CALLPRG` 세션 변수 직접 참조 (금지 ➔ `CALLEMP()`, `CALLPRG()` 함수 호출 필수)
