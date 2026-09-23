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

public partial class SendInvoiceFax : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - MgtKey : 연동사부여 문서키
     * - FromFaxNumber : 발신번호
     * - toFaxNumber : 수신번호 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //세금계산서 이메일 재전송
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");               //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");  //바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string MgtKey = Request["MgtKey"].ToString();                     //연동사부여 문서키
        string FromFaxNumber = Request["FromFaxNumber"].ToString().Replace("-", "");
        string toFaxNumber = Request["toFaxNumber"].ToString().Replace("-", "");

        int Result = BS_TI.SendInvoiceFax(CERTKEY, CorpNum, MgtKey, CorpNum, FromFaxNumber, toFaxNumber);

        string responseStr = "";
        if (Result == 1)
        {
            responseStr = "정상 처리되었습니다.";
        }
        else
        {
            responseStr = "ERROR: " + BS_TI.GetErrString(CERTKEY, Result);
        }
        Response.Write(responseStr);
        Response.End();
    }
}