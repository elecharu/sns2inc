/* TQC2002_S01: 품질관리 - 공정검사관리 - 공정불량조회 */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 최초 실행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowMerging: 'Cells' }, [
  

        column.create('작업지시번호', 'PRDINSKEY', { width: 150, align: 'center', allowMerging: true }),
        column.create('품목유형', 'ITEMTP', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 150, align: 'center', allowMerging: true }),
        column.create('품목규격', 'ITEMSPEC', { width: 150, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCCD', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PRCCD', allowMerging: true }),
        column.create('라인', 'LINECD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', allowMerging: true }),
        column.create('지시수량', 'INSQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, allowMerging: true }),


        column.create('등록일자', 'RSTDATE', { width: 120, align: 'center' }),
        column.create('불량코드', 'BADCD', { width: 120, align: 'center' }),
        column.create('불량명', 'BADNM', { width: 120, align: 'center'}),
        column.create('불량수량', 'BADQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('작업자', 'EMPCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),

        column.split()
    ]);

    // 병합처리 후 가운데 정렬
    ItsGrid.Get('grid1').formatItem.addHandler(function (s, e) {
        if (e.panel.cellType == 1 && e.range.rowSpan > 1) {
            var html = e.cell.innerHTML;
            e.cell.innerHTML = '<div class="v-center">' + html + '</div>';
        }
    });

    ItsDateRange.SetValueFrom('dr_DATE', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));
    ItsDateRange.SetValueTo('dr_DATE', ItsHelper.GetYearMonthDay());
};



/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('TQM0001_S01', 'LIST_PRDRSTBAD');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));

};
