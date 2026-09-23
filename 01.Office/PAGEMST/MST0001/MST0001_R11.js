//검사항목정보
/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    // 공정검사 그룹
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("검사유형", "STDTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDTP', readOnly: false, align: 'center' }),
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200, readOnly: false }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', readOnly: false, align: 'center' }),
        column.create("값유형", "STDVALTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDVALTP', readOnly: false, align: 'center' }),
        column.create("단위", "STDUNIT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', readOnly: false, align: 'center' }),
        column.create("범위", "STDRANGE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', readOnly: false, align: 'center' }),

        column.create("비고", "REMARK", { width: 100, readOnly: false }),

        column.split()
    ]);


    // 그리드 Row 높이 자동설정
    //ItsGrid.Get('grid1').autoRowHeights = true;
    ItsCombo.SetValue('cmb_STDTP', 'OUTTEST');
   
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('MST0001_R11', 'LIST_MSTSTD');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    //ItsGrid.Get('grid1').autoSizeColumns();

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');


};
/*********************************************************************************************************************************************************************************/
///* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop_ADD_MSTSTD');
    ItsCombo.SetValue('cmb_STDTP_ADD', 'OUTTEST'); // 팝업창
}

///* 추가 저장*/
ItsPop.Event('pop_ADD_MSTSTD').onAddBtnClick = function () {
    var maria = new ItsMaria('MST0001_R11', 'ADD_MSTSTD');

    maria.AddPanel('pdiv1');

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop_ADD_MSTSTD');

    ItsButton.EventSearch();
}

ItsPop.Event('pop_ADD_MSTSTD').onCancelBtnClick = function () {
    ItsPop.Close('pop_ADD_MSTSTD');
}

///*********************************************************************************************************************************************************************************/
/* 저장 */
ItsButton.EventSave = function () {
    var cnt = 0;

    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('MST0001_R11', 'UPDATE_MSTSTD');

            maria.AddRecord('grid1', i);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
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
///*********************************************************************************************************************************************************************************/
/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
        function () {
            var cnt = 0;
            for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
                if (ItsGrid.IsChecked('grid1', i)) {
                    var maria = new ItsMaria('MST0001_R11', 'DELETE_MSTSTD');

                    maria.AddRecord('grid1', i);

                    maria.CallProc();
                    if (maria.isError) {
                        maria.ShowErrMsg();
                        return;
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
///*********************************************************************************************************************************************************************************/





