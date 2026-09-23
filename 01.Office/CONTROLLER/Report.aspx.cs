using System;
using System.IO;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Export.Html;
using GrapeCity.ActiveReports.Export.Html.Section;
using GrapeCity.ActiveReports.Export.Pdf;
using GrapeCity.ActiveReports.Export.Pdf.Section;
using GrapeCity.ActiveReports.Export.Excel.Page;
using GrapeCity.ActiveReports.Export.Excel.AR;
using GrapeCity.ActiveReports.Export.Excel.Section;
using GrapeCity.ActiveReports.Export.Image;
using GrapeCity.ActiveReports.Export.Image.Page;
using GrapeCity.ActiveReports.Export.Image.Tiff;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;

public partial class Report_Caller : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string query = Request["query"];
        string centerYn = Request["centerYn"];
        string path = Request["path"];
        string fileName = Request["fileName"];
        string[] subReportSectionName = Request["subReportSectionName"].Split('»');
        string[] subReportObjectName = Request["subReportObjectName"].Split('»');
        string[] subReportFileName = Request["subReportFileName"].Split('»');
        string[] subReportQueryIndex = Request["subReportQueryIndex"].Split('»');
        string[] subReportparentSubReport = Request["subReportparentSubReport"].Split('»');
        string[] imageUrlFieldName = Request["imageUrlFieldName"].Split('»');
        string[] imageFieldName = Request["imageFieldName"].Split('»');
        string[] imageQueryIndex = Request["imageQueryIndex"].Split('»');
        string[] chartSectionName = Request["chartSectionName"].Split('»');
        string[] chartObjectName = Request["chartObjectName"].Split('»');
        string[] chartQueryIndex = Request["chartQueryIndex"].Split('»');
        string security = Request["security"];
        string password = Request["password"];

        List<GrapeCity.ActiveReports.SectionReport> subRerpot = new List<GrapeCity.ActiveReports.SectionReport>();
        ItsMaria maria = new ItsMaria();
        DataSet ds;
        maria.AddQuery(query);
        if (centerYn == "Y")
        {
            ds = maria.Query();
        }
        else
        {
            ds = maria.Query(ConnStringCust, 120);
        }
        if (ds == null || maria.IsError)
        {
            Response.Write("ERROR: report QUERY error \n"  + maria.ErrMessage);
            Response.End();
            return;
        }

        if (subReportSectionName[0] == "") subReportSectionName = new string[0];
        if (subReportObjectName[0] == "") subReportObjectName = new string[0];
        if (subReportFileName[0] == "") subReportFileName = new string[0];
        if (subReportQueryIndex[0] == "") subReportQueryIndex = new string[0];
        if (subReportparentSubReport[0] == "") subReportparentSubReport = new string[0];
        if (imageUrlFieldName[0] == "") imageUrlFieldName = new string[0];
        if (imageFieldName[0] == "") imageFieldName = new string[0];
        if (imageQueryIndex[0] == "") imageQueryIndex = new string[0];
        if (chartSectionName[0] == "") chartSectionName = new string[0];
        if (chartObjectName[0] == "") chartObjectName = new string[0];
        if (chartQueryIndex[0] == "") chartQueryIndex = new string[0];
        // 리포트 로딩
        GrapeCity.ActiveReports.SectionReport rpt = new GrapeCity.ActiveReports.SectionReport();
        System.Xml.XmlTextReader xtr = new System.Xml.XmlTextReader(Server.MapPath(".") + "\\..\\PAGE" + path.Substring(0, 3) + "\\" + path + "\\" + fileName + ".rpx");
        rpt.LoadLayout(xtr);
	    xtr.Dispose();
        // 서브리포트 로딩
        for (int i = 0; i < subReportObjectName.Length; i++)
        {
            if (subReportparentSubReport[i] == "-")//1단계일경우
            {
                subRerpot.Add(new GrapeCity.ActiveReports.SectionReport());
                System.Xml.XmlTextReader xtr_sub = new System.Xml.XmlTextReader(Server.MapPath(".") + "\\..\\PAGE" + path.Substring(0, 3) + "\\" + path + "\\" + subReportFileName[i] + ".rpx");
                subRerpot[i].LoadLayout(xtr_sub);
                setSubReport(rpt, subReportSectionName[i], subReportObjectName[i], subRerpot[i]);
		        xtr_sub.Dispose();
            }
            else // 2단계 일 경우
            {
                int p = Array.BinarySearch(subReportObjectName, subReportparentSubReport[i]);

                subRerpot.Add(new GrapeCity.ActiveReports.SectionReport());
                System.Xml.XmlTextReader xtr_sub = new System.Xml.XmlTextReader(Server.MapPath(".") + "\\..\\PAGE" + path.Substring(0, 3) + "\\" + path + "\\" + subReportFileName[i] + ".rpx");
                subRerpot[i].LoadLayout(xtr_sub);
                setSubReport(subRerpot[p], subReportSectionName[i], subReportObjectName[i], subRerpot[i]);
		        xtr_sub.Dispose();
            }

        }
        // 이미지 세팅
        for (int i = 0; i < imageUrlFieldName.Length; i++)
        {
            int index = Convert.ToInt32(imageQueryIndex[i]);
            if (ds.Tables[index].Rows.Count > 0)
            {
                try
                {
                    AddImageColumn(ds.Tables[index], imageFieldName[i], ds.Tables[index].Rows[0][imageUrlFieldName[i]].ToString());
                }
                catch
                {
                    try
                    {
                        AddImageColumn(ds.Tables[index], imageFieldName[i], "http://" + Request.Url.Host + ":" + Request.Url.Port + "/UploadFiles/404IMAGE.jpg");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("ERROR: 이미지 로딩 에러");
                        Response.End();
                        return;
                    }
                }
                
            }
        }
        try
        {
            // 메인 리포트 데이터
            rpt.DataSource = ds.Tables[0];
            // 서브리포트 데이터
            for (int i = 0; i < subRerpot.Count; i++)
            {
                subRerpot[i].DataSource = ds.Tables[Convert.ToInt32(subReportQueryIndex[i])];
            }
            // 차트에 데이터 세팅
            for (int i = 0; i < chartSectionName.Length; i++)
            {
                setChartData(rpt, chartSectionName[i], chartObjectName[i], ds.Tables[Convert.ToInt32(chartQueryIndex[i])]);
            }
            rpt.Run();
        }
        catch (Exception ex)
        {
            Response.Write("ERROR: report error");
            Response.Write(ex.ToString());
            Response.End();
            return;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        // pdf 파일 만들어서 경로 리턴
        string dbName = GetSession("SESSION_DBNAME");
        if (dbName == "")
        { // 세션이 없을경우
            dbName = "NOSQL";
        }
        // 폴더가 없으면 생성
        string sDirPath;
        sDirPath = Server.MapPath(".") + "\\..\\UploadFiles\\" + dbName + "\\Report";
        DirectoryInfo di = new DirectoryInfo(sDirPath);
        if (di.Exists == false)
        {
            di.Create();
        }
        foreach (var item in di.GetFiles())
        {
            if (item.CreationTime < System.DateTime.Now.AddDays(-3) && item.Name.IndexOf(".pdf") > -1)
            {
                item.Delete();
            }
        }

        string pdfFileName = System.DateTime.Now.Ticks.ToString() + "_" + fileName;
        string reportUrl = getReportUrl(rpt, dbName, pdfFileName, security, password);
        //string reportUrl = getReportUrl_Payment(rpt, dbName, pdfFileName, "kimih@itsco.co.kr", "12345");

        rpt.Dispose();
        for (int i = 0; i < subRerpot.Count; i++)
        {
            subRerpot[i].Dispose();
        }
        Response.Write(reportUrl);
        Response.End();
    }

    public void AddImageColumn(DataTable dt, string columnName, string fieldUrl)
    {
        if(!dt.Columns.Contains(columnName))
        {
            dt.Columns.Add(columnName, typeof(byte[]));
        }
        WebClient webClient = new WebClient();
        byte[] image = webClient.DownloadData(fieldUrl);
        for(int i = 0; i < dt.Rows.Count; i ++)
        {
            dt.Rows[i][columnName] = image;
        }
    }

    public void setSubReport(GrapeCity.ActiveReports.SectionReport rpt, string subReportSectionName, string subReportObjectName, GrapeCity.ActiveReports.SectionReport rpt_sub)
    {
        int sectionIndex = -1;
        int objectIndex = -1;
        for (int i = 0; i < rpt.Sections.Count; i++)
        {
            if (rpt.Sections[i].GetType().Name == subReportSectionName)
            {

                sectionIndex = i;
            }
        }
        if (sectionIndex == -1)
        {
            return;
        }
        for (int i = 0; i < rpt.Sections[sectionIndex].Controls.Count; i++)
        {
            if (rpt.Sections[sectionIndex].Controls[i].Name == subReportObjectName)
            {
                objectIndex = i;
            }
        }
        if (objectIndex == -1)
        {
            return;
        }
        (rpt.Sections[sectionIndex].Controls[objectIndex] as GrapeCity.ActiveReports.SectionReportModel.SubReport).Report = rpt_sub;
    }
    public void setChartData(GrapeCity.ActiveReports.SectionReport rpt, string sectionName, string objectName, DataTable dt)
    {
        int sectionIndex = -1;
        int objectIndex = -1;
        for (int i = 0; i < rpt.Sections.Count; i++)
        {
            if (rpt.Sections[i].GetType().Name == sectionName)
            {

                sectionIndex = i;
            }
        }
        if (sectionIndex == -1)
        {
            return;
        }
        for (int i = 0; i < rpt.Sections[sectionIndex].Controls.Count; i++)
        {
            if (rpt.Sections[sectionIndex].Controls[i].Name == objectName)
            {
                objectIndex = i;
            }
        }
        if (objectIndex == -1)
        {
            return;
        }
        (rpt.Sections[sectionIndex].Controls[objectIndex] as GrapeCity.ActiveReports.SectionReportModel.ChartControl).DataSource = dt;
    }
    public string getReportUrl(GrapeCity.ActiveReports.SectionReport rpt, string dbName, string fileName, string Export_Type, string PWD)
    {
        string reportUrl = "";

        GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport PdfExport1 = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();
        PdfExport1.Export(rpt.Document, Server.MapPath(".") + "\\..\\UploadFiles\\" + dbName + "\\Report\\" + fileName + ".pdf");

        // PDF 변환 시 PASSWORD 적용 
        if (Export_Type == "security")
        {
            PdfExport1.Security.Encrypt = true;
            PdfExport1.Security.OwnerPassword = "itsco";
            PdfExport1.Security.UserPassword = PWD;
            PdfExport1.Security.Permissions = GrapeCity.ActiveReports.Export.Pdf.Section.PdfPermissions.AllowPrint;
            PdfExport1.Security.Use128Bit = true;
            PdfExport1.Export(rpt.Document, Server.MapPath(".") + "\\..\\UploadFiles\\" + dbName + "\\Report\\" + fileName + "_PW.pdf");
        }


        reportUrl = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/UploadFiles/" + dbName + "/Report/" + fileName + ".pdf";

        return reportUrl;
    }
}