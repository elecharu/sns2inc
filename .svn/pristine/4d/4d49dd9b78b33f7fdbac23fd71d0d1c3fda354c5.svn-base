using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsDisplay : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public enum FloatEnums {
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

    public string _ID = "";
    public new string ID
    {
        set
        {
            _ID = value;
        }
    }

    public int _InputWidth = 185;
    public int InputWidth
    {
        set
        {
            _InputWidth = value;
        }
    }

    public int _LabelWidth = 90;
    public int LabelWidth
    {
        set
        {
            _LabelWidth = value;
        }
    }

    public bool _HiddenLabel = false;
    public bool HiddenLabel
    {
        set
        {
            _HiddenLabel = value;
            if (value == true)
            {
                _LabelWidth = 0;
                _InputWidth = _InputWidth + 80;
                _Label = "";
            }
        }
    }

    public string _Label = "Text";
    public string Label
    {
        set
        {
            if (_HiddenLabel == true)
            {
                _Label = "";
            }
            else
            {
                _Label = value;
            }
        }
    }

    public string _Field = "";
    public string Field
    {
        set
        {
            _Field = value;
        }
    }

    public string _Value = "";
    public string Value
    {
        set
        {
            _Value = value;
        }
    }

    public string _Hidden = "false";
    public bool Hidden
    {
        set
        {
            this._Hidden = value.ToString().ToLower();
        }
    }
}