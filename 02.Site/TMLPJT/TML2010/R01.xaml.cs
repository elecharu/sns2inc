using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using DevExpress.Xpf.Grid;

namespace TML2010
{
    /// <summary>
    /// 생산실적등록
    /// </summary>
    public partial class R01 : ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel(); //투입품번정보
        ItsModelPanel MODEL_B1 = new ItsModelPanel(); //생산실적정보

        ItsModelPanel MODEL_A1 = new ItsModelPanel(); //생산품목선택
        ItsModelPanel MODEL_A2 = new ItsModelPanel(); //불량등록
        ItsModelPanel MODEL_A3 = new ItsModelPanel(); //비가동등록
        ItsModelPanel MODEL_A5 = new ItsModelPanel(); //설비 일상점검
        ItsModelPanel MODEL_A6 = new ItsModelPanel(); //일상점검 등록·수정
        ItsModelPanel MODEL_A7 = new ItsModelPanel(); //점검값 입력(숫자)
        ItsModelPanel MODEL_A9 = new ItsModelPanel(); //문제점/조치사항
        ItsModelPanel MODEL_A10 = new ItsModelPanel(); //자주검사 등록
        ItsModelPanel MODEL_A11 = new ItsModelPanel(); //공정이동표 발행

        ItsModelGrid MODEL_G1 = new ItsModelGrid(); //투입목록
        ItsModelGrid MODEL_G2 = new ItsModelGrid(); //작업자
        ItsModelGrid MODEL_G3 = new ItsModelGrid(); //불량
        ItsModelGrid MODEL_G4 = new ItsModelGrid(); //비가동
        ItsModelGrid MODEL_G5 = new ItsModelGrid(); //생산품목선택
        ItsModelGrid MODEL_G6 = new ItsModelGrid(); //작업자선택
        ItsModelGrid MODEL_G7 = new ItsModelGrid(); //일상점검 실적
        ItsModelGrid MODEL_G8 = new ItsModelGrid(); //일상점검 실적 항목
        ItsModelGrid MODEL_G9 = new ItsModelGrid(); //일상점검 등록·수정 항목
        ItsModelGrid MODEL_G10 = new ItsModelGrid(); //자주검사 검사항목
        ItsModelGrid MODEL_G12 = new ItsModelGrid(); //공정이동표 발행 실적로트
        ItsModelGrid MODEL_G13 = new ItsModelGrid(); //실적삭제 최근 실적

        private string chgLinecd = ""; //BOM 불일치 시 바꿀 작업장
        private string chgPrccd = "";  //BOM 불일치 시 바꿀 공정

        private const string SHIP_PRCCD = "I2M1400_N"; //출하검사공정 (공정이동표 발행 팝업에서 라벨 관련 칸·버튼을 보임)

        public R01()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

            MODEL_B1.Binding(PANEL_B1);
            MODEL_B1.InitData();
            MODEL_B1.EventValueChanged += MODEL_B1_EventValueChanged;

            //양품수량은 텍스트 칸이라 정렬 속성이 없음 → 안쪽 입력칸을 찾아 오른쪽 정렬
            TextBox goodqtyBox = TXT_GOODQTY.FindName("textBox") as TextBox;
            if (goodqtyBox != null)
            {
                goodqtyBox.HorizontalContentAlignment = HorizontalAlignment.Right;
            }

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A2.Binding(PANEL_A2);
            MODEL_A2.EventValueChanged += MODEL_A2_EventValueChanged;
            MODEL_A3.Binding(PANEL_A3);
            MODEL_A5.Binding(PANEL_A5);
            MODEL_A6.Binding(PANEL_A6);
            MODEL_A7.Binding(PANEL_A7);
            MODEL_A9.Binding(PANEL_A9);
            MODEL_A10.Binding(PANEL_A10);
            MODEL_A10.EventValueChanged += MODEL_A10_EventValueChanged;
            MODEL_A11.Binding(PANEL_A11);
            MODEL_A11.FieldType("PRINT", ItsEnums.FieldTypes.String);
            MODEL_A11.FieldType("LABELPRINT", ItsEnums.FieldTypes.String);
            MODEL_A11.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.EventValueChanged += MODEL_G1_EventValueChanged;
            MODEL_G2.Binding(GRID_G2);
            MODEL_G3.Binding(GRID_G3);
            MODEL_G4.Binding(GRID_G4);
            MODEL_G5.Binding(GRID_G5);
            MODEL_G6.Binding(GRID_G6);
            MODEL_G7.Binding(GRID_G7);
            MODEL_G7.EventRowChanged += MODEL_G7_EventRowChanged;
            MODEL_G8.Binding(GRID_G8);
            MODEL_G9.Binding(GRID_G9);
            // 2026-11-26 일상점검 점검값 그리드에서 바로 입력 (숫자: 숫자패드, OK/NG: 누를 때마다 OK → NG → 빈칸)
            MODEL_G9.EventValueChanged += MODEL_G9_EventValueChanged;
            (GRID_G9.View as TableView).ShowingEditor += GRID_G9_ShowingEditor;
            GRID_G9.PreviewMouseLeftButtonUp += GRID_G9_PreviewMouseLeftButtonUp;
            this.PreviewKeyDown += KeyPad_PreviewKeyDown;   // 숫자 입력 팝업 키보드 입력

            // 숫자 입력 팝업 끌어서 옮기기 (터치·마우스)
            KEY_DRAG.TouchDown += KeyDrag_TouchDown;
            KEY_DRAG.TouchMove += KeyDrag_TouchMove;
            KEY_DRAG.TouchUp += KeyDrag_TouchUp;
            KEY_DRAG.MouseLeftButtonDown += KeyDrag_MouseDown;
            KEY_DRAG.MouseMove += KeyDrag_MouseMove;
            KEY_DRAG.MouseLeftButtonUp += KeyDrag_MouseUp;
            KEY_ZOOMIN.Click += (s, e) => KeyZoom(0.1);    // 숫자 입력 팝업 크기 조절
            KEY_ZOOMOUT.Click += (s, e) => KeyZoom(-0.1);
            MODEL_G10.Binding(GRID_G10);
            MODEL_G10.EventValueChanged += MODEL_G10_EventValueChanged;           // 자주검사 검사값 입력 → 판정
            (GRID_G10.View as TableView).ShowingEditor += GRID_G10_ShowingEditor;  // 입력 못 하는 칸 막기
            GRID_G10.PreviewMouseLeftButtonUp += GRID_G10_PreviewMouseLeftButtonUp; // 육안 판정 칸 누르기

            // L/R 유무 항목의 L·R 두 줄은 항목 정보·판정 칸을 세로로 합쳐 보여줌 (2026-11-26)
            // 병합 설정은 그리드 Loaded 때 저장된 레이아웃 복원(LoadGridStyle)으로 되돌아가므로 조회할 때마다 다시 켠다 (PrcApplyMerge)
            (GRID_G10.View as TableView).CellMerge += GRID_G10_CellMerge;
            MODEL_G12.Binding(GRID_G12);
            MODEL_G13.Binding(GRID_G13);

            //공정이동표 발행 팝업 프린터 목록 (TMLMAIN 프린터 설정과 같은 방식)
            CMB_PRINT.ItemClear();
            CMB_LABELPRINT.ItemClear();
            foreach (string printer in ItsPrinter.GetPrinterList())
            {
                CMB_PRINT.AddItem(printer, printer);
                CMB_LABELPRINT.AddItem(printer, printer);
            }
        }
        /***************************************************************************************************************************************************************/
        private void MODEL_S1_EventValueChanged(string fieldName)
        {
            if (fieldName == "LINECD")
            {
                MODEL_S1.SetRef01("EQMCD", MODEL_S1.GetText("LINECD"));
                MODEL_S1.SetRef01("PRCCD", MODEL_S1.GetText("LINECD"));
            }
            else if (fieldName == "PRCCD")
            {
                MODEL_S1.SetRef02("EQMCD", MODEL_S1.GetText("PRCCD"));
            }
            //else if (fieldName == "EQMCD")
            //{
            //    if (MODEL_S1.GetText("EQMCD") != "" && MODEL_B1.GetText("DNTP") == "")
            //    {
            //        //콤보 값이 모델에 들어가는 도중이라 바로 바꾸면 화면에 반영되지 않음 → 처리 끝난 뒤 비우고 메시지
            //        //이 이벤트가 한 번 선택에 두 번 올 수 있어 이미 비었으면 그냥 끝냄
            //        Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            if (MODEL_S1.GetText("EQMCD") == "")
            //            {
            //                return;
            //            }

            //            MODEL_S1.SetValue("EQMCD", "");
            //            ShowMessageBox("", "주야구분을 선택하세요.");
            //        }));
            //        return;
            //    }
            //}

            //작업장, 공정이 바뀌면 투입자재로트 조회
            if (fieldName == "LINECD" || fieldName == "PRCCD" || fieldName == "EQMCD")
            {
                if (MODEL_S1.GetText("LINECD") != "" && MODEL_S1.GetText("PRCCD") != "" && MODEL_S1.GetText("EQMCD") != "")
                {
                    EventCommand("LIST_INPUT");
                }
                else
                {
                    GRID_G1.Clear();
                    GRID_G2.Clear();
                    GRID_G3.Clear();
                    GRID_G4.Clear();
                    MODEL_B1.SetValue("BADQTY", 0);
                    MODEL_S1.SetValue("ITEMID", "");
                    MODEL_S1.SetValue("ITEMCD", "");
                    MODEL_S1.SetValue("ITEMNM", "");
                    MODEL_S1.SetValue("ITEMSPEC", "");
                    MODEL_S1.SetValue("PLANQTY_DAY", "");
                    MODEL_S1.SetValue("PLANQTY_NIGHT", "");
                    MODEL_B1.SetValue("GOODQTY", "");
                }
            }
        }

        private void MODEL_G1_EventValueChanged(int rowIndex, string fieldName)
        {
            if (fieldName == "USEQTY")
            {
                CalcGoodQty();
            }
        }

        //양품수량 = 투입로트 사용량 합계 - 불량수량 (0 이하면 빈칸)
        // 2026-11-26 조립공정(I2M2000_N)은 투입자재가 2가지 이상일 수 있어 자품목 1개 기준 :
        //            자품목별 사용량 합계 / BOM투입량(BOMRATE) 중 첫 번째 자품목 값 (작업완료 때 IO_PRDRST 가 모두 같은지 확인)
        private void CalcGoodQty()
        {
            decimal sumqty = 0;
            Dictionary<string, decimal> itemQty = new Dictionary<string, decimal>();   // 자품목ID → 사용량 합계 / BOM투입량
            List<string> itemOrder = new List<string>();
            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                decimal useqty;
                if (decimal.TryParse(MODEL_G1.GetText(i, "USEQTY"), out useqty))
                {
                    sumqty += useqty;

                    string itemId = MODEL_G1.GetText(i, "ITEMID");
                    // 프로시저 반영 전(BOMRATE 열 없음)이면 1 (GetValue 는 없는 열이면 메시지창을 띄움)
                    decimal rate = MODEL_G1.Columns.Contains("BOMRATE") ? MODEL_G1.GetDecimal(i, "BOMRATE") : 1;
                    if (rate <= 0) rate = 1;
                    if (!itemQty.ContainsKey(itemId)) { itemQty[itemId] = 0; itemOrder.Add(itemId); }
                    itemQty[itemId] += useqty / rate;
                }
            }

            if (MODEL_S1.GetText("PRCCD") == "I2M2000_N" && itemOrder.Count > 0)
            {
                sumqty = Math.Round(itemQty[itemOrder[0]], 4);
            }

            decimal badqty;
            decimal.TryParse(MODEL_B1.GetText("BADQTY"), out badqty);

            //양품수량 칸은 텍스트 칸 → 0 이하면 빈칸
            MODEL_B1.SetValue("GOODQTY", sumqty - badqty > 0 ? (sumqty - badqty).ToString("#,0") : "");
        }

        private void MODEL_B1_EventValueChanged(string fieldName)
        {
            if (fieldName == "DNTP")
            {
                //야간(PP161102N)이면 작업시작일 전날, 아니면 오늘
                if (MODEL_B1.GetText("DNTP") == "PP161102N")
                {
                    MODEL_B1.SetValue("WORKSDAY", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                }
                else
                {
                    MODEL_B1.SetValue("WORKSDAY", DateTime.Now.ToString("yyyy-MM-dd"));
                }

                //주야구분 명칭 예) 야간(16:00~02:00) → ~ 왼쪽 5자 시작시간, 오른쪽 5자 종료시간
                string dntpnm = CMB_DNTP.SelectedLabel;
                int idx = dntpnm.IndexOf("~");
                if (idx < 5 || dntpnm.Length < idx + 6)
                {
                    return;
                }

                MODEL_B1.SetValue("WORKSTIME", dntpnm.Substring(idx - 5, 5));
                MODEL_B1.SetValue("WORKETIME", dntpnm.Substring(idx + 1, 5));
            }
        }

        private void MODEL_A2_EventValueChanged(string fieldName)
        {
            //대분류, 중분류가 바뀌면 불량코드 find 필터 변경 후 선택한 불량코드 비움
            if (fieldName == "BADTP1")
            {
                MODEL_A2.SetRef02("BADCD", MODEL_A2.GetText("BADTP1"));
                MODEL_A2.SetValue("BADCD", "");
            }
            else if (fieldName == "BADTP2")
            {
                MODEL_A2.SetRef03("BADCD", MODEL_A2.GetText("BADTP2"));
                MODEL_A2.SetValue("BADCD", "");
            }
        }
        //비가동 유형 버튼 (TML2040 NontpButton 참고, 라인 대신 작업장 기준)
        private void NontpButton()
        {
            ItsMaria.Set("TML2010_R01", "LIST_NONTP");
            ItsMaria.AddModel(MODEL_S1);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            NONTP_LIST.Clear();
            NONTP_LIST.ButtonWidth = "80";
            NONTP_LIST.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NONTP_LIST.AddButton(ItsData.GetText(ds.Tables[0], i, "TPNM"), ItsData.GetText(ds.Tables[0], i, "NONTP"));
            }
        }

        //비가동 코드 버튼 (선택한 유형 기준)
        private void NoncdButton()
        {
            ItsMaria.Set("TML2010_R01", "LIST_MSTNON");
            ItsMaria.AddModel(MODEL_S1);
            ItsMaria.AddOne("NONTP", NONTP_LIST.Value);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            NONCD_LIST.Clear();
            NONCD_LIST.ButtonWidth = "80";
            NONCD_LIST.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NONCD_LIST.AddButton(ItsData.GetText(ds.Tables[0], i, "NONNM"), ItsData.GetText(ds.Tables[0], i, "NONCD"));
            }
        }

        //일상점검 실적 선택 → 점검 항목
        private void MODEL_G7_EventRowChanged(int rowIndex)
        {
            MODEL_G8.InitData();
            if (rowIndex < 0)
            {
                return;
            }

            ItsMaria.Set("TAL0001_R05", "LIST_CHKRSTEQMKND");
            ItsMaria.AddOne("CHKRSTKEY", MODEL_G7.GetText(rowIndex, "CHKRSTKEY"));
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            MODEL_G8.SetData(ds.Tables[0]);
            JudgeAll(MODEL_G8);
        }

        // 2026-11-26 일상점검 자동판정 (화면 표시만, 저장하지 않음. TAL0001_R05 와 같은 규칙)
        //   수치 항목: 계획 판정범위(MINVAL~MAXVAL) 안이면 합격, 밖이면 불합격 / OK·NG: OK 합격, NG 불합격
        //   점검값이 없거나 판정범위가 없는 항목은 빈칸, 불합격 줄은 빨간 글씨
        private static string JudgeText(string val, string stdtp, string min, string max)
        {
            val = (val ?? "").Trim();
            if (val == "") return "";
            if (val.ToUpper() == "OK") return "합격";
            if (val.ToUpper() == "NG") return "불합격";

            decimal v, lo, hi;
            if (stdtp != "RANGE" || !decimal.TryParse(val, out v)) return "";
            if (decimal.TryParse(min, out lo) && v < lo) return "불합격";
            if (decimal.TryParse(max, out hi) && v > hi) return "불합격";
            return "합격";
        }

        private void JudgeRow(ItsModelGrid model, int row)
        {
            if (row < 0 || !model.Columns.Contains("JUDGE")) return;
            // 프로시저 반영 전(판정범위 열 없음)이면 OK/NG 만 판정 (없는 열을 읽으면 메시지창이 뜸)
            bool hasRange = model.Columns.Contains("STDTP") && model.Columns.Contains("MINVAL") && model.Columns.Contains("MAXVAL");
            string judge = JudgeText(model.GetText(row, "CHKVALUE"),
                                     hasRange ? model.GetText(row, "STDTP") : "",
                                     hasRange ? model.GetText(row, "MINVAL") : "",
                                     hasRange ? model.GetText(row, "MAXVAL") : "");
            model.SetValue(row, "JUDGE", judge);
            model.SetForeColor(row, judge == "불합격" ? Colors.Red : Colors.Black);
        }

        //===== 일상점검 점검값 그리드 입력 (2026-11-26) =====
        private bool _chkJudging = false;

        //숫자 점검값 입력 → 판정
        private void MODEL_G9_EventValueChanged(int rowIndex, string fieldName)
        {
            if (_chkJudging || fieldName != "CHKVALUE" || rowIndex < 0) return;
            _chkJudging = true;
            JudgeRow(MODEL_G9, rowIndex);
            _chkJudging = false;
        }

        //OK/NG 항목(점검값구분 01 아님)은 점검값 칸 글자 입력 막기 (누르면 OK/NG 바뀜)
        private void GRID_G9_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.Column == null || e.Column.FieldName != "CHKVALUE") return;
            DataRowView drv = GRID_G9.GetRow(e.RowHandle) as DataRowView;
            if (drv == null || drv["CHKVALTP"].ToString() != "01") e.Cancel = true;
        }

        //점검값 칸을 누르면 입력 팝업(POPUP_A13): 숫자 항목은 숫자, OK/NG 항목은 OK·NG 버튼 (2026-11-26)
        private void GRID_G9_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TableViewHitInfo hit = (GRID_G9.View as TableView).CalcHitInfo(e.OriginalSource as DependencyObject);
            if (!hit.InRowCell || hit.Column == null || hit.Column.FieldName != "CHKVALUE") return;

            DataRowView drv = GRID_G9.GetRow(hit.RowHandle) as DataRowView;
            if (drv == null) return;
            int row = MODEL_G9.Rows.IndexOf(drv.Row);
            if (row >= 0) KeyPadOpen("CHK", row, "CHKVALUE");
        }

        //OK/NG 항목 새 점검은 OK 를 미리 넣음 (값이 비어 있는 것만, 2026-11-26)
        private void ChkDefaultOk()
        {
            _chkJudging = true;
            for (int i = 0; i < MODEL_G9.Rows.Count; i++)
            {
                if (MODEL_G9.GetText(i, "CHKVALTP") != "01" && MODEL_G9.GetText(i, "CHKVALUE").Trim() == "")
                    MODEL_G9.SetValue(i, "CHKVALUE", "OK");
            }
            _chkJudging = false;
        }

        private void JudgeAll(ItsModelGrid model)
        {
            for (int i = 0; i < model.Rows.Count; i++)
            {
                JudgeRow(model, i);
            }
        }

        //자주검사 합격·불합격은 하나만 체크
        private void MODEL_A10_EventValueChanged(string fieldName)
        {
            if (fieldName == "OK" && MODEL_A10.GetBool("OK"))
            {
                MODEL_A10.SetValue("NG", false);
            }
            else if (fieldName == "NG" && MODEL_A10.GetBool("NG"))
            {
                MODEL_A10.SetValue("OK", false);
            }
        }

        //===== 자주검사 그리드 하나 입력 (2026-11-26, TAL2001_R01 과 같음) =====
        // 검사항목 한 줄(ROWTP L), L/R 유무 항목은 바로 아래 R 줄(ROWTP R). 시료 칸 X01~X10
        private const int PRC_MAXSAMPLE = 10;

        // L·R 두 줄을 세로로 합치는 칸 (검사항목 ~ 시료수, 판정)
        private static readonly string[] PRC_MERGE_FIELDS = { "STDNM", "STDPART", "STDCHKTP", "STDJUDGE", "STDCYCLE", "CYCLEINFO", "SAMPLESIZE", "JUDGENM" };

        //병합 켜기: 그리드 뷰 + 합칠 칸만 (나머지 칸은 끔)
        //DevExpress 는 여러 칸 선택(SelectionMode Cell/Row) 이면 병합을 끈다. ITSLIB.Grid 기본이 MultiSelectMode.Cell 이라 이 그리드만 None 으로
        private void PrcApplyMerge()
        {
            TableView view = GRID_G10.View as TableView;
            if (view == null) return;
            GRID_G10.SelectionMode = MultiSelectMode.None;
            view.AllowCellMerge = true;
            foreach (GridColumn col in GRID_G10.Columns)
            {
                col.AllowCellMerge = Array.IndexOf(PRC_MERGE_FIELDS, col.FieldName) >= 0;
            }
        }

        //같은 항목의 L 줄·R 줄만 합침 (값이 같아도 다른 항목끼리는 안 합침)
        private void GRID_G10_CellMerge(object sender, CellMergeEventArgs e)
        {
            DataRowView r1 = GRID_G10.GetRow(e.RowHandle1) as DataRowView;
            DataRowView r2 = GRID_G10.GetRow(e.RowHandle2) as DataRowView;
            e.Merge = r1 != null && r2 != null
                && r1["ROWTP"].ToString() == "L" && r2["ROWTP"].ToString() == "R"
                && r1["STDCD"].ToString() == r2["STDCD"].ToString()
                && r1["STDPART"].ToString() == r2["STDPART"].ToString()
                && r1["PRCDETAIL"].ToString() == r2["PRCDETAIL"].ToString();
            e.Handled = true;
        }

        private static string XCol(int no)
        {
            return "X" + no.ToString("00");
        }

        // 시료 칸 번호 (X01 → 1, 시료 칸이 아니면 0)
        private static int XNo(string field)
        {
            if (field == null || field.Length != 3 || field[0] != 'X') return 0;
            int no;
            return int.TryParse(field.Substring(1), out no) ? no : 0;
        }

        // 항목의 L 줄 번호 (R 줄이면 바로 위)
        private int PrcLRow(int row)
        {
            return MODEL_G10.GetText(row, "ROWTP") == "R" ? row - 1 : row;
        }

        // 그 줄 항목의 시료수
        private int PrcSample(int row)
        {
            return Math.Min((int)MODEL_G10.GetDecimal(PrcLRow(row), "SAMPLESIZE"), PRC_MAXSAMPLE);
        }

        // 값을 넣을 수 있는 칸: 시료수 안 시료 칸 (측정은 숫자패드, 육안은 눌러서 OK/NG)
        private bool PrcCanInput(int row, string field)
        {
            int no = XNo(field);
            if (no == 0 || row < 0 || row >= MODEL_G10.Rows.Count) return false;
            return no <= PrcSample(row);
        }

        // 글자로 입력하는 칸: 측정검사(02) 항목의 시료 칸
        private bool PrcCanEdit(int row, string field)
        {
            return PrcCanInput(row, field) && MODEL_G10.GetText(PrcLRow(row), "STDCHKTP") == "02";
        }

        // 검사값이 판정범위 안인지. 범위 코드(STDRANGE): 01 최대, 02 최소, 03 이상, 04 이내, 05 =, 06 ~ (경계값 포함 합격)
        // 육안(측정 아님)은 OK 합격, NG 불합격 (2026-11-26 시료마다 OK/NG)
        private bool PrcIsOk(int lrow, string text)
        {
            if (MODEL_G10.GetText(lrow, "STDCHKTP") != "02") return text.Trim().ToUpper() == "OK";
            decimal v, stdval, stdminus, stdplus;
            if (!decimal.TryParse(text, out v)) return false;
            decimal.TryParse(MODEL_G10.GetText(lrow, "STDVAL"), out stdval);
            decimal.TryParse(MODEL_G10.GetText(lrow, "STDMINUS"), out stdminus);
            decimal.TryParse(MODEL_G10.GetText(lrow, "STDPLUS"), out stdplus);
            string stdrange = MODEL_G10.GetText(lrow, "STDRANGE");

            if (stdrange == "01" || stdrange == "04") return v <= stdval;
            if (stdrange == "02" || stdrange == "03") return v >= stdval;
            if (stdrange == "05") return v == stdval;
            if (stdrange == "06") return v >= stdval + stdminus && v <= stdval + stdplus;
            return true;
        }

        // 판정 표시 (L 줄에만), 불합격이면 그 항목 줄(L·R) 빨간 글자
        private bool _prcJudging = false;
        private void PrcSetJudge(int lrow, string judge)
        {
            _prcJudging = true;
            MODEL_G10.SetValue(lrow, "JUDGE", judge);
            MODEL_G10.SetValue(lrow, "JUDGENM", judge == "Y" ? "합격" : (judge == "N" ? "불합격" : ""));
            MODEL_G10.SetForeColor(lrow, judge == "N" ? Colors.Red : Colors.Black);
            if (MODEL_G10.GetText(lrow, "LRYN") == "Y" && lrow + 1 < MODEL_G10.Rows.Count && MODEL_G10.GetText(lrow + 1, "ROWTP") == "R")
            {   // R 줄도 같은 판정 (합쳐진 판정 칸이 R 줄 값을 보여줌)
                MODEL_G10.SetValue(lrow + 1, "JUDGE", judge);
                MODEL_G10.SetValue(lrow + 1, "JUDGENM", judge == "Y" ? "합격" : (judge == "N" ? "불합격" : ""));
                MODEL_G10.SetForeColor(lrow + 1, judge == "N" ? Colors.Red : Colors.Black);
            }
            _prcJudging = false;
        }

        // 자동 판정 (측정·육안): 하나라도 벗어나면(육안은 NG) 불합격, 모든 칸(L/R 항목은 L·R 다)이 차고 다 맞으면 합격, 아니면 빈칸
        private void PrcJudgeItem(int lrow)
        {
            if (lrow < 0) return;

            List<int> lines = new List<int> { lrow };
            if (MODEL_G10.GetText(lrow, "LRYN") == "Y" && lrow + 1 < MODEL_G10.Rows.Count) lines.Add(lrow + 1);

            int n = PrcSample(lrow);
            bool hasNg = false, allEntered = true;
            foreach (int r in lines)
            {
                for (int x = 1; x <= n; x++)
                {
                    string v = MODEL_G10.GetText(r, XCol(x)).Trim();
                    if (v == "") allEntered = false;
                    else if (!PrcIsOk(lrow, v)) hasNg = true;
                }
            }
            PrcSetJudge(lrow, hasNg ? "N" : (allEntered && n > 0 ? "Y" : ""));
        }

        //자주검사 검사값 입력 → 그 항목 판정
        private void MODEL_G10_EventValueChanged(int rowIndex, string fieldName)
        {
            if (_prcJudging || XNo(fieldName) == 0 || rowIndex < 0) return;
            PrcJudgeItem(PrcLRow(rowIndex));
        }

        //입력 못 하는 칸(측정 아님, 시료수 넘는 칸)은 편집 막기
        private void GRID_G10_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (XNo(e.Column.FieldName) == 0) return;   // 시료 칸이 아니면 원래 설정(ReadOnly)대로
            DataRowView drv = GRID_G10.GetRow(e.RowHandle) as DataRowView;
            int row = drv == null ? -1 : MODEL_G10.Rows.IndexOf(drv.Row);
            if (!PrcCanEdit(row, e.Column.FieldName)) e.Cancel = true;
        }

        //===== 숫자 입력 팝업 POPUP_A13 (2026-11-26) =====
        // 자주검사 시료 칸(PRC, GRID_G10)·일상점검 숫자 점검값(CHK, GRID_G9) 공용. 누르는 대로 칸에 바로 들어감
        // [다음]/Enter: 같은 줄 다음 시료 → 마지막이면 다음 줄 첫 입력 칸. 더 없으면 닫기
        private string _keyTarget = "";   // PRC / CHK
        private int _keyRow = -1;
        private string _keyField = "";
        private bool _keyIsOkNg = false;   // 지금 칸이 OK/NG 항목인지 (숫자 키는 안 먹고 OK·NG 버튼만)

        //입력 그리드 정렬 끄기: 머리글을 눌러 정렬된 상태면 값을 넣는 순간 줄이 정렬 위치로 옮겨 감 (2026-11-26)
        //저장된 그리드 레이아웃에 정렬이 남아 있을 수 있어서 조회할 때마다 정렬도 지운다
        private void NoSort(ITSLIB.Grid grid)
        {
            try
            {
                TableView view = grid.View as TableView;
                if (view != null)
                {
                    view.AllowSorting = false;
                    view.ImmediateUpdateRowPosition = false;
                }
                grid.ClearSorting();
            }
            catch { }
        }

        private void KeyPadOpen(string target, int row, string field)
        {
            _keyTarget = target;
            _keyRow = row;
            _keyField = field;

            ItsModelGrid model = target == "PRC" ? MODEL_G10 : MODEL_G9;
            ITSLIB.Grid grid = target == "PRC" ? GRID_G10 : GRID_G9;

            _keyIsOkNg = target == "PRC" ? MODEL_G10.GetText(PrcLRow(row), "STDCHKTP") != "02"
                                         : MODEL_G9.GetText(row, "CHKVALTP") != "01";

            if (target == "PRC")
            {
                int lrow = PrcLRow(row);
                string part = MODEL_G10.GetText(lrow, "STDPART").Trim();
                string side = MODEL_G10.GetText(row, "SIDE");
                // 검사항목 · 세부항목 · L/R · 시료번호 (세부항목·L/R 은 있을 때만)
                TXT_KEYTITLE.Text = MODEL_G10.GetText(lrow, "STDNM") + (part != "" ? " · " + part : "")
                                  + (side != "" ? " · " + side : "") + " · X" + XNo(field);
            }
            else
            {
                string std = MODEL_G9.GetText(row, "CHKSTD").Trim();
                TXT_KEYTITLE.Text = MODEL_G9.GetText(row, "CHKKNDNM") + (std != "" ? " · " + std : "");   // 점검기준 없으면 점검명만
            }
            TXT_KEYVAL.Text = model.GetText(row, field);

            // 입력 중인 칸 표시: 그 줄·칸에 포커스
            try
            {
                model.SelectRow(row);
                grid.CurrentColumn = grid.Columns[field];
            }
            catch { }

            if (POPUP_A13.Visibility != Visibility.Visible) PANEL_A13.Show();
            KeyDragHookTitleBar();   // 상단바 끌어서 옮기기
        }

        private void KeyPadPress(string key)
        {
            if (_keyRow < 0 || _keyField == "") return;
            ItsModelGrid model = _keyTarget == "PRC" ? MODEL_G10 : MODEL_G9;
            if (_keyRow >= model.Rows.Count) { PANEL_A13.Close(); return; }

            if (key == "ENTER") { KeyPadNext(); return; }

            // OK/NG 항목: OK·NG 버튼은 값 넣고 바로 다음 칸, 지움·← 는 빈칸. 숫자 키는 무시
            // 숫자 항목: OK·NG 버튼 무시
            if (key == "OK" || key == "NG")
            {
                if (!_keyIsOkNg) return;
                TXT_KEYVAL.Text = key;
                model.SetValue(_keyRow, _keyField, key);   // EventValueChanged 가 판정
                KeyPadNext();
                return;
            }
            if (_keyIsOkNg)
            {
                if (key != "CLEAR" && key != "BACK") return;
                TXT_KEYVAL.Text = "";
                model.SetValue(_keyRow, _keyField, "");
                return;
            }

            string v = TXT_KEYVAL.Text ?? "";
            if (key.Length == 1 && char.IsDigit(key[0])) v += key;
            else if (key == "DOT") { if (!v.Contains(".")) v += (v == "" || v == "-" ? "0." : "."); }
            else if (key == "MINUS") { v = v.StartsWith("-") ? v.Substring(1) : "-" + v; }
            else if (key == "BACK") { if (v.Length > 0) v = v.Substring(0, v.Length - 1); }
            else if (key == "CLEAR") v = "";
            else return;

            TXT_KEYVAL.Text = v;
            model.SetValue(_keyRow, _keyField, v);   // EventValueChanged 가 판정
        }

        private void KeyPadNext()
        {
            if (_keyTarget == "PRC")
            {
                // 측정·OK/NG 모두 입력 칸 (2026-11-26 OK/NG 도 키패드로)
                int no = XNo(_keyField);
                if (no < PrcSample(_keyRow) && PrcCanInput(_keyRow, XCol(no + 1)))
                {
                    KeyPadOpen("PRC", _keyRow, XCol(no + 1));
                    return;
                }
                for (int r = _keyRow + 1; r < MODEL_G10.Rows.Count; r++)
                {
                    if (PrcCanInput(r, XCol(1)))
                    {
                        KeyPadOpen("PRC", r, XCol(1));
                        return;
                    }
                }
            }
            else
            {
                if (_keyRow + 1 < MODEL_G9.Rows.Count)   // 숫자·OK/NG 모두 다음 줄
                {
                    KeyPadOpen("CHK", _keyRow + 1, "CHKVALUE");
                    return;
                }
            }
            PANEL_A13.Close();   // 마지막 칸
        }

        //----- 숫자 입력 팝업 끌어서 옮기기 (2026-11-26) -----
        // 손잡이 줄(KEY_DRAG)을 손가락·마우스로 끌면 POPUP_A13 의 Canvas.Left/Top 을 바꾼다. 화면(Canvas) 밖으로는 못 나감
        // 터치는 Touch 이벤트로 처리하고 e.Handled 로 마우스 승격을 막는다 (같은 끌기가 두 번 처리되지 않게)
        private bool _keyDragging = false;
        private Point _keyDragStart;
        private double _keyDragLeft, _keyDragTop;

        private void KeyDragBegin(Point p)
        {
            _keyDragging = true;
            _keyDragStart = p;
            _keyDragLeft = Canvas.GetLeft(POPUP_A13);
            _keyDragTop = Canvas.GetTop(POPUP_A13);
            if (double.IsNaN(_keyDragLeft)) _keyDragLeft = 0;
            if (double.IsNaN(_keyDragTop)) _keyDragTop = 0;
        }

        private void KeyDragTo(Point p)
        {
            if (!_keyDragging) return;
            Canvas canvas = POPUP_A13.Parent as Canvas;
            double left = _keyDragLeft + (p.X - _keyDragStart.X);
            double top = _keyDragTop + (p.Y - _keyDragStart.Y);
            if (canvas != null && canvas.ActualWidth > 0)
            {
                left = Math.Max(0, Math.Min(left, canvas.ActualWidth - POPUP_A13.ActualWidth * _keyScale));   // 크기 조절 배율 반영
                top = Math.Max(0, Math.Min(top, canvas.ActualHeight - POPUP_A13.ActualHeight * _keyScale));
            }
            Canvas.SetLeft(POPUP_A13, left);
            Canvas.SetTop(POPUP_A13, top);
        }

        //크기 조절: 팝업 전체를 배율로 키우고 줄임 (0.7 ~ 1.6배). 커진 만큼 화면 밖으로 나가면 안쪽으로 당김
        private double _keyScale = 1.0;
        private void KeyZoom(double step)
        {
            _keyScale = Math.Round(Math.Max(0.7, Math.Min(1.6, _keyScale + step)), 1);
            POPUP_A13.LayoutTransform = new ScaleTransform(_keyScale, _keyScale);
            POPUP_A13.UpdateLayout();

            Canvas canvas = POPUP_A13.Parent as Canvas;
            if (canvas == null || canvas.ActualWidth <= 0) return;
            double w = POPUP_A13.ActualWidth * _keyScale, h = POPUP_A13.ActualHeight * _keyScale;
            double left = Canvas.GetLeft(POPUP_A13), top = Canvas.GetTop(POPUP_A13);
            if (double.IsNaN(left)) left = 0;
            if (double.IsNaN(top)) top = 0;
            Canvas.SetLeft(POPUP_A13, Math.Max(0, Math.Min(left, canvas.ActualWidth - w)));
            Canvas.SetTop(POPUP_A13, Math.Max(0, Math.Min(top, canvas.ActualHeight - h)));
        }

        //끌기 손잡이(sender) 안의 버튼(－/＋)이나 닫기(✕, 상단바의 Canvas)를 누른 것이면 끌기 시작 안 함
        private static bool IsOnControl(object source, object stopAt)
        {
            DependencyObject d = source as DependencyObject;
            while (d != null && d != stopAt)
            {
                if (d is System.Windows.Controls.Primitives.ButtonBase || d is Canvas) return true;
                d = (d is Visual || d is System.Windows.Media.Media3D.Visual3D) ? VisualTreeHelper.GetParent(d) : LogicalTreeHelper.GetParent(d);
            }
            return false;
        }

        //팝업 상단바(TML_POP 템플릿의 TML_POP_TITLEBAR)도 끌기 손잡이로 쓴다 (처음 열 때 한 번 연결)
        private bool _keyTitleHooked = false;
        private void KeyDragHookTitleBar()
        {
            if (_keyTitleHooked) return;
            POPUP_A13.ApplyTemplate();
            UIElement bar = POPUP_A13.Template == null ? null : POPUP_A13.Template.FindName("TML_POP_TITLEBAR", POPUP_A13) as UIElement;
            if (bar == null) return;
            bar.TouchDown += KeyDrag_TouchDown;
            bar.TouchMove += KeyDrag_TouchMove;
            bar.TouchUp += KeyDrag_TouchUp;
            bar.MouseLeftButtonDown += KeyDrag_MouseDown;
            bar.MouseMove += KeyDrag_MouseMove;
            bar.MouseLeftButtonUp += KeyDrag_MouseUp;
            _keyTitleHooked = true;
        }

        private void KeyDrag_TouchDown(object sender, TouchEventArgs e)
        {
            if (IsOnControl(e.OriginalSource, sender)) return;
            KeyDragBegin(e.GetTouchPoint(POPUP_A13.Parent as IInputElement).Position);
            e.TouchDevice.Capture(sender as IInputElement);
            e.Handled = true;
        }

        private void KeyDrag_TouchMove(object sender, TouchEventArgs e)
        {
            if (e.TouchDevice.Captured != sender) return;
            KeyDragTo(e.GetTouchPoint(POPUP_A13.Parent as IInputElement).Position);
            e.Handled = true;
        }

        private void KeyDrag_TouchUp(object sender, TouchEventArgs e)
        {
            if (e.TouchDevice.Captured != sender) return;
            _keyDragging = false;
            (sender as UIElement).ReleaseTouchCapture(e.TouchDevice);
            e.Handled = true;
        }

        private void KeyDrag_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.StylusDevice != null) return;   // 터치에서 승격된 마우스 이벤트는 무시 (Touch 이벤트가 처리)
            if (IsOnControl(e.OriginalSource, sender)) return;
            KeyDragBegin(e.GetPosition(POPUP_A13.Parent as IInputElement));
            (sender as UIElement).CaptureMouse();
            e.Handled = true;
        }

        private void KeyDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.StylusDevice != null || !(sender as UIElement).IsMouseCaptured) return;
            KeyDragTo(e.GetPosition(POPUP_A13.Parent as IInputElement));
        }

        private void KeyDrag_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.StylusDevice != null || !(sender as UIElement).IsMouseCaptured) return;
            _keyDragging = false;
            (sender as UIElement).ReleaseMouseCapture();
            e.Handled = true;
        }

        //키보드로도 입력 (숫자, ., -, Backspace, Delete, Enter, Esc)
        private void KeyPad_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (POPUP_A13.Visibility != Visibility.Visible) return;

            string key = null;
            if (e.Key >= Key.D0 && e.Key <= Key.D9) key = ((int)(e.Key - Key.D0)).ToString();
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) key = ((int)(e.Key - Key.NumPad0)).ToString();
            else if (e.Key == Key.Decimal || e.Key == Key.OemPeriod) key = "DOT";
            else if (e.Key == Key.Subtract || e.Key == Key.OemMinus) key = "MINUS";
            else if (e.Key == Key.Back) key = "BACK";
            else if (e.Key == Key.Delete) key = "CLEAR";
            else if (e.Key == Key.Enter) key = "ENTER";
            else if (e.Key == Key.O) key = "OK";   // OK/NG 항목: O = OK, N = NG
            else if (e.Key == Key.N) key = "NG";
            else if (e.Key == Key.Escape) { PANEL_A13.Close(); e.Handled = true; return; }

            if (key == null) return;
            KeyPadPress(key);
            e.Handled = true;
        }

        //시료 칸을 누르면 입력 팝업(POPUP_A13): 측정 항목은 숫자, 육안 항목은 OK·NG 버튼 (판정 자동)
        private void GRID_G10_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TableViewHitInfo hit = (GRID_G10.View as TableView).CalcHitInfo(e.OriginalSource as DependencyObject);
            if (!hit.InRowCell || hit.Column == null || XNo(hit.Column.FieldName) == 0) return;

            DataRowView drv = GRID_G10.GetRow(hit.RowHandle) as DataRowView;
            if (drv == null) return;
            int row = MODEL_G10.Rows.IndexOf(drv.Row);
            string field = hit.Column.FieldName;
            if (!PrcCanInput(row, field)) return;

            KeyPadOpen("PRC", row, field);
        }

        //조회 결과(검사항목·저장된 검사값) → 그리드 줄 (항목 1건 = L 줄, L/R 유무 항목은 + R 줄)
        private void PrcBindRows(DataTable std, DataTable values)
        {
            DataTable dt = std.Clone();
            foreach (DataColumn c in dt.Columns) c.DataType = typeof(string);
            foreach (string name in new string[] { "ROWTP", "SIDE" })
                if (!dt.Columns.Contains(name)) dt.Columns.Add(name, typeof(string));
            for (int x = 1; x <= PRC_MAXSAMPLE; x++)
                if (!dt.Columns.Contains(XCol(x))) dt.Columns.Add(XCol(x), typeof(string));

            int maxSample = 0;
            foreach (DataRow s in std.Rows)
            {
                string key = s["STDCD"] + "|" + s["STDPART"] + "|" + s["PRCDETAIL"];
                List<DataRow> saved = new List<DataRow>();   // 저장 순서 = 시료 순서
                foreach (DataRow v in values.Rows)
                {
                    if (v["STDCD"] + "|" + v["STDPART"] + "|" + v["PRCDETAIL"] == key) saved.Add(v);
                }
                bool isLR = s["LRYN"].ToString() == "Y";

                decimal ss;
                decimal.TryParse(s["SAMPLESIZE"].ToString(), out ss);
                maxSample = Math.Max(maxSample, Math.Min((int)ss, PRC_MAXSAMPLE));   // 육안 항목도 시료마다 OK/NG

                // 2026-11-26 육안(OK/NG) 항목인데 이 검사일시에 저장한 값이 없으면 시료 칸에 OK 를 미리 넣음
                bool okDefault = s["STDCHKTP"].ToString() != "02" && saved.Count == 0 && s["TQMRSTKEY"].ToString() == "";
                int nOk = Math.Min((int)ss, PRC_MAXSAMPLE);

                DataRow L = dt.NewRow();
                foreach (DataColumn c in std.Columns) L[c.ColumnName] = s[c].ToString();
                L["ROWTP"] = "L";
                L["SIDE"] = isLR ? "L" : "";
                for (int x = 1; x <= PRC_MAXSAMPLE; x++) L[XCol(x)] = okDefault ? (x <= nOk ? "OK" : "") : (x <= saved.Count ? saved[x - 1]["VALUE"].ToString() : "");
                dt.Rows.Add(L);

                if (isLR)
                {
                    DataRow R = dt.NewRow();
                    foreach (DataColumn c in std.Columns) R[c.ColumnName] = s[c].ToString();
                    // 항목 정보는 L 줄과 같게 둔다: 합쳐진 칸(PRC_MERGE_FIELDS)이 R 줄 값을 보여주므로 비우면 빈칸으로 보임
                    R["ROWTP"] = "R";
                    R["SIDE"] = "R";
                    for (int x = 1; x <= PRC_MAXSAMPLE; x++) R[XCol(x)] = okDefault ? (x <= nOk ? "OK" : "") : (x <= saved.Count ? saved[x - 1]["VALUE2"].ToString() : "");
                    dt.Rows.Add(R);
                }
            }

            if (POPUP_A13.Visibility == Visibility.Visible) PANEL_A13.Close();   // 줄이 바뀌므로 숫자 입력 팝업 닫기
            NoSort(GRID_G10);   // L·R 줄 순서·병합이 깨지지 않게 정렬 끄기
            PrcApplyMerge();
            _prcJudging = true;
            MODEL_G10.SetData(dt);
            for (int i = 0; i < MODEL_G10.Rows.Count; i++)
            {
                if (MODEL_G10.GetText(i, "ROWTP") != "L") continue;
                if (MODEL_G10.GetText(i, "STDCHKTP") != "02" && MODEL_G10.GetText(i, "TQMRSTKEY") == "")
                    PrcJudgeItem(i);   // OK 를 미리 넣은 육안 항목 판정 (합격)
                else if (MODEL_G10.GetText(i, "JUDGE") == "N")
                    PrcSetJudge(i, "N");   // 불합격 항목 빨간 글자
            }
            _prcJudging = false;

            // 시료 칸은 가장 큰 시료수까지만 보임
            for (int x = 1; x <= PRC_MAXSAMPLE; x++)
            {
                GRID_G10.Columns[XCol(x)].Visible = x <= Math.Max(maxSample, 1);
            }
        }

        //비가동 탭 목록 (LIST_INPUT 은 입력 중인 사용량을 지우므로 따로 조회)
        private void NonList()
        {
            ItsMaria.Set("TML2010_R01", "LIST_NON");
            ItsMaria.AddModel(MODEL_S1);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            MODEL_G4.SetData(ds.Tables[0]);
        }
        /***************************************************************************************************************************************************************/
        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            //팝업이 Collapsed 로 시작해서 템플릿을 먼저 만들어야 제목이 들어간다
            POPUP_A1.ApplyTemplate();
            POPUP_A2.ApplyTemplate();
            POPUP_A3.ApplyTemplate();
            POPUP_A4.ApplyTemplate();
            POPUP_A11.ApplyTemplate();

            SetTMLPOPTitle(POPUP_A1, "생산품목선택");
            SetTMLPOPTitle(POPUP_A2, "불량등록");
            SetTMLPOPTitle(POPUP_A3, "비가동등록");
            SetTMLPOPTitle(POPUP_A4, "작업자선택");
            SetTMLPOPTitle(POPUP_A11, "공정이동표 발행");

            MODEL_B1.SetValue("WORKSDAY", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_B1.SetValue("WORKEDAY", DateTime.Now.ToString("yyyy-MM-dd"));

            TXT_SCANLOT.SetFocus();
        }
        /***************************************************************************************************************************************************************/
        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName.StartsWith("KEY_"))
            {   // 숫자 입력 팝업(POPUP_A13) 버튼
                KeyPadPress(commandName.Substring(4));
                return;
            }

            if (commandName == "SCAN_LOT")
            {
                // 투입로트 스캔
                if (MODEL_S1.GetText("SCANLOT") == "")
                {
                    return;
                }

                ItsMaria.Set("TML2010_R01", "SCAN_LOT");

                ItsMaria.AddModel(MODEL_S1);

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    MODEL_S1.SetValue("SCANLOT", "");
                    TXT_SCANLOT.SetFocus();
                    return;
                }

                //투입품목이 이 라인 생산품목의 BOM 에 없음 → 알림 후 기본 작업장·공정으로 변경
                if (ItsData.GetText(ds.Tables[0], 0, "RESULT") == "NO_BOM")
                {
                    chgLinecd = ItsData.GetText(ds.Tables[0], 0, "LINECD");
                    chgPrccd = ItsData.GetText(ds.Tables[0], 0, "PRCCD");
                    ShowMessageBox("CHANGE_PRC", ItsData.GetText(ds.Tables[0], 0, "MSG"));
                    return;
                }

                MODEL_A1.InitData();
                MODEL_A1.SetData(ds.Tables[0]);
                MODEL_G5.SetData(ds.Tables[0]);

                if (MODEL_G5.Rows.Count == 0)
                {
                    ShowMessageBox("", "생산할 수 있는 품목이 없습니다.");
                    MODEL_S1.SetValue("SCANLOT", "");
                    TXT_SCANLOT.SetFocus();
                    return;
                }

                if (MODEL_G5.Rows.Count > 1)
                {   // 생산품이 여러개면 팝업오픈
                    PANEL_A1.Show();
                    return;
                }
                else {
                    // 생산품이 하나면 자동선택
                    EventCommand("SEL_ITEM");
                }

                
            }
            else if (commandName == "SEL_ITEM")
            {   // 생산품목 선택
                int row = MODEL_G5.Rows.Count == 1 ? 0 : MODEL_G5.CurrentIndex;
                if (MODEL_G5.GetText(row, "ITEMID") == "")
                {
                    ShowMessageBox("", "생산할 품목을 선택하세요.");
                    return;
                }

                MODEL_S1.SetValue("ITEMID", MODEL_G5.GetText(row, "ITEMID"));
                MODEL_S1.SetValue("ITEMCD", MODEL_G5.GetText(row, "ITEMCD"));
                MODEL_S1.SetValue("ITEMNM", MODEL_G5.GetText(row, "ITEMNM"));
                MODEL_S1.SetValue("ITEMSPEC", MODEL_G5.GetText(row, "ITEMSPEC"));
                PANEL_A1.Close();

                // 라인 생산품 저장
                ItsMaria.Set("TML2010_R01", "SET_LINEITEM");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 스캔한 로트 투입등록
                EventCommand("ADD_INPUT");
            }
            else if (commandName == "ADD_INPUT")
            {   // 투입로트 등록
                ItsMaria.Set("TML2010_R01", "ADD_INPUT");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_S1.SetValue("SCANLOT", "");
                EventCommand("LIST_INPUT");
            }
            else if (commandName == "LIST_INPUT")
            {   // 투입로트 조회
                ItsMaria.Set("TML2010_R01", "LIST_INPUT");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.SetData(ds.Tables[0]);

                // 라인 생산품 (없으면 빈값)
                MODEL_S1.SetValue("ITEMID", ItsData.GetText(ds.Tables[1], 0, "ITEMID"));
                MODEL_S1.SetValue("ITEMCD", ItsData.GetText(ds.Tables[1], 0, "ITEMCD"));
                MODEL_S1.SetValue("ITEMNM", ItsData.GetText(ds.Tables[1], 0, "ITEMNM"));
                MODEL_S1.SetValue("ITEMSPEC", ItsData.GetText(ds.Tables[1], 0, "ITEMSPEC"));
                MODEL_S1.SetValue("PLANQTY_DAY", ItsData.GetText(ds.Tables[1], 0, "PLANQTY_DAY"));
                MODEL_S1.SetValue("PLANQTY_NIGHT", ItsData.GetText(ds.Tables[1], 0, "PLANQTY_NIGHT"));

                // 라인 작업자
                MODEL_G2.SetData(ds.Tables[2]);

                // 라인 불량 목록, 불량수량 합계
                MODEL_G3.SetData(ds.Tables[3]);
                MODEL_B1.SetValue("BADQTY", decimal.Parse(ItsData.GetText(ds.Tables[4], 0, "BADQTY")));
                CalcGoodQty();

                // 라인 비가동 목록
                MODEL_G4.SetData(ds.Tables[5]);
                TXT_SCANLOT.SetFocus();
            }
            else if (commandName == "DEL_INPUT")
            {
                ShowMessageBox(commandName, "투입을 취소하시겠습니까?");
                return;
            }
            else if (commandName == "WORK_DONE")
            {
                ShowMessageBox(commandName, "작업을 완료하시겠습니까?");
                return;
            }
            else if (commandName == "POP_BAD")
            {   // 불량등록 팝업
                if (MODEL_S1.GetText("LINECD") == "" || MODEL_S1.GetText("PRCCD") == "" || MODEL_S1.GetText("EQMCD") == "")
                {
                    ShowMessageBox("", "생산작업장, 생산공정, 생산라인을 선택하세요.");
                    return;
                }

                MODEL_A2.InitData();

                //공장은 2공장(07) 고정 → 대분류, 중분류, 불량코드를 공장으로 필터
                MODEL_A2.SetValue("FACTORYCD", "07");
                MODEL_A2.SetRef01("BADTP1", "07");
                MODEL_A2.SetRef01("BADTP2", "07");
                MODEL_A2.SetRef01("BADCD", "07");
                MODEL_A2.SetRef02("BADCD", "");
                MODEL_A2.SetRef03("BADCD", "");
                PANEL_A2.Show();
            }
            else if (commandName == "SAVE_BAD")
            {   // 라인 불량정보 저장
                ItsMaria.Set("TML2010_R01", "SAVE_LINEBAD");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddModel(MODEL_A2);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 불량 탭, 불량수량만 갱신 (LIST_INPUT 을 다시 부르면 입력 중인 사용량이 지워짐)
                MODEL_G3.SetData(ds.Tables[0]);
                MODEL_B1.SetValue("BADQTY", decimal.Parse(ItsData.GetText(ds.Tables[1], 0, "BADQTY")));
                CalcGoodQty();
                PANEL_A2.Close();
            }
            else if (commandName == "DEL_BAD")
            {
                ShowMessageBox(commandName, "불량을 삭제하시겠습니까?");
                return;
            }
            else if (commandName == "POP_NON")
            {   // 비가동등록 팝업
                if (MODEL_S1.GetText("LINECD") == "" || MODEL_S1.GetText("PRCCD") == "" || MODEL_S1.GetText("EQMCD") == "")
                {
                    ShowMessageBox("", "생산작업장, 생산공정, 생산라인을 선택하세요.");
                    return;
                }

                // 라인에 진행 중인 비가동이 있는지 확인
                ItsMaria.Set("TML2010_R01", "CHK_NON");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A3.InitData();
                NontpButton();
                NONCD_LIST.Clear();

                if (ItsData.GetText(ds.Tables[0], 0, "CHK") == "Y")
                {   // 진행 중 → 시작 정보 표시, 종료만 가능 (종료시간은 지금). 코드가 정해졌으면 유형·코드 잠금
                    string nonstime = ItsData.GetText(ds.Tables[0], 0, "NONSTIME");
                    MODEL_A3.SetValue("NONSDAY", nonstime.Substring(0, 10));
                    MODEL_A3.SetValue("NONSTIME", nonstime.Substring(11, 8));
                    MODEL_A3.SetValue("NONEDAY", DateTime.Now.ToString("yyyy-MM-dd"));
                    MODEL_A3.SetValue("NONETIME", DateTime.Now.ToString("HH:mm:ss"));
                    MODEL_A3.SetValue("REMARK", ItsData.GetText(ds.Tables[0], 0, "REMARK"));

                    NONTP_LIST.Value = ItsData.GetText(ds.Tables[0], 0, "NONTP"); // 값이 바뀌면 NONTP_LIST 명령이 와서 코드 목록을 채움
                    NONCD_LIST.Value = ItsData.GetText(ds.Tables[0], 0, "NONCD");

                    bool hasNoncd = ItsData.GetText(ds.Tables[0], 0, "NONCD") != "";
                    NONTP_LIST.IsEnabled = !hasNoncd;
                    NONCD_LIST.IsEnabled = !hasNoncd;
                    BTN_NONSTART.Visibility = Visibility.Hidden;
                    BTN_NONEND.Visibility = Visibility.Visible;
                }
                else
                {   // 새 비가동 → 시작시간은 지금
                    MODEL_A3.SetValue("NONSDAY", DateTime.Now.ToString("yyyy-MM-dd"));
                    MODEL_A3.SetValue("NONSTIME", DateTime.Now.ToString("HH:mm:ss"));

                    NONTP_LIST.IsEnabled = true;
                    NONCD_LIST.IsEnabled = true;
                    BTN_NONSTART.Visibility = Visibility.Visible;
                    BTN_NONEND.Visibility = Visibility.Hidden;
                }
                PANEL_A3.Show();
            }
            else if (commandName == "NONTP_LIST")
            {   // 비가동 유형 선택 → 코드 목록
                NoncdButton();
            }
            else if (commandName == "START_NON")
            {   // 비가동 시작
                ItsMaria.Set("TML2010_R01", "START_NON");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddOne("NONSTIME", MODEL_A3.GetText("NONSDAY") + " " + MODEL_A3.GetText("NONSTIME"));
                ItsMaria.AddOne("NONCD", NONCD_LIST.Value);
                ItsMaria.AddOne("REMARK", MODEL_A3.GetText("REMARK"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A3.Close();
                NonList();
                ShowMessageBox("", "비가동이 시작되었습니다.");
            }
            else if (commandName == "END_NON")
            {   // 비가동 종료
                ItsMaria.Set("TML2010_R01", "END_NON");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddOne("NONETIME", MODEL_A3.GetText("NONEDAY") + " " + MODEL_A3.GetText("NONETIME"));
                ItsMaria.AddOne("NONCD", NONCD_LIST.Value);
                ItsMaria.AddOne("REMARK", MODEL_A3.GetText("REMARK"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A3.Close();
                NonList();
                ShowMessageBox("", "비가동이 종료되었습니다.");
            }
            else if (commandName == "POP_CHK")
            {   // 설비 일상점검 팝업 (작업장·공정·라인은 메인에서 선택한 값)
                if (MODEL_S1.GetText("LINECD") == "" || MODEL_S1.GetText("PRCCD") == "" || MODEL_S1.GetText("EQMCD") == "")
                {
                    ShowMessageBox("", "생산작업장, 생산공정, 생산라인을 선택하세요.");
                    return;
                }

                ItsMaria.Set("TML2010_R01", "LIST_FANO");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    ShowMessageBox("", "선택한 라인에 매칭된 설비가 없습니다.");
                    return;
                }

                MODEL_A5.InitData();
                MODEL_A5.SetRef01("PRCCD", MODEL_S1.GetText("LINECD"));
                MODEL_A5.SetRef01("EQMCD", MODEL_S1.GetText("LINECD"));
                MODEL_A5.SetRef02("EQMCD", MODEL_S1.GetText("PRCCD"));
                MODEL_A5.SetValue("LINECD", MODEL_S1.GetText("LINECD"));
                MODEL_A5.SetValue("PRCCD", MODEL_S1.GetText("PRCCD"));
                MODEL_A5.SetValue("EQMCD", MODEL_S1.GetText("EQMCD"));
                MODEL_A5.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A5.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_G7.InitData();
                MODEL_G8.InitData();

                FANO_LIST.Clear();
                FANO_LIST.ButtonWidth = "230";
                FANO_LIST.ButtonHeight = "70";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    FANO_LIST.AddButton(ItsData.GetText(ds.Tables[0], i, "FANO") + "\n" + ItsData.GetText(ds.Tables[0], i, "EQMNM"), ItsData.GetText(ds.Tables[0], i, "FANO"));
                }

                PANEL_A5.Show();

                // 2026-11-26 설비 버튼 글자 크게·굵게 (ButtonList 기본 글자가 작아 잘 안 보임)
                FANO_LIST.UpdateLayout();
                foreach (ITSLIB.Button fanoBtn in ItsElement.FindChild<ITSLIB.Button>(FANO_LIST))
                {
                    fanoBtn.SetFontSize = 17;
                    fanoBtn.FontWeight = FontWeights.Bold;
                }
            }
            else if (commandName == "POP_PRCTEST")
            {   // 자주검사 등록 팝업 (작업장·공정·라인은 메인에서 선택한 값)
                if (MODEL_S1.GetText("LINECD") == "" || MODEL_S1.GetText("PRCCD") == "" || MODEL_S1.GetText("EQMCD") == "")
                {
                    ShowMessageBox("", "생산작업장, 생산공정, 생산라인을 선택하세요.");
                    return;
                }

                MODEL_A10.InitData();
                MODEL_A10.SetRef01("PRCCD", MODEL_S1.GetText("LINECD"));
                MODEL_A10.SetRef01("EQMCD", MODEL_S1.GetText("LINECD"));
                MODEL_A10.SetRef02("EQMCD", MODEL_S1.GetText("PRCCD"));
                MODEL_A10.SetValue("LINECD", MODEL_S1.GetText("LINECD"));
                MODEL_A10.SetValue("PRCCD", MODEL_S1.GetText("PRCCD"));
                MODEL_A10.SetValue("EQMCD", MODEL_S1.GetText("EQMCD"));
                MODEL_A10.SetValue("TQMDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A10.SetValue("TQMTIME", DateTime.Now.ToString("HH:mm"));
                MODEL_G10.InitData();

                // 검사항목 조회가 오류(생산품·자주검사 기준 없음 등)면 메시지만 띄우고 팝업은 열지 않음
                EventCommand("SEARCH_STD");
                if (ItsMaria.IsError)
                {
                    return;
                }

                PANEL_A10.Show();
            }
            else if (commandName == "SEARCH_STD")
            {   // 라인 생산품, 사용중인 자주검사 리비전 검사항목 중 이번 검사주기에 할 항목 + 이 검사일시에 저장한 검사값
                string tqmtime = MODEL_A10.GetText("TQMTIME");

                MODEL_A10.SetValue("ITEMID", "");
                MODEL_A10.SetValue("ITEMCD", "");
                MODEL_A10.SetValue("ITEMNM", "");
                MODEL_A10.SetValue("ITEMSPEC", "");
                MODEL_G10.InitData();

                ItsMaria.Set("TAL2001_R01", "LIST_STD");
                ItsMaria.AddOne("LINECD", MODEL_A10.GetText("LINECD"));
                ItsMaria.AddOne("PRCCD", MODEL_A10.GetText("PRCCD"));
                ItsMaria.AddOne("EQMCD", MODEL_A10.GetText("EQMCD"));
                ItsMaria.AddOne("TQMDATE", MODEL_A10.GetText("TQMDATE"));
                ItsMaria.AddOne("TQMTIME", tqmtime.Length > 5 ? tqmtime.Substring(0, 5) : tqmtime); // 프로시저는 HH:mm
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A10.SetValue("ITEMID", ItsData.GetText(ds.Tables[0], 0, "ITEMID"));
                MODEL_A10.SetValue("ITEMCD", ItsData.GetText(ds.Tables[0], 0, "ITEMCD"));
                MODEL_A10.SetValue("ITEMNM", ItsData.GetText(ds.Tables[0], 0, "ITEMNM"));
                MODEL_A10.SetValue("ITEMSPEC", ItsData.GetText(ds.Tables[0], 0, "ITEMSPEC"));
                MODEL_A10.SetValue("REVNUM", ds.Tables[0].Columns.Contains("REVNUM") ? ItsData.GetText(ds.Tables[0], 0, "REVNUM") : "");   // 2026-11-26 자주검사 리비전번호

                PrcBindRows(ds.Tables[1], ds.Tables.Count > 2 ? ds.Tables[2] : ds.Tables[1].Clone());
            }
            else if (commandName == "SAVE_PRCTEST")
            {   // 입력한 항목 전체 저장 (시료 칸에 값을 하나라도 넣은 항목, 육안은 OK/NG). 항목마다 SAVE_RST
                (GRID_G10.View as TableView).PostEditor();   // 입력 중인 칸 확정
                string tqmtime = MODEL_A10.GetText("TQMTIME");

                List<int> targets = new List<int>();
                for (int r = 0; r < MODEL_G10.Rows.Count; r++)
                {
                    if (MODEL_G10.GetText(r, "ROWTP") != "L") continue;

                    // 측정·육안 모두 시료마다 값 (육안은 OK/NG, 2026-11-26)
                    bool isLR = MODEL_G10.GetText(r, "LRYN") == "Y" && r + 1 < MODEL_G10.Rows.Count;
                    int n = PrcSample(r);
                    bool any = false, empty = false;
                    for (int x = 1; x <= n; x++)
                    {
                        string vl = MODEL_G10.GetText(r, XCol(x)).Trim();
                        string vr = isLR ? MODEL_G10.GetText(r + 1, XCol(x)).Trim() : "";
                        if (vl != "" || vr != "") any = true;
                        if (vl == "" || (isLR && vr == "")) empty = true;
                    }
                    if (!any) continue;   // 입력 안 한 항목은 저장 안 함

                    if (empty)
                    {
                        string part = MODEL_G10.GetText(r, "STDPART");
                        ShowMessageBox("", (MODEL_G10.GetText(r, "STDCHKTP") == "02" ? "검사값을" : "OK/NG 를") + " 시료수만큼 모두 입력하세요." + (isLR ? " (L·R 둘 다)" : "")
                            + "\n - 검사항목 : " + MODEL_G10.GetText(r, "STDNM") + (part != "" ? " / " + part : ""));
                        MODEL_G10.SelectRow(r);
                        return;
                    }
                    PrcJudgeItem(r);
                    targets.Add(r);
                }

                if (targets.Count == 0)
                {
                    ShowMessageBox("", "저장할 검사 결과가 없습니다.");
                    return;
                }

                for (int t = 0; t < targets.Count; t++)
                {
                    int stdRow = targets[t];
                    bool isLR = MODEL_G10.GetText(stdRow, "LRYN") == "Y";

                    ItsMaria.Set("TAL2001_R01", "SAVE_RST");
                    ItsMaria.AddOne("LINECD", MODEL_A10.GetText("LINECD"));
                    ItsMaria.AddOne("PRCCD", MODEL_A10.GetText("PRCCD"));
                    ItsMaria.AddOne("EQMCD", MODEL_A10.GetText("EQMCD"));
                    ItsMaria.AddOne("ITEMID", MODEL_A10.GetText("ITEMID"));
                    ItsMaria.AddOne("TQMDATE", MODEL_A10.GetText("TQMDATE"));
                    ItsMaria.AddOne("TQMTIME", tqmtime.Length > 5 ? tqmtime.Substring(0, 5) : tqmtime);
                    ItsMaria.AddOne("EMPCD", MODEL_A10.GetText("EMPCD"));
                    ItsMaria.AddOne("REVCD", MODEL_G10.GetText(stdRow, "REVCD"));
                    ItsMaria.AddOne("STDCD", MODEL_G10.GetText(stdRow, "STDCD"));
                    ItsMaria.AddOne("STDPART", MODEL_G10.GetText(stdRow, "STDPART"));
                    ItsMaria.AddOne("PRCDETAIL", MODEL_G10.GetText(stdRow, "PRCDETAIL"));
                    ItsMaria.AddOne("SAMPLESIZE", ((int)MODEL_G10.GetDecimal(stdRow, "SAMPLESIZE")).ToString());
                    ItsMaria.AddOne("JUDGE", MODEL_G10.GetText(stdRow, "JUDGE"));
                    int ns = PrcSample(stdRow);
                    for (int x = 1; x <= ns; x++)
                    {
                        ItsMaria.AddList("SEQ_LIST", x.ToString());
                        ItsMaria.AddList("VALUE_LIST", MODEL_G10.GetText(stdRow, XCol(x)).Trim());
                        ItsMaria.AddList("VALUE2_LIST", isLR ? MODEL_G10.GetText(stdRow + 1, XCol(x)).Trim() : "");
                    }
                    ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ShowMessageBox("", "[" + MODEL_G10.GetText(stdRow, "STDNM") + "] 저장 중 오류\n" + ItsMaria.ErrMessage
                            + (t > 0 ? "\n\n앞의 " + t + "개 항목은 저장되었습니다." : ""));
                        EventCommand("SEARCH_STD");
                        return;
                    }
                }

                ShowMessageBox("", targets.Count + "개 검사항목을 저장했습니다.");
                EventCommand("SEARCH_STD");   // 이 검사일시에 저장한 항목·검사값을 다시 보여줌
            }
            else if (commandName == "FANO_LIST" || commandName == "SEARCH_CHK")
            {   // 설비 선택·조회 → 일상점검 실적 목록
                if (FANO_LIST.Value == "")
                {
                    ShowMessageBox("", "설비를 선택하세요.");
                    return;
                }

                ItsMaria.Set("TAL0001_R05", "LIST_CHKRSTEQM");
                ItsMaria.AddOne("EQMCD", FANO_LIST.Value);
                ItsMaria.AddOne("SDATE", MODEL_A5.GetText("SDATE"));
                ItsMaria.AddOne("EDATE", MODEL_A5.GetText("EDATE"));
                ItsMaria.AddOne("EMPCD", MODEL_A5.GetText("EMPCD"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G8.InitData();
                MODEL_G7.SetData(ds.Tables[0]);
            }
            else if (commandName == "POP_CHKADD")
            {   // 점검 등록 팝업: 설비그룹·설비의 최신 승인 일상점검 항목
                if (FANO_LIST.Value == "")
                {
                    ShowMessageBox("", "설비를 선택하세요.");
                    return;
                }

                ItsMaria.Set("TAL0001_R05", "LIST_PLAN_ITEM");
                ItsMaria.AddOne("EQMCD", FANO_LIST.Value);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A6.InitData();
                MODEL_A6.SetValue("BASEDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A6.SetValue("DATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A6.SetValue("BASETIME", DateTime.Now.ToString("HH:mm"));
                MODEL_A6.SetValue("CHKRSTKEY", "");
                if (POPUP_A13.Visibility == Visibility.Visible) PANEL_A13.Close();   // 줄이 바뀌므로 숫자 입력 팝업 닫기
                NoSort(GRID_G9);   // 값을 넣을 때 줄이 정렬 위치로 옮겨 가지 않게
                MODEL_G9.SetData(ds.Tables[0]);
                ChkDefaultOk();    // 새 점검: OK/NG 항목은 OK 미리 입력
                JudgeAll(MODEL_G9);
                MODEL_A6.SetValue("REVTEXT", ds.Tables[0].Columns.Contains("REVTEXT") ? ItsData.GetText(ds.Tables[0], 0, "REVTEXT") : "");   // 2026-11-26 계획 리비전번호
                PANEL_A6.Show();
            }
            else if (commandName == "POP_CHKEDIT")
            {   // 점검 수정 팝업: 선택한 실적
                if (MODEL_G7.Rows.Count == 0 || MODEL_G7.CurrentIndex < 0)
                {
                    ShowMessageBox("", "수정할 점검 실적을 선택하세요.");
                    return;
                }

                string chkrstkey = MODEL_G7.GetText(MODEL_G7.CurrentIndex, "CHKRSTKEY");
                ItsMaria.Set("TAL0001_R05", "LIST_CHKRSTEQM_EDIT");
                ItsMaria.AddOne("CHKRSTKEY", chkrstkey);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A6.InitData();
                MODEL_A6.SetValue("BASEDATE", ItsData.GetText(ds.Tables[0], 0, "BASEDATE"));
                MODEL_A6.SetValue("DATE", ItsData.GetText(ds.Tables[0], 0, "DATE"));
                MODEL_A6.SetValue("BASETIME", ItsData.GetText(ds.Tables[0], 0, "TIME"));
                MODEL_A6.SetValue("EMPCD", ItsData.GetText(ds.Tables[0], 0, "EMPCD"));
                MODEL_A6.SetValue("CHKRSTKEY", chkrstkey);
                MODEL_A6.SetValue("REVTEXT", ds.Tables[0].Columns.Contains("REVTEXT") ? ItsData.GetText(ds.Tables[0], 0, "REVTEXT") : "");   // 2026-11-26 계획 리비전번호
                if (POPUP_A13.Visibility == Visibility.Visible) PANEL_A13.Close();   // 줄이 바뀌므로 숫자 입력 팝업 닫기
                NoSort(GRID_G9);   // 값을 넣을 때 줄이 정렬 위치로 옮겨 가지 않게
                MODEL_G9.SetData(ds.Tables[0]);
                JudgeAll(MODEL_G9);
                PANEL_A6.Show();
            }
            else if (commandName == "INPUT_CHKVAL")
            {   // 점검값 입력: 점검값구분이 숫자(01)면 숫자 입력, 아니면 OK/NG
                if (MODEL_G9.GetText(MODEL_G9.CurrentIndex, "CHKVALTP") == "01")
                {
                    MODEL_A7.InitData();
                    MODEL_A7.SetValue("CHKVALUE", MODEL_G9.GetText(MODEL_G9.CurrentIndex, "CHKVALUE"));
                    PANEL_A7.Show();
                }
                else
                {
                    PANEL_A8.Show();
                }
            }
            else if (commandName == "SET_CHKVAL")
            {   // 숫자 점검값 반영
                MODEL_G9.SetValue(MODEL_G9.CurrentIndex, "CHKVALUE", MODEL_A7.GetText("CHKVALUE"));
                JudgeRow(MODEL_G9, MODEL_G9.CurrentIndex);
                PANEL_A7.Close();
            }
            else if (commandName == "CHKVAL_OK" || commandName == "CHKVAL_NG")
            {   // OK/NG 점검값 반영
                MODEL_G9.SetValue(MODEL_G9.CurrentIndex, "CHKVALUE", commandName == "CHKVAL_OK" ? "OK" : "NG");
                JudgeRow(MODEL_G9, MODEL_G9.CurrentIndex);
                PANEL_A8.Close();
            }
            else if (commandName == "SAVE_CHK")
            {   // 일상점검 저장 (점검키가 없으면 등록, 있으면 수정)
                bool isAdd = MODEL_A6.GetText("CHKRSTKEY") == "";
                string basetime = MODEL_A6.GetText("BASETIME");

                ItsMaria.Set("TAL0001_R05", isAdd ? "ADD_CHKRSTEQM" : "SAVE_CHKRSTEQM");
                ItsMaria.AddOne("EQMCD", FANO_LIST.Value);
                ItsMaria.AddOne("CHKRSTKEY", MODEL_A6.GetText("CHKRSTKEY"));
                ItsMaria.AddOne("BASEDATE", MODEL_A6.GetText("BASEDATE"));
                ItsMaria.AddOne("DATE", MODEL_A6.GetText("DATE"));
                ItsMaria.AddOne("BASETIME", basetime.Length > 5 ? basetime.Substring(0, 5) : basetime); // 프로시저가 HH:mm 에 :00 을 붙임
                ItsMaria.AddOne("EMPCD", MODEL_A6.GetText("EMPCD"));
                if (isAdd && MODEL_G9.Rows.Count > 0)
                {
                    ItsMaria.AddOne("REVCD", MODEL_G9.GetText(0, "REVCD"));
                    ItsMaria.AddOne("GRPREVCD", MODEL_G9.GetText(0, "GRPREVCD"));
                }
                ItsMaria.AddListGridAll("PLANTP_LIST", MODEL_G9, "PLANTP");
                ItsMaria.AddListGridAll("CHKKNDCD_LIST", MODEL_G9, "CHKKNDCD");
                ItsMaria.AddListGridAll("CHKVALUE_LIST", MODEL_G9, "CHKVALUE");
                ItsMaria.AddListGridAll("REMARK_LIST", MODEL_G9, "REMARK");
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A6.Close();
                EventCommand("SEARCH_CHK");
                ShowMessageBox("", "저장되었습니다.");
            }
            else if (commandName == "DEL_CHK")
            {   // 일상점검 삭제 확인
                if (MODEL_G7.Rows.Count == 0 || MODEL_G7.CurrentIndex < 0)
                {
                    ShowMessageBox("", "삭제할 점검 실적을 선택하세요.");
                    return;
                }

                ShowMessageBox(commandName, "선택한 점검 실적을 삭제하시겠습니까?");
            }
            else if (commandName == "POP_CHKERR")
            {   // 문제점/조치사항 팝업
                if (MODEL_G7.Rows.Count == 0 || MODEL_G7.CurrentIndex < 0)
                {
                    ShowMessageBox("", "점검 실적을 선택하세요.");
                    return;
                }

                ItsMaria.Set("TAL0001_R05", "LIST_ERR");
                ItsMaria.AddOne("CHKRSTKEY", MODEL_G7.GetText(MODEL_G7.CurrentIndex, "CHKRSTKEY"));
                ItsMaria.AddOne("EQMCD", FANO_LIST.Value);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A9.InitData();
                MODEL_A9.SetValue("PROBLEM", ItsData.GetText(ds.Tables[0], 0, "PROBLEM"));
                MODEL_A9.SetValue("SOLUTION", ItsData.GetText(ds.Tables[0], 0, "SOLUTION"));
                PANEL_A9.Show();
            }
            else if (commandName == "SAVE_CHKERR")
            {   // 문제점/조치사항 저장
                ItsMaria.Set("TAL0001_R05", "SAVE_ERR");
                ItsMaria.AddOne("CHKRSTKEY", MODEL_G7.GetText(MODEL_G7.CurrentIndex, "CHKRSTKEY"));
                ItsMaria.AddOne("EQMCD", FANO_LIST.Value);
                ItsMaria.AddOne("PROBLEM", MODEL_A9.GetText("PROBLEM"));
                ItsMaria.AddOne("SOLUTION", MODEL_A9.GetText("SOLUTION"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A9.Close();
                ShowMessageBox("", "저장되었습니다.");
            }
            else if (commandName == "POP_EMP")
            {   // 작업자 선택 팝업
                if (MODEL_S1.GetText("LINECD") == "" || MODEL_S1.GetText("PRCCD") == "" || MODEL_S1.GetText("EQMCD") == "")
                {
                    ShowMessageBox("", "생산작업장, 생산공정, 생산라인을 선택하세요.");
                    return;
                }

                ItsMaria.Set("TML2010_R01", "LIST_EMP");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G6.SetData(ds.Tables[0]);
                PANEL_A4.Show();
            }
            else if (commandName == "SAVE_EMP")
            {   // 라인 작업자 저장 (체크한 사원)
                ItsMaria.Set("TML2010_R01", "SAVE_LINEEMP");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddListGrid("EMPCD_LIST", MODEL_G6, "EMPCD");
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A4.Close();
                EventCommand("LIST_INPUT");
            }
            else if (commandName == "POP_MOVE")
            {   // 공정이동표 발행 팝업 (작업장·공정은 메인에서 선택한 값)
                if (MODEL_S1.GetText("LINECD") == "" || MODEL_S1.GetText("PRCCD") == "")
                {
                    ShowMessageBox("", "생산작업장, 생산공정을 선택하세요.");
                    return;
                }

                // 라벨프린터·라벨출력 열·라벨번호 열·라벨발행 버튼은 출하검사공정일 때만
                bool isShip = MODEL_S1.GetText("PRCCD") == SHIP_PRCCD;
                CMB_LABELPRINT.Visibility = isShip ? Visibility.Visible : Visibility.Collapsed;
                BTN_LABELPRINT.Visibility = isShip ? Visibility.Visible : Visibility.Collapsed;
                COL_LABELBTN.Visible = isShip;
                COL_LABELKEY.Visible = isShip;

                MODEL_A11.InitData();
                MODEL_A11.SetValue("SDATE", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));
                MODEL_A11.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A11.SetValue("PRINTCNT", 1);
                MODEL_A11.SetValue("PRINT", ItsPrinter.BarcodePrintName);
                MODEL_A11.SetValue("LABELPRINT", ItsPrinter.BarcodePrintName);
                MODEL_G12.InitData();

                EventCommand("SEARCH_MOVE");
                PANEL_A11.Show();
            }
            else if (commandName == "SEARCH_MOVE")
            {   // 생산일자 기간 실적로트 (실적 조회 체크 안 하면 생산 입고창고에 현재고가 있는 로트만)
                TXT_MOVE_TITLE.Text = "공정이동표 인쇄 (생산일자 : " + MODEL_A11.GetText("SDATE") + " ~ " + MODEL_A11.GetText("EDATE") + ")";

                ItsMaria.Set("TML2010_R01", "LIST_MOVE");
                ItsMaria.AddOne("LINECD", MODEL_S1.GetText("LINECD"));
                ItsMaria.AddOne("PRCCD", MODEL_S1.GetText("PRCCD"));
                ItsMaria.AddOne("SDATE", MODEL_A11.GetText("SDATE"));
                ItsMaria.AddOne("EDATE", MODEL_A11.GetText("EDATE"));
                ItsMaria.AddOne("ALLYN", MODEL_A11.GetYn("ALLYN"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G12.SetData(ds.Tables[0]);
            }
            else if (commandName == "MOVE_UP" || commandName == "MOVE_DOWN")
            {   // 선택한 행을 위·아래로 (체크 상태도 같이 옮김)
                int row = MODEL_G12.CurrentIndex;
                int target = commandName == "MOVE_UP" ? row - 1 : row + 1;
                if (row < 0 || target < 0 || target >= MODEL_G12.Rows.Count)
                {
                    return;
                }

                bool rowChecked = MODEL_G12.IsChecked(row);
                bool targetChecked = MODEL_G12.IsChecked(target);
                object[] rowValues = MODEL_G12.Rows[row].ItemArray;
                MODEL_G12.Rows[row].ItemArray = MODEL_G12.Rows[target].ItemArray;
                MODEL_G12.Rows[target].ItemArray = rowValues;
                MODEL_G12.SetChecked(row, targetChecked);
                MODEL_G12.SetChecked(target, rowChecked);
                MODEL_G12.SelectRow(target);
            }
            else if (commandName == "PRINT_GOOD" || commandName == "PRINT_BAD" || commandName == "PRINT_REMAIN")
            {   // 양품발행: 실적로트 양품수량, 불량발행: 실적로트 불량수량, 잔량발행: 실적로트가 사용한 자재로트의 현재고
                List<int> rows = MoveTargetRows();
                if (rows.Count == 0)
                {
                    ShowMessageBox("", "발행할 실적로트를 선택하세요.");
                    return;
                }

                int copies = (int)MODEL_A11.GetDecimal("PRINTCNT");
                if (copies < 1)
                {
                    ShowMessageBox("", "발행매수(박스 당 수량)를 1 이상 입력하세요.");
                    return;
                }

                string printer = MODEL_A11.GetText("PRINT") != "" ? MODEL_A11.GetText("PRINT") : ItsPrinter.BarcodePrintName;
                List<TMLPRINT.PRD_1> reports = new List<TMLPRINT.PRD_1>(); // 모아서 한 번에 인쇄 (인쇄작업 1개)
                int printed = 0;
                foreach (int row in rows)
                {
                    string lotKey = MODEL_G12.GetText(row, "LOTKEY");

                    if (commandName == "PRINT_REMAIN")
                    {
                        ItsMaria.Set("TML2010_R01", "LIST_REMAIN");
                        ItsMaria.AddOne("LOTKEY", lotKey);
                        DataSet ds = ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ShowMessageBox("", ItsMaria.ErrMessage);
                            return;
                        }

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (!AddMoveLot(reports, ItsData.GetText(ds.Tables[0], i, "LOTKEY"), "REMAIN", false, copies))
                            {
                                return;
                            }
                            printed++;
                        }
                    }
                    else
                    {
                        bool isBad = commandName == "PRINT_BAD";
                        if (MODEL_G12.GetDecimal(row, isBad ? "BADQTY" : "GOODQTY") <= 0)
                        {
                            continue;
                        }

                        if (!AddMoveLot(reports, lotKey, "", isBad, copies))
                        {
                            return;
                        }
                        printed++;
                    }
                }

                if (printed == 0)
                {
                    ShowMessageBox("", commandName == "PRINT_GOOD" ? "발행할 양품수량이 없습니다."
                                     : commandName == "PRINT_BAD" ? "발행할 불량수량이 없습니다."
                                     : "현재고가 남은 자재로트가 없습니다.");
                    return;
                }

                try
                {
                    TMLPRINT.PRD_1.PrintDirect(reports, printer);
                }
                catch (Exception ex)
                {
                    ShowMessageBox("", "공정이동표 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
                    return;
                }

                ShowMessageBox("", "공정이동표 " + printed + "건을 발행했습니다.");
            }
            else if (commandName == "PRINT_ALL")
            {   // 전체발행: 기능 미정 (버튼만 둠)
                ShowMessageBox("", "준비 중인 기능입니다.");
            }
            else if (commandName == "PRINT_LABEL" || commandName == "PRINT_LABEL_ROW")
            {   // 소라벨(해외 수출) 출력. 라벨출력(그리드 버튼) = 그 행, 라벨발행 = 체크한 행(없으면 선택한 행)
                // 양식은 프로시저가 정함: 매출처 단가(MSTITEM_SDV)에 MAGNA 가 있으면 PRD_2, 품목 PARTNO·INITCD 가 있으면 일반 PRD_3
                List<int> rows = new List<int>();
                if (commandName == "PRINT_LABEL_ROW")
                {
                    if (MODEL_G12.CurrentIndex >= 0) rows.Add(MODEL_G12.CurrentIndex);
                }
                else
                {
                    rows = MoveTargetRows();
                }

                if (rows.Count == 0)
                {
                    ShowMessageBox("", "라벨을 발행할 실적로트를 선택하세요.");
                    return;
                }

                int copies = (int)MODEL_A11.GetDecimal("PRINTCNT");
                if (copies < 1)
                {
                    ShowMessageBox("", "발행매수(박스 당 수량)를 1 이상 입력하세요.");
                    return;
                }

                string printer = MODEL_A11.GetText("LABELPRINT") != "" ? MODEL_A11.GetText("LABELPRINT") : ItsPrinter.BarcodePrintName;
                List<ItsReport> reports = new List<ItsReport>(); // 모아서 한 번에 인쇄 (인쇄작업 1개)
                foreach (int row in rows)
                {
                    ItsMaria.Set("TML2010_R01", "PRINT_LABEL");
                    ItsMaria.AddOne("LOTKEY", MODEL_G12.GetText(row, "LOTKEY"));
                    DataSet ds = ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ShowMessageBox("", ItsMaria.ErrMessage);
                        return;
                    }

                    // 라벨번호가 이번에 매겨졌을 수 있으니 그리드에 표시 (값을 바꾸면 행이 체크되므로 체크 상태는 되돌림)
                    bool isChecked = MODEL_G12.IsChecked(row);
                    MODEL_G12.SetValue(row, "LABELKEY", ItsData.GetText(ds.Tables[0], 0, "LABELKEY"));
                    MODEL_G12.SetChecked(row, isChecked);

                    for (int i = 0; i < copies * 2; i++)   // 소라벨은 같은 라벨 2장씩 (발행매수 × 2, 2026-11-23)
                    {
                        if (ItsData.GetText(ds.Tables[0], 0, "LABELTP") == "MAGNA")
                        {
                            reports.Add(new TMLPRINT.PRD_2(ds.Tables[0]));
                        }
                        else
                        {
                            reports.Add(new TMLPRINT.PRD_3(ds.Tables[0]));
                        }
                    }
                }

                try
                {
                    TMLPRINT.PRD_3.PrintDirect(reports, printer);
                }
                catch (Exception ex)
                {
                    ShowMessageBox("", "소라벨 출력에 실패했습니다. 라벨프린터를 확인해주세요.\n" + ex.Message);
                    return;
                }

                ShowMessageBox("", "소라벨 " + rows.Count + "건을 발행했습니다.");
            }
            else if (commandName == "CLOSE_MOVE")
            {   // 공정이동표 발행 팝업 닫기
                PANEL_A11.Close();
            }
            else if (commandName == "POP_DELRST")
            {   // 실적삭제 팝업 (작업장·공정·라인은 메인에서 선택한 값, 작업일 어제·오늘 실적)
                if (MODEL_S1.GetText("LINECD") == "" || MODEL_S1.GetText("PRCCD") == "" || MODEL_S1.GetText("EQMCD") == "")
                {
                    ShowMessageBox("", "생산작업장, 생산공정, 생산라인을 선택하세요.");
                    return;
                }

                if (!SearchDelRst()) return;
                PANEL_A12.Show();
            }
            else if (commandName == "DEL_RST")
            {   // 실적삭제 확인 (실제 삭제는 EventMessageResult)
                if (MODEL_G13.Rows.Count == 0 || MODEL_G13.CurrentIndex < 0)
                {
                    ShowMessageBox("", "삭제할 실적을 선택하세요.");
                    return;
                }

                ShowMessageBox(commandName, "실적로트 " + MODEL_G13.GetText(MODEL_G13.CurrentIndex, "LOTKEY") + " 의 생산실적을 삭제하시겠습니까?\n투입로트 재고가 되돌아가고, 실적로트(양품·불량) 재고는 지워집니다.");
            }
        }

        // 실적삭제 팝업 최근 실적 조회. 실패하면 메시지 후 false
        private bool SearchDelRst()
        {
            ItsMaria.Set("TML2010_R01", "LIST_RST");
            ItsMaria.AddModel(MODEL_S1);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return false;
            }

            MODEL_G13.SetData(ds.Tables[0]);
            return true;
        }

        // 공정이동표 발행 대상 행: 체크한 행(화면 순서대로), 체크한 행이 없으면 선택한 행
        private List<int> MoveTargetRows()
        {
            List<int> rows = new List<int>();
            for (int i = 0; i < MODEL_G12.Rows.Count; i++)
            {
                if (MODEL_G12.IsChecked(i)) rows.Add(i);
            }

            if (rows.Count == 0 && MODEL_G12.Rows.Count > 0 && MODEL_G12.CurrentIndex >= 0)
            {
                rows.Add(MODEL_G12.CurrentIndex);
            }
            return rows;
        }

        // 공정이동표 한 로트를 발행매수만큼 reports 에 추가 (양식 TMLPRINT.PRD_1, 인쇄는 모은 뒤 한 번에). printTp = "REMAIN" 이면 자재로트 현재고. 실패하면 메시지 후 false
        private bool AddMoveLot(List<TMLPRINT.PRD_1> reports, string lotKey, string printTp, bool isBad, int copies)
        {
            ItsMaria.Set("TML2010_R01", "PRINT_MOVE");
            ItsMaria.AddOne("LOTKEY", lotKey);
            ItsMaria.AddOne("PRINTTP", printTp);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return false;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                ShowMessageBox("", "공정이동표 정보가 없습니다.\n- 로트번호: " + lotKey);
                return false;
            }

            for (int i = 0; i < copies; i++)
            {
                reports.Add(new TMLPRINT.PRD_1(ds, isBad));
            }
            return true;
        }
        /***************************************************************************************************************************************************************/
        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "CHANGE_PRC")
            {   // 생산 작업장, 공정을 기본 작업장, 공정으로 자동변경
                MODEL_S1.SetValue("LINECD", chgLinecd);
                MODEL_S1.SetValue("PRCCD", chgPrccd);
                MODEL_S1.SetValue("SCANLOT", "");
                TXT_SCANLOT.SetFocus();
            }
            else if (commandName == "DEL_INPUT")
            {   // 투입로트 삭제
                ItsMaria.Set("TML2010_R01", "DEL_INPUT");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddOne("SCANLOT", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "LOTKEY"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("LIST_INPUT");
            }
            else if (commandName == "DEL_RST")
            {   // 실적삭제 (실적로트를 아직 쓰지 않았을 때만, 프로시저가 확인)
                string lotKey = MODEL_G13.GetText(MODEL_G13.CurrentIndex, "LOTKEY");

                ItsMaria.Set("TML2010_R01", "DEL_RST");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddOne("LOTKEY", lotKey);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                SearchDelRst();
                ShowMessageBox("", "생산실적이 삭제되었습니다.\n실적로트: " + lotKey);
            }
            else if (commandName == "DEL_CHK")
            {   // 일상점검 삭제
                ItsMaria.Set("TAL0001_R05", "DELETE_CHKRSTEQM");
                ItsMaria.AddOne("CHKRSTKEY", MODEL_G7.GetText(MODEL_G7.CurrentIndex, "CHKRSTKEY"));
                ItsMaria.AddOne("EQMCD", FANO_LIST.Value);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEARCH_CHK");
            }
            else if (commandName == "DEL_BAD")
            {   // 라인 불량정보 삭제
                ItsMaria.Set("TML2010_R01", "DEL_LINEBAD");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddOne("BADCD", MODEL_G3.GetText(MODEL_G3.CurrentIndex, "BADCD"));
                ItsMaria.AddOne("BADDETAIL", MODEL_G3.GetText(MODEL_G3.CurrentIndex, "BADDETAIL"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 불량 탭, 불량수량만 갱신 (LIST_INPUT 을 다시 부르면 입력 중인 사용량이 지워짐)
                MODEL_G3.SetData(ds.Tables[0]);
                MODEL_B1.SetValue("BADQTY", decimal.Parse(ItsData.GetText(ds.Tables[1], 0, "BADQTY")));
                CalcGoodQty();
            }
            else if (commandName == "WORK_DONE")
            {   // 작업완료 (작업지시·작업이력·생산실적·자재출고·실적로트 입고)
                ItsMaria.Set("TML2010_R01", "WORK_DONE");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddModel(MODEL_B1);
                ItsMaria.AddListGridAll("LOTKEY_LIST", MODEL_G1, "LOTKEY");
                ItsMaria.AddListGridAll("USEQTY_LIST", MODEL_G1, "USEQTY");
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 생산실적정보 초기화 (작업일자는 오늘)
                MODEL_B1.InitData();
                MODEL_B1.SetValue("WORKSDAY", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_B1.SetValue("WORKEDAY", DateTime.Now.ToString("yyyy-MM-dd"));

                // 라인 정보가 지워졌으므로 다시 조회 (투입로트·생산품·작업자 비워짐)
                EventCommand("LIST_INPUT");

                PrintMove(ItsData.GetText(ds.Tables[0], 0, "LOTKEY"));
                ShowMessageBox("", "생산실적이 등록되었습니다.\n실적로트: " + ItsData.GetText(ds.Tables[0], 0, "LOTKEY"));
            }
        }

        // 공정이동표 출력 (A4, 확인창 없이 POP 에서 고른 프린터로 바로 인쇄). 양품로트 1장 + 불량이 있으면 불량로트 1장
        // 양식은 COMPJT\TMLPRINT 의 PRD_1 (AAALIB\TMLPRINT.exe)
        private void PrintMove(string lotKey)
        {
            ItsMaria.Set("TML2010_R01", "PRINT_MOVE");
            ItsMaria.AddOne("LOTKEY", lotKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            try
            {
                // 양품·불량을 문서 하나로 합쳐 한 번에 인쇄 (인쇄작업 1개)
                List<TMLPRINT.PRD_1> reports = new List<TMLPRINT.PRD_1>();
                if (ItsData.GetDecimal(ds.Tables[0], 0, "GOODQTY") > 0)
                {
                    reports.Add(new TMLPRINT.PRD_1(ds, false));
                }
                if (ItsData.GetDecimal(ds.Tables[0], 0, "BADQTY") > 0)
                {
                    reports.Add(new TMLPRINT.PRD_1(ds, true));
                }
                TMLPRINT.PRD_1.PrintDirect(reports, ItsPrinter.BarcodePrintName);
            }
            catch (Exception ex)
            {
                ShowMessageBox("", "공정이동표 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
            }
        }
        /***************************************************************************************************************************************************************/
        private void TXT_SCANLOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EventCommand("SCAN_LOT");
            }
        }

        private void TIME_TQMTIME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EventCommand("SEARCH_STD");
            }
        }
        /***************************************************************************************************************************************************************/
    }
}
