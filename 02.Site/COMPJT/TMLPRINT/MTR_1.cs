using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using DevExpress.XtraPrinting;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-09 [유상사급 납품등록] 거래명세서 (A4, 공급받는자 보관용 1장). 1공장 TMLPRINT R03B1/R03B2/R03B2_SUB 양식 그대로
    /// ds = TML1010_R01 PRINT_INVOICE 결과 [0] 공급자 [1] 공급받는자 [2] LOT 목록 [3] 거래일자·합계·거래명세서번호
    /// </summary>
    public partial class MTR_1 : DevExpress.XtraReports.UI.XtraReport
    {
        DataSet allData;
        public class MODEL_S1
        {
            public string SALOUTKEY { get; set; }
      
        }
        public int row = 0;
        public MTR_1(DataSet ds)
        {
            InitializeComponent();

            allData = ds;

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("TITLE", typeof(string)));
            

                // 2026-11-09 2공장은 공급받는자 보관용 1장만 출력 (1공장은 공급자보관용까지 2장)
                DataRow row = dt.NewRow();
                row["TITLE"] = "(공급받는자 보관용)";
                dt.Rows.Add(row);

            this.DataSource = dt;

        }
        //Detail에서 Data Table의 Binding값 바뀔 시 호출
        protected override void OnDataSourceRowChanged(DataSourceRowEventArgs e)
        {
            base.OnDataSourceRowChanged(e);                            //row 체크, 미설정시 Data Table Row Count + 1번 실행됨
            if (row < ((DataTable)this.DataSource).Rows.Count)
            {
                //Subreport 호출 후 row++ Subreport에서 사용할 데이터 건네주기
                this.xrSubreport1.ReportSource = new TMLPRINT.MTR_1_DOC(((DataTable)this.DataSource).Rows[row++], allData);
            }
        }

        // 확인창·미리보기 없이 지정한 프린터로 바로 인쇄 (현장 화면은 POP 에서 고른 프린터 ItsPrinter.BarcodePrintName 을 넘김)
        public void PrintDirect(string printerName)
        {
            this.ShowPrintMarginsWarning = false;
            this.ShowPrintStatusDialog = false;
            this.CreateDocument();
            PrintToolBase tool = new PrintToolBase(this.PrintingSystem);
            tool.Print(printerName);
        }

    }
}
