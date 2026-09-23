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
using System.Windows.Threading;

namespace TMLSTART
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {

        private string serverUrl = "http://mes.optisco.com:8024/TML/";
        //private string serverUrl = "http://183.106.107.163:8001/TML/";
        private string localPath = "\\MES_SNS_FAC2_TML\\";
        public bool end_flag = false;

        public StartWindow()
        {
            InitializeComponent();

            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = "/c ipconfig /flushdns";
                proc.Start();
            }
            catch { }

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            localPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + localPath;
            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            System.IO.Directory.SetCurrentDirectory(localPath);
            Environment.CurrentDirectory = localPath;
            System.IO.File.WriteAllText(localPath + "ServerUrl.config", serverUrl, Encoding.UTF8);
            //try
            //{
            //    serverUrl = System.IO.File.ReadAllText("ITS_DOWN_URL.xml", Encoding.UTF8);
            //}
            //catch
            //{
            //    MSG_01.Text = "ERROR: Not found url file";
            //    MSG_02.Text = "ITS_DOWN_URL.xml";
            //    return;
            //}

            FullScreenManager.RepairWpfWindowFullScreenBehavior(this);
            this.Loaded += MainWindow_Loaded;
            this.Activated += StartWindow_Activated;
        }

        public static bool IsConnectedToInternet()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        private void StartWindow_Activated(object sender, EventArgs e)
        {
            if (!IsConnectedToInternet())
            {
                MessageBox.Show("네트워크 연결을 확인하세요.");
                this.Close();
                return;
            }

            DoEvents();

            System.Net.WebClient webclient = new System.Net.WebClient();
            Dictionary<string, string> downList = new Dictionary<string, string>();

            downList.Add("ITS_CONFIG_MARIA.xml", "ITS_CONFIG_MARIA.xml");
            downList.Add("ITSLOGIN.exe", "ITSLOGIN.exe");
            downList.Add("ITSLIB.exe", "ITSLIB.exe");
            downList.Add("TMLMAIN.exe", "TMLMAIN.exe");

            string[] dllList = webclient.DownloadString(serverUrl + "DllList.aspx").Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string dllName in dllList)
            {
                downList.Add(dllName, dllName);
            }

            foreach (string key in downList.Keys)
            {
                if (end_flag)
                {
                    Environment.Exit(0);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    this.Close();
                }
                MSG1.Text = MSG2.Text;
                MSG2.Text = MSG3.Text;
                MSG3.Text = "Download " + key + " Start";

                if (key.Substring(0, 3).ToUpper() == "ITS" || key.Substring(0, 3).ToUpper() == "TML")
                {
                    try
                    {
                        webclient.DownloadFile(serverUrl + downList[key], localPath + key);
                    }
                    catch
                    {
                        if (key == "ITSLOGIN.exe")
                        {
                            end_flag = true;
                            MessageBox.Show("이미 실행 중 입니다.");
                        }

                        if (MSG_01.Text.Substring(0, 5) != "ERROR")
                        {
                            MSG_01.Text = "ERROR: " + key;
                            MSG_02.Text = "";
                        }
                        else
                        {
                            MSG_02.Text = "ERROR: " + key;
                        }
                    }
                }
                else if (!System.IO.File.Exists(localPath + key))
                {
                    try
                    {
                        webclient.DownloadFile(serverUrl + downList[key], localPath + key);
                    }
                    catch
                    {
                        if (MSG_01.Text.Substring(0, 5) != "ERROR")
                        {
                            MSG_01.Text = "ERROR: " + key;
                            MSG_02.Text = "";
                        }
                        else
                        {
                            MSG_02.Text = "ERROR: " + key;
                        }
                    }
                }

                MSG1.Text = MSG2.Text;
                MSG2.Text = MSG3.Text;
                MSG3.Text = "Download " + key + " End";

                DoEvents();
            }

            if (MSG_01.Text.Substring(0, 5) != "ERROR")
            {
                System.Diagnostics.Process Proc = new System.Diagnostics.Process();

                // 협력사 LOGIN 시
                //Proc.StartInfo.FileName = localPath + "ITSLOGIN.exe";

                // 사내 LOGIN 시 (사내는 LOGIN 이 없어서 TMLMAIN.EXE 가 바로 실행됨)
                Proc.StartInfo.FileName = localPath + "TMLMAIN.exe";

                Proc.Start();

                this.Close();
            }
        }

        private void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
             new Action<object>((arg) =>
             {
                 DispatcherFrame newFrame = arg as DispatcherFrame;
                 newFrame.Continue = false;
             }), frame);
            Dispatcher.PushFrame(frame);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = 450;
            this.Height = 300;
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
    }
}
