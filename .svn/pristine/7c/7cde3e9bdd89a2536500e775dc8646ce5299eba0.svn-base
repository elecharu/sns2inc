/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* PRD7001_R01 (영진산업) : 생산 관리 ▶ 단말기별 정보 ▷ 단말기 정보 */

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/// <reference path="../../Script/reference.js" />

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 페이지 내 태그 로딩을 완료한 다음 실행 */

ItsPage.Load = function () {

    ItsGrid.Create('grid_TML', { isCheckBoxGrid: true }, [
        column.band('단말기', {}, [
            column.create('코드', 'TMLCD', { width: 100 }),
            column.create('이름', 'TMLNM', { width: 150, readOnly: false })
        ]),
        column.create('순번', 'SORTNO', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('공장', 'FACTORYCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD', readOnly: false }),
        column.create('창고', 'WARECD', { width: 120, columnType: enumColumnTypes.combo, gpcd: 'WARECD', readOnly: false }),
        column.create('작업장', 'LINECD', { width: 120, columnType: enumColumnTypes.combo, gpcd: 'LINECD', readOnly: false }),
        column.create('외주처여부', 'OSCYN', { width: 70, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('IP 주소', 'IPADDR', { width: 120, readOnly: false }),
        column.create('MAC 주소', 'MACADDR', { width: 150, readOnly: false }),
        column.create('설비연동', 'EQMYN', { width: 70, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('비고', 'REMARK', { width: 300, readOnly: false }),
        column.split()
    ]);
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 전역변수 */

var POPSTT = 'N';

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 초기화 */

ItsButton.EventInit = function () {
    switch (POPSTT) {
        case 'N':
            ItsPage.InitData('sdiv1');
            ItsGrid.Clear('grid_TML');
            break;

        case 'Y':
            ItsPage.InitData('pdiv1');
            ItsCombo.SetValueByIndex('cmb_FACTORYCD_pdiv1', 1);
            ItsCheck.SetValue('chk_EQMYN_pdiv1', 'N');
            ItsText.Focus('txt_TMLCD_pdiv1');
            break;
    };
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 조회 */

ItsButton.EventSearch = function (mode) {
    if (POPSTT == 'N') {
        var maria = new ItsMaria('PRD7001_R01', 'LIST_MSTTML');
        maria.AddPanel('sdiv1');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
        }
        else {
            ItsGrid.SetStore('grid_TML', maria.store.YnToBool('EQMYN').YnToBool('OSCYN'));
            if (mode == undefined) {
                if (maria.store.Length() > 0) {
                    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
                }
                else {
                    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete());
                }
            }
        }
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 조회 */

ItsGrid.Event('grid_TML').onSelect = function (rowIndex, field) {
    ItsPage.SetStore('ddiv1', ItsGrid.GetRowData('grid_TML', rowIndex));
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 - 열기 */

ItsButton.EventAdd = function () {
    if (POPSTT == 'N') {
        ItsPop.Open('pop1');
        POPSTT = 'Y';
        ItsPage.InitData('pdiv1');
        ItsCombo.SetValueByIndex('cmb_FACTORYCD_pdiv1', 1);
        //ItsCombo.SetValueByIndex('cmb_WARECD_pdiv1', 0);
    }
};

ItsCombo.Event('cmb_FACTORYCD_pdiv1').onChanged = function (value) {
    ItsCombo.SetRef01('cmb_WARECD_pdiv1', value);
    ItsCombo.SetRef01('cmb_LINECD_pdiv1', value);
}

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 - 저장 */

ItsPop.Event('pop1').onAddBtnClick = function () {

    var maria = new ItsMaria('PRD7001_R01', 'ADD_MSTTML');
    maria.AddPanel('pdiv1');
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
    }
    else {
        ItsGrid.Setkey('grid_TML', 'TMLCD', ItsText.GetValue('txt_TMLCD_pdiv1'));
        ItsPop.Close('pop1');
        POPSTT = 'N';
        ItsButton.EventSearch('EDIT');
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 - 취소 */

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    POPSTT = 'N';
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 - 닫기 */

ItsPop.Event('pop1').onPopClosed = function () {
    POPSTT = 'N';
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 저장 */

ItsButton.EventSave = function () {
    if (POPSTT == 'N') {

        var GRIDCNT = ItsGrid.Length('grid_TML');

        if (GRIDCNT > 0) {
            var UPCNT = 0;
            var ROWDATA;

            var maria = new ItsMaria('PRD7001_R01', 'UP_MSTTML');
            for (var i = 0; i < GRIDCNT; i++) {
                if (ItsGrid.IsChecked('grid_TML', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_TML', i);
                    maria.AddList('TMLCD_LIST', ROWDATA.TMLCD);
                    maria.AddList('TMLNM_LIST', ROWDATA.TMLNM);
                    maria.AddList('SORTNO_LIST', ItsHelper.ToDecimal(ROWDATA.SORTNO));
                    maria.AddList('FACTORYCD_LIST', ROWDATA.FACTORYCD);
                    maria.AddList('WARECD_LIST', ROWDATA.WARECD);
                    maria.AddList('LINE_LIST', ROWDATA.LINECD);
                    maria.AddList('OSC_LIST', ItsHelper.ToYn(ROWDATA.OSCYN));
                    maria.AddList('IPADDR_LIST', ROWDATA.IPADDR);
                    maria.AddList('MACADDR_LIST', ROWDATA.MACADDR);
                    maria.AddList('EQMYN_LIST', ItsHelper.ToYn(ROWDATA.EQMYN));
                    maria.AddList('REMARK_LIST', ROWDATA.REMARK);
                    UPCNT++;
                }
            }

            if (UPCNT > 0) {
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                }
                else {
                    ItsButton.EventSearch('EDIT');
                    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(UPCNT));
                }
            }
            else {
                ItsMsg.Alert('선택한 항목이 없습니다.');
            }
        }
        else {
            ItsMsg.Alert('조회를 먼저 실행해주세요.');
        }
    }
    else if (POPSTT == 'Y') {
        ItsPop.Event('pop1').onAddBtnClick();
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 삭제 */

ItsButton.EventDelete = function () {
    if (POPSTT == 'N') {
        var DELCNT = 0;
        var GRIDCNT = ItsGrid.Length('grid_TML');

        var maria = new ItsMaria('PRD7001_R01', 'DEL_MSTTML');
        if (GRIDCNT > 0) {
            for (var i = 0; i < GRIDCNT; i++) {
                if (ItsGrid.IsChecked('grid_TML', i)) {
                    maria.AddList('TMLCD_LIST', ItsGrid.GetValue('grid_TML', i, 'TMLCD'));
                    DELCNT++;
                }
            }
            
            if (DELCNT > 0) {
                ItsMsg.Confirm('선택한 단말기 정보를 삭제하시겠습니까?',
                    function () {
                        maria.CallProc();
                        if (maria.isError) {
                            maria.ShowErrMsg();
                        }
                        else {
                            ItsButton.EventSearch('EDIT');
                            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(DELCNT));
                        }
                    }
                );
            }
            else {
                ItsMsg.Alert('선택한 항목이 없습니다.');
            }
        }
        else {
            ItsMsg.Alert('조회를 먼저 실행해주세요.');
        }
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 출력 */

ItsButton.EventPrint = function() {
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 닫기 */

ItsButton.EventClose = function () {
    if (POPSTT == 'N') {
        var $menuPath = location.pathname;
        parent.remove_iframe("../.." + $menuPath);
    }
    else if (POPSTT == 'Y') {
        ItsPop.Event('pop1').onCancelBtnClick();
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */