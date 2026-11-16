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

        // 검사성적서(갑지) 양식. 출하검사 1건 = 1장 (전부 ReportHeader).
        // C_ 로 시작하는 칸에 R01.cs 가 이름으로 값을 넣는다. L_ 는 고정 글자이거나 비워 두는 칸.
        // 검사항목 줄: C_R{01~27}_{NO|STD|SPEC|X1~X5|XSPAN|JUDGE}. XSPAN 은 X1~X5 를 합친 칸 (평소엔 숨김)
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.L_TITLE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_TQMDATE_TXT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRVITEM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRVITEM_V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H1_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_ITEMNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H1_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SUPPLIER = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H2_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_ITEMCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H2_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_EONO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H3_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_MODELCD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_H3_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_GRADE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ISSUE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ISSUE_V = new DevExpress.XtraReports.UI.XRLabel();
            this.C_APRVMARK = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DEMAND = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SUPPLY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_H1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DEMAND_SIGN1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_H2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DEMAND_SIGN2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_APRV_H3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DEMAND_SIGN3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_EMPNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SUPPLY_SIGN2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_APRVEMPNM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_MEAS = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_UNIT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SUPPLY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_DEMAND = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_SJ = new DevExpress.XtraReports.UI.XRLabel();
            this.L_T_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R01_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R01_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R01_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R01_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R01_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R01_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R01_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R01_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R02_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R02_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R02_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R02_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R02_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R02_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R02_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R02_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R03_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R03_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R03_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R03_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R03_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R03_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R03_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R03_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R04_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R04_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R04_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R04_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R04_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R04_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R04_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R04_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R05_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R05_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R05_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R05_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R05_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R05_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R05_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R05_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R06_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R06_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R06_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R06_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R06_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R06_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R06_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R06_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R07_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R07_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R07_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R07_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R07_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R07_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R07_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R07_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R08_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R08_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R08_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R08_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R08_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R08_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R08_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R08_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R09_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R09_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R09_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R09_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R09_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R09_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R09_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R09_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R10_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R10_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R10_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R10_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R10_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R10_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R10_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R10_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R11_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R11_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R11_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R11_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R11_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R11_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R11_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R11_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R12_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R12_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R12_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R12_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R12_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R12_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R12_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R12_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R13_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R13_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R13_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R13_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R13_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R13_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R13_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R13_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R14_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R14_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R14_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R14_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R14_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R14_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R14_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R14_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R15_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R15_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R15_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R15_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R15_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R15_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R15_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R15_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R16_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R16_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R16_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R16_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R16_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R16_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R16_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R16_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R17_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R17_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R17_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R17_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R17_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R17_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R17_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R17_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R18_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R18_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R18_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R18_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R18_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R18_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R18_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R18_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R19_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R19_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R19_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R19_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R19_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R19_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R19_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R19_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R20_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R20_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R20_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R20_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R20_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R20_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R20_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R20_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R21_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R21_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R21_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R21_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R21_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R21_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R21_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R21_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R22_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R22_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R22_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R22_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R22_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R22_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R22_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R22_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R23_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R23_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R23_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R23_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R23_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R23_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R23_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R23_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R24_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R24_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R24_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R24_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R24_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R24_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R24_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R24_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R25_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R25_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R25_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R25_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R25_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R25_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R25_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R25_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R26_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R26_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R26_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R26_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R26_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R26_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R26_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R26_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_NO = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_STD = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_SPEC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R27_MGR = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_X1 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_X2 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_X3 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_X4 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_X5 = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_JUDGE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R27_DX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R27_DX2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R27_DX3 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R27_DX4 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R27_DX5 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_R27_DJ = new DevExpress.XtraReports.UI.XRLabel();
            this.C_R27_XSPAN = new DevExpress.XtraReports.UI.XRLabel();
            this.L_REMARK = new DevExpress.XtraReports.UI.XRLabel();
            this.C_QTY_TXT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NOTE = new DevExpress.XtraReports.UI.XRLabel();
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
            this.L_TITLE,
            this.C_TQMDATE_TXT,
            this.L_APRVITEM,
            this.L_APRVITEM_V,
            this.L_H1_1,
            this.C_ITEMNM,
            this.L_H1_2,
            this.L_SUPPLIER,
            this.L_H2_1,
            this.C_ITEMCD,
            this.L_H2_2,
            this.C_EONO,
            this.L_H3_1,
            this.C_MODELCD,
            this.L_H3_2,
            this.L_GRADE,
            this.L_ISSUE,
            this.L_ISSUE_V,
            this.C_APRVMARK,
            this.L_APRV,
            this.L_DEMAND,
            this.L_SUPPLY,
            this.L_APRV_H1,
            this.L_DEMAND_SIGN1,
            this.L_APRV_H2,
            this.L_DEMAND_SIGN2,
            this.L_APRV_H3,
            this.L_DEMAND_SIGN3,
            this.C_EMPNM,
            this.L_SUPPLY_SIGN2,
            this.C_APRVEMPNM,
            this.L_T_NO,
            this.L_T_STD,
            this.L_T_SPEC,
            this.L_T_MEAS,
            this.L_T_UNIT,
            this.L_T_SUPPLY,
            this.L_T_DEMAND,
            this.L_T_MGR,
            this.L_T_SX1,
            this.L_T_DX1,
            this.L_T_SX2,
            this.L_T_DX2,
            this.L_T_SX3,
            this.L_T_DX3,
            this.L_T_SX4,
            this.L_T_DX4,
            this.L_T_SX5,
            this.L_T_DX5,
            this.L_T_SJ,
            this.L_T_DJ,
            this.C_R01_NO,
            this.C_R01_STD,
            this.C_R01_SPEC,
            this.L_R01_MGR,
            this.C_R01_X1,
            this.C_R01_X2,
            this.C_R01_X3,
            this.C_R01_X4,
            this.C_R01_X5,
            this.C_R01_JUDGE,
            this.L_R01_DX1,
            this.L_R01_DX2,
            this.L_R01_DX3,
            this.L_R01_DX4,
            this.L_R01_DX5,
            this.L_R01_DJ,
            this.C_R01_XSPAN,
            this.C_R02_NO,
            this.C_R02_STD,
            this.C_R02_SPEC,
            this.L_R02_MGR,
            this.C_R02_X1,
            this.C_R02_X2,
            this.C_R02_X3,
            this.C_R02_X4,
            this.C_R02_X5,
            this.C_R02_JUDGE,
            this.L_R02_DX1,
            this.L_R02_DX2,
            this.L_R02_DX3,
            this.L_R02_DX4,
            this.L_R02_DX5,
            this.L_R02_DJ,
            this.C_R02_XSPAN,
            this.C_R03_NO,
            this.C_R03_STD,
            this.C_R03_SPEC,
            this.L_R03_MGR,
            this.C_R03_X1,
            this.C_R03_X2,
            this.C_R03_X3,
            this.C_R03_X4,
            this.C_R03_X5,
            this.C_R03_JUDGE,
            this.L_R03_DX1,
            this.L_R03_DX2,
            this.L_R03_DX3,
            this.L_R03_DX4,
            this.L_R03_DX5,
            this.L_R03_DJ,
            this.C_R03_XSPAN,
            this.C_R04_NO,
            this.C_R04_STD,
            this.C_R04_SPEC,
            this.L_R04_MGR,
            this.C_R04_X1,
            this.C_R04_X2,
            this.C_R04_X3,
            this.C_R04_X4,
            this.C_R04_X5,
            this.C_R04_JUDGE,
            this.L_R04_DX1,
            this.L_R04_DX2,
            this.L_R04_DX3,
            this.L_R04_DX4,
            this.L_R04_DX5,
            this.L_R04_DJ,
            this.C_R04_XSPAN,
            this.C_R05_NO,
            this.C_R05_STD,
            this.C_R05_SPEC,
            this.L_R05_MGR,
            this.C_R05_X1,
            this.C_R05_X2,
            this.C_R05_X3,
            this.C_R05_X4,
            this.C_R05_X5,
            this.C_R05_JUDGE,
            this.L_R05_DX1,
            this.L_R05_DX2,
            this.L_R05_DX3,
            this.L_R05_DX4,
            this.L_R05_DX5,
            this.L_R05_DJ,
            this.C_R05_XSPAN,
            this.C_R06_NO,
            this.C_R06_STD,
            this.C_R06_SPEC,
            this.L_R06_MGR,
            this.C_R06_X1,
            this.C_R06_X2,
            this.C_R06_X3,
            this.C_R06_X4,
            this.C_R06_X5,
            this.C_R06_JUDGE,
            this.L_R06_DX1,
            this.L_R06_DX2,
            this.L_R06_DX3,
            this.L_R06_DX4,
            this.L_R06_DX5,
            this.L_R06_DJ,
            this.C_R06_XSPAN,
            this.C_R07_NO,
            this.C_R07_STD,
            this.C_R07_SPEC,
            this.L_R07_MGR,
            this.C_R07_X1,
            this.C_R07_X2,
            this.C_R07_X3,
            this.C_R07_X4,
            this.C_R07_X5,
            this.C_R07_JUDGE,
            this.L_R07_DX1,
            this.L_R07_DX2,
            this.L_R07_DX3,
            this.L_R07_DX4,
            this.L_R07_DX5,
            this.L_R07_DJ,
            this.C_R07_XSPAN,
            this.C_R08_NO,
            this.C_R08_STD,
            this.C_R08_SPEC,
            this.L_R08_MGR,
            this.C_R08_X1,
            this.C_R08_X2,
            this.C_R08_X3,
            this.C_R08_X4,
            this.C_R08_X5,
            this.C_R08_JUDGE,
            this.L_R08_DX1,
            this.L_R08_DX2,
            this.L_R08_DX3,
            this.L_R08_DX4,
            this.L_R08_DX5,
            this.L_R08_DJ,
            this.C_R08_XSPAN,
            this.C_R09_NO,
            this.C_R09_STD,
            this.C_R09_SPEC,
            this.L_R09_MGR,
            this.C_R09_X1,
            this.C_R09_X2,
            this.C_R09_X3,
            this.C_R09_X4,
            this.C_R09_X5,
            this.C_R09_JUDGE,
            this.L_R09_DX1,
            this.L_R09_DX2,
            this.L_R09_DX3,
            this.L_R09_DX4,
            this.L_R09_DX5,
            this.L_R09_DJ,
            this.C_R09_XSPAN,
            this.C_R10_NO,
            this.C_R10_STD,
            this.C_R10_SPEC,
            this.L_R10_MGR,
            this.C_R10_X1,
            this.C_R10_X2,
            this.C_R10_X3,
            this.C_R10_X4,
            this.C_R10_X5,
            this.C_R10_JUDGE,
            this.L_R10_DX1,
            this.L_R10_DX2,
            this.L_R10_DX3,
            this.L_R10_DX4,
            this.L_R10_DX5,
            this.L_R10_DJ,
            this.C_R10_XSPAN,
            this.C_R11_NO,
            this.C_R11_STD,
            this.C_R11_SPEC,
            this.L_R11_MGR,
            this.C_R11_X1,
            this.C_R11_X2,
            this.C_R11_X3,
            this.C_R11_X4,
            this.C_R11_X5,
            this.C_R11_JUDGE,
            this.L_R11_DX1,
            this.L_R11_DX2,
            this.L_R11_DX3,
            this.L_R11_DX4,
            this.L_R11_DX5,
            this.L_R11_DJ,
            this.C_R11_XSPAN,
            this.C_R12_NO,
            this.C_R12_STD,
            this.C_R12_SPEC,
            this.L_R12_MGR,
            this.C_R12_X1,
            this.C_R12_X2,
            this.C_R12_X3,
            this.C_R12_X4,
            this.C_R12_X5,
            this.C_R12_JUDGE,
            this.L_R12_DX1,
            this.L_R12_DX2,
            this.L_R12_DX3,
            this.L_R12_DX4,
            this.L_R12_DX5,
            this.L_R12_DJ,
            this.C_R12_XSPAN,
            this.C_R13_NO,
            this.C_R13_STD,
            this.C_R13_SPEC,
            this.L_R13_MGR,
            this.C_R13_X1,
            this.C_R13_X2,
            this.C_R13_X3,
            this.C_R13_X4,
            this.C_R13_X5,
            this.C_R13_JUDGE,
            this.L_R13_DX1,
            this.L_R13_DX2,
            this.L_R13_DX3,
            this.L_R13_DX4,
            this.L_R13_DX5,
            this.L_R13_DJ,
            this.C_R13_XSPAN,
            this.C_R14_NO,
            this.C_R14_STD,
            this.C_R14_SPEC,
            this.L_R14_MGR,
            this.C_R14_X1,
            this.C_R14_X2,
            this.C_R14_X3,
            this.C_R14_X4,
            this.C_R14_X5,
            this.C_R14_JUDGE,
            this.L_R14_DX1,
            this.L_R14_DX2,
            this.L_R14_DX3,
            this.L_R14_DX4,
            this.L_R14_DX5,
            this.L_R14_DJ,
            this.C_R14_XSPAN,
            this.C_R15_NO,
            this.C_R15_STD,
            this.C_R15_SPEC,
            this.L_R15_MGR,
            this.C_R15_X1,
            this.C_R15_X2,
            this.C_R15_X3,
            this.C_R15_X4,
            this.C_R15_X5,
            this.C_R15_JUDGE,
            this.L_R15_DX1,
            this.L_R15_DX2,
            this.L_R15_DX3,
            this.L_R15_DX4,
            this.L_R15_DX5,
            this.L_R15_DJ,
            this.C_R15_XSPAN,
            this.C_R16_NO,
            this.C_R16_STD,
            this.C_R16_SPEC,
            this.L_R16_MGR,
            this.C_R16_X1,
            this.C_R16_X2,
            this.C_R16_X3,
            this.C_R16_X4,
            this.C_R16_X5,
            this.C_R16_JUDGE,
            this.L_R16_DX1,
            this.L_R16_DX2,
            this.L_R16_DX3,
            this.L_R16_DX4,
            this.L_R16_DX5,
            this.L_R16_DJ,
            this.C_R16_XSPAN,
            this.C_R17_NO,
            this.C_R17_STD,
            this.C_R17_SPEC,
            this.L_R17_MGR,
            this.C_R17_X1,
            this.C_R17_X2,
            this.C_R17_X3,
            this.C_R17_X4,
            this.C_R17_X5,
            this.C_R17_JUDGE,
            this.L_R17_DX1,
            this.L_R17_DX2,
            this.L_R17_DX3,
            this.L_R17_DX4,
            this.L_R17_DX5,
            this.L_R17_DJ,
            this.C_R17_XSPAN,
            this.C_R18_NO,
            this.C_R18_STD,
            this.C_R18_SPEC,
            this.L_R18_MGR,
            this.C_R18_X1,
            this.C_R18_X2,
            this.C_R18_X3,
            this.C_R18_X4,
            this.C_R18_X5,
            this.C_R18_JUDGE,
            this.L_R18_DX1,
            this.L_R18_DX2,
            this.L_R18_DX3,
            this.L_R18_DX4,
            this.L_R18_DX5,
            this.L_R18_DJ,
            this.C_R18_XSPAN,
            this.C_R19_NO,
            this.C_R19_STD,
            this.C_R19_SPEC,
            this.L_R19_MGR,
            this.C_R19_X1,
            this.C_R19_X2,
            this.C_R19_X3,
            this.C_R19_X4,
            this.C_R19_X5,
            this.C_R19_JUDGE,
            this.L_R19_DX1,
            this.L_R19_DX2,
            this.L_R19_DX3,
            this.L_R19_DX4,
            this.L_R19_DX5,
            this.L_R19_DJ,
            this.C_R19_XSPAN,
            this.C_R20_NO,
            this.C_R20_STD,
            this.C_R20_SPEC,
            this.L_R20_MGR,
            this.C_R20_X1,
            this.C_R20_X2,
            this.C_R20_X3,
            this.C_R20_X4,
            this.C_R20_X5,
            this.C_R20_JUDGE,
            this.L_R20_DX1,
            this.L_R20_DX2,
            this.L_R20_DX3,
            this.L_R20_DX4,
            this.L_R20_DX5,
            this.L_R20_DJ,
            this.C_R20_XSPAN,
            this.C_R21_NO,
            this.C_R21_STD,
            this.C_R21_SPEC,
            this.L_R21_MGR,
            this.C_R21_X1,
            this.C_R21_X2,
            this.C_R21_X3,
            this.C_R21_X4,
            this.C_R21_X5,
            this.C_R21_JUDGE,
            this.L_R21_DX1,
            this.L_R21_DX2,
            this.L_R21_DX3,
            this.L_R21_DX4,
            this.L_R21_DX5,
            this.L_R21_DJ,
            this.C_R21_XSPAN,
            this.C_R22_NO,
            this.C_R22_STD,
            this.C_R22_SPEC,
            this.L_R22_MGR,
            this.C_R22_X1,
            this.C_R22_X2,
            this.C_R22_X3,
            this.C_R22_X4,
            this.C_R22_X5,
            this.C_R22_JUDGE,
            this.L_R22_DX1,
            this.L_R22_DX2,
            this.L_R22_DX3,
            this.L_R22_DX4,
            this.L_R22_DX5,
            this.L_R22_DJ,
            this.C_R22_XSPAN,
            this.C_R23_NO,
            this.C_R23_STD,
            this.C_R23_SPEC,
            this.L_R23_MGR,
            this.C_R23_X1,
            this.C_R23_X2,
            this.C_R23_X3,
            this.C_R23_X4,
            this.C_R23_X5,
            this.C_R23_JUDGE,
            this.L_R23_DX1,
            this.L_R23_DX2,
            this.L_R23_DX3,
            this.L_R23_DX4,
            this.L_R23_DX5,
            this.L_R23_DJ,
            this.C_R23_XSPAN,
            this.C_R24_NO,
            this.C_R24_STD,
            this.C_R24_SPEC,
            this.L_R24_MGR,
            this.C_R24_X1,
            this.C_R24_X2,
            this.C_R24_X3,
            this.C_R24_X4,
            this.C_R24_X5,
            this.C_R24_JUDGE,
            this.L_R24_DX1,
            this.L_R24_DX2,
            this.L_R24_DX3,
            this.L_R24_DX4,
            this.L_R24_DX5,
            this.L_R24_DJ,
            this.C_R24_XSPAN,
            this.C_R25_NO,
            this.C_R25_STD,
            this.C_R25_SPEC,
            this.L_R25_MGR,
            this.C_R25_X1,
            this.C_R25_X2,
            this.C_R25_X3,
            this.C_R25_X4,
            this.C_R25_X5,
            this.C_R25_JUDGE,
            this.L_R25_DX1,
            this.L_R25_DX2,
            this.L_R25_DX3,
            this.L_R25_DX4,
            this.L_R25_DX5,
            this.L_R25_DJ,
            this.C_R25_XSPAN,
            this.C_R26_NO,
            this.C_R26_STD,
            this.C_R26_SPEC,
            this.L_R26_MGR,
            this.C_R26_X1,
            this.C_R26_X2,
            this.C_R26_X3,
            this.C_R26_X4,
            this.C_R26_X5,
            this.C_R26_JUDGE,
            this.L_R26_DX1,
            this.L_R26_DX2,
            this.L_R26_DX3,
            this.L_R26_DX4,
            this.L_R26_DX5,
            this.L_R26_DJ,
            this.C_R26_XSPAN,
            this.C_R27_NO,
            this.C_R27_STD,
            this.C_R27_SPEC,
            this.L_R27_MGR,
            this.C_R27_X1,
            this.C_R27_X2,
            this.C_R27_X3,
            this.C_R27_X4,
            this.C_R27_X5,
            this.C_R27_JUDGE,
            this.L_R27_DX1,
            this.L_R27_DX2,
            this.L_R27_DX3,
            this.L_R27_DX4,
            this.L_R27_DX5,
            this.L_R27_DJ,
            this.C_R27_XSPAN,
            this.L_REMARK,
            this.C_QTY_TXT,
            this.L_NOTE});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 1059F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // L_TITLE
            // 
            this.L_TITLE.CanGrow = false;
            this.L_TITLE.Dpi = 100F;
            this.L_TITLE.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.L_TITLE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.L_TITLE.Multiline = true;
            this.L_TITLE.Name = "L_TITLE";
            this.L_TITLE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TITLE.SizeF = new System.Drawing.SizeF(767F, 40F);
            this.L_TITLE.Text = "검 사 성 적 서  (갑지)";
            this.L_TITLE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_TITLE.WordWrap = false;
            // 
            // C_TQMDATE_TXT
            // 
            this.C_TQMDATE_TXT.CanGrow = false;
            this.C_TQMDATE_TXT.Dpi = 100F;
            this.C_TQMDATE_TXT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_TQMDATE_TXT.LocationFloat = new DevExpress.Utils.PointFloat(487F, 44F);
            this.C_TQMDATE_TXT.Multiline = true;
            this.C_TQMDATE_TXT.Name = "C_TQMDATE_TXT";
            this.C_TQMDATE_TXT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_TQMDATE_TXT.SizeF = new System.Drawing.SizeF(280F, 18F);
            this.C_TQMDATE_TXT.Text = "";
            this.C_TQMDATE_TXT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.C_TQMDATE_TXT.WordWrap = false;
            // 
            // L_APRVITEM
            // 
            this.L_APRVITEM.BorderColor = System.Drawing.Color.Black;
            this.L_APRVITEM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRVITEM.BorderWidth = 0.5F;
            this.L_APRVITEM.CanGrow = false;
            this.L_APRVITEM.Dpi = 100F;
            this.L_APRVITEM.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_APRVITEM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 64F);
            this.L_APRVITEM.Multiline = true;
            this.L_APRVITEM.Name = "L_APRVITEM";
            this.L_APRVITEM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRVITEM.SizeF = new System.Drawing.SizeF(76F, 23F);
            this.L_APRVITEM.Text = "승인항목";
            this.L_APRVITEM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRVITEM.WordWrap = false;
            // 
            // L_APRVITEM_V
            // 
            this.L_APRVITEM_V.BorderColor = System.Drawing.Color.Black;
            this.L_APRVITEM_V.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRVITEM_V.BorderWidth = 0.5F;
            this.L_APRVITEM_V.CanGrow = false;
            this.L_APRVITEM_V.Dpi = 100F;
            this.L_APRVITEM_V.LocationFloat = new DevExpress.Utils.PointFloat(76F, 64F);
            this.L_APRVITEM_V.Multiline = true;
            this.L_APRVITEM_V.Name = "L_APRVITEM_V";
            this.L_APRVITEM_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRVITEM_V.SizeF = new System.Drawing.SizeF(401F, 23F);
            this.L_APRVITEM_V.Text = " ■ 외관  ■ 치수  □ 재질(MS)  □ 성능(ES)";
            this.L_APRVITEM_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_APRVITEM_V.WordWrap = false;
            // 
            // L_H1_1
            // 
            this.L_H1_1.BorderColor = System.Drawing.Color.Black;
            this.L_H1_1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H1_1.BorderWidth = 0.5F;
            this.L_H1_1.CanGrow = false;
            this.L_H1_1.Dpi = 100F;
            this.L_H1_1.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_H1_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87F);
            this.L_H1_1.Multiline = true;
            this.L_H1_1.Name = "L_H1_1";
            this.L_H1_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_H1_1.SizeF = new System.Drawing.SizeF(76F, 44F);
            this.L_H1_1.Text = "품    명";
            this.L_H1_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H1_1.WordWrap = false;
            // 
            // C_ITEMNM
            // 
            this.C_ITEMNM.BorderColor = System.Drawing.Color.Black;
            this.C_ITEMNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_ITEMNM.BorderWidth = 0.5F;
            this.C_ITEMNM.CanGrow = false;
            this.C_ITEMNM.Dpi = 100F;
            this.C_ITEMNM.LocationFloat = new DevExpress.Utils.PointFloat(76F, 87F);
            this.C_ITEMNM.Multiline = true;
            this.C_ITEMNM.Name = "C_ITEMNM";
            this.C_ITEMNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_ITEMNM.SizeF = new System.Drawing.SizeF(160F, 44F);
            this.C_ITEMNM.Text = "";
            this.C_ITEMNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_ITEMNM.WordWrap = false;
            // 
            // L_H1_2
            // 
            this.L_H1_2.BorderColor = System.Drawing.Color.Black;
            this.L_H1_2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H1_2.BorderWidth = 0.5F;
            this.L_H1_2.CanGrow = false;
            this.L_H1_2.Dpi = 100F;
            this.L_H1_2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_H1_2.LocationFloat = new DevExpress.Utils.PointFloat(236F, 87F);
            this.L_H1_2.Multiline = true;
            this.L_H1_2.Name = "L_H1_2";
            this.L_H1_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_H1_2.SizeF = new System.Drawing.SizeF(118F, 44F);
            this.L_H1_2.Text = "공급자명";
            this.L_H1_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H1_2.WordWrap = false;
            // 
            // L_SUPPLIER
            // 
            this.L_SUPPLIER.BorderColor = System.Drawing.Color.Black;
            this.L_SUPPLIER.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_SUPPLIER.BorderWidth = 0.5F;
            this.L_SUPPLIER.CanGrow = false;
            this.L_SUPPLIER.Dpi = 100F;
            this.L_SUPPLIER.LocationFloat = new DevExpress.Utils.PointFloat(354F, 87F);
            this.L_SUPPLIER.Multiline = true;
            this.L_SUPPLIER.Name = "L_SUPPLIER";
            this.L_SUPPLIER.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_SUPPLIER.SizeF = new System.Drawing.SizeF(123F, 44F);
            this.L_SUPPLIER.Text = "S&S INC 2공장";
            this.L_SUPPLIER.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_SUPPLIER.WordWrap = false;
            // 
            // L_H2_1
            // 
            this.L_H2_1.BorderColor = System.Drawing.Color.Black;
            this.L_H2_1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H2_1.BorderWidth = 0.5F;
            this.L_H2_1.CanGrow = false;
            this.L_H2_1.Dpi = 100F;
            this.L_H2_1.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_H2_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 131F);
            this.L_H2_1.Multiline = true;
            this.L_H2_1.Name = "L_H2_1";
            this.L_H2_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_H2_1.SizeF = new System.Drawing.SizeF(76F, 42F);
            this.L_H2_1.Text = "품    번";
            this.L_H2_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H2_1.WordWrap = false;
            // 
            // C_ITEMCD
            // 
            this.C_ITEMCD.BorderColor = System.Drawing.Color.Black;
            this.C_ITEMCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_ITEMCD.BorderWidth = 0.5F;
            this.C_ITEMCD.CanGrow = false;
            this.C_ITEMCD.Dpi = 100F;
            this.C_ITEMCD.LocationFloat = new DevExpress.Utils.PointFloat(76F, 131F);
            this.C_ITEMCD.Multiline = true;
            this.C_ITEMCD.Name = "C_ITEMCD";
            this.C_ITEMCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_ITEMCD.SizeF = new System.Drawing.SizeF(160F, 42F);
            this.C_ITEMCD.Text = "";
            this.C_ITEMCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_ITEMCD.WordWrap = false;
            // 
            // L_H2_2
            // 
            this.L_H2_2.BorderColor = System.Drawing.Color.Black;
            this.L_H2_2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H2_2.BorderWidth = 0.5F;
            this.L_H2_2.CanGrow = false;
            this.L_H2_2.Dpi = 100F;
            this.L_H2_2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_H2_2.LocationFloat = new DevExpress.Utils.PointFloat(236F, 131F);
            this.L_H2_2.Multiline = true;
            this.L_H2_2.Name = "L_H2_2";
            this.L_H2_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_H2_2.SizeF = new System.Drawing.SizeF(118F, 42F);
            this.L_H2_2.Text = "EO  No";
            this.L_H2_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H2_2.WordWrap = false;
            // 
            // C_EONO
            // 
            this.C_EONO.BorderColor = System.Drawing.Color.Black;
            this.C_EONO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_EONO.BorderWidth = 0.5F;
            this.C_EONO.CanGrow = false;
            this.C_EONO.Dpi = 100F;
            this.C_EONO.LocationFloat = new DevExpress.Utils.PointFloat(354F, 131F);
            this.C_EONO.Multiline = true;
            this.C_EONO.Name = "C_EONO";
            this.C_EONO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_EONO.SizeF = new System.Drawing.SizeF(123F, 42F);
            this.C_EONO.Text = "";
            this.C_EONO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_EONO.WordWrap = false;
            // 
            // L_H3_1
            // 
            this.L_H3_1.BorderColor = System.Drawing.Color.Black;
            this.L_H3_1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H3_1.BorderWidth = 0.5F;
            this.L_H3_1.CanGrow = false;
            this.L_H3_1.Dpi = 100F;
            this.L_H3_1.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_H3_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 173F);
            this.L_H3_1.Multiline = true;
            this.L_H3_1.Name = "L_H3_1";
            this.L_H3_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_H3_1.SizeF = new System.Drawing.SizeF(76F, 40F);
            this.L_H3_1.Text = "차    종";
            this.L_H3_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H3_1.WordWrap = false;
            // 
            // C_MODELCD
            // 
            this.C_MODELCD.BorderColor = System.Drawing.Color.Black;
            this.C_MODELCD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_MODELCD.BorderWidth = 0.5F;
            this.C_MODELCD.CanGrow = false;
            this.C_MODELCD.Dpi = 100F;
            this.C_MODELCD.LocationFloat = new DevExpress.Utils.PointFloat(76F, 173F);
            this.C_MODELCD.Multiline = true;
            this.C_MODELCD.Name = "C_MODELCD";
            this.C_MODELCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_MODELCD.SizeF = new System.Drawing.SizeF(160F, 40F);
            this.C_MODELCD.Text = "";
            this.C_MODELCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_MODELCD.WordWrap = false;
            // 
            // L_H3_2
            // 
            this.L_H3_2.BorderColor = System.Drawing.Color.Black;
            this.L_H3_2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_H3_2.BorderWidth = 0.5F;
            this.L_H3_2.CanGrow = false;
            this.L_H3_2.Dpi = 100F;
            this.L_H3_2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_H3_2.LocationFloat = new DevExpress.Utils.PointFloat(236F, 173F);
            this.L_H3_2.Multiline = true;
            this.L_H3_2.Name = "L_H3_2";
            this.L_H3_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_H3_2.SizeF = new System.Drawing.SizeF(118F, 40F);
            this.L_H3_2.Text = "등  급";
            this.L_H3_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_H3_2.WordWrap = false;
            // 
            // L_GRADE
            // 
            this.L_GRADE.BorderColor = System.Drawing.Color.Black;
            this.L_GRADE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_GRADE.BorderWidth = 0.5F;
            this.L_GRADE.CanGrow = false;
            this.L_GRADE.Dpi = 100F;
            this.L_GRADE.LocationFloat = new DevExpress.Utils.PointFloat(354F, 173F);
            this.L_GRADE.Multiline = true;
            this.L_GRADE.Name = "L_GRADE";
            this.L_GRADE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_GRADE.SizeF = new System.Drawing.SizeF(123F, 40F);
            this.L_GRADE.Text = "";
            this.L_GRADE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_GRADE.WordWrap = false;
            // 
            // L_ISSUE
            // 
            this.L_ISSUE.BorderColor = System.Drawing.Color.Black;
            this.L_ISSUE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ISSUE.BorderWidth = 0.5F;
            this.L_ISSUE.CanGrow = false;
            this.L_ISSUE.Dpi = 100F;
            this.L_ISSUE.Font = new System.Drawing.Font("맑은 고딕", 7F, System.Drawing.FontStyle.Bold);
            this.L_ISSUE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 213F);
            this.L_ISSUE.Multiline = true;
            this.L_ISSUE.Name = "L_ISSUE";
            this.L_ISSUE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_ISSUE.SizeF = new System.Drawing.SizeF(76F, 30F);
            this.L_ISSUE.Text = "발행(승인)번호";
            this.L_ISSUE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ISSUE.WordWrap = false;
            // 
            // L_ISSUE_V
            // 
            this.L_ISSUE_V.BorderColor = System.Drawing.Color.Black;
            this.L_ISSUE_V.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_ISSUE_V.BorderWidth = 0.5F;
            this.L_ISSUE_V.CanGrow = false;
            this.L_ISSUE_V.Dpi = 100F;
            this.L_ISSUE_V.LocationFloat = new DevExpress.Utils.PointFloat(76F, 213F);
            this.L_ISSUE_V.Multiline = true;
            this.L_ISSUE_V.Name = "L_ISSUE_V";
            this.L_ISSUE_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_ISSUE_V.SizeF = new System.Drawing.SizeF(160F, 30F);
            this.L_ISSUE_V.Text = "";
            this.L_ISSUE_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_ISSUE_V.WordWrap = false;
            // 
            // C_APRVMARK
            // 
            this.C_APRVMARK.BorderColor = System.Drawing.Color.Black;
            this.C_APRVMARK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_APRVMARK.BorderWidth = 0.5F;
            this.C_APRVMARK.CanGrow = false;
            this.C_APRVMARK.Dpi = 100F;
            this.C_APRVMARK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.C_APRVMARK.LocationFloat = new DevExpress.Utils.PointFloat(236F, 213F);
            this.C_APRVMARK.Multiline = true;
            this.C_APRVMARK.Name = "C_APRVMARK";
            this.C_APRVMARK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_APRVMARK.SizeF = new System.Drawing.SizeF(531F, 30F);
            this.C_APRVMARK.Text = "";
            this.C_APRVMARK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_APRVMARK.WordWrap = false;
            // 
            // L_APRV
            // 
            this.L_APRV.BorderColor = System.Drawing.Color.Black;
            this.L_APRV.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV.BorderWidth = 0.5F;
            this.L_APRV.CanGrow = false;
            this.L_APRV.Dpi = 100F;
            this.L_APRV.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_APRV.LocationFloat = new DevExpress.Utils.PointFloat(477F, 64F);
            this.L_APRV.Multiline = true;
            this.L_APRV.Name = "L_APRV";
            this.L_APRV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV.SizeF = new System.Drawing.SizeF(290F, 23F);
            this.L_APRV.Text = "승   인";
            this.L_APRV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV.WordWrap = false;
            // 
            // L_DEMAND
            // 
            this.L_DEMAND.BorderColor = System.Drawing.Color.Black;
            this.L_DEMAND.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DEMAND.BorderWidth = 0.5F;
            this.L_DEMAND.CanGrow = false;
            this.L_DEMAND.Dpi = 100F;
            this.L_DEMAND.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_DEMAND.LocationFloat = new DevExpress.Utils.PointFloat(477F, 87F);
            this.L_DEMAND.Multiline = true;
            this.L_DEMAND.Name = "L_DEMAND";
            this.L_DEMAND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_DEMAND.SizeF = new System.Drawing.SizeF(51F, 67F);
            this.L_DEMAND.Text = "수\r\n요\r\n자";
            this.L_DEMAND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DEMAND.WordWrap = false;
            // 
            // L_SUPPLY
            // 
            this.L_SUPPLY.BorderColor = System.Drawing.Color.Black;
            this.L_SUPPLY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_SUPPLY.BorderWidth = 0.5F;
            this.L_SUPPLY.CanGrow = false;
            this.L_SUPPLY.Dpi = 100F;
            this.L_SUPPLY.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_SUPPLY.LocationFloat = new DevExpress.Utils.PointFloat(477F, 154F);
            this.L_SUPPLY.Multiline = true;
            this.L_SUPPLY.Name = "L_SUPPLY";
            this.L_SUPPLY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_SUPPLY.SizeF = new System.Drawing.SizeF(51F, 59F);
            this.L_SUPPLY.Text = "공\r\n급\r\n자";
            this.L_SUPPLY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_SUPPLY.WordWrap = false;
            // 
            // L_APRV_H1
            // 
            this.L_APRV_H1.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_H1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_H1.BorderWidth = 0.5F;
            this.L_APRV_H1.CanGrow = false;
            this.L_APRV_H1.Dpi = 100F;
            this.L_APRV_H1.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_APRV_H1.LocationFloat = new DevExpress.Utils.PointFloat(528F, 87F);
            this.L_APRV_H1.Multiline = true;
            this.L_APRV_H1.Name = "L_APRV_H1";
            this.L_APRV_H1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_H1.SizeF = new System.Drawing.SizeF(80F, 21F);
            this.L_APRV_H1.Text = "작 성";
            this.L_APRV_H1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_H1.WordWrap = false;
            // 
            // L_DEMAND_SIGN1
            // 
            this.L_DEMAND_SIGN1.BorderColor = System.Drawing.Color.Black;
            this.L_DEMAND_SIGN1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DEMAND_SIGN1.BorderWidth = 0.5F;
            this.L_DEMAND_SIGN1.CanGrow = false;
            this.L_DEMAND_SIGN1.Dpi = 100F;
            this.L_DEMAND_SIGN1.LocationFloat = new DevExpress.Utils.PointFloat(528F, 108F);
            this.L_DEMAND_SIGN1.Multiline = true;
            this.L_DEMAND_SIGN1.Name = "L_DEMAND_SIGN1";
            this.L_DEMAND_SIGN1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_DEMAND_SIGN1.SizeF = new System.Drawing.SizeF(80F, 46F);
            this.L_DEMAND_SIGN1.Text = "";
            this.L_DEMAND_SIGN1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DEMAND_SIGN1.WordWrap = false;
            // 
            // L_APRV_H2
            // 
            this.L_APRV_H2.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_H2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_H2.BorderWidth = 0.5F;
            this.L_APRV_H2.CanGrow = false;
            this.L_APRV_H2.Dpi = 100F;
            this.L_APRV_H2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_APRV_H2.LocationFloat = new DevExpress.Utils.PointFloat(608F, 87F);
            this.L_APRV_H2.Multiline = true;
            this.L_APRV_H2.Name = "L_APRV_H2";
            this.L_APRV_H2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_H2.SizeF = new System.Drawing.SizeF(79F, 21F);
            this.L_APRV_H2.Text = "검 토";
            this.L_APRV_H2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_H2.WordWrap = false;
            // 
            // L_DEMAND_SIGN2
            // 
            this.L_DEMAND_SIGN2.BorderColor = System.Drawing.Color.Black;
            this.L_DEMAND_SIGN2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DEMAND_SIGN2.BorderWidth = 0.5F;
            this.L_DEMAND_SIGN2.CanGrow = false;
            this.L_DEMAND_SIGN2.Dpi = 100F;
            this.L_DEMAND_SIGN2.LocationFloat = new DevExpress.Utils.PointFloat(608F, 108F);
            this.L_DEMAND_SIGN2.Multiline = true;
            this.L_DEMAND_SIGN2.Name = "L_DEMAND_SIGN2";
            this.L_DEMAND_SIGN2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_DEMAND_SIGN2.SizeF = new System.Drawing.SizeF(79F, 46F);
            this.L_DEMAND_SIGN2.Text = "";
            this.L_DEMAND_SIGN2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DEMAND_SIGN2.WordWrap = false;
            // 
            // L_APRV_H3
            // 
            this.L_APRV_H3.BorderColor = System.Drawing.Color.Black;
            this.L_APRV_H3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_APRV_H3.BorderWidth = 0.5F;
            this.L_APRV_H3.CanGrow = false;
            this.L_APRV_H3.Dpi = 100F;
            this.L_APRV_H3.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_APRV_H3.LocationFloat = new DevExpress.Utils.PointFloat(687F, 87F);
            this.L_APRV_H3.Multiline = true;
            this.L_APRV_H3.Name = "L_APRV_H3";
            this.L_APRV_H3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_APRV_H3.SizeF = new System.Drawing.SizeF(80F, 21F);
            this.L_APRV_H3.Text = "승 인";
            this.L_APRV_H3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_APRV_H3.WordWrap = false;
            // 
            // L_DEMAND_SIGN3
            // 
            this.L_DEMAND_SIGN3.BorderColor = System.Drawing.Color.Black;
            this.L_DEMAND_SIGN3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DEMAND_SIGN3.BorderWidth = 0.5F;
            this.L_DEMAND_SIGN3.CanGrow = false;
            this.L_DEMAND_SIGN3.Dpi = 100F;
            this.L_DEMAND_SIGN3.LocationFloat = new DevExpress.Utils.PointFloat(687F, 108F);
            this.L_DEMAND_SIGN3.Multiline = true;
            this.L_DEMAND_SIGN3.Name = "L_DEMAND_SIGN3";
            this.L_DEMAND_SIGN3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_DEMAND_SIGN3.SizeF = new System.Drawing.SizeF(80F, 46F);
            this.L_DEMAND_SIGN3.Text = "";
            this.L_DEMAND_SIGN3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_DEMAND_SIGN3.WordWrap = false;
            // 
            // C_EMPNM
            // 
            this.C_EMPNM.BorderColor = System.Drawing.Color.Black;
            this.C_EMPNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_EMPNM.BorderWidth = 0.5F;
            this.C_EMPNM.CanGrow = false;
            this.C_EMPNM.Dpi = 100F;
            this.C_EMPNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_EMPNM.LocationFloat = new DevExpress.Utils.PointFloat(528F, 154F);
            this.C_EMPNM.Multiline = true;
            this.C_EMPNM.Name = "C_EMPNM";
            this.C_EMPNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_EMPNM.SizeF = new System.Drawing.SizeF(80F, 59F);
            this.C_EMPNM.Text = "";
            this.C_EMPNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_EMPNM.WordWrap = false;
            // 
            // L_SUPPLY_SIGN2
            // 
            this.L_SUPPLY_SIGN2.BorderColor = System.Drawing.Color.Black;
            this.L_SUPPLY_SIGN2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_SUPPLY_SIGN2.BorderWidth = 0.5F;
            this.L_SUPPLY_SIGN2.CanGrow = false;
            this.L_SUPPLY_SIGN2.Dpi = 100F;
            this.L_SUPPLY_SIGN2.LocationFloat = new DevExpress.Utils.PointFloat(608F, 154F);
            this.L_SUPPLY_SIGN2.Multiline = true;
            this.L_SUPPLY_SIGN2.Name = "L_SUPPLY_SIGN2";
            this.L_SUPPLY_SIGN2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_SUPPLY_SIGN2.SizeF = new System.Drawing.SizeF(79F, 59F);
            this.L_SUPPLY_SIGN2.Text = "";
            this.L_SUPPLY_SIGN2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_SUPPLY_SIGN2.WordWrap = false;
            // 
            // C_APRVEMPNM
            // 
            this.C_APRVEMPNM.BorderColor = System.Drawing.Color.Black;
            this.C_APRVEMPNM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_APRVEMPNM.BorderWidth = 0.5F;
            this.C_APRVEMPNM.CanGrow = false;
            this.C_APRVEMPNM.Dpi = 100F;
            this.C_APRVEMPNM.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_APRVEMPNM.LocationFloat = new DevExpress.Utils.PointFloat(687F, 154F);
            this.C_APRVEMPNM.Multiline = true;
            this.C_APRVEMPNM.Name = "C_APRVEMPNM";
            this.C_APRVEMPNM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_APRVEMPNM.SizeF = new System.Drawing.SizeF(80F, 59F);
            this.C_APRVEMPNM.Text = "";
            this.C_APRVEMPNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_APRVEMPNM.WordWrap = false;
            // 
            // L_T_NO
            // 
            this.L_T_NO.BorderColor = System.Drawing.Color.Black;
            this.L_T_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_NO.BorderWidth = 0.5F;
            this.L_T_NO.CanGrow = false;
            this.L_T_NO.Dpi = 100F;
            this.L_T_NO.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_T_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 243F);
            this.L_T_NO.Multiline = true;
            this.L_T_NO.Name = "L_T_NO";
            this.L_T_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_NO.SizeF = new System.Drawing.SizeF(25F, 76F);
            this.L_T_NO.Text = "순\r\n\r\n번";
            this.L_T_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_NO.WordWrap = false;
            // 
            // L_T_STD
            // 
            this.L_T_STD.BorderColor = System.Drawing.Color.Black;
            this.L_T_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_STD.BorderWidth = 0.5F;
            this.L_T_STD.CanGrow = false;
            this.L_T_STD.Dpi = 100F;
            this.L_T_STD.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_T_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 243F);
            this.L_T_STD.Multiline = true;
            this.L_T_STD.Name = "L_T_STD";
            this.L_T_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_STD.SizeF = new System.Drawing.SizeF(112F, 76F);
            this.L_T_STD.Text = "검 사 항 목";
            this.L_T_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_STD.WordWrap = true;
            // 
            // L_T_SPEC
            // 
            this.L_T_SPEC.BorderColor = System.Drawing.Color.Black;
            this.L_T_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SPEC.BorderWidth = 0.5F;
            this.L_T_SPEC.CanGrow = false;
            this.L_T_SPEC.Dpi = 100F;
            this.L_T_SPEC.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_T_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 243F);
            this.L_T_SPEC.Multiline = true;
            this.L_T_SPEC.Name = "L_T_SPEC";
            this.L_T_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SPEC.SizeF = new System.Drawing.SizeF(99F, 76F);
            this.L_T_SPEC.Text = "규   격";
            this.L_T_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SPEC.WordWrap = true;
            // 
            // L_T_MEAS
            // 
            this.L_T_MEAS.BorderColor = System.Drawing.Color.Black;
            this.L_T_MEAS.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_MEAS.BorderWidth = 0.5F;
            this.L_T_MEAS.CanGrow = false;
            this.L_T_MEAS.Dpi = 100F;
            this.L_T_MEAS.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_T_MEAS.LocationFloat = new DevExpress.Utils.PointFloat(236F, 243F);
            this.L_T_MEAS.Multiline = true;
            this.L_T_MEAS.Name = "L_T_MEAS";
            this.L_T_MEAS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_MEAS.SizeF = new System.Drawing.SizeF(531F, 24F);
            this.L_T_MEAS.Text = "측    정    치";
            this.L_T_MEAS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_MEAS.WordWrap = false;
            // 
            // L_T_UNIT
            // 
            this.L_T_UNIT.CanGrow = false;
            this.L_T_UNIT.Dpi = 100F;
            this.L_T_UNIT.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_T_UNIT.LocationFloat = new DevExpress.Utils.PointFloat(687F, 243F);
            this.L_T_UNIT.Multiline = true;
            this.L_T_UNIT.Name = "L_T_UNIT";
            this.L_T_UNIT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_UNIT.SizeF = new System.Drawing.SizeF(80F, 24F);
            this.L_T_UNIT.Text = "(단위:㎛)";
            this.L_T_UNIT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_UNIT.WordWrap = false;
            // 
            // L_T_SUPPLY
            // 
            this.L_T_SUPPLY.BorderColor = System.Drawing.Color.Black;
            this.L_T_SUPPLY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SUPPLY.BorderWidth = 0.5F;
            this.L_T_SUPPLY.CanGrow = false;
            this.L_T_SUPPLY.Dpi = 100F;
            this.L_T_SUPPLY.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_T_SUPPLY.LocationFloat = new DevExpress.Utils.PointFloat(236F, 267F);
            this.L_T_SUPPLY.Multiline = true;
            this.L_T_SUPPLY.Name = "L_T_SUPPLY";
            this.L_T_SUPPLY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SUPPLY.SizeF = new System.Drawing.SizeF(283F, 22F);
            this.L_T_SUPPLY.Text = "공급자";
            this.L_T_SUPPLY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SUPPLY.WordWrap = false;
            // 
            // L_T_DEMAND
            // 
            this.L_T_DEMAND.BorderColor = System.Drawing.Color.Black;
            this.L_T_DEMAND.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_DEMAND.BorderWidth = 0.5F;
            this.L_T_DEMAND.CanGrow = false;
            this.L_T_DEMAND.Dpi = 100F;
            this.L_T_DEMAND.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.L_T_DEMAND.LocationFloat = new DevExpress.Utils.PointFloat(519F, 267F);
            this.L_T_DEMAND.Multiline = true;
            this.L_T_DEMAND.Name = "L_T_DEMAND";
            this.L_T_DEMAND.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_DEMAND.SizeF = new System.Drawing.SizeF(248F, 22F);
            this.L_T_DEMAND.Text = "수요자";
            this.L_T_DEMAND.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_DEMAND.WordWrap = false;
            // 
            // L_T_MGR
            // 
            this.L_T_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_T_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_MGR.BorderWidth = 0.5F;
            this.L_T_MGR.CanGrow = false;
            this.L_T_MGR.Dpi = 100F;
            this.L_T_MGR.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_T_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 289F);
            this.L_T_MGR.Multiline = true;
            this.L_T_MGR.Name = "L_T_MGR";
            this.L_T_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_MGR.SizeF = new System.Drawing.SizeF(35F, 30F);
            this.L_T_MGR.Text = "관리\r\n구분";
            this.L_T_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_MGR.WordWrap = false;
            // 
            // L_T_SX1
            // 
            this.L_T_SX1.BorderColor = System.Drawing.Color.Black;
            this.L_T_SX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SX1.BorderWidth = 0.5F;
            this.L_T_SX1.CanGrow = false;
            this.L_T_SX1.Dpi = 100F;
            this.L_T_SX1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 289F);
            this.L_T_SX1.Multiline = true;
            this.L_T_SX1.Name = "L_T_SX1";
            this.L_T_SX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SX1.SizeF = new System.Drawing.SizeF(41.2F, 30F);
            this.L_T_SX1.Text = "X1";
            this.L_T_SX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SX1.WordWrap = false;
            // 
            // L_T_DX1
            // 
            this.L_T_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_T_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_DX1.BorderWidth = 0.5F;
            this.L_T_DX1.CanGrow = false;
            this.L_T_DX1.Dpi = 100F;
            this.L_T_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 289F);
            this.L_T_DX1.Multiline = true;
            this.L_T_DX1.Name = "L_T_DX1";
            this.L_T_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_DX1.SizeF = new System.Drawing.SizeF(41.4F, 30F);
            this.L_T_DX1.Text = "X1";
            this.L_T_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_DX1.WordWrap = false;
            // 
            // L_T_SX2
            // 
            this.L_T_SX2.BorderColor = System.Drawing.Color.Black;
            this.L_T_SX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SX2.BorderWidth = 0.5F;
            this.L_T_SX2.CanGrow = false;
            this.L_T_SX2.Dpi = 100F;
            this.L_T_SX2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 289F);
            this.L_T_SX2.Multiline = true;
            this.L_T_SX2.Name = "L_T_SX2";
            this.L_T_SX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SX2.SizeF = new System.Drawing.SizeF(41.2F, 30F);
            this.L_T_SX2.Text = "X2";
            this.L_T_SX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SX2.WordWrap = false;
            // 
            // L_T_DX2
            // 
            this.L_T_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_T_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_DX2.BorderWidth = 0.5F;
            this.L_T_DX2.CanGrow = false;
            this.L_T_DX2.Dpi = 100F;
            this.L_T_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 289F);
            this.L_T_DX2.Multiline = true;
            this.L_T_DX2.Name = "L_T_DX2";
            this.L_T_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_DX2.SizeF = new System.Drawing.SizeF(41.4F, 30F);
            this.L_T_DX2.Text = "X2";
            this.L_T_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_DX2.WordWrap = false;
            // 
            // L_T_SX3
            // 
            this.L_T_SX3.BorderColor = System.Drawing.Color.Black;
            this.L_T_SX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SX3.BorderWidth = 0.5F;
            this.L_T_SX3.CanGrow = false;
            this.L_T_SX3.Dpi = 100F;
            this.L_T_SX3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 289F);
            this.L_T_SX3.Multiline = true;
            this.L_T_SX3.Name = "L_T_SX3";
            this.L_T_SX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SX3.SizeF = new System.Drawing.SizeF(41.2F, 30F);
            this.L_T_SX3.Text = "X3";
            this.L_T_SX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SX3.WordWrap = false;
            // 
            // L_T_DX3
            // 
            this.L_T_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_T_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_DX3.BorderWidth = 0.5F;
            this.L_T_DX3.CanGrow = false;
            this.L_T_DX3.Dpi = 100F;
            this.L_T_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 289F);
            this.L_T_DX3.Multiline = true;
            this.L_T_DX3.Name = "L_T_DX3";
            this.L_T_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_DX3.SizeF = new System.Drawing.SizeF(41.4F, 30F);
            this.L_T_DX3.Text = "X3";
            this.L_T_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_DX3.WordWrap = false;
            // 
            // L_T_SX4
            // 
            this.L_T_SX4.BorderColor = System.Drawing.Color.Black;
            this.L_T_SX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SX4.BorderWidth = 0.5F;
            this.L_T_SX4.CanGrow = false;
            this.L_T_SX4.Dpi = 100F;
            this.L_T_SX4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 289F);
            this.L_T_SX4.Multiline = true;
            this.L_T_SX4.Name = "L_T_SX4";
            this.L_T_SX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SX4.SizeF = new System.Drawing.SizeF(41.2F, 30F);
            this.L_T_SX4.Text = "X4";
            this.L_T_SX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SX4.WordWrap = false;
            // 
            // L_T_DX4
            // 
            this.L_T_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_T_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_DX4.BorderWidth = 0.5F;
            this.L_T_DX4.CanGrow = false;
            this.L_T_DX4.Dpi = 100F;
            this.L_T_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 289F);
            this.L_T_DX4.Multiline = true;
            this.L_T_DX4.Name = "L_T_DX4";
            this.L_T_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_DX4.SizeF = new System.Drawing.SizeF(41.4F, 30F);
            this.L_T_DX4.Text = "X4";
            this.L_T_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_DX4.WordWrap = false;
            // 
            // L_T_SX5
            // 
            this.L_T_SX5.BorderColor = System.Drawing.Color.Black;
            this.L_T_SX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SX5.BorderWidth = 0.5F;
            this.L_T_SX5.CanGrow = false;
            this.L_T_SX5.Dpi = 100F;
            this.L_T_SX5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 289F);
            this.L_T_SX5.Multiline = true;
            this.L_T_SX5.Name = "L_T_SX5";
            this.L_T_SX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SX5.SizeF = new System.Drawing.SizeF(41.2F, 30F);
            this.L_T_SX5.Text = "X5";
            this.L_T_SX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SX5.WordWrap = false;
            // 
            // L_T_DX5
            // 
            this.L_T_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_T_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_DX5.BorderWidth = 0.5F;
            this.L_T_DX5.CanGrow = false;
            this.L_T_DX5.Dpi = 100F;
            this.L_T_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 289F);
            this.L_T_DX5.Multiline = true;
            this.L_T_DX5.Name = "L_T_DX5";
            this.L_T_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_DX5.SizeF = new System.Drawing.SizeF(41.4F, 30F);
            this.L_T_DX5.Text = "X5";
            this.L_T_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_DX5.WordWrap = false;
            // 
            // L_T_SJ
            // 
            this.L_T_SJ.BorderColor = System.Drawing.Color.Black;
            this.L_T_SJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_SJ.BorderWidth = 0.5F;
            this.L_T_SJ.CanGrow = false;
            this.L_T_SJ.Dpi = 100F;
            this.L_T_SJ.LocationFloat = new DevExpress.Utils.PointFloat(477F, 289F);
            this.L_T_SJ.Multiline = true;
            this.L_T_SJ.Name = "L_T_SJ";
            this.L_T_SJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_SJ.SizeF = new System.Drawing.SizeF(42F, 30F);
            this.L_T_SJ.Text = "판정";
            this.L_T_SJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_SJ.WordWrap = false;
            // 
            // L_T_DJ
            // 
            this.L_T_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_T_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_T_DJ.BorderWidth = 0.5F;
            this.L_T_DJ.CanGrow = false;
            this.L_T_DJ.Dpi = 100F;
            this.L_T_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 289F);
            this.L_T_DJ.Multiline = true;
            this.L_T_DJ.Name = "L_T_DJ";
            this.L_T_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_T_DJ.SizeF = new System.Drawing.SizeF(41F, 30F);
            this.L_T_DJ.Text = "판정";
            this.L_T_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_T_DJ.WordWrap = false;
            // 
            // C_R01_NO
            // 
            this.C_R01_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R01_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_NO.BorderWidth = 0.5F;
            this.C_R01_NO.CanGrow = false;
            this.C_R01_NO.Dpi = 100F;
            this.C_R01_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 319F);
            this.C_R01_NO.Multiline = true;
            this.C_R01_NO.Name = "C_R01_NO";
            this.C_R01_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R01_NO.Text = "";
            this.C_R01_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_NO.WordWrap = false;
            // 
            // C_R01_STD
            // 
            this.C_R01_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R01_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_STD.BorderWidth = 0.5F;
            this.C_R01_STD.CanGrow = false;
            this.C_R01_STD.Dpi = 100F;
            this.C_R01_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R01_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 319F);
            this.C_R01_STD.Multiline = true;
            this.C_R01_STD.Name = "C_R01_STD";
            this.C_R01_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R01_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R01_STD.Text = "";
            this.C_R01_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R01_STD.WordWrap = true;
            // 
            // C_R01_SPEC
            // 
            this.C_R01_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R01_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_SPEC.BorderWidth = 0.5F;
            this.C_R01_SPEC.CanGrow = false;
            this.C_R01_SPEC.Dpi = 100F;
            this.C_R01_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R01_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 319F);
            this.C_R01_SPEC.Multiline = true;
            this.C_R01_SPEC.Name = "C_R01_SPEC";
            this.C_R01_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R01_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R01_SPEC.Text = "";
            this.C_R01_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R01_SPEC.WordWrap = true;
            // 
            // L_R01_MGR
            // 
            this.L_R01_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R01_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R01_MGR.BorderWidth = 0.5F;
            this.L_R01_MGR.CanGrow = false;
            this.L_R01_MGR.Dpi = 100F;
            this.L_R01_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 319F);
            this.L_R01_MGR.Multiline = true;
            this.L_R01_MGR.Name = "L_R01_MGR";
            this.L_R01_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R01_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R01_MGR.Text = "";
            this.L_R01_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R01_MGR.WordWrap = false;
            // 
            // C_R01_X1
            // 
            this.C_R01_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R01_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_X1.BorderWidth = 0.5F;
            this.C_R01_X1.CanGrow = false;
            this.C_R01_X1.Dpi = 100F;
            this.C_R01_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 319F);
            this.C_R01_X1.Multiline = true;
            this.C_R01_X1.Name = "C_R01_X1";
            this.C_R01_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R01_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R01_X1.Text = "";
            this.C_R01_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_X1.WordWrap = false;
            // 
            // C_R01_X2
            // 
            this.C_R01_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R01_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_X2.BorderWidth = 0.5F;
            this.C_R01_X2.CanGrow = false;
            this.C_R01_X2.Dpi = 100F;
            this.C_R01_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 319F);
            this.C_R01_X2.Multiline = true;
            this.C_R01_X2.Name = "C_R01_X2";
            this.C_R01_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R01_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R01_X2.Text = "";
            this.C_R01_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_X2.WordWrap = false;
            // 
            // C_R01_X3
            // 
            this.C_R01_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R01_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_X3.BorderWidth = 0.5F;
            this.C_R01_X3.CanGrow = false;
            this.C_R01_X3.Dpi = 100F;
            this.C_R01_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 319F);
            this.C_R01_X3.Multiline = true;
            this.C_R01_X3.Name = "C_R01_X3";
            this.C_R01_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R01_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R01_X3.Text = "";
            this.C_R01_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_X3.WordWrap = false;
            // 
            // C_R01_X4
            // 
            this.C_R01_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R01_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_X4.BorderWidth = 0.5F;
            this.C_R01_X4.CanGrow = false;
            this.C_R01_X4.Dpi = 100F;
            this.C_R01_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 319F);
            this.C_R01_X4.Multiline = true;
            this.C_R01_X4.Name = "C_R01_X4";
            this.C_R01_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R01_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R01_X4.Text = "";
            this.C_R01_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_X4.WordWrap = false;
            // 
            // C_R01_X5
            // 
            this.C_R01_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R01_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_X5.BorderWidth = 0.5F;
            this.C_R01_X5.CanGrow = false;
            this.C_R01_X5.Dpi = 100F;
            this.C_R01_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R01_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 319F);
            this.C_R01_X5.Multiline = true;
            this.C_R01_X5.Name = "C_R01_X5";
            this.C_R01_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R01_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R01_X5.Text = "";
            this.C_R01_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_X5.WordWrap = false;
            // 
            // C_R01_JUDGE
            // 
            this.C_R01_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R01_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_JUDGE.BorderWidth = 0.5F;
            this.C_R01_JUDGE.CanGrow = false;
            this.C_R01_JUDGE.Dpi = 100F;
            this.C_R01_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 319F);
            this.C_R01_JUDGE.Multiline = true;
            this.C_R01_JUDGE.Name = "C_R01_JUDGE";
            this.C_R01_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R01_JUDGE.Text = "";
            this.C_R01_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_JUDGE.WordWrap = false;
            // 
            // L_R01_DX1
            // 
            this.L_R01_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R01_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R01_DX1.BorderWidth = 0.5F;
            this.L_R01_DX1.CanGrow = false;
            this.L_R01_DX1.Dpi = 100F;
            this.L_R01_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 319F);
            this.L_R01_DX1.Multiline = true;
            this.L_R01_DX1.Name = "L_R01_DX1";
            this.L_R01_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R01_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R01_DX1.Text = "";
            this.L_R01_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R01_DX1.WordWrap = false;
            // 
            // L_R01_DX2
            // 
            this.L_R01_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R01_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R01_DX2.BorderWidth = 0.5F;
            this.L_R01_DX2.CanGrow = false;
            this.L_R01_DX2.Dpi = 100F;
            this.L_R01_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 319F);
            this.L_R01_DX2.Multiline = true;
            this.L_R01_DX2.Name = "L_R01_DX2";
            this.L_R01_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R01_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R01_DX2.Text = "";
            this.L_R01_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R01_DX2.WordWrap = false;
            // 
            // L_R01_DX3
            // 
            this.L_R01_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R01_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R01_DX3.BorderWidth = 0.5F;
            this.L_R01_DX3.CanGrow = false;
            this.L_R01_DX3.Dpi = 100F;
            this.L_R01_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 319F);
            this.L_R01_DX3.Multiline = true;
            this.L_R01_DX3.Name = "L_R01_DX3";
            this.L_R01_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R01_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R01_DX3.Text = "";
            this.L_R01_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R01_DX3.WordWrap = false;
            // 
            // L_R01_DX4
            // 
            this.L_R01_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R01_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R01_DX4.BorderWidth = 0.5F;
            this.L_R01_DX4.CanGrow = false;
            this.L_R01_DX4.Dpi = 100F;
            this.L_R01_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 319F);
            this.L_R01_DX4.Multiline = true;
            this.L_R01_DX4.Name = "L_R01_DX4";
            this.L_R01_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R01_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R01_DX4.Text = "";
            this.L_R01_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R01_DX4.WordWrap = false;
            // 
            // L_R01_DX5
            // 
            this.L_R01_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R01_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R01_DX5.BorderWidth = 0.5F;
            this.L_R01_DX5.CanGrow = false;
            this.L_R01_DX5.Dpi = 100F;
            this.L_R01_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 319F);
            this.L_R01_DX5.Multiline = true;
            this.L_R01_DX5.Name = "L_R01_DX5";
            this.L_R01_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R01_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R01_DX5.Text = "";
            this.L_R01_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R01_DX5.WordWrap = false;
            // 
            // L_R01_DJ
            // 
            this.L_R01_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R01_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R01_DJ.BorderWidth = 0.5F;
            this.L_R01_DJ.CanGrow = false;
            this.L_R01_DJ.Dpi = 100F;
            this.L_R01_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 319F);
            this.L_R01_DJ.Multiline = true;
            this.L_R01_DJ.Name = "L_R01_DJ";
            this.L_R01_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R01_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R01_DJ.Text = "";
            this.L_R01_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R01_DJ.WordWrap = false;
            // 
            // C_R01_XSPAN
            // 
            this.C_R01_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R01_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R01_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R01_XSPAN.BorderWidth = 0.5F;
            this.C_R01_XSPAN.CanGrow = false;
            this.C_R01_XSPAN.Dpi = 100F;
            this.C_R01_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R01_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 319F);
            this.C_R01_XSPAN.Multiline = true;
            this.C_R01_XSPAN.Name = "C_R01_XSPAN";
            this.C_R01_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R01_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R01_XSPAN.Text = "";
            this.C_R01_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R01_XSPAN.Visible = false;
            this.C_R01_XSPAN.WordWrap = false;
            // 
            // C_R02_NO
            // 
            this.C_R02_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R02_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_NO.BorderWidth = 0.5F;
            this.C_R02_NO.CanGrow = false;
            this.C_R02_NO.Dpi = 100F;
            this.C_R02_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 343F);
            this.C_R02_NO.Multiline = true;
            this.C_R02_NO.Name = "C_R02_NO";
            this.C_R02_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R02_NO.Text = "";
            this.C_R02_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_NO.WordWrap = false;
            // 
            // C_R02_STD
            // 
            this.C_R02_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R02_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_STD.BorderWidth = 0.5F;
            this.C_R02_STD.CanGrow = false;
            this.C_R02_STD.Dpi = 100F;
            this.C_R02_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R02_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 343F);
            this.C_R02_STD.Multiline = true;
            this.C_R02_STD.Name = "C_R02_STD";
            this.C_R02_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R02_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R02_STD.Text = "";
            this.C_R02_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R02_STD.WordWrap = true;
            // 
            // C_R02_SPEC
            // 
            this.C_R02_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R02_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_SPEC.BorderWidth = 0.5F;
            this.C_R02_SPEC.CanGrow = false;
            this.C_R02_SPEC.Dpi = 100F;
            this.C_R02_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R02_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 343F);
            this.C_R02_SPEC.Multiline = true;
            this.C_R02_SPEC.Name = "C_R02_SPEC";
            this.C_R02_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R02_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R02_SPEC.Text = "";
            this.C_R02_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R02_SPEC.WordWrap = true;
            // 
            // L_R02_MGR
            // 
            this.L_R02_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R02_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R02_MGR.BorderWidth = 0.5F;
            this.L_R02_MGR.CanGrow = false;
            this.L_R02_MGR.Dpi = 100F;
            this.L_R02_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 343F);
            this.L_R02_MGR.Multiline = true;
            this.L_R02_MGR.Name = "L_R02_MGR";
            this.L_R02_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R02_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R02_MGR.Text = "";
            this.L_R02_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R02_MGR.WordWrap = false;
            // 
            // C_R02_X1
            // 
            this.C_R02_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R02_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_X1.BorderWidth = 0.5F;
            this.C_R02_X1.CanGrow = false;
            this.C_R02_X1.Dpi = 100F;
            this.C_R02_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 343F);
            this.C_R02_X1.Multiline = true;
            this.C_R02_X1.Name = "C_R02_X1";
            this.C_R02_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R02_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R02_X1.Text = "";
            this.C_R02_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_X1.WordWrap = false;
            // 
            // C_R02_X2
            // 
            this.C_R02_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R02_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_X2.BorderWidth = 0.5F;
            this.C_R02_X2.CanGrow = false;
            this.C_R02_X2.Dpi = 100F;
            this.C_R02_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 343F);
            this.C_R02_X2.Multiline = true;
            this.C_R02_X2.Name = "C_R02_X2";
            this.C_R02_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R02_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R02_X2.Text = "";
            this.C_R02_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_X2.WordWrap = false;
            // 
            // C_R02_X3
            // 
            this.C_R02_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R02_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_X3.BorderWidth = 0.5F;
            this.C_R02_X3.CanGrow = false;
            this.C_R02_X3.Dpi = 100F;
            this.C_R02_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 343F);
            this.C_R02_X3.Multiline = true;
            this.C_R02_X3.Name = "C_R02_X3";
            this.C_R02_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R02_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R02_X3.Text = "";
            this.C_R02_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_X3.WordWrap = false;
            // 
            // C_R02_X4
            // 
            this.C_R02_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R02_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_X4.BorderWidth = 0.5F;
            this.C_R02_X4.CanGrow = false;
            this.C_R02_X4.Dpi = 100F;
            this.C_R02_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 343F);
            this.C_R02_X4.Multiline = true;
            this.C_R02_X4.Name = "C_R02_X4";
            this.C_R02_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R02_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R02_X4.Text = "";
            this.C_R02_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_X4.WordWrap = false;
            // 
            // C_R02_X5
            // 
            this.C_R02_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R02_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_X5.BorderWidth = 0.5F;
            this.C_R02_X5.CanGrow = false;
            this.C_R02_X5.Dpi = 100F;
            this.C_R02_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R02_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 343F);
            this.C_R02_X5.Multiline = true;
            this.C_R02_X5.Name = "C_R02_X5";
            this.C_R02_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R02_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R02_X5.Text = "";
            this.C_R02_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_X5.WordWrap = false;
            // 
            // C_R02_JUDGE
            // 
            this.C_R02_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R02_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_JUDGE.BorderWidth = 0.5F;
            this.C_R02_JUDGE.CanGrow = false;
            this.C_R02_JUDGE.Dpi = 100F;
            this.C_R02_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 343F);
            this.C_R02_JUDGE.Multiline = true;
            this.C_R02_JUDGE.Name = "C_R02_JUDGE";
            this.C_R02_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R02_JUDGE.Text = "";
            this.C_R02_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_JUDGE.WordWrap = false;
            // 
            // L_R02_DX1
            // 
            this.L_R02_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R02_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R02_DX1.BorderWidth = 0.5F;
            this.L_R02_DX1.CanGrow = false;
            this.L_R02_DX1.Dpi = 100F;
            this.L_R02_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 343F);
            this.L_R02_DX1.Multiline = true;
            this.L_R02_DX1.Name = "L_R02_DX1";
            this.L_R02_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R02_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R02_DX1.Text = "";
            this.L_R02_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R02_DX1.WordWrap = false;
            // 
            // L_R02_DX2
            // 
            this.L_R02_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R02_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R02_DX2.BorderWidth = 0.5F;
            this.L_R02_DX2.CanGrow = false;
            this.L_R02_DX2.Dpi = 100F;
            this.L_R02_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 343F);
            this.L_R02_DX2.Multiline = true;
            this.L_R02_DX2.Name = "L_R02_DX2";
            this.L_R02_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R02_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R02_DX2.Text = "";
            this.L_R02_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R02_DX2.WordWrap = false;
            // 
            // L_R02_DX3
            // 
            this.L_R02_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R02_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R02_DX3.BorderWidth = 0.5F;
            this.L_R02_DX3.CanGrow = false;
            this.L_R02_DX3.Dpi = 100F;
            this.L_R02_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 343F);
            this.L_R02_DX3.Multiline = true;
            this.L_R02_DX3.Name = "L_R02_DX3";
            this.L_R02_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R02_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R02_DX3.Text = "";
            this.L_R02_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R02_DX3.WordWrap = false;
            // 
            // L_R02_DX4
            // 
            this.L_R02_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R02_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R02_DX4.BorderWidth = 0.5F;
            this.L_R02_DX4.CanGrow = false;
            this.L_R02_DX4.Dpi = 100F;
            this.L_R02_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 343F);
            this.L_R02_DX4.Multiline = true;
            this.L_R02_DX4.Name = "L_R02_DX4";
            this.L_R02_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R02_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R02_DX4.Text = "";
            this.L_R02_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R02_DX4.WordWrap = false;
            // 
            // L_R02_DX5
            // 
            this.L_R02_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R02_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R02_DX5.BorderWidth = 0.5F;
            this.L_R02_DX5.CanGrow = false;
            this.L_R02_DX5.Dpi = 100F;
            this.L_R02_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 343F);
            this.L_R02_DX5.Multiline = true;
            this.L_R02_DX5.Name = "L_R02_DX5";
            this.L_R02_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R02_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R02_DX5.Text = "";
            this.L_R02_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R02_DX5.WordWrap = false;
            // 
            // L_R02_DJ
            // 
            this.L_R02_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R02_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R02_DJ.BorderWidth = 0.5F;
            this.L_R02_DJ.CanGrow = false;
            this.L_R02_DJ.Dpi = 100F;
            this.L_R02_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 343F);
            this.L_R02_DJ.Multiline = true;
            this.L_R02_DJ.Name = "L_R02_DJ";
            this.L_R02_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R02_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R02_DJ.Text = "";
            this.L_R02_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R02_DJ.WordWrap = false;
            // 
            // C_R02_XSPAN
            // 
            this.C_R02_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R02_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R02_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R02_XSPAN.BorderWidth = 0.5F;
            this.C_R02_XSPAN.CanGrow = false;
            this.C_R02_XSPAN.Dpi = 100F;
            this.C_R02_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R02_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 343F);
            this.C_R02_XSPAN.Multiline = true;
            this.C_R02_XSPAN.Name = "C_R02_XSPAN";
            this.C_R02_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R02_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R02_XSPAN.Text = "";
            this.C_R02_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R02_XSPAN.Visible = false;
            this.C_R02_XSPAN.WordWrap = false;
            // 
            // C_R03_NO
            // 
            this.C_R03_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R03_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_NO.BorderWidth = 0.5F;
            this.C_R03_NO.CanGrow = false;
            this.C_R03_NO.Dpi = 100F;
            this.C_R03_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 367F);
            this.C_R03_NO.Multiline = true;
            this.C_R03_NO.Name = "C_R03_NO";
            this.C_R03_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R03_NO.Text = "";
            this.C_R03_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_NO.WordWrap = false;
            // 
            // C_R03_STD
            // 
            this.C_R03_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R03_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_STD.BorderWidth = 0.5F;
            this.C_R03_STD.CanGrow = false;
            this.C_R03_STD.Dpi = 100F;
            this.C_R03_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R03_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 367F);
            this.C_R03_STD.Multiline = true;
            this.C_R03_STD.Name = "C_R03_STD";
            this.C_R03_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R03_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R03_STD.Text = "";
            this.C_R03_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R03_STD.WordWrap = true;
            // 
            // C_R03_SPEC
            // 
            this.C_R03_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R03_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_SPEC.BorderWidth = 0.5F;
            this.C_R03_SPEC.CanGrow = false;
            this.C_R03_SPEC.Dpi = 100F;
            this.C_R03_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R03_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 367F);
            this.C_R03_SPEC.Multiline = true;
            this.C_R03_SPEC.Name = "C_R03_SPEC";
            this.C_R03_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R03_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R03_SPEC.Text = "";
            this.C_R03_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R03_SPEC.WordWrap = true;
            // 
            // L_R03_MGR
            // 
            this.L_R03_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R03_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R03_MGR.BorderWidth = 0.5F;
            this.L_R03_MGR.CanGrow = false;
            this.L_R03_MGR.Dpi = 100F;
            this.L_R03_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 367F);
            this.L_R03_MGR.Multiline = true;
            this.L_R03_MGR.Name = "L_R03_MGR";
            this.L_R03_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R03_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R03_MGR.Text = "";
            this.L_R03_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R03_MGR.WordWrap = false;
            // 
            // C_R03_X1
            // 
            this.C_R03_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R03_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_X1.BorderWidth = 0.5F;
            this.C_R03_X1.CanGrow = false;
            this.C_R03_X1.Dpi = 100F;
            this.C_R03_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 367F);
            this.C_R03_X1.Multiline = true;
            this.C_R03_X1.Name = "C_R03_X1";
            this.C_R03_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R03_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R03_X1.Text = "";
            this.C_R03_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_X1.WordWrap = false;
            // 
            // C_R03_X2
            // 
            this.C_R03_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R03_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_X2.BorderWidth = 0.5F;
            this.C_R03_X2.CanGrow = false;
            this.C_R03_X2.Dpi = 100F;
            this.C_R03_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 367F);
            this.C_R03_X2.Multiline = true;
            this.C_R03_X2.Name = "C_R03_X2";
            this.C_R03_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R03_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R03_X2.Text = "";
            this.C_R03_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_X2.WordWrap = false;
            // 
            // C_R03_X3
            // 
            this.C_R03_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R03_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_X3.BorderWidth = 0.5F;
            this.C_R03_X3.CanGrow = false;
            this.C_R03_X3.Dpi = 100F;
            this.C_R03_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 367F);
            this.C_R03_X3.Multiline = true;
            this.C_R03_X3.Name = "C_R03_X3";
            this.C_R03_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R03_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R03_X3.Text = "";
            this.C_R03_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_X3.WordWrap = false;
            // 
            // C_R03_X4
            // 
            this.C_R03_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R03_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_X4.BorderWidth = 0.5F;
            this.C_R03_X4.CanGrow = false;
            this.C_R03_X4.Dpi = 100F;
            this.C_R03_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 367F);
            this.C_R03_X4.Multiline = true;
            this.C_R03_X4.Name = "C_R03_X4";
            this.C_R03_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R03_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R03_X4.Text = "";
            this.C_R03_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_X4.WordWrap = false;
            // 
            // C_R03_X5
            // 
            this.C_R03_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R03_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_X5.BorderWidth = 0.5F;
            this.C_R03_X5.CanGrow = false;
            this.C_R03_X5.Dpi = 100F;
            this.C_R03_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R03_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 367F);
            this.C_R03_X5.Multiline = true;
            this.C_R03_X5.Name = "C_R03_X5";
            this.C_R03_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R03_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R03_X5.Text = "";
            this.C_R03_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_X5.WordWrap = false;
            // 
            // C_R03_JUDGE
            // 
            this.C_R03_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R03_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_JUDGE.BorderWidth = 0.5F;
            this.C_R03_JUDGE.CanGrow = false;
            this.C_R03_JUDGE.Dpi = 100F;
            this.C_R03_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 367F);
            this.C_R03_JUDGE.Multiline = true;
            this.C_R03_JUDGE.Name = "C_R03_JUDGE";
            this.C_R03_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R03_JUDGE.Text = "";
            this.C_R03_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_JUDGE.WordWrap = false;
            // 
            // L_R03_DX1
            // 
            this.L_R03_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R03_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R03_DX1.BorderWidth = 0.5F;
            this.L_R03_DX1.CanGrow = false;
            this.L_R03_DX1.Dpi = 100F;
            this.L_R03_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 367F);
            this.L_R03_DX1.Multiline = true;
            this.L_R03_DX1.Name = "L_R03_DX1";
            this.L_R03_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R03_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R03_DX1.Text = "";
            this.L_R03_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R03_DX1.WordWrap = false;
            // 
            // L_R03_DX2
            // 
            this.L_R03_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R03_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R03_DX2.BorderWidth = 0.5F;
            this.L_R03_DX2.CanGrow = false;
            this.L_R03_DX2.Dpi = 100F;
            this.L_R03_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 367F);
            this.L_R03_DX2.Multiline = true;
            this.L_R03_DX2.Name = "L_R03_DX2";
            this.L_R03_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R03_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R03_DX2.Text = "";
            this.L_R03_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R03_DX2.WordWrap = false;
            // 
            // L_R03_DX3
            // 
            this.L_R03_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R03_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R03_DX3.BorderWidth = 0.5F;
            this.L_R03_DX3.CanGrow = false;
            this.L_R03_DX3.Dpi = 100F;
            this.L_R03_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 367F);
            this.L_R03_DX3.Multiline = true;
            this.L_R03_DX3.Name = "L_R03_DX3";
            this.L_R03_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R03_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R03_DX3.Text = "";
            this.L_R03_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R03_DX3.WordWrap = false;
            // 
            // L_R03_DX4
            // 
            this.L_R03_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R03_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R03_DX4.BorderWidth = 0.5F;
            this.L_R03_DX4.CanGrow = false;
            this.L_R03_DX4.Dpi = 100F;
            this.L_R03_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 367F);
            this.L_R03_DX4.Multiline = true;
            this.L_R03_DX4.Name = "L_R03_DX4";
            this.L_R03_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R03_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R03_DX4.Text = "";
            this.L_R03_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R03_DX4.WordWrap = false;
            // 
            // L_R03_DX5
            // 
            this.L_R03_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R03_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R03_DX5.BorderWidth = 0.5F;
            this.L_R03_DX5.CanGrow = false;
            this.L_R03_DX5.Dpi = 100F;
            this.L_R03_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 367F);
            this.L_R03_DX5.Multiline = true;
            this.L_R03_DX5.Name = "L_R03_DX5";
            this.L_R03_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R03_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R03_DX5.Text = "";
            this.L_R03_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R03_DX5.WordWrap = false;
            // 
            // L_R03_DJ
            // 
            this.L_R03_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R03_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R03_DJ.BorderWidth = 0.5F;
            this.L_R03_DJ.CanGrow = false;
            this.L_R03_DJ.Dpi = 100F;
            this.L_R03_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 367F);
            this.L_R03_DJ.Multiline = true;
            this.L_R03_DJ.Name = "L_R03_DJ";
            this.L_R03_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R03_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R03_DJ.Text = "";
            this.L_R03_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R03_DJ.WordWrap = false;
            // 
            // C_R03_XSPAN
            // 
            this.C_R03_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R03_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R03_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R03_XSPAN.BorderWidth = 0.5F;
            this.C_R03_XSPAN.CanGrow = false;
            this.C_R03_XSPAN.Dpi = 100F;
            this.C_R03_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R03_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 367F);
            this.C_R03_XSPAN.Multiline = true;
            this.C_R03_XSPAN.Name = "C_R03_XSPAN";
            this.C_R03_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R03_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R03_XSPAN.Text = "";
            this.C_R03_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R03_XSPAN.Visible = false;
            this.C_R03_XSPAN.WordWrap = false;
            // 
            // C_R04_NO
            // 
            this.C_R04_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R04_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_NO.BorderWidth = 0.5F;
            this.C_R04_NO.CanGrow = false;
            this.C_R04_NO.Dpi = 100F;
            this.C_R04_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 391F);
            this.C_R04_NO.Multiline = true;
            this.C_R04_NO.Name = "C_R04_NO";
            this.C_R04_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R04_NO.Text = "";
            this.C_R04_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_NO.WordWrap = false;
            // 
            // C_R04_STD
            // 
            this.C_R04_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R04_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_STD.BorderWidth = 0.5F;
            this.C_R04_STD.CanGrow = false;
            this.C_R04_STD.Dpi = 100F;
            this.C_R04_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R04_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 391F);
            this.C_R04_STD.Multiline = true;
            this.C_R04_STD.Name = "C_R04_STD";
            this.C_R04_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R04_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R04_STD.Text = "";
            this.C_R04_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R04_STD.WordWrap = true;
            // 
            // C_R04_SPEC
            // 
            this.C_R04_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R04_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_SPEC.BorderWidth = 0.5F;
            this.C_R04_SPEC.CanGrow = false;
            this.C_R04_SPEC.Dpi = 100F;
            this.C_R04_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R04_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 391F);
            this.C_R04_SPEC.Multiline = true;
            this.C_R04_SPEC.Name = "C_R04_SPEC";
            this.C_R04_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R04_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R04_SPEC.Text = "";
            this.C_R04_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R04_SPEC.WordWrap = true;
            // 
            // L_R04_MGR
            // 
            this.L_R04_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R04_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R04_MGR.BorderWidth = 0.5F;
            this.L_R04_MGR.CanGrow = false;
            this.L_R04_MGR.Dpi = 100F;
            this.L_R04_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 391F);
            this.L_R04_MGR.Multiline = true;
            this.L_R04_MGR.Name = "L_R04_MGR";
            this.L_R04_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R04_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R04_MGR.Text = "";
            this.L_R04_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R04_MGR.WordWrap = false;
            // 
            // C_R04_X1
            // 
            this.C_R04_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R04_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_X1.BorderWidth = 0.5F;
            this.C_R04_X1.CanGrow = false;
            this.C_R04_X1.Dpi = 100F;
            this.C_R04_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 391F);
            this.C_R04_X1.Multiline = true;
            this.C_R04_X1.Name = "C_R04_X1";
            this.C_R04_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R04_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R04_X1.Text = "";
            this.C_R04_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_X1.WordWrap = false;
            // 
            // C_R04_X2
            // 
            this.C_R04_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R04_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_X2.BorderWidth = 0.5F;
            this.C_R04_X2.CanGrow = false;
            this.C_R04_X2.Dpi = 100F;
            this.C_R04_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 391F);
            this.C_R04_X2.Multiline = true;
            this.C_R04_X2.Name = "C_R04_X2";
            this.C_R04_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R04_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R04_X2.Text = "";
            this.C_R04_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_X2.WordWrap = false;
            // 
            // C_R04_X3
            // 
            this.C_R04_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R04_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_X3.BorderWidth = 0.5F;
            this.C_R04_X3.CanGrow = false;
            this.C_R04_X3.Dpi = 100F;
            this.C_R04_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 391F);
            this.C_R04_X3.Multiline = true;
            this.C_R04_X3.Name = "C_R04_X3";
            this.C_R04_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R04_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R04_X3.Text = "";
            this.C_R04_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_X3.WordWrap = false;
            // 
            // C_R04_X4
            // 
            this.C_R04_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R04_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_X4.BorderWidth = 0.5F;
            this.C_R04_X4.CanGrow = false;
            this.C_R04_X4.Dpi = 100F;
            this.C_R04_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 391F);
            this.C_R04_X4.Multiline = true;
            this.C_R04_X4.Name = "C_R04_X4";
            this.C_R04_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R04_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R04_X4.Text = "";
            this.C_R04_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_X4.WordWrap = false;
            // 
            // C_R04_X5
            // 
            this.C_R04_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R04_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_X5.BorderWidth = 0.5F;
            this.C_R04_X5.CanGrow = false;
            this.C_R04_X5.Dpi = 100F;
            this.C_R04_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R04_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 391F);
            this.C_R04_X5.Multiline = true;
            this.C_R04_X5.Name = "C_R04_X5";
            this.C_R04_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R04_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R04_X5.Text = "";
            this.C_R04_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_X5.WordWrap = false;
            // 
            // C_R04_JUDGE
            // 
            this.C_R04_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R04_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_JUDGE.BorderWidth = 0.5F;
            this.C_R04_JUDGE.CanGrow = false;
            this.C_R04_JUDGE.Dpi = 100F;
            this.C_R04_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 391F);
            this.C_R04_JUDGE.Multiline = true;
            this.C_R04_JUDGE.Name = "C_R04_JUDGE";
            this.C_R04_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R04_JUDGE.Text = "";
            this.C_R04_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_JUDGE.WordWrap = false;
            // 
            // L_R04_DX1
            // 
            this.L_R04_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R04_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R04_DX1.BorderWidth = 0.5F;
            this.L_R04_DX1.CanGrow = false;
            this.L_R04_DX1.Dpi = 100F;
            this.L_R04_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 391F);
            this.L_R04_DX1.Multiline = true;
            this.L_R04_DX1.Name = "L_R04_DX1";
            this.L_R04_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R04_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R04_DX1.Text = "";
            this.L_R04_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R04_DX1.WordWrap = false;
            // 
            // L_R04_DX2
            // 
            this.L_R04_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R04_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R04_DX2.BorderWidth = 0.5F;
            this.L_R04_DX2.CanGrow = false;
            this.L_R04_DX2.Dpi = 100F;
            this.L_R04_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 391F);
            this.L_R04_DX2.Multiline = true;
            this.L_R04_DX2.Name = "L_R04_DX2";
            this.L_R04_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R04_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R04_DX2.Text = "";
            this.L_R04_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R04_DX2.WordWrap = false;
            // 
            // L_R04_DX3
            // 
            this.L_R04_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R04_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R04_DX3.BorderWidth = 0.5F;
            this.L_R04_DX3.CanGrow = false;
            this.L_R04_DX3.Dpi = 100F;
            this.L_R04_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 391F);
            this.L_R04_DX3.Multiline = true;
            this.L_R04_DX3.Name = "L_R04_DX3";
            this.L_R04_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R04_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R04_DX3.Text = "";
            this.L_R04_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R04_DX3.WordWrap = false;
            // 
            // L_R04_DX4
            // 
            this.L_R04_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R04_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R04_DX4.BorderWidth = 0.5F;
            this.L_R04_DX4.CanGrow = false;
            this.L_R04_DX4.Dpi = 100F;
            this.L_R04_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 391F);
            this.L_R04_DX4.Multiline = true;
            this.L_R04_DX4.Name = "L_R04_DX4";
            this.L_R04_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R04_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R04_DX4.Text = "";
            this.L_R04_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R04_DX4.WordWrap = false;
            // 
            // L_R04_DX5
            // 
            this.L_R04_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R04_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R04_DX5.BorderWidth = 0.5F;
            this.L_R04_DX5.CanGrow = false;
            this.L_R04_DX5.Dpi = 100F;
            this.L_R04_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 391F);
            this.L_R04_DX5.Multiline = true;
            this.L_R04_DX5.Name = "L_R04_DX5";
            this.L_R04_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R04_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R04_DX5.Text = "";
            this.L_R04_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R04_DX5.WordWrap = false;
            // 
            // L_R04_DJ
            // 
            this.L_R04_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R04_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R04_DJ.BorderWidth = 0.5F;
            this.L_R04_DJ.CanGrow = false;
            this.L_R04_DJ.Dpi = 100F;
            this.L_R04_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 391F);
            this.L_R04_DJ.Multiline = true;
            this.L_R04_DJ.Name = "L_R04_DJ";
            this.L_R04_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R04_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R04_DJ.Text = "";
            this.L_R04_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R04_DJ.WordWrap = false;
            // 
            // C_R04_XSPAN
            // 
            this.C_R04_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R04_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R04_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R04_XSPAN.BorderWidth = 0.5F;
            this.C_R04_XSPAN.CanGrow = false;
            this.C_R04_XSPAN.Dpi = 100F;
            this.C_R04_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R04_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 391F);
            this.C_R04_XSPAN.Multiline = true;
            this.C_R04_XSPAN.Name = "C_R04_XSPAN";
            this.C_R04_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R04_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R04_XSPAN.Text = "";
            this.C_R04_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R04_XSPAN.Visible = false;
            this.C_R04_XSPAN.WordWrap = false;
            // 
            // C_R05_NO
            // 
            this.C_R05_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R05_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_NO.BorderWidth = 0.5F;
            this.C_R05_NO.CanGrow = false;
            this.C_R05_NO.Dpi = 100F;
            this.C_R05_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 415F);
            this.C_R05_NO.Multiline = true;
            this.C_R05_NO.Name = "C_R05_NO";
            this.C_R05_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R05_NO.Text = "";
            this.C_R05_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_NO.WordWrap = false;
            // 
            // C_R05_STD
            // 
            this.C_R05_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R05_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_STD.BorderWidth = 0.5F;
            this.C_R05_STD.CanGrow = false;
            this.C_R05_STD.Dpi = 100F;
            this.C_R05_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R05_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 415F);
            this.C_R05_STD.Multiline = true;
            this.C_R05_STD.Name = "C_R05_STD";
            this.C_R05_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R05_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R05_STD.Text = "";
            this.C_R05_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R05_STD.WordWrap = true;
            // 
            // C_R05_SPEC
            // 
            this.C_R05_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R05_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_SPEC.BorderWidth = 0.5F;
            this.C_R05_SPEC.CanGrow = false;
            this.C_R05_SPEC.Dpi = 100F;
            this.C_R05_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R05_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 415F);
            this.C_R05_SPEC.Multiline = true;
            this.C_R05_SPEC.Name = "C_R05_SPEC";
            this.C_R05_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R05_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R05_SPEC.Text = "";
            this.C_R05_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R05_SPEC.WordWrap = true;
            // 
            // L_R05_MGR
            // 
            this.L_R05_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R05_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R05_MGR.BorderWidth = 0.5F;
            this.L_R05_MGR.CanGrow = false;
            this.L_R05_MGR.Dpi = 100F;
            this.L_R05_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 415F);
            this.L_R05_MGR.Multiline = true;
            this.L_R05_MGR.Name = "L_R05_MGR";
            this.L_R05_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R05_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R05_MGR.Text = "";
            this.L_R05_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R05_MGR.WordWrap = false;
            // 
            // C_R05_X1
            // 
            this.C_R05_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R05_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_X1.BorderWidth = 0.5F;
            this.C_R05_X1.CanGrow = false;
            this.C_R05_X1.Dpi = 100F;
            this.C_R05_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 415F);
            this.C_R05_X1.Multiline = true;
            this.C_R05_X1.Name = "C_R05_X1";
            this.C_R05_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R05_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R05_X1.Text = "";
            this.C_R05_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_X1.WordWrap = false;
            // 
            // C_R05_X2
            // 
            this.C_R05_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R05_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_X2.BorderWidth = 0.5F;
            this.C_R05_X2.CanGrow = false;
            this.C_R05_X2.Dpi = 100F;
            this.C_R05_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 415F);
            this.C_R05_X2.Multiline = true;
            this.C_R05_X2.Name = "C_R05_X2";
            this.C_R05_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R05_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R05_X2.Text = "";
            this.C_R05_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_X2.WordWrap = false;
            // 
            // C_R05_X3
            // 
            this.C_R05_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R05_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_X3.BorderWidth = 0.5F;
            this.C_R05_X3.CanGrow = false;
            this.C_R05_X3.Dpi = 100F;
            this.C_R05_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 415F);
            this.C_R05_X3.Multiline = true;
            this.C_R05_X3.Name = "C_R05_X3";
            this.C_R05_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R05_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R05_X3.Text = "";
            this.C_R05_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_X3.WordWrap = false;
            // 
            // C_R05_X4
            // 
            this.C_R05_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R05_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_X4.BorderWidth = 0.5F;
            this.C_R05_X4.CanGrow = false;
            this.C_R05_X4.Dpi = 100F;
            this.C_R05_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 415F);
            this.C_R05_X4.Multiline = true;
            this.C_R05_X4.Name = "C_R05_X4";
            this.C_R05_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R05_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R05_X4.Text = "";
            this.C_R05_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_X4.WordWrap = false;
            // 
            // C_R05_X5
            // 
            this.C_R05_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R05_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_X5.BorderWidth = 0.5F;
            this.C_R05_X5.CanGrow = false;
            this.C_R05_X5.Dpi = 100F;
            this.C_R05_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R05_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 415F);
            this.C_R05_X5.Multiline = true;
            this.C_R05_X5.Name = "C_R05_X5";
            this.C_R05_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R05_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R05_X5.Text = "";
            this.C_R05_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_X5.WordWrap = false;
            // 
            // C_R05_JUDGE
            // 
            this.C_R05_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R05_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_JUDGE.BorderWidth = 0.5F;
            this.C_R05_JUDGE.CanGrow = false;
            this.C_R05_JUDGE.Dpi = 100F;
            this.C_R05_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 415F);
            this.C_R05_JUDGE.Multiline = true;
            this.C_R05_JUDGE.Name = "C_R05_JUDGE";
            this.C_R05_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R05_JUDGE.Text = "";
            this.C_R05_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_JUDGE.WordWrap = false;
            // 
            // L_R05_DX1
            // 
            this.L_R05_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R05_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R05_DX1.BorderWidth = 0.5F;
            this.L_R05_DX1.CanGrow = false;
            this.L_R05_DX1.Dpi = 100F;
            this.L_R05_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 415F);
            this.L_R05_DX1.Multiline = true;
            this.L_R05_DX1.Name = "L_R05_DX1";
            this.L_R05_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R05_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R05_DX1.Text = "";
            this.L_R05_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R05_DX1.WordWrap = false;
            // 
            // L_R05_DX2
            // 
            this.L_R05_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R05_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R05_DX2.BorderWidth = 0.5F;
            this.L_R05_DX2.CanGrow = false;
            this.L_R05_DX2.Dpi = 100F;
            this.L_R05_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 415F);
            this.L_R05_DX2.Multiline = true;
            this.L_R05_DX2.Name = "L_R05_DX2";
            this.L_R05_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R05_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R05_DX2.Text = "";
            this.L_R05_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R05_DX2.WordWrap = false;
            // 
            // L_R05_DX3
            // 
            this.L_R05_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R05_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R05_DX3.BorderWidth = 0.5F;
            this.L_R05_DX3.CanGrow = false;
            this.L_R05_DX3.Dpi = 100F;
            this.L_R05_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 415F);
            this.L_R05_DX3.Multiline = true;
            this.L_R05_DX3.Name = "L_R05_DX3";
            this.L_R05_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R05_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R05_DX3.Text = "";
            this.L_R05_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R05_DX3.WordWrap = false;
            // 
            // L_R05_DX4
            // 
            this.L_R05_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R05_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R05_DX4.BorderWidth = 0.5F;
            this.L_R05_DX4.CanGrow = false;
            this.L_R05_DX4.Dpi = 100F;
            this.L_R05_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 415F);
            this.L_R05_DX4.Multiline = true;
            this.L_R05_DX4.Name = "L_R05_DX4";
            this.L_R05_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R05_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R05_DX4.Text = "";
            this.L_R05_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R05_DX4.WordWrap = false;
            // 
            // L_R05_DX5
            // 
            this.L_R05_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R05_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R05_DX5.BorderWidth = 0.5F;
            this.L_R05_DX5.CanGrow = false;
            this.L_R05_DX5.Dpi = 100F;
            this.L_R05_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 415F);
            this.L_R05_DX5.Multiline = true;
            this.L_R05_DX5.Name = "L_R05_DX5";
            this.L_R05_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R05_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R05_DX5.Text = "";
            this.L_R05_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R05_DX5.WordWrap = false;
            // 
            // L_R05_DJ
            // 
            this.L_R05_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R05_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R05_DJ.BorderWidth = 0.5F;
            this.L_R05_DJ.CanGrow = false;
            this.L_R05_DJ.Dpi = 100F;
            this.L_R05_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 415F);
            this.L_R05_DJ.Multiline = true;
            this.L_R05_DJ.Name = "L_R05_DJ";
            this.L_R05_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R05_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R05_DJ.Text = "";
            this.L_R05_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R05_DJ.WordWrap = false;
            // 
            // C_R05_XSPAN
            // 
            this.C_R05_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R05_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R05_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R05_XSPAN.BorderWidth = 0.5F;
            this.C_R05_XSPAN.CanGrow = false;
            this.C_R05_XSPAN.Dpi = 100F;
            this.C_R05_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R05_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 415F);
            this.C_R05_XSPAN.Multiline = true;
            this.C_R05_XSPAN.Name = "C_R05_XSPAN";
            this.C_R05_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R05_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R05_XSPAN.Text = "";
            this.C_R05_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R05_XSPAN.Visible = false;
            this.C_R05_XSPAN.WordWrap = false;
            // 
            // C_R06_NO
            // 
            this.C_R06_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R06_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_NO.BorderWidth = 0.5F;
            this.C_R06_NO.CanGrow = false;
            this.C_R06_NO.Dpi = 100F;
            this.C_R06_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 439F);
            this.C_R06_NO.Multiline = true;
            this.C_R06_NO.Name = "C_R06_NO";
            this.C_R06_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R06_NO.Text = "";
            this.C_R06_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_NO.WordWrap = false;
            // 
            // C_R06_STD
            // 
            this.C_R06_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R06_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_STD.BorderWidth = 0.5F;
            this.C_R06_STD.CanGrow = false;
            this.C_R06_STD.Dpi = 100F;
            this.C_R06_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R06_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 439F);
            this.C_R06_STD.Multiline = true;
            this.C_R06_STD.Name = "C_R06_STD";
            this.C_R06_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R06_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R06_STD.Text = "";
            this.C_R06_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R06_STD.WordWrap = true;
            // 
            // C_R06_SPEC
            // 
            this.C_R06_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R06_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_SPEC.BorderWidth = 0.5F;
            this.C_R06_SPEC.CanGrow = false;
            this.C_R06_SPEC.Dpi = 100F;
            this.C_R06_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R06_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 439F);
            this.C_R06_SPEC.Multiline = true;
            this.C_R06_SPEC.Name = "C_R06_SPEC";
            this.C_R06_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R06_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R06_SPEC.Text = "";
            this.C_R06_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R06_SPEC.WordWrap = true;
            // 
            // L_R06_MGR
            // 
            this.L_R06_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R06_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R06_MGR.BorderWidth = 0.5F;
            this.L_R06_MGR.CanGrow = false;
            this.L_R06_MGR.Dpi = 100F;
            this.L_R06_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 439F);
            this.L_R06_MGR.Multiline = true;
            this.L_R06_MGR.Name = "L_R06_MGR";
            this.L_R06_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R06_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R06_MGR.Text = "";
            this.L_R06_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R06_MGR.WordWrap = false;
            // 
            // C_R06_X1
            // 
            this.C_R06_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R06_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_X1.BorderWidth = 0.5F;
            this.C_R06_X1.CanGrow = false;
            this.C_R06_X1.Dpi = 100F;
            this.C_R06_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 439F);
            this.C_R06_X1.Multiline = true;
            this.C_R06_X1.Name = "C_R06_X1";
            this.C_R06_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R06_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R06_X1.Text = "";
            this.C_R06_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_X1.WordWrap = false;
            // 
            // C_R06_X2
            // 
            this.C_R06_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R06_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_X2.BorderWidth = 0.5F;
            this.C_R06_X2.CanGrow = false;
            this.C_R06_X2.Dpi = 100F;
            this.C_R06_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 439F);
            this.C_R06_X2.Multiline = true;
            this.C_R06_X2.Name = "C_R06_X2";
            this.C_R06_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R06_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R06_X2.Text = "";
            this.C_R06_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_X2.WordWrap = false;
            // 
            // C_R06_X3
            // 
            this.C_R06_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R06_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_X3.BorderWidth = 0.5F;
            this.C_R06_X3.CanGrow = false;
            this.C_R06_X3.Dpi = 100F;
            this.C_R06_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 439F);
            this.C_R06_X3.Multiline = true;
            this.C_R06_X3.Name = "C_R06_X3";
            this.C_R06_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R06_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R06_X3.Text = "";
            this.C_R06_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_X3.WordWrap = false;
            // 
            // C_R06_X4
            // 
            this.C_R06_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R06_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_X4.BorderWidth = 0.5F;
            this.C_R06_X4.CanGrow = false;
            this.C_R06_X4.Dpi = 100F;
            this.C_R06_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 439F);
            this.C_R06_X4.Multiline = true;
            this.C_R06_X4.Name = "C_R06_X4";
            this.C_R06_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R06_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R06_X4.Text = "";
            this.C_R06_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_X4.WordWrap = false;
            // 
            // C_R06_X5
            // 
            this.C_R06_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R06_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_X5.BorderWidth = 0.5F;
            this.C_R06_X5.CanGrow = false;
            this.C_R06_X5.Dpi = 100F;
            this.C_R06_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R06_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 439F);
            this.C_R06_X5.Multiline = true;
            this.C_R06_X5.Name = "C_R06_X5";
            this.C_R06_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R06_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R06_X5.Text = "";
            this.C_R06_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_X5.WordWrap = false;
            // 
            // C_R06_JUDGE
            // 
            this.C_R06_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R06_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_JUDGE.BorderWidth = 0.5F;
            this.C_R06_JUDGE.CanGrow = false;
            this.C_R06_JUDGE.Dpi = 100F;
            this.C_R06_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 439F);
            this.C_R06_JUDGE.Multiline = true;
            this.C_R06_JUDGE.Name = "C_R06_JUDGE";
            this.C_R06_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R06_JUDGE.Text = "";
            this.C_R06_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_JUDGE.WordWrap = false;
            // 
            // L_R06_DX1
            // 
            this.L_R06_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R06_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R06_DX1.BorderWidth = 0.5F;
            this.L_R06_DX1.CanGrow = false;
            this.L_R06_DX1.Dpi = 100F;
            this.L_R06_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 439F);
            this.L_R06_DX1.Multiline = true;
            this.L_R06_DX1.Name = "L_R06_DX1";
            this.L_R06_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R06_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R06_DX1.Text = "";
            this.L_R06_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R06_DX1.WordWrap = false;
            // 
            // L_R06_DX2
            // 
            this.L_R06_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R06_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R06_DX2.BorderWidth = 0.5F;
            this.L_R06_DX2.CanGrow = false;
            this.L_R06_DX2.Dpi = 100F;
            this.L_R06_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 439F);
            this.L_R06_DX2.Multiline = true;
            this.L_R06_DX2.Name = "L_R06_DX2";
            this.L_R06_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R06_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R06_DX2.Text = "";
            this.L_R06_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R06_DX2.WordWrap = false;
            // 
            // L_R06_DX3
            // 
            this.L_R06_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R06_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R06_DX3.BorderWidth = 0.5F;
            this.L_R06_DX3.CanGrow = false;
            this.L_R06_DX3.Dpi = 100F;
            this.L_R06_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 439F);
            this.L_R06_DX3.Multiline = true;
            this.L_R06_DX3.Name = "L_R06_DX3";
            this.L_R06_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R06_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R06_DX3.Text = "";
            this.L_R06_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R06_DX3.WordWrap = false;
            // 
            // L_R06_DX4
            // 
            this.L_R06_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R06_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R06_DX4.BorderWidth = 0.5F;
            this.L_R06_DX4.CanGrow = false;
            this.L_R06_DX4.Dpi = 100F;
            this.L_R06_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 439F);
            this.L_R06_DX4.Multiline = true;
            this.L_R06_DX4.Name = "L_R06_DX4";
            this.L_R06_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R06_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R06_DX4.Text = "";
            this.L_R06_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R06_DX4.WordWrap = false;
            // 
            // L_R06_DX5
            // 
            this.L_R06_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R06_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R06_DX5.BorderWidth = 0.5F;
            this.L_R06_DX5.CanGrow = false;
            this.L_R06_DX5.Dpi = 100F;
            this.L_R06_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 439F);
            this.L_R06_DX5.Multiline = true;
            this.L_R06_DX5.Name = "L_R06_DX5";
            this.L_R06_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R06_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R06_DX5.Text = "";
            this.L_R06_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R06_DX5.WordWrap = false;
            // 
            // L_R06_DJ
            // 
            this.L_R06_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R06_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R06_DJ.BorderWidth = 0.5F;
            this.L_R06_DJ.CanGrow = false;
            this.L_R06_DJ.Dpi = 100F;
            this.L_R06_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 439F);
            this.L_R06_DJ.Multiline = true;
            this.L_R06_DJ.Name = "L_R06_DJ";
            this.L_R06_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R06_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R06_DJ.Text = "";
            this.L_R06_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R06_DJ.WordWrap = false;
            // 
            // C_R06_XSPAN
            // 
            this.C_R06_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R06_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R06_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R06_XSPAN.BorderWidth = 0.5F;
            this.C_R06_XSPAN.CanGrow = false;
            this.C_R06_XSPAN.Dpi = 100F;
            this.C_R06_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R06_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 439F);
            this.C_R06_XSPAN.Multiline = true;
            this.C_R06_XSPAN.Name = "C_R06_XSPAN";
            this.C_R06_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R06_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R06_XSPAN.Text = "";
            this.C_R06_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R06_XSPAN.Visible = false;
            this.C_R06_XSPAN.WordWrap = false;
            // 
            // C_R07_NO
            // 
            this.C_R07_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R07_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_NO.BorderWidth = 0.5F;
            this.C_R07_NO.CanGrow = false;
            this.C_R07_NO.Dpi = 100F;
            this.C_R07_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 463F);
            this.C_R07_NO.Multiline = true;
            this.C_R07_NO.Name = "C_R07_NO";
            this.C_R07_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R07_NO.Text = "";
            this.C_R07_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_NO.WordWrap = false;
            // 
            // C_R07_STD
            // 
            this.C_R07_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R07_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_STD.BorderWidth = 0.5F;
            this.C_R07_STD.CanGrow = false;
            this.C_R07_STD.Dpi = 100F;
            this.C_R07_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R07_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 463F);
            this.C_R07_STD.Multiline = true;
            this.C_R07_STD.Name = "C_R07_STD";
            this.C_R07_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R07_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R07_STD.Text = "";
            this.C_R07_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R07_STD.WordWrap = true;
            // 
            // C_R07_SPEC
            // 
            this.C_R07_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R07_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_SPEC.BorderWidth = 0.5F;
            this.C_R07_SPEC.CanGrow = false;
            this.C_R07_SPEC.Dpi = 100F;
            this.C_R07_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R07_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 463F);
            this.C_R07_SPEC.Multiline = true;
            this.C_R07_SPEC.Name = "C_R07_SPEC";
            this.C_R07_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R07_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R07_SPEC.Text = "";
            this.C_R07_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R07_SPEC.WordWrap = true;
            // 
            // L_R07_MGR
            // 
            this.L_R07_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R07_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R07_MGR.BorderWidth = 0.5F;
            this.L_R07_MGR.CanGrow = false;
            this.L_R07_MGR.Dpi = 100F;
            this.L_R07_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 463F);
            this.L_R07_MGR.Multiline = true;
            this.L_R07_MGR.Name = "L_R07_MGR";
            this.L_R07_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R07_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R07_MGR.Text = "";
            this.L_R07_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R07_MGR.WordWrap = false;
            // 
            // C_R07_X1
            // 
            this.C_R07_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R07_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_X1.BorderWidth = 0.5F;
            this.C_R07_X1.CanGrow = false;
            this.C_R07_X1.Dpi = 100F;
            this.C_R07_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 463F);
            this.C_R07_X1.Multiline = true;
            this.C_R07_X1.Name = "C_R07_X1";
            this.C_R07_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R07_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R07_X1.Text = "";
            this.C_R07_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_X1.WordWrap = false;
            // 
            // C_R07_X2
            // 
            this.C_R07_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R07_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_X2.BorderWidth = 0.5F;
            this.C_R07_X2.CanGrow = false;
            this.C_R07_X2.Dpi = 100F;
            this.C_R07_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 463F);
            this.C_R07_X2.Multiline = true;
            this.C_R07_X2.Name = "C_R07_X2";
            this.C_R07_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R07_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R07_X2.Text = "";
            this.C_R07_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_X2.WordWrap = false;
            // 
            // C_R07_X3
            // 
            this.C_R07_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R07_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_X3.BorderWidth = 0.5F;
            this.C_R07_X3.CanGrow = false;
            this.C_R07_X3.Dpi = 100F;
            this.C_R07_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 463F);
            this.C_R07_X3.Multiline = true;
            this.C_R07_X3.Name = "C_R07_X3";
            this.C_R07_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R07_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R07_X3.Text = "";
            this.C_R07_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_X3.WordWrap = false;
            // 
            // C_R07_X4
            // 
            this.C_R07_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R07_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_X4.BorderWidth = 0.5F;
            this.C_R07_X4.CanGrow = false;
            this.C_R07_X4.Dpi = 100F;
            this.C_R07_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 463F);
            this.C_R07_X4.Multiline = true;
            this.C_R07_X4.Name = "C_R07_X4";
            this.C_R07_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R07_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R07_X4.Text = "";
            this.C_R07_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_X4.WordWrap = false;
            // 
            // C_R07_X5
            // 
            this.C_R07_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R07_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_X5.BorderWidth = 0.5F;
            this.C_R07_X5.CanGrow = false;
            this.C_R07_X5.Dpi = 100F;
            this.C_R07_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R07_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 463F);
            this.C_R07_X5.Multiline = true;
            this.C_R07_X5.Name = "C_R07_X5";
            this.C_R07_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R07_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R07_X5.Text = "";
            this.C_R07_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_X5.WordWrap = false;
            // 
            // C_R07_JUDGE
            // 
            this.C_R07_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R07_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_JUDGE.BorderWidth = 0.5F;
            this.C_R07_JUDGE.CanGrow = false;
            this.C_R07_JUDGE.Dpi = 100F;
            this.C_R07_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 463F);
            this.C_R07_JUDGE.Multiline = true;
            this.C_R07_JUDGE.Name = "C_R07_JUDGE";
            this.C_R07_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R07_JUDGE.Text = "";
            this.C_R07_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_JUDGE.WordWrap = false;
            // 
            // L_R07_DX1
            // 
            this.L_R07_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R07_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R07_DX1.BorderWidth = 0.5F;
            this.L_R07_DX1.CanGrow = false;
            this.L_R07_DX1.Dpi = 100F;
            this.L_R07_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 463F);
            this.L_R07_DX1.Multiline = true;
            this.L_R07_DX1.Name = "L_R07_DX1";
            this.L_R07_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R07_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R07_DX1.Text = "";
            this.L_R07_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R07_DX1.WordWrap = false;
            // 
            // L_R07_DX2
            // 
            this.L_R07_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R07_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R07_DX2.BorderWidth = 0.5F;
            this.L_R07_DX2.CanGrow = false;
            this.L_R07_DX2.Dpi = 100F;
            this.L_R07_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 463F);
            this.L_R07_DX2.Multiline = true;
            this.L_R07_DX2.Name = "L_R07_DX2";
            this.L_R07_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R07_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R07_DX2.Text = "";
            this.L_R07_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R07_DX2.WordWrap = false;
            // 
            // L_R07_DX3
            // 
            this.L_R07_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R07_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R07_DX3.BorderWidth = 0.5F;
            this.L_R07_DX3.CanGrow = false;
            this.L_R07_DX3.Dpi = 100F;
            this.L_R07_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 463F);
            this.L_R07_DX3.Multiline = true;
            this.L_R07_DX3.Name = "L_R07_DX3";
            this.L_R07_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R07_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R07_DX3.Text = "";
            this.L_R07_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R07_DX3.WordWrap = false;
            // 
            // L_R07_DX4
            // 
            this.L_R07_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R07_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R07_DX4.BorderWidth = 0.5F;
            this.L_R07_DX4.CanGrow = false;
            this.L_R07_DX4.Dpi = 100F;
            this.L_R07_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 463F);
            this.L_R07_DX4.Multiline = true;
            this.L_R07_DX4.Name = "L_R07_DX4";
            this.L_R07_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R07_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R07_DX4.Text = "";
            this.L_R07_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R07_DX4.WordWrap = false;
            // 
            // L_R07_DX5
            // 
            this.L_R07_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R07_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R07_DX5.BorderWidth = 0.5F;
            this.L_R07_DX5.CanGrow = false;
            this.L_R07_DX5.Dpi = 100F;
            this.L_R07_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 463F);
            this.L_R07_DX5.Multiline = true;
            this.L_R07_DX5.Name = "L_R07_DX5";
            this.L_R07_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R07_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R07_DX5.Text = "";
            this.L_R07_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R07_DX5.WordWrap = false;
            // 
            // L_R07_DJ
            // 
            this.L_R07_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R07_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R07_DJ.BorderWidth = 0.5F;
            this.L_R07_DJ.CanGrow = false;
            this.L_R07_DJ.Dpi = 100F;
            this.L_R07_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 463F);
            this.L_R07_DJ.Multiline = true;
            this.L_R07_DJ.Name = "L_R07_DJ";
            this.L_R07_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R07_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R07_DJ.Text = "";
            this.L_R07_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R07_DJ.WordWrap = false;
            // 
            // C_R07_XSPAN
            // 
            this.C_R07_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R07_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R07_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R07_XSPAN.BorderWidth = 0.5F;
            this.C_R07_XSPAN.CanGrow = false;
            this.C_R07_XSPAN.Dpi = 100F;
            this.C_R07_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R07_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 463F);
            this.C_R07_XSPAN.Multiline = true;
            this.C_R07_XSPAN.Name = "C_R07_XSPAN";
            this.C_R07_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R07_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R07_XSPAN.Text = "";
            this.C_R07_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R07_XSPAN.Visible = false;
            this.C_R07_XSPAN.WordWrap = false;
            // 
            // C_R08_NO
            // 
            this.C_R08_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R08_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_NO.BorderWidth = 0.5F;
            this.C_R08_NO.CanGrow = false;
            this.C_R08_NO.Dpi = 100F;
            this.C_R08_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 487F);
            this.C_R08_NO.Multiline = true;
            this.C_R08_NO.Name = "C_R08_NO";
            this.C_R08_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R08_NO.Text = "";
            this.C_R08_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_NO.WordWrap = false;
            // 
            // C_R08_STD
            // 
            this.C_R08_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R08_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_STD.BorderWidth = 0.5F;
            this.C_R08_STD.CanGrow = false;
            this.C_R08_STD.Dpi = 100F;
            this.C_R08_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R08_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 487F);
            this.C_R08_STD.Multiline = true;
            this.C_R08_STD.Name = "C_R08_STD";
            this.C_R08_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R08_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R08_STD.Text = "";
            this.C_R08_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R08_STD.WordWrap = true;
            // 
            // C_R08_SPEC
            // 
            this.C_R08_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R08_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_SPEC.BorderWidth = 0.5F;
            this.C_R08_SPEC.CanGrow = false;
            this.C_R08_SPEC.Dpi = 100F;
            this.C_R08_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R08_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 487F);
            this.C_R08_SPEC.Multiline = true;
            this.C_R08_SPEC.Name = "C_R08_SPEC";
            this.C_R08_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R08_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R08_SPEC.Text = "";
            this.C_R08_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R08_SPEC.WordWrap = true;
            // 
            // L_R08_MGR
            // 
            this.L_R08_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R08_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R08_MGR.BorderWidth = 0.5F;
            this.L_R08_MGR.CanGrow = false;
            this.L_R08_MGR.Dpi = 100F;
            this.L_R08_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 487F);
            this.L_R08_MGR.Multiline = true;
            this.L_R08_MGR.Name = "L_R08_MGR";
            this.L_R08_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R08_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R08_MGR.Text = "";
            this.L_R08_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R08_MGR.WordWrap = false;
            // 
            // C_R08_X1
            // 
            this.C_R08_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R08_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_X1.BorderWidth = 0.5F;
            this.C_R08_X1.CanGrow = false;
            this.C_R08_X1.Dpi = 100F;
            this.C_R08_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 487F);
            this.C_R08_X1.Multiline = true;
            this.C_R08_X1.Name = "C_R08_X1";
            this.C_R08_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R08_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R08_X1.Text = "";
            this.C_R08_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_X1.WordWrap = false;
            // 
            // C_R08_X2
            // 
            this.C_R08_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R08_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_X2.BorderWidth = 0.5F;
            this.C_R08_X2.CanGrow = false;
            this.C_R08_X2.Dpi = 100F;
            this.C_R08_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 487F);
            this.C_R08_X2.Multiline = true;
            this.C_R08_X2.Name = "C_R08_X2";
            this.C_R08_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R08_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R08_X2.Text = "";
            this.C_R08_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_X2.WordWrap = false;
            // 
            // C_R08_X3
            // 
            this.C_R08_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R08_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_X3.BorderWidth = 0.5F;
            this.C_R08_X3.CanGrow = false;
            this.C_R08_X3.Dpi = 100F;
            this.C_R08_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 487F);
            this.C_R08_X3.Multiline = true;
            this.C_R08_X3.Name = "C_R08_X3";
            this.C_R08_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R08_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R08_X3.Text = "";
            this.C_R08_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_X3.WordWrap = false;
            // 
            // C_R08_X4
            // 
            this.C_R08_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R08_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_X4.BorderWidth = 0.5F;
            this.C_R08_X4.CanGrow = false;
            this.C_R08_X4.Dpi = 100F;
            this.C_R08_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 487F);
            this.C_R08_X4.Multiline = true;
            this.C_R08_X4.Name = "C_R08_X4";
            this.C_R08_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R08_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R08_X4.Text = "";
            this.C_R08_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_X4.WordWrap = false;
            // 
            // C_R08_X5
            // 
            this.C_R08_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R08_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_X5.BorderWidth = 0.5F;
            this.C_R08_X5.CanGrow = false;
            this.C_R08_X5.Dpi = 100F;
            this.C_R08_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R08_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 487F);
            this.C_R08_X5.Multiline = true;
            this.C_R08_X5.Name = "C_R08_X5";
            this.C_R08_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R08_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R08_X5.Text = "";
            this.C_R08_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_X5.WordWrap = false;
            // 
            // C_R08_JUDGE
            // 
            this.C_R08_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R08_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_JUDGE.BorderWidth = 0.5F;
            this.C_R08_JUDGE.CanGrow = false;
            this.C_R08_JUDGE.Dpi = 100F;
            this.C_R08_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 487F);
            this.C_R08_JUDGE.Multiline = true;
            this.C_R08_JUDGE.Name = "C_R08_JUDGE";
            this.C_R08_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R08_JUDGE.Text = "";
            this.C_R08_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_JUDGE.WordWrap = false;
            // 
            // L_R08_DX1
            // 
            this.L_R08_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R08_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R08_DX1.BorderWidth = 0.5F;
            this.L_R08_DX1.CanGrow = false;
            this.L_R08_DX1.Dpi = 100F;
            this.L_R08_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 487F);
            this.L_R08_DX1.Multiline = true;
            this.L_R08_DX1.Name = "L_R08_DX1";
            this.L_R08_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R08_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R08_DX1.Text = "";
            this.L_R08_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R08_DX1.WordWrap = false;
            // 
            // L_R08_DX2
            // 
            this.L_R08_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R08_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R08_DX2.BorderWidth = 0.5F;
            this.L_R08_DX2.CanGrow = false;
            this.L_R08_DX2.Dpi = 100F;
            this.L_R08_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 487F);
            this.L_R08_DX2.Multiline = true;
            this.L_R08_DX2.Name = "L_R08_DX2";
            this.L_R08_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R08_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R08_DX2.Text = "";
            this.L_R08_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R08_DX2.WordWrap = false;
            // 
            // L_R08_DX3
            // 
            this.L_R08_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R08_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R08_DX3.BorderWidth = 0.5F;
            this.L_R08_DX3.CanGrow = false;
            this.L_R08_DX3.Dpi = 100F;
            this.L_R08_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 487F);
            this.L_R08_DX3.Multiline = true;
            this.L_R08_DX3.Name = "L_R08_DX3";
            this.L_R08_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R08_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R08_DX3.Text = "";
            this.L_R08_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R08_DX3.WordWrap = false;
            // 
            // L_R08_DX4
            // 
            this.L_R08_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R08_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R08_DX4.BorderWidth = 0.5F;
            this.L_R08_DX4.CanGrow = false;
            this.L_R08_DX4.Dpi = 100F;
            this.L_R08_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 487F);
            this.L_R08_DX4.Multiline = true;
            this.L_R08_DX4.Name = "L_R08_DX4";
            this.L_R08_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R08_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R08_DX4.Text = "";
            this.L_R08_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R08_DX4.WordWrap = false;
            // 
            // L_R08_DX5
            // 
            this.L_R08_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R08_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R08_DX5.BorderWidth = 0.5F;
            this.L_R08_DX5.CanGrow = false;
            this.L_R08_DX5.Dpi = 100F;
            this.L_R08_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 487F);
            this.L_R08_DX5.Multiline = true;
            this.L_R08_DX5.Name = "L_R08_DX5";
            this.L_R08_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R08_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R08_DX5.Text = "";
            this.L_R08_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R08_DX5.WordWrap = false;
            // 
            // L_R08_DJ
            // 
            this.L_R08_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R08_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R08_DJ.BorderWidth = 0.5F;
            this.L_R08_DJ.CanGrow = false;
            this.L_R08_DJ.Dpi = 100F;
            this.L_R08_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 487F);
            this.L_R08_DJ.Multiline = true;
            this.L_R08_DJ.Name = "L_R08_DJ";
            this.L_R08_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R08_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R08_DJ.Text = "";
            this.L_R08_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R08_DJ.WordWrap = false;
            // 
            // C_R08_XSPAN
            // 
            this.C_R08_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R08_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R08_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R08_XSPAN.BorderWidth = 0.5F;
            this.C_R08_XSPAN.CanGrow = false;
            this.C_R08_XSPAN.Dpi = 100F;
            this.C_R08_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R08_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 487F);
            this.C_R08_XSPAN.Multiline = true;
            this.C_R08_XSPAN.Name = "C_R08_XSPAN";
            this.C_R08_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R08_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R08_XSPAN.Text = "";
            this.C_R08_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R08_XSPAN.Visible = false;
            this.C_R08_XSPAN.WordWrap = false;
            // 
            // C_R09_NO
            // 
            this.C_R09_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R09_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_NO.BorderWidth = 0.5F;
            this.C_R09_NO.CanGrow = false;
            this.C_R09_NO.Dpi = 100F;
            this.C_R09_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 511F);
            this.C_R09_NO.Multiline = true;
            this.C_R09_NO.Name = "C_R09_NO";
            this.C_R09_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R09_NO.Text = "";
            this.C_R09_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_NO.WordWrap = false;
            // 
            // C_R09_STD
            // 
            this.C_R09_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R09_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_STD.BorderWidth = 0.5F;
            this.C_R09_STD.CanGrow = false;
            this.C_R09_STD.Dpi = 100F;
            this.C_R09_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R09_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 511F);
            this.C_R09_STD.Multiline = true;
            this.C_R09_STD.Name = "C_R09_STD";
            this.C_R09_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R09_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R09_STD.Text = "";
            this.C_R09_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R09_STD.WordWrap = true;
            // 
            // C_R09_SPEC
            // 
            this.C_R09_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R09_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_SPEC.BorderWidth = 0.5F;
            this.C_R09_SPEC.CanGrow = false;
            this.C_R09_SPEC.Dpi = 100F;
            this.C_R09_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R09_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 511F);
            this.C_R09_SPEC.Multiline = true;
            this.C_R09_SPEC.Name = "C_R09_SPEC";
            this.C_R09_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R09_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R09_SPEC.Text = "";
            this.C_R09_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R09_SPEC.WordWrap = true;
            // 
            // L_R09_MGR
            // 
            this.L_R09_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R09_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R09_MGR.BorderWidth = 0.5F;
            this.L_R09_MGR.CanGrow = false;
            this.L_R09_MGR.Dpi = 100F;
            this.L_R09_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 511F);
            this.L_R09_MGR.Multiline = true;
            this.L_R09_MGR.Name = "L_R09_MGR";
            this.L_R09_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R09_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R09_MGR.Text = "";
            this.L_R09_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R09_MGR.WordWrap = false;
            // 
            // C_R09_X1
            // 
            this.C_R09_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R09_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_X1.BorderWidth = 0.5F;
            this.C_R09_X1.CanGrow = false;
            this.C_R09_X1.Dpi = 100F;
            this.C_R09_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 511F);
            this.C_R09_X1.Multiline = true;
            this.C_R09_X1.Name = "C_R09_X1";
            this.C_R09_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R09_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R09_X1.Text = "";
            this.C_R09_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_X1.WordWrap = false;
            // 
            // C_R09_X2
            // 
            this.C_R09_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R09_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_X2.BorderWidth = 0.5F;
            this.C_R09_X2.CanGrow = false;
            this.C_R09_X2.Dpi = 100F;
            this.C_R09_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 511F);
            this.C_R09_X2.Multiline = true;
            this.C_R09_X2.Name = "C_R09_X2";
            this.C_R09_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R09_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R09_X2.Text = "";
            this.C_R09_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_X2.WordWrap = false;
            // 
            // C_R09_X3
            // 
            this.C_R09_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R09_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_X3.BorderWidth = 0.5F;
            this.C_R09_X3.CanGrow = false;
            this.C_R09_X3.Dpi = 100F;
            this.C_R09_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 511F);
            this.C_R09_X3.Multiline = true;
            this.C_R09_X3.Name = "C_R09_X3";
            this.C_R09_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R09_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R09_X3.Text = "";
            this.C_R09_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_X3.WordWrap = false;
            // 
            // C_R09_X4
            // 
            this.C_R09_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R09_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_X4.BorderWidth = 0.5F;
            this.C_R09_X4.CanGrow = false;
            this.C_R09_X4.Dpi = 100F;
            this.C_R09_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 511F);
            this.C_R09_X4.Multiline = true;
            this.C_R09_X4.Name = "C_R09_X4";
            this.C_R09_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R09_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R09_X4.Text = "";
            this.C_R09_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_X4.WordWrap = false;
            // 
            // C_R09_X5
            // 
            this.C_R09_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R09_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_X5.BorderWidth = 0.5F;
            this.C_R09_X5.CanGrow = false;
            this.C_R09_X5.Dpi = 100F;
            this.C_R09_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R09_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 511F);
            this.C_R09_X5.Multiline = true;
            this.C_R09_X5.Name = "C_R09_X5";
            this.C_R09_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R09_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R09_X5.Text = "";
            this.C_R09_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_X5.WordWrap = false;
            // 
            // C_R09_JUDGE
            // 
            this.C_R09_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R09_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_JUDGE.BorderWidth = 0.5F;
            this.C_R09_JUDGE.CanGrow = false;
            this.C_R09_JUDGE.Dpi = 100F;
            this.C_R09_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 511F);
            this.C_R09_JUDGE.Multiline = true;
            this.C_R09_JUDGE.Name = "C_R09_JUDGE";
            this.C_R09_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R09_JUDGE.Text = "";
            this.C_R09_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_JUDGE.WordWrap = false;
            // 
            // L_R09_DX1
            // 
            this.L_R09_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R09_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R09_DX1.BorderWidth = 0.5F;
            this.L_R09_DX1.CanGrow = false;
            this.L_R09_DX1.Dpi = 100F;
            this.L_R09_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 511F);
            this.L_R09_DX1.Multiline = true;
            this.L_R09_DX1.Name = "L_R09_DX1";
            this.L_R09_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R09_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R09_DX1.Text = "";
            this.L_R09_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R09_DX1.WordWrap = false;
            // 
            // L_R09_DX2
            // 
            this.L_R09_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R09_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R09_DX2.BorderWidth = 0.5F;
            this.L_R09_DX2.CanGrow = false;
            this.L_R09_DX2.Dpi = 100F;
            this.L_R09_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 511F);
            this.L_R09_DX2.Multiline = true;
            this.L_R09_DX2.Name = "L_R09_DX2";
            this.L_R09_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R09_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R09_DX2.Text = "";
            this.L_R09_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R09_DX2.WordWrap = false;
            // 
            // L_R09_DX3
            // 
            this.L_R09_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R09_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R09_DX3.BorderWidth = 0.5F;
            this.L_R09_DX3.CanGrow = false;
            this.L_R09_DX3.Dpi = 100F;
            this.L_R09_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 511F);
            this.L_R09_DX3.Multiline = true;
            this.L_R09_DX3.Name = "L_R09_DX3";
            this.L_R09_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R09_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R09_DX3.Text = "";
            this.L_R09_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R09_DX3.WordWrap = false;
            // 
            // L_R09_DX4
            // 
            this.L_R09_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R09_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R09_DX4.BorderWidth = 0.5F;
            this.L_R09_DX4.CanGrow = false;
            this.L_R09_DX4.Dpi = 100F;
            this.L_R09_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 511F);
            this.L_R09_DX4.Multiline = true;
            this.L_R09_DX4.Name = "L_R09_DX4";
            this.L_R09_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R09_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R09_DX4.Text = "";
            this.L_R09_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R09_DX4.WordWrap = false;
            // 
            // L_R09_DX5
            // 
            this.L_R09_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R09_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R09_DX5.BorderWidth = 0.5F;
            this.L_R09_DX5.CanGrow = false;
            this.L_R09_DX5.Dpi = 100F;
            this.L_R09_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 511F);
            this.L_R09_DX5.Multiline = true;
            this.L_R09_DX5.Name = "L_R09_DX5";
            this.L_R09_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R09_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R09_DX5.Text = "";
            this.L_R09_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R09_DX5.WordWrap = false;
            // 
            // L_R09_DJ
            // 
            this.L_R09_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R09_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R09_DJ.BorderWidth = 0.5F;
            this.L_R09_DJ.CanGrow = false;
            this.L_R09_DJ.Dpi = 100F;
            this.L_R09_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 511F);
            this.L_R09_DJ.Multiline = true;
            this.L_R09_DJ.Name = "L_R09_DJ";
            this.L_R09_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R09_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R09_DJ.Text = "";
            this.L_R09_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R09_DJ.WordWrap = false;
            // 
            // C_R09_XSPAN
            // 
            this.C_R09_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R09_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R09_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R09_XSPAN.BorderWidth = 0.5F;
            this.C_R09_XSPAN.CanGrow = false;
            this.C_R09_XSPAN.Dpi = 100F;
            this.C_R09_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R09_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 511F);
            this.C_R09_XSPAN.Multiline = true;
            this.C_R09_XSPAN.Name = "C_R09_XSPAN";
            this.C_R09_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R09_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R09_XSPAN.Text = "";
            this.C_R09_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R09_XSPAN.Visible = false;
            this.C_R09_XSPAN.WordWrap = false;
            // 
            // C_R10_NO
            // 
            this.C_R10_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R10_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_NO.BorderWidth = 0.5F;
            this.C_R10_NO.CanGrow = false;
            this.C_R10_NO.Dpi = 100F;
            this.C_R10_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 535F);
            this.C_R10_NO.Multiline = true;
            this.C_R10_NO.Name = "C_R10_NO";
            this.C_R10_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R10_NO.Text = "";
            this.C_R10_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_NO.WordWrap = false;
            // 
            // C_R10_STD
            // 
            this.C_R10_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R10_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_STD.BorderWidth = 0.5F;
            this.C_R10_STD.CanGrow = false;
            this.C_R10_STD.Dpi = 100F;
            this.C_R10_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R10_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 535F);
            this.C_R10_STD.Multiline = true;
            this.C_R10_STD.Name = "C_R10_STD";
            this.C_R10_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R10_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R10_STD.Text = "";
            this.C_R10_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R10_STD.WordWrap = true;
            // 
            // C_R10_SPEC
            // 
            this.C_R10_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R10_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_SPEC.BorderWidth = 0.5F;
            this.C_R10_SPEC.CanGrow = false;
            this.C_R10_SPEC.Dpi = 100F;
            this.C_R10_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R10_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 535F);
            this.C_R10_SPEC.Multiline = true;
            this.C_R10_SPEC.Name = "C_R10_SPEC";
            this.C_R10_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R10_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R10_SPEC.Text = "";
            this.C_R10_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R10_SPEC.WordWrap = true;
            // 
            // L_R10_MGR
            // 
            this.L_R10_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R10_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R10_MGR.BorderWidth = 0.5F;
            this.L_R10_MGR.CanGrow = false;
            this.L_R10_MGR.Dpi = 100F;
            this.L_R10_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 535F);
            this.L_R10_MGR.Multiline = true;
            this.L_R10_MGR.Name = "L_R10_MGR";
            this.L_R10_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R10_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R10_MGR.Text = "";
            this.L_R10_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R10_MGR.WordWrap = false;
            // 
            // C_R10_X1
            // 
            this.C_R10_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R10_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_X1.BorderWidth = 0.5F;
            this.C_R10_X1.CanGrow = false;
            this.C_R10_X1.Dpi = 100F;
            this.C_R10_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 535F);
            this.C_R10_X1.Multiline = true;
            this.C_R10_X1.Name = "C_R10_X1";
            this.C_R10_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R10_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R10_X1.Text = "";
            this.C_R10_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_X1.WordWrap = false;
            // 
            // C_R10_X2
            // 
            this.C_R10_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R10_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_X2.BorderWidth = 0.5F;
            this.C_R10_X2.CanGrow = false;
            this.C_R10_X2.Dpi = 100F;
            this.C_R10_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 535F);
            this.C_R10_X2.Multiline = true;
            this.C_R10_X2.Name = "C_R10_X2";
            this.C_R10_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R10_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R10_X2.Text = "";
            this.C_R10_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_X2.WordWrap = false;
            // 
            // C_R10_X3
            // 
            this.C_R10_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R10_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_X3.BorderWidth = 0.5F;
            this.C_R10_X3.CanGrow = false;
            this.C_R10_X3.Dpi = 100F;
            this.C_R10_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 535F);
            this.C_R10_X3.Multiline = true;
            this.C_R10_X3.Name = "C_R10_X3";
            this.C_R10_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R10_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R10_X3.Text = "";
            this.C_R10_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_X3.WordWrap = false;
            // 
            // C_R10_X4
            // 
            this.C_R10_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R10_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_X4.BorderWidth = 0.5F;
            this.C_R10_X4.CanGrow = false;
            this.C_R10_X4.Dpi = 100F;
            this.C_R10_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 535F);
            this.C_R10_X4.Multiline = true;
            this.C_R10_X4.Name = "C_R10_X4";
            this.C_R10_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R10_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R10_X4.Text = "";
            this.C_R10_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_X4.WordWrap = false;
            // 
            // C_R10_X5
            // 
            this.C_R10_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R10_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_X5.BorderWidth = 0.5F;
            this.C_R10_X5.CanGrow = false;
            this.C_R10_X5.Dpi = 100F;
            this.C_R10_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R10_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 535F);
            this.C_R10_X5.Multiline = true;
            this.C_R10_X5.Name = "C_R10_X5";
            this.C_R10_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R10_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R10_X5.Text = "";
            this.C_R10_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_X5.WordWrap = false;
            // 
            // C_R10_JUDGE
            // 
            this.C_R10_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R10_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_JUDGE.BorderWidth = 0.5F;
            this.C_R10_JUDGE.CanGrow = false;
            this.C_R10_JUDGE.Dpi = 100F;
            this.C_R10_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 535F);
            this.C_R10_JUDGE.Multiline = true;
            this.C_R10_JUDGE.Name = "C_R10_JUDGE";
            this.C_R10_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R10_JUDGE.Text = "";
            this.C_R10_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_JUDGE.WordWrap = false;
            // 
            // L_R10_DX1
            // 
            this.L_R10_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R10_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R10_DX1.BorderWidth = 0.5F;
            this.L_R10_DX1.CanGrow = false;
            this.L_R10_DX1.Dpi = 100F;
            this.L_R10_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 535F);
            this.L_R10_DX1.Multiline = true;
            this.L_R10_DX1.Name = "L_R10_DX1";
            this.L_R10_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R10_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R10_DX1.Text = "";
            this.L_R10_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R10_DX1.WordWrap = false;
            // 
            // L_R10_DX2
            // 
            this.L_R10_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R10_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R10_DX2.BorderWidth = 0.5F;
            this.L_R10_DX2.CanGrow = false;
            this.L_R10_DX2.Dpi = 100F;
            this.L_R10_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 535F);
            this.L_R10_DX2.Multiline = true;
            this.L_R10_DX2.Name = "L_R10_DX2";
            this.L_R10_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R10_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R10_DX2.Text = "";
            this.L_R10_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R10_DX2.WordWrap = false;
            // 
            // L_R10_DX3
            // 
            this.L_R10_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R10_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R10_DX3.BorderWidth = 0.5F;
            this.L_R10_DX3.CanGrow = false;
            this.L_R10_DX3.Dpi = 100F;
            this.L_R10_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 535F);
            this.L_R10_DX3.Multiline = true;
            this.L_R10_DX3.Name = "L_R10_DX3";
            this.L_R10_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R10_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R10_DX3.Text = "";
            this.L_R10_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R10_DX3.WordWrap = false;
            // 
            // L_R10_DX4
            // 
            this.L_R10_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R10_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R10_DX4.BorderWidth = 0.5F;
            this.L_R10_DX4.CanGrow = false;
            this.L_R10_DX4.Dpi = 100F;
            this.L_R10_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 535F);
            this.L_R10_DX4.Multiline = true;
            this.L_R10_DX4.Name = "L_R10_DX4";
            this.L_R10_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R10_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R10_DX4.Text = "";
            this.L_R10_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R10_DX4.WordWrap = false;
            // 
            // L_R10_DX5
            // 
            this.L_R10_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R10_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R10_DX5.BorderWidth = 0.5F;
            this.L_R10_DX5.CanGrow = false;
            this.L_R10_DX5.Dpi = 100F;
            this.L_R10_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 535F);
            this.L_R10_DX5.Multiline = true;
            this.L_R10_DX5.Name = "L_R10_DX5";
            this.L_R10_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R10_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R10_DX5.Text = "";
            this.L_R10_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R10_DX5.WordWrap = false;
            // 
            // L_R10_DJ
            // 
            this.L_R10_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R10_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R10_DJ.BorderWidth = 0.5F;
            this.L_R10_DJ.CanGrow = false;
            this.L_R10_DJ.Dpi = 100F;
            this.L_R10_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 535F);
            this.L_R10_DJ.Multiline = true;
            this.L_R10_DJ.Name = "L_R10_DJ";
            this.L_R10_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R10_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R10_DJ.Text = "";
            this.L_R10_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R10_DJ.WordWrap = false;
            // 
            // C_R10_XSPAN
            // 
            this.C_R10_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R10_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R10_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R10_XSPAN.BorderWidth = 0.5F;
            this.C_R10_XSPAN.CanGrow = false;
            this.C_R10_XSPAN.Dpi = 100F;
            this.C_R10_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R10_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 535F);
            this.C_R10_XSPAN.Multiline = true;
            this.C_R10_XSPAN.Name = "C_R10_XSPAN";
            this.C_R10_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R10_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R10_XSPAN.Text = "";
            this.C_R10_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R10_XSPAN.Visible = false;
            this.C_R10_XSPAN.WordWrap = false;
            // 
            // C_R11_NO
            // 
            this.C_R11_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R11_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_NO.BorderWidth = 0.5F;
            this.C_R11_NO.CanGrow = false;
            this.C_R11_NO.Dpi = 100F;
            this.C_R11_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 559F);
            this.C_R11_NO.Multiline = true;
            this.C_R11_NO.Name = "C_R11_NO";
            this.C_R11_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R11_NO.Text = "";
            this.C_R11_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_NO.WordWrap = false;
            // 
            // C_R11_STD
            // 
            this.C_R11_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R11_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_STD.BorderWidth = 0.5F;
            this.C_R11_STD.CanGrow = false;
            this.C_R11_STD.Dpi = 100F;
            this.C_R11_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R11_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 559F);
            this.C_R11_STD.Multiline = true;
            this.C_R11_STD.Name = "C_R11_STD";
            this.C_R11_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R11_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R11_STD.Text = "";
            this.C_R11_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R11_STD.WordWrap = true;
            // 
            // C_R11_SPEC
            // 
            this.C_R11_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R11_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_SPEC.BorderWidth = 0.5F;
            this.C_R11_SPEC.CanGrow = false;
            this.C_R11_SPEC.Dpi = 100F;
            this.C_R11_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R11_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 559F);
            this.C_R11_SPEC.Multiline = true;
            this.C_R11_SPEC.Name = "C_R11_SPEC";
            this.C_R11_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R11_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R11_SPEC.Text = "";
            this.C_R11_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R11_SPEC.WordWrap = true;
            // 
            // L_R11_MGR
            // 
            this.L_R11_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R11_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R11_MGR.BorderWidth = 0.5F;
            this.L_R11_MGR.CanGrow = false;
            this.L_R11_MGR.Dpi = 100F;
            this.L_R11_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 559F);
            this.L_R11_MGR.Multiline = true;
            this.L_R11_MGR.Name = "L_R11_MGR";
            this.L_R11_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R11_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R11_MGR.Text = "";
            this.L_R11_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R11_MGR.WordWrap = false;
            // 
            // C_R11_X1
            // 
            this.C_R11_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R11_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_X1.BorderWidth = 0.5F;
            this.C_R11_X1.CanGrow = false;
            this.C_R11_X1.Dpi = 100F;
            this.C_R11_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 559F);
            this.C_R11_X1.Multiline = true;
            this.C_R11_X1.Name = "C_R11_X1";
            this.C_R11_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R11_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R11_X1.Text = "";
            this.C_R11_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_X1.WordWrap = false;
            // 
            // C_R11_X2
            // 
            this.C_R11_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R11_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_X2.BorderWidth = 0.5F;
            this.C_R11_X2.CanGrow = false;
            this.C_R11_X2.Dpi = 100F;
            this.C_R11_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 559F);
            this.C_R11_X2.Multiline = true;
            this.C_R11_X2.Name = "C_R11_X2";
            this.C_R11_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R11_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R11_X2.Text = "";
            this.C_R11_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_X2.WordWrap = false;
            // 
            // C_R11_X3
            // 
            this.C_R11_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R11_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_X3.BorderWidth = 0.5F;
            this.C_R11_X3.CanGrow = false;
            this.C_R11_X3.Dpi = 100F;
            this.C_R11_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 559F);
            this.C_R11_X3.Multiline = true;
            this.C_R11_X3.Name = "C_R11_X3";
            this.C_R11_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R11_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R11_X3.Text = "";
            this.C_R11_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_X3.WordWrap = false;
            // 
            // C_R11_X4
            // 
            this.C_R11_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R11_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_X4.BorderWidth = 0.5F;
            this.C_R11_X4.CanGrow = false;
            this.C_R11_X4.Dpi = 100F;
            this.C_R11_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 559F);
            this.C_R11_X4.Multiline = true;
            this.C_R11_X4.Name = "C_R11_X4";
            this.C_R11_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R11_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R11_X4.Text = "";
            this.C_R11_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_X4.WordWrap = false;
            // 
            // C_R11_X5
            // 
            this.C_R11_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R11_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_X5.BorderWidth = 0.5F;
            this.C_R11_X5.CanGrow = false;
            this.C_R11_X5.Dpi = 100F;
            this.C_R11_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R11_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 559F);
            this.C_R11_X5.Multiline = true;
            this.C_R11_X5.Name = "C_R11_X5";
            this.C_R11_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R11_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R11_X5.Text = "";
            this.C_R11_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_X5.WordWrap = false;
            // 
            // C_R11_JUDGE
            // 
            this.C_R11_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R11_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_JUDGE.BorderWidth = 0.5F;
            this.C_R11_JUDGE.CanGrow = false;
            this.C_R11_JUDGE.Dpi = 100F;
            this.C_R11_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 559F);
            this.C_R11_JUDGE.Multiline = true;
            this.C_R11_JUDGE.Name = "C_R11_JUDGE";
            this.C_R11_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R11_JUDGE.Text = "";
            this.C_R11_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_JUDGE.WordWrap = false;
            // 
            // L_R11_DX1
            // 
            this.L_R11_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R11_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R11_DX1.BorderWidth = 0.5F;
            this.L_R11_DX1.CanGrow = false;
            this.L_R11_DX1.Dpi = 100F;
            this.L_R11_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 559F);
            this.L_R11_DX1.Multiline = true;
            this.L_R11_DX1.Name = "L_R11_DX1";
            this.L_R11_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R11_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R11_DX1.Text = "";
            this.L_R11_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R11_DX1.WordWrap = false;
            // 
            // L_R11_DX2
            // 
            this.L_R11_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R11_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R11_DX2.BorderWidth = 0.5F;
            this.L_R11_DX2.CanGrow = false;
            this.L_R11_DX2.Dpi = 100F;
            this.L_R11_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 559F);
            this.L_R11_DX2.Multiline = true;
            this.L_R11_DX2.Name = "L_R11_DX2";
            this.L_R11_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R11_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R11_DX2.Text = "";
            this.L_R11_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R11_DX2.WordWrap = false;
            // 
            // L_R11_DX3
            // 
            this.L_R11_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R11_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R11_DX3.BorderWidth = 0.5F;
            this.L_R11_DX3.CanGrow = false;
            this.L_R11_DX3.Dpi = 100F;
            this.L_R11_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 559F);
            this.L_R11_DX3.Multiline = true;
            this.L_R11_DX3.Name = "L_R11_DX3";
            this.L_R11_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R11_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R11_DX3.Text = "";
            this.L_R11_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R11_DX3.WordWrap = false;
            // 
            // L_R11_DX4
            // 
            this.L_R11_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R11_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R11_DX4.BorderWidth = 0.5F;
            this.L_R11_DX4.CanGrow = false;
            this.L_R11_DX4.Dpi = 100F;
            this.L_R11_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 559F);
            this.L_R11_DX4.Multiline = true;
            this.L_R11_DX4.Name = "L_R11_DX4";
            this.L_R11_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R11_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R11_DX4.Text = "";
            this.L_R11_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R11_DX4.WordWrap = false;
            // 
            // L_R11_DX5
            // 
            this.L_R11_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R11_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R11_DX5.BorderWidth = 0.5F;
            this.L_R11_DX5.CanGrow = false;
            this.L_R11_DX5.Dpi = 100F;
            this.L_R11_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 559F);
            this.L_R11_DX5.Multiline = true;
            this.L_R11_DX5.Name = "L_R11_DX5";
            this.L_R11_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R11_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R11_DX5.Text = "";
            this.L_R11_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R11_DX5.WordWrap = false;
            // 
            // L_R11_DJ
            // 
            this.L_R11_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R11_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R11_DJ.BorderWidth = 0.5F;
            this.L_R11_DJ.CanGrow = false;
            this.L_R11_DJ.Dpi = 100F;
            this.L_R11_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 559F);
            this.L_R11_DJ.Multiline = true;
            this.L_R11_DJ.Name = "L_R11_DJ";
            this.L_R11_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R11_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R11_DJ.Text = "";
            this.L_R11_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R11_DJ.WordWrap = false;
            // 
            // C_R11_XSPAN
            // 
            this.C_R11_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R11_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R11_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R11_XSPAN.BorderWidth = 0.5F;
            this.C_R11_XSPAN.CanGrow = false;
            this.C_R11_XSPAN.Dpi = 100F;
            this.C_R11_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R11_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 559F);
            this.C_R11_XSPAN.Multiline = true;
            this.C_R11_XSPAN.Name = "C_R11_XSPAN";
            this.C_R11_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R11_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R11_XSPAN.Text = "";
            this.C_R11_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R11_XSPAN.Visible = false;
            this.C_R11_XSPAN.WordWrap = false;
            // 
            // C_R12_NO
            // 
            this.C_R12_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R12_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_NO.BorderWidth = 0.5F;
            this.C_R12_NO.CanGrow = false;
            this.C_R12_NO.Dpi = 100F;
            this.C_R12_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 583F);
            this.C_R12_NO.Multiline = true;
            this.C_R12_NO.Name = "C_R12_NO";
            this.C_R12_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R12_NO.Text = "";
            this.C_R12_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_NO.WordWrap = false;
            // 
            // C_R12_STD
            // 
            this.C_R12_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R12_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_STD.BorderWidth = 0.5F;
            this.C_R12_STD.CanGrow = false;
            this.C_R12_STD.Dpi = 100F;
            this.C_R12_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R12_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 583F);
            this.C_R12_STD.Multiline = true;
            this.C_R12_STD.Name = "C_R12_STD";
            this.C_R12_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R12_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R12_STD.Text = "";
            this.C_R12_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R12_STD.WordWrap = true;
            // 
            // C_R12_SPEC
            // 
            this.C_R12_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R12_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_SPEC.BorderWidth = 0.5F;
            this.C_R12_SPEC.CanGrow = false;
            this.C_R12_SPEC.Dpi = 100F;
            this.C_R12_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R12_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 583F);
            this.C_R12_SPEC.Multiline = true;
            this.C_R12_SPEC.Name = "C_R12_SPEC";
            this.C_R12_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R12_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R12_SPEC.Text = "";
            this.C_R12_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R12_SPEC.WordWrap = true;
            // 
            // L_R12_MGR
            // 
            this.L_R12_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R12_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R12_MGR.BorderWidth = 0.5F;
            this.L_R12_MGR.CanGrow = false;
            this.L_R12_MGR.Dpi = 100F;
            this.L_R12_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 583F);
            this.L_R12_MGR.Multiline = true;
            this.L_R12_MGR.Name = "L_R12_MGR";
            this.L_R12_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R12_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R12_MGR.Text = "";
            this.L_R12_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R12_MGR.WordWrap = false;
            // 
            // C_R12_X1
            // 
            this.C_R12_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R12_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_X1.BorderWidth = 0.5F;
            this.C_R12_X1.CanGrow = false;
            this.C_R12_X1.Dpi = 100F;
            this.C_R12_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 583F);
            this.C_R12_X1.Multiline = true;
            this.C_R12_X1.Name = "C_R12_X1";
            this.C_R12_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R12_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R12_X1.Text = "";
            this.C_R12_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_X1.WordWrap = false;
            // 
            // C_R12_X2
            // 
            this.C_R12_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R12_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_X2.BorderWidth = 0.5F;
            this.C_R12_X2.CanGrow = false;
            this.C_R12_X2.Dpi = 100F;
            this.C_R12_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 583F);
            this.C_R12_X2.Multiline = true;
            this.C_R12_X2.Name = "C_R12_X2";
            this.C_R12_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R12_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R12_X2.Text = "";
            this.C_R12_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_X2.WordWrap = false;
            // 
            // C_R12_X3
            // 
            this.C_R12_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R12_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_X3.BorderWidth = 0.5F;
            this.C_R12_X3.CanGrow = false;
            this.C_R12_X3.Dpi = 100F;
            this.C_R12_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 583F);
            this.C_R12_X3.Multiline = true;
            this.C_R12_X3.Name = "C_R12_X3";
            this.C_R12_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R12_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R12_X3.Text = "";
            this.C_R12_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_X3.WordWrap = false;
            // 
            // C_R12_X4
            // 
            this.C_R12_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R12_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_X4.BorderWidth = 0.5F;
            this.C_R12_X4.CanGrow = false;
            this.C_R12_X4.Dpi = 100F;
            this.C_R12_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 583F);
            this.C_R12_X4.Multiline = true;
            this.C_R12_X4.Name = "C_R12_X4";
            this.C_R12_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R12_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R12_X4.Text = "";
            this.C_R12_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_X4.WordWrap = false;
            // 
            // C_R12_X5
            // 
            this.C_R12_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R12_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_X5.BorderWidth = 0.5F;
            this.C_R12_X5.CanGrow = false;
            this.C_R12_X5.Dpi = 100F;
            this.C_R12_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R12_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 583F);
            this.C_R12_X5.Multiline = true;
            this.C_R12_X5.Name = "C_R12_X5";
            this.C_R12_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R12_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R12_X5.Text = "";
            this.C_R12_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_X5.WordWrap = false;
            // 
            // C_R12_JUDGE
            // 
            this.C_R12_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R12_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_JUDGE.BorderWidth = 0.5F;
            this.C_R12_JUDGE.CanGrow = false;
            this.C_R12_JUDGE.Dpi = 100F;
            this.C_R12_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 583F);
            this.C_R12_JUDGE.Multiline = true;
            this.C_R12_JUDGE.Name = "C_R12_JUDGE";
            this.C_R12_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R12_JUDGE.Text = "";
            this.C_R12_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_JUDGE.WordWrap = false;
            // 
            // L_R12_DX1
            // 
            this.L_R12_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R12_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R12_DX1.BorderWidth = 0.5F;
            this.L_R12_DX1.CanGrow = false;
            this.L_R12_DX1.Dpi = 100F;
            this.L_R12_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 583F);
            this.L_R12_DX1.Multiline = true;
            this.L_R12_DX1.Name = "L_R12_DX1";
            this.L_R12_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R12_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R12_DX1.Text = "";
            this.L_R12_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R12_DX1.WordWrap = false;
            // 
            // L_R12_DX2
            // 
            this.L_R12_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R12_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R12_DX2.BorderWidth = 0.5F;
            this.L_R12_DX2.CanGrow = false;
            this.L_R12_DX2.Dpi = 100F;
            this.L_R12_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 583F);
            this.L_R12_DX2.Multiline = true;
            this.L_R12_DX2.Name = "L_R12_DX2";
            this.L_R12_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R12_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R12_DX2.Text = "";
            this.L_R12_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R12_DX2.WordWrap = false;
            // 
            // L_R12_DX3
            // 
            this.L_R12_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R12_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R12_DX3.BorderWidth = 0.5F;
            this.L_R12_DX3.CanGrow = false;
            this.L_R12_DX3.Dpi = 100F;
            this.L_R12_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 583F);
            this.L_R12_DX3.Multiline = true;
            this.L_R12_DX3.Name = "L_R12_DX3";
            this.L_R12_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R12_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R12_DX3.Text = "";
            this.L_R12_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R12_DX3.WordWrap = false;
            // 
            // L_R12_DX4
            // 
            this.L_R12_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R12_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R12_DX4.BorderWidth = 0.5F;
            this.L_R12_DX4.CanGrow = false;
            this.L_R12_DX4.Dpi = 100F;
            this.L_R12_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 583F);
            this.L_R12_DX4.Multiline = true;
            this.L_R12_DX4.Name = "L_R12_DX4";
            this.L_R12_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R12_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R12_DX4.Text = "";
            this.L_R12_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R12_DX4.WordWrap = false;
            // 
            // L_R12_DX5
            // 
            this.L_R12_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R12_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R12_DX5.BorderWidth = 0.5F;
            this.L_R12_DX5.CanGrow = false;
            this.L_R12_DX5.Dpi = 100F;
            this.L_R12_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 583F);
            this.L_R12_DX5.Multiline = true;
            this.L_R12_DX5.Name = "L_R12_DX5";
            this.L_R12_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R12_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R12_DX5.Text = "";
            this.L_R12_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R12_DX5.WordWrap = false;
            // 
            // L_R12_DJ
            // 
            this.L_R12_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R12_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R12_DJ.BorderWidth = 0.5F;
            this.L_R12_DJ.CanGrow = false;
            this.L_R12_DJ.Dpi = 100F;
            this.L_R12_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 583F);
            this.L_R12_DJ.Multiline = true;
            this.L_R12_DJ.Name = "L_R12_DJ";
            this.L_R12_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R12_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R12_DJ.Text = "";
            this.L_R12_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R12_DJ.WordWrap = false;
            // 
            // C_R12_XSPAN
            // 
            this.C_R12_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R12_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R12_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R12_XSPAN.BorderWidth = 0.5F;
            this.C_R12_XSPAN.CanGrow = false;
            this.C_R12_XSPAN.Dpi = 100F;
            this.C_R12_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R12_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 583F);
            this.C_R12_XSPAN.Multiline = true;
            this.C_R12_XSPAN.Name = "C_R12_XSPAN";
            this.C_R12_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R12_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R12_XSPAN.Text = "";
            this.C_R12_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R12_XSPAN.Visible = false;
            this.C_R12_XSPAN.WordWrap = false;
            // 
            // C_R13_NO
            // 
            this.C_R13_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R13_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_NO.BorderWidth = 0.5F;
            this.C_R13_NO.CanGrow = false;
            this.C_R13_NO.Dpi = 100F;
            this.C_R13_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 607F);
            this.C_R13_NO.Multiline = true;
            this.C_R13_NO.Name = "C_R13_NO";
            this.C_R13_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R13_NO.Text = "";
            this.C_R13_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_NO.WordWrap = false;
            // 
            // C_R13_STD
            // 
            this.C_R13_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R13_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_STD.BorderWidth = 0.5F;
            this.C_R13_STD.CanGrow = false;
            this.C_R13_STD.Dpi = 100F;
            this.C_R13_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R13_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 607F);
            this.C_R13_STD.Multiline = true;
            this.C_R13_STD.Name = "C_R13_STD";
            this.C_R13_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R13_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R13_STD.Text = "";
            this.C_R13_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R13_STD.WordWrap = true;
            // 
            // C_R13_SPEC
            // 
            this.C_R13_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R13_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_SPEC.BorderWidth = 0.5F;
            this.C_R13_SPEC.CanGrow = false;
            this.C_R13_SPEC.Dpi = 100F;
            this.C_R13_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R13_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 607F);
            this.C_R13_SPEC.Multiline = true;
            this.C_R13_SPEC.Name = "C_R13_SPEC";
            this.C_R13_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R13_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R13_SPEC.Text = "";
            this.C_R13_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R13_SPEC.WordWrap = true;
            // 
            // L_R13_MGR
            // 
            this.L_R13_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R13_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R13_MGR.BorderWidth = 0.5F;
            this.L_R13_MGR.CanGrow = false;
            this.L_R13_MGR.Dpi = 100F;
            this.L_R13_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 607F);
            this.L_R13_MGR.Multiline = true;
            this.L_R13_MGR.Name = "L_R13_MGR";
            this.L_R13_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R13_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R13_MGR.Text = "";
            this.L_R13_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R13_MGR.WordWrap = false;
            // 
            // C_R13_X1
            // 
            this.C_R13_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R13_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_X1.BorderWidth = 0.5F;
            this.C_R13_X1.CanGrow = false;
            this.C_R13_X1.Dpi = 100F;
            this.C_R13_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 607F);
            this.C_R13_X1.Multiline = true;
            this.C_R13_X1.Name = "C_R13_X1";
            this.C_R13_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R13_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R13_X1.Text = "";
            this.C_R13_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_X1.WordWrap = false;
            // 
            // C_R13_X2
            // 
            this.C_R13_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R13_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_X2.BorderWidth = 0.5F;
            this.C_R13_X2.CanGrow = false;
            this.C_R13_X2.Dpi = 100F;
            this.C_R13_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 607F);
            this.C_R13_X2.Multiline = true;
            this.C_R13_X2.Name = "C_R13_X2";
            this.C_R13_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R13_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R13_X2.Text = "";
            this.C_R13_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_X2.WordWrap = false;
            // 
            // C_R13_X3
            // 
            this.C_R13_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R13_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_X3.BorderWidth = 0.5F;
            this.C_R13_X3.CanGrow = false;
            this.C_R13_X3.Dpi = 100F;
            this.C_R13_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 607F);
            this.C_R13_X3.Multiline = true;
            this.C_R13_X3.Name = "C_R13_X3";
            this.C_R13_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R13_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R13_X3.Text = "";
            this.C_R13_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_X3.WordWrap = false;
            // 
            // C_R13_X4
            // 
            this.C_R13_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R13_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_X4.BorderWidth = 0.5F;
            this.C_R13_X4.CanGrow = false;
            this.C_R13_X4.Dpi = 100F;
            this.C_R13_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 607F);
            this.C_R13_X4.Multiline = true;
            this.C_R13_X4.Name = "C_R13_X4";
            this.C_R13_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R13_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R13_X4.Text = "";
            this.C_R13_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_X4.WordWrap = false;
            // 
            // C_R13_X5
            // 
            this.C_R13_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R13_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_X5.BorderWidth = 0.5F;
            this.C_R13_X5.CanGrow = false;
            this.C_R13_X5.Dpi = 100F;
            this.C_R13_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R13_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 607F);
            this.C_R13_X5.Multiline = true;
            this.C_R13_X5.Name = "C_R13_X5";
            this.C_R13_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R13_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R13_X5.Text = "";
            this.C_R13_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_X5.WordWrap = false;
            // 
            // C_R13_JUDGE
            // 
            this.C_R13_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R13_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_JUDGE.BorderWidth = 0.5F;
            this.C_R13_JUDGE.CanGrow = false;
            this.C_R13_JUDGE.Dpi = 100F;
            this.C_R13_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 607F);
            this.C_R13_JUDGE.Multiline = true;
            this.C_R13_JUDGE.Name = "C_R13_JUDGE";
            this.C_R13_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R13_JUDGE.Text = "";
            this.C_R13_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_JUDGE.WordWrap = false;
            // 
            // L_R13_DX1
            // 
            this.L_R13_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R13_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R13_DX1.BorderWidth = 0.5F;
            this.L_R13_DX1.CanGrow = false;
            this.L_R13_DX1.Dpi = 100F;
            this.L_R13_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 607F);
            this.L_R13_DX1.Multiline = true;
            this.L_R13_DX1.Name = "L_R13_DX1";
            this.L_R13_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R13_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R13_DX1.Text = "";
            this.L_R13_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R13_DX1.WordWrap = false;
            // 
            // L_R13_DX2
            // 
            this.L_R13_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R13_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R13_DX2.BorderWidth = 0.5F;
            this.L_R13_DX2.CanGrow = false;
            this.L_R13_DX2.Dpi = 100F;
            this.L_R13_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 607F);
            this.L_R13_DX2.Multiline = true;
            this.L_R13_DX2.Name = "L_R13_DX2";
            this.L_R13_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R13_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R13_DX2.Text = "";
            this.L_R13_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R13_DX2.WordWrap = false;
            // 
            // L_R13_DX3
            // 
            this.L_R13_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R13_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R13_DX3.BorderWidth = 0.5F;
            this.L_R13_DX3.CanGrow = false;
            this.L_R13_DX3.Dpi = 100F;
            this.L_R13_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 607F);
            this.L_R13_DX3.Multiline = true;
            this.L_R13_DX3.Name = "L_R13_DX3";
            this.L_R13_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R13_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R13_DX3.Text = "";
            this.L_R13_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R13_DX3.WordWrap = false;
            // 
            // L_R13_DX4
            // 
            this.L_R13_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R13_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R13_DX4.BorderWidth = 0.5F;
            this.L_R13_DX4.CanGrow = false;
            this.L_R13_DX4.Dpi = 100F;
            this.L_R13_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 607F);
            this.L_R13_DX4.Multiline = true;
            this.L_R13_DX4.Name = "L_R13_DX4";
            this.L_R13_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R13_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R13_DX4.Text = "";
            this.L_R13_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R13_DX4.WordWrap = false;
            // 
            // L_R13_DX5
            // 
            this.L_R13_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R13_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R13_DX5.BorderWidth = 0.5F;
            this.L_R13_DX5.CanGrow = false;
            this.L_R13_DX5.Dpi = 100F;
            this.L_R13_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 607F);
            this.L_R13_DX5.Multiline = true;
            this.L_R13_DX5.Name = "L_R13_DX5";
            this.L_R13_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R13_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R13_DX5.Text = "";
            this.L_R13_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R13_DX5.WordWrap = false;
            // 
            // L_R13_DJ
            // 
            this.L_R13_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R13_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R13_DJ.BorderWidth = 0.5F;
            this.L_R13_DJ.CanGrow = false;
            this.L_R13_DJ.Dpi = 100F;
            this.L_R13_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 607F);
            this.L_R13_DJ.Multiline = true;
            this.L_R13_DJ.Name = "L_R13_DJ";
            this.L_R13_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R13_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R13_DJ.Text = "";
            this.L_R13_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R13_DJ.WordWrap = false;
            // 
            // C_R13_XSPAN
            // 
            this.C_R13_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R13_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R13_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R13_XSPAN.BorderWidth = 0.5F;
            this.C_R13_XSPAN.CanGrow = false;
            this.C_R13_XSPAN.Dpi = 100F;
            this.C_R13_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R13_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 607F);
            this.C_R13_XSPAN.Multiline = true;
            this.C_R13_XSPAN.Name = "C_R13_XSPAN";
            this.C_R13_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R13_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R13_XSPAN.Text = "";
            this.C_R13_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R13_XSPAN.Visible = false;
            this.C_R13_XSPAN.WordWrap = false;
            // 
            // C_R14_NO
            // 
            this.C_R14_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R14_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_NO.BorderWidth = 0.5F;
            this.C_R14_NO.CanGrow = false;
            this.C_R14_NO.Dpi = 100F;
            this.C_R14_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 631F);
            this.C_R14_NO.Multiline = true;
            this.C_R14_NO.Name = "C_R14_NO";
            this.C_R14_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R14_NO.Text = "";
            this.C_R14_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_NO.WordWrap = false;
            // 
            // C_R14_STD
            // 
            this.C_R14_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R14_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_STD.BorderWidth = 0.5F;
            this.C_R14_STD.CanGrow = false;
            this.C_R14_STD.Dpi = 100F;
            this.C_R14_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R14_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 631F);
            this.C_R14_STD.Multiline = true;
            this.C_R14_STD.Name = "C_R14_STD";
            this.C_R14_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R14_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R14_STD.Text = "";
            this.C_R14_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R14_STD.WordWrap = true;
            // 
            // C_R14_SPEC
            // 
            this.C_R14_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R14_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_SPEC.BorderWidth = 0.5F;
            this.C_R14_SPEC.CanGrow = false;
            this.C_R14_SPEC.Dpi = 100F;
            this.C_R14_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R14_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 631F);
            this.C_R14_SPEC.Multiline = true;
            this.C_R14_SPEC.Name = "C_R14_SPEC";
            this.C_R14_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R14_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R14_SPEC.Text = "";
            this.C_R14_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R14_SPEC.WordWrap = true;
            // 
            // L_R14_MGR
            // 
            this.L_R14_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R14_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R14_MGR.BorderWidth = 0.5F;
            this.L_R14_MGR.CanGrow = false;
            this.L_R14_MGR.Dpi = 100F;
            this.L_R14_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 631F);
            this.L_R14_MGR.Multiline = true;
            this.L_R14_MGR.Name = "L_R14_MGR";
            this.L_R14_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R14_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R14_MGR.Text = "";
            this.L_R14_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R14_MGR.WordWrap = false;
            // 
            // C_R14_X1
            // 
            this.C_R14_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R14_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_X1.BorderWidth = 0.5F;
            this.C_R14_X1.CanGrow = false;
            this.C_R14_X1.Dpi = 100F;
            this.C_R14_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 631F);
            this.C_R14_X1.Multiline = true;
            this.C_R14_X1.Name = "C_R14_X1";
            this.C_R14_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R14_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R14_X1.Text = "";
            this.C_R14_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_X1.WordWrap = false;
            // 
            // C_R14_X2
            // 
            this.C_R14_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R14_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_X2.BorderWidth = 0.5F;
            this.C_R14_X2.CanGrow = false;
            this.C_R14_X2.Dpi = 100F;
            this.C_R14_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 631F);
            this.C_R14_X2.Multiline = true;
            this.C_R14_X2.Name = "C_R14_X2";
            this.C_R14_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R14_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R14_X2.Text = "";
            this.C_R14_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_X2.WordWrap = false;
            // 
            // C_R14_X3
            // 
            this.C_R14_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R14_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_X3.BorderWidth = 0.5F;
            this.C_R14_X3.CanGrow = false;
            this.C_R14_X3.Dpi = 100F;
            this.C_R14_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 631F);
            this.C_R14_X3.Multiline = true;
            this.C_R14_X3.Name = "C_R14_X3";
            this.C_R14_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R14_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R14_X3.Text = "";
            this.C_R14_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_X3.WordWrap = false;
            // 
            // C_R14_X4
            // 
            this.C_R14_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R14_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_X4.BorderWidth = 0.5F;
            this.C_R14_X4.CanGrow = false;
            this.C_R14_X4.Dpi = 100F;
            this.C_R14_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 631F);
            this.C_R14_X4.Multiline = true;
            this.C_R14_X4.Name = "C_R14_X4";
            this.C_R14_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R14_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R14_X4.Text = "";
            this.C_R14_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_X4.WordWrap = false;
            // 
            // C_R14_X5
            // 
            this.C_R14_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R14_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_X5.BorderWidth = 0.5F;
            this.C_R14_X5.CanGrow = false;
            this.C_R14_X5.Dpi = 100F;
            this.C_R14_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R14_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 631F);
            this.C_R14_X5.Multiline = true;
            this.C_R14_X5.Name = "C_R14_X5";
            this.C_R14_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R14_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R14_X5.Text = "";
            this.C_R14_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_X5.WordWrap = false;
            // 
            // C_R14_JUDGE
            // 
            this.C_R14_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R14_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_JUDGE.BorderWidth = 0.5F;
            this.C_R14_JUDGE.CanGrow = false;
            this.C_R14_JUDGE.Dpi = 100F;
            this.C_R14_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 631F);
            this.C_R14_JUDGE.Multiline = true;
            this.C_R14_JUDGE.Name = "C_R14_JUDGE";
            this.C_R14_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R14_JUDGE.Text = "";
            this.C_R14_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_JUDGE.WordWrap = false;
            // 
            // L_R14_DX1
            // 
            this.L_R14_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R14_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R14_DX1.BorderWidth = 0.5F;
            this.L_R14_DX1.CanGrow = false;
            this.L_R14_DX1.Dpi = 100F;
            this.L_R14_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 631F);
            this.L_R14_DX1.Multiline = true;
            this.L_R14_DX1.Name = "L_R14_DX1";
            this.L_R14_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R14_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R14_DX1.Text = "";
            this.L_R14_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R14_DX1.WordWrap = false;
            // 
            // L_R14_DX2
            // 
            this.L_R14_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R14_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R14_DX2.BorderWidth = 0.5F;
            this.L_R14_DX2.CanGrow = false;
            this.L_R14_DX2.Dpi = 100F;
            this.L_R14_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 631F);
            this.L_R14_DX2.Multiline = true;
            this.L_R14_DX2.Name = "L_R14_DX2";
            this.L_R14_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R14_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R14_DX2.Text = "";
            this.L_R14_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R14_DX2.WordWrap = false;
            // 
            // L_R14_DX3
            // 
            this.L_R14_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R14_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R14_DX3.BorderWidth = 0.5F;
            this.L_R14_DX3.CanGrow = false;
            this.L_R14_DX3.Dpi = 100F;
            this.L_R14_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 631F);
            this.L_R14_DX3.Multiline = true;
            this.L_R14_DX3.Name = "L_R14_DX3";
            this.L_R14_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R14_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R14_DX3.Text = "";
            this.L_R14_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R14_DX3.WordWrap = false;
            // 
            // L_R14_DX4
            // 
            this.L_R14_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R14_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R14_DX4.BorderWidth = 0.5F;
            this.L_R14_DX4.CanGrow = false;
            this.L_R14_DX4.Dpi = 100F;
            this.L_R14_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 631F);
            this.L_R14_DX4.Multiline = true;
            this.L_R14_DX4.Name = "L_R14_DX4";
            this.L_R14_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R14_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R14_DX4.Text = "";
            this.L_R14_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R14_DX4.WordWrap = false;
            // 
            // L_R14_DX5
            // 
            this.L_R14_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R14_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R14_DX5.BorderWidth = 0.5F;
            this.L_R14_DX5.CanGrow = false;
            this.L_R14_DX5.Dpi = 100F;
            this.L_R14_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 631F);
            this.L_R14_DX5.Multiline = true;
            this.L_R14_DX5.Name = "L_R14_DX5";
            this.L_R14_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R14_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R14_DX5.Text = "";
            this.L_R14_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R14_DX5.WordWrap = false;
            // 
            // L_R14_DJ
            // 
            this.L_R14_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R14_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R14_DJ.BorderWidth = 0.5F;
            this.L_R14_DJ.CanGrow = false;
            this.L_R14_DJ.Dpi = 100F;
            this.L_R14_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 631F);
            this.L_R14_DJ.Multiline = true;
            this.L_R14_DJ.Name = "L_R14_DJ";
            this.L_R14_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R14_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R14_DJ.Text = "";
            this.L_R14_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R14_DJ.WordWrap = false;
            // 
            // C_R14_XSPAN
            // 
            this.C_R14_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R14_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R14_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R14_XSPAN.BorderWidth = 0.5F;
            this.C_R14_XSPAN.CanGrow = false;
            this.C_R14_XSPAN.Dpi = 100F;
            this.C_R14_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R14_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 631F);
            this.C_R14_XSPAN.Multiline = true;
            this.C_R14_XSPAN.Name = "C_R14_XSPAN";
            this.C_R14_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R14_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R14_XSPAN.Text = "";
            this.C_R14_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R14_XSPAN.Visible = false;
            this.C_R14_XSPAN.WordWrap = false;
            // 
            // C_R15_NO
            // 
            this.C_R15_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R15_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_NO.BorderWidth = 0.5F;
            this.C_R15_NO.CanGrow = false;
            this.C_R15_NO.Dpi = 100F;
            this.C_R15_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 655F);
            this.C_R15_NO.Multiline = true;
            this.C_R15_NO.Name = "C_R15_NO";
            this.C_R15_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R15_NO.Text = "";
            this.C_R15_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_NO.WordWrap = false;
            // 
            // C_R15_STD
            // 
            this.C_R15_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R15_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_STD.BorderWidth = 0.5F;
            this.C_R15_STD.CanGrow = false;
            this.C_R15_STD.Dpi = 100F;
            this.C_R15_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R15_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 655F);
            this.C_R15_STD.Multiline = true;
            this.C_R15_STD.Name = "C_R15_STD";
            this.C_R15_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R15_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R15_STD.Text = "";
            this.C_R15_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R15_STD.WordWrap = true;
            // 
            // C_R15_SPEC
            // 
            this.C_R15_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R15_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_SPEC.BorderWidth = 0.5F;
            this.C_R15_SPEC.CanGrow = false;
            this.C_R15_SPEC.Dpi = 100F;
            this.C_R15_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R15_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 655F);
            this.C_R15_SPEC.Multiline = true;
            this.C_R15_SPEC.Name = "C_R15_SPEC";
            this.C_R15_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R15_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R15_SPEC.Text = "";
            this.C_R15_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R15_SPEC.WordWrap = true;
            // 
            // L_R15_MGR
            // 
            this.L_R15_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R15_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R15_MGR.BorderWidth = 0.5F;
            this.L_R15_MGR.CanGrow = false;
            this.L_R15_MGR.Dpi = 100F;
            this.L_R15_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 655F);
            this.L_R15_MGR.Multiline = true;
            this.L_R15_MGR.Name = "L_R15_MGR";
            this.L_R15_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R15_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R15_MGR.Text = "";
            this.L_R15_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R15_MGR.WordWrap = false;
            // 
            // C_R15_X1
            // 
            this.C_R15_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R15_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_X1.BorderWidth = 0.5F;
            this.C_R15_X1.CanGrow = false;
            this.C_R15_X1.Dpi = 100F;
            this.C_R15_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 655F);
            this.C_R15_X1.Multiline = true;
            this.C_R15_X1.Name = "C_R15_X1";
            this.C_R15_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R15_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R15_X1.Text = "";
            this.C_R15_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_X1.WordWrap = false;
            // 
            // C_R15_X2
            // 
            this.C_R15_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R15_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_X2.BorderWidth = 0.5F;
            this.C_R15_X2.CanGrow = false;
            this.C_R15_X2.Dpi = 100F;
            this.C_R15_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 655F);
            this.C_R15_X2.Multiline = true;
            this.C_R15_X2.Name = "C_R15_X2";
            this.C_R15_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R15_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R15_X2.Text = "";
            this.C_R15_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_X2.WordWrap = false;
            // 
            // C_R15_X3
            // 
            this.C_R15_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R15_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_X3.BorderWidth = 0.5F;
            this.C_R15_X3.CanGrow = false;
            this.C_R15_X3.Dpi = 100F;
            this.C_R15_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 655F);
            this.C_R15_X3.Multiline = true;
            this.C_R15_X3.Name = "C_R15_X3";
            this.C_R15_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R15_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R15_X3.Text = "";
            this.C_R15_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_X3.WordWrap = false;
            // 
            // C_R15_X4
            // 
            this.C_R15_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R15_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_X4.BorderWidth = 0.5F;
            this.C_R15_X4.CanGrow = false;
            this.C_R15_X4.Dpi = 100F;
            this.C_R15_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 655F);
            this.C_R15_X4.Multiline = true;
            this.C_R15_X4.Name = "C_R15_X4";
            this.C_R15_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R15_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R15_X4.Text = "";
            this.C_R15_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_X4.WordWrap = false;
            // 
            // C_R15_X5
            // 
            this.C_R15_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R15_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_X5.BorderWidth = 0.5F;
            this.C_R15_X5.CanGrow = false;
            this.C_R15_X5.Dpi = 100F;
            this.C_R15_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R15_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 655F);
            this.C_R15_X5.Multiline = true;
            this.C_R15_X5.Name = "C_R15_X5";
            this.C_R15_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R15_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R15_X5.Text = "";
            this.C_R15_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_X5.WordWrap = false;
            // 
            // C_R15_JUDGE
            // 
            this.C_R15_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R15_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_JUDGE.BorderWidth = 0.5F;
            this.C_R15_JUDGE.CanGrow = false;
            this.C_R15_JUDGE.Dpi = 100F;
            this.C_R15_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 655F);
            this.C_R15_JUDGE.Multiline = true;
            this.C_R15_JUDGE.Name = "C_R15_JUDGE";
            this.C_R15_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R15_JUDGE.Text = "";
            this.C_R15_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_JUDGE.WordWrap = false;
            // 
            // L_R15_DX1
            // 
            this.L_R15_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R15_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R15_DX1.BorderWidth = 0.5F;
            this.L_R15_DX1.CanGrow = false;
            this.L_R15_DX1.Dpi = 100F;
            this.L_R15_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 655F);
            this.L_R15_DX1.Multiline = true;
            this.L_R15_DX1.Name = "L_R15_DX1";
            this.L_R15_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R15_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R15_DX1.Text = "";
            this.L_R15_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R15_DX1.WordWrap = false;
            // 
            // L_R15_DX2
            // 
            this.L_R15_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R15_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R15_DX2.BorderWidth = 0.5F;
            this.L_R15_DX2.CanGrow = false;
            this.L_R15_DX2.Dpi = 100F;
            this.L_R15_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 655F);
            this.L_R15_DX2.Multiline = true;
            this.L_R15_DX2.Name = "L_R15_DX2";
            this.L_R15_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R15_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R15_DX2.Text = "";
            this.L_R15_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R15_DX2.WordWrap = false;
            // 
            // L_R15_DX3
            // 
            this.L_R15_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R15_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R15_DX3.BorderWidth = 0.5F;
            this.L_R15_DX3.CanGrow = false;
            this.L_R15_DX3.Dpi = 100F;
            this.L_R15_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 655F);
            this.L_R15_DX3.Multiline = true;
            this.L_R15_DX3.Name = "L_R15_DX3";
            this.L_R15_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R15_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R15_DX3.Text = "";
            this.L_R15_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R15_DX3.WordWrap = false;
            // 
            // L_R15_DX4
            // 
            this.L_R15_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R15_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R15_DX4.BorderWidth = 0.5F;
            this.L_R15_DX4.CanGrow = false;
            this.L_R15_DX4.Dpi = 100F;
            this.L_R15_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 655F);
            this.L_R15_DX4.Multiline = true;
            this.L_R15_DX4.Name = "L_R15_DX4";
            this.L_R15_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R15_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R15_DX4.Text = "";
            this.L_R15_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R15_DX4.WordWrap = false;
            // 
            // L_R15_DX5
            // 
            this.L_R15_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R15_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R15_DX5.BorderWidth = 0.5F;
            this.L_R15_DX5.CanGrow = false;
            this.L_R15_DX5.Dpi = 100F;
            this.L_R15_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 655F);
            this.L_R15_DX5.Multiline = true;
            this.L_R15_DX5.Name = "L_R15_DX5";
            this.L_R15_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R15_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R15_DX5.Text = "";
            this.L_R15_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R15_DX5.WordWrap = false;
            // 
            // L_R15_DJ
            // 
            this.L_R15_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R15_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R15_DJ.BorderWidth = 0.5F;
            this.L_R15_DJ.CanGrow = false;
            this.L_R15_DJ.Dpi = 100F;
            this.L_R15_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 655F);
            this.L_R15_DJ.Multiline = true;
            this.L_R15_DJ.Name = "L_R15_DJ";
            this.L_R15_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R15_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R15_DJ.Text = "";
            this.L_R15_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R15_DJ.WordWrap = false;
            // 
            // C_R15_XSPAN
            // 
            this.C_R15_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R15_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R15_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R15_XSPAN.BorderWidth = 0.5F;
            this.C_R15_XSPAN.CanGrow = false;
            this.C_R15_XSPAN.Dpi = 100F;
            this.C_R15_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R15_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 655F);
            this.C_R15_XSPAN.Multiline = true;
            this.C_R15_XSPAN.Name = "C_R15_XSPAN";
            this.C_R15_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R15_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R15_XSPAN.Text = "";
            this.C_R15_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R15_XSPAN.Visible = false;
            this.C_R15_XSPAN.WordWrap = false;
            // 
            // C_R16_NO
            // 
            this.C_R16_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R16_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_NO.BorderWidth = 0.5F;
            this.C_R16_NO.CanGrow = false;
            this.C_R16_NO.Dpi = 100F;
            this.C_R16_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 679F);
            this.C_R16_NO.Multiline = true;
            this.C_R16_NO.Name = "C_R16_NO";
            this.C_R16_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R16_NO.Text = "";
            this.C_R16_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_NO.WordWrap = false;
            // 
            // C_R16_STD
            // 
            this.C_R16_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R16_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_STD.BorderWidth = 0.5F;
            this.C_R16_STD.CanGrow = false;
            this.C_R16_STD.Dpi = 100F;
            this.C_R16_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R16_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 679F);
            this.C_R16_STD.Multiline = true;
            this.C_R16_STD.Name = "C_R16_STD";
            this.C_R16_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R16_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R16_STD.Text = "";
            this.C_R16_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R16_STD.WordWrap = true;
            // 
            // C_R16_SPEC
            // 
            this.C_R16_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R16_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_SPEC.BorderWidth = 0.5F;
            this.C_R16_SPEC.CanGrow = false;
            this.C_R16_SPEC.Dpi = 100F;
            this.C_R16_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R16_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 679F);
            this.C_R16_SPEC.Multiline = true;
            this.C_R16_SPEC.Name = "C_R16_SPEC";
            this.C_R16_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R16_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R16_SPEC.Text = "";
            this.C_R16_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R16_SPEC.WordWrap = true;
            // 
            // L_R16_MGR
            // 
            this.L_R16_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R16_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R16_MGR.BorderWidth = 0.5F;
            this.L_R16_MGR.CanGrow = false;
            this.L_R16_MGR.Dpi = 100F;
            this.L_R16_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 679F);
            this.L_R16_MGR.Multiline = true;
            this.L_R16_MGR.Name = "L_R16_MGR";
            this.L_R16_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R16_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R16_MGR.Text = "";
            this.L_R16_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R16_MGR.WordWrap = false;
            // 
            // C_R16_X1
            // 
            this.C_R16_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R16_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_X1.BorderWidth = 0.5F;
            this.C_R16_X1.CanGrow = false;
            this.C_R16_X1.Dpi = 100F;
            this.C_R16_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 679F);
            this.C_R16_X1.Multiline = true;
            this.C_R16_X1.Name = "C_R16_X1";
            this.C_R16_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R16_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R16_X1.Text = "";
            this.C_R16_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_X1.WordWrap = false;
            // 
            // C_R16_X2
            // 
            this.C_R16_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R16_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_X2.BorderWidth = 0.5F;
            this.C_R16_X2.CanGrow = false;
            this.C_R16_X2.Dpi = 100F;
            this.C_R16_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 679F);
            this.C_R16_X2.Multiline = true;
            this.C_R16_X2.Name = "C_R16_X2";
            this.C_R16_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R16_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R16_X2.Text = "";
            this.C_R16_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_X2.WordWrap = false;
            // 
            // C_R16_X3
            // 
            this.C_R16_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R16_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_X3.BorderWidth = 0.5F;
            this.C_R16_X3.CanGrow = false;
            this.C_R16_X3.Dpi = 100F;
            this.C_R16_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 679F);
            this.C_R16_X3.Multiline = true;
            this.C_R16_X3.Name = "C_R16_X3";
            this.C_R16_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R16_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R16_X3.Text = "";
            this.C_R16_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_X3.WordWrap = false;
            // 
            // C_R16_X4
            // 
            this.C_R16_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R16_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_X4.BorderWidth = 0.5F;
            this.C_R16_X4.CanGrow = false;
            this.C_R16_X4.Dpi = 100F;
            this.C_R16_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 679F);
            this.C_R16_X4.Multiline = true;
            this.C_R16_X4.Name = "C_R16_X4";
            this.C_R16_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R16_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R16_X4.Text = "";
            this.C_R16_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_X4.WordWrap = false;
            // 
            // C_R16_X5
            // 
            this.C_R16_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R16_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_X5.BorderWidth = 0.5F;
            this.C_R16_X5.CanGrow = false;
            this.C_R16_X5.Dpi = 100F;
            this.C_R16_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R16_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 679F);
            this.C_R16_X5.Multiline = true;
            this.C_R16_X5.Name = "C_R16_X5";
            this.C_R16_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R16_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R16_X5.Text = "";
            this.C_R16_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_X5.WordWrap = false;
            // 
            // C_R16_JUDGE
            // 
            this.C_R16_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R16_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_JUDGE.BorderWidth = 0.5F;
            this.C_R16_JUDGE.CanGrow = false;
            this.C_R16_JUDGE.Dpi = 100F;
            this.C_R16_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 679F);
            this.C_R16_JUDGE.Multiline = true;
            this.C_R16_JUDGE.Name = "C_R16_JUDGE";
            this.C_R16_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R16_JUDGE.Text = "";
            this.C_R16_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_JUDGE.WordWrap = false;
            // 
            // L_R16_DX1
            // 
            this.L_R16_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R16_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R16_DX1.BorderWidth = 0.5F;
            this.L_R16_DX1.CanGrow = false;
            this.L_R16_DX1.Dpi = 100F;
            this.L_R16_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 679F);
            this.L_R16_DX1.Multiline = true;
            this.L_R16_DX1.Name = "L_R16_DX1";
            this.L_R16_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R16_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R16_DX1.Text = "";
            this.L_R16_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R16_DX1.WordWrap = false;
            // 
            // L_R16_DX2
            // 
            this.L_R16_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R16_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R16_DX2.BorderWidth = 0.5F;
            this.L_R16_DX2.CanGrow = false;
            this.L_R16_DX2.Dpi = 100F;
            this.L_R16_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 679F);
            this.L_R16_DX2.Multiline = true;
            this.L_R16_DX2.Name = "L_R16_DX2";
            this.L_R16_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R16_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R16_DX2.Text = "";
            this.L_R16_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R16_DX2.WordWrap = false;
            // 
            // L_R16_DX3
            // 
            this.L_R16_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R16_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R16_DX3.BorderWidth = 0.5F;
            this.L_R16_DX3.CanGrow = false;
            this.L_R16_DX3.Dpi = 100F;
            this.L_R16_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 679F);
            this.L_R16_DX3.Multiline = true;
            this.L_R16_DX3.Name = "L_R16_DX3";
            this.L_R16_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R16_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R16_DX3.Text = "";
            this.L_R16_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R16_DX3.WordWrap = false;
            // 
            // L_R16_DX4
            // 
            this.L_R16_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R16_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R16_DX4.BorderWidth = 0.5F;
            this.L_R16_DX4.CanGrow = false;
            this.L_R16_DX4.Dpi = 100F;
            this.L_R16_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 679F);
            this.L_R16_DX4.Multiline = true;
            this.L_R16_DX4.Name = "L_R16_DX4";
            this.L_R16_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R16_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R16_DX4.Text = "";
            this.L_R16_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R16_DX4.WordWrap = false;
            // 
            // L_R16_DX5
            // 
            this.L_R16_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R16_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R16_DX5.BorderWidth = 0.5F;
            this.L_R16_DX5.CanGrow = false;
            this.L_R16_DX5.Dpi = 100F;
            this.L_R16_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 679F);
            this.L_R16_DX5.Multiline = true;
            this.L_R16_DX5.Name = "L_R16_DX5";
            this.L_R16_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R16_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R16_DX5.Text = "";
            this.L_R16_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R16_DX5.WordWrap = false;
            // 
            // L_R16_DJ
            // 
            this.L_R16_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R16_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R16_DJ.BorderWidth = 0.5F;
            this.L_R16_DJ.CanGrow = false;
            this.L_R16_DJ.Dpi = 100F;
            this.L_R16_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 679F);
            this.L_R16_DJ.Multiline = true;
            this.L_R16_DJ.Name = "L_R16_DJ";
            this.L_R16_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R16_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R16_DJ.Text = "";
            this.L_R16_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R16_DJ.WordWrap = false;
            // 
            // C_R16_XSPAN
            // 
            this.C_R16_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R16_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R16_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R16_XSPAN.BorderWidth = 0.5F;
            this.C_R16_XSPAN.CanGrow = false;
            this.C_R16_XSPAN.Dpi = 100F;
            this.C_R16_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R16_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 679F);
            this.C_R16_XSPAN.Multiline = true;
            this.C_R16_XSPAN.Name = "C_R16_XSPAN";
            this.C_R16_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R16_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R16_XSPAN.Text = "";
            this.C_R16_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R16_XSPAN.Visible = false;
            this.C_R16_XSPAN.WordWrap = false;
            // 
            // C_R17_NO
            // 
            this.C_R17_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R17_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_NO.BorderWidth = 0.5F;
            this.C_R17_NO.CanGrow = false;
            this.C_R17_NO.Dpi = 100F;
            this.C_R17_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 703F);
            this.C_R17_NO.Multiline = true;
            this.C_R17_NO.Name = "C_R17_NO";
            this.C_R17_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R17_NO.Text = "";
            this.C_R17_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_NO.WordWrap = false;
            // 
            // C_R17_STD
            // 
            this.C_R17_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R17_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_STD.BorderWidth = 0.5F;
            this.C_R17_STD.CanGrow = false;
            this.C_R17_STD.Dpi = 100F;
            this.C_R17_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R17_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 703F);
            this.C_R17_STD.Multiline = true;
            this.C_R17_STD.Name = "C_R17_STD";
            this.C_R17_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R17_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R17_STD.Text = "";
            this.C_R17_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R17_STD.WordWrap = true;
            // 
            // C_R17_SPEC
            // 
            this.C_R17_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R17_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_SPEC.BorderWidth = 0.5F;
            this.C_R17_SPEC.CanGrow = false;
            this.C_R17_SPEC.Dpi = 100F;
            this.C_R17_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R17_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 703F);
            this.C_R17_SPEC.Multiline = true;
            this.C_R17_SPEC.Name = "C_R17_SPEC";
            this.C_R17_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R17_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R17_SPEC.Text = "";
            this.C_R17_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R17_SPEC.WordWrap = true;
            // 
            // L_R17_MGR
            // 
            this.L_R17_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R17_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R17_MGR.BorderWidth = 0.5F;
            this.L_R17_MGR.CanGrow = false;
            this.L_R17_MGR.Dpi = 100F;
            this.L_R17_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 703F);
            this.L_R17_MGR.Multiline = true;
            this.L_R17_MGR.Name = "L_R17_MGR";
            this.L_R17_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R17_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R17_MGR.Text = "";
            this.L_R17_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R17_MGR.WordWrap = false;
            // 
            // C_R17_X1
            // 
            this.C_R17_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R17_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_X1.BorderWidth = 0.5F;
            this.C_R17_X1.CanGrow = false;
            this.C_R17_X1.Dpi = 100F;
            this.C_R17_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 703F);
            this.C_R17_X1.Multiline = true;
            this.C_R17_X1.Name = "C_R17_X1";
            this.C_R17_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R17_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R17_X1.Text = "";
            this.C_R17_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_X1.WordWrap = false;
            // 
            // C_R17_X2
            // 
            this.C_R17_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R17_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_X2.BorderWidth = 0.5F;
            this.C_R17_X2.CanGrow = false;
            this.C_R17_X2.Dpi = 100F;
            this.C_R17_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 703F);
            this.C_R17_X2.Multiline = true;
            this.C_R17_X2.Name = "C_R17_X2";
            this.C_R17_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R17_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R17_X2.Text = "";
            this.C_R17_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_X2.WordWrap = false;
            // 
            // C_R17_X3
            // 
            this.C_R17_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R17_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_X3.BorderWidth = 0.5F;
            this.C_R17_X3.CanGrow = false;
            this.C_R17_X3.Dpi = 100F;
            this.C_R17_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 703F);
            this.C_R17_X3.Multiline = true;
            this.C_R17_X3.Name = "C_R17_X3";
            this.C_R17_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R17_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R17_X3.Text = "";
            this.C_R17_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_X3.WordWrap = false;
            // 
            // C_R17_X4
            // 
            this.C_R17_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R17_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_X4.BorderWidth = 0.5F;
            this.C_R17_X4.CanGrow = false;
            this.C_R17_X4.Dpi = 100F;
            this.C_R17_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 703F);
            this.C_R17_X4.Multiline = true;
            this.C_R17_X4.Name = "C_R17_X4";
            this.C_R17_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R17_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R17_X4.Text = "";
            this.C_R17_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_X4.WordWrap = false;
            // 
            // C_R17_X5
            // 
            this.C_R17_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R17_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_X5.BorderWidth = 0.5F;
            this.C_R17_X5.CanGrow = false;
            this.C_R17_X5.Dpi = 100F;
            this.C_R17_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R17_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 703F);
            this.C_R17_X5.Multiline = true;
            this.C_R17_X5.Name = "C_R17_X5";
            this.C_R17_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R17_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R17_X5.Text = "";
            this.C_R17_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_X5.WordWrap = false;
            // 
            // C_R17_JUDGE
            // 
            this.C_R17_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R17_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_JUDGE.BorderWidth = 0.5F;
            this.C_R17_JUDGE.CanGrow = false;
            this.C_R17_JUDGE.Dpi = 100F;
            this.C_R17_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 703F);
            this.C_R17_JUDGE.Multiline = true;
            this.C_R17_JUDGE.Name = "C_R17_JUDGE";
            this.C_R17_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R17_JUDGE.Text = "";
            this.C_R17_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_JUDGE.WordWrap = false;
            // 
            // L_R17_DX1
            // 
            this.L_R17_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R17_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R17_DX1.BorderWidth = 0.5F;
            this.L_R17_DX1.CanGrow = false;
            this.L_R17_DX1.Dpi = 100F;
            this.L_R17_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 703F);
            this.L_R17_DX1.Multiline = true;
            this.L_R17_DX1.Name = "L_R17_DX1";
            this.L_R17_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R17_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R17_DX1.Text = "";
            this.L_R17_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R17_DX1.WordWrap = false;
            // 
            // L_R17_DX2
            // 
            this.L_R17_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R17_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R17_DX2.BorderWidth = 0.5F;
            this.L_R17_DX2.CanGrow = false;
            this.L_R17_DX2.Dpi = 100F;
            this.L_R17_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 703F);
            this.L_R17_DX2.Multiline = true;
            this.L_R17_DX2.Name = "L_R17_DX2";
            this.L_R17_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R17_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R17_DX2.Text = "";
            this.L_R17_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R17_DX2.WordWrap = false;
            // 
            // L_R17_DX3
            // 
            this.L_R17_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R17_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R17_DX3.BorderWidth = 0.5F;
            this.L_R17_DX3.CanGrow = false;
            this.L_R17_DX3.Dpi = 100F;
            this.L_R17_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 703F);
            this.L_R17_DX3.Multiline = true;
            this.L_R17_DX3.Name = "L_R17_DX3";
            this.L_R17_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R17_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R17_DX3.Text = "";
            this.L_R17_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R17_DX3.WordWrap = false;
            // 
            // L_R17_DX4
            // 
            this.L_R17_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R17_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R17_DX4.BorderWidth = 0.5F;
            this.L_R17_DX4.CanGrow = false;
            this.L_R17_DX4.Dpi = 100F;
            this.L_R17_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 703F);
            this.L_R17_DX4.Multiline = true;
            this.L_R17_DX4.Name = "L_R17_DX4";
            this.L_R17_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R17_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R17_DX4.Text = "";
            this.L_R17_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R17_DX4.WordWrap = false;
            // 
            // L_R17_DX5
            // 
            this.L_R17_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R17_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R17_DX5.BorderWidth = 0.5F;
            this.L_R17_DX5.CanGrow = false;
            this.L_R17_DX5.Dpi = 100F;
            this.L_R17_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 703F);
            this.L_R17_DX5.Multiline = true;
            this.L_R17_DX5.Name = "L_R17_DX5";
            this.L_R17_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R17_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R17_DX5.Text = "";
            this.L_R17_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R17_DX5.WordWrap = false;
            // 
            // L_R17_DJ
            // 
            this.L_R17_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R17_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R17_DJ.BorderWidth = 0.5F;
            this.L_R17_DJ.CanGrow = false;
            this.L_R17_DJ.Dpi = 100F;
            this.L_R17_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 703F);
            this.L_R17_DJ.Multiline = true;
            this.L_R17_DJ.Name = "L_R17_DJ";
            this.L_R17_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R17_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R17_DJ.Text = "";
            this.L_R17_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R17_DJ.WordWrap = false;
            // 
            // C_R17_XSPAN
            // 
            this.C_R17_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R17_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R17_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R17_XSPAN.BorderWidth = 0.5F;
            this.C_R17_XSPAN.CanGrow = false;
            this.C_R17_XSPAN.Dpi = 100F;
            this.C_R17_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R17_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 703F);
            this.C_R17_XSPAN.Multiline = true;
            this.C_R17_XSPAN.Name = "C_R17_XSPAN";
            this.C_R17_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R17_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R17_XSPAN.Text = "";
            this.C_R17_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R17_XSPAN.Visible = false;
            this.C_R17_XSPAN.WordWrap = false;
            // 
            // C_R18_NO
            // 
            this.C_R18_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R18_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_NO.BorderWidth = 0.5F;
            this.C_R18_NO.CanGrow = false;
            this.C_R18_NO.Dpi = 100F;
            this.C_R18_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 727F);
            this.C_R18_NO.Multiline = true;
            this.C_R18_NO.Name = "C_R18_NO";
            this.C_R18_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R18_NO.Text = "";
            this.C_R18_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_NO.WordWrap = false;
            // 
            // C_R18_STD
            // 
            this.C_R18_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R18_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_STD.BorderWidth = 0.5F;
            this.C_R18_STD.CanGrow = false;
            this.C_R18_STD.Dpi = 100F;
            this.C_R18_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R18_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 727F);
            this.C_R18_STD.Multiline = true;
            this.C_R18_STD.Name = "C_R18_STD";
            this.C_R18_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R18_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R18_STD.Text = "";
            this.C_R18_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R18_STD.WordWrap = true;
            // 
            // C_R18_SPEC
            // 
            this.C_R18_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R18_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_SPEC.BorderWidth = 0.5F;
            this.C_R18_SPEC.CanGrow = false;
            this.C_R18_SPEC.Dpi = 100F;
            this.C_R18_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R18_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 727F);
            this.C_R18_SPEC.Multiline = true;
            this.C_R18_SPEC.Name = "C_R18_SPEC";
            this.C_R18_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R18_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R18_SPEC.Text = "";
            this.C_R18_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R18_SPEC.WordWrap = true;
            // 
            // L_R18_MGR
            // 
            this.L_R18_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R18_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R18_MGR.BorderWidth = 0.5F;
            this.L_R18_MGR.CanGrow = false;
            this.L_R18_MGR.Dpi = 100F;
            this.L_R18_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 727F);
            this.L_R18_MGR.Multiline = true;
            this.L_R18_MGR.Name = "L_R18_MGR";
            this.L_R18_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R18_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R18_MGR.Text = "";
            this.L_R18_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R18_MGR.WordWrap = false;
            // 
            // C_R18_X1
            // 
            this.C_R18_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R18_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_X1.BorderWidth = 0.5F;
            this.C_R18_X1.CanGrow = false;
            this.C_R18_X1.Dpi = 100F;
            this.C_R18_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 727F);
            this.C_R18_X1.Multiline = true;
            this.C_R18_X1.Name = "C_R18_X1";
            this.C_R18_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R18_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R18_X1.Text = "";
            this.C_R18_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_X1.WordWrap = false;
            // 
            // C_R18_X2
            // 
            this.C_R18_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R18_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_X2.BorderWidth = 0.5F;
            this.C_R18_X2.CanGrow = false;
            this.C_R18_X2.Dpi = 100F;
            this.C_R18_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 727F);
            this.C_R18_X2.Multiline = true;
            this.C_R18_X2.Name = "C_R18_X2";
            this.C_R18_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R18_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R18_X2.Text = "";
            this.C_R18_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_X2.WordWrap = false;
            // 
            // C_R18_X3
            // 
            this.C_R18_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R18_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_X3.BorderWidth = 0.5F;
            this.C_R18_X3.CanGrow = false;
            this.C_R18_X3.Dpi = 100F;
            this.C_R18_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 727F);
            this.C_R18_X3.Multiline = true;
            this.C_R18_X3.Name = "C_R18_X3";
            this.C_R18_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R18_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R18_X3.Text = "";
            this.C_R18_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_X3.WordWrap = false;
            // 
            // C_R18_X4
            // 
            this.C_R18_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R18_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_X4.BorderWidth = 0.5F;
            this.C_R18_X4.CanGrow = false;
            this.C_R18_X4.Dpi = 100F;
            this.C_R18_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 727F);
            this.C_R18_X4.Multiline = true;
            this.C_R18_X4.Name = "C_R18_X4";
            this.C_R18_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R18_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R18_X4.Text = "";
            this.C_R18_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_X4.WordWrap = false;
            // 
            // C_R18_X5
            // 
            this.C_R18_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R18_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_X5.BorderWidth = 0.5F;
            this.C_R18_X5.CanGrow = false;
            this.C_R18_X5.Dpi = 100F;
            this.C_R18_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R18_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 727F);
            this.C_R18_X5.Multiline = true;
            this.C_R18_X5.Name = "C_R18_X5";
            this.C_R18_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R18_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R18_X5.Text = "";
            this.C_R18_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_X5.WordWrap = false;
            // 
            // C_R18_JUDGE
            // 
            this.C_R18_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R18_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_JUDGE.BorderWidth = 0.5F;
            this.C_R18_JUDGE.CanGrow = false;
            this.C_R18_JUDGE.Dpi = 100F;
            this.C_R18_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 727F);
            this.C_R18_JUDGE.Multiline = true;
            this.C_R18_JUDGE.Name = "C_R18_JUDGE";
            this.C_R18_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R18_JUDGE.Text = "";
            this.C_R18_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_JUDGE.WordWrap = false;
            // 
            // L_R18_DX1
            // 
            this.L_R18_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R18_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R18_DX1.BorderWidth = 0.5F;
            this.L_R18_DX1.CanGrow = false;
            this.L_R18_DX1.Dpi = 100F;
            this.L_R18_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 727F);
            this.L_R18_DX1.Multiline = true;
            this.L_R18_DX1.Name = "L_R18_DX1";
            this.L_R18_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R18_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R18_DX1.Text = "";
            this.L_R18_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R18_DX1.WordWrap = false;
            // 
            // L_R18_DX2
            // 
            this.L_R18_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R18_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R18_DX2.BorderWidth = 0.5F;
            this.L_R18_DX2.CanGrow = false;
            this.L_R18_DX2.Dpi = 100F;
            this.L_R18_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 727F);
            this.L_R18_DX2.Multiline = true;
            this.L_R18_DX2.Name = "L_R18_DX2";
            this.L_R18_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R18_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R18_DX2.Text = "";
            this.L_R18_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R18_DX2.WordWrap = false;
            // 
            // L_R18_DX3
            // 
            this.L_R18_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R18_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R18_DX3.BorderWidth = 0.5F;
            this.L_R18_DX3.CanGrow = false;
            this.L_R18_DX3.Dpi = 100F;
            this.L_R18_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 727F);
            this.L_R18_DX3.Multiline = true;
            this.L_R18_DX3.Name = "L_R18_DX3";
            this.L_R18_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R18_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R18_DX3.Text = "";
            this.L_R18_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R18_DX3.WordWrap = false;
            // 
            // L_R18_DX4
            // 
            this.L_R18_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R18_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R18_DX4.BorderWidth = 0.5F;
            this.L_R18_DX4.CanGrow = false;
            this.L_R18_DX4.Dpi = 100F;
            this.L_R18_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 727F);
            this.L_R18_DX4.Multiline = true;
            this.L_R18_DX4.Name = "L_R18_DX4";
            this.L_R18_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R18_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R18_DX4.Text = "";
            this.L_R18_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R18_DX4.WordWrap = false;
            // 
            // L_R18_DX5
            // 
            this.L_R18_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R18_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R18_DX5.BorderWidth = 0.5F;
            this.L_R18_DX5.CanGrow = false;
            this.L_R18_DX5.Dpi = 100F;
            this.L_R18_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 727F);
            this.L_R18_DX5.Multiline = true;
            this.L_R18_DX5.Name = "L_R18_DX5";
            this.L_R18_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R18_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R18_DX5.Text = "";
            this.L_R18_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R18_DX5.WordWrap = false;
            // 
            // L_R18_DJ
            // 
            this.L_R18_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R18_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R18_DJ.BorderWidth = 0.5F;
            this.L_R18_DJ.CanGrow = false;
            this.L_R18_DJ.Dpi = 100F;
            this.L_R18_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 727F);
            this.L_R18_DJ.Multiline = true;
            this.L_R18_DJ.Name = "L_R18_DJ";
            this.L_R18_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R18_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R18_DJ.Text = "";
            this.L_R18_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R18_DJ.WordWrap = false;
            // 
            // C_R18_XSPAN
            // 
            this.C_R18_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R18_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R18_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R18_XSPAN.BorderWidth = 0.5F;
            this.C_R18_XSPAN.CanGrow = false;
            this.C_R18_XSPAN.Dpi = 100F;
            this.C_R18_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R18_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 727F);
            this.C_R18_XSPAN.Multiline = true;
            this.C_R18_XSPAN.Name = "C_R18_XSPAN";
            this.C_R18_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R18_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R18_XSPAN.Text = "";
            this.C_R18_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R18_XSPAN.Visible = false;
            this.C_R18_XSPAN.WordWrap = false;
            // 
            // C_R19_NO
            // 
            this.C_R19_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R19_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_NO.BorderWidth = 0.5F;
            this.C_R19_NO.CanGrow = false;
            this.C_R19_NO.Dpi = 100F;
            this.C_R19_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 751F);
            this.C_R19_NO.Multiline = true;
            this.C_R19_NO.Name = "C_R19_NO";
            this.C_R19_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R19_NO.Text = "";
            this.C_R19_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_NO.WordWrap = false;
            // 
            // C_R19_STD
            // 
            this.C_R19_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R19_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_STD.BorderWidth = 0.5F;
            this.C_R19_STD.CanGrow = false;
            this.C_R19_STD.Dpi = 100F;
            this.C_R19_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R19_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 751F);
            this.C_R19_STD.Multiline = true;
            this.C_R19_STD.Name = "C_R19_STD";
            this.C_R19_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R19_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R19_STD.Text = "";
            this.C_R19_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R19_STD.WordWrap = true;
            // 
            // C_R19_SPEC
            // 
            this.C_R19_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R19_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_SPEC.BorderWidth = 0.5F;
            this.C_R19_SPEC.CanGrow = false;
            this.C_R19_SPEC.Dpi = 100F;
            this.C_R19_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R19_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 751F);
            this.C_R19_SPEC.Multiline = true;
            this.C_R19_SPEC.Name = "C_R19_SPEC";
            this.C_R19_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R19_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R19_SPEC.Text = "";
            this.C_R19_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R19_SPEC.WordWrap = true;
            // 
            // L_R19_MGR
            // 
            this.L_R19_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R19_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R19_MGR.BorderWidth = 0.5F;
            this.L_R19_MGR.CanGrow = false;
            this.L_R19_MGR.Dpi = 100F;
            this.L_R19_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 751F);
            this.L_R19_MGR.Multiline = true;
            this.L_R19_MGR.Name = "L_R19_MGR";
            this.L_R19_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R19_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R19_MGR.Text = "";
            this.L_R19_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R19_MGR.WordWrap = false;
            // 
            // C_R19_X1
            // 
            this.C_R19_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R19_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_X1.BorderWidth = 0.5F;
            this.C_R19_X1.CanGrow = false;
            this.C_R19_X1.Dpi = 100F;
            this.C_R19_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 751F);
            this.C_R19_X1.Multiline = true;
            this.C_R19_X1.Name = "C_R19_X1";
            this.C_R19_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R19_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R19_X1.Text = "";
            this.C_R19_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_X1.WordWrap = false;
            // 
            // C_R19_X2
            // 
            this.C_R19_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R19_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_X2.BorderWidth = 0.5F;
            this.C_R19_X2.CanGrow = false;
            this.C_R19_X2.Dpi = 100F;
            this.C_R19_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 751F);
            this.C_R19_X2.Multiline = true;
            this.C_R19_X2.Name = "C_R19_X2";
            this.C_R19_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R19_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R19_X2.Text = "";
            this.C_R19_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_X2.WordWrap = false;
            // 
            // C_R19_X3
            // 
            this.C_R19_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R19_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_X3.BorderWidth = 0.5F;
            this.C_R19_X3.CanGrow = false;
            this.C_R19_X3.Dpi = 100F;
            this.C_R19_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 751F);
            this.C_R19_X3.Multiline = true;
            this.C_R19_X3.Name = "C_R19_X3";
            this.C_R19_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R19_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R19_X3.Text = "";
            this.C_R19_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_X3.WordWrap = false;
            // 
            // C_R19_X4
            // 
            this.C_R19_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R19_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_X4.BorderWidth = 0.5F;
            this.C_R19_X4.CanGrow = false;
            this.C_R19_X4.Dpi = 100F;
            this.C_R19_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 751F);
            this.C_R19_X4.Multiline = true;
            this.C_R19_X4.Name = "C_R19_X4";
            this.C_R19_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R19_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R19_X4.Text = "";
            this.C_R19_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_X4.WordWrap = false;
            // 
            // C_R19_X5
            // 
            this.C_R19_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R19_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_X5.BorderWidth = 0.5F;
            this.C_R19_X5.CanGrow = false;
            this.C_R19_X5.Dpi = 100F;
            this.C_R19_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R19_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 751F);
            this.C_R19_X5.Multiline = true;
            this.C_R19_X5.Name = "C_R19_X5";
            this.C_R19_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R19_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R19_X5.Text = "";
            this.C_R19_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_X5.WordWrap = false;
            // 
            // C_R19_JUDGE
            // 
            this.C_R19_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R19_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_JUDGE.BorderWidth = 0.5F;
            this.C_R19_JUDGE.CanGrow = false;
            this.C_R19_JUDGE.Dpi = 100F;
            this.C_R19_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 751F);
            this.C_R19_JUDGE.Multiline = true;
            this.C_R19_JUDGE.Name = "C_R19_JUDGE";
            this.C_R19_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R19_JUDGE.Text = "";
            this.C_R19_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_JUDGE.WordWrap = false;
            // 
            // L_R19_DX1
            // 
            this.L_R19_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R19_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R19_DX1.BorderWidth = 0.5F;
            this.L_R19_DX1.CanGrow = false;
            this.L_R19_DX1.Dpi = 100F;
            this.L_R19_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 751F);
            this.L_R19_DX1.Multiline = true;
            this.L_R19_DX1.Name = "L_R19_DX1";
            this.L_R19_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R19_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R19_DX1.Text = "";
            this.L_R19_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R19_DX1.WordWrap = false;
            // 
            // L_R19_DX2
            // 
            this.L_R19_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R19_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R19_DX2.BorderWidth = 0.5F;
            this.L_R19_DX2.CanGrow = false;
            this.L_R19_DX2.Dpi = 100F;
            this.L_R19_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 751F);
            this.L_R19_DX2.Multiline = true;
            this.L_R19_DX2.Name = "L_R19_DX2";
            this.L_R19_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R19_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R19_DX2.Text = "";
            this.L_R19_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R19_DX2.WordWrap = false;
            // 
            // L_R19_DX3
            // 
            this.L_R19_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R19_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R19_DX3.BorderWidth = 0.5F;
            this.L_R19_DX3.CanGrow = false;
            this.L_R19_DX3.Dpi = 100F;
            this.L_R19_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 751F);
            this.L_R19_DX3.Multiline = true;
            this.L_R19_DX3.Name = "L_R19_DX3";
            this.L_R19_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R19_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R19_DX3.Text = "";
            this.L_R19_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R19_DX3.WordWrap = false;
            // 
            // L_R19_DX4
            // 
            this.L_R19_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R19_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R19_DX4.BorderWidth = 0.5F;
            this.L_R19_DX4.CanGrow = false;
            this.L_R19_DX4.Dpi = 100F;
            this.L_R19_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 751F);
            this.L_R19_DX4.Multiline = true;
            this.L_R19_DX4.Name = "L_R19_DX4";
            this.L_R19_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R19_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R19_DX4.Text = "";
            this.L_R19_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R19_DX4.WordWrap = false;
            // 
            // L_R19_DX5
            // 
            this.L_R19_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R19_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R19_DX5.BorderWidth = 0.5F;
            this.L_R19_DX5.CanGrow = false;
            this.L_R19_DX5.Dpi = 100F;
            this.L_R19_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 751F);
            this.L_R19_DX5.Multiline = true;
            this.L_R19_DX5.Name = "L_R19_DX5";
            this.L_R19_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R19_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R19_DX5.Text = "";
            this.L_R19_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R19_DX5.WordWrap = false;
            // 
            // L_R19_DJ
            // 
            this.L_R19_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R19_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R19_DJ.BorderWidth = 0.5F;
            this.L_R19_DJ.CanGrow = false;
            this.L_R19_DJ.Dpi = 100F;
            this.L_R19_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 751F);
            this.L_R19_DJ.Multiline = true;
            this.L_R19_DJ.Name = "L_R19_DJ";
            this.L_R19_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R19_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R19_DJ.Text = "";
            this.L_R19_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R19_DJ.WordWrap = false;
            // 
            // C_R19_XSPAN
            // 
            this.C_R19_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R19_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R19_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R19_XSPAN.BorderWidth = 0.5F;
            this.C_R19_XSPAN.CanGrow = false;
            this.C_R19_XSPAN.Dpi = 100F;
            this.C_R19_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R19_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 751F);
            this.C_R19_XSPAN.Multiline = true;
            this.C_R19_XSPAN.Name = "C_R19_XSPAN";
            this.C_R19_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R19_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R19_XSPAN.Text = "";
            this.C_R19_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R19_XSPAN.Visible = false;
            this.C_R19_XSPAN.WordWrap = false;
            // 
            // C_R20_NO
            // 
            this.C_R20_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R20_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_NO.BorderWidth = 0.5F;
            this.C_R20_NO.CanGrow = false;
            this.C_R20_NO.Dpi = 100F;
            this.C_R20_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 775F);
            this.C_R20_NO.Multiline = true;
            this.C_R20_NO.Name = "C_R20_NO";
            this.C_R20_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R20_NO.Text = "";
            this.C_R20_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_NO.WordWrap = false;
            // 
            // C_R20_STD
            // 
            this.C_R20_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R20_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_STD.BorderWidth = 0.5F;
            this.C_R20_STD.CanGrow = false;
            this.C_R20_STD.Dpi = 100F;
            this.C_R20_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R20_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 775F);
            this.C_R20_STD.Multiline = true;
            this.C_R20_STD.Name = "C_R20_STD";
            this.C_R20_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R20_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R20_STD.Text = "";
            this.C_R20_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R20_STD.WordWrap = true;
            // 
            // C_R20_SPEC
            // 
            this.C_R20_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R20_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_SPEC.BorderWidth = 0.5F;
            this.C_R20_SPEC.CanGrow = false;
            this.C_R20_SPEC.Dpi = 100F;
            this.C_R20_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R20_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 775F);
            this.C_R20_SPEC.Multiline = true;
            this.C_R20_SPEC.Name = "C_R20_SPEC";
            this.C_R20_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R20_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R20_SPEC.Text = "";
            this.C_R20_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R20_SPEC.WordWrap = true;
            // 
            // L_R20_MGR
            // 
            this.L_R20_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R20_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R20_MGR.BorderWidth = 0.5F;
            this.L_R20_MGR.CanGrow = false;
            this.L_R20_MGR.Dpi = 100F;
            this.L_R20_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 775F);
            this.L_R20_MGR.Multiline = true;
            this.L_R20_MGR.Name = "L_R20_MGR";
            this.L_R20_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R20_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R20_MGR.Text = "";
            this.L_R20_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R20_MGR.WordWrap = false;
            // 
            // C_R20_X1
            // 
            this.C_R20_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R20_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_X1.BorderWidth = 0.5F;
            this.C_R20_X1.CanGrow = false;
            this.C_R20_X1.Dpi = 100F;
            this.C_R20_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 775F);
            this.C_R20_X1.Multiline = true;
            this.C_R20_X1.Name = "C_R20_X1";
            this.C_R20_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R20_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R20_X1.Text = "";
            this.C_R20_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_X1.WordWrap = false;
            // 
            // C_R20_X2
            // 
            this.C_R20_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R20_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_X2.BorderWidth = 0.5F;
            this.C_R20_X2.CanGrow = false;
            this.C_R20_X2.Dpi = 100F;
            this.C_R20_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 775F);
            this.C_R20_X2.Multiline = true;
            this.C_R20_X2.Name = "C_R20_X2";
            this.C_R20_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R20_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R20_X2.Text = "";
            this.C_R20_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_X2.WordWrap = false;
            // 
            // C_R20_X3
            // 
            this.C_R20_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R20_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_X3.BorderWidth = 0.5F;
            this.C_R20_X3.CanGrow = false;
            this.C_R20_X3.Dpi = 100F;
            this.C_R20_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 775F);
            this.C_R20_X3.Multiline = true;
            this.C_R20_X3.Name = "C_R20_X3";
            this.C_R20_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R20_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R20_X3.Text = "";
            this.C_R20_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_X3.WordWrap = false;
            // 
            // C_R20_X4
            // 
            this.C_R20_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R20_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_X4.BorderWidth = 0.5F;
            this.C_R20_X4.CanGrow = false;
            this.C_R20_X4.Dpi = 100F;
            this.C_R20_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 775F);
            this.C_R20_X4.Multiline = true;
            this.C_R20_X4.Name = "C_R20_X4";
            this.C_R20_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R20_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R20_X4.Text = "";
            this.C_R20_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_X4.WordWrap = false;
            // 
            // C_R20_X5
            // 
            this.C_R20_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R20_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_X5.BorderWidth = 0.5F;
            this.C_R20_X5.CanGrow = false;
            this.C_R20_X5.Dpi = 100F;
            this.C_R20_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R20_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 775F);
            this.C_R20_X5.Multiline = true;
            this.C_R20_X5.Name = "C_R20_X5";
            this.C_R20_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R20_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R20_X5.Text = "";
            this.C_R20_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_X5.WordWrap = false;
            // 
            // C_R20_JUDGE
            // 
            this.C_R20_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R20_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_JUDGE.BorderWidth = 0.5F;
            this.C_R20_JUDGE.CanGrow = false;
            this.C_R20_JUDGE.Dpi = 100F;
            this.C_R20_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 775F);
            this.C_R20_JUDGE.Multiline = true;
            this.C_R20_JUDGE.Name = "C_R20_JUDGE";
            this.C_R20_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R20_JUDGE.Text = "";
            this.C_R20_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_JUDGE.WordWrap = false;
            // 
            // L_R20_DX1
            // 
            this.L_R20_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R20_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R20_DX1.BorderWidth = 0.5F;
            this.L_R20_DX1.CanGrow = false;
            this.L_R20_DX1.Dpi = 100F;
            this.L_R20_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 775F);
            this.L_R20_DX1.Multiline = true;
            this.L_R20_DX1.Name = "L_R20_DX1";
            this.L_R20_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R20_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R20_DX1.Text = "";
            this.L_R20_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R20_DX1.WordWrap = false;
            // 
            // L_R20_DX2
            // 
            this.L_R20_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R20_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R20_DX2.BorderWidth = 0.5F;
            this.L_R20_DX2.CanGrow = false;
            this.L_R20_DX2.Dpi = 100F;
            this.L_R20_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 775F);
            this.L_R20_DX2.Multiline = true;
            this.L_R20_DX2.Name = "L_R20_DX2";
            this.L_R20_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R20_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R20_DX2.Text = "";
            this.L_R20_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R20_DX2.WordWrap = false;
            // 
            // L_R20_DX3
            // 
            this.L_R20_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R20_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R20_DX3.BorderWidth = 0.5F;
            this.L_R20_DX3.CanGrow = false;
            this.L_R20_DX3.Dpi = 100F;
            this.L_R20_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 775F);
            this.L_R20_DX3.Multiline = true;
            this.L_R20_DX3.Name = "L_R20_DX3";
            this.L_R20_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R20_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R20_DX3.Text = "";
            this.L_R20_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R20_DX3.WordWrap = false;
            // 
            // L_R20_DX4
            // 
            this.L_R20_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R20_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R20_DX4.BorderWidth = 0.5F;
            this.L_R20_DX4.CanGrow = false;
            this.L_R20_DX4.Dpi = 100F;
            this.L_R20_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 775F);
            this.L_R20_DX4.Multiline = true;
            this.L_R20_DX4.Name = "L_R20_DX4";
            this.L_R20_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R20_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R20_DX4.Text = "";
            this.L_R20_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R20_DX4.WordWrap = false;
            // 
            // L_R20_DX5
            // 
            this.L_R20_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R20_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R20_DX5.BorderWidth = 0.5F;
            this.L_R20_DX5.CanGrow = false;
            this.L_R20_DX5.Dpi = 100F;
            this.L_R20_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 775F);
            this.L_R20_DX5.Multiline = true;
            this.L_R20_DX5.Name = "L_R20_DX5";
            this.L_R20_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R20_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R20_DX5.Text = "";
            this.L_R20_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R20_DX5.WordWrap = false;
            // 
            // L_R20_DJ
            // 
            this.L_R20_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R20_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R20_DJ.BorderWidth = 0.5F;
            this.L_R20_DJ.CanGrow = false;
            this.L_R20_DJ.Dpi = 100F;
            this.L_R20_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 775F);
            this.L_R20_DJ.Multiline = true;
            this.L_R20_DJ.Name = "L_R20_DJ";
            this.L_R20_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R20_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R20_DJ.Text = "";
            this.L_R20_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R20_DJ.WordWrap = false;
            // 
            // C_R20_XSPAN
            // 
            this.C_R20_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R20_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R20_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R20_XSPAN.BorderWidth = 0.5F;
            this.C_R20_XSPAN.CanGrow = false;
            this.C_R20_XSPAN.Dpi = 100F;
            this.C_R20_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R20_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 775F);
            this.C_R20_XSPAN.Multiline = true;
            this.C_R20_XSPAN.Name = "C_R20_XSPAN";
            this.C_R20_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R20_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R20_XSPAN.Text = "";
            this.C_R20_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R20_XSPAN.Visible = false;
            this.C_R20_XSPAN.WordWrap = false;
            // 
            // C_R21_NO
            // 
            this.C_R21_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R21_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_NO.BorderWidth = 0.5F;
            this.C_R21_NO.CanGrow = false;
            this.C_R21_NO.Dpi = 100F;
            this.C_R21_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 799F);
            this.C_R21_NO.Multiline = true;
            this.C_R21_NO.Name = "C_R21_NO";
            this.C_R21_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R21_NO.Text = "";
            this.C_R21_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_NO.WordWrap = false;
            // 
            // C_R21_STD
            // 
            this.C_R21_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R21_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_STD.BorderWidth = 0.5F;
            this.C_R21_STD.CanGrow = false;
            this.C_R21_STD.Dpi = 100F;
            this.C_R21_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R21_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 799F);
            this.C_R21_STD.Multiline = true;
            this.C_R21_STD.Name = "C_R21_STD";
            this.C_R21_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R21_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R21_STD.Text = "";
            this.C_R21_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R21_STD.WordWrap = true;
            // 
            // C_R21_SPEC
            // 
            this.C_R21_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R21_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_SPEC.BorderWidth = 0.5F;
            this.C_R21_SPEC.CanGrow = false;
            this.C_R21_SPEC.Dpi = 100F;
            this.C_R21_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R21_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 799F);
            this.C_R21_SPEC.Multiline = true;
            this.C_R21_SPEC.Name = "C_R21_SPEC";
            this.C_R21_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R21_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R21_SPEC.Text = "";
            this.C_R21_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R21_SPEC.WordWrap = true;
            // 
            // L_R21_MGR
            // 
            this.L_R21_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R21_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R21_MGR.BorderWidth = 0.5F;
            this.L_R21_MGR.CanGrow = false;
            this.L_R21_MGR.Dpi = 100F;
            this.L_R21_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 799F);
            this.L_R21_MGR.Multiline = true;
            this.L_R21_MGR.Name = "L_R21_MGR";
            this.L_R21_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R21_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R21_MGR.Text = "";
            this.L_R21_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R21_MGR.WordWrap = false;
            // 
            // C_R21_X1
            // 
            this.C_R21_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R21_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_X1.BorderWidth = 0.5F;
            this.C_R21_X1.CanGrow = false;
            this.C_R21_X1.Dpi = 100F;
            this.C_R21_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 799F);
            this.C_R21_X1.Multiline = true;
            this.C_R21_X1.Name = "C_R21_X1";
            this.C_R21_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R21_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R21_X1.Text = "";
            this.C_R21_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_X1.WordWrap = false;
            // 
            // C_R21_X2
            // 
            this.C_R21_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R21_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_X2.BorderWidth = 0.5F;
            this.C_R21_X2.CanGrow = false;
            this.C_R21_X2.Dpi = 100F;
            this.C_R21_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 799F);
            this.C_R21_X2.Multiline = true;
            this.C_R21_X2.Name = "C_R21_X2";
            this.C_R21_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R21_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R21_X2.Text = "";
            this.C_R21_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_X2.WordWrap = false;
            // 
            // C_R21_X3
            // 
            this.C_R21_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R21_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_X3.BorderWidth = 0.5F;
            this.C_R21_X3.CanGrow = false;
            this.C_R21_X3.Dpi = 100F;
            this.C_R21_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 799F);
            this.C_R21_X3.Multiline = true;
            this.C_R21_X3.Name = "C_R21_X3";
            this.C_R21_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R21_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R21_X3.Text = "";
            this.C_R21_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_X3.WordWrap = false;
            // 
            // C_R21_X4
            // 
            this.C_R21_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R21_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_X4.BorderWidth = 0.5F;
            this.C_R21_X4.CanGrow = false;
            this.C_R21_X4.Dpi = 100F;
            this.C_R21_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 799F);
            this.C_R21_X4.Multiline = true;
            this.C_R21_X4.Name = "C_R21_X4";
            this.C_R21_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R21_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R21_X4.Text = "";
            this.C_R21_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_X4.WordWrap = false;
            // 
            // C_R21_X5
            // 
            this.C_R21_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R21_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_X5.BorderWidth = 0.5F;
            this.C_R21_X5.CanGrow = false;
            this.C_R21_X5.Dpi = 100F;
            this.C_R21_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R21_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 799F);
            this.C_R21_X5.Multiline = true;
            this.C_R21_X5.Name = "C_R21_X5";
            this.C_R21_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R21_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R21_X5.Text = "";
            this.C_R21_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_X5.WordWrap = false;
            // 
            // C_R21_JUDGE
            // 
            this.C_R21_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R21_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_JUDGE.BorderWidth = 0.5F;
            this.C_R21_JUDGE.CanGrow = false;
            this.C_R21_JUDGE.Dpi = 100F;
            this.C_R21_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 799F);
            this.C_R21_JUDGE.Multiline = true;
            this.C_R21_JUDGE.Name = "C_R21_JUDGE";
            this.C_R21_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R21_JUDGE.Text = "";
            this.C_R21_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_JUDGE.WordWrap = false;
            // 
            // L_R21_DX1
            // 
            this.L_R21_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R21_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R21_DX1.BorderWidth = 0.5F;
            this.L_R21_DX1.CanGrow = false;
            this.L_R21_DX1.Dpi = 100F;
            this.L_R21_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 799F);
            this.L_R21_DX1.Multiline = true;
            this.L_R21_DX1.Name = "L_R21_DX1";
            this.L_R21_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R21_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R21_DX1.Text = "";
            this.L_R21_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R21_DX1.WordWrap = false;
            // 
            // L_R21_DX2
            // 
            this.L_R21_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R21_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R21_DX2.BorderWidth = 0.5F;
            this.L_R21_DX2.CanGrow = false;
            this.L_R21_DX2.Dpi = 100F;
            this.L_R21_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 799F);
            this.L_R21_DX2.Multiline = true;
            this.L_R21_DX2.Name = "L_R21_DX2";
            this.L_R21_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R21_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R21_DX2.Text = "";
            this.L_R21_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R21_DX2.WordWrap = false;
            // 
            // L_R21_DX3
            // 
            this.L_R21_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R21_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R21_DX3.BorderWidth = 0.5F;
            this.L_R21_DX3.CanGrow = false;
            this.L_R21_DX3.Dpi = 100F;
            this.L_R21_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 799F);
            this.L_R21_DX3.Multiline = true;
            this.L_R21_DX3.Name = "L_R21_DX3";
            this.L_R21_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R21_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R21_DX3.Text = "";
            this.L_R21_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R21_DX3.WordWrap = false;
            // 
            // L_R21_DX4
            // 
            this.L_R21_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R21_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R21_DX4.BorderWidth = 0.5F;
            this.L_R21_DX4.CanGrow = false;
            this.L_R21_DX4.Dpi = 100F;
            this.L_R21_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 799F);
            this.L_R21_DX4.Multiline = true;
            this.L_R21_DX4.Name = "L_R21_DX4";
            this.L_R21_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R21_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R21_DX4.Text = "";
            this.L_R21_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R21_DX4.WordWrap = false;
            // 
            // L_R21_DX5
            // 
            this.L_R21_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R21_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R21_DX5.BorderWidth = 0.5F;
            this.L_R21_DX5.CanGrow = false;
            this.L_R21_DX5.Dpi = 100F;
            this.L_R21_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 799F);
            this.L_R21_DX5.Multiline = true;
            this.L_R21_DX5.Name = "L_R21_DX5";
            this.L_R21_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R21_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R21_DX5.Text = "";
            this.L_R21_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R21_DX5.WordWrap = false;
            // 
            // L_R21_DJ
            // 
            this.L_R21_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R21_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R21_DJ.BorderWidth = 0.5F;
            this.L_R21_DJ.CanGrow = false;
            this.L_R21_DJ.Dpi = 100F;
            this.L_R21_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 799F);
            this.L_R21_DJ.Multiline = true;
            this.L_R21_DJ.Name = "L_R21_DJ";
            this.L_R21_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R21_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R21_DJ.Text = "";
            this.L_R21_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R21_DJ.WordWrap = false;
            // 
            // C_R21_XSPAN
            // 
            this.C_R21_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R21_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R21_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R21_XSPAN.BorderWidth = 0.5F;
            this.C_R21_XSPAN.CanGrow = false;
            this.C_R21_XSPAN.Dpi = 100F;
            this.C_R21_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R21_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 799F);
            this.C_R21_XSPAN.Multiline = true;
            this.C_R21_XSPAN.Name = "C_R21_XSPAN";
            this.C_R21_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R21_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R21_XSPAN.Text = "";
            this.C_R21_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R21_XSPAN.Visible = false;
            this.C_R21_XSPAN.WordWrap = false;
            // 
            // C_R22_NO
            // 
            this.C_R22_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R22_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_NO.BorderWidth = 0.5F;
            this.C_R22_NO.CanGrow = false;
            this.C_R22_NO.Dpi = 100F;
            this.C_R22_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 823F);
            this.C_R22_NO.Multiline = true;
            this.C_R22_NO.Name = "C_R22_NO";
            this.C_R22_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R22_NO.Text = "";
            this.C_R22_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_NO.WordWrap = false;
            // 
            // C_R22_STD
            // 
            this.C_R22_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R22_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_STD.BorderWidth = 0.5F;
            this.C_R22_STD.CanGrow = false;
            this.C_R22_STD.Dpi = 100F;
            this.C_R22_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R22_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 823F);
            this.C_R22_STD.Multiline = true;
            this.C_R22_STD.Name = "C_R22_STD";
            this.C_R22_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R22_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R22_STD.Text = "";
            this.C_R22_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R22_STD.WordWrap = true;
            // 
            // C_R22_SPEC
            // 
            this.C_R22_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R22_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_SPEC.BorderWidth = 0.5F;
            this.C_R22_SPEC.CanGrow = false;
            this.C_R22_SPEC.Dpi = 100F;
            this.C_R22_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R22_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 823F);
            this.C_R22_SPEC.Multiline = true;
            this.C_R22_SPEC.Name = "C_R22_SPEC";
            this.C_R22_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R22_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R22_SPEC.Text = "";
            this.C_R22_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R22_SPEC.WordWrap = true;
            // 
            // L_R22_MGR
            // 
            this.L_R22_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R22_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R22_MGR.BorderWidth = 0.5F;
            this.L_R22_MGR.CanGrow = false;
            this.L_R22_MGR.Dpi = 100F;
            this.L_R22_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 823F);
            this.L_R22_MGR.Multiline = true;
            this.L_R22_MGR.Name = "L_R22_MGR";
            this.L_R22_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R22_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R22_MGR.Text = "";
            this.L_R22_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R22_MGR.WordWrap = false;
            // 
            // C_R22_X1
            // 
            this.C_R22_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R22_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_X1.BorderWidth = 0.5F;
            this.C_R22_X1.CanGrow = false;
            this.C_R22_X1.Dpi = 100F;
            this.C_R22_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 823F);
            this.C_R22_X1.Multiline = true;
            this.C_R22_X1.Name = "C_R22_X1";
            this.C_R22_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R22_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R22_X1.Text = "";
            this.C_R22_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_X1.WordWrap = false;
            // 
            // C_R22_X2
            // 
            this.C_R22_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R22_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_X2.BorderWidth = 0.5F;
            this.C_R22_X2.CanGrow = false;
            this.C_R22_X2.Dpi = 100F;
            this.C_R22_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 823F);
            this.C_R22_X2.Multiline = true;
            this.C_R22_X2.Name = "C_R22_X2";
            this.C_R22_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R22_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R22_X2.Text = "";
            this.C_R22_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_X2.WordWrap = false;
            // 
            // C_R22_X3
            // 
            this.C_R22_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R22_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_X3.BorderWidth = 0.5F;
            this.C_R22_X3.CanGrow = false;
            this.C_R22_X3.Dpi = 100F;
            this.C_R22_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 823F);
            this.C_R22_X3.Multiline = true;
            this.C_R22_X3.Name = "C_R22_X3";
            this.C_R22_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R22_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R22_X3.Text = "";
            this.C_R22_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_X3.WordWrap = false;
            // 
            // C_R22_X4
            // 
            this.C_R22_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R22_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_X4.BorderWidth = 0.5F;
            this.C_R22_X4.CanGrow = false;
            this.C_R22_X4.Dpi = 100F;
            this.C_R22_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 823F);
            this.C_R22_X4.Multiline = true;
            this.C_R22_X4.Name = "C_R22_X4";
            this.C_R22_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R22_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R22_X4.Text = "";
            this.C_R22_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_X4.WordWrap = false;
            // 
            // C_R22_X5
            // 
            this.C_R22_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R22_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_X5.BorderWidth = 0.5F;
            this.C_R22_X5.CanGrow = false;
            this.C_R22_X5.Dpi = 100F;
            this.C_R22_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R22_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 823F);
            this.C_R22_X5.Multiline = true;
            this.C_R22_X5.Name = "C_R22_X5";
            this.C_R22_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R22_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R22_X5.Text = "";
            this.C_R22_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_X5.WordWrap = false;
            // 
            // C_R22_JUDGE
            // 
            this.C_R22_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R22_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_JUDGE.BorderWidth = 0.5F;
            this.C_R22_JUDGE.CanGrow = false;
            this.C_R22_JUDGE.Dpi = 100F;
            this.C_R22_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 823F);
            this.C_R22_JUDGE.Multiline = true;
            this.C_R22_JUDGE.Name = "C_R22_JUDGE";
            this.C_R22_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R22_JUDGE.Text = "";
            this.C_R22_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_JUDGE.WordWrap = false;
            // 
            // L_R22_DX1
            // 
            this.L_R22_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R22_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R22_DX1.BorderWidth = 0.5F;
            this.L_R22_DX1.CanGrow = false;
            this.L_R22_DX1.Dpi = 100F;
            this.L_R22_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 823F);
            this.L_R22_DX1.Multiline = true;
            this.L_R22_DX1.Name = "L_R22_DX1";
            this.L_R22_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R22_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R22_DX1.Text = "";
            this.L_R22_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R22_DX1.WordWrap = false;
            // 
            // L_R22_DX2
            // 
            this.L_R22_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R22_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R22_DX2.BorderWidth = 0.5F;
            this.L_R22_DX2.CanGrow = false;
            this.L_R22_DX2.Dpi = 100F;
            this.L_R22_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 823F);
            this.L_R22_DX2.Multiline = true;
            this.L_R22_DX2.Name = "L_R22_DX2";
            this.L_R22_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R22_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R22_DX2.Text = "";
            this.L_R22_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R22_DX2.WordWrap = false;
            // 
            // L_R22_DX3
            // 
            this.L_R22_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R22_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R22_DX3.BorderWidth = 0.5F;
            this.L_R22_DX3.CanGrow = false;
            this.L_R22_DX3.Dpi = 100F;
            this.L_R22_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 823F);
            this.L_R22_DX3.Multiline = true;
            this.L_R22_DX3.Name = "L_R22_DX3";
            this.L_R22_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R22_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R22_DX3.Text = "";
            this.L_R22_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R22_DX3.WordWrap = false;
            // 
            // L_R22_DX4
            // 
            this.L_R22_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R22_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R22_DX4.BorderWidth = 0.5F;
            this.L_R22_DX4.CanGrow = false;
            this.L_R22_DX4.Dpi = 100F;
            this.L_R22_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 823F);
            this.L_R22_DX4.Multiline = true;
            this.L_R22_DX4.Name = "L_R22_DX4";
            this.L_R22_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R22_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R22_DX4.Text = "";
            this.L_R22_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R22_DX4.WordWrap = false;
            // 
            // L_R22_DX5
            // 
            this.L_R22_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R22_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R22_DX5.BorderWidth = 0.5F;
            this.L_R22_DX5.CanGrow = false;
            this.L_R22_DX5.Dpi = 100F;
            this.L_R22_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 823F);
            this.L_R22_DX5.Multiline = true;
            this.L_R22_DX5.Name = "L_R22_DX5";
            this.L_R22_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R22_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R22_DX5.Text = "";
            this.L_R22_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R22_DX5.WordWrap = false;
            // 
            // L_R22_DJ
            // 
            this.L_R22_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R22_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R22_DJ.BorderWidth = 0.5F;
            this.L_R22_DJ.CanGrow = false;
            this.L_R22_DJ.Dpi = 100F;
            this.L_R22_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 823F);
            this.L_R22_DJ.Multiline = true;
            this.L_R22_DJ.Name = "L_R22_DJ";
            this.L_R22_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R22_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R22_DJ.Text = "";
            this.L_R22_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R22_DJ.WordWrap = false;
            // 
            // C_R22_XSPAN
            // 
            this.C_R22_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R22_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R22_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R22_XSPAN.BorderWidth = 0.5F;
            this.C_R22_XSPAN.CanGrow = false;
            this.C_R22_XSPAN.Dpi = 100F;
            this.C_R22_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R22_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 823F);
            this.C_R22_XSPAN.Multiline = true;
            this.C_R22_XSPAN.Name = "C_R22_XSPAN";
            this.C_R22_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R22_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R22_XSPAN.Text = "";
            this.C_R22_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R22_XSPAN.Visible = false;
            this.C_R22_XSPAN.WordWrap = false;
            // 
            // C_R23_NO
            // 
            this.C_R23_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R23_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_NO.BorderWidth = 0.5F;
            this.C_R23_NO.CanGrow = false;
            this.C_R23_NO.Dpi = 100F;
            this.C_R23_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 847F);
            this.C_R23_NO.Multiline = true;
            this.C_R23_NO.Name = "C_R23_NO";
            this.C_R23_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R23_NO.Text = "";
            this.C_R23_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_NO.WordWrap = false;
            // 
            // C_R23_STD
            // 
            this.C_R23_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R23_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_STD.BorderWidth = 0.5F;
            this.C_R23_STD.CanGrow = false;
            this.C_R23_STD.Dpi = 100F;
            this.C_R23_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R23_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 847F);
            this.C_R23_STD.Multiline = true;
            this.C_R23_STD.Name = "C_R23_STD";
            this.C_R23_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R23_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R23_STD.Text = "";
            this.C_R23_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R23_STD.WordWrap = true;
            // 
            // C_R23_SPEC
            // 
            this.C_R23_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R23_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_SPEC.BorderWidth = 0.5F;
            this.C_R23_SPEC.CanGrow = false;
            this.C_R23_SPEC.Dpi = 100F;
            this.C_R23_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R23_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 847F);
            this.C_R23_SPEC.Multiline = true;
            this.C_R23_SPEC.Name = "C_R23_SPEC";
            this.C_R23_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R23_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R23_SPEC.Text = "";
            this.C_R23_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R23_SPEC.WordWrap = true;
            // 
            // L_R23_MGR
            // 
            this.L_R23_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R23_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R23_MGR.BorderWidth = 0.5F;
            this.L_R23_MGR.CanGrow = false;
            this.L_R23_MGR.Dpi = 100F;
            this.L_R23_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 847F);
            this.L_R23_MGR.Multiline = true;
            this.L_R23_MGR.Name = "L_R23_MGR";
            this.L_R23_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R23_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R23_MGR.Text = "";
            this.L_R23_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R23_MGR.WordWrap = false;
            // 
            // C_R23_X1
            // 
            this.C_R23_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R23_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_X1.BorderWidth = 0.5F;
            this.C_R23_X1.CanGrow = false;
            this.C_R23_X1.Dpi = 100F;
            this.C_R23_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 847F);
            this.C_R23_X1.Multiline = true;
            this.C_R23_X1.Name = "C_R23_X1";
            this.C_R23_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R23_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R23_X1.Text = "";
            this.C_R23_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_X1.WordWrap = false;
            // 
            // C_R23_X2
            // 
            this.C_R23_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R23_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_X2.BorderWidth = 0.5F;
            this.C_R23_X2.CanGrow = false;
            this.C_R23_X2.Dpi = 100F;
            this.C_R23_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 847F);
            this.C_R23_X2.Multiline = true;
            this.C_R23_X2.Name = "C_R23_X2";
            this.C_R23_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R23_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R23_X2.Text = "";
            this.C_R23_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_X2.WordWrap = false;
            // 
            // C_R23_X3
            // 
            this.C_R23_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R23_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_X3.BorderWidth = 0.5F;
            this.C_R23_X3.CanGrow = false;
            this.C_R23_X3.Dpi = 100F;
            this.C_R23_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 847F);
            this.C_R23_X3.Multiline = true;
            this.C_R23_X3.Name = "C_R23_X3";
            this.C_R23_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R23_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R23_X3.Text = "";
            this.C_R23_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_X3.WordWrap = false;
            // 
            // C_R23_X4
            // 
            this.C_R23_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R23_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_X4.BorderWidth = 0.5F;
            this.C_R23_X4.CanGrow = false;
            this.C_R23_X4.Dpi = 100F;
            this.C_R23_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 847F);
            this.C_R23_X4.Multiline = true;
            this.C_R23_X4.Name = "C_R23_X4";
            this.C_R23_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R23_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R23_X4.Text = "";
            this.C_R23_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_X4.WordWrap = false;
            // 
            // C_R23_X5
            // 
            this.C_R23_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R23_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_X5.BorderWidth = 0.5F;
            this.C_R23_X5.CanGrow = false;
            this.C_R23_X5.Dpi = 100F;
            this.C_R23_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R23_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 847F);
            this.C_R23_X5.Multiline = true;
            this.C_R23_X5.Name = "C_R23_X5";
            this.C_R23_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R23_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R23_X5.Text = "";
            this.C_R23_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_X5.WordWrap = false;
            // 
            // C_R23_JUDGE
            // 
            this.C_R23_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R23_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_JUDGE.BorderWidth = 0.5F;
            this.C_R23_JUDGE.CanGrow = false;
            this.C_R23_JUDGE.Dpi = 100F;
            this.C_R23_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 847F);
            this.C_R23_JUDGE.Multiline = true;
            this.C_R23_JUDGE.Name = "C_R23_JUDGE";
            this.C_R23_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R23_JUDGE.Text = "";
            this.C_R23_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_JUDGE.WordWrap = false;
            // 
            // L_R23_DX1
            // 
            this.L_R23_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R23_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R23_DX1.BorderWidth = 0.5F;
            this.L_R23_DX1.CanGrow = false;
            this.L_R23_DX1.Dpi = 100F;
            this.L_R23_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 847F);
            this.L_R23_DX1.Multiline = true;
            this.L_R23_DX1.Name = "L_R23_DX1";
            this.L_R23_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R23_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R23_DX1.Text = "";
            this.L_R23_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R23_DX1.WordWrap = false;
            // 
            // L_R23_DX2
            // 
            this.L_R23_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R23_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R23_DX2.BorderWidth = 0.5F;
            this.L_R23_DX2.CanGrow = false;
            this.L_R23_DX2.Dpi = 100F;
            this.L_R23_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 847F);
            this.L_R23_DX2.Multiline = true;
            this.L_R23_DX2.Name = "L_R23_DX2";
            this.L_R23_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R23_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R23_DX2.Text = "";
            this.L_R23_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R23_DX2.WordWrap = false;
            // 
            // L_R23_DX3
            // 
            this.L_R23_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R23_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R23_DX3.BorderWidth = 0.5F;
            this.L_R23_DX3.CanGrow = false;
            this.L_R23_DX3.Dpi = 100F;
            this.L_R23_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 847F);
            this.L_R23_DX3.Multiline = true;
            this.L_R23_DX3.Name = "L_R23_DX3";
            this.L_R23_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R23_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R23_DX3.Text = "";
            this.L_R23_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R23_DX3.WordWrap = false;
            // 
            // L_R23_DX4
            // 
            this.L_R23_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R23_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R23_DX4.BorderWidth = 0.5F;
            this.L_R23_DX4.CanGrow = false;
            this.L_R23_DX4.Dpi = 100F;
            this.L_R23_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 847F);
            this.L_R23_DX4.Multiline = true;
            this.L_R23_DX4.Name = "L_R23_DX4";
            this.L_R23_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R23_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R23_DX4.Text = "";
            this.L_R23_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R23_DX4.WordWrap = false;
            // 
            // L_R23_DX5
            // 
            this.L_R23_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R23_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R23_DX5.BorderWidth = 0.5F;
            this.L_R23_DX5.CanGrow = false;
            this.L_R23_DX5.Dpi = 100F;
            this.L_R23_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 847F);
            this.L_R23_DX5.Multiline = true;
            this.L_R23_DX5.Name = "L_R23_DX5";
            this.L_R23_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R23_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R23_DX5.Text = "";
            this.L_R23_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R23_DX5.WordWrap = false;
            // 
            // L_R23_DJ
            // 
            this.L_R23_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R23_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R23_DJ.BorderWidth = 0.5F;
            this.L_R23_DJ.CanGrow = false;
            this.L_R23_DJ.Dpi = 100F;
            this.L_R23_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 847F);
            this.L_R23_DJ.Multiline = true;
            this.L_R23_DJ.Name = "L_R23_DJ";
            this.L_R23_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R23_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R23_DJ.Text = "";
            this.L_R23_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R23_DJ.WordWrap = false;
            // 
            // C_R23_XSPAN
            // 
            this.C_R23_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R23_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R23_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R23_XSPAN.BorderWidth = 0.5F;
            this.C_R23_XSPAN.CanGrow = false;
            this.C_R23_XSPAN.Dpi = 100F;
            this.C_R23_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R23_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 847F);
            this.C_R23_XSPAN.Multiline = true;
            this.C_R23_XSPAN.Name = "C_R23_XSPAN";
            this.C_R23_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R23_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R23_XSPAN.Text = "";
            this.C_R23_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R23_XSPAN.Visible = false;
            this.C_R23_XSPAN.WordWrap = false;
            // 
            // C_R24_NO
            // 
            this.C_R24_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R24_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_NO.BorderWidth = 0.5F;
            this.C_R24_NO.CanGrow = false;
            this.C_R24_NO.Dpi = 100F;
            this.C_R24_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 871F);
            this.C_R24_NO.Multiline = true;
            this.C_R24_NO.Name = "C_R24_NO";
            this.C_R24_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R24_NO.Text = "";
            this.C_R24_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_NO.WordWrap = false;
            // 
            // C_R24_STD
            // 
            this.C_R24_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R24_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_STD.BorderWidth = 0.5F;
            this.C_R24_STD.CanGrow = false;
            this.C_R24_STD.Dpi = 100F;
            this.C_R24_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R24_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 871F);
            this.C_R24_STD.Multiline = true;
            this.C_R24_STD.Name = "C_R24_STD";
            this.C_R24_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R24_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R24_STD.Text = "";
            this.C_R24_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R24_STD.WordWrap = true;
            // 
            // C_R24_SPEC
            // 
            this.C_R24_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R24_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_SPEC.BorderWidth = 0.5F;
            this.C_R24_SPEC.CanGrow = false;
            this.C_R24_SPEC.Dpi = 100F;
            this.C_R24_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R24_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 871F);
            this.C_R24_SPEC.Multiline = true;
            this.C_R24_SPEC.Name = "C_R24_SPEC";
            this.C_R24_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R24_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R24_SPEC.Text = "";
            this.C_R24_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R24_SPEC.WordWrap = true;
            // 
            // L_R24_MGR
            // 
            this.L_R24_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R24_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R24_MGR.BorderWidth = 0.5F;
            this.L_R24_MGR.CanGrow = false;
            this.L_R24_MGR.Dpi = 100F;
            this.L_R24_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 871F);
            this.L_R24_MGR.Multiline = true;
            this.L_R24_MGR.Name = "L_R24_MGR";
            this.L_R24_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R24_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R24_MGR.Text = "";
            this.L_R24_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R24_MGR.WordWrap = false;
            // 
            // C_R24_X1
            // 
            this.C_R24_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R24_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_X1.BorderWidth = 0.5F;
            this.C_R24_X1.CanGrow = false;
            this.C_R24_X1.Dpi = 100F;
            this.C_R24_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 871F);
            this.C_R24_X1.Multiline = true;
            this.C_R24_X1.Name = "C_R24_X1";
            this.C_R24_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R24_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R24_X1.Text = "";
            this.C_R24_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_X1.WordWrap = false;
            // 
            // C_R24_X2
            // 
            this.C_R24_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R24_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_X2.BorderWidth = 0.5F;
            this.C_R24_X2.CanGrow = false;
            this.C_R24_X2.Dpi = 100F;
            this.C_R24_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 871F);
            this.C_R24_X2.Multiline = true;
            this.C_R24_X2.Name = "C_R24_X2";
            this.C_R24_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R24_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R24_X2.Text = "";
            this.C_R24_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_X2.WordWrap = false;
            // 
            // C_R24_X3
            // 
            this.C_R24_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R24_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_X3.BorderWidth = 0.5F;
            this.C_R24_X3.CanGrow = false;
            this.C_R24_X3.Dpi = 100F;
            this.C_R24_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 871F);
            this.C_R24_X3.Multiline = true;
            this.C_R24_X3.Name = "C_R24_X3";
            this.C_R24_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R24_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R24_X3.Text = "";
            this.C_R24_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_X3.WordWrap = false;
            // 
            // C_R24_X4
            // 
            this.C_R24_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R24_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_X4.BorderWidth = 0.5F;
            this.C_R24_X4.CanGrow = false;
            this.C_R24_X4.Dpi = 100F;
            this.C_R24_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 871F);
            this.C_R24_X4.Multiline = true;
            this.C_R24_X4.Name = "C_R24_X4";
            this.C_R24_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R24_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R24_X4.Text = "";
            this.C_R24_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_X4.WordWrap = false;
            // 
            // C_R24_X5
            // 
            this.C_R24_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R24_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_X5.BorderWidth = 0.5F;
            this.C_R24_X5.CanGrow = false;
            this.C_R24_X5.Dpi = 100F;
            this.C_R24_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R24_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 871F);
            this.C_R24_X5.Multiline = true;
            this.C_R24_X5.Name = "C_R24_X5";
            this.C_R24_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R24_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R24_X5.Text = "";
            this.C_R24_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_X5.WordWrap = false;
            // 
            // C_R24_JUDGE
            // 
            this.C_R24_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R24_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_JUDGE.BorderWidth = 0.5F;
            this.C_R24_JUDGE.CanGrow = false;
            this.C_R24_JUDGE.Dpi = 100F;
            this.C_R24_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 871F);
            this.C_R24_JUDGE.Multiline = true;
            this.C_R24_JUDGE.Name = "C_R24_JUDGE";
            this.C_R24_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R24_JUDGE.Text = "";
            this.C_R24_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_JUDGE.WordWrap = false;
            // 
            // L_R24_DX1
            // 
            this.L_R24_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R24_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R24_DX1.BorderWidth = 0.5F;
            this.L_R24_DX1.CanGrow = false;
            this.L_R24_DX1.Dpi = 100F;
            this.L_R24_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 871F);
            this.L_R24_DX1.Multiline = true;
            this.L_R24_DX1.Name = "L_R24_DX1";
            this.L_R24_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R24_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R24_DX1.Text = "";
            this.L_R24_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R24_DX1.WordWrap = false;
            // 
            // L_R24_DX2
            // 
            this.L_R24_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R24_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R24_DX2.BorderWidth = 0.5F;
            this.L_R24_DX2.CanGrow = false;
            this.L_R24_DX2.Dpi = 100F;
            this.L_R24_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 871F);
            this.L_R24_DX2.Multiline = true;
            this.L_R24_DX2.Name = "L_R24_DX2";
            this.L_R24_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R24_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R24_DX2.Text = "";
            this.L_R24_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R24_DX2.WordWrap = false;
            // 
            // L_R24_DX3
            // 
            this.L_R24_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R24_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R24_DX3.BorderWidth = 0.5F;
            this.L_R24_DX3.CanGrow = false;
            this.L_R24_DX3.Dpi = 100F;
            this.L_R24_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 871F);
            this.L_R24_DX3.Multiline = true;
            this.L_R24_DX3.Name = "L_R24_DX3";
            this.L_R24_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R24_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R24_DX3.Text = "";
            this.L_R24_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R24_DX3.WordWrap = false;
            // 
            // L_R24_DX4
            // 
            this.L_R24_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R24_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R24_DX4.BorderWidth = 0.5F;
            this.L_R24_DX4.CanGrow = false;
            this.L_R24_DX4.Dpi = 100F;
            this.L_R24_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 871F);
            this.L_R24_DX4.Multiline = true;
            this.L_R24_DX4.Name = "L_R24_DX4";
            this.L_R24_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R24_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R24_DX4.Text = "";
            this.L_R24_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R24_DX4.WordWrap = false;
            // 
            // L_R24_DX5
            // 
            this.L_R24_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R24_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R24_DX5.BorderWidth = 0.5F;
            this.L_R24_DX5.CanGrow = false;
            this.L_R24_DX5.Dpi = 100F;
            this.L_R24_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 871F);
            this.L_R24_DX5.Multiline = true;
            this.L_R24_DX5.Name = "L_R24_DX5";
            this.L_R24_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R24_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R24_DX5.Text = "";
            this.L_R24_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R24_DX5.WordWrap = false;
            // 
            // L_R24_DJ
            // 
            this.L_R24_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R24_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R24_DJ.BorderWidth = 0.5F;
            this.L_R24_DJ.CanGrow = false;
            this.L_R24_DJ.Dpi = 100F;
            this.L_R24_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 871F);
            this.L_R24_DJ.Multiline = true;
            this.L_R24_DJ.Name = "L_R24_DJ";
            this.L_R24_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R24_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R24_DJ.Text = "";
            this.L_R24_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R24_DJ.WordWrap = false;
            // 
            // C_R24_XSPAN
            // 
            this.C_R24_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R24_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R24_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R24_XSPAN.BorderWidth = 0.5F;
            this.C_R24_XSPAN.CanGrow = false;
            this.C_R24_XSPAN.Dpi = 100F;
            this.C_R24_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R24_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 871F);
            this.C_R24_XSPAN.Multiline = true;
            this.C_R24_XSPAN.Name = "C_R24_XSPAN";
            this.C_R24_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R24_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R24_XSPAN.Text = "";
            this.C_R24_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R24_XSPAN.Visible = false;
            this.C_R24_XSPAN.WordWrap = false;
            // 
            // C_R25_NO
            // 
            this.C_R25_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R25_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_NO.BorderWidth = 0.5F;
            this.C_R25_NO.CanGrow = false;
            this.C_R25_NO.Dpi = 100F;
            this.C_R25_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R25_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 895F);
            this.C_R25_NO.Multiline = true;
            this.C_R25_NO.Name = "C_R25_NO";
            this.C_R25_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R25_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R25_NO.Text = "";
            this.C_R25_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R25_NO.WordWrap = false;
            // 
            // C_R25_STD
            // 
            this.C_R25_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R25_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_STD.BorderWidth = 0.5F;
            this.C_R25_STD.CanGrow = false;
            this.C_R25_STD.Dpi = 100F;
            this.C_R25_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R25_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 895F);
            this.C_R25_STD.Multiline = true;
            this.C_R25_STD.Name = "C_R25_STD";
            this.C_R25_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R25_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R25_STD.Text = "";
            this.C_R25_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R25_STD.WordWrap = true;
            // 
            // C_R25_SPEC
            // 
            this.C_R25_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R25_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_SPEC.BorderWidth = 0.5F;
            this.C_R25_SPEC.CanGrow = false;
            this.C_R25_SPEC.Dpi = 100F;
            this.C_R25_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R25_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 895F);
            this.C_R25_SPEC.Multiline = true;
            this.C_R25_SPEC.Name = "C_R25_SPEC";
            this.C_R25_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R25_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R25_SPEC.Text = "";
            this.C_R25_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R25_SPEC.WordWrap = true;
            // 
            // L_R25_MGR
            // 
            this.L_R25_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R25_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R25_MGR.BorderWidth = 0.5F;
            this.L_R25_MGR.CanGrow = false;
            this.L_R25_MGR.Dpi = 100F;
            this.L_R25_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 895F);
            this.L_R25_MGR.Multiline = true;
            this.L_R25_MGR.Name = "L_R25_MGR";
            this.L_R25_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R25_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R25_MGR.Text = "";
            this.L_R25_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R25_MGR.WordWrap = false;
            // 
            // C_R25_X1
            // 
            this.C_R25_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R25_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_X1.BorderWidth = 0.5F;
            this.C_R25_X1.CanGrow = false;
            this.C_R25_X1.Dpi = 100F;
            this.C_R25_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R25_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 895F);
            this.C_R25_X1.Multiline = true;
            this.C_R25_X1.Name = "C_R25_X1";
            this.C_R25_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R25_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R25_X1.Text = "";
            this.C_R25_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R25_X1.WordWrap = false;
            // 
            // C_R25_X2
            // 
            this.C_R25_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R25_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_X2.BorderWidth = 0.5F;
            this.C_R25_X2.CanGrow = false;
            this.C_R25_X2.Dpi = 100F;
            this.C_R25_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R25_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 895F);
            this.C_R25_X2.Multiline = true;
            this.C_R25_X2.Name = "C_R25_X2";
            this.C_R25_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R25_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R25_X2.Text = "";
            this.C_R25_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R25_X2.WordWrap = false;
            // 
            // C_R25_X3
            // 
            this.C_R25_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R25_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_X3.BorderWidth = 0.5F;
            this.C_R25_X3.CanGrow = false;
            this.C_R25_X3.Dpi = 100F;
            this.C_R25_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R25_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 895F);
            this.C_R25_X3.Multiline = true;
            this.C_R25_X3.Name = "C_R25_X3";
            this.C_R25_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R25_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R25_X3.Text = "";
            this.C_R25_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R25_X3.WordWrap = false;
            // 
            // C_R25_X4
            // 
            this.C_R25_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R25_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_X4.BorderWidth = 0.5F;
            this.C_R25_X4.CanGrow = false;
            this.C_R25_X4.Dpi = 100F;
            this.C_R25_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R25_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 895F);
            this.C_R25_X4.Multiline = true;
            this.C_R25_X4.Name = "C_R25_X4";
            this.C_R25_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R25_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R25_X4.Text = "";
            this.C_R25_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R25_X4.WordWrap = false;
            // 
            // C_R25_X5
            // 
            this.C_R25_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R25_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_X5.BorderWidth = 0.5F;
            this.C_R25_X5.CanGrow = false;
            this.C_R25_X5.Dpi = 100F;
            this.C_R25_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R25_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 895F);
            this.C_R25_X5.Multiline = true;
            this.C_R25_X5.Name = "C_R25_X5";
            this.C_R25_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R25_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R25_X5.Text = "";
            this.C_R25_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R25_X5.WordWrap = false;
            // 
            // C_R25_JUDGE
            // 
            this.C_R25_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R25_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_JUDGE.BorderWidth = 0.5F;
            this.C_R25_JUDGE.CanGrow = false;
            this.C_R25_JUDGE.Dpi = 100F;
            this.C_R25_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R25_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 895F);
            this.C_R25_JUDGE.Multiline = true;
            this.C_R25_JUDGE.Name = "C_R25_JUDGE";
            this.C_R25_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R25_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R25_JUDGE.Text = "";
            this.C_R25_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R25_JUDGE.WordWrap = false;
            // 
            // L_R25_DX1
            // 
            this.L_R25_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R25_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R25_DX1.BorderWidth = 0.5F;
            this.L_R25_DX1.CanGrow = false;
            this.L_R25_DX1.Dpi = 100F;
            this.L_R25_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 895F);
            this.L_R25_DX1.Multiline = true;
            this.L_R25_DX1.Name = "L_R25_DX1";
            this.L_R25_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R25_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R25_DX1.Text = "";
            this.L_R25_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R25_DX1.WordWrap = false;
            // 
            // L_R25_DX2
            // 
            this.L_R25_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R25_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R25_DX2.BorderWidth = 0.5F;
            this.L_R25_DX2.CanGrow = false;
            this.L_R25_DX2.Dpi = 100F;
            this.L_R25_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 895F);
            this.L_R25_DX2.Multiline = true;
            this.L_R25_DX2.Name = "L_R25_DX2";
            this.L_R25_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R25_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R25_DX2.Text = "";
            this.L_R25_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R25_DX2.WordWrap = false;
            // 
            // L_R25_DX3
            // 
            this.L_R25_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R25_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R25_DX3.BorderWidth = 0.5F;
            this.L_R25_DX3.CanGrow = false;
            this.L_R25_DX3.Dpi = 100F;
            this.L_R25_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 895F);
            this.L_R25_DX3.Multiline = true;
            this.L_R25_DX3.Name = "L_R25_DX3";
            this.L_R25_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R25_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R25_DX3.Text = "";
            this.L_R25_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R25_DX3.WordWrap = false;
            // 
            // L_R25_DX4
            // 
            this.L_R25_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R25_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R25_DX4.BorderWidth = 0.5F;
            this.L_R25_DX4.CanGrow = false;
            this.L_R25_DX4.Dpi = 100F;
            this.L_R25_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 895F);
            this.L_R25_DX4.Multiline = true;
            this.L_R25_DX4.Name = "L_R25_DX4";
            this.L_R25_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R25_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R25_DX4.Text = "";
            this.L_R25_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R25_DX4.WordWrap = false;
            // 
            // L_R25_DX5
            // 
            this.L_R25_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R25_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R25_DX5.BorderWidth = 0.5F;
            this.L_R25_DX5.CanGrow = false;
            this.L_R25_DX5.Dpi = 100F;
            this.L_R25_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 895F);
            this.L_R25_DX5.Multiline = true;
            this.L_R25_DX5.Name = "L_R25_DX5";
            this.L_R25_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R25_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R25_DX5.Text = "";
            this.L_R25_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R25_DX5.WordWrap = false;
            // 
            // L_R25_DJ
            // 
            this.L_R25_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R25_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R25_DJ.BorderWidth = 0.5F;
            this.L_R25_DJ.CanGrow = false;
            this.L_R25_DJ.Dpi = 100F;
            this.L_R25_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 895F);
            this.L_R25_DJ.Multiline = true;
            this.L_R25_DJ.Name = "L_R25_DJ";
            this.L_R25_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R25_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R25_DJ.Text = "";
            this.L_R25_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R25_DJ.WordWrap = false;
            // 
            // C_R25_XSPAN
            // 
            this.C_R25_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R25_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R25_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R25_XSPAN.BorderWidth = 0.5F;
            this.C_R25_XSPAN.CanGrow = false;
            this.C_R25_XSPAN.Dpi = 100F;
            this.C_R25_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R25_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 895F);
            this.C_R25_XSPAN.Multiline = true;
            this.C_R25_XSPAN.Name = "C_R25_XSPAN";
            this.C_R25_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R25_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R25_XSPAN.Text = "";
            this.C_R25_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R25_XSPAN.Visible = false;
            this.C_R25_XSPAN.WordWrap = false;
            // 
            // C_R26_NO
            // 
            this.C_R26_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R26_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_NO.BorderWidth = 0.5F;
            this.C_R26_NO.CanGrow = false;
            this.C_R26_NO.Dpi = 100F;
            this.C_R26_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R26_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 919F);
            this.C_R26_NO.Multiline = true;
            this.C_R26_NO.Name = "C_R26_NO";
            this.C_R26_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R26_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R26_NO.Text = "";
            this.C_R26_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R26_NO.WordWrap = false;
            // 
            // C_R26_STD
            // 
            this.C_R26_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R26_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_STD.BorderWidth = 0.5F;
            this.C_R26_STD.CanGrow = false;
            this.C_R26_STD.Dpi = 100F;
            this.C_R26_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R26_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 919F);
            this.C_R26_STD.Multiline = true;
            this.C_R26_STD.Name = "C_R26_STD";
            this.C_R26_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R26_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R26_STD.Text = "";
            this.C_R26_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R26_STD.WordWrap = true;
            // 
            // C_R26_SPEC
            // 
            this.C_R26_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R26_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_SPEC.BorderWidth = 0.5F;
            this.C_R26_SPEC.CanGrow = false;
            this.C_R26_SPEC.Dpi = 100F;
            this.C_R26_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R26_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 919F);
            this.C_R26_SPEC.Multiline = true;
            this.C_R26_SPEC.Name = "C_R26_SPEC";
            this.C_R26_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R26_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R26_SPEC.Text = "";
            this.C_R26_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R26_SPEC.WordWrap = true;
            // 
            // L_R26_MGR
            // 
            this.L_R26_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R26_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R26_MGR.BorderWidth = 0.5F;
            this.L_R26_MGR.CanGrow = false;
            this.L_R26_MGR.Dpi = 100F;
            this.L_R26_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 919F);
            this.L_R26_MGR.Multiline = true;
            this.L_R26_MGR.Name = "L_R26_MGR";
            this.L_R26_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R26_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R26_MGR.Text = "";
            this.L_R26_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R26_MGR.WordWrap = false;
            // 
            // C_R26_X1
            // 
            this.C_R26_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R26_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_X1.BorderWidth = 0.5F;
            this.C_R26_X1.CanGrow = false;
            this.C_R26_X1.Dpi = 100F;
            this.C_R26_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R26_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 919F);
            this.C_R26_X1.Multiline = true;
            this.C_R26_X1.Name = "C_R26_X1";
            this.C_R26_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R26_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R26_X1.Text = "";
            this.C_R26_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R26_X1.WordWrap = false;
            // 
            // C_R26_X2
            // 
            this.C_R26_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R26_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_X2.BorderWidth = 0.5F;
            this.C_R26_X2.CanGrow = false;
            this.C_R26_X2.Dpi = 100F;
            this.C_R26_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R26_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 919F);
            this.C_R26_X2.Multiline = true;
            this.C_R26_X2.Name = "C_R26_X2";
            this.C_R26_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R26_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R26_X2.Text = "";
            this.C_R26_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R26_X2.WordWrap = false;
            // 
            // C_R26_X3
            // 
            this.C_R26_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R26_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_X3.BorderWidth = 0.5F;
            this.C_R26_X3.CanGrow = false;
            this.C_R26_X3.Dpi = 100F;
            this.C_R26_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R26_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 919F);
            this.C_R26_X3.Multiline = true;
            this.C_R26_X3.Name = "C_R26_X3";
            this.C_R26_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R26_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R26_X3.Text = "";
            this.C_R26_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R26_X3.WordWrap = false;
            // 
            // C_R26_X4
            // 
            this.C_R26_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R26_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_X4.BorderWidth = 0.5F;
            this.C_R26_X4.CanGrow = false;
            this.C_R26_X4.Dpi = 100F;
            this.C_R26_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R26_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 919F);
            this.C_R26_X4.Multiline = true;
            this.C_R26_X4.Name = "C_R26_X4";
            this.C_R26_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R26_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R26_X4.Text = "";
            this.C_R26_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R26_X4.WordWrap = false;
            // 
            // C_R26_X5
            // 
            this.C_R26_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R26_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_X5.BorderWidth = 0.5F;
            this.C_R26_X5.CanGrow = false;
            this.C_R26_X5.Dpi = 100F;
            this.C_R26_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R26_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 919F);
            this.C_R26_X5.Multiline = true;
            this.C_R26_X5.Name = "C_R26_X5";
            this.C_R26_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R26_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R26_X5.Text = "";
            this.C_R26_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R26_X5.WordWrap = false;
            // 
            // C_R26_JUDGE
            // 
            this.C_R26_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R26_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_JUDGE.BorderWidth = 0.5F;
            this.C_R26_JUDGE.CanGrow = false;
            this.C_R26_JUDGE.Dpi = 100F;
            this.C_R26_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R26_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 919F);
            this.C_R26_JUDGE.Multiline = true;
            this.C_R26_JUDGE.Name = "C_R26_JUDGE";
            this.C_R26_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R26_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R26_JUDGE.Text = "";
            this.C_R26_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R26_JUDGE.WordWrap = false;
            // 
            // L_R26_DX1
            // 
            this.L_R26_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R26_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R26_DX1.BorderWidth = 0.5F;
            this.L_R26_DX1.CanGrow = false;
            this.L_R26_DX1.Dpi = 100F;
            this.L_R26_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 919F);
            this.L_R26_DX1.Multiline = true;
            this.L_R26_DX1.Name = "L_R26_DX1";
            this.L_R26_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R26_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R26_DX1.Text = "";
            this.L_R26_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R26_DX1.WordWrap = false;
            // 
            // L_R26_DX2
            // 
            this.L_R26_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R26_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R26_DX2.BorderWidth = 0.5F;
            this.L_R26_DX2.CanGrow = false;
            this.L_R26_DX2.Dpi = 100F;
            this.L_R26_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 919F);
            this.L_R26_DX2.Multiline = true;
            this.L_R26_DX2.Name = "L_R26_DX2";
            this.L_R26_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R26_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R26_DX2.Text = "";
            this.L_R26_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R26_DX2.WordWrap = false;
            // 
            // L_R26_DX3
            // 
            this.L_R26_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R26_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R26_DX3.BorderWidth = 0.5F;
            this.L_R26_DX3.CanGrow = false;
            this.L_R26_DX3.Dpi = 100F;
            this.L_R26_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 919F);
            this.L_R26_DX3.Multiline = true;
            this.L_R26_DX3.Name = "L_R26_DX3";
            this.L_R26_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R26_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R26_DX3.Text = "";
            this.L_R26_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R26_DX3.WordWrap = false;
            // 
            // L_R26_DX4
            // 
            this.L_R26_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R26_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R26_DX4.BorderWidth = 0.5F;
            this.L_R26_DX4.CanGrow = false;
            this.L_R26_DX4.Dpi = 100F;
            this.L_R26_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 919F);
            this.L_R26_DX4.Multiline = true;
            this.L_R26_DX4.Name = "L_R26_DX4";
            this.L_R26_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R26_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R26_DX4.Text = "";
            this.L_R26_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R26_DX4.WordWrap = false;
            // 
            // L_R26_DX5
            // 
            this.L_R26_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R26_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R26_DX5.BorderWidth = 0.5F;
            this.L_R26_DX5.CanGrow = false;
            this.L_R26_DX5.Dpi = 100F;
            this.L_R26_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 919F);
            this.L_R26_DX5.Multiline = true;
            this.L_R26_DX5.Name = "L_R26_DX5";
            this.L_R26_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R26_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R26_DX5.Text = "";
            this.L_R26_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R26_DX5.WordWrap = false;
            // 
            // L_R26_DJ
            // 
            this.L_R26_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R26_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R26_DJ.BorderWidth = 0.5F;
            this.L_R26_DJ.CanGrow = false;
            this.L_R26_DJ.Dpi = 100F;
            this.L_R26_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 919F);
            this.L_R26_DJ.Multiline = true;
            this.L_R26_DJ.Name = "L_R26_DJ";
            this.L_R26_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R26_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R26_DJ.Text = "";
            this.L_R26_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R26_DJ.WordWrap = false;
            // 
            // C_R26_XSPAN
            // 
            this.C_R26_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R26_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R26_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R26_XSPAN.BorderWidth = 0.5F;
            this.C_R26_XSPAN.CanGrow = false;
            this.C_R26_XSPAN.Dpi = 100F;
            this.C_R26_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R26_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 919F);
            this.C_R26_XSPAN.Multiline = true;
            this.C_R26_XSPAN.Name = "C_R26_XSPAN";
            this.C_R26_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R26_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R26_XSPAN.Text = "";
            this.C_R26_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R26_XSPAN.Visible = false;
            this.C_R26_XSPAN.WordWrap = false;
            // 
            // C_R27_NO
            // 
            this.C_R27_NO.BorderColor = System.Drawing.Color.Black;
            this.C_R27_NO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_NO.BorderWidth = 0.5F;
            this.C_R27_NO.CanGrow = false;
            this.C_R27_NO.Dpi = 100F;
            this.C_R27_NO.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R27_NO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 943F);
            this.C_R27_NO.Multiline = true;
            this.C_R27_NO.Name = "C_R27_NO";
            this.C_R27_NO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R27_NO.SizeF = new System.Drawing.SizeF(25F, 24F);
            this.C_R27_NO.Text = "";
            this.C_R27_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R27_NO.WordWrap = false;
            // 
            // C_R27_STD
            // 
            this.C_R27_STD.BorderColor = System.Drawing.Color.Black;
            this.C_R27_STD.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_STD.BorderWidth = 0.5F;
            this.C_R27_STD.CanGrow = false;
            this.C_R27_STD.Dpi = 100F;
            this.C_R27_STD.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R27_STD.LocationFloat = new DevExpress.Utils.PointFloat(25F, 943F);
            this.C_R27_STD.Multiline = true;
            this.C_R27_STD.Name = "C_R27_STD";
            this.C_R27_STD.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R27_STD.SizeF = new System.Drawing.SizeF(112F, 24F);
            this.C_R27_STD.Text = "";
            this.C_R27_STD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R27_STD.WordWrap = true;
            // 
            // C_R27_SPEC
            // 
            this.C_R27_SPEC.BorderColor = System.Drawing.Color.Black;
            this.C_R27_SPEC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_SPEC.BorderWidth = 0.5F;
            this.C_R27_SPEC.CanGrow = false;
            this.C_R27_SPEC.Dpi = 100F;
            this.C_R27_SPEC.Font = new System.Drawing.Font("맑은 고딕", 6F);
            this.C_R27_SPEC.LocationFloat = new DevExpress.Utils.PointFloat(137F, 943F);
            this.C_R27_SPEC.Multiline = true;
            this.C_R27_SPEC.Name = "C_R27_SPEC";
            this.C_R27_SPEC.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R27_SPEC.SizeF = new System.Drawing.SizeF(99F, 24F);
            this.C_R27_SPEC.Text = "";
            this.C_R27_SPEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.C_R27_SPEC.WordWrap = true;
            // 
            // L_R27_MGR
            // 
            this.L_R27_MGR.BorderColor = System.Drawing.Color.Black;
            this.L_R27_MGR.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R27_MGR.BorderWidth = 0.5F;
            this.L_R27_MGR.CanGrow = false;
            this.L_R27_MGR.Dpi = 100F;
            this.L_R27_MGR.LocationFloat = new DevExpress.Utils.PointFloat(236F, 943F);
            this.L_R27_MGR.Multiline = true;
            this.L_R27_MGR.Name = "L_R27_MGR";
            this.L_R27_MGR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R27_MGR.SizeF = new System.Drawing.SizeF(35F, 24F);
            this.L_R27_MGR.Text = "";
            this.L_R27_MGR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R27_MGR.WordWrap = false;
            // 
            // C_R27_X1
            // 
            this.C_R27_X1.BorderColor = System.Drawing.Color.Black;
            this.C_R27_X1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_X1.BorderWidth = 0.5F;
            this.C_R27_X1.CanGrow = false;
            this.C_R27_X1.Dpi = 100F;
            this.C_R27_X1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R27_X1.LocationFloat = new DevExpress.Utils.PointFloat(271F, 943F);
            this.C_R27_X1.Multiline = true;
            this.C_R27_X1.Name = "C_R27_X1";
            this.C_R27_X1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R27_X1.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R27_X1.Text = "";
            this.C_R27_X1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R27_X1.WordWrap = false;
            // 
            // C_R27_X2
            // 
            this.C_R27_X2.BorderColor = System.Drawing.Color.Black;
            this.C_R27_X2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_X2.BorderWidth = 0.5F;
            this.C_R27_X2.CanGrow = false;
            this.C_R27_X2.Dpi = 100F;
            this.C_R27_X2.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R27_X2.LocationFloat = new DevExpress.Utils.PointFloat(312.2F, 943F);
            this.C_R27_X2.Multiline = true;
            this.C_R27_X2.Name = "C_R27_X2";
            this.C_R27_X2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R27_X2.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R27_X2.Text = "";
            this.C_R27_X2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R27_X2.WordWrap = false;
            // 
            // C_R27_X3
            // 
            this.C_R27_X3.BorderColor = System.Drawing.Color.Black;
            this.C_R27_X3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_X3.BorderWidth = 0.5F;
            this.C_R27_X3.CanGrow = false;
            this.C_R27_X3.Dpi = 100F;
            this.C_R27_X3.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R27_X3.LocationFloat = new DevExpress.Utils.PointFloat(353.4F, 943F);
            this.C_R27_X3.Multiline = true;
            this.C_R27_X3.Name = "C_R27_X3";
            this.C_R27_X3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R27_X3.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R27_X3.Text = "";
            this.C_R27_X3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R27_X3.WordWrap = false;
            // 
            // C_R27_X4
            // 
            this.C_R27_X4.BorderColor = System.Drawing.Color.Black;
            this.C_R27_X4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_X4.BorderWidth = 0.5F;
            this.C_R27_X4.CanGrow = false;
            this.C_R27_X4.Dpi = 100F;
            this.C_R27_X4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R27_X4.LocationFloat = new DevExpress.Utils.PointFloat(394.6F, 943F);
            this.C_R27_X4.Multiline = true;
            this.C_R27_X4.Name = "C_R27_X4";
            this.C_R27_X4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R27_X4.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R27_X4.Text = "";
            this.C_R27_X4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R27_X4.WordWrap = false;
            // 
            // C_R27_X5
            // 
            this.C_R27_X5.BorderColor = System.Drawing.Color.Black;
            this.C_R27_X5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_X5.BorderWidth = 0.5F;
            this.C_R27_X5.CanGrow = false;
            this.C_R27_X5.Dpi = 100F;
            this.C_R27_X5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.C_R27_X5.LocationFloat = new DevExpress.Utils.PointFloat(435.8F, 943F);
            this.C_R27_X5.Multiline = true;
            this.C_R27_X5.Name = "C_R27_X5";
            this.C_R27_X5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.C_R27_X5.SizeF = new System.Drawing.SizeF(41.2F, 24F);
            this.C_R27_X5.Text = "";
            this.C_R27_X5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R27_X5.WordWrap = false;
            // 
            // C_R27_JUDGE
            // 
            this.C_R27_JUDGE.BorderColor = System.Drawing.Color.Black;
            this.C_R27_JUDGE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_JUDGE.BorderWidth = 0.5F;
            this.C_R27_JUDGE.CanGrow = false;
            this.C_R27_JUDGE.Dpi = 100F;
            this.C_R27_JUDGE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R27_JUDGE.LocationFloat = new DevExpress.Utils.PointFloat(477F, 943F);
            this.C_R27_JUDGE.Multiline = true;
            this.C_R27_JUDGE.Name = "C_R27_JUDGE";
            this.C_R27_JUDGE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R27_JUDGE.SizeF = new System.Drawing.SizeF(42F, 24F);
            this.C_R27_JUDGE.Text = "";
            this.C_R27_JUDGE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R27_JUDGE.WordWrap = false;
            // 
            // L_R27_DX1
            // 
            this.L_R27_DX1.BorderColor = System.Drawing.Color.Black;
            this.L_R27_DX1.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R27_DX1.BorderWidth = 0.5F;
            this.L_R27_DX1.CanGrow = false;
            this.L_R27_DX1.Dpi = 100F;
            this.L_R27_DX1.LocationFloat = new DevExpress.Utils.PointFloat(519F, 943F);
            this.L_R27_DX1.Multiline = true;
            this.L_R27_DX1.Name = "L_R27_DX1";
            this.L_R27_DX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R27_DX1.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R27_DX1.Text = "";
            this.L_R27_DX1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R27_DX1.WordWrap = false;
            // 
            // L_R27_DX2
            // 
            this.L_R27_DX2.BorderColor = System.Drawing.Color.Black;
            this.L_R27_DX2.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R27_DX2.BorderWidth = 0.5F;
            this.L_R27_DX2.CanGrow = false;
            this.L_R27_DX2.Dpi = 100F;
            this.L_R27_DX2.LocationFloat = new DevExpress.Utils.PointFloat(560.4F, 943F);
            this.L_R27_DX2.Multiline = true;
            this.L_R27_DX2.Name = "L_R27_DX2";
            this.L_R27_DX2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R27_DX2.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R27_DX2.Text = "";
            this.L_R27_DX2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R27_DX2.WordWrap = false;
            // 
            // L_R27_DX3
            // 
            this.L_R27_DX3.BorderColor = System.Drawing.Color.Black;
            this.L_R27_DX3.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R27_DX3.BorderWidth = 0.5F;
            this.L_R27_DX3.CanGrow = false;
            this.L_R27_DX3.Dpi = 100F;
            this.L_R27_DX3.LocationFloat = new DevExpress.Utils.PointFloat(601.8F, 943F);
            this.L_R27_DX3.Multiline = true;
            this.L_R27_DX3.Name = "L_R27_DX3";
            this.L_R27_DX3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R27_DX3.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R27_DX3.Text = "";
            this.L_R27_DX3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R27_DX3.WordWrap = false;
            // 
            // L_R27_DX4
            // 
            this.L_R27_DX4.BorderColor = System.Drawing.Color.Black;
            this.L_R27_DX4.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R27_DX4.BorderWidth = 0.5F;
            this.L_R27_DX4.CanGrow = false;
            this.L_R27_DX4.Dpi = 100F;
            this.L_R27_DX4.LocationFloat = new DevExpress.Utils.PointFloat(643.2F, 943F);
            this.L_R27_DX4.Multiline = true;
            this.L_R27_DX4.Name = "L_R27_DX4";
            this.L_R27_DX4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R27_DX4.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R27_DX4.Text = "";
            this.L_R27_DX4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R27_DX4.WordWrap = false;
            // 
            // L_R27_DX5
            // 
            this.L_R27_DX5.BorderColor = System.Drawing.Color.Black;
            this.L_R27_DX5.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R27_DX5.BorderWidth = 0.5F;
            this.L_R27_DX5.CanGrow = false;
            this.L_R27_DX5.Dpi = 100F;
            this.L_R27_DX5.LocationFloat = new DevExpress.Utils.PointFloat(684.6F, 943F);
            this.L_R27_DX5.Multiline = true;
            this.L_R27_DX5.Name = "L_R27_DX5";
            this.L_R27_DX5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R27_DX5.SizeF = new System.Drawing.SizeF(41.4F, 24F);
            this.L_R27_DX5.Text = "";
            this.L_R27_DX5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R27_DX5.WordWrap = false;
            // 
            // L_R27_DJ
            // 
            this.L_R27_DJ.BorderColor = System.Drawing.Color.Black;
            this.L_R27_DJ.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_R27_DJ.BorderWidth = 0.5F;
            this.L_R27_DJ.CanGrow = false;
            this.L_R27_DJ.Dpi = 100F;
            this.L_R27_DJ.LocationFloat = new DevExpress.Utils.PointFloat(726F, 943F);
            this.L_R27_DJ.Multiline = true;
            this.L_R27_DJ.Name = "L_R27_DJ";
            this.L_R27_DJ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_R27_DJ.SizeF = new System.Drawing.SizeF(41F, 24F);
            this.L_R27_DJ.Text = "";
            this.L_R27_DJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.L_R27_DJ.WordWrap = false;
            // 
            // C_R27_XSPAN
            // 
            this.C_R27_XSPAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.C_R27_XSPAN.BorderColor = System.Drawing.Color.Black;
            this.C_R27_XSPAN.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.C_R27_XSPAN.BorderWidth = 0.5F;
            this.C_R27_XSPAN.CanGrow = false;
            this.C_R27_XSPAN.Dpi = 100F;
            this.C_R27_XSPAN.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.C_R27_XSPAN.LocationFloat = new DevExpress.Utils.PointFloat(271F, 943F);
            this.C_R27_XSPAN.Multiline = true;
            this.C_R27_XSPAN.Name = "C_R27_XSPAN";
            this.C_R27_XSPAN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_R27_XSPAN.SizeF = new System.Drawing.SizeF(206F, 24F);
            this.C_R27_XSPAN.Text = "";
            this.C_R27_XSPAN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_R27_XSPAN.Visible = false;
            this.C_R27_XSPAN.WordWrap = false;
            // 
            // L_REMARK
            // 
            this.L_REMARK.BorderColor = System.Drawing.Color.Black;
            this.L_REMARK.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_REMARK.BorderWidth = 0.5F;
            this.L_REMARK.CanGrow = false;
            this.L_REMARK.Dpi = 100F;
            this.L_REMARK.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_REMARK.LocationFloat = new DevExpress.Utils.PointFloat(0F, 967F);
            this.L_REMARK.Multiline = true;
            this.L_REMARK.Name = "L_REMARK";
            this.L_REMARK.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100F);
            this.L_REMARK.SizeF = new System.Drawing.SizeF(767F, 72F);
            this.L_REMARK.Text = "  비  고";
            this.L_REMARK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.L_REMARK.WordWrap = false;
            // 
            // C_QTY_TXT
            // 
            this.C_QTY_TXT.CanGrow = false;
            this.C_QTY_TXT.Dpi = 100F;
            this.C_QTY_TXT.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.C_QTY_TXT.LocationFloat = new DevExpress.Utils.PointFloat(283F, 1017F);
            this.C_QTY_TXT.Multiline = true;
            this.C_QTY_TXT.Name = "C_QTY_TXT";
            this.C_QTY_TXT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.C_QTY_TXT.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.C_QTY_TXT.Text = "";
            this.C_QTY_TXT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.C_QTY_TXT.WordWrap = false;
            // 
            // L_NOTE
            // 
            this.L_NOTE.BorderColor = System.Drawing.Color.Black;
            this.L_NOTE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_NOTE.BorderWidth = 0.5F;
            this.L_NOTE.CanGrow = false;
            this.L_NOTE.Dpi = 100F;
            this.L_NOTE.Font = new System.Drawing.Font("맑은 고딕", 7.5F);
            this.L_NOTE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1039F);
            this.L_NOTE.Multiline = true;
            this.L_NOTE.Name = "L_NOTE";
            this.L_NOTE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_NOTE.SizeF = new System.Drawing.SizeF(767F, 18F);
            this.L_NOTE.Text = "※ 관리구분:각 검사 항목의 관리 분류. (SPC : S, 정기검사 : P, 일상검사 : D )";
            this.L_NOTE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_NOTE.WordWrap = false;
            // 
            // R01
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.Detail});
            this.Dpi = 100F;
            this.Font = new System.Drawing.Font("맑은 고딕", 8F);
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
        private DevExpress.XtraReports.UI.XRLabel L_TITLE;
        private DevExpress.XtraReports.UI.XRLabel C_TQMDATE_TXT;
        private DevExpress.XtraReports.UI.XRLabel L_APRVITEM;
        private DevExpress.XtraReports.UI.XRLabel L_APRVITEM_V;
        private DevExpress.XtraReports.UI.XRLabel L_H1_1;
        private DevExpress.XtraReports.UI.XRLabel C_ITEMNM;
        private DevExpress.XtraReports.UI.XRLabel L_H1_2;
        private DevExpress.XtraReports.UI.XRLabel L_SUPPLIER;
        private DevExpress.XtraReports.UI.XRLabel L_H2_1;
        private DevExpress.XtraReports.UI.XRLabel C_ITEMCD;
        private DevExpress.XtraReports.UI.XRLabel L_H2_2;
        private DevExpress.XtraReports.UI.XRLabel C_EONO;
        private DevExpress.XtraReports.UI.XRLabel L_H3_1;
        private DevExpress.XtraReports.UI.XRLabel C_MODELCD;
        private DevExpress.XtraReports.UI.XRLabel L_H3_2;
        private DevExpress.XtraReports.UI.XRLabel L_GRADE;
        private DevExpress.XtraReports.UI.XRLabel L_ISSUE;
        private DevExpress.XtraReports.UI.XRLabel L_ISSUE_V;
        private DevExpress.XtraReports.UI.XRLabel C_APRVMARK;
        private DevExpress.XtraReports.UI.XRLabel L_APRV;
        private DevExpress.XtraReports.UI.XRLabel L_DEMAND;
        private DevExpress.XtraReports.UI.XRLabel L_SUPPLY;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_H1;
        private DevExpress.XtraReports.UI.XRLabel L_DEMAND_SIGN1;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_H2;
        private DevExpress.XtraReports.UI.XRLabel L_DEMAND_SIGN2;
        private DevExpress.XtraReports.UI.XRLabel L_APRV_H3;
        private DevExpress.XtraReports.UI.XRLabel L_DEMAND_SIGN3;
        private DevExpress.XtraReports.UI.XRLabel C_EMPNM;
        private DevExpress.XtraReports.UI.XRLabel L_SUPPLY_SIGN2;
        private DevExpress.XtraReports.UI.XRLabel C_APRVEMPNM;
        private DevExpress.XtraReports.UI.XRLabel L_T_NO;
        private DevExpress.XtraReports.UI.XRLabel L_T_STD;
        private DevExpress.XtraReports.UI.XRLabel L_T_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_T_MEAS;
        private DevExpress.XtraReports.UI.XRLabel L_T_UNIT;
        private DevExpress.XtraReports.UI.XRLabel L_T_SUPPLY;
        private DevExpress.XtraReports.UI.XRLabel L_T_DEMAND;
        private DevExpress.XtraReports.UI.XRLabel L_T_MGR;
        private DevExpress.XtraReports.UI.XRLabel L_T_SX1;
        private DevExpress.XtraReports.UI.XRLabel L_T_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_T_SX2;
        private DevExpress.XtraReports.UI.XRLabel L_T_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_T_SX3;
        private DevExpress.XtraReports.UI.XRLabel L_T_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_T_SX4;
        private DevExpress.XtraReports.UI.XRLabel L_T_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_T_SX5;
        private DevExpress.XtraReports.UI.XRLabel L_T_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_T_SJ;
        private DevExpress.XtraReports.UI.XRLabel L_T_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R01_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R01_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R01_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R01_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R01_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R01_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R01_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R01_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R01_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R01_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R01_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R01_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R01_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R01_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R01_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R01_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R01_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R02_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R02_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R02_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R02_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R02_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R02_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R02_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R02_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R02_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R02_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R02_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R02_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R02_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R02_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R02_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R02_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R02_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R03_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R03_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R03_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R03_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R03_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R03_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R03_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R03_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R03_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R03_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R03_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R03_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R03_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R03_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R03_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R03_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R03_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R04_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R04_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R04_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R04_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R04_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R04_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R04_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R04_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R04_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R04_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R04_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R04_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R04_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R04_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R04_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R04_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R04_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R05_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R05_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R05_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R05_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R05_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R05_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R05_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R05_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R05_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R05_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R05_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R05_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R05_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R05_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R05_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R05_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R05_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R06_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R06_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R06_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R06_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R06_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R06_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R06_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R06_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R06_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R06_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R06_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R06_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R06_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R06_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R06_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R06_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R06_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R07_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R07_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R07_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R07_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R07_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R07_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R07_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R07_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R07_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R07_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R07_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R07_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R07_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R07_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R07_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R07_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R07_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R08_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R08_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R08_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R08_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R08_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R08_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R08_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R08_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R08_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R08_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R08_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R08_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R08_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R08_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R08_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R08_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R08_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R09_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R09_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R09_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R09_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R09_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R09_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R09_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R09_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R09_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R09_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R09_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R09_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R09_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R09_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R09_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R09_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R09_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R10_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R10_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R10_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R10_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R10_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R10_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R10_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R10_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R10_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R10_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R10_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R10_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R10_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R10_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R10_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R10_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R10_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R11_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R11_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R11_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R11_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R11_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R11_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R11_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R11_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R11_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R11_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R11_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R11_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R11_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R11_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R11_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R11_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R11_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R12_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R12_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R12_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R12_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R12_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R12_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R12_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R12_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R12_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R12_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R12_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R12_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R12_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R12_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R12_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R12_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R12_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R13_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R13_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R13_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R13_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R13_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R13_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R13_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R13_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R13_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R13_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R13_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R13_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R13_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R13_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R13_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R13_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R13_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R14_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R14_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R14_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R14_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R14_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R14_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R14_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R14_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R14_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R14_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R14_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R14_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R14_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R14_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R14_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R14_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R14_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R15_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R15_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R15_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R15_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R15_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R15_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R15_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R15_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R15_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R15_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R15_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R15_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R15_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R15_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R15_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R15_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R15_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R16_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R16_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R16_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R16_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R16_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R16_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R16_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R16_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R16_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R16_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R16_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R16_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R16_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R16_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R16_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R16_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R16_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R17_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R17_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R17_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R17_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R17_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R17_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R17_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R17_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R17_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R17_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R17_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R17_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R17_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R17_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R17_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R17_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R17_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R18_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R18_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R18_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R18_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R18_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R18_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R18_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R18_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R18_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R18_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R18_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R18_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R18_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R18_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R18_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R18_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R18_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R19_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R19_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R19_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R19_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R19_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R19_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R19_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R19_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R19_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R19_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R19_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R19_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R19_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R19_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R19_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R19_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R19_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R20_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R20_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R20_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R20_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R20_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R20_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R20_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R20_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R20_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R20_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R20_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R20_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R20_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R20_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R20_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R20_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R20_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R21_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R21_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R21_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R21_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R21_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R21_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R21_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R21_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R21_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R21_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R21_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R21_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R21_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R21_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R21_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R21_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R21_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R22_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R22_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R22_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R22_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R22_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R22_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R22_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R22_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R22_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R22_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R22_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R22_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R22_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R22_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R22_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R22_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R22_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R23_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R23_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R23_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R23_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R23_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R23_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R23_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R23_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R23_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R23_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R23_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R23_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R23_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R23_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R23_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R23_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R23_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R24_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R24_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R24_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R24_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R24_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R24_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R24_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R24_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R24_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R24_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R24_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R24_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R24_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R24_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R24_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R24_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R24_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R25_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R25_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R25_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R25_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R25_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R25_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R25_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R25_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R25_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R25_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R25_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R25_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R25_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R25_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R25_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R25_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R25_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R26_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R26_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R26_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R26_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R26_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R26_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R26_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R26_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R26_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R26_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R26_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R26_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R26_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R26_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R26_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R26_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R26_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel C_R27_NO;
        private DevExpress.XtraReports.UI.XRLabel C_R27_STD;
        private DevExpress.XtraReports.UI.XRLabel C_R27_SPEC;
        private DevExpress.XtraReports.UI.XRLabel L_R27_MGR;
        private DevExpress.XtraReports.UI.XRLabel C_R27_X1;
        private DevExpress.XtraReports.UI.XRLabel C_R27_X2;
        private DevExpress.XtraReports.UI.XRLabel C_R27_X3;
        private DevExpress.XtraReports.UI.XRLabel C_R27_X4;
        private DevExpress.XtraReports.UI.XRLabel C_R27_X5;
        private DevExpress.XtraReports.UI.XRLabel C_R27_JUDGE;
        private DevExpress.XtraReports.UI.XRLabel L_R27_DX1;
        private DevExpress.XtraReports.UI.XRLabel L_R27_DX2;
        private DevExpress.XtraReports.UI.XRLabel L_R27_DX3;
        private DevExpress.XtraReports.UI.XRLabel L_R27_DX4;
        private DevExpress.XtraReports.UI.XRLabel L_R27_DX5;
        private DevExpress.XtraReports.UI.XRLabel L_R27_DJ;
        private DevExpress.XtraReports.UI.XRLabel C_R27_XSPAN;
        private DevExpress.XtraReports.UI.XRLabel L_REMARK;
        private DevExpress.XtraReports.UI.XRLabel C_QTY_TXT;
        private DevExpress.XtraReports.UI.XRLabel L_NOTE;
    }
}
