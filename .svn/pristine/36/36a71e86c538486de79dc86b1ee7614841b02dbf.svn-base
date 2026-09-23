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
using DevExpress.Xpf.Core;

namespace ITSLIB
{
    public partial class ItsWinBase : DXWindow
    {
        public DataTable LangTable = null;
        public HashSet<DependencyObject> ControlList = new HashSet<DependencyObject>();
        public Dictionary<DependencyObject, string> LangList = new Dictionary<DependencyObject, string>();

        public ItsWinBase()
        {
            this.Background = Brushes.White;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStyle = WindowStyle.ToolWindow;
            this.Loaded += ItsWinBase_Loaded;
            this.PreviewKeyDown += ItsWinBase_PreviewKeyDown;
        }

        private void ItsWinBase_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.Enter))
            {
                e.Handled = true;

                try
                {
                    ItsQueryWin QUERYWIN = new ItsQueryWin();
                    QUERYWIN.ShowDialog();
                }
                catch
                {

                }
            }
        }

        private void ItsWinBase_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= ItsWinBase_Loaded;

            this.Title = "::: " + this.Title + " :::";
            List<TextBox> textList = ItsElement.FindChild<TextBox>(this);
            foreach(TextBox textBox in textList)
            {
                if (textBox.IsReadOnly == false)
                {
                    textBox.Focus();
                    break;
                }
            }

            LangTable = ItsLang.GetLangTable(this.Name);
            ItsLang.AddLangControl(ControlList, LangTable, this.Name, this);
            ItsLang.LangPage(ControlList, LangList, LangTable);
        }

        protected void Refresh()
        {
            ItsElement.Refresh(this);
        }

        public virtual void EventFileUpload(string xName, string fileKey)
        {

        }

        public virtual void EventFileDelete(string xName, string fileKey)
        {

        }

        public virtual void EventCommand(string commandName)
        {
            //if (commandName == "SAVE")
            //{
            //    MessageBox.Show("FDSAFDS");
            //}
        }

        private Dictionary<string, object> _PopValue = new Dictionary<string, object>();
        public void SetValue(string name, object value)
        {
            if (_PopValue.Keys.Contains(name))
            {
                _PopValue[name] = value;
            }
            else
            {
                _PopValue.Add(name, value);
            }
        }
        public object GetValue(string name)
        {
            if (_PopValue.Keys.Contains(name))
            {
                return _PopValue[name];
            }
            else
            {
                return "";
            }
        }
        public string GetText(string name)
        {
            return GetValue(name).ToString();
        }
        public int GetInt(string name)
        {
            return ItsString.ParseInt(GetValue(name));
        }
        public decimal GetDecimal(string name)
        {
            return ItsString.ParseDecimal(GetValue(name));
        }
        public DateTime GetDateTime(string name)
        {
            return ItsString.ParseDateTime(GetValue(name));
        }

        public void PopupDragMove(object sender, MouseButtonEventArgs e)
        {
            ItsHelper.POINT curPos;
            IntPtr hWndPopup;

            ItsHelper.GetCursorPos(out curPos);
            hWndPopup = ItsHelper.WindowFromPoint(curPos);

            ItsHelper.ReleaseCapture();
            ItsHelper.SendMessage(hWndPopup, ItsHelper.WM_NCLBUTTONDOWN, new IntPtr(ItsHelper.HT_CAPTION), IntPtr.Zero);
        }
    }
}
