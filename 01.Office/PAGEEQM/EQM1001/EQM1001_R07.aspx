<%-- EQM1001_R07: 설비 예방보전 점검등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R07.aspx.cs" Inherits="EQM1001_R07" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R07.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" REF01="07" GPCD="*LINECD" InputWidth="160" />
        <Its:combo runat="server" Label="공정" ID="cmb_EQMTP" Field="EQMTP" GPCD="*EQMTP" InputWidth="120" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMGROUP1" Field="EQMGROUP1" GPCD="*EQMGROUP1" InputWidth="120" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="30">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:div runat="server" Type="SplitRight">
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
</asp:Content>
