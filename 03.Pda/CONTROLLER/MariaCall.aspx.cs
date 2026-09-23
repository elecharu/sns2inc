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

public partial class MariaCall : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string query = "";

        string loginYn = "N";
        string apiKey = "";
        string connDB = "";
        string connstr = ConnStringCust;
        try
        {
            query = Request["query"].ToString();
            connDB = Request["conndb"].ToString();

        }
        catch (Exception ex)
        {
            Response.Write("ERROR:query parameter is empty!!");
            Response.End();
        }
        try
        {
            apiKey = Request["apiKey"].ToString();
        }
        catch
        {
            apiKey = "";
        }
        // maria.addOne("---", "---"); 추가되어 있을 경우 
        // 로그인 과정으로 간주
        if (query.IndexOf("┃---»---┃") > -1)
        {
            loginYn = "Y";
        }

        query = query.Replace("SESSION_LOGINKEY»SESSION_LOGINKEY", "SESSION_LOGINKEY»" + GetSession("SESSION_LOGINKEY"));
        query = query.Replace("SESSION_USERID»SESSION_USERID", "SESSION_USERID»" + GetSession("SESSION_USERID"));
        query = query.Replace("SESSION_USERNM»SESSION_USERNM", "SESSION_USERNM»" + GetSession("SESSION_USERNM"));
        query = query.Replace("CALLEMP»CALLEMP", "CALLEMP»" + GetSession("SESSION_USERID"));
        query = query.Replace("CALLIP»CALLIP", "CALLIP»" + Request.UserHostAddress);

        string copyquery = query;
        try
        {
            for (int i = 1; i < copyquery.Split('┃').Length - 1; i++)
            {
                string param = copyquery.Split('┃')[i];
                string convertParam = param.Replace("'", "\\'\\'");
                query = query.Replace(param, convertParam);
            }
        }
        catch
        {
            query = copyquery;
        }

        if (query.ToString().Trim().IndexOf("CALL") == -1)
        {
            int selectindex = query.ToUpper().Trim().IndexOf("SELECT");
            if (selectindex == -1 || selectindex > 1)
            {
                Response.Write("ERROR:" + "허용되지 않는 쿼리문입니다. " + query);
                Response.End();
            }
            query += ";commit;SELECT '_SUC_' AS RTNCODE, 'SUCCESS' AS ERRMSG, 'DEBUG' AS ERRDEBUG;";
        }
        query = query.Replace(";;", ";");

        //InitSession();
        if (apiKey != null && apiKey != "")
        {
            connstr = ItsSecurity.DecDES(apiKey.Replace("ITSAPIKEY", "/").Replace("ITSAPIEQ", "=").Replace("ITSPLUS", "+"));
        }

        ItsMaria maria = new ItsMaria();
        maria.AddQuery(query.ToString());
        DataSet ds;
        if (connDB == "CENTER")
        {
            ds = maria.Query();
        }

        else
        {
            ds = maria.Query(connstr, 120);
        }
        if (maria.IsError)
        {
            Response.Write("ERROR:" + maria.ErrMessage);
            Response.End();
        }
        else
        {
            if (loginYn == "Y")
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row[0].ToString() == "LOGOUT")
                {
                    Session.Clear();
                }
                else
                {
                    Session.Clear();
                    Session.Timeout = 60 * 30;

                    SetSession("SESSION_LOGINKEY", row["LOGINKEY"]);
                    SetSession("SESSION_LOGINTIME", row["LOGINTIME"]);

                    SetSession("SESSION_USERID", row["USERID"]);
                    SetSession("SESSION_USERPW", row["USERPW"]);
                    SetSession("SESSION_USERNM", row["USERNM"]);
                    SetSession("SESSION_MESTOKEN", row["MESTOKEN"]);
                    setSrcVersion(row["SRCVERSION"].ToString());
                    SetSession("SESSION_DBADDR", maria.DbServer);
                    SetSession("SESSION_DBUSER", maria.DbUser);
                    SetSession("SESSION_DBPORT", maria.DbPort);
                    SetSession("SESSION_DBPASS", maria.DbPass);
                    SetSession("SESSION_DBNAME", maria.DbName);
                    //SetSession("SESSION_IMAP", new Imap4Client());
                    //SetSession("SESSION_IMAP_DAUM", new Imap4Client());
                    //SetSession("SESSION_POP3_DAUM", new OpenPop.Pop3.Pop3Client());

                    DataTable dt = new DataTable();
                    dt.Columns.Add("LOGINKEY");
                    dt.Columns.Add("LOGINTIME");
                    dt.Columns.Add("USERID");
                    dt.Columns.Add("USERNM");
                    dt.Columns.Add("MESTOKEN");
                    dt.Columns.Add("CUSTCD");
                    dt.Columns.Add("CUSTNM");
                    dt.Columns.Add("CENTERCD");
                    dt.Columns.Add("APIKEY");

                    DataRow newRow = dt.NewRow();
                    newRow["LOGINKEY"] = GetSession("SESSION_LOGINKEY");
                    newRow["LOGINTIME"] = GetSession("SESSION_LOGINTIME");
                    newRow["USERID"] = GetSession("SESSION_USERID");
                    newRow["USERNM"] = GetSession("SESSION_USERNM");
                    newRow["MESTOKEN"] = GetSession("SESSION_MESTOKEN");
                    dt.Rows.Add(newRow);

                    // ds = new DataSet();
                    // ds.Tables[0] = dt;
                }
            }

            Response.Write(DatasetToJson(ds));
            Response.End();
        }
    }
}