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

public partial class GetCardScrapRequestURL : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - ID : 바로빌 회원 아이디
     * - PWD : 바로빌 회원 비밀번호
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //카드 조회 서비스를 신청할 수 있는 URL을 반환
        BaroService_CARD BS_CARD = new BaroService_CARD();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");        //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");//바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string ID = Request["ID"].ToString();                           //바로빌 회원 아이디
        string PWD = Request["PWD"].ToString();                         //바로빌 회원 비밀번호

        string Result = BS_CARD.GetCardScrapRequestURL(CERTKEY, CorpNum, ID, PWD);
        if (Result.Substring(0, 1) == "-")
        {
            Result = "ERROR: " + BS_CARD.GetErrString(CERTKEY, Int32.Parse(Result));
        }
        Response.Write(Result);
        Response.End();
    }
}