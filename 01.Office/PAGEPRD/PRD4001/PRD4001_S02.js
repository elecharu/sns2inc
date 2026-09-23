/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isSubTotalGrid: true, allowMerging: 'Cells' }, [
        column.create('창고', 'WARECD', { width: 100, align: 'center' }),
        column.create('품목유형', 'ITEMCG', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create('관리번호', 'EONO', { width: 200, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('규격', 'ITEMSPEC', { width: 250 }),
        column.create('강종', 'SPEC6', { width: 250 }),
        column.create('로트번호', 'LOTKEY', { width: 200, align: 'center' }),
        column.create('재고수량', 'LOTQTY', { width: 90, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, decimalPrecision: 0 }),
        column.create('단위', 'ITEMUNIT', { width: 50, columnType: enumColumnTypes.combo, gpcd: 'DM150', align: 'center' }),
        column.split()
    ]);

    // 2025-06-27 법인 콤보박스 값을 60으로 고정
    ItsCombo.SetValue('sdiv1_combo_COMPANYCD', '60');
};

/* 조회 */
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('PRD4001_S02', 'LIST_COMLOT');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    //ItsGrid.Get('grid1').autoSizeColumns();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));

};

ItsText.Event('txt_LOTKEY').onKeyEnter = function () {
    ItsButton.EventSearch();
}

ItsText.Event('sdiv1_text_KEYWORD').onKeyEnter = function () {
    ItsButton.EventSearch();
}

ItsCombo.Event('sdiv1_combo_COMPANYCD').onChanged = function (value) {
    ItsCombo.SetRef01('sdiv1_combo_FACTORYCD', value);
    ItsCombo.SetValueByIndex('sdiv1_combo_FACTORYCD', 2);
}

ItsCombo.Event('sdiv1_combo_FACTORYCD').onChanged = function (value) {
    ItsCombo.SetRef01('sdiv1_find_WARECD', value);
    ItsCombo.SetValueByIndex('sdiv1_find_WARECD', 0);
}