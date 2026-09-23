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

public partial class GetDailyCardLogEx : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - ID : 바로빌 회원 아이디
     * - CardNum : 카드번호
     * - BaseDate : 조회기준일자. (yyyyMMdd 형식)
     * - CountPerPage : 한 페이지 당 조회 건 수
     * - CurrentPage : 조회할 페이지 번호
     * - OrderDirection : 정렬방향 (1:ASC 2:DESC)
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //카드사용내역을 1일분씩 조회 (GetDailyCardLog 에 비해 더 많은 가맹점 정보를 제공)
        BaroService_CARD BS_CARD = new BaroService_CARD();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");                //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");        //바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string UserID = Request["ID"].ToString();                               //바로빌 회원 아이디
        string CardNum = Request["CardNum"].ToString().Replace("-", "");        //카드번호
        string BaseDate = Request["BaseDate"].ToString().Replace("-", "");      //조회기준일자. (yyyyMMdd 형식)
        int CountPerPage = Int32.Parse(Request["CountPerPage"].ToString());     //한 페이지 당 조회 건 수
        int CurrentPage = Int32.Parse(Request["CurrentPage"].ToString());       //조회할 페이지 번호
        int OrderDirection = Int32.Parse(Request["OrderDirection"].ToString()); //정렬방향 (1:ASC 2:DESC)

        PagedCardLogEx Result = BS_CARD.GetDailyCardLogEx(CERTKEY, CorpNum, UserID, CardNum, BaseDate, CountPerPage, CurrentPage, OrderDirection);

        int intResult = Result.CurrentPage;
        string responseStr = "";

        if (intResult < 0) //실패
        {
            responseStr = "ERROR: " + BS_CARD.GetErrString(CERTKEY, intResult);
        }
        else //성공
        { 
            responseStr = JsonConvert.SerializeObject(Result);
        }
        Response.Write(responseStr);
        Response.End();
    }
}