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
    public partial class S03 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();

        // 생성자
        public S03()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_G1.Binding(GRID_G1);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "LIST_OSC_LOT")
            {
                ItsMaria.Set("TML1010_S03", "LIST_OSC_LOT");
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
        }
    }
}

