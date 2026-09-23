<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD0001_S03.aspx.cs" Inherits="PRD0001_S03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD0001_S03.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>                                               <%-- 네이버 차트 라이브러리는 d3.js 기반 --%>
    <script type="text/javascript" src="../../Script/billboardjs/billboard.min.js?ver=1.0"></script>    <%-- 차트 라이브러리 --%>
    <link rel="stylesheet" href="../../Script/billboardjs/billboard.min.css?ver=1.0"/>
    <link rel="stylesheet" href="../../Script/billboardjs/insight.min.css?ver=1.0"/>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="조회년도" ID="cmb_SYEAR" Field="SYEAR" GPCD="YEAR" REF01="-5" REF02="0" />
        <Its:combo runat="server" Label="공정코드" ID="cmb_PRCCD" Field="PRCCD" GPCD="PRCCD" Required="true"/>
        <%--<Its:combo runat="server" Label="품목분류" ID="cmb_ITEMCG3" Field="ITEMCG3" GPCD="ITEMCG3" />--%>
        <Its:check runat="server" Label="차트라벨" ID="chk_LABELCHK" Field="LABELCHK" Value="N" MarginLeft="25"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop">
        <Its:div runat="server" Type="SplitLeft">
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