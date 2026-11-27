/// <reference path="../../Script/reference.js" />

var chart1, chart2;
var GOAL_RATE = 0.75;   // 설비고장율 목표관리(MST1006_R01)에 목표가 없을 때 기본 목표 점유율
var PART_COLORS = ['#E6B8B7', '#E4DFEC', '#DAEEF3', '#FDE9D9', '#C5D9F1', '#F2DCDB', '#EBF1DE', '#FCD5B4', '#B7DEE8', '#CCC0DA', '#D8E4BC', '#FFE699'];   // 고장부위 원 그래프 색상

/* 페이지 로드 시 수행 */
ItsPage.Load = function () {
    $(window).resize(CHART_RESIZE);

    ItsCombo.SetValueByIndex('cmb_SYEAR', 4);
    ItsDateRange.SetInitValueFrom('dr_PERIOD', ItsHelper.GetYearMonthDay().substr(0, 4) + '-01-01');
    SHOW_PERIOD(0);
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

// 툴바 [인쇄] → 지금 탭 그래프 출력 (연간 고장 목표대비 달성 S0501, 설비별 고장현황 S0502, 설비별 고장부위 현황 S0503, 조회조건 그대로)
ItsButton.EventPrint = function () {
    var rpt = new ItsXtraRpt('EQM1001_S050' + (ItsTab.GetIndex('tab1') + 1));
    rpt.AddPanel('sdiv1');
    rpt.CallPop();
    if (rpt.isError) {
        ItsMsg.Alert(rpt.errMessage);
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

// 탭 바꾸면 그 탭 바로 조회 (작업장·공정·라인을 다 골랐을 때만), 차트 크기를 칸에 맞춤, 조회년도는 연간 탭·조회기간은 설비별 고장현황·부품별 현황 탭에서만 표시
ItsTab.Event('tab1').onTabChanged = function (newPanel) {
    SHOW_PERIOD(newPanel);
    if (ItsCombo.GetValue('cmb_LINECD') && ItsCombo.GetValue('cmb_EQMTP') && ItsCombo.GetValue('cmb_EQMGROUP1')) {
        if (newPanel == 0) {
            SEARCH_CHART();
        } else if (newPanel == 1) {
            SEARCH_EQM_FAIL();
        } else if (newPanel == 2) {
            SEARCH_EQM_PART();
        }
    }
    if (newPanel == 0 || newPanel == 1) {
        CHART_RESIZE();
    }
};

// 연간 고장 목표대비 달성 탭(0)은 조회년도, 설비별 고장현황·부품별 현황 탭은 조회기간(달력)만 표시
function SHOW_PERIOD(tab) {
    if (tab == 0) {
        ItsCombo.Show('cmb_SYEAR');
        ItsDateRange.Hide('dr_PERIOD');
    } else {
        ItsCombo.Hide('cmb_SYEAR');
        ItsDateRange.Show('dr_PERIOD');
    }
}

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
    var first = rows.length > 0 ? rows[0] : {};
    var goalRate = first['GOALRATE'] != null ? first['GOALRATE'] : GOAL_RATE;   // 라인 목표 점유율
    var today = ItsHelper.GetYearMonthDay();
    var syear = (ItsCombo.GetValue('cmb_SYEAR') || '').substr(0, 4);
    var curMM = syear < today.substr(0, 4) ? 12 : (syear == today.substr(0, 4) ? Number(today.substr(5, 2)) : 0);   // 현재 월 (지난 해는 12월)
    var categories = [], nonHr = ['NONHR'], nonRate = ['NONRATE'], barColors = [], goalRates = [];
    var maxHr = first['GOALHR'] || 0, maxRate = goalRate, sumWork = 0, cntWork = 0;
    rows.forEach(function (d, i) {
        categories.push(d['GUBUN']);
        nonHr.push(d['NONHR']);
        nonRate.push(d['NONRATE']);
        barColors.push(i == 0 ? '#F2F2F2' : (i == 1 ? '#FFC000' : (i - 1 == curMM ? '#F8CBAD' : '#D8E4BC')));
        goalRates.push(goalRate);
        maxHr = Math.max(maxHr, d['NONHR'] || 0);
        maxRate = Math.max(maxRate, d['NONRATE'] || 0);
        if (i >= 2 && d['WORKHR'] > 0) {
            sumWork += d['WORKHR'];
            cntWork++;
        }
    });
    var range = CHART_RANGE(maxHr, maxRate, cntWork > 0 ? sumWork / cntWork : 0, goalRate);

    // 목표 막대 = 라인 목표 비가동시간 (없으면 월 평균 가동시간의 목표 점유율 만큼, 가동시간도 없으면 막대 없음)
    var goalHr = first['GOALHR'] != null ? first['GOALHR'] : range.goalHr;
    if (goalHr != null) {
        nonHr[1] = Math.floor(goalHr);
        nonRate[1] = goalRate;
    }

    chart1 = DRAW_CHART('chart1', first['TITLE'] || '', categories, nonHr, nonRate, barColors, range, goalRates);
}

// 선택 라인의 설비별 비가동시간·점유율 차트 조회 (총 라인 고장시간, 설비별, 조회기간)
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
    var lineGoal = first['LINEGOALRATE'] != null ? first['LINEGOALRATE'] : GOAL_RATE;   // 총 라인은 라인 목표, 설비는 설비 목표(없으면 라인 목표)
    var categories = ['총 라인 고장 시간'], nonHr = ['NONHR', first['LINENONHR']], nonRate = ['NONRATE', first['LINENONRATE']], barColors = ['#E6B8B7'], goalRates = [lineGoal];
    var maxHr = first['LINENONHR'] || 0, maxRate = Math.max(lineGoal, first['LINENONRATE'] || 0);
    rows.forEach(function (d) {
        var goalRate = d['GOALRATE'] != null ? d['GOALRATE'] : GOAL_RATE;
        categories.push(d['GUBUN']);
        nonHr.push(d['NONHR']);
        nonRate.push(d['NONRATE']);
        barColors.push('#D8E4BC');
        goalRates.push(goalRate);
        maxHr = Math.max(maxHr, d['NONHR'] || 0);
        maxRate = Math.max(maxRate, d['NONRATE'] || 0, goalRate);
    });
    var range = CHART_RANGE(maxHr, maxRate, first['WORKHR'] || 0, lineGoal);

    chart2 = DRAW_CHART('chart2', first['TITLE'] || '', categories, nonHr, nonRate, barColors, range, goalRates);
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

    // 그래프 목록: 고장부위 이력이 있는 총 라인, 설비별 (설비코드 순)
    var pies = lineRows.length > 0 ? [{ fano: '', name: '총 라인 고장 시간', rows: lineRows }] : [];
    eqmRows.forEach(function (d) {
        if (pies.length == 0 || pies[pies.length - 1].fano != d['FANO']) {
            pies.push({ fano: d['FANO'], name: d['EQMNM'] + '\n' + d['FANO'], rows: [] });
        }
        pies[pies.length - 1].rows.push(d);
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

// 고장부위별 수리시간 원 그래프 (조각 라벨은 '부위명, 비중', 범례는 부위명만, 5% 미만 조각은 라벨 생략)
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
            colors: colors
        },
        pie: {
            label: {
                format: function (v, ratio, id) { return names[id] + ',\n' + rates[id] + '%'; }
            }
        },
        tooltip: {
            format: {
                value: function (v, ratio, id) { return Math.floor(v / 60) + 'hr (' + rates[id] + '%)'; }
            }
        },
        legend: {
            contents: {
                bindto: '#' + legendId,
                template: function (id, color) { return PART_LEGEND(names[id], color); }
            },
            item: { onclick: function () { }, onover: function () { }, onout: function () { } }
        },
        onrendered: function () {
            PIE_LABEL_SPREAD(this, chartId);
        }
    });
}

// 원 그래프 조각 라벨이 서로 겹치면 큰 조각 라벨은 그대로 두고 작은 조각 라벨을 그 조각 안에서 거리·각도를 바꿔 빈 자리로 옮김 (그래프 영역 밖은 제외)
function PIE_LABEL_SPREAD($$, chartId) {
    var area = $('#' + chartId + ' svg')[0].getBoundingClientRect();
    var placed = [];
    var nodes = d3.select('#' + chartId).selectAll('.bb-chart-arc text').filter(function () {
        return d3.select(this).text() != '';
    }).nodes();
    nodes.sort(function (a, b) {
        return d3.select(b).datum().value - d3.select(a).datum().value;
    });
    nodes.forEach(function (node) {
        var arc = $$.updateAngle(d3.select(node).datum());
        var pos = /translate\(([-\d.e]+)[ ,]+([-\d.e]+)\)/.exec($$.transformForArcLabel(d3.select(node).datum()));
        if (!arc || !pos) {
            return;
        }
        var dist = Math.sqrt(Math.pow(Number(pos[1]), 2) + Math.pow(Number(pos[2]), 2));
        var mid = (arc.startAngle + arc.endAngle) / 2, span = arc.endAngle - arc.startAngle;
        var best = null, bestScore = Infinity;
        [1, 1.15, 0.8, 1.3, 0.65, 1.45, 0.5].some(function (f) {
            return [0, -0.2, 0.2, -0.35, 0.35].some(function (t) {
                var angle = mid + span * t;
                var tf = 'translate(' + Math.sin(angle) * dist * f + ',' + (-Math.cos(angle) * dist * f) + ')';
                node.setAttribute('transform', tf);
                var r = node.getBoundingClientRect();
                var score = (r.left < area.left || r.right > area.right || r.top < area.top || r.bottom > area.bottom) ? 1000000 : 0;
                placed.forEach(function (o) {
                    score += Math.max(0, Math.min(r.right, o.right) - Math.max(r.left, o.left) + 2) * Math.max(0, Math.min(r.bottom, o.bottom) - Math.max(r.top, o.top) + 2);
                });
                if (score < bestScore) {
                    bestScore = score;
                    best = tf;
                }
                return score == 0;
            });
        });
        node.setAttribute('transform', best);
        placed.push(node.getBoundingClientRect());
    });

    // 라벨을 모든 조각 위 층에 다시 그려 옆 조각에 가려지지 않게 (billboard 원래 라벨은 위치 계산용으로 숨기고, 나타나는 효과 중에 복사돼도 보이도록 투명도 1)
    var layer = d3.select('#' + chartId + ' .bb-chart-arcs');
    layer.selectAll('.part-label').remove();
    nodes.forEach(function (node) {
        var copy = node.cloneNode(true);
        copy.setAttribute('class', 'part-label');
        copy.style.visibility = '';
        copy.style.opacity = '1';
        layer.node().appendChild(copy);
        node.style.visibility = 'hidden';
    });
}

// 원 그래프 범례 항목 (고장부위 색상 사각형 + 부위명)
function PART_LEGEND(text, color) {
    return '<span><svg width="10" height="10"><rect x="0" y="0" width="10" height="10" fill="' + color + '" stroke="#888" /></svg>' + text + '</span>';
}

// 왼쪽(hr)·오른쪽(%) 축 최대값 (오른쪽 축을 가동시간 기준으로 맞춰 막대와 목표선을 비교 가능하게)
function CHART_RANGE(maxHr, maxRate, workHr, goalRate) {
    if (!(workHr > 0)) {
        return { yMax: undefined, y2Max: maxRate * 1.15, goalHr: null };
    }

    var ratePerHr = 100 / workHr;   // 가동시간에서 비가동 1hr 의 점유율(%)
    var yMax = Math.max(maxHr, maxRate / ratePerHr) * 1.15;
    return { yMax: yMax, y2Max: yMax * ratePerHr, goalHr: goalRate / ratePerHr };
}

// 비가동시간 막대 + 점유율·목표 선 차트 (탭1·탭2 공통, goalRates = 막대별 목표 점유율)
function DRAW_CHART(chartId, title, categories, nonHr, nonRate, barColors, range, goalRates) {
    var goalRate = ['GOALRATE'].concat(goalRates);

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
                return d && d.value != null && d.value > goalRates[d.index] ? 'red' : 'blue';
            });

            // 시간 라벨: 막대 끝 바로 안쪽에 표시, 점유율 점이 그 자리에 겹칠 때만 점 아래로 내림
            d3.select('#' + chartId).selectAll('.bb-texts-NONHR text').attr('transform', function (d) {
                if (!d || d.value == null) {
                    return null;
                }
                var barTop = $$.y(d.value);
                var labelY = barTop + 16;
                var rate = nonRate[d.index + 1];
                if (rate != null) {
                    var pointY = $$.y2(rate);
                    if (pointY > barTop - 10 && pointY < labelY + 6) {
                        labelY = pointY + 18;
                    }
                }
                return 'translate(0,' + (labelY - (barTop - 3)) + ')';
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
