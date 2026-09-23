<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS3002_R05.aspx.cs" Inherits="SYS3002_R05" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS3002_R05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:text runat="server" Label="프로그램명" Field="KEYWORD" InputWidth="150"  />
        <Its:display runat="server" Label="*직무권한이 수정되면 해당 권한 사용자에게 바로 적용됩니다." LabelWidth="350" />
        <Its:display runat="server" Label="사내" ID="INSIDE"  LabelWidth="50" InputWidth="10"/>
        <Its:display runat="server" Label="사외" ID="OUTSIDE" LabelWidth="50" InputWidth="10"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" ID="div1">
        <Its:grid runat="server" ID="grid1"/>
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight" ID="div2"  >
        <Its:grid runat="server" ID="grid2"/>
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="Server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="직무권한 등록" Width="920">
        <Its:div runat="server" Type="BasicBlock" ID="pdiv1" >
            <Its:text runat="server" Label="권한코드" Field="AUTCD" ID="txt_AUTCD" />
            <Its:num runat="server" Label="정렬순서" Field="SORTNO" />
            <Its:text runat="server" Label="권한명" Field="AUTNM" InputWidth="200"/>
            <Its:newline runat="server" Height="2"/>
            <Its:text runat="server" Label="비고" Field="REMARK" InputWidth="320" />
<%--            <Its:check runat="server" Label="원가권한" Field="COSTYN" MarginLeft="50" Value="F" />
            <Its:check runat="server" Label="승인권한" Field="CONFIRMYN" MarginLeft="30" Value="F"/>--%>
            <Its:newline runat="server" Height="20" />
            <Its:grid runat="server" ID="grid4" Height="250" />
        </Its:div>
    </Its:pop>
</asp:Content>