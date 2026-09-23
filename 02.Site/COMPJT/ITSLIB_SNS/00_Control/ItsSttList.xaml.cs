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
    public partial class SttList : UserControl
    {
        public SttList()
        {
            InitializeComponent();
        }

        private string _Label = "";
        public string Label
        {
            set
            {
                _Label = value;
            }
        }

        public string SttCheckedList
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                List<CheckBox> checkList = ItsElement.FindChild<CheckBox>(this);
                foreach(CheckBox check in checkList)
                {
                    if (check.IsChecked == true)
                    {
                        sb.Append(check.Tag.ToString() + "»");
                    }
                }
                return sb.ToString();
            }
        }

        public string UnCheck
        {
            set
            {
                string uncheckList = value.Replace(" ", "") + ",";

                List<CheckBox> checkList = ItsElement.FindChild<CheckBox>(this);
                foreach(CheckBox checkBox in checkList)
                {
                    if (uncheckList.IndexOf(checkBox.Tag.ToString() + ",") > -1)
                    {
                        checkBox.IsChecked = false;
                    }
                }

            }
        }

        public string HiddenCheck
        {
            set
            {
                if (value.Length >= 0)
                {
                    List<CheckBox> checkList = ItsElement.FindChild<CheckBox>(this);
                    foreach (CheckBox checkBox in checkList)
                    {
                        checkBox.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        public string GPCD
        {
            set
            {
                StackStt.Children.Clear();

                if (_Label != "")
                {
                    DockPanel labelDock = new DockPanel();
                    labelDock.Height = 22d;
                    labelDock.Background = new SolidColorBrush(Colors.Transparent);
                    StackStt.Children.Add(labelDock);

                    TextBlock textBlock = new TextBlock();
                    textBlock.SetValue(DockPanel.DockProperty, Dock.Top);
                    textBlock.Margin = new Thickness(20, 0, 5, 0);
                    textBlock.Text = _Label;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    labelDock.Children.Add(textBlock);

                }

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT TPCD, TPNM, REF01, REF02 FROM COMTYPE");
                query.AppendLine("WHERE GPCD = 'MTRODRSTT'");
                query.AppendLine("AND USEYN = 'Y' AND REF01 <> ''");
                query.AppendLine("ORDER BY SORTNO;");

                DataTable dt = ItsMaria.Query(query.ToString()).Tables[0];
                foreach(DataRow row in dt.Rows)
                {
                    try
                    {
                        Border border = new Border();
                        border.Height = 22d;
                        border.BorderThickness = new Thickness(1);
                        border.BorderBrush = new SolidColorBrush(Colors.Gray);
                        border.Margin = new Thickness(-1, 0, 0, 0);
                        try
                        {
                            border.Background = new BrushConverter().ConvertFromString(row["REF01"].ToString()) as SolidColorBrush;
                        }
                        catch { }
                        StackStt.Children.Add(border);

                        DockPanel dockPanel = new DockPanel();
                        dockPanel.MouseDown += DockPanel_MouseDown;
                        border.Child = dockPanel;

                        CheckBox checkbox = new CheckBox();
                        checkbox.Tag = row["TPCD"].ToString();
                        checkbox.SetValue(DockPanel.DockProperty, Dock.Left);
                        checkbox.IsChecked = true;
                        checkbox.Margin = new Thickness(5, -2, -5, 0);
                        dockPanel.Children.Add(checkbox);

                        TextBlock textBlock = new TextBlock();
                        textBlock.SetValue(DockPanel.DockProperty, Dock.Left);
                        textBlock.Margin = new Thickness(5, 0, 5, 0);
                        try
                        {
                            textBlock.Foreground = new BrushConverter().ConvertFromString(row["REF02"].ToString()) as SolidColorBrush;
                        }
                        catch { }
                        textBlock.Text = row["TPNM"].ToString();
                        dockPanel.Children.Add(textBlock);
                    }
                    catch { }
                }
  
            }
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CheckBox check = ItsElement.FindChild<CheckBox>(sender)[0] as CheckBox;
            check.IsChecked = !check.IsChecked;
        }
    }
}
