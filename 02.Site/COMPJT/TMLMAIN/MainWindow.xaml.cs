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
using DevExpress.XtraReports.UI;

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

    public partial class MainWindow : Window
    {
        ItsModelPanel MODEL_WAIT = new ItsModelPanel();
        ItsModelPanel MODEL_CONFIG = new ItsModelPanel();
        // 2025-04-09 프린트 선택 옵션
        ItsModelPanel MODEL_MAIN = new ItsModelPanel();

        private System.Net.WebClient webClient = new System.Net.WebClient();

        // 2025-04-08 프로그램 버전 관리 -> 수정시 재실행 메시지 팝업용
        public string PrgVer = "";

        public MainWindow()
        {
            InitializeComponent();

          //  MODEL_WAIT.Binding(WAIT_ICON);
            MODEL_WAIT.FieldType("WAITVISIBLE", ItsEnums.FieldTypes.String);
            MODEL_WAIT.DefaultValue("WAITVISIBLE", "Visible");
            MODEL_WAIT.InitData();

            MODEL_CONFIG.Binding(PANEL_OPTION);
            MODEL_CONFIG.Binding(PANEL_PASSWORD);

            MODEL_CONFIG.FieldType("BDVCD", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("TMLCD", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("PRINT", ItsEnums.FieldTypes.String);
            //MODEL_CONFIG.FieldType("PRINT_SALES1", ItsEnums.FieldTypes.String);
            //MODEL_CONFIG.FieldType("PRINT_SALES2", ItsEnums.FieldTypes.String);
            //MODEL_CONFIG.FieldType("PRINT_DAESIN", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("PORTSCALE", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("PORTPLC", ItsEnums.FieldTypes.String);
            MODEL_CONFIG.FieldType("EMPCD", ItsEnums.FieldTypes.String);
            //MODEL_CONFIG.FieldType("PRINTTP", ItsEnums.FieldTypes.String);

            MODEL_CONFIG.InitData();
            MODEL_CONFIG.EventValueChanged += MODEL_CONFIG_EventValueChanged;

            // 2025-04-09 프린트 변경에 대한 처리
            MODEL_MAIN.Binding(DOCK_TITLE);
            MODEL_MAIN.FieldType("PRINT", ItsEnums.FieldTypes.String);
            MODEL_MAIN.InitData();
            MODEL_MAIN.EventValueChanged += MODEL_MAIN_EventValueChanged;

            COMBO_PRINT.ItemClear();
            //COMBO_PRINT_SALES1.ItemClear();
            //COMBO_PRINT_SALES2.ItemClear();
            //COMBO_PRINT_DAESIN.ItemClear();
            int count = PrinterSettings.InstalledPrinters.Count;
            for (int i = 0; i < count; i++)
            {
                COMBO_PRINT.AddItem(PrinterSettings.InstalledPrinters[i], PrinterSettings.InstalledPrinters[i]);
                //COMBO_PRINT_SALES1.AddItem(PrinterSettings.InstalledPrinters[i], PrinterSettings.InstalledPrinters[i]);
                //COMBO_PRINT_SALES2.AddItem(PrinterSettings.InstalledPrinters[i], PrinterSettings.InstalledPrinters[i]);
                //COMBO_PRINT_DAESIN.AddItem(PrinterSettings.InstalledPrinters[i], PrinterSettings.InstalledPrinters[i]);
            }

            //COMBO_PRINT.Items.Clear();
            //int count = PrinterSettings.InstalledPrinters.Count;
            //for (int i = 0; i < count; i++)
            //{
            //    COMBO_PRINT.Items.Add(PrinterSettings.InstalledPrinters[i]);
            //}

            ItsElement.TML_MAIN_WINDOW = this;
            this.WindowState = WindowState.Maximized;

            if (ItsLocalInfo.IsRunMode)
            {
                this.Topmost = true;
            }

            //ICON_MENU_MouseDown(null, null);
            MSG_CLOSE_MouseUp(null, null);
            CONFIG_CLOSE_MouseUp(null, null);

            this.Loaded += MainWindow_Loaded;
            this.Activated += MainWindow_Activated;

            // 최초 실행시 프로그램 버전 가져오기
            DataTable dt = ItsMaria.Query("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPRGVER';").Tables[0];
            this.PrgVer = ItsData.GetText(dt, 0, "REF01");
        }

        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    {
                        RoutedEvent = Keyboard.KeyDownEvent
                    };
                    InputManager.Current.ProcessInput(e);

                    // Note: Based on your requirements you may also need to fire events for:
                    // RoutedEvent = Keyboard.PreviewKeyDownEvent
                    // RoutedEvent = Keyboard.KeyUpEvent
                    // RoutedEvent = Keyboard.PreviewKeyUpEvent
                }
            }
        }

        private void MODEL_CONFIG_EventValueChanged(string fieldName)
        {
            if (fieldName == "BDVCD")
            {
                ItsElement.TML_MAIN_WINDOW.COMBO_TMLCD.ItemClear();
                ItsElement.TML_MAIN_WINDOW.COMBO_TMLCD.REF01 = MODEL_CONFIG.GetText("BDVCD");
                ItsElement.TML_MAIN_WINDOW.COMBO_TMLCD.Value = File.ReadAllText(MainWindow._tmlcdFile, Encoding.UTF8);
            }
        }

        // 2025-04-09 프린트 선택 변경시 환경설정값 변경
        private void MODEL_MAIN_EventValueChanged(string fieldName)
        {
            if (fieldName == "PRINT")
            {
                File.WriteAllText(_printFile, MODEL_MAIN.GetText("PRINT"), Encoding.UTF8);
            }
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            if (ItsLocalInfo.IsRunMode)
            {
                this.Topmost = false;
            }
        }

        public static System.Timers.Timer timer;            // AUTO PRINT
        public static System.Timers.Timer timer2;           // 프로그램 버전관리용
        public static System.Timers.Timer timer3;           // 시간보여주기용
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CONFIG_CLOSE_MouseUp(null, null);
            PASS_CHECK.Focus();
            WAIT_MSG.Visibility = Visibility.Hidden;

            double printTimeout = 5000;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT REF01");
                sb.AppendLine("FROM COMTYPE");
                sb.AppendLine("WHERE GPCD = 'GLOBAL' AND TPCD = 'AUTOPRINT';");
                printTimeout = 1000 * Convert.ToDouble(ItsData.GetScalar(ItsMaria.Query(sb.ToString())));
            }
            catch
            {
                printTimeout = 5000;
            }

            // 자동발행 경진FA는 미사용
            timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = printTimeout;
            timer.Stop();

            // 프로그램 버전 관리
            timer2 = new System.Timers.Timer();
            timer2.Elapsed += Timer2_Elapsed; ;
            timer2.Interval = 1000 * 60;

            timer3 = new System.Timers.Timer();
            timer3.Elapsed += Timer3_Elapsed;
            timer3.Interval = 100;
            timer3.Start();

            if (!File.Exists(_bdvcdFile)) File.WriteAllText(_bdvcdFile, "");
            MODEL_CONFIG.SetValue("BDVCD", File.ReadAllText(_bdvcdFile, Encoding.UTF8));

            if (!File.Exists(_tmlcdFile)) File.WriteAllText(_tmlcdFile, "");
            MODEL_CONFIG.SetValue("TMLCD", File.ReadAllText(_tmlcdFile, Encoding.UTF8));

            if (!File.Exists(_printFile)) File.WriteAllText(_printFile, "");
            MODEL_CONFIG.SetValue("PRINT", File.ReadAllText(_printFile, Encoding.UTF8));

            // 2025-04-09 기존 세팅된 프린트값 지정
            if (!File.Exists(_printFile)) File.WriteAllText(_printFile, "");
            MODEL_MAIN.SetValue("PRINT", File.ReadAllText(_printFile, Encoding.UTF8));

            //if (!File.Exists(_printFileSales1)) File.WriteAllText(_printFileSales1, "");
            //MODEL_CONFIG.SetValue("PRINT_SALES1", File.ReadAllText(_printFileSales1, Encoding.UTF8));

            //if (!File.Exists(_printFileSales2)) File.WriteAllText(_printFileSales2, "");
            //MODEL_CONFIG.SetValue("PRINT_SALES2", File.ReadAllText(_printFileSales2, Encoding.UTF8));

            //if (!File.Exists(_printFileDaesin)) File.WriteAllText(_printFileDaesin, "");
            //MODEL_CONFIG.SetValue("PRINT_DAESIN", File.ReadAllText(_printFileDaesin, Encoding.UTF8));

            if (!File.Exists(_scalePortFile)) File.WriteAllText(_scalePortFile, "");
            MODEL_CONFIG.SetValue("PORTSCALE", File.ReadAllText(_scalePortFile, Encoding.UTF8));

            if (!File.Exists(_plcPortFile)) File.WriteAllText(_plcPortFile, "");
            MODEL_CONFIG.SetValue("PORTPLC", File.ReadAllText(_plcPortFile, Encoding.UTF8));

            if (!File.Exists(_empcdFile)) File.WriteAllText(_empcdFile, "");
            MODEL_CONFIG.SetValue("TMLEMP", File.ReadAllText(_empcdFile, Encoding.UTF8));

            //if (!File.Exists(_printtpFile)) File.WriteAllText(_printtpFile, "");
            //MODEL_CONFIG.SetValue("PRINTTP", File.ReadAllText(_printtpFile, Encoding.UTF8));

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
                //LABEL_TITLE.Content = ItsData.GetScalar(ItsMaria.Query(sb.ToString()));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("메인화면을 로딩하지 못했습니다. TML0000.exe");
                MessageBox.Show(ex.Message);
            }

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                if (AUTOPRINT.IsChecked == true)
                {
                    ItsMariaThread maria = new ItsMariaThread();
                    maria.Set("TMLMAIN", "AUTO_PRINT_ORDER_LIST");
                    maria.AddOne("TMLCD", MODEL_CONFIG.GetText("TMLCD"));
                    maria.AddOne("CENTERCD", ItsLocalInfo.BDVCD);
                    maria.AddOne("PRINTTP", ItsLocalInfo.PRINTTP);

                    DataSet ds1 = maria.Call();
                    if (maria.IsError)
                    {
                        AUTOPRINT.IsChecked = false;
                        ShowMessageBox("", maria.ErrMessage);
                    }
                    else
                    {
                        if (ds1.Tables.Count > 1)
                        {
                            try
                            {
                                TMLRPT.AUTO_PRINT_ORDER_LIST rpt = new TMLRPT.AUTO_PRINT_ORDER_LIST();
                                rpt.DataSource = ds1.Tables[0];
                                rpt.PrinterName = ItsLocalInfo.PRINT_SALES2;
                                rpt.PrintingSystem.ShowMarginsWarning = false;
                                rpt.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                                ReportPrintTool tool = new ReportPrintTool(rpt);
                                tool.PrintingSystem.ShowPrintStatusDialog = false;
                                tool.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                                tool.Print();
                            }
                            catch(Exception ex)
                            {
                                AUTOPRINT.IsChecked = false;
                                ShowMessageBox("", ex.Message);
                            }
                        }
                    }

                    // 물류이동
                    //ItsMariaThread maria2 = new ItsMariaThread();
                    //maria2.Set("TMLMAIN", "AUTO_PRINT_MOVE");
                    //maria2.AddOne("TMLCD", MODEL_CONFIG.GetText("TMLCD"));
                    //maria2.AddOne("CENTERCD", ItsLocalInfo.BDVCD);
                    //DataSet ds2 = maria2.Call();
                    //if (maria2.IsError)
                    //{
                    //    AUTOPRINT.IsChecked = false;
                    //    ShowMessageBox("", maria2.ErrMessage);
                    //}
                    //else
                    //{
                    //    if (ds2.Tables.Count > 1)
                    //    {
                    //        TMLRPT.AUTO_PRINT_MOVE rpt = new TMLRPT.AUTO_PRINT_MOVE();
                    //        rpt.DataSource = ds2.Tables[0];
                    //        rpt.PrinterName = ItsLocalInfo.PRINT_SALES2;
                    //        rpt.PrintingSystem.ShowMarginsWarning = false;
                    //        ReportPrintTool tool = new ReportPrintTool(rpt);
                    //        tool.PrintingSystem.ShowPrintStatusDialog = false;
                    //        tool.Print();
                    //    }
                    //}

                }
            }));

            timer.Start();
        }

        private void Timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer2.Stop();

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

            timer2.Start();
        }

        private void Timer3_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                LABEL_TITLE_TIME.Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }));
        }

        private double _width = 0;
        private double _height = 0;

        private void SetMenu(string tmlcode)
        {
            ItsMaria.Set("TMLMAIN", "LIST_PRG");
            ItsMaria.AddOne("TMLCD", MODEL_CONFIG.GetText("TMLCD"));
            ItsMaria.AddOne("USERID", ItsMemberShip.USERID);
            
            DataSet ds = ItsMaria.Call();

            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            else
            {
                // 2026-11-16 상단 메뉴줄 → 전체화면 타일 메뉴. 메뉴 개수만큼 타일과 화면 칸을 만든다
                BuildMenus(ds.Tables[0]);
                ShowHome();
            }
        }

        private void ICON_MIN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 한번씩 포커스 남아있는 경우..
            CONFIG_PASS.CloseKeypad();

            if (e.LeftButton != MouseButtonState.Pressed) return;

            this.WindowState = WindowState.Minimized;
            // this.Topmost = false;
        }

        private void ICON_CLOSE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;

            if (PANEL_HOME.Visibility == Visibility.Visible)
            {
                ShowMessageBox("__MainClose", "전체 화면을 닫으시겠습니까?");
            }
            else
            {
                ShowMessageBox("__PageClose", "현재 화면을 닫으시겠습니까?");
            }
        }

        public static string _bdvcdFile = "ConfigBdvcd.config";
        public static string _tmlcdFile = "ConfigTmlcd.config";
        public static string _printFile = "ConfigPrintBarcode.config";
        //public static string _printFileSales1 = "ConfigPrintSales1.config";
        //public static string _printFileSales2 = "ConfigPrintSales2.config";
        //public static string _printFileDaesin = "ConfigPrintDaesin.config";
        public static string _scalePortFile = "ConfigPortScale.config";
        public static string _plcPortFile = "ConfigPortPlc.config";
        public static string _empcdFile = "ConfigEmpcd.config";
        //public static string _printtpFile = "ConfigPrinttp.config";

        private string _curTmlcd = "";
        private void ICON_CONFIG_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GRID_CONTENT.Visibility = Visibility.Hidden;

            _curTmlcd = MODEL_CONFIG.GetText("TMLCD");

            if (CURFRAME != null) CURFRAME.IsEnabled = false;

            PANEL_CONFIG.MaxHeight = 5000;
            CONFIG_LINE.MaxHeight = 10;
            ConfigCommit.Visibility = Visibility.Hidden;
            ConfigClose.Visibility = Visibility.Hidden;

            PANEL_MSG.MaxHeight = 0;
           // MsgIcon.Visibility = Visibility.Hidden;
            MsgCommit.Visibility = Visibility.Hidden;
            MsgClose.Visibility = Visibility.Hidden;

            CONFIG_PASS.MaxHeight = 5000;
            PASS_CHECK.MaxHeight = 5000;
            PANEL_OPTION.MaxHeight = 0;
            PANEL_PASSWORD.Width = 600;

            //CONFIG_PASS.Password = "";
            CONFIG_PASS.Value = "";
            CONFIG_PASS.Focus();

            //COMBO_PLCPORT.ItemClear();
            //COMBO_SCALEPORT.ItemClear();
            //for (int i = 1; i < 10; i++)
            //{
            //    COMBO_PLCPORT.AddItem("COM" + i, "COM" + i);
            //    COMBO_SCALEPORT.AddItem("COM" + i, "COM" + i);
            //}

            //try
            //{
            //    COMBO_SCALEPORT.Value = System.IO.File.ReadAllText(_scalePortFile, Encoding.UTF8);
            //    COMBO_PLCPORT.Value = System.IO.File.ReadAllText(_plcPortFile, Encoding.UTF8);
            //}
            //catch { }
        }
 
        private void CONFIG_COMMIT_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            GRID_CONTENT.Visibility = Visibility.Visible;

            File.WriteAllText(_bdvcdFile, MODEL_CONFIG.GetText("BDVCD"), Encoding.UTF8);
            File.WriteAllText(_tmlcdFile, MODEL_CONFIG.GetText("TMLCD"), Encoding.UTF8);
            File.WriteAllText(_printFile, MODEL_CONFIG.GetText("PRINT"), Encoding.UTF8);
            //File.WriteAllText(_printFileSales1, MODEL_CONFIG.GetText("PRINT_SALES1"), Encoding.UTF8);
            //File.WriteAllText(_printFileSales2, MODEL_CONFIG.GetText("PRINT_SALES2"), Encoding.UTF8);
            //File.WriteAllText(_printFileDaesin, MODEL_CONFIG.GetText("PRINT_DAESIN"), Encoding.UTF8);
            File.WriteAllText(_scalePortFile, MODEL_CONFIG.GetText("PORTSCALE"), Encoding.UTF8);
            File.WriteAllText(_plcPortFile, MODEL_CONFIG.GetText("PORTPLC"), Encoding.UTF8);
            File.WriteAllText(_empcdFile, MODEL_CONFIG.GetText("TMLEMP"), Encoding.UTF8);
            //File.WriteAllText(_printtpFile, MODEL_CONFIG.GetText("PRINTTP"), Encoding.UTF8);

            ItsLocalInfo._SetBDVCD(MODEL_CONFIG.GetText("BDVCD"));
            //ItsLocalInfo._SetPrintSales1(MODEL_CONFIG.GetText("PRINT_SALES1"));
            //ItsLocalInfo._SetPrintSales2(MODEL_CONFIG.GetText("PRINT_SALES2"));
            //ItsLocalInfo._SetPrintDaesin(MODEL_CONFIG.GetText("PRINT_DAESIN"));
            ItsLocalInfo._SetPORTSCALE(MODEL_CONFIG.GetText("PORTSCALE"));
            ItsLocalInfo._SetPORTPLC(MODEL_CONFIG.GetText("PORTPLC"));
            ItsLocalInfo.TMLEMP = MODEL_CONFIG.GetText("TMLEMP");
            //ItsLocalInfo._SetPRINTTP(MODEL_CONFIG.GetText("PRINTTP"));

            if (_curTmlcd != MODEL_CONFIG.GetText("TMLCD"))
            {
                SetMenu(MODEL_CONFIG.GetText("TMLCD"));
                ItsLocalInfo._TMLINFORELOAD = true;
                string __tmlcd = ItsLocalInfo.TMLCD; // tmlware 갱신 효과
            }

            HideAllPages();

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

            GRID_CONTENT.Visibility = Visibility.Visible;

            PANEL_CONFIG.MaxHeight = 0;
            if (CURFRAME != null) CURFRAME.IsEnabled = true;


            CONFIG_PASS.CloseKeypad();
            ConfigClose.Visibility = Visibility.Hidden;
            ConfigCommit.Visibility = Visibility.Hidden;
        }

        //private void ICON_MENU_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    LEFT_MENU.MaxWidth = 1000;
        //    ICON_MENU.MaxWidth = 0;
        //    ICON_MENU.Visibility = Visibility.Hidden;
        //}

        //private void ICON_HIDE_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    LEFT_MENU.MaxWidth = 0;
        //    ICON_MENU.Visibility = Visibility.Visible;
        //    ICON_MENU.MaxWidth = 1000;
        //}

        // 2025-04-10 메시지박스 수정
        private string command = "";
        public void ShowMessageBox(string commandName, string msg, string msgType)
        {
            command = commandName;
            TEXT_MSG.Text = msg;

            if (CURFRAME != null) CURFRAME.IsEnabled = false;

            PANEL_MSG.MaxHeight = 5000;
            //MsgIcon.Visibility = Visibility.Visible;
            if (msgType == "WARN")
            {
                Color clr = Color.FromRgb(232, 179, 87);
                MsgCommit.Background = new SolidColorBrush(clr);
                MsgCommit.Margin = new Thickness(0, 9, 10, 9);   // 2026-11-16 버튼 오른쪽 정렬로 바꿈
                MsgCommit.Visibility = Visibility.Visible;
                MsgClose.Visibility = Visibility.Hidden;
                MsgClose.Width = 0;
                TEXT_MSG_IMG.ImageSource = new BitmapImage(new Uri("pack://application:,,,/TMLMAIN;component/popup_bg_warning.png"));
            }
            else if (msgType == "ERR" || command == "")
            {
                Color clr = Color.FromRgb(243, 86, 90);
                MsgCommit.Background = new SolidColorBrush(clr);
                MsgCommit.Margin = new Thickness(0, 9, 10, 9);
                MsgCommit.Visibility = Visibility.Visible;
                MsgClose.Visibility = Visibility.Hidden;
                MsgClose.Width = 0;
                TEXT_MSG_IMG.ImageSource = new BitmapImage(new Uri("pack://application:,,,/TMLMAIN;component/popup_bg_error.png"));
            }
            else
            {
                Color clr = Color.FromRgb(70, 140, 198);
                MsgCommit.Background = new SolidColorBrush(clr);
                MsgCommit.Margin = new Thickness(0, 9, 5, 9);
                MsgCommit.Visibility = Visibility.Visible;
                MsgClose.Visibility = Visibility.Visible;
                MsgClose.Width = 50;
                TEXT_MSG_IMG.ImageSource =new BitmapImage(new Uri("pack://application:,,,/TMLMAIN;component/popup_bg_choice.png"));
            }
            
            PANEL_MSG.Focus();
        }
        public void ShowMessageBox(string commandName, string msg)
        {
            ShowMessageBox(commandName, msg, "");
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

           // MsgIcon.Visibility = Visibility.Hidden;
            MsgCommit.Visibility = Visibility.Hidden;
            MsgClose.Visibility = Visibility.Hidden;

            if (PANEL_CONFIG.Visibility == Visibility.Visible)
            {
                //CONFIG_PASS.Password = "";
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
           // MsgIcon.Visibility = Visibility.Hidden;
            MsgCommit.Visibility = Visibility.Hidden;
            MsgClose.Visibility = Visibility.Hidden;

            if (PANEL_CONFIG.Visibility == Visibility.Visible)
            {
                //CONFIG_PASS.Password = "";
                CONFIG_PASS.Value = "";
                CONFIG_PASS.Focus();
            }

            if (command == "__MainClose")
            {
                this.Close();
            }
            else if (command == "__MenuRefresh")
            {
                RefreshMenu();
            }
            else if (command == "__PageClose")
            {
                ClearAllFrames();
                HideAllPages();

                PAGE_MAIN.MaxHeight = 5000;
                CURFRAME = null;
                ShowHome();

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

        // ------------------------------------------------------------------------------------------
        // 타일 메뉴 : 2026-11-16 상단 메뉴줄(MENU0~10 + 기타메뉴) → 로그인 후 전체화면 타일 메뉴
        // 타일과 화면 칸은 같은 순서(index)로 짝을 이룬다. 타일의 Tag = 화면코드(PRGCD)
        // ------------------------------------------------------------------------------------------
        private List<UserControl> _menus = new List<UserControl>();
        private List<DockPanel> _pages = new List<DockPanel>();
        private UserControl _pressedTile = null;   // 마우스를 누른 타일 (뗄 때 같은 타일이어야 연다)

        // 메뉴 목록(0열 PRGCD, 1열 PRGNM)으로 타일·화면 칸을 새로 만든다 (이전 것은 지움)
        private void BuildMenus(DataTable dt)
        {
            foreach (DockPanel oldPage in _pages)
            {
                if (CURFRAME != null && oldPage.Children.Contains(CURFRAME))
                {
                    CURFRAME = null;
                    PAGE_MAIN.MaxHeight = 5000;
                }
                DOCK_FRAME.Children.Remove(oldPage);
            }
            GRID_TILE.Children.Clear();
            GRID_TILE.RowDefinitions.Clear();
            GRID_TILE.ColumnDefinitions.Clear();
            _menus.Clear();

            _pages.Clear();

            Dictionary<string, string[]> tileInfo = GetTileInfo();

            // 칸 나누기 : 보통 타일은 한 칸, 반칸 타일(TILEHALFYN=Y)은 순번상 이어진 2개가 한 칸을 왼쪽·오른쪽으로 나눠 쓴다
            // 열바꿈(TILEBREAKYN=Y) 타일이 들어간 칸 다음부터는 다음 열 맨 위에서 시작한다 (반칸 짝도 거기서 끊음)
            int[] cellNo = new int[dt.Rows.Count];
            bool[] isHalf = new bool[dt.Rows.Count];
            bool[] isRight = new bool[dt.Rows.Count];
            List<bool> breakAfterCell = new List<bool>();   // 칸마다 : 이 칸 다음에 열을 바꾸는지
            int cellCount = 0;
            bool halfOpen = false;   // 왼쪽만 찬 반칸 칸이 있음
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string prgcd = dt.Rows[i][0].ToString();
                isHalf[i] = tileInfo.ContainsKey(prgcd) && tileInfo[prgcd][2] == "Y";
                bool isBreak = tileInfo.ContainsKey(prgcd) && tileInfo[prgcd][3] == "Y";
                if (isHalf[i] && halfOpen)
                {
                    cellNo[i] = cellCount - 1;
                    isRight[i] = true;
                    halfOpen = false;
                }
                else
                {
                    cellNo[i] = cellCount++;
                    breakAfterCell.Add(false);
                    halfOpen = isHalf[i];
                }
                if (isBreak)
                {
                    breakAfterCell[cellNo[i]] = true;
                    halfOpen = false;
                }
            }

            // 줄 수 : 메뉴 개수와 상관없이 5줄 고정 (2026-11-16 사용자 지시)
            const int rows = 5;

            // 칸 위치 : 위→아래로 채우고, 줄이 다 차거나 열바꿈이면 다음 열로
            int[] cellRow = new int[cellCount];
            int[] cellCol = new int[cellCount];
            int curRow = 0, curCol = 0;
            for (int c = 0; c < cellCount; c++)
            {
                cellRow[c] = curRow;
                cellCol[c] = curCol;
                curRow++;
                if (curRow >= rows || breakAfterCell[c])
                {
                    curRow = 0;
                    curCol++;
                }
            }

            // 열 수 : 최소 4열. 한 열은 [왼쪽 절반][오른쪽 절반] 두 칸이고, 열 사이에 간격 칸이 있다 → 열 c 의 시작 칸 = c * 3
            int cols = Math.Max(4, cellCount == 0 ? 0 : cellCol[cellCount - 1] + 1);

            // 6열까지는 화면 폭에 맞춘다. 7열부터는 열 폭을 6열일 때로 고정하고 넓어진 만큼 가로 스크롤
            //   화면 폭(논리 단위) 600 - 여백 12 = 588, 열 사이 간격 10
            const double tileAreaWidth = 588;
            const double colGap = 10;
            if (cols > 6)
            {
                double colWidth = (tileAreaWidth - colGap * 5) / 6;
                GRID_TILE.Width = colWidth * cols + colGap * (cols - 1);
                SCROLL_TILE.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
            else
            {
                // 가로 스크롤을 끄면 화면 폭 안에서 열이 늘어난다 (켜 두면 폭 제한이 없어 열이 내용 크기로 줄어듦)
                GRID_TILE.Width = double.NaN;
                SCROLL_TILE.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            SCROLL_TILE.ScrollToHorizontalOffset(0);

            // 타일 안쪽 크기 (이름 글자 크기·줄바꿈 계산용) : 칸 크기 - 타일 바깥 여백 6 - 안쪽 여백 (가로 8, 세로 4)
            double colWidthNow = cols > 6 ? (tileAreaWidth - colGap * 5) / 6 : (tileAreaWidth - colGap * (cols - 1)) / cols;
            double tileAreaHeight = (PANEL_HOME.ActualHeight > 0 ? PANEL_HOME.ActualHeight : 275) - 12;
            double innerH = tileAreaHeight / rows - 6 - 4;

            for (int r = 0; r < rows; r++) GRID_TILE.RowDefinitions.Add(new RowDefinition());
            for (int c = 0; c < cols; c++)
            {
                if (c > 0) GRID_TILE.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10) });   // 열 사이 간격
                GRID_TILE.ColumnDefinitions.Add(new ColumnDefinition());   // 왼쪽 절반
                GRID_TILE.ColumnDefinitions.Add(new ColumnDefinition());   // 오른쪽 절반
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string prgcd = dt.Rows[i][0].ToString();
                string prgnm = dt.Rows[i][1].ToString().Trim();

                // 색·아이콘 : 메뉴관리(SYS0001_R03)에 지정한 값. 2026-11-16 색이 없으면 검정, 아이콘이 없으면 이름만 (화면명 자동 지정 없앰)
                string colorHex = "";
                string iconHex = "";
                if (tileInfo.ContainsKey(prgcd))
                {
                    colorHex = tileInfo[prgcd][0];
                    iconHex = tileInfo[prgcd][1];
                }

                StackPanel box = new StackPanel();

                // 이름 글자 크기·줄바꿈과 아이콘 크기 : 최소 글자 크기를 지키고, 넘치면 띄어쓰기에서 줄바꿈 (2026-11-16)
                string glyph = ToGlyph(iconHex);
                bool hasIcon = TileShapes.ContainsKey(iconHex) || glyph != "";
                double innerW = (isHalf[i] ? colWidthNow / 2 : colWidthNow) - 6 - 8;
                double fontSize, iconSize;
                string nameText = FitTileName(prgnm, innerW, innerH, hasIcon, out fontSize, out iconSize);

                if (TileShapes.ContainsKey(iconHex))
                {
                    // 글꼴에 없는 아이콘(트럭 등)은 직접 그린 모양으로
                    System.Windows.Shapes.Path shape = new System.Windows.Shapes.Path();
                    shape.Data = GetTileShape(iconHex);
                    shape.Fill = Brushes.White;
                    shape.Stretch = Stretch.Uniform;
                    shape.Width = iconSize * 30 / 23;
                    shape.Height = iconSize;
                    shape.HorizontalAlignment = HorizontalAlignment.Center;
                    shape.Margin = new Thickness(0, 0, 0, 3);
                    box.Children.Add(shape);
                }
                else if (glyph != "")
                {
                    TextBlock icon = new TextBlock();
                    icon.Text = glyph;
                    icon.FontFamily = new FontFamily("Segoe MDL2 Assets");
                    icon.FontSize = iconSize;
                    icon.HorizontalAlignment = HorizontalAlignment.Center;
                    icon.Margin = new Thickness(0, 0, 0, 3);
                    box.Children.Add(icon);
                }

                TextBlock name = new TextBlock();
                name.Text = nameText;
                name.FontSize = fontSize;
                name.FontWeight = FontWeights.Bold;
                name.TextAlignment = TextAlignment.Center;
                name.HorizontalAlignment = HorizontalAlignment.Center;
                box.Children.Add(name);

                // 그래도 넘치면(띄어쓰기 없는 아주 긴 이름 등) 아이콘·글자를 함께 줄여 타일 안에 다 보이게 한다 (키우지는 않음)
                Viewbox fit = new Viewbox();
                fit.Stretch = Stretch.Uniform;
                fit.StretchDirection = StretchDirection.DownOnly;
                fit.Margin = new Thickness(4, 2, 4, 2);
                fit.Child = box;

                UserControl tile = new UserControl();
                tile.Tag = prgcd;
                tile.Content = fit;
                tile.Background = colorHex == "" ? Brushes.Black : ToBrush(colorHex);
                tile.Foreground = Brushes.White;
                tile.Margin = new Thickness(3);
                tile.HorizontalContentAlignment = HorizontalAlignment.Center;
                tile.VerticalContentAlignment = VerticalAlignment.Center;
                tile.MouseEnter += (s, e) => { (s as UIElement).Opacity = 0.85; };
                tile.MouseLeave += (s, e) => { (s as UIElement).Opacity = 1; };
                // 2026-11-16 이 타일에서 눌렀다 뗀 경우만 연다. 로그인 버튼을 뗄 때 그 자리 타일이 열리던 문제 방지
                tile.PreviewMouseLeftButtonDown += (s, e) => { _pressedTile = s as UserControl; };
                tile.MouseUp += (s, e) =>
                {
                    bool pressedHere = (_pressedTile == s);
                    _pressedTile = null;
                    if (pressedHere) MENU_MouseUp(s, e);
                };
                System.Windows.Controls.Grid.SetRow(tile, cellRow[cellNo[i]]);
                System.Windows.Controls.Grid.SetColumn(tile, cellCol[cellNo[i]] * 3 + (isRight[i] ? 1 : 0));
                System.Windows.Controls.Grid.SetColumnSpan(tile, isHalf[i] ? 1 : 2);
                GRID_TILE.Children.Add(tile);
                _menus.Add(tile);

                DockPanel page = new DockPanel();
                DockPanel.SetDock(page, Dock.Top);
                page.MaxHeight = 0;
                page.Children.Add(new Frame());
                DOCK_FRAME.Children.Add(page);
                _pages.Add(page);
            }
        }

        // 타일 이름 글자 크기 : 기본 11, 최소 8.5 (사진의 '외주간 재고이동' 크기). 아이콘 기본 23, 최소 12
        private const double TileFontMax = 11;
        private const double TileFontMin = 8.5;
        private const double TileIconMax = 23;
        private const double TileIconMin = 12;

        // 타일 이름을 타일 안쪽(maxW x maxH)에 맞춘다 → 줄바꿈한 이름을 돌려주고, 글자·아이콘 크기를 정한다
        //   1) 한 줄로 : 큰 글자부터 0.5 씩 줄여 가며 최소 크기까지 들어가는지 본다
        //   2) 그래도 안 되면 줄바꿈 : 띄어쓰기 자리에서만 줄을 바꿔(글자 중간은 안 끊음) 다시 큰 글자부터 맞춰 본다
        //   최소 크기로도 안 들어가면 최소 크기로 두고, 남는 부분은 타일의 Viewbox 가 줄여서 맞춘다
        private string FitTileName(string text, double maxW, double maxH, bool hasIcon, out double fontSize, out double iconSize)
        {
            double iconNeed = hasIcon ? TileIconMin + 3 : 0;   // 아이콘 최소 크기 + 아래 여백
            for (int pass = 1; pass <= 2; pass++)
            {
                for (double f = TileFontMax; f >= TileFontMin; f -= 0.5)
                {
                    string candidate = pass == 1 ? text : WrapTileName(text, maxW, f);
                    Size s = MeasureTileName(candidate, f);
                    if (s.Width <= maxW && s.Height + iconNeed <= maxH)
                    {
                        fontSize = f;
                        iconSize = hasIcon ? Math.Min(TileIconMax, maxH - s.Height - 3) : 0;
                        return candidate;
                    }
                }
            }
            fontSize = TileFontMin;
            iconSize = hasIcon ? TileIconMin : 0;
            return WrapTileName(text, maxW, TileFontMin);
        }

        // 띄어쓰기 단위로 한 줄에 들어가는 만큼 채우고 다음 줄로 (단어 하나가 폭보다 길면 그 단어는 한 줄에 그대로)
        private string WrapTileName(string text, double maxW, double fontSize)
        {
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0) return text;

            List<string> lines = new List<string>();
            string line = words[0];
            for (int w = 1; w < words.Length; w++)
            {
                string candidate = line + " " + words[w];
                if (MeasureTileName(candidate, fontSize).Width <= maxW)
                {
                    line = candidate;
                }
                else
                {
                    lines.Add(line);
                    line = words[w];
                }
            }
            lines.Add(line);
            return string.Join("\n", lines.ToArray());
        }

        // 타일 이름(굵게, 창 글꼴)의 그려질 크기
        private Size MeasureTileName(string text, double fontSize)
        {
            FormattedText ft = new FormattedText(text, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight,
                new Typeface(this.FontFamily, FontStyles.Normal, FontWeights.Bold, FontStretches.Normal), fontSize, Brushes.White);
            ft.TextAlignment = TextAlignment.Center;
            return new Size(ft.WidthIncludingTrailingWhitespace, ft.Height);
        }

        // 메뉴별 타일 색·아이콘 : 메뉴관리(SYS0001_R03)에서 지정한 SYSPRG.TILECOLOR/TILEICON → 공통코드(TMLCOLOR/TMLICON) REF01
        //   → 화면코드마다 하나라서 모든 단말기에 같게 나온다
        // 반칸·열바꿈 : 단말기별 프로그램 정보(PRD7001_R03)에서 지정한 MSTTMLPRG.TILEHALFYN/TILEBREAKYN → 단말기마다 다르다
        // 반환 : PRGCD → { 색(#RRGGBB), 아이콘(Segoe MDL2 Assets 글자코드 16진수), 반칸(Y/N), 열바꿈(Y/N) }. 컬럼이 아직 없거나 오류면 빈 목록(전부 검정·아이콘 없음·한 칸·열바꿈 없음)
        private Dictionary<string, string[]> GetTileInfo()
        {
            Dictionary<string, string[]> info = new Dictionary<string, string[]>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT TP.PRGCD, IFNULL(CC.REF01, '') AS COLORHEX, IFNULL(CI.REF01, '') AS ICONHEX, IFNULL(TP.TILEHALFYN, 'N') AS TILEHALFYN, IFNULL(TP.TILEBREAKYN, 'N') AS TILEBREAKYN");
                sb.AppendLine("FROM MSTTMLPRG AS TP");
                sb.AppendLine("INNER JOIN SYSPRG AS P ON P.PRGCD = TP.PRGCD");
                sb.AppendLine("LEFT JOIN COMTYPE AS CC ON CC.GPCD = 'TMLCOLOR' AND CC.TPCD = P.TILECOLOR");
                sb.AppendLine("LEFT JOIN COMTYPE AS CI ON CI.GPCD = 'TMLICON'  AND CI.TPCD = P.TILEICON");
                sb.AppendLine("WHERE TP.TMLCD = '" + MODEL_CONFIG.GetText("TMLCD").Replace("'", "''") + "'");
                DataSet ds = ItsMaria.Query(sb.ToString());
                if (ItsMaria.IsError || ds.Tables.Count == 0) return info;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    info[row["PRGCD"].ToString()] = new string[] { row["COLORHEX"].ToString().Trim(), row["ICONHEX"].ToString().Trim(), row["TILEHALFYN"].ToString().Trim(), row["TILEBREAKYN"].ToString().Trim() };
                }
            }
            catch { }
            return info;
        }

        private Brush ToBrush(string hex)
        {
            try
            {
                if (!hex.StartsWith("#")) hex = "#" + hex;
                Brush brush = new BrushConverter().ConvertFrom(hex) as Brush;
                brush.Freeze();
                return brush;
            }
            catch
            {
                return Brushes.Black;   // 색 값이 잘못되면 색 없음과 같게 검정
            }
        }

        // 글꼴에 없는 아이콘 : 공통코드 TMLICON 의 REF01 이 이 이름이면 직접 그린다 (웹 SYS0001_R03.js 의 TILE_SHAPES 와 같은 모양)
        // { 면(F0 짝홀 규칙, 겹친 곳은 구멍), 선(둥근 끝, 없으면 ""), 선 굵기, 회전 "각도,중심x,중심y" (없으면 "") }
        private static readonly Dictionary<string, string[]> TileShapes = new Dictionary<string, string[]>
        {
            // 트럭에 상자가 쌓인 모양 (짐칸 상자 5개 + 운전석 + 바퀴 2개)
            { "TRUCK", new string[] {
                "F0 M3,0 h6 v6 h-6 Z M10,0 h6 v6 h-6 Z M0,7 h6 v6 h-6 Z M7,7 h6 v6 h-6 Z M14,7 h6 v6 h-6 Z"
                + " M0,14 h20 v4 h-20 Z M21,7 h6 l4,5 v6 h-10 Z M22.5,8.5 h3.8 l2.7,3.5 h-6.5 Z"
                + " M3.5,21 a3.2,3.2 0 1 0 6.4,0 a3.2,3.2 0 1 0 -6.4,0 Z M5.4,21 a1.3,1.3 0 1 0 2.6,0 a1.3,1.3 0 1 0 -2.6,0 Z"
                + " M21.5,21 a3.2,3.2 0 1 0 6.4,0 a3.2,3.2 0 1 0 -6.4,0 Z M23.4,21 a1.3,1.3 0 1 0 2.6,0 a1.3,1.3 0 1 0 -2.6,0 Z",
                "", "0", "" } },
            // 손수레에 상자 2개 (상자 2개 + 바퀴는 면, 손잡이·기둥·바닥판은 선). 뒤로 14도 기울임
            { "HANDTRUCK", new string[] {
                "F0 M10.2,11 H23.8 A1.2,1.2 0 0 1 25,12.2 V21.5 A1.2,1.2 0 0 1 23.8,22.7 H10.2 A1.2,1.2 0 0 1 9,21.5 V12.2 A1.2,1.2 0 0 1 10.2,11 Z"
                + " M14.2,14 H19.8 A1.2,1.2 0 0 1 21,15.2 A1.2,1.2 0 0 1 19.8,16.4 H14.2 A1.2,1.2 0 0 1 13,15.2 A1.2,1.2 0 0 1 14.2,14 Z"
                + " M11.2,0.5 H22.8 A1.2,1.2 0 0 1 24,1.7 V8.6 A1.2,1.2 0 0 1 22.8,9.8 H11.2 A1.2,1.2 0 0 1 10,8.6 V1.7 A1.2,1.2 0 0 1 11.2,0.5 Z"
                + " M14.2,3.2 H19.8 A1.2,1.2 0 0 1 21,4.4 A1.2,1.2 0 0 1 19.8,5.6 H14.2 A1.2,1.2 0 0 1 13,4.4 A1.2,1.2 0 0 1 14.2,3.2 Z"
                + " M1.6,28.6 A3.4,3.4 0 1 0 8.4,28.6 A3.4,3.4 0 1 0 1.6,28.6 Z M3.7,28.6 A1.3,1.3 0 1 0 6.3,28.6 A1.3,1.3 0 1 0 3.7,28.6 Z",
                "M1,1.4 H4.6 Q6.2,1.4 6.2,3 V22 Q6.2,24.6 8.8,24.6 H27",
                "2.8", "-14,14,16" } },
            // 상자 1개 (입체 : 윗면 + 왼쪽면 + 오른쪽면, 윗면에 U자 테이프 홈)
            { "BOX", new string[] {
                "F0 M16,0 L30,7 L16,14 L2,7 Z M4.8,8.4 L10.68,11.34 L19.68,6.84 L13.8,3.9 Z M6.06,9.03 L9.42,10.71 L17.12,6.86 L13.76,5.18 Z"
                + " M2,8.8 L15.2,15.4 V31 L2,24.4 Z M16.8,15.4 L30,8.8 V24.4 L16.8,31 Z",
                "", "0", "" } },
            // 상자 3개 쌓은 모양 (위 1개 + 아래 2개, 뚜껑·테이프 자국)
            { "BOXES", new string[] {
                "F0 M8,0 h5 v2.5 h4 v-2.5 h5 v4 h-14 Z M8,5 h14 v7 h-14 Z"
                + " M0,14 h5 v2.5 h4 v-2.5 h5 v4 h-14 Z M0,19 h14 v7 h-14 Z"
                + " M16,14 h5 v2.5 h4 v-2.5 h5 v4 h-14 Z M16,19 h14 v7 h-14 Z",
                "", "0", "" } }
        };

        // TileShapes 의 모양 하나를 그림으로 (면 + 선을 합치고 회전)
        private static Geometry GetTileShape(string key)
        {
            string[] s = TileShapes[key];
            Geometry g = Geometry.Parse(s[0]);
            if (s[1] != "")
            {
                Pen pen = new Pen(Brushes.White, double.Parse(s[2], CultureInfo.InvariantCulture));
                pen.StartLineCap = PenLineCap.Round;
                pen.EndLineCap = PenLineCap.Round;
                pen.LineJoin = PenLineJoin.Round;
                g = new CombinedGeometry(GeometryCombineMode.Union, g, Geometry.Parse(s[1]).GetWidenedPathGeometry(pen));
            }
            if (s[3] != "")
            {
                string[] r = s[3].Split(',');
                g = g.Clone();
                g.Transform = new RotateTransform(double.Parse(r[0], CultureInfo.InvariantCulture),
                    double.Parse(r[1], CultureInfo.InvariantCulture), double.Parse(r[2], CultureInfo.InvariantCulture));
            }
            return g;
        }

        // 아이콘 글자코드(16진수) → 글자. 비었거나 잘못되면 "" (아이콘 안 보임)
        private string ToGlyph(string hex)
        {
            if (hex == "" || TileShapes.ContainsKey(hex)) return "";
            try
            {
                return char.ConvertFromUtf32(Convert.ToInt32(hex.Replace("&#x", "").Replace(";", ""), 16));
            }
            catch
            {
                return "";
            }
        }

        // 타일 메뉴 보이기 (열려 있는 화면은 닫지 않고 숨기기만 한다)
        private void ShowHome()
        {
            PANEL_HOME.Visibility = Visibility.Visible;
            LABEL_TITLE.Content = "";
        }

        private void MENU_HOME_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            CONFIG_CLOSE_MouseUp(null, null);
            ShowHome();
        }

        // 타일 메뉴에서 마우스 휠을 굴리면 가로로 스크롤
        private void SCROLL_TILE_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            SCROLL_TILE.ScrollToHorizontalOffset(SCROLL_TILE.HorizontalOffset - e.Delta / 3.0);
            e.Handled = true;
        }

        // 2026-11-16 새로고침 : 열린 화면이 있으면 닫을지 묻고, 없으면 바로 메뉴를 다시 읽는다
        private void MENU_REFRESH_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            CONFIG_CLOSE_MouseUp(null, null);

            bool hasOpenPage = _pages.Any(p => (p.Children[0] as Frame).Tag != null);
            if (hasOpenPage)
            {
                ShowMessageBox("__MenuRefresh", "열린 화면을 모두 닫고 메뉴를 새로고침하시겠습니까?");
            }
            else
            {
                RefreshMenu();
            }
        }

        // 메뉴 목록·타일 설정(색·아이콘·반칸·열바꿈)을 DB 에서 다시 읽어 타일 메뉴를 새로 만든다. 열린 화면은 모두 닫힌다
        private void RefreshMenu()
        {
            WAIT_MSG.Visibility = Visibility.Visible;
            ItsElement.Refresh(this);

            ClearAllFrames();
            HideAllPages();
            PAGE_MAIN.MaxHeight = 5000;
            CURFRAME = null;
            SetMenu(MODEL_CONFIG.GetText("TMLCD"));   // 타일·화면 칸을 새로 만들고 타일 메뉴를 보여준다

            WAIT_MSG.Visibility = Visibility.Hidden;
        }

        // 모든 화면 칸 숨기기 (PAGE_MAIN 제외)
        private void HideAllPages()
        {
            foreach (DockPanel page in _pages) page.MaxHeight = 0;
        }

        // 열린 화면 모두 닫기 (다음에 누르면 새로 불러옴)
        private void ClearAllFrames()
        {
            foreach (DockPanel page in _pages) (page.Children[0] as Frame).Tag = null;
        }

        // 타일에 적힌 화면명
        private string GetMenuName(UserControl menu)
        {
            // 타일 구조 : Viewbox > StackPanel > [아이콘] + 이름(마지막 TextBlock)
            Viewbox fit = menu.Content as Viewbox;
            StackPanel box = (fit != null ? fit.Child : menu.Content) as StackPanel;
            if (box != null && box.Children.Count > 0)
            {
                TextBlock name = box.Children[box.Children.Count - 1] as TextBlock;
                if (name != null) return name.Text;
            }
            return Convert.ToString(menu.Tag);
        }

        // 타일 → 화면 칸 (없으면 false)
        private bool GetMenuPage(UserControl menu, out DockPanel page, out Frame frame)
        {
            page = null;
            frame = null;

            int idx = _menus.IndexOf(menu);
            if (idx < 0) return false;

            page = _pages[idx];
            frame = page.Children[0] as Frame;
            return true;
        }

        private void MENU_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null)
            {
                e.Handled = true;
                if (e.ChangedButton != MouseButton.Left) return;
            }

            UserControl menu = sender as UserControl;
            string menuName = GetMenuName(menu);

            PANEL_HOME.Visibility = Visibility.Collapsed;

            WAIT_MSG.Visibility = Visibility.Visible;
            ItsElement.Refresh(this);

            //timer.Start();

            CONFIG_CLOSE_MouseUp(null, null);
            MSG_CLOSE_MouseUp(null, null);

            PAGE_MAIN.MaxHeight = 0;

            HideAllPages();

            // TextBlock 로 넣어야 화면코드의 밑줄(_)이 Label 단축키 표시로 먹히지 않는다
            LABEL_TITLE.Content = new TextBlock { Text = "[" + (sender as UserControl).Tag.ToString().Substring(0, 11)
            + "] " + menuName };

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPRGVER';");
            DataSet ds = ItsMaria.Query(sb.ToString());
            string prgVer = ItsData.GetText(ds.Tables[0], 0, "REF01");

            if (prgVer != this.PrgVer)
            {
                ShowMessageBox("", "프로그램을 재시작해주세요.\n" + "현재버전: " + this.PrgVer + " -> 최신버전: " + prgVer);
            }

            UserControl CURMENU = sender as UserControl;

            DockPanel curPage;
            if (!GetMenuPage(CURMENU, out curPage, out CURFRAME))
            {
                WAIT_MSG.Visibility = Visibility.Hidden;
                return;
            }
            curPage.MaxHeight = 5000;

            if (CURFRAME.Tag == null)
            {
                string pageName = (sender as UserControl).Tag.ToString();
                if (ItsLocalInfo.IsRunMode)
                {
                    try
                    {
                        webClient.DownloadFile(ItsServerInfo.ServerUrl + pageName.Substring(0, 7) + ".exe", pageName.Substring(0, 7) + ".exe");
                    }
                    catch {

                    }
                }

                try
                {
                    Assembly pageAssembly = Assembly.LoadFrom(pageName.Substring(0, 7) + ".exe");

                    object assObj = pageAssembly.CreateInstance(pageName.Substring(0, 7) + "." + pageName.Substring(8));
                    Page page = assObj as Page;

                    // 2026-11-12 exe 안에 화면 클래스가 없으면 (예전 exe 등) 빈 화면 대신 알림
                    if (page == null)
                    {
                        WAIT_MSG.Visibility = Visibility.Hidden;
                        ShowMessageBox("", menuName + " 화면을 찾을 수 없습니다.");
                        ShowHome();
                        return;
                    }

                    CURFRAME.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                    CURFRAME.Navigate(page);
                    CURFRAME.Tag = (sender as UserControl).Tag;
                }
                catch(Exception ex)
                {
                    WAIT_MSG.Visibility = Visibility.Hidden;
                    ShowMessageBox("", ex.Message);
                    ShowHome();
                    //ShowMessageBox("", (sender as UserControl).Tag.ToString() + " 를 로딩하지 못했습니다.");
                }
            }

            try
            {
                if (CURFRAME.Tag.ToString().Contains("TML"))
                    ItsElement.ActiveTml = CURFRAME.Tag.ToString();
                else
                    ItsElement.ActivePage = (ItsPageBase)(CURFRAME.Content);
            }
            catch (Exception ex)
            { }
            
            WAIT_MSG.Visibility = Visibility.Hidden;
        }

        private void PASS_CHECK_Click(object sender, RoutedEventArgs e)
        {
            CONFIG_PASS_KeyDown(null, null);
        }

        private void CONFIG_PASS_UP(object sender, MouseButtonEventArgs e)
        {
            CONFIG_PASS_KeyDown(null, null);
        }

        private void CONFIG_PASS_KeyDown(object sender, KeyEventArgs e)
        {

            if (PANEL_CONFIG.MaxHeight == 0)
            {
                // ICON_CONFIG_MouseDown(null, null);
                //CONFIG_PASS.Password = "";
                CONFIG_PASS.Value = "";
                return;
            }

            if (e == null || e.Key == Key.Enter)
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPASS';");
                string pass = ItsData.GetScalar(ItsMaria.Query(query.ToString()));

                //if (pass == CONFIG_PASS.Password)
                if (pass == CONFIG_PASS.Value)
                {
                    CONFIG_PASS.CloseKeypad();
                    CONFIG_PASS.MaxHeight = 0;
                    PASS_CHECK.MaxHeight = 0;

                    CONFIG_LINE.MaxHeight = 0;
                    PANEL_OPTION.MaxHeight = 5000;
                    PANEL_PASSWORD.Width = 0;

                    ConfigCommit.Visibility = Visibility.Visible;
                    ConfigClose.Visibility = Visibility.Visible;
                }
                else
                {
                    ShowMessageBox("", "비밀번호를 정확하게 입력하세요.");
                    PASS_CHECK.Focus();
                }
            }
        }

        //private void COMBO_PRINT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    File.WriteAllText(_printFile, COMBO_PRINT.SelectedItem.ToString(), Encoding.UTF8);
        //}

        // 페이지 불러오기
        public void LoadMenu(string pName)
        {
            LoadMenu(pName, null);
        }

        public void LoadMenu(string pName, Dictionary<string, string> param)
        {
            ItsElement.SetMenuParam(param);

            // 화면코드가 같은 타일을 찾는다
            UserControl menu = null;
            foreach (UserControl m in _menus)
            {
                if (pName == Convert.ToString(m.Tag))
                {
                    menu = m;
                    break;
                }
            }
            if (menu == null) return;

            string menuName = GetMenuName(menu);

            PANEL_HOME.Visibility = Visibility.Collapsed;

            WAIT_MSG.Visibility = Visibility.Visible;
            ItsElement.Refresh(this);

            //timer.Start();

            CONFIG_CLOSE_MouseUp(null, null);
            MSG_CLOSE_MouseUp(null, null);

            PAGE_MAIN.MaxHeight = 0;

            HideAllPages();

            LABEL_TITLE.Content = new TextBlock { Text = "[" + menu.Tag.ToString().Substring(0, 11)
                + "] " + menuName };

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPRGVER';");
            DataSet ds = ItsMaria.Query(sb.ToString());
            string prgVer = ItsData.GetText(ds.Tables[0], 0, "REF01");

            if (prgVer != this.PrgVer)
            {
                ShowMessageBox("", "프로그램을 재시작해주세요.\n" + "현재버전: " + this.PrgVer + " -> 최신버전: " + prgVer);
            }

            UserControl CURMENU = menu;

            DockPanel curPage;
            if (!GetMenuPage(CURMENU, out curPage, out CURFRAME))
            {
                WAIT_MSG.Visibility = Visibility.Hidden;
                return;
            }
            curPage.MaxHeight = 5000;

            bool isNewPage = (CURFRAME.Tag == null);

            if (CURFRAME.Tag == null)
            {
                string pageName = menu.Tag.ToString();
                if (ItsLocalInfo.IsRunMode)
                {
                    try
                    {
                        webClient.DownloadFile(ItsServerInfo.ServerUrl + pageName.Substring(0, 7) + ".exe", pageName.Substring(0, 7) + ".exe");
                    }
                    catch
                    {

                    }
                }

                try
                {
                    Assembly pageAssembly = Assembly.LoadFrom(pageName.Substring(0, 7) + ".exe");

                    object assObj = pageAssembly.CreateInstance(pageName.Substring(0, 7) + "." + pageName.Substring(8));
                    Page page = assObj as Page;

                    // 2026-11-12 exe 안에 화면 클래스가 없으면 (예전 exe 등) 빈 화면 대신 알림
                    if (page == null)
                    {
                        WAIT_MSG.Visibility = Visibility.Hidden;
                        ShowMessageBox("", menuName + " 화면을 찾을 수 없습니다.");
                        ShowHome();
                        return;
                    }

                    CURFRAME.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                    CURFRAME.Navigate(page);
                    CURFRAME.Tag = menu.Tag;
                }
                catch (Exception ex)
                {
                    WAIT_MSG.Visibility = Visibility.Hidden;
                    ShowMessageBox("", ex.Message);
                    ShowHome();
                    //ShowMessageBox("", (sender as UserControl).Tag.ToString() + " 를 로딩하지 못했습니다.");
                }
            }

            try
            {
                if (CURFRAME.Tag.ToString().Contains("TML"))
                    ItsElement.ActiveTml = CURFRAME.Tag.ToString();
                else
                    ItsElement.ActivePage = (ItsPageBase)(CURFRAME.Content);
            }
            catch (Exception ex)
            { }

            // 이미 열린 화면은 Loaded 가 다시 안 불리므로 여기서 파라미터를 전달한다.
            // 신규 화면은 ItsPageTml Loaded → EventMenuParam 에서 수신한다.
            if (!isNewPage && param != null && param.Count > 0)
            {
                ItsPageBase pageBase = CURFRAME.Content as ItsPageBase;
                if (pageBase != null)
                {
                    pageBase.EventMenuParam(param);
                    ItsElement.ClearMenuParam();
                }
            }

            WAIT_MSG.Visibility = Visibility.Hidden;
        }
    }
}
