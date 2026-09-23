<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Monitoring.aspx.cs" Inherits="Monitoring" %>

<!doctype html>
<html lang="ko">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <script>
    (function () {
      try {
        var saved = localStorage.getItem('theme');
        var theme = saved === 'light' || saved === 'dark' ? saved : (window.matchMedia('(prefers-color-scheme: light)').matches ? 'light' : 'dark');
        document.documentElement.setAttribute('data-theme', theme);
      } catch (e) {}
    })();
  </script>
  <title>S&S 2공장 제조 모니터링</title>
  <meta name="description" content="S&S 2공장 제조 현황과 공정별 불량, 수주 진행 상태를 보여주는 제조 모니터링 화면" />
  <meta name="author" content="ALPHANICS" />
  <meta property="og:title" content="ALPHANICS 제조 모니터링" />
  <meta property="og:description" content="S&S 2공장 제조 현황과 공정별 불량, 수주 진행 상태를 보여주는 제조 모니터링 화면" />
  <meta property="og:type" content="website" />
  <meta name="twitter:card" content="summary" />
  <meta name="twitter:title" content="ALPHANICS 제조 모니터링" />
  <meta name="twitter:description" content="S&S 2공장 제조 현황과 공정별 불량, 수주 진행 상태를 보여주는 제조 모니터링 화면" />

  <link rel="icon" type="image/png" href="./images/fav.png" />
  <script src="./js/jquery.js"></script>
  <script type="module" src="./js/main.js"></script>
  <script id="structured-data-jsonld" type="application/ld+json">{"@context":"https://schema.org","@type":"WebSite","name":"ALPHANICS 제조 모니터링","description":"S&S 2공장 제조 현황과 공정별 불량, 수주 진행 상태를 보여주는 제조 모니터링 화면","url":"__SITE_URL__"}</script>
  <link rel="stylesheet" href="./css/styles.css" />

  <script src="../../UserControl/ItsMaria_Monitor.js?ver=<%= BasePage.srcVersion %>"></script>
</head>
<body>
  <main class="monitoring-shell">
    <header class="top-header">
      <div class="brand" aria-label="ALPHANICS ALPHA">
        <div class="brand-arc">ALPHANICS</div>
        <div class="brand-core">ALPHA</div>
      </div>
      <!-- 당월 KPI - 상단 헤더 3개 항목 -->
      <section class="kpi-group" aria-label="당월 주요 지표">
        <article class="kpi-card">
          <div class="kpi-label">당월수주량</div>
          <div class="kpi-value" data-name="M_ORD"></div>
        </article>
        <article class="kpi-card">
          <div class="kpi-label">당월생산량</div>
          <div class="kpi-value" data-name="M_PROD"></div>
        </article>
        <article class="kpi-card">
          <div class="kpi-label">당월 미달성</div>
          <div class="kpi-value" data-name="M_UNPRD"></div>
        </article>
      </section>

      <div class="datetime" aria-label="조회 기준 시각">
        <button class="theme-toggle" type="button" aria-label="라이트/다크 모드 전환" aria-pressed="false">
          <svg class="theme-icon theme-icon-sun" viewBox="0 0 24 24" aria-hidden="true"><circle cx="12" cy="12" r="4.5"></circle><path d="M12 2.5v2.4M12 19.1v2.4M4.2 4.2l1.7 1.7M18.1 18.1l1.7 1.7M2.5 12h2.4M19.1 12h2.4M4.2 19.8l1.7-1.7M18.1 5.9l1.7-1.7"></path></svg>
          <svg class="theme-icon theme-icon-moon" viewBox="0 0 24 24" aria-hidden="true"><path d="M20 14.5A8.5 8.5 0 1 1 9.5 4a6.8 6.8 0 0 0 10.5 10.5Z"></path></svg>
        </button>
        <svg class="search-icon" viewBox="0 0 24 24" aria-hidden="true"><circle cx="11" cy="11" r="6.5"></circle><path d="m16 16 4.3 4.3"></path></svg>
        <span id="currentDate"></span><span id="currentTime"></span>
      </div>
    </header>

    <!-- 수주대비 생산량 막대그래프 -->
    <section class="quality-grid">
      <article class="dashboard-section chart-section">
        <header class="section-heading">
          <h1>수주대비 생산량</h1>
          <div class="section-line"></div>
        </header>
        <div class="chart-panel" role="img">
          <div class="y-axis" aria-hidden="true"><span>10,000</span><span>9,000</span><span>8,000</span><span>7,000</span><span>6,000</span><span>5,000</span><span>4,000</span><span>3,000</span><span>2,000</span><span>1,000</span><span>0</span></div>
          <div class="plot-area">
            <div class="grid-lines" aria-hidden="true"><i></i><i></i><i></i><i></i><i></i><i></i></div>
            <div class="bars">
            </div>
          </div>
        </div>
      </article>

      <div class="defect-col">
        <!-- 금일 불량 - 테이블 -->
        <article class="dashboard-section defect-section">
          <header class="section-heading">
            <h2>금일 불량</h2>
            <div class="section-line"></div>
          </header>
          <div class="table-panel">
            <table class="defect-table">
              <thead>
                <tr>
                  <th>순번</th>
                  <th>납기일자</th>
                  <th>거래처</th>
                  <th>품목코드</th>
                  <th>품명</th>
                  <th>공정</th>
                  <th>불량유형</th>
                  <th>불량수량</th>
                  <th>작업자</th>
                </tr>
              </thead>
              <tbody>
              </tbody>
            </table>
          </div>
        </article>

        <!-- 비가동 유형 - 테이블 -->
        <article class="dashboard-section downtime-section">
          <header class="section-heading">
            <h2>비가동유형</h2>
            <div class="section-line"></div>
          </header>
          <div class="table-panel downtime-table-panel">
            <table class="downtime-table">
              <thead>
                <tr>
                  <th>순번</th>
                  <th>비가동유형</th>
                  <th>설비명</th>
                  <th>시작시간</th>
                  <th>등록자</th>
                </tr>
              </thead>
              <tbody>
                <tr><td>1</td><td>-</td><td>-</td><td>-</td><td>-</td></tr>
                <tr><td>2</td><td>-</td><td>-</td><td>-</td><td>-</td></tr>
                <tr><td>3</td><td>-</td><td>-</td><td>-</td><td>-</td></tr>
              </tbody>
            </table>
          </div>
        </article>
      </div>
    </section>

    <!-- 수주 리스트 -->
    <section class="orders-section">
      <header class="section-heading orders-heading">
        <h2>수주 리스트</h2>
        <div class="section-line"></div>
        <div class="orders-nav" hidden>
          <button class="orders-nav-btn" type="button" data-action="prev" aria-label="이전 페이지">‹</button>
          <button class="orders-nav-btn is-playing" type="button" data-action="toggle" aria-label="일시정지">
            <svg class="nav-icon icon-pause" viewBox="0 0 24 24" aria-hidden="true"><rect x="6" y="5" width="4" height="14" rx="1"/><rect x="14" y="5" width="4" height="14" rx="1"/></svg>
            <svg class="nav-icon icon-play" viewBox="0 0 24 24" aria-hidden="true"><path d="M7 5.5v13l11-6.5-11-6.5z"/></svg>
          </button>
          <button class="orders-nav-btn" type="button" data-action="next" aria-label="다음 페이지">›</button>
          <span class="orders-nav-page"><em class="orders-nav-current">1</em><i class="orders-nav-sep">/</i><em class="orders-nav-total">1</em></span>
        </div>
      </header>
      <div class="orders-grid"></div>
    </section>
  </main>
</body>
</html>

