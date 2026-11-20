using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using System.Data;
using System.Collections.Generic;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class R01 : DevExpress.XtraReports.UI.XtraReport
    {
        // 공무작업일지 (EQM1001_R01 인쇄), Visual Studio Report Designer 호환을 위한 기본 생성자
        public R01()
        {
            InitializeComponent();
        }

        // EQMREPKEY_LIST(설비수리키 쉼표 구분) 여러 건은 일지마다 새 페이지로 한 PDF에 묶음
        public R01(Dictionary<string, string> param) : this()
        {
            string keyList = param.ContainsKey("EQMREPKEY_LIST") ? param["EQMREPKEY_LIST"] : "";
            string[] eqmRepKeys = keyList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (eqmRepKeys.Length == 0)
            {
                throw new InvalidOperationException("인쇄할 공무작업일지를 선택해주세요.");
            }

            // 첫 일지는 이 리포트에, 나머지는 따로 만들어 페이지를 뒤에 붙인다
            SET_DATA(eqmRepKeys[0]);
            if (eqmRepKeys.Length == 1) return;

            CreateDocument();
            for (int i = 1; i < eqmRepKeys.Length; i++)
            {
                R01 next = new R01();
                next.SET_DATA(eqmRepKeys[i]);
                next.CreateDocument();
                Pages.AddRange(next.Pages);
            }
        }

        // [0] 일지, [1] 작업자(대표 작업자 먼저), [2] 사용 자재·부품
        private void SET_DATA(string eqmRepKey)
        {
            ItsMaria maria = new ItsMaria("EQM1001_R01", "PRINT_WORKLOG");
            maria.AddParam("EQMREPKEY", eqmRepKey);
            DataSet dataSet = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (dataSet == null || dataSet.Tables.Count < 3 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("인쇄할 공무작업일지가 없습니다. (" + eqmRepKey + ")");
            }

            DataRow log = dataSet.Tables[0].Rows[0];
            DataTable workers = dataSet.Tables[1];
            DataTable parts = dataSet.Tables[2].Copy();
            AddBlankRows(parts, 2);

            BindReportData(log, workers, parts);
        }

        private void BindReportData(DataRow log, DataTable workers, DataTable parts)
        {
            // 문서 정보
            cell_Val_EQMREPKEY.Text = Value(log, "EQMREPKEY");
            cell_Val_WORKTPNM.Text = Value(log, "WORKTPNM");
            cell_Val_WRITEDATE.Text = Value(log, "WRITEDATE");
            cell_Val_PROGRESS.Text = Value(log, "PROGRESS");

            // 1. 설비정보
            cell_Val_LINEINFO.Text = Value(log, "LINEINFO");
            cell_Val_EQMCD.Text = Value(log, "EQMCD");
            cell_Val_EQMNM.Text = Value(log, "EQMNM");
            cell_Val_FAILTPNM.Text = Value(log, "FAILTPNM");
            cell_Val_FAILPARTNM.Text = Value(log, "FAILPARTNM");
            cell_Val_STOPTPNM.Text = Value(log, "STOPTPNM");

            // 2. 발생 및 조치 시간
            cell_Val_NONSTIME.Text = Value(log, "NONSTIME");
            cell_Val_NONETIME.Text = Value(log, "NONETIME");
            cell_Val_STOPMIN.Text = Value(log, "STOPMIN");
            cell_Val_REPSTIME.Text = Value(log, "REPSTIME");
            cell_Val_REPETIME.Text = Value(log, "REPETIME");
            cell_Val_REPMIN.Text = Value(log, "REPMIN");
            BindWorkers(workers);

            // 3 ~ 5, 7 서술 항목
            xrLabelMALFUNCTION.Text = Value(log, "MALFUNCTION");
            xrLabelCAUSE.Text = Value(log, "CAUSE");
            xrLabelHANDLE.Text = Value(log, "HANDLE");
            xrLabelPREVENT.Text = Value(log, "PREVENT");

            // 6. 사용 자재 / 부품
            this.DataSource = parts;

            FitOnePage(parts);
        }

        // A4 1장 = 용지 높이 1169 - 위아래 여백 20 (1/100 inch)
        private const float PAGE_BODY_HEIGHT = 1129F;
        private const float SECTION_HEIGHT = 30F;
        private const float SAFETY_HEIGHT = 6F;
        private const float TEXT_WIDTH = 709F;
        private const float TEXT_MIN_HEIGHT = 36F;
        private const float TEXT_FLOOR_HEIGHT = 30F;
        private const string FONT_NAME = "맑은 고딕";

        // 서술 칸(3·4·5·7)과 사용 부품 행을 A4 1장에 맞춤: 글자 크기를 10pt 부터 줄여 가며 들어가는 크기를 고르고, 남는 높이는 서술 칸에 나눠 줌
        private void FitOnePage(DataTable parts)
        {
            int partRowCount = parts.Rows.Count;
            // 위쪽 표(문서정보·결재·설비정보·시간·부품 머리글)는 긴 값이 와도 늘어나지 않게 고정 (칸 안에서 줄바꿈)
            foreach (XRTable fixedTable in new XRTable[] { xrTableDoc, xrTableApproval, xrTableEqm, xrTableTime, xrTablePartHdr })
            {
                foreach (XRTableRow fixedRow in fixedTable.Rows)
                {
                    foreach (XRTableCell fixedCell in fixedRow.Cells) fixedCell.CanGrow = false;
                }
            }

            XRLabel[] texts = new XRLabel[] { xrLabelMALFUNCTION, xrLabelCAUSE, xrLabelHANDLE, xrLabelPREVENT };
            float textTop = xrLabelSec3.TopF;
            float fixedHeight = textTop + SECTION_HEIGHT * 5 + xrTablePartHdr.HeightF;
            float budget = PAGE_BODY_HEIGHT - fixedHeight - SAFETY_HEIGHT;

            float[] fontSizes = new float[] { 10F, 9.5F, 9F, 8.5F, 8F, 7.5F, 7F, 6.5F };
            float fontSize = fontSizes[fontSizes.Length - 1];
            float rowHeight = PartRowHeight(fontSize);
            float[] heights = new float[texts.Length];
            bool fitted = false;
            foreach (float size in fontSizes)
            {
                float rh = PartRowHeight(size);
                float total = rh * partRowCount;
                for (int i = 0; i < texts.Length; i++)
                {
                    heights[i] = Math.Max(TEXT_MIN_HEIGHT, MeasureTextHeight(texts[i].Text, size) + 16F);
                    total += heights[i];
                }
                if (total <= budget)
                {
                    fontSize = size;
                    rowHeight = rh;
                    fitted = true;
                    break;
                }
            }

            if (!fitted)
            {
                // 가장 작은 글자로도 넘치면 부품은 서술 칸 최소 높이를 남기고 들어가는 행까지만 표시 (마지막 행 '외 N건')
                int maxRows = (int)Math.Floor((budget - TEXT_FLOOR_HEIGHT * texts.Length) / rowHeight);
                if (partRowCount > maxRows)
                {
                    TrimParts(parts, maxRows);
                    partRowCount = parts.Rows.Count;
                }
            }

            float textBudget = budget - rowHeight * partRowCount;
            float textTotal = 0F;
            foreach (float h in heights) textTotal += h;
            if (!fitted)
            {
                // 서술 칸은 최소 높이씩 주고 남는 높이를 글 길이 비율대로 나눔 (넘친 글은 칸 안에서 잘림)
                float remain = textBudget - TEXT_FLOOR_HEIGHT * heights.Length;
                float need = 0F;
                foreach (float h in heights) need += Math.Max(0F, h - TEXT_FLOOR_HEIGHT);
                for (int i = 0; i < heights.Length; i++)
                {
                    float share = need > 0F ? Math.Max(0F, heights[i] - TEXT_FLOOR_HEIGHT) / need : 1F / heights.Length;
                    heights[i] = TEXT_FLOOR_HEIGHT + (float)Math.Floor(Math.Max(0F, remain) * share);
                }
            }
            else
            {
                float extra = (float)Math.Floor((textBudget - textTotal) / heights.Length);
                for (int i = 0; i < heights.Length; i++) heights[i] += extra;
            }

            // 서술 칸 크기·위치 고정 (자동 늘어남 끔)
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].CanGrow = false;
                texts[i].Font = new Font(FONT_NAME, fontSize);
                texts[i].HeightF = heights[i];
            }
            float y = textTop;
            XRLabel[] sections = new XRLabel[] { xrLabelSec3, xrLabelSec4, xrLabelSec5 };
            for (int i = 0; i < sections.Length; i++)
            {
                sections[i].TopF = y;
                y += SECTION_HEIGHT;
                texts[i].TopF = y;
                y += heights[i];
            }
            xrLabelSec6.TopF = y;
            y += SECTION_HEIGHT;
            xrTablePartHdr.TopF = y;
            y += xrTablePartHdr.HeightF;
            ReportHeader.HeightF = y;

            // 사용 부품 행
            xrTablePart.Font = new Font(FONT_NAME, fontSize);
            xrTablePart.HeightF = rowHeight;
            foreach (XRTableCell partCell in xrTableRowPart.Cells) partCell.CanGrow = false;
            Detail.HeightF = rowHeight;

            // 7. 특이사항 및 재발방지대책
            xrLabelSec7.TopF = 0F;
            xrLabelPREVENT.TopF = SECTION_HEIGHT;
            ReportFooter.HeightF = SECTION_HEIGHT + heights[3];
        }

        private static float PartRowHeight(float fontSize)
        {
            return fontSize >= 9.5F ? 30F : Math.Max(16F, (float)Math.Round(fontSize * 2.6F));
        }

        // 1장에 다 못 넣는 사용 부품은 앞에서 (maxRows - 1)건만 남기고 마지막 행에 나머지 건수 표시
        private static void TrimParts(DataTable parts, int maxRows)
        {
            int keep = Math.Max(0, maxRows - 1);
            int rest = parts.Rows.Count - keep;
            while (parts.Rows.Count > keep)
            {
                parts.Rows.RemoveAt(parts.Rows.Count - 1);
            }
            DataRow more = parts.NewRow();
            if (parts.Columns.Contains("PARTNM")) more["PARTNM"] = "외 " + rest + "건";
            parts.Rows.Add(more);
        }

        // 서술 칸 글 높이 (1/100 inch, 좌우 여백 뺀 폭 기준)
        private static float MeasureTextHeight(string text, float fontSize)
        {
            if (string.IsNullOrEmpty(text)) return 0F;
            using (Bitmap bmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bmp))
            using (Font font = new Font(FONT_NAME, fontSize))
            {
                g.PageUnit = GraphicsUnit.Inch;
                SizeF size = g.MeasureString(text, font, new SizeF(TEXT_WIDTH / 100F, 1000F));
                return size.Height * 100F * 1.08F;
            }
        }

        // 작업자 칸은 3개: 4명 이상이면 세 번째 칸에 '이름 외 N명'
        private void BindWorkers(DataTable workers)
        {
            XRTableCell[] arrEmp = new XRTableCell[] { cell_Val_EMP1, cell_Val_EMP2, cell_Val_EMP3 };
            for (int i = 0; i < arrEmp.Length; i++)
            {
                arrEmp[i].Text = i < workers.Rows.Count ? Value(workers.Rows[i], "EMPNM") : "";
            }
            if (workers.Rows.Count > arrEmp.Length)
            {
                arrEmp[arrEmp.Length - 1].Text += " 외 " + (workers.Rows.Count - arrEmp.Length) + "명";
            }
        }

        private static string Value(DataRow row, string fieldName)
        {
            return row.Table.Columns.Contains(fieldName) && row[fieldName] != DBNull.Value ? row[fieldName].ToString() : "";
        }

        // 사용 부품이 적어도 표 칸이 보이도록 빈 행 채움
        private static void AddBlankRows(DataTable table, int minimumRows)
        {
            while (table.Rows.Count < minimumRows)
            {
                table.Rows.Add(table.NewRow());
            }
        }
    }
}
