<%-- TAL0001_R09: 설비부품 출고등록 (태블릿) --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true"
    CodeFile="TAL0001_R09.aspx.cs" Inherits="TAL0001_R09" %>


<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server" >
    <script type="text/javascript" src="TAL0001_R09.js?ver=<%= BasePage.srcVersion %>"></script>
    <link rel="stylesheet" href="TAL0001_R09.css?ver=<%= BasePage.srcVersion %>" />

</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="div1">
        <Its:button runat="server" Label="설비부품 재고조회" ID="btn_SEARCH" BackColor="CommonButton" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="220" Height="50" />
    </Its:div>
    <Its:split runat="server" Type="Horizon" Resizeable="false" />
    <Its:div runat="server" Type="SplitDown">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop_OUT" Type="add" Title="설비부품 출고등록" Width="600">
        <Its:div runat="server" ID="pdiv_OUT">
            <Its:date runat="server" Label="출고일자" ID="pop_date_OUTDATE" Field="OUTDATE" LabelWidth="90" MarginTop="10" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="품목코드" ID="pop_txt_ITEMCD" LabelWidth="90" InputWidth="420" ReadOnly="true" MarginTop="10" />
            <Its:newline runat="server" />
            <Its:text runat="server" Label="품명" ID="pop_txt_ITEMNM" LabelWidth="90" InputWidth="420" ReadOnly="true" MarginTop="10" />
            <Its:newline runat="server" />
            <Its:combo runat="server" Label="출고구분" ID="pop_cmb_OUTTP" Field="OUTTP" GPCD="INOUTTP_EQMPARTS" REF01="OUT" LabelWidth="90" InputWidth="361" MarginTop="10" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="출고수량" ID="pop_num_OUTQTY" Field="OUTQTY" DecimalPoint="0" LabelWidth="90" InputWidth="420" MarginTop="10" />
            <Its:newline runat="server" />
            <Its:find runat="server" Label="출고자" ID="pop_find_EMPCD" Field="EMPCD" GPCD="EMPCD" LabelWidth="90" InputWidth="150" NameWidth="234" MarginTop="10" MarginBottom="10" />
            <Its:text runat="server" Label="품목ID" ID="pop_txt_ITEMID" Field="ITEMID" Hidden="true" />
        </Its:div>
    </Its:pop>

    <Its:pop runat="server" ID="pop_HIS" Title="출고 이력" Width="950" Height="510">
        <Its:div runat="server" Type="SplitTop" ID="pdiv_HIS">
            <Its:dateRange runat="server" Label="조회일자" ID="pop_date_HIS" FieldFrom="SDATE" FieldTo="EDATE" MarginTop="10" />
            <Its:button runat="server" Label="출고 이력조회" ID="btn_SEARCH_HIS" BackColor="CommonButton" MarginTop="10" MarginLeft="20" MarginBottom="10" Width="180" Height="40" />
            <Its:text runat="server" Label="품목ID" ID="pop_txt_HIS_ITEMID" Field="ITEMID" Hidden="true" />
        </Its:div>
        <Its:split runat="server" Type="Horizon" Resizeable="false" />
        <Its:div runat="server" Type="SplitDown">
            <Its:grid runat="server" ID="grid_HIS" />
        </Its:div>
    </Its:pop>
</asp:Content>
