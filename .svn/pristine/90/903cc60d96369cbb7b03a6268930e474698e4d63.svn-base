using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Editors;

namespace ITSLIB
{
    public partial class ItsPageBase : Page
    {
        public DataTable LangTable = null;
        public HashSet<DependencyObject> ControlList = new HashSet<DependencyObject>();
        public Dictionary<DependencyObject, string> LangList = new Dictionary<DependencyObject, string>();

        public Grid ActiveGrid = null;
        public List<ITSLIB.Grid> GridList = new List<ITSLIB.Grid>();

        private string _gpcd = "";
        private string _ref01 = "";
        private string _ref02 = "";
        private string _ref03 = "";
        private string _ref04 = "";
        private string _ref05 = "";
        public ItsPageBase()
        {

            this.FontSize = 12d;

            // DevExpress.Xpf.Core.ThemeManager.SetThemeName(this, "DXStyle");
            // DevExpress.Xpf.Core.ThemeManager.SetThemeName(this, "Seven");
            // DevExpress.Xpf.Core.ThemeManager.SetThemeName(this, "Office2007Silver");
            // DevExpress.Xpf.Core.ThemeManager.SetThemeName(this, "Office2010Silver");
            // DevExpress.Xpf.Core.ThemeManager.SetThemeName(this, "Office2016Colorful");

            // DevExpress.Xpf.Core.ThemeManager.SetThemeName(this, "Office2013DarkGray");
            DevExpress.Xpf.Core.ThemeManager.SetTheme(this, DevExpress.Xpf.Core.Theme.Default);

            this.Loaded += ItsPageBase_Loaded;
            this.PreviewKeyDown += ItsPageBase_PreviewKeyDown;
        }

        protected void Refresh()
        {
            ItsElement.Refresh(this);
        }

        private void ItsPageBase_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void BdvHidden(ITSLIB.Combo combo)
        {
            if (ItsMemberShip.BDVCD != "")
            {
                combo.Value = ItsMemberShip.BDVCD;
            }
            else
            {
                combo.Value = "ERROR";
            }

            combo.Visibility = Visibility.Collapsed;
        }

        private bool _isBaseLoad = false;
        private void ItsPageBase_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= ItsPageBase_Loaded;

            if (_isBaseLoad == false)
            {
                _isBaseLoad = true;
            }
            else
            {
                return;
            }

            Frame frame = ItsElement.FindParent<Frame>(this);
            if (frame == null)
            {
                if (!System.IO.Directory.Exists("..\\AAALIB"))
                {
                    ItsMsgBox.Show("단독 페이지는 직접 실행할 수 없습니다.");
                    Window win = (Window)this.Parent;
                    win.Close();
                }
            }

            //List<ITSLIB.Grid> GridList = ItsElement.FindChild<ITSLIB.Grid>(this);
            //foreach (ITSLIB.Grid grid in GridList)
            //{
            //    Stream steamStyle = new MemoryStream();
            //    grid.SaveLayoutToStream(steamStyle);
            //    steamStyle.Seek(0, SeekOrigin.Begin);

            //    StreamReader reader = new StreamReader(steamStyle);
            //    grid.InitStyle = reader.ReadToEnd();

            //    grid.LoadGridStyle();
            //}

            List<TextBox> textList = ItsElement.FindChild<TextBox>(this);
            foreach (TextBox textBox in textList)
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

        public void ShowCellCalc(decimal selCount, decimal numCount, decimal sumValue, decimal aveValue, decimal minValue, decimal maxValue)
        {
            PopContent popup = ItsElement.FindByName(this, "POP_CELL_CALC") as PopContent;

            (ItsElement.FindByName(popup, "CELLINFO_SEL_COUNT") as Number).Value = selCount;
            (ItsElement.FindByName(popup, "CELLINFO_NUM_COUNT") as Number).Value = numCount;
            (ItsElement.FindByName(popup, "CELLINFO_SUM_VALUE") as Number).Value = sumValue;
            (ItsElement.FindByName(popup, "CELLINFO_AVE_VALUE") as Number).Value = aveValue;
            (ItsElement.FindByName(popup, "CELLINFO_MIN_VALUE") as Number).Value = minValue;
            (ItsElement.FindByName(popup, "CELLINFO_MAX_VALUE") as Number).Value = maxValue;

            popup.Show();
        }

        private ITSLIB.Grid grid = null;
        private ItsModelGrid MODEL_GRID;
        private TextEdit edit;
        public void ShowPopColumn(TextEdit textEdit, string gpcd, string ref01, string ref02, string ref03, string ref04, string ref05)
        {
            _gpcd = gpcd;
            _ref01 = ref01;
            _ref02 = ref02;
            _ref03 = ref03;
            _ref04 = ref04;
            _ref05 = ref05;

            PopContent popup = ItsElement.FindByName(this, "POPCOLUMN_pop") as PopContent;
            if (popup != null)
            {
                popup.Show();
                popup.HiddenTitle();

                TextBox textBox = ItsElement.FindChild<TextBox>(popup)[0] as TextBox;
                textBox.KeyUp -= TextBox_KeyUp;
                textBox.KeyUp += TextBox_KeyUp;
                textBox.TextChanged -= TextBox_TextChanged;
                textBox.TextChanged += TextBox_TextChanged;

                edit = textEdit;
                textBox.Text = textEdit.Text;

                popup.PlacementTarget = textEdit;
                popup.Placement = PlacementMode.Bottom;

                System.Windows.Controls.Grid GridPanel = ItsElement.FindChild<System.Windows.Controls.Grid>(popup)[0];

                UserControl pop_icon = ItsElement.FindByName(GridPanel, "POPCOLUMN_Icon") as UserControl;
                pop_icon.MouseUp -= Pop_icon_MouseUp;
                pop_icon.MouseUp += Pop_icon_MouseUp;

                UserControl btn_select = ItsElement.FindByName(GridPanel, "POPCOLUMN_Select") as UserControl;
                btn_select.MouseUp -= Btn_select_MouseUp;
                btn_select.MouseUp += Btn_select_MouseUp;

                UserControl btn_clear = ItsElement.FindByName(GridPanel, "POPCOLUMN_Clear") as UserControl;
                btn_clear.MouseUp -= Btn_clear_MouseUp;
                btn_clear.MouseUp += Btn_clear_MouseUp;

                UserControl btn_close = ItsElement.FindByName(GridPanel, "POPCOLUMN_Close") as UserControl;
                btn_close.MouseUp -= Btn_close_MouseUp;
                btn_close.MouseUp += Btn_close_MouseUp;

                StringBuilder queryheader = new StringBuilder();
                queryheader.Append("CALL DC_POP('" + gpcd + "_HEAD', '', '', '', '', '', '');");
                DataSet dsheader = ItsMaria.Query(queryheader.ToString());

                grid = ItsElement.FindChild<ITSLIB.Grid>(popup)[0];
                while (grid.Columns.Count > 1)
                {
                    grid.Columns.RemoveAt(1);
                }
                MODEL_GRID = new ItsModelGrid();
                MODEL_GRID.Binding(grid);
                MODEL_GRID.CellType("CODE", ItsEnums.CellTypes.Text);
                MODEL_GRID.CellType("NAME", ItsEnums.CellTypes.Text);
                MODEL_GRID.CellType("REF01", ItsEnums.CellTypes.Text);
                MODEL_GRID.CellType("REF02", ItsEnums.CellTypes.Text);
                MODEL_GRID.CellType("REF03", ItsEnums.CellTypes.Text);
                MODEL_GRID.CellType("REF04", ItsEnums.CellTypes.Text);
                MODEL_GRID.CellType("REF05", ItsEnums.CellTypes.Text);

                for (int i = 0; i < dsheader.Tables[0].Columns.Count; i++)
                {
                    ITSLIB.Column column = new ITSLIB.Column();
                    column.Header = dsheader.Tables[0].Rows[0][i].ToString();
                    column.Width = new GridColumnWidth(double.Parse(dsheader.Tables[1].Rows[0][i].ToString()));
                    column.FieldName = dsheader.Tables[0].Columns[i].ColumnName;
                    grid.Columns.Add(column);
                }
                grid.MouseDoubleClick -= Grid_MouseDoubleClick;
                grid.MouseDoubleClick += Grid_MouseDoubleClick;

                textBox.Select(textBox.Text.Length, 0);
                textBox.Focus();

                TextBox_KeyUp(textBox, null);

                grid.SelectionMode = MultiSelectMode.None;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _popup_select = false;
        }

        private void Grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_select_MouseUp(sender, null);
        }

        private void Pop_icon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TextBox_KeyUp(null, null);
        }

        private void Btn_close_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PopContent popup = ItsElement.FindParent<PopContent>(sender);
            if (popup != null)
            {
                popup.Close();
            }
        }
         
        private void Btn_clear_MouseUp(object sender, MouseButtonEventArgs e)
        {

            Btn_close_MouseUp(sender, null);

            edit.Text = "";
            ITSLIB.Grid pGrid = ItsElement.FindParent<ITSLIB.Grid>(edit);
            pGrid.View.PostEditor();
        }

        private void Btn_select_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string sCODE = "";
            try
            {
                sCODE = (grid.SelectedItem as DataRowView).Row["CODE"].ToString();
            }
            catch
            {
                if (grid.RowCount > 0)
                {
                    sCODE = grid.GetRowData(0)["CODE"].ToString();
                }
            }

            Btn_close_MouseUp(sender, null);

            if (sCODE != "")
            {
                edit.EditValue = sCODE;

                ITSLIB.Grid pGrid = ItsElement.FindParent<ITSLIB.Grid>(edit);
                pGrid.View.PostEditor();
            }
        }

        private bool _popup_select = false;
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e == null || e.Key == Key.Enter)
            {

                if (e != null && e.Key == Key.Enter && _popup_select)
                {
                    Btn_select_MouseUp(sender, null);
                    return;
                }

                string keyword = "";
                PopContent popup = ItsElement.FindByName(this, "POPCOLUMN_pop") as PopContent;
                if (popup != null)
                {
                    TextBox textBox = ItsElement.FindChild<TextBox>(popup)[0] as TextBox;
                    keyword = textBox.Text.Trim();
                }

                StringBuilder query = new StringBuilder();
                query.Append("CALL DC_POP('" + _gpcd + "_LIST', '" + keyword + "', '");
                query.Append(_ref01 + "', '");
                query.Append(_ref02 + "', '");
                query.Append(_ref03 + "', '");
                query.Append(_ref04 + "', '");
                query.Append(_ref05 + "');");
                DataTable dt = ItsMaria.Query(query.ToString()).Tables[0];
                MODEL_GRID.SetData(dt);

                try
                {
                    ITSLIB.Grid grid = MODEL_GRID.TargetGrid as ITSLIB.Grid;
                    grid.SelectedItem = MODEL_GRID.DefaultView[0];
                    grid.CurrentItem = grid.SelectedItem;
                }
                catch { }

                return;
            }
            else if (e.Key == Key.Up)
            {
                if (grid.GetIndex() > 0)
                {
                    grid.SelectedItem = MODEL_GRID.DefaultView[grid.GetIndex() - 1];
                    grid.CurrentItem = grid.SelectedItem;
                }

                TextBox textCode = sender as TextBox;
                textCode.Select(textCode.Text.Length, 0);
                textCode.Focus();

                _popup_select = true;

                return;
            }
            else if (e.Key == Key.Down)
            {
                if (grid.GetIndex() < grid.RowCount - 1)
                {
                    grid.SelectedItem = MODEL_GRID.DefaultView[grid.GetIndex() + 1];
                    grid.CurrentItem = grid.SelectedItem;
                }

                TextBox textCode = sender as TextBox;
                textCode.Select(textCode.Text.Length, 0);
                textCode.Focus();

                _popup_select = true;

                return;
            }
        }

        public virtual void EventPageLoaded()
        {

        }

        public virtual void EventFileUpload(string xName, string fileKey)
        {

        }

        public virtual void EventFileDelete(string xName, string fileKey)
        {

        }

        public virtual void EventCommand(string commandName)
        {

        }

        /// <summary>
        /// LoadMenu 로 화면 이동 시 매번 호출된다. (이미 열린 화면도 포함)
        /// </summary>
        public virtual void EventMenuParam(Dictionary<string, string> param)
        {

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
