using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    /// <summary>
    /// 2026-11-06 [년 설비고장율 현황] 웹 EQM1001_R06 그래프 화면 출력 (A4 가로 1장)
    /// 데이터 = EQM1001_R06 LIST_CHART (화면과 같은 조회, 연도 평균 6칸 + 1~12월)
    /// 위 = 설비 비가동시간(막대) + 점유율(점선) + 목표 0.75%(점선), 아래 = 호출건수(막대) + 평균수리시간(점선)
    /// </summary>
    public partial class R0601 : XtraReport
    {
        const double GOAL_RATE = 0.75;   // 목표 점유율 (화면 EQM1001_R06.js 와 같은 값)
        static readonly Font FONT_TEXT = new Font("맑은 고딕", 9F);
        static readonly Font FONT_LABEL = new Font("맑은 고딕", 8F, FontStyle.Bold);
        static readonly Font FONT_TITLE = new Font("맑은 고딕", 13F, FontStyle.Bold);

        public R0601()
        {
            InitializeComponent();
        }

        public R0601(Dictionary<string, string> param) : this()
        {
            string year = param.ContainsKey("SYEAR") ? param["SYEAR"] : "";
            if (year == "")
            {
                throw new InvalidOperationException("조회년도를 선택하세요.");
            }

            ItsMaria maria = new ItsMaria("EQM1001_R06", "LIST_CHART");
            maria.AddParam("SYEAR", year);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 데이터가 없습니다.");
            }

            lbl_TITLE.Text = "■ " + year + "년 설비 고장율 현황";
            SET_CHART_RATE(chart_RATE, ds.Tables[0]);
            SET_CHART_CNT(chart_CNT, ds.Tables[0]);
        }

        // 설비 고장율: 비가동시간(hr, 막대) + 점유율(%, 오른쪽 축) + 목표(%, 오른쪽 축) (R0602 그래프 페이지도 사용)
        internal static void SET_CHART_RATE(XRChart chartRate, DataTable dt)
        {
            Series nonHr = NewBar("설비 비가동시간", YEAR_COLOR(dt, Color.FromArgb(0xb7, 0xbd, 0xf0)), "{V:0.0}hr");
            Series nonRate = NewLine("비가동시간 점유율(고장시간/가동시간)", Color.Red, true, "{V:0.00}%");
            Series goal = NewLine("목표(" + GOAL_RATE + "% 이하 관리)", Color.Blue, false, "");

            foreach (DataRow r in dt.Rows)
            {
                string arg = ARG(r);
                SET_POINT_COLOR(AddPoint(nonHr, arg, r["NONHR"]), r);
                AddPoint(nonRate, arg, r["NONRATE"]);
                AddPoint(goal, arg, GOAL_RATE);
            }

            SET_CHART(chartRate, "설비 고장율", nonHr, new Series[] { nonRate, goal });
        }

        // 호출건수: 설비 호출건수(막대) + 평균수리시간(분, 오른쪽 축) (R0602 그래프 페이지도 사용)
        internal static void SET_CHART_CNT(XRChart chartCnt, DataTable dt)
        {
            Series failCnt = NewBar("설비 호출횟수", YEAR_COLOR(dt, Color.FromArgb(0xf6, 0xc7, 0x9a)), "{V:0.#}건");
            Series avgRep = NewLine("평균수리시간", Color.Red, true, "{V:0}분");

            foreach (DataRow r in dt.Rows)
            {
                string arg = ARG(r);
                SET_POINT_COLOR(AddPoint(failCnt, arg, r["FAILCNT"]), r);
                AddPoint(avgRep, arg, r["AVGREPMIN"]);
            }

            SET_CHART(chartCnt, "호출건수", failCnt, new Series[] { avgRep });
        }

        // 막대는 왼쪽 축, 선은 오른쪽 축 (둘 다 0 부터)
        private static void SET_CHART(XRChart chart, string title, Series bar, Series[] lines)
        {
            chart.Series.Clear();
            chart.Series.Add(bar);
            foreach (Series s in lines)
            {
                chart.Series.Add(s);
            }

            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = title;
            chartTitle.Font = FONT_TITLE;
            chart.Titles.Clear();
            chart.Titles.Add(chartTitle);

            chart.Legend.Visibility = DefaultBoolean.True;
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;   // 그래프(목표선)를 가리지 않게 위로
            chart.Legend.Direction = LegendDirection.LeftToRight;
            chart.Legend.Font = FONT_TEXT;

            XYDiagram diagram = chart.Diagram as XYDiagram;
            if (diagram == null)
            {
                return;
            }
            diagram.AxisX.Label.Font = FONT_TEXT;
            diagram.AxisX.Label.Staggered = false;   // 가로축 칸 이름을 한 줄로 (기본은 겹치면 두 줄로 엇갈림)
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            diagram.AxisY.Label.Font = FONT_TEXT;
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = true;
            diagram.AxisY.GridLines.Visible = true;

            SecondaryAxisY axisY2 = new SecondaryAxisY("Y2");
            axisY2.Label.Font = FONT_TEXT;
            axisY2.WholeRange.AlwaysShowZeroLevel = true;
            diagram.SecondaryAxesY.Clear();
            diagram.SecondaryAxesY.Add(axisY2);
            foreach (Series s in lines)
            {
                ((LineSeriesView)s.View).AxisY = axisY2;
            }
        }

        private static Series NewBar(string name, Color color, string labelPattern)
        {
            Series s = new Series(name, ViewType.Bar);
            s.ArgumentScaleType = ScaleType.Qualitative;

            SideBySideBarSeriesView view = (SideBySideBarSeriesView)s.View;
            view.Color = color;
            view.FillStyle.FillMode = FillMode.Solid;
            view.Border.Visibility = DefaultBoolean.True;
            view.Border.Color = Color.Gray;
            view.BarWidth = 0.6;

            SET_LABEL(s, labelPattern, Color.Black);
            return s;
        }

        private static Series NewLine(string name, Color color, bool showLabel, string labelPattern)
        {
            Series s = new Series(name, ViewType.Line);
            s.ArgumentScaleType = ScaleType.Qualitative;

            LineSeriesView view = (LineSeriesView)s.View;
            view.Color = color;
            view.LineStyle.DashStyle = DashStyle.Dash;
            view.LineStyle.Thickness = 2;
            view.MarkerVisibility = DefaultBoolean.True;
            view.LineMarkerOptions.Kind = MarkerKind.Circle;
            view.LineMarkerOptions.Size = 7;
            view.LineMarkerOptions.Color = showLabel ? color : Color.White;   // 목표는 속이 빈 동그라미
            view.LineMarkerOptions.BorderColor = color;
            view.LineMarkerOptions.BorderVisible = true;

            if (showLabel)
            {
                SET_LABEL(s, labelPattern, color);
            }
            else
            {
                s.LabelsVisibility = DefaultBoolean.False;
            }
            return s;
        }

        private static void SET_LABEL(Series s, string pattern, Color color)
        {
            s.LabelsVisibility = DefaultBoolean.True;
            s.Label.TextPattern = pattern;
            s.Label.Font = FONT_LABEL;
            s.Label.TextColor = color;
            s.Label.BackColor = Color.Transparent;
            s.Label.Border.Visibility = DefaultBoolean.False;
            s.Label.LineVisibility = DefaultBoolean.False;
        }

        // 가로축 칸 이름: 연도 평균은 "'21년\n평균" 두 줄 (한 줄이면 옆 칸과 겹침)
        private static string ARG(DataRow r)
        {
            return r["GUBUN"].ToString().Replace(" 평균", "\n평균");
        }

        // 값이 없는 달(조회 시점 이후)은 빈 점으로 두어 가로축 칸은 그대로 남긴다
        private static SeriesPoint AddPoint(Series s, string arg, object value)
        {
            double v;
            if (value == null || value == DBNull.Value || !double.TryParse(value.ToString(), out v))
            {
                SeriesPoint empty = new SeriesPoint(arg, 0D);
                empty.IsEmpty = true;
                s.Points.Add(empty);
                return empty;
            }
            SeriesPoint point = new SeriesPoint(arg, v);
            s.Points.Add(point);
            return point;
        }

        // 막대 연도별 색상: 프로시저 BACKGROUND 값, 없으면 계열 기본 색상
        private static void SET_POINT_COLOR(SeriesPoint point, DataRow r)
        {
            Color color = ROW_COLOR(r);
            if (color != Color.Empty)
            {
                point.Color = color;
            }
        }

        // 범례 막대 색상: 조회년도(마지막 행) 색상, 없으면 기본 색상
        private static Color YEAR_COLOR(DataTable dt, Color defaultColor)
        {
            Color color = dt.Rows.Count > 0 ? ROW_COLOR(dt.Rows[dt.Rows.Count - 1]) : Color.Empty;
            return color != Color.Empty ? color : defaultColor;
        }

        private static Color ROW_COLOR(DataRow r)
        {
            if (!r.Table.Columns.Contains("BACKGROUND") || r["BACKGROUND"] == DBNull.Value || r["BACKGROUND"].ToString() == "")
            {
                return Color.Empty;
            }
            return ColorTranslator.FromHtml(r["BACKGROUND"].ToString());
        }
    }
}
