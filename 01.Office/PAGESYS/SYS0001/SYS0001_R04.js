/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('사용자ID', 'USERID', { width: 90 }),
        column.create('사원명', 'EMPCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),
        //column.create('권한', 'AUTCD', { width: 110, columnType: enumColumnTypes.combo, gpcd: 'AUTCD', readOnly: false }),
        column.create('잠금여부', 'LOCKYN', { width: 100, columnType: enumColumnTypes.check, readOnly: false }),
        column.create('비밀번호변경', 'CHANGEPW', { width: 110, columnType: enumColumnTypes.button, iconCls: 'fa-edit' }),
        //column.create('언어', 'LANGUAGE', { width: 120, columnType: enumColumnTypes.combo, gpcd: 'LANGUAGE', readOnly: false }),
        column.create('비고', 'REMARK', { width: 300, readOnly: false }),
        column.split()
    ]);

    ItsButton.EventSearch();
};


/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS0001_R04', 'LIST_SYSUSER');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('LOCKYN'));

    var cnt = maria.store.Length();        // 조회건수
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(cnt));
};


/* 저장 */
ItsButton.EventSave = function () {
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('SYS0001_R04', 'UP_SYSUSER');
            maria.AddRecord('grid1', i);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            } else {
                cnt++;
            }
        }
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
    ItsButton.EventSearch();
};

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('선택한 항목을 삭제 하시겠습니까?', function () {
        var cnt = 0;
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var maria = new ItsMaria('SYS0001_R04', 'DEL_SYSUSER');
                maria.AddRecord('grid1', i);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                } else {
                    cnt++;
                }
            }
        }
        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(cnt));
        ItsButton.EventSearch();
    });
};

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv1')
    ItsPop.Open('pop1');
};

ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS0001_R04', 'ADD_SYSUSER');
    maria.AddPanel('pdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop1');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsButton.EventSearch();
};
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPage.InitData('pop1');
    ItsPop.Close('pop1');
};

/* 비밀번호 변경 */
ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
    if (field == 'CHANGEPW') {
        ItsPage.InitData('pdiv2')
        ItsPop.Open('pop2');
    }
};

ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS0001_R04', 'CHANGE_PASSWORD');
    maria.AddPanel('pdiv2');
    maria.AddParam('USERID', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'USERID'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop2');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    ItsButton.EventSearch();
};

ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
};

//ItsButton.Event('CREATE_MAILID').onClick = function () {

//};