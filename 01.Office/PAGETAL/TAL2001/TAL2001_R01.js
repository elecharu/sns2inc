/// <reference path="../../Script/reference.js" />
// 2026-11-26 그리드 하나로 입력 (검사항목 한 줄, 시료 X1~X10 가로). L/R 유무 항목은 L·R 두 줄
//            검사주기별로 이번 주기에 검사한 항목은 프로시저(LIST_STD)에서 숨김. 저장은 입력한 항목 전체

var MAXSAMPLE = 10;   // 시료 칸 수 (검사기준관리 시료수 1~10)

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    var cols = [
        column.create('검사항목', 'STDNM', { width: 150 }),
        column.create('세부항목', 'STDPART', { width: 100, align: 'center' }),
        column.create('세부공정', 'PRCDETAIL', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PRCDETAIL' }),
        column.create('검사방법', 'STDCHKTP', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP' }),
        column.create('검사규격', 'STDJUDGE', { width: 140 }),
        column.create('검사주기', 'STDCYCLE', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'STDCYCLE' }),
        column.create('진행', 'CYCLEINFO', { width: 50, align: 'center' }),   // 3회/shift: 근무조 안 검사 횟수
        column.create('시료수', 'SAMPLESIZE', { width: 55, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('L/R', 'SIDE', { width: 45, align: 'center' })
    ];
    for (var i = 1; i <= MAXSAMPLE; i++) {
        cols.push(column.create('X' + i, XCOL(i), { width: 70, align: 'right', readOnly: false }));
    }
    cols = cols.concat([
        column.create('판정', 'JUDGENM', { width: 75, align: 'center' }),   // 자동 판정 (측정: 범위, 육안: 시료 칸 OK/NG)
        column.create('합불', 'JUDGE', { width: 100, hidden: true }),
        column.create('검사키', 'TQMRSTKEY', { width: 100, hidden: true }),
        column.create('리비전', 'REVCD', { width: 100, hidden: true }),
        column.create('검사항목코드', 'STDCD', { width: 100, hidden: true }),
        column.create('기준값', 'STDVAL', { width: 100, hidden: true }),
        column.create('범위', 'STDRANGE', { width: 100, hidden: true }),
        column.create('오차(-)', 'STDMINUS', { width: 100, hidden: true }),
        column.create('오차(+)', 'STDPLUS', { width: 100, hidden: true }),
        column.create('L/R 유무', 'LRYN', { width: 100, hidden: true }),
        column.create('줄구분', 'ROWTP', { width: 100, hidden: true }),       // L: 항목 첫 줄, R: L/R 항목의 R 줄
        column.create('항목번호', 'ITEMNO', { width: 100, hidden: true })    // 같은 항목의 L·R 줄을 묶는 번호
    ]);
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false }, cols);

    var grid1 = ItsGrid.Get('grid1');

    // L/R 유무 항목의 L·R 두 줄은 항목 정보·판정 칸을 세로로 합쳐 보여줌 (2026-11-26)
    grid1.allowMerging = wijmo.grid.AllowMerging.Cells;
    grid1.mergeManager = new PRC_MERGE(grid1);

    // 입력할 수 없는 칸은 편집 막음 (측정검사 아님, 시료수 넘는 칸, X 칸이 아닌 열)
    grid1.beginningEdit.addHandler(function (s, e) {
        if (!CAN_EDIT(e.row, s.columns[e.col].binding))
            e.cancel = true;
    });

    // 칸 색: 막힌 시료 칸은 회색, 판정범위를 벗어난 값·불합격은 빨간 글자, R 줄 구분
    grid1.formatItem.addHandler(function (s, e) {
        if (e.panel != s.cells) return;
        var field = s.columns[e.col].binding;
        var item = s.rows[e.row].dataItem;
        if (item == null) return;

        if (XNO(field) > 0) {
            var usable = CAN_INPUT(e.row, field);
            e.cell.style.backgroundColor = !usable ? '#EEEEEE' : (item.STDCHKTP != '02' ? '#EAF3FB' : '');   // 육안 시료 칸: 눌러서 OK/NG
            var v = TEXT(item[field]);
            e.cell.style.color = usable && v != '' && !IS_OK(item, v) ? 'red' : '';
            e.cell.style.fontWeight = usable && v != '' && !IS_OK(item, v) ? 'bold' : '';
        } else if (field == 'JUDGENM') {
            e.cell.style.color = item.JUDGE == 'N' ? 'red' : '';
            e.cell.style.fontWeight = item.JUDGE == 'N' ? 'bold' : '';
        }
    });

    // 육안(측정 아님) 항목 시료 칸을 누르면 OK → NG → 빈칸 (2026-11-26 시료마다 입력), 판정은 자동
    grid1.addEventListener(grid1.hostElement, 'click', function (e) {
        var ht = grid1.hitTest(e);
        if (ht.panel != grid1.cells || ht.row < 0 || ht.col < 0) return;
        var field = grid1.columns[ht.col].binding;
        if (XNO(field) == 0 || !CAN_INPUT(ht.row, field)) return;

        var item = grid1.rows[ht.row].dataItem;
        if (item == null || item.STDCHKTP == '02') return;

        var v = TEXT(item[field]).toUpperCase();
        ItsGrid.SetValue('grid1', ht.row, field, v == 'OK' ? 'NG' : (v == 'NG' ? '' : 'OK'));
        JUDGE_ITEM(L_ROW(ht.row));
    });

    // 엔터: 다음 입력 칸 (같은 줄 다음 시료 → 다음 줄 X1). ItsGrid 는 keyActionEnter 'None' 이라 직접 처리
    grid1.addEventListener(grid1.hostElement, 'keydown', function (e) {
        if (e.keyCode != 13 || grid1.selection.row < 0 || grid1.selection.col < 0)
            return;

        var row = grid1.selection.row;
        var field = grid1.columns[grid1.selection.col].binding;
        if (XNO(field) == 0)
            return;

        e.preventDefault();
        e.stopPropagation();
        grid1.finishEditing(false);   // 입력값 확정 (onChanged 자동 판정)
        EDIT_NEXT(row, XNO(field));
    }, true);

    ItsText.SetValue('txt_TQMTIME', new Date().format('HH:mm'));   // 검사시간 기본값: 지금 시각
};
/**********************************************************************************************************************************************************************/
// 작업장·공정·라인 선택

// 작업장 변경 시 공정·라인 콤보를 그 작업장 기준으로 바꾸고 다시 조회
ItsCombo.Event('cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_PRCCD', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_PRCCD', '', false);

    ItsCombo.SetRef01('cmb_EQMCD', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMCD', '');
    ItsCombo.SetValue('cmb_EQMCD', '', false);

    LIST_STD();
};

// 공정 변경 시 라인 콤보를 그 공정 기준으로 바꾸고 다시 조회
ItsCombo.Event('cmb_PRCCD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('cmb_EQMCD', ItsCombo.GetValue('cmb_PRCCD'));
    ItsCombo.SetValue('cmb_EQMCD', '', false);

    LIST_STD();
};

// 라인 변경 시 다시 조회
ItsCombo.Event('cmb_EQMCD').onChanged = function (value, oldValue) {
    LIST_STD();
};

// 검사시간 엔터 시 그 검사일시로 다시 조회 (주기 확인·저장된 검사값 불러오기 기준)
ItsText.Event('txt_TQMTIME').onKeyEnter = function (value, oldValue) {
    LIST_STD();
};
/**********************************************************************************************************************************************************************/
// 조회

// 라인 생산품, 사용중인 자주검사 리비전의 검사항목 중 이번 주기에 할 항목 + 이 검사일시에 저장한 검사값
LIST_STD = function () {
    ItsText.SetValue('txt_ITEMID', '');
    ItsText.SetValue('txt_ITEMCD', '');
    ItsText.SetValue('txt_ITEMNM', '');
    ItsText.SetValue('txt_ITEMSPEC', '');
    ItsText.SetValue('txt_REVNUM', '');
    ItsGrid.Clear('grid1');

    if (ItsCombo.GetValue('cmb_LINECD') == '' || ItsCombo.GetValue('cmb_PRCCD') == '' || ItsCombo.GetValue('cmb_EQMCD') == '') {
        return;
    }

    var maria = new ItsMaria('TAL2001_R01', 'LIST_STD');
    maria.AddParam('LINECD', ItsCombo.GetValue('cmb_LINECD'));
    maria.AddParam('PRCCD', ItsCombo.GetValue('cmb_PRCCD'));
    maria.AddParam('EQMCD', ItsCombo.GetValue('cmb_EQMCD'));
    maria.AddPanel('div2');     // 검사일자(TQMDATE), 검사시간(TQMTIME)
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    // 라인 생산품 (없으면 빈칸)
    if (maria.store.Length() > 0) {
        ItsText.SetValue('txt_ITEMID', maria.store.data[0]["ITEMID"]);
        ItsText.SetValue('txt_ITEMCD', maria.store.data[0]["ITEMCD"]);
        ItsText.SetValue('txt_ITEMNM', maria.store.data[0]["ITEMNM"]);
        ItsText.SetValue('txt_ITEMSPEC', maria.store.data[0]["ITEMSPEC"]);
        ItsText.SetValue('txt_REVNUM', maria.store.data[0]["REVNUM"] == undefined ? '' : maria.store.data[0]["REVNUM"]);   // 2026-11-26 자주검사 리비전번호
    }

    // 저장된 검사값을 항목별로 모음 (시료 순서 = 저장 순서)
    var saved = {};
    for (var v = 0; v < maria.storeExtend2.Length(); v++) {
        var sv = maria.storeExtend2.data[v];
        var key = sv.STDCD + '|' + sv.STDPART + '|' + sv.PRCDETAIL;
        if (saved[key] == undefined) saved[key] = [];
        saved[key].push(sv);
    }

    // 검사항목 1건 → L 줄 (+ L/R 항목은 R 줄)
    var rows = [];
    var maxSample = 0;
    for (var i = 0; i < maria.storeExtend1.Length(); i++) {
        var std = maria.storeExtend1.data[i];
        var n = Math.min(Number(std.SAMPLESIZE) || 0, MAXSAMPLE);
        if (n > maxSample) maxSample = n;   // 육안 항목도 시료마다 OK/NG (2026-11-26)

        var isLR = std.LRYN == 'Y';
        var values = saved[std.STDCD + '|' + std.STDPART + '|' + std.PRCDETAIL] || [];

        var rowL = $.extend({}, std, { ROWTP: 'L', ITEMNO: i, SIDE: isLR ? 'L' : '' });
        rows.push(rowL);
        var rowR = null;
        if (isLR) {
            rowR = $.extend({}, std, {
                ROWTP: 'R', ITEMNO: i, SIDE: 'R',
                STDNM: '', STDPART: std.STDPART, STDJUDGE: '', STDCYCLE: '', CYCLEINFO: '', SAMPLESIZE: '', JUDGE: '', JUDGENM: ''
            });
            rows.push(rowR);
        }

        // 2026-11-26 육안(OK/NG) 항목인데 이 검사일시에 저장한 적 없으면 시료 칸에 OK 를 미리 넣음
        var okDefault = std.STDCHKTP != '02' && values.length == 0 && TEXT(std.TQMRSTKEY) == '';
        for (var x = 1; x <= MAXSAMPLE; x++) {
            var val = values[x - 1];
            if (okDefault) {
                rowL[XCOL(x)] = x <= n ? 'OK' : '';
                if (rowR != null) rowR[XCOL(x)] = x <= n ? 'OK' : '';
                continue;
            }
            rowL[XCOL(x)] = val == undefined ? '' : TEXT(val.VALUE);
            if (rowR != null) rowR[XCOL(x)] = val == undefined ? '' : TEXT(val.VALUE2);
        }
    }

    ItsGrid.SetStore('grid1', new Store('grid1', rows));

    // OK 를 미리 넣은 육안 항목 판정 (합격)
    for (var j = 0; j < ItsGrid.Length('grid1'); j++) {
        var it = ItsGrid.Get('grid1').rows[j].dataItem;
        if (it.ROWTP == 'L' && it.STDCHKTP != '02' && TEXT(it.TQMRSTKEY) == '') JUDGE_ITEM(j);
    }

    // 시료 칸은 가장 큰 시료수까지만 보임
    var grid1 = ItsGrid.Get('grid1');
    for (var c = 1; c <= MAXSAMPLE; c++) {
        grid1.columns[ItsGrid.$colIndex('grid1', XCOL(c))].visible = c <= Math.max(maxSample, 1);
    }

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.storeExtend1.Length()));

    // 첫 입력 칸으로
    setTimeout(function () { EDIT_NEXT(-1, MAXSAMPLE); }, 10);
};
/**********************************************************************************************************************************************************************/
// 입력·판정

// L·R 두 줄을 세로로 합치는 칸 (검사항목 ~ 시료수, 판정). 같은 항목의 L 줄·R 줄만 합침
var PRC_MERGE_FIELDS = ['STDNM', 'STDPART', 'PRCDETAIL', 'STDCHKTP', 'STDJUDGE', 'STDCYCLE', 'CYCLEINFO', 'SAMPLESIZE', 'JUDGENM'];

PRC_MERGE = function (grid) {
    wijmo.grid.MergeManager.call(this, grid);
};
PRC_MERGE.prototype = Object.create(wijmo.grid.MergeManager.prototype);
PRC_MERGE.prototype.constructor = PRC_MERGE;
PRC_MERGE.prototype.getMergedRange = function (panel, r, c, clip) {
    var g = panel.grid;
    if (panel != g.cells || r < 0 || r >= g.rows.length) return null;
    if (PRC_MERGE_FIELDS.indexOf(g.columns[c].binding) < 0) return null;

    var item = g.rows[r].dataItem;
    if (item == null) return null;
    if (item.ROWTP == 'L' && item.LRYN == 'Y' && r + 1 < g.rows.length && g.rows[r + 1].dataItem.ROWTP == 'R')
        return new wijmo.grid.CellRange(r, c, r + 1, c);
    if (item.ROWTP == 'R' && r > 0)
        return new wijmo.grid.CellRange(r - 1, c, r, c);
    return null;
};

// 시료 칸 이름 (1 → X01)
XCOL = function (no) {
    return 'X' + (no < 10 ? '0' + no : '' + no);
};

// 시료 칸 번호 (X01 → 1, 시료 칸이 아니면 0)
XNO = function (field) {
    var m = /^X(\d\d)$/.exec(field || '');
    return m ? Number(m[1]) : 0;
};

TEXT = function (v) {
    return v == null || v == undefined ? '' : String(v).trim();
};

// 값을 넣을 수 있는 칸: 시료수 안 시료 칸 (측정은 글자 입력, 육안은 눌러서 OK/NG)
CAN_INPUT = function (row, field) {
    var no = XNO(field);
    if (no == 0 || row < 0 || row >= ItsGrid.Length('grid1')) return false;
    if (ItsGrid.Get('grid1').rows[row].dataItem == null) return false;
    return no <= SAMPLE_OF(row);
};

// 글자로 입력하는 칸: 측정검사(02) 항목의 시료 칸
CAN_EDIT = function (row, field) {
    if (!CAN_INPUT(row, field)) return false;
    return ItsGrid.Get('grid1').rows[row].dataItem.STDCHKTP == '02';
};

// 그 줄 항목의 시료수 (R 줄은 같은 항목 L 줄 값)
SAMPLE_OF = function (row) {
    var item = ItsGrid.Get('grid1').rows[row].dataItem;
    var L = item.ROWTP == 'R' ? ItsGrid.Get('grid1').rows[row - 1].dataItem : item;
    return Math.min(Number(L.SAMPLESIZE) || 0, MAXSAMPLE);
};

// 검사값이 판정범위 안인지. 범위 코드(STDRANGE): 01 최대, 02 최소, 03 이상, 04 이내, 05 =, 06 ~ (경계값 포함 합격)
IS_OK = function (item, text) {
    if (item.STDCHKTP != '02') return TEXT(text).toUpperCase() == 'OK';   // 육안: OK 합격, NG 불합격
    var value = Number(text);
    if (isNaN(value)) return false;
    var STDVAL = Number(item.STDVAL), STDMINUS = Number(item.STDMINUS), STDPLUS = Number(item.STDPLUS);
    var STDRANGE = item.STDRANGE;
    if (STDRANGE == '01' || STDRANGE == '04') return value <= STDVAL;
    if (STDRANGE == '02' || STDRANGE == '03') return value >= STDVAL;
    if (STDRANGE == '05') return value == STDVAL;
    if (STDRANGE == '06') return value >= STDVAL + STDMINUS && value <= STDVAL + STDPLUS;
    return true;
};

// 항목의 L 줄 번호 (R 줄이면 바로 위)
L_ROW = function (row) {
    return ItsGrid.GetValue('grid1', row, 'ROWTP') == 'R' ? row - 1 : row;
};

// 판정 표시 (L 줄에만)
SET_JUDGE = function (lrow, judge) {
    ItsGrid.SetValue('grid1', lrow, 'JUDGE', judge);
    ItsGrid.SetValue('grid1', lrow, 'JUDGENM', judge == 'Y' ? '합격' : (judge == 'N' ? '불합격' : ''));
    ItsGrid.Get('grid1').invalidate();
};

// 자동 판정 (측정·육안 모두): 하나라도 벗어나면(육안은 NG) 불합격, 모든 칸(L/R 항목은 L·R 다)이 차고 다 맞으면 합격, 아니면 빈칸
JUDGE_ITEM = function (lrow) {
    var grid1 = ItsGrid.Get('grid1');
    var L = grid1.rows[lrow].dataItem;

    var lines = [L];
    if (L.LRYN == 'Y' && lrow + 1 < grid1.rows.length) lines.push(grid1.rows[lrow + 1].dataItem);

    var n = SAMPLE_OF(lrow);
    var hasNg = false, allEntered = true;
    for (var k = 0; k < lines.length; k++) {
        for (var x = 1; x <= n; x++) {
            var v = TEXT(lines[k][XCOL(x)]);
            if (v == '') allEntered = false;
            else if (!IS_OK(L, v)) hasNg = true;
        }
    }
    SET_JUDGE(lrow, hasNg ? 'N' : (allEntered && n > 0 ? 'Y' : ''));
};

// 검사값 입력 시 그 항목 판정
ItsGrid.Event('grid1').onChanged = function (row, field) {
    if (XNO(field) == 0) return;
    JUDGE_ITEM(L_ROW(row));
};

// 다음 입력 칸: 같은 줄 다음 시료 → 아래 줄들의 X1 (입력 못 하는 줄은 건너뜀)
EDIT_NEXT = function (row, xno) {
    var len = ItsGrid.Length('grid1');
    if (row >= 0 && xno < SAMPLE_OF(row) && CAN_EDIT(row, XCOL(xno + 1))) {
        EDIT_CELL(row, XCOL(xno + 1));
        return;
    }
    for (var r = row + 1; r < len; r++) {
        if (CAN_EDIT(r, XCOL(1))) {
            EDIT_CELL(r, XCOL(1));
            return;
        }
    }
};

// 칸을 입력 상태로 (커서 표시, 태블릿 키보드)
EDIT_CELL = function (row, field) {
    var grid1 = ItsGrid.Get('grid1');
    var col = grid1.columns.getColumn(field).index;
    grid1.select(row, col);
    grid1.focus();
    grid1.startEditing(true, row, col);   // ItsGrid.SelectCell 은 startEditing 이 주석 처리돼 있어 직접 호출
};
/**********************************************************************************************************************************************************************/
// 저장

// 입력한 항목 전체 저장 (시료 칸에 값을 하나라도 넣은 항목, 육안은 OK/NG). 항목마다 SAVE_RST
ItsButton.Event('btn_SAVE').onClick = function () {
    var grid1 = ItsGrid.Get('grid1');
    ItsGrid.Get('grid1').finishEditing(false);

    var targets = [];
    for (var r = 0; r < grid1.rows.length; r++) {
        var L = grid1.rows[r].dataItem;
        if (L.ROWTP != 'L') continue;

        var R = L.LRYN == 'Y' && r + 1 < grid1.rows.length ? grid1.rows[r + 1].dataItem : null;
        var n = SAMPLE_OF(r);

        // 측정·육안 모두 시료마다 값 (육안은 OK/NG, 2026-11-26)
        var any = false, empty = false;
        for (var x = 1; x <= n; x++) {
            var vl = TEXT(L[XCOL(x)]), vr = R == null ? '' : TEXT(R[XCOL(x)]);
            if (vl != '' || vr != '') any = true;
            if (vl == '' || (R != null && vr == '')) empty = true;
        }
        if (!any) continue;   // 입력 안 한 항목은 저장 안 함

        if (empty) {
            ItsMsg.Alert((L.STDCHKTP == '02' ? '검사값을' : 'OK/NG 를') + ' 시료수만큼 모두 입력하세요.' + (R != null ? ' (L·R 둘 다)' : '') + '\n - 검사항목 : ' + L.STDNM + (L.STDPART != '' ? ' / ' + L.STDPART : ''));
            EDIT_FIRST_EMPTY(r);
            return;
        }
        JUDGE_ITEM(r);
        targets.push(r);
    }

    if (targets.length == 0) {
        ItsMsg.Toast('저장할 검사 결과가 없습니다.');
        return;
    }

    ItsMsg.Confirm(targets.length + '개 검사항목을 저장하시겠습니까?', function () {
        for (var t = 0; t < targets.length; t++) {
            var row = targets[t];
            var L = grid1.rows[row].dataItem;
            var R = L.LRYN == 'Y' ? grid1.rows[row + 1].dataItem : null;

            var maria = new ItsMaria('TAL2001_R01', 'SAVE_RST');
            maria.AddParam('LINECD', ItsCombo.GetValue('cmb_LINECD'));
            maria.AddParam('PRCCD', ItsCombo.GetValue('cmb_PRCCD'));
            maria.AddParam('EQMCD', ItsCombo.GetValue('cmb_EQMCD'));
            maria.AddParam('ITEMID', ItsText.GetValue('txt_ITEMID'));
            maria.AddPanel('div2');     // 검사일자(TQMDATE), 검사시간(TQMTIME), 검사자(EMPCD)
            maria.AddParam('REVCD', L.REVCD);
            maria.AddParam('STDCD', L.STDCD);
            maria.AddParam('STDPART', L.STDPART);
            maria.AddParam('PRCDETAIL', L.PRCDETAIL);
            maria.AddParam('SAMPLESIZE', L.SAMPLESIZE);
            maria.AddParam('JUDGE', L.JUDGE);

            var n = SAMPLE_OF(row);
            for (var x = 1; x <= n; x++) {
                maria.AddList('SEQ_LIST', x);
                maria.AddList('VALUE_LIST', TEXT(L[XCOL(x)]));
                maria.AddList('VALUE2_LIST', R == null ? '' : TEXT(R[XCOL(x)]));
            }

            maria.CallProc();
            if (maria.isError) {
                ItsMsg.Alert('[' + L.STDNM + '] 저장 중 오류\n' + maria.errMessage + (t > 0 ? '\n\n앞의 ' + t + '개 항목은 저장되었습니다.' : ''));
                LIST_STD();
                return;
            }
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        LIST_STD();   // 이 검사일시에 저장한 항목·검사값을 다시 보여줌
    });
};

// 항목의 첫 빈 칸으로
EDIT_FIRST_EMPTY = function (lrow) {
    var grid1 = ItsGrid.Get('grid1');
    var L = grid1.rows[lrow].dataItem;
    var lines = L.LRYN == 'Y' ? [lrow, lrow + 1] : [lrow];
    var n = SAMPLE_OF(lrow);
    for (var x = 1; x <= n; x++) {
        for (var k = 0; k < lines.length; k++) {
            if (TEXT(grid1.rows[lines[k]].dataItem[XCOL(x)]) == '') {
                EDIT_CELL(lines[k], XCOL(x));
                return;
            }
        }
    }
};
/**********************************************************************************************************************************************************************/
