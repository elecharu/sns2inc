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



        
        }

      
    }
}
