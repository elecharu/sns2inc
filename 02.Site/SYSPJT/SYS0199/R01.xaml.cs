using System;
using System.Collections.Generic;
using System.Data;
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

namespace SYS0199
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageOffice
    {
        ITSLIB.Column CN_COL = new Column();
        ITSLIB.Column JP_COL = new Column();
        ITSLIB.Column EN_COL = new Column();

        //ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_P1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();

        // 생성자
        public R01()
        {
            InitializeComponent();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.EventRowChanged += MODEL_G1_EventRowChanged;

            MODEL_G2.Binding(GRID_G2);
            MODEL_G2.AddKey("LANGKEY");
            MODEL_G2.EventValueChanged += MODEL_G2_EventValueChanged;
        }

        private void MODEL_G2_EventValueChanged(int rowIndex, string fieldName)
        {

            if (fieldName == "KR" || fieldName == "CN" || fieldName == "JP" || fieldName == "EN")
            {
                ItsMaria.Set("SYS0199_R01", "UP_LANG");
                ItsMaria.AddModel(MODEL_G2, rowIndex);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                    return;
                }
            }
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();
            //GRID_G2.IsShowDetail = false;

            CN_COL = GRID_G2.Columns.GetColumnByFieldName("CN") as ITSLIB.Column;
            JP_COL = GRID_G2.Columns.GetColumnByFieldName("JP") as ITSLIB.Column;
            EN_COL = GRID_G2.Columns.GetColumnByFieldName("EN") as ITSLIB.Column;

            EventSearch();

        }

        // FLEX 행 이동 MODEL 변경 시
        private void MODEL_G1_EventRowChanged(int rowIndex)
        {

                // 해당 행 품목별BOM 조회
                ItsMaria.Set("SYS0199_R01", "LANG_LIST");
                ItsMaria.AddOne("PRGCD", MODEL_G1.GetText(MODEL_G1.CurrentIndex,"PRGCD"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                    return;
                }

                // FLEX에 바인딩 
               MODEL_G2.SetData(ds.Tables[0]);
        }

        // 삭제
        public override void EventDelete()
        {
            base.EventDelete();

            // 질문메시지 박스, YES일 경우만 처리
            if (ItsMsgBox.ShowYesNo("선택한 항목을 삭제하시겠습니까?") == true)
            {
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0199_R01", "DEL_LANG");
                        ItsMaria.AddModel(MODEL_G2,i);
                        DataSet ds = ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                        }
                    }
                }
                EventSearch();
            }
        }

        // 조회
        public override void EventSearch()
        {
            base.EventSearch();

            ItsMaria.Set("SYS0199_R01", "PRG_LIST");
            DataSet ds1 = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                return;
            }

            // FLEX에 바인딩 
            MODEL_G1.SetData(ds1.Tables[0]);

            //MODEL_G1_EventRowChanged(MODEL_G1.CurrentIndex);
        }

        private void CN_Checked(object sender, RoutedEventArgs e)
        {
            CN_COL.Visible = true;
        }

        private void CN_Unchecked(object sender, RoutedEventArgs e)
        {
            CN_COL.Visible = false;
        }
        private void JP_Checked(object sender, RoutedEventArgs e)
        {
            JP_COL.Visible = true;
        }

        private void JP_Unchecked(object sender, RoutedEventArgs e)
        {
            JP_COL.Visible = false;
        }
        private void EN_Checked(object sender, RoutedEventArgs e)
        {
            EN_COL.Visible = true;
        }

        private void EN_Unchecked(object sender, RoutedEventArgs e)
        {
            EN_COL.Visible = false;
        }
    }
}

