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
                MENU10.Visibility = Visibility.Hidden;
 
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
                FRAME10.Tag = null;

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
                    for (int i = 0; i < 10; i++)
                    {
                        MENU = PANEL_MENU.FindName("MENU" + i) as UserControl;
                        MENU.Visibility = Visibility.Visible;
                        MENU.Tag = ds.Tables[0].Rows[i][0].ToString();
                        MENU.Content = ds.Tables[0].Rows[i][1].ToString();
                    }

                    MENU10.Visibility = Visibility.Visible;
                    MENU10.Tag = "OTHER";
                    MENU10.Content = "기타메뉴";

                    for (int i = 10; i < menuCount; i++)
                    {
                        MENU = PANEL_MENU.FindName("OTHER_MENU" + (i - 10)) as UserControl;
                        MENU.Visibility = Visibility.Visible;
                        MENU.Tag = ds.Tables[0].Rows[i][0].ToString();
                        MENU.Content = ds.Tables[0].Rows[i][1].ToString();
                    }
                }
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

            if (PAGE_MAIN.MaxHeight > 0)
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
            DOCK_FRAME.Visibility = Visibility.Hidden;

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

            DOCK_FRAME.Visibility = Visibility.Visible;

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
            PAGE10.MaxHeight = 0;

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

            DOCK_FRAME.Visibility = Visibility.Visible;

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
                MsgCommit.Margin = new Thickness(180, 9, 0, 9);
                MsgCommit.Visibility = Visibility.Visible;
                MsgClose.Visibility = Visibility.Hidden;
                MsgClose.Width = 0;
                TEXT_MSG_IMG.Source = new BitmapImage(new Uri("pack://application:,,,/TMLMAIN;component/popup_bg_warning.png"));
            }
            else if (msgType == "ERR" || command == "")
            {
                Color clr = Color.FromRgb(243, 86, 90);
                MsgCommit.Background = new SolidColorBrush(clr);
                MsgCommit.Margin = new Thickness(180, 9, 0, 9);
                MsgCommit.Visibility = Visibility.Visible;
                MsgClose.Visibility = Visibility.Hidden;
                MsgClose.Width = 0;
                TEXT_MSG_IMG.Source = new BitmapImage(new Uri("pack://application:,,,/TMLMAIN;component/popup_bg_error.png"));
            }
            else
            {
                Color clr = Color.FromRgb(70, 140, 198);
                MsgCommit.Background = new SolidColorBrush(clr);
                MsgCommit.Margin = new Thickness(130, 9, 50, 9);
                MsgCommit.Visibility = Visibility.Visible;
                MsgClose.Visibility = Visibility.Visible;
                MsgClose.Width = 50;
                TEXT_MSG_IMG.Source = new BitmapImage(new Uri("pack://application:,,,/TMLMAIN;component/popup_bg_choice.png"));
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
                FRAME10.Tag = null;

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
                PAGE10.MaxHeight = 0;

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

            //timer.Start();

            CONFIG_CLOSE_MouseUp(null, null);
            MSG_CLOSE_MouseUp(null, null);

            PAGE_MAIN.MaxHeight = 0;

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
            PAGE10.MaxHeight = 0;

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

            LABEL_TITLE.Content = "[" + (sender as UserControl).Tag.ToString().Substring(0, 11)
            + "] " + (sender as UserControl).Content.ToString();
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#262938");
            brush.Freeze();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPRGVER';");
            DataSet ds = ItsMaria.Query(sb.ToString());
            string prgVer = ItsData.GetText(ds.Tables[0], 0, "REF01");

            if (prgVer != this.PrgVer)
            {
                ShowMessageBox("", "프로그램을 재시작해주세요.\n" + "현재버전: " + this.PrgVer + " -> 최신버전: " + prgVer);
            }

            MENU0.Background = brush; MENU0.Foreground = Brushes.White;
            MENU1.Background = brush; MENU1.Foreground = Brushes.White;
            MENU2.Background = brush; MENU2.Foreground = Brushes.White;
            MENU3.Background = brush; MENU3.Foreground = Brushes.White;
            MENU4.Background = brush; MENU4.Foreground = Brushes.White;
            MENU5.Background = brush; MENU5.Foreground = Brushes.White;
            MENU6.Background = brush; MENU6.Foreground = Brushes.White;
            MENU7.Background = brush; MENU7.Foreground = Brushes.White;
            MENU8.Background = brush; MENU8.Foreground = Brushes.White;
            MENU9.Background = brush; MENU9.Foreground = Brushes.White;
            MENU10.Background = brush; MENU10.Foreground = Brushes.White;
            MENU0.BorderThickness = new Thickness(0);
            MENU1.BorderThickness = new Thickness(0);
            MENU2.BorderThickness = new Thickness(0);
            MENU3.BorderThickness = new Thickness(0);
            MENU4.BorderThickness = new Thickness(0);
            MENU5.BorderThickness = new Thickness(0);
            MENU6.BorderThickness = new Thickness(0);
            MENU7.BorderThickness = new Thickness(0);
            MENU8.BorderThickness = new Thickness(0);
            MENU9.BorderThickness = new Thickness(0);
            MENU10.BorderThickness = new Thickness(0);

            OTHER_MENU0.Background = brush; OTHER_MENU0.Foreground = Brushes.White;
            OTHER_MENU1.Background = brush; OTHER_MENU1.Foreground = Brushes.White;
            OTHER_MENU2.Background = brush; OTHER_MENU2.Foreground = Brushes.White;
            OTHER_MENU3.Background = brush; OTHER_MENU3.Foreground = Brushes.White;
            OTHER_MENU4.Background = brush; OTHER_MENU4.Foreground = Brushes.White;
            OTHER_MENU5.Background = brush; OTHER_MENU5.Foreground = Brushes.White;
            OTHER_MENU6.Background = brush; OTHER_MENU6.Foreground = Brushes.White;
            OTHER_MENU7.Background = brush; OTHER_MENU7.Foreground = Brushes.White;
            OTHER_MENU8.Background = brush; OTHER_MENU8.Foreground = Brushes.White;
            OTHER_MENU9.Background = brush; OTHER_MENU9.Foreground = Brushes.White;

            UserControl CURMENU = sender as UserControl;
            CURMENU.Background = brush;
            CURMENU.Foreground = new BrushConverter().ConvertFrom("#70A6F3") as SolidColorBrush;
            CURMENU.BorderThickness = new Thickness(0,0,0,2);
            CURMENU.BorderBrush = new BrushConverter().ConvertFrom("#70A6F3") as SolidColorBrush;

            if (CURMENU == MENU10 && MENU10.Tag.ToString() == "OTHER")
            {
                POP_OTHER_MENU.IsOpen = true;

                WAIT_MSG.Visibility = Visibility.Visible;
                return;
            }

            //string menuNo = CURMENU.Name.Replace("MENU", "");
            string menuNo = CURMENU.Name.Substring(4, 1);
            if (menuNo != "R") // 예: OTHER_FRAME5 
            {
                CURFRAME = this.FindName("FRAME" + menuNo) as Frame;
                (this.FindName("PAGE" + menuNo) as DockPanel).MaxHeight = 5000;
            }
            else
            {
                menuNo = CURMENU.Name.Substring(10, 1);
                CURFRAME = this.FindName("OTHER_FRAME" + menuNo) as Frame;
                (this.FindName("OTHER_PAGE" + menuNo) as DockPanel).MaxHeight = 5000;
            }

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

                    CURFRAME.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                    CURFRAME.Navigate(page);
                    CURFRAME.Tag = (sender as UserControl).Tag;
                }
                catch(Exception ex)
                {
                    WAIT_MSG.Visibility = Visibility.Hidden;
                    ShowMessageBox("", ex.Message);
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

            UserControl menu = null;

            int j = 0;
            while (true)
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

            //timer.Start();

            CONFIG_CLOSE_MouseUp(null, null);
            MSG_CLOSE_MouseUp(null, null);

            PAGE_MAIN.MaxHeight = 0;

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
            PAGE10.MaxHeight = 0;

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

            LABEL_TITLE.Content = "[" + menu.Tag.ToString().Substring(0, 11)
                + "] " + menu.Content.ToString();
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#262938");
            brush.Freeze();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT REF01 FROM COMTYPE WHERE GPCD = 'GLOBAL' AND TPCD = 'TMLPRGVER';");
            DataSet ds = ItsMaria.Query(sb.ToString());
            string prgVer = ItsData.GetText(ds.Tables[0], 0, "REF01");

            if (prgVer != this.PrgVer)
            {
                ShowMessageBox("", "프로그램을 재시작해주세요.\n" + "현재버전: " + this.PrgVer + " -> 최신버전: " + prgVer);
            }

            MENU0.Background = brush; MENU0.Foreground = Brushes.White;
            MENU1.Background = brush; MENU1.Foreground = Brushes.White;
            MENU2.Background = brush; MENU2.Foreground = Brushes.White;
            MENU3.Background = brush; MENU3.Foreground = Brushes.White;
            MENU4.Background = brush; MENU4.Foreground = Brushes.White;
            MENU5.Background = brush; MENU5.Foreground = Brushes.White;
            MENU6.Background = brush; MENU6.Foreground = Brushes.White;
            MENU7.Background = brush; MENU7.Foreground = Brushes.White;
            MENU8.Background = brush; MENU8.Foreground = Brushes.White;
            MENU9.Background = brush; MENU9.Foreground = Brushes.White;
            MENU10.Background = brush; MENU10.Foreground = Brushes.White;
            MENU0.BorderThickness = new Thickness(0);
            MENU1.BorderThickness = new Thickness(0);
            MENU2.BorderThickness = new Thickness(0);
            MENU3.BorderThickness = new Thickness(0);
            MENU4.BorderThickness = new Thickness(0);
            MENU5.BorderThickness = new Thickness(0);
            MENU6.BorderThickness = new Thickness(0);
            MENU7.BorderThickness = new Thickness(0);
            MENU8.BorderThickness = new Thickness(0);
            MENU9.BorderThickness = new Thickness(0);
            MENU10.BorderThickness = new Thickness(0);

            OTHER_MENU0.Background = brush; OTHER_MENU0.Foreground = Brushes.White;
            OTHER_MENU1.Background = brush; OTHER_MENU1.Foreground = Brushes.White;
            OTHER_MENU2.Background = brush; OTHER_MENU2.Foreground = Brushes.White;
            OTHER_MENU3.Background = brush; OTHER_MENU3.Foreground = Brushes.White;
            OTHER_MENU4.Background = brush; OTHER_MENU4.Foreground = Brushes.White;
            OTHER_MENU5.Background = brush; OTHER_MENU5.Foreground = Brushes.White;
            OTHER_MENU6.Background = brush; OTHER_MENU6.Foreground = Brushes.White;
            OTHER_MENU7.Background = brush; OTHER_MENU7.Foreground = Brushes.White;
            OTHER_MENU8.Background = brush; OTHER_MENU8.Foreground = Brushes.White;
            OTHER_MENU9.Background = brush; OTHER_MENU9.Foreground = Brushes.White;

            UserControl CURMENU = menu;
            CURMENU.Background = brush;
            CURMENU.Foreground = new BrushConverter().ConvertFrom("#70A6F3") as SolidColorBrush;
            CURMENU.BorderThickness = new Thickness(0, 0, 0, 2);
            CURMENU.BorderBrush = new BrushConverter().ConvertFrom("#70A6F3") as SolidColorBrush;

            if (CURMENU == MENU10 && MENU10.Tag.ToString() == "OTHER")
            {
                POP_OTHER_MENU.IsOpen = true;

                WAIT_MSG.Visibility = Visibility.Visible;
                return;
            }

            string menuNo = CURMENU.Name.Replace("MENU", "");
            if (menuNo != "R") // 예: OTHER_FRAME5 
            {
                CURFRAME = this.FindName("FRAME" + menuNo) as Frame;
                (this.FindName("PAGE" + menuNo) as DockPanel).MaxHeight = 5000;
            }
            else
            {
                menuNo = CURMENU.Name.Substring(10, 1);
                CURFRAME = this.FindName("OTHER_FRAME" + menuNo) as Frame;
                (this.FindName("OTHER_PAGE" + menuNo) as DockPanel).MaxHeight = 5000;
            }

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

                    CURFRAME.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                    CURFRAME.Navigate(page);
                    CURFRAME.Tag = menu.Tag;
                }
                catch (Exception ex)
                {
                    WAIT_MSG.Visibility = Visibility.Hidden;
                    ShowMessageBox("", ex.Message);
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
