/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* PRD7001_R03 (영진산업) : 생산 관리 ▶ 단말기별 정보 ▷ 단말기별 프로그램 정보 */

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/// <reference path="../../Script/reference.js" />

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 페이지 내 태그 로딩을 완료한 다음 실행 */

ItsPage.Load = function () {

    ItsGrid.Create('grid_TML', {}, [
        column.create('공장', 'FACTORYCD', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD' }),
        column.band('단말기', {}, [
            column.create('코드', 'TMLCD', { width: 100 }),
            column.create('이름', 'TMLNM', { width: 150 })
        ]),
        column.split()
    ]);

    ItsGrid.Create('grid_TMLPRG', { isCheckBoxGrid: true }, [
        column.band('프로그램', {}, [
            column.create('코드', 'PRGCD', { width: 120, readOnly: false, align: 'center' }),
            column.create('이름', 'PRGNM', { width: 150, readOnly: false, align: 'center' })
        ]),
        column.create('사용여부', 'USEYN', { width: 70, align: 'center', columnType: enumColumnTypes.check, readOnly: false }),
        column.create('순번', 'SORTNO', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.create('비고', 'REMARK', { width: 300, readOnly: false }),
        column.split()
    ]);

    ItsCombo.SetValueByIndex('cmb_TMLCD_ddiv1', 0);
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
            ItsGrid.Clear('grid_TMLPRG');
            ItsCombo.SetValueByIndex('cmb_TMLCD_ddiv1', 0);
            break;

        case 'Y':
            ItsPage.InitData('pdiv1');
            break;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 조회 */

ItsButton.EventSearch = function (mode) {
    ItsGrid.Clear('grid_TMLPRG');
    if (POPSTT == 'N') {
        var maria = new ItsMaria('PRD7001_R03', 'LIST_MSTTML');
        maria.AddPanel('sdiv1');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
        }
        else {
            ItsGrid.SetStore('grid_TML', maria.store);
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
    var maria = new ItsMaria('PRD7001_R03', 'LIST_MSTTMLPRG');
    maria.AddParam('TMLCD', ItsGrid.GetValue('grid_TML', rowIndex, 'TMLCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
    }
    else {
        ItsGrid.SetStore('grid_TMLPRG', maria.store.YnToBool('USEYN'));
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 */

ItsButton.EventAdd = function () {
    if (POPSTT == 'N') {
        if (ItsGrid.Length('grid_TML') > 0) {
            ItsGrid.AddRow('grid_TMLPRG', 0, {
                PRGCD: '',
                PRGNM: '',
                USEYN: false,
                SORTNO: null,
                REMARK: '',
                REGYN: 'N'
            });
        }
        else {
            ItsMsg.Alert('조회를 먼저 실행해주세요.');
        }
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 단말기별 프로그램 정보 추가 - 선택 */

ItsGrid.Event('grid_TMLPRG').onDoubleClick = function (rowIndex, field) {

    if (field == 'PRGCD') {

        if (ItsGrid.GetValue('grid_TMLPRG', rowIndex, 'REGYN') == 'N') {

            POPSTT = 'Y';

            ItsPop.OpenFindCOM({ gpcd: 'PRGCD', ref05: 'TML' }, function (res) {

                for (var i = 0; i < ItsGrid.Length('grid_TMLPRG') ; i++) {

                    if (ItsGrid.GetValue('grid_TMLPRG', i, 'PRGCD') == res['CODE']) {
                        ItsMsg.Alert('이미 등록한 프로그램입니다.');
                        POPSTT = 'N';
                        return;
                    }
                }
                ItsGrid.SetRowData('grid_TMLPRG', rowIndex, {
                    isRowCheck: true,
                    PRGCD: res['CODE'],
                    PRGNM: res['NAME'],
                    USEYN: false,
                    SORTNO: null,
                    REMARK: '',
                    REGYN: 'N'
                });
                POPSTT = 'N';
                ItsGrid.Focus('grid_TMLPRG', rowIndex, 3);
            });
        }
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 닫기 */
ItsPop.Event('findPop_COM').onPopClosed = function () {
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

            var maria = new ItsMaria('PRD7001_R03', 'UP_MSTTMLPRG');
            maria.AddParam('TMLCD', ItsGrid.GetValue('grid_TML', ItsGrid.GetCurrentIndex('grid_TML'), 'TMLCD'));
            for (var i = 0; i < ItsGrid.Length('grid_TMLPRG') ; i++) {
                if (ItsGrid.IsChecked('grid_TMLPRG', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_TMLPRG', i);
                    maria.AddList('PRGCD_LIST', ROWDATA.PRGCD);
                    maria.AddList('PRGNM_LIST', ROWDATA.PRGNM);
                    maria.AddList('SORTNO_LIST', ROWDATA.SORTNO);
                    maria.AddList('USEYN_LIST', ItsHelper.ToYn(ROWDATA.USEYN));
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
                    ItsGrid.Setkey('grid_TML', 'TMLCD', ItsGrid.GetValue('grid_TML', ItsGrid.GetCurrentIndex('grid_TML'), 'TMLCD'));
                    ItsButton.EventSearch('EDIT');
                    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(UPCNT));
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
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 삭제 */

ItsButton.EventDelete = function () {
    if (POPSTT == 'N') {

        var GRIDCNT = ItsGrid.Length('grid_TML');
        if (GRIDCNT > 0) {
            var DELCNT = 0;
            var maria = new ItsMaria('PRD7001_R03', 'DEL_MSTTMLPRG');
            maria.AddParam('TMLCD', ItsGrid.GetValue('grid_TML', ItsGrid.GetCurrentIndex('grid_TML'), 'TMLCD'));
            for (var i = 0; i < ItsGrid.Length('grid_TMLPRG') ; i++) {
                if (ItsGrid.IsChecked('grid_TMLPRG', i)) {
                    maria.AddList('PRGCD_LIST', ItsGrid.GetValue('grid_TMLPRG', i, 'PRGCD'));
                    DELCNT++;
                }
            }

            if (DELCNT > 0) {
                ItsMsg.Confirm('선택한 항목을 삭제하시겠습니까?',
                    function () {
                        maria.CallProc();
                        if (maria.isError) {
                            maria.ShowErrMsg();
                        }
                        else {
                            ItsGrid.Setkey('grid_TML', 'TMLCD', ItsGrid.GetValue('grid_TML', ItsGrid.GetCurrentIndex('grid_TML'), 'TMLCD'));
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
ItsButton.EventPrint = function () {
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 닫기 */

ItsButton.EventClose = function () {
    switch (POPSTT) {
        case 'N':
            var $menuPath = location.pathname;
            parent.remove_iframe("../.." + $menuPath);
            break;
        case 'Y':
            ItsPop.Close('findPop_COM');
            break;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 복사 */

ItsButton.Event('COPY_MSTTML').onClick = function () {
    var GRIDCNT = ItsGrid.Length('grid_TML');
    if (GRIDCNT > 0) {
        ItsMsg.Confirm('이전의 프로그램 정보가 삭제됩니다. 진행하시겠습니까?',
            function () {
                var maria = new ItsMaria('PRD7001_R03', 'COPY_MSTTML');
                var TMLCD = ItsGrid.GetValue('grid_TML', ItsGrid.GetCurrentIndex('grid_TML'), 'TMLCD');
                maria.AddParam('TTMLCD', ItsCombo.GetValue('cmb_TMLCD_ddiv1'));
                maria.AddParam('TMLCD', TMLCD);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                }
                else {
                    ItsGrid.Setkey('grid_TML', 'TMLCD', TMLCD);
                    ItsButton.EventSearch('EDIT');
                }
            }
        );
    }
    else {
        ItsMsg.Alert('조회를 먼저 실행해주세요.');
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* FindPop을 통해서만 프로그램 추가 */

ItsGrid.Event('grid_TMLPRG').onBeginningEdit = function (rowIndex, field, value) {
    if (field == 'PRGCD') {
        return;
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
