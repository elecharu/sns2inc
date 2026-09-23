using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class OnOff : UserControl
    {
        public ItsModelPanel ModelPanel = null;
        public OnOff()
        {
            InitializeComponent();
        }

        public string Label
        {
            get { return textBlock.Text; }
            set { textBlock.Text = value; }
        }

        private string _OnText = "On";
        public string OnText
        {
            get { return _OnText; }
            set {
                _OnText = value;
                Value = Value;
            }
        }

        private string _OffText = "Off";
        public string OffText
        {
            get { return _OffText; }
            set {
                _OffText = value;
                Value = Value;
            }
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

        public bool Value
        {
            get
            {
                return (bool)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);

                if (value)
                {
                    checkBackground.Background = Brushes.MintCream;
                    //checkCircle.Background = Brushes.SeaGreen;
                    checkCircle.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4472c4"));
                    checkCircle.SetValue(DockPanel.DockProperty, Dock.Right);
                    checkText.SetValue(DockPanel.DockProperty, Dock.Right);
                    checkText.TextAlignment = TextAlignment.Right;
                    checkText.Text = OnText;
                }
                else
                {
                    checkBackground.Background = Brushes.WhiteSmoke;
                    checkCircle.Background = Brushes.Silver;
                    checkCircle.SetValue(DockPanel.DockProperty, Dock.Left);
                    checkText.SetValue(DockPanel.DockProperty, Dock.Left);
                    checkText.TextAlignment = TextAlignment.Left;
                    checkText.Text = OffText;
                }
            }
        }

        public readonly static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof(bool),
                typeof(OnOff),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, propertyChangedCallback));

        private static void propertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ((OnOff)(sender)).Value = (bool)(e.NewValue);
            }
            catch { }
        }

        private void checkBackground_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((Dock)checkCircle.GetValue(DockPanel.DockProperty) == Dock.Left)
            {
                Value = true;
            }
            else
            {
                Value = false;
            }
        }

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Value = false;
        //}
    }
}
