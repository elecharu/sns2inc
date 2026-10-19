---
trigger: always_on
---

# Framework Convention & Reference-First Rule (공통 프레임워크 우선 활용 및 기존 화면 참조 규칙)

신규 기능 개발 및 레포트 구현 시 코드 일관성, 유지보수성을 극대화하고 중복 구현 및 잉여 코드를 방지하기 위해 다음 원칙을 반드시 준수합니다.

### 1. 공통 프레임워크 및 컴포넌트 함수 최우선 적극 활용 원칙 (Framework-First & Common Utility Usage)
- **공통 컴포넌트/함수 지원 여부 선행 확인 및 적극 활용**:
  - 화면 UI(`.aspx`), 클라이언트 스크립트(`.js`), 백엔드 C#(`.cs`), 리포트(`04.Report`) 등 모든 영역에서 기능 구현 착수 전, 해당 기능이 프로젝트 공통 프레임워크 및 공통 라이브러리(`ItsCommon`, `ItsLibRpt`, `ItsMaria`, `ItsSecurity`, `ItsXtraRpt`, `ItsGrid`, `ItsFind`, `ItsPop`, `ItsCombo`, `ItsMsg` 등)에 이미 존재하는지 반드시 먼저 확인하고, 존재하는 경우 이를 적극적으로 활용하여 구현합니다.
- **인위적인 중복 재구현 및 자체 헬퍼 남발 금지**:
  - 공통 프레임워크나 라이브러리가 이미 기본으로 제공하는 동작 및 유틸리티(예: DB 프로시저 호출, 리포트 자동 고유 타임스탬프 파일명 발급, 모달 자동 중앙 정렬, 공통 유효성 검증, 암복호화 등)를 화면이나 비하인드 코드에서 불필요하게 자체 함수나 헬퍼로 중복 재구현하거나 하드코딩하지 않습니다.
  - 공통 라이브러리에 없는 개별 업무 화면/리포트 고유의 특수 로직에 한해서만 최소한의 내부 메서드로 간결하고 안전하게 구현합니다.

### 2. 기존 정상 동작 유사 화면 참조 원칙 (Reference-First)
- **유사 화면 패턴 모방 의무화**: 신규 화면이나 레포트 개발 시 독자적인 방식을 도입하지 말고, 현재 프로젝트 내에 이미 안정적으로 구현되어 동작하고 있는 다른 업무 화면의 소스코드를 검색하여 동일한 형태로 제작합니다.
- **표준 패턴 일관성 유지**: 화면 레이아웃(`.aspx`), 스크립트 이벤트 및 호출 구조(`.js`), 비하인드 로직(`.cs`), 프로시저(`.sql`)까지 기존 프로젝트 표준 관례를 철저히 따라 이질감 없는 코드를 유지합니다.

### 3. 레포트(ItsXtraRpt) 표준 연동 및 작성 규칙
- **간결한 표준 인스턴스 호출**: `new ItsXtraRpt('리포트명')` 인스턴스 생성 후 `AddParam`으로 필요한 조건값만 전달하고 `CallPop()` 또는 `Call()`로 호출하는 간결한 표준 패턴을 준수합니다.
- **임의 파일명 지정(`rpt.FileName`) 금지**: 공통 컨트롤러가 파일명 미지정 시 고유 타임스탬프(`DateTime.Now.Ticks`) 파일명을 자동 부여하므로, 화면 스크립트에서 인위적으로 파일명을 조합하여 지정하지 않습니다.
- **기존 리포트 C# 소스 모방**: 신규 리포트 C# 비하인드(`04.Report/.../S05A.cs`) 구현 시에도 프로젝트 내 기존 검증된 리포트(`SAL0001_S05.cs`, `EQM1001_S01.cs` 등)의 데이터 수신 및 바인딩 구조를 그대로 준용합니다.
- **DevExpress 디자이너 표준 구조 준수 (`report_devexpress.md` 필수 준수)**: C# 비하인드 코드 동적 생성(`BuildReport`)을 금지하고 `Designer.cs` 기반의 표준 디자이너 3개 파일 세트(`cs`, `Designer.cs`, `resx`), 매개변수 없는 기본 생성자 필수 선언, `components` 초기화, `ItsMaria` 표준 호출(`CreateMaria` 하드코딩 금지) 규칙을 반드시 준수합니다.

### 4. 레포트 임시 파일 형상 관리 격리
- 리포트 출력 테스트 중 로컬 임시 폴더(`01.Office/Reports/tempFiles/`, `04.Report/bin/tempFiles/` 등)에 자동 생성되는 임시 산출물(`*.pdf`, `*.html`, `*_files/` 등)은 `.gitignore`를 통해 형상 관리에서 철저히 격리하며 Git 저장소에 커밋하지 않습니다.

### 5. 공통코드(GPCD) 그룹 분리 및 콤보박스(ItsCombo) 표준 연동 규칙
- **C# 비하인드 코드 내 DataView 필터링 / LIKE 문 사용 전면 금지**:
  - `cmb_INTP.ItemsSource = new DataView(cmb_INTP.ModelCombo, "Value LIKE 'IN_%'", ...)`와 같이 C# 비하인드 코드에서 인위적으로 `LIKE` 조건이나 `DataView`를 조작하여 콤보박스 아이템을 거르는 비표준 임시방편 코드를 일체 작성하지 않습니다.
- **[정석 방식 1] 성격별 그룹코드(GPCD) 완전 분리 준수 (MES 전체 99% 사용)**:
  - 입고구분과 출고구분, 또는 업무별/단계별 구분과 같이 성격이 다른 코드들은 하나의 그룹코드에 섞어 넣지 않고, 처음부터 별개의 공통코드 그룹(`GPCD`)으로 완전히 분리하여 설계 및 등록합니다.
    - 입고용: `GPCD = 'INTP_...'` (하위코드: 구매입고 등)
    - 출고용: `GPCD = 'OUTTP_...'` (하위코드: 부품교체 등)
- **XAML / 스크립트 마크업만으로 100% 자동 바인딩**:
  - C# 비하인드 코드(`.cs`)에서 단 한 줄의 수동 조작 코드 없이, 오직 XAML 태그(`GPCD="..."`) 또는 자바스크립트 프레임워크 함수 선언만으로 프레임워크(`ItsCombo.xaml.cs` 및 `DC_COMBO`)가 자동 바인딩하도록 구현합니다.
    ```xml
    <!-- [올바른 예 - C# 조작 없이 XAML 태그만으로 완벽 바인딩] -->
    <its:Combo GPCD="INTP_EQMPARTS" Value="{Binding INTP}" />
    <its:Combo GPCD="OUTTP_EQMPARTS" Value="{Binding OUTTP}" />
    ```
- **공통 컴포넌트(`ItsCombo`, `ItsFind`, `ItsPop`, `ItsGrid` 등) 기본 함수 최우선 활용**:
  - 공통 프레임워크가 기본 제공하는 프로퍼티와 생명주기 자동 바인딩 기능을 최우선으로 활용하며, 비표준 필터링이나 자체 꼼수 구현을 철저히 배제합니다.

### 6. 그리드 공통코드 콤보 컬럼 표준 연동 규칙 (ItsGrid 콤보 자동 바인딩 최우선 활용)
- **코드 hidden 및 명칭 텍스트 컬럼 분리 선언 절대 금지**:
  - 화면 그리드에서 공통코드(GPCD)에 해당하는 명칭을 표시할 때, **프로시저에서 `COMTYPE`을 조인하여 명칭 컬럼(`...NM`)을 별도로 반환받고 자바스크립트에서 코드 컬럼은 `hidden: true`로 숨긴 채 명칭 컬럼만 텍스트로 표시하는 비효율적이고 비표준적인 방식을 절대 작성하지 않습니다.**
- **공통 컴포넌트(`enumColumnTypes.combo`) 표준 바인딩 의무화**:
  - 그리드 컬럼 정의 시 공통 프레임워크가 제공하는 **`columnType: enumColumnTypes.combo, gpcd: '그룹코드'`** 속성을 선언하여, 프레임워크가 내부적으로 `DC_COMBO`를 통해 코드(`TPCD`)에 맞는 명칭(`TPNM`)을 그리드 셀에 100% 자동 매핑하도록 구현합니다.
- **비교 예시**:
  ```javascript
  // [올바른 예 - 공통 컴포넌트 ItsGrid combo 바인딩 적극 활용 (표준)]
  column.create("설비대분류", "EQMGROUP1", { width: 104, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', allowMerging: true }),
  column.create("설비그룹",   "EQMGUBUN",  { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM116', allowMerging: true }),

  // [잘못된 예 - 코드 hidden 처리 및 명칭 텍스트 컬럼 분리 선언 (절대 금지)]
  column.create("설비그룹코드",   "EQMGUBUN",  { hidden: true }),
  column.create("설비그룹코드명", "EQMGRPNM",  { width: 100, align: 'center' }),
  ```
- **프로시저 쿼리 단순화 연계**:
  - 화면 그리드에서 `enumColumnTypes.combo`로 자동 매핑되므로, 프로시저 SELECT 절에서도 불필요하게 `COMTYPE`을 중복 조인하여 명칭을 가져오는 잉여 로직을 제거하고 원본 식별코드만 간결하게 반환합니다.
