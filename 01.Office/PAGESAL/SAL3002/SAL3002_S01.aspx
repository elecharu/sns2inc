<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SAL3002_S01.aspx.cs" Inherits="SAL3002_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SAL3002_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:month runat="server" Label="수주기간" LabelWidth="120" Field="MONTH" ID="date_SDATE" />
        <Its:combo runat="server" Label="법인" ID="sdiv1_combo_COMPANYCD" InputWidth="150" Field="COMPANYCD" GPCD="*COMPANYCD" />
        <Its:combo runat="server" Label="사업장" Field="BDVCD" GPCD="*BDVCD" ID="sdiv1_combo_BDVCD" InputWidth="150"/>   
        <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" ID="sdiv1_find_CUSTCD"/>        
        <Its:text runat="server" Label="수주번호(*)" Field="SALODRKEY" ID="sdiv1_text_SALODRKEY" InputWidth="112"/>   
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="30">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid2" />
    </Its:div>
</asp:Content>