<%-- TQM0901_S03: 품질관리 ▶ 지표관리 ▷ 월별 불량현황 조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM0901_S02.aspx.cs" Inherits="TQM0901_S02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM0901_S02.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>                                               <%-- 네이버 차트 라이브러리는 d3.js 기반 --%>
    <script type="text/javascript" src="../../Script/billboardjs/billboard.min.js?ver=1.0"></script>    <%-- 차트 라이브러리 --%>
    <link rel="stylesheet" href="../../Script/billboardjs/billboard.min.css?ver=1.0"/>
    <link rel="stylesheet" href="../../Script/billboardjs/insight.min.css?ver=1.0"/>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:month runat="server" Label="조회년월" ID="month_SMONTH" Field="SMONTH" />
        <Its:combo runat="server" Label="공정코드" ID="cmb_PRCCD" Field="PRCCD" GPCD="*PRCCD" />
        <Its:combo runat="server" Label="품목분류" ID="cmb_ITEMTP" Field="ITEMTP" GPCD="*ITEMTP" />
        <Its:display runat="server" Label="" LabelWidth="0" InputWidth="14" />
        <Its:check runat="server" Label="차트라벨" ID="chk_LABELCHK" Field="LABELCHK" Value="N" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop">
        <div id="chart1"></div>
    </Its:div>
    <Its:split runat="server" Type="Horizon" />
    <Its:div runat="server" Type="SplitDown">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>