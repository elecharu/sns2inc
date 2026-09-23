<%-- TQM0901_S03: 품질관리 ▶ 지표관리 ▷ 월별 불량현황 조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM0001_R01.aspx.cs" Inherits="EQM0001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM0001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>                                               <%-- 네이버 차트 라이브러리는 d3.js 기반 --%>
    <script type="text/javascript" src="../../Script/billboardjs/billboard.min.js?ver=1.0"></script>    <%-- 차트 라이브러리 --%>
    <link rel="stylesheet" href="../../Script/billboardjs/billboard.min.css?ver=1.0"/>
    <link rel="stylesheet" href="../../Script/billboardjs/insight.min.css?ver=1.0"/>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="생산일자" ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMTP" Field="*ITEMTP" GPCD="ITEMTP" />
        <Its:find runat="server" Label="품목코드" ID="find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="38.5">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid2" />
    </Its:div>

</asp:Content>