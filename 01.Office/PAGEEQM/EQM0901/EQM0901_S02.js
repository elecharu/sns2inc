/* TQM0901_S02: 품질관리 ▶ 지표관리 ▷ 월별 불량현황 조회 */

/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', {}, [
        column.create('구분', 'ITEM', { width: 120 }),
        column.create('합계', 'MSUM', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('1일', 'D01', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('2일', 'D02', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('3일', 'D03', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('4일', 'D04', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('5일', 'D05', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('6일', 'D06', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('7일', 'D07', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('8일', 'D08', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('9일', 'D09', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('10일', 'D10', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('11일', 'D11', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('12일', 'D12', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('13일', 'D13', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('14일', 'D14', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('15일', 'D15', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('16일', 'D16', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('17일', 'D17', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('18일', 'D18', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('19일', 'D19', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('20일', 'D20', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('21일', 'D21', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('22일', 'D22', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('23일', 'D23', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('24일', 'D24', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('25일', 'D25', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('26일', 'D26', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('27일', 'D27', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('28일', 'D28', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('29일', 'D29', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('30일', 'D30', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.create('31일', 'D31', { width: 50, columnType: enumColumnTypes.number, decimalPrecision: 0 }),
        column.split()
    ]);

    ItsMonth.SetValue('month_SMONTH', ItsHelper.GetYearMonth());
    ItsCombo.SetValueByIndex('cmb_PRCCD', 0);                                      
    ItsCheck.SetValue('chk_LABELCHK', 'N');

    /* 차트 정의 */
    var chart1 = bb.generate({
        bindto: "#chart1",
        data: {
            columns: [["생산수량(EA)"], ["생산률(Yield)"]]
        }
    });
    
    ItsButton.EventSearch();
};

var searchStore;

/* 조회 */
ItsButton.EventSearch = function () {
    searchStore = undefined;
    var maria = new ItsMaria('TQM0901_S02', 'LIST_RST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    /* 불량률 계산 */
    var collist = Object.keys(maria.store.data[0]);
    var rowCnt = maria.store.data.length;
    collist.forEach(function (c) {
        if (c != 'ITEM') {
            if (isNaN(Math.round(maria.store.data[rowCnt - 2][c] / maria.store.data[rowCnt - 3][c] * 1000000, 0))) {
                maria.store.data[rowCnt - 1][c] = 0;
            }
            else {
                maria.store.data[rowCnt - 1][c] = Math.round(maria.store.data[rowCnt - 2][c] / maria.store.data[rowCnt - 3][c] * 1000000, 0);
            }
        }
    })
    searchStore = maria.store;
    ItsGrid.SetStore('grid1', searchStore);

    ItsCheck.Event('chk_LABELCHK').onChanged(ItsCheck.GetValue('chk_LABELCHK'), '')
};

/* 차트 라벨 옵션 */
ItsCheck.Event('chk_LABELCHK').onChanged = function (newValue, oldValue) {
    if (newValue == 'N' || newValue == false) {
        newValue = false;
    }
    else if (newValue == 'Y' || newValue == true) {
        newValue = true;
    }

    /* 차트 생성 */
    var chart1Data = [];
    searchStore.data.forEach(function (d) {
        if (d["ITEM"] == '생산수량(EA)' || d["ITEM"] == '생산률(Yield)') {
            chart1Data.push([
                d["ITEM"], d["D01"], d["D02"], d["D03"], d["D04"],
                d["D05"], d["D06"], d["D07"], d["D08"], d["D09"],
                d["D10"], d["D11"], d["D12"], d["D13"], d["D14"],
                d["D15"], d["D16"], d["D17"], d["D18"], d["D19"],
                d["D20"], d["D21"], d["D22"], d["D23"], d["D24"],
                d["D25"], d["D26"], d["D27"], d["D28"], d["D29"],
                d["D30"], d["D31"]
            ]);
        }
    })
    var chart1 = bb.generate({
        bindto: "#chart1",
        data: {
            columns: chart1Data,
            types: {    /* 그래프 타입 */
                "생산률(Yield)": "line"
            },
            axes: {     /* 그래프 사용 Y축 */
                "생산률(Yield)": "y"
            },
            colors: {   /* 그래프 색상 */
                "생산률(Yield)": "red",
            },
            labels: newValue
        },
        axis: {
            x: {
                type: "category",       /* 카테고리 축의 카테고리명 */
                categories: [
                    "1일", "2일", "3일", "4일", "5일",
                    "6일", "7일", "8일", "9일", "10일",
                    "11일", "12일", "13일", "14일", "15일",
                    "16일", "17일", "18일", "19일", "20일",
                    "21일", "22일", "23일", "24일", "25일",
                    "26일", "27일", "28일", "29일", "30일",
                    "31일"
                ]
            },
            y: {
                min: 0
            },
            y2: {
                show: true
            }
        },
        legend: {       /* 범례 */
            position: "right"
        },
        tooltip: {      /* 그래프 툴팁 */
            show: true
        },
        grid: {         /* 차트 그리드 표시 */
            x: { show: true },
            y: { show: true }
        },
        point: {        /* 데이터 점 표시 */
            show: false
        },
        padding: {
            top: 20,
            bottom: 20
        }
    });
};