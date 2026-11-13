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
using System.IO;
using System.Xml;
using System.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using DevExpress.Xpf.Grid;

namespace TML1020
{
    /// <summary>
    /// // 2026-11-09 [입고등록] 입고확인처리
    /// 외주처가 납품등록(TML1010)한 거래명세서번호 또는 LOT번호를 바코드 스캔 → 그 거래명세서의 LOT 목록이 쌓임
    /// [등록] 하면 스캔한 거래명세서들을 입고일자로 입고 (원자재 자재창고, 반제품 재공품창고, 상품 상품창고, 시편 시편창고)
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelPanel MODEL_S2 = new ItsModelPanel();   // [입고취소] 탭 조회조건
        ItsModelGrid MODEL_G2 = new ItsModelGrid();     // [입고취소] 탭 입고 목록

        public R01()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.InitData();

            MODEL_S2.Binding(PANEL_S2);
            MODEL_S2.InitData();

            MODEL_G2.Binding(GRID_G2);
            MODEL_G2.InitData();
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            MODEL_S1.SetValue("MTRINDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("BARCODE", "");

            MODEL_S2.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));

            txt_BARCODE.Focus();
        }

        // ===== [입고취소] 탭 : 입고된 거래명세서 조회 / 입고 취소 (프로시저 TML1020_R01 LIST_MTRIN, CANCEL_MTRIN → IO_MTRINVOICE_CANCEL) =====
        private void SearchMtrin()
        {
            ItsMaria.Set("TML1020_R01", "LIST_MTRIN");
            ItsMaria.AddModel(MODEL_S2);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            MODEL_G2.SetData(ds.Tables[0]);
        }

        // 조회·입고취소 버튼 처리. 처리했으면 true
        private bool EventCommandHistory(string commandName)
        {
            if (commandName == "SEARCH_MTRIN")
            {
                if (MODEL_S2.GetText("SDATE") == "" || MODEL_S2.GetText("EDATE") == "")
                {
                    ShowMessageBox("", "입고일자를 선택하세요.");
                    return true;
                }

                SearchMtrin();
                return true;
            }
            else if (commandName == "CANCEL_MTRIN")
            {
                int cnt = 0;
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i)) cnt++;
                }
                if (cnt == 0)
                {
                    ShowMessageBox("", "입고 취소할 거래명세서를 체크하세요.");
                    return true;
                }

                ShowMessageBox(commandName, "체크한 거래명세서 " + cnt + "건의 입고를 취소하시겠습니까?\n(입고대기 상태로 되돌립니다)");
                return true;
            }

            return false;
        }

        // 입고취소 확인 후 처리. 처리했으면 true
        private bool EventMessageHistory(string commandName)
        {
            if (commandName != "CANCEL_MTRIN") return false;

            ItsMaria.Set("TML1020_R01", "CANCEL_MTRIN");
            int cnt = 0;
            for (int i = 0; i < MODEL_G2.ModelCount; i++)
            {
                if (!MODEL_G2.IsChecked(i)) continue;

                ItsMaria.AddList("INVOICEKEY_LIST", MODEL_G2.GetText(i, "INVOICEKEY"));
                cnt++;
            }
            ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return true;
            }

            ShowMessageBox("", "입고 취소되었습니다. (" + cnt + "건)");
            SearchMtrin();
            return true;
        }
        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (EventCommandHistory(commandName)) return;

            // 입고 등록
            if (commandName == "ADD_MTRIN")
            {
                if (MODEL_S1.GetText("MTRINDATE") == "")
                {
                    ShowMessageBox("", "입고일자를 선택하세요.");
                    return;
                }

                List<string> invoiceKeys = GetInvoiceKeys();
                if (invoiceKeys.Count == 0)
                {
                    ShowMessageBox("", "입고할 거래명세서번호 또는 LOT번호를 스캔하세요.");
                    return;
                }

                ShowMessageBox(commandName, MODEL_S1.GetText("MTRINDATE") + " 일자로 거래명세서 " + invoiceKeys.Count + "건 (LOT " + MODEL_G1.Rows.Count + "개)을 입고하시겠습니까?");
            }
            // 스캔 목록 비우기
            else if (commandName == "CLEAR_SCAN")
            {
                MODEL_G1.Clear();
                MODEL_S1.SetValue("BARCODE", "");
                txt_BARCODE.Focus();
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (EventMessageHistory(commandName)) return;

            if (commandName == "ADD_MTRIN")
            {
                ItsMaria.Set("TML1020_R01", "ADD_MTRIN");
                ItsMaria.AddOne("MTRINDATE", MODEL_S1.GetText("MTRINDATE"));
                List<string> invoiceKeys = GetInvoiceKeys();   // 입고한 거래명세서 (등록 후 목록을 비우기 전에 담아 둠)
                foreach (string invoiceKey in invoiceKeys)
                {
                    ItsMaria.AddList("INVOICEKEY_LIST", invoiceKey);
                }

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.Clear();
                MODEL_S1.SetValue("BARCODE", "");

                // 입고된 LOT 마다 공정이동표(재고) 출력 (확인창 없이 POP 에서 고른 프린터로). 양식은 COMPJT\TMLPRINT 의 MTR_2
                // 거래명세서는 납품등록(TML1010 R01) 에서 출력하므로 입고등록에서는 출력하지 않음
                try
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        TMLPRINT.MTR_2 rptMove = new TMLPRINT.MTR_2(ds.Tables[0]);
                        rptMove.PrintDirect(ItsPrinter.BarcodePrintName);
                    }
                    ShowMessageBox("", "입고되었습니다.");
                }
                catch (Exception ex)
                {
                    ShowMessageBox("", "입고는 되었으나 공정이동표 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
                }
                txt_BARCODE.Focus();
            }
        }

        // 바코드 스캔 (스캐너가 Enter 를 붙여 보냄)
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            string barcode = MODEL_S1.GetText("BARCODE").Trim();
            MODEL_S1.SetValue("BARCODE", "");
            if (barcode == "") return;

            ItsMaria.Set("TML1020_R01", "SCAN_BARCODE");
            ItsMaria.AddOne("BARCODE", barcode);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0) return;

            // 같은 거래명세서를 다시 스캔하면 (LOT 번호로 스캔해도) 추가하지 않음
            string invoiceKey = ItsData.GetText(dt, 0, "INVOICEKEY");
            if (GetInvoiceKeys().Contains(invoiceKey))
            {
                ShowMessageBox("", "이미 스캔한 거래명세서입니다. (" + invoiceKey + ")");
                return;
            }

            if (MODEL_G1.Rows.Count == 0)
            {
                MODEL_G1.SetData(dt);
            }
            else
            {
                MODEL_G1.AddRow(dt);
            }
            (GRID_G1.View as TableView).BestFitColumns();

            txt_BARCODE.Focus();
        }

        // 스캔 목록의 거래명세서번호 (중복 제거)
        private List<string> GetInvoiceKeys()
        {
            List<string> keys = new List<string>();
            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                string key = MODEL_G1.GetText(i, "INVOICEKEY");
                if (key != "" && !keys.Contains(key)) keys.Add(key);
            }
            return keys;
        }
    }
}
