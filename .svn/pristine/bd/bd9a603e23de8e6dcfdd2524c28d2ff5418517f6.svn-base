

<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="PRD1001_R01.aspx.cs" Inherits="PRD1001_R01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="PRD1001_R01.js?ver=<%= BasePage.srcVersion %>"></script>
    <style type="text/css">
        #sdiv1_lbl_TITLE { color: blue; }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="CPH_CUSTOM_BUTTON" runat="server">
    <Its:button runat="server" Label="계획확정" ID="btn_MPLAN_CONFIRM" MarginLeft="50"/>
    <Its:button runat="server" Label="확정취소" ID="btn_MPLAN_CANCEL" />
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:month runat="server" Label="조회년월" Field="SMONTH" ID="sdiv1_mon_SMONTH" />
        <%--<Its:combo runat="server" Label="법인" InputWidth="130" Field="COMPANYCD" GPCD="COMPANYCD" ID="sdiv1_cmb_COMPANYCD" />--%>
        <Its:combo runat="server" Label="공장" Field="FACTORYCD" GPCD="FACTORYCD" ID="sdiv1_cmb_FACTORYCD" ReadOnly="true"/>        
        <Its:find runat="server" Label="품목코드" Field="ITEMID" GPCD="ITEMID" ID="sdiv1_find_ITEMID" />
        <Its:display runat="server" HiddenLabel="true" InputWidth="200" Field="TITLE" ID="sdiv1_lbl_TITLE" MarginLeft="30"/>
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
</asp:Content>

<%--POP--%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    

</asp:Content>
