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

public partial class GetTaxInvoiceStatesEX : BasePage
{
    /* Request
     * - CorpNum : 바로빌 회원 사업자번호 ('-' 제외, 10자리)
     * - MgtKey : 연동사부여 문서키 배열 (최대, 100건 까지), 구분자 : ▥
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //여러건의 세금계산서의 상태를 확인합니다
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");        //인증키
        string CorpNum = Request["CorpNum"].ToString().Replace("-", "");//바로빌 회원 사업자번호 ('-' 제외, 10자리)
        string MgtKey = Request["MgtKey"].ToString();
        if(MgtKey.Substring(MgtKey.Length - 1, 1) == "▥")
        {
            MgtKey = MgtKey.Substring(0, MgtKey.Length - 1);
        }

        string[] MgtKeyList = MgtKey.Split('▥'); //연동사부여 문서키 배열 (최대, 100건 까지)

        TaxInvoiceStateEX[] Result = BS_TI.GetTaxInvoiceStatesEX(CERTKEY, CorpNum, MgtKeyList);

        string responseStr = "";
        var JsonArr = new JArray();

        foreach (TaxInvoiceStateEX r in Result)
        {
            if (r.BarobillState < 0) //실패
            {
                responseStr += "ERROR: " + BS_TI.GetErrString(CERTKEY, r.BarobillState) + "▥";
            }
            else
            {
                try
                {
                    r.NTSSendDT = ChangeFormat(r.NTSSendDT);
                    r.NTSResultDT = ChangeFormat(r.NTSResultDT);
                    r.RegistDT = ChangeFormat(r.RegistDT);
                    r.WriteDate = ChangeFormat(r.WriteDate);
                    r.PreIssueDT = ChangeFormat(r.PreIssueDT);
                    r.IssueDT = ChangeFormat(r.IssueDT);

                }
                catch (Exception ex)
                {

                }
                var json = JObject.FromObject(r);
                if (r.NTSSendResult == "" || r.NTSSendResult == null)
                {
                    json.Add("itsSTATE", BarobillState(r.BarobillState.ToString()));
                    json.Add("itsSTTP", "1");
                }
                else
                {
                    json.Add("itsSTATE", NTSSendResult(r.NTSSendResult));
                    json.Add("itsSTTP", "2");
                }

                JsonArr.Add(json);

                //responseStr += JsonConvert.SerializeObject(json) + "▥";
            }
        }
        if(responseStr.Length > 0)
        {
            if (responseStr.Substring(0, 6) != "ERROR")
                responseStr = JsonConvert.SerializeObject(JsonArr);
        }
        else
        {
            responseStr = JsonConvert.SerializeObject(JsonArr);
        }
        Response.Write(responseStr);
        Response.End();
    }

    protected string ChangeFormat(string date)
    {
        string rV = "";
        if (date.Length > 0)
        {
            if (date.Length == 8)
            {
                string yyyy = date.Substring(0, 4);
                string MM = date.Substring(4, 2);
                string dd = date.Substring(6, 2);

                rV = yyyy + "-" + MM + "-" + dd;
            }
            else if (date.Length == 14)
            {
                string yyyy = date.Substring(0, 4);
                string MM = date.Substring(4, 2);
                string dd = date.Substring(6, 2);
                string HH = date.Substring(8, 2);
                string mm = date.Substring(10, 2);
                string ss = date.Substring(12, 2);

                rV = yyyy + "-" + MM + "-" + dd + " " + HH + ":" + mm + ":" + ss;
            }
        }
        return rV;
    }

    protected string BarobillState(string state)
    {
        string value = "";
        switch (state)
        {
            case "1000":
                value = "임시저장";
                break;
            case "2010":
                value = "발행예정 승인대기";
                break;
            case "2011":
                value = "발행예정 승인완료";
                break;
            case "2020":
                value = "역발행요청 발행대기";
                break;
            case "3011":
                value = "발행예정 발행완료";
                break;
            case "3021":
                value = "역발행요청 발행완료";
                break;
            case "3014":
                value = "발행완료";
                break;
            case "4012":
                value = "발행예정 거부";
                break;
            case "4022":
                value = "역발행요청 거부";
                break;
            case "5013":
                value = "발행예정 승인 전 공급자에 의한 취소";
                break;
            case "5023":
                value = "역발행요청 승인 전 공급받는자에 의한 취소";
                break;
            case "5031":
                value = "발행예정 승인 후, 또는 발행완료 후 공급자에 의한 취소";
                break;
        }
        return value;
    }

    protected string NTSSendResult(string state)
    {
        string value = "";
        switch (state)
        {
            case "SUC001":
                value = "국세청 전송 성공";
                break;
            case "SYN002":
                value = "공급사업자, 수탁자 전자서명 오류";
                break;
            case "SYN003":
                value = "승인번호 오류";
                break;
            case "SYN004":
                value = "전자세금계산서 스키마 오류";
                break;
            case "ERR001":
                value = "공급자 사업자번호 오류";
                break;
            case "ERR002":
                value = "공급받는자 사업자번호 오류";
                break;
            case "ERR003":
                value = "수탁자 사업자번호 오류";
                break;
            case "ERR004":
                value = "전송일시 오류";
                break;
            case "ERR005":
                value = "발행일시 오류";
                break;
            case "ERR006":
                value = "작성일시 오류";
                break;
            case "ERR007":
                value = "공급가액, 세액 오류";
                break;
            case "ERR008":
                value = "코드 유형 오류";
                break;
            case "ERR009":
                value = "폐업사업자 발행오류";
                break;
            case "ERR010":
                value = "국세청 등록번호 오류";
                break;
            case "ERR011":
                value = "당초승인번호 오류";
                break;
            case "ERR999":
                value = "기타 오류";
                break;
        }
        return value;
    }
}