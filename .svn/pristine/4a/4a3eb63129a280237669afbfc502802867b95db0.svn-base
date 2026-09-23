using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class StyleControl
    {
        private void POPDRAG_CLOSE_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e != null && e.ChangedButton == MouseButton.Left) e.Handled = true;
            if (e != null && e.ChangedButton != MouseButton.Left) return;

            Popup pop = ItsElement.FindParent<Popup>(sender);
            pop.IsOpen = false;

        }

        private void POPDRAG_TITLE_DragMove(object sender, RoutedEventArgs e)
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