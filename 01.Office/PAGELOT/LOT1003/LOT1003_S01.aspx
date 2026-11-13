<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="LOT1003_S01.aspx.cs" Inherits="LOT1003_S01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="LOT1003_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="조회기간" FieldFrom="SDATE" FieldTo="EDATE" ID="dr_DATE" />
        <Its:combo runat="server" Label="창고코드" ID="cmb_WARECD" Field="WARECD" InputWidth="97" GPCD="WARECD" Required="true"/>
        <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMCG" Field="ITEMCG" GPCD="*DM100" />
        <Its:find runat="server" Label="품목코드" ID="find_ITEMID" Field="ITEMID" GPCD="ITEMID" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle" >
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
</asp:Content>