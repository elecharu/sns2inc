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

namespace TML0000
{
    /// <summary>
    /// R02.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R02 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A2 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();

        // 생성자
        public R02()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_G1.Binding(GRID_G1);

            MODEL_G2.Binding(GRID_G2);
           // ItsLocalInfo.TMLCD = "AM01";
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();
            PANEL_A1.Close();
            if(DateTime.Now > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 12:00:00") && DateTime.Now < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 19:00:00"))
            {
                MODEL_S1.SetValue("MEALTIME", "B");
            }
            else
            {
                MODEL_S1.SetValue("MEALTIME", "A");
            }
            EventCommand("LIST_EMP");
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "LIST_EMP")
            {
                ItsMaria.Set("TML0000_R02", "LIST_EMP");
                ItsMaria.AddOne("TMLCD", ItsLocalInfo.TMLCD);
                ItsMaria.AddModel(MODEL_S1);
                DataTable dt = ItsMaria.Call().Tables[0];
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                MODEL_G1.SetData(dt);
                PANEL_A1.Close();
            }
            else if (commandName == "POP_MEAL")
            {
                SHOW_POP(true);
            }
            else if (commandName == "POP_MEAL_CANCEL")
            {
                SHOW_POP(false);
            }
            else if (commandName == "CANCEL")
            {
                EventCommand("LIST_EMP");
            }
            else if (commandName == "ADD_MEAL")
            {
                bool isError = false;
                string errMsg = "";
                for(int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i))
                    {
                        ItsMaria.Set("TML0000_R02", "ADD_MEAL");
                        ItsMaria.AddOne("TMLCD", ItsLocalInfo.TMLCD);
                        ItsMaria.AddModel(MODEL_S1);
                        ItsMaria.AddModel(MODEL_G2, i);
                        ItsMaria.AddOne("MEAL", label_POP_YN.Content);
                        ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            isError = true;
                            errMsg = ItsMaria.ErrMessage;
                        }
                    }
                }
                if (isError)
                {
                    ShowMessageBox("", "실패한 작업이 존재합니다. : " + errMsg);
                    return;
                }
                ShowMessageBox("", "요청 하였습니다.");
                PANEL_A1.Close();
                EventCommand("LIST_EMP");
            }
        }

        public override void EventPopClose(string panelName)
        {
            base.EventPopClose(panelName);

            if (panelName == "PANEL_A1")
            {
                EventCommand("LIST_EMP");
            }
        }

        public void SHOW_POP(bool addyn)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("BDVCD");
            dt.Columns.Add("EMPCD");
            dt.Columns.Add("EMPNM");

            if (MODEL_G1.CheckedCount < 1)
            {
                ShowMessageBox("", "선택된 사원이 없습니다.");
                return;
            }
            for (int i = 0; i < MODEL_G1.ModelCount; i++)
            {
                if (MODEL_G1.IsChecked(i))
                {
                    DataRow dr = dt.NewRow();
                    dr["BDVCD"] = MODEL_G1.GetValue(i, "BDVCD");
                    dr["EMPCD"] = MODEL_G1.GetValue(i, "EMPCD");
                    dr["EMPNM"] = MODEL_G1.GetValue(i, "EMPNM");
                    dt.Rows.Add(dr);
                }
            }

            MODEL_G2.SetData(dt);

            for (int i = 0; i < MODEL_G2.ModelCount; i++)
            {
                MODEL_G2.SetChecked(i, true);
            }
            
            string mealTime = MEALTIME.Value;
            string mealTimeText = "";
            foreach(DataRow r in MEALTIME.ModelCombo.Rows)
            {
                if(r["Value"].ToString() == mealTime)
                {
                    mealTimeText = r["Label"].ToString();
                }
            }

            label_POP2.Content = MODEL_S1.GetValue("MEALDT") + " " + mealTimeText;

            if (addyn)
            {
                label_POP_YN.Content = "Y";
                label_POP1.Content = "식사 인원 파악 (식사 요청)";
                label_POP3.Content = "식사 신청 하시겠습니까?";
            }
            else
            {
                label_POP_YN.Content = "N";
                label_POP1.Content = "식사 인원 파악 (요청 취소)";
                label_POP3.Content = "식사 취소 하시겠습니까?";
            }
            PANEL_A1.Show();
        }
    }
}
