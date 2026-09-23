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
using System.Windows.Input.Test;
using System.Reflection;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class Pass : UserControl
    {
        public ItsModelPanel ModelPanel = null;
        public Pass()
        {
            InitializeComponent();
            passBox.BorderBrush = Brushes.Silver;
            passBox.BorderThickness = new Thickness(1d);
        }

        public new bool IsFocused
        {
            get
            {
                return passBox.IsFocused;
            }
        }

        public void SetFocus()
        {
            passBox.SelectAll();
            passBox.Focus();
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

        public void CloseKeypad()
        {
            keypop.IsOpen = false;
        }

        public string Unit
        {
            get { return textUnit.Text; }
            set { textUnit.Text = value; }
        }

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public readonly static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof(string),
                typeof(Pass),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, valueChangedCallback));
        private static void valueChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((Pass)(sender)).passBox.Password = e.NewValue.ToString();
        }

        private void passBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passBox.BorderBrush = Brushes.Black;
            passBox.BorderThickness = new Thickness(1.5d);
            passBox.Background = Brushes.MintCream;

            if (_inputType == ItsEnums.InputTypes.Alphabat)
            {
                InputMethod.SetPreferredImeConversionMode(passBox, ImeConversionModeValues.Alphanumeric);
            }
            else if (_inputType == ItsEnums.InputTypes.Native)
            {
                InputMethod.SetPreferredImeConversionMode(passBox, ImeConversionModeValues.Native);
            }

            if (_ShowKeyPad) keypop.IsOpen = true;
        }

        private void passBox_LostFocus(object sender, RoutedEventArgs e)
        {
            passBox.BorderBrush = Brushes.Silver;
            passBox.Background = Brushes.White;
 
            keypop.IsOpen = false;
        }

        private void passBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            passBox.SelectAll();
        }

        private bool _ShowKeyPad = false;
        public string ShowKeyPad
        {
            set
            {
                if (value.Length > 0)
                {
                    _ShowKeyPad = true;
                }
                else
                {
                    _ShowKeyPad = false;
                }
            }
        }

        private ItsEnums.InputTypes _inputType = ItsEnums.InputTypes.Alphabat;
        public ItsEnums.InputTypes InputType
        {
            get
            {
                return _inputType;
            }
            set
            {
                _inputType = value;
            }
        }

        private void KEY_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            passBox.Focus();

            e.Handled = true;

            string keyCode = (e.Source as Label).Content.ToString();

            if (keyCode == "공백") SendKeys.Send(passBox, " ");
            else if (keyCode == "삭제") SendKeys.Send(passBox, "{BACKSPACE}");
            else if (keyCode == "◀") SendKeys.Send(passBox, "{LEFT}");
            else if (keyCode == "▶") SendKeys.Send(passBox, "{RIGHT}");
            else if (keyCode == "전부삭제")
            {
                passBox.Password = "";
            }
            else if (keyCode == "✖")
            {
                keypop.IsOpen = false;
            }
            else if (keyCode == "대")
            {
                DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender as Label);
                List<Label> labelList = ItsElement.FindChild<Label>(dockPanel);
                foreach(Label label in labelList)
                {
                    if (label.Content.ToString().Length == 1)
                    {
                        label.Content = label.Content.ToString().ToUpper();
                    }
                }
            }
            else if (keyCode == "소")
            {
                DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender as Label);
                List<Label> labelList = ItsElement.FindChild<Label>(dockPanel);
                foreach (Label label in labelList)
                {
                    if (label.Content.ToString().Length == 1)
                    {
                        label.Content = label.Content.ToString().ToLower();
                    }
                }
            }
            else if (keyCode == "특")
            {
                DockPanel dockPanel = ItsElement.FindParent<DockPanel>(sender as Label);
                List<Label> labelList = ItsElement.FindChild<Label>(dockPanel);
                foreach (Label label in labelList)
                {
                    if (label.Content.ToString().Length == 1 && "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789◀▶대소특삭제전부삭제공백✖".IndexOf(label.Content.ToString().ToUpper()) == -1)
                    {
                        if (label.Content.ToString() == "+") label.Content = "[";
                        else if (label.Content.ToString() == "-") label.Content = "]";
                        else if (label.Content.ToString() == "*") label.Content = "(";
                        else if (label.Content.ToString() == "/") label.Content = ")";

                        else if (label.Content.ToString() == "=") label.Content = ":";
                        else if (label.Content.ToString() == "?") label.Content = ";";

                        else if (label.Content.ToString() == "~") label.Content = "_";
                        else if (label.Content.ToString() == "!") label.Content = "&";
                        else if (label.Content.ToString() == "@") label.Content = "{";
                        else if (label.Content.ToString() == "#") label.Content = "}";
                        else if (label.Content.ToString() == "$") label.Content = ".";
                        else if (label.Content.ToString() == "%") label.Content = ",";

                        else if (label.Content.ToString() == "^") label.Content = "`";

                        // 역으로 교체
                        else if (label.Content.ToString() == "[") label.Content = "+";
                        else if (label.Content.ToString() == "]") label.Content = "-";
                        else if (label.Content.ToString() == "(") label.Content = "*";
                        else if (label.Content.ToString() == ")") label.Content = "/";

                        else if (label.Content.ToString() == ":") label.Content = "=";
                        else if (label.Content.ToString() == ";") label.Content = "?";

                        else if (label.Content.ToString() == "_") label.Content = "~";
                        else if (label.Content.ToString() == "&") label.Content = "!";
                        else if (label.Content.ToString() == "{") label.Content = "@";
                        else if (label.Content.ToString() == "}") label.Content = "#";
                        else if (label.Content.ToString() == ".") label.Content = "$";
                        else if (label.Content.ToString() == ",") label.Content = "%";

                        else if (label.Content.ToString() == "`") label.Content = "^";


                        else label.Content = "";
                    }
                }
            }
            else
            {
                passBox.Password = passBox.Password + keyCode;
            }

            passBox.Focus();
            passBox.GetType()
                .GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(passBox, new object[] { passBox.Password.Length, 0 });
        }

        private void passBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_ShowKeyPad) keypop.IsOpen = true;
        }

        private void passBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (_ShowKeyPad) keypop.IsOpen = !keypop.IsOpen;     
            }
        }

        private void passBox_TextChanged(object sender, RoutedEventArgs e)
        {
            SetValue(ValueProperty, passBox.Password);
            passBox.Focus();
            passBox.GetType()
                    .GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(passBox, new object[] { passBox.Password.Length, 0 });
            if (this.ModelPanel != null) this.ModelPanel.AcceptChanges();
        }
    }
}
