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

namespace TML1010
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class S01 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_S2 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();



        // 생성자
        public S01()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S2.Binding(PANEL_A1);
            MODEL_S2.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G2.Binding(GRID_G2);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A1.Close();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "SEARCH")
            {
                ItsMaria.Set("TML1010_S01", "LIST_ITEM");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.SetData(ds.Tables[0]);
            }

            else if (commandName == "LOT_SEARCH")
            {
                MODEL_S2.SetValue("WARENM", MODEL_G1.GetValue(MODEL_G1.CurrentIndex, "WARENM"));
                MODEL_S2.SetValue("ITEMCD", MODEL_G1.GetValue(MODEL_G1.CurrentIndex, "ITEMCD"));
                MODEL_S2.SetValue("ITEMNM", MODEL_G1.GetValue(MODEL_G1.CurrentIndex, "ITEMNM"));

                ItsMaria.Set("TML1010_S01", "LIST_LOT");
                ItsMaria.AddModel(MODEL_G1, MODEL_G1.CurrentIndex);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G2.SetData(ds.Tables[0]);
                PANEL_A1.Show();
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
    }
}

