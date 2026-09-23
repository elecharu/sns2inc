<%-- 기준관리 ▶ 기준관리 ▷ 품목마스터 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1003_R04.aspx.cs" Inherits="MST1003_R04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1003_R04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="품목분류" ID="sdiv1_combo_ITEMCG" Field="ITEMCG" GPCD="DM100" Value="DM100100"/>
        <Its:find runat="server" Label="품목" ID="sdiv1_find_ITEMID" Field="ITEMID" GPCD="ITEMID" />
        <Its:check runat="server" Label="종료 여부" ID="sdiv1_check_ENDYN" Field="ENDYN" Value="N"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>