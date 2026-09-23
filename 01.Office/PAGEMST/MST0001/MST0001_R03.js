//작업장정보
/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('라인코드', 'LINECD', { width: 200 }),
        column.create('라인명', 'LINENM', { width: 250, readOnly: false }),
        column.create('작업장', 'WORKPLACE', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'WPCD', align: 'center', readOnly: false }),
        column.create('순번', 'SORTNO', { width: 60, readOnly: false, columnType: enumColumnTypes.number }),
        column.create('사용여부', 'USEYN', { width: 70, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),
        column.split()
    ]);
    ItsButton.EventSearch();
};

/*********************************************************************************************************************************************************** */
/* 조회 */
ItsButton.EventSearch = function () {
  
    var maria = new ItsMaria('MST0001_R03', 'LIST_MSTLINE');
    maria.AddPanel('sdiv1');
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
}

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
}

ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('MST0001_R03', 'ADD_MSTLINE');
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

/* 수정 저장 */
ItsButton.EventSave = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('MST0001_R03', 'UP_MSTLINE');
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

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
        function () {
            var cnt = 0;
            for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
                if (ItsGrid.IsChecked('grid1', i)) {
                    var maria = new ItsMaria('MST0001_R03', 'DEL_MSTLINE');
                    maria.AddParam('LINECD', ItsGrid.GetValue('grid1', i, 'LINECD'));
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