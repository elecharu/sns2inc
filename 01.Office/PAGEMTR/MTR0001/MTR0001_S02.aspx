<%--재고조회--%>
<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="MTR0001_S02.aspx.cs" Inherits="MTR0001_S02" %>

<%-- HEAD 'src' --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="MTR0001_S02.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:combo runat="server" Label="창고" Field="WARECD" GPCD="*WARECD" ID="sdiv1_WARECD"  /> 
        <its:combo runat="server" Label="품목유형" Field="ITEMTP" GPCD="*ITEMTP" id="cmb_ITEMTP" />
        <Its:find runat="server"  Label="품목코드" Field="ITEMCD" GPCD="ITEMCD"  />
        <%--<Its:button runat="server" Label="라벨출력" ID="btn_PRINT_COMLOT" Width="100" Padding_Left="200px" BackColor="CustomButton2" />--%>     
    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" LeftWidthPc="70">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>

    <Its:split runat="server" Type="Vertical" />

    <Its:div runat="server" Type="SplitRight">
        <Its:grid runat="server" ID="grid2" />
    </Its:div>  
</asp:Content>


