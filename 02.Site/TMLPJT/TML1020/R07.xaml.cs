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
    /// // 2026-11-16 [유상사급 자재입고확인] 외주처 자재이동(TML1010 R06) 거래명세서 → 입고확인 = 사내창고(04S100_N) → 자재투입창고(04S111_N) 재고이동 (입고 아님)
    /// 외주처가 자재이동(TML1010 R06)한 거래명세서번호 또는 LOT번호를 바코드 스캔 → 그 거래명세서의 LOT 목록이 쌓임
    /// [등록] 하면 스캔한 거래명세서들을 입고일자로 사내창고에서 자재투입창고로 이동 (ERP WORK_10 송신, 프로시저 TML1020_R07)
    /// </summary>
    public partial class R07 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();

        public R07()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.InitData();
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            MODEL_S1.SetValue("MTRINDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("BARCODE", "");
            txt_BARCODE.Focus();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

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

                ShowMessageBox(commandName, MODEL_S1.GetText("MTRINDATE") + " 일자로 거래명세서 " + invoiceKeys.Count + "건 (LOT " + MODEL_G1.Rows.Count + "개)을 입고확인(자재투입창고로 이동) 하시겠습니까?");
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

            if (commandName == "ADD_MTRIN")
            {
                ItsMaria.Set("TML1020_R07", "ADD_MTRIN");
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

                // 2026-11-16 유상사급 자재입고확인은 출력물 없음
                ShowMessageBox("", "입고확인 되었습니다. (자재투입창고로 이동)");
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

            ItsMaria.Set("TML1020_R07", "SCAN_BARCODE");
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
