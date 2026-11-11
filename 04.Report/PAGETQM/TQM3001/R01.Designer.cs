namespace XtraRpt
{
    partial class R01
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

        // CLAIM 통보서 양식. 1장 공문서 = ReportHeader, 2장 산출내역서 = ReportFooter (PageBreak BeforeBand).
        // C_ 로 시작하는 칸에 R01.cs 가 이름으로 값을 넣는다. L_ 는 고정 글자이거나 비워 두는 칸(이의제기·확정·제반비용 산출).
        // 공문서 품목 줄: C_P1_{줄}_{ITEMCD|ITEMNM|BADCONT|QTY|AMT}, 산출내역서 품목 줄: C_P2_{줄}_{ITEMCD|ITEMNM|BADCONT|QTY|INPRICE|MFGPRICE|SALEPRICE|ETCAMT|AMT}
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.L_P1_HEADTITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_APP1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SIGN1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_APP2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SIGN2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_APP3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SIGN3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_ZIP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_ADDR = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_TEL = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_TELNO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_EMP = new DevExpress.XtraReports.UI.XRLabel();
            this.C_EMPNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_HOME = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_HOMEURL = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_FAX = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_FAXNO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_DOCDATE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DOCDATE_TXT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_LINE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_DOCNO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DOCNO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_RECVNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_RECVNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_REFNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_REFNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_LINE2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_TEXT1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_TEXT2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_OBJTEXT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_BELOW = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SEC1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_H_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_H_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_H_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_H_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_H_LOSS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_H_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_H_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_1_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_1_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_1_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_1_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_1_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_1_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_2_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_2_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_2_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_2_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_2_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_2_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_3_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_3_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_3_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_3_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_3_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_3_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_4_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_4_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_4_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_4_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_4_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_4_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_5_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_5_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_5_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_5_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_5_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_5_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_6_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_6_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_6_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_6_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_6_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_6_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_7_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_7_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_7_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_7_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_7_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_7_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_8_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_8_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_8_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_8_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_8_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_8_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_9_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_9_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_9_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_9_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_9_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_9_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_10_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_10_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_10_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_10_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_10_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_10_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_11_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_11_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_11_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_11_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_11_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_11_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_12_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_12_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_12_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_12_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_12_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_12_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_13_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_13_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_13_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_13_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_13_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_13_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_14_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_14_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_14_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_14_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_14_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_14_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_15_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_15_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_15_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_15_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_15_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_15_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_16_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_16_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_16_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_16_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_16_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_16_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_17_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_17_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_17_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_17_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_17_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_17_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_SUM_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P1_SUM_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SEC2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_OBJ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_H_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_1_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_1_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_1_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_1_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_1_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_1_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_1_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_2_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_2_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_2_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_2_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_2_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_2_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_2_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_3_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_3_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_3_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_3_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_3_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_3_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_3_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_4_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_4_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_4_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_4_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_4_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_4_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_4_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_5_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_5_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_5_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_5_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_5_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_5_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_5_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_6_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_6_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_6_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_6_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_6_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_6_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_6_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_7_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_7_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_7_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_7_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_7_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_7_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_7_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_8_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_8_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_8_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_8_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_8_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_8_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_8_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_9_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_9_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_9_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_9_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_9_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_9_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_9_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_SUM_OBJQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_SUM_OBJAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_SUM_CONFQTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_O_SUM_CONFAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SEC3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SEC4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P1_SENDER = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_TOP1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_FROM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_TOP2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_RECVNM_P2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_TOP3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_PERIOD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_PLANDATE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_CONFDATE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_CUST = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_CUSTSIGN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_APP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_APP1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_SIGN1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_APP2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_SIGN2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_APP3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_SIGN3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_LOSS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_OBJ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_CLAIM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_H_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_1_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_1_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_1_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_1_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_1_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_1_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_2_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_2_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_2_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_2_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_2_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_2_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_3_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_3_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_3_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_3_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_3_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_3_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_4_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_4_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_4_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_4_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_4_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_4_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_5_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_5_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_5_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_5_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_5_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_5_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_6_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_6_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_6_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_6_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_6_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_6_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_7_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_7_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_7_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_7_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_7_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_7_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_8_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_8_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_8_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_8_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_8_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_8_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_9_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_9_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_9_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_9_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_9_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_9_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_10_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_10_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_10_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_10_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_10_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_10_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_11_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_11_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_11_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_11_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_11_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_11_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_12_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_12_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_12_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_12_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_12_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_12_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_13_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_13_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_13_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_13_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_13_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_13_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_14_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_14_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_14_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_14_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_14_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_14_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_15_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_15_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_15_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_15_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_15_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_15_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_16_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_16_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_16_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_16_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_16_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_16_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_17_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_BADCONT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_INPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_MFGPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_SALEPRICE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_ETCAMT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_17_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_17_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_17_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_17_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_17_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_SUM_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_P2_SUM_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_SUM_OBJREQ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_SUM_OBJOK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_SUM_PLAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_SUM_CONF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_H_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_H_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_H_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_H_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_H_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_H_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_1_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_1_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_1_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_1_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_1_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_1_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_2_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_2_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_2_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_2_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_2_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_3_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_3_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_3_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_3_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_3_RATE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_4_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_4_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_4_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_4_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_4_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_5_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_5_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_5_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_5_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_5_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_6_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_6_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_6_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_6_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_6_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_7_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_7_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_7_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_7_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_7_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_8_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_8_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_8_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_8_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_8_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_9_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_9_TP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_9_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_9_BASIS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_9_AMT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_SUM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_C_SUMV = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_R_H = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_R_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_R_1V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_R_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_R_2V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_R_3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_P2_R_3V = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 25F;
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
            this.L_P1_HEADTITLE,
            this.L_P1_APP1,
            this.L_P1_SIGN1,
            this.L_P1_APP2,
            this.L_P1_SIGN2,
            this.L_P1_APP3,
            this.L_P1_SIGN3,
            this.L_P1_ZIP,
            this.L_P1_ADDR,
            this.L_P1_TEL,
            this.L_P1_TELNO,
            this.L_P1_EMP,
            this.C_EMPNM,
            this.L_P1_HOME,
            this.L_P1_HOMEURL,
            this.L_P1_FAX,
            this.L_P1_FAXNO,
            this.L_P1_DOCDATE,
            this.C_DOCDATE_TXT,
            this.L_P1_LINE1,
            this.L_P1_DOCNO,
            this.C_DOCNO,
            this.L_P1_RECVNM,
            this.C_RECVNM,
            this.L_P1_REFNM,
            this.C_REFNM,
            this.L_P1_TITLE,
            this.C_TITLE,
            this.L_P1_LINE2,
            this.L_P1_TEXT1,
            this.L_P1_TEXT2,
            this.C_OBJTEXT,
            this.L_P1_BELOW,
            this.L_P1_SEC1,
            this.L_P1_H_NO,
            this.L_P1_H_ITEMCD,
            this.L_P1_H_ITEMNM,
            this.L_P1_H_BADCONT,
            this.L_P1_H_LOSS,
            this.L_P1_H_QTY,
            this.L_P1_H_AMT,
            this.L_P1_1_NO,
            this.C_P1_1_ITEMCD,
            this.C_P1_1_ITEMNM,
            this.C_P1_1_BADCONT,
            this.C_P1_1_QTY,
            this.C_P1_1_AMT,
            this.L_P1_2_NO,
            this.C_P1_2_ITEMCD,
            this.C_P1_2_ITEMNM,
            this.C_P1_2_BADCONT,
            this.C_P1_2_QTY,
            this.C_P1_2_AMT,
            this.L_P1_3_NO,
            this.C_P1_3_ITEMCD,
            this.C_P1_3_ITEMNM,
            this.C_P1_3_BADCONT,
            this.C_P1_3_QTY,
            this.C_P1_3_AMT,
            this.L_P1_4_NO,
            this.C_P1_4_ITEMCD,
            this.C_P1_4_ITEMNM,
            this.C_P1_4_BADCONT,
            this.C_P1_4_QTY,
            this.C_P1_4_AMT,
            this.L_P1_5_NO,
            this.C_P1_5_ITEMCD,
            this.C_P1_5_ITEMNM,
            this.C_P1_5_BADCONT,
            this.C_P1_5_QTY,
            this.C_P1_5_AMT,
            this.L_P1_6_NO,
            this.C_P1_6_ITEMCD,
            this.C_P1_6_ITEMNM,
            this.C_P1_6_BADCONT,
            this.C_P1_6_QTY,
            this.C_P1_6_AMT,
            this.L_P1_7_NO,
            this.C_P1_7_ITEMCD,
            this.C_P1_7_ITEMNM,
            this.C_P1_7_BADCONT,
            this.C_P1_7_QTY,
            this.C_P1_7_AMT,
            this.L_P1_8_NO,
            this.C_P1_8_ITEMCD,
            this.C_P1_8_ITEMNM,
            this.C_P1_8_BADCONT,
            this.C_P1_8_QTY,
            this.C_P1_8_AMT,
            this.L_P1_9_NO,
            this.C_P1_9_ITEMCD,
            this.C_P1_9_ITEMNM,
            this.C_P1_9_BADCONT,
            this.C_P1_9_QTY,
            this.C_P1_9_AMT,
            this.L_P1_10_NO,
            this.C_P1_10_ITEMCD,
            this.C_P1_10_ITEMNM,
            this.C_P1_10_BADCONT,
            this.C_P1_10_QTY,
            this.C_P1_10_AMT,
            this.L_P1_11_NO,
            this.C_P1_11_ITEMCD,
            this.C_P1_11_ITEMNM,
            this.C_P1_11_BADCONT,
            this.C_P1_11_QTY,
            this.C_P1_11_AMT,
            this.L_P1_12_NO,
            this.C_P1_12_ITEMCD,
            this.C_P1_12_ITEMNM,
            this.C_P1_12_BADCONT,
            this.C_P1_12_QTY,
            this.C_P1_12_AMT,
            this.L_P1_13_NO,
            this.C_P1_13_ITEMCD,
            this.C_P1_13_ITEMNM,
            this.C_P1_13_BADCONT,
            this.C_P1_13_QTY,
            this.C_P1_13_AMT,
            this.L_P1_14_NO,
            this.C_P1_14_ITEMCD,
            this.C_P1_14_ITEMNM,
            this.C_P1_14_BADCONT,
            this.C_P1_14_QTY,
            this.C_P1_14_AMT,
            this.L_P1_15_NO,
            this.C_P1_15_ITEMCD,
            this.C_P1_15_ITEMNM,
            this.C_P1_15_BADCONT,
            this.C_P1_15_QTY,
            this.C_P1_15_AMT,
            this.L_P1_16_NO,
            this.C_P1_16_ITEMCD,
            this.C_P1_16_ITEMNM,
            this.C_P1_16_BADCONT,
            this.C_P1_16_QTY,
            this.C_P1_16_AMT,
            this.L_P1_17_NO,
            this.C_P1_17_ITEMCD,
            this.C_P1_17_ITEMNM,
            this.C_P1_17_BADCONT,
            this.C_P1_17_QTY,
            this.C_P1_17_AMT,
            this.L_P1_SUM,
            this.C_P1_SUM_QTY,
            this.C_P1_SUM_AMT,
            this.L_P1_SEC2,
            this.L_P1_O_H_NO,
            this.L_P1_O_H_ITEMCD,
            this.L_P1_O_H_ITEMNM,
            this.L_P1_O_H_OBJ,
            this.L_P1_O_H_OBJQTY,
            this.L_P1_O_H_OBJAMT,
            this.L_P1_O_H_CONF,
            this.L_P1_O_H_CONFQTY,
            this.L_P1_O_H_CONFAMT,
            this.L_P1_O_1_NO,
            this.L_P1_O_1_ITEMCD,
            this.L_P1_O_1_ITEMNM,
            this.L_P1_O_1_OBJQTY,
            this.L_P1_O_1_OBJAMT,
            this.L_P1_O_1_CONFQTY,
            this.L_P1_O_1_CONFAMT,
            this.L_P1_O_2_NO,
            this.L_P1_O_2_ITEMCD,
            this.L_P1_O_2_ITEMNM,
            this.L_P1_O_2_OBJQTY,
            this.L_P1_O_2_OBJAMT,
            this.L_P1_O_2_CONFQTY,
            this.L_P1_O_2_CONFAMT,
            this.L_P1_O_3_NO,
            this.L_P1_O_3_ITEMCD,
            this.L_P1_O_3_ITEMNM,
            this.L_P1_O_3_OBJQTY,
            this.L_P1_O_3_OBJAMT,
            this.L_P1_O_3_CONFQTY,
            this.L_P1_O_3_CONFAMT,
            this.L_P1_O_4_NO,
            this.L_P1_O_4_ITEMCD,
            this.L_P1_O_4_ITEMNM,
            this.L_P1_O_4_OBJQTY,
            this.L_P1_O_4_OBJAMT,
            this.L_P1_O_4_CONFQTY,
            this.L_P1_O_4_CONFAMT,
            this.L_P1_O_5_NO,
            this.L_P1_O_5_ITEMCD,
            this.L_P1_O_5_ITEMNM,
            this.L_P1_O_5_OBJQTY,
            this.L_P1_O_5_OBJAMT,
            this.L_P1_O_5_CONFQTY,
            this.L_P1_O_5_CONFAMT,
            this.L_P1_O_6_NO,
            this.L_P1_O_6_ITEMCD,
            this.L_P1_O_6_ITEMNM,
            this.L_P1_O_6_OBJQTY,
            this.L_P1_O_6_OBJAMT,
            this.L_P1_O_6_CONFQTY,
            this.L_P1_O_6_CONFAMT,
            this.L_P1_O_7_NO,
            this.L_P1_O_7_ITEMCD,
            this.L_P1_O_7_ITEMNM,
            this.L_P1_O_7_OBJQTY,
            this.L_P1_O_7_OBJAMT,
            this.L_P1_O_7_CONFQTY,
            this.L_P1_O_7_CONFAMT,
            this.L_P1_O_8_NO,
            this.L_P1_O_8_ITEMCD,
            this.L_P1_O_8_ITEMNM,
            this.L_P1_O_8_OBJQTY,
            this.L_P1_O_8_OBJAMT,
            this.L_P1_O_8_CONFQTY,
            this.L_P1_O_8_CONFAMT,
            this.L_P1_O_9_NO,
            this.L_P1_O_9_ITEMCD,
            this.L_P1_O_9_ITEMNM,
            this.L_P1_O_9_OBJQTY,
            this.L_P1_O_9_OBJAMT,
            this.L_P1_O_9_CONFQTY,
            this.L_P1_O_9_CONFAMT,
            this.L_P1_O_SUM,
            this.L_P1_O_SUM_OBJQTY,
            this.L_P1_O_SUM_OBJAMT,
            this.L_P1_O_SUM_CONFQTY,
            this.L_P1_O_SUM_CONFAMT,
            this.L_P1_SEC3,
            this.L_P1_SEC4,
            this.L_P1_SENDER});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 1090F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_P2_TOP1,
            this.L_P2_FROM,
            this.L_P2_TOP2,
            this.C_RECVNM_P2,
            this.L_P2_TOP3,
            this.C_PERIOD,
            this.L_P2_TITLE,
            this.C_PLANDATE,
            this.C_CONFDATE,
            this.L_P2_CUST,
            this.L_P2_CUSTSIGN,
            this.L_P2_APP,
            this.L_P2_APP1,
            this.L_P2_SIGN1,
            this.L_P2_APP2,
            this.L_P2_SIGN2,
            this.L_P2_APP3,
            this.L_P2_SIGN3,
            this.L_P2_H_NO,
            this.L_P2_H_ITEMCD,
            this.L_P2_H_ITEMNM,
            this.L_P2_H_BADCONT,
            this.L_P2_H_QTY,
            this.L_P2_H_LOSS,
            this.L_P2_H_OBJ,
            this.L_P2_H_CLAIM,
            this.L_P2_H_INPRICE,
            this.L_P2_H_MFGPRICE,
            this.L_P2_H_SALEPRICE,
            this.L_P2_H_ETCAMT,
            this.L_P2_H_AMT,
            this.L_P2_H_OBJREQ,
            this.L_P2_H_OBJOK,
            this.L_P2_H_PLAN,
            this.L_P2_H_CONF,
            this.L_P2_1_NO,
            this.C_P2_1_ITEMCD,
            this.C_P2_1_ITEMNM,
            this.C_P2_1_BADCONT,
            this.C_P2_1_QTY,
            this.C_P2_1_INPRICE,
            this.C_P2_1_MFGPRICE,
            this.C_P2_1_SALEPRICE,
            this.C_P2_1_ETCAMT,
            this.C_P2_1_AMT,
            this.L_P2_1_OBJREQ,
            this.L_P2_1_OBJOK,
            this.L_P2_1_PLAN,
            this.L_P2_1_CONF,
            this.L_P2_2_NO,
            this.C_P2_2_ITEMCD,
            this.C_P2_2_ITEMNM,
            this.C_P2_2_BADCONT,
            this.C_P2_2_QTY,
            this.C_P2_2_INPRICE,
            this.C_P2_2_MFGPRICE,
            this.C_P2_2_SALEPRICE,
            this.C_P2_2_ETCAMT,
            this.C_P2_2_AMT,
            this.L_P2_2_OBJREQ,
            this.L_P2_2_OBJOK,
            this.L_P2_2_PLAN,
            this.L_P2_2_CONF,
            this.L_P2_3_NO,
            this.C_P2_3_ITEMCD,
            this.C_P2_3_ITEMNM,
            this.C_P2_3_BADCONT,
            this.C_P2_3_QTY,
            this.C_P2_3_INPRICE,
            this.C_P2_3_MFGPRICE,
            this.C_P2_3_SALEPRICE,
            this.C_P2_3_ETCAMT,
            this.C_P2_3_AMT,
            this.L_P2_3_OBJREQ,
            this.L_P2_3_OBJOK,
            this.L_P2_3_PLAN,
            this.L_P2_3_CONF,
            this.L_P2_4_NO,
            this.C_P2_4_ITEMCD,
            this.C_P2_4_ITEMNM,
            this.C_P2_4_BADCONT,
            this.C_P2_4_QTY,
            this.C_P2_4_INPRICE,
            this.C_P2_4_MFGPRICE,
            this.C_P2_4_SALEPRICE,
            this.C_P2_4_ETCAMT,
            this.C_P2_4_AMT,
            this.L_P2_4_OBJREQ,
            this.L_P2_4_OBJOK,
            this.L_P2_4_PLAN,
            this.L_P2_4_CONF,
            this.L_P2_5_NO,
            this.C_P2_5_ITEMCD,
            this.C_P2_5_ITEMNM,
            this.C_P2_5_BADCONT,
            this.C_P2_5_QTY,
            this.C_P2_5_INPRICE,
            this.C_P2_5_MFGPRICE,
            this.C_P2_5_SALEPRICE,
            this.C_P2_5_ETCAMT,
            this.C_P2_5_AMT,
            this.L_P2_5_OBJREQ,
            this.L_P2_5_OBJOK,
            this.L_P2_5_PLAN,
            this.L_P2_5_CONF,
            this.L_P2_6_NO,
            this.C_P2_6_ITEMCD,
            this.C_P2_6_ITEMNM,
            this.C_P2_6_BADCONT,
            this.C_P2_6_QTY,
            this.C_P2_6_INPRICE,
            this.C_P2_6_MFGPRICE,
            this.C_P2_6_SALEPRICE,
            this.C_P2_6_ETCAMT,
            this.C_P2_6_AMT,
            this.L_P2_6_OBJREQ,
            this.L_P2_6_OBJOK,
            this.L_P2_6_PLAN,
            this.L_P2_6_CONF,
            this.L_P2_7_NO,
            this.C_P2_7_ITEMCD,
            this.C_P2_7_ITEMNM,
            this.C_P2_7_BADCONT,
            this.C_P2_7_QTY,
            this.C_P2_7_INPRICE,
            this.C_P2_7_MFGPRICE,
            this.C_P2_7_SALEPRICE,
            this.C_P2_7_ETCAMT,
            this.C_P2_7_AMT,
            this.L_P2_7_OBJREQ,
            this.L_P2_7_OBJOK,
            this.L_P2_7_PLAN,
            this.L_P2_7_CONF,
            this.L_P2_8_NO,
            this.C_P2_8_ITEMCD,
            this.C_P2_8_ITEMNM,
            this.C_P2_8_BADCONT,
            this.C_P2_8_QTY,
            this.C_P2_8_INPRICE,
            this.C_P2_8_MFGPRICE,
            this.C_P2_8_SALEPRICE,
            this.C_P2_8_ETCAMT,
            this.C_P2_8_AMT,
            this.L_P2_8_OBJREQ,
            this.L_P2_8_OBJOK,
            this.L_P2_8_PLAN,
            this.L_P2_8_CONF,
            this.L_P2_9_NO,
            this.C_P2_9_ITEMCD,
            this.C_P2_9_ITEMNM,
            this.C_P2_9_BADCONT,
            this.C_P2_9_QTY,
            this.C_P2_9_INPRICE,
            this.C_P2_9_MFGPRICE,
            this.C_P2_9_SALEPRICE,
            this.C_P2_9_ETCAMT,
            this.C_P2_9_AMT,
            this.L_P2_9_OBJREQ,
            this.L_P2_9_OBJOK,
            this.L_P2_9_PLAN,
            this.L_P2_9_CONF,
            this.L_P2_10_NO,
            this.C_P2_10_ITEMCD,
            this.C_P2_10_ITEMNM,
            this.C_P2_10_BADCONT,
            this.C_P2_10_QTY,
            this.C_P2_10_INPRICE,
            this.C_P2_10_MFGPRICE,
            this.C_P2_10_SALEPRICE,
            this.C_P2_10_ETCAMT,
            this.C_P2_10_AMT,
            this.L_P2_10_OBJREQ,
            this.L_P2_10_OBJOK,
            this.L_P2_10_PLAN,
            this.L_P2_10_CONF,
            this.L_P2_11_NO,
            this.C_P2_11_ITEMCD,
            this.C_P2_11_ITEMNM,
            this.C_P2_11_BADCONT,
            this.C_P2_11_QTY,
            this.C_P2_11_INPRICE,
            this.C_P2_11_MFGPRICE,
            this.C_P2_11_SALEPRICE,
            this.C_P2_11_ETCAMT,
            this.C_P2_11_AMT,
            this.L_P2_11_OBJREQ,
            this.L_P2_11_OBJOK,
            this.L_P2_11_PLAN,
            this.L_P2_11_CONF,
            this.L_P2_12_NO,
            this.C_P2_12_ITEMCD,
            this.C_P2_12_ITEMNM,
            this.C_P2_12_BADCONT,
            this.C_P2_12_QTY,
            this.C_P2_12_INPRICE,
            this.C_P2_12_MFGPRICE,
            this.C_P2_12_SALEPRICE,
            this.C_P2_12_ETCAMT,
            this.C_P2_12_AMT,
            this.L_P2_12_OBJREQ,
            this.L_P2_12_OBJOK,
            this.L_P2_12_PLAN,
            this.L_P2_12_CONF,
            this.L_P2_13_NO,
            this.C_P2_13_ITEMCD,
            this.C_P2_13_ITEMNM,
            this.C_P2_13_BADCONT,
            this.C_P2_13_QTY,
            this.C_P2_13_INPRICE,
            this.C_P2_13_MFGPRICE,
            this.C_P2_13_SALEPRICE,
            this.C_P2_13_ETCAMT,
            this.C_P2_13_AMT,
            this.L_P2_13_OBJREQ,
            this.L_P2_13_OBJOK,
            this.L_P2_13_PLAN,
            this.L_P2_13_CONF,
            this.L_P2_14_NO,
            this.C_P2_14_ITEMCD,
            this.C_P2_14_ITEMNM,
            this.C_P2_14_BADCONT,
            this.C_P2_14_QTY,
            this.C_P2_14_INPRICE,
            this.C_P2_14_MFGPRICE,
            this.C_P2_14_SALEPRICE,
            this.C_P2_14_ETCAMT,
            this.C_P2_14_AMT,
            this.L_P2_14_OBJREQ,
            this.L_P2_14_OBJOK,
            this.L_P2_14_PLAN,
            this.L_P2_14_CONF,
            this.L_P2_15_NO,
            this.C_P2_15_ITEMCD,
            this.C_P2_15_ITEMNM,
            this.C_P2_15_BADCONT,
            this.C_P2_15_QTY,
            this.C_P2_15_INPRICE,
            this.C_P2_15_MFGPRICE,
            this.C_P2_15_SALEPRICE,
            this.C_P2_15_ETCAMT,
            this.C_P2_15_AMT,
            this.L_P2_15_OBJREQ,
            this.L_P2_15_OBJOK,
            this.L_P2_15_PLAN,
            this.L_P2_15_CONF,
            this.L_P2_16_NO,
            this.C_P2_16_ITEMCD,
            this.C_P2_16_ITEMNM,
            this.C_P2_16_BADCONT,
            this.C_P2_16_QTY,
            this.C_P2_16_INPRICE,
            this.C_P2_16_MFGPRICE,
            this.C_P2_16_SALEPRICE,
            this.C_P2_16_ETCAMT,
            this.C_P2_16_AMT,
            this.L_P2_16_OBJREQ,
            this.L_P2_16_OBJOK,
            this.L_P2_16_PLAN,
            this.L_P2_16_CONF,
            this.L_P2_17_NO,
            this.C_P2_17_ITEMCD,
            this.C_P2_17_ITEMNM,
            this.C_P2_17_BADCONT,
            this.C_P2_17_QTY,
            this.C_P2_17_INPRICE,
            this.C_P2_17_MFGPRICE,
            this.C_P2_17_SALEPRICE,
            this.C_P2_17_ETCAMT,
            this.C_P2_17_AMT,
            this.L_P2_17_OBJREQ,
            this.L_P2_17_OBJOK,
            this.L_P2_17_PLAN,
            this.L_P2_17_CONF,
            this.L_P2_SUM,
            this.C_P2_SUM_QTY,
            this.C_P2_SUM_AMT,
            this.L_P2_SUM_OBJREQ,
            this.L_P2_SUM_OBJOK,
            this.L_P2_SUM_PLAN,
            this.L_P2_SUM_CONF,
            this.L_P2_C_H_NO,
            this.L_P2_C_H_TP,
            this.L_P2_C_H_STD,
            this.L_P2_C_H_BASIS,
            this.L_P2_C_H_AMT,
            this.L_P2_C_H_RATE,
            this.L_P2_C_1_NO,
            this.L_P2_C_1_TP,
            this.L_P2_C_1_STD,
            this.L_P2_C_1_BASIS,
            this.L_P2_C_1_AMT,
            this.L_P2_C_1_RATE,
            this.L_P2_C_2_TP,
            this.L_P2_C_2_STD,
            this.L_P2_C_2_BASIS,
            this.L_P2_C_2_AMT,
            this.L_P2_C_2_RATE,
            this.L_P2_C_3_TP,
            this.L_P2_C_3_STD,
            this.L_P2_C_3_BASIS,
            this.L_P2_C_3_AMT,
            this.L_P2_C_3_RATE,
            this.L_P2_C_4_NO,
            this.L_P2_C_4_TP,
            this.L_P2_C_4_STD,
            this.L_P2_C_4_BASIS,
            this.L_P2_C_4_AMT,
            this.L_P2_C_5_NO,
            this.L_P2_C_5_TP,
            this.L_P2_C_5_STD,
            this.L_P2_C_5_BASIS,
            this.L_P2_C_5_AMT,
            this.L_P2_C_6_NO,
            this.L_P2_C_6_TP,
            this.L_P2_C_6_STD,
            this.L_P2_C_6_BASIS,
            this.L_P2_C_6_AMT,
            this.L_P2_C_7_NO,
            this.L_P2_C_7_TP,
            this.L_P2_C_7_STD,
            this.L_P2_C_7_BASIS,
            this.L_P2_C_7_AMT,
            this.L_P2_C_8_NO,
            this.L_P2_C_8_TP,
            this.L_P2_C_8_STD,
            this.L_P2_C_8_BASIS,
            this.L_P2_C_8_AMT,
            this.L_P2_C_9_NO,
            this.L_P2_C_9_TP,
            this.L_P2_C_9_STD,
            this.L_P2_C_9_BASIS,
            this.L_P2_C_9_AMT,
            this.L_P2_C_SUM,
            this.L_P2_C_SUMV,
            this.L_P2_R_H,
            this.L_P2_R_1,
            this.L_P2_R_1V,
            this.L_P2_R_2,
            this.L_P2_R_2V,
            this.L_P2_R_3,
            this.L_P2_R_3V});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 700F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // L_P1_HEADTITLE
            // 
            this.L_P1_HEADTITLE.CanGrow = false;
            this.L_P1_HEADTITLE.Dpi = 100F;
            this.L_P1_HEADTITLE.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold);
            this.L_P1_HEADTITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.L_P1_HEADTITLE.Multiline = true;
            this.L_P1_HEADTITLE.Name = "L_P1_HEADTITLE";
            this.L_P1_HEADTITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_HEADTITLE.SizeF = new System.Drawing.SizeF(580F, 63F);
            this.L_P1_HEADTITLE.Text = "CLAIM 통보서";
            this.L_P1_HEADTITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_HEADTITLE.WordWrap = false;
            // 
            // L_P1_APP1
            // 
            this.L_P1_APP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_APP1.BorderColor = System.Drawing.Color.Black;
            this.L_P1_APP1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_APP1.BorderWidth = 0.5F;
            this.L_P1_APP1.CanGrow = false;
            this.L_P1_APP1.Dpi = 100F;
            this.L_P1_APP1.LocationFloat = new DevExpress.Utils.PointFloat(602F, 0F);
            this.L_P1_APP1.Multiline = true;
            this.L_P1_APP1.Name = "L_P1_APP1";
            this.L_P1_APP1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_APP1.SizeF = new System.Drawing.SizeF(55F, 18F);
            this.L_P1_APP1.Text = "작 성";
            this.L_P1_APP1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_APP1.WordWrap = false;
            // 
            // L_P1_SIGN1
            // 
            this.L_P1_SIGN1.BorderColor = System.Drawing.Color.Black;
            this.L_P1_SIGN1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_SIGN1.BorderWidth = 0.5F;
            this.L_P1_SIGN1.CanGrow = false;
            this.L_P1_SIGN1.Dpi = 100F;
            this.L_P1_SIGN1.LocationFloat = new DevExpress.Utils.PointFloat(602F, 18F);
            this.L_P1_SIGN1.Multiline = true;
            this.L_P1_SIGN1.Name = "L_P1_SIGN1";
            this.L_P1_SIGN1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SIGN1.SizeF = new System.Drawing.SizeF(55F, 45F);
            this.L_P1_SIGN1.Text = "";
            this.L_P1_SIGN1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_SIGN1.WordWrap = false;
            // 
            // L_P1_APP2
            // 
            this.L_P1_APP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_APP2.BorderColor = System.Drawing.Color.Black;
            this.L_P1_APP2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_APP2.BorderWidth = 0.5F;
            this.L_P1_APP2.CanGrow = false;
            this.L_P1_APP2.Dpi = 100F;
            this.L_P1_APP2.LocationFloat = new DevExpress.Utils.PointFloat(657F, 0F);
            this.L_P1_APP2.Multiline = true;
            this.L_P1_APP2.Name = "L_P1_APP2";
            this.L_P1_APP2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_APP2.SizeF = new System.Drawing.SizeF(55F, 18F);
            this.L_P1_APP2.Text = "검 토";
            this.L_P1_APP2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_APP2.WordWrap = false;
            // 
            // L_P1_SIGN2
            // 
            this.L_P1_SIGN2.BorderColor = System.Drawing.Color.Black;
            this.L_P1_SIGN2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_SIGN2.BorderWidth = 0.5F;
            this.L_P1_SIGN2.CanGrow = false;
            this.L_P1_SIGN2.Dpi = 100F;
            this.L_P1_SIGN2.LocationFloat = new DevExpress.Utils.PointFloat(657F, 18F);
            this.L_P1_SIGN2.Multiline = true;
            this.L_P1_SIGN2.Name = "L_P1_SIGN2";
            this.L_P1_SIGN2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SIGN2.SizeF = new System.Drawing.SizeF(55F, 45F);
            this.L_P1_SIGN2.Text = "";
            this.L_P1_SIGN2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_SIGN2.WordWrap = false;
            // 
            // L_P1_APP3
            // 
            this.L_P1_APP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_APP3.BorderColor = System.Drawing.Color.Black;
            this.L_P1_APP3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_APP3.BorderWidth = 0.5F;
            this.L_P1_APP3.CanGrow = false;
            this.L_P1_APP3.Dpi = 100F;
            this.L_P1_APP3.LocationFloat = new DevExpress.Utils.PointFloat(712F, 0F);
            this.L_P1_APP3.Multiline = true;
            this.L_P1_APP3.Name = "L_P1_APP3";
            this.L_P1_APP3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_APP3.SizeF = new System.Drawing.SizeF(55F, 18F);
            this.L_P1_APP3.Text = "승 인";
            this.L_P1_APP3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_APP3.WordWrap = false;
            // 
            // L_P1_SIGN3
            // 
            this.L_P1_SIGN3.BorderColor = System.Drawing.Color.Black;
            this.L_P1_SIGN3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_SIGN3.BorderWidth = 0.5F;
            this.L_P1_SIGN3.CanGrow = false;
            this.L_P1_SIGN3.Dpi = 100F;
            this.L_P1_SIGN3.LocationFloat = new DevExpress.Utils.PointFloat(712F, 18F);
            this.L_P1_SIGN3.Multiline = true;
            this.L_P1_SIGN3.Name = "L_P1_SIGN3";
            this.L_P1_SIGN3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SIGN3.SizeF = new System.Drawing.SizeF(55F, 45F);
            this.L_P1_SIGN3.Text = "";
            this.L_P1_SIGN3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_SIGN3.WordWrap = false;
            // 
            // L_P1_ZIP
            // 
            this.L_P1_ZIP.CanGrow = false;
            this.L_P1_ZIP.Dpi = 100F;
            this.L_P1_ZIP.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72F);
            this.L_P1_ZIP.Multiline = true;
            this.L_P1_ZIP.Name = "L_P1_ZIP";
            this.L_P1_ZIP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_ZIP.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.L_P1_ZIP.Text = "(33448)";
            this.L_P1_ZIP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_ZIP.WordWrap = false;
            // 
            // L_P1_ADDR
            // 
            this.L_P1_ADDR.CanGrow = false;
            this.L_P1_ADDR.Dpi = 100F;
            this.L_P1_ADDR.LocationFloat = new DevExpress.Utils.PointFloat(60F, 72F);
            this.L_P1_ADDR.Multiline = true;
            this.L_P1_ADDR.Name = "L_P1_ADDR";
            this.L_P1_ADDR.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_ADDR.SizeF = new System.Drawing.SizeF(330F, 18F);
            this.L_P1_ADDR.Text = "충청남도 보령시 주교면 관창공단길 160";
            this.L_P1_ADDR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_ADDR.WordWrap = false;
            // 
            // L_P1_TEL
            // 
            this.L_P1_TEL.CanGrow = false;
            this.L_P1_TEL.Dpi = 100F;
            this.L_P1_TEL.LocationFloat = new DevExpress.Utils.PointFloat(400F, 72F);
            this.L_P1_TEL.Multiline = true;
            this.L_P1_TEL.Name = "L_P1_TEL";
            this.L_P1_TEL.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_TEL.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_TEL.Text = "Tel.";
            this.L_P1_TEL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_TEL.WordWrap = false;
            // 
            // L_P1_TELNO
            // 
            this.L_P1_TELNO.CanGrow = false;
            this.L_P1_TELNO.Dpi = 100F;
            this.L_P1_TELNO.LocationFloat = new DevExpress.Utils.PointFloat(435F, 72F);
            this.L_P1_TELNO.Multiline = true;
            this.L_P1_TELNO.Name = "L_P1_TELNO";
            this.L_P1_TELNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_TELNO.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_TELNO.Text = "041-402-7800";
            this.L_P1_TELNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_TELNO.WordWrap = false;
            // 
            // L_P1_EMP
            // 
            this.L_P1_EMP.CanGrow = false;
            this.L_P1_EMP.Dpi = 100F;
            this.L_P1_EMP.LocationFloat = new DevExpress.Utils.PointFloat(570F, 72F);
            this.L_P1_EMP.Multiline = true;
            this.L_P1_EMP.Name = "L_P1_EMP";
            this.L_P1_EMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_EMP.SizeF = new System.Drawing.SizeF(55F, 18F);
            this.L_P1_EMP.Text = "담 당";
            this.L_P1_EMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_EMP.WordWrap = false;
            // 
            // C_EMPNM
            // 
            this.C_EMPNM.CanGrow = false;
            this.C_EMPNM.Dpi = 100F;
            this.C_EMPNM.LocationFloat = new DevExpress.Utils.PointFloat(625F, 72F);
            this.C_EMPNM.Multiline = true;
            this.C_EMPNM.Name = "C_EMPNM";
            this.C_EMPNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_EMPNM.SizeF = new System.Drawing.SizeF(142F, 18F);
            this.C_EMPNM.Text = "";
            this.C_EMPNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_EMPNM.WordWrap = false;
            // 
            // L_P1_HOME
            // 
            this.L_P1_HOME.CanGrow = false;
            this.L_P1_HOME.Dpi = 100F;
            this.L_P1_HOME.LocationFloat = new DevExpress.Utils.PointFloat(0F, 90F);
            this.L_P1_HOME.Multiline = true;
            this.L_P1_HOME.Name = "L_P1_HOME";
            this.L_P1_HOME.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_HOME.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.L_P1_HOME.Text = "홈페이지";
            this.L_P1_HOME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_HOME.WordWrap = false;
            // 
            // L_P1_HOMEURL
            // 
            this.L_P1_HOMEURL.CanGrow = false;
            this.L_P1_HOMEURL.Dpi = 100F;
            this.L_P1_HOMEURL.LocationFloat = new DevExpress.Utils.PointFloat(60F, 90F);
            this.L_P1_HOMEURL.Multiline = true;
            this.L_P1_HOMEURL.Name = "L_P1_HOMEURL";
            this.L_P1_HOMEURL.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_HOMEURL.SizeF = new System.Drawing.SizeF(330F, 18F);
            this.L_P1_HOMEURL.Text = "www.snsinc.co.kr";
            this.L_P1_HOMEURL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_HOMEURL.WordWrap = false;
            // 
            // L_P1_FAX
            // 
            this.L_P1_FAX.CanGrow = false;
            this.L_P1_FAX.Dpi = 100F;
            this.L_P1_FAX.LocationFloat = new DevExpress.Utils.PointFloat(400F, 90F);
            this.L_P1_FAX.Multiline = true;
            this.L_P1_FAX.Name = "L_P1_FAX";
            this.L_P1_FAX.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_FAX.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_FAX.Text = "Fax.";
            this.L_P1_FAX.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_FAX.WordWrap = false;
            // 
            // L_P1_FAXNO
            // 
            this.L_P1_FAXNO.CanGrow = false;
            this.L_P1_FAXNO.Dpi = 100F;
            this.L_P1_FAXNO.LocationFloat = new DevExpress.Utils.PointFloat(435F, 90F);
            this.L_P1_FAXNO.Multiline = true;
            this.L_P1_FAXNO.Name = "L_P1_FAXNO";
            this.L_P1_FAXNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_FAXNO.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_FAXNO.Text = "041-402-7805";
            this.L_P1_FAXNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_FAXNO.WordWrap = false;
            // 
            // L_P1_DOCDATE
            // 
            this.L_P1_DOCDATE.CanGrow = false;
            this.L_P1_DOCDATE.Dpi = 100F;
            this.L_P1_DOCDATE.LocationFloat = new DevExpress.Utils.PointFloat(570F, 90F);
            this.L_P1_DOCDATE.Multiline = true;
            this.L_P1_DOCDATE.Name = "L_P1_DOCDATE";
            this.L_P1_DOCDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_DOCDATE.SizeF = new System.Drawing.SizeF(55F, 18F);
            this.L_P1_DOCDATE.Text = "작성일";
            this.L_P1_DOCDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_DOCDATE.WordWrap = false;
            // 
            // C_DOCDATE_TXT
            // 
            this.C_DOCDATE_TXT.CanGrow = false;
            this.C_DOCDATE_TXT.Dpi = 100F;
            this.C_DOCDATE_TXT.LocationFloat = new DevExpress.Utils.PointFloat(625F, 90F);
            this.C_DOCDATE_TXT.Multiline = true;
            this.C_DOCDATE_TXT.Name = "C_DOCDATE_TXT";
            this.C_DOCDATE_TXT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DOCDATE_TXT.SizeF = new System.Drawing.SizeF(142F, 18F);
            this.C_DOCDATE_TXT.Text = "";
            this.C_DOCDATE_TXT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_DOCDATE_TXT.WordWrap = false;
            // 
            // L_P1_LINE1
            // 
            this.L_P1_LINE1.BorderColor = System.Drawing.Color.Black;
            this.L_P1_LINE1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.L_P1_LINE1.BorderWidth = 1F;
            this.L_P1_LINE1.CanGrow = false;
            this.L_P1_LINE1.Dpi = 100F;
            this.L_P1_LINE1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 108F);
            this.L_P1_LINE1.Multiline = true;
            this.L_P1_LINE1.Name = "L_P1_LINE1";
            this.L_P1_LINE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_LINE1.SizeF = new System.Drawing.SizeF(767F, 4F);
            this.L_P1_LINE1.Text = "";
            this.L_P1_LINE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_LINE1.WordWrap = false;
            // 
            // L_P1_DOCNO
            // 
            this.L_P1_DOCNO.CanGrow = false;
            this.L_P1_DOCNO.Dpi = 100F;
            this.L_P1_DOCNO.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.L_P1_DOCNO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 118F);
            this.L_P1_DOCNO.Multiline = true;
            this.L_P1_DOCNO.Name = "L_P1_DOCNO";
            this.L_P1_DOCNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_DOCNO.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.L_P1_DOCNO.Text = "문서번호";
            this.L_P1_DOCNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_DOCNO.WordWrap = false;
            // 
            // C_DOCNO
            // 
            this.C_DOCNO.CanGrow = false;
            this.C_DOCNO.Dpi = 100F;
            this.C_DOCNO.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_DOCNO.LocationFloat = new DevExpress.Utils.PointFloat(90F, 118F);
            this.C_DOCNO.Multiline = true;
            this.C_DOCNO.Name = "C_DOCNO";
            this.C_DOCNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_DOCNO.SizeF = new System.Drawing.SizeF(677F, 22F);
            this.C_DOCNO.Text = "";
            this.C_DOCNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_DOCNO.WordWrap = false;
            // 
            // L_P1_RECVNM
            // 
            this.L_P1_RECVNM.CanGrow = false;
            this.L_P1_RECVNM.Dpi = 100F;
            this.L_P1_RECVNM.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.L_P1_RECVNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 140F);
            this.L_P1_RECVNM.Multiline = true;
            this.L_P1_RECVNM.Name = "L_P1_RECVNM";
            this.L_P1_RECVNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_RECVNM.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.L_P1_RECVNM.Text = "수     신";
            this.L_P1_RECVNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_RECVNM.WordWrap = false;
            // 
            // C_RECVNM
            // 
            this.C_RECVNM.CanGrow = false;
            this.C_RECVNM.Dpi = 100F;
            this.C_RECVNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_RECVNM.LocationFloat = new DevExpress.Utils.PointFloat(90F, 140F);
            this.C_RECVNM.Multiline = true;
            this.C_RECVNM.Name = "C_RECVNM";
            this.C_RECVNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_RECVNM.SizeF = new System.Drawing.SizeF(677F, 22F);
            this.C_RECVNM.Text = "";
            this.C_RECVNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_RECVNM.WordWrap = false;
            // 
            // L_P1_REFNM
            // 
            this.L_P1_REFNM.CanGrow = false;
            this.L_P1_REFNM.Dpi = 100F;
            this.L_P1_REFNM.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.L_P1_REFNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 162F);
            this.L_P1_REFNM.Multiline = true;
            this.L_P1_REFNM.Name = "L_P1_REFNM";
            this.L_P1_REFNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_REFNM.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.L_P1_REFNM.Text = "참     조";
            this.L_P1_REFNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_REFNM.WordWrap = false;
            // 
            // C_REFNM
            // 
            this.C_REFNM.CanGrow = false;
            this.C_REFNM.Dpi = 100F;
            this.C_REFNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_REFNM.LocationFloat = new DevExpress.Utils.PointFloat(90F, 162F);
            this.C_REFNM.Multiline = true;
            this.C_REFNM.Name = "C_REFNM";
            this.C_REFNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_REFNM.SizeF = new System.Drawing.SizeF(677F, 22F);
            this.C_REFNM.Text = "";
            this.C_REFNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_REFNM.WordWrap = false;
            // 
            // L_P1_TITLE
            // 
            this.L_P1_TITLE.CanGrow = false;
            this.L_P1_TITLE.Dpi = 100F;
            this.L_P1_TITLE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.L_P1_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 184F);
            this.L_P1_TITLE.Multiline = true;
            this.L_P1_TITLE.Name = "L_P1_TITLE";
            this.L_P1_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_TITLE.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.L_P1_TITLE.Text = "제     목";
            this.L_P1_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_TITLE.WordWrap = false;
            // 
            // C_TITLE
            // 
            this.C_TITLE.CanGrow = false;
            this.C_TITLE.Dpi = 100F;
            this.C_TITLE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.C_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(90F, 184F);
            this.C_TITLE.Multiline = true;
            this.C_TITLE.Name = "C_TITLE";
            this.C_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_TITLE.SizeF = new System.Drawing.SizeF(677F, 22F);
            this.C_TITLE.Text = "";
            this.C_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_TITLE.WordWrap = false;
            // 
            // L_P1_LINE2
            // 
            this.L_P1_LINE2.BorderColor = System.Drawing.Color.Black;
            this.L_P1_LINE2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.L_P1_LINE2.BorderWidth = 1F;
            this.L_P1_LINE2.CanGrow = false;
            this.L_P1_LINE2.Dpi = 100F;
            this.L_P1_LINE2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 206F);
            this.L_P1_LINE2.Multiline = true;
            this.L_P1_LINE2.Name = "L_P1_LINE2";
            this.L_P1_LINE2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_LINE2.SizeF = new System.Drawing.SizeF(767F, 4F);
            this.L_P1_LINE2.Text = "";
            this.L_P1_LINE2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_LINE2.WordWrap = false;
            // 
            // L_P1_TEXT1
            // 
            this.L_P1_TEXT1.CanGrow = false;
            this.L_P1_TEXT1.Dpi = 100F;
            this.L_P1_TEXT1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_P1_TEXT1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 222F);
            this.L_P1_TEXT1.Multiline = true;
            this.L_P1_TEXT1.Name = "L_P1_TEXT1";
            this.L_P1_TEXT1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_TEXT1.SizeF = new System.Drawing.SizeF(767F, 20F);
            this.L_P1_TEXT1.Text = "   1. 귀사의 일익 번창하심을 기원합니다.";
            this.L_P1_TEXT1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_TEXT1.WordWrap = false;
            // 
            // L_P1_TEXT2
            // 
            this.L_P1_TEXT2.CanGrow = false;
            this.L_P1_TEXT2.Dpi = 100F;
            this.L_P1_TEXT2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_P1_TEXT2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 248F);
            this.L_P1_TEXT2.Multiline = true;
            this.L_P1_TEXT2.Name = "L_P1_TEXT2";
            this.L_P1_TEXT2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_TEXT2.SizeF = new System.Drawing.SizeF(767F, 20F);
            this.L_P1_TEXT2.Text = "   2. 귀사에서 공급하는 제품에서 가공 불량이 발생함에 따른 손실 비용을 아래와 같이 처리하고자 하오니,";
            this.L_P1_TEXT2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_TEXT2.WordWrap = false;
            // 
            // C_OBJTEXT
            // 
            this.C_OBJTEXT.CanGrow = false;
            this.C_OBJTEXT.Dpi = 100F;
            this.C_OBJTEXT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_OBJTEXT.LocationFloat = new DevExpress.Utils.PointFloat(0F, 268F);
            this.C_OBJTEXT.Multiline = true;
            this.C_OBJTEXT.Name = "C_OBJTEXT";
            this.C_OBJTEXT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_OBJTEXT.SizeF = new System.Drawing.SizeF(767F, 20F);
            this.C_OBJTEXT.Text = "";
            this.C_OBJTEXT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_OBJTEXT.WordWrap = false;
            // 
            // L_P1_BELOW
            // 
            this.L_P1_BELOW.CanGrow = false;
            this.L_P1_BELOW.Dpi = 100F;
            this.L_P1_BELOW.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.L_P1_BELOW.LocationFloat = new DevExpress.Utils.PointFloat(0F, 300F);
            this.L_P1_BELOW.Multiline = true;
            this.L_P1_BELOW.Name = "L_P1_BELOW";
            this.L_P1_BELOW.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_BELOW.SizeF = new System.Drawing.SizeF(767F, 20F);
            this.L_P1_BELOW.Text = "▣ ▣ ▣   아             래   ▣ ▣ ▣";
            this.L_P1_BELOW.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_BELOW.WordWrap = false;
            // 
            // L_P1_SEC1
            // 
            this.L_P1_SEC1.CanGrow = false;
            this.L_P1_SEC1.Dpi = 100F;
            this.L_P1_SEC1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.L_P1_SEC1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 330F);
            this.L_P1_SEC1.Multiline = true;
            this.L_P1_SEC1.Name = "L_P1_SEC1";
            this.L_P1_SEC1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SEC1.SizeF = new System.Drawing.SizeF(767F, 18F);
            this.L_P1_SEC1.Text = "1) CLAIM 상세 내역";
            this.L_P1_SEC1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_SEC1.WordWrap = false;
            // 
            // L_P1_H_NO
            // 
            this.L_P1_H_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_H_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_H_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_H_NO.BorderWidth = 0.5F;
            this.L_P1_H_NO.CanGrow = false;
            this.L_P1_H_NO.Dpi = 100F;
            this.L_P1_H_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 350F);
            this.L_P1_H_NO.Multiline = true;
            this.L_P1_H_NO.Name = "L_P1_H_NO";
            this.L_P1_H_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_H_NO.SizeF = new System.Drawing.SizeF(35F, 36F);
            this.L_P1_H_NO.Text = "NO";
            this.L_P1_H_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_H_NO.WordWrap = false;
            // 
            // L_P1_H_ITEMCD
            // 
            this.L_P1_H_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_H_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_H_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_H_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_H_ITEMCD.CanGrow = false;
            this.L_P1_H_ITEMCD.Dpi = 100F;
            this.L_P1_H_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 350F);
            this.L_P1_H_ITEMCD.Multiline = true;
            this.L_P1_H_ITEMCD.Name = "L_P1_H_ITEMCD";
            this.L_P1_H_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_H_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 36F);
            this.L_P1_H_ITEMCD.Text = "발생품번";
            this.L_P1_H_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_H_ITEMCD.WordWrap = false;
            // 
            // L_P1_H_ITEMNM
            // 
            this.L_P1_H_ITEMNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_H_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_H_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_H_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_H_ITEMNM.CanGrow = false;
            this.L_P1_H_ITEMNM.Dpi = 100F;
            this.L_P1_H_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 350F);
            this.L_P1_H_ITEMNM.Multiline = true;
            this.L_P1_H_ITEMNM.Name = "L_P1_H_ITEMNM";
            this.L_P1_H_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_H_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 36F);
            this.L_P1_H_ITEMNM.Text = "발생품명";
            this.L_P1_H_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_H_ITEMNM.WordWrap = false;
            // 
            // L_P1_H_BADCONT
            // 
            this.L_P1_H_BADCONT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_H_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_H_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_H_BADCONT.BorderWidth = 0.5F;
            this.L_P1_H_BADCONT.CanGrow = false;
            this.L_P1_H_BADCONT.Dpi = 100F;
            this.L_P1_H_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 350F);
            this.L_P1_H_BADCONT.Multiline = true;
            this.L_P1_H_BADCONT.Name = "L_P1_H_BADCONT";
            this.L_P1_H_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_H_BADCONT.SizeF = new System.Drawing.SizeF(230F, 36F);
            this.L_P1_H_BADCONT.Text = "발생 내용";
            this.L_P1_H_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_H_BADCONT.WordWrap = false;
            // 
            // L_P1_H_LOSS
            // 
            this.L_P1_H_LOSS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_H_LOSS.BorderColor = System.Drawing.Color.Black;
            this.L_P1_H_LOSS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_H_LOSS.BorderWidth = 0.5F;
            this.L_P1_H_LOSS.CanGrow = false;
            this.L_P1_H_LOSS.Dpi = 100F;
            this.L_P1_H_LOSS.LocationFloat = new DevExpress.Utils.PointFloat(585F, 350F);
            this.L_P1_H_LOSS.Multiline = true;
            this.L_P1_H_LOSS.Name = "L_P1_H_LOSS";
            this.L_P1_H_LOSS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_H_LOSS.SizeF = new System.Drawing.SizeF(182F, 18F);
            this.L_P1_H_LOSS.Text = "발생 손실 비용";
            this.L_P1_H_LOSS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_H_LOSS.WordWrap = false;
            // 
            // L_P1_H_QTY
            // 
            this.L_P1_H_QTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_H_QTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_H_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_H_QTY.BorderWidth = 0.5F;
            this.L_P1_H_QTY.CanGrow = false;
            this.L_P1_H_QTY.Dpi = 100F;
            this.L_P1_H_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 368F);
            this.L_P1_H_QTY.Multiline = true;
            this.L_P1_H_QTY.Name = "L_P1_H_QTY";
            this.L_P1_H_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_H_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_H_QTY.Text = "수량(EA)";
            this.L_P1_H_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_H_QTY.WordWrap = false;
            // 
            // L_P1_H_AMT
            // 
            this.L_P1_H_AMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_H_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_H_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_H_AMT.BorderWidth = 0.5F;
            this.L_P1_H_AMT.CanGrow = false;
            this.L_P1_H_AMT.Dpi = 100F;
            this.L_P1_H_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 368F);
            this.L_P1_H_AMT.Multiline = true;
            this.L_P1_H_AMT.Name = "L_P1_H_AMT";
            this.L_P1_H_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_H_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.L_P1_H_AMT.Text = "금액";
            this.L_P1_H_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_H_AMT.WordWrap = false;
            // 
            // L_P1_1_NO
            // 
            this.L_P1_1_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_1_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_1_NO.BorderWidth = 0.5F;
            this.L_P1_1_NO.CanGrow = false;
            this.L_P1_1_NO.Dpi = 100F;
            this.L_P1_1_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 386F);
            this.L_P1_1_NO.Multiline = true;
            this.L_P1_1_NO.Name = "L_P1_1_NO";
            this.L_P1_1_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_1_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_1_NO.Text = "1";
            this.L_P1_1_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_1_NO.WordWrap = false;
            // 
            // C_P1_1_ITEMCD
            // 
            this.C_P1_1_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_1_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_1_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_1_ITEMCD.CanGrow = false;
            this.C_P1_1_ITEMCD.Dpi = 100F;
            this.C_P1_1_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 386F);
            this.C_P1_1_ITEMCD.Multiline = true;
            this.C_P1_1_ITEMCD.Name = "C_P1_1_ITEMCD";
            this.C_P1_1_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_1_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_1_ITEMCD.Text = "";
            this.C_P1_1_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_1_ITEMCD.WordWrap = false;
            // 
            // C_P1_1_ITEMNM
            // 
            this.C_P1_1_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_1_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_1_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_1_ITEMNM.CanGrow = false;
            this.C_P1_1_ITEMNM.Dpi = 100F;
            this.C_P1_1_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 386F);
            this.C_P1_1_ITEMNM.Multiline = true;
            this.C_P1_1_ITEMNM.Name = "C_P1_1_ITEMNM";
            this.C_P1_1_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_1_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_1_ITEMNM.Text = "";
            this.C_P1_1_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_1_ITEMNM.WordWrap = false;
            // 
            // C_P1_1_BADCONT
            // 
            this.C_P1_1_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_1_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_1_BADCONT.BorderWidth = 0.5F;
            this.C_P1_1_BADCONT.CanGrow = false;
            this.C_P1_1_BADCONT.Dpi = 100F;
            this.C_P1_1_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 386F);
            this.C_P1_1_BADCONT.Multiline = true;
            this.C_P1_1_BADCONT.Name = "C_P1_1_BADCONT";
            this.C_P1_1_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_1_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_1_BADCONT.Text = "";
            this.C_P1_1_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_1_BADCONT.WordWrap = false;
            // 
            // C_P1_1_QTY
            // 
            this.C_P1_1_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_1_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_1_QTY.BorderWidth = 0.5F;
            this.C_P1_1_QTY.CanGrow = false;
            this.C_P1_1_QTY.Dpi = 100F;
            this.C_P1_1_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 386F);
            this.C_P1_1_QTY.Multiline = true;
            this.C_P1_1_QTY.Name = "C_P1_1_QTY";
            this.C_P1_1_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_1_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_1_QTY.Text = "";
            this.C_P1_1_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_1_QTY.WordWrap = false;
            // 
            // C_P1_1_AMT
            // 
            this.C_P1_1_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_1_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_1_AMT.BorderWidth = 0.5F;
            this.C_P1_1_AMT.CanGrow = false;
            this.C_P1_1_AMT.Dpi = 100F;
            this.C_P1_1_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 386F);
            this.C_P1_1_AMT.Multiline = true;
            this.C_P1_1_AMT.Name = "C_P1_1_AMT";
            this.C_P1_1_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_1_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_1_AMT.Text = "";
            this.C_P1_1_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_1_AMT.WordWrap = false;
            // 
            // L_P1_2_NO
            // 
            this.L_P1_2_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_2_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_2_NO.BorderWidth = 0.5F;
            this.L_P1_2_NO.CanGrow = false;
            this.L_P1_2_NO.Dpi = 100F;
            this.L_P1_2_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 404F);
            this.L_P1_2_NO.Multiline = true;
            this.L_P1_2_NO.Name = "L_P1_2_NO";
            this.L_P1_2_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_2_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_2_NO.Text = "2";
            this.L_P1_2_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_2_NO.WordWrap = false;
            // 
            // C_P1_2_ITEMCD
            // 
            this.C_P1_2_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_2_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_2_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_2_ITEMCD.CanGrow = false;
            this.C_P1_2_ITEMCD.Dpi = 100F;
            this.C_P1_2_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 404F);
            this.C_P1_2_ITEMCD.Multiline = true;
            this.C_P1_2_ITEMCD.Name = "C_P1_2_ITEMCD";
            this.C_P1_2_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_2_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_2_ITEMCD.Text = "";
            this.C_P1_2_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_2_ITEMCD.WordWrap = false;
            // 
            // C_P1_2_ITEMNM
            // 
            this.C_P1_2_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_2_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_2_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_2_ITEMNM.CanGrow = false;
            this.C_P1_2_ITEMNM.Dpi = 100F;
            this.C_P1_2_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 404F);
            this.C_P1_2_ITEMNM.Multiline = true;
            this.C_P1_2_ITEMNM.Name = "C_P1_2_ITEMNM";
            this.C_P1_2_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_2_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_2_ITEMNM.Text = "";
            this.C_P1_2_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_2_ITEMNM.WordWrap = false;
            // 
            // C_P1_2_BADCONT
            // 
            this.C_P1_2_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_2_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_2_BADCONT.BorderWidth = 0.5F;
            this.C_P1_2_BADCONT.CanGrow = false;
            this.C_P1_2_BADCONT.Dpi = 100F;
            this.C_P1_2_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 404F);
            this.C_P1_2_BADCONT.Multiline = true;
            this.C_P1_2_BADCONT.Name = "C_P1_2_BADCONT";
            this.C_P1_2_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_2_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_2_BADCONT.Text = "";
            this.C_P1_2_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_2_BADCONT.WordWrap = false;
            // 
            // C_P1_2_QTY
            // 
            this.C_P1_2_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_2_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_2_QTY.BorderWidth = 0.5F;
            this.C_P1_2_QTY.CanGrow = false;
            this.C_P1_2_QTY.Dpi = 100F;
            this.C_P1_2_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 404F);
            this.C_P1_2_QTY.Multiline = true;
            this.C_P1_2_QTY.Name = "C_P1_2_QTY";
            this.C_P1_2_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_2_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_2_QTY.Text = "";
            this.C_P1_2_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_2_QTY.WordWrap = false;
            // 
            // C_P1_2_AMT
            // 
            this.C_P1_2_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_2_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_2_AMT.BorderWidth = 0.5F;
            this.C_P1_2_AMT.CanGrow = false;
            this.C_P1_2_AMT.Dpi = 100F;
            this.C_P1_2_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 404F);
            this.C_P1_2_AMT.Multiline = true;
            this.C_P1_2_AMT.Name = "C_P1_2_AMT";
            this.C_P1_2_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_2_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_2_AMT.Text = "";
            this.C_P1_2_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_2_AMT.WordWrap = false;
            // 
            // L_P1_3_NO
            // 
            this.L_P1_3_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_3_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_3_NO.BorderWidth = 0.5F;
            this.L_P1_3_NO.CanGrow = false;
            this.L_P1_3_NO.Dpi = 100F;
            this.L_P1_3_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 422F);
            this.L_P1_3_NO.Multiline = true;
            this.L_P1_3_NO.Name = "L_P1_3_NO";
            this.L_P1_3_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_3_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_3_NO.Text = "3";
            this.L_P1_3_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_3_NO.WordWrap = false;
            // 
            // C_P1_3_ITEMCD
            // 
            this.C_P1_3_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_3_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_3_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_3_ITEMCD.CanGrow = false;
            this.C_P1_3_ITEMCD.Dpi = 100F;
            this.C_P1_3_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 422F);
            this.C_P1_3_ITEMCD.Multiline = true;
            this.C_P1_3_ITEMCD.Name = "C_P1_3_ITEMCD";
            this.C_P1_3_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_3_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_3_ITEMCD.Text = "";
            this.C_P1_3_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_3_ITEMCD.WordWrap = false;
            // 
            // C_P1_3_ITEMNM
            // 
            this.C_P1_3_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_3_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_3_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_3_ITEMNM.CanGrow = false;
            this.C_P1_3_ITEMNM.Dpi = 100F;
            this.C_P1_3_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 422F);
            this.C_P1_3_ITEMNM.Multiline = true;
            this.C_P1_3_ITEMNM.Name = "C_P1_3_ITEMNM";
            this.C_P1_3_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_3_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_3_ITEMNM.Text = "";
            this.C_P1_3_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_3_ITEMNM.WordWrap = false;
            // 
            // C_P1_3_BADCONT
            // 
            this.C_P1_3_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_3_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_3_BADCONT.BorderWidth = 0.5F;
            this.C_P1_3_BADCONT.CanGrow = false;
            this.C_P1_3_BADCONT.Dpi = 100F;
            this.C_P1_3_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 422F);
            this.C_P1_3_BADCONT.Multiline = true;
            this.C_P1_3_BADCONT.Name = "C_P1_3_BADCONT";
            this.C_P1_3_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_3_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_3_BADCONT.Text = "";
            this.C_P1_3_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_3_BADCONT.WordWrap = false;
            // 
            // C_P1_3_QTY
            // 
            this.C_P1_3_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_3_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_3_QTY.BorderWidth = 0.5F;
            this.C_P1_3_QTY.CanGrow = false;
            this.C_P1_3_QTY.Dpi = 100F;
            this.C_P1_3_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 422F);
            this.C_P1_3_QTY.Multiline = true;
            this.C_P1_3_QTY.Name = "C_P1_3_QTY";
            this.C_P1_3_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_3_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_3_QTY.Text = "";
            this.C_P1_3_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_3_QTY.WordWrap = false;
            // 
            // C_P1_3_AMT
            // 
            this.C_P1_3_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_3_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_3_AMT.BorderWidth = 0.5F;
            this.C_P1_3_AMT.CanGrow = false;
            this.C_P1_3_AMT.Dpi = 100F;
            this.C_P1_3_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 422F);
            this.C_P1_3_AMT.Multiline = true;
            this.C_P1_3_AMT.Name = "C_P1_3_AMT";
            this.C_P1_3_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_3_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_3_AMT.Text = "";
            this.C_P1_3_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_3_AMT.WordWrap = false;
            // 
            // L_P1_4_NO
            // 
            this.L_P1_4_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_4_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_4_NO.BorderWidth = 0.5F;
            this.L_P1_4_NO.CanGrow = false;
            this.L_P1_4_NO.Dpi = 100F;
            this.L_P1_4_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 440F);
            this.L_P1_4_NO.Multiline = true;
            this.L_P1_4_NO.Name = "L_P1_4_NO";
            this.L_P1_4_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_4_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_4_NO.Text = "4";
            this.L_P1_4_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_4_NO.WordWrap = false;
            // 
            // C_P1_4_ITEMCD
            // 
            this.C_P1_4_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_4_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_4_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_4_ITEMCD.CanGrow = false;
            this.C_P1_4_ITEMCD.Dpi = 100F;
            this.C_P1_4_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 440F);
            this.C_P1_4_ITEMCD.Multiline = true;
            this.C_P1_4_ITEMCD.Name = "C_P1_4_ITEMCD";
            this.C_P1_4_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_4_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_4_ITEMCD.Text = "";
            this.C_P1_4_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_4_ITEMCD.WordWrap = false;
            // 
            // C_P1_4_ITEMNM
            // 
            this.C_P1_4_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_4_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_4_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_4_ITEMNM.CanGrow = false;
            this.C_P1_4_ITEMNM.Dpi = 100F;
            this.C_P1_4_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 440F);
            this.C_P1_4_ITEMNM.Multiline = true;
            this.C_P1_4_ITEMNM.Name = "C_P1_4_ITEMNM";
            this.C_P1_4_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_4_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_4_ITEMNM.Text = "";
            this.C_P1_4_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_4_ITEMNM.WordWrap = false;
            // 
            // C_P1_4_BADCONT
            // 
            this.C_P1_4_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_4_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_4_BADCONT.BorderWidth = 0.5F;
            this.C_P1_4_BADCONT.CanGrow = false;
            this.C_P1_4_BADCONT.Dpi = 100F;
            this.C_P1_4_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 440F);
            this.C_P1_4_BADCONT.Multiline = true;
            this.C_P1_4_BADCONT.Name = "C_P1_4_BADCONT";
            this.C_P1_4_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_4_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_4_BADCONT.Text = "";
            this.C_P1_4_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_4_BADCONT.WordWrap = false;
            // 
            // C_P1_4_QTY
            // 
            this.C_P1_4_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_4_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_4_QTY.BorderWidth = 0.5F;
            this.C_P1_4_QTY.CanGrow = false;
            this.C_P1_4_QTY.Dpi = 100F;
            this.C_P1_4_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 440F);
            this.C_P1_4_QTY.Multiline = true;
            this.C_P1_4_QTY.Name = "C_P1_4_QTY";
            this.C_P1_4_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_4_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_4_QTY.Text = "";
            this.C_P1_4_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_4_QTY.WordWrap = false;
            // 
            // C_P1_4_AMT
            // 
            this.C_P1_4_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_4_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_4_AMT.BorderWidth = 0.5F;
            this.C_P1_4_AMT.CanGrow = false;
            this.C_P1_4_AMT.Dpi = 100F;
            this.C_P1_4_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 440F);
            this.C_P1_4_AMT.Multiline = true;
            this.C_P1_4_AMT.Name = "C_P1_4_AMT";
            this.C_P1_4_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_4_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_4_AMT.Text = "";
            this.C_P1_4_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_4_AMT.WordWrap = false;
            // 
            // L_P1_5_NO
            // 
            this.L_P1_5_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_5_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_5_NO.BorderWidth = 0.5F;
            this.L_P1_5_NO.CanGrow = false;
            this.L_P1_5_NO.Dpi = 100F;
            this.L_P1_5_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 458F);
            this.L_P1_5_NO.Multiline = true;
            this.L_P1_5_NO.Name = "L_P1_5_NO";
            this.L_P1_5_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_5_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_5_NO.Text = "5";
            this.L_P1_5_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_5_NO.WordWrap = false;
            // 
            // C_P1_5_ITEMCD
            // 
            this.C_P1_5_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_5_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_5_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_5_ITEMCD.CanGrow = false;
            this.C_P1_5_ITEMCD.Dpi = 100F;
            this.C_P1_5_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 458F);
            this.C_P1_5_ITEMCD.Multiline = true;
            this.C_P1_5_ITEMCD.Name = "C_P1_5_ITEMCD";
            this.C_P1_5_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_5_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_5_ITEMCD.Text = "";
            this.C_P1_5_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_5_ITEMCD.WordWrap = false;
            // 
            // C_P1_5_ITEMNM
            // 
            this.C_P1_5_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_5_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_5_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_5_ITEMNM.CanGrow = false;
            this.C_P1_5_ITEMNM.Dpi = 100F;
            this.C_P1_5_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 458F);
            this.C_P1_5_ITEMNM.Multiline = true;
            this.C_P1_5_ITEMNM.Name = "C_P1_5_ITEMNM";
            this.C_P1_5_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_5_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_5_ITEMNM.Text = "";
            this.C_P1_5_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_5_ITEMNM.WordWrap = false;
            // 
            // C_P1_5_BADCONT
            // 
            this.C_P1_5_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_5_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_5_BADCONT.BorderWidth = 0.5F;
            this.C_P1_5_BADCONT.CanGrow = false;
            this.C_P1_5_BADCONT.Dpi = 100F;
            this.C_P1_5_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 458F);
            this.C_P1_5_BADCONT.Multiline = true;
            this.C_P1_5_BADCONT.Name = "C_P1_5_BADCONT";
            this.C_P1_5_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_5_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_5_BADCONT.Text = "";
            this.C_P1_5_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_5_BADCONT.WordWrap = false;
            // 
            // C_P1_5_QTY
            // 
            this.C_P1_5_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_5_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_5_QTY.BorderWidth = 0.5F;
            this.C_P1_5_QTY.CanGrow = false;
            this.C_P1_5_QTY.Dpi = 100F;
            this.C_P1_5_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 458F);
            this.C_P1_5_QTY.Multiline = true;
            this.C_P1_5_QTY.Name = "C_P1_5_QTY";
            this.C_P1_5_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_5_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_5_QTY.Text = "";
            this.C_P1_5_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_5_QTY.WordWrap = false;
            // 
            // C_P1_5_AMT
            // 
            this.C_P1_5_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_5_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_5_AMT.BorderWidth = 0.5F;
            this.C_P1_5_AMT.CanGrow = false;
            this.C_P1_5_AMT.Dpi = 100F;
            this.C_P1_5_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 458F);
            this.C_P1_5_AMT.Multiline = true;
            this.C_P1_5_AMT.Name = "C_P1_5_AMT";
            this.C_P1_5_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_5_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_5_AMT.Text = "";
            this.C_P1_5_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_5_AMT.WordWrap = false;
            // 
            // L_P1_6_NO
            // 
            this.L_P1_6_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_6_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_6_NO.BorderWidth = 0.5F;
            this.L_P1_6_NO.CanGrow = false;
            this.L_P1_6_NO.Dpi = 100F;
            this.L_P1_6_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 476F);
            this.L_P1_6_NO.Multiline = true;
            this.L_P1_6_NO.Name = "L_P1_6_NO";
            this.L_P1_6_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_6_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_6_NO.Text = "6";
            this.L_P1_6_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_6_NO.WordWrap = false;
            // 
            // C_P1_6_ITEMCD
            // 
            this.C_P1_6_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_6_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_6_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_6_ITEMCD.CanGrow = false;
            this.C_P1_6_ITEMCD.Dpi = 100F;
            this.C_P1_6_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 476F);
            this.C_P1_6_ITEMCD.Multiline = true;
            this.C_P1_6_ITEMCD.Name = "C_P1_6_ITEMCD";
            this.C_P1_6_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_6_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_6_ITEMCD.Text = "";
            this.C_P1_6_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_6_ITEMCD.WordWrap = false;
            // 
            // C_P1_6_ITEMNM
            // 
            this.C_P1_6_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_6_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_6_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_6_ITEMNM.CanGrow = false;
            this.C_P1_6_ITEMNM.Dpi = 100F;
            this.C_P1_6_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 476F);
            this.C_P1_6_ITEMNM.Multiline = true;
            this.C_P1_6_ITEMNM.Name = "C_P1_6_ITEMNM";
            this.C_P1_6_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_6_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_6_ITEMNM.Text = "";
            this.C_P1_6_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_6_ITEMNM.WordWrap = false;
            // 
            // C_P1_6_BADCONT
            // 
            this.C_P1_6_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_6_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_6_BADCONT.BorderWidth = 0.5F;
            this.C_P1_6_BADCONT.CanGrow = false;
            this.C_P1_6_BADCONT.Dpi = 100F;
            this.C_P1_6_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 476F);
            this.C_P1_6_BADCONT.Multiline = true;
            this.C_P1_6_BADCONT.Name = "C_P1_6_BADCONT";
            this.C_P1_6_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_6_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_6_BADCONT.Text = "";
            this.C_P1_6_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_6_BADCONT.WordWrap = false;
            // 
            // C_P1_6_QTY
            // 
            this.C_P1_6_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_6_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_6_QTY.BorderWidth = 0.5F;
            this.C_P1_6_QTY.CanGrow = false;
            this.C_P1_6_QTY.Dpi = 100F;
            this.C_P1_6_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 476F);
            this.C_P1_6_QTY.Multiline = true;
            this.C_P1_6_QTY.Name = "C_P1_6_QTY";
            this.C_P1_6_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_6_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_6_QTY.Text = "";
            this.C_P1_6_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_6_QTY.WordWrap = false;
            // 
            // C_P1_6_AMT
            // 
            this.C_P1_6_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_6_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_6_AMT.BorderWidth = 0.5F;
            this.C_P1_6_AMT.CanGrow = false;
            this.C_P1_6_AMT.Dpi = 100F;
            this.C_P1_6_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 476F);
            this.C_P1_6_AMT.Multiline = true;
            this.C_P1_6_AMT.Name = "C_P1_6_AMT";
            this.C_P1_6_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_6_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_6_AMT.Text = "";
            this.C_P1_6_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_6_AMT.WordWrap = false;
            // 
            // L_P1_7_NO
            // 
            this.L_P1_7_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_7_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_7_NO.BorderWidth = 0.5F;
            this.L_P1_7_NO.CanGrow = false;
            this.L_P1_7_NO.Dpi = 100F;
            this.L_P1_7_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 494F);
            this.L_P1_7_NO.Multiline = true;
            this.L_P1_7_NO.Name = "L_P1_7_NO";
            this.L_P1_7_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_7_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_7_NO.Text = "7";
            this.L_P1_7_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_7_NO.WordWrap = false;
            // 
            // C_P1_7_ITEMCD
            // 
            this.C_P1_7_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_7_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_7_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_7_ITEMCD.CanGrow = false;
            this.C_P1_7_ITEMCD.Dpi = 100F;
            this.C_P1_7_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 494F);
            this.C_P1_7_ITEMCD.Multiline = true;
            this.C_P1_7_ITEMCD.Name = "C_P1_7_ITEMCD";
            this.C_P1_7_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_7_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_7_ITEMCD.Text = "";
            this.C_P1_7_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_7_ITEMCD.WordWrap = false;
            // 
            // C_P1_7_ITEMNM
            // 
            this.C_P1_7_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_7_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_7_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_7_ITEMNM.CanGrow = false;
            this.C_P1_7_ITEMNM.Dpi = 100F;
            this.C_P1_7_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 494F);
            this.C_P1_7_ITEMNM.Multiline = true;
            this.C_P1_7_ITEMNM.Name = "C_P1_7_ITEMNM";
            this.C_P1_7_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_7_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_7_ITEMNM.Text = "";
            this.C_P1_7_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_7_ITEMNM.WordWrap = false;
            // 
            // C_P1_7_BADCONT
            // 
            this.C_P1_7_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_7_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_7_BADCONT.BorderWidth = 0.5F;
            this.C_P1_7_BADCONT.CanGrow = false;
            this.C_P1_7_BADCONT.Dpi = 100F;
            this.C_P1_7_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 494F);
            this.C_P1_7_BADCONT.Multiline = true;
            this.C_P1_7_BADCONT.Name = "C_P1_7_BADCONT";
            this.C_P1_7_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_7_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_7_BADCONT.Text = "";
            this.C_P1_7_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_7_BADCONT.WordWrap = false;
            // 
            // C_P1_7_QTY
            // 
            this.C_P1_7_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_7_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_7_QTY.BorderWidth = 0.5F;
            this.C_P1_7_QTY.CanGrow = false;
            this.C_P1_7_QTY.Dpi = 100F;
            this.C_P1_7_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 494F);
            this.C_P1_7_QTY.Multiline = true;
            this.C_P1_7_QTY.Name = "C_P1_7_QTY";
            this.C_P1_7_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_7_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_7_QTY.Text = "";
            this.C_P1_7_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_7_QTY.WordWrap = false;
            // 
            // C_P1_7_AMT
            // 
            this.C_P1_7_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_7_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_7_AMT.BorderWidth = 0.5F;
            this.C_P1_7_AMT.CanGrow = false;
            this.C_P1_7_AMT.Dpi = 100F;
            this.C_P1_7_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 494F);
            this.C_P1_7_AMT.Multiline = true;
            this.C_P1_7_AMT.Name = "C_P1_7_AMT";
            this.C_P1_7_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_7_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_7_AMT.Text = "";
            this.C_P1_7_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_7_AMT.WordWrap = false;
            // 
            // L_P1_8_NO
            // 
            this.L_P1_8_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_8_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_8_NO.BorderWidth = 0.5F;
            this.L_P1_8_NO.CanGrow = false;
            this.L_P1_8_NO.Dpi = 100F;
            this.L_P1_8_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 512F);
            this.L_P1_8_NO.Multiline = true;
            this.L_P1_8_NO.Name = "L_P1_8_NO";
            this.L_P1_8_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_8_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_8_NO.Text = "8";
            this.L_P1_8_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_8_NO.WordWrap = false;
            // 
            // C_P1_8_ITEMCD
            // 
            this.C_P1_8_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_8_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_8_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_8_ITEMCD.CanGrow = false;
            this.C_P1_8_ITEMCD.Dpi = 100F;
            this.C_P1_8_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 512F);
            this.C_P1_8_ITEMCD.Multiline = true;
            this.C_P1_8_ITEMCD.Name = "C_P1_8_ITEMCD";
            this.C_P1_8_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_8_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_8_ITEMCD.Text = "";
            this.C_P1_8_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_8_ITEMCD.WordWrap = false;
            // 
            // C_P1_8_ITEMNM
            // 
            this.C_P1_8_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_8_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_8_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_8_ITEMNM.CanGrow = false;
            this.C_P1_8_ITEMNM.Dpi = 100F;
            this.C_P1_8_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 512F);
            this.C_P1_8_ITEMNM.Multiline = true;
            this.C_P1_8_ITEMNM.Name = "C_P1_8_ITEMNM";
            this.C_P1_8_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_8_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_8_ITEMNM.Text = "";
            this.C_P1_8_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_8_ITEMNM.WordWrap = false;
            // 
            // C_P1_8_BADCONT
            // 
            this.C_P1_8_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_8_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_8_BADCONT.BorderWidth = 0.5F;
            this.C_P1_8_BADCONT.CanGrow = false;
            this.C_P1_8_BADCONT.Dpi = 100F;
            this.C_P1_8_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 512F);
            this.C_P1_8_BADCONT.Multiline = true;
            this.C_P1_8_BADCONT.Name = "C_P1_8_BADCONT";
            this.C_P1_8_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_8_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_8_BADCONT.Text = "";
            this.C_P1_8_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_8_BADCONT.WordWrap = false;
            // 
            // C_P1_8_QTY
            // 
            this.C_P1_8_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_8_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_8_QTY.BorderWidth = 0.5F;
            this.C_P1_8_QTY.CanGrow = false;
            this.C_P1_8_QTY.Dpi = 100F;
            this.C_P1_8_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 512F);
            this.C_P1_8_QTY.Multiline = true;
            this.C_P1_8_QTY.Name = "C_P1_8_QTY";
            this.C_P1_8_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_8_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_8_QTY.Text = "";
            this.C_P1_8_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_8_QTY.WordWrap = false;
            // 
            // C_P1_8_AMT
            // 
            this.C_P1_8_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_8_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_8_AMT.BorderWidth = 0.5F;
            this.C_P1_8_AMT.CanGrow = false;
            this.C_P1_8_AMT.Dpi = 100F;
            this.C_P1_8_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 512F);
            this.C_P1_8_AMT.Multiline = true;
            this.C_P1_8_AMT.Name = "C_P1_8_AMT";
            this.C_P1_8_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_8_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_8_AMT.Text = "";
            this.C_P1_8_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_8_AMT.WordWrap = false;
            // 
            // L_P1_9_NO
            // 
            this.L_P1_9_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_9_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_9_NO.BorderWidth = 0.5F;
            this.L_P1_9_NO.CanGrow = false;
            this.L_P1_9_NO.Dpi = 100F;
            this.L_P1_9_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 530F);
            this.L_P1_9_NO.Multiline = true;
            this.L_P1_9_NO.Name = "L_P1_9_NO";
            this.L_P1_9_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_9_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_9_NO.Text = "9";
            this.L_P1_9_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_9_NO.WordWrap = false;
            // 
            // C_P1_9_ITEMCD
            // 
            this.C_P1_9_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_9_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_9_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_9_ITEMCD.CanGrow = false;
            this.C_P1_9_ITEMCD.Dpi = 100F;
            this.C_P1_9_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 530F);
            this.C_P1_9_ITEMCD.Multiline = true;
            this.C_P1_9_ITEMCD.Name = "C_P1_9_ITEMCD";
            this.C_P1_9_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_9_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_9_ITEMCD.Text = "";
            this.C_P1_9_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_9_ITEMCD.WordWrap = false;
            // 
            // C_P1_9_ITEMNM
            // 
            this.C_P1_9_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_9_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_9_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_9_ITEMNM.CanGrow = false;
            this.C_P1_9_ITEMNM.Dpi = 100F;
            this.C_P1_9_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 530F);
            this.C_P1_9_ITEMNM.Multiline = true;
            this.C_P1_9_ITEMNM.Name = "C_P1_9_ITEMNM";
            this.C_P1_9_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_9_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_9_ITEMNM.Text = "";
            this.C_P1_9_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_9_ITEMNM.WordWrap = false;
            // 
            // C_P1_9_BADCONT
            // 
            this.C_P1_9_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_9_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_9_BADCONT.BorderWidth = 0.5F;
            this.C_P1_9_BADCONT.CanGrow = false;
            this.C_P1_9_BADCONT.Dpi = 100F;
            this.C_P1_9_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 530F);
            this.C_P1_9_BADCONT.Multiline = true;
            this.C_P1_9_BADCONT.Name = "C_P1_9_BADCONT";
            this.C_P1_9_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_9_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_9_BADCONT.Text = "";
            this.C_P1_9_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_9_BADCONT.WordWrap = false;
            // 
            // C_P1_9_QTY
            // 
            this.C_P1_9_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_9_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_9_QTY.BorderWidth = 0.5F;
            this.C_P1_9_QTY.CanGrow = false;
            this.C_P1_9_QTY.Dpi = 100F;
            this.C_P1_9_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 530F);
            this.C_P1_9_QTY.Multiline = true;
            this.C_P1_9_QTY.Name = "C_P1_9_QTY";
            this.C_P1_9_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_9_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_9_QTY.Text = "";
            this.C_P1_9_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_9_QTY.WordWrap = false;
            // 
            // C_P1_9_AMT
            // 
            this.C_P1_9_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_9_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_9_AMT.BorderWidth = 0.5F;
            this.C_P1_9_AMT.CanGrow = false;
            this.C_P1_9_AMT.Dpi = 100F;
            this.C_P1_9_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 530F);
            this.C_P1_9_AMT.Multiline = true;
            this.C_P1_9_AMT.Name = "C_P1_9_AMT";
            this.C_P1_9_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_9_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_9_AMT.Text = "";
            this.C_P1_9_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_9_AMT.WordWrap = false;
            // 
            // L_P1_10_NO
            // 
            this.L_P1_10_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_10_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_10_NO.BorderWidth = 0.5F;
            this.L_P1_10_NO.CanGrow = false;
            this.L_P1_10_NO.Dpi = 100F;
            this.L_P1_10_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 548F);
            this.L_P1_10_NO.Multiline = true;
            this.L_P1_10_NO.Name = "L_P1_10_NO";
            this.L_P1_10_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_10_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_10_NO.Text = "10";
            this.L_P1_10_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_10_NO.WordWrap = false;
            // 
            // C_P1_10_ITEMCD
            // 
            this.C_P1_10_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_10_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_10_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_10_ITEMCD.CanGrow = false;
            this.C_P1_10_ITEMCD.Dpi = 100F;
            this.C_P1_10_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 548F);
            this.C_P1_10_ITEMCD.Multiline = true;
            this.C_P1_10_ITEMCD.Name = "C_P1_10_ITEMCD";
            this.C_P1_10_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_10_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_10_ITEMCD.Text = "";
            this.C_P1_10_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_10_ITEMCD.WordWrap = false;
            // 
            // C_P1_10_ITEMNM
            // 
            this.C_P1_10_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_10_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_10_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_10_ITEMNM.CanGrow = false;
            this.C_P1_10_ITEMNM.Dpi = 100F;
            this.C_P1_10_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 548F);
            this.C_P1_10_ITEMNM.Multiline = true;
            this.C_P1_10_ITEMNM.Name = "C_P1_10_ITEMNM";
            this.C_P1_10_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_10_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_10_ITEMNM.Text = "";
            this.C_P1_10_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_10_ITEMNM.WordWrap = false;
            // 
            // C_P1_10_BADCONT
            // 
            this.C_P1_10_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_10_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_10_BADCONT.BorderWidth = 0.5F;
            this.C_P1_10_BADCONT.CanGrow = false;
            this.C_P1_10_BADCONT.Dpi = 100F;
            this.C_P1_10_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 548F);
            this.C_P1_10_BADCONT.Multiline = true;
            this.C_P1_10_BADCONT.Name = "C_P1_10_BADCONT";
            this.C_P1_10_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_10_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_10_BADCONT.Text = "";
            this.C_P1_10_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_10_BADCONT.WordWrap = false;
            // 
            // C_P1_10_QTY
            // 
            this.C_P1_10_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_10_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_10_QTY.BorderWidth = 0.5F;
            this.C_P1_10_QTY.CanGrow = false;
            this.C_P1_10_QTY.Dpi = 100F;
            this.C_P1_10_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 548F);
            this.C_P1_10_QTY.Multiline = true;
            this.C_P1_10_QTY.Name = "C_P1_10_QTY";
            this.C_P1_10_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_10_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_10_QTY.Text = "";
            this.C_P1_10_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_10_QTY.WordWrap = false;
            // 
            // C_P1_10_AMT
            // 
            this.C_P1_10_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_10_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_10_AMT.BorderWidth = 0.5F;
            this.C_P1_10_AMT.CanGrow = false;
            this.C_P1_10_AMT.Dpi = 100F;
            this.C_P1_10_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 548F);
            this.C_P1_10_AMT.Multiline = true;
            this.C_P1_10_AMT.Name = "C_P1_10_AMT";
            this.C_P1_10_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_10_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_10_AMT.Text = "";
            this.C_P1_10_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_10_AMT.WordWrap = false;
            // 
            // L_P1_11_NO
            // 
            this.L_P1_11_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_11_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_11_NO.BorderWidth = 0.5F;
            this.L_P1_11_NO.CanGrow = false;
            this.L_P1_11_NO.Dpi = 100F;
            this.L_P1_11_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 566F);
            this.L_P1_11_NO.Multiline = true;
            this.L_P1_11_NO.Name = "L_P1_11_NO";
            this.L_P1_11_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_11_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_11_NO.Text = "11";
            this.L_P1_11_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_11_NO.WordWrap = false;
            // 
            // C_P1_11_ITEMCD
            // 
            this.C_P1_11_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_11_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_11_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_11_ITEMCD.CanGrow = false;
            this.C_P1_11_ITEMCD.Dpi = 100F;
            this.C_P1_11_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 566F);
            this.C_P1_11_ITEMCD.Multiline = true;
            this.C_P1_11_ITEMCD.Name = "C_P1_11_ITEMCD";
            this.C_P1_11_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_11_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_11_ITEMCD.Text = "";
            this.C_P1_11_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_11_ITEMCD.WordWrap = false;
            // 
            // C_P1_11_ITEMNM
            // 
            this.C_P1_11_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_11_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_11_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_11_ITEMNM.CanGrow = false;
            this.C_P1_11_ITEMNM.Dpi = 100F;
            this.C_P1_11_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 566F);
            this.C_P1_11_ITEMNM.Multiline = true;
            this.C_P1_11_ITEMNM.Name = "C_P1_11_ITEMNM";
            this.C_P1_11_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_11_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_11_ITEMNM.Text = "";
            this.C_P1_11_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_11_ITEMNM.WordWrap = false;
            // 
            // C_P1_11_BADCONT
            // 
            this.C_P1_11_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_11_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_11_BADCONT.BorderWidth = 0.5F;
            this.C_P1_11_BADCONT.CanGrow = false;
            this.C_P1_11_BADCONT.Dpi = 100F;
            this.C_P1_11_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 566F);
            this.C_P1_11_BADCONT.Multiline = true;
            this.C_P1_11_BADCONT.Name = "C_P1_11_BADCONT";
            this.C_P1_11_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_11_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_11_BADCONT.Text = "";
            this.C_P1_11_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_11_BADCONT.WordWrap = false;
            // 
            // C_P1_11_QTY
            // 
            this.C_P1_11_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_11_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_11_QTY.BorderWidth = 0.5F;
            this.C_P1_11_QTY.CanGrow = false;
            this.C_P1_11_QTY.Dpi = 100F;
            this.C_P1_11_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 566F);
            this.C_P1_11_QTY.Multiline = true;
            this.C_P1_11_QTY.Name = "C_P1_11_QTY";
            this.C_P1_11_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_11_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_11_QTY.Text = "";
            this.C_P1_11_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_11_QTY.WordWrap = false;
            // 
            // C_P1_11_AMT
            // 
            this.C_P1_11_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_11_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_11_AMT.BorderWidth = 0.5F;
            this.C_P1_11_AMT.CanGrow = false;
            this.C_P1_11_AMT.Dpi = 100F;
            this.C_P1_11_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 566F);
            this.C_P1_11_AMT.Multiline = true;
            this.C_P1_11_AMT.Name = "C_P1_11_AMT";
            this.C_P1_11_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_11_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_11_AMT.Text = "";
            this.C_P1_11_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_11_AMT.WordWrap = false;
            // 
            // L_P1_12_NO
            // 
            this.L_P1_12_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_12_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_12_NO.BorderWidth = 0.5F;
            this.L_P1_12_NO.CanGrow = false;
            this.L_P1_12_NO.Dpi = 100F;
            this.L_P1_12_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 584F);
            this.L_P1_12_NO.Multiline = true;
            this.L_P1_12_NO.Name = "L_P1_12_NO";
            this.L_P1_12_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_12_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_12_NO.Text = "12";
            this.L_P1_12_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_12_NO.WordWrap = false;
            // 
            // C_P1_12_ITEMCD
            // 
            this.C_P1_12_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_12_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_12_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_12_ITEMCD.CanGrow = false;
            this.C_P1_12_ITEMCD.Dpi = 100F;
            this.C_P1_12_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 584F);
            this.C_P1_12_ITEMCD.Multiline = true;
            this.C_P1_12_ITEMCD.Name = "C_P1_12_ITEMCD";
            this.C_P1_12_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_12_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_12_ITEMCD.Text = "";
            this.C_P1_12_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_12_ITEMCD.WordWrap = false;
            // 
            // C_P1_12_ITEMNM
            // 
            this.C_P1_12_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_12_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_12_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_12_ITEMNM.CanGrow = false;
            this.C_P1_12_ITEMNM.Dpi = 100F;
            this.C_P1_12_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 584F);
            this.C_P1_12_ITEMNM.Multiline = true;
            this.C_P1_12_ITEMNM.Name = "C_P1_12_ITEMNM";
            this.C_P1_12_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_12_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_12_ITEMNM.Text = "";
            this.C_P1_12_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_12_ITEMNM.WordWrap = false;
            // 
            // C_P1_12_BADCONT
            // 
            this.C_P1_12_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_12_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_12_BADCONT.BorderWidth = 0.5F;
            this.C_P1_12_BADCONT.CanGrow = false;
            this.C_P1_12_BADCONT.Dpi = 100F;
            this.C_P1_12_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 584F);
            this.C_P1_12_BADCONT.Multiline = true;
            this.C_P1_12_BADCONT.Name = "C_P1_12_BADCONT";
            this.C_P1_12_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_12_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_12_BADCONT.Text = "";
            this.C_P1_12_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_12_BADCONT.WordWrap = false;
            // 
            // C_P1_12_QTY
            // 
            this.C_P1_12_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_12_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_12_QTY.BorderWidth = 0.5F;
            this.C_P1_12_QTY.CanGrow = false;
            this.C_P1_12_QTY.Dpi = 100F;
            this.C_P1_12_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 584F);
            this.C_P1_12_QTY.Multiline = true;
            this.C_P1_12_QTY.Name = "C_P1_12_QTY";
            this.C_P1_12_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_12_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_12_QTY.Text = "";
            this.C_P1_12_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_12_QTY.WordWrap = false;
            // 
            // C_P1_12_AMT
            // 
            this.C_P1_12_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_12_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_12_AMT.BorderWidth = 0.5F;
            this.C_P1_12_AMT.CanGrow = false;
            this.C_P1_12_AMT.Dpi = 100F;
            this.C_P1_12_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 584F);
            this.C_P1_12_AMT.Multiline = true;
            this.C_P1_12_AMT.Name = "C_P1_12_AMT";
            this.C_P1_12_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_12_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_12_AMT.Text = "";
            this.C_P1_12_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_12_AMT.WordWrap = false;
            // 
            // L_P1_13_NO
            // 
            this.L_P1_13_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_13_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_13_NO.BorderWidth = 0.5F;
            this.L_P1_13_NO.CanGrow = false;
            this.L_P1_13_NO.Dpi = 100F;
            this.L_P1_13_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 602F);
            this.L_P1_13_NO.Multiline = true;
            this.L_P1_13_NO.Name = "L_P1_13_NO";
            this.L_P1_13_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_13_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_13_NO.Text = "13";
            this.L_P1_13_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_13_NO.WordWrap = false;
            // 
            // C_P1_13_ITEMCD
            // 
            this.C_P1_13_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_13_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_13_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_13_ITEMCD.CanGrow = false;
            this.C_P1_13_ITEMCD.Dpi = 100F;
            this.C_P1_13_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 602F);
            this.C_P1_13_ITEMCD.Multiline = true;
            this.C_P1_13_ITEMCD.Name = "C_P1_13_ITEMCD";
            this.C_P1_13_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_13_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_13_ITEMCD.Text = "";
            this.C_P1_13_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_13_ITEMCD.WordWrap = false;
            // 
            // C_P1_13_ITEMNM
            // 
            this.C_P1_13_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_13_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_13_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_13_ITEMNM.CanGrow = false;
            this.C_P1_13_ITEMNM.Dpi = 100F;
            this.C_P1_13_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 602F);
            this.C_P1_13_ITEMNM.Multiline = true;
            this.C_P1_13_ITEMNM.Name = "C_P1_13_ITEMNM";
            this.C_P1_13_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_13_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_13_ITEMNM.Text = "";
            this.C_P1_13_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_13_ITEMNM.WordWrap = false;
            // 
            // C_P1_13_BADCONT
            // 
            this.C_P1_13_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_13_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_13_BADCONT.BorderWidth = 0.5F;
            this.C_P1_13_BADCONT.CanGrow = false;
            this.C_P1_13_BADCONT.Dpi = 100F;
            this.C_P1_13_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 602F);
            this.C_P1_13_BADCONT.Multiline = true;
            this.C_P1_13_BADCONT.Name = "C_P1_13_BADCONT";
            this.C_P1_13_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_13_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_13_BADCONT.Text = "";
            this.C_P1_13_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_13_BADCONT.WordWrap = false;
            // 
            // C_P1_13_QTY
            // 
            this.C_P1_13_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_13_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_13_QTY.BorderWidth = 0.5F;
            this.C_P1_13_QTY.CanGrow = false;
            this.C_P1_13_QTY.Dpi = 100F;
            this.C_P1_13_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 602F);
            this.C_P1_13_QTY.Multiline = true;
            this.C_P1_13_QTY.Name = "C_P1_13_QTY";
            this.C_P1_13_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_13_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_13_QTY.Text = "";
            this.C_P1_13_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_13_QTY.WordWrap = false;
            // 
            // C_P1_13_AMT
            // 
            this.C_P1_13_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_13_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_13_AMT.BorderWidth = 0.5F;
            this.C_P1_13_AMT.CanGrow = false;
            this.C_P1_13_AMT.Dpi = 100F;
            this.C_P1_13_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 602F);
            this.C_P1_13_AMT.Multiline = true;
            this.C_P1_13_AMT.Name = "C_P1_13_AMT";
            this.C_P1_13_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_13_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_13_AMT.Text = "";
            this.C_P1_13_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_13_AMT.WordWrap = false;
            // 
            // L_P1_14_NO
            // 
            this.L_P1_14_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_14_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_14_NO.BorderWidth = 0.5F;
            this.L_P1_14_NO.CanGrow = false;
            this.L_P1_14_NO.Dpi = 100F;
            this.L_P1_14_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 620F);
            this.L_P1_14_NO.Multiline = true;
            this.L_P1_14_NO.Name = "L_P1_14_NO";
            this.L_P1_14_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_14_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_14_NO.Text = "14";
            this.L_P1_14_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_14_NO.WordWrap = false;
            // 
            // C_P1_14_ITEMCD
            // 
            this.C_P1_14_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_14_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_14_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_14_ITEMCD.CanGrow = false;
            this.C_P1_14_ITEMCD.Dpi = 100F;
            this.C_P1_14_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 620F);
            this.C_P1_14_ITEMCD.Multiline = true;
            this.C_P1_14_ITEMCD.Name = "C_P1_14_ITEMCD";
            this.C_P1_14_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_14_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_14_ITEMCD.Text = "";
            this.C_P1_14_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_14_ITEMCD.WordWrap = false;
            // 
            // C_P1_14_ITEMNM
            // 
            this.C_P1_14_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_14_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_14_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_14_ITEMNM.CanGrow = false;
            this.C_P1_14_ITEMNM.Dpi = 100F;
            this.C_P1_14_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 620F);
            this.C_P1_14_ITEMNM.Multiline = true;
            this.C_P1_14_ITEMNM.Name = "C_P1_14_ITEMNM";
            this.C_P1_14_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_14_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_14_ITEMNM.Text = "";
            this.C_P1_14_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_14_ITEMNM.WordWrap = false;
            // 
            // C_P1_14_BADCONT
            // 
            this.C_P1_14_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_14_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_14_BADCONT.BorderWidth = 0.5F;
            this.C_P1_14_BADCONT.CanGrow = false;
            this.C_P1_14_BADCONT.Dpi = 100F;
            this.C_P1_14_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 620F);
            this.C_P1_14_BADCONT.Multiline = true;
            this.C_P1_14_BADCONT.Name = "C_P1_14_BADCONT";
            this.C_P1_14_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_14_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_14_BADCONT.Text = "";
            this.C_P1_14_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_14_BADCONT.WordWrap = false;
            // 
            // C_P1_14_QTY
            // 
            this.C_P1_14_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_14_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_14_QTY.BorderWidth = 0.5F;
            this.C_P1_14_QTY.CanGrow = false;
            this.C_P1_14_QTY.Dpi = 100F;
            this.C_P1_14_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 620F);
            this.C_P1_14_QTY.Multiline = true;
            this.C_P1_14_QTY.Name = "C_P1_14_QTY";
            this.C_P1_14_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_14_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_14_QTY.Text = "";
            this.C_P1_14_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_14_QTY.WordWrap = false;
            // 
            // C_P1_14_AMT
            // 
            this.C_P1_14_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_14_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_14_AMT.BorderWidth = 0.5F;
            this.C_P1_14_AMT.CanGrow = false;
            this.C_P1_14_AMT.Dpi = 100F;
            this.C_P1_14_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 620F);
            this.C_P1_14_AMT.Multiline = true;
            this.C_P1_14_AMT.Name = "C_P1_14_AMT";
            this.C_P1_14_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_14_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_14_AMT.Text = "";
            this.C_P1_14_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_14_AMT.WordWrap = false;
            // 
            // L_P1_15_NO
            // 
            this.L_P1_15_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_15_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_15_NO.BorderWidth = 0.5F;
            this.L_P1_15_NO.CanGrow = false;
            this.L_P1_15_NO.Dpi = 100F;
            this.L_P1_15_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 638F);
            this.L_P1_15_NO.Multiline = true;
            this.L_P1_15_NO.Name = "L_P1_15_NO";
            this.L_P1_15_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_15_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_15_NO.Text = "15";
            this.L_P1_15_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_15_NO.WordWrap = false;
            // 
            // C_P1_15_ITEMCD
            // 
            this.C_P1_15_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_15_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_15_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_15_ITEMCD.CanGrow = false;
            this.C_P1_15_ITEMCD.Dpi = 100F;
            this.C_P1_15_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 638F);
            this.C_P1_15_ITEMCD.Multiline = true;
            this.C_P1_15_ITEMCD.Name = "C_P1_15_ITEMCD";
            this.C_P1_15_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_15_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_15_ITEMCD.Text = "";
            this.C_P1_15_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_15_ITEMCD.WordWrap = false;
            // 
            // C_P1_15_ITEMNM
            // 
            this.C_P1_15_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_15_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_15_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_15_ITEMNM.CanGrow = false;
            this.C_P1_15_ITEMNM.Dpi = 100F;
            this.C_P1_15_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 638F);
            this.C_P1_15_ITEMNM.Multiline = true;
            this.C_P1_15_ITEMNM.Name = "C_P1_15_ITEMNM";
            this.C_P1_15_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_15_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_15_ITEMNM.Text = "";
            this.C_P1_15_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_15_ITEMNM.WordWrap = false;
            // 
            // C_P1_15_BADCONT
            // 
            this.C_P1_15_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_15_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_15_BADCONT.BorderWidth = 0.5F;
            this.C_P1_15_BADCONT.CanGrow = false;
            this.C_P1_15_BADCONT.Dpi = 100F;
            this.C_P1_15_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 638F);
            this.C_P1_15_BADCONT.Multiline = true;
            this.C_P1_15_BADCONT.Name = "C_P1_15_BADCONT";
            this.C_P1_15_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_15_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_15_BADCONT.Text = "";
            this.C_P1_15_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_15_BADCONT.WordWrap = false;
            // 
            // C_P1_15_QTY
            // 
            this.C_P1_15_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_15_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_15_QTY.BorderWidth = 0.5F;
            this.C_P1_15_QTY.CanGrow = false;
            this.C_P1_15_QTY.Dpi = 100F;
            this.C_P1_15_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 638F);
            this.C_P1_15_QTY.Multiline = true;
            this.C_P1_15_QTY.Name = "C_P1_15_QTY";
            this.C_P1_15_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_15_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_15_QTY.Text = "";
            this.C_P1_15_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_15_QTY.WordWrap = false;
            // 
            // C_P1_15_AMT
            // 
            this.C_P1_15_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_15_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_15_AMT.BorderWidth = 0.5F;
            this.C_P1_15_AMT.CanGrow = false;
            this.C_P1_15_AMT.Dpi = 100F;
            this.C_P1_15_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 638F);
            this.C_P1_15_AMT.Multiline = true;
            this.C_P1_15_AMT.Name = "C_P1_15_AMT";
            this.C_P1_15_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_15_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_15_AMT.Text = "";
            this.C_P1_15_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_15_AMT.WordWrap = false;
            // 
            // L_P1_16_NO
            // 
            this.L_P1_16_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_16_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_16_NO.BorderWidth = 0.5F;
            this.L_P1_16_NO.CanGrow = false;
            this.L_P1_16_NO.Dpi = 100F;
            this.L_P1_16_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 656F);
            this.L_P1_16_NO.Multiline = true;
            this.L_P1_16_NO.Name = "L_P1_16_NO";
            this.L_P1_16_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_16_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_16_NO.Text = "16";
            this.L_P1_16_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_16_NO.WordWrap = false;
            // 
            // C_P1_16_ITEMCD
            // 
            this.C_P1_16_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_16_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_16_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_16_ITEMCD.CanGrow = false;
            this.C_P1_16_ITEMCD.Dpi = 100F;
            this.C_P1_16_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 656F);
            this.C_P1_16_ITEMCD.Multiline = true;
            this.C_P1_16_ITEMCD.Name = "C_P1_16_ITEMCD";
            this.C_P1_16_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_16_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_16_ITEMCD.Text = "";
            this.C_P1_16_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_16_ITEMCD.WordWrap = false;
            // 
            // C_P1_16_ITEMNM
            // 
            this.C_P1_16_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_16_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_16_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_16_ITEMNM.CanGrow = false;
            this.C_P1_16_ITEMNM.Dpi = 100F;
            this.C_P1_16_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 656F);
            this.C_P1_16_ITEMNM.Multiline = true;
            this.C_P1_16_ITEMNM.Name = "C_P1_16_ITEMNM";
            this.C_P1_16_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_16_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_16_ITEMNM.Text = "";
            this.C_P1_16_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_16_ITEMNM.WordWrap = false;
            // 
            // C_P1_16_BADCONT
            // 
            this.C_P1_16_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_16_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_16_BADCONT.BorderWidth = 0.5F;
            this.C_P1_16_BADCONT.CanGrow = false;
            this.C_P1_16_BADCONT.Dpi = 100F;
            this.C_P1_16_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 656F);
            this.C_P1_16_BADCONT.Multiline = true;
            this.C_P1_16_BADCONT.Name = "C_P1_16_BADCONT";
            this.C_P1_16_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_16_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_16_BADCONT.Text = "";
            this.C_P1_16_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_16_BADCONT.WordWrap = false;
            // 
            // C_P1_16_QTY
            // 
            this.C_P1_16_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_16_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_16_QTY.BorderWidth = 0.5F;
            this.C_P1_16_QTY.CanGrow = false;
            this.C_P1_16_QTY.Dpi = 100F;
            this.C_P1_16_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 656F);
            this.C_P1_16_QTY.Multiline = true;
            this.C_P1_16_QTY.Name = "C_P1_16_QTY";
            this.C_P1_16_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_16_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_16_QTY.Text = "";
            this.C_P1_16_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_16_QTY.WordWrap = false;
            // 
            // C_P1_16_AMT
            // 
            this.C_P1_16_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_16_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_16_AMT.BorderWidth = 0.5F;
            this.C_P1_16_AMT.CanGrow = false;
            this.C_P1_16_AMT.Dpi = 100F;
            this.C_P1_16_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 656F);
            this.C_P1_16_AMT.Multiline = true;
            this.C_P1_16_AMT.Name = "C_P1_16_AMT";
            this.C_P1_16_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_16_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_16_AMT.Text = "";
            this.C_P1_16_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_16_AMT.WordWrap = false;
            // 
            // L_P1_17_NO
            // 
            this.L_P1_17_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_17_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_17_NO.BorderWidth = 0.5F;
            this.L_P1_17_NO.CanGrow = false;
            this.L_P1_17_NO.Dpi = 100F;
            this.L_P1_17_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 674F);
            this.L_P1_17_NO.Multiline = true;
            this.L_P1_17_NO.Name = "L_P1_17_NO";
            this.L_P1_17_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_17_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_17_NO.Text = "17";
            this.L_P1_17_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_17_NO.WordWrap = false;
            // 
            // C_P1_17_ITEMCD
            // 
            this.C_P1_17_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P1_17_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_17_ITEMCD.BorderWidth = 0.5F;
            this.C_P1_17_ITEMCD.CanGrow = false;
            this.C_P1_17_ITEMCD.Dpi = 100F;
            this.C_P1_17_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 674F);
            this.C_P1_17_ITEMCD.Multiline = true;
            this.C_P1_17_ITEMCD.Name = "C_P1_17_ITEMCD";
            this.C_P1_17_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_17_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.C_P1_17_ITEMCD.Text = "";
            this.C_P1_17_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_17_ITEMCD.WordWrap = false;
            // 
            // C_P1_17_ITEMNM
            // 
            this.C_P1_17_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P1_17_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_17_ITEMNM.BorderWidth = 0.5F;
            this.C_P1_17_ITEMNM.CanGrow = false;
            this.C_P1_17_ITEMNM.Dpi = 100F;
            this.C_P1_17_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 674F);
            this.C_P1_17_ITEMNM.Multiline = true;
            this.C_P1_17_ITEMNM.Name = "C_P1_17_ITEMNM";
            this.C_P1_17_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_17_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_P1_17_ITEMNM.Text = "";
            this.C_P1_17_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_17_ITEMNM.WordWrap = false;
            // 
            // C_P1_17_BADCONT
            // 
            this.C_P1_17_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_17_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_17_BADCONT.BorderWidth = 0.5F;
            this.C_P1_17_BADCONT.CanGrow = false;
            this.C_P1_17_BADCONT.Dpi = 100F;
            this.C_P1_17_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(355F, 674F);
            this.C_P1_17_BADCONT.Multiline = true;
            this.C_P1_17_BADCONT.Name = "C_P1_17_BADCONT";
            this.C_P1_17_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_17_BADCONT.SizeF = new System.Drawing.SizeF(230F, 18F);
            this.C_P1_17_BADCONT.Text = "";
            this.C_P1_17_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P1_17_BADCONT.WordWrap = false;
            // 
            // C_P1_17_QTY
            // 
            this.C_P1_17_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_17_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_17_QTY.BorderWidth = 0.5F;
            this.C_P1_17_QTY.CanGrow = false;
            this.C_P1_17_QTY.Dpi = 100F;
            this.C_P1_17_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 674F);
            this.C_P1_17_QTY.Multiline = true;
            this.C_P1_17_QTY.Name = "C_P1_17_QTY";
            this.C_P1_17_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_17_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_17_QTY.Text = "";
            this.C_P1_17_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_17_QTY.WordWrap = false;
            // 
            // C_P1_17_AMT
            // 
            this.C_P1_17_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_17_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_17_AMT.BorderWidth = 0.5F;
            this.C_P1_17_AMT.CanGrow = false;
            this.C_P1_17_AMT.Dpi = 100F;
            this.C_P1_17_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 674F);
            this.C_P1_17_AMT.Multiline = true;
            this.C_P1_17_AMT.Name = "C_P1_17_AMT";
            this.C_P1_17_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_17_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_17_AMT.Text = "";
            this.C_P1_17_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_17_AMT.WordWrap = false;
            // 
            // L_P1_SUM
            // 
            this.L_P1_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_SUM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_SUM.BorderWidth = 0.5F;
            this.L_P1_SUM.CanGrow = false;
            this.L_P1_SUM.Dpi = 100F;
            this.L_P1_SUM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_P1_SUM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 692F);
            this.L_P1_SUM.Multiline = true;
            this.L_P1_SUM.Name = "L_P1_SUM";
            this.L_P1_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SUM.SizeF = new System.Drawing.SizeF(585F, 18F);
            this.L_P1_SUM.Text = "합계";
            this.L_P1_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_SUM.WordWrap = false;
            // 
            // C_P1_SUM_QTY
            // 
            this.C_P1_SUM_QTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.C_P1_SUM_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P1_SUM_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_SUM_QTY.BorderWidth = 0.5F;
            this.C_P1_SUM_QTY.CanGrow = false;
            this.C_P1_SUM_QTY.Dpi = 100F;
            this.C_P1_SUM_QTY.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_P1_SUM_QTY.LocationFloat = new DevExpress.Utils.PointFloat(585F, 692F);
            this.C_P1_SUM_QTY.Multiline = true;
            this.C_P1_SUM_QTY.Name = "C_P1_SUM_QTY";
            this.C_P1_SUM_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_SUM_QTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P1_SUM_QTY.Text = "";
            this.C_P1_SUM_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_SUM_QTY.WordWrap = false;
            // 
            // C_P1_SUM_AMT
            // 
            this.C_P1_SUM_AMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.C_P1_SUM_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P1_SUM_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P1_SUM_AMT.BorderWidth = 0.5F;
            this.C_P1_SUM_AMT.CanGrow = false;
            this.C_P1_SUM_AMT.Dpi = 100F;
            this.C_P1_SUM_AMT.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.C_P1_SUM_AMT.LocationFloat = new DevExpress.Utils.PointFloat(657F, 692F);
            this.C_P1_SUM_AMT.Multiline = true;
            this.C_P1_SUM_AMT.Name = "C_P1_SUM_AMT";
            this.C_P1_SUM_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_P1_SUM_AMT.SizeF = new System.Drawing.SizeF(110F, 18F);
            this.C_P1_SUM_AMT.Text = "";
            this.C_P1_SUM_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P1_SUM_AMT.WordWrap = false;
            // 
            // L_P1_SEC2
            // 
            this.L_P1_SEC2.CanGrow = false;
            this.L_P1_SEC2.Dpi = 100F;
            this.L_P1_SEC2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.L_P1_SEC2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 725F);
            this.L_P1_SEC2.Multiline = true;
            this.L_P1_SEC2.Name = "L_P1_SEC2";
            this.L_P1_SEC2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SEC2.SizeF = new System.Drawing.SizeF(767F, 18F);
            this.L_P1_SEC2.Text = "2) 이의신청 상세 내역 및 확정 내역";
            this.L_P1_SEC2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_SEC2.WordWrap = false;
            // 
            // L_P1_O_H_NO
            // 
            this.L_P1_O_H_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_NO.BorderWidth = 0.5F;
            this.L_P1_O_H_NO.CanGrow = false;
            this.L_P1_O_H_NO.Dpi = 100F;
            this.L_P1_O_H_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 745F);
            this.L_P1_O_H_NO.Multiline = true;
            this.L_P1_O_H_NO.Name = "L_P1_O_H_NO";
            this.L_P1_O_H_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_NO.SizeF = new System.Drawing.SizeF(35F, 36F);
            this.L_P1_O_H_NO.Text = "NO";
            this.L_P1_O_H_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_NO.WordWrap = false;
            // 
            // L_P1_O_H_ITEMCD
            // 
            this.L_P1_O_H_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_H_ITEMCD.CanGrow = false;
            this.L_P1_O_H_ITEMCD.Dpi = 100F;
            this.L_P1_O_H_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 745F);
            this.L_P1_O_H_ITEMCD.Multiline = true;
            this.L_P1_O_H_ITEMCD.Name = "L_P1_O_H_ITEMCD";
            this.L_P1_O_H_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 36F);
            this.L_P1_O_H_ITEMCD.Text = "발생품번";
            this.L_P1_O_H_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_H_ITEMNM
            // 
            this.L_P1_O_H_ITEMNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_H_ITEMNM.CanGrow = false;
            this.L_P1_O_H_ITEMNM.Dpi = 100F;
            this.L_P1_O_H_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 745F);
            this.L_P1_O_H_ITEMNM.Multiline = true;
            this.L_P1_O_H_ITEMNM.Name = "L_P1_O_H_ITEMNM";
            this.L_P1_O_H_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 36F);
            this.L_P1_O_H_ITEMNM.Text = "발생품명";
            this.L_P1_O_H_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_H_OBJ
            // 
            this.L_P1_O_H_OBJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_OBJ.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_OBJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_OBJ.BorderWidth = 0.5F;
            this.L_P1_O_H_OBJ.CanGrow = false;
            this.L_P1_O_H_OBJ.Dpi = 100F;
            this.L_P1_O_H_OBJ.LocationFloat = new DevExpress.Utils.PointFloat(355F, 745F);
            this.L_P1_O_H_OBJ.Multiline = true;
            this.L_P1_O_H_OBJ.Name = "L_P1_O_H_OBJ";
            this.L_P1_O_H_OBJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_OBJ.SizeF = new System.Drawing.SizeF(206F, 18F);
            this.L_P1_O_H_OBJ.Text = "이의제기";
            this.L_P1_O_H_OBJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_OBJ.WordWrap = false;
            // 
            // L_P1_O_H_OBJQTY
            // 
            this.L_P1_O_H_OBJQTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_H_OBJQTY.CanGrow = false;
            this.L_P1_O_H_OBJQTY.Dpi = 100F;
            this.L_P1_O_H_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 763F);
            this.L_P1_O_H_OBJQTY.Multiline = true;
            this.L_P1_O_H_OBJQTY.Name = "L_P1_O_H_OBJQTY";
            this.L_P1_O_H_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_H_OBJQTY.Text = "수량(EA)";
            this.L_P1_O_H_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_H_OBJAMT
            // 
            this.L_P1_O_H_OBJAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_H_OBJAMT.CanGrow = false;
            this.L_P1_O_H_OBJAMT.Dpi = 100F;
            this.L_P1_O_H_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 763F);
            this.L_P1_O_H_OBJAMT.Multiline = true;
            this.L_P1_O_H_OBJAMT.Name = "L_P1_O_H_OBJAMT";
            this.L_P1_O_H_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_H_OBJAMT.Text = "합계금액(원)";
            this.L_P1_O_H_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_H_CONF
            // 
            this.L_P1_O_H_CONF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_CONF.BorderWidth = 0.5F;
            this.L_P1_O_H_CONF.CanGrow = false;
            this.L_P1_O_H_CONF.Dpi = 100F;
            this.L_P1_O_H_CONF.LocationFloat = new DevExpress.Utils.PointFloat(561F, 745F);
            this.L_P1_O_H_CONF.Multiline = true;
            this.L_P1_O_H_CONF.Name = "L_P1_O_H_CONF";
            this.L_P1_O_H_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_CONF.SizeF = new System.Drawing.SizeF(206F, 18F);
            this.L_P1_O_H_CONF.Text = "확정 비용";
            this.L_P1_O_H_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_CONF.WordWrap = false;
            // 
            // L_P1_O_H_CONFQTY
            // 
            this.L_P1_O_H_CONFQTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_H_CONFQTY.CanGrow = false;
            this.L_P1_O_H_CONFQTY.Dpi = 100F;
            this.L_P1_O_H_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 763F);
            this.L_P1_O_H_CONFQTY.Multiline = true;
            this.L_P1_O_H_CONFQTY.Name = "L_P1_O_H_CONFQTY";
            this.L_P1_O_H_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_H_CONFQTY.Text = "수량(EA)";
            this.L_P1_O_H_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_H_CONFAMT
            // 
            this.L_P1_O_H_CONFAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_H_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_H_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_H_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_H_CONFAMT.CanGrow = false;
            this.L_P1_O_H_CONFAMT.Dpi = 100F;
            this.L_P1_O_H_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 763F);
            this.L_P1_O_H_CONFAMT.Multiline = true;
            this.L_P1_O_H_CONFAMT.Name = "L_P1_O_H_CONFAMT";
            this.L_P1_O_H_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_H_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_H_CONFAMT.Text = "합계금액(원)";
            this.L_P1_O_H_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_H_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_1_NO
            // 
            this.L_P1_O_1_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_1_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_1_NO.BorderWidth = 0.5F;
            this.L_P1_O_1_NO.CanGrow = false;
            this.L_P1_O_1_NO.Dpi = 100F;
            this.L_P1_O_1_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 781F);
            this.L_P1_O_1_NO.Multiline = true;
            this.L_P1_O_1_NO.Name = "L_P1_O_1_NO";
            this.L_P1_O_1_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_1_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_1_NO.Text = "";
            this.L_P1_O_1_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_1_NO.WordWrap = false;
            // 
            // L_P1_O_1_ITEMCD
            // 
            this.L_P1_O_1_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_1_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_1_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_1_ITEMCD.CanGrow = false;
            this.L_P1_O_1_ITEMCD.Dpi = 100F;
            this.L_P1_O_1_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 781F);
            this.L_P1_O_1_ITEMCD.Multiline = true;
            this.L_P1_O_1_ITEMCD.Name = "L_P1_O_1_ITEMCD";
            this.L_P1_O_1_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_1_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_1_ITEMCD.Text = "";
            this.L_P1_O_1_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_1_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_1_ITEMNM
            // 
            this.L_P1_O_1_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_1_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_1_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_1_ITEMNM.CanGrow = false;
            this.L_P1_O_1_ITEMNM.Dpi = 100F;
            this.L_P1_O_1_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 781F);
            this.L_P1_O_1_ITEMNM.Multiline = true;
            this.L_P1_O_1_ITEMNM.Name = "L_P1_O_1_ITEMNM";
            this.L_P1_O_1_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_1_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_1_ITEMNM.Text = "";
            this.L_P1_O_1_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_1_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_1_OBJQTY
            // 
            this.L_P1_O_1_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_1_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_1_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_1_OBJQTY.CanGrow = false;
            this.L_P1_O_1_OBJQTY.Dpi = 100F;
            this.L_P1_O_1_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 781F);
            this.L_P1_O_1_OBJQTY.Multiline = true;
            this.L_P1_O_1_OBJQTY.Name = "L_P1_O_1_OBJQTY";
            this.L_P1_O_1_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_1_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_1_OBJQTY.Text = "";
            this.L_P1_O_1_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_1_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_1_OBJAMT
            // 
            this.L_P1_O_1_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_1_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_1_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_1_OBJAMT.CanGrow = false;
            this.L_P1_O_1_OBJAMT.Dpi = 100F;
            this.L_P1_O_1_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 781F);
            this.L_P1_O_1_OBJAMT.Multiline = true;
            this.L_P1_O_1_OBJAMT.Name = "L_P1_O_1_OBJAMT";
            this.L_P1_O_1_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_1_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_1_OBJAMT.Text = "";
            this.L_P1_O_1_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_1_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_1_CONFQTY
            // 
            this.L_P1_O_1_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_1_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_1_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_1_CONFQTY.CanGrow = false;
            this.L_P1_O_1_CONFQTY.Dpi = 100F;
            this.L_P1_O_1_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 781F);
            this.L_P1_O_1_CONFQTY.Multiline = true;
            this.L_P1_O_1_CONFQTY.Name = "L_P1_O_1_CONFQTY";
            this.L_P1_O_1_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_1_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_1_CONFQTY.Text = "";
            this.L_P1_O_1_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_1_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_1_CONFAMT
            // 
            this.L_P1_O_1_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_1_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_1_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_1_CONFAMT.CanGrow = false;
            this.L_P1_O_1_CONFAMT.Dpi = 100F;
            this.L_P1_O_1_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 781F);
            this.L_P1_O_1_CONFAMT.Multiline = true;
            this.L_P1_O_1_CONFAMT.Name = "L_P1_O_1_CONFAMT";
            this.L_P1_O_1_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_1_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_1_CONFAMT.Text = "";
            this.L_P1_O_1_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_1_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_2_NO
            // 
            this.L_P1_O_2_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_2_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_2_NO.BorderWidth = 0.5F;
            this.L_P1_O_2_NO.CanGrow = false;
            this.L_P1_O_2_NO.Dpi = 100F;
            this.L_P1_O_2_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 799F);
            this.L_P1_O_2_NO.Multiline = true;
            this.L_P1_O_2_NO.Name = "L_P1_O_2_NO";
            this.L_P1_O_2_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_2_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_2_NO.Text = "";
            this.L_P1_O_2_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_2_NO.WordWrap = false;
            // 
            // L_P1_O_2_ITEMCD
            // 
            this.L_P1_O_2_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_2_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_2_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_2_ITEMCD.CanGrow = false;
            this.L_P1_O_2_ITEMCD.Dpi = 100F;
            this.L_P1_O_2_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 799F);
            this.L_P1_O_2_ITEMCD.Multiline = true;
            this.L_P1_O_2_ITEMCD.Name = "L_P1_O_2_ITEMCD";
            this.L_P1_O_2_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_2_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_2_ITEMCD.Text = "";
            this.L_P1_O_2_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_2_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_2_ITEMNM
            // 
            this.L_P1_O_2_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_2_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_2_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_2_ITEMNM.CanGrow = false;
            this.L_P1_O_2_ITEMNM.Dpi = 100F;
            this.L_P1_O_2_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 799F);
            this.L_P1_O_2_ITEMNM.Multiline = true;
            this.L_P1_O_2_ITEMNM.Name = "L_P1_O_2_ITEMNM";
            this.L_P1_O_2_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_2_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_2_ITEMNM.Text = "";
            this.L_P1_O_2_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_2_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_2_OBJQTY
            // 
            this.L_P1_O_2_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_2_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_2_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_2_OBJQTY.CanGrow = false;
            this.L_P1_O_2_OBJQTY.Dpi = 100F;
            this.L_P1_O_2_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 799F);
            this.L_P1_O_2_OBJQTY.Multiline = true;
            this.L_P1_O_2_OBJQTY.Name = "L_P1_O_2_OBJQTY";
            this.L_P1_O_2_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_2_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_2_OBJQTY.Text = "";
            this.L_P1_O_2_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_2_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_2_OBJAMT
            // 
            this.L_P1_O_2_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_2_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_2_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_2_OBJAMT.CanGrow = false;
            this.L_P1_O_2_OBJAMT.Dpi = 100F;
            this.L_P1_O_2_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 799F);
            this.L_P1_O_2_OBJAMT.Multiline = true;
            this.L_P1_O_2_OBJAMT.Name = "L_P1_O_2_OBJAMT";
            this.L_P1_O_2_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_2_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_2_OBJAMT.Text = "";
            this.L_P1_O_2_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_2_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_2_CONFQTY
            // 
            this.L_P1_O_2_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_2_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_2_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_2_CONFQTY.CanGrow = false;
            this.L_P1_O_2_CONFQTY.Dpi = 100F;
            this.L_P1_O_2_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 799F);
            this.L_P1_O_2_CONFQTY.Multiline = true;
            this.L_P1_O_2_CONFQTY.Name = "L_P1_O_2_CONFQTY";
            this.L_P1_O_2_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_2_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_2_CONFQTY.Text = "";
            this.L_P1_O_2_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_2_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_2_CONFAMT
            // 
            this.L_P1_O_2_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_2_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_2_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_2_CONFAMT.CanGrow = false;
            this.L_P1_O_2_CONFAMT.Dpi = 100F;
            this.L_P1_O_2_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 799F);
            this.L_P1_O_2_CONFAMT.Multiline = true;
            this.L_P1_O_2_CONFAMT.Name = "L_P1_O_2_CONFAMT";
            this.L_P1_O_2_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_2_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_2_CONFAMT.Text = "";
            this.L_P1_O_2_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_2_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_3_NO
            // 
            this.L_P1_O_3_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_3_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_3_NO.BorderWidth = 0.5F;
            this.L_P1_O_3_NO.CanGrow = false;
            this.L_P1_O_3_NO.Dpi = 100F;
            this.L_P1_O_3_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 817F);
            this.L_P1_O_3_NO.Multiline = true;
            this.L_P1_O_3_NO.Name = "L_P1_O_3_NO";
            this.L_P1_O_3_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_3_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_3_NO.Text = "";
            this.L_P1_O_3_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_3_NO.WordWrap = false;
            // 
            // L_P1_O_3_ITEMCD
            // 
            this.L_P1_O_3_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_3_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_3_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_3_ITEMCD.CanGrow = false;
            this.L_P1_O_3_ITEMCD.Dpi = 100F;
            this.L_P1_O_3_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 817F);
            this.L_P1_O_3_ITEMCD.Multiline = true;
            this.L_P1_O_3_ITEMCD.Name = "L_P1_O_3_ITEMCD";
            this.L_P1_O_3_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_3_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_3_ITEMCD.Text = "";
            this.L_P1_O_3_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_3_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_3_ITEMNM
            // 
            this.L_P1_O_3_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_3_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_3_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_3_ITEMNM.CanGrow = false;
            this.L_P1_O_3_ITEMNM.Dpi = 100F;
            this.L_P1_O_3_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 817F);
            this.L_P1_O_3_ITEMNM.Multiline = true;
            this.L_P1_O_3_ITEMNM.Name = "L_P1_O_3_ITEMNM";
            this.L_P1_O_3_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_3_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_3_ITEMNM.Text = "";
            this.L_P1_O_3_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_3_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_3_OBJQTY
            // 
            this.L_P1_O_3_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_3_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_3_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_3_OBJQTY.CanGrow = false;
            this.L_P1_O_3_OBJQTY.Dpi = 100F;
            this.L_P1_O_3_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 817F);
            this.L_P1_O_3_OBJQTY.Multiline = true;
            this.L_P1_O_3_OBJQTY.Name = "L_P1_O_3_OBJQTY";
            this.L_P1_O_3_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_3_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_3_OBJQTY.Text = "";
            this.L_P1_O_3_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_3_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_3_OBJAMT
            // 
            this.L_P1_O_3_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_3_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_3_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_3_OBJAMT.CanGrow = false;
            this.L_P1_O_3_OBJAMT.Dpi = 100F;
            this.L_P1_O_3_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 817F);
            this.L_P1_O_3_OBJAMT.Multiline = true;
            this.L_P1_O_3_OBJAMT.Name = "L_P1_O_3_OBJAMT";
            this.L_P1_O_3_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_3_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_3_OBJAMT.Text = "";
            this.L_P1_O_3_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_3_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_3_CONFQTY
            // 
            this.L_P1_O_3_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_3_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_3_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_3_CONFQTY.CanGrow = false;
            this.L_P1_O_3_CONFQTY.Dpi = 100F;
            this.L_P1_O_3_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 817F);
            this.L_P1_O_3_CONFQTY.Multiline = true;
            this.L_P1_O_3_CONFQTY.Name = "L_P1_O_3_CONFQTY";
            this.L_P1_O_3_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_3_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_3_CONFQTY.Text = "";
            this.L_P1_O_3_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_3_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_3_CONFAMT
            // 
            this.L_P1_O_3_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_3_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_3_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_3_CONFAMT.CanGrow = false;
            this.L_P1_O_3_CONFAMT.Dpi = 100F;
            this.L_P1_O_3_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 817F);
            this.L_P1_O_3_CONFAMT.Multiline = true;
            this.L_P1_O_3_CONFAMT.Name = "L_P1_O_3_CONFAMT";
            this.L_P1_O_3_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_3_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_3_CONFAMT.Text = "";
            this.L_P1_O_3_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_3_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_4_NO
            // 
            this.L_P1_O_4_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_4_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_4_NO.BorderWidth = 0.5F;
            this.L_P1_O_4_NO.CanGrow = false;
            this.L_P1_O_4_NO.Dpi = 100F;
            this.L_P1_O_4_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 835F);
            this.L_P1_O_4_NO.Multiline = true;
            this.L_P1_O_4_NO.Name = "L_P1_O_4_NO";
            this.L_P1_O_4_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_4_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_4_NO.Text = "";
            this.L_P1_O_4_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_4_NO.WordWrap = false;
            // 
            // L_P1_O_4_ITEMCD
            // 
            this.L_P1_O_4_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_4_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_4_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_4_ITEMCD.CanGrow = false;
            this.L_P1_O_4_ITEMCD.Dpi = 100F;
            this.L_P1_O_4_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 835F);
            this.L_P1_O_4_ITEMCD.Multiline = true;
            this.L_P1_O_4_ITEMCD.Name = "L_P1_O_4_ITEMCD";
            this.L_P1_O_4_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_4_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_4_ITEMCD.Text = "";
            this.L_P1_O_4_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_4_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_4_ITEMNM
            // 
            this.L_P1_O_4_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_4_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_4_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_4_ITEMNM.CanGrow = false;
            this.L_P1_O_4_ITEMNM.Dpi = 100F;
            this.L_P1_O_4_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 835F);
            this.L_P1_O_4_ITEMNM.Multiline = true;
            this.L_P1_O_4_ITEMNM.Name = "L_P1_O_4_ITEMNM";
            this.L_P1_O_4_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_4_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_4_ITEMNM.Text = "";
            this.L_P1_O_4_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_4_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_4_OBJQTY
            // 
            this.L_P1_O_4_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_4_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_4_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_4_OBJQTY.CanGrow = false;
            this.L_P1_O_4_OBJQTY.Dpi = 100F;
            this.L_P1_O_4_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 835F);
            this.L_P1_O_4_OBJQTY.Multiline = true;
            this.L_P1_O_4_OBJQTY.Name = "L_P1_O_4_OBJQTY";
            this.L_P1_O_4_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_4_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_4_OBJQTY.Text = "";
            this.L_P1_O_4_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_4_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_4_OBJAMT
            // 
            this.L_P1_O_4_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_4_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_4_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_4_OBJAMT.CanGrow = false;
            this.L_P1_O_4_OBJAMT.Dpi = 100F;
            this.L_P1_O_4_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 835F);
            this.L_P1_O_4_OBJAMT.Multiline = true;
            this.L_P1_O_4_OBJAMT.Name = "L_P1_O_4_OBJAMT";
            this.L_P1_O_4_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_4_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_4_OBJAMT.Text = "";
            this.L_P1_O_4_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_4_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_4_CONFQTY
            // 
            this.L_P1_O_4_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_4_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_4_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_4_CONFQTY.CanGrow = false;
            this.L_P1_O_4_CONFQTY.Dpi = 100F;
            this.L_P1_O_4_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 835F);
            this.L_P1_O_4_CONFQTY.Multiline = true;
            this.L_P1_O_4_CONFQTY.Name = "L_P1_O_4_CONFQTY";
            this.L_P1_O_4_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_4_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_4_CONFQTY.Text = "";
            this.L_P1_O_4_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_4_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_4_CONFAMT
            // 
            this.L_P1_O_4_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_4_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_4_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_4_CONFAMT.CanGrow = false;
            this.L_P1_O_4_CONFAMT.Dpi = 100F;
            this.L_P1_O_4_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 835F);
            this.L_P1_O_4_CONFAMT.Multiline = true;
            this.L_P1_O_4_CONFAMT.Name = "L_P1_O_4_CONFAMT";
            this.L_P1_O_4_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_4_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_4_CONFAMT.Text = "";
            this.L_P1_O_4_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_4_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_5_NO
            // 
            this.L_P1_O_5_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_5_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_5_NO.BorderWidth = 0.5F;
            this.L_P1_O_5_NO.CanGrow = false;
            this.L_P1_O_5_NO.Dpi = 100F;
            this.L_P1_O_5_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 853F);
            this.L_P1_O_5_NO.Multiline = true;
            this.L_P1_O_5_NO.Name = "L_P1_O_5_NO";
            this.L_P1_O_5_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_5_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_5_NO.Text = "";
            this.L_P1_O_5_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_5_NO.WordWrap = false;
            // 
            // L_P1_O_5_ITEMCD
            // 
            this.L_P1_O_5_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_5_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_5_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_5_ITEMCD.CanGrow = false;
            this.L_P1_O_5_ITEMCD.Dpi = 100F;
            this.L_P1_O_5_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 853F);
            this.L_P1_O_5_ITEMCD.Multiline = true;
            this.L_P1_O_5_ITEMCD.Name = "L_P1_O_5_ITEMCD";
            this.L_P1_O_5_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_5_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_5_ITEMCD.Text = "";
            this.L_P1_O_5_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_5_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_5_ITEMNM
            // 
            this.L_P1_O_5_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_5_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_5_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_5_ITEMNM.CanGrow = false;
            this.L_P1_O_5_ITEMNM.Dpi = 100F;
            this.L_P1_O_5_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 853F);
            this.L_P1_O_5_ITEMNM.Multiline = true;
            this.L_P1_O_5_ITEMNM.Name = "L_P1_O_5_ITEMNM";
            this.L_P1_O_5_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_5_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_5_ITEMNM.Text = "";
            this.L_P1_O_5_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_5_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_5_OBJQTY
            // 
            this.L_P1_O_5_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_5_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_5_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_5_OBJQTY.CanGrow = false;
            this.L_P1_O_5_OBJQTY.Dpi = 100F;
            this.L_P1_O_5_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 853F);
            this.L_P1_O_5_OBJQTY.Multiline = true;
            this.L_P1_O_5_OBJQTY.Name = "L_P1_O_5_OBJQTY";
            this.L_P1_O_5_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_5_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_5_OBJQTY.Text = "";
            this.L_P1_O_5_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_5_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_5_OBJAMT
            // 
            this.L_P1_O_5_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_5_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_5_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_5_OBJAMT.CanGrow = false;
            this.L_P1_O_5_OBJAMT.Dpi = 100F;
            this.L_P1_O_5_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 853F);
            this.L_P1_O_5_OBJAMT.Multiline = true;
            this.L_P1_O_5_OBJAMT.Name = "L_P1_O_5_OBJAMT";
            this.L_P1_O_5_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_5_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_5_OBJAMT.Text = "";
            this.L_P1_O_5_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_5_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_5_CONFQTY
            // 
            this.L_P1_O_5_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_5_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_5_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_5_CONFQTY.CanGrow = false;
            this.L_P1_O_5_CONFQTY.Dpi = 100F;
            this.L_P1_O_5_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 853F);
            this.L_P1_O_5_CONFQTY.Multiline = true;
            this.L_P1_O_5_CONFQTY.Name = "L_P1_O_5_CONFQTY";
            this.L_P1_O_5_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_5_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_5_CONFQTY.Text = "";
            this.L_P1_O_5_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_5_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_5_CONFAMT
            // 
            this.L_P1_O_5_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_5_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_5_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_5_CONFAMT.CanGrow = false;
            this.L_P1_O_5_CONFAMT.Dpi = 100F;
            this.L_P1_O_5_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 853F);
            this.L_P1_O_5_CONFAMT.Multiline = true;
            this.L_P1_O_5_CONFAMT.Name = "L_P1_O_5_CONFAMT";
            this.L_P1_O_5_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_5_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_5_CONFAMT.Text = "";
            this.L_P1_O_5_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_5_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_6_NO
            // 
            this.L_P1_O_6_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_6_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_6_NO.BorderWidth = 0.5F;
            this.L_P1_O_6_NO.CanGrow = false;
            this.L_P1_O_6_NO.Dpi = 100F;
            this.L_P1_O_6_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 871F);
            this.L_P1_O_6_NO.Multiline = true;
            this.L_P1_O_6_NO.Name = "L_P1_O_6_NO";
            this.L_P1_O_6_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_6_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_6_NO.Text = "";
            this.L_P1_O_6_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_6_NO.WordWrap = false;
            // 
            // L_P1_O_6_ITEMCD
            // 
            this.L_P1_O_6_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_6_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_6_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_6_ITEMCD.CanGrow = false;
            this.L_P1_O_6_ITEMCD.Dpi = 100F;
            this.L_P1_O_6_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 871F);
            this.L_P1_O_6_ITEMCD.Multiline = true;
            this.L_P1_O_6_ITEMCD.Name = "L_P1_O_6_ITEMCD";
            this.L_P1_O_6_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_6_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_6_ITEMCD.Text = "";
            this.L_P1_O_6_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_6_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_6_ITEMNM
            // 
            this.L_P1_O_6_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_6_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_6_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_6_ITEMNM.CanGrow = false;
            this.L_P1_O_6_ITEMNM.Dpi = 100F;
            this.L_P1_O_6_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 871F);
            this.L_P1_O_6_ITEMNM.Multiline = true;
            this.L_P1_O_6_ITEMNM.Name = "L_P1_O_6_ITEMNM";
            this.L_P1_O_6_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_6_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_6_ITEMNM.Text = "";
            this.L_P1_O_6_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_6_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_6_OBJQTY
            // 
            this.L_P1_O_6_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_6_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_6_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_6_OBJQTY.CanGrow = false;
            this.L_P1_O_6_OBJQTY.Dpi = 100F;
            this.L_P1_O_6_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 871F);
            this.L_P1_O_6_OBJQTY.Multiline = true;
            this.L_P1_O_6_OBJQTY.Name = "L_P1_O_6_OBJQTY";
            this.L_P1_O_6_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_6_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_6_OBJQTY.Text = "";
            this.L_P1_O_6_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_6_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_6_OBJAMT
            // 
            this.L_P1_O_6_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_6_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_6_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_6_OBJAMT.CanGrow = false;
            this.L_P1_O_6_OBJAMT.Dpi = 100F;
            this.L_P1_O_6_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 871F);
            this.L_P1_O_6_OBJAMT.Multiline = true;
            this.L_P1_O_6_OBJAMT.Name = "L_P1_O_6_OBJAMT";
            this.L_P1_O_6_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_6_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_6_OBJAMT.Text = "";
            this.L_P1_O_6_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_6_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_6_CONFQTY
            // 
            this.L_P1_O_6_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_6_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_6_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_6_CONFQTY.CanGrow = false;
            this.L_P1_O_6_CONFQTY.Dpi = 100F;
            this.L_P1_O_6_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 871F);
            this.L_P1_O_6_CONFQTY.Multiline = true;
            this.L_P1_O_6_CONFQTY.Name = "L_P1_O_6_CONFQTY";
            this.L_P1_O_6_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_6_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_6_CONFQTY.Text = "";
            this.L_P1_O_6_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_6_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_6_CONFAMT
            // 
            this.L_P1_O_6_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_6_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_6_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_6_CONFAMT.CanGrow = false;
            this.L_P1_O_6_CONFAMT.Dpi = 100F;
            this.L_P1_O_6_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 871F);
            this.L_P1_O_6_CONFAMT.Multiline = true;
            this.L_P1_O_6_CONFAMT.Name = "L_P1_O_6_CONFAMT";
            this.L_P1_O_6_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_6_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_6_CONFAMT.Text = "";
            this.L_P1_O_6_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_6_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_7_NO
            // 
            this.L_P1_O_7_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_7_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_7_NO.BorderWidth = 0.5F;
            this.L_P1_O_7_NO.CanGrow = false;
            this.L_P1_O_7_NO.Dpi = 100F;
            this.L_P1_O_7_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 889F);
            this.L_P1_O_7_NO.Multiline = true;
            this.L_P1_O_7_NO.Name = "L_P1_O_7_NO";
            this.L_P1_O_7_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_7_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_7_NO.Text = "";
            this.L_P1_O_7_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_7_NO.WordWrap = false;
            // 
            // L_P1_O_7_ITEMCD
            // 
            this.L_P1_O_7_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_7_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_7_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_7_ITEMCD.CanGrow = false;
            this.L_P1_O_7_ITEMCD.Dpi = 100F;
            this.L_P1_O_7_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 889F);
            this.L_P1_O_7_ITEMCD.Multiline = true;
            this.L_P1_O_7_ITEMCD.Name = "L_P1_O_7_ITEMCD";
            this.L_P1_O_7_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_7_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_7_ITEMCD.Text = "";
            this.L_P1_O_7_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_7_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_7_ITEMNM
            // 
            this.L_P1_O_7_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_7_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_7_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_7_ITEMNM.CanGrow = false;
            this.L_P1_O_7_ITEMNM.Dpi = 100F;
            this.L_P1_O_7_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 889F);
            this.L_P1_O_7_ITEMNM.Multiline = true;
            this.L_P1_O_7_ITEMNM.Name = "L_P1_O_7_ITEMNM";
            this.L_P1_O_7_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_7_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_7_ITEMNM.Text = "";
            this.L_P1_O_7_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_7_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_7_OBJQTY
            // 
            this.L_P1_O_7_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_7_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_7_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_7_OBJQTY.CanGrow = false;
            this.L_P1_O_7_OBJQTY.Dpi = 100F;
            this.L_P1_O_7_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 889F);
            this.L_P1_O_7_OBJQTY.Multiline = true;
            this.L_P1_O_7_OBJQTY.Name = "L_P1_O_7_OBJQTY";
            this.L_P1_O_7_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_7_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_7_OBJQTY.Text = "";
            this.L_P1_O_7_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_7_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_7_OBJAMT
            // 
            this.L_P1_O_7_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_7_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_7_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_7_OBJAMT.CanGrow = false;
            this.L_P1_O_7_OBJAMT.Dpi = 100F;
            this.L_P1_O_7_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 889F);
            this.L_P1_O_7_OBJAMT.Multiline = true;
            this.L_P1_O_7_OBJAMT.Name = "L_P1_O_7_OBJAMT";
            this.L_P1_O_7_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_7_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_7_OBJAMT.Text = "";
            this.L_P1_O_7_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_7_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_7_CONFQTY
            // 
            this.L_P1_O_7_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_7_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_7_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_7_CONFQTY.CanGrow = false;
            this.L_P1_O_7_CONFQTY.Dpi = 100F;
            this.L_P1_O_7_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 889F);
            this.L_P1_O_7_CONFQTY.Multiline = true;
            this.L_P1_O_7_CONFQTY.Name = "L_P1_O_7_CONFQTY";
            this.L_P1_O_7_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_7_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_7_CONFQTY.Text = "";
            this.L_P1_O_7_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_7_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_7_CONFAMT
            // 
            this.L_P1_O_7_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_7_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_7_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_7_CONFAMT.CanGrow = false;
            this.L_P1_O_7_CONFAMT.Dpi = 100F;
            this.L_P1_O_7_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 889F);
            this.L_P1_O_7_CONFAMT.Multiline = true;
            this.L_P1_O_7_CONFAMT.Name = "L_P1_O_7_CONFAMT";
            this.L_P1_O_7_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_7_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_7_CONFAMT.Text = "";
            this.L_P1_O_7_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_7_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_8_NO
            // 
            this.L_P1_O_8_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_8_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_8_NO.BorderWidth = 0.5F;
            this.L_P1_O_8_NO.CanGrow = false;
            this.L_P1_O_8_NO.Dpi = 100F;
            this.L_P1_O_8_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 907F);
            this.L_P1_O_8_NO.Multiline = true;
            this.L_P1_O_8_NO.Name = "L_P1_O_8_NO";
            this.L_P1_O_8_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_8_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_8_NO.Text = "";
            this.L_P1_O_8_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_8_NO.WordWrap = false;
            // 
            // L_P1_O_8_ITEMCD
            // 
            this.L_P1_O_8_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_8_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_8_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_8_ITEMCD.CanGrow = false;
            this.L_P1_O_8_ITEMCD.Dpi = 100F;
            this.L_P1_O_8_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 907F);
            this.L_P1_O_8_ITEMCD.Multiline = true;
            this.L_P1_O_8_ITEMCD.Name = "L_P1_O_8_ITEMCD";
            this.L_P1_O_8_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_8_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_8_ITEMCD.Text = "";
            this.L_P1_O_8_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_8_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_8_ITEMNM
            // 
            this.L_P1_O_8_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_8_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_8_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_8_ITEMNM.CanGrow = false;
            this.L_P1_O_8_ITEMNM.Dpi = 100F;
            this.L_P1_O_8_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 907F);
            this.L_P1_O_8_ITEMNM.Multiline = true;
            this.L_P1_O_8_ITEMNM.Name = "L_P1_O_8_ITEMNM";
            this.L_P1_O_8_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_8_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_8_ITEMNM.Text = "";
            this.L_P1_O_8_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_8_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_8_OBJQTY
            // 
            this.L_P1_O_8_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_8_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_8_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_8_OBJQTY.CanGrow = false;
            this.L_P1_O_8_OBJQTY.Dpi = 100F;
            this.L_P1_O_8_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 907F);
            this.L_P1_O_8_OBJQTY.Multiline = true;
            this.L_P1_O_8_OBJQTY.Name = "L_P1_O_8_OBJQTY";
            this.L_P1_O_8_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_8_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_8_OBJQTY.Text = "";
            this.L_P1_O_8_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_8_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_8_OBJAMT
            // 
            this.L_P1_O_8_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_8_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_8_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_8_OBJAMT.CanGrow = false;
            this.L_P1_O_8_OBJAMT.Dpi = 100F;
            this.L_P1_O_8_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 907F);
            this.L_P1_O_8_OBJAMT.Multiline = true;
            this.L_P1_O_8_OBJAMT.Name = "L_P1_O_8_OBJAMT";
            this.L_P1_O_8_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_8_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_8_OBJAMT.Text = "";
            this.L_P1_O_8_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_8_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_8_CONFQTY
            // 
            this.L_P1_O_8_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_8_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_8_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_8_CONFQTY.CanGrow = false;
            this.L_P1_O_8_CONFQTY.Dpi = 100F;
            this.L_P1_O_8_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 907F);
            this.L_P1_O_8_CONFQTY.Multiline = true;
            this.L_P1_O_8_CONFQTY.Name = "L_P1_O_8_CONFQTY";
            this.L_P1_O_8_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_8_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_8_CONFQTY.Text = "";
            this.L_P1_O_8_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_8_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_8_CONFAMT
            // 
            this.L_P1_O_8_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_8_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_8_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_8_CONFAMT.CanGrow = false;
            this.L_P1_O_8_CONFAMT.Dpi = 100F;
            this.L_P1_O_8_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 907F);
            this.L_P1_O_8_CONFAMT.Multiline = true;
            this.L_P1_O_8_CONFAMT.Name = "L_P1_O_8_CONFAMT";
            this.L_P1_O_8_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_8_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_8_CONFAMT.Text = "";
            this.L_P1_O_8_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_8_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_9_NO
            // 
            this.L_P1_O_9_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_9_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_9_NO.BorderWidth = 0.5F;
            this.L_P1_O_9_NO.CanGrow = false;
            this.L_P1_O_9_NO.Dpi = 100F;
            this.L_P1_O_9_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 925F);
            this.L_P1_O_9_NO.Multiline = true;
            this.L_P1_O_9_NO.Name = "L_P1_O_9_NO";
            this.L_P1_O_9_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_9_NO.SizeF = new System.Drawing.SizeF(35F, 18F);
            this.L_P1_O_9_NO.Text = "";
            this.L_P1_O_9_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_9_NO.WordWrap = false;
            // 
            // L_P1_O_9_ITEMCD
            // 
            this.L_P1_O_9_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_9_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_9_ITEMCD.BorderWidth = 0.5F;
            this.L_P1_O_9_ITEMCD.CanGrow = false;
            this.L_P1_O_9_ITEMCD.Dpi = 100F;
            this.L_P1_O_9_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(35F, 925F);
            this.L_P1_O_9_ITEMCD.Multiline = true;
            this.L_P1_O_9_ITEMCD.Name = "L_P1_O_9_ITEMCD";
            this.L_P1_O_9_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_9_ITEMCD.SizeF = new System.Drawing.SizeF(120F, 18F);
            this.L_P1_O_9_ITEMCD.Text = "";
            this.L_P1_O_9_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_9_ITEMCD.WordWrap = false;
            // 
            // L_P1_O_9_ITEMNM
            // 
            this.L_P1_O_9_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_9_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_9_ITEMNM.BorderWidth = 0.5F;
            this.L_P1_O_9_ITEMNM.CanGrow = false;
            this.L_P1_O_9_ITEMNM.Dpi = 100F;
            this.L_P1_O_9_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(155F, 925F);
            this.L_P1_O_9_ITEMNM.Multiline = true;
            this.L_P1_O_9_ITEMNM.Name = "L_P1_O_9_ITEMNM";
            this.L_P1_O_9_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_9_ITEMNM.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.L_P1_O_9_ITEMNM.Text = "";
            this.L_P1_O_9_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_9_ITEMNM.WordWrap = false;
            // 
            // L_P1_O_9_OBJQTY
            // 
            this.L_P1_O_9_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_9_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_9_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_9_OBJQTY.CanGrow = false;
            this.L_P1_O_9_OBJQTY.Dpi = 100F;
            this.L_P1_O_9_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 925F);
            this.L_P1_O_9_OBJQTY.Multiline = true;
            this.L_P1_O_9_OBJQTY.Name = "L_P1_O_9_OBJQTY";
            this.L_P1_O_9_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_9_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_9_OBJQTY.Text = "";
            this.L_P1_O_9_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_9_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_9_OBJAMT
            // 
            this.L_P1_O_9_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_9_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_9_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_9_OBJAMT.CanGrow = false;
            this.L_P1_O_9_OBJAMT.Dpi = 100F;
            this.L_P1_O_9_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 925F);
            this.L_P1_O_9_OBJAMT.Multiline = true;
            this.L_P1_O_9_OBJAMT.Name = "L_P1_O_9_OBJAMT";
            this.L_P1_O_9_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_9_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_9_OBJAMT.Text = "";
            this.L_P1_O_9_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_9_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_9_CONFQTY
            // 
            this.L_P1_O_9_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_9_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_9_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_9_CONFQTY.CanGrow = false;
            this.L_P1_O_9_CONFQTY.Dpi = 100F;
            this.L_P1_O_9_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 925F);
            this.L_P1_O_9_CONFQTY.Multiline = true;
            this.L_P1_O_9_CONFQTY.Name = "L_P1_O_9_CONFQTY";
            this.L_P1_O_9_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_9_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_9_CONFQTY.Text = "";
            this.L_P1_O_9_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_9_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_9_CONFAMT
            // 
            this.L_P1_O_9_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_9_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_9_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_9_CONFAMT.CanGrow = false;
            this.L_P1_O_9_CONFAMT.Dpi = 100F;
            this.L_P1_O_9_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 925F);
            this.L_P1_O_9_CONFAMT.Multiline = true;
            this.L_P1_O_9_CONFAMT.Name = "L_P1_O_9_CONFAMT";
            this.L_P1_O_9_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_9_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_9_CONFAMT.Text = "";
            this.L_P1_O_9_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_9_CONFAMT.WordWrap = false;
            // 
            // L_P1_O_SUM
            // 
            this.L_P1_O_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_SUM.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_SUM.BorderWidth = 0.5F;
            this.L_P1_O_SUM.CanGrow = false;
            this.L_P1_O_SUM.Dpi = 100F;
            this.L_P1_O_SUM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_P1_O_SUM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 943F);
            this.L_P1_O_SUM.Multiline = true;
            this.L_P1_O_SUM.Name = "L_P1_O_SUM";
            this.L_P1_O_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_SUM.SizeF = new System.Drawing.SizeF(355F, 18F);
            this.L_P1_O_SUM.Text = "합계";
            this.L_P1_O_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_SUM.WordWrap = false;
            // 
            // L_P1_O_SUM_OBJQTY
            // 
            this.L_P1_O_SUM_OBJQTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_SUM_OBJQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_SUM_OBJQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_SUM_OBJQTY.BorderWidth = 0.5F;
            this.L_P1_O_SUM_OBJQTY.CanGrow = false;
            this.L_P1_O_SUM_OBJQTY.Dpi = 100F;
            this.L_P1_O_SUM_OBJQTY.LocationFloat = new DevExpress.Utils.PointFloat(355F, 943F);
            this.L_P1_O_SUM_OBJQTY.Multiline = true;
            this.L_P1_O_SUM_OBJQTY.Name = "L_P1_O_SUM_OBJQTY";
            this.L_P1_O_SUM_OBJQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_SUM_OBJQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_SUM_OBJQTY.Text = "";
            this.L_P1_O_SUM_OBJQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_SUM_OBJQTY.WordWrap = false;
            // 
            // L_P1_O_SUM_OBJAMT
            // 
            this.L_P1_O_SUM_OBJAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_SUM_OBJAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_SUM_OBJAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_SUM_OBJAMT.BorderWidth = 0.5F;
            this.L_P1_O_SUM_OBJAMT.CanGrow = false;
            this.L_P1_O_SUM_OBJAMT.Dpi = 100F;
            this.L_P1_O_SUM_OBJAMT.LocationFloat = new DevExpress.Utils.PointFloat(427F, 943F);
            this.L_P1_O_SUM_OBJAMT.Multiline = true;
            this.L_P1_O_SUM_OBJAMT.Name = "L_P1_O_SUM_OBJAMT";
            this.L_P1_O_SUM_OBJAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_SUM_OBJAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_SUM_OBJAMT.Text = "";
            this.L_P1_O_SUM_OBJAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_SUM_OBJAMT.WordWrap = false;
            // 
            // L_P1_O_SUM_CONFQTY
            // 
            this.L_P1_O_SUM_CONFQTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_SUM_CONFQTY.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_SUM_CONFQTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_SUM_CONFQTY.BorderWidth = 0.5F;
            this.L_P1_O_SUM_CONFQTY.CanGrow = false;
            this.L_P1_O_SUM_CONFQTY.Dpi = 100F;
            this.L_P1_O_SUM_CONFQTY.LocationFloat = new DevExpress.Utils.PointFloat(561F, 943F);
            this.L_P1_O_SUM_CONFQTY.Multiline = true;
            this.L_P1_O_SUM_CONFQTY.Name = "L_P1_O_SUM_CONFQTY";
            this.L_P1_O_SUM_CONFQTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_SUM_CONFQTY.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.L_P1_O_SUM_CONFQTY.Text = "";
            this.L_P1_O_SUM_CONFQTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_SUM_CONFQTY.WordWrap = false;
            // 
            // L_P1_O_SUM_CONFAMT
            // 
            this.L_P1_O_SUM_CONFAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P1_O_SUM_CONFAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P1_O_SUM_CONFAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P1_O_SUM_CONFAMT.BorderWidth = 0.5F;
            this.L_P1_O_SUM_CONFAMT.CanGrow = false;
            this.L_P1_O_SUM_CONFAMT.Dpi = 100F;
            this.L_P1_O_SUM_CONFAMT.LocationFloat = new DevExpress.Utils.PointFloat(633F, 943F);
            this.L_P1_O_SUM_CONFAMT.Multiline = true;
            this.L_P1_O_SUM_CONFAMT.Name = "L_P1_O_SUM_CONFAMT";
            this.L_P1_O_SUM_CONFAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_O_SUM_CONFAMT.SizeF = new System.Drawing.SizeF(134F, 18F);
            this.L_P1_O_SUM_CONFAMT.Text = "";
            this.L_P1_O_SUM_CONFAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_O_SUM_CONFAMT.WordWrap = false;
            // 
            // L_P1_SEC3
            // 
            this.L_P1_SEC3.CanGrow = false;
            this.L_P1_SEC3.Dpi = 100F;
            this.L_P1_SEC3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.L_P1_SEC3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 976F);
            this.L_P1_SEC3.Multiline = true;
            this.L_P1_SEC3.Name = "L_P1_SEC3";
            this.L_P1_SEC3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SEC3.SizeF = new System.Drawing.SizeF(767F, 18F);
            this.L_P1_SEC3.Text = "3) CLAIM 처리 방안 : 납품 대금에서 상계 처리";
            this.L_P1_SEC3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_SEC3.WordWrap = false;
            // 
            // L_P1_SEC4
            // 
            this.L_P1_SEC4.CanGrow = false;
            this.L_P1_SEC4.Dpi = 100F;
            this.L_P1_SEC4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.L_P1_SEC4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 996F);
            this.L_P1_SEC4.Multiline = true;
            this.L_P1_SEC4.Name = "L_P1_SEC4";
            this.L_P1_SEC4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SEC4.SizeF = new System.Drawing.SizeF(767F, 18F);
            this.L_P1_SEC4.Text = "4) 비고 : 산출 상세 내역서 1부";
            this.L_P1_SEC4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P1_SEC4.WordWrap = false;
            // 
            // L_P1_SENDER
            // 
            this.L_P1_SENDER.CanGrow = false;
            this.L_P1_SENDER.Dpi = 100F;
            this.L_P1_SENDER.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.L_P1_SENDER.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1050F);
            this.L_P1_SENDER.Multiline = true;
            this.L_P1_SENDER.Name = "L_P1_SENDER";
            this.L_P1_SENDER.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P1_SENDER.SizeF = new System.Drawing.SizeF(767F, 30F);
            this.L_P1_SENDER.Text = "에스앤에스아이앤씨㈜ 품질임원 최 인 규";
            this.L_P1_SENDER.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P1_SENDER.WordWrap = false;
            // 
            // L_P2_TOP1
            // 
            this.L_P2_TOP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_TOP1.BorderColor = System.Drawing.Color.Black;
            this.L_P2_TOP1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_TOP1.BorderWidth = 0.5F;
            this.L_P2_TOP1.CanGrow = false;
            this.L_P2_TOP1.Dpi = 100F;
            this.L_P2_TOP1.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_P2_TOP1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.L_P2_TOP1.Multiline = true;
            this.L_P2_TOP1.Name = "L_P2_TOP1";
            this.L_P2_TOP1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_TOP1.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.L_P2_TOP1.Text = "발 신 처";
            this.L_P2_TOP1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_TOP1.WordWrap = false;
            // 
            // L_P2_FROM
            // 
            this.L_P2_FROM.BorderColor = System.Drawing.Color.Black;
            this.L_P2_FROM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_FROM.BorderWidth = 0.5F;
            this.L_P2_FROM.CanGrow = false;
            this.L_P2_FROM.Dpi = 100F;
            this.L_P2_FROM.LocationFloat = new DevExpress.Utils.PointFloat(60F, 0F);
            this.L_P2_FROM.Multiline = true;
            this.L_P2_FROM.Name = "L_P2_FROM";
            this.L_P2_FROM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_FROM.SizeF = new System.Drawing.SizeF(140F, 22F);
            this.L_P2_FROM.Text = "S&S INC 2공장";
            this.L_P2_FROM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_FROM.WordWrap = false;
            // 
            // L_P2_TOP2
            // 
            this.L_P2_TOP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_TOP2.BorderColor = System.Drawing.Color.Black;
            this.L_P2_TOP2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_TOP2.BorderWidth = 0.5F;
            this.L_P2_TOP2.CanGrow = false;
            this.L_P2_TOP2.Dpi = 100F;
            this.L_P2_TOP2.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_P2_TOP2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22F);
            this.L_P2_TOP2.Multiline = true;
            this.L_P2_TOP2.Name = "L_P2_TOP2";
            this.L_P2_TOP2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_TOP2.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.L_P2_TOP2.Text = "귀 책 처";
            this.L_P2_TOP2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_TOP2.WordWrap = false;
            // 
            // C_RECVNM_P2
            // 
            this.C_RECVNM_P2.BorderColor = System.Drawing.Color.Black;
            this.C_RECVNM_P2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_RECVNM_P2.BorderWidth = 0.5F;
            this.C_RECVNM_P2.CanGrow = false;
            this.C_RECVNM_P2.Dpi = 100F;
            this.C_RECVNM_P2.LocationFloat = new DevExpress.Utils.PointFloat(60F, 22F);
            this.C_RECVNM_P2.Multiline = true;
            this.C_RECVNM_P2.Name = "C_RECVNM_P2";
            this.C_RECVNM_P2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_RECVNM_P2.SizeF = new System.Drawing.SizeF(140F, 22F);
            this.C_RECVNM_P2.Text = "";
            this.C_RECVNM_P2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_RECVNM_P2.WordWrap = false;
            // 
            // L_P2_TOP3
            // 
            this.L_P2_TOP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_TOP3.BorderColor = System.Drawing.Color.Black;
            this.L_P2_TOP3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_TOP3.BorderWidth = 0.5F;
            this.L_P2_TOP3.CanGrow = false;
            this.L_P2_TOP3.Dpi = 100F;
            this.L_P2_TOP3.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_P2_TOP3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 44F);
            this.L_P2_TOP3.Multiline = true;
            this.L_P2_TOP3.Name = "L_P2_TOP3";
            this.L_P2_TOP3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_TOP3.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.L_P2_TOP3.Text = "발생기간";
            this.L_P2_TOP3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_TOP3.WordWrap = false;
            // 
            // C_PERIOD
            // 
            this.C_PERIOD.BorderColor = System.Drawing.Color.Black;
            this.C_PERIOD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_PERIOD.BorderWidth = 0.5F;
            this.C_PERIOD.CanGrow = false;
            this.C_PERIOD.Dpi = 100F;
            this.C_PERIOD.LocationFloat = new DevExpress.Utils.PointFloat(60F, 44F);
            this.C_PERIOD.Multiline = true;
            this.C_PERIOD.Name = "C_PERIOD";
            this.C_PERIOD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_PERIOD.SizeF = new System.Drawing.SizeF(140F, 22F);
            this.C_PERIOD.Text = "";
            this.C_PERIOD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_PERIOD.WordWrap = false;
            // 
            // L_P2_TITLE
            // 
            this.L_P2_TITLE.CanGrow = false;
            this.L_P2_TITLE.Dpi = 100F;
            this.L_P2_TITLE.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.L_P2_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(210F, 0F);
            this.L_P2_TITLE.Multiline = true;
            this.L_P2_TITLE.Name = "L_P2_TITLE";
            this.L_P2_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_TITLE.SizeF = new System.Drawing.SizeF(320F, 40F);
            this.L_P2_TITLE.Text = "CLAIM 내역서";
            this.L_P2_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_TITLE.WordWrap = false;
            // 
            // C_PLANDATE
            // 
            this.C_PLANDATE.CanGrow = false;
            this.C_PLANDATE.Dpi = 100F;
            this.C_PLANDATE.LocationFloat = new DevExpress.Utils.PointFloat(240F, 40F);
            this.C_PLANDATE.Multiline = true;
            this.C_PLANDATE.Name = "C_PLANDATE";
            this.C_PLANDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_PLANDATE.SizeF = new System.Drawing.SizeF(290F, 13F);
            this.C_PLANDATE.Text = "";
            this.C_PLANDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_PLANDATE.WordWrap = false;
            // 
            // C_CONFDATE
            // 
            this.C_CONFDATE.CanGrow = false;
            this.C_CONFDATE.Dpi = 100F;
            this.C_CONFDATE.LocationFloat = new DevExpress.Utils.PointFloat(240F, 53F);
            this.C_CONFDATE.Multiline = true;
            this.C_CONFDATE.Name = "C_CONFDATE";
            this.C_CONFDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.C_CONFDATE.SizeF = new System.Drawing.SizeF(290F, 13F);
            this.C_CONFDATE.Text = "";
            this.C_CONFDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_CONFDATE.WordWrap = false;
            // 
            // L_P2_CUST
            // 
            this.L_P2_CUST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_CUST.BorderColor = System.Drawing.Color.Black;
            this.L_P2_CUST.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_CUST.BorderWidth = 0.5F;
            this.L_P2_CUST.CanGrow = false;
            this.L_P2_CUST.Dpi = 100F;
            this.L_P2_CUST.LocationFloat = new DevExpress.Utils.PointFloat(537F, 0F);
            this.L_P2_CUST.Multiline = true;
            this.L_P2_CUST.Name = "L_P2_CUST";
            this.L_P2_CUST.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_CUST.SizeF = new System.Drawing.SizeF(20F, 66F);
            this.L_P2_CUST.Text = "협\r\n력\r\n사";
            this.L_P2_CUST.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_CUST.WordWrap = false;
            // 
            // L_P2_CUSTSIGN
            // 
            this.L_P2_CUSTSIGN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_CUSTSIGN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_CUSTSIGN.BorderWidth = 0.5F;
            this.L_P2_CUSTSIGN.CanGrow = false;
            this.L_P2_CUSTSIGN.Dpi = 100F;
            this.L_P2_CUSTSIGN.LocationFloat = new DevExpress.Utils.PointFloat(557F, 0F);
            this.L_P2_CUSTSIGN.Multiline = true;
            this.L_P2_CUSTSIGN.Name = "L_P2_CUSTSIGN";
            this.L_P2_CUSTSIGN.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_CUSTSIGN.SizeF = new System.Drawing.SizeF(50F, 66F);
            this.L_P2_CUSTSIGN.Text = "";
            this.L_P2_CUSTSIGN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_CUSTSIGN.WordWrap = false;
            // 
            // L_P2_APP
            // 
            this.L_P2_APP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_APP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_APP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_APP.BorderWidth = 0.5F;
            this.L_P2_APP.CanGrow = false;
            this.L_P2_APP.Dpi = 100F;
            this.L_P2_APP.LocationFloat = new DevExpress.Utils.PointFloat(612F, 0F);
            this.L_P2_APP.Multiline = true;
            this.L_P2_APP.Name = "L_P2_APP";
            this.L_P2_APP.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_APP.SizeF = new System.Drawing.SizeF(20F, 66F);
            this.L_P2_APP.Text = "결\r\n\r\n재";
            this.L_P2_APP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_APP.WordWrap = false;
            // 
            // L_P2_APP1
            // 
            this.L_P2_APP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_APP1.BorderColor = System.Drawing.Color.Black;
            this.L_P2_APP1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_APP1.BorderWidth = 0.5F;
            this.L_P2_APP1.CanGrow = false;
            this.L_P2_APP1.Dpi = 100F;
            this.L_P2_APP1.LocationFloat = new DevExpress.Utils.PointFloat(632F, 0F);
            this.L_P2_APP1.Multiline = true;
            this.L_P2_APP1.Name = "L_P2_APP1";
            this.L_P2_APP1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_APP1.SizeF = new System.Drawing.SizeF(45F, 18F);
            this.L_P2_APP1.Text = "담 당";
            this.L_P2_APP1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_APP1.WordWrap = false;
            // 
            // L_P2_SIGN1
            // 
            this.L_P2_SIGN1.BorderColor = System.Drawing.Color.Black;
            this.L_P2_SIGN1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_SIGN1.BorderWidth = 0.5F;
            this.L_P2_SIGN1.CanGrow = false;
            this.L_P2_SIGN1.Dpi = 100F;
            this.L_P2_SIGN1.LocationFloat = new DevExpress.Utils.PointFloat(632F, 18F);
            this.L_P2_SIGN1.Multiline = true;
            this.L_P2_SIGN1.Name = "L_P2_SIGN1";
            this.L_P2_SIGN1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_SIGN1.SizeF = new System.Drawing.SizeF(45F, 48F);
            this.L_P2_SIGN1.Text = "";
            this.L_P2_SIGN1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_SIGN1.WordWrap = false;
            // 
            // L_P2_APP2
            // 
            this.L_P2_APP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_APP2.BorderColor = System.Drawing.Color.Black;
            this.L_P2_APP2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_APP2.BorderWidth = 0.5F;
            this.L_P2_APP2.CanGrow = false;
            this.L_P2_APP2.Dpi = 100F;
            this.L_P2_APP2.LocationFloat = new DevExpress.Utils.PointFloat(677F, 0F);
            this.L_P2_APP2.Multiline = true;
            this.L_P2_APP2.Name = "L_P2_APP2";
            this.L_P2_APP2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_APP2.SizeF = new System.Drawing.SizeF(45F, 18F);
            this.L_P2_APP2.Text = "검 토";
            this.L_P2_APP2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_APP2.WordWrap = false;
            // 
            // L_P2_SIGN2
            // 
            this.L_P2_SIGN2.BorderColor = System.Drawing.Color.Black;
            this.L_P2_SIGN2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_SIGN2.BorderWidth = 0.5F;
            this.L_P2_SIGN2.CanGrow = false;
            this.L_P2_SIGN2.Dpi = 100F;
            this.L_P2_SIGN2.LocationFloat = new DevExpress.Utils.PointFloat(677F, 18F);
            this.L_P2_SIGN2.Multiline = true;
            this.L_P2_SIGN2.Name = "L_P2_SIGN2";
            this.L_P2_SIGN2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_SIGN2.SizeF = new System.Drawing.SizeF(45F, 48F);
            this.L_P2_SIGN2.Text = "";
            this.L_P2_SIGN2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_SIGN2.WordWrap = false;
            // 
            // L_P2_APP3
            // 
            this.L_P2_APP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_APP3.BorderColor = System.Drawing.Color.Black;
            this.L_P2_APP3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_APP3.BorderWidth = 0.5F;
            this.L_P2_APP3.CanGrow = false;
            this.L_P2_APP3.Dpi = 100F;
            this.L_P2_APP3.LocationFloat = new DevExpress.Utils.PointFloat(722F, 0F);
            this.L_P2_APP3.Multiline = true;
            this.L_P2_APP3.Name = "L_P2_APP3";
            this.L_P2_APP3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_APP3.SizeF = new System.Drawing.SizeF(45F, 18F);
            this.L_P2_APP3.Text = "승 인";
            this.L_P2_APP3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_APP3.WordWrap = false;
            // 
            // L_P2_SIGN3
            // 
            this.L_P2_SIGN3.BorderColor = System.Drawing.Color.Black;
            this.L_P2_SIGN3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_SIGN3.BorderWidth = 0.5F;
            this.L_P2_SIGN3.CanGrow = false;
            this.L_P2_SIGN3.Dpi = 100F;
            this.L_P2_SIGN3.LocationFloat = new DevExpress.Utils.PointFloat(722F, 18F);
            this.L_P2_SIGN3.Multiline = true;
            this.L_P2_SIGN3.Name = "L_P2_SIGN3";
            this.L_P2_SIGN3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_SIGN3.SizeF = new System.Drawing.SizeF(45F, 48F);
            this.L_P2_SIGN3.Text = "";
            this.L_P2_SIGN3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_SIGN3.WordWrap = false;
            // 
            // L_P2_H_NO
            // 
            this.L_P2_H_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_NO.BorderWidth = 0.5F;
            this.L_P2_H_NO.CanGrow = false;
            this.L_P2_H_NO.Dpi = 100F;
            this.L_P2_H_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80F);
            this.L_P2_H_NO.Multiline = true;
            this.L_P2_H_NO.Name = "L_P2_H_NO";
            this.L_P2_H_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_NO.SizeF = new System.Drawing.SizeF(22F, 36F);
            this.L_P2_H_NO.Text = "NO";
            this.L_P2_H_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_NO.WordWrap = false;
            // 
            // L_P2_H_ITEMCD
            // 
            this.L_P2_H_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_ITEMCD.BorderWidth = 0.5F;
            this.L_P2_H_ITEMCD.CanGrow = false;
            this.L_P2_H_ITEMCD.Dpi = 100F;
            this.L_P2_H_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 80F);
            this.L_P2_H_ITEMCD.Multiline = true;
            this.L_P2_H_ITEMCD.Name = "L_P2_H_ITEMCD";
            this.L_P2_H_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 36F);
            this.L_P2_H_ITEMCD.Text = "발생 품번";
            this.L_P2_H_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_ITEMCD.WordWrap = false;
            // 
            // L_P2_H_ITEMNM
            // 
            this.L_P2_H_ITEMNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_ITEMNM.BorderWidth = 0.5F;
            this.L_P2_H_ITEMNM.CanGrow = false;
            this.L_P2_H_ITEMNM.Dpi = 100F;
            this.L_P2_H_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 80F);
            this.L_P2_H_ITEMNM.Multiline = true;
            this.L_P2_H_ITEMNM.Name = "L_P2_H_ITEMNM";
            this.L_P2_H_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 36F);
            this.L_P2_H_ITEMNM.Text = "차종/품명";
            this.L_P2_H_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_ITEMNM.WordWrap = false;
            // 
            // L_P2_H_BADCONT
            // 
            this.L_P2_H_BADCONT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_BADCONT.BorderWidth = 0.5F;
            this.L_P2_H_BADCONT.CanGrow = false;
            this.L_P2_H_BADCONT.Dpi = 100F;
            this.L_P2_H_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 80F);
            this.L_P2_H_BADCONT.Multiline = true;
            this.L_P2_H_BADCONT.Name = "L_P2_H_BADCONT";
            this.L_P2_H_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_BADCONT.SizeF = new System.Drawing.SizeF(100F, 36F);
            this.L_P2_H_BADCONT.Text = "부적합 내용";
            this.L_P2_H_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_BADCONT.WordWrap = false;
            // 
            // L_P2_H_QTY
            // 
            this.L_P2_H_QTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_QTY.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_QTY.BorderWidth = 0.5F;
            this.L_P2_H_QTY.CanGrow = false;
            this.L_P2_H_QTY.Dpi = 100F;
            this.L_P2_H_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 80F);
            this.L_P2_H_QTY.Multiline = true;
            this.L_P2_H_QTY.Name = "L_P2_H_QTY";
            this.L_P2_H_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_QTY.SizeF = new System.Drawing.SizeF(32F, 36F);
            this.L_P2_H_QTY.Text = "수량";
            this.L_P2_H_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_QTY.WordWrap = false;
            // 
            // L_P2_H_LOSS
            // 
            this.L_P2_H_LOSS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_LOSS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_LOSS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_LOSS.BorderWidth = 0.5F;
            this.L_P2_H_LOSS.CanGrow = false;
            this.L_P2_H_LOSS.Dpi = 100F;
            this.L_P2_H_LOSS.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_LOSS.LocationFloat = new DevExpress.Utils.PointFloat(344F, 80F);
            this.L_P2_H_LOSS.Multiline = true;
            this.L_P2_H_LOSS.Name = "L_P2_H_LOSS";
            this.L_P2_H_LOSS.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_LOSS.SizeF = new System.Drawing.SizeF(252F, 18F);
            this.L_P2_H_LOSS.Text = "발생 손실 비용 (단위:원)";
            this.L_P2_H_LOSS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_LOSS.WordWrap = false;
            // 
            // L_P2_H_OBJ
            // 
            this.L_P2_H_OBJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_OBJ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_OBJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_OBJ.BorderWidth = 0.5F;
            this.L_P2_H_OBJ.CanGrow = false;
            this.L_P2_H_OBJ.Dpi = 100F;
            this.L_P2_H_OBJ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_OBJ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 80F);
            this.L_P2_H_OBJ.Multiline = true;
            this.L_P2_H_OBJ.Name = "L_P2_H_OBJ";
            this.L_P2_H_OBJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_OBJ.SizeF = new System.Drawing.SizeF(86F, 18F);
            this.L_P2_H_OBJ.Text = "이의제기 (원)";
            this.L_P2_H_OBJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_OBJ.WordWrap = false;
            // 
            // L_P2_H_CLAIM
            // 
            this.L_P2_H_CLAIM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_CLAIM.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_CLAIM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_CLAIM.BorderWidth = 0.5F;
            this.L_P2_H_CLAIM.CanGrow = false;
            this.L_P2_H_CLAIM.Dpi = 100F;
            this.L_P2_H_CLAIM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_CLAIM.LocationFloat = new DevExpress.Utils.PointFloat(682F, 80F);
            this.L_P2_H_CLAIM.Multiline = true;
            this.L_P2_H_CLAIM.Name = "L_P2_H_CLAIM";
            this.L_P2_H_CLAIM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_CLAIM.SizeF = new System.Drawing.SizeF(85F, 18F);
            this.L_P2_H_CLAIM.Text = "CLAIM 비용 (원)";
            this.L_P2_H_CLAIM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_CLAIM.WordWrap = false;
            // 
            // L_P2_H_INPRICE
            // 
            this.L_P2_H_INPRICE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_INPRICE.BorderWidth = 0.5F;
            this.L_P2_H_INPRICE.CanGrow = false;
            this.L_P2_H_INPRICE.Dpi = 100F;
            this.L_P2_H_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 98F);
            this.L_P2_H_INPRICE.Multiline = true;
            this.L_P2_H_INPRICE.Name = "L_P2_H_INPRICE";
            this.L_P2_H_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.L_P2_H_INPRICE.Text = "입고단가";
            this.L_P2_H_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_INPRICE.WordWrap = false;
            // 
            // L_P2_H_MFGPRICE
            // 
            this.L_P2_H_MFGPRICE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_MFGPRICE.BorderWidth = 0.5F;
            this.L_P2_H_MFGPRICE.CanGrow = false;
            this.L_P2_H_MFGPRICE.Dpi = 100F;
            this.L_P2_H_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 98F);
            this.L_P2_H_MFGPRICE.Multiline = true;
            this.L_P2_H_MFGPRICE.Name = "L_P2_H_MFGPRICE";
            this.L_P2_H_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.L_P2_H_MFGPRICE.Text = "제조단가";
            this.L_P2_H_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_MFGPRICE.WordWrap = false;
            // 
            // L_P2_H_SALEPRICE
            // 
            this.L_P2_H_SALEPRICE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_SALEPRICE.BorderWidth = 0.5F;
            this.L_P2_H_SALEPRICE.CanGrow = false;
            this.L_P2_H_SALEPRICE.Dpi = 100F;
            this.L_P2_H_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 98F);
            this.L_P2_H_SALEPRICE.Multiline = true;
            this.L_P2_H_SALEPRICE.Name = "L_P2_H_SALEPRICE";
            this.L_P2_H_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.L_P2_H_SALEPRICE.Text = "판매단가";
            this.L_P2_H_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_SALEPRICE.WordWrap = false;
            // 
            // L_P2_H_ETCAMT
            // 
            this.L_P2_H_ETCAMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_ETCAMT.BorderWidth = 0.5F;
            this.L_P2_H_ETCAMT.CanGrow = false;
            this.L_P2_H_ETCAMT.Dpi = 100F;
            this.L_P2_H_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 98F);
            this.L_P2_H_ETCAMT.Multiline = true;
            this.L_P2_H_ETCAMT.Name = "L_P2_H_ETCAMT";
            this.L_P2_H_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.L_P2_H_ETCAMT.Text = "제반비용";
            this.L_P2_H_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_ETCAMT.WordWrap = false;
            // 
            // L_P2_H_AMT
            // 
            this.L_P2_H_AMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_AMT.BorderWidth = 0.5F;
            this.L_P2_H_AMT.CanGrow = false;
            this.L_P2_H_AMT.Dpi = 100F;
            this.L_P2_H_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 98F);
            this.L_P2_H_AMT.Multiline = true;
            this.L_P2_H_AMT.Name = "L_P2_H_AMT";
            this.L_P2_H_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.L_P2_H_AMT.Text = "합계금액";
            this.L_P2_H_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_AMT.WordWrap = false;
            // 
            // L_P2_H_OBJREQ
            // 
            this.L_P2_H_OBJREQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_H_OBJREQ.CanGrow = false;
            this.L_P2_H_OBJREQ.Dpi = 100F;
            this.L_P2_H_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 98F);
            this.L_P2_H_OBJREQ.Multiline = true;
            this.L_P2_H_OBJREQ.Name = "L_P2_H_OBJREQ";
            this.L_P2_H_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_H_OBJREQ.Text = "신청금액";
            this.L_P2_H_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_OBJREQ.WordWrap = false;
            // 
            // L_P2_H_OBJOK
            // 
            this.L_P2_H_OBJOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_OBJOK.BorderWidth = 0.5F;
            this.L_P2_H_OBJOK.CanGrow = false;
            this.L_P2_H_OBJOK.Dpi = 100F;
            this.L_P2_H_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 98F);
            this.L_P2_H_OBJOK.Multiline = true;
            this.L_P2_H_OBJOK.Name = "L_P2_H_OBJOK";
            this.L_P2_H_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_H_OBJOK.Text = "인정금액";
            this.L_P2_H_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_OBJOK.WordWrap = false;
            // 
            // L_P2_H_PLAN
            // 
            this.L_P2_H_PLAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_PLAN.BorderWidth = 0.5F;
            this.L_P2_H_PLAN.CanGrow = false;
            this.L_P2_H_PLAN.Dpi = 100F;
            this.L_P2_H_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 98F);
            this.L_P2_H_PLAN.Multiline = true;
            this.L_P2_H_PLAN.Name = "L_P2_H_PLAN";
            this.L_P2_H_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_H_PLAN.Text = "예정금액";
            this.L_P2_H_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_PLAN.WordWrap = false;
            // 
            // L_P2_H_CONF
            // 
            this.L_P2_H_CONF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_H_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_H_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_H_CONF.BorderWidth = 0.5F;
            this.L_P2_H_CONF.CanGrow = false;
            this.L_P2_H_CONF.Dpi = 100F;
            this.L_P2_H_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_H_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 98F);
            this.L_P2_H_CONF.Multiline = true;
            this.L_P2_H_CONF.Name = "L_P2_H_CONF";
            this.L_P2_H_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_H_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_H_CONF.Text = "확정금액";
            this.L_P2_H_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_H_CONF.WordWrap = false;
            // 
            // L_P2_1_NO
            // 
            this.L_P2_1_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_1_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_1_NO.BorderWidth = 0.5F;
            this.L_P2_1_NO.CanGrow = false;
            this.L_P2_1_NO.Dpi = 100F;
            this.L_P2_1_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_1_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 116F);
            this.L_P2_1_NO.Multiline = true;
            this.L_P2_1_NO.Name = "L_P2_1_NO";
            this.L_P2_1_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_1_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_1_NO.Text = "1";
            this.L_P2_1_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_1_NO.WordWrap = false;
            // 
            // C_P2_1_ITEMCD
            // 
            this.C_P2_1_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_1_ITEMCD.CanGrow = false;
            this.C_P2_1_ITEMCD.Dpi = 100F;
            this.C_P2_1_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 116F);
            this.C_P2_1_ITEMCD.Multiline = true;
            this.C_P2_1_ITEMCD.Name = "C_P2_1_ITEMCD";
            this.C_P2_1_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_1_ITEMCD.Text = "";
            this.C_P2_1_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_1_ITEMCD.WordWrap = false;
            // 
            // C_P2_1_ITEMNM
            // 
            this.C_P2_1_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_1_ITEMNM.CanGrow = false;
            this.C_P2_1_ITEMNM.Dpi = 100F;
            this.C_P2_1_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 116F);
            this.C_P2_1_ITEMNM.Multiline = true;
            this.C_P2_1_ITEMNM.Name = "C_P2_1_ITEMNM";
            this.C_P2_1_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_1_ITEMNM.Text = "";
            this.C_P2_1_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_1_ITEMNM.WordWrap = false;
            // 
            // C_P2_1_BADCONT
            // 
            this.C_P2_1_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_BADCONT.BorderWidth = 0.5F;
            this.C_P2_1_BADCONT.CanGrow = false;
            this.C_P2_1_BADCONT.Dpi = 100F;
            this.C_P2_1_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 116F);
            this.C_P2_1_BADCONT.Multiline = true;
            this.C_P2_1_BADCONT.Name = "C_P2_1_BADCONT";
            this.C_P2_1_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_1_BADCONT.Text = "";
            this.C_P2_1_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_1_BADCONT.WordWrap = false;
            // 
            // C_P2_1_QTY
            // 
            this.C_P2_1_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_QTY.BorderWidth = 0.5F;
            this.C_P2_1_QTY.CanGrow = false;
            this.C_P2_1_QTY.Dpi = 100F;
            this.C_P2_1_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 116F);
            this.C_P2_1_QTY.Multiline = true;
            this.C_P2_1_QTY.Name = "C_P2_1_QTY";
            this.C_P2_1_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_1_QTY.Text = "";
            this.C_P2_1_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_1_QTY.WordWrap = false;
            // 
            // C_P2_1_INPRICE
            // 
            this.C_P2_1_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_INPRICE.BorderWidth = 0.5F;
            this.C_P2_1_INPRICE.CanGrow = false;
            this.C_P2_1_INPRICE.Dpi = 100F;
            this.C_P2_1_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 116F);
            this.C_P2_1_INPRICE.Multiline = true;
            this.C_P2_1_INPRICE.Name = "C_P2_1_INPRICE";
            this.C_P2_1_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_1_INPRICE.Text = "";
            this.C_P2_1_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_1_INPRICE.WordWrap = false;
            // 
            // C_P2_1_MFGPRICE
            // 
            this.C_P2_1_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_1_MFGPRICE.CanGrow = false;
            this.C_P2_1_MFGPRICE.Dpi = 100F;
            this.C_P2_1_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 116F);
            this.C_P2_1_MFGPRICE.Multiline = true;
            this.C_P2_1_MFGPRICE.Name = "C_P2_1_MFGPRICE";
            this.C_P2_1_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_1_MFGPRICE.Text = "";
            this.C_P2_1_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_1_MFGPRICE.WordWrap = false;
            // 
            // C_P2_1_SALEPRICE
            // 
            this.C_P2_1_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_1_SALEPRICE.CanGrow = false;
            this.C_P2_1_SALEPRICE.Dpi = 100F;
            this.C_P2_1_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 116F);
            this.C_P2_1_SALEPRICE.Multiline = true;
            this.C_P2_1_SALEPRICE.Name = "C_P2_1_SALEPRICE";
            this.C_P2_1_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_1_SALEPRICE.Text = "";
            this.C_P2_1_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_1_SALEPRICE.WordWrap = false;
            // 
            // C_P2_1_ETCAMT
            // 
            this.C_P2_1_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_1_ETCAMT.CanGrow = false;
            this.C_P2_1_ETCAMT.Dpi = 100F;
            this.C_P2_1_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 116F);
            this.C_P2_1_ETCAMT.Multiline = true;
            this.C_P2_1_ETCAMT.Name = "C_P2_1_ETCAMT";
            this.C_P2_1_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_1_ETCAMT.Text = "";
            this.C_P2_1_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_1_ETCAMT.WordWrap = false;
            // 
            // C_P2_1_AMT
            // 
            this.C_P2_1_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_1_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_1_AMT.BorderWidth = 0.5F;
            this.C_P2_1_AMT.CanGrow = false;
            this.C_P2_1_AMT.Dpi = 100F;
            this.C_P2_1_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_1_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 116F);
            this.C_P2_1_AMT.Multiline = true;
            this.C_P2_1_AMT.Name = "C_P2_1_AMT";
            this.C_P2_1_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_1_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_1_AMT.Text = "";
            this.C_P2_1_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_1_AMT.WordWrap = false;
            // 
            // L_P2_1_OBJREQ
            // 
            this.L_P2_1_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_1_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_1_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_1_OBJREQ.CanGrow = false;
            this.L_P2_1_OBJREQ.Dpi = 100F;
            this.L_P2_1_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_1_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 116F);
            this.L_P2_1_OBJREQ.Multiline = true;
            this.L_P2_1_OBJREQ.Name = "L_P2_1_OBJREQ";
            this.L_P2_1_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_1_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_1_OBJREQ.Text = "";
            this.L_P2_1_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_1_OBJREQ.WordWrap = false;
            // 
            // L_P2_1_OBJOK
            // 
            this.L_P2_1_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_1_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_1_OBJOK.BorderWidth = 0.5F;
            this.L_P2_1_OBJOK.CanGrow = false;
            this.L_P2_1_OBJOK.Dpi = 100F;
            this.L_P2_1_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_1_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 116F);
            this.L_P2_1_OBJOK.Multiline = true;
            this.L_P2_1_OBJOK.Name = "L_P2_1_OBJOK";
            this.L_P2_1_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_1_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_1_OBJOK.Text = "";
            this.L_P2_1_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_1_OBJOK.WordWrap = false;
            // 
            // L_P2_1_PLAN
            // 
            this.L_P2_1_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_1_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_1_PLAN.BorderWidth = 0.5F;
            this.L_P2_1_PLAN.CanGrow = false;
            this.L_P2_1_PLAN.Dpi = 100F;
            this.L_P2_1_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_1_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 116F);
            this.L_P2_1_PLAN.Multiline = true;
            this.L_P2_1_PLAN.Name = "L_P2_1_PLAN";
            this.L_P2_1_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_1_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_1_PLAN.Text = "";
            this.L_P2_1_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_1_PLAN.WordWrap = false;
            // 
            // L_P2_1_CONF
            // 
            this.L_P2_1_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_1_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_1_CONF.BorderWidth = 0.5F;
            this.L_P2_1_CONF.CanGrow = false;
            this.L_P2_1_CONF.Dpi = 100F;
            this.L_P2_1_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_1_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 116F);
            this.L_P2_1_CONF.Multiline = true;
            this.L_P2_1_CONF.Name = "L_P2_1_CONF";
            this.L_P2_1_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_1_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_1_CONF.Text = "";
            this.L_P2_1_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_1_CONF.WordWrap = false;
            // 
            // L_P2_2_NO
            // 
            this.L_P2_2_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_2_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_2_NO.BorderWidth = 0.5F;
            this.L_P2_2_NO.CanGrow = false;
            this.L_P2_2_NO.Dpi = 100F;
            this.L_P2_2_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_2_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 134F);
            this.L_P2_2_NO.Multiline = true;
            this.L_P2_2_NO.Name = "L_P2_2_NO";
            this.L_P2_2_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_2_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_2_NO.Text = "2";
            this.L_P2_2_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_2_NO.WordWrap = false;
            // 
            // C_P2_2_ITEMCD
            // 
            this.C_P2_2_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_2_ITEMCD.CanGrow = false;
            this.C_P2_2_ITEMCD.Dpi = 100F;
            this.C_P2_2_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 134F);
            this.C_P2_2_ITEMCD.Multiline = true;
            this.C_P2_2_ITEMCD.Name = "C_P2_2_ITEMCD";
            this.C_P2_2_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_2_ITEMCD.Text = "";
            this.C_P2_2_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_2_ITEMCD.WordWrap = false;
            // 
            // C_P2_2_ITEMNM
            // 
            this.C_P2_2_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_2_ITEMNM.CanGrow = false;
            this.C_P2_2_ITEMNM.Dpi = 100F;
            this.C_P2_2_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 134F);
            this.C_P2_2_ITEMNM.Multiline = true;
            this.C_P2_2_ITEMNM.Name = "C_P2_2_ITEMNM";
            this.C_P2_2_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_2_ITEMNM.Text = "";
            this.C_P2_2_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_2_ITEMNM.WordWrap = false;
            // 
            // C_P2_2_BADCONT
            // 
            this.C_P2_2_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_BADCONT.BorderWidth = 0.5F;
            this.C_P2_2_BADCONT.CanGrow = false;
            this.C_P2_2_BADCONT.Dpi = 100F;
            this.C_P2_2_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 134F);
            this.C_P2_2_BADCONT.Multiline = true;
            this.C_P2_2_BADCONT.Name = "C_P2_2_BADCONT";
            this.C_P2_2_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_2_BADCONT.Text = "";
            this.C_P2_2_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_2_BADCONT.WordWrap = false;
            // 
            // C_P2_2_QTY
            // 
            this.C_P2_2_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_QTY.BorderWidth = 0.5F;
            this.C_P2_2_QTY.CanGrow = false;
            this.C_P2_2_QTY.Dpi = 100F;
            this.C_P2_2_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 134F);
            this.C_P2_2_QTY.Multiline = true;
            this.C_P2_2_QTY.Name = "C_P2_2_QTY";
            this.C_P2_2_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_2_QTY.Text = "";
            this.C_P2_2_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_2_QTY.WordWrap = false;
            // 
            // C_P2_2_INPRICE
            // 
            this.C_P2_2_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_INPRICE.BorderWidth = 0.5F;
            this.C_P2_2_INPRICE.CanGrow = false;
            this.C_P2_2_INPRICE.Dpi = 100F;
            this.C_P2_2_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 134F);
            this.C_P2_2_INPRICE.Multiline = true;
            this.C_P2_2_INPRICE.Name = "C_P2_2_INPRICE";
            this.C_P2_2_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_2_INPRICE.Text = "";
            this.C_P2_2_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_2_INPRICE.WordWrap = false;
            // 
            // C_P2_2_MFGPRICE
            // 
            this.C_P2_2_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_2_MFGPRICE.CanGrow = false;
            this.C_P2_2_MFGPRICE.Dpi = 100F;
            this.C_P2_2_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 134F);
            this.C_P2_2_MFGPRICE.Multiline = true;
            this.C_P2_2_MFGPRICE.Name = "C_P2_2_MFGPRICE";
            this.C_P2_2_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_2_MFGPRICE.Text = "";
            this.C_P2_2_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_2_MFGPRICE.WordWrap = false;
            // 
            // C_P2_2_SALEPRICE
            // 
            this.C_P2_2_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_2_SALEPRICE.CanGrow = false;
            this.C_P2_2_SALEPRICE.Dpi = 100F;
            this.C_P2_2_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 134F);
            this.C_P2_2_SALEPRICE.Multiline = true;
            this.C_P2_2_SALEPRICE.Name = "C_P2_2_SALEPRICE";
            this.C_P2_2_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_2_SALEPRICE.Text = "";
            this.C_P2_2_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_2_SALEPRICE.WordWrap = false;
            // 
            // C_P2_2_ETCAMT
            // 
            this.C_P2_2_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_2_ETCAMT.CanGrow = false;
            this.C_P2_2_ETCAMT.Dpi = 100F;
            this.C_P2_2_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 134F);
            this.C_P2_2_ETCAMT.Multiline = true;
            this.C_P2_2_ETCAMT.Name = "C_P2_2_ETCAMT";
            this.C_P2_2_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_2_ETCAMT.Text = "";
            this.C_P2_2_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_2_ETCAMT.WordWrap = false;
            // 
            // C_P2_2_AMT
            // 
            this.C_P2_2_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_2_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_2_AMT.BorderWidth = 0.5F;
            this.C_P2_2_AMT.CanGrow = false;
            this.C_P2_2_AMT.Dpi = 100F;
            this.C_P2_2_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_2_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 134F);
            this.C_P2_2_AMT.Multiline = true;
            this.C_P2_2_AMT.Name = "C_P2_2_AMT";
            this.C_P2_2_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_2_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_2_AMT.Text = "";
            this.C_P2_2_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_2_AMT.WordWrap = false;
            // 
            // L_P2_2_OBJREQ
            // 
            this.L_P2_2_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_2_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_2_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_2_OBJREQ.CanGrow = false;
            this.L_P2_2_OBJREQ.Dpi = 100F;
            this.L_P2_2_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_2_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 134F);
            this.L_P2_2_OBJREQ.Multiline = true;
            this.L_P2_2_OBJREQ.Name = "L_P2_2_OBJREQ";
            this.L_P2_2_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_2_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_2_OBJREQ.Text = "";
            this.L_P2_2_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_2_OBJREQ.WordWrap = false;
            // 
            // L_P2_2_OBJOK
            // 
            this.L_P2_2_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_2_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_2_OBJOK.BorderWidth = 0.5F;
            this.L_P2_2_OBJOK.CanGrow = false;
            this.L_P2_2_OBJOK.Dpi = 100F;
            this.L_P2_2_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_2_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 134F);
            this.L_P2_2_OBJOK.Multiline = true;
            this.L_P2_2_OBJOK.Name = "L_P2_2_OBJOK";
            this.L_P2_2_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_2_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_2_OBJOK.Text = "";
            this.L_P2_2_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_2_OBJOK.WordWrap = false;
            // 
            // L_P2_2_PLAN
            // 
            this.L_P2_2_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_2_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_2_PLAN.BorderWidth = 0.5F;
            this.L_P2_2_PLAN.CanGrow = false;
            this.L_P2_2_PLAN.Dpi = 100F;
            this.L_P2_2_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_2_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 134F);
            this.L_P2_2_PLAN.Multiline = true;
            this.L_P2_2_PLAN.Name = "L_P2_2_PLAN";
            this.L_P2_2_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_2_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_2_PLAN.Text = "";
            this.L_P2_2_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_2_PLAN.WordWrap = false;
            // 
            // L_P2_2_CONF
            // 
            this.L_P2_2_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_2_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_2_CONF.BorderWidth = 0.5F;
            this.L_P2_2_CONF.CanGrow = false;
            this.L_P2_2_CONF.Dpi = 100F;
            this.L_P2_2_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_2_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 134F);
            this.L_P2_2_CONF.Multiline = true;
            this.L_P2_2_CONF.Name = "L_P2_2_CONF";
            this.L_P2_2_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_2_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_2_CONF.Text = "";
            this.L_P2_2_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_2_CONF.WordWrap = false;
            // 
            // L_P2_3_NO
            // 
            this.L_P2_3_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_3_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_3_NO.BorderWidth = 0.5F;
            this.L_P2_3_NO.CanGrow = false;
            this.L_P2_3_NO.Dpi = 100F;
            this.L_P2_3_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_3_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 152F);
            this.L_P2_3_NO.Multiline = true;
            this.L_P2_3_NO.Name = "L_P2_3_NO";
            this.L_P2_3_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_3_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_3_NO.Text = "3";
            this.L_P2_3_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_3_NO.WordWrap = false;
            // 
            // C_P2_3_ITEMCD
            // 
            this.C_P2_3_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_3_ITEMCD.CanGrow = false;
            this.C_P2_3_ITEMCD.Dpi = 100F;
            this.C_P2_3_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 152F);
            this.C_P2_3_ITEMCD.Multiline = true;
            this.C_P2_3_ITEMCD.Name = "C_P2_3_ITEMCD";
            this.C_P2_3_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_3_ITEMCD.Text = "";
            this.C_P2_3_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_3_ITEMCD.WordWrap = false;
            // 
            // C_P2_3_ITEMNM
            // 
            this.C_P2_3_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_3_ITEMNM.CanGrow = false;
            this.C_P2_3_ITEMNM.Dpi = 100F;
            this.C_P2_3_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 152F);
            this.C_P2_3_ITEMNM.Multiline = true;
            this.C_P2_3_ITEMNM.Name = "C_P2_3_ITEMNM";
            this.C_P2_3_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_3_ITEMNM.Text = "";
            this.C_P2_3_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_3_ITEMNM.WordWrap = false;
            // 
            // C_P2_3_BADCONT
            // 
            this.C_P2_3_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_BADCONT.BorderWidth = 0.5F;
            this.C_P2_3_BADCONT.CanGrow = false;
            this.C_P2_3_BADCONT.Dpi = 100F;
            this.C_P2_3_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 152F);
            this.C_P2_3_BADCONT.Multiline = true;
            this.C_P2_3_BADCONT.Name = "C_P2_3_BADCONT";
            this.C_P2_3_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_3_BADCONT.Text = "";
            this.C_P2_3_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_3_BADCONT.WordWrap = false;
            // 
            // C_P2_3_QTY
            // 
            this.C_P2_3_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_QTY.BorderWidth = 0.5F;
            this.C_P2_3_QTY.CanGrow = false;
            this.C_P2_3_QTY.Dpi = 100F;
            this.C_P2_3_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 152F);
            this.C_P2_3_QTY.Multiline = true;
            this.C_P2_3_QTY.Name = "C_P2_3_QTY";
            this.C_P2_3_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_3_QTY.Text = "";
            this.C_P2_3_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_3_QTY.WordWrap = false;
            // 
            // C_P2_3_INPRICE
            // 
            this.C_P2_3_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_INPRICE.BorderWidth = 0.5F;
            this.C_P2_3_INPRICE.CanGrow = false;
            this.C_P2_3_INPRICE.Dpi = 100F;
            this.C_P2_3_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 152F);
            this.C_P2_3_INPRICE.Multiline = true;
            this.C_P2_3_INPRICE.Name = "C_P2_3_INPRICE";
            this.C_P2_3_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_3_INPRICE.Text = "";
            this.C_P2_3_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_3_INPRICE.WordWrap = false;
            // 
            // C_P2_3_MFGPRICE
            // 
            this.C_P2_3_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_3_MFGPRICE.CanGrow = false;
            this.C_P2_3_MFGPRICE.Dpi = 100F;
            this.C_P2_3_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 152F);
            this.C_P2_3_MFGPRICE.Multiline = true;
            this.C_P2_3_MFGPRICE.Name = "C_P2_3_MFGPRICE";
            this.C_P2_3_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_3_MFGPRICE.Text = "";
            this.C_P2_3_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_3_MFGPRICE.WordWrap = false;
            // 
            // C_P2_3_SALEPRICE
            // 
            this.C_P2_3_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_3_SALEPRICE.CanGrow = false;
            this.C_P2_3_SALEPRICE.Dpi = 100F;
            this.C_P2_3_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 152F);
            this.C_P2_3_SALEPRICE.Multiline = true;
            this.C_P2_3_SALEPRICE.Name = "C_P2_3_SALEPRICE";
            this.C_P2_3_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_3_SALEPRICE.Text = "";
            this.C_P2_3_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_3_SALEPRICE.WordWrap = false;
            // 
            // C_P2_3_ETCAMT
            // 
            this.C_P2_3_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_3_ETCAMT.CanGrow = false;
            this.C_P2_3_ETCAMT.Dpi = 100F;
            this.C_P2_3_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 152F);
            this.C_P2_3_ETCAMT.Multiline = true;
            this.C_P2_3_ETCAMT.Name = "C_P2_3_ETCAMT";
            this.C_P2_3_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_3_ETCAMT.Text = "";
            this.C_P2_3_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_3_ETCAMT.WordWrap = false;
            // 
            // C_P2_3_AMT
            // 
            this.C_P2_3_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_3_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_3_AMT.BorderWidth = 0.5F;
            this.C_P2_3_AMT.CanGrow = false;
            this.C_P2_3_AMT.Dpi = 100F;
            this.C_P2_3_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_3_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 152F);
            this.C_P2_3_AMT.Multiline = true;
            this.C_P2_3_AMT.Name = "C_P2_3_AMT";
            this.C_P2_3_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_3_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_3_AMT.Text = "";
            this.C_P2_3_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_3_AMT.WordWrap = false;
            // 
            // L_P2_3_OBJREQ
            // 
            this.L_P2_3_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_3_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_3_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_3_OBJREQ.CanGrow = false;
            this.L_P2_3_OBJREQ.Dpi = 100F;
            this.L_P2_3_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_3_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 152F);
            this.L_P2_3_OBJREQ.Multiline = true;
            this.L_P2_3_OBJREQ.Name = "L_P2_3_OBJREQ";
            this.L_P2_3_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_3_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_3_OBJREQ.Text = "";
            this.L_P2_3_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_3_OBJREQ.WordWrap = false;
            // 
            // L_P2_3_OBJOK
            // 
            this.L_P2_3_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_3_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_3_OBJOK.BorderWidth = 0.5F;
            this.L_P2_3_OBJOK.CanGrow = false;
            this.L_P2_3_OBJOK.Dpi = 100F;
            this.L_P2_3_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_3_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 152F);
            this.L_P2_3_OBJOK.Multiline = true;
            this.L_P2_3_OBJOK.Name = "L_P2_3_OBJOK";
            this.L_P2_3_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_3_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_3_OBJOK.Text = "";
            this.L_P2_3_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_3_OBJOK.WordWrap = false;
            // 
            // L_P2_3_PLAN
            // 
            this.L_P2_3_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_3_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_3_PLAN.BorderWidth = 0.5F;
            this.L_P2_3_PLAN.CanGrow = false;
            this.L_P2_3_PLAN.Dpi = 100F;
            this.L_P2_3_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_3_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 152F);
            this.L_P2_3_PLAN.Multiline = true;
            this.L_P2_3_PLAN.Name = "L_P2_3_PLAN";
            this.L_P2_3_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_3_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_3_PLAN.Text = "";
            this.L_P2_3_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_3_PLAN.WordWrap = false;
            // 
            // L_P2_3_CONF
            // 
            this.L_P2_3_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_3_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_3_CONF.BorderWidth = 0.5F;
            this.L_P2_3_CONF.CanGrow = false;
            this.L_P2_3_CONF.Dpi = 100F;
            this.L_P2_3_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_3_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 152F);
            this.L_P2_3_CONF.Multiline = true;
            this.L_P2_3_CONF.Name = "L_P2_3_CONF";
            this.L_P2_3_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_3_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_3_CONF.Text = "";
            this.L_P2_3_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_3_CONF.WordWrap = false;
            // 
            // L_P2_4_NO
            // 
            this.L_P2_4_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_4_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_4_NO.BorderWidth = 0.5F;
            this.L_P2_4_NO.CanGrow = false;
            this.L_P2_4_NO.Dpi = 100F;
            this.L_P2_4_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_4_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 170F);
            this.L_P2_4_NO.Multiline = true;
            this.L_P2_4_NO.Name = "L_P2_4_NO";
            this.L_P2_4_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_4_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_4_NO.Text = "4";
            this.L_P2_4_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_4_NO.WordWrap = false;
            // 
            // C_P2_4_ITEMCD
            // 
            this.C_P2_4_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_4_ITEMCD.CanGrow = false;
            this.C_P2_4_ITEMCD.Dpi = 100F;
            this.C_P2_4_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 170F);
            this.C_P2_4_ITEMCD.Multiline = true;
            this.C_P2_4_ITEMCD.Name = "C_P2_4_ITEMCD";
            this.C_P2_4_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_4_ITEMCD.Text = "";
            this.C_P2_4_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_4_ITEMCD.WordWrap = false;
            // 
            // C_P2_4_ITEMNM
            // 
            this.C_P2_4_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_4_ITEMNM.CanGrow = false;
            this.C_P2_4_ITEMNM.Dpi = 100F;
            this.C_P2_4_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 170F);
            this.C_P2_4_ITEMNM.Multiline = true;
            this.C_P2_4_ITEMNM.Name = "C_P2_4_ITEMNM";
            this.C_P2_4_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_4_ITEMNM.Text = "";
            this.C_P2_4_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_4_ITEMNM.WordWrap = false;
            // 
            // C_P2_4_BADCONT
            // 
            this.C_P2_4_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_BADCONT.BorderWidth = 0.5F;
            this.C_P2_4_BADCONT.CanGrow = false;
            this.C_P2_4_BADCONT.Dpi = 100F;
            this.C_P2_4_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 170F);
            this.C_P2_4_BADCONT.Multiline = true;
            this.C_P2_4_BADCONT.Name = "C_P2_4_BADCONT";
            this.C_P2_4_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_4_BADCONT.Text = "";
            this.C_P2_4_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_4_BADCONT.WordWrap = false;
            // 
            // C_P2_4_QTY
            // 
            this.C_P2_4_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_QTY.BorderWidth = 0.5F;
            this.C_P2_4_QTY.CanGrow = false;
            this.C_P2_4_QTY.Dpi = 100F;
            this.C_P2_4_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 170F);
            this.C_P2_4_QTY.Multiline = true;
            this.C_P2_4_QTY.Name = "C_P2_4_QTY";
            this.C_P2_4_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_4_QTY.Text = "";
            this.C_P2_4_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_4_QTY.WordWrap = false;
            // 
            // C_P2_4_INPRICE
            // 
            this.C_P2_4_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_INPRICE.BorderWidth = 0.5F;
            this.C_P2_4_INPRICE.CanGrow = false;
            this.C_P2_4_INPRICE.Dpi = 100F;
            this.C_P2_4_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 170F);
            this.C_P2_4_INPRICE.Multiline = true;
            this.C_P2_4_INPRICE.Name = "C_P2_4_INPRICE";
            this.C_P2_4_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_4_INPRICE.Text = "";
            this.C_P2_4_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_4_INPRICE.WordWrap = false;
            // 
            // C_P2_4_MFGPRICE
            // 
            this.C_P2_4_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_4_MFGPRICE.CanGrow = false;
            this.C_P2_4_MFGPRICE.Dpi = 100F;
            this.C_P2_4_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 170F);
            this.C_P2_4_MFGPRICE.Multiline = true;
            this.C_P2_4_MFGPRICE.Name = "C_P2_4_MFGPRICE";
            this.C_P2_4_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_4_MFGPRICE.Text = "";
            this.C_P2_4_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_4_MFGPRICE.WordWrap = false;
            // 
            // C_P2_4_SALEPRICE
            // 
            this.C_P2_4_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_4_SALEPRICE.CanGrow = false;
            this.C_P2_4_SALEPRICE.Dpi = 100F;
            this.C_P2_4_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 170F);
            this.C_P2_4_SALEPRICE.Multiline = true;
            this.C_P2_4_SALEPRICE.Name = "C_P2_4_SALEPRICE";
            this.C_P2_4_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_4_SALEPRICE.Text = "";
            this.C_P2_4_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_4_SALEPRICE.WordWrap = false;
            // 
            // C_P2_4_ETCAMT
            // 
            this.C_P2_4_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_4_ETCAMT.CanGrow = false;
            this.C_P2_4_ETCAMT.Dpi = 100F;
            this.C_P2_4_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 170F);
            this.C_P2_4_ETCAMT.Multiline = true;
            this.C_P2_4_ETCAMT.Name = "C_P2_4_ETCAMT";
            this.C_P2_4_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_4_ETCAMT.Text = "";
            this.C_P2_4_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_4_ETCAMT.WordWrap = false;
            // 
            // C_P2_4_AMT
            // 
            this.C_P2_4_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_4_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_4_AMT.BorderWidth = 0.5F;
            this.C_P2_4_AMT.CanGrow = false;
            this.C_P2_4_AMT.Dpi = 100F;
            this.C_P2_4_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_4_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 170F);
            this.C_P2_4_AMT.Multiline = true;
            this.C_P2_4_AMT.Name = "C_P2_4_AMT";
            this.C_P2_4_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_4_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_4_AMT.Text = "";
            this.C_P2_4_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_4_AMT.WordWrap = false;
            // 
            // L_P2_4_OBJREQ
            // 
            this.L_P2_4_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_4_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_4_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_4_OBJREQ.CanGrow = false;
            this.L_P2_4_OBJREQ.Dpi = 100F;
            this.L_P2_4_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_4_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 170F);
            this.L_P2_4_OBJREQ.Multiline = true;
            this.L_P2_4_OBJREQ.Name = "L_P2_4_OBJREQ";
            this.L_P2_4_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_4_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_4_OBJREQ.Text = "";
            this.L_P2_4_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_4_OBJREQ.WordWrap = false;
            // 
            // L_P2_4_OBJOK
            // 
            this.L_P2_4_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_4_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_4_OBJOK.BorderWidth = 0.5F;
            this.L_P2_4_OBJOK.CanGrow = false;
            this.L_P2_4_OBJOK.Dpi = 100F;
            this.L_P2_4_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_4_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 170F);
            this.L_P2_4_OBJOK.Multiline = true;
            this.L_P2_4_OBJOK.Name = "L_P2_4_OBJOK";
            this.L_P2_4_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_4_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_4_OBJOK.Text = "";
            this.L_P2_4_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_4_OBJOK.WordWrap = false;
            // 
            // L_P2_4_PLAN
            // 
            this.L_P2_4_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_4_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_4_PLAN.BorderWidth = 0.5F;
            this.L_P2_4_PLAN.CanGrow = false;
            this.L_P2_4_PLAN.Dpi = 100F;
            this.L_P2_4_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_4_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 170F);
            this.L_P2_4_PLAN.Multiline = true;
            this.L_P2_4_PLAN.Name = "L_P2_4_PLAN";
            this.L_P2_4_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_4_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_4_PLAN.Text = "";
            this.L_P2_4_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_4_PLAN.WordWrap = false;
            // 
            // L_P2_4_CONF
            // 
            this.L_P2_4_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_4_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_4_CONF.BorderWidth = 0.5F;
            this.L_P2_4_CONF.CanGrow = false;
            this.L_P2_4_CONF.Dpi = 100F;
            this.L_P2_4_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_4_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 170F);
            this.L_P2_4_CONF.Multiline = true;
            this.L_P2_4_CONF.Name = "L_P2_4_CONF";
            this.L_P2_4_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_4_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_4_CONF.Text = "";
            this.L_P2_4_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_4_CONF.WordWrap = false;
            // 
            // L_P2_5_NO
            // 
            this.L_P2_5_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_5_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_5_NO.BorderWidth = 0.5F;
            this.L_P2_5_NO.CanGrow = false;
            this.L_P2_5_NO.Dpi = 100F;
            this.L_P2_5_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_5_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 188F);
            this.L_P2_5_NO.Multiline = true;
            this.L_P2_5_NO.Name = "L_P2_5_NO";
            this.L_P2_5_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_5_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_5_NO.Text = "5";
            this.L_P2_5_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_5_NO.WordWrap = false;
            // 
            // C_P2_5_ITEMCD
            // 
            this.C_P2_5_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_5_ITEMCD.CanGrow = false;
            this.C_P2_5_ITEMCD.Dpi = 100F;
            this.C_P2_5_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 188F);
            this.C_P2_5_ITEMCD.Multiline = true;
            this.C_P2_5_ITEMCD.Name = "C_P2_5_ITEMCD";
            this.C_P2_5_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_5_ITEMCD.Text = "";
            this.C_P2_5_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_5_ITEMCD.WordWrap = false;
            // 
            // C_P2_5_ITEMNM
            // 
            this.C_P2_5_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_5_ITEMNM.CanGrow = false;
            this.C_P2_5_ITEMNM.Dpi = 100F;
            this.C_P2_5_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 188F);
            this.C_P2_5_ITEMNM.Multiline = true;
            this.C_P2_5_ITEMNM.Name = "C_P2_5_ITEMNM";
            this.C_P2_5_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_5_ITEMNM.Text = "";
            this.C_P2_5_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_5_ITEMNM.WordWrap = false;
            // 
            // C_P2_5_BADCONT
            // 
            this.C_P2_5_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_BADCONT.BorderWidth = 0.5F;
            this.C_P2_5_BADCONT.CanGrow = false;
            this.C_P2_5_BADCONT.Dpi = 100F;
            this.C_P2_5_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 188F);
            this.C_P2_5_BADCONT.Multiline = true;
            this.C_P2_5_BADCONT.Name = "C_P2_5_BADCONT";
            this.C_P2_5_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_5_BADCONT.Text = "";
            this.C_P2_5_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_5_BADCONT.WordWrap = false;
            // 
            // C_P2_5_QTY
            // 
            this.C_P2_5_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_QTY.BorderWidth = 0.5F;
            this.C_P2_5_QTY.CanGrow = false;
            this.C_P2_5_QTY.Dpi = 100F;
            this.C_P2_5_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 188F);
            this.C_P2_5_QTY.Multiline = true;
            this.C_P2_5_QTY.Name = "C_P2_5_QTY";
            this.C_P2_5_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_5_QTY.Text = "";
            this.C_P2_5_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_5_QTY.WordWrap = false;
            // 
            // C_P2_5_INPRICE
            // 
            this.C_P2_5_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_INPRICE.BorderWidth = 0.5F;
            this.C_P2_5_INPRICE.CanGrow = false;
            this.C_P2_5_INPRICE.Dpi = 100F;
            this.C_P2_5_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 188F);
            this.C_P2_5_INPRICE.Multiline = true;
            this.C_P2_5_INPRICE.Name = "C_P2_5_INPRICE";
            this.C_P2_5_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_5_INPRICE.Text = "";
            this.C_P2_5_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_5_INPRICE.WordWrap = false;
            // 
            // C_P2_5_MFGPRICE
            // 
            this.C_P2_5_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_5_MFGPRICE.CanGrow = false;
            this.C_P2_5_MFGPRICE.Dpi = 100F;
            this.C_P2_5_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 188F);
            this.C_P2_5_MFGPRICE.Multiline = true;
            this.C_P2_5_MFGPRICE.Name = "C_P2_5_MFGPRICE";
            this.C_P2_5_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_5_MFGPRICE.Text = "";
            this.C_P2_5_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_5_MFGPRICE.WordWrap = false;
            // 
            // C_P2_5_SALEPRICE
            // 
            this.C_P2_5_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_5_SALEPRICE.CanGrow = false;
            this.C_P2_5_SALEPRICE.Dpi = 100F;
            this.C_P2_5_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 188F);
            this.C_P2_5_SALEPRICE.Multiline = true;
            this.C_P2_5_SALEPRICE.Name = "C_P2_5_SALEPRICE";
            this.C_P2_5_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_5_SALEPRICE.Text = "";
            this.C_P2_5_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_5_SALEPRICE.WordWrap = false;
            // 
            // C_P2_5_ETCAMT
            // 
            this.C_P2_5_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_5_ETCAMT.CanGrow = false;
            this.C_P2_5_ETCAMT.Dpi = 100F;
            this.C_P2_5_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 188F);
            this.C_P2_5_ETCAMT.Multiline = true;
            this.C_P2_5_ETCAMT.Name = "C_P2_5_ETCAMT";
            this.C_P2_5_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_5_ETCAMT.Text = "";
            this.C_P2_5_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_5_ETCAMT.WordWrap = false;
            // 
            // C_P2_5_AMT
            // 
            this.C_P2_5_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_5_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_5_AMT.BorderWidth = 0.5F;
            this.C_P2_5_AMT.CanGrow = false;
            this.C_P2_5_AMT.Dpi = 100F;
            this.C_P2_5_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_5_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 188F);
            this.C_P2_5_AMT.Multiline = true;
            this.C_P2_5_AMT.Name = "C_P2_5_AMT";
            this.C_P2_5_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_5_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_5_AMT.Text = "";
            this.C_P2_5_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_5_AMT.WordWrap = false;
            // 
            // L_P2_5_OBJREQ
            // 
            this.L_P2_5_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_5_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_5_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_5_OBJREQ.CanGrow = false;
            this.L_P2_5_OBJREQ.Dpi = 100F;
            this.L_P2_5_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_5_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 188F);
            this.L_P2_5_OBJREQ.Multiline = true;
            this.L_P2_5_OBJREQ.Name = "L_P2_5_OBJREQ";
            this.L_P2_5_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_5_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_5_OBJREQ.Text = "";
            this.L_P2_5_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_5_OBJREQ.WordWrap = false;
            // 
            // L_P2_5_OBJOK
            // 
            this.L_P2_5_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_5_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_5_OBJOK.BorderWidth = 0.5F;
            this.L_P2_5_OBJOK.CanGrow = false;
            this.L_P2_5_OBJOK.Dpi = 100F;
            this.L_P2_5_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_5_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 188F);
            this.L_P2_5_OBJOK.Multiline = true;
            this.L_P2_5_OBJOK.Name = "L_P2_5_OBJOK";
            this.L_P2_5_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_5_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_5_OBJOK.Text = "";
            this.L_P2_5_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_5_OBJOK.WordWrap = false;
            // 
            // L_P2_5_PLAN
            // 
            this.L_P2_5_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_5_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_5_PLAN.BorderWidth = 0.5F;
            this.L_P2_5_PLAN.CanGrow = false;
            this.L_P2_5_PLAN.Dpi = 100F;
            this.L_P2_5_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_5_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 188F);
            this.L_P2_5_PLAN.Multiline = true;
            this.L_P2_5_PLAN.Name = "L_P2_5_PLAN";
            this.L_P2_5_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_5_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_5_PLAN.Text = "";
            this.L_P2_5_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_5_PLAN.WordWrap = false;
            // 
            // L_P2_5_CONF
            // 
            this.L_P2_5_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_5_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_5_CONF.BorderWidth = 0.5F;
            this.L_P2_5_CONF.CanGrow = false;
            this.L_P2_5_CONF.Dpi = 100F;
            this.L_P2_5_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_5_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 188F);
            this.L_P2_5_CONF.Multiline = true;
            this.L_P2_5_CONF.Name = "L_P2_5_CONF";
            this.L_P2_5_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_5_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_5_CONF.Text = "";
            this.L_P2_5_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_5_CONF.WordWrap = false;
            // 
            // L_P2_6_NO
            // 
            this.L_P2_6_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_6_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_6_NO.BorderWidth = 0.5F;
            this.L_P2_6_NO.CanGrow = false;
            this.L_P2_6_NO.Dpi = 100F;
            this.L_P2_6_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_6_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 206F);
            this.L_P2_6_NO.Multiline = true;
            this.L_P2_6_NO.Name = "L_P2_6_NO";
            this.L_P2_6_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_6_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_6_NO.Text = "6";
            this.L_P2_6_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_6_NO.WordWrap = false;
            // 
            // C_P2_6_ITEMCD
            // 
            this.C_P2_6_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_6_ITEMCD.CanGrow = false;
            this.C_P2_6_ITEMCD.Dpi = 100F;
            this.C_P2_6_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 206F);
            this.C_P2_6_ITEMCD.Multiline = true;
            this.C_P2_6_ITEMCD.Name = "C_P2_6_ITEMCD";
            this.C_P2_6_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_6_ITEMCD.Text = "";
            this.C_P2_6_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_6_ITEMCD.WordWrap = false;
            // 
            // C_P2_6_ITEMNM
            // 
            this.C_P2_6_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_6_ITEMNM.CanGrow = false;
            this.C_P2_6_ITEMNM.Dpi = 100F;
            this.C_P2_6_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 206F);
            this.C_P2_6_ITEMNM.Multiline = true;
            this.C_P2_6_ITEMNM.Name = "C_P2_6_ITEMNM";
            this.C_P2_6_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_6_ITEMNM.Text = "";
            this.C_P2_6_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_6_ITEMNM.WordWrap = false;
            // 
            // C_P2_6_BADCONT
            // 
            this.C_P2_6_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_BADCONT.BorderWidth = 0.5F;
            this.C_P2_6_BADCONT.CanGrow = false;
            this.C_P2_6_BADCONT.Dpi = 100F;
            this.C_P2_6_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 206F);
            this.C_P2_6_BADCONT.Multiline = true;
            this.C_P2_6_BADCONT.Name = "C_P2_6_BADCONT";
            this.C_P2_6_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_6_BADCONT.Text = "";
            this.C_P2_6_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_6_BADCONT.WordWrap = false;
            // 
            // C_P2_6_QTY
            // 
            this.C_P2_6_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_QTY.BorderWidth = 0.5F;
            this.C_P2_6_QTY.CanGrow = false;
            this.C_P2_6_QTY.Dpi = 100F;
            this.C_P2_6_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 206F);
            this.C_P2_6_QTY.Multiline = true;
            this.C_P2_6_QTY.Name = "C_P2_6_QTY";
            this.C_P2_6_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_6_QTY.Text = "";
            this.C_P2_6_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_6_QTY.WordWrap = false;
            // 
            // C_P2_6_INPRICE
            // 
            this.C_P2_6_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_INPRICE.BorderWidth = 0.5F;
            this.C_P2_6_INPRICE.CanGrow = false;
            this.C_P2_6_INPRICE.Dpi = 100F;
            this.C_P2_6_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 206F);
            this.C_P2_6_INPRICE.Multiline = true;
            this.C_P2_6_INPRICE.Name = "C_P2_6_INPRICE";
            this.C_P2_6_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_6_INPRICE.Text = "";
            this.C_P2_6_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_6_INPRICE.WordWrap = false;
            // 
            // C_P2_6_MFGPRICE
            // 
            this.C_P2_6_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_6_MFGPRICE.CanGrow = false;
            this.C_P2_6_MFGPRICE.Dpi = 100F;
            this.C_P2_6_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 206F);
            this.C_P2_6_MFGPRICE.Multiline = true;
            this.C_P2_6_MFGPRICE.Name = "C_P2_6_MFGPRICE";
            this.C_P2_6_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_6_MFGPRICE.Text = "";
            this.C_P2_6_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_6_MFGPRICE.WordWrap = false;
            // 
            // C_P2_6_SALEPRICE
            // 
            this.C_P2_6_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_6_SALEPRICE.CanGrow = false;
            this.C_P2_6_SALEPRICE.Dpi = 100F;
            this.C_P2_6_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 206F);
            this.C_P2_6_SALEPRICE.Multiline = true;
            this.C_P2_6_SALEPRICE.Name = "C_P2_6_SALEPRICE";
            this.C_P2_6_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_6_SALEPRICE.Text = "";
            this.C_P2_6_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_6_SALEPRICE.WordWrap = false;
            // 
            // C_P2_6_ETCAMT
            // 
            this.C_P2_6_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_6_ETCAMT.CanGrow = false;
            this.C_P2_6_ETCAMT.Dpi = 100F;
            this.C_P2_6_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 206F);
            this.C_P2_6_ETCAMT.Multiline = true;
            this.C_P2_6_ETCAMT.Name = "C_P2_6_ETCAMT";
            this.C_P2_6_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_6_ETCAMT.Text = "";
            this.C_P2_6_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_6_ETCAMT.WordWrap = false;
            // 
            // C_P2_6_AMT
            // 
            this.C_P2_6_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_6_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_6_AMT.BorderWidth = 0.5F;
            this.C_P2_6_AMT.CanGrow = false;
            this.C_P2_6_AMT.Dpi = 100F;
            this.C_P2_6_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_6_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 206F);
            this.C_P2_6_AMT.Multiline = true;
            this.C_P2_6_AMT.Name = "C_P2_6_AMT";
            this.C_P2_6_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_6_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_6_AMT.Text = "";
            this.C_P2_6_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_6_AMT.WordWrap = false;
            // 
            // L_P2_6_OBJREQ
            // 
            this.L_P2_6_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_6_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_6_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_6_OBJREQ.CanGrow = false;
            this.L_P2_6_OBJREQ.Dpi = 100F;
            this.L_P2_6_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_6_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 206F);
            this.L_P2_6_OBJREQ.Multiline = true;
            this.L_P2_6_OBJREQ.Name = "L_P2_6_OBJREQ";
            this.L_P2_6_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_6_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_6_OBJREQ.Text = "";
            this.L_P2_6_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_6_OBJREQ.WordWrap = false;
            // 
            // L_P2_6_OBJOK
            // 
            this.L_P2_6_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_6_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_6_OBJOK.BorderWidth = 0.5F;
            this.L_P2_6_OBJOK.CanGrow = false;
            this.L_P2_6_OBJOK.Dpi = 100F;
            this.L_P2_6_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_6_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 206F);
            this.L_P2_6_OBJOK.Multiline = true;
            this.L_P2_6_OBJOK.Name = "L_P2_6_OBJOK";
            this.L_P2_6_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_6_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_6_OBJOK.Text = "";
            this.L_P2_6_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_6_OBJOK.WordWrap = false;
            // 
            // L_P2_6_PLAN
            // 
            this.L_P2_6_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_6_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_6_PLAN.BorderWidth = 0.5F;
            this.L_P2_6_PLAN.CanGrow = false;
            this.L_P2_6_PLAN.Dpi = 100F;
            this.L_P2_6_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_6_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 206F);
            this.L_P2_6_PLAN.Multiline = true;
            this.L_P2_6_PLAN.Name = "L_P2_6_PLAN";
            this.L_P2_6_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_6_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_6_PLAN.Text = "";
            this.L_P2_6_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_6_PLAN.WordWrap = false;
            // 
            // L_P2_6_CONF
            // 
            this.L_P2_6_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_6_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_6_CONF.BorderWidth = 0.5F;
            this.L_P2_6_CONF.CanGrow = false;
            this.L_P2_6_CONF.Dpi = 100F;
            this.L_P2_6_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_6_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 206F);
            this.L_P2_6_CONF.Multiline = true;
            this.L_P2_6_CONF.Name = "L_P2_6_CONF";
            this.L_P2_6_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_6_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_6_CONF.Text = "";
            this.L_P2_6_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_6_CONF.WordWrap = false;
            // 
            // L_P2_7_NO
            // 
            this.L_P2_7_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_7_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_7_NO.BorderWidth = 0.5F;
            this.L_P2_7_NO.CanGrow = false;
            this.L_P2_7_NO.Dpi = 100F;
            this.L_P2_7_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_7_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 224F);
            this.L_P2_7_NO.Multiline = true;
            this.L_P2_7_NO.Name = "L_P2_7_NO";
            this.L_P2_7_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_7_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_7_NO.Text = "7";
            this.L_P2_7_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_7_NO.WordWrap = false;
            // 
            // C_P2_7_ITEMCD
            // 
            this.C_P2_7_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_7_ITEMCD.CanGrow = false;
            this.C_P2_7_ITEMCD.Dpi = 100F;
            this.C_P2_7_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 224F);
            this.C_P2_7_ITEMCD.Multiline = true;
            this.C_P2_7_ITEMCD.Name = "C_P2_7_ITEMCD";
            this.C_P2_7_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_7_ITEMCD.Text = "";
            this.C_P2_7_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_7_ITEMCD.WordWrap = false;
            // 
            // C_P2_7_ITEMNM
            // 
            this.C_P2_7_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_7_ITEMNM.CanGrow = false;
            this.C_P2_7_ITEMNM.Dpi = 100F;
            this.C_P2_7_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 224F);
            this.C_P2_7_ITEMNM.Multiline = true;
            this.C_P2_7_ITEMNM.Name = "C_P2_7_ITEMNM";
            this.C_P2_7_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_7_ITEMNM.Text = "";
            this.C_P2_7_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_7_ITEMNM.WordWrap = false;
            // 
            // C_P2_7_BADCONT
            // 
            this.C_P2_7_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_BADCONT.BorderWidth = 0.5F;
            this.C_P2_7_BADCONT.CanGrow = false;
            this.C_P2_7_BADCONT.Dpi = 100F;
            this.C_P2_7_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 224F);
            this.C_P2_7_BADCONT.Multiline = true;
            this.C_P2_7_BADCONT.Name = "C_P2_7_BADCONT";
            this.C_P2_7_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_7_BADCONT.Text = "";
            this.C_P2_7_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_7_BADCONT.WordWrap = false;
            // 
            // C_P2_7_QTY
            // 
            this.C_P2_7_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_QTY.BorderWidth = 0.5F;
            this.C_P2_7_QTY.CanGrow = false;
            this.C_P2_7_QTY.Dpi = 100F;
            this.C_P2_7_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 224F);
            this.C_P2_7_QTY.Multiline = true;
            this.C_P2_7_QTY.Name = "C_P2_7_QTY";
            this.C_P2_7_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_7_QTY.Text = "";
            this.C_P2_7_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_7_QTY.WordWrap = false;
            // 
            // C_P2_7_INPRICE
            // 
            this.C_P2_7_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_INPRICE.BorderWidth = 0.5F;
            this.C_P2_7_INPRICE.CanGrow = false;
            this.C_P2_7_INPRICE.Dpi = 100F;
            this.C_P2_7_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 224F);
            this.C_P2_7_INPRICE.Multiline = true;
            this.C_P2_7_INPRICE.Name = "C_P2_7_INPRICE";
            this.C_P2_7_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_7_INPRICE.Text = "";
            this.C_P2_7_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_7_INPRICE.WordWrap = false;
            // 
            // C_P2_7_MFGPRICE
            // 
            this.C_P2_7_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_7_MFGPRICE.CanGrow = false;
            this.C_P2_7_MFGPRICE.Dpi = 100F;
            this.C_P2_7_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 224F);
            this.C_P2_7_MFGPRICE.Multiline = true;
            this.C_P2_7_MFGPRICE.Name = "C_P2_7_MFGPRICE";
            this.C_P2_7_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_7_MFGPRICE.Text = "";
            this.C_P2_7_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_7_MFGPRICE.WordWrap = false;
            // 
            // C_P2_7_SALEPRICE
            // 
            this.C_P2_7_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_7_SALEPRICE.CanGrow = false;
            this.C_P2_7_SALEPRICE.Dpi = 100F;
            this.C_P2_7_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 224F);
            this.C_P2_7_SALEPRICE.Multiline = true;
            this.C_P2_7_SALEPRICE.Name = "C_P2_7_SALEPRICE";
            this.C_P2_7_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_7_SALEPRICE.Text = "";
            this.C_P2_7_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_7_SALEPRICE.WordWrap = false;
            // 
            // C_P2_7_ETCAMT
            // 
            this.C_P2_7_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_7_ETCAMT.CanGrow = false;
            this.C_P2_7_ETCAMT.Dpi = 100F;
            this.C_P2_7_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 224F);
            this.C_P2_7_ETCAMT.Multiline = true;
            this.C_P2_7_ETCAMT.Name = "C_P2_7_ETCAMT";
            this.C_P2_7_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_7_ETCAMT.Text = "";
            this.C_P2_7_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_7_ETCAMT.WordWrap = false;
            // 
            // C_P2_7_AMT
            // 
            this.C_P2_7_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_7_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_7_AMT.BorderWidth = 0.5F;
            this.C_P2_7_AMT.CanGrow = false;
            this.C_P2_7_AMT.Dpi = 100F;
            this.C_P2_7_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_7_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 224F);
            this.C_P2_7_AMT.Multiline = true;
            this.C_P2_7_AMT.Name = "C_P2_7_AMT";
            this.C_P2_7_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_7_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_7_AMT.Text = "";
            this.C_P2_7_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_7_AMT.WordWrap = false;
            // 
            // L_P2_7_OBJREQ
            // 
            this.L_P2_7_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_7_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_7_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_7_OBJREQ.CanGrow = false;
            this.L_P2_7_OBJREQ.Dpi = 100F;
            this.L_P2_7_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_7_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 224F);
            this.L_P2_7_OBJREQ.Multiline = true;
            this.L_P2_7_OBJREQ.Name = "L_P2_7_OBJREQ";
            this.L_P2_7_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_7_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_7_OBJREQ.Text = "";
            this.L_P2_7_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_7_OBJREQ.WordWrap = false;
            // 
            // L_P2_7_OBJOK
            // 
            this.L_P2_7_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_7_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_7_OBJOK.BorderWidth = 0.5F;
            this.L_P2_7_OBJOK.CanGrow = false;
            this.L_P2_7_OBJOK.Dpi = 100F;
            this.L_P2_7_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_7_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 224F);
            this.L_P2_7_OBJOK.Multiline = true;
            this.L_P2_7_OBJOK.Name = "L_P2_7_OBJOK";
            this.L_P2_7_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_7_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_7_OBJOK.Text = "";
            this.L_P2_7_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_7_OBJOK.WordWrap = false;
            // 
            // L_P2_7_PLAN
            // 
            this.L_P2_7_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_7_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_7_PLAN.BorderWidth = 0.5F;
            this.L_P2_7_PLAN.CanGrow = false;
            this.L_P2_7_PLAN.Dpi = 100F;
            this.L_P2_7_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_7_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 224F);
            this.L_P2_7_PLAN.Multiline = true;
            this.L_P2_7_PLAN.Name = "L_P2_7_PLAN";
            this.L_P2_7_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_7_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_7_PLAN.Text = "";
            this.L_P2_7_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_7_PLAN.WordWrap = false;
            // 
            // L_P2_7_CONF
            // 
            this.L_P2_7_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_7_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_7_CONF.BorderWidth = 0.5F;
            this.L_P2_7_CONF.CanGrow = false;
            this.L_P2_7_CONF.Dpi = 100F;
            this.L_P2_7_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_7_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 224F);
            this.L_P2_7_CONF.Multiline = true;
            this.L_P2_7_CONF.Name = "L_P2_7_CONF";
            this.L_P2_7_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_7_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_7_CONF.Text = "";
            this.L_P2_7_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_7_CONF.WordWrap = false;
            // 
            // L_P2_8_NO
            // 
            this.L_P2_8_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_8_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_8_NO.BorderWidth = 0.5F;
            this.L_P2_8_NO.CanGrow = false;
            this.L_P2_8_NO.Dpi = 100F;
            this.L_P2_8_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_8_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 242F);
            this.L_P2_8_NO.Multiline = true;
            this.L_P2_8_NO.Name = "L_P2_8_NO";
            this.L_P2_8_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_8_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_8_NO.Text = "8";
            this.L_P2_8_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_8_NO.WordWrap = false;
            // 
            // C_P2_8_ITEMCD
            // 
            this.C_P2_8_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_8_ITEMCD.CanGrow = false;
            this.C_P2_8_ITEMCD.Dpi = 100F;
            this.C_P2_8_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 242F);
            this.C_P2_8_ITEMCD.Multiline = true;
            this.C_P2_8_ITEMCD.Name = "C_P2_8_ITEMCD";
            this.C_P2_8_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_8_ITEMCD.Text = "";
            this.C_P2_8_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_8_ITEMCD.WordWrap = false;
            // 
            // C_P2_8_ITEMNM
            // 
            this.C_P2_8_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_8_ITEMNM.CanGrow = false;
            this.C_P2_8_ITEMNM.Dpi = 100F;
            this.C_P2_8_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 242F);
            this.C_P2_8_ITEMNM.Multiline = true;
            this.C_P2_8_ITEMNM.Name = "C_P2_8_ITEMNM";
            this.C_P2_8_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_8_ITEMNM.Text = "";
            this.C_P2_8_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_8_ITEMNM.WordWrap = false;
            // 
            // C_P2_8_BADCONT
            // 
            this.C_P2_8_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_BADCONT.BorderWidth = 0.5F;
            this.C_P2_8_BADCONT.CanGrow = false;
            this.C_P2_8_BADCONT.Dpi = 100F;
            this.C_P2_8_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 242F);
            this.C_P2_8_BADCONT.Multiline = true;
            this.C_P2_8_BADCONT.Name = "C_P2_8_BADCONT";
            this.C_P2_8_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_8_BADCONT.Text = "";
            this.C_P2_8_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_8_BADCONT.WordWrap = false;
            // 
            // C_P2_8_QTY
            // 
            this.C_P2_8_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_QTY.BorderWidth = 0.5F;
            this.C_P2_8_QTY.CanGrow = false;
            this.C_P2_8_QTY.Dpi = 100F;
            this.C_P2_8_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 242F);
            this.C_P2_8_QTY.Multiline = true;
            this.C_P2_8_QTY.Name = "C_P2_8_QTY";
            this.C_P2_8_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_8_QTY.Text = "";
            this.C_P2_8_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_8_QTY.WordWrap = false;
            // 
            // C_P2_8_INPRICE
            // 
            this.C_P2_8_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_INPRICE.BorderWidth = 0.5F;
            this.C_P2_8_INPRICE.CanGrow = false;
            this.C_P2_8_INPRICE.Dpi = 100F;
            this.C_P2_8_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 242F);
            this.C_P2_8_INPRICE.Multiline = true;
            this.C_P2_8_INPRICE.Name = "C_P2_8_INPRICE";
            this.C_P2_8_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_8_INPRICE.Text = "";
            this.C_P2_8_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_8_INPRICE.WordWrap = false;
            // 
            // C_P2_8_MFGPRICE
            // 
            this.C_P2_8_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_8_MFGPRICE.CanGrow = false;
            this.C_P2_8_MFGPRICE.Dpi = 100F;
            this.C_P2_8_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 242F);
            this.C_P2_8_MFGPRICE.Multiline = true;
            this.C_P2_8_MFGPRICE.Name = "C_P2_8_MFGPRICE";
            this.C_P2_8_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_8_MFGPRICE.Text = "";
            this.C_P2_8_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_8_MFGPRICE.WordWrap = false;
            // 
            // C_P2_8_SALEPRICE
            // 
            this.C_P2_8_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_8_SALEPRICE.CanGrow = false;
            this.C_P2_8_SALEPRICE.Dpi = 100F;
            this.C_P2_8_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 242F);
            this.C_P2_8_SALEPRICE.Multiline = true;
            this.C_P2_8_SALEPRICE.Name = "C_P2_8_SALEPRICE";
            this.C_P2_8_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_8_SALEPRICE.Text = "";
            this.C_P2_8_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_8_SALEPRICE.WordWrap = false;
            // 
            // C_P2_8_ETCAMT
            // 
            this.C_P2_8_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_8_ETCAMT.CanGrow = false;
            this.C_P2_8_ETCAMT.Dpi = 100F;
            this.C_P2_8_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 242F);
            this.C_P2_8_ETCAMT.Multiline = true;
            this.C_P2_8_ETCAMT.Name = "C_P2_8_ETCAMT";
            this.C_P2_8_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_8_ETCAMT.Text = "";
            this.C_P2_8_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_8_ETCAMT.WordWrap = false;
            // 
            // C_P2_8_AMT
            // 
            this.C_P2_8_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_8_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_8_AMT.BorderWidth = 0.5F;
            this.C_P2_8_AMT.CanGrow = false;
            this.C_P2_8_AMT.Dpi = 100F;
            this.C_P2_8_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_8_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 242F);
            this.C_P2_8_AMT.Multiline = true;
            this.C_P2_8_AMT.Name = "C_P2_8_AMT";
            this.C_P2_8_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_8_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_8_AMT.Text = "";
            this.C_P2_8_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_8_AMT.WordWrap = false;
            // 
            // L_P2_8_OBJREQ
            // 
            this.L_P2_8_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_8_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_8_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_8_OBJREQ.CanGrow = false;
            this.L_P2_8_OBJREQ.Dpi = 100F;
            this.L_P2_8_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_8_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 242F);
            this.L_P2_8_OBJREQ.Multiline = true;
            this.L_P2_8_OBJREQ.Name = "L_P2_8_OBJREQ";
            this.L_P2_8_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_8_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_8_OBJREQ.Text = "";
            this.L_P2_8_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_8_OBJREQ.WordWrap = false;
            // 
            // L_P2_8_OBJOK
            // 
            this.L_P2_8_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_8_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_8_OBJOK.BorderWidth = 0.5F;
            this.L_P2_8_OBJOK.CanGrow = false;
            this.L_P2_8_OBJOK.Dpi = 100F;
            this.L_P2_8_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_8_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 242F);
            this.L_P2_8_OBJOK.Multiline = true;
            this.L_P2_8_OBJOK.Name = "L_P2_8_OBJOK";
            this.L_P2_8_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_8_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_8_OBJOK.Text = "";
            this.L_P2_8_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_8_OBJOK.WordWrap = false;
            // 
            // L_P2_8_PLAN
            // 
            this.L_P2_8_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_8_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_8_PLAN.BorderWidth = 0.5F;
            this.L_P2_8_PLAN.CanGrow = false;
            this.L_P2_8_PLAN.Dpi = 100F;
            this.L_P2_8_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_8_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 242F);
            this.L_P2_8_PLAN.Multiline = true;
            this.L_P2_8_PLAN.Name = "L_P2_8_PLAN";
            this.L_P2_8_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_8_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_8_PLAN.Text = "";
            this.L_P2_8_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_8_PLAN.WordWrap = false;
            // 
            // L_P2_8_CONF
            // 
            this.L_P2_8_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_8_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_8_CONF.BorderWidth = 0.5F;
            this.L_P2_8_CONF.CanGrow = false;
            this.L_P2_8_CONF.Dpi = 100F;
            this.L_P2_8_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_8_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 242F);
            this.L_P2_8_CONF.Multiline = true;
            this.L_P2_8_CONF.Name = "L_P2_8_CONF";
            this.L_P2_8_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_8_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_8_CONF.Text = "";
            this.L_P2_8_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_8_CONF.WordWrap = false;
            // 
            // L_P2_9_NO
            // 
            this.L_P2_9_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_9_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_9_NO.BorderWidth = 0.5F;
            this.L_P2_9_NO.CanGrow = false;
            this.L_P2_9_NO.Dpi = 100F;
            this.L_P2_9_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_9_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 260F);
            this.L_P2_9_NO.Multiline = true;
            this.L_P2_9_NO.Name = "L_P2_9_NO";
            this.L_P2_9_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_9_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_9_NO.Text = "9";
            this.L_P2_9_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_9_NO.WordWrap = false;
            // 
            // C_P2_9_ITEMCD
            // 
            this.C_P2_9_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_9_ITEMCD.CanGrow = false;
            this.C_P2_9_ITEMCD.Dpi = 100F;
            this.C_P2_9_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 260F);
            this.C_P2_9_ITEMCD.Multiline = true;
            this.C_P2_9_ITEMCD.Name = "C_P2_9_ITEMCD";
            this.C_P2_9_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_9_ITEMCD.Text = "";
            this.C_P2_9_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_9_ITEMCD.WordWrap = false;
            // 
            // C_P2_9_ITEMNM
            // 
            this.C_P2_9_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_9_ITEMNM.CanGrow = false;
            this.C_P2_9_ITEMNM.Dpi = 100F;
            this.C_P2_9_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 260F);
            this.C_P2_9_ITEMNM.Multiline = true;
            this.C_P2_9_ITEMNM.Name = "C_P2_9_ITEMNM";
            this.C_P2_9_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_9_ITEMNM.Text = "";
            this.C_P2_9_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_9_ITEMNM.WordWrap = false;
            // 
            // C_P2_9_BADCONT
            // 
            this.C_P2_9_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_BADCONT.BorderWidth = 0.5F;
            this.C_P2_9_BADCONT.CanGrow = false;
            this.C_P2_9_BADCONT.Dpi = 100F;
            this.C_P2_9_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 260F);
            this.C_P2_9_BADCONT.Multiline = true;
            this.C_P2_9_BADCONT.Name = "C_P2_9_BADCONT";
            this.C_P2_9_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_9_BADCONT.Text = "";
            this.C_P2_9_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_9_BADCONT.WordWrap = false;
            // 
            // C_P2_9_QTY
            // 
            this.C_P2_9_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_QTY.BorderWidth = 0.5F;
            this.C_P2_9_QTY.CanGrow = false;
            this.C_P2_9_QTY.Dpi = 100F;
            this.C_P2_9_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 260F);
            this.C_P2_9_QTY.Multiline = true;
            this.C_P2_9_QTY.Name = "C_P2_9_QTY";
            this.C_P2_9_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_9_QTY.Text = "";
            this.C_P2_9_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_9_QTY.WordWrap = false;
            // 
            // C_P2_9_INPRICE
            // 
            this.C_P2_9_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_INPRICE.BorderWidth = 0.5F;
            this.C_P2_9_INPRICE.CanGrow = false;
            this.C_P2_9_INPRICE.Dpi = 100F;
            this.C_P2_9_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 260F);
            this.C_P2_9_INPRICE.Multiline = true;
            this.C_P2_9_INPRICE.Name = "C_P2_9_INPRICE";
            this.C_P2_9_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_9_INPRICE.Text = "";
            this.C_P2_9_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_9_INPRICE.WordWrap = false;
            // 
            // C_P2_9_MFGPRICE
            // 
            this.C_P2_9_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_9_MFGPRICE.CanGrow = false;
            this.C_P2_9_MFGPRICE.Dpi = 100F;
            this.C_P2_9_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 260F);
            this.C_P2_9_MFGPRICE.Multiline = true;
            this.C_P2_9_MFGPRICE.Name = "C_P2_9_MFGPRICE";
            this.C_P2_9_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_9_MFGPRICE.Text = "";
            this.C_P2_9_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_9_MFGPRICE.WordWrap = false;
            // 
            // C_P2_9_SALEPRICE
            // 
            this.C_P2_9_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_9_SALEPRICE.CanGrow = false;
            this.C_P2_9_SALEPRICE.Dpi = 100F;
            this.C_P2_9_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 260F);
            this.C_P2_9_SALEPRICE.Multiline = true;
            this.C_P2_9_SALEPRICE.Name = "C_P2_9_SALEPRICE";
            this.C_P2_9_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_9_SALEPRICE.Text = "";
            this.C_P2_9_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_9_SALEPRICE.WordWrap = false;
            // 
            // C_P2_9_ETCAMT
            // 
            this.C_P2_9_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_9_ETCAMT.CanGrow = false;
            this.C_P2_9_ETCAMT.Dpi = 100F;
            this.C_P2_9_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 260F);
            this.C_P2_9_ETCAMT.Multiline = true;
            this.C_P2_9_ETCAMT.Name = "C_P2_9_ETCAMT";
            this.C_P2_9_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_9_ETCAMT.Text = "";
            this.C_P2_9_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_9_ETCAMT.WordWrap = false;
            // 
            // C_P2_9_AMT
            // 
            this.C_P2_9_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_9_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_9_AMT.BorderWidth = 0.5F;
            this.C_P2_9_AMT.CanGrow = false;
            this.C_P2_9_AMT.Dpi = 100F;
            this.C_P2_9_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_9_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 260F);
            this.C_P2_9_AMT.Multiline = true;
            this.C_P2_9_AMT.Name = "C_P2_9_AMT";
            this.C_P2_9_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_9_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_9_AMT.Text = "";
            this.C_P2_9_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_9_AMT.WordWrap = false;
            // 
            // L_P2_9_OBJREQ
            // 
            this.L_P2_9_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_9_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_9_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_9_OBJREQ.CanGrow = false;
            this.L_P2_9_OBJREQ.Dpi = 100F;
            this.L_P2_9_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_9_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 260F);
            this.L_P2_9_OBJREQ.Multiline = true;
            this.L_P2_9_OBJREQ.Name = "L_P2_9_OBJREQ";
            this.L_P2_9_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_9_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_9_OBJREQ.Text = "";
            this.L_P2_9_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_9_OBJREQ.WordWrap = false;
            // 
            // L_P2_9_OBJOK
            // 
            this.L_P2_9_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_9_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_9_OBJOK.BorderWidth = 0.5F;
            this.L_P2_9_OBJOK.CanGrow = false;
            this.L_P2_9_OBJOK.Dpi = 100F;
            this.L_P2_9_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_9_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 260F);
            this.L_P2_9_OBJOK.Multiline = true;
            this.L_P2_9_OBJOK.Name = "L_P2_9_OBJOK";
            this.L_P2_9_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_9_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_9_OBJOK.Text = "";
            this.L_P2_9_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_9_OBJOK.WordWrap = false;
            // 
            // L_P2_9_PLAN
            // 
            this.L_P2_9_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_9_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_9_PLAN.BorderWidth = 0.5F;
            this.L_P2_9_PLAN.CanGrow = false;
            this.L_P2_9_PLAN.Dpi = 100F;
            this.L_P2_9_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_9_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 260F);
            this.L_P2_9_PLAN.Multiline = true;
            this.L_P2_9_PLAN.Name = "L_P2_9_PLAN";
            this.L_P2_9_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_9_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_9_PLAN.Text = "";
            this.L_P2_9_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_9_PLAN.WordWrap = false;
            // 
            // L_P2_9_CONF
            // 
            this.L_P2_9_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_9_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_9_CONF.BorderWidth = 0.5F;
            this.L_P2_9_CONF.CanGrow = false;
            this.L_P2_9_CONF.Dpi = 100F;
            this.L_P2_9_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_9_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 260F);
            this.L_P2_9_CONF.Multiline = true;
            this.L_P2_9_CONF.Name = "L_P2_9_CONF";
            this.L_P2_9_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_9_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_9_CONF.Text = "";
            this.L_P2_9_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_9_CONF.WordWrap = false;
            // 
            // L_P2_10_NO
            // 
            this.L_P2_10_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_10_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_10_NO.BorderWidth = 0.5F;
            this.L_P2_10_NO.CanGrow = false;
            this.L_P2_10_NO.Dpi = 100F;
            this.L_P2_10_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_10_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 278F);
            this.L_P2_10_NO.Multiline = true;
            this.L_P2_10_NO.Name = "L_P2_10_NO";
            this.L_P2_10_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_10_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_10_NO.Text = "10";
            this.L_P2_10_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_10_NO.WordWrap = false;
            // 
            // C_P2_10_ITEMCD
            // 
            this.C_P2_10_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_10_ITEMCD.CanGrow = false;
            this.C_P2_10_ITEMCD.Dpi = 100F;
            this.C_P2_10_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 278F);
            this.C_P2_10_ITEMCD.Multiline = true;
            this.C_P2_10_ITEMCD.Name = "C_P2_10_ITEMCD";
            this.C_P2_10_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_10_ITEMCD.Text = "";
            this.C_P2_10_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_10_ITEMCD.WordWrap = false;
            // 
            // C_P2_10_ITEMNM
            // 
            this.C_P2_10_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_10_ITEMNM.CanGrow = false;
            this.C_P2_10_ITEMNM.Dpi = 100F;
            this.C_P2_10_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 278F);
            this.C_P2_10_ITEMNM.Multiline = true;
            this.C_P2_10_ITEMNM.Name = "C_P2_10_ITEMNM";
            this.C_P2_10_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_10_ITEMNM.Text = "";
            this.C_P2_10_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_10_ITEMNM.WordWrap = false;
            // 
            // C_P2_10_BADCONT
            // 
            this.C_P2_10_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_BADCONT.BorderWidth = 0.5F;
            this.C_P2_10_BADCONT.CanGrow = false;
            this.C_P2_10_BADCONT.Dpi = 100F;
            this.C_P2_10_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 278F);
            this.C_P2_10_BADCONT.Multiline = true;
            this.C_P2_10_BADCONT.Name = "C_P2_10_BADCONT";
            this.C_P2_10_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_10_BADCONT.Text = "";
            this.C_P2_10_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_10_BADCONT.WordWrap = false;
            // 
            // C_P2_10_QTY
            // 
            this.C_P2_10_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_QTY.BorderWidth = 0.5F;
            this.C_P2_10_QTY.CanGrow = false;
            this.C_P2_10_QTY.Dpi = 100F;
            this.C_P2_10_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 278F);
            this.C_P2_10_QTY.Multiline = true;
            this.C_P2_10_QTY.Name = "C_P2_10_QTY";
            this.C_P2_10_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_10_QTY.Text = "";
            this.C_P2_10_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_10_QTY.WordWrap = false;
            // 
            // C_P2_10_INPRICE
            // 
            this.C_P2_10_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_INPRICE.BorderWidth = 0.5F;
            this.C_P2_10_INPRICE.CanGrow = false;
            this.C_P2_10_INPRICE.Dpi = 100F;
            this.C_P2_10_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 278F);
            this.C_P2_10_INPRICE.Multiline = true;
            this.C_P2_10_INPRICE.Name = "C_P2_10_INPRICE";
            this.C_P2_10_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_10_INPRICE.Text = "";
            this.C_P2_10_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_10_INPRICE.WordWrap = false;
            // 
            // C_P2_10_MFGPRICE
            // 
            this.C_P2_10_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_10_MFGPRICE.CanGrow = false;
            this.C_P2_10_MFGPRICE.Dpi = 100F;
            this.C_P2_10_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 278F);
            this.C_P2_10_MFGPRICE.Multiline = true;
            this.C_P2_10_MFGPRICE.Name = "C_P2_10_MFGPRICE";
            this.C_P2_10_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_10_MFGPRICE.Text = "";
            this.C_P2_10_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_10_MFGPRICE.WordWrap = false;
            // 
            // C_P2_10_SALEPRICE
            // 
            this.C_P2_10_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_10_SALEPRICE.CanGrow = false;
            this.C_P2_10_SALEPRICE.Dpi = 100F;
            this.C_P2_10_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 278F);
            this.C_P2_10_SALEPRICE.Multiline = true;
            this.C_P2_10_SALEPRICE.Name = "C_P2_10_SALEPRICE";
            this.C_P2_10_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_10_SALEPRICE.Text = "";
            this.C_P2_10_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_10_SALEPRICE.WordWrap = false;
            // 
            // C_P2_10_ETCAMT
            // 
            this.C_P2_10_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_10_ETCAMT.CanGrow = false;
            this.C_P2_10_ETCAMT.Dpi = 100F;
            this.C_P2_10_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 278F);
            this.C_P2_10_ETCAMT.Multiline = true;
            this.C_P2_10_ETCAMT.Name = "C_P2_10_ETCAMT";
            this.C_P2_10_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_10_ETCAMT.Text = "";
            this.C_P2_10_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_10_ETCAMT.WordWrap = false;
            // 
            // C_P2_10_AMT
            // 
            this.C_P2_10_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_10_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_10_AMT.BorderWidth = 0.5F;
            this.C_P2_10_AMT.CanGrow = false;
            this.C_P2_10_AMT.Dpi = 100F;
            this.C_P2_10_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_10_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 278F);
            this.C_P2_10_AMT.Multiline = true;
            this.C_P2_10_AMT.Name = "C_P2_10_AMT";
            this.C_P2_10_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_10_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_10_AMT.Text = "";
            this.C_P2_10_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_10_AMT.WordWrap = false;
            // 
            // L_P2_10_OBJREQ
            // 
            this.L_P2_10_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_10_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_10_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_10_OBJREQ.CanGrow = false;
            this.L_P2_10_OBJREQ.Dpi = 100F;
            this.L_P2_10_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_10_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 278F);
            this.L_P2_10_OBJREQ.Multiline = true;
            this.L_P2_10_OBJREQ.Name = "L_P2_10_OBJREQ";
            this.L_P2_10_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_10_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_10_OBJREQ.Text = "";
            this.L_P2_10_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_10_OBJREQ.WordWrap = false;
            // 
            // L_P2_10_OBJOK
            // 
            this.L_P2_10_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_10_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_10_OBJOK.BorderWidth = 0.5F;
            this.L_P2_10_OBJOK.CanGrow = false;
            this.L_P2_10_OBJOK.Dpi = 100F;
            this.L_P2_10_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_10_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 278F);
            this.L_P2_10_OBJOK.Multiline = true;
            this.L_P2_10_OBJOK.Name = "L_P2_10_OBJOK";
            this.L_P2_10_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_10_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_10_OBJOK.Text = "";
            this.L_P2_10_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_10_OBJOK.WordWrap = false;
            // 
            // L_P2_10_PLAN
            // 
            this.L_P2_10_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_10_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_10_PLAN.BorderWidth = 0.5F;
            this.L_P2_10_PLAN.CanGrow = false;
            this.L_P2_10_PLAN.Dpi = 100F;
            this.L_P2_10_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_10_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 278F);
            this.L_P2_10_PLAN.Multiline = true;
            this.L_P2_10_PLAN.Name = "L_P2_10_PLAN";
            this.L_P2_10_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_10_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_10_PLAN.Text = "";
            this.L_P2_10_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_10_PLAN.WordWrap = false;
            // 
            // L_P2_10_CONF
            // 
            this.L_P2_10_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_10_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_10_CONF.BorderWidth = 0.5F;
            this.L_P2_10_CONF.CanGrow = false;
            this.L_P2_10_CONF.Dpi = 100F;
            this.L_P2_10_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_10_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 278F);
            this.L_P2_10_CONF.Multiline = true;
            this.L_P2_10_CONF.Name = "L_P2_10_CONF";
            this.L_P2_10_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_10_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_10_CONF.Text = "";
            this.L_P2_10_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_10_CONF.WordWrap = false;
            // 
            // L_P2_11_NO
            // 
            this.L_P2_11_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_11_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_11_NO.BorderWidth = 0.5F;
            this.L_P2_11_NO.CanGrow = false;
            this.L_P2_11_NO.Dpi = 100F;
            this.L_P2_11_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_11_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 296F);
            this.L_P2_11_NO.Multiline = true;
            this.L_P2_11_NO.Name = "L_P2_11_NO";
            this.L_P2_11_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_11_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_11_NO.Text = "11";
            this.L_P2_11_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_11_NO.WordWrap = false;
            // 
            // C_P2_11_ITEMCD
            // 
            this.C_P2_11_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_11_ITEMCD.CanGrow = false;
            this.C_P2_11_ITEMCD.Dpi = 100F;
            this.C_P2_11_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 296F);
            this.C_P2_11_ITEMCD.Multiline = true;
            this.C_P2_11_ITEMCD.Name = "C_P2_11_ITEMCD";
            this.C_P2_11_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_11_ITEMCD.Text = "";
            this.C_P2_11_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_11_ITEMCD.WordWrap = false;
            // 
            // C_P2_11_ITEMNM
            // 
            this.C_P2_11_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_11_ITEMNM.CanGrow = false;
            this.C_P2_11_ITEMNM.Dpi = 100F;
            this.C_P2_11_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 296F);
            this.C_P2_11_ITEMNM.Multiline = true;
            this.C_P2_11_ITEMNM.Name = "C_P2_11_ITEMNM";
            this.C_P2_11_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_11_ITEMNM.Text = "";
            this.C_P2_11_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_11_ITEMNM.WordWrap = false;
            // 
            // C_P2_11_BADCONT
            // 
            this.C_P2_11_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_BADCONT.BorderWidth = 0.5F;
            this.C_P2_11_BADCONT.CanGrow = false;
            this.C_P2_11_BADCONT.Dpi = 100F;
            this.C_P2_11_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 296F);
            this.C_P2_11_BADCONT.Multiline = true;
            this.C_P2_11_BADCONT.Name = "C_P2_11_BADCONT";
            this.C_P2_11_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_11_BADCONT.Text = "";
            this.C_P2_11_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_11_BADCONT.WordWrap = false;
            // 
            // C_P2_11_QTY
            // 
            this.C_P2_11_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_QTY.BorderWidth = 0.5F;
            this.C_P2_11_QTY.CanGrow = false;
            this.C_P2_11_QTY.Dpi = 100F;
            this.C_P2_11_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 296F);
            this.C_P2_11_QTY.Multiline = true;
            this.C_P2_11_QTY.Name = "C_P2_11_QTY";
            this.C_P2_11_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_11_QTY.Text = "";
            this.C_P2_11_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_11_QTY.WordWrap = false;
            // 
            // C_P2_11_INPRICE
            // 
            this.C_P2_11_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_INPRICE.BorderWidth = 0.5F;
            this.C_P2_11_INPRICE.CanGrow = false;
            this.C_P2_11_INPRICE.Dpi = 100F;
            this.C_P2_11_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 296F);
            this.C_P2_11_INPRICE.Multiline = true;
            this.C_P2_11_INPRICE.Name = "C_P2_11_INPRICE";
            this.C_P2_11_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_11_INPRICE.Text = "";
            this.C_P2_11_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_11_INPRICE.WordWrap = false;
            // 
            // C_P2_11_MFGPRICE
            // 
            this.C_P2_11_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_11_MFGPRICE.CanGrow = false;
            this.C_P2_11_MFGPRICE.Dpi = 100F;
            this.C_P2_11_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 296F);
            this.C_P2_11_MFGPRICE.Multiline = true;
            this.C_P2_11_MFGPRICE.Name = "C_P2_11_MFGPRICE";
            this.C_P2_11_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_11_MFGPRICE.Text = "";
            this.C_P2_11_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_11_MFGPRICE.WordWrap = false;
            // 
            // C_P2_11_SALEPRICE
            // 
            this.C_P2_11_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_11_SALEPRICE.CanGrow = false;
            this.C_P2_11_SALEPRICE.Dpi = 100F;
            this.C_P2_11_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 296F);
            this.C_P2_11_SALEPRICE.Multiline = true;
            this.C_P2_11_SALEPRICE.Name = "C_P2_11_SALEPRICE";
            this.C_P2_11_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_11_SALEPRICE.Text = "";
            this.C_P2_11_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_11_SALEPRICE.WordWrap = false;
            // 
            // C_P2_11_ETCAMT
            // 
            this.C_P2_11_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_11_ETCAMT.CanGrow = false;
            this.C_P2_11_ETCAMT.Dpi = 100F;
            this.C_P2_11_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 296F);
            this.C_P2_11_ETCAMT.Multiline = true;
            this.C_P2_11_ETCAMT.Name = "C_P2_11_ETCAMT";
            this.C_P2_11_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_11_ETCAMT.Text = "";
            this.C_P2_11_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_11_ETCAMT.WordWrap = false;
            // 
            // C_P2_11_AMT
            // 
            this.C_P2_11_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_11_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_11_AMT.BorderWidth = 0.5F;
            this.C_P2_11_AMT.CanGrow = false;
            this.C_P2_11_AMT.Dpi = 100F;
            this.C_P2_11_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_11_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 296F);
            this.C_P2_11_AMT.Multiline = true;
            this.C_P2_11_AMT.Name = "C_P2_11_AMT";
            this.C_P2_11_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_11_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_11_AMT.Text = "";
            this.C_P2_11_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_11_AMT.WordWrap = false;
            // 
            // L_P2_11_OBJREQ
            // 
            this.L_P2_11_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_11_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_11_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_11_OBJREQ.CanGrow = false;
            this.L_P2_11_OBJREQ.Dpi = 100F;
            this.L_P2_11_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_11_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 296F);
            this.L_P2_11_OBJREQ.Multiline = true;
            this.L_P2_11_OBJREQ.Name = "L_P2_11_OBJREQ";
            this.L_P2_11_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_11_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_11_OBJREQ.Text = "";
            this.L_P2_11_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_11_OBJREQ.WordWrap = false;
            // 
            // L_P2_11_OBJOK
            // 
            this.L_P2_11_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_11_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_11_OBJOK.BorderWidth = 0.5F;
            this.L_P2_11_OBJOK.CanGrow = false;
            this.L_P2_11_OBJOK.Dpi = 100F;
            this.L_P2_11_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_11_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 296F);
            this.L_P2_11_OBJOK.Multiline = true;
            this.L_P2_11_OBJOK.Name = "L_P2_11_OBJOK";
            this.L_P2_11_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_11_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_11_OBJOK.Text = "";
            this.L_P2_11_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_11_OBJOK.WordWrap = false;
            // 
            // L_P2_11_PLAN
            // 
            this.L_P2_11_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_11_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_11_PLAN.BorderWidth = 0.5F;
            this.L_P2_11_PLAN.CanGrow = false;
            this.L_P2_11_PLAN.Dpi = 100F;
            this.L_P2_11_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_11_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 296F);
            this.L_P2_11_PLAN.Multiline = true;
            this.L_P2_11_PLAN.Name = "L_P2_11_PLAN";
            this.L_P2_11_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_11_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_11_PLAN.Text = "";
            this.L_P2_11_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_11_PLAN.WordWrap = false;
            // 
            // L_P2_11_CONF
            // 
            this.L_P2_11_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_11_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_11_CONF.BorderWidth = 0.5F;
            this.L_P2_11_CONF.CanGrow = false;
            this.L_P2_11_CONF.Dpi = 100F;
            this.L_P2_11_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_11_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 296F);
            this.L_P2_11_CONF.Multiline = true;
            this.L_P2_11_CONF.Name = "L_P2_11_CONF";
            this.L_P2_11_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_11_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_11_CONF.Text = "";
            this.L_P2_11_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_11_CONF.WordWrap = false;
            // 
            // L_P2_12_NO
            // 
            this.L_P2_12_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_12_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_12_NO.BorderWidth = 0.5F;
            this.L_P2_12_NO.CanGrow = false;
            this.L_P2_12_NO.Dpi = 100F;
            this.L_P2_12_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_12_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 314F);
            this.L_P2_12_NO.Multiline = true;
            this.L_P2_12_NO.Name = "L_P2_12_NO";
            this.L_P2_12_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_12_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_12_NO.Text = "12";
            this.L_P2_12_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_12_NO.WordWrap = false;
            // 
            // C_P2_12_ITEMCD
            // 
            this.C_P2_12_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_12_ITEMCD.CanGrow = false;
            this.C_P2_12_ITEMCD.Dpi = 100F;
            this.C_P2_12_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 314F);
            this.C_P2_12_ITEMCD.Multiline = true;
            this.C_P2_12_ITEMCD.Name = "C_P2_12_ITEMCD";
            this.C_P2_12_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_12_ITEMCD.Text = "";
            this.C_P2_12_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_12_ITEMCD.WordWrap = false;
            // 
            // C_P2_12_ITEMNM
            // 
            this.C_P2_12_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_12_ITEMNM.CanGrow = false;
            this.C_P2_12_ITEMNM.Dpi = 100F;
            this.C_P2_12_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 314F);
            this.C_P2_12_ITEMNM.Multiline = true;
            this.C_P2_12_ITEMNM.Name = "C_P2_12_ITEMNM";
            this.C_P2_12_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_12_ITEMNM.Text = "";
            this.C_P2_12_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_12_ITEMNM.WordWrap = false;
            // 
            // C_P2_12_BADCONT
            // 
            this.C_P2_12_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_BADCONT.BorderWidth = 0.5F;
            this.C_P2_12_BADCONT.CanGrow = false;
            this.C_P2_12_BADCONT.Dpi = 100F;
            this.C_P2_12_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 314F);
            this.C_P2_12_BADCONT.Multiline = true;
            this.C_P2_12_BADCONT.Name = "C_P2_12_BADCONT";
            this.C_P2_12_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_12_BADCONT.Text = "";
            this.C_P2_12_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_12_BADCONT.WordWrap = false;
            // 
            // C_P2_12_QTY
            // 
            this.C_P2_12_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_QTY.BorderWidth = 0.5F;
            this.C_P2_12_QTY.CanGrow = false;
            this.C_P2_12_QTY.Dpi = 100F;
            this.C_P2_12_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 314F);
            this.C_P2_12_QTY.Multiline = true;
            this.C_P2_12_QTY.Name = "C_P2_12_QTY";
            this.C_P2_12_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_12_QTY.Text = "";
            this.C_P2_12_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_12_QTY.WordWrap = false;
            // 
            // C_P2_12_INPRICE
            // 
            this.C_P2_12_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_INPRICE.BorderWidth = 0.5F;
            this.C_P2_12_INPRICE.CanGrow = false;
            this.C_P2_12_INPRICE.Dpi = 100F;
            this.C_P2_12_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 314F);
            this.C_P2_12_INPRICE.Multiline = true;
            this.C_P2_12_INPRICE.Name = "C_P2_12_INPRICE";
            this.C_P2_12_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_12_INPRICE.Text = "";
            this.C_P2_12_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_12_INPRICE.WordWrap = false;
            // 
            // C_P2_12_MFGPRICE
            // 
            this.C_P2_12_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_12_MFGPRICE.CanGrow = false;
            this.C_P2_12_MFGPRICE.Dpi = 100F;
            this.C_P2_12_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 314F);
            this.C_P2_12_MFGPRICE.Multiline = true;
            this.C_P2_12_MFGPRICE.Name = "C_P2_12_MFGPRICE";
            this.C_P2_12_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_12_MFGPRICE.Text = "";
            this.C_P2_12_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_12_MFGPRICE.WordWrap = false;
            // 
            // C_P2_12_SALEPRICE
            // 
            this.C_P2_12_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_12_SALEPRICE.CanGrow = false;
            this.C_P2_12_SALEPRICE.Dpi = 100F;
            this.C_P2_12_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 314F);
            this.C_P2_12_SALEPRICE.Multiline = true;
            this.C_P2_12_SALEPRICE.Name = "C_P2_12_SALEPRICE";
            this.C_P2_12_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_12_SALEPRICE.Text = "";
            this.C_P2_12_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_12_SALEPRICE.WordWrap = false;
            // 
            // C_P2_12_ETCAMT
            // 
            this.C_P2_12_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_12_ETCAMT.CanGrow = false;
            this.C_P2_12_ETCAMT.Dpi = 100F;
            this.C_P2_12_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 314F);
            this.C_P2_12_ETCAMT.Multiline = true;
            this.C_P2_12_ETCAMT.Name = "C_P2_12_ETCAMT";
            this.C_P2_12_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_12_ETCAMT.Text = "";
            this.C_P2_12_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_12_ETCAMT.WordWrap = false;
            // 
            // C_P2_12_AMT
            // 
            this.C_P2_12_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_12_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_12_AMT.BorderWidth = 0.5F;
            this.C_P2_12_AMT.CanGrow = false;
            this.C_P2_12_AMT.Dpi = 100F;
            this.C_P2_12_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_12_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 314F);
            this.C_P2_12_AMT.Multiline = true;
            this.C_P2_12_AMT.Name = "C_P2_12_AMT";
            this.C_P2_12_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_12_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_12_AMT.Text = "";
            this.C_P2_12_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_12_AMT.WordWrap = false;
            // 
            // L_P2_12_OBJREQ
            // 
            this.L_P2_12_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_12_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_12_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_12_OBJREQ.CanGrow = false;
            this.L_P2_12_OBJREQ.Dpi = 100F;
            this.L_P2_12_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_12_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 314F);
            this.L_P2_12_OBJREQ.Multiline = true;
            this.L_P2_12_OBJREQ.Name = "L_P2_12_OBJREQ";
            this.L_P2_12_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_12_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_12_OBJREQ.Text = "";
            this.L_P2_12_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_12_OBJREQ.WordWrap = false;
            // 
            // L_P2_12_OBJOK
            // 
            this.L_P2_12_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_12_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_12_OBJOK.BorderWidth = 0.5F;
            this.L_P2_12_OBJOK.CanGrow = false;
            this.L_P2_12_OBJOK.Dpi = 100F;
            this.L_P2_12_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_12_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 314F);
            this.L_P2_12_OBJOK.Multiline = true;
            this.L_P2_12_OBJOK.Name = "L_P2_12_OBJOK";
            this.L_P2_12_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_12_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_12_OBJOK.Text = "";
            this.L_P2_12_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_12_OBJOK.WordWrap = false;
            // 
            // L_P2_12_PLAN
            // 
            this.L_P2_12_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_12_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_12_PLAN.BorderWidth = 0.5F;
            this.L_P2_12_PLAN.CanGrow = false;
            this.L_P2_12_PLAN.Dpi = 100F;
            this.L_P2_12_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_12_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 314F);
            this.L_P2_12_PLAN.Multiline = true;
            this.L_P2_12_PLAN.Name = "L_P2_12_PLAN";
            this.L_P2_12_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_12_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_12_PLAN.Text = "";
            this.L_P2_12_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_12_PLAN.WordWrap = false;
            // 
            // L_P2_12_CONF
            // 
            this.L_P2_12_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_12_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_12_CONF.BorderWidth = 0.5F;
            this.L_P2_12_CONF.CanGrow = false;
            this.L_P2_12_CONF.Dpi = 100F;
            this.L_P2_12_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_12_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 314F);
            this.L_P2_12_CONF.Multiline = true;
            this.L_P2_12_CONF.Name = "L_P2_12_CONF";
            this.L_P2_12_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_12_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_12_CONF.Text = "";
            this.L_P2_12_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_12_CONF.WordWrap = false;
            // 
            // L_P2_13_NO
            // 
            this.L_P2_13_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_13_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_13_NO.BorderWidth = 0.5F;
            this.L_P2_13_NO.CanGrow = false;
            this.L_P2_13_NO.Dpi = 100F;
            this.L_P2_13_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_13_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 332F);
            this.L_P2_13_NO.Multiline = true;
            this.L_P2_13_NO.Name = "L_P2_13_NO";
            this.L_P2_13_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_13_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_13_NO.Text = "13";
            this.L_P2_13_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_13_NO.WordWrap = false;
            // 
            // C_P2_13_ITEMCD
            // 
            this.C_P2_13_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_13_ITEMCD.CanGrow = false;
            this.C_P2_13_ITEMCD.Dpi = 100F;
            this.C_P2_13_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 332F);
            this.C_P2_13_ITEMCD.Multiline = true;
            this.C_P2_13_ITEMCD.Name = "C_P2_13_ITEMCD";
            this.C_P2_13_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_13_ITEMCD.Text = "";
            this.C_P2_13_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_13_ITEMCD.WordWrap = false;
            // 
            // C_P2_13_ITEMNM
            // 
            this.C_P2_13_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_13_ITEMNM.CanGrow = false;
            this.C_P2_13_ITEMNM.Dpi = 100F;
            this.C_P2_13_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 332F);
            this.C_P2_13_ITEMNM.Multiline = true;
            this.C_P2_13_ITEMNM.Name = "C_P2_13_ITEMNM";
            this.C_P2_13_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_13_ITEMNM.Text = "";
            this.C_P2_13_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_13_ITEMNM.WordWrap = false;
            // 
            // C_P2_13_BADCONT
            // 
            this.C_P2_13_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_BADCONT.BorderWidth = 0.5F;
            this.C_P2_13_BADCONT.CanGrow = false;
            this.C_P2_13_BADCONT.Dpi = 100F;
            this.C_P2_13_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 332F);
            this.C_P2_13_BADCONT.Multiline = true;
            this.C_P2_13_BADCONT.Name = "C_P2_13_BADCONT";
            this.C_P2_13_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_13_BADCONT.Text = "";
            this.C_P2_13_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_13_BADCONT.WordWrap = false;
            // 
            // C_P2_13_QTY
            // 
            this.C_P2_13_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_QTY.BorderWidth = 0.5F;
            this.C_P2_13_QTY.CanGrow = false;
            this.C_P2_13_QTY.Dpi = 100F;
            this.C_P2_13_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 332F);
            this.C_P2_13_QTY.Multiline = true;
            this.C_P2_13_QTY.Name = "C_P2_13_QTY";
            this.C_P2_13_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_13_QTY.Text = "";
            this.C_P2_13_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_13_QTY.WordWrap = false;
            // 
            // C_P2_13_INPRICE
            // 
            this.C_P2_13_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_INPRICE.BorderWidth = 0.5F;
            this.C_P2_13_INPRICE.CanGrow = false;
            this.C_P2_13_INPRICE.Dpi = 100F;
            this.C_P2_13_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 332F);
            this.C_P2_13_INPRICE.Multiline = true;
            this.C_P2_13_INPRICE.Name = "C_P2_13_INPRICE";
            this.C_P2_13_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_13_INPRICE.Text = "";
            this.C_P2_13_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_13_INPRICE.WordWrap = false;
            // 
            // C_P2_13_MFGPRICE
            // 
            this.C_P2_13_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_13_MFGPRICE.CanGrow = false;
            this.C_P2_13_MFGPRICE.Dpi = 100F;
            this.C_P2_13_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 332F);
            this.C_P2_13_MFGPRICE.Multiline = true;
            this.C_P2_13_MFGPRICE.Name = "C_P2_13_MFGPRICE";
            this.C_P2_13_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_13_MFGPRICE.Text = "";
            this.C_P2_13_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_13_MFGPRICE.WordWrap = false;
            // 
            // C_P2_13_SALEPRICE
            // 
            this.C_P2_13_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_13_SALEPRICE.CanGrow = false;
            this.C_P2_13_SALEPRICE.Dpi = 100F;
            this.C_P2_13_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 332F);
            this.C_P2_13_SALEPRICE.Multiline = true;
            this.C_P2_13_SALEPRICE.Name = "C_P2_13_SALEPRICE";
            this.C_P2_13_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_13_SALEPRICE.Text = "";
            this.C_P2_13_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_13_SALEPRICE.WordWrap = false;
            // 
            // C_P2_13_ETCAMT
            // 
            this.C_P2_13_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_13_ETCAMT.CanGrow = false;
            this.C_P2_13_ETCAMT.Dpi = 100F;
            this.C_P2_13_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 332F);
            this.C_P2_13_ETCAMT.Multiline = true;
            this.C_P2_13_ETCAMT.Name = "C_P2_13_ETCAMT";
            this.C_P2_13_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_13_ETCAMT.Text = "";
            this.C_P2_13_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_13_ETCAMT.WordWrap = false;
            // 
            // C_P2_13_AMT
            // 
            this.C_P2_13_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_13_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_13_AMT.BorderWidth = 0.5F;
            this.C_P2_13_AMT.CanGrow = false;
            this.C_P2_13_AMT.Dpi = 100F;
            this.C_P2_13_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_13_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 332F);
            this.C_P2_13_AMT.Multiline = true;
            this.C_P2_13_AMT.Name = "C_P2_13_AMT";
            this.C_P2_13_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_13_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_13_AMT.Text = "";
            this.C_P2_13_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_13_AMT.WordWrap = false;
            // 
            // L_P2_13_OBJREQ
            // 
            this.L_P2_13_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_13_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_13_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_13_OBJREQ.CanGrow = false;
            this.L_P2_13_OBJREQ.Dpi = 100F;
            this.L_P2_13_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_13_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 332F);
            this.L_P2_13_OBJREQ.Multiline = true;
            this.L_P2_13_OBJREQ.Name = "L_P2_13_OBJREQ";
            this.L_P2_13_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_13_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_13_OBJREQ.Text = "";
            this.L_P2_13_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_13_OBJREQ.WordWrap = false;
            // 
            // L_P2_13_OBJOK
            // 
            this.L_P2_13_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_13_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_13_OBJOK.BorderWidth = 0.5F;
            this.L_P2_13_OBJOK.CanGrow = false;
            this.L_P2_13_OBJOK.Dpi = 100F;
            this.L_P2_13_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_13_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 332F);
            this.L_P2_13_OBJOK.Multiline = true;
            this.L_P2_13_OBJOK.Name = "L_P2_13_OBJOK";
            this.L_P2_13_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_13_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_13_OBJOK.Text = "";
            this.L_P2_13_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_13_OBJOK.WordWrap = false;
            // 
            // L_P2_13_PLAN
            // 
            this.L_P2_13_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_13_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_13_PLAN.BorderWidth = 0.5F;
            this.L_P2_13_PLAN.CanGrow = false;
            this.L_P2_13_PLAN.Dpi = 100F;
            this.L_P2_13_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_13_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 332F);
            this.L_P2_13_PLAN.Multiline = true;
            this.L_P2_13_PLAN.Name = "L_P2_13_PLAN";
            this.L_P2_13_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_13_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_13_PLAN.Text = "";
            this.L_P2_13_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_13_PLAN.WordWrap = false;
            // 
            // L_P2_13_CONF
            // 
            this.L_P2_13_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_13_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_13_CONF.BorderWidth = 0.5F;
            this.L_P2_13_CONF.CanGrow = false;
            this.L_P2_13_CONF.Dpi = 100F;
            this.L_P2_13_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_13_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 332F);
            this.L_P2_13_CONF.Multiline = true;
            this.L_P2_13_CONF.Name = "L_P2_13_CONF";
            this.L_P2_13_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_13_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_13_CONF.Text = "";
            this.L_P2_13_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_13_CONF.WordWrap = false;
            // 
            // L_P2_14_NO
            // 
            this.L_P2_14_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_14_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_14_NO.BorderWidth = 0.5F;
            this.L_P2_14_NO.CanGrow = false;
            this.L_P2_14_NO.Dpi = 100F;
            this.L_P2_14_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_14_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 350F);
            this.L_P2_14_NO.Multiline = true;
            this.L_P2_14_NO.Name = "L_P2_14_NO";
            this.L_P2_14_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_14_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_14_NO.Text = "14";
            this.L_P2_14_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_14_NO.WordWrap = false;
            // 
            // C_P2_14_ITEMCD
            // 
            this.C_P2_14_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_14_ITEMCD.CanGrow = false;
            this.C_P2_14_ITEMCD.Dpi = 100F;
            this.C_P2_14_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 350F);
            this.C_P2_14_ITEMCD.Multiline = true;
            this.C_P2_14_ITEMCD.Name = "C_P2_14_ITEMCD";
            this.C_P2_14_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_14_ITEMCD.Text = "";
            this.C_P2_14_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_14_ITEMCD.WordWrap = false;
            // 
            // C_P2_14_ITEMNM
            // 
            this.C_P2_14_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_14_ITEMNM.CanGrow = false;
            this.C_P2_14_ITEMNM.Dpi = 100F;
            this.C_P2_14_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 350F);
            this.C_P2_14_ITEMNM.Multiline = true;
            this.C_P2_14_ITEMNM.Name = "C_P2_14_ITEMNM";
            this.C_P2_14_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_14_ITEMNM.Text = "";
            this.C_P2_14_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_14_ITEMNM.WordWrap = false;
            // 
            // C_P2_14_BADCONT
            // 
            this.C_P2_14_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_BADCONT.BorderWidth = 0.5F;
            this.C_P2_14_BADCONT.CanGrow = false;
            this.C_P2_14_BADCONT.Dpi = 100F;
            this.C_P2_14_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 350F);
            this.C_P2_14_BADCONT.Multiline = true;
            this.C_P2_14_BADCONT.Name = "C_P2_14_BADCONT";
            this.C_P2_14_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_14_BADCONT.Text = "";
            this.C_P2_14_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_14_BADCONT.WordWrap = false;
            // 
            // C_P2_14_QTY
            // 
            this.C_P2_14_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_QTY.BorderWidth = 0.5F;
            this.C_P2_14_QTY.CanGrow = false;
            this.C_P2_14_QTY.Dpi = 100F;
            this.C_P2_14_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 350F);
            this.C_P2_14_QTY.Multiline = true;
            this.C_P2_14_QTY.Name = "C_P2_14_QTY";
            this.C_P2_14_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_14_QTY.Text = "";
            this.C_P2_14_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_14_QTY.WordWrap = false;
            // 
            // C_P2_14_INPRICE
            // 
            this.C_P2_14_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_INPRICE.BorderWidth = 0.5F;
            this.C_P2_14_INPRICE.CanGrow = false;
            this.C_P2_14_INPRICE.Dpi = 100F;
            this.C_P2_14_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 350F);
            this.C_P2_14_INPRICE.Multiline = true;
            this.C_P2_14_INPRICE.Name = "C_P2_14_INPRICE";
            this.C_P2_14_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_14_INPRICE.Text = "";
            this.C_P2_14_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_14_INPRICE.WordWrap = false;
            // 
            // C_P2_14_MFGPRICE
            // 
            this.C_P2_14_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_14_MFGPRICE.CanGrow = false;
            this.C_P2_14_MFGPRICE.Dpi = 100F;
            this.C_P2_14_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 350F);
            this.C_P2_14_MFGPRICE.Multiline = true;
            this.C_P2_14_MFGPRICE.Name = "C_P2_14_MFGPRICE";
            this.C_P2_14_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_14_MFGPRICE.Text = "";
            this.C_P2_14_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_14_MFGPRICE.WordWrap = false;
            // 
            // C_P2_14_SALEPRICE
            // 
            this.C_P2_14_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_14_SALEPRICE.CanGrow = false;
            this.C_P2_14_SALEPRICE.Dpi = 100F;
            this.C_P2_14_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 350F);
            this.C_P2_14_SALEPRICE.Multiline = true;
            this.C_P2_14_SALEPRICE.Name = "C_P2_14_SALEPRICE";
            this.C_P2_14_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_14_SALEPRICE.Text = "";
            this.C_P2_14_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_14_SALEPRICE.WordWrap = false;
            // 
            // C_P2_14_ETCAMT
            // 
            this.C_P2_14_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_14_ETCAMT.CanGrow = false;
            this.C_P2_14_ETCAMT.Dpi = 100F;
            this.C_P2_14_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 350F);
            this.C_P2_14_ETCAMT.Multiline = true;
            this.C_P2_14_ETCAMT.Name = "C_P2_14_ETCAMT";
            this.C_P2_14_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_14_ETCAMT.Text = "";
            this.C_P2_14_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_14_ETCAMT.WordWrap = false;
            // 
            // C_P2_14_AMT
            // 
            this.C_P2_14_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_14_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_14_AMT.BorderWidth = 0.5F;
            this.C_P2_14_AMT.CanGrow = false;
            this.C_P2_14_AMT.Dpi = 100F;
            this.C_P2_14_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_14_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 350F);
            this.C_P2_14_AMT.Multiline = true;
            this.C_P2_14_AMT.Name = "C_P2_14_AMT";
            this.C_P2_14_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_14_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_14_AMT.Text = "";
            this.C_P2_14_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_14_AMT.WordWrap = false;
            // 
            // L_P2_14_OBJREQ
            // 
            this.L_P2_14_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_14_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_14_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_14_OBJREQ.CanGrow = false;
            this.L_P2_14_OBJREQ.Dpi = 100F;
            this.L_P2_14_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_14_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 350F);
            this.L_P2_14_OBJREQ.Multiline = true;
            this.L_P2_14_OBJREQ.Name = "L_P2_14_OBJREQ";
            this.L_P2_14_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_14_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_14_OBJREQ.Text = "";
            this.L_P2_14_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_14_OBJREQ.WordWrap = false;
            // 
            // L_P2_14_OBJOK
            // 
            this.L_P2_14_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_14_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_14_OBJOK.BorderWidth = 0.5F;
            this.L_P2_14_OBJOK.CanGrow = false;
            this.L_P2_14_OBJOK.Dpi = 100F;
            this.L_P2_14_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_14_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 350F);
            this.L_P2_14_OBJOK.Multiline = true;
            this.L_P2_14_OBJOK.Name = "L_P2_14_OBJOK";
            this.L_P2_14_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_14_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_14_OBJOK.Text = "";
            this.L_P2_14_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_14_OBJOK.WordWrap = false;
            // 
            // L_P2_14_PLAN
            // 
            this.L_P2_14_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_14_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_14_PLAN.BorderWidth = 0.5F;
            this.L_P2_14_PLAN.CanGrow = false;
            this.L_P2_14_PLAN.Dpi = 100F;
            this.L_P2_14_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_14_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 350F);
            this.L_P2_14_PLAN.Multiline = true;
            this.L_P2_14_PLAN.Name = "L_P2_14_PLAN";
            this.L_P2_14_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_14_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_14_PLAN.Text = "";
            this.L_P2_14_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_14_PLAN.WordWrap = false;
            // 
            // L_P2_14_CONF
            // 
            this.L_P2_14_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_14_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_14_CONF.BorderWidth = 0.5F;
            this.L_P2_14_CONF.CanGrow = false;
            this.L_P2_14_CONF.Dpi = 100F;
            this.L_P2_14_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_14_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 350F);
            this.L_P2_14_CONF.Multiline = true;
            this.L_P2_14_CONF.Name = "L_P2_14_CONF";
            this.L_P2_14_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_14_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_14_CONF.Text = "";
            this.L_P2_14_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_14_CONF.WordWrap = false;
            // 
            // L_P2_15_NO
            // 
            this.L_P2_15_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_15_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_15_NO.BorderWidth = 0.5F;
            this.L_P2_15_NO.CanGrow = false;
            this.L_P2_15_NO.Dpi = 100F;
            this.L_P2_15_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_15_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 368F);
            this.L_P2_15_NO.Multiline = true;
            this.L_P2_15_NO.Name = "L_P2_15_NO";
            this.L_P2_15_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_15_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_15_NO.Text = "15";
            this.L_P2_15_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_15_NO.WordWrap = false;
            // 
            // C_P2_15_ITEMCD
            // 
            this.C_P2_15_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_15_ITEMCD.CanGrow = false;
            this.C_P2_15_ITEMCD.Dpi = 100F;
            this.C_P2_15_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 368F);
            this.C_P2_15_ITEMCD.Multiline = true;
            this.C_P2_15_ITEMCD.Name = "C_P2_15_ITEMCD";
            this.C_P2_15_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_15_ITEMCD.Text = "";
            this.C_P2_15_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_15_ITEMCD.WordWrap = false;
            // 
            // C_P2_15_ITEMNM
            // 
            this.C_P2_15_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_15_ITEMNM.CanGrow = false;
            this.C_P2_15_ITEMNM.Dpi = 100F;
            this.C_P2_15_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 368F);
            this.C_P2_15_ITEMNM.Multiline = true;
            this.C_P2_15_ITEMNM.Name = "C_P2_15_ITEMNM";
            this.C_P2_15_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_15_ITEMNM.Text = "";
            this.C_P2_15_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_15_ITEMNM.WordWrap = false;
            // 
            // C_P2_15_BADCONT
            // 
            this.C_P2_15_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_BADCONT.BorderWidth = 0.5F;
            this.C_P2_15_BADCONT.CanGrow = false;
            this.C_P2_15_BADCONT.Dpi = 100F;
            this.C_P2_15_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 368F);
            this.C_P2_15_BADCONT.Multiline = true;
            this.C_P2_15_BADCONT.Name = "C_P2_15_BADCONT";
            this.C_P2_15_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_15_BADCONT.Text = "";
            this.C_P2_15_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_15_BADCONT.WordWrap = false;
            // 
            // C_P2_15_QTY
            // 
            this.C_P2_15_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_QTY.BorderWidth = 0.5F;
            this.C_P2_15_QTY.CanGrow = false;
            this.C_P2_15_QTY.Dpi = 100F;
            this.C_P2_15_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 368F);
            this.C_P2_15_QTY.Multiline = true;
            this.C_P2_15_QTY.Name = "C_P2_15_QTY";
            this.C_P2_15_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_15_QTY.Text = "";
            this.C_P2_15_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_15_QTY.WordWrap = false;
            // 
            // C_P2_15_INPRICE
            // 
            this.C_P2_15_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_INPRICE.BorderWidth = 0.5F;
            this.C_P2_15_INPRICE.CanGrow = false;
            this.C_P2_15_INPRICE.Dpi = 100F;
            this.C_P2_15_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 368F);
            this.C_P2_15_INPRICE.Multiline = true;
            this.C_P2_15_INPRICE.Name = "C_P2_15_INPRICE";
            this.C_P2_15_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_15_INPRICE.Text = "";
            this.C_P2_15_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_15_INPRICE.WordWrap = false;
            // 
            // C_P2_15_MFGPRICE
            // 
            this.C_P2_15_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_15_MFGPRICE.CanGrow = false;
            this.C_P2_15_MFGPRICE.Dpi = 100F;
            this.C_P2_15_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 368F);
            this.C_P2_15_MFGPRICE.Multiline = true;
            this.C_P2_15_MFGPRICE.Name = "C_P2_15_MFGPRICE";
            this.C_P2_15_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_15_MFGPRICE.Text = "";
            this.C_P2_15_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_15_MFGPRICE.WordWrap = false;
            // 
            // C_P2_15_SALEPRICE
            // 
            this.C_P2_15_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_15_SALEPRICE.CanGrow = false;
            this.C_P2_15_SALEPRICE.Dpi = 100F;
            this.C_P2_15_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 368F);
            this.C_P2_15_SALEPRICE.Multiline = true;
            this.C_P2_15_SALEPRICE.Name = "C_P2_15_SALEPRICE";
            this.C_P2_15_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_15_SALEPRICE.Text = "";
            this.C_P2_15_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_15_SALEPRICE.WordWrap = false;
            // 
            // C_P2_15_ETCAMT
            // 
            this.C_P2_15_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_15_ETCAMT.CanGrow = false;
            this.C_P2_15_ETCAMT.Dpi = 100F;
            this.C_P2_15_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 368F);
            this.C_P2_15_ETCAMT.Multiline = true;
            this.C_P2_15_ETCAMT.Name = "C_P2_15_ETCAMT";
            this.C_P2_15_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_15_ETCAMT.Text = "";
            this.C_P2_15_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_15_ETCAMT.WordWrap = false;
            // 
            // C_P2_15_AMT
            // 
            this.C_P2_15_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_15_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_15_AMT.BorderWidth = 0.5F;
            this.C_P2_15_AMT.CanGrow = false;
            this.C_P2_15_AMT.Dpi = 100F;
            this.C_P2_15_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_15_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 368F);
            this.C_P2_15_AMT.Multiline = true;
            this.C_P2_15_AMT.Name = "C_P2_15_AMT";
            this.C_P2_15_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_15_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_15_AMT.Text = "";
            this.C_P2_15_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_15_AMT.WordWrap = false;
            // 
            // L_P2_15_OBJREQ
            // 
            this.L_P2_15_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_15_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_15_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_15_OBJREQ.CanGrow = false;
            this.L_P2_15_OBJREQ.Dpi = 100F;
            this.L_P2_15_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_15_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 368F);
            this.L_P2_15_OBJREQ.Multiline = true;
            this.L_P2_15_OBJREQ.Name = "L_P2_15_OBJREQ";
            this.L_P2_15_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_15_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_15_OBJREQ.Text = "";
            this.L_P2_15_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_15_OBJREQ.WordWrap = false;
            // 
            // L_P2_15_OBJOK
            // 
            this.L_P2_15_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_15_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_15_OBJOK.BorderWidth = 0.5F;
            this.L_P2_15_OBJOK.CanGrow = false;
            this.L_P2_15_OBJOK.Dpi = 100F;
            this.L_P2_15_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_15_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 368F);
            this.L_P2_15_OBJOK.Multiline = true;
            this.L_P2_15_OBJOK.Name = "L_P2_15_OBJOK";
            this.L_P2_15_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_15_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_15_OBJOK.Text = "";
            this.L_P2_15_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_15_OBJOK.WordWrap = false;
            // 
            // L_P2_15_PLAN
            // 
            this.L_P2_15_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_15_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_15_PLAN.BorderWidth = 0.5F;
            this.L_P2_15_PLAN.CanGrow = false;
            this.L_P2_15_PLAN.Dpi = 100F;
            this.L_P2_15_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_15_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 368F);
            this.L_P2_15_PLAN.Multiline = true;
            this.L_P2_15_PLAN.Name = "L_P2_15_PLAN";
            this.L_P2_15_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_15_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_15_PLAN.Text = "";
            this.L_P2_15_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_15_PLAN.WordWrap = false;
            // 
            // L_P2_15_CONF
            // 
            this.L_P2_15_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_15_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_15_CONF.BorderWidth = 0.5F;
            this.L_P2_15_CONF.CanGrow = false;
            this.L_P2_15_CONF.Dpi = 100F;
            this.L_P2_15_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_15_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 368F);
            this.L_P2_15_CONF.Multiline = true;
            this.L_P2_15_CONF.Name = "L_P2_15_CONF";
            this.L_P2_15_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_15_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_15_CONF.Text = "";
            this.L_P2_15_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_15_CONF.WordWrap = false;
            // 
            // L_P2_16_NO
            // 
            this.L_P2_16_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_16_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_16_NO.BorderWidth = 0.5F;
            this.L_P2_16_NO.CanGrow = false;
            this.L_P2_16_NO.Dpi = 100F;
            this.L_P2_16_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_16_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 386F);
            this.L_P2_16_NO.Multiline = true;
            this.L_P2_16_NO.Name = "L_P2_16_NO";
            this.L_P2_16_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_16_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_16_NO.Text = "16";
            this.L_P2_16_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_16_NO.WordWrap = false;
            // 
            // C_P2_16_ITEMCD
            // 
            this.C_P2_16_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_16_ITEMCD.CanGrow = false;
            this.C_P2_16_ITEMCD.Dpi = 100F;
            this.C_P2_16_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 386F);
            this.C_P2_16_ITEMCD.Multiline = true;
            this.C_P2_16_ITEMCD.Name = "C_P2_16_ITEMCD";
            this.C_P2_16_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_16_ITEMCD.Text = "";
            this.C_P2_16_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_16_ITEMCD.WordWrap = false;
            // 
            // C_P2_16_ITEMNM
            // 
            this.C_P2_16_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_16_ITEMNM.CanGrow = false;
            this.C_P2_16_ITEMNM.Dpi = 100F;
            this.C_P2_16_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 386F);
            this.C_P2_16_ITEMNM.Multiline = true;
            this.C_P2_16_ITEMNM.Name = "C_P2_16_ITEMNM";
            this.C_P2_16_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_16_ITEMNM.Text = "";
            this.C_P2_16_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_16_ITEMNM.WordWrap = false;
            // 
            // C_P2_16_BADCONT
            // 
            this.C_P2_16_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_BADCONT.BorderWidth = 0.5F;
            this.C_P2_16_BADCONT.CanGrow = false;
            this.C_P2_16_BADCONT.Dpi = 100F;
            this.C_P2_16_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 386F);
            this.C_P2_16_BADCONT.Multiline = true;
            this.C_P2_16_BADCONT.Name = "C_P2_16_BADCONT";
            this.C_P2_16_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_16_BADCONT.Text = "";
            this.C_P2_16_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_16_BADCONT.WordWrap = false;
            // 
            // C_P2_16_QTY
            // 
            this.C_P2_16_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_QTY.BorderWidth = 0.5F;
            this.C_P2_16_QTY.CanGrow = false;
            this.C_P2_16_QTY.Dpi = 100F;
            this.C_P2_16_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 386F);
            this.C_P2_16_QTY.Multiline = true;
            this.C_P2_16_QTY.Name = "C_P2_16_QTY";
            this.C_P2_16_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_16_QTY.Text = "";
            this.C_P2_16_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_16_QTY.WordWrap = false;
            // 
            // C_P2_16_INPRICE
            // 
            this.C_P2_16_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_INPRICE.BorderWidth = 0.5F;
            this.C_P2_16_INPRICE.CanGrow = false;
            this.C_P2_16_INPRICE.Dpi = 100F;
            this.C_P2_16_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 386F);
            this.C_P2_16_INPRICE.Multiline = true;
            this.C_P2_16_INPRICE.Name = "C_P2_16_INPRICE";
            this.C_P2_16_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_16_INPRICE.Text = "";
            this.C_P2_16_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_16_INPRICE.WordWrap = false;
            // 
            // C_P2_16_MFGPRICE
            // 
            this.C_P2_16_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_16_MFGPRICE.CanGrow = false;
            this.C_P2_16_MFGPRICE.Dpi = 100F;
            this.C_P2_16_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 386F);
            this.C_P2_16_MFGPRICE.Multiline = true;
            this.C_P2_16_MFGPRICE.Name = "C_P2_16_MFGPRICE";
            this.C_P2_16_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_16_MFGPRICE.Text = "";
            this.C_P2_16_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_16_MFGPRICE.WordWrap = false;
            // 
            // C_P2_16_SALEPRICE
            // 
            this.C_P2_16_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_16_SALEPRICE.CanGrow = false;
            this.C_P2_16_SALEPRICE.Dpi = 100F;
            this.C_P2_16_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 386F);
            this.C_P2_16_SALEPRICE.Multiline = true;
            this.C_P2_16_SALEPRICE.Name = "C_P2_16_SALEPRICE";
            this.C_P2_16_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_16_SALEPRICE.Text = "";
            this.C_P2_16_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_16_SALEPRICE.WordWrap = false;
            // 
            // C_P2_16_ETCAMT
            // 
            this.C_P2_16_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_16_ETCAMT.CanGrow = false;
            this.C_P2_16_ETCAMT.Dpi = 100F;
            this.C_P2_16_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 386F);
            this.C_P2_16_ETCAMT.Multiline = true;
            this.C_P2_16_ETCAMT.Name = "C_P2_16_ETCAMT";
            this.C_P2_16_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_16_ETCAMT.Text = "";
            this.C_P2_16_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_16_ETCAMT.WordWrap = false;
            // 
            // C_P2_16_AMT
            // 
            this.C_P2_16_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_16_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_16_AMT.BorderWidth = 0.5F;
            this.C_P2_16_AMT.CanGrow = false;
            this.C_P2_16_AMT.Dpi = 100F;
            this.C_P2_16_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_16_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 386F);
            this.C_P2_16_AMT.Multiline = true;
            this.C_P2_16_AMT.Name = "C_P2_16_AMT";
            this.C_P2_16_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_16_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_16_AMT.Text = "";
            this.C_P2_16_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_16_AMT.WordWrap = false;
            // 
            // L_P2_16_OBJREQ
            // 
            this.L_P2_16_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_16_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_16_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_16_OBJREQ.CanGrow = false;
            this.L_P2_16_OBJREQ.Dpi = 100F;
            this.L_P2_16_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_16_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 386F);
            this.L_P2_16_OBJREQ.Multiline = true;
            this.L_P2_16_OBJREQ.Name = "L_P2_16_OBJREQ";
            this.L_P2_16_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_16_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_16_OBJREQ.Text = "";
            this.L_P2_16_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_16_OBJREQ.WordWrap = false;
            // 
            // L_P2_16_OBJOK
            // 
            this.L_P2_16_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_16_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_16_OBJOK.BorderWidth = 0.5F;
            this.L_P2_16_OBJOK.CanGrow = false;
            this.L_P2_16_OBJOK.Dpi = 100F;
            this.L_P2_16_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_16_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 386F);
            this.L_P2_16_OBJOK.Multiline = true;
            this.L_P2_16_OBJOK.Name = "L_P2_16_OBJOK";
            this.L_P2_16_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_16_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_16_OBJOK.Text = "";
            this.L_P2_16_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_16_OBJOK.WordWrap = false;
            // 
            // L_P2_16_PLAN
            // 
            this.L_P2_16_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_16_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_16_PLAN.BorderWidth = 0.5F;
            this.L_P2_16_PLAN.CanGrow = false;
            this.L_P2_16_PLAN.Dpi = 100F;
            this.L_P2_16_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_16_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 386F);
            this.L_P2_16_PLAN.Multiline = true;
            this.L_P2_16_PLAN.Name = "L_P2_16_PLAN";
            this.L_P2_16_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_16_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_16_PLAN.Text = "";
            this.L_P2_16_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_16_PLAN.WordWrap = false;
            // 
            // L_P2_16_CONF
            // 
            this.L_P2_16_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_16_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_16_CONF.BorderWidth = 0.5F;
            this.L_P2_16_CONF.CanGrow = false;
            this.L_P2_16_CONF.Dpi = 100F;
            this.L_P2_16_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_16_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 386F);
            this.L_P2_16_CONF.Multiline = true;
            this.L_P2_16_CONF.Name = "L_P2_16_CONF";
            this.L_P2_16_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_16_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_16_CONF.Text = "";
            this.L_P2_16_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_16_CONF.WordWrap = false;
            // 
            // L_P2_17_NO
            // 
            this.L_P2_17_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_17_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_17_NO.BorderWidth = 0.5F;
            this.L_P2_17_NO.CanGrow = false;
            this.L_P2_17_NO.Dpi = 100F;
            this.L_P2_17_NO.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_17_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 404F);
            this.L_P2_17_NO.Multiline = true;
            this.L_P2_17_NO.Name = "L_P2_17_NO";
            this.L_P2_17_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_17_NO.SizeF = new System.Drawing.SizeF(22F, 18F);
            this.L_P2_17_NO.Text = "17";
            this.L_P2_17_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_17_NO.WordWrap = false;
            // 
            // C_P2_17_ITEMCD
            // 
            this.C_P2_17_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_ITEMCD.BorderWidth = 0.5F;
            this.C_P2_17_ITEMCD.CanGrow = false;
            this.C_P2_17_ITEMCD.Dpi = 100F;
            this.C_P2_17_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(22F, 404F);
            this.C_P2_17_ITEMCD.Multiline = true;
            this.C_P2_17_ITEMCD.Name = "C_P2_17_ITEMCD";
            this.C_P2_17_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_ITEMCD.SizeF = new System.Drawing.SizeF(72F, 18F);
            this.C_P2_17_ITEMCD.Text = "";
            this.C_P2_17_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_17_ITEMCD.WordWrap = false;
            // 
            // C_P2_17_ITEMNM
            // 
            this.C_P2_17_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_ITEMNM.BorderWidth = 0.5F;
            this.C_P2_17_ITEMNM.CanGrow = false;
            this.C_P2_17_ITEMNM.Dpi = 100F;
            this.C_P2_17_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(94F, 404F);
            this.C_P2_17_ITEMNM.Multiline = true;
            this.C_P2_17_ITEMNM.Name = "C_P2_17_ITEMNM";
            this.C_P2_17_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_ITEMNM.SizeF = new System.Drawing.SizeF(118F, 18F);
            this.C_P2_17_ITEMNM.Text = "";
            this.C_P2_17_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_17_ITEMNM.WordWrap = false;
            // 
            // C_P2_17_BADCONT
            // 
            this.C_P2_17_BADCONT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_BADCONT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_BADCONT.BorderWidth = 0.5F;
            this.C_P2_17_BADCONT.CanGrow = false;
            this.C_P2_17_BADCONT.Dpi = 100F;
            this.C_P2_17_BADCONT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_BADCONT.LocationFloat = new DevExpress.Utils.PointFloat(212F, 404F);
            this.C_P2_17_BADCONT.Multiline = true;
            this.C_P2_17_BADCONT.Name = "C_P2_17_BADCONT";
            this.C_P2_17_BADCONT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_BADCONT.SizeF = new System.Drawing.SizeF(100F, 18F);
            this.C_P2_17_BADCONT.Text = "";
            this.C_P2_17_BADCONT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_P2_17_BADCONT.WordWrap = false;
            // 
            // C_P2_17_QTY
            // 
            this.C_P2_17_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_QTY.BorderWidth = 0.5F;
            this.C_P2_17_QTY.CanGrow = false;
            this.C_P2_17_QTY.Dpi = 100F;
            this.C_P2_17_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 404F);
            this.C_P2_17_QTY.Multiline = true;
            this.C_P2_17_QTY.Name = "C_P2_17_QTY";
            this.C_P2_17_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_17_QTY.Text = "";
            this.C_P2_17_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_17_QTY.WordWrap = false;
            // 
            // C_P2_17_INPRICE
            // 
            this.C_P2_17_INPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_INPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_INPRICE.BorderWidth = 0.5F;
            this.C_P2_17_INPRICE.CanGrow = false;
            this.C_P2_17_INPRICE.Dpi = 100F;
            this.C_P2_17_INPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_INPRICE.LocationFloat = new DevExpress.Utils.PointFloat(344F, 404F);
            this.C_P2_17_INPRICE.Multiline = true;
            this.C_P2_17_INPRICE.Name = "C_P2_17_INPRICE";
            this.C_P2_17_INPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_INPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_17_INPRICE.Text = "";
            this.C_P2_17_INPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_17_INPRICE.WordWrap = false;
            // 
            // C_P2_17_MFGPRICE
            // 
            this.C_P2_17_MFGPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_MFGPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_MFGPRICE.BorderWidth = 0.5F;
            this.C_P2_17_MFGPRICE.CanGrow = false;
            this.C_P2_17_MFGPRICE.Dpi = 100F;
            this.C_P2_17_MFGPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_MFGPRICE.LocationFloat = new DevExpress.Utils.PointFloat(392F, 404F);
            this.C_P2_17_MFGPRICE.Multiline = true;
            this.C_P2_17_MFGPRICE.Name = "C_P2_17_MFGPRICE";
            this.C_P2_17_MFGPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_MFGPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_17_MFGPRICE.Text = "";
            this.C_P2_17_MFGPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_17_MFGPRICE.WordWrap = false;
            // 
            // C_P2_17_SALEPRICE
            // 
            this.C_P2_17_SALEPRICE.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_SALEPRICE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_SALEPRICE.BorderWidth = 0.5F;
            this.C_P2_17_SALEPRICE.CanGrow = false;
            this.C_P2_17_SALEPRICE.Dpi = 100F;
            this.C_P2_17_SALEPRICE.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_SALEPRICE.LocationFloat = new DevExpress.Utils.PointFloat(440F, 404F);
            this.C_P2_17_SALEPRICE.Multiline = true;
            this.C_P2_17_SALEPRICE.Name = "C_P2_17_SALEPRICE";
            this.C_P2_17_SALEPRICE.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_SALEPRICE.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_17_SALEPRICE.Text = "";
            this.C_P2_17_SALEPRICE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_17_SALEPRICE.WordWrap = false;
            // 
            // C_P2_17_ETCAMT
            // 
            this.C_P2_17_ETCAMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_ETCAMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_ETCAMT.BorderWidth = 0.5F;
            this.C_P2_17_ETCAMT.CanGrow = false;
            this.C_P2_17_ETCAMT.Dpi = 100F;
            this.C_P2_17_ETCAMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_ETCAMT.LocationFloat = new DevExpress.Utils.PointFloat(488F, 404F);
            this.C_P2_17_ETCAMT.Multiline = true;
            this.C_P2_17_ETCAMT.Name = "C_P2_17_ETCAMT";
            this.C_P2_17_ETCAMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_ETCAMT.SizeF = new System.Drawing.SizeF(48F, 18F);
            this.C_P2_17_ETCAMT.Text = "";
            this.C_P2_17_ETCAMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_17_ETCAMT.WordWrap = false;
            // 
            // C_P2_17_AMT
            // 
            this.C_P2_17_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_17_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_17_AMT.BorderWidth = 0.5F;
            this.C_P2_17_AMT.CanGrow = false;
            this.C_P2_17_AMT.Dpi = 100F;
            this.C_P2_17_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.C_P2_17_AMT.LocationFloat = new DevExpress.Utils.PointFloat(536F, 404F);
            this.C_P2_17_AMT.Multiline = true;
            this.C_P2_17_AMT.Name = "C_P2_17_AMT";
            this.C_P2_17_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_17_AMT.SizeF = new System.Drawing.SizeF(60F, 18F);
            this.C_P2_17_AMT.Text = "";
            this.C_P2_17_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_17_AMT.WordWrap = false;
            // 
            // L_P2_17_OBJREQ
            // 
            this.L_P2_17_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_17_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_17_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_17_OBJREQ.CanGrow = false;
            this.L_P2_17_OBJREQ.Dpi = 100F;
            this.L_P2_17_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_17_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 404F);
            this.L_P2_17_OBJREQ.Multiline = true;
            this.L_P2_17_OBJREQ.Name = "L_P2_17_OBJREQ";
            this.L_P2_17_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_17_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_17_OBJREQ.Text = "";
            this.L_P2_17_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_17_OBJREQ.WordWrap = false;
            // 
            // L_P2_17_OBJOK
            // 
            this.L_P2_17_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_17_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_17_OBJOK.BorderWidth = 0.5F;
            this.L_P2_17_OBJOK.CanGrow = false;
            this.L_P2_17_OBJOK.Dpi = 100F;
            this.L_P2_17_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_17_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 404F);
            this.L_P2_17_OBJOK.Multiline = true;
            this.L_P2_17_OBJOK.Name = "L_P2_17_OBJOK";
            this.L_P2_17_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_17_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_17_OBJOK.Text = "";
            this.L_P2_17_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_17_OBJOK.WordWrap = false;
            // 
            // L_P2_17_PLAN
            // 
            this.L_P2_17_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_17_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_17_PLAN.BorderWidth = 0.5F;
            this.L_P2_17_PLAN.CanGrow = false;
            this.L_P2_17_PLAN.Dpi = 100F;
            this.L_P2_17_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_17_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 404F);
            this.L_P2_17_PLAN.Multiline = true;
            this.L_P2_17_PLAN.Name = "L_P2_17_PLAN";
            this.L_P2_17_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_17_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_17_PLAN.Text = "";
            this.L_P2_17_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_17_PLAN.WordWrap = false;
            // 
            // L_P2_17_CONF
            // 
            this.L_P2_17_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_17_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_17_CONF.BorderWidth = 0.5F;
            this.L_P2_17_CONF.CanGrow = false;
            this.L_P2_17_CONF.Dpi = 100F;
            this.L_P2_17_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_17_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 404F);
            this.L_P2_17_CONF.Multiline = true;
            this.L_P2_17_CONF.Name = "L_P2_17_CONF";
            this.L_P2_17_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_17_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_17_CONF.Text = "";
            this.L_P2_17_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_17_CONF.WordWrap = false;
            // 
            // L_P2_SUM
            // 
            this.L_P2_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_SUM.BorderColor = System.Drawing.Color.Black;
            this.L_P2_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_SUM.BorderWidth = 0.5F;
            this.L_P2_SUM.CanGrow = false;
            this.L_P2_SUM.Dpi = 100F;
            this.L_P2_SUM.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold);
            this.L_P2_SUM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 422F);
            this.L_P2_SUM.Multiline = true;
            this.L_P2_SUM.Name = "L_P2_SUM";
            this.L_P2_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_SUM.SizeF = new System.Drawing.SizeF(312F, 18F);
            this.L_P2_SUM.Text = "합   계";
            this.L_P2_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_SUM.WordWrap = false;
            // 
            // C_P2_SUM_QTY
            // 
            this.C_P2_SUM_QTY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.C_P2_SUM_QTY.BorderColor = System.Drawing.Color.Black;
            this.C_P2_SUM_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_SUM_QTY.BorderWidth = 0.5F;
            this.C_P2_SUM_QTY.CanGrow = false;
            this.C_P2_SUM_QTY.Dpi = 100F;
            this.C_P2_SUM_QTY.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold);
            this.C_P2_SUM_QTY.LocationFloat = new DevExpress.Utils.PointFloat(312F, 422F);
            this.C_P2_SUM_QTY.Multiline = true;
            this.C_P2_SUM_QTY.Name = "C_P2_SUM_QTY";
            this.C_P2_SUM_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_SUM_QTY.SizeF = new System.Drawing.SizeF(32F, 18F);
            this.C_P2_SUM_QTY.Text = "";
            this.C_P2_SUM_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_SUM_QTY.WordWrap = false;
            // 
            // C_P2_SUM_AMT
            // 
            this.C_P2_SUM_AMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.C_P2_SUM_AMT.BorderColor = System.Drawing.Color.Black;
            this.C_P2_SUM_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_P2_SUM_AMT.BorderWidth = 0.5F;
            this.C_P2_SUM_AMT.CanGrow = false;
            this.C_P2_SUM_AMT.Dpi = 100F;
            this.C_P2_SUM_AMT.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold);
            this.C_P2_SUM_AMT.LocationFloat = new DevExpress.Utils.PointFloat(344F, 422F);
            this.C_P2_SUM_AMT.Multiline = true;
            this.C_P2_SUM_AMT.Name = "C_P2_SUM_AMT";
            this.C_P2_SUM_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_P2_SUM_AMT.SizeF = new System.Drawing.SizeF(252F, 18F);
            this.C_P2_SUM_AMT.Text = "";
            this.C_P2_SUM_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_P2_SUM_AMT.WordWrap = false;
            // 
            // L_P2_SUM_OBJREQ
            // 
            this.L_P2_SUM_OBJREQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_SUM_OBJREQ.BorderColor = System.Drawing.Color.Black;
            this.L_P2_SUM_OBJREQ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_SUM_OBJREQ.BorderWidth = 0.5F;
            this.L_P2_SUM_OBJREQ.CanGrow = false;
            this.L_P2_SUM_OBJREQ.Dpi = 100F;
            this.L_P2_SUM_OBJREQ.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_SUM_OBJREQ.LocationFloat = new DevExpress.Utils.PointFloat(596F, 422F);
            this.L_P2_SUM_OBJREQ.Multiline = true;
            this.L_P2_SUM_OBJREQ.Name = "L_P2_SUM_OBJREQ";
            this.L_P2_SUM_OBJREQ.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_SUM_OBJREQ.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_SUM_OBJREQ.Text = "";
            this.L_P2_SUM_OBJREQ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_SUM_OBJREQ.WordWrap = false;
            // 
            // L_P2_SUM_OBJOK
            // 
            this.L_P2_SUM_OBJOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_SUM_OBJOK.BorderColor = System.Drawing.Color.Black;
            this.L_P2_SUM_OBJOK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_SUM_OBJOK.BorderWidth = 0.5F;
            this.L_P2_SUM_OBJOK.CanGrow = false;
            this.L_P2_SUM_OBJOK.Dpi = 100F;
            this.L_P2_SUM_OBJOK.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_SUM_OBJOK.LocationFloat = new DevExpress.Utils.PointFloat(639F, 422F);
            this.L_P2_SUM_OBJOK.Multiline = true;
            this.L_P2_SUM_OBJOK.Name = "L_P2_SUM_OBJOK";
            this.L_P2_SUM_OBJOK.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_SUM_OBJOK.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_SUM_OBJOK.Text = "";
            this.L_P2_SUM_OBJOK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_SUM_OBJOK.WordWrap = false;
            // 
            // L_P2_SUM_PLAN
            // 
            this.L_P2_SUM_PLAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_SUM_PLAN.BorderColor = System.Drawing.Color.Black;
            this.L_P2_SUM_PLAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_SUM_PLAN.BorderWidth = 0.5F;
            this.L_P2_SUM_PLAN.CanGrow = false;
            this.L_P2_SUM_PLAN.Dpi = 100F;
            this.L_P2_SUM_PLAN.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_SUM_PLAN.LocationFloat = new DevExpress.Utils.PointFloat(682F, 422F);
            this.L_P2_SUM_PLAN.Multiline = true;
            this.L_P2_SUM_PLAN.Name = "L_P2_SUM_PLAN";
            this.L_P2_SUM_PLAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_SUM_PLAN.SizeF = new System.Drawing.SizeF(42F, 18F);
            this.L_P2_SUM_PLAN.Text = "";
            this.L_P2_SUM_PLAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_SUM_PLAN.WordWrap = false;
            // 
            // L_P2_SUM_CONF
            // 
            this.L_P2_SUM_CONF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_SUM_CONF.BorderColor = System.Drawing.Color.Black;
            this.L_P2_SUM_CONF.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_SUM_CONF.BorderWidth = 0.5F;
            this.L_P2_SUM_CONF.CanGrow = false;
            this.L_P2_SUM_CONF.Dpi = 100F;
            this.L_P2_SUM_CONF.Font = new System.Drawing.Font("맑은 고딕", 6.5F);
            this.L_P2_SUM_CONF.LocationFloat = new DevExpress.Utils.PointFloat(724F, 422F);
            this.L_P2_SUM_CONF.Multiline = true;
            this.L_P2_SUM_CONF.Name = "L_P2_SUM_CONF";
            this.L_P2_SUM_CONF.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_SUM_CONF.SizeF = new System.Drawing.SizeF(43F, 18F);
            this.L_P2_SUM_CONF.Text = "";
            this.L_P2_SUM_CONF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_SUM_CONF.WordWrap = false;
            // 
            // L_P2_C_H_NO
            // 
            this.L_P2_C_H_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_C_H_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_H_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_H_NO.BorderWidth = 0.5F;
            this.L_P2_C_H_NO.CanGrow = false;
            this.L_P2_C_H_NO.Dpi = 100F;
            this.L_P2_C_H_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 460F);
            this.L_P2_C_H_NO.Multiline = true;
            this.L_P2_C_H_NO.Name = "L_P2_C_H_NO";
            this.L_P2_C_H_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_C_H_NO.SizeF = new System.Drawing.SizeF(22F, 22F);
            this.L_P2_C_H_NO.Text = "NO";
            this.L_P2_C_H_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_H_NO.WordWrap = false;
            // 
            // L_P2_C_H_TP
            // 
            this.L_P2_C_H_TP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_C_H_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_H_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_H_TP.BorderWidth = 0.5F;
            this.L_P2_C_H_TP.CanGrow = false;
            this.L_P2_C_H_TP.Dpi = 100F;
            this.L_P2_C_H_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 460F);
            this.L_P2_C_H_TP.Multiline = true;
            this.L_P2_C_H_TP.Name = "L_P2_C_H_TP";
            this.L_P2_C_H_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_H_TP.SizeF = new System.Drawing.SizeF(150F, 22F);
            this.L_P2_C_H_TP.Text = "구   분";
            this.L_P2_C_H_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_H_TP.WordWrap = false;
            // 
            // L_P2_C_H_STD
            // 
            this.L_P2_C_H_STD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_C_H_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_H_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_H_STD.BorderWidth = 0.5F;
            this.L_P2_C_H_STD.CanGrow = false;
            this.L_P2_C_H_STD.Dpi = 100F;
            this.L_P2_C_H_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 460F);
            this.L_P2_C_H_STD.Multiline = true;
            this.L_P2_C_H_STD.Name = "L_P2_C_H_STD";
            this.L_P2_C_H_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_H_STD.SizeF = new System.Drawing.SizeF(200F, 22F);
            this.L_P2_C_H_STD.Text = "산출 기준";
            this.L_P2_C_H_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_H_STD.WordWrap = false;
            // 
            // L_P2_C_H_BASIS
            // 
            this.L_P2_C_H_BASIS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_C_H_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_H_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_H_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_H_BASIS.CanGrow = false;
            this.L_P2_C_H_BASIS.Dpi = 100F;
            this.L_P2_C_H_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 460F);
            this.L_P2_C_H_BASIS.Multiline = true;
            this.L_P2_C_H_BASIS.Name = "L_P2_C_H_BASIS";
            this.L_P2_C_H_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_H_BASIS.SizeF = new System.Drawing.SizeF(160F, 22F);
            this.L_P2_C_H_BASIS.Text = "제반비용 산출 근거";
            this.L_P2_C_H_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_H_BASIS.WordWrap = false;
            // 
            // L_P2_C_H_AMT
            // 
            this.L_P2_C_H_AMT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_C_H_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_H_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_H_AMT.BorderWidth = 0.5F;
            this.L_P2_C_H_AMT.CanGrow = false;
            this.L_P2_C_H_AMT.Dpi = 100F;
            this.L_P2_C_H_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 460F);
            this.L_P2_C_H_AMT.Multiline = true;
            this.L_P2_C_H_AMT.Name = "L_P2_C_H_AMT";
            this.L_P2_C_H_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_H_AMT.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.L_P2_C_H_AMT.Text = "산출금액";
            this.L_P2_C_H_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_H_AMT.WordWrap = false;
            // 
            // L_P2_C_H_RATE
            // 
            this.L_P2_C_H_RATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_C_H_RATE.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_H_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_H_RATE.BorderWidth = 0.5F;
            this.L_P2_C_H_RATE.CanGrow = false;
            this.L_P2_C_H_RATE.Dpi = 100F;
            this.L_P2_C_H_RATE.LocationFloat = new DevExpress.Utils.PointFloat(622F, 460F);
            this.L_P2_C_H_RATE.Multiline = true;
            this.L_P2_C_H_RATE.Name = "L_P2_C_H_RATE";
            this.L_P2_C_H_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_H_RATE.SizeF = new System.Drawing.SizeF(145F, 22F);
            this.L_P2_C_H_RATE.Text = "적용 임율 기준";
            this.L_P2_C_H_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_H_RATE.WordWrap = false;
            // 
            // L_P2_C_1_NO
            // 
            this.L_P2_C_1_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_1_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_1_NO.BorderWidth = 0.5F;
            this.L_P2_C_1_NO.CanGrow = false;
            this.L_P2_C_1_NO.Dpi = 100F;
            this.L_P2_C_1_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 482F);
            this.L_P2_C_1_NO.Multiline = true;
            this.L_P2_C_1_NO.Name = "L_P2_C_1_NO";
            this.L_P2_C_1_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_C_1_NO.SizeF = new System.Drawing.SizeF(22F, 60F);
            this.L_P2_C_1_NO.Text = "1";
            this.L_P2_C_1_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_1_NO.WordWrap = false;
            // 
            // L_P2_C_1_TP
            // 
            this.L_P2_C_1_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_1_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_1_TP.BorderWidth = 0.5F;
            this.L_P2_C_1_TP.CanGrow = false;
            this.L_P2_C_1_TP.Dpi = 100F;
            this.L_P2_C_1_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 482F);
            this.L_P2_C_1_TP.Multiline = true;
            this.L_P2_C_1_TP.Name = "L_P2_C_1_TP";
            this.L_P2_C_1_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_1_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_1_TP.Text = "품질비용";
            this.L_P2_C_1_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_1_TP.WordWrap = false;
            // 
            // L_P2_C_1_STD
            // 
            this.L_P2_C_1_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_1_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_1_STD.BorderWidth = 0.5F;
            this.L_P2_C_1_STD.CanGrow = false;
            this.L_P2_C_1_STD.Dpi = 100F;
            this.L_P2_C_1_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 482F);
            this.L_P2_C_1_STD.Multiline = true;
            this.L_P2_C_1_STD.Name = "L_P2_C_1_STD";
            this.L_P2_C_1_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_1_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_1_STD.Text = "(a) + (b)";
            this.L_P2_C_1_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_1_STD.WordWrap = false;
            // 
            // L_P2_C_1_BASIS
            // 
            this.L_P2_C_1_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_1_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_1_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_1_BASIS.CanGrow = false;
            this.L_P2_C_1_BASIS.Dpi = 100F;
            this.L_P2_C_1_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 482F);
            this.L_P2_C_1_BASIS.Multiline = true;
            this.L_P2_C_1_BASIS.Name = "L_P2_C_1_BASIS";
            this.L_P2_C_1_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_1_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_1_BASIS.Text = "";
            this.L_P2_C_1_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_1_BASIS.WordWrap = false;
            // 
            // L_P2_C_1_AMT
            // 
            this.L_P2_C_1_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_1_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_1_AMT.BorderWidth = 0.5F;
            this.L_P2_C_1_AMT.CanGrow = false;
            this.L_P2_C_1_AMT.Dpi = 100F;
            this.L_P2_C_1_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 482F);
            this.L_P2_C_1_AMT.Multiline = true;
            this.L_P2_C_1_AMT.Name = "L_P2_C_1_AMT";
            this.L_P2_C_1_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_1_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_1_AMT.Text = "";
            this.L_P2_C_1_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_1_AMT.WordWrap = false;
            // 
            // L_P2_C_1_RATE
            // 
            this.L_P2_C_1_RATE.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_1_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_1_RATE.BorderWidth = 0.5F;
            this.L_P2_C_1_RATE.CanGrow = false;
            this.L_P2_C_1_RATE.Dpi = 100F;
            this.L_P2_C_1_RATE.LocationFloat = new DevExpress.Utils.PointFloat(622F, 482F);
            this.L_P2_C_1_RATE.Multiline = true;
            this.L_P2_C_1_RATE.Name = "L_P2_C_1_RATE";
            this.L_P2_C_1_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_1_RATE.SizeF = new System.Drawing.SizeF(145F, 20F);
            this.L_P2_C_1_RATE.Text = "";
            this.L_P2_C_1_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_1_RATE.WordWrap = false;
            // 
            // L_P2_C_2_TP
            // 
            this.L_P2_C_2_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_2_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_2_TP.BorderWidth = 0.5F;
            this.L_P2_C_2_TP.CanGrow = false;
            this.L_P2_C_2_TP.Dpi = 100F;
            this.L_P2_C_2_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 502F);
            this.L_P2_C_2_TP.Multiline = true;
            this.L_P2_C_2_TP.Name = "L_P2_C_2_TP";
            this.L_P2_C_2_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_2_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_2_TP.Text = " (a) 품질조사 비용";
            this.L_P2_C_2_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_2_TP.WordWrap = false;
            // 
            // L_P2_C_2_STD
            // 
            this.L_P2_C_2_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_2_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_2_STD.BorderWidth = 0.5F;
            this.L_P2_C_2_STD.CanGrow = false;
            this.L_P2_C_2_STD.Dpi = 100F;
            this.L_P2_C_2_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 502F);
            this.L_P2_C_2_STD.Multiline = true;
            this.L_P2_C_2_STD.Name = "L_P2_C_2_STD";
            this.L_P2_C_2_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_2_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_2_STD.Text = "총 투입(조사)시간*인원*간접직 임율";
            this.L_P2_C_2_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_2_STD.WordWrap = false;
            // 
            // L_P2_C_2_BASIS
            // 
            this.L_P2_C_2_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_2_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_2_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_2_BASIS.CanGrow = false;
            this.L_P2_C_2_BASIS.Dpi = 100F;
            this.L_P2_C_2_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 502F);
            this.L_P2_C_2_BASIS.Multiline = true;
            this.L_P2_C_2_BASIS.Name = "L_P2_C_2_BASIS";
            this.L_P2_C_2_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_2_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_2_BASIS.Text = "";
            this.L_P2_C_2_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_2_BASIS.WordWrap = false;
            // 
            // L_P2_C_2_AMT
            // 
            this.L_P2_C_2_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_2_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_2_AMT.BorderWidth = 0.5F;
            this.L_P2_C_2_AMT.CanGrow = false;
            this.L_P2_C_2_AMT.Dpi = 100F;
            this.L_P2_C_2_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 502F);
            this.L_P2_C_2_AMT.Multiline = true;
            this.L_P2_C_2_AMT.Name = "L_P2_C_2_AMT";
            this.L_P2_C_2_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_2_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_2_AMT.Text = "";
            this.L_P2_C_2_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_2_AMT.WordWrap = false;
            // 
            // L_P2_C_2_RATE
            // 
            this.L_P2_C_2_RATE.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_2_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_2_RATE.BorderWidth = 0.5F;
            this.L_P2_C_2_RATE.CanGrow = false;
            this.L_P2_C_2_RATE.Dpi = 100F;
            this.L_P2_C_2_RATE.LocationFloat = new DevExpress.Utils.PointFloat(622F, 502F);
            this.L_P2_C_2_RATE.Multiline = true;
            this.L_P2_C_2_RATE.Name = "L_P2_C_2_RATE";
            this.L_P2_C_2_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_2_RATE.SizeF = new System.Drawing.SizeF(145F, 20F);
            this.L_P2_C_2_RATE.Text = "";
            this.L_P2_C_2_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_2_RATE.WordWrap = false;
            // 
            // L_P2_C_3_TP
            // 
            this.L_P2_C_3_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_3_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_3_TP.BorderWidth = 0.5F;
            this.L_P2_C_3_TP.CanGrow = false;
            this.L_P2_C_3_TP.Dpi = 100F;
            this.L_P2_C_3_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 522F);
            this.L_P2_C_3_TP.Multiline = true;
            this.L_P2_C_3_TP.Name = "L_P2_C_3_TP";
            this.L_P2_C_3_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_3_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_3_TP.Text = " (b) 행정업무 비용";
            this.L_P2_C_3_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_3_TP.WordWrap = false;
            // 
            // L_P2_C_3_STD
            // 
            this.L_P2_C_3_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_3_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_3_STD.BorderWidth = 0.5F;
            this.L_P2_C_3_STD.CanGrow = false;
            this.L_P2_C_3_STD.Dpi = 100F;
            this.L_P2_C_3_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 522F);
            this.L_P2_C_3_STD.Multiline = true;
            this.L_P2_C_3_STD.Name = "L_P2_C_3_STD";
            this.L_P2_C_3_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_3_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_3_STD.Text = "총 투입(행정)시간*인원*간접직 임율";
            this.L_P2_C_3_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_3_STD.WordWrap = false;
            // 
            // L_P2_C_3_BASIS
            // 
            this.L_P2_C_3_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_3_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_3_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_3_BASIS.CanGrow = false;
            this.L_P2_C_3_BASIS.Dpi = 100F;
            this.L_P2_C_3_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 522F);
            this.L_P2_C_3_BASIS.Multiline = true;
            this.L_P2_C_3_BASIS.Name = "L_P2_C_3_BASIS";
            this.L_P2_C_3_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_3_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_3_BASIS.Text = "";
            this.L_P2_C_3_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_3_BASIS.WordWrap = false;
            // 
            // L_P2_C_3_AMT
            // 
            this.L_P2_C_3_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_3_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_3_AMT.BorderWidth = 0.5F;
            this.L_P2_C_3_AMT.CanGrow = false;
            this.L_P2_C_3_AMT.Dpi = 100F;
            this.L_P2_C_3_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 522F);
            this.L_P2_C_3_AMT.Multiline = true;
            this.L_P2_C_3_AMT.Name = "L_P2_C_3_AMT";
            this.L_P2_C_3_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_3_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_3_AMT.Text = "";
            this.L_P2_C_3_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_3_AMT.WordWrap = false;
            // 
            // L_P2_C_3_RATE
            // 
            this.L_P2_C_3_RATE.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_3_RATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_3_RATE.BorderWidth = 0.5F;
            this.L_P2_C_3_RATE.CanGrow = false;
            this.L_P2_C_3_RATE.Dpi = 100F;
            this.L_P2_C_3_RATE.LocationFloat = new DevExpress.Utils.PointFloat(622F, 522F);
            this.L_P2_C_3_RATE.Multiline = true;
            this.L_P2_C_3_RATE.Name = "L_P2_C_3_RATE";
            this.L_P2_C_3_RATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_3_RATE.SizeF = new System.Drawing.SizeF(145F, 20F);
            this.L_P2_C_3_RATE.Text = "";
            this.L_P2_C_3_RATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_3_RATE.WordWrap = false;
            // 
            // L_P2_C_4_NO
            // 
            this.L_P2_C_4_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_4_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_4_NO.BorderWidth = 0.5F;
            this.L_P2_C_4_NO.CanGrow = false;
            this.L_P2_C_4_NO.Dpi = 100F;
            this.L_P2_C_4_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 542F);
            this.L_P2_C_4_NO.Multiline = true;
            this.L_P2_C_4_NO.Name = "L_P2_C_4_NO";
            this.L_P2_C_4_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_C_4_NO.SizeF = new System.Drawing.SizeF(22F, 20F);
            this.L_P2_C_4_NO.Text = "2";
            this.L_P2_C_4_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_4_NO.WordWrap = false;
            // 
            // L_P2_C_4_TP
            // 
            this.L_P2_C_4_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_4_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_4_TP.BorderWidth = 0.5F;
            this.L_P2_C_4_TP.CanGrow = false;
            this.L_P2_C_4_TP.Dpi = 100F;
            this.L_P2_C_4_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 542F);
            this.L_P2_C_4_TP.Multiline = true;
            this.L_P2_C_4_TP.Name = "L_P2_C_4_TP";
            this.L_P2_C_4_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_4_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_4_TP.Text = "공정품/완성품";
            this.L_P2_C_4_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_4_TP.WordWrap = false;
            // 
            // L_P2_C_4_STD
            // 
            this.L_P2_C_4_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_4_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_4_STD.BorderWidth = 0.5F;
            this.L_P2_C_4_STD.CanGrow = false;
            this.L_P2_C_4_STD.Dpi = 100F;
            this.L_P2_C_4_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 542F);
            this.L_P2_C_4_STD.Multiline = true;
            this.L_P2_C_4_STD.Name = "L_P2_C_4_STD";
            this.L_P2_C_4_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_4_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_4_STD.Text = "발생수량*(제조원가*100%)";
            this.L_P2_C_4_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_4_STD.WordWrap = false;
            // 
            // L_P2_C_4_BASIS
            // 
            this.L_P2_C_4_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_4_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_4_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_4_BASIS.CanGrow = false;
            this.L_P2_C_4_BASIS.Dpi = 100F;
            this.L_P2_C_4_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 542F);
            this.L_P2_C_4_BASIS.Multiline = true;
            this.L_P2_C_4_BASIS.Name = "L_P2_C_4_BASIS";
            this.L_P2_C_4_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_4_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_4_BASIS.Text = "";
            this.L_P2_C_4_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_4_BASIS.WordWrap = false;
            // 
            // L_P2_C_4_AMT
            // 
            this.L_P2_C_4_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_4_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_4_AMT.BorderWidth = 0.5F;
            this.L_P2_C_4_AMT.CanGrow = false;
            this.L_P2_C_4_AMT.Dpi = 100F;
            this.L_P2_C_4_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 542F);
            this.L_P2_C_4_AMT.Multiline = true;
            this.L_P2_C_4_AMT.Name = "L_P2_C_4_AMT";
            this.L_P2_C_4_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_4_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_4_AMT.Text = "";
            this.L_P2_C_4_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_4_AMT.WordWrap = false;
            // 
            // L_P2_C_5_NO
            // 
            this.L_P2_C_5_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_5_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_5_NO.BorderWidth = 0.5F;
            this.L_P2_C_5_NO.CanGrow = false;
            this.L_P2_C_5_NO.Dpi = 100F;
            this.L_P2_C_5_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 562F);
            this.L_P2_C_5_NO.Multiline = true;
            this.L_P2_C_5_NO.Name = "L_P2_C_5_NO";
            this.L_P2_C_5_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_C_5_NO.SizeF = new System.Drawing.SizeF(22F, 20F);
            this.L_P2_C_5_NO.Text = "3";
            this.L_P2_C_5_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_5_NO.WordWrap = false;
            // 
            // L_P2_C_5_TP
            // 
            this.L_P2_C_5_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_5_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_5_TP.BorderWidth = 0.5F;
            this.L_P2_C_5_TP.CanGrow = false;
            this.L_P2_C_5_TP.Dpi = 100F;
            this.L_P2_C_5_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 562F);
            this.L_P2_C_5_TP.Multiline = true;
            this.L_P2_C_5_TP.Name = "L_P2_C_5_TP";
            this.L_P2_C_5_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_5_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_5_TP.Text = "LINE 정지";
            this.L_P2_C_5_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_5_TP.WordWrap = false;
            // 
            // L_P2_C_5_STD
            // 
            this.L_P2_C_5_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_5_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_5_STD.BorderWidth = 0.5F;
            this.L_P2_C_5_STD.CanGrow = false;
            this.L_P2_C_5_STD.Dpi = 100F;
            this.L_P2_C_5_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 562F);
            this.L_P2_C_5_STD.Multiline = true;
            this.L_P2_C_5_STD.Name = "L_P2_C_5_STD";
            this.L_P2_C_5_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_5_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_5_STD.Text = "라인 정지시간*부가가치액";
            this.L_P2_C_5_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_5_STD.WordWrap = false;
            // 
            // L_P2_C_5_BASIS
            // 
            this.L_P2_C_5_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_5_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_5_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_5_BASIS.CanGrow = false;
            this.L_P2_C_5_BASIS.Dpi = 100F;
            this.L_P2_C_5_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 562F);
            this.L_P2_C_5_BASIS.Multiline = true;
            this.L_P2_C_5_BASIS.Name = "L_P2_C_5_BASIS";
            this.L_P2_C_5_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_5_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_5_BASIS.Text = "";
            this.L_P2_C_5_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_5_BASIS.WordWrap = false;
            // 
            // L_P2_C_5_AMT
            // 
            this.L_P2_C_5_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_5_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_5_AMT.BorderWidth = 0.5F;
            this.L_P2_C_5_AMT.CanGrow = false;
            this.L_P2_C_5_AMT.Dpi = 100F;
            this.L_P2_C_5_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 562F);
            this.L_P2_C_5_AMT.Multiline = true;
            this.L_P2_C_5_AMT.Name = "L_P2_C_5_AMT";
            this.L_P2_C_5_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_5_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_5_AMT.Text = "";
            this.L_P2_C_5_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_5_AMT.WordWrap = false;
            // 
            // L_P2_C_6_NO
            // 
            this.L_P2_C_6_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_6_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_6_NO.BorderWidth = 0.5F;
            this.L_P2_C_6_NO.CanGrow = false;
            this.L_P2_C_6_NO.Dpi = 100F;
            this.L_P2_C_6_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 582F);
            this.L_P2_C_6_NO.Multiline = true;
            this.L_P2_C_6_NO.Name = "L_P2_C_6_NO";
            this.L_P2_C_6_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_C_6_NO.SizeF = new System.Drawing.SizeF(22F, 20F);
            this.L_P2_C_6_NO.Text = "4";
            this.L_P2_C_6_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_6_NO.WordWrap = false;
            // 
            // L_P2_C_6_TP
            // 
            this.L_P2_C_6_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_6_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_6_TP.BorderWidth = 0.5F;
            this.L_P2_C_6_TP.CanGrow = false;
            this.L_P2_C_6_TP.Dpi = 100F;
            this.L_P2_C_6_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 582F);
            this.L_P2_C_6_TP.Multiline = true;
            this.L_P2_C_6_TP.Name = "L_P2_C_6_TP";
            this.L_P2_C_6_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_6_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_6_TP.Text = "선별 및 수정";
            this.L_P2_C_6_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_6_TP.WordWrap = false;
            // 
            // L_P2_C_6_STD
            // 
            this.L_P2_C_6_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_6_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_6_STD.BorderWidth = 0.5F;
            this.L_P2_C_6_STD.CanGrow = false;
            this.L_P2_C_6_STD.Dpi = 100F;
            this.L_P2_C_6_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 582F);
            this.L_P2_C_6_STD.Multiline = true;
            this.L_P2_C_6_STD.Name = "L_P2_C_6_STD";
            this.L_P2_C_6_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_6_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_6_STD.Text = "사내,외 투입인원*투입시간*비용";
            this.L_P2_C_6_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_6_STD.WordWrap = false;
            // 
            // L_P2_C_6_BASIS
            // 
            this.L_P2_C_6_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_6_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_6_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_6_BASIS.CanGrow = false;
            this.L_P2_C_6_BASIS.Dpi = 100F;
            this.L_P2_C_6_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 582F);
            this.L_P2_C_6_BASIS.Multiline = true;
            this.L_P2_C_6_BASIS.Name = "L_P2_C_6_BASIS";
            this.L_P2_C_6_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_6_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_6_BASIS.Text = "";
            this.L_P2_C_6_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_6_BASIS.WordWrap = false;
            // 
            // L_P2_C_6_AMT
            // 
            this.L_P2_C_6_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_6_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_6_AMT.BorderWidth = 0.5F;
            this.L_P2_C_6_AMT.CanGrow = false;
            this.L_P2_C_6_AMT.Dpi = 100F;
            this.L_P2_C_6_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 582F);
            this.L_P2_C_6_AMT.Multiline = true;
            this.L_P2_C_6_AMT.Name = "L_P2_C_6_AMT";
            this.L_P2_C_6_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_6_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_6_AMT.Text = "";
            this.L_P2_C_6_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_6_AMT.WordWrap = false;
            // 
            // L_P2_C_7_NO
            // 
            this.L_P2_C_7_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_7_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_7_NO.BorderWidth = 0.5F;
            this.L_P2_C_7_NO.CanGrow = false;
            this.L_P2_C_7_NO.Dpi = 100F;
            this.L_P2_C_7_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 602F);
            this.L_P2_C_7_NO.Multiline = true;
            this.L_P2_C_7_NO.Name = "L_P2_C_7_NO";
            this.L_P2_C_7_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_C_7_NO.SizeF = new System.Drawing.SizeF(22F, 20F);
            this.L_P2_C_7_NO.Text = "5";
            this.L_P2_C_7_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_7_NO.WordWrap = false;
            // 
            // L_P2_C_7_TP
            // 
            this.L_P2_C_7_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_7_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_7_TP.BorderWidth = 0.5F;
            this.L_P2_C_7_TP.CanGrow = false;
            this.L_P2_C_7_TP.Dpi = 100F;
            this.L_P2_C_7_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 602F);
            this.L_P2_C_7_TP.Multiline = true;
            this.L_P2_C_7_TP.Name = "L_P2_C_7_TP";
            this.L_P2_C_7_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_7_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_7_TP.Text = "기타(출장비등)";
            this.L_P2_C_7_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_7_TP.WordWrap = false;
            // 
            // L_P2_C_7_STD
            // 
            this.L_P2_C_7_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_7_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_7_STD.BorderWidth = 0.5F;
            this.L_P2_C_7_STD.CanGrow = false;
            this.L_P2_C_7_STD.Dpi = 100F;
            this.L_P2_C_7_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 602F);
            this.L_P2_C_7_STD.Multiline = true;
            this.L_P2_C_7_STD.Name = "L_P2_C_7_STD";
            this.L_P2_C_7_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_7_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_7_STD.Text = "총 투입비용 정산";
            this.L_P2_C_7_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_7_STD.WordWrap = false;
            // 
            // L_P2_C_7_BASIS
            // 
            this.L_P2_C_7_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_7_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_7_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_7_BASIS.CanGrow = false;
            this.L_P2_C_7_BASIS.Dpi = 100F;
            this.L_P2_C_7_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 602F);
            this.L_P2_C_7_BASIS.Multiline = true;
            this.L_P2_C_7_BASIS.Name = "L_P2_C_7_BASIS";
            this.L_P2_C_7_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_7_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_7_BASIS.Text = "";
            this.L_P2_C_7_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_7_BASIS.WordWrap = false;
            // 
            // L_P2_C_7_AMT
            // 
            this.L_P2_C_7_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_7_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_7_AMT.BorderWidth = 0.5F;
            this.L_P2_C_7_AMT.CanGrow = false;
            this.L_P2_C_7_AMT.Dpi = 100F;
            this.L_P2_C_7_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 602F);
            this.L_P2_C_7_AMT.Multiline = true;
            this.L_P2_C_7_AMT.Name = "L_P2_C_7_AMT";
            this.L_P2_C_7_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_7_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_7_AMT.Text = "";
            this.L_P2_C_7_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_7_AMT.WordWrap = false;
            // 
            // L_P2_C_8_NO
            // 
            this.L_P2_C_8_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_8_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_8_NO.BorderWidth = 0.5F;
            this.L_P2_C_8_NO.CanGrow = false;
            this.L_P2_C_8_NO.Dpi = 100F;
            this.L_P2_C_8_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 622F);
            this.L_P2_C_8_NO.Multiline = true;
            this.L_P2_C_8_NO.Name = "L_P2_C_8_NO";
            this.L_P2_C_8_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_C_8_NO.SizeF = new System.Drawing.SizeF(22F, 20F);
            this.L_P2_C_8_NO.Text = "6";
            this.L_P2_C_8_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_8_NO.WordWrap = false;
            // 
            // L_P2_C_8_TP
            // 
            this.L_P2_C_8_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_8_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_8_TP.BorderWidth = 0.5F;
            this.L_P2_C_8_TP.CanGrow = false;
            this.L_P2_C_8_TP.Dpi = 100F;
            this.L_P2_C_8_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 622F);
            this.L_P2_C_8_TP.Multiline = true;
            this.L_P2_C_8_TP.Name = "L_P2_C_8_TP";
            this.L_P2_C_8_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_8_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_8_TP.Text = "품질신고비용";
            this.L_P2_C_8_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_8_TP.WordWrap = false;
            // 
            // L_P2_C_8_STD
            // 
            this.L_P2_C_8_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_8_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_8_STD.BorderWidth = 0.5F;
            this.L_P2_C_8_STD.CanGrow = false;
            this.L_P2_C_8_STD.Dpi = 100F;
            this.L_P2_C_8_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 622F);
            this.L_P2_C_8_STD.Multiline = true;
            this.L_P2_C_8_STD.Name = "L_P2_C_8_STD";
            this.L_P2_C_8_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_8_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_8_STD.Text = "발견자 포상금";
            this.L_P2_C_8_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_8_STD.WordWrap = false;
            // 
            // L_P2_C_8_BASIS
            // 
            this.L_P2_C_8_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_8_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_8_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_8_BASIS.CanGrow = false;
            this.L_P2_C_8_BASIS.Dpi = 100F;
            this.L_P2_C_8_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 622F);
            this.L_P2_C_8_BASIS.Multiline = true;
            this.L_P2_C_8_BASIS.Name = "L_P2_C_8_BASIS";
            this.L_P2_C_8_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_8_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_8_BASIS.Text = "";
            this.L_P2_C_8_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_8_BASIS.WordWrap = false;
            // 
            // L_P2_C_8_AMT
            // 
            this.L_P2_C_8_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_8_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_8_AMT.BorderWidth = 0.5F;
            this.L_P2_C_8_AMT.CanGrow = false;
            this.L_P2_C_8_AMT.Dpi = 100F;
            this.L_P2_C_8_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 622F);
            this.L_P2_C_8_AMT.Multiline = true;
            this.L_P2_C_8_AMT.Name = "L_P2_C_8_AMT";
            this.L_P2_C_8_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_8_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_8_AMT.Text = "";
            this.L_P2_C_8_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_8_AMT.WordWrap = false;
            // 
            // L_P2_C_9_NO
            // 
            this.L_P2_C_9_NO.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_9_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_9_NO.BorderWidth = 0.5F;
            this.L_P2_C_9_NO.CanGrow = false;
            this.L_P2_C_9_NO.Dpi = 100F;
            this.L_P2_C_9_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 642F);
            this.L_P2_C_9_NO.Multiline = true;
            this.L_P2_C_9_NO.Name = "L_P2_C_9_NO";
            this.L_P2_C_9_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.L_P2_C_9_NO.SizeF = new System.Drawing.SizeF(22F, 20F);
            this.L_P2_C_9_NO.Text = "7";
            this.L_P2_C_9_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_9_NO.WordWrap = false;
            // 
            // L_P2_C_9_TP
            // 
            this.L_P2_C_9_TP.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_9_TP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_9_TP.BorderWidth = 0.5F;
            this.L_P2_C_9_TP.CanGrow = false;
            this.L_P2_C_9_TP.Dpi = 100F;
            this.L_P2_C_9_TP.LocationFloat = new DevExpress.Utils.PointFloat(22F, 642F);
            this.L_P2_C_9_TP.Multiline = true;
            this.L_P2_C_9_TP.Name = "L_P2_C_9_TP";
            this.L_P2_C_9_TP.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_9_TP.SizeF = new System.Drawing.SizeF(150F, 20F);
            this.L_P2_C_9_TP.Text = "공구비";
            this.L_P2_C_9_TP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_9_TP.WordWrap = false;
            // 
            // L_P2_C_9_STD
            // 
            this.L_P2_C_9_STD.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_9_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_9_STD.BorderWidth = 0.5F;
            this.L_P2_C_9_STD.CanGrow = false;
            this.L_P2_C_9_STD.Dpi = 100F;
            this.L_P2_C_9_STD.LocationFloat = new DevExpress.Utils.PointFloat(172F, 642F);
            this.L_P2_C_9_STD.Multiline = true;
            this.L_P2_C_9_STD.Name = "L_P2_C_9_STD";
            this.L_P2_C_9_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_9_STD.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.L_P2_C_9_STD.Text = "공구원가*100%";
            this.L_P2_C_9_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_P2_C_9_STD.WordWrap = false;
            // 
            // L_P2_C_9_BASIS
            // 
            this.L_P2_C_9_BASIS.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_9_BASIS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_9_BASIS.BorderWidth = 0.5F;
            this.L_P2_C_9_BASIS.CanGrow = false;
            this.L_P2_C_9_BASIS.Dpi = 100F;
            this.L_P2_C_9_BASIS.LocationFloat = new DevExpress.Utils.PointFloat(372F, 642F);
            this.L_P2_C_9_BASIS.Multiline = true;
            this.L_P2_C_9_BASIS.Name = "L_P2_C_9_BASIS";
            this.L_P2_C_9_BASIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_9_BASIS.SizeF = new System.Drawing.SizeF(160F, 20F);
            this.L_P2_C_9_BASIS.Text = "";
            this.L_P2_C_9_BASIS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_9_BASIS.WordWrap = false;
            // 
            // L_P2_C_9_AMT
            // 
            this.L_P2_C_9_AMT.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_9_AMT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_9_AMT.BorderWidth = 0.5F;
            this.L_P2_C_9_AMT.CanGrow = false;
            this.L_P2_C_9_AMT.Dpi = 100F;
            this.L_P2_C_9_AMT.LocationFloat = new DevExpress.Utils.PointFloat(532F, 642F);
            this.L_P2_C_9_AMT.Multiline = true;
            this.L_P2_C_9_AMT.Name = "L_P2_C_9_AMT";
            this.L_P2_C_9_AMT.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_9_AMT.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.L_P2_C_9_AMT.Text = "";
            this.L_P2_C_9_AMT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_9_AMT.WordWrap = false;
            // 
            // L_P2_C_SUM
            // 
            this.L_P2_C_SUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_C_SUM.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_SUM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_SUM.BorderWidth = 0.5F;
            this.L_P2_C_SUM.CanGrow = false;
            this.L_P2_C_SUM.Dpi = 100F;
            this.L_P2_C_SUM.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_P2_C_SUM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 662F);
            this.L_P2_C_SUM.Multiline = true;
            this.L_P2_C_SUM.Name = "L_P2_C_SUM";
            this.L_P2_C_SUM.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_SUM.SizeF = new System.Drawing.SizeF(372F, 22F);
            this.L_P2_C_SUM.Text = "제반 비용 총 합계";
            this.L_P2_C_SUM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_SUM.WordWrap = false;
            // 
            // L_P2_C_SUMV
            // 
            this.L_P2_C_SUMV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_C_SUMV.BorderColor = System.Drawing.Color.Black;
            this.L_P2_C_SUMV.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_C_SUMV.BorderWidth = 0.5F;
            this.L_P2_C_SUMV.CanGrow = false;
            this.L_P2_C_SUMV.Dpi = 100F;
            this.L_P2_C_SUMV.LocationFloat = new DevExpress.Utils.PointFloat(372F, 662F);
            this.L_P2_C_SUMV.Multiline = true;
            this.L_P2_C_SUMV.Name = "L_P2_C_SUMV";
            this.L_P2_C_SUMV.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_C_SUMV.SizeF = new System.Drawing.SizeF(240F, 22F);
            this.L_P2_C_SUMV.Text = "";
            this.L_P2_C_SUMV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_C_SUMV.WordWrap = false;
            // 
            // L_P2_R_H
            // 
            this.L_P2_R_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_R_H.BorderColor = System.Drawing.Color.Black;
            this.L_P2_R_H.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_R_H.BorderWidth = 0.5F;
            this.L_P2_R_H.CanGrow = false;
            this.L_P2_R_H.Dpi = 100F;
            this.L_P2_R_H.Font = new System.Drawing.Font("맑은 고딕", 7.5F, System.Drawing.FontStyle.Bold);
            this.L_P2_R_H.LocationFloat = new DevExpress.Utils.PointFloat(622F, 542F);
            this.L_P2_R_H.Multiline = true;
            this.L_P2_R_H.Name = "L_P2_R_H";
            this.L_P2_R_H.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_R_H.SizeF = new System.Drawing.SizeF(145F, 20F);
            this.L_P2_R_H.Text = "CLAIM 처리 금액(원)";
            this.L_P2_R_H.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_R_H.WordWrap = false;
            // 
            // L_P2_R_1
            // 
            this.L_P2_R_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_R_1.BorderColor = System.Drawing.Color.Black;
            this.L_P2_R_1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_R_1.BorderWidth = 0.5F;
            this.L_P2_R_1.CanGrow = false;
            this.L_P2_R_1.Dpi = 100F;
            this.L_P2_R_1.LocationFloat = new DevExpress.Utils.PointFloat(622F, 562F);
            this.L_P2_R_1.Multiline = true;
            this.L_P2_R_1.Name = "L_P2_R_1";
            this.L_P2_R_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_R_1.SizeF = new System.Drawing.SizeF(85F, 40F);
            this.L_P2_R_1.Text = "CLAIM\r\n예정 금액(원)";
            this.L_P2_R_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_R_1.WordWrap = false;
            // 
            // L_P2_R_1V
            // 
            this.L_P2_R_1V.BorderColor = System.Drawing.Color.Black;
            this.L_P2_R_1V.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_R_1V.BorderWidth = 0.5F;
            this.L_P2_R_1V.CanGrow = false;
            this.L_P2_R_1V.Dpi = 100F;
            this.L_P2_R_1V.LocationFloat = new DevExpress.Utils.PointFloat(707F, 562F);
            this.L_P2_R_1V.Multiline = true;
            this.L_P2_R_1V.Name = "L_P2_R_1V";
            this.L_P2_R_1V.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_R_1V.SizeF = new System.Drawing.SizeF(60F, 40F);
            this.L_P2_R_1V.Text = "";
            this.L_P2_R_1V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_R_1V.WordWrap = false;
            // 
            // L_P2_R_2
            // 
            this.L_P2_R_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_R_2.BorderColor = System.Drawing.Color.Black;
            this.L_P2_R_2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_R_2.BorderWidth = 0.5F;
            this.L_P2_R_2.CanGrow = false;
            this.L_P2_R_2.Dpi = 100F;
            this.L_P2_R_2.LocationFloat = new DevExpress.Utils.PointFloat(622F, 602F);
            this.L_P2_R_2.Multiline = true;
            this.L_P2_R_2.Name = "L_P2_R_2";
            this.L_P2_R_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_R_2.SizeF = new System.Drawing.SizeF(85F, 40F);
            this.L_P2_R_2.Text = "이의 신청\r\n인정 금액(원)";
            this.L_P2_R_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_R_2.WordWrap = false;
            // 
            // L_P2_R_2V
            // 
            this.L_P2_R_2V.BorderColor = System.Drawing.Color.Black;
            this.L_P2_R_2V.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_R_2V.BorderWidth = 0.5F;
            this.L_P2_R_2V.CanGrow = false;
            this.L_P2_R_2V.Dpi = 100F;
            this.L_P2_R_2V.LocationFloat = new DevExpress.Utils.PointFloat(707F, 602F);
            this.L_P2_R_2V.Multiline = true;
            this.L_P2_R_2V.Name = "L_P2_R_2V";
            this.L_P2_R_2V.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_R_2V.SizeF = new System.Drawing.SizeF(60F, 40F);
            this.L_P2_R_2V.Text = "";
            this.L_P2_R_2V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_R_2V.WordWrap = false;
            // 
            // L_P2_R_3
            // 
            this.L_P2_R_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.L_P2_R_3.BorderColor = System.Drawing.Color.Black;
            this.L_P2_R_3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_R_3.BorderWidth = 0.5F;
            this.L_P2_R_3.CanGrow = false;
            this.L_P2_R_3.Dpi = 100F;
            this.L_P2_R_3.LocationFloat = new DevExpress.Utils.PointFloat(622F, 642F);
            this.L_P2_R_3.Multiline = true;
            this.L_P2_R_3.Name = "L_P2_R_3";
            this.L_P2_R_3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_R_3.SizeF = new System.Drawing.SizeF(85F, 40F);
            this.L_P2_R_3.Text = "CLAIM\r\n확정 금액(원)";
            this.L_P2_R_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_R_3.WordWrap = false;
            // 
            // L_P2_R_3V
            // 
            this.L_P2_R_3V.BorderColor = System.Drawing.Color.Black;
            this.L_P2_R_3V.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_P2_R_3V.BorderWidth = 0.5F;
            this.L_P2_R_3V.CanGrow = false;
            this.L_P2_R_3V.Dpi = 100F;
            this.L_P2_R_3V.LocationFloat = new DevExpress.Utils.PointFloat(707F, 642F);
            this.L_P2_R_3V.Multiline = true;
            this.L_P2_R_3V.Name = "L_P2_R_3V";
            this.L_P2_R_3V.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.L_P2_R_3V.SizeF = new System.Drawing.SizeF(60F, 40F);
            this.L_P2_R_3V.Text = "";
            this.L_P2_R_3V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_P2_R_3V.WordWrap = false;
            // 
            // R01
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.Detail,
            this.ReportFooter});
            this.Dpi = 100F;
            this.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 25, 20);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel L_P1_HEADTITLE;
        private DevExpress.XtraReports.UI.XRLabel L_P1_APP1;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SIGN1;
        private DevExpress.XtraReports.UI.XRLabel L_P1_APP2;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SIGN2;
        private DevExpress.XtraReports.UI.XRLabel L_P1_APP3;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SIGN3;
        private DevExpress.XtraReports.UI.XRLabel L_P1_ZIP;
        private DevExpress.XtraReports.UI.XRLabel L_P1_ADDR;
        private DevExpress.XtraReports.UI.XRLabel L_P1_TEL;
        private DevExpress.XtraReports.UI.XRLabel L_P1_TELNO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_EMP;
        private DevExpress.XtraReports.UI.XRLabel C_EMPNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_HOME;
        private DevExpress.XtraReports.UI.XRLabel L_P1_HOMEURL;
        private DevExpress.XtraReports.UI.XRLabel L_P1_FAX;
        private DevExpress.XtraReports.UI.XRLabel L_P1_FAXNO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_DOCDATE;
        private DevExpress.XtraReports.UI.XRLabel C_DOCDATE_TXT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_LINE1;
        private DevExpress.XtraReports.UI.XRLabel L_P1_DOCNO;
        private DevExpress.XtraReports.UI.XRLabel C_DOCNO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_RECVNM;
        private DevExpress.XtraReports.UI.XRLabel C_RECVNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_REFNM;
        private DevExpress.XtraReports.UI.XRLabel C_REFNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_TITLE;
        private DevExpress.XtraReports.UI.XRLabel C_TITLE;
        private DevExpress.XtraReports.UI.XRLabel L_P1_LINE2;
        private DevExpress.XtraReports.UI.XRLabel L_P1_TEXT1;
        private DevExpress.XtraReports.UI.XRLabel L_P1_TEXT2;
        private DevExpress.XtraReports.UI.XRLabel C_OBJTEXT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_BELOW;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SEC1;
        private DevExpress.XtraReports.UI.XRLabel L_P1_H_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_H_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_H_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_H_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_H_LOSS;
        private DevExpress.XtraReports.UI.XRLabel L_P1_H_QTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_H_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_1_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_1_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_1_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_1_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_1_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_1_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_2_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_2_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_2_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_2_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_2_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_2_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_3_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_3_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_3_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_3_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_3_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_3_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_4_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_4_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_4_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_4_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_4_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_4_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_5_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_5_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_5_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_5_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_5_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_5_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_6_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_6_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_6_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_6_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_6_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_6_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_7_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_7_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_7_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_7_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_7_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_7_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_8_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_8_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_8_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_8_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_8_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_8_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_9_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_9_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_9_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_9_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_9_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_9_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_10_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_10_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_10_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_10_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_10_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_10_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_11_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_11_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_11_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_11_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_11_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_11_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_12_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_12_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_12_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_12_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_12_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_12_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_13_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_13_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_13_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_13_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_13_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_13_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_14_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_14_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_14_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_14_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_14_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_14_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_15_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_15_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_15_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_15_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_15_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_15_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_16_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_16_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_16_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_16_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_16_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_16_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_17_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P1_17_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P1_17_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_17_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P1_17_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_17_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_P1_SUM_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P1_SUM_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SEC2;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_OBJ;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_H_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_1_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_1_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_1_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_1_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_1_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_1_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_1_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_2_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_2_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_2_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_2_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_2_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_2_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_2_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_3_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_3_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_3_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_3_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_3_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_3_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_3_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_4_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_4_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_4_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_4_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_4_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_4_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_4_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_5_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_5_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_5_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_5_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_5_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_5_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_5_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_6_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_6_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_6_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_6_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_6_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_6_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_6_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_7_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_7_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_7_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_7_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_7_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_7_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_7_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_8_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_8_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_8_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_8_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_8_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_8_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_8_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_9_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_9_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_9_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_9_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_9_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_9_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_9_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_SUM;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_SUM_OBJQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_SUM_OBJAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_SUM_CONFQTY;
        private DevExpress.XtraReports.UI.XRLabel L_P1_O_SUM_CONFAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SEC3;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SEC4;
        private DevExpress.XtraReports.UI.XRLabel L_P1_SENDER;
        private DevExpress.XtraReports.UI.XRLabel L_P2_TOP1;
        private DevExpress.XtraReports.UI.XRLabel L_P2_FROM;
        private DevExpress.XtraReports.UI.XRLabel L_P2_TOP2;
        private DevExpress.XtraReports.UI.XRLabel C_RECVNM_P2;
        private DevExpress.XtraReports.UI.XRLabel L_P2_TOP3;
        private DevExpress.XtraReports.UI.XRLabel C_PERIOD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_TITLE;
        private DevExpress.XtraReports.UI.XRLabel C_PLANDATE;
        private DevExpress.XtraReports.UI.XRLabel C_CONFDATE;
        private DevExpress.XtraReports.UI.XRLabel L_P2_CUST;
        private DevExpress.XtraReports.UI.XRLabel L_P2_CUSTSIGN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_APP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_APP1;
        private DevExpress.XtraReports.UI.XRLabel L_P2_SIGN1;
        private DevExpress.XtraReports.UI.XRLabel L_P2_APP2;
        private DevExpress.XtraReports.UI.XRLabel L_P2_SIGN2;
        private DevExpress.XtraReports.UI.XRLabel L_P2_APP3;
        private DevExpress.XtraReports.UI.XRLabel L_P2_SIGN3;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_QTY;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_LOSS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_OBJ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_CLAIM;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_H_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_1_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_1_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_1_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_1_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_1_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_1_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_2_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_2_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_2_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_2_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_2_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_2_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_3_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_3_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_3_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_3_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_3_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_3_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_4_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_4_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_4_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_4_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_4_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_4_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_5_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_5_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_5_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_5_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_5_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_5_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_6_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_6_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_6_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_6_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_6_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_6_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_7_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_7_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_7_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_7_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_7_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_7_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_8_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_8_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_8_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_8_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_8_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_8_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_9_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_9_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_9_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_9_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_9_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_9_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_10_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_10_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_10_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_10_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_10_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_10_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_11_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_11_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_11_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_11_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_11_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_11_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_12_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_12_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_12_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_12_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_12_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_12_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_13_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_13_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_13_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_13_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_13_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_13_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_14_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_14_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_14_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_14_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_14_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_14_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_15_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_15_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_15_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_15_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_15_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_15_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_16_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_16_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_16_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_16_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_16_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_16_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_17_NO;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_BADCONT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_INPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_MFGPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_SALEPRICE;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_ETCAMT;
        private DevExpress.XtraReports.UI.XRLabel C_P2_17_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_17_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_17_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_17_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_17_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_SUM;
        private DevExpress.XtraReports.UI.XRLabel C_P2_SUM_QTY;
        private DevExpress.XtraReports.UI.XRLabel C_P2_SUM_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_SUM_OBJREQ;
        private DevExpress.XtraReports.UI.XRLabel L_P2_SUM_OBJOK;
        private DevExpress.XtraReports.UI.XRLabel L_P2_SUM_PLAN;
        private DevExpress.XtraReports.UI.XRLabel L_P2_SUM_CONF;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_H_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_H_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_H_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_H_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_H_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_H_RATE;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_1_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_1_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_1_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_1_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_1_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_1_RATE;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_2_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_2_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_2_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_2_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_2_RATE;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_3_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_3_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_3_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_3_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_3_RATE;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_4_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_4_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_4_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_4_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_4_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_5_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_5_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_5_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_5_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_5_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_6_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_6_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_6_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_6_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_6_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_7_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_7_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_7_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_7_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_7_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_8_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_8_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_8_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_8_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_8_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_9_NO;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_9_TP;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_9_STD;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_9_BASIS;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_9_AMT;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_SUM;
        private DevExpress.XtraReports.UI.XRLabel L_P2_C_SUMV;
        private DevExpress.XtraReports.UI.XRLabel L_P2_R_H;
        private DevExpress.XtraReports.UI.XRLabel L_P2_R_1;
        private DevExpress.XtraReports.UI.XRLabel L_P2_R_1V;
        private DevExpress.XtraReports.UI.XRLabel L_P2_R_2;
        private DevExpress.XtraReports.UI.XRLabel L_P2_R_2V;
        private DevExpress.XtraReports.UI.XRLabel L_P2_R_3;
        private DevExpress.XtraReports.UI.XRLabel L_P2_R_3V;
    }
}
