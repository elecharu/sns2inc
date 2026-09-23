/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {



    ItsGrid.Create('grid1', { isSubTotalGrid: true}, [
        column.create('창고명', 'WARECD', { width: 100, align:'center' ,columnType: enumColumnTypes.combo, gpcd: 'WARECD' }),
        column.create('품목유형', 'ITEMTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ITEMTP' }),
        column.create('품목코드', 'ITEMCD', { width: 250, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 300, align: 'center' }),
        column.create('재고', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, groupType: enumGrouping.sum }),
        column.create('단위', 'UNIT', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT'}),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true, isSubTotalGrid: true}, [
        column.create('로트번호', 'LOTKEY', { width: 200, align: 'center' }),
        column.create('로트수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, groupType: enumGrouping.sum }),
        column.create('이동수량', 'MOVEQTY', { width: 100, columnType: enumColumnTypes.number, readOnly: false, groupType: enumGrouping.sum, groupType: enumGrouping.sum }),

    ]);

    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
};



// 상단 품목 조회
ItsButton.Event('button_SEARCHITEM').onClick = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TAL0001_R02', 'LIST_ITEMLIST');

    maria.AddPanel('sdiv1');
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
}

ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    var maria = new ItsMaria('TAL0001_R02', 'LIST_COMLOT');

    maria.AddRecord('grid1', rowIndex);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
};

//이동등록 클릭 부분
ItsButton.Event('SUBMIT_COMMOVE').onClick = function () {
    var maria = new ItsMaria('TAL0001_R02', 'MOVE_COMLOT');

    var ITEMCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD');

    maria.AddPanel('pdiv1');
    maria.AddParam('WARECD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'WARECD'));
    maria.AddParam('ITEMCD', ITEMCD);

    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {

            maria.AddList('LOTKEY_LIST', ItsGrid.GetValue('grid2', i, 'LOTKEY'));
            maria.AddList('MOVEQTY_LIST', ItsGrid.GetValue('grid2', i, 'MOVEQTY'));
        }
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    else {
        ItsGrid.UnCheckRow('grid2', i);
    }

    ItsGrid.Setkey('grid1', 'ITEMCD', ITEMCD);

    ItsButton.Event('button_SEARCHITEM').onClick();
}


