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
    /// 2026-11-27 [설비고장율 현황] 웹 EQM1001_S05 연간 고장 목표대비 달성 탭 그래프 출력 (A4 가로 1장)
    /// 데이터 = EQM1001_S05 LIST_CHART (화면과 같은 조회: 목표, 평균, 1~12월)
    /// 막대 = 설비 비가동시간(hr), 선 = 비가동시간 점유율(%)·목표(%), 표시 규칙은 화면 EQM1001_S05.js 와 같음 (S0502 도 SET_CHART 사용)
    /// 2026-11-27 PDF 에서 차트가 96dpi 그림으로 들어가 글자가 뭉개짐 → 차트를 K배 크기·K배 글꼴로 그림을 만들어 같은 자리 그림 상자에 줄여 넣음 (PRINT_CHART)
    /// </summary>
    public partial class S0501 : XtraReport
    {
        internal const double GOAL_RATE = 0.75;   // 목표 없을 때 기본 목표 점유율 (화면 EQM1001_S05.js 와 같은 값)
        internal const int K = 3;   // 출력 그림 배율 (96dpi x 3 = 288dpi)
        const string BAR_NAME = "설비 비가동시간";
        static readonly Font FONT_TEXT = new Font("맑은 고딕", 9F * K);
        static readonly Font FONT_LABEL = new Font("맑은 고딕", 8.5F * K, FontStyle.Bold);
        static readonly Color LABEL_BACK = Color.FromArgb(225, Color.White);   // 라벨 뒤 선이 비쳐 겹쳐 보이지 않게 흰 바탕

        // 2026-11-27 [설비고장율 현황] Visual Studio Report Designer 호환을 위한 기본 생성자
        public S0501()
        {
            InitializeComponent();
        }

        // 2026-11-27 [설비고장율 현황] 조회년도·작업장·공정·라인 수신 → 목표·평균·1~12월 그래프
        public S0501(Dictionary<string, string> param) : this()
        {
            DataTable dt = CALL_S05(param, "LIST_CHART").Tables[0];
            if (dt.Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 그래프 데이터가 없습니다.");
            }

            DataRow first = dt.Rows[0];
            double goalRate = NUM(first, "GOALRATE") ?? GOAL_RATE;
            double? goalHrInput = NUM(first, "GOALHR");
            string syear = PARAM(param, "SYEAR");
            string nowYear = DateTime.Now.ToString("yyyy");
            int curMM = string.CompareOrdinal(syear, nowYear) < 0 ? 12 : (syear == nowYear ? DateTime.Now.Month : 0);   // 현재 월 (지난 해는 12월)

            List<string> args = new List<string>();
            List<double?> hr = new List<double?>();
            List<double?> rate = new List<double?>();
            List<double> goals = new List<double>();
            List<Color> colors = new List<Color>();
            double maxHr = goalHrInput ?? 0D, maxRate = goalRate, sumWork = 0D;
            int cntWork = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow r = dt.Rows[i];
                args.Add(TEXT(r, "GUBUN"));
                hr.Add(NUM(r, "NONHR"));
                rate.Add(NUM(r, "NONRATE"));
                goals.Add(goalRate);
                colors.Add(ColorTranslator.FromHtml(i == 0 ? "#F2F2F2" : (i == 1 ? "#FFC000" : (i - 1 == curMM ? "#F8CBAD" : "#D8E4BC"))));
                maxHr = Math.Max(maxHr, NUM(r, "NONHR") ?? 0D);
                maxRate = Math.Max(maxRate, NUM(r, "NONRATE") ?? 0D);
                double work = NUM(r, "WORKHR") ?? 0D;
                if (i >= 2 && work > 0)
                {
                    sumWork += work;
                    cntWork++;
                }
            }
            double workHr = cntWork > 0 ? sumWork / cntWork : 0D;

            // 목표 막대 = 라인 년 목표 비가동시간 (없으면 월 평균 가동시간의 목표 점유율 만큼, 가동시간도 없으면 막대 없음)
            double? goalHr = goalHrInput;
            if (goalHr == null && workHr > 0)
            {
                goalHr = goalRate / (100D / workHr);
            }
            if (goalHr != null)
            {
                hr[0] = Math.Floor(goalHr.Value);
                rate[0] = goalRate;
            }

            lbl_TITLE.Text = "■ " + TEXT(first, "TITLE");
            SET_CHART(chart_RATE, args, hr, rate, goals, colors, maxHr, maxRate, workHr);
            PRINT_CHART(chart_RATE, pic_RATE);
        }

        // 2026-11-27 [설비고장율 현황] 차트를 K배 크기로 그림을 만들어 그림 상자에 넣고 차트는 숨김 (PDF 글자 선명하게, S0502·S0503 도 사용)
        internal static void PRINT_CHART(XRChart chart, XRPictureBox pic)
        {
            SizeF size = chart.SizeF;
            Band band = chart.Band;
            float bandHeight = band != null ? band.HeightF : 0F;   // 차트를 키우면 밴드도 따라 커지므로 원래 높이로 되돌림
            chart.SizeF = new SizeF(size.Width * K, size.Height * K);
            pic.Image = chart.ToImage();
            chart.SizeF = size;
            if (band != null)
            {
                band.HeightF = bandHeight;
            }
            chart.Visible = false;
        }

        // 2026-11-27 [설비고장율 현황] 비가동시간 막대 + 점유율·목표 선 (탭1·탭2 공통)
        // 오른쪽 축은 화면처럼 가동시간 기준으로 왼쪽 축에 맞춤 (막대 1hr = 100 / 가동시간 %), 점유율 라벨은 목표 초과 빨강·이하 파랑
        internal static void SET_CHART(XRChart chart, List<string> args, List<double?> hr, List<double?> rate, List<double> goals, List<Color> colors, double maxHr, double maxRate, double workHr)
        {
            Series bar = new Series(BAR_NAME, ViewType.Bar);
            Series line = new Series("비가동시간 점유율(고장시간/가동시간)", ViewType.Line);
            Series goal = new Series("목표", ViewType.Line);
            Series over = new Series("목표 초과", ViewType.Point);
            Series under = new Series("목표 이하", ViewType.Point);
            Series[] all = { bar, line, goal, over, under };
            foreach (Series s in all)
            {
                s.ArgumentScaleType = ScaleType.Qualitative;
            }

            // 값 없는 칸은 막대 빈 점, 점유율 선은 점을 빼서 앞뒤 값끼리 이어짐 (화면 connectNull)
            for (int i = 0; i < args.Count; i++)
            {
                SeriesPoint p = new SeriesPoint(args[i], hr[i] ?? 0D);
                p.IsEmpty = hr[i] == null;
                p.Color = colors[i];
                bar.Points.Add(p);
                goal.Points.Add(new SeriesPoint(args[i], goals[i]));
                if (rate[i] != null)
                {
                    line.Points.Add(new SeriesPoint(args[i], rate[i].Value));
                    (rate[i].Value > goals[i] ? over : under).Points.Add(new SeriesPoint(args[i], rate[i].Value));
                }
            }

            SideBySideBarSeriesView barView = (SideBySideBarSeriesView)bar.View;
            barView.Color = ColorTranslator.FromHtml("#D8E4BC");
            barView.FillStyle.FillMode = FillMode.Solid;
            barView.Border.Visibility = DefaultBoolean.True;
            barView.Border.Color = Color.Gray;
            barView.Border.Thickness = K;
            barView.BarWidth = 0.6;
            SET_LABEL(bar, "{V}hr", Color.Black);
            bar.Label.BackColor = LABEL_BACK;
            ((BarSeriesLabel)bar.Label).Position = BarSeriesLabelPosition.TopInside;
            ((BarSeriesLabel)bar.Label).Indent = 3 * K;

            SET_LINE(line, Color.Red, true);
            SET_LINE(goal, Color.Blue, false);
            SET_RATE_LABEL(over, Color.Red);
            SET_RATE_LABEL(under, Color.Blue);

            chart.Series.Clear();
            chart.Series.AddRange(all);
            chart.CustomDrawSeriesPoint -= HIDE_ZERO_HR;
            chart.CustomDrawSeriesPoint += HIDE_ZERO_HR;

            chart.Legend.Visibility = DefaultBoolean.True;
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
            chart.Legend.Direction = LegendDirection.LeftToRight;
            chart.Legend.Font = FONT_TEXT;
            chart.Legend.MarkerSize = new Size(20 * K, 16 * K);
            chart.Legend.Padding.All = 3 * K;
            chart.Legend.Margins.All = 5 * K;
            chart.Legend.Border.Thickness = K;

            XYDiagram diagram = chart.Diagram as XYDiagram;
            if (diagram == null)
            {
                return;
            }
            diagram.AxisX.Label.Font = FONT_TEXT;
            diagram.AxisX.Label.Staggered = false;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
            diagram.AxisY.Label.Font = FONT_TEXT;
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = true;
            diagram.AxisY.GridLines.Visible = true;
            diagram.Margins.All = 5 * K;
            foreach (Axis axis in new Axis[] { diagram.AxisX, diagram.AxisY })
            {
                SCALE_AXIS(axis);
            }

            SecondaryAxisY axisY2 = new SecondaryAxisY("Y2");
            axisY2.Label.Font = FONT_TEXT;
            axisY2.Label.TextPattern = "{V:0.##}%";
            axisY2.WholeRange.AlwaysShowZeroLevel = true;
            SCALE_AXIS(axisY2);
            diagram.SecondaryAxesY.Clear();
            diagram.SecondaryAxesY.Add(axisY2);
            foreach (Series s in new Series[] { line, goal, over, under })
            {
                ((XYDiagramSeriesViewBase)s.View).AxisY = axisY2;
            }

            if (workHr > 0)
            {
                double ratePerHr = 100D / workHr;   // 가동시간에서 비가동 1hr 의 점유율(%)
                double yMax = Math.Max(maxHr, maxRate / ratePerHr) * 1.15;
                if (yMax > 0)
                {
                    SET_RANGE(diagram.AxisY, yMax);
                    SET_RANGE(axisY2, yMax * ratePerHr);
                }
            }
            else if (maxRate > 0)
            {
                SET_RANGE(axisY2, maxRate * 1.15);
            }
        }

        // 2026-11-27 [설비고장율 현황] EQM1001_S05 프로시저 호출 (화면 조회조건 그대로)
        internal static DataSet CALL_S05(Dictionary<string, string> param, string callType)
        {
            ItsMaria maria = new ItsMaria("EQM1001_S05", callType);
            foreach (string key in new string[] { "SYEAR", "LINECD", "EQMTP", "EQMGROUP1", "SDATE", "EDATE" })
            {
                maria.AddParam(key, PARAM(param, key));
            }
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }
            if (ds == null || ds.Tables.Count == 0)
            {
                throw new InvalidOperationException("출력할 그래프 데이터가 없습니다.");
            }
            return ds;
        }

        // 막대 0hr·빈 칸은 라벨 없음 (화면과 같음)
        private static void HIDE_ZERO_HR(object sender, CustomDrawSeriesPointEventArgs e)
        {
            if (e.Series.Name == BAR_NAME && (e.SeriesPoint.IsEmpty || e.SeriesPoint.Values[0] == 0D))
            {
                e.LabelText = "";
            }
        }

        private static void SET_LINE(Series s, Color color, bool fillMarker)
        {
            LineSeriesView view = (LineSeriesView)s.View;
            view.Color = color;
            view.LineStyle.DashStyle = DashStyle.Dash;
            view.LineStyle.Thickness = 2 * K;
            view.MarkerVisibility = DefaultBoolean.True;
            view.LineMarkerOptions.Kind = MarkerKind.Circle;
            view.LineMarkerOptions.Size = 7 * K;
            view.LineMarkerOptions.Color = fillMarker ? color : Color.White;   // 목표는 속이 빈 동그라미
            view.LineMarkerOptions.BorderColor = color;
            view.LineMarkerOptions.BorderVisible = true;
            s.LabelsVisibility = DefaultBoolean.False;
        }

        // 점유율 라벨 전용 점 계열 (표식 없이 라벨만, 범례 제외)
        private static void SET_RATE_LABEL(Series s, Color color)
        {
            PointSeriesView view = (PointSeriesView)s.View;
            view.Color = Color.Transparent;
            view.PointMarkerOptions.BorderVisible = false;
            s.ShowInLegend = false;
            SET_LABEL(s, "{V:0.##}%", color);
            s.Label.BackColor = LABEL_BACK;
            ((PointSeriesLabel)s.Label).LineLength = 6 * K;
        }

        // 축 선·눈금·격자 두께와 길이를 K배로 (그림을 줄였을 때 화면 굵기와 같게)
        private static void SCALE_AXIS(Axis axis)
        {
            axis.Thickness = K;
            axis.Tickmarks.Thickness = K;
            axis.Tickmarks.MinorThickness = K;
            axis.Tickmarks.Length = 5 * K;
            axis.Tickmarks.MinorLength = 2 * K;
            axis.GridLines.LineStyle.Thickness = K;
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

        // 축 범위 0 ~ max, 눈금 간격은 8칸 안팎의 보기 좋은 값 (1·2·2.5·5 x 10^n)
        private static void SET_RANGE(AxisBase axis, double max)
        {
            double raw = max / 8D;
            double pow = Math.Pow(10D, Math.Floor(Math.Log10(raw)));
            double step = pow * 10D;
            foreach (double f in new double[] { 1D, 2D, 2.5D, 5D })
            {
                if (pow * f >= raw)
                {
                    step = pow * f;
                    break;
                }
            }
            axis.NumericScaleOptions.AutoGrid = false;
            axis.NumericScaleOptions.GridSpacing = step;
            axis.WholeRange.SetMinMaxValues(0D, max);
            axis.WholeRange.SideMarginsValue = 0D;
            axis.VisualRange.SetMinMaxValues(0D, max);
            axis.VisualRange.SideMarginsValue = 0D;
        }

        internal static string PARAM(Dictionary<string, string> param, string key)
        {
            return param.ContainsKey(key) && param[key] != null ? param[key].Trim() : "";
        }

        internal static string TEXT(DataRow r, string col)
        {
            return r.Table.Columns.Contains(col) && r[col] != DBNull.Value ? r[col].ToString() : "";
        }

        internal static double? NUM(DataRow r, string col)
        {
            double v;
            return double.TryParse(TEXT(r, col), out v) ? v : (double?)null;
        }

        public class MODEL_S1
        {
        }
    }
}
