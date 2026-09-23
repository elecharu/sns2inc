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

namespace SYS0802
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageOffice
    {

        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();

        public R01()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.AddKey("PLCCD", "PLCADDR");
            MODEL_A1.DefaultValue("CONVFACT", 1);
            MODEL_A1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.AddKey("PLCCD");
            MODEL_G1.EventRowChanged += MODEL_G1_EventRowChanged;

            MODEL_G2.Binding(GRID_G2);
            MODEL_G2.AddKey("PLCCD", "PLCADDR");
        }


        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            //최초 시작시 조회영역 모델 설정
            

            // 조회영역 컨트롤 ENTER키 눌렀을때 자동 조회 설정
            PANEL_S1.SetEnterSearch();

            // 컨트롤 영역 ENTER키 눌렀을때 자동 탭 이동
            PANEL_A1.SetEnterTab();

            PANEL_A1.Close();
            GRID_G2.IsShowDetail = false;

        }

        // FLEX 행 이동 MODEL 변경 시
        private void MODEL_G1_EventRowChanged(int rowIndex)

        {
            ItsMaria.Set("SYS0802_R01", "LIST_SYSPLCCUR");
            ItsMaria.AddModel(MODEL_G1,MODEL_G1.CurrentIndex);
            ItsMaria.AddOne("PLCCD", MODEL_G1.GetText(MODEL_G1.CurrentIndex,"PLCCD"));
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                return;
            }

            // FLEX에 바인딩 
            MODEL_G2.SetData(ds.Tables[0]);
        }

        public override void EventAdd()
        {
            base.EventAdd();
            PANEL_A1.Show();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);
            if (commandName == "PANEL_A1")
            {
                ItsMaria.Set("SYS0802_R01", "ADD_SYSPLCCUR");
                ItsMaria.AddModel(MODEL_A1);
                ItsMaria.AddOne("PLCCD", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PLCCD"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                    return;
                }
                
                MODEL_G1.SetKey(MODEL_G1.GetKey(MODEL_G1.CurrentIndex));
                MODEL_A1.InitData();
                // 조회
                MODEL_G1_EventRowChanged(MODEL_G1.CurrentIndex);
            }
        }

        // 삭제
        public override void EventDelete()
        {
            base.EventDelete();

            // 질문메시지 박스, YES일 경우만 처리
            if (ItsMsgBox.ShowYesNo("선택한 PLC정보를 삭제하시겠습니까?") == true)
            {
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0802_R01", "DEL_SYSPLCCUR");
                        ItsMaria.AddModel(MODEL_G2,i);
                        ItsMaria.AddOne("PLCCD", MODEL_G1.GetText(i, "PLCCD"));
                        DataSet ds = ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                        }
                    }
                }

                // 삭제 후 자동 조회
                MODEL_G1_EventRowChanged(MODEL_G1.CurrentIndex);
            }
        }

        // 조회
        public override void EventSearch()
        {
            base.EventSearch();

            ItsMaria.Set("SYS0802_R01", "LIST_SYSPLC");
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

        // 저장
        public override void EventSave()
        {
            base.EventSave();

            // FLEX 저장
            for (int i = 0; i < MODEL_G2.ModelCount; i++)
            {
                if (MODEL_G2.IsChecked(i))
                {
                    ItsMaria.Set("SYS0802_R01", "UP_SYSPLCCUR");
                    ItsMaria.AddModel(MODEL_G2,i);
                    ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                        return;
                    }
                }
            }
            MODEL_G1_EventRowChanged(MODEL_G1.CurrentIndex);
        }
    }
}
