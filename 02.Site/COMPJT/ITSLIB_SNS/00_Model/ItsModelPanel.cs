using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Data;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.PivotGrid;

public class ItsModelPanel : DataTable
{
    public DependencyObject TargetPanel = null;
    public delegate void DelegateValueChange(string fieldName);
    private event DelegateValueChange _EventValueChanged;
    public event DelegateValueChange EventValueChanged
    {
        add
        {
            try
            {
                _EventValueChanged -= value;
            }
            catch { }
            _EventValueChanged += value;
        }
        remove
        {
            _EventValueChanged -= value;
        }
    }

    public ItsModelPanel()
    {
        this.DefaultView.ListChanged += DefaultView_ListChanged;
        this.InitData();
    }

    private void DefaultView_ListChanged(object sender, ListChangedEventArgs e)
    {
        if (_EventValueChanged != null && e != null && e.PropertyDescriptor != null)
        {
            string fieldName = e.PropertyDescriptor.Name;
            _EventValueChanged(fieldName);
        }
    }

    private Dictionary<string, ITSLIB.Combo> _COMBO_LIST = new Dictionary<string, ITSLIB.Combo>();

    private Dictionary<string, object> _DefaultValues = new Dictionary<string, object>();
    private Dictionary<string, ItsEnums.FieldTypes> _FieldTypes = new Dictionary<string, ItsEnums.FieldTypes>();
    private Dictionary<string, string> _POP_CODE = new Dictionary<string, string>();
    private Dictionary<string, string> _POP_NAME = new Dictionary<string, string>();
    public Dictionary<string, string> _GPCD = new Dictionary<string, string>();
    public Dictionary<string, string> _REF01 = new Dictionary<string, string>();
    public Dictionary<string, string> _REF02 = new Dictionary<string, string>();
    public Dictionary<string, string> _REF03 = new Dictionary<string, string>();
    public Dictionary<string, string> _REF04 = new Dictionary<string, string>();
    public Dictionary<string, string> _REF05 = new Dictionary<string, string>();
    public void Binding(DependencyObject panel)
    {
        _SetField(panel);
        (panel as FrameworkElement).DataContext = this;
        this.TargetPanel = panel;
        if (panel is ITSLIB.WrapContent) (panel as ITSLIB.WrapContent).ModelPanel = this;
        else if (panel is ITSLIB.StackContent) (panel as ITSLIB.StackContent).ModelPanel = this;
        else if (panel is ITSLIB.PopContent) (panel as ITSLIB.PopContent).ModelPanel = this;
        else if (panel is ITSLIB.EditContent) (panel as ITSLIB.EditContent).ModelPanel = this;
        else if (panel is ITSLIB.DockContent) (panel as ITSLIB.DockContent).ModelPanel = this;
        else if (panel is ITSLIB.CanvasContent) (panel as ITSLIB.CanvasContent).ModelPanel = this;
    }

    private bool _IsBinding(FrameworkElement panel)
    {
        if (
            ((panel is ITSLIB.WrapContent) && ((panel as ITSLIB.WrapContent).ModelPanel != null))
            || ((panel is ITSLIB.StackContent) && ((panel as ITSLIB.StackContent).ModelPanel != null))
            || ((panel is ITSLIB.PopContent) && ((panel as ITSLIB.PopContent).ModelPanel != null))
            || ((panel is ITSLIB.EditContent) && ((panel as ITSLIB.EditContent).ModelPanel != null))
            || ((panel is ITSLIB.DockContent) && ((panel as ITSLIB.DockContent).ModelPanel != null))
            || ((panel is ITSLIB.CanvasContent) && ((panel as ITSLIB.CanvasContent).ModelPanel != null))
        )
        {
            return true;
        }
        return false;
    }

    private void _SetField(DependencyObject panel)
    {
        FrameworkElement panelElement = panel as FrameworkElement;
        if (panelElement != null && _IsBinding(panelElement))
        {
            MessageBox.Show("_SetField -> DataContext Already Binding");
            return;
        }

        int count = VisualTreeHelper.GetChildrenCount(panel);
        for (int i = 0; i < count; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(panel, i);
            if (child is ITSLIB.Text)
            {
                string fieldName = BindingOperations.GetBinding(child, ITSLIB.Text.ValueProperty).Path.Path;
                this.FieldType(fieldName, ItsEnums.FieldTypes.String);
                (child as ITSLIB.Text).ModelPanel = this;
            }
            if (child is ITSLIB.Combo)
            {
                string fieldName = BindingOperations.GetBinding(child, ITSLIB.Combo.ValueProperty).Path.Path;
                this.FieldType(fieldName, ItsEnums.FieldTypes.String);
                (child as ITSLIB.Combo).ModelPanel = this;

                if (!_COMBO_LIST.ContainsKey(fieldName))
                {
                    _COMBO_LIST.Add(fieldName, child as ITSLIB.Combo);
                    _GPCD.Add(fieldName, (child as ITSLIB.Combo).GPCD);
                }
            }
            else if (child is ITSLIB.Date)
            {
                string fieldName = BindingOperations.GetBinding(child, ITSLIB.Date.ValueProperty).Path.Path;
                this.FieldType(fieldName, ItsEnums.FieldTypes.Date);
                (child as ITSLIB.Date).ModelPanel = this;
            }
            else if (child is ITSLIB.Time)
            {
                string fieldName = BindingOperations.GetBinding(child, ITSLIB.Time.ValueProperty).Path.Path;
                this.FieldType(fieldName, ItsEnums.FieldTypes.Time);
                (child as ITSLIB.Time).ModelPanel = this;
            }
            else if (child is ITSLIB.Check)
            {
                string fieldName = BindingOperations.GetBinding(child, ITSLIB.Check.ValueProperty).Path.Path;
                this.FieldType(fieldName, ItsEnums.FieldTypes.Bool);
                (child as ITSLIB.Check).ModelPanel = this;
            }
            else if (child is ITSLIB.OnOff)
            {
                string fieldName = BindingOperations.GetBinding(child, ITSLIB.OnOff.ValueProperty).Path.Path;
                this.FieldType(fieldName, ItsEnums.FieldTypes.Bool);
                (child as ITSLIB.OnOff).ModelPanel = this;
            }
            else if (child is ITSLIB.Number)
            {
                string fieldName = BindingOperations.GetBinding(child, ITSLIB.Number.ValueProperty).Path.Path;
                this.FieldType(fieldName, ItsEnums.FieldTypes.Decimal);
                (child as ITSLIB.Number).ModelPanel = this;
            }
            else if (child is ITSLIB.Pop)
            {
                string fieldName = BindingOperations.GetBinding(child, ITSLIB.Pop.ValueProperty).Path.Path;
                this.FieldType(fieldName, ItsEnums.FieldTypes.Pop);

                ITSLIB.Pop pop = child as ITSLIB.Pop;
                pop.ModelPanel = this;

                this._SetPopGPCD(fieldName, "", "", pop.GPCD, pop.REF01, pop.REF02, pop.REF03, pop.REF04, pop.REF05);

            }
            else if (child is TextBox)
            {
                try
                {
                    string fieldName = BindingOperations.GetBinding(child, TextBox.TextProperty).Path.Path;
                    this.FieldType(fieldName, ItsEnums.FieldTypes.String);
                }
                catch { }
            }
            else if (child is TextBlock)
            {
                try
                {
                    string fieldName = BindingOperations.GetBinding(child, TextBox.TextProperty).Path.Path;
                    this.FieldType(fieldName, ItsEnums.FieldTypes.String);
                }
                catch { }
            }
            else
            {
                FrameworkElement childPanel = child as FrameworkElement;
                if (childPanel != null && childPanel.DataContext == null)
                {
                    if (childPanel is ITSLIB.Grid 
                        || childPanel is TreeListControl
                        || childPanel is PivotGridControl)
                    {
                        continue;
                    }

                    _SetField(childPanel);
                }
            }
        }
    }

    private void _SetPopGPCD(string fieldName, string code, string name, string gpcd, string ref01, string ref02, string ref03, string ref04, string ref05)
    {
        if (!_GPCD.ContainsKey(fieldName))
        {
            _GPCD.Add(fieldName, gpcd);

            if (!_POP_CODE.ContainsKey(fieldName)) _POP_CODE.Add(fieldName, ""); else _POP_CODE[fieldName] = "";
            if (!_POP_NAME.ContainsKey(fieldName)) _POP_NAME.Add(fieldName, ""); else _POP_NAME[fieldName] = "";
            if (!_REF01.ContainsKey(fieldName)) _REF01.Add(fieldName, ref01); else _REF01[fieldName] = ref01;
            if (!_REF02.ContainsKey(fieldName)) _REF02.Add(fieldName, ref02); else _REF02[fieldName] = ref02;
            if (!_REF03.ContainsKey(fieldName)) _REF03.Add(fieldName, ref03); else _REF03[fieldName] = ref03;
            if (!_REF04.ContainsKey(fieldName)) _REF04.Add(fieldName, ref04); else _REF04[fieldName] = ref04;
            if (!_REF05.ContainsKey(fieldName)) _REF05.Add(fieldName, ref05); else _REF05[fieldName] = ref05;
        }
    }

    public void SetRef01(string fieldName, string ref01)
    {
        if (!_GPCD.ContainsKey(fieldName))
        {
            MessageBox.Show("ItsModelPanel -> SetRef01 GPCD is empty");
            return;
        }

        _REF01[fieldName] = ref01;

        if (_COMBO_LIST.ContainsKey(fieldName))
        {
            _COMBO_LIST[fieldName].REF01 = ref01;
        }
    }

    public void SetRef02(string fieldName, string ref02)
    {
        if (!_GPCD.ContainsKey(fieldName))
        {
            MessageBox.Show("ItsModelPanel -> SetRef02 GPCD is empty");
            return;
        }

        _REF02[fieldName] = ref02;

        if (_COMBO_LIST.ContainsKey(fieldName))
        {
            _COMBO_LIST[fieldName].REF02 = ref02;
        }
    }

    public void SetRef03(string fieldName, string ref03)
    {
        if (!_GPCD.ContainsKey(fieldName))
        {
            MessageBox.Show("ItsModelPanel -> SetRef03 GPCD is empty");
            return;
        }

        _REF03[fieldName] = ref03;

        if (_COMBO_LIST.ContainsKey(fieldName))
        {
            _COMBO_LIST[fieldName].REF03 = ref03;
        }
    }

    public void SetRef04(string fieldName, string ref04)
    {
        if (!_GPCD.ContainsKey(fieldName))
        {
            MessageBox.Show("ItsModelPanel -> SetRef04 GPCD is empty");
            return;
        }

        _REF04[fieldName] = ref04;

        if (_COMBO_LIST.ContainsKey(fieldName))
        {
            _COMBO_LIST[fieldName].REF04 = ref04;
        }
    }

    public void SetRef05(string fieldName, string ref05)
    {
        if (!_GPCD.ContainsKey(fieldName))
        {
            MessageBox.Show("ItsModelPanel -> SetRef05 GPCD is empty");
            return;
        }

        _REF05[fieldName] = ref05;

        if (_COMBO_LIST.ContainsKey(fieldName))
        {
            _COMBO_LIST[fieldName].REF05 = ref05;
        }
    }

    public void SetPopInfo(string fieldName, string value)
    {
        if (!_GPCD.ContainsKey(fieldName))
        {
            MessageBox.Show("ItsModelPanel -> SetPopInfo GPCD is empty");
            return;
        }

        StringBuilder query = new StringBuilder();
        query.Append("CALL DC_POP('" + _GPCD[fieldName] + "_INFO', '" + value + "', '");
        query.Append(_REF01[fieldName] + "', '");
        query.Append(_REF02[fieldName] + "', '");
        query.Append(_REF03[fieldName] + "', '");
        query.Append(_REF04[fieldName] + "', '");
        query.Append(_REF05[fieldName] + "');");
        DataTable dt = ItsMaria.Query(query.ToString()).Tables[0];

        string code = ItsData.GetText(dt, 0, "CODE");
        string name = ItsData.GetText(dt, 0, "NAME");

        _POP_CODE[fieldName] = code;
        _POP_NAME[fieldName] = name;
    }

    public string GetPopCode(string fieldName)
    {
        if (!_POP_CODE.ContainsKey(fieldName)) return "";
        else return _POP_CODE[fieldName];
    }

    public string GetPopName(string fieldName)
    {
        if (!_POP_NAME.ContainsKey(fieldName)) return "";
        else return _POP_NAME[fieldName];
    }

    public bool IsPopName(string fieldName)
    {
        if (GetPopName(fieldName) == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void FieldType(string fieldName, ItsEnums.FieldTypes fieldType)
    {
        DataRow row = null;
        if (this.Rows.Count > 0)
        {
            row = this.Copy().Rows[0];
        }
        this.Rows.Clear();

        fieldName = fieldName.ToUpper();
        if (_FieldTypes.ContainsKey(fieldName))
        {
            _FieldTypes[fieldName] = fieldType;
        }
        else
        {
            _FieldTypes.Add(fieldName, fieldType);
        }

        Type type;
        if (fieldType == ItsEnums.FieldTypes.Date)
        {
            type = typeof(string);
            DefaultValue(fieldName, DateTime.Now);
        } 
        else if (fieldType == ItsEnums.FieldTypes.Time)
        {
            type = typeof(string);
            DefaultValue(fieldName, DateTime.Now);
        }
        else if (fieldType == ItsEnums.FieldTypes.Bool)
        {
            type = typeof(bool);
            DefaultValue(fieldName, false);
        }
        else if (fieldType == ItsEnums.FieldTypes.Decimal)
        {
            type = typeof(decimal);
            DefaultValue(fieldName, 0);
        }
        else if (fieldType == ItsEnums.FieldTypes.Pop)
        {
            type = typeof(string);
            DefaultValue(fieldName, "");
        }
        else
        {
            type = typeof(string);
            DefaultValue(fieldName, "");
        }

        if (this.Columns.Contains(fieldName))
        {
            this.Columns.Remove(fieldName);
        }

        this.Columns.Add(fieldName, type);

        if (row != null) this.SetData(row);
    }

    public void DefaultValue(string fieldName, object defaultValue)
    {
        fieldName = fieldName.ToUpper();
        if (_DefaultValues.ContainsKey(fieldName))
        {
            _DefaultValues[fieldName] = defaultValue;
        }
        else
        {
            _DefaultValues.Add(fieldName, defaultValue);
        }
    }

    public object GetValue(string fieldName)
    {
        if (this.TargetPanel == null)
        {
            MessageBox.Show("ItsModelPanel -> Binding Error");
            return "";
        }

        if (this.Rows.Count == 0)
        {
            MessageBox.Show("ItsModelPanel -> RowCount is 0");
            return "";
        }

        fieldName = fieldName.ToUpper();
        if (!this.Columns.Contains(fieldName))
        {
            MessageBox.Show("ItsModelPanel -> GetValue Error : [ " + fieldName + " ]");
            return "";
        }
        if (this.Rows.Count == 0) return "";
        else return this.Rows[0][fieldName.ToUpper()];
    }

    public string GetText(string fieldName)
    {
        object value = GetValue(fieldName);
        if (value.GetType() == typeof(bool))
        {
            if (value.Equals(true))
            {
                return "Y";
            }
            else
            {
                return "N";
            }            
        }
        else
        {
            return value.ToString();
        }
    }

    public decimal GetDecimal(string fieldName)
    {
        try
        {
            return decimal.Parse(GetText(fieldName));
        }
        catch { return 0m; }
    }

    public int GetInt(string fieldName)
    {
        try
        {
            return int.Parse(GetText(fieldName));
        }
        catch { return 0; }
    }

    public string GetYn(string fieldName)
    {
        string value = GetText(fieldName).ToUpper();
        if (value == "Y" || value == "TRUE")
        {
            return "Y";
        }
        else
        {
            return "N";
        }
    }

    public bool GetBool(string fieldName)
    {
        string value = GetText(fieldName).ToUpper();
        if (value == "Y" || value == "TRUE")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetValue(string fieldName, object value)
    {
        if (this.TargetPanel == null)
        {
            MessageBox.Show("ItsModelPanel -> Binding Error");
            return;
        }

        if (this.Rows.Count == 0)
        {
            MessageBox.Show("ItsModelPanel -> RowCount is 0");
            return;
        }

        fieldName = fieldName.ToUpper();
        if (!this.Columns.Contains(fieldName))
        {
            FieldType(fieldName, ItsEnums.FieldTypes.String);
        }

        object oldValue = this.GetValue(fieldName);
        if (oldValue.Equals(value))
        {
            return;
        }

        if (this.Rows.Count > 0)
        {
            try
            {
                this.Rows[0][fieldName] = value;
            }
            catch
            {
                MessageBox.Show("ItsModelPanel -> SetValue Error : [ " + fieldName + " ]");
                return;
            }

            if (_EventValueChanged != null)
            {
                _EventValueChanged(fieldName);
            }
        }
    }

    private List<string> _keyColumns = new List<string>();
    public void AddKey(params string[] fieldName)
    {
        foreach (string key in fieldName)
        {
            _keyColumns.Add(key);
        }
    }

    public string GetKey()
    {
        if (this.Rows.Count == 0) return "";
        string keyValue = "";
        foreach (string key in _keyColumns)
        {
            if (this.Columns.Contains(key))
            {
                keyValue += this.Rows[0][key].ToString();
            }
            else
            {
                this.FieldType(key, ItsEnums.FieldTypes.String);
            }
        }
        return keyValue;
    }

    public void InitData()
    {
        if (this.Rows.Count == 0)
        {
            this.Rows.Add();
        }

        foreach (DataColumn column in this.Columns)
        {
            if (_FieldTypes[column.ColumnName] == ItsEnums.FieldTypes.Date)
            {
                if (_DefaultValues[column.ColumnName].GetType() == typeof(DateTime))
                {
                    this.Rows[0][column.ColumnName] = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    this.Rows[0][column.ColumnName] = _DefaultValues[column.ColumnName];
                }
            }
            else if (_FieldTypes[column.ColumnName] == ItsEnums.FieldTypes.Time)
            {
                if (_DefaultValues[column.ColumnName].GetType() == typeof(DateTime))
                {
                    this.Rows[0][column.ColumnName] = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    this.Rows[0][column.ColumnName] = _DefaultValues[column.ColumnName];
                }
            }
            else if (_FieldTypes[column.ColumnName] == ItsEnums.FieldTypes.Pop)
            {
                if (!_DefaultValues.ContainsKey(column.ColumnName))
                {
                    this._POP_CODE[column.ColumnName] = "";
                    this._POP_NAME[column.ColumnName] = "";
                    this.Rows[0][column.ColumnName] = "";
                }
                else
                {
                    this._POP_CODE[column.ColumnName] = "";
                    this._POP_NAME[column.ColumnName] = "";
                    string defaultValue = _DefaultValues[column.ColumnName].ToString();
                    this.Rows[0][column.ColumnName] = defaultValue;
                }
            }
            else
            {
                if (!_DefaultValues.ContainsKey(column.ColumnName))
                {
                    this.Rows[0][column.ColumnName] = "";
                }
                else
                {
                    this.Rows[0][column.ColumnName] = _DefaultValues[column.ColumnName];
                }
            }            
        }
    }

    public void SetData(DataTable dt)
    {
        if (dt.Rows.Count > 0) SetData(dt.Rows[0]);
    }

    public void SetData(DataRow row)
    {
        if (row == null) return;
        DataTable dt = row.Table;
        foreach (DataColumn column in dt.Columns)
        {
            string fieldName = column.ColumnName.ToUpper();
            if (fieldName.Replace(" ", "").IndexOf("GPCD('") == -1 && !this.Columns.Contains(fieldName))
            {
                this.Rows.Clear();

                if (column.DataType == typeof(decimal) || column.DataType == typeof(int)
                    || column.DataType == typeof(float) || column.DataType == typeof(double))
                {
                    this.FieldType(fieldName, ItsEnums.FieldTypes.Decimal);
                }
                else if (column.DataType == typeof(bool))
                {
                    this.FieldType(fieldName, ItsEnums.FieldTypes.Bool);
                }
                else 
                {
                    if (row[column.ColumnName].ToString() == "Y" || row[column.ColumnName].ToString() == "N")
                    {
                        this.FieldType(fieldName, ItsEnums.FieldTypes.Bool);
                    }
                    else
                    {
                        this.FieldType(fieldName, ItsEnums.FieldTypes.String);
                    }
                }
            }
        }

        InitData();

        foreach (DataColumn column in dt.Columns)
        {
            string fieldName = column.ColumnName.ToUpper();
            if (this.Columns.Contains(fieldName))
            {
                if (this.Columns[fieldName].DataType == typeof(bool))
                {
                    if (row[column.ColumnName].ToString() == "Y")
                    {
                        this.Rows[0][fieldName] = true;
                    }
                    else
                    {
                        this.Rows[0][fieldName] = false;
                    }
                }
                else
                {
                    try
                    {
                        this.Rows[0][fieldName] = row[column.ColumnName];
                    }
                    catch
                    {
                        MessageBox.Show("ItsModelPanel -> SetData Error : [ " + fieldName + " ], [ " + row[column.ColumnName].ToString() + " ]");
                    }
                }
            }
        }

        if (this.TargetPanel != null)
        {
            (this.TargetPanel as FrameworkElement).DataContext = this.DefaultView[0];
        }
    }
}
