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
                    Console.WriteLine("ERROR: Invalid arguments. Usage: MTR0001 <ReportType> <FileName> [ParamString] [FileType]");
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

                Assembly assembly = Assembly.GetExecutingAssembly();
                Type t = assembly.GetType("XtraRpt." + prg);
                if (t == null)
                {
                    Console.WriteLine("ERROR: Report type " + prg + " not found.");
                    return;
                }

                object obj = Activator.CreateInstance(t, param);

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
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
