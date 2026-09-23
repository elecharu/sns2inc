//재고조회
/// <reference path="../../Script/reference.js" />


/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isSubTotalGrid: true, isCheckBoxGrid: false }, [
        column.create('창고', 'WARECD', { width: 150, columnType: enumColumnTypes.combo, gpcd: 'WARECD', align: 'center' }),
        column.create("품목유형", "ITEMTP", { width: 150, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center' }),
        column.create("품목코드", "ITEMCD", { width: 100, align: 'center' }),
        column.create("품명", "ITEMNM", { width: 90, align: 'center' }),
        column.create('재질', 'MATERIAL', { width: 100, align: 'center' }),        
        column.create('두께', 'THICK', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('길이', 'LENGTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('폭', 'WIDTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),

        column.create("재고량", "SUMQTY", { width: 150, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, backColor: enumColor.greenLight2 }),     
        column.create("사급자재량", "SUMQTY_OSCMTR", { width: 150, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),     
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create("바코드", "LABELCD", { width: 150, hidden: true }),     


    ]);
    ItsGrid.Create('grid2', { isSubTotalGrid: true, isCheckBoxGrid: true }, [
        column.create('로트번호', 'LOTKEY', { width: 120 }),
        column.create('창고', 'WARECD', { width: 120, hidden: true }),
        column.create('로트수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('입고일자', 'PRDDATE', { width: 100, align: 'center' }),        
        column.create('사급자재', 'OSCMTR_YN', { width: 80, columnType: enumColumnTypes.check }),
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MTR0001_S02', 'LIST_COMLOT');

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
    var maria = new ItsMaria('MTR0001_S02', 'DETAIL_COMLOT');

    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));
    maria.AddParam('WARECD', ItsGrid.GetValue('grid1', rowIndex, 'WARECD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('OSCMTR_YN'));

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));

    ItsGrid.Get('grid2').autoSizeColumns();

}

ItsButton.EventPrint = function () {
    var LABELCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'LABELCD');

    var maria = new ItsMaria('MTR0001_S02', 'PRINT_LABEL');

    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            maria.AddList('LOTLIST', ItsGrid.GetValue('grid2', i, 'LOTKEY'));
            maria.AddList('WARECDLIST', ItsGrid.GetValue('grid2', i, 'WARECD'));

        }
    }
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var label = new ItsTmlLabel(LABELCD, maria.ToString());
    label.Call();
}


//ItsButton.Event('btn_PRINT_COMLOT').onClick = function () {

//    var groupLABELCD = {}; // ITEMTP별로 LOTKEY, WARECD 분류 (객체)

//    // 1. 체크된 항목들을 ITEMTP 기준으로 분류
//    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
//        if (ItsGrid.IsChecked('grid1', i)) {
//            var LABELCD = ItsGrid.GetValue('grid1', i, 'LABELCD');
//            var lotkey = ItsGrid.GetValue('grid1', i, 'LOTKEY');
//            var warecd = ItsGrid.GetValue('grid1', i, 'WARECD');

//            if (!groupLABELCD[LABELCD]) {
//                groupLABELCD[LABELCD] = [];
//            }

//            groupLABELCD[LABELCD][groupLABELCD[LABELCD].length] = { LOTKEY: lotkey, WARECD: warecd };
//        }
//    }
//    console.log(groupLABELCD[LABELCD]);
//    // 2. ITEMTP별로 maria 호출 및 라벨 출력
//    for (var LABELCD in groupLABELCD) {
//        var maria = new ItsMaria('MTR0001_S02', 'PRINT_LABEL');

//        groupLABELCD[LABELCD].forEach(function (row) {
//            maria.AddList('LOTLIST', row.LOTKEY);
//            maria.AddList('WARECDLIST', row.WARECD);
//        });

//        maria.CallProc();

//        if (maria.isError) {
//            maria.ShowErrMsg();
//            return;
//        }
       
//        var label = new ItsTmlLabel(LABELCD, maria.ToString());
//        label.Call();
       
//    }
//};


