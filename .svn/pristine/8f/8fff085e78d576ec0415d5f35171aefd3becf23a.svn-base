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

            string eqmGroupCode = param.ContainsKey("EQMGRP") ? param["EQMGRP"] : "";
            if (string.IsNullOrEmpty(eqmGroupCode))
            {
                throw new InvalidOperationException("설비그룹을 선택해주세요.");
            }

            ItsMaria maria = CreateMaria("EQM1001_R05", "CALL_PLAN_RPT");
            maria.AddParam("EQMGRP", eqmGroupCode);
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
            AddBlankRows(planItems, 12);

            BuildReport(planHeader, planItems);
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

        private void BuildReport(DataRow planHeader, DataTable planItems)        {
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
            reportFooter.Controls.AddRange(CreateConfirmationControls());
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
            table.Rows.Add(CreateInfoRow("설비명", Value(row, "EQMGRPNM"), "설비규격", Value(row, "EQMSPEC")));
            table.Rows.Add(CreateInfoRow("설비번호", Value(row, "EQMCD"), "점검일자", ""));
            table.Rows.Add(CreateInfoRow("적용LINE", Value(row, "LINECD"), "적용공정", Value(row, "PROCESSNM")));
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

        private XRControl[] CreateConfirmationControls()
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

            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                float rowY = y + (revisionRowHeight * rowIndex);
                controls.Add(CreateFooterBox(revisionX, rowY, revisionNoWidth, revisionRowHeight, (4 - rowIndex).ToString(), false));
                controls.Add(CreateFooterBox(revisionX + revisionNoWidth, rowY, revisionContentWidth, revisionRowHeight, "", false));
                controls.Add(CreateFooterBox(revisionX + revisionNoWidth + revisionContentWidth, rowY, writerWidth, revisionRowHeight, "", false));
                controls.Add(CreateFooterBox(revisionX + revisionNoWidth + revisionContentWidth + writerWidth, rowY, approverWidth, revisionRowHeight, "", false));
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
