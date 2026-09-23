//거래처정보
/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('사업자번호', 'REGBUSSNUM', { width: 90, hidden: true }),
        column.create('종사업장번호', 'PLACENO', { width: 90, hidden: true }),
        column.create('구매처', 'PURYN', { width: 70, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('판매처', 'SALEYN', { width: 70, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('외주처', 'OSCYN', { width: 70, columnType: enumColumnTypes.check, readOnly: false }),
        column.create("거래처 코드", "CUSTCD", { width: 90 }),
        column.create("상호(정식명칭)", "CUSTNM", { width: 150 }),
        //column.create('거래처유형', 'CUSTTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CUSTTP' }),
        column.create("대표자", "PRESIDENT", { width: 120 }),
        column.create("업태", "REGBUSSTP", { width: 130 }),
        column.create("종목", "REGBUSSITEM", { width: 130 }),
        column.create("주소", "CUSTADDRFULL", { width: 350 }),
        column.create("전화번호", "CUSTTEL", { width: 110 }),
        column.create("팩스번호", "CUSTFAX", { width: 110 }),
        column.create("비고", "REMARK", { width: 350 }),
        column.create("수주 담당자", "CHARGENM", { width: 120 }),
        column.create("발주 담당자", "CHARGENM", { width: 120 }),
        column.split(1)
    ]);

    ItsDate.SetInitValue('date_TRADESDT', ItsHelper.GetYearMonth() + '-01');
    ItsDate.SetInitValue('date_TRADEEDT', '2999-12-31');

};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsPage.InitData('ddiv1');

    var maria = new ItsMaria('MST0001_R08', 'LIST_CUST');

    maria.AddPanel('sdiv1');
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('PURYN').YnToBool('SALEYN').YnToBool('OSCYN'));
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};

/* 추가 */
ItsButton.EventAdd = function () {
    ItsText.Disable('txt_CUSTCD');
    ItsOnoff.SetValue('onoff_GETCDYN', true);
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
};

ItsPop.Event('pop1').onAddBtnClick = function () {

    var maria = new ItsMaria('MST0001_R08', 'CHECK_REGBUSSNUM');
    maria.AddPanel('pdiv1');
    maria.CallProc();
    var data = maria.store.data[0].REGBUSSNUM;
    var txt_REGBUSSNUM = ItsText.GetValue('txt_REGBUSSNUM');
    var REGBUSSNUM = txt_REGBUSSNUM.replace(/[-\s]/g, '');



    if (data == undefined || data == 'undefined' || data != REGBUSSNUM) {
        var maria = new ItsMaria('MST0001_R08', 'ADD_CUST');
        maria.AddPanel('pdiv1');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsPop.Close('pop1');
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsButton.EventSearch();
    }

    if (data == REGBUSSNUM) {
        ItsMsg.Confirm('해당 사업자 번호는 중복된 사업자 번호입니다 \n\n 저장하시겠습니까?', function () {
            var maria = new ItsMaria('MST0001_R08', 'ADD_CUST');
            maria.AddPanel('pdiv1');
            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsPop.Close('pop1');
            ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
            ItsButton.EventSearch();

        })
    }

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    //ItsPop.Close('pop1');
    //ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    //ItsButton.EventSearch();


    //var maria = new ItsMaria('MST1001_R01', 'ADD_CUST');
    //maria.AddPanel('pdiv1');
    //maria.CallProc();
    //if (maria.isError) {
    //    maria.ShowErrMsg();
    //    return;
    //}
    //ItsPop.Close('pop1');
    //ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    //ItsButton.EventSearch();
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    ItsPage.InitData('pdiv1');
}

/* 저장 */
ItsButton.EventSave = function () {
    //if (ItsOnoff.GetValue('onoff_SCMLOCKYN') == 'N') {
    //    if (ItsText.GetValue('txt_TAG') == "") {
    //        ItsMsg.Alert("SCM을 사용하기 위해서는 거래처 약칭이 필요합니다.");
    //        return;
    //    }
    //}


    var maria = new ItsMaria('MST0001_R08', 'UP_CUST');
    maria.AddPanel('ddiv1');
    maria.AddParam('CUSTCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CUSTCD'));
    if (ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PURYN', false) == 'Y') {
        maria.AddParam('PURYN', 'Y');
    } else {
        maria.AddParam('PURYN', 'N');
    }

    if (ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALEYN', false) == 'Y') {
        maria.AddParam('SALEYN', 'Y');
    } else {
        maria.AddParam('SALEYN', 'N');
    }
    if (ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'OSCYN', false) == 'Y') {
        maria.AddParam('OSCYN', 'Y');
    } else {
        maria.AddParam('OSCYN', 'N');
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();     
        return;
    }

    ItsGrid.Setkey('grid1', 'CUSTCD', ItsText.GetValue('txt_CUSTCD'));
    ItsButton.EventSearch();
    ItsMsg.Toast('저장되었습니다.');
};

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('삭제하시겠습니까?', function () {
        var maria = new ItsMaria('MST0001_R08', 'DEL_CUST');
        maria.AddParam('CUSTCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CUSTCD'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.EventSearch();
        ItsMsg.Toast("삭제되었습니다.");
    });
};

/* 그리드 선택 */
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsPage.SetStore('ddiv1', ItsGrid.GetRowData('grid1', rowIndex));
};

/* 자동 채번 변경 */
ItsOnoff.Event('onoff_GETCDYN').onChanged = function (newValue) {
    if (newValue == true) {
        ItsText.Disable('txt_CUSTCD');
    } else {
        ItsText.Enable('txt_CUSTCD');
    }
};

/* 홈페이지 이동 버튼 */
ItsButton.Event('MOVE_HOMEPAGE').onClick = function () {
    location.href = ItsText.GetValue('txt_HOMEURL');
};

ItsButton.Event('pop_MOVE_HOMEPAGE').onClick = function () {
    location.href = ItsText.GetValue('pop_txt_HOMEURL');
};

/* 우편번호 검색 버튼 */
ItsButton.Event('SEARCH_ZIP').onClick = function () {
    // -----------------------------------------------------------------------------------
    var width = 500; //팝업의 너비
    var height = 600; //팝업의 높이
    new kakao.Postcode({
        width: width,
        height: height,
        popupName: 'postcode',
        oncomplete: function (data) {
            // ---- 수정 가능 ----------------------------------------------------------------- //
            ItsText.SetValue('txt_CUSTZIP', data.zonecode);
            ItsText.SetValue('txt_CUSTADDR', data.roadAddress);
            ItsText.SetValue('txt_CUSTADDRDETAIL', ' (' + data.buildingName + ') ');
            ItsText.SetValue('txt_CUSTADDRFILL', '');
            ItsText.SetValue('txt_ADDRESSFULL', data.roadAddress + ' (' + data.buildingName + ') ');
            // ---- 수정 가능 ----------------------------------------------------------------- //
        }
    }).open({ // 가운데 정렬 (듀얼 디스플레이에선 위치 안맞을수 있음)
        left: (window.screen.width / 2) - (width / 2),
        top: (window.screen.height / 2) - (height / 2)
    });
};

/* 상세 주소 변경 시 전체 주소에 반영 */
ItsText.Event('txt_CUSTADDRFILL').onChanged = function (value, oldValue) {
    ItsText.SetValue('txt_ADDRESSFULL', ItsText.GetValue('txt_CUSTADDR') + ' ' + value + ' ' + ItsText.GetValue('txt_CUSTADDRDETAIL'));
};

/* 건물명 변경 시 전체 주소에 반영 */
ItsText.Event('txt_CUSTADDRDETAIL').onChanged = function (value, oldValue) {
    ItsText.SetValue('txt_ADDRESSFULL', ItsText.GetValue('txt_CUSTADDR') + ' ' + ItsText.GetValue('txt_CUSTADDRFILL') + ' ' + value);
};


/* 우편번호 검색 버튼 */
ItsButton.Event('pop_SEARCH_ZIP').onClick = function () {
    // -----------------------------------------------------------------------------------
    var width = 500; //팝업의 너비
    var height = 600; //팝업의 높이
    new kakao.Postcode({
        width: width,
        height: height,
        popupName: 'postcode',
        oncomplete: function (data) {
            // ---- 수정 가능 ----------------------------------------------------------------- //
            ItsText.SetValue('pop_txt_CUSTZIP', data.zonecode);
            ItsText.SetValue('pop_txt_CUSTADDR', data.roadAddress);
            ItsText.SetValue('pop_txt_CUSTADDRDETAIL', ' (' + data.buildingName + ') ');
            ItsText.SetValue('pop_txt_CUSTADDRFILL', '');
            ItsText.SetValue('pop_txt_CUSTADDRFULL', data.roadAddress + ' (' + data.buildingName + ') ');
            // ---- 수정 가능 ----------------------------------------------------------------- //
        }
    }).open({ // 가운데 정렬 (듀얼 디스플레이에선 위치 안맞을수 있음)
        left: (window.screen.width / 2) - (width / 2),
        top: (window.screen.height / 2) - (height / 2)
    });
};

/* 상세 주소 변경 시 전체 주소에 반영 */
ItsText.Event('pop_txt_CUSTADDRFILL').onChanged = function (value, oldValue) {
    ItsText.SetValue('pop_txt_CUSTADDRFULL', ItsText.GetValue('pop_txt_CUSTADDR') + ' ' + value + ' ' + ItsText.GetValue('pop_txt_CUSTADDRDETAIL'));
};

/* 건물명 변경 시 전체 주소에 반영 */
ItsText.Event('pop_txt_CUSTADDRDETAIL').onChanged = function (value, oldValue) {
    ItsText.SetValue('pop_txt_CUSTADDRFULL', ItsText.GetValue('pop_txt_CUSTADDR') + ' ' + ItsText.GetValue('pop_txt_CUSTADDRFILL') + ' ' + value);
};
