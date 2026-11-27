/// <reference path="../../Script/reference.js" />

var TQM_MAXSEQ = 30;   // 검사 회차 열 수 (프로시저 LIST_TQM 의 T01~T30 과 같게)

/* 페이지 로드 */
ItsPage.Load = function () {
    // 작업 목록 (사내공정 작업 1건 = 1줄). 체크한 작업들을 체크시트로 출력
    ItsGrid.Create('grid_PRDWORK', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('생산일자', 'WORKDATE', { width: 90, align: 'center' }),
        column.create('주야구분', 'DNTPNM', { width: 70, align: 'center' }),
        column.create('작업시작', 'WORKSTIME', { width: 130, align: 'center' }),
        column.create('작업종료', 'WORKETIME', { width: 130, align: 'center' }),
        column.create('작업자', 'EMPNM', { width: 150, align: 'center' }),
        column.create('작업장', 'LINENM', { width: 100, align: 'center' }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center' }),
        column.create('라인', 'EQMNM', { width: 120, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 200 }),
        column.create('규격', 'ITEMSPEC', { width: 120 }),
        column.create('검사횟수', 'TQMCNT', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('불합격', 'NGCNT', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('작업키', 'PRDWORKKEY', { width: 100, hidden: true }),
        column.split()
    ]);

    // 자주검사 체크시트 (줄 = 검사항목 × 시료, 열 = 작업 중 검사 회차. 회차 열 제목은 검사시각으로 바꿔 보여준다)
    var columns = [
        column.create('공정', 'PRCDETAILNM', { width: 70, align: 'center' }),
        column.create('검사항목', 'STDNM', { width: 110 }),
        column.create('세부항목', 'STDPART', { width: 90, align: 'center' }),
        column.create('특성', 'FEATURE', { width: 50, align: 'center' }),
        column.create('검사규격', 'STDJUDGE', { width: 150 }),
        column.create('검사주기', 'STDCYCLENM', { width: 80, align: 'center' }),
        column.create('검사게이지', 'STDMACHINENM', { width: 100, align: 'center' }),
        column.create('시료', 'SAMPLENO', { width: 55, align: 'center' })   // L/R 유무 항목은 '1 L' / '1 R' (2026-11-26)
    ];
    for (var i = 1; i <= TQM_MAXSEQ; i++) {
        var no = (i < 10 ? '0' : '') + i;
        columns.push(column.create(i + '회', 'T' + no, { width: 80, align: 'center', hidden: true }));
    }
    columns.push(column.split());
    ItsGrid.Create('grid_TQMRST', { isCheckBoxGrid: false, isSubTotalGrid: false }, columns);

    ItsDateRange.SetInitValueFrom('dateR_WORKDATE', ItsHelper.GetYearMonth() + '-01');
    ItsCombo.SetValue('cmb_FACTORYCD', '07');   // 공장 기본값 (onChanged 로 품목 find 법인·공장도 들어감)
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('find_ITEMID', companycd);
    ItsFind.SetRef03('find_ITEMID', value);
};

/* 작업장 변경: 공정·라인 목록을 작업장 기준으로 */
ItsCombo.Event('cmb_LINECD').onChanged = function (value) {
    ItsCombo.SetRef01('cmb_PRCCD', value);
    ItsCombo.SetValueByIndex('cmb_PRCCD', 0);
    ItsCombo.SetRef01('cmb_EQMCD', value);
    ItsCombo.SetRef02('cmb_EQMCD', '');
    ItsCombo.SetValueByIndex('cmb_EQMCD', 0);
};

/* 공정 변경: 라인 목록을 작업장·공정 기준으로 */
ItsCombo.Event('cmb_PRCCD').onChanged = function (value) {
    ItsCombo.SetRef02('cmb_EQMCD', value);
    ItsCombo.SetValueByIndex('cmb_EQMCD', 0);
};

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid_TQMRST');

    var maria = new ItsMaria('PRD5001_S01', 'LIST_PRDWORK');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDWORK', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

/* 작업 선택: 그 작업 중 자주검사를 체크시트 모양으로 조회 */
ItsGrid.Event('grid_PRDWORK').onSelect = function (rowIndex) {
    ItsGrid.Clear('grid_TQMRST');

    var maria = new ItsMaria('PRD5001_S01', 'LIST_TQM');
    maria.AddParam('PRDWORKKEY', ItsGrid.GetValue('grid_PRDWORK', rowIndex, 'PRDWORKKEY'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    // 검사 회차 수만큼 열을 보이고, 열 제목을 검사시각으로 (선례 PRD1001_R03.js)
    var grid = ItsGrid.Get('grid_TQMRST');
    var seqCount = maria.storeExtend1.Length();
    for (var i = 1; i <= TQM_MAXSEQ; i++) {
        var field = 'T' + (i < 10 ? '0' : '') + i;
        var col = grid.columns[ItsGrid.$colIndex('grid_TQMRST', field)];
        col.visible = i <= seqCount;
        col.header = i <= seqCount ? maria.storeExtend1.data[i - 1]['HHMM'] : i + '회';
    }

    ItsGrid.SetStore('grid_TQMRST', maria.storeExtend2);

    // 불합격 회차 값은 빨간 글자 (N01~N30 = 'Y'). SetCellForeColor 가 호출마다 다시 그리므로 묶어서 한 번에
    grid.deferUpdate(function () {
        for (var r = 0; r < ItsGrid.Length('grid_TQMRST'); r++) {
            for (var k = 1; k <= seqCount; k++) {
                var no = (k < 10 ? '0' : '') + k;
                if (ItsGrid.GetValue('grid_TQMRST', r, 'N' + no) == 'Y') {
                    ItsGrid.SetCellForeColor('grid_TQMRST', r, 'T' + no, '#FF0000');
                }
            }
        }
    });
};

/* [자주검사 체크시트 출력] → 체크한 작업마다 체크시트를 한 PDF 로 (04.Report\PAGEPRD\PRD5001 S01). PRDWORKKEYS = 작업키 쉼표 구분 */
ItsButton.Event('btn_PRINT_CHECK').onClick = function () {
    if (!ItsGrid.HasChecked('grid_PRDWORK')) {
        ItsMsg.Alert('출력할 작업을 체크하세요.');
        return;
    }

    var keys = [];
    for (var i = 0; i < ItsGrid.Length('grid_PRDWORK'); i++) {
        if (!ItsGrid.IsChecked('grid_PRDWORK', i)) continue;
        keys.push(ItsGrid.GetValue('grid_PRDWORK', i, 'PRDWORKKEY'));
    }

    var rpt = new ItsXtraRpt('PRD5001_S01');
    rpt.AddParam('PRDWORKKEYS', keys.join(','));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
