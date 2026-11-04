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
  - **3개 파일의 구체적인 작성 구조·순서·명명·기본 스타일은 [report_file_structure.md](report_file_structure.md)를 반드시 따릅니다.**

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

#### 2-4. 컨트롤을 담는 `XRPanel` 사용 금지 (`component` null 오류 방지)
- **오류 배경 (규칙 최초 작성 프로젝트의 `EQM1001_S01A` 사례, VS 2017 + DevExpress 16.1에서 확인)**:
  - S01A 설비이력카드는 상단 로고·제목을 `XRPanel`(`xrPanelHeader`) 안에 넣고 `xrPanelHeader.Controls.AddRange(...)`로 배치했습니다. 빌드·런타임은 정상이었지만 VS 디자이너에서 `값은 null일 수 없습니다. 매개 변수 이름: component` 오류가 발생했습니다.
  - 호출 스택: `DesignerHost.GetDesigner(IComponent)` ← `VSLockService.CanChangeComponent` ← `XRControlDesignerBase.get_Locked` ← `XRControlDesigner.OnLoadComplete`. 로드 완료 시점에 컨트롤이 없어진(null) 디자이너가 잠금 여부를 확인하다 오류가 납니다.
  - 같은 파일에서 패널만 제거하자 VS 디자이너가 정상으로 열렸습니다. 패널이 없는 같은 프로젝트의 다른 레포트(`R03`)도 정상이었습니다.
- **원칙**:
  - 다른 컨트롤을 자식으로 담는 `XRPanel`을 사용하지 않습니다. 모든 컨트롤은 밴드(`PageHeader`, `Detail` 등)의 `Controls.AddRange`에 직접 넣습니다.
  - 테두리 박스가 필요하면 내용 없는 `XRLabel`(`Borders = All`)을 같은 위치·크기로 두고, 안에 들어갈 컨트롤은 밴드에 같은 좌표로 그 뒤에 추가합니다 (먼저 추가한 컨트롤이 아래에 그려짐).
  - 예: `xrLabelHeaderBox` (0, 0, 731×56) → `xrPictureBoxLogo` (12, 6) → `xrLabelTitle` (165, 8) 순서로 `PageHeader.Controls.AddRange`
- **빌드 성공 ≠ 디자이너 호환**: MSBuild 성공과 exe 출력 정상은 디자이너에서 열린다는 보장이 아닙니다. 레포트를 만들거나 구조를 바꾼 뒤에는 VS에서 `{리포트ID}.cs`를 디자이너로 열어 확인합니다.

#### 2-5. 디자이너 오류 진단 절차 (추측 수정 금지)
VS 디자이너에서 오류 페이지("디자이너를 로드하기 전에 ... 오류를 해결해야 합니다")가 나오면 **아래 순서를 건너뛰지 않고** 진행합니다.
S01A 사례에서 호출 스택을 보지 않고 `RowSpan`을 원인으로 추측해 수정·규칙화했다가 오류가 그대로 남은 실패가 있었습니다. 같은 실수를 반복하지 않습니다.

1. **런타임과 디자이너 문제 구분**
   - 웹 컨트롤러와 같은 방식으로 exe를 실행합니다: `{REPORT_BIN}/{화면ID}.exe {리포트ID} test "KEY»값┃" pdf` (`{REPORT_BIN}` 예: `01.Office/Reports/`, 인자 형식은 현재 프로젝트의 레포트 컨트롤러가 exe에 넘기는 형식을 따름)
   - exe가 정상이면 디자이너 전용 문제입니다. 이때 빌드 성공·PDF 정상은 해결 근거가 되지 않습니다.
2. **호출 스택 먼저 확보 (필수)**
   - 오류 페이지의 `호출 스택 표시`를 열어 맨 위 몇 줄(오류를 던진 메서드와 그 호출자)을 기록합니다. 사용자에게 요청하거나 VS 화면에서 직접 확인합니다.
   - 호출 스택 없이 원인을 단정하거나, 그 추측으로 코드·규칙을 수정하지 않습니다.
3. **정상 레포트와 비교**
   - 같은 프로젝트에서 디자이너가 정상으로 열리는 기준 레포트([project_context.md](project_context.md))와 비교해, 문제 레포트에만 있는 요소(컨트롤 종류, 밴드, 중첩, 특수 속성)를 목록으로 만듭니다.
4. **소거법으로 원인 확정**
   - 원본 `Designer.cs`를 백업한 뒤, 의심 요소를 **하나씩** 제거한 테스트 변형을 만들어 VS에서 디자이너 탭을 닫았다가 다시 엽니다.
   - "제거하면 열리고, 있으면 오류"가 확인된 요소만 원인으로 인정합니다. 확인되지 않은 가설은 원인으로 기록하지 않습니다.
5. **허용된 패턴으로 수정**
   - 원인 요소를 이 문서의 허용 패턴으로 바꿉니다 (예: `XRPanel` → 빈 테두리 `XRLabel`). 출력 모양이 바뀌면 안 되므로 좌표·크기를 그대로 유지합니다.
6. **3중 검증 후 완료 보고**
   - ① VS 디자이너에서 오류 페이지 없이 레이아웃이 표시됨 ② exe 실행·오류 안내 메시지 정상 ③ 수정 전후 출력 비교(같은 데이터로 PDF/이미지 비교)
   - ①을 직접 확인하지 못했다면 "디자이너 미확인"이라고 명시하고, 해결됐다고 말하지 않습니다.
7. **규칙·이력 반영**
   - 확정된 원인만 아래 "알려진 원인" 표와 금지 규칙에 추가합니다.
   - 잘못 짚은 진단이 있었다면 `WORK_HISTORY.md`에 그대로 정정 표시합니다.

**알려진 원인 (VS 2017 + DevExpress 16.1 환경에서 실사례로 확인된 것만)**

버전이 다른 환경에서도 우선 이 표로 의심하되, 2-5 절차(호출 스택·소거법)로 같은 원인인지 확인한 뒤 적용합니다. 새 원인을 확인하면 확인한 환경(VS·DevExpress 버전)과 함께 이 표에 추가합니다.

| 오류 메시지 / 증상 | 원인 | 해결 |
|---|---|---|
| `값은 null일 수 없습니다. 매개 변수 이름: component` (스택: `XRControlDesigner.OnLoadComplete` → `VSLockService`) | 자식 컨트롤을 담는 `XRPanel` | 2-4: 빈 테두리 `XRLabel` + 밴드 직접 배치 |
| `'XtraReport.CreateCatCell' 메서드를 찾을 수 없습니다` | `InitializeComponent()` 안의 사용자 헬퍼 호출 | 2-3: 순수 대입문으로 전개 |
| `TargetException: 개체가 대상 형식과 일치하지 않습니다` | `XRTableRow`를 `BeginInit/EndInit`에 포함 | 2-3: `XRTable`·`this`만 포함 |

---

### 3. 데이터베이스 연결 및 조회 표준 (`CreateMaria` 하드코딩 절대 금지)
- **원칙**:
  - 리포트 C# 비하인드 코드 내에 `DbServer`, `DbPort`, `DbUser`, `DbPass`, `DbName`을 하드코딩하거나, 별도의 `CreateMaria` 헬퍼 메서드를 임의로 정의하는 행위를 **절대 금지**합니다.
  - 리포트 실행 바이너리가 위치한 폴더(`{REPORT_BIN}`, 예: `01.Office/Reports/`, `04.Report/bin/`)에 이미 `ITS_CONFIG_MARIA.xml` 설정 파일이 존재하므로, `ItsMaria`는 자동으로 해당 접속 정보를 읽어옵니다.
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
- 리포트 소스 수정 후에는 반드시 프로젝트의 Visual Studio 버전에 맞는 **MSBuild로 Rebuild**(VS 2017이면 MSBuild 15.0)를 실행하여 컴파일 오류(0 Error, 0 Warning)가 없음을 검증합니다.
- 빌드된 최신 실행파일(`bin/Release/[프로젝트명].exe`)은 웹 실행 경로인 `{REPORT_BIN}`(예: `01.Office/Reports/`, `04.Report/bin/`)에 즉시 복사 배포하여 현업 및 브라우저에서 최신 버전이 실행되도록 동기화합니다.
