// 2026-11-17 재고 입출고 조회(SAL3002_S03) [인쇄] - 생산관리팀 "일일 마감 (2공장 - 외부 재고출고나 이동이력 조회)" 양식
// 양식은 S03.Designer.cs (디자이너에서 보임). A4 가로.
//   1장 : 제목 + 조회기간 + 결재란, 2장부터 : 제목만. 머리글은 장마다 반복, 마지막에 수량 합계
// 데이터는 프로시저 SAL3002_S03 PRINT (결과셋 1 조회기간, 결과셋 2 목록 = 화면 조회와 같은 목록)
using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class S03 : XtraReport
    {
        // 디자이너용 (빈 양식)
        public S03()
        {
            InitializeComponent();

            // 디자이너에서 칸을 새로 추가해도 출력 때 칸 크기가 바뀌지 않게 잠근다
            foreach (XRLabel label in AllControls<XRLabel>())
            {
                label.CanGrow = false;
                label.CanShrink = false;
            }
        }

        // SDATE, EDATE = 조회기간 (YYYY-MM-DD)
        public S03(Dictionary<string, string> param) : this()
        {
            // 매개변수가 없으면 빈 양식만 출력 (레이아웃 확인용)
            if (param == null || !param.ContainsKey("SDATE") || !param.ContainsKey("EDATE"))
            {
                return;
            }

            ItsMaria maria = new ItsMaria("SAL3002_S03", "PRINT");
            maria.AddParam("SDATE", param["SDATE"]);
            maria.AddParam("EDATE", param["EDATE"]);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 자료가 없습니다.");
            }

            C_PERIOD.Text = ds.Tables[0].Rows[0]["PERIOD"].ToString();
            this.DataSource = ds.Tables[1];
        }
    }
}
