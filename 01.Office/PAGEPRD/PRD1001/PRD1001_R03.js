

/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', { isCheckBoxGrid: false, isSubTotalGrid: false, groupField: 'RITEMNM', allowMerging: true  }, [
        column.create('제품', 'RITEMNM', { width: 100, align: 'center', hidden: true }),
        column.create('품목ID', 'ITEMID', { width: 100, align: 'center', allowMerging: true }),
        column.create('품목코드', 'ITEMCD', { width: 150, allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 300, allowMerging: true }),    
        column.create('투입공정', 'PRCNM', { width: 100, align: 'center', allowMerging: true }),    
        column.create('구분', 'QTYTP', { width: 80, align: 'center' }),    

        column.band('1일', {}, [
            column.create('수량', 'QTY_1', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('2일', {}, [
            column.create('수량', 'QTY_2', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('3일', {}, [
            column.create('수량', 'QTY_3', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('4일', {}, [
            column.create('수량', 'QTY_4', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('5일', {}, [
            column.create('수량', 'QTY_5', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('6일', {}, [
            column.create('수량', 'QTY_6', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('7일', {}, [
            column.create('수량', 'QTY_7', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('8일', {}, [
            column.create('수량', 'QTY_8', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('9일', {}, [
            column.create('수량', 'QTY_9', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('10일', {}, [
            column.create('수량', 'QTY_10', { width: 60, align: 'center', readOnly: false }),
        ]),

        column.band('11일', {}, [
            column.create('수량', 'QTY_11', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('12일', {}, [
            column.create('수량', 'QTY_12', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('13일', {}, [
            column.create('수량', 'QTY_13', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('14일', {}, [
            column.create('수량', 'QTY_14', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('15일', {}, [
            column.create('수량', 'QTY_15', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('16일', {}, [
            column.create('수량', 'QTY_16', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('17일', {}, [
            column.create('수량', 'QTY_17', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('18일', {}, [
            column.create('수량', 'QTY_18', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('19일', {}, [
            column.create('수량', 'QTY_19', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('20일', {}, [
            column.create('수량', 'QTY_20', { width: 60, align: 'center', readOnly: false }),
        ]),

        column.band('21일', {}, [
            column.create('수량', 'QTY_21', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('22일', {}, [
            column.create('수량', 'QTY_22', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('23일', {}, [
            column.create('수량', 'QTY_23', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('24일', {}, [
            column.create('수량', 'QTY_24', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('25일', {}, [
            column.create('수량', 'QTY_25', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('26일', {}, [
            column.create('수량', 'QTY_26', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('27일', {}, [
            column.create('수량', 'QTY_27', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('28일', {}, [
            column.create('수량', 'QTY_28', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('29일', {}, [
            column.create('수량', 'QTY_29', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('30일', {}, [
            column.create('수량', 'QTY_30', { width: 60, align: 'center', readOnly: false }),
        ]),
        column.band('31일', {}, [
            column.create('수량', 'QTY_31', { width: 60, align: 'center', readOnly: false }),
        ]),

        column.split()
    ]);

    // 구분이 '소재입고'(제품은 '제품생산')인 행만 입력 가능 (편집, 붙여넣기, Delete 모두 막기 위해 행 단위로 readOnly 지정)
    // ) 그룹그리드는 조회/정렬 시 행이 다시 만들어지므로 loadedRows 때마다 지정
    ItsGrid.Get('grid1').loadedRows.addHandler(function (s) {
        s.rows.forEach(function (row) {
            if (row instanceof wijmo.grid.GroupRow) return;
            row.isReadOnly = (row.dataItem == undefined || QTYTP_IN.indexOf(row.dataItem.QTYTP) == -1);
        });
    });

    // 배경색: 입력 가능한 셀(행, 컬럼 모두 readOnly = false)만 흰색, 나머지는 readOnly 컬럼과 같은 색
    ItsGrid.Get('grid1').formatItem.addHandler(function (s, e) {
        if (e.panel.cellType != wijmo.grid.CellType.Cell) return;

        var row = s.rows[e.row];
        var col = s.columns[e.col];
        if (row instanceof wijmo.grid.GroupRow) return;

        e.cell.style.backgroundColor = (row.isReadOnly || col.isReadOnly) ? '#F7F7F7' : 'white';

        // 소재잔량(제품잔량)이 음수이면 글씨 빨간색
        // ) 셀이 재사용되므로 일자 컬럼은 매번 색상을 다시 지정
        if (col.binding.indexOf('QTY_') == 0) {
            var isMinus = row.dataItem != undefined
                && QTYTP_REMAIN.indexOf(row.dataItem.QTYTP) > -1
                && parseFloat((row.dataItem[col.binding] || '').toString().replace(/,/g, '')) < 0;
            e.cell.style.color = isMinus ? 'red' : '';
        }
    });

    // 소재입고(제품생산) 입력 시 같은 제품묶음(RITEMID)의 같은 품목ID 소재잔량(제품잔량)만 재계산
    // ) 공통 onChanged는 그룹그리드 붙여넣기 시 현재 선택행 index가 넘어오므로 wijmo 이벤트에서 수정된 행을 직접 사용
    var recalcByEditedCell = function (s, e) {
        var row = s.rows[e.row];
        var field = s.columns[e.col].binding;
        if (row == undefined || row.dataItem == undefined || QTYTP_IN.indexOf(row.dataItem.QTYTP) == -1 || field.indexOf('QTY_') != 0) return;

        CALC_REMAINQTY(ItsGrid.GetStore('grid1'), row.dataItem.RITEMID, row.dataItem.ITEMID);
        s.refresh();
    };
    ItsGrid.Get('grid1').cellEditEnded.addHandler(recalcByEditedCell);
    ItsGrid.Get('grid1').pastedCell.addHandler(recalcByEditedCell);
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

    // 소재입고 입력 후 재계산도 조회 당시 기간으로 하도록 저장
    SEARCH_DAY.S = new Date(ItsDate.GetValue('date_SDATE')).getDate();
    SEARCH_DAY.E = new Date(ItsDate.GetValue('date_EDATE')).getDate();

    CALC_REMAINQTY(maria.store.data);

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

        // 조회시작일 컬럼은 입력 불가 (첫날 소재잔량은 현재고라 계산에 쓰이지 않음)
        ItsGrid.SetReadOnly('grid1', 'QTY_' + (i + 1), day.toLocaleDateString('en-CA') == SDATE.toLocaleDateString('en-CA'));
    }

    ItsGrid.Get('grid1').refresh();
}

/**********************************************************************************************************************************************************/
// 소재잔량(제품잔량) 계산
// 당일 소재잔량 = 전날 소재잔량 + 당일 소재입고 - 당일 생산계획
// 당일 제품잔량 = 전날 제품잔량 + 당일 제품생산 - 당일 출하계획
// ) 조회 시작일은 계산하지 않고 프로시저가 넣어준 현재고를 그대로 표시
// ) rItemId, itemId 지정 시 해당 제품묶음의 해당 품목ID 소재잔량만 계산
var SEARCH_DAY = { S: 1, E: 31 };

// 구분(QTYTP) 값 : 소재 / 제품(품목유형 DM100100)
var QTYTP_IN = ['소재입고', '제품생산'];
var QTYTP_PLAN = ['생산계획', '출하계획'];
var QTYTP_REMAIN = ['소재잔량', '제품잔량'];

CALC_REMAINQTY = function (data, rItemId, itemId) {
    var sDay = SEARCH_DAY.S;
    var eDay = SEARCH_DAY.E;

    var toNum = function (v) {
        var n = parseFloat((v == undefined ? '' : v).toString().replace(/,/g, ''));
        return isNaN(n) ? 0 : n;
    };

    // 품목(전개경로)별로 소재입고 / 생산계획 / 소재잔량 행 묶기
    var groups = {};
    data.forEach(function (row) {
        if (itemId != undefined && (row.RITEMID != rItemId || row.ITEMID != itemId)) return;

        var key = [row.RITEMID, row.IDX, row.MITEMID, row.ITEMID].join('|');
        if (groups[key] == undefined) groups[key] = { IN: null, PLAN: null, REMAIN: [] };

        if (QTYTP_IN.indexOf(row.QTYTP) > -1) groups[key].IN = row;
        else if (QTYTP_PLAN.indexOf(row.QTYTP) > -1) groups[key].PLAN = row;
        else if (QTYTP_REMAIN.indexOf(row.QTYTP) > -1) groups[key].REMAIN.push(row);
    });

    Object.keys(groups).forEach(function (key) {
        var g = groups[key];

        g.REMAIN.forEach(function (remainRow) {
            var qty = toNum(remainRow['QTY_' + sDay]); // 현재고

            for (var d = 1; d <= 31; d++) {
                if (d < sDay || d > eDay) {
                    remainRow['QTY_' + d] = '';
                    continue;
                }
                if (d == sDay) continue; // 첫날은 현재고 그대로

                var inQty = g.IN ? toNum(g.IN['QTY_' + d]) : 0;
                var planQty = g.PLAN ? toNum(g.PLAN['QTY_' + d]) : 0;

                qty = qty + inQty - planQty;
                remainRow['QTY_' + d] = Math.round(qty).toLocaleString('en-US');
            }
        });
    });
}

/**********************************************************************************************************************************************************/