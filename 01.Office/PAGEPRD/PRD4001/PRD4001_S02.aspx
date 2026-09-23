<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD4001_S02.aspx.cs" Inherits="PRD4001_S02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD4001_S02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="법인" ID="sdiv1_combo_COMPANYCD" Field="COMPANYCD" GPCD="*COMPANYCD" InputWidth="148"/> 
        <Its:combo runat="server" Label="공장" ID="sdiv1_combo_FACTORYCD" Field="FACTORYCD" GPCD="*FACTORYCD" InputWidth="120"/>
        <Its:text runat="server" Label="LOT번호(*)" Field="LOTKEY" ID="txt_LOTKEY"/>
        <Its:text runat="server" Label="관리번호(*)" Field="KEYWORD" ID="sdiv1_text_KEYWORD"/>
        <Its:newline runat="server" />
        <Its:combo runat="server" Label="창고" Field="WARECD" ID="sdiv1_find_WARECD" GPCD="*WARECD" InputWidth="120"/> 
        <Its:find runat="server" Label="품목" Field="ITEMID" ID="sdiv1_find_ITEMID" InputWidth="120" NameWidth="120" GPCD="ITEMID" LabelWidth="91"/>       
        <Its:combo runat="server" Label="품목유형" Field="ITEMCG" ID="sdiv1_find_ITEMCG" GPCD="*DM100" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle" LeftWidthPc="70">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>