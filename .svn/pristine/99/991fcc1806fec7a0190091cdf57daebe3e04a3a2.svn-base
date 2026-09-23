using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

[ParseChildren(false)]
public partial class ItsPop : System.Web.UI.UserControl
{
    public string _Type = "common";
    public enum PopType
    {
        common, add
    }
    public PopType Type
    {
        set
        {
            _Type = value.ToString();
        }
    }
    public string _ID = "";
    public string _AddID = "";
    public string _AddBtnName = "저장";
    public string _CancelID = "";
    public string _CancelBtnName = "취소";
    public new string ID
    {
        set
        {
            _ID = value;
            _AddID = value + "_ItsPopADD";
            _CancelID = value + "_ItsPopCANCEL";
        }
    }
    public string AddBtnName
    {
        set
        {
            _AddBtnName = value;
        }
    }
    public string CancelBtnName
    {
        set
        {
            _CancelBtnName = value;
        }
    }

    public string _Title = "";
    public string Title
    {
        set
        {
            _Title = value;
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

    public int _Height = -1;
    public int Height
    {
        set
        {
            _Height = value;
        }
    }

    public string _Modal = "true";
    public bool Modal
    {
        set
        {
            this._Modal = value.ToString().ToLower();
        }
    }
    public string _Resizable = "false";
    public bool Resizable
    {
        set
        {
            this._Resizable = value.ToString().ToLower();
        }
    }
    [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
    public virtual string Text
    {
        get
        {
            object obj = this.ViewState["Text"];
            if (obj != null)
            {
                return (string)obj;
            }
            return string.Empty;
        }
        set
        {
            if (this.HasControls())
            {
                this.Controls.Clear();
            }
            this.ViewState["Text"] = value;
        }
    }

    protected override void AddParsedSubObject(object obj)
    {
        if (obj is LiteralControl)
        {
            HtmlContent.Append(((LiteralControl)obj).Text);
            this.Text = HtmlContent.ToString();
        }
        else
        {
            if (obj != null)
            {
                HtmlContent.Append(GetControlHtml(obj as Control));
                this.Text = HtmlContent.ToString();
            }
        }
    }
    protected StringBuilder HtmlContent = new StringBuilder();
    protected string GetControlHtml(Control ctl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter tw = new StringWriter();
        HtmlTextWriter writer = new HtmlTextWriter(tw);
        ctl.RenderControl(writer);
        sb.Append(writer.InnerWriter.ToString());
        return sb.ToString();
    }
}