
/// <reference path="../../Script/reference.js" />

    /* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid_SALODRD', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells', groupField: 'SALODRNM' }, [
        column.create('수주명', 'SALODRNM', { width: 110, align: 'center', hidden: true }),
        column.create('수주품목키', 'SALODRDKEY', { width: 110, align: 'center', hidden:true }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center', allowMerging: true }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true}),               
        column.create('제품코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('수주수량', 'ODRQTY', { width: 110, align: 'center' }),
        column.create('조립유무', 'ASYYN', { width: 110, align: 'center', columnType: enumColumnTypes.check }),
        column.create('조립수량', 'ASYQTY', { width: 100, align: 'center' }),
        column.create('포장수량', 'PACKQTY', { width: 100, align: 'center' }),
        column.create('조립등록', 'POP_ADD_PRDRST_ASY', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),        
        column.create('포장등록', 'POP_ADD_PRDRST_PACK', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create('조립/포장 실적조회', 'POP_DEL_PRDRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),
        column.create('포장라벨출력', 'PRINT_LABEL_ALL', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-print' }),
        column.create('작업종료', 'FINISH_PRDINS', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-power-off' }),
        
        column.split()
    ]);

    ItsGrid.Create('grid_PRDRST', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('등록시간', 'RSTTIME', { width: 100, align: 'center' }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center', allowMerging: true }),        
        column.create('양품수량', 'GOODQTY', { width: 100, align: 'center' }),        
        column.create('로트번호', 'LOTKEY', { width: 100, align: 'center' }),
        column.create('라벨출력', 'PRINT_LABEL', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-print' }),
        column.create('삭제', 'DEL_PRDRST', { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);
};
/*************************************************************************************************************************************************************************/
ItsPage.onMenuClick = function () {
    ItsButton.Event('btn_LIST_SALODRD').onClick();
};
/*************************************************************************************************************************************************************************/   
// 수주제품 조회
ItsButton.Event('btn_LIST_SALODRD').onClick = function () {    
    var maria = new ItsMaria('TAL1001_R04', 'LIST_SALODRD');

    maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dateR_EXPDATE'));
    maria.AddParam('EDATE', ItsDateRange.GetValueTo('dateR_EXPDATE'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_SALODRD', maria.store.YnToBool('ASYYN'));

    ItsGrid.Get('grid_SALODRD').autoSizeColumns();
};
/*************************************************************************************************************************************************************************/
ItsGrid.Event('grid_SALODRD').onButtonClick = function (rowindex, field) {
    if (field == 'POP_ADD_PRDRST_ASY') {
        // 조립등록 팝업오픈
        var background = ItsGrid.GetValue('grid_SALODRD', rowindex, 'BACKGROUND');
        var ASYYN = ItsGrid.GetValue('grid_SALODRD', rowindex, 'ASYYN');
        var WORKSTT_ASY = ItsGrid.GetValue('grid_SALODRD', rowindex, 'WORKSTT_ASY');

        if (!ASYYN) {
            ItsMsg.Alert('미조립 수주제품 입니다.');
            return;
        }

        ItsPop.Open('pop_ADD_PRDRST_ASY');
    }
    else if (field == 'POP_ADD_PRDRST_PACK') {
        // 포장등록 팝업오픈

        ItsPop.Open('pop_ADD_PRDRST_PACK');
    }
    else if (field == 'POP_DEL_PRDRST') {
        // 조립,포장 실적조회 팝업오픈
        LIST_PRDRST();
        ItsPop.Open('pop_DEL_PRDRST');
        ItsGrid.Get('grid_PRDRST').autoSizeColumns();
    }
    else if (field == 'PRINT_LABEL_ALL') {
        // 포장라벨출력
        var maria2 = new ItsMaria('TAL1001_R04', 'GET_LABELCD');

        maria2.CallProc();

        var LABELCD = maria2.store.data[0]["LABELCD"];

        var maria = new ItsMaria('TAL1001_R04', 'PRINT_LABEL_ALL');

        var PRDINSKEY_PACK = ItsGrid.GetValue('grid_SALODRD', rowindex, 'PRDINSKEY_PACK');

        maria.AddParam('PRDINSKEY_PACK', PRDINSKEY_PACK);

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }


        var label = new ItsTmlLabel(LABELCD, maria.ToString());
        label.Call();
    }
    else if (field == 'FINISH_PRDINS') {
        // 작업종료
        ItsMsg.Confirm("작업을 종료하시겠습니까?.", function () {
            var maria = new ItsMaria('TAL1001_R04', 'FINISH_PRDINS');

            var PRDINSKEY_PACK = ItsGrid.GetValue('grid_SALODRD', rowindex, 'PRDINSKEY_PACK');
            var PRDINSKEY_ASY = ItsGrid.GetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'PRDINSKEY_ASY');

            maria.AddParam('PRDINSKEY_PACK', PRDINSKEY_PACK);
            maria.AddParam('PRDINSKEY_ASY', PRDINSKEY_ASY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsButton.Event('btn_LIST_SALODRD').onClick();
        });
    }
};
/*************************************************************************************************************************************************************************/
// 조립등록 팝업 기능

// 조립등록
ItsButton.Event('btn_ADD_PRDRST_ASY').onClick = function () {
    var maria = new ItsMaria('TAL1001_R04', 'ADD_PRDRST_ASY');

    var PRDINSKEY_ASY = ItsGrid.GetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'PRDINSKEY_ASY');
    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'SALODRDKEY');
    var ASYQTY = ItsNum.GetValue('num_ASYQTY');

    maria.AddParam('PRDINSKEY_ASY', PRDINSKEY_ASY);
    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('ASYQTY', ASYQTY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Alert('조립등록 완료.');

    if (PRDINSKEY_ASY == undefined || PRDINSKEY_ASY == '') {
        PRDINSKEY_ASY = maria.store.data[0]['PRDINSKEY'];
        ItsGrid.SetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'PRDINSKEY_ASY', PRDINSKEY_ASY);
    }
}

ItsPop.Event('pop_ADD_PRDRST_ASY').onPopClosed = function () {
    ItsButton.Event('btn_LIST_SALODRD').onClick();
}
/*************************************************************************************************************************************************************************/
// 포장등록 팝업 기능

// 포장등록
ItsButton.Event('btn_ADD_PRDRST_PACK').onClick = function () {
    var maria = new ItsMaria('TAL1001_R04', 'ADD_PRDRST_PACK');

    var PRDINSKEY_PACK = ItsGrid.GetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'PRDINSKEY_PACK');
    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'SALODRDKEY');
    var PACKQTY = ItsNum.GetValue('num_PACKQTY');

    maria.AddParam('PRDINSKEY_PACK', PRDINSKEY_PACK);
    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('PACKQTY', PACKQTY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsMsg.Alert('포장등록 완료.');

    if (PRDINSKEY_PACK == undefined || PRDINSKEY_PACK == '') {
        PRDINSKEY_PACK = maria.store.data[0]['PRDINSKEY'];
        ItsGrid.SetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'PRDINSKEY_PACK', PRDINSKEY_PACK);
    }
}

ItsPop.Event('pop_ADD_PRDRST_PACK').onPopClosed = function () {
    ItsButton.Event('btn_LIST_SALODRD').onClick();
}
/*************************************************************************************************************************************************************************/
// 조립,포장실적조회 팝업 기능

// 조립,포장실적 조회
LIST_PRDRST = function () {
    var maria = new ItsMaria('TAL1001_R04', 'LIST_PRDRST');

    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'SALODRDKEY');

    maria.AddParam('SALODRDKEY', SALODRDKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDRST', maria.store);

    ItsGrid.Get('grid_PRDRST').autoSizeColumns();
}

// 조립, 포장 삭제
ItsGrid.Event('grid_PRDRST').onButtonClick = function (rowindex, field) {
    if (field == 'DEL_PRDRST') {
        ItsMsg.Confirm("삭제하시겠습니까?", function () {
            var maria = new ItsMaria('TAL1001_R04', 'DEL_PRDRST');

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
    else if (field == 'PRINT_LABEL') {
        // 포장라벨출력
        var LOTKEY = ItsGrid.GetValue('grid_PRDRST', rowindex, 'LOTKEY');

        if (LOTKEY != undefined && LOTKEY != '') {
            var maria2 = new ItsMaria('TAL1001_R04', 'GET_LABELCD');

            maria2.CallProc();

            var LABELCD = maria2.store.data[0]["LABELCD"];

            var maria = new ItsMaria('TAL1001_R04', 'PRINT_LABEL');

            var PRDINSKEY_PACK = ItsGrid.GetValue('grid_SALODRD', ItsGrid.GetCurrentIndex('grid_SALODRD'), 'PRDINSKEY_PACK');


            maria.AddParam('PRDINSKEY_PACK', PRDINSKEY_PACK);
            maria.AddParam('LOTKEY', LOTKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            var label = new ItsTmlLabel(LABELCD, maria.ToString());
            label.Call();
        }
    }
};

ItsPop.Event('pop_DEL_PRDRST').onPopClosed = function () {
    ItsButton.Event('btn_LIST_SALODRD').onClick();
}
/*************************************************************************************************************************************************************************/