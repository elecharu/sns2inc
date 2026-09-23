<%-- 재고이동등록 --%>

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PDA1700_R02.aspx.cs" Inherits="PDA1700_R02" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PDA1700_R02.js?ver=<%= BasePage.srcVersion %>"></script>
    <style type="text/css">                
        div.ItsText_table > input { text-align: right;}        
    </style>

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="BasicBlock" ID="Div1">
        
         
        <Its:text runat="server" Label="로트번호" Field="LOTKEY" GPCD="LOTKEY" ID="txt_LOTKEY" LabelWidth="70"  InputWidth="200" align="right"/>
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Label="거래처" Field="CUSTCD" GPCD="CUSTCD" ID="txt_CUSTCD" LabelWidth="70"  InputWidth="200" ReadOnly="true" align="right"/>
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Label="품명" Field="ITEMCD" GPCD="ITEMCD" ID="txt_ITEMCD" LabelWidth="70"  InputWidth="200" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Label="규격" Field="SPECNM"  ID="txt_SPECNM" LabelWidth="70"  InputWidth="88" ReadOnly="true" align="right" />
        <Its:text runat="server" Field="SPECNUM" Label="" LabelWidth="0" InputWidth="88" ID="txt_SPECNUM" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Label="공정" Field="PRCCD" ID="txt_PRCCD" LabelWidth="70"  InputWidth="200" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Field="LOTQTY" Label="현재수량" LabelWidth="70"  InputWidth="150" ID="txt_SCAN_LOTQTY" ReadOnly="true" align="right" />
        <Its:text runat="server" Field="ITEMUNIT" Label="" LabelWidth="0" InputWidth="25" ID="txt_SCAN_ITEMUNIT" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Label="납기일" Field="EXPDATE"  ID="txt_EXPDATE" LabelWidth="70"  InputWidth="200" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />
        <Its:text runat="server" Label="납품형태" Field="EXPKIND"  ID="txt_EXPKIND" LabelWidth="70"  InputWidth="200" ReadOnly="true" align="right" />
        <Its:newline runat="server" Height="5" />

    </Its:div>
</asp:Content>

