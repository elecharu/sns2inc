/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, allowMerging: 'Cells', groupField: 'LINENM' }, [
        column.create("사원코드", "EMPCD", { width: 100, align: 'center' }),
        column.create("사원명", "EMPNM", { width: 100, align: 'center' }),
        column.create("호출도착 지연시간(분)", "DELAYMIN_ARRIVE", { width: 150, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create("수리종료 지연시간(분)", "DELAYMIN_REPAIR", { width: 150, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create("사원ID", "EMPCD", { width: 100, align: 'center', hidden: true }),
        column.create("사원코드", "EMPCD", { width: 100, align: 'center', hidden: true }),
        column.create("사원명", "EMPNM", { width: 100, align: 'center' }),
        column.create("부서명", "DEPTCD", { width: 100, align: 'center' }),
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST1004_R01', 'LIST_EQM_CALLEMP');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
};

ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv4');
    ItsPop.Open('pop1');
    ItsButton.Event('btn_SEARCH').onClick();
}

ItsPop.Event('pop1').onAddBtnClick = function () {

    // 1) 체크된 사원ID 수집
    var empIds = [];
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            empIds.push(ItsGrid.GetValue('grid2', i, 'EMPCD'));
        }
    }

    // 2) 입력 검증
    if (empIds.length == 0) {
        ItsMsg.Alert('등록할 사원을 선택하세요.');
        return;
    }

    if ((ItsFind.GetValue('find_LINECD') || '') == '') {
        ItsMsg.Alert('작업장을 선택하세요.');
        return;
    }

    // 3) 등록 여부 확인 → "예"를 눌렀을 때만 저장
    ItsMsg.Confirm(empIds.length + '명의 사원을 선택한 작업장에 등록하시겠습니까?', function () {

        var maria = new ItsMaria('MST1004_R01', 'INS_EQM_CALLEMP');
        maria.AddPanel('pdiv4');

        for (var j = 0; j < empIds.length; j++) {
            maria.AddList('EMPCD_LIST', empIds[j]);
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('pop1');
        ItsButton.EventSearch();
    });
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

// ── 저장 ─────────────────────────────────────────────────
ItsButton.EventSave = function () {

    var list = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            list.push({
                eqmcd: ItsGrid.GetValue('grid1', i, 'EQMCD'),
                empcd: ItsGrid.GetValue('grid1', i, 'EMPCD'),
                arrive: Math.trunc(Number(ItsGrid.GetValue('grid1', i, 'DELAYMIN_ARRIVE'))),
                repair: Math.trunc(Number(ItsGrid.GetValue('grid1', i, 'DELAYMIN_REPAIR')))
            });
        }
    }

    // 2) 입력 검증
    if (list.length == 0) {
        ItsMsg.Alert('수정할 행을 체크하세요.');
        return;
    }

    for (var k = 0; k < list.length; k++) {
        var a = Number(list[k].arrive);
        var r = Number(list[k].repair);
        if (isNaN(a) || isNaN(r) || a < 0 || r < 0) {
            ItsMsg.Alert('지연시간은 0 이상의 숫자로 입력하세요.');
            return;
        }
    }

    // 3) 저장 여부 확인 → "예"를 눌렀을 때만 저장
    ItsMsg.Confirm(list.length + '건을 저장하시겠습니까?', function () {

        var maria = new ItsMaria('MST1004_R01', 'UPD_EQM_CALLEMP');

        for (var j = 0; j < list.length; j++) {
            maria.AddList('EQMCD_LIST', list[j].eqmcd);
            maria.AddList('EMPCD_LIST', list[j].empcd);
            maria.AddList('DELAYMIN_ARRIVE_LIST', list[j].arrive);
            maria.AddList('DELAYMIN_REPAIR_LIST', list[j].repair);
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.SaveComplete(list.length));
        ItsButton.EventSearch();
    });
};

// ── 삭제 ─────────────────────────────────────────────────
ItsButton.EventDelete = function () {

    var list = [];

    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            list.push({
                eqmcd: ItsGrid.GetValue('grid1', i, 'EQMCD'),
                empcd: ItsGrid.GetValue('grid1', i, 'EMPCD')
            });
        }
    }

    // 1) 삭제 대상 검증
    if (list.length == 0) {
        ItsMsg.Alert('삭제할 행을 체크하세요.');
        return;
    }

    // 2) 삭제 여부 확인
    ItsMsg.Confirm(list.length + '건을 삭제하시겠습니까?', function () {

        var maria = new ItsMaria('MST1004_R01', 'DEL_EQM_CALLEMP');

        for (var j = 0; j < list.length; j++) {
            maria.AddList('EQMCD_LIST', list[j].eqmcd);
            maria.AddList('EMPCD_LIST', list[j].empcd);
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.DeleteComplete(list.length));
        ItsButton.EventSearch();
    });
};

ItsButton.Event('btn_SEARCH').onClick = function () {

    var maria = new ItsMaria('MST1004_R01', 'LIST_EMP');
    maria.AddPanel('pdiv2');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
}
