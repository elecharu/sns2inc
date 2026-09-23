<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PDA1500_R01.aspx.cs" Inherits="PDA1500_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PDA1500_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>
<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="BasicBlock" ID="Div1">
        <Its:combo runat="server" Label="전표구분" Field="SALODRTP" GPCD ="SALODRTP" ID="cmb_SALODRTP"  REF02="Y" Required="true"/>
        <Its:combo runat="server" Label="입고창고" Field="CUSTWARE" GPCD ="CUSTWARE"  ID="cmb_CUSTWARE" Required="true" InputWidth="80"/>
        <Its:button runat="server" Label="조회" Width ="80" Height="30" ID="btn_LIST_SALODRD" />
        <Its:newline runat="server" Height="5" />
        <Its:grid runat="server" ID="grid3" Height ="370"/>
        <Its:newline runat="server" Height="5" />
        <Its:button runat="server" Label="선택" Width="150" Height="40" ID="btn_SELECT_SALODRD" />
        <Its:button runat="server" Label="전표완료" Width="150" Height="40" ID="btn_FINISH_SALODRD" BackColor="CustomButton" />
    </Its:div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_POP" runat="Server">
    <Its:pop runat="server" ID="pop2" Title="품목선택" Width="320">
        <Its:grid runat="server" ID="grid1" Height ="320"/>
        <Its:newline runat="server" Height="5" />
        <Its:button runat="server" Label="품목선택" Width="300" Height="40" ID="btn_SELECT_ITEMCD" />
        <Its:newline runat="server" Height="5" />
        <Its:button runat="server" Label="반입완료" Width="150" Height="40" ID="btn_FINISH_SALOUT" BackColor="CustomButton"/>   
        <Its:button runat="server" Label="완료 취소" Width="150" Height="40" ID="btn_CANCEL_SALOUT" BackColor="CustomButton3"/>
        <Its:newline runat="server" Height="5" />
    </Its:pop>

    <Its:pop runat="server" ID="pop1" Title="LOT 스캔" Width="320">
        <Its:text runat="server" Field="CUSTNM" Label="업체명" ReadOnly="true" LabelWidth="70" InputWidth="210" ID="CUSTNM"/>
        <Its:text runat="server" Field="ITEMNUM" Label="품번" ReadOnly="true" LabelWidth="70" InputWidth="210" ID="ITEMNUM"/>
        <Its:text runat="server" Field="ITEMNM" Label="품명" ReadOnly="true" LabelWidth="70" InputWidth="210" ID="ITEMNM"/>
        <Its:text runat="server" Field="OUTQTY" Label="요청수량" ReadOnly="true" LabelWidth="70" InputWidth="57" ID="OUTQTY"/>
        <Its:text runat="server" Field="LOTQTY" Label="스캔수량" ReadOnly="true" LabelWidth="70" InputWidth="58" ID="LOTQTY"/>
        
        <Its:text runat="server" Field="LOTKEY" Label="UDI 스캔" LabelWidth="70" InputWidth="210" ID="txt_SCAN"/>
        <Its:num runat="server" Field="LOTQTY" Label="로트 수량" LabelWidth="70" InputWidth="120" ID="num_LOTQTY"/>  
        <Its:button runat="server" Label="반입" Width="65" Height="30" ID="btn_SALOUTLOT" />
        <Its:newline runat="server" Height="5" />
        <Its:grid runat="server" ID="grid2" Height="280"/>
        <Its:newline runat="server" Height="5" />
        
    </Its:pop>
</asp:Content>