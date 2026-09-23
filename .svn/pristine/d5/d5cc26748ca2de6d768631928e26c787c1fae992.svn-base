<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="PRD0001_S02.aspx.cs" Inherits="PRD0001_S02" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="PRD0001_S02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1"> 
        <Its:month runat="server" Label="조회년월" Field="YEARMM" />
        <Its:combo runat="server" Label="품목유형" Field="ITEMTP" GPCD="*ITEMTP" REF01="PRD01" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
       <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>
