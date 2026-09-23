<%-- EQM1001_R02: 정기점검 항목관리 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="EQM1001_R02.aspx.cs" Inherits="EQM1001_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="EQM1001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>


<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:text runat="server" Label="키워드"  Field="KEYWORD" InputWidth="300"/>
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
    <Its:pop runat="server" ID="pop1" Title="정기점검 항목 등록" Type="add" Width="690">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:text runat="server" Label="점검코드" Field="CHKKNDCD" />
            <Its:combo runat="server" Label="점검항목" Field="CHKLOC" GPCD="CHKLOC" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="점검명" Field="CHKKNDNM" InputWidth="517" />
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="점검방법" Field="CHKMTH" GPCD="CHKMTH" />
            <Its:combo runat="server" Label="점검주기" Field="CHKCYCLE" GPCD="CHKCYCLE" />
            <Its:combo runat="server" Label="점검값구분" Field="CHKVALTP" GPCD="CHKVALTP" />

            <Its:check runat="server" Label="사용여부" Field="USEYN" MarginLeft="35" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="비고" Field="REMARK" InputWidth="517" />
        </Its:div>
    </Its:pop>
    
</asp:Content>
