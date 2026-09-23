<%--공정정보--%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST0001_R05.aspx.cs" Inherits="MST0001_R05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST0001_R05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="공정유형" ID="combo_PRCTP" Field="PRCTP" GPCD="*PRCTP" />
        <Its:text runat="server" Label="키워드" ID="text_KEYWORD" />
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
    <Its:pop runat="server" ID="pop1" Type="add" Title="공정정보 추가" Width="700">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:text runat="server" Label="공정코드" Field="PRCCD"/>
            <Its:text runat="server" Label="공정명"   Field="PRCNM"/>
            
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="공정유형" Field="PRCTP" GPCD="PRCTP"/>
            <Its:num runat="server" Label="순번" Field="SORTNO" />
            <Its:newline runat="server" />
            <Its:check runat="server" Label="사용여부" Field="USEYN" LabelWidth="80" />
            <Its:text runat="server" Label="비고"  Field="REMARK" LabelWidth="180" InputWidth ="315"/>
        </Its:div>
    </Its:pop>
</asp:Content>