<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrdMonitor.aspx.cs" Inherits="PrdMonitor" %>
<%-- 생산 모니터링 (로그인 화면 [생산 모니터링] 선택 → 새 창). 프로시저 PRDMONITOR --%>
<!DOCTYPE html>
<html lang="ko">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>S&S 2공장 생산 모니터링</title>
    <link rel="icon" type="image/png" href="./images/fav.png" />
    <link rel="stylesheet" type="text/css" href="./css/PrdMonitor.css?ver=<%= BasePage.srcVersion %>" />
    <script type="text/javascript" src="../../UserControl/ItsPage.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../UserControl/ItsMaria.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../js/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="./js/PrdMonitor.js?ver=<%= BasePage.srcVersion %>"></script>
</head>
<body>
    <div class="mon-wrap">
        <header class="mon-header">
            <h1>S&amp;S 2공장 생산 모니터링</h1>
            <div class="mon-status" id="mon_status"></div>
            <div class="mon-clock">현재시간 <span id="mon_clock"></span></div>
        </header>

        <div class="mon-body">
            <!-- 왼쪽 : 판매실적 / 계획대비 실적 / 월별 불량 PPM -->
            <div class="mon-left">
                <div class="mon-left-top">
                    <section class="mon-panel">
                        <h2 id="sal_chart_title">판매실적(단위:백만원)</h2>
                        <div class="mon-legend">
                            <span><i class="lg-plan"></i>목표</span>
                            <span><i class="lg-rst"></i>실적</span>
                        </div>
                        <div class="mon-chart" id="sal_chart"></div>
                    </section>

                    <section class="mon-panel">
                        <h2 id="sal_table_title">계획대비 실적(단위:백만원)</h2>
                        <table class="mon-table sal-table">
                            <thead>
                                <tr><th>구분</th><th>판매계획</th><th>출하실적</th><th>진도율(%)</th></tr>
                            </thead>
                            <tbody id="sal_table"></tbody>
                        </table>
                    </section>
                </div>

                <section class="mon-panel mon-ppm">
                    <div class="ppm-head">
                        <h2 class="ppm-title" id="ppm_title">월별불량현황(PPM)</h2>
                        <div class="mon-legend">
                            <span><i class="lg-target"></i>목표 PPM <b id="ppm_target"></b></span>
                            <button type="button" id="btn_ppm_edit">목표 입력</button>
                            <span class="ppm-edit" id="ppm_edit">
                                <input type="text" id="txt_ppm" inputmode="decimal" />
                                <button type="button" id="btn_ppm_save">저장</button>
                                <button type="button" id="btn_ppm_cancel">취소</button>
                            </span>
                        </div>
                    </div>
                    <div class="mon-chart" id="ppm_chart"></div>
                </section>
            </div>

            <!-- 오른쪽 : 생산/설비가동현황 -->
            <section class="mon-panel mon-right">
                <h2 id="line_title">생산/설비가동현황</h2>
                <div class="line-scroll">
                    <table class="mon-table line-table">
                        <thead>
                            <tr>
                                <th>라인명</th><th>ITEM</th><th>목표수량</th><th>생산수량</th>
                                <th>목표 달성율</th><th>가동상태</th><th>시간 가동율</th>
                            </tr>
                        </thead>
                        <tbody id="line_table"></tbody>
                    </table>
                </div>
                <table class="mon-table line-table line-foot">
                    <tbody>
                        <tr>
                            <td>합계</td><td></td><td id="sum_plan"></td><td id="sum_good"></td>
                            <td id="avg_rate"></td><td></td><td id="avg_time"></td>
                        </tr>
                    </tbody>
                </table>
            </section>
        </div>
    </div>
</body>
</html>
