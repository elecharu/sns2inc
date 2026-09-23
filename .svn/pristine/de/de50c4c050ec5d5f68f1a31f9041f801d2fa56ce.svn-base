using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Script.Serialization;

public class ItsMaria
{
    public string ErrMessage = "MariaError";
    public string DebugMessage = "MariaDebug";
    public bool IsError = true;

    public string DbServer = "211.43.15.98";
    public string DbPort = "33061";
    public string DbUser = "root";
    public string DbPass = "its1005[]";
    public string DbName = "MES_SNS_FAC2";
    public string ConnString
    {
        get
        {
            return String.Format("server={0};port={1};uid={2};pwd='{3}';charset=utf8;SslMode=none;",
                DbServer, DbPort, DbUser, DbPass
            );
        }
    }

    public string SpName = "";
    public string WorkCode = "";
    public StringBuilder QueryString = new StringBuilder();
    public Dictionary<string, object> ProcParams = new Dictionary<string, object>();

    public ItsMaria(string spName, string workCode)
    {
        SpName = spName;
        WorkCode = workCode;
    }

    public ItsMaria()
    {

    }

    public void AddQuery(string query)
    {
        QueryString.Append(query);
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
        ProcParams[key] = ProcParams[key] + value.ToString() + "»";
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
            sb.Append("CALL COMCALLC ('" + SpName + "','" + WorkCode + "','Y','");
            if (ProcParams.Keys.Count > 0)
            {
                foreach (string key in ProcParams.Keys)
                {

                    try
                    {
                        string d = ProcParams[key].ToString();
                        d = d.Replace("'", "\\'");
                        sb.Append("┃" + key + "»" + d);
                    }
                    catch
                    { 
                        sb.Append("┃" + key + "»" + ProcParams[key]);
                    }
                }
            }
            sb.Append("┃');");
            return sb.ToString();
        }
    }

    public DataSet CallProc()
    {
        return CallProc(ConnString, 120);
    }

    public DataSet CallProc(string connString, int commandTimeout)
    {
        DataSet ds = new DataSet();
        if (connString == "ERROR:로그인 세션이 끊겼습니다.")
        {
            ErrMessage = connString;
            IsError = true;
            ds.Tables.Add(new DataTable());
            return ds;
        }

        ErrMessage = "";
        IsError = false;

        
        MySqlConnection mariaConn;
        mariaConn = new MySqlConnection(connString);

        if (this.SpName == "" || this.WorkCode == "")
        {
            ErrMessage = "ERROR: 프로시저명 혹은 요청유형이 정확하지 않습니다.";
            IsError = true;
            ds.Tables.Add(new DataTable());
            return ds;
        }

        try
        {
            OpenMaria(mariaConn, DbName);

            MySqlCommand mariaCmd = new MySqlCommand();
            mariaCmd.Connection = mariaConn;
            mariaCmd.CommandText = ToString();
            mariaCmd.CommandType = CommandType.Text;
            mariaCmd.CommandTimeout = 120;

            MySqlDataAdapter mariaAdapter = new MySqlDataAdapter(mariaCmd);
            mariaAdapter.Fill(ds);

            if (ds.Tables.Count > 0 && ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString() == "_ERR_")
            {
                IsError = true;
                ErrMessage = ds.Tables[ds.Tables.Count - 1].Rows[0][1].ToString();
                DebugMessage = ds.Tables[ds.Tables.Count - 1].Rows[0][2].ToString();
            }
            else if (ds.Tables.Count > 0)
            {
                try
                {
                    DebugMessage = ds.Tables[ds.Tables.Count - 1].Rows[0][2].ToString();
                }
                catch { }
            }

            mariaConn.Close();
        }
        catch (Exception ex)
        {
            try
            {
                mariaConn.Close();
            }
            catch { }

            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            IsError = true;
            ErrMessage = ex.Message;
        }

        return ds;
    }

    public DataSet Query()
    {
        return Query(ConnString, 120);
    }

    public DataSet Query(string connString, int commandTimeout)
    {
        DataSet ds = new DataSet();
        if (connString == "ERROR:로그인 세션이 끊겼습니다.")
        {
            ErrMessage = connString;
            IsError = true;
            ds.Tables.Add(new DataTable());
            return ds;
        }

        ErrMessage = "";
        IsError = false;

        MySqlConnection mariaConn;
        mariaConn = new MySqlConnection(connString);

        if (this.SpName != "" && this.WorkCode != "")
        {
            ErrMessage = "ERROR: 프로시저를 호출하세요.";
            IsError = true;
            ds.Tables.Add(new DataTable());
            return ds;
        }
        try
        {
            OpenMaria(mariaConn, DbName);

            MySqlCommand mariaCmd = new MySqlCommand();
            mariaCmd.Connection = mariaConn;
            mariaCmd.CommandText = ToString();
            mariaCmd.CommandType = CommandType.Text;
            mariaCmd.CommandTimeout = 120;

            MySqlDataAdapter mariaAdapter = new MySqlDataAdapter(mariaCmd);
            mariaAdapter.Fill(ds);

            if (ds.Tables.Count > 0 && ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString() == "_ERR_")
            {
                IsError = true;
                ErrMessage = ds.Tables[ds.Tables.Count - 1].Rows[0][1].ToString();
                DebugMessage = ds.Tables[ds.Tables.Count - 1].Rows[0][2].ToString();
            }
            else if (ds.Tables.Count > 0)
            {
                try
                {
                    DebugMessage = ds.Tables[ds.Tables.Count - 1].Rows[0][2].ToString();
                }
                catch { }
            }

            mariaConn.Close();
        }
        catch (Exception ex)
        {
            try
            {
                mariaConn.Close();
            }
            catch { }

            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            IsError = true;
            ErrMessage = ex.Message;
        }

        return ds;
    }

    private void OpenMaria(MySqlConnection conn, string dbName)
    {
        conn.Open();
        if (string.IsNullOrEmpty(conn.Database) && !string.IsNullOrEmpty(dbName))
        {
            conn.ChangeDatabase(dbName);
        }
    }
}