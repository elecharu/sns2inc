using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using com.baroservice.ws;
using Newtonsoft.Json;

public partial class GetMonthlyTaxInvoicePurchaseList : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - ID : 연계사업자 담당자 아이디
     * - DateType : 조회기준, 1:작성일자 2:발행일자
     * - BaseMonth : 기준월
     * - CountPerPage : 한 페이지 당 조회 건 수
     * - CurrentPage : 현재페이지
     * - OrderDirection : 정렬, 1:ASC 2:DESC
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //세금계산서를 1개월분씩 조회합니다.
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");            //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");    //바로빌 회원 사업자번호 ('-' 제외, 10자리)	
        string UserID = Request["ID"].ToString();                           //바로빌 회원 아이디
        int TaxType = 1;                                                    //과세형태 (1:과세+영세, 3:면세)
        int DateType = Int32.Parse(Request["DateType"].ToString());         //조회기준, 1:작성일자 2:발행일자
        string BaseMonth = Request["BaseMonth"].ToString().Replace("-", "");//기준월
        int CountPerPage = Int32.Parse(Request["CountPerPage"].ToString()); //한 페이지 당 조회 건 수
        int CurrentPage = Int32.Parse(Request["CurrentPage"].ToString());   //현재페이지
        int OrderDirection = Int32.Parse(Request["OrderDirection"].ToString());//1:ASC 2:DESC

        PagedTaxInvoiceEx Result = BS_TI.GetMonthlyTaxInvoicePurchaseList(CERTKEY, CorpNum, UserID, TaxType, DateType, BaseMonth, CountPerPage, CurrentPage, OrderDirection);

        string responseStr = "";
        if (Result.CurrentPage < 0) //실패
        {
            responseStr = "ERROR: " + BS_TI.GetErrString(CERTKEY, Result.CurrentPage);
        }
        else
        {
            responseStr = JsonConvert.SerializeObject(Result);
        }
        Response.Write(responseStr);
        Response.End();
    }
}