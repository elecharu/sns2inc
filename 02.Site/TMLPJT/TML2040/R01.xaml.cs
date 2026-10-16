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
using System.Globalization;

namespace TML2040
{
    /// <summary>
    /// R02.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel(); //조회패널

        ItsModelPanel MODEL_A1 = new ItsModelPanel(); //비가동유형추가팝업
        ItsModelPanel MODEL_A2 = new ItsModelPanel(); //수정팝업
        ItsModelPanel MODEL_A3 = new ItsModelPanel(); //비가동시작/종료

        ItsModelPanel MODEL_B1 = new ItsModelPanel(); //컨트롤패널
        ItsModelPanel MODEL_B2 = new ItsModelPanel(); //조회일자

        ItsModelPanel MODEL_C1 = new ItsModelPanel(); //금형교체등록창
        ItsModelPanel MODEL_C2 = new ItsModelPanel(); //금형교체수정창
        ItsModelPanel MODEL_C3 = new ItsModelPanel(); //금형교체수정창
        ItsModelGrid MODEL_G1 = new ItsModelGrid();   //비가동이력그리드

        private string stvalue = "";
        private string nonstt = "";

        private string Stime;
        private System.Windows.Threading.DispatcherTimer timer;

        public R01()
        {
            InitializeComponent();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();
            
            MODEL_A3.Binding(PANEL_A3);
            MODEL_A3.FieldType("STATE", ItsEnums.FieldTypes.String);
            MODEL_A3.DefaultValue("STATE", "");
            MODEL_A3.InitData();

            MODEL_B1.Binding(PANEL_B1);
            MODEL_B1.InitData();
            MODEL_B2.Binding(PANEL_B2);
            MODEL_B2.InitData();
            MODEL_B2.EventValueChanged += MODEL_B2_EventValueChanged;

            //MODEL_C1.Binding(PANEL_C1);
            //MODEL_C1.InitData();

            //MODEL_C3.Binding(PANEL_C3);
            //MODEL_C3.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.AddKey("PRDNONKEY");

            //ItsLocalInfo.TMLCD = "PRD";

            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick; ;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        private void MODEL_B2_EventValueChanged(string fieldName)
        {
            EventCommand("EQM_LIST");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (MODEL_A3.GetText("STATE") == "")
            {
                MODEL_A3.SetValue("NONSDAY", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A3.SetValue("NONSTIME", DateTime.Now.ToString("HH:mm:ss"));
                MODEL_A3.SetValue("NONEDAY", "");
                MODEL_A3.SetValue("NONETIME", "");
            }
            else
            {
                MODEL_A3.SetValue("NONEDAY", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A3.SetValue("NONETIME", DateTime.Now.ToString("HH:mm:ss"));

            }
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A1.Close();
            PANEL_A3.Close();
            PANEL_A4.Close();
            BTN_START.Visibility = Visibility.Visible;
            BTN_END.Visibility = Visibility.Hidden;

            //PANEL_C1.Close();
            //PANEL_C3.Close();

            ItsMaria.Set("TML2040_R01", "LIST_EQM");
            ItsMaria.AddOne("TMLCD", ItsLocalInfo.TMLCD);
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            EQM_LIST.Clear();
            EQM_LIST.ButtonHeight = "50";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EQM_LIST.AddButton(ItsData.GetText(dt, i, "EQMNO") + "\n" + ItsData.GetText(dt, i, "EQMNM"), ItsData.GetText(dt, i, "EQMCD"));
            }
            if (ItsData.GetText(dt, 0, "EQMCD") != null)
            {
                EQM_LIST.Value = ItsData.GetText(dt, 0, "EQMCD");
            }
        }

        private void NoncdButton(ButtonList button, ButtonList mbutton)
        {
            ItsMaria.Set("TML2040_R01", "LIST_MSTNON");
            ItsMaria.AddOne("NONTP", mbutton.Value);
            ItsMaria.AddOne("EQMCD", EQM_LIST.Value);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            button.Clear();
            button.ButtonWidth = "80";
            button.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                button.AddButton(ItsData.GetText(ds.Tables[0], i, "NONNM"), ItsData.GetText(ds.Tables[0], i, "NONCD"));
            }
            if (ItsData.GetText(ds.Tables[0], 0, "NONCD") != null)
            {
                button.Value = ItsData.GetText(ds.Tables[0], 0, "NONCD");
            }
        }

        private void NontpButton(ButtonList button, string eqmcd)
        {
            ItsMaria.Set("TML2040_R01", "LIST_NONTP");
            ItsMaria.AddOne("EQMCD", EQM_LIST.Value);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            button.Clear();
            button.ButtonWidth = "80";
            button.ButtonHeight = "50";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                button.AddButton(ItsData.GetText(ds.Tables[0], i, "TPNM"), ItsData.GetText(ds.Tables[0], i, "NONTP"));
            }
            button.Value = ItsData.GetText(ds.Tables[0], 0, "NONTP");
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "EQM_LIST")
            {
                ItsMaria.Set("TML2040_R01", "LIST_PRDRSTNON");
                ItsMaria.AddOne("EQMCD", EQM_LIST.Value);
                ItsMaria.AddOne("DATE", MODEL_B2.GetValue("DATE"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.SetData(ds.Tables[0]);
            }
            else if (commandName == "POP_NONTPLIST")
            {
                string noncd = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "NONCD");
                if (noncd != "")
                {
                    ShowMessageBox("", "등록된 비가동 유형이 존재합니다. 삭제 후 등록버튼을 통해 비가동 유형을 수정하세요.");
                    return;
                }
                nonstt = "0";
                NONTP_LIST.Clear();
                NontpButton(NONTP_LIST, EQM_LIST.Value);
                MODEL_A1.SetValue("NONSDAY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "NONSTIME").Substring(0, 10));
                MODEL_A1.SetValue("NONSTIME", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "NONSTIME").Substring(11, 5));
                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "NONETIME") != "")
                {
                    MODEL_A1.SetValue("NONEDAY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "NONETIME").Substring(0, 10));
                    MODEL_A1.SetValue("NONETIME", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "NONETIME").Substring(11, 5));
                }
                PANEL_A1.Show();                
            }
            else if (commandName == "NONCD_LIST")
            {
                if (NONCD_LIST.Value == "210" && nonstt == "1" || NONCD_LIST.Value == "140" && nonstt == "1")
                {
                    //PANEL_C1.Show();
                    //USETOOL.SetFocus();               
                }
                if (NONCD_LIST.Value == "140" || NONCD_LIST.Value == "210")
                {
                    nonstt = "1";
                }
            }

            else if (commandName == "SEARCH_WORK")
            {
                GRID_G1.Clear();

                ItsMaria.Set("TML2040_R01", "LIST_EQM");
                ItsMaria.AddOne("TMLCD", ItsLocalInfo.TMLCD);
                DataTable dt = ItsMaria.Call().Tables[0];
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                EQM_LIST.Clear();
                EQM_LIST.ButtonHeight = "50";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EQM_LIST.AddButton(ItsData.GetText(dt, i, "EQMNO") + "\n" + ItsData.GetText(dt, i, "EQMNM"), ItsData.GetText(dt, i, "EQMCD"));
                }
                if (ItsData.GetText(dt, 0, "EQMCD") != null)
                {
                    EQM_LIST.Value = ItsData.GetText(dt, 0, "EQMCD");
                }
            }
            else if (commandName == "START/END")
            {

                if (EQM_LIST.Value == "")
                {
                    ShowMessageBox("", "설비를 선택하세요.");
                    return;
                }

                ItsMaria.Set("TML2040_R01", "CHK_TIMER");
                ItsMaria.AddOne("EQMCD", EQM_LIST.Value);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                BTN_START.Visibility = Visibility.Visible;
                BTN_END.Visibility = Visibility.Hidden;
                MODEL_A3.SetValue("STATE", "");

                if (ItsData.GetText(ds.Tables[0], 0, "CHK") == "Y")
                {
                    MODEL_A3.SetValue("STATE", "START");
                    Stime = ItsData.GetText(ds.Tables[0], 0, "NONSTIME"); //비가동시작시간 변수에 저장
                    SE_NONCD_LIST.Clear();
                    SE_NONTP_LIST.Visibility = Visibility.Visible;
                    NontpButton(SE_NONTP_LIST, EQM_LIST.Value);
                    SE_NONTP_LIST.Value = ItsData.GetText(ds.Tables[0], 0, "NONTP");
                    SE_NONCD_LIST.Value = ItsData.GetText(ds.Tables[0], 0, "NONCD");
                    MODEL_A3.SetValue("NONSDAY", Stime.Substring(0, 10));
                    MODEL_A3.SetValue("NONSTIME", Stime.Substring(11, 8));
                    SE_NONTP_LIST.IsEnabled = false;
                    SE_NONCD_LIST.IsEnabled = false;
                    BTN_START.Visibility = Visibility.Hidden;
                    BTN_END.Visibility = Visibility.Visible;
                }
                else
                {
                    SE_NONCD_LIST.Clear();
                    SE_NONTP_LIST.Visibility = Visibility.Visible;
                    NontpButton(SE_NONTP_LIST, EQM_LIST.Value);
                }
                PANEL_A3.Show();
                SE_REMARK.Value = "";
            }
            else if (commandName == "START")
            {
                string eqmcd = EQM_LIST.Value;
                ItsMaria.Set("TML2040_R01", "START_NON");
                ItsMaria.AddOne("NONSTIME", MODEL_A3.GetText("NONSDAY") + " " + MODEL_A3.GetText("NONSTIME"));
                ItsMaria.AddOne("EQMCD", EQM_LIST.Value);
                ItsMaria.AddOne("NONTP", SE_NONTP_LIST.Value);
                ItsMaria.AddOne("NONCD", SE_NONCD_LIST.Value);
                ItsMaria.AddOne("REMARK", SE_REMARK.Value);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                MODEL_A3.SetValue("STATE", "START");
                BTN_START.Visibility = Visibility.Hidden;
                BTN_END.Visibility = Visibility.Visible;

                if (SE_NONCD_LIST.Value == "140" || SE_NONCD_LIST.Value == "210")
                {
                    //PANEL_C3.Show();
                    //USETOOL2.SetFocus();
                }
            }

            else if (commandName == "ERR")
            {
                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY") == "")
                {
                    ShowMessageBox("", "비가동 정보를 선택해주세요.");
                }
                else
                {
                    ItsMaria.Set("TML2040_R01", "SEL_PRDRSTNON_PROBLEM");
                    ItsMaria.AddOne("PRDNONKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY"));
                    DataSet ds = ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ShowMessageBox("", ItsMaria.ErrMessage);
                        return;
                    }

                    PROB.Text = ds.Tables[0].Rows[0]["PROBLEM"].ToString();
                    SOL.Text = ds.Tables[0].Rows[0]["SOLUTION"].ToString();

                    PANEL_A4.Show();
                }       
            }

            else if (commandName == "SAVE_ERR")
            {
                ItsMaria.Set("TML2040_R01", "UP_PRDRSTNON_PROBLEM");
                ItsMaria.AddOne("PROBLEM", PROB.Text);
                ItsMaria.AddOne("SOLUTION", SOL.Text);
                ItsMaria.AddOne("PRDNONKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PROB.Text = string.Empty;
                SOL.Text = string.Empty;

                PANEL_A4.Close();

                EventCommand("EQM_LIST");
            }

            else if (commandName == "END")
            {
                ItsMaria.Set("TML2040_R01", "END_NON");
                ItsMaria.AddOne("NONETIME", MODEL_A3.GetText("NONEDAY") + " " + MODEL_A3.GetText("NONETIME"));
                ItsMaria.AddOne("EQMCD", EQM_LIST.Value);
                ItsMaria.AddOne("NONCD", SE_NONCD_LIST.Value);
                ItsMaria.AddOne("REMARK", SE_REMARK.Value);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                MODEL_A3.SetValue("STATE", "");
                MODEL_A3.SetValue("NONSDAY", "");
                MODEL_A3.SetValue("NONSTIME", "");
                MODEL_A3.SetValue("NONEDAY", "");
                MODEL_A3.SetValue("NONETIME", "");
                Stime = "";
                BTN_START.Visibility = Visibility.Visible;
                BTN_END.Visibility = Visibility.Hidden;
                SE_NONTP_LIST.IsEnabled = true;
                SE_NONCD_LIST.IsEnabled = true;

                PANEL_A3.Close();
                //REMARK.Value = "";
                EventCommand("EQM_LIST");
            }
            else if (commandName == "ADD")
            {
                if (EQM_LIST.Value == "")
                {
                    ShowMessageBox("", "설비를 선택하세요.");
                    return;
                }
                MODEL_A1.InitData();
                NONCD_LIST.Clear();
                NontpButton(NONTP_LIST, EQM_LIST.Value);

                btnPOP.Label = "등록";

                PANEL_A1.Show();
            }
            else if (commandName == "UPDATE")
            {
                string prdnonkey = string.Empty;

                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY") == "")
                {
                    ShowMessageBox("", "비가동 정보를 선택해주세요.");
                    return;
                }

                prdnonkey = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY");

                ItsMaria.Set("TML2040_R01", "SHOW_PRDRSTNON_UP");
                ItsMaria.AddOne("PRDNONKEY", prdnonkey);

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A1.InitData();
                NONCD_LIST.Clear();
                NontpButton(NONTP_LIST, EQM_LIST.Value);
                MODEL_A1.SetRef01("FANO", EQM_LIST.Value);
                MODEL_A1.SetData(ds.Tables[0]);

                btnPOP.Label = "수정";

                PANEL_A1.Show();
            }

            else if (commandName == "DELETE")
            {
                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY") == "")
                {
                    ShowMessageBox("", "비가동 정보를 선택해주세요.");
                    return;
                }
                ShowMessageBox(commandName, "삭제하시겠습니까?");
                return;
            }

            else if (commandName == "ADD_NON")
            {
                if (btnPOP.Label == "등록")
                {
                    ShowMessageBox("ADD_NON", "등록하시겠습니까?");
                    return;
                }
                else if ((btnPOP.Label == "수정"))
                {
                    ShowMessageBox("UP_NON", "수정하시겠습니까?");
                    return;
                }              
            }

            else if (commandName == "UPDATE_NON")
            {
                ShowMessageBox(commandName, "수정하시겠습니까?");
                return;
            }
            else if (commandName == "SE_NONTP_LIST")
            {
                NoncdButton(SE_NONCD_LIST, SE_NONTP_LIST);
            }
            else if (commandName == "NONTP_LIST")
            {
                NoncdButton(NONCD_LIST, NONTP_LIST);
            }
            else if (commandName == "CLOSE_POP")
            {
                //PANEL_C1.Close();
            }
            else if (commandName == "CHANGE_TOOL")
            {
                ShowMessageBox(commandName, "금형교체하시겠습니까?");
                return;
            }
            else if (commandName == "CHANGE_TOOL1")
            {
                ShowMessageBox(commandName, "금형교체하시겠습니까?");
                return;
            }
            else if (commandName == "CHANGE_TOOL2")
            {
                ShowMessageBox(commandName, "금형교체하시겠습니까?");
                return;
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "ADD_NON")
            {
                ItsMaria.Set("TML2040_R01", "ADD_PRDRSTNON");
                ItsMaria.AddOne("PRDNONKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY"));
                ItsMaria.AddOne("NONSTIME", MODEL_A1.GetText("NONSDAY") + " " + MODEL_A1.GetText("NONSTIME"));
                ItsMaria.AddOne("NONETIME", MODEL_A1.GetText("NONEDAY") + " " + MODEL_A1.GetText("NONETIME"));
                ItsMaria.AddOne("FANO", MODEL_A1.GetValue("FANO"));
                ItsMaria.AddOne("EQMCD", EQM_LIST.Value);
                ItsMaria.AddOne("NONTP", SE_NONTP_LIST.Value);
                ItsMaria.AddOne("NONCD", SE_NONCD_LIST.Value);
                ItsMaria.AddOne("NONTP", NONTP_LIST.Value);
                ItsMaria.AddOne("NONCD", NONCD_LIST.Value);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                nonstt = "0";
                MODEL_A1.InitData();
                PANEL_A1.Close();
                EventCommand("EQM_LIST");
            }
            else if(commandName == "UP_NON")
            {
                ItsMaria.Set("TML2040_R01", "UP_PRDRSTNON");
                ItsMaria.AddOne("PRDNONKEY", MODEL_A1.GetText("PRDNONKEY"));
                ItsMaria.AddOne("NONSTIME", MODEL_A1.GetText("NONSDAY") + " " + MODEL_A1.GetText("NONSTIME"));
                ItsMaria.AddOne("NONETIME", MODEL_A1.GetText("NONEDAY") + " " + MODEL_A1.GetText("NONETIME"));
                ItsMaria.AddOne("FANO", MODEL_A1.GetValue("FANO"));
                ItsMaria.AddOne("NONTP", NONTP_LIST.Value);
                ItsMaria.AddOne("NONCD", NONCD_LIST.Value);
                ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A1.InitData();
                PANEL_A1.Close();
                EventCommand("EQM_LIST");
            }

            else if (commandName == "CHANGE_TOOL")
            {
                ItsMaria.Set("TML2040_R01", "CHANGE_TOOL");
                ItsMaria.AddOne("PRDNONKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY"));
                ItsMaria.AddOne("NONTP", NONTP_LIST.Value);
                ItsMaria.AddOne("NONCD", NONCD_LIST.Value);
                ItsMaria.AddModel(MODEL_C1);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                nonstt = "0";
                MODEL_C1.InitData();
                PANEL_A1.Close();
                //PANEL_C1.Close();
                EventCommand("EQM_LIST");
            }
            else if (commandName == "CHANGE_TOOL2")
            {
                ItsMaria.Set("TML2040_R01", "CHANGE_TOOL");
                //ItsMaria.AddOne("PRDNONKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "PRDNONKEY"));
                ItsMaria.AddOne("NONTP", SE_NONTP_LIST.Value);
                ItsMaria.AddOne("NONCD", SE_NONCD_LIST.Value);
                ItsMaria.AddModel(MODEL_C3);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                nonstt = "0";
                MODEL_C3.InitData();
                PANEL_A3.Close();
                EventCommand("EQM_LIST");
            }
            else if (commandName == "DELETE")
            { 
                ItsMaria.Set("TML2040_R01", "DEL_PRDRSTNON");
                ItsMaria.AddOne("EQMCD", EQM_LIST.Value);
                ItsMaria.AddModel(MODEL_G1, MODEL_G1.CurrentIndex);
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("EQM_LIST");
            }
        }
    }
}
