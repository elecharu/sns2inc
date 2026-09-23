
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL1001_S01.aspx.cs" Inherits="TAL1001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL1001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
<%--      <style type="text/css">
        #grid1 { height:675px !important; }
        #grid2 { height:675px !important; }
    </style>--%>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자" ID="dateR_EXPDATE"  /> 
        <%--<its:combo runat="server" Label="공정" Field="PRCCD" GPCD="*PRCCD_AFTERCUT" ID="cmb_PRCCD" InputWidth="100"/>--%>
        <Its:button runat="server" Label="수주 조회" ID="btn_LIST_SALODRD_ROUT"  Width="200" MarginLeft="40"/>

    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid_SALODRD_ROUT" />
    </Its:div>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">    
    <Its:pop runat="server" ID="pop_LIST_PRDRST" Title="실적상세 보기"  Width="1200" Height="500">
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid_PRDRST" />
        </Its:div>        
    </Its:pop>
</asp:Content>