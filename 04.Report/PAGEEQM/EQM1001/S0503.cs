using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;

namespace XtraRpt
{
    /// <summary>
    /// 2026-11-27 [설비고장율 현황] 웹 EQM1001_S05 설비별 고장부위 현황 탭 원 그래프 출력 (A4 가로, 한 줄에 3개)
    /// 데이터 = EQM1001_S05 LIST_EQM_PART (화면과 같은 조회: 0 = 총 라인 고장부위, 1 = 고장부위 이력 있는 설비별)
    /// 원 그래프 1개 = Detail 1행 (총 라인 → 설비 순), 조각 라벨 '부위명, 비중%' (5% 미만 생략), 범례 부위명, 같은 부위는 같은 색 (화면과 같음)
    /// </summary>
    public partial class S0503 : XtraReport
    {
        static readonly string[] PART_COLORS = { "#E6B8B7", "#E4DFEC", "#DAEEF3", "#FDE9D9", "#C5D9F1", "#F2DCDB", "#EBF1DE", "#FCD5B4", "#B7DEE8", "#CCC0DA", "#D8E4BC", "#FFE699" };   // 화면 EQM1001_S05.js 와 같은 색
        const int K = S0501.K;   // 출력 그림 배율 (S0501.PRINT_CHART)
        static readonly Font FONT_LABEL = new Font("맑은 고딕", 8F * K, FontStyle.Bold);
        static readonly Font FONT_LEGEND = new Font("맑은 고딕", 7.5F * K);

        private readonly List<DataRow[]> _pies = new List<DataRow[]>();
        private readonly Dictionary<string, Color> _partColor = new Dictionary<string, Color>();

        // 2026-11-27 [설비고장율 현황] Visual Studio Report Designer 호환을 위한 기본 생성자
        public S0503()
        {
            InitializeComponent();
        }

        // 2026-11-27 [설비고장율 현황] 조회기간·작업장·공정·라인 수신 → 총 라인 + 설비별 고장부위 원 그래프 목록
        public S0503(Dictionary<string, string> param) : this()
        {
            DataSet ds = S0501.CALL_S05(param, "LIST_EQM_PART");
            DataTable line = ds.Tables[0];
            DataTable eqm = ds.Tables.Count > 1 ? ds.Tables[1] : null;
            if (line.Rows.Count == 0 || eqm == null || eqm.Rows.Count == 0)
            {
                throw new InvalidOperationException("조회기간에 고장부위 이력이 없습니다.");
            }

            // 고장부위별 색상: 총 라인 순서대로, 고장부위 미입력은 회색
            for (int i = 0; i < line.Rows.Count; i++)
            {
                string part = S0501.TEXT(line.Rows[i], "FAILPART");
                _partColor[part] = ColorTranslator.FromHtml(part == "" ? "#D9D9D9" : PART_COLORS[i % PART_COLORS.Length]);
            }

            DataTable pies = new DataTable();
            pies.Columns.Add("PIEIDX", typeof(int));
            pies.Columns.Add("PIENAME", typeof(string));
            ADD_PIE(pies, "총 라인 고장 시간", line.Select());

            List<DataRow> rows = new List<DataRow>();
            for (int i = 0; i < eqm.Rows.Count; i++)
            {
                rows.Add(eqm.Rows[i]);
                if (i == eqm.Rows.Count - 1 || S0501.TEXT(eqm.Rows[i + 1], "FANO") != S0501.TEXT(eqm.Rows[i], "FANO"))
                {
                    ADD_PIE(pies, S0501.TEXT(eqm.Rows[i], "EQMNM") + "\r\n" + S0501.TEXT(eqm.Rows[i], "FANO"), rows.ToArray());
                    rows.Clear();
                }
            }

            lbl_TITLE.Text = "■ " + S0501.TEXT(eqm.Rows[0], "TITLE") + " (" + S0501.PARAM(param, "SDATE") + " ~ " + S0501.PARAM(param, "EDATE") + ")";
            this.DataSource = pies;
            chart_PART.Visible = false;   // 원 그래프는 pic_PART 그림으로만 출력
            pic_PART.BeforePrint += pic_PART_BeforePrint;
            chart_PART.CustomDrawSeriesPoint += chart_PART_CustomDrawSeriesPoint;
        }

        private void ADD_PIE(DataTable pies, string name, DataRow[] rows)
        {
            pies.Rows.Add(_pies.Count, name);
            _pies.Add(rows);
        }

        // 2026-11-27 [설비고장율 현황] 지금 행(원 그래프)의 고장부위별 수리시간으로 원 그래프를 채워 K배 그림으로 그림 상자에 넣음
        private void pic_PART_BeforePrint(object sender, PrintEventArgs e)
        {
            DataRow[] rows = _pies[Convert.ToInt32(GetCurrentColumnValue("PIEIDX"))];
            double total = 0D;
            foreach (DataRow r in rows)
            {
                total += S0501.NUM(r, "PARTMIN") ?? 0D;
            }

            Series s = new Series("고장부위", ViewType.Pie);
            s.ArgumentScaleType = ScaleType.Qualitative;
            foreach (DataRow r in rows)
            {
                string part = S0501.TEXT(r, "FAILPART");
                SeriesPoint p = new SeriesPoint(S0501.TEXT(r, "FAILPARTNM"), S0501.NUM(r, "PARTMIN") ?? 0D);
                p.Color = _partColor.ContainsKey(part) ? _partColor[part] : Color.Gray;
                p.Tag = (total > 0 && (S0501.NUM(r, "PARTMIN") ?? 0D) / total >= 0.05) ? S0501.TEXT(r, "FAILPARTNM") + ",\n" + S0501.TEXT(r, "PARTRATE") + "%" : "";
                s.Points.Add(p);
            }

            PieSeriesView view = (PieSeriesView)s.View;
            view.FillStyle.FillMode = FillMode.Solid;
            view.Border.Visibility = DefaultBoolean.True;
            view.Border.Color = Color.White;
            view.Border.Thickness = K;
            s.LabelsVisibility = DefaultBoolean.True;
            PieSeriesLabel label = (PieSeriesLabel)s.Label;
            label.Position = PieSeriesLabelPosition.TwoColumns;
            label.Font = FONT_LABEL;
            label.TextColor = Color.Black;
            label.BackColor = Color.Transparent;
            label.Border.Visibility = DefaultBoolean.False;
            label.LineLength = 12 * K;
            label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
            label.ResolveOverlappingMinIndent = 4 * K;   // 바깥 라벨끼리 위아래 간격
            label.LineStyle.Thickness = K;
            s.LegendTextPattern = "{A}";

            chart_PART.Series.Clear();
            chart_PART.Series.Add(s);
            chart_PART.Legend.Visibility = DefaultBoolean.True;
            chart_PART.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            chart_PART.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            chart_PART.Legend.Direction = LegendDirection.LeftToRight;
            chart_PART.Legend.Font = FONT_LEGEND;
            chart_PART.Legend.MarkerSize = new Size(16 * K, 12 * K);
            chart_PART.Legend.Padding.All = 3 * K;
            chart_PART.Legend.Margins.All = 4 * K;
            chart_PART.Legend.Border.Thickness = K;

            S0501.PRINT_CHART(chart_PART, pic_PART);
        }

        // 조각 라벨 '부위명, 비중%' (비중은 프로시저 값 그대로, 5% 미만 조각은 라벨 생략)
        private void chart_PART_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            e.LabelText = e.SeriesPoint.Tag as string ?? "";
        }

        public class MODEL_S1
        {
        }
    }
}
