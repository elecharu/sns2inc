/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('문서번호', 'EQMREPKEY', { width: 130, align: 'center', readOnly: true }),
        column.create('작업구분', 'WORKTP', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM300', readOnly: true }),
        column.create('작성일', 'WRITEDATE', { width: 95, align: 'center', readOnly: true }),
        column.create('작업장', 'LINECD', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: true }),
        column.create('공정', 'EQMTP', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', readOnly: true }),
        column.create('라인', 'EQMGROUP1', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', readOnly: true }),
        column.create('설비코드', 'EQMCD', { width: 100, readOnly: true }),
        column.create('설비명', 'EQMNM', { width: 180, readOnly: true }),
        column.create('고장유형', 'FAILTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM307', readOnly: true }),
        column.create('고장부위', 'FAILPART', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM303', readOnly: true }),
        column.create('중단구분', 'STOPTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM304', readOnly: true }),
        column.create('비가동 발생일시', 'NONSTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('비가동 종료일시', 'NONETIME', { width: 130, align: 'center', readOnly: true }),
        column.create('정지시간(분)', 'STOPMIN', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true }),
        column.create('수리 시작시간', 'REPSTIME', { width: 130, align: 'center', readOnly: true }),
        column.create('수리 종료시간', 'REPETIME', { width: 130, align: 'center', readOnly: true }),
        column.create('수리시간(분)', 'REPMIN', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: true }),
        column.create('작업자', 'EMPNMS', { width: 150, readOnly: true }),
        column.create('고장현상/작업내용', 'MALFUNCTION', { width: 230, readOnly: true }),
        column.create('원인분석', 'CAUSE', { width: 230, readOnly: true }),
        column.create('조치내역', 'HANDLE', { width: 230, readOnly: true }),
        column.create('사용 자재/부품', 'PARTS', { width: 200, readOnly: true }),
        column.create('특이사항 및 재발방지대책', 'PREVENT', { width: 230, readOnly: true }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('sdiv1_date_SEARCH', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));
};

// 작업장 변경 시 공정·라인 콤보를 그 작업장 기준으로 변경
ItsCombo.Event('sdiv1_cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('sdiv1_cmb_EQMTP', ItsCombo.GetValue('sdiv1_cmb_LINECD'));
    ItsCombo.SetValue('sdiv1_cmb_EQMTP', '', false);

    ItsCombo.SetRef01('sdiv1_cmb_EQMGROUP1', ItsCombo.GetValue('sdiv1_cmb_LINECD'), false);
    ItsCombo.SetRef02('sdiv1_cmb_EQMGROUP1', '');
    ItsCombo.SetValue('sdiv1_cmb_EQMGROUP1', '', false);
};

// 공정 변경 시 라인 콤보를 그 공정 기준으로 변경
ItsCombo.Event('sdiv1_cmb_EQMTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('sdiv1_cmb_EQMGROUP1', ItsCombo.GetValue('sdiv1_cmb_EQMTP'));
    ItsCombo.SetValue('sdiv1_cmb_EQMGROUP1', '', false);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD6001_S03', 'LIST_WORKLOG');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 인쇄 (툴바 인쇄와 우측 상단 [공무작업일지 인쇄] 같은 동작) */
ItsButton.EventPrint = function () {
    WORKLOG_PRINT();
};

ItsButton.Event('bdiv1_btn_PRINT').onClick = function () {
    WORKLOG_PRINT();
};

// 체크한 공무작업일지를 한 PDF로 출력 (일지 1건 = 1페이지)
function WORKLOG_PRINT() {
    var keys = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            keys.push(ItsGrid.GetValue('grid1', i, 'EQMREPKEY'));
        }
    }
    if (keys.length == 0) {
        ItsMsg.Toast('인쇄할 공무작업일지를 선택해주세요.');
        return;
    }

    var rpt = new ItsXtraRpt('PRD6001_S03');
    rpt.AddParam('EQMREPKEY_LIST', keys.join(','));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
}
