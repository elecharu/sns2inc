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
            AddBlankRows(chkItems, 12);

            BindReportData(chkHeader, chkItems);
        }

        // 2026-11-06 [설비점검 시트] 상단 설비·점검일자 및 점검항목 바인딩
        private void BindReportData(DataRow chkHeader, DataTable chkItems)
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
