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

namespace TML1010
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R04 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();

        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();


        // 생성자
        public R04()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G2.Binding(GRID_G2);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            //TEST
            //ItsLocalInfo.TMLUID = "osc1";

            if (ItsLocalInfo.TMLCUSTCD != "")
            {
                cb_CUSTCD.Value = ItsLocalInfo.TMLCUSTCD.ToString();
            }

            PANEL_A1.Close();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "LIST_COMLOT")
            {
                ItsMaria.Set("TML1010_R04", "LIST_COMLOT");

                ItsMaria.AddModel(MODEL_S1);

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.SetData(ds.Tables[0]);
                (GRID_G1.View as TableView).BestFitColumns();
            }
            // 납품 등록
            else if (commandName == "MOVE_LOT") {

                if (MODEL_S1.GetValue("MOVECUSTCD").ToString() == "")
                {
                    ShowMessageBox("", "이동 거래처를 선택하세요.");
                    return;
                }

                string CUSTNM = string.Empty;
                string CUSTCD = MODEL_S1.GetValue("MOVECUSTCD").ToString();
                string query = "SELECT CUSTNM FROM MSTCUST WHERE CUSTCD = '" + CUSTCD + "';";

                DataSet ds = ItsMaria.Query(query);

                object value = ds.Tables[0].Rows[0]["CUSTNM"];

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (value == null || value == DBNull.Value)
                    {
                        CUSTNM = string.Empty;
                    }
                    else
                    {
                        CUSTNM = value.ToString();
                    }
                }
                string msg = "이동일자 : " + MODEL_S1.GetValue("MOVEDATE") + " 이동 거래처 : " + CUSTNM + "\r\n";
                ShowMessageBox(commandName, msg + "이동등록 진행 하시겠습니까??");
                return;
            }

            // 라벨재발행
            else if (commandName == "LABEL_REPRINT")
            {
                ItsMaria.Set("TML1010_R01", "LABEL_REPRINT");
                ItsMaria.AddOne("LOTKEY", MODEL_G2.GetText(MODEL_G2.CurrentIndex, "LOTKEY"));
                ItsMaria.AddOne("INWARE", MODEL_G2.GetText(MODEL_G2.CurrentIndex, "INWARE"));
                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 라벨출력 필요
                //ItsBarcode barcode = new ItsBarcode(ItsData.GetText(ds.Tables[0], 0, "LABELCD"));

                //barcode.SetDataTable(ds.Tables[1]);
                //barcode.PrinterName = ItsPrinter.DefaultPrintName;
                //barcode.Print(false);
            }
            // 납품 취소
            else if (commandName == "MTRCUST_INVOICE_CANCEL")
            {
                ShowMessageBox(commandName, "이동 취소 하시겠습니까??");
                return;
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            // 납품 취소
            if (commandName == "MTRCUST_INVOICE_CANCEL")
            {
                ItsMaria.Set("TML1010_R01", "DEL_MTRCUSTLOT");

                ItsMaria.AddModel(MODEL_A1);

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A1.Close();

                EventCommand("LIST_MTRODR");
            }
            // 납품 등록
            else if (commandName == "MOVE_LOT")
            {
                ItsMaria.Set("TML1010_R04", "MOVE_LOT");
                ItsMaria.AddOne("MOVEDATE", MODEL_S1.GetValue("MOVEDATE"));
                ItsMaria.AddOne("CUSTCD", MODEL_S1.GetValue("CUSTCD"));
                ItsMaria.AddOne("MOVECUSTCD", MODEL_S1.GetValue("MOVECUSTCD"));

                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    if (MODEL_G1.IsChecked(i))
                    {
                        ItsMaria.AddList("LOTKEY_LIST", MODEL_G1.GetText(i, "LOTKEY"));
                        ItsMaria.AddList("LOTQTY_LIST", MODEL_G1.GetText(i, "LOTQTY"));
                        ItsMaria.AddList("WARECD_LIST", MODEL_G1.GetText(i, "WARECD"));
                    }
                }

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A1.SetValue("INVOICEKEY", ds.Tables[0].Rows[0]["INVOICEKEY"]);
                MODEL_A1.SetValue("OUTDATE", ds.Tables[0].Rows[0]["MOVEDATE"]);
                MODEL_A1.SetValue("OUTCUSTCD", ds.Tables[0].Rows[0]["OUTCUSTCD"]);
                MODEL_A1.SetValue("INDATE", ds.Tables[0].Rows[0]["INDATE"]);
                MODEL_A1.SetValue("INCUSTCD", ds.Tables[0].Rows[0]["INCUSTCD"]);
                MODEL_G2.SetData(ds.Tables[0]);

                PANEL_A1.Show();
            }
        }

        public override void EventPopClose(string panelName)
        {
            base.EventPopClose(panelName);

            if (panelName == "PANEL_A1")
            {
                EventCommand("LIST_COMLOT");
            }
        }
    }
}

