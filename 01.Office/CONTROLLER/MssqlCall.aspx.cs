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
using ActiveUp.Net.Mail;

public partial class MssqlCall : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string query = "";
        string SpName = "";
        string WorkCode = "";
        string Params = "";
        string DbName = "";

        string connstr = ConnStringCust;
        try
        {
            SpName = Request["SpName"].ToString();
            WorkCode = Request["WorkCode"].ToString();
        }
        catch (Exception ex)
        {
            SpName = "";
            WorkCode = "";
        }

        try
        {
            DbName = Request["DbName"].ToString();
        }
        catch (Exception ex)
        {
            DbName = "";
        }

        try
        {
            query = Request["query"].ToString();
            Params = Request["Params"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write("ERROR:query parameter is empty!!");
            Response.End();
        }
        
        ItsMssql mssql;
        DataSet ds;
        if (SpName.ToString().Trim() == "")
        {
            mssql = new ItsMssql();
            mssql.AddQuery(query);
        }
        else
        {
            mssql = new ItsMssql(SpName, WorkCode);
            foreach(string s in Params.Split('┃'))
            {
                mssql.AddParam(s.Split('»')[0], s.Split('»')[1]);
            }
        }
        mssql.DbName = DbName;
        ds = mssql.Query();
       
        if (mssql.IsError)
        {
            Response.Write("ERROR:" + mssql.ErrMessage);
            Response.End();
        }
        else
        {
            Response.Write(DatasetToJson(ds));
            Response.End();
        }
    }
}