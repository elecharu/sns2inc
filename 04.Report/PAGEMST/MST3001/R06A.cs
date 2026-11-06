// 2026-11-04 [외주처 소모품 수령확정] 공구불출증 (A4) - 웹 MST3001_R06 수령확정·재출력
using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    /// <summary>
    /// 현장 공구불출증(02.Site\COMPJT\TMLPRINT\OSC_1)과 같은 양식. 양식을 고치면 둘 다 고친다
    /// param RELEASEKEY_LIST = 불출증키를 쉼표로 이은 값 (여러 건이면 불출증마다 새 페이지로 한 PDF 에 묶음)
    /// 데이터 = TML1030_R02 PRINT_RELEASE (Tables[0] 헤더, Tables[1] 상세)
    /// 서명칸: 요청자 = 수령자, 대구텍 = 불출자, S & S = 확정자 (안 했으면 빈칸)
    /// </summary>
    public partial class R06A : XtraReport
    {
        const int ROWS_PER_PAGE = 12;

        public R06A()
        {
            InitializeComponent();
        }

        public R06A(Dictionary<string, string> param)
        {
            InitializeComponent();

            string keyList = param.ContainsKey("RELEASEKEY_LIST") ? param["RELEASEKEY_LIST"] : "";
            List<string> keys = new List<string>();
            foreach (string k in keyList.Split(','))
            {
                if (k.Trim() != "") keys.Add(k.Trim());
            }
            if (keys.Count == 0)
            {
                throw new InvalidOperationException("출력할 불출증이 없습니다.");
            }

            // 첫 불출증은 이 리포트에, 나머지는 따로 만들어 페이지를 뒤에 붙인다
            SET_DATA(CallPrint(keys[0]));
            if (keys.Count == 1) return;

            CreateDocument();
            for (int i = 1; i < keys.Count; i++)
            {
                R06A next = new R06A();
                next.SET_DATA(CallPrint(keys[i]));
                next.CreateDocument();
                Pages.AddRange(next.Pages);
            }
        }

        private static DataSet CallPrint(string releaseKey)
        {
            ItsMaria maria = CreateMaria("TML1030_R02", "PRINT_RELEASE");
            maria.AddParam("RELEASEKEY", releaseKey);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 불출증 데이터가 없습니다. (" + releaseKey + ")");
            }
            return ds;
        }

        // 접속 정보는 다른 웹 리포트(MTR0001 S04A)와 같게
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

        public void SET_DATA(DataSet ds)
        {
            DataTable head = ds.Tables[0];
            DataTable detail = ds.Tables[1];
            DataRow h = head.Rows[0];

            this.bar_RELEASEKEY.Text = h["RELEASEKEY"].ToString();                                   // 불출 바코드
            this.lbl_EQMNM.Text = "(    " + h["EQMNM"].ToString() + "    )LINE";                      // 불출라인
            this.lbl_SIGN1.Text = head.Columns.Contains("EMPNM_RECIEVE") ? h["EMPNM_RECIEVE"].ToString() : "";   // 요청자 = 수령자
            this.lbl_SIGN2.Text = head.Columns.Contains("EMPNM_RELEASE") ? h["EMPNM_RELEASE"].ToString() : "";   // 대구텍 = 불출자
            this.lbl_SIGN3.Text = head.Columns.Contains("EMPNM_CONFIRM") ? h["EMPNM_CONFIRM"].ToString() : "";   // S & S = 확정자

            string releaseDate = h["RELEASEDATE"].ToString();   // yyyy-MM-dd
            DateTime dt;
            this.lbl_DATE.Text = releaseDate;
            if (DateTime.TryParse(releaseDate, out dt))
            {
                this.lbl_DATE.Text = dt.Year + "    년      " + dt.Month + "  월      " + dt.Day + "  일";
            }

            // 상세 (12줄 단위로 빈 줄을 채워 페이지마다 표가 끝까지 그려지게 함)
            DataTable rows = new DataTable();
            rows.Columns.Add("ITEMSPEC", typeof(string));
            rows.Columns.Add("RELQTY", typeof(string));
            foreach (DataRow r in detail.Rows)
            {
                decimal qty;
                decimal.TryParse(r["RELQTY"].ToString(), out qty);
                rows.Rows.Add(r["ITEMSPEC"].ToString(), qty.ToString("#,##0.##"));
            }
            int pad = Math.Max(ROWS_PER_PAGE, (int)Math.Ceiling(rows.Rows.Count / (double)ROWS_PER_PAGE) * ROWS_PER_PAGE);
            while (rows.Rows.Count < pad)
            {
                rows.Rows.Add("", "");
            }
            this.DataSource = rows;
        }
    }
}
