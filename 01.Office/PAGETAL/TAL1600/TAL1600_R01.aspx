<%-- TAL1600_R01: 재고실사 등록 (태블릿) --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true"
    CodeFile="TAL1600_R01.aspx.cs" Inherits="TAL1600_R01" %>


<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server" >
    <script type="text/javascript" src="TAL1600_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="TAL1600_R01.css?ver=<%= BasePage.srcVersion %>" />

</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="div1">
        <Its:combo runat="server" Label="창고" ID="cmb_WARECD" Field="WARECD" GPCD="WARECD" Required="true" LabelWidth="70" InputWidth="220" MarginTop="10" MarginLeft="20" />
        <Its:button runat="server" Label="실사지시 조회" ID="btn_SEARCH" BackColor="CommonButton" MarginTop="9" MarginLeft="20" MarginBottom="10" Width="220" Height="40" />
    </Its:div>
    <Its:split runat="server" Type="Horizon" Resizeable="false" />
    <Its:div runat="server" Type="SplitDown">
        <Its:grid runat="server" ID="grid_COMCHK_GROUP" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop_COMCHK" Title="재고실사 등록" Width="1200" Height="640">
        <Its:div runat="server" Type="SplitTop" ID="pdiv_SCAN" TopHeightPc="29">
            <Its:text runat="server" Label="LOT 스캔" ID="txt_SCAN" Field="LOTKEY" LabelWidth="90" InputWidth="380" MarginTop="10" />
            <Its:num runat="server" Label="실사 수량" ID="num_CHKQTY" Field="CHKQTY" DecimalPoint="0" LabelWidth="90" InputWidth="220" MarginTop="10" />
            <Its:button runat="server" Label="등록" ID="btn_ADD_COMCHKLOT" BackColor="CommonButton" MarginTop="9" MarginLeft="20" Width="273" Height="40" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="창고" ID="txt_WARENM" LabelWidth="90" InputWidth="380" ReadOnly="true" MarginTop="10" />
            <Its:text runat="server" Label="품목코드" ID="txt_ITEMCD" LabelWidth="90" InputWidth="220" ReadOnly="true" MarginTop="10" />
            <Its:text runat="server" Label="로트번호" ID="txt_LOTKEY" LabelWidth="90" InputWidth="160" ReadOnly="true" MarginTop="10" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="품명" ID="txt_ITEMNM" LabelWidth="90" InputWidth="380" ReadOnly="true" MarginTop="10" />
            <Its:text runat="server" Label="재고수량" ID="txt_LOTQTY" LabelWidth="90" InputWidth="220" ReadOnly="true" MarginTop="10" />
            <Its:text runat="server" Label="실사수량" ID="txt_CHKQTY" LabelWidth="90" InputWidth="160" ReadOnly="true" MarginTop="10" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:div runat="server" Type="SplitLeft" LeftWidthPc="47">
                <Its:grid runat="server" ID="grid_COMCHK" />
            </Its:div>
            <Its:split runat="server" Type="Vertical" Resizeable="false" />
            <Its:div runat="server" Type="SplitRight">
                <Its:grid runat="server" ID="grid_COMLOT" />
            </Its:div>
        </Its:div>
    </Its:pop>
</asp:Content>
