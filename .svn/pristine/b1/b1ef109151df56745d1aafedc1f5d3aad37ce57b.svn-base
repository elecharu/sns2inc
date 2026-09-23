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
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Grid;
using System.Drawing;

namespace ITSLIB
{
    public partial class ItsPageOffice : ItsPageBase
    {
        public MainWindow MainWindow = null;

        public ItsPageOffice()
        {
            this.Loaded += ItsPageOffice_Loaded;
        }

        private bool _isLoad = false;
        private void ItsPageOffice_Loaded(object sender, RoutedEventArgs e)
        {

            //if (!System.IO.Directory.Exists("..\\AAALIB"))
            //{
            //    ItsMsgBox.Show("단독 페이지는 직접 실행할 수 없습니다.");

            //    Window win = (Window)this.Parent;
            //    win.Close();
            //}

            this.Loaded -= ItsPageOffice_Loaded;

            if (this.Style == null)
            {
                this.Style = (Style)FindResource("OFFICE");
            }

            try
            {
                if (!ItsMemberShip.AutSearch(this.Name))
                {
                    (ItsElement.FindByName(this, "COMMON_BUTTON_SEARCH") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
                }

                if (!ItsMemberShip.AutAdd(this.Name))
                {
                    (ItsElement.FindByName(this, "COMMON_BUTTON_ADD") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
                }

                if (!ItsMemberShip.AutSave(this.Name))
                {
                    (ItsElement.FindByName(this, "COMMON_BUTTON_SAVE") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
                }

                if (!ItsMemberShip.AutDelete(this.Name))
                {
                    (ItsElement.FindByName(this, "COMMON_BUTTON_DELETE") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
                }

                if (!ItsMemberShip.AutPrint(this.Name))
                {
                    (ItsElement.FindByName(this, "COMMON_BUTTON_PRINT") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
                }

                if (!ItsMemberShip.AutPreview(this.Name))
                {
                    (ItsElement.FindByName(this, "COMMON_BUTTON_PREVIEW") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
                }

                if (!ItsMemberShip.AutCapture(this.Name))
                {
                    (ItsElement.FindByName(this, "COMMON_BUTTON_CAPTURE") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
                }

                if (!ItsMemberShip.AutExport(this.Name))
                {
                    (ItsElement.FindByName(this, "COMMON_BUTTON_EXPORT") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
                }
            }
            catch { }

            this.EventPageLoaded();

            //if (_isLoad == false)
            //{
            //    if (this.Style == null)
            //    {
            //        this.Style = (Style)FindResource("OFFICE");
            //    }

            //    try
            //    {
            //        if (!ItsMemberShip.AutSearch(this.Name))
            //        {
            //            (ItsElement.FindByName(this, "COMMON_BUTTON_SEARCH") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
            //        }

            //        if (!ItsMemberShip.AutAdd(this.Name))
            //        {
            //            (ItsElement.FindByName(this, "COMMON_BUTTON_ADD") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
            //        }

            //        if (!ItsMemberShip.AutSave(this.Name))
            //        {
            //            (ItsElement.FindByName(this, "COMMON_BUTTON_SAVE") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
            //        }

            //        if (!ItsMemberShip.AutDelete(this.Name))
            //        {
            //            (ItsElement.FindByName(this, "COMMON_BUTTON_DELETE") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
            //        }

            //        if (!ItsMemberShip.AutPrint(this.Name))
            //        {
            //            (ItsElement.FindByName(this, "COMMON_BUTTON_PRINT") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
            //        }

            //        if (!ItsMemberShip.AutPreview(this.Name))
            //        {
            //            (ItsElement.FindByName(this, "COMMON_BUTTON_PREVIEW") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
            //        }

            //        if (!ItsMemberShip.AutCapture(this.Name))
            //        {
            //            (ItsElement.FindByName(this, "COMMON_BUTTON_CAPTURE") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
            //        }

            //        if (!ItsMemberShip.AutExport(this.Name))
            //        {
            //            (ItsElement.FindByName(this, "COMMON_BUTTON_EXPORT") as ButtonCommon).FontColor = new SolidColorBrush(Colors.Silver);
            //        }
            //    }
            //    catch { }

            //    this.EventPageLoaded();
            //    _isLoad = true;
            //}
        }

        public virtual void EventSearch()
        {

        }

        public virtual void EventAdd()
        {

        }

        public virtual void EventSave()
        {

        }
        public virtual void EventDelete()
        {

        }
        public virtual void EventPrint()
        {
            if (this.ActiveGrid == null) return;

            TableView view = this.ActiveGrid.View as TableView;
            if (view == null) return;
            view.PrintAutoWidth = false;
            view.ShowPrintPreviewDialog(null);
        }

        private bool _IsCapture = false;
        public virtual void EventCapture()
        {
            if (!_IsCapture)
            {
                _IsCapture = true;
                CaptureForm capForm = new CaptureForm();
                                
                if (this.MainWindow.WindowState == WindowState.Maximized)
                {
                    capForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                }
                else
                {
                    capForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                    capForm.Width = (int)(this.MainWindow.Width);
                    capForm.Height = (int)(this.MainWindow.Height);
                    capForm.Left = (int)(this.MainWindow.Left);
                    capForm.Top = (int)(this.MainWindow.Top);
                }

                Bitmap btmCap = new Bitmap((int)(this.MainWindow.Width), (int)(this.MainWindow.Height));
                Graphics g = Graphics.FromImage(btmCap);

                System.Windows.Point point = this.MainWindow.PointToScreen(new System.Windows.Point(0, 0));
                System.Drawing.Point startPoint = new System.Drawing.Point((int)point.X, (int)point.Y);
                g.CopyFromScreen(startPoint, new System.Drawing.Point(0, 0), new System.Drawing.Size((int)(this.MainWindow.Width), (int)(this.MainWindow.Height)));

                capForm.pictureBox1.Image = btmCap;
                capForm.FILENAME = this.Name;
                capForm.ShowDialog();
                _IsCapture = false;
            }
        }

        public string PrgTitle
        {
            get
            {
                try
                {
                    foreach (object item in MainWindow.TAB_MAIN.Items)
                    {
                        DevExpress.Xpf.Core.DXTabItem tabItem = item as DevExpress.Xpf.Core.DXTabItem;
                        if (tabItem.Tag.ToString().ToUpper().IndexOf(this.Name.ToUpper()) > -1)
                        {
                            return tabItem.Header.ToString();
                        }
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
        }

        public virtual void EventExport()
        {
            if (this.ActiveGrid == null) return;

            System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFile.RestoreDirectory = true;

            try
            {
                saveFile.FileName = this.Name + "_" + this.ActiveGrid.Name;
            }
            catch
            {
                saveFile.FileName = "Export Form";
            }

            saveFile.DefaultExt = "xlsx";
            saveFile.Filter = "MS Excel (*.xlsx)|*.xlsx|PDF File (*.pdf)|*.pdf";
            saveFile.FilterIndex = 0;
            saveFile.ShowDialog();

            // 저장 경로가 없을 경우 빠져나가기
            if (saveFile.FileName.IndexOf(":\\") == -1)
            {
                return;
            }

            try
            {
                // 저장 유형에 따라 이미지 저장
                if (saveFile.FileName.ToLower().IndexOf(".xlsx") > -1)
                {
                    TableView view = this.ActiveGrid.View as TableView;
                    if (view == null) return;
                    view.ExportToXlsx(saveFile.FileName);
                }
                else if (saveFile.FileName.IndexOf(".pdf") > -1)
                {
                    TableView view = this.ActiveGrid.View as TableView;
                    if (view == null) return;
                    view.ExportToPdf(saveFile.FileName);
                }

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = saveFile.FileName;
                proc.Start();

            }
            catch
            {

            }
        }
    }
}
