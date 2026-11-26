using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-10 [출하등록] 거래명세서 (출고부서용, A4 세로). 납품처 1곳 = 1부, 품목은 LOT 1개 = 1줄 (한 장에 18줄, 넘으면 다음 장)
    /// ds = TML5000_R01 PRINT_SALOUT 결과
    ///      Tables[0] 공급자 (BDVNM, BNAME, BNUM, ADDR, TEL, FAX, ITYPE, IKIND)
    ///      Tables[1] 공급받는자 (COMPNAME, PRES, BUSNM, ADDR, TEL, FAX, DTYPE, DKIND, SALTIME, EMPNM)
    ///      Tables[2] 품목 (ITEMCD, ITEMNM, ITEMSPEC, OUTQTY, BOX, BOXNM, REMARK)
    ///      Tables[3] 총 수량·출하번호 (SUMQTY, GROUPKEY, INVOICEKEY, REMARK, SUBTITLE 유상사급이면 "(유상사급)")
    ///      // 2026-11-19 바닥 출하번호는 GROUPKEY 대신 INVOICEKEY(거래명세서키) 표시
    /// // 2026-11-19 양식은 고객사 출하 거래명세서 PDF 와 같게 (품목 16줄, 바닥 줄이 품목 표에 붙음). 출고부서용·공급받는자용 2부 (생성자 copyName)
    /// // 2026-11-19 양식은 SAL_1.Designer.cs (디자이너)에 있다 (PageHeader = 제목·공급자·공급받는자·품목 머리글, Detail = 품목 1줄, PageFooter = 출하번호·총 수량).
    /// 여기는 머리글·바닥 값 채우기와 품목 목록 연결만
    /// </summary>
    public partial class SAL_1 : XtraReport
    {
        const int ROWS_PER_PAGE = 16;  // 한 장에 품목 줄 수 (양식 PDF 와 같게 16줄)

        // 기본은 출고부서용. 공급받는자용은 SAL_1(ds, "공급받는자용") 로 한 번 더 만든다 (제목 옆 괄호 글자만 다름)
        public SAL_1(DataSet ds) : this(ds, "출고부서용") { }

        public SAL_1(DataSet ds, string copyName)
        {
            DataRow supplier = ds.Tables[0].Rows[0];
            DataRow buyer = ds.Tables[1].Rows[0];
            DataRow total = ds.Tables[3].Rows[0];

            InitializeComponent();

            picLogo.Image = RptKit.FitImage(LoadLogo(), picLogo.WidthF, picLogo.HeightF);  // 2026-11-26 화면 배율 PC 에서 로고 잘림 방지

            // 유상사급 출하는 제목 아래에 (유상사급) 표시 (Tables[3] SUBTITLE, 고객사 출하는 빈값)
            xrLabel3.Text = "(" + copyName + ")";
            lblSub.Text = Str(total, "SUBTITLE");
            if (lblSub.Text != "") { xrLabel2.HeightF = 56F; xrLabel3.HeightF = 56F; }  // (유상사급) 줄이 들어갈 자리

            // 거래일자·담당자
            tblInfo.Rows[0].Cells[1].Text = Date(buyer, "SALTIME");
            tblInfo.Rows[1].Cells[1].Text = Str(buyer, "EMPNM");

            // 공급자 / 공급받는자
            FillParty(tblSupplierMain, tblSupplierSub, supplier, "BDVNM", "BNAME", "BNUM", "ADDR", "TEL", "FAX", "ITYPE", "IKIND");
            FillParty(tblBuyerMain, tblBuyerSub, buyer, "COMPNAME", "PRES", "BUSNM", "ADDR", "TEL", "FAX", "DTYPE", "DKIND");

            // 바닥 : 출하번호·총 수량·비고 (출하번호 = 거래명세서키 INVOICEKEY, 없는 예전 출하는 빈칸)
            tblBottom.Rows[0].Cells[1].Text = Str(total, "INVOICEKEY");
            tblBottom.Rows[0].Cells[3].Text = Str(total, "SUMQTY");
            tblBottom.Rows[0].Cells[5].Text = Str(total, "REMARK");

            // 품목 : LOT 1개 = 1줄, 한 장 18줄이 되게 빈 줄로 채움
            DataTable items = ds.Tables[2].Copy();
            int blank = (ROWS_PER_PAGE - (items.Rows.Count % ROWS_PER_PAGE)) % ROWS_PER_PAGE;
            if (items.Rows.Count == 0) blank = ROWS_PER_PAGE;
            for (int i = 0; i < blank; i++)
            {
                DataRow row = items.NewRow();
                foreach (DataColumn col in items.Columns) row[col] = DBNull.Value;
                items.Rows.Add(row);
            }
            this.DataSource = items;
        }

        // 공급자·공급받는자 한쪽 값 : 상호/대표/등록번호/주소 + 대표전화·팩스 + 업태·업종
        private void FillParty(XRTable main, XRTable sub, DataRow row,
                               string nm, string pres, string num, string addr, string tel, string fax, string type, string kind)
        {
            main.Rows[0].Cells[1].Text = Str(row, nm);
            main.Rows[1].Cells[1].Text = Str(row, pres);
            main.Rows[2].Cells[1].Text = Str(row, num);
            main.Rows[3].Cells[1].Text = Str(row, addr);
            sub.Rows[0].Cells[1].Text = Str(row, tel);
            sub.Rows[0].Cells[3].Text = Str(row, fax);
            sub.Rows[1].Cells[1].Text = Str(row, type);
            sub.Rows[1].Cells[3].Text = Str(row, kind);
        }

        // 로고 : 거래명세서(MTR_1_DOC) 양식의 S&S INC 로고 이미지를 그대로 씀
        private static Image LoadLogo()
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MTR_1_DOC));
                return resources.GetObject("xrPictureBox1.Image") as Image;
            }
            catch
            {
                return null;
            }
        }

        private static string Str(DataRow row, string col)
        {
            return row.Table.Columns.Contains(col) && !row.IsNull(col) ? row[col].ToString() : "";
        }

        // 2026-11-10 00:00:00 → 2026-11-10
        private static string Date(DataRow row, string col)
        {
            string s = Str(row, col);
            return s.Length > 10 ? s.Substring(0, 10) : s;
        }

        // 2026-11-23 출고부서용·공급받는자용 2부를 문서 하나로 합쳐 한 번에 인쇄 (인쇄작업 1개, 확인창·미리보기 없음)
        public static void PrintDirect(DataSet ds, string printerName)
        {
            SAL_1 first = new SAL_1(ds, "출고부서용");
            SAL_1 second = new SAL_1(ds, "공급받는자용");

            first.ShowPrintMarginsWarning = false;
            first.ShowPrintStatusDialog = false;
            first.CreateDocument();
            second.CreateDocument();
            first.Pages.AddRange(second.Pages);

            PrintToolBase tool = new PrintToolBase(first.PrintingSystem);
            tool.Print(printerName);
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄 (한 부만)
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
