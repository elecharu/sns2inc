<%-- 기준관리 ▶ 기준관리 ▷ 불량코드관리 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1003_R03.aspx.cs" Inherits="MST1003_R03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1003_R03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="공장" Field="FACTORYCD"  GPCD="*FACTORYCD" InputWidth="100" Value="07"/>
        <Its:text runat="server" Label="불량유형(*)" Field="TPNM" />
        <Its:combo runat="server" Label="대분류" Field="BADTP1" GPCD="*QM210" InputWidth="100" REF01="07"/>
        <Its:combo runat="server" Label="중분류" Field="BADTP2" GPCD="*QM220" InputWidth="100" REF01="07"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>