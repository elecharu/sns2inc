using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ITSIF_INTERFACE
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 시작프로그램 등으로 실행돼도 LOG, MariaConfig.txt 를 실행파일 위치에서 찾도록 고정
            Environment.CurrentDirectory = Application.StartupPath;

            // 저장해 둔 설정(IfConfig.txt) 읽기
            IfConfig.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 중복 실행 확인
            bool createdNew;
            using (Mutex mutex = new Mutex(true, "ITSIF_INTERFACE_SINGLE", out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("프로그램이 이미 실행중입니다.\n\n트레이 아이콘을 확인하세요.", "IF_MONITOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Application.Run(new MainForm());
            }
        }
    }
}
