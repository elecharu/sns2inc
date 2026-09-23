/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create("패키지 유형", "PKGTP", { width: 150, columnType: enumColumnTypes.combo, gpcd: 'PKGTP' }),
        column.create("화면 코드", "PRGCD", { width: 150 }),
        column.create("화면명", "PRGNM", { width: 200 }),
        column.create("상태", "PRGSTT", { width: 100, readOnly: false, columnType: enumColumnTypes.combo, gpcd: 'PRGSTT' }),
        column.create("비고", "REMARK", { width: 200 })
    ]);

    ItsPage.SetBackColor('ddiv1', enumColor.transparent);
    ItsButton.EventSearch();
};


/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SYS1002_R01', 'LIST_SYSPRG');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPage.SetBackColor('ddiv1', enumColor.transparent);
    ItsText.Disable('txt_PRGCD');

    ItsGrid.SetStore('grid1', maria.store.YnToBool());
    var cnt = maria.store.Length();        // 조회건수
    ItsMsg.Toast(cnt + '건이 조회되었습니다.');
};


/* 저장 */
ItsButton.EventSave = function () {
    var maria = new ItsMaria('SYS1002_R01', 'UP_SYSPRG');
    maria.AddPanel('ddiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsButton.EventSearch();
    ItsMsg.Toast('저장되었습니다.');
};

/* 삭제 */
ItsButton.EventDelete = function () {
    ItsMsg.Confirm('삭제하시겠습니까?', function () {
        var maria = new ItsMaria('SYS1002_R01', 'DEL_SYSPRG');
        maria.AddParam('PRGCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'PRGCD'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsButton.EventSearch();
        ItsMsg.Toast("삭제되었습니다.");
    });
};

/* 추가 */
ItsButton.EventAdd = function () {
    ItsPage.InitData('ddiv1');
    ItsPage.SetBackColor('ddiv1', enumColor.addPanel);
    ItsText.Enable('txt_PRGCD');
    ItsText.Focus('txt_PRGCD');
    ItsOnoff.SetValue('onoff_NEWYN', 'Y');
};

/* 그리드 행 선택 - grid1 */
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsPage.SetStore('ddiv1', ItsGrid.GetRowData('grid1', rowIndex));
    ItsPage.SetBackColor('ddiv1', enumColor.transparent);
    ItsText.Disable('txt_PRGCD');
    ItsOnoff.SetValue('onoff_NEWYN', 'N');
};

