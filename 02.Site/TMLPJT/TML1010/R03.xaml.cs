using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using ITSLIB;

namespace TML1010
{
    /// <summary>
    /// // 2026-11-09 [무상사급 실적 등록] TML2010_R01(사내 생산실적등록)과 같은 방식
    /// 작업장 = 로그인 외주처의 작업장 고정, 생산공정 선택, 생산설비 없음, 주야구분 기본 주간
    /// 투입바코드 스캔 → BOM·라우팅 확인 (같은 작업장의 다른 공정이면 기본공정으로 자동변경 안내) → 투입 등록
    /// 작업완료 → 외주실적(OSCRST) 등록 + 공정이동표(TMLPRINT.PRD_1) 출력. 실적삭제·공정이동표 재출력은 아래 최근 실적에서 선택
    /// </summary>
    public partial class R03 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();   // 투입품번정보
        ItsModelPanel MODEL_B1 = new ItsModelPanel();   // 생산실적정보
        ItsModelPanel MODEL_A1 = new ItsModelPanel();   // 생산품목선택 팝업

        ItsModelGrid MODEL_G1 = new ItsModelGrid();     // 투입 LOT
        ItsModelGrid MODEL_G3 = new ItsModelGrid();     // 최근 실적
        ItsModelGrid MODEL_G5 = new ItsModelGrid();     // 생산품목선택

        private string chgPrccd = "";  // 라우팅 불일치 시 바꿀 기본공정

        public R03()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

            MODEL_B1.Binding(PANEL_B1);
            MODEL_B1.InitData();
            MODEL_B1.EventValueChanged += MODEL_B1_EventValueChanged;

            MODEL_A1.Binding(PANEL_A1);

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.EventValueChanged += MODEL_G1_EventValueChanged;
            MODEL_G3.Binding(GRID_G3);
            MODEL_G5.Binding(GRID_G5);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            POPUP_A1.ApplyTemplate();
            SetTMLPOPTitle(POPUP_A1, "생산품목선택");

            MODEL_B1.SetValue("WORKSDAY", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_B1.SetValue("WORKEDAY", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_B1.SetValue("DNTP", "PP161100N");   // 주간 기본 (시작·종료시간은 MODEL_B1_EventValueChanged 에서)

            // 작업장 = 로그인 외주처의 작업장 : 작업장 콤보(DC_COMBO LINECD) REF02 에 외주처 코드 → 그 외주처 작업장만 나옴, 첫 작업장 선택
            string custcd = ItsLocalInfo.TMLCUSTCD ?? "";
            MODEL_S1.SetValue("CUSTCD", custcd);
            if (custcd == "")
            {
                ShowMessageBox("", "로그인한 계정에 외주처(거래처)가 지정되어 있지 않습니다.");
                return;
            }

            MODEL_S1.SetRef02("LINECD", custcd);

            string linecd = "";
            if (CMB_LINECD.ModelCombo != null)
            {
                foreach (DataRow row in CMB_LINECD.ModelCombo.Rows)
                {
                    if (row["Value"].ToString() != "") { linecd = row["Value"].ToString(); break; }
                }
            }
            if (linecd == "")
            {
                ShowMessageBox("", "외주처의 작업장이 없습니다. 작업장 관리에서 외주처를 지정하세요.");
                return;
            }
            MODEL_S1.SetRef01("PRCCD", linecd);   // 생산공정 콤보 REF01 = 작업장
            MODEL_S1.SetValue("LINECD", linecd);

            TXT_SCANLOT.SetFocus();
        }

        private void MODEL_S1_EventValueChanged(string fieldName)
        {
            if (fieldName == "LINECD")
            {
                MODEL_S1.SetRef01("PRCCD", MODEL_S1.GetText("LINECD"));
            }

            // 작업장·공정이 바뀌면 투입 LOT 다시 조회
            if (fieldName == "LINECD" || fieldName == "PRCCD")
            {
                if (MODEL_S1.GetText("LINECD") != "" && MODEL_S1.GetText("PRCCD") != "")
                {
                    EventCommand("LIST_INPUT");
                }
                else
                {
                    MODEL_G1.Clear();
                    MODEL_G3.Clear();
                    SetItem(null);
                    MODEL_B1.SetValue("GOODQTY", "");
                }
            }
        }

        private void MODEL_B1_EventValueChanged(string fieldName)
        {
            if (fieldName == "DNTP")
            {
                // 야간(PP161102N)이면 작업시작일 전날, 아니면 오늘
                MODEL_B1.SetValue("WORKSDAY", MODEL_B1.GetText("DNTP") == "PP161102N" ? DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd"));

                // 주야구분 명칭 예) 주간(06:00~16:00) → ~ 왼쪽 5자 시작시간, 오른쪽 5자 종료시간
                string dntpnm = CMB_DNTP.SelectedLabel ?? "";
                int idx = dntpnm.IndexOf("~");
                if (idx < 5 || dntpnm.Length < idx + 6) return;

                MODEL_B1.SetValue("WORKSTIME", dntpnm.Substring(idx - 5, 5));
                MODEL_B1.SetValue("WORKETIME", dntpnm.Substring(idx + 1, 5));
            }
        }

        private void MODEL_G1_EventValueChanged(int rowIndex, string fieldName)
        {
            if (fieldName == "USEQTY") CalcGoodQty();
        }

        // 양품수량 = 투입 LOT 사용량 합계
        private void CalcGoodQty()
        {
            decimal sumqty = 0;
            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                sumqty += MODEL_G1.GetDecimal(i, "USEQTY");
            }
            MODEL_B1.SetValue("GOODQTY", sumqty > 0 ? sumqty.ToString("#,0") : "");
        }

        // 생산품 표시 (dt 가 없으면 비움)
        private void SetItem(DataTable dt)
        {
            MODEL_S1.SetValue("ITEMID", dt == null ? "" : ItsData.GetText(dt, 0, "ITEMID"));
            MODEL_S1.SetValue("ITEMCD", dt == null ? "" : ItsData.GetText(dt, 0, "ITEMCD"));
            MODEL_S1.SetValue("ITEMNM", dt == null ? "" : ItsData.GetText(dt, 0, "ITEMNM"));
            MODEL_S1.SetValue("ITEMSPEC", dt == null ? "" : ItsData.GetText(dt, 0, "ITEMSPEC"));
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "SCAN_LOT")
            {   // 투입바코드 스캔
                if (MODEL_S1.GetText("SCANLOT") == "") return;

                ItsMaria.Set("TML1010_R03", "SCAN_LOT");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    MODEL_S1.SetValue("SCANLOT", "");
                    TXT_SCANLOT.SetFocus();
                    return;
                }

                // 선택한 공정으로 지정된 라우팅이 없음 → 알림 후 기본공정으로 변경 (작업장은 외주처 고정)
                if (ItsData.GetText(ds.Tables[0], 0, "RESULT") == "NO_BOM")
                {
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
                {   // 생산품이 여러 개면 팝업에서 선택
                    PANEL_A1.Show();
                    return;
                }
                EventCommand("SEL_ITEM");
            }
            else if (commandName == "SEL_ITEM")
            {   // 생산품 선택 → 저장 → 스캔한 LOT 투입
                int row = MODEL_G5.Rows.Count == 1 ? 0 : MODEL_G5.CurrentIndex;
                if (row < 0 || MODEL_G5.GetText(row, "ITEMID") == "")
                {
                    ShowMessageBox("", "생산할 품목을 선택하세요.");
                    return;
                }

                // 이미 투입된 LOT 의 생산품과 다르면 막음
                if (MODEL_S1.GetText("ITEMID") != "" && MODEL_S1.GetText("ITEMID") != MODEL_G5.GetText(row, "ITEMID") && MODEL_G1.Rows.Count > 0)
                {
                    PANEL_A1.Close();
                    ShowMessageBox("", "이미 투입된 LOT 의 생산품과 다른 품목입니다.\n작업완료하거나 초기화한 뒤 스캔하세요.");
                    MODEL_S1.SetValue("SCANLOT", "");
                    TXT_SCANLOT.SetFocus();
                    return;
                }

                MODEL_S1.SetValue("ITEMID", MODEL_G5.GetText(row, "ITEMID"));
                MODEL_S1.SetValue("ITEMCD", MODEL_G5.GetText(row, "ITEMCD"));
                MODEL_S1.SetValue("ITEMNM", MODEL_G5.GetText(row, "ITEMNM"));
                MODEL_S1.SetValue("ITEMSPEC", MODEL_G5.GetText(row, "ITEMSPEC"));
                PANEL_A1.Close();

                ItsMaria.Set("TML1010_R03", "SET_LINEITEM");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                ItsMaria.Set("TML1010_R03", "ADD_INPUT");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    MODEL_S1.SetValue("SCANLOT", "");
                    TXT_SCANLOT.SetFocus();
                    return;
                }

                MODEL_S1.SetValue("SCANLOT", "");
                EventCommand("LIST_INPUT");
            }
            else if (commandName == "LIST_INPUT")
            {   // 투입 LOT·생산품·최근 실적 조회
                ItsMaria.Set("TML1010_R03", "LIST_INPUT");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.SetData(ds.Tables[0]);
                SetItem(ds.Tables[1].Rows.Count > 0 ? ds.Tables[1] : null);
                MODEL_G3.SetData(ds.Tables[2]);
                CalcGoodQty();
                TXT_SCANLOT.SetFocus();
            }
            else if (commandName == "DEL_INPUT")
            {
                if (MODEL_G1.CurrentIndex < 0) return;
                ShowMessageBox(commandName, "투입을 취소하시겠습니까?");
            }
            else if (commandName == "CLEAR_INPUT")
            {
                if (MODEL_S1.GetText("LINECD") == "" || MODEL_S1.GetText("PRCCD") == "") return;
                ShowMessageBox(commandName, "투입 LOT 와 생산품을 모두 지우고 초기화하시겠습니까?");
            }
            else if (commandName == "WORK_DONE")
            {
                if (MODEL_S1.GetText("PRCCD") == "")
                {
                    ShowMessageBox("", "생산공정을 선택하세요.");
                    return;
                }
                if (MODEL_G1.Rows.Count == 0)
                {
                    ShowMessageBox("", "투입바코드를 스캔하세요.");
                    return;
                }
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    decimal useqty = MODEL_G1.GetDecimal(i, "USEQTY");
                    if (useqty <= 0)
                    {
                        ShowMessageBox("", "사용량을 입력하세요. (" + MODEL_G1.GetText(i, "LOTKEY") + ")");
                        return;
                    }
                    if (useqty > MODEL_G1.GetDecimal(i, "LOTQTY"))
                    {
                        ShowMessageBox("", "사용량이 잔여재고량보다 많습니다. (" + MODEL_G1.GetText(i, "LOTKEY") + ")");
                        return;
                    }
                }
                ShowMessageBox(commandName, "작업을 완료하시겠습니까?\n양품수량 : " + MODEL_B1.GetText("GOODQTY"));
            }
            else if (commandName == "DEL_RST")
            {
                if (MODEL_G3.Rows.Count == 0 || MODEL_G3.CurrentIndex < 0)
                {
                    ShowMessageBox("", "아래 생산실적에서 삭제할 실적을 선택하세요.");
                    return;
                }
                ShowMessageBox(commandName, "선택한 실적을 삭제하시겠습니까?\n실적로트 : " + MODEL_G3.GetText(MODEL_G3.CurrentIndex, "LOTKEY"));
            }
            else if (commandName == "PRINT_MOVE")
            {   // 선택한 실적의 공정이동표 재출력
                if (MODEL_G3.Rows.Count == 0 || MODEL_G3.CurrentIndex < 0)
                {
                    ShowMessageBox("", "아래 생산실적에서 출력할 실적을 선택하세요.");
                    return;
                }
                PrintMove(MODEL_G3.GetText(MODEL_G3.CurrentIndex, "LOTKEY"));
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "CHANGE_PRC")
            {   // 기본공정으로 자동변경 후 다시 스캔
                MODEL_S1.SetValue("PRCCD", chgPrccd);
                MODEL_S1.SetValue("SCANLOT", "");
                TXT_SCANLOT.SetFocus();
            }
            else if (commandName == "DEL_INPUT")
            {
                ItsMaria.Set("TML1010_R03", "DEL_INPUT");
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
            else if (commandName == "CLEAR_INPUT")
            {
                ItsMaria.Set("TML1010_R03", "CLEAR_INPUT");
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
            else if (commandName == "WORK_DONE")
            {   // 외주실적 등록
                ItsMaria.Set("TML1010_R03", "WORK_DONE");
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

                EventCommand("LIST_INPUT");

                string lotKey = ItsData.GetText(ds.Tables[0], 0, "LOTKEY");
                PrintMove(lotKey);
                ShowMessageBox("", "생산실적이 등록되었습니다.\n실적로트: " + lotKey);
            }
            else if (commandName == "DEL_RST")
            {
                ItsMaria.Set("TML1010_R03", "DEL_RST");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddOne("OSCRSTKEY", MODEL_G3.GetText(MODEL_G3.CurrentIndex, "OSCRSTKEY"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                EventCommand("LIST_INPUT");
                ShowMessageBox("", "실적이 삭제되었습니다.");
            }
        }

        // 공정이동표 출력 (A4, 확인창 없이 POP 에서 고른 프린터로 바로 인쇄). 양식은 COMPJT\TMLPRINT 의 PRD_1 (사내 실적과 같은 양식)
        private void PrintMove(string lotKey)
        {
            if (lotKey == "") return;

            ItsMaria.Set("TML1010_R03", "PRINT_MOVE");
            ItsMaria.AddOne("LOTKEY", lotKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            if (ds.Tables[0].Rows.Count == 0) return;

            try
            {
                TMLPRINT.PRD_1 rpt = new TMLPRINT.PRD_1(ds, false);
                rpt.PrintDirect(ItsPrinter.BarcodePrintName);
            }
            catch (Exception ex)
            {
                ShowMessageBox("", "공정이동표 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
            }
        }

        private void TXT_SCANLOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EventCommand("SCAN_LOT");
            }
        }
    }
}
