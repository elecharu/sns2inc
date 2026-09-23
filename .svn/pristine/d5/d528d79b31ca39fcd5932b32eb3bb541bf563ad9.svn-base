// 현재시간 정보입력 및 업데이트
function CurrentDate(date) {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');

    return `${year}년 ${month}월 ${day}일`;
}
function CurrentTime(date) {
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    const seconds = String(date.getSeconds()).padStart(2, '0');

    return `${hours}:${minutes}:${seconds}`;
}
function updateCurrentDate() {
    const now = new Date();
    const formattedDate = CurrentDate(now);
    const formattedTime = CurrentTime(now);

    const currentDateElement = document.getElementById('currentDate');
    currentDateElement.textContent = formattedDate;

    const currentTimeElement = document.getElementById('currentTime');
    currentTimeElement.textContent = formattedTime;
}
function timer() {
    updateCurrentDate();
    setInterval(updateCurrentDate, 1000);
}
// 테마 적용 (light/dark)
function applyTheme(theme) {
    document.documentElement.setAttribute('data-theme', theme);
    try { localStorage.setItem('theme', theme); } catch (e) {}
    const btn = document.querySelector('.theme-toggle');
    if (btn) btn.setAttribute('aria-pressed', theme === 'light' ? 'true' : 'false');
}
$(document).on('click', '.theme-toggle', function() {
    const current = document.documentElement.getAttribute('data-theme') === 'light' ? 'light' : 'dark';
    applyTheme(current === 'light' ? 'dark' : 'light');
});

// 버튼클릭 전체화면
$(document).on('click', '.search-icon', function() {
    if (!document.fullscreenElement) {
        document.documentElement.requestFullscreen();
    } else {
        if (document.exitFullscreen) {
            document.exitFullscreen();
        }
    }
});

// 임시 DB
// var stores = [
//     {
//         // 0. 임시 데이터 - KPI
//         data: [
//             { M_ORD: '1000', M_PROD: '1200', M_UNPRD: '1300' }
//         ]
//     },
//     {
//         // 1. 임시 데이터 - 공정별 불량율
//         data: [
//             { GR_MACH: '9', GR_BEND: '1', GR_PRES: '2', GR_WELD: '3', GR_ANOD: '4', GR_COAT: '5', GR_PLAT: '6' }
//         ]
//     },
//     {
//         // 2. 임시 데이터 - 금일 불량
//         data: [
//             { DEF_DUE: '23.10.01', DEF_CST: '준일테크', DEF_ICD: '714-271945-201', DEF_INM: '카메라박스-반제품01', DEF_PRC: '절곡', DEF_TP: '절곡치수불량', DEF_QTY: 10, DEF_EMP: '임경일' },
//             { DEF_DUE: '23.10.02', DEF_CST: '진성이엔지', DEF_ICD: '714-271945-202', DEF_INM: 'PL,MTG,ELECT COMP,CEFEM', DEF_PRC: '압입', DEF_TP: '압입틀어짐', DEF_QTY: 5, DEF_EMP: '임경일' },
//             { DEF_DUE: '23.10.03', DEF_CST: '진성이엔지', DEF_ICD: '714-271945-203', DEF_INM: 'PL,MTG,ELECT COMP,CEFEM', DEF_PRC: '절곡', DEF_TP: '압입틀어짐', DEF_QTY: 8, DEF_EMP: '임경일' },
//             { DEF_DUE: '23.10.04', DEF_CST: '진성이엔지', DEF_ICD: '714-271945-204', DEF_INM: 'PL,MTG,ELECT COMP,CEFEM', DEF_PRC: '용접', DEF_TP: '압입틀어짐', DEF_QTY: 12, DEF_EMP: '임경일' },
//             { DEF_DUE: '23.10.05', DEF_CST: '진성이엔지', DEF_ICD: '714-271945-205', DEF_INM: 'PL,MTG,ELECT COMP,CEFEM', DEF_PRC: '도금', DEF_TP: '압입틀어짐', DEF_QTY: 15, DEF_EMP: '임경일' }
//         ]
//     },
//         {
//         // 3. 임시 데이터 - 비가동 유형
//         data: [
//             { STP_TP: '기계수리', STP_NM: '절곡 1호기', STP_TM: '26.08.03 15:38', STP_EMP: '김성수' },
//             { STP_TP: '작업셋팅', STP_NM: '레이저가공 1호기', STP_TM: '26.08.03 15:37', STP_EMP: '박성수' },
//             { STP_TP: '작업셋팅', STP_NM: '레이저가공 2호기', STP_TM: '26.08.03 15:36', STP_EMP: '이성수' },
//         ]
//     },
//     {
//         // 4. 임시 데이터 - 수주 리스트
//         data: [
//             { ORD_ITM: '카메라박스', ORD_CST: '준일테크', ORD_DUE: '26.07.26', ORD_QTY: '3', ORD_PRC: '포장', ORD_SHP: '100', ORD_PER: '50' },
//             { ORD_ITM: 'PNL,TOP,ENCL,N2 PURGE,SFEM CFG', ORD_CST: '진성이엔지', ORD_DUE: '26.07.29', ORD_QTY: '3', ORD_PRC: '용접', ORD_SHP: '100', ORD_PER: '66' },
//             { ORD_ITM: '카메라박스', ORD_CST: '준일테크', ORD_DUE: '26.07.26', ORD_QTY: '3', ORD_PRC: '포장', ORD_SHP: '100', ORD_PER: '50' },
//             { ORD_ITM: 'PNL,TOP,ENCL,N2 PURGE,SFEM CFG', ORD_CST: '진성이엔지', ORD_DUE: '26.07.29', ORD_QTY: '3', ORD_PRC: '용접', ORD_SHP: '100', ORD_PER: '50' },
//             { ORD_ITM: '카메라박스', ORD_CST: '준일테크', ORD_DUE: '26.07.26', ORD_QTY: '3', ORD_PRC: '포장', ORD_SHP: '100', ORD_PER: '10' },
//         ]
//     },
// ]

// 천단위 콤마
function comma(v) {
    var n = Number(v);
    return isNaN(n) ? (v || '-') : n.toLocaleString('ko-KR');
}

// 0. KPI 데이터 렌더링
function kpiData(ord, prod, unprod) {
    $('[data-name="M_ORD"]').html(comma(ord));
    $('[data-name="M_PROD"]').html(comma(prod));
    $('[data-name="M_UNPRD"]').html(comma(unprod));
}

// 1. 공정별 불량율 차트 렌더링
var CHART_MAX = 10000; // y축 최대값
var KPI_LABELS = { M_ORD: '당월 수주량', M_PROD: '당월 생산량', M_UNPRD: '당월 미달성' };

function renderDefectChart(rows) {
    const bars = document.querySelector('.chart-panel .bars');
    const panel = document.querySelector('.chart-panel');
    if (!rows || !rows.length || !bars || !panel) return;

    bars.style.setProperty('--bar-count', rows.length);
    bars.innerHTML = rows.map(function (row) {
        const value = Number(row.M_DATA) || 0;
        const label = KPI_LABELS[row.M_NAME] || row.M_NAME;
        const pct = Math.min(100, (value / CHART_MAX) * 100);
        const zeroClass = value === 0 ? ' is-zero' : '';
        return '<div class="bar-item"><div class="bar-track"><div class="bar' + zeroClass + '" style="--value:' + pct + '%"><span>' + comma(value) + '</span></div></div><em>' + label + '</em></div>';
    }).join('');

    panel.setAttribute('aria-label', rows.map(function (row) {
        return (KPI_LABELS[row.M_NAME] || row.M_NAME) + ' ' + (Number(row.M_DATA) || 0);
    }).join(', ') + ' 막대그래프');
}


// 2. 금일 불량 테이블 렌더링
function defectTable(rows) {
    const tbody = document.querySelector('.defect-table tbody');
    if (!tbody) return;
    tbody.innerHTML = (rows || []).map(function (row, index) {
        return '<tr>'
            + '<td>' + (index + 1) + '</td>'
            + '<td>' + row.DEF_DUE + '</td>'
            + '<td>' + row.DEF_CST + '</td>'
            + '<td>' + row.DEF_ICD + '</td>'
            + '<td>' + row.DEF_INM + '</td>'
            + '<td><span class="process-chip">' + row.DEF_PRC + '</span></td>'
            + '<td>' + row.DEF_TP + '</td>'
            + '<td class="number">' + row.DEF_QTY + '</td>'
            + '<td>' + row.DEF_EMP + '</td>'
            + '</tr>';
    }).join('');
}

// 3. 비가동 유형 테이블 렌더링
function downtimeTable(rows) {
    const tbody = document.querySelector('.downtime-table tbody');
    if (!tbody) return;
    tbody.innerHTML = (rows || []).map(function (row, index) {
        return '<tr>'
            + '<td>' + (index + 1) + '</td>'
            + '<td>' + row.STP_TP + '</td>'
            + '<td>' + row.STP_NM + '</td>'
            + '<td>' + row.STP_TM + '</td>'
            + '<td>' + row.STP_EMP + '</td>'
            + '</tr>';
    }).join('');
}

// 4. 수주 리스트 렌더링
var ORDER_PAGE_SIZE = 10;
var ORDER_INTERVAL = 5000; // 1000 = 1초
var orderSlide = { pages: [], index: 0, timer: null, playing: true, animating: false };

function orderStop() {
    if (orderSlide.timer) {
        clearInterval(orderSlide.timer);
        orderSlide.timer = null;
    }
}
function orderStart() {
    orderStop();
    if (orderSlide.pages.length > 1 && orderSlide.playing) {
        orderSlide.timer = setInterval(function () {
            orderGoto(orderSlide.index + 1, 1);
        }, ORDER_INTERVAL);
    }
}
function orderGoto(index, dir) {
    const total = orderSlide.pages.length;
    if (!total || orderSlide.animating) return;
    orderSlide.index = ((index % total) + total) % total;
    renderOrderPage(orderSlide.pages[orderSlide.index], dir || 0);
    updateOrderNav();
}
function updateOrderNav() {
    const nav = document.querySelector('.orders-nav');
    if (!nav) return;
    nav.hidden = orderSlide.pages.length <= 1;
    const toggleBtn = nav.querySelector('[data-action="toggle"]');
    if (toggleBtn) {
        toggleBtn.classList.toggle('is-playing', orderSlide.playing);
        toggleBtn.setAttribute('aria-label', orderSlide.playing ? '일시정지' : '재생');
    }
    const current = nav.querySelector('.orders-nav-current');
    const total = nav.querySelector('.orders-nav-total');
    if (current) current.textContent = orderSlide.index + 1;
    if (total) total.textContent = orderSlide.pages.length;
}
$(document).on('click', '.orders-nav-btn', function () {
    const action = this.getAttribute('data-action');
    if (action === 'prev') {
        orderSlide.playing = false;
        orderStop();
        orderGoto(orderSlide.index - 1, -1);
    } else if (action === 'next') {
        orderSlide.playing = false;
        orderStop();
        orderGoto(orderSlide.index + 1, 1);
    } else if (action === 'toggle') {
        orderSlide.playing = !orderSlide.playing;
        updateOrderNav();
        if (orderSlide.playing) orderStart(); else orderStop();
    }
});

function orderListTable(rows) {
    orderStop();
    const list = rows || [];
    const pages = [];
    for (let i = 0; i < list.length; i += ORDER_PAGE_SIZE) {
        pages.push(list.slice(i, i + ORDER_PAGE_SIZE));
    }
    if (!pages.length) pages.push([]);

    orderSlide.pages = pages;
    orderSlide.index = 0;
    orderSlide.playing = true;

    renderOrderPage(pages[0]);
    updateOrderNav();
    orderStart();
}

function orderCardHtml(row) {
    return '<article class="order-card">'
        + '<header>'
        + '<h3>' + row.ORD_ITM + '</h3>'
        + '<p>' + row.ORD_CST + '</p>'
        + '</header>'
        + '<div class="order-body">'
        + '<div class="donut" style="--progress:' + row.ORD_PER + '"><span>' + row.ORD_PER + '<small>%</small></span></div>'
        + '<dl>'
        + '<div><dt>납기일자</dt><dd>' + row.ORD_DUE + '</dd></div>'
        + '<div><dt>수주량</dt><dd>' + row.ORD_QTY + '</dd></div>'
        + '<div><dt>포장수량</dt><dd class="accent-value">' + row.ORD_PRC + '</dd></div>'
        + '<div><dt>출하수량</dt><dd>' + row.ORD_SHP + '</dd></div>'
        + '</dl>'
        + '</div>'
        + '</article>';
}

function mountOrderCards(grid, rows) {
    grid.innerHTML = (rows || []).map(orderCardHtml).join('');

    // 카드 인터랙션 (동적 렌더링 이후 실행)
    const cards = grid.querySelectorAll('.order-card');
    if (!window.matchMedia('(prefers-reduced-motion: reduce)').matches) {
        cards.forEach(function (card, index) {
            card.animate(
                [
                    { opacity: 0, transform: 'translateY(7px)' },
                    { opacity: 1, transform: 'translateY(0)' }
                ],
                { duration: 280, delay: 40 + index * 24, easing: 'ease-out', fill: 'both' }
            );
        });
    }
}

// dir: 1 = 다음(왼쪽으로 슬라이드), -1 = 이전(오른쪽으로 슬라이드), 0/생략 = 애니메이션 없음
function renderOrderPage(rows, dir) {
    const grid = document.querySelector('.orders-grid');
    if (!grid) return;
    const reduceMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;

    if (!dir || reduceMotion) {
        mountOrderCards(grid, rows);
        return;
    }

    orderSlide.animating = true;
    const outAnim = grid.animate(
        [
            { transform: 'translateX(0)', opacity: 1 },
            { transform: 'translateX(' + (dir * -32) + 'px)', opacity: 0 }
        ],
        { duration: 180, easing: 'ease-in', fill: 'forwards' }
    );
    outAnim.onfinish = function () {
        mountOrderCards(grid, rows);
        const inAnim = grid.animate(
            [
                { transform: 'translateX(' + (dir * 32) + 'px)', opacity: 0 },
                { transform: 'translateX(0)', opacity: 1 }
            ],
            { duration: 220, easing: 'ease-out', fill: 'both' }
        );
        inAnim.onfinish = function () { orderSlide.animating = false; };
    };
}


$(function(){
    applyTheme(document.documentElement.getAttribute('data-theme') === 'light' ? 'light' : 'dark');
    timer();

    Maria();
});

var stores;

function Maria(){
    var maria = new ItsMaria('MONITORING', 'MONITOR');

    maria.CallProcCenter();

    if (maria.isError) {
        alert(maria.errMessage);
        return;
    }

    stores = maria.stores;

    // 렌더링 함수 호출
    //kpiData(stores[0].data[0].ODRQTY_MONTH, stores[0].data[0].GOODQTY_MONTH, stores[0].data[0].LEFTQTY_MONTH);  // 당월 수주량, 생산량, 미달성량
    kpiData(stores[0].data[0].M_DATA, stores[0].data[1].M_DATA, stores[0].data[2].M_DATA);
    renderDefectChart(stores[0].data);
    defectTable(stores[1].data);    // 금일 불량
    downtimeTable(stores[2].data);  // 금일 비가동
    orderListTable(stores[3].data); // 수주현황

    setTimeout(Maria, 10 * 1000);
}