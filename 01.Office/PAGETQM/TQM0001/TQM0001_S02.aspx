<%-- TQC6001_S05: 품질관리 - 지표관리 - 불량추이 유형분석 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM0001_S02.aspx.cs" Inherits="TQM0001_S02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM0001_S02.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>                                               <%-- 네이버 차트 라이브러리는 d3.js 기반 --%>
    <script type="text/javascript" src="../../Script/billboardjs/billboard.min.js?ver=1.0"></script>    <%-- 차트 라이브러리 --%>
    <link rel="stylesheet" href="../../Script/billboardjs/billboard.min.css?ver=1.0"/>
    <link rel="stylesheet" href="../../Script/billboardjs/insight.min.css?ver=1.0"/></asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:div runat="server" Type="BasicFloat">
            <Its:dateRange runat="server" Label="조회기간" FieldFrom="SDATE" FieldTo="EDATE" />
        </Its:div>
        <Its:div runat="server" Type="BasicFloat">        
            <Its:combo runat="server" Label="공정코드" ID="cmb_PRCCD" Field="PRCCD" GPCD="*PRCCD" />
            <Its:combo runat="server" Label="구분" ID="cmb_PCT_TYPE" Field="PCT_TYPE" GPCD="SELECT 'PPM', 'PPM' UNION SELECT '%', 'PERCE'" Value="PPM" />
            <Its:num runat="server" Label="목표치" Field="GOAL" ID="num_GOAL" TriggerButton="false" />
            <Its:check runat="server" Label="차트라벨" ID="chk_LABELCHK" Field="LABELCHK" Value="N" MarginLeft="38" />
        </Its:div>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" TopHeightPc="45">
        <Its:div runat="server" Type="SplitLeft" LeftWidthPc="67">
            <div id="chart1"></div>
        </Its:div>
        <Its:split runat="server" Type="Vertical" />
        <Its:div runat="server" Type="SplitRight">
            <div id="chart2"></div>
        </Its:div>
    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>