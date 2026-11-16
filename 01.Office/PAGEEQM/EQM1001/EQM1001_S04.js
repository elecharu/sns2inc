/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    // 설비종합효율
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('점검일자', 'BASEDATE', { width: 80, columnType: enumColumnTypes.date, align: 'center' }),
        column.create('점검유형', 'CHKTP', { width: 110, columnType: enumColumnTypes.combo, gpcd: "CHKTP", align: 'center' }),
        column.create('점검자', 'EMPCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: "EMPCD", align: 'center' }),
        column.create('공장', 'FACTORYCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', readOnly: true }),
        column.create('작업장', 'LINECD', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('설비구분', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', readOnly: true }),
        column.create('설비대분류', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', readOnly: true }),
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
        // 2026-11-06 점검항목별 특이사항 표시
        column.create('특이사항', 'REMARK', { width: 300, readOnly: true }),

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

// 체크한 점검이력(grid1) 점검 시트 출력, 여러 건은 한 PDF에 점검이력마다 새 페이지
ItsButton.Event('btn_PRINT').onClick = function () {
    var keys = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            keys.push(ItsGrid.GetValue('grid1', i, 'CHKRSTKEY'));
        }
    }
    if (keys.length == 0) {
        ItsMsg.Alert('출력할 점검이력을 체크하십시오.');
        return;
    }

    var rpt = new ItsXtraRpt('EQM1001_S04A');
    rpt.AddParam('CHKRSTKEY_LIST', keys.join(','));
    rpt.CallPop();

    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};