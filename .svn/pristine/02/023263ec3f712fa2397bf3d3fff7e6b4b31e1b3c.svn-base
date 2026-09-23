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

    public int _InputWidth = 110;
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


    public bool _TriggerButton = false;
    public bool _Rpad = false;
    public bool TriggerButton
    {
        set
        {
            _TriggerButton = value;
            if (value == false)
            {
                _Rpad = true;
            }
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
}