<%--작업장정보--%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST0001_R03.aspx.cs" Inherits="MST0001_R03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST0001_R03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:text runat="server" Label="키워드" ID="txt_KEYWORD" Field="KEYWORD" />
        <Its:newline runat="server" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
           <Its:grid runat="server" ID="grid1" />  
    </Its:div>   
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="라인 추가" Width="500">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:text runat="server" Label="라인코드" Field="LINECD"/>
            <Its:text runat="server" Label="라인명"   Field="LINENM"/>
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="작업장" Field="WORKPLACE" GPCD="WPCD"/>
            <Its:num runat="server" Label="순번" Field="SORTNO"/>
            <Its:newline runat="server" />
            <Its:check runat="server" Label="사용여부" Field="USEYN" MarginLeft="30" />
            <Its:text runat="server" Label="비고" Field="REMARK" LabelWidth="70" InputWidth="225"/>
        </Its:div>
    </Its:pop>
</asp:Content>