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

public partial class PreIssueTaxInvoice : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - MgtKey : 연동사부여 문서키
     * - MailTitle : 발행 알림메일의 제목 (공백이나 Null의 경우 바로빌 기본값으로 전송됨.) 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //세금계산서 발행예정
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");        //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");//바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string MgtKey = Request["MgtKey"].ToString();                   //연동사부여 문서키
        bool SendSMS = false;                                           //발행예정 알림문자 전송여부 (발행비용과 별도로 과금됨)
        string MailTitle = Request["MailTitle"].ToString();             //발행예정 알림메일의 제목 (공백이나 Null의 경우 바로빌 기본값으로 전송됨.)

        int Result = BS_TI.PreIssueTaxInvoice(CERTKEY, CorpNum, MgtKey, SendSMS, MailTitle);

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