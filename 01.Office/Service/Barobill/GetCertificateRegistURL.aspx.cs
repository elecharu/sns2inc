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

public partial class GetCertificateRegistURL : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - ID : 연계사업자 담당자 아이디
     * - PWD : 연계사업자 담당자 비밀번호
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //공인인증서 등록 URL
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");            //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");    //바로빌 회원 사업자번호 ('-' 제외, 10자리) 			
        string ID = Request["ID"].ToString();                               //연계사업자 담당자 아이디		
        string PWD = Request["PWD"].ToString();                             //연계사업자 담당자 비밀번호

        string Result = BS_TI.GetCertificateRegistURL(CERTKEY, CorpNum, ID, PWD);
        if (Result.Substring(0, 1) == "-")
        {
            Result = "ERROR: " + BS_TI.GetErrString(CERTKEY, Int32.Parse(Result));
        }

        Response.Write(Result);
        Response.End();
    }
}