/// <reference path="../Script/reference.js" />
var ItsBaroBill = function (BDVCD) {
    this.isError = false;
    this.errMessage = '';
    this.value = '';
    this.params = [];

    this.BDVCD = BDVCD;

    var maria = new ItsMaria('BAROBILL_SERVICE', 'GET_BDV');
    maria.AddParam('BDVCD', BDVCD);
    maria.AddParam('COMPCD', BDVCD);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    this.BDVDATA = maria.store.FirstRecord();
};

//전송용 파라메터
ItsBaroBill.prototype.AddParam = function (field, value) {
    if (value == undefined) {
        value = '';
    }
    if (ItsHelper.toString(field) == '') {
        return false;
    } else {
        this.params[field] = value;
        return true;
    }
};

//전송용 파라메터 (품목용)
ItsBaroBill.prototype.AddList = function (field, value) {
    if (value == undefined) {
        value = '';
    }

    if (ItsHelper.toString(field) == '') {
        return false;
    } else {
        if (this.params[field] == undefined)
            this.params[field] = '';
        this.params[field] += value + '▥';
        return true;
    }
};

//전송용 파라메터 가져오기 (resetvalue : 입력시 해당 필드에 값이 없으면 이 값으로 나옴 미입력시 ''으로 나옴)
ItsBaroBill.prototype.GetParam = function (field, resetvalue) {
    if(this.params[field] == undefined || this.params[field] == null){
        if(resetvalue == undefined || resetvalue == null)
            return '';
        else
            return resetvalue;
    }
    else{
        return this.params[field];
    }
};

//전송용 파라메터 비우기 (field 입력시 해당 field만 비우고 빈값 입력시 전체 비움)
ItsBaroBill.prototype.RemoveParam = function (field) {
    if (field == undefined || field == '') {
        this.params = [];
    }
    else {
        this.params[field] = undefined;
    }
};
/**************************************************** 공통 *******************************************************/
//아이디 존재 확인
ItsBaroBill.prototype.CheckMember = function (regno) {
    var REGNO = regno;
    if (regno == '' || regno == undefined) {
        REGNO = this.BDVDATA.REGNO;
    }

    if (REGNO == '') {
        this.isError = true;
        this.errMessage = 'ERROR: 사업자 번호가 비어있습니다.';
        this.value = '';
        return;
    }

    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/CheckCorpIsMember.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CheckCorpNum: REGNO,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                if (data == 'true')
                    this.barobill.value = true;
                else
                    this.barobill.value = false;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//아이디 만들기
ItsBaroBill.prototype.MakeId = function () {
    if (this.REGNO == '') {
        ItsMsg.Alert('사업자 번호를 입력하십시오.');
        return;
    }
    if (this.BDVNMFULL == '') {
        ItsMsg.Alert('회사명을 입력하십시오.');
        return;
    }
    if (this.PRESIDENT == '') {
        ItsMsg.Alert('대표자명을 입력하십시오.');
        return;
    }
    if (this.INDTYPE == '') {
        ItsMsg.Alert('업태를 입력하십시오.');
        return;
    }
    if (this.INDCLASS == '') {
        ItsMsg.Alert('업종을 입력하십시오.');
        return;
    }
    if (this.ZIPCD == '') {
        ItsMsg.Alert('우편번호를 입력하십시오.');
        return;
    }
    if (this.ADDRESS == '') {
        ItsMsg.Alert('주소를 입력하십시오.');
        return;
    }
    if (this.ADDRESSDETAIL == '') {
        ItsMsg.Alert('상세 주소를 입력하십시오.');
        return;
    }
    if (this.PRSNNM == '') {
        ItsMsg.Alert('담당자 정보를 입력하십시오.');
        return;
    }
    if (this.PRSNTELNO == '') {
        ItsMsg.Alert('전화번호를 입력하십시오.');
        return;
    }
    if (this.PRSNEMAIL == '') {
        ItsMsg.Alert('계산서 이메일을 입력하십시오.');
        return;
    }

    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/RegistCorp.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            CorpName: this.BDVDATA.BDVNMFULL, // 회사명
            CEOName: this.BDVDATA.PRESIDENT, // 대표자명
            BizType: this.BDVDATA.INDTYPE, // 업태
            BizClass: this.BDVDATA.INDCLASS, // 업종
            PostNum: this.BDVDATA.ZIPCD, // 우편번호
            Addr1: this.BDVDATA.ADDRESS, // 주소1 (ex. 서울특별시 양천구 목1동)
            Addr2: this.BDVDATA.ADDRESSDETAIL, // 주소2 (ex. SBS방송센터 920)
            MemberName: this.BDVDATA.PRSNNM, // 담당자 성명
            ID : this.BDVDATA.REGNO, // 바로빌 회원 아이디
            PWD : this.BDVDATA.REGNO, // 바로빌 회원 비밀번호 (6~20자만 가능)
            Grade : '', // 직급       필수 X
            TEL: this.BDVDATA.PRSNTELNO, // 전화번호
            HP: this.BDVDATA.PRSNPHONE, // 휴대폰     필수 X
            Email: this.BDVDATA.PRSNEMAIL, // 이메일
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = true;

                var maria = new ItsMaria('BAROBILL_SERVICE', 'SET_ID');
                maria.AddParam('BDVCD', this.barobill.BDVCD);
                maria.AddParam('ID', this.barobill.BDVDATA.REGNO);
                maria.AddParam('PW', this.barobill.BDVDATA.REGNO);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//아이디 설정
ItsBaroBill.prototype.ChangeOption = function (TaxationOption, TaxationAddTaxAllowYN, TaxExemptionOption, TaxExemptionAddTaxAllowYN) {
    //TaxationOption - 과세,영세 국세청 전송옵션 : 1-발행 익일 자동전송, 2-발행 즉시 전송
    //TaxationAddTaxAllowYN - 과세,영세 가산세 허용여부 : 1-허용, 0-차단
    //TaxExemptionOption - 면세 국세청 전송옵션 : 1-발행 익일 자동전송, 2-발행 즉시 전송, 3-수동 전송
    //TaxExemptionAddTaxAllowYN - 면세 가산세 허용여부 : 1-허용, 0-차단
    var option1 = '1';
    if (TaxationOption == '1' || TaxationOption == '2') {
        option1 = TaxationOption;
    }
    var option2 = 1;
    if (TaxationAddTaxAllowYN == '1' || TaxationAddTaxAllowYN == '0') {
        option2 = TaxationAddTaxAllowYN;
    }
    var option3 = 1;
    if (TaxExemptionOption == '1' || TaxExemptionOption == '2' || TaxExemptionOption == '3') {
        option3 = TaxExemptionOption;
    }
    var option4 = 1;
    if (TaxExemptionAddTaxAllowYN == '1' || TaxExemptionAddTaxAllowYN == '0') {
        option4 = TaxExemptionAddTaxAllowYN;
    }

    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/ChangeNTSSendOption.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.REGNO,
            TaxationOption: option1,
            TaxationAddTaxAllowYN: option2,
            TaxExemptionOption: option3,
            TaxExemptionAddTaxAllowYN: option4,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = true;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });

}

//에러 확인
ItsBaroBill.prototype.ShowErrMsg = function () {
    ItsMsg.Alert(this.errMessage);
    console.log(this.errMessage);
};

/************************************************* 세금계산서 *****************************************************/
//공인인증서 날짜 확인
ItsBaroBill.prototype.CheckCertificate = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetCertificateExpireDate.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//공인인증서 등록 URL
ItsBaroBill.prototype.GetCertificateRegistURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetCertificateRegistURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            PWD: this.BDVDATA.TAXPW,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//세금계산서 전송 (정발행)
ItsBaroBill.prototype.SendTax = function () {
    /* 일반 정발행 필수 입력필드
     * DEALTP : 1-영수, 2-청구 (기본 값 : 2)
     * TOTALAMOUNT : 공급가액 총액
     * TOTALTAX : 세액합계
     * TOTALAMT : 합계금액 (공급가액 총액 + 세액 합계)
     * REMARK1 : 비고 1
     * TAXSHTDT : 작성일자 (YYYYMMDD 또는 YYYY-MM-DD, 기본 값 : 오늘)
     * TAXSHTKEY : 계산서 문서 번호 (ITSCO)
     * REGNO : 공급받는자 사업자번호 ('-' 제외, 10자리)
     * PLACENO : 공급받는자 종사업장번호
     * CUSTNM : 공급받는자 회사명
     * PRESIDENT : 공급받는자 대표자명
     * ADDR : 공급받는자 주소
     * INDTYPE : 공급받는자 업종
     * INDCLASS : 공급받는자 업태
     * PRSNNM : 공급받는자 담당자명
     * TEL : 공급받는자 전화번호
     * PHONE : 공급받는자 휴대폰
     * EMAIL : 공급받는자 이메일
     * ITEMQTY : 계산서 품목 수량 (계산서에 보이는 품목 수량)
     * SALESDT : 품목 공급일자 리스트, AddList 사용
     * ITEMNM : 품목명 리스트, AddList 사용
     * ITEMSPEC : 품목 규격, AddList 사용
     * QTY : 품목 수량, AddList 사용
     * COST : 품목 단가, AddList 사용
     * AMOUNT : 품목 공급가액, AddList 사용
     * TAX : 세액, AddList 사용
     * ITEMREMARK : 품목 비고, AddList 사용
     *
     * -------------------------------------------------------------------
     * 선택 입력필드     
     * TAXTP : 1-세금계산서, 2-계산서 (기본 값 : 1)
     * VATTP : 세금계산서(1-과세, 2-영세), 계산서(3-면세) (기본 값 : 1)
     * CALCTP : 세율계산방법 (1-절상, 2-절사, 3-반올림) (기본 값 : 3)
     * REMARK2 : 비고2
     * REMARK3 : 비고3
     * BDVREGNO : 공급자 사업자번호 ('-' 제외, 10자리, 기본 값 : 설정 BDVCD의 사업자번호) 
     * BDVNM : 공급자 회사명 (기본 값 : 설정 BDVCD의 회사명)
     * BDVPRESIDENT : 공급자 대표자명 (기본 값 : 설정 BDVCD의 대표자명)
     * BDVADDR : 공급자 주소 (기본 값 : 설정 BDVCD의 전체 주소)
     * BDVINDTYPE : 공급자 업종 (기본 값 : 설정 BDVCD의 업종)
     * BDVINDCLASS : 공급자 업태 (기본 값 : 설정 BDVCD의 업태)
     * BDVPRSNM : 공급자 담당자명 (기본 값 : 설정 BDVCD의 설정 담당자)
     * BDVTEL : 공급자 전화번호 (기본 값 : 설정 BDVCD의 설정 담당자 전화번호)
     * BDVPHONE : 공급자 휴대폰 (기본 값 : 설정 BDVCD의 설정 계산서 휴대폰)
     * BDVEMAIL : 공급자 이메일 (기본 값 : 설정 BDVCD의 설정 계산서 이메일)
     */

    // 공급받는자 담당자 없을 경우 대표자로 처리 (2022-08-31 왕현준)
    if (this.GetParam('PRSNNM') == '') {
        this.AddParam('PRSNNM', this.GetParam('PRESIDENT'));
    }

    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/RegistTaxInvoice.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            IssueDirection: 1,                                              // 1-정발행, 2-역발행(위수탁 세금계산서는 정발행만 허용)
            TaxInvoiceType : this.GetParam('TAXTP', 1),                     // 1-세금계산서, 2-계산서
            TaxType: this.GetParam('VATTP', 1),                             // 세금계산서(1-과세, 2-영세), 계산서(3-면세)
            TaxCalcType: this.GetParam('CALCTP', 3),                        // 세율계산방법 (1-절상, 2-절사, 3-반올림)
            PurposeType: this.GetParam('DEALTP', 2),                        // 1-영수, 2-청구
            AmountTotal: this.GetParam('TOTALAMOUNT', 0),                   // 공급가액 총액
            TaxTotal: this.GetParam('TOTALTAX', 0),                         // 세액합계 (taxInvoice.TaxType 이 2 또는 3 으로 셋팅된 경우 0으로 입력)
            TotalAmount: this.GetParam('TOTALAMT', 0),                      // 합계금액
            Remark1: this.GetParam('REMARK1'),                              // 비고1
            Remark2: this.GetParam('REMARK2'),                              // 비고2
            Remark3: this.GetParam('REMARK3'),                              // 비고3
            WriteDate: this.GetParam('TAXSHTDT'),                           // 작성일자 (YYYYMMDD, YYYY-MM-DD도 괜찮) (공백입력 시 Today로 작성됨)
            MgtNum: this.GetParam('TAXSHTKEY'),                             // 연동사부여 문서키 (역발행때는 빈칸)
            CorpNum: this.GetParam('BDVREGNO', this.BDVDATA.REGNO),         // 공급자 사업자번호 ('-' 제외, 10자리) 
            TaxRegID: this.GetParam('BDVPLACENO'),                          // 공급자 종사업장번호
            CorpName: this.GetParam('BDVNM', this.BDVDATA.BDVNMFULL),       // 공급자 회사명
            CEOName: this.GetParam('BDVPRESIDENT', this.BDVDATA.PRESIDENT), // 공급자 대표자명
            Addr: this.GetParam('BDVADDR', this.BDVDATA.ADDRESSFULL),       // 공급자 주소
            BizType: this.GetParam('BDVINDTYPE', this.BDVDATA.INDTYPE),     // 공급자 업종
            BizClass: this.GetParam('BDVINDCLASS', this.BDVDATA.INDCLASS),  // 공급자 업태
            ContactID: this.GetParam('TAXID', this.BDVDATA.TAXID),          // 바로빌 회원 아이디 (역발행때는 빈칸)
            ContactName: this.GetParam('BDVPRSNM', this.BDVDATA.PRSNNM),    // 공급자 담당자명
            TEL: this.GetParam('BDVTEL', this.BDVDATA.PRSNTELNO),           // 공급자 전화번호
            HP: this.GetParam('BDVPHONE', this.BDVDATA.PRSNPHONE),          // 공급자 휴대폰
            Email: this.GetParam('BDVEMAIL', this.BDVDATA.PRSNEMAIL),       // 공급자 이메일
            ReMgtNum: '',                                                   // 역발행 연동사부여 문서키 (정발행때는 빈칸)
            CorpNum_e: this.GetParam('REGNO'),                              // 공급받는자 사업자번호 ('-' 제외, 10자리)
            TaxRegID_e: this.GetParam('PLACENO'),                           // 공급받는자 종사업장번호
            CorpName_e: this.GetParam('CUSTNM'),                            // 공급받는자 회사명
            CEOName_e: this.GetParam('PRESIDENT'),                          // 공급받는자 대표자명
            Addr_e: this.GetParam('ADDR'),                                  // 공급받는자 주소
            BizType_e: this.GetParam('INDTYPE'),                            // 공급받는자 업종
            BizClass_e: this.GetParam('INDCLASS'),                          // 공급받는자 업태
            ReContactID: '',                                                // 역발행 바로빌 회원 아이디 (정발행때는 빈칸)         
            ContactName_e: this.GetParam('PRSNNM'),                         // 공급받는자 담당자명
            TEL_e: this.GetParam('TEL'),                                    // 공급받는자 전화번호
            HP_e: this.GetParam('PHONE'),                                   // 공급받는자 휴대폰
            Email_e: this.GetParam('EMAIL'),                                // 공급받는자 이메일
            itemQty: this.GetParam('ITEMQTY', 0),                           // 품목 수량
            PurchaseExpiry: this.GetParam('SALESDT'),                       // 품목 공급일자 리스트, 구분자 : ▥
            Name: this.GetParam('ITEMNM'),                                  // 품목명 리스트, 구분자 : ▥
            Information: this.GetParam('ITEMSPEC'),                         // 품목 규격, 구분자 : ▥
            ChargeableUnit: this.GetParam('QTY', 0),                        // 품목 수량, 구분자 : ▥
            UnitPrice: this.GetParam('COST', 0),                            // 품목 단가, 구분자 : ▥
            Amount: this.GetParam('AMOUNT', 0),                             // 품목 공급가액, 구분자 : ▥
            Tax: this.GetParam('TAX', 0),                                   // 세액, 구분자 : ▥
            Description: this.GetParam('ITEMREMARK'),                       // 품목 비고, 구분자 : ▥
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = true;

                //임시 계산서 생성 완료

                $.ajax({
                    async: false,
                    barobill: this.barobill,
                    url: '../../Service/Barobill/IssueTaxInvoice.aspx?',
                    type: 'post',
                    dataType: 'text',
                    data: {
                        CorpNum: this.barobill.GetParam('BDVREGNO', this.barobill.BDVDATA.REGNO),
                        MgtKey: this.barobill.GetParam('TAXSHTKEY'),
                        MailTitle: this.barobill.GetParam('MailTitle'),
                    },
                    success: function (data, staus) {
                        if (data.substring(0, 6) == 'ERROR:') {
                            this.barobill.isError = true;
                            this.barobill.errMessage = data;
                            this.barobill.value = '';
                        }
                        else {
                            this.barobill.isError = false;
                            this.barobill.errMessage = '';
                            this.barobill.value = data;
                        }
                    },
                    error: function (xhr, status, error) {
                        this.barobill.isError = true;
                        this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
                        this.barobill.value = '';
                    }
                });
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//수정 세금계산서 전송 (정발행)
ItsBaroBill.prototype.ModifySendTax = function () {
    /* 수정 세금계산서 정발행 필수 입력필드
     * MODIFYTP : 수정사유코드 (1-기재사항의 착오 정정, 2-공급가액의 변동, 3-재화의 환입, 4-계약의 해제, 5-내국신용장 사후개설, 6-착오에 의한 이중발행)
     * ORGSENDKEY : 당초 세금계산서의 국세청 승인번호 (바로빌을 통해 발행된 세금계산서만 가능합니다.)
     * DEALTP : 1-영수, 2-청구 (기본 값 : 2)
     * TOTALAMOUNT : 공급가액 총액
     * TOTALTAX : 세액합계
     * TOTALAMT : 합계금액 (공급가액 총액 + 세액 합계)
     * REMARK1 : 비고 1
     * TAXSHTDT : 작성일자 (YYYYMMDD 또는 YYYY-MM-DD, 기본 값 : 오늘)
     * TAXSHTKEY : 계산서 문서 번호 (ITSCO)
     * REGNO : 공급받는자 사업자번호 ('-' 제외, 10자리)
     * PLACENO : 공급받는자 종사업장번호
     * CUSTNM : 공급받는자 회사명
     * PRESIDENT : 공급받는자 대표자명
     * ADDR : 공급받는자 주소
     * INDTYPE : 공급받는자 업종
     * INDCLASS : 공급받는자 업태
     * PRSNNM : 공급받는자 담당자명
     * TEL : 공급받는자 전화번호
     * PHONE : 공급받는자 휴대폰
     * EMAIL : 공급받는자 이메일
     * ITEMQTY : 계산서 품목 수량 (계산서에 보이는 품목 수량)
     * SALESDT : 품목 공급일자 리스트, AddList 사용
     * ITEMNM : 품목명 리스트, AddList 사용
     * ITEMSPEC : 품목 규격, AddList 사용
     * QTY : 품목 수량, AddList 사용
     * COST : 품목 단가, AddList 사용
     * AMOUNT : 품목 공급가액, AddList 사용
     * TAX : 세액, AddList 사용
     * ITEMREMARK : 품목 비고, AddList 사용
     *
     * -------------------------------------------------------------------
     * 선택 입력필드     
     * TAXTP : 1-세금계산서, 2-계산서 (기본 값 : 1)
     * VATTP : 세금계산서(1-과세, 2-영세), 계산서(3-면세) (기본 값 : 1)
     * CALCTP : 세율계산방법 (1-절상, 2-절사, 3-반올림) (기본 값 : 3)
     * REMARK2 : 비고2
     * REMARK3 : 비고3
     * BDVREGNO : 공급자 사업자번호 ('-' 제외, 10자리, 기본 값 : 설정 BDVCD의 사업자번호) 
     * BDVNM : 공급자 회사명 (기본 값 : 설정 BDVCD의 회사명)
     * BDVPRESIDENT : 공급자 대표자명 (기본 값 : 설정 BDVCD의 대표자명)
     * BDVADDR : 공급자 주소 (기본 값 : 설정 BDVCD의 전체 주소)
     * BDVINDTYPE : 공급자 업종 (기본 값 : 설정 BDVCD의 업종)
     * BDVINDCLASS : 공급자 업태 (기본 값 : 설정 BDVCD의 업태)
     * BDVPRSNM : 공급자 담당자명 (기본 값 : 설정 BDVCD의 설정 담당자)
     * BDVTEL : 공급자 전화번호 (기본 값 : 설정 BDVCD의 설정 담당자 전화번호)
     * BDVPHONE : 공급자 휴대폰 (기본 값 : 설정 BDVCD의 설정 계산서 휴대폰)
     * BDVEMAIL : 공급자 이메일 (기본 값 : 설정 BDVCD의 설정 계산서 이메일)
     */

    // 공급받는자 담당자 없을 경우 대표자로 처리 (2022-08-31 왕현준)
    if (this.GetParam('PRSNNM') == '') {
        this.AddParam('PRSNNM', this.GetParam('PRESIDENT'));
    }

    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/RegistModifyTaxInvoice.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            ModifyCode: this.GetParam('MODIFYTP'),                          //수정사유코드 (1-기재사항의 착오 정정, 2-공급가액의 변동, 3-재화의 환입, 4-계약의 해제, 5-내국신용장 사후개설, 6-착오에 의한 이중발행)
            OriginalNTSSendKey: this.GetParam('ORGSENDKEY'),                //당초 세금계산서의 국세청 승인번호 (바로빌을 통해 발행된 세금계산서만 가능합니다.)
            IssueDirection: 1,                                              // 1-정발행, 2-역발행(위수탁 세금계산서는 정발행만 허용)
            TaxInvoiceType: this.GetParam('TAXTP', 1),                      // 1-세금계산서, 2-계산서
            TaxType: this.GetParam('VATTP', 1),                             // 세금계산서(1-과세, 2-영세), 계산서(3-면세)
            TaxCalcType: this.GetParam('CALCTP', 3),                        // 세율계산방법 (1-절상, 2-절사, 3-반올림)
            PurposeType: this.GetParam('DEALTP', 2),                        // 1-영수, 2-청구
            AmountTotal: this.GetParam('TOTALAMOUNT', 0),                   // 공급가액 총액
            TaxTotal: this.GetParam('TOTALTAX', 0),                         // 세액합계 (taxInvoice.TaxType 이 2 또는 3 으로 셋팅된 경우 0으로 입력)
            TotalAmount: this.GetParam('TOTALAMT', 0),                      // 합계금액
            Remark1: this.GetParam('REMARK1'),                              // 비고1
            Remark2: this.GetParam('REMARK2'),                              // 비고2
            Remark3: this.GetParam('REMARK3'),                              // 비고3
            WriteDate: this.GetParam('TAXSHTDT'),                           // 작성일자 (YYYYMMDD, YYYY-MM-DD도 괜찮) (공백입력 시 Today로 작성됨)
            MgtNum: this.GetParam('TAXSHTKEY'),                             // 연동사부여 문서키 (역발행때는 빈칸)
            CorpNum: this.GetParam('BDVREGNO', this.BDVDATA.REGNO),         // 공급자 사업자번호 ('-' 제외, 10자리) 
            TaxRegID: this.GetParam('BDVPLACENO'),                          // 공급자 종사업장번호
            CorpName: this.GetParam('BDVNM', this.BDVDATA.BDVNMFULL),       // 공급자 회사명
            CEOName: this.GetParam('BDVPRESIDENT', this.BDVDATA.PRESIDENT), // 공급자 대표자명
            Addr: this.GetParam('BDVADDR', this.BDVDATA.ADDRESSFULL),       // 공급자 주소
            BizType: this.GetParam('BDVINDTYPE', this.BDVDATA.INDTYPE),     // 공급자 업종
            BizClass: this.GetParam('BDVINDCLASS', this.BDVDATA.INDCLASS),  // 공급자 업태
            ContactID: this.GetParam('TAXID', this.BDVDATA.TAXID),          // 바로빌 회원 아이디 (역발행때는 빈칸)
            ContactName: this.GetParam('BDVPRSNM', this.BDVDATA.PRSNNM),    // 공급자 담당자명
            TEL: this.GetParam('BDVTEL', this.BDVDATA.PRSNTELNO),           // 공급자 전화번호
            HP: this.GetParam('BDVPHONE', this.BDVDATA.PRSNPHONE),          // 공급자 휴대폰
            Email: this.GetParam('BDVEMAIL', this.BDVDATA.PRSNEMAIL),       // 공급자 이메일
            ReMgtNum: '',                                                   // 역발행 연동사부여 문서키 (정발행때는 빈칸)
            CorpNum_e: this.GetParam('REGNO'),                              // 공급받는자 사업자번호 ('-' 제외, 10자리)
            TaxRegID_e: this.GetParam('PLACENO'),                           // 공급받는자 종사업장번호
            CorpName_e: this.GetParam('CUSTNM'),                            // 공급받는자 회사명
            CEOName_e: this.GetParam('PRESIDENT'),                          // 공급받는자 대표자명
            Addr_e: this.GetParam('ADDR'),                                  // 공급받는자 주소
            BizType_e: this.GetParam('INDTYPE'),                            // 공급받는자 업종
            BizClass_e: this.GetParam('INDCLASS'),                          // 공급받는자 업태
            ReContactID: '',                                                // 역발행 바로빌 회원 아이디 (정발행때는 빈칸)         
            ContactName_e: this.GetParam('PRSNNM'),                         // 공급받는자 담당자명
            TEL_e: this.GetParam('TEL'),                                    // 공급받는자 전화번호
            HP_e: this.GetParam('PHONE'),                                   // 공급받는자 휴대폰
            Email_e: this.GetParam('EMAIL'),                                // 공급받는자 이메일
            itemQty: this.GetParam('ITEMQTY', 0),                           // 품목 수량
            PurchaseExpiry: this.GetParam('SALESDT'),                       // 품목 공급일자 리스트, 구분자 : ▥
            Name: this.GetParam('ITEMNM'),                                  // 품목명 리스트, 구분자 : ▥
            Information: this.GetParam('ITEMSPEC'),                         // 품목 규격, 구분자 : ▥
            ChargeableUnit: this.GetParam('QTY', 0),                        // 품목 수량, 구분자 : ▥
            UnitPrice: this.GetParam('COST', 0),                            // 품목 단가, 구분자 : ▥
            Amount: this.GetParam('AMOUNT', 0),                             // 품목 공급가액, 구분자 : ▥
            Tax: this.GetParam('TAX', 0),                                   // 세액, 구분자 : ▥
            Description: this.GetParam('ITEMREMARK'),                       // 품목 비고, 구분자 : ▥
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = true;

                //임시 계산서 생성 완료

                $.ajax({
                    async: false,
                    barobill: this.barobill,
                    url: '../../Service/Barobill/IssueTaxInvoice.aspx?',
                    type: 'post',
                    dataType: 'text',
                    data: {
                        CorpNum: this.barobill.GetParam('BDVREGNO', this.barobill.BDVDATA.REGNO),
                        MgtKey: this.barobill.GetParam('TAXSHTKEY'),
                        MailTitle: this.barobill.GetParam('MailTitle'),
                    },
                    success: function (data, staus) {
                        if (data.substring(0, 6) == 'ERROR:') {
                            this.barobill.isError = true;
                            this.barobill.errMessage = data;
                            this.barobill.value = '';
                        }
                        else {
                            this.barobill.isError = false;
                            this.barobill.errMessage = '';
                            this.barobill.value = data;
                        }
                    },
                    error: function (xhr, status, error) {
                        this.barobill.isError = true;
                        this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
                        this.barobill.value = '';
                    }
                });
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

/* 세금계산서 상태 확인
 * Multi => false(단일), true(다중)
 * => false : AddParam('MgtKey', 값)
 * => true : AddList('MgtKey', 값)
 * AddParam('BDVREGNO', 값) 없으면 기존 BDVCD의 사업자번호
 */
ItsBaroBill.prototype.GetTaxState = function (Multi) {
    var link = 'GetTaxInvoiceStateEX.aspx?';
    if (Multi == undefined) {
        Multi = false;
    }
    if (Multi) {
        var link = 'GetTaxInvoiceStatesEX.aspx?';
    }
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/' + link,
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.GetParam('BDVREGNO', this.BDVDATA.REGNO),     // 공급자 사업자번호 ('-' 제외, 10자리) 
            MgtKey: this.GetParam('MgtKey'),                            // 연동사부여 문서키 배열 (최대, 100건 까지)
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                if (data.indexOf('▥') > -1) {
                    var datalist = data.split('▥');
                    var value = '[';
                    for(var i =0; i<datalist.length; i++){
                        var jsondata = datalist[i].replace('[', '').replace(']', '');
                        if (jsondata != '') {
                            if (i > 0) {
                                value += (',' + jsondata);
                            }
                            else {
                                value += jsondata;
                            }
                        }
                    }
                    value += ']';
                    try{
                        this.barobill.value = JSON.parse(value);
                    }
                    catch (ex) {
                        this.barobill.value = value;
                    }
                }
                else {
                    try {
                        this.barobill.value = JSON.parse(data);
                    }
                    catch (ex) {
                        this.barobill.value = data;
                    }
                }
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//세금계산서 삭제
ItsBaroBill.prototype.DeleteTax = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/DeleteTaxInvoice.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.GetParam('BDVREGNO', this.BDVDATA.REGNO),     // 공급자 사업자번호 ('-' 제외, 10자리) 
            MgtKey: this.GetParam('MgtKey'),
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//세금계산서 삭제(발행후)
ItsBaroBill.prototype.CancelTax = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/ProcTaxInvoice.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.GetParam('BDVREGNO', this.BDVDATA.REGNO),     // 공급자 사업자번호 ('-' 제외, 10자리) 
            MgtKey: this.GetParam('MgtKey'),
            ProcType: this.GetParam('ProcType', 'ISSUE_CANCEL'),        // 발행완료후 : ISSUE_CANCEL, 발행예정시 : CANCEL (실제로 이건 쓸일 없음)
            Memo: this.GetParam('Memo'),
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                //발행 정상 취소시 삭제
                $.ajax({
                    async: false,
                    barobill: this.barobill,
                    url: '../../Service/Barobill/DeleteTaxInvoice.aspx?',
                    type: 'post',
                    dataType: 'text',
                    data: {
                        CorpNum: this.barobill.GetParam('BDVREGNO', this.barobill.BDVDATA.REGNO),     // 공급자 사업자번호 ('-' 제외, 10자리) 
                        MgtKey: this.barobill.GetParam('MgtKey'),
                    },
                    success: function (data, staus) {
                        if (data.substring(0, 6) == 'ERROR:') {
                            this.barobill.isError = true;
                            this.barobill.errMessage = data;
                            this.barobill.value = '';
                        }
                        else {
                            this.barobill.isError = false;
                            this.barobill.errMessage = '';
                            this.barobill.value = data;
                        }
                    },
                    error: function (xhr, status, error) {
                        this.barobill.isError = true;
                        this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
                        this.barobill.value = '';
                    }
                });
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//세금계산서 메일 재전송
ItsBaroBill.prototype.ReSendEmail = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/ReSendEmail.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.GetParam('BDVREGNO', this.BDVDATA.REGNO),     // 공급자 사업자번호 ('-' 제외, 10자리) 
            MgtKey: this.GetParam('MgtKey'),                            // 연동사부여 문서키 배열 (최대, 100건 까지)
            ToEmailAddress: this.GetParam('EMAIL'),                     // 수신자 메일 주소
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

/*************************************************** 국세청 ******************************************************/
//홈텍스 (세금)계산서 연동 서비스를 신청할 수 있는 URL
ItsBaroBill.prototype.GetTaxScrapRequestURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetTaxInvoiceScrapRequestURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            PWD: this.BDVDATA.TAXPW,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//홈텍스 (세금)계산서를 1일분씩 조회합니다.
ItsBaroBill.prototype.GetDailyTaxList = function () {
    
    /* 홈텍스 (세금)계산서를 1일분씩 조회합니다.
     * GETTP : 조회 타입 SAL:매출 PUR:매입
     * DATETP : 조회기준, 1:작성일자 2:발행일자
     * DATE : 기준날짜
     * PAGECOUNT : 한 페이지 당 조회 건 수
     * PAGE : 조회할 페이지 번호
     */
    var link = "GetDailyTaxInvoiceSalesList.aspx?";
    if (this.GetParam('GETTP', 'SAL') == 'PUR') {
        link = "GetDailyTaxInvoicePurchaseList.aspx?";
    }
    
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/' + link,
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            DateType: this.GetParam('DATETP'),
            BaseDate: this.GetParam('DATE'),
            CountPerPage: this.GetParam('PAGECOUNT',10),
            CurrentPage: this.GetParam('PAGE',1)
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = JSON.parse(data);
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//홈텍스 (세금)계산서를 1개월분씩 조회합니다.
ItsBaroBill.prototype.GetMonthlyTaxList = function () {

    /* 홈텍스 (세금)계산서를 1개월분씩 조회합니다.
     * GETTP : 조회 타입 SAL:매출 PUR:매입
     * DATETP : 조회기준, 1:작성일자 2:발행일자
     * MONTH : 조회기준월 yyyyMM 또는 yyyy-MM 형태
     * PAGECOUNT : 한 페이지 당 조회 건 수
     * PAGE : 조회할 페이지 번호
     * SORT : 정렬방향 1:ASC 2:DESC
     */
    var link = "GetMonthlyTaxInvoiceSalesList.aspx?";
    if (this.GetParam('GETTP', 'SAL') == 'PUR') {
        link = "GetMonthlyTaxInvoicePurchaseList.aspx?";
    }

    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/' + link,
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            DateType: this.GetParam('DATETP'),
            BaseMonth: this.GetParam('MONTH'),
            CountPerPage: this.GetParam('PAGECOUNT', 10),
            CurrentPage: this.GetParam('PAGE', 1),
            OrderDirection: this.GetParam('SORT', 1)
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = JSON.parse(data);
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

/**************************************************** 계좌 *******************************************************/
//등록한 계좌정보를 조회 (현재 사용중인 계좌만 조회)
ItsBaroBill.prototype.GetBankAccount = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetBankAccountEx.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            AvailOnly: 1
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = JSON.parse(data);
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//계좌 입출금내역을 1일분씩 조회
ItsBaroBill.prototype.GetBankLogDay = function () {
    
    /* 계좌 입출금내역을 1일분씩 조회
     * BANKACCOUNT : 계좌번호
     * DATE : 조회기준일자 yyyyMMdd 또는 yyyy-MM-dd 형태
     * PAGECOUNT : 한 페이지 당 조회 건 수
     * PAGE : 조회할 페이지 번호
     * SORT : 정렬방향 1:ASC 2:DESC
     */
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetDailyBankAccountLogEx.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            BankAccountNum: this.GetParam('BANKACCOUNT'),
            BaseDate: this.GetParam('DATE'),
            CountPerPage: this.GetParam('PAGECOUNT', 10),
            CurrentPage: this.GetParam('PAGE', 1),
            OrderDirection: this.GetParam('SORT', 1)
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = JSON.parse(data);
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//계좌 입출금내역을 1개월분씩 조회
ItsBaroBill.prototype.GetBankLogMonth = function () {

    /* 계좌 입출금내역을 1개월분씩 조회
     * BANKACCOUNT : 계좌번호
     * MONTH : 조회기준월 yyyyMM 또는 yyyy-MM 형태
     * PAGECOUNT : 한 페이지 당 조회 건 수
     * PAGE : 조회할 페이지 번호
     * SORT : 정렬방향 1:ASC 2:DESC
     */
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetMonthlyBankAccountLogEx.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            BankAccountNum: this.GetParam('BANKACCOUNT'),
            BaseMonth: this.GetParam('MONTH'),
            CountPerPage: this.GetParam('PAGECOUNT', 10),
            CurrentPage: this.GetParam('PAGE', 1),
            OrderDirection: this.GetParam('SORT', 1)
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = JSON.parse(data);
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//계좌 조회 서비스를 신청할 수 있는 URL
ItsBaroBill.prototype.GetBankScrapRequestURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetBankAccountScrapRequestURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            PWD: this.BDVDATA.TAXPW,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//계좌정보를 관리할 수 있는 URL
ItsBaroBill.prototype.GetBankManagementURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetBankAccountManagementURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            PWD: this.BDVDATA.TAXPW,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//계좌 입출금내역을 조회할 수 있는 URL
ItsBaroBill.prototype.GetBankLogURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetBankAccountLogURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            PWD: this.BDVDATA.TAXPW,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

/**************************************************** 카드 *******************************************************/
//등록한 카드정보를 조회
ItsBaroBill.prototype.GetCard = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetCard.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = JSON.parse(data);
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//카드 사용내역을 1일분씩 조회
ItsBaroBill.prototype.GetCardLogDay = function () {

    /* 카드 사용내역을 1일분씩 조회
     * CARDNUM : 카드번호
     * DATE : 조회기준일자 yyyyMMdd 또는 yyyy-MM-dd 형태
     * PAGECOUNT : 한 페이지 당 조회 건 수
     * PAGE : 조회할 페이지 번호
     * SORT : 정렬방향 1:ASC 2:DESC
     */
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetDailyCardLogEx.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            CardNum: this.GetParam('CARDNUM'),
            BaseDate: this.GetParam('DATE'),
            CountPerPage: this.GetParam('PAGECOUNT', 10),
            CurrentPage: this.GetParam('PAGE', 1),
            OrderDirection: this.GetParam('SORT', 1)
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = JSON.parse(data);
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//카드 사용내역을 1개월분씩 조회
ItsBaroBill.prototype.GetCardLogMonth = function () {

    /* 카드 사용내역을 1개월분씩 조회
     * CARDNUM : 카드번호
     * MONTH : 조회기준월 yyyyMM 또는 yyyy-MM 형태
     * PAGECOUNT : 한 페이지 당 조회 건 수
     * PAGE : 조회할 페이지 번호
     * SORT : 정렬방향 1:ASC 2:DESC
     */
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetMonthlyCardLogEx.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            CardNum: this.GetParam('CARDNUM'),
            BaseMonth: this.GetParam('MONTH'),
            CountPerPage: this.GetParam('PAGECOUNT', 10),
            CurrentPage: this.GetParam('PAGE', 1),
            OrderDirection: this.GetParam('SORT', 1)
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = JSON.parse(data);
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//카드 조회 서비스를 신청할 수 있는 URL
ItsBaroBill.prototype.GetCardScrapRequestURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetCardScrapRequestURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            PWD: this.BDVDATA.TAXPW,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//카드정보를 관리할 수 있는 URL
ItsBaroBill.prototype.GetCardManagementURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetCardManagementURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            PWD: this.BDVDATA.TAXPW,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

//카드 사용내역을 조회할 수 있는 URL
ItsBaroBill.prototype.GetCardLogURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetCardLogURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            ID: this.BDVDATA.TAXID,
            PWD: this.BDVDATA.TAXPW,
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}
// 발급완료의 계산서를 국세청 즉시전송

ItsBaroBill.prototype.SendToNTS = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/SendToNTS.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            MgtKey: this.GetParam('MgtKey'),
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}
ItsBaroBill.prototype.GetTaxInvoicePrintURL = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/GetTaxInvoicePrintURL.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            BTAXID: this.BDVDATA.TAXID,
            MgtKey: this.GetParam('MgtKey'),
        },
        success: function (data, staus) {
            window.open(data, '계산서출력', 'width=900, height=800');
            this.barobill.value = data;
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}
ItsBaroBill.prototype.SendInvoiceFax = function () {
    $.ajax({
        async: false,
        barobill: this,
        url: '../../Service/Barobill/SendInvoiceFax.aspx?',
        type: 'post',
        dataType: 'text',
        data: {
            CorpNum: this.BDVDATA.REGNO,
            MgtKey: this.GetParam('MgtKey'),
            FromFaxNumber: this.GetParam('FromFaxNumber'),
            toFaxNumber: this.GetParam('toFaxNumber')
        },
        success: function (data, staus) {
            if (data.substring(0, 6) == 'ERROR:') {
                this.barobill.isError = true;
                this.barobill.errMessage = data;
                this.barobill.value = '';
            }
            else {
                this.barobill.isError = false;
                this.barobill.errMessage = '';
                this.barobill.value = data;
            }
        },
        error: function (xhr, status, error) {
            this.barobill.isError = true;
            this.barobill.errMessage = 'ERROR: .aspx 접속 에러';
            this.barobill.value = '';
        }
    });
}

/****************************************************************************************************************/

//ItsMaria.prototype._$json = function (resText) {
//    var $model = null;
//    while (resText.trim() != '') {
//        var $index = resText.indexOf('▥');
//        if ($index > -1) {
//            var $jsonText = resText.substring(0, $index);
//            this._$store($jsonText);
//            resText = resText.substring($index + 1);
//        } else {
//            this._$store(resText);
//            resText = '';
//        }
//    };
//};

/* barobill 등록 중 에러 발생시*/
ItsBaroBill.prototype._$billError = function (TAXSHTKEY, TAXSTATE) {
    if (TAXSTATE == undefined || TAXSTATE == null) TAXSTATE = '';
    var maria = new ItsMaria('BAROBILL_SERVICE', 'ERR_SALTAX');
    maria.AddParam('TAXSHTKEY', TAXSHTKEY);
    maria.AddParam('TAXSTATE', TAXSTATE);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
}

/* barobill 등록 중 에러 발생시*/
ItsBaroBill.prototype._$billDelete = function (TAXSHTKEY) {
    var maria = new ItsMaria('BAROBILL_SERVICE', 'DEL_SALTAX');
    maria.AddParam('TAXSHTKEY', TAXSHTKEY);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
}



