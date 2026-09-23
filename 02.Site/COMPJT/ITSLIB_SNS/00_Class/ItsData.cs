using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using ITSLIB;

public static class ItsData
{
    public static Dictionary<string, object> _Data = new Dictionary<string, object>();
    public static void SetData(string key, object data)
    {
        if (_Data.ContainsKey(key))
        {
            _Data[key] = data;
        }
        else
        {
            _Data.Add(key, data);
        }
    }

    public static object GetData(string key)
    {
        if (_Data.ContainsKey(key)) return _Data[key];
        return null;
    }

    public static string GetString(string key)
    {
        if (_Data.ContainsKey(key)) return _Data[key].ToString();
        return "";
    }

    public static string GPCD(string gpcd, string code)
    {
        string QUERY = "SELECT GPCD('" + gpcd + "', '" + code + "');";
        return GetScalar(ItsMaria.Query(QUERY));
    }

    public static string GetScalar(DataSet ds)
    {
        if (ds == null) return "";
        if (ds.Tables.Count == 0) return "";
        if (ds.Tables[0].Rows.Count == 0) return "";
        return ds.Tables[0].Rows[0][0].ToString();
    }
    public static string GetScalar(DataTable dt)
    {
        if (dt == null) return "";
        if (dt.Rows.Count == 0) return "";
        return dt.Rows[0][0].ToString();
    }
    public static string GetText(DataTable dt, int rowIndex, string fieldName)
    {
        return ItsString.ParseString(GetValue(dt, rowIndex, fieldName));
    }
    public static int GetInt(DataTable dt, int rowIndex, string fieldName)
    {
        return ItsString.ParseInt(GetValue(dt, rowIndex, fieldName));
    }
    public static DateTime GetDateTime(DataTable dt, int rowIndex, string fieldName)
    {
        return ItsString.ParseDateTime(GetValue(dt, rowIndex, fieldName));
    }
    public static decimal GetDecimal(DataTable dt, int rowIndex, string fieldName)
    {
        decimal decimalValue = ItsString.ParseDecimal(GetValue(dt, rowIndex, fieldName));
        return decimal.Parse(decimalValue.ToString("###########0.########"));
    }
    public static object GetValue(DataTable dt, int rowIndex, string fieldName)
    {
        if (dt == null || dt.Rows.Count == 0)
        {
            return "";
        }
        if (rowIndex >= dt.Rows.Count)
        {
            return "";
        }

        try
        {
            object value = dt.Rows[rowIndex][fieldName];
            if (value == null) return "";
            else return value;
        }
        catch
        {
            return "";
        }
    }
    public static void SetValue(DataTable dt, int rowIndex, string fieldName, object value)
    {
        try
        {
            dt.Rows[rowIndex][fieldName] = value;
        }
        catch { }
    }
    public static void YnToBool(DataTable dt)
    {
        if (dt != null)
        {
            int rowCount = dt.Rows.Count;
            int columnCount = dt.Columns.Count;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Rows[0][i].ToString().Trim() == "Y"
                    || dt.Rows[0][i].ToString().Trim() == "N")
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string yn = dt.Rows[j][i].ToString();
                        if (yn == "Y")
                        {
                            dt.Rows[j][i] = true;
                        }
                        else if (yn == "N")
                        {
                            dt.Rows[j][i] = false;
                        }
                    }
                }
            }
        }
    }
    public static void BoolToYn(DataTable dt)
    {
        if (dt != null)
        {
            int rowCount = dt.Rows.Count;
            int columnCount = dt.Columns.Count;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Rows[0][i].ToString() == "True"
                    || dt.Rows[0][i].ToString() == "False")
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string yn = dt.Rows[j][i].ToString();
                        if (yn == "True")
                        {
                            dt.Rows[j][i] = "Y";
                        }
                        else if (yn == "False")
                        {
                            dt.Rows[j][i] = "N";
                        }
                    }
                }
            }
        }
    }
    public static DataTable NewTable(string[] headers, params object[] rows)
    {
        DataTable dt = new DataTable();
        for (int i = 0; i < headers.Length; i++)
        {
            dt.Columns.Add(headers[i]);
        }

        foreach (object[] row in rows)
        {
            DataRow newRow = dt.NewRow();
            for (int i = 0; i < headers.Length; i++)
            {
                try
                {
                    newRow[i] = row[i];
                }
                catch
                {
                    newRow[i] = "";
                }
            }
            dt.Rows.Add(newRow);
        }

        return dt;
    }
    public static DataTable FilterTable(DataTable dt, string filterExpression)
    {
        if (dt == null) return new DataTable();

        DataTable newDt = new DataTable();
        DataRow[] newRows = dt.Select(filterExpression);
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            newDt.Columns.Add(dt.Columns[i].ColumnName);
        }
        for (int i = 0; i < newRows.Length; i++)
        {
            DataRow row = newDt.NewRow();
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                row[j] = newRows[i][j];
            }
            newDt.Rows.Add(row);
        }

        return newDt;
    }
    public static DataTable SortTable(DataTable dt, string orderBy)
    {
        DataView dv = new DataView(dt);
        try
        {
            dv.Sort = orderBy;
        }
        catch
        {
            return dt.Copy();
        }
        return dv.ToTable();
    }
    public static DataTable NullToString(DataTable dt)
    {
        for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < dt.Columns.Count; columnIndex++)
            {
                try
                {
                    object value = dt.Rows[rowIndex][columnIndex];
                    if (value == null) dt.Rows[rowIndex][columnIndex] = "";
                }
                catch { }
            }
        }
        return dt;
    }
}
