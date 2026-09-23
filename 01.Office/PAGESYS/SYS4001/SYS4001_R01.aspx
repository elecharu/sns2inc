<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="SYS4001_R01.aspx.cs" Inherits="SYS4001_R01" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="SYS4001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="사업장" Field="BDVCD" GPCD="*BDVCD"/>
        <Its:find runat="server" Label="차종" Field="BRANDCD" GPCD="BRANDCD" />
        <Its:find runat="server" Label="제품" Field="ITEMCD" GPCD="ITEMCD" />
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitSingle" >
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="기초 재고 추가" Width="490">
        <Its:div runat="server" Type="BasicBlock" ID="pdiv1">
            <Its:combo runat="server" Label="사업장" Field="BDVCD" GPCD="BDVCD"/>
            <Its:date runat="server" Label="적용일자" Field="BASDT" ID="date_BASDT" />
            <Its:newline runat="server" />
            <Its:find runat="server" Label="제품" Field="ITEMCD" GPCD="ITEMCD" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="수량" Field="STOCKQTY" ID="num_STOCKQTY" Value="0" TriggerButton="false" />
            <Its:combo runat="server" Label="단위" Field="ITEMUNIT" GPCD="ITEMUNIT" Value="01" />
            <Its:newline runat="server" />
            <Its:num runat="server" Label="단가" Field="UNITCOST" ID="num_UNITCOST" Value="0" TriggerButton="false" />
            <Its:num runat="server" Label="금액" Field="STOCKAMT" ID="num_STOCKAMT" Value="0" TriggerButton="false" ReadOnly="true" />
        </Its:div>
    </Its:pop>
</asp:Content>