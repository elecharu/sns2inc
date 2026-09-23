<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SAL0001_R03.aspx.cs" Inherits="SAL0001_R03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SAL0001_R03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="납기일자" FieldFrom="SDATE" FieldTo="EDATE" ID="date_SALDATE"/>
        <Its:find runat="server" Label= "거래처" Field="CUSTCD"  GPCD ="CUSTCD" REF03="Y"/>
        <Its:combo runat="server" Label="품목유형" Field="ITEMTP" GPCD="*ITEMTP" />        
        <Its:find runat="server" Label= "품목코드" Field="ITEMCD"  GPCD ="ITEMCD" REF01="PRD"/>
        <Its:button runat="server" Label="출고확정" ID="btn_CONFIRM_SALOUT" Width="100" MarginLeft="20"  BackColor="CustomButton2" />    
        <Its:button runat="server" Label="출하확정취소" ID="btn_CANCLE_SALOUT" Width="100" MarginLeft="400"  BackColor="CustomButton3" />    
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server"> 
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="75">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>
    <Its:split runat="server" Type="Vertical" />
    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid2" />
    </Its:div>
</asp:Content>

