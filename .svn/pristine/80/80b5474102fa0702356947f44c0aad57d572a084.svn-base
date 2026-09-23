/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isSubTotalGrid: true }, [
        column.create('설비코드', 'EQMCD', { width: 100 }),
        column.create('설비명', 'EQMNM', { width: 130 }),
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('EQM1001_S01', 'LIST_EQMCD');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
};

ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    var EQMCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMCD');
    if (!EQMCD) {
        return;
    }

    var rpt = new ItsXtraRpt('EQM1001_S01A');
    rpt.AddParam('EQMCD', EQMCD);
    rpt.AddParam('CHECKYN', ItsCheck.GetValue('chk_rate'));
    rpt.Call('rpt2');

    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
        return;
    }
};

ItsCheck.Event('chk_rate').onChanged = function () {
    var EQMCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMCD');
    if (!EQMCD) {
        return;
    }

    ItsGrid.Event('grid1').onSelect();
};
