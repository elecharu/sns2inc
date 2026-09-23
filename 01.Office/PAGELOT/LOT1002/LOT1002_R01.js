/// <reference path="../../Script/reference.js" />


ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('품목ID', 'ITEMID', { width: 120, hidden: true }),
        column.create("품목유형", "ITEMCG", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create("공급구분", "ITEMSRC", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'DM160', align: 'center', hidden: true }),
        column.create('품목코드', 'ITEMCD', { width: 120, align: 'center' }),
        column.create('품번', 'EONO', { width: 120, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 300 }),
        column.create('규격', 'ITEMSPEC', { width: 120 }),
        column.split()
    ]);

    ItsGrid.Create('grid1_LOTLIST', { isCheckBoxGrid: false, isSubTotalGrid: true }, [
        column.create('로트번호', 'LOTKEY', { width: 120 }),
        column.create('로트수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create("단위", "ITEMUNIT", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'DM150', align: 'center' }),
        column.create('입고일자', 'PRDDATE', { width: 120 }),
        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: true }, [
        column.create('품목ID', 'ITEMID', { width: 120, hidden: true }),
        column.create("품목유형", "ITEMCG", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'DM100', align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120, readOnly: false }),
        column.create('품명', 'ITEMNM', { width: 300 }),
        column.create('로트번호', 'LOTKEY', { width: 120, readOnly: false }),
        column.create('입고수량', 'INQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, readOnly: false }),
        column.split()
    ]);

    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
};

/***********************************************************************************************************************************/
/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('LOT1002_R01', 'LIST_ITEM');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsGrid.Get('grid1').autoSizeColumns();
};

ItsGrid.Event('grid1').onSelect = function (rowIndex) {
    var maria = new ItsMaria('LOT1002_R01', 'LIST_COMLOT_LOTLIST');

    maria.AddRecord('grid1', rowIndex);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1_LOTLIST', maria.store);

    ItsGrid.Get('grid1_LOTLIST').autoSizeColumns();
}
/***********************************************************************************************************************************/
ItsButton.EventAdd = function () {
    ItsPop.Open('pop1');
}

//팝업 저장버튼 이벤트
ItsPop.Event('pop1').onAddBtnClick = function () {
    var count_row = ItsNum.GetValue('num_row');
    var indx = ItsGrid.Length('grid2');

    for (var i = 0; i < count_row; i++) {
        ItsGrid.AddRow('grid2', indx + i);
    }

    ItsPop.Close('pop1');
}

//팝업 취소버튼
ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
}
/***********************************************************************************************************************************/
ItsButton.Event('btn_IN_ETC').onClick = function () {
    ItsMsg.Confirm("기타입고처리 하시겠습니까?",
        function () {
            var cnt = 0;
            var maria = new ItsMaria('LOT1002_R01', 'ETC_IN');

            maria.AddParam('INDATE', ItsDate.GetValue('date_INDATE'));
            maria.AddParam('INTP', ItsCombo.GetValue('cmb_INTP'));
            maria.AddParam('EMPCD', ItsFind.GetValue('find_EMPCD'));
            maria.AddParam('REMARK', ItsText.GetValue('txt_REMARK'));

            for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
                if (ItsGrid.IsChecked('grid2', i)) {

                    if (ItsGrid.GetValue('grid2', i, 'INQTY') == '') {
                        ItsMsg.Alert('입고수량을 입력하세요.');
                        return;
                    }

                    maria.AddList('ITEMID_LIST', ItsGrid.GetValue('grid2', i, 'ITEMID'));
                    maria.AddList('LOTKEYLIST', ItsGrid.GetValue('grid2', i, 'LOTKEY'));
                    maria.AddList('INQTYLIST', ItsGrid.GetValue('grid2', i, 'INQTY'));
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

            // ERP IF 프로시저 호출 (2026-03-05 신정수)
            var mssql = new ItsMssql();

            mssql.AddQuery("EXEC sea_mfg.dbo.usp_z_mes_receive_305; EXEC sea_mfg.dbo.usp_z_mes_receive_306;");

            mssql.Call();

            if (mssql.isError) {
                mssql.ShowErrMsg();
                return;
            }
        });
}
/***********************************************************************************************************************************/
ItsGrid.Event('grid2').onDoubleClick = function (rowIndex, field) {
    ItsGrid.Event('grid2').onKeydownEnter(rowIndex, field);
}

ItsGrid.Event('grid2').onKeydownEnter = function (rowIndex, field) {
    if (field == 'ITEMCD') {
        var gpcd_find = 'ITEMID';

        // 품목코드 팝업 (자재창고 > 자재,부자재, 외주서브품창고 > 서브품)
        ItsPop.OpenFindCOM({
            gpcd: gpcd_find
        }
            , function (res) {
                ItsGrid.SetValue('grid2', rowIndex, 'ITEMID', res['CODE']);
                ItsGrid.SetValue('grid2', rowIndex, 'ITEMCD', res['NAME']);
                ItsGrid.SetValue('grid2', rowIndex, 'ITEMNM', res['REF01']);
                ItsGrid.SetValue('grid2', rowIndex, 'ITEMCG', res['SPEC']);
                ItsGrid.CheckRow('grid2', rowIndex);
            });
    }
}

// 데이터 복사 후 품목정보 조회
ItsGrid.Event('grid2').onChanged = function (rowIndex, field, newValue) {
    if (field == 'ITEMID') {
        var maria = new ItsMaria('LOT1002_R01', 'INFO_ITEM');
        maria.AddParam('ITEMID', newValue);
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        if (maria.store.Length() > 0) {
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMID', maria.store.data[0]["ITEMID"]);
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMCD', maria.store.data[0]["ITEMCD"]);
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMNM', maria.store.data[0]["ITEMNM"]);
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMSPEC', maria.store.data[0]["ITEMSPEC"]);
        } else {
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMID', '');
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMCD', '');
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMNM', '');
            ItsGrid.SetValue('grid2', rowIndex, 'ITEMSPEC', '');
        }
    }
}
/***********************************************************************************************************************************/