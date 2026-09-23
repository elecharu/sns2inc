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
