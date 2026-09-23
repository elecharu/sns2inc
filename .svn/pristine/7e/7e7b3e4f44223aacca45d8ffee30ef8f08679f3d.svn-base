/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', {}, [
        column.create("권한코드", "AUTCD", { width: 80 }),
        column.create("권한명", "AUTNM", { width: 100, readOnly: false }),
        column.create("정렬순서", "SORTNO", { width: 55, readOnly: false, columnType: enumColumnTypes.number }),
        //column.create("승인권한", "CONFIRMYN", { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        //column.create("원가권한", "COSTYN", { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        column.create("비고", "REMARK", { width: 100, readOnly: false }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true, isSubTotalGrid: true, groupField: 'PKGTP' }, [
        column.create("패키지", "PKGTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PKGTP', allowMerging: true }),
        //column.create("카테고리", "CATENM", { width: 100, allowMerging: true, allowMerging: true }),
        column.create("프로그램코드", "PRGCD", { width: 100, align: 'center' }),
        column.create("프로그램명", "PRGNM", { width: 160 }),
        // 사내
            column.create('조회', 'SEARCHYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('출력', 'PRINTYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('내보내기', 'EXPORTYN', { width: 80, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('추가', 'ADDYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('저장', 'SAVEYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('삭제', 'DELETEYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
        // 사외
            //column.create('조회', 'SEARCHYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('출력', 'PRINTYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('내보내기', 'EXPORTYN_OUT', { width: 80, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('추가', 'ADDYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('저장', 'SAVEYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('삭제', 'DELETEYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        column.create("비고", "REMARK", { width: 150, readOnly: false }),
        column.split()
    ]);

    ItsGrid.Create('grid4', {}, [
        column.create("패키지", "PKGTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PKGTP' }),
        column.band('사내권한', {}, [
            column.create('조회', 'SEARCHYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('출력', 'PRINTYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('내보내기', 'EXPORTYN', { width: 80, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('추가', 'ADDYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('저장', 'SAVEYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('삭제', 'DELETEYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
        ]),
        //column.band('사외권한', {}, [
        //    column.create('조회', 'SEARCHYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        //    column.create('출력', 'PRINTYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        //    column.create('내보내기', 'EXPORTYN_OUT', { width: 80, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        //    column.create('추가', 'ADDYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        //    column.create('저장', 'SAVEYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        //    column.create('삭제', 'DELETEYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        //]),
        column.split()
    ]);

    $('#INSIDE').parent().css('background-color', enumColor.redLight2);
    $('#OUTSIDE').parent().css('background-color', enumColor.yellowLight2);

};

var initState = true;

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS0001_R06', 'LIST_SYSAUT');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};


ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    var ischange2 = false;
    //var ischange3 = false;

    //for (var i = 0; i < ItsGrid.Length('grid2') ; i++) {
    //    if (ItsGrid.IsChecked('grid2', i))
    //        ischange2 = true;
    //}
    //for (var i = 0; i < ItsGrid.Length('grid3') ; i++) {
    //    if (ItsGrid.IsChecked('grid3', i))
    //        ischange3 = true;
    //}

    if (ischange2) {
        ItsMsg.Confirm("수정된 권한이 있습니다. 저장하시겠습니까?", function () {
            if (ischange2)
                save_PRG();
            update_PRG(rowIndex);
        })
    }
    else
        update_PRG(rowIndex);

}

save_PRG = function () {
    var rowindex = ItsGrid.GetCurrentIndex('grid1');
    var gridID = 'grid2';
    var cnt = 0;
    var maria = new ItsMaria('SYS0001_R06', 'UP_SYSAUTPRG');
    maria.AddPanel('sdiv1');
    maria.AddParam('AUTCD', ItsGrid.GetValue('grid1', rowindex, 'AUTCD'));
    maria.AddParam('INOUTTP', ItsGrid.GetValue('grid1', rowindex, 'INOUTTP'));
    for (var i = 0; i < ItsGrid.Length(gridID) ; i++) {
        if (ItsGrid.IsChecked(gridID, i)) {
            maria.AddList('PRGCD_LIST', ItsGrid.GetValue(gridID, i, 'PRGCD'));
            maria.AddList('SEARCHYN_LIST', ItsGrid.GetValue(gridID, i, 'SEARCHYN', false));
            maria.AddList('PRINTYN_LIST', ItsGrid.GetValue(gridID, i, 'PRINTYN', false));
            maria.AddList('EXPORTYN_LIST', ItsGrid.GetValue(gridID, i, 'EXPORTYN', false));
            maria.AddList('ADDYN_LIST', ItsGrid.GetValue(gridID, i, 'ADDYN', false));
            maria.AddList('SAVEYN_LIST', ItsGrid.GetValue(gridID, i, 'SAVEYN', false));
            maria.AddList('DELETEYN_LIST', ItsGrid.GetValue(gridID, i, 'DELETEYN', false));
            maria.AddList('REMARK_LIST', ItsGrid.GetValue(gridID, i, 'REMARK'));

            maria.AddList('SEARCHYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'SEARCHYN_OUT', false));
            maria.AddList('PRINTYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'PRINTYN_OUT', false));
            maria.AddList('EXPORTYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'EXPORTYN_OUT', false));
            maria.AddList('ADDYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'ADDYN_OUT', false));
            maria.AddList('SAVEYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'SAVEYN_OUT', false));
            maria.AddList('DELETEYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'DELETEYN_OUT', false));
            cnt++;
        }
    }

    if (cnt > 0) {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return 0;
        }
    }
    ItsGrid.Setkey('grid1', 'AUTCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'AUTCD'));
    ItsButton.EventSearch();
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
}

function update_PRG(rowIndex) {
    var maria = new ItsMaria('SYS0001_R06', 'LIST_SYSAUTPRGD');
    maria.AddPanel('sdiv1');
    maria.AddParam('AUTCD', ItsGrid.GetValue('grid1', rowIndex, 'AUTCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store.YnToBool('SEARCHYN').YnToBool('ADDYN').YnToBool('PRINTYN').YnToBool('EXPORTYN').YnToBool('SAVEYN').YnToBool('DELETEYN').
                              YnToBool('SEARCHYN_OUT').YnToBool('ADDYN_OUT').YnToBool('PRINTYN_OUT').YnToBool('EXPORTYN_OUT').YnToBool('SAVEYN_OUT').YnToBool('DELETEYN_OUT'));

}

/* 저장 */
ItsButton.EventSave = function () {
    var maria = new ItsMaria('SYS0001_R06', 'UP_SYSAUT');
    maria.AddPanel('sdiv1');
    maria.AddRecord('grid1', ItsGrid.GetCurrentIndex('grid1'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    save_PRG();
};

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('선택한 항목을 삭제 하시겠습니까?', function () {
        var maria = new ItsMaria('SYS0001_R06', 'DEL_SYSAUT');
        maria.AddRecord('grid1', ItsGrid.GetCurrentIndex('grid1'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsButton.EventSearch();
    });
};

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    var maria = new ItsMaria('SYS0001_R06', 'LIST_PKGTP');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid4', maria.store);
    ItsPop.Open('pop1');
}

ItsPop.Event('pop1').onAddBtnClick = function () {

    var maria = new ItsMaria('SYS0001_R06', 'ADD_SYSAUT');
    maria.AddPanel('pop1');
    var SEARCHYN = '', SEARCHYN_OUT = '', PRINTYN = '', PRINTYN_OUT = '', EXPORTYN = '', EXPORTYN_OUT = '', ADDYN = '', ADDYN_OUT = '',
        SAVEYN = '', SAVEYN_OUT = '', DELETEYN = '', DELETEYN_OUT = ''
    for (var i = 0; i < ItsGrid.Length('grid4') ; i++) {
        if (ItsGrid.GetValue('grid4', i, 'SEARCHYN'))
            SEARCHYN = SEARCHYN + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'SEARCHYN_OUT'))
            SEARCHYN_OUT = SEARCHYN_OUT + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'PRINTYN'))
            PRINTYN = PRINTYN + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'PRINTYN_OUT'))
            PRINTYN_OUT = PRINTYN_OUT + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'EXPORTYN'))
            EXPORTYN = EXPORTYN + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'EXPORTYN_OUT'))
            EXPORTYN_OUT = EXPORTYN_OUT + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'ADDYN'))
            ADDYN = ADDYN + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'ADDYN_OUT'))
            ADDYN_OUT = ADDYN_OUT + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'SAVEYN'))
            SAVEYN = SAVEYN + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'SAVEYN_OUT'))
            SAVEYN_OUT = SAVEYN_OUT + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'DELETEYN'))
            DELETEYN = DELETEYN + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
        if (ItsGrid.GetValue('grid4', i, 'DELETEYN_OUT'))
            DELETEYN_OUT = DELETEYN_OUT + ItsGrid.GetValue('grid4', i, 'PKGTP') + ',';
    }

    maria.AddParam('SEARCHYN', SEARCHYN);
    maria.AddParam('SEARCHYN_OUT', SEARCHYN_OUT);
    maria.AddParam('PRINTYN', PRINTYN);
    maria.AddParam('PRINTYN_OUT', PRINTYN_OUT);
    maria.AddParam('EXPORTYN', EXPORTYN);
    maria.AddParam('EXPORTYN_OUT', EXPORTYN_OUT);
    maria.AddParam('ADDYN', ADDYN);
    maria.AddParam('ADDYN_OUT', ADDYN_OUT);
    maria.AddParam('SAVEYN', SAVEYN);
    maria.AddParam('SAVEYN_OUT', SAVEYN_OUT);
    maria.AddParam('DELETEYN', DELETEYN);
    maria.AddParam('DELETEYN_OUT', DELETEYN_OUT);

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop1');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsGrid.Setkey('grid1', 'AUTCD', ItsText.GetValue('txt_AUTCD'));
    ItsButton.EventSearch();
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPage.InitData('pop1');
    ItsPop.Close('pop1');
};