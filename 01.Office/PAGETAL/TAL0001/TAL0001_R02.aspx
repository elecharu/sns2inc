<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL0001_R02.aspx.cs" Inherits="TAL0001_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL0001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
     <style type="text/css">
        #grid2 { height: 355px !important;}
    </style>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="sdiv1" TopHeightPc="40">
        <Its:div runat="server" Type="SplitTop" >
            <Its:combo runat="server" Label="창고코드" ID="cmb_WARECD" Field="WARECD" GPCD="WARECD" InputWidth="130" Required="true" />
            <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMTP" Field="ITEMTP" GPCD="*ITEMTP" InputWidth="100"  />
            <Its:find runat="server" Label="품목" ID="find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" NameWidth="180"  />
            
            <Its:button runat="server" Label="조회" ID="button_SEARCHITEM"   />
        </Its:div>
        <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
        <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid1"   />
        </Its:div>        
    </Its:div>
    
    <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
    
    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1" >
            <Its:date runat="server" Label="이동일자" ID="date_INDATE" Field="MOVEDATE" Required="true"/>
            <Its:combo runat="server" Label="이동창고" ID="cmb_OUTWARECD" Field="OUTWARECD" GPCD="WARECD" Required="true" InputWidth="100"/>
            <Its:find runat="server" Label="작업자" Field="EMPCD" GPCD="EMPCD" ID="find_EMPCD" Required="true"/>
            <Its:button runat="server" Label="이동등록" ID="SUBMIT_COMMOVE"  BackColor="CustomButton2" />           
        </Its:div>
        
        <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
        
        <Its:div runat="server" Type="SplitDown">
                <Its:grid runat="server" ID="grid2"   />
        </Its:div>        
    </Its:div>  

</asp:Content>