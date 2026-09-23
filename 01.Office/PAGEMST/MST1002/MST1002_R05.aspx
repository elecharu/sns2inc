<%-- 기준관리 ▶ 기준관리 ▷ 생산설비정보 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST1002_R05.aspx.cs" Inherits="MST1002_R05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST1002_R05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="공장" Field="FACTORYCD"  GPCD="*FACTORYCD" InputWidth="100" Value="07"/>
        <Its:combo runat="server" Label="작업장" Field="LINECD" GPCD="*LINECD" REF01="07"/>
        <Its:combo runat="server" Label="공정" Field="PRCCD" GPCD="*PRCCD" REF01="07"/>
        <Its:check runat="server" Label="사용여부" Field="USEYN" Value="Y" MarginLeft="20"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle" TopHeightPc="70">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>