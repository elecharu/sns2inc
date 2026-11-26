/// <reference path="../../Script/reference.js" />

var chart1, chart2;
var GOAL_RATE = 0.75;   // 목표 점유율 0.75% 고정
var PART_COLORS = ['#E6B8B7', '#E4DFEC', '#DAEEF3', '#FDE9D9', '#C5D9F1', '#F2DCDB', '#EBF1DE', '#FCD5B4', '#B7DEE8', '#CCC0DA', '#D8E4BC', '#FFE699'];   // 고장부위 원 그래프 색상

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    $(window).resize(CHART_RESIZE);

    ItsCombo.SetValueByIndex('cmb_SYEAR', 4);
};

// 선택 탭 조회 (연간 고장 목표대비 달성, 설비별 고장현황, 설비별 부품별 현황)
ItsButton.EventSearch = function () {
    var tab = ItsTab.GetIndex('tab1');
    if (tab == 0) {
        SEARCH_CHART();
    } else if (tab == 1) {
        SEARCH_EQM_FAIL();
    } else if (tab == 2) {
        SEARCH_EQM_PART();
    }
};

// 작업장 변경시 공정·라인 콤보를 그 작업장 기준으로 변경
ItsCombo.Event('cmb_LINECD').onChanged = function () {
    ItsCombo.SetRef01('cmb_EQMTP', ItsCombo.GetValue('cmb_LINECD'));
    ItsCombo.SetValue('cmb_EQMTP', '', false);

    ItsCombo.SetRef01('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_LINECD'), false);
    ItsCombo.SetRef02('cmb_EQMGROUP1', '');
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 공정 변경시 라인 콤보를 그 공정 기준으로 변경
ItsCombo.Event('cmb_EQMTP').onChanged = function () {
    ItsCombo.SetRef02('cmb_EQMGROUP1', ItsCombo.GetValue('cmb_EQMTP'));
    ItsCombo.SetValue('cmb_EQMGROUP1', '', false);
};

// 차트 탭으로 돌아오면 차트 크기를 칸에 맞춤
ItsTab.Event('tab1').onTabChanged = function (newPanel) {
    if (newPanel == 0 || newPanel == 1) {
        CHART_RESIZE();
    }
};

// 차트 높이를 칸에 맞춤 (본문·탭 높이가 정해진 뒤 실행)
function CHART_RESIZE() {
    setTimeout(function () {
        if (chart1 != undefined) {
            chart1.resize({ height: $('#chart1').height() });
        }
        if (chart2 != undefined) {
            chart2.resize({ height: $('#chart2').height() });
        }
    }, 10);
}

// 선택 라인의 연간 비가동시간·점유율 차트 조회 (목표, 평균, 1~12월)
function SEARCH_CHART() {
    var maria = new ItsMaria('EQM1001_S05', 'LIST_CHART');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var rows = maria.store.data;
    var today = ItsHelper.GetYearMonthDay();
    var syear = (ItsCombo.GetValue('cmb_SYEAR') || '').substr(0, 4);
    var curMM = syear < today.substr(0, 4) ? 12 : (syear == today.substr(0, 4) ? Number(today.substr(5, 2)) : 0);   // 현재 월 (지난 해는 12월)
    var categories = [], nonHr = ['NONHR'], nonRate = ['NONRATE'], barColors = [];
    var maxHr = 0, maxRate = GOAL_RATE, sumWork = 0, cntWork = 0;
    rows.forEach(function (d, i) {
        categories.push(d['GUBUN']);
        nonHr.push(d['NONHR']);
        nonRate.push(d['NONRATE']);
        barColors.push(i == 0 ? '#F2F2F2' : (i == 1 ? '#FFC000' : (i - 1 == curMM ? '#F8CBAD' : '#D8E4BC')));
        maxHr = Math.max(maxHr, d['NONHR'] || 0);
        maxRate = Math.max(maxRate, d['NONRATE'] || 0);
        if (i >= 2 && d['WORKHR'] > 0) {
            sumWork += d['WORKHR'];
            cntWork++;
        }
    });
    var range = CHART_RANGE(maxHr, maxRate, cntWork > 0 ? sumWork / cntWork : 0);

    // 목표 막대 = 월 평균 가동시간의 목표 점유율 만큼 비가동시간 (가동시간이 없으면 막대 없음)
    if (range.goalHr != null) {
        nonHr[1] = Math.round(range.goalHr * 10) / 10;
        nonRate[1] = GOAL_RATE;
    }

    chart1 = DRAW_CHART('chart1', rows.length > 0 ? rows[0]['TITLE'] : '', categories, nonHr, nonRate, barColors, range);
}

// 선택 라인의 설비별 비가동시간·점유율 차트 조회 (총 라인 고장시간, 설비별)
function SEARCH_EQM_FAIL() {
    var maria = new ItsMaria('EQM1001_S05', 'LIST_EQM_FAIL');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var rows = maria.store.data;
    var first = rows.length > 0 ? rows[0] : {};
    var categories = ['총 라인 고장 시간'], nonHr = ['NONHR', first['LINENONHR']], nonRate = ['NONRATE', first['LINENONRATE']], barColors = ['#E6B8B7'];
    var maxHr = first['LINENONHR'] || 0, maxRate = Math.max(GOAL_RATE, first['LINENONRATE'] || 0);
    rows.forEach(function (d) {
        categories.push(d['GUBUN']);
        nonHr.push(d['NONHR']);
        nonRate.push(d['NONRATE']);
        barColors.push('#D8E4BC');
        maxHr = Math.max(maxHr, d['NONHR'] || 0);
        maxRate = Math.max(maxRate, d['NONRATE'] || 0);
    });
    var range = CHART_RANGE(maxHr, maxRate, first['WORKHR'] || 0);

    chart2 = DRAW_CHART('chart2', first['TITLE'] || '', categories, nonHr, nonRate, barColors, range);
}

// 선택 라인의 고장부위별 수리시간 원 그래프 조회 (총 라인 + 설비별)
function SEARCH_EQM_PART() {
    var maria = new ItsMaria('EQM1001_S05', 'LIST_EQM_PART');
    maria.AddPanel('sdiv1');
    maria.CallProc();
    if (maria.isError) {
        maria.ShowErrMsg();
        return;
    }

    var lineRows = maria.store.data;
    var eqmRows = maria.storeExtend1.data;

    // 고장부위별 색상 (라인·설비 그래프에서 같은 부위는 같은 색, 고장부위 미입력은 회색)
    var partColor = {};
    lineRows.forEach(function (d, i) {
        partColor[d['FAILPART']] = d['FAILPART'] == '' ? '#D9D9D9' : PART_COLORS[i % PART_COLORS.length];
    });

    // 그래프 목록: 총 라인, 설비별 (설비코드 순)
    var pies = [{ fano: '', name: '총 라인 고장 시간', rows: lineRows }];
    eqmRows.forEach(function (d) {
        if (pies[pies.length - 1].fano != d['FANO']) {
            pies.push({ fano: d['FANO'], name: d['EQMNM'] + '\n' + d['FANO'], rows: [] });
        }
        if (d['FAILPART'] != null) {
            pies[pies.length - 1].rows.push(d);
        }
    });

    var html = '<div class="part-title">' + (eqmRows.length > 0 ? eqmRows[0]['TITLE'] : '') + '</div><div class="part-list">';
    pies.forEach(function (p, i) {
        html += '<div class="part-item"><div id="part_legend' + i + '" class="part-legend"></div>'
            + '<div id="part_chart' + i + '" class="part-chart"></div>'
            + '<div class="part-name">' + p.name + '</div></div>';
    });
    $('#div_PART').html(html + '</div>');

    pies.forEach(function (p, i) {
        DRAW_PART_CHART('part_chart' + i, 'part_legend' + i, p.rows, partColor);
    });
}

// 고장부위별 수리시간 원 그래프 (조각 라벨은 비중만, 부위명·비중은 범례, 5% 미만 조각은 라벨 생략)
function DRAW_PART_CHART(chartId, legendId, rows, partColor) {
    var columns = [], names = {}, colors = {}, rates = {};
    rows.forEach(function (d) {
        var id = d['FAILPART'] == '' ? 'NONE' : d['FAILPART'];
        columns.push([id, d['PARTMIN']]);
        names[id] = d['FAILPARTNM'];
        colors[id] = partColor[d['FAILPART']];
        rates[id] = d['PARTRATE'];
    });

    bb.generate({
        bindto: '#' + chartId,
        data: {
            columns: columns,
            type: 'pie',
            names: names,
            colors: colors,
            empty: { label: { text: '고장부위 이력 없음' } }
        },
        pie: {
            label: {
                format: function (v, ratio, id) { return rates[id] + '%'; }
            }
        },
        tooltip: {
            format: {
                value: function (v, ratio, id) { return (Math.round(v / 6) / 10) + 'hr (' + rates[id] + '%)'; }
            }
        },
        legend: {
            contents: {
                bindto: '#' + legendId,
                template: function (id, color) { return PART_LEGEND(names[id] + ' ' + rates[id] + '%', color); }
            },
            item: { onclick: function () { }, onover: function () { }, onout: function () { } }
        }
    });
}

// 원 그래프 범례 항목 (고장부위 색상 사각형 + 부위명·비중)
function PART_LEGEND(text, color) {
    return '<span><svg width="10" height="10"><rect x="0" y="0" width="10" height="10" fill="' + color + '" stroke="#888" /></svg>' + text + '</span>';
}

// 왼쪽(hr)·오른쪽(%) 축 최대값 (오른쪽 축을 가동시간 기준으로 맞춰 막대와 목표선을 비교 가능하게)
function CHART_RANGE(maxHr, maxRate, workHr) {
    if (!(workHr > 0)) {
        return { yMax: undefined, y2Max: maxRate * 1.15, goalHr: null };
    }

    var ratePerHr = 100 / workHr;   // 가동시간에서 비가동 1hr 의 점유율(%)
    var yMax = Math.max(maxHr, maxRate / ratePerHr) * 1.15;
    return { yMax: yMax, y2Max: yMax * ratePerHr, goalHr: GOAL_RATE / ratePerHr };
}

// 비가동시간 막대 + 점유율·목표 선 차트 (탭1·탭2 공통)
function DRAW_CHART(chartId, title, categories, nonHr, nonRate, barColors, range) {
    var goalRate = ['GOALRATE'];
    categories.forEach(function () {
        goalRate.push(GOAL_RATE);
    });

    return bb.generate({
        bindto: '#' + chartId,
        size: { height: $('#' + chartId).height() },
        title: { text: title, padding: { top: 6, bottom: 44 } },
        data: {
            columns: [nonHr, nonRate, goalRate],
            names: { NONHR: '설비 비가동시간', NONRATE: '비가동시간 점유율(고장시간/가동시간)', GOALRATE: '목표' },
            type: 'bar',
            types: { NONRATE: 'line', GOALRATE: 'line' },
            axes: { NONRATE: 'y2', GOALRATE: 'y2' },
            colors: { NONHR: '#D8E4BC', NONRATE: 'red', GOALRATE: 'blue' },
            color: function (color, d) {
                return (d && d.id == 'NONHR' && barColors[d.index]) ? barColors[d.index] : color;
            },
            labels: {
                format: {
                    NONHR: function (v) { return v == null || v == 0 ? '' : v + 'hr'; },
                    NONRATE: function (v) { return v == null ? '' : v + '%'; },
                    GOALRATE: function () { return ''; }
                }
            }
        },
        line: { connectNull: true },
        tooltip: {
            format: {
                value: function (v, ratio, id) {
                    return id == 'NONHR' ? v + 'hr' : v + '%';
                }
            }
        },
        legend: {
            contents: { bindto: '#' + chartId + '_legend', template: CHART_LEGEND },
            item: { onclick: function () { }, onover: function () { }, onout: function () { } }
        },
        axis: {
            x: { type: 'category', categories: categories },
            y: { min: 0, max: range.yMax, padding: { top: 0, bottom: 0 } },
            y2: { show: true, min: 0, max: range.y2Max, padding: { top: 0, bottom: 0 }, tick: { format: function (v) { return Math.round(v * 100) / 100 + '%'; } } }
        },
        grid: { y: { show: true } },
        onrendered: function () {
            var $$ = this;

            // 점유율 라벨: 목표 초과는 빨강, 목표 이하는 파랑
            d3.select('#' + chartId).selectAll('.bb-texts-NONRATE text').style('fill', function (d) {
                return d && d.value != null && d.value > GOAL_RATE ? 'red' : 'blue';
            });

            // 시간 라벨: 막대 끝과 점유율 점 중 아래쪽보다 아래(막대 안)에 표시해 점·점유율 라벨과 겹치지 않게
            d3.select('#' + chartId).selectAll('.bb-texts-NONHR text').attr('transform', function (d) {
                if (!d || d.value == null) {
                    return null;
                }
                var barTop = $$.y(d.value);
                var rate = nonRate[d.index + 1];
                var base = (rate == null) ? barTop : Math.max(barTop, $$.y2(rate));
                return 'translate(0,' + (base + 18 - (barTop - 3)) + ')';
            });
        }
    });
}

// 차트 범례 (막대 = 사각형, 선 = 점선 + 동그라미, 목표는 속이 빈 동그라미)
function CHART_LEGEND(id, color) {
    var name = this.config.data_names[id];
    var icon = '<svg width="34" height="10"><rect x="0" y="0" width="34" height="10" fill="' + color + '" stroke="#888" /></svg>';
    if (this.config.data_types[id] == 'line') {
        icon = '<svg width="34" height="10"><line x1="0" y1="5" x2="34" y2="5" stroke="' + color + '" stroke-dasharray="4 3" />'
            + '<circle cx="17" cy="5" r="3" fill="' + (id == 'GOALRATE' ? '#fff' : color) + '" stroke="' + color + '" /></svg>';
    }
    return '<span>' + icon + name + '</span>';
}
