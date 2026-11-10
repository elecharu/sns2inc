/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 설비부품 재고 그리드 (현재고가 안전재고보다 적으면 행 분홍색)
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create('설비부품코드', 'ITEMCD', { width: 160, align: 'center' }),
        column.create('설비부품명', 'ITEMNM', { width: 280 }),
        column.create('중요도등급', 'GRADE', { width: 110, align: 'center' }),
        column.create('로케이션', 'LOCANM', { width: 140, align: 'center' }),
        column.create('안전재고', 'SAFEQTY', { width: 110, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('현재고', 'LOTQTY', { width: 110, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('단위', 'ITEMUNIT', { width: 80, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DM150' }),
        column.create('출고', 'OUT', { width: 90, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create('출고 이력', 'HIS', { width: 110, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        column.create('라벨출력', 'PRINT_LABEL', { width: 110, columnType: enumColumnTypes.button, iconCls: 'fa-print' }),
        column.create('품목ID', 'ITEMID', { hidden: true }),
    ]);

    // 출고 이력 그리드
    ItsGrid.Create('grid_HIS', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create('발생일자', 'INOUTDATE', { width: 160, align: 'center' }),
        column.create('출고유형', 'OUTTP', { width: 220, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'INOUTTP_EQMPARTS' }),
        column.create('출고량', 'OUTQTY', { width: 150, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('처리자', 'EMPCD', { width: 180, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),
    ]);

    SEARCH_EQMPARTS();
};

// 설비부품 현재고 조회
function SEARCH_EQMPARTS() {
    var maria = new ItsMaria('TAL0001_R09', 'LIST_EQMPARTS');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
}

// 설비부품 재고조회 버튼
ItsButton.Event('btn_SEARCH').onClick = function () {
    SEARCH_EQMPARTS();
};

// 재고 그리드 출고·출고 이력·라벨출력 버튼
ItsGrid.Event('grid1').onButtonClick = function (rowIndex, field) {
    var ITEMID = ItsGrid.GetValue('grid1', rowIndex, 'ITEMID');

    if (field == 'OUT') {
        ItsPage.InitData('pdiv_OUT');
        ItsText.SetValue('pop_txt_ITEMID', ITEMID);
        ItsText.SetValue('pop_txt_ITEMCD', ItsGrid.GetValue('grid1', rowIndex, 'ITEMCD'));
        ItsText.SetValue('pop_txt_ITEMNM', ItsGrid.GetValue('grid1', rowIndex, 'ITEMNM'));
        ItsDate.SetValue('pop_date_OUTDATE', ItsHelper.GetYearMonthDay());
        ItsCombo.SetValue('pop_cmb_OUTTP', 'OUT_01');
        ItsFind.SetValue('pop_find_EMPCD', ItsPage.EMPCD);
        ItsPop.Open('pop_OUT');
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
    });
};

ItsPop.Event('pop_OUT').onCancelBtnClick = function () {
    ItsPop.Close('pop_OUT');
};
