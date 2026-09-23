/// <reference path="../../Script/reference.js" />

ItsPage.Load = function () {
    ItsGrid.Create('grid_SALODRD_ROUT', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells', groupField: 'SALODRDKEY' }, [
        column.create('수주품목키', 'SALODRDKEY', { width: 110, align: 'center', hidden: true }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center', allowMerging: true }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품코드', 'ITEMCD', { width: 150, align: 'center', allowMerging: true }),
        column.create('제품명', 'ITEMNM', { width: 200, align: 'center', allowMerging: true }),
        column.create('수주수량', 'ODRQTY', { width: 100, align: 'center', allowMerging: true }),
        column.create('반제품코드', 'SUBITEMCD', { width: 150, align: 'center', allowMerging: true }),
        column.create('반제품명', 'SUBITEMNM', { width: 200, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center' }),
        column.create('생산필요개수', 'NEEDQTY', { width: 110, align: 'center' }),
        column.create('생산양품', 'GOODQTY', { width: 100, align: 'center' }),
        column.create('생산불량', 'BADQTY', { width: 100, align: 'center' }),
        column.create('검사횟수', 'COUNT_TQMRST', { width: 100, align: 'center' }),

        column.split()
    ]);

    ItsGrid.Create('grid_TQMRST_HEADER', { isSubTotalGrid: false, isCheckBoxGrid: false }, [
        column.create('검사키', 'TQMRSTKEY', { width: 110, align: 'center', hidden: true }),
        column.create('검사일자', 'TQMDATE', { width: 100, align: 'center' }),
        column.create('검사자', 'EMPNM', { width: 100, align: 'center' }),
        column.create('초중종유형', 'PRCTESTTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PRCTESTTP' }),
        column.create('종합판정', 'FINALJUDGE', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGE' }),

        column.split()
    ]);

    ItsGrid.Create('grid_TQMRST_DETAIL', { isCheckBoxGrid: false }, [
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200, readOnly: true }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center', readOnly: true }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create("판정범위", "STDJUDGE_MEASURE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create('판정기준', 'STDJUDGE', { width: 300, multiLine: true }),


        column.band('검사결과', {}, [
            column.create('최소값', 'MINVAL', { width: 100, align: 'center' }),
            column.create('최대값', 'MAXVAL', { width: 100, align: 'center' }),
            column.create('평균', 'AVG', { width: 100, align: 'center' }),            
            column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2}),
            column.create('검사값조회', 'POPUP_TQMRST_VALUE', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
            column.create('판정', 'JUDGE', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'JUDGE', align: 'center' }),
        ]),

        column.split()
    ]);


    ItsGrid.Create('grid_TQMRST_VALUE', { isCheckBoxGrid: false }, [
        column.create('검사값키', 'VALUEKEY', { width: 100, hidden: true }),
        column.create('검사값', 'VALUE', { width: 100 })
    ]);

};
/*************************************************************************************************************************************************************************/
ItsCombo.Event('cmb_ITEMTP').onChanged = function () {
    ItsCombo.SetRef01('find_ITEMCD', ItsCombo.GetValue('cmb_ITEMTP'));
};

/*************************************************************************************************************************************************************************/
// 수주 작업공정 조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid_TQMRST_HEADER');
    ItsGrid.Clear('grid_TQMRST_DETAIL');

    var maria = new ItsMaria('PRD0001_S04', 'LIST_SALODRD_ROUT');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_SALODRD_ROUT', maria.store);

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

};

// 검사헤더 조회
ItsGrid.Event('grid_SALODRD_ROUT').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid_TQMRST_DETAIL');

    var maria = new ItsMaria('PRD0001_S04', 'LIST_TQMRST_HEADER');

    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_TQMRST_HEADER', maria.store);
};

// 검사상세 조회
ItsGrid.Event('grid_TQMRST_HEADER').onSelect = function (rowIndex, field) {
    var maria = new ItsMaria('PRD0001_S04', 'LIST_TQMRST_DETAIL');

    var TQMRSTKEY = ItsGrid.GetValue('grid_TQMRST_HEADER', rowIndex, 'TQMRSTKEY');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');

    maria.AddParam('TQMRSTKEY', TQMRSTKEY);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_TQMRST_DETAIL', maria.store);
    ItsGrid.Get('grid_TQMRST_DETAIL').autoSizeColumns();
};
/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid_TQMRST_DETAIL').onButtonClick = function (rowindex, field) {
    // 검사값조회 팝업오픈
    if (field == 'POPUP_TQMRST_VALUE') {
        SEARCH_TQMRST_VALUE();

        ItsPage.InitData('Div1');
        ItsPop.Open('POP_TQMRST_VALUE');
    }
}

// 검사값 조회 
SEARCH_TQMRST_VALUE = function () {
    var maria = new ItsMaria('PRD0001_S04', 'LIST_TQMRST_VALUE');

    var TQMRSTKEY = ItsGrid.GetValue('grid_TQMRST_HEADER', ItsGrid.GetCurrentIndex('grid_TQMRST_HEADER'), 'TQMRSTKEY');
    var STDCD = ItsGrid.GetValue('grid_TQMRST_DETAIL', ItsGrid.GetCurrentIndex('grid_TQMRST_DETAIL'), 'STDCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');

    maria.AddParam('TQMRSTKEY', TQMRSTKEY);
    maria.AddParam('STDCD', STDCD);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_TQMRST_VALUE', maria.store);
}
/*************************************************************************************************************************************************************************/
