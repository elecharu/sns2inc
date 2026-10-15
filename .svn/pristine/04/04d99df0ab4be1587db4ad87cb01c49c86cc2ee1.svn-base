

/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false, groupField: 'RITEMNM', allowMerging: true  }, [
        column.create('제품', 'RITEMNM', { width: 100, align: 'center', hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 100, align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 150, allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 300, allowMerging: true }),    
        column.create('투입공정', 'PRCNM', { width: 100, align: 'center', allowMerging: true }),    
        column.create('구분', 'QTYTP', { width: 80 }),    

        column.band('1일', {}, [
            column.create('수량', 'QTY_1', { width: 60, align: 'center' }),
        ]),
        column.band('2일', {}, [
            column.create('수량', 'QTY_2', { width: 60, align: 'center' }),
        ]),
        column.band('3일', {}, [
            column.create('수량', 'QTY_3', { width: 60, align: 'center' }),
        ]),
        column.band('4일', {}, [
            column.create('수량', 'QTY_4', { width: 60, align: 'center' }),
        ]),
        column.band('5일', {}, [
            column.create('수량', 'QTY_5', { width: 60, align: 'center' }),
        ]),
        column.band('6일', {}, [
            column.create('수량', 'QTY_6', { width: 60, align: 'center' }),
        ]),
        column.band('7일', {}, [
            column.create('수량', 'QTY_7', { width: 60, align: 'center' }),
        ]),
        column.band('8일', {}, [
            column.create('수량', 'QTY_8', { width: 60, align: 'center' }),
        ]),
        column.band('9일', {}, [
            column.create('수량', 'QTY_9', { width: 60, align: 'center' }),
        ]),
        column.band('10일', {}, [
            column.create('수량', 'QTY_10', { width: 60, align: 'center' }),
        ]),

        column.band('11일', {}, [
            column.create('수량', 'QTY_11', { width: 60, align: 'center' }),
        ]),
        column.band('12일', {}, [
            column.create('수량', 'QTY_12', { width: 60, align: 'center' }),
        ]),
        column.band('13일', {}, [
            column.create('수량', 'QTY_13', { width: 60, align: 'center' }),
        ]),
        column.band('14일', {}, [
            column.create('수량', 'QTY_14', { width: 60, align: 'center' }),
        ]),
        column.band('15일', {}, [
            column.create('수량', 'QTY_15', { width: 60, align: 'center' }),
        ]),
        column.band('16일', {}, [
            column.create('수량', 'QTY_16', { width: 60, align: 'center' }),
        ]),
        column.band('17일', {}, [
            column.create('수량', 'QTY_17', { width: 60, align: 'center' }),
        ]),
        column.band('18일', {}, [
            column.create('수량', 'QTY_18', { width: 60, align: 'center' }),
        ]),
        column.band('19일', {}, [
            column.create('수량', 'QTY_19', { width: 60, align: 'center' }),
        ]),
        column.band('20일', {}, [
            column.create('수량', 'QTY_20', { width: 60, align: 'center' }),
        ]),

        column.band('21일', {}, [
            column.create('수량', 'QTY_21', { width: 60, align: 'center' }),
        ]),
        column.band('22일', {}, [
            column.create('수량', 'QTY_22', { width: 60, align: 'center' }),
        ]),
        column.band('23일', {}, [
            column.create('수량', 'QTY_23', { width: 60, align: 'center' }),
        ]),
        column.band('24일', {}, [
            column.create('수량', 'QTY_24', { width: 60, align: 'center' }),
        ]),
        column.band('25일', {}, [
            column.create('수량', 'QTY_25', { width: 60, align: 'center' }),
        ]),
        column.band('26일', {}, [
            column.create('수량', 'QTY_26', { width: 60, align: 'center' }),
        ]),
        column.band('27일', {}, [
            column.create('수량', 'QTY_27', { width: 60, align: 'center' }),
        ]),
        column.band('28일', {}, [
            column.create('수량', 'QTY_28', { width: 60, align: 'center' }),
        ]),
        column.band('29일', {}, [
            column.create('수량', 'QTY_29', { width: 60, align: 'center' }),
        ]),
        column.band('30일', {}, [
            column.create('수량', 'QTY_30', { width: 60, align: 'center' }),
        ]),
        column.band('31일', {}, [
            column.create('수량', 'QTY_31', { width: 60, align: 'center' }),
        ]),

        column.split()
    ]);

    ItsDate.SetValue('date_SDATE', '2026-09-01');
};
/**********************************************************************************************************************************************************/
/* 조회 */
ItsButton.EventSearch = function () {
    ItsGrid.Clear('grid1');

    var maria = new ItsMaria('PRD1001_R03', 'LIST_MTRPLAN');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid1', maria.store);
    //ItsGrid.Get('grid1').autoSizeColumns();    

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));

    SET_BANDNAME();
};

/**********************************************************************************************************************************************************/
// 일자컬럼 설정
// 1. 밴드 명칭 설정
// 2. 컬럼 visible, readonly 설정
SET_BANDNAME = function () {
    var week = new Array("일", "월", "화", "수", "목", "금", "토");
    var SDATE = new Date(ItsDate.GetValue('date_SDATE'));
    var EDATE = new Date(ItsDate.GetValue('date_EDATE'));
    var firstDay = new Date(SDATE.getFullYear(), SDATE.getMonth(), 1);
    var lastDay = new Date(SDATE.getFullYear(), SDATE.getMonth() + 1, 0);


    for (var i = 0; i < 31; i++) {
        var day = new Date(firstDay);
        day.setDate(day.getDate() + i);
        var daystring = new Date(day).format('MM/dd');

        // 밴드 명칭 변경
        ItsGrid.Get('grid1').columnHeaders.setCellData(0, ItsGrid.$colIndex('grid1', 'QTY_' + (i + 1)), daystring);

        var isBetween = (day.toLocaleDateString('en-CA') >= SDATE.toLocaleDateString('en-CA') && day.toLocaleDateString('en-CA') <= EDATE.toLocaleDateString('en-CA'));

        // 일자컬럼 visible 설정
        //) : 조회일자 밖이면 visible = false
        if (isBetween) {
            ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'QTY_' + (i + 1))].visible = true;            
        }
        else {
            ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'QTY_' + (i + 1))].visible = false;
        }

        ItsGrid.Get('grid1').columns[ItsGrid.$colIndex('grid1', 'QTY_' + (i + 1))].header = week[day.getDay()];
    }

    ItsGrid.Get('grid1').refresh();
}

/**********************************************************************************************************************************************************/