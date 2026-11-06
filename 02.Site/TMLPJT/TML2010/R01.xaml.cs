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
        ItsModelGrid MODEL_G11 = new ItsModelGrid(); //자주검사 검사값

        private string chgLinecd = ""; //BOM 불일치 시 바꿀 작업장
        private string chgPrccd = "";  //BOM 불일치 시 바꿀 공정

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
            MODEL_G10.Binding(GRID_G10);
            MODEL_G10.EventRowChanged += MODEL_G10_EventRowChanged;
            MODEL_G11.Binding(GRID_G11);
            MODEL_G11.EventValueChanged += MODEL_G11_EventValueChanged;
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
        private void CalcGoodQty()
        {
            decimal sumqty = 0;
            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                decimal useqty;
                if (decimal.TryParse(MODEL_G1.GetText(i, "USEQTY"), out useqty))
                {
                    sumqty += useqty;
                }
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

        //자주검사 검사항목 선택 → 시료수만큼 검사값 행 (이 검사일시에 저장된 항목이면 저장된 검사값과 합불)
        private void MODEL_G10_EventRowChanged(int rowIndex)
        {
            MODEL_G11.InitData();
            MODEL_A10.SetValue("OK", false);
            MODEL_A10.SetValue("NG", false);
            if (rowIndex < 0)
            {
                return;
            }

            // 측정검사(02)가 아니면 합격을 기본으로 체크 (측정은 검사값 입력으로 자동 판정)
            if (MODEL_G10.GetText(rowIndex, "STDCHKTP") != "02")
            {
                MODEL_A10.SetValue("OK", true);
            }

            bool isSaved = MODEL_G10.GetText(rowIndex, "TQMRSTKEY") != "";
            if (isSaved)
            {
                ItsMaria.Set("TAL2001_R01", "LIST_VALUE");
                ItsMaria.AddOne("TQMRSTKEY", MODEL_G10.GetText(rowIndex, "TQMRSTKEY"));
                ItsMaria.AddOne("PRCCD", MODEL_A10.GetText("PRCCD"));
                ItsMaria.AddOne("STDCD", MODEL_G10.GetText(rowIndex, "STDCD"));
                ItsMaria.AddOne("STDPART", MODEL_G10.GetText(rowIndex, "STDPART"));
                ItsMaria.AddOne("PRCDETAIL", MODEL_G10.GetText(rowIndex, "PRCDETAIL"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G11.SetData(ds.Tables[0]);
            }

            // 시료수만큼 행 (저장된 검사값 뒤에 빈 행, L·R 둘 다 빈 행은 저장하지 않으므로)
            int samplesize = (int)MODEL_G10.GetDecimal(rowIndex, "SAMPLESIZE");
            for (int i = MODEL_G11.Rows.Count; i < samplesize; i++)
            {
                MODEL_G11.AddRow();
            }

            if (isSaved)
            {
                JudgePrcTest(rowIndex);
                MODEL_A10.SetValue("OK", MODEL_G10.GetText(rowIndex, "JUDGE") == "Y");
                MODEL_A10.SetValue("NG", MODEL_G10.GetText(rowIndex, "JUDGE") == "N");
            }
        }

        //자주검사 검사값 입력 → 합불 판정
        private void MODEL_G11_EventValueChanged(int rowIndex, string fieldName)
        {
            if (fieldName == "VALUE" || fieldName == "VALUE2")
            {
                JudgePrcTest(MODEL_G10.CurrentIndex);
            }
        }

        //측정검사(02) 검사값을 판정범위로 합불 판정: 벗어난 행은 빨간 글자, 행별 판정, 합격·불합격 체크 자동 설정 (TAL2001_R01 JUDGE_GRID2 와 같음)
        private void JudgePrcTest(int stdRow)
        {
            if (stdRow < 0 || MODEL_G10.GetText(stdRow, "STDCHKTP") != "02")
            {
                return;
            }

            string stdrange = MODEL_G10.GetText(stdRow, "STDRANGE");
            decimal stdval, stdminus, stdplus;
            decimal.TryParse(MODEL_G10.GetText(stdRow, "STDVAL"), out stdval);
            decimal.TryParse(MODEL_G10.GetText(stdRow, "STDMINUS"), out stdminus);
            decimal.TryParse(MODEL_G10.GetText(stdRow, "STDPLUS"), out stdplus);

            bool hasNg = false;
            bool allEntered = true;
            for (int i = 0; i < MODEL_G11.Rows.Count; i++)
            {
                string value = MODEL_G11.GetText(i, "VALUE").Trim();
                string value2 = MODEL_G11.GetText(i, "VALUE2").Trim();
                if (value == "" && value2 == "") allEntered = false;

                // 범위 코드(STDRANGE): 01 최대, 02 최소, 03 이상, 04 이내, 05 =, 06 ~ (경계값 포함 합격)
                bool rowNg = false;
                foreach (string text in new string[] { value, value2 })
                {
                    if (text == "") continue;

                    decimal v;
                    bool ok;
                    if (!decimal.TryParse(text, out v)) ok = false;
                    else if (stdrange == "01" || stdrange == "04") ok = v <= stdval;
                    else if (stdrange == "02" || stdrange == "03") ok = v >= stdval;
                    else if (stdrange == "05") ok = v == stdval;
                    else if (stdrange == "06") ok = v >= stdval + stdminus && v <= stdval + stdplus;
                    else ok = true;

                    if (!ok) rowNg = true;
                }

                if (rowNg) hasNg = true;
                MODEL_G11.SetValue(i, "JUDGE", value == "" && value2 == "" ? "" : (rowNg ? "불합격" : "합격"));
                MODEL_G11.SetForeColor(i, rowNg ? Colors.Red : Colors.Black);
            }

            MODEL_A10.SetValue("NG", hasNg);
            MODEL_A10.SetValue("OK", !hasNg && allEntered);
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

            SetTMLPOPTitle(POPUP_A1, "생산품목선택");
            SetTMLPOPTitle(POPUP_A2, "불량등록");
            SetTMLPOPTitle(POPUP_A3, "비가동등록");
            SetTMLPOPTitle(POPUP_A4, "작업자선택");

            MODEL_B1.SetValue("WORKSDAY", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_B1.SetValue("WORKEDAY", DateTime.Now.ToString("yyyy-MM-dd"));

            TXT_SCANLOT.SetFocus();
        }
        /***************************************************************************************************************************************************************/
        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

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
                MODEL_G11.InitData();

                // 검사항목 조회가 오류(생산품·자주검사 기준 없음 등)면 메시지만 띄우고 팝업은 열지 않음
                EventCommand("SEARCH_STD");
                if (ItsMaria.IsError)
                {
                    return;
                }

                PANEL_A10.Show();
            }
            else if (commandName == "SEARCH_STD")
            {   // 라인 생산품, 사용중인 자주검사 리비전의 검사항목 (검사일자·시간의 검사이력 포함)
                string tqmtime = MODEL_A10.GetText("TQMTIME");

                MODEL_A10.SetValue("ITEMID", "");
                MODEL_A10.SetValue("ITEMCD", "");
                MODEL_A10.SetValue("ITEMNM", "");
                MODEL_A10.SetValue("ITEMSPEC", "");
                MODEL_G10.InitData();
                MODEL_G11.InitData();

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

                MODEL_G10.SetData(ds.Tables[1]);
                (GRID_G10.View as TableView).BestFitColumns();
                for (int i = 0; i < MODEL_G10.Rows.Count; i++)
                {
                    if (MODEL_G10.GetText(i, "JUDGE") == "N") MODEL_G10.SetForeColor(i, Colors.Red);   // 불합격 항목은 빨간 글자
                }
                MODEL_G10_EventRowChanged(MODEL_G10.CurrentIndex);
            }
            else if (commandName == "SAVE_PRCTEST")
            {   // 선택한 검사항목의 검사결과(합불)와 검사값 저장
                if (MODEL_G10.Rows.Count == 0 || MODEL_G10.CurrentIndex < 0)
                {
                    ShowMessageBox("", "검사항목을 선택하세요.");
                    return;
                }

                int stdRow = MODEL_G10.CurrentIndex;
                string judge = MODEL_A10.GetBool("OK") ? "Y" : (MODEL_A10.GetBool("NG") ? "N" : "");
                string tqmtime = MODEL_A10.GetText("TQMTIME");

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
                ItsMaria.AddOne("JUDGE", judge);
                for (int i = 0; i < MODEL_G11.Rows.Count; i++)
                {
                    ItsMaria.AddList("SEQ_LIST", (i + 1).ToString());
                    ItsMaria.AddList("VALUE_LIST", MODEL_G11.GetText(i, "VALUE"));
                    ItsMaria.AddList("VALUE2_LIST", MODEL_G11.GetText(i, "VALUE2"));
                }
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 저장한 검사항목 결과를 검사항목 줄에 표시
                MODEL_G10.SetValue(stdRow, "TQMRSTKEY", ItsData.GetText(ds.Tables[0], 0, "TQMRSTKEY"));
                MODEL_G10.SetValue(stdRow, "MINVAL", ItsData.GetText(ds.Tables[0], 0, "MINVAL"));
                MODEL_G10.SetValue(stdRow, "MAXVAL", ItsData.GetText(ds.Tables[0], 0, "MAXVAL"));
                MODEL_G10.SetValue(stdRow, "AVG", ItsData.GetText(ds.Tables[0], 0, "AVG"));
                MODEL_G10.SetValue(stdRow, "JUDGE", ItsData.GetText(ds.Tables[0], 0, "JUDGE"));
                MODEL_G10.SetValue(stdRow, "JUDGENM", ItsData.GetText(ds.Tables[0], 0, "JUDGENM"));
                MODEL_G10.SetForeColor(stdRow, ItsData.GetText(ds.Tables[0], 0, "JUDGE") == "N" ? Colors.Red : Colors.Black);

                // 다음 검사항목 선택 (마지막 항목이면 첫 항목)
                int nextRow = stdRow + 1 < MODEL_G10.Rows.Count ? stdRow + 1 : 0;
                MODEL_G10.SelectRow(nextRow);
                MODEL_G10_EventRowChanged(nextRow);
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
                MODEL_G9.SetData(ds.Tables[0]);
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
                MODEL_G9.SetData(ds.Tables[0]);
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
                PANEL_A7.Close();
            }
            else if (commandName == "CHKVAL_OK" || commandName == "CHKVAL_NG")
            {   // OK/NG 점검값 반영
                MODEL_G9.SetValue(MODEL_G9.CurrentIndex, "CHKVALUE", commandName == "CHKVAL_OK" ? "OK" : "NG");
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
                if (ItsData.GetDecimal(ds.Tables[0], 0, "GOODQTY") > 0)
                {
                    TMLPRINT.PRD_1 rpt = new TMLPRINT.PRD_1(ds, false);
                    rpt.PrintDirect(ItsPrinter.BarcodePrintName);
                }
                if (ItsData.GetDecimal(ds.Tables[0], 0, "BADQTY") > 0)
                {
                    TMLPRINT.PRD_1 rptBad = new TMLPRINT.PRD_1(ds, true);
                    rptBad.PrintDirect(ItsPrinter.BarcodePrintName);
                }
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
