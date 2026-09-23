using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ITSLIB
{
    /// <summary>
    /// Interaction logic for ItsQueryWin.xaml
    /// </summary>
    public partial class ItsQueryWin : Window
    {
        public struct ROWDATA
        {
            public string NAME1 { set; get; }
            public string VALUE1 { set; get; }
            public string NAME2 { set; get; }
            public string VALUE2 { set; get; }
            public string NAME3 { set; get; }
            public string VALUE3 { set; get; }
        }

        public ItsQueryWin()
        {
            InitializeComponent();
            this.Topmost = true;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Loaded += ItsQueryWin_Loaded;
        }

        private void ItsQueryWin_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= ItsQueryWin_Loaded;

            string Query = ItsMaria.Get();
            TEXTBOX.Text = Query;

            if (ITSTML.App._RunErrMsg != "")
            {
                TEXTBOX.Text = Query + "\r\n\r\n" + ITSTML.App._RunErrMsg;
            }

            try
            {
                // CONNSTR.Text = ItsMaria.ConnString;
                string[] connStr = ItsMaria.ConnString.ToLower().Split(new string[] { "uid=" }, StringSplitOptions.None);
                CONNSTR.Text = connStr[0] + connStr[1].Split(new string[] { ";" }, StringSplitOptions.None)[2];
            }
            catch { }

            try
            {
                PROCNAME.Text = Query.Split(new string[] { "CALL COMCALLC ('" }, StringSplitOptions.None)[1].Split(new string[] { "'" }, StringSplitOptions.None)[0];
            }
            catch { }

            try
            {
                CALLTYPE.Text = Query.Split(new string[] { "','" }, StringSplitOptions.None)[1].Split(new string[] { "'" }, StringSplitOptions.None)[0];
            }
            catch { }

            try
            {
                TRANYN.Text = Query.Split(new string[] { "','" }, StringSplitOptions.None)[2].Split(new string[] { "'" }, StringSplitOptions.None)[0];
            }
            catch { }

            string[] nameList = new string[3];
            string[] valueList = new string[3];

            int rowIndex = 0;
            int columnIndex = -1; 
            string[] nameValueList = Query.Split(new string[] { "┃" }, StringSplitOptions.None);
            for(int i = 1; i < nameValueList.Length - 1; i++ )
            {
                columnIndex++;

                string[] nameValue = nameValueList[i].Split(new string[] { "»" }, StringSplitOptions.None);
                nameList[columnIndex] = nameValue[0];
                valueList[columnIndex] = nameValue[1];

                if (columnIndex >= 2)
                {
                    columnIndex = -1;
                    rowIndex++;

                    GRID_VALUE.Items.Add(new ROWDATA()
                    {
                        NAME1 = nameList[0],
                        VALUE1 = valueList[0],
                        NAME2 = nameList[1],
                        VALUE2 = valueList[1],
                        NAME3 = nameList[2],
                        VALUE3 = valueList[2]
                    });

                    nameList = new string[3];
                    valueList = new string[3];
                }
            }

            if (columnIndex > -1)
            {
                GRID_VALUE.Items.Add(new ROWDATA()
                {
                    NAME1 = nameList[0],
                    VALUE1 = valueList[0],
                    NAME2 = nameList[1],
                    VALUE2 = valueList[1],
                    NAME3 = nameList[2],
                    VALUE3 = valueList[2]
                });
            }
        }

        private void COPY_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TEXTBOX.Text.Trim());
            this.Close();
        }
    }
}
