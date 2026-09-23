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
    public string MenuHtml = "";
    public string myMenuTab = "";
    public string emergency_market_info = "";
    public string loginUser = "Guest";

    protected void Page_Load(object sender, EventArgs e)
    {
        string query = "";
        string centerYn = "Y";
        string loginYn = "N";

        if(GetSession("SESSION_USERID") == null || GetSession("SESSION_USERID") == "") {
            Response.Redirect(string.Format("../PORTAL/index.aspx"));
            return;
        }
        loginUser = GetSession("SESSION_USERNM");

        ItsMaria maria = new ItsMaria("WEBSYSMAIN", "LIST_MENU");
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
            
            pkgList = ds.Tables[0];
            cateList = ds.Tables[1];
            menuList = ds.Tables[2];
            myMenuList = ds.Tables[3];
            hisMenuList = ds.Tables[4];
            // bdvList = ds.Tables[5];

            try {
                setSrcVersion(ds.Tables[5].Rows[0]["SRCVERSION"].ToString());
                setUserFontSize(ds.Tables[5].Rows[0]["FONTSIZE"].ToString());
            }
            catch { };

            StringBuilder sb = new StringBuilder();

            // 마이메뉴
            sb.AppendLine("<li class=\"left_list_first_li\">");
            //sb.AppendLine("<i class=\"fa fa-folder-o left_list_first_i miplmain\" aria-hidden=\"true\"></i>");
            sb.AppendLine("<img class=\"left_list_first_i\" src=\"../images/folders.png\">");
            sb.AppendLine("<span class=\"left_list_first_span\">MY MENU</span>");
            sb.AppendLine("<a onclick=\"add_iframe('SYS0000_R02', '../../PAGESYS/SYS0000/SYS0000_R02.aspx', '환경설정', 'N')\"><i class=\"fa fa-cog\" style=\"margin-left:70px;\"></i></a>");
            sb.AppendLine("<ul style=\"display:none;margin-top:10px;\">");
            sb.AppendLine("<li class=\"left_list_second_li\" style=\"display: inline-block;\" title=\"열린 메뉴 탭을 우클릭 하여&#10;my menu에 추가 또는 제거 할 수 있습니다.\">");
            sb.AppendLine("<i class=\"fa fa-folder-o\" style=\" font-size:10px;color:#ffda71;\"></i>");
            sb.AppendLine("<span class=\"left_list_second_span\">MY MENU</span>");
            sb.AppendLine("<ul style=\"\">");
            for (int i = 0; i < myMenuList.Rows.Count; i++)
            {
                string thirdIcon = "fa-star-o";
                if(myMenuList.Rows[i]["HOTYN"].ToString() == "Y")
                {
                    thirdIcon = "fa-star";
                }

                sb.AppendLine("<li class=\"left_list_third_li\">");
                sb.AppendLine("<i class=\"fa " + thirdIcon + "\" style=\"opacity:0.8; color:gold; font-size:12px;\" title=\"별을 클릭하면 항상 탭이 열려있게 됩니다.\" ></i>");
                sb.AppendLine("<a class=\"left_list_third_a\" data-hotyn=\"" + myMenuList.Rows[i]["HOTYN"].ToString() + "\" data-prgcd=\"" + myMenuList.Rows[i]["PRGCD"].ToString() + "\" data-menupath=\"" + myMenuList.Rows[i]["MENUPATH"].ToString() + "\" href='#'>" + myMenuList.Rows[i]["MENUNM"].ToString() + "</a>");
                sb.AppendLine("</li>");
            }
            sb.AppendLine("</ul>");
            sb.AppendLine("</li>");
            sb.AppendLine("<li class=\"left_list_second_li\" style=\"display: inline-block;\" title=\"최근 일주일 간 사용 기록이 있는 프로그램 중&#10;역대 가장 많이 사용한 상위 5개 프로그램입니다.\">");
            sb.AppendLine("<i class=\"fa fa-folder-o\" style=\" font-size:10px;color:#ffda71;\"></i>");
            sb.AppendLine("<span class=\"left_list_second_span\">자주 사용한 메뉴</span>");
            sb.AppendLine("<ul style=\"\">");
            for (int i = 0; i < hisMenuList.Rows.Count; i++)
            {
                sb.AppendLine("<li class=\"left_list_third_li\" title=\"" + hisMenuList.Rows[i]["CNT"].ToString() + "회\">");
                sb.AppendLine("<i class=\"fa fa-angle-right\" style=\"opacity:0.4; font-size:10px;\"></i>");
                sb.AppendLine("<a class=\"left_list_third_a\" data-prgcd=\"" + hisMenuList.Rows[i]["PRGCD"].ToString() + "\" data-menupath=\"" + hisMenuList.Rows[i]["MENUPATH"].ToString() + "\" href='#'>" + hisMenuList.Rows[i]["MENUNM"].ToString() + "</a>");
                sb.AppendLine("</li>");
            }
            sb.AppendLine("</ul>");
            sb.AppendLine("</li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("</li>");

            // 일반메뉴
            for (int i = 0; i < pkgList.Rows.Count; i++) {
                // 대분류
                sb.AppendLine("<li class=\"left_list_first_li\">");
                //sb.AppendLine("<i class=\"fa fa-folder-o left_list_first_i miplmain\" aria-hidden=\"true\"></i>");
                sb.AppendLine("<img class=\"left_list_first_i\" src=\"../images/folders.png\">");
                sb.AppendLine("<span class=\"left_list_first_span\">" + pkgList.Rows[i]["TPNM"].ToString() + "</span>");
                sb.AppendLine("<ul style=\"display:none;margin-top:10px;\">");
                for (int j = 0; j < cateList.Rows.Count; j++) {
                    if(pkgList.Rows[i]["TPCD"].ToString() == cateList.Rows[j]["PKGTP"].ToString() && cateList.Rows[j]["LEVEL"].ToString() == "1") {
                        // 중분류는 여러단계가 될 수 있음
                        sb.AppendLine("<li class=\"left_list_second_li\" style=\"display:none;\">");
                        sb.AppendLine("<i class=\"fa fa-folder-o\" style=\" font-size:10px;color:#ffda71;\"></i>");
                        sb.AppendLine("<span class=\"left_list_second_span\">" + cateList.Rows[j]["CATENM"].ToString() + "</span>");
                        sb.AppendLine("<ul style=\"display:none;\">");
                        for (int j2 = 0; j2 < cateList.Rows.Count; j2++)
                        {
                            if (pkgList.Rows[i]["TPCD"].ToString() == cateList.Rows[j2]["PKGTP"].ToString() && cateList.Rows[j2]["PCATECD"].ToString() == cateList.Rows[j]["CATECD"].ToString())
                            {
                                sb.AppendLine("<li class=\"left_list_second_li \" style=\"display:none;\">");
                                sb.AppendLine("<i class=\"fa fa-folder-o\" style=\"font-size:10px;color:#ffda71;\"></i>");
                                sb.AppendLine("<span class=\"left_list_second_span \">" + cateList.Rows[j2]["CATENM"].ToString() + "</span>");
                                sb.AppendLine("<ul style=\"display:none;\">");
                                for (int k = 0; k < menuList.Rows.Count; k++)
                                {
                                    // 최하위 메뉴 목록
                                    if (pkgList.Rows[i]["TPCD"].ToString() == menuList.Rows[k]["PKGTP"].ToString() && cateList.Rows[j2]["CATECD"].ToString() == menuList.Rows[k]["CATECD"].ToString())
                                    {
                                        sb.AppendLine("<li class=\"left_list_third_li\">");
                                        //sb.AppendLine("<i class=\"fa fa-file \" style=\"opacity:0.4; font-size:10px;\"></i>");
                                        sb.AppendLine("<img src=\"../images/file-o.png\">");
                                        if (menuList.Rows[k]["AUTYN"].ToString() == "Y")
                                        {
                                            sb.AppendLine("<a class=\"left_list_third_a\" data-prgcd=\"" + menuList.Rows[k]["PRGCD"].ToString() + "\" data-menupath=\"" + menuList.Rows[k]["MENUPATH"].ToString() + "\" href='#'>" + menuList.Rows[k]["MENUNM"].ToString() + "</a>");
                                        }
                                        else
                                        {
                                            sb.AppendLine("<a class=\"left_list_third_a\" data-prgcd=\"not_aut\" data-menupath=\"not_aut\" href='#'>" + menuList.Rows[k]["MENUNM"].ToString() + "</a>");
                                        }
                                        sb.AppendLine("</li>");
                                    }
                                }
                                sb.AppendLine("</ul>");
                                sb.AppendLine("</li>");
                            }
                        }
                        //sb.AppendLine("<div style=\"height:4px;\"></div>");
                        for (int k = 0; k < menuList.Rows.Count; k++) {
                            // 최하위 메뉴 목록
                            if(pkgList.Rows[i]["TPCD"].ToString() == menuList.Rows[k]["PKGTP"].ToString() && cateList.Rows[j]["CATECD"].ToString() == menuList.Rows[k]["CATECD"].ToString()) {
                                sb.AppendLine("<li class=\"left_list_third_li\">");
                                //sb.AppendLine("<i class=\"fa fa-file \" style=\"opacity:0.4; font-size:10px;\"></i>");
                                sb.AppendLine("<img src=\"../images/file-o.png\">");
                                if(menuList.Rows[k]["AUTYN"].ToString() == "Y")
                                {
                                    sb.AppendLine("<a class=\"left_list_third_a\" data-prgcd=\"" + menuList.Rows[k]["PRGCD"].ToString() + "\" data-menupath=\"" + menuList.Rows[k]["MENUPATH"].ToString() + "\" href='#'>" + menuList.Rows[k]["MENUNM"].ToString() + "</a>");
                                }
                                else
                                {
                                    sb.AppendLine("<a class=\"left_list_third_a\" data-prgcd=\"not_aut\" data-menupath=\"not_aut\" href='#'>" + menuList.Rows[k]["MENUNM"].ToString() + "</a>");
                                }
                                sb.AppendLine("</li>");
                            }
                        }
                        sb.AppendLine("</ul>");
                        sb.AppendLine("</li>");
                    }
                }
                sb.AppendLine("</ul>");
            }
            MenuHtml = sb.ToString();

            // 마이 메뉴 중 별표 한 것은 미리 열어 놓기
            StringBuilder sb3 = new StringBuilder();
            for (int i = 0; i < myMenuList.Rows.Count; i++)
            {
                if (myMenuList.Rows[i]["HOTYN"].ToString() == "Y")
                {
                    sb3.AppendLine("<li onclick=\"top_menu_click_top5('" + myMenuList.Rows[i]["MENUPATH"].ToString() + "', this)\" class=\"opened_menu\" style=\"display: list-item;\">");
                    sb3.AppendLine("<a href=\"#\" data-prgcd=\"" + myMenuList.Rows[i]["PRGCD"].ToString() + "\" data-prgnm=\"" + myMenuList.Rows[i]["MENUNM"].ToString() + "\" data-menupath=\"" + myMenuList.Rows[i]["MENUPATH"].ToString() + "\" style=\" line-height: 18px;\">");
                    sb3.AppendLine("<i class=\"fa fa-star\" style=\"opacity:0.8; color:gold; font-size:12px;\"></i>");
                    sb3.AppendLine(myMenuList.Rows[i]["MENUNM"].ToString());
                    //sb3.AppendLine("<i class=\"top_menu_close fa fa-times\" onclick=\"remove_iframe(\'" + myMenuList.Rows[i]["MENUPATH"].ToString() + "\')\" aria-hidden=\"true\"></i>");
                    sb3.AppendLine("</a>");
                    sb3.AppendLine("</li>");
                }
            }
            myMenuTab = sb3.ToString();
        }
        catch(Exception ex)
        {
            // 에러 발생시 로그인 페이지로 이동
            Response.Redirect(string.Format("../PORTAL/index.aspx"));
        }
    }
}