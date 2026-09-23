
/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isSubTotalGrid: true }, [
        column.create('창고명', 'WARECD', { width: 150, columnType: enumColumnTypes.combo, gpcd: 'WARECD', align: 'center' }),
        column.create('품목유형', 'ITEMTP', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 100 }),
        column.create('재질', 'MATERIAL', { width: 100, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 150 }),
       
        column.create('두께', 'THICK', { width: 100, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('길이', 'LENGTH', { width: 100, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('폭', 'WIDTH', { width: 100, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('재고량', 'LOTQTY', { width: 150, columnType: enumColumnTypes.number, backColor: enumColor.greenLight2, groupType: enumGrouping.sum }),
        column.create("사급자재량", "SUMQTY_OSCMTR", { width: 150, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),     
        column.create('단위', 'UNIT', { width: 50, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('한로트관리', 'ONELOT_YN', { width: 80, readOnly: true, columnType: enumColumnTypes.check }),
        column.split()
    ]);

    ItsGrid.Create('grid1_LOTLIST', { isSubTotalGrid: true }, [
        column.create('로트번호', 'LOTKEY', { width: 120, align: 'center' }),
        column.create('로트수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('입고일자', 'PRDDATE', { width: 100, align: 'center' }),
        column.create('사급자재', 'OSCMTR_YN', { width: 80, columnType: enumColumnTypes.check }),
        column.split()
    ]);


    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('품목유형', 'ITEMTP', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP' }),
        column.create('품목코드', 'ITEMCD', { width: 200 }),        
        column.create('품명', 'ITEMNM', { width: 200 }),
        column.create('재질', 'MATERIAL', { width: 100, align: 'center' }),
        column.create('두께', 'THICK', { width: 80, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('길이', 'LENGTH', { width: 80, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('폭', 'WIDTH', { width: 80, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('로트번호', 'LOTKEY', { width: 120, readOnly: false }),
        column.create('입고수량', 'INQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.split()

    ]);
    ItsGrid.Create('grid3', { isSubTotalGrid: true}, [
        column.create('창고명', 'WARECD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'WARECD', align: 'center' }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 200 }),        
        column.create('품명', 'ITEMNM', { width: 200 }),
        column.create('재질', 'MATERIAL', { width: 100, align: 'center' }),
        column.create('두께', 'THICK', { width: 80, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('길이', 'LENGTH', { width: 80, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('폭', 'WIDTH', { width: 80, columnType: enumColumnTypes.number, align: 'center' }),
        column.create('재고량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, backColor: enumColor.greenLight2}),
        column.create("사급자재량", "SUMQTY_OSCMTR", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),     
        column.create('단위', 'UNIT', { width: 50, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
    ]);

    ItsGrid.Create('grid4', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('로트번호', 'LOTKEY', { width: 150, align: 'center' }),
        column.create('로트수량', 'LOTQTY', { width: 150, columnType: enumColumnTypes.number, groupType: enumGrouping.sum  }),
        column.create('출고수량', 'OUTQTY', { width: 100, columnType: enumColumnTypes.number, readOnly: false }),
        column.create('사급자재', 'OSCMTR_YN', { width: 80, columnType: enumColumnTypes.check }),

    ]);
 
    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
    ItsFind.SetValue('find_OUT_EMPCD', ItsPage.EMPCD);
    
};
ItsCombo.Event('cmb_ITEMTP').onChanged = function () {
    ItsCombo.SetRef01('find_ITEMCD', ItsCombo.GetValue('cmb_ITEMTP'));
};

/***************************************************************************************************************************************************************************** */
//조회
Comlot_Search = function () {
    if (ItsTab.GetIndex('tab1') == 0) {
        var maria = new ItsMaria('MTR0001_R02', 'LIST_ITEMLIST_IN');

        maria.AddPanel('sdiv1');

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid1', maria.store.YnToBool('ONELOT_YN'));

        ItsGrid.Get('grid1').autoSizeColumns();

        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
    else if (ItsTab.GetIndex('tab1') == 1) {
        var maria = new ItsMaria('MTR0001_R02', 'LIST_ITEMLIST_OUT');

        maria.AddPanel('sdiv1');

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid3', maria.store);

        //ItsGrid.Get('grid2').autoSizeColumns();

        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
}

ItsButton.EventSearch = function () {
    Comlot_Search();
}

ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid1_LOTLIST');
    ItsGrid.Clear('grid2');
    var maria = new ItsMaria('MTR0001_R02', 'LIST_COMLOT');

    maria.AddRecord('grid1', rowIndex);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1_LOTLIST', maria.store.YnToBool('OSCMTR_YN'));
    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
    ItsCombo.SetValue('cmb_INTP', '');
    ItsText.SetValue('txt_REMARK', '');
};

// 재고조정 기타입고 부분
// 행추가버튼
ItsButton.Event('btn_ADD_LINE').onClick = function () {
    var ITEMCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD');
    var ITEMNM = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMNM');
    var ITEMTP = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMTP');
    var MATERIAL = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'MATERIAL');
    var WIDTH = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'WIDTH');
    var LENGTH = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'LENGTH');
    var THICK = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'THICK');
    var ONELOT_YN = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ONELOT_YN');
    var LOTKEY = ItsGrid.GetValue('grid1_LOTLIST', ItsGrid.GetCurrentIndex('grid1_LOTLIST'), 'LOTKEY');
    if (ITEMCD == '' || ITEMCD == null || ITEMCD == undefined) {
        return;
    }
 
    if (ONELOT_YN == 'Y' || ONELOT_YN == true) {  // 한로트 관리일경우 행이 하나만 나오도록
        var row = ItsGrid.AddRow('grid2');

        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMCD', ITEMCD);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMNM', ITEMNM);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMTP', ITEMTP);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'MATERIAL', MATERIAL);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'WIDTH', WIDTH);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'LENGTH', LENGTH);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'THICK', THICK);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'LOTKEY', LOTKEY);
        if (ItsGrid.Length('grid2') >= 1) {

            return;
        }
    }
    else {
        var row = ItsGrid.AddRow('grid2');
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMCD', ITEMCD);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMNM', ITEMNM);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMTP', ITEMTP);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'MATERIAL', MATERIAL);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'WIDTH', WIDTH);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'LENGTH', LENGTH);
        ItsGrid.SetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'THICK', THICK);
    }

}

// grid2  에서 lotkey 수정부분 한로트일경우 수정 못함
ItsGrid.Event('grid2').onChanged = function (rowIndex, field) {

    var ONELOT_YN = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ONELOT_YN');
    var OLDVALUE = ItsGrid.GetValue('grid1_LOTLIST', ItsGrid.GetCurrentIndex('grid1_LOTLIST'), 'LOTKEY');

    if (ONELOT_YN == 'Y' || ONELOT_YN == true) {

        ItsGrid.SetValue('grid2', rowIndex, 'LOTKEY', OLDVALUE);
       
    }

}

// 기타입고 등록 
ItsButton.Event('btn_IN_COMLOT').onClick = function () {
    var cnt = 0;
    var maria = new ItsMaria('MTR0001_R02', 'IO_ETC_IN');

    maria.AddParam('WARECD', ItsFind.GetValue('find_WARECD'));
    maria.AddParam('INDATE', ItsDate.GetValue('date_INDATE'));
    maria.AddParam('INTP', ItsCombo.GetValue('cmb_INTP'));
    maria.AddParam('CUSTCD', ItsFind.GetValue('find_CUSTCD_IN'));
    maria.AddParam('EMPCD', ItsFind.GetValue('find_EMPCD'));
    maria.AddParam('REMARK', ItsText.GetValue('txt_REMARK'));

    
    
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            if (ItsGrid.GetValue('grid2', i, 'INQTY') == '') {
                ItsMsg.Alert('입고수량을 입력하세요.');
                return;
            }

            maria.AddList('ITEMCDLIST', ItsGrid.GetValue('grid2', i, 'ITEMCD'));
            maria.AddList('LOTKEYLIST', ItsGrid.GetValue('grid2', i, 'LOTKEY'));
            maria.AddList('INQTYLIST', ItsGrid.GetValue('grid2', i, 'INQTY'));
            cnt++;
        }
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.UnCheckAll('grid2');

    ItsMsg.Toast(ItsMsg.CommonMsg.DisposeComplete(cnt));

    var ITEMCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD')

    ItsGrid.Setkey('grid1', 'ITEMCD', ITEMCD);
    ItsButton.EventSearch();    

    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
    ItsCombo.SetValue('cmb_INTP', '');
    ItsText.SetValue('txt_REMARK', '');
}


//재고조정 기타출고 부분
ItsGrid.Event('grid3').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid4');

    var maria = new ItsMaria('MTR0001_R02', 'LIST_COMLOT');

    maria.AddRecord('grid3', rowIndex);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid4', maria.store.YnToBool('OSCMTR_YN'));
    ItsFind.SetValue('find_OUT_EMPCD', ItsPage.EMPCD);
    ItsCombo.SetValue('cmb_OUTTP', '');
    ItsText.SetValue('txt_OUT_REMARK', '');
};

// grid3  에서 lotkey 수정부분 만약 LOTKEY 보다 숫자가 클경우 못들어가도록, 그리고 0 은 못들어가도록
ItsGrid.Event('grid4').onChanged = function (rowIndex, field) {

    var LOTQTY = ItsGrid.GetValue('grid4', rowIndex, 'LOTQTY');
    var OUTQTY = ItsGrid.GetValue('grid4', rowIndex, 'OUTQTY');

    if (LOTQTY < OUTQTY || OUTQTY === 0) {

        ItsGrid.SetValue('grid4', rowIndex, 'OUTQTY', '');
        ItsGrid.UnCheckRow('grid4', rowIndex);
        return;
    }

}

//기타출고 등록
ItsButton.Event('btn_OUT_COMLOT').onClick = function () {
    var cnt = 0;
    var maria = new ItsMaria('MTR0001_R02', 'IO_ETC_OUT');
    maria.AddParam('WARECD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'WARECD'));
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'ITEMCD'));
    maria.AddParam('OUTDATE', ItsDate.GetValue('date_OUTDATE'));
    maria.AddParam('OUTTP', ItsCombo.GetValue('cmb_OUTTP'));
    maria.AddParam('EMPCD', ItsFind.GetValue('find_OUT_EMPCD'));
    maria.AddParam('REMARK', ItsText.GetValue('txt_OUT_REMARK'));



    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        if (ItsGrid.IsChecked('grid4', i)) {
            if (ItsGrid.GetValue('grid4', i, 'OUTQTY') == '') {
                ItsMsg.Alert('출고수량을 입력하세요.');
                return;
            }

            maria.AddList('LOTKEYLIST', ItsGrid.GetValue('grid4', i, 'LOTKEY'));
            maria.AddList('OUTQTYLIST', ItsGrid.GetValue('grid4', i, 'OUTQTY'));
            cnt++;
        }
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.UnCheckAll('grid4');

    ItsMsg.Toast(ItsMsg.CommonMsg.DisposeComplete(cnt));

    var ITEMCD = ItsGrid.GetValue('grid3', ItsGrid.GetCurrentIndex('grid3'), 'ITEMCD')

    ItsGrid.Setkey('grid3', 'ITEMCD', ITEMCD);

    ItsButton.EventSearch();
    
    ItsFind.SetValue('find_OUT_EMPCD', ItsPage.EMPCD);
    ItsCombo.SetValue('cmb_OUTTP', '');
    ItsText.SetValue('txt_OUT_REMARK', '');
}

ItsCombo.Event('cmb_INTP').onChanged = function (value, oldValue) {
    if (value == '07') {
        ItsFind.Show('find_CUSTCD_IN');        
    }
    else {
        ItsFind.Hide('find_CUSTCD_IN');        
    }

    ItsFind.SetValue('find_CUSTCD_IN', '');
}