using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;


namespace MailFileTrigger
{
    class Program
    {
        static string EqpDirPath = @"D:\ITSCO\Hmail\hMailServer\Data\yeungjin.co.kr";
        //static string EqpDirPath = @"C:\Users\itsco\Desktop\test";
        static string TriggerPath = @"D:\ITSCO\MailService_HOST\MailServiceTrigger.exe";

        static void Main(string[] args)
        {
            do
            {
                Run_Watcher();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static private void Run_Watcher()
        {
            var m_FolderWatcher = new FileSystemWatcher();

            m_FolderWatcher.Filter = "*.eml";
            m_FolderWatcher.Path = EqpDirPath;
            m_FolderWatcher.IncludeSubdirectories = true;

            m_FolderWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            //m_FolderWatcher.Changed += new FileSystemEventHandler(Watcher_OnChanged);
            m_FolderWatcher.Created += new FileSystemEventHandler(Watcher_OnChanged);
            //m_FolderWatcher.Deleted += new FileSystemEventHandler(Watcher_OnChanged);
            //m_FolderWatcher.Renamed += new RenamedEventHandler(Watcher_OnRenamed);
            m_FolderWatcher.EnableRaisingEvents = true;
        }



        static private void Watcher_OnChanged(object sender, FileSystemEventArgs e)
        {
            var id = e.Name.Split('\\')[0];
            Console.WriteLine(string.Format("{0} {1} {2}", e.FullPath, e.ChangeType.ToString(), id));
            Process p = new Process();

            p.StartInfo.FileName = TriggerPath;
            p.StartInfo.Arguments = id + " yeungjin.co.kr";
            //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();
        }



        static private void Watcher_OnRenamed(object sender, RenamedEventArgs e)
        {
            var id = e.Name.Split('\\')[0];
            Console.WriteLine(string.Format("{0} {1} to {2} {3}", e.OldFullPath, e.ChangeType.ToString(), e.Name, id));
        }
    }
}
