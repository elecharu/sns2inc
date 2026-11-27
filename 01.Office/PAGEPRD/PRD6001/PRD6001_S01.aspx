<%-- PRD6001_S01: 설비 일상점검 조회 --%>
<%-- 2026-11-26 점검월 기준으로 변경: 위 설비 목록(여러 대 체크 → 점검표 출력) / 아래 고른 설비의 월간 표(점검항목 × 1~31일) --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD6001_S01.aspx.cs" Inherits="PRD6001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD6001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:month runat="server" Label="점검월" ID="mon_SMONTH" Field="SMONTH" />
        <Its:combo runat="server" Label="작업장" Field="LINECD" ID="cmb_LINECD" REF01="07" GPCD="*LINECD" />
        <Its:combo runat="server" Label="공정" Field="EQMTP" ID="cmb_EQMTP" GPCD="*EQMTP" />
        <Its:combo runat="server" Label="라인" Field="EQMGROUP1" ID="cmb_EQMGROUP1" GPCD="*EQMGROUP1" />
        <Its:find runat="server" Label="설비" ID="find_EQMCD" GPCD="EQMCD" Field="EQMCD" InputWidth="80" NameWidth="120" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">

   <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 설비 목록 (체크한 설비마다 그 달 점검표 1장)" Bold="true" MarginLeft="10"/>
            <Its:button runat="server" Label="점검표 출력" ID="btn_PRINT" MarginRight="10" Float="right" BackColor="CustomButton2" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 월간 점검표 (칸 더블클릭 → 그날 점검 내용)" Bold="true" MarginLeft="10" ID="lbl_SHEET"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>

</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <%-- 2026-11-26 월간 표 칸 더블클릭: 그 설비·그날 점검 이력 + 고른 점검의 항목별 값 --%>
    <Its:pop runat="server" ID="pop_DAY" Title="일상점검 내용" Width="1300" Height="560">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
            <Its:grid runat="server" ID="grid_DAY1" />
        </Its:div>

        <Its:split runat="server" Type="Horizon" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_DAY2" />
        </Its:div>
    </Its:pop>
</asp:Content>
