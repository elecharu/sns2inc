/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    
    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: true, allowMerging: 'Cells', groupField: 'LINENM' }, [
        column.create("작업장코드", "LINECD", { width: 100, align: 'center', hidden: true }),
        column.create("작업장", "LINENM", { width: 100, align: 'center', allowMerging: true }),
        column.create("설비구분", "EQMTP", { width: 100, align: 'center', allowMerging: true }),
        column.create("설비대분류", "EQMGROUP1", { width: 100, align: 'center', allowMerging: true }),
        column.create("설비중분류", "EQMGROUP2", { width: 100, align: 'center', allowMerging: true }),
        column.create("설비소분류", "EQMGROUP3", { width: 100, align: 'center', allowMerging: true }),
        column.create("설비코드", "EQMCD", { width: 100, align: 'center', hidden: true }),
        column.create("설비", "EQMNM", { width: 200, allowMerging: true }),
        column.create("사원코드", "EMPCD", { width: 100, align: 'center' }),
        column.create("사원명", "EMPNM", { width: 100, align: 'center' }),
        column.create("호출도착 지연시간(분)", "DELAYMIN_ARRIVE", { width: 150, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create("수리종료 지연시간(분)", "DELAYMIN_REPAIR", { width: 150, align: 'center', columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create("사원ID", "EMPCD", { width: 100, align: 'center', hidden: true }),
        column.create("사원코드", "EMPCD", { width: 100, align: 'center', hidden: true }),
        column.create("사원명", "EMPNM", { width: 100, align: 'center' }),
        column.create("부서명", "DEPTCD", { width: 100, align: 'center' }),
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    var maria = new ItsMaria('MST1004_R01', 'LIST_EQM_CALLEMP');
    maria.AddPanel('pdiv2');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
};

ItsButton.EventAdd = function () {
    ItsPage.InitData('pdiv4');
    ItsPop.Open('pop1');
    ItsButton.Event('btn_SEARCH').onClick();
}

ItsPop.Event('pop1').onAddBtnClick = function () {

    // 1) 체크된 사원ID 수집
    var empIds = [];
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            empIds.push(ItsGrid.GetValue('grid2', i, 'EMPCD'));
        }
    }

    // 2) 입력 검증
    if (empIds.length == 0) {
        ItsMsg.Alert('등록할 사원을 선택하세요.');
        return;
    }

    if (lineVal() == '' && tpVal() == '' && g1Val() == '' && g2Val() == ''
        && g3Val() == '' && (ItsFind.GetValue('find_FANO') || '') == '') {
        ItsMsg.Alert('작업장, 설비구분, 설비분류, 설비번호 중 하나 이상 입력하세요.');
        return;
    }

    // 3) 등록 여부 확인 → "예"를 눌렀을 때만 저장
    ItsMsg.Confirm(empIds.length + '명의 사원을 선택한 설비에 등록하시겠습니까?', function () {

        var maria = new ItsMaria('MST1004_R01', 'INS_EQM_CALLEMP');
        maria.AddPanel('pdiv4');

        for (var j = 0; j < empIds.length; j++) {
            maria.AddList('EMPCD_LIST', empIds[j]);
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('pop1');
        ItsButton.EventSearch();
    });
};

// ── 저장 ─────────────────────────────────────────────────
ItsButton.EventSave = function () {

    var list = [];
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            list.push({
                eqmcd: ItsGrid.GetValue('grid1', i, 'EQMCD'),
                empcd: ItsGrid.GetValue('grid1', i, 'EMPCD'),
                arrive: Math.trunc(Number(ItsGrid.GetValue('grid1', i, 'DELAYMIN_ARRIVE'))),
                repair: Math.trunc(Number(ItsGrid.GetValue('grid1', i, 'DELAYMIN_REPAIR')))
            });
        }
    }

    // 2) 입력 검증
    if (list.length == 0) {
        ItsMsg.Alert('수정할 행을 체크하세요.');
        return;
    }

    for (var k = 0; k < list.length; k++) {
        var a = Number(list[k].arrive);
        var r = Number(list[k].repair);
        if (isNaN(a) || isNaN(r) || a < 0 || r < 0) {
            ItsMsg.Alert('지연시간은 0 이상의 숫자로 입력하세요.');
            return;
        }
    }

    // 3) 저장 여부 확인 → "예"를 눌렀을 때만 저장
    ItsMsg.Confirm(list.length + '건을 저장하시겠습니까?', function () {

        var maria = new ItsMaria('MST1004_R01', 'UPD_EQM_CALLEMP');

        for (var j = 0; j < list.length; j++) {
            maria.AddList('EQMCD_LIST', list[j].eqmcd);
            maria.AddList('EMPCD_LIST', list[j].empcd);
            maria.AddList('DELAYMIN_ARRIVE_LIST', list[j].arrive);
            maria.AddList('DELAYMIN_REPAIR_LIST', list[j].repair);
        }

        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.SaveComplete(list.length));
        ItsButton.EventSearch();
    });
};

// ── 삭제 ─────────────────────────────────────────────────
ItsButton.EventDelete = function () {

    var list = [];

    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.IsChecked('grid1', i)) {
            list.push({
                eqmcd: ItsGrid.GetValue('grid1', i, 'EQMCD'),
                empcd: ItsGrid.GetValue('grid1', i, 'EMPCD')
            });
        }
    }

    // 1) 삭제 대상 검증
    if (list.length == 0) {
        ItsMsg.Alert('삭제할 행을 체크하세요.');
        return;
    }

    // 2) 삭제 여부 확인
    ItsMsg.Confirm(list.length + '건을 삭제하시겠습니까?', function () {

        var maria = new ItsMaria('MST1004_R01', 'DEL_EQM_CALLEMP');

        for (var j = 0; j < list.length; j++) {
            maria.AddList('EQMCD_LIST', list[j].eqmcd);
            maria.AddList('EMPCD_LIST', list[j].empcd);
        }

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Alert(ItsMsg.CommonMsg.DeleteComplete(list.length));
        ItsButton.EventSearch();
    });
};

ItsButton.Event('btn_SEARCH').onClick = function () {

    var maria = new ItsMaria('MST1004_R01', 'LIST_EMP');
    maria.AddPanel('pdiv2');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
}

// ============================================================
// 설비 조회조건 연쇄 처리
// 작업장 → 설비구분 → 대분류 → 중분류 → 소분류 → 설비번호
//
// 상위 값이 바뀌면
//   1) 그 아래 단계의 선택값을 모두 비우고
//   2) 비워진 값 기준으로 REF를 다시 세팅하며 목록을 재조회한다.
// ============================================================

// ── 현재 값 읽기 (비어 있으면 '') ─────────────────────────────
function lineVal() { return ItsFind.GetValue('find_LINECD') || ''; }
function tpVal() { return ItsCombo.GetValue('cb_EQMTP') || ''; }
function g1Val() { return ItsCombo.GetValue('cb_EQMGROUP1') || ''; }
function g2Val() { return ItsCombo.GetValue('cb_EQMGROUP2') || ''; }
function g3Val() { return ItsCombo.GetValue('cb_EQMGROUP3') || ''; }

// ── 대상별 refresh : 현재 상위 값 전체를 읽어 REF에 세팅 ────────
// 마지막 SetRef만 목록 재조회, 앞의 것은 false = 속성만 변경
function refreshEqmtp() {
    ItsCombo.SetRef01('cb_EQMTP', lineVal());
}

function refreshEqmGroup1() {
    ItsCombo.SetRef01('cb_EQMGROUP1', lineVal(), false);
    ItsCombo.SetRef02('cb_EQMGROUP1', tpVal());
}

function refreshEqmGroup2() {
    ItsCombo.SetRef01('cb_EQMGROUP2', lineVal(), false);
    ItsCombo.SetRef02('cb_EQMGROUP2', tpVal(), false);
    ItsCombo.SetRef03('cb_EQMGROUP2', g1Val());
}

function refreshEqmGroup3() {
    ItsCombo.SetRef01('cb_EQMGROUP3', lineVal(), false);
    ItsCombo.SetRef02('cb_EQMGROUP3', tpVal(), false);
    ItsCombo.SetRef03('cb_EQMGROUP3', g1Val(), false);
    ItsCombo.SetRef04('cb_EQMGROUP3', g2Val());
}

function refreshFano() {
    ItsFind.SetRef01('find_FANO', tpVal(), false);
    ItsFind.SetRef02('find_FANO', g1Val(), false);
    ItsFind.SetRef03('find_FANO', g2Val(), false);
    ItsFind.SetRef04('find_FANO', g3Val(), false);
    ItsFind.SetRef05('find_FANO', lineVal());
}

// ── 단계 정의 (위에서 아래 순서, 두 배열의 순서를 맞출 것) ──────
var REFRESH_CHAIN = [
    refreshEqmtp,       // 0 : 설비구분
    refreshEqmGroup1,   // 1 : 대분류
    refreshEqmGroup2,   // 2 : 중분류
    refreshEqmGroup3,   // 3 : 소분류
    refreshFano         // 4 : 설비번호
];

var CHAIN_CONTROLS = [
    { api: ItsCombo, id: 'cb_EQMTP' },
    { api: ItsCombo, id: 'cb_EQMGROUP1' },
    { api: ItsCombo, id: 'cb_EQMGROUP2' },
    { api: ItsCombo, id: 'cb_EQMGROUP3' },
    { api: ItsFind, id: 'find_FANO' }
];

// ── 값 초기화 (onChanged 발생 X) ──────────────────────────────
function clearValue(ctrl) {
    if (typeof ctrl.api.SetValue === 'function') {
        ctrl.api.SetValue(ctrl.id, '', false);
    }
}

// ── index 단계부터 끝까지: 비우기 → REF 세팅/재조회 ─────────────
function refreshFrom(index) {
    var i;

    // 1) 하위 값 먼저 전부 비움
    for (i = index; i < CHAIN_CONTROLS.length; i++) {
        clearValue(CHAIN_CONTROLS[i]);
    }
    // 2) 비워진 값 기준으로 REF 세팅 + 목록 재조회
    for (i = index; i < REFRESH_CHAIN.length; i++) {
        REFRESH_CHAIN[i]();
    }
}

// ── 이벤트 연결 : 바뀐 컨트롤의 "아래 단계"부터 갱신 ─────────────
ItsFind.Event('find_LINECD').onChanged = function () { refreshFrom(0); };
ItsCombo.Event('cb_EQMTP').onChanged = function () { refreshFrom(1); };
ItsCombo.Event('cb_EQMGROUP1').onChanged = function () { refreshFrom(2); };
ItsCombo.Event('cb_EQMGROUP2').onChanged = function () { refreshFrom(3); };
ItsCombo.Event('cb_EQMGROUP3').onChanged = function () { refreshFrom(4); };