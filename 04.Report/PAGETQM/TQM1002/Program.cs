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
                    Console.WriteLine("ERROR: Invalid arguments. Usage: TQM1002 <ReportType> <FileName> [ParamString] [FileType]");
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

                // 2026-11-26 엑셀 변환: 웹이 4번째 인자로 fileType 을 넘긴다. xlsx 면 엑셀(검사 1건 = 시트 1장), 아니면 기존대로 PDF+HTML
                string fileType = args.Length > 3 ? args[3].ToLower() : "pdf";
                if (fileType == "xlsx")
                {
                    DevExpress.XtraPrinting.XlsxExportOptions xlsxOptions = new DevExpress.XtraPrinting.XlsxExportOptions();
                    xlsxOptions.ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFilePageByPage;
                    xlsxOptions.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value;
                    xr.ExportToXlsx(System.IO.Path.Combine(tempDir, fileName + ".xlsx"), xlsxOptions);
                    return;
                }

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
