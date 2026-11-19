namespace XtraRpt
{
    partial class S03
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        // 일일 마감 (생산관리팀 "일일 마감 (2공장 - 외부 재고출고나 이동이력 조회)" 양식). A4 가로.
        // 1장 = ReportHeader(제목·조회기간·결재란), 2장부터 = PageHeader(제목만). 머리글 GH1 은 장마다 반복
        // 줄 칸 D_{컬럼명}, 머리글 H_{컬럼명}, 합계 F_{컬럼명} (F_QTY = 수량 합계)
        private void InitializeComponent()
        {
            this.C_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_PERIOD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SIGN = new DevExpress.XtraReports.UI.XRLabel();
            this.S_11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.S_12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.S_13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.S_21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.S_22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.S_23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.S_31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.S_32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.S_33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.T_SIGN = new DevExpress.XtraReports.UI.XRTable();
            this.R_SIGN1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.R_SIGN2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.R_SIGN3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.C_TITLE2 = new DevExpress.XtraReports.UI.XRLabel();
            this.H_GUBUN = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_IODATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_CUSTNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_DOCNO = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_ITEMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_ITEMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.H_QTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.T_HEAD = new DevExpress.XtraReports.UI.XRTable();
            this.R_HEAD = new DevExpress.XtraReports.UI.XRTableRow();
            this.D_GUBUN = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_IODATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_CUSTNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_DOCNO = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_ITEMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_ITEMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.D_QTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.T_ROW = new DevExpress.XtraReports.UI.XRTable();
            this.R_ROW = new DevExpress.XtraReports.UI.XRTableRow();
            this.F_GUBUN = new DevExpress.XtraReports.UI.XRTableCell();
            this.F_IODATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.F_CUSTNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.F_DOCNO = new DevExpress.XtraReports.UI.XRTableCell();
            this.F_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.F_ITEMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.F_ITEMSPEC = new DevExpress.XtraReports.UI.XRTableCell();
            this.F_QTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.T_SUM = new DevExpress.XtraReports.UI.XRTable();
            this.R_SUM = new DevExpress.XtraReports.UI.XRTableRow();
            this.C_PAGE = new DevExpress.XtraReports.UI.XRPageInfo();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GH1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.T_SIGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_HEAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_ROW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_SUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // C_TITLE
            //
            this.C_TITLE.CanGrow = false;
            this.C_TITLE.Dpi = 100F;
            this.C_TITLE.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.C_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(300F, 2F);
            this.C_TITLE.Multiline = false;
            this.C_TITLE.Name = "C_TITLE";
            this.C_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_TITLE.SizeF = new System.Drawing.SizeF(529F, 38F);
            this.C_TITLE.Text = "일일 마감";
            this.C_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_TITLE.WordWrap = false;
            //
            // C_PERIOD
            //
            this.C_PERIOD.CanGrow = false;
            this.C_PERIOD.Dpi = 100F;
            this.C_PERIOD.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_PERIOD.LocationFloat = new DevExpress.Utils.PointFloat(300F, 40F);
            this.C_PERIOD.Multiline = false;
            this.C_PERIOD.Name = "C_PERIOD";
            this.C_PERIOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_PERIOD.SizeF = new System.Drawing.SizeF(529F, 18F);
            this.C_PERIOD.Text = "조회기간:";
            this.C_PERIOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_PERIOD.WordWrap = false;
            //
            // L_SIGN
            //
            this.L_SIGN.BorderColor = System.Drawing.Color.Black;
            this.L_SIGN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_SIGN.BorderWidth = 0.5F;
            this.L_SIGN.CanGrow = false;
            this.L_SIGN.Dpi = 100F;
            this.L_SIGN.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_SIGN.LocationFloat = new DevExpress.Utils.PointFloat(909F, 0F);
            this.L_SIGN.Multiline = true;
            this.L_SIGN.Name = "L_SIGN";
            this.L_SIGN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_SIGN.SizeF = new System.Drawing.SizeF(20F, 78F);
            this.L_SIGN.Text = "결\r\n재\r\n란";
            this.L_SIGN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_SIGN.WordWrap = true;
            // 
            // S_11
            // 
            this.S_11.BorderColor = System.Drawing.Color.Black;
            this.S_11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_11.BorderWidth = 0.5F;
            this.S_11.CanGrow = false;
            this.S_11.Dpi = 100F;
            this.S_11.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_11.Name = "S_11";
            this.S_11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_11.Text = "작성";
            this.S_11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_11.Weight = 60D;
            this.S_11.WordWrap = false;
            // 
            // S_12
            // 
            this.S_12.BorderColor = System.Drawing.Color.Black;
            this.S_12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_12.BorderWidth = 0.5F;
            this.S_12.CanGrow = false;
            this.S_12.Dpi = 100F;
            this.S_12.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_12.Name = "S_12";
            this.S_12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_12.Text = "검토";
            this.S_12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_12.Weight = 60D;
            this.S_12.WordWrap = false;
            // 
            // S_13
            // 
            this.S_13.BorderColor = System.Drawing.Color.Black;
            this.S_13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_13.BorderWidth = 0.5F;
            this.S_13.CanGrow = false;
            this.S_13.Dpi = 100F;
            this.S_13.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_13.Name = "S_13";
            this.S_13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_13.Text = "승인";
            this.S_13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_13.Weight = 60D;
            this.S_13.WordWrap = false;
            // 
            // S_21
            // 
            this.S_21.BorderColor = System.Drawing.Color.Black;
            this.S_21.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_21.BorderWidth = 0.5F;
            this.S_21.CanGrow = false;
            this.S_21.Dpi = 100F;
            this.S_21.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_21.Name = "S_21";
            this.S_21.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_21.Text = "";
            this.S_21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_21.Weight = 60D;
            this.S_21.WordWrap = false;
            // 
            // S_22
            // 
            this.S_22.BorderColor = System.Drawing.Color.Black;
            this.S_22.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_22.BorderWidth = 0.5F;
            this.S_22.CanGrow = false;
            this.S_22.Dpi = 100F;
            this.S_22.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_22.Name = "S_22";
            this.S_22.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_22.Text = "";
            this.S_22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_22.Weight = 60D;
            this.S_22.WordWrap = false;
            // 
            // S_23
            // 
            this.S_23.BorderColor = System.Drawing.Color.Black;
            this.S_23.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_23.BorderWidth = 0.5F;
            this.S_23.CanGrow = false;
            this.S_23.Dpi = 100F;
            this.S_23.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_23.Name = "S_23";
            this.S_23.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_23.Text = "";
            this.S_23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_23.Weight = 60D;
            this.S_23.WordWrap = false;
            // 
            // S_31
            // 
            this.S_31.BorderColor = System.Drawing.Color.Black;
            this.S_31.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_31.BorderWidth = 0.5F;
            this.S_31.CanGrow = false;
            this.S_31.Dpi = 100F;
            this.S_31.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_31.Name = "S_31";
            this.S_31.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_31.Text = "";
            this.S_31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_31.Weight = 60D;
            this.S_31.WordWrap = false;
            // 
            // S_32
            // 
            this.S_32.BorderColor = System.Drawing.Color.Black;
            this.S_32.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_32.BorderWidth = 0.5F;
            this.S_32.CanGrow = false;
            this.S_32.Dpi = 100F;
            this.S_32.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_32.Name = "S_32";
            this.S_32.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_32.Text = "";
            this.S_32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_32.Weight = 60D;
            this.S_32.WordWrap = false;
            // 
            // S_33
            // 
            this.S_33.BorderColor = System.Drawing.Color.Black;
            this.S_33.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.S_33.BorderWidth = 0.5F;
            this.S_33.CanGrow = false;
            this.S_33.Dpi = 100F;
            this.S_33.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.S_33.Name = "S_33";
            this.S_33.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.S_33.Text = "";
            this.S_33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.S_33.Weight = 60D;
            this.S_33.WordWrap = false;
            //
            // R_SIGN1
            //
            this.R_SIGN1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.S_11,
            this.S_12,
            this.S_13});
            this.R_SIGN1.Dpi = 100F;
            this.R_SIGN1.Name = "R_SIGN1";
            this.R_SIGN1.Weight = 16D;
            //
            // R_SIGN2
            //
            this.R_SIGN2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.S_21,
            this.S_22,
            this.S_23});
            this.R_SIGN2.Dpi = 100F;
            this.R_SIGN2.Name = "R_SIGN2";
            this.R_SIGN2.Weight = 48D;
            //
            // R_SIGN3
            //
            this.R_SIGN3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.S_31,
            this.S_32,
            this.S_33});
            this.R_SIGN3.Dpi = 100F;
            this.R_SIGN3.Name = "R_SIGN3";
            this.R_SIGN3.Weight = 14D;
            //
            // T_SIGN
            //
            this.T_SIGN.Dpi = 100F;
            this.T_SIGN.LocationFloat = new DevExpress.Utils.PointFloat(929F, 0F);
            this.T_SIGN.Name = "T_SIGN";
            this.T_SIGN.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.R_SIGN1,
            this.R_SIGN2,
            this.R_SIGN3});
            this.T_SIGN.SizeF = new System.Drawing.SizeF(180F, 78F);
            //
            // C_TITLE2
            //
            this.C_TITLE2.CanGrow = false;
            this.C_TITLE2.Dpi = 100F;
            this.C_TITLE2.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.C_TITLE2.LocationFloat = new DevExpress.Utils.PointFloat(300F, 2F);
            this.C_TITLE2.Multiline = false;
            this.C_TITLE2.Name = "C_TITLE2";
            this.C_TITLE2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_TITLE2.SizeF = new System.Drawing.SizeF(529F, 38F);
            this.C_TITLE2.Text = "일일 마감";
            this.C_TITLE2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_TITLE2.WordWrap = false;
            // 
            // H_GUBUN
            // 
            this.H_GUBUN.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.H_GUBUN.BorderColor = System.Drawing.Color.Black;
            this.H_GUBUN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H_GUBUN.BorderWidth = 0.5F;
            this.H_GUBUN.CanGrow = false;
            this.H_GUBUN.Dpi = 100F;
            this.H_GUBUN.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.H_GUBUN.Name = "H_GUBUN";
            this.H_GUBUN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H_GUBUN.StylePriority.UseBackColor = false;
            this.H_GUBUN.Text = "구분";
            this.H_GUBUN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_GUBUN.Weight = 90D;
            this.H_GUBUN.WordWrap = false;
            // 
            // H_IODATE
            // 
            this.H_IODATE.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.H_IODATE.BorderColor = System.Drawing.Color.Black;
            this.H_IODATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H_IODATE.BorderWidth = 0.5F;
            this.H_IODATE.CanGrow = false;
            this.H_IODATE.Dpi = 100F;
            this.H_IODATE.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.H_IODATE.Name = "H_IODATE";
            this.H_IODATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H_IODATE.StylePriority.UseBackColor = false;
            this.H_IODATE.Text = "일자";
            this.H_IODATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_IODATE.Weight = 100D;
            this.H_IODATE.WordWrap = false;
            // 
            // H_CUSTNM
            // 
            this.H_CUSTNM.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.H_CUSTNM.BorderColor = System.Drawing.Color.Black;
            this.H_CUSTNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H_CUSTNM.BorderWidth = 0.5F;
            this.H_CUSTNM.CanGrow = false;
            this.H_CUSTNM.Dpi = 100F;
            this.H_CUSTNM.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.H_CUSTNM.Name = "H_CUSTNM";
            this.H_CUSTNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H_CUSTNM.StylePriority.UseBackColor = false;
            this.H_CUSTNM.Text = "거래처명";
            this.H_CUSTNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_CUSTNM.Weight = 164D;
            this.H_CUSTNM.WordWrap = false;
            // 
            // H_DOCNO
            // 
            this.H_DOCNO.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.H_DOCNO.BorderColor = System.Drawing.Color.Black;
            this.H_DOCNO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H_DOCNO.BorderWidth = 0.5F;
            this.H_DOCNO.CanGrow = false;
            this.H_DOCNO.Dpi = 100F;
            this.H_DOCNO.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.H_DOCNO.Name = "H_DOCNO";
            this.H_DOCNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H_DOCNO.StylePriority.UseBackColor = false;
            this.H_DOCNO.Text = "명세서번호";
            this.H_DOCNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_DOCNO.Weight = 111D;
            this.H_DOCNO.WordWrap = false;
            // 
            // H_ITEMCD
            // 
            this.H_ITEMCD.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.H_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.H_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H_ITEMCD.BorderWidth = 0.5F;
            this.H_ITEMCD.CanGrow = false;
            this.H_ITEMCD.Dpi = 100F;
            this.H_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.H_ITEMCD.Name = "H_ITEMCD";
            this.H_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H_ITEMCD.StylePriority.UseBackColor = false;
            this.H_ITEMCD.Text = "품목코드";
            this.H_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_ITEMCD.Weight = 122D;
            this.H_ITEMCD.WordWrap = false;
            // 
            // H_ITEMNM
            // 
            this.H_ITEMNM.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.H_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.H_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H_ITEMNM.BorderWidth = 0.5F;
            this.H_ITEMNM.CanGrow = false;
            this.H_ITEMNM.Dpi = 100F;
            this.H_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.H_ITEMNM.Name = "H_ITEMNM";
            this.H_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H_ITEMNM.StylePriority.UseBackColor = false;
            this.H_ITEMNM.Text = "품목명";
            this.H_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_ITEMNM.Weight = 268D;
            this.H_ITEMNM.WordWrap = false;
            // 
            // H_ITEMSPEC
            // 
            this.H_ITEMSPEC.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.H_ITEMSPEC.BorderColor = System.Drawing.Color.Black;
            this.H_ITEMSPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H_ITEMSPEC.BorderWidth = 0.5F;
            this.H_ITEMSPEC.CanGrow = false;
            this.H_ITEMSPEC.Dpi = 100F;
            this.H_ITEMSPEC.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.H_ITEMSPEC.Name = "H_ITEMSPEC";
            this.H_ITEMSPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H_ITEMSPEC.StylePriority.UseBackColor = false;
            this.H_ITEMSPEC.Text = "규격";
            this.H_ITEMSPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_ITEMSPEC.Weight = 154D;
            this.H_ITEMSPEC.WordWrap = false;
            // 
            // H_QTY
            // 
            this.H_QTY.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.H_QTY.BorderColor = System.Drawing.Color.Black;
            this.H_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H_QTY.BorderWidth = 0.5F;
            this.H_QTY.CanGrow = false;
            this.H_QTY.Dpi = 100F;
            this.H_QTY.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.H_QTY.Name = "H_QTY";
            this.H_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H_QTY.StylePriority.UseBackColor = false;
            this.H_QTY.Text = "수량";
            this.H_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H_QTY.Weight = 120D;
            this.H_QTY.WordWrap = false;
            //
            // R_HEAD
            //
            this.R_HEAD.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.H_GUBUN,
            this.H_IODATE,
            this.H_CUSTNM,
            this.H_DOCNO,
            this.H_ITEMCD,
            this.H_ITEMNM,
            this.H_ITEMSPEC,
            this.H_QTY});
            this.R_HEAD.Dpi = 100F;
            this.R_HEAD.Name = "R_HEAD";
            this.R_HEAD.Weight = 20D;
            //
            // T_HEAD
            //
            this.T_HEAD.Dpi = 100F;
            this.T_HEAD.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.T_HEAD.Name = "T_HEAD";
            this.T_HEAD.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.R_HEAD});
            this.T_HEAD.SizeF = new System.Drawing.SizeF(1129F, 20F);
            // 
            // D_GUBUN
            // 
            this.D_GUBUN.BorderColor = System.Drawing.Color.Black;
            this.D_GUBUN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D_GUBUN.BorderWidth = 0.5F;
            this.D_GUBUN.CanGrow = false;
            this.D_GUBUN.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "GUBUN")});
            this.D_GUBUN.Dpi = 100F;
            this.D_GUBUN.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.D_GUBUN.Name = "D_GUBUN";
            this.D_GUBUN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D_GUBUN.Text = "";
            this.D_GUBUN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_GUBUN.Weight = 90D;
            this.D_GUBUN.WordWrap = false;
            // 
            // D_IODATE
            // 
            this.D_IODATE.BorderColor = System.Drawing.Color.Black;
            this.D_IODATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D_IODATE.BorderWidth = 0.5F;
            this.D_IODATE.CanGrow = false;
            this.D_IODATE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "IODATE")});
            this.D_IODATE.Dpi = 100F;
            this.D_IODATE.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.D_IODATE.Name = "D_IODATE";
            this.D_IODATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D_IODATE.Text = "";
            this.D_IODATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D_IODATE.Weight = 100D;
            this.D_IODATE.WordWrap = false;
            // 
            // D_CUSTNM
            // 
            this.D_CUSTNM.BorderColor = System.Drawing.Color.Black;
            this.D_CUSTNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D_CUSTNM.BorderWidth = 0.5F;
            this.D_CUSTNM.CanGrow = false;
            this.D_CUSTNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CUSTNM")});
            this.D_CUSTNM.Dpi = 100F;
            this.D_CUSTNM.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.D_CUSTNM.Name = "D_CUSTNM";
            this.D_CUSTNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D_CUSTNM.Text = "";
            this.D_CUSTNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D_CUSTNM.Weight = 164D;
            this.D_CUSTNM.WordWrap = false;
            // 
            // D_DOCNO
            // 
            this.D_DOCNO.BorderColor = System.Drawing.Color.Black;
            this.D_DOCNO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D_DOCNO.BorderWidth = 0.5F;
            this.D_DOCNO.CanGrow = false;
            this.D_DOCNO.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DOCNO")});
            this.D_DOCNO.Dpi = 100F;
            this.D_DOCNO.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.D_DOCNO.Name = "D_DOCNO";
            this.D_DOCNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D_DOCNO.Text = "";
            this.D_DOCNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D_DOCNO.Weight = 111D;
            this.D_DOCNO.WordWrap = false;
            // 
            // D_ITEMCD
            // 
            this.D_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.D_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D_ITEMCD.BorderWidth = 0.5F;
            this.D_ITEMCD.CanGrow = false;
            this.D_ITEMCD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMCD")});
            this.D_ITEMCD.Dpi = 100F;
            this.D_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.D_ITEMCD.Name = "D_ITEMCD";
            this.D_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D_ITEMCD.Text = "";
            this.D_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D_ITEMCD.Weight = 122D;
            this.D_ITEMCD.WordWrap = false;
            // 
            // D_ITEMNM
            // 
            this.D_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.D_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D_ITEMNM.BorderWidth = 0.5F;
            this.D_ITEMNM.CanGrow = false;
            this.D_ITEMNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMNM")});
            this.D_ITEMNM.Dpi = 100F;
            this.D_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.D_ITEMNM.Name = "D_ITEMNM";
            this.D_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D_ITEMNM.Text = "";
            this.D_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D_ITEMNM.Weight = 268D;
            this.D_ITEMNM.WordWrap = false;
            // 
            // D_ITEMSPEC
            // 
            this.D_ITEMSPEC.BorderColor = System.Drawing.Color.Black;
            this.D_ITEMSPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D_ITEMSPEC.BorderWidth = 0.5F;
            this.D_ITEMSPEC.CanGrow = false;
            this.D_ITEMSPEC.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMSPEC")});
            this.D_ITEMSPEC.Dpi = 100F;
            this.D_ITEMSPEC.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.D_ITEMSPEC.Name = "D_ITEMSPEC";
            this.D_ITEMSPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D_ITEMSPEC.Text = "";
            this.D_ITEMSPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D_ITEMSPEC.Weight = 154D;
            this.D_ITEMSPEC.WordWrap = false;
            // 
            // D_QTY
            // 
            this.D_QTY.BorderColor = System.Drawing.Color.Black;
            this.D_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D_QTY.BorderWidth = 0.5F;
            this.D_QTY.CanGrow = false;
            this.D_QTY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "QTY", "{0:#,##0}")});
            this.D_QTY.Dpi = 100F;
            this.D_QTY.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.D_QTY.Name = "D_QTY";
            this.D_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D_QTY.Text = "";
            this.D_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D_QTY.Weight = 120D;
            this.D_QTY.WordWrap = false;
            //
            // R_ROW
            //
            this.R_ROW.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.D_GUBUN,
            this.D_IODATE,
            this.D_CUSTNM,
            this.D_DOCNO,
            this.D_ITEMCD,
            this.D_ITEMNM,
            this.D_ITEMSPEC,
            this.D_QTY});
            this.R_ROW.Dpi = 100F;
            this.R_ROW.Name = "R_ROW";
            this.R_ROW.Weight = 20D;
            //
            // T_ROW
            //
            this.T_ROW.Dpi = 100F;
            this.T_ROW.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.T_ROW.Name = "T_ROW";
            this.T_ROW.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.R_ROW});
            this.T_ROW.SizeF = new System.Drawing.SizeF(1129F, 20F);
            // 
            // F_GUBUN
            // 
            this.F_GUBUN.BorderColor = System.Drawing.Color.Black;
            this.F_GUBUN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.F_GUBUN.BorderWidth = 0.5F;
            this.F_GUBUN.CanGrow = false;
            this.F_GUBUN.Dpi = 100F;
            this.F_GUBUN.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.F_GUBUN.Name = "F_GUBUN";
            this.F_GUBUN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.F_GUBUN.Text = "합계";
            this.F_GUBUN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.F_GUBUN.Weight = 90D;
            this.F_GUBUN.WordWrap = false;
            // 
            // F_IODATE
            // 
            this.F_IODATE.BorderColor = System.Drawing.Color.Black;
            this.F_IODATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.F_IODATE.BorderWidth = 0.5F;
            this.F_IODATE.CanGrow = false;
            this.F_IODATE.Dpi = 100F;
            this.F_IODATE.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.F_IODATE.Name = "F_IODATE";
            this.F_IODATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.F_IODATE.Text = "";
            this.F_IODATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.F_IODATE.Weight = 100D;
            this.F_IODATE.WordWrap = false;
            // 
            // F_CUSTNM
            // 
            this.F_CUSTNM.BorderColor = System.Drawing.Color.Black;
            this.F_CUSTNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.F_CUSTNM.BorderWidth = 0.5F;
            this.F_CUSTNM.CanGrow = false;
            this.F_CUSTNM.Dpi = 100F;
            this.F_CUSTNM.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.F_CUSTNM.Name = "F_CUSTNM";
            this.F_CUSTNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.F_CUSTNM.Text = "";
            this.F_CUSTNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.F_CUSTNM.Weight = 164D;
            this.F_CUSTNM.WordWrap = false;
            // 
            // F_DOCNO
            // 
            this.F_DOCNO.BorderColor = System.Drawing.Color.Black;
            this.F_DOCNO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.F_DOCNO.BorderWidth = 0.5F;
            this.F_DOCNO.CanGrow = false;
            this.F_DOCNO.Dpi = 100F;
            this.F_DOCNO.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.F_DOCNO.Name = "F_DOCNO";
            this.F_DOCNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.F_DOCNO.Text = "";
            this.F_DOCNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.F_DOCNO.Weight = 111D;
            this.F_DOCNO.WordWrap = false;
            // 
            // F_ITEMCD
            // 
            this.F_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.F_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.F_ITEMCD.BorderWidth = 0.5F;
            this.F_ITEMCD.CanGrow = false;
            this.F_ITEMCD.Dpi = 100F;
            this.F_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.F_ITEMCD.Name = "F_ITEMCD";
            this.F_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.F_ITEMCD.Text = "";
            this.F_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.F_ITEMCD.Weight = 122D;
            this.F_ITEMCD.WordWrap = false;
            // 
            // F_ITEMNM
            // 
            this.F_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.F_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.F_ITEMNM.BorderWidth = 0.5F;
            this.F_ITEMNM.CanGrow = false;
            this.F_ITEMNM.Dpi = 100F;
            this.F_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.F_ITEMNM.Name = "F_ITEMNM";
            this.F_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.F_ITEMNM.Text = "";
            this.F_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.F_ITEMNM.Weight = 268D;
            this.F_ITEMNM.WordWrap = false;
            // 
            // F_ITEMSPEC
            // 
            this.F_ITEMSPEC.BorderColor = System.Drawing.Color.Black;
            this.F_ITEMSPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.F_ITEMSPEC.BorderWidth = 0.5F;
            this.F_ITEMSPEC.CanGrow = false;
            this.F_ITEMSPEC.Dpi = 100F;
            this.F_ITEMSPEC.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.F_ITEMSPEC.Name = "F_ITEMSPEC";
            this.F_ITEMSPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.F_ITEMSPEC.Text = "";
            this.F_ITEMSPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.F_ITEMSPEC.Weight = 154D;
            this.F_ITEMSPEC.WordWrap = false;
            // 
            // F_QTY
            // 
            this.F_QTY.BorderColor = System.Drawing.Color.Black;
            this.F_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.F_QTY.BorderWidth = 0.5F;
            this.F_QTY.CanGrow = false;
            this.F_QTY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "QTY")});
            this.F_QTY.Dpi = 100F;
            this.F_QTY.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.F_QTY.Name = "F_QTY";
            this.F_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.F_QTY.Summary = new DevExpress.XtraReports.UI.XRSummary(DevExpress.XtraReports.UI.SummaryRunning.Report, DevExpress.XtraReports.UI.SummaryFunc.Sum, "{0:#,##0}");
            this.F_QTY.Text = "";
            this.F_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.F_QTY.Weight = 120D;
            this.F_QTY.WordWrap = false;
            //
            // R_SUM
            //
            this.R_SUM.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.F_GUBUN,
            this.F_IODATE,
            this.F_CUSTNM,
            this.F_DOCNO,
            this.F_ITEMCD,
            this.F_ITEMNM,
            this.F_ITEMSPEC,
            this.F_QTY});
            this.R_SUM.Dpi = 100F;
            this.R_SUM.Name = "R_SUM";
            this.R_SUM.Weight = 20D;
            //
            // T_SUM
            //
            this.T_SUM.Dpi = 100F;
            this.T_SUM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.T_SUM.Name = "T_SUM";
            this.T_SUM.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.R_SUM});
            this.T_SUM.SizeF = new System.Drawing.SizeF(1129F, 20F);
            //
            // C_PAGE
            //
            this.C_PAGE.Dpi = 100F;
            this.C_PAGE.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.C_PAGE.Format = "{0} / {1}";
            this.C_PAGE.LocationFloat = new DevExpress.Utils.PointFloat(514.5F, 2F);
            this.C_PAGE.Name = "C_PAGE";
            this.C_PAGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_PAGE.PageInfo = DevExpress.XtraPrinting.PageInfo.NumberOfTotal;
            this.C_PAGE.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.C_PAGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // TopMargin
            //
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // BottomMargin
            //
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.C_PAGE});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 20F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // ReportHeader
            //
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.C_TITLE,
            this.C_PERIOD,
            this.L_SIGN,
            this.T_SIGN});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 84F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // PageHeader
            //
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.C_TITLE2});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 44F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.PrintOn = DevExpress.XtraReports.UI.PrintOnPages.NotWithReportHeader;
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // GH1
            //
            this.GH1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.T_HEAD});
            this.GH1.Dpi = 100F;
            this.GH1.HeightF = 20F;
            this.GH1.Name = "GH1";
            this.GH1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GH1.RepeatEveryPage = true;
            this.GH1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // Detail
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.T_ROW});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // ReportFooter
            //
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.T_SUM});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 20F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // S03
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GH1,
            this.Detail,
            this.ReportFooter});
            this.Dpi = 100F;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.T_SIGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_HEAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_ROW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_SUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRLabel C_TITLE;
        private DevExpress.XtraReports.UI.XRLabel C_PERIOD;
        private DevExpress.XtraReports.UI.XRLabel L_SIGN;
        private DevExpress.XtraReports.UI.XRTableCell S_11;
        private DevExpress.XtraReports.UI.XRTableCell S_12;
        private DevExpress.XtraReports.UI.XRTableCell S_13;
        private DevExpress.XtraReports.UI.XRTableCell S_21;
        private DevExpress.XtraReports.UI.XRTableCell S_22;
        private DevExpress.XtraReports.UI.XRTableCell S_23;
        private DevExpress.XtraReports.UI.XRTableCell S_31;
        private DevExpress.XtraReports.UI.XRTableCell S_32;
        private DevExpress.XtraReports.UI.XRTableCell S_33;
        private DevExpress.XtraReports.UI.XRTable T_SIGN;
        private DevExpress.XtraReports.UI.XRTableRow R_SIGN1;
        private DevExpress.XtraReports.UI.XRTableRow R_SIGN2;
        private DevExpress.XtraReports.UI.XRTableRow R_SIGN3;
        private DevExpress.XtraReports.UI.XRLabel C_TITLE2;
        private DevExpress.XtraReports.UI.XRTableCell H_GUBUN;
        private DevExpress.XtraReports.UI.XRTableCell H_IODATE;
        private DevExpress.XtraReports.UI.XRTableCell H_CUSTNM;
        private DevExpress.XtraReports.UI.XRTableCell H_DOCNO;
        private DevExpress.XtraReports.UI.XRTableCell H_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell H_ITEMNM;
        private DevExpress.XtraReports.UI.XRTableCell H_ITEMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell H_QTY;
        private DevExpress.XtraReports.UI.XRTable T_HEAD;
        private DevExpress.XtraReports.UI.XRTableRow R_HEAD;
        private DevExpress.XtraReports.UI.XRTableCell D_GUBUN;
        private DevExpress.XtraReports.UI.XRTableCell D_IODATE;
        private DevExpress.XtraReports.UI.XRTableCell D_CUSTNM;
        private DevExpress.XtraReports.UI.XRTableCell D_DOCNO;
        private DevExpress.XtraReports.UI.XRTableCell D_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell D_ITEMNM;
        private DevExpress.XtraReports.UI.XRTableCell D_ITEMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell D_QTY;
        private DevExpress.XtraReports.UI.XRTable T_ROW;
        private DevExpress.XtraReports.UI.XRTableRow R_ROW;
        private DevExpress.XtraReports.UI.XRTableCell F_GUBUN;
        private DevExpress.XtraReports.UI.XRTableCell F_IODATE;
        private DevExpress.XtraReports.UI.XRTableCell F_CUSTNM;
        private DevExpress.XtraReports.UI.XRTableCell F_DOCNO;
        private DevExpress.XtraReports.UI.XRTableCell F_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell F_ITEMNM;
        private DevExpress.XtraReports.UI.XRTableCell F_ITEMSPEC;
        private DevExpress.XtraReports.UI.XRTableCell F_QTY;
        private DevExpress.XtraReports.UI.XRTable T_SUM;
        private DevExpress.XtraReports.UI.XRTableRow R_SUM;
        private DevExpress.XtraReports.UI.XRPageInfo C_PAGE;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GH1;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
    }
}
