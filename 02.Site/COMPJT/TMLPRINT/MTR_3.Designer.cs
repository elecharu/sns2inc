namespace TMLPRINT
{
    partial class MTR_3
    {
        /// <summary>
        /// // 2026-11-19 PRD_1(생산실적 공정이동표)·MTR_2 와 같은 양식 (A4 세로, 여백 50, 11pt 굵게). 외주입고 LOT 1개당 1장(양품·시편)
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
            this.H_INDATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_INDATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_HEAD_R3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_ITEMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_ITEMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_EMPNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_EMPNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_HEAD_R4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_OUTWARENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_OUTWARENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_INWARENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_INWARENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_LOT_R1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_LOTKEY = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_UNITNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_QTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_REGTIME = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_LOT_R2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.C_LOTKEY = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_UNITNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_QTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.C_REGTIME = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_TRACE_HEAD_R1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.H_NO = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_TRACE_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_TRACE_OUTWARENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_TRACE_INWARENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_TRACE_LOTKEY = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_TRACE_R1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.D_NO = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_OUTWARENM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_INWARENM = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.Detail.HeightF = 520F;
            this.Detail.Name = "Detail";
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry;
            //
            // lbl_TITLE ("공 정 이 동 표 ( 재 고 )")
            //
            this.lbl_TITLE.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lbl_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 15F);
            this.lbl_TITLE.Name = "lbl_TITLE";
            this.lbl_TITLE.SizeF = new System.Drawing.SizeF(727F, 60F);
            this.lbl_TITLE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TITLE")});
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
            this.tbl_HEAD_R3,
            this.tbl_HEAD_R4});
            this.tbl_HEAD.SizeF = new System.Drawing.SizeF(727.0F, 144F);
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
            this.H_INDATE,
            this.C_INDATE});
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
            // H_INDATE
            //
            this.H_INDATE.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_INDATE.Name = "H_INDATE";
            this.H_INDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_INDATE.StylePriority.UseFont = false;
            this.H_INDATE.StylePriority.UsePadding = false;
            this.H_INDATE.StylePriority.UseTextAlignment = false;
            this.H_INDATE.Text = "입고일자";
            this.H_INDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_INDATE.Weight = 140D;
            //
            // C_INDATE
            //
            this.C_INDATE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "INDATE")});
            this.C_INDATE.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_INDATE.Name = "C_INDATE";
            this.C_INDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_INDATE.StylePriority.UseFont = false;
            this.C_INDATE.StylePriority.UsePadding = false;
            this.C_INDATE.StylePriority.UseTextAlignment = false;
            this.C_INDATE.Text = "";
            this.C_INDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_INDATE.Weight = 227D;
            //
            // tbl_HEAD_R3
            //
            this.tbl_HEAD_R3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_ITEMSPEC,
            this.C_ITEMSPEC,
            this.H_EMPNM,
            this.C_EMPNM});
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
            // H_EMPNM
            //
            this.H_EMPNM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_EMPNM.Name = "H_EMPNM";
            this.H_EMPNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_EMPNM.StylePriority.UseFont = false;
            this.H_EMPNM.StylePriority.UsePadding = false;
            this.H_EMPNM.StylePriority.UseTextAlignment = false;
            this.H_EMPNM.Text = "등록자";
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
            // tbl_HEAD_R4
            //
            this.tbl_HEAD_R4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_OUTWARENM,
            this.C_OUTWARENM,
            this.H_INWARENM,
            this.C_INWARENM});
            this.tbl_HEAD_R4.Name = "tbl_HEAD_R4";
            this.tbl_HEAD_R4.Weight = 1D;
            //
            // H_OUTWARENM
            //
            this.H_OUTWARENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_OUTWARENM.Name = "H_OUTWARENM";
            this.H_OUTWARENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_OUTWARENM.StylePriority.UseFont = false;
            this.H_OUTWARENM.StylePriority.UsePadding = false;
            this.H_OUTWARENM.StylePriority.UseTextAlignment = false;
            this.H_OUTWARENM.Text = "출고창고";
            this.H_OUTWARENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_OUTWARENM.Weight = 100D;
            //
            // C_OUTWARENM
            //
            this.C_OUTWARENM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OUTWARENM")});
            this.C_OUTWARENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_OUTWARENM.Name = "C_OUTWARENM";
            this.C_OUTWARENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_OUTWARENM.StylePriority.UseFont = false;
            this.C_OUTWARENM.StylePriority.UsePadding = false;
            this.C_OUTWARENM.StylePriority.UseTextAlignment = false;
            this.C_OUTWARENM.Text = "";
            this.C_OUTWARENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_OUTWARENM.Weight = 260D;
            //
            // H_INWARENM
            //
            this.H_INWARENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_INWARENM.Name = "H_INWARENM";
            this.H_INWARENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_INWARENM.StylePriority.UseFont = false;
            this.H_INWARENM.StylePriority.UsePadding = false;
            this.H_INWARENM.StylePriority.UseTextAlignment = false;
            this.H_INWARENM.Text = "입고창고";
            this.H_INWARENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_INWARENM.Weight = 140D;
            //
            // C_INWARENM
            //
            this.C_INWARENM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "INWARENM")});
            this.C_INWARENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_INWARENM.Name = "C_INWARENM";
            this.C_INWARENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_INWARENM.StylePriority.UseFont = false;
            this.C_INWARENM.StylePriority.UsePadding = false;
            this.C_INWARENM.StylePriority.UseTextAlignment = false;
            this.C_INWARENM.Text = "";
            this.C_INWARENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_INWARENM.Weight = 227D;
            //
            // bar_LOTKEY (LOT 바코드)
            //
            this.bar_LOTKEY.AutoModule = true;
            this.bar_LOTKEY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LOTKEY")});
            this.bar_LOTKEY.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.bar_LOTKEY.LocationFloat = new DevExpress.Utils.PointFloat(213F, 254F);
            this.bar_LOTKEY.Name = "bar_LOTKEY";
            this.bar_LOTKEY.SizeF = new System.Drawing.SizeF(300F, 65F);
            this.bar_LOTKEY.Symbology = code128Generator1;
            this.bar_LOTKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            //
            // tbl_LOT (로트정보 : LOT NO, 단위, 입고수량, 등록일시)
            //
            this.tbl_LOT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.tbl_LOT.LocationFloat = new DevExpress.Utils.PointFloat(0F, 334F);
            this.tbl_LOT.Name = "tbl_LOT";
            this.tbl_LOT.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tbl_LOT_R1,
            this.tbl_LOT_R2});
            this.tbl_LOT.SizeF = new System.Drawing.SizeF(727.0F, 80F);
            //
            // tbl_LOT_R1
            //
            this.tbl_LOT_R1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_LOTKEY,
            this.H_UNITNM,
            this.H_QTY,
            this.H_REGTIME});
            this.tbl_LOT_R1.Name = "tbl_LOT_R1";
            this.tbl_LOT_R1.Weight = 1D;
            //
            // H_LOTKEY
            //
            this.H_LOTKEY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_LOTKEY.Name = "H_LOTKEY";
            this.H_LOTKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_LOTKEY.StylePriority.UseFont = false;
            this.H_LOTKEY.StylePriority.UsePadding = false;
            this.H_LOTKEY.StylePriority.UseTextAlignment = false;
            this.H_LOTKEY.Text = "LOT NO";
            this.H_LOTKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_LOTKEY.Weight = 267D;
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
            this.H_UNITNM.Weight = 100D;
            //
            // H_QTY
            //
            this.H_QTY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_QTY.Name = "H_QTY";
            this.H_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_QTY.StylePriority.UseFont = false;
            this.H_QTY.StylePriority.UsePadding = false;
            this.H_QTY.StylePriority.UseTextAlignment = false;
            this.H_QTY.Text = "입고수량";
            this.H_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_QTY.Weight = 170D;
            //
            // H_REGTIME
            //
            this.H_REGTIME.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_REGTIME.Name = "H_REGTIME";
            this.H_REGTIME.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_REGTIME.StylePriority.UseFont = false;
            this.H_REGTIME.StylePriority.UsePadding = false;
            this.H_REGTIME.StylePriority.UseTextAlignment = false;
            this.H_REGTIME.Text = "등록일시";
            this.H_REGTIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_REGTIME.Weight = 190D;
            //
            // tbl_LOT_R2
            //
            this.tbl_LOT_R2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.C_LOTKEY,
            this.C_UNITNM,
            this.C_QTY,
            this.C_REGTIME});
            this.tbl_LOT_R2.Name = "tbl_LOT_R2";
            this.tbl_LOT_R2.Weight = 1D;
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
            this.C_LOTKEY.Weight = 267D;
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
            this.C_UNITNM.Weight = 100D;
            //
            // C_QTY
            //
            this.C_QTY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "QTY")});
            this.C_QTY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_QTY.Name = "C_QTY";
            this.C_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_QTY.StylePriority.UseFont = false;
            this.C_QTY.StylePriority.UsePadding = false;
            this.C_QTY.StylePriority.UseTextAlignment = false;
            this.C_QTY.Text = "";
            this.C_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_QTY.Weight = 170D;
            //
            // C_REGTIME
            //
            this.C_REGTIME.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "REGTIME")});
            this.C_REGTIME.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.C_REGTIME.Name = "C_REGTIME";
            this.C_REGTIME.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.C_REGTIME.StylePriority.UseFont = false;
            this.C_REGTIME.StylePriority.UsePadding = false;
            this.C_REGTIME.StylePriority.UseTextAlignment = false;
            this.C_REGTIME.Text = "";
            this.C_REGTIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_REGTIME.Weight = 190D;
            //
            // tbl_TRACE_HEAD (로트추적 머리 - PRD_1 과 같은 표)
            //
            this.tbl_TRACE_HEAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.tbl_TRACE_HEAD.LocationFloat = new DevExpress.Utils.PointFloat(0F, 434F);
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
            this.H_TRACE_OUTWARENM,
            this.H_TRACE_INWARENM,
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
            // H_TRACE_OUTWARENM
            //
            this.H_TRACE_OUTWARENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_TRACE_OUTWARENM.Name = "H_TRACE_OUTWARENM";
            this.H_TRACE_OUTWARENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_TRACE_OUTWARENM.StylePriority.UseFont = false;
            this.H_TRACE_OUTWARENM.StylePriority.UsePadding = false;
            this.H_TRACE_OUTWARENM.StylePriority.UseTextAlignment = false;
            this.H_TRACE_OUTWARENM.Text = "출고창고";
            this.H_TRACE_OUTWARENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_TRACE_OUTWARENM.Weight = 150D;
            //
            // H_TRACE_INWARENM
            //
            this.H_TRACE_INWARENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.H_TRACE_INWARENM.Name = "H_TRACE_INWARENM";
            this.H_TRACE_INWARENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.H_TRACE_INWARENM.StylePriority.UseFont = false;
            this.H_TRACE_INWARENM.StylePriority.UsePadding = false;
            this.H_TRACE_INWARENM.StylePriority.UseTextAlignment = false;
            this.H_TRACE_INWARENM.Text = "입고창고";
            this.H_TRACE_INWARENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_TRACE_INWARENM.Weight = 130D;
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
            // tbl_TRACE (로트추적 줄 - 입고는 이 LOT 1줄: 출고창고 → 입고창고)
            //
            this.tbl_TRACE.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tbl_TRACE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 466F);
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
            this.D_OUTWARENM,
            this.D_INWARENM,
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
            // D_OUTWARENM
            //
            this.D_OUTWARENM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OUTWARENM")});
            this.D_OUTWARENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.D_OUTWARENM.Name = "D_OUTWARENM";
            this.D_OUTWARENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.D_OUTWARENM.StylePriority.UseFont = false;
            this.D_OUTWARENM.StylePriority.UsePadding = false;
            this.D_OUTWARENM.StylePriority.UseTextAlignment = false;
            this.D_OUTWARENM.Text = "";
            this.D_OUTWARENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_OUTWARENM.Weight = 150D;
            //
            // D_INWARENM
            //
            this.D_INWARENM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "INWARENM")});
            this.D_INWARENM.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.D_INWARENM.Name = "D_INWARENM";
            this.D_INWARENM.Padding = new DevExpress.XtraPrinting.PaddingInfo(8, 8, 0, 0, 100F);
            this.D_INWARENM.StylePriority.UseFont = false;
            this.D_INWARENM.StylePriority.UsePadding = false;
            this.D_INWARENM.StylePriority.UseTextAlignment = false;
            this.D_INWARENM.Text = "";
            this.D_INWARENM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_INWARENM.Weight = 130D;
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
            // MTR_3
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
        private DevExpress.XtraReports.UI.XRTableCell H_INDATE;
        private DevExpress.XtraReports.UI.XRTableCell C_INDATE;
        private DevExpress.XtraReports.UI.XRTableRow tbl_HEAD_R3;
        private DevExpress.XtraReports.UI.XRTableCell H_ITEMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell C_ITEMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell H_EMPNM;
        private DevExpress.XtraReports.UI.XRTableCell C_EMPNM;
        private DevExpress.XtraReports.UI.XRTableRow tbl_HEAD_R4;
        private DevExpress.XtraReports.UI.XRTableCell H_OUTWARENM;
        private DevExpress.XtraReports.UI.XRTableCell C_OUTWARENM;
        private DevExpress.XtraReports.UI.XRTableCell H_INWARENM;
        private DevExpress.XtraReports.UI.XRTableCell C_INWARENM;
        private DevExpress.XtraReports.UI.XRTableRow tbl_LOT_R1;
        private DevExpress.XtraReports.UI.XRTableCell H_LOTKEY;
        private DevExpress.XtraReports.UI.XRTableCell H_UNITNM;
        private DevExpress.XtraReports.UI.XRTableCell H_QTY;
        private DevExpress.XtraReports.UI.XRTableCell H_REGTIME;
        private DevExpress.XtraReports.UI.XRTableRow tbl_LOT_R2;
        private DevExpress.XtraReports.UI.XRTableCell C_LOTKEY;
        private DevExpress.XtraReports.UI.XRTableCell C_UNITNM;
        private DevExpress.XtraReports.UI.XRTableCell C_QTY;
        private DevExpress.XtraReports.UI.XRTableCell C_REGTIME;
        private DevExpress.XtraReports.UI.XRTableRow tbl_TRACE_HEAD_R1;
        private DevExpress.XtraReports.UI.XRTableCell H_NO;
        private DevExpress.XtraReports.UI.XRTableCell H_TRACE_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell H_TRACE_OUTWARENM;
        private DevExpress.XtraReports.UI.XRTableCell H_TRACE_INWARENM;
        private DevExpress.XtraReports.UI.XRTableCell H_TRACE_LOTKEY;
        private DevExpress.XtraReports.UI.XRTableRow tbl_TRACE_R1;
        private DevExpress.XtraReports.UI.XRTableCell D_NO;
        private DevExpress.XtraReports.UI.XRTableCell D_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell D_OUTWARENM;
        private DevExpress.XtraReports.UI.XRTableCell D_INWARENM;
        private DevExpress.XtraReports.UI.XRTableCell D_LOTKEY;
    }
}
