/// <reference path="../../Script/reference.js" />

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
};

/* 조회 */
ItsButton.EventSearch = function () {
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

// 작업장 변경시 공정·라인 콤보를 그 작업장 기준으로 변경
ItsCombo.Event('cmb_LINECD').onChanged = function () {
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
