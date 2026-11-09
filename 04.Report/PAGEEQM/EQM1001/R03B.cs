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
    public partial class R03B : DevExpress.XtraReports.UI.XtraReport
    {
        // 2026-11-09 [월별 점검계획] 월별 행 배경색 (1월~12월)
        private static readonly Color[] MonthColors = new Color[]
        {
            Color.FromArgb(242, 242, 242),
            Color.FromArgb(252, 228, 214),
            Color.FromArgb(221, 235, 247),
            Color.FromArgb(242, 220, 219),
            Color.FromArgb(228, 223, 236),
            Color.FromArgb(235, 241, 222),
            Color.FromArgb(197, 217, 241),
            Color.FromArgb(235, 241, 222),
            Color.FromArgb(218, 238, 243),
            Color.FromArgb(235, 241, 222),
            Color.FromArgb(242, 242, 242),
            Color.FromArgb(228, 223, 236)
        };

        // 2026-11-09 [월별 점검계획] Visual Studio Report Designer 호환을 위한 기본 생성자
        public R03B()
        {
            InitializeComponent();
        }

        // 2026-11-09 [월별 점검계획] 조회년도·설비 조건으로 점검자가 배정된 월별 계획 조회 바인딩
        public R03B(Dictionary<string, string> param) : this()
        {
            string year = param.ContainsKey("SYEAR") ? param["SYEAR"] : "";
            string fano = param.ContainsKey("FANO") ? param["FANO"] : "";
            if (string.IsNullOrEmpty(year))
            {
                throw new InvalidOperationException("조회년도를 지정해주세요.");
            }

            ItsMaria maria = new ItsMaria("EQM1001_R03", "CALL_CYCLE_RPT");
            maria.AddParam("SYEAR", year);
            maria.AddParam("FANO", fano);
            DataSet dataSet = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (dataSet == null || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("점검자가 배정된 월별 점검계획이 없습니다.");
            }

            this.DataSource = dataSet.Tables[0];
            this.Detail.BeforePrint += Detail_BeforePrint;
        }

        // 2026-11-09 [월별 점검계획] 점검예정 월별로 행 배경색 구분, 각 행은 한 줄로 고정
        private void Detail_BeforePrint(object sender, PrintEventArgs e)
        {
            int month;
            object monthValue = GetCurrentColumnValue("MM");
            xrTableRowDetail.BackColor = int.TryParse(Convert.ToString(monthValue), out month) && month >= 1 && month <= 12
                ? MonthColors[month - 1]
                : Color.White;

            FitCellsToOneLine();
        }

        // 2026-11-09 [월별 점검계획] 칸 폭보다 긴 글자는 줄바꿈 대신 글자 크기를 줄여 한 줄에 표시 (최소 6pt)
        private void FitCellsToOneLine()
        {
            Font baseFont = xrTableDetail.Font;
            foreach (XRTableCell cell in xrTableRowDetail.Cells)
            {
                XRBinding binding = cell.DataBindings["Text"];
                string text = binding == null ? "" : Convert.ToString(GetCurrentColumnValue(binding.DataMember));
                float availableWidth = cell.WidthF - 6F;
                float fontSize = baseFont.Size;
                if (!string.IsNullOrEmpty(text) && availableWidth > 0)
                {
                    using (Font measureFont = new Font(baseFont.FontFamily, baseFont.Size, baseFont.Style))
                    {
                        float textWidth = MeasureGraphics.MeasureString(text, measureFont, PointF.Empty, StringFormat.GenericTypographic).Width / 3F;
                        if (textWidth > availableWidth)
                        {
                            fontSize = Math.Max(6F, (float)Math.Floor(baseFont.Size * availableWidth / textWidth * 2F) / 2F);
                        }
                    }
                }
                cell.Font = fontSize == baseFont.Size ? baseFont : new Font(baseFont.FontFamily, fontSize, baseFont.Style);
            }
        }

        // 글자 폭 측정용 (Document 단위 1/300인치 → 레포트 단위 1/100인치)
        private static readonly Graphics MeasureGraphics = CreateMeasureGraphics();

        private static Graphics CreateMeasureGraphics()
        {
            Graphics graphics = Graphics.FromImage(new Bitmap(1, 1));
            graphics.PageUnit = GraphicsUnit.Document;
            return graphics;
        }
    }
}
