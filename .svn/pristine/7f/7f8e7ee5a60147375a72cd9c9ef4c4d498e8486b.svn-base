using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DevExpress.Xpf.Grid;
using System.Data;
using System.Collections.Generic;

public static class ItsLang
{
    public static string LangName = "KR";

    public static void AddLangControl(HashSet<DependencyObject> ControlList, DataTable LangTable, string PageName, object obj)
    {
        DependencyObject dobj = obj as DependencyObject;
        if (dobj == null) return;

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dobj); i++)
        {
            FrameworkElement child = VisualTreeHelper.GetChild(dobj, i) as FrameworkElement;
            if (child == null
                || ControlList.Contains(child)
                || child.Language.ToString().ToUpper() == "NONE") continue;

            if (child is ITSLIB.ButtonList)
            {
                continue;
            }
            else if (child is Image)
            {
                continue;
            }
            else if (child is ITSLIB.Button
                || child is ITSLIB.Check
                || child is ITSLIB.Combo
                || child is ITSLIB.Date
                || child is ITSLIB.Number
                || child is ITSLIB.OnOff
                || child is ITSLIB.Pop
                || child is ITSLIB.Text
                || child is ITSLIB.Time)
            {
                ControlList.Add(child);
                continue;
            }
            else if (child is GridControl)
            {
                GridControl grid = child as GridControl;
                foreach (GridColumn column in grid.Columns)
                {
                    ControlList.Add(column);
                }
                continue;
            }
            else if (child is TextBlock)
            {
                ControlList.Add(child);
                continue;
            }
            else if (child is UserControl)
            {
                UserControl uc = child as UserControl;
                if (uc.Content != null && uc.Name.IndexOf("MENU") > -1)
                {
                    ControlList.Add(child);
                    continue;
                }
            }

            AddLangControl(ControlList, LangTable, PageName, child);
        }
    }


    public static void LangPage(HashSet<DependencyObject> ControlList, Dictionary<DependencyObject, string> LangList, DataTable LangTable)
    {
        if (ItsLang.LangName == "KR") return;

        foreach (DependencyObject obj in ControlList)
        {
            if (obj is ITSLIB.Button)
            {
                ITSLIB.Button ctl = obj as ITSLIB.Button;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is ITSLIB.Check)
            {
                ITSLIB.Check ctl = obj as ITSLIB.Check;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is ITSLIB.Combo)
            {
                ITSLIB.Combo ctl = obj as ITSLIB.Combo;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is ITSLIB.Date)
            {
                ITSLIB.Date ctl = obj as ITSLIB.Date;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is ITSLIB.Number)
            {
                ITSLIB.Number ctl = obj as ITSLIB.Number;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is ITSLIB.OnOff)
            {
                ITSLIB.OnOff ctl = obj as ITSLIB.OnOff;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is ITSLIB.Pop)
            {
                ITSLIB.Pop ctl = obj as ITSLIB.Pop;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is ITSLIB.Text)
            {
                ITSLIB.Text ctl = obj as ITSLIB.Text;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is ITSLIB.Time)
            {
                ITSLIB.Time ctl = obj as ITSLIB.Time;
                ctl.Label = LangControl(LangList, LangTable, obj, ctl.Label);
            }
            else if (obj is GridColumn)
            {
                GridColumn ctl = obj as GridColumn;
                ctl.Header = LangControl(LangList, LangTable, obj, ctl.Header.ToString());
            }
            else if (obj is Image)
            {
                continue;
            }
            else if (obj is TextBlock)
            {
                TextBlock ctl = obj as TextBlock;
                ctl.Text = LangControl(LangList, LangTable, obj, ctl.Text);
            }
            else if (obj is UserControl)
            {
                UserControl uc = obj as UserControl;
                if (uc.Content != null && uc.Name.IndexOf("MENU") > -1)
                {
                    uc.Content = LangControl(LangList, LangTable, obj, uc.Content.ToString());
                    uc.FontFamily = new FontFamily("SimSun");
                }
            }
        }
    }

    private static string LangControl(Dictionary<DependencyObject, string> LangList, DataTable LangTable, DependencyObject ctl, string ctlText)
    {
        if (ItsLang.LangName == "KR" || ctlText.Trim() == "") return ctlText;

        string keyText = ctlText.Replace(" ", "");

        string langKey = ctl.GetType().ToString().Replace("System.Windows.Controls.", "").Replace("ITSLIB.", "");
        langKey = langKey + "_" + keyText;

        if (!LangList.ContainsKey(ctl))
        {
            LangList.Add(ctl, langKey);

            DataRow row = LangTable.NewRow();
            row["LANGKEY"] = langKey;
            row["KR"] = ctlText;
            row["EN"] = "";
            row["CN"] = "中华人民共和国";
            row["JP"] = "";
            row["NEW"] = "Y";
            LangTable.Rows.Add(row);
        }

        string langText = ctlText;
        DataRow[] rowList = LangTable.Select("LANGKEY = '" + langKey + "'");
        if (rowList.Length > 0)
        {
            langText = rowList[0][ItsLang.LangName].ToString();
            if (langText.Trim() == "")
            {
                langText = ctlText;
            }
        }
        return langText;
    }

    public static DataTable GetLangTable(string PageName)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("LANGKEY");
        dt.Columns.Add("KR");
        dt.Columns.Add("EN");
        dt.Columns.Add("CN");
        dt.Columns.Add("JP");
        dt.Columns.Add("NEW");

        DataRow row = dt.NewRow();
        row["LANGKEY"] = "TextBlock_조회";
        row["KR"] = "3333";
        row["EN"] = "";
        row["CN"] = "3333";
        row["JP"] = "";
        row["NEW"] = "N";
        dt.Rows.Add(row);

        return dt;
    }

}