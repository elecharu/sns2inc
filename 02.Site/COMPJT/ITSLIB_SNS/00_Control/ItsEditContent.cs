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
using System.Data;

namespace ITSLIB
{
    public class EditContent : WrapPanel
    {
        public ItsModelPanel ModelPanel = null;
        public EditContent()
        {
            this.KeyDown += EditContent_KeyDown;
        }

        private void EditContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var uie = e.OriginalSource as UIElement;
                e.Handled = true;
                bool isMove = uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                if (isMove == false)
                {
                    uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                }
            }
        }

        private List<int> _width = new List<int>();
        private List<UIElement> _controlList = new List<UIElement>();
        public void AddColumn(string header, int width)
        {
            _width.Add(width);

            UserControl uc = new UserControl();
            uc.VerticalContentAlignment = VerticalAlignment.Center;
            uc.HorizontalContentAlignment = HorizontalAlignment.Center;
            uc.Margin = new Thickness(1, 1, 0, 0);
            uc.Content = header;
            uc.Height = 25;
            uc.Width = width;
            uc.BorderThickness = new Thickness(1);
            uc.BorderBrush = Brushes.Black;
            uc.Background = Brushes.WhiteSmoke;
            this.Children.Add(uc);
        }

        public int RowCount
        {
            get
            {
                return _controlList.Count / _width.Count;
            }
        }

        public int ColumnCount
        {
            get
            {
                return _width.Count;
            }
        }

        public void Clear()
        {
            List<UIElement> delList = new List<UIElement>();
            for (int i = 0; i < this.Children.Count; i++)
            {
                if (i >= _width.Count)
                {
                    delList.Add(this.Children[i]);
                }
            }

            for (int i = 0; i < delList.Count; i++)
            {
                this.Children.Remove(delList[i]);
            }
            _controlList.Clear();
        }

        private void _AddLine()
        {
            if ((_controlList.Count + 1) % _width.Count == 1)
            {
                UserControl uc = new UserControl();
                uc.Width = 5000;
                uc.Height = 0;
                this.Children.Add(uc);
            }
        }

        public void AddLabelControl(string value)
        {
            _AddLine();

            Label lbl = new Label();
            lbl.Margin = new Thickness(1, 1, 0, 0);
            lbl.Padding = new Thickness(3);
            lbl.VerticalContentAlignment = VerticalAlignment.Center;
            lbl.HorizontalContentAlignment = HorizontalAlignment.Right;
            lbl.Width = _width[_controlList.Count % _width.Count];
            lbl.Content = value;
            this.Children.Add(lbl);

            _controlList.Add(lbl);
        }

        public void AddTextControl(string value)
        {
            _AddLine();

            Text text = new Text();
            text.Margin = new Thickness(1, 1, 0, 0);
            text.HidenLabel = "Y";
            text.Width = _width[_controlList.Count % _width.Count];
            text.Value = value;
            this.Children.Add(text);

            _controlList.Add(text);
        }

        public void AddNumberControl(int decimalPoint, bool ShowKeyPad, decimal value)
        {
            _AddLine();

            Number number = new Number();
            number.Margin = new Thickness(1, 1, 0, 0);
            number.DecimalPoint = decimalPoint;
            if (ShowKeyPad) number.ShowKeyPad = "Y";
            number.HidenLabel = "Y";
            number.Width = _width[_controlList.Count % _width.Count];
            number.Value = value;
            this.Children.Add(number);

            _controlList.Add(number);
        }

        public void AddCheckControl(bool value)
        {
            _AddLine();

            Check check = new Check();
            check.Margin = new Thickness(1, 1, 0, 0);
            check.HidenLabel = "Y";
            check.Width = _width[_controlList.Count % _width.Count];
            check.Value = value;
            this.Children.Add(check);

            _controlList.Add(check);
        }

        public void AddDateControl(string value)
        {
            _AddLine();

            Date date = new Date();
            date.Margin = new Thickness(1, 1, 0, 0);
            date.HidenLabel = "Y";
            date.Width = _width[_controlList.Count % _width.Count];
            date.Value = value;
            this.Children.Add(date);

            _controlList.Add(date);
        }

        public void AddTimeControl(string value)
        {
            _AddLine();

            Time time = new Time();
            time.Margin = new Thickness(1, 1, 0, 0);
            time.HidenLabel = "Y";
            time.Width = _width[_controlList.Count % _width.Count];
            time.Value = value;
            this.Children.Add(time);

            _controlList.Add(time);
        }

        public void AddPopControl(string value, string gpcd, params string[] refvalue)
        {
            _AddLine();

            Pop pop = new Pop();
            pop.Margin = new Thickness(1, 1, 0, 0);
            pop.HidenLabel = "Y";
            pop.Width = _width[_controlList.Count % _width.Count];
            if (refvalue.Length > 0) pop.REF01 = refvalue[0];
            if (refvalue.Length > 1) pop.REF02 = refvalue[1];
            if (refvalue.Length > 2) pop.REF03 = refvalue[2];

            pop.GPCD = gpcd;
            pop.Value = value;

            this.Children.Add(pop);

            _controlList.Add(pop);
        }

        public void AddComboControl(string value, string gpcd, params string[] refvalue)
        {
            _AddLine();

            Combo combo = new Combo();
            combo.Margin = new Thickness(1, 1, 0, 0);
            combo.HidenLabel = "Y";
            combo.Width = _width[_controlList.Count % _width.Count];
            if (refvalue.Length > 0) combo.REF01 = refvalue[0];
            if (refvalue.Length > 1) combo.REF02 = refvalue[1];
            if (refvalue.Length > 2) combo.REF03 = refvalue[2];

            combo.GPCD = gpcd;
            combo.Value = value;

            this.Children.Add(combo);

            _controlList.Add(combo);
        }

        public void AddComboControl(string value, DataTable itemSource)
        {
            _AddLine();

            Combo combo = new Combo();
            combo.Margin = new Thickness(1, 1, 0, 0);
            combo.HidenLabel = "Y";
            combo.Width = _width[_controlList.Count % _width.Count];

            combo.AddItem(itemSource);
            combo.Value = value;

            this.Children.Add(combo);
            _controlList.Add(combo);
        }

        public string GetText(int rowIndex, int columnIndex)
        {
            UIElement control = _controlList[rowIndex * ColumnCount + columnIndex];
            if (control is Label) return (control as Label).Content.ToString();
            if (control is Text) return (control as Text).Value;
            if (control is Date) return (control as Date).Value;
            if (control is Time) return (control as Time).Value;
            if (control is Pop) return (control as Pop).Value;
            if (control is Check) return (control as Check).Value.ToString();
            if (control is Combo) return (control as Combo).Value;
            if (control is Number) return (control as Number).Value.ToString();

            return "";
        }

        public decimal GetDecimal(int rowIndex, int columnIndex)
        {
            UIElement control = _controlList[rowIndex * ColumnCount + columnIndex];
            if (control is Number) return (control as Number).Value;
            
            return 0;
        }

        public int GetInt(int rowIndex, int columnIndex)
        {
            return (int)(GetDecimal(rowIndex, columnIndex));
        }

        public void Close()
        {
            ItsPageBase pageBase = ItsElement.FindParent<ItsPageBase>(this);
            if (pageBase != null)
            {
                List<Canvas> canvas = ItsElement.FindChild<Canvas>(pageBase);
                if (canvas.Count > 0) // 현장 화면일 경우 다른 레이어 살리기
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(canvas[0]); i++)
                    {
                        UserControl UC = VisualTreeHelper.GetChild(canvas[0], i) as UserControl;
                        if (UC != null) UC.IsEnabled = true;
                    }
                }
            }

            UserControl uc = ItsElement.FindParent<UserControl>(this);
            if (uc != null)
            {
                uc.Visibility = Visibility.Hidden;
                uc.MaxHeight = 0;
                uc.MaxWidth = 0;
            }
        }

        public void Show()
        {
            ItsPageBase pageBase = ItsElement.FindParent<ItsPageBase>(this);
            if (pageBase != null)
            {
                List<Canvas> canvas = ItsElement.FindChild<Canvas>(pageBase);
                if (canvas.Count > 0) // 현장 화면일 경우 다른 레이어 죽이기
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(canvas[0]); i++)
                    {
                        UserControl UC = VisualTreeHelper.GetChild(canvas[0], i) as UserControl;
                        if (UC != null) UC.IsEnabled = false;
                    }
                }
            }

            UserControl uc = ItsElement.FindParent<UserControl>(this);
            if (uc != null)
            {
                uc.Visibility = Visibility.Visible;
                uc.IsEnabled = true;

                uc.MaxHeight = 5000;
                uc.MaxWidth = 5000;
            }
        }
    }
}
