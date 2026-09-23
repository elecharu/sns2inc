using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsCheck : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

    public string _ReadOnly = "false";
    public bool ReadOnly
    {
        set
        {
            this._ReadOnly = value.ToString().ToLower();
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
    public string _ID = "";
    public new string ID
    {
        set
        {
            _ID = value;
        }
    }

    public int _InputWidth = 0;
    public int InputWidth
    {
        set
        {
            _InputWidth = value;
        }
    }

    public int _LabelWidth = -1;
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
                if (_InputWidth > 0)
                {
                    _InputWidth = _InputWidth + 80;
                }
                _Label = "";
            }
        }
    }

    public string _Label = "";
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

    public string _Value = "Y";
    public string Value
    {
        set
        {
            _Value = value;
        }
    }

    public bool _Required = false;
    public bool Required
    {
        set
        {
            _Required = value;
        }
    }

    public int _MarginLeft = -1;
    public int MarginLeft
    {
        set
        {
            _MarginLeft = value;
        }
    }

    public int _MarginRight = -1;
    public int MarginRight
    {
        set
        {
            _MarginRight = value;
        }
    }
    public int _MarginTop = -1;
    public int MarginTop
    {
        set
        {
            _MarginTop = value;
        }
    }
    public int _MarginBottom = -1;
    public int MarginBottom
    {
        set
        {
            MarginBottom = value;
        }
    }

    public string _Tooltip = "";
    public string Tooltip
    {
        set
        {
            _Tooltip = value;
        }
    }
    public string _LabelPos = "left";
    public FloatEnums LabelPos
    {
        set
        {
            _LabelPos = value.ToString();
        }
    }

    public enum TypeEnums
    {
        basic, red, green, white, yellow
    }

    public string _Type = "basic";
    public TypeEnums Type
    {
        set
        {
            this._Type = value.ToString();
        }
    }
}