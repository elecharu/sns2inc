/* TQM1002_R01: 품질관리 ▶ 출하검사 등록 */
/* 주간출하계획(PRD1001_R04 에서 올린 SALOUTPLAN_W)을 고르면 그 품목의 출하검사 기준으로 검사항목이 나온다. */
/* 검사항목 줄마다 측정치 X1~X10(시료수만큼) 와 판정을 입력하고 [저장]으로 한꺼번에 저장한다 (2026-11-13 사용자 지시, 성적서 양식과 같은 모양). */
/* 측정검사 자동 합불 기준은 자주검사 등록 TAL2001_R01 과 같다. 출하계획 1건 = 검사 1건 */

/// <reference path="../../Script/reference.js" />

var X_FIELDS = ['X1', 'X2', 'X3', 'X4', 'X5', 'X6', 'X7', 'X8', 'X9', 'X10'];   // 측정치 칸 (TQMRSTKND.STDVALCHK ~ STDVALCHK10), 시료수 최대 10

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 주간출하계획 (체크한 계획을 승인)
    ItsGrid.Create('grid1', { isCheckBoxGrid: true }, [
        column.create('출하계획일자', 'OUTDATE', { width: 85, align: 'center' }),
        column.create('구분', 'OUTPLANTPNM', { width: 50, align: 'center' }),
        column.create('거래처', 'CUSTNM', { width: 140 }),
        column.create('고객', 'ENDCUSTNM', { width: 120 }),
        column.create('품번', 'ITEMCD', { width: 130 }),
        column.create('품명', 'ITEMNM', { width: 180 }),
        column.create('리비전', 'REVNUM', { width: 60, align: 'center' }),   // 적용 리비전 (검사 전이면 사용중인 최신)
        column.create('출하수량', 'PLANQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('검사상태', 'INSPSTT', { width: 70, align: 'center' }),   // 미검사 / 검사중 / 합격 / 불합격
        column.create('검사일자', 'TQMDATE', { width: 85, align: 'center' }),
        column.create('검사자', 'EMPNM', { width: 80, align: 'center' }),
        column.create('승인자', 'APRVEMPNM', { width: 80, align: 'center' }),
        column.create('승인일시', 'APRVTIME', { width: 120, align: 'center' }),
        column.create('출하계획키', 'SALOUTPLANKEY', { width: 80, hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 80, hidden: true }),
        column.create('검사키', 'TQMRSTKEY', { width: 80, hidden: true }),
        column.split()
    ]);

    // 검사항목 (출하검사 리비전) + 측정치 X1~X5 + 판정
    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create('검사항목', 'STDNM', { width: 150 }),
        column.create('검사방법', 'STDCHKTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP' }),
        column.create('검사규격', 'STDJUDGE', { width: 150 }),
        column.create('검사게이지', 'STDMACHINE', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDMACHINE' }),
        column.band('측정치', {}, [
            column.create('X1', 'X1', { width: 70, align: 'center', readOnly: false }),
            column.create('X2', 'X2', { width: 70, align: 'center', readOnly: false }),
            column.create('X3', 'X3', { width: 70, align: 'center', readOnly: false }),
            column.create('X4', 'X4', { width: 70, align: 'center', readOnly: false }),
            column.create('X5', 'X5', { width: 70, align: 'center', readOnly: false }),
            column.create('X6', 'X6', { width: 70, align: 'center', readOnly: false }),
            column.create('X7', 'X7', { width: 70, align: 'center', readOnly: false }),
            column.create('X8', 'X8', { width: 70, align: 'center', readOnly: false }),
            column.create('X9', 'X9', { width: 70, align: 'center', readOnly: false }),
            column.create('X10', 'X10', { width: 70, align: 'center', readOnly: false })
        ]),
        // 판정: 측정검사(02)는 측정치로 자동, 그 밖의 항목은 직접 고른다 (기본 합격)
        column.create('판정', 'JUDGE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: "SELECT '합격' AS Label, 'Y' AS Value UNION ALL SELECT '불합격', 'N'", readOnly: false }),
        column.create('리비전', 'REVCD', { width: 100, hidden: true }),
        column.create('검사항목코드', 'STDCD', { width: 100, hidden: true }),
        column.create('공정', 'PRCCD', { width: 100, hidden: true }),
        column.create('기준값', 'STDVAL', { width: 100, hidden: true }),
        column.create('범위', 'STDRANGE', { width: 100, hidden: true }),
        column.create('오차(-)', 'STDMINUS', { width: 100, hidden: true }),
        column.create('오차(+)', 'STDPLUS', { width: 100, hidden: true }),
        column.create('시료수', 'SAMPLESIZE', { width: 60, hidden: true }),   // 검사기준 관리의 시료수 → 측정치 입력칸 수
        column.split()
    ]);

    // 측정치 엔터: X1 → X2 → … → 시료수 칸 → 다음 줄 X1 (ItsGrid 는 keyActionEnter 'None' 이라 직접 처리, TAL2001_R01 과 같은 방식)
    var grid2 = ItsGrid.Get('grid2');
    grid2.addEventListener(grid2.hostElement, 'keydown', function (e) {
        if (e.keyCode != 13 || grid2.selection.row < 0 || grid2.selection.col < 0)
            return;

        var row = grid2.selection.row;
        var x = X_FIELDS.indexOf(grid2.columns[grid2.selection.col].binding);
        if (x == -1)
            return;

        e.preventDefault();
        e.stopPropagation();
        grid2.finishEditing(false);   // 입력값 확정 (onChanged 자동 합불 판정)

        if (x + 1 < SAMPLE_COUNT(row))   // 시료수까지만 (그 뒤 칸은 막힘)
            EDIT_GRID2(row, X_FIELDS[x + 1]);
        else if (row + 1 < ItsGrid.Length('grid2'))
            EDIT_GRID2(row + 1, X_FIELDS[0]);
    }, true);

    // 검사방법이 육안(01)인 줄은 측정치 칸을 OK/NG 선택으로 (2026-11-25 사용자 지시). 그 줄을 편집하는 동안만 칸에 선택목록(dataMap)을 걸고, 끝나면 뺀다
    var OKNG_MAP = new wijmo.grid.DataMap(['OK', 'NG']);
    grid2.beginningEdit.addHandler(function (s, e) {
        var col = s.columns[e.col];
        var xi = X_FIELDS.indexOf(col.binding);
        if (xi == -1)
            return;
        if (xi >= SAMPLE_COUNT(e.row)) {   // 시료수보다 뒤 칸은 입력 불가
            e.cancel = true;
            return;
        }
        col.isRequired = false;   // 빈칸으로 되돌릴 수 있게
        col.dataMap = ItsGrid.GetValue('grid2', e.row, 'STDCHKTP') == '01' ? OKNG_MAP : null;
    });
    grid2.cellEditEnded.addHandler(function (s, e) {
        var col = s.columns[e.col];
        if (X_FIELDS.indexOf(col.binding) > -1)
            col.dataMap = null;
    });

    ItsDateRange.SetValueFrom('dr_DATE', ItsHelper.AddDay(-7, ItsHelper.GetYearMonthDay()));
    ItsDateRange.SetValueTo('dr_DATE', ItsHelper.AddDay(7, ItsHelper.GetYearMonthDay()));

    ItsFind.SetValue('find_APRVEMP', ItsPage.EMPCD);   // 승인자 기본값: 로그인 사원
    ItsCombo.SetValue('cmb_FACTORYCD', '07');   // 공장 기본값 (onChanged 로 품목 find 법인·공장도 들어감)
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('find_ITEMID', companycd);
    ItsFind.SetRef03('find_ITEMID', value);
};

/* 승인: 체크한 출하계획의 검사를 승인자로 승인 (미검사·검사중 계획이 있으면 프로시저가 막는다) */
ItsButton.Event('btn_APPROVE').onClick = function () {
    var APRVEMP = ItsFind.GetValue('find_APRVEMP');
    if (APRVEMP == '') {
        ItsMsg.Alert('승인자를 선택하세요.');
        return;
    }
    if (!ItsGrid.HasChecked('grid1')) {
        ItsMsg.Alert('승인할 출하계획을 체크하세요.');
        return;
    }

    var maria = new ItsMaria('TQM1002_R01', 'APPROVE');
    maria.AddParam('APRVEMP', APRVEMP);
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (!ItsGrid.IsChecked('grid1', i)) continue;
        if (ItsGrid.GetValue('grid1', i, 'INSPSTT') == '불합격') {   // 불합격 검사는 승인할 수 없다 (프로시저도 막는다)
            ItsMsg.Alert('불합격인 출하검사는 승인할 수 없습니다.\n- 품번: ' + ItsGrid.GetValue('grid1', i, 'ITEMCD'));
            return;
        }
        maria.AddList('SALOUTPLANKEY_LIST', ItsGrid.GetValue('grid1', i, 'SALOUTPLANKEY'));
        cnt++;
    }

    ItsMsg.Confirm(cnt + '건을 승인하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(cnt + '건 승인 되었습니다.');
        ItsButton.EventSearch();
    });
};

/* 승인취소: 체크한 출하계획의 승인자·승인일시를 비운다 (승인 안 된 계획이 있으면 프로시저가 막는다) */
ItsButton.Event('btn_APPROVE_CANCEL').onClick = function () {
    if (!ItsGrid.HasChecked('grid1')) {
        ItsMsg.Alert('승인취소할 출하계획을 체크하세요.');
        return;
    }

    var maria = new ItsMaria('TQM1002_R01', 'APPROVE_CANCEL');
    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (!ItsGrid.IsChecked('grid1', i)) continue;
        maria.AddList('SALOUTPLANKEY_LIST', ItsGrid.GetValue('grid1', i, 'SALOUTPLANKEY'));
        cnt++;
    }

    ItsMsg.Confirm(cnt + '건을 승인취소하시겠습니까?', function () {
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Toast(cnt + '건 승인취소 되었습니다.');
        ItsButton.EventSearch();
    });
};

/* 성적서 출력: 체크한 출하계획 중 검사한 것만 검사 1건에 1장 (리포트 TQM1002.exe R01). SALOUTPLANKEYS = 출하계획키 쉼표 구분 */
ItsButton.Event('btn_PRINT_RST').onClick = function () {
    var keys = GET_PRINT_KEYS();
    if (keys.length == 0) return;

    var rpt = new ItsXtraRpt('TQM1002_R01');
    rpt.AddParam('SALOUTPLANKEYS', keys.join(','));
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
    }
};

/* 성적서 엑셀: 출력과 같은 성적서를 엑셀 파일로 받는다 (검사 1건 = 시트 1장). 리포트 TQM1002.exe 가 fileType xlsx 로 만든다 */
ItsButton.Event('btn_PRINT_XLS').onClick = function () {
    var keys = GET_PRINT_KEYS();
    if (keys.length == 0) return;

    var rpt = new ItsXtraRpt('TQM1002_R01');
    rpt.AddParam('SALOUTPLANKEYS', keys.join(','));
    rpt.CallExcel('none');   // 뷰어 없이 파일만 만든다 (rpt.path = 엑셀 주소)
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
        return;
    }
    location.href = rpt.path;
};

/* 체크한 출하계획 중 검사한 것의 출하계획키 (없으면 안내 후 빈 배열) */
function GET_PRINT_KEYS() {
    if (!ItsGrid.HasChecked('grid1')) {
        ItsMsg.Alert('성적서를 출력할 출하계획을 체크하세요.');
        return [];
    }

    var keys = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (!ItsGrid.IsChecked('grid1', i) || ItsGrid.GetValue('grid1', i, 'TQMRSTKEY') == '') continue;   // 검사 안 한 계획은 건너뜀
        keys.push(ItsGrid.GetValue('grid1', i, 'SALOUTPLANKEY'));
    }

    if (keys.length == 0) {
        ItsMsg.Alert('체크한 출하계획 중 검사한 것이 없습니다.');
    }
    return keys;
}

/* 조회: 주간출하계획 (첫 줄이 선택되면서 onSelect 가 검사항목을 불러온다) */
ItsButton.EventSearch = function () {
    ItsText.SetValue('txt_ITEMCD', '');
    ItsText.SetValue('txt_ITEMNM', '');
    ItsText.SetValue('txt_REV', '');
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TQM1002_R01', 'LIST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsGrid.Get('grid1').autoSizeColumns();

    // 불합격은 빨간 글자 (SetStore 가 색을 초기화하므로 그 뒤에)
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.GetValue('grid1', i, 'INSPSTT') == '불합격')
            ItsGrid.SetCellForeColor('grid1', i, 'INSPSTT', '#FF0000');
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};
/**********************************************************************************************************************************************************************/
// 출하계획 선택 → 검사 헤더·검사항목

var LAST_STD_ERR = { key: '', time: 0 };   // 마지막으로 보여 준 검사항목 조회 오류 (같은 오류 반복 방지)

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    ItsText.SetValue('txt_ITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));
    ItsText.SetValue('txt_ITEMNM', ItsGrid.GetValue('grid1', rowIndex, 'ITEMNM'));
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TQM1002_R01', 'LIST_STD');
    var planKey = ItsGrid.GetValue('grid1', rowIndex, 'SALOUTPLANKEY');
    maria.AddParam('SALOUTPLANKEY', planKey);
    maria.CallProc();
    if (maria.isError) {
        // 조회 직후 첫 줄이 자동 선택되면서 그리드가 선택 이벤트를 여러 번 부르므로, 같은 계획의 같은 오류는 잠깐 동안 한 번만 보여 준다
        var now = new Date().getTime();
        if (!(LAST_STD_ERR.key == planKey && now - LAST_STD_ERR.time < 3000)) {
            maria.ShowErrMsg();
        }
        LAST_STD_ERR.key = planKey;
        LAST_STD_ERR.time = now;
        return;
    }

    // 검사 헤더 (검사 전이면 오늘·로그인 사원)
    var HEAD = maria.store.data[0];
    ItsText.SetValue('txt_REV', HEAD.REVNUM == '' ? '' : 'Rev.' + HEAD.REVNUM + (HEAD.REVDATE == '' ? '' : ' (개정일 ' + HEAD.REVDATE + ')'));   // 이 검사에 적용되는 리비전
    if (HEAD.TQMRSTKEY == '') {
        ItsDate.SetValue('date_TQMDATE', ItsHelper.GetYearMonthDay());
        ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
    }
    else {
        ItsDate.SetValue('date_TQMDATE', HEAD.TQMDATE);
        ItsFind.SetValue('find_EMPCD', HEAD.EMPCD);
    }

    // 검사항목
    ItsGrid.SetStore('grid2', maria.storeExtend1);    

    // 판정 기본값(측정검사가 아니고 저장 전이면 합격)과 글자색 (SetStore 가 색을 초기화하므로 그 뒤에, refresh 는 한 번만)
    ItsGrid.Get('grid2').deferUpdate(function () {
        for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
            if (ItsGrid.GetValue('grid2', i, 'JUDGE') == '' && ItsGrid.GetValue('grid2', i, 'STDCHKTP') != '02')
                ItsGrid.SetValue('grid2', i, 'JUDGE', 'Y');
            JUDGE_ROW(i, false);
        }
    });

    APPLY_SAMPLE();
};
/**********************************************************************************************************************************************************************/
// 시료수 (검사기준 관리에서 정한 SAMPLESIZE) → 측정치 입력칸 수

// 그 줄의 측정치 칸 수: 시료수를 1~10 으로 (비었거나 0 이하면 1, X1~X10 이 최대라 10 초과는 10)
SAMPLE_COUNT = function (row) {
    var n = parseInt(ItsGrid.GetValue('grid2', row, 'SAMPLESIZE'), 10);
    if (isNaN(n) || n < 1) return 1;
    return Math.min(n, X_FIELDS.length);
};

// 모든 줄 중 가장 큰 시료수까지만 X 칸을 보이고, 줄마다 시료수 뒤 칸은 회색으로 막는다 (SetStore 뒤에 호출)
APPLY_SAMPLE = function () {
    var grid2 = ItsGrid.Get('grid2');
    var max = 1;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++)
        max = Math.max(max, SAMPLE_COUNT(i));

    for (var x = 0; x < X_FIELDS.length; x++)
        grid2.columns.getColumn(X_FIELDS[x]).visible = x < max;

    grid2.deferUpdate(function () {
        for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
            for (var x = SAMPLE_COUNT(i); x < X_FIELDS.length; x++)
                ItsGrid.SetCellBackColor('grid2', i, X_FIELDS[x], '#E5E5E5');
        }
    });
};
/**********************************************************************************************************************************************************************/
// 측정치·판정

// 측정치를 넣으면 그 줄 판정, 판정을 바꾸면 글자색만
ItsGrid.Event('grid2').onChanged = function (row, field) {
    if (X_FIELDS.indexOf(field) > -1)
        JUDGE_ROW(row, true);
    else if (field == 'JUDGE')
        JUDGE_ROW(row, false);
};

// 한 줄 판정: 측정검사(02)는 측정치를 판정범위로 비교해 벗어난 칸을 빨간 글자로 (setJudge 면 판정도 넣음)
// 판정 기준은 TAL2001_R01 과 같다: 하나라도 벗어나면 불합격, 입력한 값이 다 맞으면 합격, 값이 없으면 빈칸
JUDGE_ROW = function (row, setJudge) {
    if (ItsGrid.GetValue('grid2', row, 'STDCHKTP') == '02') {
        var STDRANGE = ItsGrid.GetValue('grid2', row, 'STDRANGE');
        var STDVAL = Number(ItsGrid.GetValue('grid2', row, 'STDVAL'));
        var STDMINUS = Number(ItsGrid.GetValue('grid2', row, 'STDMINUS'));
        var STDPLUS = Number(ItsGrid.GetValue('grid2', row, 'STDPLUS'));

        // 범위 코드(STDRANGE): 01 최대, 02 최소, 03 이상, 04 이내, 05 =, 06 ~ (경계값 포함 합격)
        var isOk = function (text) {
            var value = Number(text);
            if (isNaN(value)) return false;
            if (STDRANGE == '01' || STDRANGE == '04') return value <= STDVAL;
            if (STDRANGE == '02' || STDRANGE == '03') return value >= STDVAL;
            if (STDRANGE == '05') return value == STDVAL;
            if (STDRANGE == '06') return value >= STDVAL + STDMINUS && value <= STDVAL + STDPLUS;
            return true;
        };

        var hasValue = false, hasNg = false;
        for (var x = 0; x < X_FIELDS.length; x++) {
            var VALUE = String(ItsGrid.GetValue('grid2', row, X_FIELDS[x]) == null ? '' : ItsGrid.GetValue('grid2', row, X_FIELDS[x])).trim();
            var isNg = VALUE != '' && !isOk(VALUE);
            if (VALUE != '') hasValue = true;
            if (isNg) hasNg = true;
            ItsGrid.SetCellForeColor('grid2', row, X_FIELDS[x], isNg ? '#FF0000' : '');
        }

        if (setJudge)
            ItsGrid.SetValue('grid2', row, 'JUDGE', hasNg ? 'N' : (hasValue ? 'Y' : ''));
    }
    // 육안검사(01): 측정치 칸은 OK/NG, NG 가 하나라도 있으면 불합격, OK 만 있으면 합격, 값이 없으면 빈칸 (NG 칸은 빨간 글자)
    else if (ItsGrid.GetValue('grid2', row, 'STDCHKTP') == '01') {
        var hasOk = false, hasNgEye = false;
        for (var x = 0; x < X_FIELDS.length; x++) {
            var EYE = String(ItsGrid.GetValue('grid2', row, X_FIELDS[x]) == null ? '' : ItsGrid.GetValue('grid2', row, X_FIELDS[x])).trim().toUpperCase();
            if (EYE != 'OK' && EYE != 'NG') {
                if (EYE != '') ItsGrid.SetValue('grid2', row, X_FIELDS[x], '');   // OK/NG 외 값은 지움
                ItsGrid.SetCellForeColor('grid2', row, X_FIELDS[x], '');
                continue;
            }
            if (EYE == 'OK') hasOk = true; else hasNgEye = true;
            ItsGrid.SetCellForeColor('grid2', row, X_FIELDS[x], EYE == 'NG' ? '#FF0000' : '');
        }

        if (setJudge && (hasOk || hasNgEye))
            ItsGrid.SetValue('grid2', row, 'JUDGE', hasNgEye ? 'N' : 'Y');
    }

    ItsGrid.SetCellForeColor('grid2', row, 'JUDGE', ItsGrid.GetValue('grid2', row, 'JUDGE') == 'N' ? '#FF0000' : '');
};

// 측정치 칸을 입력 상태로
EDIT_GRID2 = function (row, field) {
    var grid2 = ItsGrid.Get('grid2');
    var col = grid2.columns.getColumn(field).index;
    grid2.select(row, col);
    grid2.focus();
    grid2.startEditing(true, row, col);   // ItsGrid.SelectCell 은 startEditing 이 주석 처리돼 있어 직접 호출
};
/**********************************************************************************************************************************************************************/
// 저장

// 판정이 있는 검사항목 전체의 측정치·판정 저장 (판정이 빈 줄은 저장하지 않음 → 검사상태 '검사중')
ItsButton.Event('btn_SAVE').onClick = function () {
    if (ItsGrid.Length('grid2') == 0) {
        ItsMsg.Alert('출하계획을 선택하세요.');
        return;
    }

    var PLANROW = ItsGrid.GetCurrentIndex('grid1');
    var maria = new ItsMaria('TQM1002_R01', 'SAVE_RST');
    maria.AddParam('SALOUTPLANKEY', ItsGrid.GetValue('grid1', PLANROW, 'SALOUTPLANKEY'));
    maria.AddPanel('div2');     // 검사일자(TQMDATE), 검사자(EMPCD)
    maria.AddParam('REVCD', ItsGrid.GetValue('grid2', 0, 'REVCD'));

    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        var JUDGE = ItsGrid.GetValue('grid2', i, 'JUDGE');
        if (JUDGE != 'Y' && JUDGE != 'N') continue;

        maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid2', i, 'STDCD'));
        maria.AddList('STDPART_LIST', ItsGrid.GetValue('grid2', i, 'STDPART'));
        maria.AddList('PRCCD_LIST', ItsGrid.GetValue('grid2', i, 'PRCCD'));
        maria.AddList('PRCDETAIL_LIST', ItsGrid.GetValue('grid2', i, 'PRCDETAIL'));
        for (var x = 0; x < X_FIELDS.length; x++) {
            var VALUE = ItsGrid.GetValue('grid2', i, X_FIELDS[x]);
            maria.AddList(X_FIELDS[x] + '_LIST', VALUE == null ? '' : $.trim(String(VALUE)));
        }
        maria.AddList('JUDGE_LIST', JUDGE);
        cnt++;
    }

    if (cnt == 0) {
        ItsMsg.Alert('판정한 검사항목이 없습니다.');
        return;
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(cnt));

    // 출하계획 줄에 검사일자·검사자·검사상태 표시
    var HEAD = maria.store.data[0];
    ItsGrid.SetValue('grid1', PLANROW, 'TQMRSTKEY', HEAD.TQMRSTKEY);
    ItsGrid.SetValue('grid1', PLANROW, 'TQMDATE', HEAD.TQMDATE);
    ItsGrid.SetValue('grid1', PLANROW, 'EMPNM', HEAD.EMPNM);
    ItsGrid.SetValue('grid1', PLANROW, 'INSPSTT', HEAD.INSPSTT);
    ItsGrid.SetCellForeColor('grid1', PLANROW, 'INSPSTT', HEAD.INSPSTT == '불합격' ? '#FF0000' : '');
    ItsGrid.Get('grid1').autoSizeColumns();   // 바뀐 검사일자·검사자·검사상태에 맞춰 컬럼 너비 다시 맞춤
};
