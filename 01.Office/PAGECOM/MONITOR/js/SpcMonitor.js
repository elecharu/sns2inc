// SPC 모니터링(자주검사) (SpcMonitor.aspx) - 프로시저 SPCMONITOR
//   주소에 EQMCD 가 없으면 SPC 모니터링 라인 전체(특성 있는 SPC 관리항목만), 있으면 그 라인의 SPC 관리항목 전체 (라인 클릭 → 새 창)
//   라인마다 이번 달 그 라인에서 자주검사한 품목 전부 (지금 생산중인 품목만이 아님)
//   점 하나 = 검사 1회 (Xbar = 그 검사 검사값 평균, R = 최대-최소). 기간 = 이번 달
//   관리한계는 SPC 관리항목 등록(TQM4001_R01) 값, 등록 안 됐으면(0) 이번 달 데이터로 계산 (A2·D3·D4)
//   규격은 등록 USL·LSL, 등록 안 됐으면 검사기준 판정기준 최소·최대
//   전체 라인 화면은 라인 카드가 한 화면에 다 안 들어가면 라인 카드 단위로 페이지를 나눠 PAGE_SEC 마다 넘긴다
var REFRESH_SEC = 60;                 // 자동 갱신 주기(초)
var PAGE_SEC = 20;                    // 페이지 자동 넘김 주기(초)
var pages = [];                       // 페이지별 라인 카드 (jQuery 요소 배열)
var pageIndex = 0;
var pageLeft = PAGE_SEC;
var pagePaused = false;
var refreshTimer = null;
var LINE_EQMCD = '';                  // 라인 창이면 그 라인
var CHART_MODE = 'XR';                // XR = Xbar·R 차트, HIST = 히스토그램
var spcData = null;                   // 마지막 조회 결과 (창 크기 바뀌면 차트만 다시 그림)

// 관리도 계수 (군의 크기 n = 2 ~ 25)
var A2 = { 2: 1.880, 3: 1.023, 4: 0.729, 5: 0.577, 6: 0.483, 7: 0.419, 8: 0.373, 9: 0.337, 10: 0.308, 11: 0.285, 12: 0.266, 13: 0.249,
           14: 0.235, 15: 0.223, 16: 0.212, 17: 0.203, 18: 0.194, 19: 0.187, 20: 0.180, 21: 0.173, 22: 0.167, 23: 0.162, 24: 0.157, 25: 0.153 };
var D3 = { 2: 0, 3: 0, 4: 0, 5: 0, 6: 0, 7: 0.076, 8: 0.136, 9: 0.184, 10: 0.223, 11: 0.256, 12: 0.283, 13: 0.307,
           14: 0.328, 15: 0.347, 16: 0.363, 17: 0.378, 18: 0.391, 19: 0.403, 20: 0.415, 21: 0.425, 22: 0.434, 23: 0.443, 24: 0.451, 25: 0.459 };
var D4 = { 2: 3.267, 3: 2.574, 4: 2.282, 5: 2.114, 6: 2.004, 7: 1.924, 8: 1.864, 9: 1.816, 10: 1.777, 11: 1.744, 12: 1.717, 13: 1.693,
           14: 1.672, 15: 1.653, 16: 1.637, 17: 1.622, 18: 1.608, 19: 1.597, 20: 1.585, 21: 1.575, 22: 1.566, 23: 1.557, 24: 1.548, 25: 1.541 };

$(document).ready(function () {
    var m = /[?&]EQMCD=([^&]*)/.exec(location.search);
    LINE_EQMCD = m ? decodeURIComponent(m[1]) : '';
    $('body').toggleClass('is-line', LINE_EQMCD != '');

    // 현재시간
    var clock = function () {
        var now = new Date();
        $('#spc_clock').text(('0' + now.getHours()).slice(-2) + ':' + ('0' + now.getMinutes()).slice(-2) + ':' + ('0' + now.getSeconds()).slice(-2));
    };
    clock();
    setInterval(clock, 1000);

    // Xbar·R 차트 ↔ 히스토그램
    $('#btn_mode').on('click', function () {
        CHART_MODE = CHART_MODE == 'XR' ? 'HIST' : 'XR';
        $(this).text(CHART_MODE == 'XR' ? '히스토그램 보기' : 'Xbar-R 차트 보기');
        if (spcData != null) Relayout();
    });

    // 페이지 넘김 (전체 라인 화면): 1초마다 남은 시간을 줄이고 0 이면 다음 페이지
    setInterval(function () {
        if (pages.length <= 1 || pagePaused) return;
        pageLeft--;
        if (pageLeft <= 0) {
            pageIndex = (pageIndex + 1) % pages.length;
            ShowPage();
            return;
        }
        $('#page_sec').text(pageLeft + '초');
    }, 1000);
    $('#btn_prev').on('click', function () {
        pageIndex = (pageIndex - 1 + pages.length) % pages.length;
        ShowPage();
    });
    $('#btn_next').on('click', function () {
        pageIndex = (pageIndex + 1) % pages.length;
        ShowPage();
    });
    $('#btn_pause').on('click', function () {
        pagePaused = !pagePaused;
        $(this).text(pagePaused ? '재생' : '멈춤');
        $('#page_sec').text(pagePaused ? '멈춤' : pageLeft + '초');
    });

    // 라인 클릭 → 그 라인의 SPC 관리항목 전체를 새 창으로
    $('#spc_body').on('click', '.line-head', function () {
        if (LINE_EQMCD != '') return;   // 이미 라인 창
        var eqmcd = $(this).closest('.line-card').data('eqmcd');
        window.open('SpcMonitor.aspx?EQMCD=' + encodeURIComponent(eqmcd), 'SpcLine_' + eqmcd,
            'width=' + screen.availWidth + ',height=' + screen.availHeight + ',left=0,top=0');
    });

    $(window).on('resize', function () {
        if (spcData != null) Relayout();
    });

    SpcSearch();
});

// 조회 (REFRESH_SEC 마다 다시 부른다)
function SpcSearch() {
    clearTimeout(refreshTimer);
    refreshTimer = setTimeout(SpcSearch, REFRESH_SEC * 1000);

    var maria = new ItsMaria('SPCMONITOR', 'LIST');
    maria.AddParam('EQMCD', LINE_EQMCD);
    maria.AddParam('FEATUREYN', LINE_EQMCD == '' ? 'Y' : 'N');
    maria.CallProc();
    if (maria.isError) {
        // 화면은 그대로 두고 다음 갱신 때 다시 시도
        $('#spc_status').text('조회 오류 (' + new Date().toLocaleTimeString() + ') : ' + maria.errMessage);
        return;
    }
    $('#spc_status').text('');

    var info = maria.stores[0].data[0];
    var lines = maria.stores[1].data;
    var products = maria.stores[2].data;   // 라인별 이번 달 자주검사 품목
    var items = maria.stores[3].data;
    var points = maria.stores[4].data;

    // 검사항목별 점 (검사일시 순으로 온다)
    var pointMap = {};
    for (var i = 0; i < points.length; i++) {
        var p = points[i];
        var key = ItemKey(p);
        if (!pointMap[key]) pointMap[key] = [];
        pointMap[key].push({
            time: p.FIXTIME, emp: p.EMPNM, n: Number(p.N), xbar: Number(p.XBAR), r: Number(p.R),
            vals: String(p.VALS || '').split(',').filter(function (v) { return v !== ''; }).map(Number)
        });
    }

    // 라인·품목별 검사항목 + 관리한계·이탈 계산
    var itemMap = {};
    for (var i = 0; i < items.length; i++) {
        var it = items[i];
        it.points = pointMap[ItemKey(it)] || [];
        CalcItem(it);
        var pkey = it.EQMCD + '|' + it.ITEMID;
        if (!itemMap[pkey]) itemMap[pkey] = [];
        itemMap[pkey].push(it);
    }
    var productMap = {};
    for (var i = 0; i < products.length; i++) {
        var pr = products[i];
        pr.items = itemMap[pr.EQMCD + '|' + pr.ITEMID] || [];
        if (!productMap[pr.EQMCD]) productMap[pr.EQMCD] = [];
        productMap[pr.EQMCD].push(pr);
    }
    for (var i = 0; i < lines.length; i++) {
        lines[i].products = productMap[lines[i].EQMCD] || [];
        lines[i].items = [];   // 라인의 검사항목 전체 (차트 그리기·이탈 수)
        for (var k = 0; k < lines[i].products.length; k++) lines[i].items = lines[i].items.concat(lines[i].products[k].items);
    }

    spcData = { info: info, lines: lines };
    RenderBody();
}

function ItemKey(row) {
    return row.EQMCD + '|' + row.ITEMID + '|' + row.STDCD + '|' + row.STDPART + '|' + row.PRCDETAIL;
}

// 관리한계·규격과 이탈 점 계산
function CalcItem(it) {
    var pts = it.points;
    var sumX = 0, sumR = 0, sumN = 0;
    for (var i = 0; i < pts.length; i++) {
        sumX += pts[i].xbar;
        sumR += pts[i].r;
        sumN += pts[i].n;
    }
    var n = pts.length == 0 ? 0 : Math.min(25, Math.round(sumN / pts.length));
    it.xcl = pts.length == 0 ? null : sumX / pts.length;
    it.rcl = pts.length == 0 ? null : sumR / pts.length;

    var canCalc = pts.length > 0 && n >= 2;
    if (Number(it.XBAR_UCL) != 0 || Number(it.XBAR_LCL) != 0) {
        it.xucl = Number(it.XBAR_UCL);
        it.xlcl = Number(it.XBAR_LCL);
        it.limitSrc = '관리한계 등록값';
    } else if (canCalc) {
        it.xucl = it.xcl + A2[n] * it.rcl;
        it.xlcl = it.xcl - A2[n] * it.rcl;
        it.limitSrc = '관리한계 계산값(n=' + n + ')';
    } else {
        it.xucl = it.xlcl = null;
        it.limitSrc = '관리한계 없음';
    }
    if (Number(it.R_UCL) != 0) {
        it.rucl = Number(it.R_UCL);
        it.rlcl = null;
    } else if (canCalc) {
        it.rucl = D4[n] * it.rcl;
        it.rlcl = D3[n] * it.rcl;
    } else {
        it.rucl = it.rlcl = null;
    }
    it.rusl = Number(it.R_USL) != 0 ? Number(it.R_USL) : null;
    it.usl = Number(it.XBAR_USL) != 0 ? Number(it.XBAR_USL) : (it.STDMAX === '' || it.STDMAX == null ? null : Number(it.STDMAX));
    it.lsl = Number(it.XBAR_LSL) != 0 ? Number(it.XBAR_LSL) : (it.STDMIN === '' || it.STDMIN == null ? null : Number(it.STDMIN));

    // 점마다 이탈 표시 (X 차트: 규격 이탈은 빨강, 관리한계 이탈은 주황 / R 차트: 관리한계 이탈 주황)
    it.vios = [];
    for (var i = 0; i < pts.length; i++) {
        var p = pts[i];
        p.specOut = [];
        for (var k = 0; k < p.vals.length; k++) {
            if ((it.usl != null && p.vals[k] > it.usl) || (it.lsl != null && p.vals[k] < it.lsl)) p.specOut.push(p.vals[k]);
        }
        p.xOut = (it.xucl != null && p.xbar > it.xucl) || (it.xlcl != null && p.xbar < it.xlcl);
        p.rOut = (it.rucl != null && p.r > it.rucl) || (it.rusl != null && p.r > it.rusl);

        if (p.specOut.length > 0) {
            it.vios.push({ p: p, cls: 'spec', text: '규격 이탈 ' + p.specOut.map(Fmt).join(', ')
                + ' (' + (it.lsl != null ? 'LSL ' + Fmt(it.lsl) : '') + (it.lsl != null && it.usl != null ? ' ~ ' : '') + (it.usl != null ? 'USL ' + Fmt(it.usl) : '') + ')' });
        }
        if (p.xOut) {
            it.vios.push({ p: p, cls: 'ctl', text: 'Xbar ' + Fmt(p.xbar) + (p.xbar > it.xucl ? ' > UCL ' + Fmt(it.xucl) : ' < LCL ' + Fmt(it.xlcl)) });
        }
        if (p.rOut) {
            it.vios.push({ p: p, cls: 'ctl', text: 'R ' + Fmt(p.r) + ' > ' + (it.rusl != null && p.r > it.rusl ? 'USL ' + Fmt(it.rusl) : 'UCL ' + Fmt(it.rucl)) });
        }
    }
}

// 라인 카드·검사항목 칸을 만들고 차트를 그린다
function RenderBody() {
    var info = spcData.info;
    var lines = spcData.lines;
    var title = 'S&S 2공장 SPC 모니터링(자주검사) - ' + info.YEAR + '년 ' + info.MONTH + '월';
    if (LINE_EQMCD != '' && lines.length > 0) {
        title = lines[0].LINENM + ' ' + lines[0].EQMNM + ' SPC 관리항목 - ' + info.YEAR + '년 ' + info.MONTH + '월';
    }
    $('#spc_title').text(title);
    document.title = title;

    if (lines.length == 0) {
        $('#spc_body').html('<div class="spc-empty">'
            + (LINE_EQMCD == '' ? 'SPC 모니터링 라인이 없습니다. 라인정보(MST1002_R05)에서 SPC 모니터링(자주검사)을 체크하고 저장하세요.' : '라인을 찾을 수 없습니다.')
            + '</div>');
        return;
    }

    var html = '';
    for (var i = 0; i < lines.length; i++) {
        var line = lines[i];
        var ngCnt = 0;
        for (var k = 0; k < line.items.length; k++) ngCnt += line.items[k].vios.length;

        html += '<section class="line-card" data-eqmcd="' + HtmlText(line.EQMCD) + '">'
            + '<header class="line-head" title="' + (LINE_EQMCD == '' ? '클릭하면 이 라인의 SPC 관리항목 전체를 새 창으로 봅니다' : '') + '">'
            + '<b>' + HtmlText(line.LINENM + ' ' + line.EQMNM) + '</b>'
            + '<span class="line-item">' + (line.products.length == 0 ? '이번 달 자주검사 없음' : '이번 달 검사 품목 ' + line.products.length + '개') + '</span>'
            + (ngCnt > 0 ? '<span class="badge-ng">이탈 ' + ngCnt + '</span>' : (line.items.length > 0 ? '<span class="badge-ok">이탈 없음</span>' : ''))
            + (LINE_EQMCD == '' ? '<span class="line-open">전체 항목 ▸</span>' : '')
            + '</header><div class="line-items">';

        if (line.products.length == 0) {
            html += '<div class="spc-empty">이번 달 이 라인의 자주검사 이력이 없습니다.</div>';
        }
        var no = 0;
        for (var p = 0; p < line.products.length; p++) {
            var pr = line.products[p];
            // 품목 머리 (품번·품명만, 2026-11-27 검사횟수·마지막 검사는 화면이 복잡해 뺌)
            html += '<div class="prod-head"><b>' + HtmlText(pr.ITEMCD) + '</b><span class="prod-nm" title="' + HtmlText(pr.ITEMNM) + '">' + HtmlText(pr.ITEMNM) + '</span></div>';
            if (pr.items.length == 0) {
                html += '<div class="spc-empty">' + (LINE_EQMCD == '' ? '특성이 있는 SPC 관리항목이 없습니다.' : 'SPC 관리항목이 없습니다. SPC 관리항목 등록(TQM4001_R01)에서 등록하세요.') + '</div>';
            }
            if (LINE_EQMCD != '' && pr.items.length > 0) html += '<div class="prod-items">';
            for (var k = 0; k < pr.items.length; k++) {
                var it = pr.items[k];
                it.domId = 'it_' + i + '_' + (no++);
                html += '<div class="item" id="' + it.domId + '">'
                    + '<div class="item-head">'
                    + '<span class="prc">' + HtmlText(it.PRCDETAILNM) + '</span>'
                    + '<b>' + HtmlText(it.STDNM) + '</b>'   // 세부항목은 검사규격과 겹쳐 뺌 (2026-11-27 사용자 지적)
                    + (it.FEATURE ? '<span class="feat">특성항목 ' + HtmlText(it.FEATURE) + '</span>' : '')
                    + '<span class="spec">' + HtmlText(it.STDJUDGE) + '</span>'
                    + '</div>'
                    + '<div class="charts"></div>'
                    + '</div>';
            }
            if (LINE_EQMCD != '' && pr.items.length > 0) html += '</div>';
        }
        html += '</div></section>';
    }
    $('#spc_body').html('<div class="' + (LINE_EQMCD == '' ? 'line-grid' : 'line-one') + '">' + html + '</div>');

    Relayout();
}

// 카드를 다 보이게 해서 차트를 그린 뒤(숨긴 칸은 폭이 0 이라 못 그림) 페이지를 다시 나눈다
function Relayout() {
    $('#spc_body .line-card').prop('hidden', false);
    DrawCharts();
    Paginate();
}

// 라인 카드 단위로 페이지 나누기: 격자에서 같은 줄(같은 top)의 카드를 한 묶음으로, 화면 높이를 넘으면 다음 페이지
function Paginate() {
    pages = [];
    if (LINE_EQMCD != '') {   // 라인 창은 스크롤
        $('#spc_page').prop('hidden', true);
        return;
    }

    var areaH = $('#spc_body').height();
    var rows = [];
    $('#spc_body .line-grid > .line-card').each(function () {
        var top = Math.round(this.offsetTop);
        if (rows.length == 0 || rows[rows.length - 1].top != top) rows.push({ top: top, cards: [], h: 0 });
        var row = rows[rows.length - 1];
        row.cards.push($(this));
        row.h = Math.max(row.h, $(this).outerHeight());
    });

    var cur = [], used = 0, GAP = 8;
    for (var i = 0; i < rows.length; i++) {
        if (cur.length > 0 && used + rows[i].h > areaH) {   // 이 줄이 안 들어가면 다음 페이지 (한 줄이 화면보다 크면 그 줄만 한 페이지, 스크롤)
            pages.push(cur);
            cur = [];
            used = 0;
        }
        cur = cur.concat(rows[i].cards);
        used += rows[i].h + GAP;
    }
    if (cur.length > 0) pages.push(cur);

    if (pageIndex >= pages.length) pageIndex = 0;
    ShowPage();
}

// 지금 페이지의 라인 카드만 보이기
function ShowPage() {
    $('#spc_body .line-card').prop('hidden', true);
    if (pages.length == 0) return;
    for (var i = 0; i < pages[pageIndex].length; i++) pages[pageIndex][i].prop('hidden', false);
    $('#spc_body').scrollTop(0);

    pageLeft = PAGE_SEC;
    $('#spc_page').prop('hidden', pages.length <= 1);
    $('#page_no').text((pageIndex + 1) + ' / ' + pages.length);
    $('#page_sec').text(pagePaused ? '멈춤' : pageLeft + '초');
}

// 검사항목 칸마다 차트 그리기 (모드 바뀌거나 창 크기 바뀌면 이것만 다시)
// 2026-11-27 차트 아래 이탈 상세 목록은 사용자 요청으로 뺌 (이탈 점 위 검사일시·점 툴팁으로 식별)
function DrawCharts() {
    var big = LINE_EQMCD != '';
    for (var i = 0; i < spcData.lines.length; i++) {
        var items = spcData.lines[i].items;
        for (var k = 0; k < items.length; k++) {
            var it = items[k];
            var $item = $('#' + it.domId);
            var $charts = $item.find('.charts');

            if (it.points.length == 0) {
                $charts.html('<div class="spc-empty">이번 달 검사값이 없습니다.</div>');
                continue;
            }

            if (CHART_MODE == 'XR') {
                $charts.html('<div class="chart-x" style="height:' + (big ? 230 : 140) + 'px"></div>'
                    + '<div class="chart-r" style="height:' + (big ? 130 : 85) + 'px"></div>');
                DrawControlChart($charts.find('.chart-x'), it, 'X');
                DrawControlChart($charts.find('.chart-r'), it, 'R');
            } else {
                $charts.html('<div class="chart-h" style="height:' + (big ? 360 : 225) + 'px"></div>');
                DrawHistogram($charts.find('.chart-h'), it);
            }
        }
    }
}

// Xbar(kind X) 또는 R(kind R) 관리도. 이탈 점은 색을 바꾸고 위에 검사일시를 적는다
function DrawControlChart($box, it, kind) {
    var w = $box.width(), h = $box.height();
    if (w < 80 || h < 40) return;
    var pts = it.points;
    var fs = h > 150 ? 11 : 10;
    var padL = 8, padR = 92, padT = kind == 'X' ? 18 : 12, padB = kind == 'X' ? 6 : 16;
    var plotW = w - padL - padR, plotH = h - padT - padB;

    var vals = pts.map(function (p) { return kind == 'X' ? p.xbar : p.r; });
    var lines = [];   // { v, label, cls }
    if (kind == 'X') {
        if (it.usl != null) lines.push({ v: it.usl, label: 'USL', cls: 'ln-spec' });
        if (it.xucl != null) lines.push({ v: it.xucl, label: 'UCL', cls: 'ln-ctl' });
        lines.push({ v: it.xcl, label: 'CL', cls: 'ln-cl' });
        if (it.xlcl != null) lines.push({ v: it.xlcl, label: 'LCL', cls: 'ln-ctl' });
        if (it.lsl != null) lines.push({ v: it.lsl, label: 'LSL', cls: 'ln-spec' });
    } else {
        if (it.rusl != null) lines.push({ v: it.rusl, label: 'USL', cls: 'ln-spec' });
        if (it.rucl != null) lines.push({ v: it.rucl, label: 'UCL', cls: 'ln-ctl' });
        lines.push({ v: it.rcl, label: 'CL', cls: 'ln-cl' });
        if (it.rlcl != null && it.rlcl > 0) lines.push({ v: it.rlcl, label: 'LCL', cls: 'ln-ctl' });
    }

    var lo = Math.min.apply(null, vals), hi = Math.max.apply(null, vals);
    for (var i = 0; i < lines.length; i++) {
        lo = Math.min(lo, lines[i].v);
        hi = Math.max(hi, lines[i].v);
    }
    if (hi == lo) { hi += 1; lo -= 1; }
    var span = hi - lo;
    hi += span * 0.08;
    lo -= span * 0.08;
    var Y = function (v) { return padT + (hi - v) / (hi - lo) * plotH; };
    var X = function (i) { return pts.length == 1 ? padL + plotW / 2 : padL + 6 + i * (plotW - 12) / (pts.length - 1); };

    var svg = '<svg viewBox="0 0 ' + w + ' ' + h + '" xmlns="http://www.w3.org/2000/svg">';
    svg += '<text class="chart-name" x="' + (padL + 2) + '" y="' + (padT - 5) + '" font-size="' + fs + '">' + (kind == 'X' ? 'X̄' : 'R') + '</text>';

    // 한계선 + 오른쪽 이름·값 (가까운 이름은 겹치지 않게 아래로 민다)
    var lastLabelY = -100;
    var sorted = lines.slice().sort(function (a, b) { return b.v - a.v; });
    for (var i = 0; i < sorted.length; i++) {
        var ln = sorted[i];
        var y = Y(ln.v);
        svg += '<line class="' + ln.cls + '" x1="' + padL + '" x2="' + (w - padR) + '" y1="' + y + '" y2="' + y + '"/>';
        var ty = Math.max(y + fs / 3, lastLabelY + fs + 1);
        lastLabelY = ty;
        svg += '<text class="lb ' + ln.cls + '" x="' + (w - padR + 4) + '" y="' + ty + '" font-size="' + (fs - 1) + '">' + ln.label + ' ' + Fmt(ln.v) + '</text>';
    }

    // R 차트 아래: 날짜 (날짜가 바뀌는 점, 앞 글자와 겹치면 생략)
    if (kind == 'R') {
        var lastX = -100, lastDay = '';
        for (var i = 0; i < pts.length; i++) {
            var day = String(pts[i].time).substr(5, 5).replace('-', '/');
            if (day == lastDay || X(i) - lastX < 34) continue;
            svg += '<text class="axis-text" x="' + X(i) + '" y="' + (h - 3) + '" font-size="' + (fs - 1) + '" text-anchor="middle">' + day + '</text>';
            lastX = X(i);
            lastDay = day;
        }
    }

    // 선 + 점
    svg += '<polyline class="pt-line" points="' + vals.map(function (v, i) { return X(i).toFixed(1) + ',' + Y(v).toFixed(1); }).join(' ') + '"/>';
    var labelTurn = 0;
    for (var i = 0; i < pts.length; i++) {
        var p = pts[i];
        var cls = 'pt';
        if (kind == 'X' && p.specOut.length > 0) cls = 'pt pt-spec';
        else if ((kind == 'X' && p.xOut) || (kind == 'R' && p.rOut)) cls = 'pt pt-ctl';
        var x = X(i), y = Y(vals[i]);
        var tip = TimeText(p.time) + ' ' + (p.emp || '') + '\n' + 'Xbar ' + Fmt(p.xbar) + ' / R ' + Fmt(p.r) + ' (값 ' + p.n + '개)\n' + p.vals.map(Fmt).join(', ');
        svg += '<circle class="' + cls + '" cx="' + x.toFixed(1) + '" cy="' + y.toFixed(1) + '" r="' + (cls == 'pt' ? 2.6 : 4.2) + '"><title>' + HtmlText(tip) + '</title></circle>';

        // 이탈 점은 검사일시를 점 위(또는 아래)에 적는다. 이웃 글자와 겹치지 않게 위·아래를 번갈아
        if (cls != 'pt') {
            var up = labelTurn % 2 == 0;
            labelTurn++;
            var ly = up ? y - 7 : y + fs + 5;
            if (ly < fs) ly = y + fs + 5;
            if (ly > h - 2) ly = y - 7;
            var anchor = x < padL + 40 ? 'start' : (x > w - padR - 40 ? 'end' : 'middle');
            svg += '<text class="pt-label ' + (cls == 'pt pt-spec' ? 'pt-spec' : 'pt-ctl') + '" x="' + x.toFixed(1) + '" y="' + ly.toFixed(1) + '" font-size="' + (fs - 1) + '" text-anchor="' + anchor + '">'
                + HtmlText(TimeText(p.time)) + '</text>';
        }
    }
    svg += '</svg>';
    $box.html(svg);
}

// 히스토그램 (이번 달 검사값 전체). 규격 밖 막대는 빨강
function DrawHistogram($box, it) {
    var w = $box.width(), h = $box.height();
    if (w < 80 || h < 60) return;
    var vals = [];
    for (var i = 0; i < it.points.length; i++) vals = vals.concat(it.points[i].vals);
    if (vals.length == 0) return;

    var fs = h > 300 ? 11 : 10;
    var padL = 34, padR = 12, padT = 40, padB = 20;
    var plotW = w - padL - padR, plotH = h - padT - padB;

    var mean = 0;
    for (var i = 0; i < vals.length; i++) mean += vals[i];
    mean /= vals.length;
    var sd = 0;
    for (var i = 0; i < vals.length; i++) sd += Math.pow(vals[i] - mean, 2);
    sd = vals.length > 1 ? Math.sqrt(sd / (vals.length - 1)) : 0;

    var lo = Math.min.apply(null, vals), hi = Math.max.apply(null, vals);
    if (it.lsl != null) lo = Math.min(lo, it.lsl);
    if (it.usl != null) hi = Math.max(hi, it.usl);
    if (hi == lo) { hi += 1; lo -= 1; }
    var span = hi - lo;
    lo -= span * 0.06;
    hi += span * 0.06;

    var bins = Math.max(6, Math.min(20, Math.round(Math.sqrt(vals.length))));
    var bw = (hi - lo) / bins;
    var cnt = [];
    for (var b = 0; b < bins; b++) cnt.push(0);
    for (var i = 0; i < vals.length; i++) cnt[Math.min(bins - 1, Math.floor((vals[i] - lo) / bw))]++;
    var maxCnt = Math.max.apply(null, cnt);

    var X = function (v) { return padL + (v - lo) / (hi - lo) * plotW; };
    var Y = function (c) { return padT + plotH - c / maxCnt * plotH; };

    var svg = '<svg viewBox="0 0 ' + w + ' ' + h + '" xmlns="http://www.w3.org/2000/svg">';
    svg += '<text class="chart-name" x="' + padL + '" y="12" font-size="' + fs + '">검사값 ' + vals.length + '개 · 평균 ' + Fmt(mean) + ' · 표준편차 ' + Fmt(sd) + '</text>';
    // 개수 눈금
    var step = Math.max(1, Math.ceil(maxCnt / 4));
    for (var c = 0; c <= maxCnt; c += step) {
        svg += '<line class="grid-line" x1="' + padL + '" x2="' + (w - padR) + '" y1="' + Y(c) + '" y2="' + Y(c) + '"/>';
        svg += '<text class="axis-text" x="' + (padL - 4) + '" y="' + (Y(c) + 3) + '" font-size="' + (fs - 1) + '" text-anchor="end">' + c + '</text>';
    }
    for (var b = 0; b < bins; b++) {
        if (cnt[b] == 0) continue;
        var a = lo + b * bw, mid = a + bw / 2;
        var out = (it.usl != null && mid > it.usl) || (it.lsl != null && mid < it.lsl);
        svg += '<rect class="' + (out ? 'bar-out' : 'bar') + '" x="' + (X(a) + 1).toFixed(1) + '" y="' + Y(cnt[b]).toFixed(1) + '" width="' + Math.max(1, X(a + bw) - X(a) - 2).toFixed(1)
            + '" height="' + (padT + plotH - Y(cnt[b])).toFixed(1) + '"><title>' + Fmt(a) + ' ~ ' + Fmt(a + bw) + ' : ' + cnt[b] + '개</title></rect>';
    }
    var marks = [{ v: it.lsl, label: 'LSL', cls: 'ln-spec' }, { v: it.usl, label: 'USL', cls: 'ln-spec' }, { v: mean, label: '평균', cls: 'ln-cl' }];
    for (var i = 0; i < marks.length; i++) {
        if (marks[i].v == null) continue;
        var x = X(marks[i].v);
        svg += '<line class="' + marks[i].cls + '" x1="' + x + '" x2="' + x + '" y1="' + (padT - 4) + '" y2="' + (padT + plotH) + '"/>';
        svg += '<text class="lb ' + marks[i].cls + '" x="' + x + '" y="' + (padT - 7) + '" font-size="' + (fs - 1) + '" text-anchor="middle">' + marks[i].label + '</text>';
        svg += '<text class="axis-text" x="' + x + '" y="' + (h - 5) + '" font-size="' + (fs - 1) + '" text-anchor="middle">' + Fmt(marks[i].v) + '</text>';
    }
    svg += '<line class="axis-line" x1="' + padL + '" x2="' + (w - padR) + '" y1="' + (padT + plotH) + '" y2="' + (padT + plotH) + '"/>';
    svg += '</svg>';
    $box.html(svg);
}

// 숫자 표시 (소수 4자리까지, 뒤 0 없음)
function Fmt(v) {
    var n = Number(v);
    return isNaN(n) ? '' : String(Number(n.toFixed(4)));
}

// 검사일시 'yyyy-MM-dd HH:mm:ss' → 'MM/dd HH:mm'
function TimeText(t) {
    t = String(t || '');
    return t.length >= 16 ? t.substr(5, 2) + '/' + t.substr(8, 2) + ' ' + t.substr(11, 5) : t;
}

function HtmlText(v) {
    return String(v == null ? '' : v).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}
