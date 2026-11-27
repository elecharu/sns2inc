using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraReports.UI;
using ItsLibRpt;

namespace XtraRpt
{
    /// <summary>
    /// 2026-11-26 [설비 일상점검 조회 PRD6001_S01] 월간 일상점검표 (점검 결과 채움). 양식은 R02(설비 일상점검표) 그대로
    /// 체크한 설비마다 1장, 한 문서로 이어 붙임
    /// 프로시저 PRD6001_S01 PRINT_MONTH_SHEET ($SMONTH, $FANO_LIST)
    ///   Tables[0] 머리글 (설비마다 1행: FANO, EQMNM, MON, LINENM, ITEMNM_LIST, FIRSTDATE, REVDATE, REVNUM)
    ///   Tables[1] 월간 표 (FANO, SEQ, CHKLOCNM, CHKKNDNM, CHKSTD, CHKCYCLENM, D01~D31, N01~N31)
    ///   Tables[2] 위치사진 (FANO, SEQ, FILEPATH)
    /// </summary>
    public class S01 : R02
    {
        public S01() : base() { }

        public S01(Dictionary<string, string> param) : base()
        {
            string month = param != null && param.ContainsKey("SMONTH") ? param["SMONTH"] : "";
            string fanoList = param != null && param.ContainsKey("FANO_LIST") ? param["FANO_LIST"] : "";
            if (string.IsNullOrEmpty(month) || string.IsNullOrEmpty(fanoList))
            {
                throw new InvalidOperationException("점검월과 출력할 설비를 선택해주세요.");
            }

            ItsMaria maria = new ItsMaria("PRD6001_S01", "PRINT_MONTH_SHEET");
            maria.AddParam("SMONTH", month);
            maria.AddParam("FANO_LIST", fanoList);
            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }
            if (ds == null || ds.Tables.Count < 3 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 설비가 없습니다.");
            }

            // 첫 설비는 이 리포트에, 나머지는 같은 양식(S01)으로 만들어 페이지를 이어 붙임
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow head = ds.Tables[0].Rows[i];
                string fano = Convert.ToString(head["FANO"]);
                S01 sheet = i == 0 ? this : new S01();
                sheet.FillSheet(head, Rows(ds.Tables[1], fano), Rows(ds.Tables[2], fano), Convert.ToString(head["MON"]), true);
                sheet.CreateDocument();
                if (i > 0)
                {
                    this.Pages.AddRange(sheet.Pages);
                }
            }
        }

        // 한 설비의 행만
        private static DataTable Rows(DataTable src, string fano)
        {
            DataTable dt = src.Clone();
            foreach (DataRow r in src.Rows)
            {
                if (Convert.ToString(r["FANO"]) == fano) dt.ImportRow(r);
            }
            return dt;
        }
    }
}
