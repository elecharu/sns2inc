/// <reference path="../../Script/reference.js" />

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    // 군별 Xbar, R 과 검사값 (n=1 ~ n=25)
    var columns = [
        column.create('군', 'GROUPNO', { width: 50, align: 'center' }),
        column.create('X-Bar', 'XBAR', { width: 80, align: 'right' }),
        column.create('R', 'R', { width: 80, align: 'right' })
    ];
    for (var i = 1; i <= 25; i++) {
        columns.push(column.create('n=' + i, 'VALUE' + i, { width: 80, align: 'right' }));
    }
    columns.push(column.split());
    ItsGrid.Create('grid1', { isCheckBoxGrid: false }, columns);

    // 자주검사 SPC 관리항목
    ItsGrid.Create('grid2', { isCheckBoxGrid: false }, [
        column.create('품목ID', 'ITEMID', { width: 80, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 120 }),
        column.create('품명', 'ITEMNM', { width: 150 }),
        column.create('검사항목코드', 'STDCD', { width: 80, hidden: true }),
        column.create('검사항목', 'STDNM', { width: 120 }),
        column.create('세부항목', 'STDPART', { width: 80 }),
        column.create('세부공정', 'PRCDETAIL', { width: 90, columnType: enumColumnTypes.combo, gpcd: 'PRCDETAIL', align: 'center' }),
        column.create('특성', 'FEATURE', { width: 80, align: 'center' }),
        column.create('CPK', 'CPK', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('PPK', 'PPK', { width: 70, columnType: enumColumnTypes.number, decimalPrecision: 2 }),
        column.create('X-Bar UCL', 'XBAR_UCL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
        column.create('X-Bar LCL', 'XBAR_LCL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
        column.create('X-Bar USL', 'XBAR_USL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
        column.create('X-Bar LSL', 'XBAR_LSL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
        column.create('R UCL', 'R_UCL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
        column.create('R USL', 'R_USL', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 3 }),
        column.split()
    ]);

    ItsNum.Hide('num_CPK');
    ItsLabel.Hide('label_RESULT_CPK');
    ItsLabel.Hide('label_CPK');

    ItsNum.Hide('num_PPK');
    ItsLabel.Hide('label_RESULT_PPK');
    ItsLabel.Hide('label_PPK');

    ItsCombo.SetValue('cmb_FACTORYCD', '07');   // 공장 기본값 (onChanged 로 품목 find 법인·공장도 들어감)
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('sdiv1_find_ITEMID', companycd);
    ItsFind.SetRef03('sdiv1_find_ITEMID', value);
};
/***************************************************************************************************************************************************************/
/* 조회 */
ItsButton.EventSearch = function () {
    ItsPage.InitData('ddiv1');
    ItsGrid.Clear('grid1');
    ItsGrid.Clear('grid2');
    $('#chart1').empty();
    $('#chart2').empty();

    var maria = new ItsMaria('TQM4001_S01', 'LIST_STDCD');

    maria.AddPanel('sdiv1');

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    ItsGrid.SetStore('grid2', maria.store);
    ItsGrid.Get('grid2').autoSizeColumns();

    ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
};

// SPC 관리항목 선택 - n 개씩 묶어 Xbar, R 관리도와 공정능력 계산
ItsGrid.Event('grid2').onSelect = function (rowIndex, field) {
    ItsPage.InitData('ddiv1');
    ItsGrid.Clear('grid1');
    $('#chart1').empty();
    $('#chart2').empty();

    var maria = new ItsMaria('TQM4001_S01', 'SEARCH_TQMVALUE_N');

    maria.AddParam('SDATE', ItsDateRange.GetValueFrom('dataRange1'));
    maria.AddParam('EDATE', ItsDateRange.GetValueTo('dataRange1'));
    maria.AddParam('NVALUE', ItsNum.GetValue('num_NVALUE'));

    maria.AddParam('ITEMID', ItsGrid.GetValue('grid2', rowIndex, 'ITEMID'));
    maria.AddParam('STDCD', ItsGrid.GetValue('grid2', rowIndex, 'STDCD'));
    maria.AddParam('STDPART', ItsGrid.GetValue('grid2', rowIndex, 'STDPART'));
    maria.AddParam('PRCDETAIL', ItsGrid.GetValue('grid2', rowIndex, 'PRCDETAIL'));

    maria.CallProc();

    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var spc = maria.store.data[0];          // SPC 계산값
    ItsGrid.SetStore('grid1', maria.storeExtend1);   // 군별 Xbar, R

    ItsNum.SetValue('num_STDMIN', spc['STDMIN']);
    ItsNum.SetValue('num_STDMAX', spc['STDMAX']);
    ItsNum.SetValue('num_BIGN', spc['BIGN']);
    ItsNum.SetValue('num_NVALUE_2', spc['NVALUE']);
    ItsNum.SetValue('num_AVG', spc['AVG']);
    ItsNum.SetValue('num_d2', spc['d2']);
    ItsNum.SetValue('num_STDEV_ALL', spc['STDEV_ALL']);
    ItsNum.SetValue('num_STDEV_GROUP', spc['STDEV_GROUP']);

    ItsNum.SetValue('num_PP', spc['PP']);
    ItsNum.SetValue('num_PPL', spc['PPL']);
    ItsNum.SetValue('num_PPU', spc['PPU']);
    ItsNum.SetValue('num_PPK', spc['PPK']);

    ItsNum.SetValue('num_CP', spc['CP']);
    ItsNum.SetValue('num_CPL', spc['CPL']);
    ItsNum.SetValue('num_CPU', spc['CPU']);
    ItsNum.SetValue('num_CPK', spc['CPK']);

    // 목표 CPK, PPK (SPC 관리항목 등록값) 보다 계산값이 작으면 불만족
    var targetCpk = parseFloat(ItsGrid.GetValue('grid2', rowIndex, 'CPK')) || 0;
    var targetPpk = parseFloat(ItsGrid.GetValue('grid2', rowIndex, 'PPK')) || 0;

    if (targetCpk == 0) {
        ItsNum.Hide('num_CPK');
        ItsLabel.Hide('label_RESULT_CPK');
        ItsLabel.Hide('label_CPK');
    }
    else {
        if (spc['CPK'] == null || spc['CPK'] === '') {   // 군내 표준편차 0 → 계산불가
            ItsLabel.SetText('label_CPK', '계산불가');
            ItsLabel.SetStyle('label_CPK', 'background-color', 'LIGHTGRAY');
        }
        else {
            var okCpk = parseFloat(spc['CPK']) >= targetCpk;
            ItsLabel.SetText('label_CPK', okCpk ? '만족' : '불만족');
            ItsLabel.SetStyle('label_CPK', 'background-color', okCpk ? 'LIGHTGREEN' : 'PINK');
        }
        ItsNum.Show('num_CPK');
        ItsLabel.Show('label_RESULT_CPK');
        ItsLabel.Show('label_CPK');
    }

    if (targetPpk == 0) {
        ItsNum.Hide('num_PPK');
        ItsLabel.Hide('label_RESULT_PPK');
        ItsLabel.Hide('label_PPK');
    }
    else {
        if (spc['PPK'] == null || spc['PPK'] === '') {   // 전체 표준편차 0 → 계산불가
            ItsLabel.SetText('label_PPK', '계산불가');
            ItsLabel.SetStyle('label_PPK', 'background-color', 'LIGHTGRAY');
        }
        else {
            var okPpk = parseFloat(spc['PPK']) >= targetPpk;
            ItsLabel.SetText('label_PPK', okPpk ? '만족' : '불만족');
            ItsLabel.SetStyle('label_PPK', 'background-color', okPpk ? 'LIGHTGREEN' : 'PINK');
        }
        ItsNum.Show('num_PPK');
        ItsLabel.Show('label_RESULT_PPK');
        ItsLabel.Show('label_PPK');
    }

    drawChart(maria.storeExtend1.data, spc);
};
/***************************************************************************************************************************************************************/
/* Xbar 관리도(chart1), R 관리도(chart2) 그리기 - data: 군별 Xbar, R / spc: 중심선·관리한계 */
drawChart = function (data, spc) {
    if (data.length == 0) return;

    var categories = [];
    var chart1Data = [['X bar 관리도'], ['X bar UCL'], ['X bar LCL'], ['X bar CL'], ['X bar USL'], ['X bar LSL']];
    var chart2Data = [['R 관리도'], ['R UCL'], ['R CL'], ['R USL']];

    for (var i = 0; i < data.length; i++) {
        categories.push(i + 1);
        chart1Data[0].push(parseFloat(data[i]['XBAR']).toFixed(3));
        chart1Data[1].push(parseFloat(spc['XBARUCL']).toFixed(3));
        chart1Data[2].push(parseFloat(spc['XBARLCL']).toFixed(3));
        chart1Data[3].push(parseFloat(spc['XBARCL']).toFixed(3));
        chart1Data[4].push(parseFloat(spc['XBARUSL']).toFixed(3));
        chart1Data[5].push(parseFloat(spc['XBARLSL']).toFixed(3));

        chart2Data[0].push(parseFloat(data[i]['R']).toFixed(3));
        chart2Data[1].push(parseFloat(spc['RUCL']).toFixed(3));
        chart2Data[2].push(parseFloat(spc['RCL']).toFixed(3));
        chart2Data[3].push(parseFloat(spc['RUSL']).toFixed(3));
    }

    bb.generate({
        bindto: '#chart1',
        data: {
            columns: chart1Data,
            type: 'line',
            colors: {
                'X bar 관리도': 'red',
                'X bar UCL': '#FF00DD',
                'X bar LCL': '#FF00DD',
                'X bar CL': 'blue',
                'X bar USL': 'red',
                'X bar LSL': 'red'
            }
        },
        axis: { x: { type: 'category', categories: categories } },
        tooltip: { show: true },
        grid: { x: { show: true }, y: { show: true } },
        line: { point: ['X bar 관리도'] },
        padding: { top: 20, bottom: 20 },
        size: { height: 235 },
        legend: { position: 'right' }
    });

    bb.generate({
        bindto: '#chart2',
        data: {
            columns: chart2Data,
            type: 'line',
            colors: {
                'R 관리도': 'red',
                'R UCL': '#FF00DD',
                'R CL': 'blue',
                'R USL': 'red'
            }
        },
        axis: { x: { type: 'category', categories: categories } },
        tooltip: { show: true },
        grid: { x: { show: true }, y: { show: true } },
        line: { point: ['R 관리도'] },
        padding: { top: 20, bottom: 20 },
        size: { height: 235 },
        legend: { position: 'right' }
    });
};
