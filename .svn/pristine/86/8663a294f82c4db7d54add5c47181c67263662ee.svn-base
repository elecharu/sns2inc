using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelDesign
{
    public partial class DesignForm : Form
    {
        public string LABELCD = "";

        public DesignForm()
        {
            InitializeComponent();
        }

        private enum Headers
        {
            LABELCD, LABELNM, WorkGroup, WorkGroupNM, KEYWORD,
            BARCD, VERSION, BARNM, GONGCD,
            PAPERSIZE, BCDTYPE1, BCDTYPE2, BCDTYPE3, XMLDATA, PREVIEW, REMARK,
            PAGEWIDTH, PAGEHEIGHT, GONGNM
        }

        #region ###### 바코드 에디터 관련 코드

        private void DesignForm_Load(object sender, EventArgs e)
        {
            if (LABELCD == "")
            {
                MessageBox.Show("라벨코드가 지정되지 않았습니다.");
                this.Close();
            }

            ItsMaria.Set("SYS0301_R01", "INFO_XMLDATA");
            ItsMaria.AddOne("LABELCD", LABELCD);
            DataSet ds = ItsMaria.Call();
            itsBarcodeEditor_Main.LoadFromXml(ItsData.GetText(ds.Tables[0], 0, "XMLDATA"));
            propertyGrid_Barcode.SelectedObject = itsBarcodeEditor_Main.SelectedObject;
            toolStripComboBox_Zoom.Text = "200 %";
        }

        private void itsBarcodeEditor_Main_SelectedCmdChanged(object sender, EventArgs e)
        {
            object selectedObj = itsBarcodeEditor_Main.SelectedObject;

            if (selectedObj == null)
                selectedObj = itsBarcodeEditor_Main.DocumentSetup;

            propertyGrid_Barcode.SelectedObject = selectedObj;
        }

        private void propertyGrid_Barcode_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            itsBarcodeEditor_Main.Invalidate();
        }

        private void itsBarcodeEditor_Main_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            propertyGrid_Barcode.Refresh();
        }

        private void toolStripButton_AddLine_Click(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.SelectedTool = ItsBarcodeEditor.Tools.LineTool;
        }

        private void toolStripButton_AddLine_DoubleClick(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.AddLine(0, 0, 10, 10);
        }

        private void toolStripButton_AddRect_Click(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.SelectedTool = ItsBarcodeEditor.Tools.RectangleTool;
        }

        private void toolStripButton_AddRect_DoubleClick(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.AddRectangle(0, 0, 10, 10);
        }

        private void toolStripButton_Circle_Click(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.SelectedTool = ItsBarcodeEditor.Tools.CircleTool;
        }

        private void toolStripButton_Circle_DoubleClick(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.AddCircle(0, 0, 10, 10);
        }

        private void toolStripButton_AddBarcode_Click(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.SelectedTool = ItsBarcodeEditor.Tools.BarcodeTool;
        }

        private void toolStripButton_AddBarcode_DoubleClick(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.AddBarcode("123456789", 0, 0, 10, 10);
        }

        private void toolStripButton_AddText_Click(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.SelectedTool = ItsBarcodeEditor.Tools.TextTool;
        }

        private void toolStripButton_AddText_DoubleClick(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.AddText("Text", 0, 0, 10, 10);
        }

        private void toolStripButton_AddImage_Click(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.SelectedTool = ItsBarcodeEditor.Tools.ImageTool;
        }

        private void toolStripButton_AddImage_DoubleClick(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillRectangle(Brushes.LightPink, new Rectangle(0, 0, 100, 100));
                g.DrawString("NO\nIMAGE", new Font(this.Font.FontFamily, 20), Brushes.White, new PointF(0, 0));
            }
            itsBarcodeEditor_Main.AddImage(image, 0, 0, 10, 10);
        }

        private bool _suppressZoomTextChangedEvent = false;
        private void toolStripComboBox_Zoom_TextChanged(object sender, EventArgs e)
        {
            string zoomText = toolStripComboBox_Zoom.Text;

            zoomText = zoomText.Replace("%", "").Replace(" ", "");
            if (_suppressZoomTextChangedEvent)
            {
                _suppressZoomTextChangedEvent = false;
                return;
            }

            itsBarcodeEditor_Main.Zoom = ((float)ItsString.ParseDecimal(zoomText)) / 100.0F;
        }

        private void itsBarcodeEditor_Main_ZoomChanged(object sender, EventArgs e)
        {
            _suppressZoomTextChangedEvent = true;
            toolStripComboBox_Zoom.Text = (itsBarcodeEditor_Main.Zoom * 100).ToString("0.##") + " %";
        }

        private void toolStripButton_Preview_Click(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.Preview();
        }

        private void toolStripButton_Print_Click(object sender, EventArgs e)
        {
            itsBarcodeEditor_Main.Print();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("저장하시겠습니까?", "ITSCO", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            ItsMaria.Set("SYS0301_R01", "UP_XMLDATA");
            ItsMaria.AddOne("LABELCD", LABELCD);
            ItsMaria.AddOne("XMLDATA", itsBarcodeEditor_Main.SaveToXml());
            ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                MessageBox.Show(ItsMaria.ErrMessage);
            }
            else
            {
                MessageBox.Show("저장되었습니다.");
            }

            // byte[] bytes = Encoding.UTF8.GetBytes(itsBarcodeEditor_Main.SaveToXml());
            // ItsFileDialog.SaveFile("PrintLabelData.xml", bytes);
        }

        private void toolStripButton_Open_Click(object sender, EventArgs e)
        {
            ItsFileDialog.FileInfo fi = ItsFileDialog.OpenFile("", "*.xml");

            if (fi.FilePath != "")
            {
                string xml = System.IO.File.ReadAllText(fi.FilePath);

                itsBarcodeEditor_Main.LoadFromXml(xml);
            }
        }

        private void toolStripButton_New_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("신규추가하시겠습니까?", "ITSCO", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            itsBarcodeEditor_Main.Clear();
            itsBarcodeEditor_Main.Invalidate();
        }

        public string GetBarcodeXml()
        {
            return itsBarcodeEditor_Main.SaveToXml();
        }

        #endregion

        /// <summary>
        /// ComMate: DataTable 바인딩
        /// </summary>
        public void Combo_AddItem(ComboBox ComboBox, DataTable dt, string allString)
        {
            DataTable newDt = dt.Copy();
            DataRow row = newDt.NewRow();
            row[0] = allString;
            row[1] = "";
            newDt.Rows.InsertAt(row, 0);

            ComboBox.DisplayMember = newDt.Columns[0].ColumnName;
            ComboBox.ValueMember = newDt.Columns[1].ColumnName;
            ComboBox.DataSource = newDt;
        }
        /// <summary>
        /// ComMate: DataTable 바인딩
        /// </summary>
        public void Combo_AddItem(ComboBox ComboBox, DataTable dt)
        {
            DataTable newDt = dt.Copy();

            ComboBox.DisplayMember = newDt.Columns[0].ColumnName;
            ComboBox.ValueMember = newDt.Columns[1].ColumnName;
            ComboBox.DataSource = newDt;
        }

        private void itsBarcodeEditor_Main_SelectedToolChanged(object sender, EventArgs e)
        {
            bool isBarcodeChecked = false;
            bool isImageChecked = false;
            bool isLineChecked = false;
            bool isRectChecked = false;
            bool isTextChecked = false;
            bool isCircleChecked = false;

            switch (itsBarcodeEditor_Main.SelectedTool)
            {
                case ItsBarcodeEditor.Tools.LineTool:
                    isLineChecked = true;
                    break;
                case ItsBarcodeEditor.Tools.BarcodeTool:
                    isBarcodeChecked = true;
                    break;
                case ItsBarcodeEditor.Tools.ImageTool:
                    isImageChecked = true;
                    break;
                case ItsBarcodeEditor.Tools.RectangleTool:
                    isRectChecked = true;
                    break;
                case ItsBarcodeEditor.Tools.CircleTool:
                    isCircleChecked = true;
                    break;
                case ItsBarcodeEditor.Tools.TextTool:
                    isTextChecked = true;
                    break;
                case ItsBarcodeEditor.Tools.ArrowTool:
                default:
                    // do nothing
                    break;
            }

            toolStripButton_AddBarcode.Checked = isBarcodeChecked;
            toolStripButton_AddImage.Checked = isImageChecked;
            toolStripButton_AddLine.Checked = isLineChecked;
            toolStripButton_AddRect.Checked = isRectChecked;
            toolStripButton_AddText.Checked = isTextChecked;
            toolStripButton_AddCircle.Checked = isCircleChecked;
        }

    }
}

