<%--창고정보--%>
<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST0001_R06.aspx.cs" Inherits="MST0001_R06" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST0001_R06.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="창고유형" ID="Combo_WARETP" Field="WARETP" GPCD="*WARETP"/>
        <Its:text runat="server" Label="키워드" Field="KEYWORD"  /> 
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
    <Its:pop runat="server" ID="pop1" Type="add" Title="창고정보 추가" Width="700">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:text runat="server" Label="창고코드" Field="WARECD"/>
            <Its:text runat="server" Label="창고명"   Field="WARENM"/>
            <Its:combo runat="server" Label="창고유형" Field="WARETP" GPCD="WARETP"/>
            <Its:newline runat="server" />
            <Its:num runat="server" Label="순번" Field="SORTNO" />
            <Its:check runat="server" Label="사용여부" Field="USEYN" MarginLeft="40" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" Field="REMARK" InputWidth="319" />
        </Its:div>
    </Its:pop>
</asp:Content>