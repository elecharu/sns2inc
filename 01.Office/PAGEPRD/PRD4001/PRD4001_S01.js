/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isSubTotalGrid: true, allowMerging: 'Cells' }, [
        column.create('창고', 'WARECD', { width: 100, align: 'center', hidden: true }),
        column.create('창고', 'WARENM', { width: 100, align: 'center' }),       
        column.create('품목ID', 'ITEMID', { width: 200, align: 'center', hidden: true }),
        column.create('품목유형', 'ITEMCG', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),        
        column.create('공장', 'FACTORYCD', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', align: 'center' }),        
        column.create('품목코드', 'ITEMCD', { width: 200 }),        
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.create('규격', 'ITEMSPEC', { width: 250 }),
        column.create('재고수량', 'LOTQTY', { width: 90, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, decimalPrecision: 0 }),
        column.create('안전재고', 'SAFEQTY', { width: 90, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, decimalPrecision: 0 }),
        column.create('적정재고', 'STDQTY', { width: 90, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, decimalPrecision: 0 }),
        column.create('단위', 'ITEMUNIT', { width: 50, columnType: enumColumnTypes.combo, gpcd: 'DM150', align: 'center' }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isSubTotalGrid: true }, [
        column.create('로트번호', 'LOTKEY', { width: 120, align: 'center' }),
        column.create('재고수량', 'LOTQTY', { width: 90, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, decimalPrecision: 0 }),
        column.create('입고일자', 'RTIME', { width: 100, align: 'center' }),
        column.split()
    ]);

    // 공장 기본값 (법인은 공장의 법인코드를 씀)
    ItsCombo.SetValue('sdiv1_combo_FACTORYCD', '07');
};

/* 조회 */
ItsButton.EventSearch = function () {

    ItsGrid.Clear('grid2');
    var maria = new ItsMaria('PRD4001_S01', 'LIST_COMLOT');
    maria.AddPanel('sdiv1');
    maria.AddParam('COMPANYCD', ItsFind.GetRef01('sdiv1_find_ITEMID'));   // 법인 = 선택한 공장의 법인코드
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.Get('grid1').autoSizeColumns();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));

};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD4001_S01', 'INFO_COMLOT');
    maria.AddPanel('sdiv1');
    maria.AddParam('COMPANYCD', ItsFind.GetRef01('sdiv1_find_ITEMID'));   // 법인 = 선택한 공장의 법인코드
    maria.AddRecord('grid1', rowIndex);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid2').autoSizeColumns();
}

ItsText.Event('txt_LOTKEY').onKeyEnter = function () {
    ItsButton.EventSearch();
}

ItsText.Event('sdiv1_text_KEYWORD').onKeyEnter = function () {
    ItsButton.EventSearch();
}

/* 공장이 정해지면 창고 목록과 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('sdiv1_combo_FACTORYCD').onChanged = function (value) {
    ItsCombo.SetRef01('sdiv1_find_WARECD', value);
    ItsCombo.SetValueByIndex('sdiv1_find_WARECD', 0);

    var companycd = $('#sdiv1_combo_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('sdiv1_find_ITEMID', companycd);
    ItsFind.SetRef03('sdiv1_find_ITEMID', value);
}