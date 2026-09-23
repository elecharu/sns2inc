
/// <reference path="../../Script/reference.js" />

    /* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid_SALODRD_ROUT', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells', groupField:'SALODRDKEY' }, [
        column.create('수주품목키', 'SALODRDKEY', { width: 110, align: 'center', hidden:true }),
        column.create('납기일자', 'EXPDATE', { width: 100, align: 'center', allowMerging: true }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true }),    
        column.create('제품코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),        
        column.create('수주수량', 'ODRQTY', { width: 100, align: 'center', allowMerging: true  }),
        column.create('반제품코드', 'SUBITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('반제품명', 'SUBITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center' }),
        column.create('생산필요개수', 'NEEDQTY', { width: 110, align: 'center' }),
        column.create('생산양품', 'GOODQTY', { width: 100, align: 'center' }),
        column.create('생산불량', 'BADQTY', { width: 100, align: 'center' }),
        column.create('초중종검사 관리', 'POP_TQMRST_HEADER', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),      
        column.create('검사횟수', 'COUNT_TQMRST', { width: 100, align: 'center' }),
        
        column.split()
    ]);

    ItsGrid.Create('grid_TQMRST_HEADER', { isSubTotalGrid: false, isCheckBoxGrid: false }, [
        column.create('검사키', 'TQMRSTKEY', { width: 110, align: 'center', hidden: true }),
        column.create('검사일자', 'TQMDATE', { width: 150, align: 'center'}),
        column.create('검사자', 'EMPNM', { width: 150, align: 'center' }),
        column.create('초중종유형', 'PRCTESTTP', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'PRCTESTTP' }),     
        column.create('종합판정', 'FINALJUDGE', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'JUDGE' }),     
        column.create('검사결과등록', 'POP_TQMRST_DETAIL', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-pencil' }),
        column.create('검사삭제', 'DELETE_TQMRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),

        column.split()
    ]);

    ItsGrid.Create('grid_TQMRST_DETAIL', { isCheckBoxGrid: false }, [
        column.create("검사항목코드", "STDCD", { width: 100, hidden: true }),
        column.create("검사항목", "STDNM", { width: 200 }),
        column.create("검사방법", "STDCHKTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDCHKTP', align: 'center' }),
        column.create("측정부위", "STDPOINT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create("판정범위", "STDJUDGE_MEASURE", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'STDPOINT', align: 'center' }),
        column.create('판정기준', 'STDJUDGE', { width: 300, multiLine: true}),        
        column.create('최소값', 'MINVAL', { width: 100, align: 'center'  }),
        column.create('최대값', 'MAXVAL', { width: 100, align: 'center'  }),
        column.create('평균', 'AVG', { width: 100, align: 'center'  }),
        column.create('판정', 'JUDGE', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'JUDGE', align: 'center' }),
        
        column.create('기준값', 'STDVAL', { width: 60, readOnly: true, hidden: true }),
        column.create("단위", "STDUNIT", { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDUNIT', align: 'center', readOnly: true, hidden: true }),
        column.create('범위', 'STDRANGE', { width: 60, columnType: enumColumnTypes.combo, gpcd: 'STDRANGE', align: 'center', readOnly: true, hidden: true }),
        column.create('오차(-)', 'STDMINUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true, hidden: true }),
        column.create('오차(+)', 'STDPLUS', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 3, readOnly: true, hidden: true }),

        column.split()
    ]);

    ItsGrid.Create('grid_TQMRST_VALUE', { isCheckBoxGrid: true }, [
        column.create('검사값키', 'VALUEKEY', { width: 100, hidden: true }),
        column.create('검사값', 'VALUE', { width: 100, readOnly: false })
    ]);
};
/*************************************************************************************************************************************************************************/   
// 수주 작업공정 조회
ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick = function () {    
    var maria = new ItsMaria('TAL1002_R01', 'LIST_SALODRD_ROUT');

    maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dateR_EXPDATE'));
    maria.AddParam('EDATE', ItsDateRange.GetValueTo('dateR_EXPDATE'));

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
    if (field == 'POP_TQMRST_HEADER') {
        // 초중종검사 헤더팝업 오픈
        LIST_TQMRST_HEADER();
        ItsPop.Open('pop_TQMRST_HEADER');
    }
};
/*************************************************************************************************************************************************************************/
// 초중종검사 헤더 팝업

// 초중종검사헤더 조회
LIST_TQMRST_HEADER = function () {
    var maria = new ItsMaria('TAL1002_R01', 'LIST_TQMRST_HEADER');

    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_TQMRST_HEADER', maria.store);
}

// 초중종 검사헤더 등록
ItsButton.Event('btn_ADD_TQMRST_HEADER').onClick = function () {
    var maria = new ItsMaria('TAL1002_R01', 'ADD_TQMRST_HEADER');

    var SALODRDKEY = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SALODRDKEY');
    var SUBITEMCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'SUBITEMCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');

    var TQMDATE = ItsDate.GetValue('date_TQMDATE');
    var EMPCD = ItsFind.GetValue('find_EMPCD');
    var PRCTESTTP = ItsCombo.GetValue('cmb_PRCTESTTP');

    maria.AddParam('SALODRDKEY', SALODRDKEY);
    maria.AddParam('SUBITEMCD', SUBITEMCD);
    maria.AddParam('PRCCD', PRCCD);

    maria.AddParam('TQMDATE', TQMDATE);
    maria.AddParam('EMPCD', EMPCD);
    maria.AddParam('PRCTESTTP', PRCTESTTP);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    LIST_TQMRST_HEADER();
}

ItsGrid.Event('grid_TQMRST_HEADER').onButtonClick = function (rowindex, field) {
    if (field == 'POP_TQMRST_DETAIL') {
        // 검사값 등록
        ItsPop.Open('pop_TQMRST_DETAIL');
        LIST_TQMRST_DETAIL();                
    }
    else if (field == 'DELETE_TQMRST') {
        // 검사삭제
        ItsMsg.Confirm("검사결과를 삭제하시겠습니까?\n삭제 후에는 복구할 수 없습니다.", function () {
            var maria = new ItsMaria('TAL1002_R01', 'DELETE_TQMRST');

            var TQMRSTKEY = ItsGrid.GetValue('grid_TQMRST_HEADER', rowindex, 'TQMRSTKEY');

            maria.AddParam('TQMRSTKEY', TQMRSTKEY);

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            LIST_TQMRST_HEADER();
        });
    }
};


ItsPop.Event('pop_TQMRST_HEADER').onPopClosed = function () {
    ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick();
}
/*************************************************************************************************************************************************************************/
// 초중종검사 상세 팝업

// 초중종검사 상세 조회
LIST_TQMRST_DETAIL = function () {
    ItsGrid.Clear('grid_TQMRST_VALUE');
    ItsCheck.SetValue('check_OK', 'N');    
    ItsCheck.SetValue('check_NG', 'N');    

    var maria = new ItsMaria('TAL1002_R01', 'LIST_TQMRST_DETAIL');

    var TQMRSTKEY = ItsGrid.GetValue('grid_TQMRST_HEADER', ItsGrid.GetCurrentIndex('grid_TQMRST_HEADER'), 'TQMRSTKEY');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');

    maria.AddParam('TQMRSTKEY', TQMRSTKEY);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_TQMRST_DETAIL', maria.store);

    ItsGrid.Get('grid_TQMRST_DETAIL').autoSizeColumns();
}

ItsGrid.Event('grid_TQMRST_DETAIL').onSelect = function (rowindex, field) {
    LIST_TQMRST_VALUE();
};

// 검사값 조회
LIST_TQMRST_VALUE = function () {
    ItsGrid.Clear('grid_TQMRST_VALUE');
    ItsCheck.SetValue('check_OK', 'N');
    ItsCheck.SetValue('check_NG', 'N');    

    var maria = new ItsMaria('TAL1002_R01', 'LIST_TQMRST_VALUE');

    var TQMRSTKEY = ItsGrid.GetValue('grid_TQMRST_HEADER', ItsGrid.GetCurrentIndex('grid_TQMRST_HEADER'), 'TQMRSTKEY');
    var STDCD = ItsGrid.GetValue('grid_TQMRST_DETAIL', ItsGrid.GetCurrentIndex('grid_TQMRST_DETAIL'), 'STDCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');

    maria.AddParam('TQMRSTKEY', TQMRSTKEY);
    maria.AddParam('STDCD', STDCD);
    maria.AddParam('PRCCD', PRCCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var SAMPLESIZE = ItsGrid.GetValue('grid_TQMRST_DETAIL', ItsGrid.GetCurrentIndex('grid_TQMRST_DETAIL'), 'SAMPLESIZE');

    if (maria.store.Length() > 0) {
        ItsGrid.SetStore('grid_TQMRST_VALUE', maria.store);

        if (maria.store.Length() < SAMPLESIZE) {
            for (var i = maria.store.Length(); i < SAMPLESIZE; i++) {
                ItsGrid.AddRow('grid_TQMRST_VALUE', i);
            }
        }
    }
    else {
        for (var i = 0; i < SAMPLESIZE; i++) {
            ItsGrid.AddRow('grid_TQMRST_VALUE', i);
        }
    }    

    var JUDGE = ItsGrid.GetValue('grid_TQMRST_DETAIL', ItsGrid.GetCurrentIndex('grid_TQMRST_DETAIL'), 'JUDGE');

    if (JUDGE == 'Y')
        ItsCheck.SetValue('check_OK', 'Y');
    else if (JUDGE == 'N')
        ItsCheck.SetValue('check_NG', 'Y');
    else {
        ItsCheck.SetValue('check_OK', 'N');
        ItsCheck.SetValue('check_OK', 'N');
    }
}

// 검사결과 저장
ItsButton.Event('btn_SAVE_TQMRSTKND').onClick = function () {
    var maria = new ItsMaria('TAL1002_R01', 'SAVE_TQMRSTKND');

    var TQMRSTKEY = ItsGrid.GetValue('grid_TQMRST_HEADER', ItsGrid.GetCurrentIndex('grid_TQMRST_HEADER'), 'TQMRSTKEY');
    var STDCD = ItsGrid.GetValue('grid_TQMRST_DETAIL', ItsGrid.GetCurrentIndex('grid_TQMRST_DETAIL'), 'STDCD');
    var PRCCD = ItsGrid.GetValue('grid_SALODRD_ROUT', ItsGrid.GetCurrentIndex('grid_SALODRD_ROUT'), 'PRCCD');
    var SAMPLESIZE = ItsGrid.GetValue('grid_TQMRST_DETAIL', ItsGrid.GetCurrentIndex('grid_TQMRST_DETAIL'), 'SAMPLESIZE');
    var JUDGE = '';

    if (ItsCheck.GetValue('check_OK') == 'Y')
        JUDGE = 'Y';
    else if (ItsCheck.GetValue('check_NG') == 'Y')
        JUDGE = 'N';

    maria.AddParam('TQMRSTKEY', TQMRSTKEY);
    maria.AddParam('STDCD', STDCD);
    maria.AddParam('PRCCD', PRCCD);
    maria.AddParam('SAMPLESIZE', SAMPLESIZE);
    maria.AddParam('JUDGE', JUDGE);

    for (var i = 0; i < ItsGrid.Length('grid_TQMRST_VALUE'); i++) {
        if(ItsGrid.IsChecked('grid_TQMRST_VALUE', i)) {
            maria.AddList('VALUEKEY_LIST', ItsGrid.GetValue('grid_TQMRST_VALUE', i, 'VALUEKEY'));
            maria.AddList('VALUE_LIST', ItsGrid.GetValue('grid_TQMRST_VALUE', i, 'VALUE'));
        }        
    }

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var index_grid_TQMRST_DETAIL = ItsGrid.GetCurrentIndex('grid_TQMRST_DETAIL');

    LIST_TQMRST_DETAIL();
    ItsGrid.Event('grid_TQMRST_DETAIL').onSelect(index_grid_TQMRST_DETAIL);
}

ItsCheck.Event('check_OK').onChanged = function () {
    if (ItsCheck.GetValue('check_OK') == 'Y')
        ItsCheck.SetValue('check_NG', 'N')
};

ItsCheck.Event('check_NG').onChanged = function () {
    if (ItsCheck.GetValue('check_NG') == 'Y')
        ItsCheck.SetValue('check_OK', 'N')
};

ItsPop.Event('pop_TQMRST_DETAIL').onPopClosed = function () {
    LIST_TQMRST_HEADER();
}
/*************************************************************************************************************************************************************************/