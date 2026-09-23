using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Diagnostics;

public partial class XtraReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string procName = "";
        string procNo = "";
        string paramStr = "";
        string fileType = "";
        string fileName = "";

        try
        {
            procName = Request["procName"].ToString().Split('_')[0];
            procNo = Request["procName"].ToString().Split('_')[1];
            paramStr = Request["paramStr"].ToString();
            fileType = Request["fileType"].ToString();
            fileName = Request["fileName"].ToString();
            paramStr = paramStr.Replace(" ", "__SPACE__");
        }
        catch(Exception ex)
        {
            Response.Write("ERROR:parameter error.");
            Response.End();
        }

        Process p = new Process();
        if(fileName == "")
        {
            fileName = DateTime.Now.Ticks.ToString();
        }
        
        string pdfUrl = "";
        string http = "http://";

        // https포트(443)일때 https로 수정 (2026-07-24 신정수)
        if(Request.Url.Port == 443)
            http = "https://";

        if (fileType == "xlsx")
        {
            pdfUrl = http + Request.Url.Host + ":" + Request.Url.Port + "/Reports/tempFiles/" + fileName + ".xlsx";
        }
        else if (fileType == "xls")
        {
            pdfUrl = http + Request.Url.Host + ":" + Request.Url.Port + "/Reports/tempFiles/" + fileName + ".xls";
        }
        else
        {
            pdfUrl = http + Request.Url.Host + ":" + Request.Url.Port + "/Reports/tempFiles/" + fileName + ".pdf";
        }

        p.StartInfo.FileName = Server.MapPath(".") + "\\..\\Reports\\" + procName + ".exe";
        p.StartInfo.Arguments = procNo + " " + fileName + " " + paramStr + " " + fileType;
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.Start();
        StringBuilder sb = new StringBuilder();

        while (true)
        {
            string stdout = p.StandardOutput.ReadToEnd();
            sb.Append(stdout);
            if (p.HasExited)
            {
                break;
            }
        }
        p.WaitForExit();
        Console.WriteLine(sb.ToString());
        if(sb.ToString() == "")
        {
            Response.Write(pdfUrl);
        }
        else
        {
            Response.Write("ERROR:" + sb.ToString());
        }
        
        Response.End();
    }
}