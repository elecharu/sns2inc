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

namespace SYS8801
{
    /// <summary>
    /// S01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class S01 : ITSLIB.ItsPageOffice
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();

        public S01()
        {
            InitializeComponent();
            // 최초 시작시 조회영역에 모델 설정
            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.DefaultValue("SDATE", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));
            MODEL_S1.DefaultValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.InitData();

            MODEL_G1.Binding(GRID_G1);

            // 조회영역 컨트롤 ENTER키 눌렀을때 자동 조회 설정
            PANEL_S1.SetEnterSearch();
            PANEL_S1.SetEnterTab();
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

        }

        // 발주 조회
        public override void EventSearch()
        {
            base.EventSearch();

            ItsMaria.Set("SYS8801_S01", "LIST_MTREXPLOG");
            ItsMaria.AddModel(MODEL_S1);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                return;
            }

            // FLEX에 바인딩 
            MODEL_G1.SetData(ds.Tables[0]);
        }
    }
}
