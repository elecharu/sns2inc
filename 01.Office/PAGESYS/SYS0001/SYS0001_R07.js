/// <reference path="../../Script/reference.js" />

//var Tabstate;
var AUTCH = false;
var USERCH = false;

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', {}, [
        column.create("사용자ID", "USERID", { width: 100 }),
        column.create('사원명', 'EMPCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true, isSubTotalGrid: true, groupField: 'PKGTP', allowMerging: 'Cells' }, [
        column.create("패키지", "PKGTP", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'PKGTP', allowMerging: true }),

        column.create("프로그램코드", "PRGCD", { width: 100, align: 'center' }),
        column.create("프로그램명", "PRGNM", { width: 180 }),
        //column.band('사내권한', {}, [
            column.create('조회', 'SEARCHYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('출력', 'PRINTYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('내보내기', 'EXPORTYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('추가', 'ADDYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('저장', 'SAVEYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('삭제', 'DELETEYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
        //]),
        //column.band('사외권한', {}, [
            //column.create('조회', 'SEARCHYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('출력', 'PRINTYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('내보내기', 'EXPORTYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('추가', 'ADDYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('저장', 'SAVEYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('삭제', 'DELETEYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        //]),
        column.split()
    ]);

    ItsGrid.Create('grid3', {}, [
        column.create("직무코드", "AUTCD", { width: 70 }),
        column.create("직무명", "AUTNM", { width: 100 }),
        column.create("선택", "USEYN", { width: 50, columnType: enumColumnTypes.check, readOnly: false }),
        //column.create("선택", "CHECK", { width: 60, columnType: enumColumnTypes.check, readOnly: false }),
        //column.create("승인권한", "CONFIRMYN", { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        //column.create("원가권한", "COSTYN", { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        //column.create("비고", "REMARK", { width: 150, readOnly: false }),
    ]);

    ItsGrid.Create('grid4', {}, [
        column.create("패키지", "PKGTP", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'PKGTP' }),
        column.band('사내권한', {}, [
            column.create('조회', 'SEARCHYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('출력', 'PRINTYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('내보내기', 'EXPORTYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('추가', 'ADDYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('저장', 'SAVEYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
            column.create('삭제', 'DELETEYN', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.redLight2 }),
        ]),
        column.band('사외권한', {}, [
            //column.create('조회', 'SEARCHYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('출력', 'PRINTYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('내보내기', 'EXPORTYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('추가', 'ADDYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('저장', 'SAVEYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
            //column.create('삭제', 'DELETEYN_OUT', { width: 60, readOnly: false, columnType: enumColumnTypes.check, backColor: enumColor.yellowLight2 }),
        ]),
        column.split()
    ]);

    $('#INSIDE').parent().css('background-color', enumColor.redLight2);
    $('#OUTSIDE').parent().css('background-color', enumColor.yellowLight2);
    $('#txt_RESET').parent().css('color', enumColor.red);

    ItsGrid.SetGroupField('grid2', 'PKGTP', true);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS0001_R07', 'LIST_SYSUSER');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);

    AUTCH = false;
    USERCH = false;
};


/* 21.02.15 기존 프로툴 코드(개인권한 하나라도 수정 후 다른 영역 클릭 시 CONFIRM 메시지 발생) -> 윤영에서는 기능동작 안하도록 설정 */
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {

    //var ischange2 = false;

    //if (ischange2) {
    //    ItsMsg.Confirm("수정된 권한이 있습니다. 저장하시겠습니까?", function () {
    //        if (ischange2)
    //            save_PRG('grid2');
    //        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    //        update_PRG(rowIndex);

    //    }, function () {
    //        update_PRG(rowIndex);
    //    })
    //}
    //else
    update_PRG(rowIndex);
}

function update_PRG(rowIndex) {
    var maria = new ItsMaria('SYS0001_R07', 'LIST_SYSAUTPRGUSER');
    maria.AddPanel('sdiv1');
    maria.AddRecord('grid1', rowIndex);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid3', maria.store.YnToBool('USEYN'));
    ItsGrid.SetStore('grid2', maria.storeExtend1.YnToBool('SEARCHYN').YnToBool('ADDYN').YnToBool('PRINTYN').YnToBool('EXPORTYN').YnToBool('SAVEYN').YnToBool('DELETEYN').
                              YnToBool('SEARCHYN_OUT').YnToBool('ADDYN_OUT').YnToBool('PRINTYN_OUT').YnToBool('EXPORTYN_OUT').YnToBool('SAVEYN_OUT').YnToBool('DELETEYN_OUT'));

    ItsGrid.Get('grid2').collectionView.sortDescriptions.clear();
}

save_PRG = function (gridID) {
    var maria = new ItsMaria('SYS0001_R07', 'UP_SYSUSERAUTGRP');
    maria.AddPanel('sdiv1');
    maria.AddParam('USERID', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'USERID'));
    for (var i = 0; i < ItsGrid.Length(gridID) ; i++) {
        maria.AddList('AUTCD_LIST', ItsGrid.GetValue(gridID, i, 'AUTCD'));
        maria.AddList('USEYN_LIST', ItsGrid.GetValue(gridID, i, 'USEYN', false));
    }
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
}


/* 저장 */
ItsButton.EventSave = function () {

    //GRID3에 변동사항이 있을 경우(직무권한 USEYN 체크유무로 판단)
    if (AUTCH)
        save_PRG('grid3');

    //GRID2에 변동사항이 있을 경우(개인권한 체크유무로 판단)
    if (USERCH) {
        var maria = new ItsMaria('SYS0001_R07', 'UP_SYSUSERAUTGRP_NEW');
        maria.AddPanel('sdiv1');
        maria.AddParam('USERID', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'USERID'));

        var gridID = 'grid2';
        for (var i = 0; i < ItsGrid.Length(gridID) ; i++) {
            if (ItsGrid.IsChecked(gridID, i)) {
                maria.AddList('PRGCD_LIST', ItsGrid.GetValue(gridID, i, 'PRGCD'));
                maria.AddList('SEARCHYN_LIST', ItsGrid.GetValue(gridID, i, 'SEARCHYN', false));
                maria.AddList('SEARCHYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'SEARCHYN_OUT', false));
                maria.AddList('ADDYN_LIST', ItsGrid.GetValue(gridID, i, 'ADDYN', false));
                maria.AddList('ADDYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'ADDYN_OUT', false));
                maria.AddList('PRINTYN_LIST', ItsGrid.GetValue(gridID, i, 'PRINTYN', false));
                maria.AddList('PRINTYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'PRINTYN_OUT', false));
                maria.AddList('EXPORTYN_LIST', ItsGrid.GetValue(gridID, i, 'EXPORTYN', false));
                maria.AddList('EXPORTYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'EXPORTYN_OUT', false));
                maria.AddList('SAVEYN_LIST', ItsGrid.GetValue(gridID, i, 'SAVEYN', false));
                maria.AddList('SAVEYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'SAVEYN_OUT', false));
                maria.AddList('DELETEYN_LIST', ItsGrid.GetValue(gridID, i, 'DELETEYN', false));
                maria.AddList('DELETEYN_LIST_OUT', ItsGrid.GetValue(gridID, i, 'DELETEYN_OUT', false));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue(gridID, i, 'REMARK'));
            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
    }
    ItsMsg.Toast('권한이 저장되었습니다');
    ItsGrid.Setkey('grid1', 'USERID', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'USERID'));
    ItsButton.EventSearch();
};


ItsGrid.Event('grid2').onChanged = function (rowIndex, field, newValue, oldValue) {
    USERCH = true;
}

ItsGrid.Event('grid3').onChanged = function (rowIndex, field, newValue, oldValue) {
    if (field == 'USEYN') {
        AUTCH = true;
        var maria = new ItsMaria('SYS0001_R07', 'LIST_SYSAUTPRG');
        maria.AddPanel('sdiv1');

        //권한 선택이 Y일 때 GRID2에 체크된 권한이 표시(여러 개 선택 시 선택한 권한 모두 표시되어야함)
        for (var i = 0; i < ItsGrid.Length('grid3') ; i++) {
            if (ItsGrid.GetValue('grid3', i, 'USEYN', false) == 'Y') {
                maria.AddList('AUTCD_LIST', ItsGrid.GetValue('grid3', i, 'AUTCD'));
            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsGrid.SetStore('grid2', maria.store.YnToBool('SEARCHYN').YnToBool('ADDYN').YnToBool('PRINTYN').YnToBool('EXPORTYN').YnToBool('SAVEYN').YnToBool('DELETEYN').
                                              YnToBool('SEARCHYN_OUT').YnToBool('ADDYN_OUT').YnToBool('PRINTYN_OUT').YnToBool('EXPORTYN_OUT').YnToBool('SAVEYN_OUT').YnToBool('DELETEYN_OUT'));
    }

}

