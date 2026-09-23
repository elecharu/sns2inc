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

public partial class GetTaxInvoicePrintURL : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - MgtKey : 연동사부여 문서키
     */
    protected void Page_Load(object sender, EventArgs e)
    {

        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");               //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");  //바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string MgtKey = Request["MgtKey"].ToString();                     //관리번호
        string ID = Request["BTAXID"].ToString();
        string Result = BS_TI.GetTaxInvoicePrintURL(CERTKEY, CorpNum, MgtKey, ID, "");

        string responseStr = "";
  
        responseStr = Result;

        Response.Write(responseStr);
        Response.End();
    }
}