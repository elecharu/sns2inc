using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsNum : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public enum FloatEnums {
        left, right
    }

    public int _DecimalPoint = 0;
    public int DecimalPoint
    {
        set
        {
            _DecimalPoint = value;
        }
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

    public string _Field = "";
    public string Field
    {
        set
        {
            _Field = value;
        }
    }

    public int _InputWidth = 163;
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

    public string _Label = "Num";
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

    public string _Value = "";
    public string Value
    {
        set
        {
            _Value = value;
        }
    }
    public decimal _MinValue = 0;
    public decimal MinValue
    {
        set
        {
            _MinValue = value;
        }
    }
    public decimal _MaxValue = 999999999999;
    public decimal MaxValue
    {
        set
        {
            _MaxValue = value;
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

    public int _PaddingRWidth = 28;
    public int PaddingRWidth
    {
        set
        {
            _PaddingRWidth = value;
        }
    }

    public int _ButtonWidth = 22;
    public int ButtonWidth
    {
        set
        {
            _ButtonWidth = value;
        }
    }

    public int _MarginRight = 2;
    public int MarginRight
    {
        set
        {
            _MarginRight = value;
        }
    }

    public string _ButtonBorder = "1px solid silver";

    public bool _TriggerButton = true;
    public bool TriggerButton
    {
        set
        {
            _TriggerButton = value;
            if (value == false)
            {
                _ButtonWidth = 0;
                _InputWidth = _InputWidth + 22;
                _PaddingRWidth = 6;
                _ButtonBorder = "none";
                _MarginRight = 24;
            }
        }
    }
}