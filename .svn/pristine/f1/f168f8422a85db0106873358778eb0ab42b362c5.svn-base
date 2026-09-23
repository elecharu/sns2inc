<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS3002_R07.aspx.cs" Inherits="SYS3002_R07" %>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <%--<link rel="stylesheet" type="text/css" href="SYS0101_R01.css" />--%>
    <script type="text/javascript" src="SYS3002_R07.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:text runat="server" Label="키워드" Field="KEYWORD"/>
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_POP" Runat="server">
    <Its:pop runat="server" ID="pop1" Title="권한코드추가" Width="490" Type="add">
        <Its:text runat="server" Required="true" Label="권한코드" Field="AUTCD" />
        <Its:text runat="server" Label="권한명" Field="AUTNM" />
        <Its:newline runat="server" />
        <Its:num runat="server" Label="정렬순서" Field="SORTNO" />
        <%--<Its:check runat="server" Label="사업장변경" Field="BDVYN" MarginLeft="70" Value="N" />--%>
        <Its:newline runat="server" />
        <Its:text runat="server" Label="비고" Field="REMARK" InputWidth="319" />
    </Its:pop>
</asp:Content>