using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;

public partial class TmlLabel : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string labelcd = "";
        string query = "";
        string PrintFileName = "";
        string pdfUrl = "";
        string fileName = DateTime.Now.Ticks.ToString();

        try
        {
            query = Request["query"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write("ERROR: invalid query parameter");
            Response.End();
        }
        try
        {
            labelcd = Request["labelcd"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write("ERROR: invalid labelcd parameter");
            Response.End();
        }

        ItsMaria maria = new ItsMaria();
        maria.AddQuery(query);
        DataSet ds = maria.Query();
        if(maria.IsError)
        {
            Response.Write("ERROR: " + maria.ErrMessage);
            Response.End();
            return;
        }
        ItsBarcode barCode = new ItsBarcode(labelcd);
        barCode.Data.SetDataTable(ds.Tables[0]);

        if(barCode._ERRMSG != "")
        {
            Response.Write("ERROR: " + barCode._ERRMSG);
            Response.End();
            return;
        }

        string http = "http://";
        // https포트(443)일때 https로 수정 (2026-07-24 신정수)
        if (Request.Url.Port == 443)
            http = "https://";


        PrintFileName = Server.MapPath(".") + "\\..\\Reports\\tempLabel\\" + fileName + ".pdf";
        pdfUrl = http + Request.Url.Host + ":" + Request.Url.Port + "/Reports/tempLabel/" + fileName + ".pdf";
        barCode.Print("Microsoft Print to PDF", PrintFileName);

        Response.Write(pdfUrl);
        Response.End();
    }
}