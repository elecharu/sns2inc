using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsButton : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (_BorderColor == "")
        {
            _BorderColor = _BackColor;
        }
    }

    public string _FaIcon = "";
    public string FaIcon
    {
        set
        {
            if (value.IndexOf("fa ") > -1)
            {
                _FaIcon = value;
            }
            else
            {
                _FaIcon = "fa " + value.Trim().ToLower();
            }
        }
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
    public string _Disabled = "false";
    public string DisabledCls = "";
    public bool Disabled
    {
        set
        {
            this._Disabled = value.ToString().ToLower();
            if(value.ToString().ToLower() == "true")
            {
                DisabledCls = "ItsButton_disabled";
            }
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
    public string _Loading = "true";
    public bool Loading
    {
        set
        {
            this._Loading = value.ToString().ToLower();
        }
    }

    public string _Margin = "";
    public string Margin
    {
        set
        {
            this._Margin = value.ToString().ToLower();
        }
    }
    public string _Margin_Bottom = "";
    public string Margin_Bottom
    {
        set
        {
            this._Margin_Bottom = value.ToString().ToLower();
        }
    }
    public string _Margin_Top = "";
    public string Margin_Top
    {
        set
        {
            this._Margin_Top = value.ToString().ToLower();
        }
    }
    public string _Margin_Left = "";
    public string Margin_Left
    {
        set
        {
            this._Margin_Left = value.ToString().ToLower();
        }
    }
    public string _Margin_Right = "";
    public string Margin_Right
    {
        set
        {
            this._Margin_Right = value.ToString().ToLower();
        }
    }
    public string _Width = "";
    public string Width
    {
        set
        {
            this._Width = value;
        }
    }
    public string _Height = "";
    public string Height
    {
        set
        {
            this._Height = value;
        }
    }
    public string _BackColor = "#2B579A";
    public BasePage.ColorList BackColor
    {
        set
        {
            this._BackColor = BasePage.ConvertColor(value);
            if (_BorderColor == "") _BorderColor = _BackColor;
        }
    }
    public string BackColorHex
    {
        set
        {
            _BackColor = value.ToString();
        }
    }
    public string _ForeColor = "white";
    public BasePage.ColorList ForeColor
    {
        set
        {
            _ForeColor = BasePage.ConvertColor(value);
        }
    }
    public string ForeColorHex
    {
        set
        {
            _ForeColor = value.ToString();
        }
    }
    public string _BorderColor = "";
    public BasePage.ColorList BorderColor
    {
        set
        {
            this._BorderColor = BasePage.ConvertColor(value);
        }
    }
    public string BorderColorHex
    {
        set
        {
            _BorderColor = value.ToString();
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

    public string _Label = "";
    public string Label
    {
        set
        {
            _Label = value;
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
}