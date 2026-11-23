using System;
using System.Drawing;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-16 [외주입고] 공정이동표(입고) 양품 + 공정이동표(시편). 입고한 LOT 1개당 양품 1장, 시편수량이 있으면 시편 1장 더 (A4 세로, 한 장에 LOT 1개)
    /// dt = TML1020_R01 ADD_MTRIN 결과 Tables[0]
    ///      (ITEMCD, ITEMNM, ITEMSPEC, HEATNO, OUTWARENM, INWARENM, TESTWARENM, EMPNM, INDATE, REGTIME, PRINTTIME, LOTKEY, UNITNM, GOODQTY, TESTQTY)
    /// // 2026-11-19 양식은 MTR_3.Designer.cs (디자이너)에 있다. 여기는 데이터 연결만 (Detail 밴드 1개 = 이동표 1장). 양품 → 시편 순으로 LOT 마다 이어서 나옴
    /// </summary>
    public partial class MTR_3 : XtraReport
    {
        // VS 리포트 디자이너가 열 수 있게 매개변수 없는 생성자를 둔다
        public MTR_3()
        {
            InitializeComponent();
        }

        public MTR_3(DataTable dt) : this()
        {
            this.DataSource = BuildSheets(dt);
        }

        // LOT 1개 → 양품 1장(수량 있으면) + 시편 1장(수량 있으면)
        private DataTable BuildSheets(DataTable dt)
        {
            DataTable sheets = new DataTable();
            foreach (string col in new string[] { "TITLE", "ITEMCD", "ITEMNM", "ITEMSPEC", "HEATNO", "OUTWARENM", "INWARENM", "INDATE", "EMPNM", "REGTIME", "STAMP", "LOTKEY", "UNITNM", "QTY" })
            {
                sheets.Columns.Add(col, typeof(string));
            }

            foreach (DataRow r in dt.Rows)
            {
                decimal good = ToDec(r["GOODQTY"]);
                decimal test = ToDec(r["TESTQTY"]);
                if (good > 0) AddSheet(sheets, r, "공 정 이 동 표(입고)", r["INWARENM"], good);
                if (test > 0) AddSheet(sheets, r, "공 정 이 동 표(시편)", r["TESTWARENM"], test);
            }
            return sheets;
        }

        private void AddSheet(DataTable sheets, DataRow r, string title, object inWare, decimal qty)
        {
            DataRow s = sheets.NewRow();
            s["TITLE"] = title;
            s["ITEMCD"] = Str(r["ITEMCD"]);
            s["ITEMNM"] = Str(r["ITEMNM"]);
            s["ITEMSPEC"] = Str(r["ITEMSPEC"]);
            s["HEATNO"] = Str(r["HEATNO"]);
            s["OUTWARENM"] = Str(r["OUTWARENM"]);
            s["INWARENM"] = Str(inWare);
            s["INDATE"] = Str(r["INDATE"]);
            s["EMPNM"] = Str(r["EMPNM"]);
            s["REGTIME"] = Str(r["REGTIME"]);
            s["STAMP"] = Str(r["EMPNM"]) + " " + Str(r["PRINTTIME"]);
            s["LOTKEY"] = Str(r["LOTKEY"]);
            s["UNITNM"] = Str(r["UNITNM"]);
            s["QTY"] = RptKit.Qty(qty);
            sheets.Rows.Add(s);
        }

        private static string Str(object v)
        {
            return (v == null || v == DBNull.Value) ? "" : v.ToString();
        }

        private static decimal ToDec(object v)
        {
            decimal d;
            if (v == null || v == DBNull.Value || !decimal.TryParse(v.ToString(), out d)) return 0;
            return d;
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄
        public void PrintDirect(string printerName)
        {
            RptKit.PrintDirect(this, printerName);
        }
    }
}
