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

public partial class Main : BasePage
{
    public DataTable pkgList = new DataTable();
    public DataTable cateList = new DataTable();
    public DataTable menuList = new DataTable();
    public DataTable myMenuList = new DataTable();
    public DataTable hisMenuList = new DataTable();
    // public DataTable bdvList = new DataTable();
    public string MenuJson = "";
    public string UseMenuJson = "";
    public string myMenuTab = "";
    public string loginUser = "Guest";
    public string UserID = "";
    public string emailAddr = "";
    public string alertYn = "N";

    protected void Page_Load(object sender, EventArgs e)
    {
        string centerYn = "Y";

        if(GetSession("SESSION_USERID") == null || GetSession("SESSION_USERID") == "") {
            Response.Redirect(string.Format("../PORTAL/index.aspx"));
            return;
        }
        loginUser = GetSession("SESSION_USERNM");
        UserID = GetSession("SESSION_USERID");

        ItsMaria maria = new ItsMaria("WEBSYSMAIN", "LIST_MENU_TAB");
        maria.AddParam("SESSION_USERID", GetSession("SESSION_USERID"));
        maria.AddParam("CALLIP", Request.UserHostAddress);
        try
        {
            DataSet ds;
            if (centerYn == "Y")
            {
                ds = maria.CallProc(maria.ConnString, 120);
            }
            else
            {
                ds = maria.CallProc(this.ConnStringCust, 120);
            }

            MenuJson = DataTableToJson(ds.Tables[0]);
            UseMenuJson = DataTableToJson(ds.Tables[1]);
            myMenuList = ds.Tables[2];

            try {
                setSrcVersion(ds.Tables[3].Rows[0]["SRCVERSION"].ToString());
                setUserFontSize(ds.Tables[3].Rows[0]["FONTSIZE"].ToString());
                alertYn = ds.Tables[3].Rows[0]["ALERTYN"].ToString();
            }
            catch { };

            // 마이 메뉴 중 별표 한 것은 미리 열어 놓기
            StringBuilder topmenu = new StringBuilder();
            for (int i = 0; i < myMenuList.Rows.Count; i++)
            {
                topmenu.AppendLine("<div>");
                topmenu.AppendLine("<a href=\"#\" data-prgcd=\"" + myMenuList.Rows[i]["PRGCD"].ToString() + "\" data-prgnm=\"" + myMenuList.Rows[i]["MENUNM"].ToString() + "\" data-menupath=\"" + myMenuList.Rows[i]["MENUPATH"].ToString() + "\" >");
                //topmenu.AppendLine("<i class=\"fa fa-star\" style=\"color:gold; font-size:12px;\"></i>");
                topmenu.AppendLine(myMenuList.Rows[i]["MENUNM"].ToString());
                topmenu.AppendLine("</a>");
                topmenu.AppendLine("<div></div>");
                topmenu.AppendLine("</div>");
            }
            
            myMenuTab = topmenu.ToString();
        }
        catch (Exception ex)
        {
            // 에러 발생시 로그인 페이지로 이동
            Response.Redirect(string.Format("../PORTAL/index.aspx"));
        }
    }
}