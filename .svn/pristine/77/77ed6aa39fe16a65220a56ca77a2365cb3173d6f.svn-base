
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL1001_R02.aspx.cs" Inherits="TAL1001_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL1001_R02.js?ver=<%= BasePage.srcVersion %>"></script>
    </asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자" ID="dateR_EXPDATE"  /> 
        <its:combo runat="server" Label="공정" Field="PRCCD" GPCD="*PRCCD_AFTERCUT" ID="cmb_PRCCD" InputWidth="100"/>
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
    <Its:pop runat="server" ID="pop_ADD_PRDRST" Title="생산실적 등록"  Width="500" Height="510">
        <Its:div runat="server" Type="SplitTop" ID="pdiv1" TopHeightPc="67">
            <Its:combo runat="server" Label="설비" GPCD="EQMCD" Field="EQMCD" ID="cmb_EQMCD" MarginTop="20" InputWidth="265"/>
            <Its:newline runat="server"/>        
            <Its:num runat="server" Label="양품수량" ID="num_GOODQTY" MarginTop="20" InputWidth="158"/>
            <Its:button runat="server" Label="양품등록" ID="btn_ADD_PRDRSTGOOD" ForeColor="White" MarginTop="20" MarginLeft="20"/>  
            <Its:newline runat="server"/>        
            <Its:combo runat="server" Label="불량유형" ID="cmb_BADTP" GPCD="*BADTP_PRCCD" Field="BADTP" InputWidth="100" MarginTop="30" />        
            <Its:newline runat="server"/>        
            <Its:combo runat="server" Label="불량코드" ID="cmb_BADCD" GPCD="BADCD" Field="BADCD" InputWidth="265" MarginTop="5" />        
            <Its:newline runat="server"/>        
            <Its:num runat="server" Label="불량수량" ID="num_BADQTY" MarginTop="5" InputWidth="158"/>
            <Its:button runat="server" Label="불량 등록" ID="btn_ADD_PRDRSTBAD" ForeColor="White" MarginTop="5" MarginLeft="20" MarginRight="10"/>
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false"/>
        <Its:div runat="server" Type="SplitDown">
            <Its:num runat="server" Label="누적양품수량" ID="num_GOODQTY_SUM" MarginTop="20" LabelWidth="140" InputWidth="158" ReadOnly="true"/>
            <Its:num runat="server" Label="누적불량수량" ID="num_BADQTY_SUM" MarginTop="5" LabelWidth="140" InputWidth="158" ReadOnly="true"/>
        </Its:div>
    </Its:pop>    
    
    <Its:pop runat="server" ID="pop_DEL_PRDRST" Title="생산실적 삭제"  Width="1100" Height="500">
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid_PRDRST" />
        </Its:div>        
    </Its:pop>

    <Its:pop runat="server" ID="pop_SALODRD_FILES" Title="고객사도면 보기"  Width="500" Height="400">
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid_SALODRD_FILES" />
        </Its:div>        
    </Its:pop>
</asp:Content>