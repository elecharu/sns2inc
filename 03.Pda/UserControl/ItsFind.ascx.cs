using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Text;

public partial class ItsFind : System.Web.UI.UserControl
{
    public string GridField = "";
    public string GridTitle = "";
    public string GridWidth = "";
    public string GridLength = "1";
    public string _TAG_HEAD = "";
    public string _TAG_LIST = "";
    public string _GPCD = "";
    
    public string GPCD
    {
        set
        {
            _GPCD = value;

            if (_GPCD == "GPCD")
            {
                GridField = "_GridField_";
                GridTitle = "_GridTitle_";
                GridWidth = "_GridWidth_";
                GridLength = "_GridLength_";
                _TAG_HEAD = "_TAG_HEAD_";
                return;
            }

            BasePage page = new BasePage();
            page.InitSession();

            _TAG_HEAD = page.GetFindHead(_GPCD, _PROC, ref GridField, ref GridTitle, ref GridWidth, ref GridLength);
        }
    }
    public string _PROC = "DC_FIND";
    public string PROC
    {
        set
        {
            _PROC = value;
            if(_PROC != "DC_FIND")
            {
                BasePage page = new BasePage();
                page.InitSession();

                _TAG_HEAD = page.GetFindHead(_GPCD, _PROC, ref GridField, ref GridTitle, ref GridWidth, ref GridLength);
            }
        }
    }
    public string _REF01 = "";
    public string REF01
    {
        set
        {
            _REF01 = value;
        }
    }
    public string _REF02 = "";
    public string REF02
    {
        set
        {
            _REF02 = value;
        }
    }
    public string _REF03 = "";
    public string REF03
    {
        set
        {
            _REF03 = value;
        }
    }
    public string _REF04 = "";
    public string REF04
    {
        set
        {
            _REF04 = value;
        }
    }
    public string _REF05 = "";
    public string REF05
    {
        set
        {
            _REF05 = value;
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

    public string _Field = "";
    public string Field
    {
        set
        {
            _Field = value;
        }
    }

    public int _NameWidth = 128;
    public int NameWidth
    {
        set
        {
            _NameWidth = value;
        }
    }
    public int _InputWidth = 35;
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

    public string _Label = "Find";
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

    public bool _Required = false;
    public bool Required
    {
        set
        {
            _Required = value;
        }
    }
}