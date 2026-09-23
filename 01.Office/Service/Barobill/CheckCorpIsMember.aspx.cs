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

public partial class CheckCorpIsMember : BasePage
{
    /* Request
     * - CheckCorpNum : 확인할 사업자번호 ('-' 제외, 10자리) 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //가입여부 확인
        BaroService_EDOC BS_EDOC = new BaroService_EDOC();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");                    //인증키
        string CorpNum = "3091761197";                                              //바로빌 회원 사업자번호 ('-' 제외, 10자리) 			
        string CheckCorpNum = Request["CheckCorpNum"].ToString().Replace("-","");   //확인할 사업자번호 ('-' 제외, 10자리) 

        int Result = BS_EDOC.CheckCorpIsMember(CERTKEY, CorpNum, CheckCorpNum);

        string responseStr = "";
        if(Result == 1)
        {
            responseStr = "true";
        }
        else
        {
            if(Result == 0)
            {
                responseStr = "false";
            }
            else
            {
                responseStr = "ERROR: " + BS_EDOC.GetErrString(CERTKEY, Result);
            }
        }
        
        Response.Write(responseStr);
        Response.End();
    }
}