using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

[ParseChildren(false)]
public partial class ItsDiv : System.Web.UI.UserControl, ITextControl
{
    public string _ID = "";
    public new string ID
    {
        set
        {
            _ID = value;
        }
    }
    public string _TabTitle = "";
    public string TabTitle
    {
        set
        {
            _TabTitle = value;
        }
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

    public enum TypeEnums
    {
        SearchPanel,
        BasicBlock, BasicFloat,
        BorderBlock, BorderFloat,
        SplitLeft, SplitRight, SplitTop, SplitDown, SplitSingle
    }

    public string _Type = "BasicBlock";
    public TypeEnums Type
    {
        set
        {
            this._Type = value.ToString();
        }
    }
    public string _LeftPosPc = null;
    public string LeftPosPc
    {
        set
        {
            _LeftPosPc = value.ToString();
        }
    }
    public string _LeftWidthPc = "";
    public string LeftWidthPc
    {
        set
        {
            _LeftWidthPc = value;
        }
    }
    public string _RightWidthPc = "";
    public string RightWidthPc
    {
        set
        {
            _RightWidthPc = value;
        }
    }
    public string _TopHeightPc = "";
    public string TopHeightPc
    {
        set
        {
            _TopHeightPc = value;
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
    public string _BackColor = "White";
    public BasePage.ColorList BackColor
    {
        set
        {
            this._BackColor = BasePage.ConvertColor(value);
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

    public string _Tooltip = "";
    public string Tooltip
    {
        set
        {
            _Tooltip = value;
        }
    }
}