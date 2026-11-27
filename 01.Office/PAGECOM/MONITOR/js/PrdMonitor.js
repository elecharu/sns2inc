// 생산 모니터링 (PrdMonitor.aspx) - 프로시저 PRDMONITOR
var REFRESH_SEC = 30;      // 자동 갱신 주기(초)
var refreshTimer = null;
var monitorData = null;    // 마지막 조회 결과 (창 크기 바뀌면 차트 다시 그림)
var LINE_ROWS = 30;        // 생산/설비가동현황 표가 한 화면에 보여줄 줄 수 (넘치면 스크롤)

$(document).ready(function () {
    // 현재시간
    var clock = function () {
        var now = new Date();
        $('#mon_clock').text(('0' + now.getHours()).slice(-2) + ':' + ('0' + now.getMinutes()).slice(-2) + ':' + ('0' + now.getSeconds()).slice(-2));
    };
    clock();
    setInterval(clock, 1000);

    $(window).on('resize', function () {
        if (monitorData != null) DrawCharts();
        FitLineRows();
    });

    // 목표 PPM 입력
    $('#btn_ppm_edit').on('click', function () {
        $('#txt_ppm').val(monitorData == null ? '' : monitorData.info.TARGETPPM);
        $('#ppm_edit').addClass('is-open');
        $('#btn_ppm_edit').hide();
        $('#txt_ppm').focus().select();
    });
    $('#btn_ppm_cancel').on('click', function () {
        $('#ppm_edit').removeClass('is-open');
        $('#btn_ppm_edit').show();
    });
    $('#txt_ppm').on('keydown', function (e) {
        if (e.keyCode == 13) $('#btn_ppm_save').click();
    });
    $('#btn_ppm_save').on('click', function () {
        var ppm = $.trim($('#txt_ppm').val()).replace(/,/g, '');
        if (!/^[0-9]+(\.[0-9]+)?$/.test(ppm)) {
            alert('목표 PPM 을 숫자로 입력하세요.');
            return;
        }

        var maria = new ItsMaria('PRDMONITOR', 'SAVE_PPM');
        maria.AddParam('TARGETYEAR', monitorData == null ? String(new Date().getFullYear()) : monitorData.info.YEAR);
        maria.AddParam('TARGETPPM', ppm);
        maria.CallProc();
        if (maria.isError) {
            alert(maria.errMessage);
            return;
        }

        $('#ppm_edit').removeClass('is-open');
        $('#btn_ppm_edit').show();
        MonitorSearch();
    });

    MonitorSearch();
});

// 조회 (REFRESH_SEC 마다 다시 부른다)
function MonitorSearch() {
    clearTimeout(refreshTimer);
    refreshTimer = setTimeout(MonitorSearch, REFRESH_SEC * 1000);

    var maria = new ItsMaria('PRDMONITOR', 'LIST');
    maria.CallProc();
    if (maria.isError) {
        // 화면은 그대로 두고 다음 갱신 때 다시 시도
        $('#mon_status').text('조회 오류 (' + new Date().toLocaleTimeString() + ') : ' + maria.errMessage);
        return;
    }
    $('#mon_status').text('');

    monitorData = {
        info: maria.stores[0].data[0],
        sal: maria.stores[1].data,
        ppm: maria.stores[2].data,
        line: maria.stores[3].data
    };
    var info = monitorData.info;
    var yearMonth = info.YEAR + '년 ' + info.MONTH + '월';

    $('#sal_chart_title').text(yearMonth + ' 판매실적(단위:백만원)');
    $('#sal_table_title').text(yearMonth + ' 계획대비 실적(단위:백만원)');
    $('#ppm_title').text(info.YEAR + '년 월별불량현황(PPM)');
    $('#line_title').text('생산/설비가동현황 - ' + Number(info.WORKDATE.substr(5, 2)) + '월 ' + Number(info.WORKDATE.substr(8, 2)) + '일');
    $('#ppm_target').text(NumFormat(info.TARGETPPM));

    // 계획대비 실적 표 (백만원)
    var html = '';
    var sumPlan = 0, sumRst = 0;
    for (var i = 0; i < monitorData.sal.length; i++) {
        var row = monitorData.sal[i];
        sumPlan += Number(row.PLANAMT);
        sumRst += Number(row.RSTAMT);
        html += SalRowHtml('', row.DEBCNM, Number(row.PLANAMT), Number(row.RSTAMT));
    }
    html += SalRowHtml('is-total', '합계', sumPlan, sumRst);
    $('#sal_table').html(html);

    // 생산/설비가동현황 표
    html = '';
    var totPlan = 0, totGood = 0, totRate = 0, totTime = 0;
    for (var i = 0; i < monitorData.line.length; i++) {
        var row = monitorData.line[i];
        totPlan += Number(row.PLANQTY);
        totGood += Number(row.GOODQTY);
        totRate += Number(row.RATE);
        totTime += Number(row.TIMERATE);

        var stt = '<span class="stt stt-none">-</span>';   // PLC 연계 전
        if (row.RUNSTT == 'RUN') stt = '<span class="stt stt-run">가동</span>';
        else if (row.RUNSTT == 'STOP') stt = '<span class="stt stt-stop">비가동</span>';

        // 달성율 막대 색 : 100% 이상 초록, 70% 이상 파랑, 그 아래 주황
        var rate = Number(row.RATE);
        var rateCls = rate >= 100 ? 'rate-hi' : rate >= 70 ? 'rate-mid' : 'rate-low';

        html += '<tr>'
            + '<td title="' + HtmlText(row.LINENM + ' ' + row.EQMNM) + '">' + HtmlText(row.LINENM + ' ' + row.EQMNM) + '</td>'
            + '<td title="' + HtmlText(row.ITEMNM) + '">' + HtmlText(row.ITEMNM) + '</td>'
            + '<td class="num">' + NumFormat(row.PLANQTY) + '</td>'
            + '<td class="num">' + NumFormat(row.GOODQTY) + '</td>'
            + '<td><div class="rate ' + rateCls + '"><span class="rate-bar"><i style="width:' + Math.min(rate, 100) + '%"></i></span><b>' + rate + '%</b></div></td>'
            + '<td>' + stt + '</td>'
            + '<td>' + Number(row.TIMERATE) + '%</td>'
            + '</tr>';
    }
    $('#line_table').html(html);
    FitLineRows();

    var cnt = monitorData.line.length;
    $('#sum_plan').text(NumFormat(totPlan));
    $('#sum_good').text(NumFormat(totGood));
    $('#avg_rate').text('평균 ' + (cnt == 0 ? 0 : (totRate / cnt).toFixed(1)) + '%');
    $('#avg_time').text('평균 ' + (cnt == 0 ? 0 : (totTime / cnt).toFixed(1)) + '%');
    $('#sum_plan, #sum_good').addClass('num');

    DrawCharts();
}

// 생산/설비가동현황 표 : 표 영역 높이를 LINE_ROWS 로 나눠 줄 높이·글자 크기를 맞춘다
function FitLineRows() {
    var areaH = $('.line-scroll').height() - $('.line-table thead').outerHeight();
    var rowH = Math.floor(areaH / LINE_ROWS);
    if (rowH < 10) return;

    $('#line_table td').css({
        'height': (rowH - 1) + 'px',          // 1px 는 테두리
        'line-height': (rowH - 2) + 'px',
        'padding-top': 0,
        'padding-bottom': 0,
        'font-size': Math.max(9, Math.floor(rowH * 0.55)) + 'px'
    });
}

function SalRowHtml(cls, name, plan, rst) {
    var rate = plan == 0 ? 0 : Math.floor(rst / plan * 100);
    return '<tr class="' + cls + '">'
        + '<td>' + HtmlText(name) + '</td>'
        + '<td>' + NumFormat(Math.round(plan / 1000000)) + '</td>'
        + '<td>' + NumFormat(Math.round(rst / 1000000)) + '</td>'
        + '<td>' + rate + '%</td>'
        + '</tr>';
}

// 판매실적·불량 PPM 막대그래프
function DrawCharts() {
    // 판매실적 : 구분별 목표/실적 막대 2개
    var labels = [], plan = [], rst = [];
    var sumPlan = 0, sumRst = 0;
    for (var i = 0; i < monitorData.sal.length; i++) {
        labels.push(monitorData.sal[i].DEBCNM);
        plan.push(Math.round(monitorData.sal[i].PLANAMT / 1000000));
        rst.push(Math.round(monitorData.sal[i].RSTAMT / 1000000));
        sumPlan += Number(monitorData.sal[i].PLANAMT);
        sumRst += Number(monitorData.sal[i].RSTAMT);
    }
    labels.push('합계');
    plan.push(Math.round(sumPlan / 1000000));
    rst.push(Math.round(sumRst / 1000000));
    DrawBarChart('sal_chart', labels, [{ values: plan, color: 'var(--plan)' }, { values: rst, color: 'var(--rst)' }], null);

    // 월별 불량 PPM + 목표선
    labels = [];
    var ppm = [];
    for (var i = 0; i < monitorData.ppm.length; i++) {
        labels.push(monitorData.ppm[i].MONTH + '월');
        ppm.push(Number(monitorData.ppm[i].PPM));
    }
    DrawBarChart('ppm_chart', labels, [{ values: ppm, color: 'var(--ppm)', overColor: 'var(--over)' }], Number(monitorData.info.TARGETPPM));
}

// 막대그래프 (SVG). series = [{ values, color, overColor(목표 넘은 막대 색, 생략 가능) }], target = 가로 목표선 값 (없으면 null)
function DrawBarChart(id, labels, series, target) {
    var $box = $('#' + id);
    var w = $box.width(), h = $box.height();
    if (w < 50 || h < 50) return;

    var padL = 50, padR = 10, padT = 22, padB = 24;
    var plotW = w - padL - padR, plotH = h - padT - padB;

    var max = target || 0;
    for (var s = 0; s < series.length; s++) {
        for (var i = 0; i < series[s].values.length; i++) max = Math.max(max, series[s].values[i]);
    }
    // 눈금 : 1·2·5 단위로 5칸 안팎
    var step = 1;
    var raw = max / 5;
    if (raw > 0) {
        var mag = Math.pow(10, Math.floor(Math.log(raw) / Math.LN10));
        step = raw / mag <= 1 ? mag : raw / mag <= 2 ? 2 * mag : raw / mag <= 5 ? 5 * mag : 10 * mag;
    }
    var top = Math.max(step * Math.ceil(max * 1.1 / step), step);
    var fs = Math.max(10, Math.round(h / 22));

    var svg = '<svg viewBox="0 0 ' + w + ' ' + h + '" xmlns="http://www.w3.org/2000/svg">';
    for (var v = 0; v <= top; v += step) {
        var y = padT + plotH - v / top * plotH;
        svg += '<line class="' + (v == 0 ? 'base-line' : 'grid-line') + '" x1="' + padL + '" x2="' + (w - padR) + '" y1="' + y + '" y2="' + y + '"/>';
        svg += '<text class="axis-text" x="' + (padL - 6) + '" y="' + (y + fs / 3) + '" font-size="' + (fs - 1) + '" text-anchor="end">' + NumFormat(v) + '</text>';
    }

    var groupW = plotW / labels.length;
    var barW = Math.min(groupW * 0.7 / series.length, 60);
    for (var i = 0; i < labels.length; i++) {
        var gx = padL + groupW * i + (groupW - barW * series.length) / 2;
        for (var s = 0; s < series.length; s++) {
            var val = series[s].values[i] || 0;
            var bh = val / top * plotH;
            var x = gx + barW * s;
            var y = padT + plotH - bh;
            var color = (series[s].overColor && target > 0 && val > target) ? series[s].overColor : series[s].color;
            svg += '<rect x="' + (x + 2) + '" y="' + y + '" width="' + (barW - 4) + '" height="' + bh + '" rx="' + Math.min(4, bh / 2) + '" style="fill:' + color + '"/>';
            svg += '<text x="' + (x + barW / 2) + '" y="' + (y - 5) + '" font-size="' + fs + '" font-weight="600" text-anchor="middle">' + NumFormat(val) + '</text>';
        }
        svg += '<text class="axis-text" x="' + (padL + groupW * i + groupW / 2) + '" y="' + (h - 6) + '" font-size="' + fs + '" text-anchor="middle">' + HtmlText(labels[i]) + '</text>';
    }

    if (target != null && target > 0) {
        var ty = padT + plotH - target / top * plotH;
        svg += '<line x1="' + padL + '" x2="' + (w - padR) + '" y1="' + ty + '" y2="' + ty + '" style="stroke:var(--target);stroke-width:2;stroke-dasharray:6 4"/>';
    }
    svg += '</svg>';
    $box.html(svg);
}

function NumFormat(v) {
    var n = Number(v);
    return isNaN(n) ? '' : n.toLocaleString('ko-KR');
}

function HtmlText(v) {
    return String(v == null ? '' : v).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}
