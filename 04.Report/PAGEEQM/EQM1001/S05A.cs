using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class S05A : XtraReport
    {
        private const float ReportWidth = 731F;

        public S05A(Dictionary<string, string> param)
        {
            InitializeComponent();

            // 2026-10-02 계획서 구분(PLANTP) 추가: G 설비그룹(EQMGRP), E 설비(FANO), 구분이 없으면 기존처럼 설비그룹
            string planType = param.ContainsKey("PLANTP") && param["PLANTP"] == "E" ? "E" : "G";
            // 2026-10-06 R03에서 선택한 계획코드·REV로 출력
            string planCode = param.ContainsKey("PLANCD") ? param["PLANCD"] : "";
            if (string.IsNullOrEmpty(planCode))
            {
                throw new InvalidOperationException(planType == "E" ? "설비를 선택해주세요." : "설비그룹을 선택해주세요.");
            }

            ItsMaria maria = CreateMaria("EQM1001_R03", "CALL_PLAN_RPT");
            maria.AddParam("PLANTP", planType);
            maria.AddParam("PLANCD", planCode);
            maria.AddParam("REVNUM", param.ContainsKey("REVNUM") ? param["REVNUM"] : "");
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
            // 2026-10-02 하단 개정 이력 (최근 승인 4건, 최신순)
            DataTable revHistory = dataSet.Tables.Count > 2 ? dataSet.Tables[2] : null;
            AddBlankRows(planItems, 12);

            BuildReport(planHeader, planItems, revHistory);
        }

        private static ItsMaria CreateMaria(string procedureName, string callType)
        {
            ItsMaria maria = new ItsMaria(procedureName, callType);
            maria.DbServer = "211.43.15.98";
            maria.DbPort = "33061";
            maria.DbUser = "root";
            maria.DbPass = ItsSecurity.DecDES("f4jHrVI/NLGr48fLMegkWw==");
            maria.DbName = "MES_SNS2";
            return maria;
        }

        private void BuildReport(DataRow planHeader, DataTable planItems, DataTable revHistory)        {
            Dpi = 100F;
            PaperKind = PaperKind.A4;
            PageWidth = 827;
            PageHeight = 1169;
            Margins = new Margins(48, 48, 35, 35);

            TopMarginBand topMargin = new TopMarginBand();
            topMargin.HeightF = 20F;
            BottomMarginBand bottomMargin = new BottomMarginBand();
            bottomMargin.HeightF = 20F;
            PageHeaderBand pageHeader = new PageHeaderBand();
            pageHeader.HeightF = 142F;
            DetailBand detail = new DetailBand();
            detail.HeightF = 43F;
            ReportFooterBand reportFooter = new ReportFooterBand();
            reportFooter.HeightF = 128F;
            PageFooterBand pageFooter = new PageFooterBand();
            pageFooter.HeightF = 18F;

            pageHeader.Controls.Add(CreateTitle());
            pageHeader.Controls.Add(CreatePlanInfo(planHeader));
            pageHeader.Controls.Add(CreateDetailHeader());
            detail.Controls.Add(CreateDetailRow());
            // 2026-10-02 하단 개정 이력 칸에 승인 이력 표시
            reportFooter.Controls.AddRange(CreateConfirmationControls(revHistory));
            pageFooter.Controls.Add(CreateFooterLabel());

            DataSource = planItems;
            Bands.AddRange(new Band[] { topMargin, bottomMargin, pageHeader, detail, reportFooter, pageFooter });
        }

        private XRLabel CreateTitle()
        {
            XRLabel label = new XRLabel();
            label.LocationFloat = new PointFloat(0F, 0F);
            label.SizeF = new SizeF(ReportWidth, 37F);
            label.Font = new Font("맑은 고딕", 14F, FontStyle.Bold);
            label.Text = "제조설비 정기 점검 시트";
            label.TextAlignment = TextAlignment.MiddleCenter;
            return label;
        }

        private XRTable CreatePlanInfo(DataRow row)
        {
            XRTable table = CreateTable(0F, 37F, ReportWidth, 75F, 9F);
            // 2026-10-02 상단 설비 정보: 설비명(설비그룹명 또는 설비명), 적용LINE은 작업장명으로 표시
            table.Rows.Add(CreateInfoRow("설비명", Value(row, "EQMNM"), "설비규격", Value(row, "EQMSPEC")));
            table.Rows.Add(CreateInfoRow("설비번호", Value(row, "EQMCD"), "점검일자", ""));
            table.Rows.Add(CreateInfoRow("적용LINE", Value(row, "LINENM"), "적용공정", Value(row, "PROCESSNM")));
            return table;
        }

        private XRTableRow CreateInfoRow(string firstLabel, string firstValue, string secondLabel, string secondValue)
        {
            XRTableRow row = new XRTableRow();
            row.Cells.Add(CreateCell(firstLabel, 112F, true));
            row.Cells.Add(CreateCell(firstValue, 253F, false));
            row.Cells.Add(CreateCell(secondLabel, 112F, true));
            row.Cells.Add(CreateCell(secondValue, 254F, false));
            return row;
        }

        private XRTable CreateDetailHeader()
        {
            XRTable table = CreateTable(0F, 112F, ReportWidth, 30F, 9F);
            XRTableRow row = new XRTableRow();
            row.Cells.Add(CreateCell("No", 35F, true));
            row.Cells.Add(CreateCell("점검항목", 130F, true));
            row.Cells.Add(CreateCell("점검내용", 250F, true));
            row.Cells.Add(CreateCell("점검기기", 70F, true));
            row.Cells.Add(CreateCell("점검판정", 75F, true));
            row.Cells.Add(CreateCell("완료\r\n확인", 65F, true));
            row.Cells.Add(CreateCell("특이사항", 106F, true));
            table.Rows.Add(row);
            return table;
        }

        private XRTable CreateDetailRow()
        {
            XRTable table = CreateTable(0F, 0F, ReportWidth, 43F, 8.5F);
            XRTableRow row = new XRTableRow();
            row.Cells.Add(CreateDataCell("NO", 35F, TextAlignment.MiddleCenter));
            row.Cells.Add(CreateDataCell("CHKITEM", 130F, TextAlignment.MiddleLeft));
            row.Cells.Add(CreateDataCell("CHKCONTENT", 250F, TextAlignment.MiddleLeft));
            row.Cells.Add(CreateDataCell("CHKDEVICE", 70F, TextAlignment.MiddleCenter));
            row.Cells.Add(CreateDataCell("CHKRESULT", 75F, TextAlignment.MiddleCenter));
            row.Cells.Add(CreateDataCell("CONFIRM", 65F, TextAlignment.MiddleCenter));
            row.Cells.Add(CreateDataCell("REMARK", 106F, TextAlignment.MiddleLeft));
            table.Rows.Add(row);
            return table;
        }

        private XRControl[] CreateConfirmationControls(DataTable revHistory)
        {
            const float y = 4F;
            const float height = 120F;
            const float confirmWidth = 68F;
            const float inspectorWidth = 95F;
            const float managerWidth = 95F;
            const float historyLabelWidth = 90F;
            const float revisionNoWidth = 25F;
            const float revisionContentWidth = 228F;
            const float writerWidth = 65F;
            const float approverWidth = 65F;
            const float signatureHeaderHeight = 48F;
            const float revisionRowHeight = 22F;
            const float revisionHeaderHeight = 32F;
            float historyX = confirmWidth + inspectorWidth + managerWidth;
            float revisionX = historyX + historyLabelWidth;
            List<XRControl> controls = new List<XRControl>();

            controls.Add(CreateFooterBox(0F, y, confirmWidth, height, "확인", false));
            controls.Add(CreateFooterBox(confirmWidth, y, inspectorWidth, signatureHeaderHeight, "점검자", false));
            controls.Add(CreateFooterBox(confirmWidth, y + signatureHeaderHeight, inspectorWidth, height - signatureHeaderHeight, "", false));
            controls.Add(CreateFooterBox(confirmWidth + inspectorWidth, y, managerWidth, signatureHeaderHeight, "담당", false));
            controls.Add(CreateFooterBox(confirmWidth + inspectorWidth, y + signatureHeaderHeight, managerWidth, height - signatureHeaderHeight, "", false));
            controls.Add(CreateFooterBox(historyX, y, historyLabelWidth, height, "개\r\n정\r\n이\r\n력", true));

            // 2026-10-02 개정 이력: 머리글 바로 위 칸부터 오래된 순으로 채우고 위로 갈수록 최신 (No는 REV 번호, 이력은 승인일자·개정내용)
            int historyCnt = revHistory == null ? 0 : Math.Min(revHistory.Rows.Count, 4);
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                float rowY = y + (revisionRowHeight * rowIndex);
                int historyIndex = rowIndex - (4 - historyCnt);
                DataRow history = historyIndex >= 0 ? revHistory.Rows[historyIndex] : null;
                string revNo = history != null ? Value(history, "REVNUM") : "";
                string revText = history != null ? (Value(history, "REVDATE") + " " + Value(history, "REMARK")).Trim() : "";
                controls.Add(CreateFooterBox(revisionX, rowY, revisionNoWidth, revisionRowHeight, revNo, false));
                controls.Add(CreateFooterBox(revisionX + revisionNoWidth, rowY, revisionContentWidth, revisionRowHeight, revText, false));
                controls.Add(CreateFooterBox(revisionX + revisionNoWidth + revisionContentWidth, rowY, writerWidth, revisionRowHeight, history != null ? Value(history, "REQEMPNM") : "", false));
                controls.Add(CreateFooterBox(revisionX + revisionNoWidth + revisionContentWidth + writerWidth, rowY, approverWidth, revisionRowHeight, history != null ? Value(history, "APRVEMPNM") : "", false));
            }

            float headerY = y + (revisionRowHeight * 4);
            controls.Add(CreateFooterBox(revisionX, headerY, revisionNoWidth, revisionHeaderHeight, "No", false));
            controls.Add(CreateFooterBox(revisionX + revisionNoWidth, headerY, revisionContentWidth, revisionHeaderHeight, "개정 이력", false));
            controls.Add(CreateFooterBox(revisionX + revisionNoWidth + revisionContentWidth, headerY, writerWidth, revisionHeaderHeight, "작성", false));
            controls.Add(CreateFooterBox(revisionX + revisionNoWidth + revisionContentWidth + writerWidth, headerY, approverWidth, revisionHeaderHeight, "승인", false));
            return controls.ToArray();
        }

        private XRLabel CreateFooterBox(float x, float y, float width, float height, string text, bool isLabel)
        {
            XRLabel label = new XRLabel();
            label.LocationFloat = new PointFloat(x, y);
            label.SizeF = new SizeF(width, height);
            label.Borders = BorderSide.All;
            label.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular);
            label.Text = text;
            label.Multiline = true;
            label.TextAlignment = TextAlignment.MiddleCenter;
            if (isLabel)
            {
                label.BackColor = Color.Gainsboro;
            }
            return label;
        }

        private XRLabel CreateFooterLabel()
        {
            XRLabel label = new XRLabel();
            label.LocationFloat = new PointFloat(0F, 0F);
            label.SizeF = new SizeF(ReportWidth, 18F);
            label.Font = new Font("맑은 고딕", 8F, FontStyle.Regular);
            label.Text = "제조설비 정기 점검 계획서";
            label.TextAlignment = TextAlignment.MiddleLeft;
            return label;
        }

        private XRTable CreateTable(float x, float y, float width, float height, float fontSize)
        {
            XRTable table = new XRTable();
            table.LocationFloat = new PointFloat(x, y);
            table.SizeF = new SizeF(width, height);
            table.Borders = BorderSide.All;
            table.Font = new Font("맑은 고딕", fontSize, FontStyle.Regular);
            table.TextAlignment = TextAlignment.MiddleCenter;
            return table;
        }

        private XRTableCell CreateCell(string text, float width, bool isLabel)
        {
            XRTableCell cell = new XRTableCell();
            cell.WidthF = width;
            cell.Text = text;
            cell.TextAlignment = TextAlignment.MiddleCenter;
            cell.CanGrow = true;
            if (isLabel)
            {
                cell.BackColor = Color.Gainsboro;
            }
            else
            {
                cell.Padding = new PaddingInfo(4, 2, 0, 0, 100F);
                cell.TextAlignment = TextAlignment.MiddleLeft;
            }
            return cell;
        }

        private XRTableCell CreateDataCell(string fieldName, float width, TextAlignment alignment)
        {
            XRTableCell cell = CreateCell("", width, false);
            cell.TextAlignment = alignment;
            cell.CanGrow = true;
            cell.DataBindings.Add(new XRBinding("Text", null, fieldName));
            return cell;
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
    }
}
