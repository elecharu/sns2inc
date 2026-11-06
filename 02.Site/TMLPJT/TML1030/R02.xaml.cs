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
    /// // 2026-11-04 [외주처 소모품 불출] 불출증 조회·불출(불출증 생성, 재고는 건드리지 않음)·불출삭제·불출증 출력
    /// </summary>
    public partial class R02 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_G3 = new ItsModelGrid();
        ItsModelGrid MODEL_G4 = new ItsModelGrid();

        public R02()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.FieldType("ITEMID_PRD", ItsEnums.FieldTypes.String);
            MODEL_A1.InitData();
            MODEL_A1.EventValueChanged += MODEL_A1_EventValueChanged;

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.EventRowChanged += MODEL_G1_EventRowChanged;
            MODEL_G2.Binding(GRID_G2);
            MODEL_G3.Binding(GRID_G3);
            MODEL_G4.Binding(GRID_G4);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A1.Close();

            MODEL_S1.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        // 불출증 선택 → 상세 조회
        private void MODEL_G1_EventRowChanged(int rowIndex)
        {
            MODEL_G2.Clear();
            if (rowIndex < 0 || rowIndex >= MODEL_G1.ModelCount) return;

            ItsMaria.Set("TML1030_R02", "LIST_RELEASE_DETAIL");
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

        // 불출라인을 바꾸면 그 라인에 분류등록된 제품·세부공정·터렛으로 필터 목록을 바꾸고 소모품 다시 조회
        private void MODEL_A1_EventValueChanged(string fieldName)
        {
            if (fieldName == "EQMCD")
            {
                MODEL_A1.SetRef01("ITEMID_PRD", MODEL_A1.GetText("EQMCD"));
                MODEL_A1.SetRef01("PRCDETAIL", MODEL_A1.GetText("EQMCD"));
                MODEL_A1.SetRef01("TURRET", MODEL_A1.GetText("EQMCD"));
                MODEL_A1.SetValue("ITEMID_PRD", "");
                MODEL_A1.SetValue("PRCDETAIL", "");
                MODEL_A1.SetValue("TURRET", "");
                EventCommand("SEARCH_POP_ITEM");
            }
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 불출증 조회 (불출일자)
            if (commandName == "SEARCH_RELEASE")
            {
                ItsMaria.Set("TML1030_R02", "LIST_RELEASE");
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
            // 불출삭제 (선택 소모품 1건)
            else if (commandName == "DEL_RELEASE_DETAIL")
            {
                if (MODEL_G2.ModelCount <= 0 || MODEL_G2.CurrentIndex < 0) return;

                if (MODEL_G1.GetText(MODEL_G1.CurrentIndex, "RECIEVEYN") == "Y")
                {
                    ShowMessageBox("", "수령된 불출증은 삭제할 수 없습니다.");
                    return;
                }

                ShowMessageBox("DEL_RELEASE_DETAIL", "[" + MODEL_G2.GetText(MODEL_G2.CurrentIndex, "ITEMNM") + "] 불출을 삭제하시겠습니까?");
            }
            // 불출증 출력 (재발행)
            else if (commandName == "PRINT_RELEASE")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    ShowMessageBox("", "출력할 불출증을 선택해주세요.");
                    return;
                }

                PrintRelease(MODEL_G1.GetText(MODEL_G1.CurrentIndex, "RELEASEKEY"));
            }
            // 불출 팝업 열기
            else if (commandName == "POP_RELEASE")
            {
                MODEL_A1.InitData();
                MODEL_A1.SetValue("RELEASEDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A1.SetValue("EMPCD_RELEASE", (ItsMemberShip.EMPCD ?? "").Trim());
                MODEL_G3.Clear();
                MODEL_G4.Clear();

                PANEL_A1.Show();
            }
            // 불출라인·필터로 소모품 조회
            else if (commandName == "SEARCH_POP_ITEM")
            {
                MODEL_G3.Clear();
                if (MODEL_A1.GetText("EQMCD") == "") return;

                ItsMaria.Set("TML1030_R02", "LIST_POP_ITEM");
                ItsMaria.AddModel(MODEL_A1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 불출 리스트가 비어 있으면 같은 컬럼 구성으로 만들어 둔다 (추가할 때 행을 그대로 옮김)
                if (MODEL_G4.ModelCount == 0)
                {
                    MODEL_G4.SetData(ds.Tables[0].Clone());
                }
                MODEL_G3.SetData(ds.Tables[0]);
                (GRID_G3.View as TableView).BestFitColumns();
            }
            // 소모품 → 불출 리스트에 추가 (불출수량 기본 1)
            else if (commandName == "ADD_POP_ITEM")
            {
                if (MODEL_G3.ModelCount <= 0 || MODEL_G3.CurrentIndex < 0) return;

                int rowIdx = MODEL_G3.CurrentIndex;
                string itemId = MODEL_G3.GetText(rowIdx, "ITEMID");
                for (int i = 0; i < MODEL_G4.ModelCount; i++)
                {
                    if (MODEL_G4.GetText(i, "ITEMID") == itemId)
                    {
                        ShowMessageBox("", "이미 불출 리스트에 있는 소모품입니다.");
                        return;
                    }
                }

                DataTable dt = MODEL_G3.Clone();
                dt.ImportRow(MODEL_G3.Rows[rowIdx]);
                int newIdx = MODEL_G4.AddRow(dt);
                MODEL_G4.SetValue(newIdx, "RELQTY", 1);
                (GRID_G4.View as TableView).BestFitColumns();
            }
            // 불출 리스트에서 빼기
            else if (commandName == "DEL_POP_ITEM")
            {
                MODEL_G4.DeleteCurrentModel();
            }
            // 불출 (불출증 생성)
            else if (commandName == "ADD_RELEASE")
            {
                if (MODEL_A1.GetText("RELEASEDATE") == "")
                {
                    ShowMessageBox("", "불출일자를 입력해주십시오.");
                    return;
                }
                if (MODEL_A1.GetText("EQMCD") == "")
                {
                    ShowMessageBox("", "불출라인을 선택해주십시오.");
                    return;
                }
                if (MODEL_A1.GetText("EMPCD_RELEASE") == "")
                {
                    ShowMessageBox("", "불출자를 선택해주십시오.");
                    return;
                }
                if (MODEL_G4.ModelCount == 0)
                {
                    ShowMessageBox("", "불출할 소모품을 추가해주십시오.");
                    return;
                }
                for (int i = 0; i < MODEL_G4.ModelCount; i++)
                {
                    if (MODEL_G4.GetDecimal(i, "RELQTY") <= 0)
                    {
                        ShowMessageBox("", "[" + MODEL_G4.GetText(i, "ITEMNM") + "] 불출수량을 0보다 크게 입력해주십시오.");
                        return;
                    }
                }

                ShowMessageBox("ADD_RELEASE", MODEL_G4.ModelCount + "건 불출하고 불출증을 출력하시겠습니까?");
            }
        }

        // 불출증 출력 (A4, 확인창 없이 POP 에서 고른 프린터로 바로 인쇄). 양식은 COMPJT\TMLPRINT 의 OSC_1 (AAALIB\TMLPRINT.exe)
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

            // 불출증 생성 → 출력 → 다시 조회
            if (commandName == "ADD_RELEASE")
            {
                ItsMaria.Set("TML1030_R02", "ADD_RELEASE");
                ItsMaria.AddModel(MODEL_A1);
                for (int i = 0; i < MODEL_G4.ModelCount; i++)
                {
                    ItsMaria.AddList("ITEMID_LIST", MODEL_G4.GetText(i, "ITEMID"));
                    ItsMaria.AddList("RELQTY_LIST", MODEL_G4.GetDecimal(i, "RELQTY"));
                }
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A1.Close();
                MODEL_S1.SetValue("SDATE", MODEL_A1.GetText("RELEASEDATE"));
                MODEL_S1.SetValue("EDATE", MODEL_A1.GetText("RELEASEDATE"));
                EventCommand("SEARCH_RELEASE");

                PrintRelease(ItsData.GetText(ds.Tables[0], 0, "RELEASEKEY"));
            }
            // 불출삭제 → 다시 조회 (헤더까지 지워졌으면 목록에서 빠짐)
            else if (commandName == "DEL_RELEASE_DETAIL")
            {
                ItsMaria.Set("TML1030_R02", "DEL_RELEASE_DETAIL");
                ItsMaria.AddOne("RELEASEKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "RELEASEKEY"));
                ItsMaria.AddOne("ITEMID", MODEL_G2.GetText(MODEL_G2.CurrentIndex, "ITEMID"));
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
