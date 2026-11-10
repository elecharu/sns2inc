using System;
using System.Drawing;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-09 [유상사급 납품등록] 공정이동표(재고). LOT(BOX) 1개당 1장, A4 가로 한 장에 1개
    /// ds = TML1010_R01 PRINT_INVOICE 결과 Tables[4]
    ///      (ITEMCD, ITEMNM, ITEMSPEC, HEATNO, EMPNM, PRINTDATE, LOTKEY, UNITNM, LOTQTY)
    /// 양식은 코드로 그린다 (Detail 밴드 1개 = 이동표 1장, LOT 마다 페이지 나눔)
    /// </summary>
    public class MTR_2 : XtraReport
    {
        const float W = 1089F;         // A4 가로 1169 - 좌우 여백 40 x 2
        const float DETAIL_H = 745F;   // 827 - 위 40 - 아래 40 (조금 여유)
        const string FONT = "맑은 고딕";
        const float HEAD_FONT = 15F;   // 머리글 칸 글자
        const float VALUE_FONT = 16F;  // 값 칸 글자

        public MTR_2(DataTable dt)
        {
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Landscape = true;
            this.PageWidth = 1169;
            this.PageHeight = 827;
            this.Margins = new System.Drawing.Printing.Margins(40, 40, 40, 40);
            this.Font = new Font(FONT, HEAD_FONT);

            DetailBand detail = new DetailBand();
            detail.HeightF = DETAIL_H;
            detail.PageBreak = PageBreak.AfterBandExceptLastEntry; // LOT 1개당 1페이지
            this.Bands.Add(detail);
            this.Bands.Add(new TopMarginBand() { HeightF = 40F });
            this.Bands.Add(new BottomMarginBand() { HeightF = 40F });

            // 제목
            XRLabel title = new XRLabel();
            title.Text = "공 정 이 동 표 ( 재 고 )";
            title.Font = new Font(FONT, 40F, FontStyle.Bold);
            title.TextAlignment = TextAlignment.MiddleCenter;
            title.LocationF = new PointF(0F, 10F);
            title.SizeF = new SizeF(W, 85F);
            detail.Controls.Add(title);

            // 품번·품명·규격 / HEAT NO·발행자·발행일
            float[] headW = { 160F, 420F, 180F, W - 760F };
            XRTable head = NewTable(0F, 125F, headW, new float[] { 58F, 58F, 58F });
            SetRow(head.Rows[0], new string[] { "품번", null, "HEAT NO", null }, new string[] { null, "ITEMCD", null, "HEATNO" });
            SetRow(head.Rows[1], new string[] { "품명", null, "발행자", null }, new string[] { null, "ITEMNM", null, "EMPNM" });
            SetRow(head.Rows[2], new string[] { "규격", null, "발행일", null }, new string[] { null, "ITEMSPEC", null, "PRINTDATE" });
            detail.Controls.Add(head);

            // 작업장·공정·생산설비 (빈칸, 현장에서 기입)
            float[] workW = { 363F, 363F, W - 726F };
            XRTable work = NewTable(0F, 330F, workW, new float[] { 40F, 62F });
            SetRow(work.Rows[0], new string[] { "작업장", "공정", "생산설비" }, null);
            SetRow(work.Rows[1], new string[] { "", "", "" }, null);
            detail.Controls.Add(work);

            // LOT 바코드
            XRBarCode bar = new XRBarCode();
            bar.Symbology = new Code128Generator();
            bar.AutoModule = true;
            bar.ShowText = true;
            bar.Font = new Font(FONT, 13F);
            bar.TextAlignment = TextAlignment.BottomCenter;
            bar.LocationF = new PointF((W - 560F) / 2F, 455F);
            bar.SizeF = new SizeF(560F, 130F);
            bar.DataBindings.Add(new XRBinding("Text", null, "LOTKEY"));
            detail.Controls.Add(bar);

            // LOT NO·단위·수량
            float[] lotW = { 540F, 225F, W - 765F };
            XRTable lot = NewTable(0F, 605F, lotW, new float[] { 52F, 66F });
            SetRow(lot.Rows[0], new string[] { "LOT NO", "단위", "수량" }, null);
            SetRow(lot.Rows[1], new string[] { null, null, null }, new string[] { "LOTKEY", "UNITNM", "LOTQTY" });
            detail.Controls.Add(lot);

            this.DataSource = dt;
        }

        // 테두리 있는 표 (rowH 합 = 표 높이)
        private XRTable NewTable(float x, float y, float[] colW, float[] rowH)
        {
            XRTable table = new XRTable();
            table.BeginInit();
            float h = 0F;
            foreach (float rh in rowH)
            {
                XRTableRow row = new XRTableRow();
                row.Weight = rh;
                foreach (float cw in colW)
                {
                    XRTableCell cell = new XRTableCell();
                    cell.Weight = cw;
                    row.Cells.Add(cell);
                }
                table.Rows.Add(row);
                h += rh;
            }
            table.LocationF = new PointF(x, y);
            table.SizeF = new SizeF(W, h);
            table.Borders = BorderSide.All;
            table.BorderWidth = 1F;
            table.EndInit();
            return table;
        }

        // 머리글(text, 굵게) 또는 값(field 바인딩) 채우기. 값 칸은 높이가 늘지 않게 잠근다
        private void SetRow(XRTableRow row, string[] texts, string[] fields)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                XRTableCell cell = row.Cells[i];
                cell.Borders = BorderSide.All;
                cell.CanGrow = false;
                cell.CanShrink = false;
                cell.WordWrap = true;
                cell.Padding = new PaddingInfo(10, 10, 0, 0);

                string field = fields == null ? null : fields[i];
                if (field != null)
                {
                    cell.DataBindings.Add(new XRBinding("Text", null, field));
                    cell.Font = new Font(FONT, VALUE_FONT, FontStyle.Bold);
                    // 왼쪽 표의 값 칸은 왼쪽 정렬, 아래 LOT 표는 가운데
                    cell.TextAlignment = (row.Cells.Count == 4) ? TextAlignment.MiddleLeft : TextAlignment.MiddleCenter;
                }
                else
                {
                    cell.Text = texts[i] ?? "";
                    cell.Font = new Font(FONT, HEAD_FONT, FontStyle.Bold);
                    cell.TextAlignment = TextAlignment.MiddleCenter;
                }
            }
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄
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
