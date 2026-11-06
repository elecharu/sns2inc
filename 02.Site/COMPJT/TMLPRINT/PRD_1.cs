using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using System.Data;
using ITSLIB;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-06 [생산실적등록] 공정이동표 (A4). TML2010_R01 작업완료 후 양품로트·불량로트 각 1장 출력
    /// ds = TML2010_R01 PRINT_MOVE 결과
    ///      Tables[0] 생산품·생산정보·생산로트 (ITEMCD, ITEMNM, ITEMSPEC, HEATNO, HEATLOTKEY, PRDDATE, EMPNM, RSTTIME,
    ///                LOTKEY, LINENM, PRCNM, EQMNM, UNITNM, GOODQTY, BADQTY, BADTPNM, PRINTEMPNM, PRINTTIME)
    ///      Tables[1] 로트추적 (NO, ITEMCD, LINENM, PRCNM, LOTKEY) 현공정 생산로트 → 이전 공정 → 원소재 순
    /// isBad = true 면 불량로트: 수량은 불량수량, 제목 뒤에 "(불량 대분류)"
    /// </summary>
    public partial class PRD_1 : ITSLIB.ItsReport
    {
        public PRD_1()
        {
            InitializeComponent();
        }

        public PRD_1(DataSet ds, bool isBad)
        {
            InitializeComponent();

            SET_DATA(ds, isBad);
        }

        public void SET_DATA(DataSet ds, bool isBad)
        {
            DataTable head = ds.Tables[0];

            this.lbl_TITLE.Text = isBad ? "공 정 이 동 표 (" + ItsData.GetText(head, 0, "BADTPNM") + ")" : "공 정 이 동 표";

            this.C_ITEMCD.Text = ItsData.GetText(head, 0, "ITEMCD");
            this.C_ITEMNM.Text = ItsData.GetText(head, 0, "ITEMNM");
            this.C_ITEMSPEC.Text = ItsData.GetText(head, 0, "ITEMSPEC");
            this.C_EMPNM.Text = ItsData.GetText(head, 0, "EMPNM");
            this.C_HEATNO.Text = ItsData.GetText(head, 0, "HEATNO");
            this.C_HEATLOTKEY.Text = ItsData.GetText(head, 0, "HEATLOTKEY");
            this.C_PRDDATE.Text = ItsData.GetText(head, 0, "PRDDATE");
            this.C_RSTTIME.Text = ItsData.GetText(head, 0, "RSTTIME");

            this.bar_LOTKEY.Text = ItsData.GetText(head, 0, "LOTKEY");

            this.C_LINENM.Text = ItsData.GetText(head, 0, "LINENM");
            this.C_PRCNM.Text = ItsData.GetText(head, 0, "PRCNM");
            this.C_EQMNM.Text = ItsData.GetText(head, 0, "EQMNM");
            this.C_LOTKEY.Text = ItsData.GetText(head, 0, "LOTKEY");
            this.C_UNITNM.Text = ItsData.GetText(head, 0, "UNITNM");
            this.C_QTY.Text = ItsData.GetText(head, 0, isBad ? "BADQTY" : "GOODQTY");

            this.lbl_PRINT.Text = ItsData.GetText(head, 0, "PRINTEMPNM") + " " + ItsData.GetText(head, 0, "PRINTTIME");

            // 로트추적 (현공정 생산로트가 첫 줄, 원소재가 마지막 줄)
            this.DataSource = ds.Tables[1];
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄 (현장 화면은 POP 에서 고른 프린터 ItsPrinter.BarcodePrintName 을 넘김)
        public void PrintDirect(string printerName)
        {
            this.ShowPrintMarginsWarning = false;
            this.ShowPrintStatusDialog = false;
            this.CreateDocument();
            PrintToolBase tool = new PrintToolBase(this.PrintingSystem);
            tool.Print(printerName);
        }
    }
}
