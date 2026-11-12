/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create("실사그룹키", "CHKGROUPKEY", { width: 100, hidden: true }),
        column.create("실사일자", "CHKDATE", { width: 100, align: 'center' }),
        column.create("품목유형", "ITEMCG", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create("창고", "WARENM", { width: 90, align: 'center' }),
        column.create("창고코드", "WARECD", { width: 100, hidden: true }),
        column.create("실사명", "CHKNM", { width: 100, align: 'center' }),
        column.create("전산수량", "OLDSUMQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("실사수량", "LOTCHKQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("차이", "DIFFQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("승인완료", "DONEYN", { width: 80, align: 'center', columnType: enumColumnTypes.check }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create("실사키", "CHKKEY", { width: 100, hidden: true }),
        column.create("품목코드", "ITEMCD", { width: 100 }),
        column.create("품목유형", "ITEMCG", { width: 70, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create("품명", "ITEMNM", { width: 290 }),
        column.create("전산수량", "OLDSUMQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("실사수량", "LOTCHKQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("차이", "DIFFQTY", { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("승인여부", "CHKAPPYN", { width: 80, align: 'center', columnType: enumColumnTypes.check }),
        column.split()
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: false }, [
        column.create("실사키", "CHKKEY", { width: 100, hidden: true }),
        column.create("실사LOT", "CHKLOTKEY", { width: 150, align: 'center' }),
        column.create("스캔시간", "CHKSCANTIME", { width: 150 }),
        column.create("전산수량", "LOTOLDQTY", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("실사수량", "LOTCHKQTY", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("차이", "DIFFQTY", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    ItsGrid.Create('grid_ITEMLIST_ADD', { isCheckBoxGrid: true }, [
        column.create("품목ID", "ITEMID", { width: 100, hidden: true }),
        column.create("품목코드", "ITEMCD", { width: 100 }),
        column.create("품목유형", "ITEMCG", { width: 70, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create("품명", "ITEMNM", { width: 300 }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('dr_DATE', ItsHelper.GetYearMonth() + '-01');
    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('LOT1003_R01', 'LIST_COMCHK_GROUP');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('DONEYN'));

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 삭제 - 실사품목삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('삭제하시겠습니까?', function () {
        var maria = new ItsMaria('LOT1003_R01', 'COMCHK_DEL');

        maria.AddParam('CHKGROUPKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKGROUPKEY'));

        for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
            if (ItsGrid.IsChecked('grid2', i)) {
                maria.AddList('CHKKEYLIST', ItsGrid.GetValue('grid2', i, 'CHKKEY'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        var CHKGROUPKEY = ItsGrid.GetValue('grid1', ItsGrid.$GetRowIndex('grid1'), 'CHKGROUPKEY');

        ItsGrid.Setkey('grid1', 'CHKGROUPKEY', CHKGROUPKEY);

        ItsButton.EventSearch();
    });
}

// 실사지시생성 팝업 열기
ItsButton.EventAdd = function () {
    ItsButton.Event('btn_SEARCH_ITEMLIST').onClick();
    ItsPop.Open('pop1');
    ItsPage.InitData('pdiv1');
}

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
}

// 품목리스트 조회- 추가 팝업(완료)
ItsButton.Event('btn_SEARCH_ITEMLIST').onClick = function () {
    var maria = new ItsMaria('LOT1003_R01', 'SEARCH_ITEMLIST');

    maria.AddParam('WARECD', ItsCombo.GetValue('pdiv1_cmb_WARECD'));
    maria.AddParam('ITEMCG', ItsCombo.GetValue('pdiv1_cmb_ITEMCG'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid_ITEMLIST_ADD', maria.store);
}

// 실사지시생성 저장
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('LOT1003_R01', 'COMCHK_ADD');

    maria.AddPanel('float1');

    for (var i = 0; i < ItsGrid.Length('grid_ITEMLIST_ADD'); i++) {
        if (ItsGrid.IsChecked('grid_ITEMLIST_ADD', i)) {
            maria.AddList('ITEMIDLIST', ItsGrid.GetValue('grid_ITEMLIST_ADD', i, 'ITEMID'));
        }
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');
    ItsButton.EventSearch();
}

// 팝업 창고 변경 시 품목리스트 재조회
ItsCombo.Event('pdiv1_cmb_WARECD').onChanged = function () {
    ItsButton.Event('btn_SEARCH_ITEMLIST').onClick();
}

// 실사지시 선택 > 하위품목 리스트 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    var maria = new ItsMaria('LOT1003_R01', 'LIST_COMCHK');

    maria.AddRecord('grid1', rowIndex);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('CHKAPPYN'));
};

// 품목 선택 > 로트 리스트 조회
ItsGrid.Event('grid2').onSelect = function (rowIndex, field) {
    var maria = new ItsMaria('LOT1003_R01', 'LIST_COMCHKLOT');

    maria.AddRecord('grid2', rowIndex);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store);
};

// 승인 버튼
ItsButton.Event('btn_CONFIRM_COMCHK').onClick = function () {
    if (!ItsGrid.HasChecked('grid2')) {
        ItsMsg.Alert('승인할 품목을 선택하세요.');
        return;
    }

    ItsMsg.Confirm("※ 주의 ※\n- 실사재고가 전산에 반영됩니다.\n- 실사하지 않은 로트는 삭제됩니다.\n\n승인을 하시겠습니까?", function () {
        var maria = new ItsMaria('LOT1003_R01', 'COMCHK_CONFIRM');

        for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
            if (ItsGrid.IsChecked('grid2', i)) {
                maria.AddList('CHKKEYLIST', ItsGrid.GetValue('grid2', i, 'CHKKEY'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        var CHKGROUPKEY = ItsGrid.GetValue('grid1', ItsGrid.$GetRowIndex('grid1'), 'CHKGROUPKEY');

        ItsGrid.Setkey('grid1', 'CHKGROUPKEY', CHKGROUPKEY);

        ItsButton.EventSearch();
    });
}

// 승인취소 버튼
ItsButton.Event('btn_CANCEL_COMCHK').onClick = function () {
    if (!ItsGrid.HasChecked('grid2')) {
        ItsMsg.Alert('취소할 품목을 선택하세요.');
        return;
    }

    ItsMsg.Confirm("※ 주의 ※\n- 실사승인 전으로 전산재고가 돌아갑니다.\n- 실사수량도 입력 전으로 초기화됩니다.\n\n취소를 하시겠습니까?", function () {
        var CHKGROUPKEY = ItsGrid.GetValue('grid1', ItsGrid.$GetRowIndex('grid1'), 'CHKGROUPKEY');
        var maria = new ItsMaria('LOT1003_R01', 'COMCHK_CANCEL');

        for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
            if (ItsGrid.IsChecked('grid2', i)) {
                maria.AddList('CHKKEYLIST', ItsGrid.GetValue('grid2', i, 'CHKKEY'));
            }
        }
        maria.AddParam('CHKGROUPKEY', CHKGROUPKEY);

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.Setkey('grid1', 'CHKGROUPKEY', CHKGROUPKEY);

        ItsButton.EventSearch();
    });
}
