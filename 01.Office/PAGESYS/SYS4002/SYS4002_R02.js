/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* SYS4002_R02: 시스템 관리 ▶ 시스템 관리 ▷ 시스템 I/F 정보등록 */

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/// <reference path="../../Script/reference.js" />

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 전역변수 */

var POPSTT = 'N';

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 페이지 내 태그 로딩을 완료한 다음 실행 */

ItsPage.Load = function () {

    /* grid_PLC */
    ItsGrid.Create('grid_PLC', { isCheckBoxGrid: true}, [
        column.create('I/F 코드', 'PLCCD', { width: 80 }),
        column.create('I/F명', 'PLCNM', { width: 120, readOnly: false }),
        column.create('IP주소', 'PLCIP', { width: 100, readOnly: false }),
        column.create('포트번호', 'PLCPORT', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('프레임 타입', 'FRAMETP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'FRAMETP', readOnly: false }),
        column.create('수집 주기 (초)', 'READCYCLE', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('히스토리 주기 (초)', 'HISCYCLE', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('비고', 'REMARK', { width: 200, readOnly: false }),
        column.split()
    ]);

    /* grid_PLCADDR */
    ItsGrid.Create('grid_PLCADDR', { isCheckBoxGrid: true }, [
        column.create('시작번지', 'SADDR', { width: 80 }),
        column.create('할당번지', 'EADDR', { width: 80, readOnly: false }),
        column.create('비고', 'REMARK', { width: 200, readOnly: false }),
        column.split()
    ]);

    /* sdiv1 */
    ItsCombo.SetValueByIndex('cmb_FRAMETP_sdiv1', 0);

    /* pdiv1 */
    ItsNum.SetInitValue('num_READCYCLE_pdiv1', 2);
    ItsNum.SetInitValue('num_HISCYCLE_pdiv1', 5);
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 초기화 */

ItsButton.EventInit = function() {

    ItsGrid.Clear('grid_PLC');
    ItsGrid.Clear('grid_PLCADDR');

    ItsPage.InitData('sdiv1');
    ItsPage.InitData('ddiv1');
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 조회 */

ItsButton.EventSearch = function (EVENT) {

    switch (POPSTT) {

        /* 지원하지 않음 */
        case 'Y':
            ItsMsg.Alert('지원하지 않는 동작입니다.');
            break;

        /* PLC 조회 */
        case 'N':
            var maria = new ItsMaria('SYS4002_R02', 'LIST_PLC');
            maria.AddPanel('sdiv1');
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsGrid.SetStore('grid_PLC', maria.store);
            if (EVENT == undefined) {
                ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
            }
            break;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 */

ItsButton.EventAdd = function () {

    switch (POPSTT) {

        /* 지원하지 않음 */
        case 'Y':
            ItsMsg.Alert('지원하지 않는 동작입니다.');
            break;

        /* PLC 추가 팝업 */
        case 'N':
            ItsPage.InitData('pdiv1');
            ItsPop.Open('pop1');
            POPSTT = 'Y';
            ItsCombo.SetValueByIndex('cmb_FRAMETP_pdiv1', 0);
            ItsText.Focus('txt_PLCCD_pdiv1');
            break;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 - 저장 */

ItsPop.Event('pop1').onAddBtnClick = function () {

    var maria = new ItsMaria('SYS4002_R02', 'ADD_PLC');
    maria.AddPanel('pdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.Setkey('grid_PLC', 'PLCCD', ItsText.GetValue('txt_PLCCD_pdiv1'));
    ItsPop.Close('pop1');
    POPSTT = 'N';
    ItsButton.EventSearch('EDIT');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 - 취소 */

ItsPop.Event('pop1').onCancelBtnClick = function () {

    ItsPop.Close('pop1');
    POPSTT = 'N';
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 - 강제 닫기 */

ItsPop.Event('pop1').onPopClosed = function () {

    POPSTT = 'N';
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 저장 (수정) */
ItsButton.EventSave = function () {

    switch (POPSTT) {

        /* I/F 저장 */
        case 'N':
            var GRIDLEN = ItsGrid.Length('grid_PLC');
            if (GRIDLEN == 0) {
                ItsMsg.Alert('I/F가 조회되지 않았습니다.')
                return;
            }

            var maria = new ItsMaria('SYS4002_R02', 'UP_PLC');
            var ROWDATA;
            var UPCNT = 0;
            for (var i = 0; i < ItsGrid.Length('grid_PLC') ; i++) {
                if (ItsGrid.IsChecked('grid_PLC', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_PLC', i);
                    maria.AddList('PLCCD_LIST', ROWDATA.PLCCD);
                    maria.AddList('PLCNM_LIST', ROWDATA.PLCNM);
                    maria.AddList('PLCIP_LIST', ROWDATA.PLCIP);
                    maria.AddList('PLCPORT_LIST', ItsHelper.ToDecimal(ROWDATA.PLCPORT));
                    maria.AddList('FRAMETP_LIST', ROWDATA.FRAMETP);
                    maria.AddList('READCYCLE_LIST', ItsHelper.ToDecimal(ROWDATA.READCYCLE));
                    maria.AddList('HISCYCLE_LIST', ItsHelper.ToDecimal(ROWDATA.HISCYCLE));
                    maria.AddList('REMARK_LIST', ROWDATA.REMARK);
                    UPCNT++;
                }
            }

            if (UPCNT == 0) {
                ItsMsg.Alert('I/F가 선택되지 않았습니다.');
                return;
            }

            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsButton.EventSearch('EDIT');
            ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(UPCNT));
            break;

        /* I/F 추가 */
        case 'Y':
            ItsPop.Event('pop1').onAddBtnClick();
            break;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 삭제 */

ItsButton.EventDelete = function () {

    switch (POPSTT) {
        
        /* 지원하지 않음 */
        case 'Y':
            ItsMsg.Alert('지원하지 않는 동작입니다.');
            break;

        /* PLC 삭제 */
        case 'N':
            var GRIDLEN = ItsGrid.Length('grid_PLC');
            if (GRIDLEN == 0) {
                ItsMsg.Alert('I/F가 조회되지 않았습니다.')
                return;
            }

            var maria = new ItsMaria('SYS4002_R02', 'DEL_PLC');
            var DELCNT = 0;
            for (var i = 0; i < ItsGrid.Length('grid_PLC') ; i++) {
                if (ItsGrid.IsChecked('grid_PLC', i)) {
                    maria.AddList('PLCCD_LIST', ItsGrid.GetValue('grid_PLC', i, 'PLCCD'));
                    DELCNT++;
                }
            }

            if (DELCNT == 0) {
                ItsMsg.Alert('I/F가 선택되지 않았습니다.');
                return;
            }

            ItsMsg.Confirm('선택한 I/F정보를 삭제하시겠습니까?',
                function () {
                    maria.CallProc();
                    if (maria.isError) {
                        maria.ShowErrMsg();
                        return;
                    }
                    ItsButton.EventSearch('EDIT');
                    ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(DELCNT));
                },
                function () {
                    ItsMsg.Toast('삭제가 취소되었습니다.');
                }
            );
            break;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 조회 */

ItsGrid.Event('grid_PLC').onSelect = function (rowIndex, field) {
    var maria = new ItsMaria('SYS4002_R02', 'LIST_PLCADDR');
    maria.AddParam('PLCCD', ItsGrid.GetValue('grid_PLC', rowIndex, 'PLCCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid_PLCADDR', maria.store);
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 추가 */

ItsButton.Event('ADD_PLCADDR_ddiv1').onClick = function () {

    ItsMsg.Confirm('새로운 I/F 수집 영역을 추가하시겠습니까?',
        function () {
            var PLCIDX = ItsGrid.GetCurrentIndex('grid_PLC');

            var maria = new ItsMaria('SYS4002_R02', 'ADD_PLCADDR');
            maria.AddParam('PLCCD', ItsGrid.GetValue('grid_PLC', PLCIDX, 'PLCCD'));
            maria.AddPanel('ddiv1');
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsGrid.Setkey('grid_PLCADDR', 'SADDR', ItsText.GetValue('txt_SADDR_ddiv1'));
            ItsGrid.Event('grid_PLC').onSelect(PLCIDX);
            ItsPage.InitData('ddiv1');
            ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
        },
        function () {
            ItsMsg.Toast('추가가 취소되었습니다.');
        }
    );
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 수정 */

ItsButton.Event('UP_PLCADDR_ddiv1').onClick = function () {
    var GRIDLEN = ItsGrid.Length('grid_PLCADDR');
    if (GRIDLEN == 0) {
        ItsMsg.Alert('I/F 수집영역이 조회되지 않았습니다.');
        return;
    }

    var PLCIDX = ItsGrid.GetCurrentIndex('grid_PLC');
    var ROWDATA;
    var UPCNT = 0;
    var maria = new ItsMaria('SYS4002_R02', 'UP_PLCADDR');

    maria.AddParam('PLCCD', ItsGrid.GetValue('grid_PLC', PLCIDX, 'PLCCD'));

    for (var i = 0; i < ItsGrid.Length('grid_PLCADDR') ; i++) {
        if (ItsGrid.IsChecked('grid_PLCADDR', i)) {
            ROWDATA = ItsGrid.GetRowData('grid_PLCADDR', i);
            maria.AddList('SADDR_LIST', ROWDATA.SADDR);
            maria.AddList('EADDR_LIST', ROWDATA.EADDR);
            maria.AddList('REMARK_LIST', ROWDATA.REMARK);
            UPCNT++;
        }
    }

    if (UPCNT == 0) {
        ItsMsg.Alert('I/F 수집영역이 선택되지 않았습니다.');
        return;
    }

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.Event('grid_PLC').onSelect(PLCIDX, 'PLCCD');
    ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(UPCNT));
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 삭제 */

ItsButton.Event('DEL_PLCADDR_ddiv1').onClick = function () {

    var GRIDLEN = ItsGrid.Length('grid_PLCADDR');
    if (GRIDLEN == 0) {
        ItsMsg.Alert('I/F 수집영역이 조회되지 않았습니다.');
        return;
    }

    var PLCIDX = ItsGrid.GetCurrentIndex('grid_PLC');
    var DELCNT = 0;
    var maria = new ItsMaria('SYS4002_R02', 'DEL_PLCADDR');

    maria.AddParam('PLCCD', ItsGrid.GetValue('grid_PLC', PLCIDX, 'PLCCD'));

    for (var i = 0; i < ItsGrid.Length('grid_PLCADDR') ; i++) {
        if (ItsGrid.IsChecked('grid_PLCADDR', i)) {
            maria.AddList('SADDR_LIST', ItsGrid.GetValue('grid_PLCADDR', i, 'SADDR'));
            DELCNT++;
        }
    }

    if (DELCNT == 0) {
        ItsMsg.Alert('I/F 수집영역이 선택되지 않았습니다.');
        return;
    }

    ItsMsg.Confirm('선택한 I/F 수집영역을 삭제하시겠습니까?',
        function () {
            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsGrid.Event('grid_PLC').onSelect(PLCIDX, 'PLCCD');
            ItsMsg.Toast(ItsMsg.CommonMsg.DeleteComplete(DELCNT));
        },
        function () {
            ItsMsg.Toast('삭제가 취소되었습니다.');
            return;
        }
    );   
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */