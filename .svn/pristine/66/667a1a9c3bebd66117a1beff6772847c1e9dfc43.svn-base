<%-- 기준관리 ▶ 기준관리 ▷ 공정라우팅 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1003_R01.aspx.cs" Inherits="MST1003_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1003_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="공장" Field="FACTORYCD" GPCD="*FACTORYCD" InputWidth="100" Value="07"/>
        <Its:find runat="server" Label="품목코드" Field="ITEMID" GPCD="ITEMID" />
        <Its:check runat="server" Label="사용여부" Field="USEYN" Value="Y" MarginLeft="20"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop" ID="div2">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid3" />
        </Its:div>
    </Its:div>

</asp:Content>