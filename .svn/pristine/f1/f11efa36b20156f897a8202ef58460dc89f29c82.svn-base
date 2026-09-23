/* TQC6001_S05: 품질관리 - 지표관리 - 불량추이 유형분석 */

/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 최초 실행 */
ItsPage.Load = function () {

    ItsGrid.Create('grid1', {}, [
        column.create('구분', 'TITLE', { width: 100 }),
        column.create('TOP1', 'TOP1', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP2', 'TOP2', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP3', 'TOP3', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP4', 'TOP4', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP5', 'TOP5', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP6', 'TOP6', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP7', 'TOP7', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP8', 'TOP8', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP9', 'TOP9', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('TOP10', 'TOP10', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 2 }),

        column.split()
    ]);
    ItsCombo.SetValue('cmb_PCT_TYPE', 'PERCE');
};

var searchStore;
var categories = [];
var $store;

/* 조회 */
ItsButton.EventSearch = function () {
    var maria = new ItsMaria('TQM0001_S02', 'LIST_RST');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }
    $store = new Store();

    categories = [];

    $store.data.push({ TITLE: '생산수량', TOP1: '', TOP2: '', TOP3: '', TOP4: '', TOP5: '', TOP6: '', TOP7: '', TOP8: '', TOP9: '', TOP10: '' });
    $store.data.push({ TITLE: '불량수량', TOP1: '', TOP2: '', TOP3: '', TOP4: '', TOP5: '', TOP6: '', TOP7: '', TOP8: '', TOP9: '', TOP10: '' });

    if (ItsCombo.GetValue('cmb_PCT_TYPE') == "PPM")
        $store.data.push({ TITLE: '불량률(PPM)', TOP1: '', TOP2: '', TOP3: '', TOP4: '', TOP5: '', TOP6: '', TOP7: '', TOP8: '', TOP9: '', TOP10: ''  });
    else if (ItsCombo.GetValue('cmb_PCT_TYPE') == "PERCE")
        $store.data.push({ TITLE: '불량률(%)', TOP1: '', TOP2: '', TOP3: '', TOP4: '', TOP5: '', TOP6: '', TOP7: '', TOP8: '', TOP9: '', TOP10: ''  });

    searchStore = new Array(maria.store.data.length);
    for (var i = 1; i <= maria.store.data.length; i++) {
        categories.push(maria.store.data[i - 1]["BADNM"]);

        ItsGrid.SetColumnName('grid1', i + 1, maria.store.data[i - 1]["BADNM"]);
        $store.data[0]["TOP" + i] = maria.store.data[i - 1]["SUMPRDQTY"];
        $store.data[1]["TOP" + i] = maria.store.data[i - 1]["BADQTY"];
        //$store.data[2]["TOP" + i] = maria.store.data[i - 1]["BADPRICE"];
        if (ItsCombo.GetValue('cmb_PCT_TYPE') == "PPM")
            $store.data[2]["TOP" + i] = maria.store.data[i - 1]["PRDBADPERCENT"];
        else
            $store.data[2]["TOP" + i] = Math.round(maria.store.data[i - 1]["PRDBADPERCENT"] / 10000 * 100) / 100;

        searchStore[i - 1] = new Array(2);
        searchStore[i - 1][0] = maria.store.data[i - 1]["BADNM"];
        searchStore[i - 1][1] = maria.store.data[i - 1]["BADQTY"];
    }

    ItsGrid.SetStore('grid1', $store);
    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));

    ItsCheck.Event('chk_LABELCHK').onChanged(ItsCheck.GetValue('chk_LABELCHK'), '');
};

ItsGrid.Event('grid1').onChanged = function (rowIndex, field) {
    searchStore = new Array(10);
    for (var i = 0; i < 10; i++) {
        searchStore[i] = new Array(2);
        searchStore[i][0] = ItsGrid.Get('grid1').columns[i + 2]._hdr;
        searchStore[i][1] = ItsGrid.GetValue('grid1', 1, 'TOP' + (i + 1));
    }

    ItsCheck.Event('chk_LABELCHK').onChanged(ItsCheck.GetValue('chk_LABELCHK'), '');

}

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

_drawChart = function (isLabel) {

    /* 차트 생성 */
    var chart1Data = [];
    var d = $store.data;
    for (var i = 0; i < d.length; i++) {
        if (d[i]["TITLE"] == "불량수량" || d[i]["TITLE"] == "불량률(PPM)" || d[i]["TITLE"] == "불량률(%)")
            chart1Data.push([
                d[i]["TITLE"], d[i]["TOP1"], d[i]["TOP2"], d[i]["TOP3"], d[i]["TOP4"], d[i]["TOP5"], d[i]["TOP6"], d[i]["TOP7"], d[i]["TOP8"], d[i]["TOP9"], d[i]["TOP10"]
            ]);
    }


    var goaldata = ItsNum.GetValue('num_GOAL');
    chart1Data.push([
        "목표치", goaldata, goaldata, goaldata, goaldata, goaldata, goaldata, goaldata, goaldata, goaldata, goaldata
    ]);


    var chart1 = bb.generate({
        bindto: "#chart1",
        data: {
            columns: chart1Data,
            types: {    /* 그래프 타입 */
                "불량수량": "bar",
                "불량률(PPM)": "line",
                "불량률(%)": "line",
            },
            axes: {     /* 그래프 사용 Y축 */
                "불량수량(EA)": "y",
                "불량률(PPM)": "y2",
                "불량률(%)": "y2"
            },
            labels: isLabel,
            colors: {   /* 그래프 색상 */
                "불량수량": "royalblue",
            },
        },
        axis: {
            x: {
                type: "category",       /* 카테고리 축의 카테고리명 */
                categories: categories
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


    var chart2 = bb.generate({
        data: {
            columns: searchStore,
            type: "donut",

        },
        donut: {
            title: "불량별 수량"
        },
        bindto: "#chart2"
    });
};


//ItsButton.EventPrint = function () {

//    var rpt = new ItsXtraRpt('TQC6001_S05');
//    rpt.AddPanel('sdiv1');
//    rpt.CallPop();
//    if (rpt.isError) {
//        ItsMsg.Alert(rpt.errMessage);
//        return;
//    }

//};