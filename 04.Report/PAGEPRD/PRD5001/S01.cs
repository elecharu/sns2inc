// 2026-11-17 [자주검사 조회] 자주검사 체크시트 (가로 A4). PRD5001_S01 에서 체크한 작업(작업조) 동안 한 자주검사
// 매개변수: PRDWORKKEYS = 작업키 (쉼표 구분, 여러 개면 작업마다 체크시트를 한 PDF 에 이어 붙인다)
// 2026-11-17 검사항목 칸에 세부항목(STDPART)을 '검사항목_세부항목' 으로 붙임, 여러 작업 출력 (사용자 요청)
// 양식은 S01.Designer.cs (받은자료 생산팀 "자주검사(MES-Sample)검토" 시트). 여기서는 C_ 칸에 이름으로 값만 넣는다.
// 줄 = 검사항목 × 시료, 열 = 작업 중 실제 검사 회차(검사시각). 한 장에 줄 24개 · 회차 12개
//   줄이 넘치면 다음 장에 이어서, 회차가 12개를 넘으면 13번째 회차부터 같은 줄을 다시 찍는다.
// 프로시저 PRD5001_S01 LIST_TQM (화면 그리드와 같은 결과)
//   Tables[0] 머리 (TITLE, WORKDATE_TXT, DAYEMP, NIGHTEMP, ITEMNM, ITEMCD)
//   Tables[1] 검사 회차 (SEQNO, HHMM ...)
//   Tables[2] 검사항목 × 시료 줄 (PRCDETAILNM, STDNM, FEATURE, STDJUDGE, STDCYCLENM, STDMACHINENM, SAMPLENO, T01~T30, N01~N30)
//             항목 정보는 시료 1번 줄에만 있다. N = 'Y' 면 그 회차 그 항목 불합격 (빨간 글자)
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class S01 : XtraReport
    {
        private const int PageRowCount = 24;    // 한 장의 검사항목 줄 수 (양식 고정)
        private const int TimeCount = 12;   // 한 장의 검사 회차 열 수 (양식 고정)
        private const float RowHeight = 22F;

        // 시료 줄을 세로로 합쳐 한 번만 보여주는 항목 정보 칸 (공정은 같은 공정끼리 따로 합친다)
        private static readonly string[] ItemFields = { "STD", "FEAT", "SPEC", "CYCLE", "GAUGE" };
        private static readonly string[] ItemColumns = { "STDNM", "FEATURE", "STDJUDGE", "STDCYCLENM", "STDMACHINENM" };

        // 디자이너용 (빈 양식)
        public S01()
        {
            InitializeComponent();

            // 디자이너에서 칸을 새로 추가해도 출력 때 칸 크기가 바뀌지 않게 잠근다
            foreach (XRLabel label in AllControls<XRLabel>())
            {
                label.CanGrow = false;
                label.CanShrink = false;
            }

            LoadLogo();
        }

        public S01(Dictionary<string, string> param) : this()
        {
            // 매개변수가 없으면 빈 양식만 출력 (레이아웃 확인용)
            if (param == null || !param.ContainsKey("PRDWORKKEYS") || param["PRDWORKKEYS"] == "")
            {
                return;
            }

            // 작업(작업조) 여러 개면 작업마다 체크시트를 만들어 한 PDF 에 이어 붙인다
            string[] keys = param["PRDWORKKEYS"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            bool first = true;
            foreach (string key in keys)
            {
                AddWork(GET_DATA(key), ref first);
            }
        }

        private DataSet GET_DATA(string prdWorkKey)
        {
            ItsMaria maria = new ItsMaria("PRD5001_S01", "LIST_TQM");
            maria.AddParam("PRDWORKKEY", prdWorkKey);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (ds == null || ds.Tables.Count < 3 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 자주검사 데이터가 없습니다. 작업키: " + prdWorkKey);
            }

            return ds;
        }

        /// 작업 하나의 체크시트 장들을 만든다. 맨 첫 장은 이 리포트에, 나머지는 따로 만들어 이어 붙인다 (TQM1002 R01 과 같은 방식)
        private void AddWork(DataSet ds, ref bool first)
        {
            DataRow head = ds.Tables[0].Rows[0];
            DataTable seq = ds.Tables[1];

            // 줄을 장으로 나눈다. 한 검사항목의 시료 줄은 가능하면 한 장에 모은다
            List<List<DataRow>> rowPages = new List<List<DataRow>>();
            List<DataRow> page = new List<DataRow>();
            List<DataRow> item = new List<DataRow>();
            foreach (DataRow r in ds.Tables[2].Rows)
            {
                if (Value(r, "SAMPLENO") == "1" && item.Count > 0)
                {
                    AddItem(rowPages, ref page, item);
                    item = new List<DataRow>();
                }
                item.Add(r);
            }
            if (item.Count > 0)
            {
                AddItem(rowPages, ref page, item);
            }
            if (page.Count > 0 || rowPages.Count == 0)
            {
                rowPages.Add(page);
            }

            int colPages = Math.Max(1, (seq.Rows.Count + TimeCount - 1) / TimeCount);
            int total = rowPages.Count * colPages;

            // 쪽 번호는 작업마다 1 부터
            int pageNo = 0;
            for (int c = 0; c < colPages; c++)
            {
                for (int p = 0; p < rowPages.Count; p++)
                {
                    pageNo++;
                    if (first)
                    {
                        FillPage(head, seq, rowPages[p], c, pageNo, total);
                        this.CreateDocument();
                        first = false;
                        continue;
                    }

                    S01 next = new S01();
                    next.FillPage(head, seq, rowPages[p], c, pageNo, total);
                    next.CreateDocument();
                    this.Pages.AddRange(next.Pages);
                }
            }
        }

        /// 검사항목 하나(시료 줄 묶음)를 장에 넣는다. 남은 줄이 모자라면 다음 장에서 시작
        private static void AddItem(List<List<DataRow>> rowPages, ref List<DataRow> page, List<DataRow> item)
        {
            // 검사항목(세부항목 포함)·검사규격이 여러 줄이면 (예: 6 X 6 MAX / 5 X 5 MIN) 줄 수만큼 빈 줄(null)을 붙여 칸을 키운다
            int lines = Math.Max(StdText(item[0]).Split('\n').Length, Value(item[0], "STDJUDGE").Replace("\r\n", "\n").Split('\n').Length);
            while (item.Count < lines)
            {
                item.Add(null);
            }

            if (page.Count > 0 && page.Count + item.Count > PageRowCount)
            {
                rowPages.Add(page);
                page = new List<DataRow>();
            }
            foreach (DataRow r in item)
            {
                if (page.Count == PageRowCount)   // 시료 줄이 한 장보다 많은 항목
                {
                    rowPages.Add(page);
                    page = new List<DataRow>();
                }
                page.Add(r);
            }
        }

        private void FillPage(DataRow head, DataTable seq, List<DataRow> rows, int colPage, int pageNo, int pageTotal)
        {
            foreach (string field in new string[] { "TITLE", "WORKDATE_TXT", "DAYEMP", "NIGHTEMP", "ITEMNM", "ITEMCD" })
            {
                SetCell("C_" + field, Value(head, field));
            }
            SetCell("C_PAGE", pageTotal > 1 ? pageNo + " / " + pageTotal : "");

            // 검사 회차 열 제목 = 검사시각
            for (int k = 1; k <= TimeCount; k++)
            {
                int s = colPage * TimeCount + k;
                SetCell("C_H" + k.ToString("00"), s <= seq.Rows.Count ? Value(seq.Rows[s - 1], "HHMM") : "");
            }

            // 줄마다 시료번호·회차 값
            string[] itemPrc = new string[rows.Count];   // 줄이 속한 검사항목의 공정
            for (int i = 0; i < rows.Count; i++)
            {
                DataRow r = rows[i];
                string row = "C_R" + (i + 1).ToString("00") + "_";
                bool itemStart = i == 0 || Value(r, "SAMPLENO") == "1";

                itemPrc[i] = itemStart ? Value(r, "PRCDETAILNM") : itemPrc[i - 1];
                SetCell(row + "NO", Value(r, "SAMPLENO"));

                for (int k = 1; k <= TimeCount; k++)
                {
                    string s = (colPage * TimeCount + k).ToString("00");
                    XRLabel cell = FindControl(row + "T" + k.ToString("00"), true) as XRLabel;
                    if (cell == null)
                    {
                        continue;
                    }
                    cell.Text = Value(r, "T" + s);
                    cell.ForeColor = Value(r, "N" + s) == "Y" ? Color.Red : Color.Black;
                }

                // 항목 정보는 그 항목의 첫 줄 칸을 시료 줄 수만큼 늘리고, 아래 칸은 숨긴다
                if (!itemStart)
                {
                    continue;
                }
                int span = 1;
                while (i + span < rows.Count && Value(rows[i + span], "SAMPLENO") != "1")
                {
                    span++;
                }
                for (int f = 0; f < ItemFields.Length; f++)
                {
                    MergeCells(i, span, ItemFields[f], ItemFields[f] == "STD" ? StdText(r) : Value(r, ItemColumns[f]));
                }
            }

            // 공정은 같은 공정이 이어지는 검사항목끼리 합친다 (양식의 OP10, OP20 처럼)
            for (int i = 0; i < rows.Count;)
            {
                int span = 1;
                while (i + span < rows.Count && itemPrc[i + span] == itemPrc[i])
                {
                    span++;
                }
                MergeCells(i, span, "PRC", itemPrc[i]);
                i += span;
            }
        }

        /// rowIndex 줄의 field 칸을 span 줄 높이로 늘려 text 를 넣고, 그 아래 같은 칸은 숨긴다
        private void MergeCells(int rowIndex, int span, string field, string text)
        {
            XRLabel first = FindControl("C_R" + (rowIndex + 1).ToString("00") + "_" + field, true) as XRLabel;
            if (first == null)
            {
                return;
            }
            first.Text = text;
            first.HeightF = RowHeight * span;
            first.WordWrap = true;

            for (int j = 1; j < span; j++)
            {
                XRLabel below = FindControl("C_R" + (rowIndex + j + 1).ToString("00") + "_" + field, true) as XRLabel;
                if (below != null)
                {
                    below.Visible = false;
                }
            }
        }

        /// 검사항목 칸 글자: 검사항목_세부항목 (세부항목이 없으면 검사항목만)
        private static string StdText(DataRow row)
        {
            string part = Value(row, "STDPART").Trim();
            return part == "" ? Value(row, "STDNM") : Value(row, "STDNM") + "_" + part;
        }

        private void LoadLogo()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] logoPaths = new string[]
            {
                System.IO.Path.Combine(baseDir, "..", "images", "menu", "logo.png"),
                System.IO.Path.Combine(baseDir, "..", "..", "01.Office", "images", "menu", "logo.png")
            };
            foreach (string lp in logoPaths)
            {
                if (System.IO.File.Exists(lp))
                {
                    try
                    {
                        picLogo.Image = Image.FromFile(lp);
                        break;
                    }
                    catch { }
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
            if (row == null || !row.Table.Columns.Contains(columnName) || row.IsNull(columnName))   // null = 검사규격 때문에 붙인 빈 줄
            {
                return string.Empty;
            }
            return row[columnName].ToString();
        }
    }
}
