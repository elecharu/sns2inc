---
trigger: always_on
---

# DevExpress XtraReport Designer Standard Development Rule (DevExpress 레포트 디자이너 표준 개발 규칙)

신규 리포트 제작 및 기존 리포트 유지보수 시, Visual Studio의 DevExpress Report Designer 환경과 완벽히 호환되고 런타임 오류가 발생하지 않도록 다음 원칙을 반드시 준수합니다.

---

### 1. C# 런타임 동적 생성 방식(`BuildReport`) 전면 금지 및 디자이너 표준 구조 준수
- **원칙**:
  - 리포트 화면 UI를 C# 비하인드 코드에서 동적으로 컨트롤(`XRTable`, `XRTableRow`, `XRTableCell` 등)을 생성하여 조립하는 방식(`BuildReport`)을 **절대 사용하지 않습니다.**
  - 모든 리포트는 Visual Studio의 DevExpress Report Designer에서 시각적으로 열고 편집할 수 있도록 **3개 파일 세트(`[리포트명].cs`, `[리포트명].Designer.cs`, `[리포트명].resx`) 표준 구조**로 제작합니다.
  - 디자이너 파일(`Designer.cs`)의 `InitializeComponent()` 내부에 모든 밴드(`Detail`, `PageHeader`, `PageFooter`, `TopMargin`, `BottomMargin` 등)와 컨트롤의 좌표, 크기, 스타일, 테이블 레이아웃이 표준 CodeDOM 형태로 선언되어야 합니다.

---

### 2. Visual Studio DevExpress Report Designer 오류 방지 3대 핵심 규칙
Visual Studio에서 리포트를 열 때 발생하는 디자이너 크래시 및 파싱 오류를 방지하기 위해 다음 원칙을 반드시 지킵니다:

#### 2-1. 매개변수 없는 기본 생성자 필수 선언 (`ArgumentNullException` 방지)
- **오류 배경**: 기본 생성자가 없거나 파라미터 생성자만 존재할 경우, Visual Studio 디자이너 호스트(`IDesignerHost.CreateComponent`)가 컴포넌트 인스턴스를 생성하지 못해 `ArgumentNullException: component null` 오류가 발생하고 디자이너 로딩이 영구 차단됩니다.
- **필수 구현**:
  ```csharp
  // 1. 디자이너 전용 매개변수 없는 기본 생성자 (필수)
  public R03()
  {
      InitializeComponent();
  }

  // 2. 런타임 파라미터 수신 생성자는 반드시 : this()로 기본 생성자 체이닝
  public R03(Dictionary<string, string> param) : this()
  {
      // 데이터 조회 및 바인딩 로직
  }
  ```

#### 2-2. `components` 컨테이너 선언 및 초기화 누락 금지
- `[리포트명].Designer.cs` 필드 선언부에 `private System.ComponentModel.IContainer components = null;`을 선언하고,
- `InitializeComponent()` 최상단 첫 줄에 반드시 `this.components = new System.ComponentModel.Container();`를 작성해야 합니다.

#### 2-3. `InitializeComponent()` 내 사용자 정의 헬퍼 호출 및 잘못된 `BeginInit` 금지
- **사용자 정의 헬퍼 메서드 호출 금지**:
  - `InitializeComponent()` 내부에서 `CreateCatCell(...)`, `SetTableCell(...)` 등 개발자가 만든 임의의 메서드를 호출하면 CodeDOM 직렬화/역직렬화 엔진이 이를 인식하지 못해 `"'XtraReport.CreateCatCell' 메서드를 찾을 수 없습니다"` 오류가 발생합니다.
  - 모든 컨트롤 프로퍼티는 순수 대입문(`this.cell.Text = "..."`) 형태로만 구성해야 합니다.
- **`XRTableRow`의 `ISupportInitialize` 미지원**:
  - `XRTableRow`는 `ISupportInitialize` 인터페이스를 구현하지 않으므로, `((System.ComponentModel.ISupportInitialize)(this.row)).BeginInit()` / `EndInit()`에 포함하면 `TargetException: 개체가 대상 형식과 일치하지 않습니다` 런타임 리플렉션 오류가 발생합니다.
  - `BeginInit()` / `EndInit()` 대상은 `XRTable`, `XtraReport(this)`, `ObjectDataSource` 등 실제로 인터페이스를 지원하는 컴포넌트만 지정해야 합니다.

---

### 3. 데이터베이스 연결 및 조회 표준 (`CreateMaria` 하드코딩 절대 금지)
- **원칙**:
  - 리포트 C# 비하인드 코드 내에 `DbServer`, `DbPort`, `DbUser`, `DbPass`, `DbName`을 하드코딩하거나, 별도의 `CreateMaria` 헬퍼 메서드를 임의로 정의하는 행위를 **절대 금지**합니다.
  - 리포트 실행 바이너리가 위치한 폴더(`01.Office/Reports/`, `04.Report/bin/`)에 이미 `ITS_CONFIG_MARIA.xml` 설정 파일이 존재하므로, `ItsMaria`는 자동으로 해당 접속 정보를 읽어옵니다.
- **표준 호출 패턴**:
  ```csharp
  // [올바른 예 - 표준 ItsMaria 인스턴스화 (간결하고 완전한 형태)]
  ItsMaria maria = new ItsMaria("프로시저명", "CALLTYPE");
  maria.AddParam("KEY", param["KEY"]);
  DataSet ds = maria.CallProc();
  if (maria.IsError)
  {
      throw new InvalidOperationException(maria.ErrMessage);
  }
  ```

---

### 4. 공통 컴포넌트 및 라이브러리 함수 최우선 적극 활용 원칙 (Framework-First)
- **공통 컴포넌트 선행 확인 및 적극 활용**:
  - 리포트 구현 시 프로젝트 공통 라이브러리(`ItsLibRpt`, `ItsMaria`, `ItsSecurity`, `ItsXtraRpt` 등)에 이미 지원되는 공통 컴포넌트 및 함수가 있는지 반드시 선행 확인하고, 이를 최우선으로 적극 활용합니다.
  - **데이터베이스 프로시저 호출**: `ItsLibRpt.ItsMaria` 공통 인스턴스(`AddParam`, `CallProc`)를 활용하여 DB 접근 표준화.
  - **암복호화 처리**: `ItsLibRpt.ItsSecurity` (`EncDES`, `DecDES`) 공통 함수 적극 활용.
  - **클라이언트 리포트 호출**: 화면 스크립트(`.js`)에서 `new ItsXtraRpt('리포트명')` 공통 인스턴스를 통해 호출.
- **인위적인 중복 구현 금지 및 헬퍼 최소화**:
  - 공통 컴포넌트나 DevExpress 엔진이 이미 지원하는 기능(DB 연결, 자동 파일명 발급, 데이터 바인딩 등)을 개별 리포트 비하인드에서 불필요하게 자체 중복 구현하지 않습니다.
  - 공통 라이브러리에 없는 리포트 양식 고유의 기능(예: 특정 A4 인쇄 규격 유지를 위한 빈 행 채우기 `AddBlankRows`, DBNull 방어용 안전 값 취득 등)에 한해서만 최소한의 내부 `private static` 메서드로 간결하게 정의하여 사용합니다.

---

### 5. 데이터 바인딩 및 모델 선언 표준
- **스프레드시트/테이블 데이터소스 바인딩**:
  - 리포트 메인 데이터는 `this.DataSource = ds.Tables[1];`과 같이 바인딩하고, 셀 데이터 바인딩은 `XRTableCell.DataBindings.AddRange(...)`을 통해 매핑합니다.
- **`MODEL_S1` 내부 모델 클래스 선언**:
  - 리포트 클래스 하단에 `public class MODEL_S1 { ... }` (또는 `MODEL_R1`)을 정의하여 DevExpress Report Designer의 필드 바인딩 목록(`ObjectDataSource`)과 동기화할 수 있도록 표준을 유지합니다.
- **호환 파생 클래스 선언**:
  - 이전 버전 화면이나 공통 컨트롤러에서 `R03A` 등 끝에 영문자가 붙은 클래스명으로 호출하던 하위 호환성을 위해 필요 시 `public class R03A : R03 { public R03A(Dictionary<string, string> param) : base(param) { } }`를 함께 배치합니다.

---

### 6. 빌드 및 배포 무결성 검증
- 리포트 소스 수정 후에는 반드시 **MSBuild 15.0 Rebuild**를 실행하여 컴파일 오류(0 Error, 0 Warning)가 없음을 검증합니다.
- 빌드된 최신 실행파일(`bin/Release/[프로젝트명].exe`)은 웹 실행 경로인 `01.Office/Reports/` 및 `04.Report/bin/`에 즉시 복사 배포하여 현업 및 브라우저에서 최신 버전이 실행되도록 동기화합니다.
