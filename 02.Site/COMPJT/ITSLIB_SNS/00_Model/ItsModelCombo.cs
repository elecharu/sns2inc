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

public class ItsModelCombo : DataTable
{
    public ItsModelCombo()
    {
        this.Columns.Add("Label", typeof(string));
        this.Columns.Add("Value", typeof(string));
    }

    public void AddItem(DataTable dt)
    {
        foreach(DataRow row in dt.Rows)
        {
            AddItem(row);
        }
    }

    public void AddItem(DataRow row)
    {
        if (row.Table.Columns.Count >= 2)
        {
            AddItem(row[0].ToString(), row[1].ToString());
        }
    }

    public void AddItem(string label, string value)
    {
        DataRow row = this.NewRow();
        row[0] = label;
        row[1] = value;
        this.Rows.Add(row);
    }

    public void Binding(ITSLIB.Combo combo)
    {
        combo.ItemsSource = this.DefaultView;
    }

    public void Binding(ComboBox combo)
    {
        combo.ItemsSource = null;
        combo.ItemsSource = this.DefaultView;
    }
}
