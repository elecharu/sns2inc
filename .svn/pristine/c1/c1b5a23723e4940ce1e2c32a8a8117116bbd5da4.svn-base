<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_S04.aspx.cs" Inherits="EQM1001_S04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_S04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="점검일자" FieldFrom="SDATE" FieldTo="EDATE" ID="date_SDATE" />
        <Its:combo runat="server" Label="점검유형" ID="cmb_CHKTP" GPCD="*CHKTP"  Field="CHKTP" />
        <Its:find runat="server" Label="설비코드" ID="find_EQMCD" GPCD="EQMCD" Field="EQMCD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">

   <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 설비점검 이력" Bold="true" MarginLeft="10"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
    </Its:div>

    <Its:split runat="server" Type="Horizon" />

    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="■ 설비점검항목" Bold="true" MarginLeft="10"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2" />
        </Its:div> 
    </Its:div>   


</asp:Content>