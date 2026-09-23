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

namespace SYS0101
{
    /// <summary>
    /// R02.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R02 : ITSLIB.ItsPageOffice
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();

        // 생성자
        public R02()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.AddKey("TPCD");
            MODEL_A1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.AddKey("GPCD1");
            MODEL_G1.EventRowChanged += MODEL_G1_EventRowChanged;

            MODEL_G2.Binding(GRID_G2);
            MODEL_G2.AddKey("TPCD");

            // 조회영역 컨트롤 ENTER키 눌렀을때 자동 조회 설정
            PANEL_S1.SetEnterSearch();

            // 컨트롤 영역 ENTER키 눌렀을때 자동 탭 이동
            PANEL_A1.SetEnterTab();

        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();            
            PANEL_A1.Close();
            GRID_G2.IsShowDetail = false;
        }

        public override void EventAdd()
        {
            base.EventAdd();
            PANEL_A1.Show();
            ItsMaria.Set("SYS0101_R02", "LIST_COMTYPE");
            ItsMaria.AddModel(MODEL_G1, MODEL_G1.CurrentIndex);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                return;
            }

            // 추가패널 라벨명 변경 및 빈값 일경우 텍스트박스 표시 안함
            if (ItsData.GetText(ds.Tables[0], 0, "REF01NM") == "") REF01.Visibility = Visibility.Collapsed;
            else REF01.Visibility = Visibility.Visible; REF01.Label = ItsData.GetText(ds.Tables[0], 0, "REF01NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF02NM") == "") REF02.Visibility = Visibility.Collapsed;
            else REF02.Visibility = Visibility.Visible; REF02.Label = ItsData.GetText(ds.Tables[0], 0, "REF02NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF03NM") == "") REF03.Visibility = Visibility.Collapsed;
            else REF03.Visibility = Visibility.Visible; REF03.Label = ItsData.GetText(ds.Tables[0], 0, "REF03NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF04NM") == "") REF04.Visibility = Visibility.Collapsed;
            else REF04.Visibility = Visibility.Visible; REF04.Label = ItsData.GetText(ds.Tables[0], 0, "REF04NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF05NM") == "") REF05.Visibility = Visibility.Collapsed;
            else REF05.Visibility = Visibility.Visible; REF05.Label = ItsData.GetText(ds.Tables[0], 0, "REF05NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF06NM") == "") REF06.Visibility = Visibility.Collapsed;
            else REF06.Visibility = Visibility.Visible; REF06.Label = ItsData.GetText(ds.Tables[0], 0, "REF06NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF07NM") == "") REF07.Visibility = Visibility.Collapsed;
            else REF07.Visibility = Visibility.Visible; REF07.Label = ItsData.GetText(ds.Tables[0], 0, "REF07NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF08NM") == "") REF08.Visibility = Visibility.Collapsed;
            else REF08.Visibility = Visibility.Visible; REF08.Label = ItsData.GetText(ds.Tables[0], 0, "REF08NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF09NM") == "") REF09.Visibility = Visibility.Collapsed;
            else REF09.Visibility = Visibility.Visible; REF09.Label = ItsData.GetText(ds.Tables[0], 0, "REF09NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF10NM") == "") REF10.Visibility = Visibility.Collapsed;
            else REF10.Visibility = Visibility.Visible; REF10.Label = ItsData.GetText(ds.Tables[0], 0, "REF10NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF11NM") == "") REF11.Visibility = Visibility.Collapsed;
            else REF11.Visibility = Visibility.Visible; REF11.Label = ItsData.GetText(ds.Tables[0], 0, "REF11NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF12NM") == "") REF12.Visibility = Visibility.Collapsed;
            else REF12.Visibility = Visibility.Visible; REF12.Label = ItsData.GetText(ds.Tables[0], 0, "REF12NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF13NM") == "") REF13.Visibility = Visibility.Collapsed;
            else REF13.Visibility = Visibility.Visible; REF13.Label = ItsData.GetText(ds.Tables[0], 0, "REF13NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF14NM") == "") REF14.Visibility = Visibility.Collapsed;
            else REF14.Visibility = Visibility.Visible; REF14.Label = ItsData.GetText(ds.Tables[0], 0, "REF14NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF15NM") == "") REF15.Visibility = Visibility.Collapsed;
            else REF15.Visibility = Visibility.Visible; REF15.Label = ItsData.GetText(ds.Tables[0], 0, "REF15NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF16NM") == "") REF16.Visibility = Visibility.Collapsed;
            else REF16.Visibility = Visibility.Visible; REF16.Label = ItsData.GetText(ds.Tables[0], 0, "REF16NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF17NM") == "") REF17.Visibility = Visibility.Collapsed;
            else REF17.Visibility = Visibility.Visible; REF17.Label = ItsData.GetText(ds.Tables[0], 0, "REF17NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF18NM") == "") REF18.Visibility = Visibility.Collapsed;
            else REF18.Visibility = Visibility.Visible; REF18.Label = ItsData.GetText(ds.Tables[0], 0, "REF18NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF19NM") == "") REF19.Visibility = Visibility.Collapsed;
            else REF19.Visibility = Visibility.Visible; REF19.Label = ItsData.GetText(ds.Tables[0], 0, "REF19NM");
            if (ItsData.GetText(ds.Tables[0], 0, "REF20NM") == "") REF20.Visibility = Visibility.Collapsed;
            else REF20.Visibility = Visibility.Visible; REF20.Label = ItsData.GetText(ds.Tables[0], 0, "REF20NM");

        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);
            if (commandName == "PANEL_A1")
            {
                ItsMaria.Set("SYS0101_R02", "ADD_COMTYPE");
                ItsMaria.AddOne("GPCD1", MODEL_G1.GetText(MODEL_G1.CurrentIndex,"GPCD1"));
                ItsMaria.AddModel(MODEL_A1);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                    return;
                }
                MODEL_G2.SetKey(MODEL_A1.GetKey());
                MODEL_A1.InitData();
            }
            this.EventSearch();
        }

        private void MODEL_G1_EventRowChanged(int rowIndex)
        {
            // 왼쪽 그리드 선택시 ADD 접기
            PANEL_A1.Close();
 
            // 해당 행 공통타입헤더에 맞는 공통타입디테일 조회
            ItsMaria.Set("SYS0101_R02", "LIST_COMTYPE");
            ItsMaria.AddModel(MODEL_G1, rowIndex);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                return;
            }

            // 컬럼 헤더 바꾸기
            GRID_G2.Columns["REF01"].Header = ItsData.GetText(ds.Tables[0], 0, "REF01NM");
            GRID_G2.Columns["REF02"].Header = ItsData.GetText(ds.Tables[0], 0, "REF02NM");
            GRID_G2.Columns["REF03"].Header = ItsData.GetText(ds.Tables[0], 0, "REF03NM");
            GRID_G2.Columns["REF04"].Header = ItsData.GetText(ds.Tables[0], 0, "REF04NM");
            GRID_G2.Columns["REF05"].Header = ItsData.GetText(ds.Tables[0], 0, "REF05NM");
            GRID_G2.Columns["REF06"].Header = ItsData.GetText(ds.Tables[0], 0, "REF06NM");
            GRID_G2.Columns["REF07"].Header = ItsData.GetText(ds.Tables[0], 0, "REF07NM");
            GRID_G2.Columns["REF08"].Header = ItsData.GetText(ds.Tables[0], 0, "REF08NM");
            GRID_G2.Columns["REF09"].Header = ItsData.GetText(ds.Tables[0], 0, "REF09NM");
            GRID_G2.Columns["REF10"].Header = ItsData.GetText(ds.Tables[0], 0, "REF10NM");
            GRID_G2.Columns["REF11"].Header = ItsData.GetText(ds.Tables[0], 0, "REF11NM");
            GRID_G2.Columns["REF12"].Header = ItsData.GetText(ds.Tables[0], 0, "REF12NM");
            GRID_G2.Columns["REF13"].Header = ItsData.GetText(ds.Tables[0], 0, "REF13NM");
            GRID_G2.Columns["REF14"].Header = ItsData.GetText(ds.Tables[0], 0, "REF14NM");
            GRID_G2.Columns["REF15"].Header = ItsData.GetText(ds.Tables[0], 0, "REF15NM");
            GRID_G2.Columns["REF16"].Header = ItsData.GetText(ds.Tables[0], 0, "REF16NM");
            GRID_G2.Columns["REF17"].Header = ItsData.GetText(ds.Tables[0], 0, "REF17NM");
            GRID_G2.Columns["REF18"].Header = ItsData.GetText(ds.Tables[0], 0, "REF18NM");
            GRID_G2.Columns["REF19"].Header = ItsData.GetText(ds.Tables[0], 0, "REF19NM");
            GRID_G2.Columns["REF20"].Header = ItsData.GetText(ds.Tables[0], 0, "REF20NM");

            // FLEX에 바인딩 
            MODEL_G2.SetData(ds.Tables[0]);
        }

        // 조회
        public override void EventSearch()
        {
            base.EventSearch();

            ItsMaria.Set("SYS0101_R02", "LIST_COMTYPEGP");
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

        // 삭제
        public override void EventDelete()
        {
            base.EventDelete();

            if (ItsMsgBox.ShowYesNo("선택항목을 삭제하시겠습니까?") == true)
            {
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0101_R02", "DEL_COMTYPE");
                        ItsMaria.AddModel(MODEL_G2, i);
                        DataSet ds = ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                        }
                    }
                }
                MODEL_G1_EventRowChanged(MODEL_G1.CurrentIndex);
            }
        }

        // 저장
        public override void EventSave()
        {
            base.EventSave();

            // FLEX 저장
            for (int i = 0; i < MODEL_G2.ModelCount; i++)
            {
                if (MODEL_G2.IsChecked(i))
                {
                    ItsMaria.Set("SYS0101_R02", "UP_COMTYPE");
                    ItsMaria.AddModel(MODEL_G2, i);
                    DataSet ds = ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                    }
                }
            }

            // 조회
            this.EventSearch();
        }

    }
}
