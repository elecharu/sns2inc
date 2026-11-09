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
    public partial class S04A : DevExpress.XtraReports.UI.XtraReport
    {
        // 2026-11-06 [설비점검 시트] Visual Studio Report Designer 호환을 위한 기본 생성자
        public S04A()
        {
            InitializeComponent();
        }

        // 2026-11-06 [설비점검 시트] S04A 파라미터 수신 및 선택한 점검이력 조회 바인딩
        public S04A(Dictionary<string, string> param) : this()
        {
            string chkRstKey = param.ContainsKey("CHKRSTKEY") ? param["CHKRSTKEY"] : "";
            if (string.IsNullOrEmpty(chkRstKey))
            {
                throw new InvalidOperationException("출력할 점검이력을 선택해주세요.");
            }

            ItsMaria maria = new ItsMaria("EQM1001_S04", "CALL_CHKRST_RPT");
            maria.AddParam("CHKRSTKEY", chkRstKey);
            DataSet dataSet = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (dataSet == null || dataSet.Tables.Count < 2 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 점검이력이 없습니다.");
            }

            DataRow chkHeader = dataSet.Tables[0].Rows[0];
            DataTable chkItems = dataSet.Tables[1].Copy();
            // 2026-11-09 하단 개정 이력 (해당 설비의 설비별·설비그룹 계획 전체 REV, 최신순)
            DataTable revHistory = dataSet.Tables.Count > 2 ? dataSet.Tables[2] : null;
            AddBlankRows(chkItems, 12);

            BindReportData(chkHeader, chkItems, revHistory);
        }

        // 2026-11-06 [설비점검 시트] 상단 설비·점검일자 및 점검항목 바인딩
        // 2026-11-09 [설비점검 시트] 하단 확인·서명란 및 개정이력(ReportFooter) 복원
        private void BindReportData(DataRow chkHeader, DataTable chkItems, DataTable revHistory)
        {
            // 상단 설비 정보·점검일자 바인딩
            cell_Val_EQMNM.Text = Value(chkHeader, "EQMNM");
            cell_Val_EQMSPEC.Text = Value(chkHeader, "EQMSPEC");
            cell_Val_EQMCD.Text = Value(chkHeader, "EQMCD");
            cell_Val_CHKDATE.Text = Value(chkHeader, "CHKDATE");
            cell_Val_LINENM.Text = Value(chkHeader, "LINENM");
            cell_Val_PROCESSNM.Text = Value(chkHeader, "PROCESSNM");

            // 점검 항목 그리드 바인딩
            this.DataSource = chkItems;

            // 2026-11-09 하단 서명란: 점검자(점검실적), 담당(설비마스터 점검담당사번 사원명, 없으면 사번)
            xrLabelInspectorSign.Text = Value(chkHeader, "CHKEMPNM");
            xrLabelManagerSign.Text = Value(chkHeader, "MNGEMPNM");

            // 하단 개정 이력 바인딩 (최신 4건)
            BindRevHistory(revHistory);
        }

        // 2026-11-09 [설비점검 시트] 하단 개정이력 바인딩 (최신 4건, R03과 동일 배치, 개정 이력 칸은 [구분] 개정내용만 표시)
        private void BindRevHistory(DataTable revHistory)
        {
            XRTableCell[] arrRevNo = new XRTableCell[] { cell_Rev_No0, cell_Rev_No1, cell_Rev_No2, cell_Rev_No3 };
            XRTableCell[] arrRevText = new XRTableCell[] { cell_Rev_Text0, cell_Rev_Text1, cell_Rev_Text2, cell_Rev_Text3 };
            XRTableCell[] arrRevWriter = new XRTableCell[] { cell_Rev_Writer0, cell_Rev_Writer1, cell_Rev_Writer2, cell_Rev_Writer3 };
            XRTableCell[] arrRevApprover = new XRTableCell[] { cell_Rev_Approver0, cell_Rev_Approver1, cell_Rev_Approver2, cell_Rev_Approver3 };

            int historyCnt = revHistory == null ? 0 : Math.Min(revHistory.Rows.Count, 4);
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                int historyIndex = rowIndex - (4 - historyCnt);
                DataRow history = historyIndex >= 0 ? revHistory.Rows[historyIndex] : null;
                if (history != null)
                {
                    arrRevNo[rowIndex].Text = Value(history, "REVNUM");
                    arrRevText[rowIndex].Text = ("[" + Value(history, "PLANTPNM") + "] " + Value(history, "REMARK")).Trim();
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
}
