/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    /* grid1: 품목별 & 수량 */
    ItsGrid.Create('grid1', { isSubTotalGrid: true }, [
        column.create('출고키', 'SALOUTKEY', { width: 100, hidden: true, align: 'center' }),
        column.create('츨고일자', 'OUTDATE', { width: 100, align: 'center'}),
        column.create('거래처코드', 'CUSTCD', { width: 80, align: 'center'}),
        column.create('거래처명', 'CUSTNM', { width: 100, align: 'center'}),
        column.create('품목유형', 'ITEMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ITEMTP'}),
        column.create('품목코드', 'ITEMCD', { width: 150, align: 'center'}),
        column.create('품명', 'ITEMNM', { width: 200, align: 'center' }),
        column.create('수주상세번호', 'SALODRDKEY', { width: 110, align: 'center' }),
        column.create('출하창고', 'WARECD', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'WARECD'}), 
        column.create('출하로트', 'LOTKEY', { width: 110, align: 'center'}),
        column.create('출하수량', 'OUTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('date_SALDATE', ItsHelper.GetYearMonth() + '-01');

};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');

    var maria = new ItsMaria('SAL0001_S04', 'LIST_COMOUT');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
};

