namespace XtraRpt
{
    partial class S0502
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
            this.components = new System.ComponentModel.Container();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            // Detail Controls
            this.lbl_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.chart_RATE = new DevExpress.XtraReports.UI.XRChart();
            this.pic_RATE = new DevExpress.XtraReports.UI.XRPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_RATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // TopMargin
            //
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 30F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // BottomMargin
            //
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 30F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_TITLE,
            this.chart_RATE,
            this.pic_RATE});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 765F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // lbl_TITLE
            //
            this.lbl_TITLE.Dpi = 100F;
            this.lbl_TITLE.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lbl_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbl_TITLE.Name = "lbl_TITLE";
            this.lbl_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_TITLE.SizeF = new System.Drawing.SizeF(1109F, 36F);
            this.lbl_TITLE.StylePriority.UseFont = false;
            this.lbl_TITLE.Text = "■ 설비별 고장 현황";
            this.lbl_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // chart_RATE
            //
            this.chart_RATE.BorderColor = System.Drawing.Color.Black;
            this.chart_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.chart_RATE.Dpi = 100F;
            this.chart_RATE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46F);
            this.chart_RATE.Name = "chart_RATE";
            this.chart_RATE.SizeF = new System.Drawing.SizeF(1109F, 715F);
            //
            // pic_RATE
            //
            this.pic_RATE.BorderColor = System.Drawing.Color.Black;
            this.pic_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.pic_RATE.Dpi = 100F;
            this.pic_RATE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46F);
            this.pic_RATE.Name = "pic_RATE";
            this.pic_RATE.SizeF = new System.Drawing.SizeF(1109F, 715F);
            this.pic_RATE.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            //
            // S0502 Report Properties
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Dpi = 100F;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.chart_RATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;

        private DevExpress.XtraReports.UI.XRLabel lbl_TITLE;
        private DevExpress.XtraReports.UI.XRChart chart_RATE;
        private DevExpress.XtraReports.UI.XRPictureBox pic_RATE;
    }
}
