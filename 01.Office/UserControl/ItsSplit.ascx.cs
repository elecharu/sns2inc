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

    public decimal _WidthVbar = 7;
    public decimal WidthVbar
    {
        set
        {
            _WidthVbar = value;
        }
    }

    public decimal _HeightHbar = 7;
    public decimal HeightHbar
    {
        set
        {
            _HeightHbar = value;
        }
    }
    public string _Type = "V";
    public TypeEnums Type
    {
        set
        {
            _Type = value.ToString().Substring(0, 1);
        }
    }
    public bool _Resizeable = true;
    public bool Resizeable
    {
        set
        {
            _Resizeable = value;
        }
    }
}