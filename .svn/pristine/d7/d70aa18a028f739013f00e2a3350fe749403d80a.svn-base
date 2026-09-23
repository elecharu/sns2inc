using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsSplit : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public enum TypeEnums
    {
        Vertical, Horizon
    }

    public string _Type = "V";
    public TypeEnums Type
    {
        set
        {
            _Type = value.ToString().Substring(0, 1);
        }
    }
}