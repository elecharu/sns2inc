/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {
    $('.title-text').html('재고조회');

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('창고', 'WARECD', { width: 80, hidden: true }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd:'ITEMTP' }),
        column.create('재고량', 'SUMQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: true }, [        
        column.create('품목정보', 'ITEMINFO', { width: 80 }),        
        column.create('재고량', 'SUMQTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT' }),
    ]);

    ItsGrid.Create('grid3', { isSubTotalGrid: true}, [
        column.create('로트번호', 'LOTKEY', { width: 80}),
        column.create('재고량', 'LOTQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT' }),
        column.create('입고일자', 'PRDDATE', { width: 80 }),
        column.create('거래처', 'CUSTNM', { width: 80 }),
    ]);


    // 그리드 Row 높이 수정
    ItsGrid.Get('grid2').formatItem.addHandler(function (s, e) {
        for (var i = 0; i < ItsGrid.Length('grid2') ; i++) {
            ItsGrid.Get('grid2').rows[i].height = 66;
        }
    });

    
};

//***********************************************************************************************
// 이전화면 이동
ItsButton.Event('MOVE_BACK').onClick = function () {
    location.href = '../PDA_MENU/PDA_MENU.aspx';
};
//***********************************************************************************************
// 품목유형별 재고조회
ItsButton.Event('btn_LIST_COMLOT_ITEMTP').onClick = function () {
    LIST_COMLOT_ITEMTP();
};

var LIST_COMLOT_ITEMTP = function () {
    var maria = new ItsMaria('PDA1100_R01', 'LIST_COMLOT_ITEMTP');

    maria.AddParam('WARECD', ItsCombo.GetValue('cmb_WARECD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    //ItsGrid.Get('grid1').autoSizeColumns();
}
//***********************************************************************************************
ItsButton.Event('btn_SELECT_ITEMTP').onClick = function () {
    if (ItsGrid.GetCurrentIndex('grid1') < 0) {
        return;
}
    ItsPop.Open('pop_LIST_COMLOT_ITEMCD');
};


ItsPop.Event('pop_LIST_COMLOT_ITEMCD').onPopOpened = function () {
    LIST_COMLOT_ITEMCD();
};

ItsPop.Event('pop_LIST_COMLOT_ITEMCD').onPopClosed = function () {
    LIST_COMLOT_ITEMTP();
};


// 품목코드별 재고조회 
var LIST_COMLOT_ITEMCD = function () {
    var maria = new ItsMaria('PDA1100_R01', 'LIST_COMLOT_ITEMCD');

    maria.AddParam('WARECD', ItsCombo.GetValue('cmb_WARECD'));
    maria.AddParam('ITEMTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "ITEMTP"));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid2').autoSizeColumns();
}
//***********************************************************************************************
ItsButton.Event('btn_SELECT_ITEMCD').onClick = function () {
    if (ItsGrid.GetCurrentIndex('grid2') < 0)
        return;

    ItsPop.Open('pop_LIST_COMLOT');
};



ItsPop.Event('pop_LIST_COMLOT').onPopOpened = function () {
    LIST_COMLOT();
};

ItsPop.Event('pop_LIST_COMLOT').onPopClosed = function () {
    LIST_COMLOT_ITEMCD();
};

// 로트별 재고조회 
var LIST_COMLOT = function () {
    var maria = new ItsMaria('PDA1100_R01', 'LIST_COMLOT');

    maria.AddParam('WARECD', ItsCombo.GetValue('cmb_WARECD'));
    maria.AddParam('ITEMTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), "ITEMTP"));
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), "ITEMCD"));    

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store);
    ItsGrid.Get('grid3').autoSizeColumns();
}
//***********************************************************************************************
