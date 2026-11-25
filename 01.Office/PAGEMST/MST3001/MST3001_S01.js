/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 설비목록 그리드
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('작업장', 'LINECD', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', allowMerging: true }),
        column.create('공정', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', allowMerging: true }),
        column.create('라인', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', allowMerging: true }),
        column.create('설비그룹', 'EQMGUBUN', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM116', allowMerging: true }),
        column.create('설비코드', 'FANO', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 200 }),
        column.split()
    ]);

    // 선택 설비의 사용부품 집계 그리드
    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('품목코드', 'ITEMCD', { width: 120, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 180 }),
        column.create('규격', 'ITEMSPEC', { width: 150 }),
        column.create('단위', 'ITEMUNIT', { width: 60, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150' }),
        column.create('출고횟수', 'OUTCNT', { width: 70, align: 'right', columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('출고수량', 'OUTQTY', { width: 90, align: 'right', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('date_SEARCH', ItsHelper.AddDay(-365, ItsHelper.GetYearMonthDay()));
};

// 조회조건의 설비목록 조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST3001_S01', 'LIST_EQM');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

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

// 설비 선택시 출고일자 기간의 사용부품 집계 조회
ItsGrid.Event('grid1').onSelect = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST3001_S01', 'LIST_PARTS');
    maria.AddPanel('sdiv1');
    maria.AddParam('FANO', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'FANO'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
};
