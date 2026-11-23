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
    /// 2026-11-16 [유상사급 자재이동] 외주처가 납품등록(R01)한 유상사급 LOT → S&S 사내 이동. 재고 변동 없음 (이동 이력·거래명세서 INVOICETP 05 만)
    /// 이동일자 / 입고창고(사내창고 고정, 표시만) / 바코드 스캔 → 수량 수정 불가 → [등록] [취소], 등록 직후 거래명세서 2장 출력
    /// 프로시저 TML1010_R06 (SCAN_LOT, MOVE_LOT, LIST_INVOICE, DEL_MOVE_LOT). 입고확인은 사내 TML1020 R07
    /// </summary>
    public partial class R06 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();

        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelPanel MODEL_S2 = new ItsModelPanel();   // [거래명세서 발행] 탭 조회조건
        ItsModelGrid MODEL_G3 = new ItsModelGrid();     // [거래명세서 발행] 탭 거래명세서 목록
        ItsModelPanel MODEL_S3 = new ItsModelPanel();   // [이동내역삭제] 탭 조회조건
        ItsModelGrid MODEL_G4 = new ItsModelGrid();     // [이동내역삭제] 탭 이동 목록

        private bool inHouse = false;   // 사내 계정 (외주처를 직접 선택)

        // 생성자
        public R06()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

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
                cb_CUSTCD.ReadOnly = true;
            }
            else
            {
                // 2026-11-16 사내 계정: 외주처를 직접 선택
                inHouse = true;
                cb_CUSTCD.ReadOnly = false;
                cb_CUSTCD.Visibility = Visibility.Visible;
            }

            // 출고창고(= 발주입고창고)·입고창고는 첫 바코드 스캔 때 정해짐 (표시만)
            ResetWare();

            MODEL_S1.SetValue("MOVEDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S3.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S3.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("SCANLOT", "");

            PANEL_A1.Close();
            txt_BARCODE.Focus();
        }

        // 출고창고·입고창고 비움 (스캔한 LOT 가 없을 때. 다음 첫 스캔 때 다시 정함)
        private void ResetWare()
        {
            MODEL_S1.SetValue("OUTWARE", "");
            MODEL_S1.SetValue("INWARE", "");
        }

        // ===== [거래명세서 발행]·[이동내역삭제] 탭 : 자재이동 거래명세서 조회 / 발행 / 삭제 (프로시저 TML1010_R06 LIST_INVOICE, DEL_MOVE_LOT) =====
        private void SearchInvoice(ItsModelPanel modelS, ItsModelGrid modelG)
        {
            ItsMaria.Set("TML1010_R06", "LIST_INVOICE");
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

                ItsMaria.Set("TML1010_R06", "DEL_MOVE_LOT");
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
                if (MODEL_G1.Rows.Count == 0) ResetWare();
                txt_BARCODE.Focus();
            }
            // 스캔 목록 비우기
            else if (commandName == "CLEAR_SCAN")
            {
                MODEL_G1.Clear();
                ResetWare();
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
                if (MODEL_S1.GetText("CUSTCD") == "")
                {
                    ShowMessageBox("", "외주처를 선택하세요.");
                    return;
                }
                if (MODEL_G1.Rows.Count == 0)
                {
                    ShowMessageBox("", "이동할 LOT 바코드를 스캔하세요.");
                    return;
                }
                if (MODEL_S1.GetText("OUTWARE") == "" || MODEL_S1.GetText("INWARE") == "")
                {
                    ShowMessageBox("", "출고창고·입고창고가 정해지지 않았습니다. LOT 바코드를 다시 스캔하세요.");
                    return;
                }

                decimal totQty = 0;
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    totQty += MODEL_G1.GetDecimal(i, "MOVEQTY");
                }

                ShowMessageBox(commandName, MODEL_S1.GetText("MOVEDATE") + " 일자로 LOT " + MODEL_G1.Rows.Count + "개, 총 " + totQty.ToString("#,0") + " 을(를) 자재이동 하시겠습니까?");
            }
            // 취소 (등록 직후 팝업에서)
            else if (commandName == "MTRCUST_INVOICE_CANCEL")
            {
                ShowMessageBox(commandName, "이동 취소 하시겠습니까?");
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
                ItsMaria.Set("TML1010_R06", "DEL_MOVE_LOT");

                ItsMaria.AddModel(MODEL_A1);

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A1.Close();
                MODEL_G1.Clear();
                ResetWare();
                txt_BARCODE.Focus();
            }
            // 등록
            else if (commandName == "MOVE_LOT")
            {
                ItsMaria.Set("TML1010_R06", "MOVE_LOT");
                ItsMaria.AddOne("MOVEDATE", MODEL_S1.GetValue("MOVEDATE"));
                ItsMaria.AddOne("CUSTCD", MODEL_S1.GetValue("CUSTCD"));
                ItsMaria.AddOne("OUTWARE", MODEL_S1.GetValue("OUTWARE"));
                ItsMaria.AddOne("INWARE", MODEL_S1.GetValue("INWARE"));

                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    ItsMaria.AddList("LOTKEY_LIST", MODEL_G1.GetText(i, "LOTKEY"));
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
                ResetWare();
                MODEL_S1.SetValue("SCANLOT", "");

                // 등록 직후 거래명세서 출력
                PrintInvoice(invoiceKey);
            }
        }

        // 사내 계정이 외주처를 바꾸면 스캔한 LOT 는 비움 (다른 외주처 것이므로)
        private void MODEL_S1_EventValueChanged(string fieldName)
        {
            if (fieldName == "CUSTCD" && inHouse && MODEL_G1.Rows.Count > 0)
            {
                MODEL_G1.Clear();
                ResetWare();
            }
        }

        // 바코드 스캔 (스캐너가 Enter 를 붙여 보냄)
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            string lotKey = MODEL_S1.GetText("SCANLOT").Trim();
            MODEL_S1.SetValue("SCANLOT", "");
            if (lotKey == "") return;

            if (MODEL_S1.GetText("CUSTCD") == "")
            {
                ShowMessageBox("", "외주처를 선택하세요.");
                return;
            }

            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                if (MODEL_G1.GetText(i, "LOTKEY") == lotKey)
                {
                    ShowMessageBox("", "이미 스캔한 LOT 입니다. (" + lotKey + ")");
                    return;
                }
            }

            ItsMaria.Set("TML1010_R06", "SCAN_LOT");
            ItsMaria.AddOne("CUSTCD", MODEL_S1.GetText("CUSTCD"));
            ItsMaria.AddOne("SCANLOT", lotKey);
            ItsMaria.AddOne("OUTWARE", MODEL_G1.Rows.Count == 0 ? "" : MODEL_S1.GetText("OUTWARE"));   // 두 번째 스캔부터 이미 스캔한 LOT 의 발주입고창고와 같은지 프로시저에서 확인
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            if (ds.Tables[0].Rows.Count == 0) return;

            if (MODEL_G1.Rows.Count == 0)
            {
                // 첫 스캔 : 출고창고 = 이 LOT 의 발주입고창고(MTRODR.INWARECD), 입고창고는 출고창고에 따라 정해짐
                MODEL_S1.SetValue("OUTWARE", ItsData.GetText(ds.Tables[0], 0, "WARECD"));
                MODEL_S1.SetValue("INWARE", ItsData.GetText(ds.Tables[0], 0, "INWARECD"));
                MODEL_G1.SetData(ds.Tables[0]);
            }
            else
            {
                MODEL_G1.AddRow(ds.Tables[0]);
            }

            txt_BARCODE.Focus();
        }

        // 거래명세서(공급자 보관용 + 공급받는자 보관용 2장) 출력. 확인창 없이 POP 에서 고른 프린터로 바로 인쇄
        // 양식은 COMPJT\TMLPRINT 의 MTR_1 (AAALIB\TMLPRINT.exe), 데이터는 TML1010_R01 PRINT_INVOICE (자재이동 거래명세서도 같은 데이터)
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
                TMLPRINT.MTR_1 rpt = new TMLPRINT.MTR_1(ds, true);   // 공급자 보관용 + 공급받는자 보관용 2장
                rpt.PrintDirect(ItsPrinter.BarcodePrintName);
            }
            catch (Exception ex)
            {
                ShowMessageBox("", "자재이동은 등록되었으나 거래명세서 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
            }
        }

        public override void EventPopClose(string panelName)
        {
            base.EventPopClose(panelName);

            if (panelName == "PANEL_A1")
            {
                MODEL_G1.Clear();
                ResetWare();
                txt_BARCODE.Focus();
            }
        }
    }
}
