/// <reference path="../../Script/reference.js" />

var repLine;   // 설비고장율 현황에서 넘어온 라인의 공정·라인 (작업장이 같을 때만 수리 이력 조건에 사용)

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.band('비가동 이력', {}, [
            column.create('비가동키', 'PRDNONKEY', { width: 100, hidden: true }),
            column.create('비가동일자', 'NONDATE', { width: 90, align: 'center' }),
            column.create('작업장', 'LINENM', { width: 70, align: 'center' }),
            column.create('공정', 'PRCNM', { width: 90, align: 'center' }),
            column.create('라인', 'EQMNM', { width: 110, align: 'center' }),
            column.create('비가동 대분류', 'NONGROUPCD1', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PP409' }),
            column.create('비가동유형', 'NONNM', { width: 120, align: 'center' }),
            column.create('고장여부', 'BADYN', { width: 70, align: 'center' }),
            column.create('시작시간', 'NONSTIME', { width: 130, align: 'center' }),
            column.create('종료시간', 'NONETIME', { width: 130, align: 'center' }),
            column.create('비가동시간(분)', 'NONTIME', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
            column.create('문제점', 'PROBLEM', { width: 150 }),
            column.create('조치사항', 'SOLUTION', { width: 150 }),
            column.create('비고', 'REMARK', { width: 200 }),
            column.create('등록자', 'EMPNM', { width: 100, align: 'center' })
        ]),

        column.split()
    ]);

    /* 설비고장율 현황(EQM1001_S05) 막대 클릭 시 수리 이력 그리드 */
    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.band('설비 수리 이력', {}, [
            column.create('작업장', 'LINECD', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD' }),
            column.create('공정', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100' }),
            column.create('라인', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113' }),
            column.create('설비코드', 'EQMCD', { width: 110, align: 'center' }),
            column.create('설비명', 'EQMNM', { width: 180 }),
            column.create('구분', 'REPGUBUN', { width: 70, align: 'center' }),
            column.create('수리시작', 'REPSTIME', { width: 130, align: 'center' }),
            column.create('수리종료', 'REPETIME', { width: 130, align: 'center' }),
            column.create('수리시간(분)', 'REPMIN', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
            column.create('작업구분', 'WORKTP', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM300' }),
            column.create('고장유형', 'FAILTP', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM307' }),
            column.create('고장부위', 'FAILPART', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM303' }),
            column.create('고장현상', 'MALFUNCTION', { width: 200 }),
            column.create('처리내용', 'HANDLE', { width: 200 })
        ]),

        column.split()
    ]);

    ItsFind.Hide('find_FANO');
};

/* 설비고장율 현황(EQM1001_S05) 막대 클릭으로 열림 (SDATE·EDATE·LINECD·EQMTP·EQMGROUP1·FANO) → 상단 일자·작업장·설비코드(총 라인은 비움)를 넘어온 값으로 채우고 설비 수리 이력 탭 조회 */
ItsPage.onReceiveParam = function (param) {
    if (param == undefined || param.SDATE == undefined) return;

    repLine = { LINECD: param.LINECD, EQMTP: param.EQMTP, EQMGROUP1: param.EQMGROUP1 };
    ItsDateRange.SetValueFrom('dr_DATE', param.SDATE, false);
    ItsDateRange.SetValueTo('dr_DATE', param.EDATE, false);
    ItsCombo.SetValue('cmb_LINECD', param.LINECD);
    ItsFind.SetRef01('find_FANO', param.EQMTP);
    ItsFind.SetRef02('find_FANO', param.EQMGROUP1);
    ItsFind.SetValue('find_FANO', param.FANO || '', false);
    ItsTab.Select('tab1', 1);
    ItsFind.Show('find_FANO');
    setTimeout(function () {
        SEARCH_EQMREP();
    }, 10);
};

/* 설비 수리 이력 조회 (상단 일자·작업장·설비코드, 설비코드 비우면 호출 수리·넣으면 그 설비 공무작업일지 수리, 설비고장율 현황에서 넘어온 라인이면 그 공정·라인만) */
function SEARCH_EQMREP() {
    var maria = new ItsMaria('EQM1001_S03', 'LIST_EQMREP');
    var sameLine = repLine != undefined && repLine.LINECD == ItsCombo.GetValue('cmb_LINECD');
    maria.AddPanel('sdiv1');
    maria.AddParam('EQMTP', sameLine ? repLine.EQMTP : '');
    maria.AddParam('EQMGROUP1', sameLine ? repLine.EQMGROUP1 : '');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid2').autoSizeColumns();
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
}

/* 조회 (설비 수리 이력 탭은 상단 조회조건으로 수리 이력 조회) */
ItsButton.EventSearch = function () {
    if (ItsTab.GetIndex('tab1') == 1) {
        SEARCH_EQMREP();
        return;
    }

    var maria = new ItsMaria('EQM1001_S03', 'LIST_RSTNON');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsGrid.Get('grid1').autoSizeColumns();

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};

// 설비코드 필터는 설비 수리 이력 탭에서만 표시
ItsTab.Event('tab1').onTabChanged = function (newPanel) {
    if (newPanel == 1) {
        ItsFind.Show('find_FANO');
    } else {
        ItsFind.Hide('find_FANO');
    }
};

// 작업장 변경시 공정·라인 콤보를 그 작업장 기준으로 변경
ItsCombo.Event('cmb_LINECD').onChanged = function () {
    ItsFind.SetRef01('find_FANO', '');
    ItsFind.SetRef02('find_FANO', '');
    ItsFind.SetRef05('find_FANO', ItsCombo.GetValue('cmb_LINECD'));

    ItsCombo.SetRef01('cmb_PRCCD', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_PRCCD', '', false);

    ItsCombo.SetRef01('cmb_EQMCD', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMCD', '');
    ItsCombo.SetValue('cmb_EQMCD', '', false);
};

// 공정 변경시 라인 콤보를 그 공정 기준으로 변경
ItsCombo.Event('cmb_PRCCD').onChanged = function () {
    ItsCombo.SetRef02('cmb_EQMCD', ItsCombo.GetValue('cmb_PRCCD'));
    ItsCombo.SetValue('cmb_EQMCD', '', false);
};
