//불량코드정보
/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('공정', 'PRCCD', { width: 120, columnType: enumColumnTypes.combo, gpcd: 'PRCCD', readOnly: false }),
        column.create('불량유형', 'BADTP', { width: 120, columnType: enumColumnTypes.combo, gpcd: 'BADTP', readOnly: false }),        
        column.create('불량코드', 'BADCD', { width: 100 }),
        column.create('불량명', 'BADNM', { width: 300, readOnly: false }),
        column.create('순번', 'SORTNO', { width: 60, readOnly: false, columnType: enumColumnTypes.number }),        
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.split()
    ]);
    ItsButton.EventSearch();
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R02', 'LIST_MSTBAD');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('MAJORYN'));

};


/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
        function () {
            var cnt = 0;
            for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
                if (ItsGrid.IsChecked('grid1', i)) {
                    var maria = new ItsMaria('MST0001_R02', 'DEL_MSTBAD');
                    maria.AddParam('BADCD', ItsGrid.GetValue('grid1', i, 'BADCD'));
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
            var maria = new ItsMaria('MST0001_R02', 'UP_MSTBAD');
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
    ItsButton.EventSearch();
}

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
}

/* 추가 저장*/
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('MST0001_R02', 'ADD_MSTBAD');
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

