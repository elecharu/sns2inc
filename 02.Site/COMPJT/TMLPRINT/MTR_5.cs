using System;
using System.Drawing;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-16 [사업장 간 이동] 재고이동표 (A4 가로 1장, LOT 줄이 많으면 이어서)
    /// ds = TML1020_R03 ADD_MOVE 결과
    ///   Tables[1] 머리글 1행 (MOVEDATE, EMPNM, OUTNM 출고 공장(창고), INNM 입고 공장(창고))
    ///   Tables[2] LOT 목록 (LOTKEY, ITEMCD, ITEMNM, ITEMSPEC, HEATNO, UNITNM, MOVEQTY)
    /// 양식은 코드로 그린다
    /// </summary>
    public class MTR_5 : XtraReport
    {
        const float W = 1089F;     // A4 가로 1169 - 좌우 여백 40 x 2
        const float HEAD_FONT = 10F;
        const float VALUE_FONT = 10F;
        // LOT 표 칸 너비 : NO, LOT NO, 품목코드, 품명, 규격, HEAT NO, 이동량
        static readonly float[] COLS = { 31F, 194F, 129F, 189F, 222F, 227F, 97F };

        public MTR_5(DataSet ds)
        {
            DataRow hd = ds.Tables[1].Rows[0];
            DataTable lots = ds.Tables[2];

            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Landscape = true;
            this.PageWidth = 1169;
            this.PageHeight = 827;
            this.Margins = new System.Drawing.Printing.Margins(40, 40, 40, 40);
            this.Font = new Font(RptKit.FONT, HEAD_FONT);

            // ----- 머리글 (처음 한 번) : 제목 + 이동일자·등록자 / 출고 공장·입고 공장 -----
            ReportHeaderBand header = new ReportHeaderBand();
            header.HeightF = 235F;
            this.Bands.Add(header);

            header.Controls.Add(RptKit.Label("재 고 이 동 표", 0F, 30F, W, 80F, 32F, true, TextAlignment.MiddleCenter, BorderSide.None));

            XRTable info = RptKit.Grid(0F, 125F, new float[] { 72F, 138F }, new float[] { 42F, 42F });
            RptKit.Text(info.Rows[0].Cells[0], "이동일자", HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(info.Rows[0].Cells[1], S(hd, "MOVEDATE"), VALUE_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(info.Rows[1].Cells[0], "등록자", HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(info.Rows[1].Cells[1], S(hd, "EMPNM"), VALUE_FONT, true, TextAlignment.MiddleCenter);
            header.Controls.Add(info);

            XRTable fac = RptKit.Grid(W - 480F, 125F, new float[] { 107F, 131F, 107F, 135F }, new float[] { 42F, 42F });
            RptKit.Text(fac.Rows[0].Cells[0], "출고 공장\r\n(창고)", HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(fac.Rows[0].Cells[1], S(hd, "OUTNM"), HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(fac.Rows[0].Cells[2], "입고 공장\r\n(창고)", HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(fac.Rows[0].Cells[3], S(hd, "INNM"), HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(fac.Rows[1].Cells[0], "출고 확인", HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(fac.Rows[1].Cells[1], "", HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(fac.Rows[1].Cells[2], "입고 확인", HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(fac.Rows[1].Cells[3], "", HEAD_FONT, true, TextAlignment.MiddleCenter);
            header.Controls.Add(fac);

            // ----- 칸 이름 줄 (쪽마다 되풀이) -----
            string unit = lots.Rows.Count > 0 ? S(lots.Rows[0], "UNITNM") : "";
            if (unit == "") unit = "EA";

            GroupHeaderBand colHead = new GroupHeaderBand();
            colHead.HeightF = 40F;
            colHead.RepeatEveryPage = true;
            colHead.GroupFields.Add(new GroupField("GRP"));
            this.Bands.Add(colHead);

            XRTable heads = RptKit.Grid(0F, 0F, COLS, new float[] { 40F });
            string[] headText = { "NO", "LOT NO", "품목코드", "품명", "규격", "HEAT NO", "이동량(" + unit + ")" };
            for (int i = 0; i < headText.Length; i++)
            {
                RptKit.Text(heads.Rows[0].Cells[i], headText[i], 9F, true, TextAlignment.MiddleCenter);
            }
            colHead.Controls.Add(heads);

            // ----- LOT 줄 -----
            DetailBand detail = new DetailBand();
            detail.HeightF = 50F;
            this.Bands.Add(detail);

            XRTable row = RptKit.Grid(0F, 0F, COLS, new float[] { 50F });
            row.Rows[0].Cells[1].Controls.Add(RptKit.Barcode("LOTKEY", 4F, 4F, COLS[1] - 8F, 42F, 7F));
            string[] fields = { "NO", null, "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "QTY" };
            for (int i = 0; i < fields.Length; i++)
            {
                if (i == 1) continue;
                RptKit.Bind(row.Rows[0].Cells[i], fields[i], 9F, false, (i == 6) ? TextAlignment.MiddleRight : TextAlignment.MiddleCenter);
            }
            row.Rows[0].Cells[6].Padding = new PaddingInfo(4, 8, 0, 0);
            detail.Controls.Add(row);

            // ----- 맨 아래 : 총 이동량 -----
            ReportFooterBand footer = new ReportFooterBand();
            footer.HeightF = 42F;
            this.Bands.Add(footer);

            decimal total = 0;
            foreach (DataRow r in lots.Rows)
            {
                decimal q;
                if (decimal.TryParse(S(r, "MOVEQTY"), out q)) total += q;
            }
            XRTable sum = RptKit.Grid(0F, 0F, new float[] { 856F, 107F, 126F }, new float[] { 42F });
            RptKit.Text(sum.Rows[0].Cells[0], "", HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(sum.Rows[0].Cells[1], "총 이동량", 9F, true, TextAlignment.MiddleCenter);
            RptKit.Text(sum.Rows[0].Cells[2], RptKit.Qty(total), 9F, true, TextAlignment.MiddleCenter);
            footer.Controls.Add(sum);

            this.Bands.Add(new TopMarginBand() { HeightF = 40F });
            this.Bands.Add(new BottomMarginBand() { HeightF = 40F });

            // LOT 목록 (GRP = 칸 이름 줄을 쪽마다 되풀이하기 위한 묶음 값, NO = 순번)
            DataTable data = new DataTable();
            foreach (string col in new string[] { "GRP", "NO", "LOTKEY", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "QTY" }) data.Columns.Add(col, typeof(string));
            int no = 0;
            foreach (DataRow r in lots.Rows)
            {
                DataRow d = data.NewRow();
                d["GRP"] = "1";
                d["NO"] = (++no).ToString();
                foreach (string col in new string[] { "LOTKEY", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO" }) d[col] = S(r, col);
                d["QTY"] = RptKit.Qty(r["MOVEQTY"]);
                data.Rows.Add(d);
            }
            this.DataSource = data;
        }

        private static string S(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col)) return "";
            object v = r[col];
            return (v == null || v == DBNull.Value) ? "" : v.ToString();
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄
        public void PrintDirect(string printerName)
        {
            RptKit.PrintDirect(this, printerName);
        }
    }
}
