/// <reference path="../../Script/reference.js" />

// 2026-10-06 이력카드 설비 목록의 불필요한 합계 행 제거
ItsPage.Load = function () {

    ItsGrid.Create('grid1', {}, [
        column.create('설비코드', 'EQMCD', { width: 100 }),
        column.create('설비명', 'EQMNM', { width: 130 }),
    ]);
};

// 2026-10-06 이력카드 조회 시 이전 PDF 초기화
ItsButton.EventSearch = function () {
    ItsRptViewer.Clear('rpt2');
    ItsGrid.Clear('grid1');
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
        ItsRptViewer.Clear('rpt2');
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
