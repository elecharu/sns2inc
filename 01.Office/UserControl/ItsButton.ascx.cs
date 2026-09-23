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
    public int _TabIndex = 0;
    public int TabIndex
    {
        set
        {
            this._TabIndex = value;
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
            _MarginBottom = value;
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
    public string _BackColorClass = "DefaultButton";
    public string _BackColor = "DefaultButton";
    public BasePage.ColorList BackColor
    {
        set
        {
            this._BackColor = BasePage.ConvertColor(value);
            this._BackColorClass = value.ToString();

            if (_BorderColor == "") _BorderColor = _BackColor;

            if (value.ToString().Contains("CustomButton"))
            {
                this._ForeColor = "#FFFFFF";
                this._BorderColor = "transparent";
            }
            
            
        }
    }
    public string BackColorHex
    {
        set
        {
            _BackColor = value.ToString();
        }
    }
    public string _ForeColor = "#727171";
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
    public string _BorderColor = "silver";
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