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
        // 2026-11-05 [설비등급 평가표] Visual Studio Report Designer 호환을 위한 기본 생성자
        public R01()
        {
            InitializeComponent();
        }

        // 2026-11-05 [설비등급 평가표] 평가키 수신 및 평가 정보·평가항목·설비등급 기준 조회
        public R01(Dictionary<string, string> param) : this()
        {
            string evalKey = param.ContainsKey("EQMGRADEEVALKEY") ? param["EQMGRADEEVALKEY"] : "";
            if (string.IsNullOrEmpty(evalKey))
            {
                throw new InvalidOperationException("평가이력을 선택해주세요.");
            }

            ItsMaria maria = new ItsMaria("MST1005_R01", "CALL_EVAL_RPT");
            maria.AddParam("EQMGRADEEVALKEY", evalKey);
            DataSet dataSet = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (dataSet == null || dataSet.Tables.Count < 3 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 평가이력이 없습니다.");
            }

            DataRow evalHeader = dataSet.Tables[0].Rows[0];
            DataTable evalItems = dataSet.Tables[1].Copy();
            DataTable gradeStd = dataSet.Tables[2];

            BindReportData(evalHeader, evalItems, gradeStd);
        }

        // 2026-11-05 [설비등급 평가표] 상단 설비 정보·결재, 평가항목별 평가기준, 하단 합계·설비등급 표 바인딩
        private void BindReportData(DataRow evalHeader, DataTable evalItems, DataTable gradeStd)
        {
            string[] arrDate = Value(evalHeader, "EVALDATE").Split('-');
            xrLabelEvalDate.Text = arrDate.Length == 3 ? "평가일자 : " + arrDate[0] + "년 " + arrDate[1] + "월 " + arrDate[2] + "일" : "";

            cell_Val_EQMNM.Text = Value(evalHeader, "EQMNM");
            cell_Val_FANO.Text = Value(evalHeader, "FANO");
            cell_Val_EQMNM_DETAIL.Text = Value(evalHeader, "EQMNM_DETAIL");
            cell_Val_MKDATE.Text = Value(evalHeader, "MKDATE");
            cell_Val_LINENM.Text = Value(evalHeader, "LINENM");
            cell_Val_MNGNM.Text = Value(evalHeader, "MNGNM");

            // 결재 : 작성 = 평가자, 승인 = 승인자 (승인 전이면 빈칸)
            xrLabelAprvWrite.Text = Value(evalHeader, "EMPNM");
            xrLabelAprvApprove.Text = Value(evalHeader, "APRVTIME") == "" ? "" : Value(evalHeader, "APRVEMPNM");

            // 결재 칸이 비어 있으면 양식처럼 대각선 표시
            xrLineAprvWrite.Visible = xrLabelAprvWrite.Text == "";
            xrLineAprvReview.Visible = xrLabelAprvReview.Text == "";
            xrLineAprvApprove.Visible = xrLabelAprvApprove.Text == "";
            xrLabelTotal.Text = Value(evalHeader, "TOTSCORE");

            // 구분은 양식처럼 한 글자씩 세로로 표시
            foreach (DataRow row in evalItems.Rows)
            {
                row["GMTPNM"] = string.Join("\r\n", Value(row, "GMTPNM").ToCharArray());
            }

            // 설비등급 표 제목은 양식처럼 마지막 평가항목 아래 칸에 표시 (마지막 항목의 병합 칸이 제목 줄까지 이어짐)
            evalItems.Columns.Add("ROWTP", typeof(string));
            if (evalItems.Rows.Count > 0)
            {
                DataRow gradeTitle = evalItems.NewRow();
                gradeTitle.ItemArray = evalItems.Rows[evalItems.Rows.Count - 1].ItemArray;
                gradeTitle["CRITERIA"] = "설비 등급 표";
                gradeTitle["SELYN"] = "N";
                gradeTitle["ROWTP"] = "T";
                evalItems.Rows.Add(gradeTitle);
            }
            this.DataSource = evalItems;

            BindGrade(gradeStd, Value(evalHeader, "EQMGRADE"));
        }

        // 2026-11-05 [설비등급 평가표] 하단 설비등급 표 (최대 5등급, 평가등급 강조)
        private void BindGrade(DataTable gradeStd, string evalGrade)
        {
            XRTableCell[] arrNm = new XRTableCell[] { cell_Grade_Nm0, cell_Grade_Nm1, cell_Grade_Nm2, cell_Grade_Nm3, cell_Grade_Nm4 };
            XRTableCell[] arrScore = new XRTableCell[] { cell_Grade_Score0, cell_Grade_Score1, cell_Grade_Score2, cell_Grade_Score3, cell_Grade_Score4 };
            XRTableCell[] arrMng = new XRTableCell[] { cell_Grade_Mng0, cell_Grade_Mng1, cell_Grade_Mng2, cell_Grade_Mng3, cell_Grade_Mng4 };
            XRTableCell[] arrCycle = new XRTableCell[] { cell_Grade_Cycle0, cell_Grade_Cycle1, cell_Grade_Cycle2, cell_Grade_Cycle3, cell_Grade_Cycle4 };

            for (int i = 0; i < arrNm.Length; i++)
            {
                DataRow grade = i < gradeStd.Rows.Count ? gradeStd.Rows[i] : null;
                arrNm[i].Text = grade == null ? "" : Value(grade, "EQMGRADENM");
                arrScore[i].Text = grade == null ? "" : Value(grade, "SCORENM");
                arrMng[i].Text = grade == null ? "" : Value(grade, "MNGNM");
                arrCycle[i].Text = grade == null ? "" : Value(grade, "CHKCYCLE2");

                if (grade != null && Value(grade, "EQMGRADE") == evalGrade)
                {
                    arrNm[i].BackColor = Color.FromArgb(155, 194, 230);
                    arrNm[i].StylePriority.UseBackColor = true;
                }
            }
        }

        private static string Value(DataRow row, string fieldName)
        {
            return row.Table.Columns.Contains(fieldName) && row[fieldName] != DBNull.Value ? row[fieldName].ToString() : "";
        }

        public class MODEL_S1
        {
        }
    }
}
