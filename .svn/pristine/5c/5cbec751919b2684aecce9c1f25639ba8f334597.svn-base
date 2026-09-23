using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using System.Text;

namespace ITSTML
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static string _RunErrMsg = "";

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("RunError：" + Environment.NewLine);
            sb.AppendLine(e.Exception.Message);

            _RunErrMsg = e.Exception.ToString();

            ItsElement.TML_MAIN_WINDOW.WAIT_MSG.Visibility = Visibility.Hidden;
            ItsElement.TML_MAIN_WINDOW.ShowMessageBox("", sb.ToString());

            e.Handled = true;
        }
    }
}
