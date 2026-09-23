using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using ITSLIB;

public static class ItsMaria
{
    private static string _Url = "";
    private static string _Addr = "";
    private static string _Port = "";
    private static string _DbName = "";
    private static string _User = "";
    private static string _Pass = "";
    private static string _PrgTitle = "";
    private static string _MsgTitle = "";

    private static string _ConnString = "";

    public static string Url
    {
        get
        {
            if (_Url == "")
            {
                try
                {
                    _Url = File.ReadAllLines("downurl.config", Encoding.UTF8)[0];
                    if (_Url.Substring(Url.Length - 1, 1) != "/")
                    {
                        _Url += "/";
                    }
                }
                catch
                {
                    _Url = "ERROR: Not found URL config file ( downurl.config )";
                }
            }
            return _Url;
        }
    }
    public static string Addr { get { _SetConn(); return _Addr; } }
    public static string Port { get { _SetConn(); return _Port; } }
    public static string DbName { get { _SetConn(); return _DbName; } }
    public static string User { get { _SetConn(); return _User; } }
    public static string Pass { get { _SetConn(); return _Pass; } }
    public static string PrgTitle { get { _SetConn(); return _PrgTitle; } }
    public static string MsgTitle { get { _SetConn(); return _MsgTitle; } }

    public static void _PutConfig(string addr, string port, string user, string pass, string dbname)
    {
        _Addr = addr;
        _Port = port;
        _User = user;
        _Pass = pass;
        _DbName = dbname;

        _ConnString = String.Format("server={0};port={1};uid={2};pwd={3};database={4}", _Addr, _Port, _User, _Pass, _DbName);
    }

    public static string ConnString
    {
        get
        {
            if (_ConnString == "")
            {
                _SetConn();
                _ConnString = String.Format("server={0};port={1};uid={2};pwd={3};database={4}", _Addr, _Port, _User, _Pass, _DbName);
            }
            return _ConnString;
        }
    }
    private static void _SetConn()
    {
        if (_Addr == "")
        {
            try
            {
                string configPath = ".\\ITS_CONFIG_MARIA.xml";
                if (!File.Exists(configPath)) configPath = "..\\AAABIN\\ITS_CONFIG_MARIA.xml";

                string[] mariaConnStr = File.ReadAllLines(configPath, Encoding.UTF8);
                foreach (string str in mariaConnStr)
                {
                    if (str.IndexOf("--addr:") > -1) _Addr = ItsSecurity.DecDES(str.Replace("--addr:", "").Trim());
                    else if (str.IndexOf("--port:") > -1) _Port = ItsSecurity.DecDES(str.Replace("--port:", "").Trim());
                    else if (str.IndexOf("--user:") > -1) _User = ItsSecurity.DecDES(str.Replace("--user:", "").Trim());
                    else if (str.IndexOf("--password:") > -1) _Pass = ItsSecurity.DecDES(str.Replace("--password:", "").Trim());
                    else if (str.IndexOf("--dbname:") > -1) _DbName = ItsSecurity.DecDES(str.Replace("--dbname:", "").Trim());
                    else if (str.IndexOf("--program_title:") > -1) _PrgTitle = ItsSecurity.DecDES(str.Replace("--program_title:", "").Trim());
                    else if (str.IndexOf("--message_title:") > -1) _MsgTitle = ItsSecurity.DecDES(str.Replace("--message_title:", "").Trim());
                }
            }
            catch
            {
                _Addr = "ERROR";
                _ConnString = "ERROR: Not found MariaDB config file ( maria.config )";
            }
        }
    }

    private static string _ProcName = "";
    private static string _CallType = "";
    private static Dictionary<string, string> _OneParams = null;
    private static Dictionary<string, StringBuilder> _ListParams = null;

    public static void Set(string procName, string callType)
    {
        _ProcName = procName;
        _CallType = callType;

        _OneParams = new Dictionary<string, string>();
        _ListParams = new Dictionary<string, StringBuilder>();
    }

    public static void AddModel(ItsModelPanel panelModel)
    {
        if (panelModel.Rows.Count == 0)
        {
            ItsMsgBox.Show("ItsMaria -> AddModel(ItsModelPanel model) : 모델이 비어있습니다. ");
            return;
        }

        AddModel(panelModel.Rows[0]);
    }

    public static void AddModel(ItsModelGrid gridModel, int rowIndex)
    {
        if (rowIndex >= gridModel.Rows.Count)
        {
            ItsMsgBox.Show("ItsMaria -> rowIndex가 범위를 초과했습니다.");
            return;
        }

        if (rowIndex == -1)
        {
            AddModel(gridModel.NewRow());
        }
        else
        {
            AddModel(gridModel.Rows[rowIndex]);
        }
    }

    public static void AddModel(DataRow row)
    {
        DataTable dt = row.Table;
        foreach(DataColumn column in dt.Columns)
        {
            string columnName = column.ColumnName;
            if (columnName != "ISCHECKED" && columnName != "BACKGROUND" && columnName != "FOREGROUND" && columnName != "ROWNO")
            {
                AddOne(columnName, row[columnName].ToString());
            }
        }
    }

    public static void AddOne(string name, object value)
    {
        if (value.ToString().ToUpper() == "TRUE") value = "Y";
        if (value.ToString().ToUpper() == "FALSE") value = "N";

        int point = value.ToString().IndexOf("•");
        if (point > -1)
        {
            value = value.ToString().Substring(0, point);
        }

        if (_OneParams.Keys.Contains(name.ToUpper()))
        {
            _OneParams[name.ToUpper()] = value.ToString().Replace("'", "''''");
        }
        else
        {
            _OneParams.Add(name.ToUpper(), value.ToString().Replace("'", "''''"));
        }
    }

    public static void AddListEdit(string name, EditContent editContent, int columnIndex)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < editContent.RowCount; i++)
        {
            AddList(name, editContent.GetText(i, columnIndex));
        }
    }

    public static void AddListGrid(string name, ItsModelGrid modelGrid, string fieldName)
    {
        for(int i = 0; i < modelGrid.Rows.Count; i++)
        {
            if (modelGrid.IsChecked(i))
            {
                AddList(name, modelGrid.GetText(i, fieldName));
            }
        }
    }
    public static void AddListGridAll(string name, ItsModelGrid modelGrid, string fieldName)
    {
        for (int i = 0; i < modelGrid.Rows.Count; i++)
        {
            AddList(name, modelGrid.GetText(i, fieldName));
        }
    }
    public static void AddList(string name, object value)
    {
        if (value.ToString().ToUpper() == "TRUE") value = "Y";
        if (value.ToString().ToUpper() == "FALSE") value = "N";

        int point = value.ToString().IndexOf("•");
        if (point > -1)
        {
            value = value.ToString().Substring(0, point);
        }

        if (_ListParams.Keys.Contains(name.ToUpper()))
        {
            _ListParams[name.ToUpper()].Append(value.ToString().Replace("'", "''''") + "»");
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(value.ToString().Replace("'", "''''") + "»");
            _ListParams.Add(name.ToUpper(), sb);
        }
    }

    public static DataTable CallLotPrint(string callType, params string[] infoList)
    {
        string lotkey = "";
        StringBuilder lotlist = new StringBuilder();
        for(int i=0; i<infoList.Length; i++)
        {
            if (i == 0)
            {
                lotkey = infoList[0];
            }
            else
            {
                lotlist.Append(infoList[i] + "»");
            }
        }

        DataTable dt = ItsMaria.Query("CALL DC_LOTPRINT('" + callType + "', '" + lotkey + "', '" + lotlist + "');").Tables[0];
        return dt;
    }

    public static bool IsError = false;
    public static string ErrMessage = "";
    public static string DebugMessage = "";
    public static DataSet Call()
    {
        return _Query(Get(), ConnString, 300);
    }
    public static DataSet Call(int timeout)
    {
        return _Query(Get(), ConnString, timeout);
    }
    public static DataSet Call(string addr, string port, string user, string pass, string dbName, int timeout)
    {
        string connString = String.Format("server={0};port={1};uid={2};pwd={3};database={4}", addr, port, user, pass, dbName);
        return _Query(Get(), connString, timeout);
    }
    public static DataSet Query(string query)
    {
        return _Query(query + ";COMMIT;", ConnString, 300);
    }
    public static DataSet Query(string query, int timeout)
    {
        return _Query(query + ";COMMIT;", ConnString, timeout);
    }
    public static DataSet Query(string query, string addr, string port, string user, string pass, string dbName, int timeout)
    {
        string connString = String.Format("server={0};port={1};uid={2};pwd={3};database={4}", addr, port, user, pass, dbName);
        return _Query(query + ";COMMIT;", connString, timeout);
    }
    private static DataSet _Query(string query, string connString, int timeout)
    {
        query = query.Replace(";;", ";").Replace(";\r\n;", ";");

        IsError = false;
        ErrMessage = "";
        DebugMessage = "";

        DataSet ds = new DataSet();
        if (connString == "" || ItsMaria.Addr == "ERROR")
        {
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            IsError = true;
            ErrMessage = "Client: connString is empty !!";
            return ds;
        }

        MySqlConnection mariaConn = new MySqlConnection(connString);

        try
        {
            mariaConn.Open();

            MySqlCommand mariaCmd = new MySqlCommand();
            mariaCmd.Connection = mariaConn;
            mariaCmd.CommandText = query;
            mariaCmd.CommandType = CommandType.Text;
            mariaCmd.CommandTimeout = timeout;

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
            return ds;
        }
        catch(Exception ex)
        {
            try
            {
                mariaConn.Close();
            }
            catch { }

            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            IsError = true;
            ErrMessage = "Client: " + ex.Message;
            return ds;
        }
    }

    public static string Get()
    {
        if (!_OneParams.ContainsKey("CALLEMP"))
        {
            _OneParams.Add("CALLEMP", ItsMemberShip.EMPCD);

            try
            {
                if (ItsElement.ActiveTml != "") {
                    _OneParams.Add("CALLPRG", ItsElement.ActiveTml);
                }
                else
                    _OneParams.Add("CALLPRG", ItsElement.ActivePage.Name);
            }
            catch { }

            _OneParams.Add("CALLHOST", ItsLocalInfo.HostName);
            _OneParams.Add("CALLIP", ItsLocalInfo.IPAddressLan);
            _OneParams.Add("CALLMAC", ItsLocalInfo.MacAddress);
            _OneParams.Add("CALLBDV", ItsLocalInfo.BDVCD);
        }
        if (!_OneParams.ContainsKey("TMLEMP"))
        {
            _OneParams.Add("TMLEMP", ItsLocalInfo.TMLEMP);
        }
        if (!_OneParams.ContainsKey("BDVCD"))
        {
            _OneParams.Add("BDVCD", ItsLocalInfo.BDVCD);
        }
        try
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CALL COMCALLC ('" + _ProcName + "','" + _CallType + "','Y',");

            StringBuilder param = new StringBuilder();
            param.Append("┃");
            foreach (string name in _OneParams.Keys)
            {
                param.Append(name + "»" + _OneParams[name] + "┃");
            }

            foreach (string name in _ListParams.Keys)
            {
                param.Append(name + "»" + _ListParams[name] + "┃");
            }

            sb.Append("'" + param.ToString() + "'");
            sb.Append(");");
            return sb.ToString();
        }
        catch
        {
            return "";
        }
    }
}
