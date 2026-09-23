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

public partial class GetCard : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - ID : 바로빌 회원 아이디
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //카드정보를 반환합니다.
        BaroService_CARD BS_CARD = new BaroService_CARD();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");        //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");//바로빌 회원 사업자번호 ('-' 제외, 10자리)

        Card[] Result = BS_CARD.GetCard(CERTKEY, CorpNum);

        int intResult = 0;
        string responseStr = "";

        try
        {
            Int32.TryParse(Result[0].CardNum, out intResult);
            if (intResult < 0) //실패
            {
                responseStr = "ERROR: " + BS_CARD.GetErrString(CERTKEY, intResult);
            }
            else //성공
            { 
                responseStr = JsonConvert.SerializeObject(Result);
            }
        }
        catch
        {
            responseStr = "ERROR: 등록된 카드가 없습니다.";
        }
        Response.Write(responseStr);
        Response.End();
    }
}