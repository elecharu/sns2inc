/// <reference path="../../Script/reference.js" />
/* 페이지 로드 시 수행 */
ItsPage.Load = function () {

    /* 그리드 생성 */
    ItsGrid.Create('grid1', { isSubTotalGrid: true, lockColumn: 4, allowMerging: 'Cells' }, [
        column.create("품목유형", "ITEMTP", { width: 70, align: 'center', columnType: enumColumnTypes.combo, gpcd: 'ITEMTP', allowMerging: true }),

        column.create("품목코드", "ITEMCD", { width: 100, align: 'center' }),

        column.create("계", "SUMQTY_ITEMCD", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum, backColor: enumColor.yellowLight2 }),

        column.create("1일", "SUMQTY_D1", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("2일", "SUMQTY_D2", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("3일", "SUMQTY_D3", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("4일", "SUMQTY_D4", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("5일", "SUMQTY_D5", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("6일", "SUMQTY_D6", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("7일", "SUMQTY_D7", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("8일", "SUMQTY_D8", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("9일", "SUMQTY_D9", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("10일", "SUMQTY_D10", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),

        column.create("11일", "SUMQTY_D11", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("12일", "SUMQTY_D12", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("13일", "SUMQTY_D13", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("14일", "SUMQTY_D14", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("15일", "SUMQTY_D15", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("16일", "SUMQTY_D16", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("17일", "SUMQTY_D17", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("18일", "SUMQTY_D18", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("19일", "SUMQTY_D19", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("20일", "SUMQTY_D20", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),

        column.create("21일", "SUMQTY_D21", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("22일", "SUMQTY_D22", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("23일", "SUMQTY_D23", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("24일", "SUMQTY_D24", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("25일", "SUMQTY_D25", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("26일", "SUMQTY_D26", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("27일", "SUMQTY_D27", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("28일", "SUMQTY_D28", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("29일", "SUMQTY_D29", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),
        column.create("30일", "SUMQTY_D30", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),

        column.create("31일", "SUMQTY_D31", { width: 100, columnType: enumColumnTypes.number, groupType: enumGrouping.sum }),

        column.split()
    ]);
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD0001_S02 ', 'LIST_PRDRST_ITEMSHAPE');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }


    var DAYS_THISMONTH = maria.store.data[0]["DAYS_THISMONTH"]; //조회월의 일수

    ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D29')].visible = false;
    ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D30')].visible = false;
    ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D31')].visible = false;

    if (DAYS_THISMONTH == 29) {
        ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D29')].visible = true;
    }
    else if (DAYS_THISMONTH == 30) {
        ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D29')].visible = true;
        ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D30')].visible = true;
    }
    else {
        ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D29')].visible = true;
        ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D30')].visible = true;
        ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'SUMQTY_D31')].visible = true;
    }

    ItsGrid.SetStore('grid1', maria.storeExtend1);

    ItsGrid.Get('grid1').autoSizeColumns();

    ItsMsg.Toast(maria.store.Length() + '건이 조회되었습니다.');
};
