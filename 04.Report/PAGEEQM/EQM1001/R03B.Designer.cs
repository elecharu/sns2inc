namespace XtraRpt
{
    partial class R03B
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
            this.xrLabelTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableHeader = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowHeader = new DevExpress.XtraReports.UI.XRTableRow();
            this.cell_Hdr_NO = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_LINENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_EQMTPNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_EQMGROUP1NM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_EQMGROUP2NM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_EQMGROUP3NM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_EQMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_EQMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_PLANYM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_CHKDATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Hdr_EMPNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableDetail = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRowDetail = new DevExpress.XtraReports.UI.XRTableRow();
            this.cell_Detail_NO = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_LINENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_EQMTPNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_EQMGROUP1NM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_EQMGROUP2NM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_EQMGROUP3NM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_EQMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_EQMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_PLANYM = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_CHKDATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.cell_Detail_EMPNM = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableDetail)).BeginInit();
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
            this.xrLabelTitle,
            this.xrTableHeader});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 66F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabelTitle
            // 
            this.xrLabelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.xrLabelTitle.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabelTitle.Dpi = 100F;
            this.xrLabelTitle.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.xrLabelTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabelTitle.Name = "xrLabelTitle";
            this.xrLabelTitle.SizeF = new System.Drawing.SizeF(767F, 40F);
            this.xrLabelTitle.StylePriority.UseBackColor = false;
            this.xrLabelTitle.StylePriority.UseBorders = false;
            this.xrLabelTitle.StylePriority.UseFont = false;
            this.xrLabelTitle.StylePriority.UseTextAlignment = false;
            this.xrLabelTitle.Text = "월별 점검 계획";
            this.xrLabelTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableHeader
            // 
            this.xrTableHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(218)))));
            this.xrTableHeader.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.xrTableHeader.Dpi = 100F;
            this.xrTableHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.xrTableHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 40F);
            this.xrTableHeader.Name = "xrTableHeader";
            this.xrTableHeader.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowHeader});
            this.xrTableHeader.SizeF = new System.Drawing.SizeF(767F, 26F);
            this.xrTableHeader.StylePriority.UseBackColor = false;
            this.xrTableHeader.StylePriority.UseBorders = false;
            this.xrTableHeader.StylePriority.UseFont = false;
            this.xrTableHeader.StylePriority.UseTextAlignment = false;
            this.xrTableHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRowHeader
            // 
            this.xrTableRowHeader.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cell_Hdr_NO,
            this.cell_Hdr_LINENM,
            this.cell_Hdr_EQMTPNM,
            this.cell_Hdr_EQMGROUP1NM,
            this.cell_Hdr_EQMGROUP2NM,
            this.cell_Hdr_EQMGROUP3NM,
            this.cell_Hdr_EQMNM,
            this.cell_Hdr_EQMSPEC,
            this.cell_Hdr_PLANYM,
            this.cell_Hdr_CHKDATE,
            this.cell_Hdr_EMPNM});
            this.xrTableRowHeader.Dpi = 100F;
            this.xrTableRowHeader.Name = "xrTableRowHeader";
            this.xrTableRowHeader.Weight = 1D;
            // 
            // cell_Hdr_NO
            // 
            this.cell_Hdr_NO.Dpi = 100F;
            this.cell_Hdr_NO.Name = "cell_Hdr_NO";
            this.cell_Hdr_NO.Text = "구분";
            this.cell_Hdr_NO.Weight = 32D;
            // 
            // cell_Hdr_LINENM
            // 
            this.cell_Hdr_LINENM.Dpi = 100F;
            this.cell_Hdr_LINENM.Name = "cell_Hdr_LINENM";
            this.cell_Hdr_LINENM.Text = "라인명";
            this.cell_Hdr_LINENM.Weight = 58D;
            // 
            // cell_Hdr_EQMTPNM
            // 
            this.cell_Hdr_EQMTPNM.Dpi = 100F;
            this.cell_Hdr_EQMTPNM.Name = "cell_Hdr_EQMTPNM";
            this.cell_Hdr_EQMTPNM.Text = "공정구분";
            this.cell_Hdr_EQMTPNM.Weight = 56D;
            // 
            // cell_Hdr_EQMGROUP1NM
            // 
            this.cell_Hdr_EQMGROUP1NM.Dpi = 100F;
            this.cell_Hdr_EQMGROUP1NM.Name = "cell_Hdr_EQMGROUP1NM";
            this.cell_Hdr_EQMGROUP1NM.Text = "대분류";
            this.cell_Hdr_EQMGROUP1NM.Weight = 44D;
            // 
            // cell_Hdr_EQMGROUP2NM
            // 
            this.cell_Hdr_EQMGROUP2NM.Dpi = 100F;
            this.cell_Hdr_EQMGROUP2NM.Name = "cell_Hdr_EQMGROUP2NM";
            this.cell_Hdr_EQMGROUP2NM.Text = "중분류";
            this.cell_Hdr_EQMGROUP2NM.Weight = 58D;
            // 
            // cell_Hdr_EQMGROUP3NM
            // 
            this.cell_Hdr_EQMGROUP3NM.Dpi = 100F;
            this.cell_Hdr_EQMGROUP3NM.Name = "cell_Hdr_EQMGROUP3NM";
            this.cell_Hdr_EQMGROUP3NM.Text = "소분류";
            this.cell_Hdr_EQMGROUP3NM.Weight = 44D;
            // 
            // cell_Hdr_EQMNM
            // 
            this.cell_Hdr_EQMNM.Dpi = 100F;
            this.cell_Hdr_EQMNM.Name = "cell_Hdr_EQMNM";
            this.cell_Hdr_EQMNM.Text = "설비명";
            this.cell_Hdr_EQMNM.Weight = 116D;
            // 
            // cell_Hdr_EQMSPEC
            // 
            this.cell_Hdr_EQMSPEC.Dpi = 100F;
            this.cell_Hdr_EQMSPEC.Name = "cell_Hdr_EQMSPEC";
            this.cell_Hdr_EQMSPEC.Text = "모델명/규격";
            this.cell_Hdr_EQMSPEC.Weight = 150D;
            // 
            // cell_Hdr_PLANYM
            // 
            this.cell_Hdr_PLANYM.Dpi = 100F;
            this.cell_Hdr_PLANYM.Name = "cell_Hdr_PLANYM";
            this.cell_Hdr_PLANYM.Text = "점검예정일";
            this.cell_Hdr_PLANYM.Weight = 68D;
            // 
            // cell_Hdr_CHKDATE
            // 
            this.cell_Hdr_CHKDATE.Dpi = 100F;
            this.cell_Hdr_CHKDATE.Name = "cell_Hdr_CHKDATE";
            this.cell_Hdr_CHKDATE.Text = "점검실시일";
            this.cell_Hdr_CHKDATE.Weight = 70D;
            // 
            // cell_Hdr_EMPNM
            // 
            this.cell_Hdr_EMPNM.Dpi = 100F;
            this.cell_Hdr_EMPNM.Name = "cell_Hdr_EMPNM";
            this.cell_Hdr_EMPNM.Text = "점검자";
            this.cell_Hdr_EMPNM.Weight = 71D;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableDetail});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableDetail
            // 
            this.xrTableDetail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableDetail.Dpi = 100F;
            this.xrTableDetail.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.xrTableDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTableDetail.Name = "xrTableDetail";
            this.xrTableDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRowDetail});
            this.xrTableDetail.SizeF = new System.Drawing.SizeF(767F, 25F);
            this.xrTableDetail.StylePriority.UseBorders = false;
            this.xrTableDetail.StylePriority.UseFont = false;
            this.xrTableDetail.StylePriority.UsePadding = false;
            this.xrTableDetail.StylePriority.UseTextAlignment = false;
            this.xrTableDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRowDetail
            // 
            this.xrTableRowDetail.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cell_Detail_NO,
            this.cell_Detail_LINENM,
            this.cell_Detail_EQMTPNM,
            this.cell_Detail_EQMGROUP1NM,
            this.cell_Detail_EQMGROUP2NM,
            this.cell_Detail_EQMGROUP3NM,
            this.cell_Detail_EQMNM,
            this.cell_Detail_EQMSPEC,
            this.cell_Detail_PLANYM,
            this.cell_Detail_CHKDATE,
            this.cell_Detail_EMPNM});
            this.xrTableRowDetail.Dpi = 100F;
            this.xrTableRowDetail.Name = "xrTableRowDetail";
            this.xrTableRowDetail.Weight = 1D;
            // 
            // cell_Detail_NO
            // 
            this.cell_Detail_NO.CanGrow = false;
            this.cell_Detail_NO.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "NO")});
            this.cell_Detail_NO.Dpi = 100F;
            this.cell_Detail_NO.Name = "cell_Detail_NO";
            this.cell_Detail_NO.Weight = 32D;
            this.cell_Detail_NO.WordWrap = false;
            // 
            // cell_Detail_LINENM
            // 
            this.cell_Detail_LINENM.CanGrow = false;
            this.cell_Detail_LINENM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LINENM")});
            this.cell_Detail_LINENM.Dpi = 100F;
            this.cell_Detail_LINENM.Name = "cell_Detail_LINENM";
            this.cell_Detail_LINENM.Weight = 58D;
            this.cell_Detail_LINENM.WordWrap = false;
            // 
            // cell_Detail_EQMTPNM
            // 
            this.cell_Detail_EQMTPNM.CanGrow = false;
            this.cell_Detail_EQMTPNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EQMTPNM")});
            this.cell_Detail_EQMTPNM.Dpi = 100F;
            this.cell_Detail_EQMTPNM.Name = "cell_Detail_EQMTPNM";
            this.cell_Detail_EQMTPNM.Weight = 56D;
            this.cell_Detail_EQMTPNM.WordWrap = false;
            // 
            // cell_Detail_EQMGROUP1NM
            // 
            this.cell_Detail_EQMGROUP1NM.CanGrow = false;
            this.cell_Detail_EQMGROUP1NM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EQMGROUP1NM")});
            this.cell_Detail_EQMGROUP1NM.Dpi = 100F;
            this.cell_Detail_EQMGROUP1NM.Name = "cell_Detail_EQMGROUP1NM";
            this.cell_Detail_EQMGROUP1NM.Weight = 44D;
            this.cell_Detail_EQMGROUP1NM.WordWrap = false;
            // 
            // cell_Detail_EQMGROUP2NM
            // 
            this.cell_Detail_EQMGROUP2NM.CanGrow = false;
            this.cell_Detail_EQMGROUP2NM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EQMGROUP2NM")});
            this.cell_Detail_EQMGROUP2NM.Dpi = 100F;
            this.cell_Detail_EQMGROUP2NM.Name = "cell_Detail_EQMGROUP2NM";
            this.cell_Detail_EQMGROUP2NM.Weight = 58D;
            this.cell_Detail_EQMGROUP2NM.WordWrap = false;
            // 
            // cell_Detail_EQMGROUP3NM
            // 
            this.cell_Detail_EQMGROUP3NM.CanGrow = false;
            this.cell_Detail_EQMGROUP3NM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EQMGROUP3NM")});
            this.cell_Detail_EQMGROUP3NM.Dpi = 100F;
            this.cell_Detail_EQMGROUP3NM.Name = "cell_Detail_EQMGROUP3NM";
            this.cell_Detail_EQMGROUP3NM.Weight = 44D;
            this.cell_Detail_EQMGROUP3NM.WordWrap = false;
            // 
            // cell_Detail_EQMNM
            // 
            this.cell_Detail_EQMNM.CanGrow = false;
            this.cell_Detail_EQMNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EQMNM")});
            this.cell_Detail_EQMNM.Dpi = 100F;
            this.cell_Detail_EQMNM.Name = "cell_Detail_EQMNM";
            this.cell_Detail_EQMNM.Weight = 116D;
            this.cell_Detail_EQMNM.WordWrap = false;
            // 
            // cell_Detail_EQMSPEC
            // 
            this.cell_Detail_EQMSPEC.CanGrow = false;
            this.cell_Detail_EQMSPEC.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EQMSPEC")});
            this.cell_Detail_EQMSPEC.Dpi = 100F;
            this.cell_Detail_EQMSPEC.Name = "cell_Detail_EQMSPEC";
            this.cell_Detail_EQMSPEC.Weight = 150D;
            this.cell_Detail_EQMSPEC.WordWrap = false;
            // 
            // cell_Detail_PLANYM
            // 
            this.cell_Detail_PLANYM.CanGrow = false;
            this.cell_Detail_PLANYM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PLANYM")});
            this.cell_Detail_PLANYM.Dpi = 100F;
            this.cell_Detail_PLANYM.Name = "cell_Detail_PLANYM";
            this.cell_Detail_PLANYM.Weight = 68D;
            this.cell_Detail_PLANYM.WordWrap = false;
            // 
            // cell_Detail_CHKDATE
            // 
            this.cell_Detail_CHKDATE.CanGrow = false;
            this.cell_Detail_CHKDATE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CHKDATE")});
            this.cell_Detail_CHKDATE.Dpi = 100F;
            this.cell_Detail_CHKDATE.Name = "cell_Detail_CHKDATE";
            this.cell_Detail_CHKDATE.Weight = 70D;
            this.cell_Detail_CHKDATE.WordWrap = false;
            // 
            // cell_Detail_EMPNM
            // 
            this.cell_Detail_EMPNM.CanGrow = false;
            this.cell_Detail_EMPNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EMPNM")});
            this.cell_Detail_EMPNM.Dpi = 100F;
            this.cell_Detail_EMPNM.Name = "cell_Detail_EMPNM";
            this.cell_Detail_EMPNM.Weight = 71D;
            this.cell_Detail_EMPNM.WordWrap = false;
            // 
            // R03B
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.Detail});
            this.Dpi = 100F;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabelTitle;
        private DevExpress.XtraReports.UI.XRTable xrTableHeader;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowHeader;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_NO;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_LINENM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_EQMTPNM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_EQMGROUP1NM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_EQMGROUP2NM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_EQMGROUP3NM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_EQMNM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_EQMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_PLANYM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_CHKDATE;
        private DevExpress.XtraReports.UI.XRTableCell cell_Hdr_EMPNM;
        private DevExpress.XtraReports.UI.XRTable xrTableDetail;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRowDetail;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_NO;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_LINENM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_EQMTPNM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_EQMGROUP1NM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_EQMGROUP2NM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_EQMGROUP3NM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_EQMNM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_EQMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_PLANYM;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_CHKDATE;
        private DevExpress.XtraReports.UI.XRTableCell cell_Detail_EMPNM;
    }
}
