<%-- PRD1003_R01: 기준정보 ▶ 공정정보 ▷ 라우팅정보 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1001_R06.aspx.cs" Inherits="MST1001_R06" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1001_R06.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="품목유형" ID="combo_ITEMTP" Field="ITEMTP" GPCD="*ITEMTP" />
        <Its:find runat="server" Label="품목코드" ID="sdiv1_find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="35" >
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid2" />
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="라우팅 추가" Width="400" Height="450">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:grid runat="server" ID="grid3" Height="400"/>
        </Its:div>
    </Its:pop>
</asp:Content>
