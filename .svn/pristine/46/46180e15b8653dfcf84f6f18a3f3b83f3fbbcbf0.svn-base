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
    public partial class Check : UserControl
    {
        public ItsModelPanel ModelPanel = null;
        public Check()
        {
            InitializeComponent();
        }
        public bool ReadOnly
        {
            get { return !checkBox.IsEnabled; }
            set
            {
                checkBox.IsEnabled = !value;
                if (value)
                {
                    checkBox.Background = new BrushConverter().ConvertFrom("#ECECEC") as SolidColorBrush;
                }
                else
                {
                    checkBox.Background = Brushes.White;
                }
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

        public double LabelWidth
        {
            get { return textBlock.Width; }
            set { textBlock.Width = value; }
        }

        public string Label
        {
            get { return textBlock.Text; }
            set { textBlock.Text = value; }
        }


        public double Size
        {
            get { return checkBox.Width; }
            set {
                checkBox.Width = value;
                textBlock.FontSize = value;
            }
        }

        public string Comment
        {
            get { return textComment.Text; }
            set { textComment.Text = value; }
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
            }
        }
        public readonly static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof(bool),
                typeof(Check),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, propertyChangedCallback));
        private static void propertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ((Check)(sender)).checkBox.IsChecked = (bool)e.NewValue;
            }
            catch { }
        }

        public new bool IsFocused
        {
            get
            {
                return checkBox.IsFocused;
            }
        }

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Value = false;
        //}

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (checkBox.IsEnabled == false) return;

            if (checkBox.IsChecked == true)
            {
                checkBox.IsChecked = false;
            }
            else
            {
                checkBox.IsChecked = true;
            }

            Value = (bool)checkBox.IsChecked;
        }

        private void checkBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (checkBox.IsEnabled == false) return;
            Value = (bool)checkBox.IsChecked;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            Value = (bool)checkBox.IsChecked;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Value = (bool)checkBox.IsChecked;
        }
    }
}
