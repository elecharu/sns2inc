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
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.PivotGrid;
using System.Dynamic;

public class ItsModelGrid : DataTable
{
    public DependencyObject TargetGrid = null;
    public delegate void DelegateValueChanged(int rowIndex, string fieldName);
    private event DelegateValueChanged _EventValueChanged;
    public event DelegateValueChanged EventValueChanged
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

    public delegate void DelegateRowChanged(int rowIndex);
    private event DelegateRowChanged _EventRowChanged;
    public event DelegateRowChanged EventRowChanged
    {
        add
        {
            try
            {
                _EventRowChanged -= value;
            }
            catch { }
            _EventRowChanged += value;
        }
        remove
        {
            _EventRowChanged -= value;
        }
    }

    public ItsModelGrid()
    {
        this.DefaultView.ListChanged += DefaultView_ListChanged;
    }

    private bool _cancelListChange = false;
    private void DefaultView_ListChanged(object sender, ListChangedEventArgs e)
    {
        if (_cancelListChange)
        {
            _cancelListChange = false;
            return;
        }

        if (e != null && e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null)
        {
            if (e.PropertyDescriptor.Name != "ISCHECKED")
            {
                _cancelListChange = true;
                this.Rows[e.NewIndex]["ISCHECKED"] = true;
                if (_EventValueChanged != null)
                {
                    this._EventValueChanged(e.NewIndex, e.PropertyDescriptor.Name);
                }
            }
        }
    }

    public void SetBackColor(int rowIndex, Color color)
    {
        this.SetValue(rowIndex, "BACKGROUND", color.ToString());
    }

    public void SetForeColor(int rowIndex, Color color)
    {
        this.SetValue(rowIndex, "FOREGROUND", color.ToString());
    }

    public void SetBackColor(int rowIndex, string color)
    {
        this.SetValue(rowIndex, "BACKGROUND", color);
    }

    public void SetForeColor(int rowIndex, string color)
    {
        this.SetValue(rowIndex, "FOREGROUND", color);
    }

    public void ModelChanged(int rowIndex)
    {
        _KeyValue = this.GetKey(rowIndex);
        if (_KeyValue == "") _KeyValue = "__EMPTY__";

        if (_EventRowChanged != null)
        {
            //_EventRowChanged(rowIndex);
            if (!ITSLIB.Grid._IsMouseClick)
            {
                _EventRowChanged(rowIndex);
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

    private string _KeyValue = "__EMPTY__";
    public void SetKey(string key)
    {
        if (key == "") key = "__EMPTY__";
        _KeyValue = key;
    }

    public string CurrentKey
    {
        get
        {
            return _KeyValue;
        }
    }

    public string GetKey(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= this.Rows.Count) return "";
        string keyValue = "";
        foreach(string key in _keyColumns)
        {
            if (this.Columns.Contains(key))
            {
                keyValue += this.Rows[rowIndex][key].ToString();
            }
            else
            {
                CellType(key, ItsEnums.CellTypes.Text);
            }
        }
        return keyValue;
    }

    public string GetKey(DataRow row)
    {
        if (row == null) return "";
        string keyValue = "";
        foreach (string key in _keyColumns)
        {
            if (this.Columns.Contains(key))
            {
                keyValue += row[key].ToString();
            }
            else
            {
                ItsMsgBox.Show("ItsModelGrid -> GetKey : " + key + "컬럼이 존재하지 않습니다.");
            }
        }
        return keyValue;
    }

    public void Binding(DependencyObject grid)
    {
        _SetField(grid);
        TargetGrid = grid;
        CellType("ISCHECKED", ItsEnums.CellTypes.Check);
        CellType("BACKGROUND", ItsEnums.CellTypes.Text);
        CellType("FOREGROUND", ItsEnums.CellTypes.Text);

        if (grid is ITSLIB.Grid) (grid as ITSLIB.Grid).ModelGrid = this;
    }

    public void BindingRow(DependencyObject panel)
    {
        int rowIndex = this.Rows.IndexOf(this.CurrentModel);
        BindingRow(panel, rowIndex);
    }

    public void BindingRow(DependencyObject panel, int rowIndex)
    {
        if (rowIndex == -1 || rowIndex >= this.Rows.Count)
        {
            DataRow row = this.NewRow();
            (panel as FrameworkElement).DataContext = row;
            return;
        }

        DataRowView rowView = this.DefaultView[rowIndex];
        (panel as FrameworkElement).DataContext = rowView;
    }

    private void _SetField(DependencyObject grid)
    {
        ITSLIB.Grid gridControl = grid as ITSLIB.Grid;
        TreeListControl treeGrid = grid as TreeListControl;
        PivotGridControl pivotGrid = grid as PivotGridControl;

        if (gridControl != null)
        {
            foreach(GridColumn gc in gridControl.Columns)
            {
                if (!(gc is ITSLIB.Column)) continue;

                ITSLIB.Column column = gc as ITSLIB.Column;
                if (column.EditSettings is SpinEditSettings)
                {
                    this.CellType(column.FieldName, ItsEnums.CellTypes.Number);
                }
                else if (column.CellType == ItsEnums.CellTypes.Check)
                {
                    this.CellType(column.FieldName, ItsEnums.CellTypes.Check);
                }
                else if (column.CellType == ItsEnums.CellTypes.Date)
                {
                    this.CellType(column.FieldName, ItsEnums.CellTypes.Date);
                }
                else if (column.CellType == ItsEnums.CellTypes.Time)
                {
                    this.CellType(column.FieldName, ItsEnums.CellTypes.Time);
                }
                else if (column.CellType == ItsEnums.CellTypes.ImageView)
                {
                    this.CellType(column.FieldName, ItsEnums.CellTypes.ImageView);
                }
                else
                {
                    this.CellType(column.FieldName, ItsEnums.CellTypes.Text);
                }
            }
            gridControl.ItemsSource = this.DefaultView;
        }
        else if (treeGrid != null)
        {
            foreach (TreeListColumn column in treeGrid.Columns)
            {
                if (column.EditSettings is SpinEditSettings)
                {
                    this.CellType(column.FieldName, ItsEnums.CellTypes.Number);
                }
                else
                {
                    this.CellType(column.FieldName, ItsEnums.CellTypes.Text);
                }
            }
            treeGrid.ItemsSource = this.DefaultView;
        }
        else if (pivotGrid != null)
        {
            foreach (PivotGridField field in pivotGrid.Fields)
            {
                if (field.CellFormat != "")
                {
                    this.CellType(field.FieldName, ItsEnums.CellTypes.Number);
                }
                else
                {
                    this.CellType(field.FieldName, ItsEnums.CellTypes.Text);
                }
            }
            pivotGrid.DataSource = this.DefaultView;
        }
    }

    public int AddRow(ItsModelPanel modelPanel)
    {
        return AddRow(modelPanel as DataTable);
    }

    public int AddRow(DataTable dt)
    {
        DataRow curRow = null;
        foreach (DataRow row in dt.Rows)
        {
            DataRow newRow = this.NewRow();
            newRow["ISCHECKED"] = true;
            foreach (DataColumn column in dt.Columns)
            {
                string fieldName = column.ColumnName.ToUpper();
                if (!this.Columns.Contains(fieldName))
                {
                    this.SetValue(0, fieldName, "");
                }

                if (this.Columns[fieldName].DataType == typeof(bool))
                {
                    if (row[column.ColumnName].ToString() == "Y")
                    {
                        newRow[fieldName] = true;
                    }
                    else
                    {
                        newRow[fieldName] = false;
                    }
                }
                else
                {
                    newRow[fieldName] = row[column.ColumnName];
                }
            }
            this.Rows.Add(newRow);
            curRow = newRow;
        }

        int rowIndex = this.Rows.IndexOf(curRow);

        ITSLIB.Grid grid = this.TargetGrid as ITSLIB.Grid;

        grid.ItemsSource = null;
        grid.ItemsSource = this.DefaultView;

        grid.SelectedItem = this.DefaultView[rowIndex];
        grid.CurrentItem = grid.SelectedItem;

        return rowIndex;
    }

    public void AddRow(int rowCount)
    {
        for (int i = 0; i < rowCount; i++)
        {
            AddRow();
        }
    }

    public int AddRow()
    {
        DataRow newRow = this.NewRow();
        newRow["ISCHECKED"] = true;
        this.Rows.Add(newRow);

        int rowIndex = this.Rows.IndexOf(newRow);

        ITSLIB.Grid grid = this.TargetGrid as ITSLIB.Grid;

        grid.ItemsSource = null;
        grid.ItemsSource = this.DefaultView;

        grid.SelectedItem = this.DefaultView[rowIndex];
        grid.CurrentItem = grid.SelectedItem;

        return rowIndex;
    }

    public int ModelCount
    {
        get
        {
            return this.Rows.Count;
        }
    }

    private Dictionary<string, ItsEnums.CellTypes> _CellTypes = new Dictionary<string, ItsEnums.CellTypes>();
    public void CellType(string fieldName, ItsEnums.CellTypes cellType)
    {
        DataTable oldDt = null;
        if (this.Rows.Count > 0)
        {
            oldDt = this.Copy();
        }

        this.Rows.Clear();

        fieldName = fieldName.ToUpper();
        if (_CellTypes.ContainsKey(fieldName))
        {
            _CellTypes[fieldName] = cellType;
        }
        else
        {
            _CellTypes.Add(fieldName, cellType);
        }

        Type type;
        if (cellType == ItsEnums.CellTypes.Check)
        {
            type = typeof(bool);
        }
        else if (cellType == ItsEnums.CellTypes.Number)
        {
            type = typeof(decimal);
        }
        else if (cellType == ItsEnums.CellTypes.ImageView)
        {
            type = typeof(ImageSource);
        }
        else
        {
            type = typeof(string);
        }

        if (!this.Columns.Contains(fieldName))
        {
            this.Columns.Add(fieldName, type);
        }
        else
        {
            this.Columns[fieldName].DataType = type;
        }

        if (oldDt != null) this.SetData(oldDt);
    }

    public ItsEnums.CellTypes GetCellType(string fieldName)
    {
        if (_CellTypes.ContainsKey(fieldName.ToUpper()))
        {
            return _CellTypes[fieldName];
        }
        else
        {
            MessageBox.Show("ItsModelGrid GetCellType Error : [ " + fieldName + " ]");
            return ItsEnums.CellTypes.Text;
        }
    }

    public object GetValue(int rowIndex, string fieldName)
    {
        if (this.TargetGrid == null)
        {
            MessageBox.Show("ItsModelGrid -> Binding Error");
            return "";
        }

        fieldName = fieldName.ToUpper();
        if (!this.Columns.Contains(fieldName))
        {
            MessageBox.Show("ItsModelGrid GetValue Error : [ " + fieldName + " ]");
            return "";
        }

        if (rowIndex < 0 || rowIndex >= this.Rows.Count) return "";
        else return this.Rows[rowIndex][fieldName];
    }

    public string GetText(int rowIndex, string fieldName)
    {
        return GetValue(rowIndex, fieldName).ToString();
    }

    public decimal GetDecimal(int rowIndex, string fieldName)
    {
        try
        {
            return decimal.Parse(GetText(rowIndex, fieldName));
        }
        catch { return 0m; }
    }

    public int GetInt(int rowIndex, string fieldName)
    {
        try
        {
            return int.Parse(GetText(rowIndex, fieldName));
        }
        catch { return 0; }
    }

    public string GetYn(int rowIndex, string fieldName)
    {
        string value = GetText(rowIndex, fieldName).ToUpper();
        if (value == "Y" || value == "TRUE")
        {
            return "Y";
        }
        else
        {
            return "N";
        }
    }

    public bool GetBool(int rowIndex, string fieldName)
    {
        string value = GetText(rowIndex, fieldName).ToUpper();
        if (value == "Y" || value == "TRUE")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 2020-03-31
    public void SetRef01(string fieldName, string value)
    {
        ITSLIB.Column col = ((this.TargetGrid as ITSLIB.Grid).Columns[fieldName] as ITSLIB.Column);

        ItsModelCombo comboModel = ITSLIB.Combo.GetComboList(col.GPCD, value, col.REF02, col.REF03, col.REF04, col.REF05);
        SetRefComboList(col, comboModel);
    }
    public void SetRef02(string fieldName, string value)
    {
        ITSLIB.Column col = ((this.TargetGrid as ITSLIB.Grid).Columns[fieldName] as ITSLIB.Column);

        ItsModelCombo comboModel = ITSLIB.Combo.GetComboList(col.GPCD, col.REF01, value, col.REF03, col.REF04, col.REF05);
        SetRefComboList(col, comboModel);
    }
    public void SetRef03(string fieldName, string value)
    {
        ITSLIB.Column col = ((this.TargetGrid as ITSLIB.Grid).Columns[fieldName] as ITSLIB.Column);

        ItsModelCombo comboModel = ITSLIB.Combo.GetComboList(col.GPCD, col.REF01, col.REF02, value, col.REF04, col.REF05);
        SetRefComboList(col, comboModel);
    }
    public void SetRef04(string fieldName, string value)
    {
        ITSLIB.Column col = ((this.TargetGrid as ITSLIB.Grid).Columns[fieldName] as ITSLIB.Column);

        ItsModelCombo comboModel = ITSLIB.Combo.GetComboList(col.GPCD, col.REF01, col.REF02, col.REF03, value, col.REF05);
        SetRefComboList(col, comboModel);
    }
    public void SetRef05(string fieldName, string value)
    {
        ITSLIB.Column col = ((this.TargetGrid as ITSLIB.Grid).Columns[fieldName] as ITSLIB.Column);

        ItsModelCombo comboModel = ITSLIB.Combo.GetComboList(col.GPCD, col.REF01, col.REF02, col.REF03, col.REF04, value);
        SetRefComboList(col, comboModel);
    }
    protected void SetRefComboList(ITSLIB.Column col, ItsModelCombo comboModel)
    {
        ComboBoxEditSettings combo = new ComboBoxEditSettings();
        combo.AutoComplete = true;
        combo.IsTextEditable = true;
        combo.ImmediatePopup = false;
        combo.ValueMember = "Value";
        combo.DisplayMember = "Label";

        DataRow newRow = comboModel.NewRow();
        newRow[0] = "";
        newRow[1] = "";
        comboModel.Rows.InsertAt(newRow, 0);
        combo.ItemsSource = comboModel.DefaultView;
        col.EditSettings = combo;
    }

    public void SetValue(int rowIndex, string fieldName, object value)
    {
        if (this.TargetGrid == null)
        {
            MessageBox.Show("ItsModelGrid -> Binding Error");
            return;
        }

        fieldName = fieldName.ToUpper();
        if (!this.Columns.Contains(fieldName))
        {
            this.CellType(fieldName, ItsEnums.CellTypes.Text);
        }

        object oldValue = this.GetValue(rowIndex, fieldName);
        if (oldValue.Equals(value))
        {
            return;
        }

        if (rowIndex > -1 && this.Rows.Count > rowIndex)
        {
            try
            {
                this.Rows[rowIndex][fieldName] = value;
            }
            catch
            {
                MessageBox.Show("SetValue Error: [ " + fieldName + " ]");
                return;
            }

            if (_EventValueChanged != null)
            {
                _EventValueChanged(rowIndex, fieldName);
            }
        }
    }

    public void InitData()
    {
        this.Rows.Clear();
    }

    public void DeleteCheckedModel()
    {
        List<DataRow> delList = new List<DataRow>();
        foreach (DataRow row in this.Rows)
        {
            if (this.IsChecked(row)) delList.Add(row);
        }
        foreach (DataRow row in delList)
        {
            this.Rows.Remove(row);
        }

        ITSLIB.Grid grid = this.TargetGrid as ITSLIB.Grid;
        grid.ItemsSource = null;
        grid.ItemsSource = this.DefaultView;

        if (this.Rows.Count > 0)
        {
            this.SelectRow(0);
        }
    }

    public void DeleteCurrentModel()
    {
        if (this.CurrentModel == null || this.Rows.Count == 0) return;

        int rowIndex = this.CurrentIndex;

        this.Rows.Remove(this.CurrentModel);
        ITSLIB.Grid grid = this.TargetGrid as ITSLIB.Grid;
        grid.ItemsSource = null;
        grid.ItemsSource = this.DefaultView;

        if (this.Rows.Count == 0) return;

        if (rowIndex >= this.Rows.Count)
        {
            this.SelectRow(this.Rows.Count - 1);
        }
        else
        {
            this.SelectRow(rowIndex);
        }
    }

    public int CurrentIndex
    {
        get
        {
            return this.Rows.IndexOf(this.CurrentModel);
        }
    }

    public DataRow GetModel(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= this.Rows.Count)
        {
            return this.NewRow();
        }
        else
        {
            return this.Rows[rowIndex];
        }
    }

    public DataRow CurrentModel
    {
        get
        {
            if (TargetGrid is ITSLIB.Grid)
            {
                DataRowView selectedItem = (TargetGrid as ITSLIB.Grid).SelectedItem as DataRowView;
                if (selectedItem != null) return (selectedItem as DataRowView).Row;
                if (this.Rows.Count == 0) return this.NewRow();
                return this.Rows[0];
            }
            else if (TargetGrid is TreeListControl)
            {
                DataRowView selectedItem = (TargetGrid as TreeListControl).SelectedItem as DataRowView;
                if (selectedItem != null) return (selectedItem as DataRowView).Row;
                if (this.Rows.Count == 0) return this.NewRow();
                return this.Rows[0];
            }
            else if (TargetGrid is PivotGridControl)
            {
                // return (_BindGrid as PivotGridControl).GetValue( as DataRow;
                return this.NewRow();
            }
            return this.NewRow();
        }
    }

    public bool IsChecked(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= this.Rows.Count) return false;
        return (bool)(this.Rows[rowIndex]["ISCHECKED"]);
    }

    public bool IsChecked(DataRow row)
    {
        if (row == null) return false;
        return (bool)(row["ISCHECKED"]);
    }

    public void SetChecked(int rowIndex, bool checkValue)
    {
        if (rowIndex < 0 || rowIndex >= this.Rows.Count) return;
        this.Rows[rowIndex]["ISCHECKED"] = checkValue;
    }

    public void SetChecked(DataRow row, bool checkValue)
    {
        if (row == null) return;
        row["ISCHECKED"] = checkValue;
    }

    public void SelectRow(DataRow row)
    {
        if (row == null)
        {
            SelectRow(-1);
        }
        else
        {
            SelectRow(this.Rows.IndexOf(row));
        }
    }

    public void SelectRow(int rowIndex)
    {
        if (this.Rows.Count > 0)
        {
            if (rowIndex < 0 || rowIndex >= this.Rows.Count)
            {
                (this.TargetGrid as ITSLIB.Grid).SelectedItem = this.DefaultView[0];
                (this.TargetGrid as ITSLIB.Grid).CurrentItem = this.DefaultView[0];
            }
            else
            {
                (this.TargetGrid as ITSLIB.Grid).SelectedItem = this.DefaultView[rowIndex];
                (this.TargetGrid as ITSLIB.Grid).CurrentItem = this.DefaultView[rowIndex];
            }
        }
    }

    public void SetData(DataTable dt)
    {
        ITSLIB.Grid grid = TargetGrid as ITSLIB.Grid;
        TreeListControl treeGrid = TargetGrid as TreeListControl;
        PivotGridControl pivotGrid = TargetGrid as PivotGridControl;

        this.InitData();

        if (grid != null)
        {
            grid.SelectedItem = null;
            grid.CurrentItem = null;
        }
        else if (treeGrid != null)
        {
            treeGrid.SelectedItem = null;
            treeGrid.CurrentItem = null;
        }

        foreach (DataColumn column in dt.Columns)
        {
            string fieldName = column.ColumnName.ToUpper();
            if (fieldName.Replace(" ", "").IndexOf("GPCD('") == -1 && !this.Columns.Contains(fieldName))
            {
                if (column.DataType == typeof(decimal) || column.DataType == typeof(int)
                    || column.DataType == typeof(float) || column.DataType == typeof(double))
                {
                    this.CellType(fieldName, ItsEnums.CellTypes.Number);
                }
                else if (column.DataType == typeof(bool))
                {
                    this.CellType(fieldName, ItsEnums.CellTypes.Check);
                }
                else if (column.DataType == typeof(ImageSource))
                {
                    this.CellType(fieldName, ItsEnums.CellTypes.ImageView);
                }
                else
                {
                    this.CellType(fieldName, ItsEnums.CellTypes.Text);
                }
            }
        }

        foreach (DataRow row in dt.Rows)
        {
            DataRow newRow = this.NewRow();
            newRow["ISCHECKED"] = false;
            foreach (DataColumn column in dt.Columns)
            {
                string fieldName = column.ColumnName.ToUpper();
                if (this.Columns.Contains(fieldName))
                {
                    if (this.Columns[fieldName].DataType == typeof(bool))
                    {
                        if (row[column.ColumnName].ToString() == "Y")
                        {
                            newRow[fieldName] = true;
                        }
                        else
                        {
                            newRow[fieldName] = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            newRow[fieldName] = row[column.ColumnName];
                        }
                        catch
                        {
                            MessageBox.Show("DEBUG: ItsModelGrid -> SetData " + fieldName + ", " + row[column.ColumnName].ToString());
                        }
                    }
                }
            }
            this.Rows.Add(newRow);
            if (this.GetKey(newRow) == _KeyValue)
            {
                if (grid != null)
                {
                    grid.SelectedItem = this.DefaultView[this.Rows.IndexOf(newRow)];
                    grid.CurrentItem = grid.SelectedItem;
                }
                else if (treeGrid != null)
                {
                    treeGrid.SelectedItem = this.DefaultView[this.Rows.IndexOf(newRow)];
                    treeGrid.CurrentItem = treeGrid.SelectedItem;
                }
                else if (pivotGrid != null)
                {
                    // pivotGrid.Selection;
                }
            }
        }

        if (grid != null && grid.SelectedItem == null && this.ModelCount > 0)
        {
            grid.SelectedItem = this.DefaultView[0];
            grid.CurrentItem = grid.SelectedItem;
        }
        else if (treeGrid != null && grid.SelectedItem == null && this.ModelCount > 0)
        {
            treeGrid.SelectedItem = this.DefaultView[0];
            treeGrid.CurrentItem = treeGrid.SelectedItem;
        }

        //if (grid.SelectedItem != null)
        //{
        //    this.ModelChanged(this.CurrentIndex);
        //}
        //else
        //{
        //    this.ModelChanged(-1);
        //}
    }

    public int CheckedCount
    {
        get
        {
            int count = 0;
            foreach (DataRow row in this.Rows)
            {
                if ((bool)row["ISCHECKED"]) count++;
            }
            return count;
        }
    }


    // ===========================================================================================
    // CheckRow 기능 (DefaultView 기준 정렬/필터 순서 반영 버전) 2026-01-19 임현진 체크한 행 정보 보관 기능 추가
    // -------------------------------------------------------------------------------------------
    // 목적
    //  - MODEL_G1.CheckRow 호출 시, DataTable.Rows 원본 순서가 아니라
    //    "그리드에서 보이는 순서" = DefaultView(정렬/필터 적용된 순서) 기준으로 반환
    //
    // 핵심 변화
    //  - 이전: this.Rows(원본) 순서대로 체크된 행 수집
    //  - 현재: this.DefaultView(필터/정렬 반영) 순서대로 체크된 행 수집
    //
    // 추가 제공
    //  - _rowindex  : 원본 DataTable.Rows 기준 rowIndex (요구사항 유지)
    //  - _viewindex : DefaultView 기준 index (그리드에서 보이는 순서의 인덱스)  
    // ===========================================================================================
    public dynamic[] CheckRow
    {
        get
        {
            // DefaultView 기준으로 체크된 행들을 스냅샷 배열로 반환
            return GetCheckedRowArray_ByDefaultView();
        }
    }

    // DefaultView(정렬/필터 반영) 기준으로 체크된 행 배열 생성
    private dynamic[] GetCheckedRowArray_ByDefaultView()
    {
        // ISCHECKED 컬럼이 아직 없다면(예: Binding 전) 빈 배열 반환
        if (!this.Columns.Contains("ISCHECKED"))
        {
            return new dynamic[0];
        }

        // rowIndex를 빠르게 찾기 위한 맵(성능 개선)
        // - DefaultView는 DataRowView를 주고, 요구사항 _rowindex는 DataTable.Rows의 인덱스가 필요함
        // - Rows.IndexOf(row)를 매번 호출하면 O(n^2) 될 수 있어, 1회 맵 생성 후 O(1) 조회
        Dictionary<DataRow, int> rowIndexMap = new Dictionary<DataRow, int>();
        for (int i = 0; i < this.Rows.Count; i++)
        {
            rowIndexMap[this.Rows[i]] = i;
        }

        List<dynamic> list = new List<dynamic>();

        // DefaultView 순서대로 순회 (정렬/필터 반영 = 그리드에서 보이는 순서)
        for (int viewIndex = 0; viewIndex < this.DefaultView.Count; viewIndex++)
        {
            DataRowView rv = this.DefaultView[viewIndex];
            if (rv == null) continue;

            object v = rv["ISCHECKED"];
            bool isChecked = (v != DBNull.Value) && (v is bool) && (bool)v;

            if (!isChecked) continue;

            // 원본 DataTable.Rows index(_rowindex) 계산
            int rowIndex;
            if (!rowIndexMap.TryGetValue(rv.Row, out rowIndex))
            {
                // 방어: 이론상 거의 없음(삭제 직후 등)
                // - 요구사항 충족을 위해 일단 -1을 주고 계속 진행할 수도 있지만,
                //   여기서는 "정상 행만" 반환하도록 skip 처리
                continue;
            }

            // DefaultView 기준 인덱스(viewIndex)도 함께 저장
            list.Add(new CheckedRowItem(this, rowIndex, viewIndex));
        }

        return list.ToArray();
    }

    // 체크된 단일 행을 표현하는 동적 래퍼 (DefaultView 인덱스까지 포함)
    public sealed class CheckedRowItem : DynamicObject
    {
        private readonly ItsModelGrid _grid;
        private readonly int _rowIndex;   // DataTable.Rows 기준 인덱스 (요구사항 유지)
        private readonly int _viewIndex;  // DefaultView 기준 인덱스 (그리드 표시 순서) ★추가

        internal CheckedRowItem(ItsModelGrid grid, int rowIndex, int viewIndex)
        {
            _grid = grid;
            _rowIndex = rowIndex;
            _viewIndex = viewIndex;
        }

        // 요구사항: 원본 DataTable.Rows 인덱스
        public int _rowindex => _rowIndex;

        // 그리드에서 보이는 순서(정렬/필터 반영) 기준 인덱스
        public int _viewindex => _viewIndex;

        // (옵션) 원본 DataRow 접근
        public DataRow _row => (_rowIndex >= 0 && _rowIndex < _grid.Rows.Count) ? _grid.Rows[_rowIndex] : null;

        // (디버깅/확인용) 전체 컬럼/값 Dictionary
        public Dictionary<string, object> _cols
        {
            get
            {
                var dic = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                if (_row == null) return dic;

                foreach (DataColumn col in _grid.Columns)
                {
                    dic[col.ColumnName] = _row[col.ColumnName];
                }
                return dic;
            }
        }

        // dynamic getter
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;

            // 예약 멤버
            if (string.Equals(name, "_rowindex", StringComparison.OrdinalIgnoreCase))
            {
                result = _rowIndex;
                return true;
            }
            if (string.Equals(name, "_viewindex", StringComparison.OrdinalIgnoreCase))
            {
                result = _viewIndex;
                return true;
            }
            if (string.Equals(name, "_row", StringComparison.OrdinalIgnoreCase))
            {
                result = _row;
                return true;
            }
            if (string.Equals(name, "_cols", StringComparison.OrdinalIgnoreCase))
            {
                result = _cols;
                return true;
            }

            if (_rowIndex < 0 || _rowIndex >= _grid.Rows.Count)
            {
                result = null;
                return true;
            }

            // 기존 정책 유지: 컬럼 접근은 대문자 기준
            string fieldName = name.ToUpper();

            if (!_grid.Columns.Contains(fieldName))
            {
                throw new ArgumentException($"Column not found: [{fieldName}]");
            }

            result = _grid.Rows[_rowIndex][fieldName];
            return true;
        }

        // dynamic setter
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            string name = binder.Name;

            // 예약 멤버는 쓰기 금지
            if (string.Equals(name, "_rowindex", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(name, "_viewindex", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(name, "_row", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(name, "_cols", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            // 기존 SetValue 경유(이벤트/자동체크 등 기존 동작 유지)
            _grid.SetValue(_rowIndex, name, value);
            return true;
        }

        // dynamic 멤버 후보
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            foreach (DataColumn col in _grid.Columns)
                yield return col.ColumnName;

            yield return "_rowindex";
            yield return "_viewindex";
            yield return "_row";
            yield return "_cols";
        }
    }


}
