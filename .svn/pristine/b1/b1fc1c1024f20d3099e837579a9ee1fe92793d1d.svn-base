using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ItsGlobalValue
{
    public static string LoginUserID = "";
    public static string LoginEmpCD = "";
    public static string LoginEmpName = "";

    public static Dictionary<string, object> ValueList = new Dictionary<string, object>();
    public static void SetValue(string name, object value)
    {
        if (ValueList.ContainsKey(name) == true)
        {
            ValueList[name] = value;
        }
        else
        {
            ValueList.Add(name, value);
        }
    }
    private static object GetValue(string name)
    {
        if (ValueList.ContainsKey(name) == true)
        {
            return null;
        }
        else
        {
            return ValueList[name];
        }
    }
    public static string GetText(string name)
    {
        object obj = GetValue(name);
        if (obj == null) return "";
        else return obj.ToString();
    }
    public static decimal GetDecimal(string name)
    {
        decimal decimalValue = ItsString.ParseDecimal(GetValue(name));
        return decimal.Parse(decimalValue.ToString("###########0.########"));
    }
    public static int GetInt(string name)
    {
        return ItsString.ParseInt(GetValue(name));
    }
}
