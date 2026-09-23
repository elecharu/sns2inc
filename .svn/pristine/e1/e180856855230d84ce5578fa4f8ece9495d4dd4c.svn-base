<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL0001_R04.aspx.cs" Inherits="TAL0001_R04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL0001_R04.js?ver=<%= BasePage.srcVersion %>"></script>
    <style type="text/css">
        #grid2 { height:280px !important; }
        #grid3 { height:540px !important; }

    </style>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="sdiv1" TopHeightPc="50">
        <Its:div runat="server" Type="SplitTop" >
           <Its:dateRange runat="server" Label="납기일자" FieldFrom="SDATE" FieldTo="EDATE" ID="date_SALDATE"/>
            <Its:find runat="server" Label= "거래처" Field="CUSTCD"  GPCD ="CUSTCD"  NameWidth="150"  InputWidth="150"/>
            <Its:find runat="server" Label="품목" ID="find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" REF05="MTR" REF02="PRD" NameWidth="150"  InputWidth="150"   />
            <Its:button runat="server" Label="수주 조회" ID="btn_SALODRD" Width="180" MarginLeft="20"    />
        </Its:div>
        <Its:split runat="server" Type="Horizon"  Resizeable="false"/>

        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitTop" TopHeightPc="7" >
        	<Its:label runat="server" Text="수주 리스트" Bold="true" MarginLeft="10"/>
        	</Its:div>
               <Its:split runat="server" Type="Horizon" Resizeable="false" />
        	<Its:div runat="server" Type="SplitDown" >
        	<Its:grid runat="server" ID="grid1"/>
        	</Its:div> 
        </Its:div>        
    </Its:div>
    
    <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
    
    <Its:div runat="server" Type="SplitDown">
   
        <Its:div runat="server" Type="SplitTop">
            <Its:label runat="server" Text="출하스캔 리스트" Bold="true" MarginTop="10" MarginLeft="10"/>
            <Its:button runat="server" Label="출하스캔 등록" ID="btn_SCAN_SALOUT" Width="180"  MarginLeft="30"  BackColor="CustomButton2"  />    
            <Its:button runat="server" Label="출고확정" ID="btn_CONFIRM_SALOUT" Width="150"  MarginLeft="30"  BackColor="CustomButton"  />    
        </Its:div>
        <Its:split runat="server" Type="Horizon"  Resizeable="false"/>
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid2"  />
        </Its:div>
    </Its:div>
 
</asp:Content>

 <%--POP--%> 
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop_SCAN" Type="common" Title="출하스캔" Width="840" Height="680"  >
        <Its:div runat="server" Type="SplitTop" ID="pdiv1">
            <Its:text runat="server" Label= "창고" ID="pop_txt_WARENM"  InputWidth="150" Field="WARENM"  ReadOnly="true"/>
            <Its:text runat="server" Label= "창고코드" ID="pop_txt_WARECD"  InputWidth="100" Field="WARECD"  ReadOnly="true" Hidden="true"/>
            <Its:text runat="server" Label= "품명" ID="pop_txt_ITEMNM"  InputWidth="170" Field="ITEMNM"  ReadOnly="true"/>
            <Its:text runat="server" Label= "품목코드" ID="pop_txt_ITEMCD"  InputWidth="100" Field="ITEMCD"  ReadOnly="true" Hidden="true"/>
            <Its:text runat="server" Label= "로트번호" ID="pop_txt_LOTKEY"  InputWidth="200" Field="LOTKEY" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label= "지시수량" ID="pop_num_SALOUTQTY"  InputWidth="150" Field="SALOUTQTY" ReadOnly="true" />
            <Its:num runat="server" Label= "스캔수량" ID="pop_num_SCANQTY"  InputWidth="170" Field="SCANQTY" ReadOnly="true"/>

        </Its:div>   
 
        <%--<Its:split runat="server" Type="Horizon" Resizeable="false" />--%>
        <Its:div runat="server" Type="SplitDown">
             <Its:grid runat="server" ID="grid3"  />
        </Its:div>        
        
    </Its:pop>
</asp:Content>