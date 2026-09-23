/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center' }),
        column.create('거래처명', 'CUSTCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CUSTCD', align: 'center' }),

        column.create('품목코드', 'ITEMCD', { width: 150 }),
        column.create('품명', 'ITEMNM', { width: 200 }),        
        column.create('수주상세번호', 'SALODRDKEY', { width: 120, align: 'center' }),
        column.create('수주수량', 'ODRQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('출하스캔수량', 'SCANQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),

        column.create('종합판정', 'FINALJUDGE', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'JUDGE', align: 'center' }),
        column.create('출하검사성적서 출력', 'PRINT', { width: 150, columnType: enumColumnTypes.button, iconCls: "fa fa-print" }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200, readOnly: true }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center', readOnly: true }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create("판정범위", "STDJUDGE_MEASURE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create('판정기준', 'STDJUDGE', { width: 300, readOnly: false, multiLine: true, readOnly: true }),

        column.band('검사결과', {}, [
            column.create('MIN', 'MIN', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true }),
            column.create('MAX', 'MAX', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true }),
            column.create('AVG', 'AVG', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true }),
            column.create('시료수', 'SAMPLESIZE', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: true }),
            column.create('판정', 'JUDGE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGE' }),            
            //column.create('검사값등록', 'POPUP_VALUE', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        ]),

        //column.create('정렬순서', 'SORTNO', { width: 70, readOnly: false, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true }),        
        
        column.split()
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: true }, [
        column.create('출하키', 'SALOUTKEY', { width: 100, align: 'center', hidden: true }),
        column.create('검사항목코드', 'STDCD', { width: 100, hidden: true }),
        column.create('검사값키', 'VALUEKEY', { width: 100, hidden: false }),
        column.create('검사값', 'VALUE', { width: 100, readOnly: false })
    ]);

    ItsGrid.Create('grid_TQMRST_VALUE', { isCheckBoxGrid: false }, [
        column.create('검사값키', 'VALUEKEY', { width: 100, hidden: true }),
        column.create('검사값', 'VALUE', { width: 100, align: 'right'})
    ]);


    // 그리드 Row 높이 자동설정
    //ItsGrid.Get('grid2').autoRowHeights = true;
    ItsText.Hide('txt_TQMRSTKEY');

    ItsCombo.Disable('cmb_DATETP');
};

ItsCombo.Event('cmb_ITEMTP').onChanged = function () {
    ItsCombo.SetRef01('find_ITEMCD', ItsCombo.GetValue('cmb_ITEMTP'));
};


ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('SAL0001_S05', 'LIST_TQMRST');
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

    var maria = new ItsMaria('SAL0001_S05', 'LIST_TQMRSTKND');

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




// 출하검사 성적서 프린트 
ItsGrid.Event('grid1').onButtonClick = function (rowindex, field) {
    if (field == 'PRINT') {
        var rpt = new ItsXtraRpt('SAL0001_S05');       

        var TQMRSTKEY = ItsGrid.GetValue('grid1', rowindex, 'TQMRSTKEY');

        rpt.AddParam('TQMRSTKEY', TQMRSTKEY);

        rpt.Call();

        if (rpt.isError) {
            ItsMsg.Alert(rpt.errMessage);
            return;
        }
    }

};
/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid2').onSelect = function (rowindex, field) {
    LIST_TQMRST_VALUE();
};


LIST_TQMRST_VALUE = function () {
    ItsGrid.Clear('grid_TQMRST_VALUE');

    var maria = new ItsMaria('SAL0001_S05', 'LIST_TQMRST_VALUE');

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