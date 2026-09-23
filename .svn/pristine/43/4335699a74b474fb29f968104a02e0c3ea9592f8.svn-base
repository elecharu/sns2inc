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

public partial class ChangeNTSSendOption : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - ID : 바로빌 회원 아이디
     * - TaxationOption : 과세,영세 국세청 전송옵션 ( 1-발행 익일 자동전송, 2-발행 즉시 전송 )
     * - TaxationAddTaxAllowYN : 과세,영세 가산세 허용여부 ( 1-허용, 0-차단 )
     * - TaxExemptionOption : 면세 국세청 전송옵션 ( 1-발행 익일 자동전송, 2-발행 즉시 전송, 3-수동 전송 )
     * - TaxExemptionAddTaxAllowYN : 면세 가산세 허용여부 ( 1-허용, 0-차단 )
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //전자세금계산서 전송 설정
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");            //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");    //바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string ID = Request["ID"].ToString();                               //바로빌 회원 아이디
        NTSSendOption ntsSendOption = new NTSSendOption();
        ntsSendOption.TaxationOption = Int32.Parse(Request["TaxationOption"].ToString());  
        ntsSendOption.TaxationAddTaxAllowYN = Int32.Parse(Request["TaxationAddTaxAllowYN"].ToString()); 
        ntsSendOption.TaxExemptionOption = Int32.Parse(Request["TaxExemptionOption"].ToString()); 
        ntsSendOption.TaxExemptionAddTaxAllowYN = Int32.Parse(Request["TaxExemptionAddTaxAllowYN"].ToString()); 

        int Result = BS_TI.ChangeNTSSendOption(CERTKEY, CorpNum, ID, ntsSendOption);

        string responseStr = "";
        if(Result == 1)
        {
            responseStr = "전자세금계산서 전송 설정 변경 완료.";
        }
        else
        {
            responseStr = "ERROR: " + BS_TI.GetErrString(CERTKEY, Result);
        }
        
        Response.Write(responseStr);
        Response.End();
    }
}