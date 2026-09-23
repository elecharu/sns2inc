<%--BOM정보--%>
<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="MST0001_R10.aspx.cs" Inherits="MST0001_R10" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="MST0001_R10.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="품목유형" ID="Combo_ITEMTP" Field="ITEMTP" GPCD="*ITEMTP"/>
        <Its:find runat="server" Label="품목코드" ID="sdiv1_find_ITEMCD" Field="ITEMCD" GPCD="ITEMCD" REF01="PRD"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="40">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid2" />
    </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="하위 BOM 추가" Width="600">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:find runat="server" Label="모품목코드" Field="MITEMCD" GPCD="ITEMCD" ID="find_MITEMCD" ReadOnly="true"/>
            <Its:num runat="server" Label="모품목 기준수량" Field="MUSAGE" DecimalPoint="3" LabelWidth="150"/>
            <Its:newline runat="server" />
            <Its:find runat="server" Label="자품목코드" Field="CITEMCD" GPCD="ITEMCD" ID="pdiv1_find_CITEMCD" REF01="MTR"/>
            <Its:num runat="server" Label="자품목 소요수량" Field="CUSAGE" DecimalPoint="3" LabelWidth="150" />
            <Its:newline runat="server" />
<%--            <Its:find runat="server" Label="공정" Field="PRCCD" GPCD="PRCCD" ID="find_PRCCD"/>   --%>
            <Its:num runat="server" Label="자품목 LOSS수량" Field="LUSAGE" DecimalPoint="3" LabelWidth="150" MarginLeft="283"/>
            <Its:newline runat="server" />
            <Its:check runat="server" Label="사용여부" Field="USEYN" MarginLeft="30" />
            <Its:combo runat="server" Label="단위" ID="pdiv1_combo_ITEMUNIT" Field="ITEMUNIT" GPCD="ITEMUNIT" LabelWidth="50" MarginLeft="10"/>
            <Its:text runat="server" Label="비고"  Field="REMARK" LabelWidth="70" InputWidth="190"/>
            <Its:newline runat="server" />
        </Its:div>
    </Its:pop>

</asp:Content>