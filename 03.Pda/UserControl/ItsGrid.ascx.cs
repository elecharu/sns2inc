using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

public partial class ItsGrid : System.Web.UI.UserControl
{
    public string _ID = "";
    public new string ID
    {
        set
        {
            _ID = value;
        }
    }

    public enum FloatEnums
    {
        left, right
    }

    public string _Float = "left";
    public FloatEnums Float
    {
        set
        {
            this._Float = value.ToString();
        }
    }
    public string _Height = "";
    public string Height
    {
        set
        {
            _Height = value;
        }
    }
}