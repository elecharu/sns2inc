---
trigger: always_on
---

# 레포트 파일 생성 표준 구조 규칙 (DevExpress XtraReport 3개 파일 템플릿)

모든 DevExpress XtraReport 레포트 파일은 **신규 생성·전면 재작성·구조 변경 시 예외 없이** 아래 표준 구조로 작성합니다.
이 문서만으로 작성할 수 있도록 템플릿 전체를 담았습니다. 현재 프로젝트에 이 구조로 작성되어 VS 디자이너에서 정상으로 열리는 레포트(기준 레포트, [project_context.md](project_context.md))가 있으면 함께 열어 프로젝트 관례(밴드 구성, 폰트, 여백)를 맞춥니다.
예시 코드의 `EQM1001`, `R03`, `PLANCD` 등은 이 규칙을 처음 만든 프로젝트의 실제 레포트(설비점검계획서)를 축약한 **사례 값**이므로, 현재 작업의 화면ID·리포트ID·파라미터로 바꿔 작성합니다.
디자이너 오류 방지·DB 호출 원칙은 [report_devexpress.md](report_devexpress.md)를 함께 준수합니다.

---

### 1. 폴더·파일 구성

```
{REPORT_ROOT}/PAGE{모듈}/{화면ID}/
├─ {화면ID}.sln / {화면ID}.csproj / App.config / Program.cs   (화면ID 프로젝트 공통, 1회 생성)
├─ {리포트ID}.cs              ← 생성자·데이터 조회·바인딩 로직
├─ {리포트ID}.Designer.cs     ← InitializeComponent() 레이아웃 전부
└─ {리포트ID}.resx            ← 표준 빈 리소스 파일
```

- `{REPORT_ROOT}` 판별은 [project_context.md](project_context.md)를 따릅니다 (예: `04.Report/`). 모듈 폴더명(`PAGE{모듈}`)도 현재 프로젝트의 기존 레포트 폴더 구성을 확인해 맞춥니다.
- **예**: `04.Report/PAGEEQM/EQM1001/R03.cs` (모듈 `EQM`, 화면ID `EQM1001`, 리포트ID `R03`)
- 리포트ID = 파일명 = 클래스명 (`R03`, `S01A` 등). 화면에서 `new ItsXtraRpt('{화면ID}_{리포트ID}')`로 호출하면 웹 컨트롤러가 `{화면ID}.exe {리포트ID} ...`로 실행하고, `Program.cs`가 `"XtraRpt." + 리포트ID` 클래스를 리플렉션으로 생성하므로 세 가지가 반드시 일치해야 합니다. 현재 프로젝트의 `Program.cs`·컨트롤러가 다르게 동작하면 그 방식을 따릅니다.
- **3개 파일 세트 중 하나라도 빠지면 안 됩니다.** (`.resx`는 디자이너가 리소스를 저장하는 파일)
- 인코딩: 3개 파일 모두 **UTF-8 with BOM(단일) + CRLF** ([encoding.md](encoding.md)).

#### 1-1. `.csproj` 등록 (3개 항목 필수)
```xml
<Compile Include="{리포트ID}.cs">
  <SubType>Component</SubType>
</Compile>
<Compile Include="{리포트ID}.Designer.cs">
  <DependentUpon>{리포트ID}.cs</DependentUpon>
</Compile>
...
<EmbeddedResource Include="{리포트ID}.resx">
  <DependentUpon>{리포트ID}.cs</DependentUpon>
</EmbeddedResource>
```

---

### 2. `{리포트ID}.cs` 표준 구조

작성 순서는 아래 블록 순서를 그대로 유지합니다.

```csharp
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using System.Data;
using System.Collections.Generic;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class R03 : DevExpress.XtraReports.UI.XtraReport
    {
        // YYYY-MM-DD [리포트명] Visual Studio Report Designer 호환을 위한 기본 생성자
        public R03()
        {
            InitializeComponent();
        }

        // YYYY-MM-DD [리포트명] R03 파라미터 수신 및 데이터 조회 바인딩
        public R03(Dictionary<string, string> param) : this()
        {
            // ① 파라미터 수신: ContainsKey 방어 + 기본값
            string planCode = param.ContainsKey("PLANCD") ? param["PLANCD"] : "";
            if (string.IsNullOrEmpty(planCode))
            {
                throw new InvalidOperationException("설비그룹을 선택해주세요.");
            }

            // ② 프로시저 호출: ItsMaria("{화면ID}_{리포트ID}", "CALL_...") — DB 접속정보 하드코딩 금지
            ItsMaria maria = new ItsMaria("EQM1001_R03", "CALL_PLAN_RPT");
            maria.AddParam("PLANCD", planCode);
            DataSet dataSet = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            // ③ 결과 검증: 데이터 없으면 빈 PDF 대신 안내 메시지
            if (dataSet == null || dataSet.Tables.Count < 2 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 정기점검 계획이 없습니다.");
            }

            // ④ 결과셋 분리: Tables[0]=헤더(1행), Tables[1]=상세, Tables[2..]=부가(선택)
            DataRow planHeader = dataSet.Tables[0].Rows[0];
            DataTable planItems = dataSet.Tables[1].Copy();
            DataTable revHistory = dataSet.Tables.Count > 2 ? dataSet.Tables[2] : null;
            AddBlankRows(planItems, 12);   // 양식 고정 행수가 필요한 경우만

            // ⑤ 바인딩 메서드 호출
            BindReportData(planHeader, planItems, revHistory);
        }

        // YYYY-MM-DD [리포트명] 상단 마스터 정보 및 상세 바인딩
        private void BindReportData(DataRow planHeader, DataTable planItems, DataTable revHistory)
        {
            cell_Val_EQMNM.Text = Value(planHeader, "EQMNM");   // 헤더 단건 값: .Text 직접 대입
            this.DataSource = planItems;                       // 상세 반복 데이터: DataSource
            BindRevHistory(revHistory);                        // 부가 영역은 별도 private 메서드
        }

        private static string Value(DataRow row, string fieldName)
        {
            return row.Table.Columns.Contains(fieldName) && row[fieldName] != DBNull.Value ? row[fieldName].ToString() : "";
        }

        private static void AddBlankRows(DataTable table, int minimumRows) { ... }

        public class MODEL_S1
        {
        }
    }

    // R03A 호출 호환용 파생 클래스
    public class R03A : R03
    {
        public R03A(Dictionary<string, string> param) : base(param) { }
    }
}
```

#### 2-1. 필수 규칙
| 항목 | 규칙 |
|---|---|
| namespace | 항상 `XtraRpt` |
| 클래스 선언 | `public partial class {리포트ID} : DevExpress.XtraReports.UI.XtraReport` |
| 기본 생성자 | 매개변수 없는 `public {리포트ID}() { InitializeComponent(); }` **필수** (디자이너 로딩용) |
| 파라미터 생성자 | `public {리포트ID}(Dictionary<string, string> param) : this()` — `InitializeComponent()`를 다시 호출하지 않음 |
| 파라미터 수신 | `param.ContainsKey("KEY") ? param["KEY"] : ""` 형태로 방어, 필수값 누락 시 `InvalidOperationException` |
| 프로시저 호출 | `new ItsMaria("{화면ID}_{리포트ID}", "CALL_...")` → `AddParam` → `CallProc()` → `IsError` 검사. `DbServer/DbPort/DbUser/DbPass/DbName` 대입 금지 |
| 오류 처리 | 모든 사용자 안내는 `throw new InvalidOperationException("한글 메시지")` (Program.cs가 `ERROR:` 로 화면에 전달) |
| 결과셋 | `Tables[0]` 헤더 1행, `Tables[1]` 상세 목록, `Tables[2]` 이후 부가 정보(선택, `Count` 확인 후 사용) |
| 헤더 바인딩 | `.cs`에서 `cell_Val_{필드}.Text = Value(row, "{필드}")` |
| 상세 바인딩 | `.cs`에서는 `this.DataSource = DataTable;`만, 필드 매핑은 **Designer.cs의 `DataBindings`** 에서 |
| 바인딩 분리 | 생성자 본문은 조회·검증까지만, 컨트롤 대입은 `BindReportData(...)` 등 `private` 메서드로 분리 |
| 헬퍼 | `Value`(DBNull 방어), `AddBlankRows`(고정 행수) 등 양식 고유 기능만 `private static`으로 최소 정의 |
| `MODEL_S1` | 클래스 하단에 `public class MODEL_S1 { }` 유지 |
| 호환 클래스 | 기존 화면이 `{리포트ID}A`로 호출하는 경우 파생 클래스를 같은 파일 하단에 배치 |
| 주석 | 생성자·메서드 위 `// YYYY-MM-DD [리포트명] 설명` 날짜 주석 ([aspx_cs_comment.md](aspx_cs_comment.md) 2항) |
| 금지 | `BuildReport` 동적 생성, 컨트롤 `new` 생성, 레이아웃 좌표/크기 변경을 `.cs`에서 하는 행위 |

---

### 3. `{리포트ID}.Designer.cs` 표준 구조

#### 3-1. 파일 골격 (순서 고정)
```csharp
namespace XtraRpt
{
    partial class R03
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // (3-2 순서대로 작성)
        }

        #endregion

        // 필드 선언 (3-5)
    }
}
```
- `using` 문 없이 모든 타입을 **전체 네임스페이스로 표기** (`DevExpress.XtraReports.UI.XRTableCell`, `System.Drawing.Font` 등).

#### 3-2. `InitializeComponent()` 내부 작성 순서
1. `this.components = new System.ComponentModel.Container();` — **반드시 첫 줄**
2. 밴드 인스턴스 생성: `TopMargin` → `BottomMargin` → `PageHeader` → `Detail` → (`ReportFooter` / `PageFooter` 등 필요 밴드)
3. 컨트롤 인스턴스 생성 — 밴드별로 `// PageHeader Controls`, `// Detail Controls`, `// ReportFooter Controls` 주석으로 묶고, 테이블은 `XRTable` → `XRTableRow` → `XRTableCell` 순으로 나열
4. `BeginInit()` — **`XRTable`들과 `this`만** 대상 (`XRTableRow` 절대 포함 금지)
   ```csharp
   ((System.ComponentModel.ISupportInitialize)(this.xrTablePlanInfo)).BeginInit();
   ((System.ComponentModel.ISupportInitialize)(this.xrTableDetail)).BeginInit();
   ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
   ```
5. 밴드·컨트롤 속성 설정 — 밴드 → 해당 밴드의 컨트롤 → (테이블 → 행 → 셀) 순서로 위에서 아래로
6. 리포트 속성 (`this.Bands.AddRange`, 용지/여백 등)
7. `EndInit()` — 4번과 **동일한 대상·동일한 순서**

#### 3-3. 속성 블록 작성 형식
- 밴드·`XRTable`·`XRTableRow` 블록 머리:
  ```csharp
  // 
  // xrTablePlanInfo
  // 
  ```
- `XRTableCell`·`XRLabel` 블록 머리: `// cell_Val_EQMNM` 한 줄
- 컨트롤을 자식으로 담는 `XRPanel`은 사용하지 않습니다. VS 디자이너에서 `component` null 오류가 발생합니다. 테두리 박스는 빈 `XRLabel`(`Borders = All`)로 대신합니다 ([report_devexpress.md](report_devexpress.md) 2-4).
- 속성은 **순수 대입문만** 사용 (헬퍼 메서드 호출·반복문·조건문 금지). 각 블록은 대략 다음 순서로 작성:
  `BackColor` → `Borders` → `Controls/Cells/Rows.AddRange` → `DataBindings` → `Dpi` → `Font` → `LocationFloat` → `Multiline` → `Name` → `Padding` → `SizeF`/`HeightF` → `StylePriority.*` → `Text` → `TextAlignment` → `Weight`/`WidthF`
- 모든 컨트롤에 `Dpi = 100F`, `Name = "{필드명과 동일}"` 지정
- 부모와 다른 스타일(`BackColor`, `Borders`, `Font`, `Padding`, `TextAlignment`)을 지정하면 짝이 되는 `StylePriority.UseXxx = false;`를 반드시 함께 작성
- 상세 셀 데이터 바인딩은 Designer에서 선언:
  ```csharp
  this.cell_Detail_NO.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
      new DevExpress.XtraReports.UI.XRBinding("Text", null, "NO")
  });
  ```
- 줄바꿈 텍스트는 `Multiline = true;` + `Text = "완료\r\n확인";`

#### 3-4. 리포트 속성 (A4 세로 기본값)
```csharp
// 
// R03 Report Properties
// 
this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
    this.TopMargin,
    this.BottomMargin,
    this.PageHeader,
    this.Detail,
    this.ReportFooter
});
this.Dpi = 100F;
this.Margins = new System.Drawing.Printing.Margins(48, 48, 35, 35);
this.PageHeight = 1169;
this.PageWidth = 827;
this.PaperKind = System.Drawing.Printing.PaperKind.A4;
this.Version = "16.1";   // 프로젝트가 참조하는 DevExpress 버전 (예: DevExpress.*.v16.1 → "16.1")
```
- `this.Version`은 `.csproj`의 DevExpress 참조 버전과 같은 값으로 씁니다. 같은 프로젝트의 기존 `Designer.cs` 값을 확인해 맞춥니다.
- `TopMargin`/`BottomMargin`: `HeightF = 20F`, `Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F)`, `TextAlignment = TopLeft`
- 인쇄 가능 폭 = `827 - 48 - 48 = 731F` → 모든 테이블/라벨의 가로 합계는 **731F**를 기준으로 맞춥니다.
- `XRTable`의 `SizeF` 폭 = 각 행의 셀 `WidthF` 합계 (예: `112 + 253 + 112 + 254 = 731`)
- `XRTableRow.Weight = 1D`
- 가로 양식 등 다른 용지가 필요할 때만 이 값을 변경하고, 변경 사유를 작업 이력에 남깁니다.

#### 3-5. 필드 선언부 (`#endregion` 아래)
- `InitializeComponent()`에서 생성한 **모든 컴포넌트를 빠짐없이** `private` 필드로 선언
- 순서: 밴드 → PageHeader 컨트롤 → Detail 컨트롤 → Footer 컨트롤, 그룹 사이 빈 줄 1개
- 전체 네임스페이스 타입 사용: `private DevExpress.XtraReports.UI.XRTableCell cell_Val_EQMNM;`

#### 3-6. 공통 스타일 기본값
| 용도 | 값 |
|---|---|
| 제목 라벨 | `new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold)`, `MiddleCenter` |
| 헤더/정보 테이블 | `"맑은 고딕", 9F`, `Borders = BorderSide.All` |
| 상세/푸터 | `"맑은 고딕", 8.5F` |
| 항목명(라벨) 셀·컬럼 헤더 | `BackColor = System.Drawing.Color.Gainsboro`, `MiddleCenter` |
| 값 셀(좌측 정렬) | `Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 0, 0, 100F)`, `MiddleLeft` |
| 코드·숫자·판정 셀 | `MiddleCenter` |

---

### 4. 컨트롤 명명 규칙

| 대상 | 접두어 | 예시 |
|---|---|---|
| 밴드 | 밴드 타입명 그대로 | `TopMargin`, `PageHeader`, `Detail`, `ReportFooter` |
| 독립 라벨 | `xrLabel{용도}` | `xrLabelTitle`, `xrLabelConfirm` |
| 테이블 | `xrTable{용도}` | `xrTablePlanInfo`, `xrTableDetailHeader`, `xrTableDetail` |
| 테이블 행 | `xrTableRow{용도}{번호}` | `xrTableRowInfo1`, `xrTableRowDetail` |
| 항목명 셀 | `cell_Lbl_{필드}` | `cell_Lbl_EQMNM` |
| 헤더 값 셀 | `cell_Val_{필드}` | `cell_Val_EQMNM` |
| 상세 컬럼 헤더 셀 | `cell_Hdr_{필드}` | `cell_Hdr_CHKITEM` |
| 상세 데이터 셀 | `cell_Detail_{필드}` | `cell_Detail_CHKITEM` |
| 반복 고정 영역 | `cell_{영역}_{항목}{인덱스}` | `cell_Rev_No0` ~ `cell_Rev_No3` |

- `{필드}`는 프로시저 결과 컬럼명(대문자)과 동일하게 맞춰 `.cs` 바인딩·`DataBindings`와 1:1로 대응시킵니다.

---

### 5. `{리포트ID}.resx` 표준

- 이미지·아이콘 등 리소스가 없으면 **데이터 항목 없는 표준 빈 resx**로 생성합니다. 아래 내용을 그대로 사용합니다 (UTF-8 with BOM + CRLF).
- 다른 리포트의 `resx`를 복사할 때 원본의 `<data>` 항목(이미지 Base64, 다른 컨트롤명 리소스)을 남기지 않습니다.

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
</root>
```

---

### 6. 생성 완료 체크리스트

- [ ] `{리포트ID}.cs` / `.Designer.cs` / `.resx` 3개 파일 생성, `.csproj`에 3개 항목 등록
- [ ] 파일명 = 클래스명 = 리포트ID, namespace `XtraRpt`
- [ ] 매개변수 없는 기본 생성자 + `: this()` 체이닝 파라미터 생성자
- [ ] `ItsMaria("{화면ID}_{리포트ID}", ...)` 표준 호출, DB 접속정보 하드코딩 없음
- [ ] 필수 파라미터 누락·조회 결과 없음 시 `InvalidOperationException` 안내
- [ ] `InitializeComponent()` 첫 줄 `components` 초기화, `BeginInit/EndInit` 대상에 `XRTableRow` 없음
- [ ] Designer 안에 헬퍼 메서드 호출·반복문 없음, 모든 컴포넌트 필드 선언 완료
- [ ] 자식 컨트롤을 담는 `XRPanel` 미사용 — 테두리 박스는 빈 `XRLabel` ([report_devexpress.md](report_devexpress.md) 2-4)
- [ ] VS에서 `{리포트ID}.cs` 디자이너 열기 확인 (빌드 성공만으로 판단하지 않음). 오류 페이지가 나오면 [report_devexpress.md](report_devexpress.md) 2-5 진단 절차대로 호출 스택부터 확보
- [ ] 테이블 셀 폭 합계 = 테이블 폭(기본 731F)
- [ ] 상세 셀 `DataBindings` 필드명 = 프로시저 결과 컬럼명
- [ ] `MODEL_S1` 및 필요 시 `{리포트ID}A` 호환 클래스 배치
- [ ] UTF-8 with BOM(단일) + CRLF
- [ ] MSBuild Rebuild 0 Error 확인 후 `{REPORT_BIN}`(예: `01.Office/Reports/`, `04.Report/bin/`)에 배포 ([report_devexpress.md](report_devexpress.md) 6항)
