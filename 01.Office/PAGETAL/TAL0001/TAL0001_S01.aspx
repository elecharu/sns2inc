<%--태블릿 재고조회--%>
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Kiosk/Kiosk.master" AutoEventWireup="true" 
    CodeFile="TAL0001_S01.aspx.cs" Inherits="TAL0001_S01" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TAL0001_S01.js?ver=<%= BasePage.srcVersion %>"></script>
      <style type="text/css">
        /*#grid1 { height:675px !important; }
        #grid2 { height:675px !important; }*/
    </style>
</asp:Content>


<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitTop" ID="sdiv1">
        <Its:combo runat="server" Label="창고" Field="WARECD" GPCD="*WARECD" ID="sdiv1_WARECD"  MarginTop="10" MarginBottom="10"/> 
        <its:combo runat="server" Label="품목유형" Field="ITEMTP" GPCD="*ITEMTP" id="cmb_ITEMTP" MarginTop="10" MarginBottom="10"/>
        <Its:find runat="server"  Label="품목코드" Field="ITEMCD" GPCD="ITEMCD" ID="find_ITEMCD" InputWidth="200" NameWidth="170" MarginTop="10" MarginBottom="10"/>
        <Its:button runat="server" Label="재고조회" ID="button_SEARCHLOT"   Width="100" BackColor="CustomButton2" MarginLeft="20" MarginTop="10" MarginBottom="10"/>
    </Its:div>

    <Its:split runat="server" Type="Horizon" Resizeable="false" />

    <Its:div runat="server" Type="SplitDown">
        <Its:div runat="server" Type="SplitLeft"  LeftWidthPc="60">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>

        <Its:split runat="server" Type="Vertical"  Resizeable="false"/>

        <Its:div runat="server" Type="SplitRight" >
            <Its:grid runat="server" ID="grid2" />
        </Its:div>
    </Its:div>
</asp:Content>