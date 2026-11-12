// 2026-11-10 [CLAIM 통보서] 협력사 클레임등록(TQM3001_R01)에서 선택한 협력사·발생월의 클레임 (세로 A4 2장)
// 양식은 R01.Designer.cs (디자이너에서 보임). 1장 공문서, 2장 산출내역서.
// 여기서는 C_ 로 시작하는 칸에 이름으로 값만 넣는다. 발생 손실 비용만 채우고
// 이의제기·확정·CLAIM 비용·제반비용 산출 칸은 빈칸으로 둔다 (2026-11-10 사용자 지시).
using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class R01 : XtraReport
    {
        private const int ItemRowCount = 17;   // 품목 줄 수 (양식 고정)

        public R01(Dictionary<string, string> param)
        {
            InitializeComponent();

            // 디자이너에서 칸을 새로 추가해도 출력 때 칸 크기가 바뀌지 않게 잠근다
            foreach (XRLabel label in AllControls<XRLabel>())
            {
                label.CanGrow = false;
                label.CanShrink = false;
            }

            // 매개변수가 없으면 빈 양식만 출력 (레이아웃 확인용)
            if (param == null || !param.ContainsKey("SMONTH") || !param.ContainsKey("CUSTCD") || param["CUSTCD"] == "")
            {
                return;
            }

            ItsMaria maria = new ItsMaria("TQM3001_R01", "PRINT");
            maria.AddParam("SMONTH", param["SMONTH"]);
            maria.AddParam("CUSTCD", param["CUSTCD"]);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 클레임이 없습니다.");
            }

            FillReport(ds);
        }

        private void FillReport(DataSet ds)
        {
            DataRow head = ds.Tables[0].Rows[0];
            foreach (string field in new string[] { "EMPNM", "DOCDATE_TXT", "DOCNO", "RECVNM", "REFNM", "TITLE", "PERIOD" })
            {
                SetCell("C_" + field, Value(head, field));
            }
            SetCell("C_RECVNM_P2", Value(head, "RECVNM"));
            SetCell("C_PLANDATE", "■ 예정일자 : " + Value(head, "PLANDATE_TXT"));
            SetCell("C_CONFDATE", "□ 확정일자 : " + Value(head, "CONFDATE_TXT"));
            SetCell("C_OBJTEXT", "      내역 참조하시고 본 건에 대한 이의사항이 있으시면 " + Value(head, "OBJDATE_MD") + " 限 서면 제출하여 주시기 바랍니다.");

            DataTable items = ds.Tables[1];
            if (items.Rows.Count > ItemRowCount)
            {
                throw new InvalidOperationException("품목이 " + ItemRowCount + "개를 넘어 양식에 다 들어가지 않습니다. (품목 " + items.Rows.Count + "개)");
            }

            decimal sumQty = 0;
            decimal sumAmt = 0;
            for (int i = 0; i < items.Rows.Count; i++)
            {
                DataRow r = items.Rows[i];
                int n = i + 1;
                decimal qty = Dec(r, "CLAIMQTY");
                decimal amt = Dec(r, "CLAIMAMT");
                sumQty += qty;
                sumAmt += amt;

                // 1장 공문서: CLAIM 상세 내역
                SetCell("C_P1_" + n + "_ITEMCD", Value(r, "ITEMCD"));
                SetCell("C_P1_" + n + "_ITEMNM", Value(r, "ITEMNM"));
                SetCell("C_P1_" + n + "_BADCONT", Value(r, "BADCONT"));
                SetCell("C_P1_" + n + "_QTY", Num(qty));
                SetCell("C_P1_" + n + "_AMT", Num(amt));

                // 2장 산출내역서: 발생 손실 비용
                SetCell("C_P2_" + n + "_ITEMCD", Value(r, "ITEMCD"));
                SetCell("C_P2_" + n + "_ITEMNM", Value(r, "ITEMNM"));
                SetCell("C_P2_" + n + "_BADCONT", Value(r, "BADCONT"));
                SetCell("C_P2_" + n + "_QTY", Num(qty));
                SetCell("C_P2_" + n + "_INPRICE", NumBlank(Dec(r, "INPRICE")));
                SetCell("C_P2_" + n + "_MFGPRICE", NumBlank(Dec(r, "MFGPRICE")));
                SetCell("C_P2_" + n + "_SALEPRICE", NumBlank(Dec(r, "SALEPRICE")));
                SetCell("C_P2_" + n + "_ETCAMT", NumBlank(Dec(r, "ETCAMT")));
                SetCell("C_P2_" + n + "_AMT", Num(amt));
            }

            SetCell("C_P1_SUM_QTY", Num(sumQty));
            SetCell("C_P1_SUM_AMT", Num(sumAmt));
            SetCell("C_P2_SUM_QTY", Num(sumQty));
            SetCell("C_P2_SUM_AMT", Num(sumAmt));
        }

        /// 이름으로 칸을 찾아 값을 넣는다. 그 칸이 양식에 없으면 조용히 통과.
        private void SetCell(string name, string text)
        {
            XRLabel label = FindControl(name, true) as XRLabel;
            if (label == null)
            {
                return;
            }
            label.Text = text;
        }

        private static string Value(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName) || row.IsNull(columnName))
            {
                return string.Empty;
            }
            return row[columnName].ToString();
        }

        private static decimal Dec(DataRow row, string columnName)
        {
            decimal d;
            return decimal.TryParse(Value(row, columnName), out d) ? d : 0;
        }

        // 천 단위 쉼표, 불필요한 소수 0 제거 (2519.20000000 → 2,519.2)
        private static string Num(decimal d)
        {
            return d.ToString("#,##0.########");
        }

        // 단가·제반비용은 0 이면 빈칸
        private static string NumBlank(decimal d)
        {
            return d == 0 ? "" : Num(d);
        }
    }
}
