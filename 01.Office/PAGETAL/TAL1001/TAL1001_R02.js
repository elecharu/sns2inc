
/// <reference path="../../Script/reference.js" />

    /* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid_SALODRD_ROUT', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells', groupField: 'SALODRNM' }, [
        column.create('수주명', 'SALODRNM', { width: 110, align: 'center', hidden: true }),
        column.create('수주품목키', 'SALODRDKEY', { width: 110, align: 'center', hidden:true }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center', allowMerging: true }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true}),               
        column.create('품목코드', 'SUBITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('품명', 'SUBITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center' }),
        column.create('생산필요개수', 'NEEDQTY', { width: 110, align: 'center' }),
        column.create('생산양품', 'GOODQTY', { width: 100, align: 'center' }),
        column.create('추가생산', 'GOODQTY_EXTRA', { width: 100, align: 'center' }),
        column.create('생산불량', 'BADQTY', { width: 100, align: 'center' }),
        column.create('생산실적 등록', 'POP_ADD_PRDRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create('생산실적 삭제', 'POP_DEL_PRDRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),  
        column.create('고객사도면 보기', 'POP_SALODRD_FILES', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),       
        column.create('작업종료', 'FINISH_PRDINS', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-power-off' }),
        
        column.split()
    ]);

    ItsGrid.Create('grid_PRDRST', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('등록시간', 'RSTTIME', { width: 100, align: 'center' }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('품목코드', 'SUBITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('설비', 'EQMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('실적유형', 'RSTTP', { width: 100, align: 'center' }),
        column.create('양품수량', 'GOODQTY', { width: 100, align: 'center' }),
        column.create('불량수량', 'BADQTY', { width: 100, align: 'center' }),
        column.create('불량유형', 'BADCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BADCD' }),        
        
        column.create('실적삭제', 'DEL_PRDRST', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);

    ItsGrid.Create('grid_SALODRD_FILES', { isCheckBoxGrid: false, isSubTotalGrid: false, allowSorting: false }, [
        column.create("파일키", "FILEKEY", { width: 100, hidden:true }),
        column.create("파일명", "FILENAME", { width: 300 }),
        column.create('파일보기', 'OPEN_FILE', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),

        column.split()
    ]);

    // 사원 기준정보에 설정된 공정을 조회조건으로 입력
    var maria = new ItsMaria('TAL1001_R02', 'SERACH_PRCCD');

    maria.AddParam('EMPCD', ItsPage.EMPCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var PRCCD = maria.store.GetValue(0, 'PRCCD');

    ItsCombo.SetValue('cmb_PRCCD', PRCCD);
};
/*************************************************************************************************************************************************************************/
ItsPage.onMenuClick = function () {
    ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick();
};
/*************************************************************************************************************************************************************************/   
// 수주 작업공정 조회
ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick = function () {    
    var maria = new ItsMaria('TAL1001_R02', 'LIST_SALODRD_ROUT');

    maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dateR_EXPDATE'));
    maria.AddParam('EDATE', ItsDateRange.GetValueTo('dateR_EXPDATE'));
    maria.AddParam('PRCCD', ItsCombo.GetValue('cmb_PRCCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_SALODRD_ROUT', maria.store);

    ItsGrid.Get('grid_SALODRD_ROUT').autoSizeColumns();
};
/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid_SALODRD_ROUT').onButtonClick = function (rowindex, field) {
    if (field == 'POP_ADD_PRDRST') {
        // 생산실적 등록 팝업오픈
        var background = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'BACKGROUND');

        if (background == 'LIGHTGREEN')
            ItsMsg.Alert('작업이 종료되어 불가능 합니다.');
        else {
            var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'PRCCD');
            ItsCombo.SetRef02('cmb_EQMCD', PRCCD);
            ItsCombo.SetValue('cmb_EQMCD', '');

            ItsCombo.SetRef01('cmb_BADTP', PRCCD);
            ItsCombo.SetValue('cmb_BADTP', '');

            ItsCombo.SetRef02('cmb_BADCD', PRCCD);
            ItsCombo.SetValue('cmb_BADCD', '');

            SEARCH_PRDRST();
            ItsPop.Open('pop_ADD_PRDRST');
        }
    }
    else if (field == 'POP_DEL_PRDRST') {
        // 생산실적 삭제 팝업오픈
        var background = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'BACKGROUND');
        var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'PRDINSKEY');

        if (PRDINSKEY == undefined || PRDINSKEY == '') {
            ItsMsg.Alert('생산실적을 등록하세요.');
            return;
        }

        if (background == 'LIGHTGREEN')
            ItsMsg.Alert('작업이 종료되어 불가능 합니다.');
        else {
            LIST_PRDRST();
            ItsPop.Open('pop_DEL_PRDRST');
            ItsGrid.Get('grid_PRDRST').autoSizeColumns();
        }
    }
    else if (field == 'POP_SALODRD_FILES') {
        LIST_SALODRD_FILES();
        ItsPop.Open('pop_SALODRD_FILES');
    }
    else if (field == 'OPEN_SALODRD_FILE1') {
        // 고객사도면(pdf) 파일오픈
        var url = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'FILEURL');

        if (url == undefined || url == '') {
            ItsMsg.Alert('등록된 고객사도면 파일이 없습니다.');
        }
        else {
            window.open(url);
        }
    }
    else if (field == 'FINISH_PRDINS') {
        // 작업종료
        ItsMsg.Confirm("작업을 종료하시겠습니까?\n종료 후 더 이상 생산실적을 등록할 수없습니다.", function () {
            var maria = new ItsMaria('TAL1001_R02', 'FINISH_PRDINS');

            var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'PRDINSKEY');

            maria.AddParam('PRDINSKEY', PRDINSKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick();
        });
    }
};

SEARCH_PRDRST = function () {
    var maria = new ItsMaria('TAL1001_R02', 'SEARCH_PRDRST');

    var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY');
    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');

    maria.AddParam('PRDINSKEY', PRDINSKEY);
    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var GOODQTY_SUM = maria.store.GetValue(0, 'GOODQTY_SUM');
    var BADQTY_SUM = maria.store.GetValue(0, 'BADQTY_SUM');

    ItsNum.SetValue('num_GOODQTY_SUM', GOODQTY_SUM);
    ItsNum.SetValue('num_BADQTY_SUM', BADQTY_SUM);
};
/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid_SALODRD_FILES').onButtonClick = function (rowindex, field) {
    if (field == 'OPEN_FILE') {
        // 고객사도면(pdf) 파일오픈
        var url = ItsGrid.GetValue('grid_SALODRD_FILES', rowindex, 'FILEURL');

        if (url == undefined || url == '') {
            ItsMsg.Alert('등록된 고객사도면 파일이 없습니다.');
        }
        else {
            window.open(url);
        }
    }
};

// 수주품목 파일조회
function LIST_SALODRD_FILES() {
    var maria = new ItsMaria('TAL1001_R02', 'LIST_SALODRD_FILES');

    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');

    maria.AddParam('SALODRDKEY', SALODRDKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_SALODRD_FILES', maria.store);
}
/*************************************************************************************************************************************************************************/
// 생산실적등록 팝업 기능

// 양품등록
ItsButton.Event('btn_ADD_PRDRSTGOOD').onClick = function () {
    var maria = new ItsMaria('TAL1001_R02', 'ADD_PRDRSTGOOD');

    var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY');
    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');
    var NEEDQTY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'NEEDQTY');
    var GOODQTY = ItsNum.GetValue('num_GOODQTY');
    var EQMCD = ItsCombo.GetValue('cmb_EQMCD');

    maria.AddParam('PRDINSKEY', PRDINSKEY);
    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('NEEDQTY', NEEDQTY);
    maria.AddParam('GOODQTY', GOODQTY);
    maria.AddParam('EQMCD', EQMCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    if (PRDINSKEY == undefined || PRDINSKEY == '') {
        PRDINSKEY = maria.store.data[0]['PRDINSKEY'];
        ItsGrid.SetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY', PRDINSKEY);
    }

    SEARCH_PRDRST();
}

// 불량등록
ItsButton.Event('btn_ADD_PRDRSTBAD').onClick = function () {
    var maria = new ItsMaria('TAL1001_R02', 'ADD_PRDRSTBAD');

    var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY');
    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');
    var NEEDQTY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'NEEDQTY');
    var BADQTY = ItsNum.GetValue('num_BADQTY');
    var EQMCD = ItsCombo.GetValue('cmb_EQMCD');
    var BADCD = ItsCombo.GetValue('cmb_BADCD');

    maria.AddParam('PRDINSKEY', PRDINSKEY);
    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('NEEDQTY', NEEDQTY);
    maria.AddParam('BADQTY', BADQTY);
    maria.AddParam('EQMCD', EQMCD);
    maria.AddParam('BADCD', BADCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    if (PRDINSKEY == undefined || PRDINSKEY == '') {
        PRDINSKEY = maria.store.data[0]['PRDINSKEY'];
        ItsGrid.SetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY', PRDINSKEY);
    }

    SEARCH_PRDRST();
}

ItsPop.Event('pop_ADD_PRDRST').onPopClosed = function () {
    ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick();
}

ItsCombo.Event('cmb_BADTP').onChanged = function (value, oldValue) {
    ItsCombo.SetRef01('cmb_BADCD', value);
    ItsCombo.SetValue('cmb_BADCD', '');
}
/*************************************************************************************************************************************************************************/
// 생산실적삭제 팝업 기능

// 생산실적 조회
LIST_PRDRST = function () {
    var maria = new ItsMaria('TAL1001_R02', 'LIST_PRDRST');

    var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY');

    maria.AddParam('PRDINSKEY', PRDINSKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDRST', maria.store);

    ItsGrid.Get('grid_PRDRST').autoSizeColumns();
}

// 생산실적 삭제
ItsGrid.Event('grid_PRDRST').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_PRDRST') {
        ItsMsg.Confirm("생산실적을 삭제하시겠습니까?", function () {
            var maria = new ItsMaria('TAL1001_R02', 'DEL_PRDRST');

            var PRDRSTKEY = ItsGrid.GetValue('grid_PRDRST', rowindex, 'PRDRSTKEY');

            maria.AddParam('PRDRSTKEY', PRDRSTKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            LIST_PRDRST();
        });
    }
};

ItsPop.Event('pop_DEL_PRDRST').onPopClosed = function () {
    ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick();
}
/*************************************************************************************************************************************************************************/
