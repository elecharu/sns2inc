using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using ITSLIB;

namespace TMLPRINT
{ 
    public partial class MTR_1_DOC : DevExpress.XtraReports.UI.XtraReport
    {

        public MTR_1_DOC(DataRow dr, DataSet ds)
        {
            InitializeComponent();

            this.DataSource = ds.Tables[2];
            // 거래명세서 공급자 부분
            this.xrTableCell3.Text = ds.Tables[0].Rows[0]["INNM"].ToString();
            this.xrTableCell20.Text = ds.Tables[0].Rows[0]["INPRES"].ToString();
            this.xrTableCell47.Text = ds.Tables[0].Rows[0]["INNUM"].ToString();
            this.xrTableCell62.Text = ds.Tables[0].Rows[0]["INADDR"].ToString();
            this.xrTableCell37.Text = ds.Tables[0].Rows[0]["INTEL"].ToString();
            this.xrTableCell23.Text = ds.Tables[0].Rows[0]["INFAX"].ToString();
            this.xrTableCell39.Text = ds.Tables[0].Rows[0]["INTYPE"].ToString();
            this.xrTableCell7.Text = ds.Tables[0].Rows[0]["INKIND"].ToString();

            //거래명세서 공급받는자 부분
            this.xrTableCell45.Text = ds.Tables[1].Rows[0]["OUTNM"].ToString();
            this.xrTableCell21.Text = ds.Tables[1].Rows[0]["OUTPRES"].ToString();
            this.xrTableCell59.Text = ds.Tables[1].Rows[0]["OUTNUM"].ToString();
            this.xrTableCell65.Text = ds.Tables[1].Rows[0]["OUTADDR"].ToString();
            this.xrTableCell48.Text = ds.Tables[1].Rows[0]["OUTTEL"].ToString();
            this.xrTableCell24.Text = ds.Tables[1].Rows[0]["OUTFAX"].ToString();
            this.xrTableCell50.Text = ds.Tables[1].Rows[0]["OUTTYPE"].ToString();
            this.xrTableCell8.Text = ds.Tables[1].Rows[0]["OUTKIND"].ToString();

            this.xrTableCell34.Text = ds.Tables[3].Rows[0]["SUMQTY"].ToString();

            this.xrBarCode1.Text = ds.Tables[3].Rows[0]["OUTKEY"].ToString();
            this.xrTableCell70.Text = ds.Tables[3].Rows[0]["SUMQTY"].ToString();
            this.xrTableCell76.Text = ds.Tables[3].Rows[0]["REMARK"].ToString();
            this.xrTableCell71.Text = ds.Tables[3].Rows[0]["MOVEDATE"].ToString();
            this.xrTableCell73.Text = ds.Tables[3].Rows[0]["EMPNM"].ToString();
            if (dr["TITLE"].ToString() == "(공급자보관용)")
            {
                xrTable8.Visible = false;
                this.xrSubreport1.ReportSource = new TMLPRINT.MTR_1_SUB(ds);

            }
            if (dr["TITLE"].ToString() == "(공급받는자 보관용)")
            {
                xrTable8.Visible = true;
                this.xrSubreport1.Visible = false;

            }

            // 2026-11-10 품목마다 "품목별 수량" 소계 줄 (품목 단위로 묶어 LOT 수량 합계). 맨 아래 한 번만 있던 줄(xrTable5)은 없애고 거래명세서번호 줄을 위로 붙임
            if (ds.Tables[2].Columns.Contains("QTYNUM"))
            {
                xrTable5.Visible = false;
                xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(xrTable8.LocationFloat.X, 0F);
                xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(xrSubreport1.LocationFloat.X, 0F);
                this.ReportFooter.HeightF = 59.16671F;

                // 품목(ITEMCD)으로 묶기 : 묶음 정의는 GroupHeader(높이 0) 에, 소계 줄은 같은 Level 의 GroupFooter 에
                GroupHeaderBand itemGroup = new GroupHeaderBand();
                itemGroup.GroupFields.Add(new GroupField("ITEMCD"));
                itemGroup.HeightF = 0F;
                itemGroup.Level = 0;
                this.Bands.Add(itemGroup);

                GroupFooterBand itemSum = new GroupFooterBand();
                itemSum.Level = 0;
                itemSum.HeightF = 32.29167F;

                XRTable sumTable = new XRTable();
                sumTable.BeginInit();
                XRTableRow sumRow = new XRTableRow();
                sumRow.Weight = 1D;
                XRTableCell sumLabel = new XRTableCell();
                sumLabel.Text = " 품목별 수량  ";
                sumLabel.Weight = 1.4584787252675642D;
                XRTableCell sumValue = new XRTableCell();
                sumValue.Weight = 0.54152127473243583D;
                sumValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                sumValue.DataBindings.Add(new XRBinding("Text", null, "QTYNUM"));
                sumValue.Summary = new XRSummary();
                sumValue.Summary.Running = SummaryRunning.Group;
                sumValue.Summary.Func = SummaryFunc.Sum;
                sumValue.Summary.FormatString = "{0:#,0}";
                sumRow.Cells.Add(sumLabel);
                sumRow.Cells.Add(sumValue);
                sumTable.Rows.Add(sumRow);
                sumTable.BackColor = Color.LightGray;
                sumTable.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right;
                sumTable.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                sumTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                sumTable.LocationFloat = new DevExpress.Utils.PointFloat(52.08333F, 0F);
                sumTable.SizeF = new SizeF(700.0834F, 32.29167F);
                sumTable.EndInit();
                itemSum.Controls.Add(sumTable);

                this.Bands.Add(itemSum);
            }
        }


    }
}
