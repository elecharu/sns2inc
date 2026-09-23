/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    // 작업리스트
    ItsGrid.Create('grid1', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
   
        column.create("품목코드", "ITEMCD", { width: 150, align: 'center' }),
        column.create("품명", "ITEMNM", { width: 180, align: 'center' }),
        column.create("버전", "REV", { width: 80, align: 'center' }),
        column.create("공정", "PRCCD", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PRCCD', align: 'center' }),
        column.create("재질", "MATERIAL", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center' }),
        column.create("두께", "THICK", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create("길이", "LENGTH", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create("폭", "WIDTH", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create("총수량", "SUMQTY", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("단위", "ITEMUNIT", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),

        column.split()
    ]);

    ItsGrid.Create('grid2', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create("로트키", "LOTKEY", { width: 180, align: 'center' }),
        column.create("로트수량", "LOTQTY", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("단위", "ITEMUNIT", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),

        column.split()
    ]);

    ItsGrid.Create('grid3', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [
        column.create("출고키", "OUTKEY", { width: 150, align: 'center', hidden: true }),
        column.create("출고일자", "OUTDATE", { width: 150, align: 'center' }),
        column.create("출고유형", "OUTTP", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'OUTTP', align: 'center' }),
        column.create("작업자", "EMPCD", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'EMPCD', align: 'center' }),
        column.create("출고수량", "OUTQTY", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("단위", "ITEMUNIT", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create("비고", "REMARK", { width: 200, align: 'center' }),
        column.create("취소", "DEL", { width: 100, columnType: enumColumnTypes.button, iconCls: 'fa-trash' }),
        column.split()
    ]);

    ItsGrid.Create('grid4', { isCheckBoxGrid: false, allowFilter: false, allowSorting: false, contextMenu: false }, [

        column.create("출고키", "OUTKEY", { width: 150, align: 'center', hidden: true }),
        column.create("출고일자", "OUTDATE", { width: 180, align: 'center' }),
        column.create("출고유형", "OUTTP", { width: 80,  columnType: enumColumnTypes.combo, gpcd: 'OUTTP', align: 'center' }),
        column.create("작업자", "EMPCD", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'EMPCD', align: 'center' }),

        column.create("품목코드", "ITEMCD", { width: 150, align: 'center' }),
        column.create("품명", "ITEMNM", { width: 180, align: 'center' }),
        column.create("버전", "REV", { width: 80, align: 'center' }),
        column.create("공정", "PRCCD", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'PRCCD', align: 'center' }),
        column.create("재질", "MATERIAL", { width: 100, columnType: enumColumnTypes.combo, gpcd: 'MATERIAL', align: 'center' }),
        column.create("두께", "THICK", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create("길이", "LENGTH", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create("폭", "WIDTH", { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        column.create("사용수량", "OUTQTY", { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create("단위", "ITEMUNIT", { width: 80, columnType: enumColumnTypes.combo, gpcd: 'ITEMUNIT', align: 'center' }),
        column.create("비고", "REMARK", { width: 200, align:'center' }),
        column.split()
    ]);


};


//// 부자재 조회
ItsButton.Event('btn_SEARCH_SUBMAT').onClick = function () {
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');
    SUBMAT_SEARCH();
}

SUBMAT_SEARCH = function () {
    // 상
    var maria = new ItsMaria('TAL0001_R07', 'LIST_SUBMAT');
    var ITEMCD = ItsFind.GetValue('find_ITEMCD');

    maria.AddParam('ITEMCD', ITEMCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    
    ItsGrid.SetStore('grid1', maria.store);

}

// 상단 부자재 선택시
ItsGrid.Event('grid1').onSelect = function () {

    ItsGrid.Clear('grid2');
    ItsGrid.Clear('grid3');

    SUBMAT_LOT_SEARCH();
}


SUBMAT_LOT_SEARCH = function () {
    var maria = new ItsMaria('TAL0001_R07', 'LIST_SUBMAT_LOT');
    var ITEMCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD');

    maria.AddParam('ITEMCD', ITEMCD);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);


}
// 상단 부자재 선택시
ItsGrid.Event('grid2').onSelect = function () {

    ItsGrid.Clear('grid3');

    SUBMAT_OUT_SEARCH();
}


SUBMAT_OUT_SEARCH = function () {
    var maria = new ItsMaria('TAL0001_R07', 'LIST_SUBMAT_OUT');
    var LOTKEY = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'LOTKEY');

    maria.AddParam('LOTKEY', LOTKEY);

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid3', maria.store);


}
//// 부자재 사용등록
ItsButton.Event('btn_USE_SUBMAT').onClick = function () {
    var ITEMCD = ItsGrid.GetValue('grid1', ItsGrid.GetCurrentIndex('grid1'), 'ITEMCD');
    var LOTKEY = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'LOTKEY');
    if (LOTKEY == '' || LOTKEY == null || LOTKEY == undefined) {
        return;
    }

    ItsFind.SetValue('pop_find_ITEMCD', ITEMCD);

    ItsFind.SetValue('pop_txt_LOTKEY', LOTKEY);
    ItsNum.SetValue('pop_num_OUTQTY', 0);
    ItsPop.Open('pop1');
}


ItsPop.Event('pop1').onAddBtnClick = function () {
    var maria = new ItsMaria('TAL0001_R07', 'ADD_SUBMAT_USE');
    maria.AddPanel('pdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    ItsPop.Close('pop1');
    ItsPage.InitData('pdiv1');
    SUBMAT_SEARCH();
}

ItsPop.Event('pop1').onCancelBtnClick = function () {
    ItsPop.Close('pop1');
    ItsPage.InitData('pdiv1');
}



//// 입고삭제 버튼

ItsGrid.Event('grid3').onButtonClick = function (rowIndex, field) {
    if (field == 'DEL') {
        ItsMsg.Confirm("선택항목을 삭제하시겠습니까?",
            function () {
                var maria = new ItsMaria('TAL0001_R07', 'DEL_COMOUTLOT');
                var LOTKEY = ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'LOTKEY');
                maria.AddParam('LOTKEY', LOTKEY);
                maria.AddRecord('grid3', rowIndex);
                maria.CallProc();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }

                ItsGrid.Setkey('grid2', 'LOTKEY', ItsGrid.GetValue('grid2', ItsGrid.GetCurrentIndex('grid2'), 'LOTKEY'));
                SUBMAT_LOT_SEARCH();

            }
        );
    }
}


ItsButton.Event('sdiv2_btn_SEARCH').onClick = function () {
    var maria = new ItsMaria('TAL0001_R07', 'LIST_SUBMAT_HIS');
    maria.AddPanel('sdiv2');
    
    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid4', maria.store);
}



