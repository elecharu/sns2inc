using System;
using System.Text;
using System.Windows;
using System.Windows.Interop;

namespace TMLSTART
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
            {
                hwndSource.AddHook(new HwndSourceHook(this.WndProc));
            }
        }

        public enum HitTest : int
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTSIZE = HTGROWBOX,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTREDUCE = HTMINBUTTON,
            HTZOOM = HTMAXBUTTON,
            HTSIZEFIRST = HTLEFT,
            HTSIZELAST = HTBOTTOMRIGHT,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21,
        }

        private const int WM_NCHITTEST = 0x0084;
        private Point mousePoint = new Point(); //鼠标坐标
        private const int ResizeBorderAGWidth = 15;//转角宽度 
        private const int ResizeBorderThickness = 5;//边框宽度
        protected virtual IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                return IntPtr.Zero;
            }

            if (this.Width < 200)
            {
                this.Width = 200;
                return IntPtr.Zero;
            }

            if (this.Height < 200)
            {
                this.Height = 200;
                return IntPtr.Zero;
            }

            switch (msg)
            {
                case WM_NCHITTEST:
                    this.mousePoint.X = (lParam.ToInt32() & 0xFFFF);
                    this.mousePoint.Y = (lParam.ToInt32() >> 16);

                    // Left-Top
                    if (this.mousePoint.Y - this.Top <= StartWindow.ResizeBorderAGWidth
                        && this.mousePoint.X - this.Left <= StartWindow.ResizeBorderAGWidth)
                    {
                        handled = true;
                        return new IntPtr((int)HitTest.HTTOPLEFT);
                    }
                    // Left-Bottom
                    else if (this.ActualHeight + this.Top - this.mousePoint.Y <= StartWindow.ResizeBorderAGWidth
                        && this.mousePoint.X - this.Left <= StartWindow.ResizeBorderAGWidth)
                    {
                        handled = true;
                        return new IntPtr((int)HitTest.HTBOTTOMLEFT);
                    }
                    //// Right-Top
                    else if (this.mousePoint.Y - this.Top <= StartWindow.ResizeBorderAGWidth
                        && this.ActualWidth + this.Left - this.mousePoint.X <= StartWindow.ResizeBorderAGWidth)
                    {
                        handled = true;
                        return new IntPtr((int)HitTest.HTTOPRIGHT);
                    }
                    // Right-Bottom
                    else if (this.ActualWidth + this.Left - this.mousePoint.X <= StartWindow.ResizeBorderAGWidth
                        && this.ActualHeight + this.Top - this.mousePoint.Y <= StartWindow.ResizeBorderAGWidth)
                    {
                        handled = true;
                        return new IntPtr((int)HitTest.HTBOTTOMRIGHT);
                    }
                    // Left
                    else if (this.mousePoint.X - this.Left <= StartWindow.ResizeBorderThickness)
                    {
                        handled = true;
                        return new IntPtr((int)HitTest.HTLEFT);
                    }
                    // Right
                    else if (this.ActualWidth + this.Left - this.mousePoint.X <= StartWindow.ResizeBorderThickness)
                    {
                        handled = true;
                        return new IntPtr((int)HitTest.HTRIGHT);
                    }
                    // Top
                    else if (this.mousePoint.Y - this.Top <= StartWindow.ResizeBorderThickness)
                    {
                        handled = true;
                        return new IntPtr((int)HitTest.HTTOP);
                    }
                    // Bottom
                    else if (this.ActualHeight + this.Top - this.mousePoint.Y <= StartWindow.ResizeBorderThickness)
                    {
                        handled = true;
                        return new IntPtr((int)HitTest.HTBOTTOM);
                    }
                    else
                    {
                        return IntPtr.Zero;
                    }
            }
            return IntPtr.Zero;
        }
    }
}
