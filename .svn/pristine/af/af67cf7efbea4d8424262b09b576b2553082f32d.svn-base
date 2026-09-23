/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    // 설비종합효율
    ItsGrid.Create('grid1', { isSubTotalGrid: true }, [
        column.create('점검일자', 'BASEDATE', { width: 80, columnType: enumColumnTypes.date, align: 'center' }),
        column.create('점검유형', 'CHKTP', { width: 110, columnType: enumColumnTypes.combo, gpcd: "CHKTP", align: 'center' }),
        column.create('점검자', 'EMPCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: "EMPCD", align: 'center' }),
        column.create('설비코드', 'EQMCD', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 250, align: 'center' }),
        column.create('문제점', 'PROBLEM', { width: 300, multiLine: true, readOnly: true }),
        column.create('조치사항', 'SOLUTION', { width: 300, multiLine: true, readOnly: true }),
        column.create('점검키', 'CHKRSTKEY', { width: 120, readOnly: true, hidden: false, align: 'center' }),
        column.create('등록시간', 'RTIME', { width: 140, readOnly: true, align: 'center' }),
        column.split()
    ]);

    // 노동생산성
    ItsGrid.Create('grid2', { isSubTotalGrid: true }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300, readOnly: true }),
        column.create('점검항목', 'CHKLOC', { width: 130, columnType: enumColumnTypes.combo, gpcd: "CHKLOC", align: 'center' }),
        column.create('점검방법', 'CHKMTH', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', align: 'center' }),
        column.create('점검값구분', 'CHKVALTP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', align: 'center' }),
        column.create('점검값', 'CHKVALUE', { width: 90, align: 'center' }),

        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('EQM1001_S04', 'LIST_CHKRSTEQM');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};


ItsGrid.Event('grid1').onSelect = function () {

    var maria = new ItsMaria('EQM1001_S04', 'LIST_CHKRSTEQMKND');
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
}