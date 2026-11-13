namespace XtraRpt
{
    partial class R0601
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.lbl_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_SIDE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_SIDE2 = new DevExpress.XtraReports.UI.XRLabel();
            this.chart_RATE = new DevExpress.XtraReports.UI.XRChart();
            this.chart_CNT = new DevExpress.XtraReports.UI.XRChart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_RATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // TopMargin
            //
            this.TopMargin.HeightF = 30F;
            this.TopMargin.Name = "TopMargin";
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_TITLE,
            this.lbl_SIDE1,
            this.chart_RATE,
            this.lbl_SIDE2,
            this.chart_CNT});
            this.Detail.HeightF = 765F;
            this.Detail.Name = "Detail";
            //
            // BottomMargin
            //
            this.BottomMargin.HeightF = 30F;
            this.BottomMargin.Name = "BottomMargin";
            //
            // lbl_TITLE
            //
            this.lbl_TITLE.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lbl_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbl_TITLE.Name = "lbl_TITLE";
            this.lbl_TITLE.SizeF = new System.Drawing.SizeF(1109F, 36F);
            this.lbl_TITLE.StylePriority.UseFont = false;
            this.lbl_TITLE.Text = "■ 설비 고장율 현황";
            this.lbl_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // lbl_SIDE1
            //
            this.lbl_SIDE1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.lbl_SIDE1.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_SIDE1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46F);
            this.lbl_SIDE1.Multiline = true;
            this.lbl_SIDE1.Name = "lbl_SIDE1";
            this.lbl_SIDE1.SizeF = new System.Drawing.SizeF(80F, 350F);
            this.lbl_SIDE1.StylePriority.UseBorders = false;
            this.lbl_SIDE1.StylePriority.UseFont = false;
            this.lbl_SIDE1.Text = "설  비\r\n고장율\r\n(비가동)";
            this.lbl_SIDE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // chart_RATE
            //
            this.chart_RATE.BorderColor = System.Drawing.Color.Black;
            this.chart_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.chart_RATE.LocationFloat = new DevExpress.Utils.PointFloat(90F, 46F);
            this.chart_RATE.Name = "chart_RATE";
            this.chart_RATE.SizeF = new System.Drawing.SizeF(1019F, 350F);
            //
            // lbl_SIDE2
            //
            this.lbl_SIDE2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.lbl_SIDE2.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_SIDE2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 410F);
            this.lbl_SIDE2.Multiline = true;
            this.lbl_SIDE2.Name = "lbl_SIDE2";
            this.lbl_SIDE2.SizeF = new System.Drawing.SizeF(80F, 350F);
            this.lbl_SIDE2.StylePriority.UseBorders = false;
            this.lbl_SIDE2.StylePriority.UseFont = false;
            this.lbl_SIDE2.Text = "호  출\r\n건  수";
            this.lbl_SIDE2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // chart_CNT
            //
            this.chart_CNT.BorderColor = System.Drawing.Color.Black;
            this.chart_CNT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.chart_CNT.LocationFloat = new DevExpress.Utils.PointFloat(90F, 410F);
            this.chart_CNT.Name = "chart_CNT";
            this.chart_CNT.SizeF = new System.Drawing.SizeF(1019F, 350F);
            //
            // R0601
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.Detail,
            this.BottomMargin});
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.chart_RATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel lbl_TITLE;
        private DevExpress.XtraReports.UI.XRLabel lbl_SIDE1;
        private DevExpress.XtraReports.UI.XRLabel lbl_SIDE2;
        private DevExpress.XtraReports.UI.XRChart chart_RATE;
        private DevExpress.XtraReports.UI.XRChart chart_CNT;
    }
}
