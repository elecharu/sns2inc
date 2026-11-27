<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1006_R01.aspx.cs" Inherits="MST1006_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1006_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="목표년도" ID="cmb_SYEAR" Field="SYEAR" GPCD="YEAR" REF01="-4" REF02="1" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
        <Its:combo runat="server" Label="공정" ID="cmb_EQMTP" Field="EQMTP" GPCD="*EQMTP" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMGROUP1" Field="EQMGROUP1" GPCD="*EQMGROUP1" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="50">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 라인별 목표" Bold="true" Margin="3px 0px 0px 10px" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 설비별 목표" Bold="true" Margin="3px 0px 0px 10px" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
</asp:Content>
