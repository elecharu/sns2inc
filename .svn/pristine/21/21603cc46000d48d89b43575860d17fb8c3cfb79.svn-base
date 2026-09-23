/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* PRD7001_R04 (영진산업) : 생산 관리 ▶ 단말기별 정보 ▷ 단말기별 설비정보 */

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

    ItsGrid.Create('grid_TMLEQM', { isCheckBoxGrid: true }, [
        column.band('설비', {}, [
            column.create('코드', 'TMLCD', { width: 100, hidden: true }),
            column.create('코드', 'EQMCD', { width: 100, readOnly: false, align: 'center' }),
            column.create('이름', 'EQMNM', { width: 150 }),
            column.create('호기', 'EQMNO', { width: 70, align: 'center' }),
            //column.create('유형', 'EQMTPNM', { width: 150 }),
            //column.create('규격', 'EQMSPEC', { width: 70 })
        ]),
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
        ItsGrid.Clear('grid_TMLEQM');
        ItsGrid.Clear('grid_TML');
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 조회 */

ItsButton.EventSearch = function (mode) {
    if (POPSTT == 'N') {
        var maria = new ItsMaria('PRD7001_R04', 'LIST_MSTTML');
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
    var maria = new ItsMaria('PRD7001_R04', 'LIST_MSTTMLEQM');
    maria.AddParam('TMLCD', ItsGrid.GetValue('grid_TML', rowIndex, 'TMLCD'));
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
    }
    else {
        ItsGrid.SetStore('grid_TMLEQM', maria.store);
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* 추가 */

ItsButton.EventAdd = function () {
    
    if (POPSTT == 'N') {

        if (ItsGrid.Length('grid_TML') > 0) {
            ItsGrid.AddRow('grid_TMLEQM', 0, {
                TMLCD: ItsGrid.GetValue('grid_TML', ItsGrid.GetCurrentIndex('grid_TML'), 'TMLCD'),
                EQMCD: '',
                EQMNM: '',
                EQMNO: '',
                EQMTPNM: '',
                EQMSPEC: '',
                PRCCD: '',
                PRCNM: '',
                EQMSER: '',
                EPOWER: null,
                EVOLT: null,
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
/* 단말기별 설비 정보 추가 - FindPop 호출 */

ItsGrid.Event('grid_TMLEQM').onDoubleClick = function (rowIndex, field) {

    if (field == 'EQMCD') {

        if (ItsGrid.GetValue('grid_TMLEQM', rowIndex, 'REGYN') == 'N') {

            POPSTT = 'Y';

            ItsPop.OpenFindCOM({ gpcd: 'EQMCD' }, function (res) {

                for (var i = 0; i < ItsGrid.Length('grid_TMLEQM') ; i++) {

                    if (ItsGrid.GetValue('grid_TMLEQM', i, 'EQMCD') == res['CODE']) {
                        ItsMsg.Alert('이미 등록한 설비입니다.');
                        POPSTT = 'N';
                        return;
                    }
                }

                ItsGrid.SetRowData('grid_TMLEQM', rowIndex, {
                    isRowCheck: true,
                    EQMCD: res['CODE'],
                    EQMNM: res['NAME'],
                    EQMNO: res['REF01'],
                    EQMTPNM: res['REF02'],
                    EQMSPEC: res['REF03'],
                    PRCCD: res['REF04'],
                    PRCNM: res['REF05'],
                    EQMSER: res['REF06'],
                    EPOWER: res['REF07'],
                    EVOLT: res['REF08'],
                    REGYN: 'N'
                });
                POPSTT = 'N'
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

        var GRIDCNT = ItsGrid.Length('grid_TMLEQM');
        if (GRIDCNT > 0) {

            var UPCNT = 0;
            var ROWDATA;

            var maria = new ItsMaria('PRD7001_R04', 'UP_MSTTMLEQM');
            for (var i = 0; i < ItsGrid.Length('grid_TMLEQM') ; i++) {
                if (ItsGrid.IsChecked('grid_TMLEQM', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_TMLEQM', i);
                    maria.AddList('TMLCD_LIST', ROWDATA.TMLCD);
                    maria.AddList('EQMCD_LIST', ROWDATA.EQMCD);
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
            var ROWDATA;

            var maria = new ItsMaria('PRD7001_R04', 'DEL_MSTTMLEQM');
            
            for (var i = 0; i < ItsGrid.Length('grid_TMLEQM') ; i++) {
                if (ItsGrid.IsChecked('grid_TMLEQM', i)) {
                    ROWDATA = ItsGrid.GetRowData('grid_TMLEQM', i);
                    maria.AddList('TMLCD_LIST', ROWDATA.TMLCD);
                    maria.AddList('EQMCD_LIST', ROWDATA.EQMCD);
                    DELCNT++;
                }
            }

            if (DELCNT > 0) {

                ItsMsg.Confirm('선택한 설비 정보를 삭제하시겠습니까?',
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
                ItsMsg.Alert('선택한 설비 정보가 없습니다.');
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
/* FindPop을 통해서만 설비 정보 추가 */

ItsGrid.Event('grid_TMLEQM').onBeginningEdit = function (rowIndex, field, value) {
    if (field == 'EQMCD') {
        throw '';
    }
};

/* ------------------------------------------------------------------------------------------------------------------------------------------------------ */
