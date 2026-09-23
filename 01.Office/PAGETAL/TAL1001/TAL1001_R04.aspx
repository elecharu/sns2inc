
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL1001_R04.aspx.cs" Inherits="TAL1001_R04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL1001_R04.js?ver=<%= BasePage.srcVersion %>"></script>
<%--    <style type="text/css">
        #grid1 { height:675px !important; }
        #grid2 { height:675px !important; }
    </style>--%>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자" ID="dateR_EXPDATE"  /> 
        <Its:button runat="server" Label="수주 조회" ID="btn_LIST_SALODRD"  Width="150" MarginLeft="40"/>

    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid_SALODRD" />
    </Its:div>
</asp:Content>


<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop_ADD_PRDRST_ASY" Title="조립등록"  Width="500" Height="130">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
        <Its:num runat="server" Label="조립수량" ID="num_ASYQTY" MarginTop="20" InputWidth="158"/>
        <Its:button runat="server" Label="조립등록" ID="btn_ADD_PRDRST_ASY" ForeColor="White" MarginTop="20" MarginLeft="20"/>  
        </Its:div>
    </Its:pop>    

    <Its:pop runat="server" ID="pop_ADD_PRDRST_PACK" Title="포장등록"  Width="500" Height="130">
        <Its:div runat="server" Type="SplitSingle" ID="Div1">
        <Its:num runat="server" Label="포장수량" ID="num_PACKQTY" MarginTop="20" InputWidth="158"/>
        <Its:button runat="server" Label="포장등록" ID="btn_ADD_PRDRST_PACK" ForeColor="White" MarginTop="20" MarginLeft="20"/>  
        </Its:div>
    </Its:pop>    
    
    <Its:pop runat="server" ID="pop_DEL_PRDRST" Title="조립/포장 삭제"  Width="1000" Height="500">
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid_PRDRST" />
        </Its:div>        
    </Its:pop>
</asp:Content>