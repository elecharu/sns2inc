using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DevExpress.XtraReports.UI;

namespace XtraRpt
{
    /// <summary>
    /// 2026-11-27 [설비고장율 현황] 웹 EQM1001_S05 설비별 고장 현황 탭 그래프 출력 (A4 가로 1장)
    /// 데이터 = EQM1001_S05 LIST_EQM_FAIL (화면과 같은 조회: 총 라인 고장 시간 + 라인 설비별, 조회기간)
    /// 목표 = 총 라인은 라인 목표, 설비는 설비 목표(없으면 라인 목표, 그것도 없으면 0.75%), 그래프는 S0501.SET_CHART 와 같음
    /// </summary>
    public partial class S0502 : XtraReport
    {
        // 2026-11-27 [설비고장율 현황] Visual Studio Report Designer 호환을 위한 기본 생성자
        public S0502()
        {
            InitializeComponent();
        }

        // 2026-11-27 [설비고장율 현황] 조회기간·작업장·공정·라인 수신 → 총 라인 + 설비별 그래프
        public S0502(Dictionary<string, string> param) : this()
        {
            DataTable dt = S0501.CALL_S05(param, "LIST_EQM_FAIL").Tables[0];
            if (dt.Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 설비가 없습니다.");
            }

            DataRow first = dt.Rows[0];
            double lineGoal = S0501.NUM(first, "LINEGOALRATE") ?? S0501.GOAL_RATE;
            List<string> args = new List<string> { "총 라인 고장 시간" };
            List<double?> hr = new List<double?> { S0501.NUM(first, "LINENONHR") };
            List<double?> rate = new List<double?> { S0501.NUM(first, "LINENONRATE") };
            List<double> goals = new List<double> { lineGoal };
            List<Color> colors = new List<Color> { ColorTranslator.FromHtml("#E6B8B7") };
            double maxHr = S0501.NUM(first, "LINENONHR") ?? 0D;
            double maxRate = Math.Max(lineGoal, S0501.NUM(first, "LINENONRATE") ?? 0D);
            foreach (DataRow r in dt.Rows)
            {
                double goalRate = S0501.NUM(r, "GOALRATE") ?? S0501.GOAL_RATE;
                args.Add(S0501.TEXT(r, "GUBUN"));
                hr.Add(S0501.NUM(r, "NONHR"));
                rate.Add(S0501.NUM(r, "NONRATE"));
                goals.Add(goalRate);
                colors.Add(ColorTranslator.FromHtml("#D8E4BC"));
                maxHr = Math.Max(maxHr, S0501.NUM(r, "NONHR") ?? 0D);
                maxRate = Math.Max(maxRate, Math.Max(S0501.NUM(r, "NONRATE") ?? 0D, goalRate));
            }

            lbl_TITLE.Text = "■ " + S0501.TEXT(first, "TITLE") + " (" + S0501.PARAM(param, "SDATE") + " ~ " + S0501.PARAM(param, "EDATE") + ")";
            S0501.SET_CHART(chart_RATE, args, hr, rate, goals, colors, maxHr, maxRate, S0501.NUM(first, "WORKHR") ?? 0D);
            S0501.PRINT_CHART(chart_RATE, pic_RATE);
        }

        public class MODEL_S1
        {
        }
    }
}
