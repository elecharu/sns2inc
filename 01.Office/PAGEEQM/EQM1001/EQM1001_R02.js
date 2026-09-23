/// <reference path="../../Script/reference.js" />

// 정기점검 항목 그리드
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center', readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 130, columnType: enumColumnTypes.combo, gpcd: 'CHKLOC', readOnly: false }),
        column.create('점검명', 'CHKKNDNM', { width: 300, readOnly: false }),

        column.create('점검방법', 'CHKMTH', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', readOnly: false }),
        column.create('점검주기', 'CHKCYCLE', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE', readOnly: false }),
        column.create('점검값구분', 'CHKVALTP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', readOnly: false }),
        column.create('사용여부', 'USEYN', { width: 80, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('비고', 'REMARK', { width: 150, readOnly: false }),

        column.split()
    ]);

};

// 정기점검 항목 조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');

    var maria = new ItsMaria('EQM1001_R02', 'LIST_MSTCHKKND');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store.YnToBool('USEYN'));
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 정기점검 항목 등록 팝업
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1');
    ItsPop.Open('pop1');
};

// 정기점검 항목 추가
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('EQM1001_R02', 'ADD_MSTCHKKND');
    maria.AddPanel('pdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsPop.Close('pop1');
    ItsButton.EventSearch();
};

// 정기점검 항목 등록 취소
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

// 선택한 정기점검 항목 저장
ItsButton.EventSave = function () {
    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택하신 항목을 저장하시겠습니까?', function () {

        var maria = new ItsMaria('EQM1001_R02', 'SAVE_MSTCHKKND');
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid1', i, 'CHKKNDCD'));
                maria.AddList('CHKLOC_LIST', ItsGrid.GetValue('grid1', i, 'CHKLOC'));
                maria.AddList('CHKKNDNM_LIST', ItsGrid.GetValue('grid1', i, 'CHKKNDNM'));
                maria.AddList('CHKCYCLE_LIST', ItsGrid.GetValue('grid1', i, 'CHKCYCLE'));
                maria.AddList('CHKMTH_LIST', ItsGrid.GetValue('grid1', i, 'CHKMTH'));
                maria.AddList('CHKVALTP_LIST', ItsGrid.GetValue('grid1', i, 'CHKVALTP'));
                maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid1', i, 'REMARK'));
                if (ItsGrid.GetValue('grid1', i, 'USEYN', false) == 'Y')
                    maria.AddList('USEYN_LIST', 'Y');
                else
                    maria.AddList('USEYN_LIST', 'N');
            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('저장이 취소되었습니다.');
    });
};

// 선택한 정기점검 항목 삭제
ItsButton.EventDelete = function () {
    var hasChecked = false;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            hasChecked = true;
            break;
        }
    }

    if (!hasChecked) {
        ItsMsg.Toast('선택된 항목이 없습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 항목을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('EQM1001_R02', 'DELETE_MSTCHKKND');
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid1', i, 'CHKKNDCD'));
            }
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        ItsButton.EventSearch();
    }, function () {
        ItsMsg.Toast('삭제가 취소되었습니다.');
    });
};
