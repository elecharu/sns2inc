using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// ERP table Ourey 조건 변경을 위한 Class
/// </summary>
namespace ITSIF_INTERFACE
{
    public class QueryClass
    {
        static QueryClass _this = new QueryClass();

        public static QueryClass This
        {
            get { return _this; }
        }

        /// <summary>
        /// 법인정보 TABLE
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ERP_bcc100_Qurey(string name)
        {
            string query = string.Empty;

            query = "SELECT " +
                    "co_cd, co_no, co_nm, co_bnm, co_dt," +
                    "fr_dt, to_dt, co_bc, biz_bc, head_bs," +
                    "nat_cd, addr, zip_cd,ceo_nm,ceo_id,approv_no," +
                    "trade_no,sys_cd,cury_bc,capital_amt,set_mon," +
                    "vat_kd,vat_bc," +
                    "fta_cd,disp_sq,rmks,cid,cdt,mid,mdt" +
                    " FROM " + name;

            return query;
        }

        /// <summary>
        /// 사업장정보 TABLE
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ERP_bcc200_Qurey(string name)
        {
            string query = string.Empty;

            query = "SELECT " +
                    "bs_cd," +//사업장코드
                    "bs_nm," +//사업장명
                    "bs_bnm," +//사업장명_약칭
                    "ceo_nm," +//대표자명
                    "bs_enm," +//사업장명(영문)
                    "biz_no," +//사업자등록번호
                    "biz_pnm," +//사업장명_인쇄용
                    "biz_kind," +//업종
                    "biz_type," +//업태
                    "biz_kind_prt," +//업종_인쇄용
                    "biz_type_prt," +//업태_인쇄용
                    "tax_area," +//사업소면적_과세
                    "notax_area," +//사업소면적_비과세
                    "nat_cd," +//소재국가 - BC:BC410S
                    "biz_bc," +//사업군(채권단위)
                    "cury_bc," +//기준통화 - BC:BC400
                    "fr_dt," +//개업일자
                    "to_dt," +//폐업일자
                    "open_dt," +//영업개시일
                    "zip_cd," +//우편번호
                    "addr," +//주소1
                    "addr_prt," +//주소_인쇄용
                    "tel," +//대표전화
                    "fax," +//대표Fax
                    "email," +//Email
                    "homepage," +//HomePage
                    "tel2," +//대표전화(해외)
                    "hometax_id," +//HomeTaxID
                    "fax2," +//대표Fax(해외)
                    "tax_ofc_cd," +//관활세무서코드
                    "local_ofc_cd," +//지방세납부관공서
                    "tax_pay_cd," +//세무서납세코드
                    "vat_close_dt," +//부가세마감일
                    "head_yn," +//본사여부 - D:0
                    "bank_cd," +//은행코드
                    "acct_nm," +//예금주
                    "acct_no," +//계좌번호
                    "frn_yn," +//외국인단일세율적용여부
                    "con_in_tm," +//출근감안시간-분
                    "con_out_tm," +//퇴근감안시간-분
                    "unit_tm," +//단위시간-분
                    "tax_bank," +//부가세환급은행코드
                    "tax_acct," +//부가세환급계좌
                    "tax_bank_loc," +//부가세환급지점
                    "tax_bs," +//원천징수사업장 - BC:BC120S
                    "app_bs," +//귀속사업장 - BC:BC120S
                    "co_cd," +//법인코드 - BC:BC110S
                    "disp_sq," +//출력순번
                    "use_yn," +//운영여부 - D:1
                    "rmks," +//설명
                    "cid," +//생성자
                    "cdt," +//생성일
                    "mid," +//수정자
                    "mdt," +//수정일
                    "div_cd" +//회계단위
                    " FROM " + name;

            return query;
        }

        public string ERP_bca100_Qurey(string name)
        {
            string query = string.Empty;

            query = "SELECT " +
                    "bca100.main_cd, title, mdl_cd, " +
                    "grp_nm, sort_bc, user_yn, use_yn, " +
                    "popup_id, B.REF1, B.REF2, B.REF3, " +
                    "B.REF4, B.REF5, B.REF6, B.REF7, " +
                    "B.REF8, B.REF9, B.REF10, B.REF11, " +
                    "B.REF12, B.REF13, B.REF14, B.REF15, " +
                    "B.REF16, B.REF17, B.REF18, B.REF19, " +
                    "B.REF20, rmks, cid, cdt, " +
                    "mid, mdt, sys_yn " +
                    "FROM bca100 " +
                    "LEFT JOIN " +
                    "(SELECT " +
                        "T.main_cd " +
                        ", MAX(CASE WHEN T.mng_sq = 1 THEN T.title ELSE NULL END) AS REF1" +
                        ", MAX(CASE WHEN T.mng_sq = 2 THEN T.title ELSE NULL END) AS REF2" +
                        ", MAX(CASE WHEN T.mng_sq = 3 THEN T.title ELSE NULL END) AS REF3" +
                        ", MAX(CASE WHEN T.mng_sq = 4 THEN T.title ELSE NULL END) AS REF4" +
                        ", MAX(CASE WHEN T.mng_sq = 5 THEN T.title ELSE NULL END) AS REF5" +
                        ", MAX(CASE WHEN T.mng_sq = 6 THEN T.title ELSE NULL END) AS REF6" +
                        ", MAX(CASE WHEN T.mng_sq = 7 THEN T.title ELSE NULL END) AS REF7" +
                        ", MAX(CASE WHEN T.mng_sq = 8 THEN T.title ELSE NULL END) AS REF8" +
                        ", MAX(CASE WHEN T.mng_sq = 9 THEN T.title ELSE NULL END) AS REF9" +
                        ", MAX(CASE WHEN T.mng_sq = 10 THEN T.title ELSE NULL END) AS REF10" +
                        ", MAX(CASE WHEN T.mng_sq = 11 THEN T.title ELSE NULL END) AS REF11" +
                        ", MAX(CASE WHEN T.mng_sq = 12 THEN T.title ELSE NULL END) AS REF12" +
                        ", MAX(CASE WHEN T.mng_sq = 13 THEN T.title ELSE NULL END) AS REF13" +
                        ", MAX(CASE WHEN T.mng_sq = 14 THEN T.title ELSE NULL END) AS REF14" +
                        ", MAX(CASE WHEN T.mng_sq = 15 THEN T.title ELSE NULL END) AS REF15" +
                        ", MAX(CASE WHEN T.mng_sq = 16 THEN T.title ELSE NULL END) AS REF16" +
                        ", MAX(CASE WHEN T.mng_sq = 17 THEN T.title ELSE NULL END) AS REF17" +
                        ", MAX(CASE WHEN T.mng_sq = 18 THEN T.title ELSE NULL END) AS REF18" +
                        ", MAX(CASE WHEN T.mng_sq = 19 THEN T.title ELSE NULL END) AS REF19" +
                        ", MAX(CASE WHEN T.mng_sq = 20 THEN T.title ELSE NULL END) AS REF20 " +
                    "FROM(" +
                            "SELECT * FROM bca150" +
                         ") T " +
                    "GROUP BY T.main_cd) AS B " +
                    "ON bca100.main_cd = B.main_cd;";

            return query;
        }

        public string ERP_bca200_Qurey(string name)
        {
            string query = string.Empty;

            query = "SELECT " +
                    "bca200.base_cd AS base_cd, main_cd, sub_cd, " +
                    "title, ord_sq, user_yn, use_yn, " +
                    "old_cd, A.REF1, A.REF2, " +
                    "A.REF3, A.REF4, rmks, cid, " +
                    "cdt, mid, sys_yn " +
                    "FROM bca200 " +
                    "LEFT JOIN " +
                    "(SELECT " +
                        "T.base_cd " +
                        ", MAX(CASE WHEN T.mng_sq = 1 THEN T.mng_val ELSE NULL END) AS REF1" +
                        ", MAX(CASE WHEN T.mng_sq = 2 THEN T.mng_val ELSE NULL END) AS REF2" +
                        ", MAX(CASE WHEN T.mng_sq = 3 THEN T.mng_val ELSE NULL END) AS REF3" +
                        ", MAX(CASE WHEN T.mng_sq = 4 THEN T.mng_val ELSE NULL END) AS REF4 " +
                    "FROM(" +
                         "SELECT * FROM bca250" +
                         ") T " +
                    "GROUP BY T.base_cd) AS A " +
                    "ON bca200.base_cd = A.base_cd;";

            return query;
        }

        public string ERP_dma100_Qurey(string name)
        {
            string query = string.Empty;

            query = "SELECT " +
                     "A.itm_id, A.itm_cd, A.co_cd, B.model_cd, " +
                     "B.color_cd, B.my_cd, A.itm_nm, A.itm_bnm, " +
                     "B.main_part, B.main_id, B.tran_id, B.pair_id, " +
                     "B.pair_cd, A.spec, A.um_bc, A.src_bc,  " +
                     "A.itm_bc, A.grp1_cd, A.grp2_cd, A.grp3_cd, " +
                     "A.grp4_cd, A.fr_dt, A.to_dt, A.end_yn,  " +
                     "A.end_uid, A.end_bc, A.insp_bc, A.plan_bc,  " +
                     "A.bar_code, A.cb_itm, A.cb_yn, A.grp5_cd,  " +
                     "A.part_no, B.sepa_yn, B.nat_cd, B.hs_cd,  " +
                     "B.rev, B.sect_no, B.draw_dt, B.size_bc, B.draw_qty, " +
                     "B.wgt, B.mat, B.lng, B.dia,  " +
                     "B.thk, B.wid, B.spec2, B.st,  " +
                     "B.ct, B.tranday, B.spec1, B.spec3,  " +
                     "B.spec4, B.spec5, B.spec6, B.spec7, " +
                     "B.spec8, B.spec9, B.spec10, B.spec11, " +
                     "B.spec12, B.spec13, B.spec14, B.spec15,  " +
                     "B.spec16, B.spec17, B.spec18, B.spec19,  " +
                     "B.spec20, B.exp_days, B.std_box_qty, B.link_id, " +
                     "B.wonga_id, B.wonga_id, B.product_dt, B.pack_qty,  " +
                     "B.pack_lay, B.dept_cd, B.dev_rid, A.rmks,  " +
                     "A.cid, A.cdt, A.mid, A.mdt " +
                     "FROM DMA100 AS A " +
                     "INNER JOIN DMA110 AS B ON A.itm_id = B.itm_id; ";

            return query;
        }

        public string ERP_ppz350_Qurey(string name)
        {
            string query = string.Empty;

            query = "SELECT " +
                    "PPZ350.fa_no, PPZ350.itm_id, PPZ350.fr_dt, PPZ350.to_dt, " +
                    "PPZ350.rmks, PPZ350.cid, PPZ350.cdt, PPZ350.mid, " +
                    "PPZ350.mdt, PPZ350.gubun_bc, PPZ350.mc_cd " +
                    "FROM PPZ350 " +
                    "LEFT JOIN PPZ300 ON PPZ350.mc_cd = PPZ300.mc_cd " +
                    "WHERE wc_cd IN('200', '230', '220'); ";

            return query;
        }

        

        public string ERP_dma210_Qurey(string name)
        {
            string query = string.Empty;

            query = "SELECT * " +
                    "FROM DMA210 " +
                    "WHERE itm_id IN(" +
                    "'333791','346204','347578','332847'" +
                    ");";

            return query;
        }
    }
}
