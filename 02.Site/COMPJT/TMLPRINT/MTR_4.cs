using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-16 [외주반출] 외주반출증 + 발주서 2장 / [외주재작업반출] 외주반출증(재작업) 공급자 보관용 + 공급받는자 보관용 2장 (A4 세로)
    /// ds = TML1020_R02 / R04 ADD_MOVE 결과
    ///   Tables[1] 머리글 1행 (MOVENO, MOVEDATE, EMPNM,
    ///             S* = S&amp;S INC 2공장 : SNM, SPRES, SNUM, SADDR, STEL, SFAX, STYPE, SKIND
    ///             C* = 외주처       : CNM, CPRES, CNUM, CADDR, CTEL, CFAX, CTYPE, CKIND)
    ///   Tables[2] LOT 목록 (ITEMCD, ITEMNM, ITEMSPEC, HEATNO, LOTKEY, QTY, QTYNUM)
    /// 양식은 코드로 그린다. 한 부(MTR_4 1개)가 한 장 양식이고, Print 가 두 부를 이어서 한 번에 인쇄한다
    /// </summary>
    public class MTR_4 : XtraReport
    {
        const float W = 747F;      // A4 세로 827 - 좌우 여백 40 x 2
        const float HEAD_FONT = 9F;
        const float VALUE_FONT = 9F;
        // LOT 표 칸 너비 : LOT NO, 품번, 품목명, 규격, HEAT NO, 수량, BOX, BOX 수량, 비고, 납기일
        static readonly float[] LOT_COLS = { 140F, 76F, 108F, 74F, 77F, 43F, 41F, 64F, 66F, 58F };

        // 한 부. left/right = 왼쪽/오른쪽 당사자 표시 (leftIsSupplier : 왼쪽이 S&S 인지)
        private MTR_4(DataRow hd, DataTable lots, string title, float titleSize, string sub, bool leftIsSupplier, string leftLabel, string rightLabel)
        {
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Landscape = false;
            this.PageWidth = 827;
            this.PageHeight = 1169;
            this.Margins = new System.Drawing.Printing.Margins(36, 36, 40, 40);   // 좌우는 표 너비(747)보다 조금 넉넉히 (표 테두리가 넘쳐 빈 쪽이 나오지 않게)
            this.Font = new Font(RptKit.FONT, HEAD_FONT);

            // ----- 머리글 (처음 한 번) : 제목·로고·번호 + 공급자/공급받는자 -----
            ReportHeaderBand header = new ReportHeaderBand();
            header.HeightF = 288F;
            this.Bands.Add(header);

            header.Controls.Add(RptKit.Label("", 0F, 0F, 525F, 96F, 10F, false, TextAlignment.MiddleCenter, BorderSide.All));
            Image logo = RptKit.Logo();
            if (logo != null)
            {
                XRPictureBox pic = new XRPictureBox();
                pic.Image = logo;
                pic.Sizing = ImageSizeMode.ZoomImage;
                pic.Borders = BorderSide.None;
                pic.LocationF = new PointF(15F, 18F);
                pic.SizeF = new SizeF(145F, 56F);
                header.Controls.Add(pic);
            }
            header.Controls.Add(RptKit.Label(title, 165F, 12F, 355F, 48F, titleSize, false, TextAlignment.MiddleCenter, BorderSide.None));
            header.Controls.Add(RptKit.Label(sub, 165F, 60F, 355F, 28F, 10F, false, TextAlignment.MiddleCenter, BorderSide.None));

            XRTable no = RptKit.Grid(525F, 0F, new float[] { 93F, W - 618F }, new float[] { 32F, 32F, 32F });
            string[] noHeads = { "발주일자", "이동번호", "담당자" };
            string[] noVals = { S(hd, "MOVEDATE"), S(hd, "MOVENO"), S(hd, "EMPNM") };
            for (int i = 0; i < 3; i++)
            {
                RptKit.Text(no.Rows[i].Cells[0], noHeads[i], HEAD_FONT, false, TextAlignment.MiddleCenter);
                RptKit.Text(no.Rows[i].Cells[1], noVals[i], VALUE_FONT, false, TextAlignment.MiddleCenter);
            }
            header.Controls.Add(no);

            // 왼쪽 당사자 / 오른쪽 당사자
            string lp = leftIsSupplier ? "S" : "C";
            string rp = leftIsSupplier ? "C" : "S";
            AddParty(header, 0F, 96F, vertical(leftLabel), hd, lp, 335F);
            AddParty(header, 405F, 96F, null, hd, rp, 342F);
            header.Controls.Add(RptKit.Label(vertical(rightLabel), 371F, 96F, 34F, 192F, HEAD_FONT, false, TextAlignment.MiddleCenter, BorderSide.All));

            // ----- 칸 이름 줄 (쪽마다 되풀이) -----
            GroupHeaderBand colHead = new GroupHeaderBand();
            colHead.HeightF = 28F;
            colHead.RepeatEveryPage = true;
            colHead.GroupFields.Add(new GroupField("GRP"));
            this.Bands.Add(colHead);

            XRTable heads = RptKit.Grid(0F, 0F, LOT_COLS, new float[] { 28F });
            string[] headText = { "LOT NO", "품번", "품목명", "규격", "HEAT NO", "수량", "BOX", "BOX 수량", "비고", "납기일" };
            for (int i = 0; i < headText.Length; i++)
            {
                RptKit.Text(heads.Rows[0].Cells[i], headText[i], HEAD_FONT, false, TextAlignment.MiddleCenter);
            }
            colHead.Controls.Add(heads);

            // ----- LOT 줄 -----
            DetailBand detail = new DetailBand();
            detail.HeightF = 50F;
            this.Bands.Add(detail);

            XRTable row = RptKit.Grid(0F, 0F, LOT_COLS, new float[] { 50F });
            XRTableCell lotCell = row.Rows[0].Cells[0];
            lotCell.Controls.Add(RptKit.Barcode("LOTKEY", 4F, 4F, LOT_COLS[0] - 8F, 42F, 7F));
            string[] fields = { null, "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "QTY", null, null, null, null };
            for (int i = 1; i < fields.Length; i++)
            {
                if (fields[i] != null) RptKit.Bind(row.Rows[0].Cells[i], fields[i], 8.5F, false, TextAlignment.MiddleCenter);
                else RptKit.Text(row.Rows[0].Cells[i], "", 8.5F, false, TextAlignment.MiddleCenter);
            }
            detail.Controls.Add(row);

            // ----- 맨 아래 : 총 수량 + 운송 정보 + 결재칸 -----
            ReportFooterBand footer = new ReportFooterBand();
            footer.HeightF = 120F;
            this.Bands.Add(footer);

            decimal total = 0;
            foreach (DataRow r in lots.Rows)
            {
                decimal q;
                if (decimal.TryParse(S(r, "QTYNUM"), out q)) total += q;
            }

            XRTable sum = RptKit.Grid(0F, 0F, new float[] { 475F, 43F, W - 518F }, new float[] { 30F });
            RptKit.Text(sum.Rows[0].Cells[0], "총 수량", HEAD_FONT, true, TextAlignment.MiddleRight);
            RptKit.Text(sum.Rows[0].Cells[1], RptKit.Qty(total), HEAD_FONT, true, TextAlignment.MiddleCenter);
            RptKit.Text(sum.Rows[0].Cells[2], "", HEAD_FONT, false, TextAlignment.MiddleCenter);
            foreach (XRTableCell c in sum.Rows[0].Cells) c.BackColor = Color.Gainsboro;
            footer.Controls.Add(sum);

            XRLabel carrier = RptKit.Label("운송업체명 :\r\n운송책임자 :\r\n차 량 번 호 :\r\n연  락  처 :", 0F, 30F, 359F, 90F, 10F, false, TextAlignment.TopLeft, BorderSide.All);
            carrier.Padding = new PaddingInfo(6, 4, 4, 0);
            footer.Controls.Add(carrier);

            XRTable sign = RptKit.Grid(359F, 30F, new float[] { 78F, 78F, 78F, 78F, W - 670F }, new float[] { 28F, 62F });
            string[] signText = { "담 당", "검 토", "팀 장", "담당임원", "대표이사" };
            for (int i = 0; i < signText.Length; i++)
            {
                RptKit.Text(sign.Rows[0].Cells[i], signText[i], HEAD_FONT, false, TextAlignment.MiddleCenter);
                RptKit.Text(sign.Rows[1].Cells[i], "", HEAD_FONT, false, TextAlignment.MiddleCenter);
            }
            footer.Controls.Add(sign);

            this.Bands.Add(new TopMarginBand() { HeightF = 40F });
            this.Bands.Add(new BottomMarginBand() { HeightF = 40F });

            // LOT 목록 (GRP = 칸 이름 줄을 쪽마다 되풀이하기 위한 묶음 값)
            DataTable data = new DataTable();
            foreach (string col in new string[] { "GRP", "LOTKEY", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "QTY" }) data.Columns.Add(col, typeof(string));
            foreach (DataRow r in lots.Rows)
            {
                DataRow d = data.NewRow();
                d["GRP"] = "1";
                foreach (string col in new string[] { "LOTKEY", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "QTY" }) d[col] = S(r, col);
                data.Rows.Add(d);
            }
            this.DataSource = data;
        }

        // 공급자/공급받는자 한쪽 칸 : 상호·대표·등록번호·주소 / 대표전화·대표팩스 / 업태·업종. vLabel 이 있으면 왼쪽 세로 글자 칸도 그림
        private void AddParty(ReportHeaderBand header, float x, float y, string vLabel, DataRow hd, string p, float width)
        {
            float labelW = (vLabel != null) ? 57F : 58F;
            float left = x;
            if (vLabel != null)
            {
                header.Controls.Add(RptKit.Label(vLabel, x, y, 36F, 192F, HEAD_FONT, false, TextAlignment.MiddleCenter, BorderSide.All));
                left = x + 36F;
            }

            XRTable t1 = RptKit.Grid(left, y, new float[] { labelW, width - labelW }, new float[] { 32F, 32F, 32F, 32F });
            string[] h1 = { "상    호", "대    표", "등록번호", "주    소" };
            string[] f1 = { "NM", "PRES", "NUM", "ADDR" };
            for (int i = 0; i < 4; i++)
            {
                RptKit.Text(t1.Rows[i].Cells[0], h1[i], HEAD_FONT, false, TextAlignment.MiddleCenter);
                RptKit.Text(t1.Rows[i].Cells[1], S(hd, p + f1[i]), VALUE_FONT, false, TextAlignment.MiddleCenter);
            }
            header.Controls.Add(t1);

            float valW = width - labelW;
            float c1 = 105F, c2 = 60F;
            XRTable t2 = RptKit.Grid(left, y + 128F, new float[] { labelW, c1, c2, valW - c1 - c2 }, new float[] { 32F, 32F });
            string[,] t2Text = { { "대표전화", "TEL", "대표팩스", "FAX" }, { "업    태", "TYPE", "업    종", "KIND" } };
            for (int i = 0; i < 2; i++)
            {
                RptKit.Text(t2.Rows[i].Cells[0], t2Text[i, 0], HEAD_FONT, false, TextAlignment.MiddleCenter);
                RptKit.Text(t2.Rows[i].Cells[1], S(hd, p + t2Text[i, 1]), 8F, false, TextAlignment.MiddleCenter);
                RptKit.Text(t2.Rows[i].Cells[2], t2Text[i, 2], HEAD_FONT, false, TextAlignment.MiddleCenter);
                RptKit.Text(t2.Rows[i].Cells[3], S(hd, p + t2Text[i, 3]), 8F, false, TextAlignment.MiddleCenter);
            }
            header.Controls.Add(t2);
        }

        // "공급자" → "공\r\n급\r\n자"
        private static string vertical(string text)
        {
            string[] ch = new string[text.Length];
            for (int i = 0; i < text.Length; i++) ch[i] = text[i].ToString();
            return string.Join("\r\n", ch);
        }

        private static string S(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col)) return "";
            object v = r[col];
            return (v == null || v == DBNull.Value) ? "" : v.ToString();
        }

        // 두 부를 이어 붙인 문서 (rework = false : 외주반출증 + 발주서 / true : 외주반출증(재작업) 공급자 보관용 + 공급받는자 보관용)
        public static XtraReport Merge(DataSet ds, bool rework)
        {
            DataRow hd = ds.Tables[1].Rows[0];
            DataTable lots = ds.Tables[2];

            MTR_4 first, second;
            if (!rework)
            {
                first = new MTR_4(hd, lots, "외 주 반 출 증", 26F, "(공급자보관용)", true, "공급자", "공급받는자");
                second = new MTR_4(hd, lots, "발 주 서", 26F, "(발주처용)", false, "거래처", "발주처");
            }
            else
            {
                first = new MTR_4(hd, lots, "외 주 반 출 증 ( 재 작 업 )", 20F, "(공급자 보관용)", true, "공급자", "공급받는자");
                second = new MTR_4(hd, lots, "외 주 반 출 증 ( 재 작 업 )", 20F, "(공급받는자 보관용)", false, "공급받는자", "공급자");
            }

            first.CreateDocument();
            second.CreateDocument();
            first.Pages.AddRange(second.Pages);
            return first;
        }

        // 확인창·미리보기 없이 지정한 프린터로 두 장 바로 인쇄
        public static void Print(DataSet ds, bool rework, string printerName)
        {
            XtraReport doc = Merge(ds, rework);
            doc.ShowPrintMarginsWarning = false;
            doc.ShowPrintStatusDialog = false;
            PrintToolBase tool = new PrintToolBase(doc.PrintingSystem);
            tool.Print(printerName);
        }
    }
}
