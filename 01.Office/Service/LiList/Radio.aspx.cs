using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Radio : BasePage
{
    public DataTable LiList = new DataTable();
    public int LENGTH = 0;
    public string FIELD = "";
    public string NAME = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string gpcd = Request["GPCD"];
        string flag = gpcd.Substring(0, 1);
        try
        {
            LENGTH = int.Parse(Request["LENGTH"]);
        }
        catch (Exception){}
        
        FIELD = Request["FIELD"];
        NAME = Request["NAME"];

        if (flag == "*" || flag == "@")
        {
            gpcd = gpcd.Substring(1);
        }

        ItsMaria maria = new ItsMaria("DC_COMBO", " ");
        maria.AddParam("GPCD", gpcd);
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
        LiList.Columns[0].ColumnName = "Label";
        LiList.Columns[1].ColumnName = "Value";
        if(LiList.Columns.Count >2) LiList.Columns[2].ColumnName = "Tag";
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
            row[2] = "전체";
            LiList.Rows.InsertAt(row, 0);
        }
        else if (flag == "@")
        {
            DataRow row = LiList.NewRow();
            row[0] = "";
            row[1] = "";
            row[2] = "전체";
            LiList.Rows.InsertAt(row, 0);
        }

        if(LENGTH == 0 || LENGTH> LiList.Rows.Count)
        {
            LENGTH = LiList.Rows.Count;
        }

    }
}