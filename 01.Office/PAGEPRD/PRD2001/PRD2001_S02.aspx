<%-- 생산관리 ▶ 주간생산실적조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD2001_S02.aspx.cs" Inherits="PRD2001_S02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD2001_S02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:date runat="server" Label="시작일" ID="date_SDATE" Field="SDATE" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <%-- 1. 주간 생산실적 --%>
    <Its:div runat="server" Type="SplitTop" TopHeightPc="62">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 주간 생산실적" Bold="true" MarginLeft="10" />
            <Its:label runat="server" Text="" ID="lbl_WEEK" MarginLeft="20" />
            <Its:label runat="server" Text="" ID="lbl_MONTH" MarginLeft="20" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_WEEK" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <%-- 2. 생산 주요 ISSUE --%>
    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitLeft" LeftWidthPc="50">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 가동률 ISSUE (비가동)" Bold="true" MarginLeft="10" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid_NON" />
            </Its:div>
        </Its:div>

        <Its:split runat="server" Type="Vertical" />

        <Its:div runat="server" Type="SplitRight">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 불량률 ISSUE" Bold="true" MarginLeft="10" />
            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid_BAD" />
            </Its:div>
        </Its:div>
    </Its:div>
</asp:Content>
