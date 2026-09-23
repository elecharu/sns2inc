using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Net;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class FileManager : UserControl
    {
        public FileManager()
        {
            InitializeComponent();
            this.FileKey = "";

            this.OPEN.Visibility = Visibility.Visible;
            this.DOWNLOAD.Visibility = Visibility.Collapsed;
            this.UPLOAD.Visibility = Visibility.Visible;
            this.DELETE.Visibility = Visibility.Collapsed;
        }

        public string FileKey
        {
            get { return (string)GetValue(FileKeyProperty); }
            set { SetValue(FileKeyProperty, value); }
        }

        public readonly static DependencyProperty FileKeyProperty =
            DependencyProperty.Register("FileKey",
                typeof(string),
                typeof(FileManager),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, fileKeyChangedCallback));
        private static void fileKeyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            string fileKey = e.NewValue.ToString();
            if (fileKey == "")
            {
                ((FileManager)(sender)).textBox.Text = "";

                ((FileManager)(sender)).OPEN.Visibility = Visibility.Visible;
                ((FileManager)(sender)).DOWNLOAD.Visibility = Visibility.Collapsed;
                ((FileManager)(sender)).UPLOAD.Visibility = Visibility.Visible;
                ((FileManager)(sender)).DELETE.Visibility = Visibility.Collapsed;
            }
            else
            {
                StringBuilder query = new StringBuilder("SELECT FILENAME('" + fileKey + "')");
                string fileName = ItsData.GetScalar(ItsMaria.Query(query.ToString()));

                if (fileName != "") ((FileManager)(sender)).textBox.Text = fileName;
                else ((FileManager)(sender)).textBox.Text = "Invalid FileKey: " + fileKey;

                ((FileManager)(sender)).OPEN.Visibility = Visibility.Collapsed;
                ((FileManager)(sender)).DOWNLOAD.Visibility = Visibility.Visible;
                ((FileManager)(sender)).UPLOAD.Visibility = Visibility.Collapsed;
                ((FileManager)(sender)).DELETE.Visibility = Visibility.Visible;
            }
        }

        private void textBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void OPEN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ItsFileDialog.FileInfo fInfo = ItsFileDialog.OpenFile(10, new string[] { "*.*" });
            if (fInfo.FilePath != "")
            {
                this.FileKey = "";
                this.textBox.Text = fInfo.FilePath;

                this.ERRMSG.Text = "업로드하세요.";
                this.ERRMSG.Visibility = Visibility.Visible;
            }
        }

        private void UPLOAD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.ERRMSG.Visibility = Visibility.Collapsed;

            if (this.FileKey != "")
            {
                ItsMsgBox.ShowErr("이미지 바꾸기를 원하시면 기존 이미지를 삭제 및 신규 이미지를 추가하고 업로드하세요.");
                return;
            }
            else
            {
                string filePath = this.textBox.ToString();
                if (filePath.ToLower().Substring(0, 4).ToLower() == "pack")
                {
                    ItsMsgBox.ShowErr("업로드할 이미지를 추가하세요.");
                    return;
                }

                if (filePath.ToLower().IndexOf(":\\") > 0)
                {
                    if (!ItsMsgBox.ShowYesNo("파일을 서버로 업로드하시겠습니까?"))
                    {
                        this.ERRMSG.Visibility = Visibility.Visible;
                        return;
                    }

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

        private void DELETE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.ERRMSG.Visibility = Visibility.Collapsed;

            if (this.FileKey != "")
            {
                if (ItsMsgBox.ShowYesNo("업로드된 파일을 서버에서 삭제하시겠습니까?"))
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
                this.textBox.Text = "";
            }
            
        }

        private void DOWNLOAD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.ERRMSG.Visibility = Visibility.Collapsed;
            ItsFileSystem.Download(this.FileKey, textBox.Text);
        }
    }
}