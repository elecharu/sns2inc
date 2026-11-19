<%-- SAL3002_S04: 영업관리 ▶ 출하실적조회 (출하 LOT 별) --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SAL3002_S04.aspx.cs" Inherits="SAL3002_S04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SAL3002_S04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="출하일자" ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="구분" ID="cmb_DEBC" Field="DEBC" GPCD="*SD300" />
        <Its:find runat="server" Label="고객사" ID="find_CUSTCD" Field="CUSTCD" REF01="60" GPCD="CUSTCD_COMPANY" />
        <Its:find runat="server" Label="품목" ID="find_ITEMID" Field="ITEMID" GPCD="ITEMID" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>
