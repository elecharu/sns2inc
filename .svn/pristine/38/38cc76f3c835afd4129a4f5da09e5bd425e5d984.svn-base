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

namespace ITSLIB
{
    public class DockContent : DockPanel
    {
        public ItsModelPanel ModelPanel = null;
        public DockContent()
        {
            this.KeyDown += DockContent_KeyDown;
        }

        private void DockContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (_IsEnterTab == true && e.Key == Key.Enter)
            {
                var uie = e.OriginalSource as UIElement;
                e.Handled = true;
                bool isMove = uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                if (isMove == false)
                {
                    uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                }
            }
        }

        private bool _IsEnterTab = false;
        public void SetEnterTab()
        {
            _IsEnterTab = true;
        }

        public void Close()
        {
            ItsPageBase pageBase = ItsElement.FindParent<ItsPageBase>(this);
            if (pageBase != null)
            {
                List<Canvas> canvas = ItsElement.FindChild<Canvas>(pageBase);
                if (canvas.Count > 0) // 현장 화면일 경우 다른 레이어 살리기
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(canvas[0]); i++)
                    {
                        UserControl UC = VisualTreeHelper.GetChild(canvas[0], i) as UserControl;
                        if (UC != null) UC.IsEnabled = true;
                    }
                }
            }

            UserControl uc = ItsElement.FindParent<UserControl>(this);
            if (uc != null)
            {
                uc.Visibility = Visibility.Hidden;
                uc.MaxHeight = 0;
                uc.MaxWidth = 0;
            }
        }

        public void Show()
        {
            ItsPageBase pageBase = ItsElement.FindParent<ItsPageBase>(this);
            if (pageBase != null)
            {
                List<Canvas> canvas = ItsElement.FindChild<Canvas>(pageBase);
                if (canvas.Count > 0) // 현장 화면일 경우 다른 레이어 죽이기
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(canvas[0]); i++)
                    {
                        UserControl UC = VisualTreeHelper.GetChild(canvas[0], i) as UserControl;
                        if (UC != null) UC.IsEnabled = false;
                    }
                }
            }

            UserControl uc = ItsElement.FindParent<UserControl>(this);
            if (uc != null)
            {
                uc.Visibility = Visibility.Visible;
                uc.IsEnabled = true;

                uc.MaxHeight = 5000;
                uc.MaxWidth = 5000;
            }
        }
    }
}
