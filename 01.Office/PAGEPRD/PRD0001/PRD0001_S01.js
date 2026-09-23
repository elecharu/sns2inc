/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {  
    // 작업지시
    ItsGrid.Create('grid_PRDINS', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('작업지시번호', 'PRDINSKEY', { width: 100, align: 'center' }),
        column.create('지시일자', 'INSDATE', { width: 100, align: 'center' }),
        column.create('지시상태', 'WORKSTT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'WORKSTT', align: 'center' }),
        column.create('설비코드', 'EQMCD', { width: 100, align: 'center' }),
        column.create('설비명', 'EQMNM', { width: 100, align: 'center' }),
        column.create('원자재코드', 'MTRITEMCD', { width: 100, align: 'center' }),
        column.create('원자재명', 'MTRITEMNM', { width: 100, align: 'center' }),
        column.create('잔재코드', 'MTRITEMCD_LEFT', { width: 100, align: 'center' }),
        column.create('잔재명', 'MTRITEMNM_LEFT', { width: 100, align: 'center' }),
        column.create('특이사항', 'REMARK', { width: 100, align: 'center' }),
        column.band('작업지시서', {}, [
            column.create("파일명", "FILENAME", { width: 170 }),
            column.create('파일관리', 'POP_FILE_1', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-file' }),
        ]),

        column.split()
    ]);

    // 생산품목
    ItsGrid.Create('grid_PRDINS_SALODRD_EXTRAITEM', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('반제품코드', 'SUBITEMCD', { width: 150 }),
        column.create('반제품명', 'SUBITEMNM', { width: 200 }),
        column.create('한판생산수량', 'ONESHOTQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('지시수량', 'INSQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('생산수량', 'PRODQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('양품수량', 'GOODQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('불량수량', 'BADQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),

        column.band('수주정보', {}, [
            column.create('수주일자', 'ODRDATE', { width: 100, align: 'center' }),
            column.create('수주번호', 'SALODRDKEY', { width: 100, align: 'center' }),
            column.create('거래처', 'CUSTNM', { width: 100, align: 'center' }),
            column.create('수주상태', 'SALODRSTT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'SALODRSTT', align: 'center' }),
            column.create('제품코드', 'SALITEMCD', { width: 100 }),
            column.create('제품명', 'SALITEMNM', { width: 250 }),
            column.create('수주수량', 'ODRQTY', { width: 80 }),
            column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
            column.create('납기일자', 'EXPDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center' }),
            column.create('출고예정일', 'OUTDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center' }),
            column.create('수주비고', 'REMARK', { width: 200, align: 'center' }),
            column.create('반제품총필요개수', 'NEEDQTY', { width: 80 }),
        ]),

        column.split()
    ]);

    ItsGrid.Create('grid_PRDRST', { isSubTotalGrid: false, isCheckBoxGrid: false, }, [
        column.create('등록시간', 'RSTTIME', { width: 100, align: 'center' }),
        column.create('실적유형', 'RSTTP', { width: 100, align: 'center' }),
        column.create('불량유형', 'BADCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'BADCD' }),
        column.create('불량수량', 'BADQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('반제품코드', 'SUBITEMCD', { width: 100, align: 'center' }),
        column.create('반제품명', 'SUBITEMNM', { width: 100, align: 'center' }),

        column.split()
    ]);

    ItsGrid.Create('grid_PRDINSSCAN', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('투입시간', 'SCANTIME', { width: 100, align: 'center' }),
        column.create('창고', 'WARENM', { width: 100, align: 'center', allowMerging: true }),
        column.create('로트번호', 'LOTKEY', { width: 100, align: 'center' }),
        column.create('투입수량', 'SCANQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0}),
        column.create('사용수량', 'USEQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0}),
        column.create('단위', 'ITEMUNIT', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('재질', 'MATERIAL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center', allowMerging: true }),
        column.create('두께', 'THICK', { width: 100, align: 'center', allowMerging: true }),
        column.create('길이', 'LENGTH', { width: 120, align: 'center', allowMerging: true }),
        column.create('폭', 'WIDTH', { width: 100, align: 'center', allowMerging: true }),

        column.split()
    ]);

    ItsGrid.Create('grid_MTRLEFT', { isSubTotalGrid: false, isCheckBoxGrid: false, allowMerging: 'Cells' }, [
        column.create('창고', 'WARENM', { width: 100, align: 'center', allowMerging: true }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 100, align: 'center', allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('재질', 'MATERIAL', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center', allowMerging: true }),
        column.create('두께', 'THICK', { width: 100, align: 'center', allowMerging: true }),
        column.create('길이', 'LENGTH', { width: 120, align: 'center', allowMerging: true }),
        column.create('폭', 'WIDTH', { width: 100, align: 'center', allowMerging: true }),
        column.create('로트번호', 'LOTKEY', { width: 100, align: 'center' }),
        column.create('생성수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('현재고', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0}),
        column.create('단위', 'ITEMUNIT', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),

        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('date_INSDATE', ItsHelper.GetYearMonth() + '-01');

};
/*************************************************************************************************************************************************************************************/

/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid_PRDINS_SALODRD_EXTRAITEM');
    ItsGrid.Clear('grid_PRDRST');
    ItsGrid.Clear('grid_PRDINSSCAN');
    ItsGrid.Clear('grid_MTRLEFT');

    // 가공작업지시 조회 
    var maria = new ItsMaria('PRD0001_S01', 'LIST_PRDINS_CUT');

    maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dataR_INSDATE'));
    maria.AddParam('EDATE', ItsDateRange.GetValueTo('dataR_INSDATE'));
    maria.AddParam('EQMCD', ItsFind.GetValue('find_EQMCD'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDINS', maria.store);

    ItsGrid.Get('grid_PRDINS').autoSizeColumns();
};
/*************************************************************************************************************************************************************************************/
// 생산이력 조회 
ItsGrid.Event('grid_PRDINS').onSelect = function (rowIndex) {
    var maria = new ItsMaria('PRD0001_S01', 'LIST_PRDRST');

    maria.AddParam('PRDINSKEY', ItsGrid.GetValue('grid_PRDINS', rowIndex, 'PRDINSKEY'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid_PRDINS_SALODRD_EXTRAITEM', maria.store);
    ItsGrid.SetStore('grid_PRDRST', maria.storeExtend1);
    ItsGrid.SetStore('grid_PRDINSSCAN', maria.storeExtend2);
    ItsGrid.SetStore('grid_MTRLEFT', maria.storeExtend3);

    ItsGrid.Get('grid_PRDINS_SALODRD_EXTRAITEM').autoSizeColumns();
    ItsGrid.Get('grid_PRDRST').autoSizeColumns();
    ItsGrid.Get('grid_PRDINSSCAN').autoSizeColumns();
    ItsGrid.Get('grid_MTRLEFT').autoSizeColumns();
}

ItsTab.Event('tab1').onTabChanged = function (newPanel) {
    if (newPanel == 0) {
        ItsGrid.Get('grid_PRDINS_SALODRD_EXTRAITEM').autoSizeColumns();
    }
    else if(newPanel == 1) {
        ItsGrid.Get('grid_PRDRST').autoSizeColumns();
    }
    else if (newPanel == 2) {
        ItsGrid.Get('grid_PRDINSSCAN').autoSizeColumns();
    }
    else if (newPanel == 3) {
        ItsGrid.Get('grid_MTRLEFT').autoSizeColumns();
    }
}
/*************************************************************************************************************************************************************************************/
ItsGrid.Event('grid_PRDINS').onButtonClick = function (rowindex, field) {
    if (field == 'POP_FILE_1') {
        // 작업지시서 파일관리 오픈
        GET_FILE_1(rowindex);

        ItsPop.Open('pop_FILE_1');
    }
};

// 파일 다운로드
ItsButton.Event('btn_DOWN_FILE_1').onClick = function () {
    var url = ItsText.GetValue('txt_URL_FILE_1');
    var FILENAME = ItsFileManager.GetFileName('fm1');

    if (url != '' && url != undefined) {
        var link = document.createElement('a');
        //url = url.replace('http://mes.optisco.com:8019//', '../../');
        link.href = url;
        link.download = FILENAME.split(' | ')[0];
        link.click();
    }
    else {
        ItsMsg.Alert('등록된 파일이 없습니다.');
    }
}
/*************************************************************************************************************************************************************************************/