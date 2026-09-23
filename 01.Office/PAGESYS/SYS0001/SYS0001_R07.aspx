<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS0001_R07.aspx.cs" Inherits="SYS0001_R07" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS0001_R07.js?ver=<%= BasePage.srcVersion %>"></script>
    <style>
        #ddiv1 {
                height: calc(100% - 20px);
        }
    </style>
    
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:find runat="server" Label="사용자" ID="find_USERID" Field="USERID" GPCD="USERID" FindType="mini"/>
        <Its:text runat="server" Label="프로그램명" Field="KEYWORD" InputWidth="150"  />
        <Its:display runat="server" Label="사내" ID="INSIDE"  LabelWidth="50" InputWidth="10"/>
<%--        <Its:display runat="server" Label="사외" ID="OUTSIDE" LabelWidth="50" InputWidth="10"/>--%>
        <Its:display runat="server" Label="★사용자별 직무권한 수정 시 개인별 권한이 초기화됩니다" LabelWidth="315" ID="txt_RESET"  />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" ID="div1">
        <Its:div runat="server" Type="SplitTop" TopHeightPc="50" >
                <Its:grid runat="server" ID="grid1"/>
            </Its:div>
        <Its:split runat="server" Type="Horizon" />
        <Its:div runat="server" Type="SplitDown" >
            <Its:grid runat="server" ID="grid3" />
        </Its:div>
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