<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD6001_S03.aspx.cs" Inherits="PRD6001_S03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD6001_S03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="수리종료일" ID="sdiv1_date_SEARCH" FieldFrom="SDATE" FieldTo="EDATE" />
        <Its:combo runat="server" Label="작업장" ID="sdiv1_cmb_LINECD" Field="LINECD" GPCD="*LINECD" REF01="07" />
        <Its:combo runat="server" Label="공정" ID="sdiv1_cmb_EQMTP" Field="EQMTP" GPCD="*EQMTP" InputWidth="70" />
        <Its:combo runat="server" Label="라인" ID="sdiv1_cmb_EQMGROUP1" Field="EQMGROUP1" GPCD="*EQMGROUP1" InputWidth="70" />
        <Its:find runat="server" Label="설비코드" ID="sdiv1_find_EQMCD" GPCD="EQMCD" Field="EQMCD" InputWidth="80" NameWidth="120" />
        <Its:combo runat="server" Label="작업구분" ID="sdiv1_cmb_WORKTP" Field="WORKTP" GPCD="*FM300" InputWidth="110" />
        <Its:combo runat="server" Label="고장유형" ID="sdiv1_cmb_FAILTP" Field="FAILTP" GPCD="*FM307" InputWidth="80" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="bdiv1">
        <Its:label runat="server" Text="■ 공무작업일지 (체크한 일지를 인쇄)" Bold="true" MarginLeft="10" ID="lbl_WORKLOG" />
        <Its:button runat="server" Label="공무작업일지 인쇄" ID="bdiv1_btn_PRINT" Float="right" MarginRight="10" BackColor="CustomButton2" />
    </Its:div>
    <Its:split runat="server" Type="Horizon" Resizeable="false" />
    <Its:div runat="server" Type="SplitDown" ID="bdiv2">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>
