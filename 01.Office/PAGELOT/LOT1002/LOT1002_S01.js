/// <reference path="../../Script/reference.js" />


/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: true, allowMerging: 'Cells', isSubTotalGrid: true }, [
        column.create('입고키', 'INKEY', { width: 100, hidden: true }),
        column.create('입고일자', 'INDATE', { width: 100, align: 'center', allowMerging: true }),
        column.create('등록일시', 'RTIME', { width: 100, align: 'center', allowMerging: true }),
        column.create('창고코드', 'WARECD', { width: 100, hidden: true }),
        column.create('창고명', 'WARENM', { width: 100, align: 'center', allowMerging: true }),
        column.create("입고구분", "INTP", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'INTP', align: 'center', allowMerging: true }),
        column.create('사원', 'EMPNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('사유', 'REMARK', { width: 100, allowMerging: true }),
        column.create("품목유형", "ITEMCG", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 250, allowMerging: true }),
        column.create('로트번호', 'LOTKEY', { width: 110, align: 'center' }),
        column.create('입고수량', 'INQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true, allowMerging: 'Cells', isSubTotalGrid: true }, [
        column.create('출고키', 'OUTKEY', { width: 100, hidden: true }),
        column.create('출고일자', 'OUTDATE', { width: 100, align: 'center', allowMerging: true }),
        column.create('등록일시', 'RTIME', { width: 100, align: 'center', allowMerging: true }),
        column.create('창고코드', 'WARECD', { width: 100, hidden: true }),
        column.create('창고명', 'WARENM', { width: 100, align: 'center', allowMerging: true }),
        column.create("출고구분", "OUTTP", { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'OUTTP', align: 'center', allowMerging: true }),
        column.create('사원', 'EMPNM', { width: 100, align: 'center', allowMerging: true }),
        column.create('사유', 'REMARK', { width: 100, allowMerging: true }),
        column.create("품목유형", "ITEMCG", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 250, allowMerging: true }),
        column.create('로트번호', 'LOTKEY', { width: 110, align: 'center' }),
        column.create('출고수량', 'OUTQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.split()
    ]);

    ItsDateRange.SetInitValueFrom('dr_DATE', ItsHelper.GetYearMonth() + '-01');
};

/* 조회 */
ItsButton.EventSearch = function () {
    if (ItsTab.GetIndex('tab1') == 1) {
        var maria = new ItsMaria('LOT1002_S01', 'LIST_OUT_ETC');

        maria.AddPanel('sdiv1');

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid2', maria.store);

        ItsGrid.Get('grid2').autoSizeColumns();
    }
    else {
        var maria = new ItsMaria('LOT1002_S01', 'LIST_IN_ETC');

        maria.AddPanel('sdiv1');

        maria.CallProc();

        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid1', maria.store);

        ItsGrid.Get('grid1').autoSizeColumns();
    }

};


ItsButton.Event('btn_DELETE_INOUT_ETC').onClick = function () {
    ItsMsg.Confirm("기타입출고 이력을 삭제하시겠습니까?",
        function () {
            if (ItsTab.GetIndex('tab1') == 0) {
                var maria = new ItsMaria('LOT1002_S01', 'ETC_IN_DEL');

                for (var i = 0; i < ItsGrid.Length('grid1'); i++) {
                    if (ItsGrid.IsChecked('grid1', i)) {
                        maria.AddList('LOTKEYLIST', ItsGrid.GetValue('grid1', i, 'LOTKEY'));
                        maria.AddList('INKEYLIST', ItsGrid.GetValue('grid1', i, 'INKEY'));
                    }
                }

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsMsg.Alert('삭제되었습니다.');

                ItsButton.EventSearch();
            }
            else if (ItsTab.GetIndex('tab1') == 1) {
                var maria = new ItsMaria('LOT1002_S01', 'ETC_OUT_DEL');

                for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
                    if (ItsGrid.IsChecked('grid2', i)) {
                        maria.AddList('LOTKEYLIST', ItsGrid.GetValue('grid2', i, 'LOTKEY'));
                        maria.AddList('OUTKEYLIST', ItsGrid.GetValue('grid2', i, 'OUTKEY'));
                    }
                }

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsMsg.Alert('삭제되었습니다.');

                ItsButton.EventSearch();
            }
        });
}
