using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// ItsMssql
public class ItsMssql
{
    public string ErrMessage = "MssqlError";
    public bool IsError = true;

    public string DbServer = "115.93.139.173";
    public string DbPort = "51433";
    public string DbUser = "sa";
    public string DbPass = "dudwls";
    public string DbName = "YJPOP";
    public string ConnString
    {
        get
        {
            return String.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};Password={4};",
                DbServer, DbPort, DbName, DbUser, DbPass
            );
        }
    }

    public string SpName = "";
    public string WorkCode = "";
    public StringBuilder QueryString = new StringBuilder();
    public Dictionary<string, object> ProcParams = new Dictionary<string, object>();

    public ItsMssql(string spName, string workCode)
    {
        SpName = spName;
        WorkCode = workCode;
    }

    public ItsMssql()
    {

    }

    public void AddQuery(string query)
    {
        QueryString.AppendLine(query);
    }

    public void AddParam(string name, object value)
    {
        if (ProcParams.ContainsKey(name.ToUpper()))
        {
            ProcParams[name.ToUpper()] = value;
        }
        else
        {
            ProcParams.Add(name.ToUpper(), value);
        }
    }

    public void AddList(string name, object value)
    {
        string key = name.ToUpper();
        if (!ProcParams.ContainsKey(key))
        {
            ProcParams[key] = ""; 
        }
        ProcParams[key] = ProcParams[key] + "▩" + value.ToString();
    }

    private SqlParameter[] ToSqlParameter()
    {
        SqlParameter[] paramList = new SqlParameter[ProcParams.Count + 1];
        paramList[0] = new SqlParameter("WORKCODE", WorkCode);
        int index = 1;
        foreach (string key in ProcParams.Keys)
        {
            SqlParameter sqlParam = new SqlParameter(key, ProcParams[key]);
            sqlParam.SqlDbType = SqlDbType.NVarChar;
            paramList[index] = sqlParam;
            index++;
        }
        return paramList;
    }

    public override string ToString()
    {
        if (SpName == "")
        {
            return QueryString.ToString();
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Exec " + SpName + " @WorkCode=N'" + WorkCode + "'");
            foreach (string key in ProcParams.Keys)
            {
                sb.AppendLine(", @" + key + "=N'" + ProcParams[key] + "'");
            }
            return sb.ToString();
        }
    }

    public DataSet CallProc()
    {
        return CallProc(ConnString, 120);
    }

    public DataSet CallProc(string connString, int commandTimeout)
    {
        ErrMessage = "";
        IsError = false;

        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();

            if (commandTimeout > 0) cmd.CommandTimeout = commandTimeout;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SpName;

            SqlParameter[] paramList = ToSqlParameter();
            foreach (SqlParameter sqlParameter in paramList)
            {
                cmd.Parameters.Add(sqlParameter);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds.Tables.Count == 0)
            {
                ds.Tables.Add(new DataTable());
            }
        }
        catch (Exception ex)
        {
            con.Close();

            ds = new DataSet();
            ds.Tables.Add(new DataTable());

            SqlException sqlEx = ex as SqlException;
            if (sqlEx != null)
            {
                string errMsg = sqlEx.Message + " [ " + sqlEx.Procedure + " : " + (sqlEx.LineNumber + 4) + " ] ";
                ErrMessage = errMsg;
            }
            else
            {
                string errMsg = ex.Message + " [ " + ex.Source + " : " + ex.StackTrace + " ] ";

                ErrMessage = errMsg;
            }
            IsError = true;
            return ds;
        }

        con.Close();

        foreach (DataTable dt in ds.Tables)
        {
            if (dt.Rows.Count == 1)
            {
                string errMsg = dt.Rows[0][0].ToString();
                if (errMsg.Length >= 11 && errMsg.Substring(0, 11) == "ErrUserMsg:")
                {
                    ErrMessage = errMsg.Substring(11);
                    IsError = true;

                    return ds;

                }
                else if (errMsg.Length >= 12 && errMsg.Substring(0, 12) == "ErrCatchMsg:")
                {
                    ErrMessage = errMsg.Substring(12);
                    IsError = true;

                    return ds;

                }
            }
        }

        for (int i = 0; i < ds.Tables.Count; i++)
        {
            ds.Tables[i].TableName = "Table" + i;
        }

        return ds;
    }

    public DataSet Query()
    {
        return Query(ConnString, 120);
    }

    public DataSet Query(string connString, int commandTimeout)
    {
        ErrMessage = "";
        IsError = false;

        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connString);
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();
            if (commandTimeout > 0) cmd.CommandTimeout = commandTimeout;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ToString();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds.Tables.Count == 0)
            {
                ds.Tables.Add(new DataTable());
            }

        }
        catch (Exception ex)
        {
            con.Close();

            ds = new DataSet();
            ds.Tables.Add();

            SqlException sqlEx = ex as SqlException;
            if (sqlEx != null)
            {
                string errMsg = sqlEx.Message + " [ " + sqlEx.Source + " : " + sqlEx.LineNumber + " ] ";
                ErrMessage = errMsg;
            }
            else
            {
                string errMsg = sqlEx.Message + " [ " + ex.Source.ToString() + " : " + ex.StackTrace.ToString() + " ] ";
                ErrMessage = errMsg;
            }
            IsError = true;

            return ds;
        }

        con.Close();

        for (int i = 0; i < ds.Tables.Count; i++)
        {
            ds.Tables[i].TableName = "Table" + i;
        }

        return ds;
    }
}