<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- PRD7001_R03 (영진산업): 생산관리 ▶ 단말기 정보 ▷ 단말기별 프로그램 정보 --%>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- PAGE --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD7001_R03.aspx.cs" Inherits="PRD7001_R03" %>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>
<%-- HEAD --%>

<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD7001_R03.js?ver=<%= BasePage.srcVersion %>"></script>
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
        <Its:div runat="server" Type="SplitTop">
            <Its:newline runat="server" Height="5" />
            <Its:combo runat="server" Label="단말기" ID="cmb_TMLCD_ddiv1" Field="TMLCD" GPCD="TMLCD"/>
            <Its:button runat="server" Label="프로그램 정보 복사" ID="COPY_MSTTML" FaIcon="fas fa-clone" BackColor="LightCyan" Height="22" Width="100" Margin_Left="15px" />
            <Its:newline runat="server" Height="5" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_TMLPRG" />
        </Its:div>
    </Its:div>
</asp:Content>

<%-- -------------------------------------------------------------------------------------------------------------------------------------------------- --%>