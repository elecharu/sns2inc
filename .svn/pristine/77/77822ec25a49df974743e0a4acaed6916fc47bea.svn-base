//창고정보
/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsPop.LoadFindPopCOM();
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('창고코드', 'WARECD', { width: 80 }),
        column.create('창고명', 'WARENM', { width: 100, readOnly: false }),
        column.create('순번', 'SORTNO', { width: 60, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('창고유형', 'WARETP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'WARETP', readOnly: false }),
        column.create('사용여부', 'USEYN', { width: 70, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.split()
    ]);

};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R06', 'LIST_MSTWARE');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};


/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
        function () {
            var cnt = 0;
            for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
                if (ItsGrid.IsChecked('grid1', i)) {
                    var maria = new ItsMaria('MST0001_R06', 'DEL_MSTWARE');
                    maria.AddParam('WARECD', ItsGrid.GetValue('grid1', i, 'WARECD'));
                    maria.CallProc();
                    if (maria.isError) {
                        maria.ShowErrMsg();
                    }
                    else {
                        ItsGrid.UnCheckRow('grid1', i);
                        cnt++;
                    }
                }
            }
            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(cnt));
            ItsButton.EventSearch();
        }
    );
}

/* 수정 저장 */
ItsButton.EventSave = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('MST0001_R06', 'UP_MSTWARE');
            maria.AddRecord('grid1', i);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
            }
            else {
                ItsGrid.UnCheckRow('grid1', i);
                cnt++;
            }
        }
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
}

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
}

/* 추가 저장*/
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('MST0001_R06', 'ADD_MSTWARE');
    maria.AddPanel('pdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop1');
    ItsButton.EventSearch();
}

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
}


ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid1').onKeydownEnter(rowIndex, field);
}

//ItsGrid.Event('grid1').onKeydownEnter = function (rowIndex, field) {
//    if (field == 'EMPNM') {
//        ItsPop.OpenFindCOM({ gpcd: 'EMPCD_DEPTP' }, function (res) {
//            ItsGrid.SetValue('grid1', rowIndex, 'EMPCD', res['CODE']);
//            ItsGrid.SetValue('grid1', rowIndex, 'EMPNM', res['NAME']);
//            ItsGrid.SetValue('grid1', rowIndex, 'DEPTP', res['REF01']);
//            ItsGrid.SetValue('grid1', rowIndex, 'DEPTPNM', res['REF02']);
//            ItsGrid.CheckRow('grid1', rowIndex);
//        });
//    } else if (field == 'CUSTNM') {
//        ItsPop.OpenFindCOM({ gpcd: 'CUSTCD' }, function (res) {
//            ItsGrid.SetValue('grid1', rowIndex, 'CUSTCD', res['CODE']);
//            ItsGrid.SetValue('grid1', rowIndex, 'CUSTNM', res['NAME']);
//            ItsGrid.CheckRow('grid1', rowIndex);
//        });
//    } else {
//        return;
//    }
//}