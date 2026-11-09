/// <reference path="../../Script/reference.js" />

// 2026-11-09 [설비 정기점검 등록] 월별 현황 조회 결과, 선택 월(01~12)·선택 설비, 조회한 년도
var CYCLE_DATA = [];
var SEL_MONTH = '';
var SEL_EQMCD = '';
var LOADED_YEAR = '';

// 2026-11-09 점검값·특이사항 입력 팝업을 등록(grid3)·수정(grid4)이 같이 쓰므로 값을 넣을 그리드·행을 기억
var KEYPAD_GRID = 'grid3';
var KEYPAD_ROW = -1;

/* 페이지 접근 시 수행 */
// 2026-11-09 그리드 생성, 이번 달·올해 기본 선택 후 월별 현황 조회
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        column.create('점검월', 'YYYYMM', { width: 90, align: 'center' }),
        column.create('상태', 'STATUS', { width: 90, align: 'center' }),
        column.create('점검일자', 'BASEDATE', { width: 110, align: 'center' }),
        column.create('점검자', 'EMPNM', { width: 110, align: 'center' }),
        column.create('점검자코드', 'EMPCD', { hidden: true }),
        column.create('점검키', 'CHKRSTKEY', { hidden: true }),
        column.create('문제점', 'PROBLEM', { hidden: true }),
        column.create('조치사항', 'SOLUTION', { hidden: true }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: false }, CREATE_ITEM_COLUMNS());
    ItsGrid.Create('grid3', { isCheckBoxGrid: false, isSubTotalGrid: false }, CREATE_ITEM_COLUMNS());
    ItsGrid.Create('grid4', { isCheckBoxGrid: false, isSubTotalGrid: false }, CREATE_ITEM_COLUMNS());

    SEL_MONTH = ('0' + (new Date().getMonth() + 1)).slice(-2);
    SET_BUTTONS('');

    ItsCombo.SetValueByIndex('cmb_SYEAR', 4);
    if (LOADED_YEAR != ItsCombo.GetValue('cmb_SYEAR')) {
        SEARCH_CYCLE();
    }
};

// 2026-11-09 점검 항목 그리드 컬럼 (메인 grid2, 등록 grid3, 수정 grid4 공용, 값은 팝업으로 입력)
function CREATE_ITEM_COLUMNS() {
    return [
        column.create('적용 REV', 'REVNM', { width: 90, align: 'center' }),
        column.create('계획구분', 'PLANTP', { hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { hidden: true }),
        column.create('점검명', 'CHKKNDNM', { width: 230 }),
        column.create('점검항목', 'CHKLOC', { width: 120, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKLOC' }),
        column.create('점검방법', 'CHKMTH', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKMTH' }),
        column.create('점검값구분', 'CHKVALTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP' }),
        column.create('점검값', 'CHKVALUE', { width: 100, align: 'center' }),
        column.create('특이사항', 'REMARK', { width: 260 }),
    ];
}

// 2026-11-09 선택 설비의 선택 월 상태에 따라 버튼 사용 (점검필요: 점검 / 점검완료: 수정·삭제·문제점)
function SET_BUTTONS(status) {
    ItsButton.Enable('btn_SEARCH');
    if (status == '점검필요') {
        ItsButton.Enable('btn_REG');
    } else {
        ItsButton.Disable('btn_REG');
    }
    if (status == '점검완료') {
        ItsButton.Enable('btn_EDIT');
        ItsButton.Enable('btn_DELETE');
        ItsButton.Enable('btn_REMARK');
    } else {
        ItsButton.Disable('btn_EDIT');
        ItsButton.Disable('btn_DELETE');
        ItsButton.Disable('btn_REMARK');
    }
}

// 2026-11-09 사원찾기 목록(공장 07)에 없는 점검자는 이름칸이 비므로 프로시저가 준 사원명으로 표시
function SET_FIND_NAME(findId, name) {
    if (name && !ItsFind.GetNameValue(findId)) {
        $('input#' + findId).siblings('.ItsFind_name').val(name);
    }
}

// 2026-11-09 선택 년월 (YYYY-MM)
function GET_YYYYMM() {
    return ItsCombo.GetValue('cmb_SYEAR') + '-' + SEL_MONTH;
}

// 2026-11-09 선택 설비의 선택 월 상태 (점검필요 / 점검완료 / 빈 값)
function GET_STATUS(eqmCd) {
    for (var i = 0; i < CYCLE_DATA.length; i++) {
        if (CYCLE_DATA[i].EQMCD == eqmCd) {
            return CYCLE_DATA[i]['M' + SEL_MONTH] || '';
        }
    }
    return '';
}
/**********************************************************************************************************************************************************************/
// 월별 현황·설비 카드

// 2026-11-09 조회년도·설비 조건으로 월별 정기점검 현황 조회 후 월 탭·설비 카드 표시
function SEARCH_CYCLE() {
    var maria = new ItsMaria('TAL0001_R08', 'LIST_CYCLE_EQMCD');
    maria.AddParam('SYEAR', ItsCombo.GetValue('cmb_SYEAR'));
    maria.AddParam('EQMCD', ItsFind.GetValue('find_EQMCD') || '');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    CYCLE_DATA = maria.store.data;
    LOADED_YEAR = ItsCombo.GetValue('cmb_SYEAR');
    RENDER_MONTH();
    RENDER_EQM();
}

// 2026-11-09 월 탭 (1~12월)
function RENDER_MONTH() {
    var html = '';
    for (var m = 1; m <= 12; m++) {
        var mm = ('0' + m).slice(-2);
        html += '<button type="button" class="month-btn' + (mm == SEL_MONTH ? ' active' : '') + '" data-month="' + mm + '">' + m + '월</button>';
    }
    $('#MONTH_LIST').html(html);
}

// 2026-11-09 설비 카드: 선택 월에 점검 대상인 설비만, 카드 배경색으로 상태 구분(점검필요 need·점검완료 done), 선택 설비가 남아 있으면 상세 다시 조회
function RENDER_EQM() {
    var html = '';
    var hasSelected = false;

    CYCLE_DATA.forEach(function (row) {
        var status = row['M' + SEL_MONTH] || '';
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

// 2026-11-09 조회년도 변경 시 다시 조회
ItsCombo.Event('cmb_SYEAR').onChanged = function (value, oldValue) {
    SEARCH_CYCLE();
};

// 2026-11-09 월 탭 선택
$(document).on('click', '#MONTH_LIST .month-btn', function () {
    SEL_MONTH = $(this).attr('data-month');
    $('#MONTH_LIST .month-btn').removeClass('active');
    $(this).addClass('active');
    RENDER_EQM();
});

// 2026-11-09 설비 카드 선택 시 선택 월 점검 정보·항목 조회
$(document).on('click', '#EQM_LIST .eqm-btn', function () {
    SEL_EQMCD = $(this).attr('data-eqmcd');
    $('#EQM_LIST .eqm-btn').removeClass('active');
    $(this).addClass('active');
    LOAD_DETAIL();
});

// 2026-11-09 조회 버튼
ItsButton.Event('btn_SEARCH').onClick = function () {
    SEARCH_CYCLE();
};
/**********************************************************************************************************************************************************************/
// 선택 설비 상세 (왼쪽 점검 정보, 오른쪽 점검 항목)

// 2026-11-09 점검완료: 저장된 실적·항목 / 점검필요: 승인 계획 항목과 주기관리 점검자 (미리보기)
function LOAD_DETAIL() {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    var status = SEL_EQMCD ? GET_STATUS(SEL_EQMCD) : '';
    SET_BUTTONS(status);
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
        var rst = maria.store.data[0] || {};
        ItsGrid.SetStore('grid1', {
            data: [{
                YYYYMM: yyyymm, STATUS: status, BASEDATE: rst.BASEDATE, EMPCD: rst.EMPCD, EMPNM: rst.EMPNM || rst.EMPCD,
                CHKRSTKEY: rst.CHKRSTKEY, PROBLEM: rst.PROBLEM || '', SOLUTION: rst.SOLUTION || ''
            }]
        });
        ItsGrid.SetStore('grid2', maria.storeExtend1);
    } else {
        maria = new ItsMaria('TAL0001_R08', 'LIST_PLAN_EQM02');
        maria.AddParam('EQMCD', SEL_EQMCD);
        maria.AddParam('YYYYMM', yyyymm);
        maria.CallProc();
        var plan = maria.isError ? {} : (maria.store.data[0] || {});
        ItsGrid.SetStore('grid1', {
            data: [{
                YYYYMM: yyyymm, STATUS: status, BASEDATE: '', EMPCD: plan.PLANEMPCD || '', EMPNM: plan.PLANEMPNAME || plan.PLANEMPNM || '',
                CHKRSTKEY: '', PROBLEM: '', SOLUTION: ''
            }]
        });
        if (maria.isError) {
            maria.ShowErrMsg();
            ItsButton.Disable('btn_REG');
            return;
        }
        ItsGrid.SetStore('grid2', maria.store);
    }
}
/**********************************************************************************************************************************************************************/
// 점검 등록

// 2026-11-09 점검 버튼: 최신 승인 계획 항목으로 등록 팝업 열기 (점검일자 기본값: 이번 달이면 오늘, 아니면 그 달 1일 / 점검자 기본값: 주기관리 점검자)
ItsButton.Event('btn_REG').onClick = function () {
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
    var plan = maria.store.data[0] || {};

    ItsPage.InitData('pdiv1');
    ItsFind.SetValue('pop1_find_EQMCD', SEL_EQMCD);
    ItsDate.SetValue('pop1_date_BASEDATE', today.substr(0, 7) == yyyymm ? today : yyyymm + '-01');
    ItsText.SetValue('pop1_txt_YYYYMM', yyyymm);
    ItsText.SetValue('pop1_txt_REVCD', plan.EQMREVCD || '');
    ItsText.SetValue('pop1_txt_GRPREVCD', plan.GRPREVCD || '');
    ItsText.SetValue('pop1_txt_PROBLEM', '');
    ItsText.SetValue('pop1_txt_SOLUTION', '');
    if (plan.PLANEMPCD) {
        ItsFind.SetValue('pop1_find_EMPCD', plan.PLANEMPCD);
        SET_FIND_NAME('pop1_find_EMPCD', plan.PLANEMPNAME);
    } else if (plan.PLANEMPNM) {
        ItsMsg.Toast('주기관리 점검자(' + plan.PLANEMPNM + ')를 사원 목록에서 찾지 못했습니다. 점검자를 직접 선택해주세요.');
    }

    ItsGrid.SetStore('grid3', maria.store);
    ItsPop.Open('pop1');
};

// 2026-11-09 등록 팝업 저장 (점검값·특이사항 저장, 문제점/조치사항은 등록 후 메인 버튼으로 입력, 필수 확인은 프로시저에서 처리)
ItsPop.Event('pop1').onAddBtnClick = function () {
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
/**********************************************************************************************************************************************************************/
// 점검 수정·삭제

// 2026-11-09 수정 버튼: 선택 월 실적으로 수정 팝업 열기
ItsButton.Event('btn_EDIT').onClick = function () {
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
};

// 2026-11-09 수정 팝업 저장
ItsPop.Event('pop2').onAddBtnClick = function () {
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

// 2026-11-09 삭제 버튼: 선택 월 실적 삭제
ItsButton.Event('btn_DELETE').onClick = function () {
    var CHKRSTKEY = ItsGrid.GetValue('grid1', 0, 'CHKRSTKEY');
    if (!CHKRSTKEY) {
        ItsMsg.Toast('삭제할 점검 실적을 선택하세요.');
        return;
    }

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
/**********************************************************************************************************************************************************************/
// 점검값·특이사항 입력 (등록 grid3·수정 grid4)

// 2026-11-09 특이사항 칸: 큰 입력창 / 점검값 칸: 점검값구분 03(OK/NG)은 OK·NG 버튼, 그 외는 숫자패드
function OPEN_ITEM_INPUT(gridId, rowIndex, field) {
    if (rowIndex < 0) {
        return;
    }
    KEYPAD_GRID = gridId;
    KEYPAD_ROW = rowIndex;

    if (field == 'REMARK') {
        ItsTextArea.SetValue('txtArea_ITEM_REMARK', ItsGrid.GetValue(gridId, rowIndex, 'REMARK') || '');
        ItsPop.Open('pop_ITEM_REMARK');
    } else if (ItsGrid.GetValue(gridId, rowIndex, 'CHKVALTP') == '03') {
        ItsPop.Open('pop_OK');
    } else {
        ItsText.SetValue('txt_VALUE_TAL0001_R08', '');
        ItsPop.Open('pop_NUM');
    }
}

ItsGrid.Event('grid3').onDoubleClick = function (rowIndex, field) {
    OPEN_ITEM_INPUT('grid3', rowIndex, field);
};

ItsGrid.Event('grid4').onDoubleClick = function (rowIndex, field) {
    OPEN_ITEM_INPUT('grid4', rowIndex, field);
};

// 2026-11-09 숫자패드
function KEYPAD_APPEND(ch) {
    var value = ItsText.GetValue('txt_VALUE_TAL0001_R08') || '';
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
    var value = ItsText.GetValue('txt_VALUE_TAL0001_R08') || '';
    ItsNum.SetValue('txt_VALUE_TAL0001_R08', value.substring(0, value.length - 1));
};

ItsButton.Event('btn_CLEAR_TAL0001_R08').onClick = function () {
    ItsText.SetValue('txt_VALUE_TAL0001_R08', '');
};

// 2026-11-09 숫자 점검값 반영 (끝의 소수점은 제외)
ItsButton.Event('btn_ADDVAL_TAL0001_R08').onClick = function () {
    var value = (ItsText.GetValue('txt_VALUE_TAL0001_R08') || '').replace(/\.$/, '');
    ItsGrid.SetValue(KEYPAD_GRID, KEYPAD_ROW, 'CHKVALUE', value == '' ? '' : Number(value));
    ItsText.SetValue('txt_VALUE_TAL0001_R08', '');
    ItsPop.Close('pop_NUM');
};

// 2026-11-09 OK/NG 점검값 반영
ItsButton.Event('btn_OK_TAL0001_R08').onClick = function () {
    ItsGrid.SetValue(KEYPAD_GRID, KEYPAD_ROW, 'CHKVALUE', 'OK');
    ItsPop.Close('pop_OK');
};

ItsButton.Event('btn_NG_TAL0001_R08').onClick = function () {
    ItsGrid.SetValue(KEYPAD_GRID, KEYPAD_ROW, 'CHKVALUE', 'NG');
    ItsPop.Close('pop_OK');
};

// 2026-11-09 특이사항 반영
ItsPop.Event('pop_ITEM_REMARK').onAddBtnClick = function () {
    ItsGrid.SetValue(KEYPAD_GRID, KEYPAD_ROW, 'REMARK', ItsTextArea.GetValue('txtArea_ITEM_REMARK'));
    ItsPop.Close('pop_ITEM_REMARK');
};

ItsPop.Event('pop_ITEM_REMARK').onCancelBtnClick = function () {
    ItsPop.Close('pop_ITEM_REMARK');
};
/**********************************************************************************************************************************************************************/
// 문제점/조치사항

// 2026-11-09 문제점/조치사항 (TAL0001_R05와 같은 방식): 점검완료 실적을 선택한 뒤 메인 [문제점/조치사항] 버튼으로 입력
ItsButton.Event('btn_REMARK').onClick = function () {
    if (!ItsGrid.GetValue('grid1', 0, 'CHKRSTKEY')) {
        ItsMsg.Toast('점검 실적을 선택하세요.');
        return;
    }
    ItsTextArea.SetValue('txtArea_PROBLEM', ItsGrid.GetValue('grid1', 0, 'PROBLEM') || '');
    ItsTextArea.SetValue('txtArea_SOLUTION', ItsGrid.GetValue('grid1', 0, 'SOLUTION') || '');
    ItsPop.Open('pop_PROB_SOL');
};

// 2026-11-09 선택 월 실적의 점검값·특이사항은 그대로 두고 문제점/조치사항만 바꿔 저장
ItsPop.Event('pop_PROB_SOL').onAddBtnClick = function () {
    var problem = ItsTextArea.GetValue('txtArea_PROBLEM');
    var solution = ItsTextArea.GetValue('txtArea_SOLUTION');

    var maria = new ItsMaria('TAL0001_R08', 'SAVE_CHKRSTEQM');
    maria.AddParam('EQMCD', SEL_EQMCD);
    maria.AddParam('YYYYMM', GET_YYYYMM());
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid1', 0, 'CHKRSTKEY'));
    maria.AddParam('BASEDATE', ItsGrid.GetValue('grid1', 0, 'BASEDATE'));
    maria.AddParam('EMPCD', ItsGrid.GetValue('grid1', 0, 'EMPCD'));
    maria.AddParam('PROBLEM', problem);
    maria.AddParam('SOLUTION', solution);
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
/**********************************************************************************************************************************************************************/
