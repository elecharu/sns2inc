<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PDA1100_R01.aspx.cs" Inherits="PDA1100_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PDA1100_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>
<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="BasicBlock" >        
        <Its:combo runat="server" Label="창고" LabelWidth="100" InputWidth="90" Field="WARECD" GPCD="WARECD" ID="cmb_WARECD"/>
        <Its:button runat="server" Label="조회" Width ="100" Height="30" ID="btn_LIST_COMLOT_ITEMTP" />
        <Its:newline runat="server" Height="5" />
        <Its:grid runat="server" ID="grid1" Height ="370"/>
        <Its:newline runat="server" Height="5" />
        <Its:button runat="server" Label="선택" Width="350" Height="40" ID="btn_SELECT_ITEMTP" />
    </Its:div>
</asp:Content>


<asp:Content ContentPlaceHolderID="CPH_POP" runat="Server">
    <Its:pop runat="server" ID="pop_LIST_COMLOT_ITEMCD" Title="품목선택" Width="370">
        <Its:newline runat="server" Height="5" />
        <Its:grid runat="server" ID="grid2" Height ="370"/>
        <Its:newline runat="server" Height="5" />
        <Its:button runat="server" Label="선택" Width="350" Height="40" ID="btn_SELECT_ITEMCD" />
        <Its:newline runat="server" Height="5" />
    </Its:pop>

    <Its:pop runat="server" ID="pop_LIST_COMLOT" Title="현재고" Width="370">
        <Its:newline runat="server" Height="5" />
        <Its:grid runat="server" ID="grid3" Height="400"/>
        <Its:newline runat="server" Height="5" />
    </Its:pop>
</asp:Content>