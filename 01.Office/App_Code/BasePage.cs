using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Net;
using System.Web.Script.Serialization;

public class BasePage : System.Web.UI.Page
{
    public static string srcVersion;
    public void setSrcVersion(string version)
    {
        srcVersion = version;
    }
    public string getSrcVersion()
    {
        return srcVersion;
    }
    public static string userFontSize;
    public void setUserFontSize(string fontsize)
    {
        userFontSize = fontsize;
    }
    public string getUserFontSize()
    {
        return userFontSize;
    }
    public enum RequestMethodType
    {
        POST, GET, PUT, DELETE, PATCH
    }

    public enum ColorList
    {
        Transparent, Theme, Black, White, AddPanel,
        Primary, Success, Info, Warning, Danger,
        PrimaryBorder, SuccessBorder, InfoBorder, WarningBorder, DangerBorder,
        GrayDark2, GrayDark1, Gray, GrayLight1, GrayLight2,
        RedDark2, RedDark1, Red, RedLight1, RedLight2, HotPink,
        BlueDark2, BlueDark1, Blue, BlueLight1, BlueLight2,
        GreenDark2, GreenDark1, Green, GreenLight1, GreenLight2,
        YellowDark2, YellowDark1, Yellow, YellowLight1, YellowLight2,
        PurpleDark2, PurpleDark1, Purple, PurpleLight1, PurpleLight2,
        CommonButton, LightCyan,
        DefaultButton, CustomButton, CustomButton2, CustomButton3
    }

    public static string ConvertColor(ColorList color)
    {
        switch (color)
        {
            case ColorList.Transparent: return "transparent";
            case ColorList.Primary: return "#337ab7";
            case ColorList.Success: return "#5cb85c";
            case ColorList.Info: return "#5bc0de";
            case ColorList.Warning: return "#f0ad4e";
            case ColorList.Danger: return "#d9534f";
            case ColorList.PrimaryBorder: return "#2e6ad4";
            case ColorList.SuccessBorder: return "#4cae4c";
            case ColorList.InfoBorder: return "#46b8da";
            case ColorList.WarningBorder: return "#eea236";
            case ColorList.DangerBorder: return "#d43f3a";
            case ColorList.Theme: return "#7691d9";
            case ColorList.Black: return "black";
            case ColorList.White: return "white";
            case ColorList.AddPanel: return "linen";
            case ColorList.GrayDark2: return "dimGray";
            case ColorList.GrayDark1: return "gray";
            case ColorList.Gray: return "silver";
            case ColorList.GrayLight1: return "lightGray";
            case ColorList.GrayLight2: return "whiteSmoke";
            case ColorList.RedDark2: return "darkRed";
            case ColorList.RedDark1: return "indianRed";
            case ColorList.Red: return "red";
            case ColorList.RedLight1: return "pink";
            case ColorList.RedLight2: return "lavenderBlush";
            case ColorList.HotPink: return "hotpink";
            case ColorList.BlueDark2: return "navy";
            case ColorList.BlueDark1: return "steelBlue";
            case ColorList.Blue: return "blue";
            case ColorList.BlueLight1: return "lightSteelBlue";
            case ColorList.BlueLight2: return "aliceBlue";
            case ColorList.GreenDark2: return "darkGreen";
            case ColorList.GreenDark1: return "seaGreen";
            case ColorList.Green: return "green";
            case ColorList.GreenLight1: return "greenYellow";
            case ColorList.GreenLight2: return "mintCream";
            case ColorList.YellowDark2: return "darkGoldenRod";
            case ColorList.YellowDark1: return "orange";
            case ColorList.Yellow: return "gold";
            case ColorList.YellowLight1: return "yellow";
            case ColorList.YellowLight2: return "lightYellow";
            case ColorList.PurpleDark2: return "purple";
            case ColorList.PurpleDark1: return "darkViolet";
            case ColorList.Purple: return "blueViolet";
            case ColorList.PurpleLight1: return "mediumPurple";
            case ColorList.PurpleLight2: return "thistle";
            case ColorList.CommonButton: return "#0078d7";
            case ColorList.LightCyan: return "LightCyan";
            case ColorList.DefaultButton: return "#FFFFFF";
            case ColorList.CustomButton: return "#74D178";
            case ColorList.CustomButton2: return "#4774B9";
            case ColorList.CustomButton3: return "#F34F4F";
        }
        return "black";
    }

    public string ErrMsg = "";
    public string ServerUrl
    {
        get
        {
            return "";
        }
    }
    public BasePage()
    {

    }

    public string GetRequest(string reqName)
    {
        try
        {
            return Request[reqName].ToString();
        }
        catch
        {
            return "";
        }
    }

    public string GetSession(string key)
    {
        if (Session[key] == null) return "";
        else return Session[key].ToString();
    }

    public void SetSession(string key, object value)
    {
        if (Session[key] == null) Session.Add(key, value);
        else Session[key] = value;
    }

    public void InitSession()
    {
        if (GetSession("SESSION_LOGINKEY") == "")
        {
            bool isLocal = true;
            try
            {
                if (Request.Url.Host.IndexOf("localhost") == -1)
                {
                    isLocal = false;
                }
            }
            catch
            {
                isLocal = true;
            }

            if (isLocal == true) // 운영시 이 안에 다 주석처리
            {
                //Session.Clear();
                //Session.Timeout = 1 * 600;

                //// 미플
                //SetSession("SESSION_DBADDR", "mipl.optisco.com");
                //SetSession("SESSION_DBPORT", "33061");
                //SetSession("SESSION_DBUSER", "root");
                //SetSession("SESSION_DBPASS", "itscomp12#$");
                //SetSession("SESSION_DBNAME", "MP_A180101");
                //SetSession("SESSION_USERID", "jwmun");
                //SetSession("SESSION_USERNM", "개발계정");
            }
        }
    }

    public string ConnStringCust
    { 
        get
        {
            InitSession(); // 개발모드일 경우만 작동함.
            if (GetSession("SESSION_LOGINKEY") == "")
            {
                if(GetSession("SESSION_APIKEY") != null && GetSession("SESSION_APIKEY") != "")
                {
                    return GetSession("SESSION_APIKEY");
                } else
                {
                    return "ERROR:로그인 세션이 끊겼습니다.";
                }
            }
            return String.Format("server={0};port={1};uid={2};pwd={3};database={4}",
                GetSession("SESSION_DBADDR"),
                GetSession("SESSION_DBPORT"),
                GetSession("SESSION_DBUSER"),
                GetSession("SESSION_DBPASS"),
                GetSession("SESSION_DBNAME"));
        }
    }

    public string GetFindHead(string gpcd, string proc, ref string GridField, ref string GridTitle, ref string GridWidth, ref string GridLength)
    {
        StringBuilder tag_head = new StringBuilder();
        try
        {
            tag_head.AppendLine("<span class=\"no\">No.</span>");

            GridTitle = "";

            ItsMaria maria = new ItsMaria(proc, " ");
            maria.AddParam("GPCD", gpcd + "_HEAD");
            DataSet ds = maria.CallProc(this.ConnStringCust, 120);
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                string field = ds.Tables[0].Columns[i].ColumnName;
                string title = ds.Tables[0].Rows[0][i].ToString();
                string width = ds.Tables[1].Rows[0][i].ToString();

                GridField = GridField + "»" + field;
                GridTitle = GridTitle + "»" + title;
                GridWidth = GridWidth + "»" + width;

                tag_head.AppendLine("<span class=\"list\" style=\"width:" + width + "px;\">" + title + "</span>");
            }
            try { GridLength = ds.Tables[2].Rows[0][0].ToString(); } catch { GridLength = "0"; }
        }
        catch
        {
            return "";
        }

        return tag_head.ToString();
    }
    public string GetComboTag(string gpcd)
    {
        StringBuilder tag = new StringBuilder();
        try
        {
            DataTable LiList = new DataTable();
            string flag = gpcd.Substring(0, 1);
            if (flag == "*" || flag == "@")
            {
                gpcd = gpcd.Substring(1);
            }

            if (gpcd.IndexOf("SELECT") > -1)
            {
                ItsMaria maria = new ItsMaria();
                maria.AddQuery(gpcd);
                LiList = maria.Query(this.ConnStringCust, 120).Tables[0];
            }
            else
            {
                ItsMaria maria = new ItsMaria("DC_COMBO", " ");
                maria.AddParam("GPCD", gpcd);
                LiList = maria.CallProc(this.ConnStringCust, 120).Tables[0];
            }
            
            LiList.Columns[0].ColumnName = "Label";
            LiList.Columns[1].ColumnName = "Value";
            //LiList.Columns[2].ColumnName = "Tag";
            if (!LiList.Columns.Contains("REF01")) LiList.Columns.Add("REF01");
            if (!LiList.Columns.Contains("REF02")) LiList.Columns.Add("REF02");
            if (!LiList.Columns.Contains("REF03")) LiList.Columns.Add("REF03");
            if (!LiList.Columns.Contains("REF04")) LiList.Columns.Add("REF04");
            if (!LiList.Columns.Contains("REF05")) LiList.Columns.Add("REF05");
            if (!LiList.Columns.Contains("REF06")) LiList.Columns.Add("REF06");
            if (!LiList.Columns.Contains("REF07")) LiList.Columns.Add("REF07");
            if (!LiList.Columns.Contains("REF08")) LiList.Columns.Add("REF08");
            if (!LiList.Columns.Contains("REF09")) LiList.Columns.Add("REF09");
            if (!LiList.Columns.Contains("REF10")) LiList.Columns.Add("REF10");
            if (!LiList.Columns.Contains("REF11")) LiList.Columns.Add("REF11");
            if (!LiList.Columns.Contains("REF12")) LiList.Columns.Add("REF12");
            if (!LiList.Columns.Contains("REF13")) LiList.Columns.Add("REF13");
            if (!LiList.Columns.Contains("REF14")) LiList.Columns.Add("REF14");
            if (!LiList.Columns.Contains("REF15")) LiList.Columns.Add("REF15");
            if (!LiList.Columns.Contains("REF16")) LiList.Columns.Add("REF16");
            if (!LiList.Columns.Contains("REF17")) LiList.Columns.Add("REF17");
            if (!LiList.Columns.Contains("REF18")) LiList.Columns.Add("REF18");
            if (!LiList.Columns.Contains("REF19")) LiList.Columns.Add("REF19");
            if (!LiList.Columns.Contains("REF20")) LiList.Columns.Add("REF20");
            if (flag == "*")
            {
                DataRow row = LiList.NewRow();
                row[0] = "전체";
                row[1] = "";
                //row[2] = "전체";
                LiList.Rows.InsertAt(row, 0);
            }
            else if (flag == "@")
            {
                DataRow row = LiList.NewRow();
                row[0] = "전체";
                row[1] = "";
                //row[2] = "전체";
                LiList.Rows.InsertAt(row, 0);
            }
            for (int i = 0; i < LiList.Rows.Count; i++)
            {
                tag.Append("<li data-label=\"" + LiList.Rows[i]["Label"] + "\" data-value=\"" + LiList.Rows[i]["Value"] + "\" ");
                tag.Append(" data-ref01=\"" + LiList.Rows[i]["REF01"] + "\" data-ref11=\"" + LiList.Rows[i]["REF11"] + "\" ");
                tag.Append(" data-ref02=\"" + LiList.Rows[i]["REF02"] + "\" data-ref12=\"" + LiList.Rows[i]["REF12"] + "\" ");
                tag.Append(" data-ref03=\"" + LiList.Rows[i]["REF03"] + "\" data-ref13=\"" + LiList.Rows[i]["REF13"] + "\" ");
                tag.Append(" data-ref04=\"" + LiList.Rows[i]["REF04"] + "\" data-ref14=\"" + LiList.Rows[i]["REF14"] + "\" ");
                tag.Append(" data-ref05=\"" + LiList.Rows[i]["REF05"] + "\" data-ref15=\"" + LiList.Rows[i]["REF15"] + "\" ");
                tag.Append(" data-ref06=\"" + LiList.Rows[i]["REF06"] + "\" data-ref16=\"" + LiList.Rows[i]["REF16"] + "\" ");
                tag.Append(" data-ref07=\"" + LiList.Rows[i]["REF07"] + "\" data-ref17=\"" + LiList.Rows[i]["REF17"] + "\" ");
                tag.Append(" data-ref08=\"" + LiList.Rows[i]["REF08"] + "\" data-ref18=\"" + LiList.Rows[i]["REF18"] + "\" ");
                tag.Append(" data-ref09=\"" + LiList.Rows[i]["REF09"] + "\" data-ref19=\"" + LiList.Rows[i]["REF19"] + "\" ");
                tag.Append(" data-ref10=\"" + LiList.Rows[i]["REF10"] + "\" data-ref20=\"" + LiList.Rows[i]["REF20"] + "\" ");
                tag.Append(">" + LiList.Rows[i]["Label"] + "</li>");
            }
        }
        catch {

        }
        return tag.ToString();
    }

    public string DatasetToJson(DataSet ds)
    {
        string jsonData = "";
        foreach (DataTable dt in ds.Tables)
        {
            if (dt.Columns.Count == 3
                && dt.Columns[0].ColumnName == "RTNCODE"
                && dt.Columns[0].ColumnName == "ERRMSG"
                && dt.Columns[0].ColumnName == "ERRDEBUG")
            {
                continue;
            }

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            jsSerializer.MaxJsonLength = 999999999;
            Dictionary<string, object> rowData;
            List<Dictionary<string, object>> rowDataList = new List<Dictionary<string, object>>();
            foreach (DataRow row in dt.Rows)
            {
                rowData = new Dictionary<string, object>();
                foreach (DataColumn column in dt.Columns)
                {
                    rowData.Add(column.ColumnName, row[column]);
                }
                rowDataList.Add(rowData);
            }
            if (jsonData == "")
            {
                jsonData = jsSerializer.Serialize(rowDataList);
            }
            else
            {
                jsonData += "▥" + jsSerializer.Serialize(rowDataList);
            }
        }
        return jsonData;
    }
    public string DataTableToJson(DataTable dt)
    {
        string jsonData = "";
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        jsSerializer.MaxJsonLength = 999999999;
        Dictionary<string, object> rowData;
        List<Dictionary<string, object>> rowDataList = new List<Dictionary<string, object>>();
        foreach (DataRow row in dt.Rows)
        {
            rowData = new Dictionary<string, object>();
            foreach (DataColumn column in dt.Columns)
            {
                rowData.Add(column.ColumnName, row[column]);
            }
            rowDataList.Add(rowData);
        }
        jsonData = jsSerializer.Serialize(rowDataList);
        return jsonData;
    }
    public string SplitStart(string content, params string[] sep)
    {
        string[] contentList = content.Split(sep, StringSplitOptions.None);
        return contentList[0];
    }
    public string SplitEnd(string content, params string[] sep)
    {
        string[] contentList = content.Split(sep, StringSplitOptions.None);
        return contentList[contentList.Length - 1];
    }
    public string SplitCenter(string content, string sep1, string sep2)
    {
        string[] contentList = content.Split(new string[] { sep1 }, StringSplitOptions.None);
        if (contentList.Length >= 2)
        {
            content = contentList[1];
        }
        else
        {
            return "";
        }
        return SplitStart(content, sep2);
    }
    public string[] SplitList(string content, params string[] sep)
    {
        string[] contentList = content.Split(sep, StringSplitOptions.None);
        return contentList;
    }
    public string DecodeUnicode(string uniStr)
    {
        uniStr = uniStr.Replace("\\\\u", "\\u");
        StringBuilder sb = new StringBuilder();
        foreach (char c in uniStr)
        {
            if (c > 127)
            {
                string encodedValue = "\\u" + ((int)c).ToString("x4");
                sb.Append(encodedValue);
            }
            else
            {
                sb.Append(c);
            }
        }

        string rtnText = System.Text.RegularExpressions.Regex.Replace(
            sb.ToString(),
            @"\\u(?<Value>[a-zA-Z0-9]{4})",
            m => {
                return ((char)int.Parse(m.Groups["Value"].Value, System.Globalization.NumberStyles.HexNumber)).ToString();
            });

        return rtnText;
    }
}
public class RequestParams
{
    public RequestParams()
    {

    }
    public RequestParams(string name, string value)
    {
        _ParamList.Add(name, value);
    }
    private Dictionary<string, string> _ParamList = new Dictionary<string, string>();
    public void AddParam(string name, string value)
    {
        if (_ParamList.ContainsKey(name))
        {
            _ParamList[name] = value;
        }
        else
        {
            _ParamList.Add(name, value);
        }
    }
    public new string ToString()
    {
        bool isFirst = true;
        StringBuilder sb = new StringBuilder();
        foreach (string name in _ParamList.Keys)
        {
            if (isFirst)
            {
                isFirst = false;
                sb.Append(name + "=" + _ParamList[name]);
            }
            else
            {
                sb.Append("&" + name + "=" + _ParamList[name]);
            }
        }
        return sb.ToString();
    }
    public string ToJson()
    {
        return _ToJson(false, false);
    }
    public string ToJsonArrayIsString()
    {
        return _ToJson(true, false);
    }
    public string ToJsonNoValueQuot()
    {
        return _ToJson(false, true);
    }
    public string ToJsonArrayIsStringNoValueQuot()
    {
        return _ToJson(true, true);
    }
    public string _ToJson(bool arrayIsString, bool notValueQuot)
    {
        bool isFirst = true;
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        foreach (string name in _ParamList.Keys)
        {
            if (isFirst)
            {
                isFirst = false;
                
                if (_ParamList[name].Length > 1 &&(_ParamList[name].Substring(0, 1) == "[" || _ParamList[name].Substring(0, 1) == "{"))
                {
                    if (arrayIsString)
                    {
                        sb.Append("\"" + name + "\":\"" + _ParamList[name] + "\"");
                    }
                    else {
                        sb.Append("\"" + name + "\":" + _ParamList[name] + "");
                    }
                }
                else
                {
                    if(notValueQuot || _ParamList[name] == "null")
                    {
                        sb.Append("\"" + name + "\":" + _ParamList[name] + "");
                    }
                    else
                    {
                        sb.Append("\"" + name + "\":\"" + _ParamList[name] + "\"");
                    }
                }
                
            }
            else
            {
                if (_ParamList[name].Length > 1 && (_ParamList[name].Substring(0, 1) == "[" || _ParamList[name].Substring(0, 1) == "{"))
                {
                    if (arrayIsString)
                    {
                        sb.Append(",\"" + name + "\":\"" + _ParamList[name] + "\"");
                    }
                    else
                    {
                        sb.Append(",\"" + name + "\":" + _ParamList[name] + "");
                    }
                }
                else
                {
                    if (notValueQuot || _ParamList[name] == "null")
                    {
                        sb.Append(",\"" + name + "\":" + _ParamList[name] + "");
                    }
                    else
                    {
                        sb.Append(",\"" + name + "\":\"" + _ParamList[name] + "\"");
                    }
                }
            }
        }
        sb.Append("}");
        return sb.ToString();
    }
    public int Count { get { return _ParamList.Count; } }
}
public class RequestArray
{
    private List<string> _ParamList = new List<string>();
    public void AddParam(string value)
    {
        _ParamList.Add(value);
    }
    public string ToJson()
    {
        bool isFirst = true;
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        foreach (string item in _ParamList)
        {
            if (isFirst)
            {
                isFirst = false;
                sb.Append(item);
            }
            else
            {
                sb.Append("," + item);
            }
        }
        sb.Append("]");
        return sb.ToString();
    }
}