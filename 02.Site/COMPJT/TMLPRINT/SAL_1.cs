using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-10 [출하등록] 거래명세서 (출고부서용, A4 세로). 납품처 1곳 = 1부, 품목은 LOT 1개 = 1줄 (한 장에 18줄, 넘으면 다음 장)
    /// ds = TML5000_R01 PRINT_SALOUT 결과
    ///      Tables[0] 공급자 (BDVNM, BNAME, BNUM, ADDR, TEL, FAX, ITYPE, IKIND)
    ///      Tables[1] 공급받는자 (COMPNAME, PRES, BUSNM, ADDR, TEL, FAX, DTYPE, DKIND, SALTIME, EMPNM)
    ///      Tables[2] 품목 (ITEMCD, ITEMNM, ITEMSPEC, OUTQTY, BOX, BOXNM, REMARK)
    ///      Tables[3] 총 수량·출하번호 (SUMQTY, GROUPKEY, REMARK)
    /// 양식은 코드로 그린다 (PageHeader = 제목·공급자·공급받는자·품목 머리글, Detail = 품목 1줄, PageFooter = 출하번호·총 수량)
    /// </summary>
    public class SAL_1 : XtraReport
    {
        const string FONT = "맑은 고딕";
        const float W = 787F;          // A4 827 - 좌우 여백 20 x 2
        const int ROWS_PER_PAGE = 18;  // 한 장에 품목 줄 수
        const float ROW_H = 43.8F;     // 18줄 = 788 → 머리 316 + 바닥 36 과 합쳐 페이지 높이(1145)에 거의 딱 맞음 (19줄은 안 들어감)

        public SAL_1(DataSet ds)
        {
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageWidth = 827;
            this.PageHeight = 1169;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 22, 2);
            this.Font = new Font(FONT, 10F);

            DataRow supplier = ds.Tables[0].Rows[0];
            DataRow buyer = ds.Tables[1].Rows[0];
            DataRow total = ds.Tables[3].Rows[0];

            this.Bands.Add(new TopMarginBand() { HeightF = 22F });
            this.Bands.Add(new BottomMarginBand() { HeightF = 2F });

            // ---------------- 머리 : 제목·공급자·공급받는자·품목 머리글 ----------------
            PageHeaderBand head = new PageHeaderBand();
            head.HeightF = 316F;
            this.Bands.Add(head);

            // 제목 영역 (로고 + 제목) 테두리
            head.Controls.Add(Box(0F, 0F, 587F, 70F));

            XRPictureBox logo = new XRPictureBox();
            logo.LocationF = new PointF(12F, 10F);
            logo.SizeF = new SizeF(150F, 50F);
            logo.Sizing = ImageSizeMode.ZoomImage;
            logo.Image = LoadLogo();
            head.Controls.Add(logo);

            head.Controls.Add(Label("거 래 명 세 서", 170F, 12F, 280F, 46F, 22F, FontStyle.Bold, TextAlignment.MiddleCenter));
            head.Controls.Add(Label("(출고부서용)", 440F, 12F, 140F, 46F, 14F, FontStyle.Bold, TextAlignment.MiddleLeft));

            // 거래일자·담당자
            XRTable info = NewTable(587F, 0F, new float[] { 80F, 120F }, new float[] { 35F, 35F });
            SetCell(info.Rows[0].Cells[0], "거래일자", true, TextAlignment.MiddleCenter);
            SetCell(info.Rows[0].Cells[1], Date(buyer, "SALTIME"), false, TextAlignment.MiddleCenter);
            SetCell(info.Rows[1].Cells[0], "담당자", true, TextAlignment.MiddleCenter);
            SetCell(info.Rows[1].Cells[1], Str(buyer, "EMPNM"), false, TextAlignment.MiddleCenter);
            head.Controls.Add(info);

            // 공급자 / 공급받는자
            AddParty(head, 0F, "공\r\n\r\n급\r\n\r\n자", supplier, "BDVNM", "BNAME", "BNUM", "ADDR", "TEL", "FAX", "ITYPE", "IKIND");
            AddParty(head, 393F, "공\r\n급\r\n받\r\n는\r\n자", buyer, "COMPNAME", "PRES", "BUSNM", "ADDR", "TEL", "FAX", "DTYPE", "DKIND");

            // 품목 머리글
            float[] colW = { 110F, 135F, 175F, 80F, 70F, 75F, 142F };
            XRTable header = NewTable(0F, 286F, colW, new float[] { 30F });
            string[] headers = { "품번", "품명", "규격", "수량", "BOX", "BOX 수량", "비고" };
            for (int i = 0; i < headers.Length; i++)
            {
                SetCell(header.Rows[0].Cells[i], headers[i], true, TextAlignment.MiddleCenter);
            }
            head.Controls.Add(header);

            // ---------------- 품목 : LOT 1개 = 1줄, 한 장 18줄이 되게 빈 줄로 채움 ----------------
            DataTable items = ds.Tables[2].Copy();
            int blank = (ROWS_PER_PAGE - (items.Rows.Count % ROWS_PER_PAGE)) % ROWS_PER_PAGE;
            if (items.Rows.Count == 0) blank = ROWS_PER_PAGE;
            for (int i = 0; i < blank; i++)
            {
                DataRow row = items.NewRow();
                foreach (DataColumn col in items.Columns) row[col] = DBNull.Value;
                items.Rows.Add(row);
            }

            DetailBand detail = new DetailBand();
            detail.HeightF = ROW_H;
            this.Bands.Add(detail);

            XRTable line = NewTable(0F, 0F, colW, new float[] { ROW_H });
            string[] fields = { "ITEMCD", "ITEMNM", "ITEMSPEC", "OUTQTY", "BOX", "BOXNM", "REMARK" };
            TextAlignment[] aligns = {
                TextAlignment.MiddleCenter, TextAlignment.MiddleLeft, TextAlignment.MiddleLeft, TextAlignment.MiddleRight,
                TextAlignment.MiddleCenter, TextAlignment.MiddleCenter, TextAlignment.MiddleLeft };
            for (int i = 0; i < fields.Length; i++)
            {
                XRTableCell cell = line.Rows[0].Cells[i];
                SetCell(cell, "", false, aligns[i]);
                cell.DataBindings.Add(new XRBinding("Text", null, fields[i]));
                if (i == 1 || i == 2) cell.Font = new Font(FONT, 8.5F);   // 품명·규격은 길어서 작게
            }
            detail.Controls.Add(line);

            // ---------------- 바닥 : 출하번호·총 수량 ----------------
            PageFooterBand foot = new PageFooterBand();
            foot.HeightF = 36F;
            this.Bands.Add(foot);

            XRTable bottom = NewTable(0F, 0F, new float[] { 105F, 255F, 75F, 150F, 55F, 147F }, new float[] { 36F });
            SetCell(bottom.Rows[0].Cells[0], "출하번호", true, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[0].Cells[1], Str(total, "GROUPKEY"), false, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[0].Cells[2], "총 수량", true, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[0].Cells[3], Str(total, "SUMQTY"), false, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[0].Cells[4], "비고", true, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[0].Cells[5], Str(total, "REMARK"), false, TextAlignment.MiddleLeft);
            foot.Controls.Add(bottom);

            this.DataSource = items;
        }

        // 공급자·공급받는자 한쪽 (세로 제목 + 상호/대표/등록번호/주소 + 대표전화·팩스 + 업태·업종), 폭 393
        private void AddParty(PageHeaderBand head, float x, string vertical, DataRow row,
                              string nm, string pres, string num, string addr, string tel, string fax, string type, string kind)
        {
            XRLabel v = Label(vertical, x, 70F, 34F, 216F, 9.5F, FontStyle.Regular, TextAlignment.MiddleCenter);
            v.Borders = BorderSide.All;
            v.BorderWidth = 1F;
            head.Controls.Add(v);

            XRTable top = NewTable(x + 34F, 70F, new float[] { 72F, 287F }, new float[] { 36F, 36F, 36F, 36F });
            string[] labels = { "상      호", "대      표", "등록번호", "주      소" };
            string[] values = { Str(row, nm), Str(row, pres), Str(row, num), Str(row, addr) };
            for (int i = 0; i < 4; i++)
            {
                SetCell(top.Rows[i].Cells[0], labels[i], true, TextAlignment.MiddleCenter);
                SetCell(top.Rows[i].Cells[1], values[i], false, TextAlignment.MiddleCenter);
            }
            head.Controls.Add(top);

            XRTable bottom = NewTable(x + 34F, 214F, new float[] { 64F, 92F, 62F, 141F }, new float[] { 36F, 36F });
            SetCell(bottom.Rows[0].Cells[0], "대표전화", true, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[0].Cells[1], Str(row, tel), false, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[0].Cells[2], "대표팩스", true, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[0].Cells[3], Str(row, fax), false, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[1].Cells[0], "업      태", true, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[1].Cells[1], Str(row, type), false, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[1].Cells[2], "업  종", true, TextAlignment.MiddleCenter);
            SetCell(bottom.Rows[1].Cells[3], Str(row, kind), false, TextAlignment.MiddleCenter);

            // 이 두 줄은 칸이 좁아 글자를 작게 (대표팩스·전화번호·긴 업종이 잘리지 않게)
            foreach (XRTableRow r in bottom.Rows)
            {
                for (int i = 0; i < r.Cells.Count; i++)
                {
                    r.Cells[i].Font = new Font(FONT, i % 2 == 0 ? 9F : 8.5F);
                    r.Cells[i].Padding = new PaddingInfo(3, 3, 0, 0);
                }
            }
            head.Controls.Add(bottom);
        }

        // 로고 : 거래명세서(MTR_1_DOC) 양식의 S&S INC 로고 이미지를 그대로 씀
        private static Image LoadLogo()
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MTR_1_DOC));
                return resources.GetObject("xrPictureBox1.Image") as Image;
            }
            catch
            {
                return null;
            }
        }

        private static string Str(DataRow row, string col)
        {
            return row.Table.Columns.Contains(col) && !row.IsNull(col) ? row[col].ToString() : "";
        }

        // 2026-11-10 00:00:00 → 2026-11-10
        private static string Date(DataRow row, string col)
        {
            string s = Str(row, col);
            return s.Length > 10 ? s.Substring(0, 10) : s;
        }

        private static XRLabel Box(float x, float y, float w, float h)
        {
            XRLabel box = new XRLabel();
            box.LocationF = new PointF(x, y);
            box.SizeF = new SizeF(w, h);
            box.Borders = BorderSide.All;
            box.BorderWidth = 1F;
            return box;
        }

        private static XRLabel Label(string text, float x, float y, float w, float h, float size, FontStyle style, TextAlignment align)
        {
            XRLabel label = new XRLabel();
            label.Text = text;
            label.Multiline = true;   // 세로 글자(공/급/자)처럼 줄바꿈이 들어간 글자
            label.Font = new Font(FONT, size, style);
            label.TextAlignment = align;
            label.Borders = BorderSide.None;
            label.LocationF = new PointF(x, y);
            label.SizeF = new SizeF(w, h);
            return label;
        }

        // 테두리 있는 표 (colW 합 = 표 폭, rowH 합 = 표 높이)
        private static XRTable NewTable(float x, float y, float[] colW, float[] rowH)
        {
            XRTable table = new XRTable();
            table.BeginInit();
            float w = 0F, h = 0F;
            foreach (float cw in colW) w += cw;
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
            table.SizeF = new SizeF(w, h);
            table.Borders = BorderSide.All;
            table.BorderWidth = 1F;
            table.EndInit();
            return table;
        }

        // 머리글(label)·값 칸. 높이가 늘지 않게 잠그고 줄바꿈 허용
        private static void SetCell(XRTableCell cell, string text, bool isLabel, TextAlignment align)
        {
            cell.Text = text;
            cell.Borders = BorderSide.All;
            cell.CanGrow = false;
            cell.CanShrink = false;
            cell.WordWrap = true;
            cell.Padding = new PaddingInfo(5, 5, 0, 0);
            cell.TextAlignment = align;
            cell.Font = new Font(FONT, isLabel ? 10F : 9.5F, FontStyle.Regular);
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
