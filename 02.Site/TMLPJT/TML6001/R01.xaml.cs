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

namespace TML6001
{
    /// <summary>
    /// // 2026-11-20 [제품 반입등록] 고객사로 출하한 제품이 문제가 있어 2공장으로 되돌아오면 제품불량창고(04S230_N)에 반입 (프로시저 TML6001_R01)
    /// 공정이동표가 붙어 오면 바코드 스캔 (출하된 로트만, 반입수량 기본 = 반입가능량, 일부 반입이면 고침, 거래처는 출하 거래처)
    /// 공정이동표가 없으면 거래처 출하품목 + 반입수량 → [추가] → 등록 때 새 로트 채번(RT + yyMMdd + '-' + 순번3) 후 공정이동표(TMLPRINT.PRD_1) 출력
    /// 반입 = COMOUT·COMOUTLOT 출고구분 20(출하반품), OUTQTY 마이너스 + COMLOT 재고 생성. 반입 거래처는 COMOUT.CUSTCD
    /// [반입취소] 탭 : 반입 이력 조회 · 체크한 행 반입취소 · 공정이동표 재발행
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();   // [반입등록] 공통 : 반입일자·거래처
        ItsModelPanel MODEL_S3 = new ItsModelPanel();   // [반입등록] ① 공정이동표 있음 : 바코드 스캔
        ItsModelPanel MODEL_S4 = new ItsModelPanel();   // [반입등록] ② 공정이동표 없음 : 품목·반입수량
        ItsModelGrid MODEL_G1 = new ItsModelGrid();     // [반입등록] 반입할 목록
        ItsModelPanel MODEL_S2 = new ItsModelPanel();   // [반입취소] 조회조건
        ItsModelGrid MODEL_G2 = new ItsModelGrid();     // [반입취소] 반입 이력

        public R01()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

            MODEL_S3.Binding(PANEL_S3);
            MODEL_S3.InitData();

            MODEL_S4.Binding(PANEL_S4);
            MODEL_S4.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G1.InitData();

            MODEL_S2.Binding(PANEL_S2);
            MODEL_S2.InitData();

            MODEL_G2.Binding(GRID_G2);
            MODEL_G2.InitData();
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            MODEL_S1.SetValue("RTNDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S3.SetValue("SCANLOT", "");
            MODEL_S4.SetRef01("ITEMID", "");
            MODEL_S4.SetValue("RTNQTY", 0);

            MODEL_S2.SetValue("SDATE", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));

            txt_BARCODE.Focus();
        }

        // 거래처를 바꾸면 품목 콤보를 그 거래처 출하품목으로, 다른 거래처로 담아둔 목록은 비움
        private void MODEL_S1_EventValueChanged(string fieldName)
        {
            if (fieldName != "CUSTCD") return;

            string custCd = MODEL_S1.GetText("CUSTCD");
            MODEL_S4.SetRef01("ITEMID", custCd);
            MODEL_S4.SetValue("ITEMID", "");

            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                if (MODEL_G1.GetText(i, "CUSTCD") != custCd)
                {
                    MODEL_G1.Clear();
                    break;
                }
            }
        }

        // 그리드에 행 추가 (스캔·추가 공통)
        private void AddGridRows(DataTable table)
        {
            if (table.Rows.Count == 0) return;

            if (MODEL_G1.Rows.Count == 0)
            {
                MODEL_G1.SetData(table);
            }
            else
            {
                MODEL_G1.AddRow(table);
            }
        }

        // [반입취소] 탭 반입 이력 조회
        private void SearchRtn()
        {
            ItsMaria.Set("TML6001_R01", "LIST_RTN");
            ItsMaria.AddModel(MODEL_S2);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            MODEL_G2.SetData(ds.Tables[0]);
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 행 삭제
            if (commandName == "DEL_ROW")
            {
                MODEL_G1.DeleteCurrentModel();
                txt_BARCODE.Focus();
            }
            // 목록 비우기
            else if (commandName == "CLEAR_SCAN")
            {
                MODEL_G1.Clear();
                MODEL_S3.SetValue("SCANLOT", "");
                MODEL_S4.SetValue("RTNQTY", 0);
                txt_BARCODE.Focus();
            }
            // 공정이동표 없음 : 품목 + 반입수량 추가
            else if (commandName == "ADD_ITEM")
            {
                if (MODEL_S1.GetText("CUSTCD") == "")
                {
                    ShowMessageBox("", "거래처를 선택하세요.");
                    return;
                }
                if (MODEL_S4.GetText("ITEMID") == "")
                {
                    ShowMessageBox("", "품목을 선택하세요.");
                    return;
                }
                if (MODEL_S4.GetDecimal("RTNQTY") <= 0)
                {
                    ShowMessageBox("", "반입수량을 입력하세요.");
                    return;
                }

                ItsMaria.Set("TML6001_R01", "ADD_ITEM");
                ItsMaria.AddOne("CUSTCD", MODEL_S1.GetText("CUSTCD"));
                ItsMaria.AddOne("ITEMID", MODEL_S4.GetText("ITEMID"));
                ItsMaria.AddOne("RTNQTY", MODEL_S4.GetDecimal("RTNQTY").ToString());
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                AddGridRows(ds.Tables[0]);
                MODEL_S4.SetValue("RTNQTY", 0);
            }
            // 등록
            else if (commandName == "ADD_RTN")
            {
                if (MODEL_S1.GetText("RTNDATE") == "")
                {
                    ShowMessageBox("", "반입일자를 선택하세요.");
                    return;
                }
                if (MODEL_S1.GetText("CUSTCD") == "")
                {
                    ShowMessageBox("", "거래처를 선택하세요.");
                    return;
                }
                if (MODEL_G1.Rows.Count == 0)
                {
                    ShowMessageBox("", "반입할 제품을 스캔하거나 추가하세요.");
                    return;
                }

                decimal totQty = 0;
                int newCnt = 0;
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    decimal rtnQty = MODEL_G1.GetDecimal(i, "RTNQTY");
                    if (rtnQty <= 0)
                    {
                        ShowMessageBox("", "반입수량을 입력하세요. (" + (i + 1) + "번째 줄)");
                        return;
                    }
                    if (MODEL_G1.GetText(i, "NEWYN") == "N" && rtnQty > MODEL_G1.GetDecimal(i, "SHIPQTY"))
                    {
                        ShowMessageBox("", "반입수량이 반입가능량보다 많습니다.\n- 로트번호: " + MODEL_G1.GetText(i, "LOTKEY"));
                        return;
                    }
                    if (MODEL_G1.GetText(i, "NEWYN") == "Y") newCnt++;
                    totQty += rtnQty;
                }

                string msg = MODEL_S1.GetText("RTNDATE") + " 일자로 " + MODEL_G1.Rows.Count + "건, 총 " + totQty.ToString("#,0") + " 을(를) 제품불량창고에 반입하시겠습니까?";
                if (newCnt > 0)
                {
                    msg += "\n(공정이동표 없는 " + newCnt + "건은 새 로트번호로 공정이동표를 출력합니다)";
                }
                ShowMessageBox(commandName, msg);
            }
            // [반입취소] 탭 조회
            else if (commandName == "SEARCH_RTN")
            {
                if (MODEL_S2.GetText("SDATE") == "" || MODEL_S2.GetText("EDATE") == "")
                {
                    ShowMessageBox("", "반입일자를 선택하세요.");
                    return;
                }

                SearchRtn();
            }
            // [반입취소] 탭 반입취소 (체크한 행)
            else if (commandName == "DEL_RTN")
            {
                int cnt = 0;
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (!MODEL_G2.IsChecked(i)) continue;

                    if (MODEL_G2.GetDecimal(i, "LOTQTY") < MODEL_G2.GetDecimal(i, "RTNQTY"))
                    {
                        ShowMessageBox("", "제품불량창고 재고가 반입수량보다 적어 취소할 수 없습니다. (이미 이동·사용된 재고)\n- 로트번호: " + MODEL_G2.GetText(i, "LOTKEY"));
                        return;
                    }
                    cnt++;
                }
                if (cnt == 0)
                {
                    ShowMessageBox("", "취소할 반입 이력을 체크하세요.");
                    return;
                }

                ShowMessageBox(commandName, "반입 이력 " + cnt + "건을 취소하시겠습니까?\n(제품불량창고 재고를 빼고 반입 이력을 삭제합니다)");
            }
            // [반입취소] 탭 공정이동표 재발행 (체크한 행)
            else if (commandName == "PRINT_MOVE")
            {
                List<string> outKeys = new List<string>();
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (MODEL_G2.IsChecked(i)) outKeys.Add(MODEL_G2.GetText(i, "OUTKEY"));
                }
                if (outKeys.Count == 0)
                {
                    ShowMessageBox("", "공정이동표를 출력할 반입 이력을 체크하세요.");
                    return;
                }

                if (PrintMove(outKeys))
                {
                    ShowMessageBox("", "공정이동표를 출력했습니다. (" + outKeys.Count + "장)");
                }
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "ADD_RTN")
            {
                ItsMaria.Set("TML6001_R01", "ADD_RTN");
                ItsMaria.AddModel(MODEL_S1);
                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    ItsMaria.AddList("LOTKEY_LIST", MODEL_G1.GetText(i, "LOTKEY"));
                    ItsMaria.AddList("ITEMID_LIST", MODEL_G1.GetText(i, "ITEMID"));
                    ItsMaria.AddList("RTNQTY_LIST", MODEL_G1.GetDecimal(i, "RTNQTY"));
                    ItsMaria.AddList("REMARK_LIST", MODEL_G1.GetText(i, "REMARK"));
                }
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.Clear();
                MODEL_S3.SetValue("SCANLOT", "");
                MODEL_S4.SetValue("RTNQTY", 0);

                // 새로 만든 로트(공정이동표 없이 온 것)는 공정이동표 출력
                string msg = "반입 되었습니다. (" + ItsData.GetText(ds.Tables[0], 0, "LOTCNT") + "건)";
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    List<string> outKeys = new List<string>();
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        outKeys.Add(ItsData.GetText(ds.Tables[1], i, "OUTKEY"));
                    }

                    if (!PrintMove(outKeys)) return;
                    msg += "\n새 로트 " + outKeys.Count + "건의 공정이동표를 출력했습니다.";
                }

                ShowMessageBox("", msg);
                txt_BARCODE.Focus();
            }
            else if (commandName == "DEL_RTN")
            {
                ItsMaria.Set("TML6001_R01", "DEL_RTN");
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    if (!MODEL_G2.IsChecked(i)) continue;

                    ItsMaria.AddList("OUTKEY_LIST", MODEL_G2.GetText(i, "OUTKEY"));
                }
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                ShowMessageBox("", "반입취소 되었습니다. (" + ItsData.GetText(ds.Tables[0], 0, "DELCNT") + "건)");
                SearchRtn();
            }
        }

        // 공정이동표 출력 (양식 COMPJT\TMLPRINT 의 PRD_1, 제목 "공 정 이 동 표 (출하반품)", 수량 = 반입수량)
        // 여러 장을 문서 하나로 합쳐 POP 에서 고른 프린터로 한 번에 인쇄. 실패하면 메시지 후 false
        private bool PrintMove(List<string> outKeys)
        {
            List<TMLPRINT.PRD_1> reports = new List<TMLPRINT.PRD_1>();
            foreach (string outKey in outKeys)
            {
                ItsMaria.Set("TML6001_R01", "PRINT_MOVE");
                ItsMaria.AddOne("OUTKEY_LIST", outKey);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return false;
                }
                if (ds.Tables[0].Rows.Count == 0) continue;

                reports.Add(new TMLPRINT.PRD_1(ds, true));
            }

            try
            {
                TMLPRINT.PRD_1.PrintDirect(reports, ItsPrinter.BarcodePrintName);
            }
            catch (Exception ex)
            {
                ShowMessageBox("", "공정이동표 출력 중 오류가 발생했습니다.\n" + ex.Message);
                return false;
            }
            return true;
        }

        // 공정이동표 바코드 스캔 (스캐너가 Enter 를 붙여 보냄)
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            string lotKey = MODEL_S3.GetText("SCANLOT").Trim();
            MODEL_S3.SetValue("SCANLOT", "");
            if (lotKey == "") return;

            for (int i = 0; i < MODEL_G1.Rows.Count; i++)
            {
                if (MODEL_G1.GetText(i, "LOTKEY") == lotKey)
                {
                    ShowMessageBox("", "이미 스캔한 LOT 입니다. (" + lotKey + ")");
                    return;
                }
            }

            ItsMaria.Set("TML6001_R01", "SCAN_LOT");
            ItsMaria.AddOne("CUSTCD", MODEL_S1.GetText("CUSTCD"));
            ItsMaria.AddOne("SCANLOT", lotKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }
            if (ds.Tables[0].Rows.Count == 0) return;

            // 거래처를 안 골랐으면 출하 거래처로 채움 (그리드에 넣기 전에 : 거래처가 바뀌면 목록을 비우므로)
            if (MODEL_S1.GetText("CUSTCD") == "")
            {
                MODEL_S1.SetValue("CUSTCD", ItsData.GetText(ds.Tables[0], 0, "CUSTCD"));
            }

            AddGridRows(ds.Tables[0]);
            txt_BARCODE.Focus();
        }
    }
}
