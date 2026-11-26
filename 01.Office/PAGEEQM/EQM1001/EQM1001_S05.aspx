<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_S05.aspx.cs" Inherits="EQM1001_S05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_S05.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>
    <script type="text/javascript" src="../../Script/billboardjs/billboard.min.js?ver=1.0"></script>
    <link rel="stylesheet" href="../../Script/billboardjs/billboard.min.css?ver=1.0"/>
    <link rel="stylesheet" href="../../Script/billboardjs/insight.min.css?ver=1.0"/>
    <style>
        .chart-box text { font-size: 13px; }
        .chart-box .bb-title { font-size: 16px; font-weight: bold; }
        .chart-box .bb-target-NONRATE .bb-line, .chart-box .bb-target-GOALRATE .bb-line { stroke-dasharray: 4 3; }
        .chart-box .bb-target-GOALRATE .bb-circle { fill: #fff !important; }
        .chart-box .bb-texts-NONHR text { fill: #000 !important; font-weight: bold; }
        .chart-box .bb-bar { stroke: #7F7F7F !important; stroke-width: 1px; }
        .chart-box { position: relative; height: 100%; }
        .chart-legend { position: absolute; top: 34px; right: 70px; z-index: 1; padding: 3px 6px; border: 1px solid #999; background: #fff; font-size: 13px; white-space: nowrap; }
        .chart-legend > span { display: inline-flex; align-items: center; margin: 0 8px; cursor: default !important; }
        .chart-legend svg { margin-right: 6px; }
        .part-box { height: 100%; overflow-y: auto; padding: 6px 10px; box-sizing: border-box; }
        .part-title { margin: 4px 0 10px 0; text-align: center; font-size: 16px; font-weight: bold; }
        .part-list { display: flex; flex-wrap: wrap; gap: 10px; }
        .part-item { width: 380px; }
        .part-legend { display: flex; flex-wrap: wrap; justify-content: center; gap: 2px 10px; min-height: 22px; font-size: 12px; }
        .part-legend > span { display: inline-flex; align-items: center; white-space: nowrap; cursor: default !important; }
        .part-legend svg { margin-right: 3px; }
        .part-chart { height: 300px; }
        .part-chart .bb-chart-arc path { stroke: #7F7F7F !important; stroke-width: 1px; }
        .part-chart .bb-chart-arc text { fill: #000 !important; font-size: 12px; font-weight: bold; }
        .part-name { text-align: center; font-size: 13px; font-weight: bold; white-space: pre-line; }
    </style>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="조회년도" ID="cmb_SYEAR" Field="SYEAR" GPCD="YEAR" REF01="-4" REF02="0" />
        <Its:combo runat="server" Label="작업장" Field="LINECD" ID="cmb_LINECD" REF01="07" GPCD="@LINECD" />
        <Its:combo runat="server" Label="공정" Field="EQMTP" ID="cmb_EQMTP" GPCD="@EQMTP" />
        <Its:combo runat="server" Label="라인" Field="EQMGROUP1" ID="cmb_EQMGROUP1" GPCD="@EQMGROUP1" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1">
        <Its:div runat="server" Type="SplitSingle" TabTitle="연간 고장 목표대비 달성">
            <div class="chart-box">
                <div id="chart1_legend" class="chart-legend"></div>
                <div id="chart1" style="height: 100%;"></div>
            </div>
        </Its:div>

        <Its:div runat="server" Type="SplitSingle" TabTitle="설비별 고장현황">
            <div class="chart-box">
                <div id="chart2_legend" class="chart-legend"></div>
                <div id="chart2" style="height: 100%;"></div>
            </div>
        </Its:div>

        <Its:div runat="server" Type="SplitSingle" TabTitle="설비별 부품별 현황">
            <div id="div_PART" class="part-box"></div>
        </Its:div>
    </Its:tab>
</asp:Content>
