<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST3001_R04.aspx.cs" Inherits="MST3001_R04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST3001_R04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="법인" ID="cmb_COMPANYCD" Field="COMPANYCD" GPCD="*COMPANYCD" InputWidth="120" ReadOnly="true"/>
        <Its:combo runat="server" Label="공장" ID="cmb_FACTORYCD" Field="FACTORYCD" GPCD="*FACTORYCD" InputWidth="120" ReadOnly="true"/>
        <Its:combo runat="server" Label="품목유형" ID="sdiv1_combo_ITEMCG" Field="ITEMCG" GPCD="DM100" Value="DM100750" ReadOnly="true"/>
        <Its:find runat="server" Label="품목" ID="sdiv1_find_ITEMID" Field="ITEMID" GPCD="ITEMID" REF02="DM100750" REF03="07"/>
        <Its:check runat="server" Label="종료 여부" ID="sdiv1_check_ENDYN" Field="ENDYN" Value="N"/>
        <Its:label runat="server" Text="안전재고 미만 (현재고가 안전재고보다 적음)" BackColorHex="Pink" MarginLeft="20"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>
