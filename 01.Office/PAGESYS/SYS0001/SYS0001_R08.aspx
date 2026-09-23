<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS0001_R08.aspx.cs" Inherits="SYS0001_R08" %>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <%--<link rel="stylesheet" type="text/css" href="SYS0101_R01.css" />--%>
    <script type="text/javascript" src="SYS0001_R08.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="부서" Field="DEPTP" GPCD="*DEPTP"/>
        <Its:find runat="server" Label="사원" Field="EMPCD" GPCD="EMPCD"/>
        <Its:dateRange runat="server" Label="조회기간" FieldFrom="SDATE" FieldTo="EDATE" ID="dr_DATE"/>
        <Its:text runat="server" Label="IP" Field="IP"/>
    </Its:div>
</asp:Content>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
</asp:Content>