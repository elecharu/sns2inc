using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using ITSLIB;

public class ItsMariaThread
{
    private string _ProcName = "";
    private string _CallType = "";
    private Dictionary<string, string> _OneParams = null;
    private Dictionary<string, StringBuilder> _ListParams = null;

    public void Set(string procName, string callType)
    {
        _ProcName = procName;
        _CallType = callType;

        _OneParams = new Dictionary<string, string>();
        _ListParams = new Dictionary<string, StringBuilder>();
    }

    public void AddModel(ItsModelPanel panelModel)
    {
        if (panelModel.Rows.Count == 0)
        {
            ItsMsgBox.Show("ItsMaria -> AddModel(ItsModelPanel model) : 모델이 비어있습니다. ");
            return;
        }

        AddModel(panelModel.Rows[0]);
    }

    public void AddModel(ItsModelGrid gridModel, int rowIndex)
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

    public void AddModel(DataRow row)
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

    public void AddOne(string name, object value)
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

    public void AddListEdit(string name, EditContent editContent, int columnIndex)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < editContent.RowCount; i++)
        {
            AddList(name, editContent.GetText(i, columnIndex));
        }
    }

    public void AddListGrid(string name, ItsModelGrid modelGrid, string fieldName)
    {
        for(int i = 0; i < modelGrid.Rows.Count; i++)
        {
            if (modelGrid.IsChecked(i))
            {
                AddList(name, modelGrid.GetText(i, fieldName));
            }
        }
    }
    public void AddListGridAll(string name, ItsModelGrid modelGrid, string fieldName)
    {
        for (int i = 0; i < modelGrid.Rows.Count; i++)
        {
            AddList(name, modelGrid.GetText(i, fieldName));
        }
    }
    public void AddList(string name, object value)
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

    public DataTable CallLotPrint(string callType, params string[] infoList)
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

    public bool IsError = false;
    public string ErrMessage = "";
    public string DebugMessage = "";
    public DataSet Call()
    {
        return _Query(Get(), ItsMaria.ConnString, 300);
    }
    public DataSet Call(int timeout)
    {
        return _Query(Get(), ItsMaria.ConnString, timeout);
    }
    public DataSet Call(string addr, string port, string user, string pass, string dbName, int timeout)
    {
        string connString = String.Format("server={0};port={1};uid={2};pwd={3};database={4}", addr, port, user, pass, dbName);
        return _Query(Get(), connString, timeout);
    }
    public DataSet Query(string query)
    {
        return _Query(query + ";COMMIT;", ItsMaria.ConnString, 300);
    }
    public DataSet Query(string query, int timeout)
    {
        return _Query(query + ";COMMIT;", ItsMaria.ConnString, timeout);
    }
    public DataSet Query(string query, string addr, string port, string user, string pass, string dbName, int timeout)
    {
        string connString = String.Format("server={0};port={1};uid={2};pwd={3};database={4}", addr, port, user, pass, dbName);
        return _Query(query + ";COMMIT;", connString, timeout);
    }
    private DataSet _Query(string query, string connString, int timeout)
    {
        query = query.Replace(";;", ";");

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

    public string Get()
    {
        if (!_OneParams.ContainsKey("CALLEMP"))
        {
            _OneParams.Add("CALLEMP", ItsMemberShip.EMPCD);
            if (ItsElement.ActivePage != null)
            {
                try
                { _OneParams.Add("CALLPRG", ItsElement.ActivePage.Name); }
                catch (Exception ex)
                { }
            }
            //_OneParams.Add("CALLHOST", ItsLocalInfo.HostName);
            //_OneParams.Add("CALLIP", ItsLocalInfo.IPAddressLan);
            //_OneParams.Add("CALLMAC", ItsLocalInfo.MacAddress);
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
