<%--불량코드정보--%>
<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST0001_R02.aspx.cs" Inherits="MST0001_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST0001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="불량유형" ID="Combo_BADTP" Field="BADTP" GPCD="*BADTP"/>
        <Its:text runat="server" Label="키워드" Field="KEYWORD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="불량코드 추가" Width="500">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <%--<Its:text runat="server" Label="불량코드" Field="BADCD"/>--%>
            <Its:text runat="server" Label="불량명"   Field="BADNM"/>
            <Its:newline runat="server" />
           <%-- <Its:check runat="server" Label="주요여부" Field="MAJORYN" MarginLeft="75" />--%>            
            <Its:find runat="server" Label="공정" GPCD="PRCCD" Field="PRCCD" InputWidth="110"/>     
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" Field="REMARK" InputWidth="240"/>
        </Its:div>
    </Its:pop>
</asp:Content>