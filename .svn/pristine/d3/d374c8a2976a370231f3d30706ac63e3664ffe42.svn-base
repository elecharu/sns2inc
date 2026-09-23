/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* PRD7001_R02 (영진산업) : 생산 관리 ▶ 단말기별 정보 ▷ 단말기별 작업자 */

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/// <reference path="../../Script/reference.js" />

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 페이지 내 태그 로딩을 완료한 다음 실행 */

ItsPage.Load = function () {

    ItsGrid.Create('grid_TML', { }, [
        column.create('공장', 'FACTORYCD', { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'FACTORYCD' }),
        column.band('단말기', {}, [
            column.create('코드', 'TMLCD', { width: 100 }),
            column.create('이름', 'TMLNM', { width: 150 })
        ]),
        column.split()
    ]);

    ItsGrid.Create('grid_TMLEMP', { isCheckBoxGrid: true }, [
        column.create('사원 코드', 'EMPCD', { width: 90, readOnly: false, align: 'center' }),
        column.create('성명', 'EMPNM', { width: 80, align: 'center' }),
        column.create('부서', 'DEPTNM', { width: 100 }),
        column.create('직위', 'COLONELCYNM', { width: 100 }),
        column.create('현장', 'SITEYN', { width: 50, columnType: enumColumnTypes.check }),
        column.create('상태', 'EMPSTTNM', { width: 80, align: 'center' }),
        column.create('비고', 'REMARK', { width: 400, readOnly: false }),
        column.split()
    ]);
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 전역변수 */

var POPSTT = 'N';

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 초기화 */

ItsButton.EventInit = function () {
    if (POPSTT == 'N') {            // FindPop 이 띄워져 있지 않은 상태에서 초기화
        ItsPage.InitData('sdiv1');
        ItsGrid.Clear('grid_TMLEMP');
        ItsGrid.Clear('grid_TML');
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 조회 */

ItsButton.EventSearch = function (mode) {
    if (POPSTT == 'N') {
        var maria = new ItsMaria('PRD7001_R02', 'LIST_MSTTML');
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
    var maria = new ItsMaria('PRD7001_R02', 'LIST_MSTTMLEMP');
    maria.AddParam('TMLCD', ItsGrid.GetValue('grid_TML', rowIndex, 'TMLCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
    }
    else {
        ItsGrid.SetStore('grid_TMLEMP', maria.store.YnToBool('SITEYN'));
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 */

ItsButton.EventAdd = function () {
    if (POPSTT == 'N') {
        if (ItsGrid.Length('grid_TML') > 0) {
            ItsGrid.AddRow('grid_TMLEMP', 0, {
                TMLCD: ItsGrid.GetValue('grid_TML', ItsGrid.GetCurrentIndex('grid_TML'), 'TMLCD'),
                EMPCD: '',
                DEPTPNM: '',
                COLONELCYNM: '',
                SITEYN: false,
                EMPSTTNM: '',
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
/* 단말기별 사원 추가 - FindPop 호출 */

ItsGrid.Event('grid_TMLEMP').onDoubleClick = function (rowIndex, field) {

    if (field == 'EMPCD') {

        if (ItsGrid.GetValue('grid_TMLEMP', rowIndex, 'REGYN') == 'N') {

            POPSTT = 'Y';

            ItsPop.OpenFindCOM({ gpcd: 'EMPCD', ref03: '1' }, function (res) {

                for (var i = 0; i < ItsGrid.Length('grid_TMLEMP') ; i++) {

                    if (ItsGrid.GetValue('grid_TMLEMP', i, 'EMPCD') == res['CODE']) {
                        ItsMsg.Alert('이미 등록한 사원입니다.');
                        POPSTT = 'N';
                        return;
                    }
                }
                ItsGrid.SetRowData('grid_TMLEMP', rowIndex, {
                    isRowCheck: true,
                    EMPCD: res['CODE'],
                    EMPNM: res['NAME'],
                    COLONELCYNM: res['REF01'],
                    DEPTNM: res['REF02'],
                    EMPSTTNM: res['REF03'],
                    SITEYN: ItsHelper.ToBoolean(res['REF10']),
                    REGYN: 'N'
                });
                POPSTT = 'N';
            });
        }
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* FindPop 닫기 */

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

            var maria = new ItsMaria('PRD7001_R02', 'UP_MSTTMLEMP');
            for (var i = 0; i < ItsGrid.Length('grid_TMLEMP') ; i++) {
                if (ItsGrid.IsChecked('grid_TMLEMP', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_TMLEMP', i);
                    maria.AddList('TMLCD_LIST', ROWDATA.TMLCD);
                    maria.AddList('EMPCD_LIST', ROWDATA.EMPCD);
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
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 삭제 */

ItsButton.EventDelete = function () {

    if (POPSTT == 'N') {

        var GRIDCNT = ItsGrid.Length('grid_TML');

        if (GRIDCNT > 0) {

            var DELCNT = 0;
            var ROWDATA;

            var maria = new ItsMaria('PRD7001_R02', 'DEL_MSTTMLEMP');

            for (var i = 0; i < ItsGrid.Length('grid_TMLEMP') ; i++) {
                if (ItsGrid.IsChecked('grid_TMLEMP', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_TMLEMP', i);
                    maria.AddList('TMLCD_LIST', ROWDATA.TMLCD);
                    maria.AddList('EMPCD_LIST', ROWDATA.EMPCD);
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
/* FindPop을 통해서만 사원 추가 */

ItsGrid.Event('grid_TMLEMP').onBeginningEdit = function (rowIndex, field, value) {
    if (field == 'EMPCD') {
        throw '';
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
