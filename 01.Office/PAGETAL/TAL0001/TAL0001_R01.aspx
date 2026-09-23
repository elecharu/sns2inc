<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL0001_R01.aspx.cs" Inherits="TAL0001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL0001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <style type="text/css">
        #grid2 { height: 315px !important; }
        #grid3 { height: 315px !important; }
    </style>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="sdiv1" TopHeightPc="40">
        <Its:div runat="server" Type="SplitTop" >
            <Its:dateRange runat="server" Label="발주일자" ID="date_SEARCH" FieldFrom="SDATE" FieldTo="EDATE"  />
            <Its:find runat="server" Label="거래처" ID="find_CUSTCD" Field="CUSTCD" GPCD="CUSTCD"  InputWidth="200" NameWidth="200" REF02="Y"  />              
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="품목유형" ID="cmb_ITEMTP" Field="ITEMTP" GPCD="*ITEMTP" REF01="MTR01" InputWidth="238" />
            <Its:find runat="server" Label="품목" ID="find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" REF05="MTR" REF02="MTR" InputWidth="200" NameWidth="200"/>
            <Its:button runat="server" Label="발주조회" ID="button_ORDER"  MarginLeft="30"   />
            <Its:check runat="server" Label="입고완료"  ID ="chk_MTRODRSTT" Field="MTRODRSTT"  Value="N"  MarginLeft="30" MarginTop="5"/>  
        </Its:div>
        <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
        <Its:div runat="server" Type="SplitDown" >
                <Its:grid runat="server" ID="grid1"   />
        </Its:div>        
    </Its:div>
    
    <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
    
    <Its:div runat="server" Type="SplitDown" >
        <Its:div runat="server" Type="SplitTop" ID="pdiv1"  >
            <Its:date runat="server" Label="입고일자" ID="date_INDATE" Field="INDATE"/>
            <Its:combo runat="server" Label="입고창고" ID="cmb_WARECD" Field="WARECD" GPCD="WARECD"/>
            <Its:find runat="server" Label="작업자" Field="EMPCD" GPCD="EMPCD" ID="find_EMPCD"/>
            <Its:num runat="server" Label="입고수량" Field="INQTY" ID="num_INQTY"/>
            <Its:button runat="server" Label="입고등록" ID="btn_ADD_MTRINLOT" Width="100" BackColor="CustomButton2" />
            <%--<Its:button runat="server" Label="입고삭제" ID="CANCEL_COM"  BackColor="CustomButton3" />--%>            
        </Its:div>
        
        <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
        
        <Its:div runat="server" Type="SplitDown" >
           <Its:grid runat="server" ID="grid2"   />
        </Its:div>  
    </Its:div>  

</asp:Content>

