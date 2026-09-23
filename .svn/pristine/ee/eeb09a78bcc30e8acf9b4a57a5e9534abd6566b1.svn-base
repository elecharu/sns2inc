using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MobileMaster : System.Web.UI.MasterPage
{
    public string title = "";
    public int mail = 0;
    public int appr = 0;
    public int hold = 0;
    public int refs = 0;
    public int myap = 0;
    public int sche = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SESSION_DBADDR"] == null)
        {
            Response.Redirect("/PAGECOM/PORTAL/index.aspx");
        }
        else
        {
            try
            {
                ItsMaria maria = new ItsMaria("COMSESSION", "CNT");
                maria.AddParam("CALLEMP", Session["SESSION_USERID"]);
                DataSet ds = maria.CallProc();
                if (maria.IsError)
                {
                    string msg = @"
                                <script>
                                    alert('" + maria.ErrMessage + @"');
                                </script>";
                    Response.Write(msg);
                }
                else
                {
                    mail = Convert.ToInt32(ds.Tables[0].Rows[0]["CNT"]);
                    appr = Convert.ToInt32(ds.Tables[1].Rows[0]["CNT"]);
                    hold = Convert.ToInt32(ds.Tables[2].Rows[0]["CNT"]);
                    refs = Convert.ToInt32(ds.Tables[3].Rows[0]["CNT"]);
                    myap = Convert.ToInt32(ds.Tables[4].Rows[0]["CNT"]);
                    sche = Convert.ToInt32(ds.Tables[5].Rows[0]["CNT"]);
                }
            }
            catch (Exception ee)
            {
                mail = 9;
                appr = 9;
                hold = 9;
                refs = 9;
                sche = 9;
                string msg = @"
                                
                                    alert('" + ee.Message.ToString() + @"');
                                ";
                Response.Write(msg);
            }
        }
    }
}
