//품목정보
/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */

/*품목정보관리 화면*/

ItsPage.Load = function () {

    /* 그리드 생성 */
    // 원자재
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("품목유형", "ITEMTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', readOnly: false, align: 'center' }),
        column.create("거래처코드", "CUSTCD", { width: 120, align: 'center', readOnly: false  }),      
        column.create("거래처명", "CUSTNM", { width: 120, align: 'center' }),      
        column.create("품목코드", "ITEMCD", { width: 150 }),                
        column.create("품명", "ITEMNM", { width: 200, readOnly: false }),
        column.create("버전", "REV", { width: 80, align: 'center' }),             
        column.create("공정", "PRCCD", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PRCCD', readOnly: false, align: 'center' }),        
        
        column.create("재질", "MATERIAL", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', readOnly: false, align: 'center' }),        
        column.create("두께", "THICK", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1, readOnly: false }),
        column.create("길이", "LENGTH", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1, readOnly: false }),
        column.create("폭", "WIDTH", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1, readOnly: false}),        
        column.create("단위", "ITEMUNIT", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', readOnly: false, align: 'center' }),
        column.create('잔재품목 생성', 'POP_ADD_MTRLEFT', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-plus', hidden: true }),

        column.create('잔재품목', 'MTRLEFT_YN', { width: 80, columnType: enumColumnTypes.check }),
        column.create('한로트관리', 'ONELOT_YN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        column.create('수입검사', 'INTEST_YN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        column.create('공정검사', 'PRCTEST_YN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        column.create('출고검사', 'OUTTEST_YN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        column.create('사용여부', 'USEYN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        column.create("비고", "REMARK", { width: 200, readOnly: false }),
        column.split()
    ]);


};
/************************************************************************************************************************************************************/
/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R09', 'LIST_MSTITEM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN').YnToBool('ONELOT_YN').YnToBool('INTEST_YN').YnToBool('PRCTEST_YN').YnToBool('OUTTEST_YN').YnToBool('MTRLEFT_YN'));

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

};
/************************************************************************************************************************************************************/
/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
};

// 품목생성
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('MST0001_R09', 'ADD_MSTITEM');

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

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    ItsPage.InitData('pdiv1');
}
/************************************************************************************************************************************************************/
/* 품목수정 */
ItsButton.EventSave = function () {
    ItsMsg.Confirm("수정한 정보를 저장하시겠습니까?", function () { 
        var cnt = 0;
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var maria = new ItsMaria('MST0001_R09', 'UP_MSTITEM');

                maria.AddRecord('grid1', i);

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                } else {
                    cnt++;
                }
            }
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
        ItsButton.EventSearch();
    });
};

/* 품목삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택한 정보를 삭제하시겠습니까?", function () {
        var cnt = 0;
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var maria = new ItsMaria('MST0001_R09', 'DEL_MSTITEM');

                maria.AddRecord('grid1', i);

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                } else {
                    cnt++;
                }
            }
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
        ItsButton.EventSearch();
    });
}
/************************************************************************************************************************************************************/
ItsGrid.Event('grid1').onButtonClick = function (rowindex, field) {
    if (field == 'POP_ADD_MTRLEFT') {
        // 잔재품목 생성 팝업오픈

        var ITEMTP = ItsGrid.GetValue('grid1', rowindex, 'ITEMTP');
        var MTRLEFT_YN = ItsGrid.GetValue('grid1', rowindex, 'MTRLEFT_YN');
        var ITEMCD = ItsGrid.GetValue('grid1', rowindex, 'ITEMCD');

        if (ITEMTP != '10') {
            ItsMsg.Alert('품목유형이 원자재가 아닙니다.');
            return;
        }

        if (MTRLEFT_YN) {
            ItsMsg.Alert('잔재품목은 불가능 합니다.');
            return;
        }

        // 신규 잔재품목코드 찾기
        var maria = new ItsMaria('MST0001_R09', 'SEARCH_NEW_MTRLEFT');

        maria.AddParam('ITEMCD', ITEMCD);

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsText.SetValue('txt_ITEMCD_MTRLEFT', maria.store.GetValue(0, 'ITEMCD_MTRLEFT'));
        ItsText.SetValue('txt_ITEMNM_MTRLEFT', maria.store.GetValue(0, 'ITEMNM_MTRLEFT'));

        ItsNum.SetValue('num_LENGTH_MTRLEFT', maria.store.GetValue(0, 'LENGTH_MTRLEFT'));
        ItsNum.SetValue('num_WIDTH_MTRLEFT', maria.store.GetValue(0, 'WIDTH_MTRLEFT'));

        ItsPop.Open('pop2');        
    }
}

ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
    ItsPage.InitData('pdiv2');
}

// 신규잔재 생성
ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('MST0001_R09', 'ADD_MTRLEFT');

    maria.AddPanel('pdiv2');
    maria.AddParam('ITEMCD_PARENT', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop2');

    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());

    ItsButton.EventSearch();
}
/************************************************************************************************************************************************************/
ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid1').onKeydownEnter(rowIndex, field);
}

ItsGrid.Event('grid1').onKeydownEnter = function (rowIndex, field) {
    if (field == 'CUSTCD' || field == 'CUSTNM') {
        ItsPop.OpenFindCOM({ gpcd: 'CUSTCD', keyword: ItsGrid.GetValue('grid1', rowIndex, field) }, function (res) {
            ItsGrid.SetValue('grid1', rowIndex, 'CUSTCD', res['CODE']);
            ItsGrid.SetValue('grid1', rowIndex, 'CUSTNM', res['NAME']);
            ItsGrid.CheckRow('grid1', rowIndex);
        });
    }

}
/************************************************************************************************************************************************************/