<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="PRD0001_S06.aspx.cs" Inherits="PRD0001_S06" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD0001_S06.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자" ID="dateR_EXPDATE"  /> 
        <Its:find runat="server" Label="거래처" GPCD="CUSTCD" Field="CUSTCD" ID="find_CUSTCD" />
        <Its:find runat="server" Label="제품코드" GPCD="ITEMCD" Field="ITEMCD" ID="find_ITEMCD" />
    </Its:div>
</asp:Content>


<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid_PRDRSTBAD" />
    </Its:div>
</asp:Content>

