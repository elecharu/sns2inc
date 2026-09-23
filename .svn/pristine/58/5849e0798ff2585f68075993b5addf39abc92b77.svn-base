<%--사원정보--%>
<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST0001_R07.aspx.cs" Inherits="MST0001_R07" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST0001_R07.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:combo runat="server" Label="사업장" Field="BDVCD"  GPCD="*BDVCD" InputWidth="100" Value="71"/>
        <Its:combo runat="server" Label="공장" Field="FACTORYCD"  GPCD="*FACTORYCD" InputWidth="100" Value="07"/>
        <Its:combo runat="server" Label="부서" Field="DEPTCD"  GPCD="*DEPTCD" REF01="71"/>
        <Its:combo runat="server" Label="진행상태" Field="STATBC"  GPCD="*HR125" Value="HR125100"/>
        <Its:text runat="server" Label="사원명(*)" Field="EMPNM" InputWidth="100" ID="sdiv1_find_EMPNM"/>
        <Its:newline runat="server" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
       <Its:grid runat="server" ID="grid_EMPLIST" />
    </Its:div>
</asp:Content>

<%--POP--%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">

</asp:Content>