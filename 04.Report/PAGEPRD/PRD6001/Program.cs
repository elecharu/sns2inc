using System;
using System.Collections.Generic;
using System.Reflection;

namespace XtraRpt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("ERROR: Invalid arguments. Usage: PRD6001 <ReportType> <FileName> [ParamString] [FileType]");
                    return;
                }

                string prg = args[0];
                string fileName = args[1];
                string paramStr = args.Length > 2 ? args[2] : "";

                paramStr = paramStr.Replace("__SPACE__", " ");

                Dictionary<string, string> param = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(paramStr))
                {
                    foreach (string p in paramStr.Split('┃'))
                    {
                        if (string.IsNullOrEmpty(p)) continue;
                        int idx = p.IndexOf('»');
                        if (idx >= 0)
                        {
                            string key = p.Substring(0, idx);
                            string val = p.Substring(idx + 1);
                            param[key] = val;
                        }
                    }
                }

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                Assembly assembly = Assembly.GetExecutingAssembly();
                Type t = assembly.GetType("XtraRpt." + prg);

                // 2026-11-26 이 프로젝트를 다시 만들 때 S03(설비 작업일지, PRINT_WORKLOG) 소스가 없었다.
                //            예전 PRD6001.exe 를 PRD6001_S03.dll 로 같은 폴더에 두고, 여기 없는 리포트는 그 파일에서 찾는다.
                //            S03 소스를 이 프로젝트에 넣으면 이 부분과 PRD6001_S03.dll 은 지워도 된다.
                if (t == null)
                {
                    string oldFile = System.IO.Path.Combine(baseDir, "PRD6001_S03.dll");
                    if (System.IO.File.Exists(oldFile))
                    {
                        Assembly oldAssembly = Assembly.Load(System.IO.File.ReadAllBytes(oldFile));
                        t = oldAssembly.GetType("XtraRpt." + prg);
                    }
                }

                if (t == null)
                {
                    Console.WriteLine("ERROR: Report type " + prg + " not found.");
                    return;
                }

                object obj = Activator.CreateInstance(t, param);

                string tempDir = System.IO.Path.Combine(baseDir, "tempFiles");
                if (!System.IO.Directory.Exists(tempDir))
                {
                    System.IO.Directory.CreateDirectory(tempDir);
                }

                DevExpress.XtraReports.UI.XtraReport xr = obj as DevExpress.XtraReports.UI.XtraReport;
                if (xr == null)
                {
                    Console.WriteLine("ERROR: Failed to create report instance.");
                    return;
                }

                try
                {
                    if (param.ContainsKey("PW") && !string.IsNullOrEmpty(param["PW"]))
                    {
                        xr.ExportOptions.Pdf.PasswordSecurityOptions.OpenPassword = param["PW"];
                    }
                }
                catch { }

                DevExpress.XtraPrinting.HtmlExportOptions htmlOptions = xr.ExportOptions.Html;
                htmlOptions.CharacterSet = "UTF-8";
                htmlOptions.TableLayout = false;
                htmlOptions.RemoveSecondarySymbols = false;
                htmlOptions.Title = fileName;

                xr.ExportToPdf(System.IO.Path.Combine(tempDir, fileName + ".pdf"));
                xr.ExportToHtml(System.IO.Path.Combine(tempDir, fileName + ".html"));
            }
            catch (Exception e)
            {
                Exception ex = e.InnerException != null ? e.InnerException : e;
                Console.WriteLine("ERROR:" + ex.Message);
            }
        }
    }
}
