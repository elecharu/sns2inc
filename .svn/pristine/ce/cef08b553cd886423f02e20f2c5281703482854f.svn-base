using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GetTag : BasePage
{
    public string TYPE = "";
    public string _FIND_TAG_HEAD = "";
    public string _FIND_GridField = "";
    public string _FIND_GridTitle = "";
    public string _FIND_GridWidth = "";
    public string _FIND_GridLength = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            TYPE = Request["TYPE"].ToString();
        }
        catch { }

        if (TYPE == "FIND_HEAD")
        {
            _FIND_TAG_HEAD = this.GetFindHead(Request["GPCD"].ToString(), ref _FIND_GridField, ref _FIND_GridTitle, ref _FIND_GridWidth, ref _FIND_GridLength);
        }
    }
}