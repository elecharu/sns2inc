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

public partial class SendToNTS : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - MgtKey : 연동사부여 문서키
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        // 국세청 즉시전송
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");               //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");  //바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string MgtKey = Request["MgtKey"].ToString();                     //관리번호

        int Result = BS_TI.SendToNTS(CERTKEY, CorpNum, MgtKey);

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