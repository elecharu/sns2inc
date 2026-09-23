<%--태블릿 입고이력조회--%>
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL0001_S02.aspx.cs" Inherits="TAL0001_S02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL0001_S02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
     <Its:div runat="server" Type="SplitTop" ID="sdiv1" TopHeightPc="10">
        <Its:dateRange runat="server" Label="입고일자" FieldFrom="SDATE" FieldTo="EDATE" ID="txt_INDATE" />
        <Its:find runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" InputWidth="200"  NameWidth="170" ID="find1"/>
         <Its:newline runat="server" />
        <Its:combo runat="server" Label="품목유형" Field="ITEMTP" GPCD="*ITEMTP" ID="cmb_ITEMTP" REF01="MTR01"/>
        <Its:find runat="server"  Label="품목코드" Field="ITEMCD" GPCD="ITEMCD" ID="find_ITEMCD" InputWidth="200" NameWidth="170" MarginLeft="168" />
        <Its:button runat="server" Label="입고조회" ID="button_SEARCHCOMIN" Width="100"  />                 
    </Its:div>
    
    <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
    
    <Its:div runat="server" Type="SplitDown">
       <Its:div runat="server" Type="SplitTop" TopHeightPc="40">
            <Its:grid runat="server" ID="grid1" />
       </Its:div>
       <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
       <Its:div runat="server" Type="SplitDown" >
            <Its:grid runat="server" ID="grid2" />
       </Its:div>
    </Its:div>  

</asp:Content>

