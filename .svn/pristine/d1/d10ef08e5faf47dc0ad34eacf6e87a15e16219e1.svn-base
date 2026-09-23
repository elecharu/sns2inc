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

public partial class RegistCorp : BasePage
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
     * - MemberName : 담당자 성명
     * - ID : 바로빌 회원 아이디
     * - PWD : 바로빌 회원 비밀번호 (6~20자만 가능)
     * - Grade : 직급       필수 X
     * - TEL : 전화번호
     * - HP : 휴대폰     필수 X
     * - Email : 이메일
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //아이디 만들기
        BaroService_EDOC BS_EDOC = new BaroService_EDOC();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");            //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");    //바로빌 회원 사업자번호 ('-' 제외, 10자리) 
        string CorpName = Request["CorpName"].ToString();                   //회사명
        string CEOName = Request["CEOName"].ToString();                     //대표자명
        string BizType = Request["BizType"].ToString();                     //업태
        string BizClass = Request["BizClass"].ToString();                   //업종
        string PostNum = Request["PostNum"].ToString();                     //우편번호
        string Addr1 = Request["Addr1"].ToString();                         //주소1 (ex. 서울특별시 양천구 목1동)
        string Addr2 = Request["Addr2"].ToString();                         //주소2 (ex. SBS방송센터 920)
        string MemberName = Request["MemberName"].ToString();               //담당자 성명
        string JuminNum = "";                                               //주민등록번호 ('-' 제외, 13자리)
        string ID = Request["ID"].ToString();                               //바로빌 회원 아이디
        string PWD = Request["PWD"].ToString();                             //바로빌 회원 비밀번호 (6~20자만 가능)
        string Grade = Request["Grade"].ToString();                         //직급       필수 X
        string TEL = Request["TEL"].ToString();                             //전화번호
        string HP = Request["HP"].ToString();                               //휴대폰     필수 X
        string Email = Request["Email"].ToString();                         //이메일

        int Result = BS_EDOC.RegistCorp(CERTKEY, CorpNum, CorpName, CEOName, BizType, BizClass, PostNum, Addr1, Addr2, MemberName, JuminNum, ID, PWD, Grade, TEL, HP, Email);

        string responseStr = "";
        if(Result == 1)
        {
            responseStr = "정상 가입되었습니다.";
        }
        else
        {
            responseStr = "ERROR: " + BS_EDOC.GetErrString(CERTKEY, Result);
        }
        Response.Write(responseStr);
        Response.End();
    }
}