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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using System.Data;

namespace SYS0301
{
    /// <summary>
    /// P01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageOffice
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();

        // 생성자
        public R01()
        {
            InitializeComponent();

            // 최초 시작시 조회영역에 모델 설정
            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.AddKey("LABELCD");
            MODEL_A1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.AddKey("LABELCD");
            MODEL_G1.EventRowChanged += MODEL_G1_EventRowChanged;

            // 조회영역 컨트롤 ENTER키 눌렀을때 자동 조회 설정
            PANEL_S1.SetEnterSearch();

            // 컨트롤 영역 ENTER키 눌렀을때 자동 탭 이동
            PANEL_A1.SetEnterTab();
        }

        private void MODEL_G1_EventRowChanged(int rowIndex)
        {
            PANEL_A1.Close();
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();
            PANEL_A1.Close();   
        }

        public override void EventAdd()
        {
            base.EventAdd();
            PANEL_A1.Show();
        }


        // 삭제
        public override void EventDelete()
        {
            base.EventDelete();

            // 질문메시지 박스, YES일 경우만 처리
            if (ItsMsgBox.ShowYesNo("선택항목을 삭제하시겠습니까?") == true)
            {
                for (int i = 0; i < MODEL_G1.ModelCount; i++)
                {
                    if (MODEL_G1.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0301_R01", "DEL_SYSLABEL");
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

            ItsMaria.Set("SYS0301_R01", "LIST_SYSLABEL");
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

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);
            if (commandName == "LabelDesign")
            {
                LabelDesign.DesignForm dform = new LabelDesign.DesignForm();
                dform.LABELCD = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "LABELCD");
                dform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                dform.ShowDialog();
            }

            else if (commandName == "PANEL_A1")
            {
                ItsMaria.Set("SYS0301_R01", "ADD_SYSLABEL");
                ItsMaria.AddModel(MODEL_A1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                    return;
                }
                MODEL_G1.SetData(ds.Tables[0]);
                MODEL_G1.SetKey(MODEL_A1.GetKey());
                MODEL_A1.InitData();
            }
            EventSearch();
        }

        // 저장
        public override void EventSave()
        {
            base.EventSave();

            // 신규 추가
            //if (PANEL_A1.IsEditMode == true)
            //{
            //    if (PANEL_A1.GetModel<MODEL_A1>().LABELCD == "")
            //    {
            //        ItsMsgBox.Show("라벨코드를 기입하세요.");
            //        return;
            //    }
            //    else if (ItsMsgBox.ShowYesNo("신규 라벨을 추가하시겠습니까?") == true)
            //    {
            //        ItsMaria.Set("SYS0301_R01", "ADD_SYSLABEL");
            //        ItsMaria.AddModel(PANEL_A1.Model);
            //        ItsMaria.Call();
            //        if (ItsMaria.IsError)
            //        {
            //            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
            //            return;
            //        }
            //        GRID_G1.SetKey(PANEL_A1.Model);
            //        PANEL_A1.SetBinding(new MODEL_A1());
            //    }
            //}
                // FLEX 저장
                for (int i = 0; i < MODEL_G1.ModelCount; i++)
                {
                    if (MODEL_G1.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0301_R01", "UP_SYSLABEL");
                        ItsMaria.AddModel(MODEL_G1,i);
                        ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                            return;
                        }
                    }
                
                }
                // 조회
                this.EventSearch();
        }
    }
}
