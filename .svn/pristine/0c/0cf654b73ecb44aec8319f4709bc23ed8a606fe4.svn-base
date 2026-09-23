/// <reference path="../../Script/reference.js" />
var searchStore;

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', {  allowMerging: 'Cells'}, [
        column.create('품목코드', 'ITEMCD', { width: 120, allowMerging: true }),
        column.create('품명', 'ITEMNM', { width: 200, allowMerging: true }),
        column.create('구분', 'ITEM', { width: 100, align: 'center' }),
        column.create('1월', 'M01', { width: 80, columnType: enumColumnTypes.number }),
        column.create('2월', 'M02', { width: 80, columnType: enumColumnTypes.number }),
        column.create('3월', 'M03', { width: 80, columnType: enumColumnTypes.number }),
        column.create('4월', 'M04', { width: 80, columnType: enumColumnTypes.number }),
        column.create('5월', 'M05', { width: 80, columnType: enumColumnTypes.number }),
        column.create('6월', 'M06', { width: 80, columnType: enumColumnTypes.number }),
        column.create('7월', 'M07', { width: 80, columnType: enumColumnTypes.number }),
        column.create('8월', 'M08', { width: 80, columnType: enumColumnTypes.number }),
        column.create('9월', 'M09', { width: 80, columnType: enumColumnTypes.number }),
        column.create('10월', 'M10', { width: 80, columnType: enumColumnTypes.number }),
        column.create('11월', 'M11', { width: 80, columnType: enumColumnTypes.number }),
        column.create('12월', 'M12', { width: 80, columnType: enumColumnTypes.number }),
        column.create('합계', 'MSUM', { width: 80, columnType: enumColumnTypes.number }),
        column.split()
    ]);

    ItsCombo.SetValue('cmb_SYEAR', ItsHelper.GetYearMonthDay().substring(0, 4));

    var searchStore = new Store();
    _drawChart(ItsCheck.GetValue('chk_LABELCHK'));
};

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('PRD0001_S03', 'LIST_PRDINSRST');
    maria.AddPanel('sdiv1');
    var a = ItsCheck.GetValue('STAMP');
    console.log(a);
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    searchStore = maria.store;
    ItsGrid.SetStore('grid1', searchStore);
    _drawChart(ItsCheck.GetValue('chk_LABELCHK'));
};

/* 차트 라벨 옵션 */
ItsCheck.Event('chk_LABELCHK').onChanged = function (newValue, oldValue) {
    if (newValue == 'N' || newValue == false) {
        newValue = false;
    }
    else if (newValue == 'Y' || newValue == true) {
        newValue = true;
    }

    _drawChart(newValue);
}

_drawChart = function (islabel) {

    /* 차트 생성 */
    var chart1Data = [];
    if (searchStore != undefined) {
        searchStore.data.forEach(function (d) {
            if (d["ITEMCD"] == '합계') {
                chart1Data.push([
                    d["ITEM"], d["M01"], d["M02"], d["M03"], d["M04"],
                    d["M05"], d["M06"], d["M07"], d["M08"],
                    d["M09"], d["M10"], d["M11"], d["M12"]
                ]);
            }
        })
    }
    var chart1 = bb.generate({
        bindto: "#chart1",
        size: { width: "1200", height: "300" },
        data: {
            columns: chart1Data,
            types: {    /* 그래프 타입 */
                "지시수량": "bar",
                "생산수량": "bar",
                "달성률(%)": "line",
            },
            axes: {     /* 그래프 사용 Y축 */
                "지시수량": "y",
                "생산수량": "y",
                "달성률(%)": "y2",
            },
            labels: islabel
        },
        axis: {
            x: {
                type: "category",       /* 카테고리 축의 카테고리명 */
                categories: ["1월", "2월", "3월",
                    "4월", "5월", "6월",
                    "7월", "8월", "9월",
                    "10월", "11월", "12월"
                ]
            },
            y2: {       /* Y2축 눈금값 세팅 */
                show: true,
                min: 0,
                tick: {
                    values: [0, 50, 100]
                }
            }
        },
        tooltip: {      /* 그래프 툴팁 */
            show: true
        },
        bar: {          /* 바 사이 간격 */
            padding: 3
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
        },
        legend: {
            position: "right"
        }
    });

    var chart2Data = [];
    if (searchStore != undefined) {
        chart2Data.push(["x", "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월"]);
        searchStore.data.forEach(function (d) {
            if (d["ITEMCD"] == '합계' && d["ITEM"] == "달성률(%)") {
                chart2Data.push([
                    "달성률(%)", d["M01"], d["M02"], d["M03"], d["M04"],
                    d["M05"], d["M06"], d["M07"], d["M08"],
                    d["M09"], d["M10"], d["M11"], d["M12"]
                ]);
            }
        })

        var chart2 = bb.generate({
            size: { width: "300", height: "300" },
            data: {
                x: "x",
                columns: chart2Data,
                type: "radar",
                labels: islabel
            },
            radar: {
                axis: {
                    max: 110,
                    tick: {
                        values: [0, 50, 100]
                    }
                },
                level: {
                    depth: 11,
                    text: {
                        format: function (x) {
                            if (x == "50" || x == "100")
                                return x;
                            else
                                return "";
                        },
                        show: true
                    },
                },
                direction: {
                    clockwise: true
                }
            },
            bindto: "#chart2"
        });
    }
};