/// <reference path="../../Script/reference.js" />


/* 페이지 접근 시 수행 */
ItsPage.Load = function () {


    // 가입고 이력(헤더)
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('입고일자', 'PRDDATE', { width: 80, align: 'center', readOnly: true }),
        column.create('거래처명', 'CUSTCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CUSTCD', align: 'center', readOnly: true }),
        column.create('품목코드', 'ITEMCD', { width: 90, readOnly: true, align: 'center' }),
        column.create('품목형태', 'ITEMTP', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', readOnly: true, align: 'center' }),
        column.create('재질', 'MATERIAL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center', readOnly: true }),
        column.create('품명', 'ITEMNM', { width: 100, align: 'center', readOnly: true }),
        column.create('두께', 'THICK', { width: 100, columnType: enumColumnTypes.number, aligh: 'center', readOnly: true }),
        column.create('길이', 'LENGTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center', readOnly: true }),
        column.create('폭', 'WIDTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center', readOnly: true }),

        column.create('가입고번호', 'MTRINKEY', { width: 100, align: 'center', hidden: true }),
        column.create('입고량', 'INQTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, readOnly: true }),
        column.create('종합판정', 'FINALJUDGE', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGE' }),
        column.split()
    ]);



    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200 }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center', readOnly: true }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create("판정범위", "STDJUDGE_MEASURE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create('판정기준', 'STDJUDGE', { width: 200, multiLine: true }),
        column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2 }),

        column.band('검사결과', {}, [
            column.create('MIN', 'MINVAL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
            column.create('MAX', 'MAXVAL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
            column.create('AVG', 'AVG', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
            column.create('판정', 'JUDGE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGE' }),
        ]),

        column.create('기준값', 'STDVAL', { width: 60, readOnly: true, hidden: true }),
        column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', align: 'center', readOnly: true, hidden: true }),
        column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', align: 'center', readOnly: true, hidden: true }),
        column.create('오차(-)', 'STDMINUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true, hidden: true }),
        column.create('오차(+)', 'STDPLUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true, hidden: true }),

        column.split()
    ]);


    ItsGrid.Create('grid_TQMRST_VALUE', { isCheckBoxGrid: false }, [
        column.create('검사값키', 'VALUEKEY', { width: 100, hidden: true }),
        column.create('검사값', 'VALUE', { width: 100, align: 'right' })
    ]);


};

ItsCombo.Event('cmb_ITEMTP').onChanged = function () {
    ItsCombo.SetRef01('find_ITEMCD', ItsCombo.GetValue('cmb_ITEMTP'));
};


/* 수입검사 결과조회 GRID1 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');
    
    var maria = new ItsMaria('MTR0001_S04 ', 'LIST_MTRINLOT');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

};


ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MTR0001_S04', 'LIST_TQMRSTKND');

    maria.AddParam('ITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));
    maria.AddParam('LOTKEY', ItsGrid.GetValue('grid1', rowIndex, 'LOTKEY'));
    maria.AddParam('TQMRSTKEY', ItsGrid.GetValue('grid1', rowIndex, 'TQMRSTKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    ItsText.SetValue('txt_REVNUM', maria.store.data[0]['REVNUM']);
    ItsText.SetValue('txt_REVCD', maria.store.data[0]['REVCD']);
    ItsFind.SetValue('find_EMPCD', maria.store.data[0]['EMPCD']);
    ItsCombo.SetValue('comb_FINALJUDGE', maria.store.data[0]['FINALJUDGE']);   
    ItsText.SetValue('txt_REMARK', maria.store.data[0]['REMARK']);   
};


/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid2').onSelect = function (rowindex, field) {
    LIST_TQMRST_VALUE();
};


LIST_TQMRST_VALUE = function () {
    ItsGrid.Clear('grid_TQMRST_VALUE');

    var maria = new ItsMaria('MTR0001_S04', 'LIST_TQMRST_VALUE');

    var TQMRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'TQMRSTKEY');
    var STDCD = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'STDCD');

    maria.AddParam('TQMRSTKEY', TQMRSTKEY);
    maria.AddParam('STDCD', STDCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_TQMRST_VALUE', maria.store);
}
/*************************************************************************************************************************************************************************/