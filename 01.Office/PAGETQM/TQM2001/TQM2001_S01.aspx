<%-- TQM2001_S01: 품질관리 ▶ 부적합관리 ▷ 부적합 판정조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM2001_S01.aspx.cs" Inherits="TQM2001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM2001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="판정일자" ID="dr_JUDGEDATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="판정유형" ID="cmb_JUDGETP" Field="JUDGETP" GPCD="*JUDGETP" />
        <Its:combo runat="server" Label="후처리" ID="cmb_PROCYN" Field="PROCYN" GPCD="SELECT '전체', '' UNION SELECT '미처리', 'N' UNION SELECT '처리완료', 'Y'" />
        <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMCG" Field="ITEMCG" GPCD="*DM100" />
        <Its:find runat="server" Label="품목" ID="find_ITEMID" Field="ITEMID" GPCD="ITEMID" NameWidth="150" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>
