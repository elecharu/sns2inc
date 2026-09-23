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

public partial class UpdateCorpInfo : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - CorpName : 회사명
     * - CEOName : 대표자명
     * - BizType : 업태
     * - BizClass : 업종
     * - PostNum : 우편번호
     * - Addr1 : 주소1 (ex. 서울특별시 양천구 목1동)
     * - Addr2 : 주소2 (ex. SBS방송센터 920)
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //정보 수정
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");            //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");    //바로빌 회원 사업자번호 ('-' 제외, 10자리) 
        string CorpName = Request["CorpName"].ToString();                   //회사명
        string CEOName = Request["CEOName"].ToString();                     //대표자명
        string BizType = Request["BizType"].ToString();                     //업태
        string BizClass = Request["BizClass"].ToString();                   //업종
        string PostNum = Request["PostNum"].ToString();                     //우편번호
        string Addr1 = Request["Addr1"].ToString();                         //주소1 (ex. 서울특별시 양천구 목1동)
        string Addr2 = Request["Addr2"].ToString();                         //주소2 (ex. SBS방송센터 920)

        int Result = BS_TI.UpdateCorpInfo(CERTKEY, CorpNum, CorpName, CEOName, BizType, BizClass, PostNum, Addr1, Addr2);

        string responseStr = "";
        if(Result == 1)
        {
            responseStr = "정상 수정되었습니다.";
        }
        else
        {
            responseStr = "ERROR: " + BS_TI.GetErrString(CERTKEY, Result);
        }
        Response.Write(responseStr);
        Response.End();
    }
}