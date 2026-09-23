/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('비가동코드', 'NONCD', { width: 100 }),
        column.create('비가동명', 'NONNM', { width: 180, readOnly: false }),
        column.create('비가동유형', 'NONTP', { width: 120, columnType: enumColumnTypes.combo, gpcd: 'NONTP', readOnly: false }),
        column.create('순번', 'SORTNO', { width: 60, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('사용여부', 'USEYN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        //column.create('고장여부', 'BADYN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        //column.create('계획여부', 'PLANYN', { width: 80, readOnly: false, columnType: enumColumnTypes.check }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.split()
    ]);

};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R13', 'LIST_MSTNON');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN').YnToBool('BADYN').YnToBool('PLANYN'));
};


/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
        function () {
            var cnt = 0;
            for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
                if (ItsGrid.IsChecked('grid1', i)) {
                    var maria = new ItsMaria('MST0001_R13', 'DEL_MSTNON');
                    maria.AddParam('NONCD', ItsGrid.GetValue('grid1', i, 'NONCD'));
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
            var maria = new ItsMaria('MST0001_R13', 'UP_MSTNON');
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
    var maria = new ItsMaria('MST0001_R13', 'ADD_MSTNON');
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

