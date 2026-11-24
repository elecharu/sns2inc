namespace TMLPRINT
{
    partial class PRD_3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator2 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator3 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.P_BORDER = new DevExpress.XtraReports.UI.XRPanel();
            this.L_PARTNO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_PARTNO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAR_PARTNO = new DevExpress.XtraReports.UI.XRBarCode();
            this.C_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SHIPTO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_CUSTADDR = new DevExpress.XtraReports.UI.XRLabel();
            this.L_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAR_QTY = new DevExpress.XtraReports.UI.XRBarCode();
            this.L_SERIAL = new DevExpress.XtraReports.UI.XRLabel();
            this.C_LABELKEY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DATEMFG = new DevExpress.XtraReports.UI.XRLabel();
            this.C_PRDDATE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAR_LABELKEY = new DevExpress.XtraReports.UI.XRBarCode();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // TopMargin
            //
            this.TopMargin.HeightF = 82F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Dpi = 254F;
            //
            // Detail (라벨 1장, 단위 0.1mm)
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.P_BORDER});
            this.Detail.HeightF = 828F;
            this.Detail.Name = "Detail";
            this.Detail.Dpi = 254F;
            //
            // P_BORDER (바깥 테두리)
            //
            this.P_BORDER.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.P_BORDER.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_PARTNO,
            this.C_PARTNO,
            this.C_BAR_PARTNO,
            this.C_ITEMNM,
            this.L_SHIPTO,
            this.C_CUSTADDR,
            this.L_QTY,
            this.C_QTY,
            this.C_BAR_QTY,
            this.L_SERIAL,
            this.C_LABELKEY,
            this.L_DATEMFG,
            this.C_PRDDATE,
            this.C_BAR_LABELKEY});
            this.P_BORDER.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.P_BORDER.Name = "P_BORDER";
            this.P_BORDER.Dpi = 254F;
            this.P_BORDER.SizeF = new System.Drawing.SizeF(1220F, 828F);
            this.P_BORDER.StylePriority.UseBorders = false;
            //
            // L_PARTNO
            //
            this.L_PARTNO.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_PARTNO.Font = new System.Drawing.Font("맑은 고딕", 10.5F);
            this.L_PARTNO.LocationFloat = new DevExpress.Utils.PointFloat(12.7F, 2.9F);
            this.L_PARTNO.Name = "L_PARTNO";
            this.L_PARTNO.CanGrow = false;
            this.L_PARTNO.Dpi = 254F;
            this.L_PARTNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_PARTNO.SizeF = new System.Drawing.SizeF(317.7F, 51.8F);
            this.L_PARTNO.StylePriority.UseBorders = false;
            this.L_PARTNO.StylePriority.UseFont = false;
            this.L_PARTNO.StylePriority.UsePadding = false;
            this.L_PARTNO.StylePriority.UseTextAlignment = false;
            this.L_PARTNO.Text = "PART NO :";
            this.L_PARTNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // C_PARTNO (A PART_NO)
            //
            this.C_PARTNO.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_PARTNO.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.C_PARTNO.LocationFloat = new DevExpress.Utils.PointFloat(50.9F, 66.5F);
            this.C_PARTNO.Name = "C_PARTNO";
            this.C_PARTNO.CanGrow = false;
            this.C_PARTNO.WordWrap = false;
            this.C_PARTNO.Dpi = 254F;
            this.C_PARTNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_PARTNO.SizeF = new System.Drawing.SizeF(762.5F, 69.5F);
            this.C_PARTNO.StylePriority.UseBorders = false;
            this.C_PARTNO.StylePriority.UseFont = false;
            this.C_PARTNO.StylePriority.UsePadding = false;
            this.C_PARTNO.StylePriority.UseTextAlignment = false;
            this.C_PARTNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // C_BAR_PARTNO (C PART_NO 바코드)
            //
            this.C_BAR_PARTNO.AutoModule = true;
            this.C_BAR_PARTNO.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_BAR_PARTNO.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_BAR_PARTNO.LocationFloat = new DevExpress.Utils.PointFloat(34.3F, 142F);
            this.C_BAR_PARTNO.Name = "C_BAR_PARTNO";
            this.C_BAR_PARTNO.Dpi = 254F;
            this.C_BAR_PARTNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_BAR_PARTNO.SizeF = new System.Drawing.SizeF(622.7F, 118.3F);
            this.C_BAR_PARTNO.StylePriority.UseBorders = false;
            this.C_BAR_PARTNO.StylePriority.UseFont = false;
            this.C_BAR_PARTNO.StylePriority.UsePadding = false;
            this.C_BAR_PARTNO.StylePriority.UseTextAlignment = false;
            this.C_BAR_PARTNO.Symbology = code128Generator1;
            this.C_BAR_PARTNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            //
            // C_ITEMNM (B 품명)
            //
            this.C_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.C_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(813.4F, 5.9F);
            this.C_ITEMNM.Multiline = true;
            this.C_ITEMNM.Name = "C_ITEMNM";
            this.C_ITEMNM.CanGrow = false;
            this.C_ITEMNM.Dpi = 254F;
            this.C_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 254F);
            this.C_ITEMNM.SizeF = new System.Drawing.SizeF(343.2F, 140.5F);
            this.C_ITEMNM.StylePriority.UseBorders = false;
            this.C_ITEMNM.StylePriority.UseFont = false;
            this.C_ITEMNM.StylePriority.UsePadding = false;
            this.C_ITEMNM.StylePriority.UseTextAlignment = false;
            this.C_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            //
            // L_SHIPTO
            //
            this.L_SHIPTO.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_SHIPTO.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.L_SHIPTO.LocationFloat = new DevExpress.Utils.PointFloat(702.7F, 168.5F);
            this.L_SHIPTO.Name = "L_SHIPTO";
            this.L_SHIPTO.CanGrow = false;
            this.L_SHIPTO.WordWrap = false;
            this.L_SHIPTO.Dpi = 254F;
            this.L_SHIPTO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_SHIPTO.SizeF = new System.Drawing.SizeF(381.3F, 68F);
            this.L_SHIPTO.StylePriority.UseBorders = false;
            this.L_SHIPTO.StylePriority.UseFont = false;
            this.L_SHIPTO.StylePriority.UsePadding = false;
            this.L_SHIPTO.StylePriority.UseTextAlignment = false;
            this.L_SHIPTO.Text = "SHIP TO :";
            this.L_SHIPTO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // C_CUSTADDR (D 매출단가 거래처 주소 MSTCUST.CUSTADDR2)
            //
            this.C_CUSTADDR.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_CUSTADDR.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.C_CUSTADDR.LocationFloat = new DevExpress.Utils.PointFloat(702.7F, 258.8F);
            this.C_CUSTADDR.Multiline = true;
            this.C_CUSTADDR.Name = "C_CUSTADDR";
            this.C_CUSTADDR.CanGrow = false;
            this.C_CUSTADDR.Dpi = 254F;
            this.C_CUSTADDR.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 254F);
            this.C_CUSTADDR.SizeF = new System.Drawing.SizeF(419.3F, 147.8F);
            this.C_CUSTADDR.StylePriority.UseBorders = false;
            this.C_CUSTADDR.StylePriority.UseFont = false;
            this.C_CUSTADDR.StylePriority.UsePadding = false;
            this.C_CUSTADDR.StylePriority.UseTextAlignment = false;
            this.C_CUSTADDR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_QTY
            //
            this.L_QTY.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_QTY.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.L_QTY.LocationFloat = new DevExpress.Utils.PointFloat(76.3F, 297.2F);
            this.L_QTY.Name = "L_QTY";
            this.L_QTY.CanGrow = false;
            this.L_QTY.WordWrap = false;
            this.L_QTY.Dpi = 254F;
            this.L_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 254F);
            this.L_QTY.SizeF = new System.Drawing.SizeF(197F, 59.2F);
            this.L_QTY.StylePriority.UseBorders = false;
            this.L_QTY.StylePriority.UseFont = false;
            this.L_QTY.StylePriority.UsePadding = false;
            this.L_QTY.StylePriority.UseTextAlignment = false;
            this.L_QTY.Text = "Quantity";
            this.L_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // C_QTY (E LOT 수량)
            //
            this.C_QTY.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_QTY.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.C_QTY.LocationFloat = new DevExpress.Utils.PointFloat(282.2F, 294.2F);
            this.C_QTY.Name = "C_QTY";
            this.C_QTY.CanGrow = false;
            this.C_QTY.WordWrap = false;
            this.C_QTY.Dpi = 254F;
            this.C_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_QTY.SizeF = new System.Drawing.SizeF(254.1F, 66.5F);
            this.C_QTY.StylePriority.UseBorders = false;
            this.C_QTY.StylePriority.UseFont = false;
            this.C_QTY.StylePriority.UsePadding = false;
            this.C_QTY.StylePriority.UseTextAlignment = false;
            this.C_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // C_BAR_QTY (F LOT 수량 바코드)
            //
            this.C_BAR_QTY.AutoModule = true;
            this.C_BAR_QTY.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_BAR_QTY.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_BAR_QTY.LocationFloat = new DevExpress.Utils.PointFloat(185.6F, 400.7F);
            this.C_BAR_QTY.Name = "C_BAR_QTY";
            this.C_BAR_QTY.Dpi = 254F;
            this.C_BAR_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_BAR_QTY.SizeF = new System.Drawing.SizeF(324F, 110.9F);
            this.C_BAR_QTY.StylePriority.UseBorders = false;
            this.C_BAR_QTY.StylePriority.UseFont = false;
            this.C_BAR_QTY.StylePriority.UsePadding = false;
            this.C_BAR_QTY.StylePriority.UseTextAlignment = false;
            this.C_BAR_QTY.Symbology = code128Generator2;
            this.C_BAR_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            //
            // L_SERIAL
            //
            this.L_SERIAL.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_SERIAL.Font = new System.Drawing.Font("맑은 고딕", 12.5F);
            this.L_SERIAL.LocationFloat = new DevExpress.Utils.PointFloat(152.5F, 575.2F);
            this.L_SERIAL.Name = "L_SERIAL";
            this.L_SERIAL.CanGrow = false;
            this.L_SERIAL.WordWrap = false;
            this.L_SERIAL.Dpi = 254F;
            this.L_SERIAL.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 254F);
            this.L_SERIAL.SizeF = new System.Drawing.SizeF(181.8F, 62.1F);
            this.L_SERIAL.StylePriority.UseBorders = false;
            this.L_SERIAL.StylePriority.UseFont = false;
            this.L_SERIAL.StylePriority.UsePadding = false;
            this.L_SERIAL.StylePriority.UseTextAlignment = false;
            this.L_SERIAL.Text = "Serial #";
            this.L_SERIAL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            //
            // C_LABELKEY (G 라벨번호)
            //
            this.C_LABELKEY.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_LABELKEY.Font = new System.Drawing.Font("맑은 고딕", 35F, System.Drawing.FontStyle.Bold);
            this.C_LABELKEY.LocationFloat = new DevExpress.Utils.PointFloat(381.3F, 507.2F);
            this.C_LABELKEY.Name = "C_LABELKEY";
            this.C_LABELKEY.CanGrow = false;
            this.C_LABELKEY.WordWrap = false;
            this.C_LABELKEY.Dpi = 254F;
            this.C_LABELKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_LABELKEY.SizeF = new System.Drawing.SizeF(813.4F, 180.4F);
            this.C_LABELKEY.StylePriority.UseBorders = false;
            this.C_LABELKEY.StylePriority.UseFont = false;
            this.C_LABELKEY.StylePriority.UsePadding = false;
            this.C_LABELKEY.StylePriority.UseTextAlignment = false;
            this.C_LABELKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // L_DATEMFG
            //
            this.L_DATEMFG.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_DATEMFG.Font = new System.Drawing.Font("맑은 고딕", 10.5F);
            this.L_DATEMFG.LocationFloat = new DevExpress.Utils.PointFloat(12.7F, 687.5F);
            this.L_DATEMFG.Name = "L_DATEMFG";
            this.L_DATEMFG.CanGrow = false;
            this.L_DATEMFG.Dpi = 254F;
            this.L_DATEMFG.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_DATEMFG.SizeF = new System.Drawing.SizeF(317.7F, 51.8F);
            this.L_DATEMFG.StylePriority.UseBorders = false;
            this.L_DATEMFG.StylePriority.UseFont = false;
            this.L_DATEMFG.StylePriority.UsePadding = false;
            this.L_DATEMFG.StylePriority.UseTextAlignment = false;
            this.L_DATEMFG.Text = "DATE MFG";
            this.L_DATEMFG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // C_PRDDATE (H 생산실적 일자)
            //
            this.C_PRDDATE.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_PRDDATE.Font = new System.Drawing.Font("맑은 고딕", 19F, System.Drawing.FontStyle.Bold);
            this.C_PRDDATE.LocationFloat = new DevExpress.Utils.PointFloat(12.7F, 722.9F);
            this.C_PRDDATE.Name = "C_PRDDATE";
            this.C_PRDDATE.CanGrow = false;
            this.C_PRDDATE.WordWrap = false;
            this.C_PRDDATE.Dpi = 254F;
            this.C_PRDDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_PRDDATE.SizeF = new System.Drawing.SizeF(432.1F, 103F);
            this.C_PRDDATE.StylePriority.UseBorders = false;
            this.C_PRDDATE.StylePriority.UseFont = false;
            this.C_PRDDATE.StylePriority.UsePadding = false;
            this.C_PRDDATE.StylePriority.UseTextAlignment = false;
            this.C_PRDDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // C_BAR_LABELKEY (I 라벨번호 바코드)
            //
            this.C_BAR_LABELKEY.AutoModule = true;
            this.C_BAR_LABELKEY.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.C_BAR_LABELKEY.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_BAR_LABELKEY.LocationFloat = new DevExpress.Utils.PointFloat(466.4F, 695F);
            this.C_BAR_LABELKEY.Name = "C_BAR_LABELKEY";
            this.C_BAR_LABELKEY.Dpi = 254F;
            this.C_BAR_LABELKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_BAR_LABELKEY.SizeF = new System.Drawing.SizeF(653.2F, 118.3F);
            this.C_BAR_LABELKEY.StylePriority.UseBorders = false;
            this.C_BAR_LABELKEY.StylePriority.UseFont = false;
            this.C_BAR_LABELKEY.StylePriority.UsePadding = false;
            this.C_BAR_LABELKEY.StylePriority.UseTextAlignment = false;
            this.C_BAR_LABELKEY.Symbology = code128Generator3;
            this.C_BAR_LABELKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            //
            // BottomMargin
            //
            this.BottomMargin.HeightF = 82F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Dpi = 254F;
            //
            // PRD_3 (용지 99.2 x 138.6 mm 가로 방향, 라벨 네모 122.0 x 82.8 mm 가운데, 단위 0.1mm)
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.Detail,
            this.BottomMargin});
            this.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(83, 83, 82, 82);
            this.Landscape = true;   // 용지 99.2 x 138.6mm 를 눕혀서 씀 (2026-11-23)
            this.PageHeight = 992;
            this.PageWidth = 1386;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 10F;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel P_BORDER;
        private DevExpress.XtraReports.UI.XRLabel L_PARTNO;
        private DevExpress.XtraReports.UI.XRLabel C_PARTNO;
        private DevExpress.XtraReports.UI.XRBarCode C_BAR_PARTNO;
        private DevExpress.XtraReports.UI.XRLabel C_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_SHIPTO;
        private DevExpress.XtraReports.UI.XRLabel C_CUSTADDR;
        private DevExpress.XtraReports.UI.XRLabel L_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_QTY;
        private DevExpress.XtraReports.UI.XRBarCode C_BAR_QTY;
        private DevExpress.XtraReports.UI.XRLabel L_SERIAL;
        private DevExpress.XtraReports.UI.XRLabel C_LABELKEY;
        private DevExpress.XtraReports.UI.XRLabel L_DATEMFG;
        private DevExpress.XtraReports.UI.XRLabel C_PRDDATE;
        private DevExpress.XtraReports.UI.XRBarCode C_BAR_LABELKEY;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    }
}
