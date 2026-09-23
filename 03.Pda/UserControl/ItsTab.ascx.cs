using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

[ParseChildren(false)]
public partial class ItsTab : System.Web.UI.UserControl, ITextControl
{
    public string _ID = "";
    public new string ID
    {
        set
        {
            _ID = value;
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