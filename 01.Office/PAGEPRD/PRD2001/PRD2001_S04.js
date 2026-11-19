/* PRD2001_S04: 생산관리 ▶ 생산계획대비 생산실적조회 */
/* 월간탭 = 월간 생산계획(PRD1001_R01) 대비 실적, 주간탭 = 주간 생산계획(PRD1001_R02) 대비 일자·주야별 실적. 판매계획·생산CAPA 는 뺐다 */

/// <reference path="../../Script/reference.js" />

/* 페이지 접근 시 수행 */
ItsPage.Load = function () {

    // 월간: 월간 생산계획등록(PRD1001_R01) 의 품목 컬럼 + 생산계획·생산실적 수량
    ItsGrid.Create('grid_MONTH', { isCheckBoxGrid: false, isSubTotalGrid: true, allowMerging: true }, [
        column.create('작업장', 'LINENM', { width: 80, align: 'center', allowMerging: true }),
        column.create('품목ID', 'ITEMID', { width: 100, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150 }),
        column.create('품명', 'ITEMNM', { width: 200 }),
        column.create('규격', 'ITEMSPEC', { width: 200 }),

        column.create('생산계획수량', 'PLANQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum }),
        column.create('생산실적수량', 'RSTQTY', { width: 100, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, backColor: enumColor.greenLight2 }),

        column.create('달성률(%)', 'RATE', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 1 }),

        column.split()
    ]);

    // 주간: 주간 생산계획등록(PRD1001_R02) 의 품목·공정·라인 컬럼 + 기간합계, 일자마다 주/야 계획·실적
    var weekColumns = [
        column.create('작업장', 'LINENM', { width: 70, align: 'center', allowMerging: true }),
        column.create('품목ID', 'ITEMID', { width: 100, align: 'center' }),
        column.create('품목코드', 'ITEMCD', { width: 150 }),
        column.create('품명', 'ITEMNM', { width: 220 }),
        column.create('규격', 'ITEMSPEC', { width: 200 }),
        column.create('공정', 'PRCNM', { width: 100, align: 'center' }),
        column.create('라인', 'EQMNM', { width: 100, align: 'center' }),

        column.band('기간합계', {}, [
            column.create('계획', 'PLANQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, backColor: enumColor.yellowLight2 }),
            column.create('실적', 'RSTQTY', { width: 80, columnType: enumColumnTypes.number, decimalPrecision: 0, groupType: enumGrouping.sum, backColor: enumColor.greenLight2 }),
            column.create('달성률(%)', 'RATE', { width: 75, columnType: enumColumnTypes.number, decimalPrecision: 1 }),
        ]),
    ];

    // 1~31일 (밴드 이름은 조회할 때 'MM/dd (요일)' 로 바꾼다)
    for (var d = 1; d <= 31; d++) {
        weekColumns.push(column.band(d + '일', {}, [
            column.create('주 계획', 'PLAN_' + d + '_DAY', { width: 60, align: 'center' }),
            column.create('주 실적', 'RST_' + d + '_DAY', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0, backColor: enumColor.greenLight2 }),
            column.create('야 계획', 'PLAN_' + d + '_NIGHT', { width: 60, align: 'center' }),
            column.create('야 실적', 'RST_' + d + '_NIGHT', { width: 60, columnType: enumColumnTypes.number, decimalPrecision: 0, backColor: enumColor.greenLight2 }),
        ]));
    }
    weekColumns.push(column.split());

    ItsGrid.Create('grid_WEEK', { isCheckBoxGrid: false, isSubTotalGrid: true, allowMerging: true }, weekColumns);

    ItsCombo.SetValue('cmb_FACTORYCD', '07');   // 공장 기본값 (onChanged 로 품목 find 법인·공장도 들어감)
};

/* 공장이 정해지면 품목 find 에 법인(REF01)·공장(REF03) 넣기. 법인코드는 공장 콤보 목록 줄의 REF01(DC_COMBO FACTORYCD) */
ItsCombo.Event('cmb_FACTORYCD').onChanged = function (value) {
    var companycd = $('#cmb_FACTORYCD').siblings('ul').children('li').filter('[data-value="' + value + '"]').attr('data-ref01');
    if (companycd == undefined || companycd == 'undefined') companycd = '';
    ItsFind.SetRef01('sdiv1_find_ITEMID', companycd);
    ItsFind.SetRef03('sdiv1_find_ITEMID', value);
};

/* 작업장 변경: 공정·라인 목록을 작업장 기준으로 (PRD2001_S01 과 같다) */
ItsCombo.Event('cmb_LINECD').onChanged = function (value) {
    ItsCombo.SetRef01('cmb_PRCCD', value);
    ItsCombo.SetValueByIndex('cmb_PRCCD', 0);
    ItsCombo.SetRef01('cmb_EQMCD', value);
    ItsCombo.SetRef02('cmb_EQMCD', '');
    ItsCombo.SetValueByIndex('cmb_EQMCD', 0);
};

/* 공정 변경: 라인 목록을 작업장·공정 기준으로 */
ItsCombo.Event('cmb_PRCCD').onChanged = function (value) {
    ItsCombo.SetRef02('cmb_EQMCD', value);
    ItsCombo.SetValueByIndex('cmb_EQMCD', 0);
};

/* 조회: 선택된 탭만 조회한다 (월간 = 조회년월·작업장, 주간 = 조회일자·작업장·공정·라인) */
ItsButton.EventSearch = function () {
    var TabIndex = ItsTab.GetIndex('tab1');

    if (TabIndex == 0) {
        ItsGrid.Clear('grid_MONTH');

        var maria = new ItsMaria('PRD2001_S04', 'LIST_MONTH');
        maria.AddPanel('sdiv1');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid_MONTH', maria.store);
        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
    else if (TabIndex == 1) {
        ItsGrid.Clear('grid_WEEK');

        var maria = new ItsMaria('PRD2001_S04', 'LIST_WEEK');
        maria.AddPanel('sdiv1');
        maria.CallProc();
        if (maria.isError) {
            maria.ShowErrMsg();
            return;
        }

        ItsGrid.SetStore('grid_WEEK', maria.store);

        // 일자 밴드 이름을 'MM/dd (요일)' 로 바꾸고, 조회기간 밖의 일자 칸은 숨긴다 (PRD1001_R02 SET_BANDNAME 과 같은 방식)
        var week = new Array("(일)", "(월)", "(화)", "(수)", "(목)", "(금)", "(토)");
        var SDATE = ItsDateRange.GetValueFrom('dateR');
        var EDATE = ItsDateRange.GetValueTo('dateR');
        var firstDay = new Date(SDATE.substr(0, 4), Number(SDATE.substr(5, 2)) - 1, 1);
        var $grid = ItsGrid.Get('grid_WEEK');

        for (var i = 0; i < 31; i++) {
            var day = new Date(firstDay);
            day.setDate(day.getDate() + i);
            var dayValue = day.format('yyyy-MM-dd');
            var isBetween = (day.getMonth() == firstDay.getMonth() && dayValue >= SDATE && dayValue <= EDATE);
            var fields = ['PLAN_' + (i + 1) + '_DAY', 'RST_' + (i + 1) + '_DAY', 'PLAN_' + (i + 1) + '_NIGHT', 'RST_' + (i + 1) + '_NIGHT'];

            for (var j = 0; j < fields.length; j++) {
                var colIndex = ItsGrid.$colIndex('grid_WEEK', fields[j]);
                $grid.columnHeaders.setCellData(0, colIndex, day.format('MM/dd') + ' ' + week[day.getDay()]);
                $grid.columns[colIndex].visible = isBetween;
            }
        }
        $grid.refresh();

        ItsMsg.Toast(ItsMsg.CommonMsg.SearchComplete(maria.store.Length()));
    }
};
