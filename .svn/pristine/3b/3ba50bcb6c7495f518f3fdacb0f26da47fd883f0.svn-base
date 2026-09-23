using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using System.Data;

namespace SYS0202
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageOffice
    {

        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();

        public R01()
        {
            InitializeComponent();

            // 최초 시작시 조회영역에 모델 설정
            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.SetValue("PKGTP", "MTR");

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();
            MODEL_A1.AddKey("PRGCD");

            MODEL_G2.Binding(GRID_G2);



            // 조회영역 컨트롤 ENTER키 눌렀을때 자동 조회 설정
            PANEL_S1.SetEnterSearch();
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();
        }

        public override void EventAdd()
        {
            base.EventAdd();
            PANEL_A1.Show();
        }

        // 조회
        public override void EventSearch()
        {
            base.EventSearch();
            
            _curMenuKey = MODEL_S1.GetText("PKGTP");
            SearchChild();

            // SUBMENU 구성
            SUB_MENU.Children.Clear();
            SetMenu(SUB_MENU, MODEL_S1.GetText("PKGTP"));

            DockPanel newDock = new DockPanel();
            SUB_MENU.Children.Add(newDock);
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);
            if (commandName == "PANEL_A1")
            {
                if (MODEL_A1.GetText("MENUNM") == "")
                {
                    ItsMsgBox.Show("메뉴명을 입력하세요.");
                    return;
                }

                    ItsMaria.Set("SYS0202_R01", "ADD_SYSMENU");
                    ItsMaria.AddModel(MODEL_A1);
                    ItsMaria.AddOne("PMENUKEY", _curMenuKey);
                    ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                        return;
                    }

                //GRID_G2.SetKey(PANEL_A1.Model);
                MODEL_G2.SetKey(MODEL_A1.GetKey());
                MODEL_A1.InitData();

                EventSearch();
                
            }
        }

        // 하위 메뉴 추가 ( 재귀함수 )
        private void SetMenu(DockPanel menuDock, string menuKey)
        {
            ItsMaria.Set("SYS0202_R01", "LIST_SYSMENU");
            ItsMaria.AddOne("MENUKEY", menuKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                DockPanel newDock = new DockPanel();
                newDock.Style = (Style)FindResource("MENU_DOCK");
                menuDock.Children.Add(newDock);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    UserControl newMenu = new UserControl();
                    if (row["PRGCD"].ToString() != "")
                    {
                        newMenu.Style = (Style)FindResource("MENU_PAGE");
                    }
                    else
                    {
                        newMenu.Style = (Style)FindResource("MENU_FOLDER");
                    }

                    newMenu.Content = row["MENUNM"].ToString();
                    newMenu.Tag = row["MENUKEY"].ToString();
                    newMenu.MouseDown += MENU_MouseDown;
                    newDock.Children.Add(newMenu);

                    SetMenu(newDock, row["MENUKEY"].ToString());
                }
            }
        }

        private string _curMenuKey = "";
        private void MENU_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _curMenuKey = (sender as UserControl).Tag.ToString();
            SearchChild();
        }

        private void SearchChild()
        {
            ItsMaria.Set("SYS0202_R01", "LIST_SYSMENU");
            ItsMaria.AddOne("MENUKEY", _curMenuKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                return;
            }

            MODEL_G2.SetData(ds.Tables[0]);
        }

        // 사용자 삭제
        public override void EventDelete()
        {
            base.EventDelete();

            if (ItsMsgBox.ShowYesNo("선택한 메뉴정보를 삭제하시겠습니까?") == true)
            {
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0202_R01", "DEL_SYSMENU");
                        ItsMaria.AddModel(MODEL_G2,i);
                        DataSet ds = ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                        }
                    }
                }

                SearchChild();
            }
        }

        public override void EventSave()
        {
            base.EventSave();

            if (_curMenuKey == "") return;

            if (ItsMsgBox.ShowYesNo("선택한 메뉴정보를 수정하시겠습니까?") == true)
            {
                // 신규 추가
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i))
                    {
                        ItsMaria.Set("SYS0202_R01", "UP_SYSMENU");
                        ItsMaria.AddModel(MODEL_G2,i);
                        ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ItsMsgBox.ShowErr(ItsMaria.ErrMessage);
                            return;
                        }
                    }
                }

                SearchChild();
            }
        }
    }
}
