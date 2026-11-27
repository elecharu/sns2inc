namespace XtraRpt
{
    partial class S0503
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
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            // PageHeader Controls
            this.lbl_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLineTitle = new DevExpress.XtraReports.UI.XRLine();
            // Detail Controls
            this.chart_PART = new DevExpress.XtraReports.UI.XRChart();
            this.pic_PART = new DevExpress.XtraReports.UI.XRPictureBox();
            this.lbl_NAME = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PART)).BeginInit();
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
            // PageHeader
            //
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_TITLE,
            this.xrLineTitle});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 50F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.lbl_TITLE.Text = "■ 설비별 고장부위 현황";
            this.lbl_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // xrLineTitle
            //
            this.xrLineTitle.Dpi = 100F;
            this.xrLineTitle.LineWidth = 2;
            this.xrLineTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38F);
            this.xrLineTitle.Name = "xrLineTitle";
            this.xrLineTitle.SizeF = new System.Drawing.SizeF(1109F, 4F);
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.chart_PART,
            this.pic_PART,
            this.lbl_NAME});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 340F;
            this.Detail.MultiColumn.ColumnCount = 3;
            this.Detail.MultiColumn.ColumnSpacing = 10F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // chart_PART
            //
            this.chart_PART.BorderColor = System.Drawing.Color.Silver;
            this.chart_PART.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.chart_PART.Dpi = 100F;
            this.chart_PART.LocationFloat = new DevExpress.Utils.PointFloat(0F, 4F);
            this.chart_PART.Name = "chart_PART";
            this.chart_PART.SizeF = new System.Drawing.SizeF(363F, 292F);
            //
            // pic_PART
            //
            this.pic_PART.BorderColor = System.Drawing.Color.Silver;
            this.pic_PART.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.pic_PART.Dpi = 100F;
            this.pic_PART.LocationFloat = new DevExpress.Utils.PointFloat(0F, 4F);
            this.pic_PART.Name = "pic_PART";
            this.pic_PART.SizeF = new System.Drawing.SizeF(363F, 292F);
            this.pic_PART.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // lbl_NAME
            this.lbl_NAME.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PIENAME")});
            this.lbl_NAME.Dpi = 100F;
            this.lbl_NAME.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_NAME.LocationFloat = new DevExpress.Utils.PointFloat(0F, 298F);
            this.lbl_NAME.Multiline = true;
            this.lbl_NAME.Name = "lbl_NAME";
            this.lbl_NAME.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_NAME.SizeF = new System.Drawing.SizeF(363F, 36F);
            this.lbl_NAME.StylePriority.UseFont = false;
            this.lbl_NAME.StylePriority.UseTextAlignment = false;
            this.lbl_NAME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            //
            // S0503 Report Properties
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.Detail});
            this.Dpi = 100F;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.chart_PART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;

        private DevExpress.XtraReports.UI.XRLabel lbl_TITLE;
        private DevExpress.XtraReports.UI.XRLine xrLineTitle;

        private DevExpress.XtraReports.UI.XRChart chart_PART;
        private DevExpress.XtraReports.UI.XRPictureBox pic_PART;
        private DevExpress.XtraReports.UI.XRLabel lbl_NAME;
    }
}
