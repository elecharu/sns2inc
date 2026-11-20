using System;
using System.Drawing;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-16 [사업장 간 이동] 재고이동표 (A4 가로 1장, LOT 줄이 많으면 이어서)
    /// ds = TML1020_R03 ADD_MOVE 결과
    ///   Tables[1] 머리글 1행 (MOVEDATE, EMPNM, OUTNM 출고 공장(창고), INNM 입고 공장(창고))
    ///   Tables[2] LOT 목록 (LOTKEY, ITEMCD, ITEMNM, ITEMSPEC, HEATNO, UNITNM, MOVEQTY)
    /// // 2026-11-19 양식은 MTR_5.Designer.cs (디자이너)에 있다. 여기는 머리글·합계 값 채우기와 LOT 목록 연결만
    /// </summary>
    public partial class MTR_5 : XtraReport
    {
        public MTR_5(DataSet ds)
        {
            DataRow hd = ds.Tables[1].Rows[0];
            DataTable lots = ds.Tables[2];

            InitializeComponent();

            // 이동일자·등록자 / 출고 공장·입고 공장
            tblInfo.Rows[0].Cells[1].Text = S(hd, "MOVEDATE");
            tblInfo.Rows[1].Cells[1].Text = S(hd, "EMPNM");
            tblFac.Rows[0].Cells[1].Text = S(hd, "OUTNM");
            tblFac.Rows[0].Cells[3].Text = S(hd, "INNM");

            // 칸 이름 줄의 이동량 단위
            string unit = lots.Rows.Count > 0 ? S(lots.Rows[0], "UNITNM") : "";
            if (unit == "") unit = "EA";
            tblColHead.Rows[0].Cells[6].Text = "이동량(" + unit + ")";

            // 맨 아래 : 총 이동량
            decimal total = 0;
            foreach (DataRow r in lots.Rows)
            {
                decimal q;
                if (decimal.TryParse(S(r, "MOVEQTY"), out q)) total += q;
            }
            tblSum.Rows[0].Cells[2].Text = RptKit.Qty(total);

            // LOT 목록 (GRP = 칸 이름 줄을 쪽마다 되풀이하기 위한 묶음 값, NO = 순번)
            DataTable data = new DataTable();
            foreach (string col in new string[] { "GRP", "NO", "LOTKEY", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "QTY" }) data.Columns.Add(col, typeof(string));
            int no = 0;
            foreach (DataRow r in lots.Rows)
            {
                DataRow d = data.NewRow();
                d["GRP"] = "1";
                d["NO"] = (++no).ToString();
                foreach (string col in new string[] { "LOTKEY", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO" }) d[col] = S(r, col);
                d["QTY"] = RptKit.Qty(r["MOVEQTY"]);
                data.Rows.Add(d);
            }
            this.DataSource = data;
        }

        private static string S(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col)) return "";
            object v = r[col];
            return (v == null || v == DBNull.Value) ? "" : v.ToString();
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄
        public void PrintDirect(string printerName)
        {
            RptKit.PrintDirect(this, printerName);
        }
    }
}
