using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using ITSLIB;
using DevExpress.Xpf.Grid;

namespace TML1010
{
    /// <summary>
    /// 2026-11-12 [외주이동] 외주처 창고 → S&S 사내 창고 납품(무상사급). 입고 때 재고 이동
    /// ERP POP 화면 구조 : 이동일자 / 출고창고(로그인한 외주처 창고) / 입고창고 / 바코드 스캔 → 이동량 수정 → [등록] [취소]
    /// 프로시저 TML1010_R02 (SCAN_LOT, MOVE_LOT)
    /// </summary>
    public partial class R02 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();

        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelPanel MODEL_S2 = new ItsModelPanel();   // [거래명세서 발행] 탭 조회조건
        ItsModelGrid MODEL_G3 = new ItsModelGrid();     // [거래명세서 발행] 탭 거래명세서 목록
        ItsModelPanel MODEL_S3 = new ItsModelPanel();   // [이동내역삭제] 탭 조회조건
        ItsModelGrid MODEL_G4 = new ItsModelGrid();     // [이동내역삭제] 탭 이동 목록

        // 생성자
        public R02()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.InitData();

            MODEL_G2.Binding(GRID_G2);

            MODEL_S2.Binding(PANEL_S2);
            MODEL_S2.InitData();
            MODEL_G3.Binding(GRID_G3);
            MODEL_G3.InitData();

            MODEL_S3.Binding(PANEL_S3);
            MODEL_S3.InitData();
            MODEL_G4.Binding(GRID_G4);
            MODEL_G4.InitData();
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            if (ItsLocalInfo.TMLCUSTCD != "")
            {
                cb_CUSTCD.Value = ItsLocalInfo.TMLCUSTCD.ToString();

                // 출고창고 : 로그인한 외주처의 창고 (표시만)
                DataSet dsWare = ItsMaria.Query("SELECT WARECD FROM MSTWARE WHERE FACTORYCD = '07' AND USEYN = 'Y' AND CUSTCD = '" + ItsLocalInfo.TMLCUSTCD.ToString().Replace("'", "''") + "' ORDER BY WARECD LIMIT 1;");
                if (dsWare != null && dsWare.Tables.Count > 0 && dsWare.Tables[0].Rows.Count > 0)
                {
                    cb_OUTWARE.Value = dsWare.Tables[0].Rows[0]["WARECD"].ToString();
                }
            }

            MODEL_S1.SetValue("MOVEDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S3.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S3.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("SCANLOT", "");

            PANEL_A1.Close();
            txt_BARCODE.Focus();
        }

        // ===== [거래명세서 발행]·[이동내역삭제] 탭 : 이동 거래명세서 조회 / 발행 / 삭제 (프로시저 TML1010_R02 LIST_INVOICE, DEL_MOVE_LOT) =====
        private void SearchInvoice(ItsModelPanel modelS, ItsModelGrid modelG)
        {
            ItsMaria.Set("TML1010_R02", "LIST_INVOICE");
            ItsMaria.AddOne("CUSTCD", MODEL_S1.GetText("CUSTCD"));
            ItsMaria.AddOne("SDATE", modelS.GetText("SDATE"));
            ItsMaria.AddOne("EDATE", modelS.GetText("EDATE"));
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            modelG.SetData(ds.Tables[0]);
        }

        // 조회·발행·삭제 버튼 처리. 처리했으면 true
        private bool EventCommandHistory(string commandName)
        {
            if (commandName == "SEARCH_INVOICE")
            {
                // 현재 보이는 탭 기준으로 조회 (거래명세서 발행 탭 = 1, 이동내역삭제 탭 = 2)
                ItsModelPanel modelS = TAB_MAIN.SelectedIndex == 2 ? MODEL_S3 : MODEL_S2;
                ItsModelGrid modelG = TAB_MAIN.SelectedIndex == 2 ? MODEL_G4 : MODEL_G3;

                if (modelS.GetText("SDATE") == "" || modelS.GetText("EDATE") == "")
                {
                    ShowMessageBox("", "이동일자를 선택하세요.");
                    return true;
                }

                SearchInvoice(modelS, modelG);
                return true;
            }
            else if (commandName == "PRINT_INVOICE_TAB")
            {
                if (MODEL_G3.ModelCount <= 0 || MODEL_G3.CurrentIndex < 0)
                {
                    ShowMessageBox("", "발행할 거래명세서를 선택하세요.");
                    return true;
                }

                PrintInvoice(MODEL_G3.GetText(MODEL_G3.CurrentIndex, "INVOICEKEY"));
                return true;
            }
            else if (commandName == "DEL_INVOICE")
            {
                int cnt = 0;
                for (int i = 0; i < MODEL_G4.ModelCount; i++)
                {
                    if (MODEL_G4.IsChecked(i)) cnt++;
                }
                if (cnt == 0)
                {
                    ShowMessageBox("", "삭제할 이동내역을 체크하세요.");
                    return true;
                }

                ShowMessageBox(commandName, "체크한 이동 " + cnt + "건을 삭제하시겠습니까?");
                return true;
            }

            return false;
        }

        // 삭제 확인 후 처리. 처리했으면 true
        private bool EventMessageHistory(string commandName)
        {
            if (commandName != "DEL_INVOICE") return false;

            int delCnt = 0;
            for (int i = 0; i < MODEL_G4.ModelCount; i++)
            {
                if (!MODEL_G4.IsChecked(i)) continue;

                ItsMaria.Set("TML1010_R02", "DEL_MOVE_LOT");
                ItsMaria.AddOne("INVOICEKEY", MODEL_G4.GetText(i, "INVOICEKEY"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage + "\n- 거래명세번호: " + MODEL_G4.GetText(i, "INVOICEKEY"));
                    SearchInvoice(MODEL_S3, MODEL_G4);
                    return true;
                }
                delCnt++;
            }

            ShowMessageBox("", "삭제되었습니다. (" + delCnt + "건)");
            SearchInvoice(MODEL_S3, MODEL_G4);
            return true;
        }
        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (EventCommandHistory(commandName)) return;

            // 행 삭제
            if (commandName == "DEL_ROW")
            {
                MODEL_G1.DeleteCurrentModel();
                txt_BARCODE.Focus();
            }
            // 스캔 목록 비우기
            else if (commandName == "CLEAR_SCAN")
            {
                MODEL_G1.Clear();
                MODEL_S1.SetValue("SCANLOT", "");
                txt_BARCODE.Focus();
            }
            // 등록
            else if (commandName == "MOVE_LOT")
            {
                if (MODEL_S1.GetText("MOVEDATE") == "")
                {
                    ShowMessageBox("", "이동일자를 선택하세요.");
                    return;
                }
                if (MODEL_S1.GetText("OUTWARE") == "")
                {
                    ShowMessageBox("", "출고창고가 없습니다. 외주처 창고 설정을 확인하세요.");
                    return;
                }
                if (MODEL_S1.GetText("INWARE") == "")
                {
                    ShowMessageBox("", "입고창고를 선택하세요.");
                    return;
                }
                if (MODEL_G1.Rows.Count == 0)
                {
                    ShowMessageBox("", "이동할 LOT 바코드를 스캔하세요.");
                    return;
                }

                decimal totQty = 0;
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    decimal moveQty = MODEL_G1.GetDecimal(i, "MOVEQTY");
                    if (moveQty <= 0)
                    {
                        ShowMessageBox("", "이동량을 입력하세요. (" + MODEL_G1.GetText(i, "LOTKEY") + ")");
                        return;
                    }
                    decimal testQty = MODEL_G1.GetDecimal(i, "TESTQTY");
                    if (testQty < 0 || testQty > moveQty)
                    {
                        ShowMessageBox("", "시편수량은 0 이상, 이동량 이하로 입력하세요. (" + MODEL_G1.GetText(i, "LOTKEY") + ")");
                        return;
                    }
                    if (moveQty > MODEL_G1.GetDecimal(i, "LOTQTY"))
                    {
                        ShowMessageBox("", "이동량이 잔여재고량보다 많습니다. (" + MODEL_G1.GetText(i, "LOTKEY") + ")");
                        return;
                    }
                    totQty += moveQty;
                }

                ShowMessageBox(commandName, MODEL_S1.GetText("MOVEDATE") + " 일자로 LOT " + MODEL_G1.Rows.Count + "개, 총 " + totQty.ToString("#,0") + " 을(를) 납품등록 하시겠습니까?");
            }
            // 취소 (등록 직후 팝업에서)
            else if (commandName == "MTRCUST_INVOICE_CANCEL")
            {
                ShowMessageBox(commandName, "납품 취소 하시겠습니까??");
                return;
            }
            // 거래명세표 출력 (재출력)
            else if (commandName == "MTRCUST_INVOICE_PRINT")
            {
                if (MODEL_A1.GetText("INVOICEKEY") == "")
                {
                    ShowMessageBox("", "출력할 거래명세서가 없습니다.");
                    return;
                }

                PrintInvoice(MODEL_A1.GetText("INVOICEKEY"));
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (EventMessageHistory(commandName)) return;

            // 취소
            if (commandName == "MTRCUST_INVOICE_CANCEL")
            {
                ItsMaria.Set("TML1010_R02", "DEL_MOVE_LOT");

                ItsMaria.AddModel(MODEL_A1);

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A1.Close();
                MODEL_G1.Clear();
                txt_BARCODE.Focus();
            }
            // 등록
            else if (commandName == "MOVE_LOT")
            {
                ItsMaria.Set("TML1010_R02", "MOVE_LOT");
                ItsMaria.AddOne("MOVEDATE", MODEL_S1.GetValue("MOVEDATE"));
                ItsMaria.AddOne("CUSTCD", MODEL_S1.GetValue("CUSTCD"));
                ItsMaria.AddOne("INWARE", MODEL_S1.GetValue("INWARE"));

                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    ItsMaria.AddList("WARECD_LIST", MODEL_G1.GetText(i, "WARECD"));
                    ItsMaria.AddList("LOTKEY_LIST", MODEL_G1.GetText(i, "LOTKEY"));
                    ItsMaria.AddList("LOTQTY_LIST", MODEL_G1.GetDecimal(i, "MOVEQTY"));
                    ItsMaria.AddList("TESTQTY_LIST", MODEL_G1.GetDecimal(i, "TESTQTY"));
                }

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A1.SetValue("INVOICEKEY", ds.Tables[0].Rows[0]["INVOICEKEY"]);
                MODEL_A1.SetValue("OUTDATE", ds.Tables[0].Rows[0]["MOVEDATE"]);
                MODEL_A1.SetValue("INDATE", ds.Tables[0].Rows[0]["INDATE"]);
                MODEL_A1.SetValue("OUTCUSTCD", ds.Tables[0].Rows[0]["OUTCUSTCD"]);
                MODEL_A1.SetValue("INCUSTCD", ds.Tables[0].Rows[0]["INCUSTCD"]);
                MODEL_G2.SetData(ds.Tables[0]);

                PANEL_A1.Show();

                string invoiceKey = ItsData.GetText(ds.Tables[0], 0, "INVOICEKEY");

                MODEL_G1.Clear();
                MODEL_S1.SetValue("SCANLOT", "");

                // 등록 직후 거래명세서 출력
                PrintInvoice(invoiceKey);
            }
        }

        // 바코드 스캔 (스캐너가 Enter 를 붙여 보냄)
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            string lotKey = MODEL_S1.GetText("SCANLOT").Trim();
            MODEL_S1.SetValue("SCANLOT", "");
            if (lotKey == "") return;

            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                if (MODEL_G1.GetText(i, "LOTKEY") == lotKey)
                {
                    ShowMessageBox("", "이미 스캔한 LOT 입니다. (" + lotKey + ")");
                    return;
                }
            }

            ItsMaria.Set("TML1010_R02", "SCAN_LOT");
            ItsMaria.AddOne("CUSTCD", MODEL_S1.GetText("CUSTCD"));
            ItsMaria.AddOne("OUTWARE", MODEL_S1.GetText("OUTWARE"));
            ItsMaria.AddOne("SCANLOT", lotKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            if (ds.Tables[0].Rows.Count == 0) return;

            if (MODEL_G1.Rows.Count == 0)
            {
                MODEL_G1.SetData(ds.Tables[0]);
            }
            else
            {
                MODEL_G1.AddRow(ds.Tables[0]);
            }

            txt_BARCODE.Focus();
        }

        // 거래명세서(A4 1장: 공급받는자 보관용, 품목별 수량 소계) 출력. 확인창 없이 POP 에서 고른 프린터로 바로 인쇄
        // 양식은 COMPJT\TMLPRINT 의 MTR_1 (AAALIB\TMLPRINT.exe), 데이터는 TML1010_R01 PRINT_INVOICE
        private void PrintInvoice(string invoiceKey)
        {
            ItsMaria.Set("TML1010_R01", "PRINT_INVOICE");
            ItsMaria.AddOne("INVOICEKEY", invoiceKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            try
            {
                TMLPRINT.MTR_1 rpt = new TMLPRINT.MTR_1(ds);
                rpt.PrintDirect(ItsPrinter.BarcodePrintName);
            }
            catch (Exception ex)
            {
                ShowMessageBox("", "납품은 등록되었으나 거래명세서 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
            }
        }

        public override void EventPopClose(string panelName)
        {
            base.EventPopClose(panelName);

            if (panelName == "PANEL_A1")
            {
                MODEL_G1.Clear();
                txt_BARCODE.Focus();
            }
        }
    }
}