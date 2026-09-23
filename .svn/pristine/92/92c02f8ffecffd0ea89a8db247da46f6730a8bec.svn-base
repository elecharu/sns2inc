//검사기준정보

/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', {}, [
        column.create('등록여부', 'MSTSTDD_YN', { width: 50, columnType: enumColumnTypes.check }),
        column.create('품목코드', 'ITEMCD', { width: 100, hidden: true }),
        column.create('품목유형', 'ITEMTP', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create('품번', 'ITEMNUM', { width: 200 }),
        column.create('품명', 'ITEMNM', { width: 230 }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true  }, [
        column.create('검사유형', 'STDTP', { width: 100 }),
        column.create('품목코드', 'STDCD', { width: 120, hidden: true }),
        column.create('검사항목', 'STDNM', { width: 120,  readOnly: false }),
        column.create('검사방법', 'STDCHKTP', { width: 80 }),
        column.create('값유형', 'STDVALTP', { width: 80 }),
        column.create('기준값1', 'STDVAL1', { width: 70, align: 'center', readOnly: false }),
        column.create('범위', 'STDRANGE', { width: 60}),
        column.create('기준값2', 'STDVAL2', { width: 70, align: 'center', readOnly: false }),
        column.create('단위', 'STDUNIT', { width: 60}),
        column.create('비고', 'REMARK', { width: 100, readOnly: false }),
        column.split()
    ]);

   
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R12', 'LIST_MSTSTD');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('MSTSTDD_YN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};
/* 그리드 1 선택후 */
ItsGrid.Event('grid1').onSelect = function () {
    var maria = new ItsMaria('MST0001_R12', 'LIST_MSTSTDD');

    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);


}
/* 추가 */
ItsButton.EventAdd = function () {
    var indx = ItsGrid.Length('grid2');
    var itemCode = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD');

    if (itemCode === undefined) {
        ItsMsg.Toast("품목조회를 먼저하세요.");
        return;
    }
    // indx가 0일 때만 추가 가능
    
    ItsGrid.AddRow('grid2', indx);
    ItsGrid.CheckRow('grid2', indx);
    
}
/***********************************************************************************************************************************/
ItsGrid.Event('grid2').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid2').onKeydownEnter(rowIndex, field);
}

ItsGrid.Event('grid2').onKeydownEnter = function (rowIndex, field) {
    if (field == 'STDNM') {
    

        // 품목코드 팝업 (자재창고 > 자재,부자재, 외주서브품창고 > 서브품)
        ItsPop.OpenFindCOM({
            gpcd: 'STDCD',
        }
            , function (res) {
                ItsGrid.SetValue('grid2', rowIndex, 'STDTP', res['CODE']);
                ItsGrid.SetValue('grid2', rowIndex, 'STDCD', res['NAME']);
                ItsGrid.SetValue('grid2', rowIndex, 'STDNM', res['REF01']);
                ItsGrid.SetValue('grid2', rowIndex, 'STDCHKTP', res['REF02']);
                ItsGrid.SetValue('grid2', rowIndex, 'STDVALTP', res['REF03']);
                ItsGrid.SetValue('grid2', rowIndex, 'STDRANGE', res['REF05']);
                ItsGrid.SetValue('grid2', rowIndex, 'STDUNIT', res['REF04']);

                ItsGrid.CheckRow('grid2', rowIndex);
            });
    }
}
/* 저장, 수정*/
ItsButton.EventSave = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {

            var maria = new ItsMaria('MST0001_R12', 'SAVE_MSTSTDD');

            maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));

            maria.AddParam('STDCD', ItsGrid.GetValue('grid2', i, 'STDCD'));
            maria.AddParam('STDVAL1', ItsGrid.GetValue('grid2', i, 'STDVAL1'));
            maria.AddParam('STDVAL2', ItsGrid.GetValue('grid2', i, 'STDVAL2'));
            maria.AddParam('REMARK', ItsGrid.GetValue('grid2', i, 'REMARK'));

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            else {
                ItsGrid.UnCheckRow('grid2', i);
                cnt++;
            }

        }

    }
    var current_index = ItsGrid.$GetRowIndex('grid1');

    ItsButton.EventSearch();

    ItsGrid.SelectRow('grid1', current_index);

}

//삭제
ItsButton.EventDelete = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {

            var maria = new ItsMaria('MST0001_R12', 'DELETE_MSTSTDD');

            maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
            maria.AddParam('STDCD', ItsGrid.GetValue('grid2', i, 'STDCD'));
            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            else {
                ItsGrid.UnCheckRow('grid2', i);
                cnt++;
            }

        }

    }
    var current_index = ItsGrid.$GetRowIndex('grid1');

    ItsButton.EventSearch();

    ItsGrid.SelectRow('grid1', current_index);
}