/// <reference path="../../Script/reference.js" />

var _CHKGROUPKEY = ''; // 등록 창에서 작업 중인 실사지시
var _WARENM = '';      // 작업 중인 실사지시 창고명
var _SELLOTKEY = '';   // 로트 재조회 후 선택할 로트 (스캔·등록·삭제한 로트)

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 실사지시 그리드
    ItsGrid.Create('grid_COMCHK_GROUP', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create('실사그룹키', 'CHKGROUPKEY', { hidden: true }),
        column.create('실사일자', 'CHKDATE', { width: 150, align: 'center' }),
        column.create('창고', 'WARENM', { width: 220, align: 'center' }),
        column.create('실사명', 'CHKNM', { width: 300 }),
        column.create('품목 수', 'ITEMCNT', { width: 110, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('등록 로트', 'SCANLOTCNT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('전체 로트', 'LOTCNT', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('실사 등록', 'REG', { width: 130, columnType: enumColumnTypes.button, iconCls: 'fa-barcode' }),
        column.create('창고코드', 'WARECD', { hidden: true }),
    ]);

    // 실사품목 그리드 (실사수량 0 흰색, 전산수량과 같으면 초록, 다르면 분홍)
    ItsGrid.Create('grid_COMCHK', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create('실사키', 'CHKKEY', { hidden: true }),
        column.create('품목코드', 'ITEMCD', { width: 120, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 165 }),
        column.create('재고', 'LOTQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('실사', 'CHKQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('등록 로트', 'SCANLOTCNT', { width: 85, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('품목ID', 'ITEMID', { hidden: true }),
    ]);

    // 실사로트 그리드
    ItsGrid.Create('grid_COMLOT', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create('실사키', 'CHKKEY', { hidden: true }),
        column.create('로트번호', 'LOTKEY', { width: 200 }),
        column.create('재고', 'LOTQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('실사', 'SCANQTY', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('스캔시간', 'CHKSCANTIME', { width: 160, align: 'center' }),
        column.create('삭제', 'CANCEL', { width: 70, columnType: enumColumnTypes.button, iconCls: 'fa-times' }),
    ]);
};

// 실사지시 조회
function SEARCH_COMCHK_GROUP() {
    var maria = new ItsMaria('TAL1600_R01', 'LIST_COMCHK_GROUP');
    maria.AddParam('WARECD', ItsCombo.GetValue('cmb_WARECD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_COMCHK_GROUP', maria.store);
}

// 실사지시 조회 버튼
ItsButton.Event('btn_SEARCH').onClick = function () {
    SEARCH_COMCHK_GROUP();
};

// 실사지시 그리드 실사 등록 버튼
ItsGrid.Event('grid_COMCHK_GROUP').onButtonClick = function (rowIndex, field) {
    if (field == 'REG') {
        _CHKGROUPKEY = ItsGrid.GetValue('grid_COMCHK_GROUP', rowIndex, 'CHKGROUPKEY');
        _WARENM = ItsGrid.GetValue('grid_COMCHK_GROUP', rowIndex, 'WARENM');
        ItsPop.Open('pop_COMCHK');
    }
};

// 등록 창 열림 시 실사품목 조회
ItsPop.Event('pop_COMCHK').onPopOpened = function () {
    _SELLOTKEY = '';
    ITEM_INFO_INIT();
    ItsText.SetValue('txt_WARENM', _WARENM);
    LIST_COMCHK('');
    INPUT_INIT();
};

// 등록 창 닫힘 시 실사지시 진행 재조회
ItsPop.Event('pop_COMCHK').onPopClosed = function () {
    ItsGrid.Setkey('grid_COMCHK_GROUP', 'CHKGROUPKEY', _CHKGROUPKEY);
    SEARCH_COMCHK_GROUP();
};

// 실사품목 조회 (CHKKEY가 있으면 그 품목을 선택)
function LIST_COMCHK(CHKKEY) {
    var maria = new ItsMaria('TAL1600_R01', 'LIST_COMCHK');
    maria.AddParam('CHKGROUPKEY', _CHKGROUPKEY);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    if (maria.store.Length() == 0) {
        ItsGrid.Clear('grid_COMLOT');
        ITEM_INFO_INIT();
    }

    if (CHKKEY != '') {
        ItsGrid.Setkey('grid_COMCHK', 'CHKKEY', CHKKEY);
    }
    ItsGrid.SetStore('grid_COMCHK', maria.store);
}

// 품목 선택 시 로트 조회
ItsGrid.Event('grid_COMCHK').onSelect = function (rowIndex, field) {
    LIST_COMLOT(rowIndex);
};

// 실사로트 조회
function LIST_COMLOT(rowIndex) {
    var maria = new ItsMaria('TAL1600_R01', 'LIST_COMLOT');
    maria.AddParam('CHKKEY', ItsGrid.GetValue('grid_COMCHK', rowIndex, 'CHKKEY'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    // 품목 정보 (수량은 품목 합계, 로트가 선택되면 로트 선택 이벤트에서 그 로트 수량으로 바뀜)
    ItsText.SetValue('txt_ITEMCD', ItsGrid.GetValue('grid_COMCHK', rowIndex, 'ITEMCD'));
    ItsText.SetValue('txt_ITEMNM', ItsGrid.GetValue('grid_COMCHK', rowIndex, 'ITEMNM'));
    ItsText.SetValue('txt_LOTKEY', '');
    ItsText.SetValue('txt_LOTQTY', maria.storeExtend1.Length() > 0 ? maria.storeExtend1.data[0]['LOTQTY'] : 0);
    ItsText.SetValue('txt_CHKQTY', maria.storeExtend1.Length() > 0 ? maria.storeExtend1.data[0]['CHKQTY'] : 0);

    if (_SELLOTKEY != '') {
        ItsGrid.Setkey('grid_COMLOT', 'LOTKEY', _SELLOTKEY);
        _SELLOTKEY = '';
    }
    ItsGrid.SetStore('grid_COMLOT', maria.store);
}

// 로트 선택 시 로트번호·로트 재고수량·실사수량 표시
ItsGrid.Event('grid_COMLOT').onSelect = function (rowIndex, field) {
    ItsText.SetValue('txt_LOTKEY', ItsGrid.GetValue('grid_COMLOT', rowIndex, 'LOTKEY'));
    ItsText.SetValue('txt_LOTQTY', wijmo.Globalize.format(Number(ItsGrid.GetValue('grid_COMLOT', rowIndex, 'LOTQTY')), 'n0'));
    ItsText.SetValue('txt_CHKQTY', wijmo.Globalize.format(Number(ItsGrid.GetValue('grid_COMLOT', rowIndex, 'SCANQTY')), 'n0'));
};

// 선택 품목 정보 초기화
function ITEM_INFO_INIT() {
    ItsText.SetValue('txt_ITEMCD', '');
    ItsText.SetValue('txt_LOTKEY', '');
    ItsText.SetValue('txt_ITEMNM', '');
    ItsText.SetValue('txt_LOTQTY', '');
    ItsText.SetValue('txt_CHKQTY', '');
}

// 스캔·수량 입력칸 초기화
function INPUT_INIT() {
    ItsText.SetValue('txt_SCAN', '');
    ItsNum.SetValue('num_CHKQTY', '');
    ItsText.Focus('txt_SCAN');
}

// 로트 스캔 : 스캔한 로트의 품목을 선택하고 전산재고를 실사 수량에 표시 (수량은 사용자가 직접 눌러 입력하도록 커서를 두지 않음)
ItsText.Event('txt_SCAN').onKeyEnter = function (value, oldValue) {
    var maria = new ItsMaria('TAL1600_R01', 'COMCHKLOT_SCAN');
    maria.AddParam('CHKGROUPKEY', _CHKGROUPKEY);
    maria.AddParam('LOTKEY', value);
    maria.CallProc();
    if (maria.isError) {
        // 세션 만료·접속 오류는 공통 처리, 그 외 스캔 오류는 확인 후 LOT 칸을 비우고 다시 커서 (다음 바코드가 남은 값 뒤에 붙지 않도록)
        if (/session|세션|MySQL/.test(maria.errMessage)) {
            maria.ShowErrMsg();
            return;
        }
        ItsMsg.Alert(maria.errMessage, function () {
            INPUT_INIT();
        });
        return;
    }

    _SELLOTKEY = value;
    LIST_COMCHK(maria.store.data[0]['CHKKEY']);
    ItsNum.SetValue('num_CHKQTY', maria.store.data[0]['LOTQTY']);
    setTimeout(function () {
        document.activeElement.blur();
    }, 1);
};

// 실사 수량 엔터 시 등록
ItsNum.Event('num_CHKQTY').onKeyEnter = function () {
    ItsButton.Event('btn_ADD_COMCHKLOT').onClick();
};

// 실사 등록
ItsButton.Event('btn_ADD_COMCHKLOT').onClick = function () {
    var maria = new ItsMaria('TAL1600_R01', 'COMCHKLOT_ADD');
    maria.AddParam('CHKGROUPKEY', _CHKGROUPKEY);
    maria.AddParam('LOTKEY', ItsText.GetValue('txt_SCAN'));
    maria.AddParam('CHKQTY', ItsNum.GetValue('num_CHKQTY') == '' ? 0 : ItsNum.GetValue('num_CHKQTY'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    _SELLOTKEY = ItsText.GetValue('txt_SCAN');
    LIST_COMCHK(ItsGrid.GetValue('grid_COMCHK', ItsGrid.GetCurrentIndex('grid_COMCHK'), 'CHKKEY'));
    INPUT_INIT();
};

// 실사로트 삭제 버튼 : 실사수량 0, 스캔정보 초기화
ItsGrid.Event('grid_COMLOT').onButtonClick = function (rowIndex, field) {
    if (field == 'CANCEL') {
        var CHKKEY = ItsGrid.GetValue('grid_COMLOT', rowIndex, 'CHKKEY');
        var LOTKEY = ItsGrid.GetValue('grid_COMLOT', rowIndex, 'LOTKEY');

        ItsMsg.Confirm('삭제하시겠습니까?', function () {
            var maria = new ItsMaria('TAL1600_R01', 'COMCHKLOT_DEL');
            maria.AddParam('CHKKEY', CHKKEY);
            maria.AddParam('LOTKEY', LOTKEY);
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            _SELLOTKEY = LOTKEY;
            LIST_COMCHK(CHKKEY);
            INPUT_INIT();
        });
    }
};
