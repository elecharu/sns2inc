using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrPage : BasePage
{
    public string errMsg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        errMsg = GetRequest("errMsg");
    }
}