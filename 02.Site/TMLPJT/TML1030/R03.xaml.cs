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
using System.IO;
using System.Xml;
using System.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using DevExpress.Xpf.Grid;

namespace TML1030
{
    /// <summary>
    /// // 2026-11-04 [외주처 소모품 수령] 불출증 조회·불출증 스캔 수령(수령 후 불출증 출력)·수령수량 수정(저장)·수령삭제·불출증 재출력. 재고는 건드리지 않음
    /// </summary>
    public partial class R03 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_G3 = new ItsModelGrid();

        public R03()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.EventRowChanged += MODEL_G1_EventRowChanged;
            MODEL_G2.Binding(GRID_G2);
            MODEL_G3.Binding(GRID_G3);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A1.Close();

            MODEL_S1.SetValue("SDATE", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        // 불출증 선택 → 상세 조회
        private void MODEL_G1_EventRowChanged(int rowIndex)
        {
            MODEL_G2.Clear();
            if (rowIndex < 0 || rowIndex >= MODEL_G1.ModelCount) return;

            ItsMaria.Set("TML1030_R03", "LIST_RELEASE_DETAIL");
            ItsMaria.AddOne("RELEASEKEY", MODEL_G1.GetText(rowIndex, "RELEASEKEY"));
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            MODEL_G2.SetData(ds.Tables[0]);
            (GRID_G2.View as TableView).BestFitColumns();
        }

        // 불출증 바코드 스캔 (스캐너가 Enter 로 끝냄) → 불출증 내용을 팝업에 표시
        private void txt_SCAN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            MODEL_G3.Clear();
            MODEL_A1.SetValue("RELEASEKEY", "");
            MODEL_A1.SetValue("RELEASEDATE", "");
            MODEL_A1.SetValue("EQMNM", "");
            MODEL_A1.SetValue("EMPNM_RELEASE", "");

            ItsMaria.Set("TML1030_R03", "SCAN_RELEASE");
            ItsMaria.AddOne("RELEASEKEY", MODEL_A1.GetText("SCANKEY").Trim());
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                MODEL_A1.SetValue("SCANKEY", "");
                txt_SCAN.SetFocus();
                return;
            }

            MODEL_A1.SetValue("RELEASEKEY", ItsData.GetText(ds.Tables[0], 0, "RELEASEKEY"));
            MODEL_A1.SetValue("RELEASEDATE", ItsData.GetText(ds.Tables[0], 0, "RELEASEDATE"));
            MODEL_A1.SetValue("EQMNM", ItsData.GetText(ds.Tables[0], 0, "EQMNM"));
            MODEL_A1.SetValue("EMPNM_RELEASE", ItsData.GetText(ds.Tables[0], 0, "EMPNM_RELEASE"));
            MODEL_G3.SetData(ds.Tables[1]);
            (GRID_G3.View as TableView).BestFitColumns();

            MODEL_A1.SetValue("SCANKEY", "");
            txt_SCAN.SetFocus();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 불출증 조회 (불출일자)
            if (commandName == "SEARCH_RELEASE")
            {
                ItsMaria.Set("TML1030_R03", "LIST_RELEASE");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G2.Clear();
                MODEL_G1.SetData(ds.Tables[0]);
                (GRID_G1.View as TableView).BestFitColumns();
                if (MODEL_G1.ModelCount > 0)
                {
                    MODEL_G1_EventRowChanged(MODEL_G1.CurrentIndex < 0 ? 0 : MODEL_G1.CurrentIndex);
                }
            }
            // 수령 팝업 열기 (스캔 대기)
            else if (commandName == "POP_RECEIVE")
            {
                MODEL_A1.InitData();
                MODEL_A1.SetValue("RECIEVEDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A1.SetValue("EMPCD_RECIEVE", (ItsMemberShip.EMPCD ?? "").Trim());
                MODEL_G3.Clear();

                PANEL_A1.Show();
                txt_SCAN.SetFocus();
            }
            // 수령
            else if (commandName == "ADD_RECEIVE")
            {
                if (MODEL_A1.GetText("RELEASEKEY") == "" || MODEL_G3.ModelCount == 0)
                {
                    ShowMessageBox("", "불출증을 스캔해주십시오.");
                    return;
                }
                if (MODEL_A1.GetText("RECIEVEDATE") == "")
                {
                    ShowMessageBox("", "수령일자를 입력해주십시오.");
                    return;
                }
                if (MODEL_A1.GetText("EMPCD_RECIEVE") == "")
                {
                    ShowMessageBox("", "수령자를 선택해주십시오.");
                    return;
                }
                for (int i = 0; i < MODEL_G3.ModelCount; i++)
                {
                    if (MODEL_G3.GetDecimal(i, "RECQTY") < 0)
                    {
                        ShowMessageBox("", "[" + MODEL_G3.GetText(i, "ITEMNM") + "] 수령수량을 0 이상으로 입력해주십시오.");
                        return;
                    }
                }

                ShowMessageBox("ADD_RECEIVE", "불출증을 수령하시겠습니까?");
            }
            // 저장 (선택한 불출증의 수령수량 수정)
            else if (commandName == "SAVE_RECQTY")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0 || MODEL_G2.ModelCount == 0)
                {
                    ShowMessageBox("", "수령수량을 수정할 불출증을 선택해주십시오.");
                    return;
                }
                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "RECIEVEYN") != "Y")
                {
                    ShowMessageBox("", "수령 전 불출증입니다. [수령] 으로 먼저 수령해주십시오.");
                    return;
                }
                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "CONFIRMYN") == "Y")
                {
                    ShowMessageBox("", "수령확정된 불출증은 수정할 수 없습니다.");
                    return;
                }
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.GetDecimal(i, "RECQTY") < 0)
                    {
                        ShowMessageBox("", "[" + MODEL_G2.GetText(i, "ITEMNM") + "] 수령수량을 0 이상으로 입력해주십시오.");
                        return;
                    }
                }

                ShowMessageBox("SAVE_RECQTY", "수령수량을 저장하시겠습니까?");
            }
            // 수령삭제 (체크한 불출증)
            else if (commandName == "DEL_RECEIVE")
            {
                int cnt = 0;
                for (int i = 0; i < MODEL_G1.ModelCount; i++)
                {
                    if (!MODEL_G1.IsChecked(i)) continue;

                    if (MODEL_G1.GetText(i, "RECIEVEYN") != "Y")
                    {
                        ShowMessageBox("", "[" + MODEL_G1.GetText(i, "RELEASEDATE") + " " + MODEL_G1.GetText(i, "EQMNM") + "] 수령 전 불출증입니다.");
                        return;
                    }
                    if (MODEL_G1.GetText(i, "CONFIRMYN") == "Y")
                    {
                        ShowMessageBox("", "[" + MODEL_G1.GetText(i, "RELEASEDATE") + " " + MODEL_G1.GetText(i, "EQMNM") + "] 수령확정된 불출증은 수령삭제할 수 없습니다.");
                        return;
                    }
                    cnt++;
                }
                if (cnt == 0)
                {
                    ShowMessageBox("", "수령삭제할 불출증을 체크해주십시오.");
                    return;
                }

                ShowMessageBox("DEL_RECEIVE", cnt + "건 수령을 삭제하시겠습니까?");
            }
            // 불출증 출력 (재발행, 선택한 불출증)
            else if (commandName == "PRINT_RELEASE")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    ShowMessageBox("", "출력할 불출증을 선택해주십시오.");
                    return;
                }

                PrintRelease(MODEL_G1.GetText(MODEL_G1.CurrentIndex, "RELEASEKEY"));
            }
        }

        // 불출증 출력 (A4, 확인창 없이 POP 에서 고른 프린터로 바로 인쇄). 불출 화면(TML1030_R02)과 같은 양식(TMLPRINT.OSC_1)·프로시저를 쓴다
        // 수령된 불출증이면 요청자 칸 = 수령자
        private void PrintRelease(string releaseKey)
        {
            ItsMaria.Set("TML1030_R02", "PRINT_RELEASE");
            ItsMaria.AddOne("RELEASEKEY", releaseKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            try
            {
                TMLPRINT.OSC_1 rpt = new TMLPRINT.OSC_1(ds);
                rpt.PrintDirect(ItsPrinter.BarcodePrintName);
            }
            catch (Exception ex)
            {
                ShowMessageBox("", "불출증 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
            }
        }

        // Yes/No 확인창 - Yes 응답 처리
        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            // 수령 → 팝업 닫고 다시 조회 → 불출증 출력 (요청자 칸 = 수령자)
            if (commandName == "ADD_RECEIVE")
            {
                string releaseKey = MODEL_A1.GetText("RELEASEKEY");

                ItsMaria.Set("TML1030_R03", "ADD_RECEIVE");
                ItsMaria.AddOne("RELEASEKEY", MODEL_A1.GetText("RELEASEKEY"));
                ItsMaria.AddOne("RECIEVEDATE", MODEL_A1.GetText("RECIEVEDATE"));
                ItsMaria.AddOne("EMPCD_RECIEVE", MODEL_A1.GetText("EMPCD_RECIEVE"));
                for (int i = 0; i < MODEL_G3.ModelCount; i++)
                {
                    ItsMaria.AddList("ITEMID_LIST", MODEL_G3.GetText(i, "ITEMID"));
                    ItsMaria.AddList("RECQTY_LIST", MODEL_G3.GetDecimal(i, "RECQTY"));
                }
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A1.Close();
                EventCommand("SEARCH_RELEASE");

                PrintRelease(releaseKey);
            }
            // 저장 → 다시 조회
            else if (commandName == "SAVE_RECQTY")
            {
                ItsMaria.Set("TML1030_R03", "SAVE_RECQTY");
                ItsMaria.AddOne("RELEASEKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "RELEASEKEY"));
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    ItsMaria.AddList("ITEMID_LIST", MODEL_G2.GetText(i, "ITEMID"));
                    ItsMaria.AddList("RECQTY_LIST", MODEL_G2.GetDecimal(i, "RECQTY"));
                }
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEARCH_RELEASE");
            }
            // 수령삭제 → 다시 조회
            else if (commandName == "DEL_RECEIVE")
            {
                ItsMaria.Set("TML1030_R03", "DEL_RECEIVE");
                ItsMaria.AddListGrid("RELEASEKEY_LIST", MODEL_G1, "RELEASEKEY");
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEARCH_RELEASE");
            }
        }
    }
}
