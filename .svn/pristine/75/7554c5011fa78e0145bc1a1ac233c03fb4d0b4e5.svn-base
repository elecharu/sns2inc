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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITSLIB
{
    /// <summary>
    /// ItsLabelText.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonCommon : UserControl
    {
        public ButtonCommon()
        {
            InitializeComponent();
        }

        public string Label
        {
            get { return textBlock.Text; }
            set { textBlock.Text = value; }
        }

        public Brush FontColor
        {
            set
            {
                textBlock.Foreground = value;
            }
        }

        public string _Type = "Search";
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                HiddenImage();
                if (_Type == "Search")
                {
                    Search.Width = 16;
                    Search.Visibility = Visibility.Visible;
                }
                else if (_Type == "Add")
                {
                    Add.Width = 16;
                    Add.Visibility = Visibility.Visible;
                }
                else if (_Type == "Save")
                {
                    Save.Width = 16;
                    Save.Visibility = Visibility.Visible;
                }
                else if (_Type == "Delete")
                {
                    Delete.Width = 16;
                    Delete.Visibility = Visibility.Visible;
                }
                else if (_Type == "Print")
                {
                    Print.Width = 16;
                    Print.Visibility = Visibility.Visible;
                }
                else if (_Type == "Capture")
                {
                    Capture.Width = 16;
                    Capture.Visibility = Visibility.Visible;
                }
                else if (_Type == "Export")
                {
                    Export.Width = 16;
                    Export.Visibility = Visibility.Visible;
                }
            }
        }

        private void HiddenImage()
        {
            Search.Width = 0;
            Search.Visibility = Visibility.Hidden;
            Add.Width = 0;
            Add.Visibility = Visibility.Hidden;
            Save.Width = 0;
            Save.Visibility = Visibility.Hidden;
            Delete.Width = 0;
            Delete.Visibility = Visibility.Hidden;
            Print.Width = 0;
            Print.Visibility = Visibility.Hidden;
            Capture.Width = 0;
            Capture.Visibility = Visibility.Hidden;
            Export.Width = 0;
            Export.Visibility = Visibility.Hidden;
        }

        private string _CommandName = "";
        public string CommandName
        {
            get { return _CommandName; }
            set { _CommandName = value; }
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                do
                {
                    sender = VisualTreeHelper.GetParent(sender as DependencyObject);
                    if (sender is ItsPageOffice)
                    {
                        ItsPageOffice basePage = (sender as ItsPageOffice);
                        if (_Type == "Search")
                        {
                            if (ItsMemberShip.AutSearch(basePage.Name))
                            {
                                basePage.EventSearch();
                            }
                            else
                            {
                                ItsMsgBox.Show("조회권한이 없습니다.");
                            }
                        }
                        else if (_Type == "Add")
                        {
                            if (ItsMemberShip.AutAdd(basePage.Name))
                            {
                                basePage.EventAdd();
                            }
                            else
                            {
                                ItsMsgBox.Show("추가권한이 없습니다.");
                            }
                        }
                        else if (_Type == "Save")
                        {
                            if (ItsMemberShip.AutSave(basePage.Name))
                            {
                                basePage.EventSave();
                            }
                            else
                            {
                                ItsMsgBox.Show("저장권한이 없습니다.");
                            }
                        }
                        else if (_Type == "Delete")
                        {
                            if (ItsMemberShip.AutDelete(basePage.Name))
                            {
                                basePage.EventDelete();
                            }
                            else
                            {
                                ItsMsgBox.Show("삭제권한이 없습니다.");
                            }
                        }
                        else if (_Type == "Print")
                        {
                            if (ItsMemberShip.AutPrint(basePage.Name))
                            {
                                basePage.EventPrint();
                            }
                            else
                            {
                                ItsMsgBox.Show("추가권한이 없습니다.");
                            }
                        }
                        else if (_Type == "Capture")
                        {
                            if (ItsMemberShip.AutCapture(basePage.Name))
                            {
                                basePage.EventCapture();
                            }
                            else
                            {
                                ItsMsgBox.Show("캡처권한이 없습니다.");
                            }
                        }
                        else if (_Type == "Export")
                        {
                            if (ItsMemberShip.AutExport(basePage.Name))
                            {
                                basePage.EventExport();
                            }
                            else
                            {
                                ItsMsgBox.Show("내보내기 권한이 없습니다.");
                            }
                        }
                    }
                } while (!(sender is ItsPageOffice));
            }
        }

        private void border_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard story = (Storyboard)Resources["ButtonLeaveStory"];
            story.Begin(this);

        }

        private void border_MouseMove(object sender, MouseEventArgs e)
        {
            Storyboard story = (Storyboard)Resources["ButtonEnterStory"];
            story.Begin(this);
        }
    }
}
