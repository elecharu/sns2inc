namespace XtraRpt
{
    partial class S02
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

        // 판매계획대비 출하실적 (생산관리팀 엑셀 양식). A4 가로.
        // 메인 = 리포트 머리 C_TITLE + 표 1~4 (DR1~DR4), 세부내역 = DR5 (새 장에서 시작, 머리글 2줄은 장마다 반복)
        // 표마다 줄 칸 이름은 D{표번호}_{컬럼명}, 머리글은 H{표번호}_{컬럼명}. 줄 색·음수 빨강은 S02.cs 의 Row_BeforePrint
        private void InitializeComponent()
        {
            this.C_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.L_T1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_U1 = new DevExpress.XtraReports.UI.XRLabel();
            this.H1_DEBCNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H1_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H1_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H1_DIFFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H1_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.D1_DEBCNM = new DevExpress.XtraReports.UI.XRLabel();
            this.D1_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D1_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D1_DIFFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D1_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.RH1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.D1 = new DevExpress.XtraReports.UI.DetailBand();
            this.L_T2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_U2 = new DevExpress.XtraReports.UI.XRLabel();
            this.H2_DEBCNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H2_CUSTNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H2_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H2_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H2_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.D2_DEBCNM = new DevExpress.XtraReports.UI.XRLabel();
            this.D2_CUSTNM = new DevExpress.XtraReports.UI.XRLabel();
            this.D2_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D2_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D2_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.RH2 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.D2 = new DevExpress.XtraReports.UI.DetailBand();
            this.L_T3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_U3 = new DevExpress.XtraReports.UI.XRLabel();
            this.H3_OUTCHGNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H3_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H3_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H3_DIFFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D3_OUTCHGNM = new DevExpress.XtraReports.UI.XRLabel();
            this.D3_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D3_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D3_DIFFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.RH3 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.D3 = new DevExpress.XtraReports.UI.DetailBand();
            this.L_T4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_U4 = new DevExpress.XtraReports.UI.XRLabel();
            this.H4_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H4_ADJNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H4_ADJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H4_ADJPLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H4_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H4_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.D4_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D4_ADJNM = new DevExpress.XtraReports.UI.XRLabel();
            this.D4_ADJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D4_ADJPLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D4_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.D4_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.RH4 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.D4 = new DevExpress.XtraReports.UI.DetailBand();
            this.C_DETAIL_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_DEBCNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_CUSTNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_CURYNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_FUP = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_UP = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_G_계획 = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_PLANQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_PLANAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_G_실적 = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_RSTQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_RSTAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_G_차이 = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_DIFFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_DIFFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_OUTCHGNM = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_NOOUTCAUSE = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_MEASURE = new DevExpress.XtraReports.UI.XRLabel();
            this.H5_REMARK = new DevExpress.XtraReports.UI.XRLabel();
            this.D5_DEBCNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_CUSTNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_ITEMNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_ITEMCD = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_CURYNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_FUP = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_UP = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_PLANQTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_PLANAMT = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_RSTQTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_RSTAMT = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_RATE = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_DIFFQTY = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_DIFFAMT = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_OUTCHGNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_NOOUTCAUSE = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_MEASURE = new DevExpress.XtraReports.UI.XRTableCell();
            this.D5_REMARK = new DevExpress.XtraReports.UI.XRTableCell();
            this.T5 = new DevExpress.XtraReports.UI.XRTable();
            this.R5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.RH5 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GH5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.D5 = new DevExpress.XtraReports.UI.DetailBand();
            this.C_PAGE = new DevExpress.XtraReports.UI.XRPageInfo();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.DR1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DR2 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DR3 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DR4 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DR5 = new DevExpress.XtraReports.UI.DetailReportBand();
            ((System.ComponentModel.ISupportInitialize)(this.T5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // C_TITLE
            // 
            this.C_TITLE.CanGrow = false;
            this.C_TITLE.Dpi = 100F;
            this.C_TITLE.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.C_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.C_TITLE.Multiline = true;
            this.C_TITLE.Name = "C_TITLE";
            this.C_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TITLE.SizeF = new System.Drawing.SizeF(700F, 32F);
            this.C_TITLE.Text = "▣ 2026年 11月 판매계획 대비 출하실적";
            this.C_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_TITLE.WordWrap = false;
            // 
            // L_T1
            // 
            this.L_T1.CanGrow = false;
            this.L_T1.Dpi = 100F;
            this.L_T1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.L_T1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6F);
            this.L_T1.Multiline = true;
            this.L_T1.Name = "L_T1";
            this.L_T1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_T1.SizeF = new System.Drawing.SizeF(400F, 22F);
            this.L_T1.Text = "1. 판매계획 대비 출하실적 현황";
            this.L_T1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_T1.WordWrap = false;
            // 
            // L_U1
            // 
            this.L_U1.CanGrow = false;
            this.L_U1.Dpi = 100F;
            this.L_U1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_U1.LocationFloat = new DevExpress.Utils.PointFloat(580F, 6F);
            this.L_U1.Multiline = true;
            this.L_U1.Name = "L_U1";
            this.L_U1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_U1.SizeF = new System.Drawing.SizeF(100F, 22F);
            this.L_U1.Text = "단위: 원";
            this.L_U1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.L_U1.WordWrap = false;
            // 
            // H1_DEBCNM
            // 
            this.H1_DEBCNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H1_DEBCNM.BorderColor = System.Drawing.Color.Black;
            this.H1_DEBCNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H1_DEBCNM.BorderWidth = 0.5F;
            this.H1_DEBCNM.CanGrow = false;
            this.H1_DEBCNM.Dpi = 100F;
            this.H1_DEBCNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H1_DEBCNM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H1_DEBCNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28F);
            this.H1_DEBCNM.Multiline = true;
            this.H1_DEBCNM.Name = "H1_DEBCNM";
            this.H1_DEBCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H1_DEBCNM.SizeF = new System.Drawing.SizeF(140F, 22F);
            this.H1_DEBCNM.StylePriority.UseBackColor = false;
            this.H1_DEBCNM.Text = "구분";
            this.H1_DEBCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H1_DEBCNM.WordWrap = false;
            // 
            // H1_PLANAMT
            // 
            this.H1_PLANAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H1_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.H1_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H1_PLANAMT.BorderWidth = 0.5F;
            this.H1_PLANAMT.CanGrow = false;
            this.H1_PLANAMT.Dpi = 100F;
            this.H1_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H1_PLANAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H1_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(140F, 28F);
            this.H1_PLANAMT.Multiline = true;
            this.H1_PLANAMT.Name = "H1_PLANAMT";
            this.H1_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H1_PLANAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H1_PLANAMT.StylePriority.UseBackColor = false;
            this.H1_PLANAMT.Text = "판매계획";
            this.H1_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H1_PLANAMT.WordWrap = false;
            // 
            // H1_RSTAMT
            // 
            this.H1_RSTAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H1_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.H1_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H1_RSTAMT.BorderWidth = 0.5F;
            this.H1_RSTAMT.CanGrow = false;
            this.H1_RSTAMT.Dpi = 100F;
            this.H1_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H1_RSTAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H1_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(290F, 28F);
            this.H1_RSTAMT.Multiline = true;
            this.H1_RSTAMT.Name = "H1_RSTAMT";
            this.H1_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H1_RSTAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H1_RSTAMT.StylePriority.UseBackColor = false;
            this.H1_RSTAMT.Text = "출하금액";
            this.H1_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H1_RSTAMT.WordWrap = false;
            // 
            // H1_DIFFAMT
            // 
            this.H1_DIFFAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H1_DIFFAMT.BorderColor = System.Drawing.Color.Black;
            this.H1_DIFFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H1_DIFFAMT.BorderWidth = 0.5F;
            this.H1_DIFFAMT.CanGrow = false;
            this.H1_DIFFAMT.Dpi = 100F;
            this.H1_DIFFAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H1_DIFFAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H1_DIFFAMT.LocationFloat = new DevExpress.Utils.PointFloat(440F, 28F);
            this.H1_DIFFAMT.Multiline = true;
            this.H1_DIFFAMT.Name = "H1_DIFFAMT";
            this.H1_DIFFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H1_DIFFAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H1_DIFFAMT.StylePriority.UseBackColor = false;
            this.H1_DIFFAMT.Text = "차액";
            this.H1_DIFFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H1_DIFFAMT.WordWrap = false;
            // 
            // H1_RATE
            // 
            this.H1_RATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H1_RATE.BorderColor = System.Drawing.Color.Black;
            this.H1_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H1_RATE.BorderWidth = 0.5F;
            this.H1_RATE.CanGrow = false;
            this.H1_RATE.Dpi = 100F;
            this.H1_RATE.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H1_RATE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H1_RATE.LocationFloat = new DevExpress.Utils.PointFloat(590F, 28F);
            this.H1_RATE.Multiline = true;
            this.H1_RATE.Name = "H1_RATE";
            this.H1_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H1_RATE.SizeF = new System.Drawing.SizeF(90F, 22F);
            this.H1_RATE.StylePriority.UseBackColor = false;
            this.H1_RATE.Text = "달성율(%)";
            this.H1_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H1_RATE.WordWrap = false;
            // 
            // D1_DEBCNM
            // 
            this.D1_DEBCNM.BorderColor = System.Drawing.Color.Black;
            this.D1_DEBCNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D1_DEBCNM.BorderWidth = 0.5F;
            this.D1_DEBCNM.CanGrow = false;
            this.D1_DEBCNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DEBCNM")});
            this.D1_DEBCNM.Dpi = 100F;
            this.D1_DEBCNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D1_DEBCNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.D1_DEBCNM.Multiline = true;
            this.D1_DEBCNM.Name = "D1_DEBCNM";
            this.D1_DEBCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D1_DEBCNM.SizeF = new System.Drawing.SizeF(140F, 20F);
            this.D1_DEBCNM.Text = "";
            this.D1_DEBCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D1_DEBCNM.WordWrap = false;
            // 
            // D1_PLANAMT
            // 
            this.D1_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.D1_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D1_PLANAMT.BorderWidth = 0.5F;
            this.D1_PLANAMT.CanGrow = false;
            this.D1_PLANAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PLANAMT", "{0:#,##0}")});
            this.D1_PLANAMT.Dpi = 100F;
            this.D1_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D1_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.D1_PLANAMT.Multiline = true;
            this.D1_PLANAMT.Name = "D1_PLANAMT";
            this.D1_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D1_PLANAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D1_PLANAMT.Text = "";
            this.D1_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D1_PLANAMT.WordWrap = false;
            // 
            // D1_RSTAMT
            // 
            this.D1_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.D1_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D1_RSTAMT.BorderWidth = 0.5F;
            this.D1_RSTAMT.CanGrow = false;
            this.D1_RSTAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RSTAMT", "{0:#,##0}")});
            this.D1_RSTAMT.Dpi = 100F;
            this.D1_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D1_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(290F, 0F);
            this.D1_RSTAMT.Multiline = true;
            this.D1_RSTAMT.Name = "D1_RSTAMT";
            this.D1_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D1_RSTAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D1_RSTAMT.Text = "";
            this.D1_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D1_RSTAMT.WordWrap = false;
            // 
            // D1_DIFFAMT
            // 
            this.D1_DIFFAMT.BorderColor = System.Drawing.Color.Black;
            this.D1_DIFFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D1_DIFFAMT.BorderWidth = 0.5F;
            this.D1_DIFFAMT.CanGrow = false;
            this.D1_DIFFAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DIFFAMT", "{0:#,##0}")});
            this.D1_DIFFAMT.Dpi = 100F;
            this.D1_DIFFAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D1_DIFFAMT.LocationFloat = new DevExpress.Utils.PointFloat(440F, 0F);
            this.D1_DIFFAMT.Multiline = true;
            this.D1_DIFFAMT.Name = "D1_DIFFAMT";
            this.D1_DIFFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D1_DIFFAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D1_DIFFAMT.Text = "";
            this.D1_DIFFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D1_DIFFAMT.WordWrap = false;
            // 
            // D1_RATE
            // 
            this.D1_RATE.BorderColor = System.Drawing.Color.Black;
            this.D1_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D1_RATE.BorderWidth = 0.5F;
            this.D1_RATE.CanGrow = false;
            this.D1_RATE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RATE", "{0:#,##0}%")});
            this.D1_RATE.Dpi = 100F;
            this.D1_RATE.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D1_RATE.LocationFloat = new DevExpress.Utils.PointFloat(590F, 0F);
            this.D1_RATE.Multiline = true;
            this.D1_RATE.Name = "D1_RATE";
            this.D1_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D1_RATE.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.D1_RATE.Text = "";
            this.D1_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D1_RATE.WordWrap = false;
            // 
            // L_T2
            // 
            this.L_T2.CanGrow = false;
            this.L_T2.Dpi = 100F;
            this.L_T2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.L_T2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6F);
            this.L_T2.Multiline = true;
            this.L_T2.Name = "L_T2";
            this.L_T2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_T2.SizeF = new System.Drawing.SizeF(400F, 22F);
            this.L_T2.Text = "2. 고객사별 계획 대비 실적 현황";
            this.L_T2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_T2.WordWrap = false;
            // 
            // L_U2
            // 
            this.L_U2.CanGrow = false;
            this.L_U2.Dpi = 100F;
            this.L_U2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_U2.LocationFloat = new DevExpress.Utils.PointFloat(610F, 6F);
            this.L_U2.Multiline = true;
            this.L_U2.Name = "L_U2";
            this.L_U2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_U2.SizeF = new System.Drawing.SizeF(100F, 22F);
            this.L_U2.Text = "단위: 원";
            this.L_U2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.L_U2.WordWrap = false;
            // 
            // H2_DEBCNM
            // 
            this.H2_DEBCNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H2_DEBCNM.BorderColor = System.Drawing.Color.Black;
            this.H2_DEBCNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H2_DEBCNM.BorderWidth = 0.5F;
            this.H2_DEBCNM.CanGrow = false;
            this.H2_DEBCNM.Dpi = 100F;
            this.H2_DEBCNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H2_DEBCNM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H2_DEBCNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28F);
            this.H2_DEBCNM.Multiline = true;
            this.H2_DEBCNM.Name = "H2_DEBCNM";
            this.H2_DEBCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H2_DEBCNM.SizeF = new System.Drawing.SizeF(140F, 22F);
            this.H2_DEBCNM.StylePriority.UseBackColor = false;
            this.H2_DEBCNM.Text = "구분";
            this.H2_DEBCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H2_DEBCNM.WordWrap = false;
            // 
            // H2_CUSTNM
            // 
            this.H2_CUSTNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H2_CUSTNM.BorderColor = System.Drawing.Color.Black;
            this.H2_CUSTNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H2_CUSTNM.BorderWidth = 0.5F;
            this.H2_CUSTNM.CanGrow = false;
            this.H2_CUSTNM.Dpi = 100F;
            this.H2_CUSTNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H2_CUSTNM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H2_CUSTNM.LocationFloat = new DevExpress.Utils.PointFloat(140F, 28F);
            this.H2_CUSTNM.Multiline = true;
            this.H2_CUSTNM.Name = "H2_CUSTNM";
            this.H2_CUSTNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H2_CUSTNM.SizeF = new System.Drawing.SizeF(180F, 22F);
            this.H2_CUSTNM.StylePriority.UseBackColor = false;
            this.H2_CUSTNM.Text = "고객사";
            this.H2_CUSTNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H2_CUSTNM.WordWrap = false;
            // 
            // H2_PLANAMT
            // 
            this.H2_PLANAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H2_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.H2_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H2_PLANAMT.BorderWidth = 0.5F;
            this.H2_PLANAMT.CanGrow = false;
            this.H2_PLANAMT.Dpi = 100F;
            this.H2_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H2_PLANAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H2_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(320F, 28F);
            this.H2_PLANAMT.Multiline = true;
            this.H2_PLANAMT.Name = "H2_PLANAMT";
            this.H2_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H2_PLANAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H2_PLANAMT.StylePriority.UseBackColor = false;
            this.H2_PLANAMT.Text = "판매계획";
            this.H2_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H2_PLANAMT.WordWrap = false;
            // 
            // H2_RSTAMT
            // 
            this.H2_RSTAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H2_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.H2_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H2_RSTAMT.BorderWidth = 0.5F;
            this.H2_RSTAMT.CanGrow = false;
            this.H2_RSTAMT.Dpi = 100F;
            this.H2_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H2_RSTAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H2_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(470F, 28F);
            this.H2_RSTAMT.Multiline = true;
            this.H2_RSTAMT.Name = "H2_RSTAMT";
            this.H2_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H2_RSTAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H2_RSTAMT.StylePriority.UseBackColor = false;
            this.H2_RSTAMT.Text = "출하금액";
            this.H2_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H2_RSTAMT.WordWrap = false;
            // 
            // H2_RATE
            // 
            this.H2_RATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H2_RATE.BorderColor = System.Drawing.Color.Black;
            this.H2_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H2_RATE.BorderWidth = 0.5F;
            this.H2_RATE.CanGrow = false;
            this.H2_RATE.Dpi = 100F;
            this.H2_RATE.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H2_RATE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H2_RATE.LocationFloat = new DevExpress.Utils.PointFloat(620F, 28F);
            this.H2_RATE.Multiline = true;
            this.H2_RATE.Name = "H2_RATE";
            this.H2_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H2_RATE.SizeF = new System.Drawing.SizeF(90F, 22F);
            this.H2_RATE.StylePriority.UseBackColor = false;
            this.H2_RATE.Text = "달성율(%)";
            this.H2_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H2_RATE.WordWrap = false;
            // 
            // D2_DEBCNM
            // 
            this.D2_DEBCNM.BorderColor = System.Drawing.Color.Black;
            this.D2_DEBCNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D2_DEBCNM.BorderWidth = 0.5F;
            this.D2_DEBCNM.CanGrow = false;
            this.D2_DEBCNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DEBCNM")});
            this.D2_DEBCNM.Dpi = 100F;
            this.D2_DEBCNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D2_DEBCNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.D2_DEBCNM.Multiline = true;
            this.D2_DEBCNM.Name = "D2_DEBCNM";
            this.D2_DEBCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D2_DEBCNM.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.D2_DEBCNM.SizeF = new System.Drawing.SizeF(140F, 20F);
            this.D2_DEBCNM.Text = "";
            this.D2_DEBCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D2_DEBCNM.WordWrap = false;
            // 
            // D2_CUSTNM
            // 
            this.D2_CUSTNM.BorderColor = System.Drawing.Color.Black;
            this.D2_CUSTNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D2_CUSTNM.BorderWidth = 0.5F;
            this.D2_CUSTNM.CanGrow = false;
            this.D2_CUSTNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CUSTNM")});
            this.D2_CUSTNM.Dpi = 100F;
            this.D2_CUSTNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D2_CUSTNM.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.D2_CUSTNM.Multiline = true;
            this.D2_CUSTNM.Name = "D2_CUSTNM";
            this.D2_CUSTNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D2_CUSTNM.SizeF = new System.Drawing.SizeF(180F, 20F);
            this.D2_CUSTNM.Text = "";
            this.D2_CUSTNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D2_CUSTNM.WordWrap = false;
            // 
            // D2_PLANAMT
            // 
            this.D2_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.D2_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D2_PLANAMT.BorderWidth = 0.5F;
            this.D2_PLANAMT.CanGrow = false;
            this.D2_PLANAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PLANAMT", "{0:#,##0}")});
            this.D2_PLANAMT.Dpi = 100F;
            this.D2_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D2_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(320F, 0F);
            this.D2_PLANAMT.Multiline = true;
            this.D2_PLANAMT.Name = "D2_PLANAMT";
            this.D2_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D2_PLANAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D2_PLANAMT.Text = "";
            this.D2_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D2_PLANAMT.WordWrap = false;
            // 
            // D2_RSTAMT
            // 
            this.D2_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.D2_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D2_RSTAMT.BorderWidth = 0.5F;
            this.D2_RSTAMT.CanGrow = false;
            this.D2_RSTAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RSTAMT", "{0:#,##0}")});
            this.D2_RSTAMT.Dpi = 100F;
            this.D2_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D2_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(470F, 0F);
            this.D2_RSTAMT.Multiline = true;
            this.D2_RSTAMT.Name = "D2_RSTAMT";
            this.D2_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D2_RSTAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D2_RSTAMT.Text = "";
            this.D2_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D2_RSTAMT.WordWrap = false;
            // 
            // D2_RATE
            // 
            this.D2_RATE.BorderColor = System.Drawing.Color.Black;
            this.D2_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D2_RATE.BorderWidth = 0.5F;
            this.D2_RATE.CanGrow = false;
            this.D2_RATE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RATE", "{0:#,##0}%")});
            this.D2_RATE.Dpi = 100F;
            this.D2_RATE.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D2_RATE.LocationFloat = new DevExpress.Utils.PointFloat(620F, 0F);
            this.D2_RATE.Multiline = true;
            this.D2_RATE.Name = "D2_RATE";
            this.D2_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D2_RATE.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.D2_RATE.Text = "";
            this.D2_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D2_RATE.WordWrap = false;
            // 
            // L_T3
            // 
            this.L_T3.CanGrow = false;
            this.L_T3.Dpi = 100F;
            this.L_T3.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.L_T3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6F);
            this.L_T3.Multiline = true;
            this.L_T3.Name = "L_T3";
            this.L_T3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_T3.SizeF = new System.Drawing.SizeF(400F, 22F);
            this.L_T3.Text = "3. 변동사유 기준";
            this.L_T3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_T3.WordWrap = false;
            // 
            // L_U3
            // 
            this.L_U3.CanGrow = false;
            this.L_U3.Dpi = 100F;
            this.L_U3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_U3.LocationFloat = new DevExpress.Utils.PointFloat(490F, 6F);
            this.L_U3.Multiline = true;
            this.L_U3.Name = "L_U3";
            this.L_U3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_U3.SizeF = new System.Drawing.SizeF(100F, 22F);
            this.L_U3.Text = "단위: 원";
            this.L_U3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.L_U3.WordWrap = false;
            // 
            // H3_OUTCHGNM
            // 
            this.H3_OUTCHGNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H3_OUTCHGNM.BorderColor = System.Drawing.Color.Black;
            this.H3_OUTCHGNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H3_OUTCHGNM.BorderWidth = 0.5F;
            this.H3_OUTCHGNM.CanGrow = false;
            this.H3_OUTCHGNM.Dpi = 100F;
            this.H3_OUTCHGNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H3_OUTCHGNM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H3_OUTCHGNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28F);
            this.H3_OUTCHGNM.Multiline = true;
            this.H3_OUTCHGNM.Name = "H3_OUTCHGNM";
            this.H3_OUTCHGNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H3_OUTCHGNM.SizeF = new System.Drawing.SizeF(140F, 22F);
            this.H3_OUTCHGNM.StylePriority.UseBackColor = false;
            this.H3_OUTCHGNM.Text = "변동사유";
            this.H3_OUTCHGNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H3_OUTCHGNM.WordWrap = false;
            // 
            // H3_PLANAMT
            // 
            this.H3_PLANAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H3_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.H3_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H3_PLANAMT.BorderWidth = 0.5F;
            this.H3_PLANAMT.CanGrow = false;
            this.H3_PLANAMT.Dpi = 100F;
            this.H3_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H3_PLANAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H3_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(140F, 28F);
            this.H3_PLANAMT.Multiline = true;
            this.H3_PLANAMT.Name = "H3_PLANAMT";
            this.H3_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H3_PLANAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H3_PLANAMT.StylePriority.UseBackColor = false;
            this.H3_PLANAMT.Text = "판매계획";
            this.H3_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H3_PLANAMT.WordWrap = false;
            // 
            // H3_RSTAMT
            // 
            this.H3_RSTAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H3_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.H3_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H3_RSTAMT.BorderWidth = 0.5F;
            this.H3_RSTAMT.CanGrow = false;
            this.H3_RSTAMT.Dpi = 100F;
            this.H3_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H3_RSTAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H3_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(290F, 28F);
            this.H3_RSTAMT.Multiline = true;
            this.H3_RSTAMT.Name = "H3_RSTAMT";
            this.H3_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H3_RSTAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H3_RSTAMT.StylePriority.UseBackColor = false;
            this.H3_RSTAMT.Text = "출하실적";
            this.H3_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H3_RSTAMT.WordWrap = false;
            // 
            // H3_DIFFAMT
            // 
            this.H3_DIFFAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H3_DIFFAMT.BorderColor = System.Drawing.Color.Black;
            this.H3_DIFFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H3_DIFFAMT.BorderWidth = 0.5F;
            this.H3_DIFFAMT.CanGrow = false;
            this.H3_DIFFAMT.Dpi = 100F;
            this.H3_DIFFAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H3_DIFFAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H3_DIFFAMT.LocationFloat = new DevExpress.Utils.PointFloat(440F, 28F);
            this.H3_DIFFAMT.Multiline = true;
            this.H3_DIFFAMT.Name = "H3_DIFFAMT";
            this.H3_DIFFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H3_DIFFAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H3_DIFFAMT.StylePriority.UseBackColor = false;
            this.H3_DIFFAMT.Text = "차액";
            this.H3_DIFFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H3_DIFFAMT.WordWrap = false;
            // 
            // D3_OUTCHGNM
            // 
            this.D3_OUTCHGNM.BorderColor = System.Drawing.Color.Black;
            this.D3_OUTCHGNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D3_OUTCHGNM.BorderWidth = 0.5F;
            this.D3_OUTCHGNM.CanGrow = false;
            this.D3_OUTCHGNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OUTCHGNM")});
            this.D3_OUTCHGNM.Dpi = 100F;
            this.D3_OUTCHGNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D3_OUTCHGNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.D3_OUTCHGNM.Multiline = true;
            this.D3_OUTCHGNM.Name = "D3_OUTCHGNM";
            this.D3_OUTCHGNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D3_OUTCHGNM.SizeF = new System.Drawing.SizeF(140F, 20F);
            this.D3_OUTCHGNM.Text = "";
            this.D3_OUTCHGNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D3_OUTCHGNM.WordWrap = false;
            // 
            // D3_PLANAMT
            // 
            this.D3_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.D3_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D3_PLANAMT.BorderWidth = 0.5F;
            this.D3_PLANAMT.CanGrow = false;
            this.D3_PLANAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PLANAMT", "{0:#,##0}")});
            this.D3_PLANAMT.Dpi = 100F;
            this.D3_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D3_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.D3_PLANAMT.Multiline = true;
            this.D3_PLANAMT.Name = "D3_PLANAMT";
            this.D3_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D3_PLANAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D3_PLANAMT.Text = "";
            this.D3_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D3_PLANAMT.WordWrap = false;
            // 
            // D3_RSTAMT
            // 
            this.D3_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.D3_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D3_RSTAMT.BorderWidth = 0.5F;
            this.D3_RSTAMT.CanGrow = false;
            this.D3_RSTAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RSTAMT", "{0:#,##0}")});
            this.D3_RSTAMT.Dpi = 100F;
            this.D3_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D3_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(290F, 0F);
            this.D3_RSTAMT.Multiline = true;
            this.D3_RSTAMT.Name = "D3_RSTAMT";
            this.D3_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D3_RSTAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D3_RSTAMT.Text = "";
            this.D3_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D3_RSTAMT.WordWrap = false;
            // 
            // D3_DIFFAMT
            // 
            this.D3_DIFFAMT.BorderColor = System.Drawing.Color.Black;
            this.D3_DIFFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D3_DIFFAMT.BorderWidth = 0.5F;
            this.D3_DIFFAMT.CanGrow = false;
            this.D3_DIFFAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DIFFAMT", "{0:#,##0}")});
            this.D3_DIFFAMT.Dpi = 100F;
            this.D3_DIFFAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D3_DIFFAMT.LocationFloat = new DevExpress.Utils.PointFloat(440F, 0F);
            this.D3_DIFFAMT.Multiline = true;
            this.D3_DIFFAMT.Name = "D3_DIFFAMT";
            this.D3_DIFFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D3_DIFFAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D3_DIFFAMT.Text = "";
            this.D3_DIFFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D3_DIFFAMT.WordWrap = false;
            // 
            // L_T4
            // 
            this.L_T4.CanGrow = false;
            this.L_T4.Dpi = 100F;
            this.L_T4.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.L_T4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6F);
            this.L_T4.Multiline = true;
            this.L_T4.Name = "L_T4";
            this.L_T4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_T4.SizeF = new System.Drawing.SizeF(400F, 22F);
            this.L_T4.Text = "4. 판매계획 대비 실적";
            this.L_T4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_T4.WordWrap = false;
            // 
            // L_U4
            // 
            this.L_U4.CanGrow = false;
            this.L_U4.Dpi = 100F;
            this.L_U4.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_U4.LocationFloat = new DevExpress.Utils.PointFloat(740F, 6F);
            this.L_U4.Multiline = true;
            this.L_U4.Name = "L_U4";
            this.L_U4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_U4.SizeF = new System.Drawing.SizeF(100F, 22F);
            this.L_U4.Text = "단위: 원";
            this.L_U4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.L_U4.WordWrap = false;
            // 
            // H4_PLANAMT
            // 
            this.H4_PLANAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H4_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.H4_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H4_PLANAMT.BorderWidth = 0.5F;
            this.H4_PLANAMT.CanGrow = false;
            this.H4_PLANAMT.Dpi = 100F;
            this.H4_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H4_PLANAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H4_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28F);
            this.H4_PLANAMT.Multiline = true;
            this.H4_PLANAMT.Name = "H4_PLANAMT";
            this.H4_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H4_PLANAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H4_PLANAMT.StylePriority.UseBackColor = false;
            this.H4_PLANAMT.Text = "판매계획(A)";
            this.H4_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H4_PLANAMT.WordWrap = false;
            // 
            // H4_ADJNM
            // 
            this.H4_ADJNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H4_ADJNM.BorderColor = System.Drawing.Color.Black;
            this.H4_ADJNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H4_ADJNM.BorderWidth = 0.5F;
            this.H4_ADJNM.CanGrow = false;
            this.H4_ADJNM.Dpi = 100F;
            this.H4_ADJNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H4_ADJNM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H4_ADJNM.LocationFloat = new DevExpress.Utils.PointFloat(150F, 28F);
            this.H4_ADJNM.Multiline = true;
            this.H4_ADJNM.Name = "H4_ADJNM";
            this.H4_ADJNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H4_ADJNM.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H4_ADJNM.StylePriority.UseBackColor = false;
            this.H4_ADJNM.Text = "조정대상 사유";
            this.H4_ADJNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H4_ADJNM.WordWrap = false;
            // 
            // H4_ADJAMT
            // 
            this.H4_ADJAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H4_ADJAMT.BorderColor = System.Drawing.Color.Black;
            this.H4_ADJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H4_ADJAMT.BorderWidth = 0.5F;
            this.H4_ADJAMT.CanGrow = false;
            this.H4_ADJAMT.Dpi = 100F;
            this.H4_ADJAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H4_ADJAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H4_ADJAMT.LocationFloat = new DevExpress.Utils.PointFloat(300F, 28F);
            this.H4_ADJAMT.Multiline = true;
            this.H4_ADJAMT.Name = "H4_ADJAMT";
            this.H4_ADJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H4_ADJAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H4_ADJAMT.StylePriority.UseBackColor = false;
            this.H4_ADJAMT.Text = "조정대상 차액(B)";
            this.H4_ADJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H4_ADJAMT.WordWrap = false;
            // 
            // H4_ADJPLANAMT
            // 
            this.H4_ADJPLANAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H4_ADJPLANAMT.BorderColor = System.Drawing.Color.Black;
            this.H4_ADJPLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H4_ADJPLANAMT.BorderWidth = 0.5F;
            this.H4_ADJPLANAMT.CanGrow = false;
            this.H4_ADJPLANAMT.Dpi = 100F;
            this.H4_ADJPLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H4_ADJPLANAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H4_ADJPLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(450F, 28F);
            this.H4_ADJPLANAMT.Multiline = true;
            this.H4_ADJPLANAMT.Name = "H4_ADJPLANAMT";
            this.H4_ADJPLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H4_ADJPLANAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H4_ADJPLANAMT.StylePriority.UseBackColor = false;
            this.H4_ADJPLANAMT.Text = "판매계획(A+B)";
            this.H4_ADJPLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H4_ADJPLANAMT.WordWrap = false;
            // 
            // H4_RSTAMT
            // 
            this.H4_RSTAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H4_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.H4_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H4_RSTAMT.BorderWidth = 0.5F;
            this.H4_RSTAMT.CanGrow = false;
            this.H4_RSTAMT.Dpi = 100F;
            this.H4_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H4_RSTAMT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H4_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(600F, 28F);
            this.H4_RSTAMT.Multiline = true;
            this.H4_RSTAMT.Name = "H4_RSTAMT";
            this.H4_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H4_RSTAMT.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.H4_RSTAMT.StylePriority.UseBackColor = false;
            this.H4_RSTAMT.Text = "출하실적";
            this.H4_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H4_RSTAMT.WordWrap = false;
            // 
            // H4_RATE
            // 
            this.H4_RATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.H4_RATE.BorderColor = System.Drawing.Color.Black;
            this.H4_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H4_RATE.BorderWidth = 0.5F;
            this.H4_RATE.CanGrow = false;
            this.H4_RATE.Dpi = 100F;
            this.H4_RATE.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.H4_RATE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.H4_RATE.LocationFloat = new DevExpress.Utils.PointFloat(750F, 28F);
            this.H4_RATE.Multiline = true;
            this.H4_RATE.Name = "H4_RATE";
            this.H4_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H4_RATE.SizeF = new System.Drawing.SizeF(90F, 22F);
            this.H4_RATE.StylePriority.UseBackColor = false;
            this.H4_RATE.Text = "달성율(%)";
            this.H4_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H4_RATE.WordWrap = false;
            // 
            // D4_PLANAMT
            // 
            this.D4_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.D4_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D4_PLANAMT.BorderWidth = 0.5F;
            this.D4_PLANAMT.CanGrow = false;
            this.D4_PLANAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PLANAMT", "{0:#,##0}")});
            this.D4_PLANAMT.Dpi = 100F;
            this.D4_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D4_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.D4_PLANAMT.Multiline = true;
            this.D4_PLANAMT.Name = "D4_PLANAMT";
            this.D4_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D4_PLANAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D4_PLANAMT.Text = "";
            this.D4_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D4_PLANAMT.WordWrap = false;
            // 
            // D4_ADJNM
            // 
            this.D4_ADJNM.BorderColor = System.Drawing.Color.Black;
            this.D4_ADJNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D4_ADJNM.BorderWidth = 0.5F;
            this.D4_ADJNM.CanGrow = false;
            this.D4_ADJNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ADJNM")});
            this.D4_ADJNM.Dpi = 100F;
            this.D4_ADJNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D4_ADJNM.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.D4_ADJNM.Multiline = true;
            this.D4_ADJNM.Name = "D4_ADJNM";
            this.D4_ADJNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D4_ADJNM.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D4_ADJNM.Text = "";
            this.D4_ADJNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D4_ADJNM.WordWrap = false;
            // 
            // D4_ADJAMT
            // 
            this.D4_ADJAMT.BorderColor = System.Drawing.Color.Black;
            this.D4_ADJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D4_ADJAMT.BorderWidth = 0.5F;
            this.D4_ADJAMT.CanGrow = false;
            this.D4_ADJAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ADJAMT", "{0:#,##0}")});
            this.D4_ADJAMT.Dpi = 100F;
            this.D4_ADJAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D4_ADJAMT.LocationFloat = new DevExpress.Utils.PointFloat(300F, 0F);
            this.D4_ADJAMT.Multiline = true;
            this.D4_ADJAMT.Name = "D4_ADJAMT";
            this.D4_ADJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D4_ADJAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D4_ADJAMT.Text = "";
            this.D4_ADJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D4_ADJAMT.WordWrap = false;
            // 
            // D4_ADJPLANAMT
            // 
            this.D4_ADJPLANAMT.BorderColor = System.Drawing.Color.Black;
            this.D4_ADJPLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D4_ADJPLANAMT.BorderWidth = 0.5F;
            this.D4_ADJPLANAMT.CanGrow = false;
            this.D4_ADJPLANAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ADJPLANAMT", "{0:#,##0}")});
            this.D4_ADJPLANAMT.Dpi = 100F;
            this.D4_ADJPLANAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D4_ADJPLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(450F, 0F);
            this.D4_ADJPLANAMT.Multiline = true;
            this.D4_ADJPLANAMT.Name = "D4_ADJPLANAMT";
            this.D4_ADJPLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D4_ADJPLANAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D4_ADJPLANAMT.Text = "";
            this.D4_ADJPLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D4_ADJPLANAMT.WordWrap = false;
            // 
            // D4_RSTAMT
            // 
            this.D4_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.D4_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D4_RSTAMT.BorderWidth = 0.5F;
            this.D4_RSTAMT.CanGrow = false;
            this.D4_RSTAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RSTAMT", "{0:#,##0}")});
            this.D4_RSTAMT.Dpi = 100F;
            this.D4_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D4_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
            this.D4_RSTAMT.Multiline = true;
            this.D4_RSTAMT.Name = "D4_RSTAMT";
            this.D4_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D4_RSTAMT.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.D4_RSTAMT.Text = "";
            this.D4_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D4_RSTAMT.WordWrap = false;
            // 
            // D4_RATE
            // 
            this.D4_RATE.BorderColor = System.Drawing.Color.Black;
            this.D4_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D4_RATE.BorderWidth = 0.5F;
            this.D4_RATE.CanGrow = false;
            this.D4_RATE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RATE", "{0:#,##0}%")});
            this.D4_RATE.Dpi = 100F;
            this.D4_RATE.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.D4_RATE.LocationFloat = new DevExpress.Utils.PointFloat(750F, 0F);
            this.D4_RATE.Multiline = true;
            this.D4_RATE.Name = "D4_RATE";
            this.D4_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D4_RATE.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.D4_RATE.Text = "";
            this.D4_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D4_RATE.WordWrap = false;
            // 
            // C_DETAIL_TITLE
            // 
            this.C_DETAIL_TITLE.CanGrow = false;
            this.C_DETAIL_TITLE.Dpi = 100F;
            this.C_DETAIL_TITLE.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.C_DETAIL_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.C_DETAIL_TITLE.Multiline = true;
            this.C_DETAIL_TITLE.Name = "C_DETAIL_TITLE";
            this.C_DETAIL_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DETAIL_TITLE.SizeF = new System.Drawing.SizeF(700F, 32F);
            this.C_DETAIL_TITLE.Text = "■ (2026년 11월) 출하계획 대비 실적";
            this.C_DETAIL_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_DETAIL_TITLE.WordWrap = false;
            // 
            // H5_DEBCNM
            // 
            this.H5_DEBCNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_DEBCNM.BorderColor = System.Drawing.Color.Black;
            this.H5_DEBCNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_DEBCNM.BorderWidth = 0.5F;
            this.H5_DEBCNM.CanGrow = false;
            this.H5_DEBCNM.Dpi = 100F;
            this.H5_DEBCNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_DEBCNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.H5_DEBCNM.Multiline = true;
            this.H5_DEBCNM.Name = "H5_DEBCNM";
            this.H5_DEBCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_DEBCNM.SizeF = new System.Drawing.SizeF(50F, 36F);
            this.H5_DEBCNM.StylePriority.UseBackColor = false;
            this.H5_DEBCNM.Text = "구분";
            this.H5_DEBCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_DEBCNM.WordWrap = true;
            // 
            // H5_CUSTNM
            // 
            this.H5_CUSTNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_CUSTNM.BorderColor = System.Drawing.Color.Black;
            this.H5_CUSTNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_CUSTNM.BorderWidth = 0.5F;
            this.H5_CUSTNM.CanGrow = false;
            this.H5_CUSTNM.Dpi = 100F;
            this.H5_CUSTNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_CUSTNM.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.H5_CUSTNM.Multiline = true;
            this.H5_CUSTNM.Name = "H5_CUSTNM";
            this.H5_CUSTNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_CUSTNM.SizeF = new System.Drawing.SizeF(80F, 36F);
            this.H5_CUSTNM.StylePriority.UseBackColor = false;
            this.H5_CUSTNM.Text = "고객사";
            this.H5_CUSTNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_CUSTNM.WordWrap = true;
            // 
            // H5_ITEMNM
            // 
            this.H5_ITEMNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.H5_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_ITEMNM.BorderWidth = 0.5F;
            this.H5_ITEMNM.CanGrow = false;
            this.H5_ITEMNM.Dpi = 100F;
            this.H5_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(130F, 0F);
            this.H5_ITEMNM.Multiline = true;
            this.H5_ITEMNM.Name = "H5_ITEMNM";
            this.H5_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_ITEMNM.SizeF = new System.Drawing.SizeF(105F, 36F);
            this.H5_ITEMNM.StylePriority.UseBackColor = false;
            this.H5_ITEMNM.Text = "품명";
            this.H5_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_ITEMNM.WordWrap = true;
            // 
            // H5_ITEMCD
            // 
            this.H5_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.H5_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_ITEMCD.BorderWidth = 0.5F;
            this.H5_ITEMCD.CanGrow = false;
            this.H5_ITEMCD.Dpi = 100F;
            this.H5_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(235F, 0F);
            this.H5_ITEMCD.Multiline = true;
            this.H5_ITEMCD.Name = "H5_ITEMCD";
            this.H5_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_ITEMCD.SizeF = new System.Drawing.SizeF(75F, 36F);
            this.H5_ITEMCD.StylePriority.UseBackColor = false;
            this.H5_ITEMCD.Text = "품번";
            this.H5_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_ITEMCD.WordWrap = true;
            // 
            // H5_CURYNM
            // 
            this.H5_CURYNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_CURYNM.BorderColor = System.Drawing.Color.Black;
            this.H5_CURYNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_CURYNM.BorderWidth = 0.5F;
            this.H5_CURYNM.CanGrow = false;
            this.H5_CURYNM.Dpi = 100F;
            this.H5_CURYNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_CURYNM.LocationFloat = new DevExpress.Utils.PointFloat(310F, 0F);
            this.H5_CURYNM.Multiline = true;
            this.H5_CURYNM.Name = "H5_CURYNM";
            this.H5_CURYNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_CURYNM.SizeF = new System.Drawing.SizeF(30F, 36F);
            this.H5_CURYNM.StylePriority.UseBackColor = false;
            this.H5_CURYNM.Text = "통화";
            this.H5_CURYNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_CURYNM.WordWrap = true;
            // 
            // H5_FUP
            // 
            this.H5_FUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_FUP.BorderColor = System.Drawing.Color.Black;
            this.H5_FUP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_FUP.BorderWidth = 0.5F;
            this.H5_FUP.CanGrow = false;
            this.H5_FUP.Dpi = 100F;
            this.H5_FUP.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_FUP.LocationFloat = new DevExpress.Utils.PointFloat(340F, 0F);
            this.H5_FUP.Multiline = true;
            this.H5_FUP.Name = "H5_FUP";
            this.H5_FUP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_FUP.SizeF = new System.Drawing.SizeF(52F, 36F);
            this.H5_FUP.StylePriority.UseBackColor = false;
            this.H5_FUP.Text = "외화단가";
            this.H5_FUP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_FUP.WordWrap = true;
            // 
            // H5_UP
            // 
            this.H5_UP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_UP.BorderColor = System.Drawing.Color.Black;
            this.H5_UP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_UP.BorderWidth = 0.5F;
            this.H5_UP.CanGrow = false;
            this.H5_UP.Dpi = 100F;
            this.H5_UP.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_UP.LocationFloat = new DevExpress.Utils.PointFloat(392F, 0F);
            this.H5_UP.Multiline = true;
            this.H5_UP.Name = "H5_UP";
            this.H5_UP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_UP.SizeF = new System.Drawing.SizeF(46F, 36F);
            this.H5_UP.StylePriority.UseBackColor = false;
            this.H5_UP.Text = "단가";
            this.H5_UP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_UP.WordWrap = true;
            // 
            // H5_G_계획
            // 
            this.H5_G_계획.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_G_계획.BorderColor = System.Drawing.Color.Black;
            this.H5_G_계획.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_G_계획.BorderWidth = 0.5F;
            this.H5_G_계획.CanGrow = false;
            this.H5_G_계획.Dpi = 100F;
            this.H5_G_계획.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_G_계획.LocationFloat = new DevExpress.Utils.PointFloat(438F, 0F);
            this.H5_G_계획.Multiline = true;
            this.H5_G_계획.Name = "H5_G_계획";
            this.H5_G_계획.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_G_계획.SizeF = new System.Drawing.SizeF(130F, 18F);
            this.H5_G_계획.StylePriority.UseBackColor = false;
            this.H5_G_계획.Text = "계획";
            this.H5_G_계획.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_G_계획.WordWrap = true;
            // 
            // H5_PLANQTY
            // 
            this.H5_PLANQTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_PLANQTY.BorderColor = System.Drawing.Color.Black;
            this.H5_PLANQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_PLANQTY.BorderWidth = 0.5F;
            this.H5_PLANQTY.CanGrow = false;
            this.H5_PLANQTY.Dpi = 100F;
            this.H5_PLANQTY.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_PLANQTY.LocationFloat = new DevExpress.Utils.PointFloat(438F, 18F);
            this.H5_PLANQTY.Multiline = true;
            this.H5_PLANQTY.Name = "H5_PLANQTY";
            this.H5_PLANQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_PLANQTY.SizeF = new System.Drawing.SizeF(50F, 18F);
            this.H5_PLANQTY.StylePriority.UseBackColor = false;
            this.H5_PLANQTY.Text = "수량(EA)";
            this.H5_PLANQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_PLANQTY.WordWrap = true;
            // 
            // H5_PLANAMT
            // 
            this.H5_PLANAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.H5_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_PLANAMT.BorderWidth = 0.5F;
            this.H5_PLANAMT.CanGrow = false;
            this.H5_PLANAMT.Dpi = 100F;
            this.H5_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_PLANAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 18F);
            this.H5_PLANAMT.Multiline = true;
            this.H5_PLANAMT.Name = "H5_PLANAMT";
            this.H5_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_PLANAMT.SizeF = new System.Drawing.SizeF(80F, 18F);
            this.H5_PLANAMT.StylePriority.UseBackColor = false;
            this.H5_PLANAMT.Text = "금액(원)";
            this.H5_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_PLANAMT.WordWrap = true;
            // 
            // H5_G_실적
            // 
            this.H5_G_실적.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_G_실적.BorderColor = System.Drawing.Color.Black;
            this.H5_G_실적.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_G_실적.BorderWidth = 0.5F;
            this.H5_G_실적.CanGrow = false;
            this.H5_G_실적.Dpi = 100F;
            this.H5_G_실적.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_G_실적.LocationFloat = new DevExpress.Utils.PointFloat(568F, 0F);
            this.H5_G_실적.Multiline = true;
            this.H5_G_실적.Name = "H5_G_실적";
            this.H5_G_실적.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_G_실적.SizeF = new System.Drawing.SizeF(130F, 18F);
            this.H5_G_실적.StylePriority.UseBackColor = false;
            this.H5_G_실적.Text = "실적";
            this.H5_G_실적.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_G_실적.WordWrap = true;
            // 
            // H5_RSTQTY
            // 
            this.H5_RSTQTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_RSTQTY.BorderColor = System.Drawing.Color.Black;
            this.H5_RSTQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_RSTQTY.BorderWidth = 0.5F;
            this.H5_RSTQTY.CanGrow = false;
            this.H5_RSTQTY.Dpi = 100F;
            this.H5_RSTQTY.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_RSTQTY.LocationFloat = new DevExpress.Utils.PointFloat(568F, 18F);
            this.H5_RSTQTY.Multiline = true;
            this.H5_RSTQTY.Name = "H5_RSTQTY";
            this.H5_RSTQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_RSTQTY.SizeF = new System.Drawing.SizeF(50F, 18F);
            this.H5_RSTQTY.StylePriority.UseBackColor = false;
            this.H5_RSTQTY.Text = "수량(EA)";
            this.H5_RSTQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_RSTQTY.WordWrap = true;
            // 
            // H5_RSTAMT
            // 
            this.H5_RSTAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.H5_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_RSTAMT.BorderWidth = 0.5F;
            this.H5_RSTAMT.CanGrow = false;
            this.H5_RSTAMT.Dpi = 100F;
            this.H5_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_RSTAMT.LocationFloat = new DevExpress.Utils.PointFloat(618F, 18F);
            this.H5_RSTAMT.Multiline = true;
            this.H5_RSTAMT.Name = "H5_RSTAMT";
            this.H5_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_RSTAMT.SizeF = new System.Drawing.SizeF(80F, 18F);
            this.H5_RSTAMT.StylePriority.UseBackColor = false;
            this.H5_RSTAMT.Text = "금액(원)";
            this.H5_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_RSTAMT.WordWrap = true;
            // 
            // H5_RATE
            // 
            this.H5_RATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_RATE.BorderColor = System.Drawing.Color.Black;
            this.H5_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_RATE.BorderWidth = 0.5F;
            this.H5_RATE.CanGrow = false;
            this.H5_RATE.Dpi = 100F;
            this.H5_RATE.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_RATE.LocationFloat = new DevExpress.Utils.PointFloat(698F, 0F);
            this.H5_RATE.Multiline = true;
            this.H5_RATE.Name = "H5_RATE";
            this.H5_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_RATE.SizeF = new System.Drawing.SizeF(42F, 36F);
            this.H5_RATE.StylePriority.UseBackColor = false;
            this.H5_RATE.Text = "달성율(%)";
            this.H5_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_RATE.WordWrap = true;
            // 
            // H5_G_차이
            // 
            this.H5_G_차이.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_G_차이.BorderColor = System.Drawing.Color.Black;
            this.H5_G_차이.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_G_차이.BorderWidth = 0.5F;
            this.H5_G_차이.CanGrow = false;
            this.H5_G_차이.Dpi = 100F;
            this.H5_G_차이.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_G_차이.LocationFloat = new DevExpress.Utils.PointFloat(740F, 0F);
            this.H5_G_차이.Multiline = true;
            this.H5_G_차이.Name = "H5_G_차이";
            this.H5_G_차이.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_G_차이.SizeF = new System.Drawing.SizeF(132F, 18F);
            this.H5_G_차이.StylePriority.UseBackColor = false;
            this.H5_G_차이.Text = "차이";
            this.H5_G_차이.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_G_차이.WordWrap = true;
            // 
            // H5_DIFFQTY
            // 
            this.H5_DIFFQTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_DIFFQTY.BorderColor = System.Drawing.Color.Black;
            this.H5_DIFFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_DIFFQTY.BorderWidth = 0.5F;
            this.H5_DIFFQTY.CanGrow = false;
            this.H5_DIFFQTY.Dpi = 100F;
            this.H5_DIFFQTY.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_DIFFQTY.LocationFloat = new DevExpress.Utils.PointFloat(740F, 18F);
            this.H5_DIFFQTY.Multiline = true;
            this.H5_DIFFQTY.Name = "H5_DIFFQTY";
            this.H5_DIFFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_DIFFQTY.SizeF = new System.Drawing.SizeF(50F, 18F);
            this.H5_DIFFQTY.StylePriority.UseBackColor = false;
            this.H5_DIFFQTY.Text = "수량(EA)";
            this.H5_DIFFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_DIFFQTY.WordWrap = true;
            // 
            // H5_DIFFAMT
            // 
            this.H5_DIFFAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_DIFFAMT.BorderColor = System.Drawing.Color.Black;
            this.H5_DIFFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_DIFFAMT.BorderWidth = 0.5F;
            this.H5_DIFFAMT.CanGrow = false;
            this.H5_DIFFAMT.Dpi = 100F;
            this.H5_DIFFAMT.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_DIFFAMT.LocationFloat = new DevExpress.Utils.PointFloat(790F, 18F);
            this.H5_DIFFAMT.Multiline = true;
            this.H5_DIFFAMT.Name = "H5_DIFFAMT";
            this.H5_DIFFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_DIFFAMT.SizeF = new System.Drawing.SizeF(82F, 18F);
            this.H5_DIFFAMT.StylePriority.UseBackColor = false;
            this.H5_DIFFAMT.Text = "금액(원)";
            this.H5_DIFFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_DIFFAMT.WordWrap = true;
            // 
            // H5_OUTCHGNM
            // 
            this.H5_OUTCHGNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_OUTCHGNM.BorderColor = System.Drawing.Color.Black;
            this.H5_OUTCHGNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_OUTCHGNM.BorderWidth = 0.5F;
            this.H5_OUTCHGNM.CanGrow = false;
            this.H5_OUTCHGNM.Dpi = 100F;
            this.H5_OUTCHGNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_OUTCHGNM.LocationFloat = new DevExpress.Utils.PointFloat(872F, 0F);
            this.H5_OUTCHGNM.Multiline = true;
            this.H5_OUTCHGNM.Name = "H5_OUTCHGNM";
            this.H5_OUTCHGNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_OUTCHGNM.SizeF = new System.Drawing.SizeF(55F, 36F);
            this.H5_OUTCHGNM.StylePriority.UseBackColor = false;
            this.H5_OUTCHGNM.Text = "변동사유";
            this.H5_OUTCHGNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_OUTCHGNM.WordWrap = true;
            // 
            // H5_NOOUTCAUSE
            // 
            this.H5_NOOUTCAUSE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_NOOUTCAUSE.BorderColor = System.Drawing.Color.Black;
            this.H5_NOOUTCAUSE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_NOOUTCAUSE.BorderWidth = 0.5F;
            this.H5_NOOUTCAUSE.CanGrow = false;
            this.H5_NOOUTCAUSE.Dpi = 100F;
            this.H5_NOOUTCAUSE.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_NOOUTCAUSE.LocationFloat = new DevExpress.Utils.PointFloat(927F, 0F);
            this.H5_NOOUTCAUSE.Multiline = true;
            this.H5_NOOUTCAUSE.Name = "H5_NOOUTCAUSE";
            this.H5_NOOUTCAUSE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_NOOUTCAUSE.SizeF = new System.Drawing.SizeF(80F, 36F);
            this.H5_NOOUTCAUSE.StylePriority.UseBackColor = false;
            this.H5_NOOUTCAUSE.Text = "미 출고 원인";
            this.H5_NOOUTCAUSE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_NOOUTCAUSE.WordWrap = true;
            // 
            // H5_MEASURE
            // 
            this.H5_MEASURE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_MEASURE.BorderColor = System.Drawing.Color.Black;
            this.H5_MEASURE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_MEASURE.BorderWidth = 0.5F;
            this.H5_MEASURE.CanGrow = false;
            this.H5_MEASURE.Dpi = 100F;
            this.H5_MEASURE.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_MEASURE.LocationFloat = new DevExpress.Utils.PointFloat(1007F, 0F);
            this.H5_MEASURE.Multiline = true;
            this.H5_MEASURE.Name = "H5_MEASURE";
            this.H5_MEASURE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_MEASURE.SizeF = new System.Drawing.SizeF(80F, 36F);
            this.H5_MEASURE.StylePriority.UseBackColor = false;
            this.H5_MEASURE.Text = "대책";
            this.H5_MEASURE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_MEASURE.WordWrap = true;
            // 
            // H5_REMARK
            // 
            this.H5_REMARK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(228)))));
            this.H5_REMARK.BorderColor = System.Drawing.Color.Black;
            this.H5_REMARK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.H5_REMARK.BorderWidth = 0.5F;
            this.H5_REMARK.CanGrow = false;
            this.H5_REMARK.Dpi = 100F;
            this.H5_REMARK.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.H5_REMARK.LocationFloat = new DevExpress.Utils.PointFloat(1087F, 0F);
            this.H5_REMARK.Multiline = true;
            this.H5_REMARK.Name = "H5_REMARK";
            this.H5_REMARK.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.H5_REMARK.SizeF = new System.Drawing.SizeF(42F, 36F);
            this.H5_REMARK.StylePriority.UseBackColor = false;
            this.H5_REMARK.Text = "비고";
            this.H5_REMARK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.H5_REMARK.WordWrap = true;
            // 
            // D5_DEBCNM
            // 
            this.D5_DEBCNM.BorderColor = System.Drawing.Color.Black;
            this.D5_DEBCNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_DEBCNM.BorderWidth = 0.5F;
            this.D5_DEBCNM.CanGrow = false;
            this.D5_DEBCNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DEBCNM"),
            new DevExpress.XtraReports.UI.XRBinding("Tag", null, "DEBCKEY")});
            this.D5_DEBCNM.Dpi = 100F;
            this.D5_DEBCNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_DEBCNM.Multiline = true;
            this.D5_DEBCNM.Name = "D5_DEBCNM";
            this.D5_DEBCNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_DEBCNM.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.D5_DEBCNM.ProcessDuplicatesTarget = DevExpress.XtraReports.UI.ProcessDuplicatesTarget.Tag;
            this.D5_DEBCNM.Text = "";
            this.D5_DEBCNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D5_DEBCNM.WidthF = 50F;
            this.D5_DEBCNM.WordWrap = false;
            // 
            // D5_CUSTNM
            // 
            this.D5_CUSTNM.BorderColor = System.Drawing.Color.Black;
            this.D5_CUSTNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_CUSTNM.BorderWidth = 0.5F;
            this.D5_CUSTNM.CanGrow = false;
            this.D5_CUSTNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CUSTNM"),
            new DevExpress.XtraReports.UI.XRBinding("Tag", null, "CUSTKEY")});
            this.D5_CUSTNM.Dpi = 100F;
            this.D5_CUSTNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_CUSTNM.Multiline = true;
            this.D5_CUSTNM.Name = "D5_CUSTNM";
            this.D5_CUSTNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_CUSTNM.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge;
            this.D5_CUSTNM.ProcessDuplicatesTarget = DevExpress.XtraReports.UI.ProcessDuplicatesTarget.Tag;
            this.D5_CUSTNM.Text = "";
            this.D5_CUSTNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D5_CUSTNM.WidthF = 80F;
            this.D5_CUSTNM.WordWrap = false;
            // 
            // D5_ITEMNM
            // 
            this.D5_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.D5_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_ITEMNM.BorderWidth = 0.5F;
            this.D5_ITEMNM.CanGrow = false;
            this.D5_ITEMNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMNM")});
            this.D5_ITEMNM.Dpi = 100F;
            this.D5_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_ITEMNM.Multiline = true;
            this.D5_ITEMNM.Name = "D5_ITEMNM";
            this.D5_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_ITEMNM.Text = "";
            this.D5_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D5_ITEMNM.WidthF = 105F;
            this.D5_ITEMNM.WordWrap = true;
            // 
            // D5_ITEMCD
            // 
            this.D5_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.D5_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_ITEMCD.BorderWidth = 0.5F;
            this.D5_ITEMCD.CanGrow = false;
            this.D5_ITEMCD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ITEMCD")});
            this.D5_ITEMCD.Dpi = 100F;
            this.D5_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_ITEMCD.Multiline = true;
            this.D5_ITEMCD.Name = "D5_ITEMCD";
            this.D5_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_ITEMCD.Text = "";
            this.D5_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D5_ITEMCD.WidthF = 75F;
            this.D5_ITEMCD.WordWrap = false;
            // 
            // D5_CURYNM
            // 
            this.D5_CURYNM.BorderColor = System.Drawing.Color.Black;
            this.D5_CURYNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_CURYNM.BorderWidth = 0.5F;
            this.D5_CURYNM.CanGrow = false;
            this.D5_CURYNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CURYNM")});
            this.D5_CURYNM.Dpi = 100F;
            this.D5_CURYNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_CURYNM.Multiline = true;
            this.D5_CURYNM.Name = "D5_CURYNM";
            this.D5_CURYNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_CURYNM.Text = "";
            this.D5_CURYNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D5_CURYNM.WidthF = 30F;
            this.D5_CURYNM.WordWrap = false;
            // 
            // D5_FUP
            // 
            this.D5_FUP.BorderColor = System.Drawing.Color.Black;
            this.D5_FUP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_FUP.BorderWidth = 0.5F;
            this.D5_FUP.CanGrow = false;
            this.D5_FUP.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FUP", "{0:#,##0.00}")});
            this.D5_FUP.Dpi = 100F;
            this.D5_FUP.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_FUP.Multiline = true;
            this.D5_FUP.Name = "D5_FUP";
            this.D5_FUP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_FUP.Text = "";
            this.D5_FUP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D5_FUP.WidthF = 52F;
            this.D5_FUP.WordWrap = false;
            // 
            // D5_UP
            // 
            this.D5_UP.BorderColor = System.Drawing.Color.Black;
            this.D5_UP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_UP.BorderWidth = 0.5F;
            this.D5_UP.CanGrow = false;
            this.D5_UP.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UP", "{0:#,##0}")});
            this.D5_UP.Dpi = 100F;
            this.D5_UP.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_UP.Multiline = true;
            this.D5_UP.Name = "D5_UP";
            this.D5_UP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_UP.Text = "";
            this.D5_UP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D5_UP.WidthF = 46F;
            this.D5_UP.WordWrap = false;
            // 
            // D5_PLANQTY
            // 
            this.D5_PLANQTY.BorderColor = System.Drawing.Color.Black;
            this.D5_PLANQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_PLANQTY.BorderWidth = 0.5F;
            this.D5_PLANQTY.CanGrow = false;
            this.D5_PLANQTY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PLANQTY", "{0:#,##0}")});
            this.D5_PLANQTY.Dpi = 100F;
            this.D5_PLANQTY.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_PLANQTY.Multiline = true;
            this.D5_PLANQTY.Name = "D5_PLANQTY";
            this.D5_PLANQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_PLANQTY.Text = "";
            this.D5_PLANQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D5_PLANQTY.WidthF = 50F;
            this.D5_PLANQTY.WordWrap = false;
            // 
            // D5_PLANAMT
            // 
            this.D5_PLANAMT.BorderColor = System.Drawing.Color.Black;
            this.D5_PLANAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_PLANAMT.BorderWidth = 0.5F;
            this.D5_PLANAMT.CanGrow = false;
            this.D5_PLANAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PLANAMT", "{0:#,##0}")});
            this.D5_PLANAMT.Dpi = 100F;
            this.D5_PLANAMT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_PLANAMT.Multiline = true;
            this.D5_PLANAMT.Name = "D5_PLANAMT";
            this.D5_PLANAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_PLANAMT.Text = "";
            this.D5_PLANAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D5_PLANAMT.WidthF = 80F;
            this.D5_PLANAMT.WordWrap = false;
            // 
            // D5_RSTQTY
            // 
            this.D5_RSTQTY.BorderColor = System.Drawing.Color.Black;
            this.D5_RSTQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_RSTQTY.BorderWidth = 0.5F;
            this.D5_RSTQTY.CanGrow = false;
            this.D5_RSTQTY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RSTQTY", "{0:#,##0}")});
            this.D5_RSTQTY.Dpi = 100F;
            this.D5_RSTQTY.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_RSTQTY.Multiline = true;
            this.D5_RSTQTY.Name = "D5_RSTQTY";
            this.D5_RSTQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_RSTQTY.Text = "";
            this.D5_RSTQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D5_RSTQTY.WidthF = 50F;
            this.D5_RSTQTY.WordWrap = false;
            // 
            // D5_RSTAMT
            // 
            this.D5_RSTAMT.BorderColor = System.Drawing.Color.Black;
            this.D5_RSTAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_RSTAMT.BorderWidth = 0.5F;
            this.D5_RSTAMT.CanGrow = false;
            this.D5_RSTAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RSTAMT", "{0:#,##0}")});
            this.D5_RSTAMT.Dpi = 100F;
            this.D5_RSTAMT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_RSTAMT.Multiline = true;
            this.D5_RSTAMT.Name = "D5_RSTAMT";
            this.D5_RSTAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_RSTAMT.Text = "";
            this.D5_RSTAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D5_RSTAMT.WidthF = 80F;
            this.D5_RSTAMT.WordWrap = false;
            // 
            // D5_RATE
            // 
            this.D5_RATE.BorderColor = System.Drawing.Color.Black;
            this.D5_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_RATE.BorderWidth = 0.5F;
            this.D5_RATE.CanGrow = false;
            this.D5_RATE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RATE", "{0:#,##0}%")});
            this.D5_RATE.Dpi = 100F;
            this.D5_RATE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_RATE.Multiline = true;
            this.D5_RATE.Name = "D5_RATE";
            this.D5_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_RATE.Text = "";
            this.D5_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D5_RATE.WidthF = 42F;
            this.D5_RATE.WordWrap = false;
            // 
            // D5_DIFFQTY
            // 
            this.D5_DIFFQTY.BorderColor = System.Drawing.Color.Black;
            this.D5_DIFFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_DIFFQTY.BorderWidth = 0.5F;
            this.D5_DIFFQTY.CanGrow = false;
            this.D5_DIFFQTY.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DIFFQTY", "{0:#,##0}")});
            this.D5_DIFFQTY.Dpi = 100F;
            this.D5_DIFFQTY.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_DIFFQTY.Multiline = true;
            this.D5_DIFFQTY.Name = "D5_DIFFQTY";
            this.D5_DIFFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_DIFFQTY.Text = "";
            this.D5_DIFFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D5_DIFFQTY.WidthF = 50F;
            this.D5_DIFFQTY.WordWrap = false;
            // 
            // D5_DIFFAMT
            // 
            this.D5_DIFFAMT.BorderColor = System.Drawing.Color.Black;
            this.D5_DIFFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_DIFFAMT.BorderWidth = 0.5F;
            this.D5_DIFFAMT.CanGrow = false;
            this.D5_DIFFAMT.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DIFFAMT", "{0:#,##0}")});
            this.D5_DIFFAMT.Dpi = 100F;
            this.D5_DIFFAMT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_DIFFAMT.Multiline = true;
            this.D5_DIFFAMT.Name = "D5_DIFFAMT";
            this.D5_DIFFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_DIFFAMT.Text = "";
            this.D5_DIFFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.D5_DIFFAMT.WidthF = 82F;
            this.D5_DIFFAMT.WordWrap = false;
            // 
            // D5_OUTCHGNM
            // 
            this.D5_OUTCHGNM.BorderColor = System.Drawing.Color.Black;
            this.D5_OUTCHGNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_OUTCHGNM.BorderWidth = 0.5F;
            this.D5_OUTCHGNM.CanGrow = false;
            this.D5_OUTCHGNM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OUTCHGNM")});
            this.D5_OUTCHGNM.Dpi = 100F;
            this.D5_OUTCHGNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_OUTCHGNM.Multiline = true;
            this.D5_OUTCHGNM.Name = "D5_OUTCHGNM";
            this.D5_OUTCHGNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_OUTCHGNM.Text = "";
            this.D5_OUTCHGNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.D5_OUTCHGNM.WidthF = 55F;
            this.D5_OUTCHGNM.WordWrap = false;
            // 
            // D5_NOOUTCAUSE
            // 
            this.D5_NOOUTCAUSE.BorderColor = System.Drawing.Color.Black;
            this.D5_NOOUTCAUSE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_NOOUTCAUSE.BorderWidth = 0.5F;
            this.D5_NOOUTCAUSE.CanGrow = false;
            this.D5_NOOUTCAUSE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "NOOUTCAUSE")});
            this.D5_NOOUTCAUSE.Dpi = 100F;
            this.D5_NOOUTCAUSE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_NOOUTCAUSE.Multiline = true;
            this.D5_NOOUTCAUSE.Name = "D5_NOOUTCAUSE";
            this.D5_NOOUTCAUSE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_NOOUTCAUSE.Text = "";
            this.D5_NOOUTCAUSE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D5_NOOUTCAUSE.WidthF = 80F;
            this.D5_NOOUTCAUSE.WordWrap = true;
            // 
            // D5_MEASURE
            // 
            this.D5_MEASURE.BorderColor = System.Drawing.Color.Black;
            this.D5_MEASURE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_MEASURE.BorderWidth = 0.5F;
            this.D5_MEASURE.CanGrow = false;
            this.D5_MEASURE.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MEASURE")});
            this.D5_MEASURE.Dpi = 100F;
            this.D5_MEASURE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_MEASURE.Multiline = true;
            this.D5_MEASURE.Name = "D5_MEASURE";
            this.D5_MEASURE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_MEASURE.Text = "";
            this.D5_MEASURE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D5_MEASURE.WidthF = 80F;
            this.D5_MEASURE.WordWrap = true;
            // 
            // D5_REMARK
            // 
            this.D5_REMARK.BorderColor = System.Drawing.Color.Black;
            this.D5_REMARK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.D5_REMARK.BorderWidth = 0.5F;
            this.D5_REMARK.CanGrow = false;
            this.D5_REMARK.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "REMARK")});
            this.D5_REMARK.Dpi = 100F;
            this.D5_REMARK.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.D5_REMARK.Multiline = true;
            this.D5_REMARK.Name = "D5_REMARK";
            this.D5_REMARK.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.D5_REMARK.Text = "";
            this.D5_REMARK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.D5_REMARK.WidthF = 42F;
            this.D5_REMARK.WordWrap = true;
            // 
            // T5
            // 
            this.T5.Dpi = 100F;
            this.T5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.T5.Name = "T5";
            this.T5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.R5});
            this.T5.SizeF = new System.Drawing.SizeF(1129F, 18F);
            // 
            // R5
            // 
            this.R5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.D5_DEBCNM,
            this.D5_CUSTNM,
            this.D5_ITEMNM,
            this.D5_ITEMCD,
            this.D5_CURYNM,
            this.D5_FUP,
            this.D5_UP,
            this.D5_PLANQTY,
            this.D5_PLANAMT,
            this.D5_RSTQTY,
            this.D5_RSTAMT,
            this.D5_RATE,
            this.D5_DIFFQTY,
            this.D5_DIFFAMT,
            this.D5_OUTCHGNM,
            this.D5_NOOUTCAUSE,
            this.D5_MEASURE,
            this.D5_REMARK});
            this.R5.Dpi = 100F;
            this.R5.Name = "R5";
            this.R5.Weight = 1D;
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.C_TITLE});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 40F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // RH1
            // 
            this.RH1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_T1,
            this.L_U1,
            this.H1_DEBCNM,
            this.H1_PLANAMT,
            this.H1_RSTAMT,
            this.H1_DIFFAMT,
            this.H1_RATE});
            this.RH1.Dpi = 100F;
            this.RH1.HeightF = 50F;
            this.RH1.Name = "RH1";
            this.RH1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.RH1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // D1
            // 
            this.D1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.D1_DEBCNM,
            this.D1_PLANAMT,
            this.D1_RSTAMT,
            this.D1_DIFFAMT,
            this.D1_RATE});
            this.D1.Dpi = 100F;
            this.D1.HeightF = 20F;
            this.D1.Name = "D1";
            this.D1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.D1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.D1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Row_BeforePrint);
            // 
            // RH2
            // 
            this.RH2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_T2,
            this.L_U2,
            this.H2_DEBCNM,
            this.H2_CUSTNM,
            this.H2_PLANAMT,
            this.H2_RSTAMT,
            this.H2_RATE});
            this.RH2.Dpi = 100F;
            this.RH2.HeightF = 50F;
            this.RH2.Name = "RH2";
            this.RH2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.RH2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // D2
            // 
            this.D2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.D2_DEBCNM,
            this.D2_CUSTNM,
            this.D2_PLANAMT,
            this.D2_RSTAMT,
            this.D2_RATE});
            this.D2.Dpi = 100F;
            this.D2.HeightF = 20F;
            this.D2.Name = "D2";
            this.D2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.D2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.D2.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Row_BeforePrint);
            // 
            // RH3
            // 
            this.RH3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_T3,
            this.L_U3,
            this.H3_OUTCHGNM,
            this.H3_PLANAMT,
            this.H3_RSTAMT,
            this.H3_DIFFAMT});
            this.RH3.Dpi = 100F;
            this.RH3.HeightF = 50F;
            this.RH3.Name = "RH3";
            this.RH3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.RH3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // D3
            // 
            this.D3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.D3_OUTCHGNM,
            this.D3_PLANAMT,
            this.D3_RSTAMT,
            this.D3_DIFFAMT});
            this.D3.Dpi = 100F;
            this.D3.HeightF = 20F;
            this.D3.Name = "D3";
            this.D3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.D3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.D3.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Row_BeforePrint);
            // 
            // RH4
            // 
            this.RH4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_T4,
            this.L_U4,
            this.H4_PLANAMT,
            this.H4_ADJNM,
            this.H4_ADJAMT,
            this.H4_ADJPLANAMT,
            this.H4_RSTAMT,
            this.H4_RATE});
            this.RH4.Dpi = 100F;
            this.RH4.HeightF = 50F;
            this.RH4.Name = "RH4";
            this.RH4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.RH4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // D4
            // 
            this.D4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.D4_PLANAMT,
            this.D4_ADJNM,
            this.D4_ADJAMT,
            this.D4_ADJPLANAMT,
            this.D4_RSTAMT,
            this.D4_RATE});
            this.D4.Dpi = 100F;
            this.D4.HeightF = 20F;
            this.D4.Name = "D4";
            this.D4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.D4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.D4.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Row_BeforePrint);
            // 
            // RH5
            // 
            this.RH5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.C_DETAIL_TITLE});
            this.RH5.Dpi = 100F;
            this.RH5.HeightF = 40F;
            this.RH5.Name = "RH5";
            this.RH5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.RH5.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.RH5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GH5
            // 
            this.GH5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.H5_DEBCNM,
            this.H5_CUSTNM,
            this.H5_ITEMNM,
            this.H5_ITEMCD,
            this.H5_CURYNM,
            this.H5_FUP,
            this.H5_UP,
            this.H5_G_계획,
            this.H5_PLANQTY,
            this.H5_PLANAMT,
            this.H5_G_실적,
            this.H5_RSTQTY,
            this.H5_RSTAMT,
            this.H5_RATE,
            this.H5_G_차이,
            this.H5_DIFFQTY,
            this.H5_DIFFAMT,
            this.H5_OUTCHGNM,
            this.H5_NOOUTCAUSE,
            this.H5_MEASURE,
            this.H5_REMARK});
            this.GH5.Dpi = 100F;
            this.GH5.HeightF = 36F;
            this.GH5.Name = "GH5";
            this.GH5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GH5.RepeatEveryPage = true;
            this.GH5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // D5
            // 
            this.D5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.T5});
            this.D5.Dpi = 100F;
            this.D5.HeightF = 18F;
            this.D5.Name = "D5";
            this.D5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.D5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.D5.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Row_BeforePrint);
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
            // DR1
            // 
            this.DR1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.RH1,
            this.D1});
            this.DR1.Dpi = 100F;
            this.DR1.Level = 0;
            this.DR1.Name = "DR1";
            // 
            // DR2
            // 
            this.DR2.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.RH2,
            this.D2});
            this.DR2.Dpi = 100F;
            this.DR2.Level = 1;
            this.DR2.Name = "DR2";
            // 
            // DR3
            // 
            this.DR3.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.RH3,
            this.D3});
            this.DR3.Dpi = 100F;
            this.DR3.Level = 2;
            this.DR3.Name = "DR3";
            // 
            // DR4
            // 
            this.DR4.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.RH4,
            this.D4});
            this.DR4.Dpi = 100F;
            this.DR4.Level = 3;
            this.DR4.Name = "DR4";
            // 
            // DR5
            // 
            this.DR5.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.RH5,
            this.GH5,
            this.D5});
            this.DR5.Dpi = 100F;
            this.DR5.Level = 4;
            this.DR5.Name = "DR5";
            // 
            // S02
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.Detail,
            this.DR1,
            this.DR2,
            this.DR3,
            this.DR4,
            this.DR5});
            this.Dpi = 100F;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.T5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRLabel C_TITLE;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel L_T1;
        private DevExpress.XtraReports.UI.XRLabel L_U1;
        private DevExpress.XtraReports.UI.XRLabel H1_DEBCNM;
        private DevExpress.XtraReports.UI.XRLabel H1_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel H1_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel H1_DIFFAMT;
        private DevExpress.XtraReports.UI.XRLabel H1_RATE;
        private DevExpress.XtraReports.UI.XRLabel D1_DEBCNM;
        private DevExpress.XtraReports.UI.XRLabel D1_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel D1_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel D1_DIFFAMT;
        private DevExpress.XtraReports.UI.XRLabel D1_RATE;
        private DevExpress.XtraReports.UI.ReportHeaderBand RH1;
        private DevExpress.XtraReports.UI.DetailBand D1;
        private DevExpress.XtraReports.UI.XRLabel L_T2;
        private DevExpress.XtraReports.UI.XRLabel L_U2;
        private DevExpress.XtraReports.UI.XRLabel H2_DEBCNM;
        private DevExpress.XtraReports.UI.XRLabel H2_CUSTNM;
        private DevExpress.XtraReports.UI.XRLabel H2_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel H2_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel H2_RATE;
        private DevExpress.XtraReports.UI.XRLabel D2_DEBCNM;
        private DevExpress.XtraReports.UI.XRLabel D2_CUSTNM;
        private DevExpress.XtraReports.UI.XRLabel D2_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel D2_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel D2_RATE;
        private DevExpress.XtraReports.UI.ReportHeaderBand RH2;
        private DevExpress.XtraReports.UI.DetailBand D2;
        private DevExpress.XtraReports.UI.XRLabel L_T3;
        private DevExpress.XtraReports.UI.XRLabel L_U3;
        private DevExpress.XtraReports.UI.XRLabel H3_OUTCHGNM;
        private DevExpress.XtraReports.UI.XRLabel H3_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel H3_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel H3_DIFFAMT;
        private DevExpress.XtraReports.UI.XRLabel D3_OUTCHGNM;
        private DevExpress.XtraReports.UI.XRLabel D3_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel D3_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel D3_DIFFAMT;
        private DevExpress.XtraReports.UI.ReportHeaderBand RH3;
        private DevExpress.XtraReports.UI.DetailBand D3;
        private DevExpress.XtraReports.UI.XRLabel L_T4;
        private DevExpress.XtraReports.UI.XRLabel L_U4;
        private DevExpress.XtraReports.UI.XRLabel H4_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel H4_ADJNM;
        private DevExpress.XtraReports.UI.XRLabel H4_ADJAMT;
        private DevExpress.XtraReports.UI.XRLabel H4_ADJPLANAMT;
        private DevExpress.XtraReports.UI.XRLabel H4_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel H4_RATE;
        private DevExpress.XtraReports.UI.XRLabel D4_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel D4_ADJNM;
        private DevExpress.XtraReports.UI.XRLabel D4_ADJAMT;
        private DevExpress.XtraReports.UI.XRLabel D4_ADJPLANAMT;
        private DevExpress.XtraReports.UI.XRLabel D4_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel D4_RATE;
        private DevExpress.XtraReports.UI.ReportHeaderBand RH4;
        private DevExpress.XtraReports.UI.DetailBand D4;
        private DevExpress.XtraReports.UI.XRLabel C_DETAIL_TITLE;
        private DevExpress.XtraReports.UI.XRLabel H5_DEBCNM;
        private DevExpress.XtraReports.UI.XRLabel H5_CUSTNM;
        private DevExpress.XtraReports.UI.XRLabel H5_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel H5_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel H5_CURYNM;
        private DevExpress.XtraReports.UI.XRLabel H5_FUP;
        private DevExpress.XtraReports.UI.XRLabel H5_UP;
        private DevExpress.XtraReports.UI.XRLabel H5_G_계획;
        private DevExpress.XtraReports.UI.XRLabel H5_PLANQTY;
        private DevExpress.XtraReports.UI.XRLabel H5_PLANAMT;
        private DevExpress.XtraReports.UI.XRLabel H5_G_실적;
        private DevExpress.XtraReports.UI.XRLabel H5_RSTQTY;
        private DevExpress.XtraReports.UI.XRLabel H5_RSTAMT;
        private DevExpress.XtraReports.UI.XRLabel H5_RATE;
        private DevExpress.XtraReports.UI.XRLabel H5_G_차이;
        private DevExpress.XtraReports.UI.XRLabel H5_DIFFQTY;
        private DevExpress.XtraReports.UI.XRLabel H5_DIFFAMT;
        private DevExpress.XtraReports.UI.XRLabel H5_OUTCHGNM;
        private DevExpress.XtraReports.UI.XRLabel H5_NOOUTCAUSE;
        private DevExpress.XtraReports.UI.XRLabel H5_MEASURE;
        private DevExpress.XtraReports.UI.XRLabel H5_REMARK;
        private DevExpress.XtraReports.UI.XRTableCell D5_DEBCNM;
        private DevExpress.XtraReports.UI.XRTableCell D5_CUSTNM;
        private DevExpress.XtraReports.UI.XRTableCell D5_ITEMNM;
        private DevExpress.XtraReports.UI.XRTableCell D5_ITEMCD;
        private DevExpress.XtraReports.UI.XRTableCell D5_CURYNM;
        private DevExpress.XtraReports.UI.XRTableCell D5_FUP;
        private DevExpress.XtraReports.UI.XRTableCell D5_UP;
        private DevExpress.XtraReports.UI.XRTableCell D5_PLANQTY;
        private DevExpress.XtraReports.UI.XRTableCell D5_PLANAMT;
        private DevExpress.XtraReports.UI.XRTableCell D5_RSTQTY;
        private DevExpress.XtraReports.UI.XRTableCell D5_RSTAMT;
        private DevExpress.XtraReports.UI.XRTableCell D5_RATE;
        private DevExpress.XtraReports.UI.XRTableCell D5_DIFFQTY;
        private DevExpress.XtraReports.UI.XRTableCell D5_DIFFAMT;
        private DevExpress.XtraReports.UI.XRTableCell D5_OUTCHGNM;
        private DevExpress.XtraReports.UI.XRTableCell D5_NOOUTCAUSE;
        private DevExpress.XtraReports.UI.XRTableCell D5_MEASURE;
        private DevExpress.XtraReports.UI.XRTableCell D5_REMARK;
        private DevExpress.XtraReports.UI.XRTable T5;
        private DevExpress.XtraReports.UI.XRTableRow R5;
        private DevExpress.XtraReports.UI.ReportHeaderBand RH5;
        private DevExpress.XtraReports.UI.GroupHeaderBand GH5;
        private DevExpress.XtraReports.UI.DetailBand D5;
        private DevExpress.XtraReports.UI.XRPageInfo C_PAGE;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailReportBand DR1;
        private DevExpress.XtraReports.UI.DetailReportBand DR2;
        private DevExpress.XtraReports.UI.DetailReportBand DR3;
        private DevExpress.XtraReports.UI.DetailReportBand DR4;
        private DevExpress.XtraReports.UI.DetailReportBand DR5;
    }
}
