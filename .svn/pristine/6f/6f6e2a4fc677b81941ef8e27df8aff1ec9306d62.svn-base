using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsFileManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public enum StyleEnums
    {
        basic, simple
    }
    public string _StyleType = "basic";
    public StyleEnums StyleType
    {
        set
        {
            this._StyleType = value.ToString();
        }
    }
    public enum FloatEnums
    {
        basic, image
    }
    public string _Field = "";
    public string Field
    {
        set
        {
            _Field = value;
        }
    }
    public string _FileType = "basic";
    public FloatEnums FileType
    {
        set
        {
            this._FileType = value.ToString();
        }
    }

    public string _bindImageId = "";
    public string bindImageId
    {
        set
        {
            this._bindImageId = value.ToString();
        }
    }

    public string _Readonly = "false";
    public bool Readonly
    {
        set
        {
            this._Readonly = value.ToString();
        }
    }
    public string _Hidden = "false";
    public bool Hidden
    {
        set
        {
            this._Hidden = value.ToString();
        }
    }
    public string _ID = "";
    public string _ID_FILENAME_VISIBLE = "";
    public string _ID_EX_FILENAME = "";
    public string _ID_FILEKEY_HIDDEN = "";
    public new string ID
    {
        set
        {
            _ID = value;
            _ID_FILENAME_VISIBLE = value + "ex_filename_visible";
            _ID_EX_FILENAME = value + "ex_filename";
            _ID_FILEKEY_HIDDEN = value + "_fileManager_key";
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

    public enum SaveTypeValue
    {
        basic, manual
    }
    public string _SaveType = "basic";
    public SaveTypeValue SaveType
    {
        set
        {
            var val = value.ToString();
            if (val == "basic")
                val = "";
            this._SaveType = val;
        }
    }
}