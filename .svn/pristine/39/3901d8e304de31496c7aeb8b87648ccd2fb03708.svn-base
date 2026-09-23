using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class Combo : UserControl
    {
        public ItsModelCombo ModelCombo = null;
        public ItsModelPanel ModelPanel = null;

        public Combo()
        {
            InitializeComponent();
            comboBox.DisplayMemberPath = "Label";
            comboBox.SelectedValuePath = "Value";
            comboBox.BorderBrush = Brushes.Silver;
            comboBox.BorderThickness = new Thickness(1d);

            borderName.Visibility = Visibility.Collapsed;
        }

        public bool ReadOnly
        {
            get { return comboBox.IsReadOnly; }
            set
            {
                comboBox.IsReadOnly = value;
                comboBox.IsEnabled = !value;
                if (value)
                {
                    comboBox.Background = new BrushConverter().ConvertFrom("#ECECEC") as SolidColorBrush;
                }
                else
                {
                    comboBox.Background = Brushes.White;
                }
            }
        }

        public string Label
        {
            get { return textBlock.Text; }
            set { textBlock.Text = value; }
        }

        public string HidenLabel
        {
            set
            {
                if (value.Length > 0)
                {
                    this.Width = this.Width - textBlock.Width;
                    textBlock.Width = 0;
                    textBlock.Visibility = Visibility.Hidden;
                }
            }
        }

        public double LabelWidth
        {
            get { return textBlock.Width; }
            set { textBlock.Width = value; }
        }

        private string _HidenCode = "";
        public string HidenCode
        {
            set
            {
                _HidenCode = value;
            }
        }

        private string _GPCD = "";
        public string GPCD
        {
            get { return _GPCD; }
            set
            {
                _GPCD = value;
                if (_GPCD != "")
                {
                    this.ModelCombo = GetComboList(_GPCD, _REF01, _REF02, _REF03, _REF04, _REF05);
                    comboBox.ItemsSource = null;
                    comboBox.ItemsSource = this.ModelCombo.DefaultView;
                }
            }
        }

        private string _REF01 = "";
        public string REF01
        {
            get { return _REF01; }
            set
            {
                _REF01 = value;
                if (_GPCD != "")
                {
                    this.ModelCombo = GetComboList(_GPCD, _REF01, _REF02, _REF03, _REF04, _REF05);
                    comboBox.ItemsSource = null;
                    comboBox.ItemsSource = this.ModelCombo.DefaultView;
                }
            }
        }

        private string _REF02 = "";
        public string REF02
        {
            get { return _REF02; }
            set
            {
                _REF02 = value;
                if (_GPCD != "")
                {
                    this.ModelCombo = GetComboList(_GPCD, _REF01, _REF02, _REF03, _REF04, _REF05);
                    comboBox.ItemsSource = null;
                    comboBox.ItemsSource = this.ModelCombo.DefaultView;
                }
            }
        }

        private string _REF03 = "";
        public string REF03
        {
            get { return _REF03; }
            set
            {
                _REF03 = value;
                if (_GPCD != "")
                {
                    this.ModelCombo = GetComboList(_GPCD, _REF01, _REF02, _REF03, _REF04, _REF05);
                    comboBox.ItemsSource = null;
                    comboBox.ItemsSource = this.ModelCombo.DefaultView;
                }
            }
        }

        private string _REF04 = "";
        public string REF04
        {
            get { return _REF04; }
            set
            {
                _REF04 = value;
                if (_GPCD != "")
                {
                    this.ModelCombo = GetComboList(_GPCD, _REF01, _REF02, _REF03, _REF04, _REF05);
                    comboBox.ItemsSource = null;
                    comboBox.ItemsSource = this.ModelCombo.DefaultView;
                }
            }
        }

        private string _REF05 = "";
        public string REF05
        {
            get { return _REF05; }
            set
            {
                _REF05 = value;
                if (_GPCD != "")
                {
                    this.ModelCombo = GetComboList(_GPCD, _REF01, _REF02, _REF03, _REF04, _REF05);
                    comboBox.ItemsSource = null;
                    comboBox.ItemsSource = this.ModelCombo.DefaultView;
                }
            }
        }

        public void ItemClear()
        {
            if (this.ModelCombo != null)
            {
                this.ModelCombo.Rows.Clear();
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = this.ModelCombo.DefaultView;
            }
        }

        public void AddItem(DataTable dt)
        {
            AddItem(dt, "EMPTY");
        }

        public void AddItem(DataTable dt, string allStr)
        {
            if (this.ModelCombo == null)
            {
                this.ModelCombo = new ItsModelCombo();
                comboBox.ItemsSource = this.ModelCombo.DefaultView;
            }

            if (dt.Columns.Count > 1 && allStr != "EMPTY")
            {
                DataRow newRow = this.ModelCombo.NewRow();
                newRow[0] = allStr;
                newRow[1] = "";
                this.ModelCombo.Rows.Add(newRow);
            }

            if (dt != null && dt.Columns.Count > 1 && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = this.ModelCombo.NewRow();
                    newRow[0] = row[0].ToString();
                    newRow[1] = row[1].ToString();
                    this.ModelCombo.Rows.Add(newRow);
                }
            }

            comboBox.ItemsSource = null;
            comboBox.ItemsSource = this.ModelCombo.DefaultView;
        }

        public System.Collections.IEnumerable ItemsSource
        {
            get
            {
                return comboBox.ItemsSource;
            }
            set
            {
                comboBox.ItemsSource = null;
                comboBox.ItemsSource = value;
            }
        }

        public void AddItem(string label, string value)
        {
            if (this.ModelCombo == null)
            {
                this.ModelCombo = new ItsModelCombo();
                comboBox.ItemsSource = this.ModelCombo.DefaultView;
            }

            DataRow newRow = this.ModelCombo.NewRow();
            newRow[0] = label;
            newRow[1] = value;
            this.ModelCombo.Rows.Add(newRow);

            comboBox.ItemsSource = null;
            comboBox.ItemsSource = this.ModelCombo.DefaultView;
        }

        public static ItsModelCombo GetComboList(string GPCD, string REF01, string REF02, string REF03, string REF04, string REF05)
        {
            ItsModelCombo modelCombo = new ItsModelCombo();

            GPCD = GPCD.Replace("'", "''");

            if (GPCD.Trim() == "") return modelCombo;

            string allString = "";
            if (GPCD.Trim().Substring(0, 1) == "*")
            {
                allString = "전체";
                GPCD = GPCD.Trim().Substring(1);
            }

            if (GPCD.Trim().Substring(0, 1) == "@")
            {
                allString = " ";
                GPCD = GPCD.Trim().Substring(1);
            }

            DataTable dt = ItsMaria.Query("CALL DC_COMBO('" + GPCD + "', '" + REF01 + "', '" + REF02 + "', '" + REF03 + "', '" + REF04 + "', '" + REF05 + "', '', '', '', '', '')").Tables[0];

            if (dt.Columns.Count > 1 && allString.Length > 0)
            {
                DataRow newRow = modelCombo.NewRow();
                newRow[0] = allString;
                newRow[1] = "";
                modelCombo.Rows.InsertAt(newRow, 0);
            }

            if (dt != null && dt.Columns.Count > 1 && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = modelCombo.NewRow();
                    newRow[0] = row[0].ToString();
                    newRow[1] = row[1].ToString();
                    modelCombo.Rows.Add(newRow);
                }
            }

            return modelCombo;
        }

        // =========================
        // 외부에서 라벨/값 접근용 추가   2026-01-19 임현진 표시되는 라벨값 가져오도록 하는 부분
        // =========================

        public object SelectedItem
        {
            get { return comboBox.SelectedItem; }
        }

        public DataRowView SelectedRowView
        {
            get { return comboBox.SelectedItem as DataRowView; }
        }

        public string SelectedLabel
        {
            get
            {
                var drv = comboBox.SelectedItem as DataRowView;
                return drv?["Label"]?.ToString() ?? comboBox.Text ?? "";
            }
        }

        public string SelectedValueString
        {
            get { return comboBox.SelectedValue?.ToString() ?? ""; }
        }

        // =========================
        // Value DependencyProperty
        // =========================

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public readonly static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof(string),
                typeof(Combo),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, valueChangedCallback));

        private static void valueChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;

            var c = (Combo)sender;

            // Value -> ComboBox 선택 동기화 (comboBox가 아직 null일 수 있어 가드)
            if (c.comboBox != null)
            {
                c.comboBox.SelectedValue = e.NewValue.ToString();
            }

            if (e.NewValue.ToString() == "")
            {
                c.borderName.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (c._HidenCode.Length == 0)
                {
                    //c.borderName.Visibility = Visibility.Visible;
                    c.borderName.Visibility = Visibility.Collapsed;
                }
            }
        }

        public new bool IsFocused
        {
            get
            {
                return comboBox.IsFocused;
            }
        }

        private void comboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            comboBox.BorderBrush = Brushes.Black;
            comboBox.BorderThickness = new Thickness(1.5d);
            if (!comboBox.IsReadOnly)
            {
                comboBox.Background = Brushes.MintCream;
            }
        }

        private void comboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            comboBox.BorderBrush = Brushes.Silver;
            comboBox.BorderThickness = new Thickness(1d);
            if (!comboBox.IsReadOnly)
            {
                comboBox.Background = Brushes.White;
            }
        }

        private void comboBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F3)
            {
                try
                {
                    var drv = comboBox.SelectedItem as DataRowView;

                    MessageBox.Show(
                        "GPCD=" + this.GPCD.Replace("*", "").Replace("@", "") + "\n" +
                        "LABEL=" + (drv?["Label"]?.ToString() ?? comboBox.Text ?? "NULL") + "\n" +
                        "VALUE=" + (comboBox.SelectedValue?.ToString() ?? "NULL")
                    );

                    //MessageBox.Show(comboBox.SelectedValue.ToString());
                }
                catch
                {
                    MessageBox.Show("NULL");
                }
            }
        }
    }
}
