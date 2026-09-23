<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS1002_R01.aspx.cs" Inherits="SYS1002_R01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS1002_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="패키지유형" Field="PKGTP" GPCD="*PKGTP" />
        <Its:text runat="server" Label="키워드" Field="KEYWORD"  />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />

    <Its:div runat="server" Type="SplitRight" ID="ddiv1">
        <Its:combo runat="server" Label="패키지 유형" Field="PKGTP" GPCD="PKGTP"/>
        <Its:text runat="server" Label="화면 코드" Field="PRGCD" ID="txt_PRGCD"/>
        <Its:newline runat="server" />
        <Its:text runat="server" Label="화면명" Field="PRGNM" />
        <Its:combo runat="server" Label="패키지 유형" Field="PRGSTT" GPCD="PRGSTT"/>
        <Its:newline runat="server" />
        <Its:textarea runat="server" Label="비고" Field="REMARK"  InputWidth="300"/>
        <Its:onoff runat="server" Label="신규/기존 여부" Field="NEWYN" Hidden="true" OnText="신규" OffText="기존" ID="onoff_NEWYN"/>
    </Its:div>
</asp:Content>