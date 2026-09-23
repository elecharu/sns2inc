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
using ItsKeyPad;
using WindowsInput.Native;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class Number : UserControl
    {
        public ItsModelPanel ModelPanel = null;
        public Number()
        {
            InitializeComponent();
            ShowKeyPad = "";
        }

        public bool ReadOnly
        {
            get { return numericBox.IsReadOnly; }
            set
            {
                numericBox.IsReadOnly = value;
                if (value)
                {
                    numericBox.Background = new BrushConverter().ConvertFrom("#ECECEC") as SolidColorBrush;
                    numericBox.ShowEditorButtons = false;
                }
                else
                {
                    numericBox.Background = Brushes.White;
                    numericBox.ShowEditorButtons = true;
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

        public decimal MaxValue
        {
            get { return (decimal)numericBox.MaxValue; }
            set { numericBox.MaxValue = value; }
        }

        public decimal MinValue
        {
            get { return (decimal)numericBox.MinValue; }
            set { numericBox.MinValue = value; }
        }

        public int DecimalPoint
        {
            get
            {
                int index = numericBox.Mask.IndexOf(".");
                if (index == -1) return 0;
                else
                {
                    return numericBox.Mask.Substring(index + 1).Length;
                }
            }
            set
            {
                if (value == 0)
                {
                    numericBox.Mask = "###,###,###,##0";
                }
                else
                { 
                    numericBox.Mask = "###,###,###,##0." + "0000000000".Substring(0, value);
                }
                numericBox.DisplayFormatString = numericBox.Mask;
            }
        }

        public string Unit
        {
            get
            {
                if (textUnit.Text == "") return "";
                else return textBlock.Text;
            }
            set { textUnit.Text = value; }
        }
        public decimal Value
        {
            get { return (decimal)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public readonly static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value",
                typeof(decimal),
                typeof(Number),
                new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, propertyChangedCallback));
        private static void propertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((Number)(sender)).numericBox.Value = decimal.Parse(e.NewValue.ToString());
        }

        public string ShowKeyPad
        {
            set
            {
                if (value.Length > 0)
                {
                    keyPadIcon.MaxWidth = 1000;
                    canvas.Visibility = Visibility.Visible;
                }
                else
                {
                    keyPadIcon.MaxWidth = 0;
                    canvas.Visibility = Visibility.Hidden;
                }
            }
        }

        private void numericBox_GotFocus(object sender, RoutedEventArgs e)
        {
            numericBox.BorderBrush = Brushes.Black;
            numericBox.BorderThickness = new Thickness(1.5d);
            if (!numericBox.IsReadOnly)
            {
                numericBox.Background = Brushes.MintCream;
            }
        }

        private void numericBox_LostFocus(object sender, RoutedEventArgs e)
        {
            numericBox.BorderBrush = Brushes.Silver;
            numericBox.BorderThickness = new Thickness(1d);
            if (!numericBox.IsReadOnly)
            {
                numericBox.Background = Brushes.White;
            }
        }

        private void numericBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numericBox.SelectionStart = 0;
            numericBox.SelectionLength = 100;
        }

        private void KEY_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            numericBox.Focus();

            string keyCode = (e.Source as Label).Content.ToString();

            if (keyCode == "1") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD1); 
            else if (keyCode == "2") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD2);
            else if (keyCode == "3") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD3);
            else if (keyCode == "4") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD4);
            else if (keyCode == "5") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD5);
            else if (keyCode == "6") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD6);
            else if (keyCode == "7") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD7);
            else if (keyCode == "8") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD8);
            else if (keyCode == "9") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD9);
            else if (keyCode == "0") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.NUMPAD0);
            else if (keyCode == ".") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.DECIMAL);
            else if (keyCode == "Delete") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            else if (keyCode == "Backspace") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.BACK);
            else if (keyCode == "◀") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.LEFT);
            else if (keyCode == "▶") InputSimulatorStatic.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            else if (keyCode == "Clear")
            {
                if (numericBox.MinValue < 0m)
                {
                    numericBox.Value = 0;
                }
                else
                {
                    numericBox.Value = (decimal)numericBox.MinValue;
                }
                numericBox_MouseDoubleClick(null, null);
            }
            else if (keyCode == "✖")
            {
                popup.IsOpen = false;
            }
            else
            {
                ItsMsgBox.Show("키코드가 정의되지 않았습니다. ");
            }

            numericBox.Focus();
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            popup.IsOpen = true;
            numericBox.Focus();
        }

        public new bool IsFocused
        {
            get
            {
                return numericBox.IsFocused;
            }
        }

        private void numericBox_ValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            //try
            //{
                SetValue(ValueProperty, numericBox.Value);
            //}
            //catch
            //{
            //    ItsMsgBox.Show("입력값이 범위를 초과했습니다.");
            //    return;
            //}
            if (numericBox.Value < numericBox.MinValue)
            {
                ItsMsgBox.Show("최소값을 초과하였습니다.");
                numericBox.Value = (decimal)(numericBox.MinValue);
                numericBox.Focus();
            }

            if (numericBox.Value > numericBox.MaxValue)
            {
                ItsMsgBox.Show("최대값을 초과하였습니다.");
                numericBox.Value = (decimal)(numericBox.MaxValue);
                numericBox.Focus();
            }

            if (numericBox.Value < 0m)
            {
                numericBox.Foreground = Brushes.Red;
            }
            else
            {
                numericBox.Foreground = Brushes.Black;
            }
        }
    }
}
