/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    // 수주
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: true, allowSorting: false }, [
        column.create('수주일자', 'ODRDATE', { width: 100, align: 'center' }),
        column.create('수주상태', 'SALODRSTT', { width: 70, columnType: enumColumnTypes.combo, gpcd: 'SALODRSTT', align: 'center' }),
        column.create('거래처코드', 'CUSTCD', { width: 100 }),
        column.create('거래처', 'CUSTNM', { width: 150, backColor: enumColor.greenLight2, align: 'center' }),

        column.create('품목코드', 'ITEMCD', { width: 100 }),
        column.create('품명', 'ITEMNM', { width: 150 }),
        column.create("버전", "REV", { width: 80, align: 'center' }),
        column.create("공정", "PRCCD", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PRCCD', align: 'center' }),

        column.create("두께", "THICK", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create("길이", "LENGTH", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create("폭", "WIDTH", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create('수주수량', 'ODRQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('스캔수량', 'SCANQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('현재고', 'SUMQTY', { width: 80, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create('단위', 'ITEMUNIT', { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create('납기일자', 'EXPDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center' }),
        column.create('출고예정일', 'OUTDATE', { width: 120, columnType: enumColumnTypes.date, align: 'center' }),

        column.create('비고', 'REMARK', { width: 150 }),

        column.create('수주상세번호', 'SALODRDKEY', { width: 100 }),

        column.split()
    ]);

    // 출하지시
    ItsGrid.Create('grid2', { isCheckBoxGrid: true, isSubTotalGrid: true }, [
        column.create("출하지시일자", "SALOUTDATE", { width: 100, columnType: enumColumnTypes.date, align: 'center', readOnly: false }),
        column.create("출하지시번호", "SALOUTKEY", { width: 100, align: 'center' }),
        column.create('거래처코드', 'CUSTCD', { width: 100 }),
        column.create('거래처', 'CUSTNM', { width: 150, backColor: enumColor.greenLight2, align: 'center' }),       
        column.create('품목코드', 'ITEMCD', { width: 100 }),
        column.create('품명', 'ITEMNM', { width: 150 }),
        column.create('출하창고', 'WARECD', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'WARECD', align: 'center', readOnly: false }),
        column.create("출하지시수량", "OUTQTY", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, readOnly: true }),
        column.create('수주상세번호', 'SALODRDKEY', { width: 100 }),

        column.create('비고', 'REMARK', { width: 150, readOnly: false }),

        column.split()
    ]);


};
/*********************************************************************************************************************************************************************/
/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('SAL0001_R01', 'LIST_SALODRD');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);

    ItsGrid.Get('grid1').autoSizeColumns();
};
// 검사구분 선택시 - 품목조회 (grid2)
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {

    ItsGrid.Clear('grid2');
    // 품목 조회 
    var maria = new ItsMaria('SAL0001_R01 ', 'LIST_SALOUT');

    maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dateR_SALOUTDATE'));
    maria.AddParam('EDATE', ItsDateRange.GetValueTo('dateR_SALOUTDATE'));
    maria.AddParam('SALODRDKEY', ItsGrid.GetValue('grid1', rowIndex, 'SALODRDKEY'));
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid2').autoSizeColumns();

};

/**********************************************************************************************************************************************************************/
ItsGrid.Event('grid1').onDoubleClick = function (rowIndex, field) {
    ItsButton.Event('btn_ADD_ROW_SALOUT').onClick();
}
///*********************************************************************************************************************************************************************/
//// 출하지시 행추가
ItsButton.Event('btn_ADD_ROW_SALOUT').onClick = function () {
    if (ItsGrid.Length('grid2') > 0) {
        return;
    }
    var cnt = ItsGrid.Length('grid2');
    ItsGrid.AddRow('grid2', cnt);

    var today = GETDATE(new Date());

    ItsGrid.SetValue('grid2', cnt, 'SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
    ItsGrid.SetValue('grid2', cnt, 'SALOUTDATE', today);
    ItsGrid.SetValue('grid2', cnt, 'CUSTCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CUSTCD'));
    ItsGrid.SetValue('grid2', cnt, 'CUSTNM', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'CUSTNM'));

    ItsGrid.SetValue('grid2', cnt, 'ITEMCD', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD'));
    ItsGrid.SetValue('grid2', cnt, 'ITEMNM', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMNM'));

    ItsGrid.SetValue('grid2', cnt, 'OUTQTY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ODRQTY'));

    ItsGrid.Get('grid2').autoSizeColumns();
};

function GETDATE(date) {
    var todayString = date.getFullYear() + "-";

    var todayMonth = date.getMonth() + 1;
    if (todayMonth < 10) {
        todayString += "0";
    }
    todayString += todayMonth + "-";

    var todayDate = date.getDate();
    if (todayDate < 10) {
        todayString += "0";
    }
    todayString += todayDate;

    return todayString;
}

/*********************************************************************************************************************************************************************/
// 출하지시 저장
ItsButton.Event('btn_SAVE_SALOUT').onClick = function () {
    ItsMsg.Confirm('선택한 출하지시를 저장하시겠습니까?',
        function () {
            var maria = new ItsMaria('SAL0001_R01', 'SAVE_SALOUT');

            for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
                if (ItsGrid.IsChecked('grid2', i)) {
                    maria.AddList('SALODRDKEY_LIST', ItsGrid.GetValue('grid2', i, 'SALODRDKEY'));
                    maria.AddList('SALOUTKEY_LIST', ItsGrid.GetValue('grid2', i, 'SALOUTKEY'));
                    maria.AddList('SALOUTDATE_LIST', ItsGrid.GetValue('grid2', i, 'SALOUTDATE'));
                    maria.AddList('CUSTCD_LIST', ItsGrid.GetValue('grid2', i, 'CUSTCD'));
                    maria.AddList('ITEMCD_LIST', ItsGrid.GetValue('grid2', i, 'ITEMCD'));
                    maria.AddList('WARECD_LIST', ItsGrid.GetValue('grid2', i, 'WARECD'));
                    maria.AddList('OUTQTY_LIST', ItsGrid.GetValue('grid2', i, 'OUTQTY'));
                    maria.AddList('REMARK_LIST', ItsGrid.GetValue('grid2', i, 'REMARK'));
                }
            }

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());
            ItsGrid.Setkey('grid1', 'SALODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY'));
            ItsButton.EventSearch();
        }
    );
}

// 출하지시 삭제
ItsButton.Event('btn_DELETE_SALOUT').onClick = function () {
    ItsMsg.Confirm('선택한 출하지시를 삭제하시겠습니까?',
        function () {
            var maria = new ItsMaria('SAL0001_R01', 'DELETE_SALOUT');

            for (var i = 0; i < ItsGrid.Length('grid2'); i++) {
                if (ItsGrid.IsChecked('grid2', i)) {
                    maria.AddList('SALOUTKEY_LIST', ItsGrid.GetValue('grid2', i, 'SALOUTKEY'));
                }
            }

            maria.CallProc();

            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }

            ItsMsg.Toast(ItsMsg.CommonMsg.SaveComplete());

            var SALODRDKEY = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'SALODRDKEY');

            ItsButton.EventSearch();
        }
    );
}
/*********************************************************************************************************************************************************************/
