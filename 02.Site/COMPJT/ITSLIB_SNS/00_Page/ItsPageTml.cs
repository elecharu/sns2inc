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
    public class ItsPageTml : ItsPageBase
    {
        public ItsPageTml()
        {
            this.Loaded += ItsPageTml_Loaded;
        }

        private bool _isLoad = false;
        private void ItsPageTml_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= ItsPageTml_Loaded;

            if (_isLoad == false)
            {
                if (this.Style == null)
                {
                    this.Style = (Style)FindResource("TML");
                }

                HookPopDim();   // 2026-11-27 팝업 뒤 회색 막 (현장화면 공통)

                this.EventPageLoaded();

                // 최초 로드 시 LoadMenu 파라미터가 있으면 수신 처리
                Dictionary<string, string> menuParam = ItsElement.GetMenuParam();
                if (menuParam != null && menuParam.Count > 0)
                {
                    this.EventMenuParam(menuParam);
                    ItsElement.ClearMenuParam();
                }

                _isLoad = true;
            }
        }

        //===== 팝업 뒤 회색 막 (2026-11-27, 현장화면 공통) =====
        // TML_POP 모양 팝업이 열리면 그 팝업을 맨 위로 올리고, 반투명 회색 막을 바로 아래에 깔아 뒤 화면을 덮음 (눌리지 않음)
        // 팝업 위에 팝업이 또 열리면 아래 팝업도 회색. 다 닫히면 막을 걷음
        // 막을 깔지 않을 팝업(예: 뒤 그리드를 보며 쓰는 숫자패드)은 XAML 에 Tag="NODIM"
        private readonly List<UserControl> _dimPops = new List<UserControl>();
        private readonly Dictionary<Canvas, Border> _dimLayers = new Dictionary<Canvas, Border>();
        private int _popZ = 10;

        private void HookPopDim()
        {
            object popStyle = TryFindResource("TML_POP");
            if (popStyle == null) return;

            foreach (UserControl uc in ItsElement.FindChild<UserControl>(this))
            {
                if (uc.Style != popStyle || Convert.ToString(uc.Tag) == "NODIM") continue;
                Canvas canvas = uc.Parent as Canvas;
                if (canvas == null) continue;

                if (!_dimLayers.ContainsKey(canvas))
                {   // 팝업이 들어 있는 캔버스마다 막 하나 (화면 크기에 맞춤: 현장화면 틀 안에서 캔버스 가로 폭은 0 으로 잡혀서 캔버스 크기를 쓰면 안 보임)
                    Border dim = new Border
                    {
                        Background = new SolidColorBrush(Color.FromArgb(0x66, 0, 0, 0)),
                        Visibility = Visibility.Collapsed
                    };
                    Canvas.SetLeft(dim, 0);
                    Canvas.SetTop(dim, 0);
                    dim.SetBinding(FrameworkElement.WidthProperty, new Binding("ActualWidth") { Source = this });
                    dim.SetBinding(FrameworkElement.HeightProperty, new Binding("ActualHeight") { Source = this });
                    canvas.Children.Add(dim);
                    _dimLayers[canvas] = dim;
                }

                _dimPops.Add(uc);
                uc.IsVisibleChanged += PopDim_IsVisibleChanged;
            }
        }

        private void PopDim_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UserControl uc = sender as UserControl;
            if ((bool)e.NewValue)
            {   // 새로 열린 팝업을 맨 위로
                _popZ += 2;
                Panel.SetZIndex(uc, _popZ);
            }
            UpdatePopDim(uc.Parent as Canvas);
        }

        private void UpdatePopDim(Canvas canvas)
        {
            Border dim;
            if (canvas == null || !_dimLayers.TryGetValue(canvas, out dim)) return;

            UserControl top = null;
            foreach (UserControl p in _dimPops)
            {
                if (p.Parent != canvas || p.Visibility != Visibility.Visible) continue;
                if (top == null || Panel.GetZIndex(p) > Panel.GetZIndex(top)) top = p;
            }
            if (top == null)
            {
                dim.Visibility = Visibility.Collapsed;
                return;
            }
            Panel.SetZIndex(dim, Panel.GetZIndex(top) - 1);   // 맨 위 팝업 바로 아래
            dim.Visibility = Visibility.Visible;
        }

        public virtual void EventPopClose(string panelName)
        {

        }

        public virtual void EventMessageResult(string cmd)
        {

        }

        public void ShowMessageBox(string commandName, string msg)
        {
            ShowMessageBox(commandName, msg, "");
        }
        public void ShowMessageBox(string commandName, string msg, string msgType)
        {
            TMLMAIN.MainWindow tmlMain = ItsElement.FindParent<TMLMAIN.MainWindow>(this);
            if (tmlMain != null)
            {
                tmlMain.ShowMessageBox(commandName, msg, msgType);
                //tmlMain.ShowMessageBox(commandName, msg);
                return;
            }
            else
            {
                if(msgType == "ERR" || commandName == "")
                {
                    ItsMsgBox.ShowErr(msg);
                }
                else
                {
                    if (ItsMsgBox.ShowYesNo(msg))
                    {
                        EventMessageResult(commandName);
                    }
                }

            }
        }

        // 2025-05-22 팝업 타이틀 명칭 부여
        public void SetTMLPOPTitle (Object panel, string TITLE)
        {
            List<TextBlock> tc = ItsElement.FindChild<TextBlock>(panel);
            for (int i = 0; i < tc.Count; i++)
            {
                if (tc[i].Name == "TML_POP_TITLE_TEXT")
                {
                    tc[i].Text = TITLE;
                    break;
                }
            }
        }
    }
}
