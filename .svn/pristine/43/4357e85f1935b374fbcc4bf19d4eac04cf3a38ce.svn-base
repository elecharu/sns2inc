
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
        column.create('외주출고', 'OUTQTY', { width: 100, align: 'center' }),
        column.create('외주양품입고', 'GOODQTY', { width: 120, align: 'center' }),
        column.create('외주불량입고', 'BADQTY', { width: 120, align: 'center' }),
        column.create('외주입출고 등록', 'POP_ADD_PRDRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create('외주입출고 삭제', 'POP_DEL_PRDRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),
        
        column.split()
    ]);

    ItsGrid.Create('grid_PRDRST', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('등록시간', 'RSTTIME', { width: 100, align: 'center' }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('품목코드', 'SUBITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('외주처', 'OSCCUSTNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('입출고구분', 'INOUTTP', { width: 100, align: 'center' }),
        column.create('입출고수량', 'GOODQTY', { width: 100, align: 'center' }),
        
        column.create('삭제', 'DEL_PRDRST', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);
};
/*************************************************************************************************************************************************************************/
ItsPage.onMenuClick = function () {
    ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick();
};
/*************************************************************************************************************************************************************************/   
// 수주 작업공정 조회
ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick = function () {    
    var maria = new ItsMaria('TAL1001_R03', 'LIST_SALODRD_ROUT');

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
        // 외주입출고 등록 팝업오픈
        var background = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'BACKGROUND');

        if (background != 'LIGHTGREEN') {
            var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'PRCCD');

            ItsCombo.SetRef01('cmb_BADTP', PRCCD);
            ItsCombo.SetValue('cmb_BADTP', '');

            ItsCombo.SetRef02('cmb_BADCD', PRCCD);
            ItsCombo.SetValue('cmb_BADCD', '');

            SEARCH_PRDRST();
            ItsPop.Open('pop_ADD_PRDRST');
        }
    }
    else if (field == 'POP_DEL_PRDRST') {
        // 외주입출고 삭제 팝업오픈
        var background = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'BACKGROUND');
        var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', rowindex, 'PRDINSKEY');

        if (PRDINSKEY == undefined || PRDINSKEY == '') {
            ItsMsg.Alert('외주입출고를 등록하세요.');
            return;
        }

        LIST_PRDRST();
        ItsPop.Open('pop_DEL_PRDRST');
        ItsGrid.Get('grid_PRDRST').autoSizeColumns();
    }
};

SEARCH_PRDRST = function () {
    var maria = new ItsMaria('TAL1001_R03', 'SEARCH_PRDRST');

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

    var OUTQTY_SUM = maria.store.GetValue(0, 'OUTQTY_SUM');
    var GOODQTY_SUM = maria.store.GetValue(0, 'GOODQTY_SUM');
    var BADQTY_SUM = maria.store.GetValue(0, 'BADQTY_SUM');

    ItsNum.SetValue('num_OUTQTY_SUM', OUTQTY_SUM);
    ItsNum.SetValue('num_GOODQTY_SUM', GOODQTY_SUM);
    ItsNum.SetValue('num_BADQTY_SUM', BADQTY_SUM);
};
/*************************************************************************************************************************************************************************/
// 외주입출고등록 팝업 기능

// 외주출고등록
ItsButton.Event('btn_ADD_PRDRST_OUT').onClick = function () {
    var maria = new ItsMaria('TAL1001_R03', 'ADD_PRDRST_OUT');

    var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY');
    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');
    var NEEDQTY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'NEEDQTY');
    var OUTQTY = ItsNum.GetValue('num_OUTQTY');
    var CUSTCD = ItsFind.GetValue('find_CUSTCD');

    maria.AddParam('PRDINSKEY', PRDINSKEY);
    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('NEEDQTY', NEEDQTY);
    maria.AddParam('OUTQTY', OUTQTY);
    maria.AddParam('CUSTCD', CUSTCD);

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

// 외주입고등록
ItsButton.Event('btn_ADD_PRDRST_IN').onClick = function () {
    var maria = new ItsMaria('TAL1001_R03', 'ADD_PRDRST_IN');

    var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY');
    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');
    var NEEDQTY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'NEEDQTY');
    var INQTY = ItsNum.GetValue('num_INQTY');
    var CUSTCD = ItsFind.GetValue('find_CUSTCD');

    maria.AddParam('PRDINSKEY', PRDINSKEY);
    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('NEEDQTY', NEEDQTY);
    maria.AddParam('INQTY', INQTY);
    maria.AddParam('CUSTCD', CUSTCD);    

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    
    SEARCH_PRDRST();
}

// 외주불량 입고등록
ItsButton.Event('btn_ADD_PRDRSTBAD_IN').onClick = function () {
    var maria = new ItsMaria('TAL1001_R03', 'ADD_PRDRSTBAD_IN');

    var PRDINSKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRDINSKEY');
    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');
    var NEEDQTY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'NEEDQTY');
    var CUSTCD = ItsFind.GetValue('find_CUSTCD');
    var BADQTY = ItsNum.GetValue('num_BADQTY');
    var BADCD = ItsCombo.GetValue('cmb_BADCD');    

    maria.AddParam('PRDINSKEY', PRDINSKEY);
    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('NEEDQTY', NEEDQTY);
    maria.AddParam('CUSTCD', CUSTCD);
    maria.AddParam('BADQTY', BADQTY);    
    maria.AddParam('BADCD', BADCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
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
// 외주입출고삭제 팝업 기능

// 외주입출고 조회
LIST_PRDRST = function () {
    var maria = new ItsMaria('TAL1001_R03', 'LIST_PRDRST');

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

// 외주입출고 삭제
ItsGrid.Event('grid_PRDRST').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_PRDRST') {
        ItsMsg.Confirm("외주입출고를 삭제하시겠습니까?", function () {
            var maria = new ItsMaria('TAL1001_R03', 'DEL_PRDRST');

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