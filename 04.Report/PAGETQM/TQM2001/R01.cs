// 2026-11-09 [부적합 판정등록] 공정이동표 (A4). TQM2001_R01 판정 저장 후 판정 1건에 1장 출력
// 양식은 R01.Designer.cs (02.Site\COMPJT\TMLPRINT\PRD_1 생산실적등록 공정이동표를 복사). 여기서는 C_ 칸에 값만 넣는다.
// 매개변수: JUDGEKEYS = 판정키 (쉼표 구분, 여러 개면 한 PDF 에 장을 이어 붙인다), EMPCD = 출력자
// 프로시저 TQM2001_R01 PRINT_MOVE 결과
//   Tables[0] 생산품·생산정보·로트 (ITEMCD, ITEMNM, ITEMSPEC, HEATNO, HEATLOTKEY, PRDDATE, EMPNM, RSTTIME,
//             LOTKEY, LINENM, PRCNM, EQMNM, UNITNM, QTY(판정수량), PRINTEMPNM, PRINTTIME)
//   Tables[1] 로트추적 (NO, ITEMCD, LINENM, PRCNM, LOTKEY) 첫 줄 판정이력 → 판정한 로트 → 이전 공정 → 원소재 순
using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class R01 : XtraReport
    {
        // 디자이너용 (빈 양식)
        public R01()
        {
            InitializeComponent();
        }

        public R01(Dictionary<string, string> param)
        {
            InitializeComponent();

            // 매개변수가 없으면 빈 양식만 출력 (레이아웃 확인용)
            if (param == null || !param.ContainsKey("JUDGEKEYS") || param["JUDGEKEYS"] == "")
            {
                return;
            }

            string empCd = param.ContainsKey("EMPCD") ? param["EMPCD"] : "";
            string[] judgeKeys = param["JUDGEKEYS"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            // 첫 판정은 이 리포트에, 나머지 판정은 따로 만들어 장을 이어 붙인다
            SET_DATA(GET_DATA(judgeKeys[0], empCd));
            this.CreateDocument();

            for (int i = 1; i < judgeKeys.Length; i++)
            {
                R01 page = new R01();
                page.SET_DATA(GET_DATA(judgeKeys[i], empCd));
                page.CreateDocument();
                this.Pages.AddRange(page.Pages);
            }
        }

        private DataSet GET_DATA(string judgeKey, string empCd)
        {
            ItsMaria maria = new ItsMaria("TQM2001_R01", "PRINT_MOVE");
            maria.AddParam("JUDGEKEY_LIST", judgeKey);
            maria.AddParam("EMPCD", empCd);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 공정이동표 데이터가 없습니다. 판정키: " + judgeKey);
            }

            return ds;
        }

        private void SET_DATA(DataSet ds)
        {
            DataRow head = ds.Tables[0].Rows[0];

            this.C_ITEMCD.Text = head["ITEMCD"].ToString();
            this.C_ITEMNM.Text = head["ITEMNM"].ToString();
            this.C_ITEMSPEC.Text = head["ITEMSPEC"].ToString();
            this.C_EMPNM.Text = head["EMPNM"].ToString();
            this.C_HEATNO.Text = head["HEATNO"].ToString();
            this.C_HEATLOTKEY.Text = head["HEATLOTKEY"].ToString();
            this.C_PRDDATE.Text = head["PRDDATE"].ToString();
            this.C_RSTTIME.Text = head["RSTTIME"].ToString();

            this.bar_LOTKEY.Text = head["LOTKEY"].ToString();

            this.C_LINENM.Text = head["LINENM"].ToString();
            this.C_PRCNM.Text = head["PRCNM"].ToString();
            this.C_EQMNM.Text = head["EQMNM"].ToString();
            this.C_LOTKEY.Text = head["LOTKEY"].ToString();
            this.C_UNITNM.Text = head["UNITNM"].ToString();
            this.C_QTY.Text = head["QTY"].ToString();

            this.lbl_PRINT.Text = head["PRINTEMPNM"].ToString() + " " + head["PRINTTIME"].ToString();

            // 로트추적 (판정이력이 첫 줄, 원소재가 마지막 줄)
            this.DataSource = ds.Tables[1];
        }
    }
}
