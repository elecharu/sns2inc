

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD1001_R03.aspx.cs" Inherits="PRD1001_R03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD1001_R03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_CUSTOM_BUTTON" runat="server">
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">        
        <Its:date runat="server" Label="조회일자" Field="SDATE" ID="date_SDATE" ReadOnly="true"/>
        <Its:date runat="server" Label="" Field="EDATE" ID="date_EDATE" LabelWidth="0"/>
        <%--<Its:combo runat="server" Label="법인" InputWidth="130" Field="COMPANYCD" GPCD="COMPANYCD" ID="sdiv1_cmb_COMPANYCD" />--%>
        <Its:combo runat="server" Label="공장" Field="FACTORYCD" GPCD="FACTORYCD" ID="sdiv1_cmb_FACTORYCD" ReadOnly="true" Value="07"/>        
        <Its:find runat="server" Label="품목코드" Field="ITEMID" GPCD="ITEMID" ID="sdiv1_find_ITEMID" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>
