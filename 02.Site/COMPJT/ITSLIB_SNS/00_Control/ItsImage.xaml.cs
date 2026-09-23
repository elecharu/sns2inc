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
using System.Windows.Forms;

namespace ITSLIB
{
    public partial class Image : System.Windows.Controls.UserControl
    {
        private static string emptyImage = "pack://application:,,,/ITSLIB;component/00_Resource/empty.png";
        public Image()
        {
            InitializeComponent();
            this.FileKey = "";
        }
        public string FileKey
        {
            get { return (string)GetValue(FileKeyProperty); }
            set { SetValue(FileKeyProperty, value); }
        }

        public readonly static DependencyProperty FileKeyProperty =
            DependencyProperty.Register("FileKey",
                typeof(string),
                typeof(Image),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, fileKeyChangedCallback));
        private static void fileKeyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string fileKey = e.NewValue.ToString();
            if (fileKey == "")
            {
                ((Image)(sender)).Source = "";
            }
            else
            {
                StringBuilder query = new StringBuilder("SELECT FILEURL('" + fileKey + "')");
                string fileUrl = ItsData.GetScalar(ItsMaria.Query(query.ToString()));

                ((Image)(sender)).Source = fileUrl;
            }
        }

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public readonly static DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
                typeof(string),
                typeof(Image),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, sourceChangedCallback));
        private static void sourceChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ImageSourceConverter imgConv = new ImageSourceConverter();
            try
            {
                ImageSource imgSource = (ImageSource)imgConv.ConvertFromString(e.NewValue.ToString());
                ((Image)(sender)).IMAGE.Source = imgSource;
                if (((Image)(sender)).IMAGE.Source.Width > 0)
                {
                    ((Image)(sender)).IMAGE.Stretch = Stretch.Uniform;
                    ((Image)(sender)).ERRMSG.Visibility = Visibility.Collapsed;
                    return;
                }
            }
            catch { }

            ImageSource imgSource2 = (ImageSource)imgConv.ConvertFromString(emptyImage);
            ((Image)(sender)).IMAGE.Source = imgSource2;
            ((Image)(sender)).IMAGE.Stretch = Stretch.None;

            if (e.NewValue.ToString() != "")
            {
                ((Image)(sender)).ERRMSG.Text = "Image Source: " + e.NewValue.ToString();
                ((Image)(sender)).ERRMSG.Visibility = Visibility.Visible;
            }
            else
            {
                ((Image)(sender)).ERRMSG.Visibility = Visibility.Collapsed;
            }
        }

        public string ShowButton
        {
            get
            {
                if (BUTTON.Visibility == Visibility.Visible) return "True";
                else return "False";
            }
            set
            {
                if (value.ToUpper() == "N" || value.ToUpper() == "False")
                {
                    BUTTON.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BUTTON.Visibility = Visibility.Visible;
                }
            }
        }

        private void OPEN_Click(object sender, RoutedEventArgs e)
        {
            if (this.FileKey != "")
            {
                ItsMsgBox.ShowErr("기존 이미지를 삭제하고 추가하세요.");
                return;
            }

            ItsFileDialog.FileInfo fInfo = ItsFileDialog.OpenFile(10, new string[] { "*.png", "*.jpg", "*.gif", "*.bmp" });
            if (fInfo.FilePath != "")
            {
                this.FileKey = "";
                this.Source = fInfo.FilePath;

                this.ERRMSG.Text = "이미지를 업로드하세요.";
                this.ERRMSG.Visibility = Visibility.Visible;
            } 
        }

        private void UPLOAD_Click(object sender, RoutedEventArgs e)
        {
            if (this.FileKey != "")
            {
                ItsMsgBox.ShowErr("이미지 바꾸기를 원하시면 기존 이미지를 삭제 및 신규 이미지를 추가하고 업로드하세요.");
                return;
            }
            else
            {
                string filePath = this.IMAGE.Source.ToString();
                if (filePath.ToLower().Substring(0, 4).ToLower() == "pack")
                {
                    ItsMsgBox.ShowErr("업로드할 이미지를 추가하세요.");
                    return;
                }

                if (filePath.ToLower().Substring(0, 4).ToLower() == "file")
                {
                    string fileKey = ItsFileSystem.Upload(filePath);
                    this.FileKey = fileKey;

                    ItsPageBase basePage = ItsElement.FindParent<ItsPageBase>(this);
                    if (basePage != null)
                    {
                        basePage.EventFileUpload(this.Name, this.FileKey);
                    }
                    else
                    {
                        ItsWinBase winPage = ItsElement.FindParent<ItsWinBase>(this);
                        if (winPage != null)
                        {
                            winPage.EventFileUpload(this.Name, this.FileKey);
                        }
                    }
                }

                return;
            }
        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            if (this.FileKey != "")
            {
                if (ItsMsgBox.ShowYesNo("업로드된 이미지를 서버에서 삭제하시겠습니까?"))
                {
                    bool isDel = ItsFileSystem.Delete(this.FileKey);

                    ItsPageBase basePage = ItsElement.FindParent<ItsPageBase>(this);
                    if (basePage != null)
                    {
                        basePage.EventFileDelete(this.Name, this.FileKey);
                    }
                    else
                    {
                        ItsWinBase winPage = ItsElement.FindParent<ItsWinBase>(this);
                        if (winPage != null)
                        {
                            winPage.EventFileDelete(this.Name, this.FileKey);
                        }
                    }

                    // if (isDel) this.FileKey = "";
                    this.FileKey = "";
                    return;
                }
            }
            else
            {
                this.Source = "";
            }
        }
    }
}
