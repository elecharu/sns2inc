/// <reference path="../../Script/reference.js" />

// 월별 현황 조회 데이터 및 선택 상태
var CYCLE_DATA = [];
var SEL_MONTH = '';
var SEL_EQMCD = '';

// 점검값 입력 팝업 대상 그리드 및 행 인덱스
var KEYPAD_GRID = 'grid3';
var KEYPAD_ROW = -1;

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 점검이력 그리드 생성 (우클릭 메뉴 비활성화)
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false, contextMenu: false }, [
        column.create('점검일자', 'BASEDATE', { width: 110, align: 'center' }),
        column.create('점검유형', 'CHKTP', { width: 90, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKTP' }),
        column.create('점검자', 'EMPNM', { width: 90, align: 'center' }),
        column.create('점검상태', 'STATUS', { width: 90, align: 'center' }),
        column.create('문제점', 'PROBLEM', { width: 150 }),
        column.create('조치사항', 'SOLUTION', { width: 150 }),
        column.create('점검월', 'YYYYMM', { hidden: true }),
        column.create('점검자코드', 'EMPCD', { hidden: true }),
        column.create('점검키', 'CHKRSTKEY', { hidden: true }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: false, contextMenu: false }, CREATE_ITEM_COLUMNS(false));
    ItsGrid.Create('grid3', { isCheckBoxGrid: false, isSubTotalGrid: false, contextMenu: false }, CREATE_ITEM_COLUMNS(true));
    ItsGrid.Create('grid4', { isCheckBoxGrid: false, isSubTotalGrid: false, contextMenu: false }, CREATE_ITEM_COLUMNS(true));
    BIND_ITEM_INPUT_CLICK('grid3');
    BIND_ITEM_INPUT_CLICK('grid4');

    SEL_MONTH = ('0' + (new Date().getMonth() + 1)).slice(-2);

    // 조회년도 기본값 선택
    ItsCombo.SetValueByIndex('cmb_SYEAR', 4);
};

// 점검항목 그리드 컬럼 생성
function CREATE_ITEM_COLUMNS(isEdit) {
    return [
        column.create('적용 REV', 'REVNM', { width: 90, align: 'center' }),
        column.create('계획구분', 'PLANTP', { hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { hidden: true }),
        column.create('점검명', 'CHKKNDNM', { width: 180 }),
        column.create('점검항목', 'CHKLOC', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKLOC' }),
        column.create('점검방법', 'CHKMTH', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKMTH' }),
        column.create('점검값구분', 'CHKVALTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP' }),
        column.create('점검값', 'CHKVALUE', isEdit ? { width: 90, align: 'center', backColor: '#FFFFFF' } : { width: 90, align: 'center' }),
        column.create('특이사항', 'REMARK', { width: 200, readOnly: !isEdit }),
    ];
}

// 그리드 컬럼 너비 자동 맞춤
function AUTO_SIZE_GRID(gridId) {
    var grid = ItsGrid.Get(gridId);
    grid.autoSizeColumns();
}

// 버튼 동작 가능 여부 확인
function CHECK_ACTION(action) {
    if (!SEL_EQMCD) {
        ItsMsg.Alert('설비를 먼저 선택하세요.');
        return false;
    }

    var month = parseInt(SEL_MONTH, 10) + '월';
    var status = GET_STATUS(SEL_EQMCD);

    if (action == 'REG') {
        if (status == '점검완료') {
            ItsMsg.Alert(month + ' 정기점검이 이미 등록되어 있습니다. [수정]으로 고쳐주세요.');
            return false;
        }
        return true;
    }

    if (status != '점검완료') {
        ItsMsg.Alert(month + ' 정기점검이 아직 등록되지 않았습니다. [점검]으로 먼저 등록해주세요.');
        return false;
    }
    return true;
}

// 사원명 표시 처리
function SET_FIND_NAME(findId, name) {
    if (name && !ItsFind.GetNameValue(findId)) {
        $('input#' + findId).siblings('.ItsFind_name').val(name);
    }
}

// 선택 년월 반환 (YYYY-MM)
function GET_YYYYMM() {
    return ItsCombo.GetValue('cmb_SYEAR') + '-' + SEL_MONTH;
}

// 선택 설비의 선택 월 점검상태 반환
function GET_STATUS(eqmCd) {
    for (var i = 0; i < CYCLE_DATA.length; i++) {
        if (CYCLE_DATA[i].EQMCD == eqmCd) {
            return CYCLE_DATA[i]['M' + SEL_MONTH];
        }
    }
    return '';
}

// 선택 설비의 선택 월 배정 점검자 반환
function GET_PLAN_EMP(eqmCd) {
    for (var i = 0; i < CYCLE_DATA.length; i++) {
        if (CYCLE_DATA[i].EQMCD == eqmCd) {
            return {
                EMPCD: CYCLE_DATA[i]['M' + SEL_MONTH + 'EMPCD'],
                EMPNM: CYCLE_DATA[i]['M' + SEL_MONTH + 'EMPNM']
            };
        }
    }
    return { EMPCD: '', EMPNM: '' };
}

/* 월별 현황 및 설비 카드 */
// 월별 정기점검 현황 조회
function SEARCH_CYCLE() {
    var maria = new ItsMaria('TAL0001_R08', 'LIST_CYCLE_EQMCD');
    maria.AddParam('SYEAR', ItsCombo.GetValue('cmb_SYEAR'));
    maria.AddParam('EQMCD', ItsFind.GetValue('find_EQMCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    CYCLE_DATA = maria.store.data;
    RENDER_MONTH();
    RENDER_EQM();
}

// 1~12월 탭 렌더링
function RENDER_MONTH() {
    var html = '';
    for (var m = 1; m <= 12; m++) {
        var mm = ('0' + m).slice(-2);
        html += '<button type="button" class="month-btn' + (mm == SEL_MONTH ? ' active' : '') + '" data-month="' + mm + '">' + m + '월</button>';
    }
    $('#MONTH_LIST').html(html);
}

// 선택 월 점검 대상 설비 카드 렌더링
function RENDER_EQM() {
    var html = '';
    var hasSelected = false;

    CYCLE_DATA.forEach(function (row) {
        var status = row['M' + SEL_MONTH];
        if (status == '') {
            return;
        }
        if (row.EQMCD == SEL_EQMCD) {
            hasSelected = true;
        }
        html += '<button type="button" class="eqm-btn ' + (status == '점검완료' ? 'done' : 'need') + (row.EQMCD == SEL_EQMCD ? ' active' : '') + '"'
            + ' data-eqmcd="' + row.EQMCD + '" title="' + status + '">'
            + '<span class="eqm-cd">' + row.EQMCD + '</span>'
            + '<span class="eqm-nm">' + (row.EQMNM || '') + '</span>'
            + '</button>';
    });

    if (html == '') {
        html = '<span class="eqm-empty">' + parseInt(SEL_MONTH, 10) + '월 정기점검 대상 설비가 없습니다.</span>';
    }
    $('#EQM_LIST').html(html);

    if (!hasSelected) {
        SEL_EQMCD = '';
    }
    LOAD_DETAIL();
}

// 조회년도 변경 이벤트
ItsCombo.Event('cmb_SYEAR').onChanged = function (value, oldValue) {
    SEARCH_CYCLE();
};

// 설비 선택 변경 이벤트
ItsFind.Event('find_EQMCD').onChanged = function (value, oldValue) {
    SEARCH_CYCLE();
};

// 월 탭 클릭 이벤트
$(document).on('click', '#MONTH_LIST .month-btn', function () {
    SEL_MONTH = $(this).attr('data-month');
    $('#MONTH_LIST .month-btn').removeClass('active');
    $(this).addClass('active');
    RENDER_EQM();
});

// 설비 카드 클릭 이벤트
$(document).on('click', '#EQM_LIST .eqm-btn', function () {
    SEL_EQMCD = $(this).attr('data-eqmcd');
    $('#EQM_LIST .eqm-btn').removeClass('active');
    $(this).addClass('active');
    LOAD_DETAIL();
});

// 조회 버튼 클릭 이벤트
ItsButton.Event('btn_SEARCH').onClick = function () {
    SEARCH_CYCLE();
};

/* 선택 설비 상세 정보 조회 */
// 선택 설비의 점검 실적 또는 계획 상세 조회
function LOAD_DETAIL() {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    var status = GET_STATUS(SEL_EQMCD);
    if (status == '') {
        return;
    }

    var yyyymm = GET_YYYYMM();
    var maria;
    if (status == '점검완료') {
        maria = new ItsMaria('TAL0001_R08', 'SEARCH_CHKRSTEQM');
        maria.AddParam('EQMCD', SEL_EQMCD);
        maria.AddParam('YYYYMM', yyyymm);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }
        var rst = maria.store.data[0];
        ItsGrid.SetStore('grid1', {
            data: [{
                YYYYMM: yyyymm, CHKTP: '02', STATUS: status, BASEDATE: rst.BASEDATE, EMPCD: rst.EMPCD, EMPNM: rst.EMPNM || rst.EMPCD,
                CHKRSTKEY: rst.CHKRSTKEY, PROBLEM: rst.PROBLEM || '', SOLUTION: rst.SOLUTION || ''
            }]
        });
        ItsGrid.SetStore('grid2', maria.storeExtend1);
    } else {
        maria = new ItsMaria('TAL0001_R08', 'LIST_PLAN_EQM02');
        maria.AddParam('EQMCD', SEL_EQMCD);
        maria.AddParam('YYYYMM', yyyymm);
        maria.CallProc();
        // 배정 점검자 정보 바인딩
        var planEmp = GET_PLAN_EMP(SEL_EQMCD);
        ItsGrid.SetStore('grid1', {
            data: [{
                YYYYMM: yyyymm, CHKTP: '02', STATUS: status,
                EMPCD: planEmp.EMPCD, EMPNM: planEmp.EMPNM || planEmp.EMPCD
            }]
        });
        if (!maria.isError) {
            ItsGrid.SetStore('grid2', maria.store);
        }
    }
    AUTO_SIZE_GRID('grid1');
    AUTO_SIZE_GRID('grid2');
}

/* 점검 등록 */
// 점검 등록 팝업 오픈
ItsButton.Event('btn_REG').onClick = function () {
    if (!CHECK_ACTION('REG')) {
        return;
    }
    var yyyymm = GET_YYYYMM();
    var maria = new ItsMaria('TAL0001_R08', 'LIST_PLAN_EQM02');
    maria.AddParam('EQMCD', SEL_EQMCD);
    maria.AddParam('YYYYMM', yyyymm);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var today = ItsHelper.GetYearMonthDay();
    var plan = maria.store.data[0];

    ItsPage.InitData('pdiv1');
    ItsFind.SetValue('pop1_find_EQMCD', SEL_EQMCD);
    ItsDate.SetValue('pop1_date_BASEDATE', today.substr(0, 7) == yyyymm ? today : yyyymm + '-01');
    ItsText.SetValue('pop1_txt_YYYYMM', yyyymm);
    ItsText.SetValue('pop1_txt_REVCD', plan.EQMREVCD);
    ItsText.SetValue('pop1_txt_GRPREVCD', plan.GRPREVCD);
    if (plan.PLANEMPCD) {
        ItsFind.SetValue('pop1_find_EMPCD', plan.PLANEMPCD);
        SET_FIND_NAME('pop1_find_EMPCD', plan.PLANEMPNAME);
    } else if (plan.PLANEMPNM) {
        ItsMsg.Toast('주기관리 점검자(' + plan.PLANEMPNM + ')를 사원 목록에서 찾지 못했습니다. 점검자를 직접 선택해주세요.');
    }

    ItsGrid.SetStore('grid3', maria.store);
    ItsPop.Open('pop1');
    AUTO_SIZE_GRID('grid3');
};

// 점검 등록 저장
ItsPop.Event('pop1').onAddBtnClick = function () {
    ItsGrid.Get('grid3').finishEditing();
    var maria = new ItsMaria('TAL0001_R08', 'ADD_CHKRSTEQM');
    maria.AddPanel('pdiv1');
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
        maria.AddList('PLANTP_LIST', ItsGrid.GetValue('grid3', i, 'PLANTP'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue('grid3', i, 'CHKVALUE'));
        maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid3', i, 'REMARK'));
    }
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop1');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    SEARCH_CYCLE();
};

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};

/* 점검 수정 및 삭제 */
// 점검 수정 팝업 오픈
ItsButton.Event('btn_EDIT').onClick = function () {
    if (!CHECK_ACTION('EDIT')) {
        return;
    }
    var maria = new ItsMaria('TAL0001_R08', 'SEARCH_CHKRSTEQM');
    maria.AddParam('EQMCD', SEL_EQMCD);
    maria.AddParam('YYYYMM', GET_YYYYMM());
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPage.InitData('pdiv2');
    ItsPage.SetStore('pdiv2', maria.store.data[0]);
    SET_FIND_NAME('pop2_find_EMPCD', maria.store.data[0].EMPNM);
    ItsGrid.SetStore('grid4', maria.storeExtend1);
    ItsPop.Open('pop2');
    AUTO_SIZE_GRID('grid4');
};

// 점검 수정 저장
ItsPop.Event('pop2').onAddBtnClick = function () {
    ItsGrid.Get('grid4').finishEditing();
    var maria = new ItsMaria('TAL0001_R08', 'SAVE_CHKRSTEQM');
    maria.AddPanel('pdiv2');
    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid4', i, 'CHKKNDCD'));
        maria.AddList('PLANTP_LIST', ItsGrid.GetValue('grid4', i, 'PLANTP'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue('grid4', i, 'CHKVALUE'));
        maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid4', i, 'REMARK'));
    }
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop2');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    SEARCH_CYCLE();
};

ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
};

// 점검 실적 삭제
ItsButton.Event('btn_DELETE').onClick = function () {
    if (!CHECK_ACTION('DELETE')) {
        return;
    }
    var CHKRSTKEY = ItsGrid.GetValue('grid1', 0, 'CHKRSTKEY');

    ItsMsg.Confirm('선택한 정기점검 실적을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('TAL0001_R08', 'DELETE_CHKRSTEQM');
        maria.AddParam('CHKRSTKEY', CHKRSTKEY);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        SEARCH_CYCLE();
    });
};

/* 점검값 입력 */
// 점검값 입력 팝업 오픈 (OK/NG 및 숫자패드 분기)
function OPEN_ITEM_INPUT(gridId, rowIndex, field) {
    if (field != 'CHKVALUE') {
        return;
    }
    KEYPAD_GRID = gridId;
    KEYPAD_ROW = rowIndex;

    if (ItsGrid.GetValue(gridId, rowIndex, 'CHKVALTP') == '03') {
        ItsPop.Open('pop_OK');
    } else {
        ItsText.SetValue('txt_VALUE_TAL0001_R08', '');
        ItsPop.Open('pop_NUM');
    }
}

// 점검값 셀 클릭 이벤트 바인딩
function BIND_ITEM_INPUT_CLICK(gridId) {
    var grid = ItsGrid.Get(gridId);
    grid.hostElement.addEventListener('click', function (e) {
        var ht = grid.hitTest(e);
        if (ht.cellType != wijmo.grid.CellType.Cell) {
            return;
        }
        OPEN_ITEM_INPUT(gridId, ht.row, grid.columns[ht.col].binding);
    });
}

// 숫자패드 입력 처리
function KEYPAD_APPEND(ch) {
    var value = ItsText.GetValue('txt_VALUE_TAL0001_R08');
    if (ch == '.') {
        if (value.indexOf('.') >= 0) {
            return;
        }
        value = value == '' ? '0.' : value + '.';
    } else if (ch == '0' && value == '') {
        return;
    } else {
        value += ch;
    }
    ItsNum.SetValue('txt_VALUE_TAL0001_R08', value);
}

ItsButton.Event('btn_1_TAL0001_R08').onClick = function () { KEYPAD_APPEND('1'); };
ItsButton.Event('btn_2_TAL0001_R08').onClick = function () { KEYPAD_APPEND('2'); };
ItsButton.Event('btn_3_TAL0001_R08').onClick = function () { KEYPAD_APPEND('3'); };
ItsButton.Event('btn_4_TAL0001_R08').onClick = function () { KEYPAD_APPEND('4'); };
ItsButton.Event('btn_5_TAL0001_R08').onClick = function () { KEYPAD_APPEND('5'); };
ItsButton.Event('btn_6_TAL0001_R08').onClick = function () { KEYPAD_APPEND('6'); };
ItsButton.Event('btn_7_TAL0001_R08').onClick = function () { KEYPAD_APPEND('7'); };
ItsButton.Event('btn_8_TAL0001_R08').onClick = function () { KEYPAD_APPEND('8'); };
ItsButton.Event('btn_9_TAL0001_R08').onClick = function () { KEYPAD_APPEND('9'); };
ItsButton.Event('btn_0_TAL0001_R08').onClick = function () { KEYPAD_APPEND('0'); };
ItsButton.Event('btn_DOT_TAL0001_R08').onClick = function () { KEYPAD_APPEND('.'); };

ItsButton.Event('btn_DEL_TAL0001_R08').onClick = function () {
    var value = ItsText.GetValue('txt_VALUE_TAL0001_R08');
    ItsNum.SetValue('txt_VALUE_TAL0001_R08', value.substring(0, value.length - 1));
};

ItsButton.Event('btn_CLEAR_TAL0001_R08').onClick = function () {
    ItsText.SetValue('txt_VALUE_TAL0001_R08', '');
};

// 숫자 점검값 적용
ItsButton.Event('btn_ADDVAL_TAL0001_R08').onClick = function () {
    var value = ItsText.GetValue('txt_VALUE_TAL0001_R08').replace(/\.$/, '');
    ItsGrid.SetValue(KEYPAD_GRID, KEYPAD_ROW, 'CHKVALUE', value == '' ? '' : Number(value));
    ItsPop.Close('pop_NUM');
};

// 판정(OK/NG) 점검값 적용
ItsButton.Event('btn_OK_TAL0001_R08').onClick = function () {
    ItsGrid.SetValue(KEYPAD_GRID, KEYPAD_ROW, 'CHKVALUE', 'OK');
    ItsPop.Close('pop_OK');
};

ItsButton.Event('btn_NG_TAL0001_R08').onClick = function () {
    ItsGrid.SetValue(KEYPAD_GRID, KEYPAD_ROW, 'CHKVALUE', 'NG');
    ItsPop.Close('pop_OK');
};

/* 문제점 및 조치사항 */
// 문제점 및 조치사항 팝업 오픈
ItsButton.Event('btn_REMARK').onClick = function () {
    if (!CHECK_ACTION('REMARK')) {
        return;
    }
    ItsTextArea.SetValue('txtArea_PROBLEM', ItsGrid.GetValue('grid1', 0, 'PROBLEM'));
    ItsTextArea.SetValue('txtArea_SOLUTION', ItsGrid.GetValue('grid1', 0, 'SOLUTION'));
    ItsPop.Open('pop_PROB_SOL');
};

// 문제점 및 조치사항 팝업 위치 및 높이 보정
ItsPop.Event('pop_PROB_SOL').onPopOpened = function () {
    $('#pop_PROB_SOL').css('height', 'auto');
    $('#pop_PROB_SOL').height($('#pop_PROB_SOL').height() + 45);
    $('#pop_PROB_SOL').dialog('option', 'position', { my: 'center', at: 'center', of: window });
};

// 문제점 및 조치사항 저장
ItsPop.Event('pop_PROB_SOL').onAddBtnClick = function () {
    var maria = new ItsMaria('TAL0001_R08', 'SAVE_CHKRSTEQM');
    maria.AddParam('EQMCD', SEL_EQMCD);
    maria.AddParam('YYYYMM', GET_YYYYMM());
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid1', 0, 'CHKRSTKEY'));
    maria.AddParam('BASEDATE', ItsGrid.GetValue('grid1', 0, 'BASEDATE'));
    maria.AddParam('EMPCD', ItsGrid.GetValue('grid1', 0, 'EMPCD'));
    maria.AddParam('PROBLEM', ItsTextArea.GetValue('txtArea_PROBLEM'));
    maria.AddParam('SOLUTION', ItsTextArea.GetValue('txtArea_SOLUTION'));
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid2', i, 'CHKKNDCD'));
        maria.AddList('PLANTP_LIST', ItsGrid.GetValue('grid2', i, 'PLANTP'));
        maria.AddList('CHKVALUE_LIST', ItsGrid.GetValue('grid2', i, 'CHKVALUE'));
        maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid2', i, 'REMARK'));
    }
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop_PROB_SOL');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    SEARCH_CYCLE();
};

ItsPop.Event('pop_PROB_SOL').onCancelBtnClick = function () {
    ItsPop.Close('pop_PROB_SOL');
};
