/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    // 수주로 바꾸기

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true, allowSorting: false }, [
        column.create('납기일자', 'EXPDATE', { width: 120, align: 'center' }),
        column.create('수주명', 'SALODRNM', { width: 150 }),
        column.create('수주상태', 'SALODRSTT', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'SALODRSTT', align: 'center' }),
        column.create('거래처코드', 'CUSTCD', { width: 100, align: 'center', hidden: true }),
        column.create('거래처', 'CUSTNM', { width: 150, backColor: enumColor.greenLight2, align: 'center' }),

        column.create('품목코드', 'ITEMCD', { width: 100 }),
        column.create('품명', 'ITEMNM', { width: 150 }),

        column.create('수주수량', 'ODRQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('스캔수량', 'SCANQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        //column.create('출고수량', 'OUTQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('현재고', 'SUMQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('비고', 'REMARK', { width: 150 }),

        column.create('수주상세번호', 'SALODRDKEY', { width: 100, hidden: true }),

        column.split()
    ]);

    // 출하스캔리스트
    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('출고키', 'SALOUTKEY', { width: 100, hidden: true, align: 'center' }),
        column.create('스캔시간', 'SCANTIME', { width: 250, align: 'center' }),
        column.create('로트번호', 'LOTKEY', { width: 200, align: 'center' }),
        column.create('로트수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2, groupType: enumGrouping.sum, groupType: enumGrouping.sum }),
        column.create('삭제', 'CANCEL', { width: 150, columnType: enumColumnTypes.button, iconCls: "fa fa-trash" }),
        column.split()
    ]);



    // 현재고
    ItsGrid.Create('grid3', { isSubTotalGrid: true }, [        
        column.create('로트번호', 'LOTKEY', { width: 200, align: 'center' }),
        column.create('로트수량', 'LOTQTY', { width: 150, columnType: enumColumnTypes.number, decimalPrecision: 2, groupType: enumGrouping.sum, groupType: enumGrouping.sum }),
        column.create('스캔수량', 'SCANQTY', { width: 150, columnType: enumColumnTypes.number, decimalPrecision: 2, groupType: enumGrouping.sum, groupType: enumGrouping.sum, readOnly: false }),

        column.create('스캔', 'SCAN', { width: 100, columnType: enumColumnTypes.button, iconCls: "fa fa-barcode", foreColor: "BLUE"  }),
        column.create('취소', 'CANCEL', { width: 100, columnType: enumColumnTypes.button, iconCls: "fa fa-trash", foreColor: "RED" }),
        column.split()
    ]);


    ItsDateRange.SetInitValueFrom('date_SALDATE', ItsHelper.GetYearMonth() + '-01');

};
/*******************************************************************************************************************************************************************************************/
/* 조회 */
ItsButton.Event('btn_SALODRD').onClick = function () {
    LIST_SALODRD();
};

// 수주품목 조회
LIST_SALODRD = function () {

    var maria = new ItsMaria('TAL0001_R04', 'LIST_SALODRD');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsGrid.Get('grid1').autoSizeColumns();
}
/*******************************************************************************************************************************************************************************************/
// 수주클릭시
ItsGrid.Event('grid1').onSelect = function () {   
    LIST_SCANLOTLIST();
}

// 출하스캔로트 조회
LIST_SCANLOTLIST = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TAL0001_R04 ', 'LIST_SCANLIST');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
}

// 츨하스캔리스트에서 삭제
ItsGrid.Event('grid2').onButtonClick = function (rowIndex, field) {
    if (field == "CANCEL") {
        var maria = new ItsMaria('TAL0001_R04', 'CANCEL_SCAN_LOT');

        maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
        maria.AddParam('LOTKEY', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'LOTKEY'));
        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

    }

    ItsGrid.Setkey('grid1', 'SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
    LIST_SALODRD();

    ItsGrid.Setkey('grid2', 'LOTKEY', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2') - 1, 'LOTKEY'));
    LIST_SCANLOTLIST();
}
/*******************************************************************************************************************************************************************************************/
// 출하스캔등록 팝업오픈
ItsButton.Event('btn_SCAN_SALOUT').onClick = function () {
    LOTKEY_LIST();    
    ItsPop.Open('pop_SCAN');
}

// 현재고조회
LOTKEY_LIST = function () {
    var maria = new ItsMaria('TAL0001_R04', 'LIST_COMLOT');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    } 
    ItsText.SetValue('pop_txt_WARECD', maria.store.data[0]["WARECD"]);
    ItsText.SetValue('pop_txt_WARENM', maria.store.data[0]["WARENM"]);
    ItsText.SetValue('pop_txt_ITEMCD', maria.store.data[0]["ITEMCD"]);
    ItsText.SetValue('pop_txt_ITEMNM', maria.store.data[0]["ITEMNM"]);
    ItsNum.SetValue('pop_num_SALOUTQTY', maria.store.data[0]["TOTALSALOUTQTY"]);
    ItsNum.SetValue('pop_num_SCANQTY', maria.store.data[0]["TOTALSCANQTY"]);

    ItsGrid.SetStore('grid3', maria.store);
}


ItsGrid.Event('grid3').onButtonClick = function (rowIndex, field) {
    // 출하스캔등록
    if (field == "SCAN") {
        var maria = new ItsMaria('TAL0001_R04', 'SCAN_LOT');

        maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
        maria.AddParam('CUSTCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CUSTCD'));
        maria.AddParam('LOTKEY', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'LOTKEY'));
        maria.AddParam('SCANQTY', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'SCANQTY'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
    }
    // 출하스캔취소
    else if (field == "CANCEL") {
        var maria = new ItsMaria('TAL0001_R04', 'CANCEL_SCAN_LOT');

        maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
        maria.AddParam('LOTKEY', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'LOTKEY'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
    }

    ItsGrid.Setkey('grid1', 'SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
    LIST_SALODRD();

    ItsGrid.Setkey('grid3', 'LOTKEY', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3') - 1, 'LOTKEY'));
    LOTKEY_LIST();

    LIST_SCANLOTLIST();
}

/*******************************************************************************************************************************************************************************************/
ItsText.Event('pop_txt_LOTKEY').onKeyEnter = function (value, oldValue) {
    var maria = new ItsMaria('TAL0001_R04', 'SCAN_LOT');

    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
    maria.AddParam('CUSTCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CUSTCD'));
    maria.AddParam('LOTKEY', value);

    var SCANQTY = 0;
    var currentIndext_grid3 = 0;

    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if (ItsGrid.GetValue('grid3', i, 'LOTKEY') == value) {
            SCANQTY = ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'LOTQTY');
            currentIndext_grid3 = i;
            break;
        }
    }

    maria.AddParam('SCANQTY', SCANQTY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }    

    ItsText.SetValue('pop_txt_LOTKEY', '');

    ItsGrid.Setkey('grid1', 'SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
    LIST_SALODRD();

    ItsGrid.Setkey('grid3', 'LOTKEY', ItsGrid.GetValue('grid3', currentIndext_grid3 - 1, 'LOTKEY'));
    LOTKEY_LIST();

    LIST_SCANLOTLIST();
};
/*******************************************************************************************************************************************************************************************/
// 출고확정
ItsButton.Event('btn_CONFIRM_SALOUT').onClick = function () {
    ItsMsg.Confirm("출고확정하시겠습니까?", function () {
        var maria = new ItsMaria('TAL0001_R04', 'CONFIRM_SALOUT');

        maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        LIST_SALODRD();
    });
}
/*******************************************************************************************************************************************************************************************/