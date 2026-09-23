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

public partial class RegistModifyTaxInvoice_TEMP : BasePage
{
    /* Request
     * - PurposeType : 1-영수, 2-청구
     * - ModifyCode : 수정사유코드 (1-기재사항의 착오 정정, 2-공급가액의 변동, 3-재화의 환입, 4-계약의 해제, 5-내국신용장 사후개설, 6-착오에 의한 이중발행)
     * - AmountTotal : 공급가액 총액
     * - TaxTotal : 세액합계 (taxInvoice.TaxType 이 2 또는 3 으로 셋팅된 경우 0으로 입력)
     * - TotalAmount : 합계금액
     * - Remark1 : 비고1
     * - Remark2 : 비고2
     * - Remark3 : 비고3
     * - MgtNum : 연동사부여 문서키 
     * - CorpNum : 공급자 사업자번호 ('-' 제외, 10자리) 
     * - TaxRegID : 공급자 종사업장번호
     * - CorpName : 공급자 회사명
     * - CEOName : 공급자 대표자명
     * - Addr : 공급자 주소
     * - BizType : 공급자 업종
     * - BizClass : 공급자 업태
     * - ContactID : 바로빌 회원 아이디
     * - ContactName : 공급자 담당자명
     * - TEL : 공급자 전화번호
     * - HP : 공급자 휴대폰
     * - Email : 공급자 이메일
     * - CorpNum_e : 공급받는자 사업자번호 ('-' 제외, 10자리)
     * - TaxRegID_e : 공급받는자 종사업장번호
     * - CorpName_e : 공급받는자 회사명
     * - CEOName_e : 공급받는자 대표자명
     * - Addr_e : 공급받는자 주소
     * - BizType_e : 공급받는자 업종
     * - BizClass_e : 공급받는자 업태
     * - ContactName_e : 공급받는자 담당자명
     * - TEL_e : 공급받는자 전화번호
     * - HP_e : 공급받는자 휴대폰
     * - Email_e : 공급받는자 이메일
     * - itemQty : 품목 수량
     * - PurchaseExpiry : 품목 공급일자 리스트, 구분자 : ▥
     * - Name : 품목명 리스트, 구분자 : ▥
     * - Information : 품목 규격, 구분자 : ▥
     * - ChargeableUnit : 품목 수량, 구분자 : ▥
     * - UnitPrice : 품목 단가, 구분자 : ▥
     * - Amount : 품목 공급가액, 구분자 : ▥
     * - Tax : 세액, 구분자 : ▥
     * - Description : 품목 비고, 구분자 : ▥
     * - OriginalNTSSendKey : 당초 세금계산서의 국세청 승인번호 (바로빌을 통해 발행된 세금계산서만 가능합니다.)
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        //세금계산서 임시저장 (즉시발행 - IssueTaxInvoice, 발행예정 - PreIssueTaxInvoice)
        BaroService_TI BS_TI = new BaroService_TI();

        string CERTKEY = GetSession("SESSION_BILLCERTKEY");                //인증키

        //******************************* 기본정보 ****************************************
        TaxInvoice taxInvoice = new TaxInvoice();
        taxInvoice.IssueDirection = 1;                                          //1-정발행, 2-역발행(위수탁 세금계산서는 정발행만 허용)
        taxInvoice.TaxInvoiceType = 1;                                          //1-세금계산서, 2-계산서, 4-위수탁세금계산서, 5-위수탁계산서
        taxInvoice.TaxType = 1;                                                 //과세형태
                                                                                //TaxInvoiceType 이 1,4 일 때 : 1-과세, 2-영세
                                                                                //TaxInvoiceType 이 2,5 일 때 : 3-면세
        taxInvoice.TaxCalcType = 1;                                             //세율계산방법 : 1-절상, 2-절사, 3-반올림
        taxInvoice.PurposeType = Int32.Parse(Request["PurposeType"].ToString());//1-영수, 2-청구
        taxInvoice.ModifyCode = Request["ModifyCode"].ToString();               //수정사유코드 (1-기재사항의 착오 정정, 2-공급가액의 변동, 3-재화의 환입, 4-계약의 해제, 5-내국신용장 사후개설, 6-착오에 의한 이중발행)
        taxInvoice.Kwon = "";                                                   //별지서식 11호 상의 [권] 항목
        taxInvoice.Ho = "";                                                     //별지서식 11호 상의 [호] 항목
        taxInvoice.SerialNum = "";                                              //별지서식 11호 상의 [일련번호] 항목
        taxInvoice.AmountTotal = Request["AmountTotal"].ToString();             //공급가액 총액
        taxInvoice.TaxTotal = Request["TaxTotal"].ToString();                   //세액합계 (taxInvoice.TaxType 이 2 또는 3 으로 셋팅된 경우 0으로 입력)
        taxInvoice.TotalAmount = Request["TotalAmount"].ToString();             //합계금액
        taxInvoice.Cash = "";                                                   //현금
        taxInvoice.ChkBill = "";                                                //수표
        taxInvoice.Note = "";                                                   //어음
        taxInvoice.Credit = "";                                                 //외상미수금
        taxInvoice.Remark1 = Request["Remark1"].ToString();                     //비고1
        taxInvoice.Remark2 = Request["Remark2"].ToString();                     //비고2
        taxInvoice.Remark3 = Request["Remark3"].ToString();                     //비고3
        taxInvoice.WriteDate = "";                                              //작성일자 (YYYYMMDD) (공백입력 시 Today로 작성됨)

        //******************************* 공급자, 공급받은자 정보 ****************************************
        //공급자 정보 - 정발행시 세금계산서 작성자
        taxInvoice.InvoicerParty = new InvoiceParty();
        taxInvoice.InvoicerParty.MgtNum = Request["MgtNum"].ToString();         //연동사부여 문서키 
        taxInvoice.InvoicerParty.CorpNum = Request["CorpNum"].ToString().Replace("-", "");       //사업자번호 ('-' 제외, 10자리) 
        taxInvoice.InvoicerParty.TaxRegID = Request["TaxRegID"].ToString();     //종사업장번호
        taxInvoice.InvoicerParty.CorpName = Request["CorpName"].ToString();     //회사명
        taxInvoice.InvoicerParty.CEOName = Request["CEOName"].ToString();       //대표자명
        taxInvoice.InvoicerParty.Addr = Request["Addr"].ToString();             //주소
        taxInvoice.InvoicerParty.BizType = Request["BizType"].ToString();       //업종
        taxInvoice.InvoicerParty.BizClass = Request["BizClass"].ToString();     //업태
        taxInvoice.InvoicerParty.ContactID = Request["ContactID"].ToString();   //바로빌 회원 아이디
        taxInvoice.InvoicerParty.ContactName = Request["ContactName"].ToString();//담당자명
        taxInvoice.InvoicerParty.TEL = Request["TEL"].ToString();               //전화번호
        taxInvoice.InvoicerParty.HP = Request["HP"].ToString();                 //휴대폰
        taxInvoice.InvoicerParty.Email = Request["Email"].ToString();           //이메일

        //공급받는자 정보 - 역발행시 세금계산서 작성자
        taxInvoice.InvoiceeParty = new InvoiceParty();
        taxInvoice.InvoiceeParty.MgtNum = "";                                   //연동사부여 문서키 (역발행인 경우에만 입력)
        taxInvoice.InvoiceeParty.CorpNum = Request["CorpNum_e"].ToString().Replace("-", "");     //사업자번호 ('-' 제외, 10자리) 
        taxInvoice.InvoiceeParty.TaxRegID = Request["TaxRegID_e"].ToString();   //종사업장번호
        taxInvoice.InvoiceeParty.CorpName = Request["CorpName_e"].ToString();   //회사명
        taxInvoice.InvoiceeParty.CEOName = Request["CEOName_e"].ToString();     //대표자명
        taxInvoice.InvoiceeParty.Addr = Request["Addr_e"].ToString();           //주소
        taxInvoice.InvoiceeParty.BizType = Request["BizType_e"].ToString();     //업종
        taxInvoice.InvoiceeParty.BizClass = Request["BizClass_e"].ToString();   //업태
        taxInvoice.InvoiceeParty.ContactID = "";                                //바로빌 회원 아이디 (역발행인 경우에만 입력)
        taxInvoice.InvoiceeParty.ContactName = Request["ContactName_e"].ToString(); //담당자명
        taxInvoice.InvoiceeParty.TEL = Request["TEL_e"].ToString();             //전화번호
        taxInvoice.InvoiceeParty.HP = Request["HP_e"].ToString();               //휴대폰
        taxInvoice.InvoiceeParty.Email = Request["Email_e"].ToString();         //이메일

        //수탁자 정보 - 위수탁 발행시 세금계산서 작성자
        taxInvoice.BrokerParty = new InvoiceParty();
        taxInvoice.BrokerParty.MgtNum = "";                                     //연동사부여 문서키 (위수탁인 경우에만 입력)
        taxInvoice.BrokerParty.CorpNum = "";                                    //사업자번호 ('-' 제외, 10자리) 
        taxInvoice.BrokerParty.TaxRegID = "";                                   //종사업장번호
        taxInvoice.BrokerParty.CorpName = "";                                   //회사명
        taxInvoice.BrokerParty.CEOName = "";                                    //대표자명
        taxInvoice.BrokerParty.Addr = "";                                       //주소
        taxInvoice.BrokerParty.BizType = "";                                    //업종
        taxInvoice.BrokerParty.BizClass = "";                                   //업태
        taxInvoice.BrokerParty.ContactID = "";                                  //바로빌 회원 아이디 (위수탁인 경우에만 입력)
        taxInvoice.BrokerParty.ContactName = "";                                //담당자명
        taxInvoice.BrokerParty.TEL = "";                                        //전화번호
        taxInvoice.BrokerParty.HP = "";                                         //휴대폰
        taxInvoice.BrokerParty.Email = "";                                      //이메일

        //******************************* 품목 ****************************************
        //품목
        int itemQty = Int32.Parse(Request["itemQty"].ToString());
        string[] purchaseExpiry = Request["PurchaseExpiry"].ToString().Split('▥');
        string[] name = Request["Name"].ToString().Split('▥');
        string[] information = Request["Information"].ToString().Split('▥');
        string[] chargeableUnit = Request["ChargeableUnit"].ToString().Split('▥');
        string[] unitPrice = Request["UnitPrice"].ToString().Split('▥');
        string[] amount = Request["Amount"].ToString().Split('▥');
        string[] tax = Request["Tax"].ToString().Split('▥');
        string[] description = Request["Description"].ToString().Split('▥');

        taxInvoice.TaxInvoiceTradeLineItems = new TaxInvoiceTradeLineItem[itemQty];
        for (int i = 0; i < taxInvoice.TaxInvoiceTradeLineItems.Length; i++)
        {
            taxInvoice.TaxInvoiceTradeLineItems[i] = new TaxInvoiceTradeLineItem();
            taxInvoice.TaxInvoiceTradeLineItems[i].PurchaseExpiry = purchaseExpiry[i];  //공급일자 (YYYYMMDD)
            taxInvoice.TaxInvoiceTradeLineItems[i].Name = name[i];                      //품목명
            taxInvoice.TaxInvoiceTradeLineItems[i].Information = information[i];        //규격
            taxInvoice.TaxInvoiceTradeLineItems[i].ChargeableUnit = chargeableUnit[i];  //수량
            taxInvoice.TaxInvoiceTradeLineItems[i].UnitPrice = unitPrice[i];            //단가
            taxInvoice.TaxInvoiceTradeLineItems[i].Amount = amount[i];                  //공급가액
            taxInvoice.TaxInvoiceTradeLineItems[i].Tax = tax[i];                        //세액
            taxInvoice.TaxInvoiceTradeLineItems[i].Description = description[i];        //비고
        }
        string OriginalNTSSendKey = Request["OriginalNTSSendKey"].ToString();		    //당초 세금계산서의 국세청 승인번호 (바로빌을 통해 발행된 세금계산서만 가능합니다.)

        //******************************* 발행 ****************************************
        int Result = BS_TI.RegistModifyTaxInvoice(CERTKEY, taxInvoice.InvoicerParty.CorpNum, taxInvoice, OriginalNTSSendKey);           //정발행
        //int Result = BS_TI.RegistModifyBrokerTaxInvoice(CERTKEY, taxInvoice.BrokerParty.CorpNum, taxInvoice, OriginalNTSSendKey);		//위수탁
        string responseStr = "";
        if (Result == 1)
        {
            responseStr = "정상 처리되었습니다.";
        }
        else
        {
            responseStr = "ERROR: " + BS_TI.GetErrString(CERTKEY, Result);
        }

        Response.Write(responseStr);
        Response.End();
    }
}