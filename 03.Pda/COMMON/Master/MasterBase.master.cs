using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterBase : System.Web.UI.MasterPage
{
    public string srcVersion = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BasePage page = new BasePage();
        srcVersion = page.getSrcVersion();
    }
}
