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
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            //
            // Detail (라벨 1장, 단위 0.1mm)
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.P_BORDER});
            this.Detail.HeightF = 560F;
            this.Detail.Name = "Detail";
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
            this.P_BORDER.SizeF = new System.Drawing.SizeF(960F, 560F);
            this.P_BORDER.StylePriority.UseBorders = false;
            //
            // L_PARTNO
            //
            this.L_PARTNO.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_PARTNO.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_PARTNO.LocationFloat = new DevExpress.Utils.PointFloat(10F, 5F);
            this.L_PARTNO.Name = "L_PARTNO";
            this.L_PARTNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_PARTNO.SizeF = new System.Drawing.SizeF(200F, 35F);
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
            this.C_PARTNO.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.C_PARTNO.LocationFloat = new DevExpress.Utils.PointFloat(30F, 38F);
            this.C_PARTNO.Name = "C_PARTNO";
            this.C_PARTNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_PARTNO.SizeF = new System.Drawing.SizeF(590F, 55F);
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
            this.C_BAR_PARTNO.Font = new System.Drawing.Font("맑은 고딕", 5.5F);
            this.C_BAR_PARTNO.LocationFloat = new DevExpress.Utils.PointFloat(30F, 95F);
            this.C_BAR_PARTNO.Name = "C_BAR_PARTNO";
            this.C_BAR_PARTNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_BAR_PARTNO.SizeF = new System.Drawing.SizeF(590F, 95F);
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
            this.C_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.C_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(630F, 10F);
            this.C_ITEMNM.Multiline = true;
            this.C_ITEMNM.Name = "C_ITEMNM";
            this.C_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 254F);
            this.C_ITEMNM.SizeF = new System.Drawing.SizeF(330F, 120F);
            this.C_ITEMNM.StylePriority.UseBorders = false;
            this.C_ITEMNM.StylePriority.UseFont = false;
            this.C_ITEMNM.StylePriority.UsePadding = false;
            this.C_ITEMNM.StylePriority.UseTextAlignment = false;
            this.C_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            //
            // L_SHIPTO
            //
            this.L_SHIPTO.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_SHIPTO.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.L_SHIPTO.LocationFloat = new DevExpress.Utils.PointFloat(640F, 150F);
            this.L_SHIPTO.Name = "L_SHIPTO";
            this.L_SHIPTO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_SHIPTO.SizeF = new System.Drawing.SizeF(300F, 45F);
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
            this.C_CUSTADDR.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.C_CUSTADDR.LocationFloat = new DevExpress.Utils.PointFloat(630F, 200F);
            this.C_CUSTADDR.Multiline = true;
            this.C_CUSTADDR.Name = "C_CUSTADDR";
            this.C_CUSTADDR.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 254F);
            this.C_CUSTADDR.SizeF = new System.Drawing.SizeF(330F, 130F);
            this.C_CUSTADDR.StylePriority.UseBorders = false;
            this.C_CUSTADDR.StylePriority.UseFont = false;
            this.C_CUSTADDR.StylePriority.UsePadding = false;
            this.C_CUSTADDR.StylePriority.UseTextAlignment = false;
            this.C_CUSTADDR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_QTY
            //
            this.L_QTY.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_QTY.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_QTY.LocationFloat = new DevExpress.Utils.PointFloat(100F, 235F);
            this.L_QTY.Name = "L_QTY";
            this.L_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 254F);
            this.L_QTY.SizeF = new System.Drawing.SizeF(170F, 50F);
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
            this.C_QTY.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.C_QTY.LocationFloat = new DevExpress.Utils.PointFloat(270F, 230F);
            this.C_QTY.Name = "C_QTY";
            this.C_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_QTY.SizeF = new System.Drawing.SizeF(250F, 60F);
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
            this.C_BAR_QTY.Font = new System.Drawing.Font("맑은 고딕", 5.5F);
            this.C_BAR_QTY.LocationFloat = new DevExpress.Utils.PointFloat(150F, 295F);
            this.C_BAR_QTY.Name = "C_BAR_QTY";
            this.C_BAR_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_BAR_QTY.SizeF = new System.Drawing.SizeF(350F, 90F);
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
            this.L_SERIAL.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_SERIAL.LocationFloat = new DevExpress.Utils.PointFloat(230F, 395F);
            this.L_SERIAL.Name = "L_SERIAL";
            this.L_SERIAL.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 254F);
            this.L_SERIAL.SizeF = new System.Drawing.SizeF(160F, 60F);
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
            this.C_LABELKEY.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.C_LABELKEY.LocationFloat = new DevExpress.Utils.PointFloat(390F, 365F);
            this.C_LABELKEY.Name = "C_LABELKEY";
            this.C_LABELKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_LABELKEY.SizeF = new System.Drawing.SizeF(565F, 115F);
            this.C_LABELKEY.StylePriority.UseBorders = false;
            this.C_LABELKEY.StylePriority.UseFont = false;
            this.C_LABELKEY.StylePriority.UsePadding = false;
            this.C_LABELKEY.StylePriority.UseTextAlignment = false;
            this.C_LABELKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // L_DATEMFG
            //
            this.L_DATEMFG.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.L_DATEMFG.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_DATEMFG.LocationFloat = new DevExpress.Utils.PointFloat(10F, 455F);
            this.L_DATEMFG.Name = "L_DATEMFG";
            this.L_DATEMFG.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_DATEMFG.SizeF = new System.Drawing.SizeF(220F, 35F);
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
            this.C_PRDDATE.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.C_PRDDATE.LocationFloat = new DevExpress.Utils.PointFloat(10F, 490F);
            this.C_PRDDATE.Name = "C_PRDDATE";
            this.C_PRDDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_PRDDATE.SizeF = new System.Drawing.SizeF(370F, 65F);
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
            this.C_BAR_LABELKEY.Font = new System.Drawing.Font("맑은 고딕", 5.5F);
            this.C_BAR_LABELKEY.LocationFloat = new DevExpress.Utils.PointFloat(390F, 480F);
            this.C_BAR_LABELKEY.Name = "C_BAR_LABELKEY";
            this.C_BAR_LABELKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_BAR_LABELKEY.SizeF = new System.Drawing.SizeF(565F, 75F);
            this.C_BAR_LABELKEY.StylePriority.UseBorders = false;
            this.C_BAR_LABELKEY.StylePriority.UseFont = false;
            this.C_BAR_LABELKEY.StylePriority.UsePadding = false;
            this.C_BAR_LABELKEY.StylePriority.UseTextAlignment = false;
            this.C_BAR_LABELKEY.Symbology = code128Generator3;
            this.C_BAR_LABELKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            //
            // BottomMargin
            //
            this.BottomMargin.HeightF = 20F;
            this.BottomMargin.Name = "BottomMargin";
            //
            // PRD_3 (100 x 60 mm, 단위 0.1mm)
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.Detail,
            this.BottomMargin});
            this.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.PageHeight = 600;
            this.PageWidth = 1000;
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
