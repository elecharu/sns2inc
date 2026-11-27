<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpcMonitor.aspx.cs" Inherits="SpcMonitor" %>
<%-- SPC 모니터링(자주검사) (로그인 화면 [SPC 모니터링(자주검사)] 선택 → 새 창). 프로시저 SPCMONITOR
     SpcMonitor.aspx          : SPC 모니터링 라인 전체, 특성 있는 SPC 관리항목만
     SpcMonitor.aspx?EQMCD=.. : 라인을 클릭하면 새 창, 그 라인 생산품의 SPC 관리항목 전체 --%>
<!DOCTYPE html>
<html lang="ko">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>S&S 2공장 SPC 모니터링(자주검사)</title>
    <link rel="icon" type="image/png" href="./images/fav.png" />
    <link rel="stylesheet" type="text/css" href="./css/SpcMonitor.css?ver=<%= BasePage.srcVersion %>" />
    <script type="text/javascript" src="../../UserControl/ItsPage.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../../UserControl/ItsMaria.js?ver=<%= BasePage.srcVersion %>"></script>
    <script type="text/javascript" src="../js/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="./js/SpcMonitor.js?ver=<%= BasePage.srcVersion %>"></script>
</head>
<body>
    <div class="spc-wrap">
        <header class="spc-header">
            <h1 id="spc_title">S&amp;S 2공장 SPC 모니터링(자주검사)</h1>
            <div class="spc-status" id="spc_status"></div>
            <div class="spc-legend">
                <span><i class="lg-pt"></i>검사값</span>
                <span><i class="lg-ctl"></i>관리한계 이탈</span>
                <span><i class="lg-spec"></i>규격 이탈</span>
            </div>
            <%-- 라인 카드가 한 화면에 다 안 들어가면 자동으로 페이지를 넘긴다 (라인 창에서는 숨김) --%>
            <div class="spc-page" id="spc_page" hidden>
                <button type="button" id="btn_prev" title="이전 페이지">◀</button>
                <span id="page_no">1 / 1</span>
                <button type="button" id="btn_next" title="다음 페이지">▶</button>
                <button type="button" id="btn_pause">멈춤</button>
                <span class="page-sec" id="page_sec"></span>
            </div>
            <button type="button" id="btn_mode">히스토그램 보기</button>
            <div class="spc-clock">현재시간 <span id="spc_clock"></span></div>
        </header>

        <div class="spc-body" id="spc_body"></div>
    </div>
</body>
</html>
