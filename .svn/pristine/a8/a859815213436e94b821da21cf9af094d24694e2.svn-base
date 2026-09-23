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
using System.Windows.Media.Animation;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;

namespace ITSLOGIN
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        ItsModelPanel MODEL_A1 = new ItsModelPanel();

        public LoginWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Topmost = true;
            FullScreenManager.RepairWpfWindowFullScreenBehavior(this);
            this.Activated += LoginWindow_Activated;

            this.Loaded += LoginWindow_Loaded;
        }

        public static bool IsConnectedToInternet()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsConnectedToInternet())
            {
                ItsMsgBox.ShowErr("네트워크 연결을 확인하시기 바랍니다.");
                this.Close();
                return;
            }

            // TMLMAIN 다운로드 ( ITSSTART 로 옴겨지면 지워야 함. )
            //string localPath = System.IO.Directory.GetCurrentDirectory() + "\\TMLMAIN.exe";
            //if (!System.IO.File.Exists(localPath))
            //{
            //    string serverPath = ItsServerInfo.ServerUrl + "TMLMAIN.exe";
            //    try
            //    {
            //        System.Net.WebClient webclient = new System.Net.WebClient();
            //        webclient.DownloadFile(serverPath, localPath);
            //    }
            //    catch { }
            //}

            LOGINID.Focus();

            try
            {
                string saveUserID = ItsSecurity.DecDES(System.IO.File.ReadAllText("ConfigSaveUserID.config", Encoding.UTF8));
                if (saveUserID.Length > 0)
                {
                    SAVE_ID.IsChecked = true;
                    LOGINID.Text = saveUserID;
                    LOGINPASS.Focus();
                }
            }
            catch { }

            //try
            //{
            //    string saveUserPass = ItsSecurity.DecDES(System.IO.File.ReadAllText("ConfigSaveUserPass.config", Encoding.UTF8));
            //    if (saveUserPass.Length > 0)
            //    {
            //        SAVE_PASS.IsChecked = true;
            //        LOGINPASS.Password = saveUserPass;
            //        LOGINPASS.Focus();
            //    }
            //}
            //catch { }
        }

        private void LoginWindow_Activated(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 350;
            this.MaxHeight = this.Height;
            this.MaxWidth = this.Width;
        }

        private void TITLE_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void ICON_CLOSE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ICON_MIN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private string Get_MyIP()
        {
            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }

        private string Get_MacAddress()
        {
            return NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
        }

        private void LOGIN_BUTTON_MouseDown(object sender, MouseEventArgs e)
        {
            ItsMaria.Set("ITSLOGIN", "LOGIN");
            ItsMaria.AddOne("LOGIN_USER", LOGINID.Text);
            //ItsMaria.AddOne("LOGIN_PASS", ItsSecurity.EncMD5(LOGINPASS.Password));
            ItsMaria.AddOne("LOGIN_PASS", LOGINPASS.Password);
            ItsMaria.AddOne("USERIP", Get_MyIP());
            ItsMaria.AddOne("MACADDR", Get_MacAddress());
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ItsMsgBox.Show(ItsMaria.ErrMessage);
                LOGINPASS.SecurePassword.Clear();
                LOGINPASS.Focus();
                return;
            }
            else
            {
                if (SAVE_ID.IsChecked == true)
                {
                    System.IO.File.WriteAllText("ConfigSaveUserID.config", ItsSecurity.EncDES(LOGINID.Text), Encoding.UTF8);
                    //if (SAVE_PASS.IsChecked == true)
                    //{
                    //    System.IO.File.WriteAllText("ConfigSaveUserPass.config", ItsSecurity.EncDES(LOGINPASS.Password), Encoding.UTF8);
                    //}
                    //else
                    //{
                    //    System.IO.File.WriteAllText("ConfigSaveUserPass.config", "", Encoding.UTF8);
                    //}
                }
                else
                {
                    System.IO.File.WriteAllText("ConfigSaveUserID.config", "", Encoding.UTF8);
                }
            }
            ItsMemberShip.SetUserInfo(LOGINID.Text, LOGINPASS.Password);
            //ItsMemberShip.SetUserInfo(LOGINID.Text, "");
            ItsMemberShip.LoginKey = ItsData.GetText(ds.Tables[0], 0, "LOGINKEY");
            ItsMemberShip.LoginTime = ItsData.GetText(ds.Tables[0], 0, "LOGINTIME");

            this.Visibility = Visibility.Hidden;
            //ITSLIB.MainWindow MAINWINDOW = new ITSLIB.MainWindow();
            TMLMAIN.MainWindow MAINWINDOW = new TMLMAIN.MainWindow();
            MAINWINDOW.ShowDialog();         

            this.Close();
        }

        private void LOGIN_BUTTON_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard story = (Storyboard)Resources["ButtonEnterStory"];
            story.Begin(this);
        }

        private void LOGIN_BUTTON_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard story = (Storyboard)Resources["ButtonLeaveStory"];
            story.Begin(this);
        }

        private void LOGINPASS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LOGIN_BUTTON_MouseDown(null, null);
            }
        }
    }
}
