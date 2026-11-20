namespace TMLPRINT
{
    partial class PRD_2
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
            DevExpress.XtraPrinting.BarCode.PDF417Generator pdf417Generator1 = new DevExpress.XtraPrinting.BarCode.PDF417Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator2 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator3 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.L_FROM = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DESC = new DevExpress.XtraReports.UI.XRLabel();
            this.L_BOX2D = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAR2D = new DevExpress.XtraReports.UI.XRBarCode();
            this.L_PARTNO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_PARTNO_V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_BAR_PARTNO = new DevExpress.XtraReports.UI.XRBarCode();
            this.L_QTY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_QTY_V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_BAR_QTY = new DevExpress.XtraReports.UI.XRBarCode();
            this.L_COILTAG = new DevExpress.XtraReports.UI.XRLabel();
            this.C_COILTAG = new DevExpress.XtraReports.UI.XRLabel();
            this.L_REV = new DevExpress.XtraReports.UI.XRLabel();
            this.L_REV_V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_MFG = new DevExpress.XtraReports.UI.XRLabel();
            this.C_MFGDATE = new DevExpress.XtraReports.UI.XRLabel();
            this.L_PO = new DevExpress.XtraReports.UI.XRLabel();
            this.L_PO_V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_LICENSE = new DevExpress.XtraReports.UI.XRLabel();
            this.C_BAR1J = new DevExpress.XtraReports.UI.XRBarCode();
            this.L_COILHEAT = new DevExpress.XtraReports.UI.XRLabel();
            this.L_LOT = new DevExpress.XtraReports.UI.XRLabel();
            this.C_LOTKEY = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SUPPLIERP = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SUPPLIER = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SUPPLIER_V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_STEEL = new DevExpress.XtraReports.UI.XRLabel();
            this.L_STEEL_V = new DevExpress.XtraReports.UI.XRLabel();
            this.L_MULTI = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            //
            // TopMargin
            //
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            //
            // Detail (라벨 1장, 단위 0.1mm, 칸 테두리는 각 L_ 칸)
            //
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_FROM,
            this.L_TO,
            this.L_DESC,
            this.L_BOX2D,
            this.C_BAR2D,
            this.L_PARTNO,
            this.L_PARTNO_V,
            this.L_BAR_PARTNO,
            this.L_QTY,
            this.L_QTY_V,
            this.L_BAR_QTY,
            this.L_COILTAG,
            this.C_COILTAG,
            this.L_REV,
            this.L_REV_V,
            this.L_MFG,
            this.C_MFGDATE,
            this.L_PO,
            this.L_PO_V,
            this.L_LICENSE,
            this.C_BAR1J,
            this.L_COILHEAT,
            this.L_LOT,
            this.C_LOTKEY,
            this.L_SUPPLIERP,
            this.L_SUPPLIER,
            this.L_SUPPLIER_V,
            this.L_STEEL,
            this.L_STEEL_V,
            this.L_MULTI});
            this.Detail.HeightF = 560F;
            this.Detail.Name = "Detail";
            //
            // L_FROM (A 발송주소 고정)
            //
            this.L_FROM.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_FROM.Font = new System.Drawing.Font("맑은 고딕", 5F);
            this.L_FROM.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.L_FROM.Multiline = true;
            this.L_FROM.Name = "L_FROM";
            this.L_FROM.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_FROM.SizeF = new System.Drawing.SizeF(247F, 150F);
            this.L_FROM.StylePriority.UseBorders = false;
            this.L_FROM.StylePriority.UseFont = false;
            this.L_FROM.StylePriority.UsePadding = false;
            this.L_FROM.StylePriority.UseTextAlignment = false;
            this.L_FROM.Text = "From:\r\nS&S INC\r\n2nd Factory, 160,\r\nGwanchanggongdan-gil, Jugyo-myeon, Boryeong-si,\r\nChungcheongnam-do,\r\nRepublic of Korea";
            this.L_FROM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_TO (B 수신주소 고정)
            //
            this.L_TO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_TO.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_TO.LocationFloat = new DevExpress.Utils.PointFloat(247F, 0F);
            this.L_TO.Multiline = true;
            this.L_TO.Name = "L_TO";
            this.L_TO.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_TO.SizeF = new System.Drawing.SizeF(243F, 150F);
            this.L_TO.StylePriority.UseBorders = false;
            this.L_TO.StylePriority.UseFont = false;
            this.L_TO.StylePriority.UsePadding = false;
            this.L_TO.StylePriority.UseTextAlignment = false;
            this.L_TO.Text = "To:\r\nPullmatic Manufacturing\r\n430 Cochrane Drive\r\nUnionville ON L3R 8E3\r\nCANADA";
            this.L_TO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_DESC (C 설명 고정)
            //
            this.L_DESC.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_DESC.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_DESC.LocationFloat = new DevExpress.Utils.PointFloat(490F, 0F);
            this.L_DESC.Multiline = true;
            this.L_DESC.Name = "L_DESC";
            this.L_DESC.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_DESC.SizeF = new System.Drawing.SizeF(196F, 150F);
            this.L_DESC.StylePriority.UseBorders = false;
            this.L_DESC.StylePriority.UseFont = false;
            this.L_DESC.StylePriority.UsePadding = false;
            this.L_DESC.StylePriority.UseTextAlignment = false;
            this.L_DESC.Text = "Description:\r\nP1618 Turbine Shaft";
            this.L_DESC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_BOX2D (2D 바코드 칸 테두리)
            //
            this.L_BOX2D.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_BOX2D.LocationFloat = new DevExpress.Utils.PointFloat(686F, 0F);
            this.L_BOX2D.Name = "L_BOX2D";
            this.L_BOX2D.SizeF = new System.Drawing.SizeF(274F, 240F);
            this.L_BOX2D.StylePriority.UseBorders = false;
            //
            // C_BAR2D (G 바코드(4) PDF417)
            //
            this.C_BAR2D.AutoModule = true;
            this.C_BAR2D.LocationFloat = new DevExpress.Utils.PointFloat(696F, 10F);
            this.C_BAR2D.Name = "C_BAR2D";
            this.C_BAR2D.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_BAR2D.ShowText = false;
            this.C_BAR2D.SizeF = new System.Drawing.SizeF(254F, 220F);
            pdf417Generator1.Columns = 5;
            pdf417Generator1.Rows = 20;
            pdf417Generator1.CompactionMode = DevExpress.XtraPrinting.BarCode.PDF417CompactionMode.Text;
            pdf417Generator1.ErrorCorrectionLevel = DevExpress.XtraPrinting.BarCode.ErrorCorrectionLevel.Level2;
            this.C_BAR2D.Symbology = pdf417Generator1;
            //
            // L_PARTNO (PART NO 칸)
            //
            this.L_PARTNO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_PARTNO.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_PARTNO.LocationFloat = new DevExpress.Utils.PointFloat(0F, 150F);
            this.L_PARTNO.Name = "L_PARTNO";
            this.L_PARTNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_PARTNO.SizeF = new System.Drawing.SizeF(686F, 90F);
            this.L_PARTNO.StylePriority.UseBorders = false;
            this.L_PARTNO.StylePriority.UseFont = false;
            this.L_PARTNO.StylePriority.UsePadding = false;
            this.L_PARTNO.StylePriority.UseTextAlignment = false;
            this.L_PARTNO.Text = "PART NO: [P]";
            this.L_PARTNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_PARTNO_V
            //
            this.L_PARTNO_V.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_PARTNO_V.LocationFloat = new DevExpress.Utils.PointFloat(230F, 152F);
            this.L_PARTNO_V.Name = "L_PARTNO_V";
            this.L_PARTNO_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_PARTNO_V.SizeF = new System.Drawing.SizeF(200F, 30F);
            this.L_PARTNO_V.StylePriority.UseFont = false;
            this.L_PARTNO_V.StylePriority.UsePadding = false;
            this.L_PARTNO_V.StylePriority.UseTextAlignment = false;
            this.L_PARTNO_V.Text = "1100175";
            this.L_PARTNO_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // L_BAR_PARTNO (D 바코드(1) 고정 P1100175)
            //
            this.L_BAR_PARTNO.AutoModule = true;
            this.L_BAR_PARTNO.LocationFloat = new DevExpress.Utils.PointFloat(230F, 182F);
            this.L_BAR_PARTNO.Name = "L_BAR_PARTNO";
            this.L_BAR_PARTNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_BAR_PARTNO.ShowText = false;
            this.L_BAR_PARTNO.SizeF = new System.Drawing.SizeF(420F, 52F);
            this.L_BAR_PARTNO.Symbology = code128Generator1;
            this.L_BAR_PARTNO.Text = "P1100175";
            //
            // L_QTY (Quantity 칸)
            //
            this.L_QTY.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_QTY.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_QTY.LocationFloat = new DevExpress.Utils.PointFloat(0F, 240F);
            this.L_QTY.Name = "L_QTY";
            this.L_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_QTY.SizeF = new System.Drawing.SizeF(339F, 95F);
            this.L_QTY.StylePriority.UseBorders = false;
            this.L_QTY.StylePriority.UseFont = false;
            this.L_QTY.StylePriority.UsePadding = false;
            this.L_QTY.StylePriority.UseTextAlignment = false;
            this.L_QTY.Text = "Quantity: [Q]";
            this.L_QTY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_QTY_V
            //
            this.L_QTY_V.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.L_QTY_V.LocationFloat = new DevExpress.Utils.PointFloat(170F, 242F);
            this.L_QTY_V.Name = "L_QTY_V";
            this.L_QTY_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_QTY_V.SizeF = new System.Drawing.SizeF(120F, 30F);
            this.L_QTY_V.StylePriority.UseFont = false;
            this.L_QTY_V.StylePriority.UsePadding = false;
            this.L_QTY_V.StylePriority.UseTextAlignment = false;
            this.L_QTY_V.Text = "300";
            this.L_QTY_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // L_BAR_QTY (E 바코드(2) 고정 Q300)
            //
            this.L_BAR_QTY.AutoModule = true;
            this.L_BAR_QTY.LocationFloat = new DevExpress.Utils.PointFloat(20F, 274F);
            this.L_BAR_QTY.Name = "L_BAR_QTY";
            this.L_BAR_QTY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_BAR_QTY.ShowText = false;
            this.L_BAR_QTY.SizeF = new System.Drawing.SizeF(300F, 55F);
            this.L_BAR_QTY.Symbology = code128Generator2;
            this.L_BAR_QTY.Text = "Q300";
            //
            // L_COILTAG (Coil Tag 칸)
            //
            this.L_COILTAG.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_COILTAG.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_COILTAG.LocationFloat = new DevExpress.Utils.PointFloat(339F, 240F);
            this.L_COILTAG.Name = "L_COILTAG";
            this.L_COILTAG.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.L_COILTAG.SizeF = new System.Drawing.SizeF(347F, 95F);
            this.L_COILTAG.StylePriority.UseBorders = false;
            this.L_COILTAG.StylePriority.UseFont = false;
            this.L_COILTAG.StylePriority.UsePadding = false;
            this.L_COILTAG.StylePriority.UseTextAlignment = false;
            this.L_COILTAG.Text = "Coil Tag [T]:";
            this.L_COILTAG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // C_COILTAG (H 생산LOT번호)
            //
            this.C_COILTAG.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.C_COILTAG.LocationFloat = new DevExpress.Utils.PointFloat(470F, 245F);
            this.C_COILTAG.Name = "C_COILTAG";
            this.C_COILTAG.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_COILTAG.SizeF = new System.Drawing.SizeF(210F, 85F);
            this.C_COILTAG.StylePriority.UseFont = false;
            this.C_COILTAG.StylePriority.UsePadding = false;
            this.C_COILTAG.StylePriority.UseTextAlignment = false;
            this.C_COILTAG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // L_REV (Rev Level 칸)
            //
            this.L_REV.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_REV.Font = new System.Drawing.Font("맑은 고딕", 5F);
            this.L_REV.LocationFloat = new DevExpress.Utils.PointFloat(686F, 240F);
            this.L_REV.Name = "L_REV";
            this.L_REV.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 254F);
            this.L_REV.SizeF = new System.Drawing.SizeF(137F, 160F);
            this.L_REV.StylePriority.UseBorders = false;
            this.L_REV.StylePriority.UseFont = false;
            this.L_REV.StylePriority.UsePadding = false;
            this.L_REV.StylePriority.UseTextAlignment = false;
            this.L_REV.Text = "Rev Level: [R]";
            this.L_REV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            //
            // L_REV_V
            //
            this.L_REV_V.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.L_REV_V.LocationFloat = new DevExpress.Utils.PointFloat(686F, 270F);
            this.L_REV_V.Name = "L_REV_V";
            this.L_REV_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_REV_V.SizeF = new System.Drawing.SizeF(137F, 45F);
            this.L_REV_V.StylePriority.UseFont = false;
            this.L_REV_V.StylePriority.UsePadding = false;
            this.L_REV_V.StylePriority.UseTextAlignment = false;
            this.L_REV_V.Text = "00";
            this.L_REV_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // L_MFG
            //
            this.L_MFG.Font = new System.Drawing.Font("맑은 고딕", 5F);
            this.L_MFG.LocationFloat = new DevExpress.Utils.PointFloat(696F, 315F);
            this.L_MFG.Name = "L_MFG";
            this.L_MFG.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_MFG.SizeF = new System.Drawing.SizeF(120F, 25F);
            this.L_MFG.StylePriority.UseFont = false;
            this.L_MFG.StylePriority.UsePadding = false;
            this.L_MFG.StylePriority.UseTextAlignment = false;
            this.L_MFG.Text = "Mfg :";
            this.L_MFG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // C_MFGDATE (L 생산일자 DDMonYY)
            //
            this.C_MFGDATE.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.C_MFGDATE.LocationFloat = new DevExpress.Utils.PointFloat(692F, 342F);
            this.C_MFGDATE.Name = "C_MFGDATE";
            this.C_MFGDATE.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_MFGDATE.SizeF = new System.Drawing.SizeF(128F, 52F);
            this.C_MFGDATE.StylePriority.UseFont = false;
            this.C_MFGDATE.StylePriority.UsePadding = false;
            this.C_MFGDATE.StylePriority.UseTextAlignment = false;
            this.C_MFGDATE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // L_PO (PO 칸)
            //
            this.L_PO.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_PO.Font = new System.Drawing.Font("맑은 고딕", 5F);
            this.L_PO.LocationFloat = new DevExpress.Utils.PointFloat(823F, 240F);
            this.L_PO.Name = "L_PO";
            this.L_PO.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 254F);
            this.L_PO.SizeF = new System.Drawing.SizeF(137F, 160F);
            this.L_PO.StylePriority.UseBorders = false;
            this.L_PO.StylePriority.UseFont = false;
            this.L_PO.StylePriority.UsePadding = false;
            this.L_PO.StylePriority.UseTextAlignment = false;
            this.L_PO.Text = "PO: [K]";
            this.L_PO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            //
            // L_PO_V (M 고정 5400006680)
            //
            this.L_PO_V.Font = new System.Drawing.Font("맑은 고딕", 5.5F);
            this.L_PO_V.LocationFloat = new DevExpress.Utils.PointFloat(823F, 285F);
            this.L_PO_V.Name = "L_PO_V";
            this.L_PO_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_PO_V.SizeF = new System.Drawing.SizeF(137F, 30F);
            this.L_PO_V.StylePriority.UseFont = false;
            this.L_PO_V.StylePriority.UsePadding = false;
            this.L_PO_V.StylePriority.UseTextAlignment = false;
            this.L_PO_V.Text = "5400006680";
            this.L_PO_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // L_LICENSE (License Plate 칸)
            //
            this.L_LICENSE.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_LICENSE.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_LICENSE.LocationFloat = new DevExpress.Utils.PointFloat(0F, 335F);
            this.L_LICENSE.Name = "L_LICENSE";
            this.L_LICENSE.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_LICENSE.SizeF = new System.Drawing.SizeF(339F, 130F);
            this.L_LICENSE.StylePriority.UseBorders = false;
            this.L_LICENSE.StylePriority.UseFont = false;
            this.L_LICENSE.StylePriority.UsePadding = false;
            this.L_LICENSE.StylePriority.UseTextAlignment = false;
            this.L_LICENSE.Text = "License Plate: (1J)";
            this.L_LICENSE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // C_BAR1J (F 바코드(3) 1J + 600612 + 00 + 생산실적번호 + 1)
            //
            this.C_BAR1J.AutoModule = true;
            this.C_BAR1J.Font = new System.Drawing.Font("맑은 고딕", 5F);
            this.C_BAR1J.LocationFloat = new DevExpress.Utils.PointFloat(15F, 368F);
            this.C_BAR1J.Name = "C_BAR1J";
            this.C_BAR1J.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_BAR1J.SizeF = new System.Drawing.SizeF(310F, 92F);
            this.C_BAR1J.StylePriority.UseFont = false;
            this.C_BAR1J.StylePriority.UsePadding = false;
            this.C_BAR1J.StylePriority.UseTextAlignment = false;
            this.C_BAR1J.Symbology = code128Generator3;
            this.C_BAR1J.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            //
            // L_COILHEAT (Coil Heat 칸)
            //
            this.L_COILHEAT.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_COILHEAT.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_COILHEAT.LocationFloat = new DevExpress.Utils.PointFloat(339F, 335F);
            this.L_COILHEAT.Name = "L_COILHEAT";
            this.L_COILHEAT.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_COILHEAT.SizeF = new System.Drawing.SizeF(347F, 130F);
            this.L_COILHEAT.StylePriority.UseBorders = false;
            this.L_COILHEAT.StylePriority.UseFont = false;
            this.L_COILHEAT.StylePriority.UsePadding = false;
            this.L_COILHEAT.StylePriority.UseTextAlignment = false;
            this.L_COILHEAT.Text = "Coil Heat:";
            this.L_COILHEAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_LOT
            //
            this.L_LOT.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_LOT.LocationFloat = new DevExpress.Utils.PointFloat(350F, 395F);
            this.L_LOT.Name = "L_LOT";
            this.L_LOT.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_LOT.SizeF = new System.Drawing.SizeF(70F, 45F);
            this.L_LOT.StylePriority.UseFont = false;
            this.L_LOT.StylePriority.UsePadding = false;
            this.L_LOT.StylePriority.UseTextAlignment = false;
            this.L_LOT.Text = "LOT :";
            this.L_LOT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // C_LOTKEY (I 생산LOT번호)
            //
            this.C_LOTKEY.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.C_LOTKEY.LocationFloat = new DevExpress.Utils.PointFloat(420F, 395F);
            this.C_LOTKEY.Name = "C_LOTKEY";
            this.C_LOTKEY.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.C_LOTKEY.SizeF = new System.Drawing.SizeF(260F, 45F);
            this.C_LOTKEY.StylePriority.UseFont = false;
            this.C_LOTKEY.StylePriority.UsePadding = false;
            this.C_LOTKEY.StylePriority.UseTextAlignment = false;
            this.C_LOTKEY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            //
            // L_SUPPLIERP (Supplier P# 칸)
            //
            this.L_SUPPLIERP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_SUPPLIERP.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_SUPPLIERP.LocationFloat = new DevExpress.Utils.PointFloat(686F, 400F);
            this.L_SUPPLIERP.Name = "L_SUPPLIERP";
            this.L_SUPPLIERP.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_SUPPLIERP.SizeF = new System.Drawing.SizeF(274F, 65F);
            this.L_SUPPLIERP.StylePriority.UseBorders = false;
            this.L_SUPPLIERP.StylePriority.UseFont = false;
            this.L_SUPPLIERP.StylePriority.UsePadding = false;
            this.L_SUPPLIERP.StylePriority.UseTextAlignment = false;
            this.L_SUPPLIERP.Text = "Supplier P#";
            this.L_SUPPLIERP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_SUPPLIER (Supplier 칸)
            //
            this.L_SUPPLIER.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_SUPPLIER.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_SUPPLIER.LocationFloat = new DevExpress.Utils.PointFloat(0F, 465F);
            this.L_SUPPLIER.Name = "L_SUPPLIER";
            this.L_SUPPLIER.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_SUPPLIER.SizeF = new System.Drawing.SizeF(284F, 95F);
            this.L_SUPPLIER.StylePriority.UseBorders = false;
            this.L_SUPPLIER.StylePriority.UseFont = false;
            this.L_SUPPLIER.StylePriority.UsePadding = false;
            this.L_SUPPLIER.StylePriority.UseTextAlignment = false;
            this.L_SUPPLIER.Text = "Supplier: [V]";
            this.L_SUPPLIER.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_SUPPLIER_V (J 공급자번호 고정 600612)
            //
            this.L_SUPPLIER_V.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.L_SUPPLIER_V.LocationFloat = new DevExpress.Utils.PointFloat(0F, 500F);
            this.L_SUPPLIER_V.Name = "L_SUPPLIER_V";
            this.L_SUPPLIER_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_SUPPLIER_V.SizeF = new System.Drawing.SizeF(284F, 55F);
            this.L_SUPPLIER_V.StylePriority.UseFont = false;
            this.L_SUPPLIER_V.StylePriority.UsePadding = false;
            this.L_SUPPLIER_V.StylePriority.UseTextAlignment = false;
            this.L_SUPPLIER_V.Text = "600612";
            this.L_SUPPLIER_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // L_STEEL (Steel Supplier 칸)
            //
            this.L_STEEL.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_STEEL.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_STEEL.LocationFloat = new DevExpress.Utils.PointFloat(284F, 465F);
            this.L_STEEL.Name = "L_STEEL";
            this.L_STEEL.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_STEEL.SizeF = new System.Drawing.SizeF(402F, 95F);
            this.L_STEEL.StylePriority.UseBorders = false;
            this.L_STEEL.StylePriority.UseFont = false;
            this.L_STEEL.StylePriority.UsePadding = false;
            this.L_STEEL.StylePriority.UseTextAlignment = false;
            this.L_STEEL.Text = "Steel Supplier:";
            this.L_STEEL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // L_STEEL_V (K 공급자명 고정 SeAH Besteel)
            //
            this.L_STEEL_V.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.L_STEEL_V.LocationFloat = new DevExpress.Utils.PointFloat(284F, 500F);
            this.L_STEEL_V.Name = "L_STEEL_V";
            this.L_STEEL_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.L_STEEL_V.SizeF = new System.Drawing.SizeF(402F, 55F);
            this.L_STEEL_V.StylePriority.UseFont = false;
            this.L_STEEL_V.StylePriority.UsePadding = false;
            this.L_STEEL_V.StylePriority.UseTextAlignment = false;
            this.L_STEEL_V.Text = "SeAH Besteel";
            this.L_STEEL_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            //
            // L_MULTI (Multi # 칸)
            //
            this.L_MULTI.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.L_MULTI.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.L_MULTI.LocationFloat = new DevExpress.Utils.PointFloat(686F, 465F);
            this.L_MULTI.Name = "L_MULTI";
            this.L_MULTI.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 3, 0, 254F);
            this.L_MULTI.SizeF = new System.Drawing.SizeF(274F, 95F);
            this.L_MULTI.StylePriority.UseBorders = false;
            this.L_MULTI.StylePriority.UseFont = false;
            this.L_MULTI.StylePriority.UsePadding = false;
            this.L_MULTI.StylePriority.UseTextAlignment = false;
            this.L_MULTI.Text = "Multi #";
            this.L_MULTI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            //
            // BottomMargin
            //
            this.BottomMargin.HeightF = 20F;
            this.BottomMargin.Name = "BottomMargin";
            //
            // PRD_2 (100 x 60 mm, 단위 0.1mm)
            //
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.Detail,
            this.BottomMargin});
            this.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.PageHeight = 600;
            this.PageWidth = 1000;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 10F;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel L_FROM;
        private DevExpress.XtraReports.UI.XRLabel L_TO;
        private DevExpress.XtraReports.UI.XRLabel L_DESC;
        private DevExpress.XtraReports.UI.XRLabel L_BOX2D;
        private DevExpress.XtraReports.UI.XRBarCode C_BAR2D;
        private DevExpress.XtraReports.UI.XRLabel L_PARTNO;
        private DevExpress.XtraReports.UI.XRLabel L_PARTNO_V;
        private DevExpress.XtraReports.UI.XRBarCode L_BAR_PARTNO;
        private DevExpress.XtraReports.UI.XRLabel L_QTY;
        private DevExpress.XtraReports.UI.XRLabel L_QTY_V;
        private DevExpress.XtraReports.UI.XRBarCode L_BAR_QTY;
        private DevExpress.XtraReports.UI.XRLabel L_COILTAG;
        private DevExpress.XtraReports.UI.XRLabel C_COILTAG;
        private DevExpress.XtraReports.UI.XRLabel L_REV;
        private DevExpress.XtraReports.UI.XRLabel L_REV_V;
        private DevExpress.XtraReports.UI.XRLabel L_MFG;
        private DevExpress.XtraReports.UI.XRLabel C_MFGDATE;
        private DevExpress.XtraReports.UI.XRLabel L_PO;
        private DevExpress.XtraReports.UI.XRLabel L_PO_V;
        private DevExpress.XtraReports.UI.XRLabel L_LICENSE;
        private DevExpress.XtraReports.UI.XRBarCode C_BAR1J;
        private DevExpress.XtraReports.UI.XRLabel L_COILHEAT;
        private DevExpress.XtraReports.UI.XRLabel L_LOT;
        private DevExpress.XtraReports.UI.XRLabel C_LOTKEY;
        private DevExpress.XtraReports.UI.XRLabel L_SUPPLIERP;
        private DevExpress.XtraReports.UI.XRLabel L_SUPPLIER;
        private DevExpress.XtraReports.UI.XRLabel L_SUPPLIER_V;
        private DevExpress.XtraReports.UI.XRLabel L_STEEL;
        private DevExpress.XtraReports.UI.XRLabel L_STEEL_V;
        private DevExpress.XtraReports.UI.XRLabel L_MULTI;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    }
}
