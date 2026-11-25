<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST3001_S01.aspx.cs" Inherits="MST3001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST3001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="출고일자" ID="date_SEARCH" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="설비그룹" Field="EQMGRP" GPCD="*FM116" ID="cmb_GRP" />
        <Its:find runat="server" Label="설비" Field="EQMCD" GPCD="EQMCD" ID="find_EQMCD" InputWidth="80" NameWidth="120" />
        <Its:combo runat="server" Label="작업장" Field="LINECD" ID="cmb_LINECD" REF01="07" GPCD="*LINECD" />
        <Its:combo runat="server" Label="공정" Field="EQMTP" ID="cmb_EQMTP" GPCD="*EQMTP" />
        <Its:combo runat="server" Label="라인" Field="EQMGROUP1" ID="cmb_EQMGROUP1" GPCD="*EQMGROUP1" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="50">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 설비목록" Bold="true" Margin="3px 0px 0px 10px" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <Its:div runat="server" Type="SplitRight">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 사용부품" Bold="true" Margin="3px 0px 0px 10px" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
</asp:Content>
