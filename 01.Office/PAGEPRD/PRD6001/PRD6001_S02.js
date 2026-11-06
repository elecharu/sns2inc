/// <reference path="../../Script/reference.js" />
var tabState = 0;

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowMerging: true }, [
        column.create('설비명', 'EQM', { width: 130, align: 'center', allowMerging: true }),
        column.create('구분', 'ITEM', { width: 100, align: 'center' }),
        column.create('1월', 'M1', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('2월', 'M2', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('3월', 'M3', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('4월', 'M4', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('5월', 'M5', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('6월', 'M6', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('7월', 'M7', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('8월', 'M8', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('9월', 'M9', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('10월', 'M10', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('11월', 'M11', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('12월', 'M12', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.create('합계', 'MSUM', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, align: 'center' }),
        column.split()
    ]);

    ItsCombo.SetInitValue('sdiv1_cmb_SYEAR', ItsHelper.GetYearMonth().substr(0, 4));

    /* 병합처리 시 상하중간정렬처리되도록 */
    ItsGrid.Get('grid1').formatItem.addHandler(function (s, e) {
        if (e.panel.cellType == 1 && e.range.rowSpan > 1) {
            var html = e.cell.innerHTML;
            e.cell.innerHTML = '<div class="v-center">' + html + '</div>';
        }
    });
};


/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD6001_S02', 'LIST_EQMDATA');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.data.length));
}