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

public partial class GetMonthlyBankAccountLogEx : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - ID : 바로빌 회원 아이디
     * - BankAccountNum : 계좌번호
     * - BaseMonth : 조회기준월. (yyyyMM 형식)
     * - CountPerPage : 한 페이지 당 조회 건 수
     * - CurrentPage : 조회할 페이지 번호
     * - OrderDirection : 정렬방향 (1:ASC 2:DESC)
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //계좌 입출금내역을 1개월분씩 조회 (GetBankAccountLog 에 입출금 내역의 고유 키값을 추가)
        BaroService_BANKACCOUNT BS_BANKACCOUNT = new BaroService_BANKACCOUNT();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");                //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");        //바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string UserID = Request["ID"].ToString();                               //바로빌 회원 아이디
        string BankAccountNum = Request["BankAccountNum"].ToString().Replace("-", "");//계좌번호
        string BaseMonth = Request["BaseMonth"].ToString().Replace("-", "");    //조회기준월. (yyyyMM 형식)
        int CountPerPage = Int32.Parse(Request["CountPerPage"].ToString());     //한 페이지 당 조회 건 수
        int CurrentPage = Int32.Parse(Request["CurrentPage"].ToString());       //조회할 페이지 번호
        int OrderDirection = Int32.Parse(Request["OrderDirection"].ToString()); //정렬방향 (1:ASC 2:DESC)

        PagedBankAccountLogEx Result = BS_BANKACCOUNT.GetMonthlyBankAccountLogEx(CERTKEY, CorpNum, UserID, BankAccountNum, BaseMonth, CountPerPage, CurrentPage, OrderDirection);

        int intResult = Result.CurrentPage;
        string responseStr = "";

        if (intResult < 0) //실패
        {
            responseStr = "ERROR: " + BS_BANKACCOUNT.GetErrString(CERTKEY, intResult);
        }
        else //성공
        { 
            responseStr = JsonConvert.SerializeObject(Result);
        }
        Response.Write(responseStr);
        Response.End();
    }
}