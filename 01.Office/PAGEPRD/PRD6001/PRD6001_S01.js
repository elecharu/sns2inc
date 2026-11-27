/// <reference path="../../Script/reference.js" />

// 2026-11-26 점검월 기준 조회로 변경 (B안)
//            위: 설비 목록 (점검월의 점검횟수·점검일수·NG·마지막 점검일, 체크한 설비마다 점검표 1장 출력)
//            아래: 고른 설비의 월간 표 (점검항목 × 1~31일, 수치는 값·OK/NG 는 ○/X, NG 는 빨간 글씨, 칸 더블클릭 → 그날 점검 내용)

var SHEET_FANO = '';    // 월간 표에 보이는 설비
var SHEET_MONTH = '';   // 월간 표의 점검월 (YYYY-MM)

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    // 설비 목록
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, isSubTotalGrid: false }, [
        column.create('작업장', 'LINENM', { width: 80, align: 'center' }),
        column.create('공정', 'EQMTPNM', { width: 60, align: 'center' }),
        column.create('라인', 'EQMGROUP1NM', { width: 60, align: 'center' }),
        column.create('설비코드', 'FANO', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 220 }),
        column.create('점검횟수', 'CHKCNT', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('점검일수', 'CHKDAYS', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('NG', 'NGCNT', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('마지막 점검일', 'LASTDATE', { width: 90, align: 'center' }),
        column.split()
    ]);

    // 월간 표: 점검항목 × 1~31일 (N01~N31 = 그날 NG 여부, 숨김)
    var cols = [
        column.create('순', 'SEQ', { width: 40, align: 'center' }),
        column.create('점검항목', 'CHKLOCNM', { width: 100, align: 'center' }),
        column.create('점검내용', 'CHKKNDNM', { width: 160 }),
        column.create('점검기준', 'CHKSTD', { width: 110, align: 'center' }),
        column.create('주기', 'CHKCYCLENM', { width: 70, align: 'center' })
    ];
    for (var d = 1; d <= 31; d++) {
        cols.push(column.create(String(d), DAY_FIELD('D', d), { width: 62, align: 'center' }));
    }
    for (var n = 1; n <= 31; n++) {
        cols.push(column.create('NG' + n, DAY_FIELD('N', n), { hidden: true }));
    }
    cols.push(column.split());
    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: false }, cols);

    // NG 칸 빨간 글씨
    ItsGrid.Get('grid2').formatItem.addHandler(function (s, e) {
        if (e.panel != s.cells) return;
        var field = s.columns[e.col].binding;
        if (!/^D\d\d$/.test(field)) return;
        if (ItsGrid.GetValue('grid2', e.row, 'N' + field.substr(1)) == 'Y') {
            e.cell.style.color = 'red';
            e.cell.style.fontWeight = 'bold';
        }
    });

    // 그날 점검 이력 (팝업)
    ItsGrid.Create('grid_DAY1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검일자', 'BASEDATE', { width: 90, align: 'center' }),
        column.create('점검시간', 'CHKTIME', { width: 130, align: 'center' }),
        column.create('점검자', 'EMPCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'EMPCD', align: 'center' }),
        column.create('문제점', 'PROBLEM', { width: 400, multiLine: true, readOnly: true }),
        column.create('조치사항', 'SOLUTION', { width: 400, multiLine: true, readOnly: true }),
        column.create('점검키', 'CHKRSTKEY', { width: 120, align: 'center' }),
        column.split()
    ]);

    // 고른 점검의 항목별 값 (팝업)
    ItsGrid.Create('grid_DAY2', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검코드', 'CHKKNDCD', { width: 80, align: 'center' }),
        column.create('점검명', 'CHKKNDNM', { width: 300 }),
        column.create('점검항목', 'CHKLOC', { width: 130, columnType: enumColumnTypes.combo, gpcd: 'CHKLOC', align: 'center' }),
        column.create('점검방법', 'CHKMTH', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'CHKMTH', align: 'center' }),
        column.create('점검값구분', 'CHKVALTP', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP', align: 'center' }),
        column.create('점검값', 'CHKVALUE', { width: 90, align: 'center' }),
        column.create('비고', 'REMARK', { width: 300 }),
        column.split()
    ]);
};

// D01, N31 같은 일자 열 이름
function DAY_FIELD(prefix, day) {
    return prefix + (day < 10 ? '0' : '') + day;
}

// 조회조건 점검월 → YYYY-MM (비면 빈값)
function SEARCH_MONTH() {
    var ym = (ItsMonth.GetValue('mon_SMONTH') || '').replace(/[^0-9]/g, '');
    return ym.length < 6 ? '' : ym.substr(0, 4) + '-' + ym.substr(4, 2);
}

/* 조회: 설비 목록 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');
    SHEET_FANO = '';
    ItsLabel.SetText('lbl_SHEET', '■ 월간 점검표 (칸 더블클릭 → 그날 점검 내용)');

    var maria = new ItsMaria('PRD6001_S01', 'LIST_EQM_MONTH');
    maria.AddPanel('sdiv1');
    maria.AddParam('SMONTH', SEARCH_MONTH());
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    SHEET_MONTH = SEARCH_MONTH();
    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.Get('grid1').autoSizeColumns();
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 설비 선택 → 그 설비의 월간 표
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var fano = ItsGrid.GetValue('grid1', rowIndex, 'FANO');
    if (!fano || !SHEET_MONTH) return;

    var maria = new ItsMaria('PRD6001_S01', 'LIST_MONTH_SHEET');
    maria.AddParam('SMONTH', SHEET_MONTH);
    maria.AddParam('FANO_LIST', fano);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    SHEET_FANO = fano;
    ItsGrid.SetStore('grid2', maria.store);
    ItsLabel.SetText('lbl_SHEET', '■ 월간 점검표 : ' + fano + ' ' + ItsGrid.GetValue('grid1', rowIndex, 'EQMNM')
        + ' (' + SHEET_MONTH + ', 칸 더블클릭 → 그날 점검 내용)');

    // 그 달에 없는 날(29~31일) 열은 숨김
    var parts = SHEET_MONTH.split('-');
    var lastDay = new Date(parseInt(parts[0], 10), parseInt(parts[1], 10), 0).getDate();
    var flex = ItsGrid.Get('grid2');
    for (var d = 29; d <= 31; d++) {
        var col = flex.columns.getColumn(DAY_FIELD('D', d));
        if (col) col.visible = (d <= lastDay);
    }
};

// 월간 표 일자 칸 더블클릭 → 그 설비·그날 점검 이력 팝업
ItsGrid.Event('grid2').onDoubleClick = function (rowIndex, field) {
    if (!/^D\d\d$/.test(field) || !SHEET_FANO) return;

    var date = SHEET_MONTH + '-' + field.substr(1);
    var maria = new ItsMaria('PRD6001_S01', 'LIST_CHKRSTEQM');
    maria.AddParam('SDATE', date);
    maria.AddParam('EDATE', date);
    maria.AddParam('EQMCD', SHEET_FANO);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    if (maria.store.Length() == 0) {
        ItsMsg.Toast(date + ' 에 등록된 점검이 없습니다.');
        return;
    }

    ItsGrid.Clear('grid_DAY2');
    ItsPop.Open('pop_DAY');
    ItsGrid.SetStore('grid_DAY1', maria.store);
};

// 팝업: 점검 이력 선택 → 항목별 값
ItsGrid.Event('grid_DAY1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD6001_S01', 'LIST_CHKRSTEQMKND');
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid_DAY1', rowIndex, 'CHKRSTKEY'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid_DAY2', maria.store);
};

// [점검표 출력] 체크한 설비마다 그 달 점검표 1장 (결과 채움)
ItsButton.Event('btn_PRINT').onClick = function () {
    if (!SHEET_MONTH) {
        ItsMsg.Toast('먼저 조회하세요.');
        return;
    }

    var fanos = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            fanos.push(ItsGrid.GetValue('grid1', i, 'FANO'));
        }
    }
    if (fanos.length == 0) {
        ItsMsg.Toast('출력할 설비를 체크하세요.');
        return;
    }

    var rpt = new ItsXtraRpt('PRD6001_S01');
    rpt.AddParam('SMONTH', SHEET_MONTH);
    rpt.AddParam('FANO_LIST', fanos.join(','));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};
/**********************************************************************************************************************************************************************/
// 조회조건 연동 (작업장 → 공정·라인·설비, 공정 → 라인·설비, 라인 → 설비) - PRD6001_R02 와 같음

ItsCombo.Event('cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);

    // 설비 찾기 (DC_FIND EQMCD: REF05 작업장, REF01 공정, REF02 라인)
    ItsFind.SetRef05('find_EQMCD', ItsCombo.GetValue('cmb_LINECD'));
    ItsFind.SetRef01('find_EQMCD', '');
    ItsFind.SetRef02('find_EQMCD', '');
    ItsFind.SetValue('find_EQMCD', '');
};

ItsCombo.Event('cmb_EQMTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);

    ItsFind.SetRef01('find_EQMCD', ItsCombo.GetValue('cmb_EQMTP'));
    ItsFind.SetRef02('find_EQMCD', '');
    ItsFind.SetValue('find_EQMCD', '');
};

ItsCombo.Event('cmb_EQMGROUP1').onChanged = function (value, oldValue) {
    ItsFind.SetRef02('find_EQMCD', ItsCombo.GetValue('cmb_EQMGROUP1'));
    ItsFind.SetValue('find_EQMCD', '');
};
