<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS2001_R01.aspx.cs" Inherits="SYS2001_R01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS2001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="구분" Field="PKGTP" GPCD="*PKGTP_E" ID="cmb_PKGTP" />
        <Its:combo runat="server" Label="상태" Field="PRGSTT" GPCD="*PRGSTT_E" ID="cmb_PRGSTT" />
        <Its:text runat="server" Label="작업자" Field="DEV"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_POP" Runat="server">
    <Its:pop runat="server" ID="pop1" Title="이슈사항" Width="510">
        <Its:button runat="server" ID="SAVE_REMARK" Label="저장" />
        <Its:textarea runat="server" ID="ta_REMARK" Field="REMARK" Label="" InputWidth="500" InputHeight="500" />
    </Its:pop>
    <Its:pop runat="server" ID="pop2" Title="화면추가" Width="510" Type="add">
        <Its:combo runat="server" Label="패키지" Field="PKGTP" GPCD="PKGTP_E" ID="pop2_PKGTP" />
      
        <Its:newline runat="server" />
        <Its:text runat="server" Label="프로그램코드" Field="PRGCD" />
        <Its:text runat="server" Label="프로그램명" Field="MENUNM" />
        <Its:newline runat="server" />
        <Its:combo runat="server" Label="작업상태" Field="PRGSTT" GPCD="PRGSTT_E" Value="10" />
        <Its:text runat="server" Label="작업자" Field="DEV" />
        <Its:newline runat="server" />
        <Its:combo runat="server" Label="출처" Field="ORI" GPCD="PRGORI_E" Value="NEW" />
        <Its:text runat="server" Label="출처화면코드" Field="ORIPRGCD" />
        <Its:newline runat="server" />
        <Its:text runat="server" Label="출처화면명" Field="ORIPRGNM" />
    </Its:pop>
</asp:Content>