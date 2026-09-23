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

public partial class GetTaxInvoice : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - MgtKey : 연동사부여 문서키
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //세금계산서의 내용을 확인합니다.
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");        //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");//바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string MgtKey = Request["MgtKey"].ToString();                   //연동사부여 문서키

        TaxInvoice Result = BS_TI.GetTaxInvoice(CERTKEY, CorpNum, MgtKey);

        string responseStr = "";
        if (Result.TaxInvoiceType < 0) //실패
        {
            responseStr = "ERROR: " + BS_TI.GetErrString(CERTKEY, Result.TaxInvoiceType);
        }
        else
        {
            responseStr = JsonConvert.SerializeObject(Result);
        }
        Response.Write(responseStr);
        Response.End();
    }
}