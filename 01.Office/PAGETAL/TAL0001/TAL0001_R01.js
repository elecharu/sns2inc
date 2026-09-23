/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    ItsDateRange.SetInitValueFrom('date_SEARCH', ItsHelper.AddDay(-(ItsHelper.GetYearMonthDay().substring(8, 10) - 1)));

    ItsGrid.Create('grid1', {}, [
        column.create('발주일자', 'ODRDATE', { width: 100, align: 'center', columnType: enumColumnTypes.date }),
        column.create('거래처', 'CUSTCD', { width: 150, align: 'center', columnType: enumColumnTypes.combo, gpcd:'CUSTCD' }),
        column.create('품목유형', 'ITEMTP', { width: 100, columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', align: 'center'  }),
        column.create('품목코드', 'ITEMCD', { width: 150, align: 'center' }),        
        column.create('품명', 'ITEMNM', { width: 200, align: 'center' }),
        column.create('재질', 'MATERIAL', { width: 100, align: 'center' }),
        column.create('두께', 'THICK', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('길이', 'LENGTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('폭', 'WIDTH', { width: 100, columnType: enumColumnTypes.number, aligh: 'center' }),
        column.create('발주수량', 'ODRQTY', { width: 100, columnType: enumColumnTypes.number}),
        column.create('입고수량', 'LOTQTY', { width: 100, columnType: enumColumnTypes.number }),
        column.create('잔여수량', 'REMAINQTY', { width: 100, columnType: enumColumnTypes.number }),
        column.create('단위', 'UNIT', { width: 50, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT'}),
        column.create('비고', 'REMARK', { width: 200 }),
        column.create('한로트', 'ONELOT_YN', { width: 150, align: 'center', hidden: true }),
        column.create('발주상세키', 'MTRODRDKEY', { width: 60, hidden: true }),
    ]);

    ItsGrid.Create('grid2', { isSubTotalGrid: true}, [
        column.create('입고일자', 'PRDDATE', { width: 100, align: 'center', columnType: enumColumnTypes.date }),
        column.create('품목유형', 'ITEMTP', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ITEMTP' }),
        column.create('품목코드', 'ITEMCD', { width: 150, align: 'center' }),
        column.create('품명', 'ITEMNM', { width: 200, align: 'center' }),
        column.create('입고창고', 'WARECD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'WARECD' }),
        column.create('로트번호', 'LOTKEY', { width: 150, align: 'center' }),        
        column.create('입고수량', 'INQTY', { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, groupType: enumGrouping.sum }),                
        column.create('작업자', 'EMPCD', { width: 100, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'EMPCD' }),
        column.create('가입고키', 'MTRINKEY', { width: 60, hidden: true }),
        column.create('삭제', 'DEL_MTRIN', { width: 80, columnType: enumColumnTypes.button, iconCls: 'fa-trash', hidden: false }),
    ]);

    ItsDateRange.SetInitValueFrom('date_SEARCH', ItsHelper.GetYearMonth() + '-01');
    ItsFind.SetValue('find_EMPCD', ItsPage.EMPCD);
};
/*******************************************************************************************************************************************************************/
ItsCombo.Event('cmb_ITEMTP').onChanged = function () {
    ItsCombo.SetRef01('find_ITEMCD', ItsCombo.GetValue('cmb_ITEMTP'));
};
/*******************************************************************************************************************************************************************/
// 발주조회
ItsButton.Event('button_ORDER').onClick = function () {
    LIST_MTRODRD();
}

LIST_MTRODRD = function () {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TAL0001_R01', 'LIST_MTRODRD');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    
    ItsGrid.SetStore('grid1', maria.store);  
}
/*******************************************************************************************************************************************************************/
// 입고헤더 조회 
ItsGrid.Event('grid1').onSelect = function (rowIndex, field) {
    ItsGrid.Clear('grid2');

    var maria = new ItsMaria('TAL0001_R01', 'LIST_MTRIN');

    var ONELOT_YN = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ONELOT_YN');

    maria.AddRecord('grid1', rowIndex);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }


    var WARECD = maria.storeExtend1.data[0].WARECD;
    ItsCombo.SetValue('cmb_WARECD', WARECD);

    ItsGrid.SetStore('grid2', maria.store);

};

/*******************************************************************************************************************************************************************/
//입고등록 
ItsButton.Event('btn_ADD_MTRINLOT').onClick = function () {    
    var maria = new ItsMaria('TAL0001_R01', 'ADD_MTRINLOT');

    maria.AddParam('MTRODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'MTRODRDKEY'));
    maria.AddParam('ONELOT_YN', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ONELOT_YN'));
    maria.AddPanel('pdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsNum.SetValue('num_INQTY', 0);

    ItsGrid.Setkey('grid1', 'MTRODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'MTRODRDKEY'));
    LIST_MTRODRD();

}
/*******************************************************************************************************************************************************************/
// 입고삭제
ItsGrid.Event('grid2').onButtonClick = function (rowIndex, field) {
    if (field == 'DEL_MTRIN') {
        ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
            function () {
                var maria = new ItsMaria('TAL0001_R01', 'DEL_MTRIN');

                maria.AddParam('MTRINKEY', ItsGrid.GetValue('grid2', rowIndex, 'MTRINKEY'));
                maria.AddParam('ONELOT_YN', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ONELOT_YN'));

                maria.CallProc();

                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsGrid.Setkey('grid1', 'MTRODRDKEY', ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'MTRODRDKEY'));

                LIST_MTRODRD();
            }
        );
    }
}

/*******************************************************************************************************************************************************************/

ItsCheck.Event('chk_MTRODRSTT').onChanged = function () {
    LIST_MTRODRD();
}

/*******************************************************************************************************************************************************************/