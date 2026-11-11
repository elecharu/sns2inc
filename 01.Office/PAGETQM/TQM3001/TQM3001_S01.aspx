<%-- 품질관리 ▶ 협력사 불량조회 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TQM3001_S01.aspx.cs" Inherits="TQM3001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="TQM3001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:month runat="server" Label="조회월" ID="mon_SMONTH" Field="SMONTH" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>
