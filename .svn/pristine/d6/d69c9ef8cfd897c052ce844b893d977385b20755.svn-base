/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create("공장", "FACTORYNM", { width: 100, align: 'center', allowMerging: true }),
        column.create("작업장코드", "LINECD", { width: 100, align: 'center'}),
        column.create("작업장명", "LINENM", { width: 150 }),        
        column.create("생산부서코드", "PRDDEPTCD", { width: 120, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'DEPTCD', allowMerging: true  }),
        column.create("외주업체코드", "OSCCUSTCD", { width: 150, columnType: enumColumnTypes.combo, gpcd: 'CUSTCD' }),
        //column.create("작업장그룹", "LINEGROUP", { width: 100, align: 'center' }),
        //column.create("사용재출고창고", "PRART_OUT_WH", { width: 100, align: 'center' }),
        //column.create("사용반제품출고창고", "SEMI_OUT_WH", { width: 100, align: 'center' }),
        //column.create("사용제품출고창고", "PROD_OUT_WH", { width: 100, align: 'center' }),
        //column.create("생산반제품입고창고", "SEMI_IN_WH", { width: 100, align: 'center' }),
        //column.create("생산제품입고창고", "PROD_IN_WH", { width: 100, align: 'center' }),
        column.create("폐기출고창고", "DIS_OUT_WH", { width: 100, align: 'center' }),
        column.create("생산성(공수)관리", "MHYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("사용여부", "USEYN", { width: 100, align: 'center', columnType: enumColumnTypes.check }),
        column.create("적용시작일", "SDT", { width: 150, align: 'center' }),
        column.create("적용종료일", "EDT", { width: 150, align: 'center' }),
        column.create("비고", "REMARK", { width: 300, align: 'center' }),
        //column.create("집계작업장", "SUMWC", { width: 100, align: 'center' }),
        //column.create("대표공정코드", "PRCCD", { width: 100, align: 'center' }),
        column.split()
        
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create("작업장", "LINECD", { width: 100, align: 'center', hidden: true }),
        column.create("공정명", "PRCNM", { width: 100, align: 'center' }),
        column.create("제품출고창고", "PROD_OUT_WH", { width: 120, align: 'center'}),
        column.create("반제품출고창고", "SEMI_OUT_WH", { width: 120, align: 'center'}),
        column.create("자재출고창고", "PART_OUT_WH", { width: 120, align: 'center'}),
        column.create("반제품입고창고", "SEMI_IN_WH", { width: 120, align: 'center'}),
        column.create("제품입고창고", "PROD_IN_WH", { width: 120, align: 'center' }),
        column.create("적용시작일", "SDT", { width: 150, align: 'center' }),
        column.create("적용종료일", "EDT", { width: 150, align: 'center' }),
        column.create("비고", "REMARK", { width: 300, align: 'center' }),
        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {

    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('MST1002_R02', 'SEL_LINE');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store.YnToBool('MHYN').YnToBool('USEYN'));
    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');

    //ItsGrid.Get('grid1').autoSizeColumns();
};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {

    var maria = new ItsMaria('MST1002_R02', 'SEL_LINE_PRC');
    maria.AddParam('LINECD', ItsGrid.GetValue('grid1', rowIndex, 'LINECD'));

    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
}






