using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITSLIB
{
    public partial class CaptureForm : Form
    {
        public CaptureForm()
        {
            InitializeComponent();
        }

        private bool _first = true;
        public string FILENAME = "";

        private Point startPoint = new Point(0, 0);
        private Point endPoint = new Point(0, 0);
        private bool IsClicked = false;
        private bool IsCaptured = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsCaptured) return;

            IsClicked = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {            
            if (_first)
            {
                _first = false;
                return;
            }

            if (IsCaptured) return;

            IsClicked = false;
            this.Refresh();

            endPoint = new Point(e.X, e.Y);

            if (endPoint.X - startPoint.X < 10 || endPoint.Y - startPoint.Y < 10)
            {
                return;
            }

            Bitmap btmCap = new Bitmap(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            Graphics g = Graphics.FromImage(btmCap);

            Point sPoint = this.PointToScreen(startPoint);
            g.CopyFromScreen(sPoint, new Point(0, 0), new Size(btmCap.Width, btmCap.Height));

            int addWidth = this.Width - pictureBox1.Width;
            int addHeight = this.Height - pictureBox1.Height;

            pictureBox1.Dock = DockStyle.None;
            pictureBox1.Left = 0;
            //pictureBox1.Top = 30;
            if (btmCap.Width < 200)
            {
                pictureBox1.Width = 200;
            }
            else
            {
                pictureBox1.Width = btmCap.Width;
            }
            pictureBox1.Height = btmCap.Height;

            pictureBox1.Image = btmCap;
            IsCaptured = true;

            this.WindowState = FormWindowState.Normal;
            this.Width = pictureBox1.Width + addWidth;
            this.Height = pictureBox1.Height + addHeight;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            Application.DoEvents();

            System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFile.RestoreDirectory = true;

            saveFile.DefaultExt = "png";
            saveFile.Filter = "Png Image (*.png)|*.png|Gif Image (*.gif)|*.gif|Jpg File (*.jpg)|*.jpg";
            saveFile.FilterIndex = 0;
            saveFile.FileName = FILENAME;
            saveFile.ShowDialog();

            // 저장 경로가 없을 경우 빠져나가기
            if (saveFile.FileName.IndexOf(":\\") == -1)
            {
                this.Close();
            }

            // 저장 유형에 따라 이미지 저장
            if (saveFile.FileName.IndexOf(".png") > -1)
            {
                pictureBox1.Image.Save(saveFile.FileName, ImageFormat.Png);
            }
            else if (saveFile.FileName.IndexOf(".gif") > -1)
            {
                pictureBox1.Image.Save(saveFile.FileName, ImageFormat.Gif);
            }
            else if (saveFile.FileName.IndexOf(".jpg") > -1)
            {
                pictureBox1.Image.Save(saveFile.FileName, ImageFormat.Jpeg);
            }

            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = saveFile.FileName;
                proc.Start();
            }
            catch { }

            this.Close();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsCaptured) return;

            if (IsClicked)
            {
                pictureBox1.Refresh();
                Point curPoint = new Point(e.X, e.Y);
                Graphics g = pictureBox1.CreateGraphics();
                Pen redPen = new Pen(Color.Red, 3);
                g.DrawRectangle(redPen, new Rectangle(startPoint, new Size(curPoint.X - startPoint.X, curPoint.Y - startPoint.Y)));
            }
        }

        private void CaptureForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            IsCaptured = false;
        }
    }
}
