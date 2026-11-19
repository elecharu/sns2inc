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

        // 자주검사 체크시트 양식 (받은자료 생산팀 "자주검사(MES-Sample)검토" 시트). 가로 A4 한 장 = ReportHeader.
        // C_ 로 시작하는 칸에 S01.cs 가 이름으로 값을 넣는다. L_ 는 고정 글자이거나 비워 두는 칸.
        // 검사 회차 열 제목: C_H{01~12}, 검사항목 줄: C_R{01~24}_{PRC|STD|FEAT|SPEC|CYCLE|GAUGE|NO|T01~T12}
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.picLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.C_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_H1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_S1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_H2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_S2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_H3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_S3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_WORKDATE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_WORKDATE_TXT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_EMP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DAY = new DevExpress.XtraReports.UI.XRLabel();
            this.C_DAYEMP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NIGHT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_NIGHTEMP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.C_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ITEMBLANK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_TIME = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_H12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_PRC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_FEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_CYCLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_GAUGE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T01 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T02 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T03 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T04 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T05 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T06 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T07 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T08 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T09 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T10 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T11 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_T12 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_REMARK = new DevExpress.XtraReports.UI.XRLabel();
            this.C_REMARK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NOTE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_PAGE = new DevExpress.XtraReports.UI.XRLabel();
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
            this.C_TITLE,
            this.L_APRV_H1,
            this.L_APRV_S1,
            this.L_APRV_H2,
            this.L_APRV_S2,
            this.L_APRV_H3,
            this.L_APRV_S3,
            this.L_WORKDATE,
            this.C_WORKDATE_TXT,
            this.L_EMP,
            this.L_DAY,
            this.C_DAYEMP,
            this.L_NIGHT,
            this.C_NIGHTEMP,
            this.L_ITEMNM,
            this.C_ITEMNM,
            this.L_ITEMCD,
            this.C_ITEMCD,
            this.L_ITEMBLANK,
            this.L_T_PRC,
            this.L_T_STD,
            this.L_T_FEAT,
            this.L_T_SPEC,
            this.L_T_CYCLE,
            this.L_T_GAUGE,
            this.L_T_NO,
            this.L_T_TIME,
            this.C_H01,
            this.C_H02,
            this.C_H03,
            this.C_H04,
            this.C_H05,
            this.C_H06,
            this.C_H07,
            this.C_H08,
            this.C_H09,
            this.C_H10,
            this.C_H11,
            this.C_H12,
            this.C_R01_PRC,
            this.C_R01_STD,
            this.C_R01_FEAT,
            this.C_R01_SPEC,
            this.C_R01_CYCLE,
            this.C_R01_GAUGE,
            this.C_R01_NO,
            this.C_R01_T01,
            this.C_R01_T02,
            this.C_R01_T03,
            this.C_R01_T04,
            this.C_R01_T05,
            this.C_R01_T06,
            this.C_R01_T07,
            this.C_R01_T08,
            this.C_R01_T09,
            this.C_R01_T10,
            this.C_R01_T11,
            this.C_R01_T12,
            this.C_R02_PRC,
            this.C_R02_STD,
            this.C_R02_FEAT,
            this.C_R02_SPEC,
            this.C_R02_CYCLE,
            this.C_R02_GAUGE,
            this.C_R02_NO,
            this.C_R02_T01,
            this.C_R02_T02,
            this.C_R02_T03,
            this.C_R02_T04,
            this.C_R02_T05,
            this.C_R02_T06,
            this.C_R02_T07,
            this.C_R02_T08,
            this.C_R02_T09,
            this.C_R02_T10,
            this.C_R02_T11,
            this.C_R02_T12,
            this.C_R03_PRC,
            this.C_R03_STD,
            this.C_R03_FEAT,
            this.C_R03_SPEC,
            this.C_R03_CYCLE,
            this.C_R03_GAUGE,
            this.C_R03_NO,
            this.C_R03_T01,
            this.C_R03_T02,
            this.C_R03_T03,
            this.C_R03_T04,
            this.C_R03_T05,
            this.C_R03_T06,
            this.C_R03_T07,
            this.C_R03_T08,
            this.C_R03_T09,
            this.C_R03_T10,
            this.C_R03_T11,
            this.C_R03_T12,
            this.C_R04_PRC,
            this.C_R04_STD,
            this.C_R04_FEAT,
            this.C_R04_SPEC,
            this.C_R04_CYCLE,
            this.C_R04_GAUGE,
            this.C_R04_NO,
            this.C_R04_T01,
            this.C_R04_T02,
            this.C_R04_T03,
            this.C_R04_T04,
            this.C_R04_T05,
            this.C_R04_T06,
            this.C_R04_T07,
            this.C_R04_T08,
            this.C_R04_T09,
            this.C_R04_T10,
            this.C_R04_T11,
            this.C_R04_T12,
            this.C_R05_PRC,
            this.C_R05_STD,
            this.C_R05_FEAT,
            this.C_R05_SPEC,
            this.C_R05_CYCLE,
            this.C_R05_GAUGE,
            this.C_R05_NO,
            this.C_R05_T01,
            this.C_R05_T02,
            this.C_R05_T03,
            this.C_R05_T04,
            this.C_R05_T05,
            this.C_R05_T06,
            this.C_R05_T07,
            this.C_R05_T08,
            this.C_R05_T09,
            this.C_R05_T10,
            this.C_R05_T11,
            this.C_R05_T12,
            this.C_R06_PRC,
            this.C_R06_STD,
            this.C_R06_FEAT,
            this.C_R06_SPEC,
            this.C_R06_CYCLE,
            this.C_R06_GAUGE,
            this.C_R06_NO,
            this.C_R06_T01,
            this.C_R06_T02,
            this.C_R06_T03,
            this.C_R06_T04,
            this.C_R06_T05,
            this.C_R06_T06,
            this.C_R06_T07,
            this.C_R06_T08,
            this.C_R06_T09,
            this.C_R06_T10,
            this.C_R06_T11,
            this.C_R06_T12,
            this.C_R07_PRC,
            this.C_R07_STD,
            this.C_R07_FEAT,
            this.C_R07_SPEC,
            this.C_R07_CYCLE,
            this.C_R07_GAUGE,
            this.C_R07_NO,
            this.C_R07_T01,
            this.C_R07_T02,
            this.C_R07_T03,
            this.C_R07_T04,
            this.C_R07_T05,
            this.C_R07_T06,
            this.C_R07_T07,
            this.C_R07_T08,
            this.C_R07_T09,
            this.C_R07_T10,
            this.C_R07_T11,
            this.C_R07_T12,
            this.C_R08_PRC,
            this.C_R08_STD,
            this.C_R08_FEAT,
            this.C_R08_SPEC,
            this.C_R08_CYCLE,
            this.C_R08_GAUGE,
            this.C_R08_NO,
            this.C_R08_T01,
            this.C_R08_T02,
            this.C_R08_T03,
            this.C_R08_T04,
            this.C_R08_T05,
            this.C_R08_T06,
            this.C_R08_T07,
            this.C_R08_T08,
            this.C_R08_T09,
            this.C_R08_T10,
            this.C_R08_T11,
            this.C_R08_T12,
            this.C_R09_PRC,
            this.C_R09_STD,
            this.C_R09_FEAT,
            this.C_R09_SPEC,
            this.C_R09_CYCLE,
            this.C_R09_GAUGE,
            this.C_R09_NO,
            this.C_R09_T01,
            this.C_R09_T02,
            this.C_R09_T03,
            this.C_R09_T04,
            this.C_R09_T05,
            this.C_R09_T06,
            this.C_R09_T07,
            this.C_R09_T08,
            this.C_R09_T09,
            this.C_R09_T10,
            this.C_R09_T11,
            this.C_R09_T12,
            this.C_R10_PRC,
            this.C_R10_STD,
            this.C_R10_FEAT,
            this.C_R10_SPEC,
            this.C_R10_CYCLE,
            this.C_R10_GAUGE,
            this.C_R10_NO,
            this.C_R10_T01,
            this.C_R10_T02,
            this.C_R10_T03,
            this.C_R10_T04,
            this.C_R10_T05,
            this.C_R10_T06,
            this.C_R10_T07,
            this.C_R10_T08,
            this.C_R10_T09,
            this.C_R10_T10,
            this.C_R10_T11,
            this.C_R10_T12,
            this.C_R11_PRC,
            this.C_R11_STD,
            this.C_R11_FEAT,
            this.C_R11_SPEC,
            this.C_R11_CYCLE,
            this.C_R11_GAUGE,
            this.C_R11_NO,
            this.C_R11_T01,
            this.C_R11_T02,
            this.C_R11_T03,
            this.C_R11_T04,
            this.C_R11_T05,
            this.C_R11_T06,
            this.C_R11_T07,
            this.C_R11_T08,
            this.C_R11_T09,
            this.C_R11_T10,
            this.C_R11_T11,
            this.C_R11_T12,
            this.C_R12_PRC,
            this.C_R12_STD,
            this.C_R12_FEAT,
            this.C_R12_SPEC,
            this.C_R12_CYCLE,
            this.C_R12_GAUGE,
            this.C_R12_NO,
            this.C_R12_T01,
            this.C_R12_T02,
            this.C_R12_T03,
            this.C_R12_T04,
            this.C_R12_T05,
            this.C_R12_T06,
            this.C_R12_T07,
            this.C_R12_T08,
            this.C_R12_T09,
            this.C_R12_T10,
            this.C_R12_T11,
            this.C_R12_T12,
            this.C_R13_PRC,
            this.C_R13_STD,
            this.C_R13_FEAT,
            this.C_R13_SPEC,
            this.C_R13_CYCLE,
            this.C_R13_GAUGE,
            this.C_R13_NO,
            this.C_R13_T01,
            this.C_R13_T02,
            this.C_R13_T03,
            this.C_R13_T04,
            this.C_R13_T05,
            this.C_R13_T06,
            this.C_R13_T07,
            this.C_R13_T08,
            this.C_R13_T09,
            this.C_R13_T10,
            this.C_R13_T11,
            this.C_R13_T12,
            this.C_R14_PRC,
            this.C_R14_STD,
            this.C_R14_FEAT,
            this.C_R14_SPEC,
            this.C_R14_CYCLE,
            this.C_R14_GAUGE,
            this.C_R14_NO,
            this.C_R14_T01,
            this.C_R14_T02,
            this.C_R14_T03,
            this.C_R14_T04,
            this.C_R14_T05,
            this.C_R14_T06,
            this.C_R14_T07,
            this.C_R14_T08,
            this.C_R14_T09,
            this.C_R14_T10,
            this.C_R14_T11,
            this.C_R14_T12,
            this.C_R15_PRC,
            this.C_R15_STD,
            this.C_R15_FEAT,
            this.C_R15_SPEC,
            this.C_R15_CYCLE,
            this.C_R15_GAUGE,
            this.C_R15_NO,
            this.C_R15_T01,
            this.C_R15_T02,
            this.C_R15_T03,
            this.C_R15_T04,
            this.C_R15_T05,
            this.C_R15_T06,
            this.C_R15_T07,
            this.C_R15_T08,
            this.C_R15_T09,
            this.C_R15_T10,
            this.C_R15_T11,
            this.C_R15_T12,
            this.C_R16_PRC,
            this.C_R16_STD,
            this.C_R16_FEAT,
            this.C_R16_SPEC,
            this.C_R16_CYCLE,
            this.C_R16_GAUGE,
            this.C_R16_NO,
            this.C_R16_T01,
            this.C_R16_T02,
            this.C_R16_T03,
            this.C_R16_T04,
            this.C_R16_T05,
            this.C_R16_T06,
            this.C_R16_T07,
            this.C_R16_T08,
            this.C_R16_T09,
            this.C_R16_T10,
            this.C_R16_T11,
            this.C_R16_T12,
            this.C_R17_PRC,
            this.C_R17_STD,
            this.C_R17_FEAT,
            this.C_R17_SPEC,
            this.C_R17_CYCLE,
            this.C_R17_GAUGE,
            this.C_R17_NO,
            this.C_R17_T01,
            this.C_R17_T02,
            this.C_R17_T03,
            this.C_R17_T04,
            this.C_R17_T05,
            this.C_R17_T06,
            this.C_R17_T07,
            this.C_R17_T08,
            this.C_R17_T09,
            this.C_R17_T10,
            this.C_R17_T11,
            this.C_R17_T12,
            this.C_R18_PRC,
            this.C_R18_STD,
            this.C_R18_FEAT,
            this.C_R18_SPEC,
            this.C_R18_CYCLE,
            this.C_R18_GAUGE,
            this.C_R18_NO,
            this.C_R18_T01,
            this.C_R18_T02,
            this.C_R18_T03,
            this.C_R18_T04,
            this.C_R18_T05,
            this.C_R18_T06,
            this.C_R18_T07,
            this.C_R18_T08,
            this.C_R18_T09,
            this.C_R18_T10,
            this.C_R18_T11,
            this.C_R18_T12,
            this.C_R19_PRC,
            this.C_R19_STD,
            this.C_R19_FEAT,
            this.C_R19_SPEC,
            this.C_R19_CYCLE,
            this.C_R19_GAUGE,
            this.C_R19_NO,
            this.C_R19_T01,
            this.C_R19_T02,
            this.C_R19_T03,
            this.C_R19_T04,
            this.C_R19_T05,
            this.C_R19_T06,
            this.C_R19_T07,
            this.C_R19_T08,
            this.C_R19_T09,
            this.C_R19_T10,
            this.C_R19_T11,
            this.C_R19_T12,
            this.C_R20_PRC,
            this.C_R20_STD,
            this.C_R20_FEAT,
            this.C_R20_SPEC,
            this.C_R20_CYCLE,
            this.C_R20_GAUGE,
            this.C_R20_NO,
            this.C_R20_T01,
            this.C_R20_T02,
            this.C_R20_T03,
            this.C_R20_T04,
            this.C_R20_T05,
            this.C_R20_T06,
            this.C_R20_T07,
            this.C_R20_T08,
            this.C_R20_T09,
            this.C_R20_T10,
            this.C_R20_T11,
            this.C_R20_T12,
            this.C_R21_PRC,
            this.C_R21_STD,
            this.C_R21_FEAT,
            this.C_R21_SPEC,
            this.C_R21_CYCLE,
            this.C_R21_GAUGE,
            this.C_R21_NO,
            this.C_R21_T01,
            this.C_R21_T02,
            this.C_R21_T03,
            this.C_R21_T04,
            this.C_R21_T05,
            this.C_R21_T06,
            this.C_R21_T07,
            this.C_R21_T08,
            this.C_R21_T09,
            this.C_R21_T10,
            this.C_R21_T11,
            this.C_R21_T12,
            this.C_R22_PRC,
            this.C_R22_STD,
            this.C_R22_FEAT,
            this.C_R22_SPEC,
            this.C_R22_CYCLE,
            this.C_R22_GAUGE,
            this.C_R22_NO,
            this.C_R22_T01,
            this.C_R22_T02,
            this.C_R22_T03,
            this.C_R22_T04,
            this.C_R22_T05,
            this.C_R22_T06,
            this.C_R22_T07,
            this.C_R22_T08,
            this.C_R22_T09,
            this.C_R22_T10,
            this.C_R22_T11,
            this.C_R22_T12,
            this.C_R23_PRC,
            this.C_R23_STD,
            this.C_R23_FEAT,
            this.C_R23_SPEC,
            this.C_R23_CYCLE,
            this.C_R23_GAUGE,
            this.C_R23_NO,
            this.C_R23_T01,
            this.C_R23_T02,
            this.C_R23_T03,
            this.C_R23_T04,
            this.C_R23_T05,
            this.C_R23_T06,
            this.C_R23_T07,
            this.C_R23_T08,
            this.C_R23_T09,
            this.C_R23_T10,
            this.C_R23_T11,
            this.C_R23_T12,
            this.C_R24_PRC,
            this.C_R24_STD,
            this.C_R24_FEAT,
            this.C_R24_SPEC,
            this.C_R24_CYCLE,
            this.C_R24_GAUGE,
            this.C_R24_NO,
            this.C_R24_T01,
            this.C_R24_T02,
            this.C_R24_T03,
            this.C_R24_T04,
            this.C_R24_T05,
            this.C_R24_T06,
            this.C_R24_T07,
            this.C_R24_T08,
            this.C_R24_T09,
            this.C_R24_T10,
            this.C_R24_T11,
            this.C_R24_T12,
            this.L_REMARK,
            this.C_REMARK,
            this.L_NOTE,
            this.C_PAGE});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 787F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // picLogo
            // 
            this.picLogo.Dpi = 100F;
            this.picLogo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.picLogo.Name = "picLogo";
            this.picLogo.SizeF = new System.Drawing.SizeF(150F, 45F);
            this.picLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // C_TITLE
            // 
            this.C_TITLE.CanGrow = false;
            this.C_TITLE.Dpi = 100F;
            this.C_TITLE.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.C_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(170F, 0F);
            this.C_TITLE.Multiline = true;
            this.C_TITLE.Name = "C_TITLE";
            this.C_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_TITLE.SizeF = new System.Drawing.SizeF(760F, 45F);
            this.C_TITLE.StylePriority.UseFont = false;
            this.C_TITLE.Text = "○○ LINE 자주검사 체크시트";
            this.C_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_TITLE.WordWrap = false;
            // 
            // L_APRV_H1
            // 
            this.L_APRV_H1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_APRV_H1.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_H1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_H1.BorderWidth = 0.5F;
            this.L_APRV_H1.CanGrow = false;
            this.L_APRV_H1.Dpi = 100F;
            this.L_APRV_H1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_APRV_H1.LocationFloat = new DevExpress.Utils.PointFloat(959F, 0F);
            this.L_APRV_H1.Multiline = true;
            this.L_APRV_H1.Name = "L_APRV_H1";
            this.L_APRV_H1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_H1.SizeF = new System.Drawing.SizeF(56.6667F, 14F);
            this.L_APRV_H1.StylePriority.UseFont = false;
            this.L_APRV_H1.Text = "작성";
            this.L_APRV_H1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_H1.WordWrap = false;
            // 
            // L_APRV_S1
            // 
            this.L_APRV_S1.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_S1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_S1.BorderWidth = 0.5F;
            this.L_APRV_S1.CanGrow = false;
            this.L_APRV_S1.Dpi = 100F;
            this.L_APRV_S1.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_APRV_S1.LocationFloat = new DevExpress.Utils.PointFloat(959F, 14F);
            this.L_APRV_S1.Multiline = true;
            this.L_APRV_S1.Name = "L_APRV_S1";
            this.L_APRV_S1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_S1.SizeF = new System.Drawing.SizeF(56.6667F, 34F);
            this.L_APRV_S1.StylePriority.UseFont = false;
            this.L_APRV_S1.Text = "";
            this.L_APRV_S1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_S1.WordWrap = false;
            // 
            // L_APRV_H2
            // 
            this.L_APRV_H2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_APRV_H2.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_H2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_H2.BorderWidth = 0.5F;
            this.L_APRV_H2.CanGrow = false;
            this.L_APRV_H2.Dpi = 100F;
            this.L_APRV_H2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_APRV_H2.LocationFloat = new DevExpress.Utils.PointFloat(1015.6667F, 0F);
            this.L_APRV_H2.Multiline = true;
            this.L_APRV_H2.Name = "L_APRV_H2";
            this.L_APRV_H2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_H2.SizeF = new System.Drawing.SizeF(56.6667F, 14F);
            this.L_APRV_H2.StylePriority.UseFont = false;
            this.L_APRV_H2.Text = "검토";
            this.L_APRV_H2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_H2.WordWrap = false;
            // 
            // L_APRV_S2
            // 
            this.L_APRV_S2.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_S2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_S2.BorderWidth = 0.5F;
            this.L_APRV_S2.CanGrow = false;
            this.L_APRV_S2.Dpi = 100F;
            this.L_APRV_S2.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_APRV_S2.LocationFloat = new DevExpress.Utils.PointFloat(1015.6667F, 14F);
            this.L_APRV_S2.Multiline = true;
            this.L_APRV_S2.Name = "L_APRV_S2";
            this.L_APRV_S2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_S2.SizeF = new System.Drawing.SizeF(56.6667F, 34F);
            this.L_APRV_S2.StylePriority.UseFont = false;
            this.L_APRV_S2.Text = "";
            this.L_APRV_S2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_S2.WordWrap = false;
            // 
            // L_APRV_H3
            // 
            this.L_APRV_H3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_APRV_H3.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_H3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_H3.BorderWidth = 0.5F;
            this.L_APRV_H3.CanGrow = false;
            this.L_APRV_H3.Dpi = 100F;
            this.L_APRV_H3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_APRV_H3.LocationFloat = new DevExpress.Utils.PointFloat(1072.3333F, 0F);
            this.L_APRV_H3.Multiline = true;
            this.L_APRV_H3.Name = "L_APRV_H3";
            this.L_APRV_H3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_H3.SizeF = new System.Drawing.SizeF(56.6667F, 14F);
            this.L_APRV_H3.StylePriority.UseFont = false;
            this.L_APRV_H3.Text = "결재";
            this.L_APRV_H3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_H3.WordWrap = false;
            // 
            // L_APRV_S3
            // 
            this.L_APRV_S3.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_S3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_S3.BorderWidth = 0.5F;
            this.L_APRV_S3.CanGrow = false;
            this.L_APRV_S3.Dpi = 100F;
            this.L_APRV_S3.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_APRV_S3.LocationFloat = new DevExpress.Utils.PointFloat(1072.3333F, 14F);
            this.L_APRV_S3.Multiline = true;
            this.L_APRV_S3.Name = "L_APRV_S3";
            this.L_APRV_S3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_S3.SizeF = new System.Drawing.SizeF(56.6667F, 34F);
            this.L_APRV_S3.StylePriority.UseFont = false;
            this.L_APRV_S3.Text = "";
            this.L_APRV_S3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_S3.WordWrap = false;
            // 
            // L_WORKDATE
            // 
            this.L_WORKDATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_WORKDATE.BorderColor = System.Drawing.Color.Black;
            this.L_WORKDATE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_WORKDATE.BorderWidth = 0.5F;
            this.L_WORKDATE.CanGrow = false;
            this.L_WORKDATE.Dpi = 100F;
            this.L_WORKDATE.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_WORKDATE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 56F);
            this.L_WORKDATE.Multiline = true;
            this.L_WORKDATE.Name = "L_WORKDATE";
            this.L_WORKDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_WORKDATE.SizeF = new System.Drawing.SizeF(150F, 24F);
            this.L_WORKDATE.StylePriority.UseFont = false;
            this.L_WORKDATE.Text = "작성일자";
            this.L_WORKDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_WORKDATE.WordWrap = false;
            // 
            // C_WORKDATE_TXT
            // 
            this.C_WORKDATE_TXT.BorderColor = System.Drawing.Color.Black;
            this.C_WORKDATE_TXT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_WORKDATE_TXT.BorderWidth = 0.5F;
            this.C_WORKDATE_TXT.CanGrow = false;
            this.C_WORKDATE_TXT.Dpi = 100F;
            this.C_WORKDATE_TXT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_WORKDATE_TXT.LocationFloat = new DevExpress.Utils.PointFloat(150F, 56F);
            this.C_WORKDATE_TXT.Multiline = true;
            this.C_WORKDATE_TXT.Name = "C_WORKDATE_TXT";
            this.C_WORKDATE_TXT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_WORKDATE_TXT.SizeF = new System.Drawing.SizeF(450F, 24F);
            this.C_WORKDATE_TXT.StylePriority.UseFont = false;
            this.C_WORKDATE_TXT.Text = "";
            this.C_WORKDATE_TXT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_WORKDATE_TXT.WordWrap = false;
            // 
            // L_EMP
            // 
            this.L_EMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_EMP.BorderColor = System.Drawing.Color.Black;
            this.L_EMP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_EMP.BorderWidth = 0.5F;
            this.L_EMP.CanGrow = false;
            this.L_EMP.Dpi = 100F;
            this.L_EMP.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_EMP.LocationFloat = new DevExpress.Utils.PointFloat(600F, 56F);
            this.L_EMP.Multiline = true;
            this.L_EMP.Name = "L_EMP";
            this.L_EMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_EMP.SizeF = new System.Drawing.SizeF(150F, 24F);
            this.L_EMP.StylePriority.UseFont = false;
            this.L_EMP.Text = "작업자";
            this.L_EMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_EMP.WordWrap = false;
            // 
            // L_DAY
            // 
            this.L_DAY.BorderColor = System.Drawing.Color.Black;
            this.L_DAY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DAY.BorderWidth = 0.5F;
            this.L_DAY.CanGrow = false;
            this.L_DAY.Dpi = 100F;
            this.L_DAY.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_DAY.LocationFloat = new DevExpress.Utils.PointFloat(750F, 56F);
            this.L_DAY.Multiline = true;
            this.L_DAY.Name = "L_DAY";
            this.L_DAY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_DAY.SizeF = new System.Drawing.SizeF(40F, 24F);
            this.L_DAY.StylePriority.UseFont = false;
            this.L_DAY.Text = "주간";
            this.L_DAY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DAY.WordWrap = false;
            // 
            // C_DAYEMP
            // 
            this.C_DAYEMP.BorderColor = System.Drawing.Color.Black;
            this.C_DAYEMP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_DAYEMP.BorderWidth = 0.5F;
            this.C_DAYEMP.CanGrow = false;
            this.C_DAYEMP.Dpi = 100F;
            this.C_DAYEMP.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.C_DAYEMP.LocationFloat = new DevExpress.Utils.PointFloat(790F, 56F);
            this.C_DAYEMP.Multiline = true;
            this.C_DAYEMP.Name = "C_DAYEMP";
            this.C_DAYEMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_DAYEMP.SizeF = new System.Drawing.SizeF(150F, 24F);
            this.C_DAYEMP.StylePriority.UseFont = false;
            this.C_DAYEMP.Text = "";
            this.C_DAYEMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_DAYEMP.WordWrap = false;
            // 
            // L_NIGHT
            // 
            this.L_NIGHT.BorderColor = System.Drawing.Color.Black;
            this.L_NIGHT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NIGHT.BorderWidth = 0.5F;
            this.L_NIGHT.CanGrow = false;
            this.L_NIGHT.Dpi = 100F;
            this.L_NIGHT.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_NIGHT.LocationFloat = new DevExpress.Utils.PointFloat(940F, 56F);
            this.L_NIGHT.Multiline = true;
            this.L_NIGHT.Name = "L_NIGHT";
            this.L_NIGHT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_NIGHT.SizeF = new System.Drawing.SizeF(40F, 24F);
            this.L_NIGHT.StylePriority.UseFont = false;
            this.L_NIGHT.Text = "야간";
            this.L_NIGHT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_NIGHT.WordWrap = false;
            // 
            // C_NIGHTEMP
            // 
            this.C_NIGHTEMP.BorderColor = System.Drawing.Color.Black;
            this.C_NIGHTEMP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_NIGHTEMP.BorderWidth = 0.5F;
            this.C_NIGHTEMP.CanGrow = false;
            this.C_NIGHTEMP.Dpi = 100F;
            this.C_NIGHTEMP.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.C_NIGHTEMP.LocationFloat = new DevExpress.Utils.PointFloat(980F, 56F);
            this.C_NIGHTEMP.Multiline = true;
            this.C_NIGHTEMP.Name = "C_NIGHTEMP";
            this.C_NIGHTEMP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_NIGHTEMP.SizeF = new System.Drawing.SizeF(149F, 24F);
            this.C_NIGHTEMP.StylePriority.UseFont = false;
            this.C_NIGHTEMP.Text = "";
            this.C_NIGHTEMP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_NIGHTEMP.WordWrap = false;
            // 
            // L_ITEMNM
            // 
            this.L_ITEMNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.L_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ITEMNM.BorderWidth = 0.5F;
            this.L_ITEMNM.CanGrow = false;
            this.L_ITEMNM.Dpi = 100F;
            this.L_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.L_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 86F);
            this.L_ITEMNM.Multiline = true;
            this.L_ITEMNM.Name = "L_ITEMNM";
            this.L_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_ITEMNM.SizeF = new System.Drawing.SizeF(110F, 26F);
            this.L_ITEMNM.StylePriority.UseFont = false;
            this.L_ITEMNM.Text = "품 명";
            this.L_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ITEMNM.WordWrap = false;
            // 
            // C_ITEMNM
            // 
            this.C_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_ITEMNM.BorderWidth = 0.5F;
            this.C_ITEMNM.CanGrow = false;
            this.C_ITEMNM.Dpi = 100F;
            this.C_ITEMNM.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.C_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(110F, 86F);
            this.C_ITEMNM.Multiline = true;
            this.C_ITEMNM.Name = "C_ITEMNM";
            this.C_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_ITEMNM.SizeF = new System.Drawing.SizeF(380F, 26F);
            this.C_ITEMNM.StylePriority.UseFont = false;
            this.C_ITEMNM.Text = "";
            this.C_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_ITEMNM.WordWrap = false;
            // 
            // L_ITEMCD
            // 
            this.L_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.L_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ITEMCD.BorderWidth = 0.5F;
            this.L_ITEMCD.CanGrow = false;
            this.L_ITEMCD.Dpi = 100F;
            this.L_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.L_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(490F, 86F);
            this.L_ITEMCD.Multiline = true;
            this.L_ITEMCD.Name = "L_ITEMCD";
            this.L_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_ITEMCD.SizeF = new System.Drawing.SizeF(110F, 26F);
            this.L_ITEMCD.StylePriority.UseFont = false;
            this.L_ITEMCD.Text = "품 번";
            this.L_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ITEMCD.WordWrap = false;
            // 
            // C_ITEMCD
            // 
            this.C_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_ITEMCD.BorderWidth = 0.5F;
            this.C_ITEMCD.CanGrow = false;
            this.C_ITEMCD.Dpi = 100F;
            this.C_ITEMCD.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.C_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(600F, 86F);
            this.C_ITEMCD.Multiline = true;
            this.C_ITEMCD.Name = "C_ITEMCD";
            this.C_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_ITEMCD.SizeF = new System.Drawing.SizeF(300F, 26F);
            this.C_ITEMCD.StylePriority.UseFont = false;
            this.C_ITEMCD.Text = "";
            this.C_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_ITEMCD.WordWrap = false;
            // 
            // L_ITEMBLANK
            // 
            this.L_ITEMBLANK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_ITEMBLANK.BorderColor = System.Drawing.Color.Black;
            this.L_ITEMBLANK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ITEMBLANK.BorderWidth = 0.5F;
            this.L_ITEMBLANK.CanGrow = false;
            this.L_ITEMBLANK.Dpi = 100F;
            this.L_ITEMBLANK.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_ITEMBLANK.LocationFloat = new DevExpress.Utils.PointFloat(900F, 86F);
            this.L_ITEMBLANK.Multiline = true;
            this.L_ITEMBLANK.Name = "L_ITEMBLANK";
            this.L_ITEMBLANK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_ITEMBLANK.SizeF = new System.Drawing.SizeF(229F, 26F);
            this.L_ITEMBLANK.StylePriority.UseFont = false;
            this.L_ITEMBLANK.Text = "";
            this.L_ITEMBLANK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ITEMBLANK.WordWrap = false;
            // 
            // L_T_PRC
            // 
            this.L_T_PRC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_T_PRC.BorderColor = System.Drawing.Color.Black;
            this.L_T_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_PRC.BorderWidth = 0.5F;
            this.L_T_PRC.CanGrow = false;
            this.L_T_PRC.Dpi = 100F;
            this.L_T_PRC.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_T_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 118F);
            this.L_T_PRC.Multiline = true;
            this.L_T_PRC.Name = "L_T_PRC";
            this.L_T_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_PRC.SizeF = new System.Drawing.SizeF(55F, 36F);
            this.L_T_PRC.StylePriority.UseFont = false;
            this.L_T_PRC.Text = "공정";
            this.L_T_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_PRC.WordWrap = false;
            // 
            // L_T_STD
            // 
            this.L_T_STD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_T_STD.BorderColor = System.Drawing.Color.Black;
            this.L_T_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_STD.BorderWidth = 0.5F;
            this.L_T_STD.CanGrow = false;
            this.L_T_STD.Dpi = 100F;
            this.L_T_STD.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_T_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 118F);
            this.L_T_STD.Multiline = true;
            this.L_T_STD.Name = "L_T_STD";
            this.L_T_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_STD.SizeF = new System.Drawing.SizeF(80F, 36F);
            this.L_T_STD.StylePriority.UseFont = false;
            this.L_T_STD.Text = "검사 항목";
            this.L_T_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_STD.WordWrap = false;
            // 
            // L_T_FEAT
            // 
            this.L_T_FEAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_T_FEAT.BorderColor = System.Drawing.Color.Black;
            this.L_T_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_FEAT.BorderWidth = 0.5F;
            this.L_T_FEAT.CanGrow = false;
            this.L_T_FEAT.Dpi = 100F;
            this.L_T_FEAT.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_T_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 118F);
            this.L_T_FEAT.Multiline = true;
            this.L_T_FEAT.Name = "L_T_FEAT";
            this.L_T_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_FEAT.SizeF = new System.Drawing.SizeF(35F, 36F);
            this.L_T_FEAT.StylePriority.UseFont = false;
            this.L_T_FEAT.Text = "특성";
            this.L_T_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_FEAT.WordWrap = false;
            // 
            // L_T_SPEC
            // 
            this.L_T_SPEC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_T_SPEC.BorderColor = System.Drawing.Color.Black;
            this.L_T_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SPEC.BorderWidth = 0.5F;
            this.L_T_SPEC.CanGrow = false;
            this.L_T_SPEC.Dpi = 100F;
            this.L_T_SPEC.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_T_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 118F);
            this.L_T_SPEC.Multiline = true;
            this.L_T_SPEC.Name = "L_T_SPEC";
            this.L_T_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SPEC.SizeF = new System.Drawing.SizeF(158F, 36F);
            this.L_T_SPEC.StylePriority.UseFont = false;
            this.L_T_SPEC.Text = "검사규격";
            this.L_T_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SPEC.WordWrap = false;
            // 
            // L_T_CYCLE
            // 
            this.L_T_CYCLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_T_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.L_T_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_CYCLE.BorderWidth = 0.5F;
            this.L_T_CYCLE.CanGrow = false;
            this.L_T_CYCLE.Dpi = 100F;
            this.L_T_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_T_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 118F);
            this.L_T_CYCLE.Multiline = true;
            this.L_T_CYCLE.Name = "L_T_CYCLE";
            this.L_T_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_CYCLE.SizeF = new System.Drawing.SizeF(60F, 36F);
            this.L_T_CYCLE.StylePriority.UseFont = false;
            this.L_T_CYCLE.Text = "검사주기";
            this.L_T_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_CYCLE.WordWrap = false;
            // 
            // L_T_GAUGE
            // 
            this.L_T_GAUGE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_T_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.L_T_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_GAUGE.BorderWidth = 0.5F;
            this.L_T_GAUGE.CanGrow = false;
            this.L_T_GAUGE.Dpi = 100F;
            this.L_T_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_T_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 118F);
            this.L_T_GAUGE.Multiline = true;
            this.L_T_GAUGE.Name = "L_T_GAUGE";
            this.L_T_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_GAUGE.SizeF = new System.Drawing.SizeF(75F, 36F);
            this.L_T_GAUGE.StylePriority.UseFont = false;
            this.L_T_GAUGE.Text = "검사게이지";
            this.L_T_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_GAUGE.WordWrap = false;
            // 
            // L_T_NO
            // 
            this.L_T_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_T_NO.BorderColor = System.Drawing.Color.Black;
            this.L_T_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_NO.BorderWidth = 0.5F;
            this.L_T_NO.CanGrow = false;
            this.L_T_NO.Dpi = 100F;
            this.L_T_NO.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_T_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 118F);
            this.L_T_NO.Multiline = true;
            this.L_T_NO.Name = "L_T_NO";
            this.L_T_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_NO.SizeF = new System.Drawing.SizeF(30F, 36F);
            this.L_T_NO.StylePriority.UseFont = false;
            this.L_T_NO.Text = "시료";
            this.L_T_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_NO.WordWrap = false;
            // 
            // L_T_TIME
            // 
            this.L_T_TIME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_T_TIME.BorderColor = System.Drawing.Color.Black;
            this.L_T_TIME.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_TIME.BorderWidth = 0.5F;
            this.L_T_TIME.CanGrow = false;
            this.L_T_TIME.Dpi = 100F;
            this.L_T_TIME.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.L_T_TIME.LocationFloat = new DevExpress.Utils.PointFloat(493F, 118F);
            this.L_T_TIME.Multiline = true;
            this.L_T_TIME.Name = "L_T_TIME";
            this.L_T_TIME.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_TIME.SizeF = new System.Drawing.SizeF(636F, 18F);
            this.L_T_TIME.StylePriority.UseFont = false;
            this.L_T_TIME.Text = "시간";
            this.L_T_TIME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_TIME.WordWrap = false;
            // 
            // C_H01
            // 
            this.C_H01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H01.BorderColor = System.Drawing.Color.Black;
            this.C_H01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H01.BorderWidth = 0.5F;
            this.C_H01.CanGrow = false;
            this.C_H01.Dpi = 100F;
            this.C_H01.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 136F);
            this.C_H01.Multiline = true;
            this.C_H01.Name = "C_H01";
            this.C_H01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H01.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H01.StylePriority.UseFont = false;
            this.C_H01.Text = "";
            this.C_H01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H01.WordWrap = false;
            // 
            // C_H02
            // 
            this.C_H02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H02.BorderColor = System.Drawing.Color.Black;
            this.C_H02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H02.BorderWidth = 0.5F;
            this.C_H02.CanGrow = false;
            this.C_H02.Dpi = 100F;
            this.C_H02.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 136F);
            this.C_H02.Multiline = true;
            this.C_H02.Name = "C_H02";
            this.C_H02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H02.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H02.StylePriority.UseFont = false;
            this.C_H02.Text = "";
            this.C_H02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H02.WordWrap = false;
            // 
            // C_H03
            // 
            this.C_H03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H03.BorderColor = System.Drawing.Color.Black;
            this.C_H03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H03.BorderWidth = 0.5F;
            this.C_H03.CanGrow = false;
            this.C_H03.Dpi = 100F;
            this.C_H03.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 136F);
            this.C_H03.Multiline = true;
            this.C_H03.Name = "C_H03";
            this.C_H03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H03.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H03.StylePriority.UseFont = false;
            this.C_H03.Text = "";
            this.C_H03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H03.WordWrap = false;
            // 
            // C_H04
            // 
            this.C_H04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H04.BorderColor = System.Drawing.Color.Black;
            this.C_H04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H04.BorderWidth = 0.5F;
            this.C_H04.CanGrow = false;
            this.C_H04.Dpi = 100F;
            this.C_H04.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 136F);
            this.C_H04.Multiline = true;
            this.C_H04.Name = "C_H04";
            this.C_H04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H04.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H04.StylePriority.UseFont = false;
            this.C_H04.Text = "";
            this.C_H04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H04.WordWrap = false;
            // 
            // C_H05
            // 
            this.C_H05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H05.BorderColor = System.Drawing.Color.Black;
            this.C_H05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H05.BorderWidth = 0.5F;
            this.C_H05.CanGrow = false;
            this.C_H05.Dpi = 100F;
            this.C_H05.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 136F);
            this.C_H05.Multiline = true;
            this.C_H05.Name = "C_H05";
            this.C_H05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H05.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H05.StylePriority.UseFont = false;
            this.C_H05.Text = "";
            this.C_H05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H05.WordWrap = false;
            // 
            // C_H06
            // 
            this.C_H06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H06.BorderColor = System.Drawing.Color.Black;
            this.C_H06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H06.BorderWidth = 0.5F;
            this.C_H06.CanGrow = false;
            this.C_H06.Dpi = 100F;
            this.C_H06.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 136F);
            this.C_H06.Multiline = true;
            this.C_H06.Name = "C_H06";
            this.C_H06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H06.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H06.StylePriority.UseFont = false;
            this.C_H06.Text = "";
            this.C_H06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H06.WordWrap = false;
            // 
            // C_H07
            // 
            this.C_H07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H07.BorderColor = System.Drawing.Color.Black;
            this.C_H07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H07.BorderWidth = 0.5F;
            this.C_H07.CanGrow = false;
            this.C_H07.Dpi = 100F;
            this.C_H07.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 136F);
            this.C_H07.Multiline = true;
            this.C_H07.Name = "C_H07";
            this.C_H07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H07.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H07.StylePriority.UseFont = false;
            this.C_H07.Text = "";
            this.C_H07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H07.WordWrap = false;
            // 
            // C_H08
            // 
            this.C_H08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H08.BorderColor = System.Drawing.Color.Black;
            this.C_H08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H08.BorderWidth = 0.5F;
            this.C_H08.CanGrow = false;
            this.C_H08.Dpi = 100F;
            this.C_H08.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 136F);
            this.C_H08.Multiline = true;
            this.C_H08.Name = "C_H08";
            this.C_H08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H08.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H08.StylePriority.UseFont = false;
            this.C_H08.Text = "";
            this.C_H08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H08.WordWrap = false;
            // 
            // C_H09
            // 
            this.C_H09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H09.BorderColor = System.Drawing.Color.Black;
            this.C_H09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H09.BorderWidth = 0.5F;
            this.C_H09.CanGrow = false;
            this.C_H09.Dpi = 100F;
            this.C_H09.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 136F);
            this.C_H09.Multiline = true;
            this.C_H09.Name = "C_H09";
            this.C_H09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H09.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H09.StylePriority.UseFont = false;
            this.C_H09.Text = "";
            this.C_H09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H09.WordWrap = false;
            // 
            // C_H10
            // 
            this.C_H10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H10.BorderColor = System.Drawing.Color.Black;
            this.C_H10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H10.BorderWidth = 0.5F;
            this.C_H10.CanGrow = false;
            this.C_H10.Dpi = 100F;
            this.C_H10.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 136F);
            this.C_H10.Multiline = true;
            this.C_H10.Name = "C_H10";
            this.C_H10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H10.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H10.StylePriority.UseFont = false;
            this.C_H10.Text = "";
            this.C_H10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H10.WordWrap = false;
            // 
            // C_H11
            // 
            this.C_H11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H11.BorderColor = System.Drawing.Color.Black;
            this.C_H11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H11.BorderWidth = 0.5F;
            this.C_H11.CanGrow = false;
            this.C_H11.Dpi = 100F;
            this.C_H11.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 136F);
            this.C_H11.Multiline = true;
            this.C_H11.Name = "C_H11";
            this.C_H11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H11.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H11.StylePriority.UseFont = false;
            this.C_H11.Text = "";
            this.C_H11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H11.WordWrap = false;
            // 
            // C_H12
            // 
            this.C_H12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.C_H12.BorderColor = System.Drawing.Color.Black;
            this.C_H12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_H12.BorderWidth = 0.5F;
            this.C_H12.CanGrow = false;
            this.C_H12.Dpi = 100F;
            this.C_H12.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_H12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 136F);
            this.C_H12.Multiline = true;
            this.C_H12.Name = "C_H12";
            this.C_H12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_H12.SizeF = new System.Drawing.SizeF(53F, 18F);
            this.C_H12.StylePriority.UseFont = false;
            this.C_H12.Text = "";
            this.C_H12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_H12.WordWrap = false;
            // 
            // C_R01_PRC
            // 
            this.C_R01_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R01_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_PRC.BorderWidth = 0.5F;
            this.C_R01_PRC.CanGrow = false;
            this.C_R01_PRC.Dpi = 100F;
            this.C_R01_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 154F);
            this.C_R01_PRC.Multiline = true;
            this.C_R01_PRC.Name = "C_R01_PRC";
            this.C_R01_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R01_PRC.StylePriority.UseFont = false;
            this.C_R01_PRC.Text = "";
            this.C_R01_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_PRC.WordWrap = false;
            // 
            // C_R01_STD
            // 
            this.C_R01_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R01_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_STD.BorderWidth = 0.5F;
            this.C_R01_STD.CanGrow = false;
            this.C_R01_STD.Dpi = 100F;
            this.C_R01_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 154F);
            this.C_R01_STD.Multiline = true;
            this.C_R01_STD.Name = "C_R01_STD";
            this.C_R01_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R01_STD.StylePriority.UseFont = false;
            this.C_R01_STD.Text = "";
            this.C_R01_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_STD.WordWrap = true;
            // 
            // C_R01_FEAT
            // 
            this.C_R01_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R01_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_FEAT.BorderWidth = 0.5F;
            this.C_R01_FEAT.CanGrow = false;
            this.C_R01_FEAT.Dpi = 100F;
            this.C_R01_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 154F);
            this.C_R01_FEAT.Multiline = true;
            this.C_R01_FEAT.Name = "C_R01_FEAT";
            this.C_R01_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R01_FEAT.StylePriority.UseFont = false;
            this.C_R01_FEAT.Text = "";
            this.C_R01_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_FEAT.WordWrap = false;
            // 
            // C_R01_SPEC
            // 
            this.C_R01_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R01_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_SPEC.BorderWidth = 0.5F;
            this.C_R01_SPEC.CanGrow = false;
            this.C_R01_SPEC.Dpi = 100F;
            this.C_R01_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 154F);
            this.C_R01_SPEC.Multiline = true;
            this.C_R01_SPEC.Name = "C_R01_SPEC";
            this.C_R01_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R01_SPEC.StylePriority.UseFont = false;
            this.C_R01_SPEC.Text = "";
            this.C_R01_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_SPEC.WordWrap = true;
            // 
            // C_R01_CYCLE
            // 
            this.C_R01_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R01_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_CYCLE.BorderWidth = 0.5F;
            this.C_R01_CYCLE.CanGrow = false;
            this.C_R01_CYCLE.Dpi = 100F;
            this.C_R01_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 154F);
            this.C_R01_CYCLE.Multiline = true;
            this.C_R01_CYCLE.Name = "C_R01_CYCLE";
            this.C_R01_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R01_CYCLE.StylePriority.UseFont = false;
            this.C_R01_CYCLE.Text = "";
            this.C_R01_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_CYCLE.WordWrap = true;
            // 
            // C_R01_GAUGE
            // 
            this.C_R01_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R01_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_GAUGE.BorderWidth = 0.5F;
            this.C_R01_GAUGE.CanGrow = false;
            this.C_R01_GAUGE.Dpi = 100F;
            this.C_R01_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 154F);
            this.C_R01_GAUGE.Multiline = true;
            this.C_R01_GAUGE.Name = "C_R01_GAUGE";
            this.C_R01_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R01_GAUGE.StylePriority.UseFont = false;
            this.C_R01_GAUGE.Text = "";
            this.C_R01_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_GAUGE.WordWrap = true;
            // 
            // C_R01_NO
            // 
            this.C_R01_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R01_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_NO.BorderWidth = 0.5F;
            this.C_R01_NO.CanGrow = false;
            this.C_R01_NO.Dpi = 100F;
            this.C_R01_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 154F);
            this.C_R01_NO.Multiline = true;
            this.C_R01_NO.Name = "C_R01_NO";
            this.C_R01_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R01_NO.StylePriority.UseFont = false;
            this.C_R01_NO.Text = "";
            this.C_R01_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_NO.WordWrap = false;
            // 
            // C_R01_T01
            // 
            this.C_R01_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T01.BorderWidth = 0.5F;
            this.C_R01_T01.CanGrow = false;
            this.C_R01_T01.Dpi = 100F;
            this.C_R01_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 154F);
            this.C_R01_T01.Multiline = true;
            this.C_R01_T01.Name = "C_R01_T01";
            this.C_R01_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T01.StylePriority.UseFont = false;
            this.C_R01_T01.Text = "";
            this.C_R01_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T01.WordWrap = false;
            // 
            // C_R01_T02
            // 
            this.C_R01_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T02.BorderWidth = 0.5F;
            this.C_R01_T02.CanGrow = false;
            this.C_R01_T02.Dpi = 100F;
            this.C_R01_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 154F);
            this.C_R01_T02.Multiline = true;
            this.C_R01_T02.Name = "C_R01_T02";
            this.C_R01_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T02.StylePriority.UseFont = false;
            this.C_R01_T02.Text = "";
            this.C_R01_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T02.WordWrap = false;
            // 
            // C_R01_T03
            // 
            this.C_R01_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T03.BorderWidth = 0.5F;
            this.C_R01_T03.CanGrow = false;
            this.C_R01_T03.Dpi = 100F;
            this.C_R01_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 154F);
            this.C_R01_T03.Multiline = true;
            this.C_R01_T03.Name = "C_R01_T03";
            this.C_R01_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T03.StylePriority.UseFont = false;
            this.C_R01_T03.Text = "";
            this.C_R01_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T03.WordWrap = false;
            // 
            // C_R01_T04
            // 
            this.C_R01_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T04.BorderWidth = 0.5F;
            this.C_R01_T04.CanGrow = false;
            this.C_R01_T04.Dpi = 100F;
            this.C_R01_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 154F);
            this.C_R01_T04.Multiline = true;
            this.C_R01_T04.Name = "C_R01_T04";
            this.C_R01_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T04.StylePriority.UseFont = false;
            this.C_R01_T04.Text = "";
            this.C_R01_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T04.WordWrap = false;
            // 
            // C_R01_T05
            // 
            this.C_R01_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T05.BorderWidth = 0.5F;
            this.C_R01_T05.CanGrow = false;
            this.C_R01_T05.Dpi = 100F;
            this.C_R01_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 154F);
            this.C_R01_T05.Multiline = true;
            this.C_R01_T05.Name = "C_R01_T05";
            this.C_R01_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T05.StylePriority.UseFont = false;
            this.C_R01_T05.Text = "";
            this.C_R01_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T05.WordWrap = false;
            // 
            // C_R01_T06
            // 
            this.C_R01_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T06.BorderWidth = 0.5F;
            this.C_R01_T06.CanGrow = false;
            this.C_R01_T06.Dpi = 100F;
            this.C_R01_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 154F);
            this.C_R01_T06.Multiline = true;
            this.C_R01_T06.Name = "C_R01_T06";
            this.C_R01_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T06.StylePriority.UseFont = false;
            this.C_R01_T06.Text = "";
            this.C_R01_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T06.WordWrap = false;
            // 
            // C_R01_T07
            // 
            this.C_R01_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T07.BorderWidth = 0.5F;
            this.C_R01_T07.CanGrow = false;
            this.C_R01_T07.Dpi = 100F;
            this.C_R01_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 154F);
            this.C_R01_T07.Multiline = true;
            this.C_R01_T07.Name = "C_R01_T07";
            this.C_R01_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T07.StylePriority.UseFont = false;
            this.C_R01_T07.Text = "";
            this.C_R01_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T07.WordWrap = false;
            // 
            // C_R01_T08
            // 
            this.C_R01_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T08.BorderWidth = 0.5F;
            this.C_R01_T08.CanGrow = false;
            this.C_R01_T08.Dpi = 100F;
            this.C_R01_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 154F);
            this.C_R01_T08.Multiline = true;
            this.C_R01_T08.Name = "C_R01_T08";
            this.C_R01_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T08.StylePriority.UseFont = false;
            this.C_R01_T08.Text = "";
            this.C_R01_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T08.WordWrap = false;
            // 
            // C_R01_T09
            // 
            this.C_R01_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T09.BorderWidth = 0.5F;
            this.C_R01_T09.CanGrow = false;
            this.C_R01_T09.Dpi = 100F;
            this.C_R01_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 154F);
            this.C_R01_T09.Multiline = true;
            this.C_R01_T09.Name = "C_R01_T09";
            this.C_R01_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T09.StylePriority.UseFont = false;
            this.C_R01_T09.Text = "";
            this.C_R01_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T09.WordWrap = false;
            // 
            // C_R01_T10
            // 
            this.C_R01_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T10.BorderWidth = 0.5F;
            this.C_R01_T10.CanGrow = false;
            this.C_R01_T10.Dpi = 100F;
            this.C_R01_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 154F);
            this.C_R01_T10.Multiline = true;
            this.C_R01_T10.Name = "C_R01_T10";
            this.C_R01_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T10.StylePriority.UseFont = false;
            this.C_R01_T10.Text = "";
            this.C_R01_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T10.WordWrap = false;
            // 
            // C_R01_T11
            // 
            this.C_R01_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T11.BorderWidth = 0.5F;
            this.C_R01_T11.CanGrow = false;
            this.C_R01_T11.Dpi = 100F;
            this.C_R01_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 154F);
            this.C_R01_T11.Multiline = true;
            this.C_R01_T11.Name = "C_R01_T11";
            this.C_R01_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T11.StylePriority.UseFont = false;
            this.C_R01_T11.Text = "";
            this.C_R01_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T11.WordWrap = false;
            // 
            // C_R01_T12
            // 
            this.C_R01_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R01_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_T12.BorderWidth = 0.5F;
            this.C_R01_T12.CanGrow = false;
            this.C_R01_T12.Dpi = 100F;
            this.C_R01_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 154F);
            this.C_R01_T12.Multiline = true;
            this.C_R01_T12.Name = "C_R01_T12";
            this.C_R01_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R01_T12.StylePriority.UseFont = false;
            this.C_R01_T12.Text = "";
            this.C_R01_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_T12.WordWrap = false;
            // 
            // C_R02_PRC
            // 
            this.C_R02_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R02_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_PRC.BorderWidth = 0.5F;
            this.C_R02_PRC.CanGrow = false;
            this.C_R02_PRC.Dpi = 100F;
            this.C_R02_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 176F);
            this.C_R02_PRC.Multiline = true;
            this.C_R02_PRC.Name = "C_R02_PRC";
            this.C_R02_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R02_PRC.StylePriority.UseFont = false;
            this.C_R02_PRC.Text = "";
            this.C_R02_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_PRC.WordWrap = false;
            // 
            // C_R02_STD
            // 
            this.C_R02_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R02_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_STD.BorderWidth = 0.5F;
            this.C_R02_STD.CanGrow = false;
            this.C_R02_STD.Dpi = 100F;
            this.C_R02_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 176F);
            this.C_R02_STD.Multiline = true;
            this.C_R02_STD.Name = "C_R02_STD";
            this.C_R02_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R02_STD.StylePriority.UseFont = false;
            this.C_R02_STD.Text = "";
            this.C_R02_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_STD.WordWrap = true;
            // 
            // C_R02_FEAT
            // 
            this.C_R02_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R02_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_FEAT.BorderWidth = 0.5F;
            this.C_R02_FEAT.CanGrow = false;
            this.C_R02_FEAT.Dpi = 100F;
            this.C_R02_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 176F);
            this.C_R02_FEAT.Multiline = true;
            this.C_R02_FEAT.Name = "C_R02_FEAT";
            this.C_R02_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R02_FEAT.StylePriority.UseFont = false;
            this.C_R02_FEAT.Text = "";
            this.C_R02_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_FEAT.WordWrap = false;
            // 
            // C_R02_SPEC
            // 
            this.C_R02_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R02_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_SPEC.BorderWidth = 0.5F;
            this.C_R02_SPEC.CanGrow = false;
            this.C_R02_SPEC.Dpi = 100F;
            this.C_R02_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 176F);
            this.C_R02_SPEC.Multiline = true;
            this.C_R02_SPEC.Name = "C_R02_SPEC";
            this.C_R02_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R02_SPEC.StylePriority.UseFont = false;
            this.C_R02_SPEC.Text = "";
            this.C_R02_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_SPEC.WordWrap = true;
            // 
            // C_R02_CYCLE
            // 
            this.C_R02_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R02_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_CYCLE.BorderWidth = 0.5F;
            this.C_R02_CYCLE.CanGrow = false;
            this.C_R02_CYCLE.Dpi = 100F;
            this.C_R02_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 176F);
            this.C_R02_CYCLE.Multiline = true;
            this.C_R02_CYCLE.Name = "C_R02_CYCLE";
            this.C_R02_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R02_CYCLE.StylePriority.UseFont = false;
            this.C_R02_CYCLE.Text = "";
            this.C_R02_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_CYCLE.WordWrap = true;
            // 
            // C_R02_GAUGE
            // 
            this.C_R02_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R02_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_GAUGE.BorderWidth = 0.5F;
            this.C_R02_GAUGE.CanGrow = false;
            this.C_R02_GAUGE.Dpi = 100F;
            this.C_R02_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 176F);
            this.C_R02_GAUGE.Multiline = true;
            this.C_R02_GAUGE.Name = "C_R02_GAUGE";
            this.C_R02_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R02_GAUGE.StylePriority.UseFont = false;
            this.C_R02_GAUGE.Text = "";
            this.C_R02_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_GAUGE.WordWrap = true;
            // 
            // C_R02_NO
            // 
            this.C_R02_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R02_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_NO.BorderWidth = 0.5F;
            this.C_R02_NO.CanGrow = false;
            this.C_R02_NO.Dpi = 100F;
            this.C_R02_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 176F);
            this.C_R02_NO.Multiline = true;
            this.C_R02_NO.Name = "C_R02_NO";
            this.C_R02_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R02_NO.StylePriority.UseFont = false;
            this.C_R02_NO.Text = "";
            this.C_R02_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_NO.WordWrap = false;
            // 
            // C_R02_T01
            // 
            this.C_R02_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T01.BorderWidth = 0.5F;
            this.C_R02_T01.CanGrow = false;
            this.C_R02_T01.Dpi = 100F;
            this.C_R02_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 176F);
            this.C_R02_T01.Multiline = true;
            this.C_R02_T01.Name = "C_R02_T01";
            this.C_R02_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T01.StylePriority.UseFont = false;
            this.C_R02_T01.Text = "";
            this.C_R02_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T01.WordWrap = false;
            // 
            // C_R02_T02
            // 
            this.C_R02_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T02.BorderWidth = 0.5F;
            this.C_R02_T02.CanGrow = false;
            this.C_R02_T02.Dpi = 100F;
            this.C_R02_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 176F);
            this.C_R02_T02.Multiline = true;
            this.C_R02_T02.Name = "C_R02_T02";
            this.C_R02_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T02.StylePriority.UseFont = false;
            this.C_R02_T02.Text = "";
            this.C_R02_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T02.WordWrap = false;
            // 
            // C_R02_T03
            // 
            this.C_R02_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T03.BorderWidth = 0.5F;
            this.C_R02_T03.CanGrow = false;
            this.C_R02_T03.Dpi = 100F;
            this.C_R02_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 176F);
            this.C_R02_T03.Multiline = true;
            this.C_R02_T03.Name = "C_R02_T03";
            this.C_R02_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T03.StylePriority.UseFont = false;
            this.C_R02_T03.Text = "";
            this.C_R02_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T03.WordWrap = false;
            // 
            // C_R02_T04
            // 
            this.C_R02_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T04.BorderWidth = 0.5F;
            this.C_R02_T04.CanGrow = false;
            this.C_R02_T04.Dpi = 100F;
            this.C_R02_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 176F);
            this.C_R02_T04.Multiline = true;
            this.C_R02_T04.Name = "C_R02_T04";
            this.C_R02_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T04.StylePriority.UseFont = false;
            this.C_R02_T04.Text = "";
            this.C_R02_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T04.WordWrap = false;
            // 
            // C_R02_T05
            // 
            this.C_R02_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T05.BorderWidth = 0.5F;
            this.C_R02_T05.CanGrow = false;
            this.C_R02_T05.Dpi = 100F;
            this.C_R02_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 176F);
            this.C_R02_T05.Multiline = true;
            this.C_R02_T05.Name = "C_R02_T05";
            this.C_R02_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T05.StylePriority.UseFont = false;
            this.C_R02_T05.Text = "";
            this.C_R02_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T05.WordWrap = false;
            // 
            // C_R02_T06
            // 
            this.C_R02_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T06.BorderWidth = 0.5F;
            this.C_R02_T06.CanGrow = false;
            this.C_R02_T06.Dpi = 100F;
            this.C_R02_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 176F);
            this.C_R02_T06.Multiline = true;
            this.C_R02_T06.Name = "C_R02_T06";
            this.C_R02_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T06.StylePriority.UseFont = false;
            this.C_R02_T06.Text = "";
            this.C_R02_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T06.WordWrap = false;
            // 
            // C_R02_T07
            // 
            this.C_R02_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T07.BorderWidth = 0.5F;
            this.C_R02_T07.CanGrow = false;
            this.C_R02_T07.Dpi = 100F;
            this.C_R02_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 176F);
            this.C_R02_T07.Multiline = true;
            this.C_R02_T07.Name = "C_R02_T07";
            this.C_R02_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T07.StylePriority.UseFont = false;
            this.C_R02_T07.Text = "";
            this.C_R02_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T07.WordWrap = false;
            // 
            // C_R02_T08
            // 
            this.C_R02_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T08.BorderWidth = 0.5F;
            this.C_R02_T08.CanGrow = false;
            this.C_R02_T08.Dpi = 100F;
            this.C_R02_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 176F);
            this.C_R02_T08.Multiline = true;
            this.C_R02_T08.Name = "C_R02_T08";
            this.C_R02_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T08.StylePriority.UseFont = false;
            this.C_R02_T08.Text = "";
            this.C_R02_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T08.WordWrap = false;
            // 
            // C_R02_T09
            // 
            this.C_R02_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T09.BorderWidth = 0.5F;
            this.C_R02_T09.CanGrow = false;
            this.C_R02_T09.Dpi = 100F;
            this.C_R02_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 176F);
            this.C_R02_T09.Multiline = true;
            this.C_R02_T09.Name = "C_R02_T09";
            this.C_R02_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T09.StylePriority.UseFont = false;
            this.C_R02_T09.Text = "";
            this.C_R02_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T09.WordWrap = false;
            // 
            // C_R02_T10
            // 
            this.C_R02_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T10.BorderWidth = 0.5F;
            this.C_R02_T10.CanGrow = false;
            this.C_R02_T10.Dpi = 100F;
            this.C_R02_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 176F);
            this.C_R02_T10.Multiline = true;
            this.C_R02_T10.Name = "C_R02_T10";
            this.C_R02_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T10.StylePriority.UseFont = false;
            this.C_R02_T10.Text = "";
            this.C_R02_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T10.WordWrap = false;
            // 
            // C_R02_T11
            // 
            this.C_R02_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T11.BorderWidth = 0.5F;
            this.C_R02_T11.CanGrow = false;
            this.C_R02_T11.Dpi = 100F;
            this.C_R02_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 176F);
            this.C_R02_T11.Multiline = true;
            this.C_R02_T11.Name = "C_R02_T11";
            this.C_R02_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T11.StylePriority.UseFont = false;
            this.C_R02_T11.Text = "";
            this.C_R02_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T11.WordWrap = false;
            // 
            // C_R02_T12
            // 
            this.C_R02_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R02_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_T12.BorderWidth = 0.5F;
            this.C_R02_T12.CanGrow = false;
            this.C_R02_T12.Dpi = 100F;
            this.C_R02_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 176F);
            this.C_R02_T12.Multiline = true;
            this.C_R02_T12.Name = "C_R02_T12";
            this.C_R02_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R02_T12.StylePriority.UseFont = false;
            this.C_R02_T12.Text = "";
            this.C_R02_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_T12.WordWrap = false;
            // 
            // C_R03_PRC
            // 
            this.C_R03_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R03_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_PRC.BorderWidth = 0.5F;
            this.C_R03_PRC.CanGrow = false;
            this.C_R03_PRC.Dpi = 100F;
            this.C_R03_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 198F);
            this.C_R03_PRC.Multiline = true;
            this.C_R03_PRC.Name = "C_R03_PRC";
            this.C_R03_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R03_PRC.StylePriority.UseFont = false;
            this.C_R03_PRC.Text = "";
            this.C_R03_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_PRC.WordWrap = false;
            // 
            // C_R03_STD
            // 
            this.C_R03_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R03_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_STD.BorderWidth = 0.5F;
            this.C_R03_STD.CanGrow = false;
            this.C_R03_STD.Dpi = 100F;
            this.C_R03_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 198F);
            this.C_R03_STD.Multiline = true;
            this.C_R03_STD.Name = "C_R03_STD";
            this.C_R03_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R03_STD.StylePriority.UseFont = false;
            this.C_R03_STD.Text = "";
            this.C_R03_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_STD.WordWrap = true;
            // 
            // C_R03_FEAT
            // 
            this.C_R03_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R03_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_FEAT.BorderWidth = 0.5F;
            this.C_R03_FEAT.CanGrow = false;
            this.C_R03_FEAT.Dpi = 100F;
            this.C_R03_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 198F);
            this.C_R03_FEAT.Multiline = true;
            this.C_R03_FEAT.Name = "C_R03_FEAT";
            this.C_R03_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R03_FEAT.StylePriority.UseFont = false;
            this.C_R03_FEAT.Text = "";
            this.C_R03_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_FEAT.WordWrap = false;
            // 
            // C_R03_SPEC
            // 
            this.C_R03_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R03_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_SPEC.BorderWidth = 0.5F;
            this.C_R03_SPEC.CanGrow = false;
            this.C_R03_SPEC.Dpi = 100F;
            this.C_R03_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 198F);
            this.C_R03_SPEC.Multiline = true;
            this.C_R03_SPEC.Name = "C_R03_SPEC";
            this.C_R03_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R03_SPEC.StylePriority.UseFont = false;
            this.C_R03_SPEC.Text = "";
            this.C_R03_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_SPEC.WordWrap = true;
            // 
            // C_R03_CYCLE
            // 
            this.C_R03_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R03_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_CYCLE.BorderWidth = 0.5F;
            this.C_R03_CYCLE.CanGrow = false;
            this.C_R03_CYCLE.Dpi = 100F;
            this.C_R03_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 198F);
            this.C_R03_CYCLE.Multiline = true;
            this.C_R03_CYCLE.Name = "C_R03_CYCLE";
            this.C_R03_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R03_CYCLE.StylePriority.UseFont = false;
            this.C_R03_CYCLE.Text = "";
            this.C_R03_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_CYCLE.WordWrap = true;
            // 
            // C_R03_GAUGE
            // 
            this.C_R03_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R03_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_GAUGE.BorderWidth = 0.5F;
            this.C_R03_GAUGE.CanGrow = false;
            this.C_R03_GAUGE.Dpi = 100F;
            this.C_R03_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 198F);
            this.C_R03_GAUGE.Multiline = true;
            this.C_R03_GAUGE.Name = "C_R03_GAUGE";
            this.C_R03_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R03_GAUGE.StylePriority.UseFont = false;
            this.C_R03_GAUGE.Text = "";
            this.C_R03_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_GAUGE.WordWrap = true;
            // 
            // C_R03_NO
            // 
            this.C_R03_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R03_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_NO.BorderWidth = 0.5F;
            this.C_R03_NO.CanGrow = false;
            this.C_R03_NO.Dpi = 100F;
            this.C_R03_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 198F);
            this.C_R03_NO.Multiline = true;
            this.C_R03_NO.Name = "C_R03_NO";
            this.C_R03_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R03_NO.StylePriority.UseFont = false;
            this.C_R03_NO.Text = "";
            this.C_R03_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_NO.WordWrap = false;
            // 
            // C_R03_T01
            // 
            this.C_R03_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T01.BorderWidth = 0.5F;
            this.C_R03_T01.CanGrow = false;
            this.C_R03_T01.Dpi = 100F;
            this.C_R03_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 198F);
            this.C_R03_T01.Multiline = true;
            this.C_R03_T01.Name = "C_R03_T01";
            this.C_R03_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T01.StylePriority.UseFont = false;
            this.C_R03_T01.Text = "";
            this.C_R03_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T01.WordWrap = false;
            // 
            // C_R03_T02
            // 
            this.C_R03_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T02.BorderWidth = 0.5F;
            this.C_R03_T02.CanGrow = false;
            this.C_R03_T02.Dpi = 100F;
            this.C_R03_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 198F);
            this.C_R03_T02.Multiline = true;
            this.C_R03_T02.Name = "C_R03_T02";
            this.C_R03_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T02.StylePriority.UseFont = false;
            this.C_R03_T02.Text = "";
            this.C_R03_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T02.WordWrap = false;
            // 
            // C_R03_T03
            // 
            this.C_R03_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T03.BorderWidth = 0.5F;
            this.C_R03_T03.CanGrow = false;
            this.C_R03_T03.Dpi = 100F;
            this.C_R03_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 198F);
            this.C_R03_T03.Multiline = true;
            this.C_R03_T03.Name = "C_R03_T03";
            this.C_R03_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T03.StylePriority.UseFont = false;
            this.C_R03_T03.Text = "";
            this.C_R03_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T03.WordWrap = false;
            // 
            // C_R03_T04
            // 
            this.C_R03_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T04.BorderWidth = 0.5F;
            this.C_R03_T04.CanGrow = false;
            this.C_R03_T04.Dpi = 100F;
            this.C_R03_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 198F);
            this.C_R03_T04.Multiline = true;
            this.C_R03_T04.Name = "C_R03_T04";
            this.C_R03_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T04.StylePriority.UseFont = false;
            this.C_R03_T04.Text = "";
            this.C_R03_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T04.WordWrap = false;
            // 
            // C_R03_T05
            // 
            this.C_R03_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T05.BorderWidth = 0.5F;
            this.C_R03_T05.CanGrow = false;
            this.C_R03_T05.Dpi = 100F;
            this.C_R03_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 198F);
            this.C_R03_T05.Multiline = true;
            this.C_R03_T05.Name = "C_R03_T05";
            this.C_R03_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T05.StylePriority.UseFont = false;
            this.C_R03_T05.Text = "";
            this.C_R03_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T05.WordWrap = false;
            // 
            // C_R03_T06
            // 
            this.C_R03_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T06.BorderWidth = 0.5F;
            this.C_R03_T06.CanGrow = false;
            this.C_R03_T06.Dpi = 100F;
            this.C_R03_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 198F);
            this.C_R03_T06.Multiline = true;
            this.C_R03_T06.Name = "C_R03_T06";
            this.C_R03_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T06.StylePriority.UseFont = false;
            this.C_R03_T06.Text = "";
            this.C_R03_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T06.WordWrap = false;
            // 
            // C_R03_T07
            // 
            this.C_R03_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T07.BorderWidth = 0.5F;
            this.C_R03_T07.CanGrow = false;
            this.C_R03_T07.Dpi = 100F;
            this.C_R03_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 198F);
            this.C_R03_T07.Multiline = true;
            this.C_R03_T07.Name = "C_R03_T07";
            this.C_R03_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T07.StylePriority.UseFont = false;
            this.C_R03_T07.Text = "";
            this.C_R03_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T07.WordWrap = false;
            // 
            // C_R03_T08
            // 
            this.C_R03_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T08.BorderWidth = 0.5F;
            this.C_R03_T08.CanGrow = false;
            this.C_R03_T08.Dpi = 100F;
            this.C_R03_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 198F);
            this.C_R03_T08.Multiline = true;
            this.C_R03_T08.Name = "C_R03_T08";
            this.C_R03_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T08.StylePriority.UseFont = false;
            this.C_R03_T08.Text = "";
            this.C_R03_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T08.WordWrap = false;
            // 
            // C_R03_T09
            // 
            this.C_R03_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T09.BorderWidth = 0.5F;
            this.C_R03_T09.CanGrow = false;
            this.C_R03_T09.Dpi = 100F;
            this.C_R03_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 198F);
            this.C_R03_T09.Multiline = true;
            this.C_R03_T09.Name = "C_R03_T09";
            this.C_R03_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T09.StylePriority.UseFont = false;
            this.C_R03_T09.Text = "";
            this.C_R03_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T09.WordWrap = false;
            // 
            // C_R03_T10
            // 
            this.C_R03_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T10.BorderWidth = 0.5F;
            this.C_R03_T10.CanGrow = false;
            this.C_R03_T10.Dpi = 100F;
            this.C_R03_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 198F);
            this.C_R03_T10.Multiline = true;
            this.C_R03_T10.Name = "C_R03_T10";
            this.C_R03_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T10.StylePriority.UseFont = false;
            this.C_R03_T10.Text = "";
            this.C_R03_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T10.WordWrap = false;
            // 
            // C_R03_T11
            // 
            this.C_R03_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T11.BorderWidth = 0.5F;
            this.C_R03_T11.CanGrow = false;
            this.C_R03_T11.Dpi = 100F;
            this.C_R03_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 198F);
            this.C_R03_T11.Multiline = true;
            this.C_R03_T11.Name = "C_R03_T11";
            this.C_R03_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T11.StylePriority.UseFont = false;
            this.C_R03_T11.Text = "";
            this.C_R03_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T11.WordWrap = false;
            // 
            // C_R03_T12
            // 
            this.C_R03_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R03_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_T12.BorderWidth = 0.5F;
            this.C_R03_T12.CanGrow = false;
            this.C_R03_T12.Dpi = 100F;
            this.C_R03_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 198F);
            this.C_R03_T12.Multiline = true;
            this.C_R03_T12.Name = "C_R03_T12";
            this.C_R03_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R03_T12.StylePriority.UseFont = false;
            this.C_R03_T12.Text = "";
            this.C_R03_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_T12.WordWrap = false;
            // 
            // C_R04_PRC
            // 
            this.C_R04_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R04_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_PRC.BorderWidth = 0.5F;
            this.C_R04_PRC.CanGrow = false;
            this.C_R04_PRC.Dpi = 100F;
            this.C_R04_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 220F);
            this.C_R04_PRC.Multiline = true;
            this.C_R04_PRC.Name = "C_R04_PRC";
            this.C_R04_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R04_PRC.StylePriority.UseFont = false;
            this.C_R04_PRC.Text = "";
            this.C_R04_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_PRC.WordWrap = false;
            // 
            // C_R04_STD
            // 
            this.C_R04_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R04_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_STD.BorderWidth = 0.5F;
            this.C_R04_STD.CanGrow = false;
            this.C_R04_STD.Dpi = 100F;
            this.C_R04_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 220F);
            this.C_R04_STD.Multiline = true;
            this.C_R04_STD.Name = "C_R04_STD";
            this.C_R04_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R04_STD.StylePriority.UseFont = false;
            this.C_R04_STD.Text = "";
            this.C_R04_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_STD.WordWrap = true;
            // 
            // C_R04_FEAT
            // 
            this.C_R04_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R04_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_FEAT.BorderWidth = 0.5F;
            this.C_R04_FEAT.CanGrow = false;
            this.C_R04_FEAT.Dpi = 100F;
            this.C_R04_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 220F);
            this.C_R04_FEAT.Multiline = true;
            this.C_R04_FEAT.Name = "C_R04_FEAT";
            this.C_R04_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R04_FEAT.StylePriority.UseFont = false;
            this.C_R04_FEAT.Text = "";
            this.C_R04_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_FEAT.WordWrap = false;
            // 
            // C_R04_SPEC
            // 
            this.C_R04_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R04_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_SPEC.BorderWidth = 0.5F;
            this.C_R04_SPEC.CanGrow = false;
            this.C_R04_SPEC.Dpi = 100F;
            this.C_R04_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 220F);
            this.C_R04_SPEC.Multiline = true;
            this.C_R04_SPEC.Name = "C_R04_SPEC";
            this.C_R04_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R04_SPEC.StylePriority.UseFont = false;
            this.C_R04_SPEC.Text = "";
            this.C_R04_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_SPEC.WordWrap = true;
            // 
            // C_R04_CYCLE
            // 
            this.C_R04_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R04_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_CYCLE.BorderWidth = 0.5F;
            this.C_R04_CYCLE.CanGrow = false;
            this.C_R04_CYCLE.Dpi = 100F;
            this.C_R04_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 220F);
            this.C_R04_CYCLE.Multiline = true;
            this.C_R04_CYCLE.Name = "C_R04_CYCLE";
            this.C_R04_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R04_CYCLE.StylePriority.UseFont = false;
            this.C_R04_CYCLE.Text = "";
            this.C_R04_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_CYCLE.WordWrap = true;
            // 
            // C_R04_GAUGE
            // 
            this.C_R04_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R04_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_GAUGE.BorderWidth = 0.5F;
            this.C_R04_GAUGE.CanGrow = false;
            this.C_R04_GAUGE.Dpi = 100F;
            this.C_R04_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 220F);
            this.C_R04_GAUGE.Multiline = true;
            this.C_R04_GAUGE.Name = "C_R04_GAUGE";
            this.C_R04_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R04_GAUGE.StylePriority.UseFont = false;
            this.C_R04_GAUGE.Text = "";
            this.C_R04_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_GAUGE.WordWrap = true;
            // 
            // C_R04_NO
            // 
            this.C_R04_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R04_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_NO.BorderWidth = 0.5F;
            this.C_R04_NO.CanGrow = false;
            this.C_R04_NO.Dpi = 100F;
            this.C_R04_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 220F);
            this.C_R04_NO.Multiline = true;
            this.C_R04_NO.Name = "C_R04_NO";
            this.C_R04_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R04_NO.StylePriority.UseFont = false;
            this.C_R04_NO.Text = "";
            this.C_R04_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_NO.WordWrap = false;
            // 
            // C_R04_T01
            // 
            this.C_R04_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T01.BorderWidth = 0.5F;
            this.C_R04_T01.CanGrow = false;
            this.C_R04_T01.Dpi = 100F;
            this.C_R04_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 220F);
            this.C_R04_T01.Multiline = true;
            this.C_R04_T01.Name = "C_R04_T01";
            this.C_R04_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T01.StylePriority.UseFont = false;
            this.C_R04_T01.Text = "";
            this.C_R04_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T01.WordWrap = false;
            // 
            // C_R04_T02
            // 
            this.C_R04_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T02.BorderWidth = 0.5F;
            this.C_R04_T02.CanGrow = false;
            this.C_R04_T02.Dpi = 100F;
            this.C_R04_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 220F);
            this.C_R04_T02.Multiline = true;
            this.C_R04_T02.Name = "C_R04_T02";
            this.C_R04_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T02.StylePriority.UseFont = false;
            this.C_R04_T02.Text = "";
            this.C_R04_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T02.WordWrap = false;
            // 
            // C_R04_T03
            // 
            this.C_R04_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T03.BorderWidth = 0.5F;
            this.C_R04_T03.CanGrow = false;
            this.C_R04_T03.Dpi = 100F;
            this.C_R04_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 220F);
            this.C_R04_T03.Multiline = true;
            this.C_R04_T03.Name = "C_R04_T03";
            this.C_R04_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T03.StylePriority.UseFont = false;
            this.C_R04_T03.Text = "";
            this.C_R04_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T03.WordWrap = false;
            // 
            // C_R04_T04
            // 
            this.C_R04_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T04.BorderWidth = 0.5F;
            this.C_R04_T04.CanGrow = false;
            this.C_R04_T04.Dpi = 100F;
            this.C_R04_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 220F);
            this.C_R04_T04.Multiline = true;
            this.C_R04_T04.Name = "C_R04_T04";
            this.C_R04_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T04.StylePriority.UseFont = false;
            this.C_R04_T04.Text = "";
            this.C_R04_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T04.WordWrap = false;
            // 
            // C_R04_T05
            // 
            this.C_R04_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T05.BorderWidth = 0.5F;
            this.C_R04_T05.CanGrow = false;
            this.C_R04_T05.Dpi = 100F;
            this.C_R04_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 220F);
            this.C_R04_T05.Multiline = true;
            this.C_R04_T05.Name = "C_R04_T05";
            this.C_R04_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T05.StylePriority.UseFont = false;
            this.C_R04_T05.Text = "";
            this.C_R04_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T05.WordWrap = false;
            // 
            // C_R04_T06
            // 
            this.C_R04_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T06.BorderWidth = 0.5F;
            this.C_R04_T06.CanGrow = false;
            this.C_R04_T06.Dpi = 100F;
            this.C_R04_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 220F);
            this.C_R04_T06.Multiline = true;
            this.C_R04_T06.Name = "C_R04_T06";
            this.C_R04_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T06.StylePriority.UseFont = false;
            this.C_R04_T06.Text = "";
            this.C_R04_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T06.WordWrap = false;
            // 
            // C_R04_T07
            // 
            this.C_R04_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T07.BorderWidth = 0.5F;
            this.C_R04_T07.CanGrow = false;
            this.C_R04_T07.Dpi = 100F;
            this.C_R04_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 220F);
            this.C_R04_T07.Multiline = true;
            this.C_R04_T07.Name = "C_R04_T07";
            this.C_R04_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T07.StylePriority.UseFont = false;
            this.C_R04_T07.Text = "";
            this.C_R04_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T07.WordWrap = false;
            // 
            // C_R04_T08
            // 
            this.C_R04_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T08.BorderWidth = 0.5F;
            this.C_R04_T08.CanGrow = false;
            this.C_R04_T08.Dpi = 100F;
            this.C_R04_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 220F);
            this.C_R04_T08.Multiline = true;
            this.C_R04_T08.Name = "C_R04_T08";
            this.C_R04_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T08.StylePriority.UseFont = false;
            this.C_R04_T08.Text = "";
            this.C_R04_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T08.WordWrap = false;
            // 
            // C_R04_T09
            // 
            this.C_R04_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T09.BorderWidth = 0.5F;
            this.C_R04_T09.CanGrow = false;
            this.C_R04_T09.Dpi = 100F;
            this.C_R04_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 220F);
            this.C_R04_T09.Multiline = true;
            this.C_R04_T09.Name = "C_R04_T09";
            this.C_R04_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T09.StylePriority.UseFont = false;
            this.C_R04_T09.Text = "";
            this.C_R04_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T09.WordWrap = false;
            // 
            // C_R04_T10
            // 
            this.C_R04_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T10.BorderWidth = 0.5F;
            this.C_R04_T10.CanGrow = false;
            this.C_R04_T10.Dpi = 100F;
            this.C_R04_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 220F);
            this.C_R04_T10.Multiline = true;
            this.C_R04_T10.Name = "C_R04_T10";
            this.C_R04_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T10.StylePriority.UseFont = false;
            this.C_R04_T10.Text = "";
            this.C_R04_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T10.WordWrap = false;
            // 
            // C_R04_T11
            // 
            this.C_R04_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T11.BorderWidth = 0.5F;
            this.C_R04_T11.CanGrow = false;
            this.C_R04_T11.Dpi = 100F;
            this.C_R04_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 220F);
            this.C_R04_T11.Multiline = true;
            this.C_R04_T11.Name = "C_R04_T11";
            this.C_R04_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T11.StylePriority.UseFont = false;
            this.C_R04_T11.Text = "";
            this.C_R04_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T11.WordWrap = false;
            // 
            // C_R04_T12
            // 
            this.C_R04_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R04_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_T12.BorderWidth = 0.5F;
            this.C_R04_T12.CanGrow = false;
            this.C_R04_T12.Dpi = 100F;
            this.C_R04_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 220F);
            this.C_R04_T12.Multiline = true;
            this.C_R04_T12.Name = "C_R04_T12";
            this.C_R04_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R04_T12.StylePriority.UseFont = false;
            this.C_R04_T12.Text = "";
            this.C_R04_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_T12.WordWrap = false;
            // 
            // C_R05_PRC
            // 
            this.C_R05_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R05_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_PRC.BorderWidth = 0.5F;
            this.C_R05_PRC.CanGrow = false;
            this.C_R05_PRC.Dpi = 100F;
            this.C_R05_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 242F);
            this.C_R05_PRC.Multiline = true;
            this.C_R05_PRC.Name = "C_R05_PRC";
            this.C_R05_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R05_PRC.StylePriority.UseFont = false;
            this.C_R05_PRC.Text = "";
            this.C_R05_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_PRC.WordWrap = false;
            // 
            // C_R05_STD
            // 
            this.C_R05_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R05_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_STD.BorderWidth = 0.5F;
            this.C_R05_STD.CanGrow = false;
            this.C_R05_STD.Dpi = 100F;
            this.C_R05_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 242F);
            this.C_R05_STD.Multiline = true;
            this.C_R05_STD.Name = "C_R05_STD";
            this.C_R05_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R05_STD.StylePriority.UseFont = false;
            this.C_R05_STD.Text = "";
            this.C_R05_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_STD.WordWrap = true;
            // 
            // C_R05_FEAT
            // 
            this.C_R05_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R05_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_FEAT.BorderWidth = 0.5F;
            this.C_R05_FEAT.CanGrow = false;
            this.C_R05_FEAT.Dpi = 100F;
            this.C_R05_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 242F);
            this.C_R05_FEAT.Multiline = true;
            this.C_R05_FEAT.Name = "C_R05_FEAT";
            this.C_R05_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R05_FEAT.StylePriority.UseFont = false;
            this.C_R05_FEAT.Text = "";
            this.C_R05_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_FEAT.WordWrap = false;
            // 
            // C_R05_SPEC
            // 
            this.C_R05_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R05_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_SPEC.BorderWidth = 0.5F;
            this.C_R05_SPEC.CanGrow = false;
            this.C_R05_SPEC.Dpi = 100F;
            this.C_R05_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 242F);
            this.C_R05_SPEC.Multiline = true;
            this.C_R05_SPEC.Name = "C_R05_SPEC";
            this.C_R05_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R05_SPEC.StylePriority.UseFont = false;
            this.C_R05_SPEC.Text = "";
            this.C_R05_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_SPEC.WordWrap = true;
            // 
            // C_R05_CYCLE
            // 
            this.C_R05_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R05_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_CYCLE.BorderWidth = 0.5F;
            this.C_R05_CYCLE.CanGrow = false;
            this.C_R05_CYCLE.Dpi = 100F;
            this.C_R05_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 242F);
            this.C_R05_CYCLE.Multiline = true;
            this.C_R05_CYCLE.Name = "C_R05_CYCLE";
            this.C_R05_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R05_CYCLE.StylePriority.UseFont = false;
            this.C_R05_CYCLE.Text = "";
            this.C_R05_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_CYCLE.WordWrap = true;
            // 
            // C_R05_GAUGE
            // 
            this.C_R05_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R05_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_GAUGE.BorderWidth = 0.5F;
            this.C_R05_GAUGE.CanGrow = false;
            this.C_R05_GAUGE.Dpi = 100F;
            this.C_R05_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 242F);
            this.C_R05_GAUGE.Multiline = true;
            this.C_R05_GAUGE.Name = "C_R05_GAUGE";
            this.C_R05_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R05_GAUGE.StylePriority.UseFont = false;
            this.C_R05_GAUGE.Text = "";
            this.C_R05_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_GAUGE.WordWrap = true;
            // 
            // C_R05_NO
            // 
            this.C_R05_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R05_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_NO.BorderWidth = 0.5F;
            this.C_R05_NO.CanGrow = false;
            this.C_R05_NO.Dpi = 100F;
            this.C_R05_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 242F);
            this.C_R05_NO.Multiline = true;
            this.C_R05_NO.Name = "C_R05_NO";
            this.C_R05_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R05_NO.StylePriority.UseFont = false;
            this.C_R05_NO.Text = "";
            this.C_R05_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_NO.WordWrap = false;
            // 
            // C_R05_T01
            // 
            this.C_R05_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T01.BorderWidth = 0.5F;
            this.C_R05_T01.CanGrow = false;
            this.C_R05_T01.Dpi = 100F;
            this.C_R05_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 242F);
            this.C_R05_T01.Multiline = true;
            this.C_R05_T01.Name = "C_R05_T01";
            this.C_R05_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T01.StylePriority.UseFont = false;
            this.C_R05_T01.Text = "";
            this.C_R05_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T01.WordWrap = false;
            // 
            // C_R05_T02
            // 
            this.C_R05_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T02.BorderWidth = 0.5F;
            this.C_R05_T02.CanGrow = false;
            this.C_R05_T02.Dpi = 100F;
            this.C_R05_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 242F);
            this.C_R05_T02.Multiline = true;
            this.C_R05_T02.Name = "C_R05_T02";
            this.C_R05_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T02.StylePriority.UseFont = false;
            this.C_R05_T02.Text = "";
            this.C_R05_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T02.WordWrap = false;
            // 
            // C_R05_T03
            // 
            this.C_R05_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T03.BorderWidth = 0.5F;
            this.C_R05_T03.CanGrow = false;
            this.C_R05_T03.Dpi = 100F;
            this.C_R05_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 242F);
            this.C_R05_T03.Multiline = true;
            this.C_R05_T03.Name = "C_R05_T03";
            this.C_R05_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T03.StylePriority.UseFont = false;
            this.C_R05_T03.Text = "";
            this.C_R05_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T03.WordWrap = false;
            // 
            // C_R05_T04
            // 
            this.C_R05_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T04.BorderWidth = 0.5F;
            this.C_R05_T04.CanGrow = false;
            this.C_R05_T04.Dpi = 100F;
            this.C_R05_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 242F);
            this.C_R05_T04.Multiline = true;
            this.C_R05_T04.Name = "C_R05_T04";
            this.C_R05_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T04.StylePriority.UseFont = false;
            this.C_R05_T04.Text = "";
            this.C_R05_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T04.WordWrap = false;
            // 
            // C_R05_T05
            // 
            this.C_R05_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T05.BorderWidth = 0.5F;
            this.C_R05_T05.CanGrow = false;
            this.C_R05_T05.Dpi = 100F;
            this.C_R05_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 242F);
            this.C_R05_T05.Multiline = true;
            this.C_R05_T05.Name = "C_R05_T05";
            this.C_R05_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T05.StylePriority.UseFont = false;
            this.C_R05_T05.Text = "";
            this.C_R05_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T05.WordWrap = false;
            // 
            // C_R05_T06
            // 
            this.C_R05_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T06.BorderWidth = 0.5F;
            this.C_R05_T06.CanGrow = false;
            this.C_R05_T06.Dpi = 100F;
            this.C_R05_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 242F);
            this.C_R05_T06.Multiline = true;
            this.C_R05_T06.Name = "C_R05_T06";
            this.C_R05_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T06.StylePriority.UseFont = false;
            this.C_R05_T06.Text = "";
            this.C_R05_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T06.WordWrap = false;
            // 
            // C_R05_T07
            // 
            this.C_R05_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T07.BorderWidth = 0.5F;
            this.C_R05_T07.CanGrow = false;
            this.C_R05_T07.Dpi = 100F;
            this.C_R05_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 242F);
            this.C_R05_T07.Multiline = true;
            this.C_R05_T07.Name = "C_R05_T07";
            this.C_R05_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T07.StylePriority.UseFont = false;
            this.C_R05_T07.Text = "";
            this.C_R05_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T07.WordWrap = false;
            // 
            // C_R05_T08
            // 
            this.C_R05_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T08.BorderWidth = 0.5F;
            this.C_R05_T08.CanGrow = false;
            this.C_R05_T08.Dpi = 100F;
            this.C_R05_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 242F);
            this.C_R05_T08.Multiline = true;
            this.C_R05_T08.Name = "C_R05_T08";
            this.C_R05_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T08.StylePriority.UseFont = false;
            this.C_R05_T08.Text = "";
            this.C_R05_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T08.WordWrap = false;
            // 
            // C_R05_T09
            // 
            this.C_R05_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T09.BorderWidth = 0.5F;
            this.C_R05_T09.CanGrow = false;
            this.C_R05_T09.Dpi = 100F;
            this.C_R05_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 242F);
            this.C_R05_T09.Multiline = true;
            this.C_R05_T09.Name = "C_R05_T09";
            this.C_R05_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T09.StylePriority.UseFont = false;
            this.C_R05_T09.Text = "";
            this.C_R05_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T09.WordWrap = false;
            // 
            // C_R05_T10
            // 
            this.C_R05_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T10.BorderWidth = 0.5F;
            this.C_R05_T10.CanGrow = false;
            this.C_R05_T10.Dpi = 100F;
            this.C_R05_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 242F);
            this.C_R05_T10.Multiline = true;
            this.C_R05_T10.Name = "C_R05_T10";
            this.C_R05_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T10.StylePriority.UseFont = false;
            this.C_R05_T10.Text = "";
            this.C_R05_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T10.WordWrap = false;
            // 
            // C_R05_T11
            // 
            this.C_R05_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T11.BorderWidth = 0.5F;
            this.C_R05_T11.CanGrow = false;
            this.C_R05_T11.Dpi = 100F;
            this.C_R05_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 242F);
            this.C_R05_T11.Multiline = true;
            this.C_R05_T11.Name = "C_R05_T11";
            this.C_R05_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T11.StylePriority.UseFont = false;
            this.C_R05_T11.Text = "";
            this.C_R05_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T11.WordWrap = false;
            // 
            // C_R05_T12
            // 
            this.C_R05_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R05_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_T12.BorderWidth = 0.5F;
            this.C_R05_T12.CanGrow = false;
            this.C_R05_T12.Dpi = 100F;
            this.C_R05_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 242F);
            this.C_R05_T12.Multiline = true;
            this.C_R05_T12.Name = "C_R05_T12";
            this.C_R05_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R05_T12.StylePriority.UseFont = false;
            this.C_R05_T12.Text = "";
            this.C_R05_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_T12.WordWrap = false;
            // 
            // C_R06_PRC
            // 
            this.C_R06_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R06_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_PRC.BorderWidth = 0.5F;
            this.C_R06_PRC.CanGrow = false;
            this.C_R06_PRC.Dpi = 100F;
            this.C_R06_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 264F);
            this.C_R06_PRC.Multiline = true;
            this.C_R06_PRC.Name = "C_R06_PRC";
            this.C_R06_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R06_PRC.StylePriority.UseFont = false;
            this.C_R06_PRC.Text = "";
            this.C_R06_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_PRC.WordWrap = false;
            // 
            // C_R06_STD
            // 
            this.C_R06_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R06_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_STD.BorderWidth = 0.5F;
            this.C_R06_STD.CanGrow = false;
            this.C_R06_STD.Dpi = 100F;
            this.C_R06_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 264F);
            this.C_R06_STD.Multiline = true;
            this.C_R06_STD.Name = "C_R06_STD";
            this.C_R06_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R06_STD.StylePriority.UseFont = false;
            this.C_R06_STD.Text = "";
            this.C_R06_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_STD.WordWrap = true;
            // 
            // C_R06_FEAT
            // 
            this.C_R06_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R06_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_FEAT.BorderWidth = 0.5F;
            this.C_R06_FEAT.CanGrow = false;
            this.C_R06_FEAT.Dpi = 100F;
            this.C_R06_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 264F);
            this.C_R06_FEAT.Multiline = true;
            this.C_R06_FEAT.Name = "C_R06_FEAT";
            this.C_R06_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R06_FEAT.StylePriority.UseFont = false;
            this.C_R06_FEAT.Text = "";
            this.C_R06_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_FEAT.WordWrap = false;
            // 
            // C_R06_SPEC
            // 
            this.C_R06_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R06_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_SPEC.BorderWidth = 0.5F;
            this.C_R06_SPEC.CanGrow = false;
            this.C_R06_SPEC.Dpi = 100F;
            this.C_R06_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 264F);
            this.C_R06_SPEC.Multiline = true;
            this.C_R06_SPEC.Name = "C_R06_SPEC";
            this.C_R06_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R06_SPEC.StylePriority.UseFont = false;
            this.C_R06_SPEC.Text = "";
            this.C_R06_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_SPEC.WordWrap = true;
            // 
            // C_R06_CYCLE
            // 
            this.C_R06_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R06_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_CYCLE.BorderWidth = 0.5F;
            this.C_R06_CYCLE.CanGrow = false;
            this.C_R06_CYCLE.Dpi = 100F;
            this.C_R06_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 264F);
            this.C_R06_CYCLE.Multiline = true;
            this.C_R06_CYCLE.Name = "C_R06_CYCLE";
            this.C_R06_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R06_CYCLE.StylePriority.UseFont = false;
            this.C_R06_CYCLE.Text = "";
            this.C_R06_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_CYCLE.WordWrap = true;
            // 
            // C_R06_GAUGE
            // 
            this.C_R06_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R06_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_GAUGE.BorderWidth = 0.5F;
            this.C_R06_GAUGE.CanGrow = false;
            this.C_R06_GAUGE.Dpi = 100F;
            this.C_R06_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 264F);
            this.C_R06_GAUGE.Multiline = true;
            this.C_R06_GAUGE.Name = "C_R06_GAUGE";
            this.C_R06_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R06_GAUGE.StylePriority.UseFont = false;
            this.C_R06_GAUGE.Text = "";
            this.C_R06_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_GAUGE.WordWrap = true;
            // 
            // C_R06_NO
            // 
            this.C_R06_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R06_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_NO.BorderWidth = 0.5F;
            this.C_R06_NO.CanGrow = false;
            this.C_R06_NO.Dpi = 100F;
            this.C_R06_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 264F);
            this.C_R06_NO.Multiline = true;
            this.C_R06_NO.Name = "C_R06_NO";
            this.C_R06_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R06_NO.StylePriority.UseFont = false;
            this.C_R06_NO.Text = "";
            this.C_R06_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_NO.WordWrap = false;
            // 
            // C_R06_T01
            // 
            this.C_R06_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T01.BorderWidth = 0.5F;
            this.C_R06_T01.CanGrow = false;
            this.C_R06_T01.Dpi = 100F;
            this.C_R06_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 264F);
            this.C_R06_T01.Multiline = true;
            this.C_R06_T01.Name = "C_R06_T01";
            this.C_R06_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T01.StylePriority.UseFont = false;
            this.C_R06_T01.Text = "";
            this.C_R06_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T01.WordWrap = false;
            // 
            // C_R06_T02
            // 
            this.C_R06_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T02.BorderWidth = 0.5F;
            this.C_R06_T02.CanGrow = false;
            this.C_R06_T02.Dpi = 100F;
            this.C_R06_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 264F);
            this.C_R06_T02.Multiline = true;
            this.C_R06_T02.Name = "C_R06_T02";
            this.C_R06_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T02.StylePriority.UseFont = false;
            this.C_R06_T02.Text = "";
            this.C_R06_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T02.WordWrap = false;
            // 
            // C_R06_T03
            // 
            this.C_R06_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T03.BorderWidth = 0.5F;
            this.C_R06_T03.CanGrow = false;
            this.C_R06_T03.Dpi = 100F;
            this.C_R06_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 264F);
            this.C_R06_T03.Multiline = true;
            this.C_R06_T03.Name = "C_R06_T03";
            this.C_R06_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T03.StylePriority.UseFont = false;
            this.C_R06_T03.Text = "";
            this.C_R06_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T03.WordWrap = false;
            // 
            // C_R06_T04
            // 
            this.C_R06_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T04.BorderWidth = 0.5F;
            this.C_R06_T04.CanGrow = false;
            this.C_R06_T04.Dpi = 100F;
            this.C_R06_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 264F);
            this.C_R06_T04.Multiline = true;
            this.C_R06_T04.Name = "C_R06_T04";
            this.C_R06_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T04.StylePriority.UseFont = false;
            this.C_R06_T04.Text = "";
            this.C_R06_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T04.WordWrap = false;
            // 
            // C_R06_T05
            // 
            this.C_R06_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T05.BorderWidth = 0.5F;
            this.C_R06_T05.CanGrow = false;
            this.C_R06_T05.Dpi = 100F;
            this.C_R06_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 264F);
            this.C_R06_T05.Multiline = true;
            this.C_R06_T05.Name = "C_R06_T05";
            this.C_R06_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T05.StylePriority.UseFont = false;
            this.C_R06_T05.Text = "";
            this.C_R06_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T05.WordWrap = false;
            // 
            // C_R06_T06
            // 
            this.C_R06_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T06.BorderWidth = 0.5F;
            this.C_R06_T06.CanGrow = false;
            this.C_R06_T06.Dpi = 100F;
            this.C_R06_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 264F);
            this.C_R06_T06.Multiline = true;
            this.C_R06_T06.Name = "C_R06_T06";
            this.C_R06_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T06.StylePriority.UseFont = false;
            this.C_R06_T06.Text = "";
            this.C_R06_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T06.WordWrap = false;
            // 
            // C_R06_T07
            // 
            this.C_R06_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T07.BorderWidth = 0.5F;
            this.C_R06_T07.CanGrow = false;
            this.C_R06_T07.Dpi = 100F;
            this.C_R06_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 264F);
            this.C_R06_T07.Multiline = true;
            this.C_R06_T07.Name = "C_R06_T07";
            this.C_R06_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T07.StylePriority.UseFont = false;
            this.C_R06_T07.Text = "";
            this.C_R06_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T07.WordWrap = false;
            // 
            // C_R06_T08
            // 
            this.C_R06_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T08.BorderWidth = 0.5F;
            this.C_R06_T08.CanGrow = false;
            this.C_R06_T08.Dpi = 100F;
            this.C_R06_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 264F);
            this.C_R06_T08.Multiline = true;
            this.C_R06_T08.Name = "C_R06_T08";
            this.C_R06_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T08.StylePriority.UseFont = false;
            this.C_R06_T08.Text = "";
            this.C_R06_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T08.WordWrap = false;
            // 
            // C_R06_T09
            // 
            this.C_R06_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T09.BorderWidth = 0.5F;
            this.C_R06_T09.CanGrow = false;
            this.C_R06_T09.Dpi = 100F;
            this.C_R06_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 264F);
            this.C_R06_T09.Multiline = true;
            this.C_R06_T09.Name = "C_R06_T09";
            this.C_R06_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T09.StylePriority.UseFont = false;
            this.C_R06_T09.Text = "";
            this.C_R06_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T09.WordWrap = false;
            // 
            // C_R06_T10
            // 
            this.C_R06_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T10.BorderWidth = 0.5F;
            this.C_R06_T10.CanGrow = false;
            this.C_R06_T10.Dpi = 100F;
            this.C_R06_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 264F);
            this.C_R06_T10.Multiline = true;
            this.C_R06_T10.Name = "C_R06_T10";
            this.C_R06_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T10.StylePriority.UseFont = false;
            this.C_R06_T10.Text = "";
            this.C_R06_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T10.WordWrap = false;
            // 
            // C_R06_T11
            // 
            this.C_R06_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T11.BorderWidth = 0.5F;
            this.C_R06_T11.CanGrow = false;
            this.C_R06_T11.Dpi = 100F;
            this.C_R06_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 264F);
            this.C_R06_T11.Multiline = true;
            this.C_R06_T11.Name = "C_R06_T11";
            this.C_R06_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T11.StylePriority.UseFont = false;
            this.C_R06_T11.Text = "";
            this.C_R06_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T11.WordWrap = false;
            // 
            // C_R06_T12
            // 
            this.C_R06_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R06_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_T12.BorderWidth = 0.5F;
            this.C_R06_T12.CanGrow = false;
            this.C_R06_T12.Dpi = 100F;
            this.C_R06_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 264F);
            this.C_R06_T12.Multiline = true;
            this.C_R06_T12.Name = "C_R06_T12";
            this.C_R06_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R06_T12.StylePriority.UseFont = false;
            this.C_R06_T12.Text = "";
            this.C_R06_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_T12.WordWrap = false;
            // 
            // C_R07_PRC
            // 
            this.C_R07_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R07_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_PRC.BorderWidth = 0.5F;
            this.C_R07_PRC.CanGrow = false;
            this.C_R07_PRC.Dpi = 100F;
            this.C_R07_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 286F);
            this.C_R07_PRC.Multiline = true;
            this.C_R07_PRC.Name = "C_R07_PRC";
            this.C_R07_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R07_PRC.StylePriority.UseFont = false;
            this.C_R07_PRC.Text = "";
            this.C_R07_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_PRC.WordWrap = false;
            // 
            // C_R07_STD
            // 
            this.C_R07_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R07_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_STD.BorderWidth = 0.5F;
            this.C_R07_STD.CanGrow = false;
            this.C_R07_STD.Dpi = 100F;
            this.C_R07_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 286F);
            this.C_R07_STD.Multiline = true;
            this.C_R07_STD.Name = "C_R07_STD";
            this.C_R07_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R07_STD.StylePriority.UseFont = false;
            this.C_R07_STD.Text = "";
            this.C_R07_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_STD.WordWrap = true;
            // 
            // C_R07_FEAT
            // 
            this.C_R07_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R07_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_FEAT.BorderWidth = 0.5F;
            this.C_R07_FEAT.CanGrow = false;
            this.C_R07_FEAT.Dpi = 100F;
            this.C_R07_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 286F);
            this.C_R07_FEAT.Multiline = true;
            this.C_R07_FEAT.Name = "C_R07_FEAT";
            this.C_R07_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R07_FEAT.StylePriority.UseFont = false;
            this.C_R07_FEAT.Text = "";
            this.C_R07_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_FEAT.WordWrap = false;
            // 
            // C_R07_SPEC
            // 
            this.C_R07_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R07_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_SPEC.BorderWidth = 0.5F;
            this.C_R07_SPEC.CanGrow = false;
            this.C_R07_SPEC.Dpi = 100F;
            this.C_R07_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 286F);
            this.C_R07_SPEC.Multiline = true;
            this.C_R07_SPEC.Name = "C_R07_SPEC";
            this.C_R07_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R07_SPEC.StylePriority.UseFont = false;
            this.C_R07_SPEC.Text = "";
            this.C_R07_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_SPEC.WordWrap = true;
            // 
            // C_R07_CYCLE
            // 
            this.C_R07_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R07_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_CYCLE.BorderWidth = 0.5F;
            this.C_R07_CYCLE.CanGrow = false;
            this.C_R07_CYCLE.Dpi = 100F;
            this.C_R07_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 286F);
            this.C_R07_CYCLE.Multiline = true;
            this.C_R07_CYCLE.Name = "C_R07_CYCLE";
            this.C_R07_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R07_CYCLE.StylePriority.UseFont = false;
            this.C_R07_CYCLE.Text = "";
            this.C_R07_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_CYCLE.WordWrap = true;
            // 
            // C_R07_GAUGE
            // 
            this.C_R07_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R07_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_GAUGE.BorderWidth = 0.5F;
            this.C_R07_GAUGE.CanGrow = false;
            this.C_R07_GAUGE.Dpi = 100F;
            this.C_R07_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 286F);
            this.C_R07_GAUGE.Multiline = true;
            this.C_R07_GAUGE.Name = "C_R07_GAUGE";
            this.C_R07_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R07_GAUGE.StylePriority.UseFont = false;
            this.C_R07_GAUGE.Text = "";
            this.C_R07_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_GAUGE.WordWrap = true;
            // 
            // C_R07_NO
            // 
            this.C_R07_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R07_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_NO.BorderWidth = 0.5F;
            this.C_R07_NO.CanGrow = false;
            this.C_R07_NO.Dpi = 100F;
            this.C_R07_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 286F);
            this.C_R07_NO.Multiline = true;
            this.C_R07_NO.Name = "C_R07_NO";
            this.C_R07_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R07_NO.StylePriority.UseFont = false;
            this.C_R07_NO.Text = "";
            this.C_R07_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_NO.WordWrap = false;
            // 
            // C_R07_T01
            // 
            this.C_R07_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T01.BorderWidth = 0.5F;
            this.C_R07_T01.CanGrow = false;
            this.C_R07_T01.Dpi = 100F;
            this.C_R07_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 286F);
            this.C_R07_T01.Multiline = true;
            this.C_R07_T01.Name = "C_R07_T01";
            this.C_R07_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T01.StylePriority.UseFont = false;
            this.C_R07_T01.Text = "";
            this.C_R07_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T01.WordWrap = false;
            // 
            // C_R07_T02
            // 
            this.C_R07_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T02.BorderWidth = 0.5F;
            this.C_R07_T02.CanGrow = false;
            this.C_R07_T02.Dpi = 100F;
            this.C_R07_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 286F);
            this.C_R07_T02.Multiline = true;
            this.C_R07_T02.Name = "C_R07_T02";
            this.C_R07_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T02.StylePriority.UseFont = false;
            this.C_R07_T02.Text = "";
            this.C_R07_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T02.WordWrap = false;
            // 
            // C_R07_T03
            // 
            this.C_R07_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T03.BorderWidth = 0.5F;
            this.C_R07_T03.CanGrow = false;
            this.C_R07_T03.Dpi = 100F;
            this.C_R07_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 286F);
            this.C_R07_T03.Multiline = true;
            this.C_R07_T03.Name = "C_R07_T03";
            this.C_R07_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T03.StylePriority.UseFont = false;
            this.C_R07_T03.Text = "";
            this.C_R07_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T03.WordWrap = false;
            // 
            // C_R07_T04
            // 
            this.C_R07_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T04.BorderWidth = 0.5F;
            this.C_R07_T04.CanGrow = false;
            this.C_R07_T04.Dpi = 100F;
            this.C_R07_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 286F);
            this.C_R07_T04.Multiline = true;
            this.C_R07_T04.Name = "C_R07_T04";
            this.C_R07_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T04.StylePriority.UseFont = false;
            this.C_R07_T04.Text = "";
            this.C_R07_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T04.WordWrap = false;
            // 
            // C_R07_T05
            // 
            this.C_R07_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T05.BorderWidth = 0.5F;
            this.C_R07_T05.CanGrow = false;
            this.C_R07_T05.Dpi = 100F;
            this.C_R07_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 286F);
            this.C_R07_T05.Multiline = true;
            this.C_R07_T05.Name = "C_R07_T05";
            this.C_R07_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T05.StylePriority.UseFont = false;
            this.C_R07_T05.Text = "";
            this.C_R07_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T05.WordWrap = false;
            // 
            // C_R07_T06
            // 
            this.C_R07_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T06.BorderWidth = 0.5F;
            this.C_R07_T06.CanGrow = false;
            this.C_R07_T06.Dpi = 100F;
            this.C_R07_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 286F);
            this.C_R07_T06.Multiline = true;
            this.C_R07_T06.Name = "C_R07_T06";
            this.C_R07_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T06.StylePriority.UseFont = false;
            this.C_R07_T06.Text = "";
            this.C_R07_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T06.WordWrap = false;
            // 
            // C_R07_T07
            // 
            this.C_R07_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T07.BorderWidth = 0.5F;
            this.C_R07_T07.CanGrow = false;
            this.C_R07_T07.Dpi = 100F;
            this.C_R07_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 286F);
            this.C_R07_T07.Multiline = true;
            this.C_R07_T07.Name = "C_R07_T07";
            this.C_R07_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T07.StylePriority.UseFont = false;
            this.C_R07_T07.Text = "";
            this.C_R07_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T07.WordWrap = false;
            // 
            // C_R07_T08
            // 
            this.C_R07_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T08.BorderWidth = 0.5F;
            this.C_R07_T08.CanGrow = false;
            this.C_R07_T08.Dpi = 100F;
            this.C_R07_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 286F);
            this.C_R07_T08.Multiline = true;
            this.C_R07_T08.Name = "C_R07_T08";
            this.C_R07_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T08.StylePriority.UseFont = false;
            this.C_R07_T08.Text = "";
            this.C_R07_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T08.WordWrap = false;
            // 
            // C_R07_T09
            // 
            this.C_R07_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T09.BorderWidth = 0.5F;
            this.C_R07_T09.CanGrow = false;
            this.C_R07_T09.Dpi = 100F;
            this.C_R07_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 286F);
            this.C_R07_T09.Multiline = true;
            this.C_R07_T09.Name = "C_R07_T09";
            this.C_R07_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T09.StylePriority.UseFont = false;
            this.C_R07_T09.Text = "";
            this.C_R07_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T09.WordWrap = false;
            // 
            // C_R07_T10
            // 
            this.C_R07_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T10.BorderWidth = 0.5F;
            this.C_R07_T10.CanGrow = false;
            this.C_R07_T10.Dpi = 100F;
            this.C_R07_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 286F);
            this.C_R07_T10.Multiline = true;
            this.C_R07_T10.Name = "C_R07_T10";
            this.C_R07_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T10.StylePriority.UseFont = false;
            this.C_R07_T10.Text = "";
            this.C_R07_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T10.WordWrap = false;
            // 
            // C_R07_T11
            // 
            this.C_R07_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T11.BorderWidth = 0.5F;
            this.C_R07_T11.CanGrow = false;
            this.C_R07_T11.Dpi = 100F;
            this.C_R07_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 286F);
            this.C_R07_T11.Multiline = true;
            this.C_R07_T11.Name = "C_R07_T11";
            this.C_R07_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T11.StylePriority.UseFont = false;
            this.C_R07_T11.Text = "";
            this.C_R07_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T11.WordWrap = false;
            // 
            // C_R07_T12
            // 
            this.C_R07_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R07_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_T12.BorderWidth = 0.5F;
            this.C_R07_T12.CanGrow = false;
            this.C_R07_T12.Dpi = 100F;
            this.C_R07_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 286F);
            this.C_R07_T12.Multiline = true;
            this.C_R07_T12.Name = "C_R07_T12";
            this.C_R07_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R07_T12.StylePriority.UseFont = false;
            this.C_R07_T12.Text = "";
            this.C_R07_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_T12.WordWrap = false;
            // 
            // C_R08_PRC
            // 
            this.C_R08_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R08_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_PRC.BorderWidth = 0.5F;
            this.C_R08_PRC.CanGrow = false;
            this.C_R08_PRC.Dpi = 100F;
            this.C_R08_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 308F);
            this.C_R08_PRC.Multiline = true;
            this.C_R08_PRC.Name = "C_R08_PRC";
            this.C_R08_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R08_PRC.StylePriority.UseFont = false;
            this.C_R08_PRC.Text = "";
            this.C_R08_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_PRC.WordWrap = false;
            // 
            // C_R08_STD
            // 
            this.C_R08_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R08_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_STD.BorderWidth = 0.5F;
            this.C_R08_STD.CanGrow = false;
            this.C_R08_STD.Dpi = 100F;
            this.C_R08_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 308F);
            this.C_R08_STD.Multiline = true;
            this.C_R08_STD.Name = "C_R08_STD";
            this.C_R08_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R08_STD.StylePriority.UseFont = false;
            this.C_R08_STD.Text = "";
            this.C_R08_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_STD.WordWrap = true;
            // 
            // C_R08_FEAT
            // 
            this.C_R08_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R08_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_FEAT.BorderWidth = 0.5F;
            this.C_R08_FEAT.CanGrow = false;
            this.C_R08_FEAT.Dpi = 100F;
            this.C_R08_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 308F);
            this.C_R08_FEAT.Multiline = true;
            this.C_R08_FEAT.Name = "C_R08_FEAT";
            this.C_R08_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R08_FEAT.StylePriority.UseFont = false;
            this.C_R08_FEAT.Text = "";
            this.C_R08_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_FEAT.WordWrap = false;
            // 
            // C_R08_SPEC
            // 
            this.C_R08_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R08_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_SPEC.BorderWidth = 0.5F;
            this.C_R08_SPEC.CanGrow = false;
            this.C_R08_SPEC.Dpi = 100F;
            this.C_R08_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 308F);
            this.C_R08_SPEC.Multiline = true;
            this.C_R08_SPEC.Name = "C_R08_SPEC";
            this.C_R08_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R08_SPEC.StylePriority.UseFont = false;
            this.C_R08_SPEC.Text = "";
            this.C_R08_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_SPEC.WordWrap = true;
            // 
            // C_R08_CYCLE
            // 
            this.C_R08_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R08_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_CYCLE.BorderWidth = 0.5F;
            this.C_R08_CYCLE.CanGrow = false;
            this.C_R08_CYCLE.Dpi = 100F;
            this.C_R08_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 308F);
            this.C_R08_CYCLE.Multiline = true;
            this.C_R08_CYCLE.Name = "C_R08_CYCLE";
            this.C_R08_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R08_CYCLE.StylePriority.UseFont = false;
            this.C_R08_CYCLE.Text = "";
            this.C_R08_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_CYCLE.WordWrap = true;
            // 
            // C_R08_GAUGE
            // 
            this.C_R08_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R08_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_GAUGE.BorderWidth = 0.5F;
            this.C_R08_GAUGE.CanGrow = false;
            this.C_R08_GAUGE.Dpi = 100F;
            this.C_R08_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 308F);
            this.C_R08_GAUGE.Multiline = true;
            this.C_R08_GAUGE.Name = "C_R08_GAUGE";
            this.C_R08_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R08_GAUGE.StylePriority.UseFont = false;
            this.C_R08_GAUGE.Text = "";
            this.C_R08_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_GAUGE.WordWrap = true;
            // 
            // C_R08_NO
            // 
            this.C_R08_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R08_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_NO.BorderWidth = 0.5F;
            this.C_R08_NO.CanGrow = false;
            this.C_R08_NO.Dpi = 100F;
            this.C_R08_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 308F);
            this.C_R08_NO.Multiline = true;
            this.C_R08_NO.Name = "C_R08_NO";
            this.C_R08_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R08_NO.StylePriority.UseFont = false;
            this.C_R08_NO.Text = "";
            this.C_R08_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_NO.WordWrap = false;
            // 
            // C_R08_T01
            // 
            this.C_R08_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T01.BorderWidth = 0.5F;
            this.C_R08_T01.CanGrow = false;
            this.C_R08_T01.Dpi = 100F;
            this.C_R08_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 308F);
            this.C_R08_T01.Multiline = true;
            this.C_R08_T01.Name = "C_R08_T01";
            this.C_R08_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T01.StylePriority.UseFont = false;
            this.C_R08_T01.Text = "";
            this.C_R08_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T01.WordWrap = false;
            // 
            // C_R08_T02
            // 
            this.C_R08_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T02.BorderWidth = 0.5F;
            this.C_R08_T02.CanGrow = false;
            this.C_R08_T02.Dpi = 100F;
            this.C_R08_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 308F);
            this.C_R08_T02.Multiline = true;
            this.C_R08_T02.Name = "C_R08_T02";
            this.C_R08_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T02.StylePriority.UseFont = false;
            this.C_R08_T02.Text = "";
            this.C_R08_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T02.WordWrap = false;
            // 
            // C_R08_T03
            // 
            this.C_R08_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T03.BorderWidth = 0.5F;
            this.C_R08_T03.CanGrow = false;
            this.C_R08_T03.Dpi = 100F;
            this.C_R08_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 308F);
            this.C_R08_T03.Multiline = true;
            this.C_R08_T03.Name = "C_R08_T03";
            this.C_R08_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T03.StylePriority.UseFont = false;
            this.C_R08_T03.Text = "";
            this.C_R08_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T03.WordWrap = false;
            // 
            // C_R08_T04
            // 
            this.C_R08_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T04.BorderWidth = 0.5F;
            this.C_R08_T04.CanGrow = false;
            this.C_R08_T04.Dpi = 100F;
            this.C_R08_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 308F);
            this.C_R08_T04.Multiline = true;
            this.C_R08_T04.Name = "C_R08_T04";
            this.C_R08_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T04.StylePriority.UseFont = false;
            this.C_R08_T04.Text = "";
            this.C_R08_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T04.WordWrap = false;
            // 
            // C_R08_T05
            // 
            this.C_R08_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T05.BorderWidth = 0.5F;
            this.C_R08_T05.CanGrow = false;
            this.C_R08_T05.Dpi = 100F;
            this.C_R08_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 308F);
            this.C_R08_T05.Multiline = true;
            this.C_R08_T05.Name = "C_R08_T05";
            this.C_R08_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T05.StylePriority.UseFont = false;
            this.C_R08_T05.Text = "";
            this.C_R08_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T05.WordWrap = false;
            // 
            // C_R08_T06
            // 
            this.C_R08_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T06.BorderWidth = 0.5F;
            this.C_R08_T06.CanGrow = false;
            this.C_R08_T06.Dpi = 100F;
            this.C_R08_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 308F);
            this.C_R08_T06.Multiline = true;
            this.C_R08_T06.Name = "C_R08_T06";
            this.C_R08_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T06.StylePriority.UseFont = false;
            this.C_R08_T06.Text = "";
            this.C_R08_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T06.WordWrap = false;
            // 
            // C_R08_T07
            // 
            this.C_R08_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T07.BorderWidth = 0.5F;
            this.C_R08_T07.CanGrow = false;
            this.C_R08_T07.Dpi = 100F;
            this.C_R08_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 308F);
            this.C_R08_T07.Multiline = true;
            this.C_R08_T07.Name = "C_R08_T07";
            this.C_R08_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T07.StylePriority.UseFont = false;
            this.C_R08_T07.Text = "";
            this.C_R08_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T07.WordWrap = false;
            // 
            // C_R08_T08
            // 
            this.C_R08_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T08.BorderWidth = 0.5F;
            this.C_R08_T08.CanGrow = false;
            this.C_R08_T08.Dpi = 100F;
            this.C_R08_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 308F);
            this.C_R08_T08.Multiline = true;
            this.C_R08_T08.Name = "C_R08_T08";
            this.C_R08_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T08.StylePriority.UseFont = false;
            this.C_R08_T08.Text = "";
            this.C_R08_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T08.WordWrap = false;
            // 
            // C_R08_T09
            // 
            this.C_R08_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T09.BorderWidth = 0.5F;
            this.C_R08_T09.CanGrow = false;
            this.C_R08_T09.Dpi = 100F;
            this.C_R08_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 308F);
            this.C_R08_T09.Multiline = true;
            this.C_R08_T09.Name = "C_R08_T09";
            this.C_R08_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T09.StylePriority.UseFont = false;
            this.C_R08_T09.Text = "";
            this.C_R08_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T09.WordWrap = false;
            // 
            // C_R08_T10
            // 
            this.C_R08_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T10.BorderWidth = 0.5F;
            this.C_R08_T10.CanGrow = false;
            this.C_R08_T10.Dpi = 100F;
            this.C_R08_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 308F);
            this.C_R08_T10.Multiline = true;
            this.C_R08_T10.Name = "C_R08_T10";
            this.C_R08_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T10.StylePriority.UseFont = false;
            this.C_R08_T10.Text = "";
            this.C_R08_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T10.WordWrap = false;
            // 
            // C_R08_T11
            // 
            this.C_R08_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T11.BorderWidth = 0.5F;
            this.C_R08_T11.CanGrow = false;
            this.C_R08_T11.Dpi = 100F;
            this.C_R08_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 308F);
            this.C_R08_T11.Multiline = true;
            this.C_R08_T11.Name = "C_R08_T11";
            this.C_R08_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T11.StylePriority.UseFont = false;
            this.C_R08_T11.Text = "";
            this.C_R08_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T11.WordWrap = false;
            // 
            // C_R08_T12
            // 
            this.C_R08_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R08_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_T12.BorderWidth = 0.5F;
            this.C_R08_T12.CanGrow = false;
            this.C_R08_T12.Dpi = 100F;
            this.C_R08_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 308F);
            this.C_R08_T12.Multiline = true;
            this.C_R08_T12.Name = "C_R08_T12";
            this.C_R08_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R08_T12.StylePriority.UseFont = false;
            this.C_R08_T12.Text = "";
            this.C_R08_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_T12.WordWrap = false;
            // 
            // C_R09_PRC
            // 
            this.C_R09_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R09_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_PRC.BorderWidth = 0.5F;
            this.C_R09_PRC.CanGrow = false;
            this.C_R09_PRC.Dpi = 100F;
            this.C_R09_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 330F);
            this.C_R09_PRC.Multiline = true;
            this.C_R09_PRC.Name = "C_R09_PRC";
            this.C_R09_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R09_PRC.StylePriority.UseFont = false;
            this.C_R09_PRC.Text = "";
            this.C_R09_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_PRC.WordWrap = false;
            // 
            // C_R09_STD
            // 
            this.C_R09_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R09_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_STD.BorderWidth = 0.5F;
            this.C_R09_STD.CanGrow = false;
            this.C_R09_STD.Dpi = 100F;
            this.C_R09_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 330F);
            this.C_R09_STD.Multiline = true;
            this.C_R09_STD.Name = "C_R09_STD";
            this.C_R09_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R09_STD.StylePriority.UseFont = false;
            this.C_R09_STD.Text = "";
            this.C_R09_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_STD.WordWrap = true;
            // 
            // C_R09_FEAT
            // 
            this.C_R09_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R09_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_FEAT.BorderWidth = 0.5F;
            this.C_R09_FEAT.CanGrow = false;
            this.C_R09_FEAT.Dpi = 100F;
            this.C_R09_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 330F);
            this.C_R09_FEAT.Multiline = true;
            this.C_R09_FEAT.Name = "C_R09_FEAT";
            this.C_R09_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R09_FEAT.StylePriority.UseFont = false;
            this.C_R09_FEAT.Text = "";
            this.C_R09_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_FEAT.WordWrap = false;
            // 
            // C_R09_SPEC
            // 
            this.C_R09_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R09_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_SPEC.BorderWidth = 0.5F;
            this.C_R09_SPEC.CanGrow = false;
            this.C_R09_SPEC.Dpi = 100F;
            this.C_R09_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 330F);
            this.C_R09_SPEC.Multiline = true;
            this.C_R09_SPEC.Name = "C_R09_SPEC";
            this.C_R09_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R09_SPEC.StylePriority.UseFont = false;
            this.C_R09_SPEC.Text = "";
            this.C_R09_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_SPEC.WordWrap = true;
            // 
            // C_R09_CYCLE
            // 
            this.C_R09_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R09_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_CYCLE.BorderWidth = 0.5F;
            this.C_R09_CYCLE.CanGrow = false;
            this.C_R09_CYCLE.Dpi = 100F;
            this.C_R09_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 330F);
            this.C_R09_CYCLE.Multiline = true;
            this.C_R09_CYCLE.Name = "C_R09_CYCLE";
            this.C_R09_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R09_CYCLE.StylePriority.UseFont = false;
            this.C_R09_CYCLE.Text = "";
            this.C_R09_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_CYCLE.WordWrap = true;
            // 
            // C_R09_GAUGE
            // 
            this.C_R09_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R09_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_GAUGE.BorderWidth = 0.5F;
            this.C_R09_GAUGE.CanGrow = false;
            this.C_R09_GAUGE.Dpi = 100F;
            this.C_R09_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 330F);
            this.C_R09_GAUGE.Multiline = true;
            this.C_R09_GAUGE.Name = "C_R09_GAUGE";
            this.C_R09_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R09_GAUGE.StylePriority.UseFont = false;
            this.C_R09_GAUGE.Text = "";
            this.C_R09_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_GAUGE.WordWrap = true;
            // 
            // C_R09_NO
            // 
            this.C_R09_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R09_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_NO.BorderWidth = 0.5F;
            this.C_R09_NO.CanGrow = false;
            this.C_R09_NO.Dpi = 100F;
            this.C_R09_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 330F);
            this.C_R09_NO.Multiline = true;
            this.C_R09_NO.Name = "C_R09_NO";
            this.C_R09_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R09_NO.StylePriority.UseFont = false;
            this.C_R09_NO.Text = "";
            this.C_R09_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_NO.WordWrap = false;
            // 
            // C_R09_T01
            // 
            this.C_R09_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T01.BorderWidth = 0.5F;
            this.C_R09_T01.CanGrow = false;
            this.C_R09_T01.Dpi = 100F;
            this.C_R09_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 330F);
            this.C_R09_T01.Multiline = true;
            this.C_R09_T01.Name = "C_R09_T01";
            this.C_R09_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T01.StylePriority.UseFont = false;
            this.C_R09_T01.Text = "";
            this.C_R09_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T01.WordWrap = false;
            // 
            // C_R09_T02
            // 
            this.C_R09_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T02.BorderWidth = 0.5F;
            this.C_R09_T02.CanGrow = false;
            this.C_R09_T02.Dpi = 100F;
            this.C_R09_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 330F);
            this.C_R09_T02.Multiline = true;
            this.C_R09_T02.Name = "C_R09_T02";
            this.C_R09_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T02.StylePriority.UseFont = false;
            this.C_R09_T02.Text = "";
            this.C_R09_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T02.WordWrap = false;
            // 
            // C_R09_T03
            // 
            this.C_R09_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T03.BorderWidth = 0.5F;
            this.C_R09_T03.CanGrow = false;
            this.C_R09_T03.Dpi = 100F;
            this.C_R09_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 330F);
            this.C_R09_T03.Multiline = true;
            this.C_R09_T03.Name = "C_R09_T03";
            this.C_R09_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T03.StylePriority.UseFont = false;
            this.C_R09_T03.Text = "";
            this.C_R09_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T03.WordWrap = false;
            // 
            // C_R09_T04
            // 
            this.C_R09_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T04.BorderWidth = 0.5F;
            this.C_R09_T04.CanGrow = false;
            this.C_R09_T04.Dpi = 100F;
            this.C_R09_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 330F);
            this.C_R09_T04.Multiline = true;
            this.C_R09_T04.Name = "C_R09_T04";
            this.C_R09_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T04.StylePriority.UseFont = false;
            this.C_R09_T04.Text = "";
            this.C_R09_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T04.WordWrap = false;
            // 
            // C_R09_T05
            // 
            this.C_R09_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T05.BorderWidth = 0.5F;
            this.C_R09_T05.CanGrow = false;
            this.C_R09_T05.Dpi = 100F;
            this.C_R09_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 330F);
            this.C_R09_T05.Multiline = true;
            this.C_R09_T05.Name = "C_R09_T05";
            this.C_R09_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T05.StylePriority.UseFont = false;
            this.C_R09_T05.Text = "";
            this.C_R09_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T05.WordWrap = false;
            // 
            // C_R09_T06
            // 
            this.C_R09_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T06.BorderWidth = 0.5F;
            this.C_R09_T06.CanGrow = false;
            this.C_R09_T06.Dpi = 100F;
            this.C_R09_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 330F);
            this.C_R09_T06.Multiline = true;
            this.C_R09_T06.Name = "C_R09_T06";
            this.C_R09_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T06.StylePriority.UseFont = false;
            this.C_R09_T06.Text = "";
            this.C_R09_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T06.WordWrap = false;
            // 
            // C_R09_T07
            // 
            this.C_R09_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T07.BorderWidth = 0.5F;
            this.C_R09_T07.CanGrow = false;
            this.C_R09_T07.Dpi = 100F;
            this.C_R09_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 330F);
            this.C_R09_T07.Multiline = true;
            this.C_R09_T07.Name = "C_R09_T07";
            this.C_R09_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T07.StylePriority.UseFont = false;
            this.C_R09_T07.Text = "";
            this.C_R09_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T07.WordWrap = false;
            // 
            // C_R09_T08
            // 
            this.C_R09_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T08.BorderWidth = 0.5F;
            this.C_R09_T08.CanGrow = false;
            this.C_R09_T08.Dpi = 100F;
            this.C_R09_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 330F);
            this.C_R09_T08.Multiline = true;
            this.C_R09_T08.Name = "C_R09_T08";
            this.C_R09_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T08.StylePriority.UseFont = false;
            this.C_R09_T08.Text = "";
            this.C_R09_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T08.WordWrap = false;
            // 
            // C_R09_T09
            // 
            this.C_R09_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T09.BorderWidth = 0.5F;
            this.C_R09_T09.CanGrow = false;
            this.C_R09_T09.Dpi = 100F;
            this.C_R09_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 330F);
            this.C_R09_T09.Multiline = true;
            this.C_R09_T09.Name = "C_R09_T09";
            this.C_R09_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T09.StylePriority.UseFont = false;
            this.C_R09_T09.Text = "";
            this.C_R09_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T09.WordWrap = false;
            // 
            // C_R09_T10
            // 
            this.C_R09_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T10.BorderWidth = 0.5F;
            this.C_R09_T10.CanGrow = false;
            this.C_R09_T10.Dpi = 100F;
            this.C_R09_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 330F);
            this.C_R09_T10.Multiline = true;
            this.C_R09_T10.Name = "C_R09_T10";
            this.C_R09_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T10.StylePriority.UseFont = false;
            this.C_R09_T10.Text = "";
            this.C_R09_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T10.WordWrap = false;
            // 
            // C_R09_T11
            // 
            this.C_R09_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T11.BorderWidth = 0.5F;
            this.C_R09_T11.CanGrow = false;
            this.C_R09_T11.Dpi = 100F;
            this.C_R09_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 330F);
            this.C_R09_T11.Multiline = true;
            this.C_R09_T11.Name = "C_R09_T11";
            this.C_R09_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T11.StylePriority.UseFont = false;
            this.C_R09_T11.Text = "";
            this.C_R09_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T11.WordWrap = false;
            // 
            // C_R09_T12
            // 
            this.C_R09_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R09_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_T12.BorderWidth = 0.5F;
            this.C_R09_T12.CanGrow = false;
            this.C_R09_T12.Dpi = 100F;
            this.C_R09_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 330F);
            this.C_R09_T12.Multiline = true;
            this.C_R09_T12.Name = "C_R09_T12";
            this.C_R09_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R09_T12.StylePriority.UseFont = false;
            this.C_R09_T12.Text = "";
            this.C_R09_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_T12.WordWrap = false;
            // 
            // C_R10_PRC
            // 
            this.C_R10_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R10_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_PRC.BorderWidth = 0.5F;
            this.C_R10_PRC.CanGrow = false;
            this.C_R10_PRC.Dpi = 100F;
            this.C_R10_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 352F);
            this.C_R10_PRC.Multiline = true;
            this.C_R10_PRC.Name = "C_R10_PRC";
            this.C_R10_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R10_PRC.StylePriority.UseFont = false;
            this.C_R10_PRC.Text = "";
            this.C_R10_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_PRC.WordWrap = false;
            // 
            // C_R10_STD
            // 
            this.C_R10_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R10_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_STD.BorderWidth = 0.5F;
            this.C_R10_STD.CanGrow = false;
            this.C_R10_STD.Dpi = 100F;
            this.C_R10_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 352F);
            this.C_R10_STD.Multiline = true;
            this.C_R10_STD.Name = "C_R10_STD";
            this.C_R10_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R10_STD.StylePriority.UseFont = false;
            this.C_R10_STD.Text = "";
            this.C_R10_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_STD.WordWrap = true;
            // 
            // C_R10_FEAT
            // 
            this.C_R10_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R10_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_FEAT.BorderWidth = 0.5F;
            this.C_R10_FEAT.CanGrow = false;
            this.C_R10_FEAT.Dpi = 100F;
            this.C_R10_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 352F);
            this.C_R10_FEAT.Multiline = true;
            this.C_R10_FEAT.Name = "C_R10_FEAT";
            this.C_R10_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R10_FEAT.StylePriority.UseFont = false;
            this.C_R10_FEAT.Text = "";
            this.C_R10_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_FEAT.WordWrap = false;
            // 
            // C_R10_SPEC
            // 
            this.C_R10_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R10_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_SPEC.BorderWidth = 0.5F;
            this.C_R10_SPEC.CanGrow = false;
            this.C_R10_SPEC.Dpi = 100F;
            this.C_R10_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 352F);
            this.C_R10_SPEC.Multiline = true;
            this.C_R10_SPEC.Name = "C_R10_SPEC";
            this.C_R10_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R10_SPEC.StylePriority.UseFont = false;
            this.C_R10_SPEC.Text = "";
            this.C_R10_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_SPEC.WordWrap = true;
            // 
            // C_R10_CYCLE
            // 
            this.C_R10_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R10_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_CYCLE.BorderWidth = 0.5F;
            this.C_R10_CYCLE.CanGrow = false;
            this.C_R10_CYCLE.Dpi = 100F;
            this.C_R10_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 352F);
            this.C_R10_CYCLE.Multiline = true;
            this.C_R10_CYCLE.Name = "C_R10_CYCLE";
            this.C_R10_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R10_CYCLE.StylePriority.UseFont = false;
            this.C_R10_CYCLE.Text = "";
            this.C_R10_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_CYCLE.WordWrap = true;
            // 
            // C_R10_GAUGE
            // 
            this.C_R10_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R10_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_GAUGE.BorderWidth = 0.5F;
            this.C_R10_GAUGE.CanGrow = false;
            this.C_R10_GAUGE.Dpi = 100F;
            this.C_R10_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 352F);
            this.C_R10_GAUGE.Multiline = true;
            this.C_R10_GAUGE.Name = "C_R10_GAUGE";
            this.C_R10_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R10_GAUGE.StylePriority.UseFont = false;
            this.C_R10_GAUGE.Text = "";
            this.C_R10_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_GAUGE.WordWrap = true;
            // 
            // C_R10_NO
            // 
            this.C_R10_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R10_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_NO.BorderWidth = 0.5F;
            this.C_R10_NO.CanGrow = false;
            this.C_R10_NO.Dpi = 100F;
            this.C_R10_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 352F);
            this.C_R10_NO.Multiline = true;
            this.C_R10_NO.Name = "C_R10_NO";
            this.C_R10_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R10_NO.StylePriority.UseFont = false;
            this.C_R10_NO.Text = "";
            this.C_R10_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_NO.WordWrap = false;
            // 
            // C_R10_T01
            // 
            this.C_R10_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T01.BorderWidth = 0.5F;
            this.C_R10_T01.CanGrow = false;
            this.C_R10_T01.Dpi = 100F;
            this.C_R10_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 352F);
            this.C_R10_T01.Multiline = true;
            this.C_R10_T01.Name = "C_R10_T01";
            this.C_R10_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T01.StylePriority.UseFont = false;
            this.C_R10_T01.Text = "";
            this.C_R10_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T01.WordWrap = false;
            // 
            // C_R10_T02
            // 
            this.C_R10_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T02.BorderWidth = 0.5F;
            this.C_R10_T02.CanGrow = false;
            this.C_R10_T02.Dpi = 100F;
            this.C_R10_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 352F);
            this.C_R10_T02.Multiline = true;
            this.C_R10_T02.Name = "C_R10_T02";
            this.C_R10_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T02.StylePriority.UseFont = false;
            this.C_R10_T02.Text = "";
            this.C_R10_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T02.WordWrap = false;
            // 
            // C_R10_T03
            // 
            this.C_R10_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T03.BorderWidth = 0.5F;
            this.C_R10_T03.CanGrow = false;
            this.C_R10_T03.Dpi = 100F;
            this.C_R10_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 352F);
            this.C_R10_T03.Multiline = true;
            this.C_R10_T03.Name = "C_R10_T03";
            this.C_R10_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T03.StylePriority.UseFont = false;
            this.C_R10_T03.Text = "";
            this.C_R10_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T03.WordWrap = false;
            // 
            // C_R10_T04
            // 
            this.C_R10_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T04.BorderWidth = 0.5F;
            this.C_R10_T04.CanGrow = false;
            this.C_R10_T04.Dpi = 100F;
            this.C_R10_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 352F);
            this.C_R10_T04.Multiline = true;
            this.C_R10_T04.Name = "C_R10_T04";
            this.C_R10_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T04.StylePriority.UseFont = false;
            this.C_R10_T04.Text = "";
            this.C_R10_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T04.WordWrap = false;
            // 
            // C_R10_T05
            // 
            this.C_R10_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T05.BorderWidth = 0.5F;
            this.C_R10_T05.CanGrow = false;
            this.C_R10_T05.Dpi = 100F;
            this.C_R10_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 352F);
            this.C_R10_T05.Multiline = true;
            this.C_R10_T05.Name = "C_R10_T05";
            this.C_R10_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T05.StylePriority.UseFont = false;
            this.C_R10_T05.Text = "";
            this.C_R10_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T05.WordWrap = false;
            // 
            // C_R10_T06
            // 
            this.C_R10_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T06.BorderWidth = 0.5F;
            this.C_R10_T06.CanGrow = false;
            this.C_R10_T06.Dpi = 100F;
            this.C_R10_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 352F);
            this.C_R10_T06.Multiline = true;
            this.C_R10_T06.Name = "C_R10_T06";
            this.C_R10_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T06.StylePriority.UseFont = false;
            this.C_R10_T06.Text = "";
            this.C_R10_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T06.WordWrap = false;
            // 
            // C_R10_T07
            // 
            this.C_R10_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T07.BorderWidth = 0.5F;
            this.C_R10_T07.CanGrow = false;
            this.C_R10_T07.Dpi = 100F;
            this.C_R10_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 352F);
            this.C_R10_T07.Multiline = true;
            this.C_R10_T07.Name = "C_R10_T07";
            this.C_R10_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T07.StylePriority.UseFont = false;
            this.C_R10_T07.Text = "";
            this.C_R10_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T07.WordWrap = false;
            // 
            // C_R10_T08
            // 
            this.C_R10_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T08.BorderWidth = 0.5F;
            this.C_R10_T08.CanGrow = false;
            this.C_R10_T08.Dpi = 100F;
            this.C_R10_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 352F);
            this.C_R10_T08.Multiline = true;
            this.C_R10_T08.Name = "C_R10_T08";
            this.C_R10_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T08.StylePriority.UseFont = false;
            this.C_R10_T08.Text = "";
            this.C_R10_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T08.WordWrap = false;
            // 
            // C_R10_T09
            // 
            this.C_R10_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T09.BorderWidth = 0.5F;
            this.C_R10_T09.CanGrow = false;
            this.C_R10_T09.Dpi = 100F;
            this.C_R10_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 352F);
            this.C_R10_T09.Multiline = true;
            this.C_R10_T09.Name = "C_R10_T09";
            this.C_R10_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T09.StylePriority.UseFont = false;
            this.C_R10_T09.Text = "";
            this.C_R10_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T09.WordWrap = false;
            // 
            // C_R10_T10
            // 
            this.C_R10_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T10.BorderWidth = 0.5F;
            this.C_R10_T10.CanGrow = false;
            this.C_R10_T10.Dpi = 100F;
            this.C_R10_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 352F);
            this.C_R10_T10.Multiline = true;
            this.C_R10_T10.Name = "C_R10_T10";
            this.C_R10_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T10.StylePriority.UseFont = false;
            this.C_R10_T10.Text = "";
            this.C_R10_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T10.WordWrap = false;
            // 
            // C_R10_T11
            // 
            this.C_R10_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T11.BorderWidth = 0.5F;
            this.C_R10_T11.CanGrow = false;
            this.C_R10_T11.Dpi = 100F;
            this.C_R10_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 352F);
            this.C_R10_T11.Multiline = true;
            this.C_R10_T11.Name = "C_R10_T11";
            this.C_R10_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T11.StylePriority.UseFont = false;
            this.C_R10_T11.Text = "";
            this.C_R10_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T11.WordWrap = false;
            // 
            // C_R10_T12
            // 
            this.C_R10_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R10_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_T12.BorderWidth = 0.5F;
            this.C_R10_T12.CanGrow = false;
            this.C_R10_T12.Dpi = 100F;
            this.C_R10_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 352F);
            this.C_R10_T12.Multiline = true;
            this.C_R10_T12.Name = "C_R10_T12";
            this.C_R10_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R10_T12.StylePriority.UseFont = false;
            this.C_R10_T12.Text = "";
            this.C_R10_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_T12.WordWrap = false;
            // 
            // C_R11_PRC
            // 
            this.C_R11_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R11_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_PRC.BorderWidth = 0.5F;
            this.C_R11_PRC.CanGrow = false;
            this.C_R11_PRC.Dpi = 100F;
            this.C_R11_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 374F);
            this.C_R11_PRC.Multiline = true;
            this.C_R11_PRC.Name = "C_R11_PRC";
            this.C_R11_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R11_PRC.StylePriority.UseFont = false;
            this.C_R11_PRC.Text = "";
            this.C_R11_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_PRC.WordWrap = false;
            // 
            // C_R11_STD
            // 
            this.C_R11_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R11_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_STD.BorderWidth = 0.5F;
            this.C_R11_STD.CanGrow = false;
            this.C_R11_STD.Dpi = 100F;
            this.C_R11_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 374F);
            this.C_R11_STD.Multiline = true;
            this.C_R11_STD.Name = "C_R11_STD";
            this.C_R11_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R11_STD.StylePriority.UseFont = false;
            this.C_R11_STD.Text = "";
            this.C_R11_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_STD.WordWrap = true;
            // 
            // C_R11_FEAT
            // 
            this.C_R11_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R11_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_FEAT.BorderWidth = 0.5F;
            this.C_R11_FEAT.CanGrow = false;
            this.C_R11_FEAT.Dpi = 100F;
            this.C_R11_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 374F);
            this.C_R11_FEAT.Multiline = true;
            this.C_R11_FEAT.Name = "C_R11_FEAT";
            this.C_R11_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R11_FEAT.StylePriority.UseFont = false;
            this.C_R11_FEAT.Text = "";
            this.C_R11_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_FEAT.WordWrap = false;
            // 
            // C_R11_SPEC
            // 
            this.C_R11_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R11_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_SPEC.BorderWidth = 0.5F;
            this.C_R11_SPEC.CanGrow = false;
            this.C_R11_SPEC.Dpi = 100F;
            this.C_R11_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 374F);
            this.C_R11_SPEC.Multiline = true;
            this.C_R11_SPEC.Name = "C_R11_SPEC";
            this.C_R11_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R11_SPEC.StylePriority.UseFont = false;
            this.C_R11_SPEC.Text = "";
            this.C_R11_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_SPEC.WordWrap = true;
            // 
            // C_R11_CYCLE
            // 
            this.C_R11_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R11_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_CYCLE.BorderWidth = 0.5F;
            this.C_R11_CYCLE.CanGrow = false;
            this.C_R11_CYCLE.Dpi = 100F;
            this.C_R11_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 374F);
            this.C_R11_CYCLE.Multiline = true;
            this.C_R11_CYCLE.Name = "C_R11_CYCLE";
            this.C_R11_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R11_CYCLE.StylePriority.UseFont = false;
            this.C_R11_CYCLE.Text = "";
            this.C_R11_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_CYCLE.WordWrap = true;
            // 
            // C_R11_GAUGE
            // 
            this.C_R11_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R11_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_GAUGE.BorderWidth = 0.5F;
            this.C_R11_GAUGE.CanGrow = false;
            this.C_R11_GAUGE.Dpi = 100F;
            this.C_R11_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 374F);
            this.C_R11_GAUGE.Multiline = true;
            this.C_R11_GAUGE.Name = "C_R11_GAUGE";
            this.C_R11_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R11_GAUGE.StylePriority.UseFont = false;
            this.C_R11_GAUGE.Text = "";
            this.C_R11_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_GAUGE.WordWrap = true;
            // 
            // C_R11_NO
            // 
            this.C_R11_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R11_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_NO.BorderWidth = 0.5F;
            this.C_R11_NO.CanGrow = false;
            this.C_R11_NO.Dpi = 100F;
            this.C_R11_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 374F);
            this.C_R11_NO.Multiline = true;
            this.C_R11_NO.Name = "C_R11_NO";
            this.C_R11_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R11_NO.StylePriority.UseFont = false;
            this.C_R11_NO.Text = "";
            this.C_R11_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_NO.WordWrap = false;
            // 
            // C_R11_T01
            // 
            this.C_R11_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T01.BorderWidth = 0.5F;
            this.C_R11_T01.CanGrow = false;
            this.C_R11_T01.Dpi = 100F;
            this.C_R11_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 374F);
            this.C_R11_T01.Multiline = true;
            this.C_R11_T01.Name = "C_R11_T01";
            this.C_R11_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T01.StylePriority.UseFont = false;
            this.C_R11_T01.Text = "";
            this.C_R11_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T01.WordWrap = false;
            // 
            // C_R11_T02
            // 
            this.C_R11_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T02.BorderWidth = 0.5F;
            this.C_R11_T02.CanGrow = false;
            this.C_R11_T02.Dpi = 100F;
            this.C_R11_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 374F);
            this.C_R11_T02.Multiline = true;
            this.C_R11_T02.Name = "C_R11_T02";
            this.C_R11_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T02.StylePriority.UseFont = false;
            this.C_R11_T02.Text = "";
            this.C_R11_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T02.WordWrap = false;
            // 
            // C_R11_T03
            // 
            this.C_R11_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T03.BorderWidth = 0.5F;
            this.C_R11_T03.CanGrow = false;
            this.C_R11_T03.Dpi = 100F;
            this.C_R11_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 374F);
            this.C_R11_T03.Multiline = true;
            this.C_R11_T03.Name = "C_R11_T03";
            this.C_R11_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T03.StylePriority.UseFont = false;
            this.C_R11_T03.Text = "";
            this.C_R11_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T03.WordWrap = false;
            // 
            // C_R11_T04
            // 
            this.C_R11_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T04.BorderWidth = 0.5F;
            this.C_R11_T04.CanGrow = false;
            this.C_R11_T04.Dpi = 100F;
            this.C_R11_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 374F);
            this.C_R11_T04.Multiline = true;
            this.C_R11_T04.Name = "C_R11_T04";
            this.C_R11_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T04.StylePriority.UseFont = false;
            this.C_R11_T04.Text = "";
            this.C_R11_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T04.WordWrap = false;
            // 
            // C_R11_T05
            // 
            this.C_R11_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T05.BorderWidth = 0.5F;
            this.C_R11_T05.CanGrow = false;
            this.C_R11_T05.Dpi = 100F;
            this.C_R11_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 374F);
            this.C_R11_T05.Multiline = true;
            this.C_R11_T05.Name = "C_R11_T05";
            this.C_R11_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T05.StylePriority.UseFont = false;
            this.C_R11_T05.Text = "";
            this.C_R11_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T05.WordWrap = false;
            // 
            // C_R11_T06
            // 
            this.C_R11_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T06.BorderWidth = 0.5F;
            this.C_R11_T06.CanGrow = false;
            this.C_R11_T06.Dpi = 100F;
            this.C_R11_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 374F);
            this.C_R11_T06.Multiline = true;
            this.C_R11_T06.Name = "C_R11_T06";
            this.C_R11_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T06.StylePriority.UseFont = false;
            this.C_R11_T06.Text = "";
            this.C_R11_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T06.WordWrap = false;
            // 
            // C_R11_T07
            // 
            this.C_R11_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T07.BorderWidth = 0.5F;
            this.C_R11_T07.CanGrow = false;
            this.C_R11_T07.Dpi = 100F;
            this.C_R11_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 374F);
            this.C_R11_T07.Multiline = true;
            this.C_R11_T07.Name = "C_R11_T07";
            this.C_R11_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T07.StylePriority.UseFont = false;
            this.C_R11_T07.Text = "";
            this.C_R11_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T07.WordWrap = false;
            // 
            // C_R11_T08
            // 
            this.C_R11_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T08.BorderWidth = 0.5F;
            this.C_R11_T08.CanGrow = false;
            this.C_R11_T08.Dpi = 100F;
            this.C_R11_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 374F);
            this.C_R11_T08.Multiline = true;
            this.C_R11_T08.Name = "C_R11_T08";
            this.C_R11_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T08.StylePriority.UseFont = false;
            this.C_R11_T08.Text = "";
            this.C_R11_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T08.WordWrap = false;
            // 
            // C_R11_T09
            // 
            this.C_R11_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T09.BorderWidth = 0.5F;
            this.C_R11_T09.CanGrow = false;
            this.C_R11_T09.Dpi = 100F;
            this.C_R11_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 374F);
            this.C_R11_T09.Multiline = true;
            this.C_R11_T09.Name = "C_R11_T09";
            this.C_R11_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T09.StylePriority.UseFont = false;
            this.C_R11_T09.Text = "";
            this.C_R11_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T09.WordWrap = false;
            // 
            // C_R11_T10
            // 
            this.C_R11_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T10.BorderWidth = 0.5F;
            this.C_R11_T10.CanGrow = false;
            this.C_R11_T10.Dpi = 100F;
            this.C_R11_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 374F);
            this.C_R11_T10.Multiline = true;
            this.C_R11_T10.Name = "C_R11_T10";
            this.C_R11_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T10.StylePriority.UseFont = false;
            this.C_R11_T10.Text = "";
            this.C_R11_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T10.WordWrap = false;
            // 
            // C_R11_T11
            // 
            this.C_R11_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T11.BorderWidth = 0.5F;
            this.C_R11_T11.CanGrow = false;
            this.C_R11_T11.Dpi = 100F;
            this.C_R11_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 374F);
            this.C_R11_T11.Multiline = true;
            this.C_R11_T11.Name = "C_R11_T11";
            this.C_R11_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T11.StylePriority.UseFont = false;
            this.C_R11_T11.Text = "";
            this.C_R11_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T11.WordWrap = false;
            // 
            // C_R11_T12
            // 
            this.C_R11_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R11_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_T12.BorderWidth = 0.5F;
            this.C_R11_T12.CanGrow = false;
            this.C_R11_T12.Dpi = 100F;
            this.C_R11_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 374F);
            this.C_R11_T12.Multiline = true;
            this.C_R11_T12.Name = "C_R11_T12";
            this.C_R11_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R11_T12.StylePriority.UseFont = false;
            this.C_R11_T12.Text = "";
            this.C_R11_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_T12.WordWrap = false;
            // 
            // C_R12_PRC
            // 
            this.C_R12_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R12_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_PRC.BorderWidth = 0.5F;
            this.C_R12_PRC.CanGrow = false;
            this.C_R12_PRC.Dpi = 100F;
            this.C_R12_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 396F);
            this.C_R12_PRC.Multiline = true;
            this.C_R12_PRC.Name = "C_R12_PRC";
            this.C_R12_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R12_PRC.StylePriority.UseFont = false;
            this.C_R12_PRC.Text = "";
            this.C_R12_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_PRC.WordWrap = false;
            // 
            // C_R12_STD
            // 
            this.C_R12_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R12_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_STD.BorderWidth = 0.5F;
            this.C_R12_STD.CanGrow = false;
            this.C_R12_STD.Dpi = 100F;
            this.C_R12_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 396F);
            this.C_R12_STD.Multiline = true;
            this.C_R12_STD.Name = "C_R12_STD";
            this.C_R12_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R12_STD.StylePriority.UseFont = false;
            this.C_R12_STD.Text = "";
            this.C_R12_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_STD.WordWrap = true;
            // 
            // C_R12_FEAT
            // 
            this.C_R12_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R12_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_FEAT.BorderWidth = 0.5F;
            this.C_R12_FEAT.CanGrow = false;
            this.C_R12_FEAT.Dpi = 100F;
            this.C_R12_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 396F);
            this.C_R12_FEAT.Multiline = true;
            this.C_R12_FEAT.Name = "C_R12_FEAT";
            this.C_R12_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R12_FEAT.StylePriority.UseFont = false;
            this.C_R12_FEAT.Text = "";
            this.C_R12_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_FEAT.WordWrap = false;
            // 
            // C_R12_SPEC
            // 
            this.C_R12_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R12_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_SPEC.BorderWidth = 0.5F;
            this.C_R12_SPEC.CanGrow = false;
            this.C_R12_SPEC.Dpi = 100F;
            this.C_R12_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 396F);
            this.C_R12_SPEC.Multiline = true;
            this.C_R12_SPEC.Name = "C_R12_SPEC";
            this.C_R12_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R12_SPEC.StylePriority.UseFont = false;
            this.C_R12_SPEC.Text = "";
            this.C_R12_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_SPEC.WordWrap = true;
            // 
            // C_R12_CYCLE
            // 
            this.C_R12_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R12_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_CYCLE.BorderWidth = 0.5F;
            this.C_R12_CYCLE.CanGrow = false;
            this.C_R12_CYCLE.Dpi = 100F;
            this.C_R12_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 396F);
            this.C_R12_CYCLE.Multiline = true;
            this.C_R12_CYCLE.Name = "C_R12_CYCLE";
            this.C_R12_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R12_CYCLE.StylePriority.UseFont = false;
            this.C_R12_CYCLE.Text = "";
            this.C_R12_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_CYCLE.WordWrap = true;
            // 
            // C_R12_GAUGE
            // 
            this.C_R12_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R12_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_GAUGE.BorderWidth = 0.5F;
            this.C_R12_GAUGE.CanGrow = false;
            this.C_R12_GAUGE.Dpi = 100F;
            this.C_R12_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 396F);
            this.C_R12_GAUGE.Multiline = true;
            this.C_R12_GAUGE.Name = "C_R12_GAUGE";
            this.C_R12_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R12_GAUGE.StylePriority.UseFont = false;
            this.C_R12_GAUGE.Text = "";
            this.C_R12_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_GAUGE.WordWrap = true;
            // 
            // C_R12_NO
            // 
            this.C_R12_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R12_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_NO.BorderWidth = 0.5F;
            this.C_R12_NO.CanGrow = false;
            this.C_R12_NO.Dpi = 100F;
            this.C_R12_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 396F);
            this.C_R12_NO.Multiline = true;
            this.C_R12_NO.Name = "C_R12_NO";
            this.C_R12_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R12_NO.StylePriority.UseFont = false;
            this.C_R12_NO.Text = "";
            this.C_R12_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_NO.WordWrap = false;
            // 
            // C_R12_T01
            // 
            this.C_R12_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T01.BorderWidth = 0.5F;
            this.C_R12_T01.CanGrow = false;
            this.C_R12_T01.Dpi = 100F;
            this.C_R12_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 396F);
            this.C_R12_T01.Multiline = true;
            this.C_R12_T01.Name = "C_R12_T01";
            this.C_R12_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T01.StylePriority.UseFont = false;
            this.C_R12_T01.Text = "";
            this.C_R12_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T01.WordWrap = false;
            // 
            // C_R12_T02
            // 
            this.C_R12_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T02.BorderWidth = 0.5F;
            this.C_R12_T02.CanGrow = false;
            this.C_R12_T02.Dpi = 100F;
            this.C_R12_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 396F);
            this.C_R12_T02.Multiline = true;
            this.C_R12_T02.Name = "C_R12_T02";
            this.C_R12_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T02.StylePriority.UseFont = false;
            this.C_R12_T02.Text = "";
            this.C_R12_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T02.WordWrap = false;
            // 
            // C_R12_T03
            // 
            this.C_R12_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T03.BorderWidth = 0.5F;
            this.C_R12_T03.CanGrow = false;
            this.C_R12_T03.Dpi = 100F;
            this.C_R12_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 396F);
            this.C_R12_T03.Multiline = true;
            this.C_R12_T03.Name = "C_R12_T03";
            this.C_R12_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T03.StylePriority.UseFont = false;
            this.C_R12_T03.Text = "";
            this.C_R12_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T03.WordWrap = false;
            // 
            // C_R12_T04
            // 
            this.C_R12_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T04.BorderWidth = 0.5F;
            this.C_R12_T04.CanGrow = false;
            this.C_R12_T04.Dpi = 100F;
            this.C_R12_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 396F);
            this.C_R12_T04.Multiline = true;
            this.C_R12_T04.Name = "C_R12_T04";
            this.C_R12_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T04.StylePriority.UseFont = false;
            this.C_R12_T04.Text = "";
            this.C_R12_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T04.WordWrap = false;
            // 
            // C_R12_T05
            // 
            this.C_R12_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T05.BorderWidth = 0.5F;
            this.C_R12_T05.CanGrow = false;
            this.C_R12_T05.Dpi = 100F;
            this.C_R12_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 396F);
            this.C_R12_T05.Multiline = true;
            this.C_R12_T05.Name = "C_R12_T05";
            this.C_R12_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T05.StylePriority.UseFont = false;
            this.C_R12_T05.Text = "";
            this.C_R12_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T05.WordWrap = false;
            // 
            // C_R12_T06
            // 
            this.C_R12_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T06.BorderWidth = 0.5F;
            this.C_R12_T06.CanGrow = false;
            this.C_R12_T06.Dpi = 100F;
            this.C_R12_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 396F);
            this.C_R12_T06.Multiline = true;
            this.C_R12_T06.Name = "C_R12_T06";
            this.C_R12_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T06.StylePriority.UseFont = false;
            this.C_R12_T06.Text = "";
            this.C_R12_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T06.WordWrap = false;
            // 
            // C_R12_T07
            // 
            this.C_R12_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T07.BorderWidth = 0.5F;
            this.C_R12_T07.CanGrow = false;
            this.C_R12_T07.Dpi = 100F;
            this.C_R12_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 396F);
            this.C_R12_T07.Multiline = true;
            this.C_R12_T07.Name = "C_R12_T07";
            this.C_R12_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T07.StylePriority.UseFont = false;
            this.C_R12_T07.Text = "";
            this.C_R12_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T07.WordWrap = false;
            // 
            // C_R12_T08
            // 
            this.C_R12_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T08.BorderWidth = 0.5F;
            this.C_R12_T08.CanGrow = false;
            this.C_R12_T08.Dpi = 100F;
            this.C_R12_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 396F);
            this.C_R12_T08.Multiline = true;
            this.C_R12_T08.Name = "C_R12_T08";
            this.C_R12_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T08.StylePriority.UseFont = false;
            this.C_R12_T08.Text = "";
            this.C_R12_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T08.WordWrap = false;
            // 
            // C_R12_T09
            // 
            this.C_R12_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T09.BorderWidth = 0.5F;
            this.C_R12_T09.CanGrow = false;
            this.C_R12_T09.Dpi = 100F;
            this.C_R12_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 396F);
            this.C_R12_T09.Multiline = true;
            this.C_R12_T09.Name = "C_R12_T09";
            this.C_R12_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T09.StylePriority.UseFont = false;
            this.C_R12_T09.Text = "";
            this.C_R12_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T09.WordWrap = false;
            // 
            // C_R12_T10
            // 
            this.C_R12_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T10.BorderWidth = 0.5F;
            this.C_R12_T10.CanGrow = false;
            this.C_R12_T10.Dpi = 100F;
            this.C_R12_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 396F);
            this.C_R12_T10.Multiline = true;
            this.C_R12_T10.Name = "C_R12_T10";
            this.C_R12_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T10.StylePriority.UseFont = false;
            this.C_R12_T10.Text = "";
            this.C_R12_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T10.WordWrap = false;
            // 
            // C_R12_T11
            // 
            this.C_R12_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T11.BorderWidth = 0.5F;
            this.C_R12_T11.CanGrow = false;
            this.C_R12_T11.Dpi = 100F;
            this.C_R12_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 396F);
            this.C_R12_T11.Multiline = true;
            this.C_R12_T11.Name = "C_R12_T11";
            this.C_R12_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T11.StylePriority.UseFont = false;
            this.C_R12_T11.Text = "";
            this.C_R12_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T11.WordWrap = false;
            // 
            // C_R12_T12
            // 
            this.C_R12_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R12_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_T12.BorderWidth = 0.5F;
            this.C_R12_T12.CanGrow = false;
            this.C_R12_T12.Dpi = 100F;
            this.C_R12_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 396F);
            this.C_R12_T12.Multiline = true;
            this.C_R12_T12.Name = "C_R12_T12";
            this.C_R12_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R12_T12.StylePriority.UseFont = false;
            this.C_R12_T12.Text = "";
            this.C_R12_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_T12.WordWrap = false;
            // 
            // C_R13_PRC
            // 
            this.C_R13_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R13_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_PRC.BorderWidth = 0.5F;
            this.C_R13_PRC.CanGrow = false;
            this.C_R13_PRC.Dpi = 100F;
            this.C_R13_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 418F);
            this.C_R13_PRC.Multiline = true;
            this.C_R13_PRC.Name = "C_R13_PRC";
            this.C_R13_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R13_PRC.StylePriority.UseFont = false;
            this.C_R13_PRC.Text = "";
            this.C_R13_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_PRC.WordWrap = false;
            // 
            // C_R13_STD
            // 
            this.C_R13_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R13_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_STD.BorderWidth = 0.5F;
            this.C_R13_STD.CanGrow = false;
            this.C_R13_STD.Dpi = 100F;
            this.C_R13_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 418F);
            this.C_R13_STD.Multiline = true;
            this.C_R13_STD.Name = "C_R13_STD";
            this.C_R13_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R13_STD.StylePriority.UseFont = false;
            this.C_R13_STD.Text = "";
            this.C_R13_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_STD.WordWrap = true;
            // 
            // C_R13_FEAT
            // 
            this.C_R13_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R13_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_FEAT.BorderWidth = 0.5F;
            this.C_R13_FEAT.CanGrow = false;
            this.C_R13_FEAT.Dpi = 100F;
            this.C_R13_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 418F);
            this.C_R13_FEAT.Multiline = true;
            this.C_R13_FEAT.Name = "C_R13_FEAT";
            this.C_R13_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R13_FEAT.StylePriority.UseFont = false;
            this.C_R13_FEAT.Text = "";
            this.C_R13_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_FEAT.WordWrap = false;
            // 
            // C_R13_SPEC
            // 
            this.C_R13_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R13_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_SPEC.BorderWidth = 0.5F;
            this.C_R13_SPEC.CanGrow = false;
            this.C_R13_SPEC.Dpi = 100F;
            this.C_R13_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 418F);
            this.C_R13_SPEC.Multiline = true;
            this.C_R13_SPEC.Name = "C_R13_SPEC";
            this.C_R13_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R13_SPEC.StylePriority.UseFont = false;
            this.C_R13_SPEC.Text = "";
            this.C_R13_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_SPEC.WordWrap = true;
            // 
            // C_R13_CYCLE
            // 
            this.C_R13_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R13_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_CYCLE.BorderWidth = 0.5F;
            this.C_R13_CYCLE.CanGrow = false;
            this.C_R13_CYCLE.Dpi = 100F;
            this.C_R13_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 418F);
            this.C_R13_CYCLE.Multiline = true;
            this.C_R13_CYCLE.Name = "C_R13_CYCLE";
            this.C_R13_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R13_CYCLE.StylePriority.UseFont = false;
            this.C_R13_CYCLE.Text = "";
            this.C_R13_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_CYCLE.WordWrap = true;
            // 
            // C_R13_GAUGE
            // 
            this.C_R13_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R13_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_GAUGE.BorderWidth = 0.5F;
            this.C_R13_GAUGE.CanGrow = false;
            this.C_R13_GAUGE.Dpi = 100F;
            this.C_R13_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 418F);
            this.C_R13_GAUGE.Multiline = true;
            this.C_R13_GAUGE.Name = "C_R13_GAUGE";
            this.C_R13_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R13_GAUGE.StylePriority.UseFont = false;
            this.C_R13_GAUGE.Text = "";
            this.C_R13_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_GAUGE.WordWrap = true;
            // 
            // C_R13_NO
            // 
            this.C_R13_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R13_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_NO.BorderWidth = 0.5F;
            this.C_R13_NO.CanGrow = false;
            this.C_R13_NO.Dpi = 100F;
            this.C_R13_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 418F);
            this.C_R13_NO.Multiline = true;
            this.C_R13_NO.Name = "C_R13_NO";
            this.C_R13_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R13_NO.StylePriority.UseFont = false;
            this.C_R13_NO.Text = "";
            this.C_R13_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_NO.WordWrap = false;
            // 
            // C_R13_T01
            // 
            this.C_R13_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T01.BorderWidth = 0.5F;
            this.C_R13_T01.CanGrow = false;
            this.C_R13_T01.Dpi = 100F;
            this.C_R13_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 418F);
            this.C_R13_T01.Multiline = true;
            this.C_R13_T01.Name = "C_R13_T01";
            this.C_R13_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T01.StylePriority.UseFont = false;
            this.C_R13_T01.Text = "";
            this.C_R13_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T01.WordWrap = false;
            // 
            // C_R13_T02
            // 
            this.C_R13_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T02.BorderWidth = 0.5F;
            this.C_R13_T02.CanGrow = false;
            this.C_R13_T02.Dpi = 100F;
            this.C_R13_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 418F);
            this.C_R13_T02.Multiline = true;
            this.C_R13_T02.Name = "C_R13_T02";
            this.C_R13_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T02.StylePriority.UseFont = false;
            this.C_R13_T02.Text = "";
            this.C_R13_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T02.WordWrap = false;
            // 
            // C_R13_T03
            // 
            this.C_R13_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T03.BorderWidth = 0.5F;
            this.C_R13_T03.CanGrow = false;
            this.C_R13_T03.Dpi = 100F;
            this.C_R13_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 418F);
            this.C_R13_T03.Multiline = true;
            this.C_R13_T03.Name = "C_R13_T03";
            this.C_R13_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T03.StylePriority.UseFont = false;
            this.C_R13_T03.Text = "";
            this.C_R13_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T03.WordWrap = false;
            // 
            // C_R13_T04
            // 
            this.C_R13_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T04.BorderWidth = 0.5F;
            this.C_R13_T04.CanGrow = false;
            this.C_R13_T04.Dpi = 100F;
            this.C_R13_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 418F);
            this.C_R13_T04.Multiline = true;
            this.C_R13_T04.Name = "C_R13_T04";
            this.C_R13_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T04.StylePriority.UseFont = false;
            this.C_R13_T04.Text = "";
            this.C_R13_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T04.WordWrap = false;
            // 
            // C_R13_T05
            // 
            this.C_R13_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T05.BorderWidth = 0.5F;
            this.C_R13_T05.CanGrow = false;
            this.C_R13_T05.Dpi = 100F;
            this.C_R13_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 418F);
            this.C_R13_T05.Multiline = true;
            this.C_R13_T05.Name = "C_R13_T05";
            this.C_R13_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T05.StylePriority.UseFont = false;
            this.C_R13_T05.Text = "";
            this.C_R13_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T05.WordWrap = false;
            // 
            // C_R13_T06
            // 
            this.C_R13_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T06.BorderWidth = 0.5F;
            this.C_R13_T06.CanGrow = false;
            this.C_R13_T06.Dpi = 100F;
            this.C_R13_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 418F);
            this.C_R13_T06.Multiline = true;
            this.C_R13_T06.Name = "C_R13_T06";
            this.C_R13_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T06.StylePriority.UseFont = false;
            this.C_R13_T06.Text = "";
            this.C_R13_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T06.WordWrap = false;
            // 
            // C_R13_T07
            // 
            this.C_R13_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T07.BorderWidth = 0.5F;
            this.C_R13_T07.CanGrow = false;
            this.C_R13_T07.Dpi = 100F;
            this.C_R13_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 418F);
            this.C_R13_T07.Multiline = true;
            this.C_R13_T07.Name = "C_R13_T07";
            this.C_R13_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T07.StylePriority.UseFont = false;
            this.C_R13_T07.Text = "";
            this.C_R13_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T07.WordWrap = false;
            // 
            // C_R13_T08
            // 
            this.C_R13_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T08.BorderWidth = 0.5F;
            this.C_R13_T08.CanGrow = false;
            this.C_R13_T08.Dpi = 100F;
            this.C_R13_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 418F);
            this.C_R13_T08.Multiline = true;
            this.C_R13_T08.Name = "C_R13_T08";
            this.C_R13_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T08.StylePriority.UseFont = false;
            this.C_R13_T08.Text = "";
            this.C_R13_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T08.WordWrap = false;
            // 
            // C_R13_T09
            // 
            this.C_R13_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T09.BorderWidth = 0.5F;
            this.C_R13_T09.CanGrow = false;
            this.C_R13_T09.Dpi = 100F;
            this.C_R13_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 418F);
            this.C_R13_T09.Multiline = true;
            this.C_R13_T09.Name = "C_R13_T09";
            this.C_R13_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T09.StylePriority.UseFont = false;
            this.C_R13_T09.Text = "";
            this.C_R13_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T09.WordWrap = false;
            // 
            // C_R13_T10
            // 
            this.C_R13_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T10.BorderWidth = 0.5F;
            this.C_R13_T10.CanGrow = false;
            this.C_R13_T10.Dpi = 100F;
            this.C_R13_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 418F);
            this.C_R13_T10.Multiline = true;
            this.C_R13_T10.Name = "C_R13_T10";
            this.C_R13_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T10.StylePriority.UseFont = false;
            this.C_R13_T10.Text = "";
            this.C_R13_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T10.WordWrap = false;
            // 
            // C_R13_T11
            // 
            this.C_R13_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T11.BorderWidth = 0.5F;
            this.C_R13_T11.CanGrow = false;
            this.C_R13_T11.Dpi = 100F;
            this.C_R13_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 418F);
            this.C_R13_T11.Multiline = true;
            this.C_R13_T11.Name = "C_R13_T11";
            this.C_R13_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T11.StylePriority.UseFont = false;
            this.C_R13_T11.Text = "";
            this.C_R13_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T11.WordWrap = false;
            // 
            // C_R13_T12
            // 
            this.C_R13_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R13_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_T12.BorderWidth = 0.5F;
            this.C_R13_T12.CanGrow = false;
            this.C_R13_T12.Dpi = 100F;
            this.C_R13_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 418F);
            this.C_R13_T12.Multiline = true;
            this.C_R13_T12.Name = "C_R13_T12";
            this.C_R13_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R13_T12.StylePriority.UseFont = false;
            this.C_R13_T12.Text = "";
            this.C_R13_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_T12.WordWrap = false;
            // 
            // C_R14_PRC
            // 
            this.C_R14_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R14_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_PRC.BorderWidth = 0.5F;
            this.C_R14_PRC.CanGrow = false;
            this.C_R14_PRC.Dpi = 100F;
            this.C_R14_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 440F);
            this.C_R14_PRC.Multiline = true;
            this.C_R14_PRC.Name = "C_R14_PRC";
            this.C_R14_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R14_PRC.StylePriority.UseFont = false;
            this.C_R14_PRC.Text = "";
            this.C_R14_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_PRC.WordWrap = false;
            // 
            // C_R14_STD
            // 
            this.C_R14_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R14_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_STD.BorderWidth = 0.5F;
            this.C_R14_STD.CanGrow = false;
            this.C_R14_STD.Dpi = 100F;
            this.C_R14_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 440F);
            this.C_R14_STD.Multiline = true;
            this.C_R14_STD.Name = "C_R14_STD";
            this.C_R14_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R14_STD.StylePriority.UseFont = false;
            this.C_R14_STD.Text = "";
            this.C_R14_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_STD.WordWrap = true;
            // 
            // C_R14_FEAT
            // 
            this.C_R14_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R14_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_FEAT.BorderWidth = 0.5F;
            this.C_R14_FEAT.CanGrow = false;
            this.C_R14_FEAT.Dpi = 100F;
            this.C_R14_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 440F);
            this.C_R14_FEAT.Multiline = true;
            this.C_R14_FEAT.Name = "C_R14_FEAT";
            this.C_R14_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R14_FEAT.StylePriority.UseFont = false;
            this.C_R14_FEAT.Text = "";
            this.C_R14_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_FEAT.WordWrap = false;
            // 
            // C_R14_SPEC
            // 
            this.C_R14_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R14_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_SPEC.BorderWidth = 0.5F;
            this.C_R14_SPEC.CanGrow = false;
            this.C_R14_SPEC.Dpi = 100F;
            this.C_R14_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 440F);
            this.C_R14_SPEC.Multiline = true;
            this.C_R14_SPEC.Name = "C_R14_SPEC";
            this.C_R14_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R14_SPEC.StylePriority.UseFont = false;
            this.C_R14_SPEC.Text = "";
            this.C_R14_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_SPEC.WordWrap = true;
            // 
            // C_R14_CYCLE
            // 
            this.C_R14_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R14_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_CYCLE.BorderWidth = 0.5F;
            this.C_R14_CYCLE.CanGrow = false;
            this.C_R14_CYCLE.Dpi = 100F;
            this.C_R14_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 440F);
            this.C_R14_CYCLE.Multiline = true;
            this.C_R14_CYCLE.Name = "C_R14_CYCLE";
            this.C_R14_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R14_CYCLE.StylePriority.UseFont = false;
            this.C_R14_CYCLE.Text = "";
            this.C_R14_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_CYCLE.WordWrap = true;
            // 
            // C_R14_GAUGE
            // 
            this.C_R14_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R14_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_GAUGE.BorderWidth = 0.5F;
            this.C_R14_GAUGE.CanGrow = false;
            this.C_R14_GAUGE.Dpi = 100F;
            this.C_R14_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 440F);
            this.C_R14_GAUGE.Multiline = true;
            this.C_R14_GAUGE.Name = "C_R14_GAUGE";
            this.C_R14_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R14_GAUGE.StylePriority.UseFont = false;
            this.C_R14_GAUGE.Text = "";
            this.C_R14_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_GAUGE.WordWrap = true;
            // 
            // C_R14_NO
            // 
            this.C_R14_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R14_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_NO.BorderWidth = 0.5F;
            this.C_R14_NO.CanGrow = false;
            this.C_R14_NO.Dpi = 100F;
            this.C_R14_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 440F);
            this.C_R14_NO.Multiline = true;
            this.C_R14_NO.Name = "C_R14_NO";
            this.C_R14_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R14_NO.StylePriority.UseFont = false;
            this.C_R14_NO.Text = "";
            this.C_R14_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_NO.WordWrap = false;
            // 
            // C_R14_T01
            // 
            this.C_R14_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T01.BorderWidth = 0.5F;
            this.C_R14_T01.CanGrow = false;
            this.C_R14_T01.Dpi = 100F;
            this.C_R14_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 440F);
            this.C_R14_T01.Multiline = true;
            this.C_R14_T01.Name = "C_R14_T01";
            this.C_R14_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T01.StylePriority.UseFont = false;
            this.C_R14_T01.Text = "";
            this.C_R14_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T01.WordWrap = false;
            // 
            // C_R14_T02
            // 
            this.C_R14_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T02.BorderWidth = 0.5F;
            this.C_R14_T02.CanGrow = false;
            this.C_R14_T02.Dpi = 100F;
            this.C_R14_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 440F);
            this.C_R14_T02.Multiline = true;
            this.C_R14_T02.Name = "C_R14_T02";
            this.C_R14_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T02.StylePriority.UseFont = false;
            this.C_R14_T02.Text = "";
            this.C_R14_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T02.WordWrap = false;
            // 
            // C_R14_T03
            // 
            this.C_R14_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T03.BorderWidth = 0.5F;
            this.C_R14_T03.CanGrow = false;
            this.C_R14_T03.Dpi = 100F;
            this.C_R14_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 440F);
            this.C_R14_T03.Multiline = true;
            this.C_R14_T03.Name = "C_R14_T03";
            this.C_R14_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T03.StylePriority.UseFont = false;
            this.C_R14_T03.Text = "";
            this.C_R14_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T03.WordWrap = false;
            // 
            // C_R14_T04
            // 
            this.C_R14_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T04.BorderWidth = 0.5F;
            this.C_R14_T04.CanGrow = false;
            this.C_R14_T04.Dpi = 100F;
            this.C_R14_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 440F);
            this.C_R14_T04.Multiline = true;
            this.C_R14_T04.Name = "C_R14_T04";
            this.C_R14_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T04.StylePriority.UseFont = false;
            this.C_R14_T04.Text = "";
            this.C_R14_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T04.WordWrap = false;
            // 
            // C_R14_T05
            // 
            this.C_R14_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T05.BorderWidth = 0.5F;
            this.C_R14_T05.CanGrow = false;
            this.C_R14_T05.Dpi = 100F;
            this.C_R14_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 440F);
            this.C_R14_T05.Multiline = true;
            this.C_R14_T05.Name = "C_R14_T05";
            this.C_R14_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T05.StylePriority.UseFont = false;
            this.C_R14_T05.Text = "";
            this.C_R14_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T05.WordWrap = false;
            // 
            // C_R14_T06
            // 
            this.C_R14_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T06.BorderWidth = 0.5F;
            this.C_R14_T06.CanGrow = false;
            this.C_R14_T06.Dpi = 100F;
            this.C_R14_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 440F);
            this.C_R14_T06.Multiline = true;
            this.C_R14_T06.Name = "C_R14_T06";
            this.C_R14_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T06.StylePriority.UseFont = false;
            this.C_R14_T06.Text = "";
            this.C_R14_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T06.WordWrap = false;
            // 
            // C_R14_T07
            // 
            this.C_R14_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T07.BorderWidth = 0.5F;
            this.C_R14_T07.CanGrow = false;
            this.C_R14_T07.Dpi = 100F;
            this.C_R14_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 440F);
            this.C_R14_T07.Multiline = true;
            this.C_R14_T07.Name = "C_R14_T07";
            this.C_R14_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T07.StylePriority.UseFont = false;
            this.C_R14_T07.Text = "";
            this.C_R14_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T07.WordWrap = false;
            // 
            // C_R14_T08
            // 
            this.C_R14_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T08.BorderWidth = 0.5F;
            this.C_R14_T08.CanGrow = false;
            this.C_R14_T08.Dpi = 100F;
            this.C_R14_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 440F);
            this.C_R14_T08.Multiline = true;
            this.C_R14_T08.Name = "C_R14_T08";
            this.C_R14_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T08.StylePriority.UseFont = false;
            this.C_R14_T08.Text = "";
            this.C_R14_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T08.WordWrap = false;
            // 
            // C_R14_T09
            // 
            this.C_R14_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T09.BorderWidth = 0.5F;
            this.C_R14_T09.CanGrow = false;
            this.C_R14_T09.Dpi = 100F;
            this.C_R14_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 440F);
            this.C_R14_T09.Multiline = true;
            this.C_R14_T09.Name = "C_R14_T09";
            this.C_R14_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T09.StylePriority.UseFont = false;
            this.C_R14_T09.Text = "";
            this.C_R14_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T09.WordWrap = false;
            // 
            // C_R14_T10
            // 
            this.C_R14_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T10.BorderWidth = 0.5F;
            this.C_R14_T10.CanGrow = false;
            this.C_R14_T10.Dpi = 100F;
            this.C_R14_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 440F);
            this.C_R14_T10.Multiline = true;
            this.C_R14_T10.Name = "C_R14_T10";
            this.C_R14_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T10.StylePriority.UseFont = false;
            this.C_R14_T10.Text = "";
            this.C_R14_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T10.WordWrap = false;
            // 
            // C_R14_T11
            // 
            this.C_R14_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T11.BorderWidth = 0.5F;
            this.C_R14_T11.CanGrow = false;
            this.C_R14_T11.Dpi = 100F;
            this.C_R14_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 440F);
            this.C_R14_T11.Multiline = true;
            this.C_R14_T11.Name = "C_R14_T11";
            this.C_R14_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T11.StylePriority.UseFont = false;
            this.C_R14_T11.Text = "";
            this.C_R14_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T11.WordWrap = false;
            // 
            // C_R14_T12
            // 
            this.C_R14_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R14_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_T12.BorderWidth = 0.5F;
            this.C_R14_T12.CanGrow = false;
            this.C_R14_T12.Dpi = 100F;
            this.C_R14_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 440F);
            this.C_R14_T12.Multiline = true;
            this.C_R14_T12.Name = "C_R14_T12";
            this.C_R14_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R14_T12.StylePriority.UseFont = false;
            this.C_R14_T12.Text = "";
            this.C_R14_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_T12.WordWrap = false;
            // 
            // C_R15_PRC
            // 
            this.C_R15_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R15_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_PRC.BorderWidth = 0.5F;
            this.C_R15_PRC.CanGrow = false;
            this.C_R15_PRC.Dpi = 100F;
            this.C_R15_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 462F);
            this.C_R15_PRC.Multiline = true;
            this.C_R15_PRC.Name = "C_R15_PRC";
            this.C_R15_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R15_PRC.StylePriority.UseFont = false;
            this.C_R15_PRC.Text = "";
            this.C_R15_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_PRC.WordWrap = false;
            // 
            // C_R15_STD
            // 
            this.C_R15_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R15_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_STD.BorderWidth = 0.5F;
            this.C_R15_STD.CanGrow = false;
            this.C_R15_STD.Dpi = 100F;
            this.C_R15_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 462F);
            this.C_R15_STD.Multiline = true;
            this.C_R15_STD.Name = "C_R15_STD";
            this.C_R15_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R15_STD.StylePriority.UseFont = false;
            this.C_R15_STD.Text = "";
            this.C_R15_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_STD.WordWrap = true;
            // 
            // C_R15_FEAT
            // 
            this.C_R15_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R15_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_FEAT.BorderWidth = 0.5F;
            this.C_R15_FEAT.CanGrow = false;
            this.C_R15_FEAT.Dpi = 100F;
            this.C_R15_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 462F);
            this.C_R15_FEAT.Multiline = true;
            this.C_R15_FEAT.Name = "C_R15_FEAT";
            this.C_R15_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R15_FEAT.StylePriority.UseFont = false;
            this.C_R15_FEAT.Text = "";
            this.C_R15_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_FEAT.WordWrap = false;
            // 
            // C_R15_SPEC
            // 
            this.C_R15_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R15_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_SPEC.BorderWidth = 0.5F;
            this.C_R15_SPEC.CanGrow = false;
            this.C_R15_SPEC.Dpi = 100F;
            this.C_R15_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 462F);
            this.C_R15_SPEC.Multiline = true;
            this.C_R15_SPEC.Name = "C_R15_SPEC";
            this.C_R15_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R15_SPEC.StylePriority.UseFont = false;
            this.C_R15_SPEC.Text = "";
            this.C_R15_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_SPEC.WordWrap = true;
            // 
            // C_R15_CYCLE
            // 
            this.C_R15_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R15_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_CYCLE.BorderWidth = 0.5F;
            this.C_R15_CYCLE.CanGrow = false;
            this.C_R15_CYCLE.Dpi = 100F;
            this.C_R15_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 462F);
            this.C_R15_CYCLE.Multiline = true;
            this.C_R15_CYCLE.Name = "C_R15_CYCLE";
            this.C_R15_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R15_CYCLE.StylePriority.UseFont = false;
            this.C_R15_CYCLE.Text = "";
            this.C_R15_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_CYCLE.WordWrap = true;
            // 
            // C_R15_GAUGE
            // 
            this.C_R15_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R15_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_GAUGE.BorderWidth = 0.5F;
            this.C_R15_GAUGE.CanGrow = false;
            this.C_R15_GAUGE.Dpi = 100F;
            this.C_R15_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 462F);
            this.C_R15_GAUGE.Multiline = true;
            this.C_R15_GAUGE.Name = "C_R15_GAUGE";
            this.C_R15_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R15_GAUGE.StylePriority.UseFont = false;
            this.C_R15_GAUGE.Text = "";
            this.C_R15_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_GAUGE.WordWrap = true;
            // 
            // C_R15_NO
            // 
            this.C_R15_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R15_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_NO.BorderWidth = 0.5F;
            this.C_R15_NO.CanGrow = false;
            this.C_R15_NO.Dpi = 100F;
            this.C_R15_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 462F);
            this.C_R15_NO.Multiline = true;
            this.C_R15_NO.Name = "C_R15_NO";
            this.C_R15_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R15_NO.StylePriority.UseFont = false;
            this.C_R15_NO.Text = "";
            this.C_R15_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_NO.WordWrap = false;
            // 
            // C_R15_T01
            // 
            this.C_R15_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T01.BorderWidth = 0.5F;
            this.C_R15_T01.CanGrow = false;
            this.C_R15_T01.Dpi = 100F;
            this.C_R15_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 462F);
            this.C_R15_T01.Multiline = true;
            this.C_R15_T01.Name = "C_R15_T01";
            this.C_R15_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T01.StylePriority.UseFont = false;
            this.C_R15_T01.Text = "";
            this.C_R15_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T01.WordWrap = false;
            // 
            // C_R15_T02
            // 
            this.C_R15_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T02.BorderWidth = 0.5F;
            this.C_R15_T02.CanGrow = false;
            this.C_R15_T02.Dpi = 100F;
            this.C_R15_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 462F);
            this.C_R15_T02.Multiline = true;
            this.C_R15_T02.Name = "C_R15_T02";
            this.C_R15_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T02.StylePriority.UseFont = false;
            this.C_R15_T02.Text = "";
            this.C_R15_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T02.WordWrap = false;
            // 
            // C_R15_T03
            // 
            this.C_R15_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T03.BorderWidth = 0.5F;
            this.C_R15_T03.CanGrow = false;
            this.C_R15_T03.Dpi = 100F;
            this.C_R15_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 462F);
            this.C_R15_T03.Multiline = true;
            this.C_R15_T03.Name = "C_R15_T03";
            this.C_R15_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T03.StylePriority.UseFont = false;
            this.C_R15_T03.Text = "";
            this.C_R15_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T03.WordWrap = false;
            // 
            // C_R15_T04
            // 
            this.C_R15_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T04.BorderWidth = 0.5F;
            this.C_R15_T04.CanGrow = false;
            this.C_R15_T04.Dpi = 100F;
            this.C_R15_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 462F);
            this.C_R15_T04.Multiline = true;
            this.C_R15_T04.Name = "C_R15_T04";
            this.C_R15_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T04.StylePriority.UseFont = false;
            this.C_R15_T04.Text = "";
            this.C_R15_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T04.WordWrap = false;
            // 
            // C_R15_T05
            // 
            this.C_R15_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T05.BorderWidth = 0.5F;
            this.C_R15_T05.CanGrow = false;
            this.C_R15_T05.Dpi = 100F;
            this.C_R15_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 462F);
            this.C_R15_T05.Multiline = true;
            this.C_R15_T05.Name = "C_R15_T05";
            this.C_R15_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T05.StylePriority.UseFont = false;
            this.C_R15_T05.Text = "";
            this.C_R15_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T05.WordWrap = false;
            // 
            // C_R15_T06
            // 
            this.C_R15_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T06.BorderWidth = 0.5F;
            this.C_R15_T06.CanGrow = false;
            this.C_R15_T06.Dpi = 100F;
            this.C_R15_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 462F);
            this.C_R15_T06.Multiline = true;
            this.C_R15_T06.Name = "C_R15_T06";
            this.C_R15_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T06.StylePriority.UseFont = false;
            this.C_R15_T06.Text = "";
            this.C_R15_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T06.WordWrap = false;
            // 
            // C_R15_T07
            // 
            this.C_R15_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T07.BorderWidth = 0.5F;
            this.C_R15_T07.CanGrow = false;
            this.C_R15_T07.Dpi = 100F;
            this.C_R15_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 462F);
            this.C_R15_T07.Multiline = true;
            this.C_R15_T07.Name = "C_R15_T07";
            this.C_R15_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T07.StylePriority.UseFont = false;
            this.C_R15_T07.Text = "";
            this.C_R15_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T07.WordWrap = false;
            // 
            // C_R15_T08
            // 
            this.C_R15_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T08.BorderWidth = 0.5F;
            this.C_R15_T08.CanGrow = false;
            this.C_R15_T08.Dpi = 100F;
            this.C_R15_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 462F);
            this.C_R15_T08.Multiline = true;
            this.C_R15_T08.Name = "C_R15_T08";
            this.C_R15_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T08.StylePriority.UseFont = false;
            this.C_R15_T08.Text = "";
            this.C_R15_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T08.WordWrap = false;
            // 
            // C_R15_T09
            // 
            this.C_R15_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T09.BorderWidth = 0.5F;
            this.C_R15_T09.CanGrow = false;
            this.C_R15_T09.Dpi = 100F;
            this.C_R15_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 462F);
            this.C_R15_T09.Multiline = true;
            this.C_R15_T09.Name = "C_R15_T09";
            this.C_R15_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T09.StylePriority.UseFont = false;
            this.C_R15_T09.Text = "";
            this.C_R15_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T09.WordWrap = false;
            // 
            // C_R15_T10
            // 
            this.C_R15_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T10.BorderWidth = 0.5F;
            this.C_R15_T10.CanGrow = false;
            this.C_R15_T10.Dpi = 100F;
            this.C_R15_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 462F);
            this.C_R15_T10.Multiline = true;
            this.C_R15_T10.Name = "C_R15_T10";
            this.C_R15_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T10.StylePriority.UseFont = false;
            this.C_R15_T10.Text = "";
            this.C_R15_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T10.WordWrap = false;
            // 
            // C_R15_T11
            // 
            this.C_R15_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T11.BorderWidth = 0.5F;
            this.C_R15_T11.CanGrow = false;
            this.C_R15_T11.Dpi = 100F;
            this.C_R15_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 462F);
            this.C_R15_T11.Multiline = true;
            this.C_R15_T11.Name = "C_R15_T11";
            this.C_R15_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T11.StylePriority.UseFont = false;
            this.C_R15_T11.Text = "";
            this.C_R15_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T11.WordWrap = false;
            // 
            // C_R15_T12
            // 
            this.C_R15_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R15_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_T12.BorderWidth = 0.5F;
            this.C_R15_T12.CanGrow = false;
            this.C_R15_T12.Dpi = 100F;
            this.C_R15_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 462F);
            this.C_R15_T12.Multiline = true;
            this.C_R15_T12.Name = "C_R15_T12";
            this.C_R15_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R15_T12.StylePriority.UseFont = false;
            this.C_R15_T12.Text = "";
            this.C_R15_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_T12.WordWrap = false;
            // 
            // C_R16_PRC
            // 
            this.C_R16_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R16_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_PRC.BorderWidth = 0.5F;
            this.C_R16_PRC.CanGrow = false;
            this.C_R16_PRC.Dpi = 100F;
            this.C_R16_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 484F);
            this.C_R16_PRC.Multiline = true;
            this.C_R16_PRC.Name = "C_R16_PRC";
            this.C_R16_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R16_PRC.StylePriority.UseFont = false;
            this.C_R16_PRC.Text = "";
            this.C_R16_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_PRC.WordWrap = false;
            // 
            // C_R16_STD
            // 
            this.C_R16_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R16_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_STD.BorderWidth = 0.5F;
            this.C_R16_STD.CanGrow = false;
            this.C_R16_STD.Dpi = 100F;
            this.C_R16_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 484F);
            this.C_R16_STD.Multiline = true;
            this.C_R16_STD.Name = "C_R16_STD";
            this.C_R16_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R16_STD.StylePriority.UseFont = false;
            this.C_R16_STD.Text = "";
            this.C_R16_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_STD.WordWrap = true;
            // 
            // C_R16_FEAT
            // 
            this.C_R16_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R16_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_FEAT.BorderWidth = 0.5F;
            this.C_R16_FEAT.CanGrow = false;
            this.C_R16_FEAT.Dpi = 100F;
            this.C_R16_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 484F);
            this.C_R16_FEAT.Multiline = true;
            this.C_R16_FEAT.Name = "C_R16_FEAT";
            this.C_R16_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R16_FEAT.StylePriority.UseFont = false;
            this.C_R16_FEAT.Text = "";
            this.C_R16_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_FEAT.WordWrap = false;
            // 
            // C_R16_SPEC
            // 
            this.C_R16_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R16_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_SPEC.BorderWidth = 0.5F;
            this.C_R16_SPEC.CanGrow = false;
            this.C_R16_SPEC.Dpi = 100F;
            this.C_R16_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 484F);
            this.C_R16_SPEC.Multiline = true;
            this.C_R16_SPEC.Name = "C_R16_SPEC";
            this.C_R16_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R16_SPEC.StylePriority.UseFont = false;
            this.C_R16_SPEC.Text = "";
            this.C_R16_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_SPEC.WordWrap = true;
            // 
            // C_R16_CYCLE
            // 
            this.C_R16_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R16_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_CYCLE.BorderWidth = 0.5F;
            this.C_R16_CYCLE.CanGrow = false;
            this.C_R16_CYCLE.Dpi = 100F;
            this.C_R16_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 484F);
            this.C_R16_CYCLE.Multiline = true;
            this.C_R16_CYCLE.Name = "C_R16_CYCLE";
            this.C_R16_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R16_CYCLE.StylePriority.UseFont = false;
            this.C_R16_CYCLE.Text = "";
            this.C_R16_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_CYCLE.WordWrap = true;
            // 
            // C_R16_GAUGE
            // 
            this.C_R16_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R16_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_GAUGE.BorderWidth = 0.5F;
            this.C_R16_GAUGE.CanGrow = false;
            this.C_R16_GAUGE.Dpi = 100F;
            this.C_R16_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 484F);
            this.C_R16_GAUGE.Multiline = true;
            this.C_R16_GAUGE.Name = "C_R16_GAUGE";
            this.C_R16_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R16_GAUGE.StylePriority.UseFont = false;
            this.C_R16_GAUGE.Text = "";
            this.C_R16_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_GAUGE.WordWrap = true;
            // 
            // C_R16_NO
            // 
            this.C_R16_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R16_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_NO.BorderWidth = 0.5F;
            this.C_R16_NO.CanGrow = false;
            this.C_R16_NO.Dpi = 100F;
            this.C_R16_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 484F);
            this.C_R16_NO.Multiline = true;
            this.C_R16_NO.Name = "C_R16_NO";
            this.C_R16_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R16_NO.StylePriority.UseFont = false;
            this.C_R16_NO.Text = "";
            this.C_R16_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_NO.WordWrap = false;
            // 
            // C_R16_T01
            // 
            this.C_R16_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T01.BorderWidth = 0.5F;
            this.C_R16_T01.CanGrow = false;
            this.C_R16_T01.Dpi = 100F;
            this.C_R16_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 484F);
            this.C_R16_T01.Multiline = true;
            this.C_R16_T01.Name = "C_R16_T01";
            this.C_R16_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T01.StylePriority.UseFont = false;
            this.C_R16_T01.Text = "";
            this.C_R16_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T01.WordWrap = false;
            // 
            // C_R16_T02
            // 
            this.C_R16_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T02.BorderWidth = 0.5F;
            this.C_R16_T02.CanGrow = false;
            this.C_R16_T02.Dpi = 100F;
            this.C_R16_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 484F);
            this.C_R16_T02.Multiline = true;
            this.C_R16_T02.Name = "C_R16_T02";
            this.C_R16_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T02.StylePriority.UseFont = false;
            this.C_R16_T02.Text = "";
            this.C_R16_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T02.WordWrap = false;
            // 
            // C_R16_T03
            // 
            this.C_R16_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T03.BorderWidth = 0.5F;
            this.C_R16_T03.CanGrow = false;
            this.C_R16_T03.Dpi = 100F;
            this.C_R16_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 484F);
            this.C_R16_T03.Multiline = true;
            this.C_R16_T03.Name = "C_R16_T03";
            this.C_R16_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T03.StylePriority.UseFont = false;
            this.C_R16_T03.Text = "";
            this.C_R16_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T03.WordWrap = false;
            // 
            // C_R16_T04
            // 
            this.C_R16_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T04.BorderWidth = 0.5F;
            this.C_R16_T04.CanGrow = false;
            this.C_R16_T04.Dpi = 100F;
            this.C_R16_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 484F);
            this.C_R16_T04.Multiline = true;
            this.C_R16_T04.Name = "C_R16_T04";
            this.C_R16_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T04.StylePriority.UseFont = false;
            this.C_R16_T04.Text = "";
            this.C_R16_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T04.WordWrap = false;
            // 
            // C_R16_T05
            // 
            this.C_R16_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T05.BorderWidth = 0.5F;
            this.C_R16_T05.CanGrow = false;
            this.C_R16_T05.Dpi = 100F;
            this.C_R16_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 484F);
            this.C_R16_T05.Multiline = true;
            this.C_R16_T05.Name = "C_R16_T05";
            this.C_R16_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T05.StylePriority.UseFont = false;
            this.C_R16_T05.Text = "";
            this.C_R16_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T05.WordWrap = false;
            // 
            // C_R16_T06
            // 
            this.C_R16_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T06.BorderWidth = 0.5F;
            this.C_R16_T06.CanGrow = false;
            this.C_R16_T06.Dpi = 100F;
            this.C_R16_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 484F);
            this.C_R16_T06.Multiline = true;
            this.C_R16_T06.Name = "C_R16_T06";
            this.C_R16_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T06.StylePriority.UseFont = false;
            this.C_R16_T06.Text = "";
            this.C_R16_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T06.WordWrap = false;
            // 
            // C_R16_T07
            // 
            this.C_R16_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T07.BorderWidth = 0.5F;
            this.C_R16_T07.CanGrow = false;
            this.C_R16_T07.Dpi = 100F;
            this.C_R16_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 484F);
            this.C_R16_T07.Multiline = true;
            this.C_R16_T07.Name = "C_R16_T07";
            this.C_R16_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T07.StylePriority.UseFont = false;
            this.C_R16_T07.Text = "";
            this.C_R16_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T07.WordWrap = false;
            // 
            // C_R16_T08
            // 
            this.C_R16_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T08.BorderWidth = 0.5F;
            this.C_R16_T08.CanGrow = false;
            this.C_R16_T08.Dpi = 100F;
            this.C_R16_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 484F);
            this.C_R16_T08.Multiline = true;
            this.C_R16_T08.Name = "C_R16_T08";
            this.C_R16_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T08.StylePriority.UseFont = false;
            this.C_R16_T08.Text = "";
            this.C_R16_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T08.WordWrap = false;
            // 
            // C_R16_T09
            // 
            this.C_R16_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T09.BorderWidth = 0.5F;
            this.C_R16_T09.CanGrow = false;
            this.C_R16_T09.Dpi = 100F;
            this.C_R16_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 484F);
            this.C_R16_T09.Multiline = true;
            this.C_R16_T09.Name = "C_R16_T09";
            this.C_R16_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T09.StylePriority.UseFont = false;
            this.C_R16_T09.Text = "";
            this.C_R16_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T09.WordWrap = false;
            // 
            // C_R16_T10
            // 
            this.C_R16_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T10.BorderWidth = 0.5F;
            this.C_R16_T10.CanGrow = false;
            this.C_R16_T10.Dpi = 100F;
            this.C_R16_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 484F);
            this.C_R16_T10.Multiline = true;
            this.C_R16_T10.Name = "C_R16_T10";
            this.C_R16_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T10.StylePriority.UseFont = false;
            this.C_R16_T10.Text = "";
            this.C_R16_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T10.WordWrap = false;
            // 
            // C_R16_T11
            // 
            this.C_R16_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T11.BorderWidth = 0.5F;
            this.C_R16_T11.CanGrow = false;
            this.C_R16_T11.Dpi = 100F;
            this.C_R16_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 484F);
            this.C_R16_T11.Multiline = true;
            this.C_R16_T11.Name = "C_R16_T11";
            this.C_R16_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T11.StylePriority.UseFont = false;
            this.C_R16_T11.Text = "";
            this.C_R16_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T11.WordWrap = false;
            // 
            // C_R16_T12
            // 
            this.C_R16_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R16_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_T12.BorderWidth = 0.5F;
            this.C_R16_T12.CanGrow = false;
            this.C_R16_T12.Dpi = 100F;
            this.C_R16_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 484F);
            this.C_R16_T12.Multiline = true;
            this.C_R16_T12.Name = "C_R16_T12";
            this.C_R16_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R16_T12.StylePriority.UseFont = false;
            this.C_R16_T12.Text = "";
            this.C_R16_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_T12.WordWrap = false;
            // 
            // C_R17_PRC
            // 
            this.C_R17_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R17_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_PRC.BorderWidth = 0.5F;
            this.C_R17_PRC.CanGrow = false;
            this.C_R17_PRC.Dpi = 100F;
            this.C_R17_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 506F);
            this.C_R17_PRC.Multiline = true;
            this.C_R17_PRC.Name = "C_R17_PRC";
            this.C_R17_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R17_PRC.StylePriority.UseFont = false;
            this.C_R17_PRC.Text = "";
            this.C_R17_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_PRC.WordWrap = false;
            // 
            // C_R17_STD
            // 
            this.C_R17_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R17_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_STD.BorderWidth = 0.5F;
            this.C_R17_STD.CanGrow = false;
            this.C_R17_STD.Dpi = 100F;
            this.C_R17_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 506F);
            this.C_R17_STD.Multiline = true;
            this.C_R17_STD.Name = "C_R17_STD";
            this.C_R17_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R17_STD.StylePriority.UseFont = false;
            this.C_R17_STD.Text = "";
            this.C_R17_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_STD.WordWrap = true;
            // 
            // C_R17_FEAT
            // 
            this.C_R17_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R17_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_FEAT.BorderWidth = 0.5F;
            this.C_R17_FEAT.CanGrow = false;
            this.C_R17_FEAT.Dpi = 100F;
            this.C_R17_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 506F);
            this.C_R17_FEAT.Multiline = true;
            this.C_R17_FEAT.Name = "C_R17_FEAT";
            this.C_R17_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R17_FEAT.StylePriority.UseFont = false;
            this.C_R17_FEAT.Text = "";
            this.C_R17_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_FEAT.WordWrap = false;
            // 
            // C_R17_SPEC
            // 
            this.C_R17_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R17_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_SPEC.BorderWidth = 0.5F;
            this.C_R17_SPEC.CanGrow = false;
            this.C_R17_SPEC.Dpi = 100F;
            this.C_R17_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 506F);
            this.C_R17_SPEC.Multiline = true;
            this.C_R17_SPEC.Name = "C_R17_SPEC";
            this.C_R17_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R17_SPEC.StylePriority.UseFont = false;
            this.C_R17_SPEC.Text = "";
            this.C_R17_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_SPEC.WordWrap = true;
            // 
            // C_R17_CYCLE
            // 
            this.C_R17_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R17_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_CYCLE.BorderWidth = 0.5F;
            this.C_R17_CYCLE.CanGrow = false;
            this.C_R17_CYCLE.Dpi = 100F;
            this.C_R17_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 506F);
            this.C_R17_CYCLE.Multiline = true;
            this.C_R17_CYCLE.Name = "C_R17_CYCLE";
            this.C_R17_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R17_CYCLE.StylePriority.UseFont = false;
            this.C_R17_CYCLE.Text = "";
            this.C_R17_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_CYCLE.WordWrap = true;
            // 
            // C_R17_GAUGE
            // 
            this.C_R17_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R17_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_GAUGE.BorderWidth = 0.5F;
            this.C_R17_GAUGE.CanGrow = false;
            this.C_R17_GAUGE.Dpi = 100F;
            this.C_R17_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 506F);
            this.C_R17_GAUGE.Multiline = true;
            this.C_R17_GAUGE.Name = "C_R17_GAUGE";
            this.C_R17_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R17_GAUGE.StylePriority.UseFont = false;
            this.C_R17_GAUGE.Text = "";
            this.C_R17_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_GAUGE.WordWrap = true;
            // 
            // C_R17_NO
            // 
            this.C_R17_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R17_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_NO.BorderWidth = 0.5F;
            this.C_R17_NO.CanGrow = false;
            this.C_R17_NO.Dpi = 100F;
            this.C_R17_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 506F);
            this.C_R17_NO.Multiline = true;
            this.C_R17_NO.Name = "C_R17_NO";
            this.C_R17_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R17_NO.StylePriority.UseFont = false;
            this.C_R17_NO.Text = "";
            this.C_R17_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_NO.WordWrap = false;
            // 
            // C_R17_T01
            // 
            this.C_R17_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T01.BorderWidth = 0.5F;
            this.C_R17_T01.CanGrow = false;
            this.C_R17_T01.Dpi = 100F;
            this.C_R17_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 506F);
            this.C_R17_T01.Multiline = true;
            this.C_R17_T01.Name = "C_R17_T01";
            this.C_R17_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T01.StylePriority.UseFont = false;
            this.C_R17_T01.Text = "";
            this.C_R17_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T01.WordWrap = false;
            // 
            // C_R17_T02
            // 
            this.C_R17_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T02.BorderWidth = 0.5F;
            this.C_R17_T02.CanGrow = false;
            this.C_R17_T02.Dpi = 100F;
            this.C_R17_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 506F);
            this.C_R17_T02.Multiline = true;
            this.C_R17_T02.Name = "C_R17_T02";
            this.C_R17_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T02.StylePriority.UseFont = false;
            this.C_R17_T02.Text = "";
            this.C_R17_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T02.WordWrap = false;
            // 
            // C_R17_T03
            // 
            this.C_R17_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T03.BorderWidth = 0.5F;
            this.C_R17_T03.CanGrow = false;
            this.C_R17_T03.Dpi = 100F;
            this.C_R17_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 506F);
            this.C_R17_T03.Multiline = true;
            this.C_R17_T03.Name = "C_R17_T03";
            this.C_R17_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T03.StylePriority.UseFont = false;
            this.C_R17_T03.Text = "";
            this.C_R17_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T03.WordWrap = false;
            // 
            // C_R17_T04
            // 
            this.C_R17_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T04.BorderWidth = 0.5F;
            this.C_R17_T04.CanGrow = false;
            this.C_R17_T04.Dpi = 100F;
            this.C_R17_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 506F);
            this.C_R17_T04.Multiline = true;
            this.C_R17_T04.Name = "C_R17_T04";
            this.C_R17_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T04.StylePriority.UseFont = false;
            this.C_R17_T04.Text = "";
            this.C_R17_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T04.WordWrap = false;
            // 
            // C_R17_T05
            // 
            this.C_R17_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T05.BorderWidth = 0.5F;
            this.C_R17_T05.CanGrow = false;
            this.C_R17_T05.Dpi = 100F;
            this.C_R17_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 506F);
            this.C_R17_T05.Multiline = true;
            this.C_R17_T05.Name = "C_R17_T05";
            this.C_R17_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T05.StylePriority.UseFont = false;
            this.C_R17_T05.Text = "";
            this.C_R17_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T05.WordWrap = false;
            // 
            // C_R17_T06
            // 
            this.C_R17_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T06.BorderWidth = 0.5F;
            this.C_R17_T06.CanGrow = false;
            this.C_R17_T06.Dpi = 100F;
            this.C_R17_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 506F);
            this.C_R17_T06.Multiline = true;
            this.C_R17_T06.Name = "C_R17_T06";
            this.C_R17_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T06.StylePriority.UseFont = false;
            this.C_R17_T06.Text = "";
            this.C_R17_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T06.WordWrap = false;
            // 
            // C_R17_T07
            // 
            this.C_R17_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T07.BorderWidth = 0.5F;
            this.C_R17_T07.CanGrow = false;
            this.C_R17_T07.Dpi = 100F;
            this.C_R17_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 506F);
            this.C_R17_T07.Multiline = true;
            this.C_R17_T07.Name = "C_R17_T07";
            this.C_R17_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T07.StylePriority.UseFont = false;
            this.C_R17_T07.Text = "";
            this.C_R17_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T07.WordWrap = false;
            // 
            // C_R17_T08
            // 
            this.C_R17_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T08.BorderWidth = 0.5F;
            this.C_R17_T08.CanGrow = false;
            this.C_R17_T08.Dpi = 100F;
            this.C_R17_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 506F);
            this.C_R17_T08.Multiline = true;
            this.C_R17_T08.Name = "C_R17_T08";
            this.C_R17_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T08.StylePriority.UseFont = false;
            this.C_R17_T08.Text = "";
            this.C_R17_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T08.WordWrap = false;
            // 
            // C_R17_T09
            // 
            this.C_R17_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T09.BorderWidth = 0.5F;
            this.C_R17_T09.CanGrow = false;
            this.C_R17_T09.Dpi = 100F;
            this.C_R17_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 506F);
            this.C_R17_T09.Multiline = true;
            this.C_R17_T09.Name = "C_R17_T09";
            this.C_R17_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T09.StylePriority.UseFont = false;
            this.C_R17_T09.Text = "";
            this.C_R17_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T09.WordWrap = false;
            // 
            // C_R17_T10
            // 
            this.C_R17_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T10.BorderWidth = 0.5F;
            this.C_R17_T10.CanGrow = false;
            this.C_R17_T10.Dpi = 100F;
            this.C_R17_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 506F);
            this.C_R17_T10.Multiline = true;
            this.C_R17_T10.Name = "C_R17_T10";
            this.C_R17_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T10.StylePriority.UseFont = false;
            this.C_R17_T10.Text = "";
            this.C_R17_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T10.WordWrap = false;
            // 
            // C_R17_T11
            // 
            this.C_R17_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T11.BorderWidth = 0.5F;
            this.C_R17_T11.CanGrow = false;
            this.C_R17_T11.Dpi = 100F;
            this.C_R17_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 506F);
            this.C_R17_T11.Multiline = true;
            this.C_R17_T11.Name = "C_R17_T11";
            this.C_R17_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T11.StylePriority.UseFont = false;
            this.C_R17_T11.Text = "";
            this.C_R17_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T11.WordWrap = false;
            // 
            // C_R17_T12
            // 
            this.C_R17_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R17_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_T12.BorderWidth = 0.5F;
            this.C_R17_T12.CanGrow = false;
            this.C_R17_T12.Dpi = 100F;
            this.C_R17_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 506F);
            this.C_R17_T12.Multiline = true;
            this.C_R17_T12.Name = "C_R17_T12";
            this.C_R17_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R17_T12.StylePriority.UseFont = false;
            this.C_R17_T12.Text = "";
            this.C_R17_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_T12.WordWrap = false;
            // 
            // C_R18_PRC
            // 
            this.C_R18_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R18_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_PRC.BorderWidth = 0.5F;
            this.C_R18_PRC.CanGrow = false;
            this.C_R18_PRC.Dpi = 100F;
            this.C_R18_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 528F);
            this.C_R18_PRC.Multiline = true;
            this.C_R18_PRC.Name = "C_R18_PRC";
            this.C_R18_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R18_PRC.StylePriority.UseFont = false;
            this.C_R18_PRC.Text = "";
            this.C_R18_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_PRC.WordWrap = false;
            // 
            // C_R18_STD
            // 
            this.C_R18_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R18_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_STD.BorderWidth = 0.5F;
            this.C_R18_STD.CanGrow = false;
            this.C_R18_STD.Dpi = 100F;
            this.C_R18_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 528F);
            this.C_R18_STD.Multiline = true;
            this.C_R18_STD.Name = "C_R18_STD";
            this.C_R18_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R18_STD.StylePriority.UseFont = false;
            this.C_R18_STD.Text = "";
            this.C_R18_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_STD.WordWrap = true;
            // 
            // C_R18_FEAT
            // 
            this.C_R18_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R18_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_FEAT.BorderWidth = 0.5F;
            this.C_R18_FEAT.CanGrow = false;
            this.C_R18_FEAT.Dpi = 100F;
            this.C_R18_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 528F);
            this.C_R18_FEAT.Multiline = true;
            this.C_R18_FEAT.Name = "C_R18_FEAT";
            this.C_R18_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R18_FEAT.StylePriority.UseFont = false;
            this.C_R18_FEAT.Text = "";
            this.C_R18_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_FEAT.WordWrap = false;
            // 
            // C_R18_SPEC
            // 
            this.C_R18_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R18_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_SPEC.BorderWidth = 0.5F;
            this.C_R18_SPEC.CanGrow = false;
            this.C_R18_SPEC.Dpi = 100F;
            this.C_R18_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 528F);
            this.C_R18_SPEC.Multiline = true;
            this.C_R18_SPEC.Name = "C_R18_SPEC";
            this.C_R18_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R18_SPEC.StylePriority.UseFont = false;
            this.C_R18_SPEC.Text = "";
            this.C_R18_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_SPEC.WordWrap = true;
            // 
            // C_R18_CYCLE
            // 
            this.C_R18_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R18_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_CYCLE.BorderWidth = 0.5F;
            this.C_R18_CYCLE.CanGrow = false;
            this.C_R18_CYCLE.Dpi = 100F;
            this.C_R18_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 528F);
            this.C_R18_CYCLE.Multiline = true;
            this.C_R18_CYCLE.Name = "C_R18_CYCLE";
            this.C_R18_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R18_CYCLE.StylePriority.UseFont = false;
            this.C_R18_CYCLE.Text = "";
            this.C_R18_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_CYCLE.WordWrap = true;
            // 
            // C_R18_GAUGE
            // 
            this.C_R18_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R18_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_GAUGE.BorderWidth = 0.5F;
            this.C_R18_GAUGE.CanGrow = false;
            this.C_R18_GAUGE.Dpi = 100F;
            this.C_R18_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 528F);
            this.C_R18_GAUGE.Multiline = true;
            this.C_R18_GAUGE.Name = "C_R18_GAUGE";
            this.C_R18_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R18_GAUGE.StylePriority.UseFont = false;
            this.C_R18_GAUGE.Text = "";
            this.C_R18_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_GAUGE.WordWrap = true;
            // 
            // C_R18_NO
            // 
            this.C_R18_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R18_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_NO.BorderWidth = 0.5F;
            this.C_R18_NO.CanGrow = false;
            this.C_R18_NO.Dpi = 100F;
            this.C_R18_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 528F);
            this.C_R18_NO.Multiline = true;
            this.C_R18_NO.Name = "C_R18_NO";
            this.C_R18_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R18_NO.StylePriority.UseFont = false;
            this.C_R18_NO.Text = "";
            this.C_R18_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_NO.WordWrap = false;
            // 
            // C_R18_T01
            // 
            this.C_R18_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T01.BorderWidth = 0.5F;
            this.C_R18_T01.CanGrow = false;
            this.C_R18_T01.Dpi = 100F;
            this.C_R18_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 528F);
            this.C_R18_T01.Multiline = true;
            this.C_R18_T01.Name = "C_R18_T01";
            this.C_R18_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T01.StylePriority.UseFont = false;
            this.C_R18_T01.Text = "";
            this.C_R18_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T01.WordWrap = false;
            // 
            // C_R18_T02
            // 
            this.C_R18_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T02.BorderWidth = 0.5F;
            this.C_R18_T02.CanGrow = false;
            this.C_R18_T02.Dpi = 100F;
            this.C_R18_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 528F);
            this.C_R18_T02.Multiline = true;
            this.C_R18_T02.Name = "C_R18_T02";
            this.C_R18_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T02.StylePriority.UseFont = false;
            this.C_R18_T02.Text = "";
            this.C_R18_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T02.WordWrap = false;
            // 
            // C_R18_T03
            // 
            this.C_R18_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T03.BorderWidth = 0.5F;
            this.C_R18_T03.CanGrow = false;
            this.C_R18_T03.Dpi = 100F;
            this.C_R18_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 528F);
            this.C_R18_T03.Multiline = true;
            this.C_R18_T03.Name = "C_R18_T03";
            this.C_R18_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T03.StylePriority.UseFont = false;
            this.C_R18_T03.Text = "";
            this.C_R18_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T03.WordWrap = false;
            // 
            // C_R18_T04
            // 
            this.C_R18_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T04.BorderWidth = 0.5F;
            this.C_R18_T04.CanGrow = false;
            this.C_R18_T04.Dpi = 100F;
            this.C_R18_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 528F);
            this.C_R18_T04.Multiline = true;
            this.C_R18_T04.Name = "C_R18_T04";
            this.C_R18_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T04.StylePriority.UseFont = false;
            this.C_R18_T04.Text = "";
            this.C_R18_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T04.WordWrap = false;
            // 
            // C_R18_T05
            // 
            this.C_R18_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T05.BorderWidth = 0.5F;
            this.C_R18_T05.CanGrow = false;
            this.C_R18_T05.Dpi = 100F;
            this.C_R18_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 528F);
            this.C_R18_T05.Multiline = true;
            this.C_R18_T05.Name = "C_R18_T05";
            this.C_R18_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T05.StylePriority.UseFont = false;
            this.C_R18_T05.Text = "";
            this.C_R18_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T05.WordWrap = false;
            // 
            // C_R18_T06
            // 
            this.C_R18_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T06.BorderWidth = 0.5F;
            this.C_R18_T06.CanGrow = false;
            this.C_R18_T06.Dpi = 100F;
            this.C_R18_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 528F);
            this.C_R18_T06.Multiline = true;
            this.C_R18_T06.Name = "C_R18_T06";
            this.C_R18_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T06.StylePriority.UseFont = false;
            this.C_R18_T06.Text = "";
            this.C_R18_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T06.WordWrap = false;
            // 
            // C_R18_T07
            // 
            this.C_R18_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T07.BorderWidth = 0.5F;
            this.C_R18_T07.CanGrow = false;
            this.C_R18_T07.Dpi = 100F;
            this.C_R18_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 528F);
            this.C_R18_T07.Multiline = true;
            this.C_R18_T07.Name = "C_R18_T07";
            this.C_R18_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T07.StylePriority.UseFont = false;
            this.C_R18_T07.Text = "";
            this.C_R18_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T07.WordWrap = false;
            // 
            // C_R18_T08
            // 
            this.C_R18_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T08.BorderWidth = 0.5F;
            this.C_R18_T08.CanGrow = false;
            this.C_R18_T08.Dpi = 100F;
            this.C_R18_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 528F);
            this.C_R18_T08.Multiline = true;
            this.C_R18_T08.Name = "C_R18_T08";
            this.C_R18_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T08.StylePriority.UseFont = false;
            this.C_R18_T08.Text = "";
            this.C_R18_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T08.WordWrap = false;
            // 
            // C_R18_T09
            // 
            this.C_R18_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T09.BorderWidth = 0.5F;
            this.C_R18_T09.CanGrow = false;
            this.C_R18_T09.Dpi = 100F;
            this.C_R18_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 528F);
            this.C_R18_T09.Multiline = true;
            this.C_R18_T09.Name = "C_R18_T09";
            this.C_R18_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T09.StylePriority.UseFont = false;
            this.C_R18_T09.Text = "";
            this.C_R18_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T09.WordWrap = false;
            // 
            // C_R18_T10
            // 
            this.C_R18_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T10.BorderWidth = 0.5F;
            this.C_R18_T10.CanGrow = false;
            this.C_R18_T10.Dpi = 100F;
            this.C_R18_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 528F);
            this.C_R18_T10.Multiline = true;
            this.C_R18_T10.Name = "C_R18_T10";
            this.C_R18_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T10.StylePriority.UseFont = false;
            this.C_R18_T10.Text = "";
            this.C_R18_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T10.WordWrap = false;
            // 
            // C_R18_T11
            // 
            this.C_R18_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T11.BorderWidth = 0.5F;
            this.C_R18_T11.CanGrow = false;
            this.C_R18_T11.Dpi = 100F;
            this.C_R18_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 528F);
            this.C_R18_T11.Multiline = true;
            this.C_R18_T11.Name = "C_R18_T11";
            this.C_R18_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T11.StylePriority.UseFont = false;
            this.C_R18_T11.Text = "";
            this.C_R18_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T11.WordWrap = false;
            // 
            // C_R18_T12
            // 
            this.C_R18_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R18_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_T12.BorderWidth = 0.5F;
            this.C_R18_T12.CanGrow = false;
            this.C_R18_T12.Dpi = 100F;
            this.C_R18_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 528F);
            this.C_R18_T12.Multiline = true;
            this.C_R18_T12.Name = "C_R18_T12";
            this.C_R18_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R18_T12.StylePriority.UseFont = false;
            this.C_R18_T12.Text = "";
            this.C_R18_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_T12.WordWrap = false;
            // 
            // C_R19_PRC
            // 
            this.C_R19_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R19_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_PRC.BorderWidth = 0.5F;
            this.C_R19_PRC.CanGrow = false;
            this.C_R19_PRC.Dpi = 100F;
            this.C_R19_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 550F);
            this.C_R19_PRC.Multiline = true;
            this.C_R19_PRC.Name = "C_R19_PRC";
            this.C_R19_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R19_PRC.StylePriority.UseFont = false;
            this.C_R19_PRC.Text = "";
            this.C_R19_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_PRC.WordWrap = false;
            // 
            // C_R19_STD
            // 
            this.C_R19_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R19_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_STD.BorderWidth = 0.5F;
            this.C_R19_STD.CanGrow = false;
            this.C_R19_STD.Dpi = 100F;
            this.C_R19_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 550F);
            this.C_R19_STD.Multiline = true;
            this.C_R19_STD.Name = "C_R19_STD";
            this.C_R19_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R19_STD.StylePriority.UseFont = false;
            this.C_R19_STD.Text = "";
            this.C_R19_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_STD.WordWrap = true;
            // 
            // C_R19_FEAT
            // 
            this.C_R19_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R19_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_FEAT.BorderWidth = 0.5F;
            this.C_R19_FEAT.CanGrow = false;
            this.C_R19_FEAT.Dpi = 100F;
            this.C_R19_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 550F);
            this.C_R19_FEAT.Multiline = true;
            this.C_R19_FEAT.Name = "C_R19_FEAT";
            this.C_R19_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R19_FEAT.StylePriority.UseFont = false;
            this.C_R19_FEAT.Text = "";
            this.C_R19_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_FEAT.WordWrap = false;
            // 
            // C_R19_SPEC
            // 
            this.C_R19_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R19_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_SPEC.BorderWidth = 0.5F;
            this.C_R19_SPEC.CanGrow = false;
            this.C_R19_SPEC.Dpi = 100F;
            this.C_R19_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 550F);
            this.C_R19_SPEC.Multiline = true;
            this.C_R19_SPEC.Name = "C_R19_SPEC";
            this.C_R19_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R19_SPEC.StylePriority.UseFont = false;
            this.C_R19_SPEC.Text = "";
            this.C_R19_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_SPEC.WordWrap = true;
            // 
            // C_R19_CYCLE
            // 
            this.C_R19_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R19_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_CYCLE.BorderWidth = 0.5F;
            this.C_R19_CYCLE.CanGrow = false;
            this.C_R19_CYCLE.Dpi = 100F;
            this.C_R19_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 550F);
            this.C_R19_CYCLE.Multiline = true;
            this.C_R19_CYCLE.Name = "C_R19_CYCLE";
            this.C_R19_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R19_CYCLE.StylePriority.UseFont = false;
            this.C_R19_CYCLE.Text = "";
            this.C_R19_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_CYCLE.WordWrap = true;
            // 
            // C_R19_GAUGE
            // 
            this.C_R19_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R19_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_GAUGE.BorderWidth = 0.5F;
            this.C_R19_GAUGE.CanGrow = false;
            this.C_R19_GAUGE.Dpi = 100F;
            this.C_R19_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 550F);
            this.C_R19_GAUGE.Multiline = true;
            this.C_R19_GAUGE.Name = "C_R19_GAUGE";
            this.C_R19_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R19_GAUGE.StylePriority.UseFont = false;
            this.C_R19_GAUGE.Text = "";
            this.C_R19_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_GAUGE.WordWrap = true;
            // 
            // C_R19_NO
            // 
            this.C_R19_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R19_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_NO.BorderWidth = 0.5F;
            this.C_R19_NO.CanGrow = false;
            this.C_R19_NO.Dpi = 100F;
            this.C_R19_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 550F);
            this.C_R19_NO.Multiline = true;
            this.C_R19_NO.Name = "C_R19_NO";
            this.C_R19_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R19_NO.StylePriority.UseFont = false;
            this.C_R19_NO.Text = "";
            this.C_R19_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_NO.WordWrap = false;
            // 
            // C_R19_T01
            // 
            this.C_R19_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T01.BorderWidth = 0.5F;
            this.C_R19_T01.CanGrow = false;
            this.C_R19_T01.Dpi = 100F;
            this.C_R19_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 550F);
            this.C_R19_T01.Multiline = true;
            this.C_R19_T01.Name = "C_R19_T01";
            this.C_R19_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T01.StylePriority.UseFont = false;
            this.C_R19_T01.Text = "";
            this.C_R19_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T01.WordWrap = false;
            // 
            // C_R19_T02
            // 
            this.C_R19_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T02.BorderWidth = 0.5F;
            this.C_R19_T02.CanGrow = false;
            this.C_R19_T02.Dpi = 100F;
            this.C_R19_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 550F);
            this.C_R19_T02.Multiline = true;
            this.C_R19_T02.Name = "C_R19_T02";
            this.C_R19_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T02.StylePriority.UseFont = false;
            this.C_R19_T02.Text = "";
            this.C_R19_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T02.WordWrap = false;
            // 
            // C_R19_T03
            // 
            this.C_R19_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T03.BorderWidth = 0.5F;
            this.C_R19_T03.CanGrow = false;
            this.C_R19_T03.Dpi = 100F;
            this.C_R19_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 550F);
            this.C_R19_T03.Multiline = true;
            this.C_R19_T03.Name = "C_R19_T03";
            this.C_R19_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T03.StylePriority.UseFont = false;
            this.C_R19_T03.Text = "";
            this.C_R19_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T03.WordWrap = false;
            // 
            // C_R19_T04
            // 
            this.C_R19_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T04.BorderWidth = 0.5F;
            this.C_R19_T04.CanGrow = false;
            this.C_R19_T04.Dpi = 100F;
            this.C_R19_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 550F);
            this.C_R19_T04.Multiline = true;
            this.C_R19_T04.Name = "C_R19_T04";
            this.C_R19_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T04.StylePriority.UseFont = false;
            this.C_R19_T04.Text = "";
            this.C_R19_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T04.WordWrap = false;
            // 
            // C_R19_T05
            // 
            this.C_R19_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T05.BorderWidth = 0.5F;
            this.C_R19_T05.CanGrow = false;
            this.C_R19_T05.Dpi = 100F;
            this.C_R19_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 550F);
            this.C_R19_T05.Multiline = true;
            this.C_R19_T05.Name = "C_R19_T05";
            this.C_R19_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T05.StylePriority.UseFont = false;
            this.C_R19_T05.Text = "";
            this.C_R19_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T05.WordWrap = false;
            // 
            // C_R19_T06
            // 
            this.C_R19_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T06.BorderWidth = 0.5F;
            this.C_R19_T06.CanGrow = false;
            this.C_R19_T06.Dpi = 100F;
            this.C_R19_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 550F);
            this.C_R19_T06.Multiline = true;
            this.C_R19_T06.Name = "C_R19_T06";
            this.C_R19_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T06.StylePriority.UseFont = false;
            this.C_R19_T06.Text = "";
            this.C_R19_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T06.WordWrap = false;
            // 
            // C_R19_T07
            // 
            this.C_R19_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T07.BorderWidth = 0.5F;
            this.C_R19_T07.CanGrow = false;
            this.C_R19_T07.Dpi = 100F;
            this.C_R19_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 550F);
            this.C_R19_T07.Multiline = true;
            this.C_R19_T07.Name = "C_R19_T07";
            this.C_R19_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T07.StylePriority.UseFont = false;
            this.C_R19_T07.Text = "";
            this.C_R19_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T07.WordWrap = false;
            // 
            // C_R19_T08
            // 
            this.C_R19_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T08.BorderWidth = 0.5F;
            this.C_R19_T08.CanGrow = false;
            this.C_R19_T08.Dpi = 100F;
            this.C_R19_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 550F);
            this.C_R19_T08.Multiline = true;
            this.C_R19_T08.Name = "C_R19_T08";
            this.C_R19_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T08.StylePriority.UseFont = false;
            this.C_R19_T08.Text = "";
            this.C_R19_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T08.WordWrap = false;
            // 
            // C_R19_T09
            // 
            this.C_R19_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T09.BorderWidth = 0.5F;
            this.C_R19_T09.CanGrow = false;
            this.C_R19_T09.Dpi = 100F;
            this.C_R19_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 550F);
            this.C_R19_T09.Multiline = true;
            this.C_R19_T09.Name = "C_R19_T09";
            this.C_R19_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T09.StylePriority.UseFont = false;
            this.C_R19_T09.Text = "";
            this.C_R19_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T09.WordWrap = false;
            // 
            // C_R19_T10
            // 
            this.C_R19_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T10.BorderWidth = 0.5F;
            this.C_R19_T10.CanGrow = false;
            this.C_R19_T10.Dpi = 100F;
            this.C_R19_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 550F);
            this.C_R19_T10.Multiline = true;
            this.C_R19_T10.Name = "C_R19_T10";
            this.C_R19_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T10.StylePriority.UseFont = false;
            this.C_R19_T10.Text = "";
            this.C_R19_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T10.WordWrap = false;
            // 
            // C_R19_T11
            // 
            this.C_R19_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T11.BorderWidth = 0.5F;
            this.C_R19_T11.CanGrow = false;
            this.C_R19_T11.Dpi = 100F;
            this.C_R19_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 550F);
            this.C_R19_T11.Multiline = true;
            this.C_R19_T11.Name = "C_R19_T11";
            this.C_R19_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T11.StylePriority.UseFont = false;
            this.C_R19_T11.Text = "";
            this.C_R19_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T11.WordWrap = false;
            // 
            // C_R19_T12
            // 
            this.C_R19_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R19_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_T12.BorderWidth = 0.5F;
            this.C_R19_T12.CanGrow = false;
            this.C_R19_T12.Dpi = 100F;
            this.C_R19_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 550F);
            this.C_R19_T12.Multiline = true;
            this.C_R19_T12.Name = "C_R19_T12";
            this.C_R19_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R19_T12.StylePriority.UseFont = false;
            this.C_R19_T12.Text = "";
            this.C_R19_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_T12.WordWrap = false;
            // 
            // C_R20_PRC
            // 
            this.C_R20_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R20_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_PRC.BorderWidth = 0.5F;
            this.C_R20_PRC.CanGrow = false;
            this.C_R20_PRC.Dpi = 100F;
            this.C_R20_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 572F);
            this.C_R20_PRC.Multiline = true;
            this.C_R20_PRC.Name = "C_R20_PRC";
            this.C_R20_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R20_PRC.StylePriority.UseFont = false;
            this.C_R20_PRC.Text = "";
            this.C_R20_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_PRC.WordWrap = false;
            // 
            // C_R20_STD
            // 
            this.C_R20_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R20_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_STD.BorderWidth = 0.5F;
            this.C_R20_STD.CanGrow = false;
            this.C_R20_STD.Dpi = 100F;
            this.C_R20_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 572F);
            this.C_R20_STD.Multiline = true;
            this.C_R20_STD.Name = "C_R20_STD";
            this.C_R20_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R20_STD.StylePriority.UseFont = false;
            this.C_R20_STD.Text = "";
            this.C_R20_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_STD.WordWrap = true;
            // 
            // C_R20_FEAT
            // 
            this.C_R20_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R20_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_FEAT.BorderWidth = 0.5F;
            this.C_R20_FEAT.CanGrow = false;
            this.C_R20_FEAT.Dpi = 100F;
            this.C_R20_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 572F);
            this.C_R20_FEAT.Multiline = true;
            this.C_R20_FEAT.Name = "C_R20_FEAT";
            this.C_R20_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R20_FEAT.StylePriority.UseFont = false;
            this.C_R20_FEAT.Text = "";
            this.C_R20_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_FEAT.WordWrap = false;
            // 
            // C_R20_SPEC
            // 
            this.C_R20_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R20_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_SPEC.BorderWidth = 0.5F;
            this.C_R20_SPEC.CanGrow = false;
            this.C_R20_SPEC.Dpi = 100F;
            this.C_R20_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 572F);
            this.C_R20_SPEC.Multiline = true;
            this.C_R20_SPEC.Name = "C_R20_SPEC";
            this.C_R20_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R20_SPEC.StylePriority.UseFont = false;
            this.C_R20_SPEC.Text = "";
            this.C_R20_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_SPEC.WordWrap = true;
            // 
            // C_R20_CYCLE
            // 
            this.C_R20_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R20_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_CYCLE.BorderWidth = 0.5F;
            this.C_R20_CYCLE.CanGrow = false;
            this.C_R20_CYCLE.Dpi = 100F;
            this.C_R20_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 572F);
            this.C_R20_CYCLE.Multiline = true;
            this.C_R20_CYCLE.Name = "C_R20_CYCLE";
            this.C_R20_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R20_CYCLE.StylePriority.UseFont = false;
            this.C_R20_CYCLE.Text = "";
            this.C_R20_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_CYCLE.WordWrap = true;
            // 
            // C_R20_GAUGE
            // 
            this.C_R20_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R20_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_GAUGE.BorderWidth = 0.5F;
            this.C_R20_GAUGE.CanGrow = false;
            this.C_R20_GAUGE.Dpi = 100F;
            this.C_R20_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 572F);
            this.C_R20_GAUGE.Multiline = true;
            this.C_R20_GAUGE.Name = "C_R20_GAUGE";
            this.C_R20_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R20_GAUGE.StylePriority.UseFont = false;
            this.C_R20_GAUGE.Text = "";
            this.C_R20_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_GAUGE.WordWrap = true;
            // 
            // C_R20_NO
            // 
            this.C_R20_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R20_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_NO.BorderWidth = 0.5F;
            this.C_R20_NO.CanGrow = false;
            this.C_R20_NO.Dpi = 100F;
            this.C_R20_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 572F);
            this.C_R20_NO.Multiline = true;
            this.C_R20_NO.Name = "C_R20_NO";
            this.C_R20_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R20_NO.StylePriority.UseFont = false;
            this.C_R20_NO.Text = "";
            this.C_R20_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_NO.WordWrap = false;
            // 
            // C_R20_T01
            // 
            this.C_R20_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T01.BorderWidth = 0.5F;
            this.C_R20_T01.CanGrow = false;
            this.C_R20_T01.Dpi = 100F;
            this.C_R20_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 572F);
            this.C_R20_T01.Multiline = true;
            this.C_R20_T01.Name = "C_R20_T01";
            this.C_R20_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T01.StylePriority.UseFont = false;
            this.C_R20_T01.Text = "";
            this.C_R20_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T01.WordWrap = false;
            // 
            // C_R20_T02
            // 
            this.C_R20_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T02.BorderWidth = 0.5F;
            this.C_R20_T02.CanGrow = false;
            this.C_R20_T02.Dpi = 100F;
            this.C_R20_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 572F);
            this.C_R20_T02.Multiline = true;
            this.C_R20_T02.Name = "C_R20_T02";
            this.C_R20_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T02.StylePriority.UseFont = false;
            this.C_R20_T02.Text = "";
            this.C_R20_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T02.WordWrap = false;
            // 
            // C_R20_T03
            // 
            this.C_R20_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T03.BorderWidth = 0.5F;
            this.C_R20_T03.CanGrow = false;
            this.C_R20_T03.Dpi = 100F;
            this.C_R20_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 572F);
            this.C_R20_T03.Multiline = true;
            this.C_R20_T03.Name = "C_R20_T03";
            this.C_R20_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T03.StylePriority.UseFont = false;
            this.C_R20_T03.Text = "";
            this.C_R20_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T03.WordWrap = false;
            // 
            // C_R20_T04
            // 
            this.C_R20_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T04.BorderWidth = 0.5F;
            this.C_R20_T04.CanGrow = false;
            this.C_R20_T04.Dpi = 100F;
            this.C_R20_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 572F);
            this.C_R20_T04.Multiline = true;
            this.C_R20_T04.Name = "C_R20_T04";
            this.C_R20_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T04.StylePriority.UseFont = false;
            this.C_R20_T04.Text = "";
            this.C_R20_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T04.WordWrap = false;
            // 
            // C_R20_T05
            // 
            this.C_R20_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T05.BorderWidth = 0.5F;
            this.C_R20_T05.CanGrow = false;
            this.C_R20_T05.Dpi = 100F;
            this.C_R20_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 572F);
            this.C_R20_T05.Multiline = true;
            this.C_R20_T05.Name = "C_R20_T05";
            this.C_R20_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T05.StylePriority.UseFont = false;
            this.C_R20_T05.Text = "";
            this.C_R20_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T05.WordWrap = false;
            // 
            // C_R20_T06
            // 
            this.C_R20_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T06.BorderWidth = 0.5F;
            this.C_R20_T06.CanGrow = false;
            this.C_R20_T06.Dpi = 100F;
            this.C_R20_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 572F);
            this.C_R20_T06.Multiline = true;
            this.C_R20_T06.Name = "C_R20_T06";
            this.C_R20_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T06.StylePriority.UseFont = false;
            this.C_R20_T06.Text = "";
            this.C_R20_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T06.WordWrap = false;
            // 
            // C_R20_T07
            // 
            this.C_R20_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T07.BorderWidth = 0.5F;
            this.C_R20_T07.CanGrow = false;
            this.C_R20_T07.Dpi = 100F;
            this.C_R20_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 572F);
            this.C_R20_T07.Multiline = true;
            this.C_R20_T07.Name = "C_R20_T07";
            this.C_R20_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T07.StylePriority.UseFont = false;
            this.C_R20_T07.Text = "";
            this.C_R20_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T07.WordWrap = false;
            // 
            // C_R20_T08
            // 
            this.C_R20_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T08.BorderWidth = 0.5F;
            this.C_R20_T08.CanGrow = false;
            this.C_R20_T08.Dpi = 100F;
            this.C_R20_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 572F);
            this.C_R20_T08.Multiline = true;
            this.C_R20_T08.Name = "C_R20_T08";
            this.C_R20_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T08.StylePriority.UseFont = false;
            this.C_R20_T08.Text = "";
            this.C_R20_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T08.WordWrap = false;
            // 
            // C_R20_T09
            // 
            this.C_R20_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T09.BorderWidth = 0.5F;
            this.C_R20_T09.CanGrow = false;
            this.C_R20_T09.Dpi = 100F;
            this.C_R20_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 572F);
            this.C_R20_T09.Multiline = true;
            this.C_R20_T09.Name = "C_R20_T09";
            this.C_R20_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T09.StylePriority.UseFont = false;
            this.C_R20_T09.Text = "";
            this.C_R20_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T09.WordWrap = false;
            // 
            // C_R20_T10
            // 
            this.C_R20_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T10.BorderWidth = 0.5F;
            this.C_R20_T10.CanGrow = false;
            this.C_R20_T10.Dpi = 100F;
            this.C_R20_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 572F);
            this.C_R20_T10.Multiline = true;
            this.C_R20_T10.Name = "C_R20_T10";
            this.C_R20_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T10.StylePriority.UseFont = false;
            this.C_R20_T10.Text = "";
            this.C_R20_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T10.WordWrap = false;
            // 
            // C_R20_T11
            // 
            this.C_R20_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T11.BorderWidth = 0.5F;
            this.C_R20_T11.CanGrow = false;
            this.C_R20_T11.Dpi = 100F;
            this.C_R20_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 572F);
            this.C_R20_T11.Multiline = true;
            this.C_R20_T11.Name = "C_R20_T11";
            this.C_R20_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T11.StylePriority.UseFont = false;
            this.C_R20_T11.Text = "";
            this.C_R20_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T11.WordWrap = false;
            // 
            // C_R20_T12
            // 
            this.C_R20_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R20_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_T12.BorderWidth = 0.5F;
            this.C_R20_T12.CanGrow = false;
            this.C_R20_T12.Dpi = 100F;
            this.C_R20_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 572F);
            this.C_R20_T12.Multiline = true;
            this.C_R20_T12.Name = "C_R20_T12";
            this.C_R20_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R20_T12.StylePriority.UseFont = false;
            this.C_R20_T12.Text = "";
            this.C_R20_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_T12.WordWrap = false;
            // 
            // C_R21_PRC
            // 
            this.C_R21_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R21_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_PRC.BorderWidth = 0.5F;
            this.C_R21_PRC.CanGrow = false;
            this.C_R21_PRC.Dpi = 100F;
            this.C_R21_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 594F);
            this.C_R21_PRC.Multiline = true;
            this.C_R21_PRC.Name = "C_R21_PRC";
            this.C_R21_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R21_PRC.StylePriority.UseFont = false;
            this.C_R21_PRC.Text = "";
            this.C_R21_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_PRC.WordWrap = false;
            // 
            // C_R21_STD
            // 
            this.C_R21_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R21_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_STD.BorderWidth = 0.5F;
            this.C_R21_STD.CanGrow = false;
            this.C_R21_STD.Dpi = 100F;
            this.C_R21_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 594F);
            this.C_R21_STD.Multiline = true;
            this.C_R21_STD.Name = "C_R21_STD";
            this.C_R21_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R21_STD.StylePriority.UseFont = false;
            this.C_R21_STD.Text = "";
            this.C_R21_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_STD.WordWrap = true;
            // 
            // C_R21_FEAT
            // 
            this.C_R21_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R21_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_FEAT.BorderWidth = 0.5F;
            this.C_R21_FEAT.CanGrow = false;
            this.C_R21_FEAT.Dpi = 100F;
            this.C_R21_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 594F);
            this.C_R21_FEAT.Multiline = true;
            this.C_R21_FEAT.Name = "C_R21_FEAT";
            this.C_R21_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R21_FEAT.StylePriority.UseFont = false;
            this.C_R21_FEAT.Text = "";
            this.C_R21_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_FEAT.WordWrap = false;
            // 
            // C_R21_SPEC
            // 
            this.C_R21_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R21_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_SPEC.BorderWidth = 0.5F;
            this.C_R21_SPEC.CanGrow = false;
            this.C_R21_SPEC.Dpi = 100F;
            this.C_R21_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 594F);
            this.C_R21_SPEC.Multiline = true;
            this.C_R21_SPEC.Name = "C_R21_SPEC";
            this.C_R21_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R21_SPEC.StylePriority.UseFont = false;
            this.C_R21_SPEC.Text = "";
            this.C_R21_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_SPEC.WordWrap = true;
            // 
            // C_R21_CYCLE
            // 
            this.C_R21_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R21_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_CYCLE.BorderWidth = 0.5F;
            this.C_R21_CYCLE.CanGrow = false;
            this.C_R21_CYCLE.Dpi = 100F;
            this.C_R21_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 594F);
            this.C_R21_CYCLE.Multiline = true;
            this.C_R21_CYCLE.Name = "C_R21_CYCLE";
            this.C_R21_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R21_CYCLE.StylePriority.UseFont = false;
            this.C_R21_CYCLE.Text = "";
            this.C_R21_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_CYCLE.WordWrap = true;
            // 
            // C_R21_GAUGE
            // 
            this.C_R21_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R21_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_GAUGE.BorderWidth = 0.5F;
            this.C_R21_GAUGE.CanGrow = false;
            this.C_R21_GAUGE.Dpi = 100F;
            this.C_R21_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 594F);
            this.C_R21_GAUGE.Multiline = true;
            this.C_R21_GAUGE.Name = "C_R21_GAUGE";
            this.C_R21_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R21_GAUGE.StylePriority.UseFont = false;
            this.C_R21_GAUGE.Text = "";
            this.C_R21_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_GAUGE.WordWrap = true;
            // 
            // C_R21_NO
            // 
            this.C_R21_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R21_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_NO.BorderWidth = 0.5F;
            this.C_R21_NO.CanGrow = false;
            this.C_R21_NO.Dpi = 100F;
            this.C_R21_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 594F);
            this.C_R21_NO.Multiline = true;
            this.C_R21_NO.Name = "C_R21_NO";
            this.C_R21_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R21_NO.StylePriority.UseFont = false;
            this.C_R21_NO.Text = "";
            this.C_R21_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_NO.WordWrap = false;
            // 
            // C_R21_T01
            // 
            this.C_R21_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T01.BorderWidth = 0.5F;
            this.C_R21_T01.CanGrow = false;
            this.C_R21_T01.Dpi = 100F;
            this.C_R21_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 594F);
            this.C_R21_T01.Multiline = true;
            this.C_R21_T01.Name = "C_R21_T01";
            this.C_R21_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T01.StylePriority.UseFont = false;
            this.C_R21_T01.Text = "";
            this.C_R21_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T01.WordWrap = false;
            // 
            // C_R21_T02
            // 
            this.C_R21_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T02.BorderWidth = 0.5F;
            this.C_R21_T02.CanGrow = false;
            this.C_R21_T02.Dpi = 100F;
            this.C_R21_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 594F);
            this.C_R21_T02.Multiline = true;
            this.C_R21_T02.Name = "C_R21_T02";
            this.C_R21_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T02.StylePriority.UseFont = false;
            this.C_R21_T02.Text = "";
            this.C_R21_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T02.WordWrap = false;
            // 
            // C_R21_T03
            // 
            this.C_R21_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T03.BorderWidth = 0.5F;
            this.C_R21_T03.CanGrow = false;
            this.C_R21_T03.Dpi = 100F;
            this.C_R21_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 594F);
            this.C_R21_T03.Multiline = true;
            this.C_R21_T03.Name = "C_R21_T03";
            this.C_R21_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T03.StylePriority.UseFont = false;
            this.C_R21_T03.Text = "";
            this.C_R21_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T03.WordWrap = false;
            // 
            // C_R21_T04
            // 
            this.C_R21_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T04.BorderWidth = 0.5F;
            this.C_R21_T04.CanGrow = false;
            this.C_R21_T04.Dpi = 100F;
            this.C_R21_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 594F);
            this.C_R21_T04.Multiline = true;
            this.C_R21_T04.Name = "C_R21_T04";
            this.C_R21_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T04.StylePriority.UseFont = false;
            this.C_R21_T04.Text = "";
            this.C_R21_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T04.WordWrap = false;
            // 
            // C_R21_T05
            // 
            this.C_R21_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T05.BorderWidth = 0.5F;
            this.C_R21_T05.CanGrow = false;
            this.C_R21_T05.Dpi = 100F;
            this.C_R21_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 594F);
            this.C_R21_T05.Multiline = true;
            this.C_R21_T05.Name = "C_R21_T05";
            this.C_R21_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T05.StylePriority.UseFont = false;
            this.C_R21_T05.Text = "";
            this.C_R21_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T05.WordWrap = false;
            // 
            // C_R21_T06
            // 
            this.C_R21_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T06.BorderWidth = 0.5F;
            this.C_R21_T06.CanGrow = false;
            this.C_R21_T06.Dpi = 100F;
            this.C_R21_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 594F);
            this.C_R21_T06.Multiline = true;
            this.C_R21_T06.Name = "C_R21_T06";
            this.C_R21_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T06.StylePriority.UseFont = false;
            this.C_R21_T06.Text = "";
            this.C_R21_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T06.WordWrap = false;
            // 
            // C_R21_T07
            // 
            this.C_R21_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T07.BorderWidth = 0.5F;
            this.C_R21_T07.CanGrow = false;
            this.C_R21_T07.Dpi = 100F;
            this.C_R21_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 594F);
            this.C_R21_T07.Multiline = true;
            this.C_R21_T07.Name = "C_R21_T07";
            this.C_R21_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T07.StylePriority.UseFont = false;
            this.C_R21_T07.Text = "";
            this.C_R21_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T07.WordWrap = false;
            // 
            // C_R21_T08
            // 
            this.C_R21_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T08.BorderWidth = 0.5F;
            this.C_R21_T08.CanGrow = false;
            this.C_R21_T08.Dpi = 100F;
            this.C_R21_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 594F);
            this.C_R21_T08.Multiline = true;
            this.C_R21_T08.Name = "C_R21_T08";
            this.C_R21_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T08.StylePriority.UseFont = false;
            this.C_R21_T08.Text = "";
            this.C_R21_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T08.WordWrap = false;
            // 
            // C_R21_T09
            // 
            this.C_R21_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T09.BorderWidth = 0.5F;
            this.C_R21_T09.CanGrow = false;
            this.C_R21_T09.Dpi = 100F;
            this.C_R21_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 594F);
            this.C_R21_T09.Multiline = true;
            this.C_R21_T09.Name = "C_R21_T09";
            this.C_R21_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T09.StylePriority.UseFont = false;
            this.C_R21_T09.Text = "";
            this.C_R21_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T09.WordWrap = false;
            // 
            // C_R21_T10
            // 
            this.C_R21_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T10.BorderWidth = 0.5F;
            this.C_R21_T10.CanGrow = false;
            this.C_R21_T10.Dpi = 100F;
            this.C_R21_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 594F);
            this.C_R21_T10.Multiline = true;
            this.C_R21_T10.Name = "C_R21_T10";
            this.C_R21_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T10.StylePriority.UseFont = false;
            this.C_R21_T10.Text = "";
            this.C_R21_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T10.WordWrap = false;
            // 
            // C_R21_T11
            // 
            this.C_R21_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T11.BorderWidth = 0.5F;
            this.C_R21_T11.CanGrow = false;
            this.C_R21_T11.Dpi = 100F;
            this.C_R21_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 594F);
            this.C_R21_T11.Multiline = true;
            this.C_R21_T11.Name = "C_R21_T11";
            this.C_R21_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T11.StylePriority.UseFont = false;
            this.C_R21_T11.Text = "";
            this.C_R21_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T11.WordWrap = false;
            // 
            // C_R21_T12
            // 
            this.C_R21_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R21_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_T12.BorderWidth = 0.5F;
            this.C_R21_T12.CanGrow = false;
            this.C_R21_T12.Dpi = 100F;
            this.C_R21_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 594F);
            this.C_R21_T12.Multiline = true;
            this.C_R21_T12.Name = "C_R21_T12";
            this.C_R21_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R21_T12.StylePriority.UseFont = false;
            this.C_R21_T12.Text = "";
            this.C_R21_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_T12.WordWrap = false;
            // 
            // C_R22_PRC
            // 
            this.C_R22_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R22_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_PRC.BorderWidth = 0.5F;
            this.C_R22_PRC.CanGrow = false;
            this.C_R22_PRC.Dpi = 100F;
            this.C_R22_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 616F);
            this.C_R22_PRC.Multiline = true;
            this.C_R22_PRC.Name = "C_R22_PRC";
            this.C_R22_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R22_PRC.StylePriority.UseFont = false;
            this.C_R22_PRC.Text = "";
            this.C_R22_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_PRC.WordWrap = false;
            // 
            // C_R22_STD
            // 
            this.C_R22_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R22_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_STD.BorderWidth = 0.5F;
            this.C_R22_STD.CanGrow = false;
            this.C_R22_STD.Dpi = 100F;
            this.C_R22_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 616F);
            this.C_R22_STD.Multiline = true;
            this.C_R22_STD.Name = "C_R22_STD";
            this.C_R22_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R22_STD.StylePriority.UseFont = false;
            this.C_R22_STD.Text = "";
            this.C_R22_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_STD.WordWrap = true;
            // 
            // C_R22_FEAT
            // 
            this.C_R22_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R22_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_FEAT.BorderWidth = 0.5F;
            this.C_R22_FEAT.CanGrow = false;
            this.C_R22_FEAT.Dpi = 100F;
            this.C_R22_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 616F);
            this.C_R22_FEAT.Multiline = true;
            this.C_R22_FEAT.Name = "C_R22_FEAT";
            this.C_R22_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R22_FEAT.StylePriority.UseFont = false;
            this.C_R22_FEAT.Text = "";
            this.C_R22_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_FEAT.WordWrap = false;
            // 
            // C_R22_SPEC
            // 
            this.C_R22_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R22_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_SPEC.BorderWidth = 0.5F;
            this.C_R22_SPEC.CanGrow = false;
            this.C_R22_SPEC.Dpi = 100F;
            this.C_R22_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 616F);
            this.C_R22_SPEC.Multiline = true;
            this.C_R22_SPEC.Name = "C_R22_SPEC";
            this.C_R22_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R22_SPEC.StylePriority.UseFont = false;
            this.C_R22_SPEC.Text = "";
            this.C_R22_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_SPEC.WordWrap = true;
            // 
            // C_R22_CYCLE
            // 
            this.C_R22_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R22_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_CYCLE.BorderWidth = 0.5F;
            this.C_R22_CYCLE.CanGrow = false;
            this.C_R22_CYCLE.Dpi = 100F;
            this.C_R22_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 616F);
            this.C_R22_CYCLE.Multiline = true;
            this.C_R22_CYCLE.Name = "C_R22_CYCLE";
            this.C_R22_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R22_CYCLE.StylePriority.UseFont = false;
            this.C_R22_CYCLE.Text = "";
            this.C_R22_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_CYCLE.WordWrap = true;
            // 
            // C_R22_GAUGE
            // 
            this.C_R22_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R22_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_GAUGE.BorderWidth = 0.5F;
            this.C_R22_GAUGE.CanGrow = false;
            this.C_R22_GAUGE.Dpi = 100F;
            this.C_R22_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 616F);
            this.C_R22_GAUGE.Multiline = true;
            this.C_R22_GAUGE.Name = "C_R22_GAUGE";
            this.C_R22_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R22_GAUGE.StylePriority.UseFont = false;
            this.C_R22_GAUGE.Text = "";
            this.C_R22_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_GAUGE.WordWrap = true;
            // 
            // C_R22_NO
            // 
            this.C_R22_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R22_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_NO.BorderWidth = 0.5F;
            this.C_R22_NO.CanGrow = false;
            this.C_R22_NO.Dpi = 100F;
            this.C_R22_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 616F);
            this.C_R22_NO.Multiline = true;
            this.C_R22_NO.Name = "C_R22_NO";
            this.C_R22_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R22_NO.StylePriority.UseFont = false;
            this.C_R22_NO.Text = "";
            this.C_R22_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_NO.WordWrap = false;
            // 
            // C_R22_T01
            // 
            this.C_R22_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T01.BorderWidth = 0.5F;
            this.C_R22_T01.CanGrow = false;
            this.C_R22_T01.Dpi = 100F;
            this.C_R22_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 616F);
            this.C_R22_T01.Multiline = true;
            this.C_R22_T01.Name = "C_R22_T01";
            this.C_R22_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T01.StylePriority.UseFont = false;
            this.C_R22_T01.Text = "";
            this.C_R22_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T01.WordWrap = false;
            // 
            // C_R22_T02
            // 
            this.C_R22_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T02.BorderWidth = 0.5F;
            this.C_R22_T02.CanGrow = false;
            this.C_R22_T02.Dpi = 100F;
            this.C_R22_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 616F);
            this.C_R22_T02.Multiline = true;
            this.C_R22_T02.Name = "C_R22_T02";
            this.C_R22_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T02.StylePriority.UseFont = false;
            this.C_R22_T02.Text = "";
            this.C_R22_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T02.WordWrap = false;
            // 
            // C_R22_T03
            // 
            this.C_R22_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T03.BorderWidth = 0.5F;
            this.C_R22_T03.CanGrow = false;
            this.C_R22_T03.Dpi = 100F;
            this.C_R22_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 616F);
            this.C_R22_T03.Multiline = true;
            this.C_R22_T03.Name = "C_R22_T03";
            this.C_R22_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T03.StylePriority.UseFont = false;
            this.C_R22_T03.Text = "";
            this.C_R22_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T03.WordWrap = false;
            // 
            // C_R22_T04
            // 
            this.C_R22_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T04.BorderWidth = 0.5F;
            this.C_R22_T04.CanGrow = false;
            this.C_R22_T04.Dpi = 100F;
            this.C_R22_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 616F);
            this.C_R22_T04.Multiline = true;
            this.C_R22_T04.Name = "C_R22_T04";
            this.C_R22_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T04.StylePriority.UseFont = false;
            this.C_R22_T04.Text = "";
            this.C_R22_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T04.WordWrap = false;
            // 
            // C_R22_T05
            // 
            this.C_R22_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T05.BorderWidth = 0.5F;
            this.C_R22_T05.CanGrow = false;
            this.C_R22_T05.Dpi = 100F;
            this.C_R22_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 616F);
            this.C_R22_T05.Multiline = true;
            this.C_R22_T05.Name = "C_R22_T05";
            this.C_R22_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T05.StylePriority.UseFont = false;
            this.C_R22_T05.Text = "";
            this.C_R22_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T05.WordWrap = false;
            // 
            // C_R22_T06
            // 
            this.C_R22_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T06.BorderWidth = 0.5F;
            this.C_R22_T06.CanGrow = false;
            this.C_R22_T06.Dpi = 100F;
            this.C_R22_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 616F);
            this.C_R22_T06.Multiline = true;
            this.C_R22_T06.Name = "C_R22_T06";
            this.C_R22_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T06.StylePriority.UseFont = false;
            this.C_R22_T06.Text = "";
            this.C_R22_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T06.WordWrap = false;
            // 
            // C_R22_T07
            // 
            this.C_R22_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T07.BorderWidth = 0.5F;
            this.C_R22_T07.CanGrow = false;
            this.C_R22_T07.Dpi = 100F;
            this.C_R22_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 616F);
            this.C_R22_T07.Multiline = true;
            this.C_R22_T07.Name = "C_R22_T07";
            this.C_R22_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T07.StylePriority.UseFont = false;
            this.C_R22_T07.Text = "";
            this.C_R22_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T07.WordWrap = false;
            // 
            // C_R22_T08
            // 
            this.C_R22_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T08.BorderWidth = 0.5F;
            this.C_R22_T08.CanGrow = false;
            this.C_R22_T08.Dpi = 100F;
            this.C_R22_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 616F);
            this.C_R22_T08.Multiline = true;
            this.C_R22_T08.Name = "C_R22_T08";
            this.C_R22_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T08.StylePriority.UseFont = false;
            this.C_R22_T08.Text = "";
            this.C_R22_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T08.WordWrap = false;
            // 
            // C_R22_T09
            // 
            this.C_R22_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T09.BorderWidth = 0.5F;
            this.C_R22_T09.CanGrow = false;
            this.C_R22_T09.Dpi = 100F;
            this.C_R22_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 616F);
            this.C_R22_T09.Multiline = true;
            this.C_R22_T09.Name = "C_R22_T09";
            this.C_R22_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T09.StylePriority.UseFont = false;
            this.C_R22_T09.Text = "";
            this.C_R22_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T09.WordWrap = false;
            // 
            // C_R22_T10
            // 
            this.C_R22_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T10.BorderWidth = 0.5F;
            this.C_R22_T10.CanGrow = false;
            this.C_R22_T10.Dpi = 100F;
            this.C_R22_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 616F);
            this.C_R22_T10.Multiline = true;
            this.C_R22_T10.Name = "C_R22_T10";
            this.C_R22_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T10.StylePriority.UseFont = false;
            this.C_R22_T10.Text = "";
            this.C_R22_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T10.WordWrap = false;
            // 
            // C_R22_T11
            // 
            this.C_R22_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T11.BorderWidth = 0.5F;
            this.C_R22_T11.CanGrow = false;
            this.C_R22_T11.Dpi = 100F;
            this.C_R22_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 616F);
            this.C_R22_T11.Multiline = true;
            this.C_R22_T11.Name = "C_R22_T11";
            this.C_R22_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T11.StylePriority.UseFont = false;
            this.C_R22_T11.Text = "";
            this.C_R22_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T11.WordWrap = false;
            // 
            // C_R22_T12
            // 
            this.C_R22_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R22_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_T12.BorderWidth = 0.5F;
            this.C_R22_T12.CanGrow = false;
            this.C_R22_T12.Dpi = 100F;
            this.C_R22_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 616F);
            this.C_R22_T12.Multiline = true;
            this.C_R22_T12.Name = "C_R22_T12";
            this.C_R22_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R22_T12.StylePriority.UseFont = false;
            this.C_R22_T12.Text = "";
            this.C_R22_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_T12.WordWrap = false;
            // 
            // C_R23_PRC
            // 
            this.C_R23_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R23_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_PRC.BorderWidth = 0.5F;
            this.C_R23_PRC.CanGrow = false;
            this.C_R23_PRC.Dpi = 100F;
            this.C_R23_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 638F);
            this.C_R23_PRC.Multiline = true;
            this.C_R23_PRC.Name = "C_R23_PRC";
            this.C_R23_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R23_PRC.StylePriority.UseFont = false;
            this.C_R23_PRC.Text = "";
            this.C_R23_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_PRC.WordWrap = false;
            // 
            // C_R23_STD
            // 
            this.C_R23_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R23_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_STD.BorderWidth = 0.5F;
            this.C_R23_STD.CanGrow = false;
            this.C_R23_STD.Dpi = 100F;
            this.C_R23_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 638F);
            this.C_R23_STD.Multiline = true;
            this.C_R23_STD.Name = "C_R23_STD";
            this.C_R23_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R23_STD.StylePriority.UseFont = false;
            this.C_R23_STD.Text = "";
            this.C_R23_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_STD.WordWrap = true;
            // 
            // C_R23_FEAT
            // 
            this.C_R23_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R23_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_FEAT.BorderWidth = 0.5F;
            this.C_R23_FEAT.CanGrow = false;
            this.C_R23_FEAT.Dpi = 100F;
            this.C_R23_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 638F);
            this.C_R23_FEAT.Multiline = true;
            this.C_R23_FEAT.Name = "C_R23_FEAT";
            this.C_R23_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R23_FEAT.StylePriority.UseFont = false;
            this.C_R23_FEAT.Text = "";
            this.C_R23_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_FEAT.WordWrap = false;
            // 
            // C_R23_SPEC
            // 
            this.C_R23_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R23_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_SPEC.BorderWidth = 0.5F;
            this.C_R23_SPEC.CanGrow = false;
            this.C_R23_SPEC.Dpi = 100F;
            this.C_R23_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 638F);
            this.C_R23_SPEC.Multiline = true;
            this.C_R23_SPEC.Name = "C_R23_SPEC";
            this.C_R23_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R23_SPEC.StylePriority.UseFont = false;
            this.C_R23_SPEC.Text = "";
            this.C_R23_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_SPEC.WordWrap = true;
            // 
            // C_R23_CYCLE
            // 
            this.C_R23_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R23_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_CYCLE.BorderWidth = 0.5F;
            this.C_R23_CYCLE.CanGrow = false;
            this.C_R23_CYCLE.Dpi = 100F;
            this.C_R23_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 638F);
            this.C_R23_CYCLE.Multiline = true;
            this.C_R23_CYCLE.Name = "C_R23_CYCLE";
            this.C_R23_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R23_CYCLE.StylePriority.UseFont = false;
            this.C_R23_CYCLE.Text = "";
            this.C_R23_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_CYCLE.WordWrap = true;
            // 
            // C_R23_GAUGE
            // 
            this.C_R23_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R23_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_GAUGE.BorderWidth = 0.5F;
            this.C_R23_GAUGE.CanGrow = false;
            this.C_R23_GAUGE.Dpi = 100F;
            this.C_R23_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 638F);
            this.C_R23_GAUGE.Multiline = true;
            this.C_R23_GAUGE.Name = "C_R23_GAUGE";
            this.C_R23_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R23_GAUGE.StylePriority.UseFont = false;
            this.C_R23_GAUGE.Text = "";
            this.C_R23_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_GAUGE.WordWrap = true;
            // 
            // C_R23_NO
            // 
            this.C_R23_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R23_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_NO.BorderWidth = 0.5F;
            this.C_R23_NO.CanGrow = false;
            this.C_R23_NO.Dpi = 100F;
            this.C_R23_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 638F);
            this.C_R23_NO.Multiline = true;
            this.C_R23_NO.Name = "C_R23_NO";
            this.C_R23_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R23_NO.StylePriority.UseFont = false;
            this.C_R23_NO.Text = "";
            this.C_R23_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_NO.WordWrap = false;
            // 
            // C_R23_T01
            // 
            this.C_R23_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T01.BorderWidth = 0.5F;
            this.C_R23_T01.CanGrow = false;
            this.C_R23_T01.Dpi = 100F;
            this.C_R23_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 638F);
            this.C_R23_T01.Multiline = true;
            this.C_R23_T01.Name = "C_R23_T01";
            this.C_R23_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T01.StylePriority.UseFont = false;
            this.C_R23_T01.Text = "";
            this.C_R23_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T01.WordWrap = false;
            // 
            // C_R23_T02
            // 
            this.C_R23_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T02.BorderWidth = 0.5F;
            this.C_R23_T02.CanGrow = false;
            this.C_R23_T02.Dpi = 100F;
            this.C_R23_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 638F);
            this.C_R23_T02.Multiline = true;
            this.C_R23_T02.Name = "C_R23_T02";
            this.C_R23_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T02.StylePriority.UseFont = false;
            this.C_R23_T02.Text = "";
            this.C_R23_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T02.WordWrap = false;
            // 
            // C_R23_T03
            // 
            this.C_R23_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T03.BorderWidth = 0.5F;
            this.C_R23_T03.CanGrow = false;
            this.C_R23_T03.Dpi = 100F;
            this.C_R23_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 638F);
            this.C_R23_T03.Multiline = true;
            this.C_R23_T03.Name = "C_R23_T03";
            this.C_R23_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T03.StylePriority.UseFont = false;
            this.C_R23_T03.Text = "";
            this.C_R23_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T03.WordWrap = false;
            // 
            // C_R23_T04
            // 
            this.C_R23_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T04.BorderWidth = 0.5F;
            this.C_R23_T04.CanGrow = false;
            this.C_R23_T04.Dpi = 100F;
            this.C_R23_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 638F);
            this.C_R23_T04.Multiline = true;
            this.C_R23_T04.Name = "C_R23_T04";
            this.C_R23_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T04.StylePriority.UseFont = false;
            this.C_R23_T04.Text = "";
            this.C_R23_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T04.WordWrap = false;
            // 
            // C_R23_T05
            // 
            this.C_R23_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T05.BorderWidth = 0.5F;
            this.C_R23_T05.CanGrow = false;
            this.C_R23_T05.Dpi = 100F;
            this.C_R23_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 638F);
            this.C_R23_T05.Multiline = true;
            this.C_R23_T05.Name = "C_R23_T05";
            this.C_R23_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T05.StylePriority.UseFont = false;
            this.C_R23_T05.Text = "";
            this.C_R23_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T05.WordWrap = false;
            // 
            // C_R23_T06
            // 
            this.C_R23_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T06.BorderWidth = 0.5F;
            this.C_R23_T06.CanGrow = false;
            this.C_R23_T06.Dpi = 100F;
            this.C_R23_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 638F);
            this.C_R23_T06.Multiline = true;
            this.C_R23_T06.Name = "C_R23_T06";
            this.C_R23_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T06.StylePriority.UseFont = false;
            this.C_R23_T06.Text = "";
            this.C_R23_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T06.WordWrap = false;
            // 
            // C_R23_T07
            // 
            this.C_R23_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T07.BorderWidth = 0.5F;
            this.C_R23_T07.CanGrow = false;
            this.C_R23_T07.Dpi = 100F;
            this.C_R23_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 638F);
            this.C_R23_T07.Multiline = true;
            this.C_R23_T07.Name = "C_R23_T07";
            this.C_R23_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T07.StylePriority.UseFont = false;
            this.C_R23_T07.Text = "";
            this.C_R23_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T07.WordWrap = false;
            // 
            // C_R23_T08
            // 
            this.C_R23_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T08.BorderWidth = 0.5F;
            this.C_R23_T08.CanGrow = false;
            this.C_R23_T08.Dpi = 100F;
            this.C_R23_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 638F);
            this.C_R23_T08.Multiline = true;
            this.C_R23_T08.Name = "C_R23_T08";
            this.C_R23_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T08.StylePriority.UseFont = false;
            this.C_R23_T08.Text = "";
            this.C_R23_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T08.WordWrap = false;
            // 
            // C_R23_T09
            // 
            this.C_R23_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T09.BorderWidth = 0.5F;
            this.C_R23_T09.CanGrow = false;
            this.C_R23_T09.Dpi = 100F;
            this.C_R23_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 638F);
            this.C_R23_T09.Multiline = true;
            this.C_R23_T09.Name = "C_R23_T09";
            this.C_R23_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T09.StylePriority.UseFont = false;
            this.C_R23_T09.Text = "";
            this.C_R23_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T09.WordWrap = false;
            // 
            // C_R23_T10
            // 
            this.C_R23_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T10.BorderWidth = 0.5F;
            this.C_R23_T10.CanGrow = false;
            this.C_R23_T10.Dpi = 100F;
            this.C_R23_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 638F);
            this.C_R23_T10.Multiline = true;
            this.C_R23_T10.Name = "C_R23_T10";
            this.C_R23_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T10.StylePriority.UseFont = false;
            this.C_R23_T10.Text = "";
            this.C_R23_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T10.WordWrap = false;
            // 
            // C_R23_T11
            // 
            this.C_R23_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T11.BorderWidth = 0.5F;
            this.C_R23_T11.CanGrow = false;
            this.C_R23_T11.Dpi = 100F;
            this.C_R23_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 638F);
            this.C_R23_T11.Multiline = true;
            this.C_R23_T11.Name = "C_R23_T11";
            this.C_R23_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T11.StylePriority.UseFont = false;
            this.C_R23_T11.Text = "";
            this.C_R23_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T11.WordWrap = false;
            // 
            // C_R23_T12
            // 
            this.C_R23_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R23_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_T12.BorderWidth = 0.5F;
            this.C_R23_T12.CanGrow = false;
            this.C_R23_T12.Dpi = 100F;
            this.C_R23_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 638F);
            this.C_R23_T12.Multiline = true;
            this.C_R23_T12.Name = "C_R23_T12";
            this.C_R23_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R23_T12.StylePriority.UseFont = false;
            this.C_R23_T12.Text = "";
            this.C_R23_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_T12.WordWrap = false;
            // 
            // C_R24_PRC
            // 
            this.C_R24_PRC.BorderColor = System.Drawing.Color.Black;
            this.C_R24_PRC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_PRC.BorderWidth = 0.5F;
            this.C_R24_PRC.CanGrow = false;
            this.C_R24_PRC.Dpi = 100F;
            this.C_R24_PRC.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_PRC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 660F);
            this.C_R24_PRC.Multiline = true;
            this.C_R24_PRC.Name = "C_R24_PRC";
            this.C_R24_PRC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_PRC.SizeF = new System.Drawing.SizeF(55F, 22F);
            this.C_R24_PRC.StylePriority.UseFont = false;
            this.C_R24_PRC.Text = "";
            this.C_R24_PRC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_PRC.WordWrap = false;
            // 
            // C_R24_STD
            // 
            this.C_R24_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R24_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_STD.BorderWidth = 0.5F;
            this.C_R24_STD.CanGrow = false;
            this.C_R24_STD.Dpi = 100F;
            this.C_R24_STD.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_STD.LocationFloat = new DevExpress.Utils.PointFloat(55F, 660F);
            this.C_R24_STD.Multiline = true;
            this.C_R24_STD.Name = "C_R24_STD";
            this.C_R24_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_STD.SizeF = new System.Drawing.SizeF(80F, 22F);
            this.C_R24_STD.StylePriority.UseFont = false;
            this.C_R24_STD.Text = "";
            this.C_R24_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_STD.WordWrap = true;
            // 
            // C_R24_FEAT
            // 
            this.C_R24_FEAT.BorderColor = System.Drawing.Color.Black;
            this.C_R24_FEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_FEAT.BorderWidth = 0.5F;
            this.C_R24_FEAT.CanGrow = false;
            this.C_R24_FEAT.Dpi = 100F;
            this.C_R24_FEAT.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_FEAT.LocationFloat = new DevExpress.Utils.PointFloat(135F, 660F);
            this.C_R24_FEAT.Multiline = true;
            this.C_R24_FEAT.Name = "C_R24_FEAT";
            this.C_R24_FEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_FEAT.SizeF = new System.Drawing.SizeF(35F, 22F);
            this.C_R24_FEAT.StylePriority.UseFont = false;
            this.C_R24_FEAT.Text = "";
            this.C_R24_FEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_FEAT.WordWrap = false;
            // 
            // C_R24_SPEC
            // 
            this.C_R24_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R24_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_SPEC.BorderWidth = 0.5F;
            this.C_R24_SPEC.CanGrow = false;
            this.C_R24_SPEC.Dpi = 100F;
            this.C_R24_SPEC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(170F, 660F);
            this.C_R24_SPEC.Multiline = true;
            this.C_R24_SPEC.Name = "C_R24_SPEC";
            this.C_R24_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_SPEC.SizeF = new System.Drawing.SizeF(158F, 22F);
            this.C_R24_SPEC.StylePriority.UseFont = false;
            this.C_R24_SPEC.Text = "";
            this.C_R24_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_SPEC.WordWrap = true;
            // 
            // C_R24_CYCLE
            // 
            this.C_R24_CYCLE.BorderColor = System.Drawing.Color.Black;
            this.C_R24_CYCLE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_CYCLE.BorderWidth = 0.5F;
            this.C_R24_CYCLE.CanGrow = false;
            this.C_R24_CYCLE.Dpi = 100F;
            this.C_R24_CYCLE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_CYCLE.LocationFloat = new DevExpress.Utils.PointFloat(328F, 660F);
            this.C_R24_CYCLE.Multiline = true;
            this.C_R24_CYCLE.Name = "C_R24_CYCLE";
            this.C_R24_CYCLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_CYCLE.SizeF = new System.Drawing.SizeF(60F, 22F);
            this.C_R24_CYCLE.StylePriority.UseFont = false;
            this.C_R24_CYCLE.Text = "";
            this.C_R24_CYCLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_CYCLE.WordWrap = true;
            // 
            // C_R24_GAUGE
            // 
            this.C_R24_GAUGE.BorderColor = System.Drawing.Color.Black;
            this.C_R24_GAUGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_GAUGE.BorderWidth = 0.5F;
            this.C_R24_GAUGE.CanGrow = false;
            this.C_R24_GAUGE.Dpi = 100F;
            this.C_R24_GAUGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_GAUGE.LocationFloat = new DevExpress.Utils.PointFloat(388F, 660F);
            this.C_R24_GAUGE.Multiline = true;
            this.C_R24_GAUGE.Name = "C_R24_GAUGE";
            this.C_R24_GAUGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_GAUGE.SizeF = new System.Drawing.SizeF(75F, 22F);
            this.C_R24_GAUGE.StylePriority.UseFont = false;
            this.C_R24_GAUGE.Text = "";
            this.C_R24_GAUGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_GAUGE.WordWrap = true;
            // 
            // C_R24_NO
            // 
            this.C_R24_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R24_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_NO.BorderWidth = 0.5F;
            this.C_R24_NO.CanGrow = false;
            this.C_R24_NO.Dpi = 100F;
            this.C_R24_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_NO.LocationFloat = new DevExpress.Utils.PointFloat(463F, 660F);
            this.C_R24_NO.Multiline = true;
            this.C_R24_NO.Name = "C_R24_NO";
            this.C_R24_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_NO.SizeF = new System.Drawing.SizeF(30F, 22F);
            this.C_R24_NO.StylePriority.UseFont = false;
            this.C_R24_NO.Text = "";
            this.C_R24_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_NO.WordWrap = false;
            // 
            // C_R24_T01
            // 
            this.C_R24_T01.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T01.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T01.BorderWidth = 0.5F;
            this.C_R24_T01.CanGrow = false;
            this.C_R24_T01.Dpi = 100F;
            this.C_R24_T01.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T01.LocationFloat = new DevExpress.Utils.PointFloat(493F, 660F);
            this.C_R24_T01.Multiline = true;
            this.C_R24_T01.Name = "C_R24_T01";
            this.C_R24_T01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T01.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T01.StylePriority.UseFont = false;
            this.C_R24_T01.Text = "";
            this.C_R24_T01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T01.WordWrap = false;
            // 
            // C_R24_T02
            // 
            this.C_R24_T02.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T02.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T02.BorderWidth = 0.5F;
            this.C_R24_T02.CanGrow = false;
            this.C_R24_T02.Dpi = 100F;
            this.C_R24_T02.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T02.LocationFloat = new DevExpress.Utils.PointFloat(546F, 660F);
            this.C_R24_T02.Multiline = true;
            this.C_R24_T02.Name = "C_R24_T02";
            this.C_R24_T02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T02.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T02.StylePriority.UseFont = false;
            this.C_R24_T02.Text = "";
            this.C_R24_T02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T02.WordWrap = false;
            // 
            // C_R24_T03
            // 
            this.C_R24_T03.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T03.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T03.BorderWidth = 0.5F;
            this.C_R24_T03.CanGrow = false;
            this.C_R24_T03.Dpi = 100F;
            this.C_R24_T03.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T03.LocationFloat = new DevExpress.Utils.PointFloat(599F, 660F);
            this.C_R24_T03.Multiline = true;
            this.C_R24_T03.Name = "C_R24_T03";
            this.C_R24_T03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T03.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T03.StylePriority.UseFont = false;
            this.C_R24_T03.Text = "";
            this.C_R24_T03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T03.WordWrap = false;
            // 
            // C_R24_T04
            // 
            this.C_R24_T04.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T04.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T04.BorderWidth = 0.5F;
            this.C_R24_T04.CanGrow = false;
            this.C_R24_T04.Dpi = 100F;
            this.C_R24_T04.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T04.LocationFloat = new DevExpress.Utils.PointFloat(652F, 660F);
            this.C_R24_T04.Multiline = true;
            this.C_R24_T04.Name = "C_R24_T04";
            this.C_R24_T04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T04.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T04.StylePriority.UseFont = false;
            this.C_R24_T04.Text = "";
            this.C_R24_T04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T04.WordWrap = false;
            // 
            // C_R24_T05
            // 
            this.C_R24_T05.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T05.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T05.BorderWidth = 0.5F;
            this.C_R24_T05.CanGrow = false;
            this.C_R24_T05.Dpi = 100F;
            this.C_R24_T05.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T05.LocationFloat = new DevExpress.Utils.PointFloat(705F, 660F);
            this.C_R24_T05.Multiline = true;
            this.C_R24_T05.Name = "C_R24_T05";
            this.C_R24_T05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T05.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T05.StylePriority.UseFont = false;
            this.C_R24_T05.Text = "";
            this.C_R24_T05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T05.WordWrap = false;
            // 
            // C_R24_T06
            // 
            this.C_R24_T06.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T06.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T06.BorderWidth = 0.5F;
            this.C_R24_T06.CanGrow = false;
            this.C_R24_T06.Dpi = 100F;
            this.C_R24_T06.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T06.LocationFloat = new DevExpress.Utils.PointFloat(758F, 660F);
            this.C_R24_T06.Multiline = true;
            this.C_R24_T06.Name = "C_R24_T06";
            this.C_R24_T06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T06.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T06.StylePriority.UseFont = false;
            this.C_R24_T06.Text = "";
            this.C_R24_T06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T06.WordWrap = false;
            // 
            // C_R24_T07
            // 
            this.C_R24_T07.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T07.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T07.BorderWidth = 0.5F;
            this.C_R24_T07.CanGrow = false;
            this.C_R24_T07.Dpi = 100F;
            this.C_R24_T07.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T07.LocationFloat = new DevExpress.Utils.PointFloat(811F, 660F);
            this.C_R24_T07.Multiline = true;
            this.C_R24_T07.Name = "C_R24_T07";
            this.C_R24_T07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T07.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T07.StylePriority.UseFont = false;
            this.C_R24_T07.Text = "";
            this.C_R24_T07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T07.WordWrap = false;
            // 
            // C_R24_T08
            // 
            this.C_R24_T08.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T08.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T08.BorderWidth = 0.5F;
            this.C_R24_T08.CanGrow = false;
            this.C_R24_T08.Dpi = 100F;
            this.C_R24_T08.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T08.LocationFloat = new DevExpress.Utils.PointFloat(864F, 660F);
            this.C_R24_T08.Multiline = true;
            this.C_R24_T08.Name = "C_R24_T08";
            this.C_R24_T08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T08.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T08.StylePriority.UseFont = false;
            this.C_R24_T08.Text = "";
            this.C_R24_T08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T08.WordWrap = false;
            // 
            // C_R24_T09
            // 
            this.C_R24_T09.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T09.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T09.BorderWidth = 0.5F;
            this.C_R24_T09.CanGrow = false;
            this.C_R24_T09.Dpi = 100F;
            this.C_R24_T09.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T09.LocationFloat = new DevExpress.Utils.PointFloat(917F, 660F);
            this.C_R24_T09.Multiline = true;
            this.C_R24_T09.Name = "C_R24_T09";
            this.C_R24_T09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T09.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T09.StylePriority.UseFont = false;
            this.C_R24_T09.Text = "";
            this.C_R24_T09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T09.WordWrap = false;
            // 
            // C_R24_T10
            // 
            this.C_R24_T10.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T10.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T10.BorderWidth = 0.5F;
            this.C_R24_T10.CanGrow = false;
            this.C_R24_T10.Dpi = 100F;
            this.C_R24_T10.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T10.LocationFloat = new DevExpress.Utils.PointFloat(970F, 660F);
            this.C_R24_T10.Multiline = true;
            this.C_R24_T10.Name = "C_R24_T10";
            this.C_R24_T10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T10.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T10.StylePriority.UseFont = false;
            this.C_R24_T10.Text = "";
            this.C_R24_T10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T10.WordWrap = false;
            // 
            // C_R24_T11
            // 
            this.C_R24_T11.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T11.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T11.BorderWidth = 0.5F;
            this.C_R24_T11.CanGrow = false;
            this.C_R24_T11.Dpi = 100F;
            this.C_R24_T11.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T11.LocationFloat = new DevExpress.Utils.PointFloat(1023F, 660F);
            this.C_R24_T11.Multiline = true;
            this.C_R24_T11.Name = "C_R24_T11";
            this.C_R24_T11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T11.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T11.StylePriority.UseFont = false;
            this.C_R24_T11.Text = "";
            this.C_R24_T11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T11.WordWrap = false;
            // 
            // C_R24_T12
            // 
            this.C_R24_T12.BorderColor = System.Drawing.Color.Black;
            this.C_R24_T12.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_T12.BorderWidth = 0.5F;
            this.C_R24_T12.CanGrow = false;
            this.C_R24_T12.Dpi = 100F;
            this.C_R24_T12.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_T12.LocationFloat = new DevExpress.Utils.PointFloat(1076F, 660F);
            this.C_R24_T12.Multiline = true;
            this.C_R24_T12.Name = "C_R24_T12";
            this.C_R24_T12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_T12.SizeF = new System.Drawing.SizeF(53F, 22F);
            this.C_R24_T12.StylePriority.UseFont = false;
            this.C_R24_T12.Text = "";
            this.C_R24_T12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_T12.WordWrap = false;
            // 
            // L_REMARK
            // 
            this.L_REMARK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.L_REMARK.BorderColor = System.Drawing.Color.Black;
            this.L_REMARK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_REMARK.BorderWidth = 0.5F;
            this.L_REMARK.CanGrow = false;
            this.L_REMARK.Dpi = 100F;
            this.L_REMARK.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.L_REMARK.LocationFloat = new DevExpress.Utils.PointFloat(0F, 686F);
            this.L_REMARK.Multiline = true;
            this.L_REMARK.Name = "L_REMARK";
            this.L_REMARK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_REMARK.SizeF = new System.Drawing.SizeF(493F, 78F);
            this.L_REMARK.StylePriority.UseFont = false;
            this.L_REMARK.Text = "특 이 사 항";
            this.L_REMARK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_REMARK.WordWrap = false;
            // 
            // C_REMARK
            // 
            this.C_REMARK.BorderColor = System.Drawing.Color.Black;
            this.C_REMARK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_REMARK.BorderWidth = 0.5F;
            this.C_REMARK.CanGrow = false;
            this.C_REMARK.Dpi = 100F;
            this.C_REMARK.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.C_REMARK.LocationFloat = new DevExpress.Utils.PointFloat(493F, 686F);
            this.C_REMARK.Multiline = true;
            this.C_REMARK.Name = "C_REMARK";
            this.C_REMARK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_REMARK.SizeF = new System.Drawing.SizeF(636F, 78F);
            this.C_REMARK.StylePriority.UseFont = false;
            this.C_REMARK.Text = "";
            this.C_REMARK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.C_REMARK.WordWrap = true;
            // 
            // L_NOTE
            // 
            this.L_NOTE.CanGrow = false;
            this.L_NOTE.Dpi = 100F;
            this.L_NOTE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.L_NOTE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 766F);
            this.L_NOTE.Multiline = true;
            this.L_NOTE.Name = "L_NOTE";
            this.L_NOTE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_NOTE.SizeF = new System.Drawing.SizeF(900F, 18F);
            this.L_NOTE.StylePriority.UseFont = false;
            this.L_NOTE.Text = "※ 이상발생시 조·반장 / 라인 담당자에게 보고 후 공정 부적합품 처리절차에 따른다.";
            this.L_NOTE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_NOTE.WordWrap = false;
            // 
            // C_PAGE
            // 
            this.C_PAGE.CanGrow = false;
            this.C_PAGE.Dpi = 100F;
            this.C_PAGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_PAGE.LocationFloat = new DevExpress.Utils.PointFloat(929F, 766F);
            this.C_PAGE.Multiline = true;
            this.C_PAGE.Name = "C_PAGE";
            this.C_PAGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_PAGE.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_PAGE.StylePriority.UseFont = false;
            this.C_PAGE.Text = "";
            this.C_PAGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_PAGE.WordWrap = false;
            // 
            // S01
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.Detail});
            this.Dpi = 100F;
            this.Font = new System.Drawing.Font("맑은 고딕", 8F);
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
        private DevExpress.XtraReports.UI.XRLabel C_TITLE;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_H1;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_S1;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_H2;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_S2;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_H3;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_S3;
        private DevExpress.XtraReports.UI.XRLabel L_WORKDATE;
        private DevExpress.XtraReports.UI.XRLabel C_WORKDATE_TXT;
        private DevExpress.XtraReports.UI.XRLabel L_EMP;
        private DevExpress.XtraReports.UI.XRLabel L_DAY;
        private DevExpress.XtraReports.UI.XRLabel C_DAYEMP;
        private DevExpress.XtraReports.UI.XRLabel L_NIGHT;
        private DevExpress.XtraReports.UI.XRLabel C_NIGHTEMP;
        private DevExpress.XtraReports.UI.XRLabel L_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel C_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel C_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_ITEMBLANK;
        private DevExpress.XtraReports.UI.XRLabel L_T_PRC;
        private DevExpress.XtraReports.UI.XRLabel L_T_STD;
        private DevExpress.XtraReports.UI.XRLabel L_T_FEAT;
        private DevExpress.XtraReports.UI.XRLabel L_T_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_T_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel L_T_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel L_T_NO;
        private DevExpress.XtraReports.UI.XRLabel L_T_TIME;
        private DevExpress.XtraReports.UI.XRLabel C_H01;
        private DevExpress.XtraReports.UI.XRLabel C_H02;
        private DevExpress.XtraReports.UI.XRLabel C_H03;
        private DevExpress.XtraReports.UI.XRLabel C_H04;
        private DevExpress.XtraReports.UI.XRLabel C_H05;
        private DevExpress.XtraReports.UI.XRLabel C_H06;
        private DevExpress.XtraReports.UI.XRLabel C_H07;
        private DevExpress.XtraReports.UI.XRLabel C_H08;
        private DevExpress.XtraReports.UI.XRLabel C_H09;
        private DevExpress.XtraReports.UI.XRLabel C_H10;
        private DevExpress.XtraReports.UI.XRLabel C_H11;
        private DevExpress.XtraReports.UI.XRLabel C_H12;
        private DevExpress.XtraReports.UI.XRLabel C_R01_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R01_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R01_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R01_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R01_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R01_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R01_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R01_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R02_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R02_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R02_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R02_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R02_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R02_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R02_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R02_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R03_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R03_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R03_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R03_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R03_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R03_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R03_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R03_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R04_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R04_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R04_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R04_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R04_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R04_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R04_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R04_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R05_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R05_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R05_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R05_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R05_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R05_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R05_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R05_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R06_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R06_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R06_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R06_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R06_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R06_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R06_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R06_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R07_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R07_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R07_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R07_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R07_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R07_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R07_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R07_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R08_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R08_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R08_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R08_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R08_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R08_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R08_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R08_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R09_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R09_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R09_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R09_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R09_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R09_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R09_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R09_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R10_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R10_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R10_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R10_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R10_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R10_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R10_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R10_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R11_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R11_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R11_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R11_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R11_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R11_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R11_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R11_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R12_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R12_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R12_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R12_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R12_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R12_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R12_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R12_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R13_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R13_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R13_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R13_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R13_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R13_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R13_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R13_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R14_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R14_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R14_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R14_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R14_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R14_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R14_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R14_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R15_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R15_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R15_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R15_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R15_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R15_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R15_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R15_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R16_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R16_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R16_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R16_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R16_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R16_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R16_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R16_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R17_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R17_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R17_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R17_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R17_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R17_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R17_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R17_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R18_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R18_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R18_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R18_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R18_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R18_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R18_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R18_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R19_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R19_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R19_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R19_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R19_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R19_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R19_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R19_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R20_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R20_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R20_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R20_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R20_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R20_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R20_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R20_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R21_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R21_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R21_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R21_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R21_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R21_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R21_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R21_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R22_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R22_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R22_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R22_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R22_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R22_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R22_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R22_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R23_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R23_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R23_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R23_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R23_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R23_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R23_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R23_T12;
        private DevExpress.XtraReports.UI.XRLabel C_R24_PRC;
        private DevExpress.XtraReports.UI.XRLabel C_R24_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R24_FEAT;
        private DevExpress.XtraReports.UI.XRLabel C_R24_SPEC;
        private DevExpress.XtraReports.UI.XRLabel C_R24_CYCLE;
        private DevExpress.XtraReports.UI.XRLabel C_R24_GAUGE;
        private DevExpress.XtraReports.UI.XRLabel C_R24_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T01;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T02;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T03;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T04;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T05;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T06;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T07;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T08;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T09;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T10;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T11;
        private DevExpress.XtraReports.UI.XRLabel C_R24_T12;
        private DevExpress.XtraReports.UI.XRLabel L_REMARK;
        private DevExpress.XtraReports.UI.XRLabel C_REMARK;
        private DevExpress.XtraReports.UI.XRLabel L_NOTE;
        private DevExpress.XtraReports.UI.XRLabel C_PAGE;
    }
}
