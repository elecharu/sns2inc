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
        }

        // BOX 단위 수량·BOX 수량을 바꾸면 행 합계와 납품량(전체 합계)을 다시 계산
        private void MODEL_G3_EventValueChanged(int rowIndex, string fieldName)
        {
            if (fieldName == "BOXQTY" || fieldName == "BOXCNT")
            {
                CALCUL_TOTQTY();
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
            // 납품 등록 (정보입력 팝업 [확인])
            else if (commandName == "ADD_MTRCUSTLOT")
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
                if (totQty > okQty)
                {
                    ShowMessageBox("", "납품량(" + totQty.ToString("#,0") + ")이 미납량(" + okQty.ToString("#,0") + ")을 초과하였습니다.");
                    return;
                }

                ShowMessageBox(commandName, MODEL_S1.GetText("PRDDATE") + " 일자로 BOX " + boxCount + "개, 총 " + totQty.ToString("#,0") + "개를 납품등록 하시겠습니까?");
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
                ShowMessageBox(commandName, "납품 취소 하시겠습니까??");
                return;
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
            // 납품 등록
            else if (commandName == "ADD_MTRCUSTLOT")
            {
                ItsMaria.Set("TML1010_R01", "ADD_MTRCUSTLOT");
                ItsMaria.AddOne("PRDDATE", MODEL_S1.GetValue("PRDDATE"));
                ItsMaria.AddOne("MTRODRKEY", MODEL_A3.GetText("MTRODRKEY"));
                ItsMaria.AddOne("MTRODRSEQ", MODEL_A3.GetText("MTRODRSEQ"));
                ItsMaria.AddOne("HEATNO", MODEL_A3.GetText("HEATNO").Trim());

                for (int i = 0; i < MODEL_G3.Rows.Count; i++)
                {
                    if (MODEL_G3.GetDecimal(i, "BOXQTY") == 0 && MODEL_G3.GetDecimal(i, "BOXCNT") == 0) continue; // 빈 행

                    ItsMaria.AddList("BOXQTY_LIST", MODEL_G3.GetDecimal(i, "BOXQTY"));
                    ItsMaria.AddList("BOXCNT_LIST", MODEL_G3.GetDecimal(i, "BOXCNT"));
                }

                DataSet ds = ItsMaria.Call();

                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A3.Close();

                MODEL_A1.SetValue("INVOICEKEY", ds.Tables[0].Rows[0]["INVOICEKEY"]);
                MODEL_A1.SetValue("OUTDATE", ds.Tables[0].Rows[0]["PRDDATE"]);
                MODEL_A1.SetValue("OUTCUSTCD", ds.Tables[0].Rows[0]["OUTCUSTCD"]);
                MODEL_A1.SetValue("INCUSTCD", ds.Tables[0].Rows[0]["INCUSTCD"]);
                MODEL_G2.SetData(ds.Tables[0]);

                PANEL_A1.Show();
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

