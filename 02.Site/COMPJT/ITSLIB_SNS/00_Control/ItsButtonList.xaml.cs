using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITSLIB
{
    /// <summary>
    /// ItsButtonList.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonList : UserControl
    {
        public ButtonList()
        {
            InitializeComponent();
        }
        private double _ButtonWidth = 0;
        private double _ButtonHeight = 0;
        // 2025-05-26 선택 버튼 색상 임의지정 PJH
        private Dictionary<string, string> _SelBtnColor = new Dictionary<string, string>();

        public double PanelWidth
        {
            get
            {
                return this.Width;
            }
            set
            {
                PANEL_BTNLIST.Width = value;
                this.Width = PANEL_BTNLIST.Width;
            }
        }

        public double PanelHeight
        {
            get
            {
                return this.Height;
            }
            set
            {
                PANEL_BTNLIST.Height = value;
                this.Height = PANEL_BTNLIST.Height;
            }
        }


        public string ButtonWidth
        {
            get { return _ButtonWidth.ToString(); }
            set { _ButtonWidth = double.Parse(value); }
        }
        public string ButtonHeight
        {
            get { return _ButtonHeight.ToString(); }
            set { _ButtonHeight = double.Parse(value); }
        }
        public string _ButtonBackColor = "Gray";
        public string ButtonBackColor
        {
            get { return _ButtonBackColor.ToString(); }
            set { _ButtonBackColor = value; }
        }

        public string _ButtonSelectBackColor = "IndianRed";
        public string ButtonSelectBackColor
        {
            get { return _ButtonSelectBackColor.ToString(); }
            set { _ButtonSelectBackColor = value; }
        }

        public string _commandName = "";
        public string CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        // 2025-05-26 지정된 값의 버튼색상 별도 지정 PJH
        public void SelectColor(string value, string color)
        {
            _SelBtnColor.Add(value, color);
        }

        // 2025-05-26 버튼 색상 별도 지정 PJH
        public void SetBackColor(string value, string color, bool twingkle)
        {
            foreach (DependencyObject control in PANEL_BTNLIST.Children)
            {
                if (control is ITSLIB.Button)
                {
                    ITSLIB.Button btn = control as ITSLIB.Button;

                    if (btn.Tag.ToString() == value)
                    {
                        BrushConverter a = new BrushConverter();
                        if ( btn.BackColor == a.ConvertFromString(color).ToString() && twingkle == true)
                            btn.BackColor = "Gray";
                        else
                            btn.BackColor = color;
                    }

                    btn.SetLeaveStyle();
                }
            }
        }

        public void AddLine()
        {
            UserControl uc = new UserControl();
            uc.Width = 5000;
            PANEL_BTNLIST.Children.Add(uc);
        }

        public void AddButton(string label, string value, params string[] addLabel)
        {
            foreach(string lbl in addLabel)
            {
                label = label + "\n" + lbl;
            }

            Button btn = new Button();
            btn.IsEnterBackChange = false;

            btn.Label = label;
            btn.Tag = value;

            if (_ButtonWidth > 0)
            {
                btn.textBlock.Width = _ButtonWidth - 12;
                btn.stackPanel.Width = _ButtonWidth - 6;
                btn.Width = _ButtonWidth;
            }
            if (_ButtonHeight > 0) btn.Height = _ButtonHeight;

            //btn.BackColor = _ButtonBackColor; 
            // 2025-05-26 지정된 색상이 있을 경우 다른색상으로 버튼색상 표기 PJH
            if (_SelBtnColor.ContainsKey(value))
                btn.BackColor = _SelBtnColor[value];
            else
                btn.BackColor = _ButtonBackColor;


            btn.MouseDown += Btn_MouseDown;
            PANEL_BTNLIST.Children.Add(btn);
        }

        public void SetBinding(DataTable dt)
        {
            this.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.AddButton(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
            }
        }

        public void Clear()
        {
            PANEL_BTNLIST.Children.Clear();
            _Value = "";
            _SelBtnColor.Clear();
        }

        private void Btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            ValueChange((sender as ITSLIB.Button).Tag.ToString());
        }

        private void ValueChange(string value)
        {
            foreach (DependencyObject control in PANEL_BTNLIST.Children)
            {
                if (control is ITSLIB.Button)
                {
                    ITSLIB.Button btn = control as ITSLIB.Button;
                    //btn.BackColor = _ButtonBackColor;
                    // 2025-05-26 지정된 색상이 있을 경우 다른색상으로 버튼색상 표기 PJH
                    if (_SelBtnColor.ContainsKey(btn.Tag.ToString()))
                        btn.BackColor = _SelBtnColor[btn.Tag.ToString()];
                    else
                        btn.BackColor = _ButtonBackColor;

                    if (btn.Tag.ToString() == value)
                    {
                        btn.BackColor = _ButtonSelectBackColor;
                        _Value = value;
                    }

                    btn.SetLeaveStyle();
                }
            }

            ItsPageBase pageBase = ItsElement.FindParent<ItsPageBase>(this);
            if (pageBase != null)
            {
                if (_commandName != "")
                {
                    pageBase.EventCommand("_commandName");
                }
                else
                {
                    pageBase.EventCommand(this.Name);
                }
            }
        }

        public string _Value = "";
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                ValueChange(value);
            }
        }

        public int Count
        {
            get
            {
                return PANEL_BTNLIST.Children.Count;
            }
        }
    }
}
