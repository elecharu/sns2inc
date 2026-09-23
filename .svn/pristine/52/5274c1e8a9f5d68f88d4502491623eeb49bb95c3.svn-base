using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ItsTaxFileManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public enum FloatEnums {
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
    public string _ID_FIMENAME_VISIBLE = "";
    public string _ID_EX_FILENAME = "";
    public string _ID_FIMEKEY_HIDDEN = "";
    public string _ID_EX_FILEPATH = "";
    public string _ID_COMPREGNO = "";
    public new string ID
    {
        set
        {
            _ID = value;
            _ID_FIMENAME_VISIBLE = value + "ex_filename_visible";
            _ID_EX_FILENAME = value + "ex_filename";
            _ID_FIMEKEY_HIDDEN = value + "_fileManger_key";
            _ID_EX_FILEPATH = value + "ex_filepath";
            _ID_COMPREGNO = value + "_compregno";
        }
    }
    public string _Type = "";
    public string Type
    {
        set
        {
            _Type = value;
        }
    }
}