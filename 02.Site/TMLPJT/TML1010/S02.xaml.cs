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
    public partial class S02 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_S2 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_G3 = new ItsModelGrid();



        // 생성자
        public S02()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S2.Binding(PANEL_A1);
            MODEL_S2.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G2.Binding(GRID_G2);
            MODEL_G3.Binding(GRID_G3);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A1.Close();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "SEL_RST")
            {
                ItsMaria.Set("TML1010_S02", "LIST_RST");
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
            else if (commandName == "SEL_RST_DETAIL")
            {
                MODEL_S2.InitData();
                MODEL_G2.InitData();
                MODEL_G2.InitData();

                ItsMaria.Set("TML1010_S02", "LIST_RST_DETAIL");
                ItsMaria.AddModel(MODEL_G1, MODEL_G1.CurrentIndex);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_S2.SetData(ds.Tables[0]);
                MODEL_G2.SetData(ds.Tables[1]);
                MODEL_G3.SetData(ds.Tables[2]);
                PANEL_A1.Show();
            }
            else if (commandName == "DEL_RSTLOT")
            {
                ItsMaria.Set("TML1010_S02", "DEL_RSTLOT");
                ItsMaria.AddModel(MODEL_S2);
                ItsMaria.AddModel(MODEL_G2, MODEL_G2.CurrentIndex);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEL_RST_DETAIL");
            }
            else if (commandName == "DEL_RSTSAMPLE")
            {
                ItsMaria.Set("TML1010_S02", "DEL_RSTSAMPLE");
                ItsMaria.AddModel(MODEL_S2);
                ItsMaria.AddModel(MODEL_G3, MODEL_G3.CurrentIndex);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEL_RST_DETAIL");
            }

            else if (commandName == "LABEL_PRINT")
            {
                ItsMaria.Set("TML1010_S01", "PRINT");
                ItsMaria.AddOne("ITEMCD", MODEL_S2.GetText("ITEMID"));

                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i))
                    {
                        ItsMaria.AddList("WARECDLIST", MODEL_G2.GetText(i, "WARECD"));
                        ItsMaria.AddList("LOTKEYLIST", MODEL_G2.GetText(i, "LOTKEY"));
                    }
                }
                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                ItsBarcode barcode = new ItsBarcode(ItsData.GetText(ds.Tables[0], 0, "LABELCD"));

                barcode.SetDataTable(ds.Tables[1]);
                //barcode.PrinterName = ItsPrinter.DefaultPrintName;
                barcode.Print(false);

            }
        }

        public override void EventPopClose(string panelName)
        {
            base.EventPopClose(panelName);

            if (panelName == "PANEL_A1")
            {
                EventCommand("SEL_RST");
            }
        }
    }
}

