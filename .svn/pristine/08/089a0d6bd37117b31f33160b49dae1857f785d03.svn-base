<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="SAL0001_S04.aspx.cs" Inherits="SAL0001_S04" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" runat="Server">
    <script type="text/javascript" src="SAL0001_S04.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH PANEL --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:dateRange runat="server" Label="출고일자" FieldFrom="SDATE" FieldTo="EDATE" ID="date_SALDATE"/>
        <Its:find runat="server" Label= "거래처" Field="CUSTCD" GPCD ="CUSTCD" REF03="Y"/>
        <Its:combo runat="server" Label="품목유형" Field="ITEMTP" GPCD="*ITEMTP" />        
        <Its:find runat="server" Label= "품목코드" Field="ITEMCD"  GPCD ="ITEMCD" REF01="PRD"/>
    </Its:div>

</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" runat="Server">
        <Its:div runat="server" Type="SplitSingle">
            <Its:grid runat="server" ID="grid1" />
        </Its:div>
       
</asp:Content>
