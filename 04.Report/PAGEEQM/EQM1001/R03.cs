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
    public partial class R03 : DevExpress.XtraReports.UI.XtraReport
    {
        // 2026-10-16 [설비점검계획서] Visual Studio Report Designer 호환을 위한 기본 생성자
        public R03()
        {
            InitializeComponent();
        }

        // 2026-10-16 [설비점검계획서] R03 파라미터 수신 및 데이터 조회 바인딩
        public R03(Dictionary<string, string> param) : this()
        {
            // 2026-10-02 계획서 구분(PLANTP) 추가: G 설비그룹(EQMGRP), E 설비(FANO), 구분이 없으면 기존처럼 설비그룹
            string planType = param.ContainsKey("PLANTP") && param["PLANTP"] == "E" ? "E" : "G";
            string planCode = param.ContainsKey("PLANCD") ? param["PLANCD"] : "";
            if (string.IsNullOrEmpty(planCode))
            {
                throw new InvalidOperationException(planType == "E" ? "설비를 선택해주세요." : "설비그룹을 선택해주세요.");
            }

            ItsMaria maria = new ItsMaria("EQM1001_R03", "CALL_PLAN_RPT");
            maria.AddParam("PLANTP", planType);
            maria.AddParam("PLANCD", planCode);
            DataSet dataSet = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (dataSet == null || dataSet.Tables.Count < 2 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 정기점검 계획이 없습니다.");
            }

            DataRow planHeader = dataSet.Tables[0].Rows[0];
            DataTable planItems = dataSet.Tables[1].Copy();
            // 2026-10-02 하단 개정 이력 (최신순)
            DataTable revHistory = dataSet.Tables.Count > 2 ? dataSet.Tables[2] : null;
            AddBlankRows(planItems, 12);

            BindReportData(planHeader, planItems, revHistory);
        }

        // 2026-10-16 [설비점검계획서] 상단 마스터 정보 및 하단 개정이력 바인딩
        private void BindReportData(DataRow planHeader, DataTable planItems, DataTable revHistory)
        {
            // 상단 설비 마스터 정보 바인딩
            cell_Val_EQMNM.Text = Value(planHeader, "EQMNM");
            cell_Val_EQMSPEC.Text = Value(planHeader, "EQMSPEC");
            cell_Val_EQMCD.Text = Value(planHeader, "EQMCD");
            cell_Val_LINENM.Text = Value(planHeader, "LINENM");
            cell_Val_PROCESSNM.Text = Value(planHeader, "PROCESSNM");

            // 점검 항목 그리드 바인딩
            this.DataSource = planItems;

            // 하단 개정 이력 바인딩 (최신 4건)
            BindRevHistory(revHistory);
        }

        // 2026-10-16 [설비점검계획서] 하단 개정이력 바인딩 (최신 4건)
        private void BindRevHistory(DataTable revHistory)
        {
            XRLabel[] arrRevNo = new XRLabel[] { cell_Rev_No0, cell_Rev_No1, cell_Rev_No2, cell_Rev_No3 };
            XRLabel[] arrRevText = new XRLabel[] { cell_Rev_Text0, cell_Rev_Text1, cell_Rev_Text2, cell_Rev_Text3 };
            XRLabel[] arrRevWriter = new XRLabel[] { cell_Rev_Writer0, cell_Rev_Writer1, cell_Rev_Writer2, cell_Rev_Writer3 };
            XRLabel[] arrRevApprover = new XRLabel[] { cell_Rev_Approver0, cell_Rev_Approver1, cell_Rev_Approver2, cell_Rev_Approver3 };

            int historyCnt = revHistory == null ? 0 : Math.Min(revHistory.Rows.Count, 4);
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                int historyIndex = rowIndex - (4 - historyCnt);
                DataRow history = historyIndex >= 0 ? revHistory.Rows[historyIndex] : null;
                if (history != null)
                {
                    arrRevNo[rowIndex].Text = Value(history, "REVNUM");
                    arrRevText[rowIndex].Text = (Value(history, "REVDATE") + " " + Value(history, "REMARK")).Trim();
                    arrRevWriter[rowIndex].Text = Value(history, "REQEMPNM");
                    arrRevApprover[rowIndex].Text = Value(history, "APRVEMPNM");
                }
                else
                {
                    arrRevNo[rowIndex].Text = "";
                    arrRevText[rowIndex].Text = "";
                    arrRevWriter[rowIndex].Text = "";
                    arrRevApprover[rowIndex].Text = "";
                }
            }
        }

        private static string Value(DataRow row, string fieldName)
        {
            return row.Table.Columns.Contains(fieldName) && row[fieldName] != DBNull.Value ? row[fieldName].ToString() : "";
        }

        private static void AddBlankRows(DataTable table, int minimumRows)
        {
            while (table.Rows.Count < minimumRows)
            {
                DataRow row = table.NewRow();
                row["NO"] = DBNull.Value;
                table.Rows.Add(row);
            }
        }

        public class MODEL_S1
        {
        }
    }

    // R03A 호출 호환용 파생 클래스
    public class R03A : R03
    {
        public R03A(Dictionary<string, string> param) : base(param) { }
    }
}
