<%-- TQC5002_R02: 품질관리 - 계측기관리 - 인증서 갱신등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SYS2001_R04.aspx.cs" Inherits="SYS2001_R04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SYS2001_R04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:dateRange runat="server" Label="유효기간" FieldFrom="SDATE" FieldTo="EDATE" ID="dr_DATE"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft"  ID="div1">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight" ID="div2">
        <Its:text runat="server" Label="공지제목" Field="SUBJECT" InputWidth="319" />
        <Its:newline runat="server" />
        <Its:date runat="server" Label="등록일자" Field="NOTICEFRDT" ID="date_NOTICEFRDT" />
        <Its:date runat="server" Label="유효기간" Field="NOTICETODT" ID="date_NOTICETODT" />
        <Its:newline runat="server" />
        <Its:textarea runat="server" Label="공지내용" Field="CONTENT" InputHeight="500" InputWidth="500" />
    </Its:div>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">

</asp:Content>