using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-16 [외주반출] 외주반출증 + 발주서 2장 / [외주재작업반출] 외주반출증(재작업) 공급자 보관용 + 공급받는자 보관용 2장 (A4 세로)
    /// ds = TML1020_R02 / R04 ADD_MOVE 결과
    ///   Tables[1] 머리글 1행 (MOVENO, MOVEDATE, EMPNM,
    ///             S* = S&amp;S INC 2공장 : SNM, SPRES, SNUM, SADDR, STEL, SFAX, STYPE, SKIND
    ///             C* = 외주처       : CNM, CPRES, CNUM, CADDR, CTEL, CFAX, CTYPE, CKIND)
    ///   Tables[2] LOT 목록 (ITEMCD, ITEMNM, ITEMSPEC, HEATNO, LOTKEY, QTY, QTYNUM)
    /// // 2026-11-19 양식은 MTR_4.Designer.cs (디자이너)에 있다. 여기는 제목·당사자·합계 값 채우기와 LOT 목록 연결만.
    /// 한 부(MTR_4 1개)가 한 장 양식이고, Print 가 두 부를 이어서 한 번에 인쇄한다
    /// </summary>
    public partial class MTR_4 : XtraReport
    {
        // 한 부. left/right = 왼쪽/오른쪽 당사자 표시 (leftIsSupplier : 왼쪽이 S&S 인지)
        private MTR_4(DataRow hd, DataTable lots, string title, float titleSize, string sub, bool leftIsSupplier, string leftLabel, string rightLabel)
        {
            InitializeComponent();

            // ----- 머리글 : 제목·부 표시·번호 + 공급자/공급받는자 -----
            lblTitle.Text = title;
            lblTitle.Font = new Font(RptKit.FONT, titleSize);
            lblSub.Text = sub;
            picLogo.Image = RptKit.FitImage(RptKit.Logo(), picLogo.WidthF, picLogo.HeightF);  // 2026-11-26 화면 배율 PC 에서 로고 잘림 방지

            tblNo.Rows[0].Cells[1].Text = S(hd, "MOVEDATE");
            tblNo.Rows[1].Cells[1].Text = S(hd, "MOVENO");
            tblNo.Rows[2].Cells[1].Text = S(hd, "EMPNM");

            // 왼쪽 당사자 / 오른쪽 당사자
            string lp = leftIsSupplier ? "S" : "C";
            string rp = leftIsSupplier ? "C" : "S";
            lblLeftSide.Text = vertical(leftLabel);
            lblRightSide.Text = vertical(rightLabel);
            FillParty(tblLeftMain, tblLeftSub, hd, lp);
            FillParty(tblRightMain, tblRightSub, hd, rp);

            // ----- 맨 아래 : 총 수량 -----
            decimal total = 0;
            foreach (DataRow r in lots.Rows)
            {
                decimal q;
                if (decimal.TryParse(S(r, "QTYNUM"), out q)) total += q;
            }
            tblSum.Rows[0].Cells[1].Text = RptKit.Qty(total);

            // LOT 목록 (GRP = 칸 이름 줄을 쪽마다 되풀이하기 위한 묶음 값)
            DataTable data = new DataTable();
            foreach (string col in new string[] { "GRP", "LOTKEY", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "QTY" }) data.Columns.Add(col, typeof(string));
            foreach (DataRow r in lots.Rows)
            {
                DataRow d = data.NewRow();
                d["GRP"] = "1";
                foreach (string col in new string[] { "LOTKEY", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "QTY" }) d[col] = S(r, col);
                data.Rows.Add(d);
            }
            this.DataSource = data;
        }

        // 공급자/공급받는자 한쪽 칸 값 : 상호·대표·등록번호·주소 / 대표전화·대표팩스 / 업태·업종
        private void FillParty(XRTable main, XRTable sub, DataRow hd, string p)
        {
            string[] f1 = { "NM", "PRES", "NUM", "ADDR" };
            for (int i = 0; i < 4; i++)
            {
                main.Rows[i].Cells[1].Text = S(hd, p + f1[i]);
            }
            sub.Rows[0].Cells[1].Text = S(hd, p + "TEL");
            sub.Rows[0].Cells[3].Text = S(hd, p + "FAX");
            sub.Rows[1].Cells[1].Text = S(hd, p + "TYPE");
            sub.Rows[1].Cells[3].Text = S(hd, p + "KIND");
        }

        // "공급자" → "공\r\n급\r\n자"
        private static string vertical(string text)
        {
            string[] ch = new string[text.Length];
            for (int i = 0; i < text.Length; i++) ch[i] = text[i].ToString();
            return string.Join("\r\n", ch);
        }

        private static string S(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col)) return "";
            object v = r[col];
            return (v == null || v == DBNull.Value) ? "" : v.ToString();
        }

        // 두 부를 이어 붙인 문서 (rework = false : 외주반출증 + 발주서 / true : 외주반출증(재작업) 공급자 보관용 + 공급받는자 보관용)
        public static XtraReport Merge(DataSet ds, bool rework)
        {
            DataRow hd = ds.Tables[1].Rows[0];
            DataTable lots = ds.Tables[2];

            MTR_4 first, second;
            if (!rework)
            {
                first = new MTR_4(hd, lots, "외 주 반 출 증", 26F, "(공급자보관용)", true, "공급자", "공급받는자");
                second = new MTR_4(hd, lots, "발 주 서", 26F, "(발주처용)", false, "거래처", "발주처");
            }
            else
            {
                first = new MTR_4(hd, lots, "외 주 반 출 증 ( 재 작 업 )", 20F, "(공급자 보관용)", true, "공급자", "공급받는자");
                second = new MTR_4(hd, lots, "외 주 반 출 증 ( 재 작 업 )", 20F, "(공급받는자 보관용)", false, "공급받는자", "공급자");
            }

            first.CreateDocument();
            second.CreateDocument();
            first.Pages.AddRange(second.Pages);
            return first;
        }

        // 확인창·미리보기 없이 지정한 프린터로 두 장 바로 인쇄
        public static void Print(DataSet ds, bool rework, string printerName)
        {
            XtraReport doc = Merge(ds, rework);
            doc.ShowPrintMarginsWarning = false;
            doc.ShowPrintStatusDialog = false;
            PrintToolBase tool = new PrintToolBase(doc.PrintingSystem);
            tool.Print(printerName);
        }
    }
}
