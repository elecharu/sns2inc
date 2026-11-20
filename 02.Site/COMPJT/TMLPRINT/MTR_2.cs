using System;
using System.Drawing;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-09 [유상사급 납품등록] 공정이동표(재고). LOT(BOX) 1개당 1장, A4 세로 한 장에 1개 (2026-11-19 가로 → 세로)
    /// ds = TML1010_R01 PRINT_INVOICE 결과 Tables[4]
    ///      (ITEMCD, ITEMNM, ITEMSPEC, HEATNO, EMPNM, PRINTDATE, LOTKEY, UNITNM, LOTQTY)
    /// // 2026-11-19 양식은 MTR_2.Designer.cs (디자이너)에 있다. 여기는 데이터 연결만 (Detail 밴드 1개 = 이동표 1장, LOT 마다 페이지 나눔)
    /// </summary>
    public partial class MTR_2 : XtraReport
    {
        // VS 리포트 디자이너가 열 수 있게 매개변수 없는 생성자를 둔다 (디자이너는 이 생성자로 양식을 그린다)
        public MTR_2()
        {
            InitializeComponent();
        }

        public MTR_2(DataTable dt) : this()
        {
            this.DataSource = dt;
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄
        public void PrintDirect(string printerName)
        {
            this.ShowPrintMarginsWarning = false;
            this.ShowPrintStatusDialog = false;
            this.CreateDocument();
            PrintToolBase tool = new PrintToolBase(this.PrintingSystem);
            tool.Print(printerName);
        }
    }
}
