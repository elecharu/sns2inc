<%-- EQM1001_R06: 생산기술팀 ▶ 설비고장/수리 ▷ 년 설비고장율 현황 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R06.aspx.cs" Inherits="EQM1001_R06" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R06.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>                                               <%-- 네이버 차트 라이브러리는 d3.js 기반 --%>
    <script type="text/javascript" src="../../Script/billboardjs/billboard.min.js?ver=1.0"></script>    <%-- 차트 라이브러리 --%>
    <link rel="stylesheet" href="../../Script/billboardjs/billboard.min.css?ver=1.0"/>
    <link rel="stylesheet" href="../../Script/billboardjs/insight.min.css?ver=1.0"/>
    <style>
        #chart1 text, #chart2 text { font-size: 13px; }
        #chart1 .bb-title, #chart2 .bb-title { font-size: 16px; font-weight: bold; }
        .chart-box { position: relative; height: 100%; }
        .chart-legend { position: absolute; top: 4px; right: 70px; z-index: 1; padding: 3px 6px; border: 1px solid #999; background: #fff; font-size: 13px; }
        .chart-legend > span { display: inline-flex; align-items: center; margin: 0 8px; cursor: pointer; }
        .chart-legend svg { margin-right: 6px; }
        #chart1 .bb-target-NONRATE .bb-line, #chart1 .bb-target-GOALRATE .bb-line, #chart2 .bb-target-AVGREPMIN .bb-line { stroke-dasharray: 4 3; }
        #chart1 .bb-target-GOALRATE .bb-circle { fill: #fff !important; }
        #chart1 .bb-bar, #chart2 .bb-bar { cursor: pointer; }
        #MAIN_BODY { position: relative; }
        #div_TOPISSUE { display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; z-index: 10; overflow-y: auto; padding: 10px 20px; background: #fff; }
        .topissue-title { display: inline-block; margin: 6px 0 4px 0; font-size: 22px; }
        .topissue-table { width: 100%; margin-top: 18px; border-collapse: collapse; font-size: 13px; }
        .topissue-table th, .topissue-table td { padding: 6px; border: 1px solid #bbb; text-align: center; }
        .topissue-table th { background: #efebe0; font-weight: normal; }
        .topissue-table td { height: 60px; }
        .topissue-table td.text { text-align: left; }
        .topissue-table { cursor: pointer; }
        .topissue-table:hover td { background: #f7f5ee; }
        .topissue-detail { display: none; padding: 12px 0 4px 0; }
        .topissue-detail-inner { display: flex; gap: 14px; font-size: 14px; }
        .topissue-detail-col { display: flex; flex-direction: column; }
        .topissue-detail-head { align-self: flex-start; padding: 6px 28px; background: #a39a6b; color: #fff; font-size: 15px; }
        .topissue-detail-box { flex: 1; margin-top: 6px; padding: 10px 14px; border: 1px solid #ccc; line-height: 1.9; }
        .topissue-detail-box .item:before { content: '✓ '; }
        .topissue-detail-box .problem { padding: 0 4px; background: #000; color: #fff; }
        .topissue-detail-box .sub { padding-left: 16px; }
        .topissue-photo { display: flex; flex-wrap: wrap; gap: 4px; align-content: flex-start; }
        .topissue-photo img { width: calc(50% - 2px); height: 120px; object-fit: cover; border: 1px solid #ccc; }
        .topissue-photo .empty { margin: auto; color: #999; }
        .topissue-detail-headrow { position: relative; display: flex; justify-content: center; }
        .topissue-edit { position: absolute; right: 0; bottom: 0; padding: 3px 14px; border: 1px solid #a39a6b; color: #6f6640; background: #fff; cursor: pointer; }
        .topissue-edit:hover { background: #f7f5ee; }
        #pop1_IMGLIST { display: flex; flex-wrap: wrap; gap: 6px; margin: 6px 0 0 82px; }
        #pop1_IMGLIST .item { position: relative; }
        #pop1_IMGLIST img { width: 140px; height: 105px; object-fit: cover; border: 1px solid #ccc; }
        #pop1_IMGLIST .del { position: absolute; top: 2px; right: 2px; width: 20px; height: 20px; line-height: 20px; text-align: center; background: rgba(0,0,0,0.6); color: #fff; cursor: pointer; }
        #pop1_IMGLIST .empty { color: #999; }
    </style>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="조회년도" ID="cmb_SYEAR" Field="SYEAR" GPCD="YEAR" REF01="-5" REF02="0" />    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <%-- 설비 고장율 (비가동시간 + 점유율) --%>
    <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
        <div class="chart-box">
            <div id="chart1_legend" class="chart-legend"></div>
            <div id="chart1" style="height: 100%;"></div>
        </div>
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <%-- 설비 호출건수 (호출건수 + 평균수리시간) --%>
    <Its:div runat="server" Type="SplitDown">
        <div class="chart-box">
            <div id="chart2_legend" class="chart-legend"></div>
            <div id="chart2" style="height: 100%;"></div>
        </div>
    </Its:div>

    <%-- 설비 고장 TOP ISSUE (월 막대 클릭 시 차트 위에 표시) --%>
    <div id="div_TOPISSUE">
        <span id="lbl_TOPISSUE" class="topissue-title"></span>
        <Its:button runat="server" Label="◀ 그래프로" ID="btn_BACK" Width="100" Float="right" MarginTop="6" BackColor="CustomButton2" />
        <div id="div_TOPLIST"></div>
    </div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <%-- TOP ISSUE 원인 및 예방 / 사진 (설비 + 년월) --%>
    <Its:pop runat="server" Type="add" ID="pop1" Title="TOP ISSUE 원인 및 예방" Width="760" Height="620" AddBtnName="저장">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:text runat="server" Label="설비" ID="pop1_txt_EQMNM" Field="EQMNM" InputWidth="400" ReadOnly="true" />
            <Its:text runat="server" Label="년월" ID="pop1_txt_YM" Field="YM" InputWidth="80" ReadOnly="true" />
            <Its:text runat="server" Label="설비코드" ID="pop1_txt_EQMCD" Field="EQMCD" Hidden="true" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="원인" ID="pop1_txtarea_CAUSE" Field="CAUSE" InputWidth="620" InputHeight="130" />
            <Its:newline runat="server" />
            <Its:textarea runat="server" Label="예방" ID="pop1_txtarea_PREVENT" Field="PREVENT" InputWidth="620" InputHeight="130" />
            <Its:newline runat="server" />
            <Its:button runat="server" Label="원인·예방 삭제" ID="pop1_btn_DEL" Width="120" Float="right" MarginRight="10" BackColor="CustomButton3" />
            <Its:newline runat="server" />
            <%-- 사진은 선택하면 바로 업로드·등록 --%>
            <Its:fileManager runat="server" StyleType="simple" FileType="image" ID="pop1_file_IMG" MarginLeft="82" />
            <div id="pop1_IMGLIST"></div>
        </Its:div>
    </Its:pop>
</asp:Content>
