/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* SYS4002_R03: 시스템 관리 ▶ 시스템 관리 ▷ 시스템 I/F 결과조회 */

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/// <reference path="../../Script/reference.js" />

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 전역변수 */

var POPSTT = 'N';

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 페이지 내 태그 로딩을 완료한 다음 실행 */

ItsPage.Load = function () {

    /* grid_PLC */
    ItsGrid.Create('grid_PLC', { lockColumn:  3 }, [
        column.create('I/F 코드', 'PLCCD', { width: 80 }),
        column.create('I/F명', 'PLCNM', { width: 120 }),
        column.create('IP주소', 'PLCIP', { width: 100 }),
        column.create('포트번호', 'PLCPORT', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('프레임 타입', 'FRAMETP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'FRAMETP', hidden: true }),
        column.create('수집 주기(초)', 'READCYCLE', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0, hidden: true }),
        column.create('히스토리 주기(초)', 'HISCYCLE', { width: 120, columnType: enumColumnTypes.number, decimalPrecision: 0, hidden: true }),
        column.create('비고', 'REMARK', { width: 200 }),
        column.split()
    ]);

    /* grid_PLCCUR */
    ItsGrid.Create('grid_PLCCUR', { isCheckBoxGrid: true, lockColumn: 5 }, [
        column.create('I/F 코드', 'PLCCD', { width: 100, hidden: true }),
        column.create('I/F 번지', 'PLCADDR', { width: 80 }),
        column.create('비고', 'REMARK', { width: 300, readOnly: false }),
        column.create('설비 코드', 'EQMCD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'EQMCD', readOnly: false }),
        column.create('정렬 순번', 'SORTNO', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('현재 값', 'PLCVALUE', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('쓰기 값', 'WRITEVALUE', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 2, readOnly: false }),
        column.create('변환계수', 'CONVFACT', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('사용', 'USEYN', { width: 60, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('읽기', 'READYN', { width: 60, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('쓰기', 'WRITEYN', { width: 60, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('카운터 번지', 'CNTYN', { width: 100, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('비가동', 'NONYN', { width: 60, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('리셋 번지', 'RESETYN', { width: 80, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('히스토리', 'HISYN', { width: 80, align: 'CENTER', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('수정시간', 'MTIME', { width: 140 }),
        column.create('작업표준항목', 'STDKNDCD', { width: 160, readOnly: false }),
        column.split()
    ]);

    /* sdiv1 */
    ItsCombo.SetValueByIndex('cmb_FRAMETP_sdiv1', 0);

    /* pdiv1 */
    ItsNum.SetInitValue('num_CONVFACT_pdiv1', 1);
};


/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 초기화 */

ItsButton.EventInit = function () {
    
    ItsGrid.Clear('grid_PLCCUR');
    ItsGrid.Clear('grid_PLC');

    ItsPage.InitData('sdiv1');
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 조회 */

ItsButton.EventSearch = function (EVENT) {
    switch (POPSTT) {

        /* 지원하지 않음 */
        case 'Y':
            ItsMsg.Alert('지원하지 않는 동작입니다.');
            return;

            /* I/F 조회 */
        case 'N':
            var maria = new ItsMaria('SYS4002_R03', 'LIST_PLC');
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
/* 상세 조회 */

ItsGrid.Event('grid_PLC').onSelect = function (rowIndex, field) {
    var maria = new ItsMaria('SYS4002_R03', 'LIST_PLCCUR');
    maria.AddParam('PLCCD', ItsGrid.GetValue('grid_PLC', rowIndex, 'PLCCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsGrid.SetStore('grid_PLCCUR', maria.store.YnToBool('USEYN').YnToBool('READYN').YnToBool('WRITEYN').YnToBool('CNTYN').YnToBool('NONYN').YnToBool('RESETYN').YnToBool('HISYN'));
};


/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 추가 - 팝업 */

ItsButton.EventAdd = function () {
    switch (POPSTT) {

        /* 지원하지 않음 */
        case 'Y':
            ItsMsg.Alert('지원하지 않는 동작입니다.');
            break;

        /* I/F 수집항목 추가 */
        case 'N':
            ItsPage.InitData('pdiv1');
            ItsPop.Open('pop1');
            POPSTT = 'Y';
            ItsText.Focus('txt_PLCADDR_pdiv1');
            break;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 추가 - 저장 */

ItsPop.Event('pop1').onAddBtnClick = function () {

    var PLCIDX = ItsGrid.GetCurrentIndex('grid_PLC');
    
    var maria = new ItsMaria('SYS4002_R03', 'ADD_PLCCUR');
    maria.AddParam('PLCCD', ItsGrid.GetValue('grid_PLC', PLCIDX, 'PLCCD'));
    maria.AddPanel('pdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.Setkey('grid_PLCCUR', 'PLCADDR', ItsText.GetValue('txt_PLCADDR_pdiv1'));
    ItsPop.Close('pop1');
    POPSTT = 'N';

    ItsGrid.Event('grid_PLC').onSelect(PLCIDX, 'PLCCD');
    ItsMsg.Toast(ItsMsg.CommonMsg.AddComplete);
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 추가 - 취소 */

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    POPSTT = 'N';
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 추가 - 강제 닫기 */

ItsPop.Event('pop1').onPopClosed = function () {
    POPSTT = 'N';
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 저장(수정) */

ItsButton.EventSave = function () {

    switch (POPSTT) {

        /* I/F 수집항목 저장 */
        case 'N':
            var GRIDLEN = ItsGrid.Length('grid_PLCCUR');
            if (GRIDLEN == 0) {
                ItsMsg.Alert('I/F 설비정보가 조회되지 않았습니다.')
                return;
            }

            var maria = new ItsMaria('SYS4002_R03', 'UP_PLCCUR');
            var ROWDATA;
            var UPCNT = 0;
            for (var i = 0; i < ItsGrid.Length('grid_PLCCUR') ; i++) {
                if (ItsGrid.IsChecked('grid_PLCCUR', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_PLCCUR', i);
                    maria.AddList('PLCCD_LIST', ROWDATA.PLCCD);
                    maria.AddList('PLCADDR_LIST', ROWDATA.PLCADDR);
                    maria.AddList('STDKNDCD_LIST', ROWDATA.STDKNDCD);
                    maria.AddList('EQMCD_LIST', ROWDATA.EQMCD);
                    maria.AddList('SORTNO_LIST', ItsHelper.ToDecimal(ROWDATA.SORTNO));
                    maria.AddList('PLCVALUE_LIST', ItsHelper.ToDecimal(ROWDATA.PLCVALUE));
                    maria.AddList('WRITEVALUE_LIST', ItsHelper.ToDecimal(ROWDATA.WRITEVALUE));
                    maria.AddList('CONVFACT_LIST', ItsHelper.ToDecimal(ROWDATA.CONVFACT));
                    maria.AddList('USEYN_LIST', ItsHelper.ToYn(ROWDATA.USEYN));
                    maria.AddList('READYN_LIST', ItsHelper.ToYn(ROWDATA.READYN));
                    maria.AddList('WRITEYN_LIST', ItsHelper.ToYn(ROWDATA.WRITEYN));
                    maria.AddList('CNTYN_LIST', ItsHelper.ToYn(ROWDATA.CNTYN));
                    maria.AddList('NONYN_LIST', ItsHelper.ToYn(ROWDATA.NONYN));
                    maria.AddList('RESETYN_LIST', ItsHelper.ToYn(ROWDATA.RESETYN));
                    maria.AddList('HISYN_LIST', ItsHelper.ToYn(ROWDATA.HISYN));
                    maria.AddList('REMARK_LIST', ROWDATA.REMARK);
                    UPCNT++;
                }
            }

            if (UPCNT == 0) {
                ItsMsg.Alert('I/F 설비정보가 선택되지 않았습니다.');
                return;
            }

            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsGrid.Event('grid_PLC').onSelect(ItsGrid.GetCurrentIndex('grid_PLC'), 'PLCCD');
            ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete(UPCNT));
            break;

            /* I/F 추가 */
        case 'Y':
            ItsPop.Event('pop1').onAddBtnClick();
            break;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 상세 삭제 */

ItsButton.EventDelete = function () {

    switch (POPSTT) {

        /* 지원하지 않음 */
        case 'Y':
            ItsMsg.Alert('지원하지 않는 동작입니다.');
            break;

            /* PLC 삭제 */
        case 'N':
            var GRIDLEN = ItsGrid.Length('grid_PLCCUR');
            if (GRIDLEN == 0) {
                ItsMsg.Alert('I/F 설비정보가 조회되지 않았습니다.')
                return;
            }

            var maria = new ItsMaria('SYS4002_R03', 'DEL_PLCCUR');
            var ROWDATA;
            var DELCNT = 0;

            for (var i = 0; i < ItsGrid.Length('grid_PLCCUR') ; i++) {
                if (ItsGrid.IsChecked('grid_PLCCUR', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_PLCCUR', i);
                    maria.AddList('PLCCD_LIST', ROWDATA.PLCCD);
                    maria.AddList('PLCADDR_LIST', ROWDATA.PLCADDR);
                    DELCNT++;
                }
            }

            if (DELCNT == 0) {
                ItsMsg.Alert('I/F 수집항목이 선택되지 않았습니다.');
                return;
            }

            ItsMsg.Confirm('선택한 I/F 설비정보를 삭제하시겠습니까?',
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