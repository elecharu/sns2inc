// 2026-11-16 [출하검사 등록] 검사성적서(갑지) (세로 A4). TQM1002_R01 에서 체크한 출하계획의 출하검사 1건에 1장
// 양식은 R01.Designer.cs (받은자료 품질팀 출하검사성적서 엑셀을 그대로 그림). 여기서는 C_ 칸에 이름으로 값만 넣는다.
// 매개변수: SALOUTPLANKEYS = 출하계획키 (쉼표 구분, 여러 개면 한 PDF 에 장을 이어 붙인다)
// 프로시저 TQM1002_R01 PRINT 결과
//   Tables[0] 머리 (TQMDATE_TXT, ITEMNM, ITEMCD, EONO, MODELCD, EMPNM, APRVEMPNM, FINALJUDGE, QTY_TXT)
//   Tables[1] 검사항목 (STDNM, STDJUDGE, X1~X5, JUDGE) 검사기준 순서
// 관리구분·등급·발행번호·수요자 칸은 빈칸, 비고 영역은 수량만 (2026-11-16 사용자 지시)
using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class R01 : XtraReport
    {
        private const int ItemRowCount = 27;   // 검사항목 줄 수 (양식 고정)

        // 디자이너용 (빈 양식)
        public R01()
        {
            InitializeComponent();

            // 디자이너에서 칸을 새로 추가해도 출력 때 칸 크기가 바뀌지 않게 잠근다
            foreach (XRLabel label in AllControls<XRLabel>())
            {
                label.CanGrow = false;
                label.CanShrink = false;
            }
        }

        public R01(Dictionary<string, string> param) : this()
        {
            // 매개변수가 없으면 빈 양식만 출력 (레이아웃 확인용)
            if (param == null || !param.ContainsKey("SALOUTPLANKEYS") || param["SALOUTPLANKEYS"] == "")
            {
                return;
            }

            string[] keys = param["SALOUTPLANKEYS"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            // 첫 검사는 이 리포트에, 나머지 검사는 따로 만들어 장을 이어 붙인다 (TQM2001 공정이동표와 같은 방식)
            SET_DATA(GET_DATA(keys[0]));
            this.CreateDocument();

            for (int i = 1; i < keys.Length; i++)
            {
                R01 page = new R01();
                page.SET_DATA(GET_DATA(keys[i]));
                page.CreateDocument();
                this.Pages.AddRange(page.Pages);
            }
        }

        private DataSet GET_DATA(string saloutPlanKey)
        {
            ItsMaria maria = new ItsMaria("TQM1002_R01", "PRINT");
            maria.AddParam("SALOUTPLANKEY", saloutPlanKey);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 출하검사가 없습니다. 출하계획키: " + saloutPlanKey);
            }

            return ds;
        }

        private void SET_DATA(DataSet ds)
        {
            DataRow head = ds.Tables[0].Rows[0];
            foreach (string field in new string[] { "TQMDATE_TXT", "ITEMNM", "ITEMCD", "EONO", "MODELCD", "EMPNM", "APRVEMPNM", "QTY_TXT" })
            {
                SetCell("C_" + field, Value(head, field));
            }
            // 종합판정 불합격이면 기각, 아니면 승인
            SetCell("C_APRVMARK", Value(head, "FINALJUDGE") == "N"
                ? "□ 승 인          ■ 기 각          □ 기 타 (                         )"
                : "■ 승 인          □ 기 각          □ 기 타 (                         )");

            DataTable items = ds.Tables[1];
            if (items.Rows.Count > ItemRowCount)
            {
                throw new InvalidOperationException("검사항목이 " + ItemRowCount + "개를 넘어 양식에 다 들어가지 않습니다. (품번 "
                    + Value(head, "ITEMCD") + ", 검사항목 " + items.Rows.Count + "개)");
            }

            for (int i = 0; i < items.Rows.Count; i++)
            {
                DataRow r = items.Rows[i];
                string row = "C_R" + (i + 1).ToString("00") + "_";

                SetCell(row + "NO", (i + 1).ToString());
                SetCell(row + "STD", Value(r, "STDNM"));
                SetCell(row + "SPEC", Value(r, "STDJUDGE"));
                SetCell(row + "JUDGE", Value(r, "JUDGE"));

                string[] x = new string[5];
                for (int k = 0; k < 5; k++)
                {
                    x[k] = Value(r, "X" + (k + 1)).Trim();
                }

                // 측정치가 X1 에만 글자로 있으면 (예: 열처리 성적서 참조) X1~X5 를 합친 칸에 표시 (양식과 같은 모양)
                decimal num;
                bool span = x[0] != "" && x[1] == "" && x[2] == "" && x[3] == "" && x[4] == "" && !decimal.TryParse(x[0], out num);
                XRLabel spanLabel = FindControl(row + "XSPAN", true) as XRLabel;
                if (spanLabel != null)
                {
                    spanLabel.Visible = span;
                    spanLabel.Text = span ? x[0] : "";
                }
                // 합친 칸을 쓸 때는 X1~X5 칸을 숨겨야 칸 선이 겹쳐 보이지 않는다
                for (int k = 0; k < 5; k++)
                {
                    XRLabel xLabel = FindControl(row + "X" + (k + 1), true) as XRLabel;
                    if (xLabel != null)
                    {
                        xLabel.Visible = !span;
                        xLabel.Text = span ? "" : x[k];
                    }
                }
            }
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
    }
}
