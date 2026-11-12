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

namespace TML1010
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelPanel MODEL_A3 = new ItsModelPanel(); // 2026-11-09 정보입력 팝업

        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_G3 = new ItsModelGrid(); // 2026-11-09 BOX 단위 수량 x BOX 수량
        ItsModelGrid MODEL_G4 = new ItsModelGrid(); // 2026-11-10 납품등록 BOX 현황 ([등록] 전까지 화면에만)


        // 생성자
        public R01()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.DefaultValue("SDATE", DateTime.Now);
            MODEL_S1.DefaultValue("EDATE", DateTime.Now);
            MODEL_S1.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();

            MODEL_A3.Binding(PANEL_A3);
            MODEL_A3.InitData();

            MODEL_G1.Binding(GRID_G1);

            MODEL_G2.Binding(GRID_G2);

            MODEL_G3.Binding(GRID_G3);
            MODEL_G3.EventValueChanged += MODEL_G3_EventValueChanged;

            // 2026-11-10 BOX 그리드는 정렬 끔: ITSLIB 그리드가 셀 값이 바뀌면 화면 순서(RowHandle)로 데이터 행을 찾아 편집을 확정해서
            //            정렬하면 고친 행이 확정되지 않아 수량 합계·납품량이 계산되지 않음
            (GRID_G3.View as TableView).AllowSorting = false;

            MODEL_G4.Binding(GRID_G4);
        }

        // 결과 팝업에서 고른 줄의 거래명세서 (등록 한 번에 발주별로 여러 장이 만들어질 수 있음)
        private void SetSelectedInvoice()
        {
            int row = MODEL_G2.CurrentIndex;
            if (row >= 0 && MODEL_G2.Columns.Contains("INVOICEKEY") && MODEL_G2.GetText(row, "INVOICEKEY") != "")
            {
                MODEL_A1.SetValue("INVOICEKEY", MODEL_G2.GetText(row, "INVOICEKEY"));
            }
        }

        // BOX 현황에 이미 쌓아 둔 이 발주의 수량 합계
        private decimal StagedQty(string mtrodrKey, string mtrodrSeq)
        {
            decimal sum = 0;
            for (int i = 0; i < MODEL_G4.Rows.Count; i++)
            {
                if (MODEL_G4.GetText(i, "MTRODRKEY") == mtrodrKey && MODEL_G4.GetText(i, "MTRODRSEQ") == mtrodrSeq)
                {
                    sum += MODEL_G4.GetDecimal(i, "BOXSUM");
                }
            }
            return sum;
        }

        // BOX 단위 수량·BOX 수량을 바꾸면 행 합계와 납품량(전체 합계)을 다시 계산
        private void MODEL_G3_EventValueChanged(int rowIndex, string fieldName)
        {
            if (fieldName == "BOXQTY" || fieldName == "BOXCNT")
            {
                CALCUL_TOTQTY();

                // 2026-11-10 입력 중인 셀 편집이 끝난 뒤 그리드를 다시 그려 수량 합계가 바로 보이게
                Dispatcher.BeginInvoke(new Action(() => GRID_G3.RefreshData()));
            }
        }

        // 납품량 = Σ (BOX 단위 수량 x BOX 수량)
        private decimal CALCUL_TOTQTY()
        {
            decimal totQty = 0;
            for (int i = 0; i < MODEL_G3.Rows.Count; i++)
            {
                decimal boxSum = MODEL_G3.GetDecimal(i, "BOXQTY") * MODEL_G3.GetDecimal(i, "BOXCNT");
                MODEL_G3.SetValue(i, "BOXSUM", boxSum);
                totQty += boxSum;
            }
            MODEL_A3.SetValue("TOTQTY", totQty);
            return totQty;
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            if (ItsLocalInfo.TMLCUSTCD != "")
            {
                cb_CUSTCD.Value = ItsLocalInfo.TMLCUSTCD.ToString();
            }

            MODEL_S1.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-01"));
            MODEL_S1.SetValue("EDATE", DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day).ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("PRDDATE", DateTime.Now.ToString("yyyy-MM-dd"));

            PANEL_A1.Close();
            PANEL_A3.Close();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 발주 조회
            if (commandName == "LIST_MTRODR")
            {
                ItsMaria.Set("TML1010_R01", "LIST_MTRODR");

                ItsMaria.AddModel(MODEL_S1);

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G1.SetData(ds.Tables[0]);
               // (GRID_G1.View as TableView).BestFitColumns();
            }
            // 정보입력 팝업 열기 (발주 행의 [입력] 버튼)
            else if (commandName == "POP_INPUT")
            {
                int rowIndex = MODEL_G1.CurrentIndex;
                if (rowIndex < 0) return;

                if (MODEL_S1.GetText("PRDDATE") == "")
                {
                    ShowMessageBox("", "출하일자를 입력하세요.");
                    return;
                }

                MODEL_A3.InitData();
                MODEL_A3.SetValue("MTRODRKEY", MODEL_G1.GetText(rowIndex, "MTRODRKEY"));
                MODEL_A3.SetValue("MTRODRSEQ", MODEL_G1.GetText(rowIndex, "MTRODRSEQ"));
                MODEL_A3.SetValue("ITEMNM", MODEL_G1.GetText(rowIndex, "ITEMNM"));
                MODEL_A3.SetValue("ITEMSPEC", MODEL_G1.GetText(rowIndex, "ITEMSPEC"));
                MODEL_A3.SetValue("ITEMCD", MODEL_G1.GetText(rowIndex, "ITEMCD"));
                MODEL_A3.SetValue("CUSTNM", MODEL_G1.GetText(rowIndex, "CUSTNM"));
                MODEL_A3.SetValue("OKQTY", MODEL_G1.GetDecimal(rowIndex, "OKQTY"));
                MODEL_A3.SetValue("HEATNO", "");
                MODEL_A3.SetValue("TOTQTY", 0);

                MODEL_G3.InitData();
                MODEL_G3.AddRow();

                PANEL_A3.Show();
            }
            // BOX 행 추가
            else if (commandName == "ADD_BOX")
            {
                MODEL_G3.AddRow();
            }
            // BOX 행 삭제
            else if (commandName == "DEL_BOX")
            {
                MODEL_G3.DeleteCurrentModel();
                CALCUL_TOTQTY();
            }
            // 정보입력 팝업 닫기
            else if (commandName == "CLOSE_INPUT")
            {
                PANEL_A3.Close();
            }
            // 정보입력 팝업 [확인] : 저장하지 않고 오른쪽 BOX 현황에 쌓음
            else if (commandName == "ADD_STAGE")
            {
                int boxCount = 0;
                for (int i = 0; i < MODEL_G3.Rows.Count; i++)
                {
                    decimal boxQty = MODEL_G3.GetDecimal(i, "BOXQTY");
                    decimal boxCnt = MODEL_G3.GetDecimal(i, "BOXCNT");

                    if (boxQty == 0 && boxCnt == 0) continue; // 빈 행은 건너뜀

                    if (boxQty <= 0)
                    {
                        ShowMessageBox("", "BOX 단위 수량을 입력하세요. (행 : " + (i + 1) + ")");
                        return;
                    }
                    if (boxCnt <= 0 || boxCnt != Math.Floor(boxCnt))
                    {
                        ShowMessageBox("", "BOX 수량을 1 이상의 정수로 입력하세요. (행 : " + (i + 1) + ")");
                        return;
                    }
                    boxCount += (int)boxCnt;
                }

                if (boxCount == 0)
                {
                    ShowMessageBox("", "BOX 단위 수량과 BOX 수량을 입력하세요.");
                    return;
                }

                decimal totQty = CALCUL_TOTQTY();
                decimal okQty = 0;
                decimal.TryParse(MODEL_A3.GetText("OKQTY"), out okQty);
                decimal stagedQty = StagedQty(MODEL_A3.GetText("MTRODRKEY"), MODEL_A3.GetText("MTRODRSEQ"));
                if (totQty + stagedQty > okQty)
                {
                    ShowMessageBox("", "납품량(" + totQty.ToString("#,0") + (stagedQty > 0 ? " + 현황에 담긴 " + stagedQty.ToString("#,0") : "") + ")이 미납량(" + okQty.ToString("#,0") + ")을 초과하였습니다.");
                    return;
                }

                // BOX 행마다 현황에 한 줄씩
                DataTable dt = new DataTable();
                foreach (string col in new string[] { "MTRODRKEY", "MTRODRSEQ", "ITEMCD", "ITEMNM", "HEATNO" }) dt.Columns.Add(col, typeof(string));
                foreach (string col in new string[] { "BOXQTY", "BOXCNT", "BOXSUM" }) dt.Columns.Add(col, typeof(decimal));
                for (int i = 0; i < MODEL_G3.Rows.Count; i++)
                {
                    decimal boxQty = MODEL_G3.GetDecimal(i, "BOXQTY");
                    decimal boxCnt = MODEL_G3.GetDecimal(i, "BOXCNT");
                    if (boxQty == 0 && boxCnt == 0) continue;

                    dt.Rows.Add(MODEL_A3.GetText("MTRODRKEY"), MODEL_A3.GetText("MTRODRSEQ"), MODEL_A3.GetText("ITEMCD"), MODEL_A3.GetText("ITEMNM"),
                                MODEL_A3.GetText("HEATNO").Trim(), boxQty, boxCnt, boxQty * boxCnt);
                }

                if (MODEL_G4.Rows.Count == 0) MODEL_G4.SetData(dt);
                else MODEL_G4.AddRow(dt);

                PANEL_A3.Close();
            }
            // BOX 현황에서 한 줄 빼기
            else if (commandName == "DEL_STAGE")
            {
                MODEL_G4.DeleteCurrentModel();
            }
            // BOX 현황 비우기
            else if (commandName == "CLEAR_STAGE")
            {
                if (MODEL_G4.Rows.Count == 0) return;
                ShowMessageBox(commandName, "납품등록 BOX 현황을 모두 지우시겠습니까?");
            }
            // 납품 등록 : BOX 현황 전체를 저장 (발주별 거래명세서 1장)
            else if (commandName == "ADD_MTRCUSTLOT")
            {
                if (MODEL_G4.Rows.Count == 0)
                {
                    ShowMessageBox("", "납품등록할 BOX 가 없습니다. 발주의 [입력] 에서 BOX 를 추가하세요.");
                    return;
                }
                if (MODEL_S1.GetText("PRDDATE") == "")
                {
                    ShowMessageBox("", "출하일자를 입력하세요.");
                    return;
                }

                List<string> orders = new List<string>();
                int boxCount = 0;
                decimal totQty = 0;
                for (int i = 0; i < MODEL_G4.Rows.Count; i++)
                {
                    string order = MODEL_G4.GetText(i, "MTRODRKEY") + "-" + MODEL_G4.GetText(i, "MTRODRSEQ");
                    if (!orders.Contains(order)) orders.Add(order);
                    boxCount += (int)MODEL_G4.GetDecimal(i, "BOXCNT");
                    totQty += MODEL_G4.GetDecimal(i, "BOXSUM");
                }

                ShowMessageBox(commandName, MODEL_S1.GetText("PRDDATE") + " 일자로 납품등록 하시겠습니까?\n발주 " + orders.Count + "건 (BOX " + boxCount + "개, 총 " + totQty.ToString("#,0") + "개)");
                return;
            }

            // 라벨재발행
            else if (commandName == "LABEL_REPRINT")
            {
                ItsMaria.Set("TML1010_R01", "LABEL_REPRINT");
                ItsMaria.AddOne("LOTKEY", MODEL_G2.GetText(MODEL_G2.CurrentIndex, "LOTKEY"));
                ItsMaria.AddOne("INWARE", MODEL_G2.GetText(MODEL_G2.CurrentIndex, "INWARE"));
                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                // 라벨출력 필요
                //ItsBarcode barcode = new ItsBarcode(ItsData.GetText(ds.Tables[0], 0, "LABELCD"));

                //barcode.SetDataTable(ds.Tables[1]);
                //barcode.PrinterName = ItsPrinter.DefaultPrintName;
                //barcode.Print(false);
            }
            // 납품 취소
            else if (commandName == "MTRCUST_INVOICE_CANCEL")
            {
                SetSelectedInvoice();
                ShowMessageBox(commandName, "거래명세서 [" + MODEL_A1.GetText("INVOICEKEY") + "] 를 납품 취소 하시겠습니까??");
                return;
            }
            // 거래명세표 출력 (재출력: 거래명세서 + 공정이동표(재고))
            else if (commandName == "MTRCUST_INVOICE_PRINT")
            {
                SetSelectedInvoice();
                if (MODEL_A1.GetText("INVOICEKEY") == "")
                {
                    ShowMessageBox("", "출력할 거래명세서가 없습니다.");
                    return;
                }

                PrintInvoice(MODEL_A1.GetText("INVOICEKEY"));
            }
            else if (commandName == "POP_MTRCUSTLOT")
            {
                ItsMaria.Set("TML1010_R01", "LIST_MTRCUSTLOT");
                ItsMaria.AddOne("MTRODRKEY", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "MTRODRKEY"));
                ItsMaria.AddOne("MTRODRSEQ", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "MTRODRSEQ"));

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_A1.SetValue("MTRODRKEY", ds.Tables[0].Rows[0]["MTRODRKEY"]);
                MODEL_A1.SetValue("MTRODRSEQ", ds.Tables[0].Rows[0]["MTRODRSEQ"]);
                MODEL_A1.SetValue("OUTDATE", ds.Tables[0].Rows[0]["PRDDATE"]);
                MODEL_A1.SetValue("OUTCUSTCD", ds.Tables[0].Rows[0]["OUTCUSTCD"]);
                MODEL_A1.SetValue("INCUSTCD", ds.Tables[0].Rows[0]["INCUSTCD"]);
                MODEL_G2.SetData(ds.Tables[0]);

                PANEL_A1.Show();
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            // 납품 취소
            if (commandName == "MTRCUST_INVOICE_CANCEL")
            {
                ItsMaria.Set("TML1010_R01", "DEL_MTRCUSTLOT");

                ItsMaria.AddModel(MODEL_A1);

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A1.Close();

                EventCommand("LIST_MTRODR");
            }
            // BOX 현황 비우기
            else if (commandName == "CLEAR_STAGE")
            {
                MODEL_G4.Clear();
            }
            // 납품 등록 : BOX 현황 전체 (행마다 발주·HEAT NO·BOX 단위 수량·BOX 수량), 발주별 거래명세서 1장
            else if (commandName == "ADD_MTRCUSTLOT")
            {
                ItsMaria.Set("TML1010_R01", "ADD_MTRCUSTLOT");
                ItsMaria.AddOne("PRDDATE", MODEL_S1.GetValue("PRDDATE"));

                for (int i = 0; i < MODEL_G4.Rows.Count; i++)
                {
                    ItsMaria.AddList("MTRODRKEY_LIST", MODEL_G4.GetText(i, "MTRODRKEY"));
                    ItsMaria.AddList("MTRODRSEQ_LIST", MODEL_G4.GetText(i, "MTRODRSEQ"));
                    ItsMaria.AddList("HEATNO_LIST", MODEL_G4.GetText(i, "HEATNO"));
                    ItsMaria.AddList("BOXQTY_LIST", MODEL_G4.GetDecimal(i, "BOXQTY"));
                    ItsMaria.AddList("BOXCNT_LIST", MODEL_G4.GetDecimal(i, "BOXCNT"));
                }

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G4.Clear();

                // 결과 팝업 : 이번에 만든 거래명세서들의 LOT (재출력·납품 취소는 고른 줄의 거래명세서)
                MODEL_A1.SetValue("INVOICEKEY", ds.Tables[0].Rows[0]["INVOICEKEY"]);
                MODEL_A1.SetValue("OUTDATE", ds.Tables[0].Rows[0]["PRDDATE"]);
                MODEL_A1.SetValue("OUTCUSTCD", ds.Tables[0].Rows[0]["OUTCUSTCD"]);
                MODEL_A1.SetValue("INCUSTCD", ds.Tables[0].Rows[0]["INCUSTCD"]);
                MODEL_G2.SetData(ds.Tables[0]);

                PANEL_A1.Show();

                // 등록 직후 거래명세서마다 거래명세서 + 공정이동표(재고) 자동 출력
                List<string> invoiceKeys = new List<string>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string key = row["INVOICEKEY"].ToString();
                    if (!invoiceKeys.Contains(key)) invoiceKeys.Add(key);
                }
                foreach (string key in invoiceKeys)
                {
                    PrintInvoice(key);
                }
            }
        }

        // 2026-11-11 거래명세서(공급자보관용 + 공급받는자 보관용) + 공정이동표(재고)(LOT 1개당 1장, A4 한 장에 2개)
        // 확인창 없이 POP 에서 고른 프린터로 바로 인쇄. 양식은 COMPJT\TMLPRINT 의 MTR_1 / MTR_2 (AAALIB\TMLPRINT.exe)
        private void PrintInvoice(string invoiceKey)
        {
            ItsMaria.Set("TML1010_R01", "PRINT_INVOICE");
            ItsMaria.AddOne("INVOICEKEY", invoiceKey);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            try
            {
                TMLPRINT.MTR_1 rptInvoice = new TMLPRINT.MTR_1(ds, true);
                rptInvoice.PrintDirect(ItsPrinter.BarcodePrintName);

                TMLPRINT.MTR_2 rptMove = new TMLPRINT.MTR_2(ds.Tables[4]);
                rptMove.PrintDirect(ItsPrinter.BarcodePrintName);
            }
            catch (Exception ex)
            {
                ShowMessageBox("", "거래명세서 출력에 실패했습니다. 프린터를 확인해주세요.\n" + ex.Message);
            }
        }

        public override void EventPopClose(string panelName)
        {
            base.EventPopClose(panelName);

            if (panelName == "PANEL_A1")
            {
                EventCommand("LIST_MTRODR");
            }
        }
    }
}

