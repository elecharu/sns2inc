using System;
using System.Drawing;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-16 [외주입고] 공정이동표(입고) 양품 + 공정이동표(시편). 입고한 LOT 1개당 양품 1장, 시편수량이 있으면 시편 1장 더 (A4 세로, 한 장에 LOT 1개)
    /// dt = TML1020_R01 ADD_MTRIN 결과 Tables[0]
    ///      (ITEMCD, ITEMNM, ITEMSPEC, HEATNO, OUTWARENM, INWARENM, TESTWARENM, EMPNM, INDATE, REGTIME, PRINTTIME, LOTKEY, UNITNM, GOODQTY, TESTQTY)
    /// 양식은 코드로 그린다 (Detail 밴드 1개 = 이동표 1장). 양품 → 시편 순으로 LOT 마다 이어서 나옴
    /// </summary>
    public class MTR_3 : XtraReport
    {
        const float W = 707F;          // A4 세로 827 - 좌우 여백 60 x 2
        const float DETAIL_H = 1060F;  // 1169 - 위 50 - 아래 50 (조금 여유)
        const float HEAD_FONT = 11F;
        const float VALUE_FONT = 11F;

        public MTR_3(DataTable dt)
        {
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Landscape = false;
            this.PageWidth = 827;
            this.PageHeight = 1169;
            this.Margins = new System.Drawing.Printing.Margins(60, 60, 50, 50);
            this.Font = new Font(RptKit.FONT, HEAD_FONT);

            DetailBand detail = new DetailBand();
            detail.HeightF = DETAIL_H;
            detail.PageBreak = PageBreak.AfterBandExceptLastEntry; // 이동표 1장당 1페이지
            this.Bands.Add(detail);
            this.Bands.Add(new TopMarginBand() { HeightF = 50F });
            this.Bands.Add(new BottomMarginBand() { HeightF = 50F });

            // 제목 (양품 = 공 정 이 동 표(입고), 시편 = 공 정 이 동 표(시편))
            XRLabel title = RptKit.Label("", 0F, 150F, W, 85F, 36F, true, TextAlignment.MiddleCenter, BorderSide.None);
            title.DataBindings.Add(new XRBinding("Text", null, "TITLE"));
            detail.Controls.Add(title);

            // 품번·품명·규격·출고창고·등록자 / HEAT NO·열처리 LOTNO·입고일자·입고창고·등록일
            XRTable head = RptKit.Grid(0F, 270F, new float[] { 100F, 270F, 145F, W - 515F }, new float[] { 42F, 42F, 42F, 42F, 42F });
            Row(head.Rows[0], "품번", "ITEMCD", "HEAT NO", "HEATNO");
            Row(head.Rows[1], "품명", "ITEMNM", "열처리 LOTNO", null);
            Row(head.Rows[2], "규격", "ITEMSPEC", "입고일자", "INDATE");
            Row(head.Rows[3], "출고창고", "OUTWARENM", "입고창고", "INWARENM");
            Row(head.Rows[4], "등록자", "EMPNM", "등록일", "REGTIME");
            detail.Controls.Add(head);

            // LOT 바코드
            detail.Controls.Add(RptKit.Barcode("LOTKEY", (W - 350F) / 2F, 500F, 350F, 100F, 11F));

            // LOT NO·단위·입고수량·박스 내 수량·비고
            XRTable lot = RptKit.Grid(0F, 620F, new float[] { 240F, 80F, 100F, 130F, W - 550F }, new float[] { 42F, 42F });
            string[] heads = { "LOT NO", "단위", "입고수량", "박스 내 수량", "비고" };
            string[] fields = { "LOTKEY", "UNITNM", "QTY", null, null };
            for (int i = 0; i < 5; i++)
            {
                RptKit.Text(lot.Rows[0].Cells[i], heads[i], HEAD_FONT, true, TextAlignment.MiddleCenter);
                if (fields[i] != null) RptKit.Bind(lot.Rows[1].Cells[i], fields[i], VALUE_FONT, true, TextAlignment.MiddleCenter);
                else RptKit.Text(lot.Rows[1].Cells[i], "", VALUE_FONT, true, TextAlignment.MiddleCenter);
            }
            detail.Controls.Add(lot);

            // 아래 오른쪽 : 등록자 · 등록일시(초)
            XRLabel stamp = RptKit.Label("", 0F, 1000F, W, 30F, 12F, true, TextAlignment.MiddleRight, BorderSide.None);
            stamp.DataBindings.Add(new XRBinding("Text", null, "STAMP"));
            detail.Controls.Add(stamp);

            this.DataSource = BuildSheets(dt);
        }

        // 머리 표 한 줄 : 머리글(왼쪽) 값(왼쪽 정렬, field 없으면 빈칸) 머리글 값
        private void Row(XRTableRow row, string h1, string f1, string h2, string f2)
        {
            RptKit.Text(row.Cells[0], h1, HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Bind(row.Cells[1], f1, VALUE_FONT, true, TextAlignment.MiddleLeft);
            RptKit.Text(row.Cells[2], h2, HEAD_FONT, true, TextAlignment.MiddleCenter);
            if (f2 != null) RptKit.Bind(row.Cells[3], f2, VALUE_FONT, true, TextAlignment.MiddleLeft);
            else RptKit.Text(row.Cells[3], "", VALUE_FONT, true, TextAlignment.MiddleLeft);
        }

        // LOT 1개 → 양품 1장(수량 있으면) + 시편 1장(수량 있으면)
        private DataTable BuildSheets(DataTable dt)
        {
            DataTable sheets = new DataTable();
            foreach (string col in new string[] { "TITLE", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "OUTWARENM", "INWARENM", "INDATE", "EMPNM", "REGTIME", "STAMP", "LOTKEY", "UNITNM", "QTY" })
            {
                sheets.Columns.Add(col, typeof(string));
            }

            foreach (DataRow r in dt.Rows)
            {
                decimal good = ToDec(r["GOODQTY"]);
                decimal test = ToDec(r["TESTQTY"]);
                if (good > 0) AddSheet(sheets, r, "공 정 이 동 표(입고)", r["INWARENM"], good);
                if (test > 0) AddSheet(sheets, r, "공 정 이 동 표(시편)", r["TESTWARENM"], test);
            }
            return sheets;
        }

        private void AddSheet(DataTable sheets, DataRow r, string title, object inWare, decimal qty)
        {
            DataRow s = sheets.NewRow();
            s["TITLE"] = title;
            s["ITEMCD"] = Str(r["ITEMCD"]);
            s["ITEMNM"] = Str(r["ITEMNM"]);
            s["ITEMSPEC"] = Str(r["ITEMSPEC"]);
            s["HEATNO"] = Str(r["HEATNO"]);
            s["OUTWARENM"] = Str(r["OUTWARENM"]);
            s["INWARENM"] = Str(inWare);
            s["INDATE"] = Str(r["INDATE"]);
            s["EMPNM"] = Str(r["EMPNM"]);
            s["REGTIME"] = Str(r["REGTIME"]);
            s["STAMP"] = Str(r["EMPNM"]) + " " + Str(r["PRINTTIME"]);
            s["LOTKEY"] = Str(r["LOTKEY"]);
            s["UNITNM"] = Str(r["UNITNM"]);
            s["QTY"] = RptKit.Qty(qty);
            sheets.Rows.Add(s);
        }

        private static string Str(object v)
        {
            return (v == null || v == DBNull.Value) ? "" : v.ToString();
        }

        private static decimal ToDec(object v)
        {
            decimal d;
            if (v == null || v == DBNull.Value || !decimal.TryParse(v.ToString(), out d)) return 0;
            return d;
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄
        public void PrintDirect(string printerName)
        {
            RptKit.PrintDirect(this, printerName);
        }
    }
}
