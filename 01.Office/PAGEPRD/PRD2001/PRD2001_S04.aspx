<%-- PRD2001_S04: 생산관리 ▶ 생산계획대비 생산실적조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD2001_S04.aspx.cs" Inherits="PRD2001_S04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD2001_S04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:month runat="server" Label="조회년월(월간)" Field="SMONTH" ID="sdiv1_mon_SMONTH" />
        <Its:dateRange runat="server" Label="조회일자(주간)" FieldFrom="SDATE" FieldTo="EDATE" ID="dateR" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
        <Its:combo runat="server" Label="공정" ID="cmb_PRCCD" Field="PRCCD" GPCD="*PRCCD_LINE" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMCD" Field="EQMCD" GPCD="*EQMCD_LINE" />
        <Its:combo runat="server" Label="공장" ID="cmb_FACTORYCD" Field="FACTORYCD" GPCD="FACTORYCD" InputWidth="120"/>
        <Its:find runat="server" Label="품목코드" Field="ITEMID" GPCD="ITEMID" ID="sdiv1_find_ITEMID" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1">
        <Its:div runat="server" Type="SplitSingle" TabTitle="월간">
            <Its:grid runat="server" ID="grid_MONTH" />
        </Its:div>
        <Its:div runat="server" Type="SplitSingle" TabTitle="주간">
            <Its:grid runat="server" ID="grid_WEEK" />
        </Its:div>
    </Its:tab>
</asp:Content>
