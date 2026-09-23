using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Find : BasePage
{
    public DataTable LiList = new DataTable();
    public string[] _TITLE_LIST;
    public string[] _WIDTH_LIST;
    protected void Page_Load(object sender, EventArgs e)
    {
        _TITLE_LIST = Request["TITLE"].Split(new string[] { "»" }, StringSplitOptions.None);
        _WIDTH_LIST = Request["WIDTH"].Split(new string[] { "»" }, StringSplitOptions.None);
        string Limit = Request["LIMIT"];
        if (Limit == "") Limit = "100";



        ItsMaria maria = new ItsMaria(Request["PROC"], " ");
        maria.AddParam("GPCD", Request["GPCD"] + "_LIST");
        maria.AddParam("KEYWORD", Request["KEYWORD"]);
        maria.AddParam("LIMIT", Request["LIMIT"]);
        maria.AddParam("REF01", Request["REF01"]);
        maria.AddParam("REF02", Request["REF02"]);
        maria.AddParam("REF03", Request["REF03"]);
        maria.AddParam("REF04", Request["REF04"]);
        maria.AddParam("REF05", Request["REF05"]);
        maria.AddParam("REF06", Request["REF06"]);
        maria.AddParam("REF07", Request["REF07"]);
        maria.AddParam("REF08", Request["REF08"]);
        maria.AddParam("REF09", Request["REF09"]);
        maria.AddParam("REF10", Request["REF10"]);
        LiList = maria.CallProc(this.ConnStringCust, 120).Tables[0];
    }
}