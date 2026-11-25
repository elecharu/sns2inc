/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 설비부품 재고 그리드 (현재고가 안전재고보다 적으면 행 분홍색)
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create('설비부품코드', 'ITEMCD', { width: 170, align: 'center' }),
        column.create('설비부품명', 'ITEMNM', { width: '*' }),
        column.create('중요도등급', 'GRADE', { width: 100, align: 'center' }),
        column.create('로케이션', 'LOCANM', { width: 130, align: 'center' }),
        column.create('안전재고', 'SAFEQTY', { width: 95, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('현재고', 'LOTQTY', { width: 95, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('단위', 'ITEMUNIT', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150' }),
        column.create('출고', 'OUT', { width: 75, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create('출고 이력', 'HIS', { width: 95, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        column.create('라벨출력', 'PRINT_LABEL', { width: 95, columnType: enumColumnTypes.button, iconCls: 'fa-print' }),
    ]);

    // 출고 이력 그리드
    ItsGrid.Create('grid_HIS', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create('발생일자', 'INOUTDATE', { width: 110, align: 'center' }),
        column.create('출고유형', 'INOUTTPNM', { width: 120, align: 'center' }),
        column.create('라인', 'EQMGROUP1NM', { width: 90, align: 'center' }),
        column.create('설비', 'EQMNM', { width: 230 }),
        column.create('설비부품코드', 'ITEMCD', { width: 140, align: 'center' }),
        column.create('출고량', 'OUTQTY', { width: 90, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('처리자', 'EMPNM', { width: 110, align: 'center' }),
        column.create('출고취소', 'CANCEL', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-times' }),
    ]);

    SEARCH_EQMPARTS();
    ItsText.Focus('txt_SCAN');
};

// 설비부품 현재고 조회 (중요도등급·로케이션 조건)
function SEARCH_EQMPARTS() {
    var maria = new ItsMaria('TAL0001_R09', 'LIST_EQMPARTS');
    maria.AddParam('GRADE', ItsCombo.GetValue('cmb_S_GRADE'));
    maria.AddParam('LOCACD', ItsCombo.GetValue('cmb_S_LOCACD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
}

// 스캔값(품목ID 또는 설비부품코드)과 일치하는 재고 행 찾기
function FIND_EQMPARTS_ROW(scanCd) {
    for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
        if (ItsGrid.GetValue('grid1', i, 'ITEMID') == scanCd
            || String(ItsGrid.GetValue('grid1', i, 'ITEMCD')).toUpperCase() == scanCd.toUpperCase()) {
            return i;
        }
    }
    return -1;
}

// 설비부품 재고조회 버튼
ItsButton.Event('btn_SEARCH').onClick = function () {
    SEARCH_EQMPARTS();
};

// 조회 조건 중요도등급·로케이션 변경 시 바로 재조회
ItsCombo.Event('cmb_S_GRADE').onChanged = function (value, oldValue) {
    SEARCH_EQMPARTS();
};

ItsCombo.Event('cmb_S_LOCACD').onChanged = function (value, oldValue) {
    SEARCH_EQMPARTS();
};

// 설비부품 바코드 스캔 (스캐너가 Enter 를 붙여 보냄, 라벨 바코드는 품목ID)
ItsText.Event('txt_SCAN').onKeyEnter = function (value, oldValue) {
    var scanCd = $.trim(value);
    if (scanCd == '') {
        return;
    }

    var rowIndex = FIND_EQMPARTS_ROW(scanCd);
    if (rowIndex < 0) {
        // 조회 조건에 걸려 목록에 없을 수 있으므로 조건을 전체로 풀고 다시 조회
        ItsCombo.SetValue('cmb_S_GRADE', '', false);
        ItsCombo.SetValue('cmb_S_LOCACD', '', false);
        SEARCH_EQMPARTS();
        rowIndex = FIND_EQMPARTS_ROW(scanCd);
    }

    if (rowIndex < 0) {
        ItsText.SetValue('txt_SCAN', '', false);
        ItsMsg.Alert('등록되지 않은 설비부품입니다. (' + scanCd + ')', function () {
            ItsText.Focus('txt_SCAN');
        });
        return;
    }

    ItsText.SetValue('txt_SCAN', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'), false);
    ItsGrid.SelectRow('grid1', rowIndex);
    OPEN_OUT_POP(rowIndex);
};

// 재고 그리드 출고·출고 이력·라벨출력 버튼
ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
    var ITEMID = ItsGrid.GetValue('grid1', rowIndex, 'ITEMID');

    if (field == 'OUT') {
        OPEN_OUT_POP(rowIndex);
    }
    else if (field == 'HIS') {
        ItsText.SetValue('pop_txt_HIS_ITEMID', ITEMID);
        ItsDateRange.SetValueFrom('pop_date_HIS', ItsHelper.GetYearMonthDay());
        ItsDateRange.SetValueTo('pop_date_HIS', ItsHelper.GetYearMonthDay());
        ItsPop.Open('pop_HIS');
        SEARCH_OUT_HIS();
    }
    else if (field == 'PRINT_LABEL') {
        PRINT_LABEL(ITEMID);
    }
};

// 설비부품 출고등록 팝업 오픈 (초기화 시 작업장 콤보 변경 이벤트로 라인·설비 목록도 비워짐)
function OPEN_OUT_POP(rowIndex) {
    ItsPage.InitData('pdiv_OUT');
    ItsText.SetValue('pop_txt_ITEMID', ItsGrid.GetValue('grid1', rowIndex, 'ITEMID'));
    ItsText.SetValue('pop_txt_ITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));
    ItsText.SetValue('pop_txt_ITEMNM', ItsGrid.GetValue('grid1', rowIndex, 'ITEMNM'));
    ItsNum.SetValue('pop_num_LOTQTY', ItsGrid.GetValue('grid1', rowIndex, 'LOTQTY'));
    ItsDate.SetValue('pop_date_OUTDATE', ItsHelper.GetYearMonthDay());
    ItsCombo.SetValue('pop_cmb_OUTTP', 'OUT_01');
    ItsFind.SetValue('pop_find_EMPCD', ItsPage.EMPCD);
    ItsPop.Open('pop_OUT');
}

// 프로시저 목록으로 콤보 채우기 (첫 줄 빈 값)
function SET_COMBO_LIST(id, callType, params) {
    var labels = [''];
    var values = [''];
    if (callType != '') {
        var maria = new ItsMaria('TAL0001_R09', callType);
        for (var key in params) {
            maria.AddParam(key, params[key]);
        }
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
        } else {
            for (var i = 0; i < maria.store.data.length; i++) {
                labels.push(String(maria.store.data[i].Label).replace(/'/g, "''"));
                values.push(String(maria.store.data[i].Value).replace(/'/g, "''"));
            }
        }
    }
    ItsCombo.SetValue(id, '', false);
    ItsCombo.SetListByArr(id, labels, values);
}

// 작업장별 라인 목록 (작업장 미선택 시 빈 목록)
function LOAD_EQMGROUP1(lineCd) {
    SET_COMBO_LIST('pop_cmb_EQMGROUP1', lineCd == '' ? '' : 'LIST_EQMGROUP1', { LINECD: lineCd });
    LOAD_EQMCD(lineCd, '');
}

// 작업장·라인별 설비 목록 (작업장·라인 미선택 시 빈 목록)
function LOAD_EQMCD(lineCd, eqmGroup1) {
    SET_COMBO_LIST('pop_cmb_EQMCD', lineCd == '' || eqmGroup1 == '' ? '' : 'LIST_EQMCD', { LINECD: lineCd, EQMGROUP1: eqmGroup1 });
}

// 출고 팝업 작업장 선택 시 라인 목록 변경
ItsCombo.Event('pop_cmb_LINECD').onChanged = function (value, oldValue) {
    LOAD_EQMGROUP1(value);
};

// 출고 팝업 라인 선택 시 설비 목록 변경
ItsCombo.Event('pop_cmb_EQMGROUP1').onChanged = function (value, oldValue) {
    LOAD_EQMCD(ItsCombo.GetValue('pop_cmb_LINECD'), value);
};

// 출고 등록 후 재고 재조회
ItsPop.Event('pop_OUT').onAddBtnClick = function () {
    ItsMsg.Confirm('설비부품을 출고하시겠습니까?', function () {
        var maria = new ItsMaria('TAL0001_R09', 'OUT_EQMPARTS');
        maria.AddPanel('pdiv_OUT');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsPop.Close('pop_OUT');
        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        SEARCH_EQMPARTS();
        ItsText.Focus('txt_SCAN');
    });
};

ItsPop.Event('pop_OUT').onCancelBtnClick = function () {
    ItsPop.Close('pop_OUT');
    ItsText.Focus('txt_SCAN');
};

// 선택 부품 출고 이력 조회
function SEARCH_OUT_HIS() {
    var maria = new ItsMaria('TAL0001_R09', 'LIST_OUT_EQMPARTS');
    maria.AddPanel('pdiv_HIS');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_HIS', maria.store);
}

// 출고 이력조회 버튼
ItsButton.Event('btn_SEARCH_HIS').onClick = function () {
    SEARCH_OUT_HIS();
};

// 출고 이력 출고취소 (이력 삭제 및 재고 복원)
ItsGrid.Event('grid_HIS').onButtonClick = function (rowIndex, field) {
    if (field != 'CANCEL') {
        return;
    }

    var INOUTKEY = ItsGrid.GetValue('grid_HIS', rowIndex, 'INOUTKEY');
    ItsMsg.Confirm('출고를 취소하시겠습니까?', function () {
        var maria = new ItsMaria('TAL0001_R09', 'CANCEL_OUT_EQMPARTS');
        maria.AddParam('INOUTKEY', INOUTKEY);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
        SEARCH_EQMPARTS();
        SEARCH_OUT_HIS();
    });
};

// 로케이션 지정·해제 팝업 오픈 (재고 그리드 선택 부품)
ItsButton.Event('btn_LOCA').onClick = function () {
    var rowIndex = ItsGrid.GetCurrentIndex('grid1');
    if (ItsGrid.Length('grid1') <= 0 || rowIndex < 0) {
        ItsMsg.Alert('로케이션을 지정할 설비부품을 선택해주세요.');
        return;
    }

    var LOCACD = ItsGrid.GetValue('grid1', rowIndex, 'LOCACD') || '';
    var LOCANM = ItsGrid.GetValue('grid1', rowIndex, 'LOCANM') || '';
    ItsText.SetValue('pop_txt_LOCA_ITEMID', ItsGrid.GetValue('grid1', rowIndex, 'ITEMID'));
    ItsText.SetValue('pop_txt_LOCA_ITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));
    ItsText.SetValue('pop_txt_LOCA_ITEMNM', ItsGrid.GetValue('grid1', rowIndex, 'ITEMNM'));
    ItsText.SetValue('pop_txt_CURLOCANM', LOCANM == '' ? '미지정' : LOCANM);
    ItsCombo.SetValue('pop_cmb_LOCACD', LOCACD, false);
    ItsPop.Open('pop_LOCA');
};

// 로케이션 지정(SET_LOCA)·해제(CLEAR_LOCA) 저장 후 재조회, 같은 부품 다시 선택
function SAVE_LOCA(callType) {
    var ITEMID = ItsText.GetValue('pop_txt_LOCA_ITEMID');
    var maria = new ItsMaria('TAL0001_R09', callType);
    maria.AddPanel('pdiv_LOCA');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsPop.Close('pop_LOCA');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
    SEARCH_EQMPARTS();

    var rowIndex = FIND_EQMPARTS_ROW(ITEMID);
    if (rowIndex >= 0) {
        ItsGrid.SelectRow('grid1', rowIndex);
    }
    ItsText.Focus('txt_SCAN');
}

ItsPop.Event('pop_LOCA').onAddBtnClick = function () {
    ItsMsg.Confirm('로케이션을 지정하시겠습니까?', function () {
        SAVE_LOCA('SET_LOCA');
    });
};

ItsButton.Event('btn_CLEAR_LOCA').onClick = function () {
    ItsMsg.Confirm('로케이션을 해제하시겠습니까?', function () {
        SAVE_LOCA('CLEAR_LOCA');
    });
};

ItsPop.Event('pop_LOCA').onCancelBtnClick = function () {
    ItsPop.Close('pop_LOCA');
    ItsText.Focus('txt_SCAN');
};

// 선택 부품 라벨 출력
function PRINT_LABEL(ITEMID) {
    var maria2 = new ItsMaria('TAL0001_R09', 'GET_LABELCD');
    maria2.CallProc();
    if (maria2.isError) {
        maria2.ShowErrMsg();
        return;
    }

    var maria = new ItsMaria('TAL0001_R09', 'LABEL_REPRINT');
    maria.AddParam('ITEMID', ITEMID);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var label = new ItsTmlLabel(maria2.store.data[0].LABELCD, maria.ToString());
    label.Call();
    if (label.isError) {
        ItsMsg.Alert('라벨 출력에 실패했습니다. 프린터를 확인해주세요.');
    }
}
