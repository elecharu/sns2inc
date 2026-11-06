namespace XtraRpt
{
    partial class R06A
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R06A));
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lbl_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.bar_RELEASEKEY = new DevExpress.XtraReports.UI.XRBarCode();
            this.lbl_EQMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_SIGN1_HEAD = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_SIGN2_HEAD = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_SIGN3_HEAD = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_SIGN1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_SIGN2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_SIGN3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_DATE = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_HEAD_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_HEAD_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lbl_ITEMSPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_RELQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.pic_LOGO = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // TopMargin
            //
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            //
            // PageHeader
            //
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_TITLE,
            this.bar_RELEASEKEY,
            this.lbl_EQMNM,
            this.lbl_SIGN1_HEAD,
            this.lbl_SIGN2_HEAD,
            this.lbl_SIGN3_HEAD,
            this.lbl_SIGN1,
            this.lbl_SIGN2,
            this.lbl_SIGN3,
            this.lbl_DATE,
            this.lbl_HEAD_SPEC,
            this.lbl_HEAD_QTY});
            this.PageHeader.HeightF = 300F;
            this.PageHeader.Name = "PageHeader";
            //
            // lbl_TITLE
            //
            this.lbl_TITLE.Font = new System.Drawing.Font("맑은 고딕", 26F, System.Drawing.FontStyle.Bold);
            this.lbl_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbl_TITLE.Name = "lbl_TITLE";
            this.lbl_TITLE.SizeF = new System.Drawing.SizeF(727F, 50F);
            this.lbl_TITLE.Text = "공구불출증";
            this.lbl_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // bar_RELEASEKEY (불출증키 바코드)
            //
            this.bar_RELEASEKEY.AutoModule = true;
            this.bar_RELEASEKEY.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.bar_RELEASEKEY.LocationFloat = new DevExpress.Utils.PointFloat(214F, 55F);
            this.bar_RELEASEKEY.Name = "bar_RELEASEKEY";
            this.bar_RELEASEKEY.SizeF = new System.Drawing.SizeF(300F, 65F);
            this.bar_RELEASEKEY.Symbology = code128Generator1;
            this.bar_RELEASEKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            //
            // lbl_EQMNM ("(  라인  )LINE")
            //
            this.lbl_EQMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.lbl_EQMNM.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lbl_EQMNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130F);
            this.lbl_EQMNM.Name = "lbl_EQMNM";
            this.lbl_EQMNM.SizeF = new System.Drawing.SizeF(436F, 80F);
            this.lbl_EQMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_SIGN1_HEAD (왼쪽 선은 lbl_EQMNM 오른쪽 선과 겹치므로 그리지 않음)
            //
            this.lbl_SIGN1_HEAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lbl_SIGN1_HEAD.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_SIGN1_HEAD.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_SIGN1_HEAD.LocationFloat = new DevExpress.Utils.PointFloat(436F, 130F);
            this.lbl_SIGN1_HEAD.Name = "lbl_SIGN1_HEAD";
            this.lbl_SIGN1_HEAD.SizeF = new System.Drawing.SizeF(97F, 30F);
            this.lbl_SIGN1_HEAD.Text = "요청자";
            this.lbl_SIGN1_HEAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_SIGN2_HEAD
            //
            this.lbl_SIGN2_HEAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lbl_SIGN2_HEAD.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_SIGN2_HEAD.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_SIGN2_HEAD.LocationFloat = new DevExpress.Utils.PointFloat(533F, 130F);
            this.lbl_SIGN2_HEAD.Name = "lbl_SIGN2_HEAD";
            this.lbl_SIGN2_HEAD.SizeF = new System.Drawing.SizeF(97F, 30F);
            this.lbl_SIGN2_HEAD.Text = "대구텍";
            this.lbl_SIGN2_HEAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_SIGN3_HEAD
            //
            this.lbl_SIGN3_HEAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lbl_SIGN3_HEAD.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_SIGN3_HEAD.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_SIGN3_HEAD.LocationFloat = new DevExpress.Utils.PointFloat(630F, 130F);
            this.lbl_SIGN3_HEAD.Name = "lbl_SIGN3_HEAD";
            this.lbl_SIGN3_HEAD.SizeF = new System.Drawing.SizeF(97F, 30F);
            this.lbl_SIGN3_HEAD.Text = "S & S";
            this.lbl_SIGN3_HEAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_SIGN1 (요청자 = 수령자)
            //
            this.lbl_SIGN1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_SIGN1.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lbl_SIGN1.LocationFloat = new DevExpress.Utils.PointFloat(436F, 160F);
            this.lbl_SIGN1.Name = "lbl_SIGN1";
            this.lbl_SIGN1.SizeF = new System.Drawing.SizeF(97F, 50F);
            this.lbl_SIGN1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_SIGN2 (대구텍 = 불출자)
            //
            this.lbl_SIGN2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_SIGN2.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lbl_SIGN2.LocationFloat = new DevExpress.Utils.PointFloat(533F, 160F);
            this.lbl_SIGN2.Name = "lbl_SIGN2";
            this.lbl_SIGN2.SizeF = new System.Drawing.SizeF(97F, 50F);
            this.lbl_SIGN2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_SIGN3 (S & S = 확정자)
            //
            this.lbl_SIGN3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_SIGN3.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lbl_SIGN3.LocationFloat = new DevExpress.Utils.PointFloat(630F, 160F);
            this.lbl_SIGN3.Name = "lbl_SIGN3";
            this.lbl_SIGN3.SizeF = new System.Drawing.SizeF(97F, 50F);
            this.lbl_SIGN3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_DATE ("yyyy 년 M 월 d 일")
            //
            this.lbl_DATE.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_DATE.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_DATE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 210F);
            this.lbl_DATE.Name = "lbl_DATE";
            this.lbl_DATE.SizeF = new System.Drawing.SizeF(727F, 45F);
            this.lbl_DATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_HEAD_SPEC
            //
            this.lbl_HEAD_SPEC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lbl_HEAD_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.lbl_HEAD_SPEC.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_HEAD_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 265F);
            this.lbl_HEAD_SPEC.Name = "lbl_HEAD_SPEC";
            this.lbl_HEAD_SPEC.SizeF = new System.Drawing.SizeF(436F, 35F);
            this.lbl_HEAD_SPEC.Text = "공 구 규 격";
            this.lbl_HEAD_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_HEAD_QTY (왼쪽 선은 lbl_HEAD_SPEC 오른쪽 선과 겹치므로 그리지 않음)
            //
            this.lbl_HEAD_QTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lbl_HEAD_QTY.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_HEAD_QTY.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_HEAD_QTY.LocationFloat = new DevExpress.Utils.PointFloat(436F, 265F);
            this.lbl_HEAD_QTY.Name = "lbl_HEAD_QTY";
            this.lbl_HEAD_QTY.SizeF = new System.Drawing.SizeF(291F, 35F);
            this.lbl_HEAD_QTY.Text = "요청수량";
            this.lbl_HEAD_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // Detail (12줄 = 1페이지)
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_ITEMSPEC,
            this.lbl_RELQTY});
            this.Detail.HeightF = 55F;
            this.Detail.Name = "Detail";
            //
            // lbl_ITEMSPEC
            //
            this.lbl_ITEMSPEC.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_ITEMSPEC.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMSPEC")});
            this.lbl_ITEMSPEC.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_ITEMSPEC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbl_ITEMSPEC.Name = "lbl_ITEMSPEC";
            this.lbl_ITEMSPEC.SizeF = new System.Drawing.SizeF(436F, 55F);
            this.lbl_ITEMSPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // lbl_RELQTY
            //
            this.lbl_RELQTY.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_RELQTY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RELQTY")});
            this.lbl_RELQTY.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_RELQTY.LocationFloat = new DevExpress.Utils.PointFloat(436F, 0F);
            this.lbl_RELQTY.Name = "lbl_RELQTY";
            this.lbl_RELQTY.SizeF = new System.Drawing.SizeF(291F, 55F);
            this.lbl_RELQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // PageFooter
            //
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pic_LOGO});
            this.PageFooter.HeightF = 70F;
            this.PageFooter.Name = "PageFooter";
            //
            // pic_LOGO (TaeguTec)
            //
            this.pic_LOGO.Image = ((System.Drawing.Image)(resources.GetObject("pic_LOGO.Image")));
            this.pic_LOGO.LocationFloat = new DevExpress.Utils.PointFloat(274F, 3F);
            this.pic_LOGO.Name = "pic_LOGO";
            this.pic_LOGO.SizeF = new System.Drawing.SizeF(180F, 65F);
            this.pic_LOGO.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            //
            // BottomMargin
            //
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            //
            // R06A
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.PageHeader,
            this.Detail,
            this.PageFooter,
            this.BottomMargin});
            this.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lbl_TITLE;
        private DevExpress.XtraReports.UI.XRBarCode bar_RELEASEKEY;
        private DevExpress.XtraReports.UI.XRLabel lbl_EQMNM;
        private DevExpress.XtraReports.UI.XRLabel lbl_SIGN1_HEAD;
        private DevExpress.XtraReports.UI.XRLabel lbl_SIGN2_HEAD;
        private DevExpress.XtraReports.UI.XRLabel lbl_SIGN3_HEAD;
        private DevExpress.XtraReports.UI.XRLabel lbl_SIGN1;
        private DevExpress.XtraReports.UI.XRLabel lbl_SIGN2;
        private DevExpress.XtraReports.UI.XRLabel lbl_SIGN3;
        private DevExpress.XtraReports.UI.XRLabel lbl_DATE;
        private DevExpress.XtraReports.UI.XRLabel lbl_HEAD_SPEC;
        private DevExpress.XtraReports.UI.XRLabel lbl_HEAD_QTY;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel lbl_ITEMSPEC;
        private DevExpress.XtraReports.UI.XRLabel lbl_RELQTY;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPictureBox pic_LOGO;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    }
}
