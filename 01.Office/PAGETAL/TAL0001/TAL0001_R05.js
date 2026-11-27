/// <reference path="../../Script/reference.js" />

// 점검값 입력 팝업(pop_NUM / pop_OK)을 등록(grid3)·수정(grid4)이 같이 쓰므로, 값을 넣을 그리드를 기억한다
var KEYPAD_GRID = 'grid3';

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('점검시간', 'CHKTIME', { width: 150, align: 'center' }),
        column.create('점검자', 'EMPCD', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),
        column.create('점검키', 'CHKRSTKEY', { width: 150, align: 'center', hidden: true }),
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('점검명', 'CHKKNDNM', { width: 150, align: 'center' }),
        column.create('점검항목', 'CHKLOC', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKLOC' }),
        column.create('점검방법', 'CHKMTH', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKMTH' }),
        column.create('점검값', 'CHKVALUE', { width: 110, align: 'center' }),
        column.create('판정', 'JUDGE', { width: 80, align: 'center' }),                  // 2026-11-26 자동판정 (화면 표시만)
        column.create('점검기준', 'CHKSTD', { width: 130, align: 'center' }),            // 2026-11-26
        column.create('점검주기', 'CHKCYCLE', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE' }),
        column.create('비고', 'REMARK', { width: 110, align: 'center' }),
        column.create('판정방식', 'STDTP', { hidden: true }),
        column.create('하한', 'MINVAL', { hidden: true }),
        column.create('상한', 'MAXVAL', { hidden: true }),
        column.create('점검값구분', 'CHKVALTP', { hidden: true }),
    ]);

    // 2026-11-26 등록·수정 그리드: 순번 열 삭제, 점검주기 왼쪽에 점검기준, 점검값 오른쪽에 판정(자동판정, 화면 표시만)
    ItsGrid.Create('grid3', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        //column.create('순번', 'SORTNO', { width: 60, align: 'center' }),
        column.create('계획구분', 'PLANTP', { width: 60, hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 60, hidden: true }),
        column.create('점검명', 'CHKKNDNM', { width: 150, align: 'center' }),
        column.create('점검항목', 'CHKLOC', { width: 130, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKLOC' }),
        column.create('점검방법', 'CHKMTH', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKMTH' }),
        column.create('점검값구분', 'CHKVALTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP' }),
        column.create('점검기준', 'CHKSTD', { width: 130, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE' }),
        column.create('점검값', 'CHKVALUE', { width: 100, align: 'center' }),
        column.create('판정', 'JUDGE', { width: 80, align: 'center' }),
        column.create('비고', 'REMARK', { width: 220, align: 'center', readOnly: false }),
        column.create('판정방식', 'STDTP', { hidden: true }),
        column.create('하한', 'MINVAL', { hidden: true }),
        column.create('상한', 'MAXVAL', { hidden: true }),
    ]);

    ItsGrid.Create('grid4', { isCheckBoxGrid: false, isSubTotalGrid: false }, [
        //column.create('순번', 'SORTNO', { width: 60, align: 'center' }),
        column.create('계획구분', 'PLANTP', { width: 60, hidden: true }),
        column.create('점검코드', 'CHKKNDCD', { width: 60, hidden: true }),
        column.create('점검명', 'CHKKNDNM', { width: 150, align: 'center' }),
        column.create('점검항목', 'CHKLOC', { width: 130, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKLOC' }),
        column.create('점검방법', 'CHKMTH', { width: 110, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKMTH' }),
        column.create('점검값구분', 'CHKVALTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKVALTP' }),
        column.create('점검기준', 'CHKSTD', { width: 130, align: 'center' }),
        column.create('점검주기', 'CHKCYCLE', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'CHKCYCLE' }),
        column.create('점검값', 'CHKVALUE', { width: 100, align: 'center' }),
        column.create('판정', 'JUDGE', { width: 80, align: 'center' }),
        column.create('비고', 'REMARK', { width: 220, align: 'center', readOnly: false }),
        column.create('판정방식', 'STDTP', { hidden: true }),
        column.create('하한', 'MINVAL', { hidden: true }),
        column.create('상한', 'MAXVAL', { hidden: true }),
    ]);

    // 불합격은 빨간 굵은 글씨 (판정 칸)
    $.each(['grid2', 'grid3', 'grid4'], function (i, id) {
        ItsGrid.Get(id).formatItem.addHandler(function (s, e) {
            if (e.panel != s.cells || s.columns[e.col].binding != 'JUDGE') return;
            if (ItsGrid.GetValue(id, e.row, 'JUDGE') == '불합격') {
                e.cell.style.color = 'red';
                e.cell.style.fontWeight = 'bold';
            }
        });
    });

    // 작업장 '전체'를 기본으로 선택 (onChanged 에서 설비 버튼 조회)
    ItsCombo.SetValueByIndex('cmb_LINECD', 0);

    $('input#date_RANGEDATE_F').prop('disabled', true);
    $('input#date_RANGEDATE_T').prop('disabled', true);
    ItsFind.Disable('find_EMPCD');
    ItsButton.Disable('btn_SEARCH');
    ItsButton.Disable('btn_REG');
    ItsButton.Disable('btn_EDIT');
    ItsButton.Disable('btn_DELETE');
    ItsButton.Disable('btn_REMARK');
};
/**********************************************************************************************************************************************************************/
// 설비 선택

// 작업장 변경 시 공정·라인 콤보를 그 작업장 기준으로 바꾸고 설비 목록 다시 조회
ItsCombo.Event('cmb_LINECD').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);

    LIST_EQMCD_BUTTON();
};

// 공정 변경 시 라인 콤보를 그 공정 기준으로 바꾸고 설비 목록 다시 조회
ItsCombo.Event('cmb_EQMTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);

    LIST_EQMCD_BUTTON();
};

// 라인 변경 시 설비 목록 다시 조회
ItsCombo.Event('cmb_EQMGROUP1').onChanged = function (value, oldValue) {
    LIST_EQMCD_BUTTON();
};

// 상단 설비 버튼 목록 (작업장·공정·라인 조건)
LIST_EQMCD_BUTTON = function () {
    var maria = new ItsMaria('TAL0001_R05', 'LIST_EQMCD');
    maria.AddParam('LINECD', ItsCombo.GetValue('cmb_LINECD'));
    maria.AddParam('EQMTP', ItsCombo.GetValue('cmb_EQMTP'));
    maria.AddParam('EQMGROUP1', ItsCombo.GetValue('cmb_EQMGROUP1'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    $('#EQM_LIST').empty();
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    for (var i = 0; i < maria.store.Length(); i++) {
        var EQMCD = maria.store.data[i].EQMCD;
        var EQMNM = maria.store.data[i].EQMNM;

        $('#EQM_LIST').append('<button class="eqm-btn" data-EQMCD="' + EQMCD + '">'
            + '<span class="eqm-cd">' + EQMCD + '</span>'
            + '<span class="eqm-nm">' + EQMNM + '</span>'
            + '</button>');
    }

    if (maria.store.Length() == 0) {
        ItsMsg.Toast('조건에 맞는 설비가 없습니다.');
    }
};

// 설비 버튼 선택 시 버튼 활성화 후 실적 조회
$(document).on('click', '.eqm-btn', function () {
    $('.eqm-btn').removeClass('active');
    $(this).addClass('active');

    $('input#date_RANGEDATE_F').prop('disabled', false);
    $('input#date_RANGEDATE_T').prop('disabled', false);

    ItsFind.Enable('find_EMPCD');
    ItsButton.Enable('btn_SEARCH');
    ItsButton.Enable('btn_REG');
    ItsButton.Enable('btn_EDIT');
    ItsButton.Enable('btn_DELETE');
    ItsButton.Enable('btn_REMARK');

    SEARCH_LIST();
});
/**********************************************************************************************************************************************************************/
// 조회

// 선택한 설비의 일상점검 실적 조회
SEARCH_LIST = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TAL0001_R05', 'LIST_CHKRSTEQM');
    maria.AddParam('EQMCD', $('.eqm-btn.active').data('eqmcd'));
    maria.AddPanel('div1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    ItsGrid.Get('grid1').autoSizeColumns();
};

// 조회 버튼
ItsButton.Event('btn_SEARCH').onClick = function () {
    SEARCH_LIST();
};

// 실적 선택 시 점검 항목 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('TAL0001_R05', 'LIST_CHKRSTEQMKND');
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid1', rowIndex, 'CHKRSTKEY'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    JUDGE_ALL('grid2');
    ItsGrid.Get('grid2').autoSizeColumns();
};

// 2026-11-26 자동판정 (화면 표시만, 저장하지 않음)
//   수치 항목: 계획 판정범위(하한~상한) 안이면 합격, 밖이면 불합격 / OK·NG: OK 합격, NG 불합격
//   점검값이 없거나 판정범위가 없는 항목은 빈칸
function JUDGE_TEXT(id, row) {
    var val = $.trim(String(ItsGrid.GetValue(id, row, 'CHKVALUE') || ''));
    if (val == '') return '';
    var up = val.toUpperCase();
    if (up == 'OK') return '합격';
    if (up == 'NG') return '불합격';

    if (ItsGrid.GetValue(id, row, 'STDTP') != 'RANGE' || !/^-?\d+(\.\d+)?$/.test(val)) return '';
    var v = parseFloat(val);
    var min = String(ItsGrid.GetValue(id, row, 'MINVAL') || '');
    var max = String(ItsGrid.GetValue(id, row, 'MAXVAL') || '');
    if (min !== '' && v < parseFloat(min)) return '불합격';
    if (max !== '' && v > parseFloat(max)) return '불합격';
    return '합격';
}

function JUDGE_ROW(id, row) {
    ItsGrid.SetValue(id, row, 'JUDGE', JUDGE_TEXT(id, row));
}

function JUDGE_ALL(id) {
    for (var i = 0; i < ItsGrid.Length(id); i++) {
        JUDGE_ROW(id, i);
    }
}
/**********************************************************************************************************************************************************************/
// 점검 등록

// 점검 버튼: 설비그룹·설비의 최신 승인 일상점검 항목으로 등록 팝업 열기
ItsButton.Event('btn_REG').onClick = function () {
    var maria = new ItsMaria('TAL0001_R05', 'LIST_PLAN_ITEM');
    maria.AddParam('EQMCD', $('.eqm-btn.active').data('eqmcd'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPage.InitData('pdiv1');
    ItsText.SetValue('pop1_txt_BASETIME', new Date().format('HH:mm'));   // 등록시간 기본값: 지금 시각
    ItsText.SetValue('pop1_txt_REVTEXT', maria.store.Length() > 0 && maria.store.data[0]["REVTEXT"] != undefined ? maria.store.data[0]["REVTEXT"] : '');   // 2026-11-26 계획 리비전번호
    // 2026-11-26 새 점검: OK/NG 항목(점검값구분 01 아님)은 OK 를 미리 넣음
    for (var i = 0; i < maria.store.Length(); i++) {
        var item = maria.store.data[i];
        if (item.CHKVALTP != '01' && $.trim(String(item.CHKVALUE || '')) == '') item.CHKVALUE = 'OK';
    }
    ItsGrid.SetStore('grid3', maria.store);
    JUDGE_ALL('grid3');
    ItsPop.Open('pop1');
};

// 점검값 입력: 점검값구분이 숫자(01)면 숫자키패드, 아니면 OK/NG
ItsGrid.Event('grid3').onDoubleClick = function (rowIndex, field) {
    KEYPAD_GRID = 'grid3';

    if (ItsGrid.GetValue('grid3', rowIndex, 'CHKVALTP') == '01') {
        ItsPop.Open('pop_NUM');
    } else {
        ItsPop.Open('pop_OK');
    }
};

// 등록 팝업 저장
ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('TAL0001_R05', 'ADD_CHKRSTEQM');
    maria.AddPanel('pdiv1');
    maria.AddParam('EQMCD', $('.eqm-btn.active').data('eqmcd'));
    maria.AddParam('REVCD', ItsGrid.GetValue('grid3', 0, 'REVCD'));
    maria.AddParam('GRPREVCD', ItsGrid.GetValue('grid3', 0, 'GRPREVCD'));

    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        maria.AddList('PLANTP_LIST', ItsGrid.GetValue('grid3', i, 'PLANTP'));
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid3', i, 'CHKKNDCD'));
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
    SEARCH_LIST();
};

// 등록 팝업 닫기
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
};
/**********************************************************************************************************************************************************************/
// 점검 수정

// 수정 버튼: 선택한 실적으로 수정 팝업 열기
ItsButton.Event('btn_EDIT').onClick = function () {
    var CHKRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY');
    if (!CHKRSTKEY) {
        ItsMsg.Toast('수정할 점검 실적을 선택하세요.');
        return;
    }

    var maria = new ItsMaria('TAL0001_R05', 'LIST_CHKRSTEQM_EDIT');
    maria.AddParam('CHKRSTKEY', CHKRSTKEY);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid4', maria.store);
    JUDGE_ALL('grid4');
    ItsDate.SetValue('pop2_date_BASEDATE', maria.store.data[0]["BASEDATE"]);
    ItsFind.SetValue('pop2_find_EMPCD', maria.store.data[0]["EMPCD"]);
    ItsDate.SetValue('pop2_date_REGDATE', maria.store.data[0]["DATE"]);
    ItsText.SetValue('pop2_txt_BASETIME', maria.store.data[0]["TIME"]);
    ItsText.SetValue('pop2_txt_REVTEXT', maria.store.data[0]["REVTEXT"] == undefined ? '' : maria.store.data[0]["REVTEXT"]);   // 2026-11-26 그 점검에 쓴 계획 리비전번호

    ItsPop.Open('pop2');
};

// 점검값 수정: 점검값구분이 숫자(01)면 숫자키패드, 아니면 OK/NG
ItsGrid.Event('grid4').onDoubleClick = function (rowIndex, field) {
    KEYPAD_GRID = 'grid4';

    if (ItsGrid.GetValue('grid4', rowIndex, 'CHKVALTP') == '01') {
        ItsPop.Open('pop_NUM');
    } else {
        ItsPop.Open('pop_OK');
    }
};

// 수정 팝업 저장
ItsPop.Event('pop2').onAddBtnClick = function () {
    var maria = new ItsMaria('TAL0001_R05', 'SAVE_CHKRSTEQM');
    maria.AddPanel('pdiv2');
    maria.AddParam('EQMCD', $('.eqm-btn.active').data('eqmcd'));
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY'));

    for (var i = 0; i < ItsGrid.Length('grid4'); i++) {
        maria.AddList('PLANTP_LIST', ItsGrid.GetValue('grid4', i, 'PLANTP'));
        maria.AddList('CHKKNDCD_LIST', ItsGrid.GetValue('grid4', i, 'CHKKNDCD'));
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
    SEARCH_LIST();
};

// 수정 팝업 닫기
ItsPop.Event('pop2').onCancelBtnClick = function () {
    ItsPop.Close('pop2');
};
/**********************************************************************************************************************************************************************/
// 점검값 입력 팝업 (등록·수정 공용, KEYPAD_GRID 에 값 반영)

ItsButton.Event('btn_DOT_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    if (GOODQTY == '') {
        ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', '0.');
    }
    else {
        ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '.');
    }
};
ItsButton.Event('btn_1_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '1');
};
ItsButton.Event('btn_2_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '2');
};
ItsButton.Event('btn_3_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '3');
};
ItsButton.Event('btn_4_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '4');
};
ItsButton.Event('btn_5_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '5');
};
ItsButton.Event('btn_6_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '6');
};
ItsButton.Event('btn_7_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '7');
};
ItsButton.Event('btn_8_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '8');
};
ItsButton.Event('btn_9_TAL0001_R05').onClick = function () {
    ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', ItsText.GetValue('txt_GOODQTY_TAL0001_R05') + '9');
};
ItsButton.Event('btn_0_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    if (GOODQTY != '')
        ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY + '0');
};
ItsButton.Event('btn_DEL_TAL0001_R05').onClick = function () {
    var GOODQTY = ItsText.GetValue('txt_GOODQTY_TAL0001_R05');
    if (GOODQTY.length != 0) {
        ItsNum.SetValue('txt_GOODQTY_TAL0001_R05', GOODQTY.substring(0, GOODQTY.length - 1));
    }
};
ItsButton.Event('btn_CLEAR_TAL0001_R05').onClick = function () {
    ItsText.SetValue('txt_GOODQTY_TAL0001_R05', '');
};

// 숫자 점검값 반영 (등록)
ItsButton.Event('btn_ADDRST_TAL0001_R05').onClick = function () {
    ItsGrid.SetValue(KEYPAD_GRID, ItsGrid.GetCurrentIndex(KEYPAD_GRID), 'CHKVALUE', ItsNum.GetValue('txt_GOODQTY_TAL0001_R05'));
    JUDGE_ROW(KEYPAD_GRID, ItsGrid.GetCurrentIndex(KEYPAD_GRID));
    ItsPop.Close('pop_NUM');
    ItsText.SetValue('txt_GOODQTY_TAL0001_R05', '');
};

// OK/NG 점검값 반영
ItsButton.Event('btn_OK_TAL0001_R05').onClick = function () {
    ItsGrid.SetValue(KEYPAD_GRID, ItsGrid.GetCurrentIndex(KEYPAD_GRID), 'CHKVALUE', 'OK');
    JUDGE_ROW(KEYPAD_GRID, ItsGrid.GetCurrentIndex(KEYPAD_GRID));
    ItsPop.Close('pop_OK');
};
ItsButton.Event('btn_NG_TAL0001_R05').onClick = function () {
    ItsGrid.SetValue(KEYPAD_GRID, ItsGrid.GetCurrentIndex(KEYPAD_GRID), 'CHKVALUE', 'NG');
    JUDGE_ROW(KEYPAD_GRID, ItsGrid.GetCurrentIndex(KEYPAD_GRID));
    ItsPop.Close('pop_OK');
};
/**********************************************************************************************************************************************************************/
// 삭제

ItsButton.Event('btn_DELETE').onClick = function () {
    var CHKRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY');
    if (!CHKRSTKEY) {
        ItsMsg.Toast('삭제할 점검 실적을 선택하세요.');
        return;
    }

    ItsMsg.Confirm('선택한 점검 실적을 삭제하시겠습니까?', function () {
        var maria = new ItsMaria('TAL0001_R05', 'DELETE_CHKRSTEQM');
        maria.AddParam('CHKRSTKEY', CHKRSTKEY);
        maria.AddParam('EQMCD', $('.eqm-btn.active').data('eqmcd'));
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete());
        SEARCH_LIST();
    });
};
/**********************************************************************************************************************************************************************/
// 문제점/조치사항

ItsButton.Event('btn_REMARK').onClick = function () {
    var CHKRSTKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY');
    if (!CHKRSTKEY) {
        ItsMsg.Toast('점검 실적을 선택하세요.');
        return;
    }

    var maria = new ItsMaria('TAL0001_R05', 'LIST_ERR');
    maria.AddParam('CHKRSTKEY', CHKRSTKEY);
    maria.AddParam('EQMCD', $('.eqm-btn.active').data('eqmcd'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsTextArea.SetValue('txtArea_PROBLEM', maria.store.data[0]["PROBLEM"]);
    ItsTextArea.SetValue('txtArea_SOLUTION', maria.store.data[0]["SOLUTION"]);
    ItsPop.Open('pop_PROB_SOL');
};

ItsPop.Event('pop_PROB_SOL').onAddBtnClick = function () {
    var maria = new ItsMaria('TAL0001_R05', 'SAVE_ERR');
    maria.AddParam('CHKRSTKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CHKRSTKEY'));
    maria.AddParam('EQMCD', $('.eqm-btn.active').data('eqmcd'));
    maria.AddParam('PROBLEM', ItsTextArea.GetValue('txtArea_PROBLEM'));
    maria.AddParam('SOLUTION', ItsTextArea.GetValue('txtArea_SOLUTION'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop_PROB_SOL');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
};

ItsPop.Event('pop_PROB_SOL').onCancelBtnClick = function () {
    ItsPop.Close('pop_PROB_SOL');
};
/**********************************************************************************************************************************************************************/
