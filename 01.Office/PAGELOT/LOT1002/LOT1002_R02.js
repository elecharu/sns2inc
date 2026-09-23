/// <reference path="../../Script/reference.js" />


ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isSubTotalGrid: true }, [
        column.create('품목ID', 'ITEMID', { width: 100, hidden: true }),
        column.create('창고코드', 'WARECD', { width: 100, hidden: true }),
        column.create('창고명', 'WARENM', { width: 100, align: 'center' }),
        column.create("품목유형", "ITEMCG", { width: 90, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 300 }),
        column.create('재고', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create('로트번호', 'LOTKEY', { width: 120, align: 'center' }),
        column.create('로트수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('출고수량', 'OUTQTY', { width: 100, columnType: enumColumnTypes.number, readOnly: false }),
        column.split()
    ]);

    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
};
/***************************************************************************************************************************************************************************** */
/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('LOT1002_R02', 'LIST_COMLOT_ITEM');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsGrid.Get('grid1').autoSizeColumns();
};
/***************************************************************************************************************************************************************************** */
ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('LOT1002_R02', 'LIST_COMLOT_LOTLIST');

    maria.AddRecord('grid1', rowIndex);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid2').autoSizeColumns();
  
}
/***************************************************************************************************************************************************************************** */
ItsButton.Event('btn_OUT_ETC').onClick = function () {
    ItsMsg.Confirm("기타출고처리 하시겠습니까?",
        function () {
            var cnt = 0;
            var maria = new ItsMaria('LOT1002_R02', 'ETC_OUT');

            maria.AddParam('ITEMID', ItsGrid.GetValue('grid1', ItsGrid.$GetRowIndex('grid1'), 'ITEMID'));
            maria.AddParam('OUTDATE', ItsDate.GetValue('date_OUTDATE'));
            maria.AddParam('OUTTP', ItsCombo.GetValue('cmb_OUTTP'));
            maria.AddParam('EMPCD', ItsFind.GetValue('find_EMPCD'));
            maria.AddParam('REMARK', ItsText.GetValue('txt_REMARK'));

            for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
                //ItsGrid.CheckRow('grid2', i); 
                if (ItsGrid.IsChecked('grid2', i)) {
                    if (ItsGrid.GetValue('grid2', i, 'OUTQTY') == '') {
                        ItsMsg.Alert('출고수량을 입력하세요.');
                        return;
                    }
                    if (ItsGrid.GetValue('grid2', i, 'OUTQTY') > ItsGrid.GetValue('grid2', i, 'LOTQTY')) {
                        ItsMsg.Alert('출고수량을 확인하세요.');
                        return;
                    }
                    maria.AddList('LOTKEYLIST', ItsGrid.GetValue('grid2', i, 'LOTKEY'));
                    maria.AddList('OUTQTYLIST', ItsGrid.GetValue('grid2', i, 'OUTQTY'));
                    cnt++;
                }
            }

            maria.CallProc();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsGrid.UnCheckAll('grid2');

            ItsMsg.Toast(ItsMsg.CommonMsg.DisposeComplete(cnt));

            var current_index = ItsGrid.$GetRowIndex('grid1');

            ItsButton.EventSearch();

            ItsGrid.SelectRow('grid1', current_index);
        });
}