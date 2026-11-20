namespace TMLPRINT
{
    partial class MTR_2
    {
        /// <summary>
        /// // 2026-11-19 PRD_1(생산실적 공정이동표)과 같은 양식 (A4 세로, 여백 50, 11pt 굵게). 재고 LOT 1개당 1장
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lbl_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.bar_LOTKEY = new DevExpress.XtraReports.UI.XRBarCode();
            this.tbl_HEAD = new DevExpress.XtraReports.UI.XRTable();
            this.tbl_LOT = new DevExpress.XtraReports.UI.XRTable();
            this.tbl_TRACE_HEAD = new DevExpress.XtraReports.UI.XRTable();
            this.tbl_TRACE = new DevExpress.XtraReports.UI.XRTable();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.tbl_HEAD_R1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_HEATNO = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_HEATNO = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_HEAD_R2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_ITEMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_ITEMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_EMPNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_EMPNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_HEAD_R3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_ITEMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_ITEMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_PRINTDATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_PRINTDATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_LOT_R1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_LINENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_PRCNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_EQMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_LOTKEY = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_UNITNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_QTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_LOT_R2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.C_LINENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_PRCNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_EQMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_LOTKEY = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_UNITNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_QTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_TRACE_HEAD_R1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_NO = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_TRACE_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_TRACE_LINENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_TRACE_PRCNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_TRACE_LOTKEY = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_TRACE_R1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.D_NO = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_LINENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_PRCNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_LOTKEY = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_HEAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_LOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_TRACE_HEAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_TRACE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // TopMargin
            //
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            //
            // Detail (LOT 1개 = 이동표 1장, LOT 마다 페이지 나눔)
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_TITLE,
            this.tbl_HEAD,
            this.bar_LOTKEY,
            this.tbl_LOT,
            this.tbl_TRACE_HEAD,
            this.tbl_TRACE});
            this.Detail.HeightF = 480F;
            this.Detail.Name = "Detail";
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry;
            //
            // lbl_TITLE ("공 정 이 동 표 ( 재 고 )")
            //
            this.lbl_TITLE.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lbl_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 15F);
            this.lbl_TITLE.Name = "lbl_TITLE";
            this.lbl_TITLE.SizeF = new System.Drawing.SizeF(727F, 60F);
            this.lbl_TITLE.Text = "공 정 이 동 표 ( 재 고 )";
            this.lbl_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // tbl_HEAD (품번·품명·규격·HEAT NO·발행자·발행일)
            //
            this.tbl_HEAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.tbl_HEAD.LocationFloat = new DevExpress.Utils.PointFloat(0F, 95F);
            this.tbl_HEAD.Name = "tbl_HEAD";
            this.tbl_HEAD.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tbl_HEAD_R1,
            this.tbl_HEAD_R2,
            this.tbl_HEAD_R3});
            this.tbl_HEAD.SizeF = new System.Drawing.SizeF(727.0F, 108F);
            //
            // tbl_HEAD_R1
            //
            this.tbl_HEAD_R1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_ITEMCD,
            this.C_ITEMCD,
            this.H_HEATNO,
            this.C_HEATNO});
            this.tbl_HEAD_R1.Name = "tbl_HEAD_R1";
            this.tbl_HEAD_R1.Weight = 1D;
            //
            // H_ITEMCD
            //
            this.H_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_ITEMCD.Name = "H_ITEMCD";
            this.H_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_ITEMCD.StylePriority.UseFont = false;
            this.H_ITEMCD.StylePriority.UsePadding = false;
            this.H_ITEMCD.StylePriority.UseTextAlignment = false;
            this.H_ITEMCD.Text = "품번";
            this.H_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_ITEMCD.Weight = 100D;
            //
            // C_ITEMCD
            //
            this.C_ITEMCD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMCD")});
            this.C_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_ITEMCD.Name = "C_ITEMCD";
            this.C_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_ITEMCD.StylePriority.UseFont = false;
            this.C_ITEMCD.StylePriority.UsePadding = false;
            this.C_ITEMCD.StylePriority.UseTextAlignment = false;
            this.C_ITEMCD.Text = "";
            this.C_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_ITEMCD.Weight = 260D;
            //
            // H_HEATNO
            //
            this.H_HEATNO.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_HEATNO.Name = "H_HEATNO";
            this.H_HEATNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_HEATNO.StylePriority.UseFont = false;
            this.H_HEATNO.StylePriority.UsePadding = false;
            this.H_HEATNO.StylePriority.UseTextAlignment = false;
            this.H_HEATNO.Text = "HEAT NO";
            this.H_HEATNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_HEATNO.Weight = 140D;
            //
            // C_HEATNO
            //
            this.C_HEATNO.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "HEATNO")});
            this.C_HEATNO.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_HEATNO.Name = "C_HEATNO";
            this.C_HEATNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_HEATNO.StylePriority.UseFont = false;
            this.C_HEATNO.StylePriority.UsePadding = false;
            this.C_HEATNO.StylePriority.UseTextAlignment = false;
            this.C_HEATNO.Text = "";
            this.C_HEATNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_HEATNO.Weight = 227D;
            //
            // tbl_HEAD_R2
            //
            this.tbl_HEAD_R2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_ITEMNM,
            this.C_ITEMNM,
            this.H_EMPNM,
            this.C_EMPNM});
            this.tbl_HEAD_R2.Name = "tbl_HEAD_R2";
            this.tbl_HEAD_R2.Weight = 1D;
            //
            // H_ITEMNM
            //
            this.H_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_ITEMNM.Name = "H_ITEMNM";
            this.H_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_ITEMNM.StylePriority.UseFont = false;
            this.H_ITEMNM.StylePriority.UsePadding = false;
            this.H_ITEMNM.StylePriority.UseTextAlignment = false;
            this.H_ITEMNM.Text = "품명";
            this.H_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_ITEMNM.Weight = 100D;
            //
            // C_ITEMNM
            //
            this.C_ITEMNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMNM")});
            this.C_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_ITEMNM.Name = "C_ITEMNM";
            this.C_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_ITEMNM.StylePriority.UseFont = false;
            this.C_ITEMNM.StylePriority.UsePadding = false;
            this.C_ITEMNM.StylePriority.UseTextAlignment = false;
            this.C_ITEMNM.Text = "";
            this.C_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_ITEMNM.Weight = 260D;
            //
            // H_EMPNM
            //
            this.H_EMPNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_EMPNM.Name = "H_EMPNM";
            this.H_EMPNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_EMPNM.StylePriority.UseFont = false;
            this.H_EMPNM.StylePriority.UsePadding = false;
            this.H_EMPNM.StylePriority.UseTextAlignment = false;
            this.H_EMPNM.Text = "발행자";
            this.H_EMPNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_EMPNM.Weight = 140D;
            //
            // C_EMPNM
            //
            this.C_EMPNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EMPNM")});
            this.C_EMPNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_EMPNM.Name = "C_EMPNM";
            this.C_EMPNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_EMPNM.StylePriority.UseFont = false;
            this.C_EMPNM.StylePriority.UsePadding = false;
            this.C_EMPNM.StylePriority.UseTextAlignment = false;
            this.C_EMPNM.Text = "";
            this.C_EMPNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_EMPNM.Weight = 227D;
            //
            // tbl_HEAD_R3
            //
            this.tbl_HEAD_R3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_ITEMSPEC,
            this.C_ITEMSPEC,
            this.H_PRINTDATE,
            this.C_PRINTDATE});
            this.tbl_HEAD_R3.Name = "tbl_HEAD_R3";
            this.tbl_HEAD_R3.Weight = 1D;
            //
            // H_ITEMSPEC
            //
            this.H_ITEMSPEC.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_ITEMSPEC.Name = "H_ITEMSPEC";
            this.H_ITEMSPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_ITEMSPEC.StylePriority.UseFont = false;
            this.H_ITEMSPEC.StylePriority.UsePadding = false;
            this.H_ITEMSPEC.StylePriority.UseTextAlignment = false;
            this.H_ITEMSPEC.Text = "규격";
            this.H_ITEMSPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_ITEMSPEC.Weight = 100D;
            //
            // C_ITEMSPEC
            //
            this.C_ITEMSPEC.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMSPEC")});
            this.C_ITEMSPEC.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_ITEMSPEC.Name = "C_ITEMSPEC";
            this.C_ITEMSPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_ITEMSPEC.StylePriority.UseFont = false;
            this.C_ITEMSPEC.StylePriority.UsePadding = false;
            this.C_ITEMSPEC.StylePriority.UseTextAlignment = false;
            this.C_ITEMSPEC.Text = "";
            this.C_ITEMSPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_ITEMSPEC.Weight = 260D;
            //
            // H_PRINTDATE
            //
            this.H_PRINTDATE.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_PRINTDATE.Name = "H_PRINTDATE";
            this.H_PRINTDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_PRINTDATE.StylePriority.UseFont = false;
            this.H_PRINTDATE.StylePriority.UsePadding = false;
            this.H_PRINTDATE.StylePriority.UseTextAlignment = false;
            this.H_PRINTDATE.Text = "발행일";
            this.H_PRINTDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_PRINTDATE.Weight = 140D;
            //
            // C_PRINTDATE
            //
            this.C_PRINTDATE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PRINTDATE")});
            this.C_PRINTDATE.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_PRINTDATE.Name = "C_PRINTDATE";
            this.C_PRINTDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_PRINTDATE.StylePriority.UseFont = false;
            this.C_PRINTDATE.StylePriority.UsePadding = false;
            this.C_PRINTDATE.StylePriority.UseTextAlignment = false;
            this.C_PRINTDATE.Text = "";
            this.C_PRINTDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_PRINTDATE.Weight = 227D;
            //
            // bar_LOTKEY (LOT 바코드)
            //
            this.bar_LOTKEY.AutoModule = true;
            this.bar_LOTKEY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LOTKEY")});
            this.bar_LOTKEY.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.bar_LOTKEY.LocationFloat = new DevExpress.Utils.PointFloat(213F, 218F);
            this.bar_LOTKEY.Name = "bar_LOTKEY";
            this.bar_LOTKEY.SizeF = new System.Drawing.SizeF(300F, 65F);
            this.bar_LOTKEY.Symbology = code128Generator1;
            this.bar_LOTKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            //
            // tbl_LOT (로트정보 : 작업장·공정·생산설비는 재고라 빈칸)
            //
            this.tbl_LOT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.tbl_LOT.LocationFloat = new DevExpress.Utils.PointFloat(0F, 298F);
            this.tbl_LOT.Name = "tbl_LOT";
            this.tbl_LOT.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tbl_LOT_R1,
            this.tbl_LOT_R2});
            this.tbl_LOT.SizeF = new System.Drawing.SizeF(727.0F, 80F);
            //
            // tbl_LOT_R1
            //
            this.tbl_LOT_R1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_LINENM,
            this.H_PRCNM,
            this.H_EQMNM,
            this.H_LOTKEY,
            this.H_UNITNM,
            this.H_QTY});
            this.tbl_LOT_R1.Name = "tbl_LOT_R1";
            this.tbl_LOT_R1.Weight = 1D;
            //
            // H_LINENM
            //
            this.H_LINENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_LINENM.Name = "H_LINENM";
            this.H_LINENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_LINENM.StylePriority.UseFont = false;
            this.H_LINENM.StylePriority.UsePadding = false;
            this.H_LINENM.StylePriority.UseTextAlignment = false;
            this.H_LINENM.Text = "작업장";
            this.H_LINENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_LINENM.Weight = 105D;
            //
            // H_PRCNM
            //
            this.H_PRCNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_PRCNM.Name = "H_PRCNM";
            this.H_PRCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_PRCNM.StylePriority.UseFont = false;
            this.H_PRCNM.StylePriority.UsePadding = false;
            this.H_PRCNM.StylePriority.UseTextAlignment = false;
            this.H_PRCNM.Text = "공정";
            this.H_PRCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_PRCNM.Weight = 100D;
            //
            // H_EQMNM
            //
            this.H_EQMNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_EQMNM.Name = "H_EQMNM";
            this.H_EQMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_EQMNM.StylePriority.UseFont = false;
            this.H_EQMNM.StylePriority.UsePadding = false;
            this.H_EQMNM.StylePriority.UseTextAlignment = false;
            this.H_EQMNM.Text = "생산설비";
            this.H_EQMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_EQMNM.Weight = 120D;
            //
            // H_LOTKEY
            //
            this.H_LOTKEY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_LOTKEY.Name = "H_LOTKEY";
            this.H_LOTKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_LOTKEY.StylePriority.UseFont = false;
            this.H_LOTKEY.StylePriority.UsePadding = false;
            this.H_LOTKEY.StylePriority.UseTextAlignment = false;
            this.H_LOTKEY.Text = "LOTNO";
            this.H_LOTKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_LOTKEY.Weight = 192D;
            //
            // H_UNITNM
            //
            this.H_UNITNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_UNITNM.Name = "H_UNITNM";
            this.H_UNITNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_UNITNM.StylePriority.UseFont = false;
            this.H_UNITNM.StylePriority.UsePadding = false;
            this.H_UNITNM.StylePriority.UseTextAlignment = false;
            this.H_UNITNM.Text = "단위";
            this.H_UNITNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_UNITNM.Weight = 80D;
            //
            // H_QTY
            //
            this.H_QTY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_QTY.Name = "H_QTY";
            this.H_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_QTY.StylePriority.UseFont = false;
            this.H_QTY.StylePriority.UsePadding = false;
            this.H_QTY.StylePriority.UseTextAlignment = false;
            this.H_QTY.Text = "수량";
            this.H_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_QTY.Weight = 130D;
            //
            // tbl_LOT_R2
            //
            this.tbl_LOT_R2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.C_LINENM,
            this.C_PRCNM,
            this.C_EQMNM,
            this.C_LOTKEY,
            this.C_UNITNM,
            this.C_QTY});
            this.tbl_LOT_R2.Name = "tbl_LOT_R2";
            this.tbl_LOT_R2.Weight = 1D;
            //
            // C_LINENM
            //
            this.C_LINENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_LINENM.Name = "C_LINENM";
            this.C_LINENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_LINENM.StylePriority.UseFont = false;
            this.C_LINENM.StylePriority.UsePadding = false;
            this.C_LINENM.StylePriority.UseTextAlignment = false;
            this.C_LINENM.Text = "";
            this.C_LINENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_LINENM.Weight = 105D;
            //
            // C_PRCNM
            //
            this.C_PRCNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_PRCNM.Name = "C_PRCNM";
            this.C_PRCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_PRCNM.StylePriority.UseFont = false;
            this.C_PRCNM.StylePriority.UsePadding = false;
            this.C_PRCNM.StylePriority.UseTextAlignment = false;
            this.C_PRCNM.Text = "";
            this.C_PRCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_PRCNM.Weight = 100D;
            //
            // C_EQMNM
            //
            this.C_EQMNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_EQMNM.Name = "C_EQMNM";
            this.C_EQMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_EQMNM.StylePriority.UseFont = false;
            this.C_EQMNM.StylePriority.UsePadding = false;
            this.C_EQMNM.StylePriority.UseTextAlignment = false;
            this.C_EQMNM.Text = "";
            this.C_EQMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_EQMNM.Weight = 120D;
            //
            // C_LOTKEY
            //
            this.C_LOTKEY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LOTKEY")});
            this.C_LOTKEY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_LOTKEY.Name = "C_LOTKEY";
            this.C_LOTKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_LOTKEY.StylePriority.UseFont = false;
            this.C_LOTKEY.StylePriority.UsePadding = false;
            this.C_LOTKEY.StylePriority.UseTextAlignment = false;
            this.C_LOTKEY.Text = "";
            this.C_LOTKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_LOTKEY.Weight = 192D;
            //
            // C_UNITNM
            //
            this.C_UNITNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UNITNM")});
            this.C_UNITNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_UNITNM.Name = "C_UNITNM";
            this.C_UNITNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_UNITNM.StylePriority.UseFont = false;
            this.C_UNITNM.StylePriority.UsePadding = false;
            this.C_UNITNM.StylePriority.UseTextAlignment = false;
            this.C_UNITNM.Text = "";
            this.C_UNITNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_UNITNM.Weight = 80D;
            //
            // C_QTY
            //
            this.C_QTY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LOTQTY")});
            this.C_QTY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_QTY.Name = "C_QTY";
            this.C_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_QTY.StylePriority.UseFont = false;
            this.C_QTY.StylePriority.UsePadding = false;
            this.C_QTY.StylePriority.UseTextAlignment = false;
            this.C_QTY.Text = "";
            this.C_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_QTY.Weight = 130D;
            //
            // tbl_TRACE_HEAD (로트추적 머리 - PRD_1 과 같은 표)
            //
            this.tbl_TRACE_HEAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.tbl_TRACE_HEAD.LocationFloat = new DevExpress.Utils.PointFloat(0F, 398F);
            this.tbl_TRACE_HEAD.Name = "tbl_TRACE_HEAD";
            this.tbl_TRACE_HEAD.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tbl_TRACE_HEAD_R1});
            this.tbl_TRACE_HEAD.SizeF = new System.Drawing.SizeF(727.0F, 32F);
            //
            // tbl_TRACE_HEAD_R1
            //
            this.tbl_TRACE_HEAD_R1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_NO,
            this.H_TRACE_ITEMCD,
            this.H_TRACE_LINENM,
            this.H_TRACE_PRCNM,
            this.H_TRACE_LOTKEY});
            this.tbl_TRACE_HEAD_R1.Name = "tbl_TRACE_HEAD_R1";
            this.tbl_TRACE_HEAD_R1.Weight = 1D;
            //
            // H_NO
            //
            this.H_NO.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_NO.Name = "H_NO";
            this.H_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_NO.StylePriority.UseFont = false;
            this.H_NO.StylePriority.UsePadding = false;
            this.H_NO.StylePriority.UseTextAlignment = false;
            this.H_NO.Text = "NO";
            this.H_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_NO.Weight = 55D;
            //
            // H_TRACE_ITEMCD
            //
            this.H_TRACE_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_TRACE_ITEMCD.Name = "H_TRACE_ITEMCD";
            this.H_TRACE_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_TRACE_ITEMCD.StylePriority.UseFont = false;
            this.H_TRACE_ITEMCD.StylePriority.UsePadding = false;
            this.H_TRACE_ITEMCD.StylePriority.UseTextAlignment = false;
            this.H_TRACE_ITEMCD.Text = "품번";
            this.H_TRACE_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_TRACE_ITEMCD.Weight = 210D;
            //
            // H_TRACE_LINENM
            //
            this.H_TRACE_LINENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_TRACE_LINENM.Name = "H_TRACE_LINENM";
            this.H_TRACE_LINENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_TRACE_LINENM.StylePriority.UseFont = false;
            this.H_TRACE_LINENM.StylePriority.UsePadding = false;
            this.H_TRACE_LINENM.StylePriority.UseTextAlignment = false;
            this.H_TRACE_LINENM.Text = "작업장";
            this.H_TRACE_LINENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_TRACE_LINENM.Weight = 150D;
            //
            // H_TRACE_PRCNM
            //
            this.H_TRACE_PRCNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_TRACE_PRCNM.Name = "H_TRACE_PRCNM";
            this.H_TRACE_PRCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_TRACE_PRCNM.StylePriority.UseFont = false;
            this.H_TRACE_PRCNM.StylePriority.UsePadding = false;
            this.H_TRACE_PRCNM.StylePriority.UseTextAlignment = false;
            this.H_TRACE_PRCNM.Text = "공정";
            this.H_TRACE_PRCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_TRACE_PRCNM.Weight = 130D;
            //
            // H_TRACE_LOTKEY
            //
            this.H_TRACE_LOTKEY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_TRACE_LOTKEY.Name = "H_TRACE_LOTKEY";
            this.H_TRACE_LOTKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_TRACE_LOTKEY.StylePriority.UseFont = false;
            this.H_TRACE_LOTKEY.StylePriority.UsePadding = false;
            this.H_TRACE_LOTKEY.StylePriority.UseTextAlignment = false;
            this.H_TRACE_LOTKEY.Text = "LOTNO";
            this.H_TRACE_LOTKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_TRACE_LOTKEY.Weight = 182D;
            //
            // tbl_TRACE (로트추적 줄 - 재고는 이 LOT 1줄. 작업장·공정은 빈칸)
            //
            this.tbl_TRACE.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tbl_TRACE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 430F);
            this.tbl_TRACE.Name = "tbl_TRACE";
            this.tbl_TRACE.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tbl_TRACE_R1});
            this.tbl_TRACE.SizeF = new System.Drawing.SizeF(727.0F, 32F);
            //
            // tbl_TRACE_R1
            //
            this.tbl_TRACE_R1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.D_NO,
            this.D_ITEMCD,
            this.D_LINENM,
            this.D_PRCNM,
            this.D_LOTKEY});
            this.tbl_TRACE_R1.Name = "tbl_TRACE_R1";
            this.tbl_TRACE_R1.Weight = 1D;
            //
            // D_NO
            //
            this.D_NO.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.D_NO.Name = "D_NO";
            this.D_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.D_NO.StylePriority.UseFont = false;
            this.D_NO.StylePriority.UsePadding = false;
            this.D_NO.StylePriority.UseTextAlignment = false;
            this.D_NO.Text = "1";
            this.D_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_NO.Weight = 55D;
            //
            // D_ITEMCD
            //
            this.D_ITEMCD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMCD")});
            this.D_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.D_ITEMCD.Name = "D_ITEMCD";
            this.D_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.D_ITEMCD.StylePriority.UseFont = false;
            this.D_ITEMCD.StylePriority.UsePadding = false;
            this.D_ITEMCD.StylePriority.UseTextAlignment = false;
            this.D_ITEMCD.Text = "";
            this.D_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_ITEMCD.Weight = 210D;
            //
            // D_LINENM
            //
            this.D_LINENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.D_LINENM.Name = "D_LINENM";
            this.D_LINENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.D_LINENM.StylePriority.UseFont = false;
            this.D_LINENM.StylePriority.UsePadding = false;
            this.D_LINENM.StylePriority.UseTextAlignment = false;
            this.D_LINENM.Text = "";
            this.D_LINENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_LINENM.Weight = 150D;
            //
            // D_PRCNM
            //
            this.D_PRCNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.D_PRCNM.Name = "D_PRCNM";
            this.D_PRCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.D_PRCNM.StylePriority.UseFont = false;
            this.D_PRCNM.StylePriority.UsePadding = false;
            this.D_PRCNM.StylePriority.UseTextAlignment = false;
            this.D_PRCNM.Text = "";
            this.D_PRCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_PRCNM.Weight = 130D;
            //
            // D_LOTKEY
            //
            this.D_LOTKEY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LOTKEY")});
            this.D_LOTKEY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.D_LOTKEY.Name = "D_LOTKEY";
            this.D_LOTKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.D_LOTKEY.StylePriority.UseFont = false;
            this.D_LOTKEY.StylePriority.UsePadding = false;
            this.D_LOTKEY.StylePriority.UseTextAlignment = false;
            this.D_LOTKEY.Text = "";
            this.D_LOTKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_LOTKEY.Weight = 182D;
            //
            // BottomMargin
            //
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            //
            // MTR_2
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.Detail,
            this.BottomMargin});
            this.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.tbl_HEAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_LOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_TRACE_HEAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_TRACE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel lbl_TITLE;
        private DevExpress.XtraReports.UI.XRBarCode bar_LOTKEY;
        private DevExpress.XtraReports.UI.XRTable tbl_HEAD;
        private DevExpress.XtraReports.UI.XRTable tbl_LOT;
        private DevExpress.XtraReports.UI.XRTable tbl_TRACE_HEAD;
        private DevExpress.XtraReports.UI.XRTable tbl_TRACE;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTableRow tbl_HEAD_R1;
        private DevExpress.XtraReports.UI.XRTableCell H_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell C_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell H_HEATNO;
        private DevExpress.XtraReports.UI.XRTableCell C_HEATNO;
        private DevExpress.XtraReports.UI.XRTableRow tbl_HEAD_R2;
        private DevExpress.XtraReports.UI.XRTableCell H_ITEMNM;
        private DevExpress.XtraReports.UI.XRTableCell C_ITEMNM;
        private DevExpress.XtraReports.UI.XRTableCell H_EMPNM;
        private DevExpress.XtraReports.UI.XRTableCell C_EMPNM;
        private DevExpress.XtraReports.UI.XRTableRow tbl_HEAD_R3;
        private DevExpress.XtraReports.UI.XRTableCell H_ITEMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell C_ITEMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell H_PRINTDATE;
        private DevExpress.XtraReports.UI.XRTableCell C_PRINTDATE;
        private DevExpress.XtraReports.UI.XRTableRow tbl_LOT_R1;
        private DevExpress.XtraReports.UI.XRTableCell H_LINENM;
        private DevExpress.XtraReports.UI.XRTableCell H_PRCNM;
        private DevExpress.XtraReports.UI.XRTableCell H_EQMNM;
        private DevExpress.XtraReports.UI.XRTableCell H_LOTKEY;
        private DevExpress.XtraReports.UI.XRTableCell H_UNITNM;
        private DevExpress.XtraReports.UI.XRTableCell H_QTY;
        private DevExpress.XtraReports.UI.XRTableRow tbl_LOT_R2;
        private DevExpress.XtraReports.UI.XRTableCell C_LINENM;
        private DevExpress.XtraReports.UI.XRTableCell C_PRCNM;
        private DevExpress.XtraReports.UI.XRTableCell C_EQMNM;
        private DevExpress.XtraReports.UI.XRTableCell C_LOTKEY;
        private DevExpress.XtraReports.UI.XRTableCell C_UNITNM;
        private DevExpress.XtraReports.UI.XRTableCell C_QTY;
        private DevExpress.XtraReports.UI.XRTableRow tbl_TRACE_HEAD_R1;
        private DevExpress.XtraReports.UI.XRTableCell H_NO;
        private DevExpress.XtraReports.UI.XRTableCell H_TRACE_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell H_TRACE_LINENM;
        private DevExpress.XtraReports.UI.XRTableCell H_TRACE_PRCNM;
        private DevExpress.XtraReports.UI.XRTableCell H_TRACE_LOTKEY;
        private DevExpress.XtraReports.UI.XRTableRow tbl_TRACE_R1;
        private DevExpress.XtraReports.UI.XRTableCell D_NO;
        private DevExpress.XtraReports.UI.XRTableCell D_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell D_LINENM;
        private DevExpress.XtraReports.UI.XRTableCell D_PRCNM;
        private DevExpress.XtraReports.UI.XRTableCell D_LOTKEY;
    }
}
