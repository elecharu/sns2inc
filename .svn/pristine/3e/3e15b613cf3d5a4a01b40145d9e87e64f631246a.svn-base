using System;
using System.Data;

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
        if(DbName != "")
        {
            mssql.DbName = DbName;
        }
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