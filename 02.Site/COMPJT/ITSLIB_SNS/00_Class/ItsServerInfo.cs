
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Data;

public class ItsServerInfo
{
    private static string _ServerUrl = "";
    public static string ServerUrl
    {
        get
        {
            if (_ServerUrl == "")
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT REF01 FROM COMTYPE ");
                query.AppendLine("WHERE GPCD = 'GLOBAL' AND TPCD = 'SYSURL'");
                DataTable dt = ItsMaria.Query(query.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    _ServerUrl = ItsData.GetText(dt, 0, "REF01");
                }
            }
            return _ServerUrl;
        }
    }
    public static DateTime ServerTime
    {
        get
        {
            return (DateTime)(ItsMaria.Query("SELECT SYSDATE();").Tables[0].Rows[0][0]);
        }
    }
}