using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using ITSLIB;
using DevExpress.Xpf.Grid;

namespace TML5000
{
    /// <summary>
    /// // 2026-11-10 [출하등록] 2공장 수주를 조회해서 다중 선택 → 출고창고를 고르고 LOT 바코드 스캔
    /// → 출하량(기본 = 현재고, 수정 가능)·비고 입력 → [등록] 하면 수주(상세)마다 출하 1건을 만들고 바로 출고확정
    /// 프로시저 TML5000_R01 → IO_SALOUT_LOT (출고구분 01 판매출고, 출고창고의 같은 LOT 재고 차감)
    /// // 2026-11-19 ERP 화면과 같게 탭 3개 (출하등록 / 발행 / 출하내역삭제). 출고창고가 04S140_N(유상사급)이면 출고구분 011.
    /// 외주처 판매출고(R02)는 이 화면으로 합침 (R02 메뉴 제거)
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();   // 수주내역 조회조건
        ItsModelPanel MODEL_S2 = new ItsModelPanel();   // 출하일자·출고창고·바코드
        ItsModelGrid MODEL_G1 = new ItsModelGrid();     // 수주내역
        ItsModelGrid MODEL_G2 = new ItsModelGrid();     // 출하 LOT
        ItsModelPanel MODEL_S3 = new ItsModelPanel();   // [발행] 탭 조회조건
        ItsModelPanel MODEL_S4 = new ItsModelPanel();   // [출하내역삭제] 탭 조회조건
        ItsModelGrid MODEL_G3 = new ItsModelGrid();     // [발행] 출하 목록 (출하번호별)
        ItsModelGrid MODEL_G4 = new ItsModelGrid();     // [출하내역삭제] 출하 목록 (출하번호별)

        public R01()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            MODEL_S2.Binding(PANEL_S2);
            MODEL_S2.InitData();
            MODEL_S2.EventValueChanged += MODEL_S2_EventValueChanged;

            MODEL_G1.Binding(GRID_G1);
            MODEL_G2.Binding(GRID_G2);

            MODEL_S3.Binding(PANEL_S3);
            MODEL_S3.InitData();
            MODEL_S4.Binding(PANEL_S4);
            MODEL_S4.InitData();
            MODEL_G3.Binding(GRID_G3);
            MODEL_G4.Binding(GRID_G4);

            // 출하 LOT 그리드는 정렬 끔: ITSLIB 그리드가 셀 값이 바뀌면 화면 순서(RowHandle)로 데이터 행을 찾아 편집을 확정해서
            // 정렬하면 고친 행이 확정되지 않음 (TML1010 R01 BOX 그리드와 같은 문제)
            (GRID_G2.View as TableView).AllowSorting = false;
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            MODEL_S1.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-01"));
            MODEL_S1.SetValue("EDATE", DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day).ToString("yyyy-MM-dd"));

            MODEL_S2.SetValue("OUTDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("WARECD", "04S200_N");   // 기본 출고창고 : 제품창고
            MODEL_S2.SetValue("SCANLOT", "");

            // [발행]·[출하내역삭제] 탭 : 출하일자 이번 달 1일 ~ 오늘
            foreach (ItsModelPanel model in new ItsModelPanel[] { MODEL_S3, MODEL_S4 })
            {
                model.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-01"));
                model.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            }

            TXT_SCANLOT.SetFocus();
        }

        // 출고창고를 바꾸면 스캔한 LOT 는 다른 창고 것이므로 비움
        private void MODEL_S2_EventValueChanged(string fieldName)
        {
            if (fieldName == "WARECD" && MODEL_G2.Rows.Count > 0)
            {
                MODEL_G2.Clear();
            }
        }

        // 선택(체크)한 수주 (같은 수주번호·순번은 한 번만)
        private void GetCheckedOrders(out List<string> keys, out List<string> seqs)
        {
            keys = new List<string>();
            seqs = new List<string>();
            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                if (MODEL_G1.IsChecked(i))
                {
                    keys.Add(MODEL_G1.GetText(i, "SALODRKEY"));
                    seqs.Add(MODEL_G1.GetText(i, "ODRSEQ"));
                }
            }
        }

        // 수주(상세)의 출하잔량 (수주내역 그리드 기준)
        private decimal RemainQty(string salodrKey, string odrSeq)
        {
            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                if (MODEL_G1.GetText(i, "SALODRKEY") == salodrKey && MODEL_G1.GetText(i, "ODRSEQ") == odrSeq)
                {
                    return MODEL_G1.GetDecimal(i, "REMQTY");
                }
            }
            return 0;
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 수주내역 조회
            if (commandName == "SEARCH")
            {
                ItsMaria.Set("TML5000_R01", "LIST_SALODR");
                ItsMaria.AddModel(MODEL_S1);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.SetData(ds.Tables[0]);
                TXT_SCANLOT.SetFocus();
            }
            // [발행]·[출하내역삭제] 탭 : 출하일자 기간의 출하 조회 (출하번호 = 납품처별 묶음 1개가 1행)
            else if (commandName == "SEARCH_HIST1" || commandName == "SEARCH_HIST2")
            {
                ItsModelPanel panel = commandName == "SEARCH_HIST1" ? MODEL_S3 : MODEL_S4;
                ItsModelGrid grid = commandName == "SEARCH_HIST1" ? MODEL_G3 : MODEL_G4;

                ItsMaria.Set("TML5000_R01", "LIST_SALOUT");
                ItsMaria.AddModel(panel);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                grid.SetData(ds.Tables[0]);
            }
            // [발행] 고른 줄의 거래명세서(출고부서용) 재발행
            else if (commandName == "PRINT_HIST")
            {
                if (MODEL_G3.Rows.Count == 0 || MODEL_G3.CurrentIndex < 0)
                {
                    ShowMessageBox("", "발행할 출하를 선택하세요.");
                    return;
                }

                PrintSalout(MODEL_G3.GetText(MODEL_G3.CurrentIndex, "GROUPKEY"));
            }
            // [출하내역삭제] 고른 줄의 출하 삭제 (확인 후 EventMessageResult 에서 처리)
            else if (commandName == "DEL_HIST")
            {
                if (MODEL_G4.Rows.Count == 0 || MODEL_G4.CurrentIndex < 0)
                {
                    ShowMessageBox("", "삭제할 출하를 선택하세요.");
                    return;
                }

                // 보이는 출하번호 = 거래명세서키(INVOICEKEY), 삭제는 출하그룹키(GROUPKEY) 기준
                ShowMessageBox(commandName, "출하번호 " + MODEL_G4.GetText(MODEL_G4.CurrentIndex, "INVOICEKEY") + " 의 출하를 삭제합니다.\n출고한 재고가 다시 복원됩니다.");
            }
            // 행 삭제
            else if (commandName == "DEL_ROW")
            {
                MODEL_G2.DeleteCurrentModel();
                TXT_SCANLOT.SetFocus();
            }
            // 스캔 목록 비우기
            else if (commandName == "CLEAR_SCAN")
            {
                MODEL_G2.Clear();
                MODEL_S2.SetValue("SCANLOT", "");
                TXT_SCANLOT.SetFocus();
            }
            // 등록
            else if (commandName == "ADD_SALOUT")
            {
                if (MODEL_S2.GetText("OUTDATE") == "")
                {
                    ShowMessageBox("", "출하일자를 선택하세요.");
                    return;
                }
                if (MODEL_S2.GetText("WARECD") == "")
                {
                    ShowMessageBox("", "출고창고를 선택하세요.");
                    return;
                }
                if (MODEL_G2.Rows.Count == 0)
                {
                    ShowMessageBox("", "출하할 LOT 바코드를 스캔하세요.");
                    return;
                }

                // 수주(상세)별 출하량 합계 ≤ 출하잔량
                Dictionary<string, decimal> sums = new Dictionary<string, decimal>();
                decimal totQty = 0;
                for (int i = 0; i < MODEL_G2.Rows.Count; i++)
                {
                    decimal outQty = MODEL_G2.GetDecimal(i, "OUTQTY");
                    if (outQty <= 0)
                    {
                        ShowMessageBox("", "출하량을 입력하세요. (" + MODEL_G2.GetText(i, "LOTKEY") + ")");
                        return;
                    }
                    if (outQty > MODEL_G2.GetDecimal(i, "LOTQTY"))
                    {
                        ShowMessageBox("", "출하량이 잔여재고량보다 많습니다. (" + MODEL_G2.GetText(i, "LOTKEY") + ")");
                        return;
                    }

                    string order = MODEL_G2.GetText(i, "SALODRKEY") + "|" + MODEL_G2.GetText(i, "ODRSEQ");
                    sums[order] = (sums.ContainsKey(order) ? sums[order] : 0) + outQty;
                    totQty += outQty;
                }
                foreach (KeyValuePair<string, decimal> pair in sums)
                {
                    string[] part = pair.Key.Split('|');
                    decimal remQty = RemainQty(part[0], part[1]);
                    if (pair.Value > remQty)
                    {
                        ShowMessageBox("", "출하량(" + pair.Value.ToString("#,0") + ")이 수주 출하잔량(" + remQty.ToString("#,0") + ")보다 많습니다. (" + part[0] + "-" + part[1] + ")");
                        return;
                    }
                }

                ShowMessageBox(commandName, MODEL_S2.GetText("OUTDATE") + " 일자로 수주 " + sums.Count + "건, LOT " + MODEL_G2.Rows.Count + "개, 총 " + totQty.ToString("#,0") + " 을(를) 출하하시겠습니까?");
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "DEL_HIST")
            {
                ItsMaria.Set("TML5000_R01", "DEL_SALOUT");
                ItsMaria.AddOne("SALOUTGROUPKEY", MODEL_G4.GetText(MODEL_G4.CurrentIndex, "GROUPKEY"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEARCH_HIST2");
                EventCommand("SEARCH");   // 출하잔량 다시 조회
            }
            else if (commandName == "ADD_SALOUT")
            {
                ItsMaria.Set("TML5000_R01", "ADD_SALOUT");
                ItsMaria.AddOne("OUTDATE", MODEL_S2.GetText("OUTDATE"));
                ItsMaria.AddOne("WARECD", MODEL_S2.GetText("WARECD"));
                for (int i = 0; i < MODEL_G2.Rows.Count; i++)
                {
                    ItsMaria.AddList("SALODRKEY_LIST", MODEL_G2.GetText(i, "SALODRKEY"));
                    ItsMaria.AddList("ODRSEQ_LIST", MODEL_G2.GetText(i, "ODRSEQ"));
                    ItsMaria.AddList("LOTKEY_LIST", MODEL_G2.GetText(i, "LOTKEY"));
                    ItsMaria.AddList("OUTQTY_LIST", MODEL_G2.GetDecimal(i, "OUTQTY"));
                    ItsMaria.AddList("REMARK_LIST", MODEL_G2.GetText(i, "REMARK"));
                }
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 거래명세서(출고부서용) 출력용 출하번호 : 납품처별 1개 (한 번 등록에 납품처가 여러 곳이면 여러 장)
                List<string> groupKeys = new List<string>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string key = row["SALOUTGROUPKEY"].ToString();
                    if (key != "" && !groupKeys.Contains(key)) groupKeys.Add(key);
                }

                MODEL_G2.Clear();
                MODEL_S2.SetValue("SCANLOT", "");
                EventCommand("SEARCH");   // 출하잔량 다시 조회

                foreach (string key in groupKeys)
                {
                    PrintSalout(key);
                }

                ShowMessageBox("", "출하 등록되었습니다. (출하 " + ds.Tables[0].Rows.Count + "건)");
                TXT_SCANLOT.SetFocus();
            }
        }

        // 거래명세서(출고부서용·공급받는자용 2부) 출력 (A4, 확인창 없이 POP 에서 고른 프린터로 바로 인쇄). 양식은 COMPJT\TMLPRINT 의 SAL_1 (AAALIB\TMLPRINT.exe)
        private void PrintSalout(string salOutGroupKey)
        {
            ItsMaria.Set("TML5000_R01", "PRINT_SALOUT");
            ItsMaria.AddOne("SALOUTGROUPKEY", salOutGroupKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            try
            {
                // 출고부서용·공급받는자용 2부를 인쇄작업 하나로 한 번에 (2026-11-23)
                TMLPRINT.SAL_1.PrintDirect(ds, ItsPrinter.BarcodePrintName);
            }
            catch (Exception ex)
            {
                ShowMessageBox("", "출하는 등록되었으나 거래명세서 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
            }
        }

        // 바코드 스캔 (스캐너가 Enter 를 붙여 보냄)
        private void TXT_SCANLOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            string lotKey = MODEL_S2.GetText("SCANLOT").Trim();
            MODEL_S2.SetValue("SCANLOT", "");
            if (lotKey == "") return;

            for (int i = 0; i < MODEL_G2.Rows.Count; i++)
            {
                if (MODEL_G2.GetText(i, "LOTKEY") == lotKey)
                {
                    ShowMessageBox("", "이미 스캔한 LOT 입니다. (" + lotKey + ")");
                    return;
                }
            }

            List<string> keys, seqs;
            GetCheckedOrders(out keys, out seqs);
            if (keys.Count == 0)
            {
                ShowMessageBox("", "왼쪽 수주내역에서 출하할 수주를 선택하세요.");
                return;
            }

            ItsMaria.Set("TML5000_R01", "SCAN_LOT");
            ItsMaria.AddOne("WARECD", MODEL_S2.GetText("WARECD"));
            ItsMaria.AddOne("SCANLOT", lotKey);
            for (int i = 0; i < keys.Count; i++)
            {
                ItsMaria.AddList("SALODRKEY_LIST", keys[i]);
                ItsMaria.AddList("ODRSEQ_LIST", seqs[i]);
            }
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            if (ds.Tables[0].Rows.Count == 0) return;

            if (MODEL_G2.Rows.Count == 0)
            {
                MODEL_G2.SetData(ds.Tables[0]);
            }
            else
            {
                MODEL_G2.AddRow(ds.Tables[0]);
            }

            TXT_SCANLOT.SetFocus();
        }
    }
}
