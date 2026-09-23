using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;

public partial class ExcelToPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string FILEKEY = "";
        string FILEPATH = "";
        string TOFILEPATH = "";
        string FILEEXT = "";
        try
        {
            FILEKEY = Request["FILEKEY"].ToString();

            if(FILEKEY == "")
            {
                throw new Exception("파일키가 비어있습니다.");
            }
            ItsMaria maria = new ItsMaria();
            maria.AddQuery("SELECT FILEPATH, FILEEXT FROM COMFILE WHERE FILEKEY = '" + FILEKEY + "';");
            DataSet ds = maria.Query();
            if (maria.IsError || ds.Tables[0].Rows.Count != 1)
            {
                throw new Exception("올바르지 않은 파일 키 입니다.");
            }

            FILEPATH = ds.Tables[0].Rows[0]["FILEPATH"].ToString();
            FILEEXT = ds.Tables[0].Rows[0]["FILEEXT"].ToString();
            FILEPATH = FILEPATH.Replace("/", "\\");
            FILEPATH = "D:\\ITSCO\\ERP_YJ\\ITS_ERP_YJ_VA.1.0" + FILEPATH;
            TOFILEPATH = FILEPATH.Replace(FILEEXT, ".pdf");

            bool res = ExportWorkbookToPdf(FILEPATH, TOFILEPATH);
            if(res)
            {
                Response.Write(TOFILEPATH);
            }
            else
            {
                throw new Exception("pdf 변환에 실패했습니다.");
            }
        }
        catch(Exception ex)
        {
            Response.Write("ERROR : " + ex.ToString());
        }

        


    }
    public bool ExportWorkbookToPdf(string workbookPath, string outputPath)
    {
        // If either required string is null or empty, stop and bail out
        if (string.IsNullOrEmpty(workbookPath) || string.IsNullOrEmpty(outputPath))
        {
            return false;
        }

        // Create COM Objects
        Microsoft.Office.Interop.Excel.Application excelApplication;
        Microsoft.Office.Interop.Excel.Workbook excelWorkbook;

        // Create new instance of Excel
        excelApplication = new Microsoft.Office.Interop.Excel.Application();

        // Make the process invisible to the user
        excelApplication.ScreenUpdating = false;

        // Make the process silent
        excelApplication.DisplayAlerts = false;

        // Open the workbook that you wish to export to PDF
        excelWorkbook = excelApplication.Workbooks.Open(workbookPath);

        // If the workbook failed to open, stop, clean up, and bail out
        if (excelWorkbook == null)
        {
            excelApplication.Quit();

            excelApplication = null;
            excelWorkbook = null;

            return false;
        }

        var exportSuccessful = true;
        try
        {
            // Call Excel's native export function (valid in Office 2007 and Office 2010, AFAIK)
            excelWorkbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, outputPath);
        }
        catch (System.Exception ex)
        {
            // Mark the export as failed for the return value...
            exportSuccessful = false;

            // Do something with any exceptions here, if you wish...
            // MessageBox.Show...        
        }
        finally
        {
            // Close the workbook, quit the Excel, and clean up regardless of the results...
            excelWorkbook.Close();
            excelApplication.Quit();

            excelApplication = null;
            excelWorkbook = null;
        }

        // You can use the following method to automatically open the PDF after export if you wish
        // Make sure that the file actually exists first...
        if (System.IO.File.Exists(outputPath))
        {
            System.Diagnostics.Process.Start(outputPath);
        }

        return exportSuccessful;
    }
}