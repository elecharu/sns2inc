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
    public partial class MTR_1_SUB : DevExpress.XtraReports.UI.XtraReport
    {
    

        public MTR_1_SUB(DataSet ds)
   
        {
            InitializeComponent();


            this.xrTableCell36.Text = ds.Tables[3].Rows[0]["SUMQTY"].ToString();
            this.xrTableCell76.Text = ds.Tables[3].Rows[0]["REMARK"].ToString();

   

        }
    }
}
