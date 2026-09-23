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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using System.Data;
using DevExpress.Xpf.Core.Native;
using System.Windows.Threading;
using DevExpress.Xpf.Charts;

namespace SYS0000
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageOffice
    {
        ////공통타입헤더 조회 항목
        //ItsModelPanel MODEL_S1 = new ItsModelPanel();

        // 생성자
        public R01()
        {         

            InitializeComponent();
            //this.DataContext = MODEL_S1;

            this.Loaded += R01_Loaded;
        }

        private void R01_Loaded(object sender, RoutedEventArgs e)
        {

            ItsMaria.Set("SYS0000_R01", "MAIN_MONITOR");
            ItsMaria.AddOne("SDATE", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));
            ItsMaria.AddOne("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                return;
            }

            // 시리즈 생성
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {

                CHART_PERF_ARG1.Value = Convert.ToDouble(dt.Rows[0]["PERFORMANCE"]);
                CHART_PERF_ARG2.Value = 100 - Convert.ToDouble(dt.Rows[0]["PERFORMANCE"]);

                CHART_NON.Points.Clear();
                CHART_BAD.Points.Clear();

                if(dt.Rows[0]["NON_TOP1"].ToString() != "-")
                {
                    SeriesPoint SP1 = new SeriesPoint();
                    SP1.Argument = "TOP 1";
                    SP1.Value = Convert.ToDouble(dt.Rows[0]["NON_TOP1_CNT"]);
                    SP1.Brush = new SolidColorBrush(Colors.IndianRed);
                    CHART_NON.Points.Add(SP1);
                }

                if (dt.Rows[0]["NON_TOP2"].ToString() != "-")
                {
                    SeriesPoint SP2 = new SeriesPoint();
                    SP2.Argument = "TOP 2";
                    SP2.Value = Convert.ToDouble(dt.Rows[0]["NON_TOP2_CNT"]);
                    SP2.Brush = new SolidColorBrush(Colors.PaleVioletRed);
                    CHART_NON.Points.Add(SP2);
                }
                if (dt.Rows[0]["NON_TOP3"].ToString() != "-")
                {
                    SeriesPoint SP3 = new SeriesPoint();
                    SP3.Argument = "TOP 3";
                    SP3.Value = Convert.ToDouble(dt.Rows[0]["NON_TOP3_CNT"]);
                    SP3.Brush = new SolidColorBrush(Colors.LightPink);
                    CHART_NON.Points.Add(SP3);
                }
                if (dt.Rows[0]["NON_TOP4"].ToString() != "-")
                {
                    SeriesPoint SP4 = new SeriesPoint();
                    SP4.Argument = "TOP 4";
                    SP4.Value = Convert.ToDouble(dt.Rows[0]["NON_TOP4_CNT"]);
                    SP4.Brush = new SolidColorBrush(Colors.SkyBlue);
                    CHART_NON.Points.Add(SP4);
                }
                if (dt.Rows[0]["NON_TOP5"].ToString() != "-")
                {
                    SeriesPoint SP5 = new SeriesPoint();
                    SP5.Argument = "TOP 5";
                    SP5.Value = Convert.ToDouble(dt.Rows[0]["NON_TOP5_CNT"]);
                    SP5.Brush = new SolidColorBrush(Colors.LightSkyBlue);
                    CHART_NON.Points.Add(SP5);
                }

                //
                if (dt.Rows[0]["BAD_TOP1"].ToString() != "-")
                {
                    SeriesPoint SP6 = new SeriesPoint();
                    SP6.Argument = "TOP 1";
                    SP6.Value = Convert.ToDouble(dt.Rows[0]["BAD_TOP1_CNT"]);
                    SP6.Brush = new SolidColorBrush(Colors.IndianRed);
                    CHART_BAD.Points.Add(SP6);
                }
                if (dt.Rows[0]["BAD_TOP2"].ToString() != "-")
                {
                    SeriesPoint SP7 = new SeriesPoint();
                    SP7.Argument = "TOP 2";
                    SP7.Value = Convert.ToDouble(dt.Rows[0]["BAD_TOP2_CNT"]);
                    SP7.Brush = new SolidColorBrush(Colors.PaleVioletRed);
                    CHART_BAD.Points.Add(SP7);
                }
                if (dt.Rows[0]["BAD_TOP3"].ToString() != "-")
                {
                    SeriesPoint SP8 = new SeriesPoint();
                    SP8.Argument = "TOP 3";
                    SP8.Value = Convert.ToDouble(dt.Rows[0]["BAD_TOP3_CNT"]);
                    SP8.Brush = new SolidColorBrush(Colors.LightPink);
                    CHART_BAD.Points.Add(SP8);
                }
                if (dt.Rows[0]["BAD_TOP4"].ToString() != "-")
                {
                    SeriesPoint SP9 = new SeriesPoint();
                    SP9.Argument = "TOP 4";
                    SP9.Value = Convert.ToDouble(dt.Rows[0]["BAD_TOP4_CNT"]);
                    SP9.Brush = new SolidColorBrush(Colors.SkyBlue);
                    CHART_BAD.Points.Add(SP9);
                }
                if (dt.Rows[0]["BAD_TOP5"].ToString() != "-")
                {
                    SeriesPoint SP10 = new SeriesPoint();
                    SP10.Argument = "TOP 5";
                    SP10.Value = Convert.ToDouble(dt.Rows[0]["BAD_TOP5_CNT"]);
                    SP10.Brush = new SolidColorBrush(Colors.LightSkyBlue);
                    CHART_BAD.Points.Add(SP10);
                }
               // MODEL_S1.SetData(dt);
            }));
            this.DataContext = dt;
        }
        public override void EventSearch()
        {
            base.EventSearch();
            R01_Loaded(null,null);
        }
    }
}

