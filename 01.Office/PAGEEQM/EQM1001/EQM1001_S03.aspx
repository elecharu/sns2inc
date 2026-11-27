<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_S03.aspx.cs" Inherits="EQM1001_S03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_S03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="비가동일자" ID="dr_DATE" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="비가동 대분류" ID="cmb_NONGROUPCD1" Field="NONGROUPCD1" GPCD="*SELECT TPNM, TPCD FROM COMTYPE WHERE GPCD = 'PP409' AND USEYN = 'Y' AND TPCD LIKE 'PP409I21_N' ORDER BY TPCD" />
        <Its:combo runat="server" Label="작업장" ID="cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
        <Its:combo runat="server" Label="공정" ID="cmb_PRCCD" Field="PRCCD" GPCD="*PRCCD_LINE" />
        <Its:combo runat="server" Label="라인" ID="cmb_EQMCD" Field="EQMCD" GPCD="*EQMCD_LINE" />
        <Its:find runat="server" Label="설비코드" ID="find_FANO" Field="FANO" GPCD="EQMCD" InputWidth="80" NameWidth="120" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:tab runat="server" ID="tab1">
        <Its:div runat="server" Type="SplitSingle" TabTitle="비가동 이력 조회">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>

        <Its:div runat="server" Type="SplitSingle" TabTitle="설비 수리 이력 조회">
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:tab>
</asp:Content>
