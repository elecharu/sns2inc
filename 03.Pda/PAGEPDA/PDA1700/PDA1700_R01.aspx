<%-- 재고이동등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PDA1700_R01.aspx.cs" Inherits="PDA1700_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PDA1700_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <style type="text/css">                
        div.ItsText_table > input { text-align: right;}        
    </style>

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="BasicBlock" ID="Div1">
        <Its:combo runat="server" Label="현창고" Field="WARECD_FROM" GPCD ="WARECD" ID="cmb_WARECD_FROM" Required="true" LabelWidth="70" InputWidth="178"/>        
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Field="LOTKEY" Label="LOT스캔" LabelWidth="70" InputWidth="200" ID="txt_SCAN_LOTKEY" ReadOnly="false"/>
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Field="ITEMCD" Label="품목코드" LabelWidth="70"  InputWidth="200" ID="txt_SCAN_ITEMCD" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Field="ITEMNM" Label="품명" LabelWidth="70"  InputWidth="200" ID="txt_SCAN_ITEMNM" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Field="CARMODEL" Label="차종" LabelWidth="70"  InputWidth="200" ID="txt_SCAN_CARMODEL" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Field="LOTQTY" Label="이동수량" LabelWidth="70"  InputWidth="150" ID="txt_SCAN_LOTQTY" ReadOnly="true" align="right" />
        <Its:text runat="server" Field="ITEMUNIT" Label="" LabelWidth="0" InputWidth="25" ID="txt_SCAN_ITEMUNIT" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:combo runat="server" Label="이동창고" Field="WARECD_TO" GPCD ="WARECD"  ID="cmb_WARECD_TO" Required="true" LabelWidth="70" InputWidth="178"/>        
        <Its:newline runat="server" Height="5" />
        <Its:button runat="server" Label="재고이동" Width="300" Height="40" ID="btn_MOVE_COMLOT" />
    </Its:div>
</asp:Content>

