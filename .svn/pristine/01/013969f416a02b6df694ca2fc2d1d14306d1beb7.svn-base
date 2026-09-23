
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL1001_R03.aspx.cs" Inherits="TAL1001_R03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL1001_R03.js?ver=<%= BasePage.srcVersion %>"></script>
<%--    <style type="text/css">
        #grid1 { height:675px !important; }
        #grid2 { height:675px !important; }
    </style>--%>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자" ID="dateR_EXPDATE"  /> 
        <Its:button runat="server" Label="수주 조회" ID="btn_LIST_SALODRD_ROUT"  Width="150" MarginLeft="40"/>

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
    <Its:pop runat="server" ID="pop_ADD_PRDRST" Title="외주 입출고 등록"  Width="500" Height="650">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1" TopHeightPc="66">
            <Its:find runat="server" Label="외주처" GPCD="CUSTCD" Field="CUSTCD" ID="find_CUSTCD" REF04="Y" MarginTop="20" InputWidth="100" NameWidth="190"/>
            <Its:newline runat="server"/>        
            <Its:num runat="server" Label="출고수량" ID="num_OUTQTY" MarginTop="30" InputWidth="158"/>
            <Its:button runat="server" Label="출고 등록" ID="btn_ADD_PRDRST_OUT" ForeColor="White" MarginTop="30" MarginLeft="20"/>  
            <Its:newline runat="server"/>        
            <Its:num runat="server" Label="양품수량" ID="num_INQTY" MarginTop="30" InputWidth="158" />
            <Its:button runat="server" Label="양품 입고등록" ID="btn_ADD_PRDRST_IN" ForeColor="White" MarginTop="30" MarginLeft="20" MarginRight="10"/>
            <Its:newline runat="server"/>        
            <Its:combo runat="server" Label="불량유형" ID="cmb_BADTP" GPCD="*BADTP_PRCCD" Field="BADTP" InputWidth="100" MarginTop="30" />        
            <Its:combo runat="server" Label="불량코드" ID="cmb_BADCD" GPCD="BADCD" Field="BADCD" InputWidth="265" MarginTop="5" />                    
            <Its:newline runat="server"/>        
            <Its:num runat="server" Label="불량수량" ID="num_BADQTY" MarginTop="5" InputWidth="158"/>        
            <Its:button runat="server" Label="불량 입고등록" ID="btn_ADD_PRDRSTBAD_IN" ForeColor="White" MarginTop="5" MarginLeft="20" MarginRight="10"/>
        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false"/>
        <Its:div runat="server" Type="SplitDown">
            <Its:num runat="server" Label="누적출고수량" ID="num_OUTQTY_SUM" MarginTop="20" LabelWidth="140" InputWidth="158" ReadOnly="true"/>
            <Its:num runat="server" Label="누적양품수량" ID="num_GOODQTY_SUM" MarginTop="5" LabelWidth="140" InputWidth="158" ReadOnly="true"/>
            <Its:num runat="server" Label="누적불량수량" ID="num_BADQTY_SUM" MarginTop="5" LabelWidth="140" InputWidth="158" ReadOnly="true"/>
        </Its:div>
    </Its:pop>    
    
    <Its:pop runat="server" ID="pop_DEL_PRDRST" Title="외주 입출고 삭제"  Width="1000" Height="500">
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid_PRDRST" />
        </Its:div>        
    </Its:pop>
</asp:Content>