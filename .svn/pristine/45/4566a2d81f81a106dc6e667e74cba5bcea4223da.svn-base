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

public partial class GetBankAccount : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - ID : 바로빌 회원 아이디
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //등록한 계좌정보를 조회
        BaroService_BANKACCOUNT BS_BANKACCOUNT = new BaroService_BANKACCOUNT();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");        //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");//바로빌 회원 사업자번호 ('-' 제외, 10자리)

        BankAccount[] Result = BS_BANKACCOUNT.GetBankAccount(CERTKEY, CorpNum);

        int intResult = 0;
        Int32.TryParse(Result[0].BankAccountNum, out intResult);
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