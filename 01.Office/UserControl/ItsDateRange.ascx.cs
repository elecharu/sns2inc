using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Text;

public partial class ItsDateRange : System.Web.UI.UserControl
{
    public string _ID_F = "";
    public string _ID_T = "";
    public new string ID
    {
        set
        {
            _ID_F = value + "_F";
            _ID_T = value + "_T";
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

    public string _FieldFrom = "";
    public string FieldFrom
    {
        set
        {
            _FieldFrom = value;
        }
    }
    public string _FieldTo = "";
    public string FieldTo
    {
        set
        {
            _FieldTo = value;
        }
    }

    public int _InputWidth = 85;
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

    public string _Label = "DateRange";
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

    public string _ValueFrom = System.DateTime.Now.ToString("yyyy-MM-dd");
    public string ValueFrom
    {
        set
        {
            _ValueFrom = value;
        }
    }

    public string _ValueTo = System.DateTime.Now.ToString("yyyy-MM-dd");
    public string ValueTo
    {
        set
        {
            _ValueTo = value;
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