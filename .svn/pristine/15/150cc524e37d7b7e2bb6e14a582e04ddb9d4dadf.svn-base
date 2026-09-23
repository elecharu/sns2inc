//공정정보


/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('공정코드', 'PRCCD', { width: 100 }),
        column.create('공정명', 'PRCNM', { width: 120, readOnly: false }),
        column.create('순번', 'SORTNO', { width: 60, columnType: enumColumnTypes.number, readOnly: false }),

        column.create('공정유형', 'PRCTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PRCTP', readOnly: false, align: 'center' }),
        column.create('사용여부', 'USEYN', { width: 80, columnType: enumColumnTypes.check, readOnly: false }),
        
        column.create('비고', 'REMARK', { width: 120, readOnly: false }),
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R05', 'LIST_MSTPRC');
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
                    var maria = new ItsMaria('MST0001_R05', 'DEL_MSTPRC');
                    maria.AddParam('PRCCD', ItsGrid.GetValue('grid1', i, 'PRCCD'));
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
            var maria = new ItsMaria('MST0001_R05', 'UP_MSTPRC');
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
    ItsButton.EventSearch();
}

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
}

/* 추가 저장*/
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('MST0001_R05', 'ADD_MSTPRC');
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

