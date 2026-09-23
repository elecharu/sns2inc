
/// <reference path="../../Script/reference.js" />

    /* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid_SALODRD_ROUT', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells', groupField: 'SALODRNM' }, [
        column.create('수주명', 'SALODRNM', { width: 110, align: 'center', hidden: true }),
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
        column.create('외주출고', 'OUTQTY', { width: 100, align: 'center' }),
        column.create('외주입고', 'INQTY', { width: 100, align: 'center' }),
        column.create('조립수량', 'ASYQTY', { width: 100, align: 'center' }),
        column.create('포장수량', 'PACKQTY', { width: 100, align: 'center' }),
        column.create('실적상세 보기', 'POP_LIST_PRDRST', { width: 150, columnType: enumColumnTypes.button, iconCls: 'fa-search' }),        
        
        column.split()
    ]);

    ItsGrid.Create('grid_PRDRST', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('등록시간', 'RSTTIME', { width: 100, align: 'center' }),
        column.create('거래처', 'CUSTNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('제품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),     
        column.create('반제품코드', 'SUBITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('설비', 'EQMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('양품수량', 'GOODQTY', { width: 100, align: 'center' }),
        column.create('불량수량', 'BADQTY', { width: 100, align: 'center' }),
        column.create('불량유형', 'BADCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BADCD' }),  
        column.create('외주출고', 'OUTQTY', { width: 100, align: 'center' }),
        column.create('외주입고', 'INQTY', { width: 100, align: 'center' }),
        column.split()
    ]);
};
/*************************************************************************************************************************************************************************/   
// 수주 작업공정 조회
ItsButton.Event('btn_LIST_SALODRD_ROUT').onClick = function () {    
    var maria = new ItsMaria('TAL1001_S01', 'LIST_SALODRD_ROUT');

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
    if (field == 'POP_LIST_PRDRST') {
        // 실적상세보기
        LIST_PRDRST();
        ItsPop.Open('pop_LIST_PRDRST');
        ItsGrid.Get('grid_PRDRST').autoSizeColumns();
    }
};

// 생산실적 조회
LIST_PRDRST = function () {
    var maria = new ItsMaria('TAL1001_S01', 'LIST_PRDRST');

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

    ItsGrid.SetStore('grid_PRDRST', maria.store);

    ItsGrid.Get('grid_PRDRST').autoSizeColumns();
}
/*************************************************************************************************************************************************************************/