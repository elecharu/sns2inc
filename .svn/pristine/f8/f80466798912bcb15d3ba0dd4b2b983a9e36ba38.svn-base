using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsLabel : System.Web.UI.UserControl
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
    public enum AlignEnums {
        left, right, center
    }

    public string _Align = "left";
    public AlignEnums Align
    {
        set
        {
            this._Align = value.ToString();
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

    public int _Width = -1;
    public int Width
    {
        set
        {
            _Width = value;
        }
    }
    
    public string _Text = "Text";
    public string Text
    {
        set
        {
            _Text = value;
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
    public string _Bold = "false";
    public bool Bold
    {
        set
        {
            this._Bold = value.ToString().ToLower();
        }
    }
    public string _Italic = "false";
    public bool Italic
    {
        set
        {
            this._Italic = value.ToString().ToLower();
        }
    }
    public string _UnderLine = "false";
    public bool UnderLine
    {
        set
        {
            this._UnderLine = value.ToString().ToLower();
        }
    }
    public string _CancelLine = "false";
    public bool CancelLine
    {
        set
        {
            this._CancelLine = value.ToString().ToLower();
        }
    }
    public string _ForeColor = "Black";
    public BasePage.ColorList ForeColor
    {
        set
        {
            this._ForeColor = BasePage.ConvertColor(value);
        }
    }
    public string _BackColor = "Transparent";
    public BasePage.ColorList BackColor
    {
        set
        {
            this._BackColor = BasePage.ConvertColor(value);
        }
    }
    public int _FontSize = 12;
    public int FontSize
    {
        set
        {
            this._FontSize = value;
        }
    }
    public string _Margin = "0px 2px 0px 0px";
    public string Margin
    {
        set
        {
            this._Margin = value;
        }
    }
}