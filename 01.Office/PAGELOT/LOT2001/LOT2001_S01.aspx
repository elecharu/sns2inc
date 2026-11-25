<%-- LOT2001_S01: 로트추적 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="LOT2001_S01.aspx.cs" Inherits="LOT2001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="LOT2001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="추적번호" ID="cmb_KEYTP" Field="KEYTP" GPCD="SELECT '로트번호' AS Label, 'LOT' AS Value UNION ALL SELECT '라벨번호', 'LABEL' UNION ALL SELECT '출하번호', 'SALOUT'" Value="LOT" />
        <Its:text runat="server" ID="txt_KEYVAL" Field="KEYVAL" InputWidth="180" />
        <Its:combo runat="server" Label="방향" ID="cmb_DIRTP" Field="DIRTP" GPCD="SELECT '양방향' AS Label, 'ALL' AS Value UNION ALL SELECT '역추적', 'BACK' UNION ALL SELECT '정추적', 'FWD'" Value="ALL" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <%-- 왼쪽: 로트 계보. 위 = 역추적, 아래 = 정추적 (둘 다 맨 위 줄이 조회로트) --%>
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="62">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="50">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 역추적 (투입된 로트 → 원소재)" Bold="true" MarginLeft="10" />
            </Its:div>
            <Its:split runat="server" Type="Horizon" Resizeable="false" />
            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid_BACK" />
            </Its:div>
        </Its:div>

        <Its:split runat="server" Type="Horizon" />

        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitTop">
                <Its:label runat="server" Text="■ 정추적 (이 로트를 쓴 곳 → 출하)" Bold="true" MarginLeft="10" />
            </Its:div>
            <Its:split runat="server" Type="Horizon" Resizeable="false" />
            <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid_FWD" />
            </Its:div>
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <%-- 오른쪽: 선택한 줄의 상세 --%>
    <Its:div runat="server" Type="SplitRight">
        <Its:tab runat="server" ID="tab1">
            <Its:div runat="server" Type="SplitSingle" TabTitle="기본정보">
                <Its:grid runat="server" ID="grid_INFO" />
            </Its:div>
            <Its:div runat="server" Type="SplitSingle" TabTitle="입출고">
                <Its:grid runat="server" ID="grid_IO" />
            </Its:div>
            <Its:div runat="server" Type="SplitSingle" TabTitle="품질">
                <Its:grid runat="server" ID="grid_QC" />
            </Its:div>
        </Its:tab>
    </Its:div>
</asp:Content>
