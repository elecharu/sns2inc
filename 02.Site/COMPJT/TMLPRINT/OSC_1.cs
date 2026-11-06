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
    /// // 2026-11-04 [외주처 소모품 불출] 공구불출증 (A4). TML1030_R02 불출 / TML1030_R03 수령 에서 출력
    /// ds = TML1030_R02 PRINT_RELEASE 결과
    ///      Tables[0] 헤더 (RELEASEKEY, RELEASEDATE, EQMNM, EMPNM_RELEASE, EMPNM_RECIEVE, EMPNM_CONFIRM)
    ///      Tables[1] 상세 (ITEMSPEC, RELQTY)
    /// 서명칸: 요청자 = 수령자, 대구텍 = 불출자, S & S = 확정자 (안 했으면 빈칸)
    /// 웹 수령확정(MST3001_R06)은 같은 양식을 04.Report\PAGEMST\MST3001\R06A 로 따로 가진다 (양식 고치면 둘 다)
    /// 페이지마다 머리(제목·바코드·라인·서명칸·날짜·표 머리)를 반복하고, 공구규격/요청수량은 12줄 단위로 빈 줄을 채운다
    /// 현장 화면은 PrintDirect 로 바로 인쇄. 미리보기 창(ShowPop)도 쓸 수 있게 ITSLIB.ItsReport 를 상속
    /// </summary>
    public partial class OSC_1 : ITSLIB.ItsReport
    {
        const int ROWS_PER_PAGE = 12;

        public OSC_1()
        {
            InitializeComponent();
        }

        public OSC_1(DataSet ds)
        {
            InitializeComponent();

            SET_DATA(ds);
        }

        public void SET_DATA(DataSet ds)
        {
            DataTable head = ds.Tables[0];
            DataTable detail = ds.Tables[1];

            this.bar_RELEASEKEY.Text = ItsData.GetText(head, 0, "RELEASEKEY");                          // 불출 바코드
            this.lbl_EQMNM.Text = "(    " + ItsData.GetText(head, 0, "EQMNM") + "    )LINE";             // 불출라인
            this.lbl_SIGN1.Text = head.Columns.Contains("EMPNM_RECIEVE") ? ItsData.GetText(head, 0, "EMPNM_RECIEVE") : "";   // 요청자 = 수령자
            this.lbl_SIGN2.Text = head.Columns.Contains("EMPNM_RELEASE") ? ItsData.GetText(head, 0, "EMPNM_RELEASE") : "";   // 대구텍 = 불출자
            this.lbl_SIGN3.Text = head.Columns.Contains("EMPNM_CONFIRM") ? ItsData.GetText(head, 0, "EMPNM_CONFIRM") : "";   // S & S = 확정자

            string releaseDate = ItsData.GetText(head, 0, "RELEASEDATE");   // yyyy-MM-dd
            DateTime dt;
            this.lbl_DATE.Text = releaseDate;
            if (DateTime.TryParse(releaseDate, out dt))
            {
                this.lbl_DATE.Text = dt.Year + "    년      " + dt.Month + "  월      " + dt.Day + "  일";
            }

            // 상세 (12줄 단위로 빈 줄을 채워 페이지마다 표가 끝까지 그려지게 함)
            DataTable rows = new DataTable();
            rows.Columns.Add("ITEMSPEC", typeof(string));
            rows.Columns.Add("RELQTY", typeof(string));
            foreach (DataRow r in detail.Rows)
            {
                decimal qty;
                decimal.TryParse(r["RELQTY"].ToString(), out qty);
                rows.Rows.Add(r["ITEMSPEC"].ToString(), qty.ToString("#,##0.##"));
            }
            int pad = Math.Max(ROWS_PER_PAGE, (int)Math.Ceiling(rows.Rows.Count / (double)ROWS_PER_PAGE) * ROWS_PER_PAGE);
            while (rows.Rows.Count < pad)
            {
                rows.Rows.Add("", "");
            }
            this.DataSource = rows;
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
