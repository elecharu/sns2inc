<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST0001_R13.aspx.cs" Inherits="MST0001_R13" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST0001_R13.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="비가동유형" ID="Combo_NONTP" Field="NONTP" GPCD="*NONTP"/>
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
    <Its:pop runat="server" ID="pop1" Type="add" Title="비가동코드 추가" Width="500">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:text runat="server" Label="비가동코드" Field="NONCD"/>
            <Its:text runat="server" Label="비가동명"   Field="NONNM"/>
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="비가동유형" Field="NONTP" GPCD="NONTP"/>
            <Its:num runat="server" Label="순번" Field="SORTNO" />
            <Its:newline runat="server" />                                    
            <%-- <Its:check runat="server" Label="고장여부" Field="BADYN" />--%>
           <%-- <Its:check runat="server" Label="계획여부" Field="PLANYN" />--%>
            <Its:text runat="server" Label="비고" Field="REMARK"/>
            <Its:check runat="server" Label="사용여부" Field="USEYN" LabelWidth="80"/>            
        </Its:div>
    </Its:pop>
</asp:Content>