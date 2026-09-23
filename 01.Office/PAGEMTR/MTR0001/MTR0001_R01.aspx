<%--발주등록--%>
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="MTR0001_R01.aspx.cs" Inherits="MTR0001_R01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="MTR0001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <style type="text/css">
        #lbl_TITLE6 { color: magenta; }
        #lbl_TITLE7 { color: orange; }
    </style>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="발주일자" FieldFrom="SDATE" FieldTo="EDATE" ID="date_DATE" />
        <Its:combo runat="server" Label="법인" ID="sdiv1_combo_COMPANYCD" Field="COMPANYCD" GPCD="*COMPANYCD" InputWidth="148"/> 
        <Its:combo runat="server" Label="공장" ID="sdiv1_combo_FACTORYCD" Field="FACTORYCD" GPCD="*FACTORYCD" InputWidth="120"/>
        <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" InputWidth="60" NameWidth="190" REF02="Y" />
        <Its:newline runat="server" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" >
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight" >
        <Its:grid runat="server" ID="grid2" />
    </Its:div>
</asp:Content>

