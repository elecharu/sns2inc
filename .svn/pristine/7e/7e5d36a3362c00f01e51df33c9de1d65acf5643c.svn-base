<%-- TQC2002_S01: 품질관리 - 공정검사관리 - 공정불량조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM0001_S01.aspx.cs" Inherits="TQM0001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM0001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:dateRange runat="server" Label="등록일자" ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMTP" Field="*ITEMTP" GPCD="ITEMTP" />
        <Its:find runat="server" Label="품목코드" ID="find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>