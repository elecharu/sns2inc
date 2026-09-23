<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- PRD7001_R02 (영진산업): 생산관리 ▶ 단말기 정보 ▷ 단말기별 작업자 --%>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- PAGE --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD7001_R02.aspx.cs" Inherits="PRD7001_R02" %>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- HEAD --%>

<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD7001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- SEARCH --%>

<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:text runat="server" Label="키워드" ID="txt_KEYWORD_sdiv1" Field="KEYWORD" InputWidth="410" MaxLength="100" />
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- BODY --%>

<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="20">
        <Its:grid runat="server" ID="grid_TML" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid_TMLEMP" />
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>