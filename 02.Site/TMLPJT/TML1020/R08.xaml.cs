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
    /// // 2026-11-16 [유상사급 자재반출] 입고확인이 끝난 거래명세서 바코드 스캔 → [등록] 하면 입고확인·자재이동·납품등록 3건 삭제, ERP 는 D 로 역순 전송, 반출번호·반출일자 이력 저장
    /// 입고확인(TML1020 R07)이 끝난 자재이동 거래명세서번호 또는 LOT번호를 바코드 스캔 → 그 거래명세서의 LOT 목록이 쌓임 (프로시저 TML1020_R08)
    /// 반출수량은 수정할 수 있으나 입고확인 수량 전량이어야 반출됨. 자재반출증(유상사급) 출력은 TMLPRINT 양식이 만들어지면 PRINT_MOVEOUT 데이터로 연결
    /// </summary>
    public partial class R08 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();

        public R08()
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

            MODEL_S1.SetValue("MOVEDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("BARCODE", "");
            txt_BARCODE.Focus();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 입고 등록
            if (commandName == "ADD_MOVEOUT")
            {
                if (MODEL_S1.GetText("MOVEDATE") == "")
                {
                    ShowMessageBox("", "반출일자를 선택하세요.");
                    return;
                }

                List<string> invoiceKeys = GetInvoiceKeys();
                if (invoiceKeys.Count == 0)
                {
                    ShowMessageBox("", "반출할 거래명세서번호 또는 LOT번호를 스캔하세요.");
                    return;
                }

                ShowMessageBox(commandName, MODEL_S1.GetText("MOVEDATE") + " 일자로 거래명세서 " + invoiceKeys.Count + "건 (LOT " + MODEL_G1.Rows.Count + "개)을 반출하시겠습니까?\n입고확인·자재이동·납품등록이 삭제됩니다.");
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

            if (commandName == "ADD_MOVEOUT")
            {
                ItsMaria.Set("TML1020_R08", "ADD_MOVEOUT");
                ItsMaria.AddOne("MOVEDATE", MODEL_S1.GetText("MOVEDATE"));
                List<string> invoiceKeys = GetInvoiceKeys();   // 반출한 거래명세서
                foreach (string invoiceKey in invoiceKeys)
                {
                    ItsMaria.AddList("INVOICEKEY_LIST", invoiceKey);
                }
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    ItsMaria.AddList("LOTKEY_LIST", MODEL_G1.GetText(i, "LOTKEY"));
                    ItsMaria.AddList("MOVEQTY_LIST", MODEL_G1.GetDecimal(i, "MOVEQTY"));
                }

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.Clear();
                MODEL_S1.SetValue("BARCODE", "");

                // 반출번호 (자재반출증 출력은 TMLPRINT 양식이 만들어지면 TML1020_R08 PRINT_MOVEOUT 으로 연결)
                ShowMessageBox("", "반출되었습니다. (" + ItsData.GetText(ds.Tables[0], 0, "CNT") + "건)\n- 반출번호: " + ItsData.GetText(ds.Tables[0], 0, "MOVEOUTKEY"));
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

            ItsMaria.Set("TML1020_R08", "SCAN_BARCODE");
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
