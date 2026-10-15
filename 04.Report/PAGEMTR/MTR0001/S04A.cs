// 2026-10-14 [설비부품 발주서] DevExpress XtraReports 기반 발주서 리포트(S04A) 고도화 (상단 단일테이블 통합 행높이·수직선 완벽일치, 품목그리드 열너비·2줄행높이28F 원본이미지 100% 매칭)
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
    public partial class S04A : XtraReport
    {
        private const float ReportWidth = 731F;

        public S04A(Dictionary<string, string> param)
        {
            InitializeComponent();

            // 2026-10-15 [설비부품 발주서] 발주번호 파라미터 취득 및 프로시저(MTR0001_R04 CALL_RPT) 데이터 조회 (검증 프로시저 위임)
            string mtrOdrKey = param.ContainsKey("MTRODRKEY") ? param["MTRODRKEY"] : "";

            ItsMaria maria = CreateMaria("MTR0001_R04", "CALL_RPT");
            maria.AddParam("MTRODRKEY", mtrOdrKey);
            DataSet dataSet = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (dataSet == null || dataSet.Tables.Count < 2 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 발주서 데이터가 없습니다.");
            }

            DataRow odrHeader = dataSet.Tables[0].Rows[0];
            DataTable odrItems = dataSet.Tables[1].Copy();

            BuildReport(odrHeader, odrItems);
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

        // 2026-10-14 발주 리포트
        private void BuildReport(DataRow header, DataTable items)
        {
            Dpi = 100F;
            PaperKind = PaperKind.A4;
            PageWidth = 827;
            PageHeight = 1169;
            Margins = new Margins(48, 48, 45, 20);

            TopMarginBand topMargin = new TopMarginBand { HeightF = 45F };
            BottomMarginBand bottomMargin = new BottomMarginBand { HeightF = 15F };
            ReportHeaderBand reportHeader = new ReportHeaderBand { HeightF = 238F };
            DetailBand detail = new DetailBand { HeightF = 0F };
            ReportFooterBand reportFooter = new ReportFooterBand { HeightF = 745F };
            PageFooterBand pageFooter = new PageFooterBand { HeightF = 18F };

            // 상단 타이틀, 거래처명, 승인 박스
            reportHeader.Controls.AddRange(CreateHeaderControls(header));

            // 품목 그리드
            reportFooter.Controls.AddRange(CreateItemsAndFooterControls(header, items));

            // 하단 중앙 페이지 번호 (1/1)
            XRPageInfo pageInfo = new XRPageInfo();
            pageInfo.LocationFloat = new PointFloat(0F, 0F);
            pageInfo.SizeF = new SizeF(ReportWidth, 18F);
            pageInfo.Font = new Font("맑은 고딕", 8F, FontStyle.Regular);
            pageInfo.TextAlignment = TextAlignment.MiddleCenter;
            pageInfo.Format = "{0}/{1}";
            pageFooter.Controls.Add(pageInfo);

            Bands.AddRange(new Band[] { topMargin, bottomMargin, reportHeader, detail, reportFooter, pageFooter });
        }

        // 2026-10-14 상단 헤더 영역 컨트롤 생성
        private XRControl[] CreateHeaderControls(DataRow header)
        {
            List<XRControl> list = new List<XRControl>();

            // 1. 로고 이미지
            XRPictureBox logoBox = new XRPictureBox();
            logoBox.LocationFloat = new PointFloat(0F, 0F);
            logoBox.SizeF = new SizeF(190F, 45F);
            logoBox.Sizing = ImageSizeMode.ZoomImage;
            logoBox.ImageAlignment = ImageAlignment.MiddleLeft;
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] logoPaths = new string[]
            {
                System.IO.Path.Combine(baseDir, "..", "images", "menu", "logo.png"),
                System.IO.Path.Combine(baseDir, "..", "..", "01.Office", "images", "menu", "logo.png"),
                System.IO.Path.Combine(baseDir, "images", "logo.png"),
                @"D:\ITS_MES_SNSINC_FAC2_VA.1.0\01.Office\images\menu\logo.png",
                @"D:\ITS_MES_SNSINC_FAC2_VA.1.0\01.Office\images\logo.png"
            };
            foreach (string lp in logoPaths)
            {
                if (System.IO.File.Exists(lp))
                {
                    try
                    {
                        logoBox.Image = Image.FromFile(lp);
                        break;
                    }
                    catch { }
                }
            }
            list.Add(logoBox);

            // 2. 거래처명
            XRLabel custNameLabel = new XRLabel();
            custNameLabel.LocationFloat = new PointFloat(0F, 51F);
            custNameLabel.SizeF = new SizeF(230F, 26F);
            custNameLabel.Font = new Font("맑은 고딕", 14F, FontStyle.Bold);
            custNameLabel.Text = Value(header, "CUSTNM");
            custNameLabel.TextAlignment = TextAlignment.BottomLeft;
            list.Add(custNameLabel);

            // 3. 발주서 메인 타이틀
            XRLabel titleLabel = new XRLabel();
            titleLabel.LocationFloat = new PointFloat(230F, 5F);
            titleLabel.SizeF = new SizeF(270F, 38F);
            titleLabel.Font = new Font("맑은 고딕", 21F, FontStyle.Bold);
            titleLabel.Text = "발   주   서";
            titleLabel.TextAlignment = TextAlignment.MiddleCenter;
            list.Add(titleLabel);

            // 4. 우측 승인 도장 박스
            XRTable approveTable = new XRTable();
            approveTable.LocationFloat = new PointFloat(591F, 0F);
            approveTable.SizeF = new SizeF(140F, 56F);
            approveTable.Borders = BorderSide.All;
            approveTable.BorderWidth = 1.2F;
            approveTable.BorderColor = Color.Black;

            XRTableRow appRow1 = new XRTableRow { HeightF = 28F };
            XRTableCell appCell1 = new XRTableCell();
            appCell1.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            appCell1.Text = "발주승인완료";
            appCell1.TextAlignment = TextAlignment.MiddleCenter;
            appRow1.Cells.Add(appCell1);

            XRTableRow appRow2 = new XRTableRow { HeightF = 28F };
            XRTableCell appCell2 = new XRTableCell();
            appCell2.Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular);
            // string aprvDate = Value(header, "MTRODRDATE"); // 발주승인완료 날짜 (MTRODRDATE 기준)
            // appCell2.Text = aprvDate;
            appCell2.TextAlignment = TextAlignment.MiddleCenter;
            appRow2.Cells.Add(appCell2);

            approveTable.Rows.Add(appRow1);
            approveTable.Rows.Add(appRow2);
            list.Add(approveTable);

            // 5. 기본 정보 테이블
            const float startY = 84F;
            const float rowH = 24F;

            // [Row 1]
            XRTable t1 = CreateSingleRowTable(0F, startY, ReportWidth, rowH, BorderSide.All);
            XRTableRow r1 = new XRTableRow { HeightF = rowH };
            r1.Cells.Add(CreateFixedCell("전    화", 75F, rowH, true));
            r1.Cells.Add(CreateFixedCell(Value(header, "CUSTTEL"), 240F, rowH, true, TextAlignment.MiddleLeft, 8.5F, 4));
            r1.Cells.Add(CreateFixedCell(Value(header, "COMPANYNM"), 190F, rowH, true, TextAlignment.MiddleLeft, 8.5F, 4));
            r1.Cells.Add(CreateFixedCell("사업자번호", 75F, rowH, true));
            r1.Cells.Add(CreateFixedCell(Value(header, "COMPANYBIZNO"), 151F, rowH, true, TextAlignment.MiddleCenter));
            t1.Rows.Add(r1);
            list.Add(t1);

            // [Row 2]
            XRTable t2 = CreateSingleRowTable(0F, startY + rowH, ReportWidth, rowH, BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
            XRTableRow r2 = new XRTableRow { HeightF = rowH };
            r2.Cells.Add(CreateFixedCell("F  A  X", 75F, rowH, true));
            r2.Cells.Add(CreateFixedCell(Value(header, "CUSTFAX"), 240F, rowH, true, TextAlignment.MiddleLeft, 8.5F, 4));
            r2.Cells.Add(CreateFixedCell("대 표 자", 60F, rowH, true));
            r2.Cells.Add(CreateFixedCell(Value(header, "PRESIDENT"), 356F, rowH, true, TextAlignment.MiddleLeft, 8.5F, 4));
            t2.Rows.Add(r2);
            list.Add(t2);

            // [Row 3]
            XRTable t3 = CreateSingleRowTable(0F, startY + (rowH * 2F), ReportWidth, rowH, BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
            XRTableRow r3 = new XRTableRow { HeightF = rowH };
            r3.Cells.Add(CreateFixedCell("사업자번호", 75F, rowH, true));
            r3.Cells.Add(CreateFixedCell(Value(header, "CUSTBIZNO"), 240F, rowH, true, TextAlignment.MiddleLeft, 8.5F, 4));
            r3.Cells.Add(CreateFixedCell("주    소", 60F, rowH, true));
            r3.Cells.Add(CreateFixedCell(Value(header, "COMPANYADDR"), 356F, rowH, true, TextAlignment.MiddleLeft, 8F, 4));
            t3.Rows.Add(r3);
            list.Add(t3);

            // [Row 4]
            XRTable t4 = CreateSingleRowTable(0F, startY + (rowH * 3F), ReportWidth, rowH, BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
            XRTableRow r4 = new XRTableRow { HeightF = rowH };
            r4.Cells.Add(CreateFixedCell("발 주 번 호", 75F, rowH, true));
            r4.Cells.Add(CreateFixedCell(Value(header, "MTRODRKEY"), 240F, rowH, true, TextAlignment.MiddleLeft, 8.5F, 4));
            r4.Cells.Add(CreateFixedCell("전    화", 60F, rowH, true));
            r4.Cells.Add(CreateFixedCell(Value(header, "COMPANYTEL"), 148F, rowH, true, TextAlignment.MiddleLeft, 8.5F, 4));
            r4.Cells.Add(CreateFixedCell("F  A  X", 60F, rowH, true));
            r4.Cells.Add(CreateFixedCell(Value(header, "COMPANYFAX"), 148F, rowH, true, TextAlignment.MiddleLeft, 8.5F, 4));
            t4.Rows.Add(r4);
            list.Add(t4);

            // [Row 5]
            XRTable t5 = CreateSingleRowTable(0F, startY + (rowH * 4F), ReportWidth, rowH, BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
            XRTableRow r5 = new XRTableRow { HeightF = rowH };
            r5.Cells.Add(CreateFixedCell("발 주 일 자", 75F, rowH, true));
            r5.Cells.Add(CreateFixedCell(Value(header, "MTRODRDATE"), 82.5F, rowH, true, TextAlignment.MiddleCenter));
            r5.Cells.Add(CreateFixedCell("납 기 일 자", 75F, rowH, true));
            r5.Cells.Add(CreateFixedCell(Value(header, "EXPDATE"), 82.5F, rowH, true, TextAlignment.MiddleCenter));
            r5.Cells.Add(CreateFixedCell("담 당 자", 60F, rowH, true));
            r5.Cells.Add(CreateFixedCell(Value(header, "EMPINFO"), 356F, rowH, true, TextAlignment.MiddleLeft, 8F, 4));
            t5.Rows.Add(r5);
            list.Add(t5);

            // 6. "아래와 같이 발주 합니다." 안내문
            XRLabel noticeLabel = new XRLabel();
            noticeLabel.LocationFloat = new PointFloat(0F, 210F);
            noticeLabel.SizeF = new SizeF(300F, 20F);
            noticeLabel.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold);
            noticeLabel.Text = "아래와 같이 발주 합니다.";
            noticeLabel.TextAlignment = TextAlignment.MiddleLeft;
            list.Add(noticeLabel);

            return list.ToArray();
        }

        // 2026-10-14 품목 그리드
        private XRControl[] CreateItemsAndFooterControls(DataRow header, DataTable items)
        {
            List<XRControl> list = new List<XRControl>();

            const float dataRowHeight = 36F;
            const float headerHeight = dataRowHeight * 0.9F;
            const float totalRowHeight = dataRowHeight;

            // 열 너비 규격: No(30), 품명(175), 규격(120), 단위(38), 단가(72), 수량(42), 금액(84), 비고(170) = 총 731F
            const float wNo = 30F;
            const float wName = 175F;
            const float wSpec = 120F;
            const float wUnit = 38F;
            const float wPrice = 72F;
            const float wQty = 42F;
            const float wAmt = 84F;
            const float wRemark = 170F;

            // [1. 헤더 테이블] 
            XRTable headerTable = CreateSingleRowTable(0F, 0F, ReportWidth, headerHeight, BorderSide.All);
            XRTableRow th = new XRTableRow { HeightF = headerHeight };
            th.Cells.Add(CreateFixedCell("No", wNo, headerHeight, true, TextAlignment.MiddleCenter, 8.5F));
            th.Cells.Add(CreateFixedCell("품    명", wName, headerHeight, true, TextAlignment.MiddleCenter, 8.5F));
            th.Cells.Add(CreateFixedCell("규    격", wSpec, headerHeight, true, TextAlignment.MiddleCenter, 8.5F));
            th.Cells.Add(CreateFixedCell("단위", wUnit, headerHeight, true, TextAlignment.MiddleCenter, 8.5F));
            th.Cells.Add(CreateFixedCell("단가", wPrice, headerHeight, true, TextAlignment.MiddleCenter, 8.5F));
            th.Cells.Add(CreateFixedCell("수량", wQty, headerHeight, true, TextAlignment.MiddleCenter, 8.5F));
            th.Cells.Add(CreateFixedCell("금액", wAmt, headerHeight, true, TextAlignment.MiddleCenter, 8.5F));
            th.Cells.Add(CreateFixedCell("비고", wRemark, headerHeight, true, TextAlignment.MiddleCenter, 8.5F));
            headerTable.Rows.Add(th);
            list.Add(headerTable);

            decimal totalQty = 0;
            decimal totalAmt = 0;
            int rowCount = items.Rows.Count;

            // [2. 데이터 행들 1~15행]
            for (int i = 0; i < 15; i++)
            {
                float rowY = headerHeight + (i * dataRowHeight);
                XRTable rowTable = CreateSingleRowTable(0F, rowY, ReportWidth, dataRowHeight, BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
                XRTableRow tr = new XRTableRow { HeightF = dataRowHeight };

                if (i < rowCount)
                {
                    DataRow row = items.Rows[i];
                    decimal qty = ToDecimal(row["QTY"]);
                    decimal price = ToDecimal(row["PRICE"]);
                    decimal amt = ToDecimal(row["AMT"]);
                    totalQty += qty;
                    totalAmt += amt;

                    tr.Cells.Add(CreateDataCell((i + 1).ToString(), wNo, dataRowHeight, TextAlignment.MiddleCenter, 8.5F));
                    tr.Cells.Add(CreateDataCell(Value(row, "ITEMNM"), wName, dataRowHeight, TextAlignment.MiddleLeft, 8F, true));
                    tr.Cells.Add(CreateDataCell(Value(row, "ITEMSPEC"), wSpec, dataRowHeight, TextAlignment.MiddleLeft, 8F, true));
                    tr.Cells.Add(CreateDataCell(Value(row, "ITEMUNIT"), wUnit, dataRowHeight, TextAlignment.MiddleCenter, 8F));
                    tr.Cells.Add(CreateDataCell(price.ToString("#,##0"), wPrice, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 6));
                    tr.Cells.Add(CreateDataCell(qty.ToString("#,##0"), wQty, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 6));
                    tr.Cells.Add(CreateDataCell(amt.ToString("#,##0"), wAmt, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 8));
                    tr.Cells.Add(CreateDataCell(Value(row, "REMARK"), wRemark, dataRowHeight, TextAlignment.MiddleLeft, 7.5F, true));
                }
                else if (i == rowCount)
                {
                    // 원본 PDF 정답 양식: - - -  이  하  여  백  - - -
                    tr.Cells.Add(CreateDataCell((i + 1).ToString(), wNo, dataRowHeight, TextAlignment.MiddleCenter, 8.5F));
                    tr.Cells.Add(CreateDataCell("- - -  이  하  여  백  - - -", wName, dataRowHeight, TextAlignment.MiddleCenter, 7.5F));
                    tr.Cells.Add(CreateDataCell("", wSpec, dataRowHeight, TextAlignment.MiddleLeft, 8F));
                    tr.Cells.Add(CreateDataCell("", wUnit, dataRowHeight, TextAlignment.MiddleCenter, 8F));
                    tr.Cells.Add(CreateDataCell("", wPrice, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 6));
                    tr.Cells.Add(CreateDataCell("", wQty, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 6));
                    tr.Cells.Add(CreateDataCell("", wAmt, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 8));
                    tr.Cells.Add(CreateDataCell("", wRemark, dataRowHeight, TextAlignment.MiddleLeft, 7.5F));
                }
                else
                {
                    tr.Cells.Add(CreateDataCell((i + 1).ToString(), wNo, dataRowHeight, TextAlignment.MiddleCenter, 8.5F));
                    tr.Cells.Add(CreateDataCell("", wName, dataRowHeight, TextAlignment.MiddleLeft, 8F));
                    tr.Cells.Add(CreateDataCell("", wSpec, dataRowHeight, TextAlignment.MiddleLeft, 8F));
                    tr.Cells.Add(CreateDataCell("", wUnit, dataRowHeight, TextAlignment.MiddleCenter, 8F));
                    tr.Cells.Add(CreateDataCell("", wPrice, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 6));
                    tr.Cells.Add(CreateDataCell("", wQty, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 6));
                    tr.Cells.Add(CreateDataCell("", wAmt, dataRowHeight, TextAlignment.MiddleRight, 8.5F, false, 8));
                    tr.Cells.Add(CreateDataCell("", wRemark, dataRowHeight, TextAlignment.MiddleLeft, 7.5F));
                }

                rowTable.Rows.Add(tr);
                list.Add(rowTable);
            }

            // [3. 합계 테이블] Y = headerHeight + (dataRowHeight * 15F), 높이 totalRowHeight(36F)
            float totalTableY = headerHeight + (dataRowHeight * 15F);
            float totalTitleWidth = wNo + wName + wSpec + wUnit + wPrice; // 30 + 175 + 120 + 38 + 72 = 435F
            XRTable totalTable = CreateSingleRowTable(0F, totalTableY, ReportWidth, totalRowHeight, BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
            XRTableRow totalRow = new XRTableRow { HeightF = totalRowHeight };
            totalRow.Cells.Add(CreateFixedCell("합    계", totalTitleWidth, totalRowHeight, true, TextAlignment.MiddleRight, 9F, 10));
            totalRow.Cells.Add(CreateFixedCell(totalQty.ToString("#,##0"), wQty, totalRowHeight, true, TextAlignment.MiddleRight, 9F, 6));
            totalRow.Cells.Add(CreateFixedCell(totalAmt.ToString("#,##0"), wAmt, totalRowHeight, true, TextAlignment.MiddleRight, 9F, 8));
            totalRow.Cells.Add(CreateFixedCell("", wRemark, totalRowHeight, false, TextAlignment.MiddleCenter));
            totalTable.Rows.Add(totalRow);
            list.Add(totalTable);

            // [4. 업체 요청 사항 박스] Y = 398F + 23F + 10F = 431F, 높이 115F
            XRPanel reqPanel = new XRPanel();
            reqPanel.LocationFloat = new PointFloat(0F, totalTableY + totalRowHeight + 10F);
            reqPanel.SizeF = new SizeF(ReportWidth, 115F);
            reqPanel.Borders = BorderSide.All;
            reqPanel.BorderColor = Color.Black;
            reqPanel.BorderWidth = 1F;

            // (1) 업체 요청 사항 타이틀
            XRLabel reqTitle = new XRLabel();
            reqTitle.LocationFloat = new PointFloat(8F, 6F);
            reqTitle.SizeF = new SizeF(150F, 16F);
            reqTitle.Font = new Font("맑은 고딕", 8.5F, FontStyle.Bold);
            reqTitle.Text = "업체 요청 사항";
            reqTitle.Borders = BorderSide.None;
            reqPanel.Controls.Add(reqTitle);

            // (2) 업체 요청 사항 비고 내용
            XRLabel reqContent = new XRLabel();
            reqContent.LocationFloat = new PointFloat(8F, 24F);
            reqContent.SizeF = new SizeF(712F, 28F);
            reqContent.Font = new Font("맑은 고딕", 8F, FontStyle.Bold);
            reqContent.Text = Value(header, "REMARK");
            reqContent.Borders = BorderSide.None;
            reqPanel.Controls.Add(reqContent);

            // (3) 박스 내부 하단 3줄 안내문
            XRLabel notice1 = new XRLabel();
            notice1.LocationFloat = new PointFloat(8F, 56F);
            notice1.SizeF = new SizeF(712F, 15F);
            notice1.Font = new Font("맑은 고딕", 7.5F, FontStyle.Bold);
            notice1.Text = "* 위와 같은 내용을 발주하오니 업무에 참조 바라며 발주서 접수 즉시 회신 바랍니다.";
            notice1.Borders = BorderSide.None;
            reqPanel.Controls.Add(notice1);

            XRLabel notice2 = new XRLabel();
            notice2.LocationFloat = new PointFloat(8F, 72F);
            notice2.SizeF = new SizeF(712F, 15F);
            notice2.Font = new Font("맑은 고딕", 7.5F, FontStyle.Bold);
            notice2.Text = "* 품질에 관련된 관련표준을 명기한 경우 해당표준에 따른다.";
            notice2.Borders = BorderSide.None;
            reqPanel.Controls.Add(notice2);

            XRLabel notice3 = new XRLabel();
            notice3.LocationFloat = new PointFloat(8F, 88F);
            notice3.SizeF = new SizeF(712F, 15F);
            notice3.Font = new Font("맑은 고딕", 7.5F, FontStyle.Bold);
            notice3.Text = "* 품질에 관련하여 관련표준을 구체적으로 명기하지 않은 경우 당사의 검사규격에 따른다.";
            notice3.Borders = BorderSide.None;
            reqPanel.Controls.Add(notice3);

            list.Add(reqPanel);

            return list.ToArray();
        }

        // 단일 행 테이블 생성 헬퍼
        private static XRTable CreateSingleRowTable(float x, float y, float width, float height, BorderSide borders = BorderSide.All)
        {
            XRTable table = new XRTable();
            table.LocationFloat = new PointFloat(x, y);
            table.SizeF = new SizeF(width, height);
            table.Borders = borders;
            table.BorderColor = Color.Black;
            table.BorderWidth = 1F;
            return table;
        }

        // 고정 높이 셀 생성
        private static XRTableCell CreateFixedCell(string text, float width, float height, bool isHeader, TextAlignment alignment = TextAlignment.MiddleCenter, float fontSize = 8.5F, int padding = 0)
        {
            XRTableCell cell = new XRTableCell();
            cell.WidthF = width;
            cell.HeightF = height;
            cell.Text = text;
            cell.Font = new Font("맑은 고딕", fontSize, isHeader ? FontStyle.Bold : FontStyle.Regular);
            cell.TextAlignment = alignment;
            cell.Borders = BorderSide.All;
            cell.BorderColor = Color.Black;
            cell.BorderWidth = 1F;
            cell.CanGrow = false;
            cell.WordWrap = false;
            cell.Padding = new PaddingInfo(padding, padding, 0, 0, 100F);
            return cell;
        }

        // 품목 데이터 셀 생성
        private static XRTableCell CreateDataCell(string text, float width, float height, TextAlignment alignment, float fontSize = 8F, bool allowWrap = false, int padding = 3)
        {
            XRTableCell cell = new XRTableCell();
            cell.WidthF = width;
            cell.HeightF = height;
            cell.Text = text;
            cell.Font = new Font("맑은 고딕", fontSize, FontStyle.Regular);
            cell.TextAlignment = alignment;
            cell.Borders = BorderSide.All;
            cell.BorderColor = Color.Black;
            cell.BorderWidth = 1F;
            cell.CanGrow = false;
            cell.WordWrap = allowWrap;
            cell.Padding = new PaddingInfo(padding, padding, 0, 0, 100F);
            return cell;
        }

        private static string Value(DataRow row, string columnName)
        {
            if (row == null || !row.Table.Columns.Contains(columnName) || row.IsNull(columnName))
            {
                return "";
            }
            return row[columnName].ToString().Trim();
        }

        private static decimal ToDecimal(object obj)
        {
            if (obj == null || obj == DBNull.Value) return 0;
            decimal d;
            if (decimal.TryParse(obj.ToString(), out d)) return d;
            return 0;
        }
    }
}

