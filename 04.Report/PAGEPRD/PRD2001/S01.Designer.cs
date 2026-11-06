namespace XtraRpt
{
    partial class S01
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

        // 생산일보 양식. C_ 로 시작하는 칸에 S01.cs 가 이름으로 값을 넣는다 (L_ 는 고정 글자).
        // 주간/야간 줄: C_{DAY|NIGHT}_{줄}_{IN|OUT|GOOD|BAD|SUM|N01~N13}, 합계: C_{DAY|NIGHT}_SUM_*, C_TOTAL_*
        // 불량현황: C_BAD_{줄}_{TP|NM|QTY}, C_BAD_SUM_QTY
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.picLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.L_TITLE_BOX = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_PRDDATE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_PRDDATE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_WORKTIME = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAYTIME = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAYTIME = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHTTIME = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHTTIME = new DevExpress.XtraReports.UI.XRLabel();
            this.L_EMP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAYEMP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAYEMP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHTEMP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHTEMP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_EQMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_EQMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ITEMNM_CHK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ITEMCD_CHK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_NON1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_NON2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_1_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_1_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_2_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_2_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_3_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_3_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_4_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_4_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_5_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_5_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_6_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_6_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_7_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_7_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_8_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_8_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAY_SUM_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_1_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_1_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_2_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_2_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_3_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_3_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_4_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_4_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_5_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_5_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_6_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_6_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_7_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_7_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_8_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_IN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_OUT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_8_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHT_SUM_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TOTAL = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_GOOD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_BAD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TOTAL_N13 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_BAD_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_BAD_H_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_BAD_H_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_BAD_H_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_1_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_1_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_1_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_2_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_2_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_2_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_3_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_3_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_3_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_4_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_4_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_4_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_5_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_5_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_5_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_6_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_6_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_6_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_7_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_7_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_7_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_8_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_8_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_8_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_9_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_9_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_9_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_10_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_10_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_10_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_11_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_11_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_11_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_12_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_12_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_12_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_13_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_13_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_13_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_14_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_14_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_14_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_15_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_15_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_15_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_16_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_16_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_16_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_17_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_17_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_17_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_18_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_18_NM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_18_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_BAD_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAD_SUM_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ISSUE_H_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ISSUE_H = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAYISSUE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAYISSUE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHTISSUE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHTISSUE = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 20F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.picLogo,
            this.L_TITLE_BOX,
            this.L_TITLE,
            this.L_PRDDATE,
            this.C_PRDDATE,
            this.L_WORKTIME,
            this.L_DAYTIME,
            this.C_DAYTIME,
            this.L_NIGHTTIME,
            this.C_NIGHTTIME,
            this.L_EMP,
            this.L_DAYEMP,
            this.C_DAYEMP,
            this.L_NIGHTEMP,
            this.C_NIGHTEMP,
            this.L_EQMNM,
            this.C_EQMNM,
            this.L_ITEMNM,
            this.C_ITEMNM,
            this.L_ITEMNM_CHK,
            this.L_ITEMCD,
            this.C_ITEMCD,
            this.L_ITEMCD_CHK,
            this.L_H_NO,
            this.L_H_IN,
            this.L_H_OUT,
            this.L_H_QTY,
            this.L_H_GOOD,
            this.L_H_BAD,
            this.L_H_SUM,
            this.L_H_NON1,
            this.L_H_NON2,
            this.L_H_N01,
            this.L_H_N02,
            this.L_H_N03,
            this.L_H_N04,
            this.L_H_N05,
            this.L_H_N06,
            this.L_H_N07,
            this.L_H_N08,
            this.L_H_N09,
            this.L_H_N10,
            this.L_H_N11,
            this.L_H_N12,
            this.L_H_N13,
            this.L_DAY_1_NO,
            this.C_DAY_1_IN,
            this.C_DAY_1_OUT,
            this.C_DAY_1_GOOD,
            this.C_DAY_1_BAD,
            this.C_DAY_1_SUM,
            this.C_DAY_1_N01,
            this.C_DAY_1_N02,
            this.C_DAY_1_N03,
            this.C_DAY_1_N04,
            this.C_DAY_1_N05,
            this.C_DAY_1_N06,
            this.C_DAY_1_N07,
            this.C_DAY_1_N08,
            this.C_DAY_1_N09,
            this.C_DAY_1_N10,
            this.C_DAY_1_N11,
            this.C_DAY_1_N12,
            this.C_DAY_1_N13,
            this.L_DAY_2_NO,
            this.C_DAY_2_IN,
            this.C_DAY_2_OUT,
            this.C_DAY_2_GOOD,
            this.C_DAY_2_BAD,
            this.C_DAY_2_SUM,
            this.C_DAY_2_N01,
            this.C_DAY_2_N02,
            this.C_DAY_2_N03,
            this.C_DAY_2_N04,
            this.C_DAY_2_N05,
            this.C_DAY_2_N06,
            this.C_DAY_2_N07,
            this.C_DAY_2_N08,
            this.C_DAY_2_N09,
            this.C_DAY_2_N10,
            this.C_DAY_2_N11,
            this.C_DAY_2_N12,
            this.C_DAY_2_N13,
            this.L_DAY_3_NO,
            this.C_DAY_3_IN,
            this.C_DAY_3_OUT,
            this.C_DAY_3_GOOD,
            this.C_DAY_3_BAD,
            this.C_DAY_3_SUM,
            this.C_DAY_3_N01,
            this.C_DAY_3_N02,
            this.C_DAY_3_N03,
            this.C_DAY_3_N04,
            this.C_DAY_3_N05,
            this.C_DAY_3_N06,
            this.C_DAY_3_N07,
            this.C_DAY_3_N08,
            this.C_DAY_3_N09,
            this.C_DAY_3_N10,
            this.C_DAY_3_N11,
            this.C_DAY_3_N12,
            this.C_DAY_3_N13,
            this.L_DAY_4_NO,
            this.C_DAY_4_IN,
            this.C_DAY_4_OUT,
            this.C_DAY_4_GOOD,
            this.C_DAY_4_BAD,
            this.C_DAY_4_SUM,
            this.C_DAY_4_N01,
            this.C_DAY_4_N02,
            this.C_DAY_4_N03,
            this.C_DAY_4_N04,
            this.C_DAY_4_N05,
            this.C_DAY_4_N06,
            this.C_DAY_4_N07,
            this.C_DAY_4_N08,
            this.C_DAY_4_N09,
            this.C_DAY_4_N10,
            this.C_DAY_4_N11,
            this.C_DAY_4_N12,
            this.C_DAY_4_N13,
            this.L_DAY_5_NO,
            this.C_DAY_5_IN,
            this.C_DAY_5_OUT,
            this.C_DAY_5_GOOD,
            this.C_DAY_5_BAD,
            this.C_DAY_5_SUM,
            this.C_DAY_5_N01,
            this.C_DAY_5_N02,
            this.C_DAY_5_N03,
            this.C_DAY_5_N04,
            this.C_DAY_5_N05,
            this.C_DAY_5_N06,
            this.C_DAY_5_N07,
            this.C_DAY_5_N08,
            this.C_DAY_5_N09,
            this.C_DAY_5_N10,
            this.C_DAY_5_N11,
            this.C_DAY_5_N12,
            this.C_DAY_5_N13,
            this.L_DAY_6_NO,
            this.C_DAY_6_IN,
            this.C_DAY_6_OUT,
            this.C_DAY_6_GOOD,
            this.C_DAY_6_BAD,
            this.C_DAY_6_SUM,
            this.C_DAY_6_N01,
            this.C_DAY_6_N02,
            this.C_DAY_6_N03,
            this.C_DAY_6_N04,
            this.C_DAY_6_N05,
            this.C_DAY_6_N06,
            this.C_DAY_6_N07,
            this.C_DAY_6_N08,
            this.C_DAY_6_N09,
            this.C_DAY_6_N10,
            this.C_DAY_6_N11,
            this.C_DAY_6_N12,
            this.C_DAY_6_N13,
            this.L_DAY_7_NO,
            this.C_DAY_7_IN,
            this.C_DAY_7_OUT,
            this.C_DAY_7_GOOD,
            this.C_DAY_7_BAD,
            this.C_DAY_7_SUM,
            this.C_DAY_7_N01,
            this.C_DAY_7_N02,
            this.C_DAY_7_N03,
            this.C_DAY_7_N04,
            this.C_DAY_7_N05,
            this.C_DAY_7_N06,
            this.C_DAY_7_N07,
            this.C_DAY_7_N08,
            this.C_DAY_7_N09,
            this.C_DAY_7_N10,
            this.C_DAY_7_N11,
            this.C_DAY_7_N12,
            this.C_DAY_7_N13,
            this.L_DAY_8_NO,
            this.C_DAY_8_IN,
            this.C_DAY_8_OUT,
            this.C_DAY_8_GOOD,
            this.C_DAY_8_BAD,
            this.C_DAY_8_SUM,
            this.C_DAY_8_N01,
            this.C_DAY_8_N02,
            this.C_DAY_8_N03,
            this.C_DAY_8_N04,
            this.C_DAY_8_N05,
            this.C_DAY_8_N06,
            this.C_DAY_8_N07,
            this.C_DAY_8_N08,
            this.C_DAY_8_N09,
            this.C_DAY_8_N10,
            this.C_DAY_8_N11,
            this.C_DAY_8_N12,
            this.C_DAY_8_N13,
            this.L_DAY_SUM,
            this.C_DAY_SUM_GOOD,
            this.C_DAY_SUM_BAD,
            this.C_DAY_SUM_SUM,
            this.C_DAY_SUM_N01,
            this.C_DAY_SUM_N02,
            this.C_DAY_SUM_N03,
            this.C_DAY_SUM_N04,
            this.C_DAY_SUM_N05,
            this.C_DAY_SUM_N06,
            this.C_DAY_SUM_N07,
            this.C_DAY_SUM_N08,
            this.C_DAY_SUM_N09,
            this.C_DAY_SUM_N10,
            this.C_DAY_SUM_N11,
            this.C_DAY_SUM_N12,
            this.C_DAY_SUM_N13,
            this.L_NIGHT_1_NO,
            this.C_NIGHT_1_IN,
            this.C_NIGHT_1_OUT,
            this.C_NIGHT_1_GOOD,
            this.C_NIGHT_1_BAD,
            this.C_NIGHT_1_SUM,
            this.C_NIGHT_1_N01,
            this.C_NIGHT_1_N02,
            this.C_NIGHT_1_N03,
            this.C_NIGHT_1_N04,
            this.C_NIGHT_1_N05,
            this.C_NIGHT_1_N06,
            this.C_NIGHT_1_N07,
            this.C_NIGHT_1_N08,
            this.C_NIGHT_1_N09,
            this.C_NIGHT_1_N10,
            this.C_NIGHT_1_N11,
            this.C_NIGHT_1_N12,
            this.C_NIGHT_1_N13,
            this.L_NIGHT_2_NO,
            this.C_NIGHT_2_IN,
            this.C_NIGHT_2_OUT,
            this.C_NIGHT_2_GOOD,
            this.C_NIGHT_2_BAD,
            this.C_NIGHT_2_SUM,
            this.C_NIGHT_2_N01,
            this.C_NIGHT_2_N02,
            this.C_NIGHT_2_N03,
            this.C_NIGHT_2_N04,
            this.C_NIGHT_2_N05,
            this.C_NIGHT_2_N06,
            this.C_NIGHT_2_N07,
            this.C_NIGHT_2_N08,
            this.C_NIGHT_2_N09,
            this.C_NIGHT_2_N10,
            this.C_NIGHT_2_N11,
            this.C_NIGHT_2_N12,
            this.C_NIGHT_2_N13,
            this.L_NIGHT_3_NO,
            this.C_NIGHT_3_IN,
            this.C_NIGHT_3_OUT,
            this.C_NIGHT_3_GOOD,
            this.C_NIGHT_3_BAD,
            this.C_NIGHT_3_SUM,
            this.C_NIGHT_3_N01,
            this.C_NIGHT_3_N02,
            this.C_NIGHT_3_N03,
            this.C_NIGHT_3_N04,
            this.C_NIGHT_3_N05,
            this.C_NIGHT_3_N06,
            this.C_NIGHT_3_N07,
            this.C_NIGHT_3_N08,
            this.C_NIGHT_3_N09,
            this.C_NIGHT_3_N10,
            this.C_NIGHT_3_N11,
            this.C_NIGHT_3_N12,
            this.C_NIGHT_3_N13,
            this.L_NIGHT_4_NO,
            this.C_NIGHT_4_IN,
            this.C_NIGHT_4_OUT,
            this.C_NIGHT_4_GOOD,
            this.C_NIGHT_4_BAD,
            this.C_NIGHT_4_SUM,
            this.C_NIGHT_4_N01,
            this.C_NIGHT_4_N02,
            this.C_NIGHT_4_N03,
            this.C_NIGHT_4_N04,
            this.C_NIGHT_4_N05,
            this.C_NIGHT_4_N06,
            this.C_NIGHT_4_N07,
            this.C_NIGHT_4_N08,
            this.C_NIGHT_4_N09,
            this.C_NIGHT_4_N10,
            this.C_NIGHT_4_N11,
            this.C_NIGHT_4_N12,
            this.C_NIGHT_4_N13,
            this.L_NIGHT_5_NO,
            this.C_NIGHT_5_IN,
            this.C_NIGHT_5_OUT,
            this.C_NIGHT_5_GOOD,
            this.C_NIGHT_5_BAD,
            this.C_NIGHT_5_SUM,
            this.C_NIGHT_5_N01,
            this.C_NIGHT_5_N02,
            this.C_NIGHT_5_N03,
            this.C_NIGHT_5_N04,
            this.C_NIGHT_5_N05,
            this.C_NIGHT_5_N06,
            this.C_NIGHT_5_N07,
            this.C_NIGHT_5_N08,
            this.C_NIGHT_5_N09,
            this.C_NIGHT_5_N10,
            this.C_NIGHT_5_N11,
            this.C_NIGHT_5_N12,
            this.C_NIGHT_5_N13,
            this.L_NIGHT_6_NO,
            this.C_NIGHT_6_IN,
            this.C_NIGHT_6_OUT,
            this.C_NIGHT_6_GOOD,
            this.C_NIGHT_6_BAD,
            this.C_NIGHT_6_SUM,
            this.C_NIGHT_6_N01,
            this.C_NIGHT_6_N02,
            this.C_NIGHT_6_N03,
            this.C_NIGHT_6_N04,
            this.C_NIGHT_6_N05,
            this.C_NIGHT_6_N06,
            this.C_NIGHT_6_N07,
            this.C_NIGHT_6_N08,
            this.C_NIGHT_6_N09,
            this.C_NIGHT_6_N10,
            this.C_NIGHT_6_N11,
            this.C_NIGHT_6_N12,
            this.C_NIGHT_6_N13,
            this.L_NIGHT_7_NO,
            this.C_NIGHT_7_IN,
            this.C_NIGHT_7_OUT,
            this.C_NIGHT_7_GOOD,
            this.C_NIGHT_7_BAD,
            this.C_NIGHT_7_SUM,
            this.C_NIGHT_7_N01,
            this.C_NIGHT_7_N02,
            this.C_NIGHT_7_N03,
            this.C_NIGHT_7_N04,
            this.C_NIGHT_7_N05,
            this.C_NIGHT_7_N06,
            this.C_NIGHT_7_N07,
            this.C_NIGHT_7_N08,
            this.C_NIGHT_7_N09,
            this.C_NIGHT_7_N10,
            this.C_NIGHT_7_N11,
            this.C_NIGHT_7_N12,
            this.C_NIGHT_7_N13,
            this.L_NIGHT_8_NO,
            this.C_NIGHT_8_IN,
            this.C_NIGHT_8_OUT,
            this.C_NIGHT_8_GOOD,
            this.C_NIGHT_8_BAD,
            this.C_NIGHT_8_SUM,
            this.C_NIGHT_8_N01,
            this.C_NIGHT_8_N02,
            this.C_NIGHT_8_N03,
            this.C_NIGHT_8_N04,
            this.C_NIGHT_8_N05,
            this.C_NIGHT_8_N06,
            this.C_NIGHT_8_N07,
            this.C_NIGHT_8_N08,
            this.C_NIGHT_8_N09,
            this.C_NIGHT_8_N10,
            this.C_NIGHT_8_N11,
            this.C_NIGHT_8_N12,
            this.C_NIGHT_8_N13,
            this.L_NIGHT_SUM,
            this.C_NIGHT_SUM_GOOD,
            this.C_NIGHT_SUM_BAD,
            this.C_NIGHT_SUM_SUM,
            this.C_NIGHT_SUM_N01,
            this.C_NIGHT_SUM_N02,
            this.C_NIGHT_SUM_N03,
            this.C_NIGHT_SUM_N04,
            this.C_NIGHT_SUM_N05,
            this.C_NIGHT_SUM_N06,
            this.C_NIGHT_SUM_N07,
            this.C_NIGHT_SUM_N08,
            this.C_NIGHT_SUM_N09,
            this.C_NIGHT_SUM_N10,
            this.C_NIGHT_SUM_N11,
            this.C_NIGHT_SUM_N12,
            this.C_NIGHT_SUM_N13,
            this.L_TOTAL,
            this.C_TOTAL_GOOD,
            this.C_TOTAL_BAD,
            this.C_TOTAL_SUM,
            this.C_TOTAL_N01,
            this.C_TOTAL_N02,
            this.C_TOTAL_N03,
            this.C_TOTAL_N04,
            this.C_TOTAL_N05,
            this.C_TOTAL_N06,
            this.C_TOTAL_N07,
            this.C_TOTAL_N08,
            this.C_TOTAL_N09,
            this.C_TOTAL_N10,
            this.C_TOTAL_N11,
            this.C_TOTAL_N12,
            this.C_TOTAL_N13,
            this.L_BAD_TITLE,
            this.L_BAD_H_TP,
            this.L_BAD_H_NM,
            this.L_BAD_H_QTY,
            this.C_BAD_1_TP,
            this.C_BAD_1_NM,
            this.C_BAD_1_QTY,
            this.C_BAD_2_TP,
            this.C_BAD_2_NM,
            this.C_BAD_2_QTY,
            this.C_BAD_3_TP,
            this.C_BAD_3_NM,
            this.C_BAD_3_QTY,
            this.C_BAD_4_TP,
            this.C_BAD_4_NM,
            this.C_BAD_4_QTY,
            this.C_BAD_5_TP,
            this.C_BAD_5_NM,
            this.C_BAD_5_QTY,
            this.C_BAD_6_TP,
            this.C_BAD_6_NM,
            this.C_BAD_6_QTY,
            this.C_BAD_7_TP,
            this.C_BAD_7_NM,
            this.C_BAD_7_QTY,
            this.C_BAD_8_TP,
            this.C_BAD_8_NM,
            this.C_BAD_8_QTY,
            this.C_BAD_9_TP,
            this.C_BAD_9_NM,
            this.C_BAD_9_QTY,
            this.C_BAD_10_TP,
            this.C_BAD_10_NM,
            this.C_BAD_10_QTY,
            this.C_BAD_11_TP,
            this.C_BAD_11_NM,
            this.C_BAD_11_QTY,
            this.C_BAD_12_TP,
            this.C_BAD_12_NM,
            this.C_BAD_12_QTY,
            this.C_BAD_13_TP,
            this.C_BAD_13_NM,
            this.C_BAD_13_QTY,
            this.C_BAD_14_TP,
            this.C_BAD_14_NM,
            this.C_BAD_14_QTY,
            this.C_BAD_15_TP,
            this.C_BAD_15_NM,
            this.C_BAD_15_QTY,
            this.C_BAD_16_TP,
            this.C_BAD_16_NM,
            this.C_BAD_16_QTY,
            this.C_BAD_17_TP,
            this.C_BAD_17_NM,
            this.C_BAD_17_QTY,
            this.C_BAD_18_TP,
            this.C_BAD_18_NM,
            this.C_BAD_18_QTY,
            this.L_BAD_SUM,
            this.C_BAD_SUM_QTY,
            this.L_ISSUE_H_TP,
            this.L_ISSUE_H,
            this.L_DAYISSUE,
            this.C_DAYISSUE,
            this.L_NIGHTISSUE,
            this.C_NIGHTISSUE});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 725F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // picLogo (이미지는 S01.cs 가 실행할 때 01.Office\images\menu\logo.png 에서 읽음)
            // 
            this.picLogo.Dpi = 100F;
            this.picLogo.LocationFloat = new DevExpress.Utils.PointFloat(10F, 5F);
            this.picLogo.Name = "picLogo";
            this.picLogo.SizeF = new System.Drawing.SizeF(150F, 40F);
            this.picLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // L_TITLE_BOX
            // 
            this.L_TITLE_BOX.BorderColor = System.Drawing.Color.Gray;
            this.L_TITLE_BOX.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_TITLE_BOX.BorderWidth = 0.5F;
            this.L_TITLE_BOX.CanGrow = false;
            this.L_TITLE_BOX.Dpi = 100F;
            this.L_TITLE_BOX.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.L_TITLE_BOX.Multiline = true;
            this.L_TITLE_BOX.Name = "L_TITLE_BOX";
            this.L_TITLE_BOX.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_TITLE_BOX.SizeF = new System.Drawing.SizeF(170F, 50F);
            this.L_TITLE_BOX.Text = "";
            this.L_TITLE_BOX.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_TITLE_BOX.WordWrap = false;
            // 
            // L_TITLE
            // 
            this.L_TITLE.BorderColor = System.Drawing.Color.Gray;
            this.L_TITLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_TITLE.BorderWidth = 0.5F;
            this.L_TITLE.CanGrow = false;
            this.L_TITLE.Dpi = 100F;
            this.L_TITLE.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold);
            this.L_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(170F, 0F);
            this.L_TITLE.Multiline = true;
            this.L_TITLE.Name = "L_TITLE";
            this.L_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_TITLE.SizeF = new System.Drawing.SizeF(730F, 50F);
            this.L_TITLE.Text = "생   산   일   보";
            this.L_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_TITLE.WordWrap = false;
            // 
            // L_PRDDATE
            // 
            this.L_PRDDATE.BorderColor = System.Drawing.Color.Gray;
            this.L_PRDDATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_PRDDATE.BorderWidth = 0.5F;
            this.L_PRDDATE.CanGrow = false;
            this.L_PRDDATE.Dpi = 100F;
            this.L_PRDDATE.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_PRDDATE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62F);
            this.L_PRDDATE.Multiline = true;
            this.L_PRDDATE.Name = "L_PRDDATE";
            this.L_PRDDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_PRDDATE.SizeF = new System.Drawing.SizeF(70F, 18F);
            this.L_PRDDATE.Text = "생 산 일";
            this.L_PRDDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_PRDDATE.WordWrap = false;
            // 
            // C_PRDDATE
            // 
            this.C_PRDDATE.BorderColor = System.Drawing.Color.Gray;
            this.C_PRDDATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_PRDDATE.BorderWidth = 0.5F;
            this.C_PRDDATE.CanGrow = false;
            this.C_PRDDATE.Dpi = 100F;
            this.C_PRDDATE.LocationFloat = new DevExpress.Utils.PointFloat(70F, 62F);
            this.C_PRDDATE.Multiline = true;
            this.C_PRDDATE.Name = "C_PRDDATE";
            this.C_PRDDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_PRDDATE.SizeF = new System.Drawing.SizeF(370F, 18F);
            this.C_PRDDATE.Text = "";
            this.C_PRDDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_PRDDATE.WordWrap = false;
            // 
            // L_WORKTIME
            // 
            this.L_WORKTIME.BorderColor = System.Drawing.Color.Gray;
            this.L_WORKTIME.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_WORKTIME.BorderWidth = 0.5F;
            this.L_WORKTIME.CanGrow = false;
            this.L_WORKTIME.Dpi = 100F;
            this.L_WORKTIME.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_WORKTIME.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80F);
            this.L_WORKTIME.Multiline = true;
            this.L_WORKTIME.Name = "L_WORKTIME";
            this.L_WORKTIME.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_WORKTIME.SizeF = new System.Drawing.SizeF(70F, 18F);
            this.L_WORKTIME.Text = "작업시간";
            this.L_WORKTIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_WORKTIME.WordWrap = false;
            // 
            // L_DAYTIME
            // 
            this.L_DAYTIME.BorderColor = System.Drawing.Color.Gray;
            this.L_DAYTIME.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAYTIME.BorderWidth = 0.5F;
            this.L_DAYTIME.CanGrow = false;
            this.L_DAYTIME.Dpi = 100F;
            this.L_DAYTIME.LocationFloat = new DevExpress.Utils.PointFloat(70F, 80F);
            this.L_DAYTIME.Multiline = true;
            this.L_DAYTIME.Name = "L_DAYTIME";
            this.L_DAYTIME.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAYTIME.SizeF = new System.Drawing.SizeF(40F, 18F);
            this.L_DAYTIME.Text = "주간";
            this.L_DAYTIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAYTIME.WordWrap = false;
            // 
            // C_DAYTIME
            // 
            this.C_DAYTIME.BorderColor = System.Drawing.Color.Gray;
            this.C_DAYTIME.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAYTIME.BorderWidth = 0.5F;
            this.C_DAYTIME.CanGrow = false;
            this.C_DAYTIME.Dpi = 100F;
            this.C_DAYTIME.LocationFloat = new DevExpress.Utils.PointFloat(110F, 80F);
            this.C_DAYTIME.Multiline = true;
            this.C_DAYTIME.Name = "C_DAYTIME";
            this.C_DAYTIME.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAYTIME.SizeF = new System.Drawing.SizeF(145F, 18F);
            this.C_DAYTIME.Text = "";
            this.C_DAYTIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAYTIME.WordWrap = false;
            // 
            // L_NIGHTTIME
            // 
            this.L_NIGHTTIME.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHTTIME.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHTTIME.BorderWidth = 0.5F;
            this.L_NIGHTTIME.CanGrow = false;
            this.L_NIGHTTIME.Dpi = 100F;
            this.L_NIGHTTIME.LocationFloat = new DevExpress.Utils.PointFloat(255F, 80F);
            this.L_NIGHTTIME.Multiline = true;
            this.L_NIGHTTIME.Name = "L_NIGHTTIME";
            this.L_NIGHTTIME.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHTTIME.SizeF = new System.Drawing.SizeF(40F, 18F);
            this.L_NIGHTTIME.Text = "야간";
            this.L_NIGHTTIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHTTIME.WordWrap = false;
            // 
            // C_NIGHTTIME
            // 
            this.C_NIGHTTIME.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHTTIME.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHTTIME.BorderWidth = 0.5F;
            this.C_NIGHTTIME.CanGrow = false;
            this.C_NIGHTTIME.Dpi = 100F;
            this.C_NIGHTTIME.LocationFloat = new DevExpress.Utils.PointFloat(295F, 80F);
            this.C_NIGHTTIME.Multiline = true;
            this.C_NIGHTTIME.Name = "C_NIGHTTIME";
            this.C_NIGHTTIME.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHTTIME.SizeF = new System.Drawing.SizeF(145F, 18F);
            this.C_NIGHTTIME.Text = "";
            this.C_NIGHTTIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHTTIME.WordWrap = false;
            // 
            // L_EMP
            // 
            this.L_EMP.BorderColor = System.Drawing.Color.Gray;
            this.L_EMP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_EMP.BorderWidth = 0.5F;
            this.L_EMP.CanGrow = false;
            this.L_EMP.Dpi = 100F;
            this.L_EMP.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_EMP.LocationFloat = new DevExpress.Utils.PointFloat(0F, 98F);
            this.L_EMP.Multiline = true;
            this.L_EMP.Name = "L_EMP";
            this.L_EMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_EMP.SizeF = new System.Drawing.SizeF(70F, 36F);
            this.L_EMP.Text = "작 업 자";
            this.L_EMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_EMP.WordWrap = false;
            // 
            // L_DAYEMP
            // 
            this.L_DAYEMP.BorderColor = System.Drawing.Color.Gray;
            this.L_DAYEMP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAYEMP.BorderWidth = 0.5F;
            this.L_DAYEMP.CanGrow = false;
            this.L_DAYEMP.Dpi = 100F;
            this.L_DAYEMP.LocationFloat = new DevExpress.Utils.PointFloat(70F, 98F);
            this.L_DAYEMP.Multiline = true;
            this.L_DAYEMP.Name = "L_DAYEMP";
            this.L_DAYEMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAYEMP.SizeF = new System.Drawing.SizeF(80F, 18F);
            this.L_DAYEMP.Text = "주  간";
            this.L_DAYEMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAYEMP.WordWrap = false;
            // 
            // C_DAYEMP
            // 
            this.C_DAYEMP.BorderColor = System.Drawing.Color.Gray;
            this.C_DAYEMP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAYEMP.BorderWidth = 0.5F;
            this.C_DAYEMP.CanGrow = false;
            this.C_DAYEMP.Dpi = 100F;
            this.C_DAYEMP.LocationFloat = new DevExpress.Utils.PointFloat(150F, 98F);
            this.C_DAYEMP.Multiline = true;
            this.C_DAYEMP.Name = "C_DAYEMP";
            this.C_DAYEMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAYEMP.SizeF = new System.Drawing.SizeF(290F, 18F);
            this.C_DAYEMP.Text = "";
            this.C_DAYEMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAYEMP.WordWrap = false;
            // 
            // L_NIGHTEMP
            // 
            this.L_NIGHTEMP.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHTEMP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHTEMP.BorderWidth = 0.5F;
            this.L_NIGHTEMP.CanGrow = false;
            this.L_NIGHTEMP.Dpi = 100F;
            this.L_NIGHTEMP.LocationFloat = new DevExpress.Utils.PointFloat(70F, 116F);
            this.L_NIGHTEMP.Multiline = true;
            this.L_NIGHTEMP.Name = "L_NIGHTEMP";
            this.L_NIGHTEMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHTEMP.SizeF = new System.Drawing.SizeF(80F, 18F);
            this.L_NIGHTEMP.Text = "야  간";
            this.L_NIGHTEMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHTEMP.WordWrap = false;
            // 
            // C_NIGHTEMP
            // 
            this.C_NIGHTEMP.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHTEMP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHTEMP.BorderWidth = 0.5F;
            this.C_NIGHTEMP.CanGrow = false;
            this.C_NIGHTEMP.Dpi = 100F;
            this.C_NIGHTEMP.LocationFloat = new DevExpress.Utils.PointFloat(150F, 116F);
            this.C_NIGHTEMP.Multiline = true;
            this.C_NIGHTEMP.Name = "C_NIGHTEMP";
            this.C_NIGHTEMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHTEMP.SizeF = new System.Drawing.SizeF(290F, 18F);
            this.C_NIGHTEMP.Text = "";
            this.C_NIGHTEMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHTEMP.WordWrap = false;
            // 
            // L_EQMNM
            // 
            this.L_EQMNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_EQMNM.BorderColor = System.Drawing.Color.Gray;
            this.L_EQMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_EQMNM.BorderWidth = 0.5F;
            this.L_EQMNM.CanGrow = false;
            this.L_EQMNM.Dpi = 100F;
            this.L_EQMNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_EQMNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 134F);
            this.L_EQMNM.Multiline = true;
            this.L_EQMNM.Name = "L_EQMNM";
            this.L_EQMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_EQMNM.SizeF = new System.Drawing.SizeF(150F, 28F);
            this.L_EQMNM.Text = "생 산 라 인";
            this.L_EQMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_EQMNM.WordWrap = false;
            // 
            // C_EQMNM
            // 
            this.C_EQMNM.BorderColor = System.Drawing.Color.Gray;
            this.C_EQMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_EQMNM.BorderWidth = 0.5F;
            this.C_EQMNM.CanGrow = false;
            this.C_EQMNM.Dpi = 100F;
            this.C_EQMNM.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.C_EQMNM.LocationFloat = new DevExpress.Utils.PointFloat(150F, 134F);
            this.C_EQMNM.Multiline = true;
            this.C_EQMNM.Name = "C_EQMNM";
            this.C_EQMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_EQMNM.SizeF = new System.Drawing.SizeF(290F, 28F);
            this.C_EQMNM.Text = "";
            this.C_EQMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_EQMNM.WordWrap = false;
            // 
            // L_ITEMNM
            // 
            this.L_ITEMNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_ITEMNM.BorderColor = System.Drawing.Color.Gray;
            this.L_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ITEMNM.BorderWidth = 0.5F;
            this.L_ITEMNM.CanGrow = false;
            this.L_ITEMNM.Dpi = 100F;
            this.L_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(440F, 62F);
            this.L_ITEMNM.Multiline = true;
            this.L_ITEMNM.Name = "L_ITEMNM";
            this.L_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_ITEMNM.SizeF = new System.Drawing.SizeF(45F, 100F);
            this.L_ITEMNM.Text = "품\r\n\r\n명";
            this.L_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ITEMNM.WordWrap = false;
            // 
            // C_ITEMNM
            // 
            this.C_ITEMNM.BorderColor = System.Drawing.Color.Gray;
            this.C_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_ITEMNM.BorderWidth = 0.5F;
            this.C_ITEMNM.CanGrow = false;
            this.C_ITEMNM.Dpi = 100F;
            this.C_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.C_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(485F, 62F);
            this.C_ITEMNM.Multiline = true;
            this.C_ITEMNM.Name = "C_ITEMNM";
            this.C_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_ITEMNM.SizeF = new System.Drawing.SizeF(300F, 100F);
            this.C_ITEMNM.Text = "";
            this.C_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_ITEMNM.WordWrap = false;
            // 
            // L_ITEMNM_CHK
            // 
            this.L_ITEMNM_CHK.BorderColor = System.Drawing.Color.Gray;
            this.L_ITEMNM_CHK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ITEMNM_CHK.BorderWidth = 0.5F;
            this.L_ITEMNM_CHK.CanGrow = false;
            this.L_ITEMNM_CHK.Dpi = 100F;
            this.L_ITEMNM_CHK.LocationFloat = new DevExpress.Utils.PointFloat(785F, 62F);
            this.L_ITEMNM_CHK.Multiline = true;
            this.L_ITEMNM_CHK.Name = "L_ITEMNM_CHK";
            this.L_ITEMNM_CHK.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_ITEMNM_CHK.SizeF = new System.Drawing.SizeF(45F, 100F);
            this.L_ITEMNM_CHK.Text = "□";
            this.L_ITEMNM_CHK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ITEMNM_CHK.WordWrap = false;
            // 
            // L_ITEMCD
            // 
            this.L_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_ITEMCD.BorderColor = System.Drawing.Color.Gray;
            this.L_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ITEMCD.BorderWidth = 0.5F;
            this.L_ITEMCD.CanGrow = false;
            this.L_ITEMCD.Dpi = 100F;
            this.L_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(830F, 62F);
            this.L_ITEMCD.Multiline = true;
            this.L_ITEMCD.Name = "L_ITEMCD";
            this.L_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_ITEMCD.SizeF = new System.Drawing.SizeF(45F, 100F);
            this.L_ITEMCD.Text = "품\r\n\r\n번";
            this.L_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ITEMCD.WordWrap = false;
            // 
            // C_ITEMCD
            // 
            this.C_ITEMCD.BorderColor = System.Drawing.Color.Gray;
            this.C_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_ITEMCD.BorderWidth = 0.5F;
            this.C_ITEMCD.CanGrow = false;
            this.C_ITEMCD.Dpi = 100F;
            this.C_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.C_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(875F, 62F);
            this.C_ITEMCD.Multiline = true;
            this.C_ITEMCD.Name = "C_ITEMCD";
            this.C_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_ITEMCD.SizeF = new System.Drawing.SizeF(209F, 100F);
            this.C_ITEMCD.Text = "";
            this.C_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_ITEMCD.WordWrap = false;
            // 
            // L_ITEMCD_CHK
            // 
            this.L_ITEMCD_CHK.BorderColor = System.Drawing.Color.Gray;
            this.L_ITEMCD_CHK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ITEMCD_CHK.BorderWidth = 0.5F;
            this.L_ITEMCD_CHK.CanGrow = false;
            this.L_ITEMCD_CHK.Dpi = 100F;
            this.L_ITEMCD_CHK.LocationFloat = new DevExpress.Utils.PointFloat(1084F, 62F);
            this.L_ITEMCD_CHK.Multiline = true;
            this.L_ITEMCD_CHK.Name = "L_ITEMCD_CHK";
            this.L_ITEMCD_CHK.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_ITEMCD_CHK.SizeF = new System.Drawing.SizeF(45F, 100F);
            this.L_ITEMCD_CHK.Text = "□";
            this.L_ITEMCD_CHK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ITEMCD_CHK.WordWrap = false;
            // 
            // L_H_NO
            // 
            this.L_H_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_H_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_NO.BorderWidth = 0.5F;
            this.L_H_NO.CanGrow = false;
            this.L_H_NO.Dpi = 100F;
            this.L_H_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 175F);
            this.L_H_NO.Multiline = true;
            this.L_H_NO.Name = "L_H_NO";
            this.L_H_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_NO.SizeF = new System.Drawing.SizeF(24F, 32F);
            this.L_H_NO.Text = "No";
            this.L_H_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_NO.WordWrap = false;
            // 
            // L_H_IN
            // 
            this.L_H_IN.BorderColor = System.Drawing.Color.Gray;
            this.L_H_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_IN.BorderWidth = 0.5F;
            this.L_H_IN.CanGrow = false;
            this.L_H_IN.Dpi = 100F;
            this.L_H_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 175F);
            this.L_H_IN.Multiline = true;
            this.L_H_IN.Name = "L_H_IN";
            this.L_H_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_IN.SizeF = new System.Drawing.SizeF(90F, 32F);
            this.L_H_IN.Text = "투입 LOT No";
            this.L_H_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_IN.WordWrap = false;
            // 
            // L_H_OUT
            // 
            this.L_H_OUT.BorderColor = System.Drawing.Color.Gray;
            this.L_H_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_OUT.BorderWidth = 0.5F;
            this.L_H_OUT.CanGrow = false;
            this.L_H_OUT.Dpi = 100F;
            this.L_H_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 175F);
            this.L_H_OUT.Multiline = true;
            this.L_H_OUT.Name = "L_H_OUT";
            this.L_H_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_OUT.SizeF = new System.Drawing.SizeF(90F, 32F);
            this.L_H_OUT.Text = "가공완료 LOT No";
            this.L_H_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_OUT.WordWrap = false;
            // 
            // L_H_QTY
            // 
            this.L_H_QTY.BorderColor = System.Drawing.Color.Gray;
            this.L_H_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_QTY.BorderWidth = 0.5F;
            this.L_H_QTY.CanGrow = false;
            this.L_H_QTY.Dpi = 100F;
            this.L_H_QTY.LocationFloat = new DevExpress.Utils.PointFloat(204F, 175F);
            this.L_H_QTY.Multiline = true;
            this.L_H_QTY.Name = "L_H_QTY";
            this.L_H_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_QTY.SizeF = new System.Drawing.SizeF(84F, 16F);
            this.L_H_QTY.Text = "생산수량";
            this.L_H_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_QTY.WordWrap = false;
            // 
            // L_H_GOOD
            // 
            this.L_H_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.L_H_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_GOOD.BorderWidth = 0.5F;
            this.L_H_GOOD.CanGrow = false;
            this.L_H_GOOD.Dpi = 100F;
            this.L_H_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 191F);
            this.L_H_GOOD.Multiline = true;
            this.L_H_GOOD.Name = "L_H_GOOD";
            this.L_H_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_GOOD.SizeF = new System.Drawing.SizeF(42F, 16F);
            this.L_H_GOOD.Text = "양품";
            this.L_H_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_GOOD.WordWrap = false;
            // 
            // L_H_BAD
            // 
            this.L_H_BAD.BorderColor = System.Drawing.Color.Gray;
            this.L_H_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_BAD.BorderWidth = 0.5F;
            this.L_H_BAD.CanGrow = false;
            this.L_H_BAD.Dpi = 100F;
            this.L_H_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 191F);
            this.L_H_BAD.Multiline = true;
            this.L_H_BAD.Name = "L_H_BAD";
            this.L_H_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_BAD.SizeF = new System.Drawing.SizeF(42F, 16F);
            this.L_H_BAD.Text = "불량";
            this.L_H_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_BAD.WordWrap = false;
            // 
            // L_H_SUM
            // 
            this.L_H_SUM.BorderColor = System.Drawing.Color.Gray;
            this.L_H_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_SUM.BorderWidth = 0.5F;
            this.L_H_SUM.CanGrow = false;
            this.L_H_SUM.Dpi = 100F;
            this.L_H_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 175F);
            this.L_H_SUM.Multiline = true;
            this.L_H_SUM.Name = "L_H_SUM";
            this.L_H_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_SUM.SizeF = new System.Drawing.SizeF(49F, 32F);
            this.L_H_SUM.Text = "합계";
            this.L_H_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_SUM.WordWrap = false;
            // 
            // L_H_NON1
            // 
            this.L_H_NON1.BorderColor = System.Drawing.Color.Gray;
            this.L_H_NON1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_NON1.BorderWidth = 0.5F;
            this.L_H_NON1.CanGrow = false;
            this.L_H_NON1.Dpi = 100F;
            this.L_H_NON1.LocationFloat = new DevExpress.Utils.PointFloat(337F, 175F);
            this.L_H_NON1.Multiline = true;
            this.L_H_NON1.Name = "L_H_NON1";
            this.L_H_NON1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_NON1.SizeF = new System.Drawing.SizeF(129F, 16F);
            this.L_H_NON1.Text = "인정 비가동";
            this.L_H_NON1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_NON1.WordWrap = false;
            // 
            // L_H_NON2
            // 
            this.L_H_NON2.BorderColor = System.Drawing.Color.Gray;
            this.L_H_NON2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_NON2.BorderWidth = 0.5F;
            this.L_H_NON2.CanGrow = false;
            this.L_H_NON2.Dpi = 100F;
            this.L_H_NON2.LocationFloat = new DevExpress.Utils.PointFloat(466F, 175F);
            this.L_H_NON2.Multiline = true;
            this.L_H_NON2.Name = "L_H_NON2";
            this.L_H_NON2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_H_NON2.SizeF = new System.Drawing.SizeF(430F, 16F);
            this.L_H_NON2.Text = "비인정 비가동";
            this.L_H_NON2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_NON2.WordWrap = false;
            // 
            // L_H_N01
            // 
            this.L_H_N01.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N01.BorderWidth = 0.5F;
            this.L_H_N01.CanGrow = false;
            this.L_H_N01.Dpi = 100F;
            this.L_H_N01.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 191F);
            this.L_H_N01.Multiline = true;
            this.L_H_N01.Name = "L_H_N01";
            this.L_H_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N01.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N01.Text = "T/O";
            this.L_H_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N01.WordWrap = false;
            // 
            // L_H_N02
            // 
            this.L_H_N02.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N02.BorderWidth = 0.5F;
            this.L_H_N02.CanGrow = false;
            this.L_H_N02.Dpi = 100F;
            this.L_H_N02.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 191F);
            this.L_H_N02.Multiline = true;
            this.L_H_N02.Name = "L_H_N02";
            this.L_H_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N02.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N02.Text = "라인지원";
            this.L_H_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N02.WordWrap = false;
            // 
            // L_H_N03
            // 
            this.L_H_N03.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N03.BorderWidth = 0.5F;
            this.L_H_N03.CanGrow = false;
            this.L_H_N03.Dpi = 100F;
            this.L_H_N03.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 191F);
            this.L_H_N03.Multiline = true;
            this.L_H_N03.Name = "L_H_N03";
            this.L_H_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N03.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N03.Text = "계획정지";
            this.L_H_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N03.WordWrap = false;
            // 
            // L_H_N04
            // 
            this.L_H_N04.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N04.BorderWidth = 0.5F;
            this.L_H_N04.CanGrow = false;
            this.L_H_N04.Dpi = 100F;
            this.L_H_N04.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 191F);
            this.L_H_N04.Multiline = true;
            this.L_H_N04.Name = "L_H_N04";
            this.L_H_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N04.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N04.Text = "조회/교육";
            this.L_H_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N04.WordWrap = false;
            // 
            // L_H_N05
            // 
            this.L_H_N05.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N05.BorderWidth = 0.5F;
            this.L_H_N05.CanGrow = false;
            this.L_H_N05.Dpi = 100F;
            this.L_H_N05.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 191F);
            this.L_H_N05.Multiline = true;
            this.L_H_N05.Name = "L_H_N05";
            this.L_H_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N05.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N05.Text = "3정5행";
            this.L_H_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N05.WordWrap = false;
            // 
            // L_H_N06
            // 
            this.L_H_N06.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N06.BorderWidth = 0.5F;
            this.L_H_N06.CanGrow = false;
            this.L_H_N06.Dpi = 100F;
            this.L_H_N06.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 191F);
            this.L_H_N06.Multiline = true;
            this.L_H_N06.Name = "L_H_N06";
            this.L_H_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N06.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N06.Text = "작업준비";
            this.L_H_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N06.WordWrap = false;
            // 
            // L_H_N07
            // 
            this.L_H_N07.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N07.BorderWidth = 0.5F;
            this.L_H_N07.CanGrow = false;
            this.L_H_N07.Dpi = 100F;
            this.L_H_N07.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 191F);
            this.L_H_N07.Multiline = true;
            this.L_H_N07.Name = "L_H_N07";
            this.L_H_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N07.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N07.Text = "S/T";
            this.L_H_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N07.WordWrap = false;
            // 
            // L_H_N08
            // 
            this.L_H_N08.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N08.BorderWidth = 0.5F;
            this.L_H_N08.CanGrow = false;
            this.L_H_N08.Dpi = 100F;
            this.L_H_N08.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 191F);
            this.L_H_N08.Multiline = true;
            this.L_H_N08.Name = "L_H_N08";
            this.L_H_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N08.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N08.Text = "설비고장";
            this.L_H_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N08.WordWrap = false;
            // 
            // L_H_N09
            // 
            this.L_H_N09.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N09.BorderWidth = 0.5F;
            this.L_H_N09.CanGrow = false;
            this.L_H_N09.Dpi = 100F;
            this.L_H_N09.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 191F);
            this.L_H_N09.Multiline = true;
            this.L_H_N09.Name = "L_H_N09";
            this.L_H_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N09.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N09.Text = "공구교환";
            this.L_H_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N09.WordWrap = false;
            // 
            // L_H_N10
            // 
            this.L_H_N10.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N10.BorderWidth = 0.5F;
            this.L_H_N10.CanGrow = false;
            this.L_H_N10.Dpi = 100F;
            this.L_H_N10.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 191F);
            this.L_H_N10.Multiline = true;
            this.L_H_N10.Name = "L_H_N10";
            this.L_H_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N10.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N10.Text = "기종교환";
            this.L_H_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N10.WordWrap = false;
            // 
            // L_H_N11
            // 
            this.L_H_N11.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N11.BorderWidth = 0.5F;
            this.L_H_N11.CanGrow = false;
            this.L_H_N11.Dpi = 100F;
            this.L_H_N11.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 191F);
            this.L_H_N11.Multiline = true;
            this.L_H_N11.Name = "L_H_N11";
            this.L_H_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N11.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N11.Text = "소재대기";
            this.L_H_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N11.WordWrap = false;
            // 
            // L_H_N12
            // 
            this.L_H_N12.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N12.BorderWidth = 0.5F;
            this.L_H_N12.CanGrow = false;
            this.L_H_N12.Dpi = 100F;
            this.L_H_N12.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 191F);
            this.L_H_N12.Multiline = true;
            this.L_H_N12.Name = "L_H_N12";
            this.L_H_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N12.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N12.Text = "측정대기";
            this.L_H_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N12.WordWrap = false;
            // 
            // L_H_N13
            // 
            this.L_H_N13.BorderColor = System.Drawing.Color.Gray;
            this.L_H_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H_N13.BorderWidth = 0.5F;
            this.L_H_N13.CanGrow = false;
            this.L_H_N13.Dpi = 100F;
            this.L_H_N13.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_H_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 191F);
            this.L_H_N13.Multiline = true;
            this.L_H_N13.Name = "L_H_N13";
            this.L_H_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_H_N13.SizeF = new System.Drawing.SizeF(43F, 16F);
            this.L_H_N13.Text = "기타";
            this.L_H_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H_N13.WordWrap = false;
            // 
            // L_DAY_1_NO
            // 
            this.L_DAY_1_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_1_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_1_NO.BorderWidth = 0.5F;
            this.L_DAY_1_NO.CanGrow = false;
            this.L_DAY_1_NO.Dpi = 100F;
            this.L_DAY_1_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 207F);
            this.L_DAY_1_NO.Multiline = true;
            this.L_DAY_1_NO.Name = "L_DAY_1_NO";
            this.L_DAY_1_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_1_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_DAY_1_NO.Text = "1";
            this.L_DAY_1_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_1_NO.WordWrap = false;
            // 
            // C_DAY_1_IN
            // 
            this.C_DAY_1_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_IN.BorderWidth = 0.5F;
            this.C_DAY_1_IN.CanGrow = false;
            this.C_DAY_1_IN.Dpi = 100F;
            this.C_DAY_1_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 207F);
            this.C_DAY_1_IN.Multiline = true;
            this.C_DAY_1_IN.Name = "C_DAY_1_IN";
            this.C_DAY_1_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_1_IN.Text = "";
            this.C_DAY_1_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_1_IN.WordWrap = false;
            // 
            // C_DAY_1_OUT
            // 
            this.C_DAY_1_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_OUT.BorderWidth = 0.5F;
            this.C_DAY_1_OUT.CanGrow = false;
            this.C_DAY_1_OUT.Dpi = 100F;
            this.C_DAY_1_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 207F);
            this.C_DAY_1_OUT.Multiline = true;
            this.C_DAY_1_OUT.Name = "C_DAY_1_OUT";
            this.C_DAY_1_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_1_OUT.Text = "";
            this.C_DAY_1_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_1_OUT.WordWrap = false;
            // 
            // C_DAY_1_GOOD
            // 
            this.C_DAY_1_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_GOOD.BorderWidth = 0.5F;
            this.C_DAY_1_GOOD.CanGrow = false;
            this.C_DAY_1_GOOD.Dpi = 100F;
            this.C_DAY_1_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 207F);
            this.C_DAY_1_GOOD.Multiline = true;
            this.C_DAY_1_GOOD.Name = "C_DAY_1_GOOD";
            this.C_DAY_1_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_1_GOOD.Text = "";
            this.C_DAY_1_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_GOOD.WordWrap = false;
            // 
            // C_DAY_1_BAD
            // 
            this.C_DAY_1_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_BAD.BorderWidth = 0.5F;
            this.C_DAY_1_BAD.CanGrow = false;
            this.C_DAY_1_BAD.Dpi = 100F;
            this.C_DAY_1_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 207F);
            this.C_DAY_1_BAD.Multiline = true;
            this.C_DAY_1_BAD.Name = "C_DAY_1_BAD";
            this.C_DAY_1_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_1_BAD.Text = "";
            this.C_DAY_1_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_BAD.WordWrap = false;
            // 
            // C_DAY_1_SUM
            // 
            this.C_DAY_1_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_SUM.BorderWidth = 0.5F;
            this.C_DAY_1_SUM.CanGrow = false;
            this.C_DAY_1_SUM.Dpi = 100F;
            this.C_DAY_1_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 207F);
            this.C_DAY_1_SUM.Multiline = true;
            this.C_DAY_1_SUM.Name = "C_DAY_1_SUM";
            this.C_DAY_1_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_1_SUM.Text = "";
            this.C_DAY_1_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_SUM.WordWrap = false;
            // 
            // C_DAY_1_N01
            // 
            this.C_DAY_1_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N01.BorderWidth = 0.5F;
            this.C_DAY_1_N01.CanGrow = false;
            this.C_DAY_1_N01.Dpi = 100F;
            this.C_DAY_1_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 207F);
            this.C_DAY_1_N01.Multiline = true;
            this.C_DAY_1_N01.Name = "C_DAY_1_N01";
            this.C_DAY_1_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N01.Text = "";
            this.C_DAY_1_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N01.WordWrap = false;
            // 
            // C_DAY_1_N02
            // 
            this.C_DAY_1_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N02.BorderWidth = 0.5F;
            this.C_DAY_1_N02.CanGrow = false;
            this.C_DAY_1_N02.Dpi = 100F;
            this.C_DAY_1_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 207F);
            this.C_DAY_1_N02.Multiline = true;
            this.C_DAY_1_N02.Name = "C_DAY_1_N02";
            this.C_DAY_1_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N02.Text = "";
            this.C_DAY_1_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N02.WordWrap = false;
            // 
            // C_DAY_1_N03
            // 
            this.C_DAY_1_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N03.BorderWidth = 0.5F;
            this.C_DAY_1_N03.CanGrow = false;
            this.C_DAY_1_N03.Dpi = 100F;
            this.C_DAY_1_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 207F);
            this.C_DAY_1_N03.Multiline = true;
            this.C_DAY_1_N03.Name = "C_DAY_1_N03";
            this.C_DAY_1_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N03.Text = "";
            this.C_DAY_1_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N03.WordWrap = false;
            // 
            // C_DAY_1_N04
            // 
            this.C_DAY_1_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N04.BorderWidth = 0.5F;
            this.C_DAY_1_N04.CanGrow = false;
            this.C_DAY_1_N04.Dpi = 100F;
            this.C_DAY_1_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 207F);
            this.C_DAY_1_N04.Multiline = true;
            this.C_DAY_1_N04.Name = "C_DAY_1_N04";
            this.C_DAY_1_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N04.Text = "";
            this.C_DAY_1_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N04.WordWrap = false;
            // 
            // C_DAY_1_N05
            // 
            this.C_DAY_1_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N05.BorderWidth = 0.5F;
            this.C_DAY_1_N05.CanGrow = false;
            this.C_DAY_1_N05.Dpi = 100F;
            this.C_DAY_1_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 207F);
            this.C_DAY_1_N05.Multiline = true;
            this.C_DAY_1_N05.Name = "C_DAY_1_N05";
            this.C_DAY_1_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N05.Text = "";
            this.C_DAY_1_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N05.WordWrap = false;
            // 
            // C_DAY_1_N06
            // 
            this.C_DAY_1_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N06.BorderWidth = 0.5F;
            this.C_DAY_1_N06.CanGrow = false;
            this.C_DAY_1_N06.Dpi = 100F;
            this.C_DAY_1_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 207F);
            this.C_DAY_1_N06.Multiline = true;
            this.C_DAY_1_N06.Name = "C_DAY_1_N06";
            this.C_DAY_1_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N06.Text = "";
            this.C_DAY_1_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N06.WordWrap = false;
            // 
            // C_DAY_1_N07
            // 
            this.C_DAY_1_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N07.BorderWidth = 0.5F;
            this.C_DAY_1_N07.CanGrow = false;
            this.C_DAY_1_N07.Dpi = 100F;
            this.C_DAY_1_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 207F);
            this.C_DAY_1_N07.Multiline = true;
            this.C_DAY_1_N07.Name = "C_DAY_1_N07";
            this.C_DAY_1_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N07.Text = "";
            this.C_DAY_1_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N07.WordWrap = false;
            // 
            // C_DAY_1_N08
            // 
            this.C_DAY_1_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N08.BorderWidth = 0.5F;
            this.C_DAY_1_N08.CanGrow = false;
            this.C_DAY_1_N08.Dpi = 100F;
            this.C_DAY_1_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 207F);
            this.C_DAY_1_N08.Multiline = true;
            this.C_DAY_1_N08.Name = "C_DAY_1_N08";
            this.C_DAY_1_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N08.Text = "";
            this.C_DAY_1_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N08.WordWrap = false;
            // 
            // C_DAY_1_N09
            // 
            this.C_DAY_1_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N09.BorderWidth = 0.5F;
            this.C_DAY_1_N09.CanGrow = false;
            this.C_DAY_1_N09.Dpi = 100F;
            this.C_DAY_1_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 207F);
            this.C_DAY_1_N09.Multiline = true;
            this.C_DAY_1_N09.Name = "C_DAY_1_N09";
            this.C_DAY_1_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N09.Text = "";
            this.C_DAY_1_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N09.WordWrap = false;
            // 
            // C_DAY_1_N10
            // 
            this.C_DAY_1_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N10.BorderWidth = 0.5F;
            this.C_DAY_1_N10.CanGrow = false;
            this.C_DAY_1_N10.Dpi = 100F;
            this.C_DAY_1_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 207F);
            this.C_DAY_1_N10.Multiline = true;
            this.C_DAY_1_N10.Name = "C_DAY_1_N10";
            this.C_DAY_1_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N10.Text = "";
            this.C_DAY_1_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N10.WordWrap = false;
            // 
            // C_DAY_1_N11
            // 
            this.C_DAY_1_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N11.BorderWidth = 0.5F;
            this.C_DAY_1_N11.CanGrow = false;
            this.C_DAY_1_N11.Dpi = 100F;
            this.C_DAY_1_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 207F);
            this.C_DAY_1_N11.Multiline = true;
            this.C_DAY_1_N11.Name = "C_DAY_1_N11";
            this.C_DAY_1_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N11.Text = "";
            this.C_DAY_1_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N11.WordWrap = false;
            // 
            // C_DAY_1_N12
            // 
            this.C_DAY_1_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N12.BorderWidth = 0.5F;
            this.C_DAY_1_N12.CanGrow = false;
            this.C_DAY_1_N12.Dpi = 100F;
            this.C_DAY_1_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 207F);
            this.C_DAY_1_N12.Multiline = true;
            this.C_DAY_1_N12.Name = "C_DAY_1_N12";
            this.C_DAY_1_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N12.Text = "";
            this.C_DAY_1_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N12.WordWrap = false;
            // 
            // C_DAY_1_N13
            // 
            this.C_DAY_1_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_1_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_1_N13.BorderWidth = 0.5F;
            this.C_DAY_1_N13.CanGrow = false;
            this.C_DAY_1_N13.Dpi = 100F;
            this.C_DAY_1_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 207F);
            this.C_DAY_1_N13.Multiline = true;
            this.C_DAY_1_N13.Name = "C_DAY_1_N13";
            this.C_DAY_1_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_1_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_1_N13.Text = "";
            this.C_DAY_1_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_1_N13.WordWrap = false;
            // 
            // L_DAY_2_NO
            // 
            this.L_DAY_2_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_2_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_2_NO.BorderWidth = 0.5F;
            this.L_DAY_2_NO.CanGrow = false;
            this.L_DAY_2_NO.Dpi = 100F;
            this.L_DAY_2_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 222F);
            this.L_DAY_2_NO.Multiline = true;
            this.L_DAY_2_NO.Name = "L_DAY_2_NO";
            this.L_DAY_2_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_2_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_DAY_2_NO.Text = "2";
            this.L_DAY_2_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_2_NO.WordWrap = false;
            // 
            // C_DAY_2_IN
            // 
            this.C_DAY_2_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_IN.BorderWidth = 0.5F;
            this.C_DAY_2_IN.CanGrow = false;
            this.C_DAY_2_IN.Dpi = 100F;
            this.C_DAY_2_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 222F);
            this.C_DAY_2_IN.Multiline = true;
            this.C_DAY_2_IN.Name = "C_DAY_2_IN";
            this.C_DAY_2_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_2_IN.Text = "";
            this.C_DAY_2_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_2_IN.WordWrap = false;
            // 
            // C_DAY_2_OUT
            // 
            this.C_DAY_2_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_OUT.BorderWidth = 0.5F;
            this.C_DAY_2_OUT.CanGrow = false;
            this.C_DAY_2_OUT.Dpi = 100F;
            this.C_DAY_2_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 222F);
            this.C_DAY_2_OUT.Multiline = true;
            this.C_DAY_2_OUT.Name = "C_DAY_2_OUT";
            this.C_DAY_2_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_2_OUT.Text = "";
            this.C_DAY_2_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_2_OUT.WordWrap = false;
            // 
            // C_DAY_2_GOOD
            // 
            this.C_DAY_2_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_GOOD.BorderWidth = 0.5F;
            this.C_DAY_2_GOOD.CanGrow = false;
            this.C_DAY_2_GOOD.Dpi = 100F;
            this.C_DAY_2_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 222F);
            this.C_DAY_2_GOOD.Multiline = true;
            this.C_DAY_2_GOOD.Name = "C_DAY_2_GOOD";
            this.C_DAY_2_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_2_GOOD.Text = "";
            this.C_DAY_2_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_GOOD.WordWrap = false;
            // 
            // C_DAY_2_BAD
            // 
            this.C_DAY_2_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_BAD.BorderWidth = 0.5F;
            this.C_DAY_2_BAD.CanGrow = false;
            this.C_DAY_2_BAD.Dpi = 100F;
            this.C_DAY_2_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 222F);
            this.C_DAY_2_BAD.Multiline = true;
            this.C_DAY_2_BAD.Name = "C_DAY_2_BAD";
            this.C_DAY_2_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_2_BAD.Text = "";
            this.C_DAY_2_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_BAD.WordWrap = false;
            // 
            // C_DAY_2_SUM
            // 
            this.C_DAY_2_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_SUM.BorderWidth = 0.5F;
            this.C_DAY_2_SUM.CanGrow = false;
            this.C_DAY_2_SUM.Dpi = 100F;
            this.C_DAY_2_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 222F);
            this.C_DAY_2_SUM.Multiline = true;
            this.C_DAY_2_SUM.Name = "C_DAY_2_SUM";
            this.C_DAY_2_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_2_SUM.Text = "";
            this.C_DAY_2_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_SUM.WordWrap = false;
            // 
            // C_DAY_2_N01
            // 
            this.C_DAY_2_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N01.BorderWidth = 0.5F;
            this.C_DAY_2_N01.CanGrow = false;
            this.C_DAY_2_N01.Dpi = 100F;
            this.C_DAY_2_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 222F);
            this.C_DAY_2_N01.Multiline = true;
            this.C_DAY_2_N01.Name = "C_DAY_2_N01";
            this.C_DAY_2_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N01.Text = "";
            this.C_DAY_2_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N01.WordWrap = false;
            // 
            // C_DAY_2_N02
            // 
            this.C_DAY_2_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N02.BorderWidth = 0.5F;
            this.C_DAY_2_N02.CanGrow = false;
            this.C_DAY_2_N02.Dpi = 100F;
            this.C_DAY_2_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 222F);
            this.C_DAY_2_N02.Multiline = true;
            this.C_DAY_2_N02.Name = "C_DAY_2_N02";
            this.C_DAY_2_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N02.Text = "";
            this.C_DAY_2_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N02.WordWrap = false;
            // 
            // C_DAY_2_N03
            // 
            this.C_DAY_2_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N03.BorderWidth = 0.5F;
            this.C_DAY_2_N03.CanGrow = false;
            this.C_DAY_2_N03.Dpi = 100F;
            this.C_DAY_2_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 222F);
            this.C_DAY_2_N03.Multiline = true;
            this.C_DAY_2_N03.Name = "C_DAY_2_N03";
            this.C_DAY_2_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N03.Text = "";
            this.C_DAY_2_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N03.WordWrap = false;
            // 
            // C_DAY_2_N04
            // 
            this.C_DAY_2_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N04.BorderWidth = 0.5F;
            this.C_DAY_2_N04.CanGrow = false;
            this.C_DAY_2_N04.Dpi = 100F;
            this.C_DAY_2_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 222F);
            this.C_DAY_2_N04.Multiline = true;
            this.C_DAY_2_N04.Name = "C_DAY_2_N04";
            this.C_DAY_2_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N04.Text = "";
            this.C_DAY_2_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N04.WordWrap = false;
            // 
            // C_DAY_2_N05
            // 
            this.C_DAY_2_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N05.BorderWidth = 0.5F;
            this.C_DAY_2_N05.CanGrow = false;
            this.C_DAY_2_N05.Dpi = 100F;
            this.C_DAY_2_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 222F);
            this.C_DAY_2_N05.Multiline = true;
            this.C_DAY_2_N05.Name = "C_DAY_2_N05";
            this.C_DAY_2_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N05.Text = "";
            this.C_DAY_2_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N05.WordWrap = false;
            // 
            // C_DAY_2_N06
            // 
            this.C_DAY_2_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N06.BorderWidth = 0.5F;
            this.C_DAY_2_N06.CanGrow = false;
            this.C_DAY_2_N06.Dpi = 100F;
            this.C_DAY_2_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 222F);
            this.C_DAY_2_N06.Multiline = true;
            this.C_DAY_2_N06.Name = "C_DAY_2_N06";
            this.C_DAY_2_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N06.Text = "";
            this.C_DAY_2_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N06.WordWrap = false;
            // 
            // C_DAY_2_N07
            // 
            this.C_DAY_2_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N07.BorderWidth = 0.5F;
            this.C_DAY_2_N07.CanGrow = false;
            this.C_DAY_2_N07.Dpi = 100F;
            this.C_DAY_2_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 222F);
            this.C_DAY_2_N07.Multiline = true;
            this.C_DAY_2_N07.Name = "C_DAY_2_N07";
            this.C_DAY_2_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N07.Text = "";
            this.C_DAY_2_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N07.WordWrap = false;
            // 
            // C_DAY_2_N08
            // 
            this.C_DAY_2_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N08.BorderWidth = 0.5F;
            this.C_DAY_2_N08.CanGrow = false;
            this.C_DAY_2_N08.Dpi = 100F;
            this.C_DAY_2_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 222F);
            this.C_DAY_2_N08.Multiline = true;
            this.C_DAY_2_N08.Name = "C_DAY_2_N08";
            this.C_DAY_2_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N08.Text = "";
            this.C_DAY_2_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N08.WordWrap = false;
            // 
            // C_DAY_2_N09
            // 
            this.C_DAY_2_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N09.BorderWidth = 0.5F;
            this.C_DAY_2_N09.CanGrow = false;
            this.C_DAY_2_N09.Dpi = 100F;
            this.C_DAY_2_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 222F);
            this.C_DAY_2_N09.Multiline = true;
            this.C_DAY_2_N09.Name = "C_DAY_2_N09";
            this.C_DAY_2_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N09.Text = "";
            this.C_DAY_2_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N09.WordWrap = false;
            // 
            // C_DAY_2_N10
            // 
            this.C_DAY_2_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N10.BorderWidth = 0.5F;
            this.C_DAY_2_N10.CanGrow = false;
            this.C_DAY_2_N10.Dpi = 100F;
            this.C_DAY_2_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 222F);
            this.C_DAY_2_N10.Multiline = true;
            this.C_DAY_2_N10.Name = "C_DAY_2_N10";
            this.C_DAY_2_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N10.Text = "";
            this.C_DAY_2_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N10.WordWrap = false;
            // 
            // C_DAY_2_N11
            // 
            this.C_DAY_2_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N11.BorderWidth = 0.5F;
            this.C_DAY_2_N11.CanGrow = false;
            this.C_DAY_2_N11.Dpi = 100F;
            this.C_DAY_2_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 222F);
            this.C_DAY_2_N11.Multiline = true;
            this.C_DAY_2_N11.Name = "C_DAY_2_N11";
            this.C_DAY_2_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N11.Text = "";
            this.C_DAY_2_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N11.WordWrap = false;
            // 
            // C_DAY_2_N12
            // 
            this.C_DAY_2_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N12.BorderWidth = 0.5F;
            this.C_DAY_2_N12.CanGrow = false;
            this.C_DAY_2_N12.Dpi = 100F;
            this.C_DAY_2_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 222F);
            this.C_DAY_2_N12.Multiline = true;
            this.C_DAY_2_N12.Name = "C_DAY_2_N12";
            this.C_DAY_2_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N12.Text = "";
            this.C_DAY_2_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N12.WordWrap = false;
            // 
            // C_DAY_2_N13
            // 
            this.C_DAY_2_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_2_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_2_N13.BorderWidth = 0.5F;
            this.C_DAY_2_N13.CanGrow = false;
            this.C_DAY_2_N13.Dpi = 100F;
            this.C_DAY_2_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 222F);
            this.C_DAY_2_N13.Multiline = true;
            this.C_DAY_2_N13.Name = "C_DAY_2_N13";
            this.C_DAY_2_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_2_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_2_N13.Text = "";
            this.C_DAY_2_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_2_N13.WordWrap = false;
            // 
            // L_DAY_3_NO
            // 
            this.L_DAY_3_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_3_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_3_NO.BorderWidth = 0.5F;
            this.L_DAY_3_NO.CanGrow = false;
            this.L_DAY_3_NO.Dpi = 100F;
            this.L_DAY_3_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 237F);
            this.L_DAY_3_NO.Multiline = true;
            this.L_DAY_3_NO.Name = "L_DAY_3_NO";
            this.L_DAY_3_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_3_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_DAY_3_NO.Text = "3";
            this.L_DAY_3_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_3_NO.WordWrap = false;
            // 
            // C_DAY_3_IN
            // 
            this.C_DAY_3_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_IN.BorderWidth = 0.5F;
            this.C_DAY_3_IN.CanGrow = false;
            this.C_DAY_3_IN.Dpi = 100F;
            this.C_DAY_3_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 237F);
            this.C_DAY_3_IN.Multiline = true;
            this.C_DAY_3_IN.Name = "C_DAY_3_IN";
            this.C_DAY_3_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_3_IN.Text = "";
            this.C_DAY_3_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_3_IN.WordWrap = false;
            // 
            // C_DAY_3_OUT
            // 
            this.C_DAY_3_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_OUT.BorderWidth = 0.5F;
            this.C_DAY_3_OUT.CanGrow = false;
            this.C_DAY_3_OUT.Dpi = 100F;
            this.C_DAY_3_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 237F);
            this.C_DAY_3_OUT.Multiline = true;
            this.C_DAY_3_OUT.Name = "C_DAY_3_OUT";
            this.C_DAY_3_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_3_OUT.Text = "";
            this.C_DAY_3_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_3_OUT.WordWrap = false;
            // 
            // C_DAY_3_GOOD
            // 
            this.C_DAY_3_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_GOOD.BorderWidth = 0.5F;
            this.C_DAY_3_GOOD.CanGrow = false;
            this.C_DAY_3_GOOD.Dpi = 100F;
            this.C_DAY_3_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 237F);
            this.C_DAY_3_GOOD.Multiline = true;
            this.C_DAY_3_GOOD.Name = "C_DAY_3_GOOD";
            this.C_DAY_3_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_3_GOOD.Text = "";
            this.C_DAY_3_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_GOOD.WordWrap = false;
            // 
            // C_DAY_3_BAD
            // 
            this.C_DAY_3_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_BAD.BorderWidth = 0.5F;
            this.C_DAY_3_BAD.CanGrow = false;
            this.C_DAY_3_BAD.Dpi = 100F;
            this.C_DAY_3_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 237F);
            this.C_DAY_3_BAD.Multiline = true;
            this.C_DAY_3_BAD.Name = "C_DAY_3_BAD";
            this.C_DAY_3_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_3_BAD.Text = "";
            this.C_DAY_3_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_BAD.WordWrap = false;
            // 
            // C_DAY_3_SUM
            // 
            this.C_DAY_3_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_SUM.BorderWidth = 0.5F;
            this.C_DAY_3_SUM.CanGrow = false;
            this.C_DAY_3_SUM.Dpi = 100F;
            this.C_DAY_3_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 237F);
            this.C_DAY_3_SUM.Multiline = true;
            this.C_DAY_3_SUM.Name = "C_DAY_3_SUM";
            this.C_DAY_3_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_3_SUM.Text = "";
            this.C_DAY_3_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_SUM.WordWrap = false;
            // 
            // C_DAY_3_N01
            // 
            this.C_DAY_3_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N01.BorderWidth = 0.5F;
            this.C_DAY_3_N01.CanGrow = false;
            this.C_DAY_3_N01.Dpi = 100F;
            this.C_DAY_3_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 237F);
            this.C_DAY_3_N01.Multiline = true;
            this.C_DAY_3_N01.Name = "C_DAY_3_N01";
            this.C_DAY_3_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N01.Text = "";
            this.C_DAY_3_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N01.WordWrap = false;
            // 
            // C_DAY_3_N02
            // 
            this.C_DAY_3_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N02.BorderWidth = 0.5F;
            this.C_DAY_3_N02.CanGrow = false;
            this.C_DAY_3_N02.Dpi = 100F;
            this.C_DAY_3_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 237F);
            this.C_DAY_3_N02.Multiline = true;
            this.C_DAY_3_N02.Name = "C_DAY_3_N02";
            this.C_DAY_3_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N02.Text = "";
            this.C_DAY_3_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N02.WordWrap = false;
            // 
            // C_DAY_3_N03
            // 
            this.C_DAY_3_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N03.BorderWidth = 0.5F;
            this.C_DAY_3_N03.CanGrow = false;
            this.C_DAY_3_N03.Dpi = 100F;
            this.C_DAY_3_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 237F);
            this.C_DAY_3_N03.Multiline = true;
            this.C_DAY_3_N03.Name = "C_DAY_3_N03";
            this.C_DAY_3_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N03.Text = "";
            this.C_DAY_3_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N03.WordWrap = false;
            // 
            // C_DAY_3_N04
            // 
            this.C_DAY_3_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N04.BorderWidth = 0.5F;
            this.C_DAY_3_N04.CanGrow = false;
            this.C_DAY_3_N04.Dpi = 100F;
            this.C_DAY_3_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 237F);
            this.C_DAY_3_N04.Multiline = true;
            this.C_DAY_3_N04.Name = "C_DAY_3_N04";
            this.C_DAY_3_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N04.Text = "";
            this.C_DAY_3_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N04.WordWrap = false;
            // 
            // C_DAY_3_N05
            // 
            this.C_DAY_3_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N05.BorderWidth = 0.5F;
            this.C_DAY_3_N05.CanGrow = false;
            this.C_DAY_3_N05.Dpi = 100F;
            this.C_DAY_3_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 237F);
            this.C_DAY_3_N05.Multiline = true;
            this.C_DAY_3_N05.Name = "C_DAY_3_N05";
            this.C_DAY_3_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N05.Text = "";
            this.C_DAY_3_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N05.WordWrap = false;
            // 
            // C_DAY_3_N06
            // 
            this.C_DAY_3_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N06.BorderWidth = 0.5F;
            this.C_DAY_3_N06.CanGrow = false;
            this.C_DAY_3_N06.Dpi = 100F;
            this.C_DAY_3_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 237F);
            this.C_DAY_3_N06.Multiline = true;
            this.C_DAY_3_N06.Name = "C_DAY_3_N06";
            this.C_DAY_3_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N06.Text = "";
            this.C_DAY_3_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N06.WordWrap = false;
            // 
            // C_DAY_3_N07
            // 
            this.C_DAY_3_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N07.BorderWidth = 0.5F;
            this.C_DAY_3_N07.CanGrow = false;
            this.C_DAY_3_N07.Dpi = 100F;
            this.C_DAY_3_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 237F);
            this.C_DAY_3_N07.Multiline = true;
            this.C_DAY_3_N07.Name = "C_DAY_3_N07";
            this.C_DAY_3_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N07.Text = "";
            this.C_DAY_3_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N07.WordWrap = false;
            // 
            // C_DAY_3_N08
            // 
            this.C_DAY_3_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N08.BorderWidth = 0.5F;
            this.C_DAY_3_N08.CanGrow = false;
            this.C_DAY_3_N08.Dpi = 100F;
            this.C_DAY_3_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 237F);
            this.C_DAY_3_N08.Multiline = true;
            this.C_DAY_3_N08.Name = "C_DAY_3_N08";
            this.C_DAY_3_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N08.Text = "";
            this.C_DAY_3_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N08.WordWrap = false;
            // 
            // C_DAY_3_N09
            // 
            this.C_DAY_3_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N09.BorderWidth = 0.5F;
            this.C_DAY_3_N09.CanGrow = false;
            this.C_DAY_3_N09.Dpi = 100F;
            this.C_DAY_3_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 237F);
            this.C_DAY_3_N09.Multiline = true;
            this.C_DAY_3_N09.Name = "C_DAY_3_N09";
            this.C_DAY_3_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N09.Text = "";
            this.C_DAY_3_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N09.WordWrap = false;
            // 
            // C_DAY_3_N10
            // 
            this.C_DAY_3_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N10.BorderWidth = 0.5F;
            this.C_DAY_3_N10.CanGrow = false;
            this.C_DAY_3_N10.Dpi = 100F;
            this.C_DAY_3_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 237F);
            this.C_DAY_3_N10.Multiline = true;
            this.C_DAY_3_N10.Name = "C_DAY_3_N10";
            this.C_DAY_3_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N10.Text = "";
            this.C_DAY_3_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N10.WordWrap = false;
            // 
            // C_DAY_3_N11
            // 
            this.C_DAY_3_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N11.BorderWidth = 0.5F;
            this.C_DAY_3_N11.CanGrow = false;
            this.C_DAY_3_N11.Dpi = 100F;
            this.C_DAY_3_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 237F);
            this.C_DAY_3_N11.Multiline = true;
            this.C_DAY_3_N11.Name = "C_DAY_3_N11";
            this.C_DAY_3_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N11.Text = "";
            this.C_DAY_3_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N11.WordWrap = false;
            // 
            // C_DAY_3_N12
            // 
            this.C_DAY_3_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N12.BorderWidth = 0.5F;
            this.C_DAY_3_N12.CanGrow = false;
            this.C_DAY_3_N12.Dpi = 100F;
            this.C_DAY_3_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 237F);
            this.C_DAY_3_N12.Multiline = true;
            this.C_DAY_3_N12.Name = "C_DAY_3_N12";
            this.C_DAY_3_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N12.Text = "";
            this.C_DAY_3_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N12.WordWrap = false;
            // 
            // C_DAY_3_N13
            // 
            this.C_DAY_3_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_3_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_3_N13.BorderWidth = 0.5F;
            this.C_DAY_3_N13.CanGrow = false;
            this.C_DAY_3_N13.Dpi = 100F;
            this.C_DAY_3_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 237F);
            this.C_DAY_3_N13.Multiline = true;
            this.C_DAY_3_N13.Name = "C_DAY_3_N13";
            this.C_DAY_3_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_3_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_3_N13.Text = "";
            this.C_DAY_3_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_3_N13.WordWrap = false;
            // 
            // L_DAY_4_NO
            // 
            this.L_DAY_4_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_4_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_4_NO.BorderWidth = 0.5F;
            this.L_DAY_4_NO.CanGrow = false;
            this.L_DAY_4_NO.Dpi = 100F;
            this.L_DAY_4_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 252F);
            this.L_DAY_4_NO.Multiline = true;
            this.L_DAY_4_NO.Name = "L_DAY_4_NO";
            this.L_DAY_4_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_4_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_DAY_4_NO.Text = "4";
            this.L_DAY_4_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_4_NO.WordWrap = false;
            // 
            // C_DAY_4_IN
            // 
            this.C_DAY_4_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_IN.BorderWidth = 0.5F;
            this.C_DAY_4_IN.CanGrow = false;
            this.C_DAY_4_IN.Dpi = 100F;
            this.C_DAY_4_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 252F);
            this.C_DAY_4_IN.Multiline = true;
            this.C_DAY_4_IN.Name = "C_DAY_4_IN";
            this.C_DAY_4_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_4_IN.Text = "";
            this.C_DAY_4_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_4_IN.WordWrap = false;
            // 
            // C_DAY_4_OUT
            // 
            this.C_DAY_4_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_OUT.BorderWidth = 0.5F;
            this.C_DAY_4_OUT.CanGrow = false;
            this.C_DAY_4_OUT.Dpi = 100F;
            this.C_DAY_4_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 252F);
            this.C_DAY_4_OUT.Multiline = true;
            this.C_DAY_4_OUT.Name = "C_DAY_4_OUT";
            this.C_DAY_4_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_4_OUT.Text = "";
            this.C_DAY_4_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_4_OUT.WordWrap = false;
            // 
            // C_DAY_4_GOOD
            // 
            this.C_DAY_4_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_GOOD.BorderWidth = 0.5F;
            this.C_DAY_4_GOOD.CanGrow = false;
            this.C_DAY_4_GOOD.Dpi = 100F;
            this.C_DAY_4_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 252F);
            this.C_DAY_4_GOOD.Multiline = true;
            this.C_DAY_4_GOOD.Name = "C_DAY_4_GOOD";
            this.C_DAY_4_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_4_GOOD.Text = "";
            this.C_DAY_4_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_GOOD.WordWrap = false;
            // 
            // C_DAY_4_BAD
            // 
            this.C_DAY_4_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_BAD.BorderWidth = 0.5F;
            this.C_DAY_4_BAD.CanGrow = false;
            this.C_DAY_4_BAD.Dpi = 100F;
            this.C_DAY_4_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 252F);
            this.C_DAY_4_BAD.Multiline = true;
            this.C_DAY_4_BAD.Name = "C_DAY_4_BAD";
            this.C_DAY_4_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_4_BAD.Text = "";
            this.C_DAY_4_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_BAD.WordWrap = false;
            // 
            // C_DAY_4_SUM
            // 
            this.C_DAY_4_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_SUM.BorderWidth = 0.5F;
            this.C_DAY_4_SUM.CanGrow = false;
            this.C_DAY_4_SUM.Dpi = 100F;
            this.C_DAY_4_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 252F);
            this.C_DAY_4_SUM.Multiline = true;
            this.C_DAY_4_SUM.Name = "C_DAY_4_SUM";
            this.C_DAY_4_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_4_SUM.Text = "";
            this.C_DAY_4_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_SUM.WordWrap = false;
            // 
            // C_DAY_4_N01
            // 
            this.C_DAY_4_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N01.BorderWidth = 0.5F;
            this.C_DAY_4_N01.CanGrow = false;
            this.C_DAY_4_N01.Dpi = 100F;
            this.C_DAY_4_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 252F);
            this.C_DAY_4_N01.Multiline = true;
            this.C_DAY_4_N01.Name = "C_DAY_4_N01";
            this.C_DAY_4_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N01.Text = "";
            this.C_DAY_4_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N01.WordWrap = false;
            // 
            // C_DAY_4_N02
            // 
            this.C_DAY_4_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N02.BorderWidth = 0.5F;
            this.C_DAY_4_N02.CanGrow = false;
            this.C_DAY_4_N02.Dpi = 100F;
            this.C_DAY_4_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 252F);
            this.C_DAY_4_N02.Multiline = true;
            this.C_DAY_4_N02.Name = "C_DAY_4_N02";
            this.C_DAY_4_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N02.Text = "";
            this.C_DAY_4_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N02.WordWrap = false;
            // 
            // C_DAY_4_N03
            // 
            this.C_DAY_4_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N03.BorderWidth = 0.5F;
            this.C_DAY_4_N03.CanGrow = false;
            this.C_DAY_4_N03.Dpi = 100F;
            this.C_DAY_4_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 252F);
            this.C_DAY_4_N03.Multiline = true;
            this.C_DAY_4_N03.Name = "C_DAY_4_N03";
            this.C_DAY_4_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N03.Text = "";
            this.C_DAY_4_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N03.WordWrap = false;
            // 
            // C_DAY_4_N04
            // 
            this.C_DAY_4_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N04.BorderWidth = 0.5F;
            this.C_DAY_4_N04.CanGrow = false;
            this.C_DAY_4_N04.Dpi = 100F;
            this.C_DAY_4_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 252F);
            this.C_DAY_4_N04.Multiline = true;
            this.C_DAY_4_N04.Name = "C_DAY_4_N04";
            this.C_DAY_4_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N04.Text = "";
            this.C_DAY_4_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N04.WordWrap = false;
            // 
            // C_DAY_4_N05
            // 
            this.C_DAY_4_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N05.BorderWidth = 0.5F;
            this.C_DAY_4_N05.CanGrow = false;
            this.C_DAY_4_N05.Dpi = 100F;
            this.C_DAY_4_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 252F);
            this.C_DAY_4_N05.Multiline = true;
            this.C_DAY_4_N05.Name = "C_DAY_4_N05";
            this.C_DAY_4_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N05.Text = "";
            this.C_DAY_4_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N05.WordWrap = false;
            // 
            // C_DAY_4_N06
            // 
            this.C_DAY_4_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N06.BorderWidth = 0.5F;
            this.C_DAY_4_N06.CanGrow = false;
            this.C_DAY_4_N06.Dpi = 100F;
            this.C_DAY_4_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 252F);
            this.C_DAY_4_N06.Multiline = true;
            this.C_DAY_4_N06.Name = "C_DAY_4_N06";
            this.C_DAY_4_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N06.Text = "";
            this.C_DAY_4_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N06.WordWrap = false;
            // 
            // C_DAY_4_N07
            // 
            this.C_DAY_4_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N07.BorderWidth = 0.5F;
            this.C_DAY_4_N07.CanGrow = false;
            this.C_DAY_4_N07.Dpi = 100F;
            this.C_DAY_4_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 252F);
            this.C_DAY_4_N07.Multiline = true;
            this.C_DAY_4_N07.Name = "C_DAY_4_N07";
            this.C_DAY_4_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N07.Text = "";
            this.C_DAY_4_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N07.WordWrap = false;
            // 
            // C_DAY_4_N08
            // 
            this.C_DAY_4_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N08.BorderWidth = 0.5F;
            this.C_DAY_4_N08.CanGrow = false;
            this.C_DAY_4_N08.Dpi = 100F;
            this.C_DAY_4_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 252F);
            this.C_DAY_4_N08.Multiline = true;
            this.C_DAY_4_N08.Name = "C_DAY_4_N08";
            this.C_DAY_4_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N08.Text = "";
            this.C_DAY_4_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N08.WordWrap = false;
            // 
            // C_DAY_4_N09
            // 
            this.C_DAY_4_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N09.BorderWidth = 0.5F;
            this.C_DAY_4_N09.CanGrow = false;
            this.C_DAY_4_N09.Dpi = 100F;
            this.C_DAY_4_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 252F);
            this.C_DAY_4_N09.Multiline = true;
            this.C_DAY_4_N09.Name = "C_DAY_4_N09";
            this.C_DAY_4_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N09.Text = "";
            this.C_DAY_4_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N09.WordWrap = false;
            // 
            // C_DAY_4_N10
            // 
            this.C_DAY_4_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N10.BorderWidth = 0.5F;
            this.C_DAY_4_N10.CanGrow = false;
            this.C_DAY_4_N10.Dpi = 100F;
            this.C_DAY_4_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 252F);
            this.C_DAY_4_N10.Multiline = true;
            this.C_DAY_4_N10.Name = "C_DAY_4_N10";
            this.C_DAY_4_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N10.Text = "";
            this.C_DAY_4_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N10.WordWrap = false;
            // 
            // C_DAY_4_N11
            // 
            this.C_DAY_4_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N11.BorderWidth = 0.5F;
            this.C_DAY_4_N11.CanGrow = false;
            this.C_DAY_4_N11.Dpi = 100F;
            this.C_DAY_4_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 252F);
            this.C_DAY_4_N11.Multiline = true;
            this.C_DAY_4_N11.Name = "C_DAY_4_N11";
            this.C_DAY_4_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N11.Text = "";
            this.C_DAY_4_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N11.WordWrap = false;
            // 
            // C_DAY_4_N12
            // 
            this.C_DAY_4_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N12.BorderWidth = 0.5F;
            this.C_DAY_4_N12.CanGrow = false;
            this.C_DAY_4_N12.Dpi = 100F;
            this.C_DAY_4_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 252F);
            this.C_DAY_4_N12.Multiline = true;
            this.C_DAY_4_N12.Name = "C_DAY_4_N12";
            this.C_DAY_4_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N12.Text = "";
            this.C_DAY_4_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N12.WordWrap = false;
            // 
            // C_DAY_4_N13
            // 
            this.C_DAY_4_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_4_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_4_N13.BorderWidth = 0.5F;
            this.C_DAY_4_N13.CanGrow = false;
            this.C_DAY_4_N13.Dpi = 100F;
            this.C_DAY_4_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 252F);
            this.C_DAY_4_N13.Multiline = true;
            this.C_DAY_4_N13.Name = "C_DAY_4_N13";
            this.C_DAY_4_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_4_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_4_N13.Text = "";
            this.C_DAY_4_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_4_N13.WordWrap = false;
            // 
            // L_DAY_5_NO
            // 
            this.L_DAY_5_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_5_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_5_NO.BorderWidth = 0.5F;
            this.L_DAY_5_NO.CanGrow = false;
            this.L_DAY_5_NO.Dpi = 100F;
            this.L_DAY_5_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 267F);
            this.L_DAY_5_NO.Multiline = true;
            this.L_DAY_5_NO.Name = "L_DAY_5_NO";
            this.L_DAY_5_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_5_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_DAY_5_NO.Text = "5";
            this.L_DAY_5_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_5_NO.WordWrap = false;
            // 
            // C_DAY_5_IN
            // 
            this.C_DAY_5_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_IN.BorderWidth = 0.5F;
            this.C_DAY_5_IN.CanGrow = false;
            this.C_DAY_5_IN.Dpi = 100F;
            this.C_DAY_5_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 267F);
            this.C_DAY_5_IN.Multiline = true;
            this.C_DAY_5_IN.Name = "C_DAY_5_IN";
            this.C_DAY_5_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_5_IN.Text = "";
            this.C_DAY_5_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_5_IN.WordWrap = false;
            // 
            // C_DAY_5_OUT
            // 
            this.C_DAY_5_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_OUT.BorderWidth = 0.5F;
            this.C_DAY_5_OUT.CanGrow = false;
            this.C_DAY_5_OUT.Dpi = 100F;
            this.C_DAY_5_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 267F);
            this.C_DAY_5_OUT.Multiline = true;
            this.C_DAY_5_OUT.Name = "C_DAY_5_OUT";
            this.C_DAY_5_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_5_OUT.Text = "";
            this.C_DAY_5_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_5_OUT.WordWrap = false;
            // 
            // C_DAY_5_GOOD
            // 
            this.C_DAY_5_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_GOOD.BorderWidth = 0.5F;
            this.C_DAY_5_GOOD.CanGrow = false;
            this.C_DAY_5_GOOD.Dpi = 100F;
            this.C_DAY_5_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 267F);
            this.C_DAY_5_GOOD.Multiline = true;
            this.C_DAY_5_GOOD.Name = "C_DAY_5_GOOD";
            this.C_DAY_5_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_5_GOOD.Text = "";
            this.C_DAY_5_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_GOOD.WordWrap = false;
            // 
            // C_DAY_5_BAD
            // 
            this.C_DAY_5_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_BAD.BorderWidth = 0.5F;
            this.C_DAY_5_BAD.CanGrow = false;
            this.C_DAY_5_BAD.Dpi = 100F;
            this.C_DAY_5_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 267F);
            this.C_DAY_5_BAD.Multiline = true;
            this.C_DAY_5_BAD.Name = "C_DAY_5_BAD";
            this.C_DAY_5_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_5_BAD.Text = "";
            this.C_DAY_5_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_BAD.WordWrap = false;
            // 
            // C_DAY_5_SUM
            // 
            this.C_DAY_5_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_SUM.BorderWidth = 0.5F;
            this.C_DAY_5_SUM.CanGrow = false;
            this.C_DAY_5_SUM.Dpi = 100F;
            this.C_DAY_5_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 267F);
            this.C_DAY_5_SUM.Multiline = true;
            this.C_DAY_5_SUM.Name = "C_DAY_5_SUM";
            this.C_DAY_5_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_5_SUM.Text = "";
            this.C_DAY_5_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_SUM.WordWrap = false;
            // 
            // C_DAY_5_N01
            // 
            this.C_DAY_5_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N01.BorderWidth = 0.5F;
            this.C_DAY_5_N01.CanGrow = false;
            this.C_DAY_5_N01.Dpi = 100F;
            this.C_DAY_5_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 267F);
            this.C_DAY_5_N01.Multiline = true;
            this.C_DAY_5_N01.Name = "C_DAY_5_N01";
            this.C_DAY_5_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N01.Text = "";
            this.C_DAY_5_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N01.WordWrap = false;
            // 
            // C_DAY_5_N02
            // 
            this.C_DAY_5_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N02.BorderWidth = 0.5F;
            this.C_DAY_5_N02.CanGrow = false;
            this.C_DAY_5_N02.Dpi = 100F;
            this.C_DAY_5_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 267F);
            this.C_DAY_5_N02.Multiline = true;
            this.C_DAY_5_N02.Name = "C_DAY_5_N02";
            this.C_DAY_5_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N02.Text = "";
            this.C_DAY_5_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N02.WordWrap = false;
            // 
            // C_DAY_5_N03
            // 
            this.C_DAY_5_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N03.BorderWidth = 0.5F;
            this.C_DAY_5_N03.CanGrow = false;
            this.C_DAY_5_N03.Dpi = 100F;
            this.C_DAY_5_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 267F);
            this.C_DAY_5_N03.Multiline = true;
            this.C_DAY_5_N03.Name = "C_DAY_5_N03";
            this.C_DAY_5_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N03.Text = "";
            this.C_DAY_5_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N03.WordWrap = false;
            // 
            // C_DAY_5_N04
            // 
            this.C_DAY_5_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N04.BorderWidth = 0.5F;
            this.C_DAY_5_N04.CanGrow = false;
            this.C_DAY_5_N04.Dpi = 100F;
            this.C_DAY_5_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 267F);
            this.C_DAY_5_N04.Multiline = true;
            this.C_DAY_5_N04.Name = "C_DAY_5_N04";
            this.C_DAY_5_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N04.Text = "";
            this.C_DAY_5_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N04.WordWrap = false;
            // 
            // C_DAY_5_N05
            // 
            this.C_DAY_5_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N05.BorderWidth = 0.5F;
            this.C_DAY_5_N05.CanGrow = false;
            this.C_DAY_5_N05.Dpi = 100F;
            this.C_DAY_5_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 267F);
            this.C_DAY_5_N05.Multiline = true;
            this.C_DAY_5_N05.Name = "C_DAY_5_N05";
            this.C_DAY_5_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N05.Text = "";
            this.C_DAY_5_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N05.WordWrap = false;
            // 
            // C_DAY_5_N06
            // 
            this.C_DAY_5_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N06.BorderWidth = 0.5F;
            this.C_DAY_5_N06.CanGrow = false;
            this.C_DAY_5_N06.Dpi = 100F;
            this.C_DAY_5_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 267F);
            this.C_DAY_5_N06.Multiline = true;
            this.C_DAY_5_N06.Name = "C_DAY_5_N06";
            this.C_DAY_5_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N06.Text = "";
            this.C_DAY_5_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N06.WordWrap = false;
            // 
            // C_DAY_5_N07
            // 
            this.C_DAY_5_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N07.BorderWidth = 0.5F;
            this.C_DAY_5_N07.CanGrow = false;
            this.C_DAY_5_N07.Dpi = 100F;
            this.C_DAY_5_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 267F);
            this.C_DAY_5_N07.Multiline = true;
            this.C_DAY_5_N07.Name = "C_DAY_5_N07";
            this.C_DAY_5_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N07.Text = "";
            this.C_DAY_5_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N07.WordWrap = false;
            // 
            // C_DAY_5_N08
            // 
            this.C_DAY_5_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N08.BorderWidth = 0.5F;
            this.C_DAY_5_N08.CanGrow = false;
            this.C_DAY_5_N08.Dpi = 100F;
            this.C_DAY_5_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 267F);
            this.C_DAY_5_N08.Multiline = true;
            this.C_DAY_5_N08.Name = "C_DAY_5_N08";
            this.C_DAY_5_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N08.Text = "";
            this.C_DAY_5_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N08.WordWrap = false;
            // 
            // C_DAY_5_N09
            // 
            this.C_DAY_5_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N09.BorderWidth = 0.5F;
            this.C_DAY_5_N09.CanGrow = false;
            this.C_DAY_5_N09.Dpi = 100F;
            this.C_DAY_5_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 267F);
            this.C_DAY_5_N09.Multiline = true;
            this.C_DAY_5_N09.Name = "C_DAY_5_N09";
            this.C_DAY_5_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N09.Text = "";
            this.C_DAY_5_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N09.WordWrap = false;
            // 
            // C_DAY_5_N10
            // 
            this.C_DAY_5_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N10.BorderWidth = 0.5F;
            this.C_DAY_5_N10.CanGrow = false;
            this.C_DAY_5_N10.Dpi = 100F;
            this.C_DAY_5_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 267F);
            this.C_DAY_5_N10.Multiline = true;
            this.C_DAY_5_N10.Name = "C_DAY_5_N10";
            this.C_DAY_5_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N10.Text = "";
            this.C_DAY_5_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N10.WordWrap = false;
            // 
            // C_DAY_5_N11
            // 
            this.C_DAY_5_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N11.BorderWidth = 0.5F;
            this.C_DAY_5_N11.CanGrow = false;
            this.C_DAY_5_N11.Dpi = 100F;
            this.C_DAY_5_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 267F);
            this.C_DAY_5_N11.Multiline = true;
            this.C_DAY_5_N11.Name = "C_DAY_5_N11";
            this.C_DAY_5_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N11.Text = "";
            this.C_DAY_5_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N11.WordWrap = false;
            // 
            // C_DAY_5_N12
            // 
            this.C_DAY_5_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N12.BorderWidth = 0.5F;
            this.C_DAY_5_N12.CanGrow = false;
            this.C_DAY_5_N12.Dpi = 100F;
            this.C_DAY_5_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 267F);
            this.C_DAY_5_N12.Multiline = true;
            this.C_DAY_5_N12.Name = "C_DAY_5_N12";
            this.C_DAY_5_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N12.Text = "";
            this.C_DAY_5_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N12.WordWrap = false;
            // 
            // C_DAY_5_N13
            // 
            this.C_DAY_5_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_5_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_5_N13.BorderWidth = 0.5F;
            this.C_DAY_5_N13.CanGrow = false;
            this.C_DAY_5_N13.Dpi = 100F;
            this.C_DAY_5_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 267F);
            this.C_DAY_5_N13.Multiline = true;
            this.C_DAY_5_N13.Name = "C_DAY_5_N13";
            this.C_DAY_5_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_5_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_5_N13.Text = "";
            this.C_DAY_5_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_5_N13.WordWrap = false;
            // 
            // L_DAY_6_NO
            // 
            this.L_DAY_6_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_6_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_6_NO.BorderWidth = 0.5F;
            this.L_DAY_6_NO.CanGrow = false;
            this.L_DAY_6_NO.Dpi = 100F;
            this.L_DAY_6_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 282F);
            this.L_DAY_6_NO.Multiline = true;
            this.L_DAY_6_NO.Name = "L_DAY_6_NO";
            this.L_DAY_6_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_6_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_DAY_6_NO.Text = "6";
            this.L_DAY_6_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_6_NO.WordWrap = false;
            // 
            // C_DAY_6_IN
            // 
            this.C_DAY_6_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_IN.BorderWidth = 0.5F;
            this.C_DAY_6_IN.CanGrow = false;
            this.C_DAY_6_IN.Dpi = 100F;
            this.C_DAY_6_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 282F);
            this.C_DAY_6_IN.Multiline = true;
            this.C_DAY_6_IN.Name = "C_DAY_6_IN";
            this.C_DAY_6_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_6_IN.Text = "";
            this.C_DAY_6_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_6_IN.WordWrap = false;
            // 
            // C_DAY_6_OUT
            // 
            this.C_DAY_6_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_OUT.BorderWidth = 0.5F;
            this.C_DAY_6_OUT.CanGrow = false;
            this.C_DAY_6_OUT.Dpi = 100F;
            this.C_DAY_6_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 282F);
            this.C_DAY_6_OUT.Multiline = true;
            this.C_DAY_6_OUT.Name = "C_DAY_6_OUT";
            this.C_DAY_6_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_6_OUT.Text = "";
            this.C_DAY_6_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_6_OUT.WordWrap = false;
            // 
            // C_DAY_6_GOOD
            // 
            this.C_DAY_6_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_GOOD.BorderWidth = 0.5F;
            this.C_DAY_6_GOOD.CanGrow = false;
            this.C_DAY_6_GOOD.Dpi = 100F;
            this.C_DAY_6_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 282F);
            this.C_DAY_6_GOOD.Multiline = true;
            this.C_DAY_6_GOOD.Name = "C_DAY_6_GOOD";
            this.C_DAY_6_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_6_GOOD.Text = "";
            this.C_DAY_6_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_GOOD.WordWrap = false;
            // 
            // C_DAY_6_BAD
            // 
            this.C_DAY_6_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_BAD.BorderWidth = 0.5F;
            this.C_DAY_6_BAD.CanGrow = false;
            this.C_DAY_6_BAD.Dpi = 100F;
            this.C_DAY_6_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 282F);
            this.C_DAY_6_BAD.Multiline = true;
            this.C_DAY_6_BAD.Name = "C_DAY_6_BAD";
            this.C_DAY_6_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_6_BAD.Text = "";
            this.C_DAY_6_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_BAD.WordWrap = false;
            // 
            // C_DAY_6_SUM
            // 
            this.C_DAY_6_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_SUM.BorderWidth = 0.5F;
            this.C_DAY_6_SUM.CanGrow = false;
            this.C_DAY_6_SUM.Dpi = 100F;
            this.C_DAY_6_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 282F);
            this.C_DAY_6_SUM.Multiline = true;
            this.C_DAY_6_SUM.Name = "C_DAY_6_SUM";
            this.C_DAY_6_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_6_SUM.Text = "";
            this.C_DAY_6_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_SUM.WordWrap = false;
            // 
            // C_DAY_6_N01
            // 
            this.C_DAY_6_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N01.BorderWidth = 0.5F;
            this.C_DAY_6_N01.CanGrow = false;
            this.C_DAY_6_N01.Dpi = 100F;
            this.C_DAY_6_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 282F);
            this.C_DAY_6_N01.Multiline = true;
            this.C_DAY_6_N01.Name = "C_DAY_6_N01";
            this.C_DAY_6_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N01.Text = "";
            this.C_DAY_6_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N01.WordWrap = false;
            // 
            // C_DAY_6_N02
            // 
            this.C_DAY_6_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N02.BorderWidth = 0.5F;
            this.C_DAY_6_N02.CanGrow = false;
            this.C_DAY_6_N02.Dpi = 100F;
            this.C_DAY_6_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 282F);
            this.C_DAY_6_N02.Multiline = true;
            this.C_DAY_6_N02.Name = "C_DAY_6_N02";
            this.C_DAY_6_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N02.Text = "";
            this.C_DAY_6_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N02.WordWrap = false;
            // 
            // C_DAY_6_N03
            // 
            this.C_DAY_6_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N03.BorderWidth = 0.5F;
            this.C_DAY_6_N03.CanGrow = false;
            this.C_DAY_6_N03.Dpi = 100F;
            this.C_DAY_6_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 282F);
            this.C_DAY_6_N03.Multiline = true;
            this.C_DAY_6_N03.Name = "C_DAY_6_N03";
            this.C_DAY_6_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N03.Text = "";
            this.C_DAY_6_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N03.WordWrap = false;
            // 
            // C_DAY_6_N04
            // 
            this.C_DAY_6_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N04.BorderWidth = 0.5F;
            this.C_DAY_6_N04.CanGrow = false;
            this.C_DAY_6_N04.Dpi = 100F;
            this.C_DAY_6_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 282F);
            this.C_DAY_6_N04.Multiline = true;
            this.C_DAY_6_N04.Name = "C_DAY_6_N04";
            this.C_DAY_6_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N04.Text = "";
            this.C_DAY_6_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N04.WordWrap = false;
            // 
            // C_DAY_6_N05
            // 
            this.C_DAY_6_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N05.BorderWidth = 0.5F;
            this.C_DAY_6_N05.CanGrow = false;
            this.C_DAY_6_N05.Dpi = 100F;
            this.C_DAY_6_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 282F);
            this.C_DAY_6_N05.Multiline = true;
            this.C_DAY_6_N05.Name = "C_DAY_6_N05";
            this.C_DAY_6_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N05.Text = "";
            this.C_DAY_6_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N05.WordWrap = false;
            // 
            // C_DAY_6_N06
            // 
            this.C_DAY_6_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N06.BorderWidth = 0.5F;
            this.C_DAY_6_N06.CanGrow = false;
            this.C_DAY_6_N06.Dpi = 100F;
            this.C_DAY_6_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 282F);
            this.C_DAY_6_N06.Multiline = true;
            this.C_DAY_6_N06.Name = "C_DAY_6_N06";
            this.C_DAY_6_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N06.Text = "";
            this.C_DAY_6_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N06.WordWrap = false;
            // 
            // C_DAY_6_N07
            // 
            this.C_DAY_6_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N07.BorderWidth = 0.5F;
            this.C_DAY_6_N07.CanGrow = false;
            this.C_DAY_6_N07.Dpi = 100F;
            this.C_DAY_6_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 282F);
            this.C_DAY_6_N07.Multiline = true;
            this.C_DAY_6_N07.Name = "C_DAY_6_N07";
            this.C_DAY_6_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N07.Text = "";
            this.C_DAY_6_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N07.WordWrap = false;
            // 
            // C_DAY_6_N08
            // 
            this.C_DAY_6_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N08.BorderWidth = 0.5F;
            this.C_DAY_6_N08.CanGrow = false;
            this.C_DAY_6_N08.Dpi = 100F;
            this.C_DAY_6_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 282F);
            this.C_DAY_6_N08.Multiline = true;
            this.C_DAY_6_N08.Name = "C_DAY_6_N08";
            this.C_DAY_6_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N08.Text = "";
            this.C_DAY_6_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N08.WordWrap = false;
            // 
            // C_DAY_6_N09
            // 
            this.C_DAY_6_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N09.BorderWidth = 0.5F;
            this.C_DAY_6_N09.CanGrow = false;
            this.C_DAY_6_N09.Dpi = 100F;
            this.C_DAY_6_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 282F);
            this.C_DAY_6_N09.Multiline = true;
            this.C_DAY_6_N09.Name = "C_DAY_6_N09";
            this.C_DAY_6_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N09.Text = "";
            this.C_DAY_6_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N09.WordWrap = false;
            // 
            // C_DAY_6_N10
            // 
            this.C_DAY_6_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N10.BorderWidth = 0.5F;
            this.C_DAY_6_N10.CanGrow = false;
            this.C_DAY_6_N10.Dpi = 100F;
            this.C_DAY_6_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 282F);
            this.C_DAY_6_N10.Multiline = true;
            this.C_DAY_6_N10.Name = "C_DAY_6_N10";
            this.C_DAY_6_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N10.Text = "";
            this.C_DAY_6_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N10.WordWrap = false;
            // 
            // C_DAY_6_N11
            // 
            this.C_DAY_6_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N11.BorderWidth = 0.5F;
            this.C_DAY_6_N11.CanGrow = false;
            this.C_DAY_6_N11.Dpi = 100F;
            this.C_DAY_6_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 282F);
            this.C_DAY_6_N11.Multiline = true;
            this.C_DAY_6_N11.Name = "C_DAY_6_N11";
            this.C_DAY_6_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N11.Text = "";
            this.C_DAY_6_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N11.WordWrap = false;
            // 
            // C_DAY_6_N12
            // 
            this.C_DAY_6_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N12.BorderWidth = 0.5F;
            this.C_DAY_6_N12.CanGrow = false;
            this.C_DAY_6_N12.Dpi = 100F;
            this.C_DAY_6_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 282F);
            this.C_DAY_6_N12.Multiline = true;
            this.C_DAY_6_N12.Name = "C_DAY_6_N12";
            this.C_DAY_6_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N12.Text = "";
            this.C_DAY_6_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N12.WordWrap = false;
            // 
            // C_DAY_6_N13
            // 
            this.C_DAY_6_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_6_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_6_N13.BorderWidth = 0.5F;
            this.C_DAY_6_N13.CanGrow = false;
            this.C_DAY_6_N13.Dpi = 100F;
            this.C_DAY_6_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 282F);
            this.C_DAY_6_N13.Multiline = true;
            this.C_DAY_6_N13.Name = "C_DAY_6_N13";
            this.C_DAY_6_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_6_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_6_N13.Text = "";
            this.C_DAY_6_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_6_N13.WordWrap = false;
            // 
            // L_DAY_7_NO
            // 
            this.L_DAY_7_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_7_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_7_NO.BorderWidth = 0.5F;
            this.L_DAY_7_NO.CanGrow = false;
            this.L_DAY_7_NO.Dpi = 100F;
            this.L_DAY_7_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 297F);
            this.L_DAY_7_NO.Multiline = true;
            this.L_DAY_7_NO.Name = "L_DAY_7_NO";
            this.L_DAY_7_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_7_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_DAY_7_NO.Text = "7";
            this.L_DAY_7_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_7_NO.WordWrap = false;
            // 
            // C_DAY_7_IN
            // 
            this.C_DAY_7_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_IN.BorderWidth = 0.5F;
            this.C_DAY_7_IN.CanGrow = false;
            this.C_DAY_7_IN.Dpi = 100F;
            this.C_DAY_7_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 297F);
            this.C_DAY_7_IN.Multiline = true;
            this.C_DAY_7_IN.Name = "C_DAY_7_IN";
            this.C_DAY_7_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_7_IN.Text = "";
            this.C_DAY_7_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_7_IN.WordWrap = false;
            // 
            // C_DAY_7_OUT
            // 
            this.C_DAY_7_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_OUT.BorderWidth = 0.5F;
            this.C_DAY_7_OUT.CanGrow = false;
            this.C_DAY_7_OUT.Dpi = 100F;
            this.C_DAY_7_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 297F);
            this.C_DAY_7_OUT.Multiline = true;
            this.C_DAY_7_OUT.Name = "C_DAY_7_OUT";
            this.C_DAY_7_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_7_OUT.Text = "";
            this.C_DAY_7_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_7_OUT.WordWrap = false;
            // 
            // C_DAY_7_GOOD
            // 
            this.C_DAY_7_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_GOOD.BorderWidth = 0.5F;
            this.C_DAY_7_GOOD.CanGrow = false;
            this.C_DAY_7_GOOD.Dpi = 100F;
            this.C_DAY_7_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 297F);
            this.C_DAY_7_GOOD.Multiline = true;
            this.C_DAY_7_GOOD.Name = "C_DAY_7_GOOD";
            this.C_DAY_7_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_7_GOOD.Text = "";
            this.C_DAY_7_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_GOOD.WordWrap = false;
            // 
            // C_DAY_7_BAD
            // 
            this.C_DAY_7_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_BAD.BorderWidth = 0.5F;
            this.C_DAY_7_BAD.CanGrow = false;
            this.C_DAY_7_BAD.Dpi = 100F;
            this.C_DAY_7_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 297F);
            this.C_DAY_7_BAD.Multiline = true;
            this.C_DAY_7_BAD.Name = "C_DAY_7_BAD";
            this.C_DAY_7_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_7_BAD.Text = "";
            this.C_DAY_7_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_BAD.WordWrap = false;
            // 
            // C_DAY_7_SUM
            // 
            this.C_DAY_7_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_SUM.BorderWidth = 0.5F;
            this.C_DAY_7_SUM.CanGrow = false;
            this.C_DAY_7_SUM.Dpi = 100F;
            this.C_DAY_7_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 297F);
            this.C_DAY_7_SUM.Multiline = true;
            this.C_DAY_7_SUM.Name = "C_DAY_7_SUM";
            this.C_DAY_7_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_7_SUM.Text = "";
            this.C_DAY_7_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_SUM.WordWrap = false;
            // 
            // C_DAY_7_N01
            // 
            this.C_DAY_7_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N01.BorderWidth = 0.5F;
            this.C_DAY_7_N01.CanGrow = false;
            this.C_DAY_7_N01.Dpi = 100F;
            this.C_DAY_7_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 297F);
            this.C_DAY_7_N01.Multiline = true;
            this.C_DAY_7_N01.Name = "C_DAY_7_N01";
            this.C_DAY_7_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N01.Text = "";
            this.C_DAY_7_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N01.WordWrap = false;
            // 
            // C_DAY_7_N02
            // 
            this.C_DAY_7_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N02.BorderWidth = 0.5F;
            this.C_DAY_7_N02.CanGrow = false;
            this.C_DAY_7_N02.Dpi = 100F;
            this.C_DAY_7_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 297F);
            this.C_DAY_7_N02.Multiline = true;
            this.C_DAY_7_N02.Name = "C_DAY_7_N02";
            this.C_DAY_7_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N02.Text = "";
            this.C_DAY_7_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N02.WordWrap = false;
            // 
            // C_DAY_7_N03
            // 
            this.C_DAY_7_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N03.BorderWidth = 0.5F;
            this.C_DAY_7_N03.CanGrow = false;
            this.C_DAY_7_N03.Dpi = 100F;
            this.C_DAY_7_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 297F);
            this.C_DAY_7_N03.Multiline = true;
            this.C_DAY_7_N03.Name = "C_DAY_7_N03";
            this.C_DAY_7_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N03.Text = "";
            this.C_DAY_7_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N03.WordWrap = false;
            // 
            // C_DAY_7_N04
            // 
            this.C_DAY_7_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N04.BorderWidth = 0.5F;
            this.C_DAY_7_N04.CanGrow = false;
            this.C_DAY_7_N04.Dpi = 100F;
            this.C_DAY_7_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 297F);
            this.C_DAY_7_N04.Multiline = true;
            this.C_DAY_7_N04.Name = "C_DAY_7_N04";
            this.C_DAY_7_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N04.Text = "";
            this.C_DAY_7_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N04.WordWrap = false;
            // 
            // C_DAY_7_N05
            // 
            this.C_DAY_7_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N05.BorderWidth = 0.5F;
            this.C_DAY_7_N05.CanGrow = false;
            this.C_DAY_7_N05.Dpi = 100F;
            this.C_DAY_7_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 297F);
            this.C_DAY_7_N05.Multiline = true;
            this.C_DAY_7_N05.Name = "C_DAY_7_N05";
            this.C_DAY_7_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N05.Text = "";
            this.C_DAY_7_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N05.WordWrap = false;
            // 
            // C_DAY_7_N06
            // 
            this.C_DAY_7_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N06.BorderWidth = 0.5F;
            this.C_DAY_7_N06.CanGrow = false;
            this.C_DAY_7_N06.Dpi = 100F;
            this.C_DAY_7_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 297F);
            this.C_DAY_7_N06.Multiline = true;
            this.C_DAY_7_N06.Name = "C_DAY_7_N06";
            this.C_DAY_7_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N06.Text = "";
            this.C_DAY_7_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N06.WordWrap = false;
            // 
            // C_DAY_7_N07
            // 
            this.C_DAY_7_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N07.BorderWidth = 0.5F;
            this.C_DAY_7_N07.CanGrow = false;
            this.C_DAY_7_N07.Dpi = 100F;
            this.C_DAY_7_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 297F);
            this.C_DAY_7_N07.Multiline = true;
            this.C_DAY_7_N07.Name = "C_DAY_7_N07";
            this.C_DAY_7_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N07.Text = "";
            this.C_DAY_7_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N07.WordWrap = false;
            // 
            // C_DAY_7_N08
            // 
            this.C_DAY_7_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N08.BorderWidth = 0.5F;
            this.C_DAY_7_N08.CanGrow = false;
            this.C_DAY_7_N08.Dpi = 100F;
            this.C_DAY_7_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 297F);
            this.C_DAY_7_N08.Multiline = true;
            this.C_DAY_7_N08.Name = "C_DAY_7_N08";
            this.C_DAY_7_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N08.Text = "";
            this.C_DAY_7_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N08.WordWrap = false;
            // 
            // C_DAY_7_N09
            // 
            this.C_DAY_7_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N09.BorderWidth = 0.5F;
            this.C_DAY_7_N09.CanGrow = false;
            this.C_DAY_7_N09.Dpi = 100F;
            this.C_DAY_7_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 297F);
            this.C_DAY_7_N09.Multiline = true;
            this.C_DAY_7_N09.Name = "C_DAY_7_N09";
            this.C_DAY_7_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N09.Text = "";
            this.C_DAY_7_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N09.WordWrap = false;
            // 
            // C_DAY_7_N10
            // 
            this.C_DAY_7_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N10.BorderWidth = 0.5F;
            this.C_DAY_7_N10.CanGrow = false;
            this.C_DAY_7_N10.Dpi = 100F;
            this.C_DAY_7_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 297F);
            this.C_DAY_7_N10.Multiline = true;
            this.C_DAY_7_N10.Name = "C_DAY_7_N10";
            this.C_DAY_7_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N10.Text = "";
            this.C_DAY_7_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N10.WordWrap = false;
            // 
            // C_DAY_7_N11
            // 
            this.C_DAY_7_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N11.BorderWidth = 0.5F;
            this.C_DAY_7_N11.CanGrow = false;
            this.C_DAY_7_N11.Dpi = 100F;
            this.C_DAY_7_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 297F);
            this.C_DAY_7_N11.Multiline = true;
            this.C_DAY_7_N11.Name = "C_DAY_7_N11";
            this.C_DAY_7_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N11.Text = "";
            this.C_DAY_7_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N11.WordWrap = false;
            // 
            // C_DAY_7_N12
            // 
            this.C_DAY_7_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N12.BorderWidth = 0.5F;
            this.C_DAY_7_N12.CanGrow = false;
            this.C_DAY_7_N12.Dpi = 100F;
            this.C_DAY_7_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 297F);
            this.C_DAY_7_N12.Multiline = true;
            this.C_DAY_7_N12.Name = "C_DAY_7_N12";
            this.C_DAY_7_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N12.Text = "";
            this.C_DAY_7_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N12.WordWrap = false;
            // 
            // C_DAY_7_N13
            // 
            this.C_DAY_7_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_7_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_7_N13.BorderWidth = 0.5F;
            this.C_DAY_7_N13.CanGrow = false;
            this.C_DAY_7_N13.Dpi = 100F;
            this.C_DAY_7_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 297F);
            this.C_DAY_7_N13.Multiline = true;
            this.C_DAY_7_N13.Name = "C_DAY_7_N13";
            this.C_DAY_7_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_7_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_7_N13.Text = "";
            this.C_DAY_7_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_7_N13.WordWrap = false;
            // 
            // L_DAY_8_NO
            // 
            this.L_DAY_8_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_8_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_8_NO.BorderWidth = 0.5F;
            this.L_DAY_8_NO.CanGrow = false;
            this.L_DAY_8_NO.Dpi = 100F;
            this.L_DAY_8_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 312F);
            this.L_DAY_8_NO.Multiline = true;
            this.L_DAY_8_NO.Name = "L_DAY_8_NO";
            this.L_DAY_8_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_8_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_DAY_8_NO.Text = "8";
            this.L_DAY_8_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_8_NO.WordWrap = false;
            // 
            // C_DAY_8_IN
            // 
            this.C_DAY_8_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_IN.BorderWidth = 0.5F;
            this.C_DAY_8_IN.CanGrow = false;
            this.C_DAY_8_IN.Dpi = 100F;
            this.C_DAY_8_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 312F);
            this.C_DAY_8_IN.Multiline = true;
            this.C_DAY_8_IN.Name = "C_DAY_8_IN";
            this.C_DAY_8_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_8_IN.Text = "";
            this.C_DAY_8_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_8_IN.WordWrap = false;
            // 
            // C_DAY_8_OUT
            // 
            this.C_DAY_8_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_OUT.BorderWidth = 0.5F;
            this.C_DAY_8_OUT.CanGrow = false;
            this.C_DAY_8_OUT.Dpi = 100F;
            this.C_DAY_8_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 312F);
            this.C_DAY_8_OUT.Multiline = true;
            this.C_DAY_8_OUT.Name = "C_DAY_8_OUT";
            this.C_DAY_8_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_DAY_8_OUT.Text = "";
            this.C_DAY_8_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_DAY_8_OUT.WordWrap = false;
            // 
            // C_DAY_8_GOOD
            // 
            this.C_DAY_8_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_GOOD.BorderWidth = 0.5F;
            this.C_DAY_8_GOOD.CanGrow = false;
            this.C_DAY_8_GOOD.Dpi = 100F;
            this.C_DAY_8_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 312F);
            this.C_DAY_8_GOOD.Multiline = true;
            this.C_DAY_8_GOOD.Name = "C_DAY_8_GOOD";
            this.C_DAY_8_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_8_GOOD.Text = "";
            this.C_DAY_8_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_GOOD.WordWrap = false;
            // 
            // C_DAY_8_BAD
            // 
            this.C_DAY_8_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_BAD.BorderWidth = 0.5F;
            this.C_DAY_8_BAD.CanGrow = false;
            this.C_DAY_8_BAD.Dpi = 100F;
            this.C_DAY_8_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 312F);
            this.C_DAY_8_BAD.Multiline = true;
            this.C_DAY_8_BAD.Name = "C_DAY_8_BAD";
            this.C_DAY_8_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_8_BAD.Text = "";
            this.C_DAY_8_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_BAD.WordWrap = false;
            // 
            // C_DAY_8_SUM
            // 
            this.C_DAY_8_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_SUM.BorderWidth = 0.5F;
            this.C_DAY_8_SUM.CanGrow = false;
            this.C_DAY_8_SUM.Dpi = 100F;
            this.C_DAY_8_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 312F);
            this.C_DAY_8_SUM.Multiline = true;
            this.C_DAY_8_SUM.Name = "C_DAY_8_SUM";
            this.C_DAY_8_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_8_SUM.Text = "";
            this.C_DAY_8_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_SUM.WordWrap = false;
            // 
            // C_DAY_8_N01
            // 
            this.C_DAY_8_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N01.BorderWidth = 0.5F;
            this.C_DAY_8_N01.CanGrow = false;
            this.C_DAY_8_N01.Dpi = 100F;
            this.C_DAY_8_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 312F);
            this.C_DAY_8_N01.Multiline = true;
            this.C_DAY_8_N01.Name = "C_DAY_8_N01";
            this.C_DAY_8_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N01.Text = "";
            this.C_DAY_8_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N01.WordWrap = false;
            // 
            // C_DAY_8_N02
            // 
            this.C_DAY_8_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N02.BorderWidth = 0.5F;
            this.C_DAY_8_N02.CanGrow = false;
            this.C_DAY_8_N02.Dpi = 100F;
            this.C_DAY_8_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 312F);
            this.C_DAY_8_N02.Multiline = true;
            this.C_DAY_8_N02.Name = "C_DAY_8_N02";
            this.C_DAY_8_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N02.Text = "";
            this.C_DAY_8_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N02.WordWrap = false;
            // 
            // C_DAY_8_N03
            // 
            this.C_DAY_8_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N03.BorderWidth = 0.5F;
            this.C_DAY_8_N03.CanGrow = false;
            this.C_DAY_8_N03.Dpi = 100F;
            this.C_DAY_8_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 312F);
            this.C_DAY_8_N03.Multiline = true;
            this.C_DAY_8_N03.Name = "C_DAY_8_N03";
            this.C_DAY_8_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N03.Text = "";
            this.C_DAY_8_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N03.WordWrap = false;
            // 
            // C_DAY_8_N04
            // 
            this.C_DAY_8_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N04.BorderWidth = 0.5F;
            this.C_DAY_8_N04.CanGrow = false;
            this.C_DAY_8_N04.Dpi = 100F;
            this.C_DAY_8_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 312F);
            this.C_DAY_8_N04.Multiline = true;
            this.C_DAY_8_N04.Name = "C_DAY_8_N04";
            this.C_DAY_8_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N04.Text = "";
            this.C_DAY_8_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N04.WordWrap = false;
            // 
            // C_DAY_8_N05
            // 
            this.C_DAY_8_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N05.BorderWidth = 0.5F;
            this.C_DAY_8_N05.CanGrow = false;
            this.C_DAY_8_N05.Dpi = 100F;
            this.C_DAY_8_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 312F);
            this.C_DAY_8_N05.Multiline = true;
            this.C_DAY_8_N05.Name = "C_DAY_8_N05";
            this.C_DAY_8_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N05.Text = "";
            this.C_DAY_8_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N05.WordWrap = false;
            // 
            // C_DAY_8_N06
            // 
            this.C_DAY_8_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N06.BorderWidth = 0.5F;
            this.C_DAY_8_N06.CanGrow = false;
            this.C_DAY_8_N06.Dpi = 100F;
            this.C_DAY_8_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 312F);
            this.C_DAY_8_N06.Multiline = true;
            this.C_DAY_8_N06.Name = "C_DAY_8_N06";
            this.C_DAY_8_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N06.Text = "";
            this.C_DAY_8_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N06.WordWrap = false;
            // 
            // C_DAY_8_N07
            // 
            this.C_DAY_8_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N07.BorderWidth = 0.5F;
            this.C_DAY_8_N07.CanGrow = false;
            this.C_DAY_8_N07.Dpi = 100F;
            this.C_DAY_8_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 312F);
            this.C_DAY_8_N07.Multiline = true;
            this.C_DAY_8_N07.Name = "C_DAY_8_N07";
            this.C_DAY_8_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N07.Text = "";
            this.C_DAY_8_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N07.WordWrap = false;
            // 
            // C_DAY_8_N08
            // 
            this.C_DAY_8_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N08.BorderWidth = 0.5F;
            this.C_DAY_8_N08.CanGrow = false;
            this.C_DAY_8_N08.Dpi = 100F;
            this.C_DAY_8_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 312F);
            this.C_DAY_8_N08.Multiline = true;
            this.C_DAY_8_N08.Name = "C_DAY_8_N08";
            this.C_DAY_8_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N08.Text = "";
            this.C_DAY_8_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N08.WordWrap = false;
            // 
            // C_DAY_8_N09
            // 
            this.C_DAY_8_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N09.BorderWidth = 0.5F;
            this.C_DAY_8_N09.CanGrow = false;
            this.C_DAY_8_N09.Dpi = 100F;
            this.C_DAY_8_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 312F);
            this.C_DAY_8_N09.Multiline = true;
            this.C_DAY_8_N09.Name = "C_DAY_8_N09";
            this.C_DAY_8_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N09.Text = "";
            this.C_DAY_8_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N09.WordWrap = false;
            // 
            // C_DAY_8_N10
            // 
            this.C_DAY_8_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N10.BorderWidth = 0.5F;
            this.C_DAY_8_N10.CanGrow = false;
            this.C_DAY_8_N10.Dpi = 100F;
            this.C_DAY_8_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 312F);
            this.C_DAY_8_N10.Multiline = true;
            this.C_DAY_8_N10.Name = "C_DAY_8_N10";
            this.C_DAY_8_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N10.Text = "";
            this.C_DAY_8_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N10.WordWrap = false;
            // 
            // C_DAY_8_N11
            // 
            this.C_DAY_8_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N11.BorderWidth = 0.5F;
            this.C_DAY_8_N11.CanGrow = false;
            this.C_DAY_8_N11.Dpi = 100F;
            this.C_DAY_8_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 312F);
            this.C_DAY_8_N11.Multiline = true;
            this.C_DAY_8_N11.Name = "C_DAY_8_N11";
            this.C_DAY_8_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N11.Text = "";
            this.C_DAY_8_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N11.WordWrap = false;
            // 
            // C_DAY_8_N12
            // 
            this.C_DAY_8_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N12.BorderWidth = 0.5F;
            this.C_DAY_8_N12.CanGrow = false;
            this.C_DAY_8_N12.Dpi = 100F;
            this.C_DAY_8_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 312F);
            this.C_DAY_8_N12.Multiline = true;
            this.C_DAY_8_N12.Name = "C_DAY_8_N12";
            this.C_DAY_8_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N12.Text = "";
            this.C_DAY_8_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N12.WordWrap = false;
            // 
            // C_DAY_8_N13
            // 
            this.C_DAY_8_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_8_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_8_N13.BorderWidth = 0.5F;
            this.C_DAY_8_N13.CanGrow = false;
            this.C_DAY_8_N13.Dpi = 100F;
            this.C_DAY_8_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 312F);
            this.C_DAY_8_N13.Multiline = true;
            this.C_DAY_8_N13.Name = "C_DAY_8_N13";
            this.C_DAY_8_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_8_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_8_N13.Text = "";
            this.C_DAY_8_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_8_N13.WordWrap = false;
            // 
            // L_DAY_SUM
            // 
            this.L_DAY_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.L_DAY_SUM.BorderColor = System.Drawing.Color.Gray;
            this.L_DAY_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY_SUM.BorderWidth = 0.5F;
            this.L_DAY_SUM.CanGrow = false;
            this.L_DAY_SUM.Dpi = 100F;
            this.L_DAY_SUM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 327F);
            this.L_DAY_SUM.Multiline = true;
            this.L_DAY_SUM.Name = "L_DAY_SUM";
            this.L_DAY_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAY_SUM.SizeF = new System.Drawing.SizeF(204F, 15F);
            this.L_DAY_SUM.Text = "합계";
            this.L_DAY_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY_SUM.WordWrap = false;
            // 
            // C_DAY_SUM_GOOD
            // 
            this.C_DAY_SUM_GOOD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_GOOD.BorderWidth = 0.5F;
            this.C_DAY_SUM_GOOD.CanGrow = false;
            this.C_DAY_SUM_GOOD.Dpi = 100F;
            this.C_DAY_SUM_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 327F);
            this.C_DAY_SUM_GOOD.Multiline = true;
            this.C_DAY_SUM_GOOD.Name = "C_DAY_SUM_GOOD";
            this.C_DAY_SUM_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_SUM_GOOD.Text = "";
            this.C_DAY_SUM_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_GOOD.WordWrap = false;
            // 
            // C_DAY_SUM_BAD
            // 
            this.C_DAY_SUM_BAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_BAD.BorderWidth = 0.5F;
            this.C_DAY_SUM_BAD.CanGrow = false;
            this.C_DAY_SUM_BAD.Dpi = 100F;
            this.C_DAY_SUM_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 327F);
            this.C_DAY_SUM_BAD.Multiline = true;
            this.C_DAY_SUM_BAD.Name = "C_DAY_SUM_BAD";
            this.C_DAY_SUM_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_DAY_SUM_BAD.Text = "";
            this.C_DAY_SUM_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_BAD.WordWrap = false;
            // 
            // C_DAY_SUM_SUM
            // 
            this.C_DAY_SUM_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_SUM.BorderWidth = 0.5F;
            this.C_DAY_SUM_SUM.CanGrow = false;
            this.C_DAY_SUM_SUM.Dpi = 100F;
            this.C_DAY_SUM_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 327F);
            this.C_DAY_SUM_SUM.Multiline = true;
            this.C_DAY_SUM_SUM.Name = "C_DAY_SUM_SUM";
            this.C_DAY_SUM_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_DAY_SUM_SUM.Text = "";
            this.C_DAY_SUM_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_SUM.WordWrap = false;
            // 
            // C_DAY_SUM_N01
            // 
            this.C_DAY_SUM_N01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N01.BorderWidth = 0.5F;
            this.C_DAY_SUM_N01.CanGrow = false;
            this.C_DAY_SUM_N01.Dpi = 100F;
            this.C_DAY_SUM_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 327F);
            this.C_DAY_SUM_N01.Multiline = true;
            this.C_DAY_SUM_N01.Name = "C_DAY_SUM_N01";
            this.C_DAY_SUM_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N01.Text = "";
            this.C_DAY_SUM_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N01.WordWrap = false;
            // 
            // C_DAY_SUM_N02
            // 
            this.C_DAY_SUM_N02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N02.BorderWidth = 0.5F;
            this.C_DAY_SUM_N02.CanGrow = false;
            this.C_DAY_SUM_N02.Dpi = 100F;
            this.C_DAY_SUM_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 327F);
            this.C_DAY_SUM_N02.Multiline = true;
            this.C_DAY_SUM_N02.Name = "C_DAY_SUM_N02";
            this.C_DAY_SUM_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N02.Text = "";
            this.C_DAY_SUM_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N02.WordWrap = false;
            // 
            // C_DAY_SUM_N03
            // 
            this.C_DAY_SUM_N03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N03.BorderWidth = 0.5F;
            this.C_DAY_SUM_N03.CanGrow = false;
            this.C_DAY_SUM_N03.Dpi = 100F;
            this.C_DAY_SUM_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 327F);
            this.C_DAY_SUM_N03.Multiline = true;
            this.C_DAY_SUM_N03.Name = "C_DAY_SUM_N03";
            this.C_DAY_SUM_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N03.Text = "";
            this.C_DAY_SUM_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N03.WordWrap = false;
            // 
            // C_DAY_SUM_N04
            // 
            this.C_DAY_SUM_N04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N04.BorderWidth = 0.5F;
            this.C_DAY_SUM_N04.CanGrow = false;
            this.C_DAY_SUM_N04.Dpi = 100F;
            this.C_DAY_SUM_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 327F);
            this.C_DAY_SUM_N04.Multiline = true;
            this.C_DAY_SUM_N04.Name = "C_DAY_SUM_N04";
            this.C_DAY_SUM_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N04.Text = "";
            this.C_DAY_SUM_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N04.WordWrap = false;
            // 
            // C_DAY_SUM_N05
            // 
            this.C_DAY_SUM_N05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N05.BorderWidth = 0.5F;
            this.C_DAY_SUM_N05.CanGrow = false;
            this.C_DAY_SUM_N05.Dpi = 100F;
            this.C_DAY_SUM_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 327F);
            this.C_DAY_SUM_N05.Multiline = true;
            this.C_DAY_SUM_N05.Name = "C_DAY_SUM_N05";
            this.C_DAY_SUM_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N05.Text = "";
            this.C_DAY_SUM_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N05.WordWrap = false;
            // 
            // C_DAY_SUM_N06
            // 
            this.C_DAY_SUM_N06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N06.BorderWidth = 0.5F;
            this.C_DAY_SUM_N06.CanGrow = false;
            this.C_DAY_SUM_N06.Dpi = 100F;
            this.C_DAY_SUM_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 327F);
            this.C_DAY_SUM_N06.Multiline = true;
            this.C_DAY_SUM_N06.Name = "C_DAY_SUM_N06";
            this.C_DAY_SUM_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N06.Text = "";
            this.C_DAY_SUM_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N06.WordWrap = false;
            // 
            // C_DAY_SUM_N07
            // 
            this.C_DAY_SUM_N07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N07.BorderWidth = 0.5F;
            this.C_DAY_SUM_N07.CanGrow = false;
            this.C_DAY_SUM_N07.Dpi = 100F;
            this.C_DAY_SUM_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 327F);
            this.C_DAY_SUM_N07.Multiline = true;
            this.C_DAY_SUM_N07.Name = "C_DAY_SUM_N07";
            this.C_DAY_SUM_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N07.Text = "";
            this.C_DAY_SUM_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N07.WordWrap = false;
            // 
            // C_DAY_SUM_N08
            // 
            this.C_DAY_SUM_N08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N08.BorderWidth = 0.5F;
            this.C_DAY_SUM_N08.CanGrow = false;
            this.C_DAY_SUM_N08.Dpi = 100F;
            this.C_DAY_SUM_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 327F);
            this.C_DAY_SUM_N08.Multiline = true;
            this.C_DAY_SUM_N08.Name = "C_DAY_SUM_N08";
            this.C_DAY_SUM_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N08.Text = "";
            this.C_DAY_SUM_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N08.WordWrap = false;
            // 
            // C_DAY_SUM_N09
            // 
            this.C_DAY_SUM_N09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N09.BorderWidth = 0.5F;
            this.C_DAY_SUM_N09.CanGrow = false;
            this.C_DAY_SUM_N09.Dpi = 100F;
            this.C_DAY_SUM_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 327F);
            this.C_DAY_SUM_N09.Multiline = true;
            this.C_DAY_SUM_N09.Name = "C_DAY_SUM_N09";
            this.C_DAY_SUM_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N09.Text = "";
            this.C_DAY_SUM_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N09.WordWrap = false;
            // 
            // C_DAY_SUM_N10
            // 
            this.C_DAY_SUM_N10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N10.BorderWidth = 0.5F;
            this.C_DAY_SUM_N10.CanGrow = false;
            this.C_DAY_SUM_N10.Dpi = 100F;
            this.C_DAY_SUM_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 327F);
            this.C_DAY_SUM_N10.Multiline = true;
            this.C_DAY_SUM_N10.Name = "C_DAY_SUM_N10";
            this.C_DAY_SUM_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N10.Text = "";
            this.C_DAY_SUM_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N10.WordWrap = false;
            // 
            // C_DAY_SUM_N11
            // 
            this.C_DAY_SUM_N11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N11.BorderWidth = 0.5F;
            this.C_DAY_SUM_N11.CanGrow = false;
            this.C_DAY_SUM_N11.Dpi = 100F;
            this.C_DAY_SUM_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 327F);
            this.C_DAY_SUM_N11.Multiline = true;
            this.C_DAY_SUM_N11.Name = "C_DAY_SUM_N11";
            this.C_DAY_SUM_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N11.Text = "";
            this.C_DAY_SUM_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N11.WordWrap = false;
            // 
            // C_DAY_SUM_N12
            // 
            this.C_DAY_SUM_N12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N12.BorderWidth = 0.5F;
            this.C_DAY_SUM_N12.CanGrow = false;
            this.C_DAY_SUM_N12.Dpi = 100F;
            this.C_DAY_SUM_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 327F);
            this.C_DAY_SUM_N12.Multiline = true;
            this.C_DAY_SUM_N12.Name = "C_DAY_SUM_N12";
            this.C_DAY_SUM_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N12.Text = "";
            this.C_DAY_SUM_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N12.WordWrap = false;
            // 
            // C_DAY_SUM_N13
            // 
            this.C_DAY_SUM_N13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_DAY_SUM_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_DAY_SUM_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAY_SUM_N13.BorderWidth = 0.5F;
            this.C_DAY_SUM_N13.CanGrow = false;
            this.C_DAY_SUM_N13.Dpi = 100F;
            this.C_DAY_SUM_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 327F);
            this.C_DAY_SUM_N13.Multiline = true;
            this.C_DAY_SUM_N13.Name = "C_DAY_SUM_N13";
            this.C_DAY_SUM_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DAY_SUM_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_DAY_SUM_N13.Text = "";
            this.C_DAY_SUM_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_DAY_SUM_N13.WordWrap = false;
            // 
            // L_NIGHT_1_NO
            // 
            this.L_NIGHT_1_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_1_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_1_NO.BorderWidth = 0.5F;
            this.L_NIGHT_1_NO.CanGrow = false;
            this.L_NIGHT_1_NO.Dpi = 100F;
            this.L_NIGHT_1_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 342F);
            this.L_NIGHT_1_NO.Multiline = true;
            this.L_NIGHT_1_NO.Name = "L_NIGHT_1_NO";
            this.L_NIGHT_1_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_1_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_NIGHT_1_NO.Text = "1";
            this.L_NIGHT_1_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_1_NO.WordWrap = false;
            // 
            // C_NIGHT_1_IN
            // 
            this.C_NIGHT_1_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_IN.BorderWidth = 0.5F;
            this.C_NIGHT_1_IN.CanGrow = false;
            this.C_NIGHT_1_IN.Dpi = 100F;
            this.C_NIGHT_1_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 342F);
            this.C_NIGHT_1_IN.Multiline = true;
            this.C_NIGHT_1_IN.Name = "C_NIGHT_1_IN";
            this.C_NIGHT_1_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_1_IN.Text = "";
            this.C_NIGHT_1_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_1_IN.WordWrap = false;
            // 
            // C_NIGHT_1_OUT
            // 
            this.C_NIGHT_1_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_OUT.BorderWidth = 0.5F;
            this.C_NIGHT_1_OUT.CanGrow = false;
            this.C_NIGHT_1_OUT.Dpi = 100F;
            this.C_NIGHT_1_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 342F);
            this.C_NIGHT_1_OUT.Multiline = true;
            this.C_NIGHT_1_OUT.Name = "C_NIGHT_1_OUT";
            this.C_NIGHT_1_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_1_OUT.Text = "";
            this.C_NIGHT_1_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_1_OUT.WordWrap = false;
            // 
            // C_NIGHT_1_GOOD
            // 
            this.C_NIGHT_1_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_1_GOOD.CanGrow = false;
            this.C_NIGHT_1_GOOD.Dpi = 100F;
            this.C_NIGHT_1_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 342F);
            this.C_NIGHT_1_GOOD.Multiline = true;
            this.C_NIGHT_1_GOOD.Name = "C_NIGHT_1_GOOD";
            this.C_NIGHT_1_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_1_GOOD.Text = "";
            this.C_NIGHT_1_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_GOOD.WordWrap = false;
            // 
            // C_NIGHT_1_BAD
            // 
            this.C_NIGHT_1_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_1_BAD.CanGrow = false;
            this.C_NIGHT_1_BAD.Dpi = 100F;
            this.C_NIGHT_1_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 342F);
            this.C_NIGHT_1_BAD.Multiline = true;
            this.C_NIGHT_1_BAD.Name = "C_NIGHT_1_BAD";
            this.C_NIGHT_1_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_1_BAD.Text = "";
            this.C_NIGHT_1_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_BAD.WordWrap = false;
            // 
            // C_NIGHT_1_SUM
            // 
            this.C_NIGHT_1_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_1_SUM.CanGrow = false;
            this.C_NIGHT_1_SUM.Dpi = 100F;
            this.C_NIGHT_1_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 342F);
            this.C_NIGHT_1_SUM.Multiline = true;
            this.C_NIGHT_1_SUM.Name = "C_NIGHT_1_SUM";
            this.C_NIGHT_1_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_1_SUM.Text = "";
            this.C_NIGHT_1_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_SUM.WordWrap = false;
            // 
            // C_NIGHT_1_N01
            // 
            this.C_NIGHT_1_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N01.BorderWidth = 0.5F;
            this.C_NIGHT_1_N01.CanGrow = false;
            this.C_NIGHT_1_N01.Dpi = 100F;
            this.C_NIGHT_1_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 342F);
            this.C_NIGHT_1_N01.Multiline = true;
            this.C_NIGHT_1_N01.Name = "C_NIGHT_1_N01";
            this.C_NIGHT_1_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N01.Text = "";
            this.C_NIGHT_1_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N01.WordWrap = false;
            // 
            // C_NIGHT_1_N02
            // 
            this.C_NIGHT_1_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N02.BorderWidth = 0.5F;
            this.C_NIGHT_1_N02.CanGrow = false;
            this.C_NIGHT_1_N02.Dpi = 100F;
            this.C_NIGHT_1_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 342F);
            this.C_NIGHT_1_N02.Multiline = true;
            this.C_NIGHT_1_N02.Name = "C_NIGHT_1_N02";
            this.C_NIGHT_1_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N02.Text = "";
            this.C_NIGHT_1_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N02.WordWrap = false;
            // 
            // C_NIGHT_1_N03
            // 
            this.C_NIGHT_1_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N03.BorderWidth = 0.5F;
            this.C_NIGHT_1_N03.CanGrow = false;
            this.C_NIGHT_1_N03.Dpi = 100F;
            this.C_NIGHT_1_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 342F);
            this.C_NIGHT_1_N03.Multiline = true;
            this.C_NIGHT_1_N03.Name = "C_NIGHT_1_N03";
            this.C_NIGHT_1_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N03.Text = "";
            this.C_NIGHT_1_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N03.WordWrap = false;
            // 
            // C_NIGHT_1_N04
            // 
            this.C_NIGHT_1_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N04.BorderWidth = 0.5F;
            this.C_NIGHT_1_N04.CanGrow = false;
            this.C_NIGHT_1_N04.Dpi = 100F;
            this.C_NIGHT_1_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 342F);
            this.C_NIGHT_1_N04.Multiline = true;
            this.C_NIGHT_1_N04.Name = "C_NIGHT_1_N04";
            this.C_NIGHT_1_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N04.Text = "";
            this.C_NIGHT_1_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N04.WordWrap = false;
            // 
            // C_NIGHT_1_N05
            // 
            this.C_NIGHT_1_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N05.BorderWidth = 0.5F;
            this.C_NIGHT_1_N05.CanGrow = false;
            this.C_NIGHT_1_N05.Dpi = 100F;
            this.C_NIGHT_1_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 342F);
            this.C_NIGHT_1_N05.Multiline = true;
            this.C_NIGHT_1_N05.Name = "C_NIGHT_1_N05";
            this.C_NIGHT_1_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N05.Text = "";
            this.C_NIGHT_1_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N05.WordWrap = false;
            // 
            // C_NIGHT_1_N06
            // 
            this.C_NIGHT_1_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N06.BorderWidth = 0.5F;
            this.C_NIGHT_1_N06.CanGrow = false;
            this.C_NIGHT_1_N06.Dpi = 100F;
            this.C_NIGHT_1_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 342F);
            this.C_NIGHT_1_N06.Multiline = true;
            this.C_NIGHT_1_N06.Name = "C_NIGHT_1_N06";
            this.C_NIGHT_1_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N06.Text = "";
            this.C_NIGHT_1_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N06.WordWrap = false;
            // 
            // C_NIGHT_1_N07
            // 
            this.C_NIGHT_1_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N07.BorderWidth = 0.5F;
            this.C_NIGHT_1_N07.CanGrow = false;
            this.C_NIGHT_1_N07.Dpi = 100F;
            this.C_NIGHT_1_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 342F);
            this.C_NIGHT_1_N07.Multiline = true;
            this.C_NIGHT_1_N07.Name = "C_NIGHT_1_N07";
            this.C_NIGHT_1_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N07.Text = "";
            this.C_NIGHT_1_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N07.WordWrap = false;
            // 
            // C_NIGHT_1_N08
            // 
            this.C_NIGHT_1_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N08.BorderWidth = 0.5F;
            this.C_NIGHT_1_N08.CanGrow = false;
            this.C_NIGHT_1_N08.Dpi = 100F;
            this.C_NIGHT_1_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 342F);
            this.C_NIGHT_1_N08.Multiline = true;
            this.C_NIGHT_1_N08.Name = "C_NIGHT_1_N08";
            this.C_NIGHT_1_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N08.Text = "";
            this.C_NIGHT_1_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N08.WordWrap = false;
            // 
            // C_NIGHT_1_N09
            // 
            this.C_NIGHT_1_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N09.BorderWidth = 0.5F;
            this.C_NIGHT_1_N09.CanGrow = false;
            this.C_NIGHT_1_N09.Dpi = 100F;
            this.C_NIGHT_1_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 342F);
            this.C_NIGHT_1_N09.Multiline = true;
            this.C_NIGHT_1_N09.Name = "C_NIGHT_1_N09";
            this.C_NIGHT_1_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N09.Text = "";
            this.C_NIGHT_1_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N09.WordWrap = false;
            // 
            // C_NIGHT_1_N10
            // 
            this.C_NIGHT_1_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N10.BorderWidth = 0.5F;
            this.C_NIGHT_1_N10.CanGrow = false;
            this.C_NIGHT_1_N10.Dpi = 100F;
            this.C_NIGHT_1_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 342F);
            this.C_NIGHT_1_N10.Multiline = true;
            this.C_NIGHT_1_N10.Name = "C_NIGHT_1_N10";
            this.C_NIGHT_1_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N10.Text = "";
            this.C_NIGHT_1_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N10.WordWrap = false;
            // 
            // C_NIGHT_1_N11
            // 
            this.C_NIGHT_1_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N11.BorderWidth = 0.5F;
            this.C_NIGHT_1_N11.CanGrow = false;
            this.C_NIGHT_1_N11.Dpi = 100F;
            this.C_NIGHT_1_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 342F);
            this.C_NIGHT_1_N11.Multiline = true;
            this.C_NIGHT_1_N11.Name = "C_NIGHT_1_N11";
            this.C_NIGHT_1_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N11.Text = "";
            this.C_NIGHT_1_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N11.WordWrap = false;
            // 
            // C_NIGHT_1_N12
            // 
            this.C_NIGHT_1_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N12.BorderWidth = 0.5F;
            this.C_NIGHT_1_N12.CanGrow = false;
            this.C_NIGHT_1_N12.Dpi = 100F;
            this.C_NIGHT_1_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 342F);
            this.C_NIGHT_1_N12.Multiline = true;
            this.C_NIGHT_1_N12.Name = "C_NIGHT_1_N12";
            this.C_NIGHT_1_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N12.Text = "";
            this.C_NIGHT_1_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N12.WordWrap = false;
            // 
            // C_NIGHT_1_N13
            // 
            this.C_NIGHT_1_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_1_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_1_N13.BorderWidth = 0.5F;
            this.C_NIGHT_1_N13.CanGrow = false;
            this.C_NIGHT_1_N13.Dpi = 100F;
            this.C_NIGHT_1_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 342F);
            this.C_NIGHT_1_N13.Multiline = true;
            this.C_NIGHT_1_N13.Name = "C_NIGHT_1_N13";
            this.C_NIGHT_1_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_1_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_1_N13.Text = "";
            this.C_NIGHT_1_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_1_N13.WordWrap = false;
            // 
            // L_NIGHT_2_NO
            // 
            this.L_NIGHT_2_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_2_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_2_NO.BorderWidth = 0.5F;
            this.L_NIGHT_2_NO.CanGrow = false;
            this.L_NIGHT_2_NO.Dpi = 100F;
            this.L_NIGHT_2_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 357F);
            this.L_NIGHT_2_NO.Multiline = true;
            this.L_NIGHT_2_NO.Name = "L_NIGHT_2_NO";
            this.L_NIGHT_2_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_2_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_NIGHT_2_NO.Text = "2";
            this.L_NIGHT_2_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_2_NO.WordWrap = false;
            // 
            // C_NIGHT_2_IN
            // 
            this.C_NIGHT_2_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_IN.BorderWidth = 0.5F;
            this.C_NIGHT_2_IN.CanGrow = false;
            this.C_NIGHT_2_IN.Dpi = 100F;
            this.C_NIGHT_2_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 357F);
            this.C_NIGHT_2_IN.Multiline = true;
            this.C_NIGHT_2_IN.Name = "C_NIGHT_2_IN";
            this.C_NIGHT_2_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_2_IN.Text = "";
            this.C_NIGHT_2_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_2_IN.WordWrap = false;
            // 
            // C_NIGHT_2_OUT
            // 
            this.C_NIGHT_2_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_OUT.BorderWidth = 0.5F;
            this.C_NIGHT_2_OUT.CanGrow = false;
            this.C_NIGHT_2_OUT.Dpi = 100F;
            this.C_NIGHT_2_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 357F);
            this.C_NIGHT_2_OUT.Multiline = true;
            this.C_NIGHT_2_OUT.Name = "C_NIGHT_2_OUT";
            this.C_NIGHT_2_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_2_OUT.Text = "";
            this.C_NIGHT_2_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_2_OUT.WordWrap = false;
            // 
            // C_NIGHT_2_GOOD
            // 
            this.C_NIGHT_2_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_2_GOOD.CanGrow = false;
            this.C_NIGHT_2_GOOD.Dpi = 100F;
            this.C_NIGHT_2_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 357F);
            this.C_NIGHT_2_GOOD.Multiline = true;
            this.C_NIGHT_2_GOOD.Name = "C_NIGHT_2_GOOD";
            this.C_NIGHT_2_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_2_GOOD.Text = "";
            this.C_NIGHT_2_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_GOOD.WordWrap = false;
            // 
            // C_NIGHT_2_BAD
            // 
            this.C_NIGHT_2_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_2_BAD.CanGrow = false;
            this.C_NIGHT_2_BAD.Dpi = 100F;
            this.C_NIGHT_2_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 357F);
            this.C_NIGHT_2_BAD.Multiline = true;
            this.C_NIGHT_2_BAD.Name = "C_NIGHT_2_BAD";
            this.C_NIGHT_2_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_2_BAD.Text = "";
            this.C_NIGHT_2_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_BAD.WordWrap = false;
            // 
            // C_NIGHT_2_SUM
            // 
            this.C_NIGHT_2_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_2_SUM.CanGrow = false;
            this.C_NIGHT_2_SUM.Dpi = 100F;
            this.C_NIGHT_2_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 357F);
            this.C_NIGHT_2_SUM.Multiline = true;
            this.C_NIGHT_2_SUM.Name = "C_NIGHT_2_SUM";
            this.C_NIGHT_2_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_2_SUM.Text = "";
            this.C_NIGHT_2_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_SUM.WordWrap = false;
            // 
            // C_NIGHT_2_N01
            // 
            this.C_NIGHT_2_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N01.BorderWidth = 0.5F;
            this.C_NIGHT_2_N01.CanGrow = false;
            this.C_NIGHT_2_N01.Dpi = 100F;
            this.C_NIGHT_2_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 357F);
            this.C_NIGHT_2_N01.Multiline = true;
            this.C_NIGHT_2_N01.Name = "C_NIGHT_2_N01";
            this.C_NIGHT_2_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N01.Text = "";
            this.C_NIGHT_2_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N01.WordWrap = false;
            // 
            // C_NIGHT_2_N02
            // 
            this.C_NIGHT_2_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N02.BorderWidth = 0.5F;
            this.C_NIGHT_2_N02.CanGrow = false;
            this.C_NIGHT_2_N02.Dpi = 100F;
            this.C_NIGHT_2_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 357F);
            this.C_NIGHT_2_N02.Multiline = true;
            this.C_NIGHT_2_N02.Name = "C_NIGHT_2_N02";
            this.C_NIGHT_2_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N02.Text = "";
            this.C_NIGHT_2_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N02.WordWrap = false;
            // 
            // C_NIGHT_2_N03
            // 
            this.C_NIGHT_2_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N03.BorderWidth = 0.5F;
            this.C_NIGHT_2_N03.CanGrow = false;
            this.C_NIGHT_2_N03.Dpi = 100F;
            this.C_NIGHT_2_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 357F);
            this.C_NIGHT_2_N03.Multiline = true;
            this.C_NIGHT_2_N03.Name = "C_NIGHT_2_N03";
            this.C_NIGHT_2_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N03.Text = "";
            this.C_NIGHT_2_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N03.WordWrap = false;
            // 
            // C_NIGHT_2_N04
            // 
            this.C_NIGHT_2_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N04.BorderWidth = 0.5F;
            this.C_NIGHT_2_N04.CanGrow = false;
            this.C_NIGHT_2_N04.Dpi = 100F;
            this.C_NIGHT_2_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 357F);
            this.C_NIGHT_2_N04.Multiline = true;
            this.C_NIGHT_2_N04.Name = "C_NIGHT_2_N04";
            this.C_NIGHT_2_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N04.Text = "";
            this.C_NIGHT_2_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N04.WordWrap = false;
            // 
            // C_NIGHT_2_N05
            // 
            this.C_NIGHT_2_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N05.BorderWidth = 0.5F;
            this.C_NIGHT_2_N05.CanGrow = false;
            this.C_NIGHT_2_N05.Dpi = 100F;
            this.C_NIGHT_2_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 357F);
            this.C_NIGHT_2_N05.Multiline = true;
            this.C_NIGHT_2_N05.Name = "C_NIGHT_2_N05";
            this.C_NIGHT_2_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N05.Text = "";
            this.C_NIGHT_2_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N05.WordWrap = false;
            // 
            // C_NIGHT_2_N06
            // 
            this.C_NIGHT_2_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N06.BorderWidth = 0.5F;
            this.C_NIGHT_2_N06.CanGrow = false;
            this.C_NIGHT_2_N06.Dpi = 100F;
            this.C_NIGHT_2_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 357F);
            this.C_NIGHT_2_N06.Multiline = true;
            this.C_NIGHT_2_N06.Name = "C_NIGHT_2_N06";
            this.C_NIGHT_2_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N06.Text = "";
            this.C_NIGHT_2_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N06.WordWrap = false;
            // 
            // C_NIGHT_2_N07
            // 
            this.C_NIGHT_2_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N07.BorderWidth = 0.5F;
            this.C_NIGHT_2_N07.CanGrow = false;
            this.C_NIGHT_2_N07.Dpi = 100F;
            this.C_NIGHT_2_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 357F);
            this.C_NIGHT_2_N07.Multiline = true;
            this.C_NIGHT_2_N07.Name = "C_NIGHT_2_N07";
            this.C_NIGHT_2_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N07.Text = "";
            this.C_NIGHT_2_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N07.WordWrap = false;
            // 
            // C_NIGHT_2_N08
            // 
            this.C_NIGHT_2_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N08.BorderWidth = 0.5F;
            this.C_NIGHT_2_N08.CanGrow = false;
            this.C_NIGHT_2_N08.Dpi = 100F;
            this.C_NIGHT_2_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 357F);
            this.C_NIGHT_2_N08.Multiline = true;
            this.C_NIGHT_2_N08.Name = "C_NIGHT_2_N08";
            this.C_NIGHT_2_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N08.Text = "";
            this.C_NIGHT_2_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N08.WordWrap = false;
            // 
            // C_NIGHT_2_N09
            // 
            this.C_NIGHT_2_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N09.BorderWidth = 0.5F;
            this.C_NIGHT_2_N09.CanGrow = false;
            this.C_NIGHT_2_N09.Dpi = 100F;
            this.C_NIGHT_2_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 357F);
            this.C_NIGHT_2_N09.Multiline = true;
            this.C_NIGHT_2_N09.Name = "C_NIGHT_2_N09";
            this.C_NIGHT_2_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N09.Text = "";
            this.C_NIGHT_2_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N09.WordWrap = false;
            // 
            // C_NIGHT_2_N10
            // 
            this.C_NIGHT_2_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N10.BorderWidth = 0.5F;
            this.C_NIGHT_2_N10.CanGrow = false;
            this.C_NIGHT_2_N10.Dpi = 100F;
            this.C_NIGHT_2_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 357F);
            this.C_NIGHT_2_N10.Multiline = true;
            this.C_NIGHT_2_N10.Name = "C_NIGHT_2_N10";
            this.C_NIGHT_2_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N10.Text = "";
            this.C_NIGHT_2_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N10.WordWrap = false;
            // 
            // C_NIGHT_2_N11
            // 
            this.C_NIGHT_2_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N11.BorderWidth = 0.5F;
            this.C_NIGHT_2_N11.CanGrow = false;
            this.C_NIGHT_2_N11.Dpi = 100F;
            this.C_NIGHT_2_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 357F);
            this.C_NIGHT_2_N11.Multiline = true;
            this.C_NIGHT_2_N11.Name = "C_NIGHT_2_N11";
            this.C_NIGHT_2_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N11.Text = "";
            this.C_NIGHT_2_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N11.WordWrap = false;
            // 
            // C_NIGHT_2_N12
            // 
            this.C_NIGHT_2_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N12.BorderWidth = 0.5F;
            this.C_NIGHT_2_N12.CanGrow = false;
            this.C_NIGHT_2_N12.Dpi = 100F;
            this.C_NIGHT_2_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 357F);
            this.C_NIGHT_2_N12.Multiline = true;
            this.C_NIGHT_2_N12.Name = "C_NIGHT_2_N12";
            this.C_NIGHT_2_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N12.Text = "";
            this.C_NIGHT_2_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N12.WordWrap = false;
            // 
            // C_NIGHT_2_N13
            // 
            this.C_NIGHT_2_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_2_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_2_N13.BorderWidth = 0.5F;
            this.C_NIGHT_2_N13.CanGrow = false;
            this.C_NIGHT_2_N13.Dpi = 100F;
            this.C_NIGHT_2_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 357F);
            this.C_NIGHT_2_N13.Multiline = true;
            this.C_NIGHT_2_N13.Name = "C_NIGHT_2_N13";
            this.C_NIGHT_2_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_2_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_2_N13.Text = "";
            this.C_NIGHT_2_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_2_N13.WordWrap = false;
            // 
            // L_NIGHT_3_NO
            // 
            this.L_NIGHT_3_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_3_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_3_NO.BorderWidth = 0.5F;
            this.L_NIGHT_3_NO.CanGrow = false;
            this.L_NIGHT_3_NO.Dpi = 100F;
            this.L_NIGHT_3_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 372F);
            this.L_NIGHT_3_NO.Multiline = true;
            this.L_NIGHT_3_NO.Name = "L_NIGHT_3_NO";
            this.L_NIGHT_3_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_3_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_NIGHT_3_NO.Text = "3";
            this.L_NIGHT_3_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_3_NO.WordWrap = false;
            // 
            // C_NIGHT_3_IN
            // 
            this.C_NIGHT_3_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_IN.BorderWidth = 0.5F;
            this.C_NIGHT_3_IN.CanGrow = false;
            this.C_NIGHT_3_IN.Dpi = 100F;
            this.C_NIGHT_3_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 372F);
            this.C_NIGHT_3_IN.Multiline = true;
            this.C_NIGHT_3_IN.Name = "C_NIGHT_3_IN";
            this.C_NIGHT_3_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_3_IN.Text = "";
            this.C_NIGHT_3_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_3_IN.WordWrap = false;
            // 
            // C_NIGHT_3_OUT
            // 
            this.C_NIGHT_3_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_OUT.BorderWidth = 0.5F;
            this.C_NIGHT_3_OUT.CanGrow = false;
            this.C_NIGHT_3_OUT.Dpi = 100F;
            this.C_NIGHT_3_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 372F);
            this.C_NIGHT_3_OUT.Multiline = true;
            this.C_NIGHT_3_OUT.Name = "C_NIGHT_3_OUT";
            this.C_NIGHT_3_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_3_OUT.Text = "";
            this.C_NIGHT_3_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_3_OUT.WordWrap = false;
            // 
            // C_NIGHT_3_GOOD
            // 
            this.C_NIGHT_3_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_3_GOOD.CanGrow = false;
            this.C_NIGHT_3_GOOD.Dpi = 100F;
            this.C_NIGHT_3_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 372F);
            this.C_NIGHT_3_GOOD.Multiline = true;
            this.C_NIGHT_3_GOOD.Name = "C_NIGHT_3_GOOD";
            this.C_NIGHT_3_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_3_GOOD.Text = "";
            this.C_NIGHT_3_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_GOOD.WordWrap = false;
            // 
            // C_NIGHT_3_BAD
            // 
            this.C_NIGHT_3_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_3_BAD.CanGrow = false;
            this.C_NIGHT_3_BAD.Dpi = 100F;
            this.C_NIGHT_3_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 372F);
            this.C_NIGHT_3_BAD.Multiline = true;
            this.C_NIGHT_3_BAD.Name = "C_NIGHT_3_BAD";
            this.C_NIGHT_3_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_3_BAD.Text = "";
            this.C_NIGHT_3_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_BAD.WordWrap = false;
            // 
            // C_NIGHT_3_SUM
            // 
            this.C_NIGHT_3_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_3_SUM.CanGrow = false;
            this.C_NIGHT_3_SUM.Dpi = 100F;
            this.C_NIGHT_3_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 372F);
            this.C_NIGHT_3_SUM.Multiline = true;
            this.C_NIGHT_3_SUM.Name = "C_NIGHT_3_SUM";
            this.C_NIGHT_3_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_3_SUM.Text = "";
            this.C_NIGHT_3_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_SUM.WordWrap = false;
            // 
            // C_NIGHT_3_N01
            // 
            this.C_NIGHT_3_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N01.BorderWidth = 0.5F;
            this.C_NIGHT_3_N01.CanGrow = false;
            this.C_NIGHT_3_N01.Dpi = 100F;
            this.C_NIGHT_3_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 372F);
            this.C_NIGHT_3_N01.Multiline = true;
            this.C_NIGHT_3_N01.Name = "C_NIGHT_3_N01";
            this.C_NIGHT_3_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N01.Text = "";
            this.C_NIGHT_3_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N01.WordWrap = false;
            // 
            // C_NIGHT_3_N02
            // 
            this.C_NIGHT_3_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N02.BorderWidth = 0.5F;
            this.C_NIGHT_3_N02.CanGrow = false;
            this.C_NIGHT_3_N02.Dpi = 100F;
            this.C_NIGHT_3_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 372F);
            this.C_NIGHT_3_N02.Multiline = true;
            this.C_NIGHT_3_N02.Name = "C_NIGHT_3_N02";
            this.C_NIGHT_3_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N02.Text = "";
            this.C_NIGHT_3_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N02.WordWrap = false;
            // 
            // C_NIGHT_3_N03
            // 
            this.C_NIGHT_3_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N03.BorderWidth = 0.5F;
            this.C_NIGHT_3_N03.CanGrow = false;
            this.C_NIGHT_3_N03.Dpi = 100F;
            this.C_NIGHT_3_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 372F);
            this.C_NIGHT_3_N03.Multiline = true;
            this.C_NIGHT_3_N03.Name = "C_NIGHT_3_N03";
            this.C_NIGHT_3_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N03.Text = "";
            this.C_NIGHT_3_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N03.WordWrap = false;
            // 
            // C_NIGHT_3_N04
            // 
            this.C_NIGHT_3_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N04.BorderWidth = 0.5F;
            this.C_NIGHT_3_N04.CanGrow = false;
            this.C_NIGHT_3_N04.Dpi = 100F;
            this.C_NIGHT_3_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 372F);
            this.C_NIGHT_3_N04.Multiline = true;
            this.C_NIGHT_3_N04.Name = "C_NIGHT_3_N04";
            this.C_NIGHT_3_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N04.Text = "";
            this.C_NIGHT_3_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N04.WordWrap = false;
            // 
            // C_NIGHT_3_N05
            // 
            this.C_NIGHT_3_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N05.BorderWidth = 0.5F;
            this.C_NIGHT_3_N05.CanGrow = false;
            this.C_NIGHT_3_N05.Dpi = 100F;
            this.C_NIGHT_3_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 372F);
            this.C_NIGHT_3_N05.Multiline = true;
            this.C_NIGHT_3_N05.Name = "C_NIGHT_3_N05";
            this.C_NIGHT_3_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N05.Text = "";
            this.C_NIGHT_3_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N05.WordWrap = false;
            // 
            // C_NIGHT_3_N06
            // 
            this.C_NIGHT_3_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N06.BorderWidth = 0.5F;
            this.C_NIGHT_3_N06.CanGrow = false;
            this.C_NIGHT_3_N06.Dpi = 100F;
            this.C_NIGHT_3_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 372F);
            this.C_NIGHT_3_N06.Multiline = true;
            this.C_NIGHT_3_N06.Name = "C_NIGHT_3_N06";
            this.C_NIGHT_3_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N06.Text = "";
            this.C_NIGHT_3_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N06.WordWrap = false;
            // 
            // C_NIGHT_3_N07
            // 
            this.C_NIGHT_3_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N07.BorderWidth = 0.5F;
            this.C_NIGHT_3_N07.CanGrow = false;
            this.C_NIGHT_3_N07.Dpi = 100F;
            this.C_NIGHT_3_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 372F);
            this.C_NIGHT_3_N07.Multiline = true;
            this.C_NIGHT_3_N07.Name = "C_NIGHT_3_N07";
            this.C_NIGHT_3_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N07.Text = "";
            this.C_NIGHT_3_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N07.WordWrap = false;
            // 
            // C_NIGHT_3_N08
            // 
            this.C_NIGHT_3_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N08.BorderWidth = 0.5F;
            this.C_NIGHT_3_N08.CanGrow = false;
            this.C_NIGHT_3_N08.Dpi = 100F;
            this.C_NIGHT_3_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 372F);
            this.C_NIGHT_3_N08.Multiline = true;
            this.C_NIGHT_3_N08.Name = "C_NIGHT_3_N08";
            this.C_NIGHT_3_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N08.Text = "";
            this.C_NIGHT_3_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N08.WordWrap = false;
            // 
            // C_NIGHT_3_N09
            // 
            this.C_NIGHT_3_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N09.BorderWidth = 0.5F;
            this.C_NIGHT_3_N09.CanGrow = false;
            this.C_NIGHT_3_N09.Dpi = 100F;
            this.C_NIGHT_3_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 372F);
            this.C_NIGHT_3_N09.Multiline = true;
            this.C_NIGHT_3_N09.Name = "C_NIGHT_3_N09";
            this.C_NIGHT_3_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N09.Text = "";
            this.C_NIGHT_3_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N09.WordWrap = false;
            // 
            // C_NIGHT_3_N10
            // 
            this.C_NIGHT_3_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N10.BorderWidth = 0.5F;
            this.C_NIGHT_3_N10.CanGrow = false;
            this.C_NIGHT_3_N10.Dpi = 100F;
            this.C_NIGHT_3_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 372F);
            this.C_NIGHT_3_N10.Multiline = true;
            this.C_NIGHT_3_N10.Name = "C_NIGHT_3_N10";
            this.C_NIGHT_3_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N10.Text = "";
            this.C_NIGHT_3_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N10.WordWrap = false;
            // 
            // C_NIGHT_3_N11
            // 
            this.C_NIGHT_3_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N11.BorderWidth = 0.5F;
            this.C_NIGHT_3_N11.CanGrow = false;
            this.C_NIGHT_3_N11.Dpi = 100F;
            this.C_NIGHT_3_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 372F);
            this.C_NIGHT_3_N11.Multiline = true;
            this.C_NIGHT_3_N11.Name = "C_NIGHT_3_N11";
            this.C_NIGHT_3_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N11.Text = "";
            this.C_NIGHT_3_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N11.WordWrap = false;
            // 
            // C_NIGHT_3_N12
            // 
            this.C_NIGHT_3_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N12.BorderWidth = 0.5F;
            this.C_NIGHT_3_N12.CanGrow = false;
            this.C_NIGHT_3_N12.Dpi = 100F;
            this.C_NIGHT_3_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 372F);
            this.C_NIGHT_3_N12.Multiline = true;
            this.C_NIGHT_3_N12.Name = "C_NIGHT_3_N12";
            this.C_NIGHT_3_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N12.Text = "";
            this.C_NIGHT_3_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N12.WordWrap = false;
            // 
            // C_NIGHT_3_N13
            // 
            this.C_NIGHT_3_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_3_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_3_N13.BorderWidth = 0.5F;
            this.C_NIGHT_3_N13.CanGrow = false;
            this.C_NIGHT_3_N13.Dpi = 100F;
            this.C_NIGHT_3_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 372F);
            this.C_NIGHT_3_N13.Multiline = true;
            this.C_NIGHT_3_N13.Name = "C_NIGHT_3_N13";
            this.C_NIGHT_3_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_3_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_3_N13.Text = "";
            this.C_NIGHT_3_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_3_N13.WordWrap = false;
            // 
            // L_NIGHT_4_NO
            // 
            this.L_NIGHT_4_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_4_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_4_NO.BorderWidth = 0.5F;
            this.L_NIGHT_4_NO.CanGrow = false;
            this.L_NIGHT_4_NO.Dpi = 100F;
            this.L_NIGHT_4_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 387F);
            this.L_NIGHT_4_NO.Multiline = true;
            this.L_NIGHT_4_NO.Name = "L_NIGHT_4_NO";
            this.L_NIGHT_4_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_4_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_NIGHT_4_NO.Text = "4";
            this.L_NIGHT_4_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_4_NO.WordWrap = false;
            // 
            // C_NIGHT_4_IN
            // 
            this.C_NIGHT_4_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_IN.BorderWidth = 0.5F;
            this.C_NIGHT_4_IN.CanGrow = false;
            this.C_NIGHT_4_IN.Dpi = 100F;
            this.C_NIGHT_4_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 387F);
            this.C_NIGHT_4_IN.Multiline = true;
            this.C_NIGHT_4_IN.Name = "C_NIGHT_4_IN";
            this.C_NIGHT_4_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_4_IN.Text = "";
            this.C_NIGHT_4_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_4_IN.WordWrap = false;
            // 
            // C_NIGHT_4_OUT
            // 
            this.C_NIGHT_4_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_OUT.BorderWidth = 0.5F;
            this.C_NIGHT_4_OUT.CanGrow = false;
            this.C_NIGHT_4_OUT.Dpi = 100F;
            this.C_NIGHT_4_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 387F);
            this.C_NIGHT_4_OUT.Multiline = true;
            this.C_NIGHT_4_OUT.Name = "C_NIGHT_4_OUT";
            this.C_NIGHT_4_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_4_OUT.Text = "";
            this.C_NIGHT_4_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_4_OUT.WordWrap = false;
            // 
            // C_NIGHT_4_GOOD
            // 
            this.C_NIGHT_4_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_4_GOOD.CanGrow = false;
            this.C_NIGHT_4_GOOD.Dpi = 100F;
            this.C_NIGHT_4_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 387F);
            this.C_NIGHT_4_GOOD.Multiline = true;
            this.C_NIGHT_4_GOOD.Name = "C_NIGHT_4_GOOD";
            this.C_NIGHT_4_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_4_GOOD.Text = "";
            this.C_NIGHT_4_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_GOOD.WordWrap = false;
            // 
            // C_NIGHT_4_BAD
            // 
            this.C_NIGHT_4_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_4_BAD.CanGrow = false;
            this.C_NIGHT_4_BAD.Dpi = 100F;
            this.C_NIGHT_4_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 387F);
            this.C_NIGHT_4_BAD.Multiline = true;
            this.C_NIGHT_4_BAD.Name = "C_NIGHT_4_BAD";
            this.C_NIGHT_4_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_4_BAD.Text = "";
            this.C_NIGHT_4_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_BAD.WordWrap = false;
            // 
            // C_NIGHT_4_SUM
            // 
            this.C_NIGHT_4_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_4_SUM.CanGrow = false;
            this.C_NIGHT_4_SUM.Dpi = 100F;
            this.C_NIGHT_4_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 387F);
            this.C_NIGHT_4_SUM.Multiline = true;
            this.C_NIGHT_4_SUM.Name = "C_NIGHT_4_SUM";
            this.C_NIGHT_4_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_4_SUM.Text = "";
            this.C_NIGHT_4_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_SUM.WordWrap = false;
            // 
            // C_NIGHT_4_N01
            // 
            this.C_NIGHT_4_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N01.BorderWidth = 0.5F;
            this.C_NIGHT_4_N01.CanGrow = false;
            this.C_NIGHT_4_N01.Dpi = 100F;
            this.C_NIGHT_4_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 387F);
            this.C_NIGHT_4_N01.Multiline = true;
            this.C_NIGHT_4_N01.Name = "C_NIGHT_4_N01";
            this.C_NIGHT_4_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N01.Text = "";
            this.C_NIGHT_4_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N01.WordWrap = false;
            // 
            // C_NIGHT_4_N02
            // 
            this.C_NIGHT_4_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N02.BorderWidth = 0.5F;
            this.C_NIGHT_4_N02.CanGrow = false;
            this.C_NIGHT_4_N02.Dpi = 100F;
            this.C_NIGHT_4_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 387F);
            this.C_NIGHT_4_N02.Multiline = true;
            this.C_NIGHT_4_N02.Name = "C_NIGHT_4_N02";
            this.C_NIGHT_4_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N02.Text = "";
            this.C_NIGHT_4_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N02.WordWrap = false;
            // 
            // C_NIGHT_4_N03
            // 
            this.C_NIGHT_4_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N03.BorderWidth = 0.5F;
            this.C_NIGHT_4_N03.CanGrow = false;
            this.C_NIGHT_4_N03.Dpi = 100F;
            this.C_NIGHT_4_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 387F);
            this.C_NIGHT_4_N03.Multiline = true;
            this.C_NIGHT_4_N03.Name = "C_NIGHT_4_N03";
            this.C_NIGHT_4_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N03.Text = "";
            this.C_NIGHT_4_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N03.WordWrap = false;
            // 
            // C_NIGHT_4_N04
            // 
            this.C_NIGHT_4_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N04.BorderWidth = 0.5F;
            this.C_NIGHT_4_N04.CanGrow = false;
            this.C_NIGHT_4_N04.Dpi = 100F;
            this.C_NIGHT_4_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 387F);
            this.C_NIGHT_4_N04.Multiline = true;
            this.C_NIGHT_4_N04.Name = "C_NIGHT_4_N04";
            this.C_NIGHT_4_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N04.Text = "";
            this.C_NIGHT_4_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N04.WordWrap = false;
            // 
            // C_NIGHT_4_N05
            // 
            this.C_NIGHT_4_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N05.BorderWidth = 0.5F;
            this.C_NIGHT_4_N05.CanGrow = false;
            this.C_NIGHT_4_N05.Dpi = 100F;
            this.C_NIGHT_4_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 387F);
            this.C_NIGHT_4_N05.Multiline = true;
            this.C_NIGHT_4_N05.Name = "C_NIGHT_4_N05";
            this.C_NIGHT_4_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N05.Text = "";
            this.C_NIGHT_4_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N05.WordWrap = false;
            // 
            // C_NIGHT_4_N06
            // 
            this.C_NIGHT_4_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N06.BorderWidth = 0.5F;
            this.C_NIGHT_4_N06.CanGrow = false;
            this.C_NIGHT_4_N06.Dpi = 100F;
            this.C_NIGHT_4_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 387F);
            this.C_NIGHT_4_N06.Multiline = true;
            this.C_NIGHT_4_N06.Name = "C_NIGHT_4_N06";
            this.C_NIGHT_4_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N06.Text = "";
            this.C_NIGHT_4_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N06.WordWrap = false;
            // 
            // C_NIGHT_4_N07
            // 
            this.C_NIGHT_4_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N07.BorderWidth = 0.5F;
            this.C_NIGHT_4_N07.CanGrow = false;
            this.C_NIGHT_4_N07.Dpi = 100F;
            this.C_NIGHT_4_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 387F);
            this.C_NIGHT_4_N07.Multiline = true;
            this.C_NIGHT_4_N07.Name = "C_NIGHT_4_N07";
            this.C_NIGHT_4_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N07.Text = "";
            this.C_NIGHT_4_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N07.WordWrap = false;
            // 
            // C_NIGHT_4_N08
            // 
            this.C_NIGHT_4_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N08.BorderWidth = 0.5F;
            this.C_NIGHT_4_N08.CanGrow = false;
            this.C_NIGHT_4_N08.Dpi = 100F;
            this.C_NIGHT_4_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 387F);
            this.C_NIGHT_4_N08.Multiline = true;
            this.C_NIGHT_4_N08.Name = "C_NIGHT_4_N08";
            this.C_NIGHT_4_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N08.Text = "";
            this.C_NIGHT_4_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N08.WordWrap = false;
            // 
            // C_NIGHT_4_N09
            // 
            this.C_NIGHT_4_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N09.BorderWidth = 0.5F;
            this.C_NIGHT_4_N09.CanGrow = false;
            this.C_NIGHT_4_N09.Dpi = 100F;
            this.C_NIGHT_4_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 387F);
            this.C_NIGHT_4_N09.Multiline = true;
            this.C_NIGHT_4_N09.Name = "C_NIGHT_4_N09";
            this.C_NIGHT_4_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N09.Text = "";
            this.C_NIGHT_4_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N09.WordWrap = false;
            // 
            // C_NIGHT_4_N10
            // 
            this.C_NIGHT_4_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N10.BorderWidth = 0.5F;
            this.C_NIGHT_4_N10.CanGrow = false;
            this.C_NIGHT_4_N10.Dpi = 100F;
            this.C_NIGHT_4_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 387F);
            this.C_NIGHT_4_N10.Multiline = true;
            this.C_NIGHT_4_N10.Name = "C_NIGHT_4_N10";
            this.C_NIGHT_4_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N10.Text = "";
            this.C_NIGHT_4_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N10.WordWrap = false;
            // 
            // C_NIGHT_4_N11
            // 
            this.C_NIGHT_4_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N11.BorderWidth = 0.5F;
            this.C_NIGHT_4_N11.CanGrow = false;
            this.C_NIGHT_4_N11.Dpi = 100F;
            this.C_NIGHT_4_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 387F);
            this.C_NIGHT_4_N11.Multiline = true;
            this.C_NIGHT_4_N11.Name = "C_NIGHT_4_N11";
            this.C_NIGHT_4_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N11.Text = "";
            this.C_NIGHT_4_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N11.WordWrap = false;
            // 
            // C_NIGHT_4_N12
            // 
            this.C_NIGHT_4_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N12.BorderWidth = 0.5F;
            this.C_NIGHT_4_N12.CanGrow = false;
            this.C_NIGHT_4_N12.Dpi = 100F;
            this.C_NIGHT_4_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 387F);
            this.C_NIGHT_4_N12.Multiline = true;
            this.C_NIGHT_4_N12.Name = "C_NIGHT_4_N12";
            this.C_NIGHT_4_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N12.Text = "";
            this.C_NIGHT_4_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N12.WordWrap = false;
            // 
            // C_NIGHT_4_N13
            // 
            this.C_NIGHT_4_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_4_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_4_N13.BorderWidth = 0.5F;
            this.C_NIGHT_4_N13.CanGrow = false;
            this.C_NIGHT_4_N13.Dpi = 100F;
            this.C_NIGHT_4_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 387F);
            this.C_NIGHT_4_N13.Multiline = true;
            this.C_NIGHT_4_N13.Name = "C_NIGHT_4_N13";
            this.C_NIGHT_4_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_4_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_4_N13.Text = "";
            this.C_NIGHT_4_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_4_N13.WordWrap = false;
            // 
            // L_NIGHT_5_NO
            // 
            this.L_NIGHT_5_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_5_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_5_NO.BorderWidth = 0.5F;
            this.L_NIGHT_5_NO.CanGrow = false;
            this.L_NIGHT_5_NO.Dpi = 100F;
            this.L_NIGHT_5_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 402F);
            this.L_NIGHT_5_NO.Multiline = true;
            this.L_NIGHT_5_NO.Name = "L_NIGHT_5_NO";
            this.L_NIGHT_5_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_5_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_NIGHT_5_NO.Text = "5";
            this.L_NIGHT_5_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_5_NO.WordWrap = false;
            // 
            // C_NIGHT_5_IN
            // 
            this.C_NIGHT_5_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_IN.BorderWidth = 0.5F;
            this.C_NIGHT_5_IN.CanGrow = false;
            this.C_NIGHT_5_IN.Dpi = 100F;
            this.C_NIGHT_5_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 402F);
            this.C_NIGHT_5_IN.Multiline = true;
            this.C_NIGHT_5_IN.Name = "C_NIGHT_5_IN";
            this.C_NIGHT_5_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_5_IN.Text = "";
            this.C_NIGHT_5_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_5_IN.WordWrap = false;
            // 
            // C_NIGHT_5_OUT
            // 
            this.C_NIGHT_5_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_OUT.BorderWidth = 0.5F;
            this.C_NIGHT_5_OUT.CanGrow = false;
            this.C_NIGHT_5_OUT.Dpi = 100F;
            this.C_NIGHT_5_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 402F);
            this.C_NIGHT_5_OUT.Multiline = true;
            this.C_NIGHT_5_OUT.Name = "C_NIGHT_5_OUT";
            this.C_NIGHT_5_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_5_OUT.Text = "";
            this.C_NIGHT_5_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_5_OUT.WordWrap = false;
            // 
            // C_NIGHT_5_GOOD
            // 
            this.C_NIGHT_5_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_5_GOOD.CanGrow = false;
            this.C_NIGHT_5_GOOD.Dpi = 100F;
            this.C_NIGHT_5_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 402F);
            this.C_NIGHT_5_GOOD.Multiline = true;
            this.C_NIGHT_5_GOOD.Name = "C_NIGHT_5_GOOD";
            this.C_NIGHT_5_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_5_GOOD.Text = "";
            this.C_NIGHT_5_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_GOOD.WordWrap = false;
            // 
            // C_NIGHT_5_BAD
            // 
            this.C_NIGHT_5_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_5_BAD.CanGrow = false;
            this.C_NIGHT_5_BAD.Dpi = 100F;
            this.C_NIGHT_5_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 402F);
            this.C_NIGHT_5_BAD.Multiline = true;
            this.C_NIGHT_5_BAD.Name = "C_NIGHT_5_BAD";
            this.C_NIGHT_5_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_5_BAD.Text = "";
            this.C_NIGHT_5_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_BAD.WordWrap = false;
            // 
            // C_NIGHT_5_SUM
            // 
            this.C_NIGHT_5_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_5_SUM.CanGrow = false;
            this.C_NIGHT_5_SUM.Dpi = 100F;
            this.C_NIGHT_5_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 402F);
            this.C_NIGHT_5_SUM.Multiline = true;
            this.C_NIGHT_5_SUM.Name = "C_NIGHT_5_SUM";
            this.C_NIGHT_5_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_5_SUM.Text = "";
            this.C_NIGHT_5_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_SUM.WordWrap = false;
            // 
            // C_NIGHT_5_N01
            // 
            this.C_NIGHT_5_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N01.BorderWidth = 0.5F;
            this.C_NIGHT_5_N01.CanGrow = false;
            this.C_NIGHT_5_N01.Dpi = 100F;
            this.C_NIGHT_5_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 402F);
            this.C_NIGHT_5_N01.Multiline = true;
            this.C_NIGHT_5_N01.Name = "C_NIGHT_5_N01";
            this.C_NIGHT_5_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N01.Text = "";
            this.C_NIGHT_5_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N01.WordWrap = false;
            // 
            // C_NIGHT_5_N02
            // 
            this.C_NIGHT_5_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N02.BorderWidth = 0.5F;
            this.C_NIGHT_5_N02.CanGrow = false;
            this.C_NIGHT_5_N02.Dpi = 100F;
            this.C_NIGHT_5_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 402F);
            this.C_NIGHT_5_N02.Multiline = true;
            this.C_NIGHT_5_N02.Name = "C_NIGHT_5_N02";
            this.C_NIGHT_5_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N02.Text = "";
            this.C_NIGHT_5_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N02.WordWrap = false;
            // 
            // C_NIGHT_5_N03
            // 
            this.C_NIGHT_5_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N03.BorderWidth = 0.5F;
            this.C_NIGHT_5_N03.CanGrow = false;
            this.C_NIGHT_5_N03.Dpi = 100F;
            this.C_NIGHT_5_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 402F);
            this.C_NIGHT_5_N03.Multiline = true;
            this.C_NIGHT_5_N03.Name = "C_NIGHT_5_N03";
            this.C_NIGHT_5_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N03.Text = "";
            this.C_NIGHT_5_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N03.WordWrap = false;
            // 
            // C_NIGHT_5_N04
            // 
            this.C_NIGHT_5_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N04.BorderWidth = 0.5F;
            this.C_NIGHT_5_N04.CanGrow = false;
            this.C_NIGHT_5_N04.Dpi = 100F;
            this.C_NIGHT_5_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 402F);
            this.C_NIGHT_5_N04.Multiline = true;
            this.C_NIGHT_5_N04.Name = "C_NIGHT_5_N04";
            this.C_NIGHT_5_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N04.Text = "";
            this.C_NIGHT_5_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N04.WordWrap = false;
            // 
            // C_NIGHT_5_N05
            // 
            this.C_NIGHT_5_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N05.BorderWidth = 0.5F;
            this.C_NIGHT_5_N05.CanGrow = false;
            this.C_NIGHT_5_N05.Dpi = 100F;
            this.C_NIGHT_5_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 402F);
            this.C_NIGHT_5_N05.Multiline = true;
            this.C_NIGHT_5_N05.Name = "C_NIGHT_5_N05";
            this.C_NIGHT_5_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N05.Text = "";
            this.C_NIGHT_5_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N05.WordWrap = false;
            // 
            // C_NIGHT_5_N06
            // 
            this.C_NIGHT_5_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N06.BorderWidth = 0.5F;
            this.C_NIGHT_5_N06.CanGrow = false;
            this.C_NIGHT_5_N06.Dpi = 100F;
            this.C_NIGHT_5_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 402F);
            this.C_NIGHT_5_N06.Multiline = true;
            this.C_NIGHT_5_N06.Name = "C_NIGHT_5_N06";
            this.C_NIGHT_5_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N06.Text = "";
            this.C_NIGHT_5_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N06.WordWrap = false;
            // 
            // C_NIGHT_5_N07
            // 
            this.C_NIGHT_5_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N07.BorderWidth = 0.5F;
            this.C_NIGHT_5_N07.CanGrow = false;
            this.C_NIGHT_5_N07.Dpi = 100F;
            this.C_NIGHT_5_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 402F);
            this.C_NIGHT_5_N07.Multiline = true;
            this.C_NIGHT_5_N07.Name = "C_NIGHT_5_N07";
            this.C_NIGHT_5_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N07.Text = "";
            this.C_NIGHT_5_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N07.WordWrap = false;
            // 
            // C_NIGHT_5_N08
            // 
            this.C_NIGHT_5_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N08.BorderWidth = 0.5F;
            this.C_NIGHT_5_N08.CanGrow = false;
            this.C_NIGHT_5_N08.Dpi = 100F;
            this.C_NIGHT_5_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 402F);
            this.C_NIGHT_5_N08.Multiline = true;
            this.C_NIGHT_5_N08.Name = "C_NIGHT_5_N08";
            this.C_NIGHT_5_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N08.Text = "";
            this.C_NIGHT_5_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N08.WordWrap = false;
            // 
            // C_NIGHT_5_N09
            // 
            this.C_NIGHT_5_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N09.BorderWidth = 0.5F;
            this.C_NIGHT_5_N09.CanGrow = false;
            this.C_NIGHT_5_N09.Dpi = 100F;
            this.C_NIGHT_5_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 402F);
            this.C_NIGHT_5_N09.Multiline = true;
            this.C_NIGHT_5_N09.Name = "C_NIGHT_5_N09";
            this.C_NIGHT_5_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N09.Text = "";
            this.C_NIGHT_5_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N09.WordWrap = false;
            // 
            // C_NIGHT_5_N10
            // 
            this.C_NIGHT_5_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N10.BorderWidth = 0.5F;
            this.C_NIGHT_5_N10.CanGrow = false;
            this.C_NIGHT_5_N10.Dpi = 100F;
            this.C_NIGHT_5_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 402F);
            this.C_NIGHT_5_N10.Multiline = true;
            this.C_NIGHT_5_N10.Name = "C_NIGHT_5_N10";
            this.C_NIGHT_5_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N10.Text = "";
            this.C_NIGHT_5_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N10.WordWrap = false;
            // 
            // C_NIGHT_5_N11
            // 
            this.C_NIGHT_5_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N11.BorderWidth = 0.5F;
            this.C_NIGHT_5_N11.CanGrow = false;
            this.C_NIGHT_5_N11.Dpi = 100F;
            this.C_NIGHT_5_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 402F);
            this.C_NIGHT_5_N11.Multiline = true;
            this.C_NIGHT_5_N11.Name = "C_NIGHT_5_N11";
            this.C_NIGHT_5_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N11.Text = "";
            this.C_NIGHT_5_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N11.WordWrap = false;
            // 
            // C_NIGHT_5_N12
            // 
            this.C_NIGHT_5_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N12.BorderWidth = 0.5F;
            this.C_NIGHT_5_N12.CanGrow = false;
            this.C_NIGHT_5_N12.Dpi = 100F;
            this.C_NIGHT_5_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 402F);
            this.C_NIGHT_5_N12.Multiline = true;
            this.C_NIGHT_5_N12.Name = "C_NIGHT_5_N12";
            this.C_NIGHT_5_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N12.Text = "";
            this.C_NIGHT_5_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N12.WordWrap = false;
            // 
            // C_NIGHT_5_N13
            // 
            this.C_NIGHT_5_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_5_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_5_N13.BorderWidth = 0.5F;
            this.C_NIGHT_5_N13.CanGrow = false;
            this.C_NIGHT_5_N13.Dpi = 100F;
            this.C_NIGHT_5_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 402F);
            this.C_NIGHT_5_N13.Multiline = true;
            this.C_NIGHT_5_N13.Name = "C_NIGHT_5_N13";
            this.C_NIGHT_5_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_5_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_5_N13.Text = "";
            this.C_NIGHT_5_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_5_N13.WordWrap = false;
            // 
            // L_NIGHT_6_NO
            // 
            this.L_NIGHT_6_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_6_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_6_NO.BorderWidth = 0.5F;
            this.L_NIGHT_6_NO.CanGrow = false;
            this.L_NIGHT_6_NO.Dpi = 100F;
            this.L_NIGHT_6_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 417F);
            this.L_NIGHT_6_NO.Multiline = true;
            this.L_NIGHT_6_NO.Name = "L_NIGHT_6_NO";
            this.L_NIGHT_6_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_6_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_NIGHT_6_NO.Text = "6";
            this.L_NIGHT_6_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_6_NO.WordWrap = false;
            // 
            // C_NIGHT_6_IN
            // 
            this.C_NIGHT_6_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_IN.BorderWidth = 0.5F;
            this.C_NIGHT_6_IN.CanGrow = false;
            this.C_NIGHT_6_IN.Dpi = 100F;
            this.C_NIGHT_6_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 417F);
            this.C_NIGHT_6_IN.Multiline = true;
            this.C_NIGHT_6_IN.Name = "C_NIGHT_6_IN";
            this.C_NIGHT_6_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_6_IN.Text = "";
            this.C_NIGHT_6_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_6_IN.WordWrap = false;
            // 
            // C_NIGHT_6_OUT
            // 
            this.C_NIGHT_6_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_OUT.BorderWidth = 0.5F;
            this.C_NIGHT_6_OUT.CanGrow = false;
            this.C_NIGHT_6_OUT.Dpi = 100F;
            this.C_NIGHT_6_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 417F);
            this.C_NIGHT_6_OUT.Multiline = true;
            this.C_NIGHT_6_OUT.Name = "C_NIGHT_6_OUT";
            this.C_NIGHT_6_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_6_OUT.Text = "";
            this.C_NIGHT_6_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_6_OUT.WordWrap = false;
            // 
            // C_NIGHT_6_GOOD
            // 
            this.C_NIGHT_6_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_6_GOOD.CanGrow = false;
            this.C_NIGHT_6_GOOD.Dpi = 100F;
            this.C_NIGHT_6_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 417F);
            this.C_NIGHT_6_GOOD.Multiline = true;
            this.C_NIGHT_6_GOOD.Name = "C_NIGHT_6_GOOD";
            this.C_NIGHT_6_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_6_GOOD.Text = "";
            this.C_NIGHT_6_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_GOOD.WordWrap = false;
            // 
            // C_NIGHT_6_BAD
            // 
            this.C_NIGHT_6_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_6_BAD.CanGrow = false;
            this.C_NIGHT_6_BAD.Dpi = 100F;
            this.C_NIGHT_6_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 417F);
            this.C_NIGHT_6_BAD.Multiline = true;
            this.C_NIGHT_6_BAD.Name = "C_NIGHT_6_BAD";
            this.C_NIGHT_6_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_6_BAD.Text = "";
            this.C_NIGHT_6_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_BAD.WordWrap = false;
            // 
            // C_NIGHT_6_SUM
            // 
            this.C_NIGHT_6_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_6_SUM.CanGrow = false;
            this.C_NIGHT_6_SUM.Dpi = 100F;
            this.C_NIGHT_6_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 417F);
            this.C_NIGHT_6_SUM.Multiline = true;
            this.C_NIGHT_6_SUM.Name = "C_NIGHT_6_SUM";
            this.C_NIGHT_6_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_6_SUM.Text = "";
            this.C_NIGHT_6_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_SUM.WordWrap = false;
            // 
            // C_NIGHT_6_N01
            // 
            this.C_NIGHT_6_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N01.BorderWidth = 0.5F;
            this.C_NIGHT_6_N01.CanGrow = false;
            this.C_NIGHT_6_N01.Dpi = 100F;
            this.C_NIGHT_6_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 417F);
            this.C_NIGHT_6_N01.Multiline = true;
            this.C_NIGHT_6_N01.Name = "C_NIGHT_6_N01";
            this.C_NIGHT_6_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N01.Text = "";
            this.C_NIGHT_6_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N01.WordWrap = false;
            // 
            // C_NIGHT_6_N02
            // 
            this.C_NIGHT_6_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N02.BorderWidth = 0.5F;
            this.C_NIGHT_6_N02.CanGrow = false;
            this.C_NIGHT_6_N02.Dpi = 100F;
            this.C_NIGHT_6_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 417F);
            this.C_NIGHT_6_N02.Multiline = true;
            this.C_NIGHT_6_N02.Name = "C_NIGHT_6_N02";
            this.C_NIGHT_6_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N02.Text = "";
            this.C_NIGHT_6_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N02.WordWrap = false;
            // 
            // C_NIGHT_6_N03
            // 
            this.C_NIGHT_6_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N03.BorderWidth = 0.5F;
            this.C_NIGHT_6_N03.CanGrow = false;
            this.C_NIGHT_6_N03.Dpi = 100F;
            this.C_NIGHT_6_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 417F);
            this.C_NIGHT_6_N03.Multiline = true;
            this.C_NIGHT_6_N03.Name = "C_NIGHT_6_N03";
            this.C_NIGHT_6_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N03.Text = "";
            this.C_NIGHT_6_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N03.WordWrap = false;
            // 
            // C_NIGHT_6_N04
            // 
            this.C_NIGHT_6_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N04.BorderWidth = 0.5F;
            this.C_NIGHT_6_N04.CanGrow = false;
            this.C_NIGHT_6_N04.Dpi = 100F;
            this.C_NIGHT_6_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 417F);
            this.C_NIGHT_6_N04.Multiline = true;
            this.C_NIGHT_6_N04.Name = "C_NIGHT_6_N04";
            this.C_NIGHT_6_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N04.Text = "";
            this.C_NIGHT_6_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N04.WordWrap = false;
            // 
            // C_NIGHT_6_N05
            // 
            this.C_NIGHT_6_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N05.BorderWidth = 0.5F;
            this.C_NIGHT_6_N05.CanGrow = false;
            this.C_NIGHT_6_N05.Dpi = 100F;
            this.C_NIGHT_6_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 417F);
            this.C_NIGHT_6_N05.Multiline = true;
            this.C_NIGHT_6_N05.Name = "C_NIGHT_6_N05";
            this.C_NIGHT_6_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N05.Text = "";
            this.C_NIGHT_6_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N05.WordWrap = false;
            // 
            // C_NIGHT_6_N06
            // 
            this.C_NIGHT_6_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N06.BorderWidth = 0.5F;
            this.C_NIGHT_6_N06.CanGrow = false;
            this.C_NIGHT_6_N06.Dpi = 100F;
            this.C_NIGHT_6_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 417F);
            this.C_NIGHT_6_N06.Multiline = true;
            this.C_NIGHT_6_N06.Name = "C_NIGHT_6_N06";
            this.C_NIGHT_6_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N06.Text = "";
            this.C_NIGHT_6_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N06.WordWrap = false;
            // 
            // C_NIGHT_6_N07
            // 
            this.C_NIGHT_6_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N07.BorderWidth = 0.5F;
            this.C_NIGHT_6_N07.CanGrow = false;
            this.C_NIGHT_6_N07.Dpi = 100F;
            this.C_NIGHT_6_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 417F);
            this.C_NIGHT_6_N07.Multiline = true;
            this.C_NIGHT_6_N07.Name = "C_NIGHT_6_N07";
            this.C_NIGHT_6_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N07.Text = "";
            this.C_NIGHT_6_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N07.WordWrap = false;
            // 
            // C_NIGHT_6_N08
            // 
            this.C_NIGHT_6_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N08.BorderWidth = 0.5F;
            this.C_NIGHT_6_N08.CanGrow = false;
            this.C_NIGHT_6_N08.Dpi = 100F;
            this.C_NIGHT_6_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 417F);
            this.C_NIGHT_6_N08.Multiline = true;
            this.C_NIGHT_6_N08.Name = "C_NIGHT_6_N08";
            this.C_NIGHT_6_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N08.Text = "";
            this.C_NIGHT_6_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N08.WordWrap = false;
            // 
            // C_NIGHT_6_N09
            // 
            this.C_NIGHT_6_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N09.BorderWidth = 0.5F;
            this.C_NIGHT_6_N09.CanGrow = false;
            this.C_NIGHT_6_N09.Dpi = 100F;
            this.C_NIGHT_6_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 417F);
            this.C_NIGHT_6_N09.Multiline = true;
            this.C_NIGHT_6_N09.Name = "C_NIGHT_6_N09";
            this.C_NIGHT_6_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N09.Text = "";
            this.C_NIGHT_6_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N09.WordWrap = false;
            // 
            // C_NIGHT_6_N10
            // 
            this.C_NIGHT_6_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N10.BorderWidth = 0.5F;
            this.C_NIGHT_6_N10.CanGrow = false;
            this.C_NIGHT_6_N10.Dpi = 100F;
            this.C_NIGHT_6_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 417F);
            this.C_NIGHT_6_N10.Multiline = true;
            this.C_NIGHT_6_N10.Name = "C_NIGHT_6_N10";
            this.C_NIGHT_6_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N10.Text = "";
            this.C_NIGHT_6_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N10.WordWrap = false;
            // 
            // C_NIGHT_6_N11
            // 
            this.C_NIGHT_6_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N11.BorderWidth = 0.5F;
            this.C_NIGHT_6_N11.CanGrow = false;
            this.C_NIGHT_6_N11.Dpi = 100F;
            this.C_NIGHT_6_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 417F);
            this.C_NIGHT_6_N11.Multiline = true;
            this.C_NIGHT_6_N11.Name = "C_NIGHT_6_N11";
            this.C_NIGHT_6_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N11.Text = "";
            this.C_NIGHT_6_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N11.WordWrap = false;
            // 
            // C_NIGHT_6_N12
            // 
            this.C_NIGHT_6_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N12.BorderWidth = 0.5F;
            this.C_NIGHT_6_N12.CanGrow = false;
            this.C_NIGHT_6_N12.Dpi = 100F;
            this.C_NIGHT_6_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 417F);
            this.C_NIGHT_6_N12.Multiline = true;
            this.C_NIGHT_6_N12.Name = "C_NIGHT_6_N12";
            this.C_NIGHT_6_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N12.Text = "";
            this.C_NIGHT_6_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N12.WordWrap = false;
            // 
            // C_NIGHT_6_N13
            // 
            this.C_NIGHT_6_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_6_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_6_N13.BorderWidth = 0.5F;
            this.C_NIGHT_6_N13.CanGrow = false;
            this.C_NIGHT_6_N13.Dpi = 100F;
            this.C_NIGHT_6_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 417F);
            this.C_NIGHT_6_N13.Multiline = true;
            this.C_NIGHT_6_N13.Name = "C_NIGHT_6_N13";
            this.C_NIGHT_6_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_6_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_6_N13.Text = "";
            this.C_NIGHT_6_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_6_N13.WordWrap = false;
            // 
            // L_NIGHT_7_NO
            // 
            this.L_NIGHT_7_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_7_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_7_NO.BorderWidth = 0.5F;
            this.L_NIGHT_7_NO.CanGrow = false;
            this.L_NIGHT_7_NO.Dpi = 100F;
            this.L_NIGHT_7_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 432F);
            this.L_NIGHT_7_NO.Multiline = true;
            this.L_NIGHT_7_NO.Name = "L_NIGHT_7_NO";
            this.L_NIGHT_7_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_7_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_NIGHT_7_NO.Text = "7";
            this.L_NIGHT_7_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_7_NO.WordWrap = false;
            // 
            // C_NIGHT_7_IN
            // 
            this.C_NIGHT_7_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_IN.BorderWidth = 0.5F;
            this.C_NIGHT_7_IN.CanGrow = false;
            this.C_NIGHT_7_IN.Dpi = 100F;
            this.C_NIGHT_7_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 432F);
            this.C_NIGHT_7_IN.Multiline = true;
            this.C_NIGHT_7_IN.Name = "C_NIGHT_7_IN";
            this.C_NIGHT_7_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_7_IN.Text = "";
            this.C_NIGHT_7_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_7_IN.WordWrap = false;
            // 
            // C_NIGHT_7_OUT
            // 
            this.C_NIGHT_7_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_OUT.BorderWidth = 0.5F;
            this.C_NIGHT_7_OUT.CanGrow = false;
            this.C_NIGHT_7_OUT.Dpi = 100F;
            this.C_NIGHT_7_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 432F);
            this.C_NIGHT_7_OUT.Multiline = true;
            this.C_NIGHT_7_OUT.Name = "C_NIGHT_7_OUT";
            this.C_NIGHT_7_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_7_OUT.Text = "";
            this.C_NIGHT_7_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_7_OUT.WordWrap = false;
            // 
            // C_NIGHT_7_GOOD
            // 
            this.C_NIGHT_7_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_7_GOOD.CanGrow = false;
            this.C_NIGHT_7_GOOD.Dpi = 100F;
            this.C_NIGHT_7_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 432F);
            this.C_NIGHT_7_GOOD.Multiline = true;
            this.C_NIGHT_7_GOOD.Name = "C_NIGHT_7_GOOD";
            this.C_NIGHT_7_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_7_GOOD.Text = "";
            this.C_NIGHT_7_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_GOOD.WordWrap = false;
            // 
            // C_NIGHT_7_BAD
            // 
            this.C_NIGHT_7_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_7_BAD.CanGrow = false;
            this.C_NIGHT_7_BAD.Dpi = 100F;
            this.C_NIGHT_7_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 432F);
            this.C_NIGHT_7_BAD.Multiline = true;
            this.C_NIGHT_7_BAD.Name = "C_NIGHT_7_BAD";
            this.C_NIGHT_7_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_7_BAD.Text = "";
            this.C_NIGHT_7_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_BAD.WordWrap = false;
            // 
            // C_NIGHT_7_SUM
            // 
            this.C_NIGHT_7_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_7_SUM.CanGrow = false;
            this.C_NIGHT_7_SUM.Dpi = 100F;
            this.C_NIGHT_7_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 432F);
            this.C_NIGHT_7_SUM.Multiline = true;
            this.C_NIGHT_7_SUM.Name = "C_NIGHT_7_SUM";
            this.C_NIGHT_7_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_7_SUM.Text = "";
            this.C_NIGHT_7_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_SUM.WordWrap = false;
            // 
            // C_NIGHT_7_N01
            // 
            this.C_NIGHT_7_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N01.BorderWidth = 0.5F;
            this.C_NIGHT_7_N01.CanGrow = false;
            this.C_NIGHT_7_N01.Dpi = 100F;
            this.C_NIGHT_7_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 432F);
            this.C_NIGHT_7_N01.Multiline = true;
            this.C_NIGHT_7_N01.Name = "C_NIGHT_7_N01";
            this.C_NIGHT_7_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N01.Text = "";
            this.C_NIGHT_7_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N01.WordWrap = false;
            // 
            // C_NIGHT_7_N02
            // 
            this.C_NIGHT_7_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N02.BorderWidth = 0.5F;
            this.C_NIGHT_7_N02.CanGrow = false;
            this.C_NIGHT_7_N02.Dpi = 100F;
            this.C_NIGHT_7_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 432F);
            this.C_NIGHT_7_N02.Multiline = true;
            this.C_NIGHT_7_N02.Name = "C_NIGHT_7_N02";
            this.C_NIGHT_7_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N02.Text = "";
            this.C_NIGHT_7_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N02.WordWrap = false;
            // 
            // C_NIGHT_7_N03
            // 
            this.C_NIGHT_7_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N03.BorderWidth = 0.5F;
            this.C_NIGHT_7_N03.CanGrow = false;
            this.C_NIGHT_7_N03.Dpi = 100F;
            this.C_NIGHT_7_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 432F);
            this.C_NIGHT_7_N03.Multiline = true;
            this.C_NIGHT_7_N03.Name = "C_NIGHT_7_N03";
            this.C_NIGHT_7_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N03.Text = "";
            this.C_NIGHT_7_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N03.WordWrap = false;
            // 
            // C_NIGHT_7_N04
            // 
            this.C_NIGHT_7_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N04.BorderWidth = 0.5F;
            this.C_NIGHT_7_N04.CanGrow = false;
            this.C_NIGHT_7_N04.Dpi = 100F;
            this.C_NIGHT_7_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 432F);
            this.C_NIGHT_7_N04.Multiline = true;
            this.C_NIGHT_7_N04.Name = "C_NIGHT_7_N04";
            this.C_NIGHT_7_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N04.Text = "";
            this.C_NIGHT_7_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N04.WordWrap = false;
            // 
            // C_NIGHT_7_N05
            // 
            this.C_NIGHT_7_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N05.BorderWidth = 0.5F;
            this.C_NIGHT_7_N05.CanGrow = false;
            this.C_NIGHT_7_N05.Dpi = 100F;
            this.C_NIGHT_7_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 432F);
            this.C_NIGHT_7_N05.Multiline = true;
            this.C_NIGHT_7_N05.Name = "C_NIGHT_7_N05";
            this.C_NIGHT_7_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N05.Text = "";
            this.C_NIGHT_7_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N05.WordWrap = false;
            // 
            // C_NIGHT_7_N06
            // 
            this.C_NIGHT_7_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N06.BorderWidth = 0.5F;
            this.C_NIGHT_7_N06.CanGrow = false;
            this.C_NIGHT_7_N06.Dpi = 100F;
            this.C_NIGHT_7_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 432F);
            this.C_NIGHT_7_N06.Multiline = true;
            this.C_NIGHT_7_N06.Name = "C_NIGHT_7_N06";
            this.C_NIGHT_7_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N06.Text = "";
            this.C_NIGHT_7_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N06.WordWrap = false;
            // 
            // C_NIGHT_7_N07
            // 
            this.C_NIGHT_7_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N07.BorderWidth = 0.5F;
            this.C_NIGHT_7_N07.CanGrow = false;
            this.C_NIGHT_7_N07.Dpi = 100F;
            this.C_NIGHT_7_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 432F);
            this.C_NIGHT_7_N07.Multiline = true;
            this.C_NIGHT_7_N07.Name = "C_NIGHT_7_N07";
            this.C_NIGHT_7_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N07.Text = "";
            this.C_NIGHT_7_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N07.WordWrap = false;
            // 
            // C_NIGHT_7_N08
            // 
            this.C_NIGHT_7_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N08.BorderWidth = 0.5F;
            this.C_NIGHT_7_N08.CanGrow = false;
            this.C_NIGHT_7_N08.Dpi = 100F;
            this.C_NIGHT_7_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 432F);
            this.C_NIGHT_7_N08.Multiline = true;
            this.C_NIGHT_7_N08.Name = "C_NIGHT_7_N08";
            this.C_NIGHT_7_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N08.Text = "";
            this.C_NIGHT_7_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N08.WordWrap = false;
            // 
            // C_NIGHT_7_N09
            // 
            this.C_NIGHT_7_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N09.BorderWidth = 0.5F;
            this.C_NIGHT_7_N09.CanGrow = false;
            this.C_NIGHT_7_N09.Dpi = 100F;
            this.C_NIGHT_7_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 432F);
            this.C_NIGHT_7_N09.Multiline = true;
            this.C_NIGHT_7_N09.Name = "C_NIGHT_7_N09";
            this.C_NIGHT_7_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N09.Text = "";
            this.C_NIGHT_7_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N09.WordWrap = false;
            // 
            // C_NIGHT_7_N10
            // 
            this.C_NIGHT_7_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N10.BorderWidth = 0.5F;
            this.C_NIGHT_7_N10.CanGrow = false;
            this.C_NIGHT_7_N10.Dpi = 100F;
            this.C_NIGHT_7_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 432F);
            this.C_NIGHT_7_N10.Multiline = true;
            this.C_NIGHT_7_N10.Name = "C_NIGHT_7_N10";
            this.C_NIGHT_7_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N10.Text = "";
            this.C_NIGHT_7_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N10.WordWrap = false;
            // 
            // C_NIGHT_7_N11
            // 
            this.C_NIGHT_7_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N11.BorderWidth = 0.5F;
            this.C_NIGHT_7_N11.CanGrow = false;
            this.C_NIGHT_7_N11.Dpi = 100F;
            this.C_NIGHT_7_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 432F);
            this.C_NIGHT_7_N11.Multiline = true;
            this.C_NIGHT_7_N11.Name = "C_NIGHT_7_N11";
            this.C_NIGHT_7_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N11.Text = "";
            this.C_NIGHT_7_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N11.WordWrap = false;
            // 
            // C_NIGHT_7_N12
            // 
            this.C_NIGHT_7_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N12.BorderWidth = 0.5F;
            this.C_NIGHT_7_N12.CanGrow = false;
            this.C_NIGHT_7_N12.Dpi = 100F;
            this.C_NIGHT_7_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 432F);
            this.C_NIGHT_7_N12.Multiline = true;
            this.C_NIGHT_7_N12.Name = "C_NIGHT_7_N12";
            this.C_NIGHT_7_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N12.Text = "";
            this.C_NIGHT_7_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N12.WordWrap = false;
            // 
            // C_NIGHT_7_N13
            // 
            this.C_NIGHT_7_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_7_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_7_N13.BorderWidth = 0.5F;
            this.C_NIGHT_7_N13.CanGrow = false;
            this.C_NIGHT_7_N13.Dpi = 100F;
            this.C_NIGHT_7_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 432F);
            this.C_NIGHT_7_N13.Multiline = true;
            this.C_NIGHT_7_N13.Name = "C_NIGHT_7_N13";
            this.C_NIGHT_7_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_7_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_7_N13.Text = "";
            this.C_NIGHT_7_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_7_N13.WordWrap = false;
            // 
            // L_NIGHT_8_NO
            // 
            this.L_NIGHT_8_NO.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_8_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_8_NO.BorderWidth = 0.5F;
            this.L_NIGHT_8_NO.CanGrow = false;
            this.L_NIGHT_8_NO.Dpi = 100F;
            this.L_NIGHT_8_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 447F);
            this.L_NIGHT_8_NO.Multiline = true;
            this.L_NIGHT_8_NO.Name = "L_NIGHT_8_NO";
            this.L_NIGHT_8_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_8_NO.SizeF = new System.Drawing.SizeF(24F, 15F);
            this.L_NIGHT_8_NO.Text = "8";
            this.L_NIGHT_8_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_8_NO.WordWrap = false;
            // 
            // C_NIGHT_8_IN
            // 
            this.C_NIGHT_8_IN.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_IN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_IN.BorderWidth = 0.5F;
            this.C_NIGHT_8_IN.CanGrow = false;
            this.C_NIGHT_8_IN.Dpi = 100F;
            this.C_NIGHT_8_IN.LocationFloat = new DevExpress.Utils.PointFloat(24F, 447F);
            this.C_NIGHT_8_IN.Multiline = true;
            this.C_NIGHT_8_IN.Name = "C_NIGHT_8_IN";
            this.C_NIGHT_8_IN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_IN.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_8_IN.Text = "";
            this.C_NIGHT_8_IN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_8_IN.WordWrap = false;
            // 
            // C_NIGHT_8_OUT
            // 
            this.C_NIGHT_8_OUT.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_OUT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_OUT.BorderWidth = 0.5F;
            this.C_NIGHT_8_OUT.CanGrow = false;
            this.C_NIGHT_8_OUT.Dpi = 100F;
            this.C_NIGHT_8_OUT.LocationFloat = new DevExpress.Utils.PointFloat(114F, 447F);
            this.C_NIGHT_8_OUT.Multiline = true;
            this.C_NIGHT_8_OUT.Name = "C_NIGHT_8_OUT";
            this.C_NIGHT_8_OUT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_OUT.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_NIGHT_8_OUT.Text = "";
            this.C_NIGHT_8_OUT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_NIGHT_8_OUT.WordWrap = false;
            // 
            // C_NIGHT_8_GOOD
            // 
            this.C_NIGHT_8_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_8_GOOD.CanGrow = false;
            this.C_NIGHT_8_GOOD.Dpi = 100F;
            this.C_NIGHT_8_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 447F);
            this.C_NIGHT_8_GOOD.Multiline = true;
            this.C_NIGHT_8_GOOD.Name = "C_NIGHT_8_GOOD";
            this.C_NIGHT_8_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_8_GOOD.Text = "";
            this.C_NIGHT_8_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_GOOD.WordWrap = false;
            // 
            // C_NIGHT_8_BAD
            // 
            this.C_NIGHT_8_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_8_BAD.CanGrow = false;
            this.C_NIGHT_8_BAD.Dpi = 100F;
            this.C_NIGHT_8_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 447F);
            this.C_NIGHT_8_BAD.Multiline = true;
            this.C_NIGHT_8_BAD.Name = "C_NIGHT_8_BAD";
            this.C_NIGHT_8_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_8_BAD.Text = "";
            this.C_NIGHT_8_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_BAD.WordWrap = false;
            // 
            // C_NIGHT_8_SUM
            // 
            this.C_NIGHT_8_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_8_SUM.CanGrow = false;
            this.C_NIGHT_8_SUM.Dpi = 100F;
            this.C_NIGHT_8_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 447F);
            this.C_NIGHT_8_SUM.Multiline = true;
            this.C_NIGHT_8_SUM.Name = "C_NIGHT_8_SUM";
            this.C_NIGHT_8_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_8_SUM.Text = "";
            this.C_NIGHT_8_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_SUM.WordWrap = false;
            // 
            // C_NIGHT_8_N01
            // 
            this.C_NIGHT_8_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N01.BorderWidth = 0.5F;
            this.C_NIGHT_8_N01.CanGrow = false;
            this.C_NIGHT_8_N01.Dpi = 100F;
            this.C_NIGHT_8_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 447F);
            this.C_NIGHT_8_N01.Multiline = true;
            this.C_NIGHT_8_N01.Name = "C_NIGHT_8_N01";
            this.C_NIGHT_8_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N01.Text = "";
            this.C_NIGHT_8_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N01.WordWrap = false;
            // 
            // C_NIGHT_8_N02
            // 
            this.C_NIGHT_8_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N02.BorderWidth = 0.5F;
            this.C_NIGHT_8_N02.CanGrow = false;
            this.C_NIGHT_8_N02.Dpi = 100F;
            this.C_NIGHT_8_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 447F);
            this.C_NIGHT_8_N02.Multiline = true;
            this.C_NIGHT_8_N02.Name = "C_NIGHT_8_N02";
            this.C_NIGHT_8_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N02.Text = "";
            this.C_NIGHT_8_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N02.WordWrap = false;
            // 
            // C_NIGHT_8_N03
            // 
            this.C_NIGHT_8_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N03.BorderWidth = 0.5F;
            this.C_NIGHT_8_N03.CanGrow = false;
            this.C_NIGHT_8_N03.Dpi = 100F;
            this.C_NIGHT_8_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 447F);
            this.C_NIGHT_8_N03.Multiline = true;
            this.C_NIGHT_8_N03.Name = "C_NIGHT_8_N03";
            this.C_NIGHT_8_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N03.Text = "";
            this.C_NIGHT_8_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N03.WordWrap = false;
            // 
            // C_NIGHT_8_N04
            // 
            this.C_NIGHT_8_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N04.BorderWidth = 0.5F;
            this.C_NIGHT_8_N04.CanGrow = false;
            this.C_NIGHT_8_N04.Dpi = 100F;
            this.C_NIGHT_8_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 447F);
            this.C_NIGHT_8_N04.Multiline = true;
            this.C_NIGHT_8_N04.Name = "C_NIGHT_8_N04";
            this.C_NIGHT_8_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N04.Text = "";
            this.C_NIGHT_8_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N04.WordWrap = false;
            // 
            // C_NIGHT_8_N05
            // 
            this.C_NIGHT_8_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N05.BorderWidth = 0.5F;
            this.C_NIGHT_8_N05.CanGrow = false;
            this.C_NIGHT_8_N05.Dpi = 100F;
            this.C_NIGHT_8_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 447F);
            this.C_NIGHT_8_N05.Multiline = true;
            this.C_NIGHT_8_N05.Name = "C_NIGHT_8_N05";
            this.C_NIGHT_8_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N05.Text = "";
            this.C_NIGHT_8_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N05.WordWrap = false;
            // 
            // C_NIGHT_8_N06
            // 
            this.C_NIGHT_8_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N06.BorderWidth = 0.5F;
            this.C_NIGHT_8_N06.CanGrow = false;
            this.C_NIGHT_8_N06.Dpi = 100F;
            this.C_NIGHT_8_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 447F);
            this.C_NIGHT_8_N06.Multiline = true;
            this.C_NIGHT_8_N06.Name = "C_NIGHT_8_N06";
            this.C_NIGHT_8_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N06.Text = "";
            this.C_NIGHT_8_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N06.WordWrap = false;
            // 
            // C_NIGHT_8_N07
            // 
            this.C_NIGHT_8_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N07.BorderWidth = 0.5F;
            this.C_NIGHT_8_N07.CanGrow = false;
            this.C_NIGHT_8_N07.Dpi = 100F;
            this.C_NIGHT_8_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 447F);
            this.C_NIGHT_8_N07.Multiline = true;
            this.C_NIGHT_8_N07.Name = "C_NIGHT_8_N07";
            this.C_NIGHT_8_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N07.Text = "";
            this.C_NIGHT_8_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N07.WordWrap = false;
            // 
            // C_NIGHT_8_N08
            // 
            this.C_NIGHT_8_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N08.BorderWidth = 0.5F;
            this.C_NIGHT_8_N08.CanGrow = false;
            this.C_NIGHT_8_N08.Dpi = 100F;
            this.C_NIGHT_8_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 447F);
            this.C_NIGHT_8_N08.Multiline = true;
            this.C_NIGHT_8_N08.Name = "C_NIGHT_8_N08";
            this.C_NIGHT_8_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N08.Text = "";
            this.C_NIGHT_8_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N08.WordWrap = false;
            // 
            // C_NIGHT_8_N09
            // 
            this.C_NIGHT_8_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N09.BorderWidth = 0.5F;
            this.C_NIGHT_8_N09.CanGrow = false;
            this.C_NIGHT_8_N09.Dpi = 100F;
            this.C_NIGHT_8_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 447F);
            this.C_NIGHT_8_N09.Multiline = true;
            this.C_NIGHT_8_N09.Name = "C_NIGHT_8_N09";
            this.C_NIGHT_8_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N09.Text = "";
            this.C_NIGHT_8_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N09.WordWrap = false;
            // 
            // C_NIGHT_8_N10
            // 
            this.C_NIGHT_8_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N10.BorderWidth = 0.5F;
            this.C_NIGHT_8_N10.CanGrow = false;
            this.C_NIGHT_8_N10.Dpi = 100F;
            this.C_NIGHT_8_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 447F);
            this.C_NIGHT_8_N10.Multiline = true;
            this.C_NIGHT_8_N10.Name = "C_NIGHT_8_N10";
            this.C_NIGHT_8_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N10.Text = "";
            this.C_NIGHT_8_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N10.WordWrap = false;
            // 
            // C_NIGHT_8_N11
            // 
            this.C_NIGHT_8_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N11.BorderWidth = 0.5F;
            this.C_NIGHT_8_N11.CanGrow = false;
            this.C_NIGHT_8_N11.Dpi = 100F;
            this.C_NIGHT_8_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 447F);
            this.C_NIGHT_8_N11.Multiline = true;
            this.C_NIGHT_8_N11.Name = "C_NIGHT_8_N11";
            this.C_NIGHT_8_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N11.Text = "";
            this.C_NIGHT_8_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N11.WordWrap = false;
            // 
            // C_NIGHT_8_N12
            // 
            this.C_NIGHT_8_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N12.BorderWidth = 0.5F;
            this.C_NIGHT_8_N12.CanGrow = false;
            this.C_NIGHT_8_N12.Dpi = 100F;
            this.C_NIGHT_8_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 447F);
            this.C_NIGHT_8_N12.Multiline = true;
            this.C_NIGHT_8_N12.Name = "C_NIGHT_8_N12";
            this.C_NIGHT_8_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N12.Text = "";
            this.C_NIGHT_8_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N12.WordWrap = false;
            // 
            // C_NIGHT_8_N13
            // 
            this.C_NIGHT_8_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_8_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_8_N13.BorderWidth = 0.5F;
            this.C_NIGHT_8_N13.CanGrow = false;
            this.C_NIGHT_8_N13.Dpi = 100F;
            this.C_NIGHT_8_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 447F);
            this.C_NIGHT_8_N13.Multiline = true;
            this.C_NIGHT_8_N13.Name = "C_NIGHT_8_N13";
            this.C_NIGHT_8_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_8_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_8_N13.Text = "";
            this.C_NIGHT_8_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_8_N13.WordWrap = false;
            // 
            // L_NIGHT_SUM
            // 
            this.L_NIGHT_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.L_NIGHT_SUM.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHT_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT_SUM.BorderWidth = 0.5F;
            this.L_NIGHT_SUM.CanGrow = false;
            this.L_NIGHT_SUM.Dpi = 100F;
            this.L_NIGHT_SUM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 462F);
            this.L_NIGHT_SUM.Multiline = true;
            this.L_NIGHT_SUM.Name = "L_NIGHT_SUM";
            this.L_NIGHT_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHT_SUM.SizeF = new System.Drawing.SizeF(204F, 15F);
            this.L_NIGHT_SUM.Text = "합계";
            this.L_NIGHT_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT_SUM.WordWrap = false;
            // 
            // C_NIGHT_SUM_GOOD
            // 
            this.C_NIGHT_SUM_GOOD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_GOOD.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_GOOD.CanGrow = false;
            this.C_NIGHT_SUM_GOOD.Dpi = 100F;
            this.C_NIGHT_SUM_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 462F);
            this.C_NIGHT_SUM_GOOD.Multiline = true;
            this.C_NIGHT_SUM_GOOD.Name = "C_NIGHT_SUM_GOOD";
            this.C_NIGHT_SUM_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_SUM_GOOD.Text = "";
            this.C_NIGHT_SUM_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_GOOD.WordWrap = false;
            // 
            // C_NIGHT_SUM_BAD
            // 
            this.C_NIGHT_SUM_BAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_BAD.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_BAD.CanGrow = false;
            this.C_NIGHT_SUM_BAD.Dpi = 100F;
            this.C_NIGHT_SUM_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 462F);
            this.C_NIGHT_SUM_BAD.Multiline = true;
            this.C_NIGHT_SUM_BAD.Name = "C_NIGHT_SUM_BAD";
            this.C_NIGHT_SUM_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_NIGHT_SUM_BAD.Text = "";
            this.C_NIGHT_SUM_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_BAD.WordWrap = false;
            // 
            // C_NIGHT_SUM_SUM
            // 
            this.C_NIGHT_SUM_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_SUM.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_SUM.CanGrow = false;
            this.C_NIGHT_SUM_SUM.Dpi = 100F;
            this.C_NIGHT_SUM_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 462F);
            this.C_NIGHT_SUM_SUM.Multiline = true;
            this.C_NIGHT_SUM_SUM.Name = "C_NIGHT_SUM_SUM";
            this.C_NIGHT_SUM_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_NIGHT_SUM_SUM.Text = "";
            this.C_NIGHT_SUM_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_SUM.WordWrap = false;
            // 
            // C_NIGHT_SUM_N01
            // 
            this.C_NIGHT_SUM_N01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N01.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N01.CanGrow = false;
            this.C_NIGHT_SUM_N01.Dpi = 100F;
            this.C_NIGHT_SUM_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 462F);
            this.C_NIGHT_SUM_N01.Multiline = true;
            this.C_NIGHT_SUM_N01.Name = "C_NIGHT_SUM_N01";
            this.C_NIGHT_SUM_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N01.Text = "";
            this.C_NIGHT_SUM_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N01.WordWrap = false;
            // 
            // C_NIGHT_SUM_N02
            // 
            this.C_NIGHT_SUM_N02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N02.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N02.CanGrow = false;
            this.C_NIGHT_SUM_N02.Dpi = 100F;
            this.C_NIGHT_SUM_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 462F);
            this.C_NIGHT_SUM_N02.Multiline = true;
            this.C_NIGHT_SUM_N02.Name = "C_NIGHT_SUM_N02";
            this.C_NIGHT_SUM_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N02.Text = "";
            this.C_NIGHT_SUM_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N02.WordWrap = false;
            // 
            // C_NIGHT_SUM_N03
            // 
            this.C_NIGHT_SUM_N03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N03.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N03.CanGrow = false;
            this.C_NIGHT_SUM_N03.Dpi = 100F;
            this.C_NIGHT_SUM_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 462F);
            this.C_NIGHT_SUM_N03.Multiline = true;
            this.C_NIGHT_SUM_N03.Name = "C_NIGHT_SUM_N03";
            this.C_NIGHT_SUM_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N03.Text = "";
            this.C_NIGHT_SUM_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N03.WordWrap = false;
            // 
            // C_NIGHT_SUM_N04
            // 
            this.C_NIGHT_SUM_N04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N04.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N04.CanGrow = false;
            this.C_NIGHT_SUM_N04.Dpi = 100F;
            this.C_NIGHT_SUM_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 462F);
            this.C_NIGHT_SUM_N04.Multiline = true;
            this.C_NIGHT_SUM_N04.Name = "C_NIGHT_SUM_N04";
            this.C_NIGHT_SUM_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N04.Text = "";
            this.C_NIGHT_SUM_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N04.WordWrap = false;
            // 
            // C_NIGHT_SUM_N05
            // 
            this.C_NIGHT_SUM_N05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N05.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N05.CanGrow = false;
            this.C_NIGHT_SUM_N05.Dpi = 100F;
            this.C_NIGHT_SUM_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 462F);
            this.C_NIGHT_SUM_N05.Multiline = true;
            this.C_NIGHT_SUM_N05.Name = "C_NIGHT_SUM_N05";
            this.C_NIGHT_SUM_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N05.Text = "";
            this.C_NIGHT_SUM_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N05.WordWrap = false;
            // 
            // C_NIGHT_SUM_N06
            // 
            this.C_NIGHT_SUM_N06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N06.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N06.CanGrow = false;
            this.C_NIGHT_SUM_N06.Dpi = 100F;
            this.C_NIGHT_SUM_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 462F);
            this.C_NIGHT_SUM_N06.Multiline = true;
            this.C_NIGHT_SUM_N06.Name = "C_NIGHT_SUM_N06";
            this.C_NIGHT_SUM_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N06.Text = "";
            this.C_NIGHT_SUM_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N06.WordWrap = false;
            // 
            // C_NIGHT_SUM_N07
            // 
            this.C_NIGHT_SUM_N07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N07.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N07.CanGrow = false;
            this.C_NIGHT_SUM_N07.Dpi = 100F;
            this.C_NIGHT_SUM_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 462F);
            this.C_NIGHT_SUM_N07.Multiline = true;
            this.C_NIGHT_SUM_N07.Name = "C_NIGHT_SUM_N07";
            this.C_NIGHT_SUM_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N07.Text = "";
            this.C_NIGHT_SUM_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N07.WordWrap = false;
            // 
            // C_NIGHT_SUM_N08
            // 
            this.C_NIGHT_SUM_N08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N08.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N08.CanGrow = false;
            this.C_NIGHT_SUM_N08.Dpi = 100F;
            this.C_NIGHT_SUM_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 462F);
            this.C_NIGHT_SUM_N08.Multiline = true;
            this.C_NIGHT_SUM_N08.Name = "C_NIGHT_SUM_N08";
            this.C_NIGHT_SUM_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N08.Text = "";
            this.C_NIGHT_SUM_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N08.WordWrap = false;
            // 
            // C_NIGHT_SUM_N09
            // 
            this.C_NIGHT_SUM_N09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N09.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N09.CanGrow = false;
            this.C_NIGHT_SUM_N09.Dpi = 100F;
            this.C_NIGHT_SUM_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 462F);
            this.C_NIGHT_SUM_N09.Multiline = true;
            this.C_NIGHT_SUM_N09.Name = "C_NIGHT_SUM_N09";
            this.C_NIGHT_SUM_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N09.Text = "";
            this.C_NIGHT_SUM_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N09.WordWrap = false;
            // 
            // C_NIGHT_SUM_N10
            // 
            this.C_NIGHT_SUM_N10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N10.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N10.CanGrow = false;
            this.C_NIGHT_SUM_N10.Dpi = 100F;
            this.C_NIGHT_SUM_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 462F);
            this.C_NIGHT_SUM_N10.Multiline = true;
            this.C_NIGHT_SUM_N10.Name = "C_NIGHT_SUM_N10";
            this.C_NIGHT_SUM_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N10.Text = "";
            this.C_NIGHT_SUM_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N10.WordWrap = false;
            // 
            // C_NIGHT_SUM_N11
            // 
            this.C_NIGHT_SUM_N11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N11.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N11.CanGrow = false;
            this.C_NIGHT_SUM_N11.Dpi = 100F;
            this.C_NIGHT_SUM_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 462F);
            this.C_NIGHT_SUM_N11.Multiline = true;
            this.C_NIGHT_SUM_N11.Name = "C_NIGHT_SUM_N11";
            this.C_NIGHT_SUM_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N11.Text = "";
            this.C_NIGHT_SUM_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N11.WordWrap = false;
            // 
            // C_NIGHT_SUM_N12
            // 
            this.C_NIGHT_SUM_N12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N12.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N12.CanGrow = false;
            this.C_NIGHT_SUM_N12.Dpi = 100F;
            this.C_NIGHT_SUM_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 462F);
            this.C_NIGHT_SUM_N12.Multiline = true;
            this.C_NIGHT_SUM_N12.Name = "C_NIGHT_SUM_N12";
            this.C_NIGHT_SUM_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N12.Text = "";
            this.C_NIGHT_SUM_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N12.WordWrap = false;
            // 
            // C_NIGHT_SUM_N13
            // 
            this.C_NIGHT_SUM_N13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.C_NIGHT_SUM_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHT_SUM_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHT_SUM_N13.BorderWidth = 0.5F;
            this.C_NIGHT_SUM_N13.CanGrow = false;
            this.C_NIGHT_SUM_N13.Dpi = 100F;
            this.C_NIGHT_SUM_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 462F);
            this.C_NIGHT_SUM_N13.Multiline = true;
            this.C_NIGHT_SUM_N13.Name = "C_NIGHT_SUM_N13";
            this.C_NIGHT_SUM_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_NIGHT_SUM_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_NIGHT_SUM_N13.Text = "";
            this.C_NIGHT_SUM_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_NIGHT_SUM_N13.WordWrap = false;
            // 
            // L_TOTAL
            // 
            this.L_TOTAL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.L_TOTAL.BorderColor = System.Drawing.Color.Gray;
            this.L_TOTAL.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_TOTAL.BorderWidth = 0.5F;
            this.L_TOTAL.CanGrow = false;
            this.L_TOTAL.Dpi = 100F;
            this.L_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_TOTAL.LocationFloat = new DevExpress.Utils.PointFloat(0F, 477F);
            this.L_TOTAL.Multiline = true;
            this.L_TOTAL.Name = "L_TOTAL";
            this.L_TOTAL.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_TOTAL.SizeF = new System.Drawing.SizeF(204F, 15F);
            this.L_TOTAL.Text = "총 합계";
            this.L_TOTAL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_TOTAL.WordWrap = false;
            // 
            // C_TOTAL_GOOD
            // 
            this.C_TOTAL_GOOD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_GOOD.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_GOOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_GOOD.BorderWidth = 0.5F;
            this.C_TOTAL_GOOD.CanGrow = false;
            this.C_TOTAL_GOOD.Dpi = 100F;
            this.C_TOTAL_GOOD.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_GOOD.LocationFloat = new DevExpress.Utils.PointFloat(204F, 477F);
            this.C_TOTAL_GOOD.Multiline = true;
            this.C_TOTAL_GOOD.Name = "C_TOTAL_GOOD";
            this.C_TOTAL_GOOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_GOOD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_TOTAL_GOOD.Text = "";
            this.C_TOTAL_GOOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_GOOD.WordWrap = false;
            // 
            // C_TOTAL_BAD
            // 
            this.C_TOTAL_BAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_BAD.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_BAD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_BAD.BorderWidth = 0.5F;
            this.C_TOTAL_BAD.CanGrow = false;
            this.C_TOTAL_BAD.Dpi = 100F;
            this.C_TOTAL_BAD.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_BAD.LocationFloat = new DevExpress.Utils.PointFloat(246F, 477F);
            this.C_TOTAL_BAD.Multiline = true;
            this.C_TOTAL_BAD.Name = "C_TOTAL_BAD";
            this.C_TOTAL_BAD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_BAD.SizeF = new System.Drawing.SizeF(42F, 15F);
            this.C_TOTAL_BAD.Text = "";
            this.C_TOTAL_BAD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_BAD.WordWrap = false;
            // 
            // C_TOTAL_SUM
            // 
            this.C_TOTAL_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_SUM.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_SUM.BorderWidth = 0.5F;
            this.C_TOTAL_SUM.CanGrow = false;
            this.C_TOTAL_SUM.Dpi = 100F;
            this.C_TOTAL_SUM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_SUM.LocationFloat = new DevExpress.Utils.PointFloat(288F, 477F);
            this.C_TOTAL_SUM.Multiline = true;
            this.C_TOTAL_SUM.Name = "C_TOTAL_SUM";
            this.C_TOTAL_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_SUM.SizeF = new System.Drawing.SizeF(49F, 15F);
            this.C_TOTAL_SUM.Text = "";
            this.C_TOTAL_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_SUM.WordWrap = false;
            // 
            // C_TOTAL_N01
            // 
            this.C_TOTAL_N01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N01.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N01.BorderWidth = 0.5F;
            this.C_TOTAL_N01.CanGrow = false;
            this.C_TOTAL_N01.Dpi = 100F;
            this.C_TOTAL_N01.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N01.LocationFloat = new DevExpress.Utils.PointFloat(337F, 477F);
            this.C_TOTAL_N01.Multiline = true;
            this.C_TOTAL_N01.Name = "C_TOTAL_N01";
            this.C_TOTAL_N01.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N01.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N01.Text = "";
            this.C_TOTAL_N01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N01.WordWrap = false;
            // 
            // C_TOTAL_N02
            // 
            this.C_TOTAL_N02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N02.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N02.BorderWidth = 0.5F;
            this.C_TOTAL_N02.CanGrow = false;
            this.C_TOTAL_N02.Dpi = 100F;
            this.C_TOTAL_N02.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N02.LocationFloat = new DevExpress.Utils.PointFloat(380F, 477F);
            this.C_TOTAL_N02.Multiline = true;
            this.C_TOTAL_N02.Name = "C_TOTAL_N02";
            this.C_TOTAL_N02.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N02.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N02.Text = "";
            this.C_TOTAL_N02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N02.WordWrap = false;
            // 
            // C_TOTAL_N03
            // 
            this.C_TOTAL_N03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N03.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N03.BorderWidth = 0.5F;
            this.C_TOTAL_N03.CanGrow = false;
            this.C_TOTAL_N03.Dpi = 100F;
            this.C_TOTAL_N03.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N03.LocationFloat = new DevExpress.Utils.PointFloat(423F, 477F);
            this.C_TOTAL_N03.Multiline = true;
            this.C_TOTAL_N03.Name = "C_TOTAL_N03";
            this.C_TOTAL_N03.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N03.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N03.Text = "";
            this.C_TOTAL_N03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N03.WordWrap = false;
            // 
            // C_TOTAL_N04
            // 
            this.C_TOTAL_N04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N04.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N04.BorderWidth = 0.5F;
            this.C_TOTAL_N04.CanGrow = false;
            this.C_TOTAL_N04.Dpi = 100F;
            this.C_TOTAL_N04.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N04.LocationFloat = new DevExpress.Utils.PointFloat(466F, 477F);
            this.C_TOTAL_N04.Multiline = true;
            this.C_TOTAL_N04.Name = "C_TOTAL_N04";
            this.C_TOTAL_N04.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N04.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N04.Text = "";
            this.C_TOTAL_N04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N04.WordWrap = false;
            // 
            // C_TOTAL_N05
            // 
            this.C_TOTAL_N05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N05.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N05.BorderWidth = 0.5F;
            this.C_TOTAL_N05.CanGrow = false;
            this.C_TOTAL_N05.Dpi = 100F;
            this.C_TOTAL_N05.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N05.LocationFloat = new DevExpress.Utils.PointFloat(509F, 477F);
            this.C_TOTAL_N05.Multiline = true;
            this.C_TOTAL_N05.Name = "C_TOTAL_N05";
            this.C_TOTAL_N05.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N05.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N05.Text = "";
            this.C_TOTAL_N05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N05.WordWrap = false;
            // 
            // C_TOTAL_N06
            // 
            this.C_TOTAL_N06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N06.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N06.BorderWidth = 0.5F;
            this.C_TOTAL_N06.CanGrow = false;
            this.C_TOTAL_N06.Dpi = 100F;
            this.C_TOTAL_N06.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N06.LocationFloat = new DevExpress.Utils.PointFloat(552F, 477F);
            this.C_TOTAL_N06.Multiline = true;
            this.C_TOTAL_N06.Name = "C_TOTAL_N06";
            this.C_TOTAL_N06.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N06.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N06.Text = "";
            this.C_TOTAL_N06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N06.WordWrap = false;
            // 
            // C_TOTAL_N07
            // 
            this.C_TOTAL_N07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N07.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N07.BorderWidth = 0.5F;
            this.C_TOTAL_N07.CanGrow = false;
            this.C_TOTAL_N07.Dpi = 100F;
            this.C_TOTAL_N07.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N07.LocationFloat = new DevExpress.Utils.PointFloat(595F, 477F);
            this.C_TOTAL_N07.Multiline = true;
            this.C_TOTAL_N07.Name = "C_TOTAL_N07";
            this.C_TOTAL_N07.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N07.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N07.Text = "";
            this.C_TOTAL_N07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N07.WordWrap = false;
            // 
            // C_TOTAL_N08
            // 
            this.C_TOTAL_N08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N08.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N08.BorderWidth = 0.5F;
            this.C_TOTAL_N08.CanGrow = false;
            this.C_TOTAL_N08.Dpi = 100F;
            this.C_TOTAL_N08.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N08.LocationFloat = new DevExpress.Utils.PointFloat(638F, 477F);
            this.C_TOTAL_N08.Multiline = true;
            this.C_TOTAL_N08.Name = "C_TOTAL_N08";
            this.C_TOTAL_N08.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N08.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N08.Text = "";
            this.C_TOTAL_N08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N08.WordWrap = false;
            // 
            // C_TOTAL_N09
            // 
            this.C_TOTAL_N09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N09.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N09.BorderWidth = 0.5F;
            this.C_TOTAL_N09.CanGrow = false;
            this.C_TOTAL_N09.Dpi = 100F;
            this.C_TOTAL_N09.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N09.LocationFloat = new DevExpress.Utils.PointFloat(681F, 477F);
            this.C_TOTAL_N09.Multiline = true;
            this.C_TOTAL_N09.Name = "C_TOTAL_N09";
            this.C_TOTAL_N09.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N09.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N09.Text = "";
            this.C_TOTAL_N09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N09.WordWrap = false;
            // 
            // C_TOTAL_N10
            // 
            this.C_TOTAL_N10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N10.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N10.BorderWidth = 0.5F;
            this.C_TOTAL_N10.CanGrow = false;
            this.C_TOTAL_N10.Dpi = 100F;
            this.C_TOTAL_N10.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N10.LocationFloat = new DevExpress.Utils.PointFloat(724F, 477F);
            this.C_TOTAL_N10.Multiline = true;
            this.C_TOTAL_N10.Name = "C_TOTAL_N10";
            this.C_TOTAL_N10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N10.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N10.Text = "";
            this.C_TOTAL_N10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N10.WordWrap = false;
            // 
            // C_TOTAL_N11
            // 
            this.C_TOTAL_N11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N11.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N11.BorderWidth = 0.5F;
            this.C_TOTAL_N11.CanGrow = false;
            this.C_TOTAL_N11.Dpi = 100F;
            this.C_TOTAL_N11.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N11.LocationFloat = new DevExpress.Utils.PointFloat(767F, 477F);
            this.C_TOTAL_N11.Multiline = true;
            this.C_TOTAL_N11.Name = "C_TOTAL_N11";
            this.C_TOTAL_N11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N11.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N11.Text = "";
            this.C_TOTAL_N11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N11.WordWrap = false;
            // 
            // C_TOTAL_N12
            // 
            this.C_TOTAL_N12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N12.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N12.BorderWidth = 0.5F;
            this.C_TOTAL_N12.CanGrow = false;
            this.C_TOTAL_N12.Dpi = 100F;
            this.C_TOTAL_N12.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N12.LocationFloat = new DevExpress.Utils.PointFloat(810F, 477F);
            this.C_TOTAL_N12.Multiline = true;
            this.C_TOTAL_N12.Name = "C_TOTAL_N12";
            this.C_TOTAL_N12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N12.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N12.Text = "";
            this.C_TOTAL_N12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N12.WordWrap = false;
            // 
            // C_TOTAL_N13
            // 
            this.C_TOTAL_N13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.C_TOTAL_N13.BorderColor = System.Drawing.Color.Gray;
            this.C_TOTAL_N13.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_TOTAL_N13.BorderWidth = 0.5F;
            this.C_TOTAL_N13.CanGrow = false;
            this.C_TOTAL_N13.Dpi = 100F;
            this.C_TOTAL_N13.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_TOTAL_N13.LocationFloat = new DevExpress.Utils.PointFloat(853F, 477F);
            this.C_TOTAL_N13.Multiline = true;
            this.C_TOTAL_N13.Name = "C_TOTAL_N13";
            this.C_TOTAL_N13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TOTAL_N13.SizeF = new System.Drawing.SizeF(43F, 15F);
            this.C_TOTAL_N13.Text = "";
            this.C_TOTAL_N13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TOTAL_N13.WordWrap = false;
            // 
            // L_BAD_TITLE
            // 
            this.L_BAD_TITLE.BorderColor = System.Drawing.Color.Gray;
            this.L_BAD_TITLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_BAD_TITLE.BorderWidth = 0.5F;
            this.L_BAD_TITLE.CanGrow = false;
            this.L_BAD_TITLE.Dpi = 100F;
            this.L_BAD_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(911F, 175F);
            this.L_BAD_TITLE.Multiline = true;
            this.L_BAD_TITLE.Name = "L_BAD_TITLE";
            this.L_BAD_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_BAD_TITLE.SizeF = new System.Drawing.SizeF(218F, 16F);
            this.L_BAD_TITLE.Text = "불량현황";
            this.L_BAD_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_BAD_TITLE.WordWrap = false;
            // 
            // L_BAD_H_TP
            // 
            this.L_BAD_H_TP.BorderColor = System.Drawing.Color.Gray;
            this.L_BAD_H_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_BAD_H_TP.BorderWidth = 0.5F;
            this.L_BAD_H_TP.CanGrow = false;
            this.L_BAD_H_TP.Dpi = 100F;
            this.L_BAD_H_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 191F);
            this.L_BAD_H_TP.Multiline = true;
            this.L_BAD_H_TP.Name = "L_BAD_H_TP";
            this.L_BAD_H_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_BAD_H_TP.SizeF = new System.Drawing.SizeF(70F, 16F);
            this.L_BAD_H_TP.Text = "중분류";
            this.L_BAD_H_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_BAD_H_TP.WordWrap = false;
            // 
            // L_BAD_H_NM
            // 
            this.L_BAD_H_NM.BorderColor = System.Drawing.Color.Gray;
            this.L_BAD_H_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_BAD_H_NM.BorderWidth = 0.5F;
            this.L_BAD_H_NM.CanGrow = false;
            this.L_BAD_H_NM.Dpi = 100F;
            this.L_BAD_H_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 191F);
            this.L_BAD_H_NM.Multiline = true;
            this.L_BAD_H_NM.Name = "L_BAD_H_NM";
            this.L_BAD_H_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_BAD_H_NM.SizeF = new System.Drawing.SizeF(90F, 16F);
            this.L_BAD_H_NM.Text = "불량명";
            this.L_BAD_H_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_BAD_H_NM.WordWrap = false;
            // 
            // L_BAD_H_QTY
            // 
            this.L_BAD_H_QTY.BorderColor = System.Drawing.Color.Gray;
            this.L_BAD_H_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_BAD_H_QTY.BorderWidth = 0.5F;
            this.L_BAD_H_QTY.CanGrow = false;
            this.L_BAD_H_QTY.Dpi = 100F;
            this.L_BAD_H_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 191F);
            this.L_BAD_H_QTY.Multiline = true;
            this.L_BAD_H_QTY.Name = "L_BAD_H_QTY";
            this.L_BAD_H_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_BAD_H_QTY.SizeF = new System.Drawing.SizeF(58F, 16F);
            this.L_BAD_H_QTY.Text = "수량";
            this.L_BAD_H_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_BAD_H_QTY.WordWrap = false;
            // 
            // C_BAD_1_TP
            // 
            this.C_BAD_1_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_1_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_1_TP.BorderWidth = 0.5F;
            this.C_BAD_1_TP.CanGrow = false;
            this.C_BAD_1_TP.Dpi = 100F;
            this.C_BAD_1_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 207F);
            this.C_BAD_1_TP.Multiline = true;
            this.C_BAD_1_TP.Name = "C_BAD_1_TP";
            this.C_BAD_1_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_1_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_1_TP.Text = "";
            this.C_BAD_1_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_1_TP.WordWrap = false;
            // 
            // C_BAD_1_NM
            // 
            this.C_BAD_1_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_1_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_1_NM.BorderWidth = 0.5F;
            this.C_BAD_1_NM.CanGrow = false;
            this.C_BAD_1_NM.Dpi = 100F;
            this.C_BAD_1_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 207F);
            this.C_BAD_1_NM.Multiline = true;
            this.C_BAD_1_NM.Name = "C_BAD_1_NM";
            this.C_BAD_1_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_1_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_1_NM.Text = "";
            this.C_BAD_1_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_1_NM.WordWrap = false;
            // 
            // C_BAD_1_QTY
            // 
            this.C_BAD_1_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_1_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_1_QTY.BorderWidth = 0.5F;
            this.C_BAD_1_QTY.CanGrow = false;
            this.C_BAD_1_QTY.Dpi = 100F;
            this.C_BAD_1_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 207F);
            this.C_BAD_1_QTY.Multiline = true;
            this.C_BAD_1_QTY.Name = "C_BAD_1_QTY";
            this.C_BAD_1_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_1_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_1_QTY.Text = "";
            this.C_BAD_1_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_1_QTY.WordWrap = false;
            // 
            // C_BAD_2_TP
            // 
            this.C_BAD_2_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_2_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_2_TP.BorderWidth = 0.5F;
            this.C_BAD_2_TP.CanGrow = false;
            this.C_BAD_2_TP.Dpi = 100F;
            this.C_BAD_2_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 222F);
            this.C_BAD_2_TP.Multiline = true;
            this.C_BAD_2_TP.Name = "C_BAD_2_TP";
            this.C_BAD_2_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_2_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_2_TP.Text = "";
            this.C_BAD_2_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_2_TP.WordWrap = false;
            // 
            // C_BAD_2_NM
            // 
            this.C_BAD_2_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_2_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_2_NM.BorderWidth = 0.5F;
            this.C_BAD_2_NM.CanGrow = false;
            this.C_BAD_2_NM.Dpi = 100F;
            this.C_BAD_2_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 222F);
            this.C_BAD_2_NM.Multiline = true;
            this.C_BAD_2_NM.Name = "C_BAD_2_NM";
            this.C_BAD_2_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_2_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_2_NM.Text = "";
            this.C_BAD_2_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_2_NM.WordWrap = false;
            // 
            // C_BAD_2_QTY
            // 
            this.C_BAD_2_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_2_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_2_QTY.BorderWidth = 0.5F;
            this.C_BAD_2_QTY.CanGrow = false;
            this.C_BAD_2_QTY.Dpi = 100F;
            this.C_BAD_2_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 222F);
            this.C_BAD_2_QTY.Multiline = true;
            this.C_BAD_2_QTY.Name = "C_BAD_2_QTY";
            this.C_BAD_2_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_2_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_2_QTY.Text = "";
            this.C_BAD_2_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_2_QTY.WordWrap = false;
            // 
            // C_BAD_3_TP
            // 
            this.C_BAD_3_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_3_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_3_TP.BorderWidth = 0.5F;
            this.C_BAD_3_TP.CanGrow = false;
            this.C_BAD_3_TP.Dpi = 100F;
            this.C_BAD_3_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 237F);
            this.C_BAD_3_TP.Multiline = true;
            this.C_BAD_3_TP.Name = "C_BAD_3_TP";
            this.C_BAD_3_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_3_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_3_TP.Text = "";
            this.C_BAD_3_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_3_TP.WordWrap = false;
            // 
            // C_BAD_3_NM
            // 
            this.C_BAD_3_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_3_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_3_NM.BorderWidth = 0.5F;
            this.C_BAD_3_NM.CanGrow = false;
            this.C_BAD_3_NM.Dpi = 100F;
            this.C_BAD_3_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 237F);
            this.C_BAD_3_NM.Multiline = true;
            this.C_BAD_3_NM.Name = "C_BAD_3_NM";
            this.C_BAD_3_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_3_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_3_NM.Text = "";
            this.C_BAD_3_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_3_NM.WordWrap = false;
            // 
            // C_BAD_3_QTY
            // 
            this.C_BAD_3_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_3_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_3_QTY.BorderWidth = 0.5F;
            this.C_BAD_3_QTY.CanGrow = false;
            this.C_BAD_3_QTY.Dpi = 100F;
            this.C_BAD_3_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 237F);
            this.C_BAD_3_QTY.Multiline = true;
            this.C_BAD_3_QTY.Name = "C_BAD_3_QTY";
            this.C_BAD_3_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_3_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_3_QTY.Text = "";
            this.C_BAD_3_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_3_QTY.WordWrap = false;
            // 
            // C_BAD_4_TP
            // 
            this.C_BAD_4_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_4_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_4_TP.BorderWidth = 0.5F;
            this.C_BAD_4_TP.CanGrow = false;
            this.C_BAD_4_TP.Dpi = 100F;
            this.C_BAD_4_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 252F);
            this.C_BAD_4_TP.Multiline = true;
            this.C_BAD_4_TP.Name = "C_BAD_4_TP";
            this.C_BAD_4_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_4_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_4_TP.Text = "";
            this.C_BAD_4_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_4_TP.WordWrap = false;
            // 
            // C_BAD_4_NM
            // 
            this.C_BAD_4_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_4_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_4_NM.BorderWidth = 0.5F;
            this.C_BAD_4_NM.CanGrow = false;
            this.C_BAD_4_NM.Dpi = 100F;
            this.C_BAD_4_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 252F);
            this.C_BAD_4_NM.Multiline = true;
            this.C_BAD_4_NM.Name = "C_BAD_4_NM";
            this.C_BAD_4_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_4_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_4_NM.Text = "";
            this.C_BAD_4_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_4_NM.WordWrap = false;
            // 
            // C_BAD_4_QTY
            // 
            this.C_BAD_4_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_4_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_4_QTY.BorderWidth = 0.5F;
            this.C_BAD_4_QTY.CanGrow = false;
            this.C_BAD_4_QTY.Dpi = 100F;
            this.C_BAD_4_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 252F);
            this.C_BAD_4_QTY.Multiline = true;
            this.C_BAD_4_QTY.Name = "C_BAD_4_QTY";
            this.C_BAD_4_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_4_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_4_QTY.Text = "";
            this.C_BAD_4_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_4_QTY.WordWrap = false;
            // 
            // C_BAD_5_TP
            // 
            this.C_BAD_5_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_5_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_5_TP.BorderWidth = 0.5F;
            this.C_BAD_5_TP.CanGrow = false;
            this.C_BAD_5_TP.Dpi = 100F;
            this.C_BAD_5_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 267F);
            this.C_BAD_5_TP.Multiline = true;
            this.C_BAD_5_TP.Name = "C_BAD_5_TP";
            this.C_BAD_5_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_5_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_5_TP.Text = "";
            this.C_BAD_5_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_5_TP.WordWrap = false;
            // 
            // C_BAD_5_NM
            // 
            this.C_BAD_5_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_5_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_5_NM.BorderWidth = 0.5F;
            this.C_BAD_5_NM.CanGrow = false;
            this.C_BAD_5_NM.Dpi = 100F;
            this.C_BAD_5_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 267F);
            this.C_BAD_5_NM.Multiline = true;
            this.C_BAD_5_NM.Name = "C_BAD_5_NM";
            this.C_BAD_5_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_5_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_5_NM.Text = "";
            this.C_BAD_5_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_5_NM.WordWrap = false;
            // 
            // C_BAD_5_QTY
            // 
            this.C_BAD_5_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_5_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_5_QTY.BorderWidth = 0.5F;
            this.C_BAD_5_QTY.CanGrow = false;
            this.C_BAD_5_QTY.Dpi = 100F;
            this.C_BAD_5_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 267F);
            this.C_BAD_5_QTY.Multiline = true;
            this.C_BAD_5_QTY.Name = "C_BAD_5_QTY";
            this.C_BAD_5_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_5_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_5_QTY.Text = "";
            this.C_BAD_5_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_5_QTY.WordWrap = false;
            // 
            // C_BAD_6_TP
            // 
            this.C_BAD_6_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_6_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_6_TP.BorderWidth = 0.5F;
            this.C_BAD_6_TP.CanGrow = false;
            this.C_BAD_6_TP.Dpi = 100F;
            this.C_BAD_6_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 282F);
            this.C_BAD_6_TP.Multiline = true;
            this.C_BAD_6_TP.Name = "C_BAD_6_TP";
            this.C_BAD_6_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_6_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_6_TP.Text = "";
            this.C_BAD_6_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_6_TP.WordWrap = false;
            // 
            // C_BAD_6_NM
            // 
            this.C_BAD_6_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_6_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_6_NM.BorderWidth = 0.5F;
            this.C_BAD_6_NM.CanGrow = false;
            this.C_BAD_6_NM.Dpi = 100F;
            this.C_BAD_6_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 282F);
            this.C_BAD_6_NM.Multiline = true;
            this.C_BAD_6_NM.Name = "C_BAD_6_NM";
            this.C_BAD_6_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_6_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_6_NM.Text = "";
            this.C_BAD_6_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_6_NM.WordWrap = false;
            // 
            // C_BAD_6_QTY
            // 
            this.C_BAD_6_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_6_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_6_QTY.BorderWidth = 0.5F;
            this.C_BAD_6_QTY.CanGrow = false;
            this.C_BAD_6_QTY.Dpi = 100F;
            this.C_BAD_6_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 282F);
            this.C_BAD_6_QTY.Multiline = true;
            this.C_BAD_6_QTY.Name = "C_BAD_6_QTY";
            this.C_BAD_6_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_6_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_6_QTY.Text = "";
            this.C_BAD_6_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_6_QTY.WordWrap = false;
            // 
            // C_BAD_7_TP
            // 
            this.C_BAD_7_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_7_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_7_TP.BorderWidth = 0.5F;
            this.C_BAD_7_TP.CanGrow = false;
            this.C_BAD_7_TP.Dpi = 100F;
            this.C_BAD_7_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 297F);
            this.C_BAD_7_TP.Multiline = true;
            this.C_BAD_7_TP.Name = "C_BAD_7_TP";
            this.C_BAD_7_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_7_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_7_TP.Text = "";
            this.C_BAD_7_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_7_TP.WordWrap = false;
            // 
            // C_BAD_7_NM
            // 
            this.C_BAD_7_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_7_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_7_NM.BorderWidth = 0.5F;
            this.C_BAD_7_NM.CanGrow = false;
            this.C_BAD_7_NM.Dpi = 100F;
            this.C_BAD_7_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 297F);
            this.C_BAD_7_NM.Multiline = true;
            this.C_BAD_7_NM.Name = "C_BAD_7_NM";
            this.C_BAD_7_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_7_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_7_NM.Text = "";
            this.C_BAD_7_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_7_NM.WordWrap = false;
            // 
            // C_BAD_7_QTY
            // 
            this.C_BAD_7_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_7_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_7_QTY.BorderWidth = 0.5F;
            this.C_BAD_7_QTY.CanGrow = false;
            this.C_BAD_7_QTY.Dpi = 100F;
            this.C_BAD_7_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 297F);
            this.C_BAD_7_QTY.Multiline = true;
            this.C_BAD_7_QTY.Name = "C_BAD_7_QTY";
            this.C_BAD_7_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_7_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_7_QTY.Text = "";
            this.C_BAD_7_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_7_QTY.WordWrap = false;
            // 
            // C_BAD_8_TP
            // 
            this.C_BAD_8_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_8_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_8_TP.BorderWidth = 0.5F;
            this.C_BAD_8_TP.CanGrow = false;
            this.C_BAD_8_TP.Dpi = 100F;
            this.C_BAD_8_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 312F);
            this.C_BAD_8_TP.Multiline = true;
            this.C_BAD_8_TP.Name = "C_BAD_8_TP";
            this.C_BAD_8_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_8_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_8_TP.Text = "";
            this.C_BAD_8_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_8_TP.WordWrap = false;
            // 
            // C_BAD_8_NM
            // 
            this.C_BAD_8_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_8_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_8_NM.BorderWidth = 0.5F;
            this.C_BAD_8_NM.CanGrow = false;
            this.C_BAD_8_NM.Dpi = 100F;
            this.C_BAD_8_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 312F);
            this.C_BAD_8_NM.Multiline = true;
            this.C_BAD_8_NM.Name = "C_BAD_8_NM";
            this.C_BAD_8_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_8_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_8_NM.Text = "";
            this.C_BAD_8_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_8_NM.WordWrap = false;
            // 
            // C_BAD_8_QTY
            // 
            this.C_BAD_8_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_8_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_8_QTY.BorderWidth = 0.5F;
            this.C_BAD_8_QTY.CanGrow = false;
            this.C_BAD_8_QTY.Dpi = 100F;
            this.C_BAD_8_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 312F);
            this.C_BAD_8_QTY.Multiline = true;
            this.C_BAD_8_QTY.Name = "C_BAD_8_QTY";
            this.C_BAD_8_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_8_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_8_QTY.Text = "";
            this.C_BAD_8_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_8_QTY.WordWrap = false;
            // 
            // C_BAD_9_TP
            // 
            this.C_BAD_9_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_9_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_9_TP.BorderWidth = 0.5F;
            this.C_BAD_9_TP.CanGrow = false;
            this.C_BAD_9_TP.Dpi = 100F;
            this.C_BAD_9_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 327F);
            this.C_BAD_9_TP.Multiline = true;
            this.C_BAD_9_TP.Name = "C_BAD_9_TP";
            this.C_BAD_9_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_9_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_9_TP.Text = "";
            this.C_BAD_9_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_9_TP.WordWrap = false;
            // 
            // C_BAD_9_NM
            // 
            this.C_BAD_9_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_9_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_9_NM.BorderWidth = 0.5F;
            this.C_BAD_9_NM.CanGrow = false;
            this.C_BAD_9_NM.Dpi = 100F;
            this.C_BAD_9_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 327F);
            this.C_BAD_9_NM.Multiline = true;
            this.C_BAD_9_NM.Name = "C_BAD_9_NM";
            this.C_BAD_9_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_9_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_9_NM.Text = "";
            this.C_BAD_9_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_9_NM.WordWrap = false;
            // 
            // C_BAD_9_QTY
            // 
            this.C_BAD_9_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_9_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_9_QTY.BorderWidth = 0.5F;
            this.C_BAD_9_QTY.CanGrow = false;
            this.C_BAD_9_QTY.Dpi = 100F;
            this.C_BAD_9_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 327F);
            this.C_BAD_9_QTY.Multiline = true;
            this.C_BAD_9_QTY.Name = "C_BAD_9_QTY";
            this.C_BAD_9_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_9_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_9_QTY.Text = "";
            this.C_BAD_9_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_9_QTY.WordWrap = false;
            // 
            // C_BAD_10_TP
            // 
            this.C_BAD_10_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_10_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_10_TP.BorderWidth = 0.5F;
            this.C_BAD_10_TP.CanGrow = false;
            this.C_BAD_10_TP.Dpi = 100F;
            this.C_BAD_10_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 342F);
            this.C_BAD_10_TP.Multiline = true;
            this.C_BAD_10_TP.Name = "C_BAD_10_TP";
            this.C_BAD_10_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_10_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_10_TP.Text = "";
            this.C_BAD_10_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_10_TP.WordWrap = false;
            // 
            // C_BAD_10_NM
            // 
            this.C_BAD_10_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_10_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_10_NM.BorderWidth = 0.5F;
            this.C_BAD_10_NM.CanGrow = false;
            this.C_BAD_10_NM.Dpi = 100F;
            this.C_BAD_10_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 342F);
            this.C_BAD_10_NM.Multiline = true;
            this.C_BAD_10_NM.Name = "C_BAD_10_NM";
            this.C_BAD_10_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_10_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_10_NM.Text = "";
            this.C_BAD_10_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_10_NM.WordWrap = false;
            // 
            // C_BAD_10_QTY
            // 
            this.C_BAD_10_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_10_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_10_QTY.BorderWidth = 0.5F;
            this.C_BAD_10_QTY.CanGrow = false;
            this.C_BAD_10_QTY.Dpi = 100F;
            this.C_BAD_10_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 342F);
            this.C_BAD_10_QTY.Multiline = true;
            this.C_BAD_10_QTY.Name = "C_BAD_10_QTY";
            this.C_BAD_10_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_10_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_10_QTY.Text = "";
            this.C_BAD_10_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_10_QTY.WordWrap = false;
            // 
            // C_BAD_11_TP
            // 
            this.C_BAD_11_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_11_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_11_TP.BorderWidth = 0.5F;
            this.C_BAD_11_TP.CanGrow = false;
            this.C_BAD_11_TP.Dpi = 100F;
            this.C_BAD_11_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 357F);
            this.C_BAD_11_TP.Multiline = true;
            this.C_BAD_11_TP.Name = "C_BAD_11_TP";
            this.C_BAD_11_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_11_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_11_TP.Text = "";
            this.C_BAD_11_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_11_TP.WordWrap = false;
            // 
            // C_BAD_11_NM
            // 
            this.C_BAD_11_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_11_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_11_NM.BorderWidth = 0.5F;
            this.C_BAD_11_NM.CanGrow = false;
            this.C_BAD_11_NM.Dpi = 100F;
            this.C_BAD_11_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 357F);
            this.C_BAD_11_NM.Multiline = true;
            this.C_BAD_11_NM.Name = "C_BAD_11_NM";
            this.C_BAD_11_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_11_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_11_NM.Text = "";
            this.C_BAD_11_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_11_NM.WordWrap = false;
            // 
            // C_BAD_11_QTY
            // 
            this.C_BAD_11_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_11_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_11_QTY.BorderWidth = 0.5F;
            this.C_BAD_11_QTY.CanGrow = false;
            this.C_BAD_11_QTY.Dpi = 100F;
            this.C_BAD_11_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 357F);
            this.C_BAD_11_QTY.Multiline = true;
            this.C_BAD_11_QTY.Name = "C_BAD_11_QTY";
            this.C_BAD_11_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_11_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_11_QTY.Text = "";
            this.C_BAD_11_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_11_QTY.WordWrap = false;
            // 
            // C_BAD_12_TP
            // 
            this.C_BAD_12_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_12_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_12_TP.BorderWidth = 0.5F;
            this.C_BAD_12_TP.CanGrow = false;
            this.C_BAD_12_TP.Dpi = 100F;
            this.C_BAD_12_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 372F);
            this.C_BAD_12_TP.Multiline = true;
            this.C_BAD_12_TP.Name = "C_BAD_12_TP";
            this.C_BAD_12_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_12_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_12_TP.Text = "";
            this.C_BAD_12_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_12_TP.WordWrap = false;
            // 
            // C_BAD_12_NM
            // 
            this.C_BAD_12_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_12_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_12_NM.BorderWidth = 0.5F;
            this.C_BAD_12_NM.CanGrow = false;
            this.C_BAD_12_NM.Dpi = 100F;
            this.C_BAD_12_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 372F);
            this.C_BAD_12_NM.Multiline = true;
            this.C_BAD_12_NM.Name = "C_BAD_12_NM";
            this.C_BAD_12_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_12_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_12_NM.Text = "";
            this.C_BAD_12_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_12_NM.WordWrap = false;
            // 
            // C_BAD_12_QTY
            // 
            this.C_BAD_12_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_12_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_12_QTY.BorderWidth = 0.5F;
            this.C_BAD_12_QTY.CanGrow = false;
            this.C_BAD_12_QTY.Dpi = 100F;
            this.C_BAD_12_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 372F);
            this.C_BAD_12_QTY.Multiline = true;
            this.C_BAD_12_QTY.Name = "C_BAD_12_QTY";
            this.C_BAD_12_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_12_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_12_QTY.Text = "";
            this.C_BAD_12_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_12_QTY.WordWrap = false;
            // 
            // C_BAD_13_TP
            // 
            this.C_BAD_13_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_13_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_13_TP.BorderWidth = 0.5F;
            this.C_BAD_13_TP.CanGrow = false;
            this.C_BAD_13_TP.Dpi = 100F;
            this.C_BAD_13_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 387F);
            this.C_BAD_13_TP.Multiline = true;
            this.C_BAD_13_TP.Name = "C_BAD_13_TP";
            this.C_BAD_13_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_13_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_13_TP.Text = "";
            this.C_BAD_13_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_13_TP.WordWrap = false;
            // 
            // C_BAD_13_NM
            // 
            this.C_BAD_13_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_13_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_13_NM.BorderWidth = 0.5F;
            this.C_BAD_13_NM.CanGrow = false;
            this.C_BAD_13_NM.Dpi = 100F;
            this.C_BAD_13_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 387F);
            this.C_BAD_13_NM.Multiline = true;
            this.C_BAD_13_NM.Name = "C_BAD_13_NM";
            this.C_BAD_13_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_13_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_13_NM.Text = "";
            this.C_BAD_13_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_13_NM.WordWrap = false;
            // 
            // C_BAD_13_QTY
            // 
            this.C_BAD_13_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_13_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_13_QTY.BorderWidth = 0.5F;
            this.C_BAD_13_QTY.CanGrow = false;
            this.C_BAD_13_QTY.Dpi = 100F;
            this.C_BAD_13_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 387F);
            this.C_BAD_13_QTY.Multiline = true;
            this.C_BAD_13_QTY.Name = "C_BAD_13_QTY";
            this.C_BAD_13_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_13_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_13_QTY.Text = "";
            this.C_BAD_13_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_13_QTY.WordWrap = false;
            // 
            // C_BAD_14_TP
            // 
            this.C_BAD_14_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_14_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_14_TP.BorderWidth = 0.5F;
            this.C_BAD_14_TP.CanGrow = false;
            this.C_BAD_14_TP.Dpi = 100F;
            this.C_BAD_14_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 402F);
            this.C_BAD_14_TP.Multiline = true;
            this.C_BAD_14_TP.Name = "C_BAD_14_TP";
            this.C_BAD_14_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_14_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_14_TP.Text = "";
            this.C_BAD_14_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_14_TP.WordWrap = false;
            // 
            // C_BAD_14_NM
            // 
            this.C_BAD_14_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_14_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_14_NM.BorderWidth = 0.5F;
            this.C_BAD_14_NM.CanGrow = false;
            this.C_BAD_14_NM.Dpi = 100F;
            this.C_BAD_14_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 402F);
            this.C_BAD_14_NM.Multiline = true;
            this.C_BAD_14_NM.Name = "C_BAD_14_NM";
            this.C_BAD_14_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_14_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_14_NM.Text = "";
            this.C_BAD_14_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_14_NM.WordWrap = false;
            // 
            // C_BAD_14_QTY
            // 
            this.C_BAD_14_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_14_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_14_QTY.BorderWidth = 0.5F;
            this.C_BAD_14_QTY.CanGrow = false;
            this.C_BAD_14_QTY.Dpi = 100F;
            this.C_BAD_14_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 402F);
            this.C_BAD_14_QTY.Multiline = true;
            this.C_BAD_14_QTY.Name = "C_BAD_14_QTY";
            this.C_BAD_14_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_14_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_14_QTY.Text = "";
            this.C_BAD_14_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_14_QTY.WordWrap = false;
            // 
            // C_BAD_15_TP
            // 
            this.C_BAD_15_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_15_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_15_TP.BorderWidth = 0.5F;
            this.C_BAD_15_TP.CanGrow = false;
            this.C_BAD_15_TP.Dpi = 100F;
            this.C_BAD_15_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 417F);
            this.C_BAD_15_TP.Multiline = true;
            this.C_BAD_15_TP.Name = "C_BAD_15_TP";
            this.C_BAD_15_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_15_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_15_TP.Text = "";
            this.C_BAD_15_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_15_TP.WordWrap = false;
            // 
            // C_BAD_15_NM
            // 
            this.C_BAD_15_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_15_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_15_NM.BorderWidth = 0.5F;
            this.C_BAD_15_NM.CanGrow = false;
            this.C_BAD_15_NM.Dpi = 100F;
            this.C_BAD_15_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 417F);
            this.C_BAD_15_NM.Multiline = true;
            this.C_BAD_15_NM.Name = "C_BAD_15_NM";
            this.C_BAD_15_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_15_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_15_NM.Text = "";
            this.C_BAD_15_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_15_NM.WordWrap = false;
            // 
            // C_BAD_15_QTY
            // 
            this.C_BAD_15_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_15_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_15_QTY.BorderWidth = 0.5F;
            this.C_BAD_15_QTY.CanGrow = false;
            this.C_BAD_15_QTY.Dpi = 100F;
            this.C_BAD_15_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 417F);
            this.C_BAD_15_QTY.Multiline = true;
            this.C_BAD_15_QTY.Name = "C_BAD_15_QTY";
            this.C_BAD_15_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_15_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_15_QTY.Text = "";
            this.C_BAD_15_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_15_QTY.WordWrap = false;
            // 
            // C_BAD_16_TP
            // 
            this.C_BAD_16_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_16_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_16_TP.BorderWidth = 0.5F;
            this.C_BAD_16_TP.CanGrow = false;
            this.C_BAD_16_TP.Dpi = 100F;
            this.C_BAD_16_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 432F);
            this.C_BAD_16_TP.Multiline = true;
            this.C_BAD_16_TP.Name = "C_BAD_16_TP";
            this.C_BAD_16_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_16_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_16_TP.Text = "";
            this.C_BAD_16_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_16_TP.WordWrap = false;
            // 
            // C_BAD_16_NM
            // 
            this.C_BAD_16_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_16_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_16_NM.BorderWidth = 0.5F;
            this.C_BAD_16_NM.CanGrow = false;
            this.C_BAD_16_NM.Dpi = 100F;
            this.C_BAD_16_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 432F);
            this.C_BAD_16_NM.Multiline = true;
            this.C_BAD_16_NM.Name = "C_BAD_16_NM";
            this.C_BAD_16_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_16_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_16_NM.Text = "";
            this.C_BAD_16_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_16_NM.WordWrap = false;
            // 
            // C_BAD_16_QTY
            // 
            this.C_BAD_16_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_16_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_16_QTY.BorderWidth = 0.5F;
            this.C_BAD_16_QTY.CanGrow = false;
            this.C_BAD_16_QTY.Dpi = 100F;
            this.C_BAD_16_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 432F);
            this.C_BAD_16_QTY.Multiline = true;
            this.C_BAD_16_QTY.Name = "C_BAD_16_QTY";
            this.C_BAD_16_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_16_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_16_QTY.Text = "";
            this.C_BAD_16_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_16_QTY.WordWrap = false;
            // 
            // C_BAD_17_TP
            // 
            this.C_BAD_17_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_17_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_17_TP.BorderWidth = 0.5F;
            this.C_BAD_17_TP.CanGrow = false;
            this.C_BAD_17_TP.Dpi = 100F;
            this.C_BAD_17_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 447F);
            this.C_BAD_17_TP.Multiline = true;
            this.C_BAD_17_TP.Name = "C_BAD_17_TP";
            this.C_BAD_17_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_17_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_17_TP.Text = "";
            this.C_BAD_17_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_17_TP.WordWrap = false;
            // 
            // C_BAD_17_NM
            // 
            this.C_BAD_17_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_17_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_17_NM.BorderWidth = 0.5F;
            this.C_BAD_17_NM.CanGrow = false;
            this.C_BAD_17_NM.Dpi = 100F;
            this.C_BAD_17_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 447F);
            this.C_BAD_17_NM.Multiline = true;
            this.C_BAD_17_NM.Name = "C_BAD_17_NM";
            this.C_BAD_17_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_17_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_17_NM.Text = "";
            this.C_BAD_17_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_17_NM.WordWrap = false;
            // 
            // C_BAD_17_QTY
            // 
            this.C_BAD_17_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_17_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_17_QTY.BorderWidth = 0.5F;
            this.C_BAD_17_QTY.CanGrow = false;
            this.C_BAD_17_QTY.Dpi = 100F;
            this.C_BAD_17_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 447F);
            this.C_BAD_17_QTY.Multiline = true;
            this.C_BAD_17_QTY.Name = "C_BAD_17_QTY";
            this.C_BAD_17_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_17_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_17_QTY.Text = "";
            this.C_BAD_17_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_17_QTY.WordWrap = false;
            // 
            // C_BAD_18_TP
            // 
            this.C_BAD_18_TP.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_18_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_18_TP.BorderWidth = 0.5F;
            this.C_BAD_18_TP.CanGrow = false;
            this.C_BAD_18_TP.Dpi = 100F;
            this.C_BAD_18_TP.LocationFloat = new DevExpress.Utils.PointFloat(911F, 462F);
            this.C_BAD_18_TP.Multiline = true;
            this.C_BAD_18_TP.Name = "C_BAD_18_TP";
            this.C_BAD_18_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_18_TP.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.C_BAD_18_TP.Text = "";
            this.C_BAD_18_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_18_TP.WordWrap = false;
            // 
            // C_BAD_18_NM
            // 
            this.C_BAD_18_NM.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_18_NM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_18_NM.BorderWidth = 0.5F;
            this.C_BAD_18_NM.CanGrow = false;
            this.C_BAD_18_NM.Dpi = 100F;
            this.C_BAD_18_NM.LocationFloat = new DevExpress.Utils.PointFloat(981F, 462F);
            this.C_BAD_18_NM.Multiline = true;
            this.C_BAD_18_NM.Name = "C_BAD_18_NM";
            this.C_BAD_18_NM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_18_NM.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.C_BAD_18_NM.Text = "";
            this.C_BAD_18_NM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_BAD_18_NM.WordWrap = false;
            // 
            // C_BAD_18_QTY
            // 
            this.C_BAD_18_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_18_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_18_QTY.BorderWidth = 0.5F;
            this.C_BAD_18_QTY.CanGrow = false;
            this.C_BAD_18_QTY.Dpi = 100F;
            this.C_BAD_18_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 462F);
            this.C_BAD_18_QTY.Multiline = true;
            this.C_BAD_18_QTY.Name = "C_BAD_18_QTY";
            this.C_BAD_18_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_18_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_18_QTY.Text = "";
            this.C_BAD_18_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_18_QTY.WordWrap = false;
            // 
            // L_BAD_SUM
            // 
            this.L_BAD_SUM.BorderColor = System.Drawing.Color.Gray;
            this.L_BAD_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_BAD_SUM.BorderWidth = 0.5F;
            this.L_BAD_SUM.CanGrow = false;
            this.L_BAD_SUM.Dpi = 100F;
            this.L_BAD_SUM.LocationFloat = new DevExpress.Utils.PointFloat(911F, 477F);
            this.L_BAD_SUM.Multiline = true;
            this.L_BAD_SUM.Name = "L_BAD_SUM";
            this.L_BAD_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_BAD_SUM.SizeF = new System.Drawing.SizeF(160F, 15F);
            this.L_BAD_SUM.Text = "합계";
            this.L_BAD_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_BAD_SUM.WordWrap = false;
            // 
            // C_BAD_SUM_QTY
            // 
            this.C_BAD_SUM_QTY.BorderColor = System.Drawing.Color.Gray;
            this.C_BAD_SUM_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_BAD_SUM_QTY.BorderWidth = 0.5F;
            this.C_BAD_SUM_QTY.CanGrow = false;
            this.C_BAD_SUM_QTY.Dpi = 100F;
            this.C_BAD_SUM_QTY.LocationFloat = new DevExpress.Utils.PointFloat(1071F, 477F);
            this.C_BAD_SUM_QTY.Multiline = true;
            this.C_BAD_SUM_QTY.Name = "C_BAD_SUM_QTY";
            this.C_BAD_SUM_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_BAD_SUM_QTY.SizeF = new System.Drawing.SizeF(58F, 15F);
            this.C_BAD_SUM_QTY.Text = "";
            this.C_BAD_SUM_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_BAD_SUM_QTY.WordWrap = false;
            // 
            // L_ISSUE_H_TP
            // 
            this.L_ISSUE_H_TP.BorderColor = System.Drawing.Color.Gray;
            this.L_ISSUE_H_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ISSUE_H_TP.BorderWidth = 0.5F;
            this.L_ISSUE_H_TP.CanGrow = false;
            this.L_ISSUE_H_TP.Dpi = 100F;
            this.L_ISSUE_H_TP.LocationFloat = new DevExpress.Utils.PointFloat(0F, 505F);
            this.L_ISSUE_H_TP.Multiline = true;
            this.L_ISSUE_H_TP.Name = "L_ISSUE_H_TP";
            this.L_ISSUE_H_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_ISSUE_H_TP.SizeF = new System.Drawing.SizeF(60F, 16F);
            this.L_ISSUE_H_TP.Text = "구분";
            this.L_ISSUE_H_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ISSUE_H_TP.WordWrap = false;
            // 
            // L_ISSUE_H
            // 
            this.L_ISSUE_H.BorderColor = System.Drawing.Color.Gray;
            this.L_ISSUE_H.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ISSUE_H.BorderWidth = 0.5F;
            this.L_ISSUE_H.CanGrow = false;
            this.L_ISSUE_H.Dpi = 100F;
            this.L_ISSUE_H.LocationFloat = new DevExpress.Utils.PointFloat(60F, 505F);
            this.L_ISSUE_H.Multiline = true;
            this.L_ISSUE_H.Name = "L_ISSUE_H";
            this.L_ISSUE_H.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_ISSUE_H.SizeF = new System.Drawing.SizeF(836F, 16F);
            this.L_ISSUE_H.Text = "ISSUE 사항";
            this.L_ISSUE_H.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ISSUE_H.WordWrap = false;
            // 
            // L_DAYISSUE
            // 
            this.L_DAYISSUE.BorderColor = System.Drawing.Color.Gray;
            this.L_DAYISSUE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAYISSUE.BorderWidth = 0.5F;
            this.L_DAYISSUE.CanGrow = false;
            this.L_DAYISSUE.Dpi = 100F;
            this.L_DAYISSUE.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_DAYISSUE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 521F);
            this.L_DAYISSUE.Multiline = true;
            this.L_DAYISSUE.Name = "L_DAYISSUE";
            this.L_DAYISSUE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_DAYISSUE.SizeF = new System.Drawing.SizeF(60F, 100F);
            this.L_DAYISSUE.Text = "주간";
            this.L_DAYISSUE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAYISSUE.WordWrap = false;
            // 
            // C_DAYISSUE
            // 
            this.C_DAYISSUE.BorderColor = System.Drawing.Color.Gray;
            this.C_DAYISSUE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAYISSUE.BorderWidth = 0.5F;
            this.C_DAYISSUE.CanGrow = false;
            this.C_DAYISSUE.Dpi = 100F;
            this.C_DAYISSUE.LocationFloat = new DevExpress.Utils.PointFloat(60F, 521F);
            this.C_DAYISSUE.Multiline = true;
            this.C_DAYISSUE.Name = "C_DAYISSUE";
            this.C_DAYISSUE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 0, 100F);
            this.C_DAYISSUE.SizeF = new System.Drawing.SizeF(836F, 100F);
            this.C_DAYISSUE.Text = "";
            this.C_DAYISSUE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // L_NIGHTISSUE
            // 
            this.L_NIGHTISSUE.BorderColor = System.Drawing.Color.Gray;
            this.L_NIGHTISSUE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHTISSUE.BorderWidth = 0.5F;
            this.L_NIGHTISSUE.CanGrow = false;
            this.L_NIGHTISSUE.Dpi = 100F;
            this.L_NIGHTISSUE.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_NIGHTISSUE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 621F);
            this.L_NIGHTISSUE.Multiline = true;
            this.L_NIGHTISSUE.Name = "L_NIGHTISSUE";
            this.L_NIGHTISSUE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_NIGHTISSUE.SizeF = new System.Drawing.SizeF(60F, 100F);
            this.L_NIGHTISSUE.Text = "야간";
            this.L_NIGHTISSUE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHTISSUE.WordWrap = false;
            // 
            // C_NIGHTISSUE
            // 
            this.C_NIGHTISSUE.BorderColor = System.Drawing.Color.Gray;
            this.C_NIGHTISSUE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHTISSUE.BorderWidth = 0.5F;
            this.C_NIGHTISSUE.CanGrow = false;
            this.C_NIGHTISSUE.Dpi = 100F;
            this.C_NIGHTISSUE.LocationFloat = new DevExpress.Utils.PointFloat(60F, 621F);
            this.C_NIGHTISSUE.Multiline = true;
            this.C_NIGHTISSUE.Name = "C_NIGHTISSUE";
            this.C_NIGHTISSUE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 0, 100F);
            this.C_NIGHTISSUE.SizeF = new System.Drawing.SizeF(836F, 100F);
            this.C_NIGHTISSUE.Text = "";
            this.C_NIGHTISSUE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // S01
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.Detail});
            this.Dpi = 100F;
            this.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPictureBox picLogo;
        private DevExpress.XtraReports.UI.XRLabel L_TITLE_BOX;
        private DevExpress.XtraReports.UI.XRLabel L_TITLE;
        private DevExpress.XtraReports.UI.XRLabel L_PRDDATE;
        private DevExpress.XtraReports.UI.XRLabel C_PRDDATE;
        private DevExpress.XtraReports.UI.XRLabel L_WORKTIME;
        private DevExpress.XtraReports.UI.XRLabel L_DAYTIME;
        private DevExpress.XtraReports.UI.XRLabel C_DAYTIME;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHTTIME;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHTTIME;
        private DevExpress.XtraReports.UI.XRLabel L_EMP;
        private DevExpress.XtraReports.UI.XRLabel L_DAYEMP;
        private DevExpress.XtraReports.UI.XRLabel C_DAYEMP;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHTEMP;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHTEMP;
        private DevExpress.XtraReports.UI.XRLabel L_EQMNM;
        private DevExpress.XtraReports.UI.XRLabel C_EQMNM;
        private DevExpress.XtraReports.UI.XRLabel L_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_ITEMNM_CHK;
        private DevExpress.XtraReports.UI.XRLabel L_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_ITEMCD_CHK;
        private DevExpress.XtraReports.UI.XRLabel L_H_NO;
        private DevExpress.XtraReports.UI.XRLabel L_H_IN;
        private DevExpress.XtraReports.UI.XRLabel L_H_OUT;
        private DevExpress.XtraReports.UI.XRLabel L_H_QTY;
        private DevExpress.XtraReports.UI.XRLabel L_H_GOOD;
        private DevExpress.XtraReports.UI.XRLabel L_H_BAD;
        private DevExpress.XtraReports.UI.XRLabel L_H_SUM;
        private DevExpress.XtraReports.UI.XRLabel L_H_NON1;
        private DevExpress.XtraReports.UI.XRLabel L_H_NON2;
        private DevExpress.XtraReports.UI.XRLabel L_H_N01;
        private DevExpress.XtraReports.UI.XRLabel L_H_N02;
        private DevExpress.XtraReports.UI.XRLabel L_H_N03;
        private DevExpress.XtraReports.UI.XRLabel L_H_N04;
        private DevExpress.XtraReports.UI.XRLabel L_H_N05;
        private DevExpress.XtraReports.UI.XRLabel L_H_N06;
        private DevExpress.XtraReports.UI.XRLabel L_H_N07;
        private DevExpress.XtraReports.UI.XRLabel L_H_N08;
        private DevExpress.XtraReports.UI.XRLabel L_H_N09;
        private DevExpress.XtraReports.UI.XRLabel L_H_N10;
        private DevExpress.XtraReports.UI.XRLabel L_H_N11;
        private DevExpress.XtraReports.UI.XRLabel L_H_N12;
        private DevExpress.XtraReports.UI.XRLabel L_H_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_1_NO;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_IN;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_1_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_2_NO;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_IN;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_2_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_3_NO;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_IN;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_3_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_4_NO;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_IN;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_4_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_5_NO;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_IN;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_5_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_6_NO;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_IN;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_6_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_7_NO;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_IN;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_7_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_8_NO;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_IN;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_8_N13;
        private DevExpress.XtraReports.UI.XRLabel L_DAY_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N01;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N02;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N03;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N04;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N05;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N06;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N07;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N08;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N09;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N10;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N11;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N12;
        private DevExpress.XtraReports.UI.XRLabel C_DAY_SUM_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_1_NO;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_IN;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_1_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_2_NO;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_IN;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_2_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_3_NO;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_IN;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_3_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_4_NO;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_IN;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_4_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_5_NO;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_IN;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_5_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_6_NO;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_IN;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_6_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_7_NO;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_IN;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_7_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_8_NO;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_IN;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_OUT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_8_N13;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N01;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N02;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N03;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N04;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N05;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N06;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N07;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N08;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N09;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N10;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N11;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N12;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHT_SUM_N13;
        private DevExpress.XtraReports.UI.XRLabel L_TOTAL;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_GOOD;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_BAD;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N01;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N02;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N03;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N04;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N05;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N06;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N07;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N08;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N09;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N10;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N11;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N12;
        private DevExpress.XtraReports.UI.XRLabel C_TOTAL_N13;
        private DevExpress.XtraReports.UI.XRLabel L_BAD_TITLE;
        private DevExpress.XtraReports.UI.XRLabel L_BAD_H_TP;
        private DevExpress.XtraReports.UI.XRLabel L_BAD_H_NM;
        private DevExpress.XtraReports.UI.XRLabel L_BAD_H_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_1_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_1_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_1_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_2_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_2_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_2_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_3_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_3_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_3_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_4_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_4_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_4_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_5_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_5_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_5_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_6_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_6_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_6_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_7_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_7_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_7_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_8_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_8_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_8_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_9_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_9_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_9_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_10_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_10_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_10_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_11_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_11_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_11_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_12_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_12_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_12_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_13_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_13_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_13_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_14_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_14_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_14_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_15_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_15_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_15_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_16_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_16_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_16_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_17_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_17_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_17_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_18_TP;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_18_NM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_18_QTY;
        private DevExpress.XtraReports.UI.XRLabel L_BAD_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_BAD_SUM_QTY;
        private DevExpress.XtraReports.UI.XRLabel L_ISSUE_H_TP;
        private DevExpress.XtraReports.UI.XRLabel L_ISSUE_H;
        private DevExpress.XtraReports.UI.XRLabel L_DAYISSUE;
        private DevExpress.XtraReports.UI.XRLabel C_DAYISSUE;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHTISSUE;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHTISSUE;
    }
}
