/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    // 검사구분
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, [
        column.create('검사구분코드', 'STDTP', { width: 90, align: 'center', hidden: true }),
        column.create('검사구분', 'STDTPNM', { width: 110, align: 'center' }),
        column.split()
    ]);

    // 사용중 검사기준이 있는 품목
    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('SPC관리', 'SPC_YN', { width: 80, columnType: enumColumnTypes.check }),
        column.create('품목유형', 'ITEMCG', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create('품목ID', 'ITEMID', { width: 150, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150 }),
        column.create('품명', 'ITEMNM', { width: 250 }),
        column.split()
    ]);

    // 측정 검사항목별 CPK, PPK
    ItsGrid.Create('grid3', { isCheckBoxGrid: true }, [
        column.create('SPC관리', 'SPC_YN', { width: 80, columnType: enumColumnTypes.check }),
        column.create('검사항목코드', 'STDCD', { width: 90 }),
        column.create('검사항목', 'STDNM', { width: 150 }),
        column.create('세부항목', 'STDPART', { width: 100 }),
        column.create('세부공정', 'PRCDETAIL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PRCDETAIL', align: 'center' }),
        column.create('특성', 'FEATURE', { width: 100, align: 'center' }),
        column.create('CPK', 'CPK', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
        column.create('PPK', 'PPK', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
        column.create('X-Bar UCL', 'XBAR_UCL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
        column.create('X-Bar LCL', 'XBAR_LCL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
        column.create('X-Bar USL', 'XBAR_USL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
        column.create('X-Bar LSL', 'XBAR_LSL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
        column.create('R UCL', 'R_UCL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
        column.create('R USL', 'R_USL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: false }),
        column.split()
    ]);

    ItsCombo.SetValue('cmb_FACTORYCD', '07');   // 공장 기본값 (onChanged 로 품목 find 법인·공장도 들어감)
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('sdiv1_find_ITEMID', companycd);
    ItsFind.SetRef03('sdiv1_find_ITEMID', value);
};
/******************************************************************************************************************************************************************************/
/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('TQM4001_R01', 'LIST_STDTP');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// 검사구분 선택 - 품목 조회
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('TQM4001_R01', 'LIST_ITEM');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store.YnToBool('SPC_YN'));
};

// 품목 선택 - 측정 검사항목별 CPK, PPK 조회
ItsGrid.Event('grid2').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid3');

    var maria = new ItsMaria('TQM4001_R01', 'LIST_CPKPPK');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddParam('ITEMID', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMID'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store.YnToBool('SPC_YN'));
};
/******************************************************************************************************************************************************************************/
// SPC 관리항목 등록
ItsButton.Event('btn_ADD_SPC').onClick = function () {
    var maria = new ItsMaria('TQM4001_R01', 'ADD_SPC');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));

    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            maria.AddList('ITEMID_LIST', ItsGrid.GetValue('grid2', i, 'ITEMID'));
            cnt++;
        }
    }

    if (cnt == 0) {
        ItsMsg.Alert('등록할 품목을 체크하세요.');
        return;
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Toast('정상적으로 처리 되었습니다.');
    ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
};

// SPC 관리항목 삭제
ItsButton.Event('btn_DEL_SPC').onClick = function () {
    var maria = new ItsMaria('TQM4001_R01', 'DEL_SPC');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));

    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
        if (ItsGrid.IsChecked('grid2', i)) {
            maria.AddList('ITEMID_LIST', ItsGrid.GetValue('grid2', i, 'ITEMID'));
            cnt++;
        }
    }

    if (cnt == 0) {
        ItsMsg.Alert('삭제할 품목을 체크하세요.');
        return;
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Toast('정상적으로 처리 되었습니다.');
    ItsGrid.Event('grid1').onSelect(ItsGrid.GetCurrentIndex('grid1'));
};
/******************************************************************************************************************************************************************************/
// CPK, PPK 저장
ItsButton.Event('btn_SAVE_CPKPPK').onClick = function () {
    var maria = new ItsMaria('TQM4001_R01', 'SAVE_CPKPPK');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddParam('ITEMID', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMID'));

    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if (ItsGrid.IsChecked('grid3', i)) {
            maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid3', i, 'STDCD'));
            maria.AddList('STDPART_LIST', ItsGrid.GetValue('grid3', i, 'STDPART'));
            maria.AddList('PRCDETAIL_LIST', ItsGrid.GetValue('grid3', i, 'PRCDETAIL'));
            maria.AddList('CPK_LIST', ItsGrid.GetValue('grid3', i, 'CPK'));
            maria.AddList('PPK_LIST', ItsGrid.GetValue('grid3', i, 'PPK'));
            maria.AddList('XBAR_UCL_LIST', ItsGrid.GetValue('grid3', i, 'XBAR_UCL'));
            maria.AddList('XBAR_LCL_LIST', ItsGrid.GetValue('grid3', i, 'XBAR_LCL'));
            maria.AddList('XBAR_USL_LIST', ItsGrid.GetValue('grid3', i, 'XBAR_USL'));
            maria.AddList('XBAR_LSL_LIST', ItsGrid.GetValue('grid3', i, 'XBAR_LSL'));
            maria.AddList('R_UCL_LIST', ItsGrid.GetValue('grid3', i, 'R_UCL'));
            maria.AddList('R_USL_LIST', ItsGrid.GetValue('grid3', i, 'R_USL'));
            cnt++;
        }
    }

    if (cnt == 0) {
        ItsMsg.Alert('저장할 검사항목을 체크하세요.');
        return;
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Toast('정상적으로 처리 되었습니다.');
    ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid2'));
};

// CPK, PPK 삭제
ItsButton.Event('btn_DELETE_CPKPPK').onClick = function () {
    var maria = new ItsMaria('TQM4001_R01', 'DELETE_CPKPPK');

    maria.AddParam('STDTP', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'STDTP'));
    maria.AddParam('ITEMID', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'ITEMID'));

    var cnt = 0;
    for (var i = 0; i < ItsGrid.Length('grid3'); i++) {
        if (ItsGrid.IsChecked('grid3', i)) {
            maria.AddList('STDCD_LIST', ItsGrid.GetValue('grid3', i, 'STDCD'));
            maria.AddList('STDPART_LIST', ItsGrid.GetValue('grid3', i, 'STDPART'));
            maria.AddList('PRCDETAIL_LIST', ItsGrid.GetValue('grid3', i, 'PRCDETAIL'));
            cnt++;
        }
    }

    if (cnt == 0) {
        ItsMsg.Alert('삭제할 검사항목을 체크하세요.');
        return;
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Toast('정상적으로 처리 되었습니다.');
    ItsGrid.Event('grid2').onSelect(ItsGrid.GetCurrentIndex('grid2'));
};
/******************************************************************************************************************************************************************************/
