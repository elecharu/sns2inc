/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 설비등급별 설비대수 그리드
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('설비등급', 'EQMGRADE', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM110' }),
        column.create('점수기준', 'SCORENM', { width: 90, align: 'center' }),
        column.create('관리구분', 'MNGNM', { width: 90, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE2', { width: 100, align: 'center' }),
        column.create('설비대수', 'EQMCNT', { width: 70, align: 'right', columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.split()
    ]);

    // 설비등급이 없는 행은 '등급없음'으로 표시
    ItsGrid.Get('grid1').formatItem.addHandler(function (s, e) {
        if (e.panel != s.cells || s.columns[e.col].binding != 'EQMGRADE') return;

        if ((ItsGrid.GetValue('grid1', e.row, 'EQMGRADE') || '') == '') {
            e.cell.textContent = '등급없음';
        }
    });

    // 선택 등급의 설비목록 그리드
    ItsGrid.Create('grid2', { isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('작업장', 'LINECD', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'LINECD', allowMerging: true }),
        column.create('공정', 'EQMTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM100', allowMerging: true }),
        column.create('라인', 'EQMGROUP1', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM113', allowMerging: true }),
        column.create('설비그룹', 'EQMGUBUN', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM116', allowMerging: true }),
        column.create('설비코드', 'FANO', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 200 }),
        column.create('설비상태', 'EQMSTT', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FM111' }),
        column.create('설치일자', 'SETDATE', { width: 90, align: 'center' }),
        column.split()
    ]);
};

// 설비등급별 설비대수 조회
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST1005_S02', 'LIST_GRADE');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 설비등급 선택시 해당 등급의 설비목록 조회
ItsGrid.Event('grid1').onSelect = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST1005_S02', 'LIST_EQM');
    maria.AddPanel('sdiv1');
    maria.AddParam('EQMGRADE', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'EQMGRADE'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
};
