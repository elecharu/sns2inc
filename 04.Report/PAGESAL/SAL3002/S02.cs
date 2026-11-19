// 2026-11-17 판매계획대비 출하실적조회(SAL3002_S02) [인쇄] - 생산관리팀 "판매계획대비 출하실적(세부)_2공장" 엑셀 양식
// 양식은 S02.Designer.cs (디자이너에서 보임). A4 가로.
//   1장~ 메인 : 제목 + 표 1~4 (DR1~DR4)
//   다음 장~ 세부내역 : DR5 (새 장에서 시작, 머리글 2줄은 장마다 반복)
// 데이터는 화면 조회와 같은 프로시저 SAL3002_S02 LIST 결과 5개를 그대로 쓴다.
// 줄 색(Total·합계)과 음수 빨강은 Row_BeforePrint 에서 줄 종류(ROWTP)로 칠한다 (화면 엑셀 내보내기와 같은 색).
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class S02 : XtraReport
    {
        // 디자이너용 (빈 양식)
        public S02()
        {
            InitializeComponent();

            // 디자이너에서 칸을 새로 추가해도 출력 때 칸 크기가 바뀌지 않게 잠근다
            foreach (XRLabel label in AllControls<XRLabel>())
            {
                label.CanGrow = false;
                label.CanShrink = false;
            }

            // 세부내역 품명·미출고원인·대책·비고는 글이 길면 줄을 바꿔 다 보이게 한다 (2026-11-17 사용자 요청)
            // 한 줄이 표(T5) 하나라 같은 줄 칸이 다 같이 늘어난다. 칸·행·표를 모두 켜야 한다
            // (Designer 에 써 둔 CanGrow 는 EndInit 에서 되돌아가므로 여기서 켠다)
            foreach (XRTableCell cell in new XRTableCell[] { D5_ITEMNM, D5_NOOUTCAUSE, D5_MEASURE, D5_REMARK })
            {
                cell.CanGrow = true;
                cell.WordWrap = true;
                cell.BeforePrint += WrapCell_BeforePrint;
            }
            R5.CanGrow = true;
            T5.CanGrow = true;
        }

        // SMONTH = 조회년월 (YYYY-MM)
        public S02(Dictionary<string, string> param) : this()
        {
            // 매개변수가 없으면 빈 양식만 출력 (레이아웃 확인용)
            if (param == null || !param.ContainsKey("SMONTH") || param["SMONTH"] == "")
            {
                return;
            }

            ItsMaria maria = new ItsMaria("SAL3002_S02", "LIST");
            maria.AddParam("SMONTH", param["SMONTH"]);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }
            if (ds == null || ds.Tables.Count < 5)
            {
                throw new InvalidOperationException("출력할 자료가 없습니다.");
            }

            FillReport(param["SMONTH"], ds);
        }

        private void FillReport(string smonth, DataSet ds)
        {
            string yyyy = smonth.Substring(0, 4);
            string mm = smonth.Substring(5, 2);
            C_TITLE.Text = "▣ " + yyyy + "年 " + mm + "月 판매계획 대비 출하실적";
            C_DETAIL_TITLE.Text = "■ (" + yyyy + "년 " + int.Parse(mm) + "월) 출하계획 대비 실적";

            // 세부내역 합계 줄 이름은 좁은 구분·고객사 칸에서 잘리므로 넓은 칸으로 옮겨 찍는다
            //   고객사 Total : 이름은 품명 칸, 고객사 칸은 위 품목 줄과 병합
            //   구분 Total   : 이름은 고객사 칸, 구분 칸은 위 줄들과 병합
            //   Grand Total  : 이름은 품명 칸
            // 병합 기준은 DEBCKEY(구분)·CUSTKEY(구분+고객사). 합계 줄은 자기 줄만의 값이라 따로 병합되지 않는다
            DataTable detail = ds.Tables[4];
            detail.Columns.Add("DEBCKEY", typeof(string));
            detail.Columns.Add("CUSTKEY", typeof(string));
            string debc = "";
            string cust = "";
            for (int i = 0; i < detail.Rows.Count; i++)
            {
                DataRow r = detail.Rows[i];
                string rowtp = Value(r, "ROWTP");
                if (rowtp == "D")
                {
                    debc = Value(r, "DEBCNM");
                    cust = Value(r, "CUSTNM");
                }
                if (rowtp == "C")
                {
                    r["ITEMNM"] = Value(r, "CUSTNM");
                    r["CUSTNM"] = cust;
                }
                if (rowtp == "G")
                {
                    r["CUSTNM"] = Value(r, "DEBCNM");
                    r["DEBCNM"] = debc;
                }
                if (rowtp == "T")
                {
                    r["ITEMNM"] = Value(r, "DEBCNM");
                    r["DEBCNM"] = "";
                }
                r["DEBCKEY"] = rowtp == "T" ? "ROW" + i : debc;
                r["CUSTKEY"] = rowtp == "D" || rowtp == "C" ? debc + "|" + cust : "ROW" + i;
            }

            DR1.DataSource = ds.Tables[0];
            DR2.DataSource = ds.Tables[1];
            DR3.DataSource = ds.Tables[2];
            DR4.DataSource = ds.Tables[3];
            DR5.DataSource = detail;
        }

        // 줄 종류(ROWTP)별 바탕색. 표 1·3: T 회색 / 표 2: G 진한 회색, T 회색 / 세부내역: C 연두, G 진한 연두, T 남색
        private void Row_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DetailBand band = (DetailBand)sender;
            string rowtp = Convert.ToString(band.Report.GetCurrentColumnValue("ROWTP"));

            Color back = Color.Transparent;
            Color fore = Color.Black;
            if (band == D2 && rowtp == "G") back = Color.FromArgb(191, 191, 191);
            if (band != D5 && rowtp == "T") back = Color.FromArgb(217, 217, 217);
            if (band == D5 && rowtp == "C") back = Color.FromArgb(226, 239, 218);
            if (band == D5 && rowtp == "G") back = Color.FromArgb(169, 208, 142);
            if (band == D5 && rowtp == "T")
            {
                back = Color.FromArgb(0, 32, 96);
                fore = Color.White;
            }

            foreach (XRLabel control in band.AllControls<XRLabel>())   // 표 칸(XRTableCell)도 XRLabel 이다
            {
                string field = control.Name.Substring(control.Name.IndexOf('_') + 1);

                // 위 품목 줄과 병합되는 칸엔 색을 안 칠한다
                //   표 2 구분 합계의 구분 칸 / 세부내역 고객사 Total·구분 Total 의 구분 칸 / 고객사 Total 의 고객사 칸
                bool mergedWithItems = (field == "DEBCNM" && ((band == D2 && rowtp == "G") || (band == D5 && (rowtp == "C" || rowtp == "G"))))
                                    || (field == "CUSTNM" && band == D5 && rowtp == "C");
                control.BackColor = mergedWithItems ? Color.Transparent : back;
                control.ForeColor = mergedWithItems ? Color.Black : fore;

                // 차액·차이는 음수면 빨강
                if (field == "DIFFAMT" || field == "DIFFQTY" || field == "ADJAMT" || field == "ADJPLANAMT")
                {
                    decimal d;
                    if (decimal.TryParse(Convert.ToString(band.Report.GetCurrentColumnValue(field)), out d) && d < 0)
                    {
                        control.ForeColor = fore == Color.White ? Color.FromArgb(255, 150, 150) : Color.Red;
                    }
                }
            }
        }

        // 품명·미출고원인·대책·비고가 여러 줄이면 빈 줄을 덧붙여 줄 높이를 넉넉히 잡고 위에서부터 찍는다.
        // 줄 높이는 글자 단위 줄바꿈으로 재는데 PDF 는 단어 단위로 줄을 바꿔 줄이 더 많아지고, 넘친 줄이 잘리기 때문
        private void WrapCell_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell cell = (XRTableCell)sender;
            string text = cell.Text.TrimEnd('\n');
            int lines = (int)Math.Ceiling(MeasureWidth(text, cell.Font) / (cell.WidthF - 6));
            if (lines <= 1)
            {
                cell.Text = text;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                return;
            }
            cell.Text = text + new string('\n', (lines + 1) / 2);
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        }

        // 글자 폭 (리포트 단위 1/100 인치)
        private static readonly Graphics Measurer = Graphics.FromImage(new Bitmap(1, 1));
        private static float MeasureWidth(string text, Font font)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }
            return Measurer.MeasureString(text, font).Width * 100F / Measurer.DpiX;
        }

        private static string Value(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName) || row.IsNull(columnName))
            {
                return string.Empty;
            }
            return row[columnName].ToString();
        }
    }
}
