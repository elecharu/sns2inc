// 태블릿 재고조회
/// <reference path="../../Script/reference.js" />



    /* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isSubTotalGrid: true, isCheckBoxGrid: false }, [
        column.create('창고', 'WARECD', { width: 150, columnType: enumColumnTypes.combo, gpcd: 'WARECD', align: 'center' }),
        column.create("품목유형", "ITEMTP", { width: 150, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 100, align: 'center' }),
        column.create("품명", "ITEMNM", { width: 90, align: 'center' }),
        column.create('재질', 'MATERIAL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center' }),        
        column.create('두께', 'THICK', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('길이', 'LENGTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('폭', 'WIDTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),

        column.create("재고수량", "SUMQTY", { width: 150, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create("바코드", "LABELCD", { width: 150, hidden: true }),
        column.split()

    ]);
    ItsGrid.Create('grid2', { isSubTotalGrid: true, isCheckBoxGrid: false }, [
        column.create('로트번호', 'LOTKEY', { width: 120 }),
        column.create('창고', 'WARECD', { width: 120, hidden: true }),
        column.create('로트수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.split()
    ]);
};
   
ItsCombo.Event('cmb_ITEMTP').onChanged = function () {
    ItsCombo.SetRef01('find_ITEMCD', ItsCombo.GetValue('cmb_ITEMTP'));
};
/* 조회 */
ItsButton.Event('button_SEARCHLOT').onClick = function () {
    
    //ItsGrid.Clear('grid1');
    var maria = new ItsMaria('TAL0001_S01', 'LIST_COMLOT');

    maria.AddPanel('sdiv1');

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    ItsGrid.Get('grid1').autoSizeColumns();
};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsGrid.Clear('grid2');
    var maria = new ItsMaria('TAL0001_S01', 'DETAIL_COMLOT');
    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));
    maria.AddParam('WARECD', ItsGrid.GetValue('grid1', rowIndex, 'WARECD'));

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid2', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    ItsGrid.Get('grid2').autoSizeColumns();

}