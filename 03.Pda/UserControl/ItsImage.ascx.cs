using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsImage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public string _ID = "";
    public new string ID
    {
        set
        {
            _ID = value;
        }
    }
    public string _WIDTH = "100";
    public string Width
    {
        set
        {
            _WIDTH = value;
        }
    }
    public string _HEIGHT = "100";
    public string Height
    {
        set
        {
            _HEIGHT = value;
        }
    }
    public string _SCROLL = "false";
    public bool Scroll
    {
        set
        {
            _SCROLL = value.ToString().ToLower();
        }
    }
    //public string _Src = "V";
    //public TypeEnums Type
    //{
    //    set
    //    {
    //        _Type = value.ToString().Substring(0, 1);
    //    }
    //}
}