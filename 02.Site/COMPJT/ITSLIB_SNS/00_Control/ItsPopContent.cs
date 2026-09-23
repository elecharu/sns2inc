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
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Editors.Settings;
using System.Windows.Controls.Primitives;

namespace ITSLIB
{
    public class PopContent : ContentControl
    {
        public ItsModelPanel ModelPanel = null;
        public enum IconTypes
        {
            Config,
            Window,
            Info
        }

        public PopContent()
        {
            this.Loaded += PopContent_Loaded;

        }

        private void PopContent_Loaded(object sender, RoutedEventArgs e)
        {
            Title = _Title;
            IconType = _IconType;
            TitleColor = _LocalTitleColor.Color;
        }

        public void Show()
        {
            ItsElement.FindParent<Popup>(this).IsOpen = true;
        }

        public void Close()
        {
            ItsElement.FindParent<Popup>(this).IsOpen = false;
        }

        private SolidColorBrush _LocalTitleColor = new SolidColorBrush(Colors.Black);
        public Color TitleColor
        {
            get
            {
                try
                {
                    DockPanel titleDock = ItsElement.FindByName(this, "TITLE_PANEL") as DockPanel;
                    return ((SolidColorBrush)titleDock.Background).Color;
                }
                catch { }
                return _LocalTitleColor.Color;
            }
            set
            {
                try
                {
                    _LocalTitleColor = new SolidColorBrush(value);

                    (ItsElement.FindByName(this, "TITLE_PANEL") as DockPanel).Background = _LocalTitleColor;
                    (ItsElement.FindByName(this, "TITLE_MOVEDOCK") as DockPanel).Background = _LocalTitleColor;
                    (ItsElement.FindByName(this, "CONTENT_BORDER") as Border).BorderBrush = _LocalTitleColor;

                }
                catch { }
            }
        }

        private string _Title = "";
        public string Title
        {
            get
            {
                try
                {
                    TextBlock titleText = ItsElement.FindByName(this, "TITLE_TEXT") as TextBlock;
                    return titleText.Text;
                }
                catch { }
                return _Title;
            }
            set
            {
                try
                {
                    _Title = value;
                    TextBlock titleText = ItsElement.FindByName(this, "TITLE_TEXT") as TextBlock;
                    titleText.Text = value;
                }
                catch { }
            }
        }

        public PlacementMode Placement
        {
            get
            {
                Popup popup = ItsElement.FindParent<Popup>(this) as Popup;
                return popup.Placement;
            }
            set
            {
                Popup popup = ItsElement.FindParent<Popup>(this) as Popup;
                popup.Placement = value;
            }
        }

        public UIElement PlacementTarget
        {
            get
            {
                Popup popup = ItsElement.FindParent<Popup>(this) as Popup;
                return popup.PlacementTarget;
            }
            set
            {
                Popup popup = ItsElement.FindParent<Popup>(this) as Popup;
                popup.PlacementTarget = value;
            }
        }

        public void HiddenTitle()
        {
            (ItsElement.FindByName(this, "TITLE_PANEL") as DockPanel).Visibility = Visibility.Collapsed;
        }

        private void _HiddenAllIcon()
        {
            try
            {
                (ItsElement.FindByName(this, "ICON_WINDOW") as Canvas).Visibility = Visibility.Collapsed;
                (ItsElement.FindByName(this, "ICON_CONFIG") as Canvas).Visibility = Visibility.Collapsed;
                (ItsElement.FindByName(this, "ICON_INFO") as Canvas).Visibility = Visibility.Collapsed;
            }
            catch { }
        }

        public IconTypes _IconType = IconTypes.Info;
        public IconTypes IconType
        {
            get
            {
                try
                {
                    if ((ItsElement.FindByName(this, "ICON_CONFIG") as Canvas).Visibility == Visibility.Visible)
                    {
                        return IconTypes.Config;
                    }
                    else if ((ItsElement.FindByName(this, "ICON_WINDOW") as Canvas).Visibility == Visibility.Visible)
                    {
                        return IconTypes.Window;
                    }
                    else if ((ItsElement.FindByName(this, "ICON_INFO") as Canvas).Visibility == Visibility.Visible)
                    {
                        return IconTypes.Info;
                    }
                    return IconTypes.Info;
                }
                catch { }
                return _IconType;
            }
            set
            {
                _HiddenAllIcon();

                try
                {
                    _IconType = value;
                    if (value == IconTypes.Window)
                    {
                        (ItsElement.FindByName(this, "ICON_WINDOW") as Canvas).Visibility = Visibility.Visible;
                    }
                    else if (value == IconTypes.Config)
                    {
                        (ItsElement.FindByName(this, "ICON_CONFIG") as Canvas).Visibility = Visibility.Visible;
                    }
                    else if (value == IconTypes.Info)
                    {
                        (ItsElement.FindByName(this, "ICON_INFO") as Canvas).Visibility = Visibility.Visible;
                    }
                }
                catch { }
            }
        }
    }
}
