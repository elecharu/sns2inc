using System;
using System.Drawing;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-16 코드로 그리는 출력 양식(MTR_3, MTR_4, MTR_5) 공통 도구 : 표·글자·바코드 만들기, 지정 프린터로 바로 인쇄
    /// </summary>
    internal static class RptKit
    {
        public const string FONT = "맑은 고딕";

        // 테두리 있는 표 (colW 합 = 표 너비, rowH 합 = 표 높이)
        public static XRTable Grid(float x, float y, float[] colW, float[] rowH)
        {
            XRTable table = new XRTable();
            table.BeginInit();
            float w = 0F;
            foreach (float cw in colW) w += cw;
            float h = 0F;
            foreach (float rh in rowH)
            {
                XRTableRow row = new XRTableRow();
                row.Weight = rh;
                foreach (float cw in colW)
                {
                    XRTableCell cell = new XRTableCell();
                    cell.Weight = cw;
                    cell.Borders = BorderSide.All;
                    cell.CanGrow = false;
                    cell.CanShrink = false;
                    cell.WordWrap = true;
                    cell.Multiline = true;
                    cell.Padding = new PaddingInfo(2, 2, 0, 0);
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

        // 고정 글자 칸 (머리글 등)
        public static void Text(XRTableCell cell, string text, float size, bool bold, TextAlignment align)
        {
            cell.Text = text ?? "";
            cell.Font = new Font(FONT, size, bold ? FontStyle.Bold : FontStyle.Regular);
            cell.TextAlignment = align;
        }

        // 필드 바인딩 칸 (값)
        public static void Bind(XRTableCell cell, string field, float size, bool bold, TextAlignment align)
        {
            cell.DataBindings.Add(new XRBinding("Text", null, field));
            cell.Font = new Font(FONT, size, bold ? FontStyle.Bold : FontStyle.Regular);
            cell.TextAlignment = align;
        }

        public static XRLabel Label(string text, float x, float y, float w, float h, float size, bool bold, TextAlignment align, BorderSide borders)
        {
            XRLabel label = new XRLabel();
            label.Text = text ?? "";
            label.Font = new Font(FONT, size, bold ? FontStyle.Bold : FontStyle.Regular);
            label.TextAlignment = align;
            label.Borders = borders;
            label.BorderWidth = 1F;
            label.Multiline = true;
            label.WordWrap = true;
            label.CanGrow = false;
            label.CanShrink = false;
            label.LocationF = new PointF(x, y);
            label.SizeF = new SizeF(w, h);
            return label;
        }

        // Code128 바코드 (field 의 값을 바코드로, 밑에 글자)
        public static XRBarCode Barcode(string field, float x, float y, float w, float h, float fontSize)
        {
            XRBarCode bar = new XRBarCode();
            bar.Symbology = new Code128Generator();
            bar.AutoModule = true;
            bar.ShowText = true;
            bar.Font = new Font(FONT, fontSize);
            bar.TextAlignment = TextAlignment.BottomCenter;
            bar.Borders = BorderSide.None;
            bar.LocationF = new PointF(x, y);
            bar.SizeF = new SizeF(w, h);
            bar.DataBindings.Add(new XRBinding("Text", null, field));
            return bar;
        }

        // 회사 로고 (거래명세서 MTR_1_DOC 에 들어 있는 그림을 그대로 씀)
        public static Image Logo()
        {
            try
            {
                return (Image)new System.ComponentModel.ComponentResourceManager(typeof(MTR_1_DOC)).GetObject("xrPictureBox1.Image");
            }
            catch
            {
                return null;
            }
        }

        // 2026-11-26 그림 칸에 넣을 그림을 칸 크기(1/100 inch)의 600 DPI 그림으로 미리 만든다 (비율 유지, 칸 가운데, 남는 곳은 투명)
        // 화면 배율(예 150%)을 쓰는 PC 의 현장프로그램(WPF)에서 인쇄하면 DevExpress 16.1 이 작은 그림을 배율만큼 크게 그려
        // 칸 밖이 잘린다 (ZoomImage·StretchImage 모두). 칸 크기와 같은 고해상도 그림이면 배율과 상관없이 칸에 맞게 나온다
        public static Image FitImage(Image src, float boxW, float boxH)
        {
            if (src == null) return null;
            Bitmap bmp = new Bitmap((int)Math.Round(boxW * 6), (int)Math.Round(boxH * 6));
            float scale = Math.Min((float)bmp.Width / src.Width, (float)bmp.Height / src.Height);
            float w = src.Width * scale;
            float h = src.Height * scale;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, (bmp.Width - w) / 2F, (bmp.Height - h) / 2F, w, h);
            }
            bmp.SetResolution(600, 600);
            return bmp;
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄
        public static void PrintDirect(XtraReport report, string printerName)
        {
            report.ShowPrintMarginsWarning = false;
            report.ShowPrintStatusDialog = false;
            report.CreateDocument();
            PrintToolBase tool = new PrintToolBase(report.PrintingSystem);
            tool.Print(printerName);
        }

        public static string Qty(object v)
        {
            if (v == null || v == DBNull.Value) return "";
            decimal d;
            if (!decimal.TryParse(v.ToString(), out d)) return v.ToString();
            return string.Format("{0:#,0.###}", d);
        }
    }
}
