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

namespace SYS0201
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageOffice
    {
        // 조회 모델
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();


        // 생성자
        public R01()
        {
            InitializeComponent();

            // 최초 시작시 모델 설정
            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.AddKey("EQMCD");
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.AddKey("PRGCD");
            MODEL_A1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.AddKey("PRGCD");

            MODEL_G1.EventRowChanged += MODEL_G1_EventRowChanged;

            // 자동 조회 OR 자동 탭 설정
            PANEL_S1.SetEnterSearch();
            PANEL_A1.SetEnterTab();
        }




        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A1.Close();
            GRID_G1.IsShowDetail = true;
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
                ItsMaria.Set("SYS0201_R01", "ADD_SYSPRG");
                ItsMaria.AddModel(MODEL_A1);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                    return;
                }
                MODEL_G1.SetKey(MODEL_A1.GetKey());
                MODEL_A1.InitData();
            }
            EventSearch();
        }

        private void MODEL_G1_EventRowChanged(int rowIndex)
        {

            PANEL_A1.Close();
        }

        // 삭제
        public override void EventDelete()
        {
            base.EventDelete();

            string prgName = MODEL_G1.GetText(MODEL_G1.CurrentIndex,"PRGCD") + " : " + MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRGNM");

            // 질문메시지 박스, YES일 경우만 처리
            if (ItsMsgBox.ShowYesNo("선택 화면을 삭제하시겠습니까?" + "\n\n" + prgName) == true)
            {
                for (int i = 0; i < MODEL_G1.ModelCount; i++)
                {
                    if (MODEL_G1.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0201_R01", "DEL_SYSPRG");
                        ItsMaria.AddModel(MODEL_G1,i);
                        DataSet ds = ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                        }
                    }
                }

                // 삭제 후 자동 조회
                EventSearch();
            }
        }

        // 조회
        public override void EventSearch()
        {
            base.EventSearch();

            ItsMaria.Set("SYS0201_R01", "LIST_SYSPRG");
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

            string prgName = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRGCD") + " : " + MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRGNM");

            if (ItsMsgBox.ShowYesNo("선택 화면을 수정하시겠습니까?" + "\n\n" + prgName) == true)
            {
                // FLEX 저장
                for (int i = 0; i < MODEL_G1.ModelCount; i++)
                {
                    if (MODEL_G1.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0201_R01", "UP_SYSPRG");
                        ItsMaria.AddModel(MODEL_G1, i);
                        ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                            return;
                        }
                    }
                }
            }

            // 조회
            this.EventSearch();
        }
    }
}
