/// <reference path="../../Script/reference.js" />
/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    // 작업지시
    ItsGrid.Create('grid_PRDINS', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('지시번호', 'PRDINSKEY', { width: 110, align: 'center' }),
        column.create('시작시간', 'INSSTIME', { width: 150, align: 'center' }),
        column.create('종료시간', 'INSETIME', { width: 150, align: 'center' }),
        column.create('작업실', 'WORKPLACE', { width: 110, align: 'center' }),
        column.create('지시수량', 'INSQTY', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('양품수량', 'LOTQTY', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('불량수량', 'BADQTY', { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.split()
    ]);

    // 사용자재
    ItsGrid.Create('grid_USELOT', { isCheckBoxGrid: false, isSubTotalGrid: true, allowMerging: 'Cells' }, [
        column.create("품목유형", "ITEMTP", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center', allowMerging: true }),
        column.create("품목코드", "ITEMCD", { width: 150, hidden: true }),
        column.create("품명", "ITEMNM", { width: 300, allowMerging: true }),
        column.create("로트번호", "USELOTKEY", { width: 200, allowMerging: true }),
        column.create("사용량", "USEQTY", { width: 80, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('지시번호', 'PRDINSKEY', { width: 150, allowMerging: true }),

        column.split()
    ]);

    // 출고
    ItsGrid.Create('grid_SALOUT', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('출하지시키', 'SALOUTKEY', { width: 100, hidden: true }),
        column.create('출고일자', 'SALOUTDATE', { width: 100, align: 'center' }),
        column.create('출고유형', 'SALOUTTP', { width: 80, align: 'center' }),
        column.create('출고상태', 'SSTATUS', { width: 80, align: 'center' }),
        column.create('수주번호', 'SALODRDKEY', { width: 100, align: 'center' }),
        column.create('수주상태', 'SALODRTP', { width: 100, align: 'center' }),
        column.create('거래처', 'CUSTCD', { width: 100, align: 'center' }),
        column.create('컨테이너번호', 'CNTRNO', { width: 100, align: 'center' }),
        column.create('Seal 번호', 'SERIAL', { width: 100, align: 'center' }),
        column.create('출고수량', 'OUTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),

        column.split()
    ]);

    //// 반품
    ItsGrid.Create('grid_RETURN', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create("반품일자", "RETURNDATE", { width: 100, align: 'center' }),
        column.create("매출처", "CUSTNM", { width: 200 }),
        column.create("반입수량", "RETURNQTY", { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("양품수량", "REGOODQTY", { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("불량수량", "REBADQTY", { width: 100, align: 'center', columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('전표번호', 'SALODRNO', { width: 100, align: 'center' }),

        column.split()
    ]);

    
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD0003_S05', 'SEARCH_LOTKEY_INFO');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        setTimeout(function () {
            maria.ShowErrMsg();
        }, 100);
        return;
    }

    ItsText.SetValue('txt_ITEMCD', maria.store.data[0]['ITEMCD']);
    ItsTextArea.SetValue('txta_ITEMNM', maria.store.data[0]['ITEMNM']);
    ItsText.SetValue('txt_PRDDATE', maria.store.data[0]['PRDDATE']);
    ItsText.SetValue('txt_PRODQTY', maria.store.data[0]['PRODQTY']);
    ItsText.SetValue('txt_OUTQTY', maria.store.data[0]['OUTQTY']);
    ItsText.SetValue('txt_LOTQTY', maria.store.data[0]['LOTQTY']);
    ItsText.SetValue('txt_WORKORDER', maria.store.data[0]['WORKORDER']);
    ItsText.SetValue('txt_CUSTNM', maria.store.data[0]['CUSTNM']);
    ItsText.SetValue('txt_CUSTLINE', maria.store.data[0]['CUSTLINE']);

    ItsGrid.SetStore('grid_PRDINS', maria.storeExtend1);
    ItsGrid.SetStore('grid_USELOT', maria.storeExtend2);
    ItsGrid.SetStore('grid_SALOUT', maria.storeExtend3);

    ItsMsg.Toast('조회되었습니다.');
};

ItsText.Event('txt_LOTKEY_INPUT').onKeyEnter = function () {
    ItsButton.EventSearch();
}