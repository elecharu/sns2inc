/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {  
    ItsGrid.Create('grid_PRDRSTBAD', { isSubTotalGrid: true, isCheckBoxGrid: false, allowMerging: 'Cells', groupField: 'SALODRDKEY' }, [
        column.create('수주품목키', 'SALODRDKEY', { width: 110, align: 'center', hidden: true }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center', allowMerging: true }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('수주수량', 'ODRQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, allowMerging: true }),
        column.create('반제품코드', 'SUBITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('반제품명', 'SUBITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center' }),
        column.create('불량명', 'BADCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BADCD' }),
        column.create('불량수량', 'BADQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('작업자', 'EMPCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),
        column.create('실적등록시간', 'RSTTIME', { width: 100, align: 'center' }),
        column.split()
    ]);

};
/*************************************************************************************************************************************************************************************/

/* 조회 */
ItsButton.EventSearch = function () {
    // 수주 작업공정 조회
    var maria = new ItsMaria('PRD0001_S06', 'LIST_PRDRSTBAD');

    maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dateR_EXPDATE'));
    maria.AddParam('EDATE', ItsDateRange.GetValueTo('dateR_EXPDATE'));
    maria.AddParam('CUSTCD', ItsFind.GetValue('find_CUSTCD'));
    maria.AddParam('ITEMCD', ItsFind.GetValue('find_ITEMCD'));
    

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDRSTBAD', maria.store);

    ItsGrid.Get('grid_PRDRSTBAD').autoSizeColumns();
};
/*************************************************************************************************************************************************************************************/