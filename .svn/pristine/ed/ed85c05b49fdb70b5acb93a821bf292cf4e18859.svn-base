<%-- 기준관리 ▶ 기준관리 ▷ 거래처정보 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1000_R05.aspx.cs" Inherits="MST1000_R05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1000_R05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="법인" Field="COMPANYCD"  GPCD="*COMPANYCD" Value="60" InputWidth="200"/>
        <Its:combo runat="server" Label="거래처구분" Field="CUSTTP"  GPCD="*BC500"/>
        <Its:combo runat="server" Label="거래처형태" Field="CUST_KD"  GPCD="*BC510"/>
        <Its:text runat="server" Label="거래처명(*)" ID="sdiv1_text_CUSTNM" Field="CUSTNM" InputWidth="150"/>
        <Its:check runat="server" Label="사용여부" Field="USEYN" Value="Y" MarginLeft="20"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle" TopHeightPc="50">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>