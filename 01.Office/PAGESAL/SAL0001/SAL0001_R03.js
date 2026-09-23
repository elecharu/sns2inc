
/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {
    
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true}, [
        column.create('출고키', 'SALOUTKEY', { width: 100, hidden: true, align: 'center' }),

        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center' }),
        //column.create('출고유형', 'SALOUTTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'SALOUTTP'}),
        column.create('거래처코드', 'CUSTCD', { width: 100, align: 'center' }),
        column.create('거래처명', 'CUSTNM', { width: 100, align: 'center'}),
        column.create('품목유형', 'ITEMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ITEMTP' }),
        column.create('품목코드', 'ITEMCD', { width: 150, align: 'center'}),
        column.create('품명', 'ITEMNM', { width: 150, align: 'center'}),
        //column.create('품목규격', 'ITEMSPEC', { width: 150, align: 'center'}),
        column.create('출하창고', 'WARECD', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'WARECD', align:'center' }), ,
        column.create('수주수량', 'OUTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, groupType: enumGrouping.sum }),
        column.create('출고검사대상', 'TQMCHK', { width: 100, columnType: enumColumnTypes.check }),
        column.create('출고검사완료', 'FINISH_OUTTEST_YN', { width: 100, columnType: enumColumnTypes.check }),
        column.create('출고확정', 'SALCHK', { width: 100, columnType: enumColumnTypes.check }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('출고키', 'SALOUTKEY', { width: 100, hidden: true, align: 'center' }),        
        column.create('로트번호', 'LOTKEY', { width: 100, align: 'center' }),
        column.create('로트수량', 'LOTQTY', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('스캔시간', 'SCANTIME', { width: 150, align: 'center' }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('date_SALDATE', ItsHelper.GetYearMonth() + '-01');

    
};

// 출하지시조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('SAL0001_R03', 'LIST_SALOUT');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('TQMCHK').YnToBool('SALCHK').YnToBool('FINISH_OUTTEST_YN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 출하지시 선택시
ItsGrid.Event('grid1').onSelect = function () {
    SCAN_SALOUT();
}

// 출하스캔 리스트 
SCAN_SALOUT = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('SAL0001_R03', 'LIST_SALOUT_SCAN');

    maria.AddParam('SALOUTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALOUTKEY'));
    maria.AddParam('TQMCHK', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'TQMCHK'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
}

//출고확정 버튼
ItsButton.Event('btn_CONFIRM_SALOUT').onClick = function () {
    ItsMsg.Confirm("출고확정하시겠습니까?", function () {
        var maria = new ItsMaria('SAL0001_R03', 'CONFIRM_SALOUT');

        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('SALOUTKEY_LIST', ItsGrid.GetValue('grid1', i, 'SALOUTKEY'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        
        ItsButton.EventSearch();
    });
}


//출고확정취소 버튼
ItsButton.Event('btn_CANCLE_SALOUT').onClick = function () {
    ItsMsg.Confirm("출고확정을 취소하시겠습니까?", function () {
        var maria = new ItsMaria('SAL0001_R03', 'CANCEL_SALOUT');

        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('SALOUTKEY_LIST', ItsGrid.GetValue('grid1', i, 'SALOUTKEY'));
            }
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        
        ItsButton.EventSearch();
    });
}
