/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 라인별 목표 그리드
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('작업장', 'LINECD', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD' }),
        column.create('공정', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100' }),
        column.create('라인', 'EQMGROUP1', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113' }),
        column.create('목표 점유율(%)', 'GOALRATE', { width: 110, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('년 목표 비가동시간(hr)', 'GOALHR', { width: 150, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.split()
    ]);

    // 선택 라인의 설비별 목표 그리드
    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('설비코드', 'FANO', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 200 }),
        column.create('목표 점유율(%)', 'GOALRATE', { width: 110, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.split()
    ]);

    ItsCombo.SetValueByIndex('cmb_SYEAR', 4);
};

// 목표년도 라인별 목표 조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST1006_R01', 'LIST_LINE');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 라인 선택시 해당 라인의 설비별 목표 조회
ItsGrid.Event('grid1').onSelect = function () {
    ItsGrid.Clear('grid2');

    var row = ItsGrid.GetCurrentIndex('grid1');
    var maria = new ItsMaria('MST1006_R01', 'LIST_EQM');
    maria.AddParam('SYEAR', ItsGrid.GetValue('grid1', row, 'SYEAR'));
    maria.AddParam('LINECD', ItsGrid.GetValue('grid1', row, 'LINECD'));
    maria.AddParam('EQMTP', ItsGrid.GetValue('grid1', row, 'EQMTP'));
    maria.AddParam('EQMGROUP1', ItsGrid.GetValue('grid1', row, 'EQMGROUP1'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
};

// 체크한 라인·설비 목표 저장 (라인은 목표 점유율·년 목표 비가동시간을 둘 다, 설비는 목표 점유율을 비우면 목표 삭제)
ItsButton.EventSave = function () {
    var lineRows = [], eqmRows = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) lineRows.push(i);
    }
    for (var j = 0; j < ItsGrid.Length('grid2'); j++) {
        if (ItsGrid.IsChecked('grid2', j)) eqmRows.push(j);
    }
    if (lineRows.length + eqmRows.length == 0) {
        ItsMsg.Alert('저장할 행을 체크하세요.');
        return;
    }

    ItsMsg.Confirm('선택하신 항목을 저장하시겠습니까?', function () {
        var cnt = 0;
        for (var a = 0; a < lineRows.length; a++) {
            if (!SAVE_GOAL('grid1', 'SAVE_LINE', lineRows[a])) return;
            cnt++;
        }
        for (var b = 0; b < eqmRows.length; b++) {
            if (!SAVE_GOAL('grid2', 'SAVE_EQM', eqmRows[b])) return;
            cnt++;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));
        ItsButton.EventSearch();
    });
};

// 그리드 한 행의 목표 저장
function SAVE_GOAL(gridId, callType, index) {
    var maria = new ItsMaria('MST1006_R01', callType);
    maria.AddRecord(gridId, index);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return false;
    }
    return true;
}

// 작업장 변경시 공정·라인 콤보를 그 작업장 기준으로 변경
ItsCombo.Event('cmb_LINECD').onChanged = function () {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 공정 변경시 라인 콤보를 그 공정 기준으로 변경
ItsCombo.Event('cmb_EQMTP').onChanged = function () {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};
