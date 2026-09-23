/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true, groupField: 'GRP' }, [
        column.create("패키지", "PKGTP", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PKGTP_SCM' }),
        column.create("CATE", "CATECD", { width: 70, align: 'center', hidden:true }),
        column.create("카테고리", "CATENM", { width: 100, align: 'center' }),
        column.create("프로그램코드", "PRGCD", { width: 100, align: 'center' }),
        column.create("화면명", "MENUNM", { width: 180, columnType: enumColumnTypes.find, readOnly: false }),
        column.create("작업상태", "PRGSTT", { width: 70, readOnly: false, columnType: enumColumnTypes.combo, gpcd: 'PRGSTT_E' }),
        column.create("순번", "SORTNO", { width: 50, readOnly: false, columnType: enumColumnTypes.number }),
        column.create("작업자", "DEV", { width: 70, readOnly: false, align: 'center' }),
        column.create("진행률(%)", "RATE", { width: 70, readOnly: false, columnType: enumColumnTypes.number, groupType: enumGrouping.avg }),
        column.create("작업시작일", "STRDT", { width: 90, readOnly: false, columnType: enumColumnTypes.date }),
        column.create("완료예정일", "ENDDT", { width: 90, readOnly: false, columnType: enumColumnTypes.date }),     
        column.create("승인", "CONFIRMYN", { width: 50, readOnly: false, columnType: enumColumnTypes.check }),   
        column.create("승인자", "CONFIRMEMPCD", { width: 70, columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),     
        column.create("승인일", "CONFIRMDT", { width: 90 }),     
        column.create("요청사항", "REQUEST", { width: 200, readOnly: false}),   
        column.create("이동", "MOVEPRG", { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-external-link' }),
        column.create("비고", "SHOWREMARK", { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        column.create("비고-", "REMARK", { width:'*' }),
    ]);

    ItsButton.EventSearch();

    
};


/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS2001_R02', 'LIST_WEBPKG');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
};
/* 추가 */
ItsButton.EventAdd = function () {
    ItsPop.Open('pop2');
};
ItsCombo.Event('pop2_PKGTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('pop2_CATECD', value);
    ItsCombo.SetValueByIndex('pop2_CATECD', 0);
}

ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('SYS2001_R02', 'ADD_WEBPRG');
    maria.AddPanel('pop2');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop2');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
    ItsButton.EventSearch();
};
ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPage.InitData('pop2');
    ItsPop.Close('pop2');
};

/* 저장 */
ItsButton.EventSave = function () {
    for (var i = 0; i < ItsGrid.Length('grid1') ; i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            var maria = new ItsMaria('SYS2001_R02', 'SAVE_WEBPRG');
            maria.AddRecord('grid1', i);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
        }
    }
    ItsMsg.Toast('저장되었습니다.');
    ItsButton.EventSearch();
};

// 삭제
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('선택한 화면의 모든 정보를 삭제합니다.', function () {
        for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
            if (ItsGrid.IsChecked('grid1', i)) {
                var maria = new ItsMaria('SYS2001_R02', 'DEL_WEBPRG');
                maria.AddRecord('grid1', i);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
            }
        }

        ItsButton.EventSearch();
    })
};

ItsButton.Event('SAVE_REMARK').onClick = function () {
    var maria = new ItsMaria('SYS2001_R02', 'SAVE_REMARK');
    maria.AddParam('PRGCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PRGCD'));
    maria.AddParam('REMARK', ItsTextArea.GetValue('ta_REMARK'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast('저장되었습니다.');
    ItsButton.EventSearch();
};


ItsGrid.Event('grid1').onButtonClick = function (row, field) {
    if (field == 'SHOWREMARK') {
        ItsPop.Open('pop1');
        ItsTextArea.SetValue('ta_REMARK', ItsGrid.GetValue('grid1', row, 'REMARK'));
    } else if (field == 'MOVEPRG') {
        ItsPage.Jump(ItsGrid.GetValue('grid1', row, 'PRGCD'));
    }
};
