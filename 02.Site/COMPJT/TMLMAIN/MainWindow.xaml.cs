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
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Data;
using System.Reflection;
using System.Drawing.Printing;
using System.Management;
using System.IO;
using ITSLIB;
using System.Globalization;
using System.Windows.Threading;

namespace TMLMAIN
{
    public class StringToVisibility : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "Visible")
            {
                return Visibility.Visible;
            }
            else if (value.ToString() == "Hidden")
            {
                return Visibility.Hidden;
            }
            return Visibility.Hidden;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Visibility.Visible;
        }
    }

    public class clsMSTTMLEQM
    {
        public string PRCCD { get; set; }
        public string LINECD { get; set; }
        public string LINENM { get; set; }
        public string EQMCD { get; set; }
        public string EQMNM { get; set; }
    }

    public partial class MainWindow : Window
    {
        ItsModelPanel MODEL_WAIT = new ItsModelPanel();
        ItsModelPanel MODEL_CONFIG = new ItsModelPanel();

        private System.Net.WebClient webClient = new System.Net.WebClient();

        public string FACTORYCD = string.Empty;
        public string TMLCD = string.Empty;
        //단말기별 설비정보
        public List<clsMSTTMLEQM> EQMList = new List<clsMSTTMLEQM>();

        //지시->실적 화면 이동에서 사용(선택한 설비코드,,)
        public string EQMCD = string.Empty;
        public string LINECD = string.Empty;
        public bool ShowPrdSpec = false;

        // 2025-01-09 프로그램 버전 관리 -> 수정시 재실행 메시지 팝업용
        public string PrgVer = "";

        // 2020-12-08 메시지 박스 색상 변경 PJH
        private Brush _msgback = Brushes.IndianRed;
        public Brush msgback
        {
            get { return _msgback; }
            set
            {
                _msgback = value;
                PANEL_MSG.Background = _msgback;
                MsgIcon.Background = _msgback;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            MODEL_WAIT.Binding(WAIT_ICON);
            MODEL_WAIT.FieldType("WAITVISIBLE", ItsEnums.FieldTypes.String);
            MODEL_WAIT.DefaultValue("WAITVISIBLE", "Visible");
            MODEL_WAIT.InitData();

            MODEL_CONFIG.Binding(PANEL_OPTION);
            MODEL_CONFIG.FieldType("COMPANYCD", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("FACTORYCD", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("TMLCD", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("PRINT", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("PORTSCALE", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("PORTPLC", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.InitData();
            MODEL_CONFIG.EventValueChanged += MODEL_CONFIG_EventValueChanged;

            //COMBO_PRINT.ItemClear();
            //int count = PrinterSettings.InstalledPrinters.Count;
            //for (int i = 0; i < count; i++)
            //{
            //    COMBO_PRINT.AddItem(PrinterSettings.InstalledPrinters[i], PrinterSettings.InstalledPrinters[i]);
            //}

            COMBO_PRINT.Items.Clear();
            int count = PrinterSettings.InstalledPrinters.Count;
            for (int i = 0; i < count; i++)
            {
                COMBO_PRINT.Items.Add(PrinterSettings.InstalledPrinters[i]);
            }


            ItsElement.TML_MAIN_WINDOW = this;
            this.WindowState = WindowState.Maximized;

            if (ItsLocalInfo.IsRunMode)
            {
                this.Topmost = false;
            }

            ICON_MENU_MouseDown(null, null);
            MSG_CLOSE_MouseUp(null, null);
            CONFIG_CLOSE_MouseUp(null, null);

            this.Loaded += MainWindow_Loaded;
            this.Activated += MainWindow_Activated;

            // 최초 실행시 프로그램 버전 가져오기
            DataTable dt = ItsMaria.Query("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPRGVER';").Tables[0];
            this.PrgVer = ItsData.GetText(dt, 0, "REF01");
        }

        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                LABEL_TITLE2.Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }));
        }

        private void MODEL_CONFIG_EventValueChanged(string fieldName)
        {
            if (fieldName == "COMPANYCD")
            {
                ItsElement.TML_MAIN_WINDOW.COMBO_FACTORYCD.ItemClear();
                ItsElement.TML_MAIN_WINDOW.COMBO_FACTORYCD.REF01 = MODEL_CONFIG.GetText("COMPANYCD");
                ItsElement.TML_MAIN_WINDOW.COMBO_FACTORYCD.Value = File.ReadAllText(MainWindow._factoryFile, Encoding.UTF8);
                ItsElement.TML_MAIN_WINDOW.FACTORYCD = File.ReadAllText(MainWindow._factoryFile, Encoding.UTF8);
            }
             
            else if (fieldName == "FACTORYCD")
            {
                ItsElement.TML_MAIN_WINDOW.COMBO_TMLCD.ItemClear();
                ItsElement.TML_MAIN_WINDOW.COMBO_TMLCD.REF01 = MODEL_CONFIG.GetText("FACTORYCD");
                ItsElement.TML_MAIN_WINDOW.COMBO_TMLCD.Value = File.ReadAllText(MainWindow._tmlcdFile, Encoding.UTF8);
                ItsElement.TML_MAIN_WINDOW.TMLCD = File.ReadAllText(MainWindow._tmlcdFile, Encoding.UTF8);
            }
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            if (ItsLocalInfo.IsRunMode)
            {
                this.Topmost = false;
            }
        }

        public static System.Timers.Timer timer;
        private string mainLabel = "";
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CONFIG_CLOSE_MouseUp(null, null);
            PASS_CHECK.Focus();
            WAIT_MSG.Visibility = Visibility.Hidden;

            timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000 * 60;

            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += Timer1_Elapsed;
            timer1.Interval = 100;
            timer1.Start();


            if (!File.Exists(_companyFile)) File.WriteAllText(_companyFile, "");
            MODEL_CONFIG.SetValue("COMPANYCD", File.ReadAllText(_companyFile, Encoding.UTF8));

            if (!File.Exists(_factoryFile)) File.WriteAllText(_factoryFile, "");
            MODEL_CONFIG.SetValue("FACTORYCD", File.ReadAllText(_factoryFile, Encoding.UTF8));

            if (!File.Exists(_tmlcdFile)) File.WriteAllText(_tmlcdFile, "");
            MODEL_CONFIG.SetValue("TMLCD", File.ReadAllText(_tmlcdFile, Encoding.UTF8));

            // 2024-12-04 IT팀 테스트 내용은 EMPCD : 윤진욱 대리 사번으로 강제 임의지정
            // 2024-12-09 외주처 로그인시 환경설정 제한
            if (ItsMemberShip.EMPCD == "")
            {
                ICON_CONFIG.IsEnabled = true;
                mainLabel = "";
                var Tml = File.ReadAllText(_tmlcdFile, Encoding.UTF8);
                if (Tml == "SNS_IT")
                {
                    ItsMemberShip.EMPCD = "SNSIT";
                }
            }
            else 
            {
                ICON_CONFIG.IsEnabled = false;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT A.COMPANYCD, A.FACTORYCD, A.EMPCD, B.TMLCD, B.TMLNM");
                sb.AppendLine("FROM SYSUSER AS A");
                sb.AppendLine("LEFT JOIN MSTTML AS B ON A.USERID = B.TMLCD AND B.OSCYN = 'Y'");
                sb.AppendLine("WHERE A.EMPCD = '" + ItsMemberShip.EMPCD + "'; ");
                DataSet TmlUser = ItsMaria.Query(sb.ToString());
                mainLabel = ItsData.GetText(TmlUser.Tables[0], 0, "TMLNM");

                MODEL_CONFIG.SetValue("COMPANYCD", ItsData.GetText(TmlUser.Tables[0], 0, "COMPANYCD"));
                MODEL_CONFIG.SetValue("FACTORYCD", ItsData.GetText(TmlUser.Tables[0], 0, "FACTORYCD"));
                MODEL_CONFIG.SetValue("TMLCD", ItsData.GetText(TmlUser.Tables[0], 0, "TMLCD"));

                File.WriteAllText(_companyFile, MODEL_CONFIG.GetText("COMPANYCD"), Encoding.UTF8);
                File.WriteAllText(_factoryFile, MODEL_CONFIG.GetText("FACTORYCD"), Encoding.UTF8);
                File.WriteAllText(_tmlcdFile, MODEL_CONFIG.GetText("TMLCD"), Encoding.UTF8);
            }


            if (!File.Exists(_printFile)) File.WriteAllText(_printFile, "");
            MODEL_CONFIG.SetValue("PRINT", File.ReadAllText(_printFile, Encoding.UTF8));
            // 2024-10-23 초기값 지정
            for (int i = 0; i < COMBO_PRINT.Items.Count; i++)
            {
                var initPrint = File.ReadAllText(_printFile, Encoding.UTF8);
                if (initPrint != null && COMBO_PRINT.Items[i].ToString() == initPrint)
                {
                    COMBO_PRINT.SelectedIndex = i;
                    break;
                }
            }

            if (!File.Exists(_scalePortFile)) File.WriteAllText(_scalePortFile, "");
            MODEL_CONFIG.SetValue("PORTSCALE", File.ReadAllText(_scalePortFile, Encoding.UTF8));

            if (!File.Exists(_plcPortFile)) File.WriteAllText(_plcPortFile, "");
            MODEL_CONFIG.SetValue("PORTPLC", File.ReadAllText(_plcPortFile, Encoding.UTF8));

            SetMenu(MODEL_CONFIG.GetText("TMLCD"));

            _width = PAGE_MAIN.Width;
            _height = PAGE_MAIN.Height;

            if (ItsLocalInfo.IsRunMode)
            {
                try
                {
                    webClient.DownloadFile(ItsServerInfo.ServerUrl + "TML0000.exe", "TML0000.exe");
                }
                catch { }
            }

            // 메인 화면 띄우기
            PAGE_MAIN.MaxHeight = 5000;

            //if (ItsMemberShip.LoginKey == null || ItsMemberShip.LoginKey == "")
            //{
            //    LABEL_LOGINUSER.Content = "";
            //    LABEL_LOIGNTIME.Content = "";
            //}
            //else
            //{
            //    LABEL_LOGINUSER.Content = ItsData.GetScalar(ItsMaria.Query("SELECT EMPNM FROM MSTEMP WHERE EMPCD = '" + ItsMemberShip.EMPCD + "';"));
            //    LABEL_LOIGNTIME.Content = "접속시간 : " + ItsMemberShip.LoginTime;
            //}

            try
            {
                Assembly pageAssembly = Assembly.LoadFrom("TML0000.exe");
                object assObj = pageAssembly.CreateInstance("TML0000.R01");
                Page page = assObj as Page;

                FRAME_MAIN.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                FRAME_MAIN.Navigate(page);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT SYSPRG.PRGNM");
                sb.AppendLine("FROM SYSPRG");
                sb.AppendLine("WHERE PRGCD = 'TML0000_R01';");

                if (mainLabel == "")
                    LABEL_TITLE.Content = ItsData.GetScalar(ItsMaria.Query(sb.ToString()));
                else
                    LABEL_TITLE.Content = mainLabel ;
            }
            catch
            {
                MessageBox.Show("메인화면을 로딩하지 못했습니다. TML0000.exe");
            }

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();

            this.Dispatcher.Invoke(new Action(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPRGVER';");
                DataSet ds = ItsMaria.Query(sb.ToString());
                string prgVer = ItsData.GetText(ds.Tables[0], 0, "REF01");

                if (prgVer != this.PrgVer)
                {
                    ShowMessageBox("", "프로그램을 재시작해주세요.\n" + "현재버전: " + this.PrgVer + " -> 최신버전: " + prgVer);
                    return;
                }
            }));

            timer.Start();
        }

        private double _width = 0;
        private double _height = 0;

        private void SetMenu(string tmlcode)
        {
            ItsMaria.Set("TMLMAIN", "LIST_PRG");
            ItsMaria.AddOne("TMLCD", MODEL_CONFIG.GetText("TMLCD"));
            DataSet ds = ItsMaria.Call();
            
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            else
            {
                EQMList = new List<clsMSTTMLEQM>();
                this.TMLCD = MODEL_CONFIG.GetText("TMLCD");

                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                //    {
                //        clsMSTTMLEQM _eqm = new clsMSTTMLEQM();
                //        _eqm.PRCCD = ds.Tables[1].Rows[i]["PRCCD"].ToString();
                //        _eqm.LINECD = ds.Tables[1].Rows[i]["LINECD"].ToString();
                //        _eqm.LINENM = ds.Tables[1].Rows[i]["LINENM"].ToString();
                //        _eqm.EQMCD = ds.Tables[1].Rows[i]["EQMCD"].ToString();
                //        _eqm.EQMNM = ds.Tables[1].Rows[i]["EQMNM"].ToString();
                //        EQMList.Add(_eqm);
                //    }
                //}

                MENU0.Visibility = Visibility.Hidden;
                MENU1.Visibility = Visibility.Hidden;
                MENU2.Visibility = Visibility.Hidden;
                MENU3.Visibility = Visibility.Hidden;
                MENU4.Visibility = Visibility.Hidden;
                MENU5.Visibility = Visibility.Hidden;
                MENU6.Visibility = Visibility.Hidden;
                MENU7.Visibility = Visibility.Hidden;
                MENU8.Visibility = Visibility.Hidden;
                MENU9.Visibility = Visibility.Hidden;

                OTHER_MENU0.Visibility = Visibility.Hidden;
                OTHER_MENU1.Visibility = Visibility.Hidden;
                OTHER_MENU2.Visibility = Visibility.Hidden;
                OTHER_MENU3.Visibility = Visibility.Hidden;
                OTHER_MENU4.Visibility = Visibility.Hidden;
                OTHER_MENU5.Visibility = Visibility.Hidden;
                OTHER_MENU6.Visibility = Visibility.Hidden;
                OTHER_MENU7.Visibility = Visibility.Hidden;
                OTHER_MENU8.Visibility = Visibility.Hidden;
                OTHER_MENU9.Visibility = Visibility.Hidden;

                FRAME0.Tag = null;
                FRAME1.Tag = null;
                FRAME2.Tag = null;
                FRAME3.Tag = null;
                FRAME4.Tag = null;
                FRAME5.Tag = null;
                FRAME6.Tag = null;
                FRAME7.Tag = null;
                FRAME8.Tag = null;
                FRAME9.Tag = null;

                OTHER_FRAME0.Tag = null;
                OTHER_FRAME1.Tag = null;
                OTHER_FRAME2.Tag = null;
                OTHER_FRAME3.Tag = null;
                OTHER_FRAME4.Tag = null;
                OTHER_FRAME5.Tag = null;
                OTHER_FRAME6.Tag = null;
                OTHER_FRAME7.Tag = null;
                OTHER_FRAME8.Tag = null;
                OTHER_FRAME9.Tag = null;

                UserControl MENU;

                int menuCount = ds.Tables[0].Rows.Count;
                if (menuCount <= 10)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        MENU = PANEL_MENU.FindName("MENU" + i) as UserControl;
                        MENU.Visibility = Visibility.Visible;
                        MENU.Tag = ds.Tables[0].Rows[i][0].ToString();
                        MENU.Content = ds.Tables[0].Rows[i][1].ToString();
                    }
                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        MENU = PANEL_MENU.FindName("MENU" + i) as UserControl;
                        MENU.Visibility = Visibility.Visible;
                        MENU.Tag = ds.Tables[0].Rows[i][0].ToString();
                        MENU.Content = ds.Tables[0].Rows[i][1].ToString();
                    }

                    MENU9.Visibility = Visibility.Visible;
                    MENU9.Tag = "OTHER";
                    MENU9.Content = "기타메뉴";

                    for (int i = 9; i < menuCount; i++)
                    {
                        MENU = PANEL_MENU.FindName("OTHER_MENU" + (i - 9)) as UserControl;
                        MENU.Visibility = Visibility.Visible;
                        MENU.Tag = ds.Tables[0].Rows[i][0].ToString();
                        MENU.Content = ds.Tables[0].Rows[i][1].ToString();
                    }
                }

                //int row = 0;
                //for (int i = menuCount + 1; i < menuCount + ds.Tables[1].Rows.Count + 1; i++)
                //{
                //    MENU = PANEL_MENU.FindName(i < 10 ? "MENU" + i : "OTHER_MENU" + (i - 9)) as UserControl;
                //    MENU.Visibility = Visibility.Hidden;
                //    MENU.Tag = ds.Tables[1].Rows[row][0].ToString();
                //    MENU.Content = ds.Tables[1].Rows[row++][1].ToString();
                //}
            }
        }

        private void ICON_MIN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;

            this.WindowState = WindowState.Minimized;
            // this.Topmost = false;
        }

        private void ICON_CLOSE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;

            if (PAGE_MAIN.MaxHeight > 0)
            {
                ShowMessageBox("__MainClose", "전체 화면을 닫으시겠습니까?");
            }
            else 
            {
                ShowMessageBox("__PageClose", "현재 화면을 닫으시겠습니까?");
            }
        }

        public static string _companyFile = "ConfigCompany.config";
        public static string _factoryFile = "ConfigFactory.config";
        public static string _tmlcdFile = "ConfigTmlcd.config";
        public static string _printFile = "ConfigPrintBarcode.config";
        public static string _scalePortFile = "ConfigPortScale.config";
        public static string _plcPortFile = "ConfigPortPlc.config";

        private string _curTmlcd = "";
        private void ICON_CONFIG_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DOCK_FRAME.Visibility = Visibility.Hidden;

            _curTmlcd = MODEL_CONFIG.GetText("TMLCD");

            if (CURFRAME != null) CURFRAME.IsEnabled = false;

            PANEL_CONFIG.MaxHeight = 5000;
            CONFIG_LINE.MaxHeight = 10;
            ConfigIcon.Visibility = Visibility.Visible;
            ConfigCommit.Visibility = Visibility.Visible;
            ConfigClose.Visibility = Visibility.Visible;

            PANEL_MSG.MaxHeight = 0;
            MsgIcon.Visibility = Visibility.Hidden;
            MsgCommit.Visibility = Visibility.Hidden;
            MsgClose.Visibility = Visibility.Hidden;


            CONFIG_PASS.Visibility = Visibility.Visible;
            PASS_CHECK.MaxHeight = 5000;
            PANEL_OPTION.MaxHeight = 0;

            CONFIG_PASS.Value = "";
            CONFIG_PASS.SetFocus();

            COMBO_PLCPORT.ItemClear();
            COMBO_SCALEPORT.ItemClear();
            for (int i = 1; i < 10; i++)
            {
                COMBO_PLCPORT.AddItem("COM" + i, "COM" + i);
                COMBO_SCALEPORT.AddItem("COM" + i, "COM" + i);
            }

            try
            {
                COMBO_SCALEPORT.Value = System.IO.File.ReadAllText(_scalePortFile, Encoding.UTF8);
                COMBO_PLCPORT.Value = System.IO.File.ReadAllText(_plcPortFile, Encoding.UTF8);
            }
            catch { }
        }

        private void CONFIG_COMMIT_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            DOCK_FRAME.Visibility = Visibility.Visible;

            File.WriteAllText(_companyFile, MODEL_CONFIG.GetText("COMPANYCD"), Encoding.UTF8);
            File.WriteAllText(_factoryFile, MODEL_CONFIG.GetText("FACTORYCD"), Encoding.UTF8);
            File.WriteAllText(_tmlcdFile, MODEL_CONFIG.GetText("TMLCD"), Encoding.UTF8);
            File.WriteAllText(_printFile, MODEL_CONFIG.GetText("PRINT"), Encoding.UTF8);
            File.WriteAllText(_scalePortFile, MODEL_CONFIG.GetText("PORTSCALE"), Encoding.UTF8);
            File.WriteAllText(_plcPortFile, MODEL_CONFIG.GetText("PORTPLC"), Encoding.UTF8);

            ItsLocalInfo._SetCOMPANY(MODEL_CONFIG.GetText("COMPANYCD"));
            ItsLocalInfo._SetFACTORY(MODEL_CONFIG.GetText("FACTORYCD"));
            ItsLocalInfo._SetPORTSCALE(MODEL_CONFIG.GetText("PORTSCALE"));
            ItsLocalInfo._SetPORTPLC(MODEL_CONFIG.GetText("PORTPLC"));

            if (_curTmlcd != MODEL_CONFIG.GetText("TMLCD"))
            {
                SetMenu(MODEL_CONFIG.GetText("TMLCD"));
                ItsLocalInfo._TMLINFORELOAD = true;
                string __tmlcd = ItsLocalInfo.TMLCD; // tmlware 갱신 효과
            }

            PAGE0.MaxHeight = 0;
            PAGE1.MaxHeight = 0;
            PAGE2.MaxHeight = 0;
            PAGE3.MaxHeight = 0;
            PAGE4.MaxHeight = 0;
            PAGE5.MaxHeight = 0;
            PAGE6.MaxHeight = 0;
            PAGE7.MaxHeight = 0;
            PAGE8.MaxHeight = 0;
            PAGE9.MaxHeight = 0;

            OTHER_PAGE0.MaxHeight = 0;
            OTHER_PAGE1.MaxHeight = 0;
            OTHER_PAGE2.MaxHeight = 0;
            OTHER_PAGE3.MaxHeight = 0;
            OTHER_PAGE4.MaxHeight = 0;
            OTHER_PAGE5.MaxHeight = 0;
            OTHER_PAGE6.MaxHeight = 0;
            OTHER_PAGE7.MaxHeight = 0;
            OTHER_PAGE8.MaxHeight = 0;
            OTHER_PAGE9.MaxHeight = 0;

            MainWindow_Loaded(sender, e);
            SetMenu(MODEL_CONFIG.GetText("TMLCD"));

            CONFIG_CLOSE_MouseUp(null, null);
        }

        private void CONFIG_CLOSE_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            CONFIG_PASS.CloseKeypad();

            DOCK_FRAME.Visibility = Visibility.Visible;

            PANEL_CONFIG.MaxHeight = 0;
            if (CURFRAME != null) CURFRAME.IsEnabled = true;

            ConfigIcon.Visibility = Visibility.Hidden;
            ConfigClose.Visibility = Visibility.Hidden;
            ConfigCommit.Visibility = Visibility.Hidden;
        }

        private void ICON_MENU_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LEFT_MENU.MaxWidth = 1000;
            ICON_MENU.MaxWidth = 0;
            ICON_MENU.Visibility = Visibility.Hidden;
        }

        private void ICON_HIDE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LEFT_MENU.MaxWidth = 0;
            ICON_MENU.Visibility = Visibility.Visible;
            ICON_MENU.MaxWidth = 1000;
        }

        private string command = "";
        public void ShowMessageBox(string commandName, string msg)
        {
            command = commandName;
            TEXT_MSG.Text = msg;

            if (CURFRAME != null) CURFRAME.IsEnabled = false;

            PANEL_MSG.MaxHeight = 5000;
            MsgIcon.Visibility = Visibility.Visible;
            MsgCommit.Visibility = Visibility.Visible;
            MsgClose.Visibility = Visibility.Visible;

            msgback = Brushes.IndianRed;

            PANEL_MSG.Focus();
        }

        public void ShowMessageBox_B(string commandName, string msg, Brush backcolor)
        {
            command = commandName;
            TEXT_MSG.Text = msg;

            if (CURFRAME != null) CURFRAME.IsEnabled = false;

            PANEL_MSG.MaxHeight = 5000;
            MsgIcon.Visibility = Visibility.Visible;
            MsgCommit.Visibility = Visibility.Visible;
            MsgClose.Visibility = Visibility.Visible;

            msgback = backcolor;

            PANEL_MSG.Focus();
        }

        private void MSG_CLOSE_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            TEXT_MSG.Text = "오류발생: 프로그램 개발자 연락바람";
            PANEL_MSG.MaxHeight = 0;

            if (CURFRAME != null) CURFRAME.IsEnabled = true;

            MsgIcon.Visibility = Visibility.Hidden;
            MsgCommit.Visibility = Visibility.Hidden;
            MsgClose.Visibility = Visibility.Hidden;

            if (PANEL_CONFIG.Visibility == Visibility.Visible)
            {
                CONFIG_PASS.Value = "";
                CONFIG_PASS.Focus();
            }
        }

        private void MSG_COMMIT_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            TEXT_MSG.Text = "오류발생: 프로그램 개발자 연락바람";
            PANEL_MSG.MaxHeight = 0;
            if (CURFRAME != null) CURFRAME.IsEnabled = true;
            MsgIcon.Visibility = Visibility.Hidden;
            MsgCommit.Visibility = Visibility.Hidden;
            MsgClose.Visibility = Visibility.Hidden;

            if (PANEL_CONFIG.Visibility == Visibility.Visible)
            {
                CONFIG_PASS.Value = "";
                CONFIG_PASS.Focus();
            }

            if (command == "__MainClose")
            {
                this.Close();
            }
            else if (command == "__PageClose")
            {
                FRAME0.Tag = null;
                FRAME1.Tag = null;
                FRAME2.Tag = null;
                FRAME3.Tag = null;
                FRAME4.Tag = null;
                FRAME5.Tag = null;
                FRAME6.Tag = null;
                FRAME7.Tag = null;
                FRAME8.Tag = null;
                FRAME9.Tag = null;

                PAGE0.MaxHeight = 0;
                PAGE1.MaxHeight = 0;
                PAGE2.MaxHeight = 0;
                PAGE3.MaxHeight = 0;
                PAGE4.MaxHeight = 0;
                PAGE5.MaxHeight = 0;
                PAGE6.MaxHeight = 0;
                PAGE7.MaxHeight = 0;
                PAGE8.MaxHeight = 0;
                PAGE9.MaxHeight = 0;

                OTHER_FRAME0.Tag = null;
                OTHER_FRAME1.Tag = null;
                OTHER_FRAME2.Tag = null;
                OTHER_FRAME3.Tag = null;
                OTHER_FRAME4.Tag = null;
                OTHER_FRAME5.Tag = null;
                OTHER_FRAME6.Tag = null;
                OTHER_FRAME7.Tag = null;
                OTHER_FRAME8.Tag = null;
                OTHER_FRAME9.Tag = null;

                OTHER_PAGE0.MaxHeight = 0;
                OTHER_PAGE1.MaxHeight = 0;
                OTHER_PAGE2.MaxHeight = 0;
                OTHER_PAGE3.MaxHeight = 0;
                OTHER_PAGE4.MaxHeight = 0;
                OTHER_PAGE5.MaxHeight = 0;
                OTHER_PAGE6.MaxHeight = 0;
                OTHER_PAGE7.MaxHeight = 0;
                OTHER_PAGE8.MaxHeight = 0;
                OTHER_PAGE9.MaxHeight = 0;

                PAGE_MAIN.MaxHeight = 5000;
                
            }
            else
            {
                List<ItsPageTml> childList = ItsElement.FindChild<ItsPageTml>(CURFRAME);
                if (childList.Count > 0)
                {
                    childList[0].EventMessageResult(command);
                }
            }
        }

        private Frame CURFRAME = null;
        private void MENU_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            UserControl menu = sender as UserControl;
            if (menu.Tag != null)
            {
                if (menu.Tag.ToString() == "OTHER_CLOSE")
                {
                    POP_OTHER_MENU.IsOpen = false;
                    return;
                }
                else if (menu.Tag.ToString() == "OTHER")
                {
                    POP_OTHER_MENU.IsOpen = true;
                    POP_OTHER_MENU.Focus();
                    e.Handled = true;
                    return;
                }
            }

            POP_OTHER_MENU.IsOpen = false;

            WAIT_MSG.Visibility = Visibility.Visible;
            ItsElement.Refresh(this);

            timer.Stop();

            CONFIG_CLOSE_MouseUp(null, null);
            MSG_CLOSE_MouseUp(null, null);

            PAGE_MAIN.MaxHeight = 0;

            //PAGE0.MaxHeight = 0;
            //PAGE1.MaxHeight = 0;
            //PAGE2.MaxHeight = 0;
            //PAGE3.MaxHeight = 0;
            //PAGE4.MaxHeight = 0;
            //PAGE5.MaxHeight = 0;
            //PAGE6.MaxHeight = 0;
            //PAGE7.MaxHeight = 0;
            //PAGE8.MaxHeight = 0;
            //PAGE9.MaxHeight = 0;

            //OTHER_PAGE0.MaxHeight = 0;
            //OTHER_PAGE1.MaxHeight = 0;
            //OTHER_PAGE2.MaxHeight = 0;
            //OTHER_PAGE3.MaxHeight = 0;
            //OTHER_PAGE4.MaxHeight = 0;
            //OTHER_PAGE5.MaxHeight = 0;
            //OTHER_PAGE6.MaxHeight = 0;
            //OTHER_PAGE7.MaxHeight = 0;
            //OTHER_PAGE8.MaxHeight = 0;
            //OTHER_PAGE9.MaxHeight = 0;

            LABEL_TITLE.Content = "[" + (sender as UserControl).Tag.ToString().Substring(0, 11)
                + "] " + (sender as UserControl).Content.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPRGVER';");
            DataSet ds = ItsMaria.Query(sb.ToString());
            string prgVer = ItsData.GetText(ds.Tables[0], 0, "REF01");

            if (prgVer != this.PrgVer)
            {
                ShowMessageBox("", "프로그램을 재시작해주세요.\n" + "현재버전: " + this.PrgVer + " -> 최신버전: " + prgVer);
            }

            //MENU0.Background = Brushes.WhiteSmoke; MENU0.Foreground = Brushes.Black;
            //MENU1.Background = Brushes.WhiteSmoke; MENU1.Foreground = Brushes.Black;
            //MENU2.Background = Brushes.WhiteSmoke; MENU2.Foreground = Brushes.Black;
            //MENU3.Background = Brushes.WhiteSmoke; MENU3.Foreground = Brushes.Black;
            //MENU4.Background = Brushes.WhiteSmoke; MENU4.Foreground = Brushes.Black;
            //MENU5.Background = Brushes.WhiteSmoke; MENU5.Foreground = Brushes.Black;
            //MENU6.Background = Brushes.WhiteSmoke; MENU6.Foreground = Brushes.Black;
            //MENU7.Background = Brushes.WhiteSmoke; MENU7.Foreground = Brushes.Black;
            //MENU8.Background = Brushes.WhiteSmoke; MENU8.Foreground = Brushes.Black;
            //MENU9.Background = Brushes.WhiteSmoke; MENU9.Foreground = Brushes.Black;

            //OTHER_MENU0.Background = Brushes.WhiteSmoke; OTHER_MENU0.Foreground = Brushes.Black;
            //OTHER_MENU1.Background = Brushes.WhiteSmoke; OTHER_MENU1.Foreground = Brushes.Black;
            //OTHER_MENU2.Background = Brushes.WhiteSmoke; OTHER_MENU2.Foreground = Brushes.Black;
            //OTHER_MENU3.Background = Brushes.WhiteSmoke; OTHER_MENU3.Foreground = Brushes.Black;
            //OTHER_MENU4.Background = Brushes.WhiteSmoke; OTHER_MENU4.Foreground = Brushes.Black;
            //OTHER_MENU5.Background = Brushes.WhiteSmoke; OTHER_MENU5.Foreground = Brushes.Black;
            //OTHER_MENU6.Background = Brushes.WhiteSmoke; OTHER_MENU6.Foreground = Brushes.Black;
            //OTHER_MENU7.Background = Brushes.WhiteSmoke; OTHER_MENU7.Foreground = Brushes.Black;
            //OTHER_MENU8.Background = Brushes.WhiteSmoke; OTHER_MENU8.Foreground = Brushes.Black;
            //OTHER_MENU9.Background = Brushes.WhiteSmoke; OTHER_MENU9.Foreground = Brushes.Black;

            UserControl CURMENU = sender as UserControl;
            CURMENU.Background = Brushes.Black;
            CURMENU.Foreground = Brushes.White;

            if (CURMENU == MENU9 && MENU9.Tag.ToString() == "OTHER")
            {
                POP_OTHER_MENU.IsOpen = true;

                WAIT_MSG.Visibility = Visibility.Visible;
                timer.Stop();

                return;
            }

            string menuNo = CURMENU.Name.Substring(4, 1);
            // 2019.08.06 박제홍 추가 기타메뉴, 일반메뉴 같이 나오는 문제
            string otherchk;

            if (menuNo != "R") // 예: OTHER_FRAME5 
            {
                otherchk = "N";
                CURFRAME = this.FindName("FRAME" + menuNo) as Frame;
            }
            else
            {
                otherchk = "Y";
                menuNo = CURMENU.Name.Substring(10, 1);
                CURFRAME = this.FindName("OTHER_FRAME" + menuNo) as Frame;
            }

            for (int i=0; i <= 9; i++)
            {
                if (i != Convert.ToInt32(menuNo))
                {
                    (this.FindName("PAGE" + i) as DockPanel).Visibility = Visibility.Collapsed;
                    (this.FindName("OTHER_PAGE" + i) as DockPanel).Visibility = Visibility.Collapsed;
                    (this.FindName("MENU" + i) as UserControl).Background = Brushes.WhiteSmoke;
                    (this.FindName("MENU" + i) as UserControl).Foreground = Brushes.Black;
                    (this.FindName("OTHER_MENU" + i) as UserControl).Background = Brushes.WhiteSmoke;
                    (this.FindName("OTHER_MENU" + i) as UserControl).Foreground = Brushes.Black;
                }
                else
                {
                    if (otherchk == "N")
                    {
                        (this.FindName("PAGE" + i) as DockPanel).Visibility = Visibility.Visible;
                        (this.FindName("OTHER_PAGE" + i) as DockPanel).Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        (this.FindName("PAGE" + i) as DockPanel).Visibility = Visibility.Collapsed;
                        (this.FindName("OTHER_PAGE" + i) as DockPanel).Visibility = Visibility.Visible;
                    }
                }
            }

            string pageName = (sender as UserControl).Tag.ToString();
            if (CURFRAME.Tag == null)
            {
                
                if (ItsLocalInfo.IsRunMode)
                {
                    try
                    {
                        webClient.DownloadFile(ItsServerInfo.ServerUrl + pageName.Substring(0, 7) + ".exe", pageName.Substring(0, 7) + ".exe");
                    }
                    catch { }
                }

                try
                {
                    Assembly pageAssembly = Assembly.LoadFrom(pageName.Substring(0, 7) + ".exe");

                    object assObj = pageAssembly.CreateInstance(pageName.Substring(0, 7) + "." + pageName.Substring(8));
                    Page page = assObj as Page;

                    menuNo = CURMENU.Name.Substring(4, 1);
                    if (menuNo != "R") // 예: OTHER_FRAME5 
                    {
                        (this.FindName("PAGE" + menuNo) as DockPanel).MaxHeight = page.Height;
                    }
                    else
                    {
                        menuNo = CURMENU.Name.Substring(10, 1);
                        (this.FindName("OTHER_PAGE" + menuNo) as DockPanel).MaxHeight = page.Height;
                    }

                    CURFRAME.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                    CURFRAME.Navigate(page);
                    CURFRAME.Tag = (sender as UserControl).Tag;

                    
                }
                catch
                {
                    WAIT_MSG.Visibility = Visibility.Hidden;
                    ShowMessageBox("", (sender as UserControl).Tag.ToString() + " 를 로딩하지 못했습니다.");
                }
            }

            try
            {
                if (CURFRAME.Tag.ToString().Contains("TML"))
                    ItsElement.ActiveTml = CURFRAME.Tag.ToString();
                else
                    ItsElement.ActivePage = (ItsPageBase)(CURFRAME.Content);
            }
            catch { }

            WAIT_MSG.Visibility = Visibility.Hidden;
            timer.Start();
        }

        private void PASS_CHECK_Click(object sender, RoutedEventArgs e)
        {
            CONFIG_PASS_KeyDown(null, null);
        }

        private void CONFIG_PASS_KeyDown(object sender, KeyEventArgs e)
        {

            if (PANEL_CONFIG.MaxHeight == 0)
            {
                // ICON_CONFIG_MouseDown(null, null);
                CONFIG_PASS.Value = "";
                return;
            }

            if (e == null || e.Key == Key.Enter)
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPASS';");
                string pass = ItsData.GetScalar(ItsMaria.Query(query.ToString()));

                if (pass == CONFIG_PASS.Value)
                {
                    CONFIG_PASS.Visibility = Visibility.Collapsed;
                    PASS_CHECK.MaxHeight = 0;

                    CONFIG_LINE.MaxHeight = 0;
                    PANEL_OPTION.MaxHeight = 5000;
                }
                else
                {
                    ShowMessageBox("", "비밀번호를 정확하게 입력하세요.");
                    PASS_CHECK.Focus();
                }
            }
        }

        public void LoadMenu(string pName)
        {
            UserControl menu = null;

            int j = 0;
            while(true)
            {
                menu = PANEL_MENU.FindName(j < 10 ? "MENU" + j : "OTHER_MENU" + (j - 10)) as UserControl;

                if (menu == null)
                    return;
                else if (pName == Convert.ToString(menu.Tag))
                    break;

                j++;
            }

            if (menu.Tag != null)
            {
                if (menu.Tag.ToString() == "OTHER_CLOSE")
                {
                    POP_OTHER_MENU.IsOpen = false;
                    return;
                }
                else if (menu.Tag.ToString() == "OTHER")
                {
                    POP_OTHER_MENU.IsOpen = true;
                    POP_OTHER_MENU.Focus();
                    
                    return;
                }
            }
            
            POP_OTHER_MENU.IsOpen = false;

            WAIT_MSG.Visibility = Visibility.Visible;
            ItsElement.Refresh(this);

            timer.Start();

            CONFIG_CLOSE_MouseUp(null, null);
            MSG_CLOSE_MouseUp(null, null);

            PAGE_MAIN.MaxHeight = 0;

            LABEL_TITLE.Content = "[" + menu.Tag.ToString().Substring(0, 11)
                + "] " + menu.Content.ToString();


            UserControl CURMENU = menu;//sender as UserControl;
            CURMENU.Background = Brushes.Black;
            CURMENU.Foreground = Brushes.White;

            //if (CURMENU == MENU9 && MENU9.Tag.ToString() == "OTHER")
            //{
            //    POP_OTHER_MENU.IsOpen = true;

            //    WAIT_MSG.Visibility = Visibility.Visible;
            //    timer.Stop();

            //    return;
            //}

            string menuNo = CURMENU.Name.Substring(4, 1);
            // 2019.08.06 박제홍 추가 기타메뉴, 일반메뉴 같이 나오는 문제
            string otherchk;

            if (menuNo != "R") // 예: OTHER_FRAME5 
            {
                otherchk = "N";
                CURFRAME = this.FindName("FRAME" + menuNo) as Frame;
            }
            else
            {
                otherchk = "Y";
                menuNo = CURMENU.Name.Substring(10, 1);
                CURFRAME = this.FindName("OTHER_FRAME" + menuNo) as Frame;
            }

            for (int i = 0; i <= 9; i++)
            {
                if (i != Convert.ToInt32(menuNo))
                {
                    (this.FindName("PAGE" + i) as DockPanel).Visibility = Visibility.Collapsed;
                    (this.FindName("OTHER_PAGE" + i) as DockPanel).Visibility = Visibility.Collapsed;
                    (this.FindName("MENU" + i) as UserControl).Background = Brushes.WhiteSmoke;
                    (this.FindName("MENU" + i) as UserControl).Foreground = Brushes.Black;
                    (this.FindName("OTHER_MENU" + i) as UserControl).Background = Brushes.WhiteSmoke;
                    (this.FindName("OTHER_MENU" + i) as UserControl).Foreground = Brushes.Black;
                }
                else
                {
                    if (otherchk == "N")
                    {
                        (this.FindName("PAGE" + i) as DockPanel).Visibility = Visibility.Visible;
                        (this.FindName("OTHER_PAGE" + i) as DockPanel).Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        (this.FindName("PAGE" + i) as DockPanel).Visibility = Visibility.Collapsed;
                        (this.FindName("OTHER_PAGE" + i) as DockPanel).Visibility = Visibility.Visible;
                    }
                }
            }

            string pageName = menu.Tag.ToString();
            if (CURFRAME.Tag == null)
            {

                if (ItsLocalInfo.IsRunMode)
                {
                    try
                    {
                        webClient.DownloadFile(ItsServerInfo.ServerUrl + pageName.Substring(0, 7) + ".exe", pageName.Substring(0, 7) + ".exe");
                    }
                    catch { }
                }

                try
                {
                    Assembly pageAssembly = Assembly.LoadFrom(pageName.Substring(0, 7) + ".exe");

                    object assObj = pageAssembly.CreateInstance(pageName.Substring(0, 7) + "." + pageName.Substring(8));
                    Page page = assObj as Page;

                    menuNo = CURMENU.Name.Substring(4, 1);
                    if (menuNo != "R") // 예: OTHER_FRAME5 
                    {
                        (this.FindName("PAGE" + menuNo) as DockPanel).MaxHeight = page.Height;
                    }
                    else
                    {
                        menuNo = CURMENU.Name.Substring(10, 1);
                        (this.FindName("OTHER_PAGE" + menuNo) as DockPanel).MaxHeight = page.Height;
                    }

                    CURFRAME.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                    CURFRAME.Navigate(page);
                    CURFRAME.Tag = menu.Tag;
                }
                catch
                {
                    WAIT_MSG.Visibility = Visibility.Hidden;
                    ShowMessageBox("", menu.Tag.ToString() + " 를 로딩하지 못했습니다.");
                }
            }

            try
            {
                if (CURFRAME.Tag.ToString().Contains("TML"))
                    ItsElement.ActiveTml = CURFRAME.Tag.ToString();
                else
                    ItsElement.ActivePage = (ItsPageBase)(CURFRAME.Content);
            }
            catch { }

            WAIT_MSG.Visibility = Visibility.Hidden;
            timer.Stop();
        }

        private void BTN_SET_TMLEMP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //POP_EMPCD.REF01 = TMLCD;
            //POP_TMLEMP.IsOpen = true;
            //POP_TMLEMP.Focus();
            ////e.Handled = true;
            //return;
        }

        private void SET_TMLEMP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //System.IO.File.WriteAllText("ConfigEmpcd.config", POP_EMPCD.Value, Encoding.UTF8);
            //ItsLocalInfo.TMLEMP = System.IO.File.ReadAllText("ConfigEmpcd.config", Encoding.UTF8);

            //POP_TMLEMP.IsOpen = false;

            //string emp = ItsData.GetScalar(ItsMaria.Query("SELECT EMPNM FROM MSTEMP WHERE EMPCD = '" + POP_EMPCD.Value + "';"));
            //if (emp == "")
            //{
            //    ShowMessageBox("", "담당자코드를 정확히 입력하세요.");
            //    return;
            //}
            //else
            //    LABEL_TMLEMP.Content = emp;

            //return;
        }

        private void TMLEMP_POP_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //if (e != null)
            //{
            //    e.Handled = true;
            //    if (e.ChangedButton != MouseButton.Left) return;
            //}

            //if (POP_TMLEMP.IsOpen == true)
            //{
            //    POP_TMLEMP.IsOpen = false;
            //    return;
            //}
            //else
            //{
            //    POP_TMLEMP.IsOpen = true;
            //    POP_TMLEMP.Focus();
            //    return;
            //}
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ItsMaria.Set("ITSLOGIN", "LOGOUT");
            ItsMaria.AddOne("SESSION_LOGINKEY", ItsMemberShip.LoginKey);
            ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
        }

        private void COMBO_PRINT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            File.WriteAllText(_printFile, COMBO_PRINT.SelectedItem.ToString(), Encoding.UTF8);
        }
    }
}
