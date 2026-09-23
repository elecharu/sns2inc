//사업장정보
/// <reference path="../../Script/reference.js" />
var dbFileKey = "";

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    $('#keyTaxFile').find('.upload-btn').css('display', 'none');
    $('#derTaxFile').find('.upload-btn').css('display', 'none');
    $('#pop_keyTaxFile').find('.upload-btn').css('display', 'none');
    $('#pop_derTaxFile').find('.upload-btn').css('display', 'none');

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("사업장코드", "BDVCD", { width: 120 }),
        column.create("사업장명", "BDVNM", { width: 120 }),
        column.create("사업장 정식명", "BDVNMFULL", { width: 120 }),
        column.create("전화번호", "TELNO", { width: 120 }),
        column.create("관리자 성명", "PRSNNM", { width: 120 }),
        column.create("관리자 전화번호", "PRSNTELNO", { width: 120 }),
        column.create("관리자 휴대폰", "PRSNPHONE", { width: 120 }),
        column.create("관리자 이메일", "PRSNEMAIL", { width: 120 }),
        column.create("주소", "ADDRESSFULL", { width: 500 }),
        column.split(1)
    ]);
    ItsButton.EventSearch();

};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R01 ', 'LIST_BDV');     // Maria 인스턴스 생성
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsPage.SetStore('div1', ItsGrid.GetRowData('grid1', rowIndex));

    dbFileKey = ItsGrid.GetValue('grid1', rowIndex, 'MARKIMAGE');
    ItsImage.SetImage('img_MARK', ItsGrid.GetValue('grid1', rowIndex, 'MARKIMAGEURL'));

}

/* 저장 버튼 */
ItsButton.EventSave = function () {
    var fileKey = ItsFileManager.GetFileKey('file_MARKIMAGE');

    if (fileKey == '' && dbFileKey != '' && dbFileKey != undefined) {                // db에는 파일이 있으나 clear 되어있다면 삭제
        ItsFileManager.Delete('file_MARKIMAGE');
    } else if (ItsFileManager.IsFileChanged('file_MARKIMAGE')) { // 파일이 바뀐 흔적이 있다면 파일 업로드
        ItsFileManager.Upload('file_MARKIMAGE');
    } else {                                               // 이쪽으로 탔을때는 파일 처리할 일이 없을듯? 바로 다른필드 수정만
        _saveBDV(dbFileKey);
    }

};

// 이미지 업로드, 삭제 후에 키를 받아온 것으로 처리
ItsFileManager.Event('file_MARKIMAGE').onUpload = function (id, fileKey) {
    _saveBDV(fileKey);
};
ItsFileManager.Event('file_MARKIMAGE').onDelete = function (id, fileKey) {
    _saveBDV(fileKey);
};

function _saveBDV(filekey) {
    var maria = new ItsMaria('MST0001_R01 ', 'UP_BDV');
    maria.AddPanel('ddiv1');
    maria.AddParam('MARKIMAGE', filekey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.Setkey('grid1', 'BDVCD', ItsText.GetValue('txt_BDVCD'));
    ItsMsg.Toast('저장되었습니다.');
    ItsButton.EventSearch();
}

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
};

ItsPop.Event('pop1').onAddBtnClick = function () {
    if (ItsFileManager.IsFileChanged('pop_file_MARKIMAGE')) {
        ItsFileManager.Upload('pop_file_MARKIMAGE');
    } else {
        addEqm('');
    }
}

ItsFileManager.Event('pop_file_MARKIMAGE').onUpload = function (id, fileKey) {
    addEqm(fileKey);
};

function addEqm(filekey) {
    var maria = new ItsMaria('MST0001_R01', 'ADD_BDV');
    maria.AddPanel('pdiv1');
    maria.AddParam('MARKIMAGE', filekey);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsPop.Close('pop1');
    ItsButton.EventSearch();
}

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
}
/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('삭제하시겠습니까?', function () {
        var maria = new ItsMaria('MST0001_R01', 'DEL_BDV');
        maria.AddParam('BDVCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'BDVCD'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.EventSearch();
        ItsMsg.Toast("삭제되었습니다.");
    });
};

/* 그리드 행 선택 - grid1 */
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsPage.SetStore('ddiv1', ItsGrid.GetRowData('grid1', rowIndex));
    ItsPage.SetStore('ddiv2', ItsGrid.GetRowData('grid1', rowIndex));
};

/* kakao 우편번호 검색 */
ItsButton.Event('SEARCH_ZIP').onClick = function () {
    // -----------------------------------------------------------------------------------
    var width = 500; //팝업의 너비
    var height = 600; //팝업의 높이
    new kakao.Postcode({
        width: width,
        height: height,
        popupName: 'postcode',
        oncomplete: function (data) {
            /* ---- 수정 가능 ----------------------------------------------------------------- */
            ItsText.SetValue('txt_ZIPCD', data.zonecode);
            ItsText.SetValue('txt_ADDRESS', data.roadAddress);
            ItsText.SetValue('txt_ADDRESSDETAIL', ' (' + data.buildingName + ') ');
            ItsText.SetValue('txt_ADDRESSOTHER', '');
            ItsText.SetValue('txt_ADDRESSFULL', data.roadAddress + ' (' + data.buildingName + ') ');
            // ---- 수정 가능 ----------------------------------------------------------------- //
        }
    }).open({ // 가운데 정렬 (듀얼 디스플레이에선 위치 안맞을수 있음)
        left: (window.screen.width / 2) - (width / 2),
        top: (window.screen.height / 2) - (height / 2)
    });
};
/* kakao 우편번호 검색 */
ItsButton.Event('pop_SEARCH_ZIP').onClick = function () {
    // -----------------------------------------------------------------------------------
    var width = 500; //팝업의 너비
    var height = 600; //팝업의 높이
    new kakao.Postcode({
        width: width,
        height: height,
        popupName: 'postcode',
        oncomplete: function (data) {
            /* ---- 수정 가능 ----------------------------------------------------------------- */
            ItsText.SetValue('pop_txt_ZIPCD', data.zonecode);
            ItsText.SetValue('pop_txt_ADDRESS', data.roadAddress);
            ItsText.SetValue('pop_txt_ADDRESSDETAIL', ' (' + data.buildingName + ') ');
            ItsText.SetValue('pop_txt_ADDRESSOTHER', '');
            ItsText.SetValue('pop_txt_ADDRESSFULL', data.roadAddress + ' (' + data.buildingName + ') ');
            // ---- 수정 가능 ----------------------------------------------------------------- //
        }
    }).open({ // 가운데 정렬 (듀얼 디스플레이에선 위치 안맞을수 있음)
        left: (window.screen.width / 2) - (width / 2),
        top: (window.screen.height / 2) - (height / 2)
    });
};

/* 상세 주소 변경 시 전체 주소도 변경된다. */
ItsText.Event('txt_ADDRESSOTHER').onChanged = function (value, oldValue) {
    ItsText.SetValue('txt_ADDRESSFULL', ItsText.GetValue('txt_ADDRESS') + ' ' + value + ' ' + ItsText.GetValue('txt_ADDRESSDETAIL'));
};

/* 건물명 변경 시 전체 주소도 변경된다. */
ItsText.Event('txt_ADDRESSDETAIL').onChanged = function (value, oldValue) {
    ItsText.SetValue('txt_ADDRESSFULL', ItsText.GetValue('txt_ADDRESS') + ' ' + ItsText.GetValue('txt_ADDRESSOTHER') + ' ' + value);
};

/* 상세 주소 변경 시 전체 주소도 변경된다. */
ItsText.Event('pop_txt_ADDRESSOTHER').onChanged = function (value, oldValue) {
    ItsText.SetValue('pop_txt_ADDRESSFULL', ItsText.GetValue('pop_txt_ADDRESS') + ' ' + value + ' ' + ItsText.GetValue('pop_txt_ADDRESSDETAIL'));
};

/* 건물명 변경 시 전체 주소도 변경된다. */
ItsText.Event('pop_txt_ADDRESSDETAIL').onChanged = function (value, oldValue) {
    ItsText.SetValue('pop_txt_ADDRESSFULL', ItsText.GetValue('pop_txt_ADDRESS') + ' ' + ItsText.GetValue('pop_txt_ADDRESSOTHER') + ' ' + value);
};

ItsButton.Event('btn_PASSWORD').onClick = function () {
    var $COMPREGNO = ItsText.GetValue('txt_BDVREGNO');
    var $PASSWORD = ItsText.GetValue('txt_PASSWORD');

    if ($PASSWORD == '') {
        ItsMsg.Alert('인증서 비밀번호를 입력하십시오.');
        return;
    }
    if ($('#keyTaxFile').find('.upload-hidden')[0].value == '') {
        ItsMsg.Alert('signPri.key 파일을 선택하십시오.');
        return;
    }
    if ($('#derTaxFile').find('.upload-hidden')[0].value == '') {
        ItsMsg.Alert('signCert.der 파일을 선택하십시오.');
        return;
    }
    if (ItsText.GetValue('txt_BDVREGNO').replace(/-/gi, '').Length != 10 && ItsText.GetValue('txt_BDVREGNO') == '') {
        ItsMsg.Alert('정상적인 사업장 등록번호를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('txt_COMPNMFULL') == '') {
        ItsMsg.Alert('사업장 정식명을 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('txt_INDTYPE') == '') {
        ItsMsg.Alert('사업장 업태를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('txt_INDCLASS') == '') {
        ItsMsg.Alert('사업장 종목을 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('txt_TELNO') == '') {
        ItsMsg.Alert('사업장 전화번호를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('txt_REPRENM') == '') {
        ItsMsg.Alert('사업장 대표자명을 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('txt_TAXPHONE') == '') {
        ItsMsg.Alert('계산서 휴대폰 번호를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('txt_TAXEMAIL') == '') {
        ItsMsg.Alert('계산서 이메일 주소를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('txt_ADDRESSFULL') == '') {
        ItsMsg.Alert('사업장 주소를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    $('#keyTaxFile').find('.upload-btn').find('i')[0].onclick();
    $('#derTaxFile').find('.upload-btn').find('i')[0].onclick();

    if (ItsText.GetValue('txt_LGTAXID') == '' || ItsText.GetValue('txt_LGTAXID') == undefined) {
        var emp_name = ItsText.GetValue('txt_PRSNNM');
        if (emp_name == '') {
            emp_name = ItsText.GetValue('txt_REPRENM');
        }

        $REGNO = ItsText.GetValue('txt_BDVREGNO').replace(/-/gi, '');

        var data_cont = {
            "use_json": "Y",                                                                // 가입처리 결과를 JSON 형태로 받을때 Y로 설정 default: N
            "accnt_cd": "UB",                                                               // 업체의 가입형태 일단은 UB로 하드코딩.. 추후 변경될수 있음.
            "address": encodeURIComponent(ItsText.GetValue('txt_ADDRESSFULL')),             // 주소
            "cell": ItsText.GetValue('txt_TAXPHONE'),                                       // 휴대폰
            "company": encodeURIComponent(ItsText.GetValue('txt_COMPNMFULL')),              // 업체명
            "condition": encodeURIComponent(ItsText.GetValue('txt_INDTYPE')),               // 업태
            "email": ItsText.GetValue('txt_TAXEMAIL'),                                      // 이메일
            "email_noti_yn": "Y",                                                           // 이메일 알림전송 (기본값 발송:Y)
            "emp_name": encodeURIComponent(emp_name),                                       // 업체 어드민 담당자명
            "hubcompany_id": "CITSCO",                                                      // 허브업체의 웹텍스아이디 (CITSCO)
            "items": encodeURIComponent(ItsText.GetValue('txt_INDCLASS')),                  // 종목
            "name": encodeURIComponent(ItsText.GetValue('txt_REPRENM')),                    // 업체대표자명
            "nlfr_nxt_yn": "Y",                                                             // 국세청 계산서 익일전송/즉시 전송 여부 (default:Y, 익일전송:Y, 즉시전송:C, 미전송:N)  (무조건 익일전송)
            "nltx_now_yn": "N",                                                             // 국세청 즉시전송 여부 (default:N)
            "password": $PASSWORD,                                             // 업체가 사용할 웹텍스의 패스워드
            "regno": $REGNO,                                                                // 업체사업자번호
            "sms_noti_yn": "Y",                                                             // SMS 알림전송 (기본값 발송:Y)
            "tell": ItsText.GetValue('txt_TELNO'),                                          // 전화
            "userid": "CITS_" + $REGNO                                                      // 업체가 사용할 웹텍스아이디 반드시 C로 시작할것 (CITSCO_사업자번호)
        };
        $.ajax({
            url: "http://edocu.uplus.co.kr/w20/main.ApplyInput.do",
            //url: "http://w20-test.webtax21.com/w20/main.ApplyInput.do",
            dataType: "jsonp",
            type: 'get',
            data: data_cont,
            complete: function (xhr, status) {
                if (status == "error") {
                    ItsMsg.Alert("err");
                }
            },
            success: function (data) {
                if (data.return_msg.indexOf('fail') == 0) {
                    ItsMsg.Alert(' LG TAX ID 생성 오류입니다.\n 고객센터에 문의주십시오.\n 고객센터: 1811-8909');     //아이디 중복 오류
                }
                else {
                    var maria = new ItsMaria('SYS1001_R02', 'ADD_LGTAXID');
                    maria.AddParam('LGTAXID', "CITS_" + $REGNO);
                    maria.AddParam('LGTAXPW', $PASSWORD);
                    maria.AddParam('BDVCD', ItsText.GetValue('txt_BDVCD'));
                    maria.CallProc();
                    if (maria.isError) {
                        maria.ShowErrMsg();
                        return;
                    }
                }
            }
        });
    }

    _sendPassword($COMPREGNO, $PASSWORD);
};

ItsButton.Event('pop_btn_PASSWORD').onClick = function () {

    var $COMPREGNO = ItsText.GetValue('pop_txt_BDVREGNO');
    var $PASSWORD = ItsText.GetValue('pop_txt_PASSWORD');

    if ($PASSWORD == '') {
        ItsMsg.Alert('인증서 비밀번호를 입력하십시오.');
        return;
    }
    if ($('#pop_keyTaxFile').find('.upload-hidden')[0].value == '') {
        ItsMsg.Alert('signPri.key 파일을 선택하십시오.');
        return;
    }
    if ($('#pop_derTaxFile').find('.upload-hidden')[0].value == '') {
        ItsMsg.Alert('signCert.der 파일을 선택하십시오.');
        return;
    }
    if (ItsText.GetValue('pop_txt_BDVREGNO').replace(/-/gi, '').Length != 10 && ItsText.GetValue('pop_txt_BDVREGNO') == '') {
        ItsMsg.Alert('정상적인 사업장 등록번호를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('pop_txt_COMPNMFULL') == '') {
        ItsMsg.Alert('사업장 정식명을 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('pop_txt_INDTYPE') == '') {
        ItsMsg.Alert('사업장 업태를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('pop_txt_INDCLASS') == '') {
        ItsMsg.Alert('사업장 종목을 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('pop_txt_TELNO') == '') {
        ItsMsg.Alert('사업장 전화번호를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('pop_txt_REPRENM') == '') {
        ItsMsg.Alert('사업장 대표자명을 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('pop_txt_TAXPHONE') == '') {
        ItsMsg.Alert('계산서 휴대폰 번호를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('pop_txt_TAXEMAIL') == '') {
        ItsMsg.Alert('계산서 이메일 주소를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }
    if (ItsText.GetValue('pop_txt_ADDRESSFULL') == '') {
        ItsMsg.Alert('사업장 주소를 입력하십시오.\n세금계산서 발행시 필요한 정보입니다.');
        return;
    }

    $('#pop_keyTaxFile').find('.upload-btn').find('i')[0].onclick();
    $('#pop_derTaxFile').find('.upload-btn').find('i')[0].onclick();

    var emp_name = ItsText.GetValue('pop_txt_PRSNNM');
    if (emp_name == '') {
        emp_name = ItsText.GetValue('pop_txt_REPRENM');
    }

    $REGNO = ItsText.GetValue('pop_txt_BDVREGNO').replace(/-/gi, '');

    var data_cont = {
        "use_json": "Y",                                                                    // 가입처리 결과를 JSON 형태로 받을때 Y로 설정 default: N
        "accnt_cd": "UB",                                                                   // 업체의 가입형태 일단은 UB로 하드코딩.. 추후 변경될수 있음.
        "address": encodeURIComponent(ItsText.GetValue('pop_txt_ADDRESSFULL')),             // 주소
        "cell": ItsText.GetValue('pop_txt_TAXPHONE'),                                       // 휴대폰
        "company": encodeURIComponent(ItsText.GetValue('pop_txt_COMPNMFULL')),              // 업체명
        "condition": encodeURIComponent(ItsText.GetValue('pop_txt_INDTYPE')),               // 업태
        "email": ItsText.GetValue('pop_txt_TAXEMAIL'),                                      // 이메일
        "email_noti_yn": "Y",                                                               // 이메일 알림전송 (기본값 발송:Y)
        "emp_name": encodeURIComponent(emp_name),                                           // 업체 어드민 담당자명
        "hubcompany_id": "CITSCO",                                                          // 허브업체의 웹텍스아이디 (CITSCO)
        "items": encodeURIComponent(ItsText.GetValue('pop_txt_INDCLASS')),                  // 종목
        "name": encodeURIComponent(ItsText.GetValue('pop_txt_REPRENM')),                    // 업체대표자명
        "nlfr_nxt_yn": "Y",                                                                 // 국세청 계산서 익일전송/즉시 전송 여부 (default:Y, 익일전송:Y, 즉시전송:C, 미전송:N)  (무조건 익일전송)
        "nltx_now_yn": "N",                                                                 // 국세청 즉시전송 여부 (default:N)
        "password": $PASSWORD,                                                              // 업체가 사용할 웹텍스의 패스워드
        "regno": $REGNO,                                                                    // 업체사업자번호
        "sms_noti_yn": "Y",                                                                 // SMS 알림전송 (기본값 발송:Y)
        "tell": ItsText.GetValue('pop_txt_TELNO'),                                          // 전화
        "userid": "CITS_" + $REGNO                                                          // 업체가 사용할 웹텍스아이디 반드시 C로 시작할것 (CITSCO_사업자번호)
    };
    $.ajax({
        url: "http://edocu.uplus.co.kr/w20/main.ApplyInput.do",
        //url: "http://w20-test.webtax21.com/w20/main.ApplyInput.do",
        dataType: "jsonp",
        type: 'get',
        data: data_cont,
        complete: function (xhr, status) {
            if (status == "error") {
                ItsMsg.Alert("err");
            }
        },
        success: function (data) {
            if (data.return_msg.indexOf('fail') == 0) {
                ItsMsg.Alert(' LG TAX ID 생성 오류입니다.\n 고객센터에 문의주십시오.\n 고객센터: 1811-8909');     //아이디 중복 오류
            }
            else {
                var maria = new ItsMaria('SYS1001_R02', 'ADD_LGTAXID');
                maria.AddParam('LGTAXID', "CITS_" + $REGNO);
                maria.AddParam('LGTAXPW', $PASSWORD);
                maria.AddParam('BDVCD', ItsText.GetValue('pop_txt_BDVCD'));
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
            }
        }
    });


    _sendPassword($COMPREGNO, $PASSWORD);
};

_sendPassword = function ($COMPREGNO, $PASSWORD) {

    $.ajax({
        async: false,
        maria: this,
        url: 'https://09mipl.co.kr/PAGESYS/SYS9000/SYS9000_R02_PASSWORD.aspx?COMPREGNO=' + $COMPREGNO,
        type: 'post',
        dataType: 'text',
        data: {
            COMPREGNO: $COMPREGNO,
            PASSWORD: $PASSWORD
        },
        success: function (data, staus) {
            var $pathText = data;
            if ($pathText != '\n') {
                ItsMsg.Alert(' 인증서 등록 성공\n 다시 조회해주시기 바랍니다.');
            }
            else
                ItsMsg.Alert('인증서 등록 실패');

        },
        error: function (xhr, status, error) {
            ItsMsg.Alert('실패');
        }
    });
}