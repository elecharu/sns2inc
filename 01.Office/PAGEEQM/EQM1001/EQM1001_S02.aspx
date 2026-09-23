<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_S02.aspx.cs" Inherits="EQM1001_S02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_S02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>



<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="조회기간" FieldFrom="SDATE" FieldTo="EDATE" ID="date_SDATE" />
        
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">

    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid_EQM" />
    </Its:div>


</asp:Content>